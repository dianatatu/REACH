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
    /* Manages incoming messages for the Domain module */
    public class DomainCommander
    {
        /* 
         * Lets the Commander know when to call the MessageHandlers
         * in this class based on the value the corresponding
         * TriggerRule returns on the given Message.
         */
        public static void RegisterHandlers()
        {
            Commander.RegisterTriggerRule(GetAllDomains, GetAllDomainsRule);
            Commander.RegisterTriggerRule(GetAllDomainsOrdered, GetAllDomainsOrderedRule);
        }

        /* The TriggerRule for the GetAllDomains MessageHandler 
         * The message must be of GET_ALL_DOMAINS_REQUEST type to be 
         * handled by this MessageHandler.
         */
        private static Boolean GetAllDomainsRule(RMessage message)
        {
            return message.Type == MessageType.GET_ALL_DOMAINS_REQUEST;
        }

        /* The GetAllDomains MessageHandler 
         * It handles messages of GET_ALL_DOMAINS_REQUEST type.
         */
        private static void GetAllDomains(RMessage message, TcpClient connection)
        {
            Console.WriteLine("GetAllDomains request");
            RMessage replyMessage =
                new RMessage(
                    MessageType.GET_ALL_DOMAINS_REPLY,
                    DomainConnector.GetAllDomains());
            ServerCore.GetWorkerByConnection(connection).SendMessage(replyMessage);
        }

        /* The TriggerRule for the GetAllDomainsOrdered MessageHandler 
         * The message must be of GET_ALL_DOMAINS_ORDERED_REQUEST type to be 
         * handled by this MessageHandler.
         */
        private static Boolean GetAllDomainsOrderedRule(RMessage message)
        {
            return message.Type == MessageType.GET_ALL_DOMAINS_ORDERED_REQUEST;
        }

        /* The GetAllDomainsOrdered MessageHandler 
         * It handles messages of GET_ALL_DOMAINS_ORDERED_REQUEST type.
         */
        private static void GetAllDomainsOrdered(RMessage message, TcpClient connection)
        {
            uint uid = ServerCore.GetIdByConnection(connection);
            List<DomainData> validations = DomainConnector.GetUserValidations(uid);
            List<DomainData> nonValidations = DomainConnector.GetUserNonValidations(uid);
            validations.AddRange(nonValidations);
             RMessage replyMessage =
                new RMessage(
                    MessageType.GET_ALL_DOMAINS_ORDERED_REPLY,
                    validations);
            ServerCore.GetWorkerByConnection(connection).SendMessage(replyMessage);
        }


    }
}
