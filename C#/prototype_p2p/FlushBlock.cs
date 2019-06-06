using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace prototype_p2p
{
    public class FlushBlock
    {

        Client ClientInstance;
        string NodeName;
        public FlushBlock(string nodeName, Client clientInstance)
        { 
            this.NodeName = nodeName;
            this.ClientInstance = clientInstance;
        }
        public void Flush(string receiverName, string data)
        {
            Program.ProjectD.CreateMessage(new Message(NodeName, receiverName, data));
            Program.ProjectD.ProcessMessageQueue(NodeName);
            ClientInstance.SendToAll(JsonConvert.SerializeObject(Program.ProjectD));
        }
    }
}
