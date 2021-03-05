using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Cntrls;
using System.Data;
using System.Text.RegularExpressions;
using System.IO;


namespace gemoDream
{
	/// <summary>
	/// Summary description for FormSelectCustomerProgram.
	/// </summary>
	public class FormSelectCustomerProgram : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ComboBox cbCustomerPrograms;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		//private DataSet dsCp;
		//private DataSet dsCps;
		private DataSet dsCustPrograms;
		private DataSet dsParts;
		private DataSet dsOldCustProgram;
		private DataSet dsCompareCP;
	
		private bool bFormLoaded = false; 
		private bool nonNumberEntered;

		string sCustomerID;
		string sCustomerOfficeID;
		string sVendorID;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		string sVendorOfficeID;
		string sItemTypeID;
		string sOldCPID;

		private System.Windows.Forms.TextBox tbDescription;
		private Cntrls.PartTree ptPartTree;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbComments;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.PictureBox pictureBoxNew;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbDescriptionNew;
		private System.Windows.Forms.TextBox tbCommentsNew;
		private System.Windows.Forms.TextBox tbCustomerID;
		private System.Windows.Forms.TextBox tbCustomerStyle;
		private System.Windows.Forms.TextBox tbSRP;
		private System.Windows.Forms.TextBox tbCustomerIDNew;
		private System.Windows.Forms.TextBox tbCustomerStyleNew;
		private System.Windows.Forms.TextBox tbSRPNew;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.DataGrid dgNewCPDetails;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.DataGrid dgDiscrepancy;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox tbCustomerProgram;
		private System.Windows.Forms.DataGrid dgOldCPDetails;

		public FormSelectCustomerProgram()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public FormSelectCustomerProgram(string CustomerID,string CustomerOfficeID,string VendorID,string VendorOfficeID, string ItemTypeID, string oldCPID)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			//string[] Codes = Code.Split('.'); 
			//sOrderCode = Codes[0];
			//sBatchCode = Codes[3];
			//dsCp = GetCustomer(sOrderCode, sBatchCode);
			tbCustomerProgram.Text = "";
			sOldCPID = oldCPID;
			sCustomerID = CustomerID;
			sCustomerOfficeID = CustomerOfficeID;
			sVendorID = VendorID;
			sVendorOfficeID = VendorOfficeID;
			sItemTypeID = ItemTypeID;
			dsParts = new DataSet();
			dsParts.Tables.Add(Service.GetParts(sItemTypeID));
			
