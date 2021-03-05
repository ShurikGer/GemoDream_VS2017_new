using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using gemoDream;

namespace Cntrls
{
	/// <summary>
	/// Summary description for ShippingManifest.
	/// </summary>
	public class ShippingManifest : System.Windows.Forms.UserControl
	{
		public System.Windows.Forms.DataGrid dgOrdersToDelivery;
		public System.Windows.Forms.Button bAddToManifest;
		private System.Windows.Forms.GroupBox grBox1;
		public System.Windows.Forms.Button bClearData;
		public DataSet dsShipManifest;
		public DataSet dsOrdersToDelivery;
		public System.Windows.Forms.Button bCreateManifest;
		public System.Windows.Forms.TextBox tbOrderMemo;
		public System.Windows.Forms.TextBox tbQuantity;
		public System.Windows.Forms.TextBox tbOrder;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button bAddToOrderMemoTree;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ShippingManifest()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			Initialize();

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
			this.bAddToManifest = new System.Windows.Forms.Button();
			this.bCreateManifest = new System.Windows.Forms.Button();
			this.dgOrdersToDelivery = new System.Windows.Forms.DataGrid();
			this.grBox1 = new System.Windows.Forms.GroupBox();
			this.bAddToOrderMemoTree = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tbOrder = new System.Windows.Forms.TextBox();
			this.tbQuantity = new System.Windows.Forms.TextBox();
			this.tbOrderMemo = new System.Windows.Forms.TextBox();
			this.bClearData = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgOrdersToDelivery)).BeginInit();
			this.grBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// bAddToManifest
			// 
			this.bAddToManifest.BackColor = System.Drawing.Color.LemonChiffon;
			this.bAddToManifest.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.bAddToManifest.Location = new System.Drawing.Point(16, 312);
			this.bAddToManifest.Name = "bAddToManifest";
			this.bAddToManifest.Size = new System.Drawing.Size(112, 24);
			this.bAddToManifest.TabIndex = 1;
			this.bAddToManifest.Text = "Add Selected ##";
			this.bAddToManifest.Click += new System.EventHandler(this.bAddToManifest_Click);
			// 
			// bCreateManifest
			// 
			this.bCreateManifest.BackColor = System.Drawing.Color.LemonChiffon;
			this.bCreateManifest.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.bCreateManifest.Location = new System.Drawing.Point(256, 312);
			this.bCreateManifest.Name = "bCreateManifest";
			this.bCreateManifest.Size = new System.Drawing.Size(96, 24);
			this.bCreateManifest.TabIndex = 2;
			this.bCreateManifest.Text = "Create Manifest";
			this.bCreateManifest.Click += new System.EventHandler(this.dCreateManifest_Click);
			// 
			// dgOrdersToDelivery
			// 
			this.dgOrdersToDelivery.AllowNavigation = false;
			this.dgOrdersToDelivery.AllowSorting = false;
			this.dgOrdersToDelivery.CaptionFont = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dgOrdersToDelivery.CaptionVisible = false;
			this.dgOrdersToDelivery.DataMember = "";
			this.dgOrdersToDelivery.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dgOrdersToDelivery.HeaderFont = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dgOrdersToDelivery.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgOrdersToDelivery.Location = new System.Drawing.Point(8, 80);
			this.dgOrdersToDelivery.Name = "dgOrdersToDelivery";
			this.dgOrdersToDelivery.ParentRowsVisible = false;
			this.dgOrdersToDelivery.Size = new System.Drawing.Size(419, 224);
			this.dgOrdersToDelivery.TabIndex = 3;
			// 
			// grBox1
			// 
			this.grBox1.Controls.Add(this.bAddToOrderMemoTree);
			this.grBox1.Controls.Add(this.label3);
			this.grBox1.Controls.Add(this.label2);
			this.grBox1.Controls.Add(this.label1);
			this.grBox1.Controls.Add(this.tbOrder);
			this.grBox1.Controls.Add(this.tbQuantity);
			this.grBox1.Controls.Add(this.tbOrderMemo);
			this.grBox1.Controls.Add(this.bClearData);
			this.grBox1.Controls.Add(this.bCreateManifest);
			this.grBox1.Controls.Add(this.bAddToManifest);
			this.grBox1.Controls.Add(this.dgOrdersToDelivery);
			this.grBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.grBox1.Location = new System.Drawing.Point(0, 2);
			this.grBox1.Name = "grBox1";
			this.grBox1.Size = new System.Drawing.Size(432, 342);
			this.grBox1.TabIndex = 9;
			this.grBox1.TabStop = false;
			this.grBox1.Text = "Shipping/Delivery Manifest";
			// 
			// bAddToOrderMemoTree
			// 
			this.bAddToOrderMemoTree.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.bAddToOrderMemoTree.Location = new System.Drawing.Point(136, 312);
			this.bAddToOrderMemoTree.Name = "bAddToOrderMemoTree";
			this.bAddToOrderMemoTree.Size = new System.Drawing.Size(104, 24);
			this.bAddToOrderMemoTree.TabIndex = 16;
			this.bAddToOrderMemoTree.Text = "Add To List";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.label3.Location = new System.Drawing.Point(328, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 15);
			this.label3.TabIndex = 15;
			this.label3.Text = "Quantity";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.label2.Location = new System.Drawing.Point(136, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(160, 15);
			this.label2.TabIndex = 14;
			this.label2.Text = "Main Memo";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 15);
			this.label1.TabIndex = 13;
			this.label1.Text = "Order #";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbOrder
			// 
			this.tbOrder.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tbOrder.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.tbOrder.Location = new System.Drawing.Point(16, 48);
			this.tbOrder.Name = "tbOrder";
			this.tbOrder.ReadOnly = true;
			this.tbOrder.Size = new System.Drawing.Size(88, 21);
			this.tbOrder.TabIndex = 12;
			this.tbOrder.Text = "";
			// 
			// tbQuantity
			// 
			this.tbQuantity.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tbQuantity.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.tbQuantity.Location = new System.Drawing.Point(328, 48);
			this.tbQuantity.Name = "tbQuantity";
			this.tbQuantity.ReadOnly = true;
			this.tbQuantity.Size = new System.Drawing.Size(80, 21);
			this.tbQuantity.TabIndex = 11;
			this.tbQuantity.Text = "";
			// 
			// tbOrderMemo
			// 
			this.tbOrderMemo.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tbOrderMemo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbOrderMemo.Location = new System.Drawing.Point(136, 48);
			this.tbOrderMemo.Name = "tbOrderMemo";
			this.tbOrderMemo.ReadOnly = true;
			this.tbOrderMemo.Size = new System.Drawing.Size(160, 21);
			this.tbOrderMemo.TabIndex = 10;
			this.tbOrderMemo.Text = "";
			// 
			// bClearData
			// 
			this.bClearData.BackColor = System.Drawing.Color.LemonChiffon;
			this.bClearData.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.bClearData.Location = new System.Drawing.Point(360, 312);
			this.bClearData.Name = "bClearData";
			this.bClearData.Size = new System.Drawing.Size(48, 24);
			this.bClearData.TabIndex = 9;
			this.bClearData.Text = "Clear";
			this.bClearData.Click += new System.EventHandler(this.bClearData_Click);
			// 
			// ShippingManifest
			// 
			this.Controls.Add(this.grBox1);
			this.Name = "ShippingManifest";
			this.Size = new System.Drawing.Size(440, 352);
			((System.ComponentModel.ISupportInitialize)(this.dgOrdersToDelivery)).EndInit();
			this.grBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public void Initialize()
		{
			dsOrdersToDelivery = new DataSet();
			DataTable dtOrders = new DataTable();
			dtOrders.TableName = "ToShip"; 

			dtOrders.Columns.Add(new DataColumn ("Quantity", typeof(string)));
			dtOrders.Columns.Add(new DataColumn ("OrderCode", typeof(string)));
			dtOrders.Columns.Add(new DataColumn ("MemoNumber", typeof(string)));
			dtOrders.Columns.Add(new DataColumn ("MemoNumberID", typeof(string)));
			dtOrders.Columns.Add(new DataColumn ("Parcel", typeof(string)));
			dtOrders.Columns.Add(new DataColumn ("Envelope", typeof(string)));
			dtOrders.Columns.Add(new DataColumn ("CustomerCode", typeof(string)));
			dtOrders.Columns.Add(new DataColumn ("GroupID", typeof(string)));
			//dtOrders.Columns.Add(new DataColumn ("Select", typeof(bool)));
		
			dsOrdersToDelivery.Tables.Add(dtOrders);
			//dsOrdersToDelivery.Tables[0].RowDeleted += new System.Data.DataRowChangeEventHandler(OrderTable_Deleted);
			DataView myView = new DataView(dsOrdersToDelivery.Tables[0]);
			myView.AllowNew = true;
			myView.AllowEdit = true;
			myView.AllowDelete = true;
			//myView.Sort = "OrderCode";
			InitOrderDataGrid(dsOrdersToDelivery.Tables[0].TableName);
			dgOrdersToDelivery.SetDataBinding(myView, "");
	
		}
		public DataSet AddToManifest(DataSet dsAddToManifest)
		{
			DataSet dsBatches = new DataSet();
			dsBatches.DataSetName = "BatchSet";
			DataTable dtBatches = new DataTable("Batches");
			dtBatches.Columns.Add(new DataColumn ("OrderCode", typeof(string)));
			dtBatches.Columns.Add(new DataColumn ("BatchCode", typeof(string)));			
			object	oOrderCode	=	null;
			object	oBatchCode	=	null;
			object	oAllList = null;
			try
			{
				foreach(DataRow dr in dsAddToManifest.Tables["tblBatch"].Rows)
				{
					oOrderCode = dr["OrderCode"].ToString();
					oBatchCode = dr["Code"].ToString();
					dtBatches.Rows.Add(new object[] {oOrderCode, oBatchCode});
				}
				dsBatches.Tables.Add(dtBatches);
				oAllList = dsBatches.GetXml();
				
				DataSet dsIn = new DataSet();
				dsIn.Tables.Add("MemoItemsQtyFromListTypeEx");
				dsIn = Service.ProxyGenericGet(dsIn);

				DataTable table = dsIn.Tables[0];
				table.TableName = "MemoItemsQtyFromList";
				table.Columns.Add("BatchCodeList", typeof(string));
				DataRow row = table.NewRow();
				row["BatchCodeList"] = oAllList;
				table.Rows.Add(row);
				dsIn = Service.ProxyGenericGet(dsIn);
				return FillManifestTable(dsIn);
			}
			catch
			{
				return null;
			}
		}

		private DataSet FillManifestTable(DataSet dsManifestInfo)
		{
			try
			{
				if(dsManifestInfo.Tables[0].Rows.Count > 0)
				{
					foreach(DataRow dr in dsManifestInfo.Tables[0].Rows)
					{
						object oQuantity = dr["Quantity"].ToString();
						object oOrderCode = dr["OrderCode"].ToString();
						object oMemoNumber = dr["MemoNumber"].ToString();
						object oMemoNumberID = dr["MemoNumberID"].ToString();
						object oParcel = null;
						object oEnvelope = null;
						object oCustomerCode = dr["CustomerCode"].ToString();
						object oGroupID = dr["GroupID"].ToString();
						//object oSelect = true;
						dsOrdersToDelivery.Tables[0].Rows.Add(new object[] {
																			   oQuantity,
																			   oOrderCode,
																			   oMemoNumber,
																			   oMemoNumberID,
																			   oParcel,
																			   oEnvelope,
																			   oCustomerCode,
																			   oGroupID//,
																			   //oSelect
																		   });											
					}

				return dsManifestInfo;	
				}
				else

				return null;
			}
			catch
			{
				return null;
			}
			
		}

		private void InitOrderDataGrid(string mappingName)
		{
			dgOrdersToDelivery.SetDataBinding(null, ""); 
			string[] columnNames = new string[] 
					{
						"OrderCode", "MemoNumber", "Parcel", "Envelope", "Quantity"//, "CustomerCode"};
						//, "Select"
					};
		
			string[] headerText = new string[] 
					{
						"Order", "Memo", "Parcel", "Envelope", "Qty"//, "Cust#"};//, "Add"
					};
			
			int[] columnWidth = new int[]
					{
						60, 90, 85, 85, 45//, 45//, 35
					};

			DataGridTableStyle tableStyle = new DataGridTableStyle();
			tableStyle.MappingName = mappingName;

			for (int i = 0; i < columnNames.Length; i++)
			{
				//if(columnNames[i] != "Select")
				{
					DataGridTextBoxColumn tbColumn = new DataGridTextBoxColumn();

					tbColumn.MappingName = columnNames[i];
					tbColumn.HeaderText = headerText[i];
					tbColumn.Width = columnWidth[i];
					tbColumn.NullText = "";
					tableStyle.GridColumnStyles.Add(tbColumn);	
				}
				//else
				{
//					DataGridBoolColumn boolCol = new DataGridBoolColumn();
//					boolCol.MappingName = columnNames[i];
//					boolCol.HeaderText = headerText[i];
//					boolCol.Width = columnWidth[i];
//					boolCol.AllowNull = false;
//					boolCol.ReadOnly = false;
//					boolCol.TrueValue = true;
//					boolCol.FalseValue = false;
//					//boolCol.NullValue = Convert.DBNull;
//					boolCol.NullText = "";
//					tableStyle.GridColumnStyles.Add(boolCol);
				}	
		}
			dgOrdersToDelivery.TableStyles.Clear();
			dgOrdersToDelivery.TableStyles.Add(tableStyle);
		}
		
		private void bAddToManifest_Click(object sender, System.EventArgs e)
		{
		
		}

		private void dCreateManifest_Click(object sender, System.EventArgs e)
		{
			CallShipManifestConstructor(dsOrdersToDelivery);
		}

		private void bClearData_Click(object sender, System.EventArgs e)
		{
		
		}

		public void CallShipManifestConstructor(DataSet dsToShip)
		{
			Form frmNew = new Form();
			frmNew = new ShipManifestConstructor(dsToShip);
			frmNew.ShowDialog(this);
		}
		
	}
}
