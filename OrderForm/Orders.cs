using LiteDB;
using PrayerTimes;
using RestSharp;
using sharedCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Color = System.Drawing.Color;
using DataFormat = RestSharp.DataFormat;
using DataFormats = System.Windows.Forms.DataFormats;
using DragDropEffects = System.Windows.Forms.DragDropEffects;
using DragEventArgs = System.Windows.Forms.DragEventArgs;
using MessageBox = System.Windows.Forms.MessageBox;
using Point = System.Drawing.Point;
using TextDataFormat = System.Windows.Forms.TextDataFormat;
using OrderForm.SavingandPayment;
using static System.Windows.Forms.DataFormats;
using Application = System.Windows.Forms.Application;
using System.Text;
using System.Drawing;
using Newtonsoft.Json.Linq;
using System.Runtime.Remoting.Contexts;
using Windows.ApplicationModel.DataTransfer;
using System.Windows.Markup;
using System.Diagnostics.Eventing.Reader;
using Windows.UI.Notifications;
using Clipboard = Windows.ApplicationModel.Background;
using System.Windows;
using System.Windows.Media.Animation;

namespace OrderForm
{


    public partial class Orders : Form
    {

        public string APIConnection { get { return Properties.Settings.Default.API_Connection; } set { Properties.Settings.Default.API_Connection = value; } }
        public static bool servermode { get; set; }
        public bool APIAccess { get { return Properties.Settings.Default.Api_On; } set { Properties.Settings.Default.Api_On = value; } }

        public Invoice CurrentInvoice;

        public static BindingList<POSItems> POS = new BindingList<POSItems>();

        public event EventHandler<string> UpdatedDraft;

        public static List<POSItems> ItemsLists = new List<POSItems>();

        private List<string> MinutesList()
        {
            return new List<string>() { "00", "05", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55" };
        }
        private List<string> HoursList()
        {
            return new List<string>() { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" };
        }
        private List<string> TODList()
        {
            return new List<string>() { "صباحا", "ظهرا", "عصرا", "مساء", "ليلا" };
        }

        public static bool IsItPrinted { get; set; } = false;
        public bool AddingInProgress { get; set; } = false;
        public static Invoice globalInvoice { get; set; } = null;
        public int radioChecked { get; set; } = 0;
        string Title { get; set; } = "برنامج تسجيل طلبات ليبرا + ";

        #region Form and Loading Region
        public static CheckBox MyCheckBox { get; set; }
        public static void KillandRestartAPI()
        {
            if (Process.GetProcessesByName("NetworkSynq").Length == 0)
            {
                foreach (var process in Process.GetProcessesByName("NetworkSynq"))
                {
                    process.Kill();
                }

                ProcessStartInfo processInfo = new ProcessStartInfo(Application.StartupPath + @"\API\NetworkSynq.exe", "");
                processInfo.WorkingDirectory = Application.StartupPath + @"\API\";
                processInfo.CreateNoWindow = true;
                processInfo.UseShellExecute = false;
                Process.Start(processInfo);
                Thread.Sleep(3000);
            }
        }
        public Orders()
        {
            InitializeComponent();

        }




        #region Materials related logic

        #region loading materials

        public void CreateSectionBtns(FlowLayoutPanel FlowPanel, POSsections obj)
        {
            UButton Section = new UButton()
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
            UButton item = new UButton()
            {
                Name = obj.Barcode,
                Tag = obj.Barcode,
                Text = obj.Name,
                Height = 66,
                Width = 92,
                Margin = new Padding(1),
                BackgroundImageLayout = ImageLayout.Zoom
            };

            if (imgList.Images.ContainsKey(obj.Barcode))
            {
                item.BackgroundImage = imgList.Images[imgList.Images.IndexOfKey(obj.Barcode)];
            }
            else
            {
                string CacheImagesFolder = Path.Combine(Directory.GetCurrentDirectory() + "\\CacheImages\\");
                string CachedPhotoPath = Path.Combine(CacheImagesFolder + Path.GetFileName(obj.PicturePath));
                if (!Directory.Exists(CacheImagesFolder))
                {
                    Directory.CreateDirectory(CacheImagesFolder);
                }
                else
                {

                    if (CheckFile(CachedPhotoPath))
                    {

                        imgList.Images.Add(obj.Barcode, System.Drawing.Image.FromFile(CachedPhotoPath).GetThumbnailImage(50, 50, null, IntPtr.Zero));
                        item.BackgroundImage = imgList.Images[imgList.Images.Count - 1];
                    }
                    else
                    {
                        if (CheckFile(obj.PicturePath))
                        {
                            File.Copy(obj.PicturePath, CachedPhotoPath);
                            if (CheckFile(CachedPhotoPath))
                            {
                                imgList.Images.Add(obj.Barcode, System.Drawing.Image.FromFile(CachedPhotoPath).GetThumbnailImage(50, 50, null, IntPtr.Zero));
                                item.BackgroundImage = imgList.Images[imgList.Images.Count - 1];

                            }
                        }

                    }
                }
            }



            item.Click += new EventHandler(Item_Clicked);
            item.MouseWheel += new MouseEventHandler(Item_MouseWheel);
            item.MouseDown += new MouseEventHandler(Item_MouseDown);
            item.MouseEnter += Item_MouseEnter;
            item.MouseLeave += Item_MouseLeave; ;
            FlowPanel.Controls.Add(item);

        }



        private void Item_MouseLeave(object sender, EventArgs e)
        {
            var item = sender as UButton;
            if ((int)imgList.Images.IndexOfKey(item.Tag.ToString()) != -1)
            {
                item.BackgroundImage = imgList.Images[imgList.Images.IndexOfKey(item.Tag.ToString())];
            }
            item.Text = ItemsLists.First(x => x.Barcode == item.Tag.ToString()).Name;
        }
        private void Item_MouseEnter(object sender, EventArgs e)
        {
            var item = sender as UButton;
            item.BackgroundImage = null;
            item.Text = ItemsLists.First(x => x.Barcode == item.Tag.ToString()).Price.ToString() + Environment.NewLine + item.Text;



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
                var btn = (UButton)sender;
                if (Properties.Settings.Default.showMenu) { OrderForm.MainWindow.FindByBarcode((string)btn.Tag); }


                rightClickMenu.Show(Cursor.Position);
                rightClickMenu.Items[3].Text = ItemsLists.First(x => x.Barcode == btn.Tag.ToString()).Name;
                rightClickMenu.Items[2].Visible = false;
                rightClickMenu.Tag = (string)btn.Tag;
            }
        }

        private void Item_MouseWheel(object sender, MouseEventArgs e)
        {
            if (Properties.Settings.Default.WheelEnabled)
            {

                if (e.Delta > 0)
                {
                    var itembtn = (System.Windows.Forms.Button)sender;
                    var item = ItemsLists.First(x => x.Barcode == itembtn.Name);
                    AddtoGrid(item);
                }
                else
                {
                    var itembtn = (System.Windows.Forms.Button)sender;
                    var item = ItemsLists.First(x => x.Barcode == itembtn.Name);
                    EditItemGrid(item);
                }

            }

        }
        protected void Section_Clicked(object sender, EventArgs e)
        {
            var sectionbtn = (System.Windows.Forms.Button)sender;
            var section = (POSsections)sectionbtn.Tag;
            ItemsPanel1.Controls.Clear();
            var ind = SectionsPanel.Controls.GetChildIndex(sectionbtn);

            ItemsLists.ForEach(x => { if (section.Name == x.SectionName) CreateItemBtns(ItemsPanel1, x); });
            //dbQ.GetItemsForSection(section.Name).ForEach(x => CreateItemBtns(ItemsPanel1, x));
        }
        protected void Item_Clicked(object sender, EventArgs e)
        {
            var itembtn = (System.Windows.Forms.Button)sender;
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
                lists.Clear();
                try
                {
                    lists = dbQ.PopulateSections();
                }
                catch (System.Net.Http.HttpRequestException)
                {
                    if (Properties.Settings.Default.Api_Server)
                    {
                        if (repeatedBehavior.AreYouSure("لم يتم العثور على السيرفر، هل تريد الدخول في وضع الشبكة مؤقتا أم إعادة المحاولة؟ " + Environment.NewLine + "Yes = أعد المحاولة + No = إعتمد على الشبكة المحلية ", "فشلت عملية التزامن"))
                        { retryConnection(); }
                        else { /*APIAccess = false;*/ }
                    }
                    else
                    {
                        MessageBox.Show("تعذر الإتصال بالخادم", "خطأ بالإتصال");

                    }
                }



                SectionsPanel.Controls.Clear();

                int c = -1;
                lists.ForEach(l => { c += 1; CreateSectionBtns(SectionsPanel, l); dbQ.GetItemsForSection(l.Name).ForEach(i => ItemsLists.Add(i)); });
                ItemsPanel1.Controls.Clear();
                if (SectionsPanel.Controls.Count > 0) { Section_Clicked(SectionsPanel.Controls[0], null); }

            }
            catch (Exception)
            {
                Console.WriteLine("LoadMaterials Error.");
            }
        }

