using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
namespace WindowsFormsApplication1
{
    public partial class MainForm : Form
    {
        public int intChild;
        public string pathName="C:\\";
        
        public string PathName {get {return this.pathName;}
        	set {this.pathName=value;}
        }
        
        public MainForm()
        {
            InitializeComponent();
        }

          public void EnableMenu()
    {
          toolsToolStripMenuItem.Enabled=true;
        	operacjeToolStripMenuItem.Enabled=true;
        	viewToolStripMenuItem.Enabled=true;
        	windowToolStripMenuItem.Enabled=true;
    }
        
                  public void disableMenu()
    {
          toolsToolStripMenuItem.Enabled=false;
        	operacjeToolStripMenuItem.Enabled=false;
        	viewToolStripMenuItem.Enabled=false;
        	windowToolStripMenuItem.Enabled=false;
    }
        
 
                public int isdisableMenu()
    {
                	if(toolsToolStripMenuItem.Enabled&&operacjeToolStripMenuItem.Enabled&&	viewToolStripMenuItem.Enabled&&windowToolStripMenuItem.Enabled)
                	return 0;
else return 1;                	
     

    }
                  
          
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
            	
                ChildForm frm = new ChildForm();
                intChild += 1;
                frm.MdiParent = this;
                frm.Text = "Child " + intChild;
                if(  frm.open_dialog_window()==1)
               
               // frm.RestoreCurrentDirectory = false;  
              
               
                {  frm.Show();}
                else {frm.Dispose();}
     
            }

            catch (System.Exception exp)
            {
                MessageBox.Show(exp.Message, this.Text);
            }
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void windowToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void autosizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //chil = (ChildForm)this.ActiveMdiChild;
        
