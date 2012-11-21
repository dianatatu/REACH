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
    /* Manages incoming messages for the Login module */
    public class LoginCommander
    {
        /* 
         * Lets the Commander know when to call the MessageHandlers
         * in this class based on the value the corresponding
         * TriggerRule returns on the given Message.
         */
        public static void RegisterHandlers()
        {
			Commander.RegisterTriggerRule(EndItAll, EndItAllRule);
            Commander.RegisterTriggerRule(SignIn, SignInRule);
			Commander.RegisterTriggerRule(SignOut, SignOutRule);
            Commander.RegisterTriggerRule(LogConnector, LogConnectorRule);
        }

        /* The TriggerRule for the LogConnector MessageHandler 
         * The message must be of RANK_USER_LOGGED_TIME_REQUEST type to be 
         * handled by this MessageHandler.
         */
        private static Boolean LogConnectorRule(RMessage message)
        {
            return message.Type == MessageType.RANK_USER_LOGGED_TIME_REQUEST;
        }

        /* The LogConnector MessageHandler 
         * It handles messages of RANK_USER_LOGGED_TIME_REQUEST type.
         */
        private static void LogConnector(RMessage message, TcpClient connection)
        {
            double value = Ranking.USER_UP_TIME_POINT_VALUE * (Double)message.Data;
            UserConnector.UpdateUserRank(ServerCore.GetIdByConnection(connection),value);
        }

        /* The TriggerRule for the EndItAll MessageHandler 
         * The message must be of END_IT_ALL_REQUEST type to be 
         * handled by this MessageHandler.
         */
        private static Boolean EndItAllRule(RMessage message)
        {
            return message.Type == MessageType.END_IT_ALL_REQUEST;
        }

        /* The SignIn MessageHandler 
         * It handles messages of END_IT_ALL_REQUEST type.
         */
        private static void EndItAll(RMessage message, TcpClient connection)
        {
            Console.WriteLine("EndItAll");
            ServerCore.GetWorkerByConnection(connection).CloseConnection();
        }

        /* The TriggerRule for the SignIn MessageHandler 
         * The message must be of GET_ALL_QUESTIONS_REQUEST type to be 
         * handled by this MessageHandler.
         */
        private static Boolean SignInRule(RMessage message)
        {
            return message.Type == MessageType.SIGN_IN_REQUEST;
        }

        /* The SignIn MessageHandler 
         * It handles messages of SIGN_IN_REQUEST type.
         */
        private static void SignIn(RMessage message, TcpClient connection)
        {
			RMessage replyMessage;

            UserData user1 = (UserData)message.Data;
         	UserData user2 = UserConnector.GetUser(user1.Username);

			// Check if the password match
			if (user2 != null && user2.Password != user1.Password)
				user2 = null;

			// If the credentials do not match, refuse the authentification
			if (user2 == null)
			{
				ServerCore.GetWorkerByConnection(connection).SendMessage(
					new RMessage(MessageType.SIGN_IN_REPLY, null));
				return;
			}

			// If the user can authenticate, disconnect another user connected
			// with the same username
			if (user2 != null)
			{
				TcpClient previousConnection = ServerCore.GetConnectionById(user2.Id);
				if (previousConnection != null)
				{
					ServerCore.RemoveIdConnectionMapping(user2.Id, previousConnection);
					replyMessage =
						new RMessage(
							MessageType.SIGN_OUT_REPLY,
							user2);
					ServerCore.GetWorkerByConnection(previousConnection)
						.SendMessage(replyMessage);
				}
			}

			List<Object> payload = new List<Object>();
			payload.Add(user2); // user data
			payload.Add(DomainConnector.GetAllDomains()); // all domains
			payload.Add(DomainConnector.GetUserValidations(user2.Id)); // domains for which the user has certificates
            replyMessage =
                new RMessage(
                    MessageType.SIGN_IN_REPLY,
                    payload);
            ServerCore.GetWorkerByConnection(connection).SendMessage(replyMessage);

			// If the user connected successfully, store the connection mapping
			if (user2 != null)
				ServerCore.AddIdConnectionMapping(user2.Id, connection);
        }
		
		/*
		 * SignOut is called when the user makes a sign out request.
		 */
		private static Boolean SignOutRule(RMessage message)
		{
			return message.Type == MessageType.SIGN_OUT_REQUEST &&
					message.Data != null && message.Data.GetType() == typeof(UserData);
		}

		private static void SignOut(RMessage message, TcpClient connection)
		{
            Console.WriteLine("SignOut");
			UserData user = (UserData)message.Data;
			Console.WriteLine("SignOut Succeeded.");
			ServerCore.RemoveIdConnectionMapping(user.Id, connection);
			RMessage replyMessage =
				new RMessage(
					MessageType.SIGN_OUT_REPLY,
					user);
			ServerCore.GetWorkerByConnection(connection).SendMessage(replyMessage);
		}
    }
}