        private async void retryConnection()
        {

            if (!DbInv.AreYouAlive())
            {
                this.Focus();
                if (repeatedBehavior.AreYouSure("هل تريد إعادة تشغيل السيرفر؟" + Environment.NewLine + "Yes = إعادة تشغيل السيرفر + No = إعتمد على الشبكة المحلية ", "فشلت عملية التزامن"))
                {
                    KillandRestartAPI();

                }
                else { /*APIAccess = false*/; this.Text = "****Local Connection****"; }
            }

        }

        List<POSsections> lists = new List<POSsections>();
        List<POSItems> list = new List<POSItems>();

        private void LoadMethods()
        {
            //Properties.Settings.Default.DBConnection = "filename=c:\\db\\db.db;connection=shared";
            if (Properties.Settings.Default.showMenu &&
                Screen.AllScreens.Count() > 1 &&
                DM.Visibility != System.Windows.Visibility.Visible)
            {


                DM.Show();
                _ = DM.LaunchMenu(MenuDB.GetMenuItems(MenuDB.GetMenus().First()), MenuDB.GetMenus().First(), langCheck.Checked, Properties.Settings.Default.ItemSize);

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
        private void MobileTB_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (sender is Control ctrl)
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    SelectNextControl(ctrl, true, true, true, true);
                }
                else if (e.KeyCode == Keys.Up)
                {
                    SelectNextControl(ctrl, false, true, true, true);
                }

                if (e.KeyCode == Keys.Enter && Control.ModifierKeys == Keys.Control)
                {
                    var es = new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0);
                    WhatsAppBTN_Click(this, es);
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

        //private void InvoicesDG_MouseWheel(object sender, MouseEventArgs e)
        //{
        //    if (InvoicesDG.Rows.Count <= 0) return;
        //    if (e.Delta > 0 && InvoicesDG.FirstDisplayedScrollingRowIndex > 0)
        //    {
        //        InvoicesDG.FirstDisplayedScrollingRowIndex--;
        //    }
        //    else if (e.Delta < 0)
        //    {
        //        InvoicesDG.FirstDisplayedScrollingRowIndex++;
        //    }

        //    if (InvoicesDG.CurrentCell != null)
        //    {


        //        int currentIndex = InvoicesDG.CurrentCell.RowIndex;
        //        int newIndex = currentIndex - Math.Sign(e.Delta);
        //        if (newIndex >= 0 && newIndex < InvoicesDG.Rows.Count)
        //        {
        //            InvoicesDG.CurrentCell = InvoicesDG[0, newIndex];
        //        }
        //    }


        //}

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
                if (string.IsNullOrEmpty(tb.Text))
                {
                    tb.Text = "1";
                }
                e.Handled = true;
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
            var btn = (System.Windows.Forms.Button)sender;
            if (btn != null && dvItems.Rows.Count > 0)
            {
                var cell = dvItems.CurrentCell;
                if (!cell.IsInEditMode)
                {
                    dvItems.Focus();
                    foreach (DataGridViewRow row in dvItems.Rows)
                    {
                        if (row.Selected)
                        {
                            dvItems.CurrentCell = row.Cells[1];
                        }
                    }
                }
                string switchcase = btn.Name;
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

        private void SettingsPage_Click(object sender, EventArgs e)
        {
            if (ModifierKeys.HasFlag(Keys.Control))
            {
                string n = Environment.NewLine;
                MessageBox.Show(Application.ProductVersion + n + Properties.Settings.Default.API_Server_Path + n + Properties.Settings.Default.API_Connection);
            }
            else
            {
                if (Application.OpenForms.OfType<SettingsPage>().Any())
                {
                    Application.OpenForms.OfType<SettingsPage>().First().BringToFront();
                    Application.OpenForms.OfType<SettingsPage>().First().Activate();

                }
                else
                {
                    SettingsPage SettingsPage_ = new SettingsPage();
                    SettingsPage_.Show();
                }

            }
        }
        public static void SettingsClosed()
        {
            System.Windows.Forms.Application.Exit();

            //MyForm.SectionsPanel.Controls.Clear();
            //MyForm.ItemsPanel1.Controls.Clear();
            //MyForm.LoadMaterials();
            //if (Properties.Settings.Default.Api_On) MyForm.Text = "API Mode";
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
                    PNI.TimeOfPrinting = DateTime.Now.ToString("hh:mmtt dd/MM/yy");


                    DbInv.UpdatePreparingInvoice(PNI);

                    Custom_Classes.CreateOffer.CreateOfferNow(PrintNewInvoice(), true);
                    if (sender is null)
                    {
                        // do nothing;
                    }
                    else
                    {
                        NewBTN_Click(null, null);
                    }





                }
            }
        }
        #endregion


        private void NewBTN_Click(object sender, EventArgs e)
        {
            var se = sender;
            if (!IsItPrinted && POS.Count > 0 && se != null) { if (repeatedBehavior.AreYouSure("هل تريد حذف الفاتورة وبدء فاتورة جديدة؟", " تحذير الفاتورة غير مطبوعة")) Console.WriteLine("Yah"); else return; };
            try
            {
                IsItPrinted = false;
                ButtonStates(true);
                StopEditing = false;
                var draftInv = new Invoice
                {
                    Status = InvStat.Draft,
                    InEditMode = false,
                    OrderType = InvoiceTypeOptions.Items[Properties.Settings.Default.defaultOrder].Text,
                    InvoiceDay = GetWhatDay((int)DateTime.Now.DayOfWeek)
                };
                InvoiceNumberID.Text = DbInv.CreatePreparingInvoice(draftInv).Replace("\"", "");

                OrdersPanel.Enabled = true;
                AddingInProgress = true;
                POS.Clear();
                AddingInProgress = false;
                NameTB.Clear();
                MobileTB.Clear();
                TimeTB.Clear();
                DOWTB.Clear();
                CommentTB.Clear();
                TimeInfo.Text = "الآن";
                DayMenuBTN.Text = GetDayName((int)DateTime.Now.DayOfWeek);
                OrderStatus.Text = InvoiceTypeOptions.Items[Properties.Settings.Default.defaultOrder].Text;
                AmountLBL.Text = "0.00";
                HoldInvoice.Enabled = true;
                displayOffer.CloseNow();
                Refresh();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }



        }

        private void OrdersPage_Click(object sender, EventArgs e)
        {
            LoadOrders();



        }


        private void LoadOrders()
        {
            if (SearchTB.Text.Replace(" ", "") == "")
            {

                CheckDay();
            }

            this.OrdersFlowLayoutPanel.Visible = true; this.OrdersFlowLayoutPanel.BringToFront();
            this.OrdersContainer.Visible = true; this.OrdersContainer.BringToFront();
            this.OrdersPanel.Visible = false;
            LastOrder.Visible = false;
            EditName.Visible = false;
            GridUIPrinted();

        }

        private void CheckDay()
        {

            var days = DateTime.Now.DayOfWeek;

            radioButtons()[days].Checked = true;
            Fri_CheckedChanged(radioButtons()[days], null);
        }
        private Dictionary<DayOfWeek, RadioButton> radioButtons()
        {
            return new Dictionary<DayOfWeek, RadioButton>()
            {
                { DayOfWeek.Saturday, Sat },
                { DayOfWeek.Sunday, Sun },
                { DayOfWeek.Monday, Mon },
                { DayOfWeek.Tuesday, Tue },
                { DayOfWeek.Wednesday, Wed },
                { DayOfWeek.Thursday, Thu },
                { DayOfWeek.Friday, Fri }
            };
        }

        private void Fri_CheckedChanged(object sender, EventArgs e)
        {
            var se = sender as RadioButton;
            if (se.Checked)
            {
                CustomDaysOfWeek daysOfWeek;
                if (Enum.TryParse(se.Name, out daysOfWeek))
                {
                    RadioChecked((int)daysOfWeek);
                }
            }


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
            History = 100,
            Draft = -2
        }

