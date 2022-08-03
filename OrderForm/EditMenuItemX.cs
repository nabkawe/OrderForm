using sharedCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderForm
{
    public partial class EditMenuItemX : Form
    {
        public EditMenuItemX()
        {
            InitializeComponent();
            MIX = new MenuItemsX();
        }
        public void EditItems(MenuItemsX x)
        {
            MnameTB.Text = x.Name;
            MBarcode.Text = x.Barcode;
            MPrice.Text = x.Price;
            Mdetails.Text = x.Details;
            Mcal.Text = x.Cal;
            Mpath.Text = x.ImagePath;
            Availables.Checked = x.Available;
        }

        public MenuItemsX MIX { get; set; }

        private void AddSingleItem_Click(object sender, EventArgs e)
        {
            MenuItemsX m = new MenuItemsX()
            {
                Name = MnameTB.Text,
                Barcode = MBarcode.Text,
                ImagePath = Mpath.Text,
                Price = MPrice.Text,
                Details = Mdetails.Text,
                Cal = Mcal.Text,
                Available = Availables.Checked
            };
            MIX = null;
            MIX = m ;
        }

        private void ChoosePicPath_Click(object sender, EventArgs e)
        {
                var filePath = string.Empty;
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "c:\\db\\Images";
                    openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
                    openFileDialog.FilterIndex = 1;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        filePath = openFileDialog.FileName;
                        Mpath.Text = filePath;
                    }
                }
            
        }
    }
}
