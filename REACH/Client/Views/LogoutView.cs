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
using REACH.Common.Base;
using REACH.Common.Data;

namespace REACH.Client.Views
{
	public partial class LogoutView : Panel, IView
	{
		public System.Windows.Forms.PictureBox loggedInImg;
		public System.Windows.Forms.Button LogoutButton;
		public System.Windows.Forms.Button MyAccountButton;
		private LogoutController controller;

		public delegate void EmptyFunction();

		public LogoutView()
		{
			// Create the controller
			controller = new LogoutController();

			// Handlers for external events
			controller.ConnectAccept += new LogoutController.ExternalEventHandler(OnConnectAccept);
			controller.DisconnectAccept += new LogoutController.ExternalEventHandler(OnDisconnect);
            controller.GetUserInfoFromServer += new LogoutController.ExternalEventHandler(OnGetUserInfoFromServer);

			// Register the controller handlers to the service
			controller.RegisterHandlers();

			// Initialize Component
			InitializeComponent();

			// Handlers for internal events
			LogoutButton.Click += new System.EventHandler(LogoutButton_Click);
			MyAccountButton.Click += new System.EventHandler(MyAccountButton_Click);
		}

		public void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogoutView));
			this.LogoutButton = new System.Windows.Forms.Button();
			this.MyAccountButton = new System.Windows.Forms.Button();
			this.loggedInImg = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.loggedInImg)).BeginInit();
			this.SuspendLayout();
			// 
			// LogoutButton
			// 
			this.LogoutButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(209)))), ((int)(((byte)(228)))));
			this.LogoutButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(150)))), ((int)(((byte)(193)))));
			this.LogoutButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(87)))), ((int)(((byte)(147)))));
			this.LogoutButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(130)))), ((int)(((byte)(182)))));
			this.LogoutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.LogoutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LogoutButton.ForeColor = System.Drawing.Color.Black;
			this.LogoutButton.Location = new System.Drawing.Point(58, 13);
			this.LogoutButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.LogoutButton.Name = "LogoutButton";
			this.LogoutButton.Size = new System.Drawing.Size(67, 26);
			this.LogoutButton.TabIndex = 12;
			this.LogoutButton.Text = "Sign Out";
			this.LogoutButton.UseVisualStyleBackColor = false;
			// 
			// MyAccountButton
			// 
			this.MyAccountButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(209)))), ((int)(((byte)(228)))));
			this.MyAccountButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(150)))), ((int)(((byte)(193)))));
			this.MyAccountButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(87)))), ((int)(((byte)(147)))));
			this.MyAccountButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(130)))), ((int)(((byte)(182)))));
			this.MyAccountButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.MyAccountButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MyAccountButton.ForeColor = System.Drawing.Color.Black;
			this.MyAccountButton.Location = new System.Drawing.Point(120, 13);
			this.MyAccountButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.MyAccountButton.Name = "MyAccountButton";
			this.MyAccountButton.Size = new System.Drawing.Size(80, 26);
			this.MyAccountButton.TabIndex = 13;
			this.MyAccountButton.Text = "My Account";
			this.MyAccountButton.UseVisualStyleBackColor = false;
			// 
			// loggedInImg
			// 
			this.loggedInImg.Image = ((System.Drawing.Image)(resources.GetObject("loggedInImg.Image")));
			this.loggedInImg.Location = new System.Drawing.Point(3, 3);
			this.loggedInImg.Name = "loggedInImg";
			this.loggedInImg.Size = new System.Drawing.Size(45, 45);
			this.loggedInImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.loggedInImg.TabIndex = 10;
			this.loggedInImg.TabStop = false;
			// 
			// LogoutView
			// 
			this.Controls.Add(this.MyAccountButton);
			this.Controls.Add(this.LogoutButton);
			this.Controls.Add(this.loggedInImg);
			this.TabIndex = 10;
			this.Visible = false;
			((System.ComponentModel.ISupportInitialize)(this.loggedInImg)).EndInit();
			this.ResumeLayout(false);

		}

		/*
		 * Handlers for internal events
		 */
		#region internal_events

		private void LogoutButton_Click(object sender, EventArgs e)
		{
			controller.Disconnect();
		}

		void MyAccountButton_Click(object sender, EventArgs e)
		{
            MyAccountButton.Enabled = false;
            controller.GetUserInfo();
		}

		#endregion

		/*
		 * Handlers for external events
		 */
		#region external_events

		private void OnConnectAccept(LoggedInUserModel model)
		{
			if (this.InvokeRequired)
			{
				this.Invoke((LogoutController.ExternalEventHandler)
					OnConnectAccept, model);
				return;
			}
			this.Visible = true;
		}

		private void OnDisconnect(LoggedInUserModel model)
		{
			if (this.InvokeRequired)
			{
				this.Invoke((LoginController.ExternalEventHandler)
					OnDisconnect, model);
				return;
			}

			this.Visible = false;
			ReachWindow e = (ReachWindow)Context.EntryPoint;
			e.CloseAllChildren();
			e.HideItemsInToolbar();
			e.ShowLoginWindow();
		}

        private void OnGetUserInfoFromServer(LoggedInUserModel model)
		{
			while (!this.IsHandleCreated);
			if (this.InvokeRequired)
			{
				this.Invoke((LogoutController.ExternalEventHandler)
					OnGetUserInfoFromServer, model);
				return;
			}
            MyAccountButton.Enabled = true;
            new MyAccountView();
		}

		#endregion
	}
}
