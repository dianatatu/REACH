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
    /* Manages incoming messages for the Shelf module */
    public class ShelfCommander
    {
        /* 
         * Lets the Commander know when to call the MessageHandlers
         * in this class based on the value the corresponding
         * TriggerRule returns on the given Message.
         */
        public static void RegisterHandlers()
        {
            Commander.RegisterTriggerRule(GetDomainByName, GetDomainByNameRule);
            Commander.RegisterTriggerRule(GetDomainResources, GetDomainResourcesRule);
            Commander.RegisterTriggerRule(CheckUserDomainValidation, CheckUserDomainValidationRule);
            Commander.RegisterTriggerRule(GetResourceOwner, GetResourceOwnerRule);
            Commander.RegisterTriggerRule(PostResource, PostResourceRule);
            Commander.RegisterTriggerRule(EditResource, EditResourceRule);
            Commander.RegisterTriggerRule(DeleteResource, DeleteResourceRule);
            Commander.RegisterTriggerRule(CheckResourceVote, CheckResourceVoteRule);
            Commander.RegisterTriggerRule(ResourceVote, ResourceVoteRule);
            Commander.RegisterTriggerRule(ResourceAccess, ResourceAccessRule);
        }

        #region rules

        private static Boolean GetDomainByNameRule(RMessage message)
        {
            return message.Type == MessageType.GET_DOMAIN_BY_NAME_REQUEST;
        }

        private static Boolean GetDomainResourcesRule(RMessage message)
        {
            return message.Type == MessageType.GET_DOMAIN_RESOURCES_REQUEST;
        }

        /* The TriggerRule for the CheckUserDomainValidation MessageHandler 
         * The message must be of GET_USER_CERTIFIED_DOMAINS_REQUEST type to be 
         * handled by this MessageHandler.
         */
        private static Boolean CheckUserDomainValidationRule(RMessage message)
        {
            return message.Type == MessageType.GET_USER_CERTIFIED_DOMAINS_REQUEST;
        }

        /* The TriggerRule for the GetResourceOwner MessageHandler 
         * The message must be of GET_RESOURCE_OWNER_REQUEST type to be 
         * handled by this MessageHandler.
         */
        private static Boolean GetResourceOwnerRule(RMessage message)
        {
            return message.Type == MessageType.GET_RESOURCE_OWNER_REQUEST;
        }

        /* The TriggerRule for the PostResource MessageHandler 
         * The message must be of ADD_RESOURCE_REQUEST type to be 
         * handled by this MessageHandler.
         */
        private static Boolean PostResourceRule(RMessage message)
        {
            return message.Type == MessageType.ADD_RESOURCE_REQUEST;
        }

        /* The TriggerRule for the EditResource MessageHandler 
         * The message must be of EDIT_RESOURCE_REQUEST type to be 
         * handled by this MessageHandler.
         */
        private static Boolean EditResourceRule(RMessage message)
        {
            return message.Type == MessageType.EDIT_RESOURCE_REQUEST;
        }

        /* The TriggerRule for the DeleteResource MessageHandler 
         * The message must be of DELETE_RESOURCE_REQUEST type to be 
         * handled by this MessageHandler.
         */
        private static Boolean DeleteResourceRule(RMessage message)
        {
            return message.Type == MessageType.DELETE_RESOURCE_REQUEST;
        }

        /* The TriggerRule for the CheckResourceVote MessageHandler 
         * The message must be of RANK_CHECK_RESOURCE_VOTE_REQUEST type to be 
         * handled by this MessageHandler.
         */
        private static Boolean CheckResourceVoteRule(RMessage message)
        {
            return message.Type == MessageType.RANK_CHECK_RESOURCE_VOTE_REQUEST;
        }

        /* The TriggerRule for the ResourceVote MessageHandler 
         * The message must be of VOTE_RESOURCE_REQUEST type to be 
         * handled by this MessageHandler.
         */
        private static Boolean ResourceVoteRule(RMessage message)
        {
            return message.Type == MessageType.VOTE_RESOURCE_REQUEST;
        }

        /* The TriggerRule for the ResourceAccess MessageHandler 
         * The message must be of RANK_RESOURCE_ACCESSED_REQUEST type to be 
         * handled by this MessageHandler.
         */
        private static Boolean ResourceAccessRule(RMessage message)
        {
            return message.Type == MessageType.RANK_RESOURCE_ACCESSED_REQUEST;
        }

        #endregion

        #region handlers

        private static void GetDomainByName(RMessage message, TcpClient connection)
        {
            Console.WriteLine("GetDomainByName");
            DomainData domain = DomainConnector.GetDomainByName((String)message.Data);
            RMessage replyMessage = new RMessage(MessageType.GET_DOMAIN_BY_NAME_REPLY, domain);
            ServerCore.GetWorkerByConnection(connection).SendMessage(replyMessage);
        }

        private static void GetDomainResources(RMessage message, TcpClient connection)
        {
            Console.WriteLine("GetDomainResources");
            List<Object> resultContent = new List<Object>();
            resultContent.Add((Object)message.Data);
            resultContent.Add((Object)ResourceConnector.GetDomainResources((DomainData)message.Data));
            RMessage replyMessage = new RMessage(MessageType.GET_DOMAIN_RESOURCES_REPLY, resultContent);
            ServerCore.GetWorkerByConnection(connection).SendMessage(replyMessage);
        }

        /* The CheckUserDomainValidation MessageHandler 
         * It handles messages of GET_USER_CERTIFIED_DOMAINS_REQUEST type.
         */
        private static void CheckUserDomainValidation(RMessage message, TcpClient connection)
        {
            Console.WriteLine("GetUserDomainValidation");
            List<Object> resultContent = new List<Object>();
            resultContent.Add((Object)((UserData)message.Data));
            resultContent.Add((Object)DomainConnector.GetUserValidations(((UserData)message.Data).Id));
            RMessage replyMessage = new RMessage(MessageType.GET_USER_CERTIFIED_DOMAINS_REPLY, resultContent);
            ServerCore.GetWorkerByConnection(connection).SendMessage(replyMessage);
        }

        /* The GetResourceOwner MessageHandler 
         * It handles messages of GET_RESOURCE_OWNER type.
         */
        private static void GetResourceOwner(RMessage message, TcpClient connection)
        {
            Console.WriteLine("GetResourceOwner");
            List<Object> resultContent = new List<Object>();
            ResourceData res = (ResourceData)(((List<Object>)message.Data)[1]);
            resultContent.Add(((List<Object>)message.Data)[0]);
            resultContent.Add(((List<Object>)message.Data)[1]);
            resultContent.Add(UserConnector.GetUser(res.Owner));
            RMessage replyMessage = new RMessage(MessageType.GET_RESOURCE_OWNER_REPLY, resultContent);
            ServerCore.GetWorkerByConnection(connection).SendMessage(replyMessage);
        }

        /* The PostResource MessageHandler 
         * It handles messages of ADD_RESOURCE_REQUEST type.
         */
        private static void PostResource(RMessage message, TcpClient connection)
        {
            Console.WriteLine("PostResource");
            ResourceConnector.AddResource((ResourceData)message.Data);
            // a lil' something for the user
            UserConnector.UpdateUserRank(ServerCore.GetIdByConnection(connection), Ranking.USER_POSTED_RESOURCE_VALUE);

            ResourceData adddedResource = ResourceConnector.GetResource((ResourceData)message.Data);
            RMessage replyMessage = new RMessage(MessageType.ADD_RESOURCE_REPLY, adddedResource);
            List<ClientWorker> clientList = ServerCore.GetAllWorkers();
            foreach (ClientWorker client in clientList)
                client.SendMessage(replyMessage);
        }

        /* The EditResource MessageHandler 
         * It handles messages of EDIT_RESOURCE_REQUEST type.
         */
        private static void EditResource(RMessage message, TcpClient connection)
        {
            Console.WriteLine("EditResource");
            ResourceData res = (ResourceData)message.Data;
            ResourceConnector.EditResource(res);
            ResourceData editedResource = ResourceConnector.GetResource(res.Id);
            RMessage replyMessage = new RMessage(MessageType.EDIT_RESOURCE_REPLY, editedResource);
            List<ClientWorker> clientList = ServerCore.GetAllWorkers();
            foreach (ClientWorker client in clientList)
                client.SendMessage(replyMessage);
        }

        /* The DeleteResource MessageHandler 
         * It handles messages of DELETE_RESOURCE_REQUEST type.
         */
        private static void DeleteResource(RMessage message, TcpClient connection)
        {
            Console.WriteLine("DeleteResource");
            ResourceConnector.DeleteResource((ResourceData)message.Data);
            RMessage replyMessage = new RMessage(MessageType.DELETE_RESOURCE_REPLY, (ResourceData)message.Data);
            List<ClientWorker> clientList = ServerCore.GetAllWorkers();
            foreach (ClientWorker client in clientList)
                client.SendMessage(replyMessage);
        }

        /* The CheckResourceVote MessageHandler 
         * It handles messages of RANK_CHECK_RESOURCE_VOTE_REQUEST type.
         */
        private static void CheckResourceVote(RMessage message, TcpClient connection)
        {
            Console.WriteLine("CheckResourceVote");
            UserData usr = (UserData)(((List<Object>)message.Data)[0]);
            ResourceData res = (ResourceData)(((List<Object>)message.Data)[1]);
            ResourceVoteData resVote = ResourceVoteConnector.CheckResourceVote(usr, res);
            List<Object> replyContent = new List<Object>();
            replyContent.Add(usr);
            replyContent.Add(res);
            replyContent.Add(resVote);
            RMessage replyMessage = new RMessage(MessageType.RANK_CHECK_RESOURCE_VOTE_REPLY, replyContent);
            ServerCore.GetWorkerByConnection(connection).SendMessage(replyMessage);
        }

        /* The ResourceVote MessageHandler 
         * It handles messages of VOTE_RESOURCE_REQUEST type.
         */
        private static void ResourceVote(RMessage message, TcpClient connection)
        {
            Console.WriteLine("VoteResource");
            ResourceVoteData resVote = (ResourceVoteData)message.Data;

            ResourceVoteData oldResVote = ResourceVoteConnector.UpdateVote(resVote);
            ResourceConnector.VoteResource(oldResVote, resVote);
            UserConnector.UpdateUserRank(ServerCore.GetIdByConnection(connection), Ranking.USER_VOTED_RESOURCE_VALUE);

            ResourceData editedResource = ResourceConnector.GetResource(resVote.Id_Resource);

            RMessage replyMessage = new RMessage(MessageType.EDIT_RESOURCE_REPLY, editedResource);
            List<ClientWorker> clientList = ServerCore.GetAllWorkers();
            foreach (ClientWorker client in clientList)
                client.SendMessage(replyMessage);
        }

        /* The ResourceAccess MessageHandler 
         * It handles messages of RANK_RESOURCE_ACCESSED_REQUEST type.
         */
        private static void ResourceAccess(RMessage message, TcpClient connection)
        {
            Console.WriteLine("AccessResource");
            ResourceData res = (ResourceData)message.Data;
            ResourceConnector.UpdateResourceRank(res, Ranking.RESOURCE_ACCESSED_VALUE);

            ResourceData editedResource = ResourceConnector.GetResource(res.Id);

            RMessage replyMessage = new RMessage(MessageType.EDIT_RESOURCE_REPLY, editedResource);
            List<ClientWorker> clientList = ServerCore.GetAllWorkers();
            foreach (ClientWorker client in clientList)
                client.SendMessage(replyMessage);
        }

        #endregion

    }
}
