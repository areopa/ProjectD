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
        RichTextBox dynamicRichTextBox;
        RichTextBox dynamicRichTextBox2;
        RichTextBox dynamicRichTextBox3;
        ParseKeyID keyIDPaths;
        ConfigFile configData;
        FlushBlock flushMsgAndSend;
        Chain ProjectD;

        public Form1(ParseKeyID keyIDPaths, ConfigFile configData, FlushBlock flushMsgAndSend, Chain ProjectD)
        {
            this.keyIDPaths = keyIDPaths;
            this.configData = configData;
            this.flushMsgAndSend = flushMsgAndSend;
            this.ProjectD = ProjectD;
            InitializeComponent();
            //dynamicRichTextBox = new RichTextBox();
            //dynamicRichTextBox.Location = new Point(20, 20);
            //dynamicRichTextBox.Width = 300;
            //dynamicRichTextBox.Height = 200;
            // Set background and foreground
            //dynamicRichTextBox.BackColor = Color.White;
            //dynamicRichTextBox.ForeColor = Color.Black;
            //dynamicRichTextBox.Top = 80;
            //dynamicRichTextBox.BorderStyle = BorderStyle.FixedSingle;

            //dynamicRichTextBox.Name = "Input field";
            //dynamicRichTextBox.Font = new Font("Georgia", 16);
            //dynamicRichTextBox.Text = "I am Dynamic RichTextBox";
            //int size = dynamicRichTextBox.TextLength;
            
            
            
            // accepts TAB key
            //dynamicRichTextBox.AcceptsTab = true;
            //dynamicRichTextBox.WordWrap = true;
            //dynamicRichTextBox.ScrollBars = RichTextBoxScrollBars.Both;

            //dynamicRichTextBox.ReadOnly = true;
            //dynamicRichTextBox.MaxLength = 50;

            //dynamicRichTextBox.ShortcutsEnabled = true;

            //dynamicRichTextBox.EnableAutoDragDrop = true;



            //Controls.Add(dynamicRichTextBox);
        }

        // Create a RichTextBox object 


        private void CreateButton_Click(object sender, EventArgs e)
        {
            //Console.WriteLine("Chain");
            //Console.WriteLine(JsonConvert.SerializeObject(ProjectD, Formatting.Indented));
            SimpleReportViewer.ShowDialog(JsonConvert.SerializeObject(ProjectD, Formatting.Indented), "Chain data", this);
        }

        private void GetLinesButton_Click(object sender, EventArgs e)
        {
            if (ProjectD.ChainList.Count > 1) //1 and not 0 because the genesis block counts as one.
            {
                string blockNumber;
                int blockNumerInt;
                {
                    blockNumber = BlockNumberDecrypt.Text;
                    if (int.TryParse(blockNumber, out int inputBlockNumber)) //checks if the given input is a string. If not the user is told to enter a number. No more crashes because you accidently pressed enter.
                    {

                        if (inputBlockNumber >= ProjectD.ChainList.Count)
                        {
                            MessageBox.Show("The block number you enter must correspond to an existing block. Try again.");
                        }
                        else
                        {
                            blockNumerInt = Math.Abs(inputBlockNumber);
                            string encryptedDataFromChain = ProjectD.ChainList[blockNumerInt].MessageList[0].Data;
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

        private void GetSelectedTextButton_Click(object sender, EventArgs e)
        {

            SimpleReportViewer.ShowDialog(keyIDPaths.ReturnAllLoadedKeyPathsAsString(), "All known keys", this);
        }

        private void LoadRTFButton_Click(object sender, EventArgs e)
        {
            string[] receiverNames = ReceiverNameTextBox.Lines;         
            string receiverNamesForImprovedMultiEnc = ReceiverNameTextBox.Text;


            string privKeyPath = keyIDPaths.ParseAndReturnVerifiedKeyPathGUI(PrivateKeyIdTextBox.Text);


            string[] recipientKeyPathsArr = keyIDPaths.BuildVerifiedKeyIdPathArrayGUI(ReceiverKeyIdTextBox.Text);

            string inputData = Prompt.ShowDialog("Enter the data you want to encrypt", "Data entry");

            string encData = EncryptFileMultipleRecipients.MultiRecipientStringEncrypter(inputData, privKeyPath, recipientKeyPathsArr, true);
            Console.WriteLine(encData);

            flushMsgAndSend.Flush(receiverNamesForImprovedMultiEnc, encData);
            ProjectD.SaveChainStateToDisk(ProjectD);
            ReceiverNameTextBox.Text = "";
            ReceiverKeyIdTextBox.Text = "";
            PrivateKeyIdTextBox.Text = "";
        }

        private void SelectionButton_Click(object sender, EventArgs e)
        {
            dynamicRichTextBox.BackColor = Color.White;
            dynamicRichTextBox.Clear();

            dynamicRichTextBox.BulletIndent = 10;
            dynamicRichTextBox.SelectionFont = new Font("Georgia", 16, FontStyle.Bold);
            dynamicRichTextBox.SelectedText = "Mindcracker Network \n";
            dynamicRichTextBox.SelectionFont = new Font("Verdana", 12);
            dynamicRichTextBox.SelectionBullet = true;
            dynamicRichTextBox.SelectionColor = Color.DarkBlue;
            dynamicRichTextBox.SelectedText = "C# Corner" + "\n";
            dynamicRichTextBox.SelectionFont = new Font("Verdana", 12);
            dynamicRichTextBox.SelectionColor = Color.Orange;
            dynamicRichTextBox.SelectedText = "VB.NET Heaven" + "\n";
            dynamicRichTextBox.SelectionFont = new Font("Verdana", 12);
            dynamicRichTextBox.SelectionColor = Color.Green;
            dynamicRichTextBox.SelectedText = ".Longhorn Corner" + "\n";
            dynamicRichTextBox.SelectionColor = Color.Red;
            dynamicRichTextBox.SelectedText = ".NET Heaven" + "\n";
            dynamicRichTextBox.SelectionBullet = false;
            dynamicRichTextBox.SelectionFont = new Font("Tahoma", 10);
            dynamicRichTextBox.SelectionColor = Color.Black;
            dynamicRichTextBox.SelectedText = "This is a list of Mindcracker Network websites.\n";



        }

        private void ZoomButton_Click(object sender, EventArgs e)
        {
            dynamicRichTextBox.AutoWordSelection = true;
            dynamicRichTextBox.RightMargin = 5;
            dynamicRichTextBox.ZoomFactor = 3.0f;
        }
    }
}
