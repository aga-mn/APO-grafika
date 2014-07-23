/*
 * Utworzone przez SharpDevelop.
 * Data: 2013-12-05
 * Godzina: 10:48
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;

namespace WindowsFormsApplication1
{
	/// <summary>
	/// Description of Form1.
	/// </summary>
	public partial class PixTabForm : Form
	{
		public PixTabForm ()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		  public void ReloadPixTabForm(Bitmap bmp)
        {

           


            DataTable dt = new DataTable();
      
        
         MessageBox.Show(bmp.Height.ToString()+" "+bmp.Width.ToString());
          
           for (int i = 0; i < bmp.Width; i++)
                {
           	dt.Columns.Add(i.ToString(),typeof(string));
           }
           
//int heighg=65000/ bmp.Width.ToString(); 
           for (int i = 0; i <bmp.Height; i++){
           	
           	dt.Rows.Add();
           }
        
          
            for (int j = 0; j < bmp.Width; j++){
           for (int i = 0; i <bmp.Height; i++){
       
          	 try
            {
          	 	dt.Rows[i][j]=bmp.GetPixel(j,i).R.ToString();
          	  }

            catch (System.Exception exp)
            {
                MessageBox.Show(exp.Message, this.Text);
            }
	
		  }
          	
          }
	     this.dataGridView1.DataSource = dt;
           
            
        

            
        }
        
	}
}
