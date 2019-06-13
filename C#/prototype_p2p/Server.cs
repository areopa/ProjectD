using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System.Windows.Forms;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace prototype_p2p
{
    public class Server : WebSocketBehavior
    {
        bool Synchronized = false;
        WebSocketServer ServerInstance = null;
        public string LocalIPAddress;
        public string serverInitAt;


        public string GetLocalIPAddress()
        {
            UnicastIPAddressInformation mostSuitableIp = null;

            var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (var network in networkInterfaces)
            {
                if (network.OperationalStatus != OperationalStatus.Up)
                    continue;

                var properties = network.GetIPProperties();

                if (properties.GatewayAddresses.Count == 0)
                    continue;

                foreach (var address in properties.UnicastAddresses)
                {
                    if (address.Address.AddressFamily != AddressFamily.InterNetwork)
                        continue;

                    if (IPAddress.IsLoopback(address.Address))
                        continue;

                    if (!address.IsDnsEligible)
                    {
                        if (mostSuitableIp == null)
                            mostSuitableIp = address;
                        continue;
                    }

                    // The best IP is the IP got from DHCP server
                    if (address.PrefixOrigin != PrefixOrigin.Dhcp)
                    {
                        if (mostSuitableIp == null || !mostSuitableIp.IsDnsEligible)
                            mostSuitableIp = address;
                        continue;
                    }

                    return address.Address.ToString();
                }
            }

            return mostSuitableIp != null 
                ? mostSuitableIp.Address.ToString()
                : "";
        }

        public string GetExternalIPAddress()
        {
            try
            {
                string externalip = new WebClient().DownloadString("http://icanhazip.com");
                return externalip;
            }
            catch(Exception w)
            {
                Console.WriteLine(w);
                MessageBox.Show("Something went wrong with obtaining external IP address, switching over to local IP.\n" + w);
                return GetLocalIPAddress();
            }
        }
        

        public void Initialize()
        {
            LocalIPAddress = GetLocalIPAddress();
            ServerInstance = new WebSocketServer($"ws://{LocalIPAddress}:{Program.NetworkPort}");
            ServerInstance.AddWebSocketService<Server>("/Chain");
            ServerInstance.Start();
            serverInitAt = $"ws://{LocalIPAddress}:{Program.NetworkPort}";
            Console.WriteLine($"Server initialized at ws://{LocalIPAddress}:{Program.NetworkPort}");
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            if (e.Data == "Handshake to server")
            {
                Console.WriteLine(e.Data);
                Console.WriteLine(Context.UserEndPoint.Address.ToString());
                //Console.WriteLine(Context.UserEndPoint.Port.ToString());
                Send("Handshake to client");
                try
                {
                    Program.genericGUIForm.richTextBoxStatusUpdates.AppendText(Context.UserEndPoint.Address.ToString() + " is connected to you!" + Environment.NewLine);
                }
                catch (Exception f)
                {
                    if(f is InvalidOperationException)
                    {
                        Console.WriteLine("Threading error: " + f);
                    }
                    else
                    {
                        Console.WriteLine("Unexpected error: " + f);
                    }
                }
            }
            if (e.IsPing)
            {
                Console.WriteLine("You've just been pinged");
                Send("Connection live");
            }
            else
            {

                try
                {
                    Chain newChain = JsonConvert.DeserializeObject<Chain>(e.Data);
                    Console.WriteLine("Creating new chain from server");
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
                catch(Exception g)
                {
                    if (g is JsonReaderException)
                    {
                        if (!e.Data.IsNullOrEmpty())
                        {
                            Console.WriteLine(e.Data.ToString() + " received as data");
                        }
                    }
                    else
                    {
                        Console.WriteLine(g);
                    }
                }


            }
        }
    }
}