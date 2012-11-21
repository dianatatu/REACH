using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

using REACH.Common.Data;
using REACH.Server.Base;

namespace REACH.Server.Connectors
{
    public class LogConnector : ConnectorBase<AnswerData>
    {

        public static List<AnswerData> GetQuestionAnswers(UInt32 qId)
        {
            String query = "select *" +
                            " from log " +
                            "where question_question=" + qId + ";";
            
            return GetAllItems(query);
        }

        public static void AddAnswer(AnswerData answer)
        {
            String query;
            query = "insert into log (" +
                            "`id_log` ," +
                            "`question_question` ," +
                            "`owner_user` ," +
                            "`timestamp_log` ," +
                            "`content_log`" +
                            ") values (" +
                            "'NULL'," +
                            answer.Question +
                            ", " +
                            answer.Owner +
                            ",now()," +
                            "@Content" +
                            ");";
            
            MySqlCommand command = GetCommand();
            command.CommandText = query;
            command.Parameters.Add(new MySqlParameter("@Content", answer.Content.ToString()));
            GetNoItems(command);

            // update user rank
            query = "update user " +
                    "set rank_user=rank_user + 0.2 " +
                    "where id_user = " +
                    answer.Owner + " ;";
            GetNoItems(query);
        }
    }
}