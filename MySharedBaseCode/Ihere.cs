using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharedCode
{
    public interface IAllMenuItems
    {
        void PickedYou(); // interface method (does not have a body)
        
    }
    public class AppMaterial
    {
        [Browsable(false)]
        public int id { get; set; }
        [Browsable(true)]

        public string Name { get; set; }

        [Browsable(true)]

        public string Barcode { get; set; }
    }
    public class AppSets
    {
        public int id { get; set; }
        public string Name { get; set; }
        public List<AppMaterial> list { get; set; }
        public override string ToString()
        {
            return Name.ToString();
        }

    }

}
