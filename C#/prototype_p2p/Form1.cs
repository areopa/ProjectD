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
        int chainCount;

        public Form1(ParseKeyID keyIDPaths, ConfigFile configData, Client clientInstance, Server ServerInstance)
        {
            this.keyIDPaths = keyIDPaths;
            this.configData = configData;
            this.ClientInstance = clientInstance;
            this.ServerInstance = ServerInstance;
            InitializeComponent();

            // Loads the available keys in the key display box
            richTextBoxPublicKeyPaths.Text = keyIDPaths.ReturnLoadedKeyPathsAsStringNoPathPrefixed(false);
            richTextBoxPrivateKeyPaths.Text = keyIDPaths.ReturnLoadedKeyPathsAsStringNoPathPrefixed(true);
            ServerInitAt.Text = ServerInstance.serverInitAt;

            // Implemented to prevent reloading the blocknumber dropdown when no new blocks have been added
            chainCount = Program.ProjectD.ChainList.Count;

            // Loads all keys into the checkbox list
            for (int i=0; i < keyIDPaths.publicKeyArrayNoPathAppended.Length; i++) 
            {
                checkedListBoxPublicKeysToEncryptFor.Items.Add(keyIDPaths.publicKeyArrayNoPathAppended[i], false);
            }

            // Called once to initialize the chain blocknumber decrypt dropdown list
            UpdatecomboBoxBlockDecryptNumberDropDown();

            // Called once to initialize the key selector dropdown lists
            UpdatecomboBoxesDropDownKeySelectors();

            // Updates the available block numbers to decrypt on dropdown event
            this.comboBoxBlockDecryptNumber.DropDown +=
                new System.EventHandler(EventComboBoxBlockDecryptNumber_DropDown);
        }


        // Called on the dropdown event of the block number selector
        private void EventComboBoxBlockDecryptNumber_DropDown(object sender, System.EventArgs e)
        {
            // If the blocknumber count changed it updates the dropdown
            if (chainCount != Program.ProjectD.ChainList.Count)
            {
                UpdatecomboBoxBlockDecryptNumberDropDown();
            }
        }

        // Used to build the dropdown list for the block number selector
        private void UpdatecomboBoxBlockDecryptNumberDropDown()
        {
            comboBoxBlockDecryptNumber.Items.Clear();
            for (int i=1; i < Program.ProjectD.ChainList.Count; i++)
            {
                comboBoxBlockDecryptNumber.Items.Add(i);
            }
        }

        // Used to build the dropdown list for the dropdown key selectors
        private void UpdatecomboBoxesDropDownKeySelectors()
        {
            comboBoxPrivateKeyEncryptDropDown.Items.Clear();
            comboBoxPrivateKeyDecryptDropDown.Items.Clear();
            comboBoxPublicKeyDecryptDropDown.Items.Clear();
            for (int i = 0; i < keyIDPaths.privateKeyArrayNoPathAppended.Length; i++)
            {
                comboBoxPrivateKeyEncryptDropDown.Items.Add(keyIDPaths.privateKeyArrayNoPathAppended[i]);
                comboBoxPrivateKeyDecryptDropDown.Items.Add(keyIDPaths.privateKeyArrayNoPathAppended[i]);
            }
            for (int i = 0; i < keyIDPaths.publicKeyArrayNoPathAppended.Length; i++)
            {
                comboBoxPublicKeyDecryptDropDown.Items.Add(keyIDPaths.publicKeyArrayNoPathAppended[i]);
            }
        }


        private void DisplayChainFromGUI(object sender, EventArgs e)
        {
            // Opens a popup window displaying the entire chain 
            SimpleReportViewer.ShowDialog(JsonConvert.SerializeObject(Program.ProjectD, Formatting.Indented), "Chain data", this);
        }

        private void DecryptFromGUI(object sender, EventArgs e)
        {
            if (Program.ProjectD.ChainList.Count > 1) // 1 and not 0 because the genesis block counts as one.
            {
                string blockNumber;
                int blockNumerInt;
                {
                    blockNumber = comboBoxBlockDecryptNumber.Text;
                    if (int.TryParse(blockNumber, out int inputBlockNumber)) // Checks if the given input is a string. If not the user is told to enter a number. No more crashes because you accidently pressed enter.
                    {

                        if (inputBlockNumber >= Program.ProjectD.ChainList.Count)
                        {
                            MessageBox.Show("The block number you enter must correspond to an existing block. Try again.");
                        }
                        else
                        {
                            blockNumerInt = Math.Abs(inputBlockNumber);
                            string encryptedDataFromChain = Program.ProjectD.ChainList[blockNumerInt].MessageList[0].Data;
                            string privateKeyPathDecrypt = (Program.pathKeyPrivate + "\\" + comboBoxPrivateKeyDecryptDropDown.Text);
                            string publicKeyPathDecrypt = (Program.pathKeyPublic + "\\" + comboBoxPublicKeyDecryptDropDown.Text);
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

            // Resets the input boxes to display their default text again after completing the task
            comboBoxBlockDecryptNumber.Text = "Select block number";
        }


        private void EncryptfromGUI(object sender, EventArgs e)
        {
            string[] receiverNames = ReceiverNameTextBox.Lines; //not currently used        
            string receiverNamesForImprovedMultiEnc = ReceiverNameTextBox.Text;


            string privKeyPath = (Program.pathKeyPrivate + "\\" + comboBoxPrivateKeyEncryptDropDown.Text);


            //loads all checked keys into a list
            List<string> items = checkedListBoxPublicKeysToEncryptFor.CheckedItems.Cast<string>().ToList();


            //creates the path array with all the selected keys
            int cnt = 0;
            string[] recipientKeyPathsArr = new string[items.Count];
            foreach (string keyPath in items)
            {
                recipientKeyPathsArr[cnt] = (Program.pathKey + "\\" + keyPath);
                cnt++;
            }
            

            string inputData = Prompt.ShowDialog("Enter the data you want to encrypt", "Data entry");

            string encData = EncryptFileMultipleRecipients.MultiRecipientStringEncrypter(inputData, privKeyPath, recipientKeyPathsArr, true);
            Console.WriteLine(encData);

            Program.flushMsgAndSend.Flush(receiverNamesForImprovedMultiEnc, encData);
            Program.ProjectD.SaveChainStateToDisk(Program.ProjectD);

            //clears all checkex boxes
            foreach (int i in checkedListBoxPublicKeysToEncryptFor.CheckedIndices)
            {
                checkedListBoxPublicKeysToEncryptFor.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void ToggleLoadConfigSettings(object sender, EventArgs e)
        {

            configData.ToggleAutoLoadConfigValues(true);


        }

        private void ConnectServer(object sender, EventArgs e)
        {
            string serverURL = ServerUrlTextBox.Text;
            ClientInstance.Handshake($"{serverURL}/Chain");
            //TODO: add window popup with handshake
        }

        private void SaveNameAndPortToConfig_Click(object sender, EventArgs e)
        {
            //saves the entered name and port to the config file
            configData.SaveCurrentPortAndNameToConfigValues(Program.NodeName, Program.NetworkPort);
        }

        private void ButtonResetConfigFileValues_Click(object sender, EventArgs e)
        {
            configData.ResetConfigFileValues();
        }
    }
}
