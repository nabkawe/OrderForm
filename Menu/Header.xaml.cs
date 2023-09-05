using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OrderForm
{
    /// <summary>
    /// Interaction logic for Header.xaml
    /// </summary>
    public partial class Header : UserControl
    {
        // create a static timer for this control.
        public static System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();

        public Header()
        {
            InitializeComponent();
            // Set the timer interval to 30000 second.
            timer.Interval = new TimeSpan(0, 0, 30);    
            // Set the timer event handler. 
            timer.Tick += new EventHandler(timer_Tick);
            // Start the timer.
            timer.Start();

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Storyboard sb = new Storyboard();
            DoubleAnimation da = new DoubleAnimation();
            da.From = this.Height;
            da.To = 0;
            da.Duration = new Duration(TimeSpan.FromSeconds(3));
            da.AutoReverse = true;
            da.RepeatBehavior = new RepeatBehavior(1);
            sb.Children.Add(da);
            Storyboard.SetTarget(da, this);
            Storyboard.SetTargetName(da, nameof(this.HeaderBack));
            Storyboard.SetTargetProperty(da, new PropertyPath("Height"));
            
            sb.Begin();

        }
    }
}
