using sharedCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.ApplicationModel.Background;

namespace OrderForm
{
    public partial class ReadyOrders : Form
    {
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public ReadyOrders()
        {
            InitializeComponent();
            oldinvoices = new List<Invoice>();
            timer.Interval = (1);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }
        private DateTime ParseExactS(string datestring)
        {
            datestring = datestring.Replace("OrderReady:", "").Trim();
            var DT = DateTime.ParseExact(datestring,"yyyy-MM-dd HH:mm:ss",CultureInfo.InvariantCulture);
            Console.WriteLine(DT);
            return DT;
        }

        List<Invoice> oldinvoices;
        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Interval = 10000;

            if (Properties.Settings.Default.Api_On)
            {
                var invoices = new List<Invoice>();
                invoices.AddRange(DbInv.GetLast42Ready());
                invoices = invoices.Where(x => x.InvoiceTimeloglist.Any(z => z.Contains("OrderReady")) && (DateTime.Now - ParseExactS(x.InvoiceTimeloglist.First())).TotalHours <= 1 ).OrderByDescending(x => x.CustomerName?.Contains("جاهز")).ThenByDescending(x => x.CustomerName?.Contains("هنقر")).ThenByDescending(x => x.CustomerName?.Contains("مرسول")).ThenByDescending(x => x.CustomerName?.Length > 0).ThenByDescending(x => x.CustomerName == "").Take(24).ToList();
                Console.WriteLine("ReadyOrders: " + invoices.Count);
                if (!CompareLists(invoices))
                {
                    flowLayoutPanel1.Controls.Clear();
                    foreach (Invoice inv in invoices)
                    {
                        flowLayoutPanel1.Controls.Add(CreateBTN(inv.CustomerName ?? "", inv.IDstring, inv.CustomerNumber ?? ""));
                    }
                    oldinvoices.Clear();
                    invoices.ForEach(x => oldinvoices.Add(x));
                }
            }

        }
        private bool CompareLists(List<Invoice> invoices)
        {
            bool result = true;
            if (invoices.Count != oldinvoices.Count)
            {
                result = false;
            }
            else
            {
                for (int i = 0; i < invoices.Count; i++)
                {
                    if (invoices[i].IDstring != oldinvoices[i].IDstring)
                    {
                        result = false;
                    }
                }
            }
            return result;
        }

        Button CreateBTN(string name, string id, string Phonenumber)
        {
            var btn = new Button();
            if (name.Trim() != "" && Phonenumber.Length < 4) 
            {
                btn.Text = name + "";
            }
            if (name.Trim() == "" && Phonenumber.Trim()=="")
            {
                btn.Text = $"طلب سفري \n 💳 \n {id}";
                
            }
            if (name.Trim() != "" && Phonenumber.Trim() != "" && Phonenumber.Length > 4)
            {
                if (name.Length > 12)
                {
                    btn.Text = name.Substring(0, 12) + "..." + "\n" + "📱" + "\n" + "0XXXXX" + Phonenumber.Trim().Substring(Phonenumber.Length - 4);
                }
                else
                {
                    btn.Text = name + "\n" + "📱" + "\n" + "0XXXXX" + Phonenumber.Trim().Substring(Phonenumber.Length - 4);
                }
                
            }
            
            if (name.Contains("هنقر"))
            {
                btn.ForeColor = System.Drawing.Color.Yellow;
                btn.BackColor = System.Drawing.Color.Brown;
                btn.Text += "🛵";
                btn.Text = btn.Text.Replace(":", "");
                btn.Text = btn.Text.Replace("هنقر", "هنقرستيشين");

            }
            else if (name.Contains("جاهز"))
            {
                btn.BackColor = System.Drawing.Color.Red;
                btn.ForeColor = System.Drawing.Color.White;
                btn.Text += Environment.NewLine+  "🛵";

            }
            else if (name.Contains("مرسول"))
            {
                btn.Text += "🛵";
                btn.Text = btn.Text.Replace(":#", "");
                btn.BackColor = System.Drawing.Color.Green;
                btn.ForeColor = System.Drawing.Color.White;

            }
            else
            {
                btn.ForeColor = Color.FromArgb(0, 104, 66, 25);
                btn.BackColor = System.Drawing.Color.White;

            }



            btn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btn.Size = new System.Drawing.Size(312, 200);

            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = Color.FromArgb(0, 104, 66, 25);
            btn.FlatAppearance.BorderSize = 10;
            btn.FlatStyle = FlatStyle.Popup;
        
            // can I add a skooter emoji in the btn text?
            btn.Font = new System.Drawing.Font("Segoe UI Emoji", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            
            
            
            
            

            

            btn.TabStop = false;
            btn.UseVisualStyleBackColor = true;
            return btn;
        }
        private void ReadyOrders_Load(object sender, EventArgs e)
        {
            this.Location = Screen.AllScreens[1].WorkingArea.Location;
            this.Height = Screen.AllScreens[1].WorkingArea.Height;
            this.Width = Screen.AllScreens[1].WorkingArea.Width;

        }
    }
}
