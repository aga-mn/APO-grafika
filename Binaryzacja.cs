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
    public partial class Binaryzacja : Form
    {
    	//Bitmap Fbmp1;
    	Bitmap Sbmp;
    	//Bitmap TempBmp;
    	//Bitmap Fbmp2;
    	
        public Binaryzacja()
        {
            InitializeComponent();
            
               for (int i1 = 0; i1 < Application.OpenForms.Count; i1++)
        {
          Form f = Application.OpenForms[i1];
          if (f.IsMdiChild)
          	//if(f.Text.ToString()==comboBox2.SelectedItem.ToString())
          {
       
          	       ChildForm frmA = (ChildForm)f;
          	       Sbmp= frmA.Small_bmp(	this.pictureBox1.Height,	this.pictureBox1.Width);
          	  this.pictureBox1.Image=  Sbmp;
          	// Fbmp1=frmA.bmp;
          	       
          }
          this.textBox1.Text=this.trackBar1.Value.ToString();
          }
        }

        public int Threshold { get {return (int)this.trackBar1.Value;} }

        private void button1_Click(object sender, EventArgs e)
        {
           // int threshold = (int)this.NumUD.Value;
         
           
            this.Close();
        }

        public void Redraw() {
           
            //bmpModified.Draw(graphicsModified, 0, 0);
        }
        
        
        
        
        
        void TrackBar1Scroll(object sender, EventArgs e)
        {
        	Bitmap TempBmp;//= Sbmp;
        	TempBmp =new Bitmap(Sbmp);
          
        	this.textBox1.Text=trackBar1.Value.ToString();
        	Operacje op = new Operacje();
        	int threshold = (int)trackBar1.Value;
        	this.pictureBox1.Image =(op.Binaryzacja(Sbmp, null, null, threshold));
       	Sbmp=TempBmp;
        		
        }
    }
}
