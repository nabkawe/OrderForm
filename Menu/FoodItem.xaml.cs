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
    public partial class FoodItem : UserControl , IAllMenuItems
    {
        public bool IsMulti {get;set;}
        public System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        
        public FoodItem(MenuItemsX pos)
        {
            this.InitializeComponent();
            this.FillInfo(pos);
            this.IsMulti = false;
            this.Fadein();
            this.RegisterName("BackGroundGrid", scopedElement: this.BackGroundGrid);

        }
        int Count = 0;
        public FoodItem(IEnumerable<MenuItemsX> pos)
        {
            this.InitializeComponent();
            pos.ToList().ForEach(x => posLoop.Add(x));
            this.StartTimer();
            this.FillInfo(pos.Last());
            IsMulti = true;
            this.Fadein();

        }
        public List<MenuItemsX> posLoop = new List<MenuItemsX>();

       
        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            try
            {
               
                if (this.Count < this.posLoop.Count)
                {
                    //this.FadeOut();

                    this.Count += 1;
                    this.FillInfo(this.posLoop[Count]);
                    this.BackGroundGrid.Opacity = 0;
                }
                else if (this.Count == this.posLoop.Count)
                {
                    this.Count = -1;
                }
            }
            catch (Exception)
            {
                this.Count = -1;
                this.Count += 1;
                this.FillInfo(this.posLoop[Count]);
                SwitchMe();


            }



        }

        //private void FadeOut()
        //{
        //    this.RegisterName("foodi", this.FI);

        //    Storyboard storyboard = new Storyboard();
            
        //    TimeSpan duration = TimeSpan.FromMilliseconds(1000); //

        //    DoubleAnimation fadeInAnimation = new DoubleAnimation()
        //    { From = 1, To = 0, Duration = new Duration(duration) };

        //    Storyboard.SetTargetName(fadeInAnimation, "foodi");
        //    Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath("Opacity", 1));
        //    storyboard.Children.Add(fadeInAnimation);
        //    storyboard.Begin(this);
        //}

        private void StartTimer()
        {
            this.dispatcherTimer.Tick += DispatcherTimer_Tick;
            this.dispatcherTimer.Interval = new TimeSpan(0, 0, 8);
            this.dispatcherTimer.Start();

        }

        private ContentControl Reg(string r)
        {
            var contentControl = (ContentControl)this.FindResource(r);
            return contentControl;
        }
        public void FillInfo(MenuItemsX pos)
        {
            SwitchMe();
            if (pos.Available)
            {
                this.AvailableLabel.Visibility = Visibility.Hidden;
            }
            var Name = this.Reg("kName");
            Name.Content = pos.Name;

            var Details = this.Reg("kDetails");
           Details.Content = pos.Details;
            var PictureName = this.Reg("kPicture");
            PictureName.Content = pos.ImagePath;


            var Price = this.Reg("kPrice");
            Price.Content = pos.Price.ToString();

            var Cal = this.Reg("kCalories");
            Cal.Content = pos.Cal;
            var bar = this.Reg("kBarCode");
            bar.Content = pos.Barcode;
            this.Tag = pos.Barcode;
        }

        public void Fadein()
        {
            this.RegisterName("foodi", this.FI);

            Storyboard storyboard = new Storyboard();
            TimeSpan duration = TimeSpan.FromMilliseconds(200); //

            DoubleAnimation fadeInAnimation = new DoubleAnimation()
            { From = 0.0, To = 1.0, Duration = new Duration(duration) };

            Storyboard.SetTargetName(fadeInAnimation, "BackGroundGrid");
            Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath("Opacity", 1));
          storyboard.Children.Add(fadeInAnimation);
          storyboard.Begin(this);
        }

          public void SwitchMe()
        {

            Storyboard storyboard = new Storyboard();
            TimeSpan duration = TimeSpan.FromMilliseconds(400); //

            DoubleAnimation fadeInAnimation = new DoubleAnimation()
            { From = 0, To = 1, Duration = new Duration(duration) };
            Storyboard.SetTargetName(fadeInAnimation, "BackGroundGrid");
            Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath("Opacity", 1));
          storyboard.Children.Add(fadeInAnimation);
            storyboard.Completed += Storyboard_Completed;
          storyboard.Begin(this);
        }

        private void Storyboard_Completed(object sender, EventArgs e)
        {
            //this.BackGroundGrid.Opacity = 0;
            //Storyboard storyboard = new Storyboard();
            //TimeSpan duration = TimeSpan.FromMilliseconds(500); //
            //DoubleAnimation fadeInAnimation = new DoubleAnimation()
            //{ From = 1, To = 0, AutoReverse = true, Duration = new Duration(duration) };
            //Storyboard.SetTargetName(fadeInAnimation, "BackGroundGrid");
            //Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath("Opacity", 1));
            //storyboard.Children.Add(fadeInAnimation);
            //storyboard.Begin(this);

        }

        public void PickedYou()
        {
            this.dispatcherTimer.Stop();


            this.RegisterName("BlurEffect", this.dropEffect);
            Storyboard s = new Storyboard();
            TimeSpan duration = TimeSpan.FromMilliseconds(200); //
            DoubleAnimation fadeInAnimation = new DoubleAnimation()
            { From = 1, To = 5, AccelerationRatio=1, RepeatBehavior = new RepeatBehavior(3), AutoReverse = true, Duration = new Duration(duration) };
            Storyboard.SetTargetName(fadeInAnimation, "BlurEffect");
            Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath("ShadowDepth", 1));
            s.Completed += Story_Completed;
            

            duration = TimeSpan.FromMilliseconds(500);
            DoubleAnimation fadeInAnimation2 = new DoubleAnimation()
            { By=360, RepeatBehavior = new RepeatBehavior(5), Duration = new Duration(duration) };
            Storyboard.SetTargetName(fadeInAnimation2, "BlurEffect");
            Storyboard.SetTargetProperty(fadeInAnimation2, new PropertyPath("Direction", 1));

            duration = TimeSpan.FromMilliseconds(500);
            ColorAnimation fadeInAnimation3 = new ColorAnimation()
            { From = Color.FromRgb(0, 255, 20), To = Color.FromRgb(169, 107, 40), SpeedRatio = 0.3,AccelerationRatio = 1, Duration = new Duration(duration) };
            Storyboard.SetTargetName(fadeInAnimation3, "BlurEffect");
            Storyboard.SetTargetProperty(fadeInAnimation3, new PropertyPath("Color", 1));


            s.Children.Add(fadeInAnimation3);
            s.Children.Add(fadeInAnimation2);
            s.Children.Add(fadeInAnimation);
            s.Begin(this);

        }
        private void Story_Completed(object sender, EventArgs e)
        {
            this.dispatcherTimer.Start();
            this.dropEffect.Color = Color.FromRgb(169, 107, 40);


        }




    }
}
