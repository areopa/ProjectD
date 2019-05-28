using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace prototype_p2p
{
    class Program
    {
        public static int NetworkPort = 0;
        public static Server ServerInstance = null;
        public static Client ClientInstance = new Client();
        public static Chain ProjectD = new Chain();
        public static string NodeName = "Unknown";
        private static List<string> validActions = new List<string> { "1", "2", "3", "4" };

        static void Main(string[] args)
        {
            ProjectD.SetupChain();

            if (args.Length >= 1)
                NetworkPort = int.Parse(args[0]);
            if (args.Length >= 2)
                NodeName = args[1];

            if (NetworkPort > 0)
            {
                ServerInstance = new Server();
                ServerInstance.Initialize();
            }
            if (NodeName != "Unkown")
            {
                Console.WriteLine($"Your name is {NodeName}");
            }

            Console.WriteLine("--------------------------------------");
            Console.WriteLine("1. Setup a connection with a server");
            Console.WriteLine("2. Add data to chain");
            Console.WriteLine("3. Display records");
            Console.WriteLine("4. Exit the program");
            Console.WriteLine("--------------------------------------");

            int instruction = 0;
            while (instruction != 4)
            {
                switch (instruction)
                {
                    case 1:
                        Console.WriteLine("Enter the URL of the server");
                        string serverURL = Console.ReadLine();
                        ClientInstance.Handshake($"{serverURL}/Chain");
                        break;
                    case 2:
                        Console.WriteLine("Enter the name of the server");
                        string receiverName = Console.ReadLine();
                        Console.WriteLine("Type you message");
                        string data = Console.ReadLine();
                        ProjectD.CreateMessage(new Message(NodeName, receiverName, data));
                        ProjectD.ProcessMessageQueue(NodeName);
                        ClientInstance.SendToAll(JsonConvert.SerializeObject(ProjectD));
                        break;
                    case 3:
                        Console.WriteLine("Chain");
                        Console.WriteLine(JsonConvert.SerializeObject(ProjectD, Formatting.Indented));
                        break;

                }

                Console.WriteLine("Choose something from the instruction list");
                string action = Console.ReadLine();
                /*TODO1: Input filteren op integers zodat het programma niet crasht bij onverwachte input*/
                if (validActions.Contains(action))
                {
                    instruction = int.Parse(action);
                }
                else
                {
                    Console.WriteLine("Please pick a valid action!");
                    instruction = 0;
                }
            }

            ClientInstance.Exit();
        }
    }
}
