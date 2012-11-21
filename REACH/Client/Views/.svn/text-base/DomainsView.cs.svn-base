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
	public partial class DomainsView : Panel, IView
	{
		public PictureBox shelfImg;
		public Label info;
		public Button showAllDomains;
		public Panel domainList;
		private bool domainsRequested = false;
		public DomainsController controller;

		private static Color SELECT_COLOR =
			Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
		public delegate void EmptyFunction();

		public DomainsView()
		{
			// Create the controller
			controller = new DomainsController();

			// Handlers for external events
			controller.DomainsReceived += new DomainsController.ExternalEventHandler(OnDomainsReceived);

			// Register the controller handlers to the service
			controller.RegisterHandlers();

			// Initialize Component
			InitializeComponent();

			// Handlers for internal events
			showAllDomains.Click += new System.EventHandler(showAllDomains_Click);
            
		}

		public void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DomainsView));
			this.info = new System.Windows.Forms.Label();
			this.showAllDomains = new System.Windows.Forms.Button();
			this.domainList = new System.Windows.Forms.Panel();
			this.shelfImg = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.shelfImg)).BeginInit();
			this.SuspendLayout();
			// 
			// info
			// 
			this.info.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.info.Location = new System.Drawing.Point(43, 4);
			this.info.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.info.Name = "info";
			this.info.Size = new System.Drawing.Size(150, 42);
			this.info.TabIndex = 3;
			this.info.Text = "You can access shelf resources by selecting the shelf for a particular domain.";
			// 
			// showAllDomains
			// 
			this.showAllDomains.AutoSize = true;
			this.showAllDomains.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(209)))), ((int)(((byte)(228)))));
			this.showAllDomains.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(150)))), ((int)(((byte)(193)))));
			this.showAllDomains.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(87)))), ((int)(((byte)(147)))));
			this.showAllDomains.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(130)))), ((int)(((byte)(182)))));
			this.showAllDomains.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.showAllDomains.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.showAllDomains.ForeColor = System.Drawing.Color.Black;
			this.showAllDomains.Location = new System.Drawing.Point(197, 13);
			this.showAllDomains.Margin = new System.Windows.Forms.Padding(2);
			this.showAllDomains.Name = "showAllDomains";
			this.showAllDomains.Size = new System.Drawing.Size(97, 25);
			this.showAllDomains.TabIndex = 2;
			this.showAllDomains.Text = "Display Domains";
			this.showAllDomains.UseVisualStyleBackColor = false;
			// 
			// domainList
			// 
			this.domainList.BackColor = System.Drawing.Color.White;
			this.domainList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.domainList.Margin = new System.Windows.Forms.Padding(2);
			this.domainList.Name = "domainList";
			this.domainList.Size = new System.Drawing.Size(136, 43);
			this.domainList.TabIndex = 14;
			this.domainList.Visible = false;
			// 
			// shelfImg
			// 
			this.shelfImg.ErrorImage = null;
			this.shelfImg.Image = ((System.Drawing.Image)(resources.GetObject("shelfImg.Image")));
			this.shelfImg.Location = new System.Drawing.Point(2, 5);
			this.shelfImg.Margin = new System.Windows.Forms.Padding(2);
			this.shelfImg.Name = "shelfImg";
			this.shelfImg.Size = new System.Drawing.Size(38, 38);
			this.shelfImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.shelfImg.TabIndex = 0;
			this.shelfImg.TabStop = false;
			// 
			// DomainsView
			// 
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.info);
			this.Controls.Add(this.showAllDomains);
			this.Controls.Add(this.shelfImg);
			this.Size = new System.Drawing.Size(302, 50);
			((System.ComponentModel.ISupportInitialize)(this.shelfImg)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		private void changeState()
		{
			domainList.Visible = !domainList.Visible;
			if (domainList.Visible)
				showAllDomains.Text = "Hide Domains";
			else
				showAllDomains.Text = "Display Domains";
		}

		private class TransparentPanel : Panel
		{
			private const int WS_EX_TRANSPARENT = 0x00000020;

			protected override CreateParams CreateParams
			{
				get
				{
					CreateParams createParams = base.CreateParams;
					createParams.ExStyle |= WS_EX_TRANSPARENT;
					return createParams;
				}
			}

			protected override void OnPaintBackground(PaintEventArgs e)
			{ }
		}

		/*
		 * Handlers for internal events
		 */
		#region internal_events

		private void showAllDomains_Click(object sender, EventArgs e)
		{
			domainsRequested = true;
			controller.GetAllDomains();
		}

		void cover_Click(object sender, EventArgs e)
		{
			changeState();
			TransparentPanel s = (TransparentPanel)sender;
			foreach (Component item in s.Parent.Controls)
				if (item is Label)
				{
					new ShelfView(((Label)item).Text);
					break;
				}
		}

		void cover_MouseLeave(object sender, EventArgs e)
		{
			TransparentPanel s = (TransparentPanel)sender;
			s.Parent.BackColor = Color.White;
		}

		void cover_MouseEnter(object sender, EventArgs e)
		{
			TransparentPanel s = (TransparentPanel)sender;
			s.Parent.BackColor = SELECT_COLOR;
		}

		#endregion

		/*
		 * Handlers for external events
		 */
		#region external_events

		private void OnDomainsReceived(DomainListModel model)
		{
			if (!domainsRequested)
				return;

			while (!this.IsHandleCreated);
			if (this.InvokeRequired)
			{
				this.Invoke((DomainsController.ExternalEventHandler)
					OnDomainsReceived, model);
				return;
			}

			domainsRequested = false;
			domainList.Location = new Point(429, 67);
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DomainsView));

			List<DomainData> domains = model.AllDomains;
			domainList.Size = new Size(136, 2 + (22 - 1) * domains.Count);
			for (int i = 0; i < domains.Count; ++i)
			{
				// main container for domain
				Panel container = new Panel();
				container.Location = new Point(-1, -1 + 21 * i);
				container.Size = new Size(136, 22);
				container.BorderStyle = BorderStyle.FixedSingle;
				container.Visible = true;
				domainList.Controls.Add(container);

				// cover
				TransparentPanel cover = new TransparentPanel();
				cover.Location = new Point(0, 0);
				cover.Size = container.Size;
				cover.MouseEnter += new EventHandler(cover_MouseEnter);
				cover.MouseLeave += new EventHandler(cover_MouseLeave);
				cover.Click += new EventHandler(cover_Click);
				container.Controls.Add(cover);

				// image box
				PictureBox img = new PictureBox();
				img.Image = ((Image)(resources.GetObject("news.Image")));
				img.Location = new Point(2, 1);
				img.Margin = new System.Windows.Forms.Padding(2);
				img.Size = new Size(18, 20);
				img.SizeMode = PictureBoxSizeMode.StretchImage;
				img.TabIndex = 7;
				img.TabStop = false;
				container.Controls.Add(img);

				// domain title
				Label title = new Label();
				title.AutoSize = true;
				title.Font = new Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				title.Location = new Point(24, 2);
				title.Margin = new Padding(2, 0, 2, 0);
				title.Size = new Size(74, 17);
				title.TabIndex = 6;
				title.Text = domains[i].Name;
				container.Controls.Add(title);
			}

			changeState();
		}

		#endregion
	}
}
