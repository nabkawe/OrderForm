﻿using AutoItX3Lib;
using sharedCode;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace OrderForm.SavingandPayment
{
    public partial class PaymentOptions : Form
    {

        public string pos = Properties.Settings.Default.pos;
        public string barcodetb = Properties.Settings.Default.barcodetb;
        public string invoiceprc = Properties.Settings.Default.invoiceprc;
        public string invoicenotes = Properties.Settings.Default.invoicenotes;
        public string btntogo = Properties.Settings.Default.btntogo;
        public string btnphone = Properties.Settings.Default.btnphone;
        public string btn1 = Properties.Settings.Default.btn1;
        public string btn2 = Properties.Settings.Default.btn2;
        public string btn3 = Properties.Settings.Default.btn3;
        public string btn4 = Properties.Settings.Default.btn4;
        public string btn5 = Properties.Settings.Default.btn5;
        public string btn6 = Properties.Settings.Default.btn6;
        public string btn7 = Properties.Settings.Default.btn7;
        public string btn8 = Properties.Settings.Default.btn8;
        public string btn9 = Properties.Settings.Default.btn9;
        public string btn0 = Properties.Settings.Default.btn0;
        public string btnsubmit = Properties.Settings.Default.btnsubmit;
        public string amountlbl = Properties.Settings.Default.amountlbl;
        public string CashTextBox = Properties.Settings.Default.CashTextBox;
        public string SaveBTN = Properties.Settings.Default.SaveBTN;
        public string SwitchBTN = Properties.Settings.Default.SwitchBTN;
        public string Mada1 = Properties.Settings.Default.Mada1;
        public string Mada2 = Properties.Settings.Default.Mada2;
        public string Mada3 = Properties.Settings.Default.Mada3;
        public string Mada1CB = Properties.Settings.Default.Mada1Combo;
        public string Mada2CB = Properties.Settings.Default.Mada2Combo;
        public string Mada3CB = Properties.Settings.Default.Mada3Combo;
        public string PartCash = Properties.Settings.Default.PartCash;
        public string POSmainName = Properties.Settings.Default.POSMainName;
        public string InvoiceNumberTB = Properties.Settings.Default.InvoiceNumberTB;
        public string InvoiceTime = Properties.Settings.Default.InvoiceTime;
        public string POSShortcut = Properties.Settings.Default.POSShortcut;
        public string POSWinShortcut = Properties.Settings.Default.POSWinShortcut;
        public string POSNewBTN = Properties.Settings.Default.POSNewBTN;
        public string POSClearNumber = Properties.Settings.Default.POSClearNumber;
        public string POSPhoneNumber = Properties.Settings.Default.POSPhoneNumber;
        public string POSClientName = Properties.Settings.Default.POSClientName;
        public AutoItX3 AutoItX = new AutoItX3();

        public bool singleOrMultipleInvoice;
        public List<Invoice> MultipleInvoices = new List<Invoice>();
        public List<POSItems> MultipleItems = new List<POSItems>();

        public static Invoice invoice;


        public PaymentOptions(string posID)
        {
            if (GetPOSWindow())
            {
                AutoItX.WinActivate(pos);
                AutoItX.WinWaitActive(pos, "", 5000);

                AutoItX.ControlSetText(pos, "", InvoiceNumberTB, posID);
                AutoItX.ControlSend(pos, "", InvoiceNumberTB, "{ENTER}");
                this.Close();
            }
            else
            {
                this.Close();

            }
        }



        public PaymentOptions(Invoice inv) // SingleInvoice Constructor
        {
            InitializeComponent();
            //Cash.Text = inv.InvoicePrice.ToString();
            dueLBL.Text = inv.InvoicePrice.ToString();
            invoice_price = dueLBL.Text;
            targetTextBox = Cash.Name;

            //InvoiceLabel.Text = $"{inv.ID} {Environment.NewLine} {inv.CustomerName}   {inv.CustomerNumber}   {inv.Comment} ";
            foreach (Control TB in Controls)
                if (TB is TextBox)
                {
                    TB.GotFocus += TB_GotFocus;

                }
            singleOrMultipleInvoice = true;
            invoice = inv;
            invoiceBindingSource.DataSource = inv;
            ShowInvoice();
            this.BringToFront();
            this.Activate();
            this.Update();
            this.Focus();

        }

        private void ShowInvoice()
        {
            if (Screen.AllScreens.Count() > 1)
            {
                Orders.MenuShowing = true;

                displayOffer.showme(invoice.CustomerName, invoice.CustomerNumber, invoice.TimeinArabic + " | " + Orders.GetDayName((int)invoice.InvoiceDay), invoice);
            }
        }

        public PaymentOptions(List<Invoice> invList) // SingleInvoice Constructor
        {
            InitializeComponent();
            //Cash.Text = inv.InvoicePrice.ToString();
            dueLBL.Text = invList.Sum(x => x.InvoicePrice).ToString();
            invoice_price = dueLBL.Text;
            targetTextBox = Cash.Name;
            foreach (Control TB in Controls)
                if (TB is TextBox)
                {
                    TB.GotFocus += TB_GotFocus;

                }
            singleOrMultipleInvoice = false; ;
            invList.ForEach(x => this.MultipleInvoices.Add(x));
            invoice = MultipleInvoices[0];
            //ShowInvoice();
            this.Activate();
            this.Update();

        }



        /// <summary>
        ///  Full Cash or Plus Cash
        /// </summary>
        private void CashBTN_Click(object sender, EventArgs e)
        {
            repeat += 1;
            if (repeat > 6)
            {
                this.Close();
                return;
            }
            if (GetPOSWindow() && CheckIfReadyToSave())
            {
                AutoItX.WinActivate(pos);
                AutoItX.WinWaitActive(pos,"",5000); 
                //if (Convert.ToDecimal(AutoItX.ControlGetText(pos, "", invoiceprc)) != 0)
                //{
                //    AutoItX.WinActivate(pos);
                //    AutoItX.ControlClick(pos, "", POSNewBTN, "left", 1);
                //    AutoItX.Send("{ENTER}");
                //    CashBTN_Click(null, null);
                //    return;
                //}
                AutoItX.ControlClick(pos, "", POSNewBTN, "left", 1);
                AddItemsToPOS(singleOrMultipleInvoice);
                if (Convert.ToInt32(AutoItX.ControlCommand(pos, "", CashTextBox, "IsEnabled", "")) == 1)
                {
                    if (string.IsNullOrWhiteSpace(Cash.Text))
                    {

                        AutoItX.ControlSetText(pos, "", CashTextBox, dueLBL.Text);
                    }
                    else
                    {
                        var testPrice = Convert.ToDecimal(this.Cash.Text);
                        if (testPrice > Convert.ToDecimal(dueLBL.Text))
                        {
                            AutoItX.ControlSetText(pos, "", CashTextBox, testPrice.ToString());
                        }
                        else AutoItX.ControlSetText(pos, "", CashTextBox, dueLBL.Text);
                    }
                }
                else
                {
                    AutoItX.ControlClick(pos, "", SwitchBTN, "left", 1);
                    AutoItX.Sleep(500);

                }
                var payment = new Payment() { Name = "Cash", Amount = (decimal)invoice.InvoicePrice };

                invoice.Payments.Clear();
                invoice.Payments.Add(payment);

                if (Decimal.TryParse(DiscountTB.Text, out decimal discount))
                {
                    if (discount > 0)
                    {
                        var Dispayment = new Payment() { Name = "Discount", Amount = -1 * Convert.ToDecimal(discount) };
                        invoice.Payments.Add(Dispayment);
                        invoice.InvoicePrice = invoice.InvoicePrice + Dispayment.Amount;

                    }
                }
                SaveInvoiceNumber(singleOrMultipleInvoice);
            }
            else if (!CheckIfReadyToSave())
            {
                if (!ModifierKeys.HasFlag(Keys.Control)) { AutoItX.ControlClick(pos, "", POSNewBTN, "left", 2); }
                CashBTN_Click(null, null);
            }

        }


        /// <summary>
        ///  Full Mada Save
        /// </summary>
        private void MadaBTN_Click(object sender, EventArgs e)
        {
            repeat += 1;
            if (repeat > 6)
            {
                this.Close();
                return;

            }
            if (GetPOSWindow() && CheckIfReadyToSave())
            {
                //if (Convert.ToDecimal(AutoItX.ControlGetText(pos, "", invoiceprc)) != 0)
                //{
                //    AutoItX.WinActivate(pos);
                //    if (!ModifierKeys.HasFlag(Keys.Control)) { AutoItX.ControlClick(pos, "", POSNewBTN, "left", 1); }
                //    AutoItX.Send("{ENTER}");
                //    MadaBTN_Click(null, null);
                //    return;

                //}
                AutoItX.WinActivate(pos);

                AutoItX.WinWaitActive(pos, "", 5000);

                AutoItX.ControlClick(pos, "", POSNewBTN, "left", 1);

                AddItemsToPOS(singleOrMultipleInvoice);

                if (Convert.ToInt32(AutoItX.ControlCommand(pos, "", CashTextBox, "IsEnabled", "")) == 1)
                {
                    AutoItX.ControlClick(pos, "", SwitchBTN, "left", 1);
                    AutoItX.Sleep(500);
                    var payment = new Payment() { Name = "Mada", Amount = invoice.InvoicePrice };
                    invoice.Payments.Clear();
                    invoice.Payments.Add(payment);
                    if (Decimal.TryParse(DiscountTB.Text, out decimal discount))
                    {
                        if (discount > 0)
                        {
                            var Dispayment = new Payment() { Name = "Discount", Amount = -1 * Convert.ToDecimal(discount) };
                            invoice.Payments.Add(Dispayment);
                            invoice.InvoicePrice = invoice.InvoicePrice + Dispayment.Amount;

                        }
                    }
                    SaveInvoiceNumber(singleOrMultipleInvoice);
                    //AutoItX.ControlClick(pos, "", SaveBTN, "left", 1);
                }
                else
                {
                    AutoItX.ControlClick(pos, "", SwitchBTN, "left", 1);
                    AutoItX.Sleep(1000);
                    AutoItX.ControlClick(pos, "", SwitchBTN, "left", 1);
                    AutoItX.Sleep(1000);
                    var payment = new Payment() { Name = "Mada", Amount = invoice.InvoicePrice };
                    invoice.Payments.Clear();
                    invoice.Payments.Add(payment);
                    if (Decimal.TryParse(DiscountTB.Text, out decimal discount))
                    {
                        if (discount > 0)
                        {
                            var Dispayment = new Payment() { Name = "Discount", Amount = -1 * Convert.ToDecimal(discount) };
                            invoice.Payments.Add(Dispayment);
                            invoice.InvoicePrice = invoice.InvoicePrice + Dispayment.Amount;

                        }
                    }
                    SaveInvoiceNumber(singleOrMultipleInvoice);
                    //AutoItX.ControlClick(pos, "", SaveBTN, "left", 1);
                }


            }
            else if (!CheckIfReadyToSave())
            {
                if (!ModifierKeys.HasFlag(Keys.Control)) { AutoItX.ControlClick(pos, "", POSNewBTN, "left", 2); }
                MadaBTN_Click(null, null);
            }

        }



        /// <summary>
        /// 
        /// Partial Mada Partial Cash Money Entry
        /// 
        /// </summary>
        private void ManualBTN_Click(object sender, EventArgs e)
        {
            //if (Convert.ToDecimal(AutoItX.ControlGetText(pos, "", invoiceprc)) == 0)
            {
                SaveManualToPOS();
            }

        }
        private void SaveManualToPOS()
        {
            repeat += 1;
            if (repeat > 6)
            {
                this.Close();
                return;

            }
            if (GetPOSWindow() && CheckIfReadyToSave())
            {
                //if (Convert.ToDecimal(AutoItX.ControlGetText(pos, "", invoiceprc)) != 0)
                //{
                //    AutoItX.WinActivate(pos);
                //    if (!ModifierKeys.HasFlag(Keys.Control)) { AutoItX.ControlClick(pos, "", POSNewBTN, "left", 1); }

                //    AutoItX.Send("{ENTER}");
                //    SaveManualToPOS();
                //    return;

                //}
                AutoItX.WinActivate(pos);
                AutoItX.WinWaitActive(pos, "", 5000);



                AutoItX.ControlClick(pos, "", POSNewBTN, "left", 1);
                AddItemsToPOS(singleOrMultipleInvoice);

                AutoItX.ControlClick(pos, "", SwitchBTN, "left");
                AutoItX.Sleep(500);
                if (!string.IsNullOrEmpty(PartCash_.Text))
                {
                    AutoItX.ControlSetText(pos, "", PartCash, PartCash_.Text);
                    AutoItX.Sleep(100);
                }
                else AutoItX.ControlSetText(pos, "", PartCash, "0");
                if (!string.IsNullOrEmpty(Mada1_.Text))
                {
                    AutoItX.ControlSetText(pos, "", Mada1, Mada1_.Text);
                    AutoItX.Sleep(100);
                }
                else AutoItX.ControlSetText(pos, "", Mada1, "0");
                if (!string.IsNullOrEmpty(Mada2_.Text))
                {
                    AutoItX.ControlSetText(pos, "", Mada2, Mada2_.Text);
                    AutoItX.ControlClick(pos, "", Mada2CB, "Left");
                    AutoItX.ControlSend(pos, "", Mada2CB, "{DOWN}{ENTER}", 0);
                    AutoItX.Sleep(100);
                    
                   
                }

                if (!string.IsNullOrEmpty(Mada3_.Text))
                {
                    AutoItX.ControlSetText(pos, "", Mada3, Mada3_.Text);
                    AutoItX.ControlClick(pos, "", Mada3CB, "Left");
                    AutoItX.ControlSend(pos, "", Mada3CB, "{DOWN}{ENTER}", 0);
                    AutoItX.Sleep(100);

                }
                invoice.Payments.Clear();

                if (c != 0)
                {
                    var payment = new Payment() { Name = "Cash", Amount = invoice.InvoicePrice };
                    invoice.Payments.Add(payment);
                }
                if (m1 != 0)
                {
                    var payment = new Payment() { Name = "Mada", Amount = invoice.InvoicePrice };
                    invoice.Payments.Add(payment);
                }
                if (m2 != 0)
                {
                    var payment = new Payment() { Name = "Mada", Amount = invoice.InvoicePrice };
                    invoice.Payments.Add(payment);
                }
                if (m3 != 0)
                {
                    var payment = new Payment() { Name = "Mada", Amount = invoice.InvoicePrice };
                    invoice.Payments.Add(payment);
                }

                if (Decimal.TryParse(DiscountTB.Text, out decimal discount))
                {
                    if (discount > 0)
                    {
                        var Dispayment = new Payment() { Name = "Discount", Amount = -1 * Convert.ToDecimal(discount) };
                        invoice.Payments.Add(Dispayment);
                        invoice.InvoicePrice = invoice.InvoicePrice + Dispayment.Amount;

                    }
                }


                SaveInvoiceNumber(singleOrMultipleInvoice);
                //AutoItX.ControlClick(pos, "", SaveBTN, "left", 1);
            }
            else if (!CheckIfReadyToSave())
            {
                if (!ModifierKeys.HasFlag(Keys.Control)) { AutoItX.ControlClick(pos, "", POSNewBTN, "left", 2); }
                SaveManualToPOS();
            }

        }



        /// <summary>
        /// Saving and Updating invoices for invoice number.
        /// </summary>
        private void SaveInvoiceNumber(bool single)
        {

            string invoiceNTB = AutoItX.ControlGetText(pos, "", InvoiceNumberTB);
            if (!Properties.Settings.Default.TestingMode) AutoItX.ControlClick(pos, "", SaveBTN, "left", 1);

            if (single)
            {
                invoice.POSInvoiceNumber = invoiceNTB;
                DateTime DT = DateTime.Now;
                invoice.Status = InvStat.SavedToPOS;
                invoice.TimeOfSaving = DT;
                DbInv.UpdateInvoice(invoice);
                if (Orders.MyCheckBox.Checked)
                {
                    if (invoice.InvoicePrice >= 25 || invoice.OrderType == "محلي")
                    {
                        PrintInvoiceReady.Print(dbQ.CashierPrinter(), invoice);
                    }
                }
                else
                {
                    if (invoice.OrderType == "محلي")
                    {
                        PrintInvoiceReady.Print(dbQ.CashierPrinter(), invoice);
                    }
                }

            }
            else
            {
                if (MultipleInvoices.Count > 1)
                {


                    DateTime DT = DateTime.Now;

                    var Update = new Invoice();
                    CreateNewListOfItems().ForEach(x => Update.InvoiceItems.Add(x));
                    Update.POSInvoiceNumber = invoiceNTB;
                    Update.Status = InvStat.SavedToPOS;
                    Update.InvoicePrice = Update.InvoiceItems.Sum(x => x.TotalPrice);
                    string c = invoice.Comment;
                    Update.Comment = "فاتورة مجمعة" + " " + c;
                    Update.ID = invoice.ID; Update.OrderType = invoice.OrderType;
                    Update.CustomerName = invoice.CustomerName;
                    Update.CustomerNumber = invoice.CustomerNumber;
                    Update.InvoiceDay = invoice.InvoiceDay;
                    Update.Tax = invoice.Tax;
                    Update.TimeAMPM = invoice.TimeAMPM;
                    Update.TimeOfPrinting = invoice.TimeOfPrinting;
                    Update.TimeOfSaving = DT;
                    Update.TimeinArabic = invoice.TimeinArabic;
                    invoice.Payments.ForEach(x => Update.Payments.Add(x));

                    CheckBox parentCheckBox = (CheckBox)this.Owner.GetType().GetProperty("ParentCheckBox").GetValue(this.Owner, null);
                    if (Application.OpenForms.OfType<Orders>().First().checkBox1.Checked)
                    {
                        if (invoice.InvoicePrice >= 25 || invoice.OrderType == "محلي")
                        {
                            PrintInvoiceReady.Print(dbQ.CashierPrinter(), Update);
                        }
                    }
                    else
                    {
                        if (invoice.OrderType == "محلي")
                        {
                            PrintInvoiceReady.Print(dbQ.CashierPrinter(), Update);
                        }
                    }


                    for (int i = 0; i < MultipleInvoices.Count; i++)
                    {
                        if (MultipleInvoices[i].ID != invoice.ID)
                        {
                            MultipleInvoices[i].InvoiceItems.Clear();
                            MultipleInvoices[i].Comment = "فاتورة مجمعة تابعة لرقم: " + invoice.ID;
                            MultipleInvoices[i].Status = InvStat.Deleted;
                            MultipleInvoices[i].InvoicePrice = 0;

                            DbInv.UpdateInvoice(MultipleInvoices[i]);
                            DbInv.LogAction($"Multiple Saved in {invoice.ID}", MultipleInvoices[i].ID, InvStat.Deleted);
                        }
                        else
                        {
                            DbInv.UpdateInvoice(Update);
                        }

                    }


                }
                else
                {
                    SaveInvoiceNumber(true);
                }
            }
            this.Close();

        }


        /// <summary>
        ///  AddItemsMethods 
        /// </summary>
        /// 

        private void AddItemsToPOS(bool single)
        {
            if (DiscountTB.Text != "0" || !string.IsNullOrEmpty(DiscountTB.Text)) { DoDiscount(); }

            if (singleOrMultipleInvoice)
            {
                AutoItX.ControlClick(pos, "", POSClearNumber, "left", 1);
                foreach (var item in invoice.InvoiceItems)
                {
                    AutoItX.ControlClick(pos, "", barcodetb, "left", 1);
                    AutoItX.ControlSend(pos, "", barcodetb, item.Barcode, 0);
                    AutoItX.ControlSend(pos, "", barcodetb, "{ENTER}", 0);
                    int q = Convert.ToInt32(item.Quantity);
                    AutoItX.ControlSetText(pos, "", amountlbl, q.ToString());
                    AutoItX.ControlClick(pos, "", btnsubmit, "left", 1);
                }
                string invoiceNTB = AutoItX.ControlGetText(pos, "", InvoiceNumberTB);

                if (!string.IsNullOrWhiteSpace(invoice.CustomerName))
                {

                    AutoItX.ControlSetText(pos, "", POSClientName, invoice.CustomerName);
                    AutoItX.ControlSetText(pos, "", POSPhoneNumber, invoice.CustomerNumber);
                    AutoItX.ControlSetText(pos, "", invoicenotes, "#" + invoice.ID.ToString() + " " + Orders.GetDayName((int)invoice.InvoiceDay) + Environment.NewLine + "رقم الفاتورة:" + invoiceNTB + " ||| " + invoice.Comment);



                }
                else AutoItX.ControlSetText(pos, "", invoicenotes, "#" + invoice.ID.ToString() + " " + Orders.GetDayName((int)invoice.InvoiceDay) + Environment.NewLine + "رقم الفاتورة:" + invoiceNTB + " ||| " + invoice.Comment);

            }
            else
            {

                var InvoiceItems = CreateNewListOfItems();
                AutoItX.ControlClick(pos, "", POSClearNumber, "left", 1);

                foreach (var item in InvoiceItems)
                {

                    AutoItX.ControlClick(pos, "", barcodetb, "left", 1);
                    AutoItX.ControlSend(pos, "", barcodetb, item.Barcode, 0);
                    AutoItX.ControlSend(pos, "", barcodetb, "{ENTER}", 0);
                    int q = Convert.ToInt32(item.Quantity);
                    AutoItX.ControlSetText(pos, "", amountlbl, q.ToString());
                    AutoItX.ControlClick(pos, "", btnsubmit, "left", 1);
                }
                List<string> invoiceIDS = new List<string>();
                MultipleInvoices.ForEach(x => invoiceIDS.Add(x.ID.ToString()));

                var joinedNames = invoiceIDS.Aggregate((a, b) => a + "-" + b);
                string invoiceNTB = AutoItX.ControlGetText(pos, "", InvoiceNumberTB);


                AutoItX.ControlSetText(pos, "", POSClientName, this.MultipleInvoices[0].CustomerName);
                AutoItX.ControlSetText(pos, "", POSPhoneNumber, this.MultipleInvoices[0].CustomerNumber);

                AutoItX.ControlSetText(pos, "", invoicenotes, "أوراق تحضير:" + joinedNames);
                AutoItX.ControlSetText(pos, "", invoicenotes, "رقم التحضير:" + " " + this.MultipleInvoices[0].ID.ToString() + Environment.NewLine + "رقم الفاتورة:" + invoiceNTB + " ||| " + this.MultipleInvoices[0].Comment);




            }
        }


        private void DoDiscount()
        {
            AutoItX.ControlSetText(pos, "", "[NAME:TextBox2]", DiscountTB.Text);
        }

        private List<POSItems> CreateNewListOfItems()
        {
            MultipleItems.Clear();
            foreach (var item in this.MultipleInvoices)
            {
                foreach (var i in item.InvoiceItems)
                {
                    if (MultipleItems.Any(x => x.Name == i.Name))
                    {
                        MultipleItems.Where(w => w.Name == i.Name).ToList().ForEach(s => s.Quantity += i.Quantity);
                    }
                    else
                    {
                        MultipleItems.Add(i);
                    }

                }
            }
            var list = new List<POSItems>();
            foreach (var x in MultipleItems)
            {
                list.Add(x);
            }
            return list;
        }


        /// <summary>
        /// POS Check Code
        /// </summary>
        private bool CheckIfReadyToSave()
        {
            if (AutoItX.ControlGetText(pos, "", InvoiceTime).Contains("PM") ||
                AutoItX.ControlGetText(pos, "", InvoiceTime).Contains("AM"))
            {
                return true;
            }
            return false;
        }
        private bool OpenNewPosWindow()
        {
            AutoItX.WinActivate(POSmainName);
            AutoItX.WinSetState(POSmainName, "", AutoItX.SW_MAXIMIZE);
            AutoItX.WinSetOnTop(POSmainName, "", 1);
            AutoItX.ControlClick(POSmainName, "", POSShortcut, "LEFT", 2, 58, 232);
            AutoItX.ControlClick(POSmainName, "", POSWinShortcut, "LEFT", 1);
            AutoItX.WinSetOnTop(POSmainName, "", 0);
            AutoItX.WinSetState(POSmainName, "", AutoItX.SW_MINIMIZE);
            AutoItX.WinActivate(pos);
            if (AutoItX.WinWaitActive(pos, "", 5000) == 1)
            {
                return true;
            }
            else return false;


        }
        int repeat = 0;
        private bool GetPOSWindow()
        {
            if (AutoItX.WinExists(pos) == 1)
            {
                AutoItX.WinSetState(pos, "", AutoItX.SW_RESTORE);
                AutoItX.WinSetState(pos, "", AutoItX.SW_MAXIMIZE);
                AutoItX.WinSetState("WhatsApp", "", AutoItX.SW_MINIMIZE);
                return true;
                // code for checking empty or not.

            }
            else if (AutoItX.WinExists(POSmainName) == 1)
            {
                if (OpenNewPosWindow())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                repeat += 1;
                if (repeat > 3)
                {
                    this.Close();
                    return true;

                }
                else
                {
                    MessageBox.Show("قم بتشغيل برنامج ليبرا وسجل الدخول قبل محاولة الحفظ");
                    return false;
                }
            }
        }





        ///Pure UI Related  Code
        /// Payment Math
        public decimal PaidAmount;
        public string targetTextBox;
        decimal d, m1, m2, m3, c;
        private void CalculateMultiMoney()
        {
            if (!string.IsNullOrEmpty(dueLBL.Text))
            {
                d = Convert.ToDecimal(dueLBL.Text);
            }

            if (!string.IsNullOrEmpty(PartCash_.Text))
            {
                c = Convert.ToDecimal(PartCash_.Text);
            }

            if (!string.IsNullOrEmpty(Mada1_.Text))
            {
                m1 = Convert.ToDecimal(Mada1_.Text);
            }

            if (!string.IsNullOrEmpty(Mada2_.Text))
            {
                m2 = Convert.ToDecimal(Mada2_.Text);
            }

            if (!string.IsNullOrEmpty(Mada3_.Text))
            {
                m3 = Convert.ToDecimal(Mada3_.Text);
            }

            var paid = c + m1 + m2 + m3;
            paidLBL.Text = paid.ToString();
            var change = d - paid;
            ChangeLBL.Text = change.ToString();
            if (change == 0)
            {
                LBLdue.ForeColor = Color.Green;
            }
            else
            {
                LBLdue.ForeColor = Color.Red;
            }
        }

        private void CalculateSingleMoney()
        {

            d = Convert.ToDecimal(dueLBL.Text);
            if (!string.IsNullOrEmpty(Cash.Text))
            {
                c = Convert.ToDecimal(Cash.Text);
            }
            var paid = c;
            paidLBL.Text = paid.ToString();
            var change = d - paid;
            ChangeLBL.Text = change.ToString();
            if (change == 0)
            {
                LBLdue.ForeColor = Color.Green;
            }
            else
            {
                LBLdue.ForeColor = Color.Red;
            }
        }
        public bool IsNumber(char ch, string text)
        {
            bool res = true;
            char decimalChar = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            //check if it´s a decimal separator and if doesn´t already have one in the text string
            if (ch == decimalChar && text.IndexOf(decimalChar) != -1)
            {
                res = false;
                return res;
            }

            //check if it´s a digit, decimal separator and backspace
            if (!Char.IsDigit(ch) && ch != decimalChar && ch != (char)Keys.Back && ch != '-')
                res = false;

            return res;
        }
        /// 


        /// <summary>
        /// TextBox Related Code
        /// </summary>
        private void TB_GotFocus(object sender, EventArgs e)
        {
            var tb = sender as TextBox;
            targetTextBox = tb.Name;
        }
        private void TextBoxes_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Cash.Text) || Cash.Text != ".")
                try
                {
                    PaidAmount = Convert.ToDecimal(Cash.Text);

                }
                catch (Exception)
                {
                }
        }
        private void TextBoxes_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsNumber(e.KeyChar))

                if (e.KeyChar != '.' && !(char.IsControl(e.KeyChar)))
                    e.Handled = true;




        }
        private void TB_TextChanged(object sender, EventArgs e)
        {
            var se = (TextBox)sender;

            if (string.IsNullOrEmpty(se.Text))
            {
                se.Text = "0";
                se.Focus();
                SendKeys.Send("{End}");
            }
            CalculateMultiMoney();


        }
        private void CashTB_TextChanged(object sender, EventArgs e)
        {
            CalculateSingleMoney();
            var se = (TextBox)sender;

            if (string.IsNullOrEmpty(se.Text))
            {
                se.Text = "0";
                se.Focus();
                SendKeys.Send("{End}");
            }
        }
        /// Pure UI Click Events 
        private void One_Click(object sender, EventArgs e)
        {
            var s = (Button)sender;
            if (s != null)
            {

                foreach (Control control in this.Controls)
                {
                    if (control.Name == targetTextBox)
                    {
                        switch (s.Text)
                        {

                            case "1": control.Focus(); SendKeys.Send("1"); break;
                            case "2": control.Focus(); SendKeys.Send("2"); break;
                            case "3": control.Focus(); SendKeys.Send("3"); break;
                            case "4": control.Focus(); SendKeys.Send("4"); break;
                            case "5": control.Focus(); SendKeys.Send("5"); break;
                            case "6": control.Focus(); SendKeys.Send("6"); break;
                            case "7": control.Focus(); SendKeys.Send("7"); break;
                            case "8": control.Focus(); SendKeys.Send("8"); break;
                            case "9": control.Focus(); SendKeys.Send("9"); break;
                            case "0": control.Focus(); SendKeys.Send("0"); break;
                            case ".": control.Focus(); SendKeys.Send("."); break;
                            case "حذف": control.Focus(); SendKeys.Send("{BACKSPACE}"); break;
                        }
                    }
                }
            }
        }
        private void Minus_Click(object sender, EventArgs e)
        {
            if (!PartCash_.Text.Contains("-"))
            {
                PartCash_.Text = "-" + PartCash_.Text;
            }
            else PartCash_.Text = PartCash_.Text.Replace("-", "");

        }

        private void PaymentOptions_Load(object sender, EventArgs e)
        {


            if (Properties.Settings.Default.CloseWindow)
            {
                while (AutoItX.WinExists(pos, "") == 1)
                {
                    AutoItX.WinClose(pos, "");
                }



            }


        }
        string invoice_price;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(DiscountTB.Text)) { DiscountTB.Text = "0"; dueLBL.Text = invoice_price; }

            decimal discounted = Convert.ToDecimal(invoice_price) - Convert.ToDecimal(DiscountTB.Text);
            dueLBL.Text = discounted.ToString();
        }

        private void PaymentOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Properties.Settings.Default.CloseWindow)
            {
                while (AutoItX.WinExists(pos, "") == 1)
                {
                    AutoItX.WinClose(pos, "");
                }
            }
            displayOffer.CloseNow();
            Application.OpenForms[0].Activate();




        }

        private void label1_Click(object sender, EventArgs e)
        {
            DiscountTB.Text = "0.5";
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Click(object sender, EventArgs e)
        {

        }

        private void Btn50_Click(object sender, EventArgs e)
        {
            if (ModifierKeys.HasFlag(Keys.Control))
            {

                SaveInvoiceNumber(false);
            }
            else
            {

                var s = (Button)sender;
                if (s != null)
                {
                    Cash.Text = s.Text;
                    Cash.Focus();
                    SendKeys.Send("{End}");
                }

            }
        }
        private void Cash_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                CashBTN_Click(this, new EventArgs());
            }
        }
        private void Cash_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox TB = sender as TextBox;
            if (!IsNumber(e.KeyChar, TB.Text))
                e.Handled = true;

        }
        private void BackSpace_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl.Name == targetTextBox)
                    {
                        ctrl.Text = "0";
                        ctrl.Focus();
                        SendKeys.Send("{End}");

                    }
                }
            }
        }
    }
}
