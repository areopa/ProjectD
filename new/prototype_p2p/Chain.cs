﻿using System;
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

        public Chain()
        {

        }
       
        public void ReadChain()
        {
            string workingDirectory = AppDomain.CurrentDomain.BaseDirectory;
            try
            {
                using (StreamReader sr = new StreamReader(workingDirectory + "\\chain.json"))
                {
                    string json = sr.ReadToEnd();
                    Console.WriteLine("Reading from previous state...\n");
                    Chain deserializedChain = JsonConvert.DeserializeObject<Chain>(json);
                    MessageQueue = deserializedChain.MessageQueue;
                    ChainList = deserializedChain.ChainList;
                    Console.WriteLine("Done.\n");
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
