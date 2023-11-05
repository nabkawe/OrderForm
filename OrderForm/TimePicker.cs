using sharedCode;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace OrderForm
{
    public partial class TimePicker : Form
    {
        public TimePicker()
        {
            InitializeComponent();
            // close form by pressing escape

        }

        public static string SHOW()
        {
            TimePicker form = new TimePicker();
            form.TopMost = true;
            form.Location = new System.Drawing.Point((Screen.PrimaryScreen.Bounds.Width / 2) - (form.Width / 2),
                                                          (Screen.PrimaryScreen.Bounds.Height / 2) - (form.Height / 2));
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

        private void TimePicker_Load(object sender, EventArgs e)
        {
            int currentHour = DateTime.Now.Hour;
            if (currentHour < 7 && currentHour >= 0)
            {

                int index = currentHour + 17;
                comboBox1.SelectedIndex = index;
            }
            else if (currentHour >= 7)
            {
                    int index = currentHour - 7;
                comboBox1.SelectedIndex = index;
            }


            int currentMinute = DateTime.Now.Minute;
            int mindex = (currentMinute / 5) + 1;
            if (mindex >= comboBox2.Items.Count)
            {
                mindex = comboBox2.Items.Count - 1;
            }
            comboBox2.SelectedIndex = mindex;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null)
            {
                TimeLabel.Text = $"{comboBox1.SelectedItem.ToString()}:{comboBox2.SelectedItem.ToString()}";
                // choose the appropriate radio button according to the hour in the combo box while understanding that the combobox index starts from 7am and ends with 6 am the next day
                int index = comboBox1.SelectedIndex;
                if (index <= 3)
                {
                    morningRadioButton.Checked = true;
                }
                else if (index >= 4 && index <= 6)
                {
                    noonRadioButton.Checked = true;
                }
                else if (index >= 7 && index <= 8)
                {
                    launchRadioButton.Checked = true;
                }
                else if (index >= 9 && index <= 11)
                {
                    eveningRadioButton.Checked = true;
                }
                else if (index >= 12 && index <= 20)
                {
                    nightRadioButton.Checked = true;
                }
                else if (index >= 21 && index <= 23)
                {
                    morningRadioButton.Checked = true;
                }
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

     
    }
}
