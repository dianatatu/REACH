using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

using REACH.Common.Base;
using REACH.Server.Connectors;
using REACH.Server.Commanders;

namespace REACH.Server.Base
{
    class ServerCore
    {
		private const string COMMANDERS_NAMESPACE = "REACH.Server.Commanders";

		private string ip;
		private int port;

        public static SqlConnector sqlConnecter;
        private static Dictionary<UInt32, TcpClient> idConnection;
        private static Dictionary<TcpClient, UInt32> connectionId;
        private static Dictionary<TcpClient, ClientWorker> connectionWorker;
        private static List<ClientWorker> workers;
        private static readonly object imutex = new object();
        private static readonly object mutex = new object();
        private static ServerCore instance = null;

		private void LoadConfig()
		{
			Hashtable hash = Configuration.GetSettings();
			ip = hash["ip"].ToString();
			port = Int32.Parse(hash["port"].ToString());
		}

        private ServerCore()
        {
			LoadConfig();
            RegisterCommanders();
            try
            {
                sqlConnecter = SqlConnector.Instance;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not connect to Mysql: \"" + ex.Message + "\"");
                Console.WriteLine("Aborting. Press any key to exit");
                Console.Read();
                return;
            }
            idConnection = new Dictionary<UInt32, TcpClient>();
            connectionWorker = new Dictionary<TcpClient, ClientWorker>();
            connectionId = new Dictionary<TcpClient, UInt32>();
            workers = new List<ClientWorker>();
            TcpListener tcpListener = new System.Net.Sockets.TcpListener(IPAddress.Parse(ip), port);

            tcpListener.Start();
            while (true)
            {
                TcpClient connection = tcpListener.AcceptTcpClient();
                Console.WriteLine("Someone connected");
                ClientWorker worker = new ClientWorker(connection);
                lock (mutex)
                {
                    connectionWorker.Add(connection, worker);
                    workers.Add(worker);
                }
            }
        }

        private void RegisterCommanders()
        {			 
			MethodInfo mi;
			Type[] list = Assembly.GetExecutingAssembly().GetTypes();
			for (int i = 0; i < list.Length; ++i)
				if (list[i].IsClass && list[i].Namespace == COMMANDERS_NAMESPACE)
				{
					mi = list[i].GetMethod("RegisterHandlers");
					if (mi != null)
						mi.Invoke(null, null);
                    mi = list[i].GetMethod("RegisterCrashActions");
                    if (mi != null)
                        mi.Invoke(null, null);
				}
        }

        // thread-Safe implementation of Singleton Pattern
        public static ServerCore Instance
        {
            get
            {
                lock (imutex)
                {
                    if (instance == null)
                        instance = new ServerCore();
                    return instance;
                }
            }
        }

        public static UInt32 GetIdByConnection(TcpClient connection)
        {
            lock (mutex)
            {
                if (connectionId.ContainsKey(connection))
                    return connectionId[connection];
                else
                    return 0;
            }
        }

        public static TcpClient GetConnectionById(uint id)
        {
            lock (mutex)
            {
                if (idConnection.ContainsKey(id))
                    return idConnection[id];
                else
                    return null;
            }
        }

        public static ClientWorker GetWorkerById(UInt32 id)
        {
            lock (mutex)
            {
                if (idConnection.ContainsKey(id))
                    return connectionWorker[idConnection[id]];
                else
                    return null;
            }
        }

        public static ClientWorker GetWorkerByConnection(TcpClient connection)
        {
            lock (mutex)
            {
                return connectionWorker[connection];
            }
        }

        public static void AddIdConnectionMapping(UInt32 id, TcpClient connection)
        {
            lock (mutex)
            {
                idConnection.Add(id, connection);
                connectionId.Add(connection, id);
            }
        }

        public static void RemoveIdConnectionMapping(UInt32 id, TcpClient connection)
        {
            lock (mutex)
            {
                idConnection.Remove(id);
                connectionId.Remove(connection);
            }
        }

        public static void RemoveConnection(TcpClient connection)
        {
            lock (mutex)
            {
                if (connectionId.ContainsKey(connection))
                {
                    idConnection.Remove(connectionId[connection]);
                    connectionId.Remove(connection);
                }
                connectionWorker.Remove(connection);
            }
        }

        public static List<ClientWorker> GetAllWorkers()
        {
            lock (mutex)
            {
                return workers;
            }
        }

    }
}
