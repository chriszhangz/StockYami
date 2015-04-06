using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StockYami
{
    public partial class WarningForm : Form
    {
        public Form1 f1;
        public void SetRichText(String text)
        {
            this.richTextBox1.Text=text;
        }
        public WarningForm(Form1 form1)
        {
            InitializeComponent();
            f1 = form1;
        }

        private void WarningForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            f1.warningForm = null;
        }
    }
}
