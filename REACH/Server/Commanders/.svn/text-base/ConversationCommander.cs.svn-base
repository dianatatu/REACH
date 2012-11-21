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
    /* Manages incoming messages for the Conversation module */
    public class ConversationCommander
    {
        /* 
         * Lets the Commander know when to call the MessageHandlers
         * in this class based on the value the corresponding
         * TriggerRule returns on the given Message.
         */
        public static void RegisterHandlers()
        {
            Commander.RegisterTriggerRule(AddSay, AddSayRule);
            Commander.RegisterTriggerRule(PartnerInfoRequested, PartnerInfoRequestedRule);
        }

        /* The TriggerRule for the AddSay MessageHandler 
        * The message must be of ADD_SAY_REQUEST type to be 
        * handled by this MessageHandler.
        */
        private static Boolean AddSayRule(RMessage message)
        {
            return message.Type == MessageType.ADD_SAY_REQUEST;
        }

        /* The GetFriendList MessageHandler 
         * It handles messages of ADD_SAY_REQUEST type.
         */
        private static void AddSay(RMessage message, TcpClient connection)
        {
            Console.WriteLine("AddSay");
            SayData say = (SayData)(message.Data);
            uint id = say.Id;
            say.Id = ServerCore.GetIdByConnection(connection);
			if (ServerCore.GetWorkerById(id) != null)
            {
                RMessage replyMessage = new RMessage(MessageType.ADD_SAY_REPLY, say);
				ServerCore.GetWorkerById(id).SendMessage(replyMessage);
            }
            UserConnector.UpdateUserRank(say.Id, Ranking.ADD_SAY);
        }

       
        /* The TriggerRule for the PartnerInfoRequested MessageHandler 
         * The message must be of PARTNER_INFO_REQUEST type to be 
         * handled by this MessageHandler.
         */
        private static Boolean PartnerInfoRequestedRule(RMessage message)
        {
            return message.Type == MessageType.PARTNER_INFO_REQUEST;
        }

        /* The PartnerInfoRequested MessageHandler 
         * It handles messages of PARTNER_INFO_REQUEST type.
         */
        private static void PartnerInfoRequested(RMessage message, TcpClient connection)
        {
            Console.WriteLine("PartnerInfoRequested");
            UserData partner = UserConnector.GetUserById((uint)message.Data);
            RMessage replyMessage = new RMessage(MessageType.PARTNER_INFO_REPLY,partner);
            ServerCore.GetWorkerByConnection(connection).SendMessage(replyMessage);
        }

    }
}
