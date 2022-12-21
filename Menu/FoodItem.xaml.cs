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
using sharedCode;
namespace Menu
{

    /// <summary>
    /// Interaction logic for FoodItem.xaml
    /// </summary>
    public partial class FoodItem : UserControl, IAllMenuItems
    {
        public bool IsMulti { get; set; }
        public System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();

        public FoodItem(MenuItemsX pos)
        {
            this.InitializeComponent();
            this.FillInfo(pos);
            this.IsMulti = false;
            this.Fadein();
            this.RegisterName("BackGroundGrid", scopedElement: this.BackGroundGrid);
        }
        int totalcount = 0;
        public FoodItem(IEnumerable<MenuItemsX> pos)
        {
            this.InitializeComponent();
            IsMulti = true;
            pos.ToList().ForEach(x => posLoop.Add(x));
            this.FillInfo(pos.Last());
            //this.pos = pos.Last();
            totalcount = pos.Count();
            this.StartTimer();
            this.Fadein();
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
            //else if (poss.Price == "")
            //{
            //    //var Price = this.Reg("kPrice");
            //    //this.PricePlate.Text = string.Empty;
            //    //Price.Content = string.Empty;
            //    //this.KCur.Text = "-";
            //    MessageBox.Show("");
            //}
            //else if (poss.Price.ToString() != "")
            //{
            //   // var Price = this.Reg("kPrice");
            //   // Price.Content = poss.Price.ToString();
            //}






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
            this.dispatcherTimer.Start();
            this.dropEffect.Color = Color.FromRgb(169, 107, 40);
        }

        public void PickedYou()
        {
            this.dispatcherTimer.Stop();


            this.RegisterName("BlurEffect", this.dropEffect);
            Storyboard s = new Storyboard();
            TimeSpan duration = TimeSpan.FromMilliseconds(500); //
            DoubleAnimation fadeInAnimation = new DoubleAnimation()
            { From = 0, To = 100, AccelerationRatio = 0.3, RepeatBehavior = new RepeatBehavior(2), AutoReverse = true, Duration = new Duration(duration) };
            Storyboard.SetTargetName(fadeInAnimation, "BlurEffect");
            Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath("BlurRadius", 50));
            s.Completed += Story_Completed;

            duration = TimeSpan.FromMilliseconds(1000);
            DoubleAnimation fadeInAnimation2 = new DoubleAnimation()
            {  By = 360, RepeatBehavior = new RepeatBehavior(2), AutoReverse = true, Duration = new Duration(duration) };
            Storyboard.SetTargetName(fadeInAnimation2, "BlurEffect");
            Storyboard.SetTargetProperty(fadeInAnimation2, new PropertyPath("Direction", 5));

            duration = TimeSpan.FromMilliseconds(1000);
            ColorAnimation fadeInAnimation3 = new ColorAnimation()
            { From = Color.FromRgb(0, 255, 0), To = Color.FromRgb(169, 107, 40), SpeedRatio = 0.2, AccelerationRatio = 1, Duration = new Duration(duration) };
            Storyboard.SetTargetName(fadeInAnimation3, "BlurEffect");
            Storyboard.SetTargetProperty(fadeInAnimation3, new PropertyPath("Color", 5));


            s.Children.Add(fadeInAnimation3);
            s.Children.Add(fadeInAnimation2);
            s.Children.Add(fadeInAnimation);
            s.Begin(this);
        }

        private ContentControl Reg(string r)
        {
            var contentControl = (ContentControl)this.FindResource(r);
            return contentControl;
        }


    }
}
