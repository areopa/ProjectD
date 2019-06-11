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
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DisplayRecords
            // 
            this.DisplayRecords.Location = new System.Drawing.Point(372, 425);
            this.DisplayRecords.Margin = new System.Windows.Forms.Padding(4);
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
            this.DisplayKeys.Margin = new System.Windows.Forms.Padding(4);
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
            this.Encrypt.Location = new System.Drawing.Point(27, 620);
            this.Encrypt.Margin = new System.Windows.Forms.Padding(4);
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
            this.ToggleConfigLoad.Margin = new System.Windows.Forms.Padding(4);
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
            this.ConnectServerButton.Margin = new System.Windows.Forms.Padding(4);
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
            this.ReceiverNameTextBox.Margin = new System.Windows.Forms.Padding(4);
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
            this.label2.Location = new System.Drawing.Point(23, 563);
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
            this.richTextBoxPublicKeyPaths.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBoxPublicKeyPaths.Name = "richTextBoxPublicKeyPaths";
            this.richTextBoxPublicKeyPaths.ReadOnly = true;
            this.richTextBoxPublicKeyPaths.Size = new System.Drawing.Size(332, 455);
            this.richTextBoxPublicKeyPaths.TabIndex = 19;
            this.richTextBoxPublicKeyPaths.Text = "";
            // 
            // ServerUrlTextBox
            // 
            this.ServerUrlTextBox.Location = new System.Drawing.Point(27, 90);
            this.ServerUrlTextBox.Margin = new System.Windows.Forms.Padding(4);
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
            this.ServerInitAt.Margin = new System.Windows.Forms.Padding(4);
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
            this.checkedListBoxPublicKeysToEncryptFor.Margin = new System.Windows.Forms.Padding(4);
            this.checkedListBoxPublicKeysToEncryptFor.Name = "checkedListBoxPublicKeysToEncryptFor";
            this.checkedListBoxPublicKeysToEncryptFor.Size = new System.Drawing.Size(299, 276);
            this.checkedListBoxPublicKeysToEncryptFor.TabIndex = 25;
            // 
            // comboBoxBlockDecryptNumber
            // 
            this.comboBoxBlockDecryptNumber.FormattingEnabled = true;
            this.comboBoxBlockDecryptNumber.Location = new System.Drawing.Point(372, 207);
            this.comboBoxBlockDecryptNumber.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxBlockDecryptNumber.Name = "comboBoxBlockDecryptNumber";
            this.comboBoxBlockDecryptNumber.Size = new System.Drawing.Size(160, 24);
            this.comboBoxBlockDecryptNumber.TabIndex = 26;
            // 
            // SaveNameAndPortToConfig
            // 
            this.SaveNameAndPortToConfig.Location = new System.Drawing.Point(372, 475);
            this.SaveNameAndPortToConfig.Margin = new System.Windows.Forms.Padding(4);
            this.SaveNameAndPortToConfig.Name = "SaveNameAndPortToConfig";
            this.SaveNameAndPortToConfig.Size = new System.Drawing.Size(153, 43);
            this.SaveNameAndPortToConfig.TabIndex = 27;
            this.SaveNameAndPortToConfig.Text = "Save current port and name to config";
            this.SaveNameAndPortToConfig.UseVisualStyleBackColor = true;
            this.SaveNameAndPortToConfig.Click += new System.EventHandler(this.SaveNameAndPortToConfig_Click);
            // 
            // richTextBoxPrivateKeyPaths
            // 
            this.richTextBoxPrivateKeyPaths.DetectUrls = false;
            this.richTextBoxPrivateKeyPaths.Location = new System.Drawing.Point(721, 521);
            this.richTextBoxPrivateKeyPaths.Margin = new System.Windows.Forms.Padding(4);
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
            this.comboBoxPrivateKeyEncryptDropDown.Location = new System.Drawing.Point(27, 587);
            this.comboBoxPrivateKeyEncryptDropDown.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxPrivateKeyEncryptDropDown.Name = "comboBoxPrivateKeyEncryptDropDown";
            this.comboBoxPrivateKeyEncryptDropDown.Size = new System.Drawing.Size(160, 24);
            this.comboBoxPrivateKeyEncryptDropDown.TabIndex = 30;
            // 
            // comboBoxPrivateKeyDecryptDropDown
            // 
            this.comboBoxPrivateKeyDecryptDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPrivateKeyDecryptDropDown.FormattingEnabled = true;
            this.comboBoxPrivateKeyDecryptDropDown.Location = new System.Drawing.Point(372, 260);
            this.comboBoxPrivateKeyDecryptDropDown.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxPrivateKeyDecryptDropDown.Name = "comboBoxPrivateKeyDecryptDropDown";
            this.comboBoxPrivateKeyDecryptDropDown.Size = new System.Drawing.Size(160, 24);
            this.comboBoxPrivateKeyDecryptDropDown.TabIndex = 31;
            // 
            // comboBoxPublicKeyDecryptDropDown
            // 
            this.comboBoxPublicKeyDecryptDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPublicKeyDecryptDropDown.FormattingEnabled = true;
            this.comboBoxPublicKeyDecryptDropDown.Location = new System.Drawing.Point(372, 320);
            this.comboBoxPublicKeyDecryptDropDown.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxPublicKeyDecryptDropDown.Name = "comboBoxPublicKeyDecryptDropDown";
            this.comboBoxPublicKeyDecryptDropDown.Size = new System.Drawing.Size(160, 24);
            this.comboBoxPublicKeyDecryptDropDown.TabIndex = 32;
            // 
            // buttonResetConfigFileValues
            // 
            this.buttonResetConfigFileValues.Location = new System.Drawing.Point(372, 525);
            this.buttonResetConfigFileValues.Margin = new System.Windows.Forms.Padding(4);
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
            this.richTextBoxConnections.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBoxConnections.Name = "richTextBoxConnections";
            this.richTextBoxConnections.ReadOnly = true;
            this.richTextBoxConnections.Size = new System.Drawing.Size(520, 229);
            this.richTextBoxConnections.TabIndex = 35;
            this.richTextBoxConnections.Text = "";
            // 
            // connectionUpdateButton
            // 
            this.connectionUpdateButton.Location = new System.Drawing.Point(1124, 275);
            this.connectionUpdateButton.Margin = new System.Windows.Forms.Padding(4);
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
            this.displayChainVisual.Margin = new System.Windows.Forms.Padding(4);
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
            this.label11.Location = new System.Drawing.Point(1120, 353);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(121, 20);
            this.label11.TabIndex = 38;
            this.label11.Text = "Status updates";
            // 
            // richTextBoxStatusUpdates
            // 
            this.richTextBoxStatusUpdates.DetectUrls = false;
            this.richTextBoxStatusUpdates.Location = new System.Drawing.Point(1124, 378);
            this.richTextBoxStatusUpdates.Margin = new System.Windows.Forms.Padding(4);
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
            this.label12.Location = new System.Drawing.Point(1694, 37);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
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
            this.label13.Location = new System.Drawing.Point(1694, 57);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(533, 526);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 43);
            this.button1.TabIndex = 42;
            this.button1.Text = "Open keys folder";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormGenericGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1399, 678);
            this.Controls.Add(this.button1);
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
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormGenericGUI";
            this.Text = "Blockchain";
            this.Load += new System.EventHandler(this.FormGenericGUI_Load);
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
        private System.Windows.Forms.RichTextBox richTextBoxConnections;
        private System.Windows.Forms.Button connectionUpdateButton;
        private System.Windows.Forms.Button displayChainVisual;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.RichTextBox richTextBoxStatusUpdates;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
    }
}

