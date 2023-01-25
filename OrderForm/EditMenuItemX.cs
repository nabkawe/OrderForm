using sharedCode;
using System;
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
            EnMnameTB.Text = x.EnName;
            MBarcode.Text = x.Barcode;
            MPrice.Text = x.Price;
            Mdetails.Text = x.Details;
            EnMdetails.Text = x.EnDetails;
            Mcal.Text = x.Cal;
            Mpath.Text = x.ImagePath;
            Availables.Checked = x.Available;
        }

        public MenuItemsX MIX { get; set; }

        private void AddSingleItem_Click(object sender, EventArgs e)
        {
            MIX = null;

            MenuItemsX m = new MenuItemsX()
            {
                Name = MnameTB.Text,
                EnName = EnMnameTB.Text,
                Barcode = MBarcode.Text,
                ImagePath = Mpath.Text,
                Price = MPrice.Text,
                Details = Mdetails.Text,
                EnDetails = EnMdetails.Text,
                Cal = Mcal.Text,
                Available = Availables.Checked
            };
            MIX = m;
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
        private void Mpath_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Mpath_DragDrop(object sender, DragEventArgs e)
        {
            string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            Mpath.Text = filePaths[0];
        }

    }
}
