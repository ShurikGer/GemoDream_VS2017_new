using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace gemoDream
{
	/// <summary>
	/// Summary description for PrintingOptions.
	/// </summary>
	public class PrintingOptions : System.Windows.Forms.Form
	{
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.CheckBox chbApply2All;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PrintingOptions()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PrintingOptions));
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.button1 = new System.Windows.Forms.Button();
			this.chbApply2All = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// radioButton1
			// 
			this.radioButton1.Checked = true;
			this.radioButton1.Location = new System.Drawing.Point(48, 8);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.TabIndex = 0;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "Total weight";
			// 
			// radioButton2
			// 
			this.radioButton2.Location = new System.Drawing.Point(48, 32);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(144, 24);
			this.radioButton2.TabIndex = 1;
			this.radioButton2.Text = "Central stone weight";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(64, 88);
			this.button1.Name = "button1";
			this.button1.TabIndex = 3;
			this.button1.Text = "&Print";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// chbApply2All
			// 
			this.chbApply2All.Location = new System.Drawing.Point(8, 64);
			this.chbApply2All.Name = "chbApply2All";
			this.chbApply2All.Size = new System.Drawing.Size(208, 24);
			this.chbApply2All.TabIndex = 2;
			this.chbApply2All.Text = "Apply to all selected documents";
			// 
			// PrintingOptions
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
			this.ClientSize = new System.Drawing.Size(218, 119);
			this.ControlBox = false;
			this.Controls.Add(this.chbApply2All);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.radioButton2);
			this.Controls.Add(this.radioButton1);
			this.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PrintingOptions";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Printing Options";
			this.ResumeLayout(false);

		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		public Boolean IsTotalWeight
		{
			get{return this.radioButton1.Checked;}
		}

		public Boolean IsApply2All
		{
			get{return this.chbApply2All.Checked;}
		}

	}
}
