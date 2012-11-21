using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

using REACH.Client.Base;
using REACH.Client.Core;
using REACH.Client.Controllers;
using REACH.Client.Models;
using REACH.Common.Base;
using REACH.Common;
using System.Threading;

namespace REACH.Client.Base
{
    public class Service : IService
    {
		private const int DELAY_TIME = 50; // miliseconds
		private const int TIMEOUT = 2; // seconds
		private const int TIMEOUT_TICKS = (TIMEOUT * 1000) / DELAY_TIME;

		private string ip;
		private int port;

        private static Service instance = null;
        private static readonly object imutex = new object();
        private readonly object mutex = new object();
        private Thread send;
        private Thread receive;
        private bool isRunning = false;
        private List<RMessage> messageQueue = new List<RMessage>();
		private Dictionary<RMessage, int> timeout = new Dictionary<RMessage, int>();
        private System.Net.Sockets.TcpClient tcpClient;

		private void LoadConfig()
		{
			Hashtable hash = Configuration.GetSettings();
			ip = hash["ip"].ToString();
			port = Int32.Parse(hash["port"].ToString());
		}

        // prevent calling the constructor from outside
        private Service()
        {
			LoadConfig();
        }

        private void ConnectToServer()
        {
            tcpClient = new System.Net.Sockets.TcpClient();
            while (true)
            {
                try
                {
                    tcpClient.Connect(ip, port);
                    break;
                }                
                catch (Exception)
                {                    
                }
                Thread.Sleep(DELAY_TIME);
            }
        }

        // thread-safe implementation of Singleton Pattern
        public static Service Instance
        {
            get
            {
                lock (imutex)
                {
                    if (instance == null)
                        instance = new Service();
                    return instance;
                }
            }
        }

        public void AddMessage(RMessage message)
        {
            lock (mutex)
            {
				timeout[message] = TIMEOUT_TICKS;
				messageQueue.Add(message);
            }

        }

        private void SendMessages()
        {
            while (true)
            {
                lock (mutex)
                {
                    List<RMessage> newMessageQueue = new List<RMessage>();
                    foreach (RMessage m in messageQueue)
                    {
                        try
                        {
							--timeout[m];
                            WireMessage.SendMessage(tcpClient, m);
                            timeout.Remove(m);
                        }
                        catch (Exception)
                        {
							if (timeout[m] > 0)
								newMessageQueue.Add(m);
							else
							{
								// Send back the message
								Context.FireCallback(m);
								timeout.Remove(m);
							}
                        }
                    }
                    messageQueue.Clear();
                    messageQueue.AddRange(newMessageQueue);
                }
                Thread.Sleep(DELAY_TIME);
            }
        }

        private void ReceiveMessages()
        {
            if(tcpClient == null)
                ConnectToServer();
            while (true)
            {
                RMessage msg;
                do
                {
                    msg = WireMessage.ReceiveMessage(tcpClient);
                    // Pass the control to the Context, to find an
                    // appropiate callback function                
                    if (msg != null)
                        Context.FireCallback(msg);
                    else
                    {
                        Context.FireCallback(new RMessage(MessageType.SERVER_OFFLINE_EVENT, null));
                        ConnectToServer();
                    }
                } while (msg == null);
            }
        }

        public void Start()
        {
            if (isRunning == false)
            {
                send = new Thread(SendMessages);
                receive = new Thread(ReceiveMessages);
                send.Start();
                receive.Start();
                isRunning = true;
            }
        }

        public void Stop()
        {
            if (isRunning == true)
            {
                while (true)
                {
                    lock (mutex)
                    {
                        if (messageQueue.Count == 0 || !(tcpClient.Connected))
                            break;
                    }
                    Thread.Sleep(DELAY_TIME);
                }
                send.Abort();
                send.Join();
                receive.Abort();
                receive.Join();
                isRunning = false;
            }
        }

    }
}