        private void switchCase(string se)
        {

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
        private PaymentOptions NewPayForm(Invoice invoice)
        {
            return new SavingandPayment.PaymentOptions(invoice);

        }


        public void LoadInvoiceUI(Invoice heldInv)
        {

            if (heldInv.Status == InvStat.Draft)
            {

                IsItPrinted = false;
                HoldInvoice.Enabled = true;
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
                //this.panel1.Visible = false;
                this.OrdersContainer.Visible = false;
                this.OrdersPanel.Visible = true; this.OrdersPanel.BringToFront();


                return;
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
                this.OrdersContainer.Visible = false;
                this.OrdersPanel.Visible = true; this.OrdersPanel.BringToFront();
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
                    this.OrdersContainer.Visible = false;
                    this.OrdersPanel.Visible = true; this.OrdersPanel.BringToFront();
                    // create a tooltip to show on top of the button ShowMenuBTN
                    ToolTip tt = new ToolTip();
                    tt.UseAnimation = false; 
                    tt.UseFading = false;
                    tt.ToolTipTitle = "معلومات الطلب";
                    string msg = $"تم التخزين: {heldInv.TimeOfSaving} {Environment.NewLine} تمت الطباعة: {heldInv.TimeOfPrinting} {Environment.NewLine} وسيلة الدفع: {heldInv.PaymentName}";
                    tt.Show(msg, InvoiceNumberID, 5000);
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
                if (!string.IsNullOrEmpty(heldInv.OrderType)) OrderStatus.Text = heldInv.OrderType;
                else OrderStatus.Text = InvoiceTypeOptions.Items[Properties.Settings.Default.defaultOrder].Text;
                this.OrdersContainer.Visible = false;
                this.OrdersPanel.Visible = true; this.OrdersPanel.BringToFront();
                FillPOS(heldInv.InvoiceItems);
            }
            IsItPrinted = true;
            HoldInvoice.Enabled = false;

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
                EditName.Visible = false;


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
            foreach (var item in HoursList())
            {
                HourPicker.Items.Add(item.ToString());
                HourPicker.Show(TimeInfo, 0, 0);
            }
        }

        private void TimeTB_TextChanged(object sender, EventArgs e)
        {
            //TimeTB.Text= TimeTB.Text.Replace(":", "");
            TimeTB.MaxLength = 5;
            TimeInfo.Text = TimeParse.T(TimeTB.Text);
            if (string.IsNullOrWhiteSpace(TimeTB.Text)) TimeInfo.Text = "الآن";
            SendKeys.Send("{END}");

        }


        private void DayBTN_Click(object sender, EventArgs e)
        {
            int day = (int)DateTime.Now.DayOfWeek;
            string[] days = new string[] { "الأحد", "الإثنين", "الثلاثاء", "الأربعاء", "الخميس", "الجمعة", "السبت" };
            ToolStripItem[] dayItems = new ToolStripItem[days.Length];
            for (int i = 0; i < days.Length; i++)
            {
                dayItems[i] = new ToolStripMenuItem(days[i]);
            }

            DayMenu.Items.Clear();
            DayMenu.Items.AddRange(dayItems);
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

            foreach (var item in MinutesList())
            {
                MinutesPicker.Items.Add(item.ToString());
                MinutesPicker.Show(TimeInfo, 0, 0);

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
            }
            TODPicker.Show(TimeInfo, 0, 0);

        }


        private List<string> GetNewTODlist(string a)
        {
            List<string> asr = new List<string>() { "عصرا" };
            List<string> evening = new List<string>() { "مساء" };
            List<string> morningEvening = new List<string>() { "صباحا", "مساء" };
            List<string> morningNight = new List<string>() { "صباحا", "ليلا" };
            List<string> duhrNight = new List<string>() { "ظهرا", "ليلا" };

            switch (a)
            {
                case "1":
                    if (TimeInfo.Text[1] == '1' && TimeInfo.Text[2] == ':')
                    {
                        return morningNight;
                    }
                    else if (TimeInfo.Text[1] == '0' && TimeInfo.Text[2] == ':')
                    {
                        return morningNight;
                    }
                    else
                    {
                        return duhrNight;
                    }
                case "2":
                    return duhrNight;
                case "3":
                    return asr;
                case "4":
                case "5":
                case "6":
                    return evening;
                case "7":
                    return morningEvening;
                case "8":
                case "9":
                    return morningNight;
                default:
                    return TODList();
            }
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
                            if (sender.GetType() == typeof(TextBox))
                            {
                                var tb = (TextBox)sender;
                                TODPicker.Show(tb, 0, 0);
                            }
                            else
                            {
                                var tb = (Button)sender;
                                TODPicker.Show(tb, 0, 0);
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
            this.DOWTB.Clear();
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
                var send = sender as UButton;
                var sect = send.Tag as POSsections;
                NotesForm notes = new NotesForm(sect);
                notes.Show();
            }
        }



        private void NameTB_Enter(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(MobileTB.Text) && string.IsNullOrWhiteSpace(NameTB.Text))
            {
                var con = dbQ.LoadContacts(MobileTB.Text);

                LastOrder.Visible = true;
                EditName.Tag = con;
                EditName.Visible = true;

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
            MobileLBL.Visible = string.IsNullOrWhiteSpace(MobileTB.Text);
            NameLBL.Visible = string.IsNullOrWhiteSpace(NameTB.Text);
            label1.Visible = string.IsNullOrWhiteSpace(TimeTB.Text);
            label3.Visible = string.IsNullOrWhiteSpace(DOWTB.Text);
            CommentLBL.Visible = string.IsNullOrWhiteSpace(CommentTB.Text);

            if (InvoiceNumberID.Enabled == false)
            {
                NewBTN_Click(null, null);
            }
            if (MobileTB.Text.Contains("+966"))
            {
                MobileTB.Text = MobileTB.Text.Replace("+966", "0").Replace(" ", "").Replace(" ", "");
            }

            foreach (ToolStripButton btn in InvoiceTypeOptions.Items)
            {
                btn.Checked = (btn.Text == OrderStatus.Text);
            }

        }



        private void MainMenu_Click(object sender, EventArgs e)
        {
            if (OrdersContainer.Visible)
            {
                OrdersContainer.Visible = false;
                this.OrdersPanel.Visible = true;
                this.OrdersPanel.BringToFront();


                //Update();
            }
            else
            {
                AmountLBL_TextChanged1(null, null);
            }
            if (ModifierKeys.HasFlag(Keys.Control))
            {

                //Console.Beep(1000, 100);
                //DbInv.DeleteAllEmptyDrafts();
                ////DbInv.Rebuild();
                //DbInv.InsureIndexes();
                //Console.Beep(1000, 100);
                //Console.Beep(1000, 100);
            }


        }

        #region Invoices
        /// <summary>
        /// الطلبات المعلقة
        ///</summary>
        //private void AddDraftInvoices()
        //{
        //    var DraftList = DbInv.GetDraftInvoices();
        //    foreach (var item in DraftList)
        //    {
        //        if (item.InvoiceItems.Count > 0)
        //        {
        //            _InvBTN draftBTN = new _InvBTN(item);
        //            int ID = item.ID;
        //            draftBTN.Tag = ID;
        //            //draftBTN.Click += (o, i) => HeldOrder_click(o, i);
        //            //HeldPanel.Controls.Add(draftBTN);
        //        }
        //    }
        //}

        /// <summary>
        /// الأيام والتاريخ
        /// </summary>
        /// <param name="day"></param>
        private void RadioChecked(int day)
        {
            if (day == 100)
            {

                InvoicesDG.DataSource = DbInv.GetSavedInvoices();
                radioChecked = day;
                GridUISaved();
                CountLBL.Text = InvoicesDG.RowCount.ToString();




            }
            else if (day == -1)
            {
                InvoicesDG.DataSource = DbInv.GetPrintedInvoices();
                radioChecked = day;
                CountLBL.Text = InvoicesDG.RowCount.ToString();

            }
            else if (day == -2)
            {
                InvoicesDG.DataSource = DbInv.GetDraftInvoices();
                CountLBL.Text = InvoicesDG.RowCount.ToString();
                radioChecked = day;
            }
            else
            {
                radioChecked = day;





                InvoicesDG.DataSource = DbInv.GetPrintedInvoices().Where(x => (int)x.InvoiceDay == day).ToList();
                GridUIPrinted();
                CountLBL.Text = InvoicesDG.RowCount.ToString();




            }

        }

        private void GridUISaved()
        {

            InvoicesDG.Columns["TimeinArabic"].DisplayIndex = 0;
            InvoicesDG.Columns["TimeinArabic"].Width = 90;


            InvoicesDG.Columns["CustomerName"].Width = 130;
            InvoicesDG.Columns["CustomerNumber"].Width = 105;
            InvoicesDG.Columns["Comment"].Width = 50;

            InvoicesDG.Columns["ID"].Width = 65;

            InvoicesDG.Columns["OrderType"].Width = 80;


            InvoicesDG.Columns["InvoiceDay"].Width = 80;



            InvoicesDG.Columns["InvoicePrice"].DisplayIndex = 5;
            InvoicesDG.Columns["InvoicePrice"].Width = 80;


            InvoicesDG.Columns["TimeOfPrinting"].DisplayIndex = 7;
            InvoicesDG.Columns["TimeOfPrinting"].Width = 100;

            InvoicesDG.Columns["TimeOfSaving"].DisplayIndex = 8;
            InvoicesDG.Columns["TimeOfSaving"].Visible = true;
            InvoicesDG.Columns["TimeOfSaving"].Width = 100;
            InvoicesDG.Columns["POSInvoiceNumber"].Visible = true;
            InvoicesDG.Columns["POSInvoiceNumber"].Width = 100;
            InvoicesDG.Columns["POSInvoiceNumber"].DisplayIndex = 1;


            InvoicesDG.Columns["PaymentName"].Visible = true;
            InvoicesDG.Columns["PaymentStatus"].Visible = false;
            InvoicesDG.Columns["Status"].Visible = false;
        }

        private void GridUIPrinted()
        {
            InvoicesDG.Columns["TimeinArabic"].DisplayIndex = 0;
            InvoicesDG.Columns["TimeinArabic"].Width = 130;


            InvoicesDG.Columns["CustomerName"].Width = 130;
            InvoicesDG.Columns["CustomerNumber"].Width = 105;
            InvoicesDG.Columns["Comment"].Width = 164;

            InvoicesDG.Columns["ID"].Width = 98;

            InvoicesDG.Columns["OrderType"].Width = 120;
            Console.WriteLine(InvoicesDG.Columns["OrderType"].Index);

            InvoicesDG.Columns["InvoiceDay"].Width = 80;



            InvoicesDG.Columns["InvoicePrice"].DisplayIndex = 5;
            InvoicesDG.Columns["InvoicePrice"].Width = 100;


            InvoicesDG.Columns["TimeOfPrinting"].DisplayIndex = 7;
            InvoicesDG.Columns["TimeOfPrinting"].Width = 100;

            InvoicesDG.Columns["TimeOfSaving"].Visible = false;
            InvoicesDG.Columns["PaymentName"].Visible = false;
            InvoicesDG.Columns["PaymentStatus"].Visible = false;
            InvoicesDG.Columns["POSInvoiceNumber"].Visible = false;
            InvoicesDG.Columns["Status"].Visible = false;
        }
        #endregion`
        public static string GetApiConnection() { return Properties.Settings.Default.API_Connection; }
        public static string GetDBConnections() { return Properties.Settings.Default.DBConnection; }
        private void Orders_Load(object sender, EventArgs e)
        {
            Screen[] screens = Screen.AllScreens;
            Screen screen1 = screens[0];
            this.Left = screen1.WorkingArea.Width - Width;
            this.Top = screen1.WorkingArea.Height - Height;

            LoadApps();
            if (Properties.Settings.Default.CallerIDEnabled)
            {
                //CIDWorker.RunWorkerAsync();
            }


            APIConnection = Properties.Settings.Default.API_Connection;
            servermode = Properties.Settings.Default.Api_Server;


            //Properties.Settings.Default.DBConnection = @"Filename =C:\db\db.db;connection=Shared";
            //Properties.Settings.Default.Save();



            MyCheckBox = this.checkBox1;

            if (APIAccess)
            {
                this.Text = Title + " API MODE ";
            }
            else this.Text = Title + " Local Network Mode";
            //dbQ.CreatePayment();
            if (servermode && APIAccess)
            {

                //KillandRestartAPI();
                LoadMethods();



            }
            else
            {

                LoadMethods(); // Local Not Recommended }


            }
            NewBTN_Click(null, null);

            changeMenu.Enabled = Properties.Settings.Default.showMenu;
            langCheck.Enabled = Properties.Settings.Default.showMenu;


            //ProcessStartInfo processInfo = new ProcessStartInfo("C:\\Users\\Admin\\source\\repos\\nabkawe\\OrderForm\\NetworkSynq\\bin\\Debug\\net6.0\\NetworkSynq.exe", "");
            //processInfo.CreateNoWindow = true;
            //processInfo.UseShellExecute = false;
            //Process.Start(processInfo);
        }

        private void LoadApps()
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default.Logo) || string.IsNullOrEmpty(Properties.Settings.Default.RestaurantName))
            {
                FirstStart F = new FirstStart();
                F.ShowDialog();
            }

