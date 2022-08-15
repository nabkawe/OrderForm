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
