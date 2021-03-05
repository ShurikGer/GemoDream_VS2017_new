using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Cntrls
{
	/// <summary>
	/// Summary description for CarrierControl.
	/// </summary>
	public class CarrierControl : System.Windows.Forms.UserControl
	{
		internal System.Windows.Forms.GroupBox GroupBox7;
		internal System.Windows.Forms.Panel pCarrer;
		internal System.Windows.Forms.PictureBox PictureBox8;
		internal System.Windows.Forms.PictureBox PictureBox7;
		internal System.Windows.Forms.PictureBox PictureBox6;
		internal System.Windows.Forms.PictureBox PictureBox5;
		internal System.Windows.Forms.PictureBox PictureBox4;
		internal System.Windows.Forms.RadioButton rbIZIK;
		internal System.Windows.Forms.RadioButton RadioButton17;
		internal System.Windows.Forms.RadioButton RadioButton16;
		internal System.Windows.Forms.RadioButton RadioButton15;
		internal System.Windows.Forms.RadioButton RadioButton14;
		internal System.Windows.Forms.RadioButton RadioButton13;
		internal System.Windows.Forms.RadioButton rbMore;
		private System.Windows.Forms.ComboBox cmbCarriers;
		private System.Data.DataTable dtCarriers=null;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CarrierControl()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CarrierControl));
			this.GroupBox7 = new System.Windows.Forms.GroupBox();
			this.pCarrer = new System.Windows.Forms.Panel();
			this.cmbCarriers = new System.Windows.Forms.ComboBox();
			this.PictureBox8 = new System.Windows.Forms.PictureBox();
			this.PictureBox7 = new System.Windows.Forms.PictureBox();
			this.PictureBox6 = new System.Windows.Forms.PictureBox();
			this.PictureBox5 = new System.Windows.Forms.PictureBox();
			this.PictureBox4 = new System.Windows.Forms.PictureBox();
			this.rbIZIK = new System.Windows.Forms.RadioButton();
			this.RadioButton17 = new System.Windows.Forms.RadioButton();
			this.RadioButton16 = new System.Windows.Forms.RadioButton();
			this.RadioButton15 = new System.Windows.Forms.RadioButton();
			this.RadioButton14 = new System.Windows.Forms.RadioButton();
			this.RadioButton13 = new System.Windows.Forms.RadioButton();
			this.rbMore = new System.Windows.Forms.RadioButton();
			this.GroupBox7.SuspendLayout();
			this.pCarrer.SuspendLayout();
			this.SuspendLayout();
			// 
			// GroupBox7
			// 
			this.GroupBox7.Controls.Add(this.pCarrer);
			this.GroupBox7.Location = new System.Drawing.Point(0, 0);
			this.GroupBox7.Name = "GroupBox7";
			this.GroupBox7.Size = new System.Drawing.Size(655, 95);
			this.GroupBox7.TabIndex = 11;
			this.GroupBox7.TabStop = false;
			this.GroupBox7.Text = "Carrier";
			// 
			// pCarrer
			// 
			this.pCarrer.AutoScroll = true;
			this.pCarrer.Controls.Add(this.cmbCarriers);
			this.pCarrer.Controls.Add(this.PictureBox8);
			this.pCarrer.Controls.Add(this.PictureBox7);
			this.pCarrer.Controls.Add(this.PictureBox6);
			this.pCarrer.Controls.Add(this.PictureBox5);
			this.pCarrer.Controls.Add(this.PictureBox4);
			this.pCarrer.Controls.Add(this.rbIZIK);
			this.pCarrer.Controls.Add(this.RadioButton17);
			this.pCarrer.Controls.Add(this.RadioButton16);
			this.pCarrer.Controls.Add(this.RadioButton15);
			this.pCarrer.Controls.Add(this.RadioButton14);
			this.pCarrer.Controls.Add(this.RadioButton13);
			this.pCarrer.Controls.Add(this.rbMore);
			this.pCarrer.Location = new System.Drawing.Point(5, 20);
			this.pCarrer.Name = "pCarrer";
			this.pCarrer.Size = new System.Drawing.Size(645, 70);
			this.pCarrer.TabIndex = 0;
			// 
			// cmbCarriers
			// 
			this.cmbCarriers.Enabled = false;
			this.cmbCarriers.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.cmbCarriers.Location = new System.Drawing.Point(504, 25);
			this.cmbCarriers.Name = "cmbCarriers";
			this.cmbCarriers.TabIndex = 13;
			// 
			// PictureBox8
			// 
			this.PictureBox8.BackColor = System.Drawing.SystemColors.Control;
			this.PictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox8.Image")));
			this.PictureBox8.Location = new System.Drawing.Point(410, 25);
			this.PictureBox8.Name = "PictureBox8";
			this.PictureBox8.Size = new System.Drawing.Size(80, 40);
			this.PictureBox8.TabIndex = 12;
			this.PictureBox8.TabStop = false;
			// 
			// PictureBox7
			// 
			this.PictureBox7.BackColor = System.Drawing.SystemColors.Control;
			this.PictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox7.Image")));
			this.PictureBox7.Location = new System.Drawing.Point(310, 25);
			this.PictureBox7.Name = "PictureBox7";
			this.PictureBox7.Size = new System.Drawing.Size(80, 40);
			this.PictureBox7.TabIndex = 11;
			this.PictureBox7.TabStop = false;
			// 
			// PictureBox6
			// 
			this.PictureBox6.BackColor = System.Drawing.SystemColors.Control;
			this.PictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox6.Image")));
			this.PictureBox6.Location = new System.Drawing.Point(210, 25);
			this.PictureBox6.Name = "PictureBox6";
			this.PictureBox6.Size = new System.Drawing.Size(80, 40);
			this.PictureBox6.TabIndex = 10;
			this.PictureBox6.TabStop = false;
			// 
			// PictureBox5
			// 
			this.PictureBox5.BackColor = System.Drawing.SystemColors.Control;
			this.PictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox5.Image")));
			this.PictureBox5.Location = new System.Drawing.Point(110, 25);
			this.PictureBox5.Name = "PictureBox5";
			this.PictureBox5.Size = new System.Drawing.Size(80, 40);
			this.PictureBox5.TabIndex = 9;
			this.PictureBox5.TabStop = false;
			// 
			// PictureBox4
			// 
			this.PictureBox4.BackColor = System.Drawing.SystemColors.Control;
			this.PictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox4.Image")));
			this.PictureBox4.Location = new System.Drawing.Point(10, 25);
			this.PictureBox4.Name = "PictureBox4";
			this.PictureBox4.Size = new System.Drawing.Size(80, 40);
			this.PictureBox4.TabIndex = 8;
			this.PictureBox4.TabStop = false;
			// 
			// rbIZIK
			// 
			this.rbIZIK.Checked = true;
			this.rbIZIK.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.rbIZIK.ForeColor = System.Drawing.SystemColors.ControlText;
			this.rbIZIK.Location = new System.Drawing.Point(510, 5);
			this.rbIZIK.Name = "rbIZIK";
			this.rbIZIK.Size = new System.Drawing.Size(60, 15);
			this.rbIZIK.TabIndex = 5;
			this.rbIZIK.TabStop = true;
			this.rbIZIK.Tag = "6";
			this.rbIZIK.Text = "IZIK";
			// 
			// RadioButton17
			// 
			this.RadioButton17.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.RadioButton17.ForeColor = System.Drawing.SystemColors.ControlText;
			this.RadioButton17.Location = new System.Drawing.Point(410, 5);
			this.RadioButton17.Name = "RadioButton17";
			this.RadioButton17.Size = new System.Drawing.Size(83, 15);
			this.RadioButton17.TabIndex = 4;
			this.RadioButton17.Tag = "5";
			this.RadioButton17.Text = "MalcaAmit";
			// 
			// RadioButton16
			// 
			this.RadioButton16.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.RadioButton16.ForeColor = System.Drawing.SystemColors.ControlText;
			this.RadioButton16.Location = new System.Drawing.Point(310, 5);
			this.RadioButton16.Name = "RadioButton16";
			this.RadioButton16.Size = new System.Drawing.Size(60, 15);
			this.RadioButton16.TabIndex = 3;
			this.RadioButton16.Tag = "4";
			this.RadioButton16.Text = "Brinks";
			// 
			// RadioButton15
			// 
			this.RadioButton15.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.RadioButton15.ForeColor = System.Drawing.SystemColors.ControlText;
			this.RadioButton15.Location = new System.Drawing.Point(210, 5);
			this.RadioButton15.Name = "RadioButton15";
			this.RadioButton15.Size = new System.Drawing.Size(60, 15);
			this.RadioButton15.TabIndex = 2;
			this.RadioButton15.Tag = "3";
			this.RadioButton15.Text = "USPS";
			// 
			// RadioButton14
			// 
			this.RadioButton14.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.RadioButton14.ForeColor = System.Drawing.SystemColors.ControlText;
			this.RadioButton14.Location = new System.Drawing.Point(110, 5);
			this.RadioButton14.Name = "RadioButton14";
			this.RadioButton14.Size = new System.Drawing.Size(60, 15);
			this.RadioButton14.TabIndex = 1;
			this.RadioButton14.Tag = "2";
			this.RadioButton14.Text = "UPS";
			// 
			// RadioButton13
			// 
			this.RadioButton13.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.RadioButton13.ForeColor = System.Drawing.SystemColors.ControlText;
			this.RadioButton13.Location = new System.Drawing.Point(10, 5);
			this.RadioButton13.Name = "RadioButton13";
			this.RadioButton13.Size = new System.Drawing.Size(60, 15);
			this.RadioButton13.TabIndex = 0;
			this.RadioButton13.Tag = "1";
			this.RadioButton13.Text = "FedEx";
			// 
			// rbMore
			// 
			this.rbMore.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.rbMore.ForeColor = System.Drawing.SystemColors.ControlText;
			this.rbMore.Location = new System.Drawing.Point(576, 5);
			this.rbMore.Name = "rbMore";
			this.rbMore.Size = new System.Drawing.Size(60, 15);
			this.rbMore.TabIndex = 5;
			this.rbMore.Tag = "6";
			this.rbMore.Text = "More...";
			this.rbMore.CheckedChanged += new System.EventHandler(this.rbMore_CheckedChanged);
			// 
			// CarrierControl
			// 
			this.Controls.Add(this.GroupBox7);
			this.Name = "CarrierControl";
			this.Size = new System.Drawing.Size(655, 95);
			this.GroupBox7.ResumeLayout(false);
			this.pCarrer.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public void AddDataToCombo(DataTable dtData)
		{
			dtCarriers=dtData.Copy();
			cmbCarriers.DataSource=dtCarriers;
			cmbCarriers.DisplayMember="CarrierName";
			cmbCarriers.ValueMember="CarrierCode";
		}

		private void rbMore_CheckedChanged(object sender, System.EventArgs e)
		{
			if( ((RadioButton)sender).Checked)
			{
				cmbCarriers.Enabled=true;
			}
			else
				cmbCarriers.Enabled=false;
		}

		public string CarrierCode
		{
			get
			{
				foreach(Control rbCarrier in pCarrer.Controls)
				{
					if ("System.Windows.Forms.RadioButton" == rbCarrier.GetType().ToString())
					{
						RadioButton rb = (RadioButton)rbCarrier;
						if (rb.Checked)
						{
							if(rb.Name=="rbMore")
							{
								return cmbCarriers.SelectedValue.ToString();
							}
							return rb.Tag.ToString();							
                            //break;
						}
					}
				}
				return "";
			}
		}
	}
}
