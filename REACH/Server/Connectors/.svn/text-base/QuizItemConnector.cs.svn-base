using System;
using System.Collections.Generic;

using REACH.Common.Data;
using REACH.Server.Base;

namespace REACH.Server.Connectors
{
	public class QuizItemConnector : ConnectorBase<QuizItemData>
	{
		public static List<QuizItemData> GetAllItems(uint domainId)
		{
			string query = @"
				SELECT a.* 
				FROM quiz_item a, domain_quiz_item b 
				WHERE b.id_domain = " + domainId + " AND b.id_quiz_item = a.id_quiz_item";
			return GetAllItems(query);
		}
	}
}
