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
    public class MenuItemZ
    {

        public List<MenuItemsX> items { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public int ItemCount { get { return this.items.Count; } }
        public bool SingleX
        {
            get { if (ItemCount > 1) return false; else return true; }
        }
        public MenuItemZ() { items = new List<MenuItemsX>(); }

        string TotalNames;
        public string NameToShow { get { if (SingleX) return this.items[0].Name + "-" + this.items[0].Price; else { TotalNames = ""; this.items.ForEach(x => TotalNames += x.Name + "," + x.Price + " "); return "مجموعة" + ":" + TotalNames; } } }
        public MenuItemsX FindBarcode(string barcode)
        {
            if (SingleX)
            {
                if (this.items[0].Barcode.Contains(barcode))
                {
                    return this.items[0];
                }
                else return null;
            }
            else
            {
                if (this.items.Find(x => x.Barcode.Contains(barcode)) != null)
                {
                    return this.items.Find(x => x.Barcode.Contains(barcode));
                }
                else return null;
            }
        }
    }

    public class MenuItemsX : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public string Barcode { get; set; }
        public int order { get; set; }

        public string Name { get { return name; } set { name = value; NotifyPropertyChanged(name); } }
        private string name;
        public string Details { get; set; }

        public string EnName { get; set; }
        public string EnDetails { get; set; }

        public string Cal { get; set; }


        public string Price { get; set; }

        public string ImagePath { get; set; }

        public bool Available { get; set; }

        [Browsable(false)]
        public bool Lang { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public override string ToString()
        {
            return Name + " " + Price;
        }
    }
    public class MenuSection
    {
        public int ID { get; set; }
        public int order { get; set; }
        public string Name { get; set; }
        public List<MenuItemZ> list { get; set; }

        // make a list of headerObject  

        public List<headerObject> headerList { get; set; }  


        public override string ToString()
        {
            return Name;
        }
        public MenuSection()
        {
            list = new List<MenuItemZ>();



        }
    }
    public class infoObject
    {
        public int ID { get; set; }
        public List<string> list { get; set; }
        public infoObject()
        {
            list = new List<string>();

        }
    }
    public class headerObject
    {

        public int ID { get; set; }

        public string HeaderName { get; set; }
        public string BackgroundColor { get; set; }
        public string ForegroundColor { get; set; }
        public int FontSize { get; set; }
        public string FontFamily { get; set; }
        public int initialHeight { get; set; }  
        public int height { get; set; }

        override public string ToString()
        {
            return HeaderName;
        }

    }
}
