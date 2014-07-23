using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class HistForm : Form
    {
        public void ReloadHist(Histogram his){


            chart1.Series.Add("one");

            chart1.Series["one"].SetDefault(true);
            chart1.Series["one"].Enabled = true;
            chart1.Visible = true;

            chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;

            for (int q = 0; q < his.HistogramTable.Count(); q++)
            {
                chart1.Series["one"].Points.AddXY(q, his.HistogramTable[q]);
                
            }

            
                        chart1.Show();
                        label2.Text = his.Total.ToString();

        }

        public void AddSmallPicture(Bitmap bmp)
        {
            pictureBox1.Image = bmp;
            //pictureBox1.Image.Size
        }
        public HistForm()
        {
            InitializeComponent();
        }

        private void HistForm_Load(object sender, EventArgs e)
        {
            
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