			ClearText(this);
			InitOldCPData(oldCPID);
			SelectCP();
			dgOldCPDetails.SetDataBinding(null,"");
			dgNewCPDetails.SetDataBinding(null,"");
			dgDiscrepancy.SetDataBinding(null,"");
			bFormLoaded = true;
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
		private void SelectCP()
		{
			try
			{
				//this.pictureBox1.Image = null;
				this.pictureBoxNew.Image = null;
				DataSet dsTmp1 = new DataSet();	
				//DataSet dsCustPrograms;
				dsTmp1.Tables.Add("CustomerProgramsPerCustomer");
				dsTmp1.Tables["CustomerProgramsPerCustomer"].Columns.Add(new DataColumn("CustomerOfficeID",Type.GetType("System.String")));
				dsTmp1.Tables["CustomerProgramsPerCustomer"].Columns.Add(new DataColumn("CustomerID",Type.GetType("System.String")));
				dsTmp1.Tables["CustomerProgramsPerCustomer"].Columns.Add(new DataColumn("VendorOfficeID",Type.GetType("System.String")));
				dsTmp1.Tables["CustomerProgramsPerCustomer"].Columns.Add(new DataColumn("VendorID",Type.GetType("System.String")));
				DataRow row = dsTmp1.Tables["CustomerProgramsPerCustomer"].NewRow();

				row["CustomerID"] = sCustomerID;
				row["CustomerOfficeID"] = sCustomerOfficeID;
				if(sVendorID!=null && sVendorID != "")
					row["VendorOfficeID"] = sVendorID;
				else
					row["VendorOfficeID"] = DBNull.Value;

				if(sVendorOfficeID != null && sVendorOfficeID != "")
					row["VendorOfficeID"] = sVendorOfficeID;
				else
					row["VendorOfficeID"] = DBNull.Value;

				dsTmp1.Tables["CustomerProgramsPerCustomer"].Rows.Add(row);
				dsTmp1.AcceptChanges();
				dsCustPrograms = Service.ProxyGenericGet(dsTmp1);//Procedure dbo.spGetCustomerProgramsPerCustomer (for customer of the new stones)

				DataRow drNone1 = dsCustPrograms.Tables[0].NewRow();
				drNone1["CustomerProgramName"] = "[Select CP From List]";
				drNone1["ItemTypeID"] = sItemTypeID;
				dsCustPrograms.Tables[0].Rows.InsertAt(drNone1, 0);
				
				DataView dvCustProgram = new DataView(dsCustPrograms.Tables[0]);
					
				string filter = "ItemTypeID = '" + sItemTypeID + "'";

				dvCustProgram.RowFilter = filter;
				if(dvCustProgram.Count > 0)
				{
					cbCustomerPrograms.DataSource = dvCustProgram;
					cbCustomerPrograms.DisplayMember = "CustomerProgramName";
					cbCustomerPrograms.ValueMember = "CPID";
					cbCustomerPrograms.SelectedIndex = 0;
					//LoadPicture();
					//LoadComDescr();
				}
					//				DataRow[] drs = dsCustPrograms.Tables[0].Select(filter);
					//				if (drs.Length >0)
					//				{
					//					foreach(DataRow dr in drs)
					//					{
					//						cbCustomerPrograms.Items.Add(dr["CustomerProgramName"]); 
					//						//cbCustomerPrograms.Items
					//					}
					//				}
				else
				{
					MessageBox.Show("Customer has no CPs for current structure");
					this.DialogResult = DialogResult.No;		
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
						
			this.Cursor = Cursors.Default;
		}

		/*private DataSet GetCustomer(string strOrderCode, string strBatchCode)
		{
			DataSet dsData = new DataSet();
			dsData.Tables.Add("CustomerProgramInstanceByBatchCodeTypeOf");
			dsData = gemoDream.Service.ProxyGenericGet(dsData);
			dsData.Tables[0].TableName = "CustomerProgramInstanceByBatchCode";
			dsData.Tables[0].Rows.Add(dsData.Tables[0].NewRow());
			dsData.Tables[0].Rows[0]["GroupCode"] = strOrderCode;
			dsData.Tables[0].Rows[0]["BatchCode"] = strBatchCode;
			dsCp = gemoDream.Service.ProxyGenericGet(dsData);
			return dsCp;
		}*/
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormSelectCustomerProgram));
			this.cbCustomerPrograms = new System.Windows.Forms.ComboBox();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.tbDescription = new System.Windows.Forms.TextBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tbComments = new System.Windows.Forms.TextBox();
			this.dgOldCPDetails = new System.Windows.Forms.DataGrid();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.tbSRPNew = new System.Windows.Forms.TextBox();
			this.tbCustomerStyleNew = new System.Windows.Forms.TextBox();
			this.tbCustomerIDNew = new System.Windows.Forms.TextBox();
			this.tbCommentsNew = new System.Windows.Forms.TextBox();
			this.tbDescriptionNew = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.pictureBoxNew = new System.Windows.Forms.PictureBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.tbSRP = new System.Windows.Forms.TextBox();
			this.tbCustomerStyle = new System.Windows.Forms.TextBox();
			this.tbCustomerID = new System.Windows.Forms.TextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.label14 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.dgDiscrepancy = new System.Windows.Forms.DataGrid();
			this.dgNewCPDetails = new System.Windows.Forms.DataGrid();
			this.tbCustomerProgram = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.dgOldCPDetails)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgDiscrepancy)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgNewCPDetails)).BeginInit();
			this.SuspendLayout();
			// 
			// cbCustomerPrograms
			// 
			this.cbCustomerPrograms.Location = new System.Drawing.Point(296, 24);
			this.cbCustomerPrograms.MaxDropDownItems = 20;
			this.cbCustomerPrograms.Name = "cbCustomerPrograms";
			this.cbCustomerPrograms.Size = new System.Drawing.Size(224, 20);
			this.cbCustomerPrograms.TabIndex = 0;
			this.cbCustomerPrograms.SelectedIndexChanged += new System.EventHandler(this.cbCustomerPrograms_SelectedIndexChanged);
			// 
			// btnOk
			// 
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.Yes;
			this.btnOk.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.btnOk.Location = new System.Drawing.Point(536, 24);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(100, 20);
			this.btnOk.TabIndex = 1;
			this.btnOk.Text = "SELECT";
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.No;
			this.btnCancel.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.btnCancel.Location = new System.Drawing.Point(656, 24);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(100, 20);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// tbDescription
			// 
			this.tbDescription.Location = new System.Drawing.Point(8, 224);
			this.tbDescription.Multiline = true;
			this.tbDescription.Name = "tbDescription";
			this.tbDescription.Size = new System.Drawing.Size(344, 224);
			this.tbDescription.TabIndex = 3;
			this.tbDescription.Text = "";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pictureBox1.Location = new System.Drawing.Point(8, 56);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(136, 136);
			this.pictureBox1.TabIndex = 5;
			this.pictureBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(8, 208);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(128, 16);
			this.label1.TabIndex = 7;
			this.label1.Text = "Description:";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(8, 464);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(112, 16);
			this.label2.TabIndex = 8;
			this.label2.Text = "Comments:";
			// 
			// tbComments
			// 
			this.tbComments.Location = new System.Drawing.Point(8, 488);
			this.tbComments.Multiline = true;
			this.tbComments.Name = "tbComments";
			this.tbComments.Size = new System.Drawing.Size(344, 112);
			this.tbComments.TabIndex = 9;
			this.tbComments.Text = "";
			// 
			// dgOldCPDetails
			// 
			this.dgOldCPDetails.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dgOldCPDetails.CaptionFont = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dgOldCPDetails.CaptionVisible = false;
			this.dgOldCPDetails.DataMember = "";
			this.dgOldCPDetails.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dgOldCPDetails.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgOldCPDetails.Location = new System.Drawing.Point(8, 96);
			this.dgOldCPDetails.Name = "dgOldCPDetails";
			this.dgOldCPDetails.Size = new System.Drawing.Size(376, 304);
			this.dgOldCPDetails.TabIndex = 10;
			// 
			// tabControl1
			// 
			this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tabControl1.Location = new System.Drawing.Point(8, 56);
			this.tabControl1.Multiline = true;
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(808, 672);
			this.tabControl1.TabIndex = 11;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.groupBox2);
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tabPage1.Location = new System.Drawing.Point(24, 4);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(780, 664);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Picture/Description/Comments";
			// 
			// groupBox2
			// 
			this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.tbSRPNew);
			this.groupBox2.Controls.Add(this.tbCustomerStyleNew);
			this.groupBox2.Controls.Add(this.tbCustomerIDNew);
			this.groupBox2.Controls.Add(this.tbCommentsNew);
			this.groupBox2.Controls.Add(this.tbDescriptionNew);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.pictureBoxNew);
			this.groupBox2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBox2.Location = new System.Drawing.Point(405, 5);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(370, 627);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "New CP: ";
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label10.Location = new System.Drawing.Point(168, 144);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(168, 16);
			this.label10.TabIndex = 10;
			this.label10.Text = "SRP";
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label9.Location = new System.Drawing.Point(168, 88);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(168, 16);
			this.label9.TabIndex = 9;
			this.label9.Text = "Customer Style";
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label8.Location = new System.Drawing.Point(168, 32);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(136, 16);
			this.label8.TabIndex = 8;
			this.label8.Text = "Customer ID";
			// 
			// tbSRPNew
			// 
			this.tbSRPNew.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbSRPNew.Location = new System.Drawing.Point(168, 168);
			this.tbSRPNew.Name = "tbSRPNew";
			this.tbSRPNew.Size = new System.Drawing.Size(176, 21);
			this.tbSRPNew.TabIndex = 7;
			this.tbSRPNew.Text = "tbSRPNew";
			// 
			// tbCustomerStyleNew
			// 
			this.tbCustomerStyleNew.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbCustomerStyleNew.Location = new System.Drawing.Point(168, 112);
			this.tbCustomerStyleNew.Name = "tbCustomerStyleNew";
			this.tbCustomerStyleNew.Size = new System.Drawing.Size(176, 21);
			this.tbCustomerStyleNew.TabIndex = 6;
			this.tbCustomerStyleNew.Text = "tbCustomerStyleNew";
			// 
			// tbCustomerIDNew
			// 
			this.tbCustomerIDNew.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbCustomerIDNew.Location = new System.Drawing.Point(168, 56);
			this.tbCustomerIDNew.Name = "tbCustomerIDNew";
			this.tbCustomerIDNew.Size = new System.Drawing.Size(192, 21);
			this.tbCustomerIDNew.TabIndex = 5;
			this.tbCustomerIDNew.Text = "tbCustomerIDNew";
			// 
			// tbCommentsNew
			// 
			this.tbCommentsNew.Location = new System.Drawing.Point(8, 488);
			this.tbCommentsNew.Multiline = true;
			this.tbCommentsNew.Name = "tbCommentsNew";
			this.tbCommentsNew.Size = new System.Drawing.Size(344, 112);
			this.tbCommentsNew.TabIndex = 4;
			this.tbCommentsNew.Text = "";
			// 
			// tbDescriptionNew
			// 
			this.tbDescriptionNew.Location = new System.Drawing.Point(8, 224);
			this.tbDescriptionNew.Multiline = true;
			this.tbDescriptionNew.Name = "tbDescriptionNew";
			this.tbDescriptionNew.Size = new System.Drawing.Size(344, 224);
			this.tbDescriptionNew.TabIndex = 3;
			this.tbDescriptionNew.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 464);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(112, 16);
			this.label4.TabIndex = 2;
			this.label4.Text = "Comments:";
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.SystemColors.Control;
			this.label3.Location = new System.Drawing.Point(16, 208);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(112, 24);
			this.label3.TabIndex = 1;
			this.label3.Text = "Description:";
			// 
			// pictureBoxNew
			// 
			this.pictureBoxNew.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pictureBoxNew.Location = new System.Drawing.Point(8, 56);
			this.pictureBoxNew.Name = "pictureBoxNew";
			this.pictureBoxNew.Size = new System.Drawing.Size(136, 136);
			this.pictureBoxNew.TabIndex = 0;
			this.pictureBoxNew.TabStop = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.tbSRP);
			this.groupBox1.Controls.Add(this.tbCustomerStyle);
			this.groupBox1.Controls.Add(this.tbCustomerID);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.tbComments);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.tbDescription);
			this.groupBox1.Controls.Add(this.pictureBox1);
			this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(5, 5);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(370, 627);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Old CP: ";
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label7.Location = new System.Drawing.Point(168, 144);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(104, 16);
			this.label7.TabIndex = 15;
			this.label7.Text = "SRP";
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label6.Location = new System.Drawing.Point(168, 88);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(104, 16);
			this.label6.TabIndex = 14;
			this.label6.Text = "Customer Style";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.Location = new System.Drawing.Point(168, 32);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(168, 16);
			this.label5.TabIndex = 13;
			this.label5.Text = "Customer ID";
			// 
			// tbSRP
			// 
			this.tbSRP.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbSRP.Location = new System.Drawing.Point(168, 168);
			this.tbSRP.Name = "tbSRP";
			this.tbSRP.Size = new System.Drawing.Size(192, 21);
			this.tbSRP.TabIndex = 12;
			this.tbSRP.Text = "tbSRP";
			// 
			// tbCustomerStyle
			// 
			this.tbCustomerStyle.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbCustomerStyle.Location = new System.Drawing.Point(168, 112);
			this.tbCustomerStyle.Name = "tbCustomerStyle";
			this.tbCustomerStyle.Size = new System.Drawing.Size(192, 21);
			this.tbCustomerStyle.TabIndex = 11;
			this.tbCustomerStyle.Text = "tbCustomerStyle";
			// 
			// tbCustomerID
			// 
			this.tbCustomerID.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbCustomerID.Location = new System.Drawing.Point(168, 56);
			this.tbCustomerID.Name = "tbCustomerID";
			this.tbCustomerID.Size = new System.Drawing.Size(192, 21);
			this.tbCustomerID.TabIndex = 10;
			this.tbCustomerID.Text = "tbCustomerID";
			// 
			// tabPage2
			// 
			this.tabPage2.BackColor = System.Drawing.Color.LightGray;
			this.tabPage2.Controls.Add(this.label14);
			this.tabPage2.Controls.Add(this.label13);
			this.tabPage2.Controls.Add(this.label12);
			this.tabPage2.Controls.Add(this.label11);
			this.tabPage2.Controls.Add(this.dgDiscrepancy);
			this.tabPage2.Controls.Add(this.dgNewCPDetails);
			this.tabPage2.Controls.Add(this.dgOldCPDetails);
			this.tabPage2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tabPage2.Location = new System.Drawing.Point(24, 4);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(780, 664);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "         Prefilled Data          ";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(208, 16);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(376, 32);
			this.label14.TabIndex = 16;
			this.label14.Text = "Prefilled Data";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(200, 416);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(384, 24);
			this.label13.TabIndex = 15;
			this.label13.Text = "Changes in Default Data";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label12
			// 
			this.label12.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label12.Location = new System.Drawing.Point(448, 56);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(312, 24);
			this.label12.TabIndex = 14;
			this.label12.Text = "New CP: 1234567890";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label11
			// 
			this.label11.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label11.Location = new System.Drawing.Point(32, 56);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(320, 24);
			this.label11.TabIndex = 13;
			this.label11.Text = "Old CP: 1234567890";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// dgDiscrepancy
			// 
			this.dgDiscrepancy.AllowNavigation = false;
			this.dgDiscrepancy.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dgDiscrepancy.CaptionFont = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dgDiscrepancy.CaptionVisible = false;
			this.dgDiscrepancy.CausesValidation = false;
			this.dgDiscrepancy.DataMember = "";
			this.dgDiscrepancy.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dgDiscrepancy.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgDiscrepancy.Location = new System.Drawing.Point(48, 448);
			this.dgDiscrepancy.Name = "dgDiscrepancy";
			this.dgDiscrepancy.ParentRowsVisible = false;
			this.dgDiscrepancy.Size = new System.Drawing.Size(696, 208);
			this.dgDiscrepancy.TabIndex = 12;
			// 
			// dgNewCPDetails
			// 
			this.dgNewCPDetails.AllowNavigation = false;
			this.dgNewCPDetails.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dgNewCPDetails.CaptionFont = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dgNewCPDetails.CaptionVisible = false;
			this.dgNewCPDetails.CausesValidation = false;
			this.dgNewCPDetails.DataMember = "";
			this.dgNewCPDetails.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dgNewCPDetails.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgNewCPDetails.Location = new System.Drawing.Point(400, 96);
			this.dgNewCPDetails.Name = "dgNewCPDetails";
			this.dgNewCPDetails.ParentRowsVisible = false;
			this.dgNewCPDetails.ReadOnly = true;
			this.dgNewCPDetails.RowHeadersVisible = false;
			this.dgNewCPDetails.Size = new System.Drawing.Size(376, 304);
			this.dgNewCPDetails.TabIndex = 11;
			// 
			// tbCustomerProgram
			// 
			this.tbCustomerProgram.Location = new System.Drawing.Point(72, 24);
			this.tbCustomerProgram.Name = "tbCustomerProgram";
			this.tbCustomerProgram.Size = new System.Drawing.Size(208, 20);
			this.tbCustomerProgram.TabIndex = 12;
			this.tbCustomerProgram.Text = "";
			this.tbCustomerProgram.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCustomerProgram_KeyDown);
			this.tbCustomerProgram.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCustomerProgram_KeyPress);
			this.tbCustomerProgram.TextChanged += new System.EventHandler(this.tbCustomerProgram_TextChanged);
			// 
			// FormSelectCustomerProgram
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
			this.ClientSize = new System.Drawing.Size(826, 736);
			this.Controls.Add(this.tbCustomerProgram);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.cbCustomerPrograms);
			this.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "FormSelectCustomerProgram";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Select/Change Customer Program";
			((System.ComponentModel.ISupportInitialize)(this.dgOldCPDetails)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgDiscrepancy)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgNewCPDetails)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOk_Click(object sender, System.EventArgs e)
		{
			string filter;
			DataTable dt;
			DataView dv;
			if(cbCustomerPrograms.SelectedIndex != -1)
			{
				filter = "CustomerProgramName = '" + cbCustomerPrograms.Text + "'"; //.SelectedItem..ToString() + "'";
				if(dsCustPrograms.Tables.Count > 0)
				{
					DataRow[] dr = dsCustPrograms.Tables[0].Select(filter);
					if(dr.Length>0)
					{
						((OldNumbersForm)Owner).CPID = dr[0]["CPID"].ToString();
						((OldNumbersForm)Owner).CPName = dr[0]["CustomerProgramName"].ToString();
						((OldNumbersForm)Owner).Path2Picture = dr[0]["Path2Picture"].ToString();
					}
				}
				return;
				//--- to fix
				if(dsCompareCP.Tables.Count == 2 && dsCompareCP.Tables[1].Rows.Count > 0)
				{
					filter =  "Update = true";
					dv = new DataView(dsCompareCP.Tables[1]);
					dv.RowFilter = filter;
					
					if(dv.Count > 0)
					{
						dt = dsCompareCP.Tables[1].Clone();
						foreach(DataRowView drv in dv)
						{
							dt.LoadDataRow(drv.Row.ItemArray, true);
						}
						dt.TableName = dt.Rows[0]["CPID"].ToString();
						((OldNumbersForm)Owner).dsCPChanges = new DataSet();
						((OldNumbersForm)Owner).dsCPChanges.Tables.Add(dt);
						
					}
		
				}
			}
			//			string sCPID = cbCustomerPrograms.SelectedValue.ToString();
			//((OldNumbersForm)Owner).CPID = cbCustomerPrograms.SelectedItem.ToString();
			//this.Close();
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
		
		}
		private void LoadPicture(ref PictureBox pbItemPicture, string Path2Picture)
		{
			pbItemPicture.Image = null;

			string pathToPicture = Client.GetOfficeDirPath("iconDir") + Path2Picture; //dr[0]["Path2Picture"].ToString();
			if (System.IO.File.Exists(pathToPicture))
			{
				Image im =  System.Drawing.Image.FromFile(pathToPicture);
				if(im != null)
				{
					pbItemPicture.Image = im;
					Service.DrawAdjustShapeImage(pbItemPicture, im);
				}
			}
		}

		private void LoadComDescr()
		{
			DataTable dt = ((DataView)cbCustomerPrograms.DataSource).Table.Copy();
			string sID = cbCustomerPrograms.SelectedValue.ToString();
			string sFilter = "CPID = '" + sID + "'";
			DataRow[] dr = dt.Select(sFilter);
			if(dr.Length >0)
			{
				tbCustomerIDNew.Text = dr[0]["CustomerID"].ToString();
				tbCustomerStyleNew.Text = dr[0]["CustomerStyle"].ToString();
				tbSRPNew.Text = dr[0]["SRP"].ToString();
				tbDescriptionNew.Text = dr[0]["Comment"].ToString();
				tbCommentsNew.Text = dr[0]["Description"].ToString();
			}
		}
		private void cbCustomerPrograms_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(bFormLoaded & cbCustomerPrograms.SelectedIndex != 0)
			{
				string sID = cbCustomerPrograms.SelectedValue.ToString();
//				if (sID.Trim() == sOldCPID)
//				{
//					MessageBox.Show("You selected existing CP. Please, select another CP.");
//				}
//				else
//				{
				string sFilter = "CPID = '" + sID + "'";
				string sPathToPicture = "";
				DataRow [] dr = dsCustPrograms.Tables[0].Select(sFilter);
				
				if(dr.Length > 0) 
				{
					sPathToPicture = dr[0]["Path2Picture"].ToString().Trim();
					if(sPathToPicture != "" && sPathToPicture.ToUpper().IndexOf("DEFAULT") < 0)	
						LoadPicture(ref pictureBoxNew,sPathToPicture);
					LoadComDescr();
					groupBox2.Text = "New CP: " + dr[0]["CustomerProgramName"].ToString();
					//this.ptPartTree.Initialize(dsParts.Tables["Parts"]);
					//ptPartTree.tvPartTree.Select();
					CompareOldNewCP(sOldCPID, sID);
					tbCustomerProgram.Text = cbCustomerPrograms.Text;
				}
//				}
			}
		}

		private void CompareOldNewCP(string OldCPID, string NewCPID)
		{
			return;
			try
			{
				dsCompareCP = new DataSet();
				DataSet dsTemp = new DataSet();
				DataTable dtTemp;
				dtTemp = dsTemp.Tables.Add("OldNewCPData");
				dtTemp.Columns.Add("OldCPID");
				dtTemp.Columns.Add("NewCPID");
				object oOldCPID = OldCPID;
				object oMewCPID = NewCPID;
				dtTemp.Rows.Add(new object[] {oOldCPID, oMewCPID});
				dsCompareCP = Service.ProxyGenericGet(dsTemp);
				dsCompareCP.Tables[0].TableName = "CPData";
				dsCompareCP.Tables[1].TableName = "CPDifference";

				DataView dvOldCP = new DataView(dsCompareCP.Tables[0]);
				DataView dvNewCP = new DataView(dsCompareCP.Tables[0].Copy());
				
				string sFilter = "CPID = '" + OldCPID + "'";
				dvOldCP.RowFilter = sFilter;
				dvOldCP.AllowDelete = false;
				dvOldCP.AllowNew = false;
				dvOldCP.AllowEdit = false;
				dgOldCPDetails.TableStyles.Clear();
				dgOldCPDetails.TableStyles.Add(DefaultDataGrid(dsCompareCP.Tables[0].TableName));
				dgOldCPDetails.DataSource = dvOldCP;
				dgOldCPDetails.Refresh();
				
				label11.Text = "Old CP: " + dvOldCP[0]["CPName"].ToString();
				label11.Refresh();
					
				sFilter = "CPID = '" + NewCPID + "'";
				dvNewCP.RowFilter = sFilter;
				dvNewCP.AllowDelete = false;
				dvNewCP.AllowNew = false;
				dvNewCP.AllowEdit = false;
				dgNewCPDetails.TableStyles.Clear();
				dgNewCPDetails.TableStyles.Add(DefaultDataGrid(dsCompareCP.Tables[0].TableName));
				dgNewCPDetails.DataSource = dvNewCP;
				dgNewCPDetails.Refresh();
				
				label12.Text = "New CP: " + dvNewCP[0]["CPName"].ToString();
				label12.Refresh();
					
				if(dsCompareCP.Tables[1].Rows.Count > 0)
				{

					dsCompareCP.Tables[1].Columns.Add(new DataColumn("Update", typeof(bool)));
					foreach(DataRow dr in dsCompareCP.Tables[1].Rows)
					{
						dr["Update"] = false;
					}
					DataView dvDiscrepancy = new DataView(dsCompareCP.Tables[1]);
					dvDiscrepancy.AllowDelete = false;
					dvDiscrepancy.AllowNew = false;
					dvDiscrepancy.AllowEdit = true;

					dgDiscrepancy.TableStyles.Clear();
					dgDiscrepancy.TableStyles.Add(DiscrepancyGrid(dvDiscrepancy.Table.TableName)); 
					dgDiscrepancy.DataSource = dvDiscrepancy;
					dgDiscrepancy.Refresh();
					DialogResult result = MessageBox.Show(this,"Selected CP has new prefilled data. Please, check it","New Prefilled Data",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
					if(result == DialogResult.Yes)
						tabControl1.SelectedTab = tabControl1.TabPages[1];
				}

			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
				throw new Exception("Can't load old/new customer program data");
			}
		}
		
		private void InitOldCPData(string sOldCPID)
		{
			try
			{
				DataSet dsTemp = new DataSet();
				DataTable dtTemp;
				dtTemp = dsTemp.Tables.Add("CustomerProgramInstanceByCPIDTypeEx");
				dsTemp = Service.ProxyGenericGet(dsTemp);
				dtTemp = dsTemp.Tables[0];
				dtTemp.TableName = "CustomerProgramInstanceByCPID";
				dsTemp.Tables[0].Rows.Add(dsTemp.Tables[0].NewRow());
				dtTemp.Rows[0]["CPID"] = sOldCPID;
				dsOldCustProgram = new DataSet();
				dsOldCustProgram = Service.ProxyGenericGet(dsTemp);
				tbCustomerID.Text = dsOldCustProgram.Tables[0].Rows[0]["CustomerID"].ToString();
				tbCustomerStyle.Text = dsOldCustProgram.Tables[0].Rows[0]["CustomerStyle"].ToString();
				tbSRP.Text = dsOldCustProgram.Tables[0].Rows[0]["SRP"].ToString();
				tbDescription.Text = dsOldCustProgram.Tables[0].Rows[0]["Comment"].ToString();
				tbComments.Text = dsOldCustProgram.Tables[0].Rows[0]["Description"].ToString();
				groupBox1.Text = "Old CP: " + dsOldCustProgram.Tables[0].Rows[0]["CustomerProgramName"].ToString();
				string pathToPicture = dsOldCustProgram.Tables[0].Rows[0]["Path2Picture"].ToString();
				if(pathToPicture.ToUpper().IndexOf("DEFAULT") < 0 && pathToPicture.Trim() != "")
				{
					LoadPicture(ref pictureBox1, pathToPicture);
				}
			}
			catch
			{
				throw new Exception("Can't load old customer program");
			}
		}

		private void ClearText(Control  ctrlContainer)
		{
			foreach(Control  ctrl in  ctrlContainer.Controls)
			{
				if (ctrl.GetType() == typeof(TextBox)) 
					 ctrl.Text = string.Empty;
				if(ctrl.HasChildren)
					ClearText(ctrl); // recursion required for panels/groups etc
			}
		}

		private DataGridTableStyle DefaultDataGrid(string mappingName)
		{
			string[] columnNames = new string[] {"PartName", "MeasureName", "Min_Value"};
			string[] headerText = new string[]{"Part", "Measurement", "Default Value"}; 
			int[] columnWidth = new int[]{170, 100, 90};
		
			DataGridTableStyle tableStyle = new DataGridTableStyle();
			tableStyle.MappingName = mappingName;
			tableStyle.RowHeadersVisible = false;

			for (int i = 0; i < columnNames.Length; i++)
			{
				DataGridColumnStyle tbColumn = new DataGridTextBoxColumn();

				tbColumn.MappingName = columnNames[i];
				tbColumn.HeaderText = headerText[i];
				tbColumn.Width = columnWidth[i];
				tbColumn.NullText = "";
                tableStyle.GridColumnStyles.Add(tbColumn);						
			}
			return tableStyle;

		}

		private void ptPartTree_Changed(object sender, System.EventArgs e)
		{
			//this.Cursor = Cursors.WaitCursor;
			string sPartID = ptPartTree.SelectedRow["ID"].ToString();


		}

		private DataGridTableStyle DiscrepancyGrid(string mappingName)
		{
			string[] columnNames = new string[] {"PartName", "MeasureName", "OldCPName", "OldValue", "NewCPName", "NewValue", "Update"};
			string[] headerText = new string[]{"Part", "Grade/Measurement", "Old CP", "Old Value","New CP", "New Value", "Update"}; 
			int[] columnWidth = new int[]{100, 100, 100, 100, 100, 100, 80};
		
			DataGridTableStyle tableStyle = new DataGridTableStyle();
			tableStyle.MappingName = mappingName;
			tableStyle.RowHeadersVisible = false;
			tableStyle.ReadOnly = false;
			
			for (int i = 0; i < columnNames.Length; i++)
			{
				if(columnNames[i] != "Update")
				{
					DataGridTextBoxColumn tbColumn = new DataGridTextBoxColumn();

					tbColumn.MappingName = columnNames[i];
					tbColumn.HeaderText = headerText[i];
					tbColumn.Width = columnWidth[i];
					tbColumn.NullText = "";
					tableStyle.GridColumnStyles.Add(tbColumn);	
				}
				else
				{
					DataGridBoolColumn boolCol = new DataGridBoolColumn();
					boolCol.MappingName = columnNames[i];
					boolCol.HeaderText = headerText[i];
					boolCol.Width = columnWidth[i];
					boolCol.AllowNull = false;
					boolCol.ReadOnly = false;
					tableStyle.GridColumnStyles.Add(boolCol);
				}	
			}
			return tableStyle;
		}

		private void tbCustomerProgram_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Return)
			{
				DataTable dt = ((DataView)cbCustomerPrograms.DataSource).Table.Copy();
				string sFilter = "CustomerProgramName = '" + tbCustomerProgram.Text.Trim() + "'";
				DataRow[] dr = dt.Select(sFilter);
				if(dr.Length != 1)
				{
					MessageBox.Show("Can't find Customer Program: " + (char)34 + tbCustomerProgram.Text + (char)34);				
				}
				else
				{
					cbCustomerPrograms.SelectedValue = dr[0]["CPID"];
				}
			}
		}

		private void tbCustomerProgram_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
		
		}

		private void tbCustomerProgram_TextChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
