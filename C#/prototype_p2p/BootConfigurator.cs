﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prototype_p2p
{
    public partial class BootConfigurator : Form
    {
        public BootConfigurator()
        {
            InitializeComponent();
            UpdatecomboBoxeDropDownRoleSelector();
            textBoxNodeNameEntry.Text = Program.NodeName;
            textBoxPortNumberEntry.Text = Program.NetworkPort.ToString();


        }

        private void CheckIfRedundant()
        {
            if (Program.existingRoles.Contains(Program.currentRole) && ValidatePortNumberEntry(Program.NetworkPort.ToString()) && Program.NodeName != "" && Program.NodeName != "Unknown")
            {
                this.Close();
            }
        }

        private void UpdatecomboBoxeDropDownRoleSelector()
        {
            comboBoxRoleSelectorDropDown.Items.Clear();
            foreach (string role in Program.existingRoles)
            {
                comboBoxRoleSelectorDropDown.Items.Add(role);
            }
            comboBoxRoleSelectorDropDown.Text = Program.currentRole;
        }

        private bool ValidateNodeNameEntry()
        {
            return (textBoxNodeNameEntry.Text != "" && textBoxNodeNameEntry.Text != "Unknown" && textBoxNodeNameEntry.Text.Length > 1);
        }

        public bool ValidatePortNumberEntry(string portToValidate)
        {
                if (int.TryParse(portToValidate, out int port) && portToValidate.Length > 0)
                {
                    port = Math.Abs(port);
                    if (!Program.portBlacklist.Contains(port)) //checks if the entered port is on the blacklist
                    {
                        return true;   
                    }
                    else
                    {
                        MessageBox.Show("The port number must not be one of the following: " + string.Join<int>(", ", Program.portBlacklist));
                        return false;
                    }  
                }
                else
                {
                    MessageBox.Show("A port has to be a number. Try again.");
                    return false;
                }
        }

        private void buttonFinishDataEntry_Click(object sender, EventArgs e)
        {
            
            if (ValidatePortNumberEntry(textBoxPortNumberEntry.Text) && ValidateNodeNameEntry() && comboBoxRoleSelectorDropDown.Text.Length > 1)
            {
                Program.currentRole = comboBoxRoleSelectorDropDown.Text;
                Program.NodeName = textBoxNodeNameEntry.Text;
                Program.NetworkPort = Math.Abs(int.Parse(textBoxPortNumberEntry.Text));
                this.Close();
            }
        }
    }
}
