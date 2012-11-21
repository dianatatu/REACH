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
using Rating;

namespace REACH.Client.Views
{
    public partial class ShelfView : Form, IView
    {
        private const int lineHeight = 15;
        private Dictionary<Label, ResourceData> resourceLabels = new Dictionary<Label, ResourceData>();
        private Dictionary<RatingControl, ResourceData> resourceVoteWidgets = new Dictionary<RatingControl, ResourceData>();

        private ShelfController controller;

        public delegate void EmptyFunction();

        #region initializers

        private void ShelfViewInit()
        {
            // Handlers for external events
            controller.ShelfResourceList += new ShelfController.ExternalEventHandler(OnShelfResourceList);
            controller.SearchListUpdated += new ShelfController.ExternalEventHandler(OnSearchListUpdated);
            controller.UserDomainValidationChecked += new ShelfController.ExternalEventHandler(OnUserDomainValidationChecked);
            controller.DisplayModeChanged += new ShelfController.ExternalEventHandler(OnDisplayModeChanged);
            controller.ResourcePosted += new ShelfController.ExternalEventHandler(OnResourcePosted);
            controller.ResourceEdited += new ShelfController.ExternalEventHandler(OnResourceEdited);
            controller.ResourceDeleted += new ShelfController.ExternalEventHandler(OnResourceDeleted);
            controller.ResourceVoteChecked += new ShelfController.ExternalEventHandler(OnResourceVoteChecked);

            // Register the controller handlers to the service
            controller.RegisterHandlers();

            // Initialize Component
            InitializeComponent();

            // Set the parent and display the window
            SetMdiParent();
            ShowForm();

        }

        public ShelfView(String domain)
        {

            // Create the controller
            controller = new ShelfController(domain);

            ShelfViewInit();

            // set Window parameters
            this.Text = domain + " Shelf";
            this.shelftitle.Text = domain;
            this.sort_combo_box.SelectedItem = "rating";
            ActivateListMode();

            // Handlers for internal events			
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(OnFormClosing);
        }

        public ShelfView(String domain_name, ResourceData resource)
        {

            // Create the controller
            controller = new ShelfController(domain_name, resource);

            ShelfViewInit();

            // set Window parameters
            this.Text = domain_name + " Shelf";
            this.shelftitle.Text = domain_name;
            this.sort_combo_box.SelectedItem = "rating";
            ActivateListMode();

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

        #endregion

        /*
         * Handlers for internal events
         */
        #region internal_events

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            controller.UnregisterHandlers();
        }

        private void ShelfView_Load(object sender, EventArgs e)
        {
            controller.PopulateDomainListByName();
        }

        private void ColorResourceLabel(object sender, EventArgs e)
        {
            ((Label)sender).BackColor = Color.DarkGray;
        }

        private void UncolorResourceLabel(object sender, EventArgs e)
        {
            ((Label)sender).BackColor = Color.White;
        }

        private void OnResourceClick(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            ResourceData resource = resourceLabels[label];
            controller.ChangeToDetailedMode(resource);
        }

        private void search_button_Click(object sender, EventArgs e)
        {
            controller.SearchResourceList(search_text_box.Text);
        }

        private void sort_combo_box_SelectionChangeCommitted(object sender, EventArgs e)
        {
            controller.SortCriteriaUpdated();
        }

        private void ResourceList_DoubleClick(object sender, EventArgs e)
        {
            ResourceData resource = (ResourceData)((ListBox)sender).SelectedItem;
            if (resource != null)
                controller.ChangeToDetailedMode(resource);
        }

        private void back_to_list_button_Click(object sender, EventArgs e)
        {
            controller.ChangeToListMode();
        }

        private void post_button_Click(object sender, EventArgs e)
        {
            controller.ChangeToPostMode();
        }

        private void submit_button_Click(object sender, EventArgs e)
        {
            Boolean check = true;
            // check if all required fields were filled
            if (post_category.SelectedItem == null)
                check = false;
            if (post_title.Text.Trim().Equals(""))
                check = false;
            if (post_description.Text.Trim().Equals(""))
                check = false;

            if (check == false)
            {
                notification_label.ForeColor = Color.Red;
                notification_label.Text = "Please fill all fields marked with (*) before submitting";
            }
            else
            {
                // build ResourceData object
                Int32 cat;
                // here we can put other categories too
                if (post_category.SelectedItem.Equals("Beginners"))
                    cat = 0;
                else
                    cat = 1;

                controller.AddResource(post_title.Text.Trim(), post_description.Text.Trim(), post_links.Text.Trim(), cat);

                notification_label.ForeColor = Color.Black;
                notification_label.Text = "Request sent";

            }

        }

