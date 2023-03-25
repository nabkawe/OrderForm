using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SampleBasicNetwork2008
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        public const string path = @"MNSCID.dll";
        
        [DllImport(path, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern short GetNewAnswer(byte[] data);
        
        [DllImport(path, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern bool SendLastCommandToNetwork(byte[] data);

        [DllImport(path, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern void GetOfflineWithoutDeleteData(int DeviceIndex);

        [DllImport(path, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern void GetOfflineWithDeleteData(int DeviceIndex);

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox1.Text);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            byte[] data = new byte[300];
            short Res = GetNewAnswer(data);
            if (Res != 0)
            {
                string d = Encoding.Default.GetString(data).Replace("\0", string.Empty);
                if (!string.IsNullOrEmpty(d))
                {
                    listBox3.Items.Add(d);
                    {
                        for (int TempI = 0; TempI < listBox1.Items.Count; TempI++)
                        {
                            byte[] ip = Encoding.ASCII.GetBytes(listBox1.Items[TempI].ToString());
                            SendLastCommandToNetwork(ip);
                        }
                    }
                }
            }

            timer1.Enabled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GetOfflineWithDeleteData(0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GetOfflineWithoutDeleteData(0);
        }
    }
}
