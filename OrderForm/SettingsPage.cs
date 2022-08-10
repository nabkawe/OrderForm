using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using sharedCode;

namespace OrderForm
{
    public partial class SettingsPage : Form
    {

        public SettingsPage()
        {
            InitializeComponent();

        }
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
                POSsections sect = new POSsections();
                sect.Name = groupTB.Text;
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
                List<POSItems> a = dbQ.GetAllMaterials().FindAll(x => x.SectionName == sList.SelectedItem.ToString());
                a.ForEach(x => x.SectionName = "بدون قسم");
                dbQ.DeleteItemSections(a);
                sList.Items.RemoveAt(sList.SelectedIndex);
                listGB.Text = $"المجموعة:";
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
                dbQ.GetSections().ForEach(i => sList.Items.Add(i));

                mat.Items.Clear();
                dbQ.GetAllMaterials().Where(x => x.SectionName == "بدون قسم").ToList().ForEach(i => mat.Items.Add(i));
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
            else if (e.TabPage.Name == "MenuDisplaySettings")
            {
                MultiLB.Items.Clear();
                MenuLB.Items.Clear();
                MListLB.Items.Clear();
                SectionsName.Text = "NoMenu";
                EditItems();
                MenuDB.GetMenus().ForEach(x => MListLB.Items.Add(x));
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
            
            showMenu.Checked = Properties.Settings.Default.showMenu;

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
                List<POSItems> m = dbQ.GetAllMaterials();
                mat.Items.Clear();
                m.ForEach(x => mat.Items.Add(x));
            }
            else
            {
                mat.Items.Clear();
                List<POSItems> m = dbQ.GetAllMaterials();
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
            if (PrintersList1.SelectedItems.Count > 0)
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


            Properties.Settings.Default.Save();
        }

        private void ClearDB_Click(object sender, EventArgs e)
        {
            if (sharedCode.repeatedBehavior.AreYouSure("متأكد؟", "متأكد؟") == true)
            {
                DbInv.DeleteDBInvoices();
            }

        }

        private void Pos_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
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

            POSItems pos = new POSItems()
            {
                Name = NameTB.Text,
                Barcode = BarTB.Text,
                Price = Convert.ToDecimal(prcTB.Text),
                Quantity = Convert.ToInt32(quanTB.Text),
                realquan = Convert.ToInt32(RealQuanTB.Text)
                , Available = available.Checked,
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
                available.Checked= true;    
                NameTB.Focus();
                matLB.Enabled = true;
            }
            else MessageBox.Show("إسم المادة متكرر");



        }

        private void MaterialsEdit_Enter(object sender, EventArgs e)
        {
            MAT.Clear();
            dbQ.LoadMaterialItems().ForEach(x => MAT.Add(x));
            matLB.DataSource = MAT;
            TaxTB.Text = Properties.Settings.Default.CurrentTax.ToString();

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
            POSItems pos = MAT[matLB.SelectedIndex];
            pos.Name = NameTB.Text;
            pos.Barcode = BarTB.Text;
            pos.Price = Convert.ToDecimal(prcTB.Text);
            pos.Quantity = Convert.ToInt32(quanTB.Text);
            pos.realquan = Convert.ToInt32(RealQuanTB.Text);
            pos.PicturePath = PicTB.Text;
            pos.PrinterName = PrinterTB.Text;
            pos.SectionName = SectionNameTB.Text;
            pos.Available=available.Checked;
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
            if (SectionsName.Text != "NoMenu")
            {
                MenuItemsX m = new MenuItemsX()
                {
                    Name = MnameTB.Text,
                    Barcode = MBarcode.Text,
                    ImagePath = Mpath.Text,
                    Price = MPrice.Text,
                    Details = Mdetails.Text,
                    Cal = Mcal.Text,
                    Available = Availables.Checked
                };
                MenuLB.Items.Add(m);
            }
        }

        private void AddToMultiItem_Click(object sender, EventArgs e)
        {
            if (SectionsName.Text != "NoMenu")
            {
                MenuItemsX m = new MenuItemsX()
                {
                    Name = MnameTB.Text,
                    Barcode = MBarcode.Text,
                    ImagePath = Mpath.Text,
                    Price = MPrice.Text,
                    Details = Mdetails.Text,
                    Cal = Mcal.Text,
                    Available = Availables.Checked
                };
                MultiLB.Items.Add(m);
            }
        }

        private void AddMultiItem_Click(object sender, EventArgs e)
        {
            if (SectionsName.Text != "NoMenu")
            {
                List<MenuItemsX> lll = new List<MenuItemsX>();
                MultiLB.Items.Cast<MenuItemsX>().ToList().ForEach(x => { lll.Add(x); });
                MenuLB.Items.Add(lll);
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
                var s = MenuLB.Items.Cast<object>().ToList();
                MenuDB.UpdateSectionItems(s, SectionsName.Text);
                SectionsName.Text = "NoMenu";
                MenuLB.Items.Clear();
            }
        }

        private void MListLB_Click(object sender, EventArgs e)
        {
            if (MListLB.SelectedIndex != -1)
            {
                SectionsName.Text = MListLB.SelectedItem.ToString();
            }
            else
            {
                SectionsName.Text = "NoMenu";
            }
            LoadMenuSectionToEdit(SectionsName.Text);
        }

