using System;
using System.Collections.Generic;

using REACH.Common.Data;
using REACH.Server.Base;

namespace REACH.Server.Connectors
{
	public class ValidationConnector : ConnectorBase<ValidationData>
	{
		public static void AddValidation(uint user_id, uint domain_id)
		{
			String query = 
				"INSERT INTO validation " +
				"VALUES(" + user_id + ", " + domain_id + ")";
			GetNoItems(query);
		}
	}
}
