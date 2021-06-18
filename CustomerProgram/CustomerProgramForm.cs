#region Usings
using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Cntrls;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
//using System.Diagnostics;

#endregion Usings
namespace gemoDream
{
	/// <summary>
	/// The form serves customer programs
	/// </summary>
	public class CustomerProgramForm : Form
	{
		//private readonly bool bIsCPCopy;
		private bool isChanged = false;

		//private bool IsNeedTo
		//private int iAccessLevel = -1;
		//private readonly int iPrevOpsTreeIndex = -1;
		//private bool IsNeedToSavePricing = 
		//private readonly bool IsPricingEnabled = true;
		//private readonly bool IsAddRangeNeeded = false;
		private bool isTbComments = true;
		private int itemTypeID = 0;

		private int skuItemTypeID = 0;

		private DataSet dsPricing;

		private DataView dvMeasures = null;
		private DataSet dsParts = null;
		private DataSet dsCustPrograms = null;
		private DocumentProps dpPropsB = null;

		private readonly ArrayList newOperationsList = new ArrayList();
		private int iDocumentsCount;
		//private readonly bool IsFixedPrice = true;
		//private readonly int PrevOTGID = 0;
		//private readonly DataSet dsCOGP;
		//private readonly DataSet dsOTGRP;
		//private readonly DataSet dsOpsPrcs = null;
		//private readonly DataSet dsAllCaratRanges = null;
		//private readonly DataSet dsCustomerPrices = null;
		private readonly int AccessLevel;

		private bool SaveBulk = false;

		DataView dvData;
		DataSet dsDocs;
		DataSet dsOps;
		DataSet dsRight;
		DataSet dsMeasureGroups;
		//DataSet dsParts;
		DataSet dsMeasureValues;
		DataSet dsCP;
		DataTable dtCustomers;
		DataSet dsDocOperations;
		string CPOfficeID_CPID;
		string selected;
		public enum SaveCPmode
		{
			Save,
			SaveAs,
			SaveAsLocal
		}
		public enum SKULoadMode
		{
			Main,
			Instance,
			New
		}
		// mvs
		SKULoadMode skuMode;
		bool IsCustomerSelected = false;
		bool IsVendorSelected = false;
		public static bool IsLoadCPInstance = false;

		//int iCPInstanceLoad = 0;
		bool IsLoadFromItemizn = false;
		bool IsClearBatchCode = false;
		string m_sBatchCode = "";
		string m_sGroupCode = "";
		string m_sBatch3Code = "";
		private const string ClearBatchCodeOnSuccessOrFailure = "false";


		// mvs

		#region Controls

		private ImageList imageList1;
		private ImageList imageList2;
		private TabPage tabPage1;
		private TabPage tabPage2;
		private Label label2;
		private Label label3;
		private TabPage tabPage4;
		//private System.Windows.Forms.Panel panel3;
		//private Cntrls.ItemPanel ipItems;
		private ComboBox comboBoxD4;
		private CheckBox checkBoxPD4;
		private ComboBox comboBoxD3;
		private CheckBox checkBoxPD3;
		private ComboBox comboBoxD2;
		private CheckBox checkBoxPD2;
		private ComboBox comboBoxD1;
		private CheckBox checkBoxPD1;
		private Label lbCustProgName;
		private TextBox tbCustProgName;
		private CheckBox chbSameVendor;
		private TabControl tcOpsReqs;
		private Button bNewCustProg;
		private Button bSaveCustProg;
		private CheckBox chbDefEnabled;
		private TabControl tcDocs;
		private Button bNewDoc;
		private CheckBox chbReturn;
		private GroupBox gbDoc;
		private Button bDocDelete;
		private Button bOpMoveRightAll;
		private Button bOpMoveRight;
		private Button bMoveLeft;
		private Button bOpMoveLeftAll;
		internal StatusBar sbStatus;
		private ComboTextComponent ctcCustomer;
		private ComboTextComponent ctcVendor;
		private ItemPanel ipItems;
		private TabPage tabPage6;
		private DocumentProps documentProps1;
		private TabPage tabPage7;
		private TextBox tbDescription;
		private TextBox tbComments;
		private ImageList imageList3;
		private DataGrid dgRechecks;
		private PartTree ptrOpsLeft;
		private PartTree ptrOpsRight;
		private Label label1;
		private TextBox tbPicPath;
		private TextBox tbDescriptions;
		private Label lbDescription;
		private Label lbComments;
		private TextBox tbCustomerStyle;
		private Button bSaveCustProgAs;
		private Button bSaveBulk;
		private ComboBox cbCustomerProgram;
		private Label Customerstyle;
		private Label lbBatchCode;
		private TextBox tbBatchCode;
		private Label lbCPPropertyCustomerID;
		private TextBox tbCPPropertyCustomerID;
		private TextBox tbSRP;
		private Label labelSRP;
		private ListBox listBox1;
		private Label lbParts;
		private Label lbCharacteristics;
		private PartTreeEx partTree1;
		private TabPage tabPage3;
		private CheckBox chbShowDefDoc1;
		private CheckBox chbShowDefDoc2;
		private CheckBox chbShowDefDoc3;
		private CheckBox chbShowDefDoc4;
		private Button bReloadSKU_List;
		//private Cntrls.DocumentProps documentProps1;
		private IContainer components;
		#endregion Controls

		public CustomerProgramForm()
		{
			InitializeComponent();
			Init();
		}

		public string GetCPOfficeID_CPID()
		{
			return this.CPOfficeID_CPID;
		}

