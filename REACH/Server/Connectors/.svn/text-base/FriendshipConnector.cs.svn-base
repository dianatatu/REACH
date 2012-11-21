using System;
using System.Collections.Generic;

using REACH.Common.Data;
using REACH.Server.Base;

namespace REACH.Server.Connectors
{
    public class FriendshipConnector : ConnectorBase<FriendshipData>
    {
        public static List<FriendshipData> GetFriendshipList(UInt32 id)
        {
            String query = "select * from friendship where ("+id+
            " = id_former_user) or ("+id+" = id_latter_user);";
            return GetAllItems(query);
        }

        public static void DeleteFriendship(FriendshipData friendship)
        {
            String query = "delete from friendship where (" + friendship.Former +
            " = id_former_user) and (" + friendship.Latter + " = id_latter_user);";
			GetNoItems(query);		
        }

        public static void ConfirmFriendship(FriendshipData friendship)
        {
            String query = "update friendship set status_friendship=true where (" + friendship.Former +
            " = id_former_user) and (" + friendship.Latter + " = id_latter_user);";
            GetNoItems(query);
        }

        internal static void AddFriendship(FriendshipData friendship)
        {
            int intValue;
            if(friendship.Status)
                intValue = 1;
            else
                intValue = 0;
            String query = "INSERT INTO  `reach`.`friendship` (" +
                    "`id_former_user` ," +
                    "`id_latter_user` ," +
                    "`status_friendship`" +
                    ")" +
                    "VALUES (" +
                    "'" + friendship.Former + "',  '" + friendship.Latter + "',  '" + intValue + "'" +
                    ");";
            GetNoItems(query);
        }
    }
}
