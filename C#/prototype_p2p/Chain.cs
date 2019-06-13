using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace prototype_p2p
{
    public class Chain
    {
        public IList<Message> MessageQueue = new List<Message>();
        public IList<Block> ChainList { set; get; }
        public string chainPath = @"chain.json";

        public Chain()
        {
            CheckDevChain();
        }

        public void CheckDevChain()
        {
            if (Directory.Exists(@"..\\..\\chain"))
            {
                if (File.Exists(@"..\\..\\chain\chain.json"))
                {
                    chainPath = @"..\\..\\chain\chain.json";
                }
                else
                {
                    chainPath = @"chain.json";
                }
            }
            else
            {
                chainPath = @"chain.json";
            }
        }

        public string ReadChainPretty()
        {

            string result = "";
            foreach(Block block in ChainList)
            {
                result += block.readBlockPretty() + "\r\n";
            }
            return result;
        }
       
        public void ReadChain()
        {
            try
            {
                using (StreamReader sr = new StreamReader(chainPath))// @ is for relative path
                {
                    string json = sr.ReadToEnd();
                    Console.WriteLine("Reading from previous state...");
                    Chain deserializedChain = JsonConvert.DeserializeObject<Chain>(json);
                    MessageQueue = deserializedChain.MessageQueue;
                    ChainList = deserializedChain.ChainList;
                    Console.WriteLine("Done.");
                    Console.WriteLine($"Length of chain: {deserializedChain.ChainList.Count}\n");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Cannot find a previous state. Creating a fresh blockchain... \n");
                Console.WriteLine("Done. \n");
            }
        }

        public void SetupChain()
        {
            ChainList = new List<Block>();
            AddPrimary();
        }

        public Block CreatePrimary()
        {
            Block block = new Block(DateTime.Now, null, MessageQueue);
            block.AddHashcode();
            MessageQueue = new List<Message>();
            return block;
        }

        public void AddPrimary()
        {
            ChainList.Add(CreatePrimary());
        }

        public Block GetFormer()
        {
            return ChainList[ChainList.Count - 1];
        }

        public void CreateMessage(Message message)
        {
            MessageQueue.Add(message);
        }
        public void ProcessMessageQueue(string receiver)
        {
            Block block = new Block(DateTime.Now, GetFormer().Hashcode, MessageQueue);
            AddBlock(block);

            MessageQueue = new List<Message>();
        }

        public void AddBlock(Block block)
        {
            Block formerBlock = GetFormer();
            block.Number = formerBlock.Number + 1;
            block.FormerHashcode = formerBlock.Hashcode;
            //block.Hash = block.CalculateHash();
            block.AddHashcode();
            ChainList.Add(block);
        }
        public void SaveChainStateToDisk(Chain ProjectD)
        {
            CheckDevChain();
            using (StreamWriter file = File.CreateText(chainPath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, ProjectD);
            }
        }

        public bool CheckIntegrity()
        {
            for (int i = 1; i < ChainList.Count; i++)
            {
                Block thisBlock = ChainList[i];
                Block formerBlock = ChainList[i - 1];

                if (thisBlock.Hashcode != thisBlock.ComputeHashcode()) { return false; }

                if (thisBlock.FormerHashcode != formerBlock.Hashcode) { return false; }
            }

            return true;
        }
    }
}
