using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Kontrast : Form
    {
    	//Bitmap Fbmp1;
    	Bitmap Sbmp;
    	
        public Kontrast()
        {
            InitializeComponent();
            
               this.textBox1.Text=this.trackBar1.Value.ToString();
            
            for (int i1 = 0; i1 < Application.OpenForms.Count; i1++)
        {
          Form f = Application.OpenForms[i1];
          if (f.IsMdiChild)
          	//if(f.Text.ToString()==comboBox2.SelectedItem.ToString())
          {
       
          	       ChildForm frmA = (ChildForm)f;
          	  Sbmp= frmA.Small_bmp(	this.pictureBox1.Height,	this.pictureBox1.Width);
          	  this.pictureBox1.Image=  Sbmp;
          	       
          }
          }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public double GetLevel { get { return (double)this.trackBar1.Value; } }
        
        void TrackBar1Scroll(object sender, EventArgs e)
        {
        	
        	Bitmap TempBmp;//= Sbmp;
        	TempBmp =new Bitmap(Sbmp);
          
        	this.textBox1.Text=trackBar1.Value.ToString();
        	Operacje op = new Operacje();
        	int contrast = (int)trackBar1.Value;
        	this.pictureBox1.Image =(op.Kontrast(Sbmp, null, null, contrast));
       	Sbmp=TempBmp;
        }
    }
}
