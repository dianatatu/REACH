using System;
using System.Collections.Generic;

using REACH.Common.Data;
using REACH.Server.Base;

namespace REACH.Server.Connectors
{
    public class ResourceVoteConnector : ConnectorBase<ResourceVoteData>
    {

        public static ResourceVoteData CheckResourceVote(UserData usr, ResourceData res)
        {
            String query = "SELECT * FROM resource_vote " +
                            "WHERE id_resource = " + res.Id +
                            " AND id_user = " + usr.Id + ";";
            ResourceVoteData ret = (ResourceVoteData)GetSingleItem(query);
            if (ret != null)
                return ret;
            else
                return new ResourceVoteData(res.Id, usr.Id, 0);
        }

        public static ResourceVoteData UpdateVote(ResourceVoteData resVote)
        {
            String query = "SELECT * FROM resource_vote " +
                            "WHERE id_resource = " + resVote.Id_Resource + " " +
                            "AND id_user = " + resVote.Id_User + ";";

            ResourceVoteData presentVote = GetSingleItem(query);

            if (presentVote == null)
            {
                query = "INSERT INTO resource_vote " +
                        "VALUES (" + resVote.Id_Resource + "," + resVote.Id_User + "," + resVote.Value + ");";
                GetNoItems(query);
            }
            else
            {
                query = "UPDATE resource_vote " +
                        "SET value_resource_vote = " + resVote.Value + " " +
                        "WHERE id_resource = " + resVote.Id_Resource + " AND id_user = " + resVote.Id_User + ";";
                GetNoItems(query);
            }

            return presentVote;

        }

    }
}
