using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prototype_p2p
{
    public class Message
    {
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Data { get; set; }

        public Message(string sender, string receiver, string data)
        {
            Sender = sender;
            Receiver = receiver;
            Data = data;
        }

        public string readMessagePretty()
        {
            string result = "";
            result += "Sender: " + Sender + "\r\nReceiver(s): " + Receiver;
            return result;
        }
    }
}
