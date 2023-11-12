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

namespace OrderForm
{
    public partial class LogForm : Form
    {
        public LogForm()
        {
            InitializeComponent();
            LoadLogFile();

        }

        private void LoadLogFile()
    {
        string logFilePath = @"c:\db\log.text";
        if (File.Exists(logFilePath))
        {
                {
                    // read the last 100 lines of the log file.
                    string[] lines = File.ReadAllLines(logFilePath);
                    int lineCount = lines.Length;
                    int startLine = 0;
                    if (lineCount > 100)
                    {
                        startLine = lineCount - 100;
                    }
                    string logText = "";
                    for (int i = startLine; i < lineCount; i++)
                    {
                        logText += lines[i] + "\r\n";
                    }
                    logText += "\r\n";
                        
                textBoxLog.Text = logText;
                    textBoxLog.TextChanged += TextBoxLog_TextChanged;
                    textBoxLog.SelectionStart = textBoxLog.Text.Length;
                    textBoxLog.ScrollToCaret();
                }
            }
        else
        {
            MessageBox.Show("Log file not found!");
        }

        }

        private void TextBoxLog_TextChanged(object sender, EventArgs e)
        {
            textBoxLog.SelectionStart = textBoxLog.Text.Length;
            textBoxLog.ScrollToCaret();
        }

        private void textBoxLog_DoubleClick(object sender, EventArgs e)
        {
            LoadLogFile();
        }
    }
}