		public CustomerProgramForm(int AccessLevel)
		{
			InitializeComponent();
			Init();
			this.AccessLevel = AccessLevel;
		}


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
		/// 
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerProgramForm));
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.imageList2 = new System.Windows.Forms.ImageList(this.components);
			this.chbSameVendor = new System.Windows.Forms.CheckBox();
			this.sbStatus = new System.Windows.Forms.StatusBar();
			this.tcOpsReqs = new System.Windows.Forms.TabControl();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.bDocDelete = new System.Windows.Forms.Button();
			this.bNewDoc = new System.Windows.Forms.Button();
			this.tcDocs = new System.Windows.Forms.TabControl();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.gbDoc = new System.Windows.Forms.GroupBox();
			this.chbShowDefDoc4 = new System.Windows.Forms.CheckBox();
			this.chbShowDefDoc3 = new System.Windows.Forms.CheckBox();
			this.chbShowDefDoc2 = new System.Windows.Forms.CheckBox();
			this.chbShowDefDoc1 = new System.Windows.Forms.CheckBox();
			this.comboBoxD1 = new System.Windows.Forms.ComboBox();
			this.dgRechecks = new System.Windows.Forms.DataGrid();
			this.chbReturn = new System.Windows.Forms.CheckBox();
			this.tbDescription = new System.Windows.Forms.TextBox();
			this.comboBoxD4 = new System.Windows.Forms.ComboBox();
			this.comboBoxD3 = new System.Windows.Forms.ComboBox();
			this.comboBoxD2 = new System.Windows.Forms.ComboBox();
			this.checkBoxPD4 = new System.Windows.Forms.CheckBox();
			this.checkBoxPD3 = new System.Windows.Forms.CheckBox();
			this.checkBoxPD2 = new System.Windows.Forms.CheckBox();
			this.checkBoxPD1 = new System.Windows.Forms.CheckBox();
			this.chbDefEnabled = new System.Windows.Forms.CheckBox();
			this.tabPage6 = new System.Windows.Forms.TabPage();
			this.tabPage7 = new System.Windows.Forms.TabPage();
			this.partTree1 = new Cntrls.PartTreeEx();
			this.lbCharacteristics = new System.Windows.Forms.Label();
			this.lbParts = new System.Windows.Forms.Label();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.lbDescription = new System.Windows.Forms.Label();
			this.lbComments = new System.Windows.Forms.Label();
			this.tbDescriptions = new System.Windows.Forms.TextBox();
			this.tbComments = new System.Windows.Forms.TextBox();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.ptrOpsRight = new Cntrls.PartTree();
			this.ptrOpsLeft = new Cntrls.PartTree();
			this.bOpMoveLeftAll = new System.Windows.Forms.Button();
			this.bMoveLeft = new System.Windows.Forms.Button();
			this.bOpMoveRight = new System.Windows.Forms.Button();
			this.bOpMoveRightAll = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.bNewCustProg = new System.Windows.Forms.Button();
			this.bSaveCustProg = new System.Windows.Forms.Button();
			this.lbCustProgName = new System.Windows.Forms.Label();
			this.tbCustProgName = new System.Windows.Forms.TextBox();
			this.imageList3 = new System.Windows.Forms.ImageList(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.tbPicPath = new System.Windows.Forms.TextBox();
			this.tbCustomerStyle = new System.Windows.Forms.TextBox();
			this.Customerstyle = new System.Windows.Forms.Label();
			this.bSaveCustProgAs = new System.Windows.Forms.Button();
			this.bSaveBulk = new System.Windows.Forms.Button();
			this.cbCustomerProgram = new System.Windows.Forms.ComboBox();
			this.lbBatchCode = new System.Windows.Forms.Label();
			this.tbBatchCode = new System.Windows.Forms.TextBox();
			this.lbCPPropertyCustomerID = new System.Windows.Forms.Label();
			this.tbCPPropertyCustomerID = new System.Windows.Forms.TextBox();
			this.tbSRP = new System.Windows.Forms.TextBox();
			this.labelSRP = new System.Windows.Forms.Label();
			this.bReloadSKU_List = new System.Windows.Forms.Button();
			this.ctcVendor = new Cntrls.ComboTextComponent();
			this.ctcCustomer = new Cntrls.ComboTextComponent();
			this.ipItems = new Cntrls.ItemPanel();
			this.documentProps1 = new Cntrls.DocumentProps();
			this.tcOpsReqs.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tcDocs.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.gbDoc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgRechecks)).BeginInit();
			this.tabPage7.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.SuspendLayout();
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(32, 32);
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// imageList2
			// 
			this.imageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList2.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// chbSameVendor
			// 
			this.chbSameVendor.Checked = true;
			this.chbSameVendor.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chbSameVendor.Location = new System.Drawing.Point(390, 25);
			this.chbSameVendor.Name = "chbSameVendor";
			this.chbSameVendor.Size = new System.Drawing.Size(100, 25);
			this.chbSameVendor.TabIndex = 1;
			this.chbSameVendor.Text = "the same as Customer";
			this.chbSameVendor.CheckedChanged += new System.EventHandler(this.chbSameVendor_CheckedChanged);
			// 
			// sbStatus
			// 
			this.sbStatus.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.sbStatus.Location = new System.Drawing.Point(0, 689);
			this.sbStatus.Name = "sbStatus";
			this.sbStatus.Size = new System.Drawing.Size(956, 15);
			this.sbStatus.TabIndex = 8;
			this.sbStatus.Text = "StatusBar";
			// 
			// tcOpsReqs
			// 
			this.tcOpsReqs.Controls.Add(this.tabPage2);
			this.tcOpsReqs.Controls.Add(this.tabPage7);
			this.tcOpsReqs.Controls.Add(this.tabPage1);
			this.tcOpsReqs.Controls.Add(this.tabPage3);
			this.tcOpsReqs.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.tcOpsReqs.ItemSize = new System.Drawing.Size(235, 16);
			this.tcOpsReqs.Location = new System.Drawing.Point(0, 285);
			this.tcOpsReqs.Name = "tcOpsReqs";
			this.tcOpsReqs.Padding = new System.Drawing.Point(6, 2);
			this.tcOpsReqs.SelectedIndex = 0;
			this.tcOpsReqs.Size = new System.Drawing.Size(956, 407);
			this.tcOpsReqs.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			this.tcOpsReqs.TabIndex = 16;
			this.tcOpsReqs.SelectedIndexChanged += new System.EventHandler(this.tcOpsReqs_SelectedIndexChanged);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.bDocDelete);
			this.tabPage2.Controls.Add(this.bNewDoc);
			this.tabPage2.Controls.Add(this.tcDocs);
			this.tabPage2.Location = new System.Drawing.Point(4, 20);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(948, 383);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Requirements";
			// 
			// bDocDelete
			// 
			this.bDocDelete.BackColor = System.Drawing.Color.LightPink;
			this.bDocDelete.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.bDocDelete.Location = new System.Drawing.Point(550, 0);
			this.bDocDelete.Name = "bDocDelete";
			this.bDocDelete.Size = new System.Drawing.Size(190, 20);
			this.bDocDelete.TabIndex = 0;
			this.bDocDelete.Text = "De&lete Document";
			this.bDocDelete.UseVisualStyleBackColor = false;
			this.bDocDelete.Click += new System.EventHandler(this.bDocDelete_Click);
			// 
			// bNewDoc
			// 
			this.bNewDoc.BackColor = System.Drawing.Color.LightSteelBlue;
			this.bNewDoc.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.bNewDoc.Location = new System.Drawing.Point(745, 0);
			this.bNewDoc.Name = "bNewDoc";
			this.bNewDoc.Size = new System.Drawing.Size(190, 20);
			this.bNewDoc.TabIndex = 1;
			this.bNewDoc.Text = "New &Document";
			this.bNewDoc.UseVisualStyleBackColor = false;
			this.bNewDoc.Click += new System.EventHandler(this.bNew_Click);
			// 
			// tcDocs
			// 
			this.tcDocs.Controls.Add(this.tabPage4);
			this.tcDocs.Controls.Add(this.tabPage6);
			this.tcDocs.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.tcDocs.ItemSize = new System.Drawing.Size(344, 14);
			this.tcDocs.Location = new System.Drawing.Point(0, 5);
			this.tcDocs.Name = "tcDocs";
			this.tcDocs.SelectedIndex = 0;
			this.tcDocs.Size = new System.Drawing.Size(948, 373);
			this.tcDocs.TabIndex = 2;
			// 
			// tabPage4
			// 
			this.tabPage4.BackColor = System.Drawing.SystemColors.Control;
			this.tabPage4.Controls.Add(this.gbDoc);
			this.tabPage4.Controls.Add(this.chbDefEnabled);
			this.tabPage4.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.tabPage4.Location = new System.Drawing.Point(4, 18);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(940, 351);
			this.tabPage4.TabIndex = 1;
			this.tabPage4.Text = "Default";
			// 
			// gbDoc
			// 
			this.gbDoc.Controls.Add(this.chbShowDefDoc4);
			this.gbDoc.Controls.Add(this.chbShowDefDoc3);
			this.gbDoc.Controls.Add(this.chbShowDefDoc2);
			this.gbDoc.Controls.Add(this.chbShowDefDoc1);
			this.gbDoc.Controls.Add(this.comboBoxD1);
			this.gbDoc.Controls.Add(this.dgRechecks);
			this.gbDoc.Controls.Add(this.chbReturn);
			this.gbDoc.Controls.Add(this.tbDescription);
			this.gbDoc.Controls.Add(this.comboBoxD4);
			this.gbDoc.Controls.Add(this.comboBoxD3);
			this.gbDoc.Controls.Add(this.comboBoxD2);
			this.gbDoc.Controls.Add(this.checkBoxPD4);
			this.gbDoc.Controls.Add(this.checkBoxPD3);
			this.gbDoc.Controls.Add(this.checkBoxPD2);
			this.gbDoc.Controls.Add(this.checkBoxPD1);
			this.gbDoc.Enabled = false;
			this.gbDoc.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.gbDoc.Location = new System.Drawing.Point(5, 25);
			this.gbDoc.Name = "gbDoc";
			this.gbDoc.Size = new System.Drawing.Size(920, 323);
			this.gbDoc.TabIndex = 1;
			this.gbDoc.TabStop = false;
			this.gbDoc.Text = "What to do.";
			// 
			// chbShowDefDoc4
			// 
			this.chbShowDefDoc4.Location = new System.Drawing.Point(340, 100);
			this.chbShowDefDoc4.Name = "chbShowDefDoc4";
			this.chbShowDefDoc4.Size = new System.Drawing.Size(100, 15);
			this.chbShowDefDoc4.TabIndex = 14;
			this.chbShowDefDoc4.Text = "View Template";
			this.chbShowDefDoc4.CheckedChanged += new System.EventHandler(this.chbShowDefDoc4_CheckedChanged);
			// 
			// chbShowDefDoc3
			// 
			this.chbShowDefDoc3.Location = new System.Drawing.Point(340, 75);
			this.chbShowDefDoc3.Name = "chbShowDefDoc3";
			this.chbShowDefDoc3.Size = new System.Drawing.Size(100, 15);
			this.chbShowDefDoc3.TabIndex = 13;
			this.chbShowDefDoc3.Text = "View Template";
			this.chbShowDefDoc3.CheckedChanged += new System.EventHandler(this.chbShowDefDoc3_CheckedChanged);
			// 
			// chbShowDefDoc2
			// 
			this.chbShowDefDoc2.Location = new System.Drawing.Point(340, 50);
			this.chbShowDefDoc2.Name = "chbShowDefDoc2";
			this.chbShowDefDoc2.Size = new System.Drawing.Size(100, 15);
			this.chbShowDefDoc2.TabIndex = 12;
			this.chbShowDefDoc2.Text = "View Template";
			this.chbShowDefDoc2.CheckedChanged += new System.EventHandler(this.chbShowDefDoc2_CheckedChanged);
			// 
			// chbShowDefDoc1
			// 
			this.chbShowDefDoc1.Location = new System.Drawing.Point(340, 25);
			this.chbShowDefDoc1.Name = "chbShowDefDoc1";
			this.chbShowDefDoc1.Size = new System.Drawing.Size(100, 15);
			this.chbShowDefDoc1.TabIndex = 11;
			this.chbShowDefDoc1.Text = "View Template";
			this.chbShowDefDoc1.CheckedChanged += new System.EventHandler(this.chbShowDefDoc1_CheckedChanged);
			// 
			// comboBoxD1
			// 
			this.comboBoxD1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxD1.Enabled = false;
			this.comboBoxD1.Location = new System.Drawing.Point(5, 20);
			this.comboBoxD1.MaxDropDownItems = 20;
			this.comboBoxD1.Name = "comboBoxD1";
			this.comboBoxD1.Size = new System.Drawing.Size(220, 20);
			this.comboBoxD1.TabIndex = 1;
			this.comboBoxD1.SelectionChangeCommitted += new System.EventHandler(this.ComboBoxD1_SelectionChangeCommitted);
			this.comboBoxD1.Enter += new System.EventHandler(this.comboBoxD1_Enter);
			// 
			// dgRechecks
			// 
			this.dgRechecks.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dgRechecks.CaptionBackColor = System.Drawing.SystemColors.ControlLight;
			this.dgRechecks.CaptionVisible = false;
			this.dgRechecks.DataMember = "";
			this.dgRechecks.HeaderFont = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.dgRechecks.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgRechecks.Location = new System.Drawing.Point(645, 20);
			this.dgRechecks.Name = "dgRechecks";
			this.dgRechecks.PreferredRowHeight = 12;
			this.dgRechecks.Size = new System.Drawing.Size(270, 215);
			this.dgRechecks.TabIndex = 9;
			this.dgRechecks.Enter += new System.EventHandler(this.dgRechecks_Enter);
			// 
			// chbReturn
			// 
			this.chbReturn.Location = new System.Drawing.Point(10, 240);
			this.chbReturn.Name = "chbReturn";
			this.chbReturn.Size = new System.Drawing.Size(210, 15);
			this.chbReturn.TabIndex = 10;
			this.chbReturn.Text = "Return Item to Customer";
			// 
			// tbDescription
			// 
			this.tbDescription.Location = new System.Drawing.Point(5, 120);
			this.tbDescription.Multiline = true;
			this.tbDescription.Name = "tbDescription";
			this.tbDescription.Size = new System.Drawing.Size(220, 115);
			this.tbDescription.TabIndex = 8;
			this.tbDescription.Enter += new System.EventHandler(this.tbDescription_Enter);
			// 
			// comboBoxD4
			// 
			this.comboBoxD4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxD4.Enabled = false;
			this.comboBoxD4.Location = new System.Drawing.Point(5, 95);
			this.comboBoxD4.MaxDropDownItems = 20;
			this.comboBoxD4.Name = "comboBoxD4";
			this.comboBoxD4.Size = new System.Drawing.Size(220, 20);
			this.comboBoxD4.TabIndex = 7;
			this.comboBoxD4.SelectionChangeCommitted += new System.EventHandler(this.comboBoxD4_SelectionChangeCommitted);
			this.comboBoxD4.Enter += new System.EventHandler(this.comboBoxD1_Enter);
			// 
			// comboBoxD3
			// 
			this.comboBoxD3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxD3.Enabled = false;
			this.comboBoxD3.Location = new System.Drawing.Point(5, 70);
			this.comboBoxD3.MaxDropDownItems = 20;
			this.comboBoxD3.Name = "comboBoxD3";
			this.comboBoxD3.Size = new System.Drawing.Size(220, 20);
			this.comboBoxD3.TabIndex = 5;
			this.comboBoxD3.SelectionChangeCommitted += new System.EventHandler(this.comboBoxD3_SelectionChangeCommitted);
			this.comboBoxD3.Enter += new System.EventHandler(this.comboBoxD1_Enter);
			// 
			// comboBoxD2
			// 
			this.comboBoxD2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxD2.Enabled = false;
			this.comboBoxD2.Location = new System.Drawing.Point(5, 45);
			this.comboBoxD2.MaxDropDownItems = 20;
			this.comboBoxD2.Name = "comboBoxD2";
			this.comboBoxD2.Size = new System.Drawing.Size(220, 20);
			this.comboBoxD2.TabIndex = 3;
			this.comboBoxD2.SelectionChangeCommitted += new System.EventHandler(this.comboBoxD2_SelectionChangeCommitted);
			this.comboBoxD2.Enter += new System.EventHandler(this.comboBoxD1_Enter);
			// 
			// checkBoxPD4
			// 
			this.checkBoxPD4.Enabled = false;
			this.checkBoxPD4.Location = new System.Drawing.Point(230, 100);
			this.checkBoxPD4.Name = "checkBoxPD4";
			this.checkBoxPD4.Size = new System.Drawing.Size(109, 15);
			this.checkBoxPD4.TabIndex = 6;
			this.checkBoxPD4.Text = "Print Document";
			this.checkBoxPD4.CheckedChanged += new System.EventHandler(this.CheckBoxPD4_CheckedChanged);
			// 
			// checkBoxPD3
			// 
			this.checkBoxPD3.Enabled = false;
			this.checkBoxPD3.Location = new System.Drawing.Point(230, 75);
			this.checkBoxPD3.Name = "checkBoxPD3";
			this.checkBoxPD3.Size = new System.Drawing.Size(109, 15);
			this.checkBoxPD3.TabIndex = 4;
			this.checkBoxPD3.Text = "Print Document";
			this.checkBoxPD3.CheckedChanged += new System.EventHandler(this.CheckBoxPD3_CheckedChanged);
			// 
			// checkBoxPD2
			// 
			this.checkBoxPD2.Enabled = false;
			this.checkBoxPD2.Location = new System.Drawing.Point(230, 50);
			this.checkBoxPD2.Name = "checkBoxPD2";
			this.checkBoxPD2.Size = new System.Drawing.Size(109, 15);
			this.checkBoxPD2.TabIndex = 2;
			this.checkBoxPD2.Text = "Print Document";
			this.checkBoxPD2.CheckedChanged += new System.EventHandler(this.CheckBoxPD2_CheckedChanged);
			// 
			// checkBoxPD1
			// 
			this.checkBoxPD1.Location = new System.Drawing.Point(230, 25);
			this.checkBoxPD1.Name = "checkBoxPD1";
			this.checkBoxPD1.Size = new System.Drawing.Size(109, 15);
			this.checkBoxPD1.TabIndex = 0;
			this.checkBoxPD1.Text = "Print Document";
			this.checkBoxPD1.CheckedChanged += new System.EventHandler(this.CheckBoxPD1_CheckedChanged);
			// 
			// chbDefEnabled
			// 
			this.chbDefEnabled.Checked = true;
			this.chbDefEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chbDefEnabled.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.chbDefEnabled.Location = new System.Drawing.Point(10, 5);
			this.chbDefEnabled.Name = "chbDefEnabled";
			this.chbDefEnabled.Size = new System.Drawing.Size(84, 15);
			this.chbDefEnabled.TabIndex = 0;
			this.chbDefEnabled.Text = "Enabled";
			this.chbDefEnabled.CheckedChanged += new System.EventHandler(this.ChbDefEnabled_CheckedChanged);
			// 
			// tabPage6
			// 
			this.tabPage6.Location = new System.Drawing.Point(4, 18);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Size = new System.Drawing.Size(982, 351);
			this.tabPage6.TabIndex = 2;
			this.tabPage6.Text = "Documents";
			// 
			// tabPage7
			// 
			this.tabPage7.Controls.Add(this.partTree1);
			this.tabPage7.Controls.Add(this.lbCharacteristics);
			this.tabPage7.Controls.Add(this.lbParts);
			this.tabPage7.Controls.Add(this.listBox1);
			this.tabPage7.Controls.Add(this.lbDescription);
			this.tabPage7.Controls.Add(this.lbComments);
			this.tabPage7.Controls.Add(this.tbDescriptions);
			this.tabPage7.Controls.Add(this.tbComments);
			this.tabPage7.Location = new System.Drawing.Point(4, 20);
			this.tabPage7.Name = "tabPage7";
			this.tabPage7.Size = new System.Drawing.Size(948, 383);
			this.tabPage7.TabIndex = 2;
			this.tabPage7.Text = "Description";
			// 
			// partTree1
			// 
			this.partTree1.Location = new System.Drawing.Point(475, 25);
			this.partTree1.Name = "partTree1";
			this.partTree1.Size = new System.Drawing.Size(235, 305);
			this.partTree1.TabIndex = 18;
			this.partTree1.Changed += new System.EventHandler(this.partTree1_Changed);
			// 
			// lbCharacteristics
			// 
			this.lbCharacteristics.Location = new System.Drawing.Point(710, 5);
			this.lbCharacteristics.Name = "lbCharacteristics";
			this.lbCharacteristics.Size = new System.Drawing.Size(100, 15);
			this.lbCharacteristics.TabIndex = 17;
			this.lbCharacteristics.Text = "Characteristics";
			// 
			// lbParts
			// 
			this.lbParts.Location = new System.Drawing.Point(470, 5);
			this.lbParts.Name = "lbParts";
			this.lbParts.Size = new System.Drawing.Size(100, 15);
			this.lbParts.TabIndex = 16;
			this.lbParts.Text = "Parts";
			// 
			// listBox1
			// 
			this.listBox1.ItemHeight = 12;
			this.listBox1.Location = new System.Drawing.Point(710, 25);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(220, 304);
			this.listBox1.TabIndex = 15;
			this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
			// 
			// lbDescription
			// 
			this.lbDescription.Location = new System.Drawing.Point(10, 230);
			this.lbDescription.Name = "lbDescription";
			this.lbDescription.Size = new System.Drawing.Size(70, 15);
			this.lbDescription.TabIndex = 13;
			this.lbDescription.Text = "Comments";
			// 
			// lbComments
			// 
			this.lbComments.Location = new System.Drawing.Point(10, 10);
			this.lbComments.Name = "lbComments";
			this.lbComments.Size = new System.Drawing.Size(100, 15);
			this.lbComments.TabIndex = 12;
			this.lbComments.Text = "Description";
			// 
			// tbDescriptions
			// 
			this.tbDescriptions.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.tbDescriptions.Location = new System.Drawing.Point(5, 250);
			this.tbDescriptions.Multiline = true;
			this.tbDescriptions.Name = "tbDescriptions";
			this.tbDescriptions.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tbDescriptions.Size = new System.Drawing.Size(455, 85);
			this.tbDescriptions.TabIndex = 11;
			this.tbDescriptions.Enter += new System.EventHandler(this.tbDescriptions_Enter);
			// 
			// tbComments
			// 
			this.tbComments.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.tbComments.Location = new System.Drawing.Point(5, 30);
			this.tbComments.Multiline = true;
			this.tbComments.Name = "tbComments";
			this.tbComments.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tbComments.Size = new System.Drawing.Size(455, 190);
			this.tbComments.TabIndex = 10;
			this.tbComments.Enter += new System.EventHandler(this.tbComments_Enter);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.ptrOpsRight);
			this.tabPage1.Controls.Add(this.ptrOpsLeft);
			this.tabPage1.Controls.Add(this.bOpMoveLeftAll);
			this.tabPage1.Controls.Add(this.bMoveLeft);
			this.tabPage1.Controls.Add(this.bOpMoveRight);
			this.tabPage1.Controls.Add(this.bOpMoveRightAll);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Location = new System.Drawing.Point(4, 20);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(948, 383);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Operations";
			// 
			// ptrOpsRight
			// 
			this.ptrOpsRight.Location = new System.Drawing.Point(500, 20);
			this.ptrOpsRight.Name = "ptrOpsRight";
			this.ptrOpsRight.Size = new System.Drawing.Size(440, 315);
			this.ptrOpsRight.TabIndex = 1;
			this.ptrOpsRight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ptrOpsRight_KeyDown);
			this.ptrOpsRight.Enter += new System.EventHandler(this.ptrOpsRight_Enter);
			// 
			// ptrOpsLeft
			// 
			this.ptrOpsLeft.Location = new System.Drawing.Point(5, 20);
			this.ptrOpsLeft.Name = "ptrOpsLeft";
			this.ptrOpsLeft.Size = new System.Drawing.Size(440, 315);
			this.ptrOpsLeft.TabIndex = 0;
			this.ptrOpsLeft.Changed += new System.EventHandler(this.ptrOpsLeft_Changed);
			this.ptrOpsLeft.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ptrOpsLeft_KeyDown);
			this.ptrOpsLeft.Enter += new System.EventHandler(this.ptrOpsLeft_Enter);
			// 
			// bOpMoveLeftAll
			// 
			this.bOpMoveLeftAll.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.bOpMoveLeftAll.Image = ((System.Drawing.Image)(resources.GetObject("bOpMoveLeftAll.Image")));
			this.bOpMoveLeftAll.Location = new System.Drawing.Point(455, 125);
			this.bOpMoveLeftAll.Name = "bOpMoveLeftAll";
			this.bOpMoveLeftAll.Size = new System.Drawing.Size(30, 20);
			this.bOpMoveLeftAll.TabIndex = 5;
			this.bOpMoveLeftAll.Click += new System.EventHandler(this.bOpMoveLeftAll_Click);
			// 
			// bMoveLeft
			// 
			this.bMoveLeft.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.bMoveLeft.Image = ((System.Drawing.Image)(resources.GetObject("bMoveLeft.Image")));
			this.bMoveLeft.Location = new System.Drawing.Point(455, 100);
			this.bMoveLeft.Name = "bMoveLeft";
			this.bMoveLeft.Size = new System.Drawing.Size(30, 20);
			this.bMoveLeft.TabIndex = 4;
			this.bMoveLeft.Click += new System.EventHandler(this.bOpMoveLeft_Click);
			// 
			// bOpMoveRight
			// 
			this.bOpMoveRight.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.bOpMoveRight.Image = ((System.Drawing.Image)(resources.GetObject("bOpMoveRight.Image")));
			this.bOpMoveRight.Location = new System.Drawing.Point(455, 45);
			this.bOpMoveRight.Name = "bOpMoveRight";
			this.bOpMoveRight.Size = new System.Drawing.Size(30, 20);
			this.bOpMoveRight.TabIndex = 3;
			this.bOpMoveRight.Click += new System.EventHandler(this.bOpMoveRight_Click);
			// 
			// bOpMoveRightAll
			// 
			this.bOpMoveRightAll.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.bOpMoveRightAll.Image = ((System.Drawing.Image)(resources.GetObject("bOpMoveRightAll.Image")));
			this.bOpMoveRightAll.Location = new System.Drawing.Point(455, 20);
			this.bOpMoveRightAll.Name = "bOpMoveRightAll";
			this.bOpMoveRightAll.Size = new System.Drawing.Size(30, 20);
			this.bOpMoveRightAll.TabIndex = 2;
			this.bOpMoveRightAll.Click += new System.EventHandler(this.bOpMoveRightAll_Click);
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.label3.Location = new System.Drawing.Point(495, 5);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(330, 15);
			this.label3.TabIndex = 2;
			this.label3.Text = "Program operations";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(5, 5);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(330, 15);
			this.label2.TabIndex = 1;
			this.label2.Text = "Avaliable operations";
			// 
			// tabPage3
			// 
			this.tabPage3.Location = new System.Drawing.Point(4, 20);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(948, 383);
			this.tabPage3.TabIndex = 3;
			this.tabPage3.Text = "Pricing";
			// 
			// bNewCustProg
			// 
			this.bNewCustProg.BackColor = System.Drawing.Color.LightSteelBlue;
			this.bNewCustProg.Enabled = false;
			this.bNewCustProg.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.bNewCustProg.Location = new System.Drawing.Point(570, 260);
			this.bNewCustProg.Name = "bNewCustProg";
			this.bNewCustProg.Size = new System.Drawing.Size(75, 20);
			this.bNewCustProg.TabIndex = 14;
			this.bNewCustProg.Text = "New SKU";
			this.bNewCustProg.UseVisualStyleBackColor = false;
			this.bNewCustProg.Click += new System.EventHandler(this.bNewCustProg_Click);
			// 
			// bSaveCustProg
			// 
			this.bSaveCustProg.BackColor = System.Drawing.SystemColors.Control;
			this.bSaveCustProg.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.bSaveCustProg.Location = new System.Drawing.Point(655, 260);
			this.bSaveCustProg.Name = "bSaveCustProg";
			this.bSaveCustProg.Size = new System.Drawing.Size(45, 20);
			this.bSaveCustProg.TabIndex = 15;
			this.bSaveCustProg.Text = "&Save";
			this.bSaveCustProg.UseVisualStyleBackColor = false;
			this.bSaveCustProg.Click += new System.EventHandler(this.bSaveCustProg_Click);
			// 
			// lbCustProgName
			// 
			this.lbCustProgName.Location = new System.Drawing.Point(10, 263);
			this.lbCustProgName.Name = "lbCustProgName";
			this.lbCustProgName.Size = new System.Drawing.Size(40, 15);
			this.lbCustProgName.TabIndex = 12;
			this.lbCustProgName.Text = "SKU";
			// 
			// tbCustProgName
			// 
			this.tbCustProgName.Location = new System.Drawing.Point(40, 260);
			this.tbCustProgName.Name = "tbCustProgName";
			this.tbCustProgName.Size = new System.Drawing.Size(235, 20);
			this.tbCustProgName.TabIndex = 13;
			this.tbCustProgName.Text = "tbCustProgName";
			this.tbCustProgName.TextChanged += new System.EventHandler(this.tbCustProgName_TextChanged);
			this.tbCustProgName.Enter += new System.EventHandler(this.tbCustProgName_Enter);
			this.tbCustProgName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCustProgName_KeyDown);
			// 
			// imageList3
			// 
			this.imageList3.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList3.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList3.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(645, 30);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 15);
			this.label1.TabIndex = 9;
			this.label1.Text = "Picture";
			// 
			// tbPicPath
			// 
			this.tbPicPath.Location = new System.Drawing.Point(685, 25);
			this.tbPicPath.Name = "tbPicPath";
			this.tbPicPath.Size = new System.Drawing.Size(255, 20);
			this.tbPicPath.TabIndex = 10;
			this.tbPicPath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPicPath_KeyDown);
			// 
			// tbCustomerStyle
			// 
			this.tbCustomerStyle.Location = new System.Drawing.Point(710, 0);
			this.tbCustomerStyle.Name = "tbCustomerStyle";
			this.tbCustomerStyle.Size = new System.Drawing.Size(230, 20);
			this.tbCustomerStyle.TabIndex = 8;
			// 
			// Customerstyle
			// 
			this.Customerstyle.Location = new System.Drawing.Point(645, 5);
			this.Customerstyle.Name = "Customerstyle";
			this.Customerstyle.Size = new System.Drawing.Size(65, 15);
			this.Customerstyle.TabIndex = 7;
			this.Customerstyle.Text = "Cust. Style";
			// 
			// bSaveCustProgAs
			// 
			this.bSaveCustProgAs.Location = new System.Drawing.Point(710, 260);
			this.bSaveCustProgAs.Name = "bSaveCustProgAs";
			this.bSaveCustProgAs.Size = new System.Drawing.Size(60, 20);
			this.bSaveCustProgAs.TabIndex = 17;
			this.bSaveCustProgAs.Text = "&Save as";
			this.bSaveCustProgAs.Click += new System.EventHandler(this.bSaveCustProgAs_Click);
			// 
			// bSaveBulk
			// 
			this.bSaveBulk.Location = new System.Drawing.Point(780, 260);
			this.bSaveBulk.Name = "bSaveBulk";
			this.bSaveBulk.Size = new System.Drawing.Size(50, 20);
			this.bSaveBulk.TabIndex = 117;
			this.bSaveBulk.Text = "Bulk";
			this.bSaveBulk.Click += new System.EventHandler(this.bSaveBulk_Click);
			// 
			// cbCustomerProgram
			// 
			this.cbCustomerProgram.Location = new System.Drawing.Point(300, 260);
			this.cbCustomerProgram.Name = "cbCustomerProgram";
			this.cbCustomerProgram.Size = new System.Drawing.Size(255, 20);
			this.cbCustomerProgram.TabIndex = 18;
			this.cbCustomerProgram.Text = "Customer program lookup";
			this.cbCustomerProgram.SelectedIndexChanged += new System.EventHandler(this.cbCustomerProgram_SelectedIndexChanged);
			// 
			// lbBatchCode
			// 
			this.lbBatchCode.AutoSize = true;
			this.lbBatchCode.Location = new System.Drawing.Point(385, 5);
			this.lbBatchCode.Name = "lbBatchCode";
			this.lbBatchCode.Size = new System.Drawing.Size(35, 12);
			this.lbBatchCode.TabIndex = 3;
			this.lbBatchCode.Text = "Batch";
			// 
			// tbBatchCode
			// 
			this.tbBatchCode.Location = new System.Drawing.Point(425, 0);
			this.tbBatchCode.Name = "tbBatchCode";
			this.tbBatchCode.Size = new System.Drawing.Size(85, 20);
			this.tbBatchCode.TabIndex = 4;
			this.tbBatchCode.Text = "#####.###";
			this.tbBatchCode.TextChanged += new System.EventHandler(this.tbBatchCode_TextChanged);
			this.tbBatchCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbBatchCode_KeyPress);
			// 
			// lbCPPropertyCustomerID
			// 
			this.lbCPPropertyCustomerID.Location = new System.Drawing.Point(515, 5);
			this.lbCPPropertyCustomerID.Name = "lbCPPropertyCustomerID";
			this.lbCPPropertyCustomerID.Size = new System.Drawing.Size(50, 15);
			this.lbCPPropertyCustomerID.TabIndex = 5;
			this.lbCPPropertyCustomerID.Text = "Cust.ID";
			// 
			// tbCPPropertyCustomerID
			// 
			this.tbCPPropertyCustomerID.Location = new System.Drawing.Point(565, 0);
			this.tbCPPropertyCustomerID.Name = "tbCPPropertyCustomerID";
			this.tbCPPropertyCustomerID.Size = new System.Drawing.Size(70, 20);
			this.tbCPPropertyCustomerID.TabIndex = 6;
			// 
			// tbSRP
			// 
			this.tbSRP.Location = new System.Drawing.Point(565, 25);
			this.tbSRP.Name = "tbSRP";
			this.tbSRP.Size = new System.Drawing.Size(70, 20);
			this.tbSRP.TabIndex = 9;
			this.tbSRP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSRP_KeyPress);
			// 
			// labelSRP
			// 
			this.labelSRP.Location = new System.Drawing.Point(520, 30);
			this.labelSRP.Name = "labelSRP";
			this.labelSRP.Size = new System.Drawing.Size(30, 15);
			this.labelSRP.TabIndex = 13;
			this.labelSRP.Text = "SRP";
			// 
			// bReloadSKU_List
			// 
			this.bReloadSKU_List.Location = new System.Drawing.Point(845, 260);
			this.bReloadSKU_List.Name = "bReloadSKU_List";
			this.bReloadSKU_List.Size = new System.Drawing.Size(90, 20);
			this.bReloadSKU_List.TabIndex = 20;
			this.bReloadSKU_List.Text = "Reload SKU";
			this.bReloadSKU_List.Click += new System.EventHandler(this.bReloadSKU_List_Click);
			// 
			// ctcVendor
			// 
			this.ctcVendor.DefaultText = "Vendor lookup";
			this.ctcVendor.DisplayMember = "CustomerName";
			this.ctcVendor.Enabled = false;
			this.ctcVendor.InsertDefaultRow = true;
			this.ctcVendor.Location = new System.Drawing.Point(5, 25);
			this.ctcVendor.Name = "ctcVendor";
			this.ctcVendor.SelectedCode = "";
			this.ctcVendor.Size = new System.Drawing.Size(375, 21);
			this.ctcVendor.TabIndex = 2;
			this.ctcVendor.ValueMember = "CustomerOfficeID_CustomerID";
			this.ctcVendor.SelectionChanged += new System.EventHandler(this.ctcVendor_SelectionChanged);
			this.ctcVendor.Enter += new System.EventHandler(this.ctcVendor_Enter);
			// 
			// ctcCustomer
			// 
			this.ctcCustomer.DefaultText = "Customer lookup";
			this.ctcCustomer.DisplayMember = "CustomerName";
			this.ctcCustomer.InsertDefaultRow = true;
			this.ctcCustomer.Location = new System.Drawing.Point(5, 0);
			this.ctcCustomer.Name = "ctcCustomer";
			this.ctcCustomer.SelectedCode = "";
			this.ctcCustomer.Size = new System.Drawing.Size(375, 20);
			this.ctcCustomer.TabIndex = 0;
			this.ctcCustomer.ValueMember = "CustomerOfficeID_CustomerID";
			this.ctcCustomer.Enter += new System.EventHandler(this.ctcCustomer_Enter);
			// 
			// ipItems
			// 
			this.ipItems.CustomerID = 0;
			this.ipItems.Enabled = false;
			this.ipItems.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.ipItems.FullItemName = "Full Item Name";
			this.ipItems.initialized = false;
			this.ipItems.instanceLoaded = false;
			this.ipItems.ItemPicture = null;
			this.ipItems.ItemTypesInUse = null;
			this.ipItems.Location = new System.Drawing.Point(5, 50);
			this.ipItems.Name = "ipItems";
			this.ipItems.Size = new System.Drawing.Size(951, 205);
			this.ipItems.StructName = "";
			this.ipItems.TabIndex = 19;
			this.ipItems.Changed += new System.EventHandler(this.ipItems_Changed);
			this.ipItems.NewItemTypeSelected += new System.EventHandler(this.ipItems_NewItemTypeSelected);
			this.ipItems.ListViewDoubleClick += new System.EventHandler(this.ipItems_ListViewDoubleClick);
			this.ipItems.Enter += new System.EventHandler(this.ipItems_Enter);
			// 
			// documentProps1
			// 
			this.documentProps1.BackColor = System.Drawing.SystemColors.Control;
			this.documentProps1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.documentProps1.Location = new System.Drawing.Point(5, 5);
			this.documentProps1.Name = "documentProps1";
			this.documentProps1.Size = new System.Drawing.Size(925, 300);
			this.documentProps1.TabIndex = 0;
			// 
			// CustomerProgramForm
			// 
			this.ClientSize = new System.Drawing.Size(956, 704);
			this.Controls.Add(this.bReloadSKU_List);
			this.Controls.Add(this.tbSRP);
			this.Controls.Add(this.tbCPPropertyCustomerID);
			this.Controls.Add(this.tbBatchCode);
			this.Controls.Add(this.tbCustomerStyle);
			this.Controls.Add(this.tbPicPath);
			this.Controls.Add(this.tbCustProgName);
			this.Controls.Add(this.lbBatchCode);
			this.Controls.Add(this.chbSameVendor);
			this.Controls.Add(this.labelSRP);
			this.Controls.Add(this.lbCPPropertyCustomerID);
			this.Controls.Add(this.cbCustomerProgram);
			this.Controls.Add(this.bSaveCustProgAs);
			this.Controls.Add(this.bSaveBulk);
			this.Controls.Add(this.Customerstyle);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tcOpsReqs);
			this.Controls.Add(this.ctcVendor);
			this.Controls.Add(this.ctcCustomer);
			this.Controls.Add(this.ipItems);
			this.Controls.Add(this.lbCustProgName);
			this.Controls.Add(this.bSaveCustProg);
			this.Controls.Add(this.bNewCustProg);
			this.Controls.Add(this.sbStatus);
			this.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.Name = "CustomerProgramForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Customer Program Creation and Maintenance";
			this.VisibleChanged += new System.EventHandler(this.CustomerProgramForm_VisibleChanged);
			this.tcOpsReqs.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tcDocs.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.gbDoc.ResumeLayout(false);
			this.gbDoc.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgRechecks)).EndInit();
			this.tabPage7.ResumeLayout(false);
			this.tabPage7.PerformLayout();
			this.tabPage1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		#region CustomInitializing
		private void Init()
		{
			ipItems.ListItems.Enabled = true;
			skuMode = SKULoadMode.Main;
			this.Text = Service.sProgramTitle + this.Text;
			ctcCustomer.ComboField.cbField.SelectedIndex = -1;
			ctcVendor.ComboField.cbField.SelectedIndex = -1;
			ipItems.Initialize();
			cbCustomerProgram.Text = "Customer program lookup";
			cbCustomerProgram.SelectedIndex = -1;
			DataTable dt = Service.GetItemizn1_ItemsLibrary();//Procedure dbo.spGetItemTypeGroups
			ipItems.InitializeLibrary(dt);

			tbCustProgName.Text = "";
			tcOpsReqs.Enabled = false;

			bNewCustProg.Enabled = false;
			bSaveCustProg.Enabled = false;
			bSaveCustProgAs.Enabled = false;
			bDocDelete.Enabled = false;
			bNewDoc.Enabled = false;

			chbShowDefDoc1.Enabled = false;
			chbShowDefDoc2.Enabled = false;
			chbShowDefDoc3.Enabled = false;
			chbShowDefDoc4.Enabled = false;

			/*
            tbComments.Enabled = false;
            tbDescriptions.Enabled = false;
            tbCPPropertyCustomerID.Enabled = false;
            tbSRP.Enabled = false;
            tbCustomerStyle.Enabled = false;
            tbPicPath.Enabled = false;
*/
			ipItems.Changed += new EventHandler(ipItems_Changed);

			ctcCustomer.SelectionChanged += new EventHandler(ctcCustomer_SelectedIndexChanged);


			//Getting Customers from database
			InitCustomers();
			this.InitMeasures();
			//Vetal_242 06.20.2006 enable CheckBox in operation tree
			this.ptrOpsRight.tvPartTree.CheckBoxes = true;
			this.tbBatchCode.Text = "#####.###";
			this.tbBatchCode.Focus();
		}
		public void InitCustomers()
		{
			try
			{
				dtCustomers = Service.GetCustomers().Tables[0];//Procedure dbo.spGetCustomers
				ctcCustomer.Initialize(dtCustomers);
				ctcVendor.Initialize(dtCustomers);
			}
			catch
			{
				MessageBox.Show("Unable to connect to database", "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.Close();
			}
		}

		private void InitPartTree(string sItemTypeID)
		{
			dsParts = new DataSet();
			DataTable dtMeasureType = Service.GetMeasuresByItemType(sItemTypeID);//tblName : MeasuresByItemType / 1 - empty
			dtMeasureType.TableName = "Measures";

			dsParts.Tables.Add(dtMeasureType);      //tblName : Measures

			dsParts.Tables.Add(Service.GetParts(sItemTypeID));  //tblName : Parts
			dsParts.Tables.Add(Service.GetPartsStruct());   //tblName : SetParts

			this.partTree1.Initialize(dsParts.Tables["Parts"]);
			this.partTree1.ExpandTree();
		}

		private void MainButtonsEnabled(bool bState, int iMode)
		{
			//		switch (iMode)
			//		{
			//			case 0:		
			//				bSaveCustProg.Enabled = bState;
			//				bSaveCustProgAs.Enabled = bState;
			//				bNewCustProg.Enabled = bState;	
			//		}
		}


		private void InitMeasures()
		{
			DataSet dsMeasures = Service.GetMeasuresWithAdditional();//Procedure dbo.spGetMeasuresWithAdditional

			dvMeasures = new DataView(dsMeasures.Tables[0])
			{
				RowFilter = "1=0",
				Sort = "MeasureTitle"
			};

			this.listBox1.DataSource = dvMeasures;
			this.listBox1.ValueMember = "MeasureID";
			this.listBox1.DisplayMember = "MeasureTitle";
		}

		private void InitOpsLeft()
		{
			dsOps = Service.GetAllOperationsTree();//Procedure dbo.spGetOperationTree

			if (dsOps != null)
			{
				dsOps.Tables["OperationTree"].Columns["TreeParentID"].ColumnName = "ParentID";
				dsOps.Tables["OperationTree"].Columns["TreeID"].ColumnName = "ID";
				dsOps.Tables["OperationTree"].Columns["TreeItemName"].ColumnName = "Name";

				try
				{
					ptrOpsLeft.Initialize(dsOps.Tables["OperationTree"]);
					dsRight = ptrOpsLeft.Data.DataSet.Clone();
				}
				catch (Exception exc)
				{
					MessageBox.Show("Unable to connect to server. Reason: " + exc.Message, "Internal Error",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		/*
        private DataSet GetDocs(string sCPOfficeID, string sCPID)
        {
            DataSet dsIn = new DataSet();
            DataTable dtIn = dsIn.Tables.Add("DocsByCP");
            dtIn.Columns.Add("CPID", System.Type.GetType("System.String"));
            dtIn.Columns.Add("CPOfficeID", System.Type.GetType("System.String"));

            DataRow row = dtIn.NewRow();
            row["CPID"] = sCPID;
            row["CPOfficeID"] = sCPOfficeID;
				
            dtIn.Rows.Add(row);
            DataSet dsOut = Service.ProxyGenericGet(dsIn);
            return dsOut;
        }
        */

		private void ReInitDocs(string sCPOfficeID, string sCPID)
		{
			try
			{
				dsDocOperations = Service.GetDocs(sCPOfficeID, sCPID);//Procedure dbo.spGetDocsByCP

				DataView dvDocOperationsA = new DataView(dsDocOperations.Tables["DocsByCP"]);
				//dvDocOperationsA.Sort = "nOrder";

				DataView dvDocOperationsB = new DataView(dsDocOperations.Tables["DocsByCP"]/*.Copy()*/);
				//dvDocOperationsB.Sort = "nOrder";

				DataView dvDocOperationsC = new DataView(dsDocOperations.Tables["DocsByCP"]/*.Copy()*/);
				//dvDocOperationsC.Sort = "nOrder";

				DataView dvDocOperationsD = new DataView(dsDocOperations.Tables["DocsByCP"]/*.Copy()*/);
				//dvDocOperationsD.Sort = "nOrder";

				comboBoxD1.DataSource = dvDocOperationsA;
				//dsDocOperations.Tables["DocsByCP"].Copy();
				comboBoxD1.ValueMember = "OperationTypeOfficeID_OperationTypeID";
				//comboBoxD1.DisplayMember = "OperationTypeName";
				comboBoxD1.DisplayMember = "OperationTypeName";

				comboBoxD2.DataSource = dvDocOperationsB;
				//dsDocOperations.Tables["DocsByCP"].Copy();
				comboBoxD2.ValueMember = "OperationTypeOfficeID_OperationTypeID";
				//comboBoxD2.DisplayMember = "OperationTypeName";
				comboBoxD2.DisplayMember = "OperationTypeName";

				comboBoxD3.DataSource = dvDocOperationsC;
				//dsDocOperations.Tables["DocsByCP"].Copy();
				comboBoxD3.ValueMember = "OperationTypeOfficeID_OperationTypeID";
				//comboBoxD3.DisplayMember = "OperationTypeName";
				comboBoxD3.DisplayMember = "OperationTypeName";

				comboBoxD4.DataSource = dvDocOperationsD;
				//dsDocOperations.Tables["DocsByCP"].Copy();
				comboBoxD4.ValueMember = "OperationTypeOfficeID_OperationTypeID";
				//comboBoxD4.DisplayMember = "OperationTypeName";
				comboBoxD4.DisplayMember = "OperationTypeName";

			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Can't init documents. Reason: " + ex.ToString(),
					"Internal error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void InitDocs(string s)
		{
			MessageBox.Show(s);
		}

		private void InitMeasuresRechecks()
		{
			dsMeasureGroups = Service.GetMeasureGroups();//Procedure dbo.spGetMeasureGroups

			DataTable dt1 = new DataTable("Rechecks");
			dt1.Columns.Add("Property_Name");
			dt1.Columns.Add("Rechecks", typeof(byte));
			dt1.Columns.Add("Do", typeof(bool));
			foreach (DataRow drNext in dsMeasureGroups.Tables[0].Rows)
			{
				dt1.Rows.Add(new object[] { drNext["MeasureGroupName"].ToString(), "0", false });
			}

			DataView dvTable = new DataView(dt1)
			{
				AllowDelete = false,
				AllowNew = false
			};

			dvData = new DataView(dt1.Copy());

			if (dgRechecks.TableStyles.Count > 0)
				dgRechecks.TableStyles.Clear();
			dgRechecks.TableStyles.Add(DefaultTableStyle());
			dgRechecks.RowHeadersVisible = false;

			dgRechecks.DataSource = dvTable;
		}

		private void InitMeasuresRechecks(DataGrid dgTarget, DataTable dtSource, DataGridTableStyle tsStyle)
		{
			dsMeasureGroups = Service.GetMeasureGroups();

			DataTable dt1 = new DataTable("Rechecks");
			dt1.Columns.Add("Property_Name");
			dt1.Columns.Add("Rechecks", typeof(byte));
			dt1.Columns.Add("Do", typeof(bool));
			foreach (DataRow drNext in dsMeasureGroups.Tables[0].Rows)
			{
				dt1.Rows.Add(new object[] { drNext["MeasureGroupName"].ToString(), "0", false });
			}
			DataRow drSel;
			foreach (DataRow drNext in dtSource.Rows)
			{
				drSel = dt1.Select("Property_Name='" + drNext["Property_Name"].ToString() + "'")[0];
				drSel["Do"] = Convert.ToBoolean(drNext["Do"]);
				drSel["Rechecks"] = Convert.ToByte(drNext["Rechecks"]);
			}

			DataView dvTable = new DataView(dt1)
			{
				AllowDelete = false,
				AllowNew = false
			};

			dvData = new DataView(dt1.Copy());

			dgTarget.TableStyles.Clear();
			dgTarget.TableStyles.Add(tsStyle);
			dgTarget.RowHeadersVisible = false;

			dgTarget.DataSource = dvTable;
		}
		#endregion CustomInitializing

		//		private static void Main()
		//		{
		//			Application.Run(new CustomerProgramForm());
		//		}

		#region Recheck_Properties_datagrid_fill
		private DataGridTableStyle DefaultTableStyle()
		{
			DataGridTableStyle ts1 = new DataGridTableStyle
			{
				MappingName = "Rechecks"
			};
			ts1.HeaderFont = new Font(ts1.HeaderFont.FontFamily, ts1.HeaderFont.Size, FontStyle.Bold);
			ts1.PreferredRowHeight = 10;
			ts1.RowHeadersVisible = false;

			DataGridColumnStyle tcProp = new DataGridTextBoxColumn
			{
				MappingName = "Property_Name",
				HeaderText = "Property Name",
				Width = 170,
				ReadOnly = true,
				Alignment = HorizontalAlignment.Center
			};
			ts1.GridColumnStyles.Add(tcProp);

			DataGridColumnStyle tcRechecks = new DataGridTextBoxColumn
			{
				MappingName = "Rechecks",
				HeaderText = "Rechecks",
				Width = 70,
				Alignment = HorizontalAlignment.Center,
				NullText = "0"
			};
			ts1.GridColumnStyles.Add(tcRechecks);

			DataGridColumnStyle boolCol = new DataGridBoolColumn
			{
				MappingName = "Do",
				HeaderText = "Do",
				Width = 25
			};

			ts1.GridColumnStyles.Add(boolCol);

			return ts1;
		}


		//new document
		private DataGridTableStyle NewTableStyle()
		{
			DataGridTableStyle ts1 = new DataGridTableStyle
			{
				MappingName = "Rechecks"
			};
			ts1.HeaderFont = new Font(ts1.HeaderFont.FontFamily, ts1.HeaderFont.Size, FontStyle.Bold);
			ts1.PreferredRowHeight = 10;
			ts1.RowHeadersVisible = false;

			DataGridColumnStyle tcProp = new DataGridTextBoxColumn
			{
				MappingName = "Property_Name",
				HeaderText = "Property Name",
				Width = 130,
				ReadOnly = true,
				Alignment = HorizontalAlignment.Center
			};
			ts1.GridColumnStyles.Add(tcProp);

			DataGridColumnStyle tcRechecks = new DataGridTextBoxColumn
			{
				MappingName = "Rechecks",
				HeaderText = "Rechecks",
				Width = 70,
				Alignment = HorizontalAlignment.Center,
				NullText = "0"
			};
			ts1.GridColumnStyles.Add(tcRechecks);

			DataGridColumnStyle boolCol = new DataGridBoolColumn
			{
				MappingName = "Do",
				HeaderText = "Do",
				Width = 25
			};

			ts1.GridColumnStyles.Add(boolCol);

			return ts1;
		}

		#endregion Recheck Properties-datagrid fill


		#region DefaultDocument
		//PrintDoc CheckBoxes handlers
		#region PrintDocCheckBoxes
		private void CheckBoxPD1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxPD1.Checked)
			{
				checkBoxPD2.Enabled = true;
			}
			else
			{
				checkBoxPD2.Enabled = false;
			}
			CheckPDState();
			chbShowDefDoc1.Enabled = checkBoxPD1.Checked;
		}

		private void CheckBoxPD2_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxPD2.Checked)
			{
				checkBoxPD3.Enabled = true;

			}
			else
				checkBoxPD3.Enabled = false;
			CheckPDState();
			chbShowDefDoc2.Enabled = checkBoxPD2.Checked;
		}

		private void CheckBoxPD3_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxPD3.Checked)
				checkBoxPD4.Enabled = true;
			else
				checkBoxPD4.Enabled = false;
			CheckPDState();
			chbShowDefDoc3.Enabled = checkBoxPD3.Checked;

		}

		private void CheckBoxPD4_CheckedChanged(object sender, EventArgs e)
		{
			CheckPDState();
			chbShowDefDoc4.Enabled = checkBoxPD4.Checked;
		}

		private void CheckPDState()
		{
			if (checkBoxPD1.Checked)
			{
				comboBoxD1.Enabled = true;
				checkBoxPD2.Enabled = true;
			}
			else
			{
				comboBoxD1.Enabled = false;
				checkBoxPD2.Enabled = false;
				checkBoxPD2.Checked = false;
			}
			if (checkBoxPD2.Enabled && checkBoxPD2.Checked)
			{
				comboBoxD2.Enabled = true;
				checkBoxPD3.Enabled = true;
			}
			else
			{
				comboBoxD2.Enabled = false;
				checkBoxPD3.Enabled = false;
				checkBoxPD3.Checked = false;
			}
			if (checkBoxPD3.Enabled && checkBoxPD3.Checked)
			{
				comboBoxD3.Enabled = true;
				checkBoxPD4.Enabled = true;
			}
			else
			{
				comboBoxD3.Enabled = false;
				checkBoxPD4.Enabled = false;
				checkBoxPD4.Checked = false;
			}
			if (checkBoxPD4.Enabled && checkBoxPD4.Checked)
			{
				comboBoxD4.Enabled = true;
			}
			else
			{
				comboBoxD4.Enabled = false;
			}
		}
		#endregion PrintDocCheckBoxes

		//Default Document: CheckBox.Checked.Changed handler
		private void ChbDefEnabled_CheckedChanged(object sender, EventArgs e)
		{
			gbDoc.Enabled = chbDefEnabled.Checked;
		}


		/*
        private string AddOperation(ComboBox comboBox, string sItemTypeID, string sPath2Picture, string sOperationTypeName)
        {
            char separator = '_';
            string sCPOfficeID = "";
            string sCPID = "";
			
         defDocForm;
            if (CPOfficeID_CPID.Length != 0)
            {
                string[] sCPOfficeID_CPID = CPOfficeID_CPID.Split(separator);
                sCPOfficeID = sCPOfficeID_CPID[0];
                sCPID = sCPOfficeID_CPID[1];
                defDocForm = new DefineDocumentForm(
                    sItemTypeID, sPath2Picture, sOperationTypeName, sCPOfficeID, sCPID);
            }
            else
            {
                defDocForm = new DefineDocumentForm(
                    sItemTypeID, sPath2Picture, sOperationTypeName);
            }

            defDocForm.ShowDialog(this);
            string sDocumentID = defDocForm.GetDocumentID();
            if (sDocumentID == null)
                return null;

            this.iDocumentsCount++;

            string sOperationTypeOfficeID_OperationTypeID = defDocForm.GetOperationTypeOfficeID_OperationTypeID();
            if (sOperationTypeOfficeID_OperationTypeID != null)
            {
                DataView dv = (DataView)comboBox.DataSource;
                DataRow newRow = dv.Table.NewRow();

                newRow["OperationTypeOfficeID_OperationTypeID"] = sOperationTypeOfficeID_OperationTypeID;
                newRow["OperationTypeName"] = sOperationTypeName;
                //newRow["nOrder"] = ;
                dv.Table.Rows.Add(newRow);

                string[] sOperationTypeOfficeID_OperationTypeIDs = sOperationTypeOfficeID_OperationTypeID.Split(separator);
                string sOperationTypeOfficeID = sOperationTypeOfficeID_OperationTypeIDs[1];
                string sOperationTypeID = sOperationTypeOfficeID_OperationTypeIDs[0];
			
                DefineDocumentForm.NewOperationData nod = new DefineDocumentForm.NewOperationData();
                nod.sCPID = sCPID;
                nod.sCPOfficeID = sCPOfficeID;
                nod.sOperationTypeID = sOperationTypeID;
                nod.sOperationTypeOfficeID = sOperationTypeOfficeID;
                this.newOperationsList.Add(nod);
            }

            return sOperationTypeOfficeID_OperationTypeID;
        }
        */

		//		DefineDocumentForm.DefDocType GetDocTypeCode(string sID)
		//		{
		//			if (sID.Equals("-3_3"))
		//				return DefineDocumentForm.DefDocType.MDX;
		//			if (sID.Equals("-2_2"))
		//				return DefineDocumentForm.DefDocType.FDX;
		//			return DefineDocumentForm.DefDocType.IDX;
		//		}

		private void OnComboBoxSelectionChange(ref ComboBox comboBox, ref CheckBox chbShowDoc)
		{
			if (comboBox.SelectedValue != null)
			{
				DataView dv = (DataView)comboBox.DataSource;
				DataTable dt = dv.Table.Copy();
				string sID = comboBox.SelectedValue.ToString();
				DataRow[] foundRows;
				foundRows = dt.Select("OperationTypeOfficeID_OperationTypeID = '" + sID + "'");

				string sItemTypeID = ipItems.itemId;
				//this.ipItems.itemId;
				//string sPath2Picture = this.tbPicPath.Text.ToString();
				string sPath2Picture = this.tbPicPath.Text.ToString();

				string sDocTypeCode = null;
				string sOperationTypeName = null;
				string sOperationTypeID = null;

				if (foundRows.Length == 1)
				{
					sDocTypeCode = foundRows[0]["DocumentTypeCode"].ToString();
					sOperationTypeName = foundRows[0]["OperationTypeName"].ToString();
					sOperationTypeID = foundRows[0]["OperationTypeOfficeID_OperationTypeID"].ToString();
				}
				else
					return;

				//				sName = comboBox.Text.ToString();
				//				string sDocTypeCode = dv[0]["DocumentTypeCode"].ToString(); //((System.Data.DataRow)(((System.Data.DataRowView)(((System.Object)(comboBox.SelectedItem)))).Row)).ItemArray[4].ToString();
				//				sName = dv[0]["OperationTypeName"].ToString();//comboBox.Text.ToString();

				//////////////				string sID = comboBox.SelectedValue.ToString();
				//////////////				string sItemTypeID = this.ipItems.itemId;
				//////////////				string sPath2Picture = this.tbPicPath.Text.ToString();
				//////////////				string sOperationDocID;
				//////////////				string sDocumentID;
				//			string sName = comboBox.Text.ToString();
				//			int iDocumentsCountA;
				//			if (CPOfficeID_CPID.Length == 0)
				//			{
				//				iDocumentsCountA = this.newOperationsList.Count + 1;
				//			}
				//			else
				//			{
				//				string[] sIDs = CPOfficeID_CPID.Split('_');
				//				string sCPOfficeID = sIDs[0];
				//				string sCPID = sIDs[1];
				//				iDocumentsCountA = this.GetDocumentsCount(sCPOfficeID, sCPID);
				//				iDocumentsCountA++;
				//				//iDocumentsCountA = iDocumentsCount + 1;
				//			}

				//			string sOperationTypeName = String.Format("{0} {1}", sName, iDocumentsCountA);

				//			if (sID.Equals("-3_3") || //MDX Document
				//				sID.Equals("-2_2") || //FDX Document
				//				sID.Equals("-1_1"))   //IDX Document
				//if (sID.Equals("0_0"))
				if (Service.IsMagicOperation(sID) || chbShowDoc.Checked == true)
				{
					//chbShowDoc.Checked = false;

					//					string sOperationTypeID = sID;
					DataSet dsNotVCCM = null;
					if (this.tcDocs.TabPages.Count > 1)
					{
						DocumentProps dp = (DocumentProps)this.tcDocs.TabPages[1].Controls[0];
						dsNotVCCM = dp.GetRulez();
						//gemoDream.Service.debug_DiaspalyDataSet(dsNotVCCM);
					}

					//DefineDocumentForm.DocTypeCode docTypeCode = DefineDocumentForm.GetDocTypeCodeEnumByID(sID);

					//					string sOperationTypeName = comboBox.Text;
					string sCPName = this.tbCustProgName.Text.Trim();
					if (this.AccessLevel >= 2)
					{
						string sOTOID_OTID = DefineDocumentForm.AddOperation(
							this.AccessLevel,
							null, //dsNotVCCM,
							this.newOperationsList,
							CPOfficeID_CPID,
							this,
							comboBox,
							sItemTypeID,
							sPath2Picture,
							sOperationTypeName,
							sDocTypeCode,
							sOperationTypeID,
							sCPName);
						if (sOTOID_OTID != null)
							comboBox.SelectedValue = sOTOID_OTID;
						//						else
						//							comboBox.SelectedIndex = 0;
					}
					chbShowDoc.Checked = false;
					//					string sOTOID_OTID = 
					//						DefineDocumentForm.AddOperation(
					//						this.AccessLevel,
					//						dsNotVCCM,
					//						this.newOperationsList,
					//						CPOfficeID_CPID, 
					//						this,
					//						comboBox, 
					//						sItemTypeID, 
					//						sPath2Picture, 
					//						sOperationName,
					//						sDocTypeCode,
					//						null,
					//						sCPName);
					//
					//					if (sOTOID_OTID != null)
					//						comboBox.SelectedValue = sOTOID_OTID;

				}
			}

		}


		//Checking if there is the same document in chosen ones
		private void ComboBoxD1_SelectionChangeCommitted(object sender, EventArgs e)
		{
			isChanged = true;
			OnComboBoxSelectionChange(ref comboBoxD1, ref chbShowDefDoc1);
			//CheckSameDocs(sender);
		}

		private void CheckSameDocs(object sender)
		{
			bool isSame = false;
			ComboBox[] acbDocs = new ComboBox[] { comboBoxD1, comboBoxD2, comboBoxD3, comboBoxD4 };
			for (int i = 0; i < acbDocs.Length; i++)
			{
				if ((ComboBox)sender != acbDocs[i])
				{
					if (((ComboBox)sender).SelectedValue == acbDocs[i].SelectedValue)
						isSame = true;
				}
			}
			if (isSame && ((ComboBox)sender).SelectedIndex > -1)
			{
				((ComboBox)sender).SelectedIndex--;
				sbStatus.Text = "You cannot print two same documents";
			}
		}

		#endregion DefaultDocument




		#region CPCommon
		//Operations Tab buttons handlers
		#region OperationsMoves
		private void bOpMoveRightAll_Click(object sender, EventArgs e)
		{
			//DataRow[] adrAll = ptrOpsLeft.Data.Select("ParentID<>''");// + DBNull.Value.ToString());

			//foreach(DataRow dr in ptrOpsLeft.Data.Rows)
			//{
			//	DoRight(dr["ID"].ToString());
			//}

			/*DataSet dsNew = new DataSet();
            dsNew.Tables.Add(ptrOpsLeft.Data.Copy());
            ptrOpsRight.Initialize(dsNew.Tables[0]);
            */
			for (int n = 0; n < ptrOpsLeft.tvPartTree.Nodes.Count; n++)
			{
				ptrOpsLeft.tvPartTree.SelectedNode = ptrOpsLeft.tvPartTree.Nodes[n];//.Text.ToString();

				ArrayList alRows = MovePartRight(ptrOpsLeft.SelectedRow["ID"].ToString(), new ArrayList());
				try
				{
					for (int i = alRows.Count - 1; i > -1; i--)
					{
						if (dsRight.Tables["OperationTree"].Select("ID = '" + ((DataRow)alRows[i])["ID"] + "'").Length == 0)
							dsRight.Tables["OperationTree"].Rows.Add(((DataRow)alRows[i]).ItemArray);
					}
				}
				catch
				{
					alRows.Reverse();

					for (int i = alRows.Count - 1; i > -1; i--)
					{
						if (dsRight.Tables["OperationTree"].Select("ID = '" + ((DataRow)alRows[i])["ID"] + "'").Length == 0)
							dsRight.Tables["OperationTree"].Rows.Add(((DataRow)alRows[i]).ItemArray);
					}
				}
			}
			ptrOpsRight.Initialize(dsRight.Tables["OperationTree"]);
			ptrOpsRight.ExpandTree();

			dsRight = new DataSet();
			dsRight.Tables.Add(ptrOpsRight.Data.Copy());
		}

		private void bOpMoveRight_Click(object sender, EventArgs e)
		{
			if (ptrOpsLeft.SelectedNode != null)
			{
				ArrayList alRows = MovePartRight(ptrOpsLeft.SelectedRow["ID"].ToString(), new ArrayList());

				try
				{
					for (int i = alRows.Count - 1; i > -1; i--)
					{
						if (dsRight.Tables["OperationTree"].Select("ID = '" + ((DataRow)alRows[i])["ID"] + "'").Length == 0)
							dsRight.Tables["OperationTree"].Rows.Add(((DataRow)alRows[i]).ItemArray);
					}
				}
				catch
				{
					alRows.Reverse();

					for (int i = alRows.Count - 1; i > -1; i--)
					{
						if (dsRight.Tables["OperationTree"].Select("ID = '" + ((DataRow)alRows[i])["ID"] + "'").Length == 0)
							dsRight.Tables["OperationTree"].Rows.Add(((DataRow)alRows[i]).ItemArray);
					}
				}
				ptrOpsRight.Initialize(dsRight.Tables["OperationTree"]);
				ptrOpsRight.ExpandTree();
			}
			else
				sbStatus.Text = "One unit must be selected to move";
			//DebugDataTable(dsRight.Tables[0].Copy(), "OP_MOVE_RIGHT");
		}

		private void DebugDataTable(DataTable dtDebug, string comments)
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.Append(comments).Append('\n');
			for (int i = 0; i < dtDebug.Rows.Count; i++)
			{
				for (int j = 0; j < dtDebug.Columns.Count; j++)
				{
					sb.Append(dtDebug.Columns[j].ColumnName).Append("	:	");
					sb.Append(dtDebug.Rows[i][j].ToString()).Append('\n');
				}
			}
			MessageBox.Show(sb.ToString());
		}

		private void DoRight(string id)
		{
			ArrayList alRows = MovePartRight(id, new ArrayList());

			for (int i = alRows.Count - 1; i > -1; i--)
			{
				if (dsRight.Tables["OperationTree"].Select("ID = '" + ((DataRow)alRows[i])["ID"].ToString() + "'").Length == 0)
					dsRight.Tables["OperationTree"].Rows.Add(((DataRow)alRows[i]).ItemArray);
			}
			ptrOpsRight.Initialize(dsRight.Tables["OperationTree"]);
			Object t = ptrOpsRight.tvPartTree.Nodes[0].Nodes[0].Tag;
		}

		private ArrayList MovePartRight(string id, ArrayList alRows)
		{
			alRows = MoveChildrenRight(id, alRows);
			alRows = MoveParentsRight(id, alRows);

			return alRows;
		}

		private ArrayList MoveParentsRight(string id, ArrayList alRows)
		{
			DataRow[] drTry;
			DataRow drLeft = ptrOpsLeft.Data.Select("ID = '" + id + "'")[0];
			alRows.Add(drLeft);

			drTry = ptrOpsLeft.Data.Select("ID='" + drLeft["ParentID"].ToString() + "'");
			DataRow[] drSelected = ptrOpsLeft.Data.Select("ID='" + selected + "'");

			if (drTry.Length > 0 && !alRows.Contains(drTry[0]))
				MoveParentsRight(drTry[0]["ID"].ToString(), alRows);

			return alRows;
		}

		private ArrayList MoveChildrenRight(string id, ArrayList alRows)
		{
			DataRow[] drChldrn;
			DataRow drLeft = ptrOpsLeft.Data.Select("ID = '" + id + "'")[0];
			alRows.Add(drLeft);

			drChldrn = ptrOpsLeft.Data.Select("ParentID='" + drLeft["ID"].ToString() + "'");
			DataRow[] drSelected = ptrOpsLeft.Data.Select("ID='" + selected + "'");

			if (drChldrn.Length > 0 && !alRows.Contains(drChldrn[0]) && drSelected.Length > 0)// && drSelected[0]["OperationTypeID"] != DBNull.Value)
				foreach (DataRow dr in drChldrn)
					MoveChildrenRight(dr["ID"].ToString(), alRows);

			return alRows;
		}

		private void bOpMoveLeft_Click(object sender, EventArgs e)
		{
			if (ptrOpsRight.SelectedNode != null)
			{
				DataViewManager dvm = new DataViewManager(ptrOpsRight.Data.DataSet);
				dvm.DataSet.Tables[0].Rows.Remove(ptrOpsRight.SelectedRow);
				ptrOpsRight.Initialize(ptrOpsRight.Data);
				ptrOpsRight.ExpandTree();
			}
			else
				sbStatus.Text = "One unit must be selected to move";
		}

		private void bOpMoveLeftAll_Click(object sender, EventArgs e)
		{
			DataViewManager dvm = new DataViewManager(ptrOpsRight.Data.DataSet);
			ptrOpsRight.Clear();
			ptrOpsRight.Data.Constraints.Clear();
			ptrOpsRight.Data.DataSet.Relations.Clear();
			ptrOpsRight.Data.Rows.Clear();
			dsRight = new DataSet();
			dsRight.Tables.Add(ptrOpsRight.Data.Clone());
		}
		#endregion OperationsMoves

		//CheckBox Same Vendor as Customer handler
		private void chbSameVendor_CheckedChanged(object sender, EventArgs e)
		{
			ipItems.ListItems.Enabled = true;
			ctcVendor.Enabled = !chbSameVendor.Checked;
			if (chbSameVendor.Checked)
			{
				if (ctcCustomer.SelectedCode != "0" && ctcCustomer.SelectedCode != "")
				{
					//ctcVendor.TextField.Text = ctcCustomer.TextField.Text;
					//ctcVendor.ComboField.cbField.SelectedValue = ctcCustomer.ComboField.cbField.SelectedValue;
					ctcVendor.ComboField.cbField.SelectedIndex = ctcCustomer.ComboField.cbField.SelectedIndex;
				}
				else
				{
					ctcVendor.SelectedCode = "";
				}
			}
		}


		//Customer lookup changed
		private void ctcCustomer_SelectedIndexChanged(object sender, EventArgs e)
		{
			ipItems.ListItems.Enabled = true;

			Service.SetDepartmentOfficeId(ctcCustomer.SelectedID.Split('_')[0]);
			//ctcVendor.Enabled = false;
			//chbSameVendor.Checked = true;
			//tbCustProgName.Enabled = true;
			//cbCustomerProgram.Enabled = true;
			//bSaveCustProgAs.Enabled = true;
			//bNewCustProg.Enabled = true;

			/*
                if (iCPInstanceLoad == 0)
                {
                    //tbBatchCode.Text = "#####.###";
                    isCPInstanceLoad = false;
                }
                else
                    iCPInstanceLoad--;
                */
			//this.bIsCPCopy = false;


			if (IsCustomerSelected != true)
				IsLoadCPInstance = false;
			IsCustomerSelected = false;
			if (ClearBatchCodeOnSuccessOrFailure == "true")
				IsClearBatchCode = false;

			if (!IsLoadCPInstance)
			{
				tbBatchCode.Text = "#####.###";
				tbCustProgName.Enabled = true;
				cbCustomerProgram.Enabled = true;

				if (this.AccessLevel > 2)
				{
					bSaveCustProgAs.Enabled = true;
					bNewCustProg.Enabled = true;
				}
				if (this.AccessLevel == 2) bSaveCustProgAs.Enabled = true;
				else bSaveCustProgAs.Enabled = false;
			}

			#region InitializeMRU
			this.Cursor = Cursors.WaitCursor;
			if (chbSameVendor.Checked)
				if (ctcCustomer.ComboField.cbField.SelectedValue.ToString() == "0" ||
					ctcCustomer.ComboField.cbField.SelectedValue.ToString() == "")
					ctcVendor.SelectedCode = "0";
				else
				{
					string str = ctcCustomer.ComboField.cbField.SelectedValue.ToString();
					//mvs
					IsVendorSelected = true;

					for (int ii = 0; ii < ctcVendor.ComboField.cbField.Items.Count; ii++)
					{
						if (((DataRowView)ctcVendor.ComboField.cbField.Items[ii])[1].ToString() == str)
						{
							ctcVendor.ComboField.cbField.SelectedIndex = ii;
							break;
						}
					}

					//ctcVendor.ComboField.cbField.SelectedValue = str;
				}

			if (!IsLoadCPInstance)
			{
				if (ctcCustomer.SelectedCode != "0" && ctcVendor.SelectedCode != "0" &&
				ctcCustomer.SelectedCode != "" && ctcVendor.SelectedCode != "")
				{
					ipItems.InitializeMRU(ctcCustomer.ComboField.cbField.SelectedValue.ToString().Split(new char[] { '_' })[0],
						ctcCustomer.ComboField.cbField.SelectedValue.ToString().Split(new char[] { '_' })[1],
						ctcVendor.ComboField.cbField.SelectedValue.ToString().Split(new char[] { '_' })[0],
						ctcVendor.ComboField.cbField.SelectedValue.ToString().Split(new char[] { '_' })[1]);//Procedure dbo.spGetMRUItems,dbo.spGetMeasuresByItemType, dbo.spGetPartsByItemType					
				}
				else ClearAll();
			}
			#endregion
			cbCustomerProgram.Items.Clear();
			cbCustomerProgram.Text = "Customer program lookup";
			cbCustomerProgram.SelectedIndex = -1;
			tbCustProgName.Text = "";
			// mvs
			ClearAll();

			try
			{
				//if (!IsLoadCPInstance)
				{
					DataSet dsTmp1 = new DataSet();

					dsTmp1.Tables.Add("CustomerProgramsPerCustomer");
					dsTmp1.Tables["CustomerProgramsPerCustomer"].Columns.Add(new DataColumn("CustomerOfficeID", Type.GetType("System.String")));
					dsTmp1.Tables["CustomerProgramsPerCustomer"].Columns.Add(new DataColumn("CustomerID", Type.GetType("System.String")));
					dsTmp1.Tables["CustomerProgramsPerCustomer"].Columns.Add(new DataColumn("VendorOfficeID", Type.GetType("System.String")));
					dsTmp1.Tables["CustomerProgramsPerCustomer"].Columns.Add(new DataColumn("VendorID", Type.GetType("System.String")));
					DataRow row = dsTmp1.Tables["CustomerProgramsPerCustomer"].NewRow();

					string[] sIDc = ctcCustomer.SelectedID.Split('_');
					string[] sIDv = ctcVendor.SelectedID.Split('_');

					if (chbSameVendor.Checked)
					{
						if (sIDc.Length > 1)
						{
							row["CustomerID"] = sIDc[1];
							ipItems.CustomerID = Convert.ToInt32(sIDc[1]);
						}
						else
						{
							row["CustomerID"] = "0";
							ipItems.CustomerID = 0;
						}
						row["CustomerOfficeID"] = sIDc[0];
						row["VendorOfficeID"] = DBNull.Value;
						row["VendorID"] = DBNull.Value;

					}
					else
					{
						if (sIDc.Length > 1)
						{
							row["CustomerID"] = sIDc[1];
							ipItems.CustomerID = Convert.ToInt32(sIDc[1]);
						}
						else
						{
							row["CustomerID"] = "0";
							ipItems.CustomerID = 0;
						}
						row["CustomerOfficeID"] = sIDc[0];
						row["VendorOfficeID"] = sIDv[0];
						row["VendorID"] = sIDv[1];
					}
					dsTmp1.Tables["CustomerProgramsPerCustomer"].Rows.Add(row);
					dsTmp1.AcceptChanges();
					dsCustPrograms = Service.ProxyGenericGet(dsTmp1); //Procedure spGetCustomerProgramsPerCustomer

					/*
						DataView dv = new DataView(dsCustPrograms.Tables[0]);

						cbCustomerProgram.DataSource = dv;
							//dsCustPrograms;
						cbCustomerProgram.DisplayMember="CustomerProgramName";
						cbCustomerProgram.ValueMember="CPOfficeID_CPID";
						*/

					if (dsCustPrograms.Tables[0].Rows.Count > 0)
					{
						/*
						ItemTypesInUse = (from DataRow drow indsCustPrograms.Tables[0]
										  where (!drow["Typeid"].ToString().Contains("_") || drow["Typeid"].ToString().Trim() == "")
										  select drow["id"].ToString()).Distinct().ToList();
						 */
						ipItems.ItemTypesInUse = (from DataRow drow in dsCustPrograms.Tables[0].Rows select drow["ItemTypeID"].ToString()).Distinct().ToList();

						foreach (DataRow r in dsCustPrograms.Tables[0].Rows)
						{
							cbCustomerProgram.Items.Add(r["CustomerProgramName"]);
						}


						//ipItems.ListItems.Items.Clear();
						//ListViewItem lvi;
						//ipItems.ListItems.View = View.Details;
						//ipItems.ListItems.AllowColumnReorder = true;
						//ipItems.ListItems.FullRowSelect = true;
						//ipItems.ListItems.BackColor = Color.White;
						//var i = 0;
						//foreach (DataRow r in dsCustPrograms.Tables[0].Rows)
						//{
						//	cbCustomerProgram.Items.Add(r["CustomerProgramName"]);
						//	if (ipItems.ItemTypesInUse.Contains(r["ItemTypeID"].ToString()))
						//	{
						//		var a = r["ItemTypeID"].ToString();
						//		lvi = new ListViewItem("");
						//		lvi.Tag = r["ItemTypeID"].ToString();
						//		lvi.SubItems.Add(r["CustomerProgramName"].ToString().ToUpper().Replace("ITEM CONTAINER", "IC"));
						//		ipItems.ListItems.Items.Add(lvi);
						//		i++;
						//	}
						//}
						if (cbCustomerProgram.SelectedIndex == -1)
						{
							bSaveCustProg.Enabled = false;
							bSaveCustProgAs.Enabled = false;
						}
						if (!IsLoadCPInstance)
							ipItems.LoadItemitemTypeView(false, "0");

					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}

			this.Cursor = Cursors.Default;
		}

		private void ClearAll()
		{
			CPOfficeID_CPID = "";

			//vetal_242 05.31.2006

			if (this.AccessLevel >= 2)
			{
				bNewCustProg.Enabled = true;
				bSaveCustProg.Enabled = true;
				bSaveCustProgAs.Enabled = true;
				bDocDelete.Enabled = true;
				bNewDoc.Enabled = true;

				tbComments.Enabled = true;
				tbDescriptions.Enabled = true;
				tbCPPropertyCustomerID.Enabled = true;
				tbSRP.Enabled = true;
				tbCustomerStyle.Enabled = true;
				tbPicPath.Enabled = true;

			}
			else
			{
				bNewCustProg.Enabled = false;
				bSaveCustProg.Enabled = false;

				if (this.AccessLevel == 2) bSaveCustProgAs.Enabled = true;

				bDocDelete.Enabled = false;
				bNewDoc.Enabled = false;
				/*
                                tbComments.Enabled = false;
                                tbDescriptions.Enabled = false;
                                tbCPPropertyCustomerID.Enabled = false;
                                tbSRP.Enabled = false;
                                tbCustomerStyle.Enabled = false;
                                tbPicPath.Enabled = false;
                */
			}

			ipItems.Enabled = true;
			int iCount = tcDocs.TabCount;
			for (int i = 1; i < iCount; i++)
				tcDocs.TabPages.Remove(tcDocs.TabPages[1]);

			chbDefEnabled.Checked = false;
			comboBoxD1.SelectedIndex = -1;
			comboBoxD2.SelectedIndex = -1;
			comboBoxD3.SelectedIndex = -1;
			comboBoxD4.SelectedIndex = -1;

			checkBoxPD1.Checked = false;
			checkBoxPD2.Checked = false;
			checkBoxPD3.Checked = false;
			checkBoxPD4.Checked = false;

			chbReturn.Checked = false;

			gbDoc.Enabled = false;

			this.tbCPPropertyCustomerID.Text = "";
			this.tbSRP.Text = "";
			tbCustomerStyle.Text = "";
			tbComments.Text = "";
			tbDescriptions.Text = "";
			tbDescription.Text = "";
			tbPicPath.Text = "";
			ipItems.InitializePicture(null);
			//tbCustProgName.Text = "";
			//tbCustProgName.Focus();
			tcOpsReqs.Enabled = false;

			try
			{
				bOpMoveLeftAll_Click(this, EventArgs.Empty);
			}
			catch (Exception exc)
			{
				string str = exc.Message;
			}

			try
			{
				((DataView)(dgRechecks.DataSource)).Table.Rows.Clear();
			}
			catch { }

			InitOpsLeft();//Procedures dbo.spGetDocsByCP, dbo.spGetOperationTree
						  //InitDocs("ClearAll");
			this.ReInitDocs("-1", "-1");
			InitMeasuresRechecks();
		}


		private void ipItems_Changed(object sender, EventArgs ea)
		{
			if (ipItems.ItemId != null && tbCustProgName.Text.Trim() != "")
				tcOpsReqs.Enabled = true;
			else
				tcOpsReqs.Enabled = false;

			if (ipItems.ItemName != "" && this.AccessLevel > 2)
				bNewCustProg.Enabled = true;

			//this.InitPartTree(ipItems.ItemId);


			//			dsParts = new DataSet();	
			//			dsParts.Tables.Add(Service.GetMeasuresByItemType(sItemTypeID));	//tblName : Measures
			//			dsParts.Tables.Add(Service.GetParts(sItemTypeID));	//tblName : Parts
			//			dsParts.Tables.Add(Service.GetPartsStruct());	//tblName : SetParts				
			//		}
			//		catch(Exception exc)
			//		{
			//			sbStatus.Text = "Unable to get parts info from server";
			//		}
		}


		//New Customer Program button handler
		private void bNewCustProg_Click(object sender, EventArgs e)
		{
			ipItems.LoadItemitemTypeView(true, "-2");
			CPOfficeID_CPID = "";

			if (ctcCustomer.SelectedCode == "0" || ctcVendor.SelectedCode == "0" ||
				ctcCustomer.SelectedCode == "" || ctcVendor.SelectedCode == "")
			{
				MessageBox.Show("Customer and Vendor must be selected", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				ctcCustomer.Focus();
				return;
			}

			DataSet dsCPCheck = Service.GetCPByNameAndCustomer(tbCustProgName.Text.Trim(),
				ctcCustomer.ComboField.cbField.SelectedValue.ToString(),
				ctcVendor.ComboField.cbField.SelectedValue.ToString());
			if (dsCPCheck.Tables[0].Rows.Count > 0)
				if (MessageBox.Show("Customer program with this name already exists. Would you like to load it?",
					"Found customer program with this name", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
					DialogResult.No)
				{
					tbCustProgName.Focus();
					return;
				}
				else
				{
					KeyEventArgs kea = new KeyEventArgs(Keys.Enter);
					tbCustProgName_KeyDown(this, kea);
					return;
				}

			if (tbCustProgName.Text.Trim() != "" && ctcCustomer.TextField.Text != "" && ctcVendor.TextField.Text != "")
			{
				ClearAll();
				//create in CP default document CertifiedLabel
				//03.06.2006
				//by Vetal_242
				//chbDefEnabled.Checked = true;
				//checkBoxPD1.Checked = true;
				//dsDocOperations = Service.GetDocs("-1", "-2");
				//DataView dvDocOperationsA = new DataView(dsDocOperations.Tables["DocsByCP"]);
				//comboBoxD1.DataSource = dvDocOperationsA;
				ipItems.Focus();
			}
			else
			{
				sbStatus.Text = "Enter customer program name, select Customer and Vendor to proceed";
				ctcCustomer.Focus();
			}
		}


		//Load Customer Program
		private void tbCustProgName_KeyDown(object sender, KeyEventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			if (e.KeyCode == Keys.Enter)
			{
				if (tbCustProgName.Text.Trim() != "")
				{
					if (dsCustPrograms.Tables[0].Rows.Count > 0)
					{
						DataRow[] drCPList = dsCustPrograms.Tables[0].Select("CustomerProgramName = '" + tbCustProgName.Text.Trim() + "'");
						if (drCPList.Length == 1)
						{
							//if(this.cbCustomerProgram.SelectedItem.ToString().ToUpper() != tbCustProgName.Text.Trim().ToUpper()) 
							this.cbCustomerProgram.SelectedItem = drCPList[0]["CustomerProgramName"];
							//LoadCP(tbCustProgName.Text);
						}
						else
							MessageBox.Show("Wrong Customer Program Name. Please, check it again", "Check CP Name",
								MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

						/*
                        char separator = '_';
                        string[] sCPOfficeID_CPID = CPOfficeID_CPID.Split(separator);
                        string sCPOfficeID = sCPOfficeID_CPID[0];
                        string sCPID = sCPOfficeID_CPID[1];

                        this.iDocumentsCount = this.GetDocumentsCount(sCPOfficeID, sCPID);
                        */
					}
				}
			}
			this.Cursor = Cursors.Default;
		}


		//Just status bar notice
		private void tbComments_Enter(object sender, EventArgs e)
		{
			sbStatus.Text = "Program comments";
			this.isTbComments = true;
		}


		//Itempanel tree group changed
		private void ipItems_NewItemTypeSelected(object sender, EventArgs e)
		{

			DataTable dt;
			if (skuMode == SKULoadMode.Main && !ipItems.initialized) dt = Service.GetItemizn1_ItemsSubtypesList("0");
			else dt = Service.GetItemizn1_ItemsSubtypesList(ipItems.TypeId);  //Procedure spGetItemTypesByGroup 
			ipItems.InitializeItems(dt);
		}

		private void ipItems_ListViewDoubleClick(object sender, EventArgs e)
		{
			if (skuMode == SKULoadMode.Instance) return;
			var structureName = "";
			ipItems.ListItems.BackColor = Color.White;
			foreach (ListViewItem item in ipItems.ListItems.Items)
			{
				item.BackColor = Color.White;
				if (item.Selected)
				{
					itemTypeID = Convert.ToInt32(item.Tag.ToString());
					structureName = item.SubItems[1].Text;
					item.BackColor = Color.SkyBlue;
					break;
				}
			}
			//if (tbCustProgName.Text.Trim() == "" && itemTypeID != 0)
			//{
			//	cbCustomerProgram.Items.Clear();
			//	cbCustomerProgram.Text = "Customer program lookup";
			//	cbCustomerProgram.SelectedIndex = -1;
			//}
			if (dsCustPrograms.Tables[0].Rows.Count > 0)
			{
				DataRow[] rows = dsCustPrograms.Tables[0].Select("ItemTypeID = '" + itemTypeID + "'");
				if (rows.Length > 0)
				{
					cbCustomerProgram.Items.Clear();
					cbCustomerProgram.Text = "Customer program lookup";
					cbCustomerProgram.SelectedIndex = -1;

					foreach (DataRow row in rows)
					{
						cbCustomerProgram.Items.Add(row["CustomerProgramName"]);
					}
					MessageBox.Show("All SKUs with structure\n" + structureName + "\nloaded successfully", "Structure " + structureName);
				}
				else
				{
					MessageBox.Show("Customer " + ctcCustomer.TextField + " has no customer programs with structure " + structureName);
				}
			}
		}

		#endregion CPCommon
		#region NotDefaultDocument
		//New Document button handler
		private void bNew_Click(object sender, EventArgs e)
		{
			//Measure values
			dsMeasureValues = new DataSet();
			dsMeasureValues.Tables.Add(Service.GetMeasureValues());

			DataSet ds = Service.GetCPDocRuleTypeOf();
			//ipItems.Enabled = false;			

			//Getting PartTree
			string sItemTypeID = ipItems.ItemId;
			DataSet dsParts = new DataSet();
			DataTable dtParts = new DataTable();
			dtParts = Service.GetParts(sItemTypeID);
			dsParts.Tables.Add(dtParts.Copy());

			//Get all measures
			DataTable dtMeasures = Service.GetMeasuresByItemType(sItemTypeID);
			DataSet dsMeasures = new DataSet();
			dsMeasures.Tables.Add(dtMeasures);
			dsParts.Tables.Add(dtMeasures.Copy());

			//gemoDream.Service.debug_DiaspalyDataSet(dsMeasures);

			//Set NotVisibleInCCM for all measures all parts by default
			DataSet dsRules = Service.GetCPDocRuleByCpTypeOf(sItemTypeID);
			dsRules.Tables["CPDocRuleByCpTypeOf"].TableName = "Rules";

			string sCPOfficeID = "";
			string sCPID = "";
			if (CPOfficeID_CPID.Length != 0)
			{
				string[] sID = CPOfficeID_CPID.Split('_');
				sCPOfficeID = sID[0];
				sCPID = sID[1];
			}

			sItemTypeID = ipItems.itemId;
			string sPath2Picture = this.tbPicPath.Text.ToString();

			//gemoDream.Service.debug_DiaspalyDataSet(dsDocOperations);
			//gemoDream.Service.debug_DiaspalyDataSet(dsMeasureValues);
			//gemoDream.Service.debug_DiaspalyDataSet(dsParts);
			//gemoDream.Service.debug_DiaspalyDataSet(dsRules);
			string sCPName = this.tbCustProgName.Text.Trim();

			DocumentProps dpNewDoc = new DocumentProps(this.AccessLevel, dsDocOperations, dsMeasureValues, dsParts, dsRules,
				sCPOfficeID, sCPID, sItemTypeID, sPath2Picture,
				this.newOperationsList, sCPName);
			TabPage tpNewPage = new TabPage("Document" + tcDocs.TabCount.ToString());
			//dpNewDoc.InitRechecks(dvData);

			DataTable dtEmpty = new DataTable("Rechecks");
			dtEmpty.Columns.Add("Property_Name");
			dtEmpty.Columns.Add("Rechecks");
			dtEmpty.Columns.Add("Do");
			InitMeasuresRechecks(dpNewDoc.dgRechecks, dtEmpty, dpNewDoc.NewTableStyle());
			dpNewDoc.Parent = tpNewPage;
			dpNewDoc.Location = new Point(0, 5);

			//dpNewDoc.partProps2.Nodes = dtItem;
			tcDocs.TabPages.Add(tpNewPage);
			tcDocs.SelectedTab = tpNewPage;

			//((DocumentProps)(tcDocs.SelectedTab.Controls[0])).InitTree(dsData1.Tables["Parts"]);
		}


		//Delete Document button handler
		private void bDocDelete_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Any unsaved data on the selected document will be lost. /nContinue?",
				"New document", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
			{
				if (tcDocs.SelectedIndex != 0)
				{
					tcDocs.TabPages.Remove(tcDocs.SelectedTab);
					for (int i = 1; i < tcDocs.TabCount; i++)
						tcDocs.TabPages[i].Text = "Document" + i.ToString();
					Console.WriteLine(tcDocs.TabCount.ToString());
				}
				else
					MessageBox.Show("Default document cannot be deleted", "Not permitted operation",
						MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}


		private bool CheckFirstTab()
		{
			bool bMeasuresOk = false;
			DataRow drRow;
			for (int i = 0; i < ((DataView)(dgRechecks.DataSource)).Table.Rows.Count; i++)
			{
				drRow = ((DataView)dgRechecks.DataSource).Table.Rows[i];
				if (Convert.ToInt32(drRow["Rechecks"]) > 0 && Convert.ToBoolean(drRow["Do"]) == true)
				{
					bMeasuresOk = true;
					break;
				}
			}

			if (!chbDefEnabled.Checked || !(checkBoxPD1.Checked || bMeasuresOk))
				return false;
			return true;
		}

		private bool CheckOtherTab(int iTabIndex)
		{
			bool bMeasuresOk = false;
			DataRow drRow;
			for (int i = 0; i < ((DataView)(dgRechecks.DataSource)).Table.Rows.Count; i++)
			{
				drRow = ((DataView)(((DocumentProps)(tcDocs.TabPages[iTabIndex].Controls[0])).dgRechecks.DataSource)).Table.Rows[i];
				if (Convert.ToInt32(drRow["Rechecks"]) > 0 && Convert.ToBoolean(drRow["Do"]) == true)
				{
					bMeasuresOk = true;
					break;
				}
			}



			/*
            if(!((DocumentProps)(tcDocs.TabPages[iTabIndex].Controls[0])).chbDocEnabled.Checked || 
                ((DocumentProps)(tcDocs.TabPages[iTabIndex].Controls[0])).Rulez.Tables[0].Rows.Count == 0 ||
                !(bMeasuresOk || ((DocumentProps)(tcDocs.TabPages[iTabIndex].Controls[0])).chbPrintDoc1.Checked))
                return false;
                */
			DocumentProps dp = ((DocumentProps)(tcDocs.TabPages[iTabIndex].Controls[0]));
			if (!dp.chbDocEnabled.Checked ||
				dp.Rulez.Tables[0].Rows.Count == 0 ||
				!(bMeasuresOk || dp.chbPrintDoc1.Checked))
				return false;
			return true;
		}

		private bool IsAbleToSave(int iTabIndex)
		{
			bool bMeasuresOk = false;
			DataRow drRow;
			if (iTabIndex == 0)
			{
				for (int i = 0; i < ((DataView)(dgRechecks.DataSource)).Table.Rows.Count; i++)
				{
					drRow = ((DataView)dgRechecks.DataSource).Table.Rows[i];
					if (Convert.ToInt32(drRow["Rechecks"]) > 0 && Convert.ToBoolean(drRow["Do"]) == true)
					{
						bMeasuresOk = true;
						break;
					}
				}

				if (!chbDefEnabled.Checked || !(checkBoxPD1.Checked || bMeasuresOk))
					return false;
			}
			else
			{
				for (int i = 0; i < ((DataView)(dgRechecks.DataSource)).Table.Rows.Count; i++)
				{
					drRow = ((DataView)(((DocumentProps)(tcDocs.TabPages[iTabIndex].Controls[0])).dgRechecks.DataSource)).Table.Rows[i];
					if (Convert.ToInt32(drRow["Rechecks"]) > 0 && Convert.ToBoolean(drRow["Do"]) == true)
					{
						bMeasuresOk = true;
						break;
					}
				}

				if (!((DocumentProps)(tcDocs.TabPages[iTabIndex].Controls[0])).chbDocEnabled.Checked ||
					((DocumentProps)(tcDocs.TabPages[iTabIndex].Controls[0])).Rulez.Tables[0].Rows.Count == 0 ||
					!(bMeasuresOk || ((DocumentProps)(tcDocs.TabPages[iTabIndex].Controls[0])).chbPrintDoc1.Checked))
					return false;
			}
			return true;
		}

		private void SetDocumentCPID(string sCPOfficeID, string sCPID,
			string sOperationTypeOfficeID, string sOperationTypeID)
		{
			try
			{
				DataSet dsIn = new DataSet();
				DataTable dtIn = dsIn.Tables.Add("DocumentCPID");
				dtIn.Columns.Add("CPID", System.Type.GetType("System.String"));
				dtIn.Columns.Add("CPOfficeID", System.Type.GetType("System.String"));
				dtIn.Columns.Add("OperationTypeID", System.Type.GetType("System.String"));
				dtIn.Columns.Add("OperationTypeOfficeID", System.Type.GetType("System.String"));

				DataRow row = dtIn.NewRow();

				row["CPID"] = sCPID;
				row["CPOfficeID"] = sCPOfficeID;
				row["OperationTypeID"] = sOperationTypeOfficeID;
				row["OperationTypeOfficeID"] = sOperationTypeID;

				dtIn.Rows.Add(row);
				gemoDream.Service.ProxyGenericSet(dsIn, "Set");
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Can't set document CPID. Reason: " + ex.ToString(),
					"Internal error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private bool UpdateOperations(ArrayList newOperList)
		{
			try
			{
				DefineDocumentForm.NewOperationData nod;
				char separator = '_';
				string[] sCPOfficeID_CPID = CPOfficeID_CPID.Split(separator);
				string sCPOfficeID = sCPOfficeID_CPID[0];
				string sCPID = sCPOfficeID_CPID[1];
				for (int i = 0; i < newOperList.Count; i++)
				{
					nod = (DefineDocumentForm.NewOperationData)newOperList[i];
					if (nod.sCPOfficeID == null || nod.sCPOfficeID.Length == 0)
					{
						//						SetDocumentCPID(sCPOfficeID, sCPID, nod.sOperationTypeOfficeID, nod.sOperationTypeID);
						Service.SetDocument_CP(nod.sDocumentID, sCPOfficeID, sCPID);
					}
					//					if ((nod.sCPOfficeID == null || nod.sCPOfficeID.Length == 0) &&
					//						(nod.sOperationTypeID == null || nod.sOperationTypeID.Length == 0))
					//					{
					//						Service.SetDocument_CP(nod.sDocumentID, sCPOfficeID, sCPID);
					//					}

					//else
					//SetDocumentCPID(nod.sCPOfficeID, nod.sCPID, nod.sOperationTypeOfficeID, nod.sOperationTypeID);
				}
				newOperList.Clear();
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Can't update operations. Reason: " + ex.ToString(),
					"Internal error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			return true;
		}

		public void CopyAllOperations()
		{
			this.newOperationsList.Clear();
			string s = this.comboBoxD1.SelectedValue.ToString();
			if (this.checkBoxPD1.Checked && chbDefEnabled.Checked)
			{
				//if (Service.IsMagicOperations
				/*	
                    DefineDocumentForm.NewOperationData nod = new DefineDocumentForm.NewOperationData();
                    nod.sDocumentID = sDocumentID;
                    nod.sCPID = null;
                    nod.sCPOfficeID = null;
                    nod.sOperationTypeID = null;
                    nod.sOperationTypeOfficeID = null;
                    newOperationsListMember.Add(nod);
                    //if (Service.IsMagicOperation(s))
                    //	return true;
                    */
			}
			s = this.comboBoxD2.SelectedValue.ToString();
			if (this.checkBoxPD2.Checked && chbDefEnabled.Checked)
			{
			}
			s = this.comboBoxD3.SelectedValue.ToString();
			if (this.checkBoxPD3.Checked && chbDefEnabled.Checked)
			{
			}
			s = this.comboBoxD4.SelectedValue.ToString();
			if (this.checkBoxPD4.Checked && chbDefEnabled.Checked)
			{
			}

			for (int i = 1; i < this.tcDocs.TabPages.Count; i++)
			{
				DocumentProps dp = (DocumentProps)this.tcDocs.TabPages[i].Controls[0];
				s = dp.cbDoc1.SelectedValue.ToString();
				if (dp.chbPrintDoc1.Checked)
				{
				}
				s = dp.cbDoc2.SelectedValue.ToString();
				if (dp.chbPrintDoc2.Checked)
				{
				}
				s = dp.cbDoc3.SelectedValue.ToString();
				if (dp.chbPrintDoc3.Checked)
				{
				}
				s = dp.cbDoc4.SelectedValue.ToString();
				if (dp.chbPrintDoc4.Checked)
				{
				}
				s = dp.cbDoc5.SelectedValue.ToString();
				if (dp.chbPrintDoc5.Checked)
				{
				}
				if (dp.chbPrintDoc6.Checked)
				{
					s = dp.cbDoc6.SelectedValue.ToString();
				}
			}
		}

		public bool SaveCPPart2(string sCPOfficeID, string sCPID)
		{
			try
			{
				bool bSaveAll = false;

				bool b = UpdateOperations(this.newOperationsList);
				if (b != true)
				{
					//MessageBox.Show("Can't save customer program. "	
					return false;
				}

				String s = this.tbBatchCode.Text;
				string[] sCustomer = ctcCustomer.SelectedID.Split('_');
				if ((s.Length == 8 || s.Length == 9) && !s.StartsWith("#") && this.AccessLevel > 2)
				{
					DialogResult result = MessageBox.Show(this, "Apply changes to all Customer Program copies?", "Change all copies",
						MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
					if (result == DialogResult.Yes)
						bSaveAll = true;
				}

				//neiie?iaaou eciaiey ai ana eiiee

				//if ((s.Length < 8 || s.Length > 9) || bSaveAll)

				if (bSaveAll || s.IndexOf("###") >= 0 || s.Trim().Length == 0)
				{
					DataSet dsIn = new DataSet();
					DataTable dtIn = dsIn.Tables.Add("CopyAllCP_New");
					dtIn.Columns.Add("CPID", System.Type.GetType("System.String"));
					dtIn.Columns.Add("CPOfficeID", System.Type.GetType("System.String"));
					dtIn.Columns.Add("CustomerID", System.Type.GetType("System.String"));
					dtIn.Columns.Add("CustomerOfficeID", System.Type.GetType("System.String"));
					DataRow row = dtIn.NewRow();

					//char[] separator = { '_' };
					//string[] strCPOfficeID_CPID = CPOfficeID_CPID.Split(separator);

					row["CPID"] = sCPID;
					//strCPOfficeID_CPID[1];
					row["CPOfficeID"] = sCPOfficeID;
					//strCPOfficeID_CPID[0];
					row["CustomerID"] = sCustomer[1];
					row["CustomerOfficeID"] = sCustomer[0];

					dtIn.Rows.Add(row);
					gemoDream.Service.ProxyGenericSet(dsIn, "");//Procedure dbo.spCopyAllCP_New
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Can't save customer program. Reason: " + ex.ToString(),
					"Internal error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			return true;
		}

		public void LoadCustomerAndCustomerProgram(
			string sCPOfficeID_CPID,
			string sCustomerOfficeID_CustomerID, string sCPName)
		{
			var SID = sCustomerOfficeID_CustomerID.Split('_');
			ipItems.CustomerID = Convert.ToInt32(SID[1]);
			ctcCustomer_SelectedIndexChanged(this, null);
			//ctcCustomer.ComboField.cbField.SelectedValue = sCustomerOfficeID_CustomerID;
			this.cbCustomerProgram.SelectedItem = sCPName.Trim();
			//this.cbCustomerProgram.SelectedValue = sCPOfficeID_CPID;

			//this.cbCustomerProgram.Text = sCPName;
			//cbCustomerProgram_SelectedIndexChanged(this, null);
			//this.cbCustomerProgram.Text = sCPName;
			//LoadCP(sCPName);
		}

		public void CopyDefDocs(string sCPOfficeIDFrom, string sCPIDFrom)
		{
			try
			{
				DataSet dsIn = new DataSet();
				DataTable dtIn = dsIn.Tables.Add("CopyDefDocs");
				dtIn.Columns.Add("CPIDFrom", System.Type.GetType("System.String"));
				dtIn.Columns.Add("CPOfficeIDFrom", System.Type.GetType("System.String"));
				dtIn.Columns.Add("CPIDTo", System.Type.GetType("System.String"));
				dtIn.Columns.Add("CPOfficeIDTo", System.Type.GetType("System.String"));

				DataRow row = dtIn.NewRow();

				char[] separator = { '_' };
				string[] strCPOfficeID_CPID = CPOfficeID_CPID.Split(separator);

				row["CPIDFrom"] = sCPIDFrom;
				row["CPOfficeIDFrom"] = sCPOfficeIDFrom;
				row["CPIDTo"] = strCPOfficeID_CPID[1];
				row["CPOfficeIDTo"] = strCPOfficeID_CPID[0];

				dtIn.Rows.Add(row);
				gemoDream.Service.ProxyGenericSet(dsIn, "");
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Can't copy def docs. Reason: " + ex.ToString(),
					"Internal error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		//mind-screw
		private void bSaveCustProg_Click(object sender, EventArgs e)
		{
			bSaveCustProg.Enabled = false;
			bSaveCustProgAs.Enabled = false;
			bool IsOK = this.SaveCP(tbCustProgName.Text.Trim(), ctcCustomer.ComboField.cbField.SelectedValue.ToString(),
				ctcVendor.ComboField.cbField.SelectedValue.ToString(), SaveCPmode.Save);
			if (IsOK)
			{
				char[] separator = { '_' };
				string[] strCPOfficeID_CPID = CPOfficeID_CPID.Split(separator);
				IsOK = SaveCPPart2(strCPOfficeID_CPID[0], strCPOfficeID_CPID[1]);
				if (IsOK)
				{
					try
					{
						if (dpPropsB != null)
						{
							ArrayList myParts = new ArrayList();
							ArrayList myPartsName = new ArrayList();
							Service.GetCheckedPartFromPartTree(dpPropsB.ptPartTree.tvPartTree.Nodes, ref myParts, ref myPartsName);
							SaveBlockedParts(this.tbBatchCode.Text.ToString(), strCPOfficeID_CPID[1], myParts);
						}
						if (IsLoadFromItemizn)
						{
							MessageBox.Show("Customer program was saved successfully.", "Successful Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
						else
						{
							if (MessageBox.Show("Customer program was saved successfully.\nWould you like to clear all the fields?", "Successfull save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
								DialogResult.Yes)
							{
								ctcCustomer.ComboField.cbField.SelectedIndex = 0;
								//Init();
								//return;
								ipItems.FullItemName = "";
								ipItems.StructName = "";
								ipItems.CustomerID = 0;
								ipItems._ptItemStructure.Clear();
								ipItems.LoadItemitemTypeView(true, "0");
								ctcCustomer.Focus();
								tbCustProgName.Text = "";
								ctcVendor.ComboField.cbField.SelectedIndex = 0;

								dsPricing = null;
								return;
							}
						}
					}
					catch (Exception ex)
					{
						var a = ex.Message;
					}
				}
			}
			bSaveCustProg.Enabled = true;
			string str = this.tbBatchCode.Text.ToString();
			if (str.Equals("#####.###")) bSaveCustProgAs.Enabled = true;
		}
		#endregion NotDefaultDocument

		private void GetCheckedPartFromPartTree(TreeNodeCollection nodes, ref ArrayList myParts)
		{
			try
			{
				foreach (TreeNode tn in nodes)
				{
					if (tn.Checked)
						myParts.Add(tn.ImageKey);
					GetRecursive(tn, ref myParts);
				}

			}
			catch (Exception ex)
			{
				var a = ex.Message;
			}
		}

		private void GetRecursive(TreeNode treeNode, ref ArrayList myParts)
		{
			foreach (TreeNode tn in treeNode.Nodes)
			{
				if (tn.Checked) myParts.Add(tn.ImageKey);
				GetRecursive(tn, ref myParts);
			}
		}

		private void SaveBlockedParts(string strBatch, string CPID, ArrayList parts0)
		{
			try
			{
				string sGroupCode = "";
				string sBatchCode = "";
				if (strBatch.Length == 8)
				{
					sGroupCode = strBatch.Substring(0, 5);
					sBatchCode = strBatch.Substring(5, 3);
				}
				if (strBatch.Length == 9)
				{
					sGroupCode = strBatch.Substring(0, 6);
					sBatchCode = strBatch.Substring(6, 3);
				}
				string sBatchID = Service.GetBatchByCode(sGroupCode, sBatchCode);
				DataSet dsTemp = new DataSet("Batches");
				DataTable dt = new DataTable("PartsPerBatch");
				int[] ColumnIndex = { 2, 3, 7 };

				foreach (var i in ColumnIndex)
				{
					dt.Columns.Add("Col" + i.ToString());
				}
				if (parts0.Count == 0)
				{
					DataRow dr = dt.NewRow();
					foreach (int i in ColumnIndex)
					{
						if (i == 2) dr["Col" + i.ToString()] = sBatchID;
						if (i == 3) dr["Col" + i.ToString()] = CPID;
						if (i == 7) dr["Col" + i.ToString()] = "";
					}
					dt.Rows.Add(dr);
				}
				else
				{
					foreach (var aa in parts0)
					{
						DataRow dr = dt.NewRow();
						foreach (int i in ColumnIndex)
						{
							if (i == 2) dr["Col" + i.ToString()] = sBatchID;
							if (i == 3) dr["Col" + i.ToString()] = CPID;
							if (i == 7) dr["Col" + i.ToString()] = aa;
						}
						dt.Rows.Add(dr);
					}

				}
				dsTemp.Tables.Add(dt);
#if DEBUG
				// For debugging only			
				string filename = "C:/DELL/myXmlBlockedPartsListCP.xml";
				if (File.Exists(filename)) File.Delete(filename);
				// Create the FileStream to write with.
				System.IO.FileStream myFileStream = new System.IO.FileStream(filename, System.IO.FileMode.Create);
				// Create an XmlTextWriter with the fileStream.
				System.Xml.XmlTextWriter myXmlWriter = new System.Xml.XmlTextWriter(myFileStream, System.Text.Encoding.Unicode);
				// Write to the file with the WriteXml method.
				dsTemp.WriteXml(myXmlWriter);
				myXmlWriter.Close();
				// End of debugging part
#endif
				DataSet dsIn = new DataSet();
				DataTable dtIn = dsIn.Tables.Add("SaveBlockedPartsByBatch");
				dtIn.Columns.Add("XmlBlockedParts", System.Type.GetType("System.String"));
				DataRow row = dtIn.NewRow();
				dtIn.Rows.Add(row);
				row["XmlBlockedParts"] = dsTemp.GetXml();
				DataSet dsOut = Service.ProxyGenericSet(dsIn, "Set");
			}
			catch (Exception ex)
			{
				var a = ex.Message;
			}
		}

		#region StatusBar
		private void ctcCustomer_Enter(object sender, EventArgs e)
		{
			sbStatus.Text = "Select a customer to process";

		}

		private void ctcVendor_Enter(object sender, EventArgs e)
		{
			sbStatus.Text = "Select a vendor to process";
		}

		private void ipItems_Enter(object sender, EventArgs e)
		{
			sbStatus.Text = "Select an item to process";
		}

		private void tbCustProgName_Enter(object sender, EventArgs e)
		{
			sbStatus.Text = "Customer program name";
		}
		private void ptrOpsLeft_Enter(object sender, EventArgs e)
		{
			sbStatus.Text = "Available operations";
		}

		private void ptrOpsRight_Enter(object sender, EventArgs e)
		{
			sbStatus.Text = "Program operations";
		}

		private void tbDescription_Enter(object sender, EventArgs e)
		{
			sbStatus.Text = "Document description";
		}

		private void dgRechecks_Enter(object sender, EventArgs e)
		{
			sbStatus.Text = "Measures to recheck";
		}

		private void comboBoxD1_Enter(object sender, EventArgs e)
		{
			sbStatus.Text = "Document to print";
		}

		#endregion StatusBar

		private void ptrOpsLeft_Changed(object sender, EventArgs e)
		{
			selected = ptrOpsLeft.SelectedRow["ID"].ToString();
		}

		private void tbPicPath_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				string pathToShape = Client.GetOfficeDirPath("iconDir") + tbPicPath.Text;
				if (File.Exists(pathToShape))
				{
					Image im = System.Drawing.Image.FromFile(pathToShape);//  (System.Drawing.Image)Service.ExtractImageFromString(dvParts[0]["ShapePicture"].ToString(), dvParts[0]["ShapePath"].ToString()); old part
					ipItems.InitializePicture(im);
				}
				//				Old part
				//				Image im = Service.GetImageFromSrv(tbPicPath.Text);
				//				if(im != null)
				//				{
				//					ipItems.InitializePicture(im);
				//				}
				else
				{
					ipItems.InitializePicture(null);
					MessageBox.Show("There is no picture in specified location",
						"Picture not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
		}

		private void ptrOpsLeft_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Space)
			{
				if (e.Control)
					bOpMoveRightAll_Click(this, EventArgs.Empty);
				else
					bOpMoveRight_Click(this, EventArgs.Empty);
			}
		}

		private void ptrOpsRight_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Space)
			{
				if (e.Control)
					bOpMoveLeftAll_Click(this, EventArgs.Empty);
				else
					bOpMoveLeft_Click(this, EventArgs.Empty);
			}
		}


		private void bSaveCustProgAs_Click(object sender, EventArgs e)
		{
			string s;
			if (this.CPOfficeID_CPID == null || this.CPOfficeID_CPID.Length == 0)
			{
				s = this.cbCustomerProgram.SelectedValue.ToString();
			}
			else
				s = this.CPOfficeID_CPID;

			if (this.dtCustomers != null && this.tbCustProgName.Text.Trim() != "" && this != null)
			{
				SaveCPas frm = new SaveCPas(this.dtCustomers, this.tbCustProgName.Text.Trim(), this, s);
				frm.ShowDialog(this);
			}
		}

		private bool IsAnyDocumentNotValid()
		{
			string s = this.comboBoxD1.SelectedValue.ToString();
			if (this.checkBoxPD1.Checked && chbDefEnabled.Checked)
			{
				//if (s.Equals("-1_1") || s.Equals("-2_2") || s.Equals("-3_3"))
				if (Service.IsMagicOperation(s))
					return true;
			}
			s = this.comboBoxD2.SelectedValue.ToString();
			if (this.checkBoxPD2.Checked && chbDefEnabled.Checked)
			{
				//if (s.Equals("-1_1") || s.Equals("-2_2") || s.Equals("-3_3"))
				if (Service.IsMagicOperation(s))
					return true;
			}
			s = this.comboBoxD3.SelectedValue.ToString();
			if (this.checkBoxPD3.Checked && chbDefEnabled.Checked)
			{
				//if (s.Equals("-1_1") || s.Equals("-2_2") || s.Equals("-3_3"))
				if (Service.IsMagicOperation(s))
					return true;
			}
			s = this.comboBoxD4.SelectedValue.ToString();
			if (this.checkBoxPD4.Checked && chbDefEnabled.Checked)
			{
				//if (s.Equals("-1_1") || s.Equals("-2_2") || s.Equals("-3_3"))
				if (Service.IsMagicOperation(s))
					return true;
			}

			for (int i = 1; i < this.tcDocs.TabPages.Count; i++)
			{
				DocumentProps dp = (DocumentProps)this.tcDocs.TabPages[i].Controls[0];
				s = dp.cbDoc1.SelectedValue.ToString();
				if (dp.chbPrintDoc1.Checked)
				{
					//if (s.Equals("-1_1") || s.Equals("-2_2") || s.Equals("-3_3"))
					if (Service.IsMagicOperation(s))
						return true;
				}
				s = dp.cbDoc2.SelectedValue.ToString();
				if (dp.chbPrintDoc2.Checked)
				{
					//if (s.Equals("-1_1") || s.Equals("-2_2") || s.Equals("-3_3"))
					if (Service.IsMagicOperation(s))
						return true;
				}
				s = dp.cbDoc3.SelectedValue.ToString();
				if (dp.chbPrintDoc3.Checked)
				{
					//if (s.Equals("-1_1") || s.Equals("-2_2") || s.Equals("-3_3"))
					if (Service.IsMagicOperation(s))
						return true;
				}
				s = dp.cbDoc4.SelectedValue.ToString();
				if (dp.chbPrintDoc4.Checked)
				{

					//if (s.Equals("-1_1") || s.Equals("-2_2") || s.Equals("-3_3"))
					if (Service.IsMagicOperation(s))
						return true;
				}
				s = dp.cbDoc5.SelectedValue.ToString();
				if (dp.chbPrintDoc5.Checked)
				{

					//if (s.Equals("-1_1") || s.Equals("-2_2") || s.Equals("-3_3"))
					if (Service.IsMagicOperation(s))
						return true;
				}
				if (dp.chbPrintDoc6.Checked)
				{
					s = dp.cbDoc6.SelectedValue.ToString();
					//if (s.Equals("-1_1") || s.Equals("-2_2") || s.Equals("-3_3"))
					if (Service.IsMagicOperation(s))
						return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Find node by name
		/// </summary>
		/// <param name="tv"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		private TreeNode FindNode(TreeView tv, string name)
		{
			foreach (TreeNode tn in tv.Nodes)
			{
				if (name.Equals(tn.Tag.ToString()))
				{
					return tn;
				}
			}

			TreeNode node;
			foreach (TreeNode tn in tv.Nodes)
			{
				node = FindNode(tn, name);
				if (node != null)
				{
					return node;
				}
			}
			return null;
		}

		private TreeNode FindNode(TreeNode tv, string name)
		{
			foreach (TreeNode tn in tv.Nodes)
			{
				if (name.Equals(tn.Tag.ToString()))
				{
					return tn;
				}
			}

			TreeNode node;
			foreach (TreeNode tn in tv.Nodes)
			{
				node = FindNode(tn, name);
				if (node != null)
				{
					return node;
				}
			}
			return null;
		}

		/// <summary>
		/// CheckNode by name
		/// </summary>
		/// <param name="tv"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		private void CheckNode(TreeView tv, string ID)
		{
			foreach (TreeNode tn in tv.Nodes)
			{
				if (ID.Equals(tn.Tag.ToString()))
				{
					tn.Checked = true;
					return;
				}
				else
				{
					CheckNode(tn, ID);
				}
			}
			return;
		}

		private void CheckNode(TreeNode tv, string ID)
		{
			foreach (TreeNode tn in tv.Nodes)
			{
				if (ID.Equals(tn.Tag.ToString()))
				{
					tn.Checked = true;
					return;
				}
				else
				{
					CheckNode(tn, ID);
				}
			}
			return;
		}


		/// <summary>
		/// //save customer program to various users and vendors
		/// </summary>
		public bool SaveCP(string sCPName, string sCustomerOfficeID_CustomerID, string sVendorOfficeID_VendorID, SaveCPmode mode)
		{
			bool IsOK = true;

			#region cheking comboboxes for equals values

			bool bIfError = false;
			DataTable lbTable = new DataTable("lbTable");
			DataColumn dcColv = new DataColumn("Selected_values", Type.GetType("System.Int32"))
			{
				Unique = true
			};
			DataColumn dcColn = new DataColumn("TabNumber", Type.GetType("System.Int32"));

			lbTable.Columns.Add(dcColn);
			lbTable.Columns.Add(dcColv);

			for (int iCurrCntrl = 0; iCurrCntrl < gbDoc.Controls.Count; iCurrCntrl++)
			{
				if (gbDoc.Controls[iCurrCntrl].GetType().ToString() ==
					"System.Windows.Forms.ComboBox")
				{
					ComboBox dInsp = (ComboBox)gbDoc.Controls[iCurrCntrl];
					if (dInsp.Enabled)
					{
						DataRow dr = lbTable.NewRow();
						dr.BeginEdit();
						dr["TabNumber"] = 1;
						dr["Selected_values"] = dInsp.SelectedIndex;
						dr.EndEdit();
						try
						{
							lbTable.Rows.Add(dr);
						}
						catch
						{
							string sMessage = "Can't save CP. You try to add identical documents";

							MessageBox.Show(sMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
							//tcOpsReqs.SelectedTab = tcOpsReqs.TabPages[1]; 
							//tcDocs.SelectedTab = tcDocs.TabPages[0];
							bIfError = true;
							break;
						}
					}
				}
			}
			for (int iCurrTab = 1; iCurrTab < tcDocs.TabPages.Count; iCurrTab++)
			{
				lbTable.Rows.Clear();
				try
				{
					if (((DocumentProps)(tcDocs.TabPages[iCurrTab].Controls[0])).cbDoc1.Enabled)
					{

						DataRow dr = lbTable.NewRow();
						dr.BeginEdit();
						dr["TabNumber"] = iCurrTab;
						dr["Selected_values"] = ((DocumentProps)(tcDocs.TabPages[iCurrTab].Controls[0])).cbDoc1.SelectedIndex;
						dr.EndEdit();
						lbTable.Rows.Add(dr);
					}
					if (((DocumentProps)(tcDocs.TabPages[iCurrTab].Controls[0])).cbDoc2.Enabled)
					{
						DataRow dr = lbTable.NewRow();
						dr.BeginEdit();
						dr["TabNumber"] = iCurrTab;
						dr["Selected_values"] = ((DocumentProps)(tcDocs.TabPages[iCurrTab].Controls[0])).cbDoc2.SelectedIndex;
						dr.EndEdit();
						lbTable.Rows.Add(dr);
					}
					if (((DocumentProps)(tcDocs.TabPages[iCurrTab].Controls[0])).cbDoc3.Enabled)
					{
						DataRow dr = lbTable.NewRow();
						dr.BeginEdit();
						dr["TabNumber"] = iCurrTab;
						dr["Selected_values"] = ((DocumentProps)(tcDocs.TabPages[iCurrTab].Controls[0])).cbDoc3.SelectedIndex;
						dr.EndEdit();
						lbTable.Rows.Add(dr);
					}
					if (((DocumentProps)(tcDocs.TabPages[iCurrTab].Controls[0])).cbDoc4.Enabled)
					{
						DataRow dr = lbTable.NewRow();
						dr.BeginEdit();
						dr["TabNumber"] = iCurrTab;
						dr["Selected_values"] = ((DocumentProps)(tcDocs.TabPages[iCurrTab].Controls[0])).cbDoc4.SelectedIndex;
						dr.EndEdit();
						lbTable.Rows.Add(dr);
					}

					if (((DocumentProps)(tcDocs.TabPages[iCurrTab].Controls[0])).cbDoc5.Enabled)
					{
						DataRow dr = lbTable.NewRow();
						dr.BeginEdit();
						dr["TabNumber"] = iCurrTab;
						dr["Selected_values"] = ((DocumentProps)(tcDocs.TabPages[iCurrTab].Controls[0])).cbDoc5.SelectedIndex;
						dr.EndEdit();
						lbTable.Rows.Add(dr);
					}
					if (((DocumentProps)(tcDocs.TabPages[iCurrTab].Controls[0])).cbDoc6.Enabled)
					{
						DataRow dr = lbTable.NewRow();
						dr.BeginEdit();
						dr["TabNumber"] = iCurrTab;
						dr["Selected_values"] = ((DocumentProps)(tcDocs.TabPages[iCurrTab].Controls[0])).cbDoc6.SelectedIndex;
						dr.EndEdit();
						lbTable.Rows.Add(dr);
					}
				}
				catch (Exception ex)
				{
					string sMessage = "Can't save CP. You try to add identical documents";

					MessageBox.Show(sMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					//tcOpsReqs.SelectedTab = tcOpsReqs.TabPages[1]; 
					//tcDocs.SelectedTab = tcDocs.TabPages[iCurrTab]; 
					bIfError = true;
					break;
				}
			}
			//////////////////
			#endregion

			if (bIfError)
			{
				IsOK = false;
				this.sbStatus.Text = "Save failed";
				return IsOK;
			}

			if (!bIfError)
			{

				bool bSave0 = false;
				bool bSaveOther = true;
				bool bOtherExists = false;


				bool save = false;
				int quantToSave = 0;
				for (int i = 0; i < tcDocs.TabPages.Count; i++)
				{
					if (i == 0)
						bSave0 = CheckFirstTab();
					else
					{
						bOtherExists = true;
						bool bOk = CheckOtherTab(i);
						if (i == 1)
							bSaveOther = bOk;
						else
							bSaveOther = bOk && bSaveOther;
					}
				}

				if (bOtherExists)
				{
					save = bSaveOther;
				}
				else
				{
					save = bSave0;
				}

				if (!save)
				{
					sbStatus.Text = "Not all requirements are satisfied for documents";
					IsOK = false;
					return IsOK;
				}

				if (IsAnyDocumentNotValid())
				{
					MessageBox.Show(this, "Can't save documents, some documents are not valid. Please, check them.",
						"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					sbStatus.Text = "Some documents are not valid";
					IsOK = false;
					return IsOK;
				}

				DataSet dsCheck = Service.GetCPByNameAndCustomer(tbCustProgName.Text,
											ctcCustomer.ComboField.cbField.SelectedValue.ToString(),
											ctcVendor.ComboField.cbField.SelectedValue.ToString()); //Procedure dbo.spGetCustomerProgramByNameAndCustomer

				if (tbCustProgName.Text.Trim() == "" || ipItems.ItemId == null)
				{

				}
				else
				{
					if (!save)
					{
						sbStatus.Text = "Not all requirements are satisfied for documents";
						IsOK = false;
						return IsOK;
					}
					else
					{
						if (ptrOpsRight.NodesCount == 0)
						{
							sbStatus.Text = "At least one operation must be chosen to proceed";
							IsOK = false;
							return IsOK;
						}
						else
						{
							sbStatus.Text = "Saving document";
							this.Cursor = Cursors.WaitCursor;

							if (dsCheck.Tables[0].Rows.Count > 0)
								dsCP = dsCheck.Copy();
							else
								dsCP = Service.GetCustomerProgramTypeOf();//Procedure dbo.spGetCustomerProgramTypeOf2

							//by vetal_242 save pricing
							string sPriceID = "";
							if (dsPricing != null)
							{
								if (dsPricing.Tables["PricePartsMeasures"].Rows.Count > 0
									|| dsPricing.Tables["AdditionalServicePrice"].Rows.Count > 0)
								{
									sPriceID = Service.SetPrices();
									Service.SetPricePartsMeasures(dsPricing.Tables["PricePartsMeasures"].Copy(), sPriceID);
									Service.SetPriceRange(dsPricing.Tables["PriceRange"].Copy(), sPriceID);
									Service.SetAdditionalServicePrice(dsPricing.Tables["AdditionalServicePrice"].Copy(), sPriceID);
								}
							}

							if (dsCP.Tables[0].Rows.Count == 0)
								dsCP.Tables[0].Rows.Add(dsCP.Tables[0].NewRow());
							dsCP.Tables[0].Rows[0]["CustomerProgramName"] = sCPName.Trim();

							dsCP.Tables[0].Rows[0]["VendorOfficeID_VendorID"] = sVendorOfficeID_VendorID;
							dsCP.Tables[0].Rows[0]["ItemTypeID"] = Convert.ToInt32(ipItems.ItemId);
							dsCP.Tables[0].Rows[0]["CustomerOfficeID_CustomerID"] = sCustomerOfficeID_CustomerID;
							dsCP.Tables[0].Rows[0]["Comment"] = tbComments.Text;

							#region Pricing History
							if (dsPricing != null)
							{
								if (dsPricing.Tables["CPHistory"].Rows.Count == 1)
								{
									if (Convert.ToString(dsPricing.Tables["CPHistory"].Rows[0]["isFixed"]) == "1")
									{
										dsCP.Tables[0].Rows[0]["isFixed"] = "1";
										if (dsPricing.Tables["AdditionalServicePrice"].Rows.Count > 0)
											dsCP.Tables[0].Rows[0]["PriceID"] = sPriceID; // DBNull.Value;
										else
										{
											dsCP.Tables[0].Rows[0]["PriceID"] = DBNull.Value;
											sPriceID = "";
										}
									}
									dsCP.Tables[0].Rows[0]["FixedPrice"] = dsPricing.Tables["CPHistory"].Rows[0]["FixedPrice"];
									dsCP.Tables[0].Rows[0]["DeltaFix"] = dsPricing.Tables["CPHistory"].Rows[0]["DeltaFix"];
									dsCP.Tables[0].Rows[0]["Discount"] = dsPricing.Tables["CPHistory"].Rows[0]["Discount"];
									dsCP.Tables[0].Rows[0]["FailFixed"] = dsPricing.Tables["CPHistory"].Rows[0]["FailFixed"];
									dsCP.Tables[0].Rows[0]["FailDiscount"] = dsPricing.Tables["CPHistory"].Rows[0]["FailDiscount"];
									if (sPriceID != "")
									{
										dsCP.Tables[0].Rows[0]["PriceID"] = sPriceID;
									}
								}
								else
								{
									string sCPID = "";
									if (CPOfficeID_CPID != "")
										sCPID = CPOfficeID_CPID.Split('_')[1];
									DataTable dtCPHistory = Service.GetCustomerProgramPriceByCPID(sCPID);
									if (dtCPHistory.Rows.Count > 0)
									{
										dsCP.Tables[0].Rows[0]["isFixed"] = dtCPHistory.Rows[0]["isFixed"];
										dsCP.Tables[0].Rows[0]["FixedPrice"] = dtCPHistory.Rows[0]["FixedPrice"];
										dsCP.Tables[0].Rows[0]["DeltaFix"] = dtCPHistory.Rows[0]["DeltaFix"];
										dsCP.Tables[0].Rows[0]["Discount"] = dtCPHistory.Rows[0]["Discount"];
										dsCP.Tables[0].Rows[0]["FailFixed"] = dtCPHistory.Rows[0]["FailFixed"];
										dsCP.Tables[0].Rows[0]["FailDiscount"] = dtCPHistory.Rows[0]["FailDiscount"];
										dsCP.Tables[0].Rows[0]["PriceID"] = dtCPHistory.Rows[0]["PriceID"];
									}
								}
							}
							else
							{
								string sCPID = "";
								if (CPOfficeID_CPID != "")
									sCPID = CPOfficeID_CPID.Split('_')[1];
								DataTable dtCPHistory = Service.GetCustomerProgramPriceByCPID(sCPID);//Procedure dbo.spGetCustomerProgramPriceByCPID
								if (dtCPHistory.Rows.Count > 0)
								{
									dsCP.Tables[0].Rows[0]["isFixed"] = dtCPHistory.Rows[0]["isFixed"];
									dsCP.Tables[0].Rows[0]["FixedPrice"] = dtCPHistory.Rows[0]["FixedPrice"];
									dsCP.Tables[0].Rows[0]["DeltaFix"] = dtCPHistory.Rows[0]["DeltaFix"];
									dsCP.Tables[0].Rows[0]["Discount"] = dtCPHistory.Rows[0]["Discount"];
									dsCP.Tables[0].Rows[0]["FailFixed"] = dtCPHistory.Rows[0]["FailFixed"];
									dsCP.Tables[0].Rows[0]["FailDiscount"] = dtCPHistory.Rows[0]["FailDiscount"];
									dsCP.Tables[0].Rows[0]["PriceID"] = dtCPHistory.Rows[0]["PriceID"];
								}
							}
							#endregion

							//mvs
							if (this.tbCPPropertyCustomerID.Text.Length > 0)
								dsCP.Tables[0].Rows[0]["CPPropertyCustomerID"] = this.tbCPPropertyCustomerID.Text;
							else
								dsCP.Tables[0].Rows[0]["CPPropertyCustomerID"] = DBNull.Value;

							if (this.tbSRP.Text.Length > 0)
								dsCP.Tables[0].Rows[0]["SRP"] = this.tbSRP.Text;
							else
								dsCP.Tables[0].Rows[0]["SRP"] = DBNull.Value;
							//mvs

							if (tbCustomerStyle.Text.Length > 0)
								dsCP.Tables[0].Rows[0]["CustomerStyle"] = tbCustomerStyle.Text;
							else dsCP.Tables[0].Rows[0]["CustomerStyle"] = DBNull.Value;

							dsCP.Tables[0].Rows[0]["Description"] = tbDescriptions.Text;

							dsCP.Tables[0].Rows[0]["Path2Picture"] = tbPicPath.Text;
							dsCP.Tables[0].Columns.Remove("Image_Path2Picture");

							if (mode == SaveCPmode.SaveAs)
							{
								//////////////////////////////////
								DataSet dsCPCheck = Service.GetCPByNameAndCustomer(sCPName.Trim(), sCustomerOfficeID_CustomerID, sVendorOfficeID_VendorID);

								if (dsCPCheck.Tables[0].Rows.Count > 0)
								{
									MessageBox.Show("Customer program with this name already exists for this customer and vendor.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
									this.Cursor = Cursors.Arrow;
									IsOK = false;
									return IsOK;
								}
								/////////////////////////////////

								dsCP.Tables[0].Rows[0]["CPOfficeID_CPID"] = DBNull.Value;

							}
							if (mode == SaveCPmode.Save)
							{

								if (CPOfficeID_CPID != "")
									dsCP.Tables[0].Rows[0]["CPOfficeID_CPID"] = CPOfficeID_CPID;
							}

							dsCP.Tables[0].TableName = "CustomerProgram";

							DataSet dsCP1 = Service.AddCustomerProgram(dsCP);//Procedure dbo.spAddCustomerProgram

							CPOfficeID_CPID = dsCP1.Tables["CustomerProgram"].Rows[0]["Id"].ToString();

							DataSet dsCPOperationTypeOf = Service.GetCPOperationTypeOf();
							DataSet dsCPOperation = dsCPOperationTypeOf.Copy();

							//vetal_242 06.20.2006
							dsCPOperation.Tables[0].TableName = "CPOperationWithCheck";
							dsCPOperation.Tables[0].Columns.Add("Checked");

							foreach (DataRow drCurrent in ptrOpsRight.Data.Rows)
							{
								if (drCurrent["OperationTypeID"] != DBNull.Value)
								{
									dsCPOperation.Tables[0].Rows.Add(dsCPOperation.Tables[0].NewRow());
									dsCPOperation.Tables[0].Rows[dsCPOperation.Tables[0].Rows.Count - 1]["CPOfficeID_CPID"] =
										dsCP1.Tables["CustomerProgram"].Rows[0]["Id"];
									dsCPOperation.Tables[0].Rows[dsCPOperation.Tables[0].Rows.Count - 1]["OperationTypeOfficeID_OperationTypeID"] =
										drCurrent["OperationTypeOfficeID_OperationTypeID"];

									ptrOpsRight.tvPartTree.SelectedNode = FindNode(ptrOpsRight.tvPartTree, drCurrent["OperationTypeOfficeID_OperationTypeID"].ToString());
									if (ptrOpsRight.tvPartTree.SelectedNode.Checked)
									{
										dsCPOperation.Tables[0].Rows[dsCPOperation.Tables[0].Rows.Count - 1]["Checked"] = 1;
									}
									break;
								}
							}

							dsCPOperation.Tables[0].TableName = "CPOperationWithCheck";
							//dsCPOperation.Tables[0].TableName = "CPOperation";
							Service.SetCPOperation(dsCPOperation);//Procedure dbo.spSetCPOperationWithCheck

							if (dsCPOperation.Tables[0].Rows.Count == 0)
								sbStatus.Text = "At least one operation must be chosen";
							else
							{
								DataSet dsCPDocTypeOf = Service.GetCPDocsTypeOf();//Procedure dbo.spGetCPDocTypeOf

								for (int i = 0; i < tcDocs.TabPages.Count; i++)
								{
									string IsReturn;
									if (IsAbleToSave(i))
									{
										dsCPDocTypeOf.Tables[0].Rows.Add(dsCPDocTypeOf.Tables[0].NewRow());

										if (i == 0)
										{
											dsCPDocTypeOf.Tables[0].Rows[i]["Description"] = tbDescription.Text;
											IsReturn = chbReturn.Checked == true ? "1" : "0";
										}
										else
										{
											dsCPDocTypeOf.Tables[0].Rows[quantToSave]["Description"] = ((DocumentProps)(tcDocs.TabPages[i].Controls[0])).tbDescription.Text;
											IsReturn = ((DocumentProps)(tcDocs.TabPages[i].Controls[0])).checkBox1.Checked == true ? "1" : "0";
										}
										dsCPDocTypeOf.Tables[0].Rows[quantToSave]["IsReturn"] = IsReturn;
										dsCPDocTypeOf.Tables[0].Rows[quantToSave]["CPOfficeID_CPID"] = dsCP1.Tables[0].Rows[0]["Id"];

										quantToSave++;
									}
								}

								dsCPDocTypeOf.Tables[0].TableName = "CPDoc";
								DataSet dsDocs = Service.SetCPDocs(dsCPDocTypeOf);//Procedure dbo.spSetCPDoc

								DataSet dsCPDocMeasureGroupTypeOf = Service.GetCPDoc_MeasureGroupTypeOf();//Procedure dbo.spGetCPDoc_MeasureGroupTypeOf
								DataSet dsCPDocMeasureGroup = dsCPDocMeasureGroupTypeOf.Copy();
								dsCPDocMeasureGroup.Tables["CPDoc_MeasureGroupTypeOf"].TableName = "CPDoc_MeasureGroup";

								DataSet dsCPDocOperation = Service.GetCPDocOperationTypeOf();//Procedure dbo.spGetCPDoc_OperationTypeOf		

								int iDocNum = 0;

								for (int h = 0; h < tcDocs.TabPages.Count; h++)
								{
									if (IsAbleToSave(h))
									{
										DataRow drDoc = dsDocs.Tables[0].Rows[iDocNum];
										if (h == 0)
										{
											for (int i = 0; i < ((DataView)dgRechecks.DataSource).Table.Rows.Count; i++)   // procedure spSetCPDocRule	, loops
											{
												if (Convert.ToBoolean(((DataView)dgRechecks.DataSource).Table.Rows[i]["Do"]) == true &&
													Convert.ToInt32(((DataView)dgRechecks.DataSource).Table.Rows[i]["Rechecks"]) > 0)
												{
													int CPDMGRowsCount = dsCPDocMeasureGroup.Tables["CPDoc_MeasureGroup"].Rows.Count;
													dsCPDocMeasureGroup.Tables["CPDoc_MeasureGroup"].Rows.Add(dsCPDocMeasureGroup.Tables["CPDoc_MeasureGroup"].NewRow());
													dsCPDocMeasureGroup.Tables["CPDoc_MeasureGroup"].Rows[CPDMGRowsCount]["CPDocID"] = drDoc["Id"];
													dsCPDocMeasureGroup.Tables["CPDoc_MeasureGroup"].Rows[CPDMGRowsCount]["NoRecheck"] =
														((DataView)dgRechecks.DataSource).Table.Rows[i]["Rechecks"].ToString();
													string select = dsMeasureGroups.Tables[0].Select("MeasureGroupName='" + ((DataView)dgRechecks.DataSource).Table.Rows[i]["Property_Name"].ToString() + "'")[0]["MeasureGroupID"].ToString();
													dsCPDocMeasureGroup.Tables["CPDoc_MeasureGroup"].Rows[CPDMGRowsCount]["MeasureGroupID"] =
														Convert.ToDecimal(select);
												}
											}
											//E.B.M.

											if (checkBoxPD1.Checked)
											{
												dsCPDocOperation.Tables[0].Rows.Add(dsCPDocOperation.Tables[0].NewRow());
												dsCPDocOperation.Tables[0].Rows[dsCPDocOperation.Tables[0].Rows.Count - 1]["OperationTypeOfficeID_OperationTypeID"] =
													comboBoxD1.SelectedValue.ToString();
												dsCPDocOperation.Tables[0].Rows[dsCPDocOperation.Tables[0].Rows.Count - 1]["CPDocID"] = drDoc["Id"];

												//if default document checked, but not attached, save it in CP
												//by vetal_242
												//03.08.2006
												string[] strCPOfficeID_CPID = CPOfficeID_CPID.Split('_');
												//		string OperationTypeOfficeID_OperationTypeID = (string)(((DataRowView)comboBoxD1.SelectedItem).Row)[0];
												//		DataSet dsDocID = Service.GetDocumentIDByOperationTypeID(OperationTypeOfficeID_OperationTypeID);
												//		string documentID = (dsDocID.Tables[0].Rows[0][0]).ToString();
												//		DataSet dsDocsCP = Service.GetDocument_CP(documentID, strCPOfficeID_CPID[0], strCPOfficeID_CPID[1]);
												//		if(dsDocsCP.Tables[0].Rows.Count == 0 && !isChanged)
												//		{
												//			Service.SetDocument_CP(documentID, strCPOfficeID_CPID[0], strCPOfficeID_CPID[1]);
												//		}
											}

											if (checkBoxPD2.Checked)
											{
												dsCPDocOperation.Tables[0].Rows.Add(dsCPDocOperation.Tables[0].NewRow());
												dsCPDocOperation.Tables[0].Rows[dsCPDocOperation.Tables[0].Rows.Count - 1]["OperationTypeOfficeID_OperationTypeID"] =
													comboBoxD2.SelectedValue.ToString();
												dsCPDocOperation.Tables[0].Rows[dsCPDocOperation.Tables[0].Rows.Count - 1]["CPDocID"] = drDoc["Id"];

											}

											if (checkBoxPD3.Checked)
											{
												dsCPDocOperation.Tables[0].Rows.Add(dsCPDocOperation.Tables[0].NewRow());
												dsCPDocOperation.Tables[0].Rows[dsCPDocOperation.Tables[0].Rows.Count - 1]["OperationTypeOfficeID_OperationTypeID"] =
													comboBoxD3.SelectedValue.ToString();
												dsCPDocOperation.Tables[0].Rows[dsCPDocOperation.Tables[0].Rows.Count - 1]["CPDocID"] = drDoc["Id"];

											}

											if (checkBoxPD4.Checked)
											{
												dsCPDocOperation.Tables[0].Rows.Add(dsCPDocOperation.Tables[0].NewRow());
												dsCPDocOperation.Tables[0].Rows[dsCPDocOperation.Tables[0].Rows.Count - 1]["OperationTypeOfficeID_OperationTypeID"] =
													comboBoxD4.SelectedValue.ToString();
												dsCPDocOperation.Tables[0].Rows[dsCPDocOperation.Tables[0].Rows.Count - 1]["CPDocID"] = drDoc["Id"];

											}

										}
										else
										{
											for (int i = 0; i < ((DataView)(((DocumentProps)(tcDocs.TabPages[h].Controls[0])).dgRechecks.DataSource)).Table.Rows.Count; i++)
											{
												if (Convert.ToBoolean(((DataView)(((DocumentProps)(tcDocs.TabPages[h].Controls[0])).dgRechecks.DataSource)).Table.Rows[i]["Do"]) == true &&
													Convert.ToInt32(((DataView)(((DocumentProps)(tcDocs.TabPages[h].Controls[0])).dgRechecks.DataSource)).Table.Rows[i]["Rechecks"]) > 0)
												{
													dsCPDocMeasureGroup.Tables["CPDoc_MeasureGroup"].Rows.Add(dsCPDocMeasureGroup.Tables["CPDoc_MeasureGroup"].NewRow());
													dsCPDocMeasureGroup.Tables["CPDoc_MeasureGroup"].Rows[dsCPDocMeasureGroup.Tables["CPDoc_MeasureGroup"].Rows.Count - 1]["CPDocID"] = drDoc["Id"];
													dsCPDocMeasureGroup.Tables["CPDoc_MeasureGroup"].Rows[dsCPDocMeasureGroup.Tables["CPDoc_MeasureGroup"].Rows.Count - 1]["NoRecheck"] =
														((DataView)(((DocumentProps)(tcDocs.TabPages[h].Controls[0])).dgRechecks.DataSource)).Table.Rows[i]["Rechecks"].ToString();
													string select = dsMeasureGroups.Tables[0].Select("MeasureGroupName='" +
														((DataView)(((DocumentProps)(tcDocs.TabPages[h].Controls[0])).dgRechecks.DataSource)).Table.Rows[i]["Property_Name"].ToString() + "'")[0]["MeasureGroupID"].ToString();
													dsCPDocMeasureGroup.Tables["CPDoc_MeasureGroup"].Rows[dsCPDocMeasureGroup.Tables["CPDoc_MeasureGroup"].Rows.Count - 1]["MeasureGroupID"] =
														Convert.ToDecimal(select);
												}
											}

											if (((DocumentProps)(tcDocs.TabPages[h].Controls[0])).chbPrintDoc1.Checked)
											{
												dsCPDocOperation.Tables[0].Rows.Add(dsCPDocOperation.Tables[0].NewRow());
												dsCPDocOperation.Tables[0].Rows[dsCPDocOperation.Tables[0].Rows.Count - 1]["OperationTypeOfficeID_OperationTypeID"] =
													((DocumentProps)(tcDocs.TabPages[h].Controls[0])).cbDoc1.SelectedValue.ToString();
												dsCPDocOperation.Tables[0].Rows[dsCPDocOperation.Tables[0].Rows.Count - 1]["CPDocID"] = drDoc["Id"];
											}

											DocumentProps docProps = ((DocumentProps)(tcDocs.TabPages[h].Controls[0]));
											if (((DocumentProps)(tcDocs.TabPages[h].Controls[0])).chbPrintDoc2.Checked)
											{
												if (docProps.cbDoc2.SelectedValue == null)
												{
													sbStatus.Text = "Please, choose any value for the document";
													this.Cursor = Cursors.Arrow;
													IsOK = false;
													return IsOK;
												}

												dsCPDocOperation.Tables[0].Rows.Add(dsCPDocOperation.Tables[0].NewRow());
												dsCPDocOperation.Tables[0].Rows[dsCPDocOperation.Tables[0].Rows.Count - 1]["OperationTypeOfficeID_OperationTypeID"] =
													((DocumentProps)(tcDocs.TabPages[h].Controls[0])).cbDoc2.SelectedValue.ToString();
												dsCPDocOperation.Tables[0].Rows[dsCPDocOperation.Tables[0].Rows.Count - 1]["CPDocID"] = drDoc["Id"];
											}

											if (((DocumentProps)(tcDocs.TabPages[h].Controls[0])).chbPrintDoc3.Checked)
											{
												if (docProps.cbDoc3.SelectedValue == null)
												{
													sbStatus.Text = "Please, choose any value for the document";
													this.Cursor = Cursors.Arrow;
													IsOK = false;
													return IsOK;
												}

												dsCPDocOperation.Tables[0].Rows.Add(dsCPDocOperation.Tables[0].NewRow());
												dsCPDocOperation.Tables[0].Rows[dsCPDocOperation.Tables[0].Rows.Count - 1]["OperationTypeOfficeID_OperationTypeID"] =
													((DocumentProps)(tcDocs.TabPages[h].Controls[0])).cbDoc3.SelectedValue.ToString();
												dsCPDocOperation.Tables[0].Rows[dsCPDocOperation.Tables[0].Rows.Count - 1]["CPDocID"] = drDoc["Id"];

											}

											if (((DocumentProps)(tcDocs.TabPages[h].Controls[0])).chbPrintDoc4.Checked)
											{
												if (docProps.cbDoc4.SelectedValue == null)
												{
													sbStatus.Text = "Please, choose any value for the document";
													this.Cursor = Cursors.Arrow;
													IsOK = false;
													return IsOK;
												}

												dsCPDocOperation.Tables[0].Rows.Add(dsCPDocOperation.Tables[0].NewRow());
												dsCPDocOperation.Tables[0].Rows[dsCPDocOperation.Tables[0].Rows.Count - 1]["OperationTypeOfficeID_OperationTypeID"] =
													((DocumentProps)(tcDocs.TabPages[h].Controls[0])).cbDoc4.SelectedValue.ToString();
												dsCPDocOperation.Tables[0].Rows[dsCPDocOperation.Tables[0].Rows.Count - 1]["CPDocID"] = drDoc["Id"];
											}

											if (((DocumentProps)(tcDocs.TabPages[h].Controls[0])).chbPrintDoc5.Checked)
											{
												if (docProps.cbDoc5.SelectedValue == null)
												{
													sbStatus.Text = "Please, choose any value for the document";
													this.Cursor = Cursors.Arrow;
													IsOK = false;
													return IsOK;
												}

												dsCPDocOperation.Tables[0].Rows.Add(dsCPDocOperation.Tables[0].NewRow());
												dsCPDocOperation.Tables[0].Rows[dsCPDocOperation.Tables[0].Rows.Count - 1]["OperationTypeOfficeID_OperationTypeID"] =
													((DocumentProps)(tcDocs.TabPages[h].Controls[0])).cbDoc5.SelectedValue.ToString();
												dsCPDocOperation.Tables[0].Rows[dsCPDocOperation.Tables[0].Rows.Count - 1]["CPDocID"] = drDoc["Id"];
											}

											if (((DocumentProps)(tcDocs.TabPages[h].Controls[0])).chbPrintDoc6.Checked)
											{
												if (docProps.cbDoc6.SelectedValue == null)
												{
													sbStatus.Text = "Please, choose any value for the document";
													this.Cursor = Cursors.Arrow;
													IsOK = false;
													return IsOK;
												}

												dsCPDocOperation.Tables[0].Rows.Add(dsCPDocOperation.Tables[0].NewRow());
												dsCPDocOperation.Tables[0].Rows[dsCPDocOperation.Tables[0].Rows.Count - 1]["OperationTypeOfficeID_OperationTypeID"] =
													((DocumentProps)(tcDocs.TabPages[h].Controls[0])).cbDoc6.SelectedValue.ToString();
												dsCPDocOperation.Tables[0].Rows[dsCPDocOperation.Tables[0].Rows.Count - 1]["CPDocID"] = drDoc["Id"];
											}
											try
											{
												DataSet dsCPDocRules = ((DocumentProps)(tcDocs.TabPages[h].Controls[0])).Rulez;
												dsCPDocRules.Tables[0].TableName = "CPDocRule";

												//((Cntrls.DocumentProps)tcDocs.TabPages[h].Controls[0]).ptPartTree.SelectedNode.Tag

												for (int i = 0; i < dsCPDocRules.Tables[0].Rows.Count; i++)
													dsCPDocRules.Tables[0].Rows[i]["CPDocID"] = drDoc["Id"];
#if DEBUG
												try
												{
													// For debugging only			
													string filename = "C:/DELL/myXml_CPRules.xml";
													if (File.Exists(filename)) File.Delete(filename);
													// Create the FileStream to write with.
													FileStream myFileStream = new FileStream(filename, System.IO.FileMode.Create);
													// Create an XmlTextWriter with the fileStream.
													System.Xml.XmlTextWriter myXmlWriter = new System.Xml.XmlTextWriter(myFileStream, System.Text.Encoding.Unicode);
													// Write to the file with the WriteXml method.
													dsCPDocRules.WriteXml(myXmlWriter);
													myXmlWriter.Close();
													// End of debugging part
												}
												catch
												{ }
#endif
												if (SaveBulk)
												{
													var TableToXML = dsCPDocRules.GetXml();
													var PartID = ((DocumentProps)tcDocs.TabPages[h].Controls[0]).ptPartTree.SelectedNode.Tag;
													Service.SetBulkCPDocRules(PartID.ToString(), drDoc["Id"].ToString(), TableToXML, "1");
													SaveBulk = false;
												}
												else Service.SetCPDocRules(dsCPDocRules);

											}
											// ???
											catch (Exception exc)
											{
												this.sbStatus.Text = "Save failed";
												Console.WriteLine(exc.Message);
											}
										}
										iDocNum++;
									}
								}
								//sbStatus.Text = "Customer program was saved successfully";

								if (dsCPDocMeasureGroup.Tables[0].Rows.Count > 0)
									try
									{
										Service.SetCPDoc_MeasureGroup(dsCPDocMeasureGroup);
									}
									catch
									{
										sbStatus.Text = "Error saving Measure Groups. Measure Groups were not saved";
										this.Cursor = Cursors.Arrow;
										IsOK = false;
										return IsOK;
									}


								if (dsCPDocOperation.Tables[0].Rows.Count > 0)
									try
									{
										gemoDream.Service.Debug_DiaspalyDataSet(dsCPDocOperation);
										Service.SetCPDoc_Operation(dsCPDocOperation);
									}
									catch
									{
										sbStatus.Text = "Error saving Document Operations. Document Operations were not saved";
										this.Cursor = Cursors.Arrow;
										IsOK = false;
										return IsOK;
									}
								//mvs
								//if(MessageBox.Show("Customer program was saved successfully.\nWould you like to clear all the fields?", "Successfull save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
								//	DialogResult.Yes)
								//{
								//	ctcCustomer.ComboField.cbField.SelectedIndex = 0;
								//	ctcCustomer.Focus();
								//	tbCustProgName.Text = "";
								//    ctcVendor.ComboField.cbField.SelectedIndex = 0;
								//}
								//

								//ClearAll();
							}
						}
					}
				}
				this.Cursor = Cursors.Default;
				bIfError = false;
			}
			IsOK = true;
			return IsOK;
		}

		private void tbCustProgName_TextChanged(object sender, EventArgs e)
		{

		}

		private void cbCustomerProgram_SelectedIndexChanged(object sender, EventArgs e)
		{
			//this.tb
			if (!IsLoadCPInstance)
			{
				tbCustProgName.Text = cbCustomerProgram.Text.Trim();
				//cbCustomerProgram.SelectedItem.ToString();
				try
				{
					this.LoadCP(cbCustomerProgram.SelectedItem.ToString());
					if (CPOfficeID_CPID != null && CPOfficeID_CPID.Length != 0)
					{

						char separator = '_';
						string[] sCPOfficeID_CPID = CPOfficeID_CPID.Split(separator);
						string sCPOfficeID = sCPOfficeID_CPID[0];
						string sCPID = sCPOfficeID_CPID[1];

						this.iDocumentsCount = this.GetDocumentsCount(sCPOfficeID, sCPID);
					}

				}
				catch
				{ }
			}
		}

		private void LoadCP(string CPname)
		{
			this.Focus();
			skuMode = SKULoadMode.Main;
			ipItems.ListItems.Enabled = true;
			dsPricing = null;
			CPOfficeID_CPID = "";
			ipItems.ItemPicture = null;
			for (int i = 1; i < tcDocs.TabPages.Count; i++)
				tcDocs.TabPages.RemoveAt(i);
			InitOpsLeft();            //spGetOperationTree
			//InitDocs("LoadCP");	   
			InitMeasuresRechecks();   //spGetMeasureGroups
			//ipItems.Enabled = false;
			ipItems.Enabled = true;
			//vetal_242 06.01.2006

			if (this.AccessLevel >= 2)
			{
				bSaveCustProg.Enabled = true;
				bSaveCustProgAs.Enabled = true;
			}
			else
			{
				bSaveCustProg.Enabled = false;
				bSaveCustProgAs.Enabled = false;
				//if(this.AccessLevel == 2) bSaveCustProgAs.Enabled = true;
				//else bSaveCustProgAs.Enabled = false;
			}
			try
			{
				if (ctcCustomer.SelectedCode == "0" || ctcVendor.SelectedCode == "0" || CPname == "" ||
					ctcCustomer.SelectedCode == "" || ctcVendor.SelectedCode == "")
				{
					sbStatus.Text = "Customer, Vendor and Customer Program Names must be filled";
					this.Cursor = Cursors.Default;
					return;
				}

				dsCP = Service.GetCPByNameAndCustomer(
					CPname, ctcCustomer.ComboField.cbField.SelectedValue.ToString(),
					ctcVendor.ComboField.cbField.SelectedValue.ToString());//Procedures dbo.spGetCustomerProgramByNameAndCustomerTypeOf, 
																		   //dbo.spGetCustomerProgramByNameAndCustomer

				string sCPOfficeID_CPID = dsCP.Tables[0].Rows[0]["CPOfficeID_CPID"].ToString();

				string[] sID = sCPOfficeID_CPID.Split('_');
				string sCPOfficeID = sID[0];
				string sCPID = sID[1];

				this.ReInitDocs(sCPOfficeID, sCPID);


				tbComments.Text = dsCP.Tables[0].Rows[0]["Comment"].ToString();

				//string sPath = dsCP.Tables[0].Rows[0]["Path2Picture"].ToString();
				this.tbCPPropertyCustomerID.Text =
					dsCP.Tables[0].Rows[0]["CPPropertyCustomerID"].ToString();
				this.tbSRP.Text = dsCP.Tables[0].Rows[0]["SRP"].ToString();
				tbCustomerStyle.Text = dsCP.Tables[0].Rows[0]["CustomerStyle"].ToString();
				tbDescriptions.Text = dsCP.Tables[0].Rows[0]["Description"].ToString();
				//if (sPath != "" && sPath != "Default")
				//{
				//    tbPicPath.Text = dsCP.Tables[0].Rows[0]["Path2Picture"].ToString();
				//    tbPicPath.Focus();
				//    KeyEventArgs kea = new KeyEventArgs(Keys.Enter);
				//    tbPicPath_KeyDown(this, kea);
				//}
				//else
				//{
				//    tbPicPath.Text = "Default";
				//    ipItems.InitializePicture(ipItems.DefaultPicture);
				//}

				tbCustProgName.Focus();
				string sItemTypeID = dsCP.Tables[0].Rows[0]["ItemTypeID"].ToString();
				ipItems.SelectItemTypeById(dsCP.Tables[0].Rows[0]["ItemTypeID"].ToString(),
					dsCP.Tables[0].Rows[0]["ItemTypeGroupID"].ToString());

				//string sItemTypeID = ipItems.ItemId;
				DataSet dsData1 = new DataSet();
				DataTable dtParts = new DataTable();
				dtParts = Service.GetParts(sItemTypeID);
				dsData1.Tables.Add(dtParts);

				DataSet dsOps = Service.GetCPOperationsTypeEx();
				dsOps.Tables[0].TableName = "CPOperations";
				dsOps.Tables[0].Rows.Add(dsOps.Tables[0].NewRow());
				dsOps.Tables[0].Rows[0]["CPOfficeID_CPID"] = dsCP.Tables[0].Rows[0]["CPOfficeID_CPID"];
				DataSet dsOpsIni = Service.GetCPOperations(dsOps.Copy());
				//dsOps.Tables[0].TableName = "CPOperations";
				//dsOps = Service.GetCPOperations(dsOps);
				string id;
				for (int i = 0; i < dsOpsIni.Tables[0].Rows.Count; i++)
				{
					id = ptrOpsLeft.Data.Select("OperationTypeOfficeID_OperationTypeId='" + dsOpsIni.Tables[0].Rows[i]["OperationTypeOfficeID_OperationTypeId"].ToString() + "'")[0]["ID"].ToString();
					selected = id;
					DoRight(id);
				}

				//vetal_242 21.06.2006
				DataSet dsIDs = new DataSet();
				dsIDs = Service.GetCheckedOperationByCP(CPname, ctcCustomer.ComboField.cbField.SelectedValue.ToString());
				for (int i = 0; i < dsIDs.Tables[0].Rows.Count; i++)
				{
					this.CheckNode(ptrOpsRight.tvPartTree, dsIDs.Tables[0].Rows[i][0].ToString());
				}


				dsOps.Tables[0].TableName = "CPDocs";
				dsDocs = Service.GetCPDocs(dsOps.Copy());

				for (int i = 0; i < dsDocs.Tables[0].Rows.Count; i++)
				{
					int iCPDocID = Convert.ToInt32(dsDocs.Tables[0].Rows[i]["CPDocID"]);
					if (Convert.ToInt32(dsDocs.Tables[0].Rows[i]["nDocRule"]) == 0)
					{
						chbDefEnabled.Checked = true;
						chbReturn.Checked =
							dsDocs.Tables[0].Rows[i]["IsReturn"].ToString() == "1" ? true : false;
						tbDescription.Text = dsDocs.Tables[0].Rows[i]["Description"].ToString();

						DataSet dsDoc = Service.GetCPDocTypeEx();
						dsDoc.Tables[0].TableName = "CPDoc_MeasureGroup";
						dsDoc.Tables[0].Rows.Add(new object[] { iCPDocID });
						DataSet dsDocMeasures = Service.GetCPMeasures(dsDoc.Copy());

						DataTable dtMsrs = new DataTable("Rechecks");
						dtMsrs.Columns.Add("Property_Name");
						dtMsrs.Columns.Add("Do");
						dtMsrs.Columns.Add("Rechecks");

						DataSet dsCPDocOperations = Service.GetCPDocOperation(dsDoc.Copy());
						dsCPDocOperations.Tables[0].TableName = "CPDoc_Operation";

						bool bDo;
						int iRchcks;
						string sNm;
						for (int j = 0; j < dsDocMeasures.Tables[0].Rows.Count; j++)
						{
							bDo = true;
							iRchcks = Convert.ToInt32(dsDocMeasures.Tables[0].Rows[j]["NoRecheck"]);
							sNm = dsMeasureGroups.Tables[0].Select("MeasureGroupID=" + dsDocMeasures.Tables[0].Rows[j]["MeasureGroupID"].ToString())[0]["MeasureGroupName"].ToString();
							dtMsrs.Rows.Add(new object[] { sNm, bDo, iRchcks });
						}

						//E.B.M.
						InitMeasuresRechecks(dgRechecks, dtMsrs, DefaultTableStyle());

						ComboBox[] acbDocOps = new ComboBox[] { comboBoxD1, comboBoxD2, comboBoxD3, comboBoxD4 };
						CheckBox[] achbDocOpCheck = new CheckBox[] { checkBoxPD1, checkBoxPD2, checkBoxPD3, checkBoxPD4 };
						for (int k = 0; k < dsCPDocOperations.Tables[0].Rows.Count; k++)
						{
							string s = dsCPDocOperations.Tables[0].Rows[k]["OperationTypeOfficeID_OperationTypeID"].ToString();
							//if (!s.Equals("-1_1") && !s.Equals("-2_2") && !s.Equals("-3_3"))
							if (!Service.IsMagicOperation(s))
							{
								acbDocOps[k].SelectedValue = s;
								achbDocOpCheck[k].Checked = true;
							}
						}
						AccessRestriction(this.AccessLevel, ref acbDocOps, ref achbDocOpCheck);
						//						if(this.AccessLevel < 3)
						//						{
						//							for(int j = 0; j < 4; j++)
						//							{
						//								if(achbDocOpCheck[j].Checked)
						//								{
						//									acbDocOps[j].Visible = true;
						//									acbDocOps[j].MaxDropDownItems = 1;
						//									achbDocOpCheck[j].Visible = true;
						//								}
						//								else
						//								{
						//									acbDocOps[j].Visible = false;
						//									achbDocOpCheck[j].Visible = false;	
						//								}
						//							}
						//						}
					}
					else
					{
						DataSet dsDoc = Service.GetCPDocTypeEx();
						dsDoc.Tables[0].Rows.Add(new object[] { iCPDocID });

						DataSet dsCPDocRules = Service.GetCPDocRules(dsDoc.Copy());

						DataSet dsParts = new DataSet();
						dsParts.Tables.Add(Service.GetParts(ipItems.ItemId));

						DataTable dtMeasures = Service.GetMeasuresByItemType(sItemTypeID);
						dsParts.Tables.Add(dtMeasures);

						dsMeasureValues = new DataSet();
						dsMeasureValues.Tables.Add(Service.GetMeasureValues());

						TabPage tpDoc = new TabPage("Document " + tcDocs.TabPages.Count.ToString());


						//sItemTypeID = this.ipItems.itemId;
						string sPath2Picture = this.tbPicPath.Text.ToString();

						string sCPName = this.tbCustProgName.Text.Trim();

						DocumentProps dpProps = new DocumentProps(this.AccessLevel, dsDocOperations, dsMeasureValues, dsParts, dsCPDocRules,
							sCPOfficeID, sCPID, sItemTypeID, sPath2Picture, this.newOperationsList,
							sCPName);
						dpProps.InitTree(dtParts);
						dpProps.Location = new Point(5, 5);
						tpDoc.Controls.Add(dpProps);
						tcDocs.TabPages.Add(tpDoc);

						dpProps.checkBox1.Checked =
							dsDocs.Tables[0].Rows[i]["IsReturn"].ToString() == "1" ? true : false;
						dpProps.tbDescription.Text = dsDocs.Tables[0].Rows[i]["Description"].ToString();
						dpProps.chbDocEnabled.Checked = true;

						dsDoc.Tables[0].TableName = "CPDoc_MeasureGroup";
						DataSet dsDocMeasures = Service.GetCPMeasures(dsDoc.Copy());

						DataSet dsCPDocOperations = dsDoc.Copy();
						dsCPDocOperations.Tables[0].TableName = "CPDoc_Operation";
						dsCPDocOperations = Service.GetCPDocOperation(dsDoc.Copy());

						DataTable dtMsrs = new DataTable("Rechecks");
						dtMsrs.Columns.Add("Property_Name");
						dtMsrs.Columns.Add("Do");
						dtMsrs.Columns.Add("Rechecks");

						bool bDo;
						int iRchcks;
						string sNm;
						for (int j = 0; j < dsDocMeasures.Tables[0].Rows.Count; j++)
						{
							bDo = true;
							iRchcks = Convert.ToInt32(dsDocMeasures.Tables[0].Rows[j]["NoRecheck"]);
							sNm = dsMeasureGroups.Tables[0].Select("MeasureGroupID=" + dsDocMeasures.Tables[0].Rows[j]["MeasureGroupID"].ToString())[0]["MeasureGroupName"].ToString();
							dtMsrs.Rows.Add(new object[] { sNm, bDo, iRchcks });
						}

						InitMeasuresRechecks(dpProps.dgRechecks, dtMsrs, NewTableStyle());

						ComboBox[] acbDocOps = new ComboBox[] { dpProps.cbDoc1, dpProps.cbDoc2, dpProps.cbDoc3, dpProps.cbDoc4, dpProps.cbDoc5, dpProps.cbDoc6 };
						CheckBox[] achbDocOpCheck = new CheckBox[] { dpProps.chbPrintDoc1, dpProps.chbPrintDoc2, dpProps.chbPrintDoc3, dpProps.chbPrintDoc4, dpProps.chbPrintDoc5, dpProps.chbPrintDoc6 };
						CheckBox[] achbShowDoc = new CheckBox[] { dpProps.chbShowDoc1, dpProps.chbShowDoc2, dpProps.chbShowDoc3, dpProps.chbShowDoc4, dpProps.chbShowDoc5, dpProps.chbShowDoc6 };
						for (int k = 0; k < dsCPDocOperations.Tables[0].Rows.Count; k++)
						{
							string s = dsCPDocOperations.Tables[0].Rows[k]["OperationTypeOfficeID_OperationTypeID"].ToString();
							//if (!s.Equals("-1_1") && !s.Equals("-2_2") && !s.Equals("-3_3"))
							if (!Service.IsMagicOperation(s))
							{
								achbDocOpCheck[k].Checked = true;
								acbDocOps[k].SelectedValue = dsCPDocOperations.Tables[0].Rows[k]["OperationTypeOfficeID_OperationTypeID"];
								achbShowDoc[k].Enabled = true;
							}
						}
						AccessRestriction(this.AccessLevel, ref acbDocOps, ref achbDocOpCheck);
						//						if(this.AccessLevel < 3)
						//						{
						//							for(int j = 0; j < 6; j++)
						//							{
						//								//acbDocOps[j].Enabled = false;
						//								//achbDocOpCheck[j].Enabled = false;								
						//								
						//								if(achbDocOpCheck[j].Checked)
						//								{
						//									acbDocOps[j].Visible = true;
						//									acbDocOps[j].MaxDropDownItems = 1;
						//									achbDocOpCheck[j].Visible = true;
						//									//acbDocOps[j].ForeColor = System.Drawing.Color.Brown;
						//									//acbDocOps[j].BackColor = System.Drawing.Color.White;
						//								}
						//								else
						//								{
						//									acbDocOps[j].Visible = false;
						//									achbDocOpCheck[j].Visible = false;	
						//								}
						//							}
						//						}
					}
				}

				tcDocs.Enabled = true;
				tcOpsReqs.Enabled = true;
				CPOfficeID_CPID = dsCP.Tables[0].Rows[0]["CPOfficeID_CPID"].ToString();
				InitPartTree(ipItems.ItemId);

				//InitPricing();

				/*
                string[] sID = CPOfficeID_CPID.Split('_');
                string sCPOfficeID = sID[0];
                string sCPID = sID[1];

                this.ReInitDocs(sCPOfficeID, sCPID);
                */

			}
			catch (Exception exc)
			{
				MessageBox.Show(this, "Can't load customer program. Reason: " + exc.ToString(),
					"Internal error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				//Console.WriteLine(exc.Message);
				sbStatus.Text = "Typed customer program name doesn't exist. Please, check the spelling";
				ClearAll();
				this.Cursor = Cursors.Default;
				return;
			}
			string sPath = dsCP.Tables[0].Rows[0]["Path2Picture"].ToString();
			if (sPath.Trim() != "" && !sPath.ToUpper().Contains("DEFAULT"))
			{
				tbPicPath.Text = dsCP.Tables[0].Rows[0]["Path2Picture"].ToString();
				tbPicPath.Focus();
				KeyEventArgs kea = new KeyEventArgs(Keys.Enter);
				tbPicPath_KeyDown(this, kea);
			}
			if (sPath.ToUpper().Contains("DEFAULT")) tbPicPath.Text = sPath;

			sbStatus.Text = "Customer Program is loaded successfully";
			tbCustProgName.Focus();
		}

		//mvs
		private void LoadCPInstance(string strOrderCode, string strBatchCode)
		{
			try
			{
				//ipItems.ListItems.Enabled = false;
				skuMode = SKULoadMode.Instance;
				/*
                if(ctcCustomer.SelectedCode == "0" || ctcVendor.SelectedCode == "0" || //CPname == "" ||
                    ctcCustomer.SelectedCode == "" || ctcVendor.SelectedCode == "")
                {
                    sbStatus.Text = "Customer, Vendor and Customer Program Name must be filled";
                    this.Cursor = Cursors.Default;
                    return;
                }
                */

				//dsCP = Service.GetCPByNameAndCustomer(CPname, ctcCustomer.ComboField.cbField.SelectedValue.ToString(),
				//	ctcVendor.ComboField.cbField.SelectedValue.ToString());

				DataSet dsData = new DataSet();
				dsData.Tables.Add("CustomerProgramInstanceByBatchCodeTypeOf");
				dsData = gemoDream.Service.ProxyGenericGet(dsData);//Procedure dbo.spGetCustomerProgramInstanceByBatchCodeTypeOf
				dsData.Tables[0].TableName = "CustomerProgramInstanceByBatchCode";
				dsData.Tables[0].Rows.Add(dsData.Tables[0].NewRow());
				dsData.Tables[0].Rows[0]["GroupCode"] = strOrderCode;
				dsData.Tables[0].Rows[0]["BatchCode"] = strBatchCode;
				dsCP = gemoDream.Service.ProxyGenericGet(dsData);//Procedure dbo.spGetCustomerProgramInstanceByBatchCode

				if (dsCP.Tables[0].Rows.Count == 0)
				{
					ShowBatchCodeIsNotExistMessageBox(strBatchCode);
					ClearAll();
					tbBatchCode.Focus();
					return;
				}

				skuItemTypeID = Convert.ToInt32(dsCP.Tables[0].Rows[0]["ItemTypeID"].ToString());
				string sItemTypeID = skuItemTypeID.ToString();   //ipItems.ItemId;
				CPOfficeID_CPID = "";

				for (; tcDocs.TabPages.Count > 1;)
					tcDocs.TabPages.RemoveAt(tcDocs.TabPages.Count - 1);
				InitOpsLeft();//Procedure dbo.spGetOperationTree
							  //InitDocs("LoadCPInstance");
				InitMeasuresRechecks();//Procedure dbo.spGetMeasureGroups
				ipItems.Enabled = true; // false;
				if (this.AccessLevel >= 2)
				{
					bSaveCustProg.Enabled = true;
					bSaveCustProgAs.Enabled = true;
				}
				IsLoadCPInstance = true;
				ipItems.instanceLoaded = IsLoadCPInstance;
				string strCustomer = dsCP.Tables[0].Rows[0]["CustomerOfficeID"].ToString() +
					"_" + dsCP.Tables[0].Rows[0]["CustomerID"].ToString();
				IsCustomerSelected = true;
				try
				{
					ctcCustomer.ComboField.cbField.SelectedValue = strCustomer;//Load info for customer CP's, global info for measure and docs
					IsCustomerSelected = false;
				}
				catch (Exception ex)
				{
					int index = 0;
					int result = -2;
					foreach (DataRowView drv in ctcCustomer.ComboField.cbField.Items)
					{
						string s1 = drv.Row["CustomerOfficeID_CustomerID"].ToString();
						if (s1 == strCustomer)
						{
							result = index;
							break;
						}
						index++;
					}
					ctcCustomer.ComboField.cbField.SelectedIndex = result;
				}

				string strVendor = dsCP.Tables[0].Rows[0]["VendorOfficeID"].ToString() +
					"_" + dsCP.Tables[0].Rows[0]["VendorID"].ToString();
				//if (dsCP.Tables[0].Rows[0]["VendorOfficeID"] )
				if (strVendor.Length > 1)
				{
					if (!strCustomer.Equals(strVendor))
					{
						//this.ctcVendor.ComboField.cbField.Enabled = true;
						this.ctcVendor.Enabled = true;
						this.chbSameVendor.Checked = false;
					}
					else
					{
						this.ctcVendor.Enabled = false;
						this.chbSameVendor.Checked = true;
					}
					IsVendorSelected = true;
					ctcVendor.ComboField.cbField.SelectedValue = strVendor;
				}
				else
				{
					this.ctcVendor.Enabled = false;
					this.chbSameVendor.Checked = true;
					//*************
					try
					{
						ctcVendor.ComboField.cbField.SelectedValue = strCustomer;
					}
					catch (Exception ex)
					{
						int index = 0;
						int result = -2;
						foreach (DataRowView drv in ctcVendor.ComboField.cbField.Items)
						{
							string s1 = drv.Row["CustomerOfficeID_CustomerID"].ToString();
							if (s1 == strCustomer)
							{
								result = index;
								break;
							}
							index++;
						}
						//if(result>-1)
						ctcVendor.ComboField.cbField.SelectedIndex = result;
					}
					//ctcVendor.ComboField.cbField.SelectedValue = strCustomer;
					//***************
				}

				if (IsLoadFromItemizn)
				{
					ctcCustomer.Enabled = false;
					ctcVendor.Enabled = false;
					chbSameVendor.Enabled = false;
				}

				//gemoDream.Service.debug_DiaspalyDataSet(dsCP);

				string sCPOfficeID_CPID = dsCP.Tables[0].Rows[0]["CPOfficeID_CPID"].ToString();

				string[] sID = sCPOfficeID_CPID.Split('_');
				string sCPOfficeID = sID[0];
				string sCPID = sID[1];

				this.ReInitDocs(sCPOfficeID, sCPID);

				string strCPName = dsCP.Tables[0].Rows[0]["CustomerProgramName"].ToString().Trim();

				tbCustProgName.Text = strCPName;
				if (cbCustomerProgram.Items.Contains(tbCustProgName.Text))
			  				cbCustomerProgram.SelectedItem = tbCustProgName.Text.Trim();
				else
				{
					cbCustomerProgram.Text = strCPName;
					cbCustomerProgram.SelectedIndex = -1;
				}

				tbCustProgName.Enabled = false;
				cbCustomerProgram.Enabled = false;
				bSaveCustProgAs.Enabled = false;

				//isCPInstanceLoad = true;
				//bNewCustProg.Enabled = false;

				//cbCustomerProgram.SelectedValue = 

				tbComments.Text = dsCP.Tables[0].Rows[0]["Comment"].ToString();

				tbCustProgName.Focus();
				ipItems.SelectItemTypeById(dsCP.Tables[0].Rows[0]["ItemTypeID"].ToString(),
					dsCP.Tables[0].Rows[0]["ItemTypeGroupID"].ToString());//Procedures spGetMeasuresByItemType,spGetPartsByItemType,


				string sPath = dsCP.Tables[0].Rows[0]["Path2Picture"].ToString();
				this.tbCPPropertyCustomerID.Text =
					dsCP.Tables[0].Rows[0]["CPPropertyCustomerID"].ToString();
				if (dsCP.Tables[0].Rows[0]["SRP"] == DBNull.Value)
					this.tbSRP.Text = "";
				else
					this.tbSRP.Text = dsCP.Tables[0].Rows[0]["SRP"].ToString();
				tbCustomerStyle.Text = dsCP.Tables[0].Rows[0]["CustomerStyle"].ToString();
				tbDescriptions.Text = dsCP.Tables[0].Rows[0]["Description"].ToString();
				if (sPath.Trim() != "" && sPath.IndexOf("Default") < 0)
				{
					tbPicPath.Text = dsCP.Tables[0].Rows[0]["Path2Picture"].ToString();
					tbPicPath.Focus();
					KeyEventArgs kea = new KeyEventArgs(Keys.Enter);
					tbPicPath_KeyDown(this, kea);
				}
				else
				{
					try
					{
						tbPicPath.Text = "Default";
						ipItems.InitializePicture(ipItems.DefaultPicture);
					}
					catch (Exception ex1)
					{
						MessageBox.Show("Can not initialize picture");
					}
				}
				
				//string sItemTypeID = skuItemTypeID.ToString();   //ipItems.ItemId;
				//ipItems.LoadItemitemTypeView(false, sItemTypeID);

				DataSet dsData1 = new DataSet();
				DataTable dtParts = new DataTable();
				dtParts = Service.GetParts(sItemTypeID);//Procedure dbo.spGetPartsByItemType
				dsData1.Tables.Add(dtParts);

				DataSet dsOps = Service.GetCPOperationsTypeEx();//Procedure dbo.spGetCPOperationsTypeEx
				dsOps.Tables[0].TableName = "CPOperations";
				dsOps.Tables[0].Rows.Add(dsOps.Tables[0].NewRow());
				dsOps.Tables[0].Rows[0]["CPOfficeID_CPID"] = dsCP.Tables[0].Rows[0]["CPOfficeID_CPID"];
				DataSet dsOpsIni = Service.GetCPOperations(dsOps.Copy());//Procedure dbo.spGetCPOperations
																		 //dsOps.Tables[0].TableName = "CPOperations";
																		 //dsOps = Service.GetCPOperations(dsOps);
				string id;
				for (int i = 0; i < dsOpsIni.Tables[0].Rows.Count; i++)
				{
					id = ptrOpsLeft.Data.Select("OperationTypeOfficeID_OperationTypeId='" + dsOpsIni.Tables[0].Rows[i]["OperationTypeOfficeID_OperationTypeId"].ToString() + "'")[0]["ID"].ToString();
					selected = id;
					DoRight(id);
				}

				dsOps.Tables[0].TableName = "CPDocs";
				dsDocs = Service.GetCPDocs(dsOps.Copy());//Procedure dbo.spGetCPDocs

				for (int i = 0; i < dsDocs.Tables[0].Rows.Count; i++)
				{
					int iCPDocID = Convert.ToInt32(dsDocs.Tables[0].Rows[i]["CPDocID"]);
					if (Convert.ToInt32(dsDocs.Tables[0].Rows[i]["nDocRule"]) == 0)
					{
						chbDefEnabled.Checked = true;
						chbReturn.Checked =
							dsDocs.Tables[0].Rows[i]["IsReturn"].ToString() == "1" ? true : false;
						tbDescription.Text = dsDocs.Tables[0].Rows[i]["Description"].ToString();

						DataSet dsDoc = Service.GetCPDocTypeEx();//Procedure dbo.spGetCPDocTypeEx
						dsDoc.Tables[0].TableName = "CPDoc_MeasureGroup";
						dsDoc.Tables[0].Rows.Add(new object[] { iCPDocID });
						DataSet dsDocMeasures = Service.GetCPMeasures(dsDoc.Copy());//procedure dbo.spGetCPDoc_MeasureGroup

						DataTable dtMsrs = new DataTable("Rechecks");
						dtMsrs.Columns.Add("Property_Name");
						dtMsrs.Columns.Add("Do");
						dtMsrs.Columns.Add("Rechecks");

						DataSet dsCPDocOperations = Service.GetCPDocOperation(dsDoc.Copy());//procedure dbo.spGetCPDoc_Operation
						dsCPDocOperations.Tables[0].TableName = "CPDoc_Operation";

						bool bDo;
						int iRchcks;
						string sNm;
						for (int j = 0; j < dsDocMeasures.Tables[0].Rows.Count; j++)
						{
							bDo = true;
							iRchcks = Convert.ToInt32(dsDocMeasures.Tables[0].Rows[j]["NoRecheck"]);
							sNm = dsMeasureGroups.Tables[0].Select("MeasureGroupID=" + dsDocMeasures.Tables[0].Rows[j]["MeasureGroupID"].ToString())[0]["MeasureGroupName"].ToString();
							dtMsrs.Rows.Add(new object[] { sNm, bDo, iRchcks });
						}

						//E.B.M.
						InitMeasuresRechecks(dgRechecks, dtMsrs, DefaultTableStyle());//Procedure dbo.spGetMeasureGroups

						ComboBox[] acbDocOps = new ComboBox[] { comboBoxD1, comboBoxD2, comboBoxD3, comboBoxD4 };
						CheckBox[] achbDocOpCheck = new CheckBox[] { checkBoxPD1, checkBoxPD2, checkBoxPD3, checkBoxPD4 };
						for (int k = 0; k < dsCPDocOperations.Tables[0].Rows.Count; k++)
						{
							string s = dsCPDocOperations.Tables[0].Rows[k]["OperationTypeOfficeID_OperationTypeID"].ToString();
							//if (!s.Equals("-1_1") && !s.Equals("-2_2") && !s.Equals("-3_3"))
							if (!Service.IsMagicOperation(s))
							{
								acbDocOps[k].SelectedValue = dsCPDocOperations.Tables[0].Rows[k]["OperationTypeOfficeID_OperationTypeID"];
								//acbDocOps[k].
								achbDocOpCheck[k].Checked = true;
							}
							//							acbDocOps[k].SelectedValue = dsCPDocOperations.Tables[0].Rows[k]["OperationTypeOfficeID_OperationTypeID"];
							//							achbDocOpCheck[k].Checked = true;
						}
						AccessRestriction(this.AccessLevel, ref acbDocOps, ref achbDocOpCheck);
					}
					else
					{
						DataSet dsDoc = Service.GetCPDocTypeEx();//Procedure dbo.spGetCPDocTypeEx							
						dsDoc.Tables[0].Rows.Add(new object[] { iCPDocID });

						DataSet dsCPDocRules = Service.GetCPDocRules(dsDoc.Copy());//Procedure dbo.spGetCPDocRule

						DataSet dsParts = new DataSet();
						dsParts.Tables.Add(Service.GetParts(ipItems.ItemId));//Procedures dbo.spGetPartsByItemTypeEx, dbo.spGetPartsByItemType

						DataTable dtMeasures = Service.GetMeasuresByItemType(sItemTypeID);//Procedure dbo.spGetMeasuresByItemType
						dsParts.Tables.Add(dtMeasures);

						dsMeasureValues = new DataSet();
						dsMeasureValues.Tables.Add(Service.GetMeasureValues());//Procedure dbo.spGetMeasureValues

						TabPage tpDoc = new TabPage("Document " + tcDocs.TabPages.Count.ToString());

						//string sCPOfficeID = "";
						//string sCPID = "";

						//sItemTypeID = ipItems.itemId;
						string sPath2Picture = this.tbPicPath.Text.ToString();

						string sCPName = this.tbCustProgName.Text.Trim();

						dpPropsB = new DocumentProps(this.AccessLevel, dsDocOperations, dsMeasureValues, dsParts, dsCPDocRules,
							sCPOfficeID, sCPID, sItemTypeID, sPath2Picture,
							this.newOperationsList, sCPName);

						dpPropsB.InitTree(dtParts);
						dpPropsB.Location = new Point(5, 5);
						tpDoc.Controls.Add(dpPropsB);
						tcDocs.TabPages.Add(tpDoc);

						dpPropsB.checkBox1.Checked =
							dsDocs.Tables[0].Rows[i]["IsReturn"].ToString() == "1" ? true : false;
						dpPropsB.tbDescription.Text = dsDocs.Tables[0].Rows[i]["Description"].ToString();
						dpPropsB.chbDocEnabled.Checked = true;

						dsDoc.Tables[0].TableName = "CPDoc_MeasureGroup";
						DataSet dsDocMeasures = Service.GetCPMeasures(dsDoc.Copy());//Procedure dbo.spGetCPDoc_MeasureGroup

						DataSet dsCPDocOperations = dsDoc.Copy();
						dsCPDocOperations.Tables[0].TableName = "CPDoc_Operation";
						dsCPDocOperations = Service.GetCPDocOperation(dsDoc.Copy());

						DataTable dtMsrs = new DataTable("Rechecks");
						dtMsrs.Columns.Add("Property_Name");
						dtMsrs.Columns.Add("Do");
						dtMsrs.Columns.Add("Rechecks");

						bool bDo;
						int iRchcks;
						string sNm;
						for (int j = 0; j < dsDocMeasures.Tables[0].Rows.Count; j++)
						{
							bDo = true;
							iRchcks = Convert.ToInt32(dsDocMeasures.Tables[0].Rows[j]["NoRecheck"]);
							sNm = dsMeasureGroups.Tables[0].Select("MeasureGroupID=" + dsDocMeasures.Tables[0].Rows[j]["MeasureGroupID"].ToString())[0]["MeasureGroupName"].ToString();
							dtMsrs.Rows.Add(new object[] { sNm, bDo, iRchcks });
						}

						InitMeasuresRechecks(dpPropsB.dgRechecks, dtMsrs, NewTableStyle());

						ComboBox[] acbDocOps = new ComboBox[] { dpPropsB.cbDoc1, dpPropsB.cbDoc2, dpPropsB.cbDoc3, dpPropsB.cbDoc4, dpPropsB.cbDoc5, dpPropsB.cbDoc6 };
						CheckBox[] achbDocOpCheck = new CheckBox[] { dpPropsB.chbPrintDoc1, dpPropsB.chbPrintDoc2, dpPropsB.chbPrintDoc3, dpPropsB.chbPrintDoc4, dpPropsB.chbPrintDoc5, dpPropsB.chbPrintDoc6 };
						CheckBox[] achbShowDoc = new CheckBox[] { dpPropsB.chbShowDoc1, dpPropsB.chbShowDoc2, dpPropsB.chbShowDoc3, dpPropsB.chbShowDoc4, dpPropsB.chbShowDoc5, dpPropsB.chbShowDoc6 };
						for (int k = 0; k < dsCPDocOperations.Tables[0].Rows.Count; k++)
						{
							string s = dsCPDocOperations.Tables[0].Rows[k]["OperationTypeOfficeID_OperationTypeID"].ToString();
							//if (!s.Equals("-1_1") && !s.Equals("-2_2") && !s.Equals("-3_3"))
							if (!Service.IsMagicOperation(s))
							{
								achbDocOpCheck[k].Checked = true;
								acbDocOps[k].SelectedValue = dsCPDocOperations.Tables[0].Rows[k]["OperationTypeOfficeID_OperationTypeID"];
								achbShowDoc[k].Enabled = true;
							}
							//							achbDocOpCheck[k].Checked = true;
							//							acbDocOps[k].SelectedValue = dsCPDocOperations.Tables[0].Rows[k]["OperationTypeOfficeID_OperationTypeID"];
						}
						AccessRestriction(this.AccessLevel, ref acbDocOps, ref achbDocOpCheck);
						//						if(this.AccessLevel < 3)
						//						{
						//							for(int j = 0; j < 6; j++)
						//							{
						//								if(achbDocOpCheck[j].Checked)
						//								{
						//									acbDocOps[j].Visible = true;
						//									acbDocOps[j].MaxDropDownItems = 1;
						//									achbDocOpCheck[j].Visible = true;
						//									//acbDocOps[j].ForeColor = System.Drawing.Color.Brown;
						//									//acbDocOps[j].BackColor = System.Drawing.Color.White;
						//								}
						//								else
						//								{
						//									acbDocOps[j].Visible = false;
						//									achbDocOpCheck[j].Visible = false;	
						//								}
						//							}
						//						}
					}
				}

				tcDocs.Enabled = true;
				tcOpsReqs.Enabled = true;
				ipItems.LoadItemitemTypeView(false, skuItemTypeID.ToString());
				CPOfficeID_CPID = dsCP.Tables[0].Rows[0]["CPOfficeID_CPID"].ToString();
				if (sPath.Trim() != "" && !sPath.ToUpper().Contains("DEFAULT"))
				{
					tbPicPath.Text = dsCP.Tables[0].Rows[0]["Path2Picture"].ToString();
					tbPicPath.Focus();
					KeyEventArgs kea = new KeyEventArgs(Keys.Enter);
					tbPicPath_KeyDown(this, kea);
				}
				if (sPath.ToUpper().Contains("DEFAULT")) tbPicPath.Text = sPath;
			}
			catch (Exception exc)
			{
				Console.WriteLine(exc.Message);
				sbStatus.Text = "Typed customer program name doesn't exist. Please, check the spelling";
				ClearAll();
				this.Cursor = Cursors.Default;
				return;
			}

			bNewCustProg.Enabled = false;

			sbStatus.Text = "Customer Program is loaded successfully";
			if (ClearBatchCodeOnSuccessOrFailure == "true")
				IsClearBatchCode = true;

			//vetal_242 22.06.2006
			string sBatchID = Service.GetBatchByCode(strOrderCode, strBatchCode);//Procedure dbo.spGetBatchByCode

			DataSet dsIDs = new DataSet();
			dsIDs.Tables.Add("NameCheckedOperationByBatchID");
			dsIDs.Tables[0].Columns.Add("BatchID");
			dsIDs.Tables[0].Rows.Add(dsIDs.Tables[0].NewRow());
			dsIDs.Tables[0].Rows[0][0] = sBatchID;

			dsIDs = Service.GetNameCheckedOperationByBatchID(dsIDs);//Procedure dbo.spGetNameCheckedOperationByBatchID
			for (int i = 0; i < dsIDs.Tables[0].Rows.Count; i++)
			{
				this.CheckNode(ptrOpsRight.tvPartTree, dsIDs.Tables[0].Rows[i][1].ToString());
			}
			skuMode = SKULoadMode.Main;
		}//LoadCPInstance


		private void ctcVendor_SelectionChanged(object sender, EventArgs e)
		{
			// mvs
			if (!IsVendorSelected)
				IsLoadCPInstance = false;
			if (!IsVendorSelected)
			{
				ctcCustomer_SelectedIndexChanged(sender, e);
			}
			IsVendorSelected = false;
			if (ClearBatchCodeOnSuccessOrFailure == "true")
				IsClearBatchCode = false;
			//mvs
		}

		//mvs
		private void tbBatchCode_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar != 13 && e.KeyChar != 8)
			{
				string str = this.tbBatchCode.Text.ToString();
				if (str.Equals("#####.###") ||
					(ClearBatchCodeOnSuccessOrFailure == "true" && IsClearBatchCode == true))
				{
					if (ClearBatchCodeOnSuccessOrFailure == "true")
						IsClearBatchCode = false;
					str = "";
					tbBatchCode.Text = str;
				}

				str += e.KeyChar.ToString();

				string pattern = "[0-9]{0,9}";
				Regex rex = new Regex(pattern);

				Match m = rex.Match(str);
				if (m.Length != str.Length)
					e.Handled = true;
			}
			else if (e.KeyChar == 13)
			{
				string strBatch = tbBatchCode.Text.ToString();
				if (strBatch.Length > 7)
				{
					string sGroupCode = "";
					string sBatchCode = "";
					if (strBatch.Length == 8)
					{
						sGroupCode = strBatch.Substring(0, 5);
						sBatchCode = strBatch.Substring(5, 3);
					}
					if (strBatch.Length == 9)
					{
						sGroupCode = strBatch.Substring(0, 6);
						sBatchCode = strBatch.Substring(6, 3);
					}

					LoadCPInstance(sGroupCode, sBatchCode);
					//ipItems.LoadItemitemTypeView(false, skuItemTypeID.ToString());
					if (CPOfficeID_CPID != null && CPOfficeID_CPID.Length != 0)
					{
						char separator = '_';
						string[] sCPOfficeID_CPID = CPOfficeID_CPID.Split(separator);
						string sCPOfficeID = sCPOfficeID_CPID[0];
						string sCPID = sCPOfficeID_CPID[1];
						this.iDocumentsCount = this.GetDocumentsCount(sCPOfficeID, sCPID);
						dsPricing = null;
					}
					bSaveCustProg.Enabled = true;
					bSaveCustProgAs.Enabled = false;
					bNewCustProg.Enabled = false;
				}
				else
				{
					ShowBatchCodeIsNotExistMessageBox(strBatch);
					ClearAll();
					bSaveCustProg.Enabled = false;
					bSaveCustProgAs.Enabled = false;
					bNewCustProg.Enabled = false;
				}
			}

		}
		//mvs

		//mvs
		public void InitializeFormFromItemzn(string sBatchID)
		{
			tbBatchCode.Text = sBatchID;
			tbBatchCode.Enabled = false;
			this.tbCPPropertyCustomerID.Text = "";
			this.tbSRP.Text = "";
			tbCustomerStyle.Text = "";
			DataSet dsIn = new DataSet();
			dsIn.Tables.Add("BatchTypeEx");
			dsIn = gemoDream.Service.ProxyGenericGet(dsIn);
			dsIn.Tables[0].TableName = "Batch";
			dsIn.Tables[0].Rows.Add(dsIn.Tables[0].NewRow());
			dsIn.Tables[0].Rows[0]["BatchID"] = sBatchID;
			DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);

			if (dsOut.Tables[0].Rows.Count == 0)
			{
				ShowBatchCodeIsNotExistMessageBox(tbBatchCode.Text.ToString());
				ClearAll();
				//				bSaveCustProg.Enabled = false;
				//				bSaveCustProgAs.Enabled = false;
				//				bNewCustProg.Enabled = false;
				tbBatchCode.Focus();
				return;
			}
			IsLoadFromItemizn = true;

			string sGroupCode = "";
			sGroupCode = dsOut.Tables[0].Rows[0]["GroupCode"].ToString();
			string sBatchCode = "";
			sBatchCode = dsOut.Tables[0].Rows[0]["BatchCode"].ToString();

			sGroupCode = gemoDream.Service.FillToFiveChars(sGroupCode);
			sBatchCode = gemoDream.Service.FillToThreeChars(sBatchCode);
			m_sBatchCode = sGroupCode + sBatchCode;

			m_sGroupCode = sGroupCode;
			m_sBatch3Code = sBatchCode;

		}

		private void CustomerProgramForm_VisibleChanged(object sender, EventArgs e)
		{
			if (IsLoadFromItemizn)
			{
				tbBatchCode.Text = m_sBatchCode;

				//KeyPressEventArgs kea = new KeyPressEventArgs((char)13);
				//tbBatchCode_KeyPress(this, kea);

				LoadCPInstance(m_sGroupCode, m_sBatch3Code);
				//ipItems.LoadItemitemTypeView(false, skuItemTypeID.ToString());
				if (CPOfficeID_CPID != null && CPOfficeID_CPID.Length != 0)
				{
					char separator = '_';
					string[] sCPOfficeID_CPID = CPOfficeID_CPID.Split(separator);
					string sCPOfficeID = sCPOfficeID_CPID[0];
					string sCPID = sCPOfficeID_CPID[1];

					this.iDocumentsCount = this.GetDocumentsCount(sCPOfficeID, sCPID);
				}

				//IsLoadFromItemizn = false;
			}
		}
		//mvs

		//mvs
		public DialogResult ShowBatchCodeIsNotExistMessageBox(string sBatchCode)
		{
			if (ClearBatchCodeOnSuccessOrFailure == "true")
				IsClearBatchCode = true;

			return MessageBox.Show(this, "The entered batch code " + sBatchCode + " does not exist.",
				"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}
		//mvs

		private DataSet GetCPOGPByCustomerProgram()
		{
			string sss = CPOfficeID_CPID;
			//cbCustomerProgram.SelectedValue.ToString();

			char[] separator = { '_' };
			string[] sIDs = sss.Split(separator);
			//CPOfficeID_CPID.Split(separator);

			DataSet dsIn = new DataSet();
			DataTable dtIn = dsIn.Tables.Add("CPOGPByCustomerProgram");
			dtIn.Columns.Add("CPID", System.Type.GetType("System.String"));
			dtIn.Columns.Add("CPOfficeID", System.Type.GetType("System.String"));

			DataRow row = dtIn.NewRow();
			row["CPID"] = sIDs[1];
			row["CPOfficeID"] = sIDs[0];

			dtIn.Rows.Add(row);

			DataSet dsOut = Service.ProxyGenericGet(dsIn);
			return dsOut;
		}


		private void comboBoxD2_SelectionChangeCommitted(object sender, EventArgs e)
		{
			OnComboBoxSelectionChange(ref comboBoxD2, ref chbShowDefDoc2);
			/*
            string sID = this.comboBoxD2.SelectedValue.ToString();
            string sItemTypeID = this.ipItems.itemId;
            string sPath2Picture = this.tbPicPath.Text.ToString();
            string sDocumentID;
            string sName = this.comboBoxD2.Text.ToString();
            int iDocumentsCount;
            if (CPOfficeID_CPID.Length == 0)
            {
                iDocumentsCount = this.newOperationsList.Count + 1;
            }
            else
            {
                string[] sIDs = CPOfficeID_CPID.Split('_');
                string sCPOfficeID = sIDs[0];
                string sCPID = sIDs[1];
                iDocumentsCount = this.GetDocumentsCount(sCPOfficeID, sCPID);
                iDocumentsCount++;
            }

            string sOperationTypeName = String.Format("{0} {1}", sName, iDocumentsCount);
			
            if (sID.Equals("-3_3") || //MDX Document
                sID.Equals("-2_2") || //FDX Document
                sID.Equals("-1_1"))   //IDX Document
            {
                sDocumentID = AddOperation(comboBoxD2, sItemTypeID, sPath2Picture, sOperationTypeName);
                if (sDocumentID.Length != 0)
                    this.comboBoxD2.SelectedValue = sDocumentID;
            }
            */

		}

		private void comboBoxD3_SelectionChangeCommitted(object sender, EventArgs e)
		{
			OnComboBoxSelectionChange(ref comboBoxD3, ref chbShowDefDoc3);
			/*
            string sID = this.comboBoxD3.SelectedValue.ToString();
            string sItemTypeID = this.ipItems.itemId;
            string sPath2Picture = this.tbPicPath.Text.ToString();
            string sDocumentID;
            string sName = this.comboBoxD3.Text.ToString();
            int iDocumentsCount;
            if (CPOfficeID_CPID.Length == 0)
            {
                iDocumentsCount = this.newOperationsList.Count + 1;
            }
            else
            {
                string[] sIDs = CPOfficeID_CPID.Split('_');
                string sCPOfficeID = sIDs[0];
                string sCPID = sIDs[1];
                iDocumentsCount = this.GetDocumentsCount(sCPOfficeID, sCPID);
                iDocumentsCount++;
            }

            string sOperationTypeName = String.Format("{0} {1}", sName, iDocumentsCount);
			
            if (sID.Equals("-3_3") || //MDX Document
                sID.Equals("-2_2") || //FDX Document
                sID.Equals("-1_1"))   //IDX Document
            {
                sDocumentID = AddOperation(comboBoxD3, sItemTypeID, sPath2Picture, sOperationTypeName);
                if (sDocumentID.Length != 0)
                    this.comboBoxD3.SelectedValue = sDocumentID;
            }
            */

		}

		private void comboBoxD4_SelectionChangeCommitted(object sender, EventArgs e)
		{
			OnComboBoxSelectionChange(ref comboBoxD4, ref chbShowDefDoc4);
			/*
            string sID = this.comboBoxD4.SelectedValue.ToString();
            string sItemTypeID = this.ipItems.itemId;
            string sPath2Picture = this.tbPicPath.Text.ToString();
            string sDocumentID;
            string sName = this.comboBoxD4.Text.ToString();
            int iDocumentsCount;
            if (CPOfficeID_CPID.Length == 0)
            {
                iDocumentsCount = this.newOperationsList.Count + 1;
            }
            else
            {
                string[] sIDs = CPOfficeID_CPID.Split('_');
                string sCPOfficeID = sIDs[0];
                string sCPID = sIDs[1];
                iDocumentsCount = this.GetDocumentsCount(sCPOfficeID, sCPID);
                iDocumentsCount++;
            }

            string sOperationTypeName = String.Format("{0} {1}", sName, iDocumentsCount);
			
            if (sID.Equals("-3_3") || //MDX Document
                sID.Equals("-2_2") || //FDX Document
                sID.Equals("-1_1"))   //IDX Document
            {
                sDocumentID = AddOperation(comboBoxD4, sItemTypeID, sPath2Picture, sOperationTypeName);
                if (sDocumentID.Length != 0)
                    this.comboBoxD4.SelectedValue = sDocumentID;
            }
            */
		}

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
				DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);//Procedure dbo.spGetCustomerProgramDocumentsCount
				string sDocumentsCount = dsOut.Tables[0].Rows[0]["DocumentsCount"].ToString();

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

		/// <summary>
		/// Function handles key pressed on SRP-input, compares resulting string with pattern and depending on compare result either allows char or doesn't.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tbSRP_KeyPress(object sender, KeyPressEventArgs e)
		{
			String decSeparator = System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;

			if (e.KeyChar != 8)
			{
				string str = this.tbSRP.Text.ToString();
				str = str.Insert(tbSRP.SelectionStart, e.KeyChar.ToString());

				string pattern = "[0-9]{0,5}\\" + decSeparator + "?[0-9]{0,4}";
				Regex rex = new Regex(pattern);

				Match m = rex.Match(str);
				if (m.Captures.Count != 1 || m.Length != str.Length)
					e.Handled = true;
				else
					if (str.Length == 6 && str.IndexOf(decSeparator) == -1)
				{
					e.Handled = true;
					tbSRP.Text = str.Substring(0, 5) + decSeparator + str.Substring(5, str.Length - 5);
					tbSRP.SelectionStart = tbSRP.Text.Length;
					tbSRP.SelectionLength = 0;
				}
			}
		}

		//private void ctcVendor_Load(object sender, EventArgs e)
		//{

		//}

		//private void label5_Click(object sender, EventArgs e)
		//{

		//}

		private void partProps1_Load(object sender, EventArgs e)
		{
			//			System.Collections.IEnumerator en = partProps1.Controls.GetEnumerator();		
			//			PartTree pt = (PartTree)en.Current;
			//			//pt.Width = partProps1.Width;
			//			//pt.Height = partProps1.Height;
		}

		private void partProps1_Paint(object sender, PaintEventArgs e)
		{
			//			System.Collections.IEnumerator en = partProps1.Controls.GetEnumerator();		
			//			String str = en.Current.GetType().ToString();
			//			PartTree pt = (PartTree)en.Current;
			//			pt.Width = 10;//partProps1.Width;
			//			pt.Height = 10;//partProps1.Height;
		}

		/**
         * select measures list for current partType
         * by Vetal_242
         * 03.09.2006
         * */
		private void partTree1_Changed(object sender, EventArgs e)
		{
			try
			{
				string sPartTypeID = this.partTree1.SelectedNode.Tag.ToString();

				DataRow[] rows = this.dsParts.Tables["Parts"].Select("PartTypeID = '" + sPartTypeID + "'");
				string sPartID = rows[0]["ID"].ToString();

				string sFilter = "PartTypeID IN (" + sPartTypeID + ", -1)";
				this.dvMeasures.RowFilter = sFilter;
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Can't load measures. Reason: " + ex.ToString(),
					"Internal error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		/**
         * add [Part_Name.Measure_Name] in Comments or Descriptions textBox
         * by Vetal_242
         * 03.09.2006
         * */
		private void listBox1_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				TextBox CurTextBox;
				int position = 0;
				//select last active textBox
				if (this.isTbComments)
				{
					//Comments
					CurTextBox = this.tbComments;
					//caret position before select measure
					position = CurTextBox.SelectionStart;
				}
				else
				{
					//or Descriptions
					CurTextBox = this.tbDescriptions;
					//caret position before select measure
					position = CurTextBox.SelectionStart;
				}

				string sOld = CurTextBox.Text;

				DataRowView row = (DataRowView)this.listBox1.SelectedItem;
				string sMeasure = (string)row["MeasureTitle"];

				string sPartType = this.partTree1.tvPartTree.SelectedNode.Text;
				string sNewPart = null;

				if (sOld.Length == 0)
				{
					sNewPart = String.Format("[{0}.{1}]", sPartType, sMeasure);
					sOld += sNewPart;
				}
				else
				{
					string sSeparator = " ";
					sNewPart = String.Format("{0}[{1}.{2}]", sSeparator, sPartType, sMeasure);
					sOld = sOld.Insert(position, sNewPart);
				}
				CurTextBox.Text = sOld;
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Can't add. Reason: " + ex.ToString(),
					"Internal error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void tbDescriptions_Enter(object sender, EventArgs e)
		{
			sbStatus.Text = "Program descriptions";
			this.isTbComments = false;
		}
		/*
                private void button1_Click(object sender, System.EventArgs e)
                {
                    string sCPID = "";
                    if(CPOfficeID_CPID != "")
                    {
                        sCPID = CPOfficeID_CPID.Split('_')[1];
                    }
                    dsPricing = Prices.Pricing(this, sCPID, ipItems.itemId);
                }
        */
		private void tcOpsReqs_SelectedIndexChanged(object sender, EventArgs e)
		{
			string sCPID = "";
			Boolean isClosedOK = false;
			DataSet dsTemp = new DataSet();

			if (CPOfficeID_CPID != "" && ((TabControl)sender).SelectedIndex == 3 && AccessLevel > 2)
			{
				sCPID = CPOfficeID_CPID.Split('_')[1];

				if (dsPricing == null)
				{
					dsTemp = Prices.Pricing(this, sCPID, ipItems.itemId, ref isClosedOK);
					if (isClosedOK)
						dsPricing = dsTemp;
				}
				else
				{
					dsTemp = Prices.Pricing(this, ref dsPricing, ipItems.itemId, ref isClosedOK);
					if (isClosedOK)
						dsPricing = dsTemp;
				}

#if DEBUG
				try
				{
					// For debugging only			
					string filename = "C:/DELL/myXml_CP_Prices_ToSave.xml";
					if (File.Exists(filename)) File.Delete(filename);
					// Create the FileStream to write with.
					FileStream myFileStream = new FileStream(filename, System.IO.FileMode.Create);
					// Create an XmlTextWriter with the fileStream.
					System.Xml.XmlTextWriter myXmlWriter = new System.Xml.XmlTextWriter(myFileStream, System.Text.Encoding.Unicode);
					// Write to the file with the WriteXml method.
					dsPricing.WriteXml(myXmlWriter);
					myXmlWriter.Close();
					// End of debugging part
				}
				catch
				{ }
#endif
				((TabControl)sender).SelectedIndex = 2;
			}
		}

		private void AccessRestriction(int accLevel, ref ComboBox[] acbDocOps, ref CheckBox[] achbDocOpCheck)
		{
			if (accLevel < 3)
			{
				for (int j = 0; j < acbDocOps.Length; j++)
				{
					if (achbDocOpCheck[j].Checked)
					{
						acbDocOps[j].Visible = true;
						acbDocOps[j].MaxDropDownItems = 1;
						achbDocOpCheck[j].Visible = true;
					}
					else
					{
						acbDocOps[j].Visible = false;
						achbDocOpCheck[j].Visible = false;
					}
				}
			}
		}

		private void chbShowDefDoc1_CheckedChanged(object sender, EventArgs e)
		{
			if (chbShowDefDoc1.Checked)
				OnComboBoxSelectionChange(ref comboBoxD1, ref chbShowDefDoc1);
		}

		private void chbShowDefDoc2_CheckedChanged(object sender, EventArgs e)
		{
			if (chbShowDefDoc2.Checked)
				OnComboBoxSelectionChange(ref comboBoxD2, ref chbShowDefDoc2);
		}

		private void chbShowDefDoc3_CheckedChanged(object sender, EventArgs e)
		{
			if (chbShowDefDoc3.Checked)
				OnComboBoxSelectionChange(ref comboBoxD3, ref chbShowDefDoc3);
		}

		private void chbShowDefDoc4_CheckedChanged(object sender, EventArgs e)
		{
			if (chbShowDefDoc4.Checked)
				OnComboBoxSelectionChange(ref comboBoxD4, ref chbShowDefDoc4);
		}

		private void tbBatchCode_TextChanged(object sender, EventArgs e)
		{
			if (tbBatchCode.Text.Trim().Length < 8)
			{
				bSaveCustProg.Enabled = false;
				bSaveCustProgAs.Enabled = false;
				bNewCustProg.Enabled = false;
			}
		}

		private void bReloadSKU_List_Click(object sender, EventArgs e)
		{
			if (dsCustPrograms.Tables[0].Rows.Count > 0)
			{
				var sCPName1 = cbCustomerProgram.SelectedItem;
				cbCustomerProgram.Items.Clear();
				cbCustomerProgram.Text = "Customer program lookup";
				cbCustomerProgram.SelectedIndex = -1;

				foreach (DataRow r in dsCustPrograms.Tables[0].Rows)
				{
					cbCustomerProgram.Items.Add(r["CustomerProgramName"]);
				}
				cbCustomerProgram.SelectedItem = sCPName1;
				ipItems.ListItems.BackColor = Color.White;
			}
		}

		private void bSaveBulk_Click(object sender, EventArgs e)
		{
			TreeNode selectedPartTreeNode = ((Cntrls.DocumentProps)tcDocs.TabPages[1].Controls[0]).ptPartTree.SelectedNode;
			if (selectedPartTreeNode != null)
			{
				var partName = selectedPartTreeNode.Text;
				DialogResult result = MessageBox.Show("Ok to bulk save for parts similar to " + partName + "?", "Saving bulk rules", MessageBoxButtons.YesNoCancel);
				if (result == DialogResult.Yes)
				{
					SaveBulk = true;
					bSaveCustProg_Click(this, EventArgs.Empty);
					SaveBulk = false;
				}
			}
			//throw new NotImplementedException();
		}
	}
}
