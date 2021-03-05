using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Cntrls
{
	/// <summary>
	/// Summary description for Permissions.
	/// </summary>
	public class Permissions : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.CheckBox chbChangeOrderOnLine;
		private System.Windows.Forms.CheckBox chbPlaceOrderOnLine;
		private System.Windows.Forms.CheckBox chbCheckResultsOnLine;
		private System.Windows.Forms.CheckBox chbCheckOrderStatusOnLine;
		private System.Windows.Forms.CheckBox chbChangeOrder;
		private System.Windows.Forms.CheckBox chbSubmit;
		private System.Windows.Forms.CheckBox chbPickup;
		private System.Windows.Forms.CheckBox chbOrder;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.GroupBox gbPermissions;
		public CheckBox[] achbPermissions;

		public Permissions()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
			achbPermissions = new CheckBox[] {chbOrder, chbPickup, chbSubmit, chbChangeOrder, 
												 chbCheckOrderStatusOnLine, chbCheckResultsOnLine, chbPlaceOrderOnLine, 
												 chbChangeOrderOnLine};
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
			this.gbPermissions = new System.Windows.Forms.GroupBox();
			this.chbChangeOrderOnLine = new System.Windows.Forms.CheckBox();
			this.chbPlaceOrderOnLine = new System.Windows.Forms.CheckBox();
			this.chbCheckResultsOnLine = new System.Windows.Forms.CheckBox();
			this.chbCheckOrderStatusOnLine = new System.Windows.Forms.CheckBox();
			this.chbChangeOrder = new System.Windows.Forms.CheckBox();
			this.chbSubmit = new System.Windows.Forms.CheckBox();
			this.chbPickup = new System.Windows.Forms.CheckBox();
			this.chbOrder = new System.Windows.Forms.CheckBox();
			this.gbPermissions.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbPermissions
			// 
			this.gbPermissions.Controls.Add(this.chbChangeOrderOnLine);
			this.gbPermissions.Controls.Add(this.chbPlaceOrderOnLine);
			this.gbPermissions.Controls.Add(this.chbCheckResultsOnLine);
			this.gbPermissions.Controls.Add(this.chbCheckOrderStatusOnLine);
			this.gbPermissions.Controls.Add(this.chbChangeOrder);
			this.gbPermissions.Controls.Add(this.chbSubmit);
			this.gbPermissions.Controls.Add(this.chbPickup);
			this.gbPermissions.Controls.Add(this.chbOrder);
			this.gbPermissions.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
			this.gbPermissions.ForeColor = System.Drawing.SystemColors.ControlText;
			this.gbPermissions.Location = new System.Drawing.Point(0, 0);
			this.gbPermissions.Name = "gbPermissions";
			this.gbPermissions.Size = new System.Drawing.Size(180, 205);
			this.gbPermissions.TabIndex = 23;
			this.gbPermissions.TabStop = false;
			this.gbPermissions.Text = "Permissions";
			// 
			// chbChangeOrderOnLine
			// 
			this.chbChangeOrderOnLine.Location = new System.Drawing.Point(10, 170);
			this.chbChangeOrderOnLine.Name = "chbChangeOrderOnLine";
			this.chbChangeOrderOnLine.Size = new System.Drawing.Size(166, 15);
			this.chbChangeOrderOnLine.TabIndex = 7;
			this.chbChangeOrderOnLine.Text = "Change Order Online";
			// 
			// chbPlaceOrderOnLine
			// 
			this.chbPlaceOrderOnLine.Location = new System.Drawing.Point(10, 150);
			this.chbPlaceOrderOnLine.Name = "chbPlaceOrderOnLine";
			this.chbPlaceOrderOnLine.Size = new System.Drawing.Size(166, 15);
			this.chbPlaceOrderOnLine.TabIndex = 6;
			this.chbPlaceOrderOnLine.Text = "Place Order Online";
			// 
			// chbCheckResultsOnLine
			// 
			this.chbCheckResultsOnLine.Location = new System.Drawing.Point(10, 130);
			this.chbCheckResultsOnLine.Name = "chbCheckResultsOnLine";
			this.chbCheckResultsOnLine.Size = new System.Drawing.Size(166, 15);
			this.chbCheckResultsOnLine.TabIndex = 5;
			this.chbCheckResultsOnLine.Text = "Check Results On-line";
			// 
			// chbCheckOrderStatusOnLine
			// 
			this.chbCheckOrderStatusOnLine.Location = new System.Drawing.Point(10, 110);
			this.chbCheckOrderStatusOnLine.Name = "chbCheckOrderStatusOnLine";
			this.chbCheckOrderStatusOnLine.Size = new System.Drawing.Size(166, 15);
			this.chbCheckOrderStatusOnLine.TabIndex = 4;
			this.chbCheckOrderStatusOnLine.Text = "Check Order Status On-line";
			// 
			// chbChangeOrder
			// 
			this.chbChangeOrder.Location = new System.Drawing.Point(10, 90);
			this.chbChangeOrder.Name = "chbChangeOrder";
			this.chbChangeOrder.Size = new System.Drawing.Size(166, 15);
			this.chbChangeOrder.TabIndex = 3;
			this.chbChangeOrder.Text = "Change Order";
			// 
			// chbSubmit
			// 
			this.chbSubmit.Location = new System.Drawing.Point(10, 70);
			this.chbSubmit.Name = "chbSubmit";
			this.chbSubmit.Size = new System.Drawing.Size(166, 15);
			this.chbSubmit.TabIndex = 2;
			this.chbSubmit.Text = "Submit";
			// 
			// chbPickup
			// 
			this.chbPickup.Location = new System.Drawing.Point(10, 50);
			this.chbPickup.Name = "chbPickup";
			this.chbPickup.Size = new System.Drawing.Size(166, 15);
			this.chbPickup.TabIndex = 1;
			this.chbPickup.Text = "Pick Up";
			// 
			// chbOrder
			// 
			this.chbOrder.Location = new System.Drawing.Point(10, 30);
			this.chbOrder.Name = "chbOrder";
			this.chbOrder.Size = new System.Drawing.Size(166, 15);
			this.chbOrder.TabIndex = 0;
			this.chbOrder.Text = "Order";
			// 
			// Permissions
			// 
			this.Controls.Add(this.gbPermissions);
			this.Name = "Permissions";
			this.Size = new System.Drawing.Size(184, 208);
			this.Resize += new System.EventHandler(this.Permissions_Resize);
			this.gbPermissions.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void Permissions_Resize(object sender, System.EventArgs e)
		{
			gbPermissions.Width = this.Width - 5;
			gbPermissions.Height = this.Height - 5;
		}

		public void ClearChecks()
		{
			for(int i = 0; i < achbPermissions.Length; i++)
			{
				achbPermissions[i].Checked = false;
			}
		}
	}
}