        private void edit_button_Click(object sender, EventArgs e)
        {
            controller.ChangeToEditMode();
        }

        private void back_to_resource_button_Click(object sender, EventArgs e)
        {
            controller.ChangeToDetailedMode();
        }

        private void modify_button_Click(object sender, EventArgs e)
        {
            Boolean check = true;
            // check if all required fields were filled
            if (post_description.Text.Trim().Equals(""))
                check = false;

            if (check == false)
            {
                notification_label.ForeColor = Color.Red;
                notification_label.Text = "Please fill all fields marked with (*) before submitting";
            }
            else
            {
                controller.EditResource(post_description.Text.Trim(), post_links.Text.Trim());

                notification_label.ForeColor = Color.Black;
                notification_label.Text = "Edit request sent";

            }
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            DeactivateEditMode();
            DeactivateDetailedMode();

            back_to_list_button.Visible = true;
            back_to_resource_button.Visible = true;
            notification_label.Visible = true;
            confirm_button.Visible = true;
            notification_label.ForeColor = Color.Red;
            notification_label.Text = "Are you sure you want to delete the resource ?";
        }

        private void confirm_button_Click(object sender, EventArgs e)
        {
            notification_label.Text = "Delete request sent";
            controller.DeleteResource();
        }

        private void ResourceList_MouseDown(object sender, MouseEventArgs e)
        {
            int sel = ((ListBox)sender).IndexFromPoint(e.Location);
            if (sel == ListBox.NoMatches)
                ((ListBox)sender).SelectedIndex = -1;
        }

        private void det_res_vote_SelectRating(object sender, int rating)
        {
            controller.VoteResource(det_res_vote.Rating);
        }

        private void onVoteWidgetClick(object sender, int rating)
        {
            RatingControl voteWidget = (RatingControl)sender;
            controller.VoteResource(resourceVoteWidgets[voteWidget], rating);
        }

