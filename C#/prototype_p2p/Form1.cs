using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace prototype_p2p
{
    public partial class Form1 : Form
    {
        ParseKeyID keyIDPaths;
        ConfigFile configData;
        Client ClientInstance;
        Server ServerInstance;

        public Form1(ParseKeyID keyIDPaths, ConfigFile configData, Client clientInstance, Server ServerInstance)
        {
            this.keyIDPaths = keyIDPaths;
            this.configData = configData;
            this.ClientInstance = clientInstance;
            this.ServerInstance = ServerInstance;
            InitializeComponent();
           // richTextBoxKeyPaths.ReadOnly = false;
            richTextBoxKeyPaths.Text = keyIDPaths.ReturnAllLoadedKeyPathsAsStringNoPathPrefixed();
            // richTextBoxKeyPaths.ReadOnly = true;
            ServerInitAt.Text = ServerInstance.serverInitAt;
        }




        private void DisplayChainFromGUI(object sender, EventArgs e)
        {

            SimpleReportViewer.ShowDialog(JsonConvert.SerializeObject(Program.ProjectD, Formatting.Indented), "Chain data", this);
        }

        private void DecryptFromGUI(object sender, EventArgs e)
        {
            if (Program.ProjectD.ChainList.Count > 1) //1 and not 0 because the genesis block counts as one.
            {
                string blockNumber;
                int blockNumerInt;
                {
                    blockNumber = BlockNumberDecrypt.Text;
                    if (int.TryParse(blockNumber, out int inputBlockNumber)) //checks if the given input is a string. If not the user is told to enter a number. No more crashes because you accidently pressed enter.
                    {

                        if (inputBlockNumber >= Program.ProjectD.ChainList.Count)
                        {
                            MessageBox.Show("The block number you enter must correspond to an existing block. Try again.");
                        }
                        else
                        {
                            blockNumerInt = Math.Abs(inputBlockNumber);
                            string encryptedDataFromChain = Program.ProjectD.ChainList[blockNumerInt].MessageList[0].Data;
                            string privateKeyPathDecrypt = keyIDPaths.ParseAndReturnVerifiedKeyPathGUI(PrivateKeyDecrypt.Text);
                            string publicKeyPathDecrypt = keyIDPaths.ParseAndReturnVerifiedKeyPathGUI(PublicKeyVerify.Text);
                            DecryptAndVerifyString.Decrypt(encryptedDataFromChain, privateKeyPathDecrypt, publicKeyPathDecrypt,true);
                        }
                    }
                    else
                    {
                        MessageBox.Show("The number of the block has to be a number. Try again.");
                    }
                }

               
            }
            else
            {
                MessageBox.Show("There are no blocks to decrypt!");
            }
            BlockNumberDecrypt.Text = "";
            PublicKeyVerify.Text = "";
            PrivateKeyDecrypt.Text = "";
        }

        private void DisplayAllKeysGUI(object sender, EventArgs e)
        {

            SimpleReportViewer.ShowDialog(keyIDPaths.ReturnAllLoadedKeyPathsAsString(), "All known keys", this);
        }

        private void EncryptfromGUI(object sender, EventArgs e)
        {
            string[] receiverNames = ReceiverNameTextBox.Lines;         
            string receiverNamesForImprovedMultiEnc = ReceiverNameTextBox.Text;


            string privKeyPath = keyIDPaths.ParseAndReturnVerifiedKeyPathGUI(PrivateKeyIdTextBox.Text);


            string[] recipientKeyPathsArr = keyIDPaths.BuildVerifiedKeyIdPathArrayGUI(ReceiverKeyIdTextBox.Text);

            string inputData = Prompt.ShowDialog("Enter the data you want to encrypt", "Data entry");

            string encData = EncryptFileMultipleRecipients.MultiRecipientStringEncrypter(inputData, privKeyPath, recipientKeyPathsArr, true);
            Console.WriteLine(encData);

            Program.flushMsgAndSend.Flush(receiverNamesForImprovedMultiEnc, encData);
            Program.ProjectD.SaveChainStateToDisk(Program.ProjectD);
            ReceiverNameTextBox.Text = "";
            ReceiverKeyIdTextBox.Text = "";
            PrivateKeyIdTextBox.Text = "";
        }

        private void ToggleLoadConfigSettings(object sender, EventArgs e)
        {

            configData.ToggleAutoLoadConfigValues(true);


        }

        private void ConnectServer(object sender, EventArgs e)
        {
            string serverURL = ServerUrlTextBox.Text;
            ClientInstance.Handshake($"{serverURL}/Chain");
        }
    }
}
