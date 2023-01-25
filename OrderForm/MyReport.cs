using sharedCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace OrderForm
{
    public partial class MyReport : Form
    {
        public MyReport()
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


        }
        public List<Invoice> dv = new List<Invoice>();
        private void FindAll_Click(object sender, EventArgs e)
        {
            if (eatIn.Checked)
            {
                dv = DbInv.GetAllSavedInvoices().FindAll(x => x.TimeOfSaving > this.StartDate.Value && x.TimeOfSaving < this.EndDate.Value && x.Status == sharedCode.InvStat.SavedToPOS && x.OrderType == "محلي");
                dvReport.DataSource = dv;
                this.totalSales.Text = dv.Sum(x => x.InvoicePrice).ToString();
            }
            else if (Phone.Checked)
            {
                // لتلاقي فواتير جاهز لازم ما تستخدم وقت الحفظ بما انه غير موجود في جاهز
                dv = DbInv.GetAllSavedInvoices().FindAll(x => x.TimeOfSaving > this.StartDate.Value && x.TimeOfSaving < this.EndDate.Value && x.Status == sharedCode.InvStat.SavedToPOS && x.OrderType == "هاتف");
                dvReport.DataSource = dv;
                this.totalSales.Text = dv.Sum(x => x.InvoicePrice).ToString();
            }
            else if (toGo.Checked)
            {
                dv = DbInv.GetAllSavedInvoices().FindAll(x => x.TimeOfSaving > this.StartDate.Value && x.TimeOfSaving < this.EndDate.Value && x.Status == sharedCode.InvStat.SavedToPOS && x.OrderType == "سفري" && x.CustomerName == "" && x.CustomerNumber == "");
                dvReport.DataSource = dv;
                this.totalSales.Text = dv.Sum(x => x.InvoicePrice).ToString();

            }
            else if (Jahez.Checked)
            {
                dv = DbInv.GetAllSavedInvoices().FindAll(x => x.Status == sharedCode.InvStat.SavedToPOS && x.OrderType == "تطبيقات");
                dvReport.DataSource = dv;
                this.totalSales.Text = dv.Sum(x => x.InvoicePrice).ToString();

            }
            else if (All.Checked)
            {
                dv = DbInv.GetAllSavedInvoices().FindAll(x => x.TimeOfSaving > this.StartDate.Value && x.TimeOfSaving < this.EndDate.Value && x.Status == sharedCode.InvStat.SavedToPOS);
                dvReport.DataSource = dv;
                this.totalSales.Text = dv.Sum(x => x.InvoicePrice).ToString();
            }
        }

        private void ByPriceDescending(object sender, EventArgs e)
        {
            if (OrderDirection.Checked)
            {
                dvReport.DataSource = dv.OrderByDescending(x => x.InvoicePrice).ToList();
            }
            else
            {
                dvReport.DataSource = dv.OrderBy(x => x.InvoicePrice).ToList();
            }
        }

        static TextBox CreatePaymentResult(string Name)
        {
            var tb = new TextBox();
            tb.Dock = System.Windows.Forms.DockStyle.Left;
            tb.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tb.Location = new System.Drawing.Point(131, 0);
            tb.Name = Name;
            tb.ReadOnly = true;
            tb.Size = new System.Drawing.Size(200, 30);
            tb.TextAlign = HorizontalAlignment.Center;
            tb.RightToLeft = RightToLeft.Yes;
            tb.Text = Name.Replace("_", " ") + ": ";
            tb.Click += Tb_Click;
            return tb;
        }

        private static void Tb_Click(object sender, EventArgs e)
        {
            var se = (TextBox)sender;
            MessageBox.Show(se.Name.ToString());
        }

        private void dvReport_DataSourceChanged(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            List<Payment> TotalPayments = new List<Payment>();
            dv.ForEach(x =>
            {
                if (x.Payments.Count > 0)
                {
                    if (x.Payments.Count == 1)
                    {
                        list.Add(x.PaymentName);
                        TotalPayments.Add(x.Payments[0]);
                    }
                    else
                    {
                        x.Payments.ForEach(z => { list.Add(z.Name); TotalPayments.Add(z); });

                    }
                }
                else
                {
                    list.Add(x.PaymentName);
                    TotalPayments.Add(new Payment() { Name = x.PaymentName, Amount = x.InvoicePrice });
                }
            }
            );

            var PayMethods = list.Distinct().ToList();
            PayMethods.ForEach(x => PaymentMethods.Controls.Add(CreatePaymentResult(x)));
            dv.ForEach(x => x.Payments.ForEach(y => TotalPayments.Add(y)));
            foreach (var item in PayMethods)
            {
                var tb = (TextBox)PaymentMethods.Controls.Find(item, false).First();
                tb.Text = item.Replace("_", " ") + ": " + TotalPayments.Where(x => x.Name == item).Sum(z => z.Amount).ToString();

            }

            totalSales.SendToBack();

        }

    }
}
