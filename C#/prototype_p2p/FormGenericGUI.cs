using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Windows.Forms;
using WebSocketSharp;


namespace prototype_p2p
{
    public partial class FormGenericGUI : Form
    {
        ParseKeyID keyIDPaths;
        ConfigFile configData;
        Client ClientInstance;
        Server ServerInstance;
        int chainCount;

        public FormGenericGUI(ParseKeyID keyIDPaths, ConfigFile configData, Client clientInstance, Server ServerInstance)
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
            textBoxCurrentActiveRole.Text = Program.currentRole;
            textBoxNodeName.Text = Program.NodeName;

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
            richTextBoxStatusUpdates.AppendText(keyIDPaths.roleKeyPaths["OM"]+Environment.NewLine);
            richTextBoxStatusUpdates.AppendText(keyIDPaths.roleKeyPaths["Gemeente"] + Environment.NewLine);
            richTextBoxStatusUpdates.AppendText(keyIDPaths.roleKeyPaths["Reclassering"] + Environment.NewLine);
            richTextBoxStatusUpdates.AppendText(keyIDPaths.roleKeyPaths["Politie"] + Environment.NewLine);
            TabInit(); // Removes all tabs that do not match the current role
        }

        
        private void TabInit()
        {
            foreach(TabPage tabRole in tabControl1.TabPages)
            {
                //if(tabRole.Text)
                if (tabRole.Text != Program.currentRole)
                    tabControl1.TabPages.Remove(tabRole);


            }
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
            comboBoxPrivateKeyReclasseringEncryptDropDown.Items.Clear();
            comboBoxPrivateKeyPolitieEncryptDropDown.Items.Clear();
            comboBoxPrivateKeyOMEncryptDropDown.Items.Clear();
            comboBoxPrivateKeyGemeenteEncryptDropDown.Items.Clear();

            for (int i = 0; i < keyIDPaths.privateKeyArrayNoPathAppended.Length; i++)
            {
                comboBoxPrivateKeyEncryptDropDown.Items.Add(keyIDPaths.privateKeyArrayNoPathAppended[i]);
                comboBoxPrivateKeyDecryptDropDown.Items.Add(keyIDPaths.privateKeyArrayNoPathAppended[i]);
                comboBoxPrivateKeyReclasseringEncryptDropDown.Items.Add(keyIDPaths.privateKeyArrayNoPathAppended[i]);
                comboBoxPrivateKeyPolitieEncryptDropDown.Items.Add(keyIDPaths.privateKeyArrayNoPathAppended[i]);
                comboBoxPrivateKeyOMEncryptDropDown.Items.Add(keyIDPaths.privateKeyArrayNoPathAppended[i]);
                comboBoxPrivateKeyGemeenteEncryptDropDown.Items.Add(keyIDPaths.privateKeyArrayNoPathAppended[i]);
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

        private void displayChainVisual_Click(object sender, EventArgs e)
        {
            //Opens a popup window displaying the chain in pretty format
            SimpleReportViewer.ShowDialog(Program.ProjectD.ReadChainPretty(), "Chain data (pretty)", this);
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
        }

        private void EncryptionCaller(string[] recipientKeyPathsArr = null, string inputData = "", string privKeyPath = "")
        {
            string receiverNamesForImprovedMultiEnc = ReceiverNameTextBox.Text;

            if (privKeyPath == "")
            {
                privKeyPath = (Program.pathKeyPrivate + "\\" + comboBoxPrivateKeyEncryptDropDown.Text);
            }

            //loads all checked keys into a list
            List<string> items = checkedListBoxPublicKeysToEncryptFor.CheckedItems.Cast<string>().ToList();

            if (recipientKeyPathsArr == null)
            {
                //creates the path array with all the selected keys
                int cnt = 0;
                recipientKeyPathsArr = new string[items.Count];
                foreach (string keyPath in items)
                {
                    recipientKeyPathsArr[cnt] = (Program.pathKeyPublic + "\\" + keyPath);
                    cnt++;
                }
            }

            if (inputData == "")
            {
                inputData = Prompt.ShowDialog("Enter the data you want to encrypt", "Data entry");
            }

            string encData = EncryptFileMultipleRecipients.MultiRecipientStringEncrypter(inputData, privKeyPath, recipientKeyPathsArr, true);
            Console.WriteLine(encData);

            Program.flushMsgAndSend.Flush(receiverNamesForImprovedMultiEnc, encData);
            Program.ProjectD.SaveChainStateToDisk(Program.ProjectD);

            //clears all checked boxes
            foreach (int i in checkedListBoxPublicKeysToEncryptFor.CheckedIndices)
            {
                checkedListBoxPublicKeysToEncryptFor.SetItemCheckState(i, CheckState.Unchecked);
            }

        }


        private void EncryptfromGUI(object sender, EventArgs e)
        {

            EncryptionCaller();
        }

        private void ToggleLoadConfigSettings(object sender, EventArgs e)
        {

            configData.ToggleAutoLoadConfigValues(true);


        }

        private void ConnectServer(object sender, EventArgs e)
        {
            string serverURL = ServerUrlTextBox.Text;
            ClientInstance.Handshake($"{serverURL}/Chain");
            // The code that updates the status box can be found in the Server class
        }

        private void SaveName_PortAndRoleToConfig_Click(object sender, EventArgs e)
        {
            // Saves the entered name and port to the config file
            configData.SaveCurrentPort_NameAndRoleToConfigValues(Program.NodeName, Program.NetworkPort, Program.currentRole);
        }

        private void ButtonResetConfigFileValues_Click(object sender, EventArgs e)
        {
            configData.ResetConfigFileValues();
        }

        private void connectionUpdateButton_Click(object sender, EventArgs e)
        {

            string message = "";

            if (Client.socketDictionary != null)
            {

                foreach (var item in Client.socketDictionary)
                {
                    if (message.Equals("No connections"))
                    {
                        message = "";
                    }

                    WebSocket socket = new WebSocket(item.Key);
                    socket.Connect();

                    if (socket.IsAlive)
                    {
                        message = message + item.Key + " : connection alive \r\n";
                    }
                    else
                    {
                        message = message + item.Key + " : connection broken \r\n";
                    }
                }
            }
            else
            {
                message = "no connections";
            }


            richTextBoxConnections.Text = message;
            


        }

        private void FormGenericGUI_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label12.Text = DateTime.Now.ToLongDateString();
            label13.Text = DateTime.Now.ToLongTimeString();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label13.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void button_Open_Keys_Folder_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(System.IO.Directory.GetParent(Program.pathKeyPublic).FullName);
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button_Open_Config_File_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"Config.ini");
        }

