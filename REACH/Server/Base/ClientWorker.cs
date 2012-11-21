using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Collections;
using System.Net.Sockets;
using REACH.Common.Base;

namespace REACH.Server.Base
{
    class ClientWorker
    {
        TcpClient connection;
        Thread chatThread;
        Boolean closed = false;

        public ClientWorker(TcpClient tcpClient)
        {
            connection = tcpClient;
            chatThread = new Thread(new ThreadStart(StartChat));
            chatThread.Start();
        }

        private void StartChat()
        {
            while (true)
            {
                RMessage message = WireMessage.ReceiveMessage(connection);
                if (message == null)
                {
                    CloseConnection();
                    break;
                }
                Commander.OnNewMessage(message, connection);
            }
        }

        public void SendMessage(RMessage message)
        {
            try
            {
                WireMessage.SendMessage(connection, message);
            }
            catch (Exception)
            {
                // The connection is down, we destroy this ClientWorker
                CloseConnection();
                chatThread.Abort();
            }
        }

        public void CloseConnection()
        {
            if (connection.Connected)
            {
                UInt32 id = ServerCore.GetIdByConnection(connection);
                Console.WriteLine(id + " has left the system(id=0 means it didn't log in or it reconnected)");
                ServerCore.RemoveConnection(connection);
                Socket socket = connection.Client;
                connection.Close();
                socket.Close();
                closed = true;
            }
            else if(!closed)
            {
                UInt32 id = ServerCore.GetIdByConnection(connection);
                Console.WriteLine("connection with "+id + " has crashed(id=0 means it didn't log in or it reconnected)");
                Commander.OnCrash(connection);
                ServerCore.RemoveConnection(connection);
            }
        }
    }
}

