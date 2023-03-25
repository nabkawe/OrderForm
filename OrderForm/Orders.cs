using LiteDB;
using Microsoft.Win32;
using OrderForm.Custom_UI_Elements;
using PrayerTimes;
using RestSharp;
using sharedCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;
using Color = System.Drawing.Color;
using DataFormat = RestSharp.DataFormat;
using DataFormats = System.Windows.Forms.DataFormats;
using DragDropEffects = System.Windows.Forms.DragDropEffects;
using DragEventArgs = System.Windows.Forms.DragEventArgs;
using MessageBox = System.Windows.Forms.MessageBox;
using Point = System.Drawing.Point;
using TextDataFormat = System.Windows.Forms.TextDataFormat;

using System.Reflection;
using OrderForm.SavingandPayment;
using static System.Windows.Forms.DataFormats;
using System.Security.Cryptography;
using static System.Net.WebRequestMethods;
using System.Runtime.InteropServices.WindowsRuntime;

namespace OrderForm
{


    public partial class Orders : Form
    {

        public static string APIConnection = Properties.Settings.Default.API_Connection;
        public static BindingList<POSItems> POS = new BindingList<POSItems>();
        public event EventHandler<string> UpdatedDraft;
        public static List<string> MinutesList = new List<string>() { "00", "05", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55" };
        public static List<string> HoursList = new List<string>() { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" };
        public static List<string> TODList = new List<string>() { "صباحا", "ظهرا", "عصرا", "مساء", "ليلا" };
        public static bool IsItPrinted = false;
        public bool IsItPrintedNow = false;
        public bool AddingInProgress = false;
        public bool APIAccess = Properties.Settings.Default.API_ACCESS;
        public static Invoice globalInvoice = null;
        public int radioChecked = 0;
        string Title = "برنامج تسجيل طلبات ليبرا + ";
        #region Form and Loading Region
        public static Orders MyForm { get; set; }

        public Orders()
        {
            //Properties.Settings.Default.DBConnection = @"Filename=C:\db\db.db;connection=Shared";
            //Properties.Settings.Default.Save();

            if (Properties.Settings.Default.Logo != null || Properties.Settings.Default.RestaurantName != null)
            {
                if (Properties.Settings.Default.Logo == "" || Properties.Settings.Default.RestaurantName == "")
                {
                    FirstStart F = new FirstStart();
                    F.ShowDialog();
                }
            }
            InitializeComponent();
            MyForm = this;

            if (APIAccess)
            {
                this.Text = Title + " API MODE ";
            }
            else this.Text = Title + " Local Network Mode";
            //dbQ.CreatePayment();
            if (APIAccess)
            {

                if (System.IO.File.Exists(Properties.Settings.Default.API_Server_Path))
                {
                    if (Process.GetProcessesByName("NetworkSynq").Length == 0)
                    {
                        ProcessStartInfo processInfo = new ProcessStartInfo(Properties.Settings.Default.API_Server_Path, "");
                        processInfo.WorkingDirectory = Properties.Settings.Default.API_Server_Path.Replace("NetworkSynq.exe", "");
                        processInfo.CreateNoWindow = true;
                        processInfo.UseShellExecute = false;
                        Process.Start(processInfo);
                        Thread.Sleep(3000);
                        LoadMethods();
                    }
                }
                else
                {
                    if (DbInv.AreYouAlive())
                    {
                        LoadMethods();
                    }
                    else
                    {
                        Thread.Sleep(3000);
                        if (!DbInv.AreYouAlive())
                        {
                            MessageBox.Show("تعذر الإتصال بالخادم، الرجاء التحقق من إعدادات الإتصال بالشبكة", "مشكلة بالإتصال");
                            SettingsPage_Click(null, null);


                        }

                    }


                }
            }
            else
            {
                LoadMethods(); // Local Not Recommended }


            }
        }


        public static List<POSItems> ItemsLists = new List<POSItems>();


        #region Materials related logic

        #region loading materials

        public void CreateSectionBtns(FlowLayoutPanel FlowPanel, POSsections obj)
        {
            UnfocusableButton Section = new UnfocusableButton()
            {
                Tag = obj,
                Text = obj.Name,
                Width = FlowPanel.Width - 5,
                Height = 40
            };

            Section.Click += new EventHandler(Section_Clicked);
            Section.MouseDown += new MouseEventHandler(SectionNotes);
            FlowPanel.Controls.Add(Section);

        }
        public void CreateItemBtns(FlowLayoutPanel FlowPanel, POSItems obj)
        {
            UnfocusableButton item = new UnfocusableButton()
            {
                Name = obj.Barcode,
                Tag = obj.Barcode,
                Text = obj.Name,
                Height = 70,
                Width = 92,
                Margin = new Padding(2),
            };


            if (CheckFile(obj.PicturePath))
            {
                item.Image = Image.FromFile(obj.PicturePath).GetThumbnailImage(50, 50, null, IntPtr.Zero);
            }
            item.Click += new EventHandler(Item_Clicked);
            item.MouseWheel += new MouseEventHandler(Item_MouseWheel);
            item.MouseDown += new MouseEventHandler(Item_MouseDown);
            //item.MouseHover += Item_MouseHover;
            FlowPanel.Controls.Add(item);
        }


        private bool CheckFile(string picturePath)
        {
            if (System.IO.File.Exists(picturePath)) return true; else return false;
        }

        #endregion

        #region Mouse related logic for materials
        private void Item_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var btn = (UnfocusableButton)sender;
                if (Properties.Settings.Default.showMenu) { OrderForm.MainWindow.FindByBarcode((string)btn.Tag); }


                rightClickMenu.Show(Cursor.Position);
                rightClickMenu.Items[3].Text = btn.Text;
                rightClickMenu.Items[2].Visible = false;
                rightClickMenu.Tag = (string)btn.Tag;
            }
            else
            {
                var btn = (UnfocusableButton)sender;
                //if (Properties.Settings.Default.showMenu) { OrderForm.MainWindow.FindByBarcode((string)btn.Tag); }
            }
            //item.Name;
        }
        private void Item_MouseWheel(object sender, MouseEventArgs e)
        {
            if (Properties.Settings.Default.WheelEnabled)
            {

                if (e.Delta > 0)
                {
                    var itembtn = (Button)sender;
                    var item = ItemsLists.First(x => x.Barcode == itembtn.Name);
                    AddtoGrid(item);
                }
                else
                {
                    var itembtn = (Button)sender;
                    var item = ItemsLists.First(x => x.Barcode == itembtn.Name);
                    EditItemGrid(item);
                }

            }

        }
        protected void Section_Clicked(object sender, EventArgs e)
        {
            var sectionbtn = (Button)sender;
            var section = (POSsections)sectionbtn.Tag;
            ItemsPanel1.Controls.Clear();
            var ind = SectionsPanel.Controls.GetChildIndex(sectionbtn);

            ItemsLists.ForEach(x => { if (section.Name == x.SectionName) CreateItemBtns(ItemsPanel1, x); });
            //dbQ.GetItemsForSection(section.Name).ForEach(x => CreateItemBtns(ItemsPanel1, x));
        }
        protected void Item_Clicked(object sender, EventArgs e)
        {
            var itembtn = (Button)sender;
            var item = ItemsLists.First(x => x.Barcode == itembtn.Name);
            //var item = (POSItems)itembtn.Tag;
            if (Properties.Settings.Default.showMenu) { OrderForm.MainWindow.FindByBarcode(item.Barcode); }
            AddtoGrid(item);

        }
        #endregion


