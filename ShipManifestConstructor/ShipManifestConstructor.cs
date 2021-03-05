using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Xml;
using System.IO;
using System.Diagnostics;
using gemoDream.gemoDreamService;
using NewCntrls;

namespace gemoDream
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class ShipManifestConstructor : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ComboBox cbDeliveryPerson;
		private System.Windows.Forms.ComboBox cbMessenger;
		private System.Windows.Forms.ComboBox cbCarrrier;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbManifestID;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button bLoadManifest;
		private System.Windows.Forms.Button bSaveManifest;
		private System.Windows.Forms.Button bClearManifest;
		private System.Windows.Forms.Button bDelete;
		private System.Windows.Forms.Button bExit;
		private System.Windows.Forms.Button bAddLine;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ShipManifestConstructor(DataSet dsShippingData)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			Init();
			LoadShippingDetails();
			LoadShippingDataSet(dsShippingData);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.cbDeliveryPerson = new System.Windows.Forms.ComboBox();
			this.cbMessenger = new System.Windows.Forms.ComboBox();
			this.cbCarrrier = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tbManifestID = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.bLoadManifest = new System.Windows.Forms.Button();
			this.bSaveManifest = new System.Windows.Forms.Button();
			this.bClearManifest = new System.Windows.Forms.Button();
			this.bDelete = new System.Windows.Forms.Button();
			this.bExit = new System.Windows.Forms.Button();
			this.bAddLine = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Location = new System.Drawing.Point(5, 235);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(867, 340);
			this.panel1.TabIndex = 0;
			// 
			// cbDeliveryPerson
			// 
			this.cbDeliveryPerson.Location = new System.Drawing.Point(112, 8);
			this.cbDeliveryPerson.Name = "cbDeliveryPerson";
			this.cbDeliveryPerson.Size = new System.Drawing.Size(240, 21);
			this.cbDeliveryPerson.TabIndex = 1;
			// 
			// cbMessenger
			// 
			this.cbMessenger.Location = new System.Drawing.Point(112, 48);
			this.cbMessenger.Name = "cbMessenger";
			this.cbMessenger.Size = new System.Drawing.Size(240, 21);
			this.cbMessenger.TabIndex = 2;
			// 
			// cbCarrrier
			// 
			this.cbCarrrier.Location = new System.Drawing.Point(112, 88);
			this.cbCarrrier.Name = "cbCarrrier";
			this.cbCarrrier.Size = new System.Drawing.Size(240, 21);
			this.cbCarrrier.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 20);
			this.label1.TabIndex = 4;
			this.label1.Text = "Delivered by";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(96, 20);
			this.label2.TabIndex = 5;
			this.label2.Text = "Messenger";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 88);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(104, 20);
			this.label3.TabIndex = 6;
			this.label3.Text = "Carrier";
			// 
			// tbManifestID
			// 
			this.tbManifestID.Location = new System.Drawing.Point(112, 136);
			this.tbManifestID.Name = "tbManifestID";
			this.tbManifestID.Size = new System.Drawing.Size(88, 20);
			this.tbManifestID.TabIndex = 7;
			this.tbManifestID.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 136);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(96, 24);
			this.label4.TabIndex = 8;
			this.label4.Text = "Manifest #";
			// 
			// bLoadManifest
			// 
			this.bLoadManifest.Location = new System.Drawing.Point(232, 136);
			this.bLoadManifest.Name = "bLoadManifest";
			this.bLoadManifest.Size = new System.Drawing.Size(104, 20);
			this.bLoadManifest.TabIndex = 9;
			this.bLoadManifest.Text = "Load Manifest";
			// 
			// bSaveManifest
			// 
			this.bSaveManifest.Location = new System.Drawing.Point(536, 584);
			this.bSaveManifest.Name = "bSaveManifest";
			this.bSaveManifest.Size = new System.Drawing.Size(104, 20);
			this.bSaveManifest.TabIndex = 10;
			this.bSaveManifest.Text = "Save Manifest";
			// 
			// bClearManifest
			// 
			this.bClearManifest.Location = new System.Drawing.Point(232, 584);
			this.bClearManifest.Name = "bClearManifest";
			this.bClearManifest.Size = new System.Drawing.Size(104, 20);
			this.bClearManifest.TabIndex = 11;
			this.bClearManifest.Text = "Clear Manifest";
			// 
			// bDelete
			// 
			this.bDelete.Location = new System.Drawing.Point(376, 584);
			this.bDelete.Name = "bDelete";
			this.bDelete.Size = new System.Drawing.Size(104, 20);
			this.bDelete.TabIndex = 12;
			this.bDelete.Text = "Delete Manifest";
			// 
			// bExit
			// 
			this.bExit.Location = new System.Drawing.Point(664, 584);
			this.bExit.Name = "bExit";
			this.bExit.Size = new System.Drawing.Size(104, 20);
			this.bExit.TabIndex = 13;
			this.bExit.Text = "Exit";
			// 
			// bAddLine
			// 
			this.bAddLine.BackColor = System.Drawing.Color.LemonChiffon;
			this.bAddLine.Location = new System.Drawing.Point(16, 584);
			this.bAddLine.Name = "bAddLine";
			this.bAddLine.Size = new System.Drawing.Size(104, 20);
			this.bAddLine.TabIndex = 14;
			this.bAddLine.Text = "Add Line";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(5, 200);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(50, 16);
			this.label5.TabIndex = 15;
			this.label5.Text = "Order #";
			this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(60, 200);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 16);
			this.label6.TabIndex = 16;
			this.label6.Text = "Order\'s Memo";
			this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(160, 200);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(100, 16);
			this.label7.TabIndex = 17;
			this.label7.Text = "Batches Memo";
			this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(250, 200);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(100, 16);
			this.label8.TabIndex = 18;
			this.label8.Text = "Parcel";
			this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(350, 200);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(100, 16);
			this.label9.TabIndex = 19;
			this.label9.Text = "Envelope";
			this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(455, 200);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(40, 16);
			this.label10.TabIndex = 20;
			this.label10.Text = "Qty";
			this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(500, 200);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(300, 16);
			this.label11.TabIndex = 21;
			this.label11.Text = "Comments";
			this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// ShipManifestConstructor
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(912, 621);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.bAddLine);
			this.Controls.Add(this.bExit);
			this.Controls.Add(this.bDelete);
			this.Controls.Add(this.bClearManifest);
			this.Controls.Add(this.bSaveManifest);
			this.Controls.Add(this.bLoadManifest);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.tbManifestID);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cbCarrrier);
			this.Controls.Add(this.cbMessenger);
			this.Controls.Add(this.cbDeliveryPerson);
			this.Controls.Add(this.panel1);
			this.Name = "ShipManifestConstructor";
			this.Text = "Create/Edit Shipping Manifesr";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			//Application.Run(new ShipManifestConstructor());
		}
		private void Init()
		{
			tbManifestID.Text = "";
			bLoadManifest.Enabled = false;
			bAddLine.Enabled = false;
			bClearManifest.Enabled = false;
			bDelete.Enabled = false;

		}
		private void LoadShippingDetails()
		{
//			cbDeliveryPerson.BeginUpdate();
//			cbDeliveryPerson.DataSource = 
//			cbDeliveryPerson.DisplayMember = 

		}
