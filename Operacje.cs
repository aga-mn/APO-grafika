using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Operacje
    {
        public Bitmap Negacja(Bitmap bmp, System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1, System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1)
        {
            Benchmark.Start();
            MyFBitmap Fbmp = new MyFBitmap(bmp);
            Fbmp.LockBits();
            int negativeR, negativeG, negativeB;
            toolStripProgressBar1.Maximum = Fbmp.Width;
            for (int x = 0; x < Fbmp.Width; x++) 
            {
                toolStripProgressBar1.Value = x;

                for (int y = 0; y < Fbmp.Height; y++)
                {
                    Color px = Fbmp.GetPixel(x, y);
                    negativeR = 255 - px.R;
                    negativeG = 255 - px.G;
                    negativeB = 255 - px.B;
                    
                    Color nc = Color.FromArgb(px.A, negativeR, negativeG, negativeB);
                    Fbmp.SetPixel(x, y, nc);
                }

            }
            Fbmp.UnlockBits();
            Benchmark.End();
            toolStripProgressBar1.Value = toolStripProgressBar1.Maximum;
            double seconds = Benchmark.GetSeconds();
            
            toolStripStatusLabel1.Text = "Czas Wykonania Negacji:" + seconds.ToString();
            return bmp;
        }

            public Bitmap GrayScale(Bitmap bmp, System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1, System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1)
        {
            Benchmark.Start();
            MyFBitmap Fbmp = new MyFBitmap(bmp);
            Fbmp.LockBits();
           // int negativeR, negativeG, negativeB;
            toolStripProgressBar1.Maximum = Fbmp.Width;
               for (int x = 0; x < Fbmp.Width; x++)

                for (int y = 0; y < Fbmp.Height; y++)
                {
                    Color px = Fbmp.GetPixel(x, y);

                    int grayScale = (int)((px.R * 0.3) + (px.G * 0.59) + (px.B * 0.11));
                    Color nc = Color.FromArgb(px.A, grayScale, grayScale, grayScale);
                    Fbmp.SetPixel(x, y, nc);
                }

            
            Fbmp.UnlockBits();
            Benchmark.End();
            toolStripProgressBar1.Value = toolStripProgressBar1.Maximum;
            double seconds = Benchmark.GetSeconds();
            
            toolStripStatusLabel1.Text = "Czas Wykonania Negacji:" + seconds.ToString();
            return bmp;
        }

        
        public Bitmap Binaryzacja(Bitmap bmp, System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1, System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1, int threshold)
        {

        	 Benchmark.Start();
            MyFBitmap Fbmp = new MyFBitmap(bmp);
            Fbmp.LockBits();
            if (toolStripProgressBar1 != null) {toolStripProgressBar1.Maximum = Fbmp.Width;}
            for (int x = 0; x < Fbmp.Width; x++)
            {if (toolStripProgressBar1 !=null) {toolStripProgressBar1.Value = x;}
                for (int y = 0; y < Fbmp.Height; y++)
                {
                    Color px = Fbmp.GetPixel(x, y);
                    if ((int)((px.R * 0.3) + (px.G * 0.59) + (px.B * 0.11)) <= threshold)
                    {
                        Color nc = Color.FromArgb(px.A, 0, 0, 0);
                        Fbmp.SetPixel(x, y, nc);
                    }
                    else
                    {
                        Color nc = Color.FromArgb(px.A, 255, 255, 255);
                        Fbmp.SetPixel(x, y, nc);
                    }
                }
            }
 Fbmp.UnlockBits();
            Benchmark.End();
            if (toolStripProgressBar1 !=null) {toolStripProgressBar1.Value = toolStripProgressBar1.Maximum;}
            double seconds = Benchmark.GetSeconds();
            if (toolStripStatusLabel1 !=null) toolStripStatusLabel1.Text = "Czas Wykonania Bianryzacji:" + seconds.ToString();
            return bmp;
        }

        public Bitmap Rozciaganie(Bitmap bmp, System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1, System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1, int p1, int p2)
        {
        	Benchmark.Start();
            MyFBitmap Fbmp = new MyFBitmap(bmp);
            Fbmp.LockBits();
            if (toolStripProgressBar1!=null) {toolStripProgressBar1.Maximum = Fbmp.Width;}
            for (int x = 0; x < bmp.Width; x++)
            {
            	if (toolStripProgressBar1!=null) {toolStripProgressBar1.Value = x;}
            	for (int y = 0; y < Fbmp.Height; y++)
                {
                    Color px = Fbmp.GetPixel(x, y);
                    int oc = (int)((px.R * 0.3) + (px.G * 0.59) + (px.B * 0.11));
                    if (oc > p1 && oc <= p2)
                    {

                        int q = (oc - p1) * 255 / (p2 - p1);

                        Color nc = Color.FromArgb(px.A, q, q, q);
                        Fbmp.SetPixel(x, y, nc);
                    }
                    else
                    {
                        Color nc = Color.FromArgb(px.A, 0, 0, 0);
                        Fbmp.SetPixel(x, y, nc);
                    }
                }
            }
             Fbmp.UnlockBits();
            Benchmark.End();
            if (toolStripProgressBar1!=null) {toolStripProgressBar1.Value = toolStripProgressBar1.Maximum;}
            double seconds = Benchmark.GetSeconds();
           if (toolStripStatusLabel1 !=null) toolStripStatusLabel1.Text = "Czas Wykonania Roziciągania:" + seconds.ToString();
            return bmp;
        }

        
        public Bitmap Redukcja (Bitmap bmp, System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1, System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1, int poziomy )
        {
        Benchmark.Start();
            MyFBitmap Fbmp = new MyFBitmap(bmp);
            Fbmp.LockBits();
        	toolStripProgressBar1.Maximum = Fbmp.Width;
        	
        	 int[] upo = new int[256];
            float param1 = 255.0f / (poziomy - 1);
            float param2 = 256.0f / (poziomy);
            for (int i = 0; i < 256; ++i) {
                upo[i] = (int)((int)(i / param2) * param1);
            }
                
                for (int i = 0; i < bmp.Size.Width; ++i) {
                for (int j = 0; j < bmp.Size.Height; ++j) {
            		Color nc = Color.FromArgb(upo[ToGrey(Fbmp.GetPixel(i,j))], upo[ToGrey(Fbmp.GetPixel(i,j))],upo[ToGrey(Fbmp.GetPixel(i,j))], upo[ToGrey(Fbmp.GetPixel(i,j))]);
                        Fbmp.SetPixel(i, j, nc);
                }
            }
            
            
            
        	
          Fbmp.UnlockBits();
            Benchmark.End();
            toolStripProgressBar1.Value = toolStripProgressBar1.Maximum;
            double seconds = Benchmark.GetSeconds();
            
            toolStripStatusLabel1.Text = "Czas Wykonania Redukcji: " + ((int)seconds).ToString() +" sek.";
            return bmp;
        
        }
        
        public Bitmap Jasnosc (Bitmap bmp, System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1, System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1,int level)
        {
        	 Benchmark.Start();
            MyFBitmap Fbmp = new MyFBitmap(bmp);
            Fbmp.LockBits();
            if (toolStripProgressBar1 !=null) toolStripProgressBar1.Maximum = Fbmp.Width;
            for (int x = 0; x < Fbmp.Width; x++)
            {
            	if (toolStripProgressBar1 !=null)  toolStripProgressBar1.Value = x;
                for (int y = 0; y < Fbmp.Height; y++)
                {
                    Color px = Fbmp.GetPixel(x, y);
                    int oc = (int)((px.R * 0.3) + (px.G * 0.59) + (px.B * 0.11));
                    int nc = oc+level;
                    if (nc < 0) nc = 0;
                    else if (nc > 255) nc = 255;
                    Color nnc = Color.FromArgb(px.A, nc, nc, nc);
                    Fbmp.SetPixel(x, y, nnc); 
                }
            }
                 Fbmp.UnlockBits();
            Benchmark.End();
           if (toolStripProgressBar1 !=null)  toolStripProgressBar1.Value = toolStripProgressBar1.Maximum;
            double seconds = Benchmark.GetSeconds();
            
            if (toolStripStatusLabel1!=null)  toolStripStatusLabel1.Text = "Czas Wykonania Regulacji Jasności:" + seconds.ToString();
            return bmp;
        }

        public Bitmap Kontrast (Bitmap bmp, System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1, System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1, double contrast)
        {
        	
        	 Benchmark.Start();
            MyFBitmap Fbmp = new MyFBitmap(bmp);
            Fbmp.LockBits();
            if (toolStripProgressBar1!=null) {toolStripProgressBar1.Maximum = Fbmp.Width;}
            double A, R, G, B;

            //Color pixelColor;

            contrast = (100.0 + contrast) / 100.0;
            contrast *= contrast;

            for (int x = 0; x < Fbmp.Width; x++)
            {
            	if (toolStripProgressBar1!=null) {toolStripProgressBar1.Value = x;}
                for (int y = 0; y < Fbmp.Height; y++)
                {
                    Color px = Fbmp.GetPixel(x, y);
                  
                    A = px.A;

                    R = px.R / 255.0;
                    R -= 0.5;
                    R *= contrast;
                    R += 0.5;
                    R *= 255;

                    if (R > 255)
                    {
                        R = 255;
                    }
                    else if (R < 0)
                    {
                        R = 0;
                    }

                    G = px.G / 255.0;
                    G -= 0.5;
                    G *= contrast;
                    G += 0.5;
                    G *= 255;
                    if (G > 255)
                    {
                        G = 255;
                    }
                    else if (G < 0)
                    {
                        G = 0;
                    }

                    B = px.B / 255.0;
                    B -= 0.5;
                    B *= contrast;
                    B += 0.5;
                    B *= 255;
                    if (B > 255)
                    {
                        B = 255;
                    }
                    else if (B < 0)
                    {
                        B = 0;
                    }

                    Fbmp.SetPixel(x, y, Color.FromArgb((int)A, (int)R, (int)G, (int)B));
                }
            }
                             Fbmp.UnlockBits();
            Benchmark.End();
            if (toolStripProgressBar1!=null)  {toolStripProgressBar1.Value = toolStripProgressBar1.Maximum;}
            double seconds = Benchmark.GetSeconds();
            
            if (toolStripStatusLabel1!=null) { toolStripStatusLabel1.Text = "Czas Wykonania Regulacji Kontrastu:" + seconds.ToString();}

            return bmp;
        }  

        public Bitmap Erozja(Bitmap bmp,  System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1, System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1, int wzorzec, int skrajne)
        {
        Benchmark.Start();
            MyFBitmap Fbmp = new MyFBitmap(bmp);
            Fbmp.LockBits();
                    toolStripProgressBar1.Maximum = Fbmp.Width;
                    
                    if (skrajne==1)//olewa krawędzie
                    {  
                    	
                    	int [,] erozja=new int[bmp.Width,bmp.Height];
                    	int min;
                    if (wzorzec==1)//romb
                    {
                    for (int x=1; x<Fbmp.Width-1; x++)
                    	for (int y=1;y<Fbmp.Height-1;y++)
                    		
                    {
                      int oc=ToGrey(Fbmp.GetPixel(x, y));
                       min=oc;
                      if (min>=ToGrey(Fbmp.GetPixel(x,y-1))) min=ToGrey(Fbmp.GetPixel(x,y-1));
                      if (min>=ToGrey(Fbmp.GetPixel(x-1,y))) min=ToGrey(Fbmp.GetPixel(x-1,y));
                      if (min>=ToGrey(Fbmp.GetPixel(x+1,y))) min=ToGrey(Fbmp.GetPixel(x+1,y));
                      if (min>=ToGrey(Fbmp.GetPixel(x,y+1))) min=ToGrey(Fbmp.GetPixel(x,y+1));    
 		         
                  erozja[x,y]=min;
                    }
                                 
                    }//endif
                    
                    else //kwadrat
                    {
                   
                    for (int x=1; x<Fbmp.Width-1; x++)
                    	for (int y=1;y<Fbmp.Height-1;y++)
                    		
                    {
                      int oc=ToGrey(Fbmp.GetPixel(x, y));
                       min=oc;
                      if (min>=ToGrey(Fbmp.GetPixel(x,y-1))) min=ToGrey(Fbmp.GetPixel(x,y-1));
                      if (min>=ToGrey(Fbmp.GetPixel(x-1,y))) min=ToGrey(Fbmp.GetPixel(x-1,y));
                      if (min>=ToGrey(Fbmp.GetPixel(x+1,y))) min=ToGrey(Fbmp.GetPixel(x+1,y));
                      if (min>=ToGrey(Fbmp.GetPixel(x,y+1))) min=ToGrey(Fbmp.GetPixel(x,y+1)); 
                      if (min>=ToGrey(Fbmp.GetPixel(x-1,y-1))) min=ToGrey(Fbmp.GetPixel(x-1,y-1));					  
                      if (min>=ToGrey(Fbmp.GetPixel(x-1,y+1))) min=ToGrey(Fbmp.GetPixel(x-1,y+1));
					  if (min>=ToGrey(Fbmp.GetPixel(x+1,y-1))) min=ToGrey(Fbmp.GetPixel(x+1,y-1));
					  if (min>=ToGrey(Fbmp.GetPixel(x+1,y+1))) min=ToGrey(Fbmp.GetPixel(x+1,y+1));
 			
              erozja[x,y]=min;
                    }
                    }//end kwadrat
                    
                   for (int x=1; x<Fbmp.Width-1; x++)
                    	for (int y=1;y<Fbmp.Height-1;y++)
                   {
                   	  Color nc = Color.FromArgb(erozja[x,y], erozja[x,y], erozja[x,y], erozja[x,y]);                      
                    	 Fbmp.SetPixel(x, y, nc);
                   }
                    } //end olewa krawedzie
                    
                    else if (skrajne==2) //duplikuje
                    {
                    		int [,] erozja=new int[bmp.Width,bmp.Height];
                    	int min;
                    if (wzorzec==1)//romb
                    {
                    	
                    for (int x=0; x<Fbmp.Width; x++)
                    	for (int y=0;y<Fbmp.Height;y++)
                    		
                    {
                    	//narożniki
                    	if (x==0&&y==0) 
                    	{int oc=ToGrey(Fbmp.GetPixel(x, y));
                      min=oc;
                      if (min>=ToGrey(Fbmp.GetPixel(x+1,y))) min=ToGrey(Fbmp.GetPixel(x+1,y));
                      if (min>=ToGrey(Fbmp.GetPixel(x,y+1))) min=ToGrey(Fbmp.GetPixel(x,y+1)); 
                  //    erozja[x,y]=min;
                       	}
                    	
                    	else if (x==0 && y==Fbmp.Height-1)
                    	{
                    	int oc=ToGrey(Fbmp.GetPixel(x, y));
                       min=oc;
        				if (min>=ToGrey(Fbmp.GetPixel(x,y-1))) min=ToGrey(Fbmp.GetPixel(x,y-1));
     				     if (min>=ToGrey(Fbmp.GetPixel(x+1,y))) min=ToGrey(Fbmp.GetPixel(x+1,y)); 
     				 //                          erozja[x,y]=min;
                    	}
                    	
                    	else if (x==Fbmp.Width-1 && y==0)
                    		{
                    	int oc=ToGrey(Fbmp.GetPixel(x, y));
                       min=oc;
        				if (min>=ToGrey(Fbmp.GetPixel(x-1,y))) min=ToGrey(Fbmp.GetPixel(x-1,y));
     				     if (min>=ToGrey(Fbmp.GetPixel(x,y+1))) min=ToGrey(Fbmp.GetPixel(x,y+1)); 
     				 //                          erozja[x,y]=min;
                    	}
                    		
                    		else if (x==Fbmp.Width-1 && y==Fbmp.Height-1)
                    		{
                    		int oc=ToGrey(Fbmp.GetPixel(x, y));
                       min=oc;
                         if (min>=ToGrey(Fbmp.GetPixel(x-1,y))) min=ToGrey(Fbmp.GetPixel(x-1,y));
                          if (min>=ToGrey(Fbmp.GetPixel(x,y-1))) min=ToGrey(Fbmp.GetPixel(x,y-1));
                     //                           erozja[x,y]=min;
                    		}
                    			
                    		//skrajne bez narożników
                    		
                    		else if (x==0&& y>0 && y<Fbmp.Height-1)//górny rząd
                    		{
                    			int oc=ToGrey(Fbmp.GetPixel(x, y));
                       min=oc;
                        if (min>=ToGrey(Fbmp.GetPixel(x,y-1))) min=ToGrey(Fbmp.GetPixel(x,y-1));
                      if (min>=ToGrey(Fbmp.GetPixel(x+1,y))) min=ToGrey(Fbmp.GetPixel(x+1,y));
                      if (min>=ToGrey(Fbmp.GetPixel(x,y+1))) min=ToGrey(Fbmp.GetPixel(x,y+1)); 
                      //                      erozja[x,y]=min;
                    		}
                    		
                    		else if (x==Fbmp.Width-1&& y>0 && y<Fbmp.Height-1)//dolny rząd
                    		{
                    		 int oc=ToGrey(Fbmp.GetPixel(x, y));
                       min=oc;
                      if (min>=ToGrey(Fbmp.GetPixel(x,y-1))) min=ToGrey(Fbmp.GetPixel(x,y-1));
                      if (min>=ToGrey(Fbmp.GetPixel(x-1,y))) min=ToGrey(Fbmp.GetPixel(x-1,y));
                      if (min>=ToGrey(Fbmp.GetPixel(x,y+1))) min=ToGrey(Fbmp.GetPixel(x,y+1)); 
					// erozja[x,y]=min;
                    		}
                    		
                    		else if (y==0 && x>0 && x<Fbmp.Width-1)//pierwsza kolumna
                    		{ int oc=ToGrey(Fbmp.GetPixel(x, y));
                       min=oc;
                    		  if (min>=ToGrey(Fbmp.GetPixel(x-1,y))) min=ToGrey(Fbmp.GetPixel(x-1,y));
                      if (min>=ToGrey(Fbmp.GetPixel(x+1,y))) min=ToGrey(Fbmp.GetPixel(x+1,y));
                      if (min>=ToGrey(Fbmp.GetPixel(x,y+1))) min=ToGrey(Fbmp.GetPixel(x,y+1)); 
					// erozja[x,y]=min;
                    		
                    		}
                    		else if (y==Fbmp.Height-1 &&  x>0 && x<Fbmp.Width-1) //ostatnia kolumna
                    		{
                    		int oc=ToGrey(Fbmp.GetPixel(x, y));
                       min=oc;
                      if (min>=ToGrey(Fbmp.GetPixel(x,y-1))) min=ToGrey(Fbmp.GetPixel(x,y-1));
                      if (min>=ToGrey(Fbmp.GetPixel(x-1,y))) min=ToGrey(Fbmp.GetPixel(x-1,y));
                      if (min>=ToGrey(Fbmp.GetPixel(x+1,y))) min=ToGrey(Fbmp.GetPixel(x+1,y));
                    	//erozja[x,y]=min;	
                    		}
                    		//nieskrajne
                    			else
                    			{     int oc=ToGrey(Fbmp.GetPixel(x, y));
                       min=oc;
                      if (min>=ToGrey(Fbmp.GetPixel(x,y-1))) min=ToGrey(Fbmp.GetPixel(x,y-1));
                      if (min>=ToGrey(Fbmp.GetPixel(x-1,y))) min=ToGrey(Fbmp.GetPixel(x-1,y));
                      if (min>=ToGrey(Fbmp.GetPixel(x+1,y))) min=ToGrey(Fbmp.GetPixel(x+1,y));
                      if (min>=ToGrey(Fbmp.GetPixel(x,y+1))) min=ToGrey(Fbmp.GetPixel(x,y+1)); 
					// erozja[x,y]=min;
                    			}
                    			 erozja[x,y]=min;
                    }//endfor
                                 
                    }//endromb
							else //kwadrat
							{
							  for (int x=0; x<Fbmp.Width; x++)
                    	for (int y=0;y<Fbmp.Height;y++)
                    		
                    {
                    	//narożniki
                    	if (x==0&&y==0) 
                    	{int oc=ToGrey(Fbmp.GetPixel(x, y));
                      min=oc;
                      if (min>=ToGrey(Fbmp.GetPixel(x+1,y))) min=ToGrey(Fbmp.GetPixel(x+1,y));
                      if (min>=ToGrey(Fbmp.GetPixel(x,y+1))) min=ToGrey(Fbmp.GetPixel(x,y+1)); 
                      if (min>=ToGrey(Fbmp.GetPixel(x+1,y+1))) min=ToGrey(Fbmp.GetPixel(x+1,y+1)); 
                      
                  //    erozja[x,y]=min;
                       	}
                    	
                    	else if (x==0 && y==Fbmp.Height-1)
                    	{
                    	int oc=ToGrey(Fbmp.GetPixel(x, y));
                       min=oc;
        				if (min>=ToGrey(Fbmp.GetPixel(x,y-1))) min=ToGrey(Fbmp.GetPixel(x,y-1));
     				     if (min>=ToGrey(Fbmp.GetPixel(x+1,y))) min=ToGrey(Fbmp.GetPixel(x+1,y));  
        				if (min>=ToGrey(Fbmp.GetPixel(x+1,y-1))) min=ToGrey(Fbmp.GetPixel(x+1,y-1));
     				      //                     erozja[x,y]=min;
                    	}
                    	
                    	else if (x==Fbmp.Width-1 && y==0)
                    		{
                    	int oc=ToGrey(Fbmp.GetPixel(x, y));
                       min=oc;
        				if (min>=ToGrey(Fbmp.GetPixel(x-1,y))) min=ToGrey(Fbmp.GetPixel(x-1,y));
     				     if (min>=ToGrey(Fbmp.GetPixel(x,y+1))) min=ToGrey(Fbmp.GetPixel(x,y+1)); 
     				      if (min>=ToGrey(Fbmp.GetPixel(x-1,y+1))) min=ToGrey(Fbmp.GetPixel(x-1,y+1)); 
     				        //                   erozja[x,y]=min;
                    	}
                    		
                    		else if (x==Fbmp.Width-1 && y==Fbmp.Height-1)
                    		{
                    		int oc=ToGrey(Fbmp.GetPixel(x, y));
                       min=oc;
                         if (min>=ToGrey(Fbmp.GetPixel(x-1,y))) min=ToGrey(Fbmp.GetPixel(x-1,y));
                          if (min>=ToGrey(Fbmp.GetPixel(x,y-1))) min=ToGrey(Fbmp.GetPixel(x,y-1));
                           if (min>=ToGrey(Fbmp.GetPixel(x-1,y-1))) min=ToGrey(Fbmp.GetPixel(x-1,y-1)); 
                     //                           erozja[x,y]=min;
                    		}
                    			
                    		//skrajne bez narożników
                    		
                    		else if (x==0&& y>0 && y<Fbmp.Height-1)//górny rząd
                    		{
                    			int oc=ToGrey(Fbmp.GetPixel(x, y));
                       min=oc;
                        if (min>=ToGrey(Fbmp.GetPixel(x,y-1))) min=ToGrey(Fbmp.GetPixel(x,y-1));
                      if (min>=ToGrey(Fbmp.GetPixel(x+1,y))) min=ToGrey(Fbmp.GetPixel(x+1,y));
                      if (min>=ToGrey(Fbmp.GetPixel(x,y+1))) min=ToGrey(Fbmp.GetPixel(x,y+1)); 
                      if (min>=ToGrey(Fbmp.GetPixel(x+1,y-1))) min=ToGrey(Fbmp.GetPixel(x+1,y-1));
                      if (min>=ToGrey(Fbmp.GetPixel(x+1,y+1))) min=ToGrey(Fbmp.GetPixel(x+1,y+1));
                     //                       erozja[x,y]=min;
                    		}
                    		
                    		else if (x==Fbmp.Width-1&& y>0 && y<Fbmp.Height-1)//dolny rząd
                    		{
                    		 int oc=ToGrey(Fbmp.GetPixel(x, y));
                      	 min=oc;
                      if (min>=ToGrey(Fbmp.GetPixel(x,y-1))) min=ToGrey(Fbmp.GetPixel(x,y-1));
                      if (min>=ToGrey(Fbmp.GetPixel(x-1,y))) min=ToGrey(Fbmp.GetPixel(x-1,y));
                      if (min>=ToGrey(Fbmp.GetPixel(x,y+1))) min=ToGrey(Fbmp.GetPixel(x,y+1)); 
                      if (min>=ToGrey(Fbmp.GetPixel(x-1,y-1))) min=ToGrey(Fbmp.GetPixel(x-1,y-1));
                      if (min>=ToGrey(Fbmp.GetPixel(x-1,y+1))) min=ToGrey(Fbmp.GetPixel(x-1,y+1));
					//	 erozja[x,y]=min;
                    		}
                    		
                    		else if (y==0 && x>0 && x<Fbmp.Width-1)//pierwsza kolumna
                    		{ int oc=ToGrey(Fbmp.GetPixel(x, y));
                    	   min=oc;
                    		  if (min>=ToGrey(Fbmp.GetPixel(x-1,y))) min=ToGrey(Fbmp.GetPixel(x-1,y));
                      if (min>=ToGrey(Fbmp.GetPixel(x+1,y))) min=ToGrey(Fbmp.GetPixel(x+1,y));
                      if (min>=ToGrey(Fbmp.GetPixel(x,y+1))) min=ToGrey(Fbmp.GetPixel(x,y+1)); 
                      if (min>=ToGrey(Fbmp.GetPixel(x-1,y+1))) min=ToGrey(Fbmp.GetPixel(x-1,y+1));
                      if (min>=ToGrey(Fbmp.GetPixel(x+1,y+1))) min=ToGrey(Fbmp.GetPixel(x+1,y+1));
					// erozja[x,y]=min;
                    		
                    		}
                    		else if (y==Fbmp.Height-1 &&  x>0 && x<Fbmp.Width-1) //ostatnia kolumna
                    		{
                    		int oc=ToGrey(Fbmp.GetPixel(x, y));
                       min=oc;
                      if (min>=ToGrey(Fbmp.GetPixel(x,y-1))) min=ToGrey(Fbmp.GetPixel(x,y-1));
                      if (min>=ToGrey(Fbmp.GetPixel(x-1,y))) min=ToGrey(Fbmp.GetPixel(x-1,y));
                      if (min>=ToGrey(Fbmp.GetPixel(x+1,y))) min=ToGrey(Fbmp.GetPixel(x+1,y));
                      if (min>=ToGrey(Fbmp.GetPixel(x-1,y-1))) min=ToGrey(Fbmp.GetPixel(x-1,y-1));
                      if (min>=ToGrey(Fbmp.GetPixel(x+1,y-1))) min=ToGrey(Fbmp.GetPixel(x+1,y-1));
                   // 	erozja[x,y]=min;	
                    		}
                    		//nieskrajne
                    			else
                    			{     int oc=ToGrey(Fbmp.GetPixel(x, y));
                       min=oc;
                       if (min>=ToGrey(Fbmp.GetPixel(x,y-1))) min=ToGrey(Fbmp.GetPixel(x,y-1));
                      if (min>=ToGrey(Fbmp.GetPixel(x-1,y))) min=ToGrey(Fbmp.GetPixel(x-1,y));
                      if (min>=ToGrey(Fbmp.GetPixel(x+1,y))) min=ToGrey(Fbmp.GetPixel(x+1,y));
                      if (min>=ToGrey(Fbmp.GetPixel(x,y+1))) min=ToGrey(Fbmp.GetPixel(x,y+1)); 
                      if (min>=ToGrey(Fbmp.GetPixel(x-1,y-1))) min=ToGrey(Fbmp.GetPixel(x-1,y-1));					  
                      if (min>=ToGrey(Fbmp.GetPixel(x-1,y+1))) min=ToGrey(Fbmp.GetPixel(x-1,y+1));
					  if (min>=ToGrey(Fbmp.GetPixel(x+1,y-1))) min=ToGrey(Fbmp.GetPixel(x+1,y-1));
					  if (min>=ToGrey(Fbmp.GetPixel(x+1,y+1))) min=ToGrey(Fbmp.GetPixel(x+1,y+1));
				
                    			}	 erozja[x,y]=min;
                    }//endfor
                      
							} //end kwadrat

                    	 for (int x=0; x<Fbmp.Width; x++)
                    	for (int y=0;y<Fbmp.Height;y++)
                   {
                   	  Color nc = Color.FromArgb(erozja[x,y], erozja[x,y], erozja[x,y], erozja[x,y]);                      
                    	 Fbmp.SetPixel(x, y, nc);
                   }
                    }//end duplikuje
                    
                    else //ustawia na 0
                    {
                    	int [,] erozja=new int[bmp.Width,bmp.Height];
                    	if(wzorzec==1)//romb
                    	{
                    		int min;
                    	for (int x=0; x<Fbmp.Width; x++)
                    	for (int y=0;y<Fbmp.Height;y++)
                    	    	{
                    		if ((x==0)|| (y==0)||(x>Fbmp.Width-2)||(y>Fbmp.Height-2)  )
                    		{ min=0;}
                    		else
                    		{
                    		int oc=ToGrey(Fbmp.GetPixel(x, y));
                       min=oc;
                  	  if (min>=ToGrey(Fbmp.GetPixel(x,y-1))) min=ToGrey(Fbmp.GetPixel(x,y-1));
                      if (min>=ToGrey(Fbmp.GetPixel(x-1,y))) min=ToGrey(Fbmp.GetPixel(x-1,y));
                      if (min>=ToGrey(Fbmp.GetPixel(x+1,y))) min=ToGrey(Fbmp.GetPixel(x+1,y));
                      if (min>=ToGrey(Fbmp.GetPixel(x,y+1))) min=ToGrey(Fbmp.GetPixel(x,y+1)); 
                    		}
                    	erozja[x,y]=min;
                    	}
                    			
                    	}//end romb
                    	else //kwadrat
                    	{
                    	int min;
                    	for (int x=0; x<Fbmp.Width; x++)
                    	for (int y=0;y<Fbmp.Height;y++)
                    	    	{
                    		if ((x-1<0)|| (y-1<0)||(x>Fbmp.Width-2)||(y>Fbmp.Height-2)  )
                    		{ min=0;}
                    		else
                    		{
                    		int oc=ToGrey(Fbmp.GetPixel(x, y));
                       min=oc;
           if (min>=ToGrey(Fbmp.GetPixel(x,y-1))) min=ToGrey(Fbmp.GetPixel(x,y-1));
                      if (min>=ToGrey(Fbmp.GetPixel(x-1,y))) min=ToGrey(Fbmp.GetPixel(x-1,y));
                      if (min>=ToGrey(Fbmp.GetPixel(x+1,y))) min=ToGrey(Fbmp.GetPixel(x+1,y));
                      if (min>=ToGrey(Fbmp.GetPixel(x,y+1))) min=ToGrey(Fbmp.GetPixel(x,y+1)); 
                      if (min>=ToGrey(Fbmp.GetPixel(x-1,y-1))) min=ToGrey(Fbmp.GetPixel(x-1,y-1));					  
                      if (min>=ToGrey(Fbmp.GetPixel(x-1,y+1))) min=ToGrey(Fbmp.GetPixel(x-1,y+1));
					  if (min>=ToGrey(Fbmp.GetPixel(x+1,y-1))) min=ToGrey(Fbmp.GetPixel(x+1,y-1));
					  if (min>=ToGrey(Fbmp.GetPixel(x+1,y+1))) min=ToGrey(Fbmp.GetPixel(x+1,y+1));
                    		
                    		}
                    	erozja[x,y]=min;
                    	}
                    	}//end kwadrat
                      for (int x=0; x<Fbmp.Width; x++)
                    	for (int y=0;y<Fbmp.Height;y++)
                   {
                   	  Color nc = Color.FromArgb(erozja[x,y], erozja[x,y], erozja[x,y], erozja[x,y]);                      
                    	 Fbmp.SetPixel(x, y, nc);
                   }
                    }//end ustawia na 0
                    
                  
                    Fbmp.UnlockBits();
            Benchmark.End();
            toolStripProgressBar1.Value = toolStripProgressBar1.Maximum;
            double seconds = Benchmark.GetSeconds();
            
            toolStripStatusLabel1.Text = "Czas Wykonania Erozji:" + seconds.ToString();
            
           return bmp;
        
        }
        
        private int ToGrey(Color px)
        {
        	return (int)((px.R * 0.3) + (px.G * 0.59) + (px.B * 0.11));
        }
        
        public Bitmap Dylatacja(Bitmap bmp,  System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1, System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1, int wzorzec, int skrajne)
        {
        Benchmark.Start();
            MyFBitmap Fbmp = new MyFBitmap(bmp);
            Fbmp.LockBits();
                    toolStripProgressBar1.Maximum = Fbmp.Width;
                    
                    if (skrajne==1)//olewa krawędzie
                    {  
                    	
                    	int [,] erozja=new int[bmp.Width,bmp.Height];
                    	int max;
                    if (wzorzec==1)//romb
                    {
                    for (int x=1; x<Fbmp.Width-1; x++)
                    	for (int y=1;y<Fbmp.Height-1;y++)
                    		
                    {
                      int oc=ToGrey(Fbmp.GetPixel(x, y));
                       max=oc;
                      if (max<=ToGrey(Fbmp.GetPixel(x,y-1))) max=ToGrey(Fbmp.GetPixel(x,y-1));
                      if (max<=ToGrey(Fbmp.GetPixel(x-1,y))) max=ToGrey(Fbmp.GetPixel(x-1,y));
                      if (max<=ToGrey(Fbmp.GetPixel(x+1,y))) max=ToGrey(Fbmp.GetPixel(x+1,y));
                      if (max<=ToGrey(Fbmp.GetPixel(x,y+1))) max=ToGrey(Fbmp.GetPixel(x,y+1));    
 		         
                  erozja[x,y]=max;
                    }
                                 
                    }//endif
                    
                    else //kwadrat
                    {
                   
                    for (int x=1; x<Fbmp.Width-1; x++)
                    	for (int y=1;y<Fbmp.Height-1;y++)
                    		
                    {
                      int oc=ToGrey(Fbmp.GetPixel(x, y));
                       max=oc;
                      if (max<=ToGrey(Fbmp.GetPixel(x,y-1))) max=ToGrey(Fbmp.GetPixel(x,y-1));
                      if (max<=ToGrey(Fbmp.GetPixel(x-1,y))) max=ToGrey(Fbmp.GetPixel(x-1,y));
                      if (max<=ToGrey(Fbmp.GetPixel(x+1,y))) max=ToGrey(Fbmp.GetPixel(x+1,y));
                      if (max<=ToGrey(Fbmp.GetPixel(x,y+1))) max=ToGrey(Fbmp.GetPixel(x,y+1)); 
                      if (max<=ToGrey(Fbmp.GetPixel(x-1,y-1))) max=ToGrey(Fbmp.GetPixel(x-1,y-1));					  
                      if (max<=ToGrey(Fbmp.GetPixel(x-1,y+1))) max=ToGrey(Fbmp.GetPixel(x-1,y+1));
					  if (max<=ToGrey(Fbmp.GetPixel(x+1,y-1))) max=ToGrey(Fbmp.GetPixel(x+1,y-1));
					  if (max<=ToGrey(Fbmp.GetPixel(x+1,y+1))) max=ToGrey(Fbmp.GetPixel(x+1,y+1));
 			
              erozja[x,y]=max;
                    }
                    }//end kwadrat
                    
                   for (int x=1; x<Fbmp.Width-1; x++)
                    	for (int y=1;y<Fbmp.Height-1;y++)
                   {
                   	  Color nc = Color.FromArgb(erozja[x,y], erozja[x,y], erozja[x,y], erozja[x,y]);                      
                    	 Fbmp.SetPixel(x, y, nc);
                   }
                    } //end olewa krawedzie
                    
                    else if (skrajne==2) //duplikuje
                    {
                    		int [,] erozja=new int[bmp.Width,bmp.Height];
                    	int max;
                    if (wzorzec==1)//romb
                    {
                    	
                    for (int x=0; x<Fbmp.Width; x++)
                    	for (int y=0;y<Fbmp.Height;y++)
                    		
                    {
                    	//narożniki
                    	if (x==0&&y==0) 
                    	{int oc=ToGrey(Fbmp.GetPixel(x, y));
                      max=oc;
                      if (max<=ToGrey(Fbmp.GetPixel(x+1,y))) max=ToGrey(Fbmp.GetPixel(x+1,y));
                      if (max<=ToGrey(Fbmp.GetPixel(x,y+1))) max=ToGrey(Fbmp.GetPixel(x,y+1)); 
                  //    erozja[x,y]=min;
                       	}
                    	
                    	else if (x==0 && y==Fbmp.Height-1)
                    	{
                    	int oc=ToGrey(Fbmp.GetPixel(x, y));
                       max=oc;
        				if (max<=ToGrey(Fbmp.GetPixel(x,y-1))) max=ToGrey(Fbmp.GetPixel(x,y-1));
     				     if (max<=ToGrey(Fbmp.GetPixel(x+1,y))) max=ToGrey(Fbmp.GetPixel(x+1,y)); 
     				 //                          erozja[x,y]=min;
                    	}
                    	
                    	else if (x==Fbmp.Width-1 && y==0)
                    		{
                    	int oc=ToGrey(Fbmp.GetPixel(x, y));
                       max=oc;
        				if (max<=ToGrey(Fbmp.GetPixel(x-1,y))) max=ToGrey(Fbmp.GetPixel(x-1,y));
     				     if (max<=ToGrey(Fbmp.GetPixel(x,y+1))) max=ToGrey(Fbmp.GetPixel(x,y+1)); 
     				 //                          erozja[x,y]=min;
                    	}
                    		
                    		else if (x==Fbmp.Width-1 && y==Fbmp.Height-1)
                    		{
                    		int oc=ToGrey(Fbmp.GetPixel(x, y));
                       max=oc;
                         if (max<=ToGrey(Fbmp.GetPixel(x-1,y))) max=ToGrey(Fbmp.GetPixel(x-1,y));
                          if (max<=ToGrey(Fbmp.GetPixel(x,y-1))) max=ToGrey(Fbmp.GetPixel(x,y-1));
                     //                           erozja[x,y]=min;
                    		}
                    			
                    		//skrajne bez narożników
                    		
                    		else if (x==0&& y>0 && y<Fbmp.Height-1)//górny rząd
                    		{
                    			int oc=ToGrey(Fbmp.GetPixel(x, y));
                       max=oc;
                        if (max<=ToGrey(Fbmp.GetPixel(x,y-1))) max=ToGrey(Fbmp.GetPixel(x,y-1));
                      if (max<=ToGrey(Fbmp.GetPixel(x+1,y))) max=ToGrey(Fbmp.GetPixel(x+1,y));
                      if (max<=ToGrey(Fbmp.GetPixel(x,y+1))) max=ToGrey(Fbmp.GetPixel(x,y+1)); 
                      //                      erozja[x,y]=min;
                    		}
                    		
                    		else if (x==Fbmp.Width-1&& y>0 && y<Fbmp.Height-1)//dolny rząd
                    		{
                    		 int oc=ToGrey(Fbmp.GetPixel(x, y));
                       max=oc;
                      if (max<=ToGrey(Fbmp.GetPixel(x,y-1))) max=ToGrey(Fbmp.GetPixel(x,y-1));
                      if (max<=ToGrey(Fbmp.GetPixel(x-1,y))) max=ToGrey(Fbmp.GetPixel(x-1,y));
                      if (max<=ToGrey(Fbmp.GetPixel(x,y+1))) max=ToGrey(Fbmp.GetPixel(x,y+1)); 
					// erozja[x,y]=min;
                    		}
                    		
                    		else if (y==0 && x>0 && x<Fbmp.Width-1)//pierwsza kolumna
                    		{ int oc=ToGrey(Fbmp.GetPixel(x, y));
                       max=oc;
                    		  if (max<=ToGrey(Fbmp.GetPixel(x-1,y))) max=ToGrey(Fbmp.GetPixel(x-1,y));
                      if (max<=ToGrey(Fbmp.GetPixel(x+1,y))) max=ToGrey(Fbmp.GetPixel(x+1,y));
                      if (max<=ToGrey(Fbmp.GetPixel(x,y+1))) max=ToGrey(Fbmp.GetPixel(x,y+1)); 
					// erozja[x,y]=min;
                    		
                    		}
                    		else if (y==Fbmp.Height-1 &&  x>0 && x<Fbmp.Width-1) //ostatnia kolumna
                    		{
                    		int oc=ToGrey(Fbmp.GetPixel(x, y));
                       max=oc;
                      if (max<=ToGrey(Fbmp.GetPixel(x,y-1))) max=ToGrey(Fbmp.GetPixel(x,y-1));
                      if (max<=ToGrey(Fbmp.GetPixel(x-1,y))) max=ToGrey(Fbmp.GetPixel(x-1,y));
                      if (max<=ToGrey(Fbmp.GetPixel(x+1,y))) max=ToGrey(Fbmp.GetPixel(x+1,y));
                    	//erozja[x,y]=min;	
                    		}
                    		//nieskrajne
                    			else
                    			{     int oc=ToGrey(Fbmp.GetPixel(x, y));
                       max=oc;
                      if (max<=ToGrey(Fbmp.GetPixel(x,y-1))) max=ToGrey(Fbmp.GetPixel(x,y-1));
                      if (max<=ToGrey(Fbmp.GetPixel(x-1,y))) max=ToGrey(Fbmp.GetPixel(x-1,y));
                      if (max<=ToGrey(Fbmp.GetPixel(x+1,y))) max=ToGrey(Fbmp.GetPixel(x+1,y));
                      if (max<=ToGrey(Fbmp.GetPixel(x,y+1))) max=ToGrey(Fbmp.GetPixel(x,y+1)); 
					// erozja[x,y]=min;
                    			}
                    			 erozja[x,y]=max;
                    }//endfor
                                 
                    }//endromb
							else //kwadrat
							{
							  for (int x=0; x<Fbmp.Width; x++)
                    	for (int y=0;y<Fbmp.Height;y++)
                    		
                    {
                    	//narożniki
                    	if (x==0&&y==0) 
                    	{int oc=ToGrey(Fbmp.GetPixel(x, y));
                      max=oc;
                      if (max<=ToGrey(Fbmp.GetPixel(x+1,y))) max=ToGrey(Fbmp.GetPixel(x+1,y));
                      if (max<=ToGrey(Fbmp.GetPixel(x,y+1))) max=ToGrey(Fbmp.GetPixel(x,y+1)); 
                      if (max<=ToGrey(Fbmp.GetPixel(x+1,y+1))) max=ToGrey(Fbmp.GetPixel(x+1,y+1)); 
                      
                  //    erozja[x,y]=min;
                       	}
                    	
                    	else if (x==0 && y==Fbmp.Height-1)
                    	{
                    	int oc=ToGrey(Fbmp.GetPixel(x, y));
                       max=oc;
        				if (max<=ToGrey(Fbmp.GetPixel(x,y-1))) max=ToGrey(Fbmp.GetPixel(x,y-1));
     				     if (max<=ToGrey(Fbmp.GetPixel(x+1,y))) max=ToGrey(Fbmp.GetPixel(x+1,y));  
        				if (max<=ToGrey(Fbmp.GetPixel(x+1,y-1))) max=ToGrey(Fbmp.GetPixel(x+1,y-1));
     				      //                     erozja[x,y]=min;
                    	}
                    	
                    	else if (x==Fbmp.Width-1 && y==0)
                    		{
                    	int oc=ToGrey(Fbmp.GetPixel(x, y));
                       max=oc;
        				if (max<=ToGrey(Fbmp.GetPixel(x-1,y))) max=ToGrey(Fbmp.GetPixel(x-1,y));
     				     if (max<=ToGrey(Fbmp.GetPixel(x,y+1))) max=ToGrey(Fbmp.GetPixel(x,y+1)); 
     				      if (max<=ToGrey(Fbmp.GetPixel(x-1,y+1))) max=ToGrey(Fbmp.GetPixel(x-1,y+1)); 
     				        //                   erozja[x,y]=min;
                    	}
                    		
                    		else if (x==Fbmp.Width-1 && y==Fbmp.Height-1)
                    		{
                    		int oc=ToGrey(Fbmp.GetPixel(x, y));
                       max=oc;
                         if (max<=ToGrey(Fbmp.GetPixel(x-1,y))) max=ToGrey(Fbmp.GetPixel(x-1,y));
                          if (max<=ToGrey(Fbmp.GetPixel(x,y-1))) max=ToGrey(Fbmp.GetPixel(x,y-1));
                           if (max<=ToGrey(Fbmp.GetPixel(x-1,y-1))) max=ToGrey(Fbmp.GetPixel(x-1,y-1)); 
                     //                           erozja[x,y]=min;
                    		}
                    			
                    		//skrajne bez narożników
                    		
                    		else if (x==0&& y>0 && y<Fbmp.Height-1)//górny rząd
                    		{
                    			int oc=ToGrey(Fbmp.GetPixel(x, y));
                       max=oc;
                        if (max<=ToGrey(Fbmp.GetPixel(x,y-1))) max=ToGrey(Fbmp.GetPixel(x,y-1));
                      if (max<=ToGrey(Fbmp.GetPixel(x+1,y))) max=ToGrey(Fbmp.GetPixel(x+1,y));
                      if (max<=ToGrey(Fbmp.GetPixel(x,y+1))) max=ToGrey(Fbmp.GetPixel(x,y+1)); 
                      if (max<=ToGrey(Fbmp.GetPixel(x+1,y-1))) max=ToGrey(Fbmp.GetPixel(x+1,y-1));
                      if (max<=ToGrey(Fbmp.GetPixel(x+1,y+1))) max=ToGrey(Fbmp.GetPixel(x+1,y+1));
                     //                       erozja[x,y]=min;
                    		}
                    		
                    		else if (x==Fbmp.Width-1&& y>0 && y<Fbmp.Height-1)//dolny rząd
                    		{
                    		 int oc=ToGrey(Fbmp.GetPixel(x, y));
                      	 max=oc;
                      if (max<=ToGrey(Fbmp.GetPixel(x,y-1))) max=ToGrey(Fbmp.GetPixel(x,y-1));
                      if (max<=ToGrey(Fbmp.GetPixel(x-1,y))) max=ToGrey(Fbmp.GetPixel(x-1,y));
                      if (max<=ToGrey(Fbmp.GetPixel(x,y+1))) max=ToGrey(Fbmp.GetPixel(x,y+1)); 
                      if (max<=ToGrey(Fbmp.GetPixel(x-1,y-1))) max=ToGrey(Fbmp.GetPixel(x-1,y-1));
                      if (max<=ToGrey(Fbmp.GetPixel(x-1,y+1))) max=ToGrey(Fbmp.GetPixel(x-1,y+1));
					//	 erozja[x,y]=min;
                    		}
                    		
                    		else if (y==0 && x>0 && x<Fbmp.Width-1)//pierwsza kolumna
                    		{ int oc=ToGrey(Fbmp.GetPixel(x, y));
                    	   max=oc;
                    		  if (max<=ToGrey(Fbmp.GetPixel(x-1,y))) max=ToGrey(Fbmp.GetPixel(x-1,y));
                      if (max<=ToGrey(Fbmp.GetPixel(x+1,y))) max=ToGrey(Fbmp.GetPixel(x+1,y));
                      if (max<=ToGrey(Fbmp.GetPixel(x,y+1))) max=ToGrey(Fbmp.GetPixel(x,y+1)); 
                      if (max<=ToGrey(Fbmp.GetPixel(x-1,y+1))) max=ToGrey(Fbmp.GetPixel(x-1,y+1));
                      if (max<=ToGrey(Fbmp.GetPixel(x+1,y+1))) max=ToGrey(Fbmp.GetPixel(x+1,y+1));
					// erozja[x,y]=min;
                    		
                    		}
                    		else if (y==Fbmp.Height-1 &&  x>0 && x<Fbmp.Width-1) //ostatnia kolumna
                    		{
                    		int oc=ToGrey(Fbmp.GetPixel(x, y));
                       max=oc;
                      if (max<=ToGrey(Fbmp.GetPixel(x,y-1))) max=ToGrey(Fbmp.GetPixel(x,y-1));
                      if (max<=ToGrey(Fbmp.GetPixel(x-1,y))) max=ToGrey(Fbmp.GetPixel(x-1,y));
                      if (max<=ToGrey(Fbmp.GetPixel(x+1,y))) max=ToGrey(Fbmp.GetPixel(x+1,y));
                      if (max<=ToGrey(Fbmp.GetPixel(x-1,y-1))) max=ToGrey(Fbmp.GetPixel(x-1,y-1));
                      if (max<=ToGrey(Fbmp.GetPixel(x+1,y-1))) max=ToGrey(Fbmp.GetPixel(x+1,y-1));
                   // 	erozja[x,y]=min;	
                    		}
                    		//nieskrajne
                    			else
                    			{     int oc=ToGrey(Fbmp.GetPixel(x, y));
                       max=oc;
                       if (max<=ToGrey(Fbmp.GetPixel(x,y-1))) max=ToGrey(Fbmp.GetPixel(x,y-1));
                      if (max<=ToGrey(Fbmp.GetPixel(x-1,y))) max=ToGrey(Fbmp.GetPixel(x-1,y));
                      if (max<=ToGrey(Fbmp.GetPixel(x+1,y))) max=ToGrey(Fbmp.GetPixel(x+1,y));
                      if (max<=ToGrey(Fbmp.GetPixel(x,y+1))) max=ToGrey(Fbmp.GetPixel(x,y+1)); 
                      if (max<=ToGrey(Fbmp.GetPixel(x-1,y-1))) max=ToGrey(Fbmp.GetPixel(x-1,y-1));					  
                      if (max<=ToGrey(Fbmp.GetPixel(x-1,y+1))) max=ToGrey(Fbmp.GetPixel(x-1,y+1));
					  if (max<=ToGrey(Fbmp.GetPixel(x+1,y-1))) max=ToGrey(Fbmp.GetPixel(x+1,y-1));
					  if (max<=ToGrey(Fbmp.GetPixel(x+1,y+1))) max=ToGrey(Fbmp.GetPixel(x+1,y+1));
				
                    			}	 erozja[x,y]=max;
                    }//endfor
                      
							} //end kwadrat

                    	 for (int x=0; x<Fbmp.Width; x++)
                    	for (int y=0;y<Fbmp.Height;y++)
                   {
                   	  Color nc = Color.FromArgb(erozja[x,y], erozja[x,y], erozja[x,y], erozja[x,y]);                      
                    	 Fbmp.SetPixel(x, y, nc);
                   }
                    }//end duplikuje
                    
                    else //ustawia na 0
                    {
                    	int [,] erozja=new int[bmp.Width,bmp.Height];
                    	if(wzorzec==1)//romb
                    	{
                    		int max;
                    	for (int x=0; x<Fbmp.Width; x++)
                    	for (int y=0;y<Fbmp.Height;y++)
                    	    	{
                    		if ((x==0)|| (y==0)||(x>Fbmp.Width-2)||(y>Fbmp.Height-2)  )
                    		{ max=255;}
                    		else
                    		{
                    		int oc=ToGrey(Fbmp.GetPixel(x, y));
                       max=oc;
                  	  if (max<=ToGrey(Fbmp.GetPixel(x,y-1))) max=ToGrey(Fbmp.GetPixel(x,y-1));
                      if (max<=ToGrey(Fbmp.GetPixel(x-1,y))) max=ToGrey(Fbmp.GetPixel(x-1,y));
                      if (max<=ToGrey(Fbmp.GetPixel(x+1,y))) max=ToGrey(Fbmp.GetPixel(x+1,y));
                      if (max<=ToGrey(Fbmp.GetPixel(x,y+1))) max=ToGrey(Fbmp.GetPixel(x,y+1)); 
                    		}
                    	erozja[x,y]=max;
                    	}
                    			
                    	}//end romb
                    	else //kwadrat
                    	{
                    	int max;
                    	for (int x=0; x<Fbmp.Width; x++)
                    	for (int y=0;y<Fbmp.Height;y++)
                    	    	{
                    		if ((x-1<0)|| (y-1<0)||(x>Fbmp.Width-2)||(y>Fbmp.Height-2)  )
                    		{ max=255;}
                    		else
                    		{
                    		int oc=ToGrey(Fbmp.GetPixel(x, y));
                       max=oc;
           if (max<=ToGrey(Fbmp.GetPixel(x,y-1))) max=ToGrey(Fbmp.GetPixel(x,y-1));
                      if (max<=ToGrey(Fbmp.GetPixel(x-1,y))) max=ToGrey(Fbmp.GetPixel(x-1,y));
                      if (max<=ToGrey(Fbmp.GetPixel(x+1,y))) max=ToGrey(Fbmp.GetPixel(x+1,y));
                      if (max<=ToGrey(Fbmp.GetPixel(x,y+1))) max=ToGrey(Fbmp.GetPixel(x,y+1)); 
                      if (max<=ToGrey(Fbmp.GetPixel(x-1,y-1))) max=ToGrey(Fbmp.GetPixel(x-1,y-1));					  
                      if (max<=ToGrey(Fbmp.GetPixel(x-1,y+1))) max=ToGrey(Fbmp.GetPixel(x-1,y+1));
					  if (max<=ToGrey(Fbmp.GetPixel(x+1,y-1))) max=ToGrey(Fbmp.GetPixel(x+1,y-1));
					  if (max<=ToGrey(Fbmp.GetPixel(x+1,y+1))) max=ToGrey(Fbmp.GetPixel(x+1,y+1));
                    		
                    		}
                    	erozja[x,y]=max;
                    	}
                    	}//end kwadrat
                      for (int x=0; x<Fbmp.Width; x++)
                    	for (int y=0;y<Fbmp.Height;y++)
                   {
                   	  Color nc = Color.FromArgb(erozja[x,y], erozja[x,y], erozja[x,y], erozja[x,y]);                      
                    	 Fbmp.SetPixel(x, y, nc);
                   }
                    }//end ustawia na 0
                    
                  
                    Fbmp.UnlockBits();
            Benchmark.End();
            toolStripProgressBar1.Value = toolStripProgressBar1.Maximum;
            double seconds = Benchmark.GetSeconds();
            
            toolStripStatusLabel1.Text = "Czas Wykonania Erozji:" + seconds.ToString();
           return bmp;
        
        }

        public Bitmap Otwarcie (Bitmap bmp,  System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1, System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1, int wzorzec, int skrajne)
        {
     
                    if (wzorzec==1)//romb
                    { Erozja(bmp, toolStripStatusLabel1, toolStripProgressBar1, 1, skrajne);
                    	Dylatacja(bmp, toolStripStatusLabel1, toolStripProgressBar1, 1, skrajne);
                    }
                    
                    else //kwadrat
                    {
                    Erozja(bmp, toolStripStatusLabel1, toolStripProgressBar1, 2, skrajne);
                    	Dylatacja(bmp, toolStripStatusLabel1, toolStripProgressBar1, 2, skrajne);
                    }//endkwadrat
               
       return bmp;
        }
        
        public Bitmap Zamkniecie (Bitmap bmp,  System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1, System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1, int wzorzec, int skrajne)
        {
        	   if (wzorzec==1)//romb
                    { 
                    	Dylatacja(bmp, toolStripStatusLabel1, toolStripProgressBar1, 1, skrajne);
                    	Erozja(bmp, toolStripStatusLabel1, toolStripProgressBar1, 1, skrajne);
                    }
                    
                    else //kwadrat
                    { Dylatacja(bmp, toolStripStatusLabel1, toolStripProgressBar1, 2, skrajne);
                    	Erozja(bmp, toolStripStatusLabel1, toolStripProgressBar1, 2, skrajne);
                    	}//endkwadrat
               
       return bmp;
        	
        	
        }
	
        public Bitmap Filtracja(Bitmap bmp,  System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1, System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1, int[,]maska, int skrajne)

        {
          Benchmark.Start();
            MyFBitmap Fbmp = new MyFBitmap(bmp);
            Fbmp.LockBits();
           
            int [,] pomBmp =new int[bmp.Width,bmp.Height];
            int divisor=0;
            
            for (int i=0;i<3;i++)
            	for (int j=0;j<3;j++)
            {
            	divisor+=maska[i,j];
            }
            if (divisor==0) divisor=1;
            		
            
            if (skrajne==1)//olej krawędzie
            {
            
            for (int x=1; x<Fbmp.Width-1; x++)
                    	for (int y=1;y<Fbmp.Height-1;y++)
            	{
            	   //int oc=ToGrey(Fbmp.GetPixel(x, y));
            	   pomBmp[x,y]=(ToGrey(Fbmp.GetPixel(x-1,y-1))*maska[0,0]+
            	    ToGrey(Fbmp.GetPixel(x-1,y))*maska[0,1]+
            	    ToGrey(Fbmp.GetPixel(x-1,y+1))*maska[0,2]+
            	   	ToGrey(Fbmp.GetPixel(x,y-1))*maska[1,0]+
            	   	ToGrey(Fbmp.GetPixel(x,y))*maska[1,1]+
            	   	ToGrey(Fbmp.GetPixel(x,y+1))*maska[1,2]+
            	   	ToGrey(Fbmp.GetPixel(x+1,y-1))*maska[2,0]+
            	   	ToGrey(Fbmp.GetPixel(x+1,y))*maska[2,1]+
            	   	ToGrey(Fbmp.GetPixel(x+1,y+1))*maska[2,2])/divisor;
           	   
            	}
                  
            }//end olejkrawędzie
            
            else //wykorzystaj istniejące
            {
            
							  for (int x=0; x<Fbmp.Width; x++)
                    	for (int y=0;y<Fbmp.Height;y++)
                    		
                    {
                    	//narożniki
                    	if (x==0&&y==0) 
                    	{ pomBmp[x,y]=(
            	   	ToGrey(Fbmp.GetPixel(x,y))*maska[1,1]+
            	   	ToGrey(Fbmp.GetPixel(x,y+1))*maska[1,2]+
            	   	ToGrey(Fbmp.GetPixel(x+1,y))*maska[2,1]+
            	   	ToGrey(Fbmp.GetPixel(x+1,y+1))*maska[2,2])/divisor;
                       	}
                    	
                    	else if (x==0 && y==Fbmp.Height-1)
                    	{
                    pomBmp[x,y]=(        	    
            	   	ToGrey(Fbmp.GetPixel(x,y-1))*maska[1,0]+
            	   	ToGrey(Fbmp.GetPixel(x,y))*maska[1,1]+
            	   	ToGrey(Fbmp.GetPixel(x+1,y-1))*maska[2,0]+
            	   	ToGrey(Fbmp.GetPixel(x+1,y))*maska[2,1])
            	   	/divisor;
     				      //                     
                    	}
                    	
                    	else if (x==Fbmp.Width-1 && y==0)
                    		{
                    	pomBmp[x,y]=(        	    
            	   	ToGrey(Fbmp.GetPixel(x-1,y))*maska[0,1]+
            	   	ToGrey(Fbmp.GetPixel(x,y))*maska[1,1]+
            	   	ToGrey(Fbmp.GetPixel(x,y+1))*maska[0,2]+
            	   	ToGrey(Fbmp.GetPixel(x,y+1))*maska[1,2])
            	   	/divisor;
                    	}
                    		
                    		else if (x==Fbmp.Width-1 && y==Fbmp.Height-1)
                    		{
                    		pomBmp[x,y]=(        	    
            	   	ToGrey(Fbmp.GetPixel(x-1,y))*maska[0,1]+
            	   	ToGrey(Fbmp.GetPixel(x,y))*maska[1,1]+
            	   	ToGrey(Fbmp.GetPixel(x,y-1))*maska[1,0]+
            	   	ToGrey(Fbmp.GetPixel(x-1,y-1))*maska[0,0])
            	   	/divisor;
                    		}
                    			
                    		//skrajne bez narożników
                    		
                    		else if (x==0&& y>0 && y<Fbmp.Height-1)//górny rząd
                    		{
                    			pomBmp[x,y]=(ToGrey(Fbmp.GetPixel(x,y-1))*maska[1,0]+
            	   	ToGrey(Fbmp.GetPixel(x,y))*maska[1,1]+
            	   	ToGrey(Fbmp.GetPixel(x,y+1))*maska[1,2]+
            	   	ToGrey(Fbmp.GetPixel(x+1,y-1))*maska[2,0]+
            	   	ToGrey(Fbmp.GetPixel(x+1,y))*maska[2,1]+
            	   	ToGrey(Fbmp.GetPixel(x+1,y+1))*maska[2,2])/divisor;
                    		}
                    		
                    		else if (x==Fbmp.Width-1&& y>0 && y<Fbmp.Height-1)//dolny rząd
                    		{
                    		 pomBmp[x,y]=(ToGrey(Fbmp.GetPixel(x-1,y-1))*maska[0,0]+
            	    ToGrey(Fbmp.GetPixel(x-1,y))*maska[0,1]+
            	    ToGrey(Fbmp.GetPixel(x-1,y+1))*maska[0,2]+
            	   	ToGrey(Fbmp.GetPixel(x,y-1))*maska[1,0]+
            	   	ToGrey(Fbmp.GetPixel(x,y))*maska[1,1]+
            	   	ToGrey(Fbmp.GetPixel(x,y+1))*maska[1,2])/divisor;
                    		}
                    		
                    		else if (y==0 && x>0 && x<Fbmp.Width-1)//pierwsza kolumna
                    		{ pomBmp[x,y]=(ToGrey(Fbmp.GetPixel(x-1,y))*maska[0,1]+
            	    ToGrey(Fbmp.GetPixel(x-1,y+1))*maska[0,2]+
            	   	ToGrey(Fbmp.GetPixel(x,y))*maska[1,1]+
            	   	ToGrey(Fbmp.GetPixel(x,y+1))*maska[1,2]+
            	   	ToGrey(Fbmp.GetPixel(x+1,y))*maska[2,1]+
            	   	ToGrey(Fbmp.GetPixel(x+1,y+1))*maska[2,2])/divisor;
                    		
                    		}
                    		else if (y==Fbmp.Height-1 &&  x>0 && x<Fbmp.Width-1) //ostatnia kolumna
                    		{
                    		pomBmp[x,y]=(ToGrey(Fbmp.GetPixel(x-1,y-1))*maska[0,0]+
            	    ToGrey(Fbmp.GetPixel(x-1,y))*maska[0,1]+
            	   	ToGrey(Fbmp.GetPixel(x,y-1))*maska[1,0]+
            	   	ToGrey(Fbmp.GetPixel(x,y))*maska[1,1]+
            	   	ToGrey(Fbmp.GetPixel(x+1,y-1))*maska[2,0]+
            	   	ToGrey(Fbmp.GetPixel(x+1,y))*maska[2,1])/divisor;
                    		}
                    		//nieskrajne
                    			else
                    			{    pomBmp[x,y]=(ToGrey(Fbmp.GetPixel(x-1,y-1))*maska[0,0]+
            	    ToGrey(Fbmp.GetPixel(x-1,y))*maska[0,1]+
            	    ToGrey(Fbmp.GetPixel(x-1,y+1))*maska[0,2]+
            	   	ToGrey(Fbmp.GetPixel(x,y-1))*maska[1,0]+
            	   	ToGrey(Fbmp.GetPixel(x,y))*maska[1,1]+
            	   	ToGrey(Fbmp.GetPixel(x,y+1))*maska[1,2]+
            	   	ToGrey(Fbmp.GetPixel(x+1,y-1))*maska[2,0]+
            	   	ToGrey(Fbmp.GetPixel(x+1,y))*maska[2,1]+
            	   	ToGrey(Fbmp.GetPixel(x+1,y+1))*maska[2,2])/divisor;
				
                    			}	 
                    }//endfor
                      
							                   	
            
            
            }//end duplikuj
            //skalowanie
        
            	for (int x=0;x<Fbmp.Width;x++)
            		for (int y=0;y<Fbmp.Height;y++)
            	  	{
            	  		if (pomBmp[x,y]<0) pomBmp[x,y]=0;
            	  		if (pomBmp[x,y]>255) pomBmp[x,y]=255;
            	  		
            	  	}
            
            		for (int x=0;x<Fbmp.Width;x++)
            		for (int y=0;y<Fbmp.Height;y++)
            		{
            	Color nc = Color.FromArgb(pomBmp[x,y], pomBmp[x,y], pomBmp[x,y], pomBmp[x,y]);
            	  		Fbmp.SetPixel(x,y,nc);
            		}
            
        	Fbmp.UnlockBits();
            Benchmark.End();
            if (toolStripProgressBar1!=null) { toolStripProgressBar1.Value = toolStripProgressBar1.Maximum;}
            double seconds = Benchmark.GetSeconds();
            
            if (toolStripStatusLabel1 !=null)  toolStripStatusLabel1.Text = "Czas Wykonania Filtracji:" + seconds.ToString();
        	
        	
        return bmp;
        }
       

        public Bitmap Szkieletyzacja(Bitmap bmp,  System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1, System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1)
        {
   			 int[] dx = { 0, 1, 1, 1, 0, -1, -1, -1 };
            int[] dy = { 1, 1, 0, -1, -1, -1, 0, 1 };
Color clr ;
            bool[,] img = new bool[bmp.Width, bmp.Height];
            int W = bmp.Width;
            int H = bmp.Height;
            for (int x = 0; x < bmp.Width; x++)
            	for (int y = 0; y < bmp.Height; y++){
                      clr = bmp.GetPixel(x, y);
                        Byte byPixel = (byte)((30 * clr.R + 59 * clr.G + 11 * clr.B) / 100);
            		

            		img[x, y] = byPixel == 0;
            }
            bool pass = false;
            LinkedList<Point> list;

            do
            {
                pass = !pass;
                list = new LinkedList<Point>();

                for (int x = 1; x < W - 1; ++x)
                {
                    for (int y = 1; y < H - 1; ++y)
                    {
                        if (img[x, y])
                        {
                            int cnt = 0;
                            int hm = 0;
                            bool prev = img[x - 1, y + 1];
                            for (int i = 0; i < 8; ++i)
                            {
                                bool cur = img[x + dx[i], y + dy[i]];
                                hm += cur ? 1 : 0;
                                if (prev && !cur) ++cnt;
                                prev = cur;
                            }
                            if (hm > 1 && hm < 7 && cnt == 1)
                            {
                                if (pass && (!img[x + 1, y] || !img[x, y + 1] || !img[x, y - 1] && !img[x - 1, y]))
                                {
                                    list.AddLast(new Point(x, y));
                                }
                                if (!pass && (!img[x - 1, y] || !img[x, y - 1] || !img[x, y + 1] && !img[x + 1, y]))
                                {
                                    list.AddLast(new Point(x, y));
                                }
                            }
                        }

                    }
                }
                foreach (Point p in list)
                    img[p.X, p.Y] = false;
            } while (list.Count != 0);
         

            Bitmap ret = new Bitmap(W, H);
            for (int x = 0; x < W; ++x)            
            	for (int y = 0; y < H; ++y)   {
            	  byte n = (byte)(img[x, y] ? 0 : 255);
            	  
            	 Color nc = Color.FromArgb(n, n, n);
                       ret.SetPixel(x, y, nc);
                      
            	
            }
                  

            return ret;
}


        public Bitmap Logiczne (Bitmap bmp1, Bitmap bmp2, int operacja)
        {
        
        // Benchmark.Start();
            Bitmap Fbmp = new Bitmap(Math.Min(bmp1.Width,bmp2.Width), Math.Min(bmp1.Height,bmp2.Height) );
           // Fbmp.LockBits();
            
            switch(operacja)
            {
            	case 1: //and
            		
            		for (int x=0;x<Math.Min(bmp1.Width,bmp2.Width);x++)
            			for(int y=0;y<Math.Min(bmp1.Height,bmp2.Height);y++)
            		{
            			Color c1=bmp1.GetPixel(x,y);
            			Color c2=bmp2.GetPixel(x,y);
            			Color nc= Color.FromArgb(255, Math.Min(255, c1.R & c2.R),  Math.Min(255,c1.G& c2.G),  Math.Min(255,c1.B& c2.B));
            			Fbmp.SetPixel(x,y,nc);  
            			
            		}
            		break;
            		
            	case 2: //or
            	
            		for (int x=0;x<Math.Min(bmp1.Width,bmp2.Width);x++)
            			for(int y=0;y<Math.Min(bmp1.Height,bmp2.Height);y++)
            		{
            			Color c1=bmp1.GetPixel(x,y);
            			Color c2=bmp2.GetPixel(x,y);
            			Color nc= Color.FromArgb(255, Math.Max(0, Math.Min(255, c1.R | c2.R)), Math.Max(0, Math.Min(255, c1.G | c2.G)), Math.Max(0, Math.Min(255, c1.B | c2.B)));
            			Fbmp.SetPixel(x,y,nc); 
            			
            		}
            		break;
            		
            	case 3: //xor
            		            		
            		for (int x=0;x<Math.Min(bmp1.Width,bmp2.Width);x++)
            			for(int y=0;y<Math.Min(bmp1.Height,bmp2.Height);y++)
            		{
            			Color c1=bmp1.GetPixel(x,y);
            			Color c2=bmp2.GetPixel(x,y);
            			Color nc= Color.FromArgb(255, Math.Max(0, Math.Min(255, c1.R ^ c2.R)), Math.Max(0, Math.Min(255, c1.G ^ c2.G)), Math.Max(0, Math.Min(255, c1.B ^ c2.B)));
            			Fbmp.SetPixel(x,y,nc); 
            			
            		}
            		break;
            		
            	
            
            }
            ///Fbmp.UnlockBits();
            //Benchmark.End();
            //toolStripProgressBar1.Value = toolStripProgressBar1.Maximum;
         //   double seconds = Benchmark.GetSeconds();
            
         //   toolStripStatusLabel1.Text = "Czas Wykonania Operacji :" + seconds.ToString();
          
            return Fbmp;
            

            }
        
        public Bitmap Turtle (Bitmap bitmap)
        {
        	
        	 MyFBitmap bmp = new MyFBitmap(bitmap);
        	 bmp.LockBits();
        	 
              int[,] rtab = new int[bmp.Width, bmp.Height];
            int[,] gtab = new int[bmp.Width, bmp.Height];
            int[,] btab = new int[bmp.Width, bmp.Height];
            int i, j;
            for (i = 1; i < bmp.Width - 1; i++) {
                for (j = 1; j < bmp.Height - 1; j++) {
            		Color px=bmp.GetPixel(i,j);
            		
                    rtab[i, j] = px.R;
                    gtab[i, j] = px.G;
                    btab[i, j] = px.B;
                }
            }
            
            
            
            int d = 0;
            int pami = 0, pamj = 0, ja = 0, ia = 0;
            int x, y;
            int[] wynik = new int[bmp.Width * bmp.Height];
            int[] droga = new int[bmp.Width * bmp.Height];
            
            
            
            for (i = 1; i < bmp.Height - 1; i++) {
                for (j = 1; j < bmp.Width - 1; j++) {
                    if (rtab[j, i] != 0 || gtab[j, i] != 0 || btab[j, i] != 0) {
                        ja = j;
                        ia = i;
                        pamj = j;
                        pami = i;
                       
                        wynik[bmp.Width * i + j] = 255;
                        goto cont;
                    }
                }
            }
       

           cont:
            j = pamj;
            i = pami - 1;
            wynik[bmp.Width * i + j] = 255;
          
            droga[d] = 1;
            do {
                x = j - pamj;
                y = i - pami;
                pamj = j;
                pami = i;
                d++;
                if (rtab[j, i] != 0 || gtab[j, i] != 0 || btab[j, i] != 0) {
                    if (x == 0 && y == (-1)) {
                        j--;
                        droga[d] = 2;
                    }
                    if (x == 1 && y == 0) {
                        i--;
                        droga[d] = 1;
                    }
                    if (x == 0 && y == 1) {
                        j++;
                        droga[d] = 0;
                    }
                    if (x == (-1) && y == 0) {
                        i++;
                        droga[d] = 3;
                    }
                }
                else {
                    if (x == 0 && y == (-1)) {
                        j++;
                        droga[d] = 0;
                    }
                    if (x == 1 && y == 0) {
                        i++;
                        droga[d] = 3;
                    }
                    if (x == 0 && y == 1) {
                        j--;
                        droga[d] = 2;
                    }
                    if (x == (-1) && y == 0) {
                        i--;
                        droga[d] = 1;
                    }
                }
                wynik[bmp.Width * i + j] = 255;
            }
            while (j != ja || i != ia);
            for (i = 0; i < bmp.Height; i++) {
                for (j = 0; j < bmp.Width; j++) {
                    if (wynik[bmp.Width * i + j] == 255) {
                        rtab[j, i] = 255;
                        gtab[j, i] = 0;
                        btab[j, i] = 0;
                    }
                }
            }

            for (i = 0; i < bmp.Width; i++) {
                for (j = 0; j < bmp.Height; j++) {
                    
            		Color nc = Color.FromArgb(255, rtab[i, j], gtab[i, j], btab[i, j]);
                    bmp.SetPixel(i,j, nc);
                    
            		
                }
            }
            bmp.UnlockBits();
            return bitmap;
        }
        
       
    
        public Bitmap turtle2 (Bitmap img,int startx,int starty)
        {

            int[] dx = {-1,0,1,0};
            int[] dy = {0,-1,0,1};
            int x = -1; int y = -1;

            if (img.GetPixel(startx, starty).B >= 100)
            {
                for (int xx = 0; xx < img.Width; ++xx)
                {
                    for (int yy = 0; yy < img.Height; ++yy)
                    {
                        if (img.GetPixel(xx, yy).B < 100) { x = xx; y = yy; }
                    }
                }
            }
            else
            {
                for (int xx = startx; xx < img.Width; ++xx)
                {
                    y = starty;
                    x = img.Width - 1;
                    if (img.GetPixel(xx, starty).B >= 100)
                    {
                        x = xx-1;
                        break;
                    }
                }
            }


            int d = 0;
            startx = x;
            starty = y;
            Bitmap ret = new Bitmap(img);

            do
            {
                if (x >= 0 && y >= 0 && x < img.Width && y < img.Height)
                    ret.SetPixel(x, y, Color.FromArgb(255, 0, 0));

                if (x >= 0 && y >= 0 && x < img.Width && y < img.Height &&
                    img.GetPixel(x, y).B < 100)
                {
                    d = (d + 3) % 4;
                }
                else
                {
                    d = (d + 1) % 4;
                }
                x += dx[d];
                y += dy[d];
            } while (x != startx || y != starty);
            return ret;
        }
    }

            
        }
    

        
        