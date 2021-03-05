using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Cntrls
{
	/// <summary>
	/// Summary description for Price.
	/// </summary>
	public class Price : System.Windows.Forms.UserControl
	{
		public String sCaratRangeMin;
		public String sCaratRangeMax;
		private System.Windows.Forms.Panel panel7;
		public System.Windows.Forms.RadioButton rbUnfixed01P;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label20;
		public System.Windows.Forms.RadioButton rbUnfixed01B;
		public System.Windows.Forms.Label lbInterval;
		public System.Windows.Forms.TextBox tbPercent;
		public System.Windows.Forms.TextBox tbBuck;
		public System.Windows.Forms.Label lbName;
		public System.Windows.Forms.CheckBox cbInterval;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Price()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panel7 = new System.Windows.Forms.Panel();
			this.cbInterval = new System.Windows.Forms.CheckBox();
			this.lbInterval = new System.Windows.Forms.Label();
			this.rbUnfixed01P = new System.Windows.Forms.RadioButton();
			this.label21 = new System.Windows.Forms.Label();
			this.tbPercent = new System.Windows.Forms.TextBox();
			this.label20 = new System.Windows.Forms.Label();
			this.tbBuck = new System.Windows.Forms.TextBox();
			this.lbName = new System.Windows.Forms.Label();
			this.rbUnfixed01B = new System.Windows.Forms.RadioButton();
			this.panel7.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel7
			// 
			this.panel7.Controls.Add(this.cbInterval);
			this.panel7.Controls.Add(this.lbInterval);
			this.panel7.Controls.Add(this.rbUnfixed01P);
			this.panel7.Controls.Add(this.label21);
			this.panel7.Controls.Add(this.tbPercent);
			this.panel7.Controls.Add(this.label20);
			this.panel7.Controls.Add(this.tbBuck);
			this.panel7.Controls.Add(this.lbName);
			this.panel7.Controls.Add(this.rbUnfixed01B);
			this.panel7.Location = new System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(455, 40);
			this.panel7.TabIndex = 3;
			// 
			// cbInterval
			// 
			this.cbInterval.Location = new System.Drawing.Point(80, 20);
			this.cbInterval.Name = "cbInterval";
			this.cbInterval.Size = new System.Drawing.Size(15, 15);
			this.cbInterval.TabIndex = 10;
			this.cbInterval.Text = "checkBox1";
			// 
			// lbInterval
			// 
			this.lbInterval.Location = new System.Drawing.Point(10, 20);
			this.lbInterval.Name = "lbInterval";
			this.lbInterval.Size = new System.Drawing.Size(86, 15);
			this.lbInterval.TabIndex = 9;
			this.lbInterval.Text = "0 -1";
			// 
			// rbUnfixed01P
			// 
			this.rbUnfixed01P.Location = new System.Drawing.Point(328, 0);
			this.rbUnfixed01P.Name = "rbUnfixed01P";
			this.rbUnfixed01P.Size = new System.Drawing.Size(15, 15);
			this.rbUnfixed01P.TabIndex = 8;
			this.rbUnfixed01P.CheckedChanged += new System.EventHandler(this.rbUnfixed01P_CheckedChanged);
			// 
			// label21
			// 
			this.label21.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
			this.label21.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label21.Location = new System.Drawing.Point(435, 20);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(15, 15);
			this.label21.TabIndex = 7;
			this.label21.Text = "%";
			// 
			// tbPercent
			// 
			this.tbPercent.Enabled = false;
			this.tbPercent.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
			this.tbPercent.Location = new System.Drawing.Point(328, 15);
			this.tbPercent.Name = "tbPercent";
			this.tbPercent.Size = new System.Drawing.Size(96, 20);
			this.tbPercent.TabIndex = 6;
			this.tbPercent.Text = "";
			// 
			// label20
			// 
			this.label20.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label20.Location = new System.Drawing.Point(304, 20);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(15, 15);
			this.label20.TabIndex = 5;
			this.label20.Text = "$";
			// 
			// tbBuck
			// 
			this.tbBuck.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
			this.tbBuck.Location = new System.Drawing.Point(195, 15);
			this.tbBuck.Name = "tbBuck";
			this.tbBuck.Size = new System.Drawing.Size(96, 20);
			this.tbBuck.TabIndex = 4;
			this.tbBuck.Text = "";
			// 
			// lbName
			// 
			this.lbName.Location = new System.Drawing.Point(100, 20);
			this.lbName.Name = "lbName";
			this.lbName.Size = new System.Drawing.Size(88, 15);
			this.lbName.TabIndex = 3;
			this.lbName.Text = "Range Price";
			// 
			// rbUnfixed01B
			// 
			this.rbUnfixed01B.Checked = true;
			this.rbUnfixed01B.Location = new System.Drawing.Point(195, 0);
			this.rbUnfixed01B.Name = "rbUnfixed01B";
			this.rbUnfixed01B.Size = new System.Drawing.Size(15, 15);
			this.rbUnfixed01B.TabIndex = 1;
			this.rbUnfixed01B.TabStop = true;
			this.rbUnfixed01B.CheckedChanged += new System.EventHandler(this.rbUnfixed01B_CheckedChanged);
			// 
			// Price
			// 
			this.Controls.Add(this.panel7);
			this.Name = "Price";
			this.Size = new System.Drawing.Size(455, 45);
			this.panel7.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void rbUnfixed01B_CheckedChanged(object sender, System.EventArgs e)
		{
			tbBuck.Enabled = rbUnfixed01B.Checked;
			tbPercent.Enabled = !rbUnfixed01B.Checked;
		}

		private void rbUnfixed01P_CheckedChanged(object sender, System.EventArgs e)
		{
			if(lbName.Text == "")
				rbUnfixed01B.Checked = true;
		}

	}
}
