using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text.RegularExpressions;
using System.Threading;
using Cntrls;
using System.Xml;
//using System.Data.OleDb;
//using gdrClientLibrary;

namespace gemoDream
{
	/// <summary>
	/// Summary description for Itemizn1Form.
	/// </summary>
	public class Itemizn1Form : System.Windows.Forms.Form
	{
		private bool canClose = false;
		private CMStrategy.CMStrategy cmstrategy;
		private DataSet dsMainDataSet; //= new DataSet(); // main dataset
		private DataSet dsBatchCPItemSet;// = new DataSet(); // dataset for total itemizing
		private DataSet dsMemoNumbers;
		private DataSet dsDatafromXLS;
		private int accessLevel;
		private string formState;
		private bool nonNumberEntered;
		private bool nonNumberEntered1;
		private string FormState = "";
		private bool bLoading = false;
		private Thread PrintingThread;
		private ArrayList alThreadPrintParam;
		private bool bAutoCreateBatch;
		private string sGroup = "";
		private bool bLoadingFromXML = false;
		private int iServiceType = 0;

		#region Generated
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label3;
		internal System.Windows.Forms.Label Label14;
		private System.Windows.Forms.Panel panel2;
		internal System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Panel panel4;
		internal System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ImageList imageList2;
		private System.Windows.Forms.Label lbCustomerName;
		private System.Windows.Forms.Label lbVendorInfo;
		private System.Windows.Forms.Label lbWeightNotInspected;
		private System.Windows.Forms.Label lbItemsNotInspected;
		private System.Windows.Forms.Button btnStartGrouping;
		private System.Windows.Forms.Button btnWrong;
		private System.Windows.Forms.Button btnCreateGroup;
		private System.Windows.Forms.TextBox tbCustomerProgram;
		public System.Windows.Forms.TextBox tbItemsInGroup;
		private System.Windows.Forms.Button btnDoneBag;
		private System.ComponentModel.IContainer components;

