using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Cntrls.Front
{
	/// <summary>
	/// Summary description for Tab_TakeIn.
	/// </summary>
	public class Tab_TakeIn : System.Windows.Forms.UserControl
	{
		DataSet dsData;
		#region Generate

		internal System.Windows.Forms.Button btnClear;
		internal System.Windows.Forms.Button btnSubmit;
		internal System.Windows.Forms.GroupBox GroupBox4;
		private System.Windows.Forms.TextBox tbOrderSummary;
		internal System.Windows.Forms.GroupBox GroupBox2;
		private Cntrls.MessengerControl messengerControl1;
		private Cntrls.CustomerOrder coOrder;
		private Cntrls.MessengerControl mcMessenger;
		private Cntrls.Front.CustomerSelecter csCustomer;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Tab_TakeIn()
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
			this.coOrder = new Cntrls.CustomerOrder();
			this.btnClear = new System.Windows.Forms.Button();
			this.btnSubmit = new System.Windows.Forms.Button();
			this.GroupBox4 = new System.Windows.Forms.GroupBox();
			this.tbOrderSummary = new System.Windows.Forms.TextBox();
			this.GroupBox2 = new System.Windows.Forms.GroupBox();
			this.csCustomer = new Cntrls.Front.CustomerSelecter();
			this.mcMessenger = new Cntrls.MessengerControl();
			this.messengerControl1 = new Cntrls.MessengerControl();
			this.GroupBox4.SuspendLayout();
			this.GroupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// coOrder
			// 
			this.coOrder.Location = new System.Drawing.Point(2, 226);
			this.coOrder.Name = "coOrder";
			this.coOrder.Size = new System.Drawing.Size(680, 168);
			this.coOrder.TabIndex = 14;
			// 
			// btnClear
			// 
			this.btnClear.BackColor = System.Drawing.SystemColors.Control;
			this.btnClear.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
			this.btnClear.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnClear.Location = new System.Drawing.Point(507, 476);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(80, 20);
			this.btnClear.TabIndex = 12;
			this.btnClear.Text = "Clear";
			// 
			// btnSubmit
			// 
			this.btnSubmit.BackColor = System.Drawing.SystemColors.Control;
			this.btnSubmit.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
			this.btnSubmit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnSubmit.Location = new System.Drawing.Point(597, 476);
			this.btnSubmit.Name = "btnSubmit";
			this.btnSubmit.Size = new System.Drawing.Size(80, 20);
			this.btnSubmit.TabIndex = 13;
			this.btnSubmit.Text = "Submit";
//			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			// 
			// GroupBox4
			// 
			this.GroupBox4.Controls.Add(this.tbOrderSummary);
			this.GroupBox4.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
			this.GroupBox4.ForeColor = System.Drawing.Color.DimGray;
			this.GroupBox4.Location = new System.Drawing.Point(2, 391);
			this.GroupBox4.Name = "GroupBox4";
			this.GroupBox4.Size = new System.Drawing.Size(675, 80);
			this.GroupBox4.TabIndex = 11;
			this.GroupBox4.TabStop = false;
			this.GroupBox4.Text = "Order Summary";
			// 
			// tbOrderSummary
			// 
			this.tbOrderSummary.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(240)), ((System.Byte)(240)), ((System.Byte)(240)));
			this.tbOrderSummary.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbOrderSummary.Location = new System.Drawing.Point(8, 16);
			this.tbOrderSummary.Multiline = true;
			this.tbOrderSummary.Name = "tbOrderSummary";
			this.tbOrderSummary.ReadOnly = true;
			this.tbOrderSummary.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbOrderSummary.Size = new System.Drawing.Size(656, 56);
			this.tbOrderSummary.TabIndex = 3;
			this.tbOrderSummary.Text = "This filed contains dynamically updated order summary.";
			// 
			// GroupBox2
			// 
			this.GroupBox2.Controls.Add(this.csCustomer);
			this.GroupBox2.Controls.Add(this.mcMessenger);
			this.GroupBox2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
			this.GroupBox2.ForeColor = System.Drawing.Color.DimGray;
			this.GroupBox2.Location = new System.Drawing.Point(2, 1);
			this.GroupBox2.Name = "GroupBox2";
			this.GroupBox2.Size = new System.Drawing.Size(675, 220);
			this.GroupBox2.TabIndex = 10;
			this.GroupBox2.TabStop = false;
			this.GroupBox2.Text = "Customer Status";
			// 
			// csCustomer
			// 
			this.csCustomer.Location = new System.Drawing.Point(10, 20);
			this.csCustomer.Name = "csCustomer";
			this.csCustomer.Size = new System.Drawing.Size(655, 65);
			this.csCustomer.TabIndex = 6;
			// 
			// mcMessenger
			// 
			this.mcMessenger.Filter = "";
			this.mcMessenger.Location = new System.Drawing.Point(10, 95);
			this.mcMessenger.Name = "mcMessenger";
			this.mcMessenger.Size = new System.Drawing.Size(656, 122);
			this.mcMessenger.TabIndex = 5;
			// 
			// messengerControl1
			// 
			this.messengerControl1.Filter = "";
			this.messengerControl1.Location = new System.Drawing.Point(0, 0);
			this.messengerControl1.Name = "messengerControl1";
			this.messengerControl1.Size = new System.Drawing.Size(656, 122);
			this.messengerControl1.TabIndex = 0;
			// 
			// Tab_TakeIn
			// 
			this.Controls.Add(this.coOrder);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.btnSubmit);
			this.Controls.Add(this.GroupBox4);
			this.Controls.Add(this.GroupBox2);
			this.Name = "Tab_TakeIn";
			this.Size = new System.Drawing.Size(684, 497);
			this.GroupBox4.ResumeLayout(false);
			this.GroupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		#endregion Generate

		public void Initialize(DataSet dsData)
		{
			this.dsData = dsData;
			
			
			coOrder.InitializeOrder(dsData);


			/*
						DataView dvMessengers = new DataView(dsData.Tables["tblMessenger"]);
						dvMessengers.Sort = "MessengerID ASC";
		
						cbMessenger.BeginUpdate();	
						cbMessenger.DataSource = dvMessengers;
						cbMessenger.DisplayMember = "MessengerName";
						cbMessenger.ValueMember = "MessengerID";
						cbMessenger.EndUpdate();


						DataView dvCustomers = new DataView(dsFrontGet.Tables["tblCustomer"]);
						dvCustomers.Sort = "CustomerID ASC";

						cbCustomer.BeginUpdate();
						cbCustomer.DataSource = dvCustomers;
						cbCustomer.DisplayMember = "CustomerName";
						cbCustomer.ValueMember = "CustomerID";
						cbCustomer.EndUpdate();	

						ClearTakeIn();
						cbCustomer.Enabled = true;
						StatusBar.Text = "StatusBar";
		
			*/
		}

	}
}
