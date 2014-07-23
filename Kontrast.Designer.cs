namespace WindowsFormsApplication1
{
    partial class Kontrast
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
        	this.trackBar1 = new System.Windows.Forms.TrackBar();
        	this.pictureBox1 = new System.Windows.Forms.PictureBox();
        	this.textBox1 = new System.Windows.Forms.TextBox();
        	((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// button1
        	// 
        	this.button1.Location = new System.Drawing.Point(104, 311);
        	this.button1.Name = "button1";
        	this.button1.Size = new System.Drawing.Size(94, 30);
        	this.button1.TabIndex = 1;
        	this.button1.Text = "OK";
        	this.button1.UseVisualStyleBackColor = true;
        	this.button1.Click += new System.EventHandler(this.button1_Click);
        	// 
        	// trackBar1
        	// 
        	this.trackBar1.Location = new System.Drawing.Point(12, 260);
        	this.trackBar1.Maximum = 40;
        	this.trackBar1.Minimum = -40;
        	this.trackBar1.Name = "trackBar1";
        	this.trackBar1.Size = new System.Drawing.Size(253, 45);
        	this.trackBar1.TabIndex = 2;
        	this.trackBar1.Scroll += new System.EventHandler(this.TrackBar1Scroll);
        	// 
        	// pictureBox1
        	// 
        	this.pictureBox1.Location = new System.Drawing.Point(48, 29);
        	this.pictureBox1.Name = "pictureBox1";
        	this.pictureBox1.Size = new System.Drawing.Size(191, 215);
        	this.pictureBox1.TabIndex = 3;
        	this.pictureBox1.TabStop = false;
        	// 
        	// textBox1
        	// 
        	this.textBox1.Location = new System.Drawing.Point(260, 276);
        	this.textBox1.Name = "textBox1";
        	this.textBox1.Size = new System.Drawing.Size(28, 20);
        	this.textBox1.TabIndex = 4;
        	// 
        	// Kontrast
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(300, 353);
        	this.Controls.Add(this.textBox1);
        	this.Controls.Add(this.pictureBox1);
        	this.Controls.Add(this.trackBar1);
        	this.Controls.Add(this.button1);
        	this.Name = "Kontrast";
        	this.Text = "Kontrast";
        	((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
        	((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TrackBar trackBar1;

        #endregion

        private System.Windows.Forms.Button button1;
    }
}