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
        private static readonly List<string> validActions = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        public static string pathKey = @"..\\..\\Keys";
        public static string pathMessages = @"..\\..\\Messages";

        //restricting usage of most commonly used ports 25:SMTP 80:HTTP 443:HTTPS 20,21:FTP 23:telnet 143:IMAP 3389:RDP 22:SSH 53:DNS 67,68:DHCP 110:POP3
        public static readonly List<int> portBlacklist = new List<int> { 0, 20, 21, 22, 23, 25, 53, 67, 68, 80, 110, 143, 443, 3389 }; //The blacklist can be implemented with a user editable config file in the future

        static void Main(string[] args)
        {
            //Console.WriteLine("Messages directory exists:" + Directory.Exists(@"Messages"));
            Console.WriteLine("Default Keys directory exists:" + Directory.Exists(pathKey));
            Console.WriteLine("Config.ini exists:" + File.Exists("Config.ini"));

            ConfigFile configData = new ConfigFile(pathKey);
            configData.WriteAllValuesConsole();

            ParseKeyID keyIDPaths = new ParseKeyID(pathKey);
            keyIDPaths.WriteAllLoadedKeyPaths();

            while (NetworkPort == 0)
            {
                Console.Write("Enter network port: ");
                if (int.TryParse(Console.ReadLine(), out int port)) //checks if the given input is a string. If not the user is told to enter a number. No more crashes because you accidently pressed enter.
                {
                    port = Math.Abs(port); //can't enter a negative number as a port now
                    if (!portBlacklist.Contains(port)) //checks if the entered port is on the blacklist
                    {
                        NetworkPort = port;
                        break;
                    }
                    Console.Write("Pick a port number that does not match any of the following: ");
                    Console.WriteLine(string.Join<int>(", ", portBlacklist)); //lists all blacklisted ports to the user so he can avoid them.
                    Console.Write("Enter network port: ");

                }
                else
                {
                    Console.WriteLine("A port has to be a number. Try again.");
                }
            }

            if (NodeName == "Unknown")
            {
                Console.Write("Enter Node name: ");
                NodeName = Console.ReadLine();
            }

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
                Console.WriteLine($"Your node name is: {NodeName}");
            }

            Console.WriteLine("--------------------------------------");
            Console.WriteLine("1. Setup a connection with a server");
            Console.WriteLine("2. Add unencrypted data to chain");
            Console.WriteLine("3. Display records");
            Console.WriteLine("4. Exit the program");
            Console.WriteLine("5. List all keys in the keys directory");
            Console.WriteLine("6. Encrypt a message, encryption key ID's are listed under 5");
            Console.WriteLine("7. Decrypt a stored message");
            Console.WriteLine("8. Multi encryption method");
            Console.WriteLine("9. Toggle loading from config");
           // Console.WriteLine("10. Delete current chain");
            Console.WriteLine("--------------------------------------");

            int instruction = 0;
            while (instruction != 4)
            {
                switch (instruction)
                {
                    case 1:
                        Console.WriteLine("Enter the URL and port of the server:");
                        string serverURL = Console.ReadLine();
                        ClientInstance.Handshake($"{serverURL}/Chain");
                        break;
                    case 2:
                        Console.Write("Enter the name(s) of the intended recipient(s): ");
                        string receiverName = Console.ReadLine();
                        Console.WriteLine("Enter the data:");
                        string data = Console.ReadLine();
                        ProjectD.CreateMessage(new Message(NodeName, receiverName, data));
                        ProjectD.ProcessMessageQueue(NodeName);
                        ClientInstance.SendToAll(JsonConvert.SerializeObject(ProjectD));
                        break;
                    case 3:
                        Console.WriteLine("Chain");
                        Console.WriteLine(JsonConvert.SerializeObject(ProjectD, Formatting.Indented));
                        break;
                    case 5:
                        string[] keyArray = Directory.GetFiles(pathKey).Select(p => Path.GetFileName(p)).ToArray(); //Select statement with lambda is necessary to display file names without the relative path appended.
                        //Lists every file found in the map pathKey is pointing to
                        for (int i = 0; i < keyArray.Length; i++)
                        {
                            Console.WriteLine(keyArray[i] + " key ID:" + i);
                        }
                        //for (int i = 0; i < keyArrayPathAppended.Length; i++)
                        //{
                        //    Console.WriteLine(keyArrayPathAppended[i] + " key ID:" + i);
                        //}
                        break;
                    case 6:
                        Console.WriteLine("Enter the name of the receiver");
                        string receiverNameFor6 = Console.ReadLine();

                        Console.WriteLine("Enter the data you want encrypted: ");
                        string dataToBeEncrypted = Console.ReadLine();
                        Console.WriteLine("Enter the ID of the private key you want to sign with");
                        string privateKeyPath = keyIDPaths.ParseAndReturnVerifiedKeyPath(); //the user looks up the private and public key ÏD's with the option 5 menu and then chooses the encryption keys with the ID"s linked to the keys.
                        Console.WriteLine("Enter the ID of the public key you want to encrypt for");
                        string publicKeyPath = keyIDPaths.ParseAndReturnVerifiedKeyPath();
                    
                        string encryptedData = SignAndEncryptString.StringEncrypter(dataToBeEncrypted, privateKeyPath, publicKeyPath);
                        Console.WriteLine(encryptedData);
                        ProjectD.CreateMessage(new Message(NodeName, receiverNameFor6, encryptedData));
                        ProjectD.ProcessMessageQueue(NodeName);
                        ClientInstance.SendToAll(JsonConvert.SerializeObject(ProjectD));

                        break;
                    case 7:

                        int blockNumber = 0;
                        while (blockNumber <= 0)
                        {
                            Console.Write("Enter the number of the block you want to decrypt: ");
                            if (int.TryParse(Console.ReadLine(), out int inputBlockNumber)) //checks if the given input is a string. If not the user is told to enter a number. No more crashes because you accidently pressed enter.
                            {

                                if (inputBlockNumber >= ProjectD.ChainList.Count)
                                {
                                    Console.WriteLine("The number you enter must correspond to an existing block. Try again.");
                                }
                                else
                                {
                                    blockNumber = Math.Abs(inputBlockNumber);
                                }
                            }
                            else
                            {
                                Console.WriteLine("The number of the block has to be a number. Try again.");
                            }
                        }
                        Console.WriteLine("Encrypted data:");

                        string encryptedDataFromChain = ProjectD.ChainList[blockNumber].MessageList[0].Data;
                        Console.WriteLine(encryptedDataFromChain);

                        Console.Write("Enter the ID of the private key you want to use to decrypt: ");
                        string privateKeyPathDecrypt = keyIDPaths.ParseAndReturnVerifiedKeyPath(); //the user looks up the private and public key ÏD's with the option 5 menu and then chooses the encryption keys with the ID"s linked to the keys.
                        Console.Write("Enter the ID of the public key of the sender: ");
                        string publicKeyPathDecrypt = keyIDPaths.ParseAndReturnVerifiedKeyPath();

                        DecryptAndVerifyString.Decrypt(encryptedDataFromChain, privateKeyPathDecrypt, publicKeyPathDecrypt);

                        break;
                    case 8:

                        Console.WriteLine("Enter the names of the designated recipients");
                        string receiverNamesForImprovedMultiEnc = Console.ReadLine();

                        Console.WriteLine("Enter data you want to encrypt:");
                        string inputData = Console.ReadLine();

                        Console.WriteLine("Enter the ID of the private key you want to sign with");
                        string privKeyPath = keyIDPaths.ParseAndReturnVerifiedKeyPath();

                        Console.WriteLine("Enter the public key ID's for every recipient");
                        string[] recipientKeyPathsArr = keyIDPaths.BuildVerifiedKeyIdPathArray();

                        string encData = EncryptFileMultipleRecipients.MultiRecipientStringEncrypter(inputData, privKeyPath, recipientKeyPathsArr);
                        Console.WriteLine(encData);

                        ProjectD.CreateMessage(new Message(NodeName, receiverNamesForImprovedMultiEnc, encData));
                        ProjectD.ProcessMessageQueue(NodeName);
                        ClientInstance.SendToAll(JsonConvert.SerializeObject(ProjectD));
                        break;
                    case 9:

                        configData.ToggleAutoLoadConfigValues();
                        break;
                }


                        Console.Write("Enter the number of the action you want to execute: ");
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
                        using (StreamWriter file = File.CreateText(@"chain.json")) //placed it here as well to save the chain after every action
                        {
                            JsonSerializer serializer = new JsonSerializer();
                            serializer.Serialize(file, ProjectD);
                        }
                }

                using (StreamWriter file = File.CreateText(@"chain.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, ProjectD);
                }

                ClientInstance.Exit();
            }
        }
    }

