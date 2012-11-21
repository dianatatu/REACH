using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using REACH.Client.Helpers;
using REACH.Client.Base;
using REACH.Client.Models;
using REACH.Client.Views;
using REACH.Common.Data;
using REACH.Common.Base;
using REACH.Common;

namespace REACH.Client.Controllers
{
	public class NewAccountController : ControllerBase<NewAccountModel>
	{
		private const string EMAIL_REGEX = "[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,4}";
		private const int MIN_LENGTH = 3;
		private const int MAX_LENGTH = 32;

		/* Constructor */
		public NewAccountController()
		{
			model = NewAccountModel.Instance;
		}

        public void RegisterHandlers()
        {
            Context.RegisterTriggerRule(OnGetAllDomains, OnGetAllDomainsRule);
			Context.RegisterTriggerRule(OnDomainsTimeOut, OnDomainsTimeOutRule);
			Context.RegisterTriggerRule(OnUsernameTaken, OnUsernameTakenRule);
			Context.RegisterTriggerRule(OnUsernameTakenTimeOut, OnUsernameTakenTimeOutRule);
			Context.RegisterTriggerRule(OnStartTest, OnStartTestRule);
			Context.RegisterTriggerRule(OnStartTestTimeout, OnStartTestTimeoutRule);		
        }

		public void UnregisterHandlers()
		{
			Context.UnregisterTriggerRule(OnGetAllDomains, OnGetAllDomainsRule);
			Context.UnregisterTriggerRule(OnDomainsTimeOut, OnDomainsTimeOutRule);
			Context.UnregisterTriggerRule(OnUsernameTaken, OnUsernameTakenRule);
			Context.UnregisterTriggerRule(OnUsernameTakenTimeOut, OnUsernameTakenTimeOutRule);
			Context.UnregisterTriggerRule(OnStartTestTimeout, OnStartTestTimeoutRule);
			Context.UnregisterTriggerRule(OnStartTest, OnStartTestRule);
		}

		private bool hasValidCharacters(string str)
		{
			for (int i = 0; i < str.Length; ++i)
				if (!Char.IsLetterOrDigit(str[i]))
					return false;
			return true;
		}

		private bool isSecure(string pass)
		{
			bool hasLetter = false, hasDigit = false;
			for (int i = 0; i < pass.Length; ++i)
			{
				hasLetter |= Char.IsLetter(pass[i]);
				hasDigit |= Char.IsDigit(pass[i]);
			}
			return hasLetter && hasDigit;
		}

		// only basic checks
		private bool validEmail(string email)
		{
			Match match = Regex.Match(email, EMAIL_REGEX,
				RegexOptions.IgnoreCase);			
			return match.Success;
		}

		/*
		 * Events section
		 */
		#region events

		public event ExternalEventHandler DomainsReceivedFromServer;
		public event ExternalEventHandler DomainsTimeOut;
		public event ExternalEventHandler LocalVerificationComplete;
		public event ExternalEventHandler UsernameTaken;
		public event ExternalEventHandler CreateAccountInit;
		public event ExternalEventHandler CreateAccountDeny;
		public event ExternalEventHandler QuizesReceivedFromServer;
		public event ExternalEventHandler TestChanged;
		public event ExternalEventHandler AllTestsFinished;
		public event ExternalEventHandler QuestionChanged;
		public event ExternalEventHandler Timeout;
		public event ExternalEventHandler Tick;
		public event ExternalEventHandler TimeExpired;

		#endregion

		/* 
		 * Commands section 
		 */
		#region commands

		// Get the list of all possible domains from the server
		public void GetAllDomains()
		{
			RMessage msg = new RMessage(MessageType.GET_ALL_DOMAINS_REQUEST, null);
			Service.Instance.AddMessage(msg);
		}

