using LiteDB;
using Newtonsoft.Json.Linq;
using OrderForm.SavingandPayment;
using PrayerTimes;
using sharedCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Deployment.Application;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.ApplicationModel.DataTransfer;
using Application = System.Windows.Forms.Application;
using Color = System.Drawing.Color;
using DataFormats = System.Windows.Forms.DataFormats;
using DragDropEffects = System.Windows.Forms.DragDropEffects;
using DragEventArgs = System.Windows.Forms.DragEventArgs;
using Point = System.Drawing.Point;

namespace OrderForm
{


    public partial class Orders : Form
    {
        public string APIConnection { get { return Properties.Settings.Default.API_Connection; } set { Properties.Settings.Default.API_Connection = value; } }
        public static bool Servermode { get; set; }
        public bool APIAccess { get { return Properties.Settings.Default.Api_On; } set { Properties.Settings.Default.Api_On = value; } }

        public static BindingList<POSItems> POS = new BindingList<POSItems>();

        public event EventHandler<string> UpdatedDraft;

        public static List<POSItems> ItemsLists = new List<POSItems>();

        public static bool IsItPrinted { get; set; } = false;
        public bool AddingInProgress { get; set; } = false;
        public static Invoice GlobalInvoice { get; set; } = null;
        public int RadioChecked { get; set; } = 0;
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

                var processInfo = new ProcessStartInfo(Application.StartupPath + @"\API\NetworkSynq.exe", "")
                {
                    WorkingDirectory = Application.StartupPath + @"\API\"
                ,
                    CreateNoWindow = true
                ,
                    UseShellExecute = false
                };
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
                if (POS.Any(x => x.ID == item.ID))
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
                if (POS.Any(x => x.ID == item.ID))
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
                        { RetryConnection(); }
                        else { /*APIAccess = false;*/ }
                    }
                    else
                    {
                        repeatedBehavior.AreYouSure("تعذر الإتصال بالخادم", "خطأ بالإتصال");

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

        private async void RetryConnection()
        {

            if (!DbInv.AreYouAlive())
            {
                this.Focus();
                if (repeatedBehavior.AreYouSure("هل تريد إعادة تشغيل السيرفر؟" + Environment.NewLine + "Yes = إعادة تشغيل السيرفر + No = إعتمد على الشبكة المحلية ", "فشلت عملية التزامن"))
                {
                    KillandRestartAPI();

                }
                else { this.Text = "****Local Connection****"; }
            }

        }

        List<POSsections> lists = new List<POSsections>();

        private void LoadMethods()
        {
            if (Properties.Settings.Default.showMenu &&
                 Screen.AllScreens.Count() > 1 &&
                 DisplayMenu_.DM.Visibility != System.Windows.Visibility.Visible)
            {


                DisplayMenu_.DM.Show();
                _ = DisplayMenu_.DM.LaunchMenu(MenuDB.GetMenuItems(MenuDB.GetMenus().First()), MenuDB.GetMenus().First(), langCheck.Checked, Properties.Settings.Default.ItemSize);

            }
            LoadMaterials();
            POS.ListChanged += POS_ListChanged;
            UIVisuals();
            ShowSalahTimes();
            AmountLBL.TextChanged += AmountLBL_TextChanged1;
            this.UpdatedDraft += UpdateDraft;
        }
        private void AmountLBL_TextChanged1(object sender, EventArgs e)
        {
            if (!AddingInProgress)
            {
                ItemCount.Text = CalculateItemCount();
            }

        }
        private string CalculateItemCount()
        {
            int count = 0;
            if (!AddingInProgress)
            {
                POS.ToList().ForEach((x) => { count += x.RealQuantity; });
            }
            return count.ToString();
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
                if (POS.Count > 0)
                {
                    decimal total = POS.Sum((a) => a.TotalPrice);
                    AmountLBL.Text = total.ToString();

                    if (POS.Any(x => x.discount))
                    {
                        if (POS.IndexOf(POS.First(x => x.discount)) != POS.Count - 1)
                        {
                            POS.ListChanged -= POS_ListChanged;
                            POS.Move(POS.IndexOf(POS.First(x => x.discount)), POS.Count - 1);
                            POS.ListChanged += POS_ListChanged;
                        }
                    }
                }
                else
                {
                    AmountLBL.Text = "0.0";
                    ItemCount.Text = "0";
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
                    bool MoblieTBfocused = this.ActiveControl == CommentTB;
                    if (MoblieTBfocused) MobileTB.Focus();
                    else SelectNextControl(ctrl, true, true, true, true);
                }
                else if (e.KeyCode == Keys.Up)
                {
                    bool MoblieTBfocused = this.ActiveControl == MobileTB;
                    if (MoblieTBfocused) CommentTB.Focus();
                    else SelectNextControl(ctrl, false, true, true, true);
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
            DhuhrBTN.Text = DateTime.Parse(times.Dhuhr.ToString()).ToString("hh:mm tt");
            AsrBTN.Text = DateTime.Parse(times.Asr.ToString()).ToString("hh:mm tt");
            MaghribBTN.Text = DateTime.Parse(times.Maghrib.ToString()).ToString("hh:mm tt");
            IshaBTN.Text = DateTime.Parse(times.Isha.ToString()).ToString("hh:mm tt");
            DayLBL.Text = Orders.GetDayName((int)DateTime.Now.DayOfWeek);
            DateLBL.Text = DateTime.Now.ToString("dd/MM/yyyy");
            SalahTMR.Start();
        }
        bool afterPrayers = false;
        private void SalahTMR_Tick(object sender, EventArgs e)
        {
            TimeButton.Text = DateTime.Now.ToString("hh:mm tt");
            if (SalahPanels.Size != new Size(321, 63))
            {
                return;
            }
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
            dvItems.DataSource = POS;
            List<string> ColumnsList = new List<string>();
            // create a foreach loop to loop through columns and delete some of them that don't meet a certain condition
            foreach (DataGridViewColumn x in dvItems.Columns)
            {
                if (x.DataPropertyName == "Name" || x.DataPropertyName == "Quantity" || x.DataPropertyName == "Price" || x.DataPropertyName == "TotalPrice" || x.DataPropertyName == "Comment" || x.Name == "btnColumn")
                {
                    continue;
                }
                ColumnsList.Add(x.Name);
            }

            ColumnsList.ForEach(x => dvItems.Columns.Remove(x));

            OrderStatus.Text = InvoiceTypeOptions.Items[Properties.Settings.Default.defaultOrder].Text; ;
            dvItems.Columns["Name"].Width = 120;// Name
            dvItems.Columns["Name"].HeaderText = "إسم المادة";
            dvItems.Columns["Name"].ReadOnly = true;

            dvItems.Columns["Quantity"].Width = 45;// Quantity
            dvItems.Columns["Quantity"].HeaderText = "العدد";



            dvItems.Columns["Price"].Width = 45;// Price
            dvItems.Columns["Price"].HeaderText = "سعر";
            dvItems.Columns["Price"].ReadOnly = true;



            dvItems.Columns["TotalPrice"].Width = 55;// TotalPrice
            dvItems.Columns["TotalPrice"].HeaderText = "إجمالي";
            dvItems.Columns["TotalPrice"].ReadOnly = true;

            dvItems.Columns["Comment"].Width = 170;// Comment
            dvItems.Columns["Comment"].HeaderText = "ملاحظات";
            dvItems.Refresh();
            dvItems.Update();

            dvItems.Columns["Comment"].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;

            dvItems.MouseWheel += new MouseEventHandler(DataGridView1_MouseWheel);

            if (dvItems.Columns["btnColumn"] != null) return;

            var btnColumn = new DataGridViewButtonColumn
            {
                HeaderText = "م",
                Name = "btnColumn",
                Text = "ملاحظة سريعة",
                UseColumnTextForButtonValue = true,
                Width = 20
            };
            dvItems.Columns.Add(btnColumn);

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
                        if (currentItem.Quantity <= 0) currentItem.Quantity = 1;
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
                if (dvItems.IsCurrentCellInEditMode)
                {

                    return;
                }

                int rowIndex = dvItems.HitTest(e.X, e.Y).RowIndex;

                // check if any cell is in edit mode
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

                try
                {
                    string n = Environment.NewLine;
                    if (MessageForm.SHOW(ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString() ?? "" + n + Properties.Settings.Default.API_Server_Path + n + Properties.Settings.Default.API_Connection, "معلومات", "تم", "إغلاق التزامن") == DialogResult.No)
                    {
                        if (Process.GetProcessesByName("NetworkSynq").Length >= 0)
                        {
                            foreach (var process in Process.GetProcessesByName("NetworkSynq"))
                            {
                                process.Kill();
                            }
                        }
                    }

                }
                catch (Exception)
                {

                    string n = Environment.NewLine;
                    if (MessageForm.SHOW(Properties.Settings.Default.API_Server_Path + n + Properties.Settings.Default.API_Connection, "معلومات", "تم", "إغلاق التزامن") == DialogResult.No)
                    {
                        if (Process.GetProcessesByName("NetworkSynq").Length >= 0)
                        {
                            foreach (var process in Process.GetProcessesByName("NetworkSynq"))
                            {
                                process.Kill();
                            }
                        }
                    }
                }
            }//else if shift is pressed show logform();
            else if (ModifierKeys.HasFlag(Keys.Shift))
            {
                new LogForm().Show();
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

                }

            }
        }