             ChildForm frmActiveNewDocument = (ChildForm)this.ActiveMdiChild;
             frmActiveNewDocument.reload_position("autosize");
        }

        private void centerImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildForm frmActiveNewDocument = (ChildForm)this.ActiveMdiChild;
            frmActiveNewDocument.reload_position("centerImage");
        }

        private void stretchImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildForm frmActiveNewDocument = (ChildForm)this.ActiveMdiChild;
            frmActiveNewDocument.reload_position("stretchImage");
        }

        private void zoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildForm frmActiveNewDocument = (ChildForm)this.ActiveMdiChild;
            frmActiveNewDocument.reload_zoom(1);
        }

        private void zoomToolStripMenuItem1_Click(object sender, EventArgs e)
        {


            
        }

        private void grayScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Operacje op = new Operacje();
            ChildForm frmActiveNewDocument = (ChildForm)this.ActiveMdiChild;
            Bitmap bmp1 = frmActiveNewDocument.bmp;
            frmActiveNewDocument.reload_bmp(op.GrayScale (bmp1, toolStripStatusLabel1, toolStripProgressBar1));
            frmActiveNewDocument.reload_position("centerImage");

        }


       
        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                ChildForm frmActiveNewDocument = (ChildForm)this.ActiveMdiChild;
                Bitmap bmp1 = frmActiveNewDocument.bmp;

                Histogram his = new Histogram(bmp1);
                RichHistForm frmH = new RichHistForm();
                frmH.MdiParent = this;
                frmH.Show();
                frmH.AddSmallImg(frmActiveNewDocument.Small_bmp(100,100));

             frmH.ReloadHist(his);  
                

            }

            catch (System.Exception exp)
            {
                MessageBox.Show(exp.Message, this.Text);
            }


        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutProgram box = new AboutProgram();
            box.ShowDialog();
        }

        private void duplicateToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
            ChildForm frmActiveNewDocument = (ChildForm)this.ActiveMdiChild;
            Bitmap bmp1 = frmActiveNewDocument.bmp;
         
            
                ChildForm frm = new ChildForm();
                intChild += 1;
                frm.MdiParent = this;
                frm.Text = "Copy " + frmActiveNewDocument.Text +" "+ intChild;
               // Bitmap tempBmp = new Bitmap(bmp1);
                
                Bitmap tempBmp = (Bitmap)bmp1.Clone();
              
                frm.reload_bmp(tempBmp);
                frm.bmp = tempBmp;
                frm.reload_position("centerImage");
                frm.Show();
                
              
    
            }

            catch (System.Exception exp)
            {
                MessageBox.Show(exp.Message, this.Text);
            }

        }

       
        private void averageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistogramEqualization he = new HistogramEqualization();
            ChildForm frmActiveNewDocument = (ChildForm)this.ActiveMdiChild;
            Bitmap bmp1 = frmActiveNewDocument.bmp;
            frmActiveNewDocument.reload_bmp(he.Wyrownanie(bmp1, HistogramEqualization.Metody.Srednich));
            frmActiveNewDocument.reload_position("centerImage");
        }

        private void neighbourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistogramEqualization he = new HistogramEqualization();
            ChildForm frmActiveNewDocument = (ChildForm)this.ActiveMdiChild;
            Bitmap bmp1 = frmActiveNewDocument.bmp;
            frmActiveNewDocument.reload_bmp(he.Wyrownanie(bmp1, HistogramEqualization.Metody.Sasiedztwa));
            frmActiveNewDocument.reload_position("centerImage");
        }

        private void randomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistogramEqualization he = new HistogramEqualization();
            ChildForm frmActiveNewDocument = (ChildForm)this.ActiveMdiChild;
            Bitmap bmp1 = frmActiveNewDocument.bmp;
            frmActiveNewDocument.reload_bmp(he.Wyrownanie(bmp1, HistogramEqualization.Metody.Losowa));
            frmActiveNewDocument.reload_position("centerImage");
        }

        private void negacjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Operacje op = new Operacje();
            ChildForm frmActiveNewDocument = (ChildForm)this.ActiveMdiChild;
            Bitmap bmp1 = frmActiveNewDocument.bmp;
            frmActiveNewDocument.reload_bmp(op.Negacja(bmp1, toolStripStatusLabel1, toolStripProgressBar1));
            frmActiveNewDocument.reload_position("centerImage");
     
        }

        private void binaryzacjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Binaryzacja bin=new Binaryzacja();
           bin.ShowDialog();
           int threshold = bin.Threshold;
 //MessageBox.Show(threshold.ToString());
           Operacje op = new Operacje();
           ChildForm frmActiveNewDocument = (ChildForm)this.ActiveMdiChild;
           Bitmap bmp1 = frmActiveNewDocument.bmp;
           frmActiveNewDocument.reload_bmp(op.Binaryzacja(bmp1, toolStripStatusLabel1, toolStripProgressBar1, threshold));
		   frmActiveNewDocument.reload_position("centerImage");
          
                   }

        private void rozciąganieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rozciaganie roz = new Rozciaganie();
            roz.ShowDialog();
            int p1 = roz.GetP1;
            int p2 = roz.GetP2;
            Operacje op = new Operacje();
            ChildForm frmActiveNewDocument = (ChildForm)this.ActiveMdiChild;
            Bitmap bmp1 = frmActiveNewDocument.bmp;
            frmActiveNewDocument.reload_bmp(op.Rozciaganie(bmp1, toolStripStatusLabel1, toolStripProgressBar1, p1,p2));
            frmActiveNewDocument.reload_position("centerImage");
        }

        private void jasnoscToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Jasnosc jas = new Jasnosc();
            jas.ShowDialog();
            int level = jas.GetLevel;
            Operacje op = new Operacje();
            ChildForm frmActiveNewDocument = (ChildForm)this.ActiveMdiChild;
            Bitmap bmp1 = frmActiveNewDocument.bmp;
            frmActiveNewDocument.reload_bmp(op.Jasnosc(bmp1, toolStripStatusLabel1, toolStripProgressBar1, level));
            frmActiveNewDocument.reload_position("centerImage");
        }

        private void kontrastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kontrast kon = new Kontrast();
            kon.ShowDialog();
            double level = kon.GetLevel;
            Operacje op = new Operacje();
            ChildForm frmActiveNewDocument = (ChildForm)this.ActiveMdiChild;
            Bitmap bmp1 = frmActiveNewDocument.bmp;
            frmActiveNewDocument.reload_bmp(op.Kontrast(bmp1, toolStripStatusLabel1, toolStripProgressBar1,  level));
            frmActiveNewDocument.reload_position("centerImage");
        }

        private void skalaSzarosciFastToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            ChildForm frmActiveNewDocument = (ChildForm)this.ActiveMdiChild;
            Bitmap bmp1 = frmActiveNewDocument.bmp;
            MyBitmap mb =new MyBitmap(bmp1);
            

            frmActiveNewDocument.reload_bmp(mb.Transformacja(256, MyBitmap.trans.KSZAROSCI));
            frmActiveNewDocument.reload_position("centerImage");
        }

        private void fastProbaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int negativeR, negativeG, negativeB;
            
            ChildForm frmActiveNewDocument = (ChildForm)this.ActiveMdiChild;
            Bitmap bmp1 = frmActiveNewDocument.bmp;
            MyBitmap mb = new MyBitmap(bmp1);
         
            mb.LockB();
            for (int y = 0; y < mb.Height; y++)
            {
                for (int x = 0; x < mb.Width; x++)
                {

                    Color px = mb.getPixel(x, y);
                    negativeR = 255 - px.R;
                    negativeG = 255 - px.G;
                    negativeB = 255 - px.B;

                    Color nc = Color.FromArgb(px.A, negativeR, negativeG, negativeB);
                    mb.setPixel (x, y, nc);

                }
             
            }
            mb.UnlockB();
            frmActiveNewDocument.reload_bmp(mb.MyImageCopy);
            frmActiveNewDocument.reload_position("centerImage");
        
        }

        private void myFBitmapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildForm frmActiveNewDocument = (ChildForm)this.ActiveMdiChild;
            Bitmap bmp1 = frmActiveNewDocument.bmp;
         
            Benchmark.Start();
            MyFBitmap FBitmap = new MyFBitmap(bmp1);
            FBitmap.LockBits();

            Color compareClr = Color.FromArgb(255, 255, 255, 255);
            for (int y = 0; y < FBitmap.Height; y++)
            {
                for (int x = 0; x < FBitmap.Width; x++)
                {
                    if (FBitmap.GetPixel(x, y) == compareClr)
                    {
                        FBitmap.SetPixel(x, y, Color.Red);
                    }
                }
            }
            FBitmap.UnlockBits();
            Benchmark.End();
            double seconds = Benchmark.GetSeconds();
            System.Windows.Forms.MessageBox.Show("Duration:" + seconds.ToString());
            frmActiveNewDocument.reload_bmp(bmp1);
            frmActiveNewDocument.reload_position("centerImage");

        }

        private void histNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildForm frmActiveNewDocument = (ChildForm)this.ActiveMdiChild;
            Bitmap bmp1 = frmActiveNewDocument.bmp;

            Histogram his = new Histogram(bmp1);
            RichHistForm frmH = new RichHistForm();
            frmH.MdiParent = this;
            frmH.Show();
  
           frmH.ReloadHist(his); 
        
        }

        private void cofnijToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ChildForm frmActiveNewDocument = (ChildForm)this.ActiveMdiChild;
