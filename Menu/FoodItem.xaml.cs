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
    public partial class FoodItem : UserControl
    {
        public bool IsMulti {get;set;}
        public System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        
        public FoodItem(MenuItemsX pos)
        {
            this.InitializeComponent();
            this.FillInfo(pos);
            this.IsMulti = false;
            this.Fadein();
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

       
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            try
            {
               
                if (this.Count < this.posLoop.Count)
                {
                    this.FadeOut();

                    this.Count += 1;
                    this.FillInfo(this.posLoop[Count]);
                    this.Fadein();
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
                this.Fadein();


            }



        }

        private void FadeOut()
        {
            this.RegisterName("foodi", this.FI);

            Storyboard storyboard = new Storyboard();
            
            TimeSpan duration = TimeSpan.FromMilliseconds(1000); //

            DoubleAnimation fadeInAnimation = new DoubleAnimation()
            { From = 1, To = 0, Duration = new Duration(duration) };

            Storyboard.SetTargetName(fadeInAnimation, "foodi");
            Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath("Opacity", 1));
            storyboard.Children.Add(fadeInAnimation);
            storyboard.Begin(this);
        }

        private void StartTimer()
        {
            this.dispatcherTimer.Tick += dispatcherTimer_Tick;
            this.dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            this.dispatcherTimer.Start();

        }

        private ContentControl Reg(string r)
        {
            var contentControl = (ContentControl)this.FindResource(r);
            return contentControl;
        }
        public void FillInfo(MenuItemsX pos)
        {
            var Name = this.Reg("kName");
            Name.Content = pos.Name;

            var Details = this.Reg("kDetails");
           Details.Content = pos.Details;

            var Price = this.Reg("kPrice");
            Price.Content = pos.Price.ToString();

            var PictureName = this.Reg("kPicture");
            PictureName.Content = pos.ImagePath;
            
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
            TimeSpan duration = TimeSpan.FromMilliseconds(1000); //

            DoubleAnimation fadeInAnimation = new DoubleAnimation()
            { From = 0.0, To = 1.0, Duration = new Duration(duration) };

            Storyboard.SetTargetName(fadeInAnimation, "foodi");
            Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath("Opacity", 1));
          storyboard.Children.Add(fadeInAnimation);
          storyboard.Begin(this);
        }

     

        public void PickedYou()
        {
            this.dispatcherTimer.Stop();


            this.RegisterName("BlurEffect", this.dropEffect);

            Storyboard s = new Storyboard();
            TimeSpan duration = TimeSpan.FromMilliseconds(1000); //
            DoubleAnimation fadeInAnimation = new DoubleAnimation()
            { From = 0.00, To = 40, RepeatBehavior = new RepeatBehavior(5), AutoReverse = true, Duration = new Duration(duration) };

            Storyboard.SetTargetName(fadeInAnimation, "BlurEffect");
            //Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath("ShadowDepth", 1));
            Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath("BlurRadius", 1));
            s.Completed += S_Completed;
            s.Children.Add(fadeInAnimation);
            s.Begin(this);

        }
        private void S_Completed(object sender, EventArgs e)
        {
            this.dispatcherTimer.Start();

        }
        //public  void  DestroyMe()
        //{
        //    this.dispatcherTimer.Stop();
        //    dispatcherTimer.Tick -= dispatcherTimer_Tick;


        //    Storyboard s = new Storyboard();
        //    Storyboard a = new Storyboard();
        //    TimeSpan duration = TimeSpan.FromMilliseconds(200); //
        //    DoubleAnimation fadeInAnimation = new DoubleAnimation()
        //    { From = 1.0, To = 0.1 ,  Duration = new Duration(duration) };

        //    Storyboard.SetTargetName(fadeInAnimation, this.Name);
        //    Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath("Opacity", 1));
        //    s.Children.Add(fadeInAnimation);
        //    //s.Begin(this);
        //    //DoubleAnimation collapse = new DoubleAnimation()
        //    //{ From = 0, To = this.Height, Duration = new Duration(duration) };
        //    //Storyboard.SetTargetName(collapse, this.Name);
        //    //Storyboard.SetTargetProperty(collapse, new PropertyPath("Height", 1));
        //    //s.Children.Add(collapse);
        //    s.Completed += S_Completed2;
        //    s.Begin(this);

        //}


        //private void S_Completed2(object sender, EventArgs e)
        //{
        //    Destroyed?.Invoke(this, this);
        //}




    }
}
