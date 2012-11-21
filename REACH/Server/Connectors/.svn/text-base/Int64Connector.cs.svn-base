using System;
using System.Collections.Generic;

using REACH.Common.Data;
using REACH.Server.Base;

namespace REACH.Server.Connectors
{
    public class Int64Connector : ConnectorBase<Int64>
    {
        public static Int64 GetLastInsertId()
        {
            String query = "SELECT LAST_INSERT_ID();";
            return GetSingleItem(query);
        }
    }
}
