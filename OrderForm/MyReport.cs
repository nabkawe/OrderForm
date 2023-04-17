using sharedCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
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
                // لتلاقي فواتير جاهز لازم ما تستخدم وقت الحفظ بما انه غير موجود في جاهز

                //dv = DbInv.GetAllSavedInvoices().FindAll(x => x.Status == sharedCode.InvStat.SavedToPOS && x.OrderType == "تطبيقات" && x.TimeOfPrinting != null && DateTime.Parse(x.TimeOfPrinting) > this.StartDate.Value && DateTime.Parse(x.TimeOfPrinting) < this.EndDate.Value);
                //dvReport.DataSource = dv;
                //this.totalSales.Text = dv.Sum(x => x.InvoicePrice).ToString();


                // Find the minimum and maximum unique IDs that correspond to the start and end dates
                var minUniqueId = DbInv.GetAllSavedInvoices()
                    .Where(x => x.Status == sharedCode.InvStat.SavedToPOS && x.OrderType == "تطبيقات" && x.TimeOfPrinting != null)
                    .Where(x => DateTime.TryParse(x.TimeOfPrinting, out var timeOfPrinting) && timeOfPrinting >= this.StartDate.Value)
                    .Select(x => Regex.Match(x.CustomerName, @"^جاهز(\d+)$"))
                    .Where(m => m.Success)
                    .Min(m => int.Parse(m.Groups[1].Value));

                var maxUniqueId = DbInv.GetAllSavedInvoices()
                    .Where(x => x.Status == sharedCode.InvStat.SavedToPOS && x.OrderType == "تطبيقات" && x.TimeOfPrinting != null)
                    .Where(x => DateTime.TryParse(x.TimeOfPrinting, out var timeOfPrinting) && timeOfPrinting <= this.EndDate.Value)
                    .Select(x => Regex.Match(x.CustomerName, @"^جاهز(\d+)$"))
                    .Where(m => m.Success)
                    .Max(m => int.Parse(m.Groups[1].Value));

                // Filter the invoices based on the unique ID range
                dv = DbInv.GetAllSavedInvoices().FindAll(x =>
                {
                    if (x.Status == sharedCode.InvStat.SavedToPOS && x.OrderType == "تطبيقات" && x.TimeOfPrinting != null)
                    {
                        if (DateTime.TryParse(x.TimeOfPrinting, out var timeOfPrinting))
                        {
                            return timeOfPrinting > this.StartDate.Value && timeOfPrinting < this.EndDate.Value;
                        }
                        else
                        {
                            var match = Regex.Match(x.CustomerName, @"^جاهز(\d+)$");
                            if (match.Success)
                            {
                                var uniqueId = int.Parse(match.Groups[1].Value);
                                return uniqueId >= minUniqueId && uniqueId <= maxUniqueId;
                            }
                        }
                    }
                    return false;
                    
                });
                dvReport.DataSource = dv;
                this.totalSales.Text = dv.Sum(x => x.InvoicePrice).ToString();


            }
            else if (All.Checked)
            {
                if (!HourSort.Checked) { 
                dv = DbInv.GetAllSavedInvoices().FindAll(x =>
                   x.TimeOfSaving > this.StartDate.Value
                && x.TimeOfSaving < this.EndDate.Value
                && x.Status == sharedCode.InvStat.SavedToPOS
                && x.OrderType != "تطبيقات");
                dvReport.DataSource = dv;
                this.totalSales.Text = dv.Sum(x => x.InvoicePrice).ToString();
                }
                else
                {
                    dv = DbInv.GetAllSavedInvoices()
    .Where(x => x.TimeOfSaving > this.StartDate.Value && x.TimeOfSaving < this.EndDate.Value && x.Status == sharedCode.InvStat.SavedToPOS && x.OrderType != "تطبيقات")
    .ToList();

                    var groupedInvoices = dv.GroupBy(x => x.TimeOfSaving.Hour * 2 + x.TimeOfSaving.Minute / 30);

                    var result = new List<Invoice>();
                    foreach (var group in groupedInvoices)
                    {
                        // Process each group of invoices that fall within the same half-hour interval
                        var invoice = group.First();
                        var hour = group.Key / 2;
                        var minute = (group.Key % 2) * 30;
                        invoice.OrderType = $"{hour:00}:{minute:00}";
                        invoice.InvoicePrice = group.Sum(x => x.InvoicePrice);
                        result.Add(invoice);
                    }

                    result = result.OrderByDescending(x => x.InvoicePrice).ToList();

                    this.totalSales.Text = result.Sum(x => x.InvoicePrice).ToString();
                    dvReport.AutoGenerateColumns = true;    
                    dvReport.DataSource = result;
                    dvReport.Refresh();
                }
            }
            MakePayments();
        }

        private void MakePayments()
        {
            //List<string> list = new List<string>();
            //List<Payment> TotalPayments = new List<Payment>();
            //dv.ForEach(x =>
            //{
            //    if (x.Payments.Count > 0)
            //    {
            //        if (x.Payments.Count == 1)
            //        {
            //            list.Add(x.PaymentName);
            //            TotalPayments.Add(x.Payments.First());
            //        }
            //        else
            //        {
            //            x.Payments.ForEach(z => { list.Add(z.Name); TotalPayments.Add(z); });

            //        }
            //    }
            //    else
            //    {
            //        list.Add(x.PaymentName);
            //        TotalPayments.Add(new Payment() { Name = x.PaymentName, Amount = x.InvoicePrice });
            //    }
            //}
            //);

            //var PayMethods = list.Distinct().ToList();
            //PaymentMethods.Controls.Clear();
            //PayMethods.ForEach(x => PaymentMethods.Controls.Add(CreatePaymentResult(x)));
            ////dv.ForEach(x => x.Payments.ForEach(y => TotalPayments.Add(y)));
            //foreach (var item in PayMethods)
            //{
            //    var tb = (TextBox)PaymentMethods.Controls.Find(item, false).First();
            //    tb.Text = item.Replace("_", " ") + ": " + TotalPayments.Where(x => x.Name == item).Sum(z => z.Amount).ToString();
            //}
            //totalSales.SendToBack();

            
                var list = new List<string>();
                var totalPayments = new List<Payment>();

                foreach (var x in dv)
                {
                    if (x.Payments.Count > 0)
                    {
                        list.AddRange(x.Payments.Select(z => z.Name));
                        totalPayments.AddRange(x.Payments);
                    }
                    else
                    {
                        list.Add(x.PaymentName);
                        totalPayments.Add(new Payment { Name = x.PaymentName, Amount = x.InvoicePrice });
                    }
                }

                var payMethods = list.Distinct().ToList();
                PaymentMethods.Controls.Clear();
                payMethods.ForEach(x => PaymentMethods.Controls.Add(CreatePaymentResult(x)));

                foreach (var item in payMethods)
                {
                    var tb = (TextBox)PaymentMethods.Controls.Find(item, false).First();
                    tb.Text = item.Replace("_", " ") + ": " + totalPayments.Where(x => x.Name == item).Sum(z => z.Amount);
                }

                totalSales.SendToBack();
            


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

        }

        private void MyReport_Load(object sender, EventArgs e)
        {

        }

        private void PaymentMethods_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
