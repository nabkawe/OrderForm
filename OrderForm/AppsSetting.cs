using sharedCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Networking.NetworkOperators;
using Windows.UI.Xaml.Controls;

namespace OrderForm
{
    public partial class AppsSetting : Form
    {
        public AppsSetting()
        {
            InitializeComponent();
        }
        private BindingList<AppMaterial> list = new BindingList<AppMaterial>();
        private void SaveAppsNames_Click(object sender, EventArgs e)
        {
            DbInv.deleteAllApps();
            foreach (AppSets item in lb.Items)
            {
                DbInv.SaveApps(item);
            }
        }
        private void lb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lb.SelectedIndex != -1)
            {
                
                var a = lb.SelectedItem as AppSets;
                AppSetsLabel.Text = a.Name;
                dvApps.DataSource = null;
                list.Clear();
                if (a.list != null) a.list.ForEach(x => list.Add(x));
                dvApps.DataSource = list;
            }
            else
            {
                AppSetsLabel.Text = "اسم التطبيق";
                dvApps.DataSource = null;
            }
        }

        private void AppsSetting_Load(object sender, EventArgs e)
        {
            LoadComboBox();
            lb.Items.AddRange(DbInv.LoadApps().ToArray());
            // make combobox1 not accept manual input
        }

        private void LoadComboBox()
        {
            comboBox1.Items.AddRange(Orders.ItemsLists.ToArray());
        }


        private void LoadList_Click_1(object sender, EventArgs e)
        {
            string a = Clipboard.GetText();
            foreach (string line in a.Split('\n'))
            {
                if (line.Trim() != "")
                {
                    list.Add(new AppMaterial { Name = line });
                }
            }
            dvApps.DataSource = null;
            dvApps.DataSource = list;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //search combobox items for matching text   
            if (textBox2.Text != "")
            {
                comboBox1.Items.Clear();
                foreach (var s in Orders.ItemsLists)
                {
                    if (s.Name.Contains(textBox2.Text))
                    {
                        comboBox1.Items.Add(s);
                    }
                }
                // show the combBox1 list
                comboBox1.DroppedDown = true;
                Cursor.Current = Cursors.Default;

            }
            else
            {
                comboBox1.DroppedDown = false;
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(Orders.ItemsLists.ToArray());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1 && dvApps.DataSource != null && comboBox1.Items.Count >0)
            {
                var a = comboBox1.SelectedItem as POSItems;
                dvApps.CurrentRow.Cells[1].Value = a.Barcode;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";   
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // are you sure you want to delete this item? then delete if Yes in lb listbox
            if (lb.SelectedIndex == -1) return;
            if (MessageForm.SHOW("هل أنت متأكد من رغبتك بحذف المادة", "تأكيد حذف", "نعم","لا") == DialogResult.Yes)
            {
                lb.Items.RemoveAt(lb.SelectedIndex);
                lb.ClearSelected();
                dvApps.DataSource = null;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // save list to selected item in lb listbox 
            if (lb.SelectedIndex != -1)
            {
                var a = lb.SelectedItem as AppSets;
                a.list.Clear();
                a.list.AddRange(list);
                dvApps.DataSource = null;
                dvApps.DataSource = list;
                lb.ClearSelected();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // check if lb has an appset object with the same name and clear the field if it does
            if (lb.Items.Count > 0)
            {
                foreach (AppSets item in lb.Items)
                {
                    if (item.Name.Trim() == textBox1.Text.Trim())
                    {
                        textBox1.Clear();
                        return;
                    }
                }
            }
            if (textBox1.Text.Trim() == "") return;

            var newApp = new AppSets { Name = textBox1.Text.Trim().ToLower(), list = new List<AppMaterial>() };  
            lb.Items.Add(newApp);
            textBox1.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // save lb listbox objects to a file to be retrieved later.
            if (lb.Items.Count == 0) return;
            var a = new List<AppSets>();
            foreach (AppSets item in lb.Items)
            {
                a.Add(item);
            }
            // save a to a file in the location 
            var path = @"c:\db\";
          
            var now = DateTime.Now.ToString("hh-mmttdd-MM-yy");
            var filename = path + "Apps" + now + ".backup";
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(a);
            File.WriteAllText(filename, s);
            MessageForm.SHOW("تم الحفظ بنجاح","معلومات","موافق");


        }

        private void button7_Click(object sender, EventArgs e)
        {
            //load a file and deserialize the object from json to a list of appsets objects
            var a = new List<AppSets>();
            var ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"c:\db\";
            ofd.Filter = "backup files (*.backup)|*.backup|All files (*.*)|*.*";
            ofd.FilterIndex = 2;
            ofd.RestoreDirectory = true;
               if (ofd.ShowDialog() == DialogResult.OK)
            {
                var file = File.ReadAllText(ofd.FileName);
                a = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AppSets>>(file);
                lb.Items.Clear();
                foreach (AppSets item in a)
                {
                    lb.Items.Add(item);
                }
            }
        }

        private void dvApps_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }


}
