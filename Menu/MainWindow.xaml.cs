using sharedCode;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ShowOnSecondScreen();
            FoodItemZ = new BindingList<NewFood>();
        }


        public static BindingList<NewFood> FoodItemZ { get; set; }
        public string CurrentMenu;
        public static System.Windows.Size Currentsize;

        public async Task LaunchMenu(List<MenuItemZ> list, string CurrentMenuIn, bool langs, [Optional] System.Windows.Size ItemSize )
        {
            
            try
            {
                FoodItemZ.Clear();

                this.FoodList.ItemsSource = FoodItemZ;

   
                CurrentMenu = CurrentMenuIn;

                foreach (MenuItemZ item in list)
                {
                    item.items.ForEach(x => x.Lang = langs);
                    NewFood foodItem = new NewFood(item);
                    if (ItemSize.Width > 0) { foodItem.Width = ItemSize.Width; foodItem.Height = ItemSize.Height; Currentsize = ItemSize; }
                    FoodItemZ.Add(foodItem);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }


        }


        public static void FindByBarcode(string barcode)
        {
            foreach (NewFood item in FoodItemZ)
            {
                if (item.Single)
                {
                    var bar = (string)item.Tag;
                    if (bar.Contains('-'))
                    {
                        for (int i = 0; i < bar.Split('-').Count(); i++)
                        {
                            if (bar.Split('-')[i] != null)
                            {
                                if (bar.Split('-')[i] == barcode)
                                {
                                    item.PickedYou();
                                    return;
                                }
                            }
                        }
                    }
                    else
                    if ((string)item.Tag == barcode)
                    {
                        
                        item.PickedYou();
                        return;

                    }
                }
                else
                {
                    foreach (var items in item.posLoop)
                    {
                        if (items.Barcode.Contains("-"))
                        {
                            for (int i = 0; i < items.Barcode.Split('-').Count(); i++)
                            {
                                if (items.Barcode.Split('-')[i] != null)
                                {
                                    if (items.Barcode.Split('-')[i] == barcode)
                                    {
                                        item.DataContext = items;
                                        item.PickedYou();
                                        return;
                                    }
                                }
                            }

                        }
                        else
                        {
                            if (items.Barcode == barcode)
                            {
                                item.DataContext = items;
                                item.PickedYou();
                                return;
                            }
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
            if (Width > Height)
            {
                this.Top_Row.Height = new GridLength(0, GridUnitType.Star);
                this.Bot_Row.Height = new GridLength(1, GridUnitType.Star);
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

