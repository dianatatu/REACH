using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

using REACH.Common.Data;
using REACH.Server;
using REACH.Server.Base;

namespace REACH.Server.Connectors
{
    public class ResourceConnector : ConnectorBase<ResourceData>
    {

        public static List<ResourceData> GetDomainResources(DomainData Domain)
        {
            string query = "SELECT * FROM resource " +
                            "WHERE id_domain = " + Domain.ID + ";";
            return GetAllItems(query);
        }

        internal static void AddResource(ResourceData res)
        {
            String query = "INSERT INTO `reach`.`resource` (" +
                            "`owner_user` ," +
                            "`id_domain` ," +
                            "`timestamp_resource` ," +
                            "`title_resource` ," +
                            "`description_resource` ," +
                            "`links_resource` ," +
                            "`category_resource` ," +
                            "`rank_resource`" +
                            ") VALUES (" +
                            "'" + res.Owner + "', " +
                            "'" + res.Domain + "', " +
                            "CURRENT_TIMESTAMP, " +
                            "@Title, " +
                            "@Description," +
                            "@Links," +
                            "'" + res.Category + "'," +
                            "'" + res.Rank + "');";
            MySqlCommand command = GetCommand();
            command.CommandText = query;
            command.Parameters.Add(new MySqlParameter("@Title", res.Title.ToString()));
            command.Parameters.Add(new MySqlParameter("@Description", res.Description.ToString()));
            command.Parameters.Add(new MySqlParameter("@Links", res.Links.ToString()));
            GetNoItems(command);
         }

        internal static void EditResource(ResourceData res)
        {
            String query = "UPDATE resource " +
                            "SET description_resource = @Description, " +
                            "links_resource = @Links " +
                            "WHERE id_resource = " + res.Id + " ;";
            MySqlCommand command = GetCommand();
            command.CommandText = query;
            command.Parameters.Add(new MySqlParameter("@Description", res.Description.ToString()));
            command.Parameters.Add(new MySqlParameter("@Links", res.Links.ToString()));
            GetNoItems(command);
        }

        public static ResourceData GetResource(ResourceData res)
        {
            String query = "SELECT * FROM resource " + 
                            "WHERE owner_user = " + res.Owner + " AND " +
                            "id_domain = " + res.Domain + " AND " +
                            "description_resource = @Description AND " +
                            "title_resource = @Title;";
            MySqlCommand command = GetCommand();
            command.CommandText = query;
            command.Parameters.Add(new MySqlParameter("@Description", res.Description.ToString()));
            command.Parameters.Add(new MySqlParameter("@Title", res.Title.ToString()));
            return GetSingleItem(command);
        }

        public static ResourceData GetResource(UInt32 id)
        {
            String query = "SELECT * FROM resource " + 
                            "WHERE id_resource = " + id + " ;" ;
            return GetSingleItem(query);
        }

        internal static void DeleteResource(ResourceData resource)
        {
            // delete all references from ResourceVote
            String query = "DELETE FROM resource_vote " +
                            "WHERE id_resource = " + resource.Id + ";";
            GetNoItems(query);

            // delete all references from QuestionResource
            query = "DELETE FROM question_resource " +
                    "WHERE id_resource = " + resource.Id + ";";

            GetNoItems(query);

            query = "DELETE FROM resource " +
                    "WHERE id_resource = " + resource.Id + ";";
            GetNoItems(query);
        }

        public static void VoteResource(ResourceVoteData oldResVote, ResourceVoteData resVote)
        {
            ResourceData res = GetResource(resVote.Id_Resource);
            double adjustment = 0;
            
            if (oldResVote != null)
            {
                if (oldResVote.Value < 3)
                    adjustment += (double)(3 - oldResVote.Value) * Ranking.RESOURCE_VOTE_POINT_VALUE;
                else
                    adjustment += -(double)(oldResVote.Value - 2) * Ranking.RESOURCE_VOTE_POINT_VALUE;
            }
            if (resVote.Value < 3)
                adjustment += - (double)(3 - resVote.Value) * Ranking.RESOURCE_VOTE_POINT_VALUE;
            else
                adjustment += (double)(resVote.Value - 2) * Ranking.RESOURCE_VOTE_POINT_VALUE;

            UpdateResourceRank(res, adjustment);
        }

        public static void UpdateResourceRank(ResourceData resource, double value)
        {
            ResourceData res = GetResource(resource.Id);
            double rnk = res.Rank;
            rnk += value;
            String query = "UPDATE resource SET rank_resource = @Rank WHERE id_resource = " + res.Id + ";";
            MySqlCommand command = GetCommand();
            command.CommandText = query;
            command.Parameters.Add(new MySqlParameter("@Rank", rnk));
            GetNoItems(command);
        }

        public static List<ResourceData> GetQuestionResources(UInt32 id)
        {
            String query = "SELECT a.* " + 
                            "FROM resource a, question_resource b " +
                            "WHERE b.id_question=" + id + " " + 
                            "AND a.id_resource = b.id_resource" + ";";
            return GetAllItems(query);
        }
    }
}
