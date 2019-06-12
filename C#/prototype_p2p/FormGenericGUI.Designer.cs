namespace prototype_p2p
{
    partial class FormGenericGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.DisplayRecords = new System.Windows.Forms.Button();
            this.DisplayKeys = new System.Windows.Forms.Button();
            this.Encrypt = new System.Windows.Forms.Button();
            this.ToggleConfigLoad = new System.Windows.Forms.Button();
            this.ConnectServerButton = new System.Windows.Forms.Button();
            this.labeltextDisplay = new System.Windows.Forms.Label();
            this.ReceiverNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.richTextBoxPublicKeyPaths = new System.Windows.Forms.RichTextBox();
            this.ServerUrlTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ServerInitAt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.checkedListBoxPublicKeysToEncryptFor = new System.Windows.Forms.CheckedListBox();
            this.comboBoxBlockDecryptNumber = new System.Windows.Forms.ComboBox();
            this.SaveNameAndPortToConfig = new System.Windows.Forms.Button();
            this.richTextBoxPrivateKeyPaths = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxPrivateKeyEncryptDropDown = new System.Windows.Forms.ComboBox();
            this.comboBoxPrivateKeyDecryptDropDown = new System.Windows.Forms.ComboBox();
            this.comboBoxPublicKeyDecryptDropDown = new System.Windows.Forms.ComboBox();
            this.buttonResetConfigFileValues = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.richTextBoxConnections = new System.Windows.Forms.RichTextBox();
            this.connectionUpdateButton = new System.Windows.Forms.Button();
            this.displayChainVisual = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.richTextBoxStatusUpdates = new System.Windows.Forms.RichTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button_Open_Keys_Folder = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textBoxNodeName = new System.Windows.Forms.TextBox();
            this.textBoxCurrentActiveRole = new System.Windows.Forms.TextBox();
            this.button_Open_Config_File = new System.Windows.Forms.Button();
            this.Data_Invoer_Reclassering_Button = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Reclassering = new System.Windows.Forms.TabPage();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.comboBoxPrivateKeyReclasseringEncryptDropDown = new System.Windows.Forms.ComboBox();
            this.OM = new System.Windows.Forms.TabPage();
            this.Data_Invoer_OM_Button = new System.Windows.Forms.Button();
            this.comboBoxPrivateKeyOMEncryptDropDown = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.Gemeente = new System.Windows.Forms.TabPage();
            this.Data_Invoer_Gemeente_Button = new System.Windows.Forms.Button();
            this.comboBoxPrivateKeyGemeenteEncryptDropDown = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.Politie = new System.Windows.Forms.TabPage();
            this.label19 = new System.Windows.Forms.Label();
            this.comboBoxPrivateKeyPolitieEncryptDropDown = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.Data_Invoer_Politie_Button = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.Reclassering.SuspendLayout();
            this.OM.SuspendLayout();
            this.Gemeente.SuspendLayout();
            this.Politie.SuspendLayout();
            this.SuspendLayout();
            // 
            // DisplayRecords
            // 
            this.DisplayRecords.Location = new System.Drawing.Point(372, 425);
            this.DisplayRecords.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DisplayRecords.Name = "DisplayRecords";
            this.DisplayRecords.Size = new System.Drawing.Size(153, 43);
            this.DisplayRecords.TabIndex = 0;
            this.DisplayRecords.Text = "Display chain data (full)";
            this.DisplayRecords.UseVisualStyleBackColor = true;
            this.DisplayRecords.Click += new System.EventHandler(this.DisplayChainFromGUI);
            // 
            // DisplayKeys
            // 
            this.DisplayKeys.AccessibleRole = System.Windows.Forms.AccessibleRole.WhiteSpace;
            this.DisplayKeys.Location = new System.Drawing.Point(372, 353);
            this.DisplayKeys.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DisplayKeys.Name = "DisplayKeys";
            this.DisplayKeys.Size = new System.Drawing.Size(153, 43);
            this.DisplayKeys.TabIndex = 1;
            this.DisplayKeys.Text = "Decrypt";
            this.DisplayKeys.UseVisualStyleBackColor = true;
            this.DisplayKeys.Click += new System.EventHandler(this.DecryptFromGUI);
            // 
            // Encrypt
            // 
            this.Encrypt.AccessibleRole = System.Windows.Forms.AccessibleRole.WhiteSpace;
            this.Encrypt.Location = new System.Drawing.Point(27, 585);
            this.Encrypt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Encrypt.Name = "Encrypt";
            this.Encrypt.Size = new System.Drawing.Size(153, 43);
            this.Encrypt.TabIndex = 3;
            this.Encrypt.Text = "Encrypt data";
            this.Encrypt.UseVisualStyleBackColor = true;
            this.Encrypt.Click += new System.EventHandler(this.EncryptfromGUI);
            // 
            // ToggleConfigLoad
            // 
            this.ToggleConfigLoad.Location = new System.Drawing.Point(533, 475);
            this.ToggleConfigLoad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ToggleConfigLoad.Name = "ToggleConfigLoad";
            this.ToggleConfigLoad.Size = new System.Drawing.Size(153, 43);
            this.ToggleConfigLoad.TabIndex = 4;
            this.ToggleConfigLoad.Text = "Toggle loading from config file";
            this.ToggleConfigLoad.UseVisualStyleBackColor = true;
            this.ToggleConfigLoad.Click += new System.EventHandler(this.ToggleLoadConfigSettings);
            // 
            // ConnectServerButton
            // 
            this.ConnectServerButton.Location = new System.Drawing.Point(27, 122);
            this.ConnectServerButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ConnectServerButton.Name = "ConnectServerButton";
            this.ConnectServerButton.Size = new System.Drawing.Size(153, 43);
            this.ConnectServerButton.TabIndex = 5;
            this.ConnectServerButton.Text = "Setup a connection with a server";
            this.ConnectServerButton.UseVisualStyleBackColor = true;
            this.ConnectServerButton.Click += new System.EventHandler(this.ConnectServer);
            // 
            // labeltextDisplay
            // 
            this.labeltextDisplay.AutoSize = true;
            this.labeltextDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labeltextDisplay.Location = new System.Drawing.Point(23, 182);
            this.labeltextDisplay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labeltextDisplay.Name = "labeltextDisplay";
            this.labeltextDisplay.Size = new System.Drawing.Size(181, 20);
            this.labeltextDisplay.TabIndex = 6;
            this.labeltextDisplay.Text = "Enter receiver name(s)";
            // 
            // ReceiverNameTextBox
            // 
            this.ReceiverNameTextBox.Location = new System.Drawing.Point(27, 207);
            this.ReceiverNameTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ReceiverNameTextBox.Name = "ReceiverNameTextBox";
            this.ReceiverNameTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.ReceiverNameTextBox.Size = new System.Drawing.Size(265, 22);
            this.ReceiverNameTextBox.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(23, 235);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Select public key(s) to encrypt for";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(23, 527);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(231, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Select private key to sign with";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(368, 182);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(233, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Enter block number to decrypt";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(368, 235);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(255, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Select private key to decrypt with";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(368, 295);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(308, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "Select public key to verify signature with";
            // 
            // richTextBoxPublicKeyPaths
            // 
            this.richTextBoxPublicKeyPaths.DetectUrls = false;
            this.richTextBoxPublicKeyPaths.Location = new System.Drawing.Point(721, 37);
            this.richTextBoxPublicKeyPaths.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBoxPublicKeyPaths.Name = "richTextBoxPublicKeyPaths";
            this.richTextBoxPublicKeyPaths.ReadOnly = true;
            this.richTextBoxPublicKeyPaths.Size = new System.Drawing.Size(332, 454);
            this.richTextBoxPublicKeyPaths.TabIndex = 19;
            this.richTextBoxPublicKeyPaths.Text = "";
            // 
            // ServerUrlTextBox
            // 
            this.ServerUrlTextBox.Location = new System.Drawing.Point(27, 90);
            this.ServerUrlTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ServerUrlTextBox.Name = "ServerUrlTextBox";
            this.ServerUrlTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.ServerUrlTextBox.Size = new System.Drawing.Size(532, 22);
            this.ServerUrlTextBox.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.Location = new System.Drawing.Point(23, 65);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(201, 20);
            this.label7.TabIndex = 21;
            this.label7.Text = "Enter Server Url and port ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label8.Location = new System.Drawing.Point(23, 12);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(157, 20);
            this.label8.TabIndex = 22;
            this.label8.Text = "Server initialized at:";
            // 
            // ServerInitAt
            // 
            this.ServerInitAt.Location = new System.Drawing.Point(27, 37);
            this.ServerInitAt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ServerInitAt.Name = "ServerInitAt";
            this.ServerInitAt.ReadOnly = true;
            this.ServerInitAt.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.ServerInitAt.ShortcutsEnabled = false;
            this.ServerInitAt.Size = new System.Drawing.Size(532, 22);
            this.ServerInitAt.TabIndex = 23;
            this.ServerInitAt.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label9.Location = new System.Drawing.Point(717, 12);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(164, 20);
            this.label9.TabIndex = 24;
            this.label9.Text = "Available public keys";
            // 
            // checkedListBoxPublicKeysToEncryptFor
            // 
            this.checkedListBoxPublicKeysToEncryptFor.FormattingEnabled = true;
            this.checkedListBoxPublicKeysToEncryptFor.HorizontalScrollbar = true;
            this.checkedListBoxPublicKeysToEncryptFor.Location = new System.Drawing.Point(27, 260);
            this.checkedListBoxPublicKeysToEncryptFor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkedListBoxPublicKeysToEncryptFor.Name = "checkedListBoxPublicKeysToEncryptFor";
            this.checkedListBoxPublicKeysToEncryptFor.Size = new System.Drawing.Size(299, 259);
            this.checkedListBoxPublicKeysToEncryptFor.TabIndex = 25;
            // 
            // comboBoxBlockDecryptNumber
            // 
            this.comboBoxBlockDecryptNumber.FormattingEnabled = true;
            this.comboBoxBlockDecryptNumber.Location = new System.Drawing.Point(372, 207);
            this.comboBoxBlockDecryptNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxBlockDecryptNumber.Name = "comboBoxBlockDecryptNumber";
            this.comboBoxBlockDecryptNumber.Size = new System.Drawing.Size(160, 24);
            this.comboBoxBlockDecryptNumber.TabIndex = 26;
            // 
            // SaveNameAndPortToConfig
            // 
            this.SaveNameAndPortToConfig.Location = new System.Drawing.Point(372, 475);
            this.SaveNameAndPortToConfig.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SaveNameAndPortToConfig.Name = "SaveNameAndPortToConfig";
            this.SaveNameAndPortToConfig.Size = new System.Drawing.Size(153, 43);
            this.SaveNameAndPortToConfig.TabIndex = 27;
            this.SaveNameAndPortToConfig.Text = "Save current settings";
            this.SaveNameAndPortToConfig.UseVisualStyleBackColor = true;
            this.SaveNameAndPortToConfig.Click += new System.EventHandler(this.SaveName_PortAndRoleToConfig_Click);
            // 
            // richTextBoxPrivateKeyPaths
            // 
            this.richTextBoxPrivateKeyPaths.DetectUrls = false;
            this.richTextBoxPrivateKeyPaths.Location = new System.Drawing.Point(721, 521);
            this.richTextBoxPrivateKeyPaths.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBoxPrivateKeyPaths.Name = "richTextBoxPrivateKeyPaths";
            this.richTextBoxPrivateKeyPaths.ReadOnly = true;
            this.richTextBoxPrivateKeyPaths.Size = new System.Drawing.Size(332, 142);
            this.richTextBoxPrivateKeyPaths.TabIndex = 28;
            this.richTextBoxPrivateKeyPaths.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(717, 496);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 20);
            this.label4.TabIndex = 29;
            this.label4.Text = "Available private keys";
            // 
            // comboBoxPrivateKeyEncryptDropDown
            // 
            this.comboBoxPrivateKeyEncryptDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPrivateKeyEncryptDropDown.FormattingEnabled = true;
            this.comboBoxPrivateKeyEncryptDropDown.Location = new System.Drawing.Point(27, 551);
            this.comboBoxPrivateKeyEncryptDropDown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxPrivateKeyEncryptDropDown.Name = "comboBoxPrivateKeyEncryptDropDown";
            this.comboBoxPrivateKeyEncryptDropDown.Size = new System.Drawing.Size(160, 24);
            this.comboBoxPrivateKeyEncryptDropDown.TabIndex = 30;
            // 
            // comboBoxPrivateKeyDecryptDropDown
            // 
            this.comboBoxPrivateKeyDecryptDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPrivateKeyDecryptDropDown.FormattingEnabled = true;
            this.comboBoxPrivateKeyDecryptDropDown.Location = new System.Drawing.Point(372, 260);
            this.comboBoxPrivateKeyDecryptDropDown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxPrivateKeyDecryptDropDown.Name = "comboBoxPrivateKeyDecryptDropDown";
            this.comboBoxPrivateKeyDecryptDropDown.Size = new System.Drawing.Size(160, 24);
            this.comboBoxPrivateKeyDecryptDropDown.TabIndex = 31;
            // 
            // comboBoxPublicKeyDecryptDropDown
            // 
            this.comboBoxPublicKeyDecryptDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPublicKeyDecryptDropDown.FormattingEnabled = true;
            this.comboBoxPublicKeyDecryptDropDown.Location = new System.Drawing.Point(372, 320);
            this.comboBoxPublicKeyDecryptDropDown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxPublicKeyDecryptDropDown.Name = "comboBoxPublicKeyDecryptDropDown";
            this.comboBoxPublicKeyDecryptDropDown.Size = new System.Drawing.Size(160, 24);
            this.comboBoxPublicKeyDecryptDropDown.TabIndex = 32;
            // 
            // buttonResetConfigFileValues
            // 
            this.buttonResetConfigFileValues.Location = new System.Drawing.Point(533, 576);
            this.buttonResetConfigFileValues.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonResetConfigFileValues.Name = "buttonResetConfigFileValues";
            this.buttonResetConfigFileValues.Size = new System.Drawing.Size(153, 43);
            this.buttonResetConfigFileValues.TabIndex = 33;
            this.buttonResetConfigFileValues.Text = "Reset config file";
            this.buttonResetConfigFileValues.UseVisualStyleBackColor = true;
            this.buttonResetConfigFileValues.Click += new System.EventHandler(this.ButtonResetConfigFileValues_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label10.Location = new System.Drawing.Point(1120, 11);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 20);
            this.label10.TabIndex = 34;
            this.label10.Text = "Connections";
            // 
            // richTextBoxConnections
            // 
            this.richTextBoxConnections.DetectUrls = false;
            this.richTextBoxConnections.Location = new System.Drawing.Point(1124, 37);
            this.richTextBoxConnections.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBoxConnections.Name = "richTextBoxConnections";
            this.richTextBoxConnections.ReadOnly = true;
            this.richTextBoxConnections.Size = new System.Drawing.Size(520, 229);
            this.richTextBoxConnections.TabIndex = 35;
            this.richTextBoxConnections.Text = "";
            this.richTextBoxConnections.TextChanged += new System.EventHandler(this.richTextBoxConnections_TextChanged_1);
            // 
            // connectionUpdateButton
            // 
            this.connectionUpdateButton.Location = new System.Drawing.Point(1124, 274);
            this.connectionUpdateButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.connectionUpdateButton.Name = "connectionUpdateButton";
            this.connectionUpdateButton.Size = new System.Drawing.Size(153, 43);
            this.connectionUpdateButton.TabIndex = 36;
            this.connectionUpdateButton.Text = "Update connections";
            this.connectionUpdateButton.UseVisualStyleBackColor = true;
            this.connectionUpdateButton.Click += new System.EventHandler(this.connectionUpdateButton_Click);
            // 
            // displayChainVisual
            // 
            this.displayChainVisual.Location = new System.Drawing.Point(533, 425);
            this.displayChainVisual.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.displayChainVisual.Name = "displayChainVisual";
            this.displayChainVisual.Size = new System.Drawing.Size(153, 43);
            this.displayChainVisual.TabIndex = 37;
            this.displayChainVisual.Text = "Display chain data (pretty)";
            this.displayChainVisual.UseVisualStyleBackColor = true;
            this.displayChainVisual.Click += new System.EventHandler(this.displayChainVisual_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label11.Location = new System.Drawing.Point(1120, 321);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(121, 20);
            this.label11.TabIndex = 38;
            this.label11.Text = "Status updates";
            // 
            // richTextBoxStatusUpdates
            // 
            this.richTextBoxStatusUpdates.DetectUrls = false;
            this.richTextBoxStatusUpdates.Location = new System.Drawing.Point(1124, 346);
            this.richTextBoxStatusUpdates.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBoxStatusUpdates.Name = "richTextBoxStatusUpdates";
            this.richTextBoxStatusUpdates.ReadOnly = true;
            this.richTextBoxStatusUpdates.Size = new System.Drawing.Size(520, 229);
            this.richTextBoxStatusUpdates.TabIndex = 39;
            this.richTextBoxStatusUpdates.Text = "";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(1693, 37);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 24);
            this.label12.TabIndex = 40;
            this.label12.Text = "label_Date";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(1693, 57);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(103, 24);
            this.label13.TabIndex = 41;
            this.label13.Text = "label_Time";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button_Open_Keys_Folder
            // 
            this.button_Open_Keys_Folder.Location = new System.Drawing.Point(533, 526);
            this.button_Open_Keys_Folder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Open_Keys_Folder.Name = "button_Open_Keys_Folder";
            this.button_Open_Keys_Folder.Size = new System.Drawing.Size(153, 43);
            this.button_Open_Keys_Folder.TabIndex = 42;
            this.button_Open_Keys_Folder.Text = "Open keys folder";
            this.button_Open_Keys_Folder.UseVisualStyleBackColor = true;
            this.button_Open_Keys_Folder.Click += new System.EventHandler(this.button_Open_Keys_Folder_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label14.Location = new System.Drawing.Point(1120, 580);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(103, 20);
            this.label14.TabIndex = 43;
            this.label14.Text = "Current role:";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label15.Location = new System.Drawing.Point(1323, 580);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(116, 20);
            this.label15.TabIndex = 44;
            this.label15.Text = "Current name:";
            // 
            // textBoxNodeName
            // 
            this.textBoxNodeName.Location = new System.Drawing.Point(1327, 603);
            this.textBoxNodeName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxNodeName.Name = "textBoxNodeName";
            this.textBoxNodeName.ReadOnly = true;
            this.textBoxNodeName.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBoxNodeName.Size = new System.Drawing.Size(265, 22);
            this.textBoxNodeName.TabIndex = 45;
            // 
            // textBoxCurrentActiveRole
            // 
            this.textBoxCurrentActiveRole.Location = new System.Drawing.Point(1124, 604);
            this.textBoxCurrentActiveRole.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxCurrentActiveRole.Name = "textBoxCurrentActiveRole";
            this.textBoxCurrentActiveRole.ReadOnly = true;
            this.textBoxCurrentActiveRole.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBoxCurrentActiveRole.Size = new System.Drawing.Size(193, 22);
            this.textBoxCurrentActiveRole.TabIndex = 46;
            // 
            // button_Open_Config_File
            // 
            this.button_Open_Config_File.Location = new System.Drawing.Point(372, 526);
            this.button_Open_Config_File.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Open_Config_File.Name = "button_Open_Config_File";
            this.button_Open_Config_File.Size = new System.Drawing.Size(153, 43);
            this.button_Open_Config_File.TabIndex = 47;
            this.button_Open_Config_File.Text = "Open config file";
            this.button_Open_Config_File.UseVisualStyleBackColor = true;
            this.button_Open_Config_File.Click += new System.EventHandler(this.button_Open_Config_File_Click);
            // 
            // Data_Invoer_Reclassering_Button
            // 
            this.Data_Invoer_Reclassering_Button.Location = new System.Drawing.Point(29, 59);
            this.Data_Invoer_Reclassering_Button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Data_Invoer_Reclassering_Button.Name = "Data_Invoer_Reclassering_Button";
            this.Data_Invoer_Reclassering_Button.Size = new System.Drawing.Size(153, 43);
            this.Data_Invoer_Reclassering_Button.TabIndex = 49;
            this.Data_Invoer_Reclassering_Button.Text = "Data invoer";
            this.Data_Invoer_Reclassering_Button.UseVisualStyleBackColor = true;
            this.Data_Invoer_Reclassering_Button.Click += new System.EventHandler(this.Data_Invoer_Reclassering_Button_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Reclassering);
            this.tabControl1.Controls.Add(this.OM);
            this.tabControl1.Controls.Add(this.Gemeente);
            this.tabControl1.Controls.Add(this.Politie);
            this.tabControl1.Location = new System.Drawing.Point(27, 719);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(885, 254);
            this.tabControl1.TabIndex = 50;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // Reclassering
            // 
            this.Reclassering.Controls.Add(this.label17);
            this.Reclassering.Controls.Add(this.label16);
            this.Reclassering.Controls.Add(this.comboBoxPrivateKeyReclasseringEncryptDropDown);
            this.Reclassering.Controls.Add(this.Data_Invoer_Reclassering_Button);
            this.Reclassering.Location = new System.Drawing.Point(4, 25);
            this.Reclassering.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Reclassering.Name = "Reclassering";
            this.Reclassering.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Reclassering.Size = new System.Drawing.Size(877, 225);
            this.Reclassering.TabIndex = 0;
            this.Reclassering.Text = "Reclassering";
            this.Reclassering.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label17.Location = new System.Drawing.Point(25, 34);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(198, 20);
            this.label17.TabIndex = 52;
            this.label17.Text = "ZSM, Radicalen, Detentie";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label16.Location = new System.Drawing.Point(25, 124);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(231, 20);
            this.label16.TabIndex = 51;
            this.label16.Text = "Select private key to sign with";
            // 
            // comboBoxPrivateKeyReclasseringEncryptDropDown
            // 
            this.comboBoxPrivateKeyReclasseringEncryptDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPrivateKeyReclasseringEncryptDropDown.FormattingEnabled = true;
            this.comboBoxPrivateKeyReclasseringEncryptDropDown.Location = new System.Drawing.Point(29, 149);
            this.comboBoxPrivateKeyReclasseringEncryptDropDown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxPrivateKeyReclasseringEncryptDropDown.Name = "comboBoxPrivateKeyReclasseringEncryptDropDown";
            this.comboBoxPrivateKeyReclasseringEncryptDropDown.Size = new System.Drawing.Size(160, 24);
            this.comboBoxPrivateKeyReclasseringEncryptDropDown.TabIndex = 50;
            // 
            // OM
            // 
            this.OM.Controls.Add(this.Data_Invoer_OM_Button);
            this.OM.Controls.Add(this.comboBoxPrivateKeyOMEncryptDropDown);
            this.OM.Controls.Add(this.label20);
            this.OM.Location = new System.Drawing.Point(4, 25);
            this.OM.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.OM.Name = "OM";
            this.OM.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.OM.Size = new System.Drawing.Size(877, 225);
            this.OM.TabIndex = 1;
            this.OM.Text = "OM";
            this.OM.UseVisualStyleBackColor = true;
            // 
            // Data_Invoer_OM_Button
            // 
            this.Data_Invoer_OM_Button.Location = new System.Drawing.Point(28, 53);
            this.Data_Invoer_OM_Button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Data_Invoer_OM_Button.Name = "Data_Invoer_OM_Button";
            this.Data_Invoer_OM_Button.Size = new System.Drawing.Size(153, 43);
            this.Data_Invoer_OM_Button.TabIndex = 54;
            this.Data_Invoer_OM_Button.Text = "Data invoer";
            this.Data_Invoer_OM_Button.UseVisualStyleBackColor = true;
            this.Data_Invoer_OM_Button.Click += new System.EventHandler(this.Data_Invoer_OM_Button_Click);
            // 
            // comboBoxPrivateKeyOMEncryptDropDown
            // 
            this.comboBoxPrivateKeyOMEncryptDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPrivateKeyOMEncryptDropDown.FormattingEnabled = true;
            this.comboBoxPrivateKeyOMEncryptDropDown.Location = new System.Drawing.Point(28, 166);
            this.comboBoxPrivateKeyOMEncryptDropDown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxPrivateKeyOMEncryptDropDown.Name = "comboBoxPrivateKeyOMEncryptDropDown";
            this.comboBoxPrivateKeyOMEncryptDropDown.Size = new System.Drawing.Size(160, 24);
            this.comboBoxPrivateKeyOMEncryptDropDown.TabIndex = 53;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label20.Location = new System.Drawing.Point(24, 142);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(231, 20);
            this.label20.TabIndex = 52;
            this.label20.Text = "Select private key to sign with";
            // 
            // Gemeente
            // 
            this.Gemeente.Controls.Add(this.Data_Invoer_Gemeente_Button);
            this.Gemeente.Controls.Add(this.comboBoxPrivateKeyGemeenteEncryptDropDown);
            this.Gemeente.Controls.Add(this.label21);
            this.Gemeente.Location = new System.Drawing.Point(4, 25);
            this.Gemeente.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Gemeente.Name = "Gemeente";
            this.Gemeente.Size = new System.Drawing.Size(877, 225);
            this.Gemeente.TabIndex = 2;
            this.Gemeente.Text = "Gemeente";
            this.Gemeente.UseVisualStyleBackColor = true;
            // 
            // Data_Invoer_Gemeente_Button
            // 
            this.Data_Invoer_Gemeente_Button.Location = new System.Drawing.Point(48, 48);
            this.Data_Invoer_Gemeente_Button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Data_Invoer_Gemeente_Button.Name = "Data_Invoer_Gemeente_Button";
            this.Data_Invoer_Gemeente_Button.Size = new System.Drawing.Size(153, 43);
            this.Data_Invoer_Gemeente_Button.TabIndex = 54;
            this.Data_Invoer_Gemeente_Button.Text = "Data invoer";
            this.Data_Invoer_Gemeente_Button.UseVisualStyleBackColor = true;
            this.Data_Invoer_Gemeente_Button.Click += new System.EventHandler(this.Data_Invoer_Gemeente_Button_Click);
            // 
            // comboBoxPrivateKeyGemeenteEncryptDropDown
            // 
            this.comboBoxPrivateKeyGemeenteEncryptDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPrivateKeyGemeenteEncryptDropDown.FormattingEnabled = true;
            this.comboBoxPrivateKeyGemeenteEncryptDropDown.Location = new System.Drawing.Point(40, 165);
            this.comboBoxPrivateKeyGemeenteEncryptDropDown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxPrivateKeyGemeenteEncryptDropDown.Name = "comboBoxPrivateKeyGemeenteEncryptDropDown";
            this.comboBoxPrivateKeyGemeenteEncryptDropDown.Size = new System.Drawing.Size(160, 24);
            this.comboBoxPrivateKeyGemeenteEncryptDropDown.TabIndex = 53;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label21.Location = new System.Drawing.Point(36, 140);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(231, 20);
            this.label21.TabIndex = 52;
            this.label21.Text = "Select private key to sign with";
            // 
            // Politie
            // 
            this.Politie.Controls.Add(this.label19);
            this.Politie.Controls.Add(this.comboBoxPrivateKeyPolitieEncryptDropDown);
            this.Politie.Controls.Add(this.label18);
            this.Politie.Controls.Add(this.Data_Invoer_Politie_Button);
            this.Politie.Location = new System.Drawing.Point(4, 25);
            this.Politie.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Politie.Name = "Politie";
            this.Politie.Size = new System.Drawing.Size(877, 225);
            this.Politie.TabIndex = 3;
            this.Politie.Text = "Politie";
            this.Politie.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label19.Location = new System.Drawing.Point(24, 143);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(231, 20);
            this.label19.TabIndex = 55;
            this.label19.Text = "Select private key to sign with";
            // 
            // comboBoxPrivateKeyPolitieEncryptDropDown
            // 
            this.comboBoxPrivateKeyPolitieEncryptDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPrivateKeyPolitieEncryptDropDown.FormattingEnabled = true;
            this.comboBoxPrivateKeyPolitieEncryptDropDown.Location = new System.Drawing.Point(28, 167);
            this.comboBoxPrivateKeyPolitieEncryptDropDown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxPrivateKeyPolitieEncryptDropDown.Name = "comboBoxPrivateKeyPolitieEncryptDropDown";
            this.comboBoxPrivateKeyPolitieEncryptDropDown.Size = new System.Drawing.Size(160, 24);
            this.comboBoxPrivateKeyPolitieEncryptDropDown.TabIndex = 54;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label18.Location = new System.Drawing.Point(24, 37);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(126, 20);
            this.label18.TabIndex = 53;
            this.label18.Text = "ZSM, Radicalen";
            // 
            // Data_Invoer_Politie_Button
            // 
            this.Data_Invoer_Politie_Button.Location = new System.Drawing.Point(28, 62);
            this.Data_Invoer_Politie_Button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Data_Invoer_Politie_Button.Name = "Data_Invoer_Politie_Button";
            this.Data_Invoer_Politie_Button.Size = new System.Drawing.Size(153, 43);
            this.Data_Invoer_Politie_Button.TabIndex = 50;
            this.Data_Invoer_Politie_Button.Text = "Data invoer";
            this.Data_Invoer_Politie_Button.UseVisualStyleBackColor = true;
            this.Data_Invoer_Politie_Button.Click += new System.EventHandler(this.Data_Invoer_Politie_Button_Click);
            // 
            // FormGenericGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button_Open_Config_File);
            this.Controls.Add(this.textBoxCurrentActiveRole);
            this.Controls.Add(this.textBoxNodeName);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.button_Open_Keys_Folder);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.richTextBoxStatusUpdates);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.displayChainVisual);
            this.Controls.Add(this.connectionUpdateButton);
            this.Controls.Add(this.richTextBoxConnections);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.buttonResetConfigFileValues);
            this.Controls.Add(this.comboBoxPublicKeyDecryptDropDown);
            this.Controls.Add(this.comboBoxPrivateKeyDecryptDropDown);
            this.Controls.Add(this.comboBoxPrivateKeyEncryptDropDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.richTextBoxPrivateKeyPaths);
            this.Controls.Add(this.SaveNameAndPortToConfig);
            this.Controls.Add(this.comboBoxBlockDecryptNumber);
            this.Controls.Add(this.checkedListBoxPublicKeysToEncryptFor);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.ServerInitAt);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ServerUrlTextBox);
            this.Controls.Add(this.richTextBoxPublicKeyPaths);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ReceiverNameTextBox);
            this.Controls.Add(this.labeltextDisplay);
            this.Controls.Add(this.ConnectServerButton);
            this.Controls.Add(this.ToggleConfigLoad);
            this.Controls.Add(this.Encrypt);
            this.Controls.Add(this.DisplayKeys);
            this.Controls.Add(this.DisplayRecords);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormGenericGUI";
            this.Text = "Blockchain";
            this.Load += new System.EventHandler(this.FormGenericGUI_Load);
            this.tabControl1.ResumeLayout(false);
            this.Reclassering.ResumeLayout(false);
            this.Reclassering.PerformLayout();
            this.OM.ResumeLayout(false);
            this.OM.PerformLayout();
            this.Gemeente.ResumeLayout(false);
            this.Gemeente.PerformLayout();
            this.Politie.ResumeLayout(false);
            this.Politie.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DisplayRecords;
        private System.Windows.Forms.Button DisplayKeys;
        private System.Windows.Forms.Button Encrypt;
        private System.Windows.Forms.Button ToggleConfigLoad;
        private System.Windows.Forms.Button ConnectServerButton;
        private System.Windows.Forms.Label labeltextDisplay;
        private System.Windows.Forms.TextBox ReceiverNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox richTextBoxPublicKeyPaths;
        private System.Windows.Forms.TextBox ServerUrlTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox ServerInitAt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckedListBox checkedListBoxPublicKeysToEncryptFor;
        private System.Windows.Forms.ComboBox comboBoxBlockDecryptNumber;
        private System.Windows.Forms.Button SaveNameAndPortToConfig;
        private System.Windows.Forms.RichTextBox richTextBoxPrivateKeyPaths;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxPrivateKeyEncryptDropDown;
        private System.Windows.Forms.ComboBox comboBoxPrivateKeyDecryptDropDown;
        private System.Windows.Forms.ComboBox comboBoxPublicKeyDecryptDropDown;
        private System.Windows.Forms.Button buttonResetConfigFileValues;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.RichTextBox richTextBoxConnections;
        private System.Windows.Forms.Button connectionUpdateButton;
        private System.Windows.Forms.Button displayChainVisual;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.RichTextBox richTextBoxStatusUpdates;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button_Open_Keys_Folder;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBoxNodeName;
        private System.Windows.Forms.TextBox textBoxCurrentActiveRole;
        private System.Windows.Forms.Button button_Open_Config_File;
        private System.Windows.Forms.Button Data_Invoer_Reclassering_Button;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage OM;
        private System.Windows.Forms.TabPage Reclassering;
        private System.Windows.Forms.TabPage Gemeente;
        private System.Windows.Forms.TabPage Politie;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox comboBoxPrivateKeyReclasseringEncryptDropDown;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox comboBoxPrivateKeyOMEncryptDropDown;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox comboBoxPrivateKeyGemeenteEncryptDropDown;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox comboBoxPrivateKeyPolitieEncryptDropDown;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button Data_Invoer_Politie_Button;
        private System.Windows.Forms.Button Data_Invoer_OM_Button;
        private System.Windows.Forms.Button Data_Invoer_Gemeente_Button;
    }
}

