using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Cntrls.Front
{
	/// <summary>
	/// Summary description for CustomerSelecter.
	/// </summary>
	public class CustomerSelecter : System.Windows.Forms.UserControl
	{
		#region Generated
		private System.Windows.Forms.Panel panel7;
		internal System.Windows.Forms.Button btnDepSet;
		internal System.Windows.Forms.Button btnNewCustomer;
		private Cntrls.ComboTextComponent ctcCustomer;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CustomerSelecter()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CustomerSelecter));
			this.panel7 = new System.Windows.Forms.Panel();
			this.btnDepSet = new System.Windows.Forms.Button();
			this.btnNewCustomer = new System.Windows.Forms.Button();
			this.ctcCustomer = new Cntrls.ComboTextComponent();
			this.panel7.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel7
			// 
			this.panel7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel7.BackgroundImage")));
			this.panel7.Controls.Add(this.btnDepSet);
			this.panel7.Location = new System.Drawing.Point(0, 45);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(655, 20);
			this.panel7.TabIndex = 9;
			// 
			// btnDepSet
			// 
			this.btnDepSet.BackColor = System.Drawing.Color.LightSteelBlue;
			this.btnDepSet.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
			this.btnDepSet.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnDepSet.Location = new System.Drawing.Point(455, 0);
			this.btnDepSet.Name = "btnDepSet";
			this.btnDepSet.Size = new System.Drawing.Size(200, 20);
			this.btnDepSet.TabIndex = 9;
			this.btnDepSet.Text = "Departure Settings ";
			// 
			// btnNewCustomer
			// 
			this.btnNewCustomer.BackColor = System.Drawing.Color.LightSteelBlue;
			this.btnNewCustomer.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
			this.btnNewCustomer.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnNewCustomer.Location = new System.Drawing.Point(455, 0);
			this.btnNewCustomer.Name = "btnNewCustomer";
			this.btnNewCustomer.Size = new System.Drawing.Size(200, 20);
			this.btnNewCustomer.TabIndex = 8;
			this.btnNewCustomer.Text = "New Customer ";
			// 
			// ctcCustomer
			// 
			this.ctcCustomer.Location = new System.Drawing.Point(0, 0);
			this.ctcCustomer.Name = "ctcCustomer";
			this.ctcCustomer.Size = new System.Drawing.Size(656, 40);
			this.ctcCustomer.TabIndex = 10;
			// 
			// CustomerSelecter
			// 
			this.Controls.Add(this.btnNewCustomer);
			this.Controls.Add(this.ctcCustomer);
			this.Controls.Add(this.panel7);
			this.Name = "CustomerSelecter";
			this.Size = new System.Drawing.Size(655, 65);
			this.panel7.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		#endregion Generated

		public void Initialize(DataTable dtData)
		{
			ctcCustomer.Initialize(dtData);
		
			
		}

		public void Clear()
		{
			ctcCustomer.Clear();
		}
	}
}
