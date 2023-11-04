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
    public partial class MessageForm : Form
    {
        public MessageForm()
        {
            InitializeComponent();
            // close form by pressing escape
            
        }
        /// <summary>
        /// MessageBox alternative.
        /// </summary>
        /// <param name="Title">Title of the Message</param>
        /// <param name="Message">Message Details</param>
        /// <param name="Yes">Ok/yes button Name</param>
        /// <param name="no">Optional buton if no name was passed the button will be just Ok/Yes.</param>
        /// <returns></returns>
        public static DialogResult SHOW(string Message, string Title, string Yes,[Optional] string no)
        {
            MessageForm form = new MessageForm();
            form.Text = Title;
            form.Message.Text = Message;
            form.YesBTN.Text = Yes;
            if (no != null)
            {
                form.NoBTN.Text = no;
                form.NoBTN.Visible = true;
            }
            else
            {
                form.NoBTN.Visible = false;
                form.YesBTN.Location = new Point(form.YesBTN.Location.X , form.YesBTN.Location.Y + 100);
                form.panel1.Size = new Size(form.panel1.Size.Width, form.panel1.Size.Height + 130);
            }

            // Add the ability to move the form by clicking on the title bar c#


            form.TopMost = true;
            form.Location = new System.Drawing.Point((Screen.PrimaryScreen.Bounds.Width / 2) - (form.Width / 2),
                                                          (Screen.PrimaryScreen.Bounds.Height / 2) - (form.Height / 2));
            form.ShowDialog();
            return form.DialogResult;
        }

        private void MessageForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.DialogResult = DialogResult.No;
                this.Close();
            }
            else if(e.KeyChar == (char)Keys.Enter)
            {
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }       
        }
    }
}
