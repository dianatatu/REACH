using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using REACH.Client.Base;
using REACH.Client.Views;
using REACH.Client.Models;
using REACH.Common;
using REACH.Common.Base;

namespace REACH.Client
{
    public partial class ReachWindow : Form
    {
		private LoginView login;

        public ReachWindow()
        {
            
            InitializeComponent();
			ShowLoginWindow();
		}

		public void ShowLoginWindow()
		{
			login = new LoginView();
			login.MdiParent = this;
			login.Show();
		}

		public void ShowItemsInToolbar()
		{
			whoIsLoggedIn.Visible = true;
			loggedInUser.Text = LoggedInUserModel.Instance.User.Username;
			loggedInUser.Location = new Point(
				whoIsLoggedIn.Width - loggedInUser.Width - 10,
				loggedInUser.Location.Y);
			label1.Location = new Point(
				loggedInUser.Location.X - label1.Width,
				loggedInUser.Location.Y + 2);
			toolbarSeparator1.Visible = true;
			toolbarSeparator2.Visible = true;
			domainView.Visible = true;
		}

		public void CloseLoginWindow()
		{
			login.Close();
		}

		public void HideItemsInToolbar()
		{
			whoIsLoggedIn.Visible = false;
			toolbarSeparator1.Visible = false;
			toolbarSeparator2.Visible = false;
			domainView.Visible = false;
			domainView.showAllDomains.Text = "Display Domains";
			domainView.domainList.Visible = false;
		}

		public void CloseAllChildren()
		{
			foreach (Form f in MdiChildren)
				f.Close();
		}

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void ReachWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            RMessage msg = new RMessage(MessageType.CHANGE_USER_STATE_REQUEST, false);
            Service.Instance.AddMessage(msg);
            RMessage msg2 = new RMessage(MessageType.END_IT_ALL_REQUEST, false);
            Service.Instance.AddMessage(msg2);
            Service.Instance.Stop();
        }

        private void ShelfMenuStripItem_Click(object sender, EventArgs e)
        {
            String domain = sender.ToString();
            new ShelfView(domain);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox();
        }

    }
}
