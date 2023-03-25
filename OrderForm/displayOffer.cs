using sharedCode;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace OrderForm
{
    public partial class displayOffer : Form
    {

        public static event EventHandler<string> TimeUp;

        public displayOffer()
        {
            InitializeComponent();
            TimeUp += DisplayOffer_TimeUp;
            LogoPic.BackgroundImage = Bitmap.FromFile(Properties.Settings.Default.Logo);
        }




        public static void showme(string ClientName, string ClientPhone, string ClientDate)
        {

            Orders.MenuShowing = true;
            var Show = new displayOffer();
            Show.timer1.Start();
            Show.timer1.Tick += Show.T_Tick;
            if (ClientDate != null) { if (ClientDate.Replace(" ", "") != "") Show.ClientDate.Text = ClientDate; else { Show.ClientDate.Visible = false; Show.DateTitle.Visible = false; } }
            if (ClientName != null) { if (ClientName.Replace(" ", "") != "") Show.ClientName.Text = ClientName; else { Show.ClientName.Visible = false; Show.ClientTitle.Visible = false; } }
            if (ClientPhone != null) { if (ClientPhone.Replace(" ", "") != "") Show.ClientPhone.Text = "05XXXX" + ClientPhone.Substring(6); else { Show.ClientPhone.Visible = false; Show.PhoneTitle.Visible = false; } }
            Show.Show();
            Show.POS_ListChanged(null, null);

        }
        public static void showme(string ClientName, string ClientPhone, string ClientDate, Invoice inv)
        {

            Orders.MenuShowing = true;
            var Show = new displayOffer();
            Show.timer1.Start();
            Show.timer1.Tick += Show.T_Tick;
            if (ClientDate != null) { if (ClientDate.Replace(" ", "") != "") Show.ClientDate.Text = ClientDate; else { Show.ClientDate.Visible = false; Show.DateTitle.Visible = false; } }
            if (ClientName != null) { if (ClientName.Replace(" ", "") != "") Show.ClientName.Text = ClientName; else { Show.ClientName.Visible = false; Show.ClientTitle.Visible = false; } }
            if (ClientPhone != null) { if (ClientPhone.Replace(" ", "") != "") Show.ClientPhone.Text = "05XXXX" + ClientPhone.Substring(6); else { Show.ClientPhone.Visible = false; Show.PhoneTitle.Visible = false; } }
            Show.Show();
            Show.POS_ListChanged(null, null);
            Show.dvItems2.DataSource = inv.InvoiceItems;
            Show.Price.Text = inv.InvoicePrice.ToString();
            var c = inv.InvoiceItems.Sum<POSItems>((x) => x.RealQuantity).ToString();
            Show.ItemCount.Text = $"عدد المواد المطلوبة: \n\n {c}";


        }


        private void DisplayOffer_TimeUp(object sender, string e)
        {
            if (e == "Stop")
            {
                Orders.MenuShowing = false;
                timer1.Stop();
                Close();

            }


        }


        private void displayOffer_Load(object sender, EventArgs e)
        {
            this.Location = Screen.AllScreens[1].WorkingArea.Location;
            this.Height = Screen.AllScreens[1].WorkingArea.Height;
            this.Width = Screen.AllScreens[1].WorkingArea.Width;
            if (this.Height > this.Width)
            {
                //this.Payment.Height += 300;
                //this.dvItems2.Height += 350;
            }
            else { this.Payment.Visible = false; this.LogoPic.Visible = false; this.panel1.Dock = DockStyle.Top; this.panel1.SendToBack(); }
                

                dvItems2.DataSource = Orders.POS;
            Orders.POS.ListChanged += POS_ListChanged;
            var cellstyleMaterial = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.Black,
                SelectionBackColor = Color.White,
                SelectionForeColor = Color.Black,
                Font = new System.Drawing.Font("Segoe UI", 14, System.Drawing.FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter
                ,
                Padding = new System.Windows.Forms.Padding(5, 5, 5, 5)
            };
            var cellstyleAlternate = new DataGridViewCellStyle
            {
                BackColor = Color.GhostWhite,
                ForeColor = Color.Black,
                SelectionBackColor = Color.GhostWhite,
                SelectionForeColor = Color.Black,
                Alignment = DataGridViewContentAlignment.MiddleCenter
      ,
                Padding = new System.Windows.Forms.Padding(5, 5, 5, 5)
            };
            var cellstyleHeader = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.Black,
                SelectionBackColor = Color.White,
                SelectionForeColor = Color.Black,
                Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.TopCenter

            };
            dvItems2.ColumnHeadersHeight = 30;
            dvItems2.AlternatingRowsDefaultCellStyle = cellstyleAlternate;
            dvItems2.ColumnHeadersDefaultCellStyle.ApplyStyle(cellstyleHeader);
            dvItems2.ReadOnly = true;
            dvItems2.Columns[0].Width = 300;// Name
            dvItems2.Columns[0].HeaderText = "إسم المادة";
            dvItems2.Columns[0].DefaultCellStyle = cellstyleMaterial;

            dvItems2.Columns[1].Width = 100;// Quantity
            dvItems2.Columns[1].HeaderText = "العدد";
            dvItems2.Columns[1].DefaultCellStyle = cellstyleMaterial;

            var cellstyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.Black,
                SelectionBackColor = Color.White,
                SelectionForeColor = Color.Black,
                Font = new System.Drawing.Font("Segoe UI", 8, System.Drawing.FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };

            dvItems2.Columns[2].Width = 200;// Price
            dvItems2.Columns[2].HeaderText = " سعر المادة";
            dvItems2.Columns[2].DefaultCellStyle = cellstyle;

            dvItems2.Columns[3].Width = 100;// TotalPrice
            dvItems2.Columns[3].HeaderText = "إجمالي";
            dvItems2.Columns[3].DefaultCellStyle = cellstyle;

            dvItems2.Columns[4].Width = 150;// Comment
            dvItems2.Columns[4].HeaderText = "ملاحظات";
            dvItems2.Columns[4].DefaultCellStyle = cellstyle;
            //dvItems2.Refresh();
            //dvItems2.Update();

            dvItems2.Columns[4].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;

        }

        private void POS_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            if (Orders.POS.Count > 0)
            {
                decimal total = Orders.POS.Sum<POSItems>((a) => a.TotalPrice);
                Price.Text = total.ToString();

                var c = Orders.POS.Sum<POSItems>((x) => x.RealQuantity).ToString();
                ItemCount.Text = $"عدد المواد المطلوبة: \n\n {c}";
                dvItems2.Height = dvItems2.Rows[0].Height * (dvItems2.Rows.Count +1);
            }
            else
            {
                Price.Text = "0.0";
            }
        }

        private void T_Tick(object sender, EventArgs e)
        {
            var t = (Timer)sender;
            t.Stop();
            TimeUp?.Invoke(null, "Stop");

        }
        public static void CloseNow()
        {

            TimeUp?.Invoke(null, "Stop");

        }


        private void displayOffer_FormClosed(object sender, FormClosedEventArgs e)
        {
            Orders.POS.ListChanged -= POS_ListChanged;
            Orders.MenuShowing = false;
        }

        private void dvItems2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Payment_Click(object sender, EventArgs e)
        {

        }
    }



}
