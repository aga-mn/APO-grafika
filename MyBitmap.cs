using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace WindowsFormsApplication1
{
    class MyBitmap
    {
        private Bitmap myImage;
        private Bitmap myImageCopy;
        private BitmapData myImagedata=null ;
        private BitmapData myImageCopydata=null;
        PixelFormat formatImage;
     
        public Bitmap MyImage
        {
            get
            {
                return myImage;
            }
            set
            {
                myImage = value;
            }
        }

        public Bitmap MyImageCopy
        {
            get
            {
                return myImageCopy;
            }
        }


        public int Width
        {
            get { return myImage.Width; }
        }

        public int Height
        {
            get { return myImage.Height; }
        }


        public unsafe void Initialize(BitmapData myImagedata, BitmapData myImageCopydata)
        {
            byte* PtrmyImagedata = (byte*)myImagedata.Scan0;
            byte* PTrmyImageCopydata = (byte*)myImageCopydata.Scan0;


            int nOffset = myImagedata.Stride - myImage.Width * 3;

            for (int y = 0; y < myImageCopy.Height; y++)
            {
                for (int x = 0; x < myImageCopy.Width; x++)
                {
                    PTrmyImageCopydata[0] = PTrmyImageCopydata[1] = PTrmyImageCopydata[2] = (byte)((PtrmyImagedata[0] + PtrmyImagedata[1] + PtrmyImagedata[2]) / 3);

                    PtrmyImagedata += 3; PTrmyImageCopydata += 3;
                }
                PtrmyImagedata += nOffset; PTrmyImageCopydata += nOffset;
            }

           // myImage.UnlockBits(myImagedata);
           // myImageCopy.UnlockBits(myImageCopydata);
        
        }
        
       public void UnlockB() {
           myImage.UnlockBits(myImagedata);
           myImageCopy.UnlockBits(myImageCopydata);
           System.Windows.Forms.MessageBox.Show("UnlockB");

    }

       public void LockB()
       {
           myImagedata = myImage.LockBits(new Rectangle(0, 0, myImage.Width, myImage.Height), ImageLockMode.ReadOnly, formatImage);
           myImageCopydata = myImageCopy.LockBits(new Rectangle(0, 0, myImageCopy.Width, myImageCopy.Height), ImageLockMode.ReadWrite, formatImage);
         

       }

        
        public MyBitmap(Bitmap img)
{

            this.myImageCopy = this.myImage = img;
            myImage = (Bitmap)img.Clone();
            myImageCopy = (Bitmap)img.Clone();
            //Blokujemy bitmapy w pamięci. Jako pierwszy argument metody LockBits podajemy obszar z współrzędnymi początku i końca obrazka. Następnie określamy sposób dostępu i format. Do tak utworzonej tablicy pikseli możemy się bezpośrednio odwołać i ją modyfikować.
            formatImage = (myImage.PixelFormat == PixelFormat.Format8bppIndexed) ? PixelFormat.Format8bppIndexed : PixelFormat.Format24bppRgb;
           
            LockB(); 
            
           // myImagedata = myImage.LockBits(new Rectangle(0, 0, myImage.Width, myImage.Height), ImageLockMode.ReadOnly, formatObrazka);
             //myImageCopydata = myImageCopy.LockBits(new Rectangle(0, 0, myImageCopy.Width, myImageCopy.Height), ImageLockMode.ReadWrite, formatObrazka);
            Initialize(myImagedata, myImageCopydata);
            UnlockB();
           
}

        public void Dispose()
        {
            System.Windows.Forms.MessageBox.Show("sss");
        }



        public enum trans
        {
            JASNOSC, BINARYZACJA, KSZAROSCI, NEGATYW
        }

        public void setPixel(int x, int y,Color nc)
        {

         

        

            unsafe
            {
                byte* ptr = (byte*)((byte*)myImageCopydata.Scan0 + (y * myImageCopydata.Stride) + x);
                ptr[0] = nc.R;
                ptr[1] = nc.G;
                ptr[2] = nc.B;
            }



        }


        public Color getPixel(int x, int y)
        {
               Color nc=new Color();
              
            unsafe
            {
                byte* ptr = (byte*)((byte*)myImageCopydata.Scan0 + (y * myImageCopydata.Stride) + x);
      

            Color c = Color.FromArgb(ptr[0], ptr[1], ptr[2]);
            }
       


            return nc;

        }

        public Bitmap Transformacja(int prog, trans RodzTransformacji)
        {
           /* if (myImageCopy.PixelFormat != PixelFormat.Format8bppIndexed && myImageCopy.PixelFormat != PixelFormat.Format24bppRgb)
            {
                Bitmap bmp = new Bitmap(myImageCopy.Width, myImageCopy.Height, PixelFormat.Format24bppRgb);
                Graphics g = Graphics.FromImage(bmp);
                g.DrawImage(myImageCopy, 0, 0, myImageCopy.Width, myImageCopy.Height);
                g.Dispose();
                myImageCopy = bmp;
                myImage = bmp;
            }*/
    // PixelFormat formatObrazka = (myImage.PixelFormat == PixelFormat.Format8bppIndexed) ? PixelFormat.Format8bppIndexed : PixelFormat.Format24bppRgb;
     //Blokujemy bitmapy w pamięci. Jako pierwszy argument metody LockBits podajemy obszar z współrzędnymi początku i końca obrazka. Następnie określamy sposób dostępu i format. Do tak utworzonej tablicy pikseli możemy się bezpośrednio odwołać i ją modyfikować.
    // BitmapData myImagedata = myImage.LockBits(new Rectangle(0, 0, myImage.Width, myImage.Height), ImageLockMode.ReadOnly, formatObrazka);
   //  BitmapData myImageCopydata = myImageCopy.LockBits(new Rectangle(0, 0, myImageCopy.Width, myImageCopy.Height), ImageLockMode.ReadWrite, formatObrazka);



/*
 


unsafe
{

   
  

  

    switch (RodzTransformacji)
    {
       
     case trans.KSZAROSCI:

for (int y = 0; y < myImageCopy.Height; y++)
{
for (int x = 0; x < myImageCopy.Width; x++)
{
    PTrmyImageCopydata[0] = PTrmyImageCopydata[1] = PTrmyImageCopydata[2] = (byte)((PtrmyImagedata[0] + PtrmyImagedata[1] + PtrmyImagedata[2]) / 3);

    PtrmyImagedata += 3; PTrmyImageCopydata += 3;
}
PtrmyImagedata += nOffset; PTrmyImageCopydata += nOffset; 
}
break;

    }


}////
*/
//myImage.UnlockBits(myImagedata);
//myImageCopy.UnlockBits(myImageCopydata);
return myImageCopy;     
        
        }

    }
}
