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
    /* Manages incoming messages for the FriendList module */
    public class FriendListCommander
    {
        /* 
         * Lets the Commander know when to call the MessageHandlers
         * in this class based on the value the corresponding
         * TriggerRule returns on the given Message.
         */
        public static void RegisterHandlers()
        {
            Commander.RegisterTriggerRule(GetFriendList, GetFriendListRule);
            Commander.RegisterTriggerRule(GetAllFriendships, GetAllFriendshipsRule);
            Commander.RegisterTriggerRule(ChangeUserState, ChangeUserStateRule);
            Commander.RegisterTriggerRule(UpdateFriendship, UpdateFriendshipRule);
            Commander.RegisterTriggerRule(AddFriend, AddFriendRule);  
        }

        /*
         * Register all the actions taken when a connection crashes
         */
        public static void RegisterCrashActions()
        {
            Commander.RegisterCrashAction(MakeUserOffline);
        }

        /*
         * On connection crash, makes the user offline
         */
        private static void MakeUserOffline(TcpClient connection)
        {
            uint id = ServerCore.GetIdByConnection(connection);
            UserData user = UserConnector.UpdateUserState(id, false);
            List<UserData> friendList = UserConnector.GetFriendList(id);
            RMessage replyMessage = new RMessage(MessageType.CHANGE_USER_STATE_REPLY, user);
            foreach (UserData friend in friendList)
            {
                ClientWorker worker = ServerCore.GetWorkerById(friend.Id);
                if (worker != null)
                    ServerCore.GetWorkerById(friend.Id).SendMessage(replyMessage);
            }
        }

        /* The TriggerRule for the AddFriend MessageHandler 
        * The message must be of ADD_FRIEND_REQ type to be 
        * handled by this MessageHandler.
        */
        private static Boolean AddFriendRule(RMessage message)
        {
            return message.Type == MessageType.ADD_FRIEND_REQUEST;
        }

        /* The GetFriendList MessageHandler 
         * It handles messages of ADD_FRIEND_REQ type.
         */
        private static void AddFriend(RMessage message, TcpClient connection)
        {
            Console.WriteLine("AddFriend");
            uint thisUserId = ServerCore.GetIdByConnection(connection);
            UserData friend = UserConnector.GetUser((String)message.Data);
            UserData thisUser = UserConnector.GetUser(thisUserId);
            if(friend == null) 
                return;
            if (friend.Id == thisUserId)
                return;            
            List<FriendshipData> friendships = FriendshipConnector.GetFriendshipList(thisUserId);
            foreach(FriendshipData friendshipIt in friendships)
                if (friendshipIt.Former == friend.Id || friendshipIt.Latter == friend.Id)
                    return;                
            FriendshipData friendship = new FriendshipData(thisUserId, friend.Id, false);
            FriendshipConnector.AddFriendship(friendship);

            ClientWorker formerWorker = ServerCore.GetWorkerById(friendship.Former);
			ClientWorker latterWorker = ServerCore.GetWorkerById(friendship.Latter);

            RMessage replyMessageFormer = new RMessage(MessageType.ADD_FRIEND_REPLY, friend);
            RMessage replyMessageLatter = new RMessage(MessageType.ADD_FRIEND_REPLY, thisUser);            
            RMessage replyMessage = new RMessage(MessageType.ADD_FRIENDSHIP_REPLY, friendship);

            if (formerWorker != null)
            {
                formerWorker.SendMessage(replyMessageFormer);
                formerWorker.SendMessage(replyMessage);
            }
            if (latterWorker != null) {
                latterWorker.SendMessage(replyMessageLatter);
                latterWorker.SendMessage(replyMessage);
            }
        }

        /* The TriggerRule for the UpdateFriendship MessageHandler 
         * The message must be of UPDATE_FRIENDSHIP_REQ type to be 
         * handled by this MessageHandler.
         */
        private static Boolean UpdateFriendshipRule(RMessage message)
        {
            return message.Type == MessageType.UPDATE_FRIENDSHIP_REQ;
        }

        /* The GetFriendList MessageHandler 
         * It handles messages of UPDATE_FRIENDSHIP_REQ type.
         */
        private static void UpdateFriendship(RMessage message, TcpClient connection)
        {
            Console.WriteLine("UpdateFriendship");
            FriendshipData friendship = (FriendshipData)message.Data;
            RMessage replyMessageFormer, replyMessageLatter;
            if (friendship.Status)
            {
                FriendshipConnector.ConfirmFriendship(friendship);
                replyMessageFormer = new RMessage(MessageType.CONFIRM_FRIENDSHIP_REPLY, friendship.Latter);
                replyMessageLatter = new RMessage(MessageType.CONFIRM_FRIENDSHIP_REPLY, friendship.Former);
                UserConnector.UpdateUserRank(friendship.Latter, Ranking.ADD_FRIEND);
                UserConnector.UpdateUserRank(friendship.Former, Ranking.ADD_FRIEND);
            } else {
                FriendshipConnector.DeleteFriendship(friendship);
                replyMessageFormer = new RMessage(MessageType.DENY_FRIENDSHIP_REPLY, friendship.Latter);
                replyMessageLatter = new RMessage(MessageType.DENY_FRIENDSHIP_REPLY, friendship.Former);
            }
			ClientWorker formerWorker = ServerCore.GetWorkerById(friendship.Former);
            if (formerWorker != null)
                formerWorker.SendMessage(replyMessageFormer);
			ClientWorker latterWorker = ServerCore.GetWorkerById(friendship.Latter);
            if (latterWorker != null)
                latterWorker.SendMessage(replyMessageLatter);
        }

        /* The TriggerRule for the GetFriendList MessageHandler 
         * The message must be of GET_ALL_FRIENDS_REQUEST type to be 
         * handled by this MessageHandler.
         */
        private static Boolean GetFriendListRule(RMessage message)
        {
            return message.Type == MessageType.GET_ALL_FRIENDS_REQUEST;
        }

        /* The GetFriendList MessageHandler 
         * It handles messages of GET_ALL_FRIENDS_REQUEST type.
         */
        private static void GetFriendList(RMessage message, TcpClient connection)
        {
            Console.WriteLine("GetFriendList");
			List<UserData> friendlist = UserConnector.GetFriendList(ServerCore.GetIdByConnection(connection));
            RMessage replyMessage = new RMessage(MessageType.GET_ALL_FRIENDS_REPLY, friendlist);
			ServerCore.GetWorkerByConnection(connection).SendMessage(replyMessage);
        }

        /* The TriggerRule for the GetAllFriendships MessageHandler 
        * The message must be of GET_ALL_FRIENDSHIPS_REQUEST type to be 
        * handled by this MessageHandler.
        */
        private static Boolean GetAllFriendshipsRule(RMessage message)
        {
            return message.Type == MessageType.GET_ALL_FRIENDSHIPS_REQUEST;
        }

        /* The GetFriendList MessageHandler 
         * It handles messages of GET_ALL_FRIENDSHIPS_REQUEST type.
         */
        private static void GetAllFriendships(RMessage message, TcpClient connection)
        {
            Console.WriteLine("GetAllFriendships");
			List<FriendshipData> friendlist = FriendshipConnector.GetFriendshipList(ServerCore.GetIdByConnection(connection));
            RMessage replyMessage = new RMessage(MessageType.GET_ALL_FRIENDSHIPS_REPLY, friendlist);
			ServerCore.GetWorkerByConnection(connection).SendMessage(replyMessage);
        }

        /* The TriggerRule for the ChangeUserState MessageHandler 
         * The message must be of CHANGE_USER_STATE_REQUEST type to be 
         * handled by this MessageHandler.
         */
        private static Boolean ChangeUserStateRule(RMessage message)
        {
            return message.Type == MessageType.CHANGE_USER_STATE_REQUEST;
        }

        /* The GetFriendList MessageHandler 
         * It handles messages of CHANGE_USER_STATE_REQUEST type.
         */
        private static void ChangeUserState(RMessage message, TcpClient connection)
        {
            Console.WriteLine("ChangeUserState");
			uint id = ServerCore.GetIdByConnection(connection);
            UserData user = UserConnector.UpdateUserState(id,(bool)message.Data);
            List<UserData> friendList = UserConnector.GetFriendList(id);
            RMessage replyMessage = new RMessage(MessageType.CHANGE_USER_STATE_REPLY,user);
            foreach (UserData friend in friendList)
            {
				ClientWorker worker = ServerCore.GetWorkerById(friend.Id);
                if(worker!=null)
					ServerCore.GetWorkerById(friend.Id).SendMessage(replyMessage);
            }
			ServerCore.GetWorkerByConnection(connection).SendMessage(replyMessage);
        }
    }
}
