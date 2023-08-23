﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp;
using sharedCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Deployment.Application;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Animation;
using static System.Net.Mime.MediaTypeNames;

namespace OrderForm
{

    public partial class SettingsPage : Form
    {

        public SettingsPage()
        {
            InitializeComponent();
        }

        private static BindingList<MenuItemZ> MIZ = new BindingList<MenuItemZ>();
        private static BindingList<MenuItemsX> MIX = new BindingList<MenuItemsX>();

        private void button4_Click(object sender, EventArgs e)
        {
            MoveItem(-1, list);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            MoveItem(1, list);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MoveItem(-1, sList);
        }
        private void button9_Click(object sender, EventArgs e)
        {
            MoveItem(1, sList);
        }
        private void createGroupBTN_Click(object sender, EventArgs e)
        {
            if (groupTB.Text != "")
            {
                POSsections sect = new POSsections
                {
                    Name = groupTB.Text
                };
                if (sList.Items.Count > 0)
                {
                    bool exists = false;
                    for (int i = 0; i < sList.Items.Count; i++)
                    {
                        if (sect.Name == sList.Items[i].ToString())
                        {
                            exists = true;
                        }

                    }
                    if (exists == false)
                    {
                        sList.Items.Add(sect);
                    }
                }
                else sList.Items.Add(sect);

                groupTB.Text = "";
                groupTB.Focus();
            }

        }

