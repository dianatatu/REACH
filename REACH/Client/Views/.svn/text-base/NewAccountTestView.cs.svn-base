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
	public partial class NewAccountTestView : Form, IView
	{
		public const int CREATE_NEW_ACCOUNT = 0x0;
		public const int TAKE_NEW_CERT = 0x1;

		private int type;
		private Form parentForm;
		private NewAccountController controller;

		private const int CP_NOCLOSE_BUTTON = 0x200;
		public delegate void EmptyFunction();

		public NewAccountTestView(int type, Form parent)
		{
			// Create the controller
			controller = new NewAccountController();

			// Handlers for external events
			controller.Tick += new NewAccountController.ExternalEventHandler(OnTick);
			controller.TimeExpired += new NewAccountController.ExternalEventHandler(OnTimeExpired);
			controller.QuestionChanged += new NewAccountController.ExternalEventHandler(OnQuestionChanged);
			controller.TestChanged += new NewAccountController.ExternalEventHandler(OnTestChanged);			
			controller.AllTestsFinished += new NewAccountController.ExternalEventHandler(OnAllTestsFinished);
        
			// Register the controller handlers to the service
			controller.RegisterHandlers();

			// Initialize Component
			InitializeComponent();

			// Set the parent and display the window
			SetMdiParent();
			ShowForm();

			// Handlers for internal events			
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(OnFormClosing);
			timer1.Tick += new System.EventHandler(timer1_Tick);
			NextQuestionButton.Click += new System.EventHandler(NextQuestionButton_Click);
			PreviousQuestionButton.Click += new System.EventHandler(PreviousQuestionButton_Click);
			FinishTestButton.Click += new System.EventHandler(FinishTestButton_Click);
			ReturnToLogin.Click += new System.EventHandler(ReturnToLogin_Click);
			varA.Click += new System.EventHandler(varA_Click);
			varB.Click += new System.EventHandler(varB_Click);			
			varC.Click += new System.EventHandler(varC_Click);
			varD.Click += new System.EventHandler(varD_Click);

			this.type = type;
			this.parentForm = parent;
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

		// Disable close button
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams myCp = base.CreateParams;
				myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
				return myCp;
			}
		}

		private String ConvertToTime(int time)
		{
			String result = "";

			int mins = time / 60;
			int secs = time % 60;

			if (mins == 0)
				result += "00";
			else
				result += ((mins < 10) ? "0" : "") + mins;
			
			result += ":";

			if (secs == 0)
				result += "00";
			else
				result += ((secs < 10) ? "0" : "") + secs;

			return result;
		}

		/*
		 * Handlers for internal events
		 */
		#region internal_events

		private void OnFormClosing(object sender, FormClosingEventArgs e)
		{
			controller.UnregisterHandlers();
		}

		private void NewAccountTestView_Load(object sender, EventArgs e)
		{
			timer1.Enabled = true;
			controller.StartTest();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			controller.DecreaseTime();
		}

		private void NextQuestionButton_Click(object sender, EventArgs e)
		{
			controller.GetNextQuestion();
		}

		private void PreviousQuestionButton_Click(object sender, EventArgs e)
		{
			controller.GetPreviousQuestion();
		}

		private void varA_Click(object sender, EventArgs e)
		{
			controller.Answer(0);
		}

		private void varB_Click(object sender, EventArgs e)
		{
			controller.Answer(1);
		}

		private void varC_Click(object sender, EventArgs e)
		{
			controller.Answer(2);
		}

		private void varD_Click(object sender, EventArgs e)
		{
			controller.Answer(3);
		}

		private void FinishTestButton_Click(object sender, EventArgs e)
		{
			DialogResult ans = MessageBox.Show(
				"Are you sure you want to finish the test?", 
				"REACH", 
				MessageBoxButtons.YesNo);

			if (ans == DialogResult.Yes)
				controller.FinishQuizSet();
		}

		private void ReturnToLogin_Click(object sender, EventArgs e)
		{
			ReachWindow mainWindow = (ReachWindow)Context.EntryPoint;
			mainWindow.CloseAllChildren();
		}

		#endregion

		/*
		 * Handlers for external events
		 */
		#region external_events

		private void OnTick(NewAccountModel model)
		{
			while (!this.IsHandleCreated) ;
			if (this.InvokeRequired)
			{
				this.Invoke((NewAccountController.ExternalEventHandler)
					OnTick, model);
				return;
			}

			timeLeft.Text = ConvertToTime(model.RemainingTime);
			if (model.RemainingTime > 10)
				timeLeft.ForeColor = Color.Black;				
			else
				timeLeft.ForeColor = Color.Red;
		}

		private void OnTimeExpired(NewAccountModel model)
		{
			while (!this.IsHandleCreated);
			if (this.InvokeRequired)
			{
				this.Invoke((NewAccountController.ExternalEventHandler)
					OnTimeExpired, model);
				return;
			}

			timeLeft.Text = "00:00";
			timer1.Enabled = false;
			MessageBox.Show("Time expired.", "REACH");
			controller.FinishQuizSet();
		}

		private void OnQuestionChanged(NewAccountModel model)
		{
			while (!this.IsHandleCreated);
			if (this.InvokeRequired)
			{
				this.Invoke((NewAccountController.ExternalEventHandler)
					OnQuestionChanged, model);
				return;
			}

			title.Text = model.CurrentQuestion.Title;
			varA.Checked = varB.Checked = varC.Checked = varD.Checked = false;
			varA.Text = model.CurrentQuestion.VarA;
			varB.Text = model.CurrentQuestion.VarB;
			varC.Text = model.CurrentQuestion.VarC;
			varD.Text = model.CurrentQuestion.VarD;
			switch (model.CurrentQuestion.Answer)
			{
				case 0: varA.Checked = true; break;
				case 1: varB.Checked = true; break;
				case 2: varC.Checked = true; break;
				case 3: varD.Checked = true; break;
				default: break;
			}

			NextQuestionButton.Enabled = !model.IsLastQuestionInSet();
			PreviousQuestionButton.Enabled = !model.IsFirstQuestionInSet();

			q1.BackColor = q2.BackColor = q3.BackColor = 
				q4.BackColor = q5.BackColor = Color.White;
			switch (model.CurrentQuestionIndex)
			{
				case 0: q1.BackColor = Color.Lime; break;
				case 1: q2.BackColor = Color.Lime; break;
				case 2: q3.BackColor = Color.Lime; break;
				case 3: q4.BackColor = Color.Lime; break;
				case 4: q5.BackColor = Color.Lime; break;
				default: break;
			}
		}

		private void OnTestChanged(NewAccountModel model)
		{
			while (!this.IsHandleCreated);
			if (this.InvokeRequired)
			{
				this.Invoke((NewAccountController.ExternalEventHandler)
					OnTestChanged, model);
				return;
			}

			// stop the timer
			timer1.Enabled = false;
			timeLeft.Text = ConvertToTime(60 * NewAccountModel.MINUTES_PER_QUIZ);
			MessageBox.Show("Start the test for: " + model.CurrentQuiz.Domain, "REACH");

			// set the domain
			domain.Text = model.CurrentQuiz.Domain;

			// reset the timer
			timer1.Enabled = true;
		}

		private void OnAllTestsFinished(NewAccountModel model)
		{
			while (!this.IsHandleCreated);
			if (this.InvokeRequired)
			{
				this.Invoke((NewAccountController.ExternalEventHandler)
					OnAllTestsFinished, model);
				return;
			}

			timer1.Enabled = false;		

			if (type == TAKE_NEW_CERT)
			{
				int score = model.GetScoreForTest(0);

				if (score >= NewAccountModel.MIN_PASSING_SCORE)
				{
					MessageBox.Show(
						"You obtained " + score + " points and received the certification for the domain!",
						"REACH");
					controller.TakeNewCert(model.CertifiedDomains[0], score);					
				}
				else
					MessageBox.Show(
						"You didn't pass the test and did not received the certification. You may try again.",
						"REACH");

				parentForm.Close();
				this.Close();
				return;
			}

			testContainer.Visible = false;	
			resultsContainer.Visible = true;
			int passed = 0;
			for (int i = 0; i < model.CertifiedDomains.Count; ++i)
			{
				// rating control
				RatingControl r = new RatingControl();
				r.Location = new Point(89, 99 + i * (r.Height+1));
				r.Rating = model.GetScoreForTest(i);
				r.Fixed = true;
				if (r.Rating >= NewAccountModel.MIN_PASSING_SCORE)
					++passed;
				r.Visible = true;
				resultsContainer.Controls.Add(r);

				// the label with the domain
				Label domainTitle = new Label();
				domainTitle.Location = new Point(12, 106 + i * (r.Height + 1));
				domainTitle.Font = new Font(
					"Microsoft Sans Serif",
					9.75F,
					FontStyle.Regular,
					GraphicsUnit.Point,
					((byte)(0)));
				domainTitle.Text = model.CertifiedDomains[i].Name + ":";
				domainTitle.Visible = true;
				resultsContainer.Controls.Add(domainTitle);

				// the label with the result
				Label domainStatus = new Label();
				domainStatus.Location = new Point(211, 106 + i * (r.Height+1));
				domainStatus.Font = new Font(
					"Microsoft Sans Serif", 
					9.75F, 
					FontStyle.Bold, 
					GraphicsUnit.Point, 
					((byte)(0)));
				if (r.Rating >= NewAccountModel.MIN_PASSING_SCORE)
				{
					domainStatus.ForeColor = Color.Green;
					domainStatus.Text = "Passed";
				}
				else
				{
					domainStatus.ForeColor = Color.Red;
					domainStatus.Text = "Failed";
				}
				domainStatus.Visible = true;
				resultsContainer.Controls.Add(domainStatus);
			}
			if (passed > 0)
			{
				resultTitle.Text = 
					"Your account was created. You will receive a certificate for each domain that you passed successfully.";
				controller.CreateAccount();
			}
			else
				resultTitle.Text = 
					"You didn't pass any test. Your account was not created. You may try again.";
		}

		#endregion

	}
}
