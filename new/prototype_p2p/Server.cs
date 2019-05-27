using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace prototype_p2p
{
    public class Server : WebSocketBehavior
    {
        bool Synchronized = false;
        WebSocketServer ServerInstance = null;

        public void Initialize()
        {
            ServerInstance = new WebSocketServer($"ws://145.137.115.173:{Program.NetworkPort}");
            ServerInstance.AddWebSocketService<Server>("/Chain");
            ServerInstance.Start();
            Console.WriteLine($"Server initialized at ws://145.137.115.173:{Program.NetworkPort}");
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