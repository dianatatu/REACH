using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using REACH.Client.Core;
using REACH.Client.Base;
using REACH.Client.Models;
using REACH.Client.Controllers;
using REACH.Common.Data;

namespace REACH.Client.Views
{
    public partial class FriendListView : Form, IView
    {
        private FriendListController controller;

        private const int lineHeight = 25;
        private const int CP_NOCLOSE_BUTTON = 0x200;

        public delegate void EmptyFunction();
        private Dictionary<Button, uint> denyButtons = new Dictionary<Button, uint>();
        private Dictionary<Button, uint> acceptButtons = new Dictionary<Button, uint>();
        private Dictionary<Label, uint> nameLabels = new Dictionary<Label, uint>();

        public FriendListView()
        {
            // Create the controller
            controller = new FriendListController();

            // Handlers for external events
            controller.FriendListStateChanged += new FriendListController.ExternalEventHandler(OnFriendListStateChanged);
            controller.ThisUserStateChanged += new FriendListController.ExternalEventHandler(OnThisUserStateChanged);

            // Register the controller handlers to the service
            controller.RegisterHandlers();

            // Initialize Component
            InitializeComponent();

            // Set the parent and display the window
            SetMdiParent();
            ShowForm();

            // Handlers for internal events			
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FriendListView_FormClosing);
			addFriendTextBox.Enter += new System.EventHandler(this.addFriendTextBox_Enter);
			addFriendTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.addFriendTextBox_KeyDown);
			addFriendTextBox.Leave += new System.EventHandler(this.addFriendTextBox_Leave);
        }

        // Disable close button
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        private void SetMdiParent()
        {
            ReachWindow f = (ReachWindow)Context.EntryPoint;
            if (f.InvokeRequired)
            {
                f.Invoke((EmptyFunction)SetMdiParent, null);
                return;
            }
            this.MdiParent = f;
        }

        public void ShowForm()
        {
            if (this.InvokeRequired)
            {
                this.Invoke((EmptyFunction)ShowForm, null);
                return;
            }
            this.Show();
        }

        /*
         * Handlers for internal events
         */
        #region internal_events

        private void FriendListView_FormClosing(object sender, FormClosingEventArgs e)
        {
            controller.UnregisterHandlers();
        }

        private void FriendListView_Load(object sender, EventArgs e)
        {
			this.Bounds = new Rectangle(
				new Point(Context.EntryPoint.Width-this.Size.Width-25, 10), 
				this.Size);			

            controller.UpdateUserState(false);
            controller.PopulateFriendList();
        }

        private void toggleStatusButton_Click(object sender, EventArgs e)
        {
            controller.UpdateUserState(toggleStatusButton.Text.Equals("Go Online"));
        }

        private void customStylesCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            controller.StyleChoiceChanged(((CheckBox)sender).Checked);
        }

        private void OnNameClick(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            uint id = nameLabels[label];
            controller.OpenConversation(id);
        }

        private void OnAccept(object sender, EventArgs e)
        {
            Button label = (Button)sender;
            uint id = acceptButtons[label];
            controller.ResponseFriendRequest(id, true);
        }

        private void OnDeny(object sender, EventArgs e)
        {
            Button label = (Button)sender;
            uint id = denyButtons[label];
            controller.ResponseFriendRequest(id, false);
        }

        private void ColorNameLabel(object sender, EventArgs e)
        {
            ((Label)sender).BackColor = Color.DarkGray;
        }

        private void UncolorNameLabel(object sender, EventArgs e)
        {
            ((Label)sender).BackColor = Color.White;
        }

		private void addFriendTextBox_Enter(object sender, EventArgs e)
		{
			addFriendTextBox.Text = "";
		}

		private void addFriendTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				controller.AddFriend(addFriendTextBox.Text);
				addFriendTextBox.Text = "";
				addFriendTextBox.Focus();
			}
		}

		private void addFriendTextBox_Leave(object sender, EventArgs e)
		{
			addFriendTextBox.Text = "Add a friend...";
		}

        private void offlineCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            controller.refreshFriendList();
        }

        private void invitedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            controller.refreshFriendList();
        }

        private void invitingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            controller.refreshFriendList();
        }

        #endregion

        /*
		 * Handlers for external events
		 */
        #region external_events

        private void OnFriendListStateChanged(FriendListModel model)
        {
            while (!this.IsHandleCreated) ;
            if (this.InvokeRequired)
            {
                this.Invoke((FriendListController.ExternalEventHandler)
                    OnFriendListStateChanged, model);
                return;
            }
            nameLabels.Clear();
            denyButtons.Clear();
            acceptButtons.Clear();
            uint thisUserId = LoggedInUserModel.Instance.User.Id;
            int index = 0;
            panel1.Controls.Clear();
            panel1.Focus();
            panel1.SuspendLayout();
            // Online users
            foreach (UserData user in model.Users)
            {
                FriendshipData friendship = model.GetFriendshipById(user.Id);
                if (friendship.Status && user.Status)
                    PutUserOnList(thisUserId, index++, user, model, friendship.Status, user.Status);
            }
            // Offline users
            if (offlineCheckBox.Checked)
                foreach (UserData user in model.Users)
                {
                    FriendshipData friendship = model.GetFriendshipById(user.Id);
                    if (friendship.Status && !user.Status)
                        PutUserOnList(thisUserId, index++, user, model, friendship.Status, user.Status);
                }
            // Inviting users
            if (invitingCheckBox.Checked)
                foreach (UserData user in model.Users)
                {
                    FriendshipData friendship = model.GetFriendshipById(user.Id);
                    if (!friendship.Status && friendship.Latter == thisUserId)
                        PutUserOnList(thisUserId, index++, user, model, friendship.Status, user.Status);
                }
            // Invited users
            if (invitedCheckBox.Checked)
                foreach (UserData user in model.Users)
                {
                    FriendshipData friendship = model.GetFriendshipById(user.Id);
                    if (!friendship.Status && friendship.Latter != thisUserId)
                        PutUserOnList(thisUserId, index++, user, model, friendship.Status, user.Status);
                }
            panel1.ResumeLayout();
            panel1.PerformLayout();
        }

        private void PutUserOnList(uint thisUserId, int index, UserData user, FriendListModel model, bool friendshipStatus, bool onlineStatus)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FriendListView));
            PictureBox icon = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)(icon)).BeginInit();
            if (!friendshipStatus)
                icon.Image = global::REACH.Client.Properties.Resources.user_pending;
            else if (onlineStatus)
                icon.Image = global::REACH.Client.Properties.Resources.user_online;
            else
                icon.Image = global::REACH.Client.Properties.Resources.user_offline;
            icon.Location = new Point(lineHeight - 20, index * lineHeight + 2);
            icon.Size = new Size(20, 20);
            panel1.Controls.Add(icon);
          
            FriendshipData friendship = model.GetFriendshipById(user.Id);
            if (!(friendship.Status))
            {
                if (friendship.Latter == thisUserId)
                {
                    Button acceptButton = new Button();
                    acceptButton.Text = "accept";
                    acceptButton.Location = new Point(130, index * lineHeight);
                    acceptButton.Size = new Size(80, lineHeight);
                    acceptButton.AutoSize = false;
                    acceptButton.Click += new System.EventHandler(this.OnAccept);
                    acceptButtons.Add(acceptButton, user.Id);
                    panel1.Controls.Add(acceptButton);

                    Button denyButton = new Button();
                    denyButton.Text = "deny";
                    denyButton.Location = new Point(210, index * lineHeight);
                    denyButton.Size = new Size(80, lineHeight);
                    denyButton.AutoSize = false;
                    denyButton.Click += new System.EventHandler(this.OnDeny);
                    denyButtons.Add(denyButton, user.Id);
                    panel1.Controls.Add(denyButton);
                }
            }

            Label friendname = new Label();
            friendname.Text = user.Username;
            friendname.Location = new Point(30, index * lineHeight);
			friendname.Font = new Font(
				"Microsoft Sans Serif", 
				9.75F, 
				FontStyle.Regular, 
				GraphicsUnit.Point, ((byte)(0)));
            friendname.AutoSize = false;
            friendname.Size = new Size(panel1.Width - 55, lineHeight);
            friendname.Click += new System.EventHandler(this.OnNameClick);
            friendname.MouseEnter += new System.EventHandler(this.ColorNameLabel);
            friendname.MouseLeave += new System.EventHandler(this.UncolorNameLabel);
            nameLabels.Add(friendname, user.Id);
            panel1.Controls.Add(friendname);
        }

        private void OnThisUserStateChanged(FriendListModel model)
        {
            while (!this.IsHandleCreated) ;
            if (this.InvokeRequired)
            {
                this.Invoke((FriendListController.ExternalEventHandler)
                    OnThisUserStateChanged, model);
                return;
            }
            if (LoggedInUserModel.Instance.User.Status)
            {
                toggleStatusButton.Text = "Go Offline";
                panel1.Visible = true;
                addFriendTextBox.Visible = true;
                customStylesCheckbox.Visible = true;
                offlineCheckBox.Visible = true;
                invitingCheckBox.Visible = true;
                invitedCheckBox.Visible = true;
            }
            else
            {
                toggleStatusButton.Text = "Go Online";
                panel1.Visible = false;
                addFriendTextBox.Visible = false;
                customStylesCheckbox.Visible = false;
                offlineCheckBox.Visible = false;
                invitingCheckBox.Visible = false;
                invitedCheckBox.Visible = false;
            }
        }

        #endregion

    }
}