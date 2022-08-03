using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderForm.Custom_UI_Elements
{
    public partial class MulipleSave : UserControl
    {
        public BindingList<Invoice> list = new BindingList<Invoice>();
        public MulipleSave()
        {
            InitializeComponent();
            lb.DataSource = list;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (list.Count>0)
            {
                this.Hide();
                var a = new SavingandPayment.PaymentOptions(list.ToList());
                
                a.ShowDialog();
                this.Show();

            }

        }

        private void RemoveMe(object sender, EventArgs e)
        {
            list.Clear();
            this.Parent.Controls.Remove(this); 
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                list.RemoveAt(lb.SelectedIndex);
                    }
            catch (Exception)
            {

                
            }
            
        }
    }
}
