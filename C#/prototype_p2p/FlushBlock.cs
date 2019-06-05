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
        Chain ProjectD;
        Client ClientInstance;
        string NodeName;
        public FlushBlock(Chain projectD, string nodeName, Client clientInstance)
        {
            this.ProjectD = projectD;
            this.NodeName = nodeName;
            this.ClientInstance = clientInstance;
        }
        public void Flush(string receiverName, string data)
        {
            ProjectD.CreateMessage(new Message(NodeName, receiverName, data));
            ProjectD.ProcessMessageQueue(NodeName);
            ClientInstance.SendToAll(JsonConvert.SerializeObject(ProjectD));
        }
    }
}
