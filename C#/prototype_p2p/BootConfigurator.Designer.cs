namespace prototype_p2p
{
    partial class BootConfigurator
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxRoleSelectorDropDown = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonFinishDataEntry = new System.Windows.Forms.Button();
            this.textBoxPortNumberEntry = new System.Windows.Forms.TextBox();
            this.textBoxNodeNameEntry = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selecteer de rol die van toepassing is";
            // 
            // comboBoxRoleSelectorDropDown
            // 
            this.comboBoxRoleSelectorDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRoleSelectorDropDown.FormattingEnabled = true;
            this.comboBoxRoleSelectorDropDown.Location = new System.Drawing.Point(34, 57);
            this.comboBoxRoleSelectorDropDown.Name = "comboBoxRoleSelectorDropDown";
            this.comboBoxRoleSelectorDropDown.Size = new System.Drawing.Size(180, 21);
            this.comboBoxRoleSelectorDropDown.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Voer het gewenste netwerk poort nummer in";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(250, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Voer de naam in waaronder data wordt toegevoegd";
            // 
            // buttonFinishDataEntry
            // 
            this.buttonFinishDataEntry.Location = new System.Drawing.Point(34, 162);
            this.buttonFinishDataEntry.Name = "buttonFinishDataEntry";
            this.buttonFinishDataEntry.Size = new System.Drawing.Size(103, 40);
            this.buttonFinishDataEntry.TabIndex = 5;
            this.buttonFinishDataEntry.Text = "Invoer afronden";
            this.buttonFinishDataEntry.UseVisualStyleBackColor = true;
            this.buttonFinishDataEntry.Click += new System.EventHandler(this.buttonFinishDataEntry_Click);
            // 
            // textBoxPortNumberEntry
            // 
            this.textBoxPortNumberEntry.Location = new System.Drawing.Point(34, 136);
            this.textBoxPortNumberEntry.Name = "textBoxPortNumberEntry";
            this.textBoxPortNumberEntry.Size = new System.Drawing.Size(100, 20);
            this.textBoxPortNumberEntry.TabIndex = 6;
            // 
            // textBoxNodeNameEntry
            // 
            this.textBoxNodeNameEntry.Location = new System.Drawing.Point(34, 97);
            this.textBoxNodeNameEntry.Name = "textBoxNodeNameEntry";
            this.textBoxNodeNameEntry.Size = new System.Drawing.Size(247, 20);
            this.textBoxNodeNameEntry.TabIndex = 7;
            // 
            // BootConfigurator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 224);
            this.Controls.Add(this.textBoxNodeNameEntry);
            this.Controls.Add(this.textBoxPortNumberEntry);
            this.Controls.Add(this.buttonFinishDataEntry);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxRoleSelectorDropDown);
            this.Controls.Add(this.label1);
            this.Name = "BootConfigurator";
            this.Text = "Configurator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxRoleSelectorDropDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonFinishDataEntry;
        private System.Windows.Forms.TextBox textBoxPortNumberEntry;
        private System.Windows.Forms.TextBox textBoxNodeNameEntry;
    }
}