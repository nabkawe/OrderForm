using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using sharedCode;
using System.Reflection;

namespace OrderFormCID
{
    public partial class CIDMain : Form
    {
        static BindingList<PhoneLog> ListString = new BindingList<PhoneLog>();
        public const string path = @"MNSCID.dll";

        [DllImport(path, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern short GetNewAnswer(byte[] data);
        public CIDMain()
        {
            InitializeComponent();
            timer1.Start();
            Tray.Visible = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            byte[] data = new byte[300];
            short Res = GetNewAnswer(data);
            if (Res == 2)
            {
                string d = Encoding.Default.GetString(data).Substring(15).Replace(".", string.Empty);
                d = "0" + d;
                if (!string.IsNullOrEmpty(d))
                {
                    PhoneLog phoneLog = PhoneLog.NewPhoneLog(d);
                    phoneLog.CallDateTime = DateTime.Now;
                    ListString.Add(phoneLog);
                    this.Name = "Caller ID" + ":" + phoneLog.PhoneNumber;
                }
            }
            else if (Res == 1)
            {
                Task.Run(Music);
            }
        }
        static void Music()
        {
            Console.Beep(659, 125); Console.Beep(659, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(167); Console.Beep(523, 125); Console.Beep(659, 125); Thread.Sleep(125); Console.Beep(784, 125); Thread.Sleep(375); Console.Beep(392, 125); Thread.Sleep(375); Console.Beep(523, 125); Thread.Sleep(250); Console.Beep(392, 125); Thread.Sleep(250); Console.Beep(330, 125); Thread.Sleep(250); Console.Beep(440, 125); Thread.Sleep(125); Console.Beep(494, 125); Thread.Sleep(125); Console.Beep(466, 125); Thread.Sleep(42); Console.Beep(440, 125); Thread.Sleep(125); Console.Beep(392, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(125); Console.Beep(784, 125); Thread.Sleep(125); Console.Beep(880, 125); Thread.Sleep(125); Console.Beep(698, 125); Console.Beep(784, 125);
        }
        public static List<PhoneLog> GetLastNumber()
        {
            List<PhoneLog> ListOfPhones = new List<PhoneLog>();
            ListString.ToList().ForEach(item => ListOfPhones.Add(item));
            ListString.Clear();
            return ListOfPhones;
        }
        private void Tray_DoubleClick(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("هل أنت متأكد من أنك تريد إغلاق كاشف الأرقام؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
            else if (dialogResult == DialogResult.No)
            {
                // Do nothing
            }
        }

        private void CIDMain_Load(object sender, EventArgs e)
        {
            this.Name = "Caller ID" + ":";
        }
    }
}
