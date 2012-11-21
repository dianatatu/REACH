namespace REACH.Client.Views
{
    partial class ShelfView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShelfView));
			this.shelftitle = new System.Windows.Forms.Label();
			this.sort_label = new System.Windows.Forms.Label();
			this.sort_combo_box = new System.Windows.Forms.ComboBox();
			this.search_text_box = new System.Windows.Forms.TextBox();
			this.post_button = new System.Windows.Forms.Button();
			this.resource_display = new System.Windows.Forms.RichTextBox();
			this.back_to_list_button = new System.Windows.Forms.Button();
			this.search_label = new System.Windows.Forms.Label();
			this.edit_button = new System.Windows.Forms.Button();
			this.delete_button = new System.Windows.Forms.Button();
			this.post_title = new System.Windows.Forms.RichTextBox();
			this.post_description = new System.Windows.Forms.RichTextBox();
			this.post_links = new System.Windows.Forms.RichTextBox();
			this.notification_label = new System.Windows.Forms.Label();
			this.post_title_label = new System.Windows.Forms.Label();
			this.post_description_label = new System.Windows.Forms.Label();
			this.post_links_label = new System.Windows.Forms.Label();
			this.submit_button = new System.Windows.Forms.Button();
			this.post_category_label = new System.Windows.Forms.Label();
			this.post_category = new System.Windows.Forms.ComboBox();
			this.modify_button = new System.Windows.Forms.Button();
			this.back_to_resource_button = new System.Windows.Forms.Button();
			this.confirm_button = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.det_res_vote = new Rating.RatingControl();
			this.panel2 = new System.Windows.Forms.Panel();
			this.beginners_label = new System.Windows.Forms.Label();
			this.general_label = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// shelftitle
			// 
			this.shelftitle.AutoSize = true;
			this.shelftitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.shelftitle.Location = new System.Drawing.Point(12, 9);
			this.shelftitle.Name = "shelftitle";
			this.shelftitle.Size = new System.Drawing.Size(85, 20);
			this.shelftitle.TabIndex = 0;
			this.shelftitle.Text = "ShelfTitle";
			// 
			// sort_label
			// 
			this.sort_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.sort_label.AutoSize = true;
			this.sort_label.Location = new System.Drawing.Point(530, 54);
			this.sort_label.Name = "sort_label";
			this.sort_label.Size = new System.Drawing.Size(43, 13);
			this.sort_label.TabIndex = 2;
			this.sort_label.Text = "Sort by:";
			this.sort_label.Visible = false;
			// 
			// sort_combo_box
			// 
			this.sort_combo_box.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.sort_combo_box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.sort_combo_box.FormattingEnabled = true;
			this.sort_combo_box.Items.AddRange(new object[] {
            "rating",
            "date"});
			this.sort_combo_box.Location = new System.Drawing.Point(530, 72);
			this.sort_combo_box.Name = "sort_combo_box";
			this.sort_combo_box.Size = new System.Drawing.Size(121, 21);
			this.sort_combo_box.TabIndex = 3;
			this.sort_combo_box.Visible = false;
			this.sort_combo_box.SelectionChangeCommitted += new System.EventHandler(this.sort_combo_box_SelectionChangeCommitted);
			// 
			// search_text_box
			// 
			this.search_text_box.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.search_text_box.Location = new System.Drawing.Point(530, 120);
			this.search_text_box.Name = "search_text_box";
			this.search_text_box.Size = new System.Drawing.Size(124, 20);
			this.search_text_box.TabIndex = 5;
			this.search_text_box.Visible = false;
			this.search_text_box.TextChanged += new System.EventHandler(this.search_button_Click);
			// 
			// post_button
			// 
			this.post_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.post_button.Enabled = false;
			this.post_button.Location = new System.Drawing.Point(533, 422);
			this.post_button.Name = "post_button";
			this.post_button.Size = new System.Drawing.Size(120, 23);
			this.post_button.TabIndex = 7;
			this.post_button.Text = "Post resource";
			this.post_button.UseVisualStyleBackColor = true;
			this.post_button.Visible = false;
			this.post_button.Click += new System.EventHandler(this.post_button_Click);
			// 
			// resource_display
			// 
			this.resource_display.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.resource_display.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.resource_display.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.resource_display.Location = new System.Drawing.Point(11, 43);
			this.resource_display.Name = "resource_display";
			this.resource_display.ReadOnly = true;
			this.resource_display.Size = new System.Drawing.Size(644, 408);
			this.resource_display.TabIndex = 8;
			this.resource_display.Text = "";
			this.resource_display.Visible = false;
			this.resource_display.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.resource_display_LinkClicked);
			// 
			// back_to_list_button
			// 
			this.back_to_list_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.back_to_list_button.AutoSize = true;
			this.back_to_list_button.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.back_to_list_button.Location = new System.Drawing.Point(341, 9);
			this.back_to_list_button.Name = "back_to_list_button";
			this.back_to_list_button.Size = new System.Drawing.Size(100, 28);
			this.back_to_list_button.TabIndex = 9;
			this.back_to_list_button.Text = "Back to list";
			this.back_to_list_button.UseVisualStyleBackColor = true;
			this.back_to_list_button.Visible = false;
			this.back_to_list_button.Click += new System.EventHandler(this.back_to_list_button_Click);
			// 
			// search_label
			// 
			this.search_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.search_label.AutoSize = true;
			this.search_label.Location = new System.Drawing.Point(530, 104);
			this.search_label.Name = "search_label";
			this.search_label.Size = new System.Drawing.Size(41, 13);
			this.search_label.TabIndex = 10;
			this.search_label.Text = "Search";
			this.search_label.Visible = false;
			// 
			// edit_button
			// 
			this.edit_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.edit_button.Location = new System.Drawing.Point(447, 9);
			this.edit_button.Name = "edit_button";
			this.edit_button.Size = new System.Drawing.Size(100, 28);
			this.edit_button.TabIndex = 11;
			this.edit_button.Text = "Edit ";
			this.edit_button.UseVisualStyleBackColor = true;
			this.edit_button.Visible = false;
			this.edit_button.Click += new System.EventHandler(this.edit_button_Click);
			// 
			// delete_button
			// 
			this.delete_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.delete_button.ImageAlign = System.Drawing.ContentAlignment.TopRight;
			this.delete_button.Location = new System.Drawing.Point(553, 9);
			this.delete_button.Name = "delete_button";
			this.delete_button.Size = new System.Drawing.Size(100, 28);
			this.delete_button.TabIndex = 12;
			this.delete_button.Text = "Delete";
			this.delete_button.UseVisualStyleBackColor = true;
			this.delete_button.Visible = false;
			this.delete_button.Click += new System.EventHandler(this.delete_button_Click);
			// 
			// post_title
			// 
			this.post_title.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.post_title.Location = new System.Drawing.Point(11, 86);
			this.post_title.Name = "post_title";
			this.post_title.Size = new System.Drawing.Size(642, 47);
			this.post_title.TabIndex = 13;
			this.post_title.Text = "";
			this.post_title.Visible = false;
			// 
			// post_description
			// 
			this.post_description.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.post_description.Location = new System.Drawing.Point(11, 154);
			this.post_description.Name = "post_description";
			this.post_description.Size = new System.Drawing.Size(642, 140);
			this.post_description.TabIndex = 14;
			this.post_description.Text = "";
			this.post_description.Visible = false;
			// 
			// post_links
			// 
			this.post_links.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.post_links.Location = new System.Drawing.Point(11, 320);
			this.post_links.Name = "post_links";
			this.post_links.Size = new System.Drawing.Size(642, 76);
			this.post_links.TabIndex = 15;
			this.post_links.Text = "";
			this.post_links.Visible = false;
			// 
			// notification_label
			// 
			this.notification_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.notification_label.AutoSize = true;
			this.notification_label.Location = new System.Drawing.Point(13, 48);
			this.notification_label.Name = "notification_label";
			this.notification_label.Size = new System.Drawing.Size(133, 13);
			this.notification_label.TabIndex = 16;
			this.notification_label.Text = "Write your notification here";
			this.notification_label.Visible = false;
			// 
			// post_title_label
			// 
			this.post_title_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.post_title_label.AutoSize = true;
			this.post_title_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.post_title_label.Location = new System.Drawing.Point(14, 67);
			this.post_title_label.Name = "post_title_label";
			this.post_title_label.Size = new System.Drawing.Size(51, 17);
			this.post_title_label.TabIndex = 17;
			this.post_title_label.Text = "Title *";
			this.post_title_label.Visible = false;
			// 
			// post_description_label
			// 
			this.post_description_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.post_description_label.AutoSize = true;
			this.post_description_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.post_description_label.Location = new System.Drawing.Point(14, 136);
			this.post_description_label.Name = "post_description_label";
			this.post_description_label.Size = new System.Drawing.Size(101, 17);
			this.post_description_label.TabIndex = 18;
			this.post_description_label.Text = "Description *";
			this.post_description_label.Visible = false;
			// 
			// post_links_label
			// 
			this.post_links_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.post_links_label.AutoSize = true;
			this.post_links_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.post_links_label.Location = new System.Drawing.Point(14, 297);
			this.post_links_label.Name = "post_links_label";
			this.post_links_label.Size = new System.Drawing.Size(46, 17);
			this.post_links_label.TabIndex = 19;
			this.post_links_label.Text = "Links";
			this.post_links_label.Visible = false;
			// 
			// submit_button
			// 
			this.submit_button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.submit_button.Location = new System.Drawing.Point(250, 422);
			this.submit_button.Name = "submit_button";
			this.submit_button.Size = new System.Drawing.Size(161, 29);
			this.submit_button.TabIndex = 17;
			this.submit_button.Text = "Submit";
			this.submit_button.UseVisualStyleBackColor = true;
			this.submit_button.Visible = false;
			this.submit_button.Click += new System.EventHandler(this.submit_button_Click);
			// 
			// post_category_label
			// 
			this.post_category_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.post_category_label.AutoSize = true;
			this.post_category_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.post_category_label.Location = new System.Drawing.Point(14, 399);
			this.post_category_label.Name = "post_category_label";
			this.post_category_label.Size = new System.Drawing.Size(84, 17);
			this.post_category_label.TabIndex = 21;
			this.post_category_label.Text = "Category *";
			this.post_category_label.Visible = false;
			// 
			// post_category
			// 
			this.post_category.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.post_category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.post_category.FormattingEnabled = true;
			this.post_category.Items.AddRange(new object[] {
            "Beginners",
            "General"});
			this.post_category.Location = new System.Drawing.Point(98, 402);
			this.post_category.Name = "post_category";
			this.post_category.Size = new System.Drawing.Size(127, 21);
			this.post_category.TabIndex = 16;
			this.post_category.Visible = false;
			// 
			// modify_button
			// 
			this.modify_button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.modify_button.Location = new System.Drawing.Point(250, 422);
			this.modify_button.Name = "modify_button";
			this.modify_button.Size = new System.Drawing.Size(161, 29);
			this.modify_button.TabIndex = 22;
			this.modify_button.Text = "Modify";
			this.modify_button.UseVisualStyleBackColor = true;
			this.modify_button.Visible = false;
			this.modify_button.Click += new System.EventHandler(this.modify_button_Click);
			// 
			// back_to_resource_button
			// 
			this.back_to_resource_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.back_to_resource_button.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.back_to_resource_button.Location = new System.Drawing.Point(447, 9);
			this.back_to_resource_button.Name = "back_to_resource_button";
			this.back_to_resource_button.Size = new System.Drawing.Size(100, 28);
			this.back_to_resource_button.TabIndex = 23;
			this.back_to_resource_button.Text = "Back to resource";
			this.back_to_resource_button.UseMnemonic = false;
			this.back_to_resource_button.UseVisualStyleBackColor = true;
			this.back_to_resource_button.Visible = false;
			this.back_to_resource_button.Click += new System.EventHandler(this.back_to_resource_button_Click);
			// 
			// confirm_button
			// 
			this.confirm_button.Location = new System.Drawing.Point(11, 67);
			this.confirm_button.Name = "confirm_button";
			this.confirm_button.Size = new System.Drawing.Size(81, 28);
			this.confirm_button.TabIndex = 24;
			this.confirm_button.Text = "OK";
			this.confirm_button.UseVisualStyleBackColor = true;
			this.confirm_button.Visible = false;
			this.confirm_button.Click += new System.EventHandler(this.confirm_button_Click);
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BackColor = System.Drawing.SystemColors.HighlightText;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Location = new System.Drawing.Point(17, 69);
			this.panel1.Margin = new System.Windows.Forms.Padding(2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(508, 139);
			this.panel1.TabIndex = 26;
			this.panel1.Visible = false;
			// 
			// det_res_vote
			// 
			this.det_res_vote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.det_res_vote.BackColor = System.Drawing.Color.Transparent;
			this.det_res_vote.Fixed = false;
			this.det_res_vote.Location = new System.Drawing.Point(219, 8);
			this.det_res_vote.Margin = new System.Windows.Forms.Padding(2);
			this.det_res_vote.Name = "det_res_vote";
			this.det_res_vote.Rating = 0;
			this.det_res_vote.Size = new System.Drawing.Size(117, 29);
			this.det_res_vote.TabIndex = 27;
			this.det_res_vote.Visible = false;
			this.det_res_vote.SelectRating += new Rating.RatingControl.SelectRatingHandler(this.det_res_vote_SelectRating);
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BackColor = System.Drawing.SystemColors.HighlightText;
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Location = new System.Drawing.Point(17, 229);
			this.panel2.Margin = new System.Windows.Forms.Padding(2);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(508, 216);
			this.panel2.TabIndex = 27;
			this.panel2.Visible = false;
			// 
			// beginners_label
			// 
			this.beginners_label.AutoSize = true;
			this.beginners_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.beginners_label.Location = new System.Drawing.Point(16, 50);
			this.beginners_label.Name = "beginners_label";
			this.beginners_label.Size = new System.Drawing.Size(81, 17);
			this.beginners_label.TabIndex = 28;
			this.beginners_label.Text = "Beginners";
			// 
			// general_label
			// 
			this.general_label.AutoSize = true;
			this.general_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.general_label.Location = new System.Drawing.Point(16, 210);
			this.general_label.Name = "general_label";
			this.general_label.Size = new System.Drawing.Size(66, 17);
			this.general_label.TabIndex = 29;
			this.general_label.Text = "General";
			// 
			// ShelfView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(667, 463);
			this.Controls.Add(this.det_res_vote);
			this.Controls.Add(this.shelftitle);
			this.Controls.Add(this.post_description);
			this.Controls.Add(this.post_links);
			this.Controls.Add(this.modify_button);
			this.Controls.Add(this.submit_button);
			this.Controls.Add(this.post_category);
			this.Controls.Add(this.post_category_label);
			this.Controls.Add(this.post_links_label);
			this.Controls.Add(this.post_description_label);
			this.Controls.Add(this.post_title_label);
			this.Controls.Add(this.confirm_button);
			this.Controls.Add(this.notification_label);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.beginners_label);
			this.Controls.Add(this.sort_combo_box);
			this.Controls.Add(this.sort_label);
			this.Controls.Add(this.search_label);
			this.Controls.Add(this.search_text_box);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.post_button);
			this.Controls.Add(this.general_label);
			this.Controls.Add(this.back_to_list_button);
			this.Controls.Add(this.back_to_resource_button);
			this.Controls.Add(this.edit_button);
			this.Controls.Add(this.delete_button);
			this.Controls.Add(this.resource_display);
			this.Controls.Add(this.post_title);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Location = new System.Drawing.Point(800, 0);
			this.MaximizeBox = false;
			this.Name = "ShelfView";
			this.Text = "DomainName";
			this.Load += new System.EventHandler(this.ShelfView_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label shelftitle;
        private System.Windows.Forms.Label sort_label;
        private System.Windows.Forms.ComboBox sort_combo_box;
        private System.Windows.Forms.TextBox search_text_box;
        private System.Windows.Forms.Button post_button;
        private System.Windows.Forms.RichTextBox resource_display;
        private System.Windows.Forms.Button back_to_list_button;
        private System.Windows.Forms.Label search_label;
        private System.Windows.Forms.Button edit_button;
        private System.Windows.Forms.Button delete_button;
        private System.Windows.Forms.RichTextBox post_title;
        private System.Windows.Forms.RichTextBox post_description;
        private System.Windows.Forms.RichTextBox post_links;
        private System.Windows.Forms.Label notification_label;
        private System.Windows.Forms.Label post_title_label;
        private System.Windows.Forms.Label post_description_label;
        private System.Windows.Forms.Label post_links_label;
        private System.Windows.Forms.Button submit_button;
        private System.Windows.Forms.Label post_category_label;
        private System.Windows.Forms.ComboBox post_category;
        private System.Windows.Forms.Button modify_button;
        private System.Windows.Forms.Button back_to_resource_button;
        private System.Windows.Forms.Button confirm_button;
        private System.Windows.Forms.Panel panel1;
        private Rating.RatingControl det_res_vote;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label beginners_label;
        private System.Windows.Forms.Label general_label;


    }
}