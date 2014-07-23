/*
 * Utworzone przez SharpDevelop.
 * Data: 2013-11-05
 * Godzina: 16:32
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
	/// <summary>
	/// Description of Maska.
	/// </summary>
	public partial class Maska : Form
	{
		
		Bitmap Sbmp;
		
		public Maska()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			this.textBox1.Text="0";
			this.radioButton1.Checked=true;
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
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
		
		void Button1Click(object sender, EventArgs e)
		{
			this.Close();
		}
		
		public int[,] GetMask
			
		{
			get{
			
				int[,] mask={{(int)m1.Value, (int)m2.Value, (int)m3.Value},
					{(int)m4.Value, (int)m5.Value, (int)m6.Value},
					{(int)m7.Value, (int)m8.Value, (int)m9.Value}};
				
				return mask;
			}
		}
		
		public int GetSkrajne
		{
			get {if (this.radioButton1.Checked==true) return 1;
				else return 2;
			}
		
		
		}
			
				
		void M1ValueChanged(object sender, EventArgs e)
		{
			textBox1.Text=(m1.Value+m2.Value+m3.Value+m4.Value+m5.Value+m6.Value+m7.Value+m8.Value+m9.Value).ToString() ;
		}
		
		void M2ValueChanged(object sender, EventArgs e)
		{
			textBox1.Text=(m1.Value+m2.Value+m3.Value+m4.Value+m5.Value+m6.Value+m7.Value+m8.Value+m9.Value).ToString() ;			
		}
		
		void M3ValueChanged(object sender, EventArgs e)
		{
			textBox1.Text=(m1.Value+m2.Value+m3.Value+m4.Value+m5.Value+m6.Value+m7.Value+m8.Value+m9.Value).ToString() ;			
		}
		
		void M4ValueChanged(object sender, EventArgs e)
		{
			textBox1.Text=(m1.Value+m2.Value+m3.Value+m4.Value+m5.Value+m6.Value+m7.Value+m8.Value+m9.Value).ToString() ;			
		}
		
		void M5ValueChanged(object sender, EventArgs e)
		{
			textBox1.Text=(m1.Value+m2.Value+m3.Value+m4.Value+m5.Value+m6.Value+m7.Value+m8.Value+m9.Value).ToString() ;			
		}
		
		void M6ValueChanged(object sender, EventArgs e)
		{
			textBox1.Text=(m1.Value+m2.Value+m3.Value+m4.Value+m5.Value+m6.Value+m7.Value+m8.Value+m9.Value).ToString() ;			
		}
		
		void M7ValueChanged(object sender, EventArgs e)
		{
			textBox1.Text=(m1.Value+m2.Value+m3.Value+m4.Value+m5.Value+m6.Value+m7.Value+m8.Value+m9.Value).ToString() ;			
		}
		
		void M8ValueChanged(object sender, EventArgs e)
		{
			textBox1.Text=(m1.Value+m2.Value+m3.Value+m4.Value+m5.Value+m6.Value+m7.Value+m8.Value+m9.Value).ToString() ;			
		}
		
		void M9ValueChanged(object sender, EventArgs e)
		{
			textBox1.Text=(m1.Value+m2.Value+m3.Value+m4.Value+m5.Value+m6.Value+m7.Value+m8.Value+m9.Value).ToString() ;			
		}
		
		void Button2Click(object sender, EventArgs e)
		{
				Bitmap TempBmp;//= Sbmp;
        	TempBmp =new Bitmap(Sbmp);
          
        	//this.textBox1.Text=trackBar1.Value.ToString();
        	Operacje op = new Operacje();
        	int[,] maska = this.GetMask;
        	int skrajne=this.GetSkrajne;
        	this.pictureBox1.Image =(op.Filtracja(Sbmp, null, null, maska, skrajne));
     	  	Sbmp=TempBmp;
       	
		}
	}
}