        public void Reclassering_DataEntry()
        {
            try
            {
                string dataToRetrieve = "";
                Reclassering_DataEntry testDialog = new Reclassering_DataEntry();
                // Show testDialog as a modal dialog and determine if DialogResult = OK.
                if (testDialog.ShowDialog(this) == DialogResult.OK)
                {
                    // Read the contents of testDialog's TextBox.
                    dataToRetrieve = "Lopend traject: " + testDialog.textBoxReclassering_DataEntry_Lopend_Traject.Text + Environment.NewLine;
                    dataToRetrieve += "Laatste gesprek: " + testDialog.dateTimePickerReclassering_DataEntry_Laatste_Gesprek.Text + Environment.NewLine;
                    dataToRetrieve += "BSN: " + testDialog.textBoxReclassering_DataEntry_BSN.Text + Environment.NewLine;
                    dataToRetrieve += "Achternaam: " + testDialog.textBoxReclassering_DataEntry_Achternaam.Text + Environment.NewLine;
                    dataToRetrieve += "Geb datum: " + testDialog.dateTimePickerReclassering_DataEntry_Geb_Datum.Text + Environment.NewLine;
                    string[] recipient_Role_Paths = new string[4];
                    int cnt = 0;

                    foreach (var pair in keyIDPaths.roleKeyPaths)
                    {
                        recipient_Role_Paths[cnt] = pair.Value;
                        cnt++;
                    }

                    EncryptionCaller(recipient_Role_Paths, dataToRetrieve, (Program.pathKeyPrivate + "\\" + comboBoxPrivateKeyReclasseringEncryptDropDown.Text));
                }
                testDialog.Dispose();
            }
            catch(Exception e)
            {
                if(e is System.IO.DirectoryNotFoundException)
                {
                    MessageBox.Show("You didn't select a private key!");
                }
            }
        }

        private void Data_Invoer_Reclassering_Button_Click(object sender, EventArgs e)
        {
            Reclassering_DataEntry();
        }

