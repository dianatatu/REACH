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
    /* Manages incoming messages for the QuestionAdd module */
    public class QuestionAddCommander
    {
        /* 
         * Lets the Commander know when to call the MessageHandlers
         * in this class based on the value the corresponding
         * TriggerRule returns on the given Message.
         */
        public static void RegisterHandlers()
        {
            Commander.RegisterTriggerRule(AddQuestion, AddQuestionRule);
        }

        /* The TriggerRule for the AddQuestion MessageHandler 
         * The message must be of ADD_QUESTION_REQUEST type to be 
         * handled by this MessageHandler.
         */
        private static Boolean AddQuestionRule(RMessage message)
        {
            return message.Type == MessageType.ADD_QUESTION_REQUEST;
        }

        /* The AddQuestion MessageHandler 
         * It handles messages of ADD_QUESTION_REQUEST type.   
         */
        private static void AddQuestion(RMessage message, TcpClient connection)
        {
            Console.WriteLine("AddQuestion");
            List<Object> data = (List<Object>)message.Data;
            QuestionData question0 = (QuestionData)data[0];
            List<DomainData> domains = (List<DomainData>)data[1];

            QuestionConnector.AddQuestion(question0);
            UserConnector.UpdateUserRank(question0.Owner, Ranking.ADD_QUESTION);

            UInt32 id = (UInt32)(Int64Connector.GetLastInsertId());
            QuestionData question = QuestionConnector.GetQuestion(id);

            QuestionConnector.AddDomainQuestion(id, domains);

            List<ClientWorker> allWorkers = ServerCore.GetAllWorkers();
            foreach (ClientWorker workersIterator in allWorkers)
            {
                workersIterator.SendMessage(new RMessage(MessageType.ADD_QUESTION_REPLY, question));
            }
        }
    }
}
