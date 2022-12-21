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


namespace Menu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ShowOnSecondScreen();
            foodItems = new BindingList<FoodItem>();
        }

        public BindingList<FoodItem> foodItems { get; set; }
        public string CurrentMenu;

        public async Task  LaunchMenu(List<object> list, string CurrentMenuIn)
        {
            
            try
            {
                foodItems.Clear();
                Storyboard storyboard = new Storyboard();
                TimeSpan duration = TimeSpan.FromMilliseconds(400); //
                DoubleAnimation fadeInAnimation = new DoubleAnimation()
                { From = 1, To = 0, AutoReverse = true, Duration = new Duration(duration) };
                Storyboard.SetTargetName(fadeInAnimation, this.FoodList.Name) ;
                Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath("Opacity", 1));
                storyboard.Children.Add(fadeInAnimation);
                storyboard.Begin(this);
                CurrentMenu = CurrentMenuIn;
                 foreach (object item in list)
                {
                    if (item.GetType() == typeof(object[]))
                    {
                        List<object> L = (item as IEnumerable<object>).Cast<object>().ToList();
                        var LS = L.Cast<MenuItemsX>().ToList();

                         FoodItem foodList = new FoodItem(LS);

                        foodItems.Add(foodList);


                    }
                    else if (item.GetType() == typeof(MenuItemsX))
                    {
                        FoodItem foodItem = new FoodItem((MenuItemsX)item);
                        foodItems.Add(foodItem);

                    }

                }
                 this.FoodList.ItemsSource = foodItems;
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString()); 
            }
            
        }


        public void FindByBarcode(string barcode)
        {
            foreach (FoodItem item in this.foodItems)
            {
                if (!item.IsMulti)
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
            //this.Left = SystemParameters.VirtualScreenLeft;
            //this.Top = SystemParameters.VirtualScreenTop;
            //this.Height = SystemParameters.VirtualScreenHeight;
            //this.Width = SystemParameters.VirtualScreenWidth;
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
                
                //this.InfoPanels.MadaMid.Visibility = Visibility.Hidden;
                //this.InfoPanels.logoMid.Height = this.InfoPanels.logoMid.Height / 2;
                //this.InfoPanels.logoMid.Width = this.InfoPanels.logoMid.Width / 2;
                //this.InfoPanels.logoMid.VerticalAlignment = VerticalAlignment.Top;

            }
            else
            {

            }


        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;
        }

        private void InformationPanel_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}

