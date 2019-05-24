using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prototype_p2p
{
    public class Chain
    {
        public IList<Message> MessageQueue = new List<Message>();
        public IList<Block> ChainList { set; get; }

        public Chain()
        {

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
