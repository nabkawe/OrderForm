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

namespace OrderForm
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
            globalInfo = posLoop[0];
            StartAnimation(posLoop[0]);

            StartTimer();


        }
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
                if (posLoop.Count > 0)
                {
                    globalInfo = posLoop[0];
                    // Get the first item
                    StartAnimation(posLoop[0]);

                    // Remove it from the list
                    posLoop.RemoveAt(0);

                    // Add it to the end of the list
                    posLoop.Add(posLoop[0]);

                }
            }
            catch (Exception)
            {

            }
        }

        private void StartAnimation(string info)
        {

            var a = (TextBlock)this.FindName("InfoContent");
            a.Text = globalInfo;

        }

        private void Storyboard_Completed(object sender, EventArgs e)
        {
           
        }
    }
}
