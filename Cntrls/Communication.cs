using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace gemoDream
{
	/// <summary>
	/// Summary description for Communication.
	/// </summary>
	public class Communication : System.Windows.Forms.UserControl
	{
		public System.Windows.Forms.CheckBox chbMail;
		public System.Windows.Forms.CheckBox chbEmail;
		public System.Windows.Forms.CheckBox chbPhone;
		public System.Windows.Forms.CheckBox chbFax;
		private System.Windows.Forms.GroupBox gbComm;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;	
		public CheckBox[] achbComm;
		private System.Windows.Forms.Button bPrefComDown;
		private System.Windows.Forms.Button bPrefComUp;
		int iLastChecked = 0;

		public Communication()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			InitCheckBoxes();
			achbComm = new CheckBox[] {chbFax, chbPhone, chbEmail, chbMail};			

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Communication));
			this.gbComm = new System.Windows.Forms.GroupBox();
			this.bPrefComUp = new System.Windows.Forms.Button();
			this.bPrefComDown = new System.Windows.Forms.Button();
			this.chbMail = new System.Windows.Forms.CheckBox();
			this.chbEmail = new System.Windows.Forms.CheckBox();
			this.chbPhone = new System.Windows.Forms.CheckBox();
			this.chbFax = new System.Windows.Forms.CheckBox();
			this.gbComm.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbComm
			// 
			this.gbComm.Controls.Add(this.bPrefComUp);
			this.gbComm.Controls.Add(this.bPrefComDown);
			this.gbComm.Controls.Add(this.chbMail);
			this.gbComm.Controls.Add(this.chbEmail);
			this.gbComm.Controls.Add(this.chbPhone);
			this.gbComm.Controls.Add(this.chbFax);
			this.gbComm.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
			this.gbComm.ForeColor = System.Drawing.SystemColors.ControlText;
			this.gbComm.Location = new System.Drawing.Point(0, 0);
			this.gbComm.Name = "gbComm";
			this.gbComm.Size = new System.Drawing.Size(230, 60);
			this.gbComm.TabIndex = 20;
			this.gbComm.TabStop = false;
			this.gbComm.Text = "Preferred Methods of Communication";
			// 
			// bPrefComUp
			// 
			this.bPrefComUp.Enabled = false;
			this.bPrefComUp.Image = ((System.Drawing.Image)(resources.GetObject("bPrefComUp.Image")));
			this.bPrefComUp.Location = new System.Drawing.Point(8, 35);
			this.bPrefComUp.Name = "bPrefComUp";
			this.bPrefComUp.Size = new System.Drawing.Size(20, 20);
			this.bPrefComUp.TabIndex = 7;
			this.bPrefComUp.Click += new System.EventHandler(this.bPrefComUp_Click);
			// 
			// bPrefComDown
			// 
			this.bPrefComDown.Enabled = false;
			this.bPrefComDown.Image = ((System.Drawing.Image)(resources.GetObject("bPrefComDown.Image")));
			this.bPrefComDown.Location = new System.Drawing.Point(203, 35);
			this.bPrefComDown.Name = "bPrefComDown";
			this.bPrefComDown.Size = new System.Drawing.Size(20, 20);
			this.bPrefComDown.TabIndex = 6;
			this.bPrefComDown.Click += new System.EventHandler(this.bPrefComDown_Click);
			// 
			// chbMail
			// 
			this.chbMail.Location = new System.Drawing.Point(170, 20);
			this.chbMail.Name = "chbMail";
			this.chbMail.Size = new System.Drawing.Size(55, 15);
			this.chbMail.TabIndex = 3;
			this.chbMail.Text = "Mail";
			this.chbMail.CheckedChanged += new System.EventHandler(this.chbComm_CheckedChanged);
			// 
			// chbEmail
			// 
			this.chbEmail.Location = new System.Drawing.Point(115, 20);
			this.chbEmail.Name = "chbEmail";
			this.chbEmail.Size = new System.Drawing.Size(55, 15);
			this.chbEmail.TabIndex = 2;
			this.chbEmail.Text = "Email";
			this.chbEmail.CheckedChanged += new System.EventHandler(this.chbComm_CheckedChanged);
			// 
			// chbPhone
			// 
			this.chbPhone.Location = new System.Drawing.Point(60, 20);
			this.chbPhone.Name = "chbPhone";
			this.chbPhone.Size = new System.Drawing.Size(55, 15);
			this.chbPhone.TabIndex = 1;
			this.chbPhone.Text = "Phone";
			this.chbPhone.CheckedChanged += new System.EventHandler(this.chbComm_CheckedChanged);
			// 
			// chbFax
			// 
			this.chbFax.Location = new System.Drawing.Point(5, 20);
			this.chbFax.Name = "chbFax";
			this.chbFax.Size = new System.Drawing.Size(55, 15);
			this.chbFax.TabIndex = 0;
			this.chbFax.Text = "Fax";
			this.chbFax.CheckedChanged += new System.EventHandler(this.chbComm_CheckedChanged);
			// 
			// Communication
			// 
			this.Controls.Add(this.gbComm);
			this.Name = "Communication";
			this.Size = new System.Drawing.Size(230, 60);
			this.gbComm.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void InitCheckBoxes()
		{
			/*
			CheckBox chbFax = new CheckBox();
			chbFax.Parent = this;
			chbFax.Text = "Fax";
			chbFax.Location = new Point(35, 20);
			chbFax.Size = new Size(104, 15);
			chbFax.CheckedChanged += new EventHandler(chbComm_CheckedChanged);

			CheckBox chbPhone = new CheckBox();
			chbPhone.Parent = this;
			chbPhone.Text = "Fax";
			chbPhone.Location = new Point(35, 40);
			chbPhone.Size = new Size(104, 15);
			chbPhone.CheckedChanged += new EventHandler(chbComm_CheckedChanged);

			CheckBox chbEmail = new CheckBox();
			chbEmail.Parent = this;
			chbEmail.Text = "Email";
			chbEmail.Location = new Point(35, 60);
			chbEmail.Size = new Size(104, 15);
			chbEmail.CheckedChanged += new EventHandler(chbComm_CheckedChanged);

			CheckBox chbMail = new CheckBox();
			chbMail.Parent = this;
			chbMail.Text = "Mail";
			chbMail.Location = new Point(35, 80);
			chbMail.Size = new Size(104, 15);
			chbMail.CheckedChanged += new EventHandler(chbComm_CheckedChanged);

			this.gbComm.Controls.Add(this.chbMail);
			this.gbComm.Controls.Add(this.chbEmail);
			this.gbComm.Controls.Add(this.chbPhone);
			this.gbComm.Controls.Add(this.chbFax);
			*/
			 
		}

		private void chbComm_CheckedChanged(object sender, EventArgs ea)
		{
			for(int i = 0; i < 4; i++)
			{
				if(achbComm[i].Focused)
				{
					if(achbComm[i].Checked)
					{
						if(achbComm[i].Location.X == 5)
							bPrefComUp.Enabled = false;
						else bPrefComUp.Enabled = true;

						if(achbComm[i].Location.X == 170)
							bPrefComDown.Enabled = false;
						else bPrefComDown.Enabled = true;

						iLastChecked = i;
					}
					else 
					{
						bPrefComUp.Enabled = false;
						bPrefComDown.Enabled = false;
					}
				}
				//else bPrefComDown.Enabled = true;
			}
		}

		private void bPrefComUp_Click(object sender, System.EventArgs e)
		{
			for(int j = 0; j < 4; j++)
				if(achbComm[j].Location.X == achbComm[iLastChecked].Location.X - 55)
					achbComm[j].Location = 
						new Point(achbComm[j].Location.X + 55, achbComm[j].Location.Y);
			achbComm[iLastChecked].Location = 
				new Point(achbComm[iLastChecked].Location.X - 55, achbComm[iLastChecked].Location.Y);

			if(achbComm[iLastChecked].Location.X == 5)
				bPrefComUp.Enabled = false;
			else bPrefComUp.Enabled = true;

			if(achbComm[iLastChecked].Location.X == 170)
				bPrefComDown.Enabled = false;
			else bPrefComDown.Enabled = true;
		}

		private void bPrefComDown_Click(object sender, System.EventArgs e)
		{
			for(int j = 0; j < 4; j++)
				if(achbComm[j].Location.X == achbComm[iLastChecked].Location.X + 55)
					achbComm[j].Location = 
						new Point(achbComm[j].Location.X - 55, achbComm[j].Location.Y);
			achbComm[iLastChecked].Location = 
				new Point(achbComm[iLastChecked].Location.X + 55, achbComm[iLastChecked].Location.Y);

			if(achbComm[iLastChecked].Location.X == 5)
				bPrefComUp.Enabled = false;
			else bPrefComUp.Enabled = true;

			if(achbComm[iLastChecked].Location.X == 170)
				bPrefComDown.Enabled = false;
			else bPrefComDown.Enabled = true;
		}

		public void ClearChecks()
		{
			chbEmail.Checked = false;
			chbPhone.Checked = false;
			chbFax.Checked = false;
			chbMail.Checked = false;
		}
	}
}
