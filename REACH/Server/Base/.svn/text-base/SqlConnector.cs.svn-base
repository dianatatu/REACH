using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace REACH.Server.Base
{
    class SqlConnector
    {
        MySqlConnection connection = null;
        private readonly object mutex = new object();
        private static readonly object imutex = new object();
        private static SqlConnector instance = null;

        private SqlConnector()
        {
            CreateConnection();
        }

        private void CreateConnection()
        {
            string MyConString = "SERVER=localhost;" +
                        "DATABASE=reach;" +
                        "UID=root;" +
                        "PASSWORD=;";
            connection = new MySqlConnection(MyConString);
            connection.Open();
            Console.WriteLine("Connected to MySQL");
        }

        // thread-Safe implementation of Singleton Pattern
        public static SqlConnector Instance
        {
            get
            {
                lock (imutex)
                {
                    if (instance == null)
                        instance = new SqlConnector();
                    return instance;
                }
            }
        }

        ~SqlConnector()
        {
            Console.WriteLine("Connection to MySQL closed");
            connection.Close();
        }

        public MySqlDataReader GetReaderForQuery(MySqlCommand command)
        {
            MySqlDataReader reader = null;
            lock (mutex)
            {
                try
                {
                    reader = command.ExecuteReader();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lost connection to MySQL due to\n"+ex);                       
                }
            }
            return reader;
        }

        public int ExecuteNonQuery(MySqlCommand command)
        {
            int result = -10;
            lock (mutex)
            {
                try
                {
                    result = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lost connection to MySQL due to\n" + ex);
                }
            }
            return result;
        }

        public MySqlCommand GetCommand()
        {
            lock (mutex)
            {
                return connection.CreateCommand();
            }
        }
    }
}
