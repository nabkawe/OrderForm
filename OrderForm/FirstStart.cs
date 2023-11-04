using System;
using System.IO;
using System.Windows.Forms;

namespace OrderForm
{
    public partial class FirstStart : Form
    {
        public FirstStart()
        {
            InitializeComponent();
            FirstLogoTB.Text = Properties.Settings.Default.Logo;
            FirstRestTB.Text = Properties.Settings.Default.RestaurantName;
        }
        private void FirstLogoTB_DragOver(object sender, DragEventArgs e)
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

        private void FirstLogoTB_DragDrop(object sender, DragEventArgs e)
        {
            string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            FirstLogoTB.Text = filePaths[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (File.Exists(FirstLogoTB.Text))
            {
                Properties.Settings.Default.RestaurantName = FirstRestTB.Text;
                Properties.Settings.Default.Logo = FirstLogoTB.Text;
                Properties.Settings.Default.Api_Server = ServerPC.Checked;
                this.Close();
            }
            else
            {
                MessageForm.SHOW("قم بإختيار ملف صالح للاستخدام", "الملف غير متوفر", "مفهوم");

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileOpen.ShowDialog();
            FirstLogoTB.Text = FileOpen.FileName.ToString();

        }

        private void FirstStart_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(@"C:\db"))
            {
                Directory.CreateDirectory(@"C:\db");
            }
        }
    }
}
