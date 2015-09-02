using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataVisualization_WEB
{
    public partial class DataVisualization_WEB : Form
    {
        public DataVisualization_WEB()
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
