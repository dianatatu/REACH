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
    /* Manages incoming messages for the QuestionList module */
    public class QuestionListCommander
    {
        /* 
         * Lets the Commander know when to call the MessageHandlers
         * in this class based on the value the corresponding
         * TriggerRule returns on the given Message.
         */
        public static void RegisterHandlers()
        {
            Commander.RegisterTriggerRule(GetAllQuestions, GetAllQuestionsRule);
            Commander.RegisterTriggerRule(GetDomainQuestions, GetDomainQuestionsRule);
        }

        /* The TriggerRule for the GetAllQuestions MessageHandler 
         * The message must be of GET_ALL_QUESTIONS_REQUEST type to be 
         * handled by this MessageHandler.
         */
        private static Boolean GetAllQuestionsRule(RMessage message)
        {
            return message.Type == MessageType.GET_ALL_QUESTIONS_REQUEST;
        }
        
        /* The GetAllQuestions MessageHandler 
         * It handles messages of GET_ALL_QUESTIONS_REQUEST type.
         */
        private static void GetAllQuestions(RMessage message, TcpClient connection)
        {
            Console.WriteLine("GetAllQuestions");
            List<QuestionData> questions = QuestionConnector.GetAllQuestions();
            RMessage replyMessage = new RMessage(MessageType.GET_ALL_QUESTIONS_REPLY, questions);
            ServerCore.GetWorkerByConnection(connection).SendMessage(replyMessage);
        }


        /* The TriggerRule for the GetDomainQuestions MessageHandler 
         * The message must be of GET_DOMAIN_QUESTIONS_REQUEST type to be 
         * handled by this MessageHandler.
         */
        private static Boolean GetDomainQuestionsRule(RMessage message)
        {
            return message.Type == MessageType.GET_DOMAIN_QUESTIONS_REQUEST;
        }

        /* The GetDomainQuestions MessageHandler 
         * It handles messages of GET_DOMAIN_QUESTIONS_REQUEST type.
         */
        private static void GetDomainQuestions(RMessage message, TcpClient connection)
        {
            Console.WriteLine("GetDomainQuestions");
            List<QuestionData> questions = QuestionConnector.GetDomainQuestions((DomainData)message.Data);
            RMessage replyMessage = new RMessage(MessageType.GET_DOMAIN_QUESTIONS_REPLY, questions);
            ServerCore.GetWorkerByConnection(connection).SendMessage(replyMessage);
        }
    }
}
