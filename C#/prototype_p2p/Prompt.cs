using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prototype_p2p
{
    public static class Prompt
    {
        public static string ShowDialog(string text, string caption, bool acceptsReturn = true, bool acceptsTab = true, bool multiline = true)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 450,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text, Width = 400 };
            TextBox textBox = new TextBox() { Left = 50, Top = 70, Width = 400, Height = 300 };
            textBox.AcceptsReturn = acceptsReturn;
            textBox.AcceptsTab = acceptsTab;
            textBox.Multiline = multiline;
            textBox.ScrollBars = ScrollBars.Vertical;
            Button confirmation = new Button() { Text = "Ok", Left = 50, Width = 100, Top = 40, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}
