using OrderForm.Custom_UI_Elements;
using PrayerTimes;
using sharedCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Color = System.Drawing.Color;

namespace OrderForm
{


    public partial class Orders : Form
    {

        private string MyDirectory()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }
        public event EventHandler<string> ItemsAddedToInvoice;

        public bool DgvMouseDown = false;
        public BindingList<POSItems> POS = new BindingList<POSItems>();
        public event EventHandler<string> UpdatedDraft;
        public List<string> MinutesList = new List<string>() { "00", "05", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55" };
        public List<string> HoursList = new List<string>() { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" };
        public List<string> TODList = new List<string>() { "صباحا", "ظهرا", "عصرا", "مساء", "ليلا" };
        public static bool IsItPrinted = false;
        public bool IsItPrintedNow = false;
        public bool AddingInProgress = false;

        public static Invoice globalInvoice = null;
        public int radioChecked = 0;
        #region Form and Loading Region
        public Orders()
        {

            InitializeComponent();
            LoadMethods();
        }

        private void LoadMethods()
        {

            if (Properties.Settings.Default.showMenu)
            {
                if (Screen.AllScreens.Count() > 1)
                {

                    if (DM.Visibility != System.Windows.Visibility.Visible)
                    {
                        DM.Show();

                        _ = DM.LaunchMenu(MenuDB.GetMenuItems(MenuDB.GetMenus().First()), MenuDB.GetMenus().First());
                    }
                }
            }
            LoadMaterials();
            this.ItemsAddedToInvoice += ItemsAddedToInvoice_raised;
            POS.ListChanged += POS_ListChanged;
            UIVisuals();
            ShowSalahTimes();
            AmountLBL.TextChanged += AmountLBL_TextChanged1;
            this.UpdatedDraft += UpdateDraft;
        }
        int c = 0;
        private void AmountLBL_TextChanged1(object sender, EventArgs e)
        {
            if (!AddingInProgress)
            {
                c = 0;
                POS.ToList().ForEach((x) => { c += x.RealQuantity; });
                ItemCount.Text = c.ToString();
            }

        }

        private void UpdateDraft(object sender, string e)
        {


            DbInv.CreateDraftInvoice(CreateDraftObject());

        }

        Invoice CreateDraftObject()
        {
            Invoice draftInvoice = new Invoice()
            {
                ID = Convert.ToInt32(InvoiceNumberID.Text),
                CustomerNumber = MobileTB.Text,
                CustomerName = NameTB.Text,
                Comment = CommentTB.Text,
                InvoiceDay = (InvDay)GetDayOfWeek(),
                TimeAMPM = TimeTB.Text,
                OrderType = OrderStatus.Text,
                TimeinArabic = TimeInfo.Text,
                InvoicePrice = Convert.ToDecimal(AmountLBL.Text),
                InEditMode = false
            };

            draftInvoice.InvoiceItems.Clear();
            POS.ToList().ForEach(x => draftInvoice.InvoiceItems.Add(x));
            return draftInvoice;
        }

        public static string GetDayName(int dayInt)
        {
            var culture = new System.Globalization.CultureInfo("ar-SA");
            if (dayInt == 6) return culture.DateTimeFormat.GetDayName(DayOfWeek.Saturday);
            else if (dayInt == 0) return culture.DateTimeFormat.GetDayName(DayOfWeek.Sunday);
            else if (dayInt == 1) return culture.DateTimeFormat.GetDayName(DayOfWeek.Monday);
            else if (dayInt == 2) return culture.DateTimeFormat.GetDayName(DayOfWeek.Tuesday);
            else if (dayInt == 3) return culture.DateTimeFormat.GetDayName(DayOfWeek.Wednesday);
            else if (dayInt == 4) return culture.DateTimeFormat.GetDayName(DayOfWeek.Thursday);
            else return culture.DateTimeFormat.GetDayName(DayOfWeek.Friday);

        }
        public int GetDayOfWeek()
        {

            if (DayMenuBTN.Text == "اليوم")
            {
                var days = DateTime.Now.DayOfWeek;
                if (days == DayOfWeek.Saturday) return Convert.ToInt32(DayOfWeek.Saturday);
                else if (days == DayOfWeek.Sunday) return Convert.ToInt32(DayOfWeek.Sunday);
                else if (days == DayOfWeek.Monday) return Convert.ToInt32(DayOfWeek.Monday);
                else if (days == DayOfWeek.Tuesday) return Convert.ToInt32(DayOfWeek.Tuesday);
                else if (days == DayOfWeek.Wednesday) return Convert.ToInt32(DayOfWeek.Wednesday);
                else if (days == DayOfWeek.Thursday) return Convert.ToInt32(DayOfWeek.Thursday);
                else return Convert.ToInt32(DayOfWeek.Friday);
            }
            else
            {
                if (DayMenuBTN.Text == "السبت") return (int)DayOfWeek.Saturday;
                else if (DayMenuBTN.Text == "الأحد") return (int)DayOfWeek.Sunday;
                else if (DayMenuBTN.Text == "الإثنين") return (int)DayOfWeek.Monday;
                else if (DayMenuBTN.Text == "الثلاثاء") return (int)DayOfWeek.Tuesday;
                else if (DayMenuBTN.Text == "الأربعاء") return (int)DayOfWeek.Wednesday;
                else if (DayMenuBTN.Text == "الخميس") return (int)DayOfWeek.Thursday;
                else return (int)DayOfWeek.Friday;


            }
        }
        private void POS_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (!AddingInProgress)
            {
                var s = POS.Sum(a => a.TotalPrice);
                AmountLBL.Text = s.ToString();
                //UpdatedDraft?.Invoke(this, null);

            }
        }

        private void Orders_FormClosed(object sender, FormClosedEventArgs e)
        {
            dvItems.MouseWheel -= new MouseEventHandler(DataGridView1_MouseWheel);
            this.UpdatedDraft -= this.UpdateDraft;

        }
        #endregion
        #region Invoice related logic
        private void ItemsAddedToInvoice_raised(object sender, string e)
        {
            //decimal total = dvItems.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToDecimal(t.Cells[3].Value));
            if (!AddingInProgress)
            {
                dvItems.DataSource = POS;
                decimal total = POS.Sum((a) => a.TotalPrice);
                dvItems.Update();
                dvItems.Refresh();
                AmountLBL.Text = total.ToString();
            }
        }
        #endregion


        #region Customer Data Logic to be implemented later
        Control ctrl;
        private void MobileTB_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            ctrl = (Control)sender;
            if (ctrl is TextBox)
            {
                if (e.KeyCode == Keys.Down)
                {
                    this.SelectNextControl(ctrl, true, true, true, true);
                }
                else if (e.KeyCode == Keys.Up) this.SelectNextControl(ctrl, false, true, true, true);

                else if (e.KeyCode == Keys.Enter)
                {
                    this.SelectNextControl(ctrl, true, true, true, true);
                    if (Control.ModifierKeys == Keys.Control)
                    {
                        var es = new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0);
                        WhatsAppBTN_Click(this, es);
                        // Check for Name Later implementation
                    }
                }
            }
        }



        private void MobileTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        #endregion

        #region WhatsAppRelatedLogic
        private void WhatsAppBTN_Click(object sender, EventArgs e)
        {
            if (MobileTB.Text != "")
            {
                var num = this.MobileTB.Text;
                //var numbersyntax = "(05)([0-9]{8})|5([0-9]{8})";
                var numbersyntax = @"(05)([0-9]{8})|5([0-9]{8})|\+([0-9]{12})|00([0-9]{12})|\+([0-9]{11})|00([0-9]{11})";
                Regex rgx = new Regex(numbersyntax);
                Match numbermatch = rgx.Match(num);
                this.MobileTB.Text = numbermatch.Value.ToString();
                if (this.MobileTB.Text.StartsWith("00") == true | this.MobileTB.Text.StartsWith("+") == true) Process.Start("whatsapp://send/?phone=" + this.MobileTB.Text);
                else
                {
                    Process.Start("whatsapp://send/?phone=" + "966" + this.MobileTB.Text + "&text=" + "/");
                }

            }
        }
        #endregion
        #region SalahRelatedCode
        private void ShowSalahTimes()
        {
            PrayerTimesCalculator calc = new PrayerTimesCalculator(24.715468, 46.696223)
            {
                CalculationMethod = CalculationMethods.Makkah,
                AsrJurusticMethod = AsrJuristicMethods.Shafii
            };
            var times = calc.GetPrayerTimes(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), 4);
            //var ts = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            DhuhrBTN.Text = DateTime.Parse(times.Dhuhr.ToString()).ToString("hh:mm tt");
            AsrBTN.Text = DateTime.Parse(times.Asr.ToString()).ToString("hh:mm tt");
            MaghribBTN.Text = DateTime.Parse(times.Maghrib.ToString()).ToString("hh:mm tt");
            IshaBTN.Text = DateTime.Parse(times.Isha.ToString()).ToString("hh:mm tt");
            //CultureInfo Culture = new CultureInfo("ar-SA");
            DayLBL.Text = Orders.GetDayName((int)DateTime.Now.DayOfWeek);
            DateLBL.Text = DateTime.Now.ToString("dd/MM/yyyy");
            //TimeTB.Text = times.Sunrise.Subtract(ts).ToString();
            SalahTMR.Start();
            /// ChangeBackground("bm");
        }
        private bool after = false;
        public NextPrayer.state state = NextPrayer.state.stateless;
        private void SalahTMR_Tick(object sender, EventArgs e)
        {
            var now = DateTime.Now.ToString("hh:mm tt");
            TimeButton.Text = now;



            TimeTillCountdown.Text = NextPrayer.UpdateCounter();
            switch (NextPrayer.UpdateCounter(true))
            {
                case NextPrayer.state.DhuhrPeriod:
                    if (!TimeTillCountdown.Visible && !TimeLeftLBL.Visible)
                    {
                        TimeTillCountdown.Visible = true;
                        TimeLeftLBL.Visible = true;
                    }
                    if (state != NextPrayer.state.DhuhrPeriod)
                    {
                        DhuhrLBL.BackColor = Color.LightGreen;
                        TimeTillCountdown.BackColor = Color.LightGreen;
                        TimeTillCountdown.BringToFront();
                        TimeLeftLBL.BringToFront();
                        DhuhrBTN.BringToFront();
                        DhuhrLBL.BringToFront();
                        ChangeBackground(DhuhrLBL.Name);
                    }
                    state = NextPrayer.state.DhuhrPeriod;
                    after = false;

                    break;
                case NextPrayer.state.DhuhrSalahPeriod:
                    if (!TimeTillCountdown.Visible && !TimeLeftLBL.Visible)
                    {
                        TimeTillCountdown.Visible = true;
                        TimeLeftLBL.Visible = true;
                    }
                    if (state != NextPrayer.state.DhuhrSalahPeriod)
                    {
                        DhuhrBTN.BackColor = Color.LightPink;
                        TimeTillCountdown.BackColor = Color.LightPink;
                        TimeTillCountdown.BringToFront();
                        TimeLeftLBL.BringToFront();
                        DhuhrBTN.BringToFront();
                        DhuhrLBL.BringToFront();

                        ChangeBackground(DhuhrBTN.Name);
                    }
                    state = NextPrayer.state.DhuhrSalahPeriod;
                    after = false;
                    break;
                case NextPrayer.state.AsrPeriod:
                    if (!TimeTillCountdown.Visible && !TimeLeftLBL.Visible)
                    {
                        TimeTillCountdown.Visible = true;
                        TimeLeftLBL.Visible = true;
                    }
                    if (state != NextPrayer.state.AsrPeriod)
                    {
                        AsrLBL.BackColor = Color.LightGreen;
                        TimeTillCountdown.BackColor = Color.LightGreen;
                        TimeTillCountdown.BringToFront();
                        TimeLeftLBL.BringToFront();
                        AsrBTN.BringToFront();
                        AsrLBL.BringToFront();
                        ChangeBackground(AsrLBL.Name);
                    }
                    state = NextPrayer.state.AsrPeriod;
                    after = false;
                    break;
                case NextPrayer.state.AsrSalahPeriod:
                    if (!TimeTillCountdown.Visible && !TimeLeftLBL.Visible)
                    {
                        TimeTillCountdown.Visible = true;
                        TimeLeftLBL.Visible = true;
                    }
                    if (state != NextPrayer.state.AsrSalahPeriod)
                    {
                        AsrBTN.BackColor = Color.LightPink;
                        TimeTillCountdown.BackColor = Color.LightPink;
                        TimeTillCountdown.BringToFront();
                        TimeLeftLBL.BringToFront();

                        AsrBTN.BringToFront();
                        AsrLBL.BringToFront();
                        ChangeBackground(AsrBTN.Name);
                    }
                    state = NextPrayer.state.AsrSalahPeriod;
                    after = false;
                    break;
                case NextPrayer.state.MagribPeriod:
                    if (!TimeTillCountdown.Visible && !TimeLeftLBL.Visible)
                    {
                        TimeTillCountdown.Visible = true;
                        TimeLeftLBL.Visible = true;
                    }
                    if (state != NextPrayer.state.MagribPeriod)
                    {
                        MaghribLBL.BackColor = Color.LightGreen;
                        TimeTillCountdown.BackColor = Color.LightGreen;
                        TimeTillCountdown.BringToFront();
                        TimeLeftLBL.BringToFront();
                        MaghribBTN.BringToFront();
                        MaghribLBL.BringToFront();
                        ChangeBackground(MaghribLBL.Name);
                    }
                    state = NextPrayer.state.MagribPeriod;
                    after = false;
                    break;
                case NextPrayer.state.MagribSalahPeriod:
                    if (!TimeTillCountdown.Visible && !TimeLeftLBL.Visible)
                    {
                        TimeTillCountdown.Visible = true;
                        TimeLeftLBL.Visible = true;
                    }
                    if (state != NextPrayer.state.MagribSalahPeriod)
                    {
                        MaghribBTN.BackColor = Color.LightPink;
                        TimeTillCountdown.BackColor = Color.LightPink;
                        TimeTillCountdown.BringToFront();
                        TimeLeftLBL.BringToFront();
                        MaghribBTN.BringToFront();
                        MaghribLBL.BringToFront();
                        ChangeBackground(MaghribBTN.Name);
                    }
                    state = NextPrayer.state.MagribSalahPeriod;
                    after = false;
                    break;
                case NextPrayer.state.IshaPeriod:
                    if (!TimeTillCountdown.Visible && !TimeLeftLBL.Visible)
                    {
                        TimeTillCountdown.Visible = true;
                        TimeLeftLBL.Visible = true;
                    }
                    if (state != NextPrayer.state.IshaPeriod)
                    {
                        IshaLBL.BackColor = Color.LightGreen;
                        TimeTillCountdown.BackColor = Color.LightGreen;
                        ChangeBackground(IshaLBL.Name);
                        TimeTillCountdown.BringToFront();
                        TimeLeftLBL.BringToFront();
                        IshaBTN.BringToFront();
                        IshaLBL.BringToFront();
                    }
                    state = NextPrayer.state.IshaPeriod;
                    after = false;
                    break;
                case NextPrayer.state.IshaSalahPeriod:
                    if (!TimeTillCountdown.Visible && !TimeLeftLBL.Visible)
                    {
                        TimeTillCountdown.Visible = true;
                        TimeLeftLBL.Visible = true;
                    }
                    if (state != NextPrayer.state.IshaSalahPeriod)
                    {

                        IshaBTN.BackColor = Color.LightPink;
                        TimeTillCountdown.BackColor = Color.LightPink;
                        TimeTillCountdown.BringToFront();
                        TimeLeftLBL.BringToFront();
                        IshaBTN.BringToFront();
                        IshaLBL.BringToFront();
                        ChangeBackground(IshaBTN.Name);
                    }
                    state = NextPrayer.state.IshaSalahPeriod;

                    after = false;
                    break;
                case NextPrayer.state.AfterIsha:

                    if (!after)
                    {
                        TimeTillCountdown.Visible = false;
                        TimeLeftLBL.Visible = false;

                        IshaBTN.BringToFront();
                        IshaLBL.BringToFront();
                        MaghribBTN.BringToFront();
                        MaghribLBL.BringToFront();
                        AsrBTN.BringToFront();
                        AsrLBL.BringToFront();
                        DhuhrBTN.BringToFront();
                        DhuhrLBL.BringToFront();

                        ChangeBackground("");
                    }
                    after = true;
                    break;
                case NextPrayer.state.After12am:
                    if (!after)
                    {
                        TimeTillCountdown.Visible = false;
                        TimeLeftLBL.Visible = false;
                        IshaBTN.BringToFront();
                        IshaLBL.BringToFront();
                        MaghribBTN.BringToFront();
                        MaghribLBL.BringToFront();
                        AsrBTN.BringToFront();
                        AsrLBL.BringToFront();
                        DhuhrBTN.BringToFront();
                        DhuhrLBL.BringToFront();

                        ChangeBackground("");
                        DateLBL.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        DayLBL.Text = DayLBL.Text = Orders.GetDayName((int)DateTime.Now.DayOfWeek);
                    }
                    after = true;

                    break;

            }
        }
        private void ChangeBackground(string btn)
        {

            foreach (Control button in SalahTimes.Controls)
            {

                if (button.Name.EndsWith("LBL") == true)
                {
                    if (button.Name != btn)
                        button.BackColor = Color.White;

                }
                else if (button.Name.EndsWith("BTN") == true)
                {
                    if (button.Name != btn)
                        button.BackColor = Color.White;
                }

            }
        }

        #endregion

        #region DataGridView Related Logic
        public void UIVisuals()
        {
            OrderStatus.Text = InvoiceTypeOptions.Items[Properties.Settings.Default.defaultOrder].Text; ;
            dvItems.DataSource = POS;
            dvItems.Columns[0].Width = 120;// Name
            dvItems.Columns[0].HeaderText = "إسم المادة";
            dvItems.Columns[0].ReadOnly = true;

            dvItems.Columns[1].Width = 45;// Quantity
            dvItems.Columns[1].HeaderText = "العدد";
            //dvItems.Columns[2].ReadOnly = true;


            dvItems.Columns[2].Width = 45;// Price
            dvItems.Columns[2].HeaderText = "سعر";
            dvItems.Columns[2].ReadOnly = true;



            dvItems.Columns[3].Width = 55;// TotalPrice
            dvItems.Columns[3].HeaderText = "إجمالي";
            dvItems.Columns[3].ReadOnly = true;

            dvItems.Columns[4].Width = 170;// Comment
            dvItems.Columns[4].HeaderText = "ملاحظات";
            dvItems.Columns[4].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;

            dvItems.MouseWheel += new MouseEventHandler(DataGridView1_MouseWheel);

            dvItems.Refresh();
            dvItems.Update();
        }

        private void DvItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var dv = sender as DataGridView;


            try
            {

                if (dvItems.Rows.Count > 0)
                {
                    if (dv.CurrentCell.ColumnIndex == 1)
                    {
                        POSItems currentItem = (POSItems)dvItems.CurrentRow.DataBoundItem;
                        ItemsAddedToInvoice?.Invoke(this, currentItem.Name);
                        if (currentItem.Quantity == 0)
                        {
                            var MsgBox = new SureMsg();
                            if (MsgBox.ShowDialog(this) == DialogResult.OK)
                            {
                                POS.Remove(currentItem);
                            }
                            else
                            {
                                if (currentItem.Quantity == 0) currentItem.Quantity = 1;
                                dvItems.Update();
                                dvItems.Refresh();
                            }

                        }

                    }

                }

            }
            catch (Exception)
            {


            }
            //UpdatedDraft?.Invoke(this, null);
        }
        private void DataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (dvItems.CurrentCell.ColumnIndex == 1) //Desired Column
            {
                TextBox tb = (TextBox)e.Control;
                if (tb != null)
                {

                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }
        #region DataGridView MouseRelatedLogic
        void DataGridView1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (dvItems.Rows.Count > 0)
            {
                dvItems.Focus();

                if (e.Delta > 0)
                {

                    if (DgvMouseDown == true)
                    { SendKeys.Send("{Up}"); }
                    else
                    {
                        if (!StopEditing)
                        {
                            foreach (DataGridViewRow row in dvItems.Rows)
                            {
                                if (row.Selected == true)
                                {
                                    dvItems.CurrentCell = dvItems.Rows[row.Index].Cells[1];
                                }
                            }
                            var dv = sender as DataGridView;
                            POSItems currentItem = (POSItems)dvItems.CurrentRow.DataBoundItem;
                            currentItem.Quantity++;
                            ItemsAddedToInvoice?.Invoke(this, currentItem.Name);
                            if (currentItem.Quantity == 0) currentItem.Quantity = 1;
                        }
                    }

                }

                else if (e.Delta < 0)
                {
                    if (DgvMouseDown == true)
                    {
                        SendKeys.Send("{Down}");
                    }
                    else
                    {
                        try
                        {
                            if (!StopEditing)
                            {
                                foreach (DataGridViewRow row in dvItems.Rows)
                                {
                                    if (row.Selected == true)
                                    {
                                        dvItems.CurrentCell = dvItems.Rows[row.Index].Cells[1];
                                    }
                                }
                                POSItems currentItem = (POSItems)dvItems.CurrentRow.DataBoundItem;
                                if (currentItem.Quantity > 1) currentItem.Quantity--;
                                ItemsAddedToInvoice?.Invoke(this, currentItem.Name);

                            }
                        }
                        catch (Exception)
                        {

                        }
                    }
                }

            }
        }

        private void DvItems_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 2 && e.Button == MouseButtons.Right)
            {
                int rowIndex = dvItems.HitTest(e.X, e.Y).RowIndex;

                if (dvItems.RowCount > 0 && dvItems.SelectedRows.Count != -1 && rowIndex != -1)
                {
                    var row = dvItems.Rows[rowIndex];
                    row.Selected = true;
                    POSItems item = (POSItems)row.DataBoundItem;
                    rightClickMenu.Items[2].Visible = false;
                    rightClickMenu.Show(Cursor.Position);
                    rightClickMenu.Items[3].Text = item.Name;
                    rightClickMenu.Tag = item;
                    row.Selected = true;

                }

            }
            else DgvMouseDown = true;
        }


        private void DvItems_MouseUp(object sender, MouseEventArgs e)
        {
            DgvMouseDown = false;

        }

        private void DvItems_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            CultureInfo ar = new CultureInfo("ar-sa");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(ar);


        }

        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                var tb = (TextBox)sender;
                if (tb.Text == "")
                {
                    tb.Text = "1";
                    e.Handled = true;
                }
                else e.Handled = true;
            }
        }

        #endregion
        private void DvItems_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
            SendKeys.Send("0");

        }
        private void DvItems_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            POSItems E = (POSItems)e.Row.DataBoundItem;
            E.Comment = "";
        }
        #endregion

        #region Touch Keyboard logic
        private void NumberBTN_Click(object sender, EventArgs e)
        {
            var BTN = (Button)sender;
            if (BTN != null)
            {
                if (dvItems.Rows.Count > 0)
                {
                    var cell = dvItems.CurrentCell;
                    bool inedit = cell.IsInEditMode;


                    if (inedit == false)
                        dvItems.Focus();
                    try
                    {
                        foreach (DataGridViewRow row in dvItems.Rows)
                        {
                            if (row.Selected == true)
                            {
                                dvItems.CurrentCell = dvItems.Rows[row.Index].Cells[1];
                            }
                        }

                        string switchcase = BTN.Name;

                        switch (switchcase)
                        {

                            case "OneBTN":
                                SendKeys.Send("1");
                                break;
                            case "TwoBTN":
                                SendKeys.Send("2");
                                break;
                            case "ThreeBTN":
                                SendKeys.Send("3");
                                break;
                            case "FourBTN":
                                SendKeys.Send("4");
                                break;
                            case "FiveBTN":
                                SendKeys.Send("5");
                                break;
                            case "SixBTN":
                                SendKeys.Send("6");
                                break;
                            case "SevenBTN":
                                SendKeys.Send("7");
                                break;
                            case "EightBTN":
                                SendKeys.Send("8");
                                break;
                            case "NineBTN":
                                SendKeys.Send("9");
                                break;
                            case "ZeroBTN":
                                SendKeys.Send("0");
                                break;
                            case "EnterBTN":
                                SendKeys.Send("{Enter}");
                                break;
                            case "BackSpaceBTN":
                                SendKeys.Send("{BACKSPACE}");
                                break;
                            default:
                                break;
                        }
                    }
                    catch (Exception)
                    {

                    }


                    //dvItems.CurrentCell.Value += "1";



                }
            }
        }
        private void PlusBTN_Click(object sender, EventArgs e)
        {

            DataGridView1_MouseWheel(this, new MouseEventArgs(MouseButtons.None, 0, 0, 0, 120));
        }
        private void PlusBTN_MouseUp(object sender, MouseEventArgs e)
        {
            if (dvItems.Focused == true)
            {
                if (e.Button == MouseButtons.Right) SendKeys.Send("{Up}");
            }
            else { dvItems.Focus(); if (e.Button == MouseButtons.Right) SendKeys.Send("{Up}"); }
        }
        private void DownBTN_MouseUp(object sender, MouseEventArgs e)
        {
            if (dvItems.Focused == true)
            {
                if (e.Button == MouseButtons.Right) SendKeys.Send("{Down}");
            }
            else { dvItems.Focus(); if (e.Button == MouseButtons.Right) SendKeys.Send("{Down}"); }
        }
        private void DownBTN_Click(object sender, EventArgs e)
        {
            var es = new MouseEventArgs(MouseButtons.None, 0, 0, 0, -120);

            DataGridView1_MouseWheel(this, es);

        }
        private void DeleteTouchBTN_Click(object sender, EventArgs e)
        {


            if (dvItems.Rows.Count > 0)
            {
                dvItems.Focus();
                SendKeys.Send("{Delete}");

            }

        }
        #endregion

        #region RightClickMenu logic
        private void CustomComment_Click(object sender, EventArgs e)
        {

            if (dvItems.Rows.Count > 0)
            {
                dvItems.Focus();
                dvItems.SelectedRows[0].Cells[4].Selected = true;
                dvItems.SelectedRows[0].Cells[4].Value = "";
            }

        }

        private void DeleteBTN_Click(object sender, EventArgs e)
        {
            var s = (ToolStripMenuItem)sender;
            var item = (POSItems)s.GetCurrentParent().Tag;
            item.Comment = "";
            POS.Remove(item);
        }
        #endregion

        #region SettingsRelated
        private void Settings_Click(object sender, EventArgs e)
        {
            var setting = new SettingsPage();
            setting.Show();
        }
        private void SettingsPage_Click(object sender, EventArgs e)
        {
            Form SettingsForm = new SettingsPage();
            SettingsForm.ShowDialog();
            LoadMaterials();
        }
        #endregion

        #region Printing Invoices
        public static BindingList<POSItems> PrintingList = new BindingList<POSItems>();
        public static BindingList<POSItems> CurrentList = new BindingList<POSItems>();
        public static string CurrentDep;


        public static int InvID;

        public Invoice PrintNewInvoice()
        {
            Invoice inv = new Invoice()
            {
                CustomerName = NameTB.Text,
                Comment = CommentTB.Text,
                CustomerNumber = MobileTB.Text,
                ID = Convert.ToInt32(InvoiceNumberID.Text),
                InvoiceItems = POS.ToList(),
                InvoicePrice = Convert.ToDecimal(AmountLBL.Text),
                OrderType = OrderStatus.Text,
                Status = InvStat.Printed,
                InvoiceDay = (InvDay)GetDayOfWeek(),
                TimeAMPM = TimeTB.Text,
                TimeinArabic = TimeInfo.Text,
            };
            return inv;
        }
        public void PrintingLogic()
        {
            CurrentList.Clear();

            foreach (POSItems i in POS) //default printing.
            {
                CurrentList.Add(i);
            }
            CurrentDep = "ورقة التحضير";
            PrintInvoice.Print(dbQ.DefaultPrinters());
            var deps = dbQ.LoadDepartments();
            for (int I = 0; I < deps.Count; I++)
            {
                foreach (POSItems i in POS)
                {
                    if (i.printerlist.Contains(deps[I].DefaultPrinter))
                    {
                        PrintingList.Add(i);
                        //MessageBox.Show(i.Name + " " + i.PrinterName);
                    }
                }
                if (PrintingList.Count > 0)
                {
                    CurrentList.Clear();
                    foreach (var item in PrintingList)
                    {
                        CurrentList.Add(item);
                    }
                    CurrentDep = deps[I].Name;
                    PrintInvoice.Print(deps[I].DefaultPrinter);
                    //;

                }

            }
        }

        private void PrintSave_Click(object sender, EventArgs e)
        {
            //TimeTB_Leave(sender, e);  

            InvoiceTypeOptions.Hide();
            InvoiceTypeOptions.SendToBack();
            Custom_Classes.CreateOffer.CreateOfferNow(PrintNewInvoice());
            if (POS.Count > 0)
            {

                globalInvoice = null;
                globalInvoice = PrintNewInvoice();
                InvID = Convert.ToInt32(InvoiceNumberID.Text);
                //var orderinfo = Orders.globalInvoice;
                if (!globalInvoice.Equal(DbInv.GetInvoiceByID(InvID)))
                {
                    PrintingLogic();


                    //MessageBox.Show(getPrinterName());
                    Contacts customer = new Contacts(NameTB.Text, MobileTB.Text, CommentTB.Text);
                    customer.ID = dbQ.SaveContacts(null) + 1;
                    dbQ.SaveContacts(customer);
                    Invoice PNI = PrintNewInvoice();
                    PNI.TimeOfPrinting = DateTime.Now.ToString();
                    DbInv.CreatePreparingInvoice(PNI);
                    DbInv.LogAction("Invoice Printed", PNI.ID, PNI.Status);

                    // DbInv.DeleteDraftInvoice(PNI);
                    NewBTN_Click(null, null);
                    //dbQ.PrepareNewInvoice();
                    IsItPrinted = false;

                }

            }

        }

        #endregion

        public void Repeater(Button btn, int interval)
        {
            var timer = new System.Windows.Forms.Timer { Interval = interval };
            timer.Tick += (sender, e) => DataGridView1_MouseWheel(this, new MouseEventArgs(MouseButtons.None, 0, 0, 0, 10));
            btn.MouseDown += (sender, e) => timer.Start();
            btn.MouseUp += (sender, e) => timer.Stop();
            btn.Disposed += (sender, e) =>
            {
                timer.Stop();
                timer.Dispose();
            };
        }

        int InvoiceID;
        private void NewBTN_Click(object sender, EventArgs e)
        {
            ButtonStates(true);
            StopEditing = false;

            // DbInv.UpdateDraftInvoice(Convert.ToInt32(InvoiceNumberID.Text), false);

            //var drafts = DbInv.GetDraftInvoices();
            //var draft = drafts.FindAll(x => x.InvoiceItems.Count == 0 && !x.InEditMode);
            //if (draft.Count > 0)
            //{
            //    EmptyINV = draft.OrderBy(x => x.ID).First();
            //    if (EmptyINV != null)
            //    {
            //        InvoiceID = EmptyINV.ID;
            //    }
            //    else InvoiceID = DbInv.GetInvoicesCount();

            //}
            //else
            //{
            //}
            InvoiceID = DbInv.GetInvoicesCount();
            InvoiceNumberID.Text = InvoiceID.ToString();
            var draftInv = new Invoice();
            draftInv.ID = InvoiceID;
            draftInv.Status = InvStat.Draft;
            draftInv.InEditMode = true;
            draftInv.OrderType = InvoiceTypeOptions.Items[Properties.Settings.Default.defaultOrder].Text;
            draftInv.InvoiceDay = GetWhatDay((int)DateTime.Now.DayOfWeek);
            //DbInv.CreateDraftInvoice(draftInv);
            //DbInv.LogAction("Draft Invoice Created", d
            //raftInv.ID, draftInv.Status);
            DbInv.CreatePreparingInvoice(draftInv);
            OrdersPanel.Enabled = true;
            AddingInProgress = true;
            POS.Clear();
            AddingInProgress = false;
            NameTB.Text = "";
            MobileTB.Text = "";
            TimeTB.Text = "";
            DOWTB.Text = "";
            CommentTB.Text = "";
            TimeInfo.Text = "الآن";
            DayMenuBTN.Text = GetDayName((int)DateTime.Now.DayOfWeek);
            OrderStatus.Text = InvoiceTypeOptions.Items[Properties.Settings.Default.defaultOrder].Text;
            AmountLBL.Text = "0.00";
            button1.Enabled = true;
            IsItPrinted = false;

        }

        private void OrdersPage_Click(object sender, EventArgs e)
        {
            _ = LoadOrders();

        }

        private async Task LoadOrders()
        {
            InvoiceTypeOptions.Hide();
            this.panel1.Visible = true;
            this.HeldPanel.Controls.Clear();
            _ = AddDraftInvoicesAsync(); _ = CheckDay();
            LastOrder.Visible = false;
            await Task.CompletedTask;
        }

        private async Task CheckDay()
        {
            this.PrintedInvoices.Controls.Clear();

            var days = DateTime.Now.DayOfWeek;
            if (days == DayOfWeek.Saturday) { Sat.Checked = true; Fri_CheckedChanged(Sat, null); }
            else if (days == DayOfWeek.Sunday) { Sun.Checked = true; Fri_CheckedChanged(Sun, null); }
            else if (days == DayOfWeek.Monday) { Mon.Checked = true; Fri_CheckedChanged(Mon, null); }
            else if (days == DayOfWeek.Tuesday) { Tue.Checked = true; Fri_CheckedChanged(Tue, null); }
            else if (days == DayOfWeek.Wednesday) { Wed.Checked = true; Fri_CheckedChanged(Wed, null); }
            else if (days == DayOfWeek.Thursday) { Thu.Checked = true; Fri_CheckedChanged(Thu, null); }
            else if (days == DayOfWeek.Friday) { Fri.Checked = true; Fri_CheckedChanged(Fri, null); }
            await Task.CompletedTask;

        }
        private void Fri_CheckedChanged(object sender, EventArgs e)
        {
            var se = sender as RadioButton;
            //this.PrintedInvoices.Controls.Clear();

            _ = switchCase(se.Name);
        }

        private async Task switchCase(string se)
        {
            switch (se)
            {
                case "AllDays":
                    {

                        _ = RadioChecked(-1); break;
                    }
                case "Fri": { _ = RadioChecked(5); break; }
                case "Thu": { _ = RadioChecked(4); break; }
                case "Wed": { _ = RadioChecked(3); break; }
                case "Tue": { _ = RadioChecked(2); break; }
                case "Mon": { _ = RadioChecked(1); break; }
                case "Sun": { _ = RadioChecked(0); break; }
                case "Sat": { _ = RadioChecked(6); break; }
                case "History": { _ = RadioChecked(100); break; }
            }
            await Task.CompletedTask;
        }

        private void HeldOrder_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && GroupSave.Checked)
            {
                var se = (_InvBTN)sender;
                int id = (int)se.Tag;
                AddListToSave(id);
            }
            else if (e.Button == MouseButtons.Right && !GroupSave.Checked)
            {
                var a = new ContextMenuStrip() { Items = { "ملخص الفاتورة" } };
                var se = (_InvBTN)sender;
                int id = (int)se.Tag;
                var inv = DbInv.GetInvoiceByID(id);
                inv.InvoiceTimeloglist.ForEach(x => a.Items.Add(x));
                
                if (inv.POSInvoiceNumber != null) {
                    var btn = new ToolStripButton() { Text = "فتح الفاتورة في ليبرا" };
                    btn.Click += Btn_Click;
                    string posinv = inv.POSInvoiceNumber;
                    btn.Tag = posinv;
                    a.Items.Add(btn);
                }
                
                a.Show(se, new Point(0, 0));
            }
        }
        /// <summary>
        /// Btn_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Click(object sender, EventArgs e)
        {
           
            var se = (ToolStripButton)sender;
            string posid = (string)se.Tag;
            
           if (posid != null) {
                var a = new SavingandPayment.PaymentOptions(posid);
                            }

        }

        private bool AddListToSave(int id)
        {
            var a = PrintedInvoices.Controls.Find("MulipleSave", true);
            if (a.Length != 0)
            {
                if (a[0] != null)
                {
                    foreach (var control in PrintedInvoices.Controls)
                    {
                        if (control.GetType().ToString() == "OrderForm.Custom_UI_Elements.MulipleSave")
                        {
                            var MS = (MulipleSave)control;
                            if (MS.list.Where(x => x.ID == DbInv.GetInvoiceByID(id).ID).Count() != 1)
                                MS.list.Add(DbInv.GetInvoiceByID(id));

                        }
                    }

                }

            }
            else
            {
                var MS = new MulipleSave();
                MS.list.Add(DbInv.GetInvoiceByID(id));
                PrintedInvoices.Controls.Add(MS);
                MS.BringToFront();




            }
            return false;
        }
        private void HeldOrder_click(object sender, EventArgs e)
        {
            //string nl = Environment.NewLine;
            //string text = "قد تكون الفاتورة مفتوحة في جهاز آخر " + "لتجاهل التحذير إضغط على كونترول أثناء فتح الفاتورة";
            var se = sender as _InvBTN;
            int id = Convert.ToInt32(se.Tag);
            Invoice heldInv = DbInv.GetInvoiceByID(id);

            if (heldInv.Status != InvStat.Draft)
            {
                IsItPrinted = true;
                button1.Enabled = false;
                DbInv.LogAction("Printed Invoice Opened", heldInv.ID, heldInv.Status);
                LoadInvoiceUI(heldInv);
            }
            else
            {
                DbInv.UpdateDraftInvoice(Convert.ToInt32(InvoiceNumberID.Text), false);
                heldInv = DbInv.GetDraftInvoiceByID(id);
                IsItPrinted = false;
                button1.Enabled = true;
                DbInv.LogAction("Draft Invoice Opened", heldInv.ID, heldInv.Status);
                DbInv.UpdateDraftInvoice(heldInv.ID, true);
                heldInv = DbInv.GetDraftInvoiceByID(id);
                LoadInvoiceUI(heldInv);
                //}

                //else MessageBox.Show(text, "الفاتورة مفتوحة على جهاز آخر");

            }

            //timeinfo.Text =
            // DOW

        }

        public void LoadInvoiceUI(Invoice heldInv)
        {
            this.panel1.Visible = false;

            if (heldInv.Status == InvStat.Draft)
            {
                StopEditing = false;
                ButtonStates(true);
                OrdersPanel.Enabled = true;
                InvoiceNumberID.Text = heldInv.ID.ToString();
                MobileTB.Text = heldInv.CustomerNumber;
                NameTB.Text = heldInv.CustomerName + " ";
                TimeTB.Text = heldInv.TimeAMPM;
                DayMenuBTN.Text = GetDayName((int)heldInv.InvoiceDay);
                CommentTB.Text = heldInv.Comment;
                OrderStatus.Text = heldInv.OrderType;
                Thread t = new Thread(() => FillPOS(heldInv.InvoiceItems));
                t.Start();


            }
            else if (heldInv.Status == InvStat.Printed)
            {
                StopEditing = false;
                ButtonStates(true);
                OrdersPanel.Enabled = true;
                InvoiceNumberID.Text = heldInv.ID.ToString();
                MobileTB.Text = heldInv.CustomerNumber;
                NameTB.Text = heldInv.CustomerName;
                TimeTB.Text = heldInv.TimeAMPM;
                DayMenuBTN.Text = GetDayName((int)heldInv.InvoiceDay);
                CommentTB.Text = heldInv.Comment;
                OrderStatus.Text = heldInv.OrderType;
                Thread t = new Thread(() => FillPOS(heldInv.InvoiceItems));
                t.Start();


            }
            else if (heldInv.Status == InvStat.SavedToPOS)
            {
                StopEditing = true;
                ButtonStates(false);
                OrdersPanel.Enabled = true;
                InvoiceNumberID.Text = heldInv.ID.ToString();
                MobileTB.Text = heldInv.CustomerNumber;
                NameTB.Text = heldInv.CustomerName;
                TimeTB.Text = heldInv.TimeAMPM;
                DayMenuBTN.Text = GetDayName((int)heldInv.InvoiceDay);
                CommentTB.Text = heldInv.Comment;
                OrderStatus.Text = heldInv.OrderType;
                Thread t = new Thread(() => FillPOS(heldInv.InvoiceItems));
                t.Start();

            }
            else
            {
                StopEditing = true;
                ButtonStates(false);
                InvoiceNumberID.Text = heldInv.ID.ToString();
                MobileTB.Text = heldInv.CustomerNumber;
                NameTB.Text = heldInv.CustomerName;
                TimeTB.Text = heldInv.TimeAMPM;
                DayMenuBTN.Text = GetDayName((int)heldInv.InvoiceDay);
                OrderStatus.Text = heldInv.OrderType;
                CommentTB.Text = heldInv.Comment;
                if (heldInv.OrderType != null || heldInv.OrderType != "") OrderStatus.Text = heldInv.OrderType;
                else OrderStatus.Text = InvoiceTypeOptions.Items[Properties.Settings.Default.defaultOrder].Text;

                Thread t = new Thread(() => FillPOS(heldInv.InvoiceItems));
                t.Start();


            }

        }
        private void FillPOS(List<POSItems> list)
        {
            Invoke(new EventHandler(delegate (object sender, EventArgs e)
            {
                AddingInProgress = true;
                POS.Clear();
                foreach (var item in list)
                {
                    POS.Add(item);
                }
                AddingInProgress = false;
                POS_ListChanged(null, null);
                AmountLBL_TextChanged1(null, null);
                //UpdatedDraft?.Invoke(this, null);

            }), new object[2] { this, null });



        }
        private void ButtonStates(bool t)
        {
            if (t)
            {
                PrintSave.Enabled = true;
                SaveInvoice.Enabled = true;
                DeleteInvoice.Enabled = true;
                RepeatOrder.Visible = false;
                LastOrder.Visible = false;

            }
            else
            {
                PrintSave.Enabled = false;
                SaveInvoice.Enabled = true;
                DeleteInvoice.Enabled = false;
                RepeatOrder.Visible = true;
            }
        }

        private void TimeInfo_Click(object sender, EventArgs e)
        {
            HourPicker.Items.Clear();
            foreach (var item in HoursList)
            {
                HourPicker.Items.Add(item.ToString());
                HourPicker.Show(Cursor.Position);
            }
        }

        private void TimeTB_TextChanged(object sender, EventArgs e)
        {

            TimeTB.MaxLength = 5;
            TimeInfo.Text = TimeParse.T(TimeTB.Text);
            if (TimeTB.Text == "") TimeInfo.Text = "الآن";
            SendKeys.Send("{END}");

        }


        private void DayBTN_Click(object sender, EventArgs e)
        {
            int day = (int)DateTime.Now.DayOfWeek;
            DayMenu.Items.Clear();
            DayMenu.Items.Add("الأحد");
            DayMenu.Items.Add("الإثنين");
            DayMenu.Items.Add("الثلاثاء");
            DayMenu.Items.Add("الأربعاء");
            DayMenu.Items.Add("الخميس");
            DayMenu.Items.Add("الجمعة");
            DayMenu.Items.Add("السبت");
            DayMenu.Items[day].Text += "-اليوم";
            DayMenu.Items[day].BackColor = Color.Lavender;
            DayMenu.Show(Cursor.Position.X + 10, Cursor.Position.Y - 90);
            DayMenu.Items[day].Select();

        }

        private void DayMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

            DayMenuBTN.Text = e.ClickedItem.Text.Replace("-اليوم", "");

        }


        private void TimePicker_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            TimeTB.Text = e.ClickedItem.Text;
            MinutesPicker.Items.Clear();

            foreach (var item in MinutesList)
            {
                MinutesPicker.Items.Add(item.ToString());
                MinutesPicker.Show(Cursor.Position);

            }
        }
        private void MinutesPicker_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            TimeTB.Text += e.ClickedItem.Text;
            TODPicker.Items.Clear();
            string a = TimeInfo.Text[0].ToString();


            foreach (var item in GetNewTODlist(a))
            {
                TODPicker.Items.Add(item.ToString());
                //Point ptLowerLeft = new Point(0, TimeTB.Height);
                //ptLowerLeft = TimeTB.PointToScreen(ptLowerLeft);
                TODPicker.Show(Cursor.Position);
            }

        }


        private List<string> GetNewTODlist(string a)
        {
            List<string> Asr = new List<string>() { "عصرا" };
            List<string> Evening = new List<string>() { "مساء" };
            List<string> MorningEvening = new List<string>() { "صباحا", "مساء" };
            List<string> MorningNight = new List<string>() { "صباحا", "ليلا" };
            List<string> DuhrNight = new List<string>() { "ظهرا", "ليلا" };
            List<string> selectedList;

            switch (a)
            {
                case "1": if (this.TimeInfo.Text[1].ToString() == "1" && this.TimeInfo.Text[2].ToString() == ":") { selectedList = MorningNight; break; } else if (this.TimeInfo.Text[1].ToString() == "0" && this.TimeInfo.Text[2].ToString() == ":") { selectedList = MorningNight; break; } else { selectedList = DuhrNight; break; }
                case "2": selectedList = DuhrNight; break;
                case "3": selectedList = Asr; break;
                case "4": selectedList = Evening; break;
                case "5": selectedList = Evening; break;
                case "6": selectedList = Evening; break;
                case "7": selectedList = MorningEvening; break;
                case "8": selectedList = MorningNight; break;
                case "9": selectedList = MorningNight; break;
                default: selectedList = TODList; break;
            }
            return selectedList;
        }



        private void TODPicker_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            TimeTB.Text += e.ClickedItem.Text.Remove(1, e.ClickedItem.Text.Length - 1);

        }

        private void TimeTB_Leave(object sender, EventArgs e)
        {
            string tod = "ص ظ ع م ل";
            if (TimeTB.Text.Length > 0)
            {
                if (TimeTB.Text.IndexOfAny(tod.ToCharArray()) <= 0)
                {

                    TODPicker.Items.Clear();
                    try
                    {
                        string a = TimeInfo.Text[0].ToString();
                        foreach (var item in GetNewTODlist(a))
                        {
                            TODPicker.Items.Add(item.ToString());
                            //Point ptLowerLeft = new Point(0, TimeTB.Height);
                            //ptLowerLeft = TimeTB.PointToScreen(ptLowerLeft);
                            if (sender.GetType() == typeof(TextBox))
                            {
                                var tb = (TextBox)sender;
                                TODPicker.Show(tb, tb.Location);
                            }
                            else
                            {
                                var tb = (Button)sender;
                                TODPicker.Show(tb, tb.Location);
                            }

                        }

                    }
                    catch (Exception)
                    {

                    }

                }
            }
        }

        private void DOWTB_TextChanged(object sender, EventArgs e)
        {
            this.DOWTB.Text = "";
            int day = (int)DateTime.Now.DayOfWeek;
            DayMenu.Items.Clear();
            DayMenu.Items.Add("الأحد");
            DayMenu.Items.Add("الإثنين");
            DayMenu.Items.Add("الثلاثاء");
            DayMenu.Items.Add("الأربعاء");
            DayMenu.Items.Add("الخميس");
            DayMenu.Items.Add("الجمعة");
            DayMenu.Items.Add("السبت");
            DayMenu.Items[day].Text += "-اليوم";
            DayMenu.Items[day].BackColor = Color.Lavender;
            Point ptLowerLeft = new Point(0, DOWTB.Height);
            ptLowerLeft = TimeTB.PointToScreen(ptLowerLeft);
            DayMenu.Show(ptLowerLeft);
            DayMenu.Items[day].Select();
        }




        private void DOWTB_DoubleClick(object sender, EventArgs e)
        {
            DayBTN_Click(DOWTB, new MouseEventArgs(MouseButtons.Left, 1, DayMenuBTN.Left + 10, DayMenuBTN.Top + 10, 0));
        }
        private void SectionNotes(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 2 && e.Button == MouseButtons.Right)
            {
                var send = sender as UnfocusableButton;
                var sect = send.Tag as POSsections;
                NotesForm notes = new NotesForm(sect);
                notes.Show();
            }
        }



        private void NameTB_Enter(object sender, EventArgs e)
        {
            var con = dbQ.LoadContacts(MobileTB.Text);
            CommentTB.AutoCompleteSource = AutoCompleteSource.None;
            LastOrder.Visible = true;
            if (con.Count > 0)
            {
                NameTB.Text = con[0].Name;
                CustomerMenu.Items.Clear();
                InvoiceCommentsMenu.Items.Clear();
                foreach (var c in con)
                {
                    CustomerMenu.Items.Add(c.Name);
                    if (c.comments != null)
                    {
                        var empty = c.comments.Replace(" ", "").ToString();
                        if (empty != "") InvoiceCommentsMenu.Items.Add(c.comments);
                    }
                }
            }
        }


        private void CustomerMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e != null)
            {
                NameTB.Text = e.ClickedItem.Text;
            }
        }



        private void InvoiceCommentsMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e != null)
            {
                CommentTB.Text = e.ClickedItem.Text;
            }
        }

        private void TimeTB_DoubleClick(object sender, EventArgs e)
        {
            TimeInfo_Click(TimeTB, new MouseEventArgs(MouseButtons.Left, 1, TimeInfo.Left + 10, TimeInfo.Top + 10, 0));

        }

        private void DvItems_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {


            var Cind = e.ColumnIndex;
            var Rind = e.RowIndex;
            if (Cind == 4)
            {

                if (dvItems.RowCount > 0 && dvItems.SelectedRows.Count != -1 && Rind != -1)
                {

                    var row = dvItems.Rows[Rind];
                    row.Selected = true;
                    POSItems item = (POSItems)row.DataBoundItem;
                    row.Selected = true;
                    var c = dbQ.GetSection(item);
                    FastComment.Items.Clear();

                    foreach (var sect in c)
                    {
                        if (sect.NotesList.Count > 0)
                        {

                            foreach (string it in sect.NotesList)
                            {
                                FastComment.Items.Add(it);
                            }

                        }
                    }

                    FastComment.Items.Add("");
                    FastComment.Show(Cursor.Position);
                    FastComment.Tag = item;




                }
            }


        }

        private void FastComment_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (dvItems.Rows.Count > 0)
            {

                if (e.ClickedItem.Text != "")
                {
                    dvItems.Focus();
                    //var a = dvItems.SelectedRows[0].Cells[4];
                    dvItems.SelectedRows[0].Cells[4].Selected = true;
                    dvItems.SelectedRows[0].Cells[4].Value += " " + e.ClickedItem.Text + " ";
                    SendKeys.Send("{Enter}");
                    //var a = dvItems.CurrentRow.Cells[4];
                    //dvItems.CurrentRow.Cells[4].Selected = true;
                }
                else
                {
                    dvItems.Focus();
                    //var a = dvItems.SelectedRows[0].Cells[4];
                    dvItems.SelectedRows[0].Cells[4].Selected = true;
                    dvItems.SelectedRows[0].Cells[4].Value = "";

                }
            }

        }


        private void TelBTN_Click(object sender, EventArgs e)
        {
            var se = sender as ToolStripButton;
            foreach (ToolStripButton btn in InvoiceTypeOptions.Items)
            {
                btn.Checked = false;
            }
            se.Checked = true;
            InvoiceTypeOptions.Visible = false;
            OrderStatus.Text = se.Text;
        }

        private void OrderStatus_Click(object sender, EventArgs e)
        {
            InvoiceTypeOptions.Visible = true;
            InvoiceTypeOptions.BringToFront();


        }

        private void OrdersPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MobileTB_TextChanged(object sender, EventArgs e)
        {
            if (InvoiceNumberID.Enabled == false)
            {
                NewBTN_Click(null, null);
            }
            //UpdatedDraft?.Invoke(this, null);
        }

        private void AmountLBL_TextChanged(object sender, EventArgs e)
        {
            //UpdatedDraft?.Invoke(this, null);

        }

        private void MainMenu_Click(object sender, EventArgs e)
        {
            if (this.panel1.Visible == true)
            {
                this.panel1.Visible = false;
                //if (DbInv.IsItOpen(Convert.ToInt32(InvoiceNumberID.Text)))
                //{

                //    NewBTN_Click(null, null);
                //}


            }
            else
            {
                AmountLBL_TextChanged1(null, null);
            }



        }


        private async Task AddDraftInvoicesAsync()
        {

            var DraftList = DbInv.GetDraftInvoices();

            foreach (var item in DraftList)

            {
                if (item.InvoiceItems.Count > 0)
                {
                    _InvBTN draftBTN = new _InvBTN(item);
                    int ID = item.ID;
                    draftBTN.Tag = ID;
                    draftBTN.Click += (o, i) => HeldOrder_click(o, i);

                    HeldPanel.Controls.Add(draftBTN);
                }
                else if (item.InvoiceItems.Count == 0)
                {
                    if (Control.ModifierKeys == Keys.Control)
                    {
                        DbInv.DeleteInvoicesByID(item.ID);

                    }

                }
            }
            await Task.CompletedTask;

        }

        private async Task RadioChecked(int day)
        {
            PrintedInvoices.Controls.Clear();
            if (day == 100)
            {
                radioChecked = day;
                var List = DbInv.GetSavedInvoices();
                foreach (var item in List)
                {

                    _InvBTN PrintedBTN = new _InvBTN(item);
                    int ID = item.ID;
                    PrintedBTN.Tag = ID;

                    PrintedBTN.Click += HeldOrder_click;
                    PrintedBTN.MouseUp += HeldOrder_MouseUp;
                    PrintedInvoices.Controls.Add(PrintedBTN);

                }
            }
            else
            {
                radioChecked = day;

                var List = DbInv.GetPrintedInvoices();
                //     var lists = new List<Invoice>();//
                //  lists.Clear();//
                foreach (var item in List)
                {
                    _InvBTN PrintedBTN = new _InvBTN(item);
                    if ((int)item.InvoiceDay == day)
                    {
                        int ID = item.ID;
                        PrintedBTN.Tag = ID;
                        PrintedBTN.Click += HeldOrder_click;
                        PrintedBTN.MouseUp += HeldOrder_MouseUp;
                        PrintedInvoices.Controls.Add(PrintedBTN);
                        //  lists.Add(item); //
                    }
                    else if (day == -1)
                    {
                        int ID = item.ID;
                        PrintedBTN.Tag = ID;
                        PrintedBTN.Click += HeldOrder_click;
                        PrintedBTN.MouseUp += HeldOrder_MouseUp;
                        PrintedInvoices.Controls.Add(PrintedBTN);
                    }

                }
                //  var a = new SavingandPayment.PaymentOptions(lists); //
                //  a.ShowDialog(); //
                await Task.CompletedTask;

            }
        }


        private void Orders_Load(object sender, EventArgs e)
        {
            NewBTN_Click(null, null);
            if (Properties.Settings.Default.showMenu)
            {
                unfocusableButton3.Enabled = true;
            }
            else unfocusableButton3.Enabled = false;
        }
        private void TimeButton_Click(object sender, EventArgs e)
        {
            Custom_Classes.CreateOffer.CreateOfferNow(PrintNewInvoice());

        }

        private void DvItems_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                dvItems.Rows[e.RowIndex - 1].Selected = true;
            }
            else if (dvItems.Rows.Count > 0) dvItems.Rows[e.RowIndex].Selected = true;
        }

        private void Fri_Click(object sender, EventArgs e)
        {

        }

        private void SearchTB_TextChanged(object sender, EventArgs e)
        {
            if (SearchTB.Text.Replace(" ", "") != "" && SearchTB.Text.Length > 2)
            {
                if (radioChecked != 100)
                {

                    List<Invoice> searchresults = new List<Invoice>();
                    PrintedInvoices.Controls.Clear();
                    searchresults = DbInv.SearchPrintedInvoices(SearchTB.Text);
                    foreach (Invoice Inv in searchresults)
                    {
                        if (Inv != null)
                        {

                            if (radioChecked == -1)
                            {
                                _InvBTN ResultsBTN = new _InvBTN(Inv);
                                int ID = Inv.ID;
                                ResultsBTN.Tag = ID;
                                ResultsBTN.Click += HeldOrder_click;
                                ResultsBTN.MouseUp += HeldOrder_MouseUp;

                                PrintedInvoices.Controls.Add(ResultsBTN);
                            }
                            else
                            {
                                if (Inv.InvoiceDay == GetWhatDay(radioChecked))
                                {
                                    _InvBTN ResultsBTN = new _InvBTN(Inv);
                                    int ID = Inv.ID;
                                    ResultsBTN.Tag = ID;
                                    ResultsBTN.Click += HeldOrder_click;
                                    ResultsBTN.MouseUp += HeldOrder_MouseUp;
                                    PrintedInvoices.Controls.Add(ResultsBTN);
                                }
                            }


                        }

                    }

                }

                else
                {
                    PrintedInvoices.Controls.Clear();
                    var List = DbInv.GetAllSavedInvoices();
                    foreach (var item in List)
                    {
                        if (item.SearchResult.Contains(SearchTB.Text))
                        {
                            _InvBTN PrintedBTN = new _InvBTN(item);
                            int ID = item.ID;
                            PrintedBTN.Tag = ID;

                            PrintedBTN.Click += HeldOrder_click;
                            //PrintedBTN.MouseUp += HeldOrder_MouseUp;
                            PrintedInvoices.Controls.Add(PrintedBTN);
                        }
                    }


                }
            }

        }
        public InvDay GetWhatDay(int radioChecked)
        {
            InvDay day = (InvDay)radioChecked;

            return day;
        }

        private void DeleteInvoice_Click(object sender, EventArgs e)
        {
            if (IsItPrinted)
            {
                var DeleteFRM = new AreYouSure();
                DeleteFRM.ShowDialog();

                if (DeleteFRM.DialogResult == DialogResult.Abort)
                {
                    if (DbInv.DeleteInvoice(Convert.ToInt32(InvoiceNumberID.Text), 0))
                    {
                        NewBTN_Click(null, null);
                    }
                }
                else if (DeleteFRM.DialogResult == DialogResult.Cancel)
                {
                    if (DbInv.DeleteInvoice(Convert.ToInt32(InvoiceNumberID.Text), 1))
                    {
                        NewBTN_Click(null, null);
                    }
                }

            }

        }

        private void SaveInvoice_Click(object sender, EventArgs e)
        {
            if (!PrintSave.Enabled)
            {
                if (repeatedBehavior.AreYouSure("تم تخزين الفاتورة من قبل هل تريد تخزينها مجددا؟", "هل فشلت عملية التخزين؟"))
                {
                    var SaveToPOS = PrintNewInvoice();
                    if (IsItPrinted && SaveToPOS.Equal(DbInv.GetInvoiceByID(SaveToPOS.ID)))
                    {
                        Save2POS(SaveToPOS);

                    }
                    else if (IsItPrinted && !SaveToPOS.Equal(DbInv.GetInvoiceByID(SaveToPOS.ID)))
                    {
                        DialogResult dialogResult = MessageBox.Show("هل تريد إعادة الطباعة؟", "تم تعديل الفاتورة", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {

                            PrintSave_Click(sender, null);
                            Save2POS(SaveToPOS);
                        }
                        else if (dialogResult == DialogResult.No)
                        {

                            Save2POS(SaveToPOS);
                        }

                    }
                    else
                    {
                        PrintSave_Click(sender, null);
                        Save2POS(SaveToPOS);

                    }
                }
            }
        }
        private void Save2POS(Invoice SaveToPOS)
        {
            this.Hide();
            var canceled = new _InvBTN(SaveToPOS);
            int id = SaveToPOS.ID;
            canceled.Tag = id;

            var a = new SavingandPayment.PaymentOptions(SaveToPOS);
            a.PrintOrNot += A_PrintOrNot;
            d.Hide();
            if (a.ShowDialog() == DialogResult.OK)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                NewBTN_Click(null, null);
            }
            else
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;

                HeldOrder_click(canceled, null);
            }


        }

        private void A_PrintOrNot(object sender, Invoice e)
        {

            if (checkBox1.Checked && e.OrderType == "هاتف")
            {
                PrintInvoiceReady.Print(Properties.Settings.Default.DefaultPrinter, e);
            }

        }

        private void FastComment_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            FastComment.Items.Clear();

        }

        private void label7_Click(object sender, EventArgs e)
        {
            try
            {
                dvItems.FirstDisplayedScrollingRowIndex = dvItems.FirstDisplayedScrollingRowIndex + 1;
            }
            catch (Exception)
            {


            }

        }

        private void label5_Click(object sender, EventArgs e)
        {
            try
            {
                dvItems.FirstDisplayedScrollingRowIndex = dvItems.FirstDisplayedScrollingRowIndex - 1;
            }
            catch (Exception)
            {


            }


        }

        private void GroupSave_CheckedChanged(object sender, EventArgs e)
        {
            if (GroupSave.Checked)
            {
                label8.Visible = true;
            }
            else
            {
                label8.Visible = false;
                var a = PrintedInvoices.Controls.Find("MulipleSave", true);
                if (a.Length != 0)
                {
                    if (a[0] != null)
                    {
                        foreach (var control in PrintedInvoices.Controls)
                        {
                            if (control.GetType().ToString() == "OrderForm.Custom_UI_Elements.MulipleSave")
                            {
                                var MS = (MulipleSave)control;
                                PrintedInvoices.Controls.Remove(MS);


                            }
                        }

                    }

                }
            }

        }

        private void Orders_FormClosing(object sender, FormClosingEventArgs e)
        {
            DbInv.UpdateDraftInvoice(Convert.ToInt32(InvoiceNumberID.Text), false);
        }

        private void NameTB_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text, true))
            {
                var num = (string)e.Data.GetData(DataFormats.UnicodeText);
                var name = (string)e.Data.GetData(DataFormats.UnicodeText);
                name = Regex.Replace(name, "[0-9]", "").Replace("+", "");
                if (num.Contains("+966"))
                {
                    num = num.Replace("+966", "0").Replace(" ", "");

                    var numbersyntax2 = @"(05)([0-9]{8})|5([0-9]{8})|\+([0-9]{12})|00([0-9]{12})|\+([0-9]{11})|00([0-9]{11})";
                    Regex rgx2 = new Regex(numbersyntax2);
                    Match numbermatch2 = rgx2.Match(num);

                    if (numbermatch2.Success)
                    {
                        MobileTB.Text = numbermatch2.Value.ToString().Replace(" ", "");
                        NameTB.Text = name.Replace("\n", "").Replace("\r", "").Replace("  ", "").Replace("   ", "").Replace("~", "");
                    }
                    else NameTB.Text = name.Replace("\n", "").Replace("\r", "").Replace("  ", "").Replace("   ", "").Replace("~", "");
                    ;


                }
                else
                {
                    var nums = num.Replace(" ", "");

                    var numbersyntax2 = @"(05)([0-9]{8})|5([0-9]{8})|\+([0-9]{12})|00([0-9]{12})|\+([0-9]{11})|00([0-9]{11})";
                    Regex rgx2 = new Regex(numbersyntax2);
                    Match numbermatch2 = rgx2.Match(nums);

                    if (numbermatch2.Success)
                    {
                        MobileTB.Text = numbermatch2.Value.ToString().Replace(" ", "");
                        NameTB.Text = name.Replace("\n", "").Replace("\r", "");
                    }
                    else NameTB.Text = name.Replace("\n", "").Replace("\r", "");
                }
                //else { 
                //    //var numbersyntax = "(05)([0-9]{8})|5([0-9]{8})";
                //var numbersyntax = @"(05)([0-9]{8})|5([0-9]{8})|\+([0-9]{12})|00([0-9]{12})|\+([0-9]{11})|00([0-9]{11})";
                //Regex rgx = new Regex(numbersyntax);
                //Match numbermatch = rgx.Match(num);
                //if (numbermatch.Success)
                //{

                //    MobileTB.Text = numbermatch.Value.ToString();
                //    NameTB.Text = num.Replace(numbermatch.Value, "");

                //}
                //else NameTB.Text = num;

                //}


            }
        }

        private void NameTB_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text, true))
            {
                e.Effect = DragDropEffects.Copy;
            }

        }

        private void PrintSave_MouseEnter(object sender, EventArgs e)
        {
            InvoiceTypeOptions.Show();
            InvoiceTypeOptions.BringToFront();

        }

        private void DayLBL_Click(object sender, EventArgs e)
        {
            //var a = new WpfApp1.MainWindow();
            //a.sayhi();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var SaveToPOS = PrintNewInvoice();
            if (IsItPrinted/* && SaveToPOS.Equal(DbInv.GetInvoiceByID(SaveToPOS.ID))*/)
            {
                Save2POS(SaveToPOS);

            }
        }

        private void SaveInvoice_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void HoldInvoice_click(object sender, EventArgs e)
        {
            UpdatedDraft?.Invoke(this, null);
            NewBTN_Click(null, null);
        }

        #region Show Offer
        public bool MenuShowing = false;
        displayOffer d = new displayOffer();


        public void MenuShowingStatus(object sender, EventArgs e)
        {
            MenuShowing = false;
        }
        #endregion

        private void unfocusableButton1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(MobileTB.Text);
        }

        private void unfocusableButton2_Click(object sender, EventArgs e)
        {
            MobileTB.Text = Clipboard.GetText(TextDataFormat.Text);
        }
        public Menu.MainWindow DM = new Menu.MainWindow();
        public bool DMShown = false;
        private void DhuhrLBL_Click(object sender, EventArgs e)
        {
            //if (DMShown)
            //{
            //    DM.Hide();
            //    DMShown = false;
            //}
            //else
            //{
            //    DMShown = true;
            //    DM.Show();

            //    List<object> list = new List<object>();
            //    List<POSItems> po = POS.ToList<POSItems>();
            //    list.Add(po);
            //    foreach (sharedCode.POSItems item in POS)
            //    {
            //        list.Add(item);
            //    }
            //    _ = DM.LaunchMenu(list, "فطاير شامية");
            //}

        }

        private void unfocusableButton4_Click(object sender, EventArgs e)
        {

            if (Screen.AllScreens.Count() > 0)
            {
                try
                {
                    if (!MenuShowing)
                    {
                        MenuShowing = true;
                        d.pbox.Image = Custom_Classes.CreateOffer.CreateOfferNow(PrintNewInvoice());
                        d.Location = Screen.AllScreens[1].WorkingArea.Location;
                        d.Top += 150;
                        d.Left += 40;
                        d.Show();
                        d.timer1.Tick += new EventHandler(MenuShowingStatus);
                        d.timer1.Start();
                    }
                    else { d.stopNow(); MenuShowing = false; }
                }
                catch (Exception)
                {


                }



            }
            else Custom_Classes.CreateOffer.CreateOfferNow(PrintNewInvoice());

        }
        private void MenuSelection_Opening(object sender, CancelEventArgs e)
        {
            MenuSelection.Items.Clear();

            MenuDB.GetMenus().ForEach(x => MenuSelection.Items.Add(x));
            if (MenuSelection.Items.Count == 0)
            {
                e.Cancel = true;
            }
        }

        private void MenuSelection_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            MenuTimeOut.Start();
            string a = e.ClickedItem.Text;

            _ = MenuSelection_ItemClicked(a);
        }
        private async Task MenuSelection_ItemClicked(string a)
        {
            await DM.LaunchMenu(MenuDB.GetMenuItems(a), a);
        }

        private void unfocusableButton3_Click(object sender, EventArgs e)
        {

            if (Screen.AllScreens.Count() > 1)
            {

                if (DM.Visibility != System.Windows.Visibility.Visible)
                {
                    DM.Show();
                    _ = DM.LaunchMenu(MenuDB.GetMenuItems(MenuDB.GetMenus().First()), MenuDB.GetMenus().First());
                }
                else MenuSelection.Show(unfocusableButton3, unfocusableButton3.Left + 82, unfocusableButton3.Top + 26);

            }

        }

        private void MenuTimeOut_Tick(object sender, EventArgs e)
        {
            _ = DM.LaunchMenu(MenuDB.GetMenuItems(MenuDB.GetMenus().First()), MenuDB.GetMenus().First());
            MenuTimeOut.Stop();

        }

        private void AsrLBL_Click(object sender, EventArgs e)
        {

        }

        private void ItemNameTag_Click(object sender, EventArgs e)
        {
            string text = "هل تريد تغيير حالة المادة؟" + Environment.NewLine + "Yes المادة متوفرة" + Environment.NewLine + " No المادة غير متوفرة";
            DialogResult dialogResult = MessageBox.Show(text, "تعدل حالة توفر المادة", MessageBoxButtons.YesNo);
            var s = (ToolStripMenuItem)sender;
            var item = (POSItems)s.GetCurrentParent().Tag;

            if (dialogResult == DialogResult.Yes)
            {
                dbQ.MatAvailableSet(item.Barcode, true);
            }
            else dbQ.MatAvailableSet(item.Barcode, false);


        }

        private void RepeatOrder_Click(object sender, EventArgs e)
        {
            List<POSItems> a = new List<POSItems>();
            POS.ToList().ForEach(x => a.Add(x));
            NameTB.Text += " ";
            MobileTB.Text += " ";
            string name = " " + NameTB.Text;
            string number = MobileTB.Text;
            NewBTN_Click(null, null);
            a.ForEach(x => POS.Add(x));
            DialogResult dialogResult = MessageBox.Show("هل تريد إستخدام الإسم والرقم؟", "هل الطلب لنفس العميل؟", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                NameTB.Text = name;
                MobileTB.Text = number;
            }
            a.Clear();

        }

        private void LastOrder_Click(object sender, EventArgs e)
        {
            Invoice invoice = DbInv.GetInvoiceByPhoneNumber(MobileTB.Text);
            if (invoice != null)
            {
                POS.Clear();
                invoice.InvoiceItems.ForEach(x => POS.Add(x));
                CommentTB.Text = invoice.Comment;
                LastOrder.Visible = false;
            }


        }

        private void CommentTB_MouseDown(object sender, MouseEventArgs e)
        {
            if (InvoiceCommentsMenu.Items.Count > 0 && e.Button == MouseButtons.Right) InvoiceCommentsMenu.Show();
        }
    }

}