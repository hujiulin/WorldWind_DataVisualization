/*
 * Authoer: Jiulin Hu (tohujiulin@126.com Beijing Normal University)
 * Version: 1.0
 * Description: Data Visulation from MSChart
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DBEngine;

namespace DataVisualization_2D
{
    public class DataVisualization_2D : Form
    {
        #region Designer
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dBDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.demoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.areaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.circularToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pyramidToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 25);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(792, 541);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.randomDataToolStripMenuItem,
            this.dBDataToolStripMenuItem,
            this.demoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(792, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // randomDataToolStripMenuItem
            // 
            this.randomDataToolStripMenuItem.Name = "randomDataToolStripMenuItem";
            this.randomDataToolStripMenuItem.Size = new System.Drawing.Size(96, 21);
            this.randomDataToolStripMenuItem.Text = "RandomData";
            this.randomDataToolStripMenuItem.Click += new System.EventHandler(this.randomDataToolStripMenuItem_Click);
            // 
            // dBDataToolStripMenuItem
            // 
            this.dBDataToolStripMenuItem.Name = "dBDataToolStripMenuItem";
            this.dBDataToolStripMenuItem.Size = new System.Drawing.Size(64, 21);
            this.dBDataToolStripMenuItem.Text = "DBData";
            this.dBDataToolStripMenuItem.Click += new System.EventHandler(this.dBDataToolStripMenuItem_Click);
            // 
            // demoToolStripMenuItem
            // 
            this.demoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barToolStripMenuItem,
            this.lineToolStripMenuItem,
            this.pointsToolStripMenuItem,
            this.pieToolStripMenuItem,
            this.areaToolStripMenuItem,
            this.rangeToolStripMenuItem,
            this.circularToolStripMenuItem,
            this.pyramidToolStripMenuItem});
            this.demoToolStripMenuItem.Name = "demoToolStripMenuItem";
            this.demoToolStripMenuItem.Size = new System.Drawing.Size(83, 21);
            this.demoToolStripMenuItem.Text = "DemoType";
            // 
            // barToolStripMenuItem
            // 
            this.barToolStripMenuItem.Name = "barToolStripMenuItem";
            this.barToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.barToolStripMenuItem.Text = "Bar";
            this.barToolStripMenuItem.Click += new System.EventHandler(this.barToolStripMenuItem_Click);
            // 
            // lineToolStripMenuItem
            // 
            this.lineToolStripMenuItem.Name = "lineToolStripMenuItem";
            this.lineToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.lineToolStripMenuItem.Text = "Line";
            this.lineToolStripMenuItem.Click += new System.EventHandler(this.lineToolStripMenuItem_Click);
            // 
            // pointsToolStripMenuItem
            // 
            this.pointsToolStripMenuItem.Name = "pointsToolStripMenuItem";
            this.pointsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.pointsToolStripMenuItem.Text = "Points";
            this.pointsToolStripMenuItem.Click += new System.EventHandler(this.pointsToolStripMenuItem_Click);
            // 
            // pieToolStripMenuItem
            // 
            this.pieToolStripMenuItem.Name = "pieToolStripMenuItem";
            this.pieToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.pieToolStripMenuItem.Text = "Pie";
            this.pieToolStripMenuItem.Click += new System.EventHandler(this.pieToolStripMenuItem_Click);
            // 
            // areaToolStripMenuItem
            // 
            this.areaToolStripMenuItem.Name = "areaToolStripMenuItem";
            this.areaToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.areaToolStripMenuItem.Text = "Area";
            this.areaToolStripMenuItem.Click += new System.EventHandler(this.areaToolStripMenuItem_Click);
            // 
            // rangeToolStripMenuItem
            // 
            this.rangeToolStripMenuItem.Name = "rangeToolStripMenuItem";
            this.rangeToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.rangeToolStripMenuItem.Text = "Range";
            this.rangeToolStripMenuItem.Click += new System.EventHandler(this.rangeToolStripMenuItem_Click);
            // 
            // circularToolStripMenuItem
            // 
            this.circularToolStripMenuItem.Name = "circularToolStripMenuItem";
            this.circularToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.circularToolStripMenuItem.Text = "Circular";
            this.circularToolStripMenuItem.Click += new System.EventHandler(this.circularToolStripMenuItem_Click);
            // 
            // pyramidToolStripMenuItem
            // 
            this.pyramidToolStripMenuItem.Name = "pyramidToolStripMenuItem";
            this.pyramidToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.pyramidToolStripMenuItem.Text = "Pyramid";
            this.pyramidToolStripMenuItem.Click += new System.EventHandler(this.pyramidToolStripMenuItem_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(671, 25);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(589, 28);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(35, 16);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "2D";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(630, 28);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(35, 16);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "3D";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // DataVisualization_2D
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "DataVisualization_2D";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DataVisualization_2D";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        #endregion

        #region database
        static private string _database = "datavisualization";
        static private string _dataSource = "localhost";
        static private string _userId = "root";
        static private string _password = "root";
        static private string _charset = "utf8";
        static private string _pooling = "true";
        static private int _number = 10;
        #endregion

        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem demoToolStripMenuItem;
        private ToolStripMenuItem barToolStripMenuItem;
        private ToolStripMenuItem lineToolStripMenuItem;
        private ToolStripMenuItem pointsToolStripMenuItem;
        private ToolStripMenuItem pieToolStripMenuItem;
        private ToolStripMenuItem areaToolStripMenuItem;
        private ToolStripMenuItem rangeToolStripMenuItem;
        private ToolStripMenuItem circularToolStripMenuItem;
        private ToolStripMenuItem pyramidToolStripMenuItem;
        private ToolStripMenuItem randomDataToolStripMenuItem;
        private ComboBox comboBox1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private ToolStripMenuItem dBDataToolStripMenuItem;


        #region Common parameters
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        #endregion

        #region Main paltform
        public DataVisualization_2D()
        {
            InitializeComponent();
        }
        #endregion

        #region Data function
        private double[] GenerateRandomArray(double min, double max, int number)
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            double[] randomArray = new double[number];
            for (int i = 0; i < number;i++)
            {
                randomArray[i] = random.NextDouble() * (max - min) + min;
            }
            return randomArray;
        }
        private double[] GenerateDBArray()
        {
            MysqlHelper _mysqlHelper = null;
            // Filter: .doc and vaild file path
            if (null == _mysqlHelper)
            {
                _mysqlHelper = new MysqlHelper("Database='" + _database + "';" +
                                                "Data Source='" + _dataSource + "';" +
                                                "User Id='" + _userId + "';" +
                                                "Password='" + _password + "';" +
                                                "charset='" + _charset + "';" +
                                                "pooling=" + _pooling + "");
                if (null == _mysqlHelper.Conn)
                {
                    MessageBox.Show("Error: can not connect to mysql database.");
                    return null;
                }
            }
            string sqlFiles = "select id, value from data2d";
            DataTable dataTable = _mysqlHelper.ExecuteDataTable(sqlFiles, null);
            double[] array = new double[_number];
            int i = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                array[i++] = (double)row[1];
            }
            return array;
        }
        #endregion

        #region Random data
        private void randomDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            chart1.Series.Add(new Series("Series1"));
            chart1.Series.Add(new Series("Series2"));
            chart1.Series.Add(new Series("Series3"));
            double[] values1 = GenerateRandomArray(0, 100, 10);
            double[] values2 = GenerateRandomArray(0, 100, 10);
            double[] values3 = GenerateRandomArray(0, 100, 10);
            chart1.Series["Series1"].Points.DataBindY(values1);
            chart1.Series["Series2"].Points.DataBindY(values2);
            chart1.Series["Series3"].Points.DataBindY(values3);
        }
        #endregion

        #region Demo type
        private void updateComboBox(string[] selectTypes)
        {
            if (chart1.Series.Count <= 0)
            {
                MessageBox.Show("Please open or random data to visual.");
                return ;
            }
            comboBox1.Items.Clear();
            foreach (var sType in (SeriesChartType[])Enum.GetValues(typeof(SeriesChartType)))
            {
                foreach (var selectType in selectTypes)
                {
                    if (-1 != sType.ToString().IndexOf(selectType, StringComparison.OrdinalIgnoreCase))
                    {
                        if (false == sType.ToString().Equals("ErrorBar", StringComparison.OrdinalIgnoreCase) &&
                            false == sType.ToString().Equals("ThreeLineBreak", StringComparison.OrdinalIgnoreCase) &&
                            false == sType.ToString().Equals("PointAndFigure", StringComparison.OrdinalIgnoreCase)
                            )
                        {
                            this.comboBox1.Items.Add(sType.ToString());
                        }
                    }
                }
            }
            this.comboBox1.SelectedItem = this.comboBox1.Items[0];
        }

        private void barToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] selectTypes = new string[1];
            selectTypes[0] = "bar";
            updateComboBox(selectTypes);
        }
        
        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] selectTypes = new string[1];
            selectTypes[0] = "line";
            updateComboBox(selectTypes);
        }

        private void pointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] selectTypes = new string[2];
            selectTypes[0] = "point";
            selectTypes[1] = "bubble";
            updateComboBox(selectTypes);
        }

        private void pieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] selectTypes = new string[1];
            selectTypes[0] = "pie";
            updateComboBox(selectTypes);
        }

        private void areaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] selectTypes = new string[1];
            selectTypes[0] = "area";
            updateComboBox(selectTypes);
        }

        private void rangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] selectTypes = new string[1];
            selectTypes[0] = "range";
            updateComboBox(selectTypes);
        }

        private void circularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] selectTypes = new string[2];
            selectTypes[0] = "polar";
            selectTypes[1] = "radar";
            updateComboBox(selectTypes);
        }

        private void pyramidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] selectTypes = new string[2];
            selectTypes[0] = "pyramid";
            selectTypes[1] = "funnel";
            updateComboBox(selectTypes);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.chart1.Series["Series1"].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), comboBox1.SelectedItem.ToString());
            this.chart1.Series["Series2"].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), comboBox1.SelectedItem.ToString());
            this.chart1.Series["Series3"].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), comboBox1.SelectedItem.ToString());
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
            }
            else
            {
                chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            }
        }

        #endregion

        #region File ToDo
        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openfileDialog = new System.Windows.Forms.OpenFileDialog();
            if (openfileDialog.ShowDialog() == DialogResult.OK)
            {
                // TODO
            }
        }
        #endregion

        #region D3
        private void d3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChromeForm chrome = new ChromeForm();
            chrome.Show();
        }
        #endregion

        private void dBDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            chart1.Series.Add(new Series("Series1"));
            chart1.Series.Add(new Series("Series2"));
            chart1.Series.Add(new Series("Series3"));
            double[] values1 = GenerateDBArray();
            double[] values2 = GenerateRandomArray(0, 100, 10);
            double[] values3 = GenerateRandomArray(0, 100, 10);
            chart1.Series["Series1"].Points.DataBindY(values1);
            chart1.Series["Series2"].Points.DataBindY(values2);
            chart1.Series["Series3"].Points.DataBindY(values3);

        }
    }
}