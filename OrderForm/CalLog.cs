using sharedCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Navigation;
using Windows.AI.MachineLearning;
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
            this.Close();
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
            this.Close();
        }

        private void LoadLastNo_Click_1(object sender, EventArgs e)
        {
            PhonelogList.Clear();
            dbQ.loadPhoneBook(number()).OrderByDescending(y => y.CallDateTime).ToList().ForEach(x => PhonelogList.Add(x));
        }
        public static void LoadLastNumber()
        {
            if (dbQ.loadPhoneBook(1).OrderByDescending(y => y.CallDateTime).Equals(null))
            {
                return;
            }
            var item = dbQ.loadPhoneBook(1).OrderByDescending(y => y.CallDateTime).First();

            Application.OpenForms.OfType<Orders>().First().MobileTB.Text = item.PhoneNumber;
            Application.OpenForms.OfType<Orders>().First().NameTB.Text = item.CustomerName;


        }

        private void SearchLog_TextChanged(object sender, EventArgs e)
        {
            if(SearchLog.Text.Length >= 3)
            {
                PhonelogList.Clear();
                dbQ.loadPhoneBook(number()).Where(x => x.DisplayText.Contains(SearchLog.Text)).OrderByDescending(y => y.CallDateTime).ToList().ForEach(x => PhonelogList.Add(x));
            }
            else
            {
                PhonelogList.Clear();
                dbQ.loadPhoneBook(number()).OrderByDescending(y => y.CallDateTime).ToList().ForEach(x => PhonelogList.Add(x));
            }   
        }

        private int number()
        {
            return Convert.ToInt32(numericUpDown1.Value);
        }
    }
}
