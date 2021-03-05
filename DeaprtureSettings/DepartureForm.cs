using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace gemoDream
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class DeaprtureForm: System.Windows.Forms.Form
	{
		private DataSet dsData;		
		#region Generated
		private System.Windows.Forms.Button btnSet;
		private System.Windows.Forms.Label lbEntryBatch;
		private System.Windows.Forms.Label lbCustomer;
		private Cntrls.ComboTextComponent ctcVendor;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DeaprtureForm()
		{
			InitializeComponent();
			string CustomerName = lbCustomer.Text;
			string EntryBatchCode = lbEntryBatch.Text;
			Initialize(CustomerName,EntryBatchCode);
		}
		public DeaprtureForm(string CustomerName)
		{
			InitializeComponent();
			string EntryBatchCode = lbEntryBatch.Text;
			Initialize(CustomerName,EntryBatchCode);			
		}
		public DeaprtureForm(string CustomerName, string EntryBatchCode)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			Initialize(CustomerName, EntryBatchCode);
			
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
			this.btnSet = new System.Windows.Forms.Button();
			this.lbEntryBatch = new System.Windows.Forms.Label();
			this.lbCustomer = new System.Windows.Forms.Label();
			this.ctcVendor = new Cntrls.ComboTextComponent();
			this.SuspendLayout();
			// 
			// btnSet
			// 
			this.btnSet.BackColor = System.Drawing.SystemColors.Control;
			this.btnSet.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
			this.btnSet.Location = new System.Drawing.Point(320, 112);
			this.btnSet.Name = "btnSet";
			this.btnSet.Size = new System.Drawing.Size(65, 20);
			this.btnSet.TabIndex = 14;
			this.btnSet.Text = "Set";
			this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
			// 
			// lbEntryBatch
			// 
			this.lbEntryBatch.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(240)), ((System.Byte)(240)), ((System.Byte)(240)));
			this.lbEntryBatch.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
			this.lbEntryBatch.Location = new System.Drawing.Point(8, 40);
			this.lbEntryBatch.Name = "lbEntryBatch";
			this.lbEntryBatch.Size = new System.Drawing.Size(370, 15);
			this.lbEntryBatch.TabIndex = 12;
			this.lbEntryBatch.Text = "Scan Bag/Receipt Number";
			// 
			// lbCustomer
			// 
			this.lbCustomer.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(240)), ((System.Byte)(240)), ((System.Byte)(240)));
			this.lbCustomer.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
			this.lbCustomer.Location = new System.Drawing.Point(8, 16);
			this.lbCustomer.Name = "lbCustomer";
			this.lbCustomer.Size = new System.Drawing.Size(370, 15);
			this.lbCustomer.TabIndex = 11;
			this.lbCustomer.Text = "Customer Name";
			// 
			// ctcVendor
			// 
			this.ctcVendor.DefaultText = "Vendor Lookup";
			this.ctcVendor.DisplayMember = "CustomerName";
			this.ctcVendor.InsertDefaultRow = true;
			this.ctcVendor.Location = new System.Drawing.Point(8, 64);
			this.ctcVendor.Name = "ctcVendor";
			this.ctcVendor.Size = new System.Drawing.Size(370, 40);
			this.ctcVendor.TabIndex = 15;
			this.ctcVendor.ValueMember = "CustomerID";
			// 
			// DeaprtureForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
			this.ClientSize = new System.Drawing.Size(390, 134);
			this.Controls.Add(this.ctcVendor);
			this.Controls.Add(this.btnSet);
			this.Controls.Add(this.lbEntryBatch);
			this.Controls.Add(this.lbCustomer);
			this.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.Name = "DeaprtureForm";
			this.Text = "Departure Settings";
			this.ResumeLayout(false);

		}
		#endregion
		#endregion Generated
		public void Initialize(string sCustomerName,string sEntryBatchCode)
		{
			lbEntryBatch.Text = sEntryBatchCode;
			Initialize(sCustomerName);
		}
		public void Initialize(string sCustomerName)
		{
			this.Text = Service.sProgramTitle + this.Text;
			lbCustomer.Text = sCustomerName;
			
			//Get data & fill ComboBox 
			ctcVendor.Initialize(gemoDream.Service.GetDepartureSet());
		}

		private void btnSet_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		public DataRowView SelectedValue
		{
			get
			{
				return (DataRowView)ctcVendor.ComboField.cbField.SelectedItem;
			}
		}
	}
}
