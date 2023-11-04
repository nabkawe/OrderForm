using sharedCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        List<Invoice> oldinvoices;
        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Interval = 5000;

            if (Properties.Settings.Default.Api_On)
            {
                var invoices = new List<Invoice>();
                invoices.AddRange(DbInv.GetLast42Ready());
                invoices = invoices.OrderByDescending(x => x.CustomerName?.Contains("جاهز")).ThenByDescending(x => x.CustomerName?.Contains("هنقر")).ThenByDescending(x => x.CustomerName?.Length > 0).ThenByDescending(x => x.CustomerName == "").ToList();
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
                btn.Text = name;
            }
            if (name.Trim() == "" && Phonenumber.Trim()=="")
            {
                btn.Text = $"رقم الطلب: {id}";
                
            }
            if (name.Trim() != "" && Phonenumber.Trim() != "" && Phonenumber.Length > 4)
            {
                btn.Text = name + "\n" + "0XXXXX" + Phonenumber.Substring(Phonenumber.Length - 4);
            }
            
            if (name.Contains("هنقر"))
            {
                btn.BackColor = System.Drawing.Color.Yellow;
                btn.ForeColor = System.Drawing.Color.Brown;

            }
            else if (name.Contains("جاهز"))
            {
                btn.BackColor = System.Drawing.Color.Red;
                btn.ForeColor = System.Drawing.Color.White;

            }
            else
            {
                btn.BackColor = System.Drawing.Color.White;

            }


            btn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            btn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.Size = new System.Drawing.Size(291, 130);
            btn.TabStop = false;
            btn.UseVisualStyleBackColor = false;
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
