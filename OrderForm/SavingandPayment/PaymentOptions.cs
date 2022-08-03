using AutoItX3Lib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using sharedCode;

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

        public bool singleOrMultipleInvoice;
        public List<Invoice> MultipleInvoices = new List<Invoice>();
        public List<POSItems> MultipleItems = new List<POSItems>();

        public Invoice invoice;
        public AutoItX3 ait = new AutoItX3();

        public PaymentOptions(Invoice inv) // SingleInvoice Constructor
        {
            InitializeComponent();
            //Cash.Text = inv.InvoicePrice.ToString();
            dueLBL.Text = inv.InvoicePrice.ToString();
            invoice_price = dueLBL.Text;
            targetTextBox = Cash.Name;
            var invbtn = new _InvBTN(inv);
            invbtn.Enabled = false;
            INVBTN.Controls.Add(invbtn);
            //InvoiceLabel.Text = $"{inv.ID} {Environment.NewLine} {inv.CustomerName}   {inv.CustomerNumber}   {inv.Comment} ";
            foreach (Control TB in Controls)
                if (TB is TextBox)
                {
                    TB.GotFocus += TB_GotFocus;

                }
            singleOrMultipleInvoice = true;
            this.invoice = inv;
        }

        public PaymentOptions(List<Invoice> invList) // SingleInvoice Constructor
        {
            InitializeComponent();
            //Cash.Text = inv.InvoicePrice.ToString();
            dueLBL.Text = invList.Sum(x => x.InvoicePrice).ToString();
            invoice_price = dueLBL.Text;
            targetTextBox = Cash.Name;
            var invbtn = new _InvBTN(invList[0]);
            invbtn.Enabled = false;
            invbtn.Controls.Add(new Label() { Left = 0, Top = 170, Text = "فواتير متعددة" });
            INVBTN.Controls.Add(invbtn);
            foreach (Control TB in Controls)
                if (TB is TextBox)
                {
                    TB.GotFocus += TB_GotFocus;

                }
            singleOrMultipleInvoice = false; ;
            this.MultipleInvoices = invList;
            this.invoice = invList[0];
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
                ait.WinActivate(pos);
                if (Convert.ToDecimal(ait.ControlGetText(pos, "", invoiceprc)) != 0)
                {
                    ait.WinActivate(pos);
                    ait.ControlClick(pos, "", POSNewBTN, "left", 1);
                    ait.Send("{ENTER}");
                    CashBTN_Click(null, null);
                    return;
                }

                AddItemsToPOS(singleOrMultipleInvoice);
                if (Convert.ToInt32(ait.ControlCommand(pos, "", CashTextBox, "IsEnabled", "")) == 1)
                {
                    if (Cash.Text.Replace(" ", "") == "")
                    {

                        ait.ControlSetText(pos, "", CashTextBox, dueLBL.Text);
                    }
                    else
                    {
                        var testPrice = Convert.ToDecimal(this.Cash.Text);
                        if (testPrice > Convert.ToDecimal(dueLBL.Text))
                        {
                            ait.ControlSetText(pos, "", CashTextBox, testPrice.ToString());
                        }
                        else ait.ControlSetText(pos, "", CashTextBox, dueLBL.Text);
                    }
                }
                else
                {
                    ait.ControlClick(pos, "", SwitchBTN, "left", 1);
                    ait.Sleep(500);

                }
                SaveInvoiceNumber(singleOrMultipleInvoice);
            }
            else if (!CheckIfReadyToSave())
            {
                ait.ControlClick(pos, "", POSNewBTN, "left", 2);
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
                if (Convert.ToDecimal(ait.ControlGetText(pos, "", invoiceprc)) != 0)
                {
                    ait.WinActivate(pos);
                    ait.ControlClick(pos, "", POSNewBTN, "left", 1);
                    ait.Send("{ENTER}");
                    MadaBTN_Click(null, null);
                    return;

                }
                AddItemsToPOS(singleOrMultipleInvoice);

                if (Convert.ToInt32(ait.ControlCommand(pos, "", CashTextBox, "IsEnabled", "")) == 1)
                {
                    ait.ControlClick(pos, "", SwitchBTN, "left", 1);
                    ait.Sleep(500);
                    SaveInvoiceNumber(singleOrMultipleInvoice);
                    //ait.ControlClick(pos, "", SaveBTN, "left", 1);
                }
                else
                {
                    ait.ControlClick(pos, "", SwitchBTN, "left", 1);
                    ait.Sleep(1000);
                    ait.ControlClick(pos, "", SwitchBTN, "left", 1);
                    ait.Sleep(1000);
                    SaveInvoiceNumber(singleOrMultipleInvoice);
                    //ait.ControlClick(pos, "", SaveBTN, "left", 1);
                }


            }
            else if (!CheckIfReadyToSave())
            {
                ait.ControlClick(pos, "", POSNewBTN, "left", 2);
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
            if (Convert.ToDecimal(ait.ControlGetText(pos, "", invoiceprc)) != 0) { 
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
                if (Convert.ToDecimal(ait.ControlGetText(pos, "", invoiceprc)) != 0)
                {
                    ait.WinActivate(pos);
                    ait.ControlClick(pos, "", POSNewBTN, "left", 1);
                    
                    ait.Send("{ENTER}");
                    SaveManualToPOS();
                    return;

                }
                AddItemsToPOS(singleOrMultipleInvoice);
                ait.ControlClick(pos, "", SwitchBTN, "left");
                ait.Sleep(500);
                if (PartCash_.Text != "")
                {
                    ait.ControlSetText(pos, "", PartCash, PartCash_.Text);
                }
                else ait.ControlSetText(pos, "", PartCash, "0");
                if (Mada1_.Text != "")
                {
                    ait.ControlSetText(pos, "", Mada1, Mada1_.Text);
                }
                else ait.ControlSetText(pos, "", Mada1, "0");
                if (Mada2_.Text != "")
                {
                    ait.ControlSetText(pos, "", Mada2, Mada2_.Text);
                    ait.ControlClick(pos, "", Mada2CB, "Left");
                    ait.ControlSend(pos, "", Mada2CB, "{DOWN}{ENTER}", 0);
                }

                if (Mada3_.Text != "")
                {
                    ait.ControlSetText(pos, "", Mada3, Mada3_.Text);
                    ait.ControlClick(pos, "", Mada3CB, "Left");
                    ait.ControlSend(pos, "", Mada3CB, "{DOWN}{ENTER}", 0);

                }
                SaveInvoiceNumber(singleOrMultipleInvoice);
                //ait.ControlClick(pos, "", SaveBTN, "left", 1);
            }
            else if (!CheckIfReadyToSave())
            {
                ait.ControlClick(pos, "", POSNewBTN, "left", 2);
                SaveManualToPOS();
            }

        }



        /// <summary>
        /// Saving and Updating invoices for invoice number.
        /// </summary>
        private void SaveInvoiceNumber(bool single)
        {
            string invoiceNTB = ait.ControlGetText(pos, "", InvoiceNumberTB);
            if (!Properties.Settings.Default.TestingMode) ait.ControlClick(pos, "", SaveBTN, "left", 1);

            if (single)
            {
                DbInv.UpdateInvoice(this.invoice.ID, invoiceNTB);

            }
            else
            {
                if (MultipleInvoices.Count> 0)
                {

                foreach (Invoice inv in MultipleInvoices)
                {
                    DbInv.UpdateInvoice(inv.ID, invoiceNTB);

                }

                }
            }
            this.Close();
        }


        /// <summary>
        ///  AddItemsMethods 
        /// </summary>
        private void AddItemsToPOS(bool single)
        {
            if (textBox1.Text != null || textBox1.Text != "0" || textBox1.Text !="") { DoDiscount(); }
         
            if (single)
            {
                ait.ControlClick(pos, "", POSClearNumber, "left", 1);
                foreach (var item in invoice.InvoiceItems)
                {
                    ait.ControlClick(pos, "", barcodetb, "left", 1);
                    ait.ControlSend(pos, "", barcodetb, item.Barcode, 0);
                    ait.ControlSend(pos, "", barcodetb, "{ENTER}", 0);
                    int q = Convert.ToInt32(item.Quantity);
                    ait.ControlSetText(pos, "", amountlbl, q.ToString());
                    ait.ControlClick(pos, "", btnsubmit, "left", 1);
                }
                if (this.invoice.CustomerName != null)
                {
                    if (this.invoice.CustomerName.Replace(" ", "") != "")
                    {
                        ait.ControlSetText(pos, "", invoicenotes, "ورقة التحضير:" + " - " + this.invoice.ID.ToString() + " -" + this.invoice.CustomerName) ;

                    }
                    else ait.ControlSetText(pos, "", invoicenotes, "ورقة التحضير:" + " - " + this.invoice.ID.ToString() + " -");
                }
                else
                ait.ControlSetText(pos, "", invoicenotes, "ورقة التحضير:" + " - " + this.invoice.ID.ToString() + " -" );

            }
            else
            {
                var InvoiceItems = CreateNewListOfItems();
                ait.ControlClick(pos, "", POSClearNumber, "left", 1);
                foreach (var item in InvoiceItems)
                {
                    ait.ControlClick(pos, "", barcodetb, "left", 1);
                    ait.ControlSend(pos, "", barcodetb, item.Barcode, 0);
                    ait.ControlSend(pos, "", barcodetb, "{ENTER}", 0);
                    int q = Convert.ToInt32(item.Quantity);
                    ait.ControlSetText(pos, "", amountlbl, q.ToString());
                    ait.ControlClick(pos, "", btnsubmit, "left", 1);
                }
                List<string> invoiceIDS = new List<string>();
                MultipleInvoices.ForEach(x => invoiceIDS.Add(x.ID.ToString()));
                var joinedNames = invoiceIDS.Aggregate((a, b) => a + "-" + b);
                ait.ControlSetText(pos, "", invoicenotes, "أوراق تحضير:" + joinedNames);
            }
        }

        private void DoDiscount()
        {
            ait.ControlSetText(pos, "", "[NAME:TextBox2]", textBox1.Text);
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
            if (ait.ControlGetText(pos, "", InvoiceTime).Contains("PM") ||
                ait.ControlGetText(pos, "", InvoiceTime).Contains("AM"))
            {
                return true;
            }
            return false;
        }
        private bool OpenNewPosWindow()
        {
            ait.WinActivate(POSmainName);
            ait.WinSetState(POSmainName, "", ait.SW_MAXIMIZE);
            ait.WinSetOnTop(POSmainName, "", 1);
            ait.ControlClick(POSmainName, "", POSShortcut, "LEFT", 2, 58, 232);
            ait.ControlClick(POSmainName, "", POSWinShortcut, "LEFT", 1);
            ait.WinSetOnTop(POSmainName, "", 0);
            ait.WinSetState(POSmainName, "", ait.SW_MINIMIZE);
            ait.WinActivate(pos);
            if (ait.WinWaitActive(pos, "", 2000) == 1)
            {
                return true;
            }
            else return false;


        }
         int repeat = 0;
        private bool GetPOSWindow()
        {
            if (ait.WinExists(pos) == 1)
            {
                ait.WinSetState("WhatsApp", "", ait.SW_MINIMIZE);
                return true;
                // code for checking empty or not.

            }
            else if (ait.WinExists(POSmainName) == 1)
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
            d = Convert.ToDecimal(dueLBL.Text);
            if (PartCash_.Text != "" && PartCash_.Text != "-")
            {
                c = Convert.ToDecimal(PartCash_.Text);
            }
            if (Mada1_.Text != "")
            {
                m1 = Convert.ToDecimal(Mada1_.Text);
            }
            if (Mada2_.Text != "")
            {
                m2 = Convert.ToDecimal(Mada2_.Text);
            }
            if (Mada3_.Text != "")
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
            else LBLdue.ForeColor = Color.Red;
        }
        private void CalculateSingleMoney()
        {
            d = Convert.ToDecimal(dueLBL.Text);
            if (Cash.Text != "")
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
            else LBLdue.ForeColor = Color.Red;
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
            if (Cash.Text != "." || Cash.Text != "")
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
            CalculateMultiMoney();
            var se = (TextBox)sender;

            if (se.Text == "")
            {
                se.Text = "0";
                se.Focus();
                SendKeys.Send("{End}");
            }

        }
        private void CashTB_TextChanged(object sender, EventArgs e)
        {
            CalculateSingleMoney();
            var se = (TextBox)sender;

            if (se.Text == "")
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

        }
        string invoice_price;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (textBox1.Text == "") { textBox1.Text = "0"; dueLBL.Text = invoice_price; }
                        
            decimal discounted = Convert.ToDecimal(invoice_price) - Convert.ToDecimal(textBox1.Text);
            dueLBL.Text = discounted.ToString(); 
        }

        private void Btn50_Click(object sender, EventArgs e)
        {
            var s = (Button)sender;
            if (s != null)
            {
                Cash.Text = s.Text;
                Cash.Focus();
                SendKeys.Send("{End}");
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
