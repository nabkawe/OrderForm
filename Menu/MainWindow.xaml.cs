using sharedCode;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Threading;
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
            FoodItemZ = new ObservableCollection<NewFood>();
            FoodList.ItemsSource = FoodItemZ;

        }


        public static ObservableCollection<NewFood> FoodItemZ { get; set; }
        public string CurrentMenu;
        public static System.Windows.Size Currentsize;

        public async Task LaunchMenu(List<MenuItemZ> list, string CurrentMenuIn, bool langs, [Optional] System.Windows.Size ItemSize)
        {

            try
            {
                HeadersPanel.Children.Clear();


                FoodItemZ.Clear();
                CurrentMenu = CurrentMenuIn;
                foreach (MenuItemZ item in list)
                {
                    item.items.ForEach(x => x.Lang = langs);
                    NewFood foodItem = new NewFood(item);
                    if (ItemSize.Width > 0) { foodItem.Width = ItemSize.Width; foodItem.Height = ItemSize.Height; Currentsize = ItemSize; }
                    FoodItemZ.Add(foodItem);
                }

                if (MenuDB.GetMenuHeaders(CurrentMenuIn).Count() > 0)
                {
                    foreach (var item in MenuDB.GetMenuHeaders(CurrentMenuIn))
                    {
                        var h = new Header();
                        h.HeaderText.Text = item.HeaderName;
                        h.Width = item.height;
                        h.Height = 150;
                        h.Margin = new Thickness(0, item.initialHeight, 0, 0);
                        //h.Width = HeadersPanel.Width;
                        Color bColor = new Color();
                        var abyte = Convert.ToByte(item.BackgroundColor.Split(',')[0]);
                        var rbyte = Convert.ToByte(item.BackgroundColor.Split(',')[1]);
                        var gbyte = Convert.ToByte(item.BackgroundColor.Split(',')[2]);
                        var bbyte = Convert.ToByte(item.BackgroundColor.Split(',')[3]);
                        bColor.A = abyte;
                        bColor.R = rbyte;
                        bColor.G = gbyte;
                        bColor.B = bbyte;
                        Color fcolor = new Color();
                        var fabyte = Convert.ToByte(item.ForegroundColor.Split(',')[0]);
                        var frbyte = Convert.ToByte(item.ForegroundColor.Split(',')[1]);
                        var fgbyte = Convert.ToByte(item.ForegroundColor.Split(',')[2]);
                        var fbbyte = Convert.ToByte(item.ForegroundColor.Split(',')[3]);
                        fcolor.A = fabyte;
                        fcolor.R = frbyte;
                        fcolor.G = fgbyte;
                        fcolor.B = fbbyte;
                        h.HeaderBack.Background = new SolidColorBrush(bColor);  
                        h.HeaderText.Foreground = new SolidColorBrush(fcolor);
                        h.HeaderText.FontFamily = new FontFamily(item.FontFamily);
                        h.HeaderText.FontSize = item.FontSize;
                        
                        HeadersPanel.Children.Add(h);
                        HeadersPanel.UpdateLayout();    
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(GetWindow(this), ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }



        }




        public static void FindByBarcode(string barcode)
        {
            foreach (NewFood item in FoodItemZ)
            {
                if (item.Single)
                {
                    var bar = (string)item.Tag;
                    if (ContainsBarcode(bar, barcode))
                    {
                        item.PickedYou();
                        return;
                    }
                }
                else
                {
                    foreach (var items in item.posLoop)
                    {
                        if (ContainsBarcode(items.Barcode, barcode))
                        {
                            item.ChangeDataContext(items);
                            item.PickedYou();
                            return;
                        }
                    }
                }
            }
        }

        private static bool ContainsBarcode(string source, string target)
        {
            if (source.Contains('-'))
            {
                foreach (var part in source.Split('-', (char)StringSplitOptions.RemoveEmptyEntries))
                {
                    if (part.Equals(target, StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
            }
            else
            {
                if (source.Equals(target, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
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

