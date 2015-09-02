using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataVisualization_2D
{
    public partial class ChromeForm : Form
    {
        public ChromeForm()
        {
            InitializeComponent();

        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chromeWebBrowser1.OpenUrl("http://d3js.org/");
        }

        private void ChromeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            chromeWebBrowser1.Free();
            chromeWebBrowser1.Dispose();
        }

    }
}
