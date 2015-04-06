using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace StockYami
{
    public partial class Form1 : Form
    {
        public WarningForm warningForm = null;
        public int recontimes = 0;
        string command;
        public Form1()
        {
            InitializeComponent();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //Console.WriteLine("type:" + webBrowser1.DocumentType);
            //Console.WriteLine("Title:" + webBrowser1.DocumentTitle);
            if (webBrowser1.DocumentType == "File" || webBrowser1.DocumentTitle == "502 Bad Gateway")
            {
                LogHelper.WriteErrorLog("DocumentType:" + webBrowser1.DocumentType + " DocumentTitle:" + webBrowser1.DocumentTitle + " ReadyState:" + webBrowser1.ReadyState);
                if (warningForm == null)
                {
                    warningForm = new WarningForm(this);
                    //this.Invoke(new Action(() => this.show_WarningForm()));
                    Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - warningForm.Width, Screen.PrimaryScreen.WorkingArea.Height - warningForm.Height);
                    warningForm.PointToScreen(p);
                    warningForm.Location = p;
                    if (recontimes > 100)
                    {
                        warningForm.SetRichText("Reconnecting failed.!\nPlease contact IT!");
                    }
                    warningForm.Show();
                }
                else
                {
                    Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - warningForm.Width, Screen.PrimaryScreen.WorkingArea.Height - warningForm.Height);
                    warningForm.PointToScreen(p);
                    warningForm.Location = p;
                    if (recontimes > 100)
                    {
                        warningForm.SetRichText("Reconnecting failed.!\nPlease contact IT Dept.!");
                    }
                    warningForm.Show();
                }
                if (recontimes > 10)
                {
                    command = "netsh wlan disconnect";
                    executeCmd(command); 
                    command = "netsh wlan connect name=YAMIBUY";
                    executeCmd(command);
                    recontimes = 0;
                }
                Thread.Sleep(500);
                recontimes++;
                Application.DoEvents();
                this.Invoke(new Action(() =>webBrowser1.Navigate("http://192.168.1.242/picking_flow.php")));
                //webBrowser1.Navigate("http://192.168.1.242/picking_flow.php");
                //webBrowser1.Navigate("http://stock.yamibuy.com/picking_flow.php");
                //webBrowser1.Navigate("http://127.0.0.1:8080/test2.php");
            }
            else
            {
                LogHelper.WriteErrorLog("DocumentType:" + webBrowser1.DocumentType + " DocumentTitle:" + webBrowser1.DocumentTitle + " ReadyState:" + webBrowser1.ReadyState);
                recontimes = 0;
                if (warningForm != null)
                {
                    warningForm.Close();
                    this.Focus();
                }
            }
        }
        private void show_WarningForm()
        {
            if (warningForm != null)
            {
                Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - warningForm.Width, Screen.PrimaryScreen.WorkingArea.Height - warningForm.Height);
                warningForm.PointToScreen(p);
                warningForm.Location=p;
                warningForm.Show();
                //for (int i = 0; i <= warningForm.Height; i++)
                //{
                //    warningForm.Location = new Point(p.X, p.Y - i);
                //    Thread.Sleep(1);
                //}
            }
        }

        public string executeCmd(string Command)
        {
            Process process = new Process
            {
                StartInfo = { FileName = " cmd.exe ", UseShellExecute = false, RedirectStandardInput = true, RedirectStandardOutput = true, CreateNoWindow = true }
            };
            process.Start();
            process.StandardInput.WriteLine(Command);
            process.StandardInput.WriteLine("exit");
            process.WaitForExit();
            string str = process.StandardOutput.ReadToEnd();
            process.Close();
            return str;
        }
    }
}
