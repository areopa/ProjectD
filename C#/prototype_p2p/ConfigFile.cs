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
        public ConfigFile()
        {
            InitConfigFile();
            configSettings = LoadConfigFileData();
            LoadConfigValues();
            IsInitialized = true;
            
        }
        // public static Dictionary<string, string> configSettings = new Dictionary<string, string>();

        private void InitConfigFile(bool reset = false)
        {
            if (!File.Exists("Config.ini") || reset)
            {
                Console.WriteLine("Generating default Config.ini");
                File.WriteAllText("Config.ini", "To disable a particular config setting place 2 equals (=) signs on that line or leave the space after the \"=\" blank\n" +
                    "useConfigFile=false\n" +
                    "NetworkPort=\n" +
                    "NodeName=\n" +
                    "pathKeyPrivate=" + Program.pathKeyPrivate + "\n" +
                    "pathKeyPublic=" + Program.pathKeyPublic + "\n" +
                    "currentRole=\n");
            }
        }

        public void ResetConfigFileValues()
        {
            InitConfigFile(true);
            MessageBox.Show("Config file settings successfully reset to default");
        }

        //populates the public configsettings dictionary in this class
        private Dictionary<string,string> LoadConfigFileData()
        {
            try
            {
                Dictionary<string, string> configSettings = new Dictionary<string, string>();
                // Open the config file using a stream reader.
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
                Console.WriteLine("The file could not be read:" + Environment.NewLine + e.Message);
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

        //checks if the values entered in the config file are valid and loads them
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
                    if (configSettings.TryGetValue("pathKeyPublic", out string altPublicKeyPath))
                    {
                        Program.pathKeyPublic = altPublicKeyPath;
                    }
                    if (configSettings.TryGetValue("pathKeyPrivate", out string altPrivateKeyPath))
                    {
                        Program.pathKeyPrivate = altPrivateKeyPath;
                    }
                    if (configSettings.TryGetValue("currentRole", out string currentRoleInConfig))
                    {
                        if (Program.existingRoles.Contains(currentRoleInConfig))
                        {
                            Program.currentRole = currentRoleInConfig;
                        }
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
            catch (Exception e)
            {
                if (e is UnauthorizedAccessException)
                {
                    Console.WriteLine("No access authorization!");
                }
                else
                {
                    MessageBox.Show("Exception occured: "+e);
                }
            }
        }

        public void SaveCurrentPort_NameAndRoleToConfigValues(string nameToSet, int portToSet, string roleToSet)
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

                configSettings["currentRole"] = roleToSet;
                
                using (StreamWriter file = new StreamWriter("Config.ini"))
                {
                    file.WriteLine("//== Use two or more = characters in one line to prevent the program from loading it or leave the part after the = empty");
                    foreach (var entry in configSettings)
                    {
                        file.WriteLine("{0}{1}{2}", entry.Key, "=", entry.Value);
                    }
                }
                MessageBox.Show("Settings saved: " + "NodeName = " + configSettings["NodeName"] + " NetworkPort = " + configSettings["NetworkPort"] + " currentRole = " + configSettings["currentRole"]);
            }
            catch (Exception e)
            {
                if (e is UnauthorizedAccessException)
                {
                    Console.WriteLine("No access authorization!");
                }
                else
                {
                    MessageBox.Show("Exception occured: " + e);
                }
            }
        }


    }
}