		// Start validating the given credentials
		public void ValidateAccount(
			string username,
			string pass,
			string confirm_pass,
			string email,
			List<DomainData> domains)
		{
			Dictionary<String, String> errors = new Dictionary<string,string>();

			// Check the username
			if (username.Trim().Length == 0)
				errors["username"] = "Username cannot be empty.";
			else if (username.Trim().Length < MIN_LENGTH || 
				username.Trim().Length > MAX_LENGTH)
				errors["username"] = "The username can contain between " 
					+ MIN_LENGTH + " and " + MAX_LENGTH + " characters.";
			else if (!hasValidCharacters(username))
				errors["username"] = "The username can only contain letters and digits.";

			// Check the password
			if (pass.Length == 0)
				errors["password"] = "The password cannot be empty.";
			else if (pass.Length < MIN_LENGTH || pass.Length > MAX_LENGTH)
				errors["password"] = "The password can contain between "
					+ MIN_LENGTH + " and " + MAX_LENGTH + " characters.";
			else if (!hasValidCharacters(pass))
				errors["password"] = "The password can only contain letters and digits.";
			else if (!isSecure(pass))
				errors["password"] = "The password must contain a letter and a digit.";

			// Check the password confirmation
			if (pass != confirm_pass)
				errors["confirm"] = "The two passwords must be the same.";

			// Check the email
			if (email.Length == 0)
				errors["email"] = "The e-mail address cannot be empty.";
			else if (!validEmail(email))
				errors["email"] = "The e-mail address is not valid.";

			// Check the domain list
			if (domains == null || domains.Count == 0)
				errors["domains"] = "At least one domain must be selected.";

			if (errors.ContainsKey("username"))
				errors["general"] = errors["username"];
			else if (errors.ContainsKey("password"))
				errors["general"] = errors["password"];
			else if (errors.ContainsKey("confirm"))
				errors["general"] = errors["confirm"];
			else if (errors.ContainsKey("email"))
				errors["general"] = errors["email"];
			else if (errors.ContainsKey("domains"))
				errors["general"] = errors["domains"];

			if (errors.Count > 0)
			{
				model.Errors = errors;
				CreateAccountDeny(model);
				return;
			}

			// All the credentials are client-side correct.
			// Store them in the model for further use.
			model.Username = username;
			model.Password = Md5Helper.GetMd5(pass);
			model.Email = email;
			model.CertifiedDomains = domains;

			// The server must also receive the credentials,
			// to check if the username has already been taken.
			LocalVerificationComplete(model);
			RMessage message = new RMessage(
				MessageType.USERNAME_TAKEN_REQUEST,
				new UserData(username, null));
			Service.Instance.AddMessage(message);
		}

		public void CreateAccount()
		{
			UserData user = 
				new UserData(
					0,
					model.Username,
					model.Password, 
					model.Email, 
					false,
					0);

			List<DomainData> passedDomains = new List<DomainData>();
			for (int i = 0; i < model.CertifiedDomains.Count; ++i)
				if (model.GetScoreForTest(i) >= NewAccountModel.MIN_PASSING_SCORE)
					passedDomains.Add(model.CertifiedDomains[i]);

			List<object> itemsToSend = new List<object>();
			List<int> scores = new List<int>();
			for (int i = 0; i < model.CertifiedDomains.Count; ++i)
			{
				bool found = false;
				for (int j = 0; j < passedDomains.Count && !found; ++j)
					found = (model.CertifiedDomains[i].Name == passedDomains[j].Name);
				if (found)
					scores.Add(model.GetScoreForTest(i));
			}
				
			itemsToSend.Add(user);
			itemsToSend.Add(passedDomains);
			itemsToSend.Add(scores);

			RMessage msg = new RMessage(
				MessageType.CREATE_NEW_USER_REQUEST, 
				itemsToSend);
			Service.Instance.AddMessage(msg);
		}

		public void DecreaseTime()
		{
			model.Tick();
			if (model.RemainingTime == 0)
				TimeExpired(model);
			else
				Tick(model);
		}

		public void StartTest()
		{
			model.InitTest();
			StartSet();
		}

