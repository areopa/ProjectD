﻿using System;
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
            for (int i = 0; i < keyIDPaths.publicKeyArrayNoPathAppended.Length; i++)
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
            //TabInit(); // Removes all tabs that do not match the current role

            this.ServerInitAt.Click +=
                new EventHandler(EventServerInitAtClipboard_OnClick);
            TabInit(); // Removes all tabs that do not match the current role
        }


        private void TabInit()
        {
            foreach (TabPage tabRole in tabControl1.TabPages)
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
            for (int i = 1; i < Program.ProjectD.ChainList.Count; i++)
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
                            DecryptAndVerifyString.Decrypt(encryptedDataFromChain, privateKeyPathDecrypt, publicKeyPathDecrypt, true);
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

        private void EncryptionCaller(string[] recipientKeyPathsArr = null, string inputData = "", string privKeyPath = "", bool Precoded = false, string receiversPrecoded = null)
        {
            string receiverNamesForImprovedMultiEnc = "";
           

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


            if (!Precoded)
            {
                 receiverNamesForImprovedMultiEnc = ReceiverNameTextBox.Text;
            }
            else
            {
                receiverNamesForImprovedMultiEnc = receiversPrecoded;
            }

            //Checken of er recipients null zijn. Anders verwijderen
            recipientKeyPathsArr = recipientKeyPathsArr.Where(c => c != null).ToArray();

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
            string result = "";
            List<string> list = new List<string>();
            list = ClientInstance.PingAll();
            foreach (var item in list)
            {
                result += item + "\n";
            }

            richTextBoxConnections.Text = result;
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


        /*
         * De finish knop in de Reclassering_DataEntry form heeft Properties -> Behavior -> DialogResult op "OK" staan, zonder deze setting werkt de data input niet.
         * Ik heb de Reclassering_DataEntry() functie en de Reclassering_DataEntry form 3x gekopieërd en gerenamed. Deze moeten wel allemaal gevuld worden met de correcte textboxen en code.
         * Waarschijnlijk zijn er nog meer forms nodig.
         * Elke tab in de main form heeft al 1 data invoer knop en een werkende private key dropdown.
         * in de OM, Politie, Gemeente en Reclassering mappen in de Keys\Public folder mogen maar 1 key, de logica gaat er vanuit dat de correcte key daarin geplaatst is. 
        */

        public void Reclassering_DataEntry()
        {
            try
            {
                string dataToRetrieve = "";
                Reclassering_DataEntry testDialog = new Reclassering_DataEntry();
                // Show testDialog as a modal dialog and determine if DialogResult = OK.
                if (testDialog.ShowDialog(this) == DialogResult.OK)
                {
                    // Read the contents of testDialog's data fields
                    // Alle data moet in 1 string staan voor de encryptie functie.
                    dataToRetrieve = "Lopend traject: " + testDialog.textBoxReclassering_DataEntry_Lopend_Traject.Text + Environment.NewLine;
                    dataToRetrieve += "Laatste gesprek: " + testDialog.dateTimePickerReclassering_DataEntry_Laatste_Gesprek.Text + Environment.NewLine;
                    dataToRetrieve += "BSN: " + testDialog.textBoxReclassering_DataEntry_BSN.Text + Environment.NewLine;
                    dataToRetrieve += "Achternaam: " + testDialog.textBoxReclassering_DataEntry_Achternaam.Text + Environment.NewLine;
                    dataToRetrieve += "Geb datum: " + testDialog.dateTimePickerReclassering_DataEntry_Geb_Datum.Text + Environment.NewLine;


                    // Maakt de ontvangers lijst, het aantal partijen dat de data mag lezen + 1 (voor de eigen rol) is de size van de array.
                    string[] recipient_Role_Paths = new string[4];
                    int cnt = 0;
                    // Je kan een rol hier uitsluiten met
                    // if (pair.Key != "OM") { recipient_Role_Paths[cnt] = pair.Value; } voeg met || zonodig meer rollen toe om uit te sluiten. Iedereen behalve OM staat nu in de ontvangst lijst met dit voorbeeld.
                    foreach (var pair in keyIDPaths.roleKeyPaths)
                    {
                        recipient_Role_Paths[cnt] = pair.Value;
                        cnt++;
                    }

                    // Zonder parameters worden de bestaande encryptie data velden gebruikt.
                    EncryptionCaller(recipient_Role_Paths, dataToRetrieve, (Program.pathKeyPrivate + "\\" + comboBoxPrivateKeyReclasseringEncryptDropDown.Text), true, "Gemeente, Politie, Reclassering, OM");
                }
                // Zonder deze dispose blijft de form in memory.
                testDialog.Dispose();
            }
            catch (Exception e)
            {   // Voor als de user vergeet een key in de dropdown te selecteren.
                if (e is System.IO.DirectoryNotFoundException)
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
                    //dataToRetrieve = "Lopend traject: " + testDialog.textBoxReclassering_DataEntry_Lopend_Traject.Text + Environment.NewLine;
                    //dataToRetrieve += "Laatste gesprek: " + testDialog.dateTimePickerReclassering_DataEntry_Laatste_Gesprek.Text + Environment.NewLine;
                    //dataToRetrieve += "BSN: " + testDialog.textBoxReclassering_DataEntry_BSN.Text + Environment.NewLine;
                    //dataToRetrieve += "Achternaam: " + testDialog.textBoxReclassering_DataEntry_Achternaam.Text + Environment.NewLine;
                    //dataToRetrieve += "Geb datum: " + testDialog.dateTimePickerReclassering_DataEntry_Geb_Datum.Text + Environment.NewLine;
                    string[] recipient_Role_Paths = new string[4];
                    int cnt = 0;

                    foreach (var pair in keyIDPaths.roleKeyPaths)
                    {
                        recipient_Role_Paths[cnt] = pair.Value;
                        cnt++;
                    }

                    EncryptionCaller(recipient_Role_Paths, dataToRetrieve, (Program.pathKeyPrivate + "\\" + comboBoxPrivateKeyReclasseringEncryptDropDown.Text), true);
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
        
        public void Politie_DataEntry_ZSM_Radicalen()
        {
            try
            {
                string dataToRetrieve = "";
                Politie_DataEntry_ZSM_Radicalen testDialog = new Politie_DataEntry_ZSM_Radicalen();
                // Show testDialog as a modal dialog and determine if DialogResult = OK.
                if (testDialog.ShowDialog(this) == DialogResult.OK)
                {
                    // Read the contents of testDialog's TextBox.
                    dataToRetrieve = "Aantal antecedenten: " + testDialog.numericAntecendentenPolitie.Value + Environment.NewLine;
                    dataToRetrieve += "Aantal aanhoudingen: " + testDialog.numericAanhoudingenPolitie.Value + Environment.NewLine;
                    dataToRetrieve += "BSN: " + testDialog.textBoxPolitie_DataEntry_BSN.Text + Environment.NewLine;
                    dataToRetrieve += "Achternaam: " + testDialog.textBoxPolitie_DataEntry_Achternaam.Text + Environment.NewLine;
                    dataToRetrieve += "Geb datum: " + testDialog.dateTimePickerPolitie_DataEntry_Geb_Datum.Text + Environment.NewLine;

                    //STUK IS ALLEEN VOOR ENCRYPTE GEMEENTE
                    string[] recipient_Role_Paths = new string[4];
                    int cnt = 0;

                    foreach (var pair in keyIDPaths.roleKeyPaths)
                    {
                        if (pair.Key == "Gemeente" || pair.Key == "Politie")
                        {
                            recipient_Role_Paths[cnt] = pair.Value;
                        }
                        cnt++;
                    }

                    EncryptionCaller(recipient_Role_Paths, dataToRetrieve, (Program.pathKeyPrivate + "\\" + comboBoxPrivateKeyPolitieEncryptDropDown.Text), true, "Gemeente, Politie");

                    if (testDialog.checkBoxHeeftISDMaatregel.Checked)
                    {
                        dataToRetrieve += "Heeft ISD maatregel";
                    }
                    else
                    {
                        dataToRetrieve += "Heeft geen ISD maatregel";
                    }

                    //STUK IS VOOR OM EN RECLASSERING
                    string[] recipient_Role_Paths_2 = new string[4];
                    cnt = 0;

                    foreach (var pair in keyIDPaths.roleKeyPaths)
                    {
                        if (pair.Key == "OM" || pair.Key == "Reclassering" || pair.Key == "Politie")
                        {
                            recipient_Role_Paths_2[cnt] = pair.Value;
                        }
                        cnt++;
                    }
                    EncryptionCaller(recipient_Role_Paths_2, dataToRetrieve, (Program.pathKeyPrivate + "\\" + comboBoxPrivateKeyPolitieEncryptDropDown.Text), true, "OM, Reclassering, Politie");
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

        public void Politie_DataEntry_LokalePGA()
        {
            try
            {
                string dataToRetrieve = "";
                Politie_DataEntry_LokalePGA testDialog = new Politie_DataEntry_LokalePGA();
                // Show testDialog as a modal dialog and determine if DialogResult = OK.
                if (testDialog.ShowDialog(this) == DialogResult.OK)
                {
                    // Read the contents of testDialog's TextBox.
                    dataToRetrieve = "Aantal antecedenten: " + testDialog.numericAntecendentenPolitie.Value + Environment.NewLine;
                    dataToRetrieve += "BSN: " + testDialog.textBoxPolitie_DataEntry_BSN.Text + Environment.NewLine;
                    dataToRetrieve += "Achternaam: " + testDialog.textBoxPolitie_DataEntry_Achternaam.Text + Environment.NewLine;
                    dataToRetrieve += "Geb datum: " + testDialog.dateTimePickerPolitie_DataEntry_Geb_Datum.Text + Environment.NewLine;

                    //STUK IS VOOR OM EN RECLASSERING
                    string[] recipient_Role_Paths = new string[4];
                    int cnt = 0;

                    foreach (var pair in keyIDPaths.roleKeyPaths)
                    {
                        if (pair.Key == "OM" || pair.Key == "Reclassering" || pair.Key == "Politie" || pair.Key == "Gemeente")
                        {
                            recipient_Role_Paths[cnt] = pair.Value;
                        }
                        cnt++;

                    }
                    EncryptionCaller(recipient_Role_Paths, dataToRetrieve, (Program.pathKeyPrivate + "\\" + comboBoxPrivateKeyPolitieEncryptDropDown.Text), true, "OM, Reclassering, Politie, Gemeente");
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

        public void Politie_DataEntry_Detentie()
        {
            try
            {
                string dataToRetrieve = "";
                Politie_DataEntry_Detentie testDialog = new Politie_DataEntry_Detentie();
                // Show testDialog as a modal dialog and determine if DialogResult = OK.
                if (testDialog.ShowDialog(this) == DialogResult.OK)
                {
                    // Read the contents of testDialog's TextBox.
                    dataToRetrieve = "Aantal antecedenten: " + testDialog.numericAntecendentenPolitie.Value + Environment.NewLine;
                    dataToRetrieve += "Aantal aanhoudingen: " + testDialog.numericAanhoudingenPolitie.Value + Environment.NewLine;
                    dataToRetrieve += "BSN: " + testDialog.textBoxPolitie_DataEntry_BSN.Text + Environment.NewLine;
                    dataToRetrieve += "Achternaam: " + testDialog.textBoxPolitie_DataEntry_Achternaam.Text + Environment.NewLine;
                    dataToRetrieve += "Geb datum: " + testDialog.dateTimePickerPolitie_DataEntry_Geb_Datum.Text + Environment.NewLine;

                    string[] recipient_Role_Paths = new string[4];
                    int cnt = 0;

                    foreach (var pair in keyIDPaths.roleKeyPaths)
                    {
                        if (pair.Key == "OM" || pair.Key == "Reclassering" || pair.Key == "Politie" || pair.Key == "Gemeente")
                        {
                            recipient_Role_Paths[cnt] = pair.Value;
                        }
                        cnt++;
                    }
                    EncryptionCaller(recipient_Role_Paths, dataToRetrieve, (Program.pathKeyPrivate + "\\" + comboBoxPrivateKeyPolitieEncryptDropDown.Text), true, "OM, Reclassering, Politie, Gemeente");
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

        public void OM_DataEntry_ZSM()
        {
            try
            {
                string dataToRetrieve = "";
                OM_DataEntry_ZSM testDialog = new OM_DataEntry_ZSM();
                // Show testDialog as a modal dialog and determine if DialogResult = OK.
                if (testDialog.ShowDialog(this) == DialogResult.OK)
                {
                    // Read the contents of testDialog's TextBox.
                    dataToRetrieve = "Aantal antecedenten: " + testDialog.numericAntecendentenPolitie.Value + Environment.NewLine;
                    dataToRetrieve += "Aantal sepots: " + testDialog.numericAntecendentenPolitie.Value + Environment.NewLine;
                    dataToRetrieve += "BSN: " + testDialog.textBoxPolitie_DataEntry_BSN.Text + Environment.NewLine;
                    dataToRetrieve += "Achternaam: " + testDialog.textBoxPolitie_DataEntry_Achternaam.Text + Environment.NewLine;
                    dataToRetrieve += "Geb datum: " + testDialog.dateTimePickerPolitie_DataEntry_Geb_Datum.Text + Environment.NewLine;

                    string[] recipient_Role_Paths = new string[4];
                    int cnt = 0;

                    foreach (var pair in keyIDPaths.roleKeyPaths)
                    {
                        if (pair.Key == "OM" || pair.Key == "Reclassering" || pair.Key == "Politie" || pair.Key == "Gemeente")
                        {
                            recipient_Role_Paths[cnt] = pair.Value;
                        }
                        cnt++;
                    }
                    EncryptionCaller(recipient_Role_Paths, dataToRetrieve, (Program.pathKeyPrivate + "\\" + comboBoxPrivateKeyOMEncryptDropDown.Text), true, "OM, Reclassering, Politie, Gemeente");
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

        public void OM_DataEntry_Radicalen()
        {
            try
            {
                string dataToRetrieve = "";
                OM_DataEntry_Radicalen testDialog = new OM_DataEntry_Radicalen();
                // Show testDialog as a modal dialog and determine if DialogResult = OK.
                if (testDialog.ShowDialog(this) == DialogResult.OK)
                {
                    // Read the contents of testDialog's TextBox.
                    dataToRetrieve = "Aantal antecedenten: " + testDialog.numericAntecendentenPolitie.Value + Environment.NewLine;
                    dataToRetrieve += "Aantal sepots: " + testDialog.numericAanhoudingenPolitie.Value + Environment.NewLine;
                    dataToRetrieve += "BSN: " + testDialog.textBoxPolitie_DataEntry_BSN.Text + Environment.NewLine;
                    dataToRetrieve += "Achternaam: " + testDialog.textBoxPolitie_DataEntry_Achternaam.Text + Environment.NewLine;
                    dataToRetrieve += "Geb datum: " + testDialog.dateTimePickerPolitie_DataEntry_Geb_Datum.Text + Environment.NewLine;

                    //STUK IS ALLEEN VOOR ENCRYPTE GEMEENTE
                    string[] recipient_Role_Paths = new string[4];
                    int cnt = 0;

                    foreach (var pair in keyIDPaths.roleKeyPaths)
                    {
                        if (pair.Key == "Reclassering" || pair.Key == "OM")
                        {
                            recipient_Role_Paths[cnt] = pair.Value;
                        }
                        cnt++;
                    }
                    EncryptionCaller(recipient_Role_Paths, dataToRetrieve, (Program.pathKeyPrivate + "\\" + comboBoxPrivateKeyOMEncryptDropDown.Text), true, "OM, Reclassering");

                    if (testDialog.checkBoxHeeftOnderzoekRad.Checked)
                    {
                        dataToRetrieve += "Heeft onderzoekRAD maatregel";
                    }
                    else
                    {
                        dataToRetrieve += "Heeft geen onderzoekRAD maatregel";
                    }

                    //STUK IS VOOR OM EN RECLASSERING
                    string[] recipient_Role_Paths_2 = new string[4];
                    cnt = 0;

                    foreach (var pair in keyIDPaths.roleKeyPaths)
                    {
                        if (pair.Key == "OM" || pair.Key == "Gemeente" || pair.Key == "Politie")
                        {
                            recipient_Role_Paths_2[cnt] = pair.Value;
                        }
                        cnt++;
                    }
                    EncryptionCaller(recipient_Role_Paths_2, dataToRetrieve, (Program.pathKeyPrivate + "\\" + comboBoxPrivateKeyOMEncryptDropDown.Text), true, "OM, Politie, Gemeente");
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

        public void OM_DataEntry_LokalePGA()
        {
            try
            {
                string dataToRetrieve = "";
                OM_DataEntry_LokalePGA testDialog = new OM_DataEntry_LokalePGA();
                // Show testDialog as a modal dialog and determine if DialogResult = OK.
                if (testDialog.ShowDialog(this) == DialogResult.OK)
                {
                    // Read the contents of testDialog's TextBox.
                    dataToRetrieve = "Aantal antecedenten: " + testDialog.numericAntecendentenPolitie.Value + Environment.NewLine;
                    dataToRetrieve += "BSN: " + testDialog.textBoxPolitie_DataEntry_BSN.Text + Environment.NewLine;
                    dataToRetrieve += "Achternaam: " + testDialog.textBoxPolitie_DataEntry_Achternaam.Text + Environment.NewLine;
                    dataToRetrieve += "Geb datum: " + testDialog.dateTimePickerPolitie_DataEntry_Geb_Datum.Text + Environment.NewLine;

                    //STUK IS VOOR OM EN RECLASSERING
                    string[] recipient_Role_Paths = new string[4];
                    int cnt = 0;

                    foreach (var pair in keyIDPaths.roleKeyPaths)
                    {
                        if (pair.Key == "OM" || pair.Key == "Gemeente" || pair.Key == "Reclassering" || pair.Key == "Politie")
                        {
                            recipient_Role_Paths[cnt] = pair.Value;
                        }
                        cnt++;
                    }
                    EncryptionCaller(recipient_Role_Paths, dataToRetrieve, (Program.pathKeyPrivate + "\\" + comboBoxPrivateKeyOMEncryptDropDown.Text), true, "OM, Reclassering, Politie, Gemeente");
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

        public void OM_DataEntry_Detentie()
        {
            try
            {
                string dataToRetrieve = "";
                OM_DataEntry_Detentie testDialog = new OM_DataEntry_Detentie();
                // Show testDialog as a modal dialog and determine if DialogResult = OK.
                if (testDialog.ShowDialog(this) == DialogResult.OK)
                {
                    // Read the contents of testDialog's TextBox.
                    dataToRetrieve = "Aantel opende dossiers: " + testDialog.numericAntecendentenPolitie.Value + Environment.NewLine;
                    dataToRetrieve += "BSN: " + testDialog.textBoxPolitie_DataEntry_BSN.Text + Environment.NewLine;
                    dataToRetrieve += "Achternaam: " + testDialog.textBoxPolitie_DataEntry_Achternaam.Text + Environment.NewLine;
                    dataToRetrieve += "Geb datum: " + testDialog.dateTimePickerPolitie_DataEntry_Geb_Datum.Text + Environment.NewLine;
                   
                    string[] recipient_Role_Paths = new string[4];
                    int cnt = 0;

                    foreach (var pair in keyIDPaths.roleKeyPaths)
                    {
                        if (pair.Key == "OM" || pair.Key == "Gemeente" || pair.Key == "Reclassering" || pair.Key == "Politie")
                        {
                            recipient_Role_Paths[cnt] = pair.Value;
                        }
                        cnt++;
                    }
                    EncryptionCaller(recipient_Role_Paths, dataToRetrieve, (Program.pathKeyPrivate + "\\" + comboBoxPrivateKeyOMEncryptDropDown.Text), true, "OM, Reclassering, Politie, Gemeente");
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

        public void Gemeente_DataEntry_ZSM()
        {
            try
            {
                string dataToRetrieve = "";
                Gemeente_DataEntry_ZSM testDialog = new Gemeente_DataEntry_ZSM();
                // Show testDialog as a modal dialog and determine if DialogResult = OK.
                if (testDialog.ShowDialog(this) == DialogResult.OK)
                {
                    // Read the contents of testDialog's TextBox.
                    if (testDialog.checkBoxHeeftUitkering.Checked)
                    {
                        dataToRetrieve = "Bezit uitkering";
                    } else
                    {
                        dataToRetrieve = "Bezit geen uitkering";
                    }

                    dataToRetrieve += "BSN: " + testDialog.textBoxPolitie_DataEntry_BSN.Text + Environment.NewLine;
                    dataToRetrieve += "Achternaam: " + testDialog.textBoxPolitie_DataEntry_Achternaam.Text + Environment.NewLine;
                    dataToRetrieve += "Geb datum: " + testDialog.dateTimePickerPolitie_DataEntry_Geb_Datum.Text + Environment.NewLine;

                    string[] recipient_Role_Paths = new string[4];
                    int cnt = 0;

                    foreach (var pair in keyIDPaths.roleKeyPaths)
                    {
                        if (pair.Key == "OM" || pair.Key == "Gemeente" || pair.Key == "Reclassering" || pair.Key == "Politie")
                        {
                            recipient_Role_Paths[cnt] = pair.Value;
                        }
                        cnt++;
                    }
                    EncryptionCaller(recipient_Role_Paths, dataToRetrieve, (Program.pathKeyPrivate + "\\" + comboBoxPrivateKeyGemeenteEncryptDropDown.Text), true, "OM, Reclassering, Politie, Gemeente");
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

        public void Gemeente_DataEntry_Radicalen()
        {
            try
            {
                string dataToRetrieve = "";
                Gemeente_DataEntry_Radicalen testDialog = new Gemeente_DataEntry_Radicalen();
                // Show testDialog as a modal dialog and determine if DialogResult = OK.
                if (testDialog.ShowDialog(this) == DialogResult.OK)
                {
                    dataToRetrieve = "Aantal meldingen rad: " + testDialog.numericAntecendentenPolitie.Value + Environment.NewLine;
                    dataToRetrieve += "BSN: " + testDialog.textBoxPolitie_DataEntry_BSN.Text + Environment.NewLine;
                    dataToRetrieve += "Achternaam: " + testDialog.textBoxPolitie_DataEntry_Achternaam.Text + Environment.NewLine;
                    dataToRetrieve += "Geb datum: " + testDialog.dateTimePickerPolitie_DataEntry_Geb_Datum.Text + Environment.NewLine;

                    string[] recipient_Role_Paths = new string[4];
                    int cnt = 0;

                    foreach (var pair in keyIDPaths.roleKeyPaths)
                    {
                        if (pair.Key == "OM" || pair.Key == "Gemeente" || pair.Key == "Politie")
                        {
                            recipient_Role_Paths[cnt] = pair.Value;
                        }
                        cnt++;
                    }
                    EncryptionCaller(recipient_Role_Paths, dataToRetrieve, (Program.pathKeyPrivate + "\\" + comboBoxPrivateKeyGemeenteEncryptDropDown.Text), true, "OM, Politie, Gemeente");
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

        public void Gemeente_DataEntry_LokalePGA()
        {
            try
            {
                string dataToRetrieve = "";
                Gemeente_DataEntry_LokalePGA testDialog = new Gemeente_DataEntry_LokalePGA();
                // Show testDialog as a modal dialog and determine if DialogResult = OK.
                if (testDialog.ShowDialog(this) == DialogResult.OK)
                {
                    if (testDialog.BezitUitkering.Checked)
                    {
                        dataToRetrieve = "Bezit uitkering";
                    }
                    else
                    {
                        dataToRetrieve = "Bezit geen uitkering";
                    }

                    if (testDialog.checkBoxZitInGroepsAanpak.Checked)
                    {
                        dataToRetrieve += "Zit in groepsaanpak";
                    }
                    else
                    {
                        dataToRetrieve += "Zit niet in groepsaanpak";
                    }

                    dataToRetrieve += "BSN: " + testDialog.textBoxPolitie_DataEntry_BSN.Text + Environment.NewLine;
                    dataToRetrieve += "Achternaam: " + testDialog.textBoxPolitie_DataEntry_Achternaam.Text + Environment.NewLine;
                    dataToRetrieve += "Geb datum: " + testDialog.dateTimePickerPolitie_DataEntry_Geb_Datum.Text + Environment.NewLine;

                    string[] recipient_Role_Paths = new string[4];
                    int cnt = 0;

                    foreach (var pair in keyIDPaths.roleKeyPaths)
                    {
                        if (pair.Key == "OM" || pair.Key == "Reclassering" || pair.Key == "Politie" || pair.Key == "Gemeente")
                        {
                            recipient_Role_Paths[cnt] = pair.Value;
                        }
                        cnt++;
                    }
                    EncryptionCaller(recipient_Role_Paths, dataToRetrieve, (Program.pathKeyPrivate + "\\" + comboBoxPrivateKeyGemeenteEncryptDropDown.Text), true, "OM, Reclassering, Politie, Gemeente");
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

        public void Gemeente_DataEntry_Detentie()
        {
            try
            {
                string dataToRetrieve = "";
                Gemeente_DataEntry_Detentie testDialog = new Gemeente_DataEntry_Detentie();
                // Show testDialog as a modal dialog and determine if DialogResult = OK.
                if (testDialog.ShowDialog(this) == DialogResult.OK)
                {
                    // Read the contents of testDialog's TextBox.

                    if (testDialog.BezitUitkering.Checked)
                    {
                        dataToRetrieve = "Bezit uitkering";
                    }
                    else
                    {
                        dataToRetrieve = "Bezit geen uitkering";
                    }

                    if (testDialog.checkBoxHeeftIDBewijs.Checked)
                    {
                        dataToRetrieve += "Zit in groepsaanpak";
                    }
                    else
                    {
                        dataToRetrieve += "Zit niet in groepsaanpak";
                    }

                    dataToRetrieve += "BSN: " + testDialog.textBoxPolitie_DataEntry_BSN.Text + Environment.NewLine;
                    dataToRetrieve += "Achternaam: " + testDialog.textBoxPolitie_DataEntry_Achternaam.Text + Environment.NewLine;
                    dataToRetrieve += "Geb datum: " + testDialog.dateTimePickerPolitie_DataEntry_Geb_Datum.Text + Environment.NewLine;

                    string[] recipient_Role_Paths = new string[4];
                    int cnt = 0;

                    foreach (var pair in keyIDPaths.roleKeyPaths)
                    {
                        if (pair.Key == "OM" || pair.Key == "Reclassering" || pair.Key == "Politie" || pair.Key == "Gemeente")
                        {
                            recipient_Role_Paths[cnt] = pair.Value;
                        }
                        cnt++;
                    }
                    EncryptionCaller(recipient_Role_Paths, dataToRetrieve, (Program.pathKeyPrivate + "\\" + comboBoxPrivateKeyGemeenteEncryptDropDown.Text), true, "OM, Reclassering, Politie, Gemeente");
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
            Politie_DataEntry_ZSM_Radicalen();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void richTextBoxConnections_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBoxConnections_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void Data_Invoer_Politie_LokalePGA_Button_Click(object sender, EventArgs e)
        {
            Politie_DataEntry_LokalePGA();
        }

        private void Data_Invoer_Politie_Detentie_Button_Click(object sender, EventArgs e)
        {
            Politie_DataEntry_Detentie();
        }

        private void Data_Invoer_Gemeente_Radicalen_Button_Click(object sender, EventArgs e)
        {
            Gemeente_DataEntry_Radicalen();
        }

        private void Data_Invoer_Gemeente_LokalePGA_Button_Click(object sender, EventArgs e)
        {
            Gemeente_DataEntry_LokalePGA();
        }

        private void Data_Invoer_Gemeente_Detentie_Button_Click(object sender, EventArgs e)
        {
            Gemeente_DataEntry_Detentie();
        }

        private void Data_Invoer_Gemeente_ZSM_Button_Click(object sender, EventArgs e)
        {
            Gemeente_DataEntry_ZSM();
        }

        private void DataInvoerOmZSM_Click(object sender, EventArgs e)
        {
            OM_DataEntry_ZSM();
        }

        private void DataInvoerOmRadicalen_Click(object sender, EventArgs e)
        {
            OM_DataEntry_Radicalen();
        }

        private void DataInvoerOmLokalePGA_Click(object sender, EventArgs e)
        {
            OM_DataEntry_LokalePGA();
        }

        private void DataInvoerOmDetentie_Click(object sender, EventArgs e)
        {
            OM_DataEntry_Detentie();
        }

        private void EventServerInitAtClipboard_OnClick(object sender, EventArgs e)
        {
            Clipboard.SetText(ServerInitAt.Text);
        }
    }

}
