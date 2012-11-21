using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using REACH.Client.Base;
using REACH.Client.Core;
using REACH.Client.Models;
using REACH.Client.Controllers;
using REACH.Common.Data;

namespace REACH.Client.Views
{
	public partial class LoginView : Form, IView
	{
		private LoginController controller;

		private const string EMPTY_USER_OR_PASSWORD =
			"The username and password fields cannot be empty.";
		private const string INVALID_CREDENTIALS_ERROR = 
			"The user does not exist or the user and the password do not match.";
		private const string TIMEOUT_ERROR = 
			"The server is unreachable.";
		
		public LoginView()
		{
			// Create the controller
			controller = new LoginController();

            // Handlers for external events
            controller.ConnectAccept += new LoginController.ExternalEventHandler(OnConnectAccept);
            controller.ConnectDeny += new LoginController.ExternalEventHandler(OnConnectDeny);
            controller.ConnectTimeOut += new LoginController.ExternalEventHandler(OnConnectTimeOut);

            // Register the controller handlers to the service
            controller.RegisterHandlers();

            // Initialize Component
            InitializeComponent();
	
			// Handlers for internal events
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(OnFormClosing);
			ConnectButton.Click += new System.EventHandler(ConnectButton_Click);
			password.KeyDown += new System.Windows.Forms.KeyEventHandler(password_KeyDown);
			username.KeyDown += new System.Windows.Forms.KeyEventHandler(username_KeyDown);
			CreateAccountButton.Click += new System.EventHandler(CreateAccountButton_Click);
		}

		/*
		 * Handlers for internal events
		 */
		#region internal_events

		private void OnFormClosing(object sender, FormClosingEventArgs e)
		{
			controller.UnregisterHandlers();
		}

		private void ConnectButton_Click(object sender, EventArgs e)
		{
			if (username.Text.Length == 0 || password.Text.Length == 0)
			{
				errorMessage.Visible = true;
				errorMessage.Text = EMPTY_USER_OR_PASSWORD;
				return ;
			}

			this.Enabled = false;
			errorMessage.Visible = true;
			errorMessage.Text = "Operation in progress...";
			controller.Connect(username.Text, password.Text);
		}

		private void username_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				ConnectButton_Click(null, null);
		}

		private void password_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				ConnectButton_Click(null, null);
		}

		private void SkipButton_Click(object sender, EventArgs e)
		{
			this.Enabled = false;
			errorMessage.Visible = true;
			errorMessage.Text = "Operation in progress...";
			controller.Connect("test", "test");
		}

		private void CreateAccountButton_Click(object sender, EventArgs e)
		{
			ReachWindow mainWindow = (ReachWindow)Context.EntryPoint;
			mainWindow.CloseAllChildren();
			new NewAccountView();
		}

		#endregion

		/*  
		 * Handlers for external events 
		 */
		#region external_events

		private void OnConnectAccept(LoggedInUserModel model)
		{
			while (!this.IsHandleCreated) ;
			if (this.InvokeRequired)
			{
				this.Invoke((LoginController.ExternalEventHandler)
					OnConnectAccept, model);
				return;
			}

			errorMessage.Visible = false;

			// Start the new views
			new QuestionListView();
			new FriendListView();
			((ReachWindow)(Context.EntryPoint)).ShowItemsInToolbar();

			this.Close();
		}

		private void OnConnectDeny(LoggedInUserModel model)
		{
			while (!this.IsHandleCreated) ;
			if (this.InvokeRequired)
			{
				this.Invoke((LoginController.ExternalEventHandler)
					OnConnectDeny, model);
				return;
			}

			this.Enabled = true;
			errorMessage.Visible = true;
			errorMessage.Text = INVALID_CREDENTIALS_ERROR;
		}

		private void OnConnectTimeOut(LoggedInUserModel model)
		{
			while (!this.IsHandleCreated) ;
			if (this.InvokeRequired)
			{
				this.Invoke((LoginController.ExternalEventHandler)
					OnConnectTimeOut, model);
				return;
			}

			this.Enabled = true;
			errorMessage.Visible = true;
			errorMessage.Text = TIMEOUT_ERROR;
		}

		#endregion

	}
}
