using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication1
{




    public class HistogramEqualization
    {
        public enum Metody
        {
            Srednich,
            Losowa,
            Sasiedztwa,
			Wlasna            
        }

         
        public Bitmap Wyrownanie(Bitmap bmp, Metody metoda)
        {
            int levels = 256;
            int[] H = new int[levels];
            for (int x = 0; x < bmp.Width; x++)
                for (int y = 0; y < bmp.Height; y++)
                 H[bmp.GetPixel(x,y).R]++;
                   

            int Havg = 0;
            for (int i = 0; i < levels; i++)
                Havg += H[i];
            Havg /= levels;

            int R = 0;
            int Hint = 0;
            int[] left = new int[levels];
            int[] right = new int[levels];
            int[] _new = new int[levels];

            for (int z = 0; z < levels; z++)
            {
                left[z] = R;
                Hint += H[z];
                while (Hint > Havg)
                {
                    Hint -= Havg;
                    R++;
                }
                if (R > levels - 1) R = levels - 1;
                right[z] = R;

                switch (metoda)
                {
                    case Metody.Srednich:
                        _new[z] = (left[z] + right[z]) / 2;
                        break;

                    case Metody.Losowa:
                        _new[z] = right[z] - left[z];
                        break;
                   
                       case Metody.Wlasna:
                         _new[z] = (left[z] + right[z]) / 2;
                        break;

                    default:
                        break;
                }
            }

            Random random = new Random();

            for (int i = 0; i < bmp.Size.Width; ++i)
            {
                for (int j = 0; j < bmp.Size.Height; ++j)
                {
                    byte color = 0;

                    byte val = bmp.GetPixel(i,j).R;

                    if (left[val] == right[val])
                    {
                        color = (byte)left[val];
                    }
                    else
                    {
                        switch (metoda)
                        {
                            case Metody.Srednich:                                
                                color = (byte)_new[val];
                                break;

                            case Metody.Losowa:
                                int value = random.Next(0, _new[val]);
                                color = (byte)(left[val] + value);
                                break;

                            case Metody.Sasiedztwa:
                                double average = 0;
                                int count = 0;
                                foreach (Point offset in new Point[] { new Point(1, 0), new Point(-1, 0), new Point(0, 1), new Point(0, -1), new Point(1, 1), new Point(-1, -1), new Point(-1, 1), new Point(1, -1) })
                                {
                                    if (i + offset.X >= 0 && i + offset.X < bmp.Width && j + offset.Y >= 0 && j + offset.Y < bmp.Height)
                                    {
                                        average += bmp.GetPixel(i + offset.X, j + offset.Y).R;
                                        ++count;
                                    }
                                }
                                average /= count;
                                if (average > right[val])
                                    color = (byte)right[val];
                                else if (average < left[val])
                                    color = (byte)left[val];
                                else
                                    color = (byte)((int)average);
                                break;
                                
                               case Metody.Wlasna:
                                  color = (byte)((_new[val] + random.Next(0, _new[val])) / 2);
                                break;

                                default:
                                break;
                        }
                    }

                   // bmp[i, j] = color;
                    Color px = bmp.GetPixel(i,j);

                    Color nc = Color.FromArgb(px.A, color, color, color);
                    bmp.SetPixel(i, j, nc);
                }
            }

            return bmp;
        }
    }
}
