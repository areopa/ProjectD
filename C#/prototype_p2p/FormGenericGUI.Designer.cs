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
            this.SuspendLayout();
            // 
            // DisplayRecords
            // 
            this.DisplayRecords.Location = new System.Drawing.Point(500, 550);
            this.DisplayRecords.Name = "DisplayRecords";
            this.DisplayRecords.Size = new System.Drawing.Size(115, 35);
            this.DisplayRecords.TabIndex = 0;
            this.DisplayRecords.Text = "Display chain data";
            this.DisplayRecords.UseVisualStyleBackColor = true;
            this.DisplayRecords.Click += new System.EventHandler(this.DisplayChainFromGUI);
            // 
            // DisplayKeys
            // 
            this.DisplayKeys.AccessibleRole = System.Windows.Forms.AccessibleRole.WhiteSpace;
            this.DisplayKeys.Location = new System.Drawing.Point(866, 621);
            this.DisplayKeys.Name = "DisplayKeys";
            this.DisplayKeys.Size = new System.Drawing.Size(115, 35);
            this.DisplayKeys.TabIndex = 1;
            this.DisplayKeys.Text = "Decrypt";
            this.DisplayKeys.UseVisualStyleBackColor = true;
            this.DisplayKeys.Click += new System.EventHandler(this.DecryptFromGUI);
            // 
            // Encrypt
            // 
            this.Encrypt.AccessibleRole = System.Windows.Forms.AccessibleRole.WhiteSpace;
            this.Encrypt.Location = new System.Drawing.Point(20, 472);
            this.Encrypt.Name = "Encrypt";
            this.Encrypt.Size = new System.Drawing.Size(115, 35);
            this.Encrypt.TabIndex = 3;
            this.Encrypt.Text = "Encrypt data";
            this.Encrypt.UseVisualStyleBackColor = true;
            this.Encrypt.Click += new System.EventHandler(this.EncryptfromGUI);
            // 
            // ToggleConfigLoad
            // 
            this.ToggleConfigLoad.Location = new System.Drawing.Point(635, 550);
            this.ToggleConfigLoad.Name = "ToggleConfigLoad";
            this.ToggleConfigLoad.Size = new System.Drawing.Size(115, 35);
            this.ToggleConfigLoad.TabIndex = 4;
            this.ToggleConfigLoad.Text = "Toggle loading from config file";
            this.ToggleConfigLoad.UseVisualStyleBackColor = true;
            this.ToggleConfigLoad.Click += new System.EventHandler(this.ToggleLoadConfigSettings);
            // 
            // ConnectServerButton
            // 
            this.ConnectServerButton.Location = new System.Drawing.Point(20, 585);
            this.ConnectServerButton.Name = "ConnectServerButton";
            this.ConnectServerButton.Size = new System.Drawing.Size(115, 35);
            this.ConnectServerButton.TabIndex = 5;
            this.ConnectServerButton.Text = "Setup a connection with a server";
            this.ConnectServerButton.UseVisualStyleBackColor = true;
            this.ConnectServerButton.Click += new System.EventHandler(this.ConnectServer);
            // 
            // labeltextDisplay
            // 
            this.labeltextDisplay.AutoSize = true;
            this.labeltextDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labeltextDisplay.Location = new System.Drawing.Point(20, 65);
            this.labeltextDisplay.Name = "labeltextDisplay";
            this.labeltextDisplay.Size = new System.Drawing.Size(153, 17);
            this.labeltextDisplay.TabIndex = 6;
            this.labeltextDisplay.Text = "Enter receiver name(s)";
            // 
            // ReceiverNameTextBox
            // 
            this.ReceiverNameTextBox.Location = new System.Drawing.Point(20, 85);
            this.ReceiverNameTextBox.Name = "ReceiverNameTextBox";
            this.ReceiverNameTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.ReceiverNameTextBox.Size = new System.Drawing.Size(200, 20);
            this.ReceiverNameTextBox.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(20, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Select public key(s) to encrypt for";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(17, 404);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Select private key to sign with";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(862, 460);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Enter block number to decrypt";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(863, 513);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(215, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Select private key to decrypt with";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(862, 559);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(259, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "Select public key to verify signature with";
            // 
            // richTextBoxPublicKeyPaths
            // 
            this.richTextBoxPublicKeyPaths.DetectUrls = false;
            this.richTextBoxPublicKeyPaths.Location = new System.Drawing.Point(500, 30);
            this.richTextBoxPublicKeyPaths.Name = "richTextBoxPublicKeyPaths";
            this.richTextBoxPublicKeyPaths.ReadOnly = true;
            this.richTextBoxPublicKeyPaths.Size = new System.Drawing.Size(250, 425);
            this.richTextBoxPublicKeyPaths.TabIndex = 19;
            this.richTextBoxPublicKeyPaths.Text = "";
            // 
            // ServerUrlTextBox
            // 
            this.ServerUrlTextBox.Location = new System.Drawing.Point(20, 550);
            this.ServerUrlTextBox.Name = "ServerUrlTextBox";
            this.ServerUrlTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.ServerUrlTextBox.Size = new System.Drawing.Size(400, 20);
            this.ServerUrlTextBox.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.Location = new System.Drawing.Point(20, 530);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(171, 17);
            this.label7.TabIndex = 21;
            this.label7.Text = "Enter Server Url and port ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label8.Location = new System.Drawing.Point(20, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(132, 17);
            this.label8.TabIndex = 22;
            this.label8.Text = "Server initialized at:";
            // 
            // ServerInitAt
            // 
            this.ServerInitAt.Location = new System.Drawing.Point(20, 30);
            this.ServerInitAt.Name = "ServerInitAt";
            this.ServerInitAt.ReadOnly = true;
            this.ServerInitAt.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.ServerInitAt.ShortcutsEnabled = false;
            this.ServerInitAt.Size = new System.Drawing.Size(400, 20);
            this.ServerInitAt.TabIndex = 23;
            this.ServerInitAt.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label9.Location = new System.Drawing.Point(500, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(139, 17);
            this.label9.TabIndex = 24;
            this.label9.Text = "Available public keys";
            // 
            // checkedListBoxPublicKeysToEncryptFor
            // 
            this.checkedListBoxPublicKeysToEncryptFor.FormattingEnabled = true;
            this.checkedListBoxPublicKeysToEncryptFor.HorizontalScrollbar = true;
            this.checkedListBoxPublicKeysToEncryptFor.Location = new System.Drawing.Point(20, 140);
            this.checkedListBoxPublicKeysToEncryptFor.Name = "checkedListBoxPublicKeysToEncryptFor";
            this.checkedListBoxPublicKeysToEncryptFor.Size = new System.Drawing.Size(225, 244);
            this.checkedListBoxPublicKeysToEncryptFor.TabIndex = 25;
            // 
            // comboBoxBlockDecryptNumber
            // 
            this.comboBoxBlockDecryptNumber.FormattingEnabled = true;
            this.comboBoxBlockDecryptNumber.Location = new System.Drawing.Point(865, 480);
            this.comboBoxBlockDecryptNumber.Name = "comboBoxBlockDecryptNumber";
            this.comboBoxBlockDecryptNumber.Size = new System.Drawing.Size(121, 21);
            this.comboBoxBlockDecryptNumber.TabIndex = 26;
            // 
            // SaveNameAndPortToConfig
            // 
            this.SaveNameAndPortToConfig.Location = new System.Drawing.Point(635, 591);
            this.SaveNameAndPortToConfig.Name = "SaveNameAndPortToConfig";
            this.SaveNameAndPortToConfig.Size = new System.Drawing.Size(115, 35);
            this.SaveNameAndPortToConfig.TabIndex = 27;
            this.SaveNameAndPortToConfig.Text = "Save current port and name to config";
            this.SaveNameAndPortToConfig.UseVisualStyleBackColor = true;
            this.SaveNameAndPortToConfig.Click += new System.EventHandler(this.SaveNameAndPortToConfig_Click);
            // 
            // richTextBoxPrivateKeyPaths
            // 
            this.richTextBoxPrivateKeyPaths.DetectUrls = false;
            this.richTextBoxPrivateKeyPaths.Location = new System.Drawing.Point(810, 30);
            this.richTextBoxPrivateKeyPaths.Name = "richTextBoxPrivateKeyPaths";
            this.richTextBoxPrivateKeyPaths.ReadOnly = true;
            this.richTextBoxPrivateKeyPaths.Size = new System.Drawing.Size(250, 187);
            this.richTextBoxPrivateKeyPaths.TabIndex = 28;
            this.richTextBoxPrivateKeyPaths.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(807, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 17);
            this.label4.TabIndex = 29;
            this.label4.Text = "Available private keys";
            // 
            // comboBoxPrivateKeyEncryptDropDown
            // 
            this.comboBoxPrivateKeyEncryptDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPrivateKeyEncryptDropDown.FormattingEnabled = true;
            this.comboBoxPrivateKeyEncryptDropDown.Location = new System.Drawing.Point(20, 434);
            this.comboBoxPrivateKeyEncryptDropDown.Name = "comboBoxPrivateKeyEncryptDropDown";
            this.comboBoxPrivateKeyEncryptDropDown.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPrivateKeyEncryptDropDown.TabIndex = 30;
            // 
            // comboBoxPrivateKeyDecryptDropDown
            // 
            this.comboBoxPrivateKeyDecryptDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPrivateKeyDecryptDropDown.FormattingEnabled = true;
            this.comboBoxPrivateKeyDecryptDropDown.Location = new System.Drawing.Point(866, 536);
            this.comboBoxPrivateKeyDecryptDropDown.Name = "comboBoxPrivateKeyDecryptDropDown";
            this.comboBoxPrivateKeyDecryptDropDown.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPrivateKeyDecryptDropDown.TabIndex = 31;
            // 
            // comboBoxPublicKeyDecryptDropDown
            // 
            this.comboBoxPublicKeyDecryptDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPublicKeyDecryptDropDown.FormattingEnabled = true;
            this.comboBoxPublicKeyDecryptDropDown.Location = new System.Drawing.Point(866, 590);
            this.comboBoxPublicKeyDecryptDropDown.Name = "comboBoxPublicKeyDecryptDropDown";
            this.comboBoxPublicKeyDecryptDropDown.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPublicKeyDecryptDropDown.TabIndex = 32;
            // 
            // buttonResetConfigFileValues
            // 
            this.buttonResetConfigFileValues.Location = new System.Drawing.Point(500, 591);
            this.buttonResetConfigFileValues.Name = "buttonResetConfigFileValues";
            this.buttonResetConfigFileValues.Size = new System.Drawing.Size(115, 35);
            this.buttonResetConfigFileValues.TabIndex = 33;
            this.buttonResetConfigFileValues.Text = "Reset config file";
            this.buttonResetConfigFileValues.UseVisualStyleBackColor = true;
            this.buttonResetConfigFileValues.Click += new System.EventHandler(this.ButtonResetConfigFileValues_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 668);
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
            this.Name = "Form1";
            this.Text = "Blockchain";
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
    }
}