//dtEntryBatch.Rows[0]["CustomerName"] != DBNull.Value
		private void LoadShippingDataSet(DataSet dsShippingData)
		{
			int Pos = 1;
			panel1.Controls.Clear();
			if(dsShippingData != null)
			{
				if(dsShippingData.Tables.Count > 0)
				{
					if(dsShippingData.Tables[0].Rows.Count > 0)
					{
						foreach(DataRow dr in dsShippingData.Tables[0].Rows)
						{
							ManifestDetails mnfNew = new ManifestDetails();
							if(panel1.Controls.Count > 0)
								mnfNew.Location = new Point(Pos, panel1.Controls[panel1.Controls.Count - 1].Location.Y + 21);
							else
								mnfNew.Location = new Point(Pos, 1);
							
								mnfNew.tbOrder.Text = dr["OrderCode"].ToString().Trim();
								mnfNew.tbQuantity.Text = dr["Quantity"].ToString().Trim();
							if(dr["MemoNumberID"].ToString().Trim() == "")
								mnfNew.tbMainMemo.Text = dr["MemoNumber"].ToString().Trim();
							else
							{
								mnfNew.tbMainMemo.Text = "";
								mnfNew.tbBatchSetMemo.Text = dr["MemoNumber"].ToString().Trim();
							}

							panel1.Controls.Add(mnfNew);
							panel1.ScrollControlIntoView(mnfNew);
						}
					
					}
				
				}
			
			
			}
		}
	}
}
