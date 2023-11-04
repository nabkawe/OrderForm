using sharedCode;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace OrderForm
{
    public partial class Discounnt : Form
    {
        public Discounnt()
        {
            InitializeComponent();
            dc.CausesValidation = true;
            dc.Validating += new System.ComponentModel.CancelEventHandler(textBox1_Validating);
            dc.Select();

        }
        public POSItems GetDiscount()
        {
            dc.Select();

            ShowDialog();
            dc.Focus();
            if (dc.Text.Trim() != "" && this.DialogResult == DialogResult.OK)
            {
                var item = new POSItems();
                item.Quantity = 1;
                item.Barcode = "discount";
                item.Name = "خصم";
                item.Price = -Decimal.Parse(dc.Text);
                item.Comment = errorRB.Checked ? errorRB.Text : DiscountRB.Text;

                return item;
            }
            else
            {
                return null;
            }

        }
        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            dc.Text = string.Format("{0:$#.00}", dc.Text);
            if (!double.TryParse(dc.Text, out double result))
            {
                e.Cancel = true;
            }
        }


        private void ChoiceClicked(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ApplyDiscount.PerformClick();
            }

        }

        private void Discounnt_Load(object sender, EventArgs e)
        {
            dc.Select();

        }
    }
}