        private void PrintSave_Click(object sender, EventArgs e)
        {
            MobileTB.Focus();
            if (POS.Count > 0)
            {
                GlobalInvoice = null;
                GlobalInvoice = PrintNewInvoice();
                InvID = Convert.ToInt32(InvoiceNumberID.Text);
                if (!GlobalInvoice.Equal(DbInv.GetInvoiceByID(InvID)))
                {
                    PrintingLogic();
                    Contacts customer = new Contacts(NameTB.Text, MobileTB.Text, CommentTB.Text);
                    dbQ.SaveContacts(customer);
                    Invoice PNI = PrintNewInvoice();
                    if (PNI.OrderType == "تطبيقات")
                    {
                        PNI.TimeOfPrinting = DateTime.Now.ToString("hh:mmtt dd/MM/yy");
                        PNI.TimeOfSaving = DateTime.Now.AddTicks(-(DateTime.Now.Ticks % TimeSpan.TicksPerSecond));
                        PNI.Status = InvStat.SavedToPOS;
                        PNI.POSInvoiceNumber = "جاهز";
                        var payment = new Payment() { Name = "Jahez", Amount = PNI.InvoicePrice };
                        PNI.Payments.Add(payment);
                    }
                    else
                    {

                        Custom_Classes.CreateOffer.CreateOfferNow(PrintNewInvoice(), true);
                    }
                    PNI.TimeOfPrinting = DateTime.Now.ToString("hh:mmtt dd/MM/yy");

                    DbInv.UpdatePreparingInvoice(PNI);
                    var se = sender;
                    if (sender.GetType() == typeof(int))
                    {
                        IsItPrinted = true;
                    }
                    else if (se.GetType() == typeof(string))
                    {
                        NewBTN_Click(null, null);

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
            if (!IsItPrinted && POS.Count > 0 && se != null) { if (MessageForm.SHOW("هل تريد حذف الفاتورة وبدء فاتورة جديدة؟", " تحذير الفاتورة غير مطبوعة", "نعم", "لا") == DialogResult.No) return; };
            try
            {
                AddingInProgress = true;
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

                NameTB.Clear();
                MobileTB.Clear();
                TimeTB.Clear();
                DOWTB.Clear();
                CommentTB.Clear();
                POS.Clear();
                TimeInfo.Text = "الآن";
                AmountLBL.Text = "0.00";
                DayMenuBTN.Text = GetDayName((int)DateTime.Now.DayOfWeek);
                OrderStatus.Text = InvoiceTypeOptions.Items[Properties.Settings.Default.defaultOrder].Text;
                OrdersPanel.Enabled = true;
                dvItems.BackgroundColor = Color.GhostWhite;
                HoldInvoice.Enabled = true;
                displayOffer.CloseNow();
                Refresh();
                AddingInProgress = false;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }




        }

        private void OrdersPage_Click(object sender, EventArgs e)
        {
            // if control is pressed()

            LoadOrders();
            if (ModifierKeys.HasFlag(Keys.Control))
            {
                if (Properties.Settings.Default.Api_On && !Properties.Settings.Default.showMenu)
                {
                    if (Screen.AllScreens.Count() > 1)
                    {
                        if (Application.OpenForms.OfType<ReadyOrders>().Any())
                        {
                            Application.OpenForms.OfType<ReadyOrders>().First().BringToFront();
                            Application.OpenForms.OfType<ReadyOrders>().First().Activate();

                        }
                        else
                        {
                            var readyOrders = new ReadyOrders();
                            readyOrders.Show();
                        }
                    }

                }
            }



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
            //LastOrder.Visible = false;
            //EditName.Visible = false;
            GridUIPrinted();

        }

        private void CheckDay()
        {

            var days = DateTime.Now.DayOfWeek;

            RadioButtons()[days].Checked = true;
            Fri_CheckedChanged(RadioButtons()[days], null);
        }
        private Dictionary<DayOfWeek, RadioButton> RadioButtons()
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
                if (Enum.TryParse(se.Name, out CustomDaysOfWeek daysOfWeek))
                {
                    RadioChecked_((int)daysOfWeek);
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
                StopEditing = true;
                IsItPrinted = true;
                HoldInvoice.Enabled = false;
                ButtonStates(true);
                OrdersPanel.Enabled = true;
                InvoiceNumberID.Text = heldInv.ID.ToString();
                MobileTB.Text = heldInv.CustomerNumber;
                NameTB.Text = heldInv.CustomerName;
                TimeTB.Text = heldInv.TimeAMPM;
                DayMenuBTN.Text = GetDayName((int)heldInv.InvoiceDay);
                CommentTB.Text = heldInv.Comment;
                OrderStatus.Text = heldInv.OrderType;
                // set InvoiceTypeOptions button to the button matching the heldnv.OrderType
                foreach (ToolStripButton item in InvoiceTypeOptions.Items)
                {
                    if (item.Text == heldInv.OrderType)
                    {
                        item.PerformClick();
                        break;
                    }
                }
                FillPOS(heldInv.InvoiceItems);
                this.OrdersContainer.Visible = false;
                this.OrdersPanel.Visible = true; this.OrdersPanel.BringToFront();

                // start a timer of 5 seconds to do this code : StopEditing = false;
                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer
                {
                    Interval = 800
                };
                timer.Tick += (s, e) =>
                {
                    StopEditing = false;
                    timer.Stop();
                    timer.Dispose();
                };
                timer.Start();



                return;
            }
            else if (heldInv.Status == InvStat.SavedToPOS)
            {
                if (History.Checked || heldInv.OrderType == "تطبيقات")
                {
                    StopEditing = true;
                    IsItPrinted = true;

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
                    var tt = new ToolTip
                    {
                        UseAnimation = false,
                        UseFading = false,
                        ToolTipTitle = "معلومات الطلب"
                    };
                    string msg = $"تم التخزين: {heldInv.TimeOfSaving} {Environment.NewLine} تمت الطباعة: {heldInv.TimeOfPrinting} {Environment.NewLine} وسيلة الدفع: {heldInv.PaymentName}";
                    tt.Show(msg, InvoiceNumberID, 20000);
                    return;
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

        }
        private void FillPOS(List<POSItems> list)
        {

            //AddingInProgress = true;
            POS.Clear();
            foreach (POSItems item in list.OrderBy(x => x.discount))
            {
                POS.Add(item);
            }
            //AddingInProgress = false;
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
                //LastOrder.Visible = false;
                //EditName.Visible = false;


            }
            else
            {
                PrintSave.Enabled = false;
                SaveInvoice.Enabled = true;
                DeleteInvoice.Enabled = false;
                RepeatOrder.Visible = true;
                HoldInvoice.Enabled = false;
            }
        }

        private void TimeInfo_Click(object sender, EventArgs e)
        {
            string result = TimePicker.SHOW();

            if (result.Length > 1)
            {
                TimeTB.Text = result;
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
            if (Cind == 5)
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
                if (dvItems.RowCount > 0 && dvItems.SelectedRows.Count != -1 && Rind != -1 && Cind != 4)
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

        private void MobileTB_TextChanged(object sender, EventArgs e)
        {
            MobileLBL.Visible = string.IsNullOrWhiteSpace(MobileTB.Text);
            NameLBL.Visible = string.IsNullOrWhiteSpace(NameTB.Text);
            label1.Visible = string.IsNullOrWhiteSpace(TimeTB.Text);
            label3.Visible = string.IsNullOrWhiteSpace(DOWTB.Text);
            CommentLBL.Visible = string.IsNullOrWhiteSpace(CommentTB.Text);
            if (!string.IsNullOrWhiteSpace(MobileTB.Text) && !InvoiceTypeOptions.Items.Find("DineButton", false).First().Pressed)
            {
                InvoiceTypeOptions.Items.Find("TelButton", false).First().PerformClick();
            }
            else
            {
                if (string.IsNullOrEmpty(MobileTB.Text) && string.IsNullOrEmpty(NameTB.Text) && !InvoiceTypeOptions.Items.Find("DineButton", false).First().Pressed && !InvoiceTypeOptions.Items.Find("AppsButton", false).First().Pressed)
                {
                    InvoiceTypeOptions.Items.Find("ToGoButton", false).First().PerformClick();
                }
            }

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
                AppsSettings.Visible = OrderStatus.Text == "تطبيقات";

            }

        }
        private void MainMenu_Click(object sender, EventArgs e)
        {
            if (OrdersContainer.Visible)
            {
                OrdersContainer.Visible = false;
                this.OrdersPanel.Visible = true;
                this.OrdersPanel.BringToFront();
            }
            else
            {
                AmountLBL_TextChanged1(null, null);
            }


        }

        #region Invoices


        private List<Invoice> GetListwithFilters()
        {
            var list = DbInv.GetSavedInvoices();

            // list all checked items in FilterMenu 
            // protect against finding a seperator in the list
            // avoid null seperator in the cast
            var checkedItems = FilterMenu.Items.OfType<ToolStripMenuItem>().Cast<ToolStripMenuItem>()
                .Where(item => item is ToolStripMenuItem && item.Checked)
                .Select(item => item.Name)
                .ToList();

            if (checkedItems.Any(item => item == todaysFilter.Name))
            {
                // account for if x.TimeOfSaving is null 
                return list.Where(x => x.TimeOfSaving != null && x.TimeOfSaving.Date == DateTime.Now.Date).ToList();
            }
            if (checkedItems.Any(item => item == jahezFilter.Name))
            {
                return list.Where(x => x.OrderType == "تطبيقات").ToList();
            }
            else if (checkedItems.Any(item => item == notJahezFilter.Name))
            {
                return list.Where(x => x.OrderType != "تطبيقات" && x.Status != InvStat.Deleted).ToList();
            }
            if (checkedItems.Any(item => item == deletedFilter.Name))
            {
                return list.Where(x => x.Status == InvStat.Deleted).ToList();
            }
            if (checkedItems.Any(item => item == savingTimeFilter.Name))
            {
                //sort list by time of saving with a null check
                return list.Where(x => x.TimeOfSaving != null).OrderByDescending(x => x.TimeOfSaving).ToList();
            }
            if (checkedItems.Any(item => item == multiPaymentFilter.Name))
            {
                //sort list by time of saving with a null check
                return list.Where(x => x.PaymentName != null && x.PaymentName == "دفع متعدد").ToList();

            }
            else if (checkedItems.Any(item => item == CashFilter.Name))
            {
                //sort list by time of saving with a null check
                return list.Where(x => x.PaymentName != null && x.PaymentName == "Cash").ToList();
            }
            else if (checkedItems.Any(item => item == madaFilter.Name))
            {
                //sort list by time of saving with a null check
                return list.Where(x => x.PaymentName != null && x.PaymentName == "Mada").ToList();
            }
            else return list;
        }



        /// <summary>
        /// الأيام والتاريخ
        /// </summary>
        /// <param name="day"></param>
        private void RadioChecked_(int day)
        {
            if (day == 100)
            {
                var GetSavedlist = GetListwithFilters();

                InvoicesDG.DataSource = GetSavedlist;
                RadioChecked = day;
                CountLBL.Text = InvoicesDG.RowCount.ToString();
                GridUISaved();


            }
            else if (day == -1)
            {
                InvoicesDG.DataSource = DbInv.GetPrintedInvoices();
                RadioChecked = day;
                CountLBL.Text = InvoicesDG.RowCount.ToString();
                GridUIPrinted();
            }
            else if (day == -2)
            {
                InvoicesDG.DataSource = DbInv.GetDraftInvoices();
                CountLBL.Text = InvoicesDG.RowCount.ToString();
                RadioChecked = day;

            }
            else
            {
                RadioChecked = day;
                InvoicesDG.DataSource = DbInv.GetPrintedInvoices().Where(x => (int)x.InvoiceDay == day).ToList();
                CountLBL.Text = InvoicesDG.RowCount.ToString();
                GridUIPrinted();
            }

        }


        private void GridUISaved()
        {
            if (InvoicesDG.Columns.Count == 0)
            {
                return;
            }
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
            if (InvoicesDG.Columns.Count == 0)
            {
                return;
            }
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
        private void Orders_Load(object sender, EventArgs e)
        {
            Screen[] screens = Screen.AllScreens;
            Screen screen1 = screens[0];
            this.Left = screen1.WorkingArea.Width - Width;
            this.Top = screen1.WorkingArea.Height - Height;

            LoadApps();


            APIConnection = Properties.Settings.Default.API_Connection;
            Servermode = Properties.Settings.Default.Api_Server;


            //Properties.Settings.Default.DBConnection = @"Filename =C:\db\db.db;connection=Shared";
            //Properties.Settings.Default.Save();



            MyCheckBox = this.checkBox1;

            if (APIAccess)
            {
                this.Text = Title + " API MODE ";
            }
            else this.Text = Title + " Local Network Mode";
            //dbQ.CreatePayment();
            if (Servermode && APIAccess)
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
                    var processInfo = new ProcessStartInfo(Application.StartupPath + @"\API\NetworkSynq.exe", "")
                    {
                        WorkingDirectory = Application.StartupPath + @"\API\",
                        CreateNoWindow = true,
                        UseShellExecute = false
                    };
                    Process.Start(processInfo);
                }
                while (Process.GetProcessesByName("NetworkSynq").Length == 0)
                {
                    Thread.Sleep(200);
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

        private void DvItems_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                dvItems.Rows[e.RowIndex - 1].Selected = true;
            }
            else if (dvItems.Rows.Count > 0) dvItems.Rows[e.RowIndex].Selected = true;
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
            if (POS.Count == 0) return;
            int NoNewClick = 0;

            this.Activate();
            var SaveToPOS = PrintNewInvoice();

            if (ModifierKeys.HasFlag(Keys.Control))
            {
                if (!string.IsNullOrEmpty(SaveToPOS.TimeOfPrinting)) SaveToPOS.TimeOfPrinting = DateTime.Now.ToString("hh:mmtt dd/MM/yy");
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
                                DialogResult dialogResult = MessageForm.SHOW("هل تريد إعادة الطباعة؟", "تم تعديل الفاتورة", "نعم، أعد الطباعة", "لا شكراً");
                                if (dialogResult == DialogResult.Yes)
                                {
                                    PrintSave_Click(NoNewClick, null);
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

                                PrintSave_Click(NoNewClick, null);
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
                            DialogResult dialogResult = MessageForm.SHOW("هل تريد إعادة الطباعة؟", "تم تعديل الفاتورة", "نعم، أعد الطباعة", "لا شكراً");
                            if (dialogResult == DialogResult.Yes)
                            {
                                PrintSave_Click(NoNewClick, null);
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
                            PrintSave_Click(NoNewClick, null);
                            Save2POS(SaveToPOS);
                            return;
                        }
                    }
                }
                else
                {
                    MessageForm.SHOW("حاليا لا نقوم بتخزين طلبات التطبيقات، ستتم إضافة الميزة لاحقا", "لست بحاجة لتخزين الطلبات حاليا", "مفهوم");

                }
            }
        }
        private void Save2POS(Invoice SaveToPOS)
        {
            this.Hide();
            ShowMenuBTN.BackColor = Color.SlateGray;
            if (NewPayForm(SaveToPOS).ShowDialog() == DialogResult.OK)
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
                this.BringToFront();
                this.Activate();
                return;
            }
        }



        private void FastComment_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            FastComment.Items.Clear();

        }

        private void Label7_Click(object sender, EventArgs e)
        {
            dvItems.Focus();
            SendKeys.Send("{PGDN}");

        }

        private void Label5_Click(object sender, EventArgs e)
        {
            dvItems.Focus();
            SendKeys.Send("{PGUP}");


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





        private void ShowMenuBTN_Click(object sender, EventArgs e)
        {
            if (POS.Count() > 0)
            {

                if (!Properties.Settings.Default.showMenu) return;
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
                await DisplayMenu_.DM.LaunchMenu(MenuDB.GetMenuItems(a), a, langCheck.Checked, Properties.Settings.Default.ItemSize);
            }
        }

        private void ShowMenu_Click(object sender, EventArgs e)
        {

            if (Screen.AllScreens.Count() > 1)
            {

                if (DisplayMenu_.DM.Visibility != System.Windows.Visibility.Visible)
                {
                    DisplayMenu_.DM.Show();
                    _ = DisplayMenu_.DM.LaunchMenu(MenuDB.GetMenuItems(MenuDB.GetMenus().First()), MenuDB.GetMenus().First(), langCheck.Checked, Properties.Settings.Default.ItemSize);

                }
                else MenuSelection.Show(Cursor.Position);

            }

        }

        private void MenuTimeOut_Tick(object sender, EventArgs e)
        {
            _ = DisplayMenu_.DM.LaunchMenu(MenuDB.GetMenuItems(MenuDB.GetMenus().First()), MenuDB.GetMenus().First(), langCheck.Checked, Properties.Settings.Default.ItemSize);
            MenuTimeOut.Stop();

        }


        private void ItemNameTag_Click(object sender, EventArgs e)
        {
            string text = "هل تريد تغيير حالة المادة؟";
            DialogResult dialogResult = MessageForm.SHOW(text, "تعديل حالة توفر المادة", "المادة متوفرة", "المادة غير متوفرة");

            var s = (ToolStripMenuItem)sender;
            var item = (string)s.GetCurrentParent().Tag;

            if (dialogResult == DialogResult.Yes)
            {
                dbQ.MatAvailableSet(item, true);
            }
            else dbQ.MatAvailableSet(item, false);
            langCheck.Checked = !langCheck.Checked;
            langCheck.Checked = !langCheck.Checked;

            /////////// To Be Programmed.
        }

        private void RepeatOrder_Click(object sender, EventArgs e)
        {
            List<POSItems> NewPrices = new List<POSItems>();

            foreach (var i in POS.Where(x => !x.discount))
            {
                var a = ItemsLists.First(x => x.Barcode == i.Barcode);
                if (a != null)
                {
                    a.Quantity = i.Quantity;
                    a.Comment = i.Comment;
                    NewPrices.Add(a);
                }
            }
            NameTB.Text += " ";
            MobileTB.Text += " ";
            string name = " " + NameTB.Text;
            string number = MobileTB.Text;

            NewBTN_Click(null, null);
            NewPrices.ForEach(x => POS.Add(x));
            NewPrices.Clear();
            if (MessageForm.SHOW("هل تريد إستخدام الإسم والرقم؟", "هل الطلب لنفس العميل؟", "نعم", "لا") == DialogResult.Yes)
            {
                NameTB.Text = name;
                MobileTB.Text = number;
            }


        }

        private void LastOrder_Click(object sender, EventArgs e)
        {
            OrdersPage_Click(null, null);
            History.Checked = true;
            this.SearchTB.Text = MobileTB.Text;
            Search_Click(null, null);
            this.OrdersFlowLayoutPanel.Visible = true; this.OrdersFlowLayoutPanel.BringToFront();
            this.OrdersContainer.Visible = true; this.OrdersContainer.BringToFront();
            this.OrdersPanel.Visible = false;
            GridUISaved();
        }

        string jahezID;

        #region DragAndDropJahezWhatsapp
        private void DvItems_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        private void DvItems_DragDrop(object sender, DragEventArgs e)
        {


            ParseInvoices(e.Data.GetData(DataFormats.UnicodeText).ToString());

        }
        string totalamount;

        private async void ParseInvoices(string Invoicedata)
        {
            string JahezParser = "";
            JahezParser = Invoicedata;
            Match match = Regex.Match(JahezParser, @"^\d\r?");

            #region Jahez
            if (Invoicedata.Contains("Order#"))
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
                var mymatches = Regex.Matches(input, pattern);
                if (mymatches.Count == 0)
                {
                    return;
                }
                foreach (Match m in mymatches)
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
                        var New = new POSItems
                        {
                            Name = Item.Name,
                            Quantity = Item.Quantity,
                            PrinterName = Item.PrinterName,
                            realquan = Item.realquan,
                            Barcode = Item.Barcode,
                            ID = Item.ID,
                            Parent = Item.Parent,
                            Available = Item.Available
                        };
                        if (Decimal.TryParse(Price, out decimal decimalPrice))
                        {
                            // Conversion successful
                            New.Price = decimalPrice / Item.Quantity;
                        }
                        else
                        {
                            New.Price = Item.Price;
                        }
                        if (barcode == "010052")
                        {
                            New.Comment = ProductName;
                        }
                        Item.printerlist.ForEach(x => New.printerlist.Add(x));
                        OrderStatus.Text = "تطبيقات";
                        POS.Add(New);

                    }
                }
                if (!DbInv.GetLastSaveApps().Exists(x => x.CustomerName == jahezID) && !DbInv.GetPrintedInvoices().Exists(x => x.CustomerName == jahezID))
                {
                    if (DbInv.GetInvoiceByID(Convert.ToInt32(InvoiceNumberID.Text)).Status == InvStat.Draft)
                    {
                        string printJahez = string.Empty;
                        PrintSave_Click(printJahez, null);
                    }
                    else { MessageForm.SHOW("ربما تقوم بنسخ فاتورة جاهز فوق فاتورة معدة من قبل الرجاء بدء فاتورة جديدة", "تنويه", "مفهوم"); }
                }
                else
                {
                    MessageForm.SHOW("ربما قمت بتخزين هذا الطلب من قبل", "تنويه", "مفهوم");
                }

                return;

            }
            #endregion
            #region HungerStation
            else if (Invoicedata.Contains('×') && Invoicedata.Contains("تفاصيل الطلب"))
            {
                string HungerParser = string.Empty;
                HungerParser = Invoicedata;
                string patternComment = @"firstword\s*(.*?)\s*lastword";
                Match matchnew = Regex.Match(Invoicedata.Replace("تفاصيل الطلب الإضافية", "firstword").Replace("نوع التوصيل", "lastword"), patternComment);
                CommentTB.Text = matchnew.Success ? matchnew.Groups[1].Value : "";
                POS.Clear();
                string MatParser = "";
                var OrderID = HungerParser.Split('\n')[0];
                NameTB.Text = "هنقر:" + OrderID.Trim();
                string oldname = "هنقر:" + OrderID.Trim();
                var MatParser2 = HungerParser.Substring(HungerParser.IndexOf("تفاصيل الطلب")).Replace("تفاصيل الطلب", "");
                Match match1 = Regex.Match(HungerParser.Replace("المجموع الفرعي", "totaly").Replace("تفاصيل الطلب الإضافية", "details").Replace(" ر.س.", "").Replace("\u200F", ""), @"(totaly)\s*(.*?)\s*(details)");
                string totalamount = match1.Groups[2].Value.Trim();
                MatParser = MatParser2.Substring(0, MatParser2.LastIndexOf("المجموع الفرعي")).Replace(" ر.س.", "").Replace("\u200F", "").Replace("\r", "").Replace("\n\n", "\n").Replace('\u00D7', 'x');
                string patterns = @"^(\d+)x\s*(.*?)\s*(\d+\.\d{2})$";
                var mat4Hunger = DbInv.LoadApp("hungerstation");

                MatchCollection matches2 = Regex.Matches(MatParser, patterns, RegexOptions.Multiline);
                if (matches2.Count == 0) return;
                foreach (Match matchhunger in matches2)
                {

                    var Quantity = matchhunger.Groups[1].Value;
                    var ProductName = matchhunger.Groups[2].Value;
                    var Price = matchhunger.Groups[3].Value;
                    string barcode;
                    if (mat4Hunger.list.Any(x => x.Name == ProductName.Trim()))
                    {
                        barcode = mat4Hunger.list.First(z => z.Name == ProductName.Trim()).Barcode;
                        var Item = ItemsLists.First(x => x.Barcode == barcode);
                        if (Item != null)
                        {
                            Item.Comment = string.Empty;
                            var New = new POSItems
                            {
                                Name = Item.Name,
                                Quantity = Convert.ToInt32(Quantity),
                                realquan = Item.realquan,
                                Barcode = Item.Barcode,
                                ID = Item.ID,
                                Parent = Item.Parent,
                                Available = Item.Available
                            };
                            if (Decimal.TryParse(Price, out decimal decimalPrice))
                            {
                                // Conversion successful
                                New.Price = decimalPrice / Convert.ToDecimal(New.Quantity);
                            }
                            else
                            {
                                New.Price = Item.Price;
                            }
                            if (barcode == "010052")
                            {
                                New.Comment = ProductName;
                            }
                            Item.printerlist.ForEach(x => New.printerlist.Add(x));
                            POS.Add(New);
                        }
                    }

                }
                OrderStatus.Text = "تطبيقات";
                if (AmountLBL.Text != totalamount) { MessageForm.SHOW("قد يكون هناك خطأ في أحد المواد لأن المبالغ لم تتطابق", "تنبيه", "مفهوم"); return; }

                if (!DbInv.GetLastSaveApps().Exists(x => x.CustomerName.Trim() == oldname.Trim()))
                {
                    if (DbInv.GetInvoiceByID(Convert.ToInt32(InvoiceNumberID.Text)).Status == InvStat.Draft)
                    {
                        string printJahez = string.Empty;
                        PrintSave_Click(printJahez, null);
                    }
                    else { MessageForm.SHOW("ربما تقوم بنسخ فاتورة جاهز فوق فاتورة معدة من قبل الرجاء بدء فاتورة جديدة", "تنبيه", "مفهوم"); }
                }
                else
                {
                    MessageForm.SHOW("ربما قمت بتخزين هذا الطلب من قبل", "تنبيه", "مفهوم");
                }
                return;
            }
            #endregion

