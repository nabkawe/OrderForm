using sharedCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.Linq;

namespace OrderForm
{
    public class MenuItemsXViewModel : INotifyPropertyChanged
    {
        public static MenuItemsXViewModel me(MenuItemsX menuItemsX)
        {
            var viewModel = new MenuItemsXViewModel
            {
                ID = menuItemsX.ID,
                Barcode = menuItemsX.Barcode,
                Order = menuItemsX.order,
                Name = menuItemsX.Name,
                Details = menuItemsX.Details,
                EnName = menuItemsX.EnName,
                EnDetails = menuItemsX.EnDetails,
                Cal = menuItemsX.Cal,
                Price = menuItemsX.Price,
                ImagePath = menuItemsX.ImagePath,
                Available = menuItemsX.Available,
                Lang = menuItemsX.Lang
            };
            return viewModel;
        }


        private int _id;
        public int ID
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged(nameof(ID));
                }
            }
        }


        private string _barcode;
        public string Barcode
        {
            get { return _barcode; }
            set
            {
                if (_barcode != value)
                {
                    _barcode = value;
                    OnPropertyChanged(nameof(Barcode));
                }
            }
        }

        private int _order;
        public int Order
        {
            get { return _order; }
            set
            {
                if (_order != value)
                {
                    _order = value;
                    OnPropertyChanged(nameof(Order));
                }
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        private string _details;
        public string Details
        {
            get { return _details; }
            set
            {
                if (_details != value)
                {
                    _details = value;
                    OnPropertyChanged(nameof(Details));
                }
            }
        }

        private string _enName;
        public string EnName
        {
            get { return _enName; }
            set
            {
                if (_enName != value)
                {
                    _enName = value;
                    OnPropertyChanged(nameof(EnName));
                }
            }
        }

        private string _enDetails;
        public string EnDetails
        {
            get { return _enDetails; }
            set
            {
                if (_enDetails != value)
                {
                    _enDetails = value;
                    OnPropertyChanged(nameof(EnDetails));
                }
            }
        }

        private string _cal;
        public string Cal
        {
            get { return _cal; }
            set
            {
                if (_cal != value)
                {
                    _cal = value;
                    OnPropertyChanged(nameof(Cal));
                }
            }
        }

        private string _price;
        public string Price
        {
            get { return this._price; }
            set
            {
                if (this._price != value)
                {
                    this._price = value;
                    OnPropertyChanged(nameof(Price));
                }
            }
        }

        private string imagePath;
        public string ImagePath
        {
            get => imagePath;
            set => SetProperty(ref imagePath, value);
        }

        public BitmapImage ImagePathSmall

        {
            get
            {
                try
                {
                    string cacheImagesFolder = Path.Combine(Directory.GetCurrentDirectory(), "CacheImages2");
                    string cachedPhotoPath = Path.Combine(cacheImagesFolder, Path.GetFileName(ImagePath));

                    if (!Directory.Exists(cacheImagesFolder))
                    {
                        Directory.CreateDirectory(cacheImagesFolder);
                    }
                    else
                    {
                        if (File.Exists(cachedPhotoPath))
                        {


                            return new BitmapImage(new Uri(cachedPhotoPath));
                        }
                        else
                        {
                            if (File.Exists(ImagePath))
                            {
                                BitmapImage bitmapImage = new BitmapImage();
                                bitmapImage.BeginInit();
                                bitmapImage.UriSource = new Uri(ImagePath);
                                bitmapImage.DecodePixelWidth = 200; // set the width to 200 pixels
                                bitmapImage.EndInit();

                                PngBitmapEncoder encoder = new PngBitmapEncoder();
                                encoder.Frames.Add(BitmapFrame.Create(bitmapImage));

                                using (var fileStream = new FileStream(cachedPhotoPath, FileMode.Create))
                                {
                                    encoder.Save(fileStream);
                                }

                                if (File.Exists(cachedPhotoPath))
                                {
                                    return new BitmapImage(new Uri(cachedPhotoPath));
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    return new BitmapImage();

                }
                return new BitmapImage();




            }
        }


 

private bool available;
        public bool Available
        {
            get => available;
            set => SetProperty(ref available, value);
        }

        [Browsable(false)]
        public bool Lang { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {

            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;

            onChanged?.Invoke();

            OnPropertyChanged(propertyName);

            return true;

        }

    }

}
