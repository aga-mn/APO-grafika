using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class Lab6
    {
        public class Stats
        {
            public double[] W = new double[9];
            public long[] M = new long[4];
            public long[] MC = new long[3];
            public Point SM;
            public double area;
            public double perimeter;
        }

        private static bool isPixelValid(int x, int y, int width, int height)
        {
            if (x >= 0 && y >= 0 && x < width && y < height)
                return true;
            return false;
        }

        // Zadanie 6
        public Stats stats(FastBitmapp bmp)
        {
            int L = 0;
            int S = 0;
            int size = bmp.Width * bmp.Height;
            double areaNorm = 0.0;
            int[] r0 = new int[] { 0, 0 };
            long m00 = 0;
            long m10 = 0;
            long m01 = 0;
            long m11 = 0;

            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    int rpixel = bmp[x, y];
                    if (rpixel > 0)
                    {
                        S++;
                        m00 += bmp[x, y];
                        m10 += x * bmp[x, y];
                        m01 += y * bmp[x, y];
                        m11 += x * y * bmp[x, y];

                        for (int i = -1; i < 2; i++)
                        {
                            for (int j = -1; j < 2; j++)
                            {
                                if (isPixelValid(x + i, y + j, bmp.Width, bmp.Height))
                                {
                                    int sasiad = bmp[x + i, y + j];
                                    if (sasiad == 0)
                                    {
                                        L++;
                                        r0[0] += x;
                                        r0[1] += y;
                                        goto next;
                                    }
                                }
                            }
                        }
                    }
                next: ;
                }
            }

            if (L > 0)
            {
                r0[0] = r0[0] / L;
                r0[1] = r0[1] / L;
            }
            areaNorm = (double)S / (double)size;

            double W1 = 2.0 * Math.Sqrt((double)S / Math.PI);
            double W2 = (double)L / Math.PI;
            //double W3 = (double)L / (2.0 * Math.Sqrt((double)S * Math.PI));
            double W3 = (double)L / (2.0 * Math.Sqrt((double)S * Math.PI)) - 1;
            double W9 = (2.0 * Math.Sqrt(Math.PI * (double)S)) / (double)L;

            int minX = -1;
            int maxX = -1;
            int minY = -1;
            int maxY = -1;
            bool isSet = false;
            long sumaOdl = 0;
            long M10 = 0;
            long M01 = 0;
            long M11 = 0;

            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    int rpixel = bmp[x, y];
                    if (rpixel > 0)
                    {
                        if (!isSet)
                        {
                            isSet = true;
                            if (minX == -1) minX = x;
                            if (maxX == -1) maxX = x;
                            if (minY == -1) minY = y;
                            if (maxY == -1) maxY = y;
                        }
                        if (x < minX) minX = x;
                        if (x > maxX) maxX = x;
                        if (y < minY) minY = y;
                        if (y > maxY) maxY = y;

                        M10 += (x - r0[0]) * bmp[x, y];
                        M01 += (y - r0[1]) * bmp[x, y];
                        M11 += (x - r0[0]) * (y - r0[1]) * bmp[x, y];
                        sumaOdl += (int)Math.Pow(Math.Sqrt((x - r0[0] * x - r0[0]) + (y - r0[1] * y - r0[1])), 2);
                    }
                }
            }
            int gabarytX = maxX - minX;
            int gabarytY = maxY - minY;
            int Lmax;
            if (gabarytX > gabarytY) Lmax = gabarytX;
            else Lmax = gabarytY;

            double W8 = (double)Lmax / (double)L;
            double W4 = (double)S / Math.Sqrt(2 * Math.PI * (double)sumaOdl);

            Stats result = new Stats();

            result.W[0] = W1; //wsp cyrkularności
            result.W[1] = W2; //wsp cyrkularności
            result.W[2] = W3; //wsp malinowskiej
            result.W[3] = W4; //wsp Blaira-Blissa
            //result.W[4] = W5;
            //result.W[5] = W6;
            //result.W[6] = W7;
            result.W[7] = W8; //wsp Lp2 - określa cechy pośrednie
            result.W[8] = W9; //współczynnik Malinowskiej uproszczony

            result.M[0] = m00;
            result.M[1] = m01;
            result.M[2] = m10;
            result.M[3] = m11;

            result.MC[0] = M10;
            result.MC[1] = M01;
            result.MC[2] = M11;

            result.SM = new Point(r0[0], r0[1]);
            result.area = S;
            result.perimeter = L;


            return result;
        }
    }
}