		private System.Windows.Forms.TabControl tabGroup;
		private System.Windows.Forms.ToolTip toolTip1;
		public System.Windows.Forms.TextBox tbBatchesList;
		private Cntrls.ItemPanel itemPanel1;
		private Cntrls.WeightControl wcInspected;
		public System.Windows.Forms.TextBox tbItemsInspected;
		private System.Windows.Forms.Button btnDepartureSettings;
		private System.Windows.Forms.Button btnSaveNumberOfItemsInspected;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbMemoNumber;
		private System.Windows.Forms.CheckBox cbEditCP;
		private System.Windows.Forms.ComboBox cbMemoNumber;
		private System.Windows.Forms.Button btnOldNumber;
		private System.Windows.Forms.Button btnAutoCreateBatch;
		private System.Windows.Forms.Button btnAddToList;
		private System.Windows.Forms.ComboBox cbCustomerProgram;
		private System.Windows.Forms.DataGrid dgItemsSet;
		private System.Windows.Forms.TextBox tbTotalItemsInSet;
		private System.Windows.Forms.TextBox tbItemsNotAdded;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnClearSet;
		private System.Windows.Forms.Label label5;
		public System.Windows.Forms.Label lbItemsItemized;
		private System.Windows.Forms.TextBox tbOldNumbers;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rbBatchLabelsPrint;
		private System.Windows.Forms.RadioButton rbBatchLabelsSkip;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton rbItemLabelsRegular;
		private System.Windows.Forms.RadioButton rbItemLabelsSpecial;
		public Cntrls.BarCode bcItem;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.RadioButton rbSelectRealItem;
		private System.Windows.Forms.RadioButton rbSelectReportItem;
		private System.Windows.Forms.GroupBox groupBox3;
		private TextBox txtXLSFile;
		private Button btnItmzFromXLS;
		private Label label11;
		private TextBox txt_XMLFile;
		private TabPage tabPage2;
		private DataGridView dataGridView1;
		private OpenFileDialog openFileDialog1;
		public Cntrls.BarCodeField bcfItem;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Itemizn1Form));
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.lbCustomerName = new System.Windows.Forms.Label();
			this.lbVendorInfo = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lbWeightNotInspected = new System.Windows.Forms.Label();
			this.Label14 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.lbItemsNotInspected = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lbItemsItemized = new System.Windows.Forms.Label();
			this.cbMemoNumber = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.wcInspected = new Cntrls.WeightControl();
			this.tbItemsInspected = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tbMemoNumber = new System.Windows.Forms.TextBox();
			this.btnItmzFromXLS = new System.Windows.Forms.Button();
			this.label11 = new System.Windows.Forms.Label();
			this.txtXLSFile = new System.Windows.Forms.TextBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.rbSelectRealItem = new System.Windows.Forms.RadioButton();
			this.rbSelectReportItem = new System.Windows.Forms.RadioButton();
			this.btnStartGrouping = new System.Windows.Forms.Button();
			this.panel3 = new System.Windows.Forms.Panel();
			this.tabGroup = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.dgItemsSet = new System.Windows.Forms.DataGrid();
			this.panel5 = new System.Windows.Forms.Panel();
			this.tbBatchesList = new System.Windows.Forms.TextBox();
			this.btnCreateGroup = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.rbItemLabelsSpecial = new System.Windows.Forms.RadioButton();
			this.rbItemLabelsRegular = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rbBatchLabelsSkip = new System.Windows.Forms.RadioButton();
			this.rbBatchLabelsPrint = new System.Windows.Forms.RadioButton();
			this.btnClearSet = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tbItemsNotAdded = new System.Windows.Forms.TextBox();
			this.tbTotalItemsInSet = new System.Windows.Forms.TextBox();
			this.btnAddToList = new System.Windows.Forms.Button();
			this.cbEditCP = new System.Windows.Forms.CheckBox();
			this.itemPanel1 = new Cntrls.ItemPanel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.cbCustomerProgram = new System.Windows.Forms.ComboBox();
			this.tbItemsInGroup = new System.Windows.Forms.TextBox();
			this.tbCustomerProgram = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.btnAutoCreateBatch = new System.Windows.Forms.Button();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.btnWrong = new System.Windows.Forms.Button();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.imageList2 = new System.Windows.Forms.ImageList(this.components);
			this.btnDoneBag = new System.Windows.Forms.Button();
			this.btnDepartureSettings = new System.Windows.Forms.Button();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.btnSaveNumberOfItemsInspected = new System.Windows.Forms.Button();
			this.btnOldNumber = new System.Windows.Forms.Button();
			this.tbOldNumbers = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txt_XMLFile = new System.Windows.Forms.TextBox();
			this.bcItem = new Cntrls.BarCode();
			this.bcfItem = new Cntrls.BarCodeField();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.panel3.SuspendLayout();
			this.tabGroup.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgItemsSet)).BeginInit();
			this.panel5.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel4.SuspendLayout();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// statusBar1
			// 
			this.statusBar1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.statusBar1.Location = new System.Drawing.Point(0, 680);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Size = new System.Drawing.Size(955, 15);
			this.statusBar1.TabIndex = 0;
			// 
			// lbCustomerName
			// 
			this.lbCustomerName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.lbCustomerName.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.lbCustomerName.Location = new System.Drawing.Point(5, 35);
			this.lbCustomerName.Name = "lbCustomerName";
			this.lbCustomerName.Size = new System.Drawing.Size(370, 15);
			this.lbCustomerName.TabIndex = 2;
			this.lbCustomerName.Text = "Customer Name";
			// 
			// lbVendorInfo
			// 
			this.lbVendorInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.lbVendorInfo.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.lbVendorInfo.Location = new System.Drawing.Point(385, 35);
			this.lbVendorInfo.Name = "lbVendorInfo";
			this.lbVendorInfo.Size = new System.Drawing.Size(315, 15);
			this.lbVendorInfo.TabIndex = 3;
			this.lbVendorInfo.Text = "Chain/Vendor Info";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lbWeightNotInspected);
			this.panel1.Controls.Add(this.Label14);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.lbItemsNotInspected);
			this.panel1.Location = new System.Drawing.Point(5, 55);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(695, 25);
			this.panel1.TabIndex = 4;
			// 
			// lbWeightNotInspected
			// 
			this.lbWeightNotInspected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.lbWeightNotInspected.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.lbWeightNotInspected.Location = new System.Drawing.Point(555, 5);
			this.lbWeightNotInspected.Name = "lbWeightNotInspected";
			this.lbWeightNotInspected.Size = new System.Drawing.Size(137, 15);
			this.lbWeightNotInspected.TabIndex = 5;
			// 
			// Label14
			// 
			this.Label14.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.Label14.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label14.Location = new System.Drawing.Point(440, 5);
			this.Label14.Name = "Label14";
			this.Label14.Size = new System.Drawing.Size(115, 15);
			this.Label14.TabIndex = 4;
			this.Label14.Text = "Total Weight n/Insp.";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(5, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(115, 15);
			this.label3.TabIndex = 0;
			this.label3.Text = "N/Inspected Items #";
			// 
			// lbItemsNotInspected
			// 
			this.lbItemsNotInspected.BackColor = System.Drawing.Color.White;
			this.lbItemsNotInspected.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.lbItemsNotInspected.Location = new System.Drawing.Point(120, 0);
			this.lbItemsNotInspected.Name = "lbItemsNotInspected";
			this.lbItemsNotInspected.Size = new System.Drawing.Size(50, 15);
			this.lbItemsNotInspected.TabIndex = 3;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.lbItemsItemized);
			this.panel2.Controls.Add(this.cbMemoNumber);
			this.panel2.Controls.Add(this.label5);
			this.panel2.Controls.Add(this.wcInspected);
			this.panel2.Controls.Add(this.tbItemsInspected);
			this.panel2.Controls.Add(this.label7);
			this.panel2.Controls.Add(this.label9);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.tbMemoNumber);
			this.panel2.Location = new System.Drawing.Point(5, 80);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(700, 65);
			this.panel2.TabIndex = 5;
			this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
			// 
			// lbItemsItemized
			// 
			this.lbItemsItemized.BackColor = System.Drawing.Color.White;
			this.lbItemsItemized.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.lbItemsItemized.Location = new System.Drawing.Point(120, 25);
			this.lbItemsItemized.Name = "lbItemsItemized";
			this.lbItemsItemized.Size = new System.Drawing.Size(50, 15);
			this.lbItemsItemized.TabIndex = 18;
			// 
			// cbMemoNumber
			// 
			this.cbMemoNumber.Location = new System.Drawing.Point(240, 5);
			this.cbMemoNumber.Name = "cbMemoNumber";
			this.cbMemoNumber.Size = new System.Drawing.Size(185, 20);
			this.cbMemoNumber.TabIndex = 14;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(5, 20);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(110, 15);
			this.label5.TabIndex = 17;
			this.label5.Text = "Itemized Items #";
			// 
			// wcInspected
			// 
			this.wcInspected.IsMeasureUnit = true;
			this.wcInspected.IsRequired = false;
			this.wcInspected.Location = new System.Drawing.Point(545, 2);
			this.wcInspected.Name = "wcInspected";
			this.wcInspected.Size = new System.Drawing.Size(145, 24);
			this.wcInspected.TabIndex = 9;
			this.wcInspected.Weight = "";
			// 
			// tbItemsInspected
			// 
			this.tbItemsInspected.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.tbItemsInspected.Location = new System.Drawing.Point(120, 0);
			this.tbItemsInspected.Name = "tbItemsInspected";
			this.tbItemsInspected.Size = new System.Drawing.Size(50, 20);
			this.tbItemsInspected.TabIndex = 6;
			this.tbItemsInspected.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbItemsInspected_KeyDown);
			this.tbItemsInspected.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbItemsInspected_KeyPress);
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label7.Location = new System.Drawing.Point(440, 5);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(100, 15);
			this.label7.TabIndex = 4;
			this.label7.Text = "Total Weight Insp.";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(5, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(110, 15);
			this.label9.TabIndex = 0;
			this.label9.Text = "Inspected Items #";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(190, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(50, 15);
			this.label1.TabIndex = 15;
			this.label1.Text = "Memo:";
			// 
			// tbMemoNumber
			// 
			this.tbMemoNumber.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.tbMemoNumber.Location = new System.Drawing.Point(250, 5);
			this.tbMemoNumber.Name = "tbMemoNumber";
			this.tbMemoNumber.Size = new System.Drawing.Size(180, 20);
			this.tbMemoNumber.TabIndex = 10;
			this.tbMemoNumber.Visible = false;
			// 
			// btnItmzFromXLS
			// 
			this.btnItmzFromXLS.Location = new System.Drawing.Point(752, 220);
			this.btnItmzFromXLS.Name = "btnItmzFromXLS";
			this.btnItmzFromXLS.Size = new System.Drawing.Size(186, 20);
			this.btnItmzFromXLS.TabIndex = 24;
			this.btnItmzFromXLS.Text = "Select Excel File";
			this.btnItmzFromXLS.UseVisualStyleBackColor = true;
			this.btnItmzFromXLS.Click += new System.EventHandler(this.btnItmzFromXLS_Click);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(750, 123);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(105, 12);
			this.label11.TabIndex = 23;
			this.label11.Text = "Excel File To Load";
			// 
			// txtXLSFile
			// 
			this.txtXLSFile.Location = new System.Drawing.Point(582, 151);
			this.txtXLSFile.Name = "txtXLSFile";
			this.txtXLSFile.Size = new System.Drawing.Size(361, 20);
			this.txtXLSFile.TabIndex = 22;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.rbSelectRealItem);
			this.groupBox3.Controls.Add(this.rbSelectReportItem);
			this.groupBox3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.groupBox3.Location = new System.Drawing.Point(760, 55);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(165, 45);
			this.groupBox3.TabIndex = 21;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Item Type";
			// 
			// rbSelectRealItem
			// 
			this.rbSelectRealItem.Location = new System.Drawing.Point(10, 20);
			this.rbSelectRealItem.Name = "rbSelectRealItem";
			this.rbSelectRealItem.Size = new System.Drawing.Size(64, 19);
			this.rbSelectRealItem.TabIndex = 0;
			this.rbSelectRealItem.Text = "Real";
			// 
			// rbSelectReportItem
			// 
			this.rbSelectReportItem.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.rbSelectReportItem.Location = new System.Drawing.Point(79, 17);
			this.rbSelectReportItem.Name = "rbSelectReportItem";
			this.rbSelectReportItem.Size = new System.Drawing.Size(66, 25);
			this.rbSelectReportItem.TabIndex = 1;
			this.rbSelectReportItem.Text = "Report";
			// 
			// btnStartGrouping
			// 
			this.btnStartGrouping.BackColor = System.Drawing.Color.LightSteelBlue;
			this.btnStartGrouping.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.btnStartGrouping.Location = new System.Drawing.Point(0, 0);
			this.btnStartGrouping.Name = "btnStartGrouping";
			this.btnStartGrouping.Size = new System.Drawing.Size(150, 20);
			this.btnStartGrouping.TabIndex = 6;
			this.btnStartGrouping.Text = "Start Divisioning";
			this.btnStartGrouping.UseVisualStyleBackColor = false;
			this.btnStartGrouping.Click += new System.EventHandler(this.btnStartGrouping_Click);
			// 
			// panel3
			// 
			this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
			this.panel3.Controls.Add(this.btnStartGrouping);
			this.panel3.Location = new System.Drawing.Point(545, 115);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(150, 20);
			this.panel3.TabIndex = 7;
			// 
			// tabGroup
			// 
			this.tabGroup.Controls.Add(this.tabPage1);
			this.tabGroup.Controls.Add(this.tabPage2);
			this.tabGroup.Enabled = false;
			this.tabGroup.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.tabGroup.Location = new System.Drawing.Point(5, 167);
			this.tabGroup.Name = "tabGroup";
			this.tabGroup.SelectedIndex = 0;
			this.tabGroup.Size = new System.Drawing.Size(741, 478);
			this.tabGroup.TabIndex = 8;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.dgItemsSet);
			this.tabPage1.Controls.Add(this.panel5);
			this.tabPage1.Controls.Add(this.groupBox2);
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Controls.Add(this.btnClearSet);
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.tbItemsNotAdded);
			this.tabPage1.Controls.Add(this.tbTotalItemsInSet);
			this.tabPage1.Controls.Add(this.btnAddToList);
			this.tabPage1.Controls.Add(this.cbEditCP);
			this.tabPage1.Controls.Add(this.itemPanel1);
			this.tabPage1.Controls.Add(this.panel4);
			this.tabPage1.Controls.Add(this.btnAutoCreateBatch);
			this.tabPage1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.tabPage1.Location = new System.Drawing.Point(4, 21);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(733, 453);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Group";
			// 
			// dgItemsSet
			// 
			this.dgItemsSet.AllowNavigation = false;
			this.dgItemsSet.AllowSorting = false;
			this.dgItemsSet.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.dgItemsSet.CaptionVisible = false;
			this.dgItemsSet.DataMember = "";
			this.dgItemsSet.Font = new System.Drawing.Font("Tahoma", 8F);
			this.dgItemsSet.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgItemsSet.Location = new System.Drawing.Point(5, 40);
			this.dgItemsSet.Name = "dgItemsSet";
			this.dgItemsSet.ParentRowsVisible = false;
			this.dgItemsSet.Size = new System.Drawing.Size(409, 304);
			this.dgItemsSet.TabIndex = 18;
			this.dgItemsSet.Navigate += new System.Windows.Forms.NavigateEventHandler(this.dgItemsSet_Navigate);
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.tbBatchesList);
			this.panel5.Controls.Add(this.btnCreateGroup);
			this.panel5.Location = new System.Drawing.Point(5, 195);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(700, 255);
			this.panel5.TabIndex = 28;
			// 
			// tbBatchesList
			// 
			this.tbBatchesList.BackColor = System.Drawing.SystemColors.Window;
			this.tbBatchesList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbBatchesList.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbBatchesList.ForeColor = System.Drawing.Color.Black;
			this.tbBatchesList.Location = new System.Drawing.Point(3, 155);
			this.tbBatchesList.Multiline = true;
			this.tbBatchesList.Name = "tbBatchesList";
			this.tbBatchesList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbBatchesList.Size = new System.Drawing.Size(696, 97);
			this.tbBatchesList.TabIndex = 11;
			// 
			// btnCreateGroup
			// 
			this.btnCreateGroup.BackColor = System.Drawing.Color.LightSteelBlue;
			this.btnCreateGroup.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.btnCreateGroup.Location = new System.Drawing.Point(495, 35);
			this.btnCreateGroup.Name = "btnCreateGroup";
			this.btnCreateGroup.Size = new System.Drawing.Size(135, 20);
			this.btnCreateGroup.TabIndex = 8;
			this.btnCreateGroup.Text = "Create Regular Batch";
			this.btnCreateGroup.UseVisualStyleBackColor = false;
			this.btnCreateGroup.Visible = false;
			this.btnCreateGroup.EnabledChanged += new System.EventHandler(this.btnCreateGroup_EnabledChanged);
			this.btnCreateGroup.Click += new System.EventHandler(this.btnCreateGroup_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.rbItemLabelsSpecial);
			this.groupBox2.Controls.Add(this.rbItemLabelsRegular);
			this.groupBox2.Location = new System.Drawing.Point(535, 135);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(100, 60);
			this.groupBox2.TabIndex = 27;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Item Labels";
			// 
			// rbItemLabelsSpecial
			// 
			this.rbItemLabelsSpecial.Location = new System.Drawing.Point(10, 40);
			this.rbItemLabelsSpecial.Name = "rbItemLabelsSpecial";
			this.rbItemLabelsSpecial.Size = new System.Drawing.Size(70, 15);
			this.rbItemLabelsSpecial.TabIndex = 1;
			this.rbItemLabelsSpecial.Text = "Special";
			// 
			// rbItemLabelsRegular
			// 
			this.rbItemLabelsRegular.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.rbItemLabelsRegular.Location = new System.Drawing.Point(10, 20);
			this.rbItemLabelsRegular.Name = "rbItemLabelsRegular";
			this.rbItemLabelsRegular.Size = new System.Drawing.Size(75, 15);
			this.rbItemLabelsRegular.TabIndex = 0;
			this.rbItemLabelsRegular.Text = "Regular";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rbBatchLabelsSkip);
			this.groupBox1.Controls.Add(this.rbBatchLabelsPrint);
			this.groupBox1.Location = new System.Drawing.Point(425, 135);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(90, 60);
			this.groupBox1.TabIndex = 26;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Batch Labels";
			// 
			// rbBatchLabelsSkip
			// 
			this.rbBatchLabelsSkip.Location = new System.Drawing.Point(10, 40);
			this.rbBatchLabelsSkip.Name = "rbBatchLabelsSkip";
			this.rbBatchLabelsSkip.Size = new System.Drawing.Size(65, 15);
			this.rbBatchLabelsSkip.TabIndex = 1;
			this.rbBatchLabelsSkip.Text = "Skip";
			// 
			// rbBatchLabelsPrint
			// 
			this.rbBatchLabelsPrint.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.rbBatchLabelsPrint.Location = new System.Drawing.Point(10, 20);
			this.rbBatchLabelsPrint.Name = "rbBatchLabelsPrint";
			this.rbBatchLabelsPrint.Size = new System.Drawing.Size(65, 15);
			this.rbBatchLabelsPrint.TabIndex = 0;
			this.rbBatchLabelsPrint.Text = "Print";

			// 
			// btnClearSet
			// 
			this.btnClearSet.Location = new System.Drawing.Point(630, 80);
			this.btnClearSet.Name = "btnClearSet";
			this.btnClearSet.Size = new System.Drawing.Size(65, 20);
			this.btnClearSet.TabIndex = 23;
			this.btnClearSet.Text = "Clear Set";
			this.btnClearSet.Click += new System.EventHandler(this.btnClearSet_Click);
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.Location = new System.Drawing.Point(570, 40);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(75, 15);
			this.label4.TabIndex = 22;
			this.label4.Text = "## to Add";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(480, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(75, 15);
			this.label2.TabIndex = 21;
			this.label2.Text = "## in Set";
			// 
			// tbItemsNotAdded
			// 
			this.tbItemsNotAdded.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tbItemsNotAdded.Location = new System.Drawing.Point(575, 55);
			this.tbItemsNotAdded.Name = "tbItemsNotAdded";
			this.tbItemsNotAdded.ReadOnly = true;
			this.tbItemsNotAdded.Size = new System.Drawing.Size(60, 20);
			this.tbItemsNotAdded.TabIndex = 20;
			// 
			// tbTotalItemsInSet
			// 
			this.tbTotalItemsInSet.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tbTotalItemsInSet.Location = new System.Drawing.Point(485, 55);
			this.tbTotalItemsInSet.Name = "tbTotalItemsInSet";
			this.tbTotalItemsInSet.ReadOnly = true;
			this.tbTotalItemsInSet.Size = new System.Drawing.Size(60, 20);
			this.tbTotalItemsInSet.TabIndex = 19;
			// 
			// btnAddToList
			// 
			this.btnAddToList.BackColor = System.Drawing.SystemColors.Control;
			this.btnAddToList.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAddToList.Location = new System.Drawing.Point(420, 80);
			this.btnAddToList.Name = "btnAddToList";
			this.btnAddToList.Size = new System.Drawing.Size(90, 20);
			this.btnAddToList.TabIndex = 17;
			this.btnAddToList.Text = "Add To List";
			this.btnAddToList.UseVisualStyleBackColor = false;
			this.btnAddToList.Click += new System.EventHandler(this.btnAddToList_Click);
			// 
			// cbEditCP
			// 
			this.cbEditCP.Location = new System.Drawing.Point(10, 385);
			this.cbEditCP.Name = "cbEditCP";
			this.cbEditCP.Size = new System.Drawing.Size(150, 15);
			this.cbEditCP.TabIndex = 11;
			this.cbEditCP.Text = "Edit Customer Program";
			this.cbEditCP.Visible = false;
			// 
			// itemPanel1
			// 
			this.itemPanel1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.itemPanel1.FullItemName = "Full Item Name";
			this.itemPanel1.ItemPicture = null;
			this.itemPanel1.Location = new System.Drawing.Point(5, 195);
			this.itemPanel1.Name = "itemPanel1";
			this.itemPanel1.Size = new System.Drawing.Size(696, 185);
			this.itemPanel1.TabIndex = 10;
			this.itemPanel1.Changed += new System.EventHandler(this.itemPanel3_Changed);
			this.itemPanel1.NewItemTypeSelected += new System.EventHandler(this.itemPanel1_NewItemTypeSelected);
			this.itemPanel1.Load += new System.EventHandler(this.itemPanel1_Load_1);
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.cbCustomerProgram);
			this.panel4.Controls.Add(this.tbItemsInGroup);
			this.panel4.Controls.Add(this.tbCustomerProgram);
			this.panel4.Controls.Add(this.label6);
			this.panel4.Controls.Add(this.label8);
			this.panel4.Location = new System.Drawing.Point(5, 5);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(700, 30);
			this.panel4.TabIndex = 6;
			// 
			// cbCustomerProgram
			// 
			this.cbCustomerProgram.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCustomerProgram.Location = new System.Drawing.Point(485, 5);
			this.cbCustomerProgram.Name = "cbCustomerProgram";
			this.cbCustomerProgram.Size = new System.Drawing.Size(215, 20);
			this.cbCustomerProgram.TabIndex = 8;
			this.cbCustomerProgram.SelectedIndexChanged += new System.EventHandler(this.cbCustomerProgram_SelectedIndexChanged);
			// 
			// tbItemsInGroup
			// 
			this.tbItemsInGroup.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.tbItemsInGroup.Location = new System.Drawing.Point(85, 5);
			this.tbItemsInGroup.Name = "tbItemsInGroup";
			this.tbItemsInGroup.Size = new System.Drawing.Size(75, 20);
			this.tbItemsInGroup.TabIndex = 6;
			this.tbItemsInGroup.TextChanged += new System.EventHandler(this.tbItemsInGroup_TextChanged);
			this.tbItemsInGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbItemsInGroup_KeyDown);
			this.tbItemsInGroup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbItemsInGroup_KeyPress);
			// 
			// tbCustomerProgram
			// 
			this.tbCustomerProgram.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.tbCustomerProgram.Location = new System.Drawing.Point(280, 5);
			this.tbCustomerProgram.Name = "tbCustomerProgram";
			this.tbCustomerProgram.Size = new System.Drawing.Size(183, 20);
			this.tbCustomerProgram.TabIndex = 7;
			this.tbCustomerProgram.TextChanged += new System.EventHandler(this.tbCustomerProgram_TextChanged);
			this.tbCustomerProgram.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCustomerProgram_KeyDown);
			this.tbCustomerProgram.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCustomerProgram_KeyPress);
			this.tbCustomerProgram.Leave += new System.EventHandler(this.tbCustomerProgram_Leave);
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label6.Location = new System.Drawing.Point(165, 5);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(116, 17);
			this.label6.TabIndex = 4;
			this.label6.Text = "Customer Program";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(5, 7);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(75, 15);
			this.label8.TabIndex = 0;
			this.label8.Text = "Items in set";
			// 
			// btnAutoCreateBatch
			// 
			this.btnAutoCreateBatch.BackColor = System.Drawing.SystemColors.Control;
			this.btnAutoCreateBatch.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAutoCreateBatch.Location = new System.Drawing.Point(515, 80);
			this.btnAutoCreateBatch.Name = "btnAutoCreateBatch";
			this.btnAutoCreateBatch.Size = new System.Drawing.Size(105, 20);
			this.btnAutoCreateBatch.TabIndex = 12;
			this.btnAutoCreateBatch.Text = "Create Full Set";
			this.btnAutoCreateBatch.UseVisualStyleBackColor = false;
			this.btnAutoCreateBatch.Click += new System.EventHandler(this.btnAutoCreateBatch_Click);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.dataGridView1);
			this.tabPage2.Location = new System.Drawing.Point(4, 21);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(733, 453);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Excel Files";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(4, 3);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(726, 447);
			this.dataGridView1.TabIndex = 0;
			// 
			// btnWrong
			// 
			this.btnWrong.BackColor = System.Drawing.Color.LightPink;
			this.btnWrong.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.btnWrong.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnWrong.Location = new System.Drawing.Point(5, 650);
			this.btnWrong.Name = "btnWrong";
			this.btnWrong.Size = new System.Drawing.Size(120, 20);
			this.btnWrong.TabIndex = 9;
			this.btnWrong.Text = "Something Wrong";
			this.btnWrong.UseVisualStyleBackColor = false;
			this.btnWrong.Visible = false;
			this.btnWrong.Click += new System.EventHandler(this.btnWrong_Click);
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "");
			this.imageList1.Images.SetKeyName(1, "");
			this.imageList1.Images.SetKeyName(2, "");
			this.imageList1.Images.SetKeyName(3, "");
			this.imageList1.Images.SetKeyName(4, "");
			this.imageList1.Images.SetKeyName(5, "");
			this.imageList1.Images.SetKeyName(6, "");
			this.imageList1.Images.SetKeyName(7, "");
			this.imageList1.Images.SetKeyName(8, "");
			this.imageList1.Images.SetKeyName(9, "");
			this.imageList1.Images.SetKeyName(10, "");
			this.imageList1.Images.SetKeyName(11, "");
			this.imageList1.Images.SetKeyName(12, "");
			this.imageList1.Images.SetKeyName(13, "");
			this.imageList1.Images.SetKeyName(14, "");
			this.imageList1.Images.SetKeyName(15, "");
			// 
			// imageList2
			// 
			this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
			this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList2.Images.SetKeyName(0, "");
			this.imageList2.Images.SetKeyName(1, "");
			this.imageList2.Images.SetKeyName(2, "");
			this.imageList2.Images.SetKeyName(3, "");
			this.imageList2.Images.SetKeyName(4, "");
			this.imageList2.Images.SetKeyName(5, "");
			this.imageList2.Images.SetKeyName(6, "");
			this.imageList2.Images.SetKeyName(7, "");
			this.imageList2.Images.SetKeyName(8, "");
			this.imageList2.Images.SetKeyName(9, "");
			this.imageList2.Images.SetKeyName(10, "");
			this.imageList2.Images.SetKeyName(11, "");
			this.imageList2.Images.SetKeyName(12, "");
			this.imageList2.Images.SetKeyName(13, "");
			this.imageList2.Images.SetKeyName(14, "");
			this.imageList2.Images.SetKeyName(15, "");
			// 
			// btnDoneBag
			// 
			this.btnDoneBag.BackColor = System.Drawing.SystemColors.Control;
			this.btnDoneBag.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.btnDoneBag.Location = new System.Drawing.Point(595, 650);
			this.btnDoneBag.Name = "btnDoneBag";
			this.btnDoneBag.Size = new System.Drawing.Size(120, 20);
			this.btnDoneBag.TabIndex = 9;
			this.btnDoneBag.Text = "Done With the Bag";
			this.btnDoneBag.UseVisualStyleBackColor = false;
			this.btnDoneBag.Click += new System.EventHandler(this.btnDoneBag_Click);
			// 
			// btnDepartureSettings
			// 
			this.btnDepartureSettings.BackColor = System.Drawing.SystemColors.Control;
			this.btnDepartureSettings.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDepartureSettings.BackgroundImage")));
			this.btnDepartureSettings.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.btnDepartureSettings.Location = new System.Drawing.Point(570, 5);
			this.btnDepartureSettings.Name = "btnDepartureSettings";
			this.btnDepartureSettings.Size = new System.Drawing.Size(135, 20);
			this.btnDepartureSettings.TabIndex = 10;
			this.btnDepartureSettings.Text = "Departure Settings";
			this.btnDepartureSettings.UseVisualStyleBackColor = false;
			this.btnDepartureSettings.Visible = false;
			this.btnDepartureSettings.Click += new System.EventHandler(this.btnDepartureSettings_Click);
			// 
			// btnSaveNumberOfItemsInspected
			// 
			this.btnSaveNumberOfItemsInspected.Location = new System.Drawing.Point(100, 650);
			this.btnSaveNumberOfItemsInspected.Name = "btnSaveNumberOfItemsInspected";
			this.btnSaveNumberOfItemsInspected.Size = new System.Drawing.Size(170, 20);
			this.btnSaveNumberOfItemsInspected.TabIndex = 13;
			this.btnSaveNumberOfItemsInspected.Text = "Save #  Of Inspected Items";
			this.btnSaveNumberOfItemsInspected.Click += new System.EventHandler(this.btnSaveNumberOfItemsInspected_Click);
			// 
			// btnOldNumber
			// 
			this.btnOldNumber.BackColor = System.Drawing.Color.LightSteelBlue;
			this.btnOldNumber.Enabled = false;
			this.btnOldNumber.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.btnOldNumber.Location = new System.Drawing.Point(455, 650);
			this.btnOldNumber.Name = "btnOldNumber";
			this.btnOldNumber.Size = new System.Drawing.Size(130, 20);
			this.btnOldNumber.TabIndex = 15;
			this.btnOldNumber.Text = "Old Number";
			this.btnOldNumber.UseVisualStyleBackColor = false;
			this.btnOldNumber.Click += new System.EventHandler(this.btnOldNumber_Click);
			// 
			// tbOldNumbers
			// 
			this.tbOldNumbers.Location = new System.Drawing.Point(390, 650);
			this.tbOldNumbers.Name = "tbOldNumbers";
			this.tbOldNumbers.Size = new System.Drawing.Size(55, 20);
			this.tbOldNumbers.TabIndex = 16;
			this.tbOldNumbers.Visible = false;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(285, 655);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(100, 15);
			this.label10.TabIndex = 17;
			this.label10.Text = "Old ## to Add ->";
			this.label10.Visible = false;
			// 
			// txt_XMLFile
			// 
			this.txt_XMLFile.Location = new System.Drawing.Point(487, 72);
			this.txt_XMLFile.Name = "txt_XMLFile";
			this.txt_XMLFile.Size = new System.Drawing.Size(186, 20);
			this.txt_XMLFile.TabIndex = 22;
			// 
			// bcItem
			// 
			this.bcItem.Location = new System.Drawing.Point(5, 5);
			this.bcItem.Name = "bcItem";
			this.bcItem.Size = new System.Drawing.Size(300, 25);
			this.bcItem.TabIndex = 18;
			this.bcItem.CodeEntered += new System.EventHandler(this.bcItem_CodeEntered);
			this.bcItem.Enter += new System.EventHandler(this.bcItem_Enter);
			// 
			// bcfItem
			// 
			this.bcfItem.DigitsQuantity = 50;
			this.bcfItem.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.bcfItem.IsRequired = true;
			this.bcfItem.IsVariable = false;
			this.bcfItem.Location = new System.Drawing.Point(5, 5);
			this.bcfItem.Name = "bcfItem";
			this.bcfItem.Size = new System.Drawing.Size(285, 20);
			this.bcfItem.TabIndex = 12;
			this.bcfItem.CodeEntered += new System.EventHandler(this.barCodeField1_CodeEntered);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// Itemizn1Form
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
			this.ClientSize = new System.Drawing.Size(955, 695);
			this.Controls.Add(this.txtXLSFile);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.btnItmzFromXLS);
			this.Controls.Add(this.bcItem);
			this.Controls.Add(this.tbOldNumbers);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.statusBar1);
			this.Controls.Add(this.btnOldNumber);
			this.Controls.Add(this.btnSaveNumberOfItemsInspected);
			this.Controls.Add(this.btnWrong);
			this.Controls.Add(this.bcfItem);
			this.Controls.Add(this.btnDoneBag);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.lbVendorInfo);
			this.Controls.Add(this.lbCustomerName);
			this.Controls.Add(this.tabGroup);
			this.Controls.Add(this.btnDepartureSettings);
			this.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Itemizn1Form";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Itemizing part 1";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Itemizn1Form_Closing);
			this.Closed += new System.EventHandler(this.Itemizn1Form_Closed);
			this.Load += new System.EventHandler(this.Itemizn1Form_Load);
			this.TextChanged += new System.EventHandler(this.tbItemsInGroup_TextChanged);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.tabGroup.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgItemsSet)).EndInit();
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		/*		[STAThread]
				static void Main() 
				{
					Application.Run(new Itemizn1Form());
				}
		*/

		#endregion Generated

		public Itemizn1Form(int level)
		{
			accessLevel = level; // security access level
								 //
								 // Required for Windows Form Designer support
								 //
			InitializeComponent();
			Initialize();

			this.Text = Service.sProgramTitle + "Itemizing/Part 1";
			//bcItem_enter(this, System.EventArgs.Empty);
		}

		public void Initialize()
		{
			CreateMainDataSet();
			txt_XMLFile.Text = "";
			sGroup = "";
			//dsDatafromXML = new DataSet();
			dsBatchCPItemSet = new DataSet(); // dataset for total itemizing
			Client.MyActivePrinter = "";
			Client.MyActiveReportName = "";
			//Client.KillOpenExcel();
			tbItemsInGroup.Enabled = false;
			tbTotalItemsInSet.Text = "0";
			tbItemsInspected.Text = "";
			tbItemsNotAdded.Text = "";
			tbOldNumbers.Text = "";
			//cbCustomerProgram.Text = "[Select Customer Program]";
			cbCustomerProgram.SelectedIndex = -1;

			cmstrategy = CMStrategy.CMStrategyFactory.CreateCMStrategy(accessLevel);
			//			Service.GetItemizn_MeasureUnits(dsMainDataSet);
			//
			//			DataTable dtItems = dsMainDataSet.Tables.Add("Items");
			//			dtItems.Columns.Add("runningN");
			//			dtItems.Columns.Add("lotN");
			//			dtItems.Columns.Add("ParNo");
			//			dtItems.Columns.Add("prevN");
			//			dtItems.Columns.Add("weight");
			//			dtItems.Columns.Add("weightUnitId");
			//			dtItems.Columns.Add("customerWeight");
			//			dtItems.Columns.Add("customerWeightUnitId");
			//			dtItems.Columns.Add("SetID");

			DataTable dtBatchCP = dsBatchCPItemSet.Tables.Add("SetData");
			dtBatchCP.Columns.Add("BatchMemoID");
			dtBatchCP.Columns.Add("BatchMemoName");
			dtBatchCP.Columns.Add("nItemsInSet");
			dtBatchCP.Columns.Add("ItemTypeId");
			dtBatchCP.Columns.Add("CPName");
			dtBatchCP.Columns.Add("CustomerProgramId");
			dtBatchCP.Columns.Add("CPOfficeID_CPID");
			dtBatchCP.Columns.Add("SetID");
			dtBatchCP.Columns.Add("ItemTypeName");
			dsBatchCPItemSet.Tables["SetData"].RowDeleted += new System.Data.DataRowChangeEventHandler(BatchDataTable_Deleted);
			DataView myView = new DataView(dsBatchCPItemSet.Tables[0]);
			myView.AllowNew = true;
			myView.AllowEdit = false;
			myView.AllowDelete = true;
			InitBatchDataGrid(dsBatchCPItemSet.Tables[0].TableName);
			dgItemsSet.SetDataBinding(myView, "");

			btnClearSet_Click(this, System.EventArgs.Empty);

			wcInspected.Initialize(dsMainDataSet.Tables["MeasureUnits"].DefaultView);
			itemPanel1.Initialize();

			DataTable dt = Service.GetItemizn1_ItemsLibrary();
			itemPanel1.InitializeLibrary(dt);
			bAutoCreateBatch = false;
			setState("wait for scan");
			bLoading = true;

			rbBatchLabelsPrint.Checked = true;
			rbItemLabelsRegular.Checked = true;
			rbSelectRealItem.Checked = true;
		}

		private void CreateMainDataSet()
		{
			dsMainDataSet = new DataSet(); // main dataset
										   //			cmstrategy = CMStrategy.CMStrategyFactory.CreateCMStrategy(accessLevel);
			Service.GetItemizn_MeasureUnits(dsMainDataSet);

			DataTable dtItems = dsMainDataSet.Tables.Add("Items");
			dtItems.Columns.Add("runningN");
			dtItems.Columns.Add("lotN");
			dtItems.Columns.Add("ParNo");
			dtItems.Columns.Add("prevN");
			dtItems.Columns.Add("weight");
			dtItems.Columns.Add("weightUnitId");
			dtItems.Columns.Add("customerWeight");
			dtItems.Columns.Add("customerWeightUnitId");
			dtItems.Columns.Add("SetID");

		}

		private void BatchDataTable_Deleted(object sender, System.Data.DataRowChangeEventArgs e)
		{
			if (bLoading)
			{
				try
				{
					int iItemsInSet = 0;
					dsBatchCPItemSet.Tables[0].AcceptChanges();
					foreach (DataRow dr in dsBatchCPItemSet.Tables[0].Rows)
					{
						iItemsInSet = iItemsInSet + Convert.ToInt16(dr["nItemsInSet"].ToString());
					}
					tbTotalItemsInSet.Text = iItemsInSet.ToString();

					int iItemsToAdd = Convert.ToInt16(tbItemsInspected.Text) - Convert.ToInt16(lbItemsItemized.Text) - iItemsInSet;
					tbItemsNotAdded.Text = iItemsToAdd.ToString();
					tbOldNumbers.Text = iItemsToAdd.ToString();

					switch (dsBatchCPItemSet.Tables[0].Rows.Count)
					{
						case 0:
							btnCreateGroup.Enabled = false;
							//btnOldNumber.Enabled = false;
							btnClearSet_Click(this, System.EventArgs.Empty);
							cbMemoNumber.SelectedIndex = 0;
							break;

						case 1:
							btnCreateGroup.Enabled = true;
							btnOldNumber.Enabled = true;
							SetSingleMemoIndex(); //cbMemoNumber.SelectedIndex = 0;
							break;

						default:
							btnCreateGroup.Enabled = false;
							//btnOldNumber.Enabled = false;
							SetSingleMemoIndex(); //cbMemoNumber.SelectedIndex = 0;
							break;
					}

					if (dsBatchCPItemSet.Tables[0].Rows.Count > 0)
					{
						int iSetID = 1;
						foreach (DataRow dr in dsBatchCPItemSet.Tables[0].Rows)
						{
							dr["SetID"] = iSetID;
							iSetID++;
						}
					}
					dgItemsSet.Refresh();
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message + " .Can't delete row in control");
				}
			}
		}

		private void setState(string state)
		{
			if (accessLevel < 2)
			{
				bcItem.Enabled = false;
				bcfItem.Enabled = false;
				tbItemsInspected.Enabled = false;
				tbMemoNumber.Enabled = false;
				//by vetal_242 10.02.2006
				cbMemoNumber.Enabled = true;
				wcInspected.Enabled = false;
				tbBatchesList.Enabled = false;
				tabGroup.Enabled = false;
				btnItmzFromXLS.Enabled = false;

				btnStartGrouping.Enabled = false;
				btnStartGrouping.BackColor = SystemColors.Control;
				btnCreateGroup.Enabled = false;
				btnAutoCreateBatch.Enabled = false;
				btnAddToList.Enabled = false;
				btnClearSet.Enabled = false;
				btnCreateGroup.BackColor = SystemColors.Control;
				btnDoneBag.Enabled = false;
				btnDepartureSettings.Enabled = false;
				canClose = true;
				cbEditCP.Enabled = false;
				btnSaveNumberOfItemsInspected.Visible = false;
				btnOldNumber.Enabled = false;
			}

			else
			{
				if (accessLevel >= 3)
				{
					btnSaveNumberOfItemsInspected.Visible = true;
				}
				else
				{
					btnSaveNumberOfItemsInspected.Visible = false;
				}

				this.Enabled = true;
				if (state == "wait for scan")
				{
					canClose = true;
					btnDepartureSettings.Enabled = false;
					////bcfItem.Text = "";
					///
					bcItem.Enabled = true;
					bcItem.Select();
					bcfItem.Enabled = true;
					bcfItem.Select();
					tbItemsInspected.Enabled = false;
					tbMemoNumber.Text = "";
					tbMemoNumber.Enabled = false;
					cbMemoNumber.Enabled = false;
					//tbItemsInspected.Text = "";
					wcInspected.Enabled = false;
					wcInspected.Weight = "";
					tbBatchesList.Enabled = false;
					tbBatchesList.Text = "";
					tbItemsInGroup.Text = "";
					tbCustomerProgram.Text = "";
					lbCustomerName.Text = "Customer Name";
					lbVendorInfo.Text = "Chain/Vendor Info";
					lbItemsNotInspected.Text = "";
					lbWeightNotInspected.Text = "";

					tabGroup.Enabled = false;
					btnItmzFromXLS.Enabled = false;

					btnStartGrouping.Enabled = false;
					btnStartGrouping.BackColor = SystemColors.Control;

					btnCreateGroup.Enabled = false;
					btnAutoCreateBatch.Enabled = false;
					btnAddToList.Enabled = false;
					btnClearSet.Enabled = false;
					btnCreateGroup.BackColor = SystemColors.Control;
					btnDoneBag.Enabled = false;
					cbEditCP.Checked = false;
					cbEditCP.Enabled = false;
					FormState = state;
					btnOldNumber.Enabled = false;
				}
				if (state == "before start divisioning")
				{
					if (FormState == "wait for scan")
					{
						canClose = true;
						btnDepartureSettings.Enabled = true;
						bcfItem.Enabled = true;
						bcItem.Enabled = true;
						//wcInspected.Enabled = true;
						tbBatchesList.Enabled = false;
						tabGroup.Enabled = false;
						btnItmzFromXLS.Enabled = false;

						btnStartGrouping.Enabled = true;
						btnStartGrouping.BackColor = Color.LightSteelBlue;
						btnStartGrouping.Focus();
						btnCreateGroup.Enabled = false;
						btnAutoCreateBatch.Enabled = false;
						btnAddToList.Enabled = false;
						btnClearSet.Enabled = false;
						btnCreateGroup.BackColor = SystemColors.Control;
						btnDoneBag.Enabled = false;
						cbEditCP.Enabled = true;
						FormState = state;
						btnOldNumber.Enabled = false;
					}
				}
				if (state == "divisioning")
				{
					if (FormState == "before start divisioning" || FormState == "create division" || FormState == "item type selected")
					{
						canClose = false;
						btnDepartureSettings.Enabled = false;
						//tbItemsInspected.Enabled = false;
						//wcInspected.Enabled = false;
						bcfItem.Enabled = false;
						bcItem.Enabled = false;
						tbBatchesList.Enabled = true;
						tabGroup.Enabled = true;
						btnItmzFromXLS.Enabled = false;
						btnStartGrouping.Enabled = false;
						btnStartGrouping.BackColor = SystemColors.Control;
						//tbItemsInGroup.Focus();
						//tbItemsInGroup.SelectAll();
						btnCreateGroup.Enabled = false;
						btnAutoCreateBatch.Enabled = false;
						btnAddToList.Enabled = false;
						btnClearSet.Enabled = false;
						btnCreateGroup.BackColor = SystemColors.Control;
						btnDoneBag.Enabled = false;
						FormState = state;
						btnOldNumber.Enabled = false;
					}
				}
				if (state == "item type selected")
				{
					if (FormState == "divisioning" || FormState == "item type selected")
					{
						canClose = false;
						btnDepartureSettings.Enabled = false;
						FormState = state;
						bcfItem.Enabled = false;
						bcItem.Enabled = false;
						tbBatchesList.Enabled = true;
						tabGroup.Enabled = true;
						btnItmzFromXLS.Enabled = true;
						btnStartGrouping.Enabled = false;
						btnStartGrouping.BackColor = SystemColors.Control;
						btnDoneBag.Enabled = false;
						if (tbItemsInGroup.Text.Length > 0 && Convert.ToInt32(tbItemsInGroup.Text) > 0 && itemPanel1.ItemId != null)
						{
							btnCreateGroup.Enabled = true;
							if (isCPvalidatedForGlobal)
							{
								btnAutoCreateBatch.Enabled = true;
								btnAddToList.Enabled = true;
								btnClearSet.Enabled = true;
							}
							btnCreateGroup.BackColor = Color.LightSteelBlue;
							btnOldNumber.Enabled = true;
						}
						else
						{
							btnCreateGroup.Enabled = false;
							btnAutoCreateBatch.Enabled = false;
							btnAddToList.Enabled = false;
							btnClearSet.Enabled = false;
							btnOldNumber.Enabled = false;
							btnCreateGroup.BackColor = SystemColors.Control;
							setState("divisioning");
						}
					}
					if (FormState == "create division")
					{
						canClose = false;
						btnDepartureSettings.Enabled = false;
						FormState = state;
						tbItemsInspected.Enabled = false;
						btnItmzFromXLS.Enabled = true;
						wcInspected.Enabled = false;
						if (tbItemsInGroup.Text.Length > 0 && Convert.ToInt32(tbItemsInGroup.Text) > 0 && itemPanel1.ItemId != null)
						{
							btnCreateGroup.Enabled = true;
							if (isCPvalidatedForGlobal)
							{
								btnAutoCreateBatch.Enabled = true;
								btnAddToList.Enabled = true;
								btnClearSet.Enabled = true;
							}
							btnCreateGroup.BackColor = Color.LightSteelBlue;
						}
						else
						{
							btnCreateGroup.Enabled = false;
							btnAutoCreateBatch.Enabled = false;
							btnAddToList.Enabled = false;
							btnClearSet.Enabled = false;
							btnCreateGroup.BackColor = SystemColors.Control;
							setState("divisioning");
						}
					}
				}
				if (state == "create division")
				{
					if (FormState == "item type selected")
					{
						canClose = false;
						btnDepartureSettings.Enabled = false;
						tbItemsInspected.Enabled = false;
						wcInspected.Enabled = false;
						FormState = state;
					}
				}
				if (state == "end of bag")
				{
					canClose = true;
					bcfItem.Enabled = false;
					bcItem.Enabled = false;
					tbBatchesList.Enabled = false;
					tabGroup.Enabled = false;
					btnItmzFromXLS.Enabled = false;
					btnStartGrouping.Enabled = false;
					btnStartGrouping.BackColor = SystemColors.Control;
					btnCreateGroup.Enabled = false;
					btnAutoCreateBatch.Enabled = false;
					btnAddToList.Enabled = false;
					btnClearSet.Enabled = false;
					btnCreateGroup.BackColor = SystemColors.Control;
					btnDoneBag.Enabled = true;
					tbMemoNumber.Enabled = false;
					cbMemoNumber.Enabled = false;
					btnDoneBag.Focus();
					FormState = state;
				}
				if (state == "old numbers")
				{
					canClose = true;
					btnOldNumber.Enabled = true;
				}
			}
			btnOldNumber.Enabled = true;
			formState = state;
		}

		private void fillItemsInspected()
		{
			try
			{
			DataTable dtEntryBatch = dsMainDataSet.Tables["EntryBatch"];
			int iItemsNotInspected = 0; //Convert.ToInt32(lbItemsNotInspected.Text);
			int iItemsInspected = 0;
			int iItemsItemized = 0;

			if (dtEntryBatch.Rows[0]["CustomerName"] != DBNull.Value)
				lbCustomerName.Text = dtEntryBatch.Rows[0]["CustomerName"].ToString();
			else
				lbCustomerName.Text = "";

			if (dtEntryBatch.Rows[0]["VendorName"] != DBNull.Value)
				lbVendorInfo.Text = dtEntryBatch.Rows[0]["VendorName"].ToString();
			else
				lbVendorInfo.Text = "";

			iItemsItemized = 0;
			if (dtEntryBatch.Rows[0]["EnteredIQ"] != DBNull.Value) iItemsItemized = Convert.ToInt32(dtEntryBatch.Rows[0]["EnteredIQ"]);
			lbItemsItemized.Text = iItemsItemized.ToString();

			iItemsInspected = 0;
			if (dtEntryBatch.Rows[0]["IQInspected"] != DBNull.Value)
			{
				iItemsInspected = Convert.ToInt32(dtEntryBatch.Rows[0]["IQInspected"]);
				tbItemsInspected.Text = iItemsInspected.ToString();

				tbItemsInspected.Enabled = false;
				//tbMemoNumber.Text = dtEntryBatch.Rows[1]["MemoNumber"].ToString();
				tbMemoNumber.Enabled = false;
				//by vetal_242 10.02.2006
				cbMemoNumber.Enabled = true;
				if (accessLevel >= 3)
				{
					//tbItemsInspected.Text = dtEntryBatch.Rows[0]["IQInspected"].ToString();
					//label10.Text = dtEntryBatch.Rows[0]["EnteredIQ"].ToString();
					tbItemsInspected.Enabled = true;
					tbMemoNumber.Enabled = true;
					cbMemoNumber.Enabled = true;
					btnClearSet_Click(this, System.EventArgs.Empty);
				}
			}
			else
			{
				tbItemsInspected.Text = "0";
				tbItemsInspected.Enabled = true;
				tbMemoNumber.Text = "";
				tbMemoNumber.Enabled = true;
				cbMemoNumber.Enabled = true;
			}

			iItemsNotInspected = 0;
			if (dtEntryBatch.Rows[0]["IQNotInspected"] != DBNull.Value) iItemsNotInspected = Convert.ToInt32(dtEntryBatch.Rows[0]["IQNotInspected"]);
			lbItemsNotInspected.Text = iItemsNotInspected.ToString();

			if (dtEntryBatch.Rows[0]["TWInspected"] != DBNull.Value)
			{
				wcInspected.Weight = dtEntryBatch.Rows[0]["TWInspected"].ToString();
				wcInspected.MeasureUnitID = dtEntryBatch.Rows[0]["TWInspectedMeasureUnitId"].ToString();
				wcInspected.Enabled = false;
			}
			else
			{
				wcInspected.Weight = "";
				wcInspected.Enabled = true;
			}

			if ((dtEntryBatch.Rows[0]["TWNotInspected"] != DBNull.Value) & (Convert.ToInt16(dtEntryBatch.Rows[0]["TWNotInspected"]) != 0))
			{
				lbWeightNotInspected.Text = dtEntryBatch.Rows[0]["TWNotInspected"].ToString()
					+ " " + dsMainDataSet.Tables["MeasureUnits"].Select("MeasureUnitID = " + dtEntryBatch.Rows[0]["TWNotInspectedMeasureUnitId"].ToString())[0]["MeasureUnitName"].ToString();
			}
			else
			{
				lbWeightNotInspected.Text = "";
			}
			//lbItemsNotInspected.Text = 
			try
			{
				itemPanel1.InitializeMRU(
					dsMainDataSet.Tables["EntryBatch"].Rows[0]["CustomerOfficeID"].ToString(),
					dsMainDataSet.Tables["EntryBatch"].Rows[0]["CustomerID"].ToString(),
					dsMainDataSet.Tables["EntryBatch"].Rows[0]["VendorOfficeID"].ToString(),
					dsMainDataSet.Tables["EntryBatch"].Rows[0]["VendorID"].ToString()
					);
			}
			catch { }
		 }

		catch(Exception ex)
			{
				var a = ex.Message;
			}
		}

		#region EventHandlers

		private void btnStartGrouping_Click(object sender, System.EventArgs e)
		{
			try
			{

				if (Convert.ToInt32(dsMainDataSet.Tables["EntryBatch"].Rows[0]["EnteredIQ"]) == 0 & Convert.ToInt32(dsMainDataSet.Tables["EntryBatch"].Rows[0]["IQInspected"]) == 0)
				{
					setState("divisioning");
					throw new Exception("Order #: " + dsMainDataSet.Tables["EntryBatch"].Rows[0]["GroupCode"].ToString() + " has 0 inspected items.");
				}

				if (dsMainDataSet.Tables["EntryBatch"].Rows[0]["IQInspected"] != DBNull.Value)
				{
					if (Convert.ToInt32(dsMainDataSet.Tables["EntryBatch"].Rows[0]["EnteredIQ"]) == Convert.ToInt32(dsMainDataSet.Tables["EntryBatch"].Rows[0]["IQInspected"]))
					{
						setState("divisioning");
						//setState("wait for scan");
						throw new Exception("Order #: " + dsMainDataSet.Tables["EntryBatch"].Rows[0]["GroupCode"].ToString() + " has inspected number of items already.");
					}
				}

				try
				{
					if (Convert.ToInt32(tbItemsInspected.Text) > 0)
					{ }
					else
					{
						btnOldNumber.Enabled = true;
						throw new Exception("Please enter inspected number of items.");
					}
				}
				catch
				{
					tbItemsInspected.Focus();
					tbItemsInspected.SelectAll();
					throw new Exception("Please enter inspected number of items.");
				}
				int iItemsToAdd = Convert.ToInt16(tbItemsInspected.Text) - Convert.ToInt32(dsMainDataSet.Tables["EntryBatch"].Rows[0]["EnteredIQ"]);
				tbItemsNotAdded.Text = iItemsToAdd.ToString();
				tbOldNumbers.Text = iItemsToAdd.ToString();
				tbTotalItemsInSet.Text = "0";

				setState("divisioning");
				btnOldNumber.Enabled = true;

			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message);
			}
		}

		private void InitBatchDataGrid(string mappingName)
		{
			dgItemsSet.SetDataBinding(null, "");
			string[] columnNames = new string[]
					{
						"BatchMemoName", "nItemsInSet", "CPName", "SetID"
					};

			string[] headerText = new string[]
					{
						"Memo", "Items In Set", "Customer Program", "Set #"
					};

			int[] columnWidth = new int[]
					{
						120, 70, 110, 60
					};

			DataGridTableStyle tableStyle = new DataGridTableStyle();
			tableStyle.MappingName = mappingName;

			for (int i = 0; i < columnNames.Length; i++)
			{
				DataGridTextBoxColumn tbColumn = new DataGridTextBoxColumn();

				tbColumn.MappingName = columnNames[i];
				tbColumn.HeaderText = headerText[i];
				tbColumn.Width = columnWidth[i];
				//tbColumn.ReadOnly = true;
				tbColumn.NullText = "";
				tbColumn.Alignment = HorizontalAlignment.Left;

				tableStyle.GridColumnStyles.Add(tbColumn);
			}

			dgItemsSet.TableStyles.Clear();
			dgItemsSet.TableStyles.Add(tableStyle);
		}

		private void btnCreateGroup_Click(object sender, System.EventArgs e)
		{
			bAutoCreateBatch = false;
			try
			{
				if (dsBatchCPItemSet.Tables[0].Rows.Count == 0 && tbItemsInGroup.Text.Trim() != "")
					btnAddToList_Click(this, System.EventArgs.Empty);

				int itemsInGroup = Convert.ToInt32(dsBatchCPItemSet.Tables[0].Rows[0]["nItemsInSet"]);

				if (cbMemoNumber.SelectedIndex == -1 && cbMemoNumber.Text != "")
				{
					throw new Exception("Wrong MemoNumber");
				}

				if (cbMemoNumber.Text == "[none]")
				{
					if (MessageBox.Show("Memo info is missing.\r\nIs it OK to itemize this batch?",
						"Missing Memo info", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) == DialogResult.No)
					{
						return;
					}
				}

				DataRow drEntryBatchRow = dsMainDataSet.Tables["EntryBatch"].Rows[0];

				if (wcInspected.Weight != null && wcInspected.Weight != "")
				{
					drEntryBatchRow["TWInspected"] = Convert.ChangeType(wcInspected.Weight, dsMainDataSet.Tables["EntryBatch"].Columns["TWInspected"].DataType);
					drEntryBatchRow["TWInspectedMeasureUnitId"] = Convert.ChangeType(wcInspected.MeasureUnitID, dsMainDataSet.Tables["EntryBatch"].Columns["TWInspectedMeasureUnitId"].DataType);
				}
				else
				{
					drEntryBatchRow["TWInspected"] = DBNull.Value;
					drEntryBatchRow["TWInspectedMeasureUnitId"] = DBNull.Value;
				}

				try
				{
					if (Convert.ToInt32(tbItemsInspected.Text) > 0)
					{
						drEntryBatchRow["IQInspected"] = Convert.ChangeType(tbItemsInspected.Text, dsMainDataSet.Tables["EntryBatch"].Columns["IQInspected"].DataType);
					}
					else
						throw new Exception("Please enter inspected number of items.");
				}
				catch
				{
					tbItemsInspected.Focus();
					tbItemsInspected.SelectAll();
					throw new Exception("Please enter inspected number of items.");
				}

				if (drEntryBatchRow["EnteredIQ"] == DBNull.Value) drEntryBatchRow["EnteredIQ"] = 0;
				//check number of items in the batch
				if (Convert.ToInt32(drEntryBatchRow["EnteredIQ"]) + itemsInGroup > Convert.ToInt32(tbItemsInspected.Text))
				{
					tbItemsInGroup.Focus();
					tbItemsInGroup.SelectAll();
					setState("wait for scan");
					throw new Exception("Group needs only " + (Convert.ToInt32(tbItemsInspected.Text) - Convert.ToInt32(dsMainDataSet.Tables["EntryBatch"].Rows[0]["EnteredIQ"])).ToString() + " items to reach inspected number of items.");
				}


				//				if( ! Service.GetItemizn_CustomerProgramExists(tbCustomerProgram.Text) )
				//				{
				//					tbCustomerProgram.Focus();
				//					tbCustomerProgram.SelectAll();
				//					throw new Exception("Can not find entered Customer Program.");
				//				}
				//////				DataTable dtCP = Service.GetItemizn_ItemTypeIdByCustomerProgramAndCustomer(
				//////					tbCustomerProgram.Text,
				//////					drEntryBatchRow["VendorOfficeID"].ToString(),
				//////					drEntryBatchRow["VendorID"].ToString(),
				//////					drEntryBatchRow["CustomerOfficeID"].ToString(),
				//////					drEntryBatchRow["CustomerID"].ToString());//Procedure dbo.spGetCustomerProgramByNameAndCustomer
				//////				if (dtCP.Rows.Count == 0)
				//////				{
				//////					tbCustomerProgram.Focus();
				//////					tbCustomerProgram.SelectAll();
				//////					throw new Exception("Can not find entered Customer Program.");	
				//////				}

				Itemizn2Form frm = new Itemizn2Form(accessLevel);
				//////				if(dtCP.Rows.Count>0 && itemPanel1.ItemId.ToString() == dtCP.Rows[0]["ItemTypeID"].ToString())
				//////				{
				//////					frm.CustomerProgram = tbCustomerProgram.Text;
				//////					frm.CustomerProgramId = dtCP.Rows[0]["CPOfficeID_CPID"].ToString();
				//////				}
				//////				else
				{
					//////					Service.GetItemizn_CustomerProgramExists(tbCustomerProgram.Text);
					try
					{
						//						DataTable dt = Service.GetItemizn_ItemTypeIdByCustomerProgramAndCustomer(
						//							tbCustomerProgram.Text,
						//							drEntryBatchRow["VendorOfficeID"].ToString(),
						//							drEntryBatchRow["VendorID"].ToString(),
						//							drEntryBatchRow["CustomerOfficeID"].ToString(),
						//							drEntryBatchRow["CustomerID"].ToString());
						//						if( dt.Rows.Count == 0 )
						//							throw new Exception();
						//						isCPvalidated = true;
						//						itemPanel1.SelectItemTypeById(dt.Rows[0]["ItemTypeID"].ToString(), dt.Rows[0]["ItemTypeGroupID"].ToString());
						//						isCPvalidated = false;
						frm.ISetID = Convert.ToInt16(dsBatchCPItemSet.Tables[0].Rows[0]["SetID"]);
						frm.CustomerProgram = dsBatchCPItemSet.Tables[0].Rows[0]["CPName"].ToString();
						frm.CustomerProgramId = dsBatchCPItemSet.Tables[0].Rows[0]["CPOfficeID_CPID"].ToString();//               dtCP.Rows[0]["CPOfficeID_CPID"].ToString();
					}
					catch (Exception exc)
					{
						MessageBox.Show(exc.Message);                       //if(itemPanel1.CustomerProgram == tbCustomerProgram.Text)
						{
							////						frm.CustomerProgram = tbCustomerProgram.Text;
							////						frm.CustomerProgramId = itemPanel1.CustomerProgramId;
						}
						//else
						{
							////						isCPvalidated = false;
							////						tbCustomerProgram.Focus();
							////						tbCustomerProgram.SelectAll();
							////						throw new Exception("Can not find entered Customer Program");
						}
					}
				}

				frm.lbCustomerName.Text = lbCustomerName.Text;
				frm.lbCustomerProgram.Text = dsBatchCPItemSet.Tables[0].Rows[0]["CPName"].ToString();
				frm.lbFullItemName.Text = itemPanel1.FullItemName;
				frm.pbItemPicture.Image = itemPanel1.ItemPicture;

				frm.ItemsInGroup = itemsInGroup;
				frm.ItemsTypeId = dsBatchCPItemSet.Tables[0].Rows[0]["ItemTypeId"].ToString(); //           itemPanel1.ItemId;
				setState("create division");
				//update entry batch
				Service.Itemizn1_EntryBatchUpdate(dsMainDataSet.Tables["EntryBatch"]);//Procedure dbo.spItemizingUpdateGroup
																					  //------------
				frm.ShowDialog(this);
				btnClearSet_Click(this, System.EventArgs.Empty);
				SetSingleMemoIndex(); //cbMemoNumber.SelectedIndex = 0;
				cbCustomerProgram.SelectedIndex = 0;
				bcItem_CodeEntered(this, System.EventArgs.Empty);
				//barCodeField1_CodeEntered(this, System.EventArgs.Empty);
				rbBatchLabelsPrint.Checked = true;
				rbItemLabelsRegular.Checked = true;
				rbSelectRealItem.Checked = true;
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message);
				btnDoneBag.Enabled = true;
				return;
			}

		}

		private void updateInspectedNumberOfItems(bool bNoMsgBox)
		{
			try
			{
				DataRow drEntryBatchRow = dsMainDataSet.Tables["EntryBatch"].Rows[0];
				try
				{
					if (Convert.ToInt32(tbItemsInspected.Text) > 0)
					{
						if (Convert.ToInt32(dsMainDataSet.Tables["EntryBatch"].Rows[0]["EnteredIQ"]) >= Convert.ToInt32(tbItemsInspected.Text))
							throw new Exception("Inspected items quantity must be greater than " + dsMainDataSet.Tables["EntryBatch"].Rows[0]["EnteredIQ"].ToString());
						drEntryBatchRow["IQInspected"] = Convert.ChangeType(tbItemsInspected.Text, dsMainDataSet.Tables["EntryBatch"].Columns["IQInspected"].DataType);
					}
					else
						throw new Exception("Please enter inspected number of items.");
				}
				catch (Exception exc)
				{
					tbItemsInspected.Focus();
					tbItemsInspected.SelectAll();
					throw new Exception(exc.Message);
				}
				Service.Itemizn1_EntryBatchUpdate(dsMainDataSet.Tables["EntryBatch"]);
				if (bNoMsgBox)
				{
					goto abc;
					MessageBox.Show("Inspected items # in order " + bcfItem.Text + " was updated to " + tbItemsInspected.Text, "Inspected Items Update");
					barCodeField1_CodeEntered(this, System.EventArgs.Empty);

					abc:
					{
						MessageBox.Show("Inspected items # in order " + bcItem.sGroupCode + " was updated to " + tbItemsInspected.Text, "Inspected Items Update");
						bcItem_CodeEntered(this, System.EventArgs.Empty);
					}

				}
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message);
				return;
			}
		}

		private void tbItemsInGroup_TextChanged(object sender, System.EventArgs e)
		{
			if (tbItemsInGroup.Enabled)
			{
				if (tbItemsInGroup.Text.Trim() != "")
					setState("item type selected");
				btnAutoCreateBatch.Enabled = false;
				if (dsBatchCPItemSet.Tables[0].Rows.Count > 0)
				{
					btnAutoCreateBatch.Enabled = true;
					btnClearSet.Enabled = true;
					btnCreateGroup.Enabled = true;
					btnOldNumber.Enabled = true;
					dgItemsSet.Enabled = true;
					btnAddToList.Enabled = true;
				}
			}
		}

		private void btnWrong_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show("Call Manager");
		}
		private void itemPanel3_Changed(object sender, System.EventArgs e)
		{
			////////			if(!isCPvalidated)
			////////				{
			////////					if(itemPanel1.Enabled) 
			////////					{
			////////					setState("item type selected");
			////////					string sCustomerProgram = null;
			////////
			////////					if(sCustomerProgram==null && itemPanel1.ItemId!=null)
			////////					{
			////////						sCustomerProgram = Service.GetItemizn_MRUCustomerProgram(dsMainDataSet.Tables["EntryBatch"], itemPanel1.ItemId);//Procedure dbo.spGetMRUCustomerProgram
			////////						if( sCustomerProgram!=null )
			////////						{
			////////							DataRow drEntryBatchRow = dsMainDataSet.Tables["EntryBatch"].Rows[0];
			////////
			////////							DataTable dt = Service.GetItemizn_ItemTypeIdByCustomerProgramAndCustomer(
			////////								sCustomerProgram,
			////////								drEntryBatchRow["VendorOfficeID"].ToString(),
			////////								drEntryBatchRow["VendorID"].ToString(),
			////////								drEntryBatchRow["CustomerOfficeID"].ToString(),
			////////								drEntryBatchRow["CustomerID"].ToString());
			////////							if( dt.Rows.Count != 0 )
			////////							{
			////////								if(dt.Rows[0]["Picture"]!=DBNull.Value)
			////////									itemPanel1.InitializePicture((Image)dt.Rows[0]["Picture"]);
			////////							}
			////////						}
			////////					}
			////////					if(sCustomerProgram==null)
			////////					{
			////////						itemPanel1.InitializePicture(itemPanel1.DefaultPicture);
			////////						sCustomerProgram = itemPanel1.CustomerProgram;
			////////					}
			////////					if(sCustomerProgram!=null)
			////////						tbCustomerProgram.Text = sCustomerProgram;
			////////				}
			////////			}
		}
		private void barCodeField1_CodeEntered(object sender, System.EventArgs e)
		{
			if (bcfItem.Text.Trim().IndexOf(".") > 4)
			{
				sGroup = bcfItem.Text.Trim().Substring(0, bcfItem.Text.Trim().IndexOf("."));
				LoadOrderData();
			}
		}

		public void LoadOrderData()
		{
			try
			{
				if (dsMainDataSet != null)
				{
					dsMainDataSet.Dispose();
					dsMainDataSet = null;
				}
				//				dsMainDataSet = new DataSet();
				CreateMainDataSet();
				//Service.GetItemizn1_EntryBatch(bcfItem.Value, dsMainDataSet);//Procedure dbo.spGetGroupByCode2
				//if(sGroup.IndexOf(".") > 0) sGroup = sGroup.Substring(0, sGroup.IndexOf("."));
				string sGroup = bcItem.sGroupCode;

				if (sGroup.Length > 4 && sGroup.Length < 7) bcItem.Text = bcItem.sGroupCode;
				else
				{
					bcItem.Text = "";
					throw new Exception("Order # " + sGroup + "does not exists. Please, scan again");
				}
				//sGroup = bcItem.sGroupCode;

				Service.GetItemizn1_EntryBatch(bcItem.sGroupCode, dsMainDataSet);//Procedure dbo.spGetGroupByCode3

				if (dsMainDataSet.Tables["EntryBatch"].Rows.Count == 0)
				{
					setState("wait for scan");
					throw new Exception("Order has wrong number. Please, scan again");
				}
				else
				{
					Service.SetDepartmentOfficeId(dsMainDataSet.Tables["EntryBatch"].Rows[0]["CustomerOfficeID"].ToString());
				}

				this.Text = Service.sProgramTitle + "Itemizing/Part 1 - Order #: " + dsMainDataSet.Tables["EntryBatch"].Rows[0]["GroupCode"];

				if (dsMainDataSet.Tables["EntryBatch"].Rows[0]["EnteredIQ"] == null) dsMainDataSet.Tables["EntryBatch"].Rows[0]["EnteredIQ"] = "0";
				if (dsMainDataSet.Tables["EntryBatch"].Rows[0]["IQInspected"] == null) dsMainDataSet.Tables["EntryBatch"].Rows[0]["IQInspected"] = "0";

				int EnteredIQ = Convert.ToInt32(dsMainDataSet.Tables["EntryBatch"].Rows[0]["EnteredIQ"]);
				int IQInspected = Convert.ToInt32(dsMainDataSet.Tables["EntryBatch"].Rows[0]["IQInspected"]);

				if (Convert.ToInt32(dsMainDataSet.Tables["EntryBatch"].Rows[0]["EnteredIQ"]) > Convert.ToInt32(dsMainDataSet.Tables["EntryBatch"].Rows[0]["IQInspected"]))
				{
					//tbItemsInspected.Text = lbItemsItemized.Text;
					dsMainDataSet.Tables["EntryBatch"].Rows[0]["IQInspected"] = Convert.ChangeType(dsMainDataSet.Tables["EntryBatch"].Rows[0]["EnteredIQ"], dsMainDataSet.Tables["EntryBatch"].Columns["IQInspected"].DataType);
					Service.Itemizn1_EntryBatchUpdate(dsMainDataSet.Tables["EntryBatch"]);
					//Service.GetItemizn1_EntryBatch(bcfItem.Value, dsMainDataSet);//Procedure dbo.spGetGroupByCode2
					Service.GetItemizn1_EntryBatch(bcItem.sGroupCode, dsMainDataSet);//Procedure dbo.spGetGroupByCode2
				}

				if (EnteredIQ == 0 & IQInspected == 0 & accessLevel < 3)
				{
					setState("wait for scan");
					throw new Exception("Order #: " + dsMainDataSet.Tables["EntryBatch"].Rows[0]["GroupCode"].ToString() + " has 0 inspected items.");
				}

				if (dsMainDataSet.Tables["EntryBatch"].Rows[0]["IQInspected"] != DBNull.Value && accessLevel < 3)
				{
					if (Convert.ToInt32(dsMainDataSet.Tables["EntryBatch"].Rows[0]["EnteredIQ"]) == Convert.ToInt32(dsMainDataSet.Tables["EntryBatch"].Rows[0]["IQInspected"]))
					{
						setState("wait for scan");
						throw new Exception("Order #: " + dsMainDataSet.Tables["EntryBatch"].Rows[0]["GroupCode"].ToString() + " has inspected number of items already.");
					}
				}

				//				if(Convert.ToInt32(dsMainDataSet.Tables["EntryBatch"].Rows[0]["EnteredIQ"]) > Convert.ToInt32(dsMainDataSet.Tables["EntryBatch"].Rows[0]["IQInspected"]))
				//				{
				//						//tbItemsInspected.Text = lbItemsItemized.Text;
				//						dsMainDataSet.Tables["EntryBatch"].Rows[0]["IQInspected"] = Convert.ChangeType(dsMainDataSet.Tables["EntryBatch"].Rows[0]["EnteredIQ"], dsMainDataSet.Tables["EntryBatch"].Columns["IQInspected"].DataType);
				//						Service.Itemizn1_EntryBatchUpdate(dsMainDataSet.Tables["EntryBatch"]);
				//						Service.GetItemizn1_EntryBatch(bcfItem.Value, dsMainDataSet);//Procedure dbo.spGetGroupByCode2
				//				}

				//				this.Text = Service.sProgramTitle + "Itemizing/Part 1 - Order #: " + dsMainDataSet.Tables["EntryBatch"].Rows[0]["GroupCode"];
				iServiceType = Convert.ToInt32(dsMainDataSet.Tables["EntryBatch"].Rows[0]["ServiceTypeID"]);

				fillItemsInspected();
				setState("before start divisioning");

				//by vetal_242 07.05.2006 
				dsMemoNumbers = Service.GetGroupMemoNumbers(dsMainDataSet.Tables["EntryBatch"].Rows[0]["GroupID"].ToString());//Procedure dbo.spGetGroupMemoNumber
				dsMemoNumbers.Tables[0].TableName = "MemoNumbers";

				//by vetal_242 25.09.2006
				DataRow drNone = dsMemoNumbers.Tables[0].NewRow();
				drNone["MemoNumberID"] = System.DBNull.Value;
				drNone["Name"] = "[none]";
				dsMemoNumbers.Tables[0].Rows.InsertAt(drNone, 0);

				cbMemoNumber.DataSource = dsMemoNumbers.Tables["MemoNumbers"];
				cbMemoNumber.DisplayMember = "Name";
				cbMemoNumber.ValueMember = "MemoNumberID";
				SetSingleMemoIndex();

				btnOldNumber.Enabled = false;
				string[] sIDc = dsMainDataSet.Tables["EntryBatch"].Rows[0]["CustomerOfficeID_CustomerID"].ToString().Split('_');
				DataSet dsTmp1 = new DataSet();
				switch (iServiceType)
				{
					case 7:
						dsTmp1.Tables.Add("CustomerProgramsPerCustomerDS");
						dsTmp1.Tables["CustomerProgramsPerCustomerDS"].Columns.Add(new DataColumn("CustomerOfficeID", Type.GetType("System.String")));
						dsTmp1.Tables["CustomerProgramsPerCustomerDS"].Columns.Add(new DataColumn("CustomerID", Type.GetType("System.String")));
						dsTmp1.Tables["CustomerProgramsPerCustomerDS"].Columns.Add(new DataColumn("VendorOfficeID", Type.GetType("System.String")));
						dsTmp1.Tables["CustomerProgramsPerCustomerDS"].Columns.Add(new DataColumn("VendorID", Type.GetType("System.String")));
						var row = dsTmp1.Tables["CustomerProgramsPerCustomerDS"].NewRow();

						row["CustomerID"] = sIDc[1];
						row["CustomerOfficeID"] = sIDc[0];
						row["VendorID"] = sIDc[1];
						row["VendorOfficeID"] = sIDc[0];
						dsTmp1.Tables["CustomerProgramsPerCustomerDS"].Rows.Add(row);
						dsTmp1.AcceptChanges();
						break;

					default:
						dsTmp1.Tables.Add("CustomerProgramsPerCustomer");
						dsTmp1.Tables["CustomerProgramsPerCustomer"].Columns.Add(new DataColumn("CustomerOfficeID", Type.GetType("System.String")));
						dsTmp1.Tables["CustomerProgramsPerCustomer"].Columns.Add(new DataColumn("CustomerID", Type.GetType("System.String")));
						dsTmp1.Tables["CustomerProgramsPerCustomer"].Columns.Add(new DataColumn("VendorOfficeID", Type.GetType("System.String")));
						dsTmp1.Tables["CustomerProgramsPerCustomer"].Columns.Add(new DataColumn("VendorID", Type.GetType("System.String")));
						var row1 = dsTmp1.Tables["CustomerProgramsPerCustomer"].NewRow();

						row1["CustomerID"] = sIDc[1];
						row1["CustomerOfficeID"] = sIDc[0];
						row1["VendorID"] = sIDc[1];
						row1["VendorOfficeID"] = sIDc[0];
						dsTmp1.Tables["CustomerProgramsPerCustomer"].Rows.Add(row1);
						dsTmp1.AcceptChanges();

						break;
				}

				//if (iServiceType == 7) dsTmp1.Tables.Add("CustomerProgramsPerCustomerDS");
				//else dsTmp1.Tables.Add("CustomerProgramsPerCustomer");
				////dsTmp1.Tables.Add("CustomerProgramsPerCustomer");
				//dsTmp1.Tables["CustomerProgramsPerCustomer"].Columns.Add(new DataColumn("CustomerOfficeID",Type.GetType("System.String")));
				//dsTmp1.Tables["CustomerProgramsPerCustomer"].Columns.Add(new DataColumn("CustomerID",Type.GetType("System.String")));
				//dsTmp1.Tables["CustomerProgramsPerCustomer"].Columns.Add(new DataColumn("VendorOfficeID",Type.GetType("System.String")));
				//dsTmp1.Tables["CustomerProgramsPerCustomer"].Columns.Add(new DataColumn("VendorID",Type.GetType("System.String")));

				//DataRow row = dsTmp1.Tables["CustomerProgramsPerCustomer"].NewRow();

				//string[] sIDc = dsMainDataSet.Tables["EntryBatch"].Rows[0]["CustomerOfficeID_CustomerID"].ToString().Split('_');

				//row["CustomerID"] = sIDc[1];
				//row["CustomerOfficeID"] = sIDc[0];
				//row["VendorID"] = sIDc[1];
				//row["VendorOfficeID"] = sIDc[0];

				//if (iServiceType == 7) dsTmp1.Tables["CustomerProgramsPerCustomerDS"].Rows.Add(row);
				//else dsTmp1.Tables["CustomerProgramsPerCustomer"].Rows.Add(row);
				//dsTmp1.AcceptChanges();
				DataSet dsCustPrograms = new DataSet();
				//DataSet 
				dsCustPrograms = Service.ProxyGenericGet(dsTmp1);//Procedure dbo.spGetCustomerProgramsPerCustomer
				DataRow drNone1 = dsCustPrograms.Tables[0].NewRow();
				drNone1["CustomerProgramName"] = "[Select CP From List]";
				drNone1["CPOfficeID_CPID"] = System.DBNull.Value;
				dsCustPrograms.Tables[0].Rows.InsertAt(drNone1, 0);
				dsCustPrograms.Tables[0].TableName = "CP_List";
				if (dsMainDataSet.Tables.Contains("CP_List")) dsMainDataSet.Tables.Remove("CP_List");
				dsMainDataSet.Tables.Add(dsCustPrograms.Tables[0].Copy());
				if (dsMainDataSet.Tables["CP_List"].Rows.Count > 1)
				{
					cbCustomerProgram.DataSource = dsMainDataSet.Tables["CP_List"];
					cbCustomerProgram.DisplayMember = "CustomerProgramName";
					cbCustomerProgram.ValueMember = "CPOfficeID_CPID";
					cbCustomerProgram.SelectedIndex = 0;
				}
				//if (iServiceType == 7 && dsMainDataSet.Tables["CP_List"].Rows.Count == 2)
				//{
				//	cbCustomerProgram.SelectedIndex = 1;
				//	string message = "Would you like to itemize whole order automatically?";
				//	string caption = "Stop Test Options";
				//	var result = MessageBox.Show(message, caption,
				//								 MessageBoxButtons.YesNo,
				//								 MessageBoxIcon.Question);
				//	if (result == DialogResult.Yes)
				//	{
				//		StopTestAutomate();
				//		return;
				//	}

				//}

				//else
				//{
				//	if (iServiceType == 7)
				//	{
				//		setState("wait for scan");
				//		throw new Exception("Current Customer has no StopTest Customer Programs in system");
				//	}
				//}
				//					for(int i=0;i<dsCustPrograms.Tables[0].Rows.Count;i++)
				//					{
				//						cbCustomerProgram.Items.Add(dsCustPrograms.Tables[0].Rows[i]["CustomerProgramName"]); 
				//					}
				//					dsCustPrograms.Tables[0].TableName = "CP_List";
				//					dsMainDataSet.Tables.Add(dsCustPrograms.Tables[0].Copy());
				//}
				btnOldNumber.Enabled = true;
				//				string sXMLFilePath = Client.GetOfficeDirPath("oldNumberXMLDir");
				//				DirectoryInfo di = new DirectoryInfo(sXMLFilePath);
				//				FileInfo[] fi = di.GetFiles("*.xml");
				//				if (fi.Length > 0)
				//				{
				//					foreach(FileInfo fitemp in fi)
				//					{
				//						if(fitemp.Name.IndexOf("done") < 0)
				//						{
				//							btnOldNumber.Enabled = true;
				//							break;
				//						}
				//					}
				//				}
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message);
			}

		}

		private void StopTestAutomate()
		{
			int iSetID = 1;
			foreach (DataRow row in dsMemoNumbers.Tables[0].Rows)
			{
				object oBatchMemoName = null;
				object oBatchMemoID = null;
				DataRowView drvCP = ((DataRowView)cbCustomerProgram.SelectedItem);
				object oItemtypeID = null;
				object oCPName = null;
				object oCPID = null;
				object oOfficeID_CPID = null;
				object oNItems = null;
				object oSetID = null;
				object oItemTypeName = null;

				if (drvCP != null && cbCustomerProgram.SelectedIndex > 0 && !row["Name"].ToString().ToUpper().Contains("NONE"))
				{
					oBatchMemoName = row["Name"];
					oBatchMemoID = row["MemoNumberID"];
					oItemtypeID = drvCP["ItemTypeID"];
					oCPName = drvCP["CustomerProgramName"];
					oCPID = drvCP["CPID"];
					oOfficeID_CPID = drvCP["CPOfficeID_CPID"];
					oNItems = 1;
					oItemTypeName = itemPanel1.ItemName;
					dsBatchCPItemSet.Tables[0].Rows.Add(new Object[] {  oBatchMemoID,
																		oBatchMemoName,
																		oNItems,
																		oItemtypeID,
																		oCPName,
																		oCPID,
																		oOfficeID_CPID,
																		oSetID,
																		oItemTypeName});
				}
			}
			foreach (DataRow dr in dsBatchCPItemSet.Tables[0].Rows)
			{
				dr["SetID"] = iSetID;
				iSetID++;
			}
			AutoCreateBatch();
			//bcItem_CodeEntered(this, System.EventArgs.Empty);

		}

		private void Itemizn1Form_Load(object sender, System.EventArgs e)
		{
			bcfItem.Select();
			bcItem.Select();
		}
		#endregion EventHandlers
		//		[STAThread]
		//		static void Main() 
		//		{
		//			Application.Run(new Itemizn1Form(2));
		//		}

		private void itemPanel1_NewItemTypeSelected(object sender, System.EventArgs e)
		{
			DataTable table = Service.GetItemizn1_ItemsSubtypesList(itemPanel1.TypeId);
			itemPanel1.InitializeItems(table);
		}

		// Handle the KeyDown event to determine the type of character entered into the control.
		private void tbItemsInspected_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			nonNumberEntered = false;
			////			if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
			////				if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
			////					if(e.KeyCode != Keys.Back)
			////						nonNumberEntered = true;
			if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
			{
				if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
				{
					if (e.KeyCode != Keys.Back)
					{
						if (e.KeyCode != Keys.Return)
							nonNumberEntered = true;
						else
						{
							if (MessageBox.Show("Would you like to save # " + tbItemsInspected.Text + " of inspected items?",
								"New Inspected Items", MessageBoxButtons.YesNo,
								MessageBoxIcon.Question) == DialogResult.Yes)
							{
								updateInspectedNumberOfItems(false);
								bcItem_CodeEntered(this, System.EventArgs.Empty);
								//barCodeField1_CodeEntered(this,System.EventArgs.Empty);
							}
						}
					}
				}
			}
		}

		// This event occurs after the KeyDown event and can be used to prevent characters from entering the control.
		private void tbItemsInspected_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = nonNumberEntered;
		}

		public void AddBatch(string sItemTypeId,
								string sCustomerProgram,
								string sCustomerProgramId,
								int iSetID,
								ref System.Windows.Forms.StatusBar Itemizn2Status)
		{
			Itemizn2Status.Text = "Please Wait. Adding Batch now... ";
			tbItemsInGroup.Text = "";

			DataView dvItems = new DataView(dsMainDataSet.Tables["Items"]);
			dvItems.RowFilter = "SetID = '" + iSetID.ToString() + "'";

			DataView dvBatchSet = new DataView(dsBatchCPItemSet.Tables[0]);
			dvBatchSet.RowFilter = "SetID = '" + iSetID.ToString() + "'";

			System.Collections.ArrayList outList = new ArrayList();
			string sMemoName = null;
			string sMemoID = null;
			try
			{
				//DataRowView drvMemo = ((DataRowView)cbMemoNumber.SelectedItem);
				//New sequence: add batch, print labels, add items
				if (dvBatchSet != null && dvBatchSet[0]["BatchMemoName"].ToString() != "[none]")
				{
					sMemoName = dvBatchSet[0]["BatchMemoName"].ToString();
					sMemoID = dvBatchSet[0]["BatchMemoID"].ToString();
				}
				outList = Service.Itemizn2_BatchAddNew(dvItems,
													dsMainDataSet.Tables["EntryBatch"].Rows[0]["EntryBatchId"].ToString(),
													sItemTypeId,
													sCustomerProgramId,
													sMemoName,
													sMemoID);
			}
			catch (Exception exc)
			{
				throw new Exception("Batch addition failed: " + exc.Message); // + "Step: " + Service.iStep.ToString() + "." + exc.Message);
			}
			alThreadPrintParam = outList;
			Itemizn2Status.Text = "Batch added.";
			try
			{
				if (bAutoCreateBatch) Print(sCustomerProgram, sMemoName);
				/*
                else
                {
                    //Print Report within new thread.
                    //By _3ter on 2006.05.18. Accellerating Itemizn
                    for (; ; )
                    {
                        if (PrintingThread == null || !PrintingThread.IsAlive)
                        {
                            PrintingThread = new Thread(new ThreadStart(Print));
                            PrintingThread.Priority = ThreadPriority.BelowNormal;
                            PrintingThread.Start();
                        }
                        else
                            PrintingThread.Start();


                        if (MessageBox.Show("Would you like to print again?",
                            "Printing completed", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
                        {

                            continue;
                        }
                        else
                        {

                            break;
                        }
                    }

                }
                */
				///////////
				//				CrystalReport.CrystalReport crCustomer_Program=new CrystalReport.CrystalReport(sCRTemplatePath);
				//				crCustomer_Program.Customer_Program(outList[0].ToString());
				//				crCustomer_Program.Print();


				Itemizn2Status.Text = "Batch added. Reports printed.";

				//barCodeField1_CodeEntered(this, System.EventArgs.Empty);
			}
			catch (Exception exc)
			{
				MessageBox.Show("Can't print reports.\r\n" + exc.Message);
			}
			outList = Service.Itemizn2_ItemsAdd(outList, dvItems,
													dsMainDataSet.Tables["EntryBatch"].Rows[0]["EntryBatchId"].ToString(),
													sItemTypeId,
													sCustomerProgramId,
													sMemoName,
													sMemoID);
			int enteredIQ = Convert.ToInt32(dsMainDataSet.Tables["EntryBatch"].Rows[0]["EnteredIQ"]) + dvItems.Count;
			dsMainDataSet.Tables["EntryBatch"].Rows[0]["EnteredIQ"] = Convert.ChangeType(enteredIQ, dsMainDataSet.Tables["EntryBatch"].Columns["EnteredIQ"].DataType);
			double sumWeight = 0;

			if (dsMainDataSet.Tables["EntryBatch"].Rows[0]["EnteredIW"] != DBNull.Value)
				sumWeight = Convert.ToDouble(dsMainDataSet.Tables["EntryBatch"].Rows[0]["EnteredIW"]);

			foreach (DataRowView dr in dvItems)
				if (dr["weight"] != DBNull.Value && dr["weight"].ToString() != "")
					sumWeight += Convert.ToDouble(dr["weight"]);

			dsMainDataSet.Tables["EntryBatch"].Rows[0]["EnteredIW"] = Convert.ChangeType(sumWeight, dsMainDataSet.Tables["EntryBatch"].Columns["EnteredIW"].DataType);

			tbBatchesList.Text += "Item Type: " + dvBatchSet[0]["ItemTypeName"].ToString() + " / ";
			tbBatchesList.Text += "Customer Program: " + sCustomerProgram + " / ";
			tbBatchesList.Text += "Items in batch: " + dvItems.Count + "\r\n";

			while (dvItems.Count > 0)
			{
				dvItems.Delete(0);
			}
			//dsMainDataSet.Tables["Items"].Rows.Clear();
			if (Convert.ToInt32(dsMainDataSet.Tables["EntryBatch"].Rows[0]["EnteredIQ"]) == Convert.ToInt32(dsMainDataSet.Tables["EntryBatch"].Rows[0]["IQInspected"]))
			{
				setState("end of bag");
				try
				{
					if (wcInspected.Weight != "" &&
						wcInspected.MeasureUnitCode == "2" && Math.Abs(Convert.ToDouble(dsMainDataSet.Tables["EntryBatch"].Rows[0]["EnteredIW"]) - Convert.ToDouble(wcInspected.Weight)) > 0.02)
						MessageBox.Show("Note: Total Items Weight (" + dsMainDataSet.Tables["EntryBatch"].Rows[0]["EnteredIW"].ToString() + " " + wcInspected.MeasureUnitName + ") and Weight Inspected (" + wcInspected.Weight + " " + wcInspected.MeasureUnitName + ") have difference more than 0.02 ct.");
				}
				catch { }
			}
			else
				setState("divisioning");

			//Show CP form to edit CP instance
			if (cbEditCP.Checked)
			{
				try
				{
					int iMenuSecurity = 9;
					CustomerProgramForm frm = new CustomerProgramForm(iMenuSecurity);
					frm.InitializeFormFromItemzn(outList[0].ToString());
					frm.ShowDialog(this);
					this.Cursor = Cursors.Default;
				}
				catch (Exception exc)
				{
					MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}

			Itemizn2Status.Text = "Batch added. Printing reports...";

			#region BatchTracking

			if (outList.Count > 0)
			{
				object BatchID = outList[0];
				object EventID = GraderLib.BatchEvents.Created;
				object ItemsAffected = outList.Count - 1;
				object ItemsInBatch = outList.Count - 1;
				object FormID = GraderLib.Codes.Itemizing;
				Service.SetBatchEvent(EventID, BatchID, FormID, ItemsAffected, ItemsInBatch);
			}

			#endregion

			alThreadPrintParam = outList; // To make thread work. by _3ter on 2006.05.18

		}

		private void Print(string sCustomerProgram, string sMemoName)
		{
			Print(sCustomerProgram, sMemoName, alThreadPrintParam);
		}

		private void Print(string sCustomerProgram, string sMemoName, ArrayList outList)
		{
			//#if DEBUG
			//			return;
			//#endif
			string sCRTemplatePath = Client.GetOfficeDirPath("repDir");
			CrystalReport.CrystalReport crReport_Batch = null;// = new CrystalReport.CrystalReport(sCRTemplatePath);
			CrystalReport.CrystalReport crReport_Label = null;
			string sBatchCode = null;
			bool toPrint = false;
			crReport_Label = new CrystalReport.CrystalReport(sCRTemplatePath, true);
			crReport_Batch = new CrystalReport.CrystalReport(sCRTemplatePath, true);

			if (rbBatchLabelsPrint.Checked)
			{
				{
					toPrint = true;
					//crReport_Batch = new CrystalReport.CrystalReport(sCRTemplatePath, true);
					try
					{
						sBatchCode = crReport_Batch.Excel_Label_BatchNew(outList, toPrint);
					}
					catch (Exception ex)
					{
						MessageBox.Show(this, ex.Message, "Print error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}

					/*GC.Collect();
					GC.WaitForPendingFinalizers(); 
					GC.Collect();*/
				}

				//if (Service.GetReportKind() != "crystal")
				//{
				//	if (crReport_Batch != null)
				//		crReport_Label = crReport_Batch;
				//	else
				//		crReport_Label = new CrystalReport.CrystalReport(sCRTemplatePath, true);
				//}
			}
			else
			{
				try
				{
					toPrint = false;
					sBatchCode = crReport_Batch.Excel_Label_BatchNew(outList, toPrint);
				}
				catch (Exception ex)
				{
					MessageBox.Show(this, ex.Message, "Print error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			for (int i = 1; i < outList.Count; i++)
			{
				int abc = i;
				try
				{

					string item = sBatchCode + FillToTwoChars(i.ToString());
					//crReport_Label.Excel_Label_Item(outList[i].ToString());
					if (rbItemLabelsRegular.Checked)
						crReport_Label.Excel_Label_ItemNew(outList.Count - 1, item, sCustomerProgram, sMemoName);
					// alexelse
					// alex	crReport_Label.Excel_Tag_Item(item, sCustomerProgram);
				}
				catch (Exception ex)
				{
					MessageBox.Show(this, ex.Message, "Print error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
	
			Client.MyActivePrinter = "";
			Client.MyActiveReportName = "";
			if(crReport_Label != null)
				crReport_Label.CloseExcel();
			crReport_Label = null;

			if(crReport_Batch != null)
				crReport_Batch.CloseExcel();
			crReport_Batch	= null;
			GC.Collect();
			GC.WaitForPendingFinalizers(); 
			GC.Collect();
		}

        private string FillToTwoChars(string sNumber)
        {
            while (sNumber.Length < 2)
                sNumber = "0" + sNumber;
            return sNumber;
        }
        public void AddItem(int runningN, 
							string lotN, 
							string ParNo, 
							string prevN, 
							string weight, 
							string weightUnitId, 
							string customerWeight, 
							string customerWeightUnitId, 
							int iSetID)
		{
			dsMainDataSet.Tables["Items"].Rows.Add(new Object[] {	runningN, 
																	lotN, 
																	ParNo, 
																	prevN, 
																	weight, 
																	weightUnitId, 
																	customerWeight, 
																	customerWeightUnitId, 
																	iSetID});
		}

		private void btnDoneBag_Click(object sender, System.EventArgs e)
		{
			Service.Itemizn2_EntryBatchComplete(dsMainDataSet.Tables["EntryBatch"].Rows[0]["GroupCode"].ToString());
			this.Text = Service.sProgramTitle + "Itemizn part 1";
			setState("wait for scan");
			//
		}

		private void btnDepartureSettings_Click(object sender, System.EventArgs e)
		{
			DataRowView view = cmstrategy.DepartureSettings(dsMainDataSet.Tables["EntryBatch"].Rows[0]["CustomerName"].ToString());
			if( view!=null && view["CustomerID"]!=DBNull.Value )
			{
				dsMainDataSet.Tables["EntryBatch"].Rows[0]["VendorOfficeID_VendorID"] = view["CustomerID"].ToString();
				dsMainDataSet.Tables["EntryBatch"].Rows[0]["VendorOfficeID"] = view["CustomerID"].ToString().Split(new char[] {'_'})[0];
				dsMainDataSet.Tables["EntryBatch"].Rows[0]["VendorID"] = view["CustomerID"].ToString().Split(new char[] {'_'})[1];
				dsMainDataSet.Tables["EntryBatch"].Rows[0]["VendorName"] = view["CustomerName"].ToString();
				fillItemsInspected();
			}
		}

		private bool isCPvalidated = false;
		private bool isCPvalidatedForGlobal = false;

		private void tbCustomerProgram_Leave(object sender, System.EventArgs e)
		{
			isCPvalidated = false;
		}
		
		private void LoadCPInfo(DataView dvCP)
		{
			nonNumberEntered = true;
			
			try
			{
					DataRowView drv = dvCP[0];
					itemPanel1.SelectItemTypeById(drv["ItemTypeID"].ToString(), drv["ItemTypeGroupID"].ToString());

				if (drv["Path2Picture"] != DBNull.Value)
				{

					string pathToShape = Client.GetOfficeDirPath("iconDir") + drv["Path2Picture"].ToString();
					if (File.Exists(pathToShape))
					{
						Image im = System.Drawing.Image.FromFile(pathToShape);//  (System.Drawing.Image)Service.ExtractImageFromString(dvParts[0]["ShapePicture"].ToString(), dvParts[0]["ShapePath"].ToString()); old part
						itemPanel1.InitializePicture(im);
					}
					else
						itemPanel1.InitializePicture(itemPanel1.DefaultPicture);
				}
				else
					itemPanel1.InitializePicture(itemPanel1.DefaultPicture);

				isCPvalidated = true;
				isCPvalidatedForGlobal = true;
	
//				if(dsMainDataSet.Tables["CPData"] != null)
//				{
//					dsMainDataSet.Tables["CPData"].Rows.Add(new object[]{});
//					DataRow dr = dt.Rows[0];
//					foreach(DataColumn col in dt.Columns)
//					{
//						object myObject = dr[col.ColumnName];
//						dsMainDataSet.Tables["CPData"].Rows[dsMainDataSet.Tables["CPData"].Rows.Count-1][col.ColumnName] = myObject;
//					}
//				}
//				else
//				{
//					DataTable dtMyCP = new DataTable();
//					dtMyCP =  dt.Copy();
//					dtMyCP.TableName = "CPData";
//					dsMainDataSet.Tables.Add(dtMyCP);
//				}
////////				DataRowView drvMemo = ((DataRowView)cbMemoNumber.SelectedItem);
////////				string sMemoName = null;
////////				string sMemoID = null;
////////				if(drvMemo != null && drvMemo["Name"].ToString() != "[none]")
////////				{
////////					sMemoName = drvMemo["Name"].ToString();
////////					sMemoID = drvMemo["MemoNumberID"].ToString();
////////				}

				//tbItemsInGroup.Text = "";
				//tbCustomerProgram.Text = "";
			}
			catch(Exception ex)
			{
				isCPvalidated = false;
				isCPvalidatedForGlobal = false;
				//tbCustomerProgram.Text = itemPanel1.CustomerProgram;
				MessageBox.Show(ex.Message + " .Can't find Customer Program " + tbCustomerProgram.Text);
			}
		}	

		private void tbCustomerProgram_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Return)
			{
				DataView dvCP = new DataView(dsMainDataSet.Tables["CP_List"]);
				dvCP.RowFilter = "CustomerProgramName = '" + tbCustomerProgram.Text.Trim() + "'";
				if(dvCP.Count != 1)
				{
					MessageBox.Show("Can't find Customer Program: " + (char)34 + tbCustomerProgram.Text + (char)34);				
				}
				else
				{
					cbCustomerProgram.SelectedValue = dvCP[0]["CPOfficeID_CPID"];
					tbItemsInGroup.Focus();
				}
				//FillItemCPDataSet(dvCP);
//				nonNumberEntered = true;
//				Service.GetItemizn_CustomerProgramExists(tbCustomerProgram.Text);//Procedure dbo.spGetCustomerProgramByName
//				try
//				{
//					DataRow drEntryBatchRow = dsMainDataSet.Tables["EntryBatch"].Rows[0];
//					DataTable dt = Service.GetItemizn_ItemTypeIdByCustomerProgramAndCustomer(
//						tbCustomerProgram.Text,
//						drEntryBatchRow["VendorOfficeID"].ToString(),
//						drEntryBatchRow["VendorID"].ToString(),
//						drEntryBatchRow["CustomerOfficeID"].ToString(),
//						drEntryBatchRow["CustomerID"].ToString());
//					if( dt.Rows.Count == 0 )
//						throw new Exception();
//					if(dt.Rows[0]["Picture"]!=DBNull.Value)
//						itemPanel1.InitializePicture((Image)dt.Rows[0]["Picture"]);
//					else
//						itemPanel1.InitializePicture(itemPanel1.DefaultPicture);
//					isCPvalidated = true;
//					isCPvalidatedForGlobal = true;
//	
//					if(dsMainDataSet.Tables["CPData"] != null)
//					{
//						dsMainDataSet.Tables["CPData"].Rows.Add(new object[]{});
//						DataRow dr = dt.Rows[0];
//						foreach(DataColumn col in dt.Columns)
//						{
//							object myObject = dr[col.ColumnName];
//							dsMainDataSet.Tables["CPData"].Rows[dsMainDataSet.Tables["CPData"].Rows.Count-1][col.ColumnName] = myObject;
//						}
//					}
//					else
//					{
//						DataTable dtMyCP = new DataTable();
//						dtMyCP =  dt.Copy();
//						dtMyCP.TableName = "CPData";
//						dsMainDataSet.Tables.Add(dtMyCP);
//					}
//					DataRowView drvMemo = ((DataRowView)cbMemoNumber.SelectedItem);
//					string sMemoName = null;
//					string sMemoID = null;
//					if(drvMemo != null && drvMemo["Name"].ToString() != "[none]")
//					{
//						sMemoName = drvMemo["Name"].ToString();
//						sMemoID = drvMemo["MemoNumberID"].ToString();
//					}
//
//					tbItemsInGroup.Text = "";
//					tbCustomerProgram.Text = "";
//					itemPanel1.SelectItemTypeById(dt.Rows[0]["ItemTypeID"].ToString(), dt.Rows[0]["ItemTypeGroupID"].ToString());
//				}
//				catch(Exception ex)
//				{
//					isCPvalidated = false;
//					isCPvalidatedForGlobal = false;
//					//tbCustomerProgram.Text = itemPanel1.CustomerProgram;
//					MessageBox.Show(ex.Message + " .Can't find Customer Program " + tbCustomerProgram.Text);
//				}
				}
				else
				{
				nonNumberEntered = false;
				}
		}

		private void tbCustomerProgram_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = nonNumberEntered;
		}

		private void Itemizn1Form_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
				if (!canClose)
				e.Cancel = false;
		}

		private void btnSaveNumberOfItemsInspected_Click(object sender, System.EventArgs e)
		{
			updateInspectedNumberOfItems(true);
		}

		public string getGroupID()
		{
			return dsMainDataSet.Tables["EntryBatch"].Rows[0]["GroupID"].ToString();
		}

		private void btnOldNumber_Click(object sender, System.EventArgs e)
		{
			canClose = false;
			try 
			{
//				if(dsBatchCPItemSet.Tables[0].Rows.Count == 0 && tbItemsInGroup.Text.Trim() != "")
//					btnAddToList_Click(this, System.EventArgs.Empty);
				if (dsMainDataSet.Tables["EntryBatch"].Rows[0]["IQInspected"] != DBNull.Value)
				{
					goto Skip1;
					if(Convert.ToInt32(dsMainDataSet.Tables["EntryBatch"].Rows[0]["EnteredIQ"]) == Convert.ToInt32(dsMainDataSet.Tables["EntryBatch"].Rows[0]["IQInspected"]))
					{
						setState("wait for scan");
						throw new Exception("Group has inspected number of items already.");
					}
				}
				
				try
				{
					if(Convert.ToInt32(tbItemsInspected.Text)>0)
					{}
					else
						throw new Exception("Please enter inspected number of items.");
					
				}
				catch
				{
					tbItemsInspected.Focus();
					tbItemsInspected.SelectAll();
					throw new Exception("Please enter inspected number of items.");
				}
				if(Convert.ToInt32(dsMainDataSet.Tables["EntryBatch"].Rows[0]["EnteredIQ"]) + Convert.ToInt32((tbItemsInGroup.Text!="")?tbItemsInGroup.Text:"0") > Convert.ToInt32(tbItemsInspected.Text))
				{
					tbItemsInGroup.Focus();
					tbItemsInGroup.SelectAll();
					throw new Exception("Group needs only " + (Convert.ToInt32(tbItemsInspected.Text)-Convert.ToInt32(dsMainDataSet.Tables["EntryBatch"].Rows[0]["EnteredIQ"])).ToString() + " items to reach inspected number of items.");
				}
				if(Convert.ToInt32(tbOldNumbers.Text) > Convert.ToInt32(tbItemsNotAdded.Text))
				{
					throw new Exception("You can enter only " + tbItemsNotAdded.Text + " items");
				}

			Skip1:
				setState("old numbers");
				//int itemsInGroup = Convert.ToInt32(dsBatchCPItemSet.Tables[0].Rows[0]["nItemsInSet"]);
				int enteredIQ = Convert.ToInt32(dsMainDataSet.Tables["EntryBatch"].Rows[0]["EnteredIQ"]);// + itemsInGroup; //Convert.ToInt32((tbItemsInGroup.Text!="")?tbItemsInGroup.Text:"0");
				
				FormCallOldNumbers frm1 = new FormCallOldNumbers();
				frm1.tbOldNumbers.Text = tbOldNumbers.Text.Trim();
				//frm1.bCallOldNumberForm.Text = "Enter " + frm1.tbOldNumbers.Text.Trim() + " Items";
				DialogResult dlgRes = frm1.ShowDialog(this);

				if (dlgRes == DialogResult.Yes || dlgRes == DialogResult.OK)
				{
					//frm1.tbOldNumbers.Text = Convert.ToString(Math.Min(Convert.ToInt32(frm1.tbOldNumbers.Text.Trim()), Convert.ToInt32(tbOldNumbers.Text.Trim())));
					string sItemsToAdd = "";
					if (dlgRes == DialogResult.Yes) sItemsToAdd = frm1.tbOldNumbers.Text.Trim();
					else sItemsToAdd = "500";
					
						OldNumbersForm frm = new OldNumbersForm(dsMainDataSet.Tables["EntryBatch"].Rows[0]["EntryBatchId"].ToString(), 
																dsMainDataSet.Tables["EntryBatch"].Rows[0]["GroupCode"].ToString(), 
																sItemsToAdd, 
																dsMainDataSet.Tables["EntryBatch"].Copy(),
                                                                dsMemoNumbers.Copy());
					try
					{
						frm.ShowDialog(this);
						frm.Close();
						frm.Dispose();
						setState("create division");

						enteredIQ = Convert.ToInt16(lbItemsItemized.Text);
						
						dsMainDataSet.Tables["EntryBatch"].Rows[0]["EnteredIQ"] = Convert.ChangeType(enteredIQ, dsMainDataSet.Tables["EntryBatch"].Columns["EnteredIQ"].DataType);
						if(enteredIQ < Convert.ToInt32(dsMainDataSet.Tables["EntryBatch"].Rows[0]["IQInspected"]))
							setState("old numbers");
						else
						{
							setState("wait for scan");
							btnDoneBag.Enabled = true;
						}
                        if(bcItem.sGroupCode != "") bcItem.Text = bcItem.sGroupCode;
						LoadOrderData();
					}

					catch(Exception ex)
					{
						string msg = ex.Message;
						MessageBox.Show(this, msg);
					}
				}
			SetSingleMemoIndex(); //cbMemoNumber.SelectedIndex = 0;		
			cbCustomerProgram.SelectedIndex = 0;
			}
			catch(InvalidCastException ice)
			{
				string msg = ice.Message;
				//MessageBox.Show(this,"InvalidCastException","OldNumber");
			}
			catch(IndexOutOfRangeException iore)
			{
				string msg = iore.Message;
				//MessageBox.Show(this,"IndexOutOfRangeException","OldNumber");
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message);
			}
		}

		private void AutoCreateBatch()
		{
			bAutoCreateBatch = true;
            btnAutoCreateBatch.Enabled = false;

			try
			{

				//					if(cbMemoNumber.SelectedIndex == -1 && cbMemoNumber.Text != "")
				//					{
				//						throw new Exception("Wrong MemoNumber");
				//					}

				DataRow drEntryBatchRow = dsMainDataSet.Tables["EntryBatch"].Rows[0];

				if(wcInspected.Weight != null && wcInspected.Weight != "")
				{
					drEntryBatchRow["TWInspected"] = Convert.ChangeType(wcInspected.Weight, dsMainDataSet.Tables["EntryBatch"].Columns["TWInspected"].DataType);
					drEntryBatchRow["TWInspectedMeasureUnitId"] = Convert.ChangeType(wcInspected.MeasureUnitID, dsMainDataSet.Tables["EntryBatch"].Columns["TWInspectedMeasureUnitId"].DataType);
				}
				else
				{
					drEntryBatchRow["TWInspected"] = DBNull.Value;
					drEntryBatchRow["TWInspectedMeasureUnitId"] = DBNull.Value;
				}	
			
				try
				{
                    if(Convert.ToInt32(tbItemsInspected.Text) > 0)
                    {
                        drEntryBatchRow["IQInspected"] = Convert.ChangeType(tbItemsInspected.Text, dsMainDataSet.Tables["EntryBatch"].Columns["IQInspected"].DataType);
                    }
                    else
                    {
                        btnAutoCreateBatch.Enabled = true;
                        throw new Exception("Please enter inspected number of items.");
                    }
				}
				catch
				{
					tbItemsInspected.Focus();
					tbItemsInspected.SelectAll();
                    btnAutoCreateBatch.Enabled = true;
					throw new Exception("Please enter inspected number of items.");
				}

				if (drEntryBatchRow["EnteredIQ"] == DBNull.Value) drEntryBatchRow["EnteredIQ"] = 0;
				//check number of items in the batch
				////				if(Convert.ToInt32(drEntryBatchRow["EnteredIQ"]) + Convert.ToInt32(tbItemsInGroup.Text) > Convert.ToInt32(tbItemsInspected.Text))
				////				{
				////					tbItemsInGroup.Focus();
				////					tbItemsInGroup.SelectAll();
				////					throw new Exception("Group needs only " + (Convert.ToInt32(tbItemsInspected.Text)-Convert.ToInt32(dsMainDataSet.Tables["EntryBatch"].Rows[0]["EnteredIQ"])).ToString() + " items to reach inspected number of items.");
				////					//setState("wait for scan");
				////				}
				//			DataTable dtCP = Service.GetItemizn_ItemTypeIdByCustomerProgramAndCustomer(
				//				tbCustomerProgram.Text,
				//				drEntryBatchRow["VendorOfficeID"].ToString(),
				//				drEntryBatchRow["VendorID"].ToString(),
				//				drEntryBatchRow["CustomerOfficeID"].ToString(),
				//				drEntryBatchRow["CustomerID"].ToString());//Procedure dbo.spGetCustomerProgramByNameAndCustomer
				//			if (dtCP.Rows.Count == 0)
				//			{
				//				tbCustomerProgram.Focus();
				//				tbCustomerProgram.SelectAll();
				//				throw new Exception("Can not find entered Customer Program/ Item Type ID");	
				//			}
				//Service.Itemizn1_EntryBatchUpdate(dsMainDataSet.Tables["EntryBatch"]);//Procedure dbo.spItemizingUpdateGroup
				
				foreach(DataRow dr in dsBatchCPItemSet.Tables[0].Rows)
				{
					int nItems = Convert.ToInt32(dr["nItemsInSet"]);
					int iSetID =  Convert.ToInt32(dr["SetID"].ToString());
					if(Convert.ToInt32(drEntryBatchRow["EnteredIQ"]) + nItems > Convert.ToInt32(tbItemsInspected.Text))
					{
						//tbItemsInGroup.Focus();
						//tbItemsInGroup.SelectAll();
						throw new Exception("Group needs only " + (Convert.ToInt32(tbItemsInspected.Text)-Convert.ToInt32(dsMainDataSet.Tables["EntryBatch"].Rows[0]["EnteredIQ"])).ToString() + " items to reach inspected number of items.");
						//setState("wait for scan");
					}
					
					int nBatches = (nItems / 25) + ((nItems % 25) != 0 ? 1 : 0);
			
					//DataRow drEntryBatchCPRow = dsMainDataSet.Tables["CPData"].Rows[0];
					if (1 == 1) //(!bLoadingFromXML)
					{
						for (int i = 0; i < nBatches; i++)
						{
							for (int k = 0; (k < 25 && nItems > 0); k++)
							{
								AddItem(k + 1, "", "", "", "", "2", "", "2", iSetID);
								nItems--;
							}
							AddBatch(dr["ItemTypeID"].ToString(),
										dr["CPName"].ToString(),
										dr["CPOfficeID_CPID"].ToString(),
										iSetID,
										ref statusBar1);
						}
					}
				}
				// -- here is new part to check - moved from line 2318
				Service.Itemizn1_EntryBatchUpdate(dsMainDataSet.Tables["EntryBatch"]);//Procedure dbo.spItemizingUpdateGroup

			}
			catch (Exception exc)
			{
                btnAutoCreateBatch.Enabled = true;
                MessageBox.Show(exc.Message);
				return;
			}	
//			btnAutoCreateBatch.Enabled = false;
			btnAddToList.Enabled = false;
			btnClearSet.Enabled = false;
			isCPvalidatedForGlobal = false;
			tbCustomerProgram.Text = "";
			bAutoCreateBatch = false;
			btnClearSet_Click(this, System.EventArgs.Empty);
			SetSingleMemoIndex(); //cbMemoNumber.SelectedIndex = 0;
			cbCustomerProgram.SelectedIndex = 0;
		}
		
		private void btnAutoCreateBatch_Click(object sender, System.EventArgs e)
		{
			//btnAddToList_Click(this, System.EventArgs.Empty);
            
            if (dsBatchCPItemSet.Tables[0].Rows.Count == 0) 
            {
                btnAddToList_Click(this, System.EventArgs.Empty);
                return;
            }
			AutoCreateBatch();
            bcItem_CodeEntered(this, System.EventArgs.Empty);
			//barCodeField1_CodeEntered(this, System.EventArgs.Empty);
			return;

			bAutoCreateBatch = true;
			try
			{

//					if(cbMemoNumber.SelectedIndex == -1 && cbMemoNumber.Text != "")
//					{
//						throw new Exception("Wrong MemoNumber");
//					}

				DataRow drEntryBatchRow = dsMainDataSet.Tables["EntryBatch"].Rows[0];

				if(wcInspected.Weight != null && wcInspected.Weight != "")
				{
					drEntryBatchRow["TWInspected"] = Convert.ChangeType(wcInspected.Weight, dsMainDataSet.Tables["EntryBatch"].Columns["TWInspected"].DataType);
					drEntryBatchRow["TWInspectedMeasureUnitId"] = Convert.ChangeType(wcInspected.MeasureUnitID, dsMainDataSet.Tables["EntryBatch"].Columns["TWInspectedMeasureUnitId"].DataType);
				}
				else
				{
					drEntryBatchRow["TWInspected"] = DBNull.Value;
					drEntryBatchRow["TWInspectedMeasureUnitId"] = DBNull.Value;
				}	
			
				try
				{
					if(Convert.ToInt32(tbItemsInspected.Text) > 0)
					{
						drEntryBatchRow["IQInspected"] = Convert.ChangeType(tbItemsInspected.Text, dsMainDataSet.Tables["EntryBatch"].Columns["IQInspected"].DataType);
					}
					else
						throw new Exception("Please enter inspected number of items.");
				}
				catch
				{
					tbItemsInspected.Focus();
					tbItemsInspected.SelectAll();
					throw new Exception("Please enter inspected number of items.");
				}

				if (drEntryBatchRow["EnteredIQ"] == DBNull.Value) drEntryBatchRow["EnteredIQ"] = 0;
				//check number of items in the batch
////				if(Convert.ToInt32(drEntryBatchRow["EnteredIQ"]) + Convert.ToInt32(tbItemsInGroup.Text) > Convert.ToInt32(tbItemsInspected.Text))
////				{
////					tbItemsInGroup.Focus();
////					tbItemsInGroup.SelectAll();
////					throw new Exception("Group needs only " + (Convert.ToInt32(tbItemsInspected.Text)-Convert.ToInt32(dsMainDataSet.Tables["EntryBatch"].Rows[0]["EnteredIQ"])).ToString() + " items to reach inspected number of items.");
////					//setState("wait for scan");
////				}
				//			DataTable dtCP = Service.GetItemizn_ItemTypeIdByCustomerProgramAndCustomer(
				//				tbCustomerProgram.Text,
				//				drEntryBatchRow["VendorOfficeID"].ToString(),
				//				drEntryBatchRow["VendorID"].ToString(),
				//				drEntryBatchRow["CustomerOfficeID"].ToString(),
				//				drEntryBatchRow["CustomerID"].ToString());//Procedure dbo.spGetCustomerProgramByNameAndCustomer
				//			if (dtCP.Rows.Count == 0)
				//			{
				//				tbCustomerProgram.Focus();
				//				tbCustomerProgram.SelectAll();
				//				throw new Exception("Can not find entered Customer Program/ Item Type ID");	
				//			}
				Service.Itemizn1_EntryBatchUpdate(dsMainDataSet.Tables["EntryBatch"]);//Procedure dbo.spItemizingUpdateGroup
				
				foreach(DataRow dr in dsBatchCPItemSet.Tables[0].Rows)
				{
					int nItems = Convert.ToInt32(dr["nItemsInSet"]);
					int iSetID =  Convert.ToInt32(dr["SetID"].ToString());
					if(Convert.ToInt32(drEntryBatchRow["EnteredIQ"]) + nItems > Convert.ToInt32(tbItemsInspected.Text))
					{
						//tbItemsInGroup.Focus();
						//tbItemsInGroup.SelectAll();
						throw new Exception("Group needs only " + (Convert.ToInt32(tbItemsInspected.Text)-Convert.ToInt32(dsMainDataSet.Tables["EntryBatch"].Rows[0]["EnteredIQ"])).ToString() + " items to reach inspected number of items.");
						//setState("wait for scan");
					}
					
					int nBatches = (nItems / 25) + ((nItems % 25) != 0 ? 1 : 0);
			
				//DataRow drEntryBatchCPRow = dsMainDataSet.Tables["CPData"].Rows[0];
					if (1 == 1) //(!bLoadingFromXML)
					{
						for (int i = 0; i < nBatches; i++)
						{
							for (int k = 0; (k < 25 && nItems > 0); k++)
							{
								AddItem(k + 1, "", "", "", "", "2", "", "2", iSetID);
								nItems--;
							}
							AddBatch(dr["ItemTypeID"].ToString(),
										dr["CPName"].ToString(),
										dr["CPOfficeID_CPID"].ToString(),
										iSetID,
										ref statusBar1);
						}
					}
	
				}
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message);
				return;
			}	
			btnAutoCreateBatch.Enabled = false;
			btnAddToList.Enabled = false;
			btnClearSet.Enabled = false;
			isCPvalidatedForGlobal = false;
			tbCustomerProgram.Text = "";
			bAutoCreateBatch = false;
			btnClearSet_Click(this, System.EventArgs.Empty);
			SetSingleMemoIndex(); //cbMemoNumber.SelectedIndex = 0;
			cbCustomerProgram.SelectedIndex = 0;
			rbBatchLabelsPrint.Checked = true;
			rbItemLabelsRegular.Checked = true;
            rbSelectRealItem.Checked = true;
		}

		private void itemPanel1_Load(object sender, System.EventArgs e)
		{
		
		}

		private void cbCustomerProgram_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			setState("item type selected");

			if(FormState != "before start divisioning" && cbCustomerProgram.SelectedIndex > 0)
			{
				tbCustomerProgram.Text = cbCustomerProgram.Text;
				tbItemsInGroup.Text = "";
				DataView dvCP = new DataView(dsMainDataSet.Tables["CP_List"]);
				dvCP.RowFilter = "CustomerProgramName = '" + tbCustomerProgram.Text.Trim() + "'";
				if(dvCP.Count != 1)
				{
					MessageBox.Show("Can't find Customer Program in list: " + tbCustomerProgram.Text);				
				}
				else
				{
					isCPvalidated = true;
					tbItemsInGroup.Enabled = true;
					LoadCPInfo(dvCP);
					tbItemsInGroup.Focus();
					btnItmzFromXLS.Enabled = true;
				}
			}
			else
				tbCustomerProgram.Text = "";

			if (dsBatchCPItemSet.Tables[0].Rows.Count> 0)
			{
				//btnAddToList.Enabled = true;
				btnAutoCreateBatch.Enabled = true;
				btnClearSet.Enabled = true;
				btnCreateGroup.Enabled = true;
				btnItmzFromXLS.Enabled = true;

			}
		}

		private void tbCustomerProgram_TextChanged(object sender, System.EventArgs e)
		{
			tbItemsInGroup.Enabled = false;
			btnAddToList.Enabled = false;
			btnClearSet.Enabled = false;
			btnAutoCreateBatch.Enabled = false;
			btnCreateGroup.Enabled = false;
		}

		private void tbItemsInGroup_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			nonNumberEntered1 = false;
			if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
			{
				if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
				{
					if(e.KeyCode != Keys.Back)
					{
						if(e.KeyCode != Keys.Return)
							nonNumberEntered1 = true;
						
					}
				}
			}
			if (e.KeyCode == Keys.Return)
			{
				if(tbItemsInGroup.Text.Trim().Length > 0)
				{
					int iItemsInGroup = Convert.ToInt32(tbItemsInGroup.Text.Trim());
					int iItemsToAdd = Convert.ToInt32(tbItemsNotAdded.Text.Trim());
					int iItemsInGroup1 = Math.Min(iItemsInGroup,iItemsToAdd);
					if(iItemsInGroup1 != iItemsInGroup)
					{
						if(MessageBox.Show("Your can add only " + iItemsInGroup1.ToString() + " items.\r\nWould you like to add?",
							"Items in set near maximum", MessageBoxButtons.YesNo, 
							MessageBoxIcon.Question) == DialogResult.No)
							return;
					}
					tbItemsInGroup.Text = iItemsInGroup1.ToString();
					btnAddToList.Enabled = false;
					btnClearSet.Enabled = true;
					btnAutoCreateBatch.Enabled = true;
					btnCreateGroup.Enabled = true;
					btnAddToList_Click(sender, System.EventArgs.Empty);
				}
			}
		}

		private void tbItemsInGroup_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = nonNumberEntered1;
		}

		private void btnAddToList_Click(object sender, System.EventArgs e)
		{
			btnAddToList.Enabled = false;
			btnAutoCreateBatch.Enabled = true;
			try
			{
				if(cbMemoNumber.SelectedIndex == -1 && cbMemoNumber.Text != "")
				{
					throw new Exception("Wrong MemoNumber");
				}
				DataRowView drvMemo = ((DataRowView)cbMemoNumber.SelectedItem);
				object oBatchMemoName = null;
				object oBatchMemoID = null;

				if(drvMemo != null && drvMemo["Name"].ToString().Trim() != "[none]")
				{
				    oBatchMemoName = drvMemo["Name"];
                    if(rbSelectReportItem.Checked) oBatchMemoName = oBatchMemoName + " (P)";
					oBatchMemoID = drvMemo["MemoNumberID"];
				}
				if(oBatchMemoName == null || oBatchMemoName.ToString().Trim() == "")
				{
                    if(MessageBox.Show("Memo info is missing.\r\nIs it OK to itemize this set?",
                        "Missing Memo info", MessageBoxButtons.YesNo, 
                        MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) == DialogResult.No)	
                    {
                        return;
                    }
                    else
                    {
                        if(rbSelectReportItem.Checked) oBatchMemoName = "(P)";
                    }
				}

				DataRowView drvCP = ((DataRowView)cbCustomerProgram.SelectedItem);
				int iSetID = 1;
				object	oItemtypeID	=	null;
				object	oCPName		=	null;
				object	oCPID		=	null;
				object	oOfficeID_CPID = null;
				object	oNItems		=	null;
				object	oSetID		=	null;
				object	oItemTypeName = null;
				//int iTotal = 0;
				if(drvCP != null && cbCustomerProgram.SelectedIndex > 0  && tbItemsInGroup.Text.Trim() !="")
				{
					oItemtypeID	=	drvCP["ItemTypeID"];
					oCPName		=	drvCP["CustomerProgramName"];
					oCPID		=	drvCP["CPID"];
					oOfficeID_CPID =	drvCP["CPOfficeID_CPID"];
					oNItems	= Convert.ToInt16(tbItemsInGroup.Text.Trim());
					oItemTypeName = itemPanel1.ItemName;

					if(tbTotalItemsInSet.Text.Trim() == "") 
						tbTotalItemsInSet.Text = "0";

					int iItemsToAdd = Convert.ToInt16(tbItemsInspected.Text) - Convert.ToInt32(dsMainDataSet.Tables["EntryBatch"].Rows[0]["EnteredIQ"]);
					int iTotalItemInSet = Math.Min((Convert.ToInt16(tbTotalItemsInSet.Text) + Convert.ToInt16(oNItems)), iItemsToAdd);
					tbTotalItemsInSet.Text = iTotalItemInSet.ToString();
					int iTotalItemsToAdd = iItemsToAdd - iTotalItemInSet;
					tbItemsNotAdded.Text = iTotalItemsToAdd.ToString();
					tbOldNumbers.Text = iTotalItemsToAdd.ToString();
					
					dsBatchCPItemSet.Tables[0].Rows.Add(new Object[] {	oBatchMemoID, 
																		oBatchMemoName, 
																		oNItems, 
																		oItemtypeID, 
																		oCPName, 
																		oCPID, 
																		oOfficeID_CPID,
																		oSetID,
																		oItemTypeName});

					foreach(DataRow dr in dsBatchCPItemSet.Tables[0].Rows)
					{
						dr["SetID"] = iSetID;
						iSetID++;
					}

					if (iTotalItemsToAdd < 1)
					{
						btnAutoCreateBatch.Enabled = false;
						tbItemsNotAdded.Text = "0";
						tbOldNumbers.Text = "0";
						//oNItems = null;
						if(MessageBox.Show("Your items set is full. You can't add more items.\r\nWould you like to itemize set?",
							"Items in set reached maximum of " + iItemsToAdd.ToString(), MessageBoxButtons.YesNo, 
							MessageBoxIcon.Question) == DialogResult.Yes)
					
						{
							tbItemsInGroup.Text = "";
							
							AutoCreateBatch();
                            bcItem_CodeEntered(this, System.EventArgs.Empty);
							//barCodeField1_CodeEntered(this, System.EventArgs.Empty);
							//btnAutoCreateBatch_Click(this, System.EventArgs.Empty);
							return;
						}
						//throw new Exception("You try to add " + tbItemsInGroup.Text.Trim() + " items." + \n\r + tbTotalItemsInSet.Text + " exceeded inspected # " + iItemsToAdd.ToString());
					}							
//					if(tbTotalItemsInSet.Text.Trim() == "") 
//							tbTotalItemsInSet.Text = "0";
//					
//					int iTotalItemInSet = (Convert.ToInt16(tbTotalItemsInSet.Text) + Convert.ToInt16(oNItems));
//					tbTotalItemsInSet.Text = iTotalItemInSet.ToString();
//					int iItemsToAdd = Convert.ToInt16(tbItemsInspected.Text) - Convert.ToInt32(dsMainDataSet.Tables["EntryBatch"].Rows[0]["EnteredIQ"]);
//					int iTotalItemsToAdd = iItemsToAdd - iTotalItemInSet;
//					tbItemsNotAdded.Text = iTotalItemsToAdd.ToString();
//
//					if (iTotalItemsToAdd < 1)
//						{
//							throw new Exception("Total # of Item " + tbTotalItemsInSet.Text + " exceeded inspected # " + tbItemsInspected.Text);
//						}
					
					DataView myView = new DataView(dsBatchCPItemSet.Tables[0]);
					myView.AllowNew = true;
					myView.AllowEdit = false;
					myView.AllowDelete = true;
					dgItemsSet.SetDataBinding(myView, "");
					//myView.AllowNew = false;
					dgItemsSet.Refresh();
					cbCustomerProgram.SelectedIndex = 0;
					tbItemsInGroup.Text = "";
					if (dsBatchCPItemSet.Tables[0].Rows.Count > 1) 
					{
						btnCreateGroup.Enabled = false;
					}
					SetSingleMemoIndex(); //cbMemoNumber.SelectedIndex = 0;
				}
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message);
				return;
			}	
		}
		private void SetSingleMemoIndex()
		{
			try
			{
				if(dsMemoNumbers.Tables["MemoNumbers"].Rows.Count == 2)
				{
					cbMemoNumber.SelectedIndex = 1;
				}
				else
					cbMemoNumber.SelectedIndex = 0;
			}
			catch
			{
				cbMemoNumber.SelectedIndex = 0;
			}
		}
		private void btnClearSet_Click(object sender, System.EventArgs e)
		{
			try
			{
				while (dsBatchCPItemSet.Tables[0].Rows.Count > 0)
				{
					dsBatchCPItemSet.Tables[0].Rows[0].Delete();
				}
				
				dgItemsSet.Refresh();

				tbTotalItemsInSet.Text = "0";
				int iTotalItemsToAdd = 0;
				if (tbItemsInspected.Text.Trim() != "") 
					iTotalItemsToAdd = Convert.ToInt16(tbItemsInspected.Text) - Convert.ToInt32(dsMainDataSet.Tables["EntryBatch"].Rows[0]["EnteredIQ"]);
				tbItemsNotAdded.Text = iTotalItemsToAdd.ToString();
				tbOldNumbers.Text = iTotalItemsToAdd.ToString();
				btnAutoCreateBatch.Enabled = false;
				btnStartGrouping.Enabled = true;
				rbBatchLabelsPrint.Checked = true;
				rbItemLabelsRegular.Checked = true;
                rbSelectRealItem.Checked = true;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
				return;			
			}
		}

		private void btnCreateGroup_EnabledChanged(object sender, System.EventArgs e)
		{
//			if(Convert.ToInt32(tbItemsNotAdded.Text.Trim()) < 1)
//				btnOldNumber.Enabled = btnCreateGroup.Enabled;
//			else
//				btnOldNumber.Enabled = true;
		}

		private void Itemizn1Form_Closed(object sender, System.EventArgs e)
		{
			Dispose();
		}

        private void bcItem_CodeEntered(object sender, System.EventArgs e)
        {
            if (bcItem.sGroupCode.Length > 4)
            {
//                sGroup = bcItem.sGroupCode;
                //sGroup = bcfItem.Text.Trim().Substring(0, bcItem.Text.Trim().IndexOf(".")); 
                LoadOrderData();
            }	        
        }

        private void bcItem_Enter(object sender, System.EventArgs e)
        {
            if(FormState != "create division")
            bcItem.Text = "";
        }

        private void itemPanel1_Load_1(object sender, System.EventArgs e)
        {
        
        }

        private void dgItemsSet_Navigate(object sender, System.Windows.Forms.NavigateEventArgs ne)
        {
        
        }

   
		public bool SetCanClose
		{
			set{canClose = value;}
			get{return canClose;}
		}

	
		private void panel2_Paint(object sender, PaintEventArgs e)
		{

		}

		private void btnItmzFromXLS_Click(object sender, EventArgs e)
		{
			string sCRTemplatePath = "";
			CrystalReport.CrystalReport crReportSub = null;
			if (cbCustomerProgram.SelectedIndex <= 0)
			{
				MessageBox.Show("Please, select SKU first");
				return;
			}
			openFileDialog1.InitialDirectory = Service.sTempDir + System.IO.Path.DirectorySeparatorChar;
			openFileDialog1.Filter = "xls files (*.xls)|*.xls; *.xlsx";
			openFileDialog1.FilterIndex = 1;
			openFileDialog1.Multiselect = false;
			txtXLSFile.Text = openFileDialog1.FileName;

			BindingSource bindingSource1 = new BindingSource();

			DialogResult result = openFileDialog1.ShowDialog();
			if (result == DialogResult.OK)
			{
				dsDatafromXLS = new DataSet();
				crReportSub = new CrystalReport.CrystalReport(sCRTemplatePath,true);

				crReportSub.GetDataFromExcel(openFileDialog1.FileName, ref dsDatafromXLS);
				
				if (dsDatafromXLS.Tables.Count > 0)
				{
					bindingSource1.DataSource = dsDatafromXLS.Tables[0];
					dataGridView1.DataSource = bindingSource1;
					dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.Fill);
					tabGroup.TabPages[1].Select();
			
				}
			}


			bLoadingFromXML = true;

			//int skuIndex = cbCustomerProgram.SelectedIndex;
			//string sXMLFilePath = Client.GetOfficeDirPath("oldNumberXMLDir");
			//dsDatafromXLS = new DataSet();
			//DataSet dsXML = new DataSet();
			//if (File.Exists(sXMLFilePath + txtXLSFile.Text))
			//{
			//    dsXML.ReadXml(sXMLFilePath + txtXLSFile.Text);
			//    if (dsXML.Tables["Data"].Rows.Count > 0)
			//    {
			//        dsDatafromXLS.Tables.Add("Items");
			//        dsDatafromXLS.Tables["Items"].Columns.Add(new DataColumn("Lot"));
			//        dsDatafromXLS.Tables["Items"].Columns.Add(new DataColumn("Memo"));
			//        dsDatafromXLS.Tables["Items"].Columns.Add(new DataColumn("Weight"));
			//        dsDatafromXLS.Tables["Items"].Columns.Add(new DataColumn("BatchCode"));
			//        dsDatafromXLS.Tables["Items"].Columns.Add(new DataColumn("ItemCode"));
			//        string sTempData = "";
			//        try
			//        {
			//            for (int i = 0; i < dsXML.Tables["Data"].Rows.Count; )
			//            {
							
			//                DataRow drTemp = dsDatafromXLS.Tables["Items"].NewRow();
			//                DataRow dr1 = dsXML.Tables["Data"].Rows[i];
			//                sTempData = dr1[1].ToString();
			//                drTemp["Lot"] = dr1[1].ToString();
			//                i++;
			//                dr1 = dsXML.Tables["Data"].Rows[i];
			//                sTempData =  dr1[1].ToString();
			//                drTemp["Memo"] = dr1[1].ToString();
			//                i++;
			//                dr1 = dsXML.Tables["Data"].Rows[i];
			//                sTempData = dr1[1].ToString();
			//                drTemp["Weight"] = dr1[1].ToString();
			//                dsDatafromXLS.Tables["Items"].Rows.Add(drTemp);
			//                i++;
			//            }
			//            DataView dw = new DataView(dsDatafromXLS.Tables["Items"]);
			//            dw.Sort = "Memo ASC";
			//            //foreach (DataRowView drv in dw)
			//            //{
			//            //    sTempData = drv["Memo"].ToString();
						
			//            //}
			//            string sMyFilter = "";
			//            DataRow[] MySelectedRow;
			//            for (int i = 1; i <= cbMemoNumber.Items.Count; i++)
			//            {
			//                cbMemoNumber.SelectedIndex = i;
			//                sTempData = cbMemoNumber.Text;
			//                sMyFilter = "Memo = '" + sTempData + "'";
			//                MySelectedRow = dsDatafromXLS.Tables["Items"].Select(sMyFilter);
			//                tbItemsInGroup.Text = MySelectedRow.Length.ToString();
			//                btnAddToList_Click(sender, System.EventArgs.Empty);
			//                cbCustomerProgram.SelectedIndex = skuIndex;
			//            }
			//            btnAutoCreateBatch_Click(sender, System.EventArgs.Empty);

			//        }
			//        catch(Exception ex)
			//        {
			//            string a = ex.Message;
			//        }
			

			//    }
			
			//}
			bLoadingFromXML = false;
		}
     
    }
}
