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
    /* Manages incoming messages for the Question module */
    public class QuestionCommander
    {
        /* 
         * Lets the Commander know when to call the MessageHandlers
         * in this class based on the value the corresponding
         * TriggerRule returns on the given Message.
         */
        public static void RegisterHandlers() {            
            Commander.RegisterTriggerRule(GetQuestion, GetQuestionRule);
            Commander.RegisterTriggerRule(GetQuestionDomains, GetQuestionDomainsRule);
            Commander.RegisterTriggerRule(GetUserById, GetUserByIdRule);
            Commander.RegisterTriggerRule(ChangeQuestionStatus, ChangeQuestionStatusRule);
            Commander.RegisterTriggerRule(AddAnswer, AddAnswerRule);
            Commander.RegisterTriggerRule(GetAnswers, GetAnswersRule);
            Commander.RegisterTriggerRule(GetResources, GetResourcesRule);
            Commander.RegisterTriggerRule(GetQuestionResources, GetQuestionResourcesRule);
            Commander.RegisterTriggerRule(AddReference, AddReferenceRule);
            Commander.RegisterTriggerRule(CheckUserVote, CheckUserVoteRule);
            Commander.RegisterTriggerRule(AddUserVote, AddUserVoteRule);
        }

        /* The TriggerRule for the AddUserVote MessageHandler 
         * The message must be of ADD_USER_VOTE_REQUEST type to be 
         * handled by this MessageHandler.
         */
        private static Boolean AddUserVoteRule(RMessage message)
        {
            return message.Type == MessageType.ADD_USER_VOTE_REQUEST;
        }

        /* The AddUserVote MessageHandler 
         * It handles messages of ADD_USER_VOTE_REQUEST type.
         */
        private static void AddUserVote(RMessage message, TcpClient connection)
        {
            Console.WriteLine("AddUserVote");
            // Get the vote data from the message
            UserVoteData vote = (UserVoteData)message.Data;

            // Update the voter's rank
            UserVoteData rating = UserVoteConnector.CheckUserVote(vote);
            if (rating == null)
                UserConnector.UpdateUserRank(vote.Id_voter_user, Ranking.VOTE_USER);

            // Update the votee's rank
            UserConnector.VoteUser(vote);

            // Send the vote back to the client
            RMessage replyMessage = new RMessage(MessageType.ADD_USER_VOTE_REPLY, vote);
            ServerCore.GetWorkerByConnection(connection).SendMessage(replyMessage);

            // Send the updated user rank to all clients
            UserData user = UserConnector.GetUserById(vote.Id_votee_user);
            replyMessage = new RMessage(MessageType.RANK_USER_UPDATED, user);
            List<ClientWorker> allWorkers = ServerCore.GetAllWorkers();
            foreach (ClientWorker workersIterator in allWorkers)
            {
                workersIterator.SendMessage(replyMessage);
            }
        }


        /* The TriggerRule for the GetQuestion MessageHandler 
         * The message must be of GET_ALL_QUESTIONS_REQUEST type to be 
         * handled by this MessageHandler.
         */
        private static Boolean GetQuestionRule(RMessage message)
        {
            return message.Type == MessageType.GET_QUESTION_REQUEST;
        }

        /* The GetQuestion MessageHandler 
         * It handles messages of GET_QUESTION_REQUEST type.
         */
        private static void GetQuestion(RMessage message, TcpClient connection)
        {
            Console.WriteLine("GetQuestion");
            QuestionData question = QuestionConnector.GetQuestion((UInt32)(message.Data));
            RMessage replyMessage = new RMessage(MessageType.GET_QUESTION_REPLY, question);
            ServerCore.GetWorkerByConnection(connection).SendMessage(replyMessage);
        }

        /* The TriggerRule for the GetQuestionDomains MessageHandler 
         * The message must be of GET_QUESTION_DOMAINS_REQUEST type to be 
         * handled by this MessageHandler.
         */
        private static Boolean GetQuestionDomainsRule(RMessage message)
        {
            return message.Type == MessageType.GET_QUESTION_DOMAINS_REQUEST;
        }

        /* The GetQuestionDomains MessageHandler 
         * It handles messages of GET_QUESTION_DOMAINS_REQUEST type.
         */
        private static void GetQuestionDomains(RMessage message, TcpClient connection)
        {
            Console.WriteLine("GetQuestionDomains");
            List<DomainData> domains = DomainConnector.GetQuestionDomains((QuestionData)message.Data);
            RMessage replyMessage = new RMessage(MessageType.GET_QUESTION_DOMAINS_REPLY, domains);
            ServerCore.GetWorkerByConnection(connection).SendMessage(replyMessage);
        }

        /* The TriggerRule for the GetUserById MessageHandler 
         * The message must be of GET_USER_BY_ID_REQUEST type to be 
         * handled by this MessageHandler.
         */
        private static Boolean GetUserByIdRule(RMessage message)
        {
            return message.Type == MessageType.GET_USER_BY_ID_REQUEST;
        }

        /* The GetUserById MessageHandler 
         * It handles messages of GET_USER_BY_ID_REQUEST type.
         */
        private static void GetUserById(RMessage message, TcpClient connection)
        {
            Console.WriteLine("GetUserById");
            UserData user = UserConnector.GetUser((UInt32)message.Data);
            RMessage replyMessage = new RMessage(MessageType.GET_USER_BY_ID_REPLY, user);
            ServerCore.GetWorkerByConnection(connection).SendMessage(replyMessage);
        }

        /* The TriggerRule for the ChangeQuestionStatus MessageHandler 
         * The message must be of CHANGE_QUESTION_STATUS_REQUEST type to be 
         * handled by this MessageHandler.
         */
        private static Boolean ChangeQuestionStatusRule(RMessage message)
        {
            return message.Type == MessageType.CHANGE_QUESTION_STATUS_REQUEST;
        }

        /* The ChangeQuestionStatus MessageHandler 
         * It handles messages of CHANGE_QUESTION_STATUS_REQUEST type.
         */
        private static void ChangeQuestionStatus(RMessage message, TcpClient connection)
        {
            Console.WriteLine("ChangeQuestionStatus");
            QuestionData question = QuestionConnector.ChangeQuestionStatus(((QuestionData)message.Data).Id);
            RMessage replyMessage = new RMessage(MessageType.CHANGE_QUESTION_STATUS_REPLY, question);

            List<ClientWorker> allWorkers = ServerCore.GetAllWorkers();
            foreach (ClientWorker workersIterator in allWorkers)
            {
                workersIterator.SendMessage(replyMessage);
            }
        }

        private static Boolean AddAnswerRule(RMessage message)
        {
            return message.Type == MessageType.ADD_ANSWER_REQUEST;
        }

        private static void AddAnswer(RMessage message, TcpClient connection)
        {
            Console.WriteLine("ChangeQuestionStatus");
            AnswerData answer = (AnswerData)message.Data;
            LogConnector.AddAnswer(answer);
            UserConnector.UpdateUserRank(answer.Owner, Ranking.ADD_ANSWER);
            foreach (ClientWorker workersIterator in ServerCore.GetAllWorkers())
            {
                workersIterator.SendMessage(new RMessage(MessageType.ADD_ANSWER_REPLY, answer));
            }
        }

        private static Boolean GetAnswersRule(RMessage message)
        {
            return message.Type == MessageType.GET_QUESTION_ANSWERS_REQUEST;
        }

        private static void GetAnswers(RMessage message, TcpClient connection)
        {
            Console.WriteLine("GetAnswers");
            UInt32 questionId = (UInt32)message.Data;
            List<AnswerData> answers = LogConnector.GetQuestionAnswers(questionId);

            List<UserData> users = new List<UserData>();
            for (int i=0; i<answers.Count; i++)
                users.Add(UserConnector.GetUser(answers[i].Owner));

            List<Object> data = new List<Object>();
            data.Add(answers);
            data.Add(users);
            RMessage replyMessage = new RMessage(MessageType.GET_QUESTION_ANSWERS_REPLY, data);
            ServerCore.GetWorkerByConnection(connection).SendMessage(replyMessage);
        }
        
        
        /* The TriggerRule for the GetResources MessageHandler 
         * The message must be of GET_QUESTION_RESOURCES_REQUEST type to be 
         * handled by this MessageHandler.
         */
        private static Boolean GetResourcesRule(RMessage message)
        {
            return message.Type == MessageType.GET_QUESTION_DOMAINS_RESOURCES_REQUEST;
        }

        /* The GetResources MessageHandler 
         * It handles messages of GET_QUESTION_RESOURCES_REQUEST type.
         */
        private static void GetResources(RMessage message, TcpClient connection)
        {
            Console.WriteLine("GetResources");
            List<DomainData> domains = (List<DomainData>)message.Data;
            List<ResourceData> resources = new List<ResourceData>();
            
            for (int i = 0; i < domains.Count; i++)
            {
                List<ResourceData> res = ResourceConnector.GetDomainResources(domains[i]);
                for (int j = 0; j < res.Count; j++)
                    resources.Add(res[j]);
            }

            RMessage replyMessage = new RMessage(MessageType.GET_QUESTION_DOMAINS_RESOURCES_REPLY, resources);
            ServerCore.GetWorkerByConnection(connection).SendMessage(replyMessage);
        }

        /* The TriggerRule for the GetQuestionResources MessageHandler 
         * The message must be of GET_QUESTION_RESOURCES_REQUEST type to be 
         * handled by this MessageHandler.
         */
        private static Boolean GetQuestionResourcesRule(RMessage message)
        {
            return message.Type == MessageType.GET_QUESTION_RESOURCES_REQUEST;
        }

        /* The GetQuestionResources MessageHandler 
         * It handles messages of GET_QUESTION_RESOURCES_REQUEST type.
         */
        private static void GetQuestionResources(RMessage message, TcpClient connection)
        {
            Console.WriteLine("GetQuestionResources");
            QuestionData question = (QuestionData)message.Data;
            List<ResourceData> resources = ResourceConnector.GetQuestionResources(question.Id);
            
            RMessage replyMessage = new RMessage(MessageType.GET_QUESTION_RESOURCES_REPLY, resources);
            ServerCore.GetWorkerByConnection(connection).SendMessage(replyMessage);
        }

        /* The TriggerRule for the AddReference MessageHandler 
         * The message must be of ADD_REFERENCE_REQUEST type to be 
         * handled by this MessageHandler.
         */
        private static Boolean AddReferenceRule(RMessage message)
        {
            return message.Type == MessageType.ADD_QUESTION_REFERENCE_REQUEST;
        }

        /* The AddReference MessageHandler 
         * It handles messages of ADD_REFERENCE_REQUEST type.
         */
        private static void AddReference(RMessage message, TcpClient connection)
        {
            Console.WriteLine("AddReference");
            List<UInt32> ids = (List<UInt32>)message.Data;

            QuestionConnector.AddReference(ids);

            RMessage replyMessage = new RMessage(MessageType.ADD_QUESTION_REFERENCE_REPLY, null);
            //ServerCore.GetWorkerByConnection(connection).SendMessage(replyMessage);

            List<ClientWorker> allWorkers = ServerCore.GetAllWorkers();
            foreach (ClientWorker workersIterator in allWorkers)
            {
                workersIterator.SendMessage(replyMessage);
            }
        }

        /* The TriggerRule for the CheckUserVote MessageHandler 
         * The message must be of CHECK_USER_VOTE_REQUEST type to be 
         * handled by this MessageHandler.
         */
        private static Boolean CheckUserVoteRule(RMessage message)
        {
            return message.Type == MessageType.CHECK_USER_VOTE_REQUEST;
        }

        /* The CheckUserVote MessageHandler 
         * It handles messages of CHECK_USER_VOTE_REQUEST type.
         */
        private static void CheckUserVote(RMessage message, TcpClient connection)
        {
            Console.WriteLine("CheckUserVote");
            UserVoteData userVote = (UserVoteData)message.Data;
            UserVoteData rating = UserVoteConnector.CheckUserVote(userVote);
            RMessage replyMessage;
            replyMessage = new RMessage(MessageType.CHECK_USER_VOTE_REPLY, rating);
            ServerCore.GetWorkerByConnection(connection).SendMessage(replyMessage);
        }


      }
}
