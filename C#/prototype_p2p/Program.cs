using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;

namespace prototype_p2p
{
    class Program
    {
        public static int NetworkPort = 0;
        public static Server ServerInstance = null;
        public static Client ClientInstance = new Client();
        public static Chain ProjectD = new Chain();
        public static string NodeName = "Unknown";
        private static readonly List<string> validActions = new List<string> { "1", "2", "3", "4", "5", "7", "8", "9", "10" };
        public static string pathKeyPrivate = @"..\\..\\Keys\\Private";
        public static string pathKeyPublic = @"..\\..\\Keys\\Public";
        public static string pathKey = @"..\\..\\Keys";
        public static Form1 form1;
        public static FlushBlock flushMsgAndSend;


        //restricting usage of most commonly used ports 25:SMTP 80:HTTP 443:HTTPS 20,21:FTP 23:telnet 143:IMAP 3389:RDP 22:SSH 53:DNS 67,68:DHCP 110:POP3
        public static readonly List<int> portBlacklist = new List<int> { 0, 20, 21, 22, 23, 25, 53, 67, 68, 80, 110, 143, 443, 3389 };

        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Public Keys directory exists:" + Directory.Exists(pathKeyPublic));
            Console.WriteLine("Private Keys directory exists:" + Directory.Exists(pathKeyPrivate));
            Console.WriteLine("Default Keys directory for CLI exists:" + Directory.Exists(pathKey));
            Console.WriteLine("Config.ini exists:" + File.Exists("Config.ini"));

            ConfigFile configData = new ConfigFile();
            configData.WriteAllValuesConsole();

            ParseKeyID keyIDPaths = new ParseKeyID(pathKey);
            keyIDPaths.WriteLoadedKeyPaths();

            

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

            flushMsgAndSend = new FlushBlock(NodeName, ClientInstance); //Place this after the chain, clientinstance and nodename have been initialized.

            Console.WriteLine("--------------------------------------");
            Console.WriteLine("1. Setup a connection with a server");
            Console.WriteLine("2. Add unencrypted data to chain");
            Console.WriteLine("3. Display records");
            Console.WriteLine("4. Exit the program");
            Console.WriteLine("5. List all keys in the keys directory");
            Console.WriteLine("7. Decrypt a stored message");
            Console.WriteLine("8. Encrypt a message, multiple recipients supported, encryption key ID's are listed under 5");
            Console.WriteLine("9. Toggle loading from config");
            Console.WriteLine("10. List active connections");
            Console.WriteLine("--------------------------------------");




            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form1 = new Form1(keyIDPaths, configData, ClientInstance, ServerInstance);
            Application.Run(form1);

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
                        string data = Prompt.ShowDialog("Enter the data", "Data entry");

                        flushMsgAndSend.Flush(receiverName, data);
                        break;
                    case 3:
                        Console.WriteLine("Chain");
                        Console.WriteLine(JsonConvert.SerializeObject(ProjectD, Formatting.Indented));
                        break;
                    case 5:
                        keyIDPaths.WriteLoadedKeyPaths();
                        break;
                    case 7:
                        if (ProjectD.ChainList.Count > 1) //1 and not 0 because the genesis block counts as one.
                        {
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

                            keyIDPaths.WriteLoadedKeyPaths(false,true);
                            Console.Write("Enter the ID of the private key you want to use to decrypt: ");
                            string privateKeyPathDecrypt = keyIDPaths.ParseAndReturnVerifiedKeyPath(); //the user looks up the private and public key ÏD's with the option 5 menu and then chooses the encryption keys with the ID"s linked to the keys.
                            keyIDPaths.WriteLoadedKeyPaths(true, false);
                            Console.Write("Enter the ID of the public key of the sender: ");
                            string publicKeyPathDecrypt = keyIDPaths.ParseAndReturnVerifiedKeyPath(true);

                            DecryptAndVerifyString.Decrypt(encryptedDataFromChain, privateKeyPathDecrypt, publicKeyPathDecrypt);
                        }
                        else
                        {
                            Console.WriteLine("There are no blocks to decrypt!");
                        }
                        break;
                    case 8:

                        Console.WriteLine("Enter the names of the designated recipients");
                        string receiverNamesForImprovedMultiEnc = Console.ReadLine();

                        keyIDPaths.WriteLoadedKeyPaths(false, true);
                        Console.WriteLine("Enter the ID of the private key you want to sign with");
                        string privKeyPath = keyIDPaths.ParseAndReturnVerifiedKeyPath();

                        keyIDPaths.WriteLoadedKeyPaths(true, false);
                        Console.WriteLine("Enter the public key ID's for every recipient");
                        string[] recipientKeyPathsArr = keyIDPaths.BuildVerifiedKeyIdPathArray();

                        string inputData = Prompt.ShowDialog("Enter the data you want to encrypt", "Data entry");

                        string encData = EncryptFileMultipleRecipients.MultiRecipientStringEncrypter(inputData, privKeyPath, recipientKeyPathsArr);
                        Console.WriteLine(encData);

                        flushMsgAndSend.Flush(receiverNamesForImprovedMultiEnc, encData);
                        break;
                    case 9:

                        configData.ToggleAutoLoadConfigValues();
                        break;
                    case (10):

                        ClientInstance.PingAll();
                        break;
                }

                        ProjectD.SaveChainStateToDisk(ProjectD);
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
                        
                }

            ProjectD.SaveChainStateToDisk(ProjectD);

            ClientInstance.Exit();
            }
        }
    }

