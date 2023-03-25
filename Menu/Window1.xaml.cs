using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
using System.Windows.Shapes;

namespace OrderForm
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            if (MainWindow.Currentsize.Width > 0)
            {
                this.Width = MainWindow.Currentsize.Width*1.5;
                this.Height = MainWindow.Currentsize.Height*1.5;
            }
            this.Topmost = true;
            AnimateWindow();
        }
        private void AnimateWindow()
        {
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 0;
            animation.To = 1;
            animation.Duration = new Duration(TimeSpan.FromSeconds(2));
            animation.AutoReverse = true;
            animation.Completed += Animation_Completed1;
            this.BeginAnimation(Window.OpacityProperty, animation);

        }

        private void Animation_Completed1(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void TallenObject(int newHeight, TimeSpan duration)
        {
            DoubleAnimation animation = new DoubleAnimation(newHeight, duration);
            this.BeginAnimation(Rectangle.HeightProperty, animation);
        }


        public void resizeme()
        {
            var newFood = (NewFood)Grid.FindName("foodi");
            newFood.Width = Grid.Width;
            newFood.Height = Grid.Height;
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject obj) where T : DependencyObject
        {
            if (obj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
        int count = 0;
        private void Grid_LayoutUpdated(object sender, EventArgs e)
        {



            count++;

        }
    }
}