        bool StopEditing = false;
        #region material insertion 
        public void AddtoGrid(POSItems items)
        {
            POSItems item = new POSItems(items);
            if (!StopEditing)
            {
                if (InvoiceNumberID.Enabled == false)
                {
                    NewBTN_Click(null, null);
                }
                bool alreadyExists = POS.Any(x => x.ID == item.ID);
                if (alreadyExists == true)
                {
                    var found = POS.Single(x => x.ID == item.ID);
                    foreach (DataGridViewRow row in dvItems.Rows)
                    {
                        if (row.DataBoundItem.Equals(found)) row.Selected = true;

                    }
                    found.ChangeQuantity(1);
                }
                else
                {
                    item.Quantity = 1;
                    POS.Add(item);
                    foreach (DataGridViewRow row in dvItems.Rows)
                    {
                        if (row.DataBoundItem.Equals(item)) row.Selected = true;

                    }
                }
            }
        }
        public void EditItemGrid(POSItems item)
        {

            if (!StopEditing)
            {
                bool alreadyExists = POS.Any(x => x.ID == item.ID);
                if (alreadyExists)
                {
                    var found = POS.Single(x => x.ID == item.ID);
                    foreach (DataGridViewRow row in dvItems.Rows)
                    {
                        if (row.DataBoundItem.Equals(found)) row.Selected = true;

                    }
                    found.ChangeQuantity(-1);
                }
            }
        }
        #endregion

        #endregion

        public void LoadMaterials()
        {
            try
            {
                ItemsLists.Clear();
                list.Clear();
                lists.Clear();
                try
                {
                    lists = dbQ.PopulateSections();
                }
                catch (System.Net.Http.HttpRequestException)
                {
                    this.Focus();
                    if (repeatedBehavior.AreYouSure("لم يتم العثور على السيرفر، هل تريد الدخول في وضع الشبكة مؤقتا أم إعادة المحاولة؟ " + Environment.NewLine + "Yes = أعد المحاولة + No = إعتمد على الشبكة المحلية ", "فشلت عملية التزامن"))
                    { retryConnection(); }
                    else { Properties.Settings.Default.API_ACCESS = false; }
                }


                SectionsPanel.Controls.Clear();

                int c = -1;
                lists.ForEach(l => { c += 1; CreateSectionBtns(SectionsPanel, l); dbQ.GetItemsForSection(l.Name).ForEach(i => ItemsLists.Add(i)); });
                ItemsPanel1.Controls.Clear();
                if (SectionsPanel.Controls.Count > 0) { Section_Clicked(SectionsPanel.Controls[0], null); }

            }
            catch (Exception)
            {
                //throw;
                Console.WriteLine("LoadMaterials Error.");
            }
        }

        private void retryConnection()
        {
            if (System.IO.File.Exists(Properties.Settings.Default.API_Server_Path))
            {
                foreach (var process in Process.GetProcessesByName("NetworkSynq"))
                {
                    process.Kill();
                }

                ProcessStartInfo processInfo = new ProcessStartInfo(Properties.Settings.Default.API_Server_Path, "");
                processInfo.WorkingDirectory = Properties.Settings.Default.API_Server_Path.Replace("NetworkSynq.exe", "");
                processInfo.CreateNoWindow = true;
                processInfo.UseShellExecute = false;
                Process.Start(processInfo);
            }
            else
            {
                if (!DbInv.AreYouAlive())
                {
                    this.Focus();
                    if (repeatedBehavior.AreYouSure("لم يتم العثور على السيرفر، هل تريد الدخول في وضع الشبكة مؤقتا أم إعادة المحاولة؟ " + Environment.NewLine + "Yes = أعد المحاولة + No = إعتمد على الشبكة المحلية ", "فشلت عملية التزامن"))
                    { retryConnection(); }
                    else { Properties.Settings.Default.API_ACCESS = false; this.Text = "****Local Connection****"; }
                }
            }
        }

        List<POSsections> lists = new List<POSsections>();
        List<POSItems> list = new List<POSItems>();

        private void LoadMethods()
        {
            //Properties.Settings.Default.DBConnection = "filename=c:\\db\\db.db;connection=shared";
            if (Properties.Settings.Default.showMenu)
            {
                if (Screen.AllScreens.Count() > 1)
                {

                    if (DM.Visibility != System.Windows.Visibility.Visible)
                    {

                        if (MenuDB.GetMenus().Count > 0)
                        {
                            DM.Show();
                            _ = DM.LaunchMenu(MenuDB.GetMenuItems(MenuDB.GetMenus().First()), MenuDB.GetMenus().First(), langCheck.Checked, Properties.Settings.Default.ItemSize); ;
                        }
                    }
                }
            }
            LoadMaterials();
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
            string[] days = culture.DateTimeFormat.DayNames;
            return days[dayInt];
        }
        public int GetDayOfWeek()
        {
            Dictionary<string, int> days = new Dictionary<string, int>()
    {
        { "السبت", (int)DayOfWeek.Saturday },
        { "الأحد", (int)DayOfWeek.Sunday },
        { "الإثنين", (int)DayOfWeek.Monday },
        { "الثلاثاء", (int)DayOfWeek.Tuesday },
        { "الأربعاء", (int)DayOfWeek.Wednesday },
        { "الخميس", (int)DayOfWeek.Thursday },
        { "الجمعة", (int)DayOfWeek.Friday }
    };

            if (DayMenuBTN.Text == "اليوم")
            {
                var daysOfWeek = DateTime.Now.DayOfWeek;
                return Convert.ToInt32(days[daysOfWeek.ToString()]);
            }
            else
            {
                return days[DayMenuBTN.Text];
            }
        }

        private void POS_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (!AddingInProgress)
            {
                if (POS.Count > 0)
                {
                    decimal total = POS.Sum((a) => a.TotalPrice);
                    AmountLBL.Text = total.ToString();
                    ItemCount.Text = Orders.POS.Sum<POSItems>((x) => x.RealQuantity).ToString();
                }
                else
                {
                    AmountLBL.Text = "0.0";
                    ItemCount.Text = "0";
                }
            }
        }

        private void Orders_FormClosed(object sender, FormClosedEventArgs e)
        {
            dvItems.MouseWheel -= new MouseEventHandler(DataGridView1_MouseWheel);
            this.UpdatedDraft -= this.UpdateDraft;

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
        }

