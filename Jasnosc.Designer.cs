namespace WindowsFormsApplication1
{
    partial class Jasnosc
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
        	this.button1 = new System.Windows.Forms.Button();
        	this.pictureBox1 = new System.Windows.Forms.PictureBox();
        	this.trackBar1 = new System.Windows.Forms.TrackBar();
        	this.textBox1 = new System.Windows.Forms.TextBox();
        	((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// button1
        	// 
        	this.button1.Location = new System.Drawing.Point(115, 308);
        	this.button1.Name = "button1";
        	this.button1.Size = new System.Drawing.Size(87, 26);
        	this.button1.TabIndex = 0;
        	this.button1.Text = "OK";
        	this.button1.UseVisualStyleBackColor = true;
        	this.button1.Click += new System.EventHandler(this.button1_Click);
        	// 
        	// pictureBox1
        	// 
        	this.pictureBox1.Location = new System.Drawing.Point(54, 28);
        	this.pictureBox1.Name = "pictureBox1";
        	this.pictureBox1.Size = new System.Drawing.Size(198, 210);
        	this.pictureBox1.TabIndex = 2;
        	this.pictureBox1.TabStop = false;
        	// 
        	// trackBar1
        	// 
        	this.trackBar1.Location = new System.Drawing.Point(12, 257);
        	this.trackBar1.Maximum = 100;
        	this.trackBar1.Minimum = -100;
        	this.trackBar1.Name = "trackBar1";
        	this.trackBar1.Size = new System.Drawing.Size(268, 45);
        	this.trackBar1.TabIndex = 3;
        	this.trackBar1.Scroll += new System.EventHandler(this.TrackBar1Scroll);
        	// 
        	// textBox1
        	// 
        	this.textBox1.Location = new System.Drawing.Point(286, 266);
        	this.textBox1.Name = "textBox1";
        	this.textBox1.Size = new System.Drawing.Size(33, 20);
        	this.textBox1.TabIndex = 4;
        	// 
        	// Jasnosc
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(331, 349);
        	this.Controls.Add(this.textBox1);
        	this.Controls.Add(this.trackBar1);
        	this.Controls.Add(this.pictureBox1);
        	this.Controls.Add(this.button1);
        	this.Name = "Jasnosc";
        	this.Text = "Jasność";
        	((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
        	((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.PictureBox pictureBox1;

        #endregion

        private System.Windows.Forms.Button button1;
    }
}