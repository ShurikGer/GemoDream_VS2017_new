using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace gemoDream
{
	/// <summary>
	/// Summary description for CommonDetails.
	/// </summary>
	public class CommonDetails : System.Windows.Forms.Form
	{
		private int iAccessLevel;
		private string sCPName;
		private bool IsUpdate = false;
		private bool bAddNewOperation = false;
		private string sCPOfficeID;
		private string sCPID;
		private int iDocumentsCount;
		private String sItemTypeID;
		public System.Windows.Forms.ComboBox cbService;
		public System.Windows.Forms.TextBox tbLabel;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button bAdd;
		private System.Windows.Forms.Button bCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CommonDetails()
		{			
			InitializeComponent();
		}

		/*
		private int GetDocumentsCount(string sCPOfficeID, string sCPID)
		{
			try
			{
				DataSet dsIn = new DataSet();
				DataTable dtIn = dsIn.Tables.Add("CustomerProgramDocumentsCount");

				dtIn.Columns.Add("CPOfficeID", System.Type.GetType("System.String"));
				dtIn.Columns.Add("CPID", System.Type.GetType("System.String"));

				DataRow row = dtIn.NewRow();

				row["CPOfficeID"] = sCPOfficeID;
				row["CPID"] = sCPID;
								
				dtIn.Rows.Add(row);
				gemoDream.Service.ProxyGenericGet(dsIn);
				string sDocumentsCount = dsIn.Tables[0].Rows[0][0].ToString();

				int iDocumentsCount = System.Convert.ToInt32(sDocumentsCount, 10);
				return iDocumentsCount;
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Can't get documents count. Reason: " + ex.ToString(),
					"Internal error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			return -1;
		}
		*/

		public CommonDetails(int iAccessLevel, DataSet dsData, bool IsDefDocFormNeeded, string sItemTypeID, string sCPOfficeID,
			string sCPID, string sCPName)
		{			
			InitializeComponent();

			this.iAccessLevel = iAccessLevel;
			this.sCPName = sCPName;
			this.sItemTypeID = sItemTypeID;
			this.sCPOfficeID = sCPOfficeID;
			this.sCPID = sCPID;
			DataSet ds = dsData.Copy();

			//ds.Clear();

			//gemoDream.Service.debug_DiaspalyDataSet(ds);

			//DataSet ds = new DataSet();

//			if (IsDefDocFormNeeded)
//			{
//				AddMagicOperations(ds);
//			}

			//gemoDream.Service.debug_DiaspalyDataSet(ds);
			this.iDocumentsCount = Service.GetDocumentsCount(sCPOfficeID, sCPID);//Procedure dbo.spGetCustomerProgramDocumentsCount
			//this.iDocumentsCount++;
			DataView dvData = new DataView(ds.Tables[0]);
			//dvData.Sort = "nOrder";
			cbService.DataSource = dvData;//dsData.Tables["Docs"];
			//cbService.DataSource = ds.Tables[0];
			//cbService.DisplayMember = "OperationTypeName";
			cbService.DisplayMember = "OperationTypeName";
			cbService.ValueMember = "OperationTypeOfficeID_OperationTypeID";
			cbService.SelectedIndex = -1;
			tbLabel.Enabled = false;
			tbLabel.Text = sCPName;
		}

		/*
		private string GetCPByBatch()
		{

		}
		*/

		private void InitDocumentsCount(string sBatchID)
		{
			/*
			char separator = '_';
			string[] sCPOfficeID_CPID = CPOfficeID_CPID.Split(separator);
			string sCPOfficeID = sCPOfficeID_CPID[0];
			string sCPID = sCPOfficeID_CPID[1];

			this.iDocumentsCount = this.GetDocumentsCount(sCPOfficeID, sCPID);
			*/
		}

		private void AddMagicOperations(DataSet dsData)
		{
			/*
			DataRow row = dsData.Tables[0].NewRow();
			row["OperationTypeOfficeID_OperationTypeID"] = "-3_3";
			//row["OperationTypeName"] = "MDX Document";
			row["OperationTypeName"] = "MDX Document";
			row["nOrder"] = -3;
			dsData.Tables[0].Rows.Add(row);
			
			row = dsData.Tables[0].NewRow();
			row["OperationTypeOfficeID_OperationTypeID"] = "-2_2";
			//row["OperationTypeName"] = "FDX Document";
			row["OperationTypeName"] = "FDX Document";
			row["nOrder"] = -2;
			dsData.Tables[0].Rows.Add(row);

			row = dsData.Tables[0].NewRow();
			row["OperationTypeOfficeID_OperationTypeID"] = "-1_1";
			//row["OperationTypeName"] = "IDX Document";
			row["OperationTypeName"] = "IDX Document";
			row["nOrder"] = -1;
			dsData.Tables[0].Rows.Add(row);
			*/
			/*
			DataSet ds = gemoDream.Service.GetDocumentTypes();
			
			foreach (DataRow rowFrom in ds.Tables[0].Rows)
			{
				DataRow row = dsData.Tables[0].NewRow();
				row["OperationTypeOfficeID_OperationTypeID"] = rowFrom["DocumentTypeCode"].ToString();
				row["OperationTypeName"] = rowFrom["DocumentTypeName"].ToString();
				row["nOrder"] = -1;
				dsData.Tables[0].Rows.Add(row);
			}
			*/
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
			this.cbService = new System.Windows.Forms.ComboBox();
			this.tbLabel = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.bAdd = new System.Windows.Forms.Button();
			this.bCancel = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// cbService
			// 
			this.cbService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbService.Items.AddRange(new object[] {
														   "1",
														   "2",
														   "3"});
			this.cbService.Location = new System.Drawing.Point(8, 16);
			this.cbService.Name = "cbService";
			this.cbService.Size = new System.Drawing.Size(248, 21);
			this.cbService.TabIndex = 0;
			this.cbService.SelectedIndexChanged += new System.EventHandler(this.cbService_SelectedIndexChanged);
			// 
			// tbLabel
			// 
			this.tbLabel.Location = new System.Drawing.Point(256, 16);
			this.tbLabel.Name = "tbLabel";
			this.tbLabel.ReadOnly = true;
			this.tbLabel.Size = new System.Drawing.Size(216, 20);
			this.tbLabel.TabIndex = 1;
			this.tbLabel.Text = "";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cbService);
			this.groupBox1.Controls.Add(this.tbLabel);
			this.groupBox1.Location = new System.Drawing.Point(0, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(480, 48);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Select Report Type From List                                       CP Name";
			// 
			// bAdd
			// 
			this.bAdd.BackColor = System.Drawing.Color.LightSteelBlue;
			this.bAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.bAdd.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.bAdd.Location = new System.Drawing.Point(208, 72);
			this.bAdd.Name = "bAdd";
			this.bAdd.Size = new System.Drawing.Size(100, 23);
			this.bAdd.TabIndex = 4;
			this.bAdd.Text = "Add";
			this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
			// 
			// bCancel
			// 
			this.bCancel.BackColor = System.Drawing.Color.LightPink;
			this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.bCancel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.bCancel.Location = new System.Drawing.Point(312, 72);
			this.bCancel.Name = "bCancel";
			this.bCancel.Size = new System.Drawing.Size(100, 23);
			this.bCancel.TabIndex = 5;
			this.bCancel.Text = "Cancel";
			// 
			// CommonDetails
			// 
			this.AcceptButton = this.bAdd;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.bCancel;
			this.ClientSize = new System.Drawing.Size(490, 101);
			this.Controls.Add(this.bCancel);
			this.Controls.Add(this.bAdd);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CommonDetails";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "CommonDetails";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

	
		private string AddOperation(int iAccessLevel, string sItemTypeID, string sPath2Picture, string sOperationTypeName, string sCPOfficeID, string sCPID, 
			string sDocTypeCode,
			string sCPName)
		{
            DefineDocumentForm defDocForm = new DefineDocumentForm(iAccessLevel, null, sItemTypeID, 
				sPath2Picture, sOperationTypeName, sCPOfficeID, sCPID, 
				new ArrayList(), sDocTypeCode, null, sCPName);
//				sCPOfficeID, sCPID);
			defDocForm.ShowDialog(this);
			string sDocumentID = defDocForm.GetDocumentID();
			string sDocumentName = defDocForm.GetDocumentName();
			string sOTOID_OTID = defDocForm.GetOperationTypeOfficeID_OperationTypeID();
			if (sDocumentID == null)
				return null;
			this.iDocumentsCount++;
			//this.cbService.SelectedValue = sDocumentID;
			
			DataView dv = (DataView)this.cbService.DataSource;
			DataRow newRow = dv.Table.NewRow();
			newRow["OperationTypeOfficeID_OperationTypeID"] = sOTOID_OTID;
			//newRow["OperationTypeName"] = sDocumentName;
			newRow["OperationTypeName"] = sDocumentName;
				//sOperationTypeName;
			//newRow["nOrder"] = ;
			this.bAddNewOperation = true;
			dv.Table.Rows.Add(newRow);
			this.bAddNewOperation = false;
		
			//return sDocumentID;
			return sOTOID_OTID;
		}

		private void cbService_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (!this.IsUpdate)
			{

				try
				{
					string sID = cbService.SelectedValue.ToString();
			
//					if (sID.Equals("-3_3") || //MDX Document
//						sID.Equals("-2_2") || //FDX Document
//						sID.Equals("-1_1"))   //IDX Document
					if (Service.IsMagicOperation(sID) && !sID.Equals("System.Data.DataRowView"))
					{
						if (!bAddNewOperation)
						{
							//DefineDocumentForm.DocTypeCode docTypeCode = DefineDocumentForm.GetDocTypeCodeEnumByID(sID);
                            string sDocTypeCode = sID;

							string sCPName = this.sCPName;
							string sPath2Picture = Service.GetPath2Picture(sItemTypeID);
							string sName = this.cbService.Text.ToString();
							//string sOperationTypeName = String.Format("{0} {1}", sName, this.iDocumentsCount+1);
							string sOperationTypeName = this.cbService.Text;
							tbLabel.Text = sCPName;
							string sOTOID_OTID = AddOperation(this.iAccessLevel,
								this.sItemTypeID, sPath2Picture, sOperationTypeName, 
								this.sCPOfficeID, this.sCPID, sDocTypeCode, sCPName);
							if (sOTOID_OTID != null && sOTOID_OTID.Length != 0)
								this.cbService.SelectedValue = sOTOID_OTID;
							else
							{
								this.IsUpdate = true;
								this.cbService.SelectedIndex = 0;
								this.IsUpdate = false;
							}
						}


						/*
						this.cbService.DataSource = Get
						string sFilter = "OperationTypeOfficeID_OperationTypeID='" + cbService.SelectedValue.ToString() + "'"
						DataRow[] drRows = ((DataTable)(cbService.DataSource)).Select(sFilter);
						if(drRows[0]["OperationTypeClass"].ToString() != "2")
						{
							tbLabel.Enabled = false;
							tbLabel.Text = "";
						}
						else
						{
							tbLabel.Enabled = true;
							tbLabel.Text = "";
						}
						*/
					}
					else
					{
						DataRow[] drRows = ((DataTable)(cbService.DataSource)).Select("OperationTypeOfficeID_OperationTypeID='" + cbService.SelectedValue.ToString() + "'");
						if(drRows[0]["OperationTypeClass"].ToString() != "2")
						{
							tbLabel.Enabled = false;
							tbLabel.Text = "";
						}
						else
						{
							tbLabel.Enabled = true;
							tbLabel.Text = "";
						}
					}
				}
				catch(Exception exc)
				{
					Console.WriteLine(exc.Message);
				}
			}
		}

		private void bAdd_Click(object sender, System.EventArgs e)
		{
			string s = this.cbService.SelectedValue.ToString();
			if (s.Equals("-3_3") || s.Equals("-2_2") || s.Equals("-1_1"))
			{
				MessageBox.Show(this, "You can add only a valid document. Document will not be added.",
					"Invalid document", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				this.DialogResult = DialogResult.Cancel;
				return ;
			}
			this.DialogResult = DialogResult.OK;
		}
	}
}
