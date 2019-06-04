namespace prototype_p2p
{
    partial class Form1
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
            this.GetSelectedTextButton = new System.Windows.Forms.Button();
            this.Encrypt = new System.Windows.Forms.Button();
            this.SelectionButton = new System.Windows.Forms.Button();
            this.ZoomButton = new System.Windows.Forms.Button();
            this.labeltextDisplay = new System.Windows.Forms.Label();
            this.ReceiverNameTextBox = new System.Windows.Forms.TextBox();
            this.ReceiverKeyIdTextBox = new System.Windows.Forms.TextBox();
            this.PrivateKeyIdTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BlockNumberDecrypt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.PrivateKeyDecrypt = new System.Windows.Forms.TextBox();
            this.PublicKeyVerify = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // DisplayRecords
            // 
            this.DisplayRecords.Location = new System.Drawing.Point(820, 98);
            this.DisplayRecords.Name = "DisplayRecords";
            this.DisplayRecords.Size = new System.Drawing.Size(115, 35);
            this.DisplayRecords.TabIndex = 0;
            this.DisplayRecords.Text = "Display records";
            this.DisplayRecords.UseVisualStyleBackColor = true;
            this.DisplayRecords.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // DisplayKeys
            // 
            this.DisplayKeys.AccessibleRole = System.Windows.Forms.AccessibleRole.WhiteSpace;
            this.DisplayKeys.Location = new System.Drawing.Point(820, 44);
            this.DisplayKeys.Name = "DisplayKeys";
            this.DisplayKeys.Size = new System.Drawing.Size(115, 35);
            this.DisplayKeys.TabIndex = 1;
            this.DisplayKeys.Text = "Decrypt";
            this.DisplayKeys.UseVisualStyleBackColor = true;
            this.DisplayKeys.Click += new System.EventHandler(this.GetLinesButton_Click);
            // 
            // GetSelectedTextButton
            // 
            this.GetSelectedTextButton.AccessibleRole = System.Windows.Forms.AccessibleRole.WhiteSpace;
            this.GetSelectedTextButton.Location = new System.Drawing.Point(820, 152);
            this.GetSelectedTextButton.Name = "GetSelectedTextButton";
            this.GetSelectedTextButton.Size = new System.Drawing.Size(115, 35);
            this.GetSelectedTextButton.TabIndex = 2;
            this.GetSelectedTextButton.Text = "Display all known keys";
            this.GetSelectedTextButton.UseVisualStyleBackColor = true;
            this.GetSelectedTextButton.Click += new System.EventHandler(this.GetSelectedTextButton_Click);
            // 
            // Encrypt
            // 
            this.Encrypt.AccessibleRole = System.Windows.Forms.AccessibleRole.WhiteSpace;
            this.Encrypt.Location = new System.Drawing.Point(820, 214);
            this.Encrypt.Name = "Encrypt";
            this.Encrypt.Size = new System.Drawing.Size(115, 35);
            this.Encrypt.TabIndex = 3;
            this.Encrypt.Text = "Encrypt data";
            this.Encrypt.UseVisualStyleBackColor = true;
            this.Encrypt.Click += new System.EventHandler(this.LoadRTFButton_Click);
            // 
            // SelectionButton
            // 
            this.SelectionButton.Location = new System.Drawing.Point(820, 270);
            this.SelectionButton.Name = "SelectionButton";
            this.SelectionButton.Size = new System.Drawing.Size(115, 35);
            this.SelectionButton.TabIndex = 4;
            this.SelectionButton.Text = "Selection ";
            this.SelectionButton.UseVisualStyleBackColor = true;
            this.SelectionButton.Visible = false;
            this.SelectionButton.Click += new System.EventHandler(this.SelectionButton_Click);
            // 
            // ZoomButton
            // 
            this.ZoomButton.Location = new System.Drawing.Point(820, 327);
            this.ZoomButton.Name = "ZoomButton";
            this.ZoomButton.Size = new System.Drawing.Size(115, 35);
            this.ZoomButton.TabIndex = 5;
            this.ZoomButton.Text = "Zoom";
            this.ZoomButton.UseVisualStyleBackColor = true;
            this.ZoomButton.Visible = false;
            this.ZoomButton.Click += new System.EventHandler(this.ZoomButton_Click);
            // 
            // labeltextDisplay
            // 
            this.labeltextDisplay.AutoSize = true;
            this.labeltextDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labeltextDisplay.Location = new System.Drawing.Point(37, 79);
            this.labeltextDisplay.Name = "labeltextDisplay";
            this.labeltextDisplay.Size = new System.Drawing.Size(153, 17);
            this.labeltextDisplay.TabIndex = 6;
            this.labeltextDisplay.Text = "Enter receiver name(s)";
            // 
            // ReceiverNameTextBox
            // 
            this.ReceiverNameTextBox.Location = new System.Drawing.Point(40, 106);
            this.ReceiverNameTextBox.Name = "ReceiverNameTextBox";
            this.ReceiverNameTextBox.Size = new System.Drawing.Size(186, 20);
            this.ReceiverNameTextBox.TabIndex = 7;
            // 
            // ReceiverKeyIdTextBox
            // 
            this.ReceiverKeyIdTextBox.Location = new System.Drawing.Point(40, 214);
            this.ReceiverKeyIdTextBox.Name = "ReceiverKeyIdTextBox";
            this.ReceiverKeyIdTextBox.Size = new System.Drawing.Size(140, 20);
            this.ReceiverKeyIdTextBox.TabIndex = 8;
            // 
            // PrivateKeyIdTextBox
            // 
            this.PrivateKeyIdTextBox.Location = new System.Drawing.Point(40, 342);
            this.PrivateKeyIdTextBox.Name = "PrivateKeyIdTextBox";
            this.PrivateKeyIdTextBox.Size = new System.Drawing.Size(100, 20);
            this.PrivateKeyIdTextBox.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(37, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Enter public key ID(s) to encrypt for";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(37, 279);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Enter private key ID to sign with";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(496, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Enter block number to decrypt";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(37, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(382, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Seperate multiple entries with a comma(,) or a semi colon(;)";
            // 
            // BlockNumberDecrypt
            // 
            this.BlockNumberDecrypt.Location = new System.Drawing.Point(528, 113);
            this.BlockNumberDecrypt.Name = "BlockNumberDecrypt";
            this.BlockNumberDecrypt.Size = new System.Drawing.Size(100, 20);
            this.BlockNumberDecrypt.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(496, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(227, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Enter private key ID to decrypt with";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(496, 288);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(243, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "Enter public key ID to verify signature";
            // 
            // PrivateKeyDecrypt
            // 
            this.PrivateKeyDecrypt.Location = new System.Drawing.Point(528, 229);
            this.PrivateKeyDecrypt.Name = "PrivateKeyDecrypt";
            this.PrivateKeyDecrypt.Size = new System.Drawing.Size(100, 20);
            this.PrivateKeyDecrypt.TabIndex = 17;
            // 
            // PublicKeyVerify
            // 
            this.PublicKeyVerify.Location = new System.Drawing.Point(528, 342);
            this.PublicKeyVerify.Name = "PublicKeyVerify";
            this.PublicKeyVerify.Size = new System.Drawing.Size(100, 20);
            this.PublicKeyVerify.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 506);
            this.Controls.Add(this.PublicKeyVerify);
            this.Controls.Add(this.PrivateKeyDecrypt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BlockNumberDecrypt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PrivateKeyIdTextBox);
            this.Controls.Add(this.ReceiverKeyIdTextBox);
            this.Controls.Add(this.ReceiverNameTextBox);
            this.Controls.Add(this.labeltextDisplay);
            this.Controls.Add(this.ZoomButton);
            this.Controls.Add(this.SelectionButton);
            this.Controls.Add(this.Encrypt);
            this.Controls.Add(this.GetSelectedTextButton);
            this.Controls.Add(this.DisplayKeys);
            this.Controls.Add(this.DisplayRecords);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DisplayRecords;
        private System.Windows.Forms.Button DisplayKeys;
        private System.Windows.Forms.Button GetSelectedTextButton;
        private System.Windows.Forms.Button Encrypt;
        private System.Windows.Forms.Button SelectionButton;
        private System.Windows.Forms.Button ZoomButton;
        private System.Windows.Forms.Label labeltextDisplay;
        private System.Windows.Forms.TextBox ReceiverNameTextBox;
        private System.Windows.Forms.TextBox ReceiverKeyIdTextBox;
        private System.Windows.Forms.TextBox PrivateKeyIdTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox BlockNumberDecrypt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox PrivateKeyDecrypt;
        private System.Windows.Forms.TextBox PublicKeyVerify;
    }
}

