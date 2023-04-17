using sharedCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Windows.ApplicationModel.Store;
using Windows.Services.Maps;

namespace OrderForm
{
    public partial class CalLog : Form
    {
        public CalLog()
        {
            InitializeComponent();
        }

        public static BindingList<PhoneLog> PhonelogList = new BindingList<PhoneLog>();

        private void CalLog_Load(object sender, EventArgs e)
        {
            PhonelogList.Clear();
            dbQ.loadPhoneBook().OrderByDescending(z => z.CallDateTime).ToList().ForEach(x => PhonelogList.Add(x));
            phoneLogLB.DisplayMember = "DisplayText";
            phoneLogLB.DataSource = PhonelogList;
            phoneLogLB.ValueMember = "CallDateTime";
            phoneLogLB.MouseWheel += PhoneLogLB_MouseWheel;
            phoneLogLB.Refresh();
            phoneLogLB.Update();




        }

        private void PhoneLogLB_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if (phoneLogLB.SelectedIndex != -1)
                { phoneLogLB.Focus(); SendKeys.Send("{UP}"); }
                else { phoneLogLB.SelectedIndex = 0; }
            }
            else {
                if (phoneLogLB.SelectedIndex != -1)
                { phoneLogLB.Focus(); SendKeys.Send("{DOWN}"); }
                else { phoneLogLB.SelectedIndex = 0; }
            }

        }


        private void CalLog_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void phoneLogLB_DoubleClick(object sender, EventArgs e)
        {

            LoadNo();

        }
        private void LoadNo()
        {
            if (phoneLogLB.SelectedItem != null)
            {
                var item = phoneLogLB.SelectedItem as PhoneLog;
                if (item != null)
                {
                    Application.OpenForms.OfType<Orders>().First().MobileTB.Text = item.PhoneNumber;
                    Application.OpenForms.OfType<Orders>().First().NameTB.Text = item.CustomerName;
                }
            }
        }

        private void AddNumberToForm_Click(object sender, EventArgs e)
        {
            LoadNo();
        }

        private void LoadLastNo_Click_1(object sender, EventArgs e)
        {
            PhonelogList.Clear();
            dbQ.loadPhoneBook(Convert.ToInt32(numericUpDown1.Value)).OrderByDescending(y => y.CallDateTime).ToList().ForEach(x => PhonelogList.Add(x));

        }
    }
}
