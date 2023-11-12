using sharedCode;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.Json.Serialization;
using System.Windows.Forms;
using Windows.Foundation.Metadata;

namespace OrderForm
{
    public partial class displayOffer : Form
    {

        public static event EventHandler<string> TimeUp;

        public displayOffer()
        {
            if (!Application.OpenForms.OfType<ReadyOrders>().Any())
            {
                InitializeComponent();
                TimeUp += DisplayOffer_TimeUp;
                LogoPic.BackgroundImage = Bitmap.FromFile(Properties.Settings.Default.Logo);
            }
            else this.Hide();
        }




        public static void showme(string _ClientName, string _ClientPhone, string _ClientDate)
        {
            if (_ClientDate == null) _ClientDate = "";
            if (_ClientName == null) _ClientName = "";
            if (_ClientPhone == null) _ClientPhone = "";


            Orders.MenuShowing = true;
            var Show = new displayOffer();
            Show.timer1.Start();
            Show.timer1.Tick += Show.T_Tick;
            Show.Show();

            Show.ClientDate.Visible = _ClientDate.Length > 0;
            Show.DateTitle.Visible = Show.ClientDate.Visible;
            Show.ClientDate.Text = _ClientDate;

            Show.ClientDate.ForeColor =  Color.Black; 
            Show.ClientName.Visible = _ClientName.Length > 0;
            Show.ClientTitle.Visible = Show.ClientName.Visible;
            Show.ClientName.Text = _ClientName;

            Show.ClientPhone.Visible = _ClientPhone.Length > 0;
            Show.PhoneTitle.Visible = Show.ClientPhone.Visible;
            if(_ClientPhone.Length>0)Show.ClientPhone.Text = "05XXXX" + _ClientPhone.Substring(6); 
            Show.Update();
            Show.POS_ListChanged(null, null);
            Show.dvItems2.DataSource = Orders.POS;
            Show.LoadUI();
            if (Show.dvItems2.Rows.Count >= 1)
            {
                Show.dvItems2.Height = Show.dvItems2.Rows[0].Height * (Show.dvItems2.Rows.Count + 1);
            }

        }
        public static void showme(string _ClientName, string _ClientPhone, string _ClientDate, Invoice inv)
        {
            if (_ClientDate == null) _ClientDate = "";
            if (_ClientName == null) _ClientName = "";
            if (_ClientPhone == null) _ClientPhone = "";
            

            Orders.MenuShowing = true;
            var Show = new displayOffer();
            Show.timer1.Start();
            Show.timer1.Tick += Show.T_Tick;
          
            
            Show.ClientDate.Visible = _ClientDate.Length > 0;
            Show.DateTitle.Visible = Show.ClientDate.Visible;
            Show.ClientDate.Text = _ClientDate;

            Show.ClientDate.ForeColor = Color.Black;
            Show.ClientName.Visible = _ClientName.Length > 0;
            Show.ClientTitle.Visible = Show.ClientName.Visible;
            Show.ClientName.Text = _ClientName;

            Show.ClientPhone.Visible = _ClientPhone.Length > 0;
            Show.PhoneTitle.Visible = Show.ClientPhone.Visible;
            if (_ClientPhone.Length > 0) Show.ClientPhone.Text = "05XXXX" + _ClientPhone.Substring(6);
            Show.dvItems2.DataSource = inv.InvoiceItems;

            Show.Price.Text = inv.InvoicePrice.ToString();

            var c = inv.InvoiceItems.Sum<POSItems>((x) => x.RealQuantity).ToString();
            Show.ItemCount.Text = $"عدد المواد المطلوبة: \n\n {c}";

            Show.Show();
            Show.dvItems2.DataSource = inv.InvoiceItems;
            Show.LoadUI();
            if (Show.dvItems2.Rows.Count >= 1)
            {
                Show.dvItems2.Height = Show.dvItems2.Rows[0].Height * (Show.dvItems2.Rows.Count + 1);
            }


        }


        private void DisplayOffer_TimeUp(object sender, string e)
        {
            if (e == "Stop")
            {
                Orders.POS.ListChanged -= POS_ListChanged;
                Orders.MenuShowing = false;
                timer1.Stop();
                Close();

            }


        }

        void LoadUI()
        {
            List<string> ColumnsList = new List<string>();
            // create a foreach loop to loop through columns and delete some of them that don't meet a certain condition
            foreach (DataGridViewColumn x in dvItems2.Columns)
            {
                if (x.DataPropertyName == "Name" || x.DataPropertyName == "Quantity" || x.DataPropertyName == "Price" || x.DataPropertyName == "TotalPrice" || x.DataPropertyName == "Comment" || x.Name == "btnColumn")
                {
                    continue;
                }
                ColumnsList.Add(x.Name);
            }

            ColumnsList.ForEach(x => dvItems2.Columns.Remove(x));


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
            dvItems2.Columns["Name"].Width = 300;// Name
            dvItems2.Columns["Name"].HeaderText = "إسم المادة";
            dvItems2.Columns["Name"].DefaultCellStyle = cellstyleMaterial;

            dvItems2.Columns["Quantity"].Width = 100;// Quantity
            dvItems2.Columns["Quantity"].HeaderText = "العدد";
            dvItems2.Columns["Quantity"].DefaultCellStyle = cellstyleMaterial;

            var cellstyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.Black,
                SelectionBackColor = Color.White,
                SelectionForeColor = Color.Black,
                Font = new System.Drawing.Font("Segoe UI", 8, System.Drawing.FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };

            dvItems2.Columns["Price"].Width = 200;// Price
            dvItems2.Columns["Price"].HeaderText = " سعر المادة";
            dvItems2.Columns["Price"].DefaultCellStyle = cellstyle;

            dvItems2.Columns["TotalPrice"].Width = 100;// TotalPrice
            dvItems2.Columns["TotalPrice"].HeaderText = "إجمالي";
            dvItems2.Columns["TotalPrice"].DefaultCellStyle = cellstyle;

            dvItems2.Columns["comment"].Width = 150;// Comment
            dvItems2.Columns["comment"].HeaderText = "ملاحظات";
            dvItems2.Columns["comment"].DefaultCellStyle = cellstyle;
            //dvItems2.Refresh();
            //dvItems2.Update();

            dvItems2.Columns["comment"].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;

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
            // check if this file exists C:\db\images\promotion.jpg
            // if it does then show it in the picture box
            // if it doesn't then hide the picture box
            if (System.IO.File.Exists(Properties.Settings.Default.PromotionLink))
            {
                PromotionPic.BackgroundImage = Bitmap.FromFile(Properties.Settings.Default.PromotionLink);
                
            }
            else
            {
                PromotionPic.Visible = false;
            }


        }

        private void POS_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            if (Orders.POS.Count > 0)
            {
                decimal total = Orders.POS.Sum<POSItems>((a) => a.TotalPrice);
                Price.Text = total.ToString();

                var c = Orders.POS.Sum<POSItems>((x) => x.RealQuantity).ToString();
                ItemCount.Text = $"عدد المواد المطلوبة: \n\n {c}";
                if (dvItems2.Rows.Count >= 1)
                {
                    dvItems2.Height = dvItems2.Rows[0].Height * (dvItems2.Rows.Count + 1);
                }
            }
            else
            {
                Price.Text = "0.0";
            }

            if (dvItems2.Rows.Count >= 1)
            {
                dvItems2.Height = dvItems2.Rows[0].Height * (dvItems2.Rows.Count + 1);
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


    }



}