            if (Properties.Settings.Default.Api_Server)
            {
                if (Process.GetProcessesByName("NetworkSynq").Length == 0)
                {
                    ProcessStartInfo processInfo = new ProcessStartInfo(Application.StartupPath + @"\API\NetworkSynq.exe", "");
                    processInfo.WorkingDirectory = Application.StartupPath + @"\API\";
                    processInfo.CreateNoWindow = true;
                    processInfo.UseShellExecute = false;
                    Process.Start(processInfo);


                }
                while (Process.GetProcessesByName("NetworkSynq").Length == 0)
                {
                    Thread.Sleep(200);
                }


            }
            if (Properties.Settings.Default.CallerIDEnabled)
            {
                if (Process.GetProcessesByName("CID").Length == 0)
                {
                    ProcessStartInfo processInfo = new ProcessStartInfo(Application.StartupPath + @"\CID.exe", "");
                    processInfo.WorkingDirectory = Application.StartupPath;
                    Process.Start(processInfo);
                }
            }
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

        public static bool GetServerMode()
        {
            return Properties.Settings.Default.Api_Server;
        }
        public static bool GetAPIMode()
        {
            return Properties.Settings.Default.Api_On;
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
                SaveToPOS.TimeOfPrinting = DateTime.Now.ToString("hh:mmtt dd/MM/yy");
                SaveToPOS.Comment = SaveToPOS.Comment == null ? " NP " : SaveToPOS.Comment + " NP ";
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
                                SaveToPOS.TimeOfPrinting = DateTime.Now.ToString("hh:mmtt dd/MM/yy");
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
                        var payment = new Payment() { Name = "Jahez", Amount = SaveToPOS.InvoicePrice };
                        SaveToPOS.Payments.Add(payment);
                        SaveToPOS.TimeOfSaving = DateTime.Now;


                        SaveToPOS.TimeOfPrinting = DbInv.GetInvoiceByID(SaveToPOS.ID).TimeOfPrinting;

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
            //var canceled = new InvoiceButton(SaveToPOS);
            int id = SaveToPOS.ID;
            //canceled.Tag = id;

            var a = NewPayForm(SaveToPOS);
            ShowMenuBTN.BackColor = Color.SlateGray;
            if (a.ShowDialog() == DialogResult.OK)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                NewBTN_Click(null, null);
                this.BringToFront();
                this.Activate();
                return;

            }
            else
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                //HeldOrder_click(canceled, null);
                this.BringToFront();
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
            if (POS.Count() > 0 || !string.IsNullOrEmpty(NameTB.Text) || !string.IsNullOrEmpty(MobileTB.Text))
            {
                POS.Clear();
                NewBTN_Click(null, null);
            }


        }

        #region Show Offer
        public static bool MenuShowing = false;

        #endregion



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
                        else { displayOffer.CloseNow(); ShowMenuBTN.BackColor = Color.SlateGray; }
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


        private void ItemNameTag_Click(object sender, EventArgs e)
        {
            string text = "هل تريد تغيير حالة المادة؟" + Environment.NewLine + "Yes المادة متوفرة" + Environment.NewLine + " No المادة غير متوفرة";
            DialogResult dialogResult = MessageBox.Show(text, "تعدل حالة توفر المادة", MessageBoxButtons.YesNo);
            var s = (ToolStripMenuItem)sender;
            var item = (string)s.GetCurrentParent().Tag;

            if (dialogResult == DialogResult.Yes)
            {
                dbQ.MatAvailableSet(item, true);
            }
            else dbQ.MatAvailableSet(item, false);

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
            this.OrdersFlowLayoutPanel.Visible = true; this.OrdersFlowLayoutPanel.BringToFront();
            this.OrdersContainer.Visible = true; this.OrdersContainer.BringToFront();
            this.OrdersPanel.Visible = false;
            LastOrder.Visible = false;
            EditName.Visible = false;
            History.Checked = true;
            this.SearchTB.Text = MobileTB.Text;
            GridUISaved();
            Search_Click(null, null);
            // AddDraftInvoices(); 


        }

        string jahezID;

        #region DragAndDropJahezWhatsapp
        private void dvItems_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        private void DvItems_DragDrop(object sender, DragEventArgs e)
        {


            string JahezParser = "";
            JahezParser = e.Data.GetData(DataFormats.UnicodeText).ToString();
            Match match = Regex.Match(JahezParser, @"^\d\r?");


            if (JahezParser.Contains("Order"))
            {
                POS.Clear();
                String input = JahezParser.Replace("Product", "").Replace("Quantity", "").Replace("Price", "");
                string pattern = @"Order#\s(\d+)";
                match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    MobileTB.Text = "";
                    NameTB.Text = "جاهز" + match.Groups[1].Value;
                    jahezID = "جاهز" + match.Groups[1].Value;
                }
                pattern = @"Comment:(.*?)[\r\n]+";

                match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    CommentTB.Text = match.Groups[1].Value;
                }
                pattern = @"([\s\S]*?)\r?\n""(\d+)"".*?\r?\n.*?\r?\n(\d+)\s+([\d.]+)";
                foreach (Match m in Regex.Matches(input, pattern))
                {
                    var ProductName = m.Groups[1].Value.Trim().Replace("SAR", "").Replace("\n", "").Replace("\r", "");
                    var barcode = m.Groups[2].Value;
                    var Quantity = m.Groups[3].Value;
                    var Price = m.Groups[4].Value;
                    var Item = ItemsLists.First(x => x.Barcode == barcode);
                    if (Item != null)
                    {
                        Item.Quantity = Convert.ToInt32(Quantity);
                        Item.Comment = string.Empty;
                        POSItems New = new POSItems();
                        New.Name = Item.Name;
                        New.Quantity = Item.Quantity;
                        decimal decimalPrice;
                        if (Decimal.TryParse(Price, out decimalPrice))
                        {
                            // Conversion successful
                            New.Price = decimalPrice / Item.Quantity;
                        }
                        else
                        {
                            New.Price = Item.Price;
                        }

                        New.PrinterName = Item.PrinterName;
                        Item.printerlist.ForEach(x => New.printerlist.Add(x));
                        New.realquan = Item.realquan;
                        New.Barcode = Item.Barcode;
                        New.ID = Item.ID;
                        New.Parent = Item.Parent;
                        New.Available = Item.Available;
                        if (barcode == "010052")
                        {
                            New.Comment = ProductName;
                        }
                        POS.Add(New);
                    }
                }
                OrderStatus.Text = "تطبيقات";
                if (!DbInv.GetAllSavedInvoices().Exists(x => x.CustomerName == jahezID) && !DbInv.GetPrintedInvoices().Exists(x => x.CustomerName == jahezID))
                {
                    if (DbInv.GetInvoiceByID(Convert.ToInt32(InvoiceNumberID.Text)).Status == InvStat.Draft)
                    {
                        PrintSave_Click(null, null);
                    }
                    else { MessageBox.Show("ربما تقوم بنسخ فاتورة جاهز فوق فاتورة معدة من قبل الرجاء بدء فاتورة جديدة"); }
                }
                else
                {
                    MessageBox.Show("ربما قمت بتخزين هذا الطلب من قبل");
                }



            }

            //else if (match.Success)
            //{
            //    JahezParser = JahezParser.Replace("\u200F", "");
            //    string a = JahezParser;
            //    while (a.Contains("\r") || a.Contains("\n\n"))
            //    {
            //        a = a.Replace("\r", "").Replace("\n\n", "\n");
            //    }

            //    MatchCollection matches = Regex.Matches(a, @"\n(\d+)×\n(.+?)\s+([\d.]+) ر.س.");


            //    foreach (Match matchA in matches)
            //    {
            //        string quantity = matchA.Groups[1].Value;
            //        string itemName = matchA.Groups[2].Value;
            //        string price = matchA.Groups[3].Value;

            //        MessageBox.Show($"{quantity}x {itemName} for {price} ر.س.");
            //    }
            //}

            else if (JahezParser.Contains("المبلغ المُقدَّر") || JahezParser.Contains("estimated"))
            {
                string whatsappParser = string.Empty;
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

                    //string price = whatsappParser.Split('\u000a')[2].
                    //    Replace(" ر.س.‏", "").Replace("(estimated)", "").Replace("SAR", "").Replace("(المبلغ المُقدَّر)", "").Replace("(المبلغالمُقدَّر)", "").Replace('٫', '.').Replace(" ", "").Replace("٠", "0").Replace("١", "1").Replace("٢", "2").Replace("٣", "3").Replace("٤", "4").Replace("٥", "5").Replace("٦", "6").Replace("٧", "7").Replace("٨", "8").Replace("٩", "9");
                    //MessageBox.Show(price);
                    //string price0 = whatsappParser.Split('\u000a')[0].
                    //    Replace(" ر.س.‏", "").Replace("(estimated)", "").Replace("SAR", "").Replace("(المبلغ المُقدَّر)", "").Replace("(المبلغالمُقدَّر)", "").Replace('٫', '.').Replace(" ", "").Replace("٠", "0").Replace("١", "1").Replace("٢", "2").Replace("٣", "3").Replace("٤", "4").Replace("٥", "5").Replace("٦", "6").Replace("٧", "7").Replace("٨", "8").Replace("٩", "9");

                    string price1 = whatsappParser.Split('\u000a')[1].
                        Replace(" ر.س.‏", "").Replace("(estimated)", "").Replace("SAR", "").Replace("(المبلغ المُقدَّر)", "").Replace("(المبلغالمُقدَّر)", "").Replace('٫', '.').Replace(" ", "").Replace("٠", "0").Replace("١", "1").Replace("٢", "2").Replace("٣", "3").Replace("٤", "4").Replace("٥", "5").Replace("٦", "6").Replace("٧", "7").Replace("٨", "8").Replace("٩", "9");
                    price1 = price1.Replace("‏", "").Replace("(المبلغالمُقدَّر)", "");
                    decimal due = Convert.ToDecimal(AmountLBL.Text);
                    decimal decimalPrice;
                    string CartPrice = price1.Replace("\r", "");
                    if (Decimal.TryParse(CartPrice, out decimalPrice))
                    {
                        if (due != decimalPrice)
                        {
                            MessageBox.Show("السعر لا يساوي السعر بالسلة");
                            return;
                        }
                        else
                        {
                            uButton1_Click(null, null);
                            return;
                        }
                    }
                    else { return; }

                }
            }



            //else if (JahezParser.Contains("(") || JahezParser.Contains("ر.س"))
            //{
            //    string whatsappParser = string.Empty;
            //    whatsappParser = e.Data.GetData(DataFormats.UnicodeText).ToString();
            //    POS.Clear();
            //    String MatParser = "";
            //    {

            //        foreach (string s in whatsappParser.Split('\u000a'))
            //        {

            //            if (s.Contains("\""))
            //            {
            //                var start = s.IndexOf("\"") + 1;//add one to not include quote
            //                var end = s.LastIndexOf("\"") - start;
            //                var result = s.Substring(start, end);
            //                MatParser += Environment.NewLine + "*" + result;
            //            }
            //            if (s.Contains('•'))
            //            {

            //                MatParser += Environment.NewLine + s.Split('•')[1].Replace("Quantity ", "").Replace("الكمية ", "");
            //            }

            //        }

            //        try
            //        {

            //            for (int i = 1; i < MatParser.Split('*').Count() + 1; i++)
            //            {
            //                string WhatsBarcode = MatParser.Split('*')[i].Split('\u000a')[0];
            //                string WhatsQuantity = MatParser.Split('*')[i].Split('\u000a')[1];
            //                WhatsBarcode = WhatsBarcode.Replace('\r', ' ').Replace(" ", "");
            //                WhatsQuantity = WhatsQuantity.Replace('\r', ' ').Replace(" ", "");

            //                var Item = ItemsLists.First(x => x.Barcode == WhatsBarcode);
            //                if (Item != null)
            //                {
            //                    Item.Quantity = Convert.ToInt32(WhatsQuantity);
            //                    Item.Comment = "";
            //                    POSItems New = new POSItems();
            //                    New.Name = Item.Name;
            //                    New.Quantity = Item.Quantity;
            //                    New.Price = Item.Price;
            //                    New.PrinterName = Item.PrinterName;
            //                    Item.printerlist.ForEach(x => New.printerlist.Add(x));
            //                    New.realquan = Item.realquan;
            //                    New.Barcode = Item.Barcode;
            //                    New.ID = Item.ID;
            //                    New.Parent = Item.Parent;
            //                    New.Available = Item.Available;
            //                    POS.Add(New);
            //                }

            //            }
            //        }


            //        catch (Exception)
            //        {
            //            //JahezBarcode = JahezBarcode.Remove(JahezBarcode.Length - 2, JahezBarcode.Length);
            //            //JahezQuantity = JahezQuantity.Remove(JahezQuantity.Length - 2, JahezQuantity.Length);
            //        }

            //        string price = whatsappParser.Split('\u000a')[1].
            //            Replace(" ر.س.‏", "").Replace("(estimated)", "").Replace("SAR", "").Replace("(المبلغ المُقدَّر)", "").Replace('٫', '.').Replace(" ", "").Replace("٠", "0").Replace("١", "1").Replace("٢", "2").Replace("٣", "3").Replace("٤", "4").Replace("٥", "5").Replace("٦", "6").Replace("٧", "7").Replace("٨", "8").Replace("٩", "9");
            //        string price1 = whatsappParser.Split('\u000a')[1].
            //            Replace(" ر.س.‏", "").Replace("(estimated)", "").Replace("SAR", "").Replace("(المبلغ المُقدَّر)", "").Replace('٫', '.').Replace(" ", "").Replace("٠", "0").Replace("١", "1").Replace("٢", "2").Replace("٣", "3").Replace("٤", "4").Replace("٥", "5").Replace("٦", "6").Replace("٧", "7").Replace("٨", "8").Replace("٩", "9");
            //        string price0 = whatsappParser.Split('\u000a')[0].
            //            Replace(" ر.س.‏", "").Replace("(estimated)", "").Replace("SAR", "").Replace("(المبلغ المُقدَّر)", "").Replace('٫', '.').Replace(" ", "").Replace("٠", "0").Replace("١", "1").Replace("٢", "2").Replace("٣", "3").Replace("٤", "4").Replace("٥", "5").Replace("٦", "6").Replace("٧", "7").Replace("٨", "8").Replace("٩", "9");

            //        decimal due = Convert.ToDecimal(AmountLBL.Text);
            //        string CartPrice = price.Replace("/r", "");



            //    }
            //}
        }
        #endregion
        private void Search_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SearchTB.Text) && SearchTB.Text.Length > 1)
            {
                InvoicesDG.CurrentCell = null;
                InvoicesDG.ClearSelection();
                if (radioChecked != 100)
                {
                    if (radioChecked != -1)
                    {
                        InvoicesDG.DataSource = DbInv.GetPrintedInvoices().Where(x => (int)x.InvoiceDay == radioChecked && ToUnifiedArabic(x.SearchResult).Contains(ToUnifiedArabic(SearchTB.Text))).ToList();
                    }
                    else
                    {
                        InvoicesDG.DataSource = DbInv.GetPrintedInvoices().Where(x => ToUnifiedArabic(x.SearchResult).Contains(ToUnifiedArabic(SearchTB.Text))).ToList();
                    }
                }
                else
                {
                    InvoicesDG.DataSource = DbInv.GetAllSavedInvoices().Where(x => ToUnifiedArabic(x.SearchResult).Contains(ToUnifiedArabic(SearchTB.Text))).ToList();

                }
                CountLBL.Text = InvoicesDG.RowCount.ToString();


            }
        }
        private string ToUnifiedArabic(string original)
        {
            StringBuilder Uniefied = new StringBuilder(original);

            string[] alefVariations = new string[] { "آ", "أ", "إ", "ٵ" };
            foreach (string variation in alefVariations)
            {
                Uniefied.Replace(variation, "ا");
            }

            string[] tashkeel = new string[] { "َ", "ً", "ُ", "ٌ", "ِ", "ٍ", "ْ", "ّ" };
            foreach (string mark in tashkeel)
            {
                Uniefied.Replace(mark, "");
            }

            Uniefied.Replace("ة", "ه");
            Uniefied.Replace("ى", "ي");
            Uniefied.Replace("ؤ", "و");

            return Uniefied.ToString();
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
            if (!OrdersFlowLayoutPanel.Visible)
            {
                this.OrdersContainer.Visible = false;
            }
            else { this.OrdersContainer.Visible = true; }


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
                if (!ModifierKeys.HasFlag(Keys.Control) && !string.IsNullOrEmpty(MobileTB.Text))
                {
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
                    if (!string.IsNullOrEmpty(MobileTB.Text))
                    {
                        var num = this.MobileTB.Text;
                        //var numbersyntax = "(05)([0-9]{8})|5([0-9]{8})";
                        var numbersyntax = @"(05)([0-9]{8})|5([0-9]{8})|\+([0-9]{12})|00([0-9]{12})|\+([0-9]{11})|00([0-9]{11})";
                        Regex rgx = new Regex(numbersyntax);
                        Match numbermatch = rgx.Match(num);
                        this.MobileTB.Text = numbermatch.Value.ToString();
                        if (this.MobileTB.Text.StartsWith("00") || this.MobileTB.Text.StartsWith("+")) Process.Start("https://wa.me/" + this.MobileTB.Text + "?text=" + "/");
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
            if (!InvoicesDG.Visible)
            {


                if (e.ClickedItem.Text == "نسخ وإرسال الفاتورة")
                {
                    if (!string.IsNullOrEmpty(MobileTB.Text))
                    {
                        Custom_Classes.CreateOffer.CreateOfferNow(PrintNewInvoice(), true);
                        Console.Beep(1000, 100);
                        string url = "whatsapp://send/?phone=" + "966" + this.MobileTB.Text + "&text= ";
                        Process.Start(url);
                        Process.Start(url);
                        InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("En-US"));
                        SendKeys.Send("^{V}");
                        InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("Ar-SA"));
                    }
                }
                // add another condition for if the text = صورة منيو    

                else if (e.ClickedItem.Text == "فيديو توضيحي" || e.ClickedItem.Text == "صورة منيو")
                {
                    string details = dbQ.GetAllShortcuts().Where(x => x.Shortcut == e.ClickedItem.Text).First().Details;
                    // check if a file exists...    
                    if (File.Exists(details))
                    {
                        // copy the file to the clipboard...    
                        System.Windows.Clipboard.SetFileDropList(new System.Collections.Specialized.StringCollection { details });
                    }
                }

                else
                {
                    if (!string.IsNullOrEmpty(MobileTB.Text))
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

            }
            else
            {
                var seee = sender as ContextMenuStrip;
                //var see = seee.GetCurrentParent() as 
                var se = seee.Tag as Invoice;
                if (e.ClickedItem.Text != "نسخ وإرسال الفاتورة")
                {
                    if (!string.IsNullOrEmpty(se.CustomerNumber))
                    {
                        string details = dbQ.GetAllShortcuts().Where(x => x.Shortcut == e.ClickedItem.Text).First().Details;
                        string newdetails = details.Replace(" ", "%20").Replace("\n", "%0a");
                        string url = "whatsapp://send/?phone=" + "966" + se.CustomerNumber;

                        url = "whatsapp://send/?phone=" + "966" + se.CustomerNumber + "&text=" + newdetails;
                        Process.Start(url);

                        Thread.Sleep(1000);

                        SendKeys.Send("{Enter}");

                    }

                }
                else
                {
                    if (!string.IsNullOrEmpty(se.CustomerNumber))
                    {



                        Custom_Classes.CreateOffer.CreateOfferNow(se, true);


                        Console.Beep(1000, 100);
                        string url = "whatsapp://send/?phone=" + "966" + se.CustomerNumber + "&text= ";
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
            if (!History.Checked && repeatedBehavior.AreYouSure("هل تريد تخزين كل فواتير جاهز", ""))
            {
                foreach (DataGridViewRow row in InvoicesDG.Rows)
                {
                    Invoice item = (Invoice)row.DataBoundItem;
                    if (item.OrderType == "تطبيقات")
                    {
                        item.Status = InvStat.SavedToPOS;
                        item.POSInvoiceNumber = "جاهز";
                        item.TimeOfSaving = DateTime.Now;
                        var payment = new Payment() { Name = "Jahez", Amount = item.InvoicePrice };
                        item.Payments.Add(payment);
                        DbInv.CreateAppOrder(item);
                    }
                }
                GetRadioDict()[radioChecked].Checked = true;
                Fri_CheckedChanged(GetRadioDict()[radioChecked], null);
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
            //if (APIAccess)
            //{
            //    if (!DbInv.AreYouAlive())
            //    {
            //        this.Text = Title + " *** Failed to Connect to API";
            //    }
            //    else
            //    {
            //        this.Text = Title + "API Mode Connected " + DateTime.Now.ToString("HH:mm:ss");
            //    }
            //}
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

                DbInv.GetSavedInvoices().Where(x => x.OrderType == "تطبيقات").Take(10).ToList().ForEach(x => menu.MenuItems.Add(x.CustomerName));

                menu.Show(toolStrip1, new Point(0, 0));
            }
        }


        private async void MobileTB_DoubleClick(object sender, EventArgs e)
        {
            var a = await getcontextMenu();
            if (a != null)
            {
                a.Show(MobileTB, new Point(0, 0));
                a.MenuItems[0].PerformSelect();
            }

        }
        async Task<ContextMenu> getcontextMenu()
        {

            var items = await Windows.ApplicationModel.DataTransfer.Clipboard.GetHistoryItemsAsync();
            var context = new ContextMenu();

            var empty = new MenuItem(" ");
            empty.Click += Menu_Click;

            context.MenuItems.Add(empty);

            foreach (var item in items.Items.Where(x => x.Content.AvailableFormats.Contains(StandardDataFormats.Text)).Distinct().ToList())
            {
                string data = await item.Content.GetTextAsync();
                if (data.Length == 10 && data.StartsWith("0"))
                {
                    var menu = new MenuItem(data);
                    menu.Click += Menu_Click;

                    context.MenuItems.Add(menu);
                }

            }

            if (context.MenuItems.Count > 0)
            {

                return context;
            }
            else return null;


            //var items = await Windows.ApplicationModel.DataTransfer.Clipboard.GetHistoryItemsAsync();
            //var context = new ContextMenu();
            //foreach (var item in items.Items.Take(30))
            //{

            //    var data = await item.Content();
            //    if (data.GetType() == typeof(string)) { 

            //    if (data.Length == 10 && data.StartsWith("0"))
            //    {
            //        var menu = new MenuItem(data);
            //        menu.Click += Menu_Click;

            //        context.MenuItems.Add(menu);
            //    }
            //    }
            //}



        }
        private void Menu_Click(object sender, EventArgs e)
        {
            var mi = (MenuItem)sender;

            MobileTB.Text = mi.Text;

            if (mi.Text != "") NameTB_Enter(null, null); else MobileTB.Text = "";



        }

        //private void CIDWorker_DoWork(object sender, DoWorkEventArgs e)
        //{


        //    var phoneLog = CIDMain.GetLastNumber();
        //    if (phoneLog?.Count > 0)
        //    {

        //        foreach (var item in phoneLog)
        //        {
        //            item.CustomerName = dbQ.LoadContacts(item.PhoneNumber).Name;


        //            if (servermode)

        //            {
        //                if (APIAccess)
        //                {
        //                    try
        //                    {
        //                        System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
        //                        var client = new RestClient(Properties.Settings.Default.API_Connection + "/CallerID/LogPhone");
        //                        var request = new RestRequest();
        //                        request.AddHeader("Content-Type", "application/json");
        //                        request.AddHeader("Accept", "application/json");
        //                        request.RequestFormat = RestSharp.DataFormat.Json;
        //                        string i = Newtonsoft.Json.JsonConvert.SerializeObject(item, Newtonsoft.Json.Formatting.Indented);
        //                        request.AddParameter("application/json", i, ParameterType.RequestBody);
        //                        var response = client.Post(request);
        //                    }
        //                    catch (Exception) { }
        //                }
        //                else
        //                {

        //                    try
        //                    {
        //                        using (var db = new LiteDatabase(Properties.Settings.Default.DBConnection))
        //                        {
        //                            var phlog = db.GetCollection<PhoneLog>("PhoneLog");
        //                            if (item != null)
        //                            {
        //                                phlog.Insert(item);
        //                            }
        //                        }

        //                    }
        //                    catch (Exception)
        //                    {

        //                    }
        //                }
        //            }
        //            else
        //            {
        //                try
        //                {
        //                    System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
        //                    var client = new RestClient(Properties.Settings.Default.API_Connection + "/CallerID/LogPhone");
        //                    var request = new RestRequest();
        //                    request.AddHeader("Content-Type", "application/json");
        //                    request.AddHeader("Accept", "application/json");
        //                    request.RequestFormat = RestSharp.DataFormat.Json;
        //                    string i = Newtonsoft.Json.JsonConvert.SerializeObject(phoneLog, Newtonsoft.Json.Formatting.Indented);
        //                    request.AddParameter("application/json", i, ParameterType.RequestBody);
        //                    var response = client.Post(request);
        //                }
        //                catch (Exception) { }



        //            }
        //        }
        //    }
        //    return;


        //}

        //private void CallerIDBTN_Click(object sender, EventArgs e)
        //{

        //    if (Application.OpenForms.OfType<CalLog>().Any())
        //    {
        //        Application.OpenForms.OfType<CalLog>().First().BringToFront();
        //    }
        //    else
        //    {
        //        CalLog calLog = new CalLog();
        //        ///*calLog.Location */;
        //        ///
        //        calLog.Location = new Point(Cursor.Position.X - calLog.Width, Cursor.Position.Y - calLog.Height);
        //        calLog.Show();
        //    }



        //}

        //private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        //{

        //}

        private void CallerIDBTN_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                try
                {
                    var last = dbQ.loadPhoneBook(1).First();
                    MobileTB.Text = last.PhoneNumber;
                    NameTB.Text = last.CustomerName;

                }
                catch (Exception)
                {

                }
            }
        }

        private void InvoicesDG_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            Invoice item = (Invoice)InvoicesDG.Rows[e.RowIndex].DataBoundItem;
            var Opened = DbInv.GetInvoiceByID(item.ID);
            LoadInvoiceUI(Opened);

        }

        private void InvoicesDG_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            Invoice item = (Invoice)InvoicesDG.Rows[e.RowIndex].DataBoundItem;
            if (e.ColumnIndex == InvoicesDG.Columns["InvoiceDay"].Index && e.Value != null)
            {
                e.Value = GetDayName((int)item.InvoiceDay);
            }
            if (e.ColumnIndex == InvoicesDG.Columns["TimeOfPrinting"].Index && !string.IsNullOrEmpty(item.TimeOfPrinting) && DateTime.TryParse(item.TimeOfPrinting.Replace("-", ""), out var timeOfPrinting))
            {

                e.Value = timeOfPrinting.ToString("hh:mmtt");



            }
            if (e.ColumnIndex == 5 && item.InEditMode && item.TimeOfSaving != null)
            {

                e.Value = "الطلب جاهز";



            }



            if (e.ColumnIndex == InvoicesDG.Columns["TimeOfSaving"].Index && item.TimeOfSaving != null)
            {
                e.Value = item.TimeOfSaving.ToString("hh:mmtt");

            }
            if (e.ColumnIndex == InvoicesDG.Columns["TimeOfSaving"].Index && item.TimeOfSaving != null)
            {
                e.Value = item.TimeOfSaving.ToString("hh:mmtt dd/MM/yy");



            }


            if (item.OrderType == "تطبيقات")
            {
                if (!item.InEditMode)
                {
                    InvoicesDG.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                    InvoicesDG.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                }
                else
                {
                    InvoicesDG.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.MediumPurple;
                    InvoicesDG.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                }
            }
            else if (item.InEditMode && item.OrderType != "تطبيقات")
            {
                InvoicesDG.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.MediumPurple;
                InvoicesDG.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;

            }
            else if (item.Status ==  InvStat.Deleted)
            {
                InvoicesDG.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightPink;
                InvoicesDG.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;

            }else
            {
                InvoicesDG.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                InvoicesDG.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;

            }






        }

        private void InvoicesDG_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.RowIndex > -1)
            {

                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    // Set the ToolTip text to the value of the cell
                    if (InvoicesDG[e.ColumnIndex, e.RowIndex].Value != null)
                        e.ToolTipText = InvoicesDG[e.ColumnIndex, e.RowIndex].Value.ToString();
                }

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

            SearchTB.Clear();
            GetRadioDict()[radioChecked].Checked = true;
            Fri_CheckedChanged(GetRadioDict()[radioChecked], null);
        }
        private Dictionary<int, RadioButton> GetRadioDict()
        {
            return new Dictionary<int, RadioButton>()
            {
                { 6, Sat },
                { 0, Sun },
                { 1, Mon },
                { 2, Tue },
                { 3, Wed },
                { 4, Thu },
                { 5, Fri },
                { -1, AllDays },
                { 100, History }  ,
                { -2, Draft }
            };
        }

        private void GroupSave_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void PrintMulti_Click(object sender, EventArgs e)
        {
            if (InvoicesDG.SelectedRows.Count <= 1)
            {
                return;
            }
            else
            {
                var list = new List<Invoice>();
                var reloadlist = InvoicesDG.SelectedRows
                                 .Cast<DataGridViewRow>()
                                 .Select(row => row.DataBoundItem)
                                 .Cast<Invoice>();
                reloadlist.ToList().ForEach(x => list.Add(DbInv.GetInvoiceByID(x.ID)));
                var CombinedInvoice = new Invoice() { ID = 999999999, CustomerName = "ورقة مجمعة لعدة فواتير", Comment = " " };
                list.ToList().ForEach(x =>
                {
                    if (!string.IsNullOrEmpty(x.CustomerName) && x.CustomerName.Length >= 3)
                    {
                        CombinedInvoice.Comment += x.CustomerName.Substring(0, 3) + "..." + x.IDstring + Environment.NewLine;
                    }
                });


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

                var grouped = poslist.GroupBy(item => item.Barcode);

                foreach (var group in grouped)
                {
                    var firstItem = group.First();
                    firstItem.Comment = string.Join(", ", group.Where(item => !string.IsNullOrEmpty(item.Comment))
                                                               .Select(item => $"{item.Quantity}: {item.Comment}"));
                    firstItem.Quantity = group.Sum(item => item.Quantity);

                }

                poslist = poslist.GroupBy(item => item.Barcode)
                                 .Select(group => group.First())
                                 .ToList();



                Orders.CurrentList.Clear();

                foreach (var group in poslist)
                {
                    Orders.CurrentList.Add(group);
                }

                Orders.globalInvoice = CombinedInvoice;

                PrintInvoice.Print(dbQ.DefaultPrinters());
                GetRadioDict()[radioChecked].Checked = true;
                Fri_CheckedChanged(GetRadioDict()[radioChecked], null);


            }

        }

        private void MultiSave_Click(object sender, EventArgs e)
        {
            int selectedCount = InvoicesDG.SelectedRows.Count;
            if (selectedCount <= 0)
            {
                return;
            }
            else if (selectedCount == 1)
            {
                DataGridViewRow row = this.InvoicesDG.SelectedRows[0];
                Invoice SingleInvoice = row.DataBoundItem as Invoice;
                //updating the Invoice so we wouldn't get old data.
                SingleInvoice = DbInv.GetInvoiceByID(SingleInvoice.ID);
                if (SingleInvoice == null || SingleInvoice.Status == InvStat.SavedToPOS)
                {
                    return;

                }

                this.Hide();

                if (NewPayForm(SingleInvoice).ShowDialog() == DialogResult.OK)
                {
                    this.Show();
                    this.WindowState = FormWindowState.Normal;
                    MainMenu_Click(null, null);
                    NewBTN_Click(null, null);
                    this.BringToFront();
                    this.Activate();
                    return;

                }
                else
                {
                    this.Show();
                    this.WindowState = FormWindowState.Normal;
                    this.BringToFront();
                    this.Activate();
                    return;
                }
            }
            else
            {
                var list = new List<Invoice>();
                var reloadlist = InvoicesDG.SelectedRows.Cast<DataGridViewRow>().Select(row => row.DataBoundItem).Cast<Invoice>();

                foreach (var item in reloadlist.ToList())
                {
                    var invoice = DbInv.GetInvoiceByID(item.ID);
                    if (invoice == null) { MessageBox.Show("هناك مشكلة في أحد الفواتير المراد تخزينها، قم بتحديث قائمة الفواتير"); return; }
                    if (invoice.Status != InvStat.SavedToPOS) list.Add(invoice);
                }
                if (list.Count <= 0) return;
                var mainInvoice = list.Last();
                var CombinedInvoice = new Invoice() { ID = mainInvoice.ID, CustomerName = mainInvoice.CustomerName, CustomerNumber = mainInvoice.CustomerNumber, TimeOfPrinting = mainInvoice.TimeOfPrinting };

                list.ToList().ForEach(x => { if (!string.IsNullOrEmpty(x.Comment)) CombinedInvoice.Comment += " " + x.Comment + " "; });
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
                var grouped = poslist.GroupBy(item => item.Barcode);

                foreach (var group in grouped)
                {
                    var firstItem = group.First();
                    firstItem.Comment = string.Join(", ", group.Where(item => !string.IsNullOrEmpty(item.Comment))
                                                               .Select(item => $"{item.Quantity}: {item.Comment}"));
                    firstItem.Quantity = group.Sum(item => item.Quantity);
                }
                poslist = poslist.GroupBy(item => item.Barcode)
                                 .Select(group => group.First())
                                 .ToList();


                foreach (var group in poslist)
                {
                    CombinedInvoice.InvoiceItems.Add(group);
                }
                CombinedInvoice.InvoicePrice = CombinedInvoice.InvoiceItems.Sum(x => x.TotalPrice);
                if (NewPayForm(CombinedInvoice).ShowDialog() == DialogResult.OK)
                {
                    this.Show();
                    this.WindowState = FormWindowState.Normal;
                    MainMenu_Click(null, null);
                    NewBTN_Click(null, null);
                    this.BringToFront();
                    this.Activate();
                    int oldID = CombinedInvoice.ID;
                    foreach (var item in list)
                    {
                        if (item.ID == oldID)
                        {
                            CombinedInvoice.Status = InvStat.SavedToPOS;
                            CombinedInvoice.TimeOfSaving = DateTime.Now;
                            DbInv.UpdateInvoice(CombinedInvoice);
                        }
                        else
                        {
                            item.InvoiceItems.Clear();
                            item.Comment = "فاتورة مجمعة تابعة لرقم: " + oldID;
                            item.Status = InvStat.Deleted;
                            item.InvoicePrice = 0;
                            DbInv.UpdateInvoice(item);
                        }
                    }
                    return;
                }
                else
                {
                    this.Show();
                    this.WindowState = FormWindowState.Normal;
                    this.BringToFront();
                    this.Activate();
                    return;
                }
            }
        }

        private void InvoicesDG_SelectionChanged(object sender, EventArgs e)
        {
            if (InvoicesDG.SelectedRows.Count > 1)
            {
                var last = InvoicesDG.SelectedRows.Cast<DataGridViewRow>().ToList().Last();


                last.DefaultCellStyle.SelectionBackColor = Color.Green;

                InvoicesDG.SelectedRows.Cast<DataGridViewRow>().ToList().ForEach(x => { if (x.Index != last.Index) x.DefaultCellStyle.SelectionBackColor = Color.Blue; });

            }

            selectedLBL.Text = InvoicesDG.SelectedRows.Count.ToString();

        }

        private void OrdersReady_Click(object sender, EventArgs e)
        {
            if (InvoicesDG.SelectedRows.Count >= 1)
            {
                var last = InvoicesDG.SelectedRows.Cast<DataGridViewRow>().ToList();
                last.ForEach(x =>
                {
                    var inv = (Invoice)x.DataBoundItem;
                    if (inv.InEditMode == false)
                    {
                        DbInv.UpdateInvoiceReady(inv.ID, true); inv.InEditMode = true;
                    }
                    else { DbInv.UpdateInvoiceReady(inv.ID, false); inv.InEditMode = false; }
                });
                InvoicesDG.Refresh();


            }

        }

        private void InvoicesDG_DataSourceChanged(object sender, EventArgs e)
        {

            // Call the method and set the cell value


        }

        private void InvoicesDG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == InvoicesDG.Columns["ID"].Index)
            {
                if (e.RowIndex < 0) return;
                Invoice item = (Invoice)InvoicesDG.Rows[e.RowIndex].DataBoundItem;
                var Opened = DbInv.GetInvoiceByID(item.ID);
                LoadInvoiceUI(Opened);
                return;
            }
        }

        private void WhatsAppDataGrid(Invoice item)
        {
            var WhatsAppList = dbQ.GetAllShortcuts();
            if (WhatsAppList.Count > 0)
            {
                WhatsSend.Items.Clear();
                WhatsSend.Items.Add("نسخ وإرسال الفاتورة");
                WhatsAppList.ForEach(x => WhatsSend.Items.Add(x.Shortcut));
                WhatsSend.Tag = null;
                WhatsSend.Tag = item;
                WhatsSend.Show(Cursor.Position);
            }


        }

        private void History_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Fri_CheckedChanged(GetRadioDict()[radioChecked], null);
            }
        }

        private void InvoicesDG_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                if (e.ColumnIndex == InvoicesDG.Columns["CustomerNumber"].Index)
                {
                    InvoicesDG.ClearSelection();
                    if (e.RowIndex < 0) return;
                    InvoicesDG.Rows[e.RowIndex].Selected = true;

                    if (InvoicesDG.SelectedCells[e.ColumnIndex].Value != null && InvoicesDG.SelectedCells[e.ColumnIndex].Value.ToString() != "")
                    {

                        Invoice item = (Invoice)InvoicesDG.Rows[e.RowIndex].DataBoundItem;

                        WhatsAppDataGrid(item);
                    }
                }

                if (e.ColumnIndex == InvoicesDG.Columns["POSInvoiceNumber"].Index)
                {
                    InvoicesDG.ClearSelection();
                    if (e.RowIndex < 0) return;
                    InvoicesDG.Rows[e.RowIndex].Selected = true;

                    if (InvoicesDG.SelectedCells[e.ColumnIndex].Value != null && InvoicesDG.SelectedCells[e.ColumnIndex].Value.ToString() != "جاهز" && InvoicesDG.SelectedCells[e.ColumnIndex].Value.ToString() != "")
                    {

                        Invoice item = (Invoice)InvoicesDG.Rows[e.RowIndex].DataBoundItem;

                        PaymentOptions p = new PaymentOptions(item.POSInvoiceNumber);
                    }
                }
            }
        }

        private void EditName_Click(object sender, EventArgs e)
        {
            try
            {
                var con = EditName.Tag as Contacts;
                if (con != null && MobileTB.Text == con.Number)
                {
                    con.Name = NameTB.Text;
                    dbQ.SaveContacts(con);
                }
                EditName.Visible = false;
            }
            catch (Exception)
            {


            }


        }

        private void InvoicesDG_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                if (e.Value != null)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                    ButtonRenderer.DrawButton(e.Graphics, e.CellBounds, e.Value.ToString(), this.Font, false, System.Windows.Forms.VisualStyles.PushButtonState.Hot);

                    e.Handled = true;
                }
            }

            if (e.ColumnIndex == 5 && e.RowIndex >= 0 && e.FormattedValue.ToString() == "الطلب جاهز")
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
                ButtonRenderer.DrawButton(e.Graphics, e.CellBounds, e.FormattedValue.ToString(), this.Font, false, System.Windows.Forms.VisualStyles.PushButtonState.Hot);
                e.Handled = true;
            }

        }

        private void uButton1_Click(object sender, EventArgs e)
        {

            if (System.Windows.Clipboard.ContainsText(System.Windows.TextDataFormat.Text))
            {
                if (!System.Windows.Clipboard.GetText().Replace("+", "").Replace(" ", "").Any(c => !Char.IsDigit(c)))
                    MobileTB.Text = System.Windows.Clipboard.GetText();
                else { NameTB.Text = System.Windows.Clipboard.GetText(); }
            }
        }
    }
}

