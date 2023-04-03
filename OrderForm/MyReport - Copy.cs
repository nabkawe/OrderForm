using sharedCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace OrderForm
{
    public partial class MyMatReport : Form
    {
        public MyMatReport()
        {
            InitializeComponent();
            var dt = new DateTime();
            dt = DateTime.Today;
            dt = dt.AddHours(00);
            dt = dt.AddMinutes(00);
            dt = dt.AddSeconds(00);
            StartDate.Value = dt;

            dt = DateTime.Today;
            dt = dt.AddHours(23);
            dt = dt.AddMinutes(59);
            dt = dt.AddSeconds(59);
            EndDate.Value = dt;
            comboBox1.DataSource = dbQ.LoadMaterialItems();
            comboBox1.DisplayMember = "Name";

        }
        public List<Invoice> dv = new List<Invoice>();
        public List<POSItems> L = new List<POSItems>();

        private void FindAll_Click(object sender, EventArgs e)
        {
            if (ModifierKeys.HasFlag(Keys.Control))
            {
                GetAllReport();
                return;
            }
            if (eatIn.Checked)
            {
                dv = DbInv.GetAllSavedInvoices().FindAll(x => x.TimeOfSaving > this.StartDate.Value && x.TimeOfSaving < this.EndDate.Value && x.Status == sharedCode.InvStat.SavedToPOS && x.OrderType == "محلي");
                L.Clear();
                dv.ForEach(x => { if (x.InvoiceItems.Any(y => y.Name == comboBox1.Text)) { L.Add(x.InvoiceItems.First(z => z.Name == comboBox1.Text)); } });
                this.totalSales.Text = L.Sum(x => x.Quantity).ToString();
                this.MatTotalSales.Text = L.Sum(x => x.TotalPrice).ToString();


            }
            else if (Phone.Checked)
            {
                // لتلاقي فواتير جاهز لازم ما تستخدم وقت الحفظ بما انه غير موجود في جاهز
                dv = DbInv.GetAllSavedInvoices().FindAll(x => x.TimeOfSaving > this.StartDate.Value && x.TimeOfSaving < this.EndDate.Value && x.Status == sharedCode.InvStat.SavedToPOS && x.OrderType == "هاتف");
                L.Clear();
                dv.ForEach(x => { if (x.InvoiceItems.Any(y => y.Name == comboBox1.Text)) { L.Add(x.InvoiceItems.First(z => z.Name == comboBox1.Text)); } });

                this.totalSales.Text = L.Sum(x => x.Quantity).ToString();
                this.MatTotalSales.Text = L.Sum(x => x.TotalPrice).ToString();
                dvReport.DataSource = null;
                dvReport.DataSource = L;

            }
            else if (toGo.Checked)
            {
                dv = DbInv.GetAllSavedInvoices().FindAll(x => x.TimeOfSaving > this.StartDate.Value && x.TimeOfSaving < this.EndDate.Value && x.Status == sharedCode.InvStat.SavedToPOS && x.OrderType == "سفري" && x.CustomerName == "" && x.CustomerNumber == "");
                L.Clear();
                dv.ForEach(x => { if (x.InvoiceItems.Any(y => y.Name == comboBox1.Text)) { L.Add(x.InvoiceItems.First(z => z.Name == comboBox1.Text)); } });

                this.totalSales.Text = L.Sum(x => x.Quantity).ToString();
                this.MatTotalSales.Text = L.Sum(x => x.TotalPrice).ToString();
                dvReport.DataSource = null;
                dvReport.DataSource = L;

            }
            else if (Jahez.Checked)
            {
                dv = DbInv.GetAllSavedInvoices().FindAll(x => x.Status == sharedCode.InvStat.SavedToPOS && x.OrderType == "تطبيقات" && x.TimeOfPrinting != null && DateTime.Parse(x.TimeOfPrinting) > this.StartDate.Value && DateTime.Parse(x.TimeOfPrinting) < this.EndDate.Value);
                L.Clear();
                dv.ForEach(x => { if (x.InvoiceItems.Any(y => y.Name == comboBox1.Text)) { L.Add(x.InvoiceItems.First(z => z.Name == comboBox1.Text)); } });
                dvReport.DataSource = L;
                this.totalSales.Text = L.Sum(x => x.Quantity).ToString();
                this.MatTotalSales.Text = L.Sum(x => x.TotalPrice).ToString();

            }
            else if (All.Checked)
            {
                dv = DbInv.GetAllSavedInvoices().FindAll(x => x.TimeOfSaving > this.StartDate.Value && x.TimeOfSaving < this.EndDate.Value && x.Status == sharedCode.InvStat.SavedToPOS);
                L.Clear();
                dv.ForEach(x => { if (x.InvoiceItems.Any(y => y.Name == comboBox1.Text)) { L.Add(x.InvoiceItems.First(z => z.Name == comboBox1.Text)); } });
                this.totalSales.Text = L.Sum(x => x.Quantity).ToString();
                this.MatTotalSales.Text = L.Sum(x => x.TotalPrice).ToString();
                dvReport.DataSource = null;
                dvReport.DataSource = L;
            }

        }

        private void ByPriceDescending(object sender, EventArgs e)
        {
            if (OrderDirection.Checked)
            {
                dvReport.DataSource = L.OrderByDescending(x => x.TotalPrice).ToList();
            }
            else
            {
                dvReport.DataSource = L.OrderBy(x => x.TotalPrice).ToList();
            }
        }

        private void GetAllReport(){
            
            dv = DbInv.GetAllSavedInvoices().FindAll(x => x.TimeOfSaving > this.StartDate.Value && x.TimeOfSaving < this.EndDate.Value && x.Status == sharedCode.InvStat.SavedToPOS);
            L.Clear();
            dv.ForEach(x => x.InvoiceItems.ForEach(z => L.Add(z)));
             var grouped = L.GroupBy(x => x.Barcode);
            foreach (var group in grouped)
            {
                var totalItems = group.First();
                totalItems.Quantity = group.Sum(item => item.Quantity);
                totalItems.Name = " [مبيع مادة] " + totalItems.Name ;
            }
            L = L.GroupBy(item => item.Barcode).Select(group => group.First()).ToList();
            


            this.totalSales.Text = L.Sum(x => x.Quantity).ToString();
            this.MatTotalSales.Text = L.Sum(x => x.TotalPrice).ToString();
            dvReport.DataSource = null;
            dvReport.DataSource = L;
        }


    }
}
