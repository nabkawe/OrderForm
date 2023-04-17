using LiteDB;
using sharedCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
//using System.Windows.Forms;
namespace sharedCode
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
    
    public class Payment
    {
        public int ID;
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        
        public Payment()
        {
            Guid = Guid.NewGuid();
        }
        public Payment(string Name,decimal Amount)
        {
            Guid = Guid.NewGuid();
            Name = this.Name;
            Amount = this.Amount;
        }
        public static Payment NewPayment()
        {

            return new Payment();
        }

    }


    public class Invoice
    {

        // item related code
        public List<POSItems> InvoiceItems { get; set; }
        [Browsable(false)]
        public int RealQuantity
        {
            get
            {

                try
                {
                    if (this.InvoiceItems.Count > 0)
                    {
                        return this.InvoiceItems.Sum(x => x.RealQuantity);
                    }
                    else return 0;

                }
                catch (Exception)
                {

                    //MessageBox.Show("خطأ غير معروف ( يمكنكم تجاهله)");
                    //MessageBox.Show(ex.ToString());
                    return 0;
                }



            }

            //set { this.realquan = value; }
        }

        // invoice info related code
        [DisplayName("رقم الطلب")]
        [BsonId]
        public int ID { get; set; }


        [DisplayName("إسم العميل")]
        public string CustomerName { get; set; }
        [DisplayName("رقم العميل")]
        public string CustomerNumber { get; set; }
        [DisplayName("ملاحظات الطلب")]
        public string Comment { get; set; }
        [DisplayName("رقم التخزين في ليبرا")]
        public string POSInvoiceNumber { get; set; }
        [DisplayName("نوع الطلب")]
        public string OrderType { get; set; }
        [DisplayName("حالة الطلب")]
        public InvStat Status { get; set; }
        [DisplayName("وقت التخزين")]
        public DateTime TimeOfSaving { get; set; }


        [DisplayName("جاهز للتسليم")]

        [Browsable(false)]
        public bool InEditMode { get; set; }

        // Price related code
        [DisplayName("سعر الطلب")]

        public decimal InvoicePrice { get; set; }
        [Browsable(false)]
        public decimal Tax { get; set; }

        [Browsable(false)]
        public string IDstring
        {
            get
            {

                return this.ID.ToString();
            }
        }

        [Browsable(false)]
        public decimal PricewithoutTax
        {
            get
            {
                var tax = this.InvoicePrice / (1 + (Tax / 100));
                return Decimal.Round(tax, 2);
            }
        }

        //time related code

        [DisplayName("يوم الطلب")]
        public InvDay InvoiceDay { get ; set; }
        [DisplayName("وقت الطلب")]
        public string TimeinArabic { get; set; } // مكتوب بالعربي
        [Browsable(false)]
        public string TimeAMPM { get; set; } // مكتوب بالعربي المختصر
        [Browsable(false)]
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
                DayOfWeek dow = (DayOfWeek)(int)this.InvoiceDay;
                DateTime dt = Next(DateTime.Now, dow);
                return dt;
            }
            return DateTime.Now.AddMinutes(15);
        } // 
        public DateTime Next(DateTime from, DayOfWeek dayOfWeek)
        {
            //int start = (int)from.DayOfWeek;
            //int target = (int)dayOfWeek;
            //if (target <= start)
            //    target += 7;
            //return from.AddDays(target - start);
            int daysToAdd = ((int)dayOfWeek - (int)from.DayOfWeek + 7) % 7;
            return from.AddDays(daysToAdd);

        }
        public static string GetDayName(int dayInt)
        {

            var culture = new System.Globalization.CultureInfo("ar-SA");
            string[] days = culture.DateTimeFormat.DayNames;
            return days[dayInt];
        }

        [Browsable(true)]
        [DisplayName("وقت الطباعة")]
        public string TimeOfPrinting { get; set; }

        //logging related code
        [DisplayName("تاريخ الطلب")]
        public List<string> InvoiceTimeloglist { get; set; }
        public List<string> LogThis(string ActionMade)
        {
            string dt = DateTime.Now.ToString(" hh:mm:sstt dd-MM-yy ");
            string dtAction = dt + ActionMade;
            InvoiceTimeloglist.Add(dtAction);
            return InvoiceTimeloglist;
        }
        [Browsable(true)]
        public List<Payment> Payments { get; set; }
        [Browsable(true)]
        public string PaymentName
        {
            get
            {
                if (Payments.Count == 1) return Payments[0].Name;
                else if (Payments.Count == 0) return "غير_متوفر";
                else
                {
                    return "دفع متعدد";
                }

            }
        }
        [Browsable(true)]
        public bool PaymentStatus
        {
            get
            {
                if (Payments.Sum(x => x.Amount) == InvoicePrice)
                {
                    return true;
                }
                else return false;
            }
        }
        
        
        // Constructor defaults
        public Invoice()
        {
            //Status = InvStat.Draft;
            this.InvoiceItems = new List<POSItems>();
            this.Payments = new List<Payment>();
            this.InvoiceTimeloglist = new List<string>();
            this.Comment = "";
            this.CustomerName = "";
            this.CustomerNumber = "";
            this.CustomerNumber = "";
            this.TimeinArabic = "الآن";
            this.Tax = 15;
            this.TimeOfPrinting = "";

        }

        // Database related code for improved search
        [Browsable(false)]
        public string SearchResult
        {
            get { return $"{this.ID} : {this.CustomerName} : {this.CustomerNumber}"; }

        }
        public override string ToString()
        {
            return $"{ID}-{CustomerName}-{CustomerNumber}";
        }
        static bool t = true;
        public bool Equal(Invoice other)
        {
            if (other == null) return false;

            if (InvoiceItems.Count != other.InvoiceItems.Count) return false;
            if (InvoiceItems.Sum(x => x.RealQuantity) != other.InvoiceItems.Sum(x => x.RealQuantity)) return false;

            other.Comment = other.Comment ?? "";
            other.CustomerNumber = other.CustomerNumber ?? "";
            other.CustomerName = other.CustomerName ?? "";

            if (Comment != other.Comment || CustomerNumber != other.CustomerNumber ||
                ID != other.ID || TimeinArabic != other.TimeinArabic || CustomerName != other.CustomerName ||
                OrderType != other.OrderType || InvoiceDay != other.InvoiceDay) return false;

            foreach (var item in InvoiceItems)
            {
                if (!other.InvoiceItems.Any(x => x.Name == item.Name && x.Quantity == item.Quantity && x.Comment == item.Comment))
                    return false;
            }

            return true;
        }







    }


}

