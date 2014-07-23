namespace WindowsFormsApplication1
{
    partial class Rozciaganie
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
        	this.trackBar2 = new System.Windows.Forms.TrackBar();
        	this.textBox1 = new System.Windows.Forms.TextBox();
        	this.textBox2 = new System.Windows.Forms.TextBox();
        	this.pictureBox1 = new System.Windows.Forms.PictureBox();
        	((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// button1
        	// 
        	this.button1.Location = new System.Drawing.Point(70, 353);
        	this.button1.Name = "button1";
        	this.button1.Size = new System.Drawing.Size(75, 23);
        	this.button1.TabIndex = 4;
        	this.button1.Text = "OK";
        	this.button1.UseVisualStyleBackColor = true;
        	this.button1.Click += new System.EventHandler(this.button1_Click);
        	// 
        	// trackBar1
        	// 
        	this.trackBar1.Location = new System.Drawing.Point(12, 251);
        	this.trackBar1.Maximum = 255;
        	this.trackBar1.Name = "trackBar1";
        	this.trackBar1.Size = new System.Drawing.Size(206, 45);
        	this.trackBar1.TabIndex = 5;
        	this.trackBar1.Value = 127;
        	this.trackBar1.Scroll += new System.EventHandler(this.TrackBar1Scroll);
        	// 
        	// trackBar2
        	// 
        	this.trackBar2.Location = new System.Drawing.Point(12, 302);
        	this.trackBar2.Maximum = 255;
        	this.trackBar2.Name = "trackBar2";
        	this.trackBar2.Size = new System.Drawing.Size(205, 45);
        	this.trackBar2.TabIndex = 6;
        	this.trackBar2.Value = 127;
        	this.trackBar2.Scroll += new System.EventHandler(this.TrackBar2Scroll);
        	// 
        	// textBox1
        	// 
        	this.textBox1.Location = new System.Drawing.Point(212, 260);
        	this.textBox1.Name = "textBox1";
        	this.textBox1.Size = new System.Drawing.Size(30, 20);
        	this.textBox1.TabIndex = 7;
        	// 
        	// textBox2
        	// 
        	this.textBox2.Location = new System.Drawing.Point(212, 314);
        	this.textBox2.Name = "textBox2";
        	this.textBox2.Size = new System.Drawing.Size(30, 20);
        	this.textBox2.TabIndex = 8;
        	// 
        	// pictureBox1
        	// 
        	this.pictureBox1.Location = new System.Drawing.Point(46, 27);
        	this.pictureBox1.Name = "pictureBox1";
        	this.pictureBox1.Size = new System.Drawing.Size(159, 193);
        	this.pictureBox1.TabIndex = 9;
        	this.pictureBox1.TabStop = false;
        	// 
        	// Rozciaganie
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(247, 388);
        	this.Controls.Add(this.pictureBox1);
        	this.Controls.Add(this.textBox2);
        	this.Controls.Add(this.textBox1);
        	this.Controls.Add(this.trackBar2);
        	this.Controls.Add(this.trackBar1);
        	this.Controls.Add(this.button1);
        	this.Name = "Rozciaganie";
        	this.Text = "RozciaganieForm";
        	((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
        	((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
        	((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.TrackBar trackBar1;

        #endregion

        private System.Windows.Forms.Button button1;
    }
}