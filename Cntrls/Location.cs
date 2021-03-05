using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Cntrls
{
	/// <summary>
	/// Summary description for Location.
	/// </summary>
	public class Location : System.Windows.Forms.UserControl
	{
		public System.Windows.Forms.TextBox tbCountry;
		public System.Windows.Forms.TextBox tbZip2;
		public System.Windows.Forms.TextBox tbZip1;
		public System.Windows.Forms.ComboBox cbState;
		public System.Windows.Forms.TextBox tbCity;
		public System.Windows.Forms.TextBox tbAdditional;
		public System.Windows.Forms.TextBox tbAddress;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label2;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Location()
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
			this.tbCountry = new System.Windows.Forms.TextBox();
			this.tbZip2 = new System.Windows.Forms.TextBox();
			this.tbZip1 = new System.Windows.Forms.TextBox();
			this.cbState = new System.Windows.Forms.ComboBox();
			this.tbCity = new System.Windows.Forms.TextBox();
			this.tbAdditional = new System.Windows.Forms.TextBox();
			this.tbAddress = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// tbCountry
			// 
			this.tbCountry.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
			this.tbCountry.Location = new System.Drawing.Point(95, 65);
			this.tbCountry.Name = "tbCountry";
			this.tbCountry.Size = new System.Drawing.Size(60, 20);
			this.tbCountry.TabIndex = 4;
			this.tbCountry.Text = "";
			this.tbCountry.TextChanged += new System.EventHandler(this.tbCountry_TextChanged);
			this.tbCountry.Enter += new System.EventHandler(this.tbCountry_Enter);
			// 
			// tbZip2
			// 
			this.tbZip2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
			this.tbZip2.Location = new System.Drawing.Point(160, 85);
			this.tbZip2.MaxLength = 4;
			this.tbZip2.Name = "tbZip2";
			this.tbZip2.Size = new System.Drawing.Size(50, 20);
			this.tbZip2.TabIndex = 7;
			this.tbZip2.Text = "";
			this.tbZip2.Enter += new System.EventHandler(this.tbZip2_Enter);
			// 
			// tbZip1
			// 
			this.tbZip1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
			this.tbZip1.Location = new System.Drawing.Point(95, 85);
			this.tbZip1.MaxLength = 5;
			this.tbZip1.Name = "tbZip1";
			this.tbZip1.Size = new System.Drawing.Size(60, 20);
			this.tbZip1.TabIndex = 6;
			this.tbZip1.Text = "";
			this.tbZip1.Enter += new System.EventHandler(this.tbZip1_Enter);
			// 
			// cbState
			// 
			this.cbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbState.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
			this.cbState.Items.AddRange(new object[] {});
			this.cbState.Location = new System.Drawing.Point(160, 65);
			this.cbState.MaxLength = 10;
			this.cbState.Name = "cbState";
			this.cbState.Size = new System.Drawing.Size(50, 20);
			this.cbState.Sorted =false;
			this.cbState.TabIndex = 5;
			// 
			// tbCity
			// 
			this.tbCity.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
			this.tbCity.Location = new System.Drawing.Point(96, 40);
			this.tbCity.Name = "tbCity";
			this.tbCity.Size = new System.Drawing.Size(115, 20);
			this.tbCity.TabIndex = 3;
			this.tbCity.Text = "";
			this.tbCity.Enter += new System.EventHandler(this.tbCity_Enter);
			// 
			// tbAdditional
			// 
			this.tbAdditional.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
			this.tbAdditional.Location = new System.Drawing.Point(96, 20);
			this.tbAdditional.Name = "tbAdditional";
			this.tbAdditional.Size = new System.Drawing.Size(115, 20);
			this.tbAdditional.TabIndex = 2;
			this.tbAdditional.Text = "";
			this.tbAdditional.Enter += new System.EventHandler(this.tbAdditional_Enter);
			// 
			// tbAddress
			// 
			this.tbAddress.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
			this.tbAddress.Location = new System.Drawing.Point(96, 0);
			this.tbAddress.Name = "tbAddress";
			this.tbAddress.Size = new System.Drawing.Size(115, 20);
			this.tbAddress.TabIndex = 1;
			this.tbAddress.Text = "";
			this.tbAddress.Enter += new System.EventHandler(this.tbAddress_Enter);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
			this.label1.Location = new System.Drawing.Point(0, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 15);
			this.label1.TabIndex = 31;
			this.label1.Text = "Address 1";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
			this.label3.Location = new System.Drawing.Point(0, 25);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 15);
			this.label3.TabIndex = 32;
			this.label3.Text = "Address 2";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
			this.label4.Location = new System.Drawing.Point(0, 45);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 15);
			this.label4.TabIndex = 33;
			this.label4.Text = "City";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
			this.label5.Location = new System.Drawing.Point(0, 70);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(85, 15);
			this.label5.TabIndex = 34;
			this.label5.Text = "Country, State";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
			this.label2.Location = new System.Drawing.Point(0, 90);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(65, 15);
			this.label2.TabIndex = 35;
			this.label2.Text = "Zip";
			// 
			// Location
			// 
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbCountry);
			this.Controls.Add(this.tbZip2);
			this.Controls.Add(this.tbZip1);
			this.Controls.Add(this.cbState);
			this.Controls.Add(this.tbCity);
			this.Controls.Add(this.tbAdditional);
			this.Controls.Add(this.tbAddress);
			this.Name = "Location";
			this.Size = new System.Drawing.Size(216, 108);
			this.ResumeLayout(false);

		}
		#endregion

		public event EventHandler CountryChanged;

		protected virtual void OnChanged(EventArgs ea)
		{
			if(CountryChanged != null)
				CountryChanged(this, ea);
		}

		private void tbCountry_TextChanged(object sender, System.EventArgs e)
		{
			if(tbCountry.Text.ToUpper() != "USA" && tbCountry.Text.ToUpper() != "US" &&
				tbCountry.Text.ToUpper() != "U.S." && tbCountry.Text.ToUpper() != "U.S.A.")
			{
				cbState.Enabled = false;
				tbZip2.Enabled = false;
				tbZip1.MaxLength = 255;
			}
			else
			{
				cbState.Enabled = true;
				tbZip2.Enabled = true;
				tbZip1.MaxLength = 5;
			}

			OnChanged(EventArgs.Empty);
		}

		public void ClearFields()
		{
			tbAdditional.Text = "";
			tbAddress.Text = "";
			tbCity.Text = "";
			tbCountry.Text = "USA";
			tbZip1.Text = "";
			tbZip2.Text = "";
			cbState.Enabled = true;
		}

		private void tbAddress_Enter(object sender, System.EventArgs e)
		{
			tbAddress.SelectAll();
		}

		private void tbAdditional_Enter(object sender, System.EventArgs e)
		{
			tbAdditional.SelectAll();
		}

		private void tbCity_Enter(object sender, System.EventArgs e)
		{
			tbCity.SelectAll();
		}

		private void tbCountry_Enter(object sender, System.EventArgs e)
		{
			tbCountry.SelectAll();
		}

		private void tbZip1_Enter(object sender, System.EventArgs e)
		{
			tbZip1.SelectAll();
		}

		private void tbZip2_Enter(object sender, System.EventArgs e)
		{
			tbZip2.SelectAll();
		}
	}
}