        private void LoadMenuSectionToEdit(string text)
        {
            MenuLB.Items.Clear();
            var a = MenuDB.GetMenuItems(text);
            if (a != null)
            {
                if (a.Count > 0)
                {
                    foreach (object item in a)
                    {
                        if (item.GetType() == typeof(MenuItemsX))
                        {
                            MenuItemsX x = (MenuItemsX)item;
                            MenuLB.Items.Add(x);
                        }
                        else if (item.GetType() == typeof(object[]))
                        {
                            List<object> L = (item as IEnumerable<object>).Cast<object>().ToList();
                            var LS = L.Cast<MenuItemsX>().ToList();

                            MenuLB.Items.Add(LS);
                        }
                        else if (item.GetType() == typeof(string))
                        {
                            MenuLB.Items.Add((string)item);
                        }


                    }
                }


            }
        }

        private void MenuLB_DoubleClick(object sender, EventArgs e)
        {
            if (MenuLB.SelectedIndex != -1)
            {
                if (MenuLB.SelectedItem.GetType() == typeof(MenuItemsX))
                {
                    if (Control.ModifierKeys != Keys.Control)
                    {
                        MultiLB.Items.Clear();
                        SaveMulti.Enabled = false;
                        AddMultiItem.Enabled = true ;

                        using (var form = new EditMenuItemX())
                        {
                            form.EditItems((MenuItemsX)MenuLB.SelectedItem);
                            var result = form.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                MenuItemsX val = form.MIX;            //values preserved after close
                                                                      //Do something here with these values

                                var a = (MenuItemsX)MenuLB.SelectedItem;
                                //MenuLB.Items.RemoveAt(MenuLB.SelectedIndex);
                                MenuLB.Items[MenuLB.SelectedIndex] = val;


                            }
                        }
                    }
                    else
                    {
                        MultiLB.Items.Add(MenuLB.Items[MenuLB.SelectedIndex]);
                        MenuLB.Items.Remove(MenuLB.Items[MenuLB.SelectedIndex]);
                    }
                }
                else if (MenuLB.SelectedItem.GetType() == typeof(List<MenuItemsX>))
                {
                    var multis = (List<MenuItemsX>)MenuLB.SelectedItem;
                    MultiLB.Items.Clear();
                    multis.ForEach(x => MultiLB.Items.Add(x));
                    SaveMulti.Enabled = true;
                    AddMultiItem.Enabled = false;
                }
            }
        }
        private void EditItems(MenuItemsX x)
        {
            MnameTB.Text = x.Name;
            MBarcode.Text = x.Barcode;
            MPrice.Text = x.Price;
            Mdetails.Text = x.Details;
            Mcal.Text = x.Cal;
            Mpath.Text = x.ImagePath;
            Availables.Checked = x.Available;
        }
        private void EditItems()
        {
            MnameTB.Text = "";
            MBarcode.Text = "";
            MPrice.Text = "";
            Mdetails.Text = "";
            Mcal.Text = "";
            Mpath.Text = "";
            Availables.Checked = true;
        }

        private void MultiLB_DoubleClick(object sender, EventArgs e)
        {
            if (MultiLB.SelectedIndex != -1)
            {
                if (MultiLB.SelectedItem.GetType() == typeof(MenuItemsX))
                {
                    using (var form = new EditMenuItemX())
                    {
                        form.EditItems((MenuItemsX)MultiLB.SelectedItem);
                        var result = form.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            MenuItemsX val = form.MIX;            //values preserved after close
                                                                  //Do something here with these values

                            var a = (MenuItemsX)MultiLB.SelectedItem;
                            //MenuLB.Items.RemoveAt(MenuLB.SelectedIndex);
                            MultiLB.Items[MultiLB.SelectedIndex] = val;


                        }
                    }
                }


                //EditItems((MenuItemsX)MultiLB.SelectedItem);
            }
        }


        private void DeleteM_Click(object sender, EventArgs e)
        {
            if (MenuLB.SelectedIndex != -1)
            {
                int a = MenuLB.SelectedIndex;
                MenuLB.Items.Remove(MenuLB.SelectedItem);
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
            MoveItem(-1, MenuLB);

        }

        private void MDown_Click(object sender, EventArgs e)
        {
            MoveItem(1, MenuLB);
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
                    Mpath.Text = filePath;
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

        private void button14_Click(object sender, EventArgs e)
        {
            MoveItem(-1, MultiLB);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            MoveItem(1, MultiLB);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (MultiLB.SelectedIndex != -1)
            {
                if (repeatedBehavior.AreYouSure("هل تريد حذف المعلومة", "تنبيه")) MultiLB.Items.Remove(MultiLB.SelectedItem);
            }


        }

        private void FastAdd_Click(object sender, EventArgs e)
        {

            if (SectionsName.Text != "NoMenu") sectionsML.Show(QuickAdd,0,0);
        }

        private void SaveMulti_Click(object sender, EventArgs e)
        {
            SaveMulti.Enabled = false;
            AddMultiItem.Enabled = true;

            List<MenuItemsX> lll = new List<MenuItemsX>();
            MultiLB.Items.Cast<MenuItemsX>().ToList().ForEach(x => { lll.Add(x); });
            MenuLB.Items[MenuLB.SelectedIndex] = lll;
            MultiLB.Items.Clear();
        }

        private void sectionsML_Opening(object sender, CancelEventArgs e)
        {
            sectionsML.Items.Clear();
            List<POSsections> lists = dbQ.PopulateSections();

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
                MenuItemsX X = new MenuItemsX() { Available = true, Barcode = item.Barcode, Price = item.Price.ToString(), Name = item.Name };
                MenuLB.Items.Add(X);
            }


        }
    }
}
