using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace WindowsFormsApplication1 {
    public class Histogram {
        private int[] histogramTable;
        private int total = 0;
        private int max;
        private double avg;
        private double mean;
        private double variance;
       
        public int[] HistogramTable {
            get { return histogramTable; }
        }
        
        public int Total {
            get { return total; }
        } 

        public int Max {
            get { return max; }
        }

        public double Average {
            get { return avg; }
        }

        public double Mean {
            get { return mean; }
        }

        public double Variance {
            get { return variance; }
        }

                public Histogram(Bitmap bmp) {
            histogramTable = new int[256];
            for (int i = 0; i < bmp.Size.Width; ++i) {
                for (int j = 0; j < bmp.Size.Height; ++j) {
                    histogramTable[bmp.GetPixel(i,j).R]++;
                    total++;
                }
            }
            max = histogramTable.Max();
            avg = histogramTable.Average();

            double[] hv = new double[256];
            for (int i = 0; i < histogramTable.Length; ++i) {
                hv[i] = (double)histogramTable[i] / total;
            }

            double temp;

            mean = 0;
            variance = 0;
         

            for (int i = 0; i < histogramTable.Length; ++i) {
                mean += i * hv[i];
            }

            for (int i = 0; i < histogramTable.Length; ++i) {
                temp = i - mean;
                variance += temp * temp * hv[i];
                
            }
            
        }
    }
}
