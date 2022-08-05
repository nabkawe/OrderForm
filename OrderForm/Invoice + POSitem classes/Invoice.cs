using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using sharedCode;
namespace OrderForm
{
    public enum InvStat
    {
        Draft = 0,
        Printed = 1,
        Deleted = 2,
        SavedToPOS = 3
            
    }
    public enum InvDay
    {
        Sun = 0, Mon = 1, Tue = 2, Wed = 3, Thu = 4, Fri = 5, Sat = 6
    }


    public class Invoice
    {

        // item related code
        public List<POSItems> InvoiceItems { get; set; }
        public int RealQuantity
        {
            get
            {

                try
                {
                    if (this.InvoiceItems.Count > 0)
                    {
                        int RQ = this.InvoiceItems.Sum(x => x.RealQuantity);
                        return RQ;
                    }
                    else return 0;

                }
                catch (Exception ex)
                {

                    MessageBox.Show("خطأ غير معروف ( يمكنكم تجاهله)");
                    MessageBox.Show(ex.ToString());
                    return 0;
                }



            }

            //set { this.realquan = value; }
        }

        // invoice info related code
        public int ID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerNumber { get; set; }
        public string Comment { get; set; }
        public string POSInvoiceNumber { get; set; }
        public string OrderType { get; set; }
        public InvStat Status { get; set; }


        /// <summary>
        /// sharing related code
        /// </summary>
        public bool InEditMode { get; set; }


        // Price related code
        public decimal InvoicePrice { get; set; }
        public decimal Tax { get; set; }
        public string IDstring
        {
            get
            {
                
                return this.ID.ToString();
            }
        }

        public decimal PricewithoutTax
        {
            get
            {
                var tax = this.InvoicePrice / (1 + (Tax / 100));
                return Decimal.Round(tax,2);
            }
        }

        //time related code
        public InvDay InvoiceDay { get; set; }
        public string TimeinArabic { get; set; } // مكتوب بالعربي
        public string TimeAMPM { get; set; } // مكتوب بالعربي المختصر
        public DateTime TimeOfInv
        {
            get { return GetDateTime(TimeinArabic); }
        } // الوقت النظامي
        public DateTime GetDateTime(string TimeInArabic)
        {
            if ((int)this.InvoiceDay == (int)DateTime.Now.DayOfWeek)
            {
                DateTime dt = TimeParse.TT(TimeInArabic);
                return dt;
            }
            else if ((int)this.InvoiceDay != (int)DateTime.Now.DayOfWeek)
            {
                DayOfWeek dow = (DayOfWeek)(int)this.InvoiceDay;// = (int)this.InvoiceDay;
                DateTime dt = Next(DateTime.Now, dow);
                return dt;
            }
            return DateTime.Now.AddMinutes(15);
        } // 
        public DateTime Next(DateTime from, DayOfWeek dayOfWeek)
        {
            int start = (int)from.DayOfWeek;
            int target = (int)dayOfWeek;
            if (target <= start)
                target += 7;
            return from.AddDays(target - start);
        }
        public string TimeOfPrinting { get; set; }

        //logging related code
        public List<string> InvoiceTimeloglist { get; set; }
        public List<string> LogThis(string ActionMade)
        {
            string dt = DateTime.Now.ToString(" hh:mm:sstt dd-MM-yy ");
            string dtAction = dt + ActionMade;
            InvoiceTimeloglist.Add(dtAction);
            return InvoiceTimeloglist;
        }


        // Constructor defaults
        public Invoice()
        {
            //Status = InvStat.Draft;
            InvoiceItems = new List<POSItems>();
            InvoiceTimeloglist = new List<string>();
            Comment = "";
            CustomerName = "";
            CustomerNumber = "";
            CustomerNumber = "";
            TimeinArabic = "الآن";
            Tax = Properties.Settings.Default.CurrentTax;
        }

        // Database related code for improved search
        public string SearchResult
        {
            get { return $"{this.ID}-{this.CustomerName}-{this.CustomerNumber}"; }

        }
        public override string ToString()
        {
            return $"{ID}-{CustomerName}-{CustomerNumber}";
        }
        static bool t = true;
        public bool Equal(Invoice New)
        {
        if(New == null) return false;
            if (New.Comment == null) New.Comment = "";
            if (New.CustomerNumber == null) New.CustomerNumber = "";
            if (New.CustomerName == null) New.CustomerName = "";
            t = true;
            if (this.Comment == New.Comment && this.CustomerNumber == New.CustomerNumber &&
                this.ID == New.ID /*&& this.InvoicePrice == New.InvoicePrice*/ &&
                this.TimeinArabic == New.TimeinArabic && this.CustomerName == New.CustomerName &&
                this.OrderType == New.OrderType) { t = true; /*MessageBox.Show("All Good at Text level");*/ }
            else { t = false;/* MessageBox.Show("Not Equal at text level?");*/ }

            foreach (var item in this.InvoiceItems)
            {
                var a = New.InvoiceItems.Any(x => x.Name == item.Name && x.Quantity == item.Quantity && x.Comment == item.Comment);
                if (!a)
                {
                    t = false;
                }

            }
            return t;
        }








    }


}

