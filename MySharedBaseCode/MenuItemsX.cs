using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace sharedCode
{
    public class MenuItemsX
    {
        public int ID { get; set; }
        public string Barcode { get; set; }
        public int order { get; set; }

        public string Name { get; set; }
        public string Details { get; set; }

        public string Cal { get; set; }


        public string Price { get; set; }

        public string ImagePath { get; set; }

        public bool Available { get; set; }
    

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
    public List<object> list { get; set; }
    public override string ToString()
    {
        return Name;
    }
    public MenuSection()
    {
        list = new List<object>();
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
}
