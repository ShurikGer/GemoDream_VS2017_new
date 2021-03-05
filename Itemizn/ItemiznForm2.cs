using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace gemoDream
{
	/// <summary>
	/// Summary description for Itemizn2Form.
	/// </summary>
	public class Itemizn2Form : System.Windows.Forms.Form
	{
		private bool canClose = false;
		private int accessLevel;
		private int itemsInGroup = 0;
		private int iSetID = 0;
		
		public int ISetID
		{
			get
			{
				return iSetID;
			}
			set
			{
				iSetID = value;
			}
		}

		public int ItemsInGroup
		{
			get
			{
				return itemsInGroup;
			}
			set
			{
				itemsInGroup = value;
			}
		}
		private string itemsTypeId;
		public string ItemsTypeId
		{
			get
			{
				return itemsTypeId;
			}
			set
			{
				itemsTypeId = value;
			}
		}
		private string customerProgram;
		public string CustomerProgram
		{
			get
			{
				return customerProgram;
			}
			set
			{
				customerProgram = value;
			}
		}
		private string customerProgramId;
		public string CustomerProgramId
		{
			get
			{
				return customerProgramId;
			}
			set
			{
				customerProgramId = value;
			}
		}
		private int addedItemsQuantity = 0;
		private DataSet dsData = new DataSet();
		#region Generated
		private System.Windows.Forms.StatusBar statusBar1;
		internal System.Windows.Forms.GroupBox GroupBox6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		public System.Windows.Forms.Label lbCustomerName;
		public System.Windows.Forms.Label lbCustomerProgram;
		public System.Windows.Forms.Label lbFullItemName;
		public System.Windows.Forms.PictureBox pbItemPicture;
		private System.Windows.Forms.Label lbRunningItemN;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnDoneBatch;
		private System.Windows.Forms.ColumnHeader itemN;
		private System.Windows.Forms.ColumnHeader lotN;
		private System.Windows.Forms.ColumnHeader itemWeight;
		private System.Windows.Forms.Button btnDoneGroup;
		private System.Windows.Forms.ListView listItems;
		private System.Windows.Forms.Button btnWrong;
		private System.Windows.Forms.TextBox tbLotNumber;
		
		private System.Windows.Forms.Label lb;
		private System.Windows.Forms.Label label1;
	
		private System.Windows.Forms.ColumnHeader itemCusomerWeight;
		private System.Windows.Forms.ColumnHeader itemPrevItemN;
		private Cntrls.WeightControl wcCustomerWeight;
		private Cntrls.WeightControl wcWeight;
		private System.Windows.Forms.DataGridTableStyle tsItem;
		private System.Windows.Forms.DataGridTextBoxColumn number;
		private System.Windows.Forms.DataGridTextBoxColumn LotNumber;
		private System.Windows.Forms.DataGridTextBoxColumn Weight;
		private System.Windows.Forms.DataGridTextBoxColumn MeasureUnitName;
		private Cntrls.ItemNumberControl prevItemNumber;
		private System.Windows.Forms.ComboBox cbMN;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbParNo;
		private System.Windows.Forms.ColumnHeader itemParNo;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;


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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Itemizn2Form));
			this.lbCustomerName = new System.Windows.Forms.Label();
			this.lbCustomerProgram = new System.Windows.Forms.Label();
			this.lbFullItemName = new System.Windows.Forms.Label();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.GroupBox6 = new System.Windows.Forms.GroupBox();
			this.tbParNo = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.prevItemNumber = new Cntrls.ItemNumberControl();
			this.wcCustomerWeight = new Cntrls.WeightControl();
			this.wcWeight = new Cntrls.WeightControl();
			this.label1 = new System.Windows.Forms.Label();
			this.lb = new System.Windows.Forms.Label();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.tbLotNumber = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.lbRunningItemN = new System.Windows.Forms.Label();
			this.pbItemPicture = new System.Windows.Forms.PictureBox();
			this.btnWrong = new System.Windows.Forms.Button();
			this.btnDoneBatch = new System.Windows.Forms.Button();
			this.btnDoneGroup = new System.Windows.Forms.Button();
			this.listItems = new System.Windows.Forms.ListView();
			this.itemN = new System.Windows.Forms.ColumnHeader();
			this.lotN = new System.Windows.Forms.ColumnHeader();
			this.itemWeight = new System.Windows.Forms.ColumnHeader();
			this.itemCusomerWeight = new System.Windows.Forms.ColumnHeader();
			this.itemPrevItemN = new System.Windows.Forms.ColumnHeader();
			this.itemParNo = new System.Windows.Forms.ColumnHeader();
			this.tsItem = new System.Windows.Forms.DataGridTableStyle();
			this.number = new System.Windows.Forms.DataGridTextBoxColumn();
			this.LotNumber = new System.Windows.Forms.DataGridTextBoxColumn();
			this.Weight = new System.Windows.Forms.DataGridTextBoxColumn();
			this.MeasureUnitName = new System.Windows.Forms.DataGridTextBoxColumn();
			this.cbMN = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.GroupBox6.SuspendLayout();
			this.SuspendLayout();
			// 
			// lbCustomerName
			// 
			this.lbCustomerName.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(240)), ((System.Byte)(240)), ((System.Byte)(240)));
			this.lbCustomerName.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
			this.lbCustomerName.Location = new System.Drawing.Point(10, 10);
			this.lbCustomerName.Name = "lbCustomerName";
			this.lbCustomerName.Size = new System.Drawing.Size(370, 15);
			this.lbCustomerName.TabIndex = 3;
			this.lbCustomerName.Text = "Customer Name";
			// 
			// lbCustomerProgram
			// 
			this.lbCustomerProgram.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(240)), ((System.Byte)(240)), ((System.Byte)(240)));
			this.lbCustomerProgram.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
			this.lbCustomerProgram.Location = new System.Drawing.Point(10, 35);
			this.lbCustomerProgram.Name = "lbCustomerProgram";
			this.lbCustomerProgram.Size = new System.Drawing.Size(370, 15);
			this.lbCustomerProgram.TabIndex = 4;
			this.lbCustomerProgram.Text = "SKU/Customer Program";
			// 
			// lbFullItemName
			// 
			this.lbFullItemName.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(240)), ((System.Byte)(240)), ((System.Byte)(240)));
			this.lbFullItemName.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
			this.lbFullItemName.Location = new System.Drawing.Point(10, 60);
			this.lbFullItemName.Name = "lbFullItemName";
			this.lbFullItemName.Size = new System.Drawing.Size(370, 25);
			this.lbFullItemName.TabIndex = 5;
			this.lbFullItemName.Text = "Full Item Name";
			// 
			// statusBar1
			// 
			this.statusBar1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
			this.statusBar1.Location = new System.Drawing.Point(0, 680);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Size = new System.Drawing.Size(639, 15);
			this.statusBar1.TabIndex = 7;
			// 
			// GroupBox6
			// 
			this.GroupBox6.Controls.Add(this.tbParNo);
			this.GroupBox6.Controls.Add(this.label3);
			this.GroupBox6.Controls.Add(this.prevItemNumber);
			this.GroupBox6.Controls.Add(this.wcCustomerWeight);
			this.GroupBox6.Controls.Add(this.wcWeight);
			this.GroupBox6.Controls.Add(this.label1);
			this.GroupBox6.Controls.Add(this.lb);
			this.GroupBox6.Controls.Add(this.btnAdd);
			this.GroupBox6.Controls.Add(this.btnDelete);
			this.GroupBox6.Controls.Add(this.btnEdit);
			this.GroupBox6.Controls.Add(this.label7);
			this.GroupBox6.Controls.Add(this.label6);
			this.GroupBox6.Controls.Add(this.tbLotNumber);
			this.GroupBox6.Controls.Add(this.label5);
			this.GroupBox6.Controls.Add(this.lbRunningItemN);
			this.GroupBox6.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
			this.GroupBox6.ForeColor = System.Drawing.Color.DimGray;
			this.GroupBox6.Location = new System.Drawing.Point(10, 510);
			this.GroupBox6.Name = "GroupBox6";
			this.GroupBox6.Size = new System.Drawing.Size(615, 135);
			this.GroupBox6.TabIndex = 0;
			this.GroupBox6.TabStop = false;
			this.GroupBox6.Text = "Item";
			// 
			// tbParNo
			// 
			this.tbParNo.Location = new System.Drawing.Point(410, 35);
			this.tbParNo.Name = "tbParNo";
			this.tbParNo.Size = new System.Drawing.Size(140, 20);
			this.tbParNo.TabIndex = 2;
			this.tbParNo.Text = "";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label3.Location = new System.Drawing.Point(420, 15);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(110, 20);
			this.label3.TabIndex = 19;
			this.label3.Text = "Item Part #(ParNo)";
			// 
			// prevItemNumber
			// 
			this.prevItemNumber.Enabled = false;
			this.prevItemNumber.ItemNumber = "";
			this.prevItemNumber.Location = new System.Drawing.Point(130, 80);
			this.prevItemNumber.Name = "prevItemNumber";
			this.prevItemNumber.Size = new System.Drawing.Size(140, 20);
			this.prevItemNumber.TabIndex = 3;
			// 
			// wcCustomerWeight
			// 
			this.wcCustomerWeight.IsMeasureUnit = false;
			this.wcCustomerWeight.IsRequired = false;
			this.wcCustomerWeight.Location = new System.Drawing.Point(295, 35);
			this.wcCustomerWeight.Name = "wcCustomerWeight";
			this.wcCustomerWeight.Size = new System.Drawing.Size(90, 25);
			this.wcCustomerWeight.TabIndex = 1;
			this.wcCustomerWeight.Weight = "";
			// 
			// wcWeight
			// 
			this.wcWeight.Enabled = false;
			this.wcWeight.IsMeasureUnit = false;
			this.wcWeight.IsRequired = false;
			this.wcWeight.Location = new System.Drawing.Point(290, 80);
			this.wcWeight.Name = "wcWeight";
			this.wcWeight.Size = new System.Drawing.Size(90, 24);
			this.wcWeight.TabIndex = 4;
			this.wcWeight.Weight = "";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label1.Location = new System.Drawing.Point(130, 60);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 15);
			this.label1.TabIndex = 18;
			this.label1.Text = "Prev. Item N";
			// 
			// lb
			// 
			this.lb.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
			this.lb.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lb.Location = new System.Drawing.Point(295, 15);
			this.lb.Name = "lb";
			this.lb.Size = new System.Drawing.Size(100, 15);
			this.lb.TabIndex = 16;
			this.lb.Text = "Customer Weight";
			// 
			// btnAdd
			// 
			this.btnAdd.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
			this.btnAdd.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnAdd.Location = new System.Drawing.Point(390, 105);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(90, 23);
			this.btnAdd.TabIndex = 3;
			this.btnAdd.Text = "Add";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
			this.btnDelete.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnDelete.Location = new System.Drawing.Point(280, 105);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(90, 23);
			this.btnDelete.TabIndex = 5;
			this.btnDelete.Text = "Delete";
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
			this.btnEdit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnEdit.Location = new System.Drawing.Point(165, 105);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(90, 23);
			this.btnEdit.TabIndex = 4;
			this.btnEdit.Text = "Edit";
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
			this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label7.Location = new System.Drawing.Point(295, 65);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(45, 15);
			this.label7.TabIndex = 9;
			this.label7.Text = "Weight";
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
			this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label6.Location = new System.Drawing.Point(125, 15);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(72, 15);
			this.label6.TabIndex = 7;
			this.label6.Text = "Lot Number";
			// 
			// tbLotNumber
			// 
			this.tbLotNumber.Location = new System.Drawing.Point(130, 35);
			this.tbLotNumber.Name = "tbLotNumber";
			this.tbLotNumber.Size = new System.Drawing.Size(140, 20);
			this.tbLotNumber.TabIndex = 0;
			this.tbLotNumber.Text = "";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
			this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label5.Location = new System.Drawing.Point(10, 15);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(95, 15);
			this.label5.TabIndex = 5;
			this.label5.Text = "Running Item N";
			// 
			// lbRunningItemN
			// 
			this.lbRunningItemN.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(240)), ((System.Byte)(240)), ((System.Byte)(240)));
			this.lbRunningItemN.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
			this.lbRunningItemN.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lbRunningItemN.Location = new System.Drawing.Point(55, 35);
			this.lbRunningItemN.Name = "lbRunningItemN";
			this.lbRunningItemN.Size = new System.Drawing.Size(50, 20);
			this.lbRunningItemN.TabIndex = 4;
			this.lbRunningItemN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// pbItemPicture
			// 
			this.pbItemPicture.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbItemPicture.BackgroundImage")));
			this.pbItemPicture.Location = new System.Drawing.Point(400, 10);
			this.pbItemPicture.Name = "pbItemPicture";
			this.pbItemPicture.Size = new System.Drawing.Size(115, 115);
			this.pbItemPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pbItemPicture.TabIndex = 11;
			this.pbItemPicture.TabStop = false;
			this.pbItemPicture.Paint += new System.Windows.Forms.PaintEventHandler(this.pbItemPicture_Paint);
			// 
			// btnWrong
			// 
			this.btnWrong.BackColor = System.Drawing.Color.LightPink;
			this.btnWrong.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
			this.btnWrong.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnWrong.Location = new System.Drawing.Point(20, 650);
			this.btnWrong.Name = "btnWrong";
			this.btnWrong.Size = new System.Drawing.Size(140, 20);
			this.btnWrong.TabIndex = 3;
			this.btnWrong.Text = "Something Wrong";
			// 
			// btnDoneBatch
			// 
			this.btnDoneBatch.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
			this.btnDoneBatch.Location = new System.Drawing.Point(215, 650);
			this.btnDoneBatch.Name = "btnDoneBatch";
			this.btnDoneBatch.Size = new System.Drawing.Size(140, 20);
			this.btnDoneBatch.TabIndex = 2;
			this.btnDoneBatch.Text = "Done with the Batch";
			this.btnDoneBatch.Click += new System.EventHandler(this.btnDoneBatch_Click);
			// 
			// btnDoneGroup
			// 
			this.btnDoneGroup.BackColor = System.Drawing.Color.LightPink;
			this.btnDoneGroup.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
			this.btnDoneGroup.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnDoneGroup.Location = new System.Drawing.Point(415, 650);
			this.btnDoneGroup.Name = "btnDoneGroup";
			this.btnDoneGroup.Size = new System.Drawing.Size(145, 20);
			this.btnDoneGroup.TabIndex = 4;
			this.btnDoneGroup.Text = "Done with the Division";
			this.btnDoneGroup.Click += new System.EventHandler(this.btnDoneGroup_Click);
			// 
			// listItems
			// 
			this.listItems.AutoArrange = false;
			this.listItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.itemN,
																						this.lotN,
																						this.itemWeight,
																						this.itemCusomerWeight,
																						this.itemPrevItemN,
																						this.itemParNo});
			this.listItems.FullRowSelect = true;
			this.listItems.GridLines = true;
			this.listItems.HideSelection = false;
			this.listItems.LabelEdit = true;
			this.listItems.Location = new System.Drawing.Point(10, 135);
			this.listItems.MultiSelect = false;
			this.listItems.Name = "listItems";
			this.listItems.Size = new System.Drawing.Size(615, 370);
			this.listItems.TabIndex = 1;
			this.listItems.View = System.Windows.Forms.View.Details;
			this.listItems.SelectedIndexChanged += new System.EventHandler(this.listItems_SelectedIndexChanged);
			// 
			// itemN
			// 
			this.itemN.Text = "#";
			this.itemN.Width = 40;
			// 
			// lotN
			// 
			this.lotN.Text = "Lot Number";
			this.lotN.Width = 111;
			// 
			// itemWeight
			// 
			this.itemWeight.Text = "Weight";
			this.itemWeight.Width = 95;
			// 
			// itemCusomerWeight
			// 
			this.itemCusomerWeight.Text = "Customer Weight";
			this.itemCusomerWeight.Width = 103;
			// 
			// itemPrevItemN
			// 
			this.itemPrevItemN.Text = "Prev. Item N";
			this.itemPrevItemN.Width = 144;
			// 
			// itemParNo
			// 
			this.itemParNo.Text = "Part Number";
			this.itemParNo.Width = 111;
			// 
			// tsItem
			// 
			this.tsItem.DataGrid = null;
			this.tsItem.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.tsItem.MappingName = "";
			// 
			// number
			// 
			this.number.Format = "";
			this.number.FormatInfo = null;
			this.number.HeaderText = "#";
			this.number.MappingName = "number";
			this.number.Width = 75;
			// 
			// LotNumber
			// 
			this.LotNumber.Format = "";
			this.LotNumber.FormatInfo = null;
			this.LotNumber.HeaderText = "Lot Number";
			this.LotNumber.MappingName = "LotNumber";
			this.LotNumber.Width = 75;
			// 
			// Weight
			// 
			this.Weight.Format = "";
			this.Weight.FormatInfo = null;
			this.Weight.HeaderText = "Weight";
			this.Weight.MappingName = "TotalWeight";
			this.Weight.Width = 75;
			// 
			// MeasureUnitName
			// 
			this.MeasureUnitName.Format = "";
			this.MeasureUnitName.FormatInfo = null;
			this.MeasureUnitName.HeaderText = "Measure Unit";
			this.MeasureUnitName.MappingName = "MeasureUnitID.GetParentRow(\"Item_MeasureUnit\")";
			this.MeasureUnitName.Width = 75;
			// 
			// cbMN
			// 
			this.cbMN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbMN.Items.AddRange(new object[] {
													  "(none)"});
			this.cbMN.Location = new System.Drawing.Point(5, 105);
			this.cbMN.Name = "cbMN";
			this.cbMN.Size = new System.Drawing.Size(370, 21);
			this.cbMN.TabIndex = 12;
			this.cbMN.Visible = false;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
			this.label2.Location = new System.Drawing.Point(10, 90);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 15);
			this.label2.TabIndex = 13;
			this.label2.Text = "Memo Number";
			this.label2.Visible = false;
			// 
			// Itemizn2Form
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(639, 695);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cbMN);
			this.Controls.Add(this.listItems);
			this.Controls.Add(this.btnDoneGroup);
			this.Controls.Add(this.btnDoneBatch);
			this.Controls.Add(this.btnWrong);
			this.Controls.Add(this.pbItemPicture);
			this.Controls.Add(this.GroupBox6);
			this.Controls.Add(this.statusBar1);
			this.Controls.Add(this.lbFullItemName);
			this.Controls.Add(this.lbCustomerProgram);
			this.Controls.Add(this.lbCustomerName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Itemizn2Form";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Itemizn part 2";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Itemizn2Form_Closing);
			this.Load += new System.EventHandler(this.Itemizn2Form_Load);
			this.GroupBox6.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new Itemizn2Form(2));
		}
		#endregion Generated

		public Itemizn2Form(int level)
		{
			//
			// Required for Windows Form Designer support
			//
			accessLevel = level; // security access level
			InitializeComponent();
			Initialize();
			this.Text = Service.sProgramTitle + "Itemizn part 2";

		}
		
		private void Initialize()
		{

			Service.GetItemizn_MeasureUnits(dsData); // MeasureUnit

		//	Itemizn1Form frm = (Itemizn1Form)this.Parent;
		//	cbWeightUnit.Items.AddRange(new object[] {"g", "ct."});
		//	cbWeightUnit.SelectedIndex = 1;

			wcWeight.Initialize(dsData.Tables["MeasureUnits"].DefaultView);
			wcWeight.MeasureUnitCode = "2"; // set "ct." as default weight MeasureUnit
			wcCustomerWeight.Initialize(dsData.Tables["MeasureUnits"].DefaultView);
			wcCustomerWeight.MeasureUnitCode = "2"; // set "ct." as default weight MeasureUnit

			
			Clear();

			if (accessLevel < 2)
			{
				btnAdd.Enabled = false;
				btnDoneBatch.Enabled = false;
				btnDoneBatch.BackColor = SystemColors.Control;
				btnDoneGroup.Enabled = false;
				btnDoneGroup.BackColor = SystemColors.Control;
			}
		}

		private void Clear()
		{
			btnEdit.Enabled = false;
			btnDelete.Enabled = false;
			btnAdd.Enabled = true;
			btnDoneBatch.Enabled = false;
			listItems.Items.Clear();
			lbRunningItemN.Text = (listItems.Items.Count+1).ToString();
			statusBar1.Text = "";
			tbLotNumber.Text = "";
			tbParNo.Text = "";
			tbLotNumber.Focus();
		}



		private  void setState(string state)
		{
				this.Enabled = true;
				if (state == "item selected")
				{
					btnEdit.Enabled = true;
					btnDelete.Enabled = true;
					btnAdd.Enabled = true;
					btnDoneBatch.Enabled = false;
					if(listItems.Items.Count > 0)
					{
						btnDoneBatch.Enabled = true;
					}
					tbLotNumber.Focus();
					// if number of items in the current group is reached
					if(listItems.Items.Count + addedItemsQuantity >= itemsInGroup || listItems.Items.Count == 25)
						btnAdd.Enabled = false;
				}
				if (state == "after edit")
				{
					btnEdit.Enabled = false;
					btnDelete.Enabled = false;
					btnAdd.Enabled = true;
					foreach (ListViewItem item in listItems.Items)
					{
						item.SubItems[0].Text = (item.Index+1).ToString();
						item.Selected = false;
					}
					lbRunningItemN.Text = (listItems.Items.Count+1).ToString();
					tbLotNumber.Text = "";
					tbParNo.Text = "";
					wcCustomerWeight.Clear();
					wcWeight.Clear();
					prevItemNumber.Clear();
					
					tbLotNumber.Focus();
					btnDoneBatch.Enabled = (listItems.Items.Count > 0);
					
					// if number of items in the current group is reached
					if(listItems.Items.Count + addedItemsQuantity >= itemsInGroup)
					{
						btnAdd.Enabled = false;
						lbRunningItemN.Text = "";
						statusBar1.Text = "Number of items in the current Division is reached.";
					}
					// if 25 items added - done batch
					if(listItems.Items.Count == 25)
					{
						statusBar1.Text = "25 items added. Press \"Done with the Batch\" button.";
						btnAdd.Enabled = false;
						lbRunningItemN.Text = "";
					}
				}
		}


		#region EventHandler

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(wcWeight.Weight!="" && wcCustomerWeight.Weight!="" && Convert.ToDouble(wcWeight.Weight) != Convert.ToDouble(wcCustomerWeight.Weight))
					MessageBox.Show("Item Weight and Customer Item Weight are different.");

				ListViewItem item1 = new ListViewItem((listItems.Items.Count+1).ToString(), 0);
				item1.SubItems.Add(tbLotNumber.Text.Trim());
				item1.SubItems.Add(wcWeight.Weight);
				item1.SubItems.Add(wcCustomerWeight.Weight);

				if(prevItemNumber.ItemNumber.Length>0)
				{
					if( Service.GetItemByCode(
						prevItemNumber.ItemNumber.Split(new char []{'.'})[1], 
						prevItemNumber.ItemNumber.Split(new char []{'.'})[2], 
						prevItemNumber.ItemNumber.Split(new char []{'.'})[3] ).Rows.Count == 0) 
					{
						prevItemNumber.Focus();
						throw new Exception("Entered Prev. Item N does not exist.");
					}
					item1.SubItems.Add(prevItemNumber.ItemNumber);
				}
				else
				item1.SubItems.Add("");
				item1.SubItems.Add(tbParNo.Text.Trim());
				listItems.Items.Add(item1);
				listItems.EnsureVisible(item1.Index);
				setState("after edit");
			}
			catch (Exception exc) 
			{ 
				MessageBox.Show(exc.Message);
			}



			// if number of items in the current group is reached
			if(listItems.Items.Count + addedItemsQuantity >= itemsInGroup)
			{
				DoneGroupDialogForm frm = new DoneGroupDialogForm();
				DialogResult dlgRes = frm.ShowDialog(this);
				if(dlgRes == DialogResult.OK)
				{
					DoneBatch();
				}
				else
				{
					if(dlgRes == DialogResult.Retry)
						canClose = false;
					else
					{
						MessageBox.Show("Call Manager");
						canClose = false;
						//canClose = true;
						//this.Close();
					}
				}
			}
			else 
			if(listItems.Items.Count == 25)// if 25 items added - done batch
			{
				DoneBatchDialogForm frm = new DoneBatchDialogForm();
				if(frm.ShowDialog(this) == DialogResult.OK)
				{
					DoneBatch();
					Clear();
				}
			}

		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			listItems.Items.Remove(listItems.SelectedItems[0]);
			setState("after edit");
		}

		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(wcWeight.Weight!="" && wcCustomerWeight.Weight!="" && Convert.ToDouble(wcWeight.Weight) != Convert.ToDouble(wcCustomerWeight.Weight))
					MessageBox.Show("Item Weight and Customer Item Weight are different.");

				if (listItems.SelectedItems.Count > 0)
				{
					listItems.SelectedItems[0].SubItems[1].Text = tbLotNumber.Text;
					listItems.SelectedItems[0].SubItems[2].Text = wcWeight.Weight.ToString();
					listItems.SelectedItems[0].SubItems[3].Text = wcCustomerWeight.Weight.ToString();
					listItems.SelectedItems[0].SubItems[5].Text = tbParNo.Text.Trim();
					if(prevItemNumber.ItemNumber.Length>0)
					{
						if( Service.GetItemByCode(
							prevItemNumber.ItemNumber.Split(new char []{'.'})[1], 
							prevItemNumber.ItemNumber.Split(new char []{'.'})[2], 
							prevItemNumber.ItemNumber.Split(new char []{'.'})[3] ).Rows.Count == 0) 
						{
							prevItemNumber.Focus();
							throw new Exception("Entered Prev. Item N does not exist.");
						}
						listItems.SelectedItems[0].SubItems[4].Text = prevItemNumber.ItemNumber;
					}
					else
						listItems.SelectedItems[0].SubItems[4].Text = "";
				}
				setState("after edit");
			}
			catch (Exception exc) 
			{ 
				MessageBox.Show(exc.Message);
			}
		}

		private void btnDoneBatch_Click(object sender, System.EventArgs e)
		{			
			DoneBatch();		
			Clear();
		}

		public void DoneBatch()
		{			
			try
			{
				this.Enabled = false;
				foreach (ListViewItem listItem in listItems.Items)
				{
					((Itemizn1Form)Owner).AddItem(	Convert.ToInt32(listItem.SubItems[0].Text), 
													listItem.SubItems[1].Text,
													listItem.SubItems[5].Text,
													listItem.SubItems[4].Text,
													listItem.SubItems[2].Text, 
													wcWeight.MeasureUnitID, 
													listItem.SubItems[3].Text, 
													wcCustomerWeight.MeasureUnitID,
													iSetID);
					addedItemsQuantity++;
				}
				((Itemizn1Form)Owner).AddBatch(itemsTypeId, CustomerProgram, CustomerProgramId, iSetID, ref statusBar1);
			}
			finally
			{
				statusBar1.Text = "";
				this.Enabled = true;
				if(addedItemsQuantity >= itemsInGroup)
				{
					canClose = true;
					this.Close();
				}
			}		
		}

		private void listItems_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (listItems.SelectedItems.Count > 0)
			{
				setState("item selected");
				lbRunningItemN.Text = listItems.SelectedItems[0].SubItems[0].Text;
				tbLotNumber.Text = listItems.SelectedItems[0].SubItems[1].Text;
				wcWeight.Weight = listItems.SelectedItems[0].SubItems[2].Text;
				wcCustomerWeight.Weight = listItems.SelectedItems[0].SubItems[3].Text;
				tbParNo.Text = listItems.SelectedItems[0].SubItems[5].Text;
				if(listItems.SelectedItems[0].SubItems[4].Text != "")
				{
					string str = listItems.SelectedItems[0].SubItems[4].Text;
					prevItemNumber.ItemNumber = str;
				}
				else
					prevItemNumber.Clear();
			}
		}

		#endregion EventHandler

		private void btnDoneGroup_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show("Call Manager");
		}

		private void pbItemPicture_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			if(pbItemPicture.Image==null) return;
			if(pbItemPicture.Image.Size.Height > pbItemPicture.Size.Height || pbItemPicture.Image.Size.Width > pbItemPicture.Size.Width)
			{
				pbItemPicture.SizeMode = PictureBoxSizeMode.StretchImage;
			}
			else
			{
				pbItemPicture.SizeMode = PictureBoxSizeMode.CenterImage;
			}
		}

		private void Itemizn2Form_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (!canClose)
				e.Cancel = true;
		}

		private void Itemizn2Form_Load(object sender, System.EventArgs e)
		{
		
		}

		
	}

}
