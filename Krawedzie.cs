/*
 * Utworzone przez SharpDevelop.
 * Data: 2013-11-03
 * Godzina: 19:35
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
	/// <summary>
	/// Description of Krawedzie.
	/// </summary>
	public partial class Krawedzie : Form
	{
		public Krawedzie()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			radioButton1.Checked=true;
		}
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		
		
		private void RadioButton1CheckedChanged(object sender, EventArgs e)
		{
			
		}
		
		
		
		private void GroupBox1Enter(object sender, EventArgs e)
		{
			
		}
		
		public int Skrajne { get {
					if (radioButton1.Checked==true) return 1;
					else if (radioButton2.Checked==true) return 2;
					else return 3; } }
		
		void Button1Click(object sender, EventArgs e)
		{
			this.Close();
		}
		
		//public void Hide3() {this.radioButton3.Visible=false;}
	}
		
}
