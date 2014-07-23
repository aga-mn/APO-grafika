using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BarChart;


namespace WindowsFormsApplication1
{
    public partial class RichHistForm : Form
    {

      
        public RichHistForm()
        {
            InitializeComponent();
           // this.hBarChart1.Add();
        }

 public void AddSmallImg(Bitmap bmp)
        {
 	pictureBox1.Image=bmp;
 }

        public void ReloadHist(Histogram his)
        {

            hBarChart1.BarsGap = 0;
            hBarChart1.BarWidth = 5;
            hBarChart1.Items.DrawingMode = HBarItems.DrawingModes.Solid;
            hBarChart1.Description.Text = "Histogram";
            hBarChart1.Description.Visible = true;
            hBarChart1.Values.Visible = false;
            hBarChart1.Label.Visible = false;

               hBarChart1.Background.PaintingMode = CBackgroundProperty.PaintingModes.SolidColor;
               hBarChart1.Background.SolidColor = Color.White;
             
         //   hBarChart1.Background.GradientColor1=Color.Red;
            
            hBarChart1.RedrawChart();



            DataTable dt = new DataTable();
            DataRow dr, drproc, dr1;
            dr = dt.NewRow();
            drproc = dt.NewRow();
            dr1=dt.NewRow();
           int maxV= his.Max;
          // MessageBox.Show(maxV.ToString());
            for (int q = 0; q < his.HistogramTable.Count(); q++)
            {
               // chart1.Series["one"].Points.AddXY(q, his.HistogramTable[q]);

              
                dt.Columns.Add(q.ToString(), typeof(System.Double));
              // hBarChart1.Add(1900, "Des", Color.FromArgb(255, 150, 240, 80));
               drproc[q] = ((double)his.HistogramTable[q] / (double)maxV) * 100;
                dr[q] = his.HistogramTable[q];
                dr1[q]= ((double)his.HistogramTable[q] / his.Total) * 100;
            }

            dt.Rows.Add(dr);
            dt.Rows.Add(drproc);
            dt.Rows.Add(dr1);
            this.dataGridView1.DataSource = dt;
           // this.hBarChart1.DataSource = this.dataGridView1.DataSource;


            for (int q = 0; q < his.HistogramTable.Count(); q++)
            {
                hBarChart1.Add(his.HistogramTable[q], q.ToString(), Color.FromArgb(255, q, q, q));
            }

            hBarChart1.RedrawChart();
        }
        
        
        private void button1_Click(object sender, EventArgs e)
        {
            hBarChart1.Description.Text = "Histogram";
            hBarChart1.Description.Visible = true;

            hBarChart1.RedrawChart();
            
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("Jan", typeof(System.Double));
            dt.Columns.Add("Feb", typeof(System.Double));
            dt.Columns.Add("Mar", typeof(System.Double));
            dt.Columns.Add("Apr", typeof(System.Double));
            dt.Columns.Add("May", typeof(System.Double));
            dt.Columns.Add("Jun", typeof(System.Double));
            dt.Columns.Add("Jul", typeof(System.Double));
            dt.Columns.Add("Aug", typeof(System.Double));
            dt.Columns.Add("Sep", typeof(System.Double));
            dt.Columns.Add("Oct", typeof(System.Double));
            dt.Columns.Add("Nov", typeof(System.Double));
            dt.Columns.Add("Des", typeof(System.Double));

            dr = dt.NewRow();

            dr[0] = 1900.2566;
            dr[1] = 2841.5468;
            dr[2] = 1045.3258;
            dr[3] = 1502.215;
            dr[4] = 1467;
            dr[5] = 1678.354;
            dr[6] = 1785.689;
            dr[7] = 1283.099;
            dr[8] = 1554.879;
            dr[9] = 1400.10;
            dr[10] = 1600.556;
            dr[11] = 1900.3546;

            dt.Rows.Add(dr);

            this.dataGridView1.DataSource = dt;
            this.hBarChart1.DataSource = this.dataGridView1.DataSource;
        }

        private void trackBarGap_Scroll(object sender, EventArgs e)
        {
            hBarChart1.BarsGap = trackBarGap.Value;
            hBarChart1.RedrawChart();

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Gap size({0})", trackBarGap.Value.ToString());
            labelGapValue.Text = sb.ToString();
        }

        private void trackBarWidthBar_Scroll(object sender, EventArgs e)
        {
            hBarChart1.BarWidth = trackBarWidthBar.Value;
            hBarChart1.RedrawChart();

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Bar Width({0})", trackBarWidthBar.Value.ToString());

            labelBarWidthValue.Text = sb.ToString();
        }

        private void comboBoxSizingMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox senderComboBox = (ComboBox)sender;

           
             hBarChart1.RedrawChart();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void trackBarGap_Scroll_1(object sender, EventArgs e)
        {

        }
       

        private void trackBarGap_Scroll_2(object sender, EventArgs e)
        {
            hBarChart1.BarsGap = trackBarGap.Value;
            hBarChart1.RedrawChart();

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Gap siz({0})", trackBarGap.Value.ToString());
            labelGapValue.Text = sb.ToString();
        }

        private void trackBarWidthBar_Scroll_1(object sender, EventArgs e)
        {
            hBarChart1.BarWidth = trackBarWidthBar.Value;
            hBarChart1.RedrawChart();

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Bar Width({0})", trackBarWidthBar.Value.ToString());

            labelBarWidthValue.Text = sb.ToString();
        }

      

     

       
      

       
        
        void PictureBox1Click(object sender, EventArgs e)
        {
        	
        }
    }
}