        public void OM_DataEntry()
        {
            try
            {
                string dataToRetrieve = "";
                OM_DataEntry testDialog = new OM_DataEntry();
                // Show testDialog as a modal dialog and determine if DialogResult = OK.
                if (testDialog.ShowDialog(this) == DialogResult.OK)
                {
                    // Read the contents of testDialog's TextBox.
                    dataToRetrieve = "Lopend traject: " + testDialog.textBoxReclassering_DataEntry_Lopend_Traject.Text + Environment.NewLine;
                    dataToRetrieve += "Laatste gesprek: " + testDialog.dateTimePickerReclassering_DataEntry_Laatste_Gesprek.Text + Environment.NewLine;
                    dataToRetrieve += "BSN: " + testDialog.textBoxReclassering_DataEntry_BSN.Text + Environment.NewLine;
                    dataToRetrieve += "Achternaam: " + testDialog.textBoxReclassering_DataEntry_Achternaam.Text + Environment.NewLine;
                    dataToRetrieve += "Geb datum: " + testDialog.dateTimePickerReclassering_DataEntry_Geb_Datum.Text + Environment.NewLine;
                    string[] recipient_Role_Paths = new string[4];
                    int cnt = 0;

                    foreach (var pair in keyIDPaths.roleKeyPaths)
                    {
                        recipient_Role_Paths[cnt] = pair.Value;
                        cnt++;
                    }

                    EncryptionCaller(recipient_Role_Paths, dataToRetrieve, (Program.pathKeyPrivate + "\\" + comboBoxPrivateKeyReclasseringEncryptDropDown.Text));
                }
                testDialog.Dispose();
            }
            catch (Exception e)
            {
                if (e is System.IO.DirectoryNotFoundException)
                {
                    MessageBox.Show("You didn't select a private key!");
                }
            }
        }
        private void Data_Invoer_OM_Button_Click(object sender, EventArgs e)
        {

        }
        public void Gemeente_DataEntry()
        {
            try
            {
                string dataToRetrieve = "";
                Gemeente_DataEntry testDialog = new Gemeente_DataEntry();
                // Show testDialog as a modal dialog and determine if DialogResult = OK.
                if (testDialog.ShowDialog(this) == DialogResult.OK)
                {
                    // Read the contents of testDialog's TextBox.
                    dataToRetrieve = "Lopend traject: " + testDialog.textBoxReclassering_DataEntry_Lopend_Traject.Text + Environment.NewLine;
                    dataToRetrieve += "Laatste gesprek: " + testDialog.dateTimePickerReclassering_DataEntry_Laatste_Gesprek.Text + Environment.NewLine;
                    dataToRetrieve += "BSN: " + testDialog.textBoxReclassering_DataEntry_BSN.Text + Environment.NewLine;
                    dataToRetrieve += "Achternaam: " + testDialog.textBoxReclassering_DataEntry_Achternaam.Text + Environment.NewLine;
                    dataToRetrieve += "Geb datum: " + testDialog.dateTimePickerReclassering_DataEntry_Geb_Datum.Text + Environment.NewLine;
                    string[] recipient_Role_Paths = new string[4];
                    int cnt = 0;

                    foreach (var pair in keyIDPaths.roleKeyPaths)
                    {
                        recipient_Role_Paths[cnt] = pair.Value;
                        cnt++;
                    }

                    EncryptionCaller(recipient_Role_Paths, dataToRetrieve, (Program.pathKeyPrivate + "\\" + comboBoxPrivateKeyReclasseringEncryptDropDown.Text));
                }
                testDialog.Dispose();
            }
            catch (Exception e)
            {
                if (e is System.IO.DirectoryNotFoundException)
                {
                    MessageBox.Show("You didn't select a private key!");
                }
            }
        }

        private void Data_Invoer_Gemeente_Button_Click(object sender, EventArgs e)
        {

        }
        public void Politie_DataEntry()
        {
            try
            {
                string dataToRetrieve = "";
                Politie_DataEntry testDialog = new Politie_DataEntry();
                // Show testDialog as a modal dialog and determine if DialogResult = OK.
                if (testDialog.ShowDialog(this) == DialogResult.OK)
                {
                    // Read the contents of testDialog's TextBox.
                    dataToRetrieve = "Lopend traject: " + testDialog.textBoxReclassering_DataEntry_Lopend_Traject.Text + Environment.NewLine;
                    dataToRetrieve += "Laatste gesprek: " + testDialog.dateTimePickerReclassering_DataEntry_Laatste_Gesprek.Text + Environment.NewLine;
                    dataToRetrieve += "BSN: " + testDialog.textBoxReclassering_DataEntry_BSN.Text + Environment.NewLine;
                    dataToRetrieve += "Achternaam: " + testDialog.textBoxReclassering_DataEntry_Achternaam.Text + Environment.NewLine;
                    dataToRetrieve += "Geb datum: " + testDialog.dateTimePickerReclassering_DataEntry_Geb_Datum.Text + Environment.NewLine;
                    string[] recipient_Role_Paths = new string[4];
                    int cnt = 0;

                    foreach (var pair in keyIDPaths.roleKeyPaths)
                    {
                        recipient_Role_Paths[cnt] = pair.Value;
                        cnt++;
                    }

                    EncryptionCaller(recipient_Role_Paths, dataToRetrieve, (Program.pathKeyPrivate + "\\" + comboBoxPrivateKeyReclasseringEncryptDropDown.Text));
                }
                testDialog.Dispose();
            }
            catch (Exception e)
            {
                if (e is System.IO.DirectoryNotFoundException)
                {
                    MessageBox.Show("You didn't select a private key!");
                }
            }
        }

        private void Data_Invoer_Politie_Button_Click(object sender, EventArgs e)
        {

        }
    }
}
