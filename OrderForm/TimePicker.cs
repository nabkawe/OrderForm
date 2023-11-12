using sharedCode;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace OrderForm
{
    public partial class TimePicker : Form
    {
        public TimePicker()
        {
            InitializeComponent();
        }
        public static string SHOW()
        {
            TimePicker form = new TimePicker();
            form.TopMost = true;
            form.Location = new System.Drawing.Point(1390, 185);
            if (form.ShowDialog() == DialogResult.Yes)
            {
                return form.TimeLabel.Text.Replace(":", "") + form.label1.Text.Substring(0, 1);
            }
            else
            {
                return "";
            }


        }

        private void MessageForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.DialogResult = DialogResult.No;
                this.Close();
            }
            else if (e.KeyChar == (char)Keys.Enter)
            {
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
        }




        private void allRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if (radioButton != null)
            {
                if (radioButton.Checked)
                {
                    label1.Text = radioButton.Text;
                }
            }
        }




        string Minutes;
        string Hours;
        private void zerozero_CheckedChanged(object sender, EventArgs e)
        {
            var se = sender as RadioButton;
            Minutes = se.Text;
            ChangeTime();
        }
        private void HourChecked(object sender, EventArgs e)
        {
            var se = sender as RadioButton;
            se.Text = se.Text.Replace(" ", "");
            Hours = se.Text;
            ChangeTime();
        }

        private void ChangeTime()
        {
            var Hour = Convert.ToInt32(Hours);
            if (Hour == 0)
            {
                TimeLabel.Text = 12 + ":" + Minutes;
            }
            else if (Hour > 12 && Hour != 0)
            {
                Hour = Hour - 12;
                TimeLabel.Text = Hour.ToString() + ":" + Minutes;
            }
            else
            {
                TimeLabel.Text = Hour.ToString() + ":" + Minutes;
            }

        }

        private void TimePicker_Load(object sender, EventArgs e)
        {

            if (System.Windows.Forms.Application.OpenForms.OfType<Orders>().First().TimeInfo.Text == "الآن")
            {
                Hours = DateTime.Now.Hour.ToString();
                Minutes = DateTime.Now.Minute.ToString(); // if number under 10 make it preceded with 0
                if (Minutes.Length == 1)
                {
                    Minutes = "0" + Minutes;
                }
                ChangeTime();
                GetTimeOfTheDay();
                RadioCheck();
            }
            else
            {
                Hours = System.Windows.Forms.Application.OpenForms.OfType<Orders>().First().TimeInfo.Text.Replace("ليلا", "").Replace("مساء", "").Replace("عصرا", "").Replace("ظهرا", "").Replace("صباحا", "").Split(':')[0];
                Minutes = System.Windows.Forms.Application.OpenForms.OfType<Orders>().First().TimeInfo.Text.Replace("ليلا", "").Replace("مساء", "").Replace("عصرا", "").Replace("ظهرا", "").Replace("صباحا", "").Split(':')[1];
                ChangeTime();
                GetTimeOfTheDay2();
            }

        }

        private void RadioCheck()
        {
            // for every radio button in panel2 check if the text is over or under the current minutes
            // if it is over then check the next radio button that has a higher number.
            SortOrder sortOrder = SortOrder.Ascending;
            var sorted = panel2.Controls.OfType<RadioButton>().OrderBy(x => x.Text).ToList();
            panel2.Controls.Clear();
            if (sortOrder == SortOrder.Descending)
                sorted.Reverse();
            panel2.Controls.AddRange(sorted.ToArray());

            foreach (RadioButton item in panel2.Controls)
            {
                if (Convert.ToInt32(item.Text) >= Convert.ToInt32(Minutes))

                {
                    item.Checked = true;
                    break;
                }
            }

            SortOrder sortOrder3 = SortOrder.Ascending;
            var sorted3 = panel3.Controls.OfType<RadioButton>().OrderBy(x => Convert.ToInt32(x.Text)).ToList();
            panel3.Controls.Clear();

            if (sortOrder3 == SortOrder.Descending)
                sorted3.Reverse();

            panel3.Controls.AddRange(sorted3.ToArray());

            foreach (var item in panel3.Controls)
            {
                if (item.GetType() == typeof(RadioButton))
                {
                    RadioButton radio = (RadioButton)item;
                    if (Convert.ToInt32(radio.Text) >= Convert.ToInt32(Hours))

                    {
                        radio.Checked = true;
                        break;
                    }
                }

            }







        }

        private void GetTimeOfTheDay2()
        {
            var form = System.Windows.Forms.Application.OpenForms.OfType<Orders>().First();
            if (form.TimeInfo.Text.Contains("ليلا"))
            {
                nightRadioButton.Checked = true;
            }
            else if (form.TimeInfo.Text.Contains("عصرا"))
            {
                launchRadioButton.Checked = true;
            }
            else if (form.TimeInfo.Text.Contains("مساء"))
            {
                eveningRadioButton.Checked = true;
            }
            else if (form.TimeInfo.Text.Contains("صباحا"))
            {
                morningRadioButton.Checked = true;
            }
            else
            {
                noonRadioButton.Checked = true;
            }

        }

        private void GetTimeOfTheDay()
        {
            int index = DateTime.Now.Hour;
            if (index >= 3 && index <= 10)
            {
                morningRadioButton.Checked = true;
            }
            else if (index >= 11 && index <= 13)
            {
                noonRadioButton.Checked = true;
            }
            else if (index >= 14 && index <= 16)
            {
                launchRadioButton.Checked = true;
            }
            else if (index >= 17 && index <= 19)
            {
                eveningRadioButton.Checked = true;
            }
            else if (index >= 20 && index <= 23)
            {
                nightRadioButton.Checked = true;
            }
            else if (index >= 0 && index <= 2)
            {
                morningRadioButton.Checked = true;
            }

        }
    }
}
