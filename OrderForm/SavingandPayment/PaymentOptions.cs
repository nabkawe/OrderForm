using AutoItX3Lib;
using sharedCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
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



        public PaymentOptions(Invoice inv)
        {
            InitializeComponent();
            if (inv.InEditMode) this.Text += "الطلب جاهز الآن"; 
            dueLBL.Text = inv.InvoicePrice.ToString();
            invoice_price = dueLBL.Text;
            targetTextBox = Cash.Name;
            foreach (Control TB in Controls)
                if (TB is TextBox)
                {
                    TB.GotFocus += TB_GotFocus;

                }
            invoice = inv;
            if (invoice.InvoiceItems.Any(x => x.discount))
            {
                DiscountTB.Text = invoice.InvoiceItems.Where(x => x.discount).Sum(x => x.TotalPrice).ToString().Replace("-", "");
                DiscountTB.Enabled = false;
            }
            invoiceBindingSource.DataSource = inv;
            ShowInvoice();
            this.BringToFront();
            this.Activate();
            this.Update();
            this.Focus();

        }

        private void ShowInvoice()
        {
            if (Properties.Settings.Default.showMenu)
            {
                if (Screen.AllScreens.Count() > 1)
                {
                    Orders.MenuShowing = true;

                    displayOffer.showme(invoice.CustomerName, invoice.CustomerNumber, invoice.TimeinArabic + " | " + Orders.GetDayName((int)invoice.InvoiceDay), invoice);
                }
            }
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
                AutoItX.WinWaitActive(pos, "", 5000);

                AutoItX.ControlClick(pos, "", POSNewBTN, "left", 1);
                if (IsCtrlKeyPressed()) { return; }
                AddItemsToPOS();
                if (IsCtrlKeyPressed()) { return; }

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
                        if (invoice.InvoiceItems.Any(x => x.discount))
                        {
                            var Dispayment = new Payment() { Name = "Discount", Amount = -1 * Convert.ToDecimal(discount) };
                            invoice.Payments.Add(Dispayment);

                        }
                        else
                        {
                            var Dispayment = new Payment() { Name = "Discount", Amount = -1 * Convert.ToDecimal(discount) };
                            invoice.Payments.Add(Dispayment);
                            invoice.InvoicePrice = invoice.InvoicePrice + Dispayment.Amount;
                        }
                    }
                }
                SaveInvoiceNumber();
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
                if (IsCtrlKeyPressed()) { return; }
                AddItemsToPOS();
                if (IsCtrlKeyPressed()) { return; }




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
                            if (invoice.InvoiceItems.Any(x => x.discount))
                            {
                                var Dispayment = new Payment() { Name = "Discount", Amount = -1 * Convert.ToDecimal(discount) };
                                invoice.Payments.Add(Dispayment);

                            }
                            else
                            {
                                var Dispayment = new Payment() { Name = "Discount", Amount = -1 * Convert.ToDecimal(discount) };
                                invoice.Payments.Add(Dispayment);
                                invoice.InvoicePrice = invoice.InvoicePrice + Dispayment.Amount;
                            }
                        }
                    }
                    SaveInvoiceNumber();
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
                            if (invoice.InvoiceItems.Any(x => x.discount))
                            {
                                var Dispayment = new Payment() { Name = "Discount", Amount = -1 * Convert.ToDecimal(discount) };
                                invoice.Payments.Add(Dispayment);

                            }
                            else
                            {
                                var Dispayment = new Payment() { Name = "Discount", Amount = -1 * Convert.ToDecimal(discount) };
                                invoice.Payments.Add(Dispayment);
                                invoice.InvoicePrice = invoice.InvoicePrice + Dispayment.Amount;
                            }
                        }
                    }
                    SaveInvoiceNumber();
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
                if (IsCtrlKeyPressed()) { return; }
                AddItemsToPOS();
                if (IsCtrlKeyPressed()) { return; }


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
                    AutoItX.ControlSend(pos, "", Mada2CB, "م{ENTER}", 0);
                    AutoItX.Sleep(100);


                }

                if (!string.IsNullOrEmpty(Mada3_.Text))
                {
                    AutoItX.ControlSetText(pos, "", Mada3, Mada3_.Text);
                    AutoItX.ControlSend(pos, "", Mada3CB, "م{ENTER}", 0);
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
                        if (invoice.InvoiceItems.Any(x => x.discount))
                        {
                            var Dispayment = new Payment() { Name = "Discount", Amount = -1 * Convert.ToDecimal(discount) };
                            invoice.Payments.Add(Dispayment);

                        }
                        else
                        {
                            var Dispayment = new Payment() { Name = "Discount", Amount = -1 * Convert.ToDecimal(discount) };
                            invoice.Payments.Add(Dispayment);
                            invoice.InvoicePrice = invoice.InvoicePrice + Dispayment.Amount;
                        }
                    }
                }


                SaveInvoiceNumber();
                //AutoItX.ControlClick(pos, "", SaveBTN, "left", 1);
            }
            else if (!CheckIfReadyToSave())
            {
                if (!ModifierKeys.HasFlag(Keys.Control)) { AutoItX.ControlClick(pos, "", POSNewBTN, "left", 2); }
                SaveManualToPOS();
            }

        }

        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int vKey);

        public static bool IsCtrlKeyPressed()
        {
            return (GetAsyncKeyState(0xA2) & 0x8000) != 0;
        }


        /// <summary>
        /// Saving and Updating invoices for invoice number.
        /// </summary>
        /// 

        private void SaveInvoiceNumber()
        {

            string invoiceNTB = AutoItX.ControlGetText(pos, "", InvoiceNumberTB);
            if (!Properties.Settings.Default.TestingMode && !IsCtrlKeyPressed()) AutoItX.ControlClick(pos, "", SaveBTN, "left", 1);
            else
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            invoice.POSInvoiceNumber = invoiceNTB;
            invoice.Status = InvStat.SavedToPOS;
            invoice.TimeOfPrinting = DbInv.GetInvoiceByID(invoice.ID).TimeOfPrinting;
            invoice.TimeOfSaving = DateTime.Now.AddTicks(-(DateTime.Now.Ticks % TimeSpan.TicksPerSecond));
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
            this.DialogResult = DialogResult.OK;
            this.Close();

        }


        /// <summary>
        ///  AddItemsMethods 
        /// </summary>
        /// 

        private void AddItemsToPOS()
        {
            if (DiscountTB.Text != "0" || !string.IsNullOrEmpty(DiscountTB.Text)) { DoDiscount(); }

            
                AutoItX.ControlClick(pos, "", POSClearNumber, "left", 1);
                foreach (var item in invoice.InvoiceItems.Where(x=> !x.discount))
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
                    AutoItX.ControlSetText(pos, "", invoicenotes, "#" + invoice.ID.ToString() + " " + Orders.GetDayName((int)invoice.InvoiceDay) + Environment.NewLine + " | " + invoice.Comment);
                }
                else AutoItX.ControlSetText(pos, "", invoicenotes, "#" + invoice.ID.ToString() + " " + Orders.GetDayName((int)invoice.InvoiceDay) + Environment.NewLine + " | " + invoice.Comment);

            

        }


        private void DoDiscount()
        {
            AutoItX.ControlSetText(pos, "", "[NAME:TextBox2]", DiscountTB.Text);
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
                    MessageForm.SHOW("قم بتشغيل برنامج ليبرا وسجل الدخول قبل محاولة الحفظ", "تنبيه", "مفهوم");
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

            QuickItems.Clear();
            dataGridView1.DataSource = QuickItems;
            GridViewUI();
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
            if (!invoice.InvoiceItems.Any(x => x.discount))
            {
                decimal discounted = Convert.ToDecimal(invoice_price) - Convert.ToDecimal(DiscountTB.Text);
                dueLBL.Text = discounted.ToString();
            }


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
            //Application.OpenForms.OfType<Orders>().First().Activate();




        }

        private void label1_Click(object sender, EventArgs e)
        {
            DiscountTB.Text = "0.5";
        }

       

        private void panel1_Click(object sender, EventArgs e)
        {

        }

        BindingList<POSItems> QuickItems = new BindingList<POSItems>();
        private void QuickAddBTN_Click(object sender, EventArgs e)
        {




            var ContextMenu = new ContextMenu();
            ContextMenu.RightToLeft = RightToLeft.Yes;
            foreach (var section in dbQ.PopulateSections())
            {

                MenuItem menuItem = new MenuItem();
                menuItem.Text = section.Name;

                foreach (var item in dbQ.GetItemsForSection(section.Name))
                {
                    MenuItem Item = new MenuItem(item.Name, onClick);
                    Item.Tag = item.Barcode.ToString();
                    menuItem.MenuItems.Add(Item);
                }
                ContextMenu.MenuItems.Add(menuItem);

            }
            ContextMenu.Show(QuickAddBTN, new Point(0, 0));

        }

        private void GridViewUI()
        {

            List<string> ColumnsList = new List<string>();
            // create a foreach loop to loop through columns and delete some of them that don't meet a certain condition
            foreach (DataGridViewColumn x in dataGridView1.Columns)
            {
                if (x.DataPropertyName == "Name" || x.DataPropertyName == "Quantity" || x.Name == "Increment")
                {
                    continue;
                }
                ColumnsList.Add(x.Name);
            }

            ColumnsList.ForEach(x => dataGridView1.Columns.Remove(x));

            if (!dataGridView1.Columns.Contains("Increment"))
            {


                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.Name = "Increment";
                buttonColumn.HeaderText = "زيادة سريعة";
                buttonColumn.Text = "+";
                buttonColumn.FlatStyle = FlatStyle.Popup;

                buttonColumn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(buttonColumn);
            }


        }

        private void onClick(object sender, EventArgs e)
        {

            if (!quickPayGB.Visible) { quickPayGB.Visible = true; }

            var se = sender as MenuItem;
            var order = Orders.ItemsLists.First(x => x.Barcode == se.Tag.ToString());
            order.Quantity = 1;
            QuickItems.Add(order);
            GridViewUI();


        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine(e.RowIndex);
            // Check if the clicked cell is in the buttons column
            if (e.ColumnIndex == dataGridView1.Columns["Increment"].Index && e.RowIndex >= 0)
            {
                // Get the value of the cell in column [1] of the same row
                int value = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value);

                // Increment the value by 1
                value++;

                // Set the new value to the cell in column [1] of the same row
                dataGridView1.Rows[e.RowIndex].Cells[2].Value = value;
            }
        }

        private void AddToInvoice_Click(object sender, EventArgs e)
        {
            quickPayGB.Visible = false;
            QuickAddBTN.Enabled = false;
            QuickAddBTN.Text = "تمت إضافة المواد السريعة إلى الفاتورة";


            var poslist = new List<POSItems>();
            poslist.Clear();
            foreach (POSItems Material in invoice.InvoiceItems)
            {
                {
                    poslist.Add(Material);
                }
            }
            QuickItems.ToList().ForEach(x => poslist.Add(x));

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

            invoice.InvoiceItems.Clear();
            foreach (var group in poslist)
            {
                invoice.InvoiceItems.Add(group);
            }
            invoice.InvoicePrice = invoice.InvoiceItems.Sum(x => x.TotalPrice);
            dueLBL.Text = invoice.InvoicePrice.ToString();
            invoice_price = dueLBL.Text;

            this.Update();
            this.Refresh();
            Orders.POS.Clear();
            invoice.InvoiceItems.ToList().ForEach(x => Orders.POS.Add(x));
            ShowInvoice();
        }

        private void PreviewOrder_Click(object sender, EventArgs e)
        {
            var t = new ToolTip();
            t.UseAnimation = false;
            t.UseFading = false;
            t.ToolTipTitle = "الطلب حتى الآن" + Environment.NewLine + "_____________" + Environment.NewLine;
            string OrderSoFar = "" + Environment.NewLine;
            foreach (var mat in invoice.InvoiceItems)
            {
                OrderSoFar += $"{mat.Name} - {mat.Quantity}  " + Environment.NewLine;
            }
            OrderSoFar += Environment.NewLine + " ";
            t.Show(OrderSoFar, PreviewOrder, 35, 35, 5000);
        }

        private void PartCashLabel_click(object sender, EventArgs e)
        {
            // lookup ChangeLBL.Text if it's not zero and is not negative number then put it's value inside the textbox PartCash
            if (ChangeLBL.Text != "0.00" && !ChangeLBL.Text.Contains("-"))
            {
                PartCash_.Text = ChangeLBL.Text;
            }
        }

        private void Mada1LBL_Click(object sender, EventArgs e)
        {
            // do the same as PartCashLabel_click  but for Mada1_ textbox   
            if (ChangeLBL.Text != "0.00" && ChangeLBL.Text != "0.0" && !ChangeLBL.Text.Contains("-"))
            {
                Mada1_.Text = ChangeLBL.Text;
            }
            // repeat for Mada2_ textbox    

        }

        private void Mada2LBL_Click(object sender, EventArgs e)
        {
            if (ChangeLBL.Text != "0.00" && ChangeLBL.Text != "0.0" && !ChangeLBL.Text.Contains("-"))
            {
                Mada2_.Text = ChangeLBL.Text;
            }
        }

        private void TryOrderBTN_Click(object sender, EventArgs e)
        {
            if (MessageForm.SHOW("هل أنت متأكد من رغبتك في تخزين الفاتورة كفاتورة تطبيق ؟", "متأكد؟", "نعم", "لا") == DialogResult.No)
            {
                return;
            }
            repeat += 1;
            if (repeat > 6)
            {
                this.Close();
                return;

            }
            if (GetPOSWindow() && CheckIfReadyToSave())
            {
                AutoItX.WinActivate(pos);

                AutoItX.WinWaitActive(pos, "", 5000);
                
                AutoItX.ControlClick(pos, "", POSNewBTN, "left", 1);
                if (IsCtrlKeyPressed()) { return; }
                AddItemsToPOS();
                if (IsCtrlKeyPressed()) { return; }



                if (Convert.ToInt32(AutoItX.ControlCommand(pos, "", CashTextBox, "IsEnabled", "")) == 1)
                {
                    AutoItX.ControlClick(pos, "", SwitchBTN, "left", 1);
                    AutoItX.Sleep(500);
                    AutoItX.ControlSetText(pos, "", Mada1, "0");
                    AutoItX.ControlSetText(pos, "", Mada3, invoice_price);
                    AutoItX.ControlCommand(pos, "", Mada3CB, "ShowDropDown", "");
                    AutoItX.ControlSend(pos, "", Mada3CB, "T{ENTER}", 0);
                    AutoItX.Sleep(100);
                    //AutoItX.ControlSetText("T{RETURN}");


                    var payment = new Payment() { Name = "TryOrder", Amount = invoice.InvoicePrice };
                    invoice.Payments.Clear();
                    invoice.Payments.Add(payment);
                    if (Decimal.TryParse(DiscountTB.Text, out decimal discount))
                    {
                        if (discount > 0)
                        {
                            if (invoice.InvoiceItems.Any(x => x.discount))
                            {
                                var Dispayment = new Payment() { Name = "Discount", Amount = -1 * Convert.ToDecimal(discount) };
                                invoice.Payments.Add(Dispayment);

                            }
                            else
                            {
                                var Dispayment = new Payment() { Name = "Discount", Amount = -1 * Convert.ToDecimal(discount) };
                                invoice.Payments.Add(Dispayment);
                                invoice.InvoicePrice = invoice.InvoicePrice + Dispayment.Amount;
                            }
                        }
                    }
                    SaveInvoiceNumber();
                    //AutoItX.ControlClick(pos, "", SaveBTN, "left", 1);
                }
                else
                {
                    AutoItX.ControlClick(pos, "", SwitchBTN, "left", 1);
                    AutoItX.Sleep(1000);
                    AutoItX.ControlClick(pos, "", SwitchBTN, "left", 1);
                    AutoItX.Sleep(1000);
                    var payment = new Payment() { Name = "TryOrder", Amount = invoice.InvoicePrice };
                    invoice.Payments.Clear();
                    invoice.Payments.Add(payment);
                    if (Decimal.TryParse(DiscountTB.Text, out decimal discount))
                    {
                        if (discount > 0)
                        {
                            if (invoice.InvoiceItems.Any(x => x.discount))
                            {
                                var Dispayment = new Payment() { Name = "Discount", Amount = -1 * Convert.ToDecimal(discount) };
                                invoice.Payments.Add(Dispayment);

                            }
                            else
                            {
                                var Dispayment = new Payment() { Name = "Discount", Amount = -1 * Convert.ToDecimal(discount) };
                                invoice.Payments.Add(Dispayment);
                                invoice.InvoicePrice = invoice.InvoicePrice + Dispayment.Amount;
                            }
                        }
                    }
                    SaveInvoiceNumber();
                    //AutoItX.ControlClick(pos, "", SaveBTN, "left", 1);
                }


            }
            else if (!CheckIfReadyToSave())
            {
                if (!ModifierKeys.HasFlag(Keys.Control)) { AutoItX.ControlClick(pos, "", POSNewBTN, "left", 2); }
                
            }
        }

        private void Mada3LBL_Click(object sender, EventArgs e)
        {
            // now do the same for Mada3_ textbox upon mada3LBL click event 
            if (ChangeLBL.Text != "0.00" && ChangeLBL.Text != "0.0" && !ChangeLBL.Text.Contains("-"))
            {

                Mada3_.Text = ChangeLBL.Text;
            }

        }




        //private void Btn50_Click(object sender, EventArgs e)
        //{
        //    if (ModifierKeys.HasFlag(Keys.Control))
        //    {

        //        SaveInvoiceNumber();
        //    }
        //    else
        //    {

        //        var s = (Button)sender;
        //        if (s != null)
        //        {
        //            Cash.Text = s.Text;
        //            Cash.Focus();
        //            SendKeys.Send("{End}");
        //        }

        //    }
        //}
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
