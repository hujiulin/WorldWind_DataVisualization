namespace DataVisualization_3D
{
    partial class DataVisualization_3D
    {
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eventWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renderWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wanderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xyzToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeLastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.demoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.earthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textEvents = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.renderWindowControl2 = new Kitware.VTK.RenderWindowControl();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.renderWindowControl1 = new Kitware.VTK.RenderWindowControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.renderWindowToolStripMenuItem,
            this.demoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(52, 21);
            this.OpenToolStripMenuItem.Text = "Open";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eventWindowToolStripMenuItem,
            this.dWindowToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // eventWindowToolStripMenuItem
            // 
            this.eventWindowToolStripMenuItem.Checked = true;
            this.eventWindowToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.eventWindowToolStripMenuItem.Name = "eventWindowToolStripMenuItem";
            this.eventWindowToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.eventWindowToolStripMenuItem.Text = "Event Window";
            this.eventWindowToolStripMenuItem.Click += new System.EventHandler(this.eventWindowToolStripMenuItem_Click);
            // 
            // dWindowToolStripMenuItem
            // 
            this.dWindowToolStripMenuItem.Checked = true;
            this.dWindowToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.dWindowToolStripMenuItem.Name = "dWindowToolStripMenuItem";
            this.dWindowToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.dWindowToolStripMenuItem.Text = "2D Window";
            this.dWindowToolStripMenuItem.Click += new System.EventHandler(this.dWindowToolStripMenuItem_Click);
            // 
            // renderWindowToolStripMenuItem
            // 
            this.renderWindowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backgroundColorToolStripMenuItem,
            this.resetToolStripMenuItem,
            this.wanderToolStripMenuItem,
            this.xyzToolStripMenuItem,
            this.removeLastToolStripMenuItem,
            this.clearToolStripMenuItem});
            this.renderWindowToolStripMenuItem.Name = "renderWindowToolStripMenuItem";
            this.renderWindowToolStripMenuItem.Size = new System.Drawing.Size(109, 21);
            this.renderWindowToolStripMenuItem.Text = "RenderWindow";
            // 
            // backgroundColorToolStripMenuItem
            // 
            this.backgroundColorToolStripMenuItem.Name = "backgroundColorToolStripMenuItem";
            this.backgroundColorToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.backgroundColorToolStripMenuItem.Text = "BackgroundColor";
            this.backgroundColorToolStripMenuItem.Click += new System.EventHandler(this.backgroundColorToolStripMenuItem_Click);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.resetToolStripMenuItem.Text = "ResetCamera";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // wanderToolStripMenuItem
            // 
            this.wanderToolStripMenuItem.Name = "wanderToolStripMenuItem";
            this.wanderToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.wanderToolStripMenuItem.Text = "Wander";
            this.wanderToolStripMenuItem.Click += new System.EventHandler(this.wanderToolStripMenuItem_Click);
            // 
            // xyzToolStripMenuItem
            // 
            this.xyzToolStripMenuItem.Name = "xyzToolStripMenuItem";
            this.xyzToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.xyzToolStripMenuItem.Text = "xyz";
            this.xyzToolStripMenuItem.Click += new System.EventHandler(this.xyzToolStripMenuItem_Click);
            // 
            // removeLastToolStripMenuItem
            // 
            this.removeLastToolStripMenuItem.Name = "removeLastToolStripMenuItem";
            this.removeLastToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.removeLastToolStripMenuItem.Text = "RemoveLast";
            this.removeLastToolStripMenuItem.Click += new System.EventHandler(this.removeLastToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // demoToolStripMenuItem
            // 
            this.demoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.earthToolStripMenuItem});
            this.demoToolStripMenuItem.Name = "demoToolStripMenuItem";
            this.demoToolStripMenuItem.Size = new System.Drawing.Size(55, 21);
            this.demoToolStripMenuItem.Text = "Demo";
            // 
            // earthToolStripMenuItem
            // 
            this.earthToolStripMenuItem.Name = "earthToolStripMenuItem";
            this.earthToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.earthToolStripMenuItem.Text = "Earth";
            this.earthToolStripMenuItem.Click += new System.EventHandler(this.earthToolStripMenuItem_Click);
            // 
            // textEvents
            // 
            this.textEvents.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textEvents.Location = new System.Drawing.Point(0, 419);
            this.textEvents.Multiline = true;
            this.textEvents.Name = "textEvents";
            this.textEvents.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textEvents.Size = new System.Drawing.Size(784, 143);
            this.textEvents.TabIndex = 5;
            this.textEvents.WordWrap = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.renderWindowControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 394);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.renderWindowControl2);
            this.panel2.Controls.Add(this.trackBar1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(457, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(327, 394);
            this.panel2.TabIndex = 1;
            // 
            // renderWindowControl2
            // 
            this.renderWindowControl2.AddTestActors = false;
            this.renderWindowControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.renderWindowControl2.Location = new System.Drawing.Point(0, 0);
            this.renderWindowControl2.Name = "renderWindowControl2";
            this.renderWindowControl2.Size = new System.Drawing.Size(327, 349);
            this.renderWindowControl2.TabIndex = 3;
            this.renderWindowControl2.TestText = null;
            // 
            // trackBar1
            // 
            this.trackBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.trackBar1.Location = new System.Drawing.Point(0, 349);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(327, 45);
            this.trackBar1.TabIndex = 4;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // renderWindowControl1
            // 
            this.renderWindowControl1.AddTestActors = false;
            this.renderWindowControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.renderWindowControl1.Location = new System.Drawing.Point(0, 0);
            this.renderWindowControl1.Name = "renderWindowControl1";
            this.renderWindowControl1.Size = new System.Drawing.Size(451, 394);
            this.renderWindowControl1.TabIndex = 0;
            this.renderWindowControl1.TestText = null;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainPaltform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textEvents);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainPaltform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DataVisualization_3D";
            this.Load += new System.EventHandler(this.MainPaltform_Load);
            this.SizeChanged += new System.EventHandler(this.MainPaltform_SizeChanged);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainPaltform_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainPaltform_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eventWindowToolStripMenuItem;
        public System.Windows.Forms.TextBox textEvents;
        private System.Windows.Forms.Panel panel1;
        private Kitware.VTK.RenderWindowControl renderWindowControl1;
        public System.Windows.Forms.Panel panel2;
        private Kitware.VTK.RenderWindowControl renderWindowControl2;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem dWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renderWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backgroundColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wanderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeLastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem demoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem earthToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xyzToolStripMenuItem;
    }
}

