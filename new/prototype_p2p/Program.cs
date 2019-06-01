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
        private static readonly List<string> validActions = new List<string> { "1", "2", "3", "4", "5", "6", "8" };
        public static string pathKey = @"Keys";
        public static string pathMessages = @"Messages";
        //restricting usage of most commonly used ports 25:SMTP 80:HTTP 443:HTTPS 20,21:FTP 23:telnet 143:IMAP 3389:RDP 22:SSH 53:DNS 67,68:DHCP 110:POP3
        private static List<int> portBlacklist = new List<int> { 0, 20, 21, 22, 23, 25, 53, 67, 68, 80, 110, 143, 443, 3389 }; //The blacklist can be implemented with a user editable config file in the future
        

        static void Main(string[] args)
        {
            Directory.CreateDirectory(pathMessages);
            Directory.CreateDirectory(pathKey);
            
            if (Directory.GetFiles(pathKey).Length == 0)
            {
                string pathKeyAlt = @"..//..//Keys";
                if (Directory.Exists(pathKeyAlt) && Directory.GetFiles(pathKeyAlt).Length > 0)
                {
                    pathKey = pathKeyAlt;
                }
                else
                {
                    Console.WriteLine("No pgp keys have been found in the " + pathKey + " folder");
                }
            }
            else
            {
                Console.WriteLine(Directory.GetFiles(pathKey).Length+" pgp keys have been found in the "+pathKey+" folder");
            }
            Console.WriteLine("Messages directory exists:" + Directory.Exists(pathMessages));
            Console.WriteLine("Keys directory exists:" + Directory.Exists(pathKey));
            Console.WriteLine("Config.ini exists:" + File.Exists("Config.ini"));
            


            // Console.WriteLine("Messages\\WriteLines.txt:" + File.Exists("Messages\\WriteLines.txt"));
            string[] keyArrayPathAppended = Directory.GetFiles(pathKey);

            //try
            //{   // Open the text file using a stream reader.
            //   using (StreamReader sr = new StreamReader("Config.ini"))            //this can be used to create a config file system to remember settings
            //    //using (StreamReader sr = new StreamReader("Messages\\WriteLines.txt"))
            //    {
            //      //Read the stream to a string, and write the string to the console.
            //        String line = sr.ReadToEnd(); //ReadToEnd loads the whole file into a string.
            //        char[] stringSeperator = new char[] { ';' }; //the text extracted from the file will be split on this character, more could be added if needed.
            //        string[] configSplit = line.Split(stringSeperator, StringSplitOptions.RemoveEmptyEntries);
            //        for (int i = 0; i < configSplit.Length; i++)
            //        {
            //            Console.Write(configSplit[i] + "=" + i);
            //        }
            //        Console.WriteLine();  //to make sure the next write will be on a new line without screwing up the for loop to achieve it
            //    }
            //}
            //catch (IOException e)
            //{
            //    Console.WriteLine("The file could not be read:"+"\n"+e.Message);
            //}


            //string[] lines = { "First line", "Second line", "Third line" };

            //using (StreamWriter outputFile = new StreamWriter(Path.Combine(pathMessages, "WriteLines.txt")))  //code to create new data files.
            //{
            //    foreach (string line in lines)
            //        outputFile.WriteLine(line);
            //}




            Console.Write("Enter network port: ");
            while (NetworkPort == 0)
            {
                if(int.TryParse(Console.ReadLine(), out int port)) //checks if the given input is a string. If not the user is told to enter a number. No more crashes because you accidently pressed enter.
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
                Console.Write("Enter network port: ");
                }
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
            Console.WriteLine("5. List all keys in the keys directory");
            Console.WriteLine("6. Encrypt a message, encryption key ID's are listed under 5"); 
            //Console.WriteLine("7. Decrypt a stored message"); //TODO
            Console.WriteLine("8. Multi encryption method"); 
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
                    case 5:
                        string[] keyArray = Directory.GetFiles(pathKey).Select(p => Path.GetFileName(p)).ToArray(); //Select statement with lambda is necessary to display file names without the relative path appended.
                        //Lists every file found in the map pathKey is pointing to
                        for (int i = 0; i < keyArray.Length; i++)
                        {
                            Console.WriteLine(keyArray[i]+" key ID:"+i);
                        }
                        for (int i = 0; i < keyArrayPathAppended.Length; i++)
                        {
                            Console.WriteLine(keyArrayPathAppended[i] + " key ID:" + i);
                        }
                        break;
                    case 6:

                        //This is only for testing the encryption for now.
                        Console.WriteLine("Enter the data you want encrypted: ");
                        string dataToBeEncrypted = Console.ReadLine();
                        Console.WriteLine("Enter the ID of the private key");
                        string privateKeyPath = Console.ReadLine(); //the user looks up the private and public key ÏD's with the option 5 menu and then chooses the encryption keys with the ID"s linked to the keys.
                        Console.WriteLine("Enter the ID of the public key");
                        string publicKeyPath = Console.ReadLine();
                        if (int.TryParse(privateKeyPath, out int secretPath)&&(int.TryParse(publicKeyPath, out int publicPath))) //makes sure and int is given by the user.
                        {
                            Console.WriteLine(SignAndEncryptString.StringEncrypter(dataToBeEncrypted, keyArrayPathAppended[secretPath], keyArrayPathAppended[publicPath])); // keyArrayPathAppended has all the key paths, the ID entered by the user corresponds to the array position of the key.
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Make sure to enter the numbered IDs of the keys you want to use, look them up in the 5 menu if you forgot them.");
                        }
                        break;
                    case 7:

                        break;
                    case 8:

                        Console.WriteLine("Enter the data you want to have encrypted");
                        Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                        string dataToEncrypt = Console.ReadLine();
                        string filename = unixTimestamp.ToString() + ".txt";
                        using (StreamWriter outputFile = new StreamWriter(Path.Combine(pathMessages, filename)))  //code to create new data files.
                        {

                            outputFile.WriteLine(dataToEncrypt);

                        }
                        Console.WriteLine("Enter the public key ID's for every recipient seperated by a comma(,) or a semicolon (;)");
                        string recipientIDs = Console.ReadLine();
                        char[] strSeperator = new char[] { ';',',' }; 
                        string[] recipientSplit = recipientIDs.Split(strSeperator, StringSplitOptions.RemoveEmptyEntries);
                        int[] ids = new int[recipientSplit.Length];
                        for (int i = 0; i < recipientSplit.Length; i++)
                        {
                            ids[i] = int.Parse(recipientSplit[i]);
                        }
                        string[] recipientKeyPaths = new string[ids.Length];
                        string outputFilePath = unixTimestamp.ToString() + "encrypted.pgp";
                        for (int j = 0; j < ids.Length; j++)
                        {
                            recipientKeyPaths[j] = keyArrayPathAppended[ids[j]];
                        }
                        EncryptFileMultipleRecipients encryptFileMultipleRecipients = new EncryptFileMultipleRecipients();
                        encryptFileMultipleRecipients.EncryptFileMultiRec(recipientKeyPaths, (Path.Combine(pathMessages, filename)), (Path.Combine(pathMessages, outputFilePath)));
                        try
                        {   
                            using (StreamReader sr = new StreamReader(Path.Combine(pathMessages, outputFilePath)))            
                                                                                                
                            {
                                //Read the stream to a string, and write the string to the console.
                                String line = sr.ReadToEnd(); //ReadToEnd loads the whole file into a string.
                                Console.WriteLine(line);  //to make sure the next write will be on a new line without screwing up the for loop to achieve it
                            }
                        }
                        catch (IOException e)
                        {
                            Console.WriteLine("The file could not be read:" + "\n" + e.Message);
                        }
                        File.Delete(Path.Combine(pathMessages, filename));
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
