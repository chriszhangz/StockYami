using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
//using Microsoft.Win32;

namespace StockYami
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //RegistryKey hklm = Registry.LocalMachine;
            //RegistryKey key = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION", true);
            //key.SetValue("StockYami.exe", "11000", RegistryValueKind.DWord);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
