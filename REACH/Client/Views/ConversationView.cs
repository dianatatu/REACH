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
    public partial class ConversationView : Form, IView
    {
        private ConversationController controller;
		private bool _styleChoice;
        private string _name;
        private bool initialSay;
        public uint _id;

        public delegate void EmptyFunction();

        public ConversationView(uint id, bool styleChoice)
        {
			// Create the controller
			controller = new ConversationController(id);

            // Handlers for external events
			controller.NewSay += new ConversationController.ExternalEventHandler(OnNewSay);
			controller.ChangeUserState += new ConversationController.ExternalEventHandler(OnChangeUserState);
            controller.ReceivedPartnerInfo += new ConversationController.ExternalEventHandler(OnReceivedParnterInfo);

            // Register the controller handlers to the service
            controller.RegisterHandlers();

			// Initialize Component
            InitializeComponent();
			_styleChoice = styleChoice;
            _id = id;
            
            // Set the parent and display the window
            SetMdiParent();
            ShowForm();

            // Handlers for internal events			
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FriendListView_FormClosing);    
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

		private void ConversationView_Load(object sender, EventArgs e)
		{
			styleCheckbox.Checked = _styleChoice;
			styleCheckbox_CheckedChanged(styleCheckbox, null);
            controller.GetPartnerInfo();
		}

        private void FriendListView_FormClosing(object sender, FormClosingEventArgs e)
        {
            controller.UnregisterHandlers();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                sayButton_Click(sender, e);
        }

        private void sayButton_Click(object sender, EventArgs e)
        {
            Font font = saysTextbox.SelectionFont;
            Color color = saysTextbox.SelectionColor;
            controller.AddSay(saysTextbox.Text, saysTextbox.Rtf);            
            saysTextbox.Text = "";
            saysTextbox.SelectionColor = color;
            saysTextbox.SelectionFont = font;
            saysTextbox.Focus();
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog1 = new ColorDialog();

            // Set the initial color of the dialog to the current text color.
            colorDialog1.Color = saysTextbox.SelectionColor;

            // Determine if the user clicked OK in the dialog and that the color has changed.
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               colorDialog1.Color != saysTextbox.SelectionColor)
            {
                // Change the selection color to the user specified color.
                saysTextbox.SelectionColor = colorDialog1.Color;
            }
            saysTextbox.Focus();
        }

        private void backcolorButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog1 = new ColorDialog();

            // Set the initial color of the dialog to the current text color.
            colorDialog1.Color = saysTextbox.SelectionBackColor;

            // Determine if the user clicked OK in the dialog and that the color has changed.
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               colorDialog1.Color != saysTextbox.SelectionBackColor)
            {
                // Change the selection color to the user specified color.
                saysTextbox.SelectionBackColor = colorDialog1.Color;
            }
            saysTextbox.Focus();
        }

        private void fontButton_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();

            // Set the initial color of the dialog to the current text color.
            fontDialog.Font = saysTextbox.Font;

            // Determine if the user clicked OK in the dialog and that the color has changed.
            if (fontDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               fontDialog.Font != saysTextbox.SelectionFont)
            {
                // Change the selection color to the user specified color.
                saysTextbox.SelectionFont = fontDialog.Font;
            }
            saysTextbox.Focus();
        }

        private void saysTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                saysTextbox.SelectionStart = saysTextbox.SelectionStart - 1;
                saysTextbox.SelectionLength = 1;
                saysTextbox.SelectedText = "";
                saysTextbox.SelectionStart = saysTextbox.Text.Length;
                if (sayButton.Enabled && saysTextbox.Text.Length>0)
                {                    
                    sayButton_Click(sender, e);                    
                }                
            }
            if (e.KeyChar == 10)
            {
                saysTextbox.SelectionStart += saysTextbox.TextLength;
            }
        }

        private void styleCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            bool customStyle = ((CheckBox)sender).Checked;
            if (customStyle)
            {
                richConversationTextbox.Visible = true;
                normalConversationTextbox.Visible = false;
                richConversationTextbox.ScrollToCaret();
            }
            else
            {
                richConversationTextbox.Visible = false;
                normalConversationTextbox.Visible = true;
                normalConversationTextbox.ScrollToCaret();
            }
            saysTextbox.Focus();
        }

        #endregion
        /*
		 * Handlers for external events
		 */
        #region external_events

        private void OnChangeUserState(ConversationModel model)
		{
			while (!this.IsHandleCreated) ;
			if (this.InvokeRequired)
			{
				this.Invoke((ConversationController.ExternalEventHandler)
					OnChangeUserState, model);
				return;
			}

            if (model.Partner.Status)
            {
                sayButton.Enabled = true;
                stateLabel.Text = _name + " is online";
            }
            else
            {
                sayButton.Enabled = false;
                stateLabel.Text = _name + " is offline";
            }
		}

        private void OnNewSay(ConversationModel model)
        {
            if (model.Partner == null)
            {
                initialSay = true;
                return;
            }
			while (!this.IsHandleCreated) ;
            if (this.InvokeRequired)
            {
                this.Invoke((ConversationController.ExternalEventHandler)
                    OnNewSay, model);
                return;
            }
            SayData sayData = model.Says[model.Says.Count - 1];
            richConversationTextbox.SelectionStart = richConversationTextbox.Text.Length;
            if (sayData.Id == LoggedInUserModel.Instance.User.Id)
            {
                richConversationTextbox.SelectionBackColor = Color.LightGray;
                richConversationTextbox.SelectedText = LoggedInUserModel.Instance.User.Username + ": ";
                normalConversationTextbox.SelectedText = LoggedInUserModel.Instance.User.Username + ": ";
            }
            else
            {
                richConversationTextbox.SelectionBackColor = Color.DarkGray;
                richConversationTextbox.SelectedText = _name + ": ";
                normalConversationTextbox.SelectedText = _name + ": ";
            }
            richConversationTextbox.SelectedRtf = sayData.RichSay;
            normalConversationTextbox.SelectedText = sayData.NormalSay+"\r\n";            
            richConversationTextbox.Refresh();
            normalConversationTextbox.ScrollToCaret();
            normalConversationTextbox.Refresh();

            richConversationTextbox.Focus();
            saysTextbox.Focus();
        }


        private void OnReceivedParnterInfo(ConversationModel model)
		{
			while (!this.IsHandleCreated);
			if (this.InvokeRequired)
			{
				this.Invoke((ConversationController.ExternalEventHandler)
					OnReceivedParnterInfo, model);
				return;
			}
            _name = model.Partner.Username;
            this.Text = "Talk to " + _name;
            OnChangeUserState(model);
            if (initialSay)
                OnNewSay(model);
		}

        #endregion

        public uint Id
        {
            get { return _id; }
            set { _id = value; }
        }

    }
}
