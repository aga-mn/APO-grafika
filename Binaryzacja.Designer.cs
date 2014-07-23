namespace WindowsFormsApplication1
{
    partial class Binaryzacja
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
        	this.textBox1 = new System.Windows.Forms.TextBox();
        	this.trackBar1 = new System.Windows.Forms.TrackBar();
        	((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// button1
        	// 
        	this.button1.Location = new System.Drawing.Point(87, 325);
        	this.button1.Name = "button1";
        	this.button1.Size = new System.Drawing.Size(120, 27);
        	this.button1.TabIndex = 3;
        	this.button1.Text = "OK";
        	this.button1.UseVisualStyleBackColor = true;
        	this.button1.Click += new System.EventHandler(this.button1_Click);
        	// 
        	// pictureBox1
        	// 
        	this.pictureBox1.Location = new System.Drawing.Point(49, 12);
        	this.pictureBox1.Name = "pictureBox1";
        	this.pictureBox1.Size = new System.Drawing.Size(217, 242);
        	this.pictureBox1.TabIndex = 4;
        	this.pictureBox1.TabStop = false;
        	// 
        	// textBox1
        	// 
        	this.textBox1.Location = new System.Drawing.Point(290, 283);
        	this.textBox1.Name = "textBox1";
        	this.textBox1.Size = new System.Drawing.Size(33, 20);
        	this.textBox1.TabIndex = 6;
        	// 
        	// trackBar1
        	// 
        	this.trackBar1.Location = new System.Drawing.Point(13, 274);
        	this.trackBar1.Maximum = 255;
        	this.trackBar1.Name = "trackBar1";
        	this.trackBar1.Size = new System.Drawing.Size(271, 45);
        	this.trackBar1.TabIndex = 7;
        	this.trackBar1.Value = 127;
        	this.trackBar1.Scroll += new System.EventHandler(this.TrackBar1Scroll);
        	// 
        	// Binaryzacja
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(334, 372);
        	this.Controls.Add(this.trackBar1);
        	this.Controls.Add(this.textBox1);
        	this.Controls.Add(this.pictureBox1);
        	this.Controls.Add(this.button1);
        	this.Name = "Binaryzacja";
        	this.Text = "Binaryzacja";
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