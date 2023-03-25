using sharedCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Documents;
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
            if (list.Count > 0)
            {
                this.Hide();
                var a = new SavingandPayment.PaymentOptions(list.ToList());

                a.ShowDialog();
                this.Dispose();

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

        private void button2_Click(object sender, EventArgs e)
        {
            List<Invoice> Invoice_list = new List<Invoice>();

            var CombinedInvoice = new Invoice() { ID = 999999999, CustomerName = "ورقة مجمعة لعدة فواتير", Comment = " " };
            list.ToList().ForEach(x => CombinedInvoice.Comment += x.ID.ToString() + " " ) ;
            CombinedInvoice.Comment += Environment.NewLine;
            CombinedInvoice.Comment += Environment.NewLine;

            var poslist = new List<POSItems>();
            poslist.Clear();
            foreach (var Invoice in list)
            {
                foreach (POSItems Material in Invoice.InvoiceItems)
                {
                    {
                        poslist.Add(Material);
                    }
                }
            }
            Orders.CurrentList.Clear();
            poslist.ForEach(x => Orders.CurrentList.Add(x));
            Orders.globalInvoice = CombinedInvoice;
            
            PrintInvoice.Print(dbQ.DefaultPrinters());
        }



    }
}
