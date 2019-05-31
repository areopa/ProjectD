using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace prototype_p2p
{
    public class Server : WebSocketBehavior
    {
        bool Synchronized = false;
        WebSocketServer ServerInstance = null;

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        public void Initialize()
        {
            string LocalIPAddress = GetLocalIPAddress();
            ServerInstance = new WebSocketServer($"ws://{LocalIPAddress}:{Program.NetworkPort}");
            ServerInstance.AddWebSocketService<Server>("/Chain");
            ServerInstance.Start();
            Console.WriteLine($"Server initialized at ws://{LocalIPAddress}:{Program.NetworkPort}");
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            if (e.Data == "Handshake to server")
            {
                Console.WriteLine(e.Data);
                Send("Handshake to client");
            }
            else
            {
                Console.WriteLine("Creating new chain from server");
                Chain newChain = JsonConvert.DeserializeObject<Chain>(e.Data);

                if (newChain.CheckIntegrity() && newChain.ChainList.Count > Program.ProjectD.ChainList.Count)
                {
                    List<Message> messagesToAdd = new List<Message>();
                    messagesToAdd.AddRange(newChain.MessageQueue);
                    messagesToAdd.AddRange(Program.ProjectD.MessageQueue);

                    newChain.MessageQueue = messagesToAdd;
                    Program.ProjectD = newChain;
                }

                if (!Synchronized)
                {
                    Send(JsonConvert.SerializeObject(Program.ProjectD));
                    Synchronized = true;
                }
            }
        }
    }
}