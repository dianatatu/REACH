using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

using REACH.Common.Data;
using REACH.Server.Base;

namespace REACH.Server.Connectors
{
    public class QuestionConnector : ConnectorBase<QuestionData>
    {
        public static List<QuestionData> GetAllQuestions()
        {
            String query = "select * from Question;";
            return GetAllItems(query);
        }

        public static List<QuestionData> GetDomainQuestions(DomainData dd)
        {
            String query =  "select a.* " +
                            "from question a, domain_question b " +
                            "where b.id_domain=" + dd.ID + 
                            " and b.id_question = a.id_question;";
            return GetAllItems(query);
        }

        public static QuestionData GetQuestion(UInt32 id)
        {
            String query = "select * from Question where id_question = " + id + ";";
            return GetSingleItem(query);
        }

        public static void AddQuestion(QuestionData question)
        {
            String query;
            query = "insert into question (" +
                            "`id_question` ," +
                            "`owner_user` ," +
                            "`timestamp_question` ," +
                            "`title_question` ," +
                            "`content_question` ," +
                            "`status_question`" +
                            ") values (" + 
                            "'NULL'," +
                            question.Owner +
                            ",now()," +
                            "@Title," +
                            "@Content," +
                            question.Status +
                            ");";
            MySqlCommand command = GetCommand();
            command.CommandText = query;
            command.Parameters.Add(new MySqlParameter("@Title",question.Title.ToString()));
            command.Parameters.Add(new MySqlParameter("@Content", question.Content.ToString()));
            GetNoItems(command);
        }

        public static void AddDomainQuestion(uint questionId, List<DomainData> domains)
        {
            String query;

            for (int i = 0; i < domains.Count; i++)
            {
                query = "insert into domain_question (" +
                                "`id_question` ," +
                                "`id_domain` " +
                                ") values ('" + questionId + "', '" + domains[i].ID + "');";

                GetNoItems(query);
            }
        }

        public static QuestionData ChangeQuestionStatus(UInt32 id)
        {
            String query;

            query = "update question set status_question = 1 - status_question where id_question = " + id + ";";
            GetNoItems(query);

            query = "select * from question where id_question = " + id + ";";
            return GetSingleItem(query);
        }

        public static void AddReference(List<UInt32> ids)
        {
            for (int i = 1; i < ids.Count; i++)
            {
                String query = "insert into question_resource (" +
                                "`id_question` ," +
                                "`id_resource` " +
                                ") values ('" + ids[0] + "', '" + ids[i] + "');";
                GetNoItems(query);
            }
        }
    }
}
