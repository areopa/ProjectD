using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace prototype_p2p
{
     class ConfigFile
    {
        public static void InitConfigFile()
        {
            if (!File.Exists("Config.ini"))
            {
                File.WriteAllText("Config.ini", "//== Use two or more = characters in one line to prevent the program from loading it\n" +
                    "useConfigFile=false\n" +
                    "NetworkPort=\n" +
                    "NodeName=\n" +
                    "pathKey=");
            }
        }


    }
}
