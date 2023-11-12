using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sharedCode
{
    public class POSItems : INotifyPropertyChanged

    {

        [Browsable(true)]
        public int ID { get; set; }

        [DisplayName("اسم المادة")]
        public string Name { get; set; }

        private int quantity { get; set; }
        [DisplayName("العدد")]
        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (this.Barcode == "discount") { quantity = 1; } else { 
                    quantity = value; NotifyPropertyChanged("Quantity"); NotifyPropertyChanged("TotalPrice");
                }
            }

        }
        
        
        [DisplayName("السعر")]
        public decimal Price { get { return price; } set { price = value; NotifyPropertyChanged("Price"); NotifyPropertyChanged("TotalPrice"); } }  

        [DisplayName("الإجمالي")]
        
        public decimal TotalPrice
        {
            get { return Price * Quantity; }
        }

        [Browsable(true)]
        public string Parent { get; set; }


        [Browsable(true)]
        public decimal PricewithoutTax
        {
            get
            {
                Decimal P = Price / (1 + (Tax / 100));
                return Decimal.Round(P, 2);
            }
        }

        [DisplayName("الباركود")]
        [Browsable(true)]
        public string Barcode { get; set; }
        [DisplayName("ملاحظة المادة")]
        private string comment { get; set; }
        public string Comment
        {
            get { return comment; }
            set { comment = value; NotifyPropertyChanged("Comment"); }
        }
        [Browsable(true)]
        public int realquan { get; set; }
        [Browsable(true)]
        public decimal Tax { get; set; }
        [Browsable(true)]
        public string PicturePath { get; set; }
        [Browsable(true)]
        public List<string> printerlist = new List<string>();
        public event PropertyChangedEventHandler PropertyChanged;
        [Browsable(true)]
        public int RealQuantity
        {
            get { return realquan * Quantity; }
            set {; }
        }
        [Browsable(true)]
        public string PrinterName
        {
            get
            {
                printerlist = printerlist.Distinct().ToList();
                if (printerlist.Count > 1)
                {
                    return String.Join(",", printerlist.ToArray()).TrimEnd(',').Replace("Default,", "");
                }
                else if (printerlist.Count == 1) return printerlist[0];
                else return "Default";
            }
            set
            {
                string b = value.ToString();
                if (b.Length > 0)
                {
                    string[] a = value.Split(',');
                    foreach (string itm in a)
                    {
                        printerlist.Add(itm);
                    }
                }
                else printerlist.Clear();
            }
        }
        [Browsable(true)]
        public bool Available { get; set; }
        [Browsable(true)]
        public string SectionName { get; set; }
        [Browsable(true)]
        public string NameAndPrinter
        {
            get { return Name + " " + PrinterName; }
        }
        [Browsable(true)]
        public int order { get; set; }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private decimal price { get; set; }
        [Browsable(true)]
        public bool discount { get{ return this.Barcode == "discount"; }  }
        /// <summary>
        /// Pass 1 to increase quantity, Pass -1 to decrease quantity.
        /// </summary>
        /// <param name="Number"></param>
        public void ChangeQuantity(int Number)
        {
            if (this.Barcode != "discount")
            {
                if (Number == 1)
                {
                    this.Quantity++;
                }
                else { this.Quantity--; if (this.Quantity <= 0) this.Quantity = 1; }
            }
            else
            {
                //
            }
            

        }

        public POSItems(/*int id,string barcode, string nm, decimal prc,int realq,decimal t*/)
        {

        }

        public POSItems(POSItems items)
        {
            ID = items.ID; Barcode = items.Barcode; Available = true; Comment = ""; Name = items.Name; Price = items.Price; order = items.order; Parent = items.Parent; PrinterName = items.PrinterName; Quantity = items.Quantity; realquan = items.realquan; SectionName = items.SectionName; printerlist = items.printerlist; Tax = items.Tax;
        }
        public POSItems(int id, string barcode, string nm,
            decimal prc, int q, int realq, decimal tax, string
            path, string defaultP)
        {

            this.ID = id;
            this.Barcode = barcode;
            this.Name = nm;
            this.Price = prc;
            this.Quantity = q;
            this.realquan = realq;
            this.Tax = tax;
            this.PicturePath = path;
            this.PrinterName = defaultP;
            this.Comment = "";

        }
        public override string ToString()
        {
            string text = $"الإسم: {Name} -  السعر: {Price}";
            return text;
        }


    }
    public class POSsections
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string materialTable { get; set; }
        public string DefaultDepartment { get; set; }
        public List<string> NotesList { get; set; }
        public POSsections(int iD, string name)
        {
            ID = iD;
            Name = name;

        }

        public POSsections()
        {
            NotesList = new List<string>();
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class POSitemComparer : IEqualityComparer<POSItems>
    {
        public int GetHashCode(POSItems obj)
        {
            return obj.GetHashCode();
        }
        public bool Equals(POSItems x, POSItems y)
        {
            if (x.Name.ToLower() == y.Name.ToLower())
                return true;

            return false;
        }
    }
    public class POSSectComparer : IEqualityComparer<POSsections>
    {
        public int GetHashCode(POSsections obj)
        {
            return obj.GetHashCode();
        }
        public bool Equals(POSsections x, POSsections y)
        {
            if (x.Name == y.Name)
                return true;

            return false;
        }
    }

    public class WhatsAppShortCut
    {
        public Guid guid { get; set; }
        public string Shortcut { get; set; }
        public string Details { get; set; }
        public WhatsAppShortCut(int ID, string Shortcut, string Details)
        {
            guid = Guid.NewGuid();

            Shortcut = this.Shortcut;
            Details = this.Details;
        }
        public WhatsAppShortCut()
        {
            guid = Guid.NewGuid();
        }
    }
}
