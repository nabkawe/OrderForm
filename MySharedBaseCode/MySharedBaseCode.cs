using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sharedCode
{
    public class POSItems : INotifyPropertyChanged

    {

        [Browsable(false)]
        public int ID { get; set; }

        [DisplayName("اسم المادة")]
        public string Name { get; set; }

        private int quantity { get; set; }
        [DisplayName("العدد")]
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; NotifyPropertyChanged("Quantity"); NotifyPropertyChanged("TotalPrice"); }

        }
        [DisplayName("السعر")]
        public decimal Price { get; set; }
        [DisplayName("الإجمالي")]
        public decimal TotalPrice
        {
            get { return Price * Quantity; }
        }

        [Browsable(false)]
        public string Parent { get; set; }


        [Browsable(false)]
        public decimal PricewithoutTax
        {
            get
            {
                Decimal P = Price / (1 + (Tax / 100));
                return Decimal.Round(P, 2);
            }
        }

        [Browsable(false)]
        public string Barcode { get; set; }
        [DisplayName("ملاحظة المادة")]
        private string comment { get; set; }
        public string Comment
        {
            get { return comment; }
            set { comment = value; NotifyPropertyChanged("Comment"); }
        }
        [Browsable(false)]
        public int realquan { get; set; }
        [Browsable(false)]
        public decimal Tax { get; set; }
        [Browsable(false)]
        public string PicturePath { get; set; }
        [Browsable(false)]
        public List<string> printerlist = new List<string>();
        public event PropertyChangedEventHandler PropertyChanged;
        [Browsable(false)]
        public int RealQuantity
        {
            get { return realquan * Quantity; }
            set {; }
        }
        [Browsable(false)]
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
        [Browsable(false)]
        public bool Available { get; set; }
        [Browsable(false)]
        public string SectionName { get; set; }
        [Browsable(false)]
        public string NameAndPrinter
        {
            get { return Name + " " + PrinterName; }
        }
        [Browsable(false)]
        public int order { get; set; }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public POSItems(/*int id,string barcode, string nm, decimal prc,int realq,decimal t*/)
        {

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
