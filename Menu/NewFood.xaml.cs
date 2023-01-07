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
using System.Windows.Media.Converters;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using sharedCode;
namespace OrderForm
{

    /// <summary>
    /// Interaction logic for NewFood.xaml
    /// </summary>
    public partial class NewFood : UserControl, IAllMenuItems
    {
        public System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        public bool Single { get; set; }

        
        int totalcount = 0;
        public NewFood(MenuItemZ pos)
        {
            this.InitializeComponent();
            this.RegisterName("BackGroundGrid", scopedElement: this.BackGroundGrid);

            if (pos.SingleX)
            {
                this.FillInfo(pos.items.Last());
                this.Fadein();
                Single= true;   
            }
            else
            {
                pos.items.ForEach(x => posLoop.Add(x));
                this.FillInfo(pos.items.Last());
                totalcount = pos.items.Count();
                this.StartTimer();
                this.Fadein();
                Single = false;
            }
            
        }
        public List<MenuItemsX> posLoop = new List<MenuItemsX>();


        public void FillInfo(MenuItemsX poss)
        {

            if (poss.Available)
            {
                this.AvailableLabel.Visibility = Visibility.Hidden;
            }

            var Name = this.Reg("kName");
            Name.Content = poss.Name;
            var Details = this.Reg("kDetails");
            Details.Content = poss.Details;
            var PictureName = this.Reg("kPicture");
            PictureName.Content = poss.ImagePath;
            var Cal = this.Reg("kCalories");
            Cal.Content = poss.Cal;
            var bar = this.Reg("kBarCode");
            bar.Content = poss.Barcode;
            this.Tag = poss.Barcode;


            if (poss.Price != null)
            {
                var Price = this.Reg("kPrice");
                Price.Content = poss.Price.ToString();
            }else if (poss.Price == null){ this.KCur.Text = " "; PricePlate.Text = " "; }






        }
        int Count = 0;
        private void Storyboard_Completed(object sender, EventArgs e)
        {
            FillInfo(posLoop[Count]);
            this.Count += 1;
            Fadein();
        }

        private void StartTimer()
        {
            this.dispatcherTimer.Tick += DispatcherTimer_Tick;
            this.dispatcherTimer.Interval = new TimeSpan(0, 0, 18);
            this.dispatcherTimer.Start();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (Count > totalcount || Count == totalcount)
            {
                Count = 0;
            }
            else if (Count < totalcount)
            {

                Storyboard storyboard = new Storyboard();
                TimeSpan duration = TimeSpan.FromMilliseconds(1500); //
                DoubleAnimation fadeInAnimation = new DoubleAnimation()
                { From = 1, To = 0, AutoReverse = false, Duration = new Duration(duration) };
                Storyboard.SetTargetName(fadeInAnimation, "BackGroundGrid");
                Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath("Opacity", 1));
                storyboard.Children.Add(fadeInAnimation);
                storyboard.Completed += Storyboard_Completed;
                storyboard.Begin(this);


            }


        }




        public void Fadein()
        {
            this.RegisterName("foodi", this.FI);
            Storyboard storyboard = new Storyboard();
            TimeSpan duration = TimeSpan.FromMilliseconds(1500); //
            DoubleAnimation fadeInAnimation = new DoubleAnimation()
            { From = 0.0, To = 1.0, Duration = new Duration(duration) };
            Storyboard.SetTargetName(fadeInAnimation, "BackGroundGrid");
            Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath("Opacity", 1));
            storyboard.Children.Add(fadeInAnimation);
            storyboard.Begin(this);
        }

        private void Story_Completed(object sender, EventArgs e)
        {
            var brush = new SolidColorBrush(Color.FromRgb(169, 107, 40));
            MyBorder.BorderBrush = brush; 
            this.dispatcherTimer.Start();
        }

        public void PickedYou()
        {
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

        private ContentControl Reg(string r)
        {
            var contentControl = (ContentControl)this.FindResource(r);
            return contentControl;
        }
        //Color.FromRgb(169, 107, 40)
        //duration = TimeSpan.FromMilliseconds(1000);
        //DoubleAnimation fadeInAnimation2 = new DoubleAnimation()
        //{  By = 360, RepeatBehavior = new RepeatBehavior(2), AutoReverse = true, Duration = new Duration(duration) };
        //Storyboard.SetTargetName(fadeInAnimation2, "BlurEffect");
        //Storyboard.SetTargetProperty(fadeInAnimation2, new PropertyPath("Direction", 5));
        //s.Children.Add(fadeInAnimation2);


    }
}
