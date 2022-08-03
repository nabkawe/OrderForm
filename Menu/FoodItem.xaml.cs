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
        public event EventHandler<FoodItem> Destroyed;
        public FoodItem()
        {
            InitializeComponent();
        }
        public FoodItem(MenuItemsX pos)
        {
            InitializeComponent();
            FillInfo(pos);
            IsMulti = false;
            Fadein();
        }
        int Count = 0;
        public FoodItem(IEnumerable<MenuItemsX> pos)
        {
            InitializeComponent();
            pos.ToList().ForEach(x => posLoop.Add(x));
            StartTimer();
            FillInfo(pos.Last());
            IsMulti = true;
            Fadein();

        }
        public List<MenuItemsX> posLoop = new List<MenuItemsX>();

       
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            try
            {
               
                if (Count < posLoop.Count)
                {
                    FadeOut();

                    Count += 1;
                    FillInfo(posLoop[Count]);
                    Fadein();
                }
                else if (Count == posLoop.Count)
                {
                    Count = -1;
                }
            }
            catch (Exception)
            {
                Count = -1;
                Count += 1;
                FillInfo(posLoop[Count]);
                Fadein();


            }



        }

        private void FadeOut()
        {
            RegisterName("foodi", this.FI);

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
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            dispatcherTimer.Start();

        }

        private ContentControl Reg(string r)
        {
            var contentControl = (ContentControl)this.FindResource(r);
            return contentControl;
        }
        public void FillInfo(MenuItemsX pos)
        {
            var Name = Reg("kName");
            Name.Content = pos.Name;

            var Details = Reg("kDetails");
           Details.Content = pos.Details;

            var Price = Reg("kPrice");
            Price.Content = pos.Price.ToString();

            var PictureName = Reg("kPicture");
            PictureName.Content = pos.ImagePath;
            
            var Cal = Reg("kCalories");
            Cal.Content = pos.Cal;
            var bar = Reg("kBarCode");
            bar.Content = pos.Barcode;
            this.Tag = pos.Barcode;
        }

        public void Fadein()
        {
            RegisterName("foodi", this.FI);

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


            RegisterName("BlurEffect", this.dropEffect);

            Storyboard s = new Storyboard();
            TimeSpan duration = TimeSpan.FromMilliseconds(1000); //
            DoubleAnimation fadeInAnimation = new DoubleAnimation()
            { From = 0.00, To = 10, RepeatBehavior = new RepeatBehavior(5), AutoReverse = true, Duration = new Duration(duration) };

            Storyboard.SetTargetName(fadeInAnimation, "BlurEffect");
            //Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath("ShadowDepth", 1));
            Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath("ShadowDepth", 1));
            s.Completed += S_Completed;
            s.Children.Add(fadeInAnimation);
            s.Begin(this);

        }
        public  void  DestroyMe()
        {
            this.dispatcherTimer.Stop();
            dispatcherTimer.Tick -= dispatcherTimer_Tick;


            Storyboard s = new Storyboard();
            Storyboard a = new Storyboard();
            TimeSpan duration = TimeSpan.FromMilliseconds(200); //
            DoubleAnimation fadeInAnimation = new DoubleAnimation()
            { From = 1.0, To = 0.1 ,  Duration = new Duration(duration) };

            Storyboard.SetTargetName(fadeInAnimation, this.Name);
            Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath("Opacity", 1));
            s.Children.Add(fadeInAnimation);
            //s.Begin(this);
            //DoubleAnimation collapse = new DoubleAnimation()
            //{ From = 0, To = this.Height, Duration = new Duration(duration) };
            //Storyboard.SetTargetName(collapse, this.Name);
            //Storyboard.SetTargetProperty(collapse, new PropertyPath("Height", 1));
            //s.Children.Add(collapse);
            s.Completed += S_Completed2;
            s.Begin(this);

        }

        private void S_Completed(object sender, EventArgs e)
        {
            this.dispatcherTimer.Start();

        }
        private void S_Completed2(object sender, EventArgs e)
        {
            Destroyed?.Invoke(this, this);
        }




    }
}
