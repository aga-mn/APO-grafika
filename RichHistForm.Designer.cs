namespace WindowsFormsApplication1
{
    partial class RichHistForm
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
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RichHistForm));
        	this.splitContainer1 = new System.Windows.Forms.SplitContainer();
        	this.hBarChart1 = new BarChart.HBarChart();
        	this.splitContainer2 = new System.Windows.Forms.SplitContainer();
        	this.dataGridView1 = new System.Windows.Forms.DataGridView();
        	this.groupBoxSizing = new System.Windows.Forms.GroupBox();
        	this.trackBarWidthBar = new System.Windows.Forms.TrackBar();
        	this.labelGapValue = new System.Windows.Forms.Label();
        	this.trackBarGap = new System.Windows.Forms.TrackBar();
        	this.labelBarWidthValue = new System.Windows.Forms.Label();
        	this.pictureBox1 = new System.Windows.Forms.PictureBox();
        	((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
        	this.splitContainer1.Panel1.SuspendLayout();
        	this.splitContainer1.Panel2.SuspendLayout();
        	this.splitContainer1.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
        	this.splitContainer2.Panel1.SuspendLayout();
        	this.splitContainer2.Panel2.SuspendLayout();
        	this.splitContainer2.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
        	this.groupBoxSizing.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.trackBarWidthBar)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.trackBarGap)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// splitContainer1
        	// 
        	this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.splitContainer1.Location = new System.Drawing.Point(0, 0);
        	this.splitContainer1.Name = "splitContainer1";
        	this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
        	// 
        	// splitContainer1.Panel1
        	// 
        	this.splitContainer1.Panel1.AutoScroll = true;
        	this.splitContainer1.Panel1.Controls.Add(this.hBarChart1);
        	this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
        	// 
        	// splitContainer1.Panel2
        	// 
        	this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
        	this.splitContainer1.Size = new System.Drawing.Size(794, 541);
        	this.splitContainer1.SplitterDistance = 385;
        	this.splitContainer1.TabIndex = 0;
        	// 
        	// hBarChart1
        	// 
        	this.hBarChart1.AutoScroll = true;
        	this.hBarChart1.AutoSize = true;
        	this.hBarChart1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        	this.hBarChart1.Background.GradientColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(210)))), ((int)(((byte)(245)))));
        	this.hBarChart1.Background.GradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(30)))), ((int)(((byte)(90)))));
        	this.hBarChart1.Background.PaintingMode = BarChart.CBackgroundProperty.PaintingModes.RadialGradient;
        	this.hBarChart1.Background.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(30)))), ((int)(((byte)(90)))));
        	this.hBarChart1.BarsGap = 4;
        	this.hBarChart1.BarWidth = 24;
        	this.hBarChart1.Border.BoundRect = ((System.Drawing.RectangleF)(resources.GetObject("resource.BoundRect")));
        	this.hBarChart1.Border.Color = System.Drawing.Color.White;
        	this.hBarChart1.Border.Visible = true;
        	this.hBarChart1.Border.Width = 1;
        	this.hBarChart1.Description.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
        	this.hBarChart1.Description.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
        	this.hBarChart1.Description.FontDefaultSize = 14F;
        	this.hBarChart1.Description.Text = "";
        	this.hBarChart1.Description.Visible = true;
        	this.hBarChart1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.hBarChart1.Items.DefaultWidth = 0;
        	this.hBarChart1.Items.DrawingMode = BarChart.HBarItems.DrawingModes.Glass;
        	this.hBarChart1.Items.ShouldReCalculate = false;
        	this.hBarChart1.Label.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
        	this.hBarChart1.Label.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
        	this.hBarChart1.Label.FontDefaultSize = 8F;
        	this.hBarChart1.Label.Visible = true;
        	this.hBarChart1.Location = new System.Drawing.Point(0, 0);
        	this.hBarChart1.Margin = new System.Windows.Forms.Padding(13);
        	this.hBarChart1.Name = "hBarChart1";
        	this.hBarChart1.Padding = new System.Windows.Forms.Padding(10);
        	this.hBarChart1.Shadow.ColorInner = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        	this.hBarChart1.Shadow.ColorOuter = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        	this.hBarChart1.Shadow.Mode = BarChart.CShadowProperty.Modes.Inner;
        	this.hBarChart1.Shadow.WidthInner = 5;
        	this.hBarChart1.Shadow.WidthOuter = 5;
        	this.hBarChart1.Size = new System.Drawing.Size(794, 385);
        	this.hBarChart1.SizingMode = BarChart.HBarChart.BarSizingMode.Normal;
        	this.hBarChart1.TabIndex = 2;
        	this.hBarChart1.Values.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
        	this.hBarChart1.Values.Font = new System.Drawing.Font("Tahoma", 7F);
        	this.hBarChart1.Values.FontDefaultSize = 7F;
        	this.hBarChart1.Values.Mode = BarChart.CValueProperty.ValueMode.Digit;
        	this.hBarChart1.Values.Visible = true;
        	// 
        	// splitContainer2
        	// 
        	this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.splitContainer2.Location = new System.Drawing.Point(0, 0);
        	this.splitContainer2.Name = "splitContainer2";
        	this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
        	// 
        	// splitContainer2.Panel1
        	// 
        	this.splitContainer2.Panel1.Controls.Add(this.dataGridView1);
        	// 
        	// splitContainer2.Panel2
        	// 
        	this.splitContainer2.Panel2.Controls.Add(this.pictureBox1);
        	this.splitContainer2.Panel2.Controls.Add(this.groupBoxSizing);
        	this.splitContainer2.Size = new System.Drawing.Size(794, 152);
        	this.splitContainer2.SplitterDistance = 79;
        	this.splitContainer2.TabIndex = 0;
        	// 
        	// dataGridView1
        	// 
        	this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.dataGridView1.Location = new System.Drawing.Point(0, 0);
        	this.dataGridView1.Name = "dataGridView1";
        	this.dataGridView1.Size = new System.Drawing.Size(794, 79);
        	this.dataGridView1.TabIndex = 35;
        	// 
        	// groupBoxSizing
        	// 
        	this.groupBoxSizing.Controls.Add(this.trackBarWidthBar);
        	this.groupBoxSizing.Controls.Add(this.labelGapValue);
        	this.groupBoxSizing.Controls.Add(this.trackBarGap);
        	this.groupBoxSizing.Controls.Add(this.labelBarWidthValue);
        	this.groupBoxSizing.Location = new System.Drawing.Point(24, 3);
        	this.groupBoxSizing.Name = "groupBoxSizing";
        	this.groupBoxSizing.Size = new System.Drawing.Size(247, 62);
        	this.groupBoxSizing.TabIndex = 31;
        	this.groupBoxSizing.TabStop = false;
        	this.groupBoxSizing.Text = "Bars";
        	// 
        	// trackBarWidthBar
        	// 
        	this.trackBarWidthBar.AutoSize = false;
        	this.trackBarWidthBar.LargeChange = 1;
        	this.trackBarWidthBar.Location = new System.Drawing.Point(79, 33);
        	this.trackBarWidthBar.Maximum = 100;
        	this.trackBarWidthBar.Minimum = 1;
        	this.trackBarWidthBar.Name = "trackBarWidthBar";
        	this.trackBarWidthBar.Size = new System.Drawing.Size(106, 23);
        	this.trackBarWidthBar.TabIndex = 3;
        	this.trackBarWidthBar.TickFrequency = 0;
        	this.trackBarWidthBar.Value = 3;
        	this.trackBarWidthBar.Scroll += new System.EventHandler(this.trackBarWidthBar_Scroll_1);
        	// 
        	// labelGapValue
        	// 
        	this.labelGapValue.AutoSize = true;
        	this.labelGapValue.Location = new System.Drawing.Point(3, 16);
        	this.labelGapValue.Name = "labelGapValue";
        	this.labelGapValue.Size = new System.Drawing.Size(60, 13);
        	this.labelGapValue.TabIndex = 0;
        	this.labelGapValue.Text = "Gap size(0)";
        	// 
        	// trackBarGap
        	// 
        	this.trackBarGap.AutoSize = false;
        	this.trackBarGap.LargeChange = 1;
        	this.trackBarGap.Location = new System.Drawing.Point(79, 10);
        	this.trackBarGap.Maximum = 20;
        	this.trackBarGap.Name = "trackBarGap";
        	this.trackBarGap.Size = new System.Drawing.Size(106, 23);
        	this.trackBarGap.TabIndex = 1;
        	this.trackBarGap.TickFrequency = 0;
        	this.trackBarGap.Scroll += new System.EventHandler(this.trackBarGap_Scroll_2);
        	// 
        	// labelBarWidthValue
        	// 
        	this.labelBarWidthValue.AutoSize = true;
        	this.labelBarWidthValue.Location = new System.Drawing.Point(4, 39);
        	this.labelBarWidthValue.Name = "labelBarWidthValue";
        	this.labelBarWidthValue.Size = new System.Drawing.Size(66, 13);
        	this.labelBarWidthValue.TabIndex = 2;
        	this.labelBarWidthValue.Text = "Bar Width(3)";
        	// 
        	// pictureBox1
        	// 
        	this.pictureBox1.Location = new System.Drawing.Point(363, 5);
        	this.pictureBox1.Name = "pictureBox1";
        	this.pictureBox1.Size = new System.Drawing.Size(199, 60);
        	this.pictureBox1.TabIndex = 32;
        	this.pictureBox1.TabStop = false;
        	this.pictureBox1.Click += new System.EventHandler(this.PictureBox1Click);
        	// 
        	// RichHistForm
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(794, 541);
        	this.Controls.Add(this.splitContainer1);
        	this.Name = "RichHistForm";
        	this.Text = "RichHistForm";
        	this.splitContainer1.Panel1.ResumeLayout(false);
        	this.splitContainer1.Panel1.PerformLayout();
        	this.splitContainer1.Panel2.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
        	this.splitContainer1.ResumeLayout(false);
        	this.splitContainer2.Panel1.ResumeLayout(false);
        	this.splitContainer2.Panel2.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
        	this.splitContainer2.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
        	this.groupBoxSizing.ResumeLayout(false);
        	this.groupBoxSizing.PerformLayout();
        	((System.ComponentModel.ISupportInitialize)(this.trackBarWidthBar)).EndInit();
        	((System.ComponentModel.ISupportInitialize)(this.trackBarGap)).EndInit();
        	((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
        	this.ResumeLayout(false);
        }
        private System.Windows.Forms.PictureBox pictureBox1;

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private BarChart.HBarChart hBarChart1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TrackBar trackBarWidthBar;
        private System.Windows.Forms.Label labelBarWidthValue;
        private System.Windows.Forms.Label labelGapValue;
        private System.Windows.Forms.TrackBar trackBarGap;
        private System.Windows.Forms.GroupBox groupBoxSizing;





    }
}