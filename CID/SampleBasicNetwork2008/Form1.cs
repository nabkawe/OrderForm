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

namespace OrderForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ListString.AddingNew += ListString_AddingNew;
            listBox3.DataSource = ListString;
            ListString.Add("Caller ID");

        }

        private void ListString_AddingNew(object sender, AddingNewEventArgs e)
        {
            try
            {
                Tray.Text = ListString.Last();
                Tray.ShowBalloonTip(5);
                Task.Run(Music);
            }
            catch (Exception)
            {

                return;
            }
        }



        BindingList<string> ListString = new BindingList<string>();
        public const string path = @"MNSCID.dll";

        [DllImport(path, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern short GetNewAnswer(byte[] data);

        [DllImport(path, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern bool SendLastCommandToNetwork(byte[] data);

        [DllImport(path, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern void GetOfflineWithoutDeleteData(int DeviceIndex);

        [DllImport(path, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern void GetOfflineWithDeleteData(int DeviceIndex);



        private void timer1_Tick(object sender, EventArgs e)
        {
            //timer1.Enabled = false;
            byte[] data = new byte[300];
            short Res = GetNewAnswer(data);
            if (Res == 2)
            {
                string d = Encoding.Default.GetString(data).Substring(15).Replace(".", string.Empty);
                d = "0" + d;
                if (!string.IsNullOrEmpty(d))
                {
                    ListString.Add(d);
                    Clipboard.Clear();
                    Clipboard.SetText(d);
                    Clipboard.SetText(d);
                    Clipboard.SetText(d);

                }

            }
            else if (Res == 1)
            {
                if (listBox3.Items.Count >= 1)
                {
                    Clipboard.Clear();
                    Clipboard.SetText(ListString.Last());
                    Clipboard.SetText(ListString.Last());
                    Clipboard.SetText(ListString.Last());

                    Task.Run(Music);
                }
            }


            //timer1.Enabled = true;
        }
        static void Music()
        {
            Console.Beep(659, 125); Console.Beep(659, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(167); Console.Beep(523, 125); Console.Beep(659, 125); Thread.Sleep(125); Console.Beep(784, 125); Thread.Sleep(375); Console.Beep(392, 125); Thread.Sleep(375); Console.Beep(523, 125); Thread.Sleep(250); Console.Beep(392, 125); Thread.Sleep(250); Console.Beep(330, 125); Thread.Sleep(250); Console.Beep(440, 125); Thread.Sleep(125); Console.Beep(494, 125); Thread.Sleep(125); Console.Beep(466, 125); Thread.Sleep(42); Console.Beep(440, 125); Thread.Sleep(125); Console.Beep(392, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(125); Console.Beep(784, 125); Thread.Sleep(125); Console.Beep(880, 125); Thread.Sleep(125); Console.Beep(698, 125); Console.Beep(784, 125);
        }
        public static List<string> GetLastFiveNumber()
        {
            var list = new List<string>();
            
            return list;

        }

        private void listBox3_DoubleClick(object sender, EventArgs e)
        {
            if (listBox3.SelectedIndex != -1)
            {
                Clipboard.SetText(listBox3.SelectedItem.ToString());
            }
        }
        private void Tray_BalloonTipClicked(object sender, EventArgs e)
        {
            Clipboard.SetText(this.Tray.BalloonTipText);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            Tray.Visible = true;
        }
        private void Tray_DoubleClick(object sender, EventArgs e)
        {
            if (ListString.Count > 0)
            {
                Clipboard.SetText(ListString.Last());
            }
        }
        private void Tray_BalloonTipShown(object sender, EventArgs e)
        {
            Task.Run(Music);
        }

    }
}
