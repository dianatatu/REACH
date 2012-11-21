using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Rating;

using REACH.Client.Core;
using REACH.Client.Base;
using REACH.Client.Models;
using REACH.Client.Controllers;
using REACH.Common.Base;
using REACH.Common.Data;

namespace REACH.Client.Views
{
	public partial class MyAccountView : Form, IView
	{
		private MyAccountController controller;

		public delegate void EmptyFunction();

		private static Font UI_FONT = new Font(
					"Microsoft Sans Serif",
					9.75F,
					FontStyle.Regular,
					GraphicsUnit.Point,
					((byte)(0)));

		public MyAccountView()
		{
			// Create the controller
			controller = new MyAccountController();

			// Handlers for external events
			controller.QuizReceivedFromServer += new MyAccountController.ExternalEventHandler(OnQuizReceivedFromServer);

			// Register the controller handlers to the service
			controller.RegisterHandlers();

			// Initialize Component
			InitializeComponent();

			// Set the parent and display the window
			SetMdiParent();
			ShowForm();
			ShowUserInfo();

			// Handlers for internal events			
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(OnFormClosing);
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

		private class CertButton : Button
		{
			public DomainData domain;
		}

		public void ShowUserInfo()
		{
			LoggedInUserModel model = LoggedInUserModel.Instance;
			loggedInUser.Text = model.User.Username;
			crtRating.Text = model.User.Rank.ToString("0.000");

			// Display all the domains for which the user is certificated
			int maxHeight = 0;
			certs.Items.Clear();
			for (int i = 0; i < model.CertifiedDomains.Count; ++i)
				certs.Items.Add(model.CertifiedDomains[i].Name);
			certs.Size = new Size(235, 4 + model.CertifiedDomains.Count * 16);
			certsContainer.Size = new Size(248, certs.Height + 15);

			label2.Location = new Point(25, certsContainer.Location.Y + certsContainer.Height + 2);
			pictureBox4.Location = new Point(-2, label2.Location.Y - 8);
			uncertsContainer.Location = new Point(6, label2.Location.Y + 20);
			
			// Display all the domains for which a user can receive a certificate
			int index = 0;
			foreach (DomainData item in model.AllDomains)
			{
				bool found = false;
				for (int i = 0; i < model.CertifiedDomains.Count && !found; ++i)
					found = (model.CertifiedDomains[i].ID == item.ID);
				if (found)
					continue;
				
				// the label with the domain
				Label domainTitle = new Label();
				domainTitle.Location = new Point(7, 12 + 27 * index);
				domainTitle.Font = UI_FONT;
				domainTitle.Text = item.Name + ":";
				domainTitle.Visible = true;
				uncertsContainer.Controls.Add(domainTitle);				

				// the button for obtaining the certificate
				CertButton btn = new CertButton();
				btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(209)))), ((int)(((byte)(228)))));
				btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(150)))), ((int)(((byte)(193)))));
				btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(87)))), ((int)(((byte)(147)))));
				btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(130)))), ((int)(((byte)(182)))));
				btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
				btn.Font = UI_FONT;
				btn.ForeColor = System.Drawing.Color.Black;
				btn.Size = new System.Drawing.Size(115, 25);
				btn.Location = new System.Drawing.Point(127, 8 + index * (btn.Height + 2));
				btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
				btn.TabIndex = 100 + index;
				btn.Text = "Get a Certificate";
				btn.UseVisualStyleBackColor = false;
				btn.Click += new EventHandler(btn_Click);
				btn.domain = item;
				uncertsContainer.Controls.Add(btn);

				++index;
				maxHeight = btn.Location.Y + btn.Height;
			}

			uncertsContainer.Height = maxHeight + 10;
			this.Size = new Size(
				this.Width, 
				uncertsContainer.Location.Y + uncertsContainer.Height + 30);
		}

		/*
		 * Handlers for internal events
		 */
		#region internal_events

		private void OnFormClosing(object sender, FormClosingEventArgs e)
		{
			controller.UnregisterHandlers();
		}

		void btn_Click(object sender, EventArgs e)
		{
			CertButton btn = (CertButton)sender;
			NewAccountModel model = NewAccountModel.Instance;
			model.CertifiedDomains = new List<DomainData>();
			model.CertifiedDomains.Add(btn.domain);
			this.Enabled = false;
			controller.StartTest(btn.domain);
		}

		#endregion

		/*
		 * Handlers for external events
		 */
		#region external_events

		private void OnQuizReceivedFromServer(NewAccountModel model)
		{
			while (!this.IsHandleCreated);
			if (this.InvokeRequired)
			{
				this.Invoke((MyAccountController.ExternalEventHandler)
					OnQuizReceivedFromServer, model);
				return;
			}
			new NewAccountTestView(NewAccountTestView.TAKE_NEW_CERT, this);
		}

		#endregion
	}
}
