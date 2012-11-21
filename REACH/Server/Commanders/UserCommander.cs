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
    /* Manages incoming messages for the User module */
    public class UserCommander
    {
        /* 
         * Lets the Commander know when to call the MessageHandlers
         * in this class based on the value the corresponding
         * TriggerRule returns on the given Message.
         */
        public static void RegisterHandlers()
        {
            Commander.RegisterTriggerRule(GetUserInfo, GetUserInfoRule);
        }

        /* The TriggerRule for the GetUserInfo MessageHandler 
         * The message must be of GET_USER_INFO_REQUEST type to be 
         * handled by this MessageHandler.
         */
        private static Boolean GetUserInfoRule(RMessage message)
        {
            return message.Type == MessageType.GET_USER_INFO_REQUEST;
        }

        /* The GetUserInfo MessageHandler 
         * It handles messages of GET_USER_INFO_REQUEST type.
         */
        private static void GetUserInfo(RMessage message, TcpClient connection)
        {
            UserData user = (UserData)message.Data;
            user = UserConnector.GetUserById(user.Id);
            List<Object> list = new List<Object>();
            list.Add(user);
			list.Add(DomainConnector.GetAllDomains()); // all domains
			list.Add(DomainConnector.GetUserValidations(user.Id)); // domains for which the user has certificates
            RMessage replyMessage = new RMessage(MessageType.GET_USER_INFO_REPLY, list);
            ServerCore.GetWorkerByConnection(connection).SendMessage(replyMessage);
        }

    }
}
