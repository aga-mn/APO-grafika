/*
 * Utworzone przez SharpDevelop.
 * Data: 2013-11-19
 * Godzina: 20:18
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
	/// <summary>
	/// Description of _2image.
	/// </summary>
	public partial class TwoImageForm : Form
	{
		
	Bitmap Fbmp1;
	Bitmap Fbmp2;
		public TwoImageForm()
		{
			
//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
	

		
		
		
		void TwoImageFormLoad(object sender, System.EventArgs e)
		{
			try
            {
       
 	
 	
 	 for (int i1 = 0; i1 < Application.OpenForms.Count; i1++)
        {
          Form f = Application.OpenForms[i1];
          if (f.IsMdiChild){
          	this.comboBox2.Items.Add(f.Text.ToString());
            this.comboBox3.Items.Add(f.Text.ToString());
          }
          	//MessageBox.Show(f.Text.ToString());
        }
          this.comboBox1.SelectedIndex=0;
            this.comboBox2.SelectedIndex=0;
                 this.comboBox3.SelectedIndex=0;
			
			}

            catch (System.Exception exp)
            {
                MessageBox.Show(exp.Message, this.Text);
            }
   
		}

		
		
		void Button1Click(object sender, EventArgs e)
		{


 try
            {
       
 	 ;

 
 	 for (int i1 = 0; i1 < Application.OpenForms.Count; i1++)
        {
          Form f = Application.OpenForms[i1];
          if (f.IsMdiChild)
          	if(f.Text.ToString()==comboBox2.SelectedItem.ToString())
          {
       
          	       ChildForm frmA = (ChildForm)f;
          	  this.pictureBox1.Image=     frmA.Small_bmp(	this.pictureBox1.Height,	this.pictureBox1.Width);
          	 Fbmp1=frmA.bmp;
          	       
          }
          }
        }
        
            

            catch (System.Exception exp)
            {
                MessageBox.Show(exp.Message, this.Text);
            }
   		
		}
		
		
		int   getOperacja(){
		

			 if (comboBox1.SelectedItem.ToString()=="AND") return 1;
				else if (comboBox1.SelectedItem.ToString()=="OR") return 2;
				else return 3;
			
		
		}
		
		void Button2Click(object sender, EventArgs e)
		{

 try
            {
       
 	 
 	 for (int i1 = 0; i1 < Application.OpenForms.Count; i1++)
        {
          Form f = Application.OpenForms[i1];
          if (f.IsMdiChild)
          	if(f.Text.ToString()==comboBox3.SelectedItem.ToString())
          {
       
          	       ChildForm frmA = (ChildForm)f;
          	  this.pictureBox2.Image=     frmA.Small_bmp(	this.pictureBox2.Height,	this.pictureBox2.Width);
          	                 	 Fbmp2=frmA.bmp;
          	       
          }
          }
        }
        
            

            catch (System.Exception exp)
            {
                MessageBox.Show(exp.Message, this.Text);
            }
   
  


			
			

		}
		
		void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			//MessageBox.Show("ComboBox1SelectedIndexChanged");
		}
		
		void ComboBox2SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//MessageBox.Show("ComboBox2SelectedIndexChanged");
			
			try           {
       
 	 ;

 
 	 for (int i1 = 0; i1 < Application.OpenForms.Count; i1++)
        {
          Form f = Application.OpenForms[i1];
          if (f.IsMdiChild)
          	if(f.Text.ToString()==comboBox2.SelectedItem.ToString())
          {
       
          	       ChildForm frmA = (ChildForm)f;
          	  this.pictureBox1.Image=     frmA.Small_bmp(	this.pictureBox1.Height,	this.pictureBox1.Width);
          	 Fbmp1=frmA.bmp;
          	       
          }
          }
        
			}
            

            catch (System.Exception exp)
            {
                MessageBox.Show(exp.Message, this.Text);
            }


		}
		
		
		void ComboBox3SelectedIndexChanged(object sender, EventArgs e)
		{
	//	MessageBox.Show("ComboBox3SelectedIndexChanged");


try
            {
       
 	 
 	 for (int i1 = 0; i1 < Application.OpenForms.Count; i1++)
        {
          Form f = Application.OpenForms[i1];
          if (f.IsMdiChild)
          	if(f.Text.ToString()==comboBox3.SelectedItem.ToString())
          {
       
          	       ChildForm frmA = (ChildForm)f;
          	  this.pictureBox2.Image=     frmA.Small_bmp(	this.pictureBox2.Height,	this.pictureBox2.Width);
          	                 	 Fbmp2=frmA.bmp;
          	       
          }
          }
        }
        
            

            catch (System.Exception exp)
            {
                MessageBox.Show(exp.Message, this.Text);
            }			
		
		}
		
		void Button3Click(object sender, EventArgs e)
		{
		 MainForm fparent=null;	
			
			for (int i1 = 0; i1 < Application.OpenForms.Count; i1++)
        {
          Form f = Application.OpenForms[i1];
          if(f.Name.ToString()=="MainForm")
 fparent = (MainForm)f;
          
			}
			
			
			ChildForm frm = new ChildForm();
               // intChild += 1;
                frm.MdiParent =fparent;
                frm.Text = "Child ";// + intChild;
                
                Operacje op=new Operacje();
               
                frm.create_new_window(op.Logiczne(Fbmp1, Fbmp2,getOperacja()), getOperacja());
                frm.Show();
			
		}
		
		
}
	



	
	}