		public void StartSet()
		{
			model.InitSet();
			TestChanged(model);
			QuestionChanged(model);
		}

		// Get the next question in the current quiz set
		public void GetNextQuestion()
		{
			model.GetNextQuestion();
			QuestionChanged(model);
		}

		// Get the previous question in the current quiz set
		public void GetPreviousQuestion()
		{
			model.GetPreviousQuestion();
			QuestionChanged(model);
		}

		// Answer the current question in the current quiz set with ans
		public void Answer(int answer)
		{
			model.CurrentQuestion.Answer = answer;
		}

		// Finish the current quiz set
		public void FinishQuizSet()
		{
			int nrCorrect = 0;
			QuizSetData quiz = model.CurrentQuiz;
			for (int i = 0; i < quiz.Question.Count; ++i)
				if (quiz.Question[i].Answer == quiz.Question[i].Correct)
					++nrCorrect;
			model.SetScoreForCurrentTest(nrCorrect);
			if (model.IsLastSet())
				AllTestsFinished(model);
			else
			{
				model.GetNextSet();
				StartSet();
			}
		}

		public void TakeNewCert(DomainData domain, int score)
		{
			List<object> list = new List<object>();
			list.Add(LoggedInUserModel.Instance.User);
			list.Add(domain);
			list.Add(score);
			RMessage msg = new RMessage(MessageType.TAKE_NEW_CERT_REQUEST, list);
			Service.Instance.AddMessage(msg);
		}

		#endregion

		/* 
		 * Trigger rules for callback functions 
		 */
		#region rules

		public bool OnGetAllDomainsRule(RMessage message)
		{
			if (message.Type != MessageType.GET_ALL_DOMAINS_REPLY)
				return false;
			return true;
		}

		public bool OnDomainsTimeOutRule(RMessage message)
		{
			if (message.Type != MessageType.GET_ALL_DOMAINS_REQUEST)
				return false;
			return true;
		}

		public bool OnUsernameTakenRule(RMessage message)
		{
			if (message.Type != MessageType.USERNAME_TAKEN_REPLY)
				return false;
			return true;
		}

		public bool OnUsernameTakenTimeOutRule(RMessage message)
		{
			if (message.Type != MessageType.USERNAME_TAKEN_REQUEST)
				return false;
			return true;
		}

		public bool OnStartTestTimeoutRule(RMessage message)
		{
			if (message.Type != MessageType.START_TEST_REQUEST)
				return false;
			return true;
		}

		public bool OnStartTestRule(RMessage message)
		{
			if (message.Type != MessageType.START_TEST_REPLY)
				return false;
			return true;
		}

		#endregion

		/* 
		 * Callback functions section (for asynchronous actions).
		 * These methods will be triggered by the Context. 
		 */
		#region callbacks
    
    	public void OnGetAllDomains(RMessage message)
		{
			model.AllDomains = (List<DomainData>)message.Data;
			DomainsReceivedFromServer(model);
		}
    
    	public void OnDomainsTimeOut(RMessage message)
		{
			DomainsTimeOut(model);
		}
    
    	public void OnUsernameTaken(RMessage message)
		{
			Boolean isUsernameTaken = (Boolean)message.Data;
			if (isUsernameTaken == false)
			{
				CreateAccountInit(null);
				RMessage msg = new RMessage(
					MessageType.START_TEST_REQUEST,
					model.CertifiedDomains);
				Service.Instance.AddMessage(msg);
			}
			else
				UsernameTaken(null);
		}
    
    	public void OnUsernameTakenTimeOut(RMessage message)
		{
			Timeout(null);
		}
    
    	public void OnStartTestTimeout(RMessage message)
		{
			Timeout(null);
		}

		public void OnStartTest(RMessage message)
		{
			model.QuizSet = (List<QuizSetData>)message.Data;
			QuizesReceivedFromServer(model);
		}

		#endregion
	}
}
