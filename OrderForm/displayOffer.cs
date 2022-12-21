using System;
using System.Windows.Forms;

namespace OrderForm
{
    public partial class displayOffer : Form
    {
        public displayOffer()
        {
            InitializeComponent();
        }

        private void displayOffer_Load(object sender, EventArgs e)
        {



        }

        public void stopNow()
        {
            timer1.Stop();
            this.Hide();
        }
        private void T_Tick(object sender, EventArgs e)
        {
            var t = (Timer)sender;
            t.Stop();
            this.Hide();

        }
        

    }
}
