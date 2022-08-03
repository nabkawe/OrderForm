using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
