using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace prototype_p2p
{
     public class ConfigFile
    {

        public Dictionary<string, string> configSettings;
        public bool IsInitialized;
        public ConfigFile(string keysPath)
        {
            InitConfigFile(keysPath);
            configSettings = LoadConfigFileData();
            LoadConfigValues();
            IsInitialized = true;
            
        }
        // public static Dictionary<string, string> configSettings = new Dictionary<string, string>();

        private void InitConfigFile(string keysPath)
        {
            if (!File.Exists("Config.ini"))
            {
                Console.WriteLine("Generating default Config.ini");
                File.WriteAllText("Config.ini", "//== Use two or more = characters in one line to prevent the program from loading it or leave the part after the = empty\n" +
                    "useConfigFile=false\n" +
                    "NetworkPort=\n" +
                    "NodeName=Unknown\n" +
                    "pathKey="+Program.pathKey);
            }
        }

        private Dictionary<string,string> LoadConfigFileData()
        {
            try
            {
                Dictionary<string, string> configSettings = new Dictionary<string, string>();
                // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader("Config.ini"))            
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] keyvalue = line.Split('=');
                        if (keyvalue.Length == 2)
                        {
                            configSettings.Add(keyvalue[0], keyvalue[1]);
                        }
                    }
                }
                return configSettings;
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:" + "\n" + e.Message);
            }
            throw new ApplicationException("Something went wrong with loading the config file data");
        }

        public void WriteAllValuesConsole()
        {
            foreach (var pair in configSettings)
            {
                Console.WriteLine($"Setting:{pair.Key} Value:{pair.Value}");
            }
        }
        private void LoadConfigValues()
        {
            if (configSettings.TryGetValue("useConfigFile", out string value))
            {
                if (value.ToLower() == "true")
                {
                    if (configSettings.TryGetValue("NetworkPort", out string portVal))
                    {
                        if (int.TryParse(portVal, out int portValInt))
                        {
                            if (!Program.portBlacklist.Contains(portValInt))
                            {
                                Program.NetworkPort = Math.Abs(portValInt);
                            }

                        }
                    }
                    if (configSettings.TryGetValue("NodeName", out string nodeNameVal))
                    {
                        Program.NodeName = nodeNameVal;
                    }
                    if (configSettings.TryGetValue("pathKey", out string altKeyPath))
                    {
                        Program.pathKey = altKeyPath;
                    }

                }
            }
        }
        public void ToggleAutoLoadConfigValues(bool gui = false)
        {
            try
            {
                if (configSettings.TryGetValue("useConfigFile", out string useConfigVal))
                {
                    if (useConfigVal.ToLower() == "true")
                    {
                        configSettings["useConfigFile"] = "false";
                    }
                    else if (useConfigVal.ToLower() == "false")
                    {
                        configSettings["useConfigFile"] = "true";
                    }
                }
                using (StreamWriter file = new StreamWriter("Config.ini"))
                {
                    file.WriteLine("//== Use two or more = characters in one line to prevent the program from loading it or leave the part after the = empty");
                    foreach (var entry in configSettings)
                    {
                        file.WriteLine("{0}{1}{2}", entry.Key, "=", entry.Value);
                    }
                }
                if (!gui)
                {
                    Console.WriteLine("Change will go in effect next application restart.");
                }
                else
                {
                    MessageBox.Show("Change will go in effect next application restart: "+ "useConfigFile = "+configSettings["useConfigFile"]);
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("No access authorization!");
            }
        }
        public void SaveCurrentPortAndNameToConfigValues(string nameToSet, int portToSet)
        {
            try
            {
                if (configSettings.TryGetValue("NodeName", out string nodeName))
                {
                        configSettings["NodeName"] = nameToSet;
                }
                if (configSettings.TryGetValue("NetworkPort", out string networkPort))
                {
                    configSettings["NetworkPort"] = portToSet.ToString();
                }
                using (StreamWriter file = new StreamWriter("Config.ini"))
                {
                    file.WriteLine("//== Use two or more = characters in one line to prevent the program from loading it or leave the part after the = empty");
                    foreach (var entry in configSettings)
                    {
                        file.WriteLine("{0}{1}{2}", entry.Key, "=", entry.Value);
                    }
                }
                MessageBox.Show("Settings saved: " + "NodeName = " + configSettings["NodeName"] + " NetworkPort = " + configSettings["NetworkPort"]);
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("No access authorization!");
            }
        }


    }
}
