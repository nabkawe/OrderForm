using System;
using System.Drawing;
using System.Windows.Forms;

namespace OrderForm
{
    public partial class SureMsg : Form
    {
        public SureMsg()
        {
            InitializeComponent();
            DeleteBTN.DialogResult = DialogResult.OK;
            this.TopMost = true;

        }
        public int countDown = 0;
        private void SureMsg_Load(object sender, EventArgs e)
        {
            this.Location = new Point(Cursor.Position.X - this.Width / 3, Cursor.Position.Y - this.Height / 2);

            tmr.Start();
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            if (countDown < 1 == true)
            {
                countDown += 1;
            }
            else
            {
                Close();

            }//implement later
        }

        private void DeleteBTN_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void DeleteBTN_Click(object sender, EventArgs e)
        {
            this.Close();


        }
    }
}