        private void groupTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                createGroupBTN.Focus();
            }
        }

        private void sDelete_Click(object sender, EventArgs e)
        {
            if (sList.SelectedIndex >= 0)
            {
                if (repeatedBehavior.AreYouSure("لن تتمكن من التراجع عن الحذف، هل أنت متأكد من رغبتك في حذف القسم؟", "هل تريد حذف قسم المواد؟"))
                {
                    List<POSItems> a = dbQ.LoadMaterialItems().FindAll(x => x.SectionName == sList.SelectedItem.ToString());
                    a.ForEach(x => x.SectionName = "بدون قسم");
                    dbQ.DeleteItemSections(a);
                    sList.Items.RemoveAt(sList.SelectedIndex);
                    listGB.Text = $"المجموعة:";
                }
            }
        }

        private void sectionListSave_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < sList.Items.Count; i++)
            {
                var a = (POSsections)sList.Items[i];
                a.ID = i;
            }
            dbQ.SaveSections(sList);
            this.Close();
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage.Name == "Sections")
            {
                sList.Items.Clear();
                dbQ.PopulateSections().ForEach(i => sList.Items.Add(i));
                mat.Items.Clear();
                dbQ.LoadMaterialItems().Where(x => x.SectionName == "بدون قسم").ToList().ForEach(i => mat.Items.Add(i));
            }

            else if (e.TabPage.Name == "prntSetting")
            {
                GetListOfPrinters();
                List<POSsections> l = dbQ.GetSections();
                sectionsListCB.Items.Clear();
                foreach (var i in l)
                {
                    sectionsListCB.Items.Add(i);
                }
                defaultPrinterTB.Text = dbQ.DefaultPrinters();
                CashierPrinterTB.Text = dbQ.CashierPrinter();
                sectionList.Items.Clear();
                PrepareList.Items.Clear();
                foreach (var item in dbQ.LoadDepartments())
                {
                    PrepareList.Items.Add(item);
                }
            }
            else if (e.TabPage.Name == "Pos")
            {
                GetSettings();
            }
            else if (e.TabPage.Name == "About")
            {
                infolist.Items.Clear();
                var list = MenuDB.LoadInfo();
                if (list != null)
                {
                    if (list.list.Count > 0)
                    {
                        foreach (string item in list.list)
                        {
                            infolist.Items.Add(item);
                        }
                    }
                }
                try
                {
                    label54.Text += Environment.NewLine + ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();

                }
                catch (Exception)
                {
                    Console.Beep(500, 500);
                }
            }
            else if (e.TabPage.Name == "MenuDisplaySettings")
            {
                MIX.Clear();
                MIZ.Clear();
                MenuLB.DataSource = MIZ;
                AddingGrid.DataSource = MIX;
                SaveMenu.Enabled = false;
                MListLB.Items.Clear();
                SectionsName.Text = "NoMenu";
                try
                {
                    MenuDB.GetMenus().ForEach(x => MListLB.Items.Add(x));

                }
                catch (Exception)
                {

                }
            }


        }

        private void GetSettings()
        {
            postb.Text = Properties.Settings.Default.pos;
            barcodetb.Text = Properties.Settings.Default.barcodetb;
            invoiceprc.Text = Properties.Settings.Default.invoiceprc;
            invoicenotes.Text = Properties.Settings.Default.invoicenotes;
            btntogo.Text = Properties.Settings.Default.btntogo;
            btnphone.Text = Properties.Settings.Default.btnphone;
            btn1.Text = Properties.Settings.Default.btn1;
            btn2.Text = Properties.Settings.Default.btn2;
            btn3.Text = Properties.Settings.Default.btn3;
            btn4.Text = Properties.Settings.Default.btn4;
            btn5.Text = Properties.Settings.Default.btn5;
            btn6.Text = Properties.Settings.Default.btn6;
            btn7.Text = Properties.Settings.Default.btn7;
            btn8.Text = Properties.Settings.Default.btn8;
            btn9.Text = Properties.Settings.Default.btn9;
            btn0.Text = Properties.Settings.Default.btn0;
            btnsubmit.Text = Properties.Settings.Default.btnsubmit;
            amountlbl.Text = Properties.Settings.Default.amountlbl;
            CashTextBox.Text = Properties.Settings.Default.CashTextBox;
            SaveBTN_.Text = Properties.Settings.Default.SaveBTN;
            SwitchBTNPOS.Text = Properties.Settings.Default.SwitchBTN;
            Mada1.Text = Properties.Settings.Default.Mada1;
            Mada2.Text = Properties.Settings.Default.Mada2;
            Mada3.Text = Properties.Settings.Default.Mada3;
            Mada1CB.Text = Properties.Settings.Default.Mada1Combo;
            Mada2CB.Text = Properties.Settings.Default.Mada2Combo;
            Mada3CB.Text = Properties.Settings.Default.Mada3Combo;
            PartCash.Text = Properties.Settings.Default.PartCash;
            InvoiceNumberTB.Text = Properties.Settings.Default.InvoiceNumberTB;
            InvoiceTimeTB.Text = Properties.Settings.Default.InvoiceTime;
            POSName.Text = Properties.Settings.Default.POSMainName;
            POSNewBTN.Text = Properties.Settings.Default.POSNewBTN;
            POSShortcut.Text = Properties.Settings.Default.POSShortcut;
            POSWinShortcut.Text = Properties.Settings.Default.POSWinShortcut;
            //
            POSClearNumber.Text = Properties.Settings.Default.POSClearNumber;
            CurrentTax.Text = Properties.Settings.Default.CurrentTax.ToString();
            BranchName.Text = Properties.Settings.Default.BranchName;

            defaultOrder.Text = Properties.Settings.Default.defaultOrder.ToString();
            DBConnection.Text = Properties.Settings.Default.DBConnection;
            CloseWin_.Checked = Properties.Settings.Default.CloseWindow;
            showMenu.Checked = Properties.Settings.Default.showMenu;
            TestingMode.Checked = Properties.Settings.Default.TestingMode;
            FntUpDown.Value = Properties.Settings.Default.Fnt;
            POSClientName_.Text = Properties.Settings.Default.POSClientName;
            POSPhoneNumber_.Text = Properties.Settings.Default.POSPhoneNumber;
            WheelCheck.Checked = Properties.Settings.Default.WheelEnabled;
            WheelGridCheck.Checked = Properties.Settings.Default.WheelGridEnabled;
            LoadFile.FileName = Properties.Settings.Default.API_Server_Path;
            ipTB.Text = Properties.Settings.Default.API_Connection;
            ItemW.Text = Properties.Settings.Default.ItemSize.Width.ToString();
            ItemH.Text = Properties.Settings.Default.ItemSize.Height.ToString();
            RestTB.Text = Properties.Settings.Default.RestaurantName;
            logoTB.Text = Properties.Settings.Default.Logo;
            GetFonts();
            comboBox1.Text = Properties.Settings.Default.FontCombo;
            APICheck.Checked = Properties.Settings.Default.Api_On;
            ServerRB.Checked = Properties.Settings.Default.Api_Server;
            ClientRB.Checked = !Properties.Settings.Default.Api_Server;
            CIDCheck.Checked = Properties.Settings.Default.CallerIDEnabled;

        }

        private void GetFonts()
        {
            List<string> fonts = new List<string>();

            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                comboBox1.Items.Add(font.Name);
            }
        }
        private void GetListOfPrinters()
        {
            PrintersList1.Items.Clear();
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                PrintersList1.Items.Add(printer);
            }

        }
        private void AddToGroup_Click(object sender, EventArgs e)
        {
            if (listGB.Text != $"المجموعة:")
            {
                List<POSItems> l = new List<POSItems>();

                var SelectedMat = mat.SelectedItems.Cast<POSItems>().ToList();
                var TargetBox = list.Items.Cast<POSItems>().ToList();

                SelectedMat.ForEach(x => { if (!TargetBox.Contains(x, new POSitemComparer())) list.Items.Add(x); });
            }
        }


        private void filterTB_TextChanged(object sender, EventArgs e)
        {
            if (filterTB.Text == "")
            {
                List<POSItems> m = dbQ.LoadMaterialItems();
                mat.Items.Clear();
                m.ForEach(x => mat.Items.Add(x));
            }
            else
            {
                mat.Items.Clear();
                List<POSItems> m = dbQ.LoadMaterialItems();
                m.Where(x => x.Name.Contains(filterTB.Text)).ToList().ForEach(f => mat.Items.Add(f));
            }

        }

        private void DeleteItems_Click(object sender, EventArgs e)
        {
            if (list.SelectedIndex >= 0)
            {
                list.Items.RemoveAt(list.SelectedIndex);
            }
        }

        private void GroupSaveMat_Click(object sender, EventArgs e)
        {
            var s = sList.SelectedItem.ToString();
            dbQ.UpdateItemSections(list.Items.Cast<POSItems>().ToList(), s);

            listGB.Enabled = false;
            groupBox4.Enabled = true;
            listGB.Text = $"المجموعة:";
            list.Items.Clear();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            listGB.Text = $"المجموعة:";
            groupBox4.Enabled = true;
            listGB.Enabled = false;
            list.Items.Clear();
        }


        private void sList_DoubleClick(object sender, EventArgs e)
        {
            if (sList.SelectedIndex >= 0)
            {
                var s = sList.Items[sList.SelectedIndex].ToString();
                listGB.Text = $"المجموعة:{s}";
                list.Items.Clear();
                dbQ.GetItemsForSection(s).ForEach(x => list.Items.Add(x));
                groupBox4.Enabled = false;
                listGB.Enabled = true;

            }
        }
        /// <summary>
        /// Move Item in a listbox, pass -1 to move up, pass 1 to move down,
        /// pass ListBox Name to set the target listbox.
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="listBox1"></param>
        public void MoveItem(int direction, ListBox listBox1)
        {
            // Checking selected item
            if (listBox1.SelectedItem == null || listBox1.SelectedIndex < 0)
                return; // No selected item - nothing to do

            // Calculate new index using move direction
            int newIndex = listBox1.SelectedIndex + direction;

            // Checking bounds of the range
            if (newIndex < 0 || newIndex >= listBox1.Items.Count)
                return; // Index out of range - nothing to do

            object selected = listBox1.SelectedItem;

            // Removing removable element
            listBox1.Items.Remove(selected);
            // Insert it in new position
            listBox1.Items.Insert(newIndex, selected);
            // Restore selection
            listBox1.SetSelected(newIndex, true);
        }


        private void button2_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < sectionList.Items.Count; i++)
            {
                var a = (POSsections)sectionList.Items[i];
            }

            dbQ.SaveSections(sectionList);

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (PrintersList1.SelectedItems.Count == 1)
            {
                defaultPrinterTB.Text = PrintersList1.SelectedItem.ToString();
                dbQ.DefaultPrinters(defaultPrinterTB.Text);
            }

        }



        private void sectionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sectionList.SelectedIndex >= 0)
            {
                //var a = (POSsections)sectionList.SelectedItem;
                //SectionName.Text = a.Name;
                //printerLBL.Text = a.DefaultPrinter;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (sectionList.SelectedItems.Count > 0)
            {
                //var a = (POSsections)sectionList.SelectedItem;
                //a.DefaultPrinter = "";
                //SectionName.Text = a.Name;
                //printerLBL.Text = a.DefaultPrinter;

            }
        }





        private void sectionsListCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sectionsListCB.SelectedIndex >= 0)
            {
                var slct = sectionsListCB.SelectedItem.ToString();
                sectionList.Items.Clear();
                dbQ.GetItemsForSection(slct).ForEach(x => sectionList.Items.Add(x));

                sectionList.SelectedItems.Clear();
                //for (int i = 0; i < sectionList.Items.Count; i++)
                //{
                //    sectionList.SetSelected(i, true);
                //}

            }
        }


        private void button7_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.DefaultPrinter = "";
            Properties.Settings.Default.Save();
            defaultPrinterTB.Text = "";
        }

        private void button6_Click_1(object sender, EventArgs e)
        {

        }

        private void AddNewDepartment_Click_1(object sender, EventArgs e)
        {

        }

        private void button6_Click_2(object sender, EventArgs e) //adding printers to items
        {
            if (PrintersList1.SelectedItems.Count > 0 && sectionList.SelectedItems.Count > 0)
            {


                foreach (var item in sectionList.SelectedItems.Cast<POSItems>().ToList())
                {
                    item.PrinterName = "";
                    foreach (Object chk in PrintersList1.CheckedItems)
                    {
                        item.PrinterName += "," + chk.ToString() + ",";
                    }
                }



            }
        }

        private void AddNewDepartment_Click_2(object sender, EventArgs e)
        {
            if (sectionsListCB.SelectedIndex >= 0)
            {
                // POSsections d = c as POSsections;
                // d.Items.Clear();
                dbQ.UpdateAllItemsPrinters(sectionList.Items.Cast<POSItems>().ToList());


            }
        }
        private bool exists = false;

        private void PrepareADD_Click(object sender, EventArgs e)




        {

            if (PrepareTB.Text != "")
            {
                if (PrepareList.Items.Count > 1)
                {
                    for (int i = 0; i < PrepareList.Items.Count; i++)
                    {
                        if (PrepareTB.Text == PrepareList.Items[i].ToString())
                        {
                            exists = true;
                        }

                    }

                    if (!exists)
                    {
                        POSDepartments Dep = new POSDepartments(PrepareTB.Text);
                        PrepareList.Items.Add(Dep);
                        PrepareTB.Text = "";
                        exists = false;
                    }
                    else PrepareTB.Text = "";

                }
                else if (PrepareList.Items.Count == 1)
                {
                    if (PrepareList.Items[0].ToString() == PrepareTB.Text) PrepareTB.Text = "";
                    else
                    {
                        POSDepartments Dep = new POSDepartments(PrepareTB.Text);
                        PrepareList.Items.Add(Dep);
                    }
                    exists = false;


                }
                else
                {
                    POSDepartments Dep = new POSDepartments(PrepareTB.Text);
                    PrepareList.Items.Add(Dep);
                    PrepareTB.Text = "";
                }
                exists = false;

            }
        }

        private void PrepareTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PrepareADD.PerformClick();
                PrepareTB.Text = "";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (PrepareList.SelectedIndex >= 0)
            {
                PrepareList.Items.RemoveAt(PrepareList.SelectedIndex);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (PrintersList1.CheckedItems.Count > 0)
            {
                if (PrepareList.SelectedIndex >= 0)
                {
                    var a = PrepareList.SelectedItem as POSDepartments;
                    a.DefaultPrinter = PrintersList1.GetItemText(PrintersList1.SelectedItem);

                }
            }
            else if (PrintersList1.CheckedItems.Count <= 0)
            {
                if (PrepareList.SelectedIndex >= 0)
                {
                    var a = PrepareList.SelectedItem as POSDepartments;
                    a.DefaultPrinter = "";
                }
            }

        }

        private void PrepareList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PrepareList.SelectedIndex >= 0)
            {
                var a = PrepareList.SelectedItem as POSDepartments;

                MessageBox.Show(a.DefaultPrinter);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            List<POSDepartments> PosDep = new List<POSDepartments>();
            foreach (POSDepartments item in PrepareList.Items)
            {
                PosDep.Add(item);
            }
            dbQ.SaveDepartments(PosDep);
        }

        private void SaveChangesPOS_Click(object sender, EventArgs e)
        {

            Properties.Settings.Default.pos = postb.Text;
            Properties.Settings.Default.barcodetb = barcodetb.Text;
            Properties.Settings.Default.invoiceprc = invoiceprc.Text;
            Properties.Settings.Default.invoicenotes = invoicenotes.Text;
            Properties.Settings.Default.btntogo = btntogo.Text;
            Properties.Settings.Default.btnphone = btnphone.Text;
            Properties.Settings.Default.btn1 = btn1.Text;
            Properties.Settings.Default.btn2 = btn2.Text;
            Properties.Settings.Default.btn3 = btn3.Text;
            Properties.Settings.Default.btn4 = btn4.Text;
            Properties.Settings.Default.btn5 = btn5.Text;
            Properties.Settings.Default.btn6 = btn6.Text;
            Properties.Settings.Default.btn7 = btn8.Text;
            Properties.Settings.Default.btn8 = btn8.Text;
            Properties.Settings.Default.btn9 = btn9.Text;
            Properties.Settings.Default.btn0 = btn0.Text;
            Properties.Settings.Default.btnsubmit = btnsubmit.Text;
            Properties.Settings.Default.amountlbl = amountlbl.Text;
            Properties.Settings.Default.CashTextBox = CashTextBox.Text;
            Properties.Settings.Default.SaveBTN = SaveBTN_.Text;
            Properties.Settings.Default.SwitchBTN = SwitchBTNPOS.Text;
            Properties.Settings.Default.Mada1 = Mada1.Text;
            Properties.Settings.Default.Mada2 = Mada2.Text;
            Properties.Settings.Default.Mada3 = Mada3.Text;
            Properties.Settings.Default.Mada1Combo = Mada1CB.Text;
            Properties.Settings.Default.Mada2Combo = Mada2CB.Text;
            Properties.Settings.Default.Mada3Combo = Mada3CB.Text;
            Properties.Settings.Default.PartCash = PartCash.Text;
            Properties.Settings.Default.InvoiceNumberTB = InvoiceNumberTB.Text;
            Properties.Settings.Default.InvoiceTime = InvoiceTimeTB.Text;
            Properties.Settings.Default.POSMainName = POSName.Text;

            Properties.Settings.Default.POSNewBTN = POSNewBTN.Text;
            Properties.Settings.Default.POSShortcut = POSShortcut.Text;
            Properties.Settings.Default.POSWinShortcut = POSWinShortcut.Text;
            Properties.Settings.Default.POSClearNumber = POSClearNumber.Text;

            Properties.Settings.Default.POSClearNumber = POSClearNumber.Text;
            Properties.Settings.Default.CurrentTax = Convert.ToDecimal(CurrentTax.Text);
            Properties.Settings.Default.BranchName = BranchName.Text;
            Properties.Settings.Default.defaultOrder = Convert.ToInt32(defaultOrder.Text);
            Properties.Settings.Default.DBConnection = DBConnection.Text;
            Properties.Settings.Default.showMenu = showMenu.Checked;
            Properties.Settings.Default.CloseWindow = CloseWin_.Checked;
            Properties.Settings.Default.TestingMode = TestingMode.Checked;
            Properties.Settings.Default.Fnt = Convert.ToInt32(FntUpDown.Value);
            Properties.Settings.Default.FontCombo = comboBox1.Text;

            Properties.Settings.Default.POSClientName = POSClientName_.Text;
            Properties.Settings.Default.POSPhoneNumber = POSPhoneNumber_.Text;
            Properties.Settings.Default.WheelEnabled = WheelCheck.Checked;
            Properties.Settings.Default.WheelGridEnabled = WheelGridCheck.Checked;
            Properties.Settings.Default.Api_On = APICheck.Checked;
            Properties.Settings.Default.API_Server_Path = LoadFile.FileName;
            Properties.Settings.Default.API_Connection = ipTB.Text;
            Properties.Settings.Default.RestaurantName = RestTB.Text;
            Properties.Settings.Default.Logo = logoTB.Text;
            Properties.Settings.Default.Api_Server = ServerRB.Checked;

            Properties.Settings.Default.Api_Server = ServerRB.Checked;
            Properties.Settings.Default.CallerIDEnabled = CIDCheck.Checked;



            if (ItemW.Text != null && ItemH.Text != null)
            {
                ItemW.Text = new String(ItemW.Text.Where(Char.IsDigit).ToArray());
                ItemH.Text = new String(ItemH.Text.Where(Char.IsDigit).ToArray());
                if (Convert.ToInt32(ItemW.Text) > 0 && Convert.ToInt32(ItemH.Text) > 0)
                {
                    Properties.Settings.Default.ItemSize = new System.Windows.Size() { Width = Convert.ToInt32(ItemW.Text), Height = Convert.ToInt32(ItemH.Text) };
                }

            }

            Properties.Settings.Default.Save();
        }

        private void ClearDB_Click(object sender, EventArgs e)
        {
            if (repeatedBehavior.AreYouSure("متأكد؟", "متأكد؟") == true)
            {
                DbInv.DeleteDBInvoices();
            }

        }

        private void Pos_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (TestingMode.Checked == true)
            {
                Properties.Settings.Default.TestingMode = true;
            }
            else Properties.Settings.Default.TestingMode = false;
            Properties.Settings.Default.Save();
        }

        private void prcTB_TextChanged(object sender, EventArgs e)
        {

        }
        BindingList<POSItems> MAT = new BindingList<POSItems>();

        private void AddMat_Click(object sender, EventArgs e)
        {
            if (uButton1.Visible) return;
            POSItems pos = new POSItems()
            {
                Name = NameTB.Text,
                Barcode = BarTB.Text,
                Price = Convert.ToDecimal(prcTB.Text),
                Quantity = Convert.ToInt32(quanTB.Text),
                realquan = Convert.ToInt32(RealQuanTB.Text)
                ,
                Available = available.Checked,
                Tax = Properties.Settings.Default.CurrentTax,
                PicturePath = PicTB.Text,
                Comment = "",
                PrinterName = PrinterTB.Text,
                SectionName = "بدون قسم"
            };
            if (MAT.ToList().TrueForAll(x => x.Name != pos.Name))
            {
                MAT.Add(pos);


                NameTB.Text = "";
                BarTB.Text = "";
                prcTB.Text = "0";
                quanTB.Text = "1";
                RealQuanTB.Text = "1";
                TaxTB.Text = Properties.Settings.Default.CurrentTax.ToString();
                PicTB.Text = "";
                PrinterTB.Text = "";
                SectionNameTB.Text = "بدون قسم";
                available.Checked = true;
                NameTB.Focus();
                matLB.Enabled = true;
            }
            else MessageBox.Show("إسم المادة متكرر");



        }

        private void MaterialsEdit_Enter(object sender, EventArgs e)
        {
            this.uButton1.Visible = true;


        }

        private void matLB_DoubleClick(object sender, EventArgs e)
        {

            if (matLB.SelectedIndex >= 0)
            {
                matLB.Enabled = false;
                var Edit = (POSItems)MAT[matLB.SelectedIndex];
                NameTB.Text = Edit.Name;
                BarTB.Text = Edit.Barcode;
                prcTB.Text = Edit.Price.ToString();
                quanTB.Text = Edit.Quantity.ToString();
                RealQuanTB.Text = Edit.realquan.ToString();
                TaxTB.Text = Properties.Settings.Default.CurrentTax.ToString();
                PicTB.Text = Edit.PicturePath;
                PrinterTB.Text = Edit.PrinterName;
                SectionNameTB.Text = Edit.SectionName;
                EditMat.Enabled = true;
                AddMat.Enabled = false;
                matLB.SelectionMode = SelectionMode.One;
                checkBox2.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked) matLB.SelectionMode = SelectionMode.MultiExtended; else matLB.SelectionMode = SelectionMode.One;
        }

        private void EditMat_Click(object sender, EventArgs e)
        {
            if (uButton1.Visible) return;

            POSItems pos = MAT[matLB.SelectedIndex];
            pos.Name = NameTB.Text;
            pos.Barcode = BarTB.Text;
            pos.Price = Convert.ToDecimal(prcTB.Text);
            pos.Quantity = Convert.ToInt32(quanTB.Text);
            pos.realquan = Convert.ToInt32(RealQuanTB.Text);
            pos.PicturePath = PicTB.Text;
            pos.PrinterName = PrinterTB.Text;
            pos.SectionName = SectionNameTB.Text;
            pos.Available = available.Checked;
            AddMat.Enabled = true;
            EditMat.Enabled = false;
            matLB.DataSource = null;
            matLB.DataSource = MAT;

            matLB.Update();
            matLB.Refresh();
            available.Checked = true;
            NameTB.Text = "";
            BarTB.Text = "";
            prcTB.Text = "0";
            quanTB.Text = "0";
            RealQuanTB.Text = "0";
            TaxTB.Text = Properties.Settings.Default.CurrentTax.ToString();
            PicTB.Text = "";
            PrinterTB.Text = "";
            SectionNameTB.Text = "";
            matLB.Enabled = true;
        }




        private void SectionNameTB_DoubleClick(object sender, EventArgs e)
        {
            SettingTabs.SelectTab(Sections);
        }

        private void prcTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void quanTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void DeleleMat_Click(object sender, EventArgs e)
        {
            matLB.SelectedItems.Cast<POSItems>().ToList().ForEach(x => MAT.Remove(x));



            //if (matLB.SelectedIndex >=0 )
            //MAT.RemoveAt(matLB.SelectedIndex);
        }

        private void PrinterTB_Click(object sender, EventArgs e)
        {
            SettingTabs.SelectTab(prntSetting);

        }

        private void SaveAndUpdateMat_Click(object sender, EventArgs e)
        {

            dbQ.SaveOrUpdateItems(MAT.ToList());

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void NameTB_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((TextBox)sender, true, true, true, true);

            }
        }

        private void MenuDisplaySettings_Click(object sender, EventArgs e)
        {

        }

        private void AddMlist_Click(object sender, EventArgs e)
        {
            if (mlistTB.Text != "")
            {
                MenuSection sect = new MenuSection();
                sect.Name = mlistTB.Text;
                if (MListLB.Items.Count > 0)
                {
                    bool exists = false;
                    for (int i = 0; i < MListLB.Items.Count; i++)
                    {
                        if (sect.Name == MListLB.Items[i].ToString())
                        {
                            exists = true;
                        }

                    }
                    if (exists == false)
                    {
                        MListLB.Items.Add(sect.Name);
                        MenuDB.SaveMenuSection(sect);
                    }
                }
                else
                {
                    MListLB.Items.Add(sect.Name);
                    MenuDB.SaveMenuSection(sect);
                }

                mlistTB.Text = "";
                mlistTB.Focus();
            }
        }

        private void DeleteSM_Click(object sender, EventArgs e)
        {
            if (MListLB.SelectedIndex != -1)
            {
                if (repeatedBehavior.AreYouSure("هل تريد حذف المجموعة، لا يمكن التراجع عن الحذف", "تنبيه"))
                {
                    MenuDB.DeleteMenuSection(MListLB.Text);
                    MListLB.Items.Remove(MListLB.SelectedItem);
                }
            }
        }

        private void AddSingleItem_Click(object sender, EventArgs e)
        {
            if (MIX.Count > 0)
            {

                var NewItem = new MenuItemZ() { };
                MIX.ToList().ForEach(x => NewItem.items.Add(x));
                MIZ.Add(NewItem);
                MIZ.ResetBindings();
            }
        }



        private void mlistTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                AddMlist.Focus();
            }
        }

        private void SaveMenu_Click(object sender, EventArgs e)
        {
            if (SectionsName.Text != "NoMenu")
            {
                MenuDB.UpdateSectionItems(MIZ.ToList(), SectionsName.Text);
                SectionsName.Text = "NoMenu";
                MIZ.Clear();
                SaveMenu.Enabled = false;
            }
        }
        int MListindex = 0;
        private void MListLB_Click(object sender, EventArgs e)
        {

            if (SaveMenu.Enabled)
            {
                if (!repeatedBehavior.AreYouSure("سوف تذهب أي تعديلات غير محفوظة", "متأكد؟"))
                {
                    MListLB.SelectedIndex = MListindex;
                    return;
                }
            }


            if (MListLB.SelectedIndex != -1)
            {
                SectionsName.Text = MListLB.SelectedItem.ToString();
                LoadMenuSectionToEdit(SectionsName.Text);
                MIZ.ListChanged += MIZ_ListChanged;
                SaveMenu.Enabled = false;
                CopyMenu.Enabled = true;
            }
            else
            {
                SectionsName.Text = "NoMenu";
                CopyMenu.Enabled = false;
            }


        }

        private void MIZ_ListChanged(object sender, ListChangedEventArgs e)
        {
            SaveMenu.Enabled = true;
            MIZ.ListChanged -= MIZ_ListChanged;

        }

        private void LoadMenuSectionToEdit(string text)
        {
            MListindex = MListLB.SelectedIndex;

            MIZ.Clear();
            var a = MenuDB.GetMenuItems(text);
            if (a != null)
            {
                if (a.Count > 0)
                {
                    foreach (MenuItemZ item in a)
                    {

                        MIZ.Add(item);
                    }
                }
            }
        }
        static MenuItemZ selectedMIZ;
        private void MenuLB_DoubleClick(object sender, EventArgs e)
        {
            if (MenuLB.SelectedIndex != -1)
            {
                MenuLB.Enabled = false;
                selectedMIZ = (MenuItemZ)MenuLB.SelectedItem;
                MIX.Clear();
                selectedMIZ.items.ForEach(x => MIX.Add(x));
                AddSingleItem.Enabled = false;
                SaveMulti.Enabled = true;


                //if (M.SingleX)
                //{
                //    if (!Control.ModifierKeys.HasFlag(Keys.Control))
                //    {
                //        MultiLB.Items.Clear();
                //        SaveMulti.Enabled = false;
                //        AddMultiItem.Enabled = true;
                //        using (var form = new EditMenuItemX())
                //        {
                //            form.EditItems(M.items[0]);
                //            var result = form.ShowDialog();
                //            if (result == DialogResult.OK)
                //            {
                //                MenuItemsX val = form.MIX;            //values preserved after close
                //                M.items[0] = val;
                //                MenuLB.Items[MenuLB.SelectedIndex] = M;
                //            }
                //        }
                //    }
                //    else
                //    {
                //        MultiLB.Items.Add(M.items[0]);
                //        MenuLB.Items.Remove(MenuLB.Items[MenuLB.SelectedIndex]);
                //    }
                //}
                //else
                //{

                //    MultiLB.Items.Clear();
                //    M.items.ForEach(x => MultiLB.Items.Add(x));
                //    SaveMulti.Enabled = true;
                //    AddMultiItem.Enabled = false;
                //}
            }
        }



        private void DeleteM_Click(object sender, EventArgs e)
        {
            if (MenuLB.SelectedIndex != -1)
            {
                int a = MenuLB.SelectedIndex;
                MIZ.RemoveAt(MenuLB.SelectedIndex);
                try
                {
                    MenuLB.SelectedIndex = a - 1;
                }
                catch (Exception)
                {

                }

            }


        }

        private void MSUp_Click(object sender, EventArgs e)
        {
            MoveItem(-1, MListLB);

        }

        private void MSDown_Click(object sender, EventArgs e)
        {
            MoveItem(1, MListLB);

        }

        private void MUp_Click(object sender, EventArgs e)
        {
            //MoveItem(-1, MenuLB);
            selectedMIZ = (MenuItemZ)MenuLB.SelectedItem;
            int index = MIZ.IndexOf(selectedMIZ);
            if (index > MIZ.IndexOf(MIZ.First()))
            {
                MIZ.Move(index, index - 1);
                MenuLB.SelectedIndex = index - 1;

            }
        }

        private void MDown_Click(object sender, EventArgs e)
        {
            {
                //MoveItem(-1, MenuLB);
                selectedMIZ = (MenuItemZ)MenuLB.SelectedItem;
                int index = MIZ.IndexOf(selectedMIZ);
                if (index < MIZ.IndexOf(MIZ.Last()))
                {
                    MIZ.Move(index, index + 1);
                    MenuLB.SelectedIndex = index + 1;
                }
            }
        }

        private void ChoosePicPath_click(object sender, EventArgs e)
        {
            var filePath = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\db\\Images";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                }
            }
        }

        private void MenuDisplaySettings_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddInfo_Click(object sender, EventArgs e)
        {
            infolist.Items.Add(infopanel.Text);
            infopanel.Text = "";
            infopanel.Focus();
        }

        private void UpdateInfo_Click(object sender, EventArgs e)
        {
            var info = new infoObject();
            foreach (string item in infolist.Items)
            {
                info.list.Add(item);
            }
            MenuDB.SaveInfo(info);
        }

        private void DeleteInfo_Click(object sender, EventArgs e)
        {
            if (infolist.SelectedIndex != -1)
            {
                if (repeatedBehavior.AreYouSure("هل تريد حذف المعلومة", "تنبيه"))
                {
                    infolist.Items.Remove(infolist.SelectedItem);
                }
            }

        }



        private void FastAdd_Click(object sender, EventArgs e)
        {

            if (SectionsName.Text != "NoMenu") sectionsML.Show(QuickAdd, 0, 0);
        }

        private void SaveMulti_Click(object sender, EventArgs e)
        {
            if (MIX.Count > 0)
            {
                SaveMulti.Enabled = false;
                AddSingleItem.Enabled = true;

                selectedMIZ.items.Clear();
                MIX.ToList().ForEach(x => { selectedMIZ.items.Add(x); });
                MenuLB.Enabled = true;
                MIZ.ResetBindings();
                MIX.Clear();
            }
            else { MessageBox.Show("قم بإختيار المجموعة التي تريد تحديثها قبل محاولة الحفظ "); }
        }

        private void sectionsML_Opening(object sender, CancelEventArgs e)
        {
            sectionsML.Items.Clear();
            List<POSsections> lists = dbQ.GetSections();

            lists.ForEach(x => sectionsML.Items.Add(x.Name));
            if (sectionsML.Items.Count == 0)
            {
                e.Cancel = true;
            }
        }

        private void sectionsML_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

            foreach (var item in dbQ.GetItemsForSection(e.ClickedItem.Text))

            {
                var X = new MenuItemZ() { };
                X.items.Add(new MenuItemsX() { Name = item.Name, Barcode = item.Barcode, Price = item.Price.ToString() });
                MIZ.Add(X);
            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SettingsPage_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (ipTB.Text == "")
            {
                ipTB.Text = "http://" + GetLocalIPAddress() + ":5000";
            }
            var appSettingsPath = Path.Combine(System.Windows.Forms.Application.StartupPath + @"\API\" + "appsettings.json");
            var json = File.ReadAllText(appSettingsPath);
            var jsonSettings = new JsonSerializerSettings();
            jsonSettings.Converters.Add(new ExpandoObjectConverter());
            jsonSettings.Converters.Add(new StringEnumConverter());
            dynamic config = JsonConvert.DeserializeObject<ExpandoObject>(json, jsonSettings);
            config.Kestrel.Endpoints.Http.Url = ipTB.Text;
            //config.Kestrel.Endpoints.Https.Url = ipTB.Text.Replace(":5000",":5001").Replace("http://","https://");
            config.ConnectionString = Properties.Settings.Default.DBConnection;
            var newJson = JsonConvert.SerializeObject(config, Formatting.Indented, jsonSettings);
            File.WriteAllText(appSettingsPath, newJson);
            Console.Beep(500, 2000);
            if (repeatedBehavior.AreYouSure("هل تريد التأكد من صلاحية الآي بي للإتصال؟", "تأكد؟"))
            {
                Orders.KillandRestartAPI();
                if (DbInv.AreYouAlive())
                {
                    MessageBox.Show("الإتصال سليم");
                }
                else
                {
                    MessageBox.Show("قد يكون هناك خطأ في إعدادات السيرفر");
                }
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            string host = Dns.GetHostName();
            IPHostEntry ip = Dns.GetHostEntry(host);
            {

                BackgroundWorker bw = new BackgroundWorker();
                bw.DoWork += Bw_DoWork;
                bw.RunWorkerCompleted += Bw_RunWorkerCompleted;

                bw.WorkerReportsProgress = true;
                bw.RunWorkerAsync();
                ipTB.ForeColor = Color.Red;
                ipTB.Text = "جاري البحث: 1-9~ د";
            }
        }

        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {


            Console.WriteLine("I'm Here.");
            var OwnIp = GetLocalIPAddress().Split('.');
            string NetworkIP = $"{OwnIp[0]}.{OwnIp[1]}.{OwnIp[2]}.";
            Console.WriteLine(NetworkIP);
            Parallel.For(1, 256, i =>
            {
                if (scanForAPI($"{NetworkIP}{i}"))
                {
                    Console.WriteLine(i);
                    e.Result = $"{NetworkIP}{i}";
                    return;
                }
            });
            e.Result = "فشل العثور على السيرفر";

            //Console.WriteLine("I'm Here.");
            //var OwnIp = GetLocalIPAddress().Split('.');
            //string NetworkIP = OwnIp[0] + "." + OwnIp[1] + "." + OwnIp[2] + ".";
            //Console.WriteLine(NetworkIP);
            //for (int i = 1; i <= 255; i++)
            //{
            //    if (scanForAPI(NetworkIP + i.ToString()))
            //    {
            //        Console.WriteLine(i);
            //        e.Result = NetworkIP + i.ToString();
            //        return;
            //    }
            //}
            //e.Result = "فشل العثور على السيرفر";
        }

        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            ipTB.Text = "http://" + e.Result + ":5000";
            ipTB.ForeColor = Color.Green;

        }

        private bool scanForAPI(string ip)
        {

            try
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                var client = new RestClient("http://" + ip + ":5000" + "/LoadDB/AreYouAlive");
                var request = new RestRequest();
                request.Timeout = 2000;
                var response = client.Get(request);
                if (response != null) { return true; } else { return false; }
            }
            catch (Exception)
            {
                Console.WriteLine(ip + "Failed");

                return false;
            }


        }



        public static string GetLocalIPAddress()
        {
            var EthernetNetwork = GetLocalIPv4(NetworkInterfaceType.Ethernet);
            var WifiNetwork = GetLocalIPv4(NetworkInterfaceType.Wireless80211);

            if (EthernetNetwork != "")
            {
                return EthernetNetwork;
            }
            else if (WifiNetwork != "")
            {
                return WifiNetwork;
            }
            else
            {
                throw new Exception("لم يتم العثور على أي شبكة محلية الرجاء الإتصال بنفس الشبكة المحلية التي يتصل عليها السيرفر");
            }



        }

        private void SettingsPage_Load(object sender, EventArgs e)
        {

        }


        public static string GetLocalIPv4(NetworkInterfaceType _type)
        {
            string output = "";
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            output = ip.Address.ToString();
                        }
                    }
                }
            }
            return output;
        }
        Control ctrl;

        private void MnameTB_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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
                }

            }
            else if (ctrl is Button)
            {
                this.SelectNextControl(ctrl, true, true, false, true);
            }
        }

        private void Mpath_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Mpath_DragDrop(object sender, DragEventArgs e)
        {
            string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            AddingGrid.SelectedRows[0].Cells[9].Value = filePaths[0];
        }

        private void groupBox11_Enter(object sender, EventArgs e)
        {

        }

        private void AssignCashier_Click(object sender, EventArgs e)
        {
            if (PrintersList1.SelectedItems.Count == 1)
            {
                CashierPrinterTB.Text = PrintersList1.SelectedItem.ToString();
                dbQ.CashierPrinter(CashierPrinterTB.Text);
            }

        }

        private void RemoveCashierPrinter_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.CashierPrinter = "";
            Properties.Settings.Default.Save();
            CashierPrinterTB.Text = "";
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }


        private void AddingGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MenuLB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CancelMIX_Click(object sender, EventArgs e)
        {
            MenuLB.Enabled = true;
            SaveMulti.Enabled = false;
            AddSingleItem.Enabled = true;
            MIX.Clear();
            MenuLB.Refresh();
        }

        private void groupBox12_Enter(object sender, EventArgs e)
        {

        }

        private void SaveOrder_Click(object sender, EventArgs e)
        {
            MenuSection sect = new MenuSection();
            for (int i = 0; i < MListLB.Items.Count; i++)
            {
                MenuDB.UpdateMenuSection(MListLB.Items[i].ToString(), i);
            }

        }
        private void CopyMenu_Click(object sender, EventArgs e)
        {
            //explain this please?

            if (mlistTB.Text != "")
            {
                MenuSection sect = new MenuSection();
                sect.Name = mlistTB.Text;
                MListLB.Items.Add(sect);

                sect.order = MListLB.FindString(sect.Name);
                MenuDB.SaveMenuSection(sect);
                MenuDB.UpdateSectionItems(MIZ.ToList(), sect.Name);
            }
        }

        private void SettingsPage_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            Orders.SettingsClosed();
        }

        private void PicTB_DoubleClick(object sender, EventArgs e)
        {
            if (ModifierKeys.HasFlag(Keys.Control))
            {
                if (repeatedBehavior.AreYouSure("هل تريد تحديث جميع الصور بناء على المينيو؟", "العملية قد تأخذ وقتا... "))
                {
                    var MenuItemZZZ = new List<MenuItemZ>();
                    MenuDB.GetMenus().ForEach(x => MenuDB.GetMenuItems(x).ForEach(y => MenuItemZZZ.Add(y)));



                    foreach (var item in MAT.ToList())
                    {
                        foreach (var z in MenuItemZZZ)
                        {
                            {
                                if (z.SingleX)
                                {
                                    if (item.Barcode == z.items[0].Barcode) item.PicturePath = z.items[0].ImagePath;
                                }
                                else
                                {
                                    z.items.ForEach(multi => { if (multi.Barcode == item.Barcode) { item.PicturePath = multi.ImagePath; } });
                                }
                            }
                        }
                    }
                }



            }
        }

        private void OpenDB_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = @"c:\db";
            openFileDialog1.Filter = "db files (*.db)|*.db|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.CheckFileExists = false;
            openFileDialog1.CheckPathExists = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                DBConnection.Text = "filename=" + openFileDialog1.FileName;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (ClientRB.Checked)
            {
                APICheck.Checked = true;

            }

        }

        private void ServerRB_CheckedChanged(object sender, EventArgs e)
        {
            if (ServerRB.Checked && DBConnection.Text == "")
            {
                if (repeatedBehavior.AreYouSure("لم تقم بضبط مكان لقاعدة البيانات وهو ضروري لعمل السيرفر" + Environment.NewLine + "هل تريد أن نقوم بضبطه في المكان الإفتراضي؟", "يرجى ضبط مكان قاعدة البيانات"))
                {
                    DBConnection.Text = @"filename=C:\db\db.db";
                }
                APISETTINGS.Enabled = true;

            }
            else if (ServerRB.Checked)
            {

                APISETTINGS.Enabled = true;
            }
        }

        private void uButton1_Click(object sender, EventArgs e)
        {
            MAT.Clear();
            dbQ.LoadMaterialItems().ForEach(x => MAT.Add(x));
            matLB.DataSource = MAT;
            TaxTB.Text = Properties.Settings.Default.CurrentTax.ToString();
            this.uButton1.Visible = false;
        }

        private void MListLB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            // open a showdialog for the user to change headers title
            // save the new headers to the database 

            if (MListLB.SelectedIndex != -1)
            {
                if (MListLB.SelectedItem != null)
                {
                    // why am I having a system.outofmemory exception listbox contains too many items here??



                    Headers h = new Headers(MListLB.SelectedItem.ToString());
                    h.ShowDialog();
                }
            }
            
        }
    }
}