            #region Mrsool
            else if (Invoicedata.Contains("رمز التحقق") || Invoicedata.Contains("حي السليمانية"))
            {
                string MrsoolParser = string.Empty;
                MrsoolParser = Invoicedata;


                Match orderMatch = Regex.Match(Invoicedata, @"#(\d+)");
                var OrderID = orderMatch.Value;
                NameTB.Text = "مرسول:" + OrderID.Trim();
                string oldname = "مرسول:" + OrderID.Trim();

                string commentPattern = @"رمز التحقق: (\d+)";
                Match VerificationCode = Regex.Match(Invoicedata, commentPattern);
                CommentTB.Text = VerificationCode.Success ? VerificationCode.Value : "";
                string totalPricePattern = @"(\d+\.\d{2}) sar\s*نقبل";
                Match totalPriceMatch = Regex.Match(Invoicedata, totalPricePattern);
                if (totalPriceMatch.Success)
                {
                    totalamount = totalPriceMatch.Groups[1].Value;
                }
                else
                {
                    string totalPricePattern2 = @"(\d+\.\d{2}) sar\s*الفرع";
                    Match totalPriceMatch2 = Regex.Match(Invoicedata, totalPricePattern2);
                    if (totalPriceMatch2.Success)
                    {
                        totalamount = totalPriceMatch2.Groups[1].Value;
                    }
                }


                //string patternDriverNo = @"\+\d+";
                //Match DriverNo = Regex.Match(Invoicedata, patternDriverNo);
                //MobileTB.Text = DriverNo.Success ? DriverNo.Value : "";
                POS.Clear();
                string MatParser = Invoicedata.Replace('×', 'x');

                string[] lines = MatParser.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                MatParser = string.Join(Environment.NewLine, lines);
                string patterns = @"(.*?)\s*(\d+)x\s*(\d+\.\d{2})";
                var mat4Mrsool = DbInv.LoadApp("mrsool");

                MatchCollection materialMatches = Regex.Matches(MatParser, patterns, RegexOptions.Multiline);
                if (materialMatches.Count == 0) return;
                foreach (Match matchMrsool in materialMatches)
                {
                    Console.WriteLine("Quantity: " + matchMrsool.Groups[2].Value);
                    Console.WriteLine("Name: " + matchMrsool.Groups[1].Value);
                    Console.WriteLine("Price: " + matchMrsool.Groups[3].Value);

                    var ProductName = matchMrsool.Groups[1].Value;
                    var Quantity = matchMrsool.Groups[2].Value;
                    var Price = matchMrsool.Groups[3].Value;
                    string barcode;
                    if (mat4Mrsool.list.Any(x => x.Name == ProductName.Trim()))
                    {
                        barcode = mat4Mrsool.list.First(z => z.Name.Trim() == ProductName.Trim()).Barcode;
                        var Item = ItemsLists.First(x => x.Barcode == barcode);
                        if (Item != null)
                        {
                            Item.Comment = string.Empty;
                            var New = new POSItems
                            {
                                Name = Item.Name,
                                Quantity = Convert.ToInt32(Quantity),
                                realquan = Item.realquan,
                                Barcode = Item.Barcode,
                                ID = Item.ID,
                                Parent = Item.Parent,
                                Available = Item.Available
                                ,
                                Price = Convert.ToDecimal(Price)
                            };

                            if (barcode == "010052")
                            {
                                New.Comment = ProductName;
                            }
                            Item.printerlist.ForEach(x => New.printerlist.Add(x));
                            POS.Add(New);
                        }
                    }

                }
                OrderStatus.Text = "تطبيقات";
                if (AmountLBL.Text != totalamount) { MessageForm.SHOW("قد يكون هناك خطأ في أحد المواد لأن المبالغ لم تتطابق", "تنبيه", "مفهوم"); return; }

                if (!DbInv.GetLastSaveApps().Exists(x => x.CustomerName.Trim() == oldname.Trim()))
                {
                    if (DbInv.GetInvoiceByID(Convert.ToInt32(InvoiceNumberID.Text)).Status == InvStat.Draft)
                    {
                        string printJahez = string.Empty;
                        PrintSave_Click(printJahez, null);
                    }
                    else { MessageForm.SHOW("ربما تقوم بنسخ فاتورة  فوق فاتورة معدة من قبل الرجاء بدء فاتورة جديدة", "تنبيه", "مفهوم"); }
                }
                else
                {
                    MessageForm.SHOW("ربما قمت بتخزين هذا الطلب من قبل", "تنبيه", "مفهوم");
                }
                return;

            }
            #endregion

