using sharedCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Menu
{
    /// <summary>
    /// Interaction logic for InformationPanel.xaml
    /// </summary>
    public partial class InformationPanel : UserControl
    {

        public InformationPanel()
        {
            InitializeComponent();
            infoObject a = MenuDB.LoadInfo();
            if (a != null) { a.list.ForEach(x => posLoop.Add(x)); }
            StartTimer();


        }
        int Count = 0;
        private List<string> posLoop = new List<string>();
        string globalInfo;
        private void StartTimer()
        {
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0,5);
            dispatcherTimer.Start();

        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            try
            {

                if (Count < posLoop.Count)
                {
                    Count += 1;
                    globalInfo = posLoop[Count];
                    StartAnimation(posLoop[Count]);
                }
                else if (Count == posLoop.Count)
                {
                    Count = -1;
                }
            }
            catch (Exception)
            {

                Count = -1;
            }
        }

        private void StartAnimation(string info)
        {

            RegisterName("InfoBorder", FindName("InfoBorder"));
            RegisterName("Info2", FindName("InfoContent"));
            Border b = (Border)FindName("InfoBorder");
            TextBlock aaa = (TextBlock)this.FindName("InfoContent");

            Storyboard storyboard = new Storyboard();
            TimeSpan duration = TimeSpan.FromMilliseconds(999); //

            DoubleAnimation fadeInAnimation = new DoubleAnimation()
            { From = 95, To = 00, AutoReverse = true, Duration = new Duration(duration) };
            DoubleAnimation fadeInAnimation2 = new DoubleAnimation()
            { From = 95, To = 00, AutoReverse = true, Duration = new Duration(duration) };
            Storyboard.SetTargetName(fadeInAnimation, b.Name);
            Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath("Height", 1));
            storyboard.Children.Add(fadeInAnimation);
            Storyboard.SetTargetName(fadeInAnimation2, "Info2");
            Storyboard.SetTargetProperty(fadeInAnimation2, new PropertyPath("Height", 1));
            storyboard.Children.Add(fadeInAnimation2);
            storyboard.Completed += Storyboard_Completed;
            var a = (TextBlock)this.FindName("InfoContent");
            a.Text = globalInfo;
            storyboard.Begin(this);

        }

        private void Storyboard_Completed(object sender, EventArgs e)
        {
           
        }
    }
}
