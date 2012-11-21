using System;
using System.Collections.Generic;

using REACH.Common.Data;
using REACH.Server.Base;

namespace REACH.Server.Connectors
{
	public class DomainConnector : ConnectorBase<DomainData>
	{
		public static List<DomainData> GetAllDomains()
		{
			string query = "SELECT * FROM domain";
			return GetAllItems(query);
		}

        public static DomainData GetDomainByName(String Domain_Name)
        {
            string query = "SELECT * FROM domain " +
                            "WHERE name_domain = \"" + Domain_Name + "\";";
            return GetSingleItem(query);
        }

        public static List<DomainData> GetUserValidations(uint uid)
        {
            string query = "SELECT * FROM domain " +
                           "WHERE id_domain IN " +
                           "( SELECT id_domain FROM validation " +
                           "WHERE id_user = " + uid + " );";
            return GetAllItems(query);
        }

        public static List<DomainData> GetUserNonValidations(uint uid)
        {
            string query = "SELECT * FROM domain " +
                           "WHERE id_domain NOT IN " +
                           "( SELECT id_domain FROM validation " +
                           "WHERE id_user = " + uid + " );";
            return GetAllItems(query);
        }

        public static List<DomainData> GetQuestionDomains(QuestionData q)
        {
            String query =  "select a.* " +
                            "from domain a, domain_question b " +
                            "where b.id_question = " + q.Id +
                            " and b.id_domain = a.id_domain;";
            return GetAllItems(query);
        }

	}
}
