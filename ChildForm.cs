using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace WindowsFormsApplication1
{
    public partial class ChildForm : Form
    {
        public ChildForm()
        {
            InitializeComponent();
        }
       public Bitmap bmp;
       public MyFBitmap Fbmp;

       public void reload_bmp(Bitmap bmp1)
       {

           pictureBox1.Image = bmp1;
           pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
           this.bmp = bmp1;
       }

public void reload_position(string what){

    if (what=="autosize")
    pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;

    if (what == "centerImage")
        pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;

    if (what == "stretchImage")
        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

}

public int open_dialog_window()
{
    OpenFileDialog odlgImage = new OpenFileDialog();
    //odlgImage.InitialDirectory = "C:\\";
  
    
   
    odlgImage.InitialDirectory= ((MainForm) MdiParent).pathName;
    odlgImage.Filter = "All Image Formats (*.bmp;*.jpg;*.jpeg;*.gif;*.tif)|" +
        "*.bmp;*.jpg;*.jpeg;*.gif;*.tif|Bitmaps (*.bmp)|*.bmp|" +
        "GIFs (*.gif)|*.gif|JPEGs (*.jpg)|*.jpg;*.jpeg|TIFs (*.tif)|*.tif";
    odlgImage.FilterIndex = 1;


    if (odlgImage.ShowDialog() == DialogResult.OK)
    {
        bmp = new Bitmap(odlgImage.FileName);
        Fbmp=new MyFBitmap(bmp);
        pictureBox1.Image = bmp;
        pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
  
        //optNormal.Checked = true;
        this.Text = odlgImage.FileName;
        
       ((MainForm) MdiParent).pathName= Path.GetDirectoryName(odlgImage.FileName);
    }
    
    if(odlgImage.FileName.Length==0) {return 0;}
    else {return 1;}
    
}




public void create_new_window(Bitmap bmp1, int op)
{
   
        bmp = new Bitmap(bmp1);
       
        Fbmp=new MyFBitmap(bmp);
        pictureBox1.Image = bmp;
        pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
  
        
        string oper;
        switch(op)
        {
        case 1: oper="AND"; break;
       case 2: oper="OR"; break;
      case 3: oper="XOR"; break;
     default: oper=""; break;
        }
        //optNormal.Checked = true;
        this.Text = "Operacja logiczna " + oper; //odlgImage.FileName;
        
        
       
       
        
    
}



public Bitmap Small_bmp(int width,int height)
{
    
	
Bitmap bitmap = new Bitmap(width, height);
 
Graphics graphics = Graphics.FromImage(bitmap);
graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
 
Rectangle imageRectangle = new Rectangle(0, 0, width, height);
graphics.DrawImage(bmp, imageRectangle);
 
graphics.Dispose();
//bitmap.Dispose();
return bitmap;
}


private void Fit()
{
    // if Fit was called by the Zoom In button, then center the image. This is
    // only needed when working with images that are smaller than the PictureBox.
    // Feel free to uncomment the line that sets the SizeMode and then see how
    // it causes Zoom In for small images to show unexpected behavior.

    if ((pictureBox1.Image.Width < pictureBox1.Width) &&
        (pictureBox1.Image.Height < pictureBox1.Height))
    {
       
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
        
    }
    CalculateAspectRatioAndSetDimensions();
}

// Calculates and returns the image's aspect ratio, and sets 
// its proper dimensions. This is used for Fit() and for saving thumbnails
// of images.
private double CalculateAspectRatioAndSetDimensions()
{
    // Calculate the proper aspect ratio and set the image's dimensions.
    double ratio;

    if (pictureBox1.Image.Width > pictureBox1.Image.Height)
    {
        ratio = pictureBox1.Image.Width / pictureBox1.Image.Height;
        pictureBox1.Height = Convert.ToInt32(Convert.ToDouble(pictureBox1.Width) / ratio);
    }
    else
    {
        ratio = pictureBox1.Image.Height / pictureBox1.Image.Width;
        pictureBox1.Width = Convert.ToInt32(Convert.ToDouble(pictureBox1.Height) / ratio);
    }
    return ratio;
}


public void reload_zoom(int what)
{

    
    // When zooming in or out the SizeMode controls are disabled or the zooming
    // doesn't work anticipated. This check ensures that the initial Zoom in 
    // transition is smooth. Without this, if the SizeMode = something other
    // than AutoSize, the image can appear to get smaller on the first click, 
    // and then begin zooming in, which is not expected behavior.
   
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
   
        // Set UI and UI flags.
        
   
  
        // StretchMode works best for zooming. When Zooming In, the SizeMode should 
        // be set prior to calling Fit(). The reason for this becomes apparent only
        // when loading images that are smaller than the PictureBox dimensions.
        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        // Zoom works best if you first fit the image according to its true aspect 
        // ratio.
        Fit();
        // Make the PictureBox dimensions larger by 25% to effect the Zoom.
        pictureBox1.Width = Convert.ToInt32(pictureBox1.Width * 1.25);
        pictureBox1.Height = Convert.ToInt32(pictureBox1.Height * 1.25);
     



}



        

      /*  private void ChildForm_Load(object sender, EventArgs e)
        {
           
                 OpenFileDialog odlgImage= new OpenFileDialog(); 
            odlgImage.InitialDirectory = "C:\\";
        odlgImage.Filter = "All Image Formats (*.bmp;*.jpg;*.jpeg;*.gif;*.tif)|" + 
            "*.bmp;*.jpg;*.jpeg;*.gif;*.tif|Bitmaps (*.bmp)|*.bmp|" + 
            "GIFs (*.gif)|*.gif|JPEGs (*.jpg)|*.jpg;*.jpeg|TIFs (*.tif)|*.tif";
        odlgImage.FilterIndex = 1;

        
        if (odlgImage.ShowDialog() == DialogResult.OK) 
		{
            bmp = new Bitmap(odlgImage.FileName);
            pictureBox1.Image = bmp;
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            //optNormal.Checked = true;
            this.Text = odlgImage.FileName;
        }

        //Rectangle recSource = new Rectangle(0, 0, pictureBox1.Image.Width, pictureBox1.Image.Height);

     //  Bitmap bmpCropped = new Bitmap(pictureBox1.Image.Width, pictureBox1.Image.Height);
        // Get a Graphics object from the Bitmap for drawing.
       // Graphics grBitmap = Graphics.FromImage(bmpCropped);
        // Draw the image on the Bitmap anchored at the upper left corner.
       // grBitmap.DrawImage(pictureBox1.Image, 0, 0);
        // Set the PictureBox image to the new cropped image.
       //pictureBox1.Image = bmpCropped;       
     //   pictureBox1.Image = bmpCropped; 

        }
       * */
        
        void ChildFormLoad(object sender, EventArgs e)
        {
       
        //	MessageBox.Show(	((MainForm) MdiParent).Name.ToString());
        MainForm a;
        a=((MainForm) MdiParent);
        if(a != null)
        	a.EnableMenu();
        }
    
            void ChildFormClosed(object sender, EventArgs e)
        {
       int count=-1;
            //	MessageBox.Show(Application.OpenForms.Count.ToString());
            	
            	
            		    for (int i1 = 0; i1 < Application.OpenForms.Count; i1++)
        {
          Form f = Application.OpenForms[i1];
        
        if (f.IsMdiChild)
        	count++;
            		    }
            	if( count==0){
            	
            	((MainForm) MdiParent).disableMenu();
            	}
      
            		  //  MessageBox.Show(count.ToString());
            }
    
    
    
    }
}
