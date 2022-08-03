using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderForm
{
    
    public partial class UnfocusableButton : Button
    {
        public UnfocusableButton()
        {
            InitializeComponent();
            SetStyle(ControlStyles.Selectable, false);

        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
