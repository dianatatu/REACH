using System;
using System.Collections.Generic;
using System.Net.Sockets;

using REACH.Common;
using REACH.Common.Base;
using REACH.Common.Data;
using REACH.Server.Base;
using REACH.Server.Connectors;

namespace REACH.Server.Commanders
{
	/* Manages incoming messages for the NewAccount module */
	public class NewAccountCommander
	{
		public const int QUESTIONS_PER_SET = 5;

		/* 
		 * Lets the Commander know when to call the MessageHandlers
		 * in this class based on the value the corresponding
		 * TriggerRule returns on the given Message.
		 */
		public static void RegisterHandlers()
		{
			Commander.RegisterTriggerRule(UserTakenCheck, UserTakenCheckRule);
			Commander.RegisterTriggerRule(StartTest, StartTestRule);
			Commander.RegisterTriggerRule(CreateNewUser, CreateNewUserRule);
			Commander.RegisterTriggerRule(TakeNewCert, TakeNewCertRule);        
		}
		
        /* The TriggerRule for the UserTakenCheck MessageHandler 
         * The message must be of USERNAME_TAKEN_REQUEST type to be 
         * handled by this MessageHandler.
         */
		private static Boolean UserTakenCheckRule(RMessage message)
        {
            return message.Type == MessageType.USERNAME_TAKEN_REQUEST;
        }

		/* The UserTakenCheck MessageHandler 
		 * It handles messages of USERNAME_TAKEN_REQUEST type.
		 */
		private static void UserTakenCheck(RMessage message, TcpClient connection)
        {
			Console.WriteLine("UserTakenCheck request");
			UserData user = (UserData)message.Data;
			Boolean taken = false;
			if (user != null)
				taken = (UserConnector.GetUser(user.Username) != null);
			RMessage replyMessage =
							new RMessage(
								MessageType.USERNAME_TAKEN_REPLY,
								taken);
			ServerCore.GetWorkerByConnection(connection).SendMessage(replyMessage);
        }

		// Select m random different natural numbers from interval [0, n-1]
		private static List<int> GetRandoms(int n, int m)
		{
			Random rnd = new Random();

			List<int> interval = new List<int>();
			for (int i = 0; i < n; ++i)
				interval.Add(i);
			int poz, aux;
			for (int i = 0; i < m; ++i)
			{
				poz = rnd.Next(i, n);
				aux = interval[i];
				interval[i] = interval[poz];
				interval[poz] = aux;
			}

			List<int> selected = new List<int>();
			for (int i = 0; i < m; ++i)
				selected.Add(interval[i]);
			return selected;
		}

		/* The TriggerRule for the StartTest MessageHandler 
         * The message must be of START_TEST_REQUEST type to be 
         * handled by this MessageHandler.
         */
		private static Boolean StartTestRule(RMessage message)
        {
			return message.Type == MessageType.START_TEST_REQUEST;
        }

        /* The StartTest MessageHandler 
         * It handles messages of START_TEST_REQUEST type.
         */
        private static void StartTest(RMessage message, TcpClient connection)
        {
			List<DomainData> reqDomains = (List<DomainData>)message.Data;
			
			List<QuizSetData> quizList = new List<QuizSetData>();
			for (int i = 0; i < reqDomains.Count; ++i)
			{
				// Get all questions from the database
				List<QuizItemData> allQuestions = 
					QuizItemConnector.GetAllItems(reqDomains[i].ID);

				// Select random questions from the set
				List<int> selected = 
					GetRandoms(allQuestions.Count, QUESTIONS_PER_SET);

				// Create a new QuizSet with the selected questions
				QuizSetData quizSet = new QuizSetData(reqDomains[i].Name);
				for (int j = 0; j < QUESTIONS_PER_SET; ++j)
					quizSet.AddQuestion(allQuestions[selected[j]]);
				quizList.Add(quizSet);
			}
			
			RMessage replyMessage =
				new RMessage(
					MessageType.START_TEST_REPLY,
					quizList);
			
			ServerCore.GetWorkerByConnection(connection).SendMessage(replyMessage);
        }

        /* The TriggerRule for the CreateNewUser MessageHandler 
         * The message must be of CREATE_NEW_USER_REQUEST type to be 
         * handled by this MessageHandler.
         */
        private static Boolean CreateNewUserRule(RMessage message)
        {
            return message.Type == MessageType.CREATE_NEW_USER_REQUEST;
        }

		private static double GetRank(int score)
		{
			switch (score)
			{
				case 3:
					return Ranking.USER_INITIAL_RANK_BEGINNER;
				case 4:
					return Ranking.USER_INITIAL_RANK_INTERMEDIATE;
				case 5:
					return Ranking.USER_INITIAL_RANK_ADVANCED;
			}
			return 0;
		}

        /* The CreateNewUser MessageHandler 
         * It handles messages of CREATE_NEW_USER_REQUEST type.
         */
        private static void CreateNewUser(RMessage message, TcpClient connection)
        {
			Console.WriteLine("CreateNewUser request");

			List<object> items = (List<object>)message.Data;
			UserData user = (UserData)items[0];
			List<DomainData> domains = (List<DomainData>)items[1];
			List<int> scores = (List<int>)items[2];

			double initialRank = 0;
			for (int i = 0; i < domains.Count; ++i)
				initialRank += GetRank(scores[i]);

			UserConnector.AddUser(user.Username, user.Password, user.Email, initialRank);
			user = UserConnector.GetUser(user.Username);

			foreach (DomainData item in domains)
				ValidationConnector.AddValidation(user.Id, item.ID);
        }

		/* The TriggerRule for the TakeNewCert MessageHandler 
         * The message must be of TAKE_NEW_CERT_REQUEST type to be 
         * handled by this MessageHandler.
         */
        private static Boolean TakeNewCertRule(RMessage message)
        {
			return message.Type == MessageType.TAKE_NEW_CERT_REQUEST;
        }

        /* The TakeNewCert MessageHandler 
         * It handles messages of MESSAGE_TYPE type.
         */
        private static void TakeNewCert(RMessage message, TcpClient connection)
        {
			List<object> list = (List<object>)message.Data;
			UserData user = (UserData)list[0];
			DomainData domain = (DomainData)list[1];
			int score = (int)list[2];
			UserConnector.UpdateUserRank(user.Id, GetRank(score));
			ValidationConnector.AddValidation(user.Id, domain.ID);
        }

	}
}
