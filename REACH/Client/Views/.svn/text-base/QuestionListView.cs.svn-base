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
    public partial class QuestionListView : Form, IView
    {
        private QuestionListController controller;

        public delegate void EmptyFunction();

        public QuestionListView()
        {
            // Create the controller
            controller = new QuestionListController();

            // Handlers for external events
            controller.QuestionsDomainsUpdated += new QuestionListController.ExternalEventHandler(OnQuestionsDomainsUpdated);

            // Register the controller handlers to the service
            controller.RegisterHandlers();

            // Initialize Component
            InitializeComponent();

            // Set the parent and display the window
            SetMdiParent();
            ShowForm();

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

        /*
         * Handlers for internal events
         */
        #region internal_events

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            controller.UnregisterHandlers();
        }

        private void QuestionListView_Load(object sender, EventArgs e)
        {
            controller.ListQuestions();
            controller.ListDomains();
        }

        private void QuestionListResetButton_Click(object sender, EventArgs e)
        {
            controller.QuestionListReset();
            questionSearchTextBox.Text = "Search...";
        }

        private void DomainListResetButton_Click(object sender, EventArgs e)
        {
            controller.DomainListReset();
            domainSearchTextBox.Text = "Search...";
        }

        private void QuestionSearchButton_Click(object sender, EventArgs e)
        {
            controller.QuestionSearch(questionSearchTextBox.Text);
            questionSearchTextBox.Text = "Search...";
        }

        private void questionSearchTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void DomainSearchButton_Click(object sender, EventArgs e)
        {
            controller.DomainSearch(domainSearchTextBox.Text);
            domainSearchTextBox.Text = "Search...";
        }

        private void domainSearchTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void domainsListBox_DoubleClick(object sender, EventArgs e)
        {
            if (controller.GetState() == QuestionListModel.QUESTIONLIST)
            {
                new QuestionView(domainsListBox.SelectedItem);
            }
            else
                controller.GetDomain(domainsListBox.SelectedItem.ToString());
        }

        private void questionsListBox_DoubleClick(object sender, EventArgs e)
        {
            new QuestionView(myQuestionsListBox.SelectedItem);
        }

        private void AddQuestionButton_Click(object sender, EventArgs e)
        {
            new QuestionAddView();
        }

        private void questionSearchTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                controller.QuestionSearch(questionSearchTextBox.Text);
                questionSearchTextBox.ForeColor = Color.DarkGray;
                questionSearchTextBox.Text = "Search...";
				QuestionListResetButton.Focus();
            }
        }

        private void domainSearchTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                controller.DomainSearch(domainSearchTextBox.Text);
                domainSearchTextBox.ForeColor = Color.DarkGray;
                domainSearchTextBox.Text = "Search...";
				DomainListResetButton.Focus();
            }
        }

        #endregion

        /*
		 * Handlers for external events
		 */
        #region external_events

        private void OnQuestionsDomainsUpdated(QuestionListModel model)
		{
			while (!this.IsHandleCreated);
			if (this.InvokeRequired)
			{
				this.Invoke((QuestionListController.ExternalEventHandler)
					OnQuestionsDomainsUpdated, model);
				return;
			}

            //myQuestionsListBox.DataSource = model.Current_my_questions;
            List<QuestionData> truncate = new List<QuestionData>();
            truncate = model.Current_my_questions;
            for (int i = 0; i < truncate.Count; i++)
            {
                if (truncate[i].Title.Length > QuestionData.TitleTruncate)
                    truncate[i].Title = truncate[i].Title.Substring(0, QuestionData.TitleTruncate)+"...";
            }
            myQuestionsListBox.DataSource = truncate;
            for (int i = 0; i < myQuestionsListBox.Items.Count; i++)
                myQuestionsListBox.SetSelected(i, false);
            myQuestionsListBox.Refresh();

            if (model.State == QuestionListModel.QUESTIONLIST)
            {
                truncate = model.Current_all_questions;
                for (int i = 0; i < truncate.Count; i++)
                {
                    if (truncate[i].Title.Length > QuestionData.TitleTruncate)
                        truncate[i].Title = truncate[i].Title.Substring(0, QuestionData.TitleTruncate)+"...";
                }
                domainsListBox.DataSource = truncate;
            }
            else
                domainsListBox.DataSource = model.Domains;
            for (int i = 0; i < domainsListBox.Items.Count; i++)
                domainsListBox.SetSelected(i, false);
            domainsListBox.Refresh();
		}

        #endregion

        private void domainsListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            bool flag = false;
            if ((e.State & DrawItemState.Selected)!=0)
                flag = true;

            Rectangle rect = new Rectangle(e.Bounds.X,e.Bounds.Y,e.Bounds.Width,e.Bounds.Height-1);
            e = new DrawItemEventArgs(e.Graphics, e.Font, rect, e.Index, DrawItemState.Default, e.ForeColor, Color.White);
            if (e.Index >= 0)            
                if (domainsListBox.Items[e.Index].GetType() == typeof(QuestionData))
                    if (((QuestionData)(domainsListBox.Items[e.Index])).Owner == LoggedInUserModel.Instance.User.Id)
                        e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State, e.ForeColor, Color.Gainsboro);
            
            // Draw the background of the ListBox control for each item.
            e.DrawBackground();
            
            if (flag)
            {
                Graphics g = e.Graphics;
                g.DrawRectangle(new Pen(new SolidBrush(Color.Black)), e.Bounds);
            }
            else
            {
                Graphics g = e.Graphics;
                g.DrawRectangle(new Pen(new SolidBrush(Color.White)), e.Bounds);
            }

            // Define the default color of the brush as black.
            Brush myBrush = Brushes.Black;

            // Determine the color of the brush to draw each item based 
            // on the index of the item to draw.
            if(e.Index>=0)
            {
                if (domainsListBox.Items[e.Index].GetType() == typeof(QuestionData))
                {
                    if (((QuestionData)(domainsListBox.Items[e.Index])).Status)
                    {
                        myBrush = Brushes.Blue;
                    }
                    else
                        myBrush = Brushes.Green;
                }
            
            // Draw the current item text based on the current Font 
            // and the custom brush settings.
            e.Graphics.DrawString(domainsListBox.Items[e.Index].ToString(),
                e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);
            }

            // If the ListBox has focus, draw a focus rectangle around the selected item.
            //e.DrawFocusRectangle();
        }

        private void myQuestionsListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            bool flag = false;
            if ((e.State & DrawItemState.Selected) != 0)
                flag = true;

            Rectangle rect = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height - 1);
            e = new DrawItemEventArgs(e.Graphics, e.Font, rect, e.Index, DrawItemState.Default, e.ForeColor, Color.White);

            // Draw the background of the ListBox control for each item.
            e.DrawBackground();

            if (flag)
            {
                Graphics g = e.Graphics;
                g.DrawRectangle(new Pen(new SolidBrush(Color.Black)), e.Bounds);
            }
            else
            {
                Graphics g = e.Graphics;
                g.DrawRectangle(new Pen(new SolidBrush(Color.White)), e.Bounds);
            }

            // Define the default color of the brush as black.
            Brush myBrush = Brushes.Black;

            // Determine the color of the brush to draw each item based 
            // on the index of the item to draw.
            if (e.Index >= 0)
            {
                if (myQuestionsListBox.Items[e.Index].GetType() == typeof(QuestionData))
                {
                    if (((QuestionData)(myQuestionsListBox.Items[e.Index])).Status)
                    {
                        myBrush = Brushes.Blue;
                    }
                    else
                        myBrush = Brushes.Green;
                }

                // Draw the current item text based on the current Font 
                // and the custom brush settings.
                e.Graphics.DrawString(myQuestionsListBox.Items[e.Index].ToString(),
                    e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);
            }

            // If the ListBox has focus, draw a focus rectangle around the selected item.
            e.DrawFocusRectangle();
        }

        private void questionSearchTextBox_Leave(object sender, EventArgs e)
        {
            if (questionSearchTextBox.Text == "")
            {
                questionSearchTextBox.Text = "Search...";
                questionSearchTextBox.ForeColor = Color.DarkGray;
            }
        }

        private void domainSearchTextBox_Leave(object sender, EventArgs e)
        {
            if (domainSearchTextBox.Text == "")
            {
                domainSearchTextBox.Text = "Search...";
                domainSearchTextBox.ForeColor = Color.DarkGray;
            }
        }

        private void questionSearchTextBox_Enter(object sender, EventArgs e)
        {
            if (questionSearchTextBox.Text == "Search...")
            {
                questionSearchTextBox.Text = "";
                questionSearchTextBox.ForeColor = Color.Black;
            }
        }

        private void domainSearchTextBox_Enter(object sender, EventArgs e)
        {
            if (domainSearchTextBox.Text == "Search...")
            {
                domainSearchTextBox.Text = "";
                domainSearchTextBox.ForeColor = Color.Black;
            }
        }
    }
}
