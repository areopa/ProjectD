﻿using Newtonsoft.Json;
﻿using System;
using System.Collections.Generic;
using System.Text;
using WebSocketSharp;

namespace prototype_p2p
{
    public class Client
    {
        public IDictionary<string, WebSocket> socketDictionary = new Dictionary<string, WebSocket>();

        public List<string> PingAll()
        {
            List<string> display = new List<string>() { };

            if (socketDictionary != null)
            {
                foreach (var item in socketDictionary)
                {
                    WebSocket socket = new WebSocket(item.Key);
                    try
                    {
                        socket.Connect();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                    finally
                    {
                        if (socket.IsAlive)
                        {
                            Console.WriteLine(item.Key + " : connection alive");
                            display.Add(item.Key);
                        }
                        else
                        {
                            Console.WriteLine(item.Key + " : connection broken");
                            socketDictionary.Remove(item.Key);
                        }
                    }
                }
            }
            else
            {
                display.Add("no connections");
            }
            return display;
        }

        public void Handshake(string url)
        {
            if (!socketDictionary.ContainsKey(url))
            {
                WebSocket socket = new WebSocket(url);

                socket.OnClose += (sender, e) =>
                {
                    Console.WriteLine(url+" : connection closed");
                    Program.genericGUIForm.richTextBoxStatusUpdates.AppendText(
                        url + " has fallen away. Nay!" + Environment.NewLine
                        );
                    socketDictionary.Remove(url);
                    return;
                };
                socket.OnMessage += (sender, e) =>
                {
                    if (e.Data == "Handshake to client")
                    {
                        Console.WriteLine(e.Data);
                    }
                    else
                    {
                        Console.WriteLine("Creating new chain from client");
                        Chain newChain = JsonConvert.DeserializeObject<Chain>(e.Data);
                        if (newChain.CheckIntegrity() && newChain.ChainList.Count > Program.ProjectD.ChainList.Count)
                        {
                            List<Message> messagesToAdd = new List<Message>();
                            messagesToAdd.AddRange(newChain.MessageQueue);
                            messagesToAdd.AddRange(Program.ProjectD.MessageQueue);

                            newChain.MessageQueue = messagesToAdd;
                            Program.ProjectD = newChain;
                        }
                    }
                };
                socket.Connect();
                socket.Send("Handshake to server");
                socket.Send(JsonConvert.SerializeObject(Program.ProjectD));
                socketDictionary.Add(url, socket);
                Program.genericGUIForm.richTextBoxStatusUpdates.AppendText(
                        url + " is now connected" + Environment.NewLine
                        );

            }
        }


        public void SendToOne(string url, string data)
        {
            foreach (var item in socketDictionary)
            {
                if (item.Key == url)
                {
                    item.Value.Send(data);
                }
            }
        }

        public void SendToAll(string data)
        {
            foreach (var item in socketDictionary)
            {
                item.Value.Send(data);
            }
        }

        public IList<string> LookupServers()
        {
            IList<string> serverList = new List<string>();
            foreach (var item in socketDictionary)
            {
                serverList.Add(item.Key);
            }
            return serverList;
        }

        public void Exit()
        {
            foreach (var item in socketDictionary)
            {
                item.Value.Close();
            }
        }
    }
}