        private void resource_display_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);

        }

        #endregion

        /*
		 * Handlers for external events
		 */
        #region external_events

        private void OnShelfResourceList(ShelfModel model)
        {
            while (!this.IsHandleCreated) ;
            if (this.InvokeRequired)
            {
                this.Invoke((ShelfController.ExternalEventHandler)
                    OnShelfResourceList, model);
                return;
            }

            ShowResources(model);
        }

        private void ShowResources(ShelfModel model)
        {
            List<ResourceData> resList = new List<ResourceData>();
            resList.AddRange(model.Resources);
            resList = sortListItems(resList);

            resourceLabels.Clear();
            resourceVoteWidgets.Clear();

            panel1.Controls.Clear();
            panel1.SuspendLayout();

            panel2.Controls.Clear();
            panel2.SuspendLayout();

            int index1 = 0;
            int index2 = 0;
            foreach (ResourceData res in resList)
            {
                RatingControl voteWidget = new RatingControl();
                if(res.Category == 0)
                    voteWidget.Location = new Point(0, 2 * (index1) * lineHeight);
                else
                    voteWidget.Location = new Point(0, 2 * (index2) * lineHeight);
                voteWidget.AutoSize = false;
                voteWidget.Scale(new SizeF((float)0.45, (float)0.5));
                voteWidget.Fixed = false;
                voteWidget.SelectRating += new Rating.RatingControl.SelectRatingHandler(this.onVoteWidgetClick);
                if (model.My_Votes.ContainsKey(res.Id))
                    voteWidget.Rating = model.My_Votes[res.Id];
                else
                    controller.CheckResourceVote(res);
                resourceVoteWidgets.Add(voteWidget, res);
                if (res.Category == 0)
                    panel1.Controls.Add(voteWidget);
                else
                    panel2.Controls.Add(voteWidget);
                Label resourceLabel = new Label();
                resourceLabel.Font = new Font("Courier New", 8, FontStyle.Bold);
                resourceLabel.Text = res.ToString();
                if (res.Category == 0)
                    resourceLabel.Location = new Point(70, (index1++) * lineHeight);
                else
                    resourceLabel.Location = new Point(70, (index2++) * lineHeight);
                resourceLabel.AutoSize = false;
                resourceLabel.Size = new Size(panel1.Width - 72, lineHeight);
                resourceLabel.Click += new System.EventHandler(this.OnResourceClick);
                resourceLabel.MouseEnter += new System.EventHandler(this.ColorResourceLabel);
                resourceLabel.MouseLeave += new System.EventHandler(this.UncolorResourceLabel);
                resourceLabels.Add(resourceLabel, res);
                if (res.Category == 0)
                    panel1.Controls.Add(resourceLabel);
                else
                    panel2.Controls.Add(resourceLabel);
            }

            panel1.ResumeLayout();
            panel2.ResumeLayout();
        }

        private void OnUserDomainValidationChecked(ShelfModel model)
        {
            while (!this.IsHandleCreated) ;
            if (this.InvokeRequired)
            {
                this.Invoke((ShelfController.ExternalEventHandler)
                    OnUserDomainValidationChecked, model);
                return;
            }

            Boolean found = false;

            foreach (DomainData dom in model.User_Domains)
            {
                if (model.Domain.ID == dom.ID)
                {
                    found = true;
                    break;
                }
            }

            if (found == false)
            {
                // deactivate post
                post_button.Enabled = false;
            }
            else
            {
                // activate post
                post_button.Enabled = true;
            }

        }

        private void OnSearchListUpdated(ShelfModel model)
        {
            while (!this.IsHandleCreated) ;
            if (this.InvokeRequired)
            {
                this.Invoke((ShelfController.ExternalEventHandler)
                    OnSearchListUpdated, model);
                return;
            }

            ShowResources(model);
        }

        private void OnDisplayModeChanged(ShelfModel model)
		{
			while (!this.IsHandleCreated);
			if (this.InvokeRequired)
			{
				this.Invoke((ShelfController.ExternalEventHandler)
					OnDisplayModeChanged, model);
				return;
			}

            switch (model.Display)
            {
                case 'l':
                    DeactivateDetailedMode();
                    DeactivateEditMode();
                    DeactivatePostMode();
                    ActivateListMode();
                    break;
                case 'd':
                    DeactivateListMode();
                    DeactivateEditMode();
                    DeactivatePostMode();
                    ActivateDetailedMode(model.Resource, model.Resource_Owner);
                    break;
                case 'p':
                    DeactivateListMode();
                    DeactivateDetailedMode();
                    DeactivateEditMode();
                    ActivatePostMode();
                    break;
                case 'e':
                    DeactivateListMode();
                    DeactivateDetailedMode();
                    DeactivatePostMode();
                    ActivateEditMode();

                    post_title.Text = model.Resource.Title;
                    post_description.Text = model.Resource.Description;
                    post_links.Text = model.Resource.Links;

                    break;
            }

		}

        private void OnResourcePosted(ShelfModel model)
        {
            while (!this.IsHandleCreated) ;
            if (this.InvokeRequired)
            {
                this.Invoke((ShelfController.ExternalEventHandler)
                    OnResourcePosted, model);
                return;
            }

            if (model.Display == 'p' &&
                notification_label.Text.Equals("Request sent"))
            {
                DeactivatePostMode();
                back_to_list_button.Visible = true;
                notification_label.Visible = true;
                notification_label.Text = "Resource sucessfully posted";
            }

        }

        
        private void OnResourceVoteChecked(ShelfModel model)
		{
			while (!this.IsHandleCreated);
			if (this.InvokeRequired)
			{
				this.Invoke((ShelfController.ExternalEventHandler)
					OnResourceVoteChecked, model);
				return;
			}

            if (model.Display == 'd')
            {
                if (model.My_Votes.ContainsKey(model.Resource.Id))
                    det_res_vote.Rating = model.My_Votes[model.Resource.Id];
            }
            
            foreach (RatingControl key in resourceVoteWidgets.Keys)
            {
                ResourceData res = resourceVoteWidgets[key];
                if (model.My_Votes.ContainsKey(res.Id))
                    key.Rating = model.My_Votes[res.Id];
            }
            

		}

        private void OnResourceEdited(ShelfModel model)
        {
            while (!this.IsHandleCreated) ;
            if (this.InvokeRequired)
            {
                this.Invoke((ShelfController.ExternalEventHandler)
                    OnResourceEdited, model);
                return;
            }

            if (model.Display == 'e')
            {
                if (notification_label.Text.Equals("Edit request sent"))
                {
                    DeactivateEditMode();
                    back_to_list_button.Visible = true;
                    back_to_resource_button.Visible = true;
                    notification_label.Visible = true;
                    notification_label.Text = "Resource successfully edited";
                }
            }
            else
            {
                OnDisplayModeChanged(model);
            }

        }

        private void OnResourceDeleted(ShelfModel model)
        {
            while (!this.IsHandleCreated) ;
            if (this.InvokeRequired)
            {
                this.Invoke((ShelfController.ExternalEventHandler)
                    OnResourceDeleted, model);
                return;
            }

            String textBoxText = resource_display.Text;

            if (model.Display == 'd')
            {
                if (textBoxText.ToLower().Contains(model.Resource.Title.ToLower()))
                {
                    controller.ChangeToListMode();
                }
            }
            else if (model.Display == 'e')
            {
                if (post_title.Text.ToLower().Equals(model.Resource.Title.ToLower()))
                {
                    controller.ChangeToListMode();
                }
            }

        }

        #endregion

        #region display_mode_functions

        private void ActivateListMode()
        {
            // set speific mode objects to visible
            panel1.Visible = true;
            panel2.Visible = true;
            beginners_label.Visible = true;
            general_label.Visible = true;
            sort_label.Visible = true;
            sort_combo_box.Visible = true;
            search_label.Visible = true;
            search_text_box.Visible = true;
            post_button.Visible = true;

        }

        private void DeactivateListMode()
        {
            // set speific mode objects to not visible
            panel1.Visible = false;
            panel2.Visible = false;
            beginners_label.Visible = false;
            general_label.Visible = false;
            sort_label.Visible = false;
            sort_combo_box.Visible = false;
            search_label.Visible = false;
            search_text_box.Visible = false;
            post_button.Visible = false;
            confirm_button.Visible = false;
        }

        private void ActivateDetailedMode(ResourceData resource, UserData user)
        {
            
            // set speific mode objects to visible
            resource_display.Visible = true;
            back_to_list_button.Visible = true;
            delete_button.Visible = true;
            edit_button.Visible = true;
            det_res_vote.Visible = true;
            
            // fill resource_display with text
            int position = 0;
            String current_string;

            resource_display.Text = "";

            current_string = resource.Title + "\n\n";
            resource_display.Select(position, 0);
            resource_display.SelectionFont = new Font(resource_display.Font.Name, 12, FontStyle.Bold);
            resource_display.SelectedText = current_string;
            position += current_string.Length;

            current_string = resource.Description + Environment.NewLine + Environment.NewLine;
            resource_display.Select(position, 0);
            resource_display.SelectionFont = new Font(resource_display.Font.Name, 10);
            resource_display.SelectedText = current_string;
            position += current_string.Length;

            current_string = "Links\n" + resource.Links + Environment.NewLine + Environment.NewLine;
            resource_display.Select(position, 0);
            resource_display.SelectionFont = new Font(resource_display.Font.Name, 10);
            resource_display.SelectedText = current_string;
            position += current_string.Length;

            current_string = "Posted by " + user.Username + Environment.NewLine;
            current_string += resource.Timestamp + "\n";
            current_string += "Rank: " + String.Format("{0,10:0.0}",resource.Rank);
            resource_display.Select(position, 0);
            resource_display.SelectionFont = new Font(resource_display.Font.Name, 8, FontStyle.Italic);
            resource_display.SelectedText = current_string;
            position += current_string.Length;

            // display edit and delete buttons according to user permissions
            if (resource.Owner == LoggedInUserModel.Instance.User.Id)
            {
                edit_button.Enabled = true;
                delete_button.Enabled = true;
            }
            else
            {
                edit_button.Enabled = false;
                delete_button.Enabled = false;
            }

            // enable vote widget with the value of the present vote
            det_res_vote.Rating = 0;
            controller.CheckResourceVote(resource);
        }

        private void DeactivateDetailedMode()
        {
            // set speific mode objects to not visible
            resource_display.Visible = false;
            back_to_list_button.Visible = false;
            edit_button.Visible = false;
            delete_button.Visible = false;
            confirm_button.Visible = false;
            det_res_vote.Visible = false;
            det_res_vote.Fixed = false;
        }

        private void ActivatePostMode()
        {
            // set speific mode objects to visible
            back_to_list_button.Visible = true;
            notification_label.Visible = true;
            post_title_label.Visible = true;
            post_title.Visible = true;
            post_description_label.Visible = true;
            post_description.Visible = true;
            post_links.Visible = true;
            post_links_label.Visible = true;
            post_category_label.Visible = true;
            post_category.Visible = true;
            submit_button.Visible = true;

            // some specific components initialization
            notification_label.ForeColor = Color.Black;
            notification_label.Text = "All fields marked with (*) must be filled";
            post_title_label.Text = "Title *";
            post_title.Text = "";
            post_title.ReadOnly = false;
            post_title.BackColor = Color.White;
            post_description_label.Text = "Description *";
            post_description.Text = "";
            post_links.Text = "";
            post_category.SelectedItem = null;

        }

        private void DeactivatePostMode()
        {
            // set speific mode objects to not visible
            back_to_list_button.Visible = false;
            notification_label.Visible = false;
            post_title_label.Visible = false;
            post_title.Visible = false;
            post_description_label.Visible = false;
            post_description.Visible = false;
            post_links.Visible = false;
            post_links_label.Visible = false;
            post_category_label.Visible = false;
            post_category.Visible = false;
            submit_button.Visible = false;
            confirm_button.Visible = false;

        }

        private void ActivateEditMode()
        {
            // set speific mode objects to visible
            back_to_list_button.Visible = true;
            notification_label.Visible = true;
            post_title_label.Visible = true;
            post_title.Visible = true;
            post_description_label.Visible = true;
            post_description.Visible = true;
            post_links.Visible = true;
            post_links_label.Visible = true;
            modify_button.Visible = true;
            delete_button.Visible = true;
            back_to_resource_button.Visible = true;

            // some specific components initialization
            notification_label.ForeColor = Color.Black;
            notification_label.Text = "All fields marked with (*) must be filled";
            post_title_label.Text = "Title";
            post_title.ReadOnly = true;
            post_title.BackColor = Color.LightGray;
            post_description_label.Text = "Description *";
            post_description.Text = "";
            post_links.Text = "";
            post_category.SelectedItem = null;

        }

        private void DeactivateEditMode()
        {
            // set speific mode objects to not visible
            back_to_list_button.Visible = false;
            notification_label.Visible = false;
            post_title_label.Visible = false;
            post_title.Visible = false;
            post_description_label.Visible = false;
            post_description.Visible = false;
            post_links.Visible = false;
            post_links_label.Visible = false;
            modify_button.Visible = false;
            delete_button.Visible = false;
            back_to_resource_button.Visible = false;
            confirm_button.Visible = false;
        }

        #endregion  

        #region sorting_list_methods

        public class DateComparison : Comparer<ResourceData>
        {
            public override int Compare(ResourceData x, ResourceData y)
            {
                if (x.Category != y.Category)
                    return x.Category - y.Category;
                if (x.Timestamp < y.Timestamp)
                    return 1;
                else if (x.Timestamp > y.Timestamp)
                    return -1;
                else return (int)x.Id - (int)y.Id;
            }
        }

        public class RankComparison : Comparer<ResourceData>
        {
            public override int Compare(ResourceData x, ResourceData y)
            {
                if (x.Category != y.Category)
                    return x.Category - y.Category;
                if (x.Rank < y.Rank)
                    return 1;
                else if (x.Rank > y.Rank)
                    return -1;
                else return (int)x.Id - (int)y.Id;
            }
        }

        private List<ResourceData> sortListItems(List<ResourceData> initialList)
        {
            String criteria = (String)(((ComboBox)sort_combo_box).SelectedItem);
            List<ResourceData> resourceList = new List<ResourceData>();

            resourceList.AddRange(initialList);

            if (criteria != null)
            {
                if (criteria.Equals("date"))
                    resourceList.Sort((IComparer<ResourceData>)(new DateComparison()));
                else if (criteria.Equals("rating"))
                    resourceList.Sort((IComparer<ResourceData>)(new RankComparison()));
                else { shelftitle.Text = "Criteria not found"; }
            }

            return resourceList;
        }

        #endregion

        

    }
}
