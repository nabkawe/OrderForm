using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Converters;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml;
using sharedCode;
using WpfScreenHelper;

namespace OrderForm
{

    /// <summary>
    /// Interaction logic for NewFood.xaml
    /// </summary>
    public partial class NewFood : UserControl, IAllMenuItems
    {
        public System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        public bool Single;
        public NewFood()
        {

        }
        public List<MenuItemsX> posLoop = new List<MenuItemsX>();

        private  MenuItemsX MenuX;
        public NewFood(MenuItemZ pos)
        {
            this.InitializeComponent();
            this.RegisterName("BackGroundGrid", scopedElement: this.BackGroundGrid);
            this.Name = "Foodi";
            

            if (pos.SingleX)
            {
                Single = true;
                //Task.Run(() =>
                //{
                //    this.Dispatcher.Invoke(() =>
                //    {
                //        this.DataContext = MenuItemsXViewModel.me(pos.items[0]);
                //    });
                //});
                this.DataContext = MenuItemsXViewModel.me(pos.items[0]);
                this.Tag = pos.items[0].Barcode;
            }
            else
            {
                DataContext = MenuItemsXViewModel.me(pos.items[1]);
                var result = new StringBuilder();
                pos.items.ForEach(x => result.Append(x.Barcode + "-"));
                this.Tag = result.Length--; // remove last '-'

                pos.items.ForEach(x => posLoop.Add(x));

                var timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(6);
                timer.Tick += (sender, args) =>
                {
                    if (posLoop.Count > 0)
                    {
                        // Get the first item
                         MenuX = posLoop[0];

                        // Remove it from the list
                        posLoop.RemoveAt(0);

                        // Add it to the end of the list
                        posLoop.Add(MenuX);


                        // Update your UI with the new item using DataContext

                        // Animate your UI element

                        var opacityAnimation = new DoubleAnimation(1.0, 0.0, TimeSpan.FromMilliseconds(1000));
                        opacityAnimation.Completed += ScaleAnimation_Completed;

                        BackGroundGrid.BeginAnimation(Grid.OpacityProperty, opacityAnimation);
                    }
                };
                timer.Start();
            }
        
        }

        private  void ScaleAnimation_Completed(object sender, EventArgs e)
        {
            changeDC();
            


            var opacityAnimation = new DoubleAnimation(0.0, 1.0, TimeSpan.FromMilliseconds(1000));

            BackGroundGrid.BeginAnimation(OpacityProperty, opacityAnimation);

        }

        private  void changeDC()
        {
            Task.Run(() =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    this.DataContext = MenuItemsXViewModel.me(MenuX); ;
                });
            });

        }

        public void Fadein()
        {
            this.RegisterName("foodi", this.FI);
            Storyboard storyboard = new Storyboard();
            TimeSpan duration = TimeSpan.FromMilliseconds(1500); //
            DoubleAnimation scaleAnimation = new DoubleAnimation()
            { From = 0.0, To = 1.0, Duration = new Duration(duration) };
            Storyboard.SetTargetName(scaleAnimation, "BackGroundGrid");
            storyboard.Children.Add(scaleAnimation);
            storyboard.Begin(this);
        }


   
        public void PickedYou()
        {
          //  Window1 window = new Window1();
          //  Type type = this.GetType();
          //  string xaml = XamlWriter.Save(this);
          //  StringReader stringReader = new StringReader(xaml);
          //  XmlReader xmlReader = XmlReader.Create(stringReader);
          //  NewFood newFood = (NewFood)XamlReader.Load(xmlReader);
          //  newFood.Name = "foodi";
          //  newFood.Height = window.Height;
          //  newFood.Width = window.Width;   
          //window.Grid.Children.Add(newFood);
            


          //  //window.Content = XamlReader.Parse(XamlWriter.Save(this));
          //  Window parentWindow = Window.GetWindow(this);
          //  window.Owner = parentWindow;
          //  Point rl = this.TranslatePoint(new Point(0, 0), parentWindow) ;
          //  //Screen screen = Screen.FromPoint(rl) ;
          //  window.Topmost = true;
          //  window.Left = this.PointToScreen(new Point(MainWindow.Currentsize.Width * 1.5 / this.Width ,0)).X;
          //  window.Top = this.PointToScreen(new Point(0, 0)).Y;

          //  window.Show();

            this.dispatcherTimer.Stop();
            this.RegisterName("BlurEffect", dropEffect);
            dropEffect.Color = Color.FromRgb(0, 255, 00);
            MyBorder.BorderBrush = Brushes.LightGreen;

            Storyboard s = new Storyboard();
            TimeSpan duration = TimeSpan.FromMilliseconds(500); //
            DoubleAnimation fadeInAnimation = new DoubleAnimation()
            { From = 0, To = 100, AccelerationRatio = 0.3, RepeatBehavior = new RepeatBehavior(2), AutoReverse = true, Duration = new Duration(duration) };
            Storyboard.SetTargetName(fadeInAnimation, "BlurEffect");
            Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath("BlurRadius", 15));


            duration = TimeSpan.FromMilliseconds(100);
            ColorAnimation fadeInAnimation3 = new ColorAnimation()
            { From = Color.FromRgb(169, 107, 40), To = Color.FromRgb(0, 255, 0), SpeedRatio =0.5, RepeatBehavior = new RepeatBehavior(2), AutoReverse=true, Duration = new Duration(duration)};
            Storyboard.SetTargetName(fadeInAnimation3, "BlurEffect");
            Storyboard.SetTargetProperty(fadeInAnimation3, new PropertyPath("Color", 1));
            ThicknessAnimation thick = new ThicknessAnimation() { From = new Thickness(1, 1,1,1), To = new Thickness(1, 100, 1, 100), AutoReverse = true,Duration = new Duration(duration) };
            Storyboard.SetTargetName(thick, nameof(this.MyBorder));
            Storyboard.SetTargetProperty(thick, new PropertyPath("BorderThickness",1));


            s.Completed += Story_Completed;
            s.Children.Add(fadeInAnimation3);
            s.Children.Add(fadeInAnimation);
            s.Children.Add(thick);
            s.Begin(this);
        }
        private void Story_Completed(object sender, EventArgs e)
        {
            var brush = new SolidColorBrush(Color.FromRgb(169, 107, 40));
            MyBorder.BorderBrush = brush;
            this.dispatcherTimer.Start();
        }

        private ContentControl Reg(string r)
        {
            var contentControl = (ContentControl)this.FindResource(r);
            return contentControl;
        }

    }
}