        public NextPrayer.state state = NextPrayer.state.stateless;
        private void SalahTMR_Tick(object sender, EventArgs e)
        {
            bool afterPrayers = false;
            var now = DateTime.Now.ToString("hh:mm tt");
            TimeButton.Text = now; // change here
            TimeTillCountdown.Text = NextPrayer.UpdateCounter();
            if (afterPrayers) return;
            switch (NextPrayer.UpdateCounter(true))
            {
                case NextPrayer.state.AfterIsha:
                    {
                        TimeTillCountdown.Visible = false;
                        TimeLeftLBL.Visible = false;
                    }
                    break;
                case NextPrayer.state.After12am:
                    {
                        TimeTillCountdown.Visible = false;
                        TimeLeftLBL.Visible = false;
                        DateLBL.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        DayLBL.Text = DayLBL.Text = Orders.GetDayName((int)DateTime.Now.DayOfWeek);
                        afterPrayers = true;
                        break;
                    }

                default:
                    {
                        afterPrayers = false;
                        return;

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
            dvItems.Refresh();
            dvItems.Update();

            dvItems.Columns[4].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;

            dvItems.MouseWheel += new MouseEventHandler(DataGridView1_MouseWheel);

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
                        if (currentItem.Quantity == 0) currentItem.Quantity = 1;
                    }

                }

            }
            catch (Exception)
            {
                Console.WriteLine("DvItems_CellEndEdit");

            }
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
            if (Properties.Settings.Default.WheelGridEnabled)
            {
                if (dvItems.Rows.Count > 0)
                {
                    dvItems.Focus();
                    if (e.Delta > 0)
                    {
                        if (!StopEditing)
                        {
                            foreach (DataGridViewRow row in dvItems.Rows)
                            {
                                if (row.Selected == true)
                                {
                                    dvItems.CurrentCell = dvItems.Rows[row.Index].Cells[1];
                                    break;
                                }
                            }
                            POSItems currentItem = (POSItems)dvItems.CurrentRow.DataBoundItem;
                            currentItem.ChangeQuantity(1);
                            return;
                        }


                    }
                    else if (e.Delta < 0) { }

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
                            currentItem.ChangeQuantity(-1);
                        }
                    }
                    catch (Exception)
                    {

                    }

                }
            }
        }



        private void DvItems_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 1 && e.Button == MouseButtons.Right)
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
                    rightClickMenu.Tag = item.Barcode;
                    row.Selected = true;

                }

            }
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

            if (sender.GetType() == typeof(ToolStripMenuItem))
            {
                var s = (ToolStripMenuItem)sender;
                if (POS.Any(x => x.Barcode == (string)s.GetCurrentParent().Tag))
                {
                    var item = POS.First(x => x.Barcode == (string)s.GetCurrentParent().Tag);
                    item.Comment = "";

                    POS.Remove(item);
                }
            }

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
            if (ModifierKeys.HasFlag(Keys.Control))
            {
                string n = Environment.NewLine;
                MessageBox.Show(Application.ProductVersion + n + Properties.Settings.Default.API_Server_Path + n + Properties.Settings.Default.API_Connection);
            }
            else
            {
                Form SettingsForm = new SettingsPage();
                SettingsForm.Show();
            }
        }
        public static void SettingsClosed()
        {
            MyForm.SectionsPanel.Controls.Clear();
            MyForm.ItemsPanel1.Controls.Clear();
            MyForm.LoadMaterials();
            if (Properties.Settings.Default.API_ACCESS) MyForm.Text = "API Mode";
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


            if (ModifierKeys.HasFlag(Keys.Control) && ModifierKeys.HasFlag(Keys.Shift))
            {


            }
            else
            {
                MobileTB.Focus();
                if (POS.Count > 0)
                {
                    globalInvoice = null;
                    globalInvoice = PrintNewInvoice();
                    InvID = Convert.ToInt32(InvoiceNumberID.Text);
                    if (!globalInvoice.Equal(DbInv.GetInvoiceByID(InvID)))
                    {
                        PrintingLogic();
                        Contacts customer = new Contacts(NameTB.Text, MobileTB.Text, CommentTB.Text);
                        dbQ.SaveContacts(customer);
                        Invoice PNI = PrintNewInvoice();
                        PNI.TimeOfPrinting = DateTime.Now.ToString();

                        if (APIAccess)
                        {
                            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                            var client = new RestClient(APIConnection + "/LoadDB/UpdateInvoice");

                            var request = new RestRequest();

                            request.AddHeader("Content-Type", "application/json");
                            request.AddHeader("Accept", "application/json");
                            request.RequestFormat = DataFormat.Json;

                            string i = Newtonsoft.Json.JsonConvert.SerializeObject(PNI, Newtonsoft.Json.Formatting.Indented);// <Invoice>(item);
                            request.AddParameter("application/json", i, ParameterType.RequestBody);
                            var response = client.Post(request);
                            Console.WriteLine(response.Content.ToString());
                            DbInv.LogAction("Invoice Printed", PNI.ID, PNI.Status);


                        }
                        else
                        {
                            DbInv.UpdatePreparingInvoice(PNI);

                            DbInv.LogAction("Invoice Printed", PNI.ID, PNI.Status);
                        }

                        Custom_Classes.CreateOffer.CreateOfferNow(PrintNewInvoice(), true);

                        NewBTN_Click(null, null);
                    }

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

        private void NewBTN_Click(object sender, EventArgs e)
        {
            var se = sender;
            if (!IsItPrinted && POS.Count > 0 && se != null) { if (repeatedBehavior.AreYouSure("هل تريد حذف الفاتورة وبدء فاتورة جديدة؟", " تحذير الفاتورة غير مطبوعة")) Console.WriteLine("Yah"); else return; };
            try
            {
                IsItPrinted = false;
                Stopwatch sw = new Stopwatch();
                sw.Start();
                ButtonStates(true);
                StopEditing = false;
                //InvoiceID = DbInv.GetInvoicesCount();
                var draftInv = new Invoice();
                ;
                draftInv.Status = InvStat.Draft;
                draftInv.InEditMode = true;
                draftInv.OrderType = InvoiceTypeOptions.Items[Properties.Settings.Default.defaultOrder].Text;
                draftInv.InvoiceDay = GetWhatDay((int)DateTime.Now.DayOfWeek);

                InvoiceNumberID.Text = DbInv.CreatePreparingInvoice(draftInv).Replace("\"", "");

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
                HoldInvoice.Enabled = true;
                sw.Stop();
                Console.WriteLine("ArrayList:\tMilliseconds = {0},\tTicks = {1}", sw.ElapsedMilliseconds, sw.ElapsedTicks);
                displayOffer.CloseNow();
                this.Update();
                this.Refresh();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }



        }

        private void OrdersPage_Click(object sender, EventArgs e)
        {

            LoadOrders();
            this.Update();

        }

        private void Ordersbw_DoWork(object sender, DoWorkEventArgs e)
        {
            CheckDay();
        }

        private void LoadOrders()
        {
            this.panel1.Visible = true;
            this.splitContainer1.Visible = true;
            this.HeldPanel.Controls.Clear();
            // AddDraftInvoices(); 
            CheckDay();

            LastOrder.Visible = false;

        }

        private void CheckDay()
        {
            this.PrintedInvoices.Controls.Clear();

            var days = DateTime.Now.DayOfWeek;
            Dictionary<DayOfWeek, RadioButton> radioButtons = new Dictionary<DayOfWeek, RadioButton>()
            {
                { DayOfWeek.Saturday, Sat },
                { DayOfWeek.Sunday, Sun },
                { DayOfWeek.Monday, Mon },
                { DayOfWeek.Tuesday, Tue },
                { DayOfWeek.Wednesday, Wed },
                { DayOfWeek.Thursday, Thu },
                { DayOfWeek.Friday, Fri }
            };
            radioButtons[days].Checked = true;
            Fri_CheckedChanged(radioButtons[days], null);
        }

        private void Fri_CheckedChanged(object sender, EventArgs e)
        {
            var se = sender as RadioButton;
            if (se.Checked) switchCase(se.Name);
        }

        enum CustomDaysOfWeek
        {
            AllDays = -1,
            Sun = 0,
            Mon = 1,
            Tue = 2,
            Wed = 3,
            Thu = 4,
            Fri = 5,
            Sat = 6,
            History = 100
        }

        private void switchCase(string se)
        {
            CustomDaysOfWeek daysOfWeek;
            if (Enum.TryParse(se, out daysOfWeek))
            {
                RadioChecked((int)daysOfWeek);
            }
        }





        private void HeldOrder_MouseUp(object sender, MouseEventArgs e)
        {
            var se = (_InvBTN)sender;
            int id = (int)se.Tag;
            var inv = DbInv.GetInvoiceByID(id);

            if (e.Button == MouseButtons.Right && GroupSave.Checked)
            {
                AddListToSave(id);
                PrintedInvoices.Controls.Remove(se);
            }
            else if (e.Button == MouseButtons.Right && !GroupSave.Checked)
            {
                var a = new ContextMenuStrip() { Items = { "ملخص الفاتورة" } };
                inv.InvoiceTimeloglist.ForEach(x => a.Items.Add(x));

                if (inv.OrderType == "تطبيقات" && inv.Status != InvStat.SavedToPOS)
                {
                    var btnSave = new ToolStripButton() { Text = " تـــخـــزيـــن جـــــــــاهــــــــز" };
                    btnSave.Tag = id;
                    btnSave.Click += BtnSave_Click;
                    a.Items.Add(btnSave);
                }
                if (inv.POSInvoiceNumber != null)
                {
                    var btn = new ToolStripButton() { Text = "فتح الفاتورة في ليبرا" };
                    btn.Click += Btn_Click;

                    string posinv = inv.POSInvoiceNumber;
                    btn.Tag = posinv;
                    a.Items.Add(btn);


                }
                a.Show(se, new Point(0, 0));
            }
            else if (ModifierKeys.HasFlag(Keys.Control) && ModifierKeys.HasFlag(Keys.Shift))
            {
                Console.Beep(500, 500);
                if (inv.Status == InvStat.Deleted)
                {
                    var dt = DateTime.Now;
                    inv.TimeOfSaving = dt;
                    inv.Status = InvStat.SavedToPOS;
                    DbInv.UpdateInvoice(inv);
                }
                else if (inv.Status == InvStat.SavedToPOS)
                {
                    inv.Status = InvStat.Deleted;
                    DbInv.UpdateInvoice(inv);
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (repeatedBehavior.AreYouSure("هل قمت بتسليم الطلب للمندوب؟", "تأكيد تسليم الفاتورة"))
            {
                var se = sender as ToolStripButton;
                int id = (int)se.Tag;
                var inv = DbInv.GetInvoiceByID(id);
                inv.Status = InvStat.SavedToPOS;
                inv.POSInvoiceNumber = "جاهز";
                DbInv.CreateAppOrder(inv);
                string a = id.ToString();


                foreach (_InvBTN item in PrintedInvoices.Controls.OfType<_InvBTN>().ToList())
                {
                    if (item.Tag.ToString() == a)
                    {
                        PrintedInvoices.Controls.Remove(item);
                    }
                }
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

            if (posid != null)
            {
                new SavingandPayment.PaymentOptions(posid);
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
            var se = sender as _InvBTN;
            int id = Convert.ToInt32(se.Tag);
            Invoice heldInv = DbInv.GetInvoiceByID(id);
            if (ReadyStatus.Checked)
            {
                if (heldInv.Comment != null)
                {
                    if (heldInv.Comment.Contains("الطلب جاهز")){
                        heldInv.Comment = heldInv.Comment.Replace("الطلب جاهز", "");
                        DbInv.UpdateInvoice(heldInv);
                        var replacement = new _InvBTN(heldInv);
                        replacement.Click += HeldOrder_click;
                        replacement.Tag = id;

                        int index = PrintedInvoices.Controls.IndexOf(se);
                        this.PrintedInvoices.Controls.Add(replacement);
                        this.PrintedInvoices.Controls.SetChildIndex(replacement, index);

                        this.PrintedInvoices.Controls.Remove(se);
                        PrintedInvoices.Refresh();

                    }

                }
                else
                {
                    heldInv.Comment += "الطلب جاهز";
                
                    DbInv.UpdateInvoice(heldInv);
                    var replacement = new _InvBTN(heldInv);
                    replacement.Tag = id;
                    replacement.Click += HeldOrder_click;
                    int index = PrintedInvoices.Controls.IndexOf(se);

                    this.PrintedInvoices.Controls.Add(replacement);
                    this.PrintedInvoices.Controls.SetChildIndex(replacement, index);

                    this.PrintedInvoices.Controls.Remove(se);
                    PrintedInvoices.Refresh();


                }
                //OrdersPage_Click(null,null);
                return;
            }
            if (heldInv.Status != InvStat.Draft)
            {
                IsItPrinted = true;
                HoldInvoice.Enabled = false;
                DbInv.LogAction("Printed Invoice Opened", heldInv.ID, heldInv.Status);
                LoadInvoiceUI(heldInv);
            }
            else
            {
                //DbInv.UpdateDraftInvoice(Convert.ToInt32(InvoiceNumberID.Text), false);
                IsItPrinted = false;
                HoldInvoice.Enabled = true;
                DbInv.LogAction("Draft Invoice Opened", heldInv.ID, heldInv.Status);
                DbInv.UpdateDraftInvoice(heldInv.ID, true);
                LoadInvoiceUI(heldInv);
            }
        }

        public void LoadInvoiceUI(Invoice heldInv)
        {

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
                FillPOS(heldInv.InvoiceItems);
                this.panel1.Visible = false;
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
                FillPOS(heldInv.InvoiceItems);
                this.panel1.Visible = false;
            }
            else if (heldInv.Status == InvStat.SavedToPOS)
            {
                if (History.Checked)
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
                    FillPOS(heldInv.InvoiceItems);
                    this.panel1.Visible = false;

                }
                else { OrdersPage_Click(null, null); }

            }
            else if (heldInv.Status == InvStat.Deleted)
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
                FillPOS(heldInv.InvoiceItems);
                this.panel1.Visible = false;
            }


        }
        private void FillPOS(List<POSItems> list)
        {

            AddingInProgress = true;
            POS.Clear();
            foreach (var item in list)
            {
                POS.Add(item);
            }
            AddingInProgress = false;
            POS_ListChanged(null, null);

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
            //TimeTB.Text= TimeTB.Text.Replace(":", "");
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
            if (MobileTB.Text.Replace(" ", "") != "")
            {
                var con = dbQ.LoadContacts(MobileTB.Text);
                LastOrder.Visible = true;
                if (con != null)
                {
                    NameTB.Text = con.Name;

                }
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
                    FastComment.Items.Add("(((ملاحظة مخصصة)))");


                    if (c.NotesList.Count > 0)
                    {

                        foreach (string it in c.NotesList)
                        {
                            FastComment.Items.Add(it);
                        }

                    }


                    FastComment.Show(Cursor.Position);
                    FastComment.Tag = item;




                }
            }
            else
            {
                if (dvItems.RowCount > 0 && dvItems.SelectedRows.Count != -1 && Rind != -1)
                {

                    var row = dvItems.Rows[Rind];
                    row.Cells[1].Selected = true;
                }
            }


        }

        private void FastComment_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (dvItems.Rows.Count > 0)
            {
                if (e.ClickedItem.Text != "(((ملاحظة مخصصة)))")
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



        private void TelButton_Click(object sender, EventArgs e)
        {
            var se = sender as ToolStripButton;
            foreach (ToolStripButton btn in InvoiceTypeOptions.Items)
            {
                btn.Checked = false;
            }
            se.Checked = true;
            OrderStatus.Text = se.Text;
        }



        private void OrdersPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MobileTB_TextChanged(object sender, EventArgs e)
        {
            if (MobileTB.Text.Replace(" ", "") != "")
            {
                MobileLBL.Visible = false;
            }
            else MobileLBL.Visible = true;
            if (NameTB.Text.Replace(" ", "") != "")
            {
                NameLBL.Visible = false;
            }
            else NameLBL.Visible = true;
            if (TimeTB.Text.Replace(" ", "") != "")
            {
                label1.Visible = false;
            }
            else
                label1.Visible = true;
            if (DOWTB.Text.Replace(" ", "") != "")
            {
                label3.Visible = false;
            }
            else
                label3.Visible = true;
            if (CommentTB.Text.Replace(" ", "") != "")
            {
                CommentLBL.Visible = false;
            }
            else
                CommentLBL.Visible = true;
            if (InvoiceNumberID.Enabled == false)
            {
                NewBTN_Click(null, null);
            }
            if (OrderStatus.Text == "تطبيقات")
            {
                jahezPrice.Visible = true;
            }
            else { jahezPrice.Visible = false; jahezPrice.Text = "0"; }
            foreach (ToolStripButton btn in InvoiceTypeOptions.Items)
            {
                if (btn.Text == OrderStatus.Text) btn.Checked = true;
                else btn.Checked = false;

            }
        }



        private void MainMenu_Click(object sender, EventArgs e)
        {
            if (this.panel1.Visible == true)
            {
                this.panel1.Visible = false;
                this.splitContainer1.Visible = false;
                //if (DbInv.IsItOpen(Convert.ToInt32(InvoiceNumberID.Text)))
                //{

                //    NewBTN_Click(null, null);
                //}
                this.Update();

            }
            else
            {
                AmountLBL_TextChanged1(null, null);
            }
            if (ModifierKeys.HasFlag(Keys.Control))
            {
                Console.Beep(1000, 100);
                DbInv.DeleteAllEmptyDrafts();
                //DbInv.Rebuild();
                DbInv.InsureIndexes();
                Console.Beep(1000, 100);
                Console.Beep(1000, 100);
            }


        }


        private void AddDraftInvoices()
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
            }
        }

        private void RadioChecked(int day)
        {
            PrintedInvoices.Controls.Clear();
            if (day == 100)
            {
                radioChecked = day;




                var List = DbInv.GetSavedInvoices();
                if (List.Count != 0)
                {
                    foreach (var item in List)
                    {

                        _InvBTN PrintedBTN = new _InvBTN(item);
                        int ID = item.ID;
                        PrintedBTN.Tag = ID;
                        PrintedBTN.Click += HeldOrder_click;
                        PrintedBTN.MouseUp += HeldOrder_MouseUp;
                        PrintedBTN.Name = item.ID.ToString();
                        PrintedInvoices.Controls.Add(PrintedBTN);

                    }
                }
                else return;

            }
            else
            {
                radioChecked = day;

                {
                    var List = DbInv.GetPrintedInvoices();
                    if (List.Count != 0)
                    {
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
                    }

                }


            }

        }


        private void Orders_Load(object sender, EventArgs e)
        {
            NewBTN_Click(null, null);
            if (Properties.Settings.Default.showMenu)
            {
                changeMenu.Enabled = true;
                langCheck.Enabled = true;
            }
            else
            {
                changeMenu.Enabled = false;
                langCheck.Enabled = false;
            }

            //ProcessStartInfo processInfo = new ProcessStartInfo("C:\\Users\\Admin\\source\\repos\\nabkawe\\OrderForm\\NetworkSynq\\bin\\Debug\\net6.0\\NetworkSynq.exe", "");
            //processInfo.CreateNoWindow = true;
            //processInfo.UseShellExecute = false;
            //Process.Start(processInfo);
        }
        private void TimeButton_Click(object sender, EventArgs e)
        {
            Custom_Classes.CreateOffer.CreateOfferNow(PrintNewInvoice(), true);
            Console.Beep(1000, 300);
        }
        private void CopyInvoice_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                this.DragDropImage();
        }

        private void DragDropImage()
        {
            var filename = "drag.png";
            var path = Path.Combine(Path.GetTempPath(), filename);
            Custom_Classes.CreateOffer.CreateOfferNow(PrintNewInvoice(), true).Save(path);
            var paths = new[] { path };
            try
            {
                this.CopyInvoice.DoDragDrop(new System.Windows.Forms.DataObject(DataFormats.FileDrop, paths), DragDropEffects.Copy);
            }
            catch (Exception)
            {

                return;
            }


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

            this.Activate();
            var SaveToPOS = PrintNewInvoice();

            if (ModifierKeys.HasFlag(Keys.Control))
            {
                DbInv.UpdatePreparingInvoice(SaveToPOS);
                Save2POS(SaveToPOS);
                return;

            }
            else
            {
                if (SaveToPOS.OrderType != "تطبيقات")
                {
                    if (!PrintSave.Enabled)
                    {
                        if (repeatedBehavior.AreYouSure("تم تخزين الفاتورة من قبل هل تريد تخزينها مجددا؟", "هل فشلت عملية التخزين؟"))
                        {
                            if (IsItPrinted && SaveToPOS.Equal(DbInv.GetInvoiceByID(SaveToPOS.ID)))
                            {
                                Save2POS(SaveToPOS);
                                return;
                            }
                            else if (IsItPrinted && !SaveToPOS.Equal(DbInv.GetInvoiceByID(SaveToPOS.ID)))
                            {
                                DialogResult dialogResult = MessageBox.Show("هل تريد إعادة الطباعة؟", "تم تعديل الفاتورة", MessageBoxButtons.YesNo);
                                if (dialogResult == DialogResult.Yes)
                                {

                                    PrintSave_Click(sender, null);
                                    Save2POS(SaveToPOS);
                                    return;
                                }
                                else if (dialogResult == DialogResult.No)
                                {

                                    Save2POS(SaveToPOS);
                                    return;
                                }

                            }
                            else
                            {
                                PrintSave_Click(sender, null);
                                Save2POS(SaveToPOS);
                                return;

                            }
                        }
                    }
                    else
                    {
                        if (IsItPrinted && SaveToPOS.Equal(DbInv.GetInvoiceByID(SaveToPOS.ID)))
                        {
                            Save2POS(SaveToPOS);
                            return;
                        }
                        else if (IsItPrinted && !SaveToPOS.Equal(DbInv.GetInvoiceByID(SaveToPOS.ID)))
                        {
                            DialogResult dialogResult = MessageBox.Show("هل تريد إعادة الطباعة؟", "تم تعديل الفاتورة", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {

                                PrintSave_Click(sender, null);
                                Save2POS(SaveToPOS);
                                return;
                            }
                            else if (dialogResult == DialogResult.No)
                            {

                                Save2POS(SaveToPOS);
                                return;
                            }

                        }
                        else
                        {
                            PrintSave_Click(sender, null);
                            Save2POS(SaveToPOS);
                            return;
                        }
                    }
                }
                else
                {
                    if (repeatedBehavior.AreYouSure("هل قمت بتسليم الطلب للمندوب؟", "تأكيد تسليم الفاتورة"))
                    {
                        SaveToPOS.Status = InvStat.SavedToPOS;
                        SaveToPOS.POSInvoiceNumber = "جاهز";
                        DbInv.CreateAppOrder(SaveToPOS);
                        return;

                    }
                    else return;

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
            a.Owner = this;
            ShowMenuBTN.BackColor = Color.AliceBlue;
            if (a.ShowDialog() == DialogResult.OK)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                NewBTN_Click(null, null);
                this.Activate();
                return;

            }
            else
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;

                HeldOrder_click(canceled, null);
                this.Activate();
                return;






            }


        }

        public CheckBox ParentCheckBox
        {
            get { return this.checkBox1; }
        }



        private void FastComment_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            FastComment.Items.Clear();

        }

        private void label7_Click(object sender, EventArgs e)
        {
            dvItems.Focus();
            SendKeys.Send("{PGDN}");

        }

        private void Label5_Click(object sender, EventArgs e)
        {
            dvItems.Focus();
            SendKeys.Send("{PGUP}");


        }

        private void GroupSave_CheckedChanged(object sender, EventArgs e)
        {
            if (GroupSave.Checked)
            {
                label8.Visible = true;
                SaveAllJahez.Visible = false;
            }
            else
            {
                SaveAllJahez.Visible = true;
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
                                OrdersPage_Click(null, null);

                            }
                        }

                    }

                }
            }

        }

        private void Orders_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DbInv.UpdateDraftInvoice(Convert.ToInt32(InvoiceNumberID.Text), false);
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

            }
        }

        private void NameTB_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text, true))
            {
                e.Effect = DragDropEffects.Copy;
            }

        }





        private void HoldInvoice_click(object sender, EventArgs e)
        {
            UpdatedDraft?.Invoke(this, null);
            if (POS.Count() > 0 || NameTB.Text != "" || MobileTB.Text != "")
            {
                POS.Clear();
                NewBTN_Click(null, null);
            }


        }

        #region Show Offer
        public static bool MenuShowing = false;

        #endregion

        private void unfocusableButton1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(MobileTB.Text);
        }

        private void unfocusableButton2_Click(object sender, EventArgs e)
        {
            MobileTB.Text = System.Windows.Forms.Clipboard.GetText(TextDataFormat.Text);
        }
        public static MainWindow DM = new MainWindow();


        public bool DMShown = false;

        private void ShowMenuBTN_Click(object sender, EventArgs e)
        {
            if (POS.Count() > 0)
            {

                if (Screen.AllScreens.Count() > 1)
                {
                    try
                    {
                        if (!MenuShowing)
                        {

                            displayOffer.showme(this.NameTB.Text, this.MobileTB.Text, this.TimeInfo.Text + " | " + this.DayMenuBTN.Text);

                            this.Activate();
                            ShowMenuBTN.BackColor = Color.Lime;
                        }
                        else { displayOffer.CloseNow(); ShowMenuBTN.BackColor = Color.AliceBlue; }
                    }
                    catch (Exception)
                    {


                    }



                }
                else Custom_Classes.CreateOffer.CreateOfferNow(PrintNewInvoice(), true);
            }
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
            if (a != null)
            {
                await DM.LaunchMenu(MenuDB.GetMenuItems(a), a, langCheck.Checked, Properties.Settings.Default.ItemSize);
            }
        }

        private void unfocusableButton3_Click(object sender, EventArgs e)
        {

            if (Screen.AllScreens.Count() > 1)
            {

                if (DM.Visibility != System.Windows.Visibility.Visible)
                {
                    DM.Show();
                    _ = DM.LaunchMenu(MenuDB.GetMenuItems(MenuDB.GetMenus().First()), MenuDB.GetMenus().First(), langCheck.Checked, Properties.Settings.Default.ItemSize);

                }
                else MenuSelection.Show(Cursor.Position);

            }

        }

        private void MenuTimeOut_Tick(object sender, EventArgs e)
        {
            _ = DM.LaunchMenu(MenuDB.GetMenuItems(MenuDB.GetMenus().First()), MenuDB.GetMenus().First(), langCheck.Checked, Properties.Settings.Default.ItemSize);
            MenuTimeOut.Stop();

        }

        private void AsrLBL_Click(object sender, EventArgs e)
        {

        }

        private void ItemNameTag_Click(object sender, EventArgs e)
        {
            //string text = "هل تريد تغيير حالة المادة؟" + Environment.NewLine + "Yes المادة متوفرة" + Environment.NewLine + " No المادة غير متوفرة";
            //DialogResult dialogResult = MessageBox.Show(text, "تعدل حالة توفر المادة", MessageBoxButtons.YesNo);
            //var s = (ToolStripMenuItem)sender;
            //var item = (POSItems)s.GetCurrentParent().Tag;

            //if (dialogResult == DialogResult.Yes)
            //{
            //    dbQ.MatAvailableSet(item.Barcode, true);
            //}
            //else dbQ.MatAvailableSet(item.Barcode, false);

            /////////// To Be Programmed.
        }

        private void RepeatOrder_Click(object sender, EventArgs e)
        {
            List<POSItems> NewPrices = new List<POSItems>();

            foreach (var i in POS)
            {
                var a = ItemsLists.First(x => x.Barcode == i.Barcode);
                a.Quantity = i.Quantity;
                a.Comment = i.Comment;
                NewPrices.Add(a);
            }
            NameTB.Text += " ";
            MobileTB.Text += " ";
            string name = " " + NameTB.Text;
            string number = MobileTB.Text;

            NewBTN_Click(null, null);
            NewPrices.ForEach(x => POS.Add(x));
            NewPrices.Clear();
            DialogResult dialogResult = MessageBox.Show("هل تريد إستخدام الإسم والرقم؟", "هل الطلب لنفس العميل؟", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                NameTB.Text = name;
                MobileTB.Text = number;
            }


        }

        private void LastOrder_Click(object sender, EventArgs e)
        {

            LastOrder.Visible = false;
            this.panel1.Visible = true;
            this.splitContainer1.Visible = true;
            this.HeldPanel.Controls.Clear();
            History.Checked = true;
            this.SearchTB.Text = MobileTB.Text;
            Search_Click(null, null);
            // AddDraftInvoices(); 




        }

        private void dvItems_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        private void DvItems_DragDrop(object sender, DragEventArgs e)
        {


            string JahezParser = "";
            JahezParser = e.Data.GetData(DataFormats.UnicodeText).ToString().Replace("x", "");
            if (JahezParser.Contains("Order"))
            {
                POS.Clear();
                String MatParser = "";
                if (JahezParser.Contains("Order"))
                {
                    Regex JOrderID = new Regex(@"Order#\s*\d*");
                    if (JOrderID.Match(JahezParser).Success)
                    {
                        NameTB.Text = "جاهز" + JOrderID.Match(JahezParser).Value.ToString().Replace("Order#", "");
                    }
                    //if (JahezParser.Split('\u000a')[0].Count() > 0)
                    //{

                    //    NameTB.Text = "جاهز" + JahezParser.Split('\u000a')[0].Replace("Order", "");
                    //}
                    //else NameTB.Text = "جاهز" + JahezParser.Split('\u000a')[1].Replace("Order", "");

                    foreach (string s in JahezParser.Split('\u000a'))
                    {
                        if (s.StartsWith("Comment:"))
                        {
                            CommentTB.Text = s.Split(':')[1];
                        }
                        if (s.StartsWith("Grand Total:\t"))
                        {
                            jahezPrice.Text = s.Split('\t')[1];
                        }
                        if (s.Contains("\""))
                        {
                            var start = s.IndexOf("\"") + 1;//add one to not include quote
                            var end = s.LastIndexOf("\"") - start;
                            var result = s.Substring(start, end);
                            MatParser += Environment.NewLine + "*" + result;
                        }
                        if (s.Contains('\u0009'))
                        {

                            MatParser += Environment.NewLine + s.Split('\u0009')[0];
                        }
                        MatParser = MatParser.Replace("Total", "");
                        MatParser = MatParser.Replace("Grand ", "");
                        MatParser = MatParser.Replace("Discount", "");
                        MatParser = MatParser.Replace("Product", "");
                        MatParser = MatParser.Replace(":", "");
                        MatParser = Regex.Replace(MatParser, @"^\s+$[\r\n]*", string.Empty, RegexOptions.Multiline);
                    }

                    try
                    {

                        for (int i = 1; i < MatParser.Split('*').Count() + 1; i++)
                        {
                            string JahezBarcode = MatParser.Split('*')[i].Split('\u000a')[0];
                            string JahezQuantity = MatParser.Split('*')[i].Split('\u000a')[1];
                            JahezBarcode = JahezBarcode.Replace('\r', ' ').Replace(" ", "");
                            JahezQuantity = JahezQuantity.Replace('\r', ' ').Replace(" ", "");

                            var Item = ItemsLists.First(x => x.Barcode == JahezBarcode);
                            if (Item != null)
                            {
                                Item.Quantity = Convert.ToInt32(JahezQuantity);
                                Item.Comment = "";
                                POSItems New = new POSItems();
                                New.Name = Item.Name;
                                New.Quantity = Item.Quantity;
                                New.Price = Item.Price;
                                New.PrinterName = Item.PrinterName;
                                Item.printerlist.ForEach(x => New.printerlist.Add(x));
                                New.realquan = Item.realquan;
                                New.Barcode = Item.Barcode;
                                New.ID = Item.ID;
                                New.Parent = Item.Parent;
                                New.Available = Item.Available;

                                POS.Add(New);

                            }
                        }
                    }
                    catch (Exception)
                    {
                        //JahezBarcode = JahezBarcode.Remove(JahezBarcode.Length - 2, JahezBarcode.Length);
                        //JahezQuantity = JahezQuantity.Remove(JahezQuantity.Length - 2, JahezQuantity.Length);
                    }
                    OrderStatus.Text = "تطبيقات";
                }
            }
            else if (JahezParser.Contains("(estimated)") || JahezParser.Contains("ر.س"))
            {
                string whatsappParser = "";
                whatsappParser = e.Data.GetData(DataFormats.UnicodeText).ToString();


                POS.Clear();
                String MatParser = "";
                {

                    foreach (string s in whatsappParser.Split('\u000a'))
                    {

                        if (s.Contains("\""))
                        {
                            var start = s.IndexOf("\"") + 1;//add one to not include quote
                            var end = s.LastIndexOf("\"") - start;
                            var result = s.Substring(start, end);
                            MatParser += Environment.NewLine + "*" + result;
                        }
                        if (s.Contains('•'))
                        {

                            MatParser += Environment.NewLine + s.Split('•')[1].Replace("Quantity ", "").Replace("الكمية ", "");
                        }

                    }

                    try
                    {

                        for (int i = 1; i < MatParser.Split('*').Count() + 1; i++)
                        {
                            string WhatsBarcode = MatParser.Split('*')[i].Split('\u000a')[0];
                            string WhatsQuantity = MatParser.Split('*')[i].Split('\u000a')[1];
                            WhatsBarcode = WhatsBarcode.Replace('\r', ' ').Replace(" ", "");
                            WhatsQuantity = WhatsQuantity.Replace('\r', ' ').Replace(" ", "");

                            var Item = ItemsLists.First(x => x.Barcode == WhatsBarcode);
                            if (Item != null)
                            {
                                Item.Quantity = Convert.ToInt32(WhatsQuantity);
                                Item.Comment = "";
                                POSItems New = new POSItems();
                                New.Name = Item.Name;
                                New.Quantity = Item.Quantity;
                                New.Price = Item.Price;
                                New.PrinterName = Item.PrinterName;
                                Item.printerlist.ForEach(x => New.printerlist.Add(x));
                                New.realquan = Item.realquan;
                                New.Barcode = Item.Barcode;
                                New.ID = Item.ID;
                                New.Parent = Item.Parent;
                                New.Available = Item.Available;
                                POS.Add(New);
                            }

                        }
                    }


                    catch (Exception)
                    {
                        //JahezBarcode = JahezBarcode.Remove(JahezBarcode.Length - 2, JahezBarcode.Length);
                        //JahezQuantity = JahezQuantity.Remove(JahezQuantity.Length - 2, JahezQuantity.Length);
                    }

                    string price = whatsappParser.Split('\u000a')[2].
                        Replace(" ر.س.‏", "").Replace("(estimated)", "").Replace("SAR", "").Replace("(المبلغ المُقدَّر)", "").Replace('٫', '.').Replace(" ", "").Replace("٠", "0").Replace("١", "1").Replace("٢", "2").Replace("٣", "3").Replace("٤", "4").Replace("٥", "5").Replace("٦", "6").Replace("٧", "7").Replace("٨", "8").Replace("٩", "9");
                    string price1 = whatsappParser.Split('\u000a')[1].
                        Replace(" ر.س.‏", "").Replace("(estimated)", "").Replace("SAR", "").Replace("(المبلغ المُقدَّر)", "").Replace('٫', '.').Replace(" ", "").Replace("٠", "0").Replace("١", "1").Replace("٢", "2").Replace("٣", "3").Replace("٤", "4").Replace("٥", "5").Replace("٦", "6").Replace("٧", "7").Replace("٨", "8").Replace("٩", "9");
                    string price0 = whatsappParser.Split('\u000a')[0].
                        Replace(" ر.س.‏", "").Replace("(estimated)", "").Replace("SAR", "").Replace("(المبلغ المُقدَّر)", "").Replace('٫', '.').Replace(" ", "").Replace("٠", "0").Replace("١", "1").Replace("٢", "2").Replace("٣", "3").Replace("٤", "4").Replace("٥", "5").Replace("٦", "6").Replace("٧", "7").Replace("٨", "8").Replace("٩", "9");
                    if (ModifierKeys.HasFlag(Keys.Control))
                    {
                        MessageBox.Show(price + " " + price0 + " " + price1);
                    }

                    decimal due = Convert.ToDecimal(AmountLBL.Text);
                    try
                    {
                        if (due != decimal.Parse(price))
                        {
                            MessageBox.Show("لم يتطابق سعر الفاتورة مع الواتسآب الرجاء التأكد من نسخ كامل الفاتورة");
                        }
                    }
                    catch (System.FormatException)
                    {
                        try
                        {
                            if (due != decimal.Parse(price1))
                            {
                                MessageBox.Show("لم يتطابق سعر الفاتورة مع الواتسآب الرجاء التأكد من نسخ كامل الفاتورة");
                            }

                        }
                        catch (System.FormatException)
                        {
                            try
                            {
                                if (due != decimal.Parse(price0))
                                {
                                    MessageBox.Show("لم يتطابق سعر الفاتورة مع الواتسآب الرجاء التأكد من نسخ كامل الفاتورة");
                                }
                            }
                            catch (System.FormatException)
                            {

                                MessageBox.Show("قم بنسخ الفاتورة بدأ من سطر سعر الفاتورة ليتم مقارنة السعر بالمدخلات");

                            }
                        }

                    }




                }
            }

        }

        private void Search_Click(object sender, EventArgs e)
        {
            if (SearchTB.Text.Replace(" ", "") != "" && SearchTB.Text.Length > 1)
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
                    if (List.Count > 0)
                    {
                        foreach (var item in List)
                        {
                            if (item.SearchResult.Contains(SearchTB.Text))
                            {
                                _InvBTN PrintedBTN = new _InvBTN(item);
                                int ID = item.ID;
                                PrintedBTN.Tag = ID;
                                PrintedBTN.Click += HeldOrder_click;
                                PrintedBTN.MouseUp += HeldOrder_MouseUp;
                                PrintedInvoices.Controls.Add(PrintedBTN);
                            }
                        }
                    }
                }
            }
        }

        private void SearchTB_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search_Click(null, null);
            }

        }

        private void OrderCut_Click(object sender, EventArgs e)
        {
            var se = sender as Button;
            CommentTB.Text += se.Text;
        }

        private void unfocusableButton5_Click(object sender, EventArgs e)
        {

        }

        private void unfocusableButton5_Click_1(object sender, EventArgs e)
        {
            this.HeldPanel.Controls.Clear();

            AddDraftInvoices();
        }

        private void xLabel_Click(object sender, EventArgs e)
        {
            TimeTB.Clear();
        }

        private void SaveInvoice_MouseLeave(object sender, EventArgs e)
        {
            MobileTB.Focus();

        }

        private void PrintSave_MouseLeave(object sender, EventArgs e)
        {
            MobileTB.Focus();

        }

        private void panel1_VisibleChanged(object sender, EventArgs e)
        {
            if (!panel1.Visible)
            {
                this.splitContainer1.Visible = false;
            }
            else { this.splitContainer1.Visible = true; }


        }



        private void TimeTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ':') { e.Handled = true; }

        }


        private void WhatAppBTN_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && ModifierKeys.HasFlag(Keys.Control))
            {
                var note = new WhatsNotesForm();

                note.Show();

            }
            else if (e.Button == MouseButtons.Right)
            {
                var WhatsAppList = dbQ.GetAllShortcuts();
                if (WhatsAppList.Count > 0)
                {
                    WhatsSend.Items.Clear();
                    WhatsSend.Items.Add("نسخ وإرسال الفاتورة");
                    WhatsAppList.ForEach(x => WhatsSend.Items.Add(x.Shortcut));
                    WhatsSend.Show(Cursor.Position);
                }


            }
            else if (e.Button == MouseButtons.Left)
            {
                if (!ModifierKeys.HasFlag(Keys.Control))
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
                            Process.Start("whatsapp://send/?phone=" + "966" + this.MobileTB.Text);
                        }

                    }
                }
                else
                {
                    if (MobileTB.Text != "")
                    {
                        var num = this.MobileTB.Text;
                        //var numbersyntax = "(05)([0-9]{8})|5([0-9]{8})";
                        var numbersyntax = @"(05)([0-9]{8})|5([0-9]{8})|\+([0-9]{12})|00([0-9]{12})|\+([0-9]{11})|00([0-9]{11})";
                        Regex rgx = new Regex(numbersyntax);
                        Match numbermatch = rgx.Match(num);
                        this.MobileTB.Text = numbermatch.Value.ToString();
                        if (this.MobileTB.Text.StartsWith("00") == true | this.MobileTB.Text.StartsWith("+") == true) Process.Start("https://wa.me/" + this.MobileTB.Text + "?text=" + "/");
                        else
                        {
                            Process.Start("https://wa.me/" + "966" + this.MobileTB.Text);
                        }

                    }
                }
            }
        }
        private void WhatsSend_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text != "نسخ وإرسال الفاتورة")
            {
                if (MobileTB.Text != "")
                {
                    string details = dbQ.GetAllShortcuts().Where(x => x.Shortcut == e.ClickedItem.Text).First().Details;
                    string newdetails = details.Replace(" ", "%20").Replace("\n", "%0a");
                    string url = "whatsapp://send/?phone=" + "966" + this.MobileTB.Text;

                    url = "whatsapp://send/?phone=" + "966" + this.MobileTB.Text + "&text=" + newdetails;
                    Process.Start(url);

                    Thread.Sleep(1000);

                    SendKeys.Send("{Enter}");

                }

            }
            else
            {
                if (MobileTB.Text != "")
                {

                    Custom_Classes.CreateOffer.CreateOfferNow(PrintNewInvoice(), true);
                    Console.Beep(1000, 100);
                    string url = "whatsapp://send/?phone=" + "966" + this.MobileTB.Text + "&text= ";
                    Process.Start(url);
                    Process.Start(url);
                    InputLanguage.CurrentInputLanguage =
          InputLanguage.FromCulture(new System.Globalization.CultureInfo("En-US"));

                    SendKeys.Send("^{V}");
                    InputLanguage.CurrentInputLanguage =
        InputLanguage.FromCulture(new System.Globalization.CultureInfo("Ar-SA"));
                }
            }


        }

        private void HeldPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TelButton_Click_1(object sender, EventArgs e)
        {
            var se = sender as ToolStripButton;
            foreach (ToolStripButton btn in InvoiceTypeOptions.Items)
            {
                btn.Checked = false;
            }
            se.Checked = true;
            OrderStatus.Text = se.Text;

        }


        private void SaveAllJahez_Click(object sender, EventArgs e)
        {
            if (!History.Checked)
            {
                if (repeatedBehavior.AreYouSure("هل تريد تخزين كل فواتير جاهز", ""))
                {
                    List<int> removelist = new List<int>();

                    for (int i = 0; i < PrintedInvoices.Controls.Count; i++)
                    {
                        if (PrintedInvoices.Controls[i].GetType() == typeof(_InvBTN))
                        {
                            _InvBTN btn = PrintedInvoices.Controls[i] as _InvBTN;
                            int id = (int)btn.Tag;
                            var inv = DbInv.GetInvoiceByID(id);
                            if (inv.OrderType == "تطبيقات")
                            {
                                inv.Status = InvStat.SavedToPOS;
                                inv.POSInvoiceNumber = "جاهز";
                                DbInv.CreateAppOrder(inv);
                                removelist.Add(i);
                            }


                        }


                    }


                    removelist.Reverse();
                    removelist.ForEach(x => PrintedInvoices.Controls.RemoveAt(x));


                }
            }
        }

        private void DateLBL_Click(object sender, EventArgs e)
        {
            if (Control.ModifierKeys.HasFlag(Keys.Control))
            {
                var myReport = new MyReport();
                myReport.Show();
            }
        }

        private void PrintedInvoices_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DayLBL_Click(object sender, EventArgs e)
        {
            if (ModifierKeys.HasFlag(Keys.Control))
            {
                MyMatReport m = new MyMatReport();
                m.Show();
            }
        }

        private void Api_Health_Tick(object sender, EventArgs e)
        {
            if (APIAccess)
            {
                if (!DbInv.AreYouAlive())
                {
                    this.Text = Title + " *** Failed to Connect to API";
                }
                else
                {
                    this.Text = Title + "API Mode Connected " + DateTime.Now.ToString("HH:mm:ss");
                }
            }
        }

        private void langCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (DM.Visibility != System.Windows.Visibility.Visible)
            {
                try
                {
                    DM.Show();
                    _ = DM.LaunchMenu(MenuDB.GetMenuItems(MenuDB.GetMenus().First()), MenuDB.GetMenus().First(), langCheck.Checked, Properties.Settings.Default.ItemSize);

                }
                catch (Exception)
                {

                }
            }
            else
            {
                _ = DM.LaunchMenu(MenuDB.GetMenuItems(MenuDB.GetMenus().First()), MenuDB.GetMenus().First(), langCheck.Checked, Properties.Settings.Default.ItemSize);
            }
        }

        private void SaveAllJahez_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                
                var menu = new ContextMenu();
                
                DbInv.GetSavedInvoices().Where(x => x.OrderType == "تطبيقات").Take(10).ToList().ForEach(x => menu.MenuItems.Add(x.CustomerName) );
                
                menu.Show(SaveAllJahez,new Point(0,0));    
            }
        }
    }

}