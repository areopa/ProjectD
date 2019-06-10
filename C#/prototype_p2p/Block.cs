using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Security.Cryptography;


namespace prototype_p2p
{
    public class Block
    {
        public int Number { get; set; }
        public DateTime TimeCode { get; set; }
        public string FormerHashcode { get; set; }
        public string Hashcode { get; set; }
        public IList<Message> MessageList { get; set; }

        public Block(DateTime timeCode, string formerHashcode, IList<Message> messageList)
        {
            Number = 0;
            TimeCode = timeCode;
            FormerHashcode = formerHashcode;
            MessageList = messageList;
        }

        public string ComputeHashcode()
        {
            SHA256 sha256 = SHA256.Create();

            string TimeCodeString = TimeCode.ToString("yyyyMMddHHmmss");
            byte[] input = Encoding.ASCII.GetBytes($"{TimeCodeString}-{FormerHashcode ?? ""}-{JsonConvert.SerializeObject(MessageList)}");
            //Console.WriteLine("De bytes zijn" + Encoding.Default.GetString(input));
            byte[] output = sha256.ComputeHash(input);

            return Convert.ToBase64String(output);
        }

        public void AddHashcode()
        {
            this.Hashcode = this.ComputeHashcode();
        }

        public string readBlockPretty()
        {
            string result = "";
            result += "Blocknumber: " + Number;
            result += " (Time: " + TimeCode + ")\r\n";
            foreach(Message message in MessageList)
            {
                result += message.readMessagePretty() + "\r\n";
            }
            return result;
        }
    }
}
