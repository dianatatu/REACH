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
	public partial class NewAccountView : Form, IView
	{
		private Color ERROR_COLOR =
			System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
		private Color NORMAL_COLOR =
			System.Drawing.Color.White;

		private Dictionary<String, String> errors;
		private NewAccountController controller;
		
		public delegate void EmptyFunction();

		public NewAccountView()
		{
			// Create the controller
			controller = new NewAccountController();

			// Handlers for external events
			controller.DomainsReceivedFromServer += new NewAccountController.ExternalEventHandler(OnDomainsReceived);
			controller.DomainsTimeOut += new NewAccountController.ExternalEventHandler(OnDomainsTimeOut);
			controller.LocalVerificationComplete += new NewAccountController.ExternalEventHandler(OnLocalVerificationComplete);
			controller.CreateAccountDeny += new NewAccountController.ExternalEventHandler(OnCreateAccountDeny);
			controller.UsernameTaken += new NewAccountController.ExternalEventHandler(OnUsernameTaken);
			controller.Timeout += new NewAccountController.ExternalEventHandler(OnTimeOut);
			controller.CreateAccountInit += new NewAccountController.ExternalEventHandler(OnCreateAccountInit);
			controller.QuizesReceivedFromServer += new NewAccountController.ExternalEventHandler(OnStartTest);

            // Register the controller handlers to the service
            controller.RegisterHandlers();

			// Initialize Component
			InitializeComponent();

			// Set the parent and display the window
			SetMdiParent();
			ShowForm();

			// Handlers for internal events
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(OnFormClosing);
			CreateNewAccountBtn.Click += new System.EventHandler(CreateNewAccountBtn_Click);
			CancelBtn.Click += new System.EventHandler(CancelBtn_Click);
			tryagain.Click += new System.EventHandler(tryagain_Click);
			username.MouseEnter += new System.EventHandler(username_MouseEnter);
			password.MouseEnter += new System.EventHandler(password_MouseEnter);
			confirm.MouseEnter += new System.EventHandler(confirm_MouseEnter);
			email.MouseEnter += new System.EventHandler(email_MouseEnter);
			domains.MouseEnter += new System.EventHandler(domains_MouseEnter);
			username.KeyDown += new System.Windows.Forms.KeyEventHandler(username_KeyDown);
			password.KeyDown += new System.Windows.Forms.KeyEventHandler(password_KeyDown);
			confirm.KeyDown += new System.Windows.Forms.KeyEventHandler(confirm_KeyDown);
			email.KeyDown += new System.Windows.Forms.KeyEventHandler(email_KeyDown);

			username.Focus();
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

		private void mark(Control c, String errorName)
		{
			if (errors.ContainsKey(errorName))
				c.BackColor = ERROR_COLOR;
			else
				c.BackColor = NORMAL_COLOR;				
		}

		/*
		 * Handlers for internal events
		 */
		#region internal_events

		private void OnFormClosing(object sender, FormClosingEventArgs e)
		{
			controller.UnregisterHandlers();
			((ReachWindow)Context.EntryPoint).ShowLoginWindow();
		}

		private void NewAccountView_Load(object sender, EventArgs e)
		{
			status.Visible = true;
			controller.GetAllDomains();
		}

		private void CancelBtn_Click(object sender, EventArgs e)
		{
			ReachWindow mainWindow = (ReachWindow)Context.EntryPoint;
			mainWindow.CloseAllChildren();
		}

		private void CreateNewAccountBtn_Click(object sender, EventArgs e)
		{
			List<DomainData> list = new List<DomainData>();
			for (int i = 0; i < domains.Items.Count; ++i)
				if (domains.GetItemChecked(i))
					list.Add((DomainData)domains.Items[i]);
			controller.ValidateAccount(
				username.Text,
				password.Text,
				confirm.Text,
				email.Text,
				list);
		}

		private void tryagain_Click(object sender, EventArgs e)
		{
			tryagain.Visible = false;
			status.Text = "Loading...";
			controller.GetAllDomains();
		}

		private void username_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				CreateNewAccountBtn_Click(null, null);
				username_MouseEnter(null, null);
			}
		}

		private void password_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				CreateNewAccountBtn_Click(null, null);
				password_MouseEnter(null, null);
			}
		}

		private void confirm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				CreateNewAccountBtn_Click(null, null);
				confirm_MouseEnter(null, null);
			}
		}

		private void email_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				CreateNewAccountBtn_Click(null, null);
				email_MouseEnter(null, null);
			}
		}

		private void username_MouseEnter(object sender, EventArgs e)
		{
			if (errors != null && errors.ContainsKey("username"))
				errorMessage.Text = errors["username"];
		}

		private void password_MouseEnter(object sender, EventArgs e)
		{
			if (errors != null && errors.ContainsKey("password"))
				errorMessage.Text = errors["password"];
		}

		private void confirm_MouseEnter(object sender, EventArgs e)
		{
			if (errors != null && errors.ContainsKey("confirm"))
				errorMessage.Text = errors["confirm"];
		}

		private void email_MouseEnter(object sender, EventArgs e)
		{
			if (errors != null && errors.ContainsKey("email"))
				errorMessage.Text = errors["email"];
		}

		private void domains_MouseEnter(object sender, EventArgs e)
		{
			if (errors != null && errors.ContainsKey("domains"))
				errorMessage.Text = errors["domains"];
		}

		private void NewAccountView_MouseMove(object sender, MouseEventArgs e)
		{
			if (errors != null && errors.ContainsKey("general"))
				errorMessage.Text = errors["general"];
			else
				errorMessage.Text = "";
		}

		#endregion

		/*
		 * Handlers for external events
		 */
		#region external_events
		
		private void OnCreateAccountDeny(NewAccountModel model)
		{
			while (!this.IsHandleCreated);
			if (this.InvokeRequired)
			{
				this.Invoke((NewAccountController.ExternalEventHandler)
					OnCreateAccountDeny, model);
				return;
			}

			errors = model.Errors;
			mark(username, "username");
			mark(password, "password");
			mark(confirm, "confirm");
			mark(email, "email");
			mark(domains, "domains");
			NewAccountView_MouseMove(null, null);
		}

        private void OnDomainsReceived(NewAccountModel model)
		{
			while (!this.IsHandleCreated);
			if (this.InvokeRequired)
			{
				this.Invoke((NewAccountController.ExternalEventHandler)
					OnDomainsReceived, model);
				return;
			}

			domains.Items.Clear();
			domains.Items.AddRange(model.AllDomains.ToArray());
			status.Visible = false;
			tryagain.Visible = false;
			CreateNewAccountBtn.Enabled = true;
		}

		private void OnDomainsTimeOut(NewAccountModel model)
		{
			while (!this.IsHandleCreated) ;
			if (this.InvokeRequired)
			{
				this.Invoke((NewAccountController.ExternalEventHandler)
					OnDomainsTimeOut, model);
				return;
			}

			status.Text = "The server is not reachable.";
			tryagain.Visible = true;
		}

		private void OnLocalVerificationComplete(NewAccountModel model)
		{
			while (!this.IsHandleCreated);
			if (this.InvokeRequired)
			{
				this.Invoke((NewAccountController.ExternalEventHandler)
					OnLocalVerificationComplete, model);
				return;
			}

			this.Enabled = false;
			username.BackColor = NORMAL_COLOR;
			password.BackColor = NORMAL_COLOR;
			confirm.BackColor = NORMAL_COLOR;
			email.BackColor = NORMAL_COLOR;
			domains.BackColor = NORMAL_COLOR;
			errorMessage.Text = "Talking to server...";
		}

		private void OnUsernameTaken(NewAccountModel model)
		{
			while (!this.IsHandleCreated);
			if (this.InvokeRequired)
			{
				this.Invoke((NewAccountController.ExternalEventHandler)
					OnUsernameTaken, model);
				return;
			}

			errors = new Dictionary<string, string>();
			errors["username"] = "Username already taken.";
			errorMessage.Text = errors["username"];
			mark(username, "username");
			this.Enabled = true;			
		}

		private void OnTimeOut(NewAccountModel model)
		{
			while (!this.IsHandleCreated);
			if (this.InvokeRequired)
			{
				this.Invoke((NewAccountController.ExternalEventHandler)
					OnTimeOut, model);
				return;
			}

			errors = new Dictionary<string, string>();
			errors["general"] = "The server is not responding. Try again.";
			errorMessage.Text = errors["general"];
			this.Enabled = true;
		}

        private void OnCreateAccountInit(NewAccountModel model)
		{
			while (!this.IsHandleCreated);
			if (this.InvokeRequired)
			{
				this.Invoke((NewAccountController.ExternalEventHandler)
					OnCreateAccountInit, model);
				return;
			}
			this.Enabled = true;
			errorMessage.Text = "Talking to server...";
		}

		private void OnStartTest(NewAccountModel model)
		{
			while (!this.IsHandleCreated);
			if (this.InvokeRequired)
			{
				this.Invoke((NewAccountController.ExternalEventHandler)
					OnStartTest, model);
				return;
			}

			this.Enabled = false;
			errorMessage.Text = "Test is in progress...";
			new NewAccountTestView(NewAccountTestView.CREATE_NEW_ACCOUNT, null);
		}

		#endregion

	}
}
