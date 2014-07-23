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
    public partial class Rozciaganie : Form
    {
    	//Bitmap Fbmp1;
    	Bitmap Sbmp;
    	
        public Rozciaganie()
        {
            InitializeComponent();
            
                this.textBox1.Text=this.trackBar1.Value.ToString();
                this.textBox2.Text=this.trackBar2.Value.ToString();
            
            for (int i1 = 0; i1 < Application.OpenForms.Count; i1++)
        {
          Form f = Application.OpenForms[i1];
          if (f.IsMdiChild)
          	//if(f.Text.ToString()==comboBox2.SelectedItem.ToString())
          {
       
          	       ChildForm frmA = (ChildForm)f;
          	 Sbmp=     frmA.Small_bmp(	this.pictureBox1.Height,	this.pictureBox1.Width);
          	  this.pictureBox1.Image=  Sbmp;
          	       
          }
          }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public int GetP1 { get { return (int)this.trackBar1.Value; } }
        public int GetP2 { get { return (int)this.trackBar2.Value; } }
        
        void TrackBar1Scroll(object sender, EventArgs e)
        {
        	Bitmap TempBmp;//= Sbmp;
        	TempBmp =new Bitmap(Sbmp);
          
        	this.textBox1.Text=trackBar1.Value.ToString();
        	Operacje op = new Operacje();
        	int p1 = (int)trackBar1.Value;
        	int p2 = (int)trackBar2.Value;
        	this.pictureBox1.Image =(op.Rozciaganie(Sbmp, null, null, p1, p2));
       	Sbmp=TempBmp;
        }
        
        void TrackBar2Scroll(object sender, EventArgs e)
        {
        	Bitmap TempBmp;//= Sbmp;
        	TempBmp =new Bitmap(Sbmp);
        		this.textBox2.Text=trackBar1.Value.ToString();
        	Operacje op = new Operacje();
        	int p1 = (int)trackBar1.Value;
        	int p2 = (int)trackBar2.Value;
        	this.pictureBox1.Image =(op.Rozciaganie(Sbmp, null, null, p1, p2));
       	Sbmp=TempBmp;
        }
    }
}
