using sharedCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using WpfScreenHelper;


namespace OrderForm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public  partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ShowOnSecondScreen();
            foodItems = new BindingList<FoodItem>();
            foodItemZ = new BindingList<NewFood>();
        }


        public static BindingList<FoodItem> foodItems { get; set; }
        public static BindingList<NewFood> foodItemZ { get; set; }
        public string CurrentMenu;

        
        public async Task LaunchMenu(List<MenuItemZ> list, string CurrentMenuIn)
        {

            try
            {
                foodItemZ.Clear();
                Storyboard storyboard = new Storyboard();
                TimeSpan duration = TimeSpan.FromMilliseconds(400); //
                DoubleAnimation fadeInAnimation = new DoubleAnimation()
                { From = 1, To = 0, AutoReverse = true, Duration = new Duration(duration) };
                Storyboard.SetTargetName(fadeInAnimation, this.FoodList.Name);
                Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath("Opacity", 1));
                storyboard.Children.Add(fadeInAnimation);
                storyboard.Begin(this);
                CurrentMenu = CurrentMenuIn;
                foreach (MenuItemZ item in list)
                {
                    NewFood foodItem = new NewFood(item);
                        foodItemZ.Add(foodItem);
                }
                this.FoodList.ItemsSource = foodItemZ;
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }


        public static  void FindByBarcode(string barcode)
        {
            foreach (NewFood item in foodItemZ)
            {
                if (item.Single)
                {
                    if ((string)item.Tag == barcode)
                    {
                        item.PickedYou();
                    }
                }
                else
                {
                    foreach (var items in item.posLoop)
                    {
                        if (items.Barcode == barcode)
                        {
                            item.FillInfo(items);
                            item.PickedYou();
                        }
                    }
                }
            }
        }


        private void ShowOnSecondScreen()
        {
            Screen screen = WpfScreenHelper.Screen.AllScreens.Last();
            Left = screen.Bounds.Left;
            Top = screen.Bounds.Top;
            Width = screen.Bounds.Width;
            Height = screen.Bounds.Height;
            // portrait mode
            if (Width> Height)
            {
                this.Top_Row.Height = new GridLength(0,GridUnitType.Star);
                this.Bot_Row.Height = new GridLength(1,GridUnitType.Star);
            }
            else
            {
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;
        }

    

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}