            #region Whatsapp
            else if (Invoicedata.Contains("الإجمالي المُقدَّر") || Invoicedata.Contains("estimated"))
            {
                if (Invoicedata.Contains("الإجمالي المُقدَّر"))
                {
                    POS.Clear();


                    try
                    {
                        string pattern = @"\""(.+)\""\s*(\d+)\s*\u200F.+٫..";
                        MatchCollection WhatsappMatches = Regex.Matches(Invoicedata, pattern, RegexOptions.Multiline);

                        foreach (Match matchWhatsapp in WhatsappMatches)
                        {
                            string whatsappBarcode = matchWhatsapp.Groups[1].Value;
                            string whatsappQuantity = matchWhatsapp.Groups[2].Value;

                            var Item = ItemsLists.First(x => x.Barcode == whatsappBarcode);
                            if (Item != null)
                            {
                                Item.Comment = "";
                                POSItems New = new POSItems()
                                {
                                    Name = Item.Name,
                                    Quantity = Convert.ToInt32(whatsappQuantity),
                                    Price = Item.Price,
                                    PrinterName = Item.PrinterName,
                                    realquan = Item.realquan,
                                    Barcode = Item.Barcode,
                                    ID = Item.ID,
                                    Parent = Item.Parent,
                                    Available = Item.Available
                                };
                                Item.printerlist.ForEach(x => New.printerlist.Add(x));

                                POS.Add(New);

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageForm.SHOW(ex.Message, ex.ToString(), "تنبيه", "مفهوم");
                    }

                    Double due = Convert.ToDouble(AmountLBL.Text);
                    string CartPrice = Regex.Match(Invoicedata, @"\u200F(.+٫..)").Captures[0].Value; ;
                    //String CartPrice2 = CartPrice.Replace("٫", ".").Replace("٠", "0").Replace("۱", "1").Replace("۲", "2").Replace("٣", "3").Replace("٤", "4").Replace("٥", "5").Replace("٦", "6").Replace("٧", "7").Replace("٨", "8").Replace("٩", "9");
                    if (Double.TryParse(ToEnglishNumbers(CartPrice), out Double decimalPrice))
                    {
                        if (due != decimalPrice)
                        {
                            MessageForm.SHOW("السعر لا يساوي السعر بالسلة", "تنبيه", "مفهوم");
                            return;
                        }
                        else
                        {
                            if (Invoicedata.Contains("contact"))
                            {
                                string keyword = "contact";
                                int index = Invoicedata.IndexOf(keyword) + keyword.Length;
                                string result = Invoicedata.Substring(index);
                                System.Windows.Clipboard.SetText(result);
                                PasteBTN_Click(null, null);
                            }


                        }
                    }


                }
            }


        }
        private static string ToEnglishNumbers(string input)
        {
            StringBuilder sbEnglishNumbers = new StringBuilder(string.Empty);
            input = input.Replace('٫', '.'); // Replace Arabic decimal separator with English decimal separator

            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i]))
                {
                    sbEnglishNumbers.Append(char.GetNumericValue(input, i));
                }
                else
                {
                    sbEnglishNumbers.Append(input[i].ToString());
                }
            }

            return sbEnglishNumbers.ToString();
        }

        #endregion
        #endregion
        private void Search_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SearchTB.Text) && SearchTB.Text.Length > 1)
            {
                InvoicesDG.CurrentCell = null;
                InvoicesDG.ClearSelection();
                if (RadioChecked != 100)
                {
                    if (RadioChecked != -1)
                    {
                        InvoicesDG.DataSource = DbInv.GetPrintedInvoices().Where(x => (int)x.InvoiceDay == RadioChecked && ToUnifiedArabic(x.SearchResult).Contains(ToUnifiedArabic(SearchTB.Text))).ToList();
                    }
                    else
                    {
                        InvoicesDG.DataSource = DbInv.GetPrintedInvoices().Where(x => ToUnifiedArabic(x.SearchResult).Contains(ToUnifiedArabic(SearchTB.Text))).ToList();
                    }
                }
                else
                {
                    if (ModifierKeys.HasFlag(Keys.Control))
                    {

                    }
                    else
                    {
                        InvoicesDG.DataSource = DbInv.GetAllSavedInvoicesDB(ToUnifiedArabic(SearchTB.Text)).OrderByDescending(x => x.TimeOfSaving).ThenBy(x => x.Status).ToList();
                    }


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


        private void XLabel_Click(object sender, EventArgs e)
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
                        // copy the file to the clipboard... // copy the file to the clipboard 
                        System.Collections.Specialized.StringCollection paths = new System.Collections.Specialized.StringCollection
                        {
                            details
                        };
                        System.Windows.Clipboard.SetFileDropList(paths);


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



        private void TelButton_Click_1(object sender, EventArgs e)
        {
            var se = sender as ToolStripButton;
            foreach (ToolStripButton btn in InvoiceTypeOptions.Items)
            {
                btn.Checked = false;
            }
            se.Checked = true;
            OrderStatus.Text = se.Text;
            if (se.Text == "تطبيقات")
            {

                dvItems.BackgroundColor = Color.FromArgb(255, 244, 244);
            }
            else if (se.Text == "محلي")
            {
                dvItems.BackgroundColor = Color.FromArgb(192, 192, 255);


            }
            else if (se.Text == "سفري")
            {

                dvItems.BackgroundColor = Color.GhostWhite;
            }
            else if (se.Text == "هاتف")
            {

                dvItems.BackgroundColor = Color.FromArgb(236, 255, 236);
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

        private void DayLBL_Click(object sender, EventArgs e)
        {
            if (ModifierKeys.HasFlag(Keys.Control))
            {
                MyMatReport m = new MyMatReport();
                m.Show();
            }
        }


        private void LangCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (DisplayMenu_.DM.Visibility != System.Windows.Visibility.Visible)
            {
                try
                {
                    DisplayMenu_.DM.Show();
                    _ = DisplayMenu_.DM.LaunchMenu(MenuDB.GetMenuItems(MenuDB.GetMenus().First()), MenuDB.GetMenus().First(), langCheck.Checked, Properties.Settings.Default.ItemSize);

                }
                catch (Exception)
                {

                }
            }
            else
            {
                _ = DisplayMenu_.DM.LaunchMenu(MenuDB.GetMenuItems(MenuDB.GetMenus().First()), MenuDB.GetMenus().First(), langCheck.Checked, Properties.Settings.Default.ItemSize);
            }
        }

        private void SaveAllJahez_MouseUp(object sender, MouseEventArgs e)
        {
            var menu = new ContextMenu();

            // create a lambda handler for the M clicked event


            DbInv.GetLastSaveApps().Take(20).ToList().ForEach(x =>
            {
                var M = new MenuItem
                {
                    Tag = x.ID,
                    Text = x.CustomerName
                };
                M.Click += (s, args) =>
                {
                    var se = s as MenuItem;
                    int setag = Convert.ToInt32(se.Tag);
                    LoadInvoiceUI(DbInv.GetInvoiceByID(setag));
                };
                menu.MenuItems.Add(M);
            });
            menu.Show(JahezToolStrip, new Point(0, 0));
        }





        private void InvoicesDG_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            Invoice item = (Invoice)InvoicesDG.Rows[e.RowIndex].DataBoundItem;
            if (History.Checked)
            {
                LoadInvoiceUI(item);
            }
            else
            {
                var Opened = DbInv.GetInvoiceByID(item.ID);
                LoadInvoiceUI(Opened);
            }

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
            else if (item.Status == InvStat.Deleted)
            {
                InvoicesDG.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightPink;
                InvoicesDG.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;

            }
            else
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

        private void Label2_Click(object sender, EventArgs e)
        {

            SearchTB.Clear();
            GetRadioDict()[RadioChecked].Checked = true;
            Fri_CheckedChanged(GetRadioDict()[RadioChecked], null);
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

                Orders.GlobalInvoice = CombinedInvoice;

                PrintInvoice.Print(dbQ.DefaultPrinters());
                GetRadioDict()[RadioChecked].Checked = true;
                Fri_CheckedChanged(GetRadioDict()[RadioChecked], null);


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
                    if (invoice == null) { MessageForm.SHOW("هناك مشكلة في أحد الفواتير المراد تخزينها، قم بتحديث قائمة الفواتير", "تحذير", "مفهوم"); return; }
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
                if (poslist.Any(p => p.discount))
                {
                    // group all items that has p.discount true in poslist into 1 item
                    var discountItems = poslist.Where(p => p.discount).ToList();
                    var discountItem = new POSItems()
                    {
                        Name = "خصم",
                        Price = discountItems.Sum(p => p.Price),
                        Quantity = 1,
                        Barcode = "discount"
                    };
                    poslist.RemoveAll(p => p.discount);
                    poslist.Add(discountItem);

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
                            CombinedInvoice.TimeOfSaving = DateTime.Now.AddTicks(-(DateTime.Now.Ticks % TimeSpan.TicksPerSecond));
                            DbInv.UpdateInvoice(CombinedInvoice);
                        }
                        else
                        {
                            item.InvoiceItems.Clear();
                            item.Comment = "فاتورة مجمعة تابعة لرقم: " + oldID;
                            item.Status = InvStat.Deleted;
                            item.TimeOfSaving = DateTime.Now.AddTicks(-(DateTime.Now.Ticks % TimeSpan.TicksPerSecond));
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
                Fri_CheckedChanged(GetRadioDict()[RadioChecked], null);
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
                if (e.ColumnIndex == InvoicesDG.Columns["ID"].Index)
                {
                    //select row under mouse right now
                    InvoicesDG.ClearSelection();
                    InvoicesDG.Rows[e.RowIndex].Selected = true;
                    MultiSave_Click(sender, e);
                }

            }
            else
            {
                if (e.ColumnIndex == InvoicesDG.Columns["POSInvoiceNumber"].Index)
                {
                    InvoicesDG.ClearSelection();
                    if (e.RowIndex < 0) return;
                    InvoicesDG.Rows[e.RowIndex].Selected = true;

                    if (InvoicesDG.SelectedCells[e.ColumnIndex].Value != null && InvoicesDG.SelectedCells[e.ColumnIndex].Value.ToString() != "جاهز" && InvoicesDG.SelectedCells[e.ColumnIndex].Value.ToString() != "")
                    {

                        Invoice item = (Invoice)InvoicesDG.Rows[e.RowIndex].DataBoundItem;

                        new PaymentOptions(item.POSInvoiceNumber);
                    }
                }


                if (e.ColumnIndex == InvoicesDG.Columns["ID"].Index)
                {
                    if (e.RowIndex < 0) return;
                    Invoice item = (Invoice)InvoicesDG.Rows[e.RowIndex].DataBoundItem;
                    if (History.Checked)
                    {
                        LoadInvoiceUI(item);
                    }
                    else
                    {
                        var Opened = DbInv.GetInvoiceByID(item.ID);
                        LoadInvoiceUI(Opened);

                    }
                }
            }
        }

        private void EditName_Click(object sender, EventArgs e)
        {
            try
            {
                if (EditName.Tag is Contacts con && MobileTB.Text == con.Number)
                {
                    con.Name = NameTB.Text;
                    dbQ.SaveContacts(con);
                    string old = EditName.Text;
                    EditName.Text = "تم التعديل";
                    // wait 10 seconds then return to original text of EditName.Text;
                    Task.Delay(5000).ContinueWith(t => { EditName.Text = old; });

                }
                else
                {
                    EditName.Tag = dbQ.LoadContacts(MobileTB.Text);
                    EditName_Click(sender, e);
                }
            }
            catch (Exception)
            {


            }
        }

        private void InvoicesDG_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)

            {
                var newfont = this.Font;
                newfont = new Font(newfont.FontFamily, 11, System.Drawing.FontStyle.Bold);
                if (e.Value != null)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                    ButtonRenderer.DrawButton(e.Graphics, e.CellBounds, e.Value.ToString(), newfont, false, System.Windows.Forms.VisualStyles.PushButtonState.Hot);

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

        private void PasteBTN_Click(object sender, EventArgs e)
        {

            if (System.Windows.Clipboard.ContainsText(System.Windows.TextDataFormat.Text))
            {
                if (!System.Windows.Clipboard.GetText().Replace("+", "").Replace(" ", "").Any(c => !Char.IsDigit(c)))
                { MobileTB.Text = System.Windows.Clipboard.GetText(); NameTB.Focus(); }
                else { NameTB.Text = System.Windows.Clipboard.GetText(); }
            }
        }



        private void FilterBTN_Click(object sender, EventArgs e)
        {
            FilterMenu.Show(this.FilterBTN, new Point(0, 0));
        }

        private void FilterMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name == madaFilter.Name)
            {
                CashFilter.Checked = false;
                multiPaymentFilter.Checked = false;

            }
            else if (e.ClickedItem.Name == CashFilter.Name)
            {
                madaFilter.Checked = false;
                multiPaymentFilter.Checked = false;
            }
            else if (e.ClickedItem.Name == multiPaymentFilter.Name)
            {
                CashFilter.Checked = false;
                madaFilter.Checked = false;
            }
            if (e.ClickedItem.Name == notJahezFilter.Name)
            {
                jahezFilter.Checked = false;
                deletedFilter.Checked = false;
            }
            else if (e.ClickedItem.Name == jahezFilter.Name)
            {
                notJahezFilter.Checked = false;
                deletedFilter.Checked = false;
            }

        }

        private void CountLBL_Click(object sender, EventArgs e)
        {
            // check for radio button checked named history
            // calculate InvoicePrice Column in InvoicesDG
            try
            {
                var sum = InvoicesDG.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToDouble(t.Cells["InvoicePrice"].Value));
                //Make a 5 second tool tip to show the result of sum    
                ToolTip tt = new ToolTip();
                tt.Show(sum.ToString(), CountLBL, 0, 0, 5000);
            }
            catch (Exception)
            {


            }



        }

        private void Label4_Click(object sender, EventArgs e)
        {
            NameTB.Clear();
        }

        private void Label8_Click(object sender, EventArgs e)
        {
            MobileTB.Clear();
        }

        private void UButton5_Click(object sender, EventArgs e)
        {
            CommentTB.Clear();
        }

        private void SharpClipboard1_ClipboardChanged(object sender, WK.Libraries.SharpClipboardNS.SharpClipboard.ClipboardChangedEventArgs e)
        {


            if (e.Content.ToString().Contains('×') || e.Content.ToString().Contains("app_id") || e.Content.ToString().Contains("المُقدَّر") || e.Content.ToString().Contains("estimated") || e.Content.ToString().Contains("Order#"))
            {
                try
                {
                    if (POS.Count == 0)
                    {

                        var result = MessageForm.SHOW("تم إلتقاط فاتورة عبر الحافظة، هل تريد محاولة قراءتها؟" + Environment.NewLine + e.Content.ToString(), "العثور الذكي على الفواتير", "نعم", "لا");
                        if (result == DialogResult.Yes)
                        {
                            if (e.Content.ToString().Contains("app_id"))
                            {
                                ParseJson(e.Content.ToString());
                            }
                            else
                            {
                                ParseInvoices(e.Content.ToString());
                                DeleteLastCliboard(e.Content.ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    repeatedBehavior.AreYouSure(ex.Message.ToString(), "خطأ بالتنفيذ");

                }

            }

        }

        private void ParseJson(string v)
        {
            Console.WriteLine("Parsing JSON...");
            // parse json
            var json = v;
            var jObject = JObject.Parse(json);
            // find customer_name
            var customer_name = jObject["customer_name"].ToString();
            Console.WriteLine("Customer name found: " + customer_name);
            NameTB.Text = customer_name;
            // find customer_phone
            var customer_mobile = jObject["customer_mobile"].ToString();
            Console.WriteLine("Customer mobile found: " + customer_mobile);
            MobileTB.Text = "0" + customer_mobile;
            var vehicle_brand_name = jObject["vehicle_brand_name"].ToString();
            var vehicle_color_name = jObject["vehicle_color_name"].ToString();
            if (vehicle_brand_name != null)
            {
                CommentTB.Text += " " + vehicle_brand_name + " " + vehicle_color_name;
                Console.WriteLine("Vehicle brand and color found: " + vehicle_brand_name + " " + vehicle_color_name);
            }

            // get list of items 
            var items = jObject["items"].ToList();
            Console.WriteLine("Items found:");
            // go through each item and add it to POS   
            foreach (var item in items)
            {
                var TryOrderMaterials = DbInv.LoadApp("tryorder");
                var name = item["item_name"].ToString();
                var price = item["item_price"].ToString();
                var quantity = item["qty"].ToString();
                string barcode = TryOrderMaterials.list.First(z => z.Name == name.Trim()).Barcode;

                var positem = new POSItems()
                {
                    Name = name,
                    Price = Convert.ToDecimal(price),
                    Quantity = Convert.ToInt32(quantity),
                    Barcode = barcode,
                };
                POS.Add(positem);
                Console.WriteLine("- " + name + " added to POS");
            }
        }

        private async void DeleteLastCliboard(string e)
        {
            try
            {
                var historyItems = await Windows.ApplicationModel.DataTransfer.Clipboard.GetHistoryItemsAsync();
                var myClipList = historyItems.Items.Where(item => { if (item.Content.Contains(StandardDataFormats.Text) && item.Content.GetTextAsync().GetResults().Substring(0, 100) == e.Substring(0, 100)) return true; else return false; }).First();
                Windows.ApplicationModel.DataTransfer.Clipboard.DeleteItemFromHistory(myClipList);
            }
            catch (Exception Ex)
            {

                Console.WriteLine(Ex.Message);
            }
        }
        private void EditName_TextChanged(object sender, EventArgs e)
        {
            Console.Write(true);
        }

        private void AppsSettings_Click(object sender, EventArgs e)
        {
            var f = new AppsSetting();
            f.ShowDialog();
        }

        private void UButton6_Click(object sender, EventArgs e)
        {
            var f = new Discounnt();
            if (POS.Any(x => x.discount))
            {
                f.dc.Text = POS.First(x => x.discount).Price.ToString().Replace("-", "");
                var discount = f.GetDiscount();

                if (discount != null)
                {
                    if (discount.Price != 0)
                    {
                        POS.First(x => x.discount).Price = discount.Price;
                        POS.First(x => x.discount).Comment = discount.Comment;
                    }
                }
            }
            else
            {
                var discount = f.GetDiscount();
                if (discount != null)
                {
                    if (discount.Price != 0)
                    {
                        POS.Add(discount);
                    }
                }
            }
        }

        private void UButton1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var cal = new CalLog
                {
                    Top = uButton1.Top - 435,
                    Left = uButton1.Left + 450
                };
                cal.Show();
            }
            else
            {
                CalLog.LoadLastNumber();
            }
        }

        private void uButton7_Click(object sender, EventArgs e)
        {
            if (MobileTB.Text.Length > 8 && dbQ.LoadContacts(MobileTB.Text).comments != null)
                CommentTB.Text = dbQ.LoadContacts(MobileTB.Text).comments;



        }

        private void SalahTimeBTN_Click(object sender, EventArgs e)
        {
            if (SalahPanels.Size == new Size(321, 63))
            {
                SalahPanels.Size = new Size(20, 63);
                SalahPanels.Visible = false;
                SalahTimeBTN.Text = ">";
            }
            else
            {
                SalahPanels.Size = new Size(321, 63);
                SalahPanels.Visible = true;
                SalahTimeBTN.Text = "<";
            }


        }
    }
}

