using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Reflection;

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



            //This is only for testing the encryption for now.
            //Console.Write("Enter the data you want encrypted: ");
            //Console.WriteLine(SignAndEncryptString.StringEncrypter(Console.ReadLine()));



            string pathKey = @"..\\..\\Keys";
            var test = System.IO.Directory.GetFiles(pathKey);
            var atestArray = test.ToArray();
            var testNew = test.GetLength(0);



            Console.Write("Enter networkport: ");
            while (NetworkPort == 0)
            {
                if(int.TryParse(Console.ReadLine(), out int port))
                {
                    NetworkPort = port;
                    break;
                }
                Console.WriteLine("A port has to be a number. Try again.");
                Console.Write("Enter networkport: ");
            }


                




            Console.Write("Enter Node name: ");
            NodeName = Console.ReadLine();



            //Eerst ProjectD.ReadChain() --> Als geen resultaat, dan SetupChain()
            ProjectD.ReadChain();
            if (ProjectD.ChainList == null)
            {
                ProjectD.SetupChain(); 
            }

        //    if (args.Length >= 1)
         //       NetworkPort = int.Parse(args[0]);
        //    if (args.Length >= 2)
        //        NodeName = args[1];

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
                        Console.WriteLine("Type your message");
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

                Console.WriteLine("Choose something from the instruction list\n");
                string action = Console.ReadLine();
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
           
            string workingDirectory = AppDomain.CurrentDomain.BaseDirectory;
            using (StreamWriter file = File.CreateText(workingDirectory + "\\chain.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, ProjectD);
            }

            ClientInstance.Exit();
        }
    }
}