//Obiekt szybkiej bitmapy znajduje sie w childrenie 
            Bitmap bmp = frmActiveNewDocument.Fbmp.sourceCopy;
            frmActiveNewDocument.reload_bmp(bmp);
          frmActiveNewDocument.reload_position("centerImage");


        }

     
        private void RombToolStripMenuItemClick(object sender, System.EventArgs e)
        {
        	Krawedzie kr = new Krawedzie();
            kr.ShowDialog();
            int skrajne = kr.Skrajne;
            
        	Operacje op=new Operacje();
        	
        	 ChildForm frmActiveNewDocument = (ChildForm)this.ActiveMdiChild;
            Bitmap bmp1 = frmActiveNewDocument.bmp;
           frmActiveNewDocument.reload_bmp(op.Erozja(bmp1, toolStripStatusLabel1, toolStripProgressBar1, 1, skrajne));
           frmActiveNewDocument.reload_position("centerImage");
        }

            
       private void KwadratToolStripMenuItemClick(object sender, EventArgs e)
        {
       	Krawedzie kr = new Krawedzie();
            kr.ShowDialog();
            int skrajne = kr.Skrajne;
        	Operacje op=new Operacje();
        	
        	 ChildForm frmActiveNewDocument = (ChildForm)this.ActiveMdiChild;
            Bitmap bmp1 = frmActiveNewDocument.bmp;
            frmActiveNewDocument.reload_bmp(op.Erozja(bmp1, toolStripStatusLabel1, toolStripProgressBar1, 2, skrajne));
            frmActiveNewDocument.reload_position("centerImage");
        }
        
        private void RombToolStripMenuItem1Click(object sender, EventArgs e)
        {
        	Krawedzie kr = new Krawedzie();
            kr.ShowDialog();
            int skrajne = kr.Skrajne;
        	Operacje op=new Operacje();
        	
        	 ChildForm frmActiveNewDocument = (ChildForm)this.ActiveMdiChild;
            Bitmap bmp1 = frmActiveNewDocument.bmp;
            frmActiveNewDocument.reload_bmp(op.Dylatacja(bmp1, toolStripStatusLabel1, toolStripProgressBar1, 1, skrajne));
            frmActiveNewDocument.reload_position("centerImage");
        }
        
       private void KwadratToolStripMenuItem1Click(object sender, EventArgs e)
        {
        Krawedzie kr = new Krawedzie();
            kr.ShowDialog();
            int skrajne = kr.Skrajne;
            
       	Operacje op=new Operacje();
        	
        	 ChildForm frmActiveNewDocument = (ChildForm)this.ActiveMdiChild;
            Bitmap bmp1 = frmActiveNewDocument.bmp;
            frmActiveNewDocument.reload_bmp(op.Dylatacja(bmp1, toolStripStatusLabel1, toolStripProgressBar1, 2, skrajne));
            frmActiveNewDocument.reload_position("centerImage");
        }
       
      private void RombToolStripMenuItem2Click(object sender, System.EventArgs e)
        {
        	 Krawedzie kr = new Krawedzie();
            kr.ShowDialog();
            int skrajne = kr.Skrajne;
            
       	Operacje op=new Operacje();
        	
        	 ChildForm frmActiveNewDocument = (ChildForm)this.ActiveMdiChild;
            Bitmap bmp1 = frmActiveNewDocument.bmp;
            frmActiveNewDocument.reload_bmp(op.Otwarcie(bmp1, toolStripStatusLabel1, toolStripProgressBar1, 1, skrajne));
            frmActiveNewDocument.reload_position("centerImage");
        }
         
        void FiltracjaLiniowaToolStripMenuItemClick(object sender, EventArgs e)
        {
        	Maska msk = new Maska();
        	msk.ShowDialog();
        	int [,]maska=msk.GetMask;
        	  int skrajne =msk.GetSkrajne;
                      	
        	Operacje op=new Operacje();
        	
        	
        	       	
        	 ChildForm frmActiveNewDocument = (ChildForm)this.ActiveMdiChild;
        	 Bitmap bmp1 = frmActiveNewDocument.bmp;
			if (bmp1 == null)
				return;
            //	frmActiveNewDocument.bmp;
            frmActiveNewDocument.reload_bmp(op.Filtracja (bmp1, toolStripStatusLabel1, toolStripProgressBar1, maska, skrajne));
            frmActiveNewDocument.reload_position("centerImage");
            
        }
        
        void KwadratToolStripMenuItem2Click(object sender, EventArgs e)
        {
        	 Krawedzie kr = new Krawedzie();
            kr.ShowDialog();
            int skrajne = kr.Skrajne;
            
       	Operacje op=new Operacje();
        	
        	 ChildForm frmActiveNewDocument = (ChildForm)this.ActiveMdiChild;
            Bitmap bmp1 = frmActiveNewDocument.bmp;
            frmActiveNewDocument.reload_bmp(op.Otwarcie(bmp1, toolStripStatusLabel1, toolStripProgressBar1, 2, skrajne));
            frmActiveNewDocument.reload_position("centerImage");
        }
        
        
        void RombToolStripMenuItem3Click(object sender, EventArgs e)
        {
        	 Krawedzie kr = new Krawedzie();
            kr.ShowDialog();
            int skrajne = kr.Skrajne;
            
       	Operacje op=new Operacje();
        	
        	 ChildForm frmActiveNewDocument = (ChildForm)this.ActiveMdiChild;
            Bitmap bmp1 = frmActiveNewDocument.bmp;
            frmActiveNewDocument.reload_bmp(op.Zamkniecie(bmp1, toolStripStatusLabel1, toolStripProgressBar1, 1, skrajne));
            frmActiveNewDocument.reload_position("centerImage");
        }
        
        void KwadratToolStripMenuItem3Click(object sender, EventArgs e)
        {
			 Krawedzie kr = new Krawedzie();
            kr.ShowDialog();
            int skrajne = kr.Skrajne;
            
       	Operacje op=new Operacje();
        	
        	 ChildForm frmActiveNewDocument = (ChildForm)this.ActiveMdiChild;
            Bitmap bmp1 = frmActiveNewDocument.bmp;
            frmActiveNewDocument.reload_bmp(op.Zamkniecie(bmp1, toolStripStatusLabel1, toolStripProgressBar1, 2, skrajne));  
			frmActiveNewDocument.reload_position("centerImage");            
        }
        
        void SzkieletyzacjaToolStripMenuItemClick(object sender, EventArgs e)
        {
        	Operacje op=new Operacje();
        	
        	 ChildForm frmActiveNewDocument = (ChildForm)this.ActiveMdiChild;
            Bitmap bmp1 = frmActiveNewDocument.bmp;
            frmActiveNewDocument.reload_bmp(op.Szkieletyzacja(bmp1, toolStripStatusLabel1, toolStripProgressBar1));
            frmActiveNewDocument.reload_position("centerImage");
        }
        
        void SegmentacjaToolStripMenuItemClick(object sender, System.EventArgs e)
        {

           //Region Growing
            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            	 ChildForm frmActiveNewDocument = (ChildForm)this.ActiveMdiChild;
            Bitmap EditImage = frmActiveNewDocument.bmp;
                 byte minq = 0;
            byte maxq = 150;
           
            
            BitmapData bmData = EditImage.LockBits(new Rectangle(0, 0, EditImage.Width, EditImage.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
 
            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;
            int bitsPerPixels = stride / EditImage.Width;
 
            int[,] arraynilai = new int[EditImage.Width+1, EditImage.Height+1];
 
            unsafe
            {
                byte* pos;
                byte* scan0 = (byte*)(bmData.Scan0.ToPointer());
 
                for (int j = 0; j < bmData.Height-1; j++)
                {
                    pos = scan0 + stride * j;
                    for (int i = 0; i < bmData.Width; i++)
                    {
                        *pos = (byte)(255 - *pos);
                        if ((pos[i] <= maxq && pos[i] >= minq))
                            arraynilai[i, j] = 1; 
                        else
                            arraynilai[i, j] = 0;
                        pos += bitsPerPixels;
                    }
                }
               


                for (int j = 1; j < bmData.Height-1; j++)
                {
                    pos = scan0 + stride * j;
                    for (int i = 1; i < bmData.Width; i++)
                    {
                        *pos = (byte)(255 - *pos);
                        int rc1 = arraynilai[i - 1, j - 1];
                        int rc2 = arraynilai[i, j - 1];
                        int rc3 = arraynilai[i + 1, j - 1];
                        int rc4 = arraynilai[i + 1, j];
                        int rc5 = arraynilai[i + 1, j + 1];
                        int rc6 = arraynilai[i, j + 1];
                        int rc7 = arraynilai[i - 1, j + 1];
                        int rc8 = arraynilai[i - 1, j];
                        int tot = rc1 + rc2 + rc3 + rc4 + rc5 + rc6 + rc7 + rc8;
                        if (tot < 8 && tot > 0)
                        {
                        	try {
                            pos[i] =128;
                           // if(bmData.Width<(i+1))  
                            	pos[i + 1]=0;
                           // if(bmData.Width<(i+2))  
                            	pos[i + 2] = 0;
                        	}
                        	catch {MessageBox.Show("i "+i.ToString());}
                        }
                        pos += bitsPerPixels;
                    }
                }
            }
            EditImage.UnlockBits(bmData);
            frmActiveNewDocument.reload_bmp(EditImage);
            frmActiveNewDocument.reload_position("centerImage");
        }        	
        
        
        void PoziomyToolStripMenuItemClick(object sender, System.EventArgs e)
        {
        	Operacje op=new Operacje();
        	
        	 ChildForm frmActiveNewDocument = (ChildForm)this.ActiveMdiChild;
            Bitmap bmp1 = frmActiveNewDocument.bmp;
            frmActiveNewDocument.reload_bmp(op.Redukcja(bmp1, toolStripStatusLabel1, toolStripProgressBar1, 4));
            frmActiveNewDocument.reload_position("centerImage");
        }
        
        void PoziomówToolStripMenuItemClick(object sender, EventArgs e)
        {
        	Operacje op=new Operacje();
        	
        	 ChildForm frmActiveNewDocument = (ChildForm)this.ActiveMdiChild;
            Bitmap bmp1 = frmActiveNewDocument.bmp;
            frmActiveNewDocument.reload_bmp(op.Redukcja(bmp1, toolStripStatusLabel1, toolStripProgressBar1, 8));
            frmActiveNewDocument.reload_position("centerImage");
        }
        
        void PoziomówToolStripMenuItem1Click(object sender, EventArgs e)
        {
			Operacje op=new Operacje();
        	
        	 ChildForm frmActiveNewDocument = (ChildForm)this.ActiveMdiChild;
            Bitmap bmp1 = frmActiveNewDocument.bmp;
            frmActiveNewDocument.reload_bmp(op.Redukcja(bmp1, toolStripStatusLabel1, toolStripProgressBar1, 16));        
			frmActiveNewDocument.reload_position("centerImage");            
        }
        
        void PoziomyToolStripMenuItem1Click(object sender, EventArgs e)
        {
        	Operacje op=new Operacje();
        	
        	 ChildForm frmActiveNewDocument = (ChildForm)this.ActiveMdiChild;
            Bitmap bmp1 = frmActiveNewDocument.bmp;
            frmActiveNewDocument.reload_bmp(op.Redukcja(bmp1, toolStripStatusLabel1, toolStripProgressBar1, 32));
            frmActiveNewDocument.reload_position("centerImage");
        }
        
        void PoziomyToolStripMenuItem2Click(object sender, EventArgs e)
        {
        	Operacje op=new Operacje();
        	
        	 ChildForm frmActiveNewDocument = (ChildForm)this.ActiveMdiChild;
            Bitmap bmp1 = frmActiveNewDocument.bmp;
            frmActiveNewDocument.reload_bmp(op.Redukcja(bmp1, toolStripStatusLabel1, toolStripProgressBar1, 64));
            frmActiveNewDocument.reload_position("centerImage");
        }
        
        void PoziomówToolStripMenuItem2Click(object sender, EventArgs e)
        {
        	Operacje op=new Operacje();
        	
        	 ChildForm frmActiveNewDocument = (ChildForm)this.ActiveMdiChild;
            Bitmap bmp1 = frmActiveNewDocument.bmp;
            frmActiveNewDocument.reload_bmp(op.Redukcja(bmp1, toolStripStatusLabel1, toolStripProgressBar1, 128));
            frmActiveNewDocument.reload_position("centerImage");
        }
        
        void ANDToolStripMenuItemClick(object sender, EventArgs e)
        {
        	
        }
        
        void AlgorytmŻółwiaToolStripMenuItemClick(object sender, EventArgs e)
        {
        	Operacje op=new Operacje();
        	
        	 ChildForm frmActiveNewDocument = (ChildForm)this.ActiveMdiChild;
            Bitmap bmp1 = frmActiveNewDocument.bmp;
            frmActiveNewDocument.reload_bmp(op.turtle2(bmp1, 0,0));
            frmActiveNewDocument.reload_position("centerImage");
        }
        
        void MainFormLoad(object sender, EventArgs e)
        {
        	toolsToolStripMenuItem.Enabled=false;
        	operacjeToolStripMenuItem.Enabled=false;
        	viewToolStripMenuItem.Enabled=false;
        	windowToolStripMenuItem.Enabled=false;
        	//MessageBox.Show("sssss");
        }
        
        void MenuStrip1ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        	
        }
        
        void ZapiszToolStripMenuItemClick(object sender, EventArgs e)
        {
        	ChildForm frmActiveNewDocument = (ChildForm)this.ActiveMdiChild;
            Bitmap bmp1 = frmActiveNewDocument.bmp;
        	 
            SaveFileDialog sfd = new SaveFileDialog();
sfd.Filter = "All Image Formats (*.bmp;*.jpg;*.jpeg;*.gif;*.tif)|" +
        "*.bmp;*.jpg;*.jpeg;*.gif;*.tif|Bitmaps (*.bmp)|*.bmp|" +
        "GIFs (*.gif)|*.gif|JPEGs (*.jpg)|*.jpg;*.jpeg|TIFs (*.tif)|*.tif";

ImageFormat format = ImageFormat.Bmp;
if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
{
    string ext = System.IO.Path.GetExtension(sfd.FileName);
    switch (ext)
    {
        case ".jpg":
            format = ImageFormat.Jpeg;
            break;
        case ".png":
            format = ImageFormat.Png;
            break;
            
           default:
            format=ImageFormat.Bmp;
            break;
    }
    bmp1.Save(sfd.FileName, format);
}
            
        }
        
        void SaveFileDialog1FileOk(object sender, CancelEventArgs e)
        {
        	 
        	string name =this.saveFileDialog1.FileName;
        	//MessageBox.Show();
        	
        	
        	 try
    {
        
        	 	
        	 	   	
        	 ChildForm frmActiveNewDocument = (ChildForm)this.ActiveMdiChild;
            Bitmap bmp1 = frmActiveNewDocument.bmp;
        	 	
        	 	if (bmp1 != null)
        {
            bmp1.Save(name.ToString());
           
        }
    }
    catch(Exception)
    {
        MessageBox.Show("There was a problem saving the file." +
            "Check the file permissions.");
    }
        	
        	
        }
        
        void PixTabToolStripMenuItemClick(object sender, EventArgs e)
        {
        	
        	 try
            {
                ChildForm frmActiveNewDocument = (ChildForm)this.ActiveMdiChild;
                Bitmap bmp1 = frmActiveNewDocument.bmp;

           
                 PixTabForm frmH = new  PixTabForm();
                frmH.MdiParent = this;
                frmH.Show();
                //frmH.AddSmallImg(frmActiveNewDocument.Small_bmp(100,100));

             frmH.ReloadPixTabForm(bmp1);  
                

            }

            catch (System.Exception exp)
            {
                MessageBox.Show(exp.Message, this.Text);
            }

        }
        
        void WłasnaToolStripMenuItemClick(object sender, EventArgs e)
        {
        	 HistogramEqualization he = new HistogramEqualization();
            ChildForm frmActiveNewDocument = (ChildForm)this.ActiveMdiChild;
            Bitmap bmp1 = frmActiveNewDocument.bmp;
            frmActiveNewDocument.reload_bmp(he.Wyrownanie(bmp1, HistogramEqualization.Metody.Wlasna ));
            frmActiveNewDocument.reload_position("centerImage");
        }
        
         void WspolczynnikiKsztaltuToolStripMenuItemClick(object sender, System.EventArgs e)
        {
        	ChildForm frmActiveNewDocument = (ChildForm)this.ActiveMdiChild;
            Bitmap bmp = frmActiveNewDocument.bmp;
            FastBitmapp fbmp = new FastBitmapp(bmp);
            Lab6 x = new Lab6();
            Lab6.Stats info = x.stats(fbmp);
            
            StringBuilder str = new StringBuilder();
            str.Append("W1: ").Append(info.W[0]).Append("\n");
            str.Append("W2: ").Append(info.W[1]).Append("\n");
            str.Append("W3: ").Append(info.W[2]).Append("\n");
            str.Append("W4: ").Append(info.W[3]).Append("\n");
            //str.Append("W5: ").Append(info.W[4]).Append("\n");
            //str.Append("W6: ").Append(info.W[5]).Append("\n");
            //str.Append("W7: ").Append(info.W[6]).Append("\n");
            //str.Append("W8: ").Append(info.W[7]).Append("\n");
            str.Append("W9: ").Append(info.W[8]).Append("\n");
            str.Append("Area: ").Append(info.area).Append("\n");
            MessageBox.Show(str.ToString());

        }

         private void oProgramieToolStripMenuItem_Click(object sender, EventArgs e)
         {
             AboutProgram box = new AboutProgram();
             box.ShowDialog();
         }
    }
}
