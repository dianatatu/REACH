using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Reflection;

using REACH.Common.Data;

namespace REACH.Server.Base
{
    public abstract class ConnectorBase<T>
    {
        protected static MySqlCommand GetCommand()
        {
            return ServerCore.sqlConnecter.GetCommand();
        }

        protected static void GetNoItems(String query)
        {
            MySqlCommand command = GetCommand();
            command.CommandText = query;
            GetNoItems(command);
        }

        protected static T GetSingleItem(String query)
        {
            MySqlCommand command = GetCommand();
            command.CommandText = query;
            return GetSingleItem(command);
        }

        protected static List<T> GetAllItems(String query)
        {
            MySqlCommand command = GetCommand();
            command.CommandText = query;
            return GetAllItems(command);
        }

		protected static void GetNoItems(MySqlCommand query)
		{
			ServerCore.sqlConnecter.ExecuteNonQuery(query);
		}

        protected static List<T> GetAllItems(MySqlCommand query)
        {
            MySqlDataReader reader = ServerCore.sqlConnecter.GetReaderForQuery(query);
            List<T> resultItems = GetAllItemsFromReader(reader);
            reader.Close();
            return resultItems;
        }

        protected static T GetSingleItem(MySqlCommand query)
        {
            MySqlDataReader reader = ServerCore.sqlConnecter.GetReaderForQuery(query);
            T resultItem = GetSingleItemFromReader(reader);
            reader.Close();
            return resultItem;
        }

        protected static T GetSingleItemFromReader(MySqlDataReader reader)
        {
            if (!reader.Read())
                return default(T);

            Type type = typeof(T);

            ConstructorInfo[] cInfo = type.GetConstructors();
            Object[] values = new Object[reader.FieldCount];
            reader.GetValues(values);
            if (cInfo.Length > 0)
                return (T)(cInfo[0].Invoke(values));
            else
                return (T)(values[0]);
        }

        protected static List<T> GetAllItemsFromReader(MySqlDataReader reader)
        {
            List<T> list = new List<T>();
            T Item;
            while ((Item = GetSingleItemFromReader(reader)) != null)
            {
                list.Add(Item);
            }
            return list;
        }


    }
}
