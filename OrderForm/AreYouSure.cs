using System;
using System.Windows.Forms;

namespace OrderForm
{
    public partial class AreYouSure : Form
    {
        public AreYouSure()
        {
            InitializeComponent();
        }

        private void ChoiceClicked(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
