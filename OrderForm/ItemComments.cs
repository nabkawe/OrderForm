using sharedCode;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Windows.UI.Xaml.Input;
using static System.Net.Mime.MediaTypeNames;

namespace OrderForm
{
    public partial class ItemComments : Form
    {
        public ItemComments()
        {
            InitializeComponent();

        }
        /// <summary>
        /// MessageBox alternative.
        /// </summary>
        /// <param name="Title">Title of the Message</param>
        /// <param name="Message">Message Details</param>
        /// <param name="Yes">Ok/yes button Name</param>
        /// <param name="no">Optional buton if no name was passed the button will be just Ok/Yes.</param>
        /// <returns></returns>
        public static string SHOW(POSsections PosSections, string TextComment, Point p,string itemName)
        {
            ItemComments form = new ItemComments();
            PosSections.NotesList.ForEach(x =>
            {
                var Check = new CheckBox() { Text = x };
                Check.AutoSize = true;
                Check.CheckedChanged += form.CheckBox_CheckedChanged;
                form.CheckBoxes.Controls.Add(Check);
                form.QuickCommentTB.Text = TextComment;

            });
            form.Left = p.X;
            form.Top = p.Y;
            form.Text = itemName;
            form.NotesLabel.Text += " " + itemName; 
            form.ShowDialog();
            if (form.DialogResult == DialogResult.Yes)
            {
                return form.QuickCommentTB.Text;
            }
            else
            {
                return "";
            }

        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var se = sender as CheckBox;
            if (se.Checked)
            {
                QuickCommentTB.Text += " " + se.Text;
            }
            else
            {
                QuickCommentTB.Text = QuickCommentTB.Text.Replace(se.Text, "");
            }
        }

        private void MessageForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.DialogResult = DialogResult.No;
                this.Close();
            }
            else if (e.KeyChar == (char)Keys.Enter)
            {
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
        }

        private void NineBTN_Click(object sender, EventArgs e)
        {
            var se = sender as Button;
            QuickCommentTB.Focus();
            QuickCommentTB.DeselectAll();
            // QuickCommentTB send key to the end of QuickCommentTB text
            QuickCommentTB.SelectionStart = QuickCommentTB.Text.Length;


          // check if the last char is not space and is not a digit
          if (QuickCommentTB.Text.Length > 0 && !char.IsDigit(QuickCommentTB.Text[QuickCommentTB.Text.Length - 1]) && QuickCommentTB.Text[QuickCommentTB.Text.Length - 1] != ' ')
            {
                SendKeys.Send(" ");
            }
            SendKeys.Send(se.Text);

        }

        private void uButton1_Click(object sender, EventArgs e)
        {
            QuickCommentTB.Focus();
            QuickCommentTB.DeselectAll();
            // QuickCommentTB send key to the end of QuickCommentTB text
            QuickCommentTB.SelectionStart = QuickCommentTB.Text.Length;

            SendKeys.Send(" ");
        }

        private void BackSpaceBTN_Click(object sender, EventArgs e)
        {
            QuickCommentTB.Focus();
            QuickCommentTB.DeselectAll();
            // QuickCommentTB send key to the end of QuickCommentTB text
            QuickCommentTB.SelectionStart = QuickCommentTB.Text.Length;

            SendKeys.Send("{BACKSPACE}");
        }

        private void QuickCommentTB_TextChanged(object sender, EventArgs e)
        {
            // remove every space that is more than two spaces or more
            QuickCommentTB.Text = QuickCommentTB.Text.Replace("  ", " ");

        }
    }
}
