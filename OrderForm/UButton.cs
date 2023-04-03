using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace OrderForm
{

    public partial class UButton : Button
    {
        public UButton()
        {
            InitializeComponent();
            SetStyle(ControlStyles.Selectable, false);
            this.DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {

            base.OnPaint(pe);

        }
    }
}
