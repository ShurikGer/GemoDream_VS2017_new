using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Cntrls;
using System.Text;
using System.Xml;
using System.IO;
using System.Collections.Generic;
using System.Linq;


//using System.Drawing.Imaging;

namespace gemoDream
{
	/// <summary>
	/// Account representative form
	/// </summary>
	public class AccountRep : Form
	{
		public static string addressToBill = "";
		private string myActiveOrder = "";
		private bool isLoaded = true;
		private bool bulkMode = false;
		private DataSet dsStructure = null;
		private int indexOld = -1;
		private Hashtable htBlockedPart = null;
		private bool reset = false;
		private ArrayList myParts = null;

		#region DesignerDeclarations
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.ColumnHeader itemN;
		private System.Windows.Forms.ColumnHeader firstName;
		private System.Windows.Forms.ColumnHeader lastName;
		private System.Windows.Forms.ColumnHeader position;
		private System.Windows.Forms.ColumnHeader phonePersonN;
		private System.Windows.Forms.ColumnHeader faxPersonN;
		private System.Windows.Forms.ColumnHeader cellPersonN;
		private System.Windows.Forms.ColumnHeader emailPerson;
		private System.Windows.Forms.GroupBox groupBox10;
		private System.Windows.Forms.GroupBox groupBox12;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.GroupBox groupBox13;
		private System.Windows.Forms.GroupBox groupBox14;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.GroupBox groupBox15;
		private System.Windows.Forms.GroupBox groupBox16;
		private System.Windows.Forms.GroupBox gbOrdersHistory;
		private Cntrls.ComboTextComponent cbcCustomer;
		private System.Windows.Forms.ComboBox cbPeriod;
		private System.Windows.Forms.Label lbEmail;
		private System.Windows.Forms.Label lbFax;
		private System.Windows.Forms.Label lbPhone;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.CheckBox chbMail;
		private System.Windows.Forms.CheckBox chbEmail;
		private System.Windows.Forms.CheckBox chbPhone;
		private System.Windows.Forms.CheckBox chbFax;
		private System.Windows.Forms.Label lbInd;
		private System.Windows.Forms.Label lbAdd;
		private System.Windows.Forms.Label lbCompanyName;
		private System.Windows.Forms.Label lbBus;
		private System.Windows.Forms.Label lbCompany;
		private System.Windows.Forms.Label lbAddress;
		private System.Windows.Forms.Label lbBusiness;
		private System.Windows.Forms.ListView liPersons;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker dtpFrom;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dtpTo;
		private System.Windows.Forms.Label lbCustMembership;
		private System.Windows.Forms.Label lbCustEmail;
		private System.Windows.Forms.Label lbCustAddr;
		private System.Windows.Forms.Label lbCustComp;
		private System.Windows.Forms.Label lbCustBusiness;
		private System.Windows.Forms.ComboBox cbCustPersons;
		private System.Windows.Forms.Label lbSearchFrom;
		private System.Windows.Forms.Label lbSearchTo;
		private System.Windows.Forms.CheckBox chbMail1;
		private System.Windows.Forms.CheckBox chbEmail1;
		private System.Windows.Forms.CheckBox chbPhone1;
		private System.Windows.Forms.CheckBox chbFax1;
		private Cntrls.Permissions prmPermissions;
		private System.Windows.Forms.Label lbPersonID;
		private System.Windows.Forms.Label lbPhoneExt;		
		private System.Windows.Forms.TabControl tcMain;
		private System.Windows.Forms.TabPage tpCustomer;
		private System.Windows.Forms.TabPage tpUpdate;
		private System.Windows.Forms.Label lbCustFax;
		private System.Windows.Forms.Label lbCustPhone;
		private System.Windows.Forms.StatusBar sbStatus;
		private System.Windows.Forms.ListView lvDocs;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.TextBox tbOrderName;
		private System.Windows.Forms.Panel pnlDetails;
		private System.Windows.Forms.DateTimePicker dtpUpdTo;
		private System.Windows.Forms.DateTimePicker dtpUpdFrom;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox tbItemName;
		private System.Windows.Forms.Button bDetailsSelect;
		private System.Windows.Forms.Button bUpdOrdOrdersClear;
		private System.Windows.Forms.Button bDetailsAdd;
		private System.Windows.Forms.Button bDetailsClear;
		private System.Windows.Forms.Button bDetailsUpdate;
		private Cntrls.OrdersTree otClosed;
		private Cntrls.OrdersTree2 otAllOrders;
		private bool bLoading = false;		
		private DataSet dsOrdersToDelivery;
		private DataSet dsCustomerTypeEx;
		private DataSet dsAddServices;
		private DataTable dtPerson;
		private DataTable dtCustomer;
		private DataTable dtCustBiz;
		private DataTable dtCustInd;
		private DataTable dtCarrier;		
		private DataTable dtStates;
		private DataTable dtPositions;
		private DataTable dtDocDetails;
		private DataTable dtReportList;
		private Timer tmr;
		private DataTable dtItem = new DataTable("tblItems");
		private DataTable dtChecked;
		private DataSet dsAvailableOps;
		private bool nonNumberEntered;

		private System.Windows.Forms.ListBox lbxIndustry;
		private System.Windows.Forms.ListBox lbxIndustry2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox tbSearchUnit;
		private System.Windows.Forms.Button bSearch;

		private int AccessLevel;
		#endregion DesignerDeclarations
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.ComboBox cbPersons;
		private System.Windows.Forms.Button bFax;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.ListBox lbxItems;
		private System.Windows.Forms.Button bBill;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button bPrint;
		private Cntrls.OrdersTree otOpenOrders;
		private Cntrls.OrdersTree otOrderReports;
		private System.Windows.Forms.Button bEndSession;
		private System.Windows.Forms.Button bOrderUpdate;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Label lbNOpenItems;
		private System.Windows.Forms.Label lbNOpenBatches;
		private System.Windows.Forms.Label lbNOpenOrders;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label12;
		internal System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button bPrintLabel;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.GroupBox groupBox7;
		internal System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label lbMemo;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.Panel pnlShapeContainer;
		private System.Windows.Forms.PictureBox pbShape;
		private System.Windows.Forms.GroupBox groupBox11;
		internal System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.GroupBox groupBox6;
		private Cntrls.PartTree ptrOps;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.Label lbOtherDetails;
		private System.Windows.Forms.ListView lvProps;
		private System.Windows.Forms.ColumnHeader PartName;
		private System.Windows.Forms.ColumnHeader chName;
		private System.Windows.Forms.ColumnHeader chValue;
		private System.Windows.Forms.ColumnHeader chPrevValue;
		private System.Windows.Forms.TabPage tpOrders;
		private System.Windows.Forms.Button btnFoceEndSession;
		private System.Windows.Forms.TextBox tbMemoNumber;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ListView lvMigratedItemData;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TabPage tpReports;
		private System.Windows.Forms.ListView lvReportPictures;
		private System.Windows.Forms.PictureBox pbReportView;
		private System.Windows.Forms.Button bOrderReports;
		private System.Windows.Forms.GroupBox groupBox9;
		private System.Windows.Forms.ImageList imageReportsList;
		private System.Windows.Forms.Button bClose_otReports;
		private System.Windows.Forms.ListView lvReportList;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.Button bprintedReport;
		private System.Windows.Forms.Button bmissedReports;
		private System.Windows.Forms.Button bZoomMinus;
		private System.Windows.Forms.Button bZoomPlus;
		private System.Windows.Forms.Panel pnlReportContainer;
		private System.Windows.Forms.Button bRestorePicture;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private System.Windows.Forms.Button bBillWithSKU;

//		private bool bRegularBill = false;
//        private bool bBillWithLot = false;
		private System.Windows.Forms.TabPage tpDelivery;
		private Cntrls.OrdersTree otDelivery;
		private System.Windows.Forms.Button bPrintDeliveryReport;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Button bAddToDeliveryList;
		private System.Windows.Forms.DataGrid dgOrdersToDelivery;
		private System.Windows.Forms.TextBox tbOrderToDelivery;
		private System.Windows.Forms.Button bAddOrderToList;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.ComboBox cbMessenger;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Button bOrdersForDelivery;
		private System.Windows.Forms.ComboBox cbCarrier;
		private System.Windows.Forms.Label label20;
        private System.Windows.Forms.GroupBox gbBilling;
        private System.Windows.Forms.CheckBox cbRegularBilling;
        private System.Windows.Forms.CheckBox cbBillingWithSKU;
        private System.Windows.Forms.CheckBox cbBillingWithLot;
		private Label label21;
		private ListView lvAddServices;
		private ColumnHeader columnHeader12;
		private ColumnHeader AddServiceID;
		private ColumnHeader AddServiceName;
		private ColumnHeader BatchID;
		private ColumnHeader BatchCode;
		private ListView lvServices;
		private Button cmd_ReloadList;
		private Button cmd_ClearAddServiceList;
		private ColumnHeader Price;
		private ColumnHeader PriceID;
		private ColumnHeader AuthorID;
		private RadioButton radioButton1;
		private RadioButton radioButton3;
		private bool isSelectItem = false;

		public static int billingTo;
		public static bool closeExit = false;
		private TabPage tpBlockParts;
		private Button button6;
		private Button button5;
		private Button cmd_ClearBlockPart;
		private Label lblStructure;
		private ListView lvBatchesToBlock;
		private ColumnHeader columnHeader13;
		private ColumnHeader myBatchID;
		private ColumnHeader FullBatchCode;
		private ColumnHeader CPID;
		private ColumnHeader SKU_Name;
		private ColumnHeader itemTypeID;
		private PartTreeEx partView;
		private ComboBox cbCustomerProgram;
		private ColumnHeader itemStructure;
		private ColumnHeader blockedPartName;
		private Label label26;
		private Label label22;
		private Button cmd_Reset;
		private ColumnHeader FullBlockedPartName;
		private ColumnHeader copyOfBlockedParts;
		private ColumnHeader myPartID;
		
		
		public AccountRep()
		{
			InitializeComponent();
			InitCustomers();
			InitGlobal();
			tmr = new Timer();
			tmr.Interval = 1000;
			tmr.Tick +=new EventHandler(tmr_Tick);

			dtItem.Columns.Add("ID");
			dtItem.Columns.Add("ParentID");
			dtItem.Columns.Add("Name");
			dtItem.Columns.Add("Code");
			
			pictureBox2.Paint += new PaintEventHandler(pictureBox2_Paint);
			pbShape.Paint += new PaintEventHandler(pictureBox2_Paint);
			lvAddServices.Items.Clear();
		 }

		public AccountRep(int AccessLevel)
		{			
			this.AccessLevel = AccessLevel;
			InitializeComponent();
			InitCustomers();
			InitGlobal();
			tmr = new Timer();
			tmr.Interval = 1000;
			tmr.Tick +=new EventHandler(tmr_Tick);
			
			dtItem.Columns.Add("ID");
			dtItem.Columns.Add("ParentID");
			dtItem.Columns.Add("Name");
			dtItem.Columns.Add("Code");
			
			pictureBox2.Paint += new PaintEventHandler(pictureBox2_Paint);
			pbShape.Paint += new PaintEventHandler(pictureBox2_Paint);
			tcMain.SelectedTab = tcMain.TabPages[1];
			nonNumberEntered = false;

			dsOrdersToDelivery = new DataSet();
			DataTable dtOrders = new DataTable();
			dtOrders.TableName = "Orders"; //(new DataColumn("Update", typeof(bool)));
			dtOrders.Columns.Add(new DataColumn ("OrderCode", typeof(string)));
			dtOrders.Columns.Add(new DataColumn ("ItemsQuantity", typeof(string)));
			dtOrders.Columns.Add(new DataColumn ("CustomerName", typeof(string)));
			dtOrders.Columns.Add(new DataColumn ("CustomerCode", typeof(string)));
			dtOrders.Columns.Add(new DataColumn ("Memo", typeof(string)));
			dsOrdersToDelivery.Tables.Add(dtOrders);
			dsOrdersToDelivery.Tables[0].RowDeleted += new System.Data.DataRowChangeEventHandler(OrderTable_Deleted);
			DataView myView = new DataView(dsOrdersToDelivery.Tables[0]);
			myView.AllowNew = true;
			myView.AllowEdit = false;
			myView.AllowDelete = true;
			myView.Sort = "OrderCode";
			InitOrderDataGrid(dsOrdersToDelivery.Tables[0].TableName);
			dgOrdersToDelivery.SetDataBinding(myView, "");
			bPrintDeliveryReport.Enabled = false;
			bLoading = true;
			tbMemoNumber.Text = "";
            cbRegularBilling.Checked = true;
			lvAddServices.Items.Clear();
			//rbDefault.Checked = true;
			//rbQBprimary.Checked = false;
			//rbQBcorpt.Checked = false;
			//rbTally.Checked = false;
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountRep));
			this.tcMain = new System.Windows.Forms.TabControl();
			this.tpCustomer = new System.Windows.Forms.TabPage();
			this.gbOrdersHistory = new System.Windows.Forms.GroupBox();
			this.otClosed = new Cntrls.OrdersTree();
			this.button1 = new System.Windows.Forms.Button();
			this.dtpTo = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.dtpFrom = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.cbPeriod = new System.Windows.Forms.ComboBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.lbxIndustry = new System.Windows.Forms.ListBox();
			this.lbBusiness = new System.Windows.Forms.Label();
			this.lbAddress = new System.Windows.Forms.Label();
			this.lbCompany = new System.Windows.Forms.Label();
			this.lbInd = new System.Windows.Forms.Label();
			this.lbEmail = new System.Windows.Forms.Label();
			this.lbFax = new System.Windows.Forms.Label();
			this.lbPhone = new System.Windows.Forms.Label();
			this.lbAdd = new System.Windows.Forms.Label();
			this.lbCompanyName = new System.Windows.Forms.Label();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.liPersons = new System.Windows.Forms.ListView();
			this.emailPerson = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.lbBus = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.chbMail = new System.Windows.Forms.CheckBox();
			this.chbEmail = new System.Windows.Forms.CheckBox();
			this.chbPhone = new System.Windows.Forms.CheckBox();
			this.chbFax = new System.Windows.Forms.CheckBox();
			this.tpOrders = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lvAddServices = new System.Windows.Forms.ListView();
			this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.AddServiceID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.AddServiceName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.BatchID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.BatchCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.PriceID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.AuthorID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.label21 = new System.Windows.Forms.Label();
			this.gbBilling = new System.Windows.Forms.GroupBox();
			this.cbBillingWithLot = new System.Windows.Forms.CheckBox();
			this.cbBillingWithSKU = new System.Windows.Forms.CheckBox();
			this.cbRegularBilling = new System.Windows.Forms.CheckBox();
			this.bBill = new System.Windows.Forms.Button();
			this.label11 = new System.Windows.Forms.Label();
			this.lvMigratedItemData = new System.Windows.Forms.ListView();
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.btnFoceEndSession = new System.Windows.Forms.Button();
			this.cmd_ReloadList = new System.Windows.Forms.Button();
			this.label16 = new System.Windows.Forms.Label();
			this.cbPersons = new System.Windows.Forms.ComboBox();
			this.bFax = new System.Windows.Forms.Button();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.button13 = new System.Windows.Forms.Button();
			this.lbxItems = new System.Windows.Forms.ListBox();
			this.bPrint = new System.Windows.Forms.Button();
			this.otOpenOrders = new Cntrls.OrdersTree();
			this.bEndSession = new System.Windows.Forms.Button();
			this.bOrderUpdate = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.bPrintLabel = new System.Windows.Forms.Button();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.lbNOpenItems = new System.Windows.Forms.Label();
			this.cmd_ClearAddServiceList = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.lbMemo = new System.Windows.Forms.Label();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.pnlShapeContainer = new System.Windows.Forms.Panel();
			this.pbShape = new System.Windows.Forms.PictureBox();
			this.groupBox11 = new System.Windows.Forms.GroupBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.lbOtherDetails = new System.Windows.Forms.Label();
			this.lvProps = new System.Windows.Forms.ListView();
			this.PartName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chPrevValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.lbNOpenBatches = new System.Windows.Forms.Label();
			this.lbNOpenOrders = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.ptrOps = new Cntrls.PartTree();
			this.label37 = new System.Windows.Forms.Label();
			this.bBillWithSKU = new System.Windows.Forms.Button();
			this.bAddToDeliveryList = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.bOrderReports = new System.Windows.Forms.Button();
			this.tpUpdate = new System.Windows.Forms.TabPage();
			this.groupBox16 = new System.Windows.Forms.GroupBox();
			this.lvDocs = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.groupBox15 = new System.Windows.Forms.GroupBox();
			this.pnlDetails = new System.Windows.Forms.Panel();
			this.tbItemName = new System.Windows.Forms.TextBox();
			this.label30 = new System.Windows.Forms.Label();
			this.label29 = new System.Windows.Forms.Label();
			this.tbOrderName = new System.Windows.Forms.TextBox();
			this.groupBox13 = new System.Windows.Forms.GroupBox();
			this.otAllOrders = new Cntrls.OrdersTree2();
			this.panel1 = new System.Windows.Forms.Panel();
			this.bDetailsAdd = new System.Windows.Forms.Button();
			this.groupBox14 = new System.Windows.Forms.GroupBox();
			this.dtpUpdTo = new System.Windows.Forms.DateTimePicker();
			this.lbSearchTo = new System.Windows.Forms.Label();
			this.dtpUpdFrom = new System.Windows.Forms.DateTimePicker();
			this.lbSearchFrom = new System.Windows.Forms.Label();
			this.bDetailsSelect = new System.Windows.Forms.Button();
			this.bUpdOrdOrdersClear = new System.Windows.Forms.Button();
			this.bDetailsUpdate = new System.Windows.Forms.Button();
			this.bDetailsClear = new System.Windows.Forms.Button();
			this.groupBox10 = new System.Windows.Forms.GroupBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.lbxIndustry2 = new System.Windows.Forms.ListBox();
			this.lbCustMembership = new System.Windows.Forms.Label();
			this.lbCustEmail = new System.Windows.Forms.Label();
			this.lbCustFax = new System.Windows.Forms.Label();
			this.lbCustPhone = new System.Windows.Forms.Label();
			this.lbCustAddr = new System.Windows.Forms.Label();
			this.lbCustComp = new System.Windows.Forms.Label();
			this.groupBox12 = new System.Windows.Forms.GroupBox();
			this.lbPhoneExt = new System.Windows.Forms.Label();
			this.cbCustPersons = new System.Windows.Forms.ComboBox();
			this.prmPermissions = new Cntrls.Permissions();
			this.lbCustBusiness = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.label25 = new System.Windows.Forms.Label();
			this.chbMail1 = new System.Windows.Forms.CheckBox();
			this.chbEmail1 = new System.Windows.Forms.CheckBox();
			this.chbPhone1 = new System.Windows.Forms.CheckBox();
			this.chbFax1 = new System.Windows.Forms.CheckBox();
			this.lbPersonID = new System.Windows.Forms.Label();
			this.tpReports = new System.Windows.Forms.TabPage();
			this.groupBox9 = new System.Windows.Forms.GroupBox();
			this.label13 = new System.Windows.Forms.Label();
			this.bRestorePicture = new System.Windows.Forms.Button();
			this.pnlReportContainer = new System.Windows.Forms.Panel();
			this.pbReportView = new System.Windows.Forms.PictureBox();
			this.bZoomPlus = new System.Windows.Forms.Button();
			this.bZoomMinus = new System.Windows.Forms.Button();
			this.bmissedReports = new System.Windows.Forms.Button();
			this.bprintedReport = new System.Windows.Forms.Button();
			this.lvReportList = new System.Windows.Forms.ListView();
			this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.bClose_otReports = new System.Windows.Forms.Button();
			this.lvReportPictures = new System.Windows.Forms.ListView();
			this.imageReportsList = new System.Windows.Forms.ImageList(this.components);
			this.otOrderReports = new Cntrls.OrdersTree();
			this.tpDelivery = new System.Windows.Forms.TabPage();
			this.label20 = new System.Windows.Forms.Label();
			this.cbCarrier = new System.Windows.Forms.ComboBox();
			this.bOrdersForDelivery = new System.Windows.Forms.Button();
			this.label19 = new System.Windows.Forms.Label();
			this.cbMessenger = new System.Windows.Forms.ComboBox();
			this.label18 = new System.Windows.Forms.Label();
			this.bAddOrderToList = new System.Windows.Forms.Button();
			this.tbOrderToDelivery = new System.Windows.Forms.TextBox();
			this.dgOrdersToDelivery = new System.Windows.Forms.DataGrid();
			this.label17 = new System.Windows.Forms.Label();
			this.bPrintDeliveryReport = new System.Windows.Forms.Button();
			this.otDelivery = new Cntrls.OrdersTree();
			this.tpBlockParts = new System.Windows.Forms.TabPage();
			this.cmd_Reset = new System.Windows.Forms.Button();
			this.label22 = new System.Windows.Forms.Label();
			this.cbCustomerProgram = new System.Windows.Forms.ComboBox();
			this.partView = new Cntrls.PartTreeEx();
			this.lvBatchesToBlock = new System.Windows.Forms.ListView();
			this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.FullBatchCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.myBatchID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.CPID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SKU_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.itemTypeID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.itemStructure = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.myPartID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.blockedPartName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.FullBlockedPartName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.copyOfBlockedParts = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.button6 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.cmd_ClearBlockPart = new System.Windows.Forms.Button();
			this.lblStructure = new System.Windows.Forms.Label();
			this.itemN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.firstName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.lastName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.position = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.phonePersonN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.faxPersonN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.cellPersonN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.sbStatus = new System.Windows.Forms.StatusBar();
			this.tbSearchUnit = new System.Windows.Forms.TextBox();
			this.bSearch = new System.Windows.Forms.Button();
			this.tbMemoNumber = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.lvServices = new System.Windows.Forms.ListView();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.label26 = new System.Windows.Forms.Label();
			this.cbcCustomer = new Cntrls.ComboTextComponent();
			this.tcMain.SuspendLayout();
			this.tpCustomer.SuspendLayout();
			this.gbOrdersHistory.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.tpOrders.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.gbBilling.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.groupBox7.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox8.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbShape)).BeginInit();
			this.groupBox11.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.groupBox5.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.tpUpdate.SuspendLayout();
			this.groupBox16.SuspendLayout();
			this.groupBox15.SuspendLayout();
			this.groupBox13.SuspendLayout();
			this.panel1.SuspendLayout();
			this.groupBox14.SuspendLayout();
			this.groupBox10.SuspendLayout();
			this.groupBox12.SuspendLayout();
			this.tpReports.SuspendLayout();
			this.groupBox9.SuspendLayout();
			this.pnlReportContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbReportView)).BeginInit();
			this.tpDelivery.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgOrdersToDelivery)).BeginInit();
			this.tpBlockParts.SuspendLayout();
			this.SuspendLayout();
			// 
			// tcMain
			// 
			this.tcMain.Alignment = System.Windows.Forms.TabAlignment.Left;
			this.tcMain.Controls.Add(this.tpCustomer);
			this.tcMain.Controls.Add(this.tpOrders);
			this.tcMain.Controls.Add(this.tpUpdate);
			this.tcMain.Controls.Add(this.tpReports);
			this.tcMain.Controls.Add(this.tpDelivery);
			this.tcMain.Controls.Add(this.tpBlockParts);
			this.tcMain.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.tcMain.ItemSize = new System.Drawing.Size(205, 15);
			this.tcMain.Location = new System.Drawing.Point(5, 28);
			this.tcMain.Multiline = true;
			this.tcMain.Name = "tcMain";
			this.tcMain.Padding = new System.Drawing.Point(6, 2);
			this.tcMain.SelectedIndex = 0;
			this.tcMain.Size = new System.Drawing.Size(1266, 677);
			this.tcMain.TabIndex = 14;
			this.tcMain.SelectedIndexChanged += new System.EventHandler(this.tcMain_SelectedIndexChanged);
			// 
			// tpCustomer
			// 
			this.tpCustomer.Controls.Add(this.gbOrdersHistory);
			this.tpCustomer.Controls.Add(this.groupBox2);
			this.tpCustomer.Location = new System.Drawing.Point(19, 4);
			this.tpCustomer.Name = "tpCustomer";
			this.tpCustomer.Size = new System.Drawing.Size(1243, 669);
			this.tpCustomer.TabIndex = 0;
			this.tpCustomer.Text = "Customer";
			this.tpCustomer.Enter += new System.EventHandler(this.tpCustomer_Enter);
			// 
			// gbOrdersHistory
			// 
			this.gbOrdersHistory.Controls.Add(this.otClosed);
			this.gbOrdersHistory.Controls.Add(this.button1);
			this.gbOrdersHistory.Controls.Add(this.dtpTo);
			this.gbOrdersHistory.Controls.Add(this.label2);
			this.gbOrdersHistory.Controls.Add(this.dtpFrom);
			this.gbOrdersHistory.Controls.Add(this.label1);
			this.gbOrdersHistory.Controls.Add(this.cbPeriod);
			this.gbOrdersHistory.ForeColor = System.Drawing.Color.DimGray;
			this.gbOrdersHistory.Location = new System.Drawing.Point(5, 5);
			this.gbOrdersHistory.Name = "gbOrdersHistory";
			this.gbOrdersHistory.Size = new System.Drawing.Size(940, 430);
			this.gbOrdersHistory.TabIndex = 25;
			this.gbOrdersHistory.TabStop = false;
			this.gbOrdersHistory.Text = "Customer Orders History";
			// 
			// otClosed
			// 
			this.otClosed.CheckBoxes = true;
			this.otClosed.IsDocumentGhost = false;
			this.otClosed.IsExpand = false;
			this.otClosed.Location = new System.Drawing.Point(5, 50);
			this.otClosed.Name = "otClosed";
			this.otClosed.Selected = null;
			this.otClosed.ShowColorAndClarity = true;
			this.otClosed.Size = new System.Drawing.Size(420, 375);
			this.otClosed.TabIndex = 29;
			this.otClosed.Enter += new System.EventHandler(this.otClosed_Enter);
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.button1.Location = new System.Drawing.Point(515, 20);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(65, 20);
			this.button1.TabIndex = 28;
			this.button1.Text = "Se&lect";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			this.button1.Enter += new System.EventHandler(this.button1_Enter);
			this.button1.Leave += new System.EventHandler(this.ControlFocusLeave);
			// 
			// dtpTo
			// 
			this.dtpTo.Enabled = false;
			this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpTo.Location = new System.Drawing.Point(400, 20);
			this.dtpTo.Name = "dtpTo";
			this.dtpTo.Size = new System.Drawing.Size(95, 20);
			this.dtpTo.TabIndex = 26;
			this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
			this.dtpTo.Enter += new System.EventHandler(this.dtpTo_Enter);
			this.dtpTo.Leave += new System.EventHandler(this.ControlFocusLeave);
			// 
			// label2
			// 
			this.label2.ForeColor = System.Drawing.Color.Black;
			this.label2.Location = new System.Drawing.Point(380, 25);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(20, 15);
			this.label2.TabIndex = 25;
			this.label2.Text = "to";
			// 
			// dtpFrom
			// 
			this.dtpFrom.Enabled = false;
			this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFrom.Location = new System.Drawing.Point(270, 20);
			this.dtpFrom.Name = "dtpFrom";
			this.dtpFrom.Size = new System.Drawing.Size(95, 20);
			this.dtpFrom.TabIndex = 24;
			this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
			this.dtpFrom.Enter += new System.EventHandler(this.dtpFrom_Enter);
			this.dtpFrom.Leave += new System.EventHandler(this.ControlFocusLeave);
			// 
			// label1
			// 
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(230, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 15);
			this.label1.TabIndex = 23;
			this.label1.Text = "From";
			// 
			// cbPeriod
			// 
			this.cbPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbPeriod.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.cbPeriod.ItemHeight = 12;
			this.cbPeriod.Items.AddRange(new object[] {
            "This Month",
            "Last Month",
            "This Year",
            "Last Year",
            "From - To"});
			this.cbPeriod.Location = new System.Drawing.Point(10, 20);
			this.cbPeriod.Name = "cbPeriod";
			this.cbPeriod.Size = new System.Drawing.Size(205, 20);
			this.cbPeriod.TabIndex = 17;
			this.cbPeriod.SelectedIndexChanged += new System.EventHandler(this.cbPeriod_SelectedIndexChanged);
			this.cbPeriod.Enter += new System.EventHandler(this.cbPeriod_Enter);
			this.cbPeriod.Leave += new System.EventHandler(this.ControlFocusLeave);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.lbxIndustry);
			this.groupBox2.Controls.Add(this.lbBusiness);
			this.groupBox2.Controls.Add(this.lbAddress);
			this.groupBox2.Controls.Add(this.lbCompany);
			this.groupBox2.Controls.Add(this.lbInd);
			this.groupBox2.Controls.Add(this.lbEmail);
			this.groupBox2.Controls.Add(this.lbFax);
			this.groupBox2.Controls.Add(this.lbPhone);
			this.groupBox2.Controls.Add(this.lbAdd);
			this.groupBox2.Controls.Add(this.lbCompanyName);
			this.groupBox2.Controls.Add(this.groupBox4);
			this.groupBox2.Controls.Add(this.lbBus);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.chbMail);
			this.groupBox2.Controls.Add(this.chbEmail);
			this.groupBox2.Controls.Add(this.chbPhone);
			this.groupBox2.Controls.Add(this.chbFax);
			this.groupBox2.ForeColor = System.Drawing.Color.DimGray;
			this.groupBox2.Location = new System.Drawing.Point(5, 435);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(945, 230);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Customer Details";
			// 
			// lbxIndustry
			// 
			this.lbxIndustry.ItemHeight = 12;
			this.lbxIndustry.Location = new System.Drawing.Point(555, 180);
			this.lbxIndustry.Name = "lbxIndustry";
			this.lbxIndustry.ScrollAlwaysVisible = true;
			this.lbxIndustry.Size = new System.Drawing.Size(140, 40);
			this.lbxIndustry.TabIndex = 29;
			this.lbxIndustry.Enter += new System.EventHandler(this.lbxIndustry_Enter);
			this.lbxIndustry.Leave += new System.EventHandler(this.ControlFocusLeave);
			// 
			// lbBusiness
			// 
			this.lbBusiness.ForeColor = System.Drawing.Color.Black;
			this.lbBusiness.Location = new System.Drawing.Point(60, 180);
			this.lbBusiness.Name = "lbBusiness";
			this.lbBusiness.Size = new System.Drawing.Size(160, 15);
			this.lbBusiness.TabIndex = 28;
			// 
			// lbAddress
			// 
			this.lbAddress.ForeColor = System.Drawing.Color.Black;
			this.lbAddress.Location = new System.Drawing.Point(70, 60);
			this.lbAddress.Name = "lbAddress";
			this.lbAddress.Size = new System.Drawing.Size(150, 50);
			this.lbAddress.TabIndex = 27;
			// 
			// lbCompany
			// 
			this.lbCompany.ForeColor = System.Drawing.Color.Black;
			this.lbCompany.Location = new System.Drawing.Point(70, 30);
			this.lbCompany.Name = "lbCompany";
			this.lbCompany.Size = new System.Drawing.Size(150, 25);
			this.lbCompany.TabIndex = 26;
			// 
			// lbInd
			// 
			this.lbInd.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.lbInd.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lbInd.Location = new System.Drawing.Point(470, 185);
			this.lbInd.Name = "lbInd";
			this.lbInd.Size = new System.Drawing.Size(75, 25);
			this.lbInd.TabIndex = 25;
			this.lbInd.Text = "Industry membership";
			// 
			// lbEmail
			// 
			this.lbEmail.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.lbEmail.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lbEmail.Location = new System.Drawing.Point(60, 160);
			this.lbEmail.Name = "lbEmail";
			this.lbEmail.Size = new System.Drawing.Size(160, 15);
			this.lbEmail.TabIndex = 24;
			// 
			// lbFax
			// 
			this.lbFax.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.lbFax.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lbFax.Location = new System.Drawing.Point(60, 140);
			this.lbFax.Name = "lbFax";
			this.lbFax.Size = new System.Drawing.Size(160, 15);
			this.lbFax.TabIndex = 23;
			// 
			// lbPhone
			// 
			this.lbPhone.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.lbPhone.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lbPhone.Location = new System.Drawing.Point(60, 120);
			this.lbPhone.Name = "lbPhone";
			this.lbPhone.Size = new System.Drawing.Size(160, 15);
			this.lbPhone.TabIndex = 22;
			// 
			// lbAdd
			// 
			this.lbAdd.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.lbAdd.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lbAdd.Location = new System.Drawing.Point(10, 60);
			this.lbAdd.Name = "lbAdd";
			this.lbAdd.Size = new System.Drawing.Size(50, 15);
			this.lbAdd.TabIndex = 21;
			this.lbAdd.Text = "Address";
			// 
			// lbCompanyName
			// 
			this.lbCompanyName.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.lbCompanyName.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lbCompanyName.Location = new System.Drawing.Point(10, 25);
			this.lbCompanyName.Name = "lbCompanyName";
			this.lbCompanyName.Size = new System.Drawing.Size(55, 30);
			this.lbCompanyName.TabIndex = 20;
			this.lbCompanyName.Text = "Company Name";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.liPersons);
			this.groupBox4.Location = new System.Drawing.Point(230, 25);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(665, 150);
			this.groupBox4.TabIndex = 19;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Persons";
			// 
			// liPersons
			// 
			this.liPersons.AutoArrange = false;
			this.liPersons.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.emailPerson});
			this.liPersons.FullRowSelect = true;
			this.liPersons.GridLines = true;
			this.liPersons.HideSelection = false;
			this.liPersons.Location = new System.Drawing.Point(5, 10);
			this.liPersons.MultiSelect = false;
			this.liPersons.Name = "liPersons";
			this.liPersons.Size = new System.Drawing.Size(655, 130);
			this.liPersons.TabIndex = 26;
			this.liPersons.UseCompatibleStateImageBehavior = false;
			this.liPersons.View = System.Windows.Forms.View.Details;
			this.liPersons.Enter += new System.EventHandler(this.liPersons_Enter);
			this.liPersons.Leave += new System.EventHandler(this.ControlFocusLeave);
			// 
			// emailPerson
			// 
			this.emailPerson.Text = "Email";
			this.emailPerson.Width = 161;
			// 
			// lbBus
			// 
			this.lbBus.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.lbBus.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lbBus.Location = new System.Drawing.Point(10, 180);
			this.lbBus.Name = "lbBus";
			this.lbBus.Size = new System.Drawing.Size(40, 15);
			this.lbBus.TabIndex = 18;
			this.lbBus.Text = "Type";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label5.Location = new System.Drawing.Point(10, 160);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(40, 15);
			this.label5.TabIndex = 10;
			this.label5.Text = "Email";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label4.Location = new System.Drawing.Point(10, 140);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 15);
			this.label4.TabIndex = 9;
			this.label4.Text = "Fax";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label3.Location = new System.Drawing.Point(10, 120);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 15);
			this.label3.TabIndex = 8;
			this.label3.Text = "Phone";
			// 
			// chbMail
			// 
			this.chbMail.Enabled = false;
			this.chbMail.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.chbMail.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chbMail.Location = new System.Drawing.Point(405, 185);
			this.chbMail.Name = "chbMail";
			this.chbMail.Size = new System.Drawing.Size(55, 15);
			this.chbMail.TabIndex = 3;
			this.chbMail.Text = "Mail";
			// 
			// chbEmail
			// 
			this.chbEmail.Enabled = false;
			this.chbEmail.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.chbEmail.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chbEmail.Location = new System.Drawing.Point(350, 185);
			this.chbEmail.Name = "chbEmail";
			this.chbEmail.Size = new System.Drawing.Size(55, 15);
			this.chbEmail.TabIndex = 2;
			this.chbEmail.Text = "Email";
			// 
			// chbPhone
			// 
			this.chbPhone.Enabled = false;
			this.chbPhone.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.chbPhone.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chbPhone.Location = new System.Drawing.Point(250, 185);
			this.chbPhone.Name = "chbPhone";
			this.chbPhone.Size = new System.Drawing.Size(55, 15);
			this.chbPhone.TabIndex = 1;
			this.chbPhone.Text = "Phone";
			// 
			// chbFax
			// 
			this.chbFax.Enabled = false;
			this.chbFax.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.chbFax.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chbFax.Location = new System.Drawing.Point(305, 185);
			this.chbFax.Name = "chbFax";
			this.chbFax.Size = new System.Drawing.Size(45, 15);
			this.chbFax.TabIndex = 0;
			this.chbFax.Text = "Fax";
			// 
			// tpOrders
			// 
			this.tpOrders.Controls.Add(this.groupBox1);
			this.tpOrders.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.tpOrders.ForeColor = System.Drawing.Color.DimGray;
			this.tpOrders.Location = new System.Drawing.Point(19, 4);
			this.tpOrders.Name = "tpOrders";
			this.tpOrders.Size = new System.Drawing.Size(1243, 669);
			this.tpOrders.TabIndex = 1;
			this.tpOrders.Text = "Open Orders, Stones     ";
			this.tpOrders.Visible = false;
			this.tpOrders.Enter += new System.EventHandler(this.tpOrders_Enter);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lvAddServices);
			this.groupBox1.Controls.Add(this.label21);
			this.groupBox1.Controls.Add(this.gbBilling);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.lvMigratedItemData);
			this.groupBox1.Controls.Add(this.btnFoceEndSession);
			this.groupBox1.Controls.Add(this.cmd_ReloadList);
			this.groupBox1.Controls.Add(this.label16);
			this.groupBox1.Controls.Add(this.cbPersons);
			this.groupBox1.Controls.Add(this.bFax);
			this.groupBox1.Controls.Add(this.comboBox2);
			this.groupBox1.Controls.Add(this.button13);
			this.groupBox1.Controls.Add(this.lbxItems);
			this.groupBox1.Controls.Add(this.bPrint);
			this.groupBox1.Controls.Add(this.otOpenOrders);
			this.groupBox1.Controls.Add(this.bEndSession);
			this.groupBox1.Controls.Add(this.bOrderUpdate);
			this.groupBox1.Controls.Add(this.pictureBox1);
			this.groupBox1.Controls.Add(this.bPrintLabel);
			this.groupBox1.Controls.Add(this.groupBox7);
			this.groupBox1.Controls.Add(this.groupBox6);
			this.groupBox1.Controls.Add(this.bBillWithSKU);
			this.groupBox1.Controls.Add(this.bAddToDeliveryList);
			this.groupBox1.Controls.Add(this.button3);
			this.groupBox1.Controls.Add(this.button4);
			this.groupBox1.Controls.Add(this.bOrderReports);
			this.groupBox1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.groupBox1.ForeColor = System.Drawing.Color.DimGray;
			this.groupBox1.Location = new System.Drawing.Point(5, 5);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(1235, 660);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Open orders";
			// 
			// lvAddServices
			// 
			this.lvAddServices.AllowColumnReorder = true;
			this.lvAddServices.CheckBoxes = true;
			this.lvAddServices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader12,
            this.AddServiceID,
            this.AddServiceName,
            this.BatchID,
            this.BatchCode,
            this.Price,
            this.PriceID,
            this.AuthorID});
			this.lvAddServices.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lvAddServices.FullRowSelect = true;
			this.lvAddServices.GridLines = true;
			this.lvAddServices.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvAddServices.Location = new System.Drawing.Point(473, 33);
			this.lvAddServices.MultiSelect = false;
			this.lvAddServices.Name = "lvAddServices";
			this.lvAddServices.Size = new System.Drawing.Size(227, 393);
			this.lvAddServices.TabIndex = 36;
			this.lvAddServices.UseCompatibleStateImageBehavior = false;
			this.lvAddServices.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader12
			// 
			this.columnHeader12.Text = "";
			this.columnHeader12.Width = 20;
			// 
			// AddServiceID
			// 
			this.AddServiceID.Text = "";
			this.AddServiceID.Width = 0;
			// 
			// AddServiceName
			// 
			this.AddServiceName.Text = "Service";
			this.AddServiceName.Width = 120;
			// 
			// BatchID
			// 
			this.BatchID.Text = "";
			this.BatchID.Width = 0;
			// 
			// BatchCode
			// 
			this.BatchCode.Text = "Batch";
			// 
			// Price
			// 
			this.Price.Width = 0;
			// 
			// PriceID
			// 
			this.PriceID.Width = 0;
			// 
			// AuthorID
			// 
			this.AuthorID.Width = 0;
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.ForeColor = System.Drawing.Color.Black;
			this.label21.Location = new System.Drawing.Point(471, 16);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(114, 12);
			this.label21.TabIndex = 35;
			this.label21.Text = "Additional Services";
			// 
			// gbBilling
			// 
			this.gbBilling.Controls.Add(this.cbBillingWithLot);
			this.gbBilling.Controls.Add(this.cbBillingWithSKU);
			this.gbBilling.Controls.Add(this.cbRegularBilling);
			this.gbBilling.Controls.Add(this.bBill);
			this.gbBilling.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
			this.gbBilling.Location = new System.Drawing.Point(724, 300);
			this.gbBilling.Name = "gbBilling";
			this.gbBilling.Size = new System.Drawing.Size(146, 131);
			this.gbBilling.TabIndex = 33;
			this.gbBilling.TabStop = false;
			this.gbBilling.Text = "Billing Options";
			// 
			// cbBillingWithLot
			// 
			this.cbBillingWithLot.ForeColor = System.Drawing.Color.Black;
			this.cbBillingWithLot.Location = new System.Drawing.Point(10, 100);
			this.cbBillingWithLot.Name = "cbBillingWithLot";
			this.cbBillingWithLot.Size = new System.Drawing.Size(80, 20);
			this.cbBillingWithLot.TabIndex = 34;
			this.cbBillingWithLot.Text = "Add Lot #";
			this.cbBillingWithLot.CheckedChanged += new System.EventHandler(this.cbBillingWithLot_CheckedChanged);
			// 
			// cbBillingWithSKU
			// 
			this.cbBillingWithSKU.ForeColor = System.Drawing.Color.Black;
			this.cbBillingWithSKU.Location = new System.Drawing.Point(10, 75);
			this.cbBillingWithSKU.Name = "cbBillingWithSKU";
			this.cbBillingWithSKU.Size = new System.Drawing.Size(80, 20);
			this.cbBillingWithSKU.TabIndex = 33;
			this.cbBillingWithSKU.Text = "Add SKU";
			this.cbBillingWithSKU.CheckedChanged += new System.EventHandler(this.cbBillingWithSKU_CheckedChanged);
			// 
			// cbRegularBilling
			// 
			this.cbRegularBilling.Checked = true;
			this.cbRegularBilling.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbRegularBilling.ForeColor = System.Drawing.Color.Black;
			this.cbRegularBilling.Location = new System.Drawing.Point(10, 50);
			this.cbRegularBilling.Name = "cbRegularBilling";
			this.cbRegularBilling.Size = new System.Drawing.Size(80, 20);
			this.cbRegularBilling.TabIndex = 32;
			this.cbRegularBilling.Text = "Regular";
			this.cbRegularBilling.CheckedChanged += new System.EventHandler(this.cbRegularBilling_CheckedChanged);
			// 
			// bBill
			// 
			this.bBill.BackColor = System.Drawing.Color.LightSteelBlue;
			this.bBill.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
			this.bBill.ForeColor = System.Drawing.Color.Black;
			this.bBill.Location = new System.Drawing.Point(10, 20);
			this.bBill.Name = "bBill";
			this.bBill.Size = new System.Drawing.Size(105, 23);
			this.bBill.TabIndex = 3;
			this.bBill.Text = "Regular Billing";
			this.bBill.UseVisualStyleBackColor = false;
			this.bBill.Click += new System.EventHandler(this.bBill_Click);
			// 
			// label11
			// 
			this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label11.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.ForeColor = System.Drawing.Color.Black;
			this.label11.Location = new System.Drawing.Point(724, 16);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(335, 20);
			this.label11.TabIndex = 29;
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lvMigratedItemData
			// 
			this.lvMigratedItemData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
			this.lvMigratedItemData.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lvMigratedItemData.FullRowSelect = true;
			this.lvMigratedItemData.GridLines = true;
			this.lvMigratedItemData.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvMigratedItemData.Location = new System.Drawing.Point(724, 44);
			this.lvMigratedItemData.MultiSelect = false;
			this.lvMigratedItemData.Name = "lvMigratedItemData";
			this.lvMigratedItemData.Size = new System.Drawing.Size(340, 250);
			this.lvMigratedItemData.TabIndex = 28;
			this.lvMigratedItemData.UseCompatibleStateImageBehavior = false;
			this.lvMigratedItemData.View = System.Windows.Forms.View.Details;
			this.lvMigratedItemData.DoubleClick += new System.EventHandler(this.lvMigratedItemData_DoubleClick);
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "From Old #";
			this.columnHeader4.Width = 110;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Current #";
			this.columnHeader5.Width = 110;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "To New #";
			this.columnHeader6.Width = 110;
			// 
			// btnFoceEndSession
			// 
			this.btnFoceEndSession.BackColor = System.Drawing.Color.LightSteelBlue;
			this.btnFoceEndSession.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
			this.btnFoceEndSession.ForeColor = System.Drawing.Color.Black;
			this.btnFoceEndSession.Location = new System.Drawing.Point(90, 400);
			this.btnFoceEndSession.Name = "btnFoceEndSession";
			this.btnFoceEndSession.Size = new System.Drawing.Size(115, 23);
			this.btnFoceEndSession.TabIndex = 27;
			this.btnFoceEndSession.Text = "Force End Session";
			this.btnFoceEndSession.UseVisualStyleBackColor = false;
			this.btnFoceEndSession.Click += new System.EventHandler(this.btnFoceEndSession_Click);
			// 
			// cmd_ReloadList
			// 
			this.cmd_ReloadList.Location = new System.Drawing.Point(572, 290);
			this.cmd_ReloadList.Name = "cmd_ReloadList";
			this.cmd_ReloadList.Size = new System.Drawing.Size(75, 23);
			this.cmd_ReloadList.TabIndex = 37;
			this.cmd_ReloadList.Text = "Reload List";
			this.cmd_ReloadList.UseVisualStyleBackColor = true;
			this.cmd_ReloadList.Click += new System.EventHandler(this.cmd_ReloadList_Click);
			// 
			// label16
			// 
			this.label16.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label16.Location = new System.Drawing.Point(1086, 16);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(45, 15);
			this.label16.TabIndex = 1;
			this.label16.Text = "Items";
			// 
			// cbPersons
			// 
			this.cbPersons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbPersons.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.cbPersons.ItemHeight = 12;
			this.cbPersons.Location = new System.Drawing.Point(901, 190);
			this.cbPersons.Name = "cbPersons";
			this.cbPersons.Size = new System.Drawing.Size(110, 20);
			this.cbPersons.TabIndex = 9;
			this.cbPersons.Enter += new System.EventHandler(this.cbPersons_Enter);
			// 
			// bFax
			// 
			this.bFax.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.bFax.ForeColor = System.Drawing.SystemColors.ControlText;
			this.bFax.Location = new System.Drawing.Point(826, 190);
			this.bFax.Name = "bFax";
			this.bFax.Size = new System.Drawing.Size(70, 23);
			this.bFax.TabIndex = 8;
			this.bFax.Text = "Fax (F3) ";
			this.bFax.Click += new System.EventHandler(this.bFax_Click);
			// 
			// comboBox2
			// 
			this.comboBox2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.comboBox2.ItemHeight = 12;
			this.comboBox2.Items.AddRange(new object[] {
            "Excel, *.xls",
            "Reach Text Format, *.rtf",
            "PDF, *.pdf",
            "Tab-delimeted, *.txt"});
			this.comboBox2.Location = new System.Drawing.Point(901, 165);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(110, 20);
			this.comboBox2.TabIndex = 11;
			this.comboBox2.Text = "Excel, *.xls";
			this.comboBox2.Enter += new System.EventHandler(this.comboBox2_Enter);
			// 
			// button13
			// 
			this.button13.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.button13.ForeColor = System.Drawing.SystemColors.ControlText;
			this.button13.Location = new System.Drawing.Point(826, 165);
			this.button13.Name = "button13";
			this.button13.Size = new System.Drawing.Size(70, 23);
			this.button13.TabIndex = 10;
			this.button13.Text = "E-mail (F4) ";
			this.button13.Click += new System.EventHandler(this.button13_Click);
			// 
			// lbxItems
			// 
			this.lbxItems.ItemHeight = 12;
			this.lbxItems.Location = new System.Drawing.Point(1070, 31);
			this.lbxItems.Name = "lbxItems";
			this.lbxItems.Size = new System.Drawing.Size(165, 292);
			this.lbxItems.TabIndex = 13;
			this.lbxItems.SelectedIndexChanged += new System.EventHandler(this.lbxItems_SelectedIndexChanged);
			this.lbxItems.Enter += new System.EventHandler(this.lbxItems_Enter);
			// 
			// bPrint
			// 
			this.bPrint.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
			this.bPrint.ForeColor = System.Drawing.SystemColors.ControlText;
			this.bPrint.Location = new System.Drawing.Point(1089, 356);
			this.bPrint.Name = "bPrint";
			this.bPrint.Size = new System.Drawing.Size(140, 23);
			this.bPrint.TabIndex = 7;
			this.bPrint.Text = "View Receipt/Label";
			this.bPrint.Click += new System.EventHandler(this.bPrint_Click);
			// 
			// otOpenOrders
			// 
			this.otOpenOrders.CheckBoxes = true;
			this.otOpenOrders.IsDocumentGhost = false;
			this.otOpenOrders.IsExpand = false;
			this.otOpenOrders.Location = new System.Drawing.Point(0, 0);
			this.otOpenOrders.Name = "otOpenOrders";
			this.otOpenOrders.Selected = null;
			this.otOpenOrders.ShowColorAndClarity = true;
			this.otOpenOrders.Size = new System.Drawing.Size(455, 400);
			this.otOpenOrders.TabIndex = 0;
			this.otOpenOrders.Tag = "";
			this.otOpenOrders.SelectedItemChanged += new System.EventHandler(this.otOpenOrders_SelectedItemChanged);
			this.otOpenOrders.RealDoubleClick += new System.EventHandler(this.otOpenOrders_RealDoubleClick);
			this.otOpenOrders.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.otOpenOrders_AfterCheck);
			this.otOpenOrders.Enter += new System.EventHandler(this.otOpenOrders_Enter);
			// 
			// bEndSession
			// 
			this.bEndSession.BackColor = System.Drawing.Color.LightSteelBlue;
			this.bEndSession.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bEndSession.ForeColor = System.Drawing.Color.Black;
			this.bEndSession.Location = new System.Drawing.Point(5, 400);
			this.bEndSession.Name = "bEndSession";
			this.bEndSession.Size = new System.Drawing.Size(80, 23);
			this.bEndSession.TabIndex = 2;
			this.bEndSession.Text = "End Session";
			this.bEndSession.UseVisualStyleBackColor = false;
			this.bEndSession.Click += new System.EventHandler(this.bEndSession_Click);
			// 
			// bOrderUpdate
			// 
			this.bOrderUpdate.BackColor = System.Drawing.Color.RosyBrown;
			this.bOrderUpdate.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
			this.bOrderUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.bOrderUpdate.Location = new System.Drawing.Point(315, 400);
			this.bOrderUpdate.Name = "bOrderUpdate";
			this.bOrderUpdate.Size = new System.Drawing.Size(95, 23);
			this.bOrderUpdate.TabIndex = 8;
			this.bOrderUpdate.Text = "Order &Update";
			this.bOrderUpdate.UseVisualStyleBackColor = false;
			this.bOrderUpdate.Click += new System.EventHandler(this.button4_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
			this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
			this.pictureBox1.Location = new System.Drawing.Point(809, 126);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(115, 85);
			this.pictureBox1.TabIndex = 26;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Visible = false;
			// 
			// bPrintLabel
			// 
			this.bPrintLabel.BackColor = System.Drawing.Color.LightSteelBlue;
			this.bPrintLabel.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
			this.bPrintLabel.ForeColor = System.Drawing.Color.Black;
			this.bPrintLabel.Location = new System.Drawing.Point(220, 400);
			this.bPrintLabel.Name = "bPrintLabel";
			this.bPrintLabel.Size = new System.Drawing.Size(85, 23);
			this.bPrintLabel.TabIndex = 4;
			this.bPrintLabel.Text = "Print Labels";
			this.bPrintLabel.UseVisualStyleBackColor = false;
			this.bPrintLabel.Click += new System.EventHandler(this.bPrintLabel_Click);
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.lbNOpenItems);
			this.groupBox7.Controls.Add(this.cmd_ClearAddServiceList);
			this.groupBox7.Controls.Add(this.groupBox3);
			this.groupBox7.Controls.Add(this.groupBox8);
			this.groupBox7.Controls.Add(this.groupBox11);
			this.groupBox7.Controls.Add(this.lbOtherDetails);
			this.groupBox7.Controls.Add(this.lvProps);
			this.groupBox7.Controls.Add(this.groupBox5);
			this.groupBox7.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.groupBox7.ForeColor = System.Drawing.SystemColors.ControlText;
			this.groupBox7.Location = new System.Drawing.Point(5, 425);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(1123, 235);
			this.groupBox7.TabIndex = 5;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Item Details";
			// 
			// lbNOpenItems
			// 
			this.lbNOpenItems.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbNOpenItems.Location = new System.Drawing.Point(564, 186);
			this.lbNOpenItems.Name = "lbNOpenItems";
			this.lbNOpenItems.Size = new System.Drawing.Size(40, 20);
			this.lbNOpenItems.TabIndex = 5;
			this.lbNOpenItems.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cmd_ClearAddServiceList
			// 
			this.cmd_ClearAddServiceList.Location = new System.Drawing.Point(556, 19);
			this.cmd_ClearAddServiceList.Name = "cmd_ClearAddServiceList";
			this.cmd_ClearAddServiceList.Size = new System.Drawing.Size(75, 23);
			this.cmd_ClearAddServiceList.TabIndex = 36;
			this.cmd_ClearAddServiceList.Text = "Clear List";
			this.cmd_ClearAddServiceList.UseVisualStyleBackColor = true;
			this.cmd_ClearAddServiceList.Click += new System.EventHandler(this.cmd_ClearAddServiceList_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.lbMemo);
			this.groupBox3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.groupBox3.Location = new System.Drawing.Point(801, 39);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(325, 40);
			this.groupBox3.TabIndex = 34;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Memo";
			// 
			// lbMemo
			// 
			this.lbMemo.Location = new System.Drawing.Point(15, 20);
			this.lbMemo.Name = "lbMemo";
			this.lbMemo.Size = new System.Drawing.Size(300, 10);
			this.lbMemo.TabIndex = 0;
			// 
			// groupBox8
			// 
			this.groupBox8.Controls.Add(this.pnlShapeContainer);
			this.groupBox8.Controls.Add(this.pbShape);
			this.groupBox8.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.groupBox8.ForeColor = System.Drawing.SystemColors.ControlText;
			this.groupBox8.Location = new System.Drawing.Point(971, 85);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(150, 145);
			this.groupBox8.TabIndex = 32;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Shape";
			// 
			// pnlShapeContainer
			// 
			this.pnlShapeContainer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlShapeContainer.BackgroundImage")));
			this.pnlShapeContainer.Location = new System.Drawing.Point(10, 20);
			this.pnlShapeContainer.Name = "pnlShapeContainer";
			this.pnlShapeContainer.Size = new System.Drawing.Size(130, 115);
			this.pnlShapeContainer.TabIndex = 0;
			// 
			// pbShape
			// 
			this.pbShape.BackColor = System.Drawing.Color.Transparent;
			this.pbShape.Location = new System.Drawing.Point(10, 20);
			this.pbShape.Name = "pbShape";
			this.pbShape.Size = new System.Drawing.Size(130, 115);
			this.pbShape.TabIndex = 27;
			this.pbShape.TabStop = false;
			// 
			// groupBox11
			// 
			this.groupBox11.Controls.Add(this.pictureBox2);
			this.groupBox11.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.groupBox11.ForeColor = System.Drawing.SystemColors.ControlText;
			this.groupBox11.Location = new System.Drawing.Point(801, 85);
			this.groupBox11.Name = "groupBox11";
			this.groupBox11.Size = new System.Drawing.Size(155, 145);
			this.groupBox11.TabIndex = 31;
			this.groupBox11.TabStop = false;
			this.groupBox11.Text = "Picture";
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackColor = System.Drawing.SystemColors.Control;
			this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
			this.pictureBox2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.pictureBox2.Location = new System.Drawing.Point(10, 20);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(135, 115);
			this.pictureBox2.TabIndex = 26;
			this.pictureBox2.TabStop = false;
			// 
			// lbOtherDetails
			// 
			this.lbOtherDetails.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbOtherDetails.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lbOtherDetails.Location = new System.Drawing.Point(801, 9);
			this.lbOtherDetails.Name = "lbOtherDetails";
			this.lbOtherDetails.Size = new System.Drawing.Size(325, 30);
			this.lbOtherDetails.TabIndex = 2;
			this.lbOtherDetails.Text = "Lot #, Item #";
			// 
			// lvProps
			// 
			this.lvProps.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PartName,
            this.chName,
            this.chValue,
            this.chPrevValue});
			this.lvProps.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.lvProps.FullRowSelect = true;
			this.lvProps.GridLines = true;
			this.lvProps.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvProps.Location = new System.Drawing.Point(5, 20);
			this.lvProps.MultiSelect = false;
			this.lvProps.Name = "lvProps";
			this.lvProps.Size = new System.Drawing.Size(545, 210);
			this.lvProps.TabIndex = 35;
			this.lvProps.UseCompatibleStateImageBehavior = false;
			this.lvProps.View = System.Windows.Forms.View.Details;
			// 
			// PartName
			// 
			this.PartName.Text = "Part Name";
			this.PartName.Width = 123;
			// 
			// chName
			// 
			this.chName.Text = "Grade";
			this.chName.Width = 142;
			// 
			// chValue
			// 
			this.chValue.Text = "Value";
			this.chValue.Width = 128;
			// 
			// chPrevValue
			// 
			this.chPrevValue.Text = "Previous Value";
			this.chPrevValue.Width = 127;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.lbNOpenBatches);
			this.groupBox5.Controls.Add(this.lbNOpenOrders);
			this.groupBox5.Controls.Add(this.label15);
			this.groupBox5.Controls.Add(this.label14);
			this.groupBox5.Controls.Add(this.label12);
			this.groupBox5.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.groupBox5.ForeColor = System.Drawing.SystemColors.ControlText;
			this.groupBox5.Location = new System.Drawing.Point(645, 121);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(150, 99);
			this.groupBox5.TabIndex = 1;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Totals";
			// 
			// lbNOpenBatches
			// 
			this.lbNOpenBatches.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbNOpenBatches.Location = new System.Drawing.Point(100, 50);
			this.lbNOpenBatches.Name = "lbNOpenBatches";
			this.lbNOpenBatches.Size = new System.Drawing.Size(40, 20);
			this.lbNOpenBatches.TabIndex = 3;
			this.lbNOpenBatches.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lbNOpenOrders
			// 
			this.lbNOpenOrders.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbNOpenOrders.Location = new System.Drawing.Point(100, 20);
			this.lbNOpenOrders.Name = "lbNOpenOrders";
			this.lbNOpenOrders.Size = new System.Drawing.Size(40, 20);
			this.lbNOpenOrders.TabIndex = 1;
			this.lbNOpenOrders.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(10, 65);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(90, 15);
			this.label15.TabIndex = 4;
			this.label15.Text = "# open items";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(10, 45);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(90, 15);
			this.label14.TabIndex = 2;
			this.label14.Text = "# open batches";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(10, 25);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(90, 15);
			this.label12.TabIndex = 0;
			this.label12.Text = "# open orders";
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.ptrOps);
			this.groupBox6.Controls.Add(this.label37);
			this.groupBox6.Location = new System.Drawing.Point(65, 75);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(125, 210);
			this.groupBox6.TabIndex = 1;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Order Details";
			// 
			// ptrOps
			// 
			this.ptrOps.Location = new System.Drawing.Point(690, 35);
			this.ptrOps.Name = "ptrOps";
			this.ptrOps.Size = new System.Drawing.Size(205, 90);
			this.ptrOps.TabIndex = 14;
			this.ptrOps.Enter += new System.EventHandler(this.ptrOps_Enter);
			// 
			// label37
			// 
			this.label37.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.label37.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label37.Location = new System.Drawing.Point(690, 15);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(115, 15);
			this.label37.TabIndex = 2;
			this.label37.Text = "Operations";
			// 
			// bBillWithSKU
			// 
			this.bBillWithSKU.BackColor = System.Drawing.SystemColors.ControlLight;
			this.bBillWithSKU.Enabled = false;
			this.bBillWithSKU.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bBillWithSKU.ForeColor = System.Drawing.Color.Black;
			this.bBillWithSKU.Location = new System.Drawing.Point(1082, 216);
			this.bBillWithSKU.Name = "bBillWithSKU";
			this.bBillWithSKU.Size = new System.Drawing.Size(100, 23);
			this.bBillWithSKU.TabIndex = 31;
			this.bBillWithSKU.Text = "Bill with SKU";
			this.bBillWithSKU.UseVisualStyleBackColor = false;
			this.bBillWithSKU.Visible = false;
			this.bBillWithSKU.Click += new System.EventHandler(this.bBillWithSKU_Click);
			// 
			// bAddToDeliveryList
			// 
			this.bAddToDeliveryList.BackColor = System.Drawing.Color.LightGray;
			this.bAddToDeliveryList.Enabled = false;
			this.bAddToDeliveryList.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bAddToDeliveryList.ForeColor = System.Drawing.Color.Black;
			this.bAddToDeliveryList.Location = new System.Drawing.Point(1088, 262);
			this.bAddToDeliveryList.Name = "bAddToDeliveryList";
			this.bAddToDeliveryList.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.bAddToDeliveryList.Size = new System.Drawing.Size(105, 23);
			this.bAddToDeliveryList.TabIndex = 32;
			this.bAddToDeliveryList.Text = "Add To Delivery";
			this.bAddToDeliveryList.UseVisualStyleBackColor = false;
			this.bAddToDeliveryList.Visible = false;
			// 
			// button3
			// 
			this.button3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.button3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.button3.Location = new System.Drawing.Point(1107, 206);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 6;
			this.button3.Text = "Send to GE";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.button4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.button4.Location = new System.Drawing.Point(1122, 177);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 23);
			this.button4.TabIndex = 5;
			this.button4.Text = "Send to LI";
			this.button4.Click += new System.EventHandler(this.button4_Click_1);
			// 
			// bOrderReports
			// 
			this.bOrderReports.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bOrderReports.ForeColor = System.Drawing.Color.Black;
			this.bOrderReports.Location = new System.Drawing.Point(912, 236);
			this.bOrderReports.Name = "bOrderReports";
			this.bOrderReports.Size = new System.Drawing.Size(90, 23);
			this.bOrderReports.TabIndex = 30;
			this.bOrderReports.Text = "View Reports";
			this.bOrderReports.Click += new System.EventHandler(this.bOrderReports_Click);
			// 
			// tpUpdate
			// 
			this.tpUpdate.Controls.Add(this.groupBox16);
			this.tpUpdate.Controls.Add(this.groupBox15);
			this.tpUpdate.Controls.Add(this.tbItemName);
			this.tpUpdate.Controls.Add(this.label30);
			this.tpUpdate.Controls.Add(this.label29);
			this.tpUpdate.Controls.Add(this.tbOrderName);
			this.tpUpdate.Controls.Add(this.groupBox13);
			this.tpUpdate.Controls.Add(this.bDetailsUpdate);
			this.tpUpdate.Controls.Add(this.bDetailsClear);
			this.tpUpdate.Controls.Add(this.groupBox10);
			this.tpUpdate.Controls.Add(this.lbPersonID);
			this.tpUpdate.Location = new System.Drawing.Point(19, 4);
			this.tpUpdate.Name = "tpUpdate";
			this.tpUpdate.Size = new System.Drawing.Size(1243, 669);
			this.tpUpdate.TabIndex = 2;
			this.tpUpdate.Text = "Update Order        ";
			this.tpUpdate.Visible = false;
			this.tpUpdate.Enter += new System.EventHandler(this.tpUpdate_Enter);
			// 
			// groupBox16
			// 
			this.groupBox16.Controls.Add(this.lvDocs);
			this.groupBox16.ForeColor = System.Drawing.Color.DimGray;
			this.groupBox16.Location = new System.Drawing.Point(5, 370);
			this.groupBox16.Name = "groupBox16";
			this.groupBox16.Size = new System.Drawing.Size(405, 260);
			this.groupBox16.TabIndex = 33;
			this.groupBox16.TabStop = false;
			this.groupBox16.Text = "Order Summary";
			// 
			// lvDocs
			// 
			this.lvDocs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
			this.lvDocs.FullRowSelect = true;
			this.lvDocs.GridLines = true;
			this.lvDocs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvDocs.Location = new System.Drawing.Point(5, 20);
			this.lvDocs.MultiSelect = false;
			this.lvDocs.Name = "lvDocs";
			this.lvDocs.Size = new System.Drawing.Size(395, 235);
			this.lvDocs.TabIndex = 0;
			this.lvDocs.UseCompatibleStateImageBehavior = false;
			this.lvDocs.View = System.Windows.Forms.View.Details;
			this.lvDocs.Enter += new System.EventHandler(this.lvDocs_Enter);
			this.lvDocs.Leave += new System.EventHandler(this.ControlFocusLeave);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Item code";
			this.columnHeader1.Width = 136;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Document/Service";
			this.columnHeader2.Width = 185;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Property";
			this.columnHeader3.Width = 70;
			// 
			// groupBox15
			// 
			this.groupBox15.Controls.Add(this.pnlDetails);
			this.groupBox15.ForeColor = System.Drawing.Color.DimGray;
			this.groupBox15.Location = new System.Drawing.Point(415, 370);
			this.groupBox15.Name = "groupBox15";
			this.groupBox15.Size = new System.Drawing.Size(663, 260);
			this.groupBox15.TabIndex = 32;
			this.groupBox15.TabStop = false;
			this.groupBox15.Text = "Order Details";
			// 
			// pnlDetails
			// 
			this.pnlDetails.AutoScroll = true;
			this.pnlDetails.Enabled = false;
			this.pnlDetails.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.pnlDetails.ForeColor = System.Drawing.SystemColors.ControlText;
			this.pnlDetails.Location = new System.Drawing.Point(5, 20);
			this.pnlDetails.Name = "pnlDetails";
			this.pnlDetails.Size = new System.Drawing.Size(480, 235);
			this.pnlDetails.TabIndex = 0;
			this.pnlDetails.Enter += new System.EventHandler(this.pnlDetails_Enter);
			this.pnlDetails.Leave += new System.EventHandler(this.ControlFocusLeave);
			// 
			// tbItemName
			// 
			this.tbItemName.Location = new System.Drawing.Point(735, 345);
			this.tbItemName.MaxLength = 18;
			this.tbItemName.Name = "tbItemName";
			this.tbItemName.Size = new System.Drawing.Size(155, 20);
			this.tbItemName.TabIndex = 31;
			this.tbItemName.Text = "#####.#####.###.##";
			this.tbItemName.TextChanged += new System.EventHandler(this.tbItemName_TextChanged);
			this.tbItemName.Enter += new System.EventHandler(this.tbItemName_Enter);
			this.tbItemName.Leave += new System.EventHandler(this.ControlFocusLeave);
			// 
			// label30
			// 
			this.label30.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.label30.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label30.Location = new System.Drawing.Point(640, 350);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(85, 15);
			this.label30.TabIndex = 30;
			this.label30.Text = "Item Number";
			// 
			// label29
			// 
			this.label29.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.label29.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label29.Location = new System.Drawing.Point(425, 350);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(85, 15);
			this.label29.TabIndex = 29;
			this.label29.Text = "Order Number";
			// 
			// tbOrderName
			// 
			this.tbOrderName.Location = new System.Drawing.Point(520, 345);
			this.tbOrderName.MaxLength = 5;
			this.tbOrderName.Name = "tbOrderName";
			this.tbOrderName.Size = new System.Drawing.Size(100, 20);
			this.tbOrderName.TabIndex = 28;
			this.tbOrderName.Text = "#####.#####";
			this.tbOrderName.TextChanged += new System.EventHandler(this.tbOrderName_TextChanged);
			this.tbOrderName.Enter += new System.EventHandler(this.tbOrderName_Enter);
			this.tbOrderName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbOrderName_KeyPress);
			this.tbOrderName.Leave += new System.EventHandler(this.ControlFocusLeave);
			// 
			// groupBox13
			// 
			this.groupBox13.Controls.Add(this.otAllOrders);
			this.groupBox13.Controls.Add(this.panel1);
			this.groupBox13.Controls.Add(this.groupBox14);
			this.groupBox13.ForeColor = System.Drawing.Color.DimGray;
			this.groupBox13.Location = new System.Drawing.Point(415, 5);
			this.groupBox13.Name = "groupBox13";
			this.groupBox13.Size = new System.Drawing.Size(663, 335);
			this.groupBox13.TabIndex = 27;
			this.groupBox13.TabStop = false;
			this.groupBox13.Text = "Orders";
			// 
			// otAllOrders
			// 
			this.otAllOrders.CheckBoxes = true;
			this.otAllOrders.IsDocumentGhost = false;
			this.otAllOrders.IsExpand = false;
			this.otAllOrders.Location = new System.Drawing.Point(10, 65);
			this.otAllOrders.Name = "otAllOrders";
			this.otAllOrders.Selected = null;
			this.otAllOrders.ShowColorAndClarity = true;
			this.otAllOrders.Size = new System.Drawing.Size(480, 240);
			this.otAllOrders.TabIndex = 26;
			this.otAllOrders.WrongCheck += new System.EventHandler(this.otAllOrders_WrongCheck);
			this.otAllOrders.RealDoubleClick += new System.EventHandler(this.otAllOrders_RealDoubleClick);
			this.otAllOrders.Enter += new System.EventHandler(this.otAllOrders_Enter);
			this.otAllOrders.Leave += new System.EventHandler(this.ControlFocusLeave);
			// 
			// panel1
			// 
			this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
			this.panel1.Controls.Add(this.bDetailsAdd);
			this.panel1.Location = new System.Drawing.Point(15, 310);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(475, 20);
			this.panel1.TabIndex = 25;
			// 
			// bDetailsAdd
			// 
			this.bDetailsAdd.BackColor = System.Drawing.Color.LightSteelBlue;
			this.bDetailsAdd.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.bDetailsAdd.ForeColor = System.Drawing.SystemColors.ControlText;
			this.bDetailsAdd.Location = new System.Drawing.Point(400, 0);
			this.bDetailsAdd.Name = "bDetailsAdd";
			this.bDetailsAdd.Size = new System.Drawing.Size(75, 20);
			this.bDetailsAdd.TabIndex = 24;
			this.bDetailsAdd.Text = "Add";
			this.bDetailsAdd.UseVisualStyleBackColor = false;
			this.bDetailsAdd.Click += new System.EventHandler(this.bDetailsAdd_Click);
			// 
			// groupBox14
			// 
			this.groupBox14.Controls.Add(this.dtpUpdTo);
			this.groupBox14.Controls.Add(this.lbSearchTo);
			this.groupBox14.Controls.Add(this.dtpUpdFrom);
			this.groupBox14.Controls.Add(this.lbSearchFrom);
			this.groupBox14.Controls.Add(this.bDetailsSelect);
			this.groupBox14.Controls.Add(this.bUpdOrdOrdersClear);
			this.groupBox14.Location = new System.Drawing.Point(10, 15);
			this.groupBox14.Name = "groupBox14";
			this.groupBox14.Size = new System.Drawing.Size(480, 45);
			this.groupBox14.TabIndex = 23;
			this.groupBox14.TabStop = false;
			this.groupBox14.Text = "Date Range Search";
			// 
			// dtpUpdTo
			// 
			this.dtpUpdTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpUpdTo.Location = new System.Drawing.Point(180, 20);
			this.dtpUpdTo.Name = "dtpUpdTo";
			this.dtpUpdTo.Size = new System.Drawing.Size(90, 20);
			this.dtpUpdTo.TabIndex = 27;
			this.dtpUpdTo.ValueChanged += new System.EventHandler(this.dtpUpdTo_ValueChanged);
			this.dtpUpdTo.Enter += new System.EventHandler(this.dateTimePicker2_Enter);
			this.dtpUpdTo.Leave += new System.EventHandler(this.ControlFocusLeave);
			// 
			// lbSearchTo
			// 
			this.lbSearchTo.Location = new System.Drawing.Point(155, 25);
			this.lbSearchTo.Name = "lbSearchTo";
			this.lbSearchTo.Size = new System.Drawing.Size(20, 15);
			this.lbSearchTo.TabIndex = 26;
			this.lbSearchTo.Text = "To";
			// 
			// dtpUpdFrom
			// 
			this.dtpUpdFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpUpdFrom.Location = new System.Drawing.Point(55, 20);
			this.dtpUpdFrom.Name = "dtpUpdFrom";
			this.dtpUpdFrom.Size = new System.Drawing.Size(90, 20);
			this.dtpUpdFrom.TabIndex = 25;
			this.dtpUpdFrom.ValueChanged += new System.EventHandler(this.dtpUpdFrom_ValueChanged);
			this.dtpUpdFrom.Enter += new System.EventHandler(this.dateTimePicker1_Enter);
			this.dtpUpdFrom.Leave += new System.EventHandler(this.ControlFocusLeave);
			// 
			// lbSearchFrom
			// 
			this.lbSearchFrom.Location = new System.Drawing.Point(10, 25);
			this.lbSearchFrom.Name = "lbSearchFrom";
			this.lbSearchFrom.Size = new System.Drawing.Size(40, 15);
			this.lbSearchFrom.TabIndex = 24;
			this.lbSearchFrom.Text = "From";
			// 
			// bDetailsSelect
			// 
			this.bDetailsSelect.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.bDetailsSelect.ForeColor = System.Drawing.SystemColors.ControlText;
			this.bDetailsSelect.Location = new System.Drawing.Point(280, 20);
			this.bDetailsSelect.Name = "bDetailsSelect";
			this.bDetailsSelect.Size = new System.Drawing.Size(65, 20);
			this.bDetailsSelect.TabIndex = 23;
			this.bDetailsSelect.Text = "Refresh";
			this.bDetailsSelect.Click += new System.EventHandler(this.bDetailsSelect_Click);
			// 
			// bUpdOrdOrdersClear
			// 
			this.bUpdOrdOrdersClear.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.bUpdOrdOrdersClear.ForeColor = System.Drawing.SystemColors.ControlText;
			this.bUpdOrdOrdersClear.Location = new System.Drawing.Point(410, 20);
			this.bUpdOrdOrdersClear.Name = "bUpdOrdOrdersClear";
			this.bUpdOrdOrdersClear.Size = new System.Drawing.Size(65, 20);
			this.bUpdOrdOrdersClear.TabIndex = 22;
			this.bUpdOrdOrdersClear.Text = "Clear";
			this.bUpdOrdOrdersClear.Click += new System.EventHandler(this.bUpdOrdOrdersClear_Click);
			// 
			// bDetailsUpdate
			// 
			this.bDetailsUpdate.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.bDetailsUpdate.Location = new System.Drawing.Point(765, 640);
			this.bDetailsUpdate.Name = "bDetailsUpdate";
			this.bDetailsUpdate.Size = new System.Drawing.Size(140, 20);
			this.bDetailsUpdate.TabIndex = 8;
			this.bDetailsUpdate.Text = "Update";
			this.bDetailsUpdate.Click += new System.EventHandler(this.bDetailsUpdate_Click);
			// 
			// bDetailsClear
			// 
			this.bDetailsClear.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.bDetailsClear.Location = new System.Drawing.Point(615, 640);
			this.bDetailsClear.Name = "bDetailsClear";
			this.bDetailsClear.Size = new System.Drawing.Size(140, 20);
			this.bDetailsClear.TabIndex = 7;
			this.bDetailsClear.Text = "Clear";
			this.bDetailsClear.Click += new System.EventHandler(this.bDetailsClear_Click);
			// 
			// groupBox10
			// 
			this.groupBox10.Controls.Add(this.label8);
			this.groupBox10.Controls.Add(this.label7);
			this.groupBox10.Controls.Add(this.label6);
			this.groupBox10.Controls.Add(this.lbxIndustry2);
			this.groupBox10.Controls.Add(this.lbCustMembership);
			this.groupBox10.Controls.Add(this.lbCustEmail);
			this.groupBox10.Controls.Add(this.lbCustFax);
			this.groupBox10.Controls.Add(this.lbCustPhone);
			this.groupBox10.Controls.Add(this.lbCustAddr);
			this.groupBox10.Controls.Add(this.lbCustComp);
			this.groupBox10.Controls.Add(this.groupBox12);
			this.groupBox10.Controls.Add(this.lbCustBusiness);
			this.groupBox10.Controls.Add(this.label23);
			this.groupBox10.Controls.Add(this.label24);
			this.groupBox10.Controls.Add(this.label25);
			this.groupBox10.Controls.Add(this.chbMail1);
			this.groupBox10.Controls.Add(this.chbEmail1);
			this.groupBox10.Controls.Add(this.chbPhone1);
			this.groupBox10.Controls.Add(this.chbFax1);
			this.groupBox10.ForeColor = System.Drawing.Color.DimGray;
			this.groupBox10.Location = new System.Drawing.Point(6, 5);
			this.groupBox10.Name = "groupBox10";
			this.groupBox10.Size = new System.Drawing.Size(404, 285);
			this.groupBox10.TabIndex = 6;
			this.groupBox10.TabStop = false;
			this.groupBox10.Text = "Customer Details";
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label8.Location = new System.Drawing.Point(5, 175);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(40, 20);
			this.label8.TabIndex = 33;
			this.label8.Text = "Type";
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label7.Location = new System.Drawing.Point(5, 55);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(50, 15);
			this.label7.TabIndex = 32;
			this.label7.Text = "Address";
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label6.Location = new System.Drawing.Point(5, 25);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(55, 25);
			this.label6.TabIndex = 31;
			this.label6.Text = "Company Name";
			// 
			// lbxIndustry2
			// 
			this.lbxIndustry2.ItemHeight = 12;
			this.lbxIndustry2.Location = new System.Drawing.Point(80, 200);
			this.lbxIndustry2.Name = "lbxIndustry2";
			this.lbxIndustry2.ScrollAlwaysVisible = true;
			this.lbxIndustry2.Size = new System.Drawing.Size(120, 52);
			this.lbxIndustry2.TabIndex = 30;
			this.lbxIndustry2.Enter += new System.EventHandler(this.lbxIndustry_Enter);
			this.lbxIndustry2.Leave += new System.EventHandler(this.ControlFocusLeave);
			// 
			// lbCustMembership
			// 
			this.lbCustMembership.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.lbCustMembership.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lbCustMembership.Location = new System.Drawing.Point(5, 200);
			this.lbCustMembership.Name = "lbCustMembership";
			this.lbCustMembership.Size = new System.Drawing.Size(70, 35);
			this.lbCustMembership.TabIndex = 25;
			this.lbCustMembership.Text = "Industry membership";
			// 
			// lbCustEmail
			// 
			this.lbCustEmail.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.lbCustEmail.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lbCustEmail.Location = new System.Drawing.Point(60, 155);
			this.lbCustEmail.Name = "lbCustEmail";
			this.lbCustEmail.Size = new System.Drawing.Size(140, 15);
			this.lbCustEmail.TabIndex = 24;
			// 
			// lbCustFax
			// 
			this.lbCustFax.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.lbCustFax.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lbCustFax.Location = new System.Drawing.Point(60, 135);
			this.lbCustFax.Name = "lbCustFax";
			this.lbCustFax.Size = new System.Drawing.Size(140, 15);
			this.lbCustFax.TabIndex = 23;
			// 
			// lbCustPhone
			// 
			this.lbCustPhone.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.lbCustPhone.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lbCustPhone.Location = new System.Drawing.Point(60, 115);
			this.lbCustPhone.Name = "lbCustPhone";
			this.lbCustPhone.Size = new System.Drawing.Size(140, 15);
			this.lbCustPhone.TabIndex = 22;
			// 
			// lbCustAddr
			// 
			this.lbCustAddr.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.lbCustAddr.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lbCustAddr.Location = new System.Drawing.Point(65, 55);
			this.lbCustAddr.Name = "lbCustAddr";
			this.lbCustAddr.Size = new System.Drawing.Size(135, 55);
			this.lbCustAddr.TabIndex = 21;
			// 
			// lbCustComp
			// 
			this.lbCustComp.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.lbCustComp.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lbCustComp.Location = new System.Drawing.Point(65, 25);
			this.lbCustComp.Name = "lbCustComp";
			this.lbCustComp.Size = new System.Drawing.Size(135, 25);
			this.lbCustComp.TabIndex = 20;
			// 
			// groupBox12
			// 
			this.groupBox12.Controls.Add(this.lbPhoneExt);
			this.groupBox12.Controls.Add(this.cbCustPersons);
			this.groupBox12.Controls.Add(this.prmPermissions);
			this.groupBox12.Location = new System.Drawing.Point(205, 10);
			this.groupBox12.Name = "groupBox12";
			this.groupBox12.Size = new System.Drawing.Size(195, 270);
			this.groupBox12.TabIndex = 19;
			this.groupBox12.TabStop = false;
			this.groupBox12.Text = "Persons";
			// 
			// lbPhoneExt
			// 
			this.lbPhoneExt.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.lbPhoneExt.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lbPhoneExt.Location = new System.Drawing.Point(5, 40);
			this.lbPhoneExt.Name = "lbPhoneExt";
			this.lbPhoneExt.Size = new System.Drawing.Size(185, 15);
			this.lbPhoneExt.TabIndex = 22;
			this.lbPhoneExt.Text = "Phone, Ext #";
			// 
			// cbCustPersons
			// 
			this.cbCustPersons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCustPersons.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.cbCustPersons.Location = new System.Drawing.Point(5, 15);
			this.cbCustPersons.Name = "cbCustPersons";
			this.cbCustPersons.Size = new System.Drawing.Size(185, 20);
			this.cbCustPersons.TabIndex = 10;
			this.cbCustPersons.SelectedIndexChanged += new System.EventHandler(this.cbCustPersons_SelectedIndexChanged);
			this.cbCustPersons.Enter += new System.EventHandler(this.cbCustPersons_Enter);
			this.cbCustPersons.Leave += new System.EventHandler(this.ControlFocusLeave);
			// 
			// prmPermissions
			// 
			this.prmPermissions.Enabled = false;
			this.prmPermissions.Location = new System.Drawing.Point(5, 55);
			this.prmPermissions.Name = "prmPermissions";
			this.prmPermissions.Size = new System.Drawing.Size(185, 210);
			this.prmPermissions.TabIndex = 34;
			// 
			// lbCustBusiness
			// 
			this.lbCustBusiness.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.lbCustBusiness.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lbCustBusiness.Location = new System.Drawing.Point(60, 175);
			this.lbCustBusiness.Name = "lbCustBusiness";
			this.lbCustBusiness.Size = new System.Drawing.Size(140, 20);
			this.lbCustBusiness.TabIndex = 18;
			// 
			// label23
			// 
			this.label23.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.label23.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label23.Location = new System.Drawing.Point(5, 155);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(40, 15);
			this.label23.TabIndex = 10;
			this.label23.Text = "Email";
			// 
			// label24
			// 
			this.label24.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.label24.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label24.Location = new System.Drawing.Point(5, 135);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(40, 15);
			this.label24.TabIndex = 9;
			this.label24.Text = "Fax";
			// 
			// label25
			// 
			this.label25.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.label25.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label25.Location = new System.Drawing.Point(5, 115);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(40, 15);
			this.label25.TabIndex = 8;
			this.label25.Text = "Phone";
			// 
			// chbMail1
			// 
			this.chbMail1.Enabled = false;
			this.chbMail1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.chbMail1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chbMail1.Location = new System.Drawing.Point(160, 260);
			this.chbMail1.Name = "chbMail1";
			this.chbMail1.Size = new System.Drawing.Size(45, 15);
			this.chbMail1.TabIndex = 3;
			this.chbMail1.Text = "Mail";
			// 
			// chbEmail1
			// 
			this.chbEmail1.Enabled = false;
			this.chbEmail1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.chbEmail1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chbEmail1.Location = new System.Drawing.Point(105, 260);
			this.chbEmail1.Name = "chbEmail1";
			this.chbEmail1.Size = new System.Drawing.Size(55, 15);
			this.chbEmail1.TabIndex = 2;
			this.chbEmail1.Text = "Email";
			// 
			// chbPhone1
			// 
			this.chbPhone1.Enabled = false;
			this.chbPhone1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.chbPhone1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chbPhone1.Location = new System.Drawing.Point(5, 260);
			this.chbPhone1.Name = "chbPhone1";
			this.chbPhone1.Size = new System.Drawing.Size(55, 15);
			this.chbPhone1.TabIndex = 1;
			this.chbPhone1.Text = "Phone";
			// 
			// chbFax1
			// 
			this.chbFax1.Enabled = false;
			this.chbFax1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.chbFax1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chbFax1.Location = new System.Drawing.Point(60, 260);
			this.chbFax1.Name = "chbFax1";
			this.chbFax1.Size = new System.Drawing.Size(45, 15);
			this.chbFax1.TabIndex = 0;
			this.chbFax1.Text = "Fax";
			// 
			// lbPersonID
			// 
			this.lbPersonID.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.lbPersonID.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lbPersonID.Location = new System.Drawing.Point(215, 295);
			this.lbPersonID.Name = "lbPersonID";
			this.lbPersonID.Size = new System.Drawing.Size(190, 15);
			this.lbPersonID.TabIndex = 26;
			this.lbPersonID.Text = "Person ID";
			// 
			// tpReports
			// 
			this.tpReports.Controls.Add(this.groupBox9);
			this.tpReports.Location = new System.Drawing.Point(19, 4);
			this.tpReports.Name = "tpReports";
			this.tpReports.Size = new System.Drawing.Size(1243, 669);
			this.tpReports.TabIndex = 3;
			this.tpReports.Text = "Reports          ";
			// 
			// groupBox9
			// 
			this.groupBox9.Controls.Add(this.label13);
			this.groupBox9.Controls.Add(this.bRestorePicture);
			this.groupBox9.Controls.Add(this.pnlReportContainer);
			this.groupBox9.Controls.Add(this.bZoomPlus);
			this.groupBox9.Controls.Add(this.bZoomMinus);
			this.groupBox9.Controls.Add(this.bmissedReports);
			this.groupBox9.Controls.Add(this.bprintedReport);
			this.groupBox9.Controls.Add(this.lvReportList);
			this.groupBox9.Controls.Add(this.bClose_otReports);
			this.groupBox9.Controls.Add(this.lvReportPictures);
			this.groupBox9.Controls.Add(this.otOrderReports);
			this.groupBox9.Location = new System.Drawing.Point(0, 0);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new System.Drawing.Size(960, 665);
			this.groupBox9.TabIndex = 3;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "Order/Reports";
			// 
			// label13
			// 
			this.label13.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label13.Location = new System.Drawing.Point(20, 415);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(320, 15);
			this.label13.TabIndex = 11;
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// bRestorePicture
			// 
			this.bRestorePicture.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bRestorePicture.Location = new System.Drawing.Point(755, 640);
			this.bRestorePicture.Name = "bRestorePicture";
			this.bRestorePicture.Size = new System.Drawing.Size(60, 20);
			this.bRestorePicture.TabIndex = 10;
			this.bRestorePicture.Text = "Restore";
			this.bRestorePicture.Click += new System.EventHandler(this.bRestorePicture_Click);
			// 
			// pnlReportContainer
			// 
			this.pnlReportContainer.AutoScroll = true;
			this.pnlReportContainer.Controls.Add(this.pbReportView);
			this.pnlReportContainer.Location = new System.Drawing.Point(365, 205);
			this.pnlReportContainer.Name = "pnlReportContainer";
			this.pnlReportContainer.Size = new System.Drawing.Size(590, 425);
			this.pnlReportContainer.TabIndex = 9;
			// 
			// pbReportView
			// 
			this.pbReportView.BackColor = System.Drawing.Color.White;
			this.pbReportView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pbReportView.Location = new System.Drawing.Point(3, 3);
			this.pbReportView.Name = "pbReportView";
			this.pbReportView.Size = new System.Drawing.Size(585, 420);
			this.pbReportView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pbReportView.TabIndex = 2;
			this.pbReportView.TabStop = false;
			// 
			// bZoomPlus
			// 
			this.bZoomPlus.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bZoomPlus.Location = new System.Drawing.Point(610, 640);
			this.bZoomPlus.Name = "bZoomPlus";
			this.bZoomPlus.Size = new System.Drawing.Size(65, 20);
			this.bZoomPlus.TabIndex = 8;
			this.bZoomPlus.Text = "Zoom(+)";
			this.bZoomPlus.Click += new System.EventHandler(this.bZoomPlus_Click);
			// 
			// bZoomMinus
			// 
			this.bZoomMinus.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bZoomMinus.Location = new System.Drawing.Point(680, 640);
			this.bZoomMinus.Name = "bZoomMinus";
			this.bZoomMinus.Size = new System.Drawing.Size(65, 20);
			this.bZoomMinus.TabIndex = 7;
			this.bZoomMinus.Text = "Zoom(-)";
			this.bZoomMinus.Click += new System.EventHandler(this.bZoomMinus_Click);
			// 
			// bmissedReports
			// 
			this.bmissedReports.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bmissedReports.Location = new System.Drawing.Point(460, 640);
			this.bmissedReports.Name = "bmissedReports";
			this.bmissedReports.Size = new System.Drawing.Size(65, 20);
			this.bmissedReports.TabIndex = 6;
			this.bmissedReports.Text = "Missed";
			this.bmissedReports.Click += new System.EventHandler(this.bmissedReports_Click);
			// 
			// bprintedReport
			// 
			this.bprintedReport.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bprintedReport.Location = new System.Drawing.Point(370, 640);
			this.bprintedReport.Name = "bprintedReport";
			this.bprintedReport.Size = new System.Drawing.Size(80, 20);
			this.bprintedReport.TabIndex = 5;
			this.bprintedReport.Text = "Printed";
			this.bprintedReport.Click += new System.EventHandler(this.bprintedReport_Click);
			// 
			// lvReportList
			// 
			this.lvReportList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11});
			this.lvReportList.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lvReportList.FullRowSelect = true;
			this.lvReportList.GridLines = true;
			this.lvReportList.Location = new System.Drawing.Point(10, 435);
			this.lvReportList.Name = "lvReportList";
			this.lvReportList.Size = new System.Drawing.Size(335, 225);
			this.lvReportList.TabIndex = 4;
			this.lvReportList.UseCompatibleStateImageBehavior = false;
			this.lvReportList.View = System.Windows.Forms.View.Details;
			this.lvReportList.SelectedIndexChanged += new System.EventHandler(this.lvReportList_SelectedIndexChanged);
			this.lvReportList.DoubleClick += new System.EventHandler(this.lvReportList_DoubleClick);
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "New #";
			this.columnHeader7.Width = 105;
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "Old #";
			this.columnHeader8.Width = 105;
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "Type";
			this.columnHeader9.Width = 41;
			// 
			// columnHeader10
			// 
			this.columnHeader10.Text = "Status";
			this.columnHeader10.Width = 73;
			// 
			// columnHeader11
			// 
			this.columnHeader11.Text = "";
			this.columnHeader11.Width = 0;
			// 
			// bClose_otReports
			// 
			this.bClose_otReports.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bClose_otReports.Location = new System.Drawing.Point(865, 640);
			this.bClose_otReports.Name = "bClose_otReports";
			this.bClose_otReports.Size = new System.Drawing.Size(85, 20);
			this.bClose_otReports.TabIndex = 3;
			this.bClose_otReports.Text = "Clear/Exit";
			this.bClose_otReports.Click += new System.EventHandler(this.bClose_otReports_Click);
			// 
			// lvReportPictures
			// 
			this.lvReportPictures.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lvReportPictures.LabelWrap = false;
			this.lvReportPictures.LargeImageList = this.imageReportsList;
			this.lvReportPictures.Location = new System.Drawing.Point(365, 20);
			this.lvReportPictures.MultiSelect = false;
			this.lvReportPictures.Name = "lvReportPictures";
			this.lvReportPictures.Size = new System.Drawing.Size(590, 175);
			this.lvReportPictures.TabIndex = 1;
			this.lvReportPictures.UseCompatibleStateImageBehavior = false;
			this.lvReportPictures.SelectedIndexChanged += new System.EventHandler(this.lvReportPictures_SelectedIndexChanged);
			// 
			// imageReportsList
			// 
			this.imageReportsList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.imageReportsList.ImageSize = new System.Drawing.Size(100, 80);
			this.imageReportsList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// otOrderReports
			// 
			this.otOrderReports.CheckBoxes = true;
			this.otOrderReports.IsDocumentGhost = false;
			this.otOrderReports.IsExpand = false;
			this.otOrderReports.Location = new System.Drawing.Point(10, 15);
			this.otOrderReports.Name = "otOrderReports";
			this.otOrderReports.Selected = null;
			this.otOrderReports.ShowColorAndClarity = true;
			this.otOrderReports.Size = new System.Drawing.Size(345, 390);
			this.otOrderReports.TabIndex = 0;
			this.otOrderReports.Tag = "";
			this.otOrderReports.SelectedItemChanged += new System.EventHandler(this.otOrderReports_SelectedItemChanged);
			this.otOrderReports.RealDoubleClick += new System.EventHandler(this.otOrderReports_RealDoubleClick);
			// 
			// tpDelivery
			// 
			this.tpDelivery.Controls.Add(this.label20);
			this.tpDelivery.Controls.Add(this.cbCarrier);
			this.tpDelivery.Controls.Add(this.bOrdersForDelivery);
			this.tpDelivery.Controls.Add(this.label19);
			this.tpDelivery.Controls.Add(this.cbMessenger);
			this.tpDelivery.Controls.Add(this.label18);
			this.tpDelivery.Controls.Add(this.bAddOrderToList);
			this.tpDelivery.Controls.Add(this.tbOrderToDelivery);
			this.tpDelivery.Controls.Add(this.dgOrdersToDelivery);
			this.tpDelivery.Controls.Add(this.label17);
			this.tpDelivery.Controls.Add(this.bPrintDeliveryReport);
			this.tpDelivery.Controls.Add(this.otDelivery);
			this.tpDelivery.Location = new System.Drawing.Point(19, 4);
			this.tpDelivery.Name = "tpDelivery";
			this.tpDelivery.Size = new System.Drawing.Size(1243, 669);
			this.tpDelivery.TabIndex = 4;
			this.tpDelivery.Text = "Orders for Delivery     ";
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(560, 520);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(80, 16);
			this.label20.TabIndex = 12;
			this.label20.Text = "Carrier";
			// 
			// cbCarrier
			// 
			this.cbCarrier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCarrier.Location = new System.Drawing.Point(656, 512);
			this.cbCarrier.Name = "cbCarrier";
			this.cbCarrier.Size = new System.Drawing.Size(272, 20);
			this.cbCarrier.TabIndex = 11;
			// 
			// bOrdersForDelivery
			// 
			this.bOrdersForDelivery.Location = new System.Drawing.Point(640, 400);
			this.bOrdersForDelivery.Name = "bOrdersForDelivery";
			this.bOrdersForDelivery.Size = new System.Drawing.Size(232, 24);
			this.bOrdersForDelivery.TabIndex = 10;
			this.bOrdersForDelivery.Text = "Collect Orders for Delivery";
			this.bOrdersForDelivery.Click += new System.EventHandler(this.bOrdersForDelivery_Click);
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(560, 472);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(88, 16);
			this.label19.TabIndex = 9;
			this.label19.Text = "Messenger";
			this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cbMessenger
			// 
			this.cbMessenger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbMessenger.Location = new System.Drawing.Point(656, 464);
			this.cbMessenger.Name = "cbMessenger";
			this.cbMessenger.Size = new System.Drawing.Size(272, 20);
			this.cbMessenger.TabIndex = 8;
			this.cbMessenger.SelectedIndexChanged += new System.EventHandler(this.cbMessenger_SelectedIndexChanged);
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(480, 40);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(80, 16);
			this.label18.TabIndex = 7;
			this.label18.Text = "Order #";
			// 
			// bAddOrderToList
			// 
			this.bAddOrderToList.Location = new System.Drawing.Point(784, 88);
			this.bAddOrderToList.Name = "bAddOrderToList";
			this.bAddOrderToList.Size = new System.Drawing.Size(136, 24);
			this.bAddOrderToList.TabIndex = 6;
			this.bAddOrderToList.Text = "View Details";
			this.bAddOrderToList.Click += new System.EventHandler(this.bAddOrderToList_Click);
			// 
			// tbOrderToDelivery
			// 
			this.tbOrderToDelivery.Location = new System.Drawing.Point(576, 40);
			this.tbOrderToDelivery.Name = "tbOrderToDelivery";
			this.tbOrderToDelivery.Size = new System.Drawing.Size(152, 20);
			this.tbOrderToDelivery.TabIndex = 5;
			this.tbOrderToDelivery.TextChanged += new System.EventHandler(this.tbOrderToDelivery_TextChanged);
			this.tbOrderToDelivery.Enter += new System.EventHandler(this.tbOrderToDelivery_Enter);
			this.tbOrderToDelivery.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbOrderToDelivery_KeyDown);
			this.tbOrderToDelivery.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbOrderToDelivery_KeyPress);
			// 
			// dgOrdersToDelivery
			// 
			this.dgOrdersToDelivery.AllowNavigation = false;
			this.dgOrdersToDelivery.AllowSorting = false;
			this.dgOrdersToDelivery.CaptionFont = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgOrdersToDelivery.CaptionVisible = false;
			this.dgOrdersToDelivery.DataMember = "";
			this.dgOrdersToDelivery.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgOrdersToDelivery.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgOrdersToDelivery.Location = new System.Drawing.Point(472, 128);
			this.dgOrdersToDelivery.Name = "dgOrdersToDelivery";
			this.dgOrdersToDelivery.ParentRowsVisible = false;
			this.dgOrdersToDelivery.Size = new System.Drawing.Size(480, 240);
			this.dgOrdersToDelivery.TabIndex = 4;
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(488, 88);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(264, 24);
			this.label17.TabIndex = 3;
			this.label17.Text = "Order\'s List Summary";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// bPrintDeliveryReport
			// 
			this.bPrintDeliveryReport.Location = new System.Drawing.Point(152, 584);
			this.bPrintDeliveryReport.Name = "bPrintDeliveryReport";
			this.bPrintDeliveryReport.Size = new System.Drawing.Size(208, 24);
			this.bPrintDeliveryReport.TabIndex = 2;
			this.bPrintDeliveryReport.Text = "Delivery Manifest";
			// 
			// otDelivery
			// 
			this.otDelivery.CheckBoxes = true;
			this.otDelivery.IsDocumentGhost = false;
			this.otDelivery.IsExpand = false;
			this.otDelivery.Location = new System.Drawing.Point(16, 16);
			this.otDelivery.Name = "otDelivery";
			this.otDelivery.Selected = null;
			this.otDelivery.ShowColorAndClarity = true;
			this.otDelivery.Size = new System.Drawing.Size(440, 544);
			this.otDelivery.TabIndex = 0;
			// 
			// tpBlockParts
			// 
			this.tpBlockParts.BackColor = System.Drawing.SystemColors.Control;
			this.tpBlockParts.Controls.Add(this.cmd_Reset);
			this.tpBlockParts.Controls.Add(this.label22);
			this.tpBlockParts.Controls.Add(this.cbCustomerProgram);
			this.tpBlockParts.Controls.Add(this.partView);
			this.tpBlockParts.Controls.Add(this.lvBatchesToBlock);
			this.tpBlockParts.Controls.Add(this.button6);
			this.tpBlockParts.Controls.Add(this.button5);
			this.tpBlockParts.Controls.Add(this.cmd_ClearBlockPart);
			this.tpBlockParts.Controls.Add(this.lblStructure);
			this.tpBlockParts.Location = new System.Drawing.Point(19, 4);
			this.tpBlockParts.Name = "tpBlockParts";
			this.tpBlockParts.Size = new System.Drawing.Size(1243, 669);
			this.tpBlockParts.TabIndex = 5;
			this.tpBlockParts.Text = "Blocked Parts";
			// 
			// cmd_Reset
			// 
			this.cmd_Reset.Location = new System.Drawing.Point(1037, 472);
			this.cmd_Reset.Name = "cmd_Reset";
			this.cmd_Reset.Size = new System.Drawing.Size(120, 25);
			this.cmd_Reset.TabIndex = 11;
			this.cmd_Reset.Text = "Reset";
			this.cmd_Reset.UseVisualStyleBackColor = true;
			this.cmd_Reset.Click += new System.EventHandler(this.cmd_Reset_Click);
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(896, 47);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(289, 22);
			this.label22.TabIndex = 10;
			// 
			// cbCustomerProgram
			// 
			this.cbCustomerProgram.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbCustomerProgram.FormattingEnabled = true;
			this.cbCustomerProgram.Location = new System.Drawing.Point(898, 360);
			this.cbCustomerProgram.Name = "cbCustomerProgram";
			this.cbCustomerProgram.Size = new System.Drawing.Size(287, 21);
			this.cbCustomerProgram.TabIndex = 9;
			this.cbCustomerProgram.Click += new System.EventHandler(this.cbCustomerProgram_Click);
			// 
			// partView
			// 
			this.partView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.partView.Location = new System.Drawing.Point(898, 113);
			this.partView.Name = "partView";
			this.partView.Size = new System.Drawing.Size(290, 225);
			this.partView.TabIndex = 8;
			// 
			// lvBatchesToBlock
			// 
			this.lvBatchesToBlock.AllowColumnReorder = true;
			this.lvBatchesToBlock.CheckBoxes = true;
			this.lvBatchesToBlock.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader13,
            this.FullBatchCode,
            this.myBatchID,
            this.CPID,
            this.SKU_Name,
            this.itemTypeID,
            this.itemStructure,
            this.myPartID,
            this.blockedPartName,
            this.FullBlockedPartName,
            this.copyOfBlockedParts});
			this.lvBatchesToBlock.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lvBatchesToBlock.FullRowSelect = true;
			this.lvBatchesToBlock.GridLines = true;
			this.lvBatchesToBlock.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvBatchesToBlock.Location = new System.Drawing.Point(28, 47);
			this.lvBatchesToBlock.Name = "lvBatchesToBlock";
			this.lvBatchesToBlock.Size = new System.Drawing.Size(779, 599);
			this.lvBatchesToBlock.TabIndex = 7;
			this.lvBatchesToBlock.UseCompatibleStateImageBehavior = false;
			this.lvBatchesToBlock.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader13
			// 
			this.columnHeader13.Text = "";
			this.columnHeader13.Width = 20;
			// 
			// FullBatchCode
			// 
			this.FullBatchCode.DisplayIndex = 2;
			this.FullBatchCode.Text = "Batch";
			this.FullBatchCode.Width = 96;
			// 
			// myBatchID
			// 
			this.myBatchID.DisplayIndex = 1;
			this.myBatchID.Text = "";
			this.myBatchID.Width = 0;
			// 
			// CPID
			// 
			this.CPID.Text = "";
			this.CPID.Width = 0;
			// 
			// SKU_Name
			// 
			this.SKU_Name.Text = "SKU";
			this.SKU_Name.Width = 176;
			// 
			// itemTypeID
			// 
			this.itemTypeID.Text = "";
			this.itemTypeID.Width = 0;
			// 
			// itemStructure
			// 
			this.itemStructure.Text = "Structure";
			this.itemStructure.Width = 100;
			// 
			// myPartID
			// 
			this.myPartID.DisplayIndex = 8;
			this.myPartID.Width = 0;
			// 
			// blockedPartName
			// 
			this.blockedPartName.DisplayIndex = 7;
			this.blockedPartName.Text = "ColumnHeader";
			this.blockedPartName.Width = 0;
			// 
			// FullBlockedPartName
			// 
			this.FullBlockedPartName.Text = "Blocked Parts";
			this.FullBlockedPartName.Width = 367;
			// 
			// copyOfBlockedParts
			// 
			this.copyOfBlockedParts.Width = 0;
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(1037, 433);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(120, 25);
			this.button6.TabIndex = 6;
			this.button6.Text = "Save";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(898, 433);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(120, 25);
			this.button5.TabIndex = 5;
			this.button5.Text = "Save Bulk";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// cmd_ClearBlockPart
			// 
			this.cmd_ClearBlockPart.Location = new System.Drawing.Point(898, 472);
			this.cmd_ClearBlockPart.Name = "cmd_ClearBlockPart";
			this.cmd_ClearBlockPart.Size = new System.Drawing.Size(120, 25);
			this.cmd_ClearBlockPart.TabIndex = 4;
			this.cmd_ClearBlockPart.Text = "Clear";
			this.cmd_ClearBlockPart.UseVisualStyleBackColor = true;
			this.cmd_ClearBlockPart.Click += new System.EventHandler(this.cmd_ClearBlockPart_Click);
			// 
			// lblStructure
			// 
			this.lblStructure.Location = new System.Drawing.Point(899, 88);
			this.lblStructure.Name = "lblStructure";
			this.lblStructure.Size = new System.Drawing.Size(289, 22);
			this.lblStructure.TabIndex = 3;
			// 
			// itemN
			// 
			this.itemN.Text = "#";
			this.itemN.Width = 27;
			// 
			// firstName
			// 
			this.firstName.Text = "First Name";
			this.firstName.Width = 90;
			// 
			// lastName
			// 
			this.lastName.Text = "Last Name";
			this.lastName.Width = 86;
			// 
			// position
			// 
			this.position.Text = "Position";
			this.position.Width = 64;
			// 
			// phonePersonN
			// 
			this.phonePersonN.Text = "Phone";
			this.phonePersonN.Width = 61;
			// 
			// faxPersonN
			// 
			this.faxPersonN.Text = "Fax";
			this.faxPersonN.Width = 80;
			// 
			// cellPersonN
			// 
			this.cellPersonN.Text = "Cell";
			this.cellPersonN.Width = 79;
			// 
			// sbStatus
			// 
			this.sbStatus.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.sbStatus.Location = new System.Drawing.Point(0, 703);
			this.sbStatus.Name = "sbStatus";
			this.sbStatus.Size = new System.Drawing.Size(1283, 15);
			this.sbStatus.TabIndex = 13;
			this.sbStatus.Text = "Ready";
			// 
			// tbSearchUnit
			// 
			this.tbSearchUnit.AcceptsReturn = true;
			this.tbSearchUnit.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.tbSearchUnit.Location = new System.Drawing.Point(720, 5);
			this.tbSearchUnit.MaxLength = 18;
			this.tbSearchUnit.Name = "tbSearchUnit";
			this.tbSearchUnit.Size = new System.Drawing.Size(155, 20);
			this.tbSearchUnit.TabIndex = 32;
			this.tbSearchUnit.Enter += new System.EventHandler(this.tbSearchUnit_Enter);
			this.tbSearchUnit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSearchUnit_KeyDown);
			this.tbSearchUnit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSearchUnit_KeyPress);
			// 
			// bSearch
			// 
			this.bSearch.Location = new System.Drawing.Point(890, 3);
			this.bSearch.Name = "bSearch";
			this.bSearch.Size = new System.Drawing.Size(55, 23);
			this.bSearch.TabIndex = 33;
			this.bSearch.Text = "&Search";
			this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
			// 
			// tbMemoNumber
			// 
			this.tbMemoNumber.Location = new System.Drawing.Point(475, 5);
			this.tbMemoNumber.Name = "tbMemoNumber";
			this.tbMemoNumber.Size = new System.Drawing.Size(155, 20);
			this.tbMemoNumber.TabIndex = 34;
			this.tbMemoNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbMemoNumber_KeyDown);
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(430, 5);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(40, 20);
			this.label9.TabIndex = 35;
			this.label9.Text = "Memo";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(650, 5);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(60, 20);
			this.label10.TabIndex = 36;
			this.label10.Text = "Order/Item";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lvServices
			// 
			this.lvServices.CheckBoxes = true;
			this.lvServices.FullRowSelect = true;
			this.lvServices.GridLines = true;
			this.lvServices.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvServices.Location = new System.Drawing.Point(465, 44);
			this.lvServices.MultiSelect = false;
			this.lvServices.Name = "lvServices";
			this.lvServices.Size = new System.Drawing.Size(253, 368);
			this.lvServices.TabIndex = 36;
			this.lvServices.UseCompatibleStateImageBehavior = false;
			this.lvServices.View = System.Windows.Forms.View.Details;
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.ForeColor = System.Drawing.Color.Black;
			this.radioButton1.Location = new System.Drawing.Point(43, 19);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(96, 20);
			this.radioButton1.TabIndex = 35;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "radioButton1";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// radioButton3
			// 
			this.radioButton3.ForeColor = System.Drawing.Color.Black;
			this.radioButton3.Location = new System.Drawing.Point(43, 73);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(96, 20);
			this.radioButton3.TabIndex = 37;
			this.radioButton3.TabStop = true;
			this.radioButton3.Text = "Tally";
			this.radioButton3.UseVisualStyleBackColor = true;
			// 
			// label26
			// 
			this.label26.Location = new System.Drawing.Point(641, 75);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(289, 35);
			this.label26.TabIndex = 3;
			this.label26.Text = "label26";
			// 
			// cbcCustomer
			// 
			this.cbcCustomer.DefaultText = "Customer Lookup";
			this.cbcCustomer.DisplayMember = "CustomerName";
			this.cbcCustomer.InsertDefaultRow = true;
			this.cbcCustomer.Location = new System.Drawing.Point(25, 5);
			this.cbcCustomer.Name = "cbcCustomer";
			this.cbcCustomer.SelectedCode = "";
			this.cbcCustomer.Size = new System.Drawing.Size(400, 20);
			this.cbcCustomer.TabIndex = 15;
			this.cbcCustomer.ValueMember = "CustomerOfficeID_CustomerID";
			this.cbcCustomer.SelectionChanged += new System.EventHandler(this.cbcCustomer_SelectedIndexChanged);
			this.cbcCustomer.Load += new System.EventHandler(this.cbcCustomer_Load);
			this.cbcCustomer.Enter += new System.EventHandler(this.cbcCustomer_Enter);
			this.cbcCustomer.Leave += new System.EventHandler(this.ControlFocusLeave);
			// 
			// AccountRep
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1283, 718);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.bSearch);
			this.Controls.Add(this.tbSearchUnit);
			this.Controls.Add(this.tbMemoNumber);
			this.Controls.Add(this.cbcCustomer);
			this.Controls.Add(this.tcMain);
			this.Controls.Add(this.sbStatus);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.Name = "AccountRep";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Account Representative";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AccountRep_KeyDown);
			this.tcMain.ResumeLayout(false);
			this.tpCustomer.ResumeLayout(false);
			this.gbOrdersHistory.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.tpOrders.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.gbBilling.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.groupBox7.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox8.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbShape)).EndInit();
			this.groupBox11.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.groupBox5.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.tpUpdate.ResumeLayout(false);
			this.tpUpdate.PerformLayout();
			this.groupBox16.ResumeLayout(false);
			this.groupBox15.ResumeLayout(false);
			this.groupBox13.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.groupBox14.ResumeLayout(false);
			this.groupBox10.ResumeLayout(false);
			this.groupBox12.ResumeLayout(false);
			this.tpReports.ResumeLayout(false);
			this.groupBox9.ResumeLayout(false);
			this.pnlReportContainer.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbReportView)).EndInit();
			this.tpDelivery.ResumeLayout(false);
			this.tpDelivery.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgOrdersToDelivery)).EndInit();
			this.tpBlockParts.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
//		[STAThread]
//		public static void Main()
//		{
//			Application.Run(new AccountRep());
//		}
		

		private void cbcCustomer_SelectedIndexChanged(object sender, System.EventArgs e)
		{			
			CClear();
			DataTable dt = ((DataTable)cbCustPersons.DataSource);
			if (dt != null)
				dt.Rows.Clear();
			dt = ((DataTable)cbPersons.DataSource);
			if (dt != null)
				dt.Rows.Clear();

			if(cbcCustomer.SelectedCode.ToString() == "0") return;
			{
//				otAllOrders.Clear();
//				otClosed.Clear();
//				otOpenOrders.Clear();
//				lbxItems.Items.Clear();
//				ptrOps.Clear();
//				lvProps.Items.Clear();
//				lbMemo.Text = "";
//				pbShape.Image = null;
//				pictureBox2.Image = null;
//				lbNOpenBatches.Text = "";
//				lbNOpenItems.Text = "";
//				lbNOpenOrders.Text = "";
//				liPersons.Items.Clear();
//				lbCompany.Text = "";
//				lbAddress.Text = "";
//				lbBusiness.Text = "";
//				lbCompany.Text = "";
//				lbCustAddr.Text = "";
//				lbCustBusiness.Text = "";
//				lbCustComp.Text = "";
//				lbEmail.Text = "";
//				lbFax.Text = "";
//				lbOtherDetails.Text = "";
//				lbPersonID.Text = "";
//				lbPhone.Text = "";
//				lbPhoneExt.Text = "";
//				lbxIndustry.Items.Clear();
//				lbxIndustry2.Items.Clear();
//				chbEmail.Checked = false;
//				chbEmail1.Checked = false;
//				chbFax.Checked = false;
//				chbFax1.Checked = false;
//				chbMail.Checked = false;
//				chbMail1.Checked = false;
//				chbPhone.Checked = false;
//				chbPhone1.Checked = false;
//				lvDocs.Items.Clear();
//				tbOrderName.Text = "#####.#####";
//				tbItemName.Text = "#####.#####.###.##";
//				pnlDetails.Controls.Clear();
//				tbMemoNumber.Clear();
//				lvMigratedItemData.Visible = false;
//				for(int i = 0; i < prmPermissions.achbPermissions.Length; i++)
//					prmPermissions.achbPermissions[i].Checked = false;
//
//				DataTable dt = ((DataTable)cbCustPersons.DataSource);
//				if (dt != null)
//					dt.Rows.Clear();
//				dt = ((DataTable)cbPersons.DataSource);
//				if (dt != null)
//					dt.Rows.Clear();
//				return;
			}
			this.Cursor = Cursors.WaitCursor;
//			otAllOrders.Clear();
//			otClosed.Clear();
//			otOpenOrders.Clear();
//			this.lbxItems.Items.Clear();
//			tbSearchUnit.Text = "";
//			lvProps.Items.Clear();
//			pbShape.Image = null;
//			pictureBox2.Image = null;

			DataSet dsTemp = new DataSet();
			DataTable dtTemp = dsCustomerTypeEx.Tables[0].Copy();
			dsTemp.Tables.Add(dtTemp);
			dsTemp.Tables[0].TableName = "CustomerType";
			dsTemp.Tables[0].Rows.Add(new object[] {cbcCustomer.ComboField.drvSelectedItem[cbcCustomer.ValueMember], null, null});
				
			DataSet dsCustomerInfo = new DataSet();
			dsCustomerInfo.Tables.Add(dsTemp.Tables["CustomerType"].Copy());
			dsCustomerInfo.Tables[0].TableName = "Customer";

			try
			{
				dtCustomer = Service.GetCustomerType(dsCustomerInfo).Tables[0];//Procedure dbo.spGetCustomer
			}
			catch
			{
				MessageBox.Show("Unable to get data from server", "Internal error", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				this.Close();				
			}

		{
			DataSet dsPersons = Service.GetPersonsByCustomer(dsCustomerInfo);//Procedure dbo.spGetPersonsByCustomer
			dtPerson = dsPersons.Tables[0].Copy();
			cbCustPersons.DataSource = dtPerson;
			cbCustPersons.DisplayMember = "LastName"; 
			cbCustPersons.ValueMember = "PersonCode";
			cbCustPersons.Update();

			dtPerson.Columns.Add("LastName_Position");
			string pos;
			foreach(DataRow dr in dtPerson.Rows)
			{
				pos = dtPositions.Select("PositionID=" + dr["PositionID"].ToString())[0]["PositionName"].ToString();
				dr["LastName_Position"] = dr["LastName"].ToString() + " - " + pos;
			}

			cbPersons.DataSource = dtPerson.Copy();
			cbPersons.DisplayMember = "LastName_Position"; 
			cbPersons.ValueMember = "PersonCode";
			cbPersons.Update();
		}

			tcMain.Enabled = true;
			FillCustomer();
			FillPersons();
			try
			{
				if(!isSelectItem)
				{
					DrawOpen(); //Fill order tree
				}
				isSelectItem = false;
				lbNOpenOrders.Text = otOpenOrders.dsOrderTree.Tables["tblOrder"].Rows.Count.ToString();
				lbNOpenBatches.Text = otOpenOrders.dsOrderTree.Tables["tblBatch"].Rows.Count.ToString();
				lbNOpenItems.Text = otOpenOrders.dsOrderTree.Tables["tblItem"].Rows.Count.ToString();
			}
			catch
			{
				sbStatus.Text = "Time out/No open orders were found for this customer";
			}
			if (dtCustomer.Rows.Count > 0)
			{
				Service.SetDepartmentOfficeId(dtCustomer.Rows[0]["CustomerOfficeID"].ToString());
				//var busiNessType = dtCustomer.Rows[0]["BusinessTypeID"].ToString();
				//var customerOfficeID = cbcCustomer.SelectedID.Split('_')[0].ToString();
				//if (busiNessType == "8") rbQBcorpt.Checked = true;
				//else
				//{
				//	if (customerOfficeID == "1") rbQBprimary.Checked = true;
				//	else rbTally.Checked = true;
				//}
			}
			this.Cursor = Cursors.Default;
		}

		
		#region PrimaryDataFilling
		//Customer lookup init
		public void InitCustomers()
		{
			pbShape.Parent = pnlShapeContainer;
			pbShape.Top = 0;
			pbShape.Left = 0;
			try
			{
				DataTable dtCustomers = Service.GetCustomers().Tables[0];
				cbcCustomer.Initialize(dtCustomers);
				dsAvailableOps = Service.GetDocs();
			}
			catch
			{
				MessageBox.Show("Unable to connect to database", "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.Close();
			}
		}


		private void InitGlobal()
		{
			myActiveOrder = "";
			isLoaded = true;
			lvBatchesToBlock.Items.Clear();
			tbMemoNumber.Clear();
			this.Text = Service.sProgramTitle + "Account Representative";
			dtDocDetails = new DataTable();
			dtDocDetails.Columns.Add("ItemCode");
			dtDocDetails.Columns.Add("DocID");
			dtDocDetails.Columns.Add("LabelText");

			dsCustomerTypeEx = Service.GetCustomerTypeEx();					

			dtCarrier = dsCustomerTypeEx.Tables["Carriers"].Copy();
			dtCustBiz = dsCustomerTypeEx.Tables["BusinessTypes"].Copy();
			dtCustInd = dsCustomerTypeEx.Tables["IndustryMemberships"].Copy();
			dtStates = dsCustomerTypeEx.Tables["USStates"].Copy();
			dtPositions = dsCustomerTypeEx.Tables["Positions"].Copy();

			cmd_Reset.Enabled = false;

			for(int i = 1; i < dsCustomerTypeEx.Tables.Count; i++)
				dsCustomerTypeEx.Tables.RemoveAt(i);
		}

		private void FillCustomer()
		{
			string stateName=String.Empty;
			try
			{
				stateName = dtStates.Select("USStateID=" + dtCustomer.Rows[0]["USStateID"])[0]["USStateName"].ToString();
			}
			catch
			{}

			lbCustComp.Text = lbCompany.Text = dtCustomer.Rows[0]["CompanyName"].ToString();
			if(stateName == String.Empty)
			{
				lbCustAddr.Text = lbAddress.Text = dtCustomer.Rows[0]["Address1"].ToString() + ", " +
					dtCustomer.Rows[0]["Address2"].ToString() + ",\n" +
					dtCustomer.Rows[0]["City"].ToString() + ", " + dtCustomer.Rows[0]["Country"].ToString() + ",\n" +
					FillToFiveChars(dtCustomer.Rows[0]["Zip1"].ToString());
			}
			else
			{
				lbCustAddr.Text = lbAddress.Text = dtCustomer.Rows[0]["Address1"].ToString() + ", " +
					dtCustomer.Rows[0]["Address2"].ToString() + ",\n" +
					dtCustomer.Rows[0]["City"].ToString() + ", " + 
					stateName + ", " + dtCustomer.Rows[0]["Country"].ToString() + ",\n" +
					FillToFiveChars(dtCustomer.Rows[0]["Zip1"].ToString());
			}
			if(dtCustomer.Rows[0]["Zip1"].ToString() != "")
			{
				lbCustAddr.Text += "- ";
				lbAddress.Text += "- ";
			}

			lbCustAddr.Text += dtCustomer.Rows[0]["Zip2"].ToString();
			lbAddress.Text += dtCustomer.Rows[0]["Zip2"].ToString();
            try
            {
                lbCustPhone.Text = lbPhone.Text = dtCustomer.Rows[0]["CountryPhoneCode"].ToString() + '-' +
                    dtCustomer.Rows[0]["Phone"].ToString().Substring(0, 3) + '-' +
                    dtCustomer.Rows[0]["Phone"].ToString().Substring(3, 3) + '-' +
                    dtCustomer.Rows[0]["Phone"].ToString().Substring(6, dtCustomer.Rows[0]["Phone"].ToString().Length - 6);
            }
            catch { }
            try
            {
                if (dtCustomer.Rows[0]["Fax"].ToString().Length > 0)
                {
                    lbCustFax.Text = lbFax.Text = dtCustomer.Rows[0]["CountryPhoneCode"].ToString() + '-' +
                        dtCustomer.Rows[0]["Fax"].ToString().Substring(0, 3) + '-' +
                        dtCustomer.Rows[0]["Fax"].ToString().Substring(3, 3) + '-' +
                        dtCustomer.Rows[0]["Fax"].ToString().Substring(6, dtCustomer.Rows[0]["Fax"].ToString().Length - 6);
                }
            }
            catch { }
			lbCustEmail.Text = lbEmail.Text = dtCustomer.Rows[0]["Email"].ToString();

			//Business Type
			lbCustBusiness.Text = lbBusiness.Text = dtCustBiz.Select("BusinessTypeID=" + 
				dtCustomer.Rows[0]["BusinessTypeID"].ToString())[0]["BusinessTypeName"].ToString();

			//Industry Membership
			DataRow dr;
			lbxIndustry.Items.Clear();
			lbxIndustry2.Items.Clear();
			for(int i = 0; i < dtCustomer.Rows[0]["IndustryMembership"].ToString().Length; i++)
			{
				char ch = Convert.ToChar(dtCustomer.Rows[0]["IndustryMembership"].ToString().Substring(i, 1));				
				try
				{
					Convert.ToInt32(ch);
					dr = dtCustInd.Select("IndustryMembershipID=" + ch)[0];
					string Name = dr["IndustryMembershipName"].ToString();
					lbxIndustry.Items.Add(Name);
					lbxIndustry2.Items.Add(Name);
				}
				catch
				{
					continue;
				}								
			}

			//Communication
			CommunicationInit(dtCustomer.Rows[0]["Communication"].ToString());			
			

			//Permissions
			//PermInit(dtCustomer.Rows[0]["Permission"].ToString(), prmPermissions);				
		}

		private void FillPersons()
		{
			liPersons.Items.Clear();
			if(dtPerson!=null)
			{
				for(int i = 0; i < dtPerson.Rows.Count; i++)
				{
					ListViewItem lviItem = new ListViewItem(i.ToString());
					lviItem.SubItems.Add(dtPerson.Rows[i]["FirstName"].ToString());
					lviItem.SubItems.Add(dtPerson.Rows[i]["LastName"].ToString());
					try
					{
						lviItem.SubItems.Add(dtPerson.Rows[i]["PositionName"].ToString());
					}
					catch(Exception exc)
					{
						Console.WriteLine(exc.Message);
					}

					lviItem.SubItems.Add(dtPerson.Rows[i]["CountryPhoneCode"].ToString() + dtPerson.Rows[i]["Phone"].ToString());

					try
					{
						lviItem.SubItems.Add(dtPerson.Rows[i]["CountryFaxCode"].ToString() + dtPerson.Rows[i]["Fax"].ToString());
					}
					catch(Exception exc)
					{
						Console.WriteLine(exc.Message);
					}

					try
					{
						lviItem.SubItems.Add(dtPerson.Rows[i]["CountryCellCode"].ToString() + 
							dtPerson.Rows[i]["Cell"].ToString());
					}
					catch(Exception exc)
					{
						Console.WriteLine(exc.Message);
					}

					lviItem.SubItems.Add(dtPerson.Rows[i]["Email"].ToString());
					liPersons.Items.Add(lviItem);
				}
			}			
		}
		
		private void cbCustPersons_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lbPhoneExt.Text = "";
			PermInit(dtPerson.Rows[cbCustPersons.SelectedIndex]["Permission"].ToString(), prmPermissions);
			lbPersonID.Text = "Person ID:	" + dtPerson.Rows[cbCustPersons.SelectedIndex]["PersonCode"].ToString();
			lbPhoneExt.Text = "Ph.: " + dtPerson.Rows[cbCustPersons.SelectedIndex]["CountryPhoneCode"].ToString() + '-' +
				dtPerson.Rows[cbCustPersons.SelectedIndex]["Phone"].ToString() + 
				".Ext. " + dtPerson.Rows[cbCustPersons.SelectedIndex]["ExtPhone"].ToString();
		}	

		private void DrawOpen()
		{
			Couple cplCustomer = new Couple();
			Couple cplState = new Couple();
			cplCustomer.FieldName = "CustomerCode";
			cplCustomer.FieldValue = cbcCustomer.ComboField.drvSelectedItem[cbcCustomer.CodeMember].ToString();
			cplState.FieldName = "BGroupState";
			cplState.FieldValue = "2";
			//Code below calls procedures dbo.spGetGroupByCode, dbo.spGetBatchByCode, dbo.spGetItemByCode, dbo.spGetItemDocByCode, dbo.spGetStates
			otOpenOrders.Initialize(Service.GetOrderTreeDataByCode(new Couple[] {cplCustomer, cplState}));
			otOpenOrders.Update();
			if (otOpenOrders.dsOrderTree != null)
				tcMain.SelectedTab = tcMain.TabPages[1];
		}

		private void FillOrderTreeFromList(object aOrders)
		{
			otDelivery.Initialize(Service.GetOrderTreeDataByCodeFromList(aOrders));
			otDelivery.Update();
		}

		private void InitCustomerData()
		{
			dtCustomer = new DataTable();
			dtCustomer.Columns.Add("ID");
			dtCustomer.Columns.Add("CompanyName");
			dtCustomer.Columns.Add("Address");
			dtCustomer.Columns.Add("Country");
			dtCustomer.Columns.Add("City");
			dtCustomer.Columns.Add("State");
			dtCustomer.Columns.Add("Additional");
			dtCustomer.Columns.Add("Zip1");
			dtCustomer.Columns.Add("Zip2");
			dtCustomer.Columns.Add("Phone");
			dtCustomer.Columns.Add("Fax");
			dtCustomer.Columns.Add("Email");
			dtCustomer.Columns.Add("Mail");
			dtCustomer.Columns.Add("StartDate");
			dtCustomer.Columns.Add("Business");
			dtCustomer.Columns.Add("Industry");
			dtCustomer.Columns.Add("Communication");
			dtCustomer.Columns.Add("Permissions");
			dtCustomer.Columns.Add("WeCarry");
			dtCustomer.Columns.Add("TheyCarry");
			dtCustomer.Columns.Add("WeShipCarry");
			dtCustomer.Columns.Add("UseTheirAccount");
			dtCustomer.Columns.Add("Carrier");
			dtCustomer.Columns.Add("Account");

			dtCustomer.Rows.Add(new object[] {"id1",
												 "cmn1",
												 "addr1",
												 "USA",
												 "city1",
												 "stt1",
												 "floor1",
												 "zip1",
												 "zip2",
												 "phn1",
												 "fx1",
												 "eml1",
												 "ml1",
												 "strt1",
												 "bsns1",
												 "JVC",
												 "f1p1m0e0",
												 "0,3,4,5,7",
												 false,
												 true,
												 true,
												 "crr1",
												 "accnt1"});
		}
		

		private void CommunicationInit(string sIni)
		{
			CheckBox chbTemp = null;
			CheckBox chbTemp1 = null;
			int iPos = 0;

			while(iPos < sIni.Length)
			{	
				switch (sIni[iPos])
				{
					case 'p':
						chbTemp = this.chbPhone;
						chbTemp1 = this.chbPhone1;
						break;
					case 'f':
						chbTemp = this.chbFax;
						chbTemp1 = this.chbFax1;
						break;
					case 'e':
						chbTemp = this.chbEmail;
						chbTemp1 = this.chbEmail1;
						break;
					case 'm':
						chbTemp = this.chbMail;
						chbTemp1 = this.chbMail1;
						break;
				}
				chbTemp.Checked = sIni[iPos + 1] == '1' ? true : false;
				chbTemp1.Checked = sIni[iPos + 1] == '1' ? true : false;
				iPos += 2;
			}
		}


		public void InitPersonData()
		{
			dtPerson = new DataTable();
			dtPerson.Columns.Add("ID");
			dtPerson.Columns.Add("FirstName");
			dtPerson.Columns.Add("LastName");
			dtPerson.Columns.Add("Position");
			dtPerson.Columns.Add("StartDate");
			dtPerson.Columns.Add("BirthDate");
			dtPerson.Columns.Add("Phone");
			dtPerson.Columns.Add("Fax");
			dtPerson.Columns.Add("Cell");
			dtPerson.Columns.Add("Email");
			dtPerson.Columns.Add("Country");
			dtPerson.Columns.Add("City"); 
			dtPerson.Columns.Add("Address");
			dtPerson.Columns.Add("Additional");
			dtPerson.Columns.Add("State");
			dtPerson.Columns.Add("Zip1");
			dtPerson.Columns.Add("Zip2");
			dtPerson.Columns.Add("Communication");
			dtPerson.Columns.Add("WebLogin");
			dtPerson.Columns.Add("WebPwd");
			dtPerson.Columns.Add("Picture");
			dtPerson.Columns.Add("Sign");
			dtPerson.Columns.Add("Permissions");

			dtPerson.Rows.Add(new object[] {"id1", "fn1", "ln1", "pos1", "std1", "bd1", "phn1",
											   "fx1", "cll1", "eml1", "cntr1", "ct1", "addr1", "add1", "st1", "zp1", "zp12",
											   "f1p1m0e0", "wlog1", "wpwd1", "pic1", "sgn1", "0,3,4,5,7"});
			dtPerson.Rows.Add(new object[] {"id2", "fn2", "ln2", "pos2", "std2", "bd2", "phn2",
											   "fx2", "cll2", "eml2", "cntr2", "ct2", "addr2", "add2", "st2", "zp2", "zp22",
											   "m1f1e1p0", "wlog2", "wpwd2", "pic2", "sgn2", "0,2,3,4"});	
			dtPerson.Rows.Add(new object[] {"id3", "fn3", "ln3", "pos3", "std3", "bd3", "phn3",
											   "fx3", "cll3", "eml3", "cntr3", "ct3", "addr3", "add3", "st3", "zp3", "zp32",
											   "e1m1p1f1", "wlog3", "wpwd3", "pic3", "sgn3", "0,3,6,7"});
		}
	
		private void PermInit(string sIni, Permissions prmPerm)
		{
			int iPos = 0;
			int iNum = 0;

			for(int i = 0; i < prmPerm.achbPermissions.Length; i++)
				prmPerm.achbPermissions[i].Checked = false;

			while(iPos < sIni.Length)
			{	
				iNum = Convert.ToInt32(sIni.Substring(iPos, 1)) - 1;

				iPos += 2;
				prmPerm.achbPermissions[iNum].Checked = true;
			}
		}

		#endregion PrimaryDataFilling
		

		#region Tab1
		//Tab1/Get closed orders filtered by date from DB
		private void button1_Click(object sender, System.EventArgs e)
		{
			otClosed.Clear();

			Couple cplCustomer = new Couple();
			cplCustomer.FieldName = "CustomerCode";
			cplCustomer.FieldValue = cbcCustomer.ComboField.drvSelectedItem[cbcCustomer.CodeMember].ToString();

			Couple cplStateB = new Couple();
			cplStateB.FieldName = "BGroupState"; 
			cplStateB.FieldValue = "1";

			Couple cplStateE = new Couple();
			cplStateE.FieldName = "EGroupState"; 
			cplStateE.FieldValue = "1";

			if(dtpFrom.Value < dtpTo.Value)
			{
				Couple cplDatesB = new Couple();
				cplDatesB.FieldName = "BDate";
				cplDatesB.FieldValue = dtpFrom.Value.ToString();

				Couple cplDatesE = new Couple();
				cplDatesE.FieldName = "EDate";
				cplDatesE.FieldValue = dtpTo.Value.ToString();

				try
				{
					otClosed.Initialize(Service.GetOrderTreeDataByCode(new Couple[] {cplCustomer, cplDatesB, cplDatesE, cplStateB, cplStateE}));
				}
				catch
				{
					MessageBox.Show("Unable to get data from server", "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				if(dtpFrom.Value.Year == dtpTo.Value.Year && 
					dtpFrom.Value.Month == dtpTo.Value.Month &&
					dtpFrom.Value.Day == dtpTo.Value.Day)
				{
					otClosed.Initialize(Service.GetOrderTreeDataByCode(new Couple[] 
						{cplCustomer, cplStateB, cplStateE}));
				}
				else 
					sbStatus.Text = "Searching start date must be less then end date";
			}				
		}


		//Tab1/DateTimePickers stuff
		private void cbPeriod_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(cbPeriod.SelectedItem.ToString() == "From - To")
			{
				dtpFrom.Enabled = true;				
				dtpTo.Enabled = true;				
			}
			else
			{
				dtpFrom.Enabled = false;				
				dtpTo.Enabled = false;				
			}

			if(cbPeriod.SelectedItem.ToString() == "This Month")
			{
				dtpFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
				dtpTo.Value = DateTime.Now;
			}

			if(cbPeriod.SelectedItem.ToString() == "This Year")
			{
				dtpFrom.Value = new DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0);
				dtpTo.Value = DateTime.Now;
			}

			if(cbPeriod.SelectedItem.ToString() == "Last Month")
			{
				if(DateTime.Now.Month != 1)
				{
					dtpFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1,	1, 0, 0, 0);
					dtpTo.Value = new DateTime(DateTime.Now.Year, 
						DateTime.Now.Month - 1,
						DateTime.DaysInMonth(dtpFrom.Value.Year, dtpFrom.Value.Month), 23, 59, 59);
				}
				else
				{
					dtpFrom.Value = new DateTime(DateTime.Now.Year,	12,	1, 0, 0, 0);
					dtpTo.Value = new DateTime(DateTime.Now.Year,	12,	DateTime.DaysInMonth(dtpFrom.Value.Year, dtpFrom.Value.Month), 23, 59, 59);
				}
			}

			if(cbPeriod.SelectedItem.ToString() == "Last Year")
			{				
				dtpFrom.Value = new DateTime(DateTime.Now.Year - 1, 1, 1, 0, 0, 0);
				dtpTo.Value = new DateTime(DateTime.Now.Year - 1, 12, 31, 23, 59, 59);
			}
		}

		private void dtpFrom_ValueChanged(object sender, System.EventArgs e)
		{
			dtpFrom.Value = new DateTime(dtpFrom.Value.Year, dtpFrom.Value.Month, dtpFrom.Value.Day, 0, 0, 0);
			dtpTo.Value = new DateTime(dtpTo.Value.Year, dtpTo.Value.Month, dtpTo.Value.Day, 23, 59, 59);
		}
		private void dtpTo_ValueChanged(object sender, System.EventArgs e)
		{
			dtpFrom.Value = new DateTime(dtpFrom.Value.Year, dtpFrom.Value.Month, dtpFrom.Value.Day, 0, 0, 0);
			dtpTo.Value = new DateTime(dtpTo.Value.Year, dtpTo.Value.Month, dtpTo.Value.Day, 23, 59, 59);
		}

        
        #region Search
		private void tbSearchUnit_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
            char c = e.KeyChar;
            if(((c >= '0'&& c <= '9') || c== '.'|| c==8 || c==13) && (sender as TextBox).Text.Length <= 20)
            {
                e.Handled = false;
            }
//            else
//            {
//                if(((sender as TextBox).Text.Length==18 ) && c!=13 &&
//                    ((c >='0'&&c<='9')||c=='.'||c==8) && (sender as TextBox).Text =="#####.#####.###.##")
//                {
//                    (sender as TextBox).Text="";
//                    e.Handled=false;
//                }
//                else
//                {
//                    e.Handled=true;
//                }
//            }

//			if(tbSearchUnit.Text.Length > 4)
//			{
//				try
//				{
//                    e.Handled = true;
//					Convert.ToInt64(tbSearchUnit.Text);
//					tbSearchUnit.Text += e.KeyChar.ToString();
//					//tbSearchUnit.Text += "." + tbSearchUnit.Text;
//					tbSearchUnit.SelectionStart = tbSearchUnit.Text.Length;
//					tbSearchUnit.SelectionLength = 0;
//				}
//				catch
//				{
//					MessageBox.Show("Order name must be numeric", "Wrong order name", MessageBoxButtons.OK,
//						MessageBoxIcon.Warning);
//					tbSearchUnit.Clear();
//				}
//			}
//            else e.Handled = nonNumberEntered;

		}

		private void tbSearchUnit_Enter(object sender, System.EventArgs e)
		{
			tbSearchUnit.Clear();
		}
		private void CClear()
		{
			bOrderUpdate.Enabled = false;
			bOrderReports.Enabled = false;
			tbSearchUnit.Text = "";
			label11.Text = "";
			otAllOrders.Clear();
			otClosed.Clear();
			otOpenOrders.Clear();
			otOrderReports.Clear();
			lbxItems.Items.Clear();
			ptrOps.Clear();
			lvProps.Items.Clear();
			lbMemo.Text = "";
			pbShape.Image = null;
			pictureBox2.Image = null;
			lbNOpenBatches.Text = "";
			lbNOpenItems.Text = "";
			lbNOpenOrders.Text = "";
			liPersons.Items.Clear();
			lbCompany.Text = "";
			lbAddress.Text = "";
			lbBusiness.Text = "";
			lbCompany.Text = "";
			lbCustAddr.Text = "";
			lbCustBusiness.Text = "";
			lbCustComp.Text = "";
			lbEmail.Text = "";
			lbFax.Text = "";
			lbOtherDetails.Text = "";
			lbPersonID.Text = "";
			lbPhone.Text = "";
			lbPhoneExt.Text = "";
			lbxIndustry.Items.Clear();
			lbxIndustry2.Items.Clear();
			chbEmail.Checked = false;
			chbEmail1.Checked = false;
			chbFax.Checked = false;
			chbFax1.Checked = false;
			chbMail.Checked = false;
			chbMail1.Checked = false;
			chbPhone.Checked = false;
			chbPhone1.Checked = false;
			lvDocs.Items.Clear();
			tbOrderName.Text = "#####.#####";
			tbItemName.Text = "#####.#####.###.##";
 			pnlDetails.Controls.Clear();
			lvMigratedItemData.Items.Clear();
			lvMigratedItemData.Visible = true;
			imageReportsList.Images.Clear();
			//rbDefault.Checked = true;
			lvAddServices.Items.Clear();
			for (int i = 0; i < prmPermissions.achbPermissions.Length; i++)
				prmPermissions.achbPermissions[i].Checked = false;

			//DataTable dt = ((DataTable)cbCustPersons.DataSource);
			//if (dt != null)
			//	dt.Rows.Clear();
			//dt = ((DataTable)cbPersons.DataSource);
			//if (dt != null)
			//	dt.Rows.Clear();
		}
		private void LoadOrderByMemo(string sMemoNumber)
		{
		}

		private void bSearch_Click(object sender, System.EventArgs e)
		{
			//rbDefault.Checked = true;
			lvAddServices.Items.Clear();
			if (tbMemoNumber.Text.Trim().Length > 0)
			{
				LoadOrderByMemo(tbMemoNumber.Text.Trim());
				tbMemoNumber.Text = "";
				return;
			}
//            string sOrder = "";
//            string sBatch = "";
//            string sItem = "";
            string[] sItemNum;

            DataTable dtNewItemCode;
            string sNewItemNum0 = "";

			string sOrderGroup = tbSearchUnit.Text.Trim();
			CClear();
			tbSearchUnit.Text = sOrderGroup;
			isSelectItem = true;
			this.Cursor = Cursors.WaitCursor;

			sbStatus.Text = "Searching. Please, wait";
            int iFirstDotPosition = 0;

            switch (sOrderGroup.Length)
            {
                case 10:
                    if(sOrderGroup.IndexOf(".")< 0 )
                    {
                        tbSearchUnit.Text = GraderLib.GetFullCodeStringWithDots(sOrderGroup);
                        sOrderGroup = tbSearchUnit.Text;
                    }
                    break;
                case 11:
                    if(sOrderGroup.IndexOf(".")< 0 )
                    {
                        tbSearchUnit.Text = GraderLib.GetFullCodeStringWithDots(sOrderGroup);
                        sOrderGroup = tbSearchUnit.Text;
                    }
//                    else
//                    {
//                        tbSearchUnit.Text = GraderLib.GetFullCodeStringWithDots(sOrderGroup.Substring(5));
//                        sOrderGroup = tbSearchUnit.Text;
//                    }
                    break;
                case 16:
                    if(sOrderGroup.IndexOf(".")> 0 )
                    {
                        iFirstDotPosition = sOrderGroup.IndexOf('.');
                        tbSearchUnit.Text = GraderLib.GetFullCodeStringWithDots(sOrderGroup.Substring(iFirstDotPosition));
				        sOrderGroup = tbSearchUnit.Text;
                    }
                    break;
                case 18:
                    if(sOrderGroup.IndexOf(".")> 0 )
                    {
                        iFirstDotPosition = sOrderGroup.IndexOf('.');
                        tbSearchUnit.Text = GraderLib.GetFullCodeStringWithDots(sOrderGroup.Substring(iFirstDotPosition));
                        sOrderGroup = tbSearchUnit.Text;
                    }
                    break;
                case 5:
                    {
                        tbSearchUnit.Text = tbSearchUnit.Text + "." + tbSearchUnit.Text;
                        sOrderGroup = tbSearchUnit.Text;
                        break;
                    }
                case 6:
                {
                    tbSearchUnit.Text = tbSearchUnit.Text + "." + tbSearchUnit.Text;
                    sOrderGroup = tbSearchUnit.Text;
                    break;
                }

//                default:
//                    WrongOrderCodeMessage();
//                    return;
                   
            }
            if(tbSearchUnit.Text.Length < 5)
            {
                tbSearchUnit.Text = Service.FillToFiveChars(tbSearchUnit.Text);
                tbSearchUnit.Text = tbSearchUnit.Text + "." + tbSearchUnit.Text;
                sOrderGroup = tbSearchUnit.Text;
            }
			
			sItemNum = sOrderGroup.Split('.');
			/*otAllOrders.Clear();


			otClosed.Clear();
			otOpenOrders.Clear();*/
			//CClear();

			//FillPersons();
			bool Exists = false;
			DataRow []iRow;
			//for(int i = 0; i < ((DataView)(cbcCustomer.ComboField.cbField.DataSource)).Count; i++)
			//{	
			
//			DataTable dtNewItemCode;
//			string sNewItemNum0 = "";


			if (sOrderGroup.Length == 18 || sOrderGroup.Length == 20)

			{
				dtNewItemCode = Service.GetNewItemCustomerCodeByCode(sItemNum[0], sItemNum[1], sItemNum[2], sItemNum[3]);			

				if (dtNewItemCode.Rows.Count > 0)
				{
					sNewItemNum0 = dtNewItemCode.Rows[0]["NewItemNumber"].ToString().Trim();

					if (sNewItemNum0.Trim() != tbSearchUnit.Text.Trim())
					{
						if(MessageBox.Show("Item #" + tbSearchUnit.Text.Trim() + " migrated to new #" + sNewItemNum0.Trim() + ".\nWould you like to open it?" ,"New Item #", MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
						{
							tbSearchUnit.Text = sNewItemNum0.Trim();
							sOrderGroup = sNewItemNum0.Trim();
						}
						else 
						{
							tbSearchUnit.Text = "";
							CClear();
							return;
						}
					}
				}
			}
			try
			{
				myActiveOrder = sItemNum[0];
				if (bLoading && tcMain.SelectedIndex == 5)
				{
					cbCustomerProgram.Items.Clear();
					cbCustomerProgram.Text = "Customer program lookup";
					cbCustomerProgram.SelectedIndex = -1;
					myActiveOrder = sItemNum[0];
					FillBlockedDataObjects(sItemNum[0], "");
					htBlockedPart = new Hashtable();
					bulkMode = true;
					indexOld = -1;
					this.Cursor = Cursors.Default;
					isSelectItem = false;
					if (lvBatchesToBlock.Items.Count > 0) sbStatus.Text = "Ready";
					else sbStatus.Text = "No batches to load";
					return;
				}
				DataSet dsOrders = Service.GetOrderTreeDataByGroupCode(sItemNum[0]);	//Procedures spGetGroupByCode, spGetBatchByCode, spGetItemByCode, spGetItemDocByCode, spGetStates
//				if(tbSearchUnit.Text.Length == 11 || tbSearchUnit.Text.Length == 18)
#if DEBUG
                // For debugging only			
                string filename = Service.sTempDir + "/myXmlDoc.xml";
                if (File.Exists(filename)) File.Delete(filename);
                // Create the FileStream to write with.
                System.IO.FileStream myFileStream = new System.IO.FileStream (filename, System.IO.FileMode.Create);
                // Create an XmlTextWriter with the fileStream.
                System.Xml.XmlTextWriter myXmlWriter = new System.Xml.XmlTextWriter(myFileStream, System.Text.Encoding.Unicode);
                // Write to the file with the WriteXml method.
                dsOrders.WriteXml(myXmlWriter);   
                myXmlWriter.Close();
                // End of debugging part
#endif
				
                
                if(((tbSearchUnit.Text.Length == 11 || tbSearchUnit.Text.Length == 18) && tbSearchUnit.Text.IndexOf('.') > 0)
                    || ((tbSearchUnit.Text.Length == 13 || tbSearchUnit.Text.Length == 20) && tbSearchUnit.Text.IndexOf('.') > 0))
				{
					#region
					if((tbSearchUnit.Text.Length == 11) || (tbSearchUnit.Text.Length == 13))

					{
						string sOrderCode = tbSearchUnit.Text.Split(new char[] {'.'})[0].TrimStart(new char[] {'0'});


						if((iRow = dsOrders.Tables["tblOrder"].Select("OrderCode='" + sOrderCode + "'")).Length > 0)
						{
							try
							{
								cbcCustomer.SelectedCode = iRow[0]["CustomerCode"].ToString();
								Exists = true;
							}
							catch(Exception ex)
							{
								MessageBox.Show(ex.Message ,"Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
							}
						}
					}
					else
					{
						if((iRow = dsOrders.Tables["tblItem"].Select("Name='" + tbSearchUnit.Text.Trim() + "'")).Length > 0)
						{
							cbcCustomer.SelectedCode = iRow[0]["CustomerCode"].ToString();
							Exists = true;
							//break;
						}
					}
					#endregion
				}
				//else break;
				//}
			
				#region
				if(Exists)
				{
					tbSearchUnit.Text = sOrderGroup;

					this.Cursor = Cursors.WaitCursor;				
					//bDetailsSelect_Click(this, EventArgs.Empty);
					string sOrder = tbSearchUnit.Text.Split(new char[] {'.'})[0].TrimStart(new char[] {'0'});
					
					if(tbSearchUnit.Text.Length == 11 || tbSearchUnit.Text.Length == 13)
					{
						string[] sNewItemNum = tbSearchUnit.Text.Trim().Split('.');
//						sOrderGroup = tbSearchUnit.Text.Trim();
			
						DataTable dtMigratedItemCode = Service.GetMigratedItemCode(sNewItemNum[0],"0","0");
						if (dtMigratedItemCode.Rows.Count > 0)
						{
							ListViewItem lv2;
							lvMigratedItemData.Visible = true;

                            foreach (DataRow dr in dtMigratedItemCode.Rows)
							{
								lv2 = new ListViewItem(dr["PrevItemNumber"].ToString());
								lv2.SubItems.Add(dr["CurrentOrderItemNumber"].ToString());
								lv2.SubItems.Add(dr["NewItemNumber"].ToString());
								lvMigratedItemData.Items.Add(lv2);
							}
							this.label11.Text = "Order # " + sNewItemNum[0] + ": " + dtMigratedItemCode.Rows.Count + " Migrated Items";
						}
					}					
					
					if(System.Convert.ToInt32(dsOrders.Tables[0].Rows[0]["StateCode"]) != 1)
					{
						otOpenOrders.Initialize(dsOrders);
						otOpenOrders.RealSelectNode(tbSearchUnit.Text);

						otOpenOrders.ExpandOneLevel();				
						tcMain.SelectedTab = tcMain.TabPages[1];				
					}
					else
					{
						if (MessageBox.Show("Order # " + sOrder + " is closed. Would you like to open it temporary?", "Order status", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

						{
							otOpenOrders.Initialize(dsOrders);
							otOpenOrders.RealSelectNode(tbSearchUnit.Text);

							otOpenOrders.ExpandOneLevel();
							tcMain.SelectedTab = tcMain.TabPages[1];
						}
						else
						{
							otClosed.Initialize(dsOrders);
							otClosed.RealSelectNode(tbSearchUnit.Text);

							otOpenOrders.ExpandOneLevel();
							tcMain.SelectedTab = tcMain.TabPages[0];
						}
					}
					bOrderUpdate.Enabled = true;
					bOrderReports.Enabled = true;
					dsAddServices = GetAdditionalSrvices(sOrder);
					//FillAddServicesList(sOrder, "0");
				}
				else
				{
					MessageBox.Show("Order/Item could not be found. Make sure that you enter right Group Code or Item Code", 
						"Could not find Order/Item", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);				
					cbcCustomer.SelectedCode = "0";
					tcMain.SelectedTab = tcMain.TabPages[0];
					tcMain.Enabled = false;
				}

			#endregion

				tbSearchUnit.SelectAll();
				FillPersons();
				sbStatus.Text = "Ready";
			}
			catch(Exception ex)
			{
				tbSearchUnit.Text="";
				MessageBox.Show(ex.Message ,"Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
			this.Cursor = Cursors.Default;
			isSelectItem = false;
		}

		//private string[]  GetItemNumber(string sOrderGroup)
		//{

		//	return null;
		//}

//		private void InitPartTree(string sItemTypeID)
//		{
//			try
//			{
//				partView.Clear();
//				dsStructure = new DataSet();
//				dsStructure.Tables.Add(Service.GetParts(sItemTypeID));  //tblName : Parts	/Procedure dbo.spGetPartsByItemType
//				dsStructure.Tables.Add(Service.GetPartsStruct());   //tblName : SetParts
	
//				this.partView.Initialize(dsStructure.Tables["Parts"]);
//				this.partView.ExpandTree();
//				partView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.partView_AfterCheck);
//#if DEBUG
//				// For debugging only			
//				string filename = "C:/DELL/myXmlPartsList.xml";
//				if (File.Exists(filename)) File.Delete(filename);
//				// Create the FileStream to write with.
//				System.IO.FileStream myFileStream = new System.IO.FileStream(filename, System.IO.FileMode.Create);
//				// Create an XmlTextWriter with the fileStream.
//				System.Xml.XmlTextWriter myXmlWriter = new System.Xml.XmlTextWriter(myFileStream, System.Text.Encoding.Unicode);
//				// Write to the file with the WriteXml method.
//				dsStructure.WriteXml(myXmlWriter);
//				myXmlWriter.Close();
//				// End of debugging part
//#endif
//			}
//			catch (Exception ex)
		//	{
		//		var a = ex.Message;
		//	}

		//}

		//private void FillBlockedDataObjects(string sOrder, string sSelectBy)
		//{
		//	try
		//	{
		//		button5.Enabled = false;
		//		DataSet dsBatches = GetBlockedPartsSKUBatches(sOrder);
		//		if (dsBatches != null)
		//		{
		//			ListViewItem lv;
		//			DataRow[] dRows;
		//			isLoaded = true;
		//			lvBatchesToBlock.Items.Clear();            //"DocumentTypeCode = '8'"
		//			if (sSelectBy == "") dRows = dsBatches.Tables[0].Select();
		//			else dRows = dsBatches.Tables[0].Select("CustomerProgramName = '" + sSelectBy + "'");

		//			if (dRows.Length > 0)
		//			{
		//				foreach (DataRow dRow in dRows)
		//				{
		//					lv = new ListViewItem("");
		//					if (dRow[6] != DBNull.Value) lv.Checked = true;
		//					else lv.Checked = false;
		//					lv.SubItems.Add(dRow[0].ToString());
		//					lv.SubItems.Add(dRow[1].ToString());
		//					lv.SubItems.Add(dRow[2].ToString());
		//					lv.SubItems.Add(dRow[3].ToString());
		//					lv.SubItems.Add(dRow[4].ToString());
		//					lv.SubItems.Add(dRow[5].ToString());
		//					lv.SubItems.Add(dRow[6] == DBNull.Value ? "" : dRow[6].ToString());
		//					lv.SubItems.Add(dRow[7] == DBNull.Value ? "" : dRow[7].ToString());
		//					lvBatchesToBlock.Items.Add(lv);
		//				}
		//				lvBatchesToBlock.ListViewItemSorter = new ListViewItemComparer(1);
		//				lvBatchesToBlock.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvBatchesToBlock_ItemSelectionChanged);
		//				lvBatchesToBlock.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lvBatchesToBlock_ItemCheck);
		//				lvBatchesToBlock.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvBatchesToBlock_ItemChecked);
		//			}
		//			if (sSelectBy.Trim() == "")
		//			{
		//				dRows = dsBatches.Tables[1].Select();
		//				if (dRows.Length > 0)
		//				{
		//					cbCustomerProgram.DataSource = dsBatches.Tables[1];
		//					cbCustomerProgram.DisplayMember = "CustomerProgramName";
		//					cbCustomerProgram.ValueMember = "ItemTypeID";
		//					cbCustomerProgram.SelectedIndex = -1;
		//					cbCustomerProgram.Text = "Customer program lookup";
		//					cbCustomerProgram.SelectedIndexChanged += new System.EventHandler(this.cbCustomerProgram_SelectedIndexChanged);
		//				}
		//			}
		//			isLoaded = false;
		//		}

		//	}
		//	catch (Exception ex)
		//	{
		//		var a = ex.Message;
		//	}
		//}

		private void WrongOrderCodeMessage()
        {
            MessageBox.Show("Order/Item could not be found. Make sure that you enter right Group Code or Item Code", 
                "Could not find Order/Item", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);				
            cbcCustomer.SelectedCode = "0";
            tcMain.SelectedTab = tcMain.TabPages[0];
            tcMain.Enabled = false;
        }
				
#endregion Search

#endregion Tab1

#region Tab2		
				
		//Tab2/ "Open Orders" & "Order Details"
		private void otOpenOrders_SelectedItemChanged(object sender, EventArgs e)
		{	
			groupBox7.Text = "Item Details";
			lbOtherDetails.Text = "";
			lvProps.Items.Clear();
			if(otOpenOrders.Selected.tblName != "tblItem")
				lbxItems.Items.Clear();
			else
				bHelp_Click(this, EventArgs.Empty);
			SetItems(otOpenOrders, otOpenOrders.Selected);			
		}

		private void SetItems(OrdersTree otTree, OrderNode noTemp)
		{
//			if(noTemp.tblName == "tblOrder")
//			{
//			tbSearchUnit.Text = noTemp.NodeCode;
//			}
			if(noTemp.tblName == "tblBatch")
			{
				for(int j = 0; j < noTemp.Nodes.Count; j++)
				{					
					lbxItems.Items.Add(((OrderNode)noTemp.Nodes[j]).drNode["Name"]);
				}			
			}
				
			else 
				
				for(int i = 0; i < noTemp.Nodes.Count; i++)
					SetItems(otTree, (OrderNode)noTemp.Nodes[i]);
		}		

		private void lbxItems_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			sbStatus.Text = "Getting item info from server";
			this.Cursor = Cursors.WaitCursor;

			try
			{
				DataSet dsGetItemDocByCodeTypeEx = Service.GetItemDocByCodeTypeEx();
				dsGetItemDocByCodeTypeEx.Tables[0].Rows.Add(dsGetItemDocByCodeTypeEx.Tables[0].NewRow());

				DataSet dsGetOpsByItemCode = dsGetItemDocByCodeTypeEx.Copy();
				dsGetOpsByItemCode.Tables["ItemDocByCodeTypeEx"].TableName = "ItemOpByCode";
				dsGetOpsByItemCode.Tables["ItemOpByCode"].Rows[0]["GroupCode"] = Convert.ToInt32(lbxItems.SelectedItem.ToString().Substring(0, 5)).ToString();
				dsGetOpsByItemCode.Tables["ItemOpByCode"].Rows[0]["BatchCode"] = Convert.ToInt32(lbxItems.SelectedItem.ToString().Substring(12, 3)).ToString();
				dsGetOpsByItemCode.Tables["ItemOpByCode"].Rows[0]["ItemCode"] = Convert.ToInt32(lbxItems.SelectedItem.ToString().Substring(16, 2)).ToString();
				dsGetOpsByItemCode = Service.GetOpsByItemCode(dsGetOpsByItemCode);

				dsGetOpsByItemCode.Tables["ItemOpByCode"].Columns["OperationTypeGroupParentID"].ColumnName = "ParentID";
				dsGetOpsByItemCode.Tables["ItemOpByCode"].Columns["OperationTypeID"].ColumnName = "ID";
				dsGetOpsByItemCode.Tables["ItemOpByCode"].Columns["OperationTypeName"].ColumnName = "Name";

				DataSet dsToFill = dsGetOpsByItemCode.Copy();

				int iResIDs = -1;
				foreach(DataRow dr in dsToFill.Tables["ItemOpByCode"].Rows)
				{
					if(dsGetOpsByItemCode.Tables["ItemOpByCode"].Select("Name='" + dr["OperationTypeGroupName"].ToString() + "'").Length == 0)
					{
						dsGetOpsByItemCode.Tables["ItemOpByCode"].Rows.Add(dsGetOpsByItemCode.Tables["ItemOpByCode"].NewRow());
						dsGetOpsByItemCode.Tables["ItemOpByCode"].Rows[dsGetOpsByItemCode.Tables["ItemOpByCode"].Rows.Count - 1]["ParentID"] =
							DBNull.Value;
						dsGetOpsByItemCode.Tables["ItemOpByCode"].Rows[dsGetOpsByItemCode.Tables["ItemOpByCode"].Rows.Count - 1]["Name"] =
							dr["OperationTypeGroupName"];
						dsGetOpsByItemCode.Tables["ItemOpByCode"].Rows[dsGetOpsByItemCode.Tables["ItemOpByCode"].Rows.Count - 1]["ID"] =
							iResIDs;
						
						DataRow[] adrChldrn = dsGetOpsByItemCode.Tables["ItemOpByCode"].Select("OperationTypeGroupName='" + dr["OperationTypeGroupName"].ToString() + "'");
						foreach(DataRow drChld in adrChldrn)
						{
							if(drChld["OperationTypeGroupName"].ToString() != drChld["Name"].ToString())
								drChld["ParentID"] = iResIDs;
						}
						iResIDs--;
						//dr["ParentID"] = iResIDs;
					}
					else
					{
						DataRow drSel = dsGetOpsByItemCode.Tables["ItemOpByCode"].Select("Name='" + dr["OperationTypeGroupName"].ToString() + "'")[0];
						dr["ParentID"] = drSel["ID"];
					}
				}

				ptrOps.Initialize(dsGetOpsByItemCode.Tables["ItemOpByCode"]);
				ptrOps.ExpandTree();
			}
			catch(Exception exc)
			{
				sbStatus.Text = "Couldn't get details from server";
				Console.WriteLine(exc.Message);
			}

			otOpenOrders.RealSelectNode(lbxItems.SelectedItem.ToString());
			//bHelp_Click(this, EventArgs.Empty);

			this.Cursor = Cursors.Default;
			sbStatus.Text = "Ready";
		}


		//Tab2/Filling Tab3/AllOrders with checked orders from Tab2/OpenOrders
		private void button4_Click(object sender, System.EventArgs e)
		{
			otAllOrders.Initialize(otOpenOrders.Get());
			tcMain.SelectedTab = tcMain.TabPages[2];
		}


		//Tab2 hotkeys handler
		private void AccountRep_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch(e.KeyCode)
			{
				case Keys.F3 :
				{
					bFax_Click(this, EventArgs.Empty);
					break;
				}
				case Keys.F4 :
				{
					if(!e.Alt)
						button13_Click(this, EventArgs.Empty);
					break;
				}
				case Keys.F1 :
				{
					bHelp_Click(this, EventArgs.Empty);
					break;
				}
			}
				
		}

#region PrintAndEndSession
		//External receipt
		private void bPrint_Click(object sender, System.EventArgs e)
		{
            try
            {
				bPrint.Enabled = false;
				string sRepPath = Client.GetOfficeDirPath("repDir");
                CrystalReport.CrystalReport crReport;
                crReport = new CrystalReport.CrystalReport(sRepPath, true);
				//string sTempFolder = @"C:\TEMP\";
                DataSet dsChecked = otOpenOrders.GetChecked();

#if DEBUG
                // For debugging only			
                string filename = "C:/DELL/myXmlDoc.xml";
                if (File.Exists(filename)) File.Delete(filename);
                // Create the FileStream to write with.
                System.IO.FileStream myFileStream = new System.IO.FileStream(filename, System.IO.FileMode.Create);
                // Create an XmlTextWriter with the fileStream.
                System.Xml.XmlTextWriter myXmlWriter = new System.Xml.XmlTextWriter(myFileStream, System.Text.Encoding.Unicode);
                // Write to the file with the WriteXml method.
                dsChecked.WriteXml(myXmlWriter);
                myXmlWriter.Close();
                // End of debugging part
#endif

                if (dsChecked.Tables["tblOrder"].Rows.Count == 0 && dsChecked.Tables["tblItem"].Rows.Count == 0)
                {
                    MessageBox.Show("No Checked Orders/Items in List", "Checked Orders", MessageBoxButtons.OK, MessageBoxIcon.Error);
					bPrint.Enabled = true;
					return;
                }

				if (dsChecked.Tables["tblOrder"].Rows.Count > 0)
				{
					//Preview previewExcel = new Preview();
					foreach (DataRow dr in dsChecked.Tables["tblOrder"].Rows)
					{

						Client.ViewReport = true;
						crReport.Excel_Front_TakeIn(dr["GroupOfficeID"].ToString() + "_" + dr["GroupID"].ToString(), CrystalReport.TakeInType.TakeIn, 1);
						Client.ViewReport = false;
						bPrint.Enabled = true;
						//Preview previewExcel = new Preview(sTempFolder + dr["Code"].ToString() + ".xls");
						//previewExcel.ShowDialog();
						return;
						//CrystalReport.CrystalReport crRep = new CrystalReport.CrystalReport(sRepPath);
						//crRep.Front_TakeIn(dr["GroupOfficeID"].ToString() + "_" + dr["GroupID"].ToString(), CrystalReport.TakeInType.TakeIn);
						//crRep.Export("pdf");
						//crRep.ViewDocument();
					}
				}

				if (dsChecked.Tables["tblOrder"].Rows.Count == 0 && dsChecked.Tables["tblItem"].Rows.Count > 0)
				{
					foreach (DataRow row in dsChecked.Tables["tblItem"].Rows)
					{
					DataSet dsDocs = new DataSet();//Service.GetDocumentIDByBatchID(row["BatchID"].ToString());
					dsDocs.Tables.Add("DefaultDocumentTypeCodeByBatchID");
					//dsDocs.Tables.Add("DocumentTypeCodeByBatchID");
					dsDocs.Tables[0].Columns.Add("BatchID");
					dsDocs.Tables[0].Rows.Add(dsDocs.Tables[0].NewRow());
					dsDocs.Tables[0].Rows[0][0] = row["BatchID"].ToString();
					dsDocs = Service.ProxyGenericGet(dsDocs);//Procedure dbo.spGetDocumentTypeCodeByBatchID
					DataRow[] docs = dsDocs.Tables[0].Select("DocumentTypeCode = '8'");

						if (docs.Length == 1)
						{
							Client.ViewReport = true;
							crReport.Excel_Account_Representative_Label(
																		docs[0], row["BatchID"].ToString(),
																		row["NewBatchID"].ToString(),
																		row["Code"].ToString(),
																		row["NewItemCode"].ToString(),
																		row["OrderCode"].ToString(),
																		row["BatchCode"].ToString(),
																		docs[0]["CorelFile"].ToString().ToUpper().Trim().Replace("RPT", "XLS"));
							Client.ViewReport = false;
							break;
						}
					}
				}
			}
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
			bPrint.Enabled = true;
		}
		private DataSet GetAdditionalSrvices(string myOrder)
		{
			try
			{
				//if (otAllOrders.Selected != null)
				{
					DataSet dsTemp = new DataSet();
					dsTemp.Tables.Add("AdditionalServicesPerBatch");
					dsTemp.Tables[0].Columns.Add("OrderCode", Type.GetType("System.String"));
					dsTemp.Tables[0].Rows.Add(dsTemp.Tables[0].NewRow());
					dsTemp.Tables[0].Rows[0][0] = myOrder;
					DataSet dsOut = Service.ProxyGenericGet(dsTemp); //Procedure [dbo].[spGetAdditionalServicesPerBatch]
					return dsOut;
				}
				//else return null;
			}
			catch
			{
				return null;
			}
		}


		private void FillAddServicesList(string sOrderCode, string sBatch)
		{
			ListViewItem lv;
	
			{
				try
				{
					 if (dsAddServices != null)
					{
						if (dsAddServices.Tables.Count > 0)
						{
							DataRow[] dRows;
							if (sBatch == "0")
							{
								lvAddServices.Items.Clear();
								dRows = dsAddServices.Tables[0].Select();
							}
							else
								dRows = dsAddServices.Tables[0].Select("BatchCode = '" + sBatch + "'");

							if (dRows.Length > 0)
							{
								foreach (DataRow dRow in dRows)
								{
									lv = new ListViewItem("");
									lv.Checked = true;
									lv.SubItems.Add(dRow[0].ToString());
									lv.SubItems.Add(dRow[1].ToString());
									lv.SubItems.Add(dRow[2].ToString());
									lv.SubItems.Add(Service.FillToThreeChars(dRow[3].ToString()));
									lv.SubItems.Add(dRow[4].ToString());
									lv.SubItems.Add(dRow[5].ToString());
									lv.SubItems.Add(dRow[6].ToString());
									lvAddServices.Items.Add(lv);
								}
								lvAddServices.ListViewItemSorter = new ListViewItemComparer(4);
							}
						}
					}
				}
				catch { }
			}
		}
		//Certified labels
		//
		public static void AnalyzeAndPrint(DataTable dtItems)
		{
			Boolean isApply2All = false;
			Boolean isTotalWeight = true;
            int    bOldStyle = 1;
			PrintingOptions frmPrintingOptions;
			CrystalReport.CrystalReport crReport = null;
			string sReportKind = Service.GetReportKind();
			String s = "";
           
            //dtItems = dsSelectedItems.Tables[
			//temporary DataTable, contains one current row
			//need this to be able to print documents in Items loop
			DataTable dtBlockedItems = dtItems.Clone(); //new DataTable();
//			foreach(DataColumn dcCol in dtItems.Columns)
//				dtItemsPerBatch.Columns.Add(dcCol.ColumnName);

			string sRepPath = Client.GetOfficeDirPath("repDir");
			if(sReportKind != "crystal")
			{
				crReport = new CrystalReport.CrystalReport(sRepPath,true);
			}
		
			foreach(DataRow row in dtItems.Rows)
			{
				//dtItemsPerBatch.Rows.Clear();
				//check for .rpt file attached to CP
				//vetal_242 01.03.2006
				DataSet dsDocs = new DataSet();//Service.GetDocumentIDByBatchID(row["BatchID"].ToString());
                dsDocs.Tables.Add("DefaultDocumentTypeCodeByBatchID");
				//dsDocs.Tables.Add("DocumentTypeCodeByBatchID");
				dsDocs.Tables[0].Columns.Add("BatchID");
				dsDocs.Tables[0].Rows.Add(dsDocs.Tables[0].NewRow());
				dsDocs.Tables[0].Rows[0][0] = row["BatchID"].ToString();
				dsDocs = Service.ProxyGenericGet(dsDocs);//Procedure dbo.spGetDocumentTypeCodeByBatchID
				
				DataRow []docs = dsDocs.Tables[0].Select("DocumentTypeCode = '8'");
				Boolean isRpt = docs.Length == 0 ? false : true;
                bOldStyle = 0;
                if (docs.Length == 1)
                {
                    //switch (docs[0]["CorelFile"].ToString().ToUpper().Trim())
                    //{
                    //    case "ACC_REP_TLKW_LABEL.XLS":
                    //    case "ACCOUNT_REP_TLKW_LABEL.XLS":
                    //        {
                    //            bOldStyle = 1;
                    //            break;
                    //        }
                    //    case "ACC_REP_LABEL.XLS":
                    //    case "ACCOUNT_REP_LABEL.XLS":
                    //        {
                    //            bOldStyle = 0;
                    //            break;
                    //        }
                    //    case "ACCOUNT_REP_LABEL_QR.XLS":
                    //    case "ACC_REP_LABEL_QR.XLS":
                    //        {
                    //            bOldStyle = 2;
                    //            break;
                    //        }
                    //    default:
                    //        {
                    //            bOldStyle = 0;
                    //            break;                            
                    //        }
                    //}
                    //if(docs[0]["CorelFile"].ToString().ToUpper().Equals("ACC_REP_TLKW_LABEL.XLS")) bOldStyle = false;  
                    //else bOldStyle = true;
                }
				try
				{					
					if(row["StateCode"].ToString().Equals("3"))
					{
						//throw new Exception("Item " + row["Name"] + " is blocked.");
						dtBlockedItems.Rows.Add(row.ItemArray);
						continue;
					}
					//If explicit certified labels for this item don't exist, ask what we need to print in implicit label
					if(!isRpt && !isApply2All)
					{
                        string OrderCode = Service.FillToFiveChars(row["OrderCode"].ToString());
                        string BatchCode = Service.FillToThreeChars(row["BatchCode"].ToString());
                        s = "";
                        MessageBox.Show("No labels attached to batch #" + OrderCode + "." + BatchCode);
                        goto Finish;
                        //frmPrintingOptions = new PrintingOptions();
                        //frmPrintingOptions.ShowDialog();
                        //isTotalWeight = frmPrintingOptions.IsTotalWeight;
                        //isApply2All = frmPrintingOptions.IsApply2All;
					}

					//if not exist .rpt file print default
					if(!isRpt)
					{
						
						if(sReportKind == "crystal")
						{
							crReport = new CrystalReport.CrystalReport(sRepPath);
							crReport.Account_Representative_Label(row["OrderCode"].ToString(), row["BatchCode"].ToString(), row["BatchID"].ToString(),row["NewBatchID"].ToString(),row["Code"].ToString(), row["NewItemCode"].ToString(), isTotalWeight);
							crReport.Print();
						}
						else
						{
							crReport.Excel_Account_Representative_Label(row["OrderCode"].ToString(), row["BatchCode"].ToString(), row["BatchID"].ToString(),row["NewBatchID"].ToString(),row["Code"].ToString(), row["NewItemCode"].ToString(), isTotalWeight);
						}
					}
					else
					{
						//crReport = new CrystalReport.CrystalReport(sRepPath);
						foreach(DataRow drDoc in docs)
						{
							
							if(sReportKind == "crystal")
							{
								crReport = new CrystalReport.CrystalReport(sRepPath);
								crReport.Account_Representative_Label(
                                                                        drDoc, row["BatchID"].ToString(),
                                                                        row["NewBatchID"].ToString(), 
                                                                        row["Code"].ToString(),
                                                                        row["NewItemCode"].ToString(), 
                                                                        row["OrderCode"].ToString(), 
                                                                        row["BatchCode"].ToString());
								crReport.Print();
							}
							else
							{
								crReport.Excel_Account_Representative_Label(
                                                                            drDoc, row["BatchID"].ToString(),
                                                                            row["NewBatchID"].ToString(), 
                                                                            row["Code"].ToString(),
                                                                            row["NewItemCode"].ToString(), 
                                                                            row["OrderCode"].ToString(), 
                                                                            row["BatchCode"].ToString(),
                                                                            docs[0]["CorelFile"].ToString().ToUpper().Trim().Replace("RPT","XLS"));                      //Create acc. rep. label
							}
						}
					}					
				}
				catch (Exception ex)
				{
					if (s.Length != 0)
						s += ", ";
					s += String.Format("{0}.{1}.{2}", row["OrderCode"].ToString(), row["BatchCode"].ToString(), row["Code"].ToString());
					MessageBox.Show("Missing data in ##" + ex.Message, "Print error", MessageBoxButtons.OK);
				}
			}
			if(dtBlockedItems.Rows.Count > 0)
			{
				if(MessageBox.Show("Would you like to print labels for blocked items", "Blocked Items", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
					PrintLabelsForBlockedItem(dtBlockedItems);
			}
            Finish:
            Client.MyActivePrinter = "";
            Client.MyActiveReportName = "";
			if(crReport != null)
				crReport.CloseExcel();
			crReport = null;
			GC.Collect();
			GC.WaitForPendingFinalizers(); 
			GC.Collect();

			if (s.Length != 0)			
				MessageBox.Show("Next labels are not printed:\n" + s, "Some labels are not printed", MessageBoxButtons.OK, MessageBoxIcon.Warning);			
		}

		private static void PrintLabelsForBlockedItem(DataTable dtItems)
		{



		}

		private void bPrintLabel_Click(object sender, System.EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			this.sbStatus.Text = "Printing labels...";
//            DataSet dsData = new DataSet();
//            dsData = otOpenOrders.GetChecked().Copy();

			try
			{
				AnalyzeAndPrint(otOpenOrders.GetChecked().Tables["tblItem"]);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message, "Print error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			//Reprint until say NO
			for(;;)
			{
				if(MessageBox.Show("Would you like to print these labels again?","Printing completed", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
				{
					ReprintForm reprintForm = new ReprintForm(this.otOpenOrders.Get());
					reprintForm.ShowDialog();					
				}
				else break;	
			}
			
			this.Cursor = Cursors.Default;
			this.sbStatus.Text = "Ready";
		}

		//Commented on 2006.03.18 by 3ter. Now Print()'s functionality is contained by AnalyzeAndPrint(). We can remove this func at all
#region
		/*
		public static void Print(DataTable dtTable, bool isRpt, DataRow []docs)
		{			
			PrintingOptions frmPrintingOptions = new PrintingOptions();
			Boolean isTotalWeight=true;
			Boolean isApply2All = false;
			//if not exist .rpt file
			if(!isRpt)
			{
				frmPrintingOptions.ShowDialog();
				isTotalWeight = frmPrintingOptions.IsTotalWeight;
				isApply2All = frmPrintingOptions.IsApply2All;
			}
			string s = null;
			string sOrder = "";
			string sBatch = "";
			string sBatchID = "";
			string sItemCode = "";
			foreach(DataRow dr in dtTable.Rows)
			{
				try
				{
					sOrder = Convert.ToInt32(dr["Name"].ToString().Substring(0, 5)).ToString();
					sBatch = Convert.ToInt32(dr["Name"].ToString().Substring(12, 3)).ToString();
					sBatchID = dr["BatchID"].ToString();
					sItemCode = dr["Code"].ToString();

					string sRepPath = Service.GetCRTemplatePath();
					CrystalReport.CrystalReport crReport = new CrystalReport.CrystalReport(sRepPath);
					//if not exist .rpt file print default
					if(!isRpt)
					{
						crReport.Account_Representative_Label(sOrder, sBatch, sBatchID, sItemCode, isTotalWeight);
					}
					else
					{
						crReport.Account_Representative_Label(docs, sBatchID, sItemCode, sOrder, sBatch);
					}
					
					crReport.Print();
				}
				catch (Exception ex)
				{
					if (s != null)
						s += ", ";
					s += String.Format("{0}.{1}.{2}", sOrder, sBatch, sItemCode);
					MessageBox.Show("Print error occured: " + ex.Message,	"Measure is empty for item", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			if (s != null)
			{
				MessageBox.Show("Next labels are not printed:\n" + s, "Some labels are not printed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
		
*/		
#endregion
		//End session
		private void bEndSession_Click(object sender, System.EventArgs e)
		{
			endSession(false);
//			this.Cursor = Cursors.WaitCursor;			
//
//			StringBuilder sb = new StringBuilder();
//			StringBuilder sbExec = new StringBuilder();
//			//15.09.2006 by vetal_242 change Tables["tblBatch"] to Tables["tblItem"]
//			if(otOpenOrders.GetChecked().Tables["tblItem"].Rows.Count > 0)
//				try
//				{
//					foreach(DataRow dr in otOpenOrders.GetChecked().Tables["tblBatch"].Rows)
//						sb.Append(dr["Name"]).Append("\n");
//					DataSet dsItemDocsName = new DataSet();
//					string sDoc = "";
//					int count = 0;
//					DataTable dtItemsWithOpenRecheckSession = otOpenOrders.GetChecked().Tables["tblItem"].Clone();
//					
//					foreach(DataRow drItem in otOpenOrders.GetChecked().Tables["tblItem"].Rows)
//					{
//						//if(Service.GetCheckClossedRecheckSessionForItem(drItem["BatchID"].ToString(), drItem["Code"].ToString()).Tables[0].Rows[0][0].ToString() == "0")
//						if(1 == 1)//(Service.GetCheckClossedRecheckSessionForItem(drItem["NewBatchID"].ToString(), drItem["NewItemCode"].ToString()).Tables[0].Rows[0][0].ToString() == "0")
//						{
//							String []sCountAndCanselledDocs;
//							//DataSet dsDoc = Service.SetEndSession(drItem["BatchID"].ToString(), drItem["Code"].ToString());
//							DataSet dsDoc = Service.SetEndSession(drItem["NewBatchID"].ToString(), drItem["NewItemCode"].ToString());
//							//sd 11.16.2006
//							DataSet dsItemDocs = Service.GetDocTypeNameByItemCode(drItem["GroupCode"].ToString(),drItem["BatchCode"].ToString() ,drItem["Code"].ToString());
//							if(!(dsItemDocs.Tables.Count > 0 && dsItemDocs.Tables[0].Rows.Count > 0))
//							{
//								string sItemCode = Service.FillToFiveChars(drItem["GroupCode"].ToString()) + "." +
//									Service.FillToThreeChars(drItem["BatchCode"].ToString()) + "." +
//									Service.FillToTwoChars(drItem["Code"].ToString());
//								if(dsItemDocs.Tables.Count == 0)
//								{
//									dsItemDocs.Tables.Add(new DataTable());
//									dsItemDocs.Tables[0].Columns.Add("ItemNumber");
//									dsItemDocs.Tables[0].Columns.Add("Reports");
//								}
//								dsItemDocs.Tables[0].Rows.Add(new object[] {sItemCode,"Item Rejected"});
//							}
//							dsItemDocsName.Tables.Add(dsItemDocs.Tables[0].Copy());
//							if(dsItemDocsName.Tables.Count>0)
//								dsItemDocsName.Tables[dsItemDocsName.Tables.Count-1].TableName = "Table" + dsItemDocsName.Tables.Count.ToString();
//							
//							if(dsDoc != null)
//							{
//								sCountAndCanselledDocs = dsDoc.Tables[0].Rows[0][0].ToString().Split(' ');
//								count += System.Convert.ToInt32(sCountAndCanselledDocs[0]);
//								if(sCountAndCanselledDocs.Length > 1)
//								{
//									Service.ProxySendCancelledDocs(sCountAndCanselledDocs[1].Substring(1));
//									//MessageBox.Show(this, "NOTE: The previously ordered document [" + sCountAndCanselledDocs[1].Substring(1) 
//									//	+ "] has been cancelled.", "Cancelled documents", MessageBoxButtons.OK, MessageBoxIcon.Error);
//								}
//							}
//							//dtItemsWithOpenRecheckSession.Rows.Add(drItem);
//							dtItemsWithOpenRecheckSession.ImportRow(drItem);
//						}
//					}
//					sDoc = count.ToString();
//					//sd 10.25.2006				
//					//"Do you want to print labels?"
//					DialogResult res=MessageBox.Show(this,"Do you want to print labels?","",MessageBoxButtons.YesNo);
//					if(res==DialogResult.Yes)
//					try
//					{
//						AccountRep.AnalyzeAndPrint(dtItemsWithOpenRecheckSession);
//					}
//					catch(Exception ex)
//					{
//						MessageBox.Show(this,ex.Message,"Print error",MessageBoxButtons.OK,MessageBoxIcon.Error); 
//					}
//					//
//					String sMessage = String.Format("End session is finished. {0} documents are ordered.", sDoc);
//					MessageBox.Show(this, sMessage, "End session is finished.", 
//						MessageBoxButtons.OK, MessageBoxIcon.Information);
//					string msg = "";
//					foreach(DataTable dt in dsItemDocsName.Tables)
//					{
//						string sItemNumber = "";
//						string sReports = "";
//						foreach(DataRow drDocName in dt.Rows)
//						{
//							sItemNumber = drDocName["ItemNumber"].ToString();
//							sReports += (sReports == "")?drDocName["Reports"].ToString():" ," + drDocName["Reports"].ToString();
//						}
//						msg += sItemNumber + " : " + sReports + "\n";
//					}
//					if(msg != "")
//						MessageBox.Show(this, msg, "Ordered Documents.",MessageBoxButtons.OK, MessageBoxIcon.Information);
//					//DrawOpen();
//					lbxItems.Items.Clear();
//				}
//				catch (Exception ex)
//				{
//					MessageBox.Show("Unable to end recheck session. Reason: " + ex.ToString(),
//						"Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//				}
//			else
//				MessageBox.Show("At least one item must be checked to end session", "No batches are checked");
//			
//			sbStatus.Text = "Session was ended";
//			this.Cursor = Cursors.Default;
		}

		private void endSession(bool forceGlobal)
		{
			this.Cursor = Cursors.WaitCursor;			

			StringBuilder sb = new StringBuilder();
			StringBuilder sbExec = new StringBuilder();
			//15.09.2006 by vetal_242 change Tables["tblBatch"] to Tables["tblItem"]
			if(otOpenOrders.GetChecked().Tables["tblItem"].Rows.Count > 0)
				try
				{
					DataTable dtBatch = otOpenOrders.Get().Tables["tblBatch"].Copy();
					foreach(DataRow dr in otOpenOrders.GetChecked().Tables["tblBatch"].Rows)
						sb.Append(dr["Name"]).Append("\n");
					DataSet dsItemDocsName = new DataSet();
					string sDoc = "";
					int count = 0;
					DataTable dtItemsWithOpenRecheckSession = otOpenOrders.GetChecked().Tables["tblItem"].Clone();
					
					foreach(DataRow drItem in otOpenOrders.GetChecked().Tables["tblItem"].Rows)
					{
						//if(Service.GetCheckClossedRecheckSessionForItem(drItem["BatchID"].ToString(), drItem["Code"].ToString()).Tables[0].Rows[0][0].ToString() == "0")
						if(forceGlobal || Service.GetCheckClossedRecheckSessionForItem(drItem["NewBatchID"].ToString(), drItem["NewItemCode"].ToString()).Tables[0].Rows[0][0].ToString() == "0")
						{
							String []sCountAndCanselledDocs;
							//DataSet dsDoc = Service.SetEndSession(drItem["BatchID"].ToString(), drItem["Code"].ToString());
							DataSet dsDoc = Service.SetEndSession(drItem["NewBatchID"].ToString(), drItem["NewItemCode"].ToString());
							//sd 11.16.2006
							DataSet dsItemDocs = Service.GetDocTypeNameByItemCode(drItem["GroupCode"].ToString(),drItem["BatchCode"].ToString() ,drItem["Code"].ToString());
							if(!(dsItemDocs.Tables.Count > 0 && dsItemDocs.Tables[0].Rows.Count > 0))
							{
								string sItemCode = Service.FillToFiveChars(drItem["GroupCode"].ToString()) + "." +
									Service.FillToThreeChars(drItem["BatchCode"].ToString()) + "." +
									Service.FillToTwoChars(drItem["Code"].ToString());
								if(dsItemDocs.Tables.Count == 0)
								{
									dsItemDocs.Tables.Add(new DataTable());
									dsItemDocs.Tables[0].Columns.Add("ItemNumber");
									dsItemDocs.Tables[0].Columns.Add("Reports");
								}
								dsItemDocs.Tables[0].Rows.Add(new object[] {sItemCode,"Item Rejected"});
							}
							dsItemDocsName.Tables.Add(dsItemDocs.Tables[0].Copy());
							if(dsItemDocsName.Tables.Count>0)
								dsItemDocsName.Tables[dsItemDocsName.Tables.Count-1].TableName = "Table" + dsItemDocsName.Tables.Count.ToString();
							
							if(dsDoc != null)
							{
								sCountAndCanselledDocs = dsDoc.Tables[0].Rows[0][0].ToString().Split(' ');
								count += System.Convert.ToInt32(sCountAndCanselledDocs[0]);
								if(sCountAndCanselledDocs.Length > 1)
								{
									Service.ProxySendCancelledDocs(sCountAndCanselledDocs[1].Substring(1));
									//MessageBox.Show(this, "NOTE: The previously ordered document [" + sCountAndCanselledDocs[1].Substring(1) 
									//	+ "] has been cancelled.", "Cancelled documents", MessageBoxButtons.OK, MessageBoxIcon.Error);
								}
							}
							//dtItemsWithOpenRecheckSession.Rows.Add(drItem);
							dtItemsWithOpenRecheckSession.ImportRow(drItem);
						}
					}

#region BatchTracking
					if(dtItemsWithOpenRecheckSession.Rows.Count > 0)
					{
							foreach(DataRow dr in dtBatch.Rows)
							{
								DataRow[] drSet = dtItemsWithOpenRecheckSession.Select("NewBatchID = '" + dr["BatchID"].ToString() + "'");
								if(drSet.Length > 0)
								{
									object BatchID = dr["BatchID"];
									object EventID = GraderLib.BatchEvents.EndSession;
									object ItemsAffected = drSet.Length;
									object ItemsInBatch = dr["ItemsQuantity"];
									object FormID = GraderLib.Codes.AccRep;
									Service.SetBatchEvent(EventID, BatchID, FormID, ItemsAffected, ItemsInBatch);
								}
							}
					}
#endregion
					
					sDoc = count.ToString();
					//sd 10.25.2006				
					//"Do you want to print labels?"
					DialogResult res = MessageBox.Show(this,"Do you want to print labels?","",MessageBoxButtons.YesNo);
					if(res==DialogResult.Yes)
					try
					{
						AccountRep.AnalyzeAndPrint(dtItemsWithOpenRecheckSession);
					}
					catch(Exception ex)
					{
						MessageBox.Show(this,ex.Message,"Print error",MessageBoxButtons.OK,MessageBoxIcon.Error); 
					}
					//
					String sMessage = String.Format("End session is finished. {0} documents are ordered.", sDoc);
					MessageBox.Show(this, sMessage, "End session is finished.", 
						MessageBoxButtons.OK, MessageBoxIcon.Information);
					string msg = "";
					foreach(DataTable dt in dsItemDocsName.Tables)
					{
						string sItemNumber = "";
						string sReports = "";
						foreach(DataRow drDocName in dt.Rows)
						{
							sItemNumber = drDocName["ItemNumber"].ToString();
							sReports += (sReports == "")?drDocName["Reports"].ToString():" ," + drDocName["Reports"].ToString();
						}
						msg += sItemNumber + " : " + sReports + "\n";
					}
					if(msg != "")
						MessageBox.Show(this, msg, "Ordered Documents.",MessageBoxButtons.OK, MessageBoxIcon.Information);
					//DrawOpen();
					lbxItems.Items.Clear();
				}
				catch (Exception ex)
				{
					MessageBox.Show("Unable to end recheck session. Reason: " + ex.ToString(),
						"Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			else
				MessageBox.Show("At least one item must be checked to end session", "No batches are checked");
			
			sbStatus.Text = "Session was ended";
			this.Cursor = Cursors.Default;
		}

#endregion PrintAndEndSession
		

#region GoldEngraving
		private void button3_Click(object sender, System.EventArgs e)
		{
			//Gold Engraving
			Print_GoldEngraving_LaserInsription(true);			
		}
		private void button4_Click_1(object sender, System.EventArgs e)
		{
			//Laser Insription
			Print_GoldEngraving_LaserInsription(false);
		}

		private void Print_GoldEngraving_LaserInsription(bool isGold)
		{
			DataSet dsData = new DataSet();
			dsData = otOpenOrders.GetChecked().Copy();

			DataSet dsPrintSet = new DataSet();
			if(isGold)
				dsPrintSet.Tables.Add("GoldEngraving");
			else 
				dsPrintSet.Tables.Add("GoldEngraving");

			dsPrintSet.Tables[0].Columns.Add("Item",System.Type.GetType("System.String"));
			dsPrintSet.Tables[0].Columns.Add("Weight",System.Type.GetType("System.String"));
			dsPrintSet.Tables[0].Columns.Add("Color",System.Type.GetType("System.String"));
			dsPrintSet.Tables[0].Columns.Add("Clarity",System.Type.GetType("System.String"));
	
			try
			{
				string sWeigth = "";
				foreach(DataRow rBatch in dsData.Tables["tblBatch"].Rows)
				{
					sbStatus.Text = "Printing";
					dsPrintSet.Tables[0].Rows.Clear();

					DataRow [] rItems = dsData.Tables["tblItem"].Select("BatchID = " + rBatch["BatchID"].ToString());
					for (int i=0; i<rItems.Length;i++)
					{
						DataRow tRow = dsPrintSet.Tables[0].NewRow();
						tRow["Item"] = rItems[i]["Name"].ToString().Substring(6);
						if(rItems[i]["Weight"].ToString().Length>0)
						{
							sWeigth = rItems[i]["Weight"].ToString() + " " + rItems[i]["WeightUnitName"].ToString();
							tRow["Weight"] = sWeigth;
						}
						tRow["Color"] = rItems[i]["Color"].ToString();
						tRow["Clarity"] = rItems[i]["Clarity"].ToString();
						dsPrintSet.Tables[0].Rows.Add(tRow);
					}

					string sRepPath = Service.GetCRTemplatePath();
					CrystalReport.CrystalReport cr = new CrystalReport.CrystalReport(sRepPath);
					if(isGold)
						cr.GoldEngraving(dsPrintSet);
					else 
						cr.LaserInscription(dsPrintSet);

					cr.Print();

				}
				sbStatus.Text = "Printing complited";
			}
			catch(Exception ex)
			{
				sbStatus.Text = ex.Source.ToString() + ":" + ex.Message.ToString(); 
			}
		}
		
#endregion GoldEngraving

		private void pictureBox2_Paint(object sender, PaintEventArgs e)
		{
            try
            {
                if(((PictureBox)sender).Image==null) return;
                if(((PictureBox)sender).Image.Size.Height > ((PictureBox)sender).Size.Height || ((PictureBox)sender).Image.Size.Width > ((PictureBox)sender).Size.Width)
                {
                    Service.DrawAdjustShapeImage((PictureBox)sender,((PictureBox)sender).Image,-1,-1,0,0);
                    //((PictureBox)sender).SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    ((PictureBox)sender).SizeMode = PictureBoxSizeMode.CenterImage;
                }
            }
            catch{}
		}

#endregion Tab2

#region Tab3

		private DataSet GetCPByBatchID(string sBatchID)
		{
			try
			{
				// spGetCustomerProgramByBatchID 
				// @BatchID dnID

				DataSet dsIn = new DataSet();
				DataTable dtIn = dsIn.Tables.Add("CustomerProgramByBatchID");
				dtIn.Columns.Add("BatchID", System.Type.GetType("System.String"));
				DataRow row = dtIn.NewRow();

				row["BatchID"] = sBatchID;

				dtIn.Rows.Add(row);
				DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);
				//string sID = dsOut.Tables[0].Rows[0]["CPOfficeID_CPID"].ToString();
				//return sID;
				return dsOut;
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Can't get customer program id. Reason: " + ex.ToString(),
					"Internal error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			return null;
		}

		/*
		private bool IsOneBatch(DataSet ds)
		{
			string sBatch;
			string sPrevBatch;
			gemoDream.Service.debug_DiaspalyDataSet(ds);

			for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
			{
				if (i == 0)
					sPrevBatch = ds.Tables[0].Rows[0]["BatchID"].ToString();
				else
				{
					sBatch = ds.Tables[0].Rows[i]["BatchID"].ToString();
					if (sBatch.Equals(sPrevBatch))
						return false;
				}
			}
			return true;
		}
		*/

		private bool IsAllItemsAreInvalid(DataTable dt)
		{
			bool bRet = true;
			foreach (DataRow row in dt.Rows)
			{
				if (!row["StateCode"].ToString().Equals("3"))
				{
					bRet = false;
					break;
				}
			}
			return bRet;
		}

		//Tab3/Getting details for checked items
		private void bDetailsAdd_Click(object sender, System.EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			sbStatus.Text = "Getting items information from server...";

			//pnlDetails.Controls.Clear();
			try
			{
				//dtChecked = GetAllItems(otAllOrders);
				dtChecked = otAllOrders.GetChecked().Tables["tblItem"];

				//DataSet ds = new DataSet();
				//ds.Tables.Add(dtChecked.Copy());
				//gemoDream.Service.debug_DiaspalyDataSet(ds);

				if(dtChecked.Rows.Count == 0)
				{
					sbStatus.Text = "No items chosen";
					this.Cursor = Cursors.Default;
					return;
				}

				if (IsAllItemsAreInvalid(dtChecked))
				{
					sbStatus.Text = "All items are invalid";
					this.Cursor = Cursors.Default;
					return;
				}

				bool isDefDocFormNeeded = IsDefDocFormNeeded(dtChecked);
				string sItemTypeID = "";
				string sBatchID = "";
				string sCPOfficeID = "";
				string sCPID = "";

				sItemTypeID = dtChecked.Rows[0]["ItemTypeID"].ToString();
				sBatchID = dtChecked.Rows[0]["BatchID"].ToString();
				DataSet ds = GetCPByBatchID(sBatchID);//Procedure dbo.spGetCustomerProgramByBatchID
				string sCPOfficeID_CPID = ds.Tables[0].Rows[0]["CPOfficeID_CPID"].ToString();
				string sCPName = ds.Tables[0].Rows[0]["CustomerProgramName"].ToString();
				string[] s = sCPOfficeID_CPID.Split('_');
				sCPOfficeID = s[0];
				sCPID = s[1];

				//gemoDream.Service.debug_DiaspalyDataSet(dsAvailableOps);

				CommonDetails cdDialog;
				if (!isDefDocFormNeeded)
				{
					sbStatus.Text = "Please select one batch";
					this.Cursor = Cursors.Default;		
					return ;
					//dsAvailableOps = Service.GetDocs();//sCPOfficeID, sCPID);
					//cdDialog = new CommonDetails(this.AccessLevel, dsAvailableOps, isDefDocFormNeeded,
					//	sItemTypeID, sCPOfficeID, sCPID, sCPName);
				}
				else
				{
					//DataSet ds = Service.GetDocs(sCPOfficeID, sCPID);
					//gemoDream.Service.debug_DiaspalyDataSet(ds);
					//cdDialog = new CommonDetails(ds, isDefDocFormNeeded, sItemTypeID, sCPOfficeID, sCPID);
					dsAvailableOps = Service.GetCurrentDocs(sCPOfficeID, sCPID);//Procedure dbo.spGetCurrentDocsByCP
					cdDialog = new CommonDetails(this.AccessLevel, dsAvailableOps, isDefDocFormNeeded, 
						sItemTypeID, sCPOfficeID, sCPID, sCPName);
				}

				if(cdDialog.ShowDialog() == DialogResult.OK)
				{
					dsAvailableOps = Service.GetCurrentDocs(sCPOfficeID, sCPID);
					gemoDream.Service.Debug_DiaspalyDataSet(dsAvailableOps);
					//DataSet ds
					for(int i = 0; i < dtChecked.Rows.Count; i++)						
					{
						string sStateCode = dtChecked.Rows[i]["StateCode"].ToString();
						if (!sStateCode.Equals("3"))
						{
							string Code = dtChecked.Rows[i]["Name"].ToString();
							string iComboIndex = cdDialog.cbService.SelectedValue.ToString();
							string sLabelText = cdDialog.tbLabel.Text;
							//AddNewDetails(dtChecked.Rows[i]["Name"].ToString(), cdDialog.cbService.SelectedValue.ToString(), cdDialog.tbLabel.Text);
							this.AddNewDetails(Code, iComboIndex, sLabelText);
						}
						else
						{
							MessageBox.Show("Item " + dtChecked.Rows[i]["Name"].ToString() + " is blocked.","Measure Weight failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}
					//AddNewDetails2(ds, dtChecked.Rows[i]["Name"].ToString(), cdDialog.cbService.SelectedValue.ToString(), cdDialog.tbLabel.Text);
				}		
			}
			catch
			{
				sbStatus.Text = "No items are chosen";
				this.Cursor = Cursors.Default;
			}

			pnlDetails.Enabled = true;

			sbStatus.Text = "Ready";
			this.Cursor = Cursors.Default;		
		}

		//		private bool IsDefDocFormNeeded(DataTable dtChecked)
		//		{
		//			//DataSet ds = new DataSet();
		//			//ds.Tables.Add(dtChecked.Copy());
		//			//gemoDream.Service.debug_DiaspalyDataSet(ds);
		//			string sBatchID = "";
		//			string sTemp;
		//			for (int i = 0; i < dtChecked.Rows.Count; i++)
		//			{
		//				if (i == 0)
		//					sBatchID = dtChecked.Rows[i]["BatchID"].ToString();
		//				sTemp = dtChecked.Rows[i]["BatchID"].ToString();
		//				if (!sBatchID.Equals(sTemp))
		//					return false;
		//			}
		//
		//			return true;
		//		}

		private bool IsDefDocFormNeeded(DataTable dtChecked)
		{
			//DataSet ds = new DataSet();
			//ds.Tables.Add(dtChecked.Copy());
			//gemoDream.Service.debug_DiaspalyDataSet(ds);
			string sBatchID = "";
			string sTemp;
			for (int i = 0; i < dtChecked.Rows.Count; i++)
			{
				if (i == 0)
					sBatchID = dtChecked.Rows[i]["BatchID"].ToString();
				sTemp = dtChecked.Rows[i]["BatchID"].ToString();

				if (!sBatchID.Equals(sTemp))
					return false;
			}

			return true;
		}


		//Tab3/Trying to check non-item||order
		private void otAllOrders_WrongCheck(object sender, System.EventArgs e)
		{
			sbStatus.Text = "Only items can be checked within this tree";
		}


		//Tab3/Adding new details to Panel
		private void AddNewDetails(string Code, string iComboIndex, string sLabelText)
		{
			bool Exists = false;
			if(dtDocDetails.Select("ItemCode='" + Code + "' and DocID='" + iComboIndex + "'").Length == 0)
			{
				dtDocDetails.Rows.Add(new object[] { Code, iComboIndex, sLabelText });
				Exists = false;
			}
			else Exists = true;

			if(!Exists)
			{
				OrderDetails odNew;			
			
				odNew = new OrderDetails();

				odNew.tbItemCode.Text = Code;
				odNew.tbItemCode.Enabled = false;
				odNew.chbEnabled.Checked = true;
				odNew.tbLabel.Enabled = false;
				odNew.cbServiceType.SelectedIndexChanged += new EventHandler(cbServiceType_SelectedIndexChanged);
				odNew.cbServiceType.DataSource = dsAvailableOps.Tables[0];
				odNew.cbServiceType.DisplayMember = "OperationTypeName";
				//"OperationTypeName";
				odNew.cbServiceType.ValueMember = "OperationTypeOfficeID_OperationTypeID";

				if(pnlDetails.Controls.Count > 0)
					odNew.Location = new Point(5, 
						((OrderDetails)pnlDetails.Controls[pnlDetails.Controls.Count - 1]).Location.Y + 25);
				else
					odNew.Location = new Point(5, 5);

				pnlDetails.Controls.Add(odNew);	
				odNew.cbServiceType.SelectedValue = iComboIndex;
				odNew.tbLabel.Text = sLabelText;

				pnlDetails.Enabled = true;
				pnlDetails.ScrollControlIntoView(odNew);

				odNew.chbEnabled.CheckedChanged +=new EventHandler(chbEnabled_CheckedChanged);
			}
		}

		private void AddNewDetails2(DataSet dsNewOps, string Code, string iComboIndex, string sLabelText)
		{
			bool Exists = false;
			if(dtDocDetails.Select("ItemCode='" + Code + "' and DocID='" + iComboIndex + "'").Length == 0)
			{
				dtDocDetails.Rows.Add(new object[] { Code, iComboIndex, sLabelText });
				Exists = false;
			}
			else Exists = true;

			if(!Exists)
			{
				OrderDetails odNew;			
			
				odNew = new OrderDetails();

				odNew.tbItemCode.Text = Code;
				odNew.tbItemCode.Enabled = false;
				odNew.chbEnabled.Checked = true;
				odNew.tbLabel.Enabled = false;
				odNew.cbServiceType.SelectedIndexChanged += new EventHandler(cbServiceType_SelectedIndexChanged);
				odNew.cbServiceType.DataSource = dsNewOps.Tables[0];
				//dsAvailableOps.Tables[0];
				odNew.cbServiceType.DisplayMember = "OperationTypeName";
				odNew.cbServiceType.ValueMember = "OperationTypeOfficeID_OperationTypeID";

				if(pnlDetails.Controls.Count > 0)
					odNew.Location = new Point(5, 
						((OrderDetails)pnlDetails.Controls[pnlDetails.Controls.Count - 1]).Location.Y + 25);
				else
					odNew.Location = new Point(5, 5);

				pnlDetails.Controls.Add(odNew);	
				odNew.cbServiceType.SelectedValue = iComboIndex;
				odNew.tbLabel.Text = sLabelText;

				pnlDetails.Enabled = true;
				pnlDetails.ScrollControlIntoView(odNew);

				odNew.chbEnabled.CheckedChanged +=new EventHandler(chbEnabled_CheckedChanged);
			}
		}


		//Tab3/ On Details/Combo_SelectedIndexChanged/ running through all the controls
		//within Details Panel to find out if control with the same details exists
		private void cbServiceType_SelectedIndexChanged(object sender, EventArgs ea)
		{
			int iExists = 0;
			foreach(Control cntrl in pnlDetails.Controls)
			{
				if(((OrderDetails)cntrl).cbServiceType.SelectedIndex == ((ComboBox)sender).SelectedIndex &&
					((OrderDetails)cntrl).tbItemCode.Text == ((OrderDetails)((ComboBox)sender).Parent).tbItemCode.Text)
					iExists ++;
			}

			if(iExists > 1)
			{
				((ComboBox)sender).SelectedIndex = -1;
				sbStatus.Text = "Selected document or service already exists for this item";
			}

			try
			{
				DataRow[] drRows = dsAvailableOps.Tables[0].Select("OperationTypeOfficeID_OperationTypeID='" + ((ComboBox)sender).SelectedValue.ToString() + "'");
				if(drRows[0]["OperationTypeClass"].ToString() != "3")
				{
					((OrderDetails)((ComboBox)sender).Parent).tbLabel.Enabled = false;
					((OrderDetails)((ComboBox)sender).Parent).tbLabel.Text = "";
				}
				else
				{
					((OrderDetails)((ComboBox)sender).Parent).tbLabel.Enabled = true;
					((OrderDetails)((ComboBox)sender).Parent).tbLabel.Text = "";
				}
			}
			catch(Exception exc)
			{
				Console.WriteLine(exc.Message);
			}
		}
		
		private void chbEnabled_CheckedChanged(object sender, EventArgs ea)
		{
			try
			{
				DataRow[] drRows = dsAvailableOps.Tables[0].Select("OperationTypeOfficeID_OperationTypeID='" + ((OrderDetails)((CheckBox)sender).Parent).cbServiceType.SelectedValue.ToString() + "'");
				if(drRows[0]["OperationTypeClass"].ToString() != "3")
				{
					((OrderDetails)((CheckBox)sender).Parent).tbLabel.Enabled = false;
					((OrderDetails)((CheckBox)sender).Parent).tbLabel.Text = "";
				}
				else
				{
					((OrderDetails)((CheckBox)sender).Parent).tbLabel.Enabled = true;
					((OrderDetails)((CheckBox)sender).Parent).tbLabel.Text = "";
				}
			}
			catch(Exception exc)
			{
				Console.WriteLine(exc.Message);
			}
		}

		//Tab3/Getting All checked items
		private DataTable GetAllItems(OrdersTree otCurrent)
		{
			dtItem.Rows.Clear();
			foreach(DataRow drItem in otCurrent.dsOrderTree.Tables["tblItem"].Rows)
			{
				//DataTable dtItemsChecked = otCurrent.GetChecked().Tables["tblItem"];
				otCurrent.RealSelectNode(drItem["Name"].ToString());
				if(otCurrent.Selected.Checked)
					dtItem.Rows.Add(new object[] {otCurrent.Selected.drNode["ID"], otCurrent.Selected.drNode["ParentID"],
													 otCurrent.Selected.drNode["Name"], otCurrent.Selected.drNode["Code"]});
			}
			return dtItem;
		}
	

		//Tab3/Get all orders filtered by date
		private void bDetailsSelect_Click(object sender, System.EventArgs e)
		{
			sbStatus.Text = "Filtering orders by date";
			this.Cursor = Cursors.WaitCursor;
			otAllOrders.Clear();

			Couple cplCustomer = new Couple();
			cplCustomer.FieldName = "CustomerCode";
			cplCustomer.FieldValue = cbcCustomer.ComboField.drvSelectedItem[cbcCustomer.CodeMember].ToString();

			if(dtpUpdFrom.Value < dtpUpdTo.Value)
			{
				Couple cplDatesB = new Couple();
				cplDatesB.FieldName = "BDate";
				cplDatesB.FieldValue = dtpUpdFrom.Value.ToString();

				Couple cplDatesE = new Couple();
				cplDatesE.FieldName = "EDate";
				cplDatesE.FieldValue = dtpUpdTo.Value.ToString();

				otAllOrders.Initialize(Service.GetOrderTreeDataByCode(new Couple[] 
					{cplCustomer, cplDatesB, cplDatesE}));
			}
			else
			{
				if(dtpUpdFrom.Value.Year == dtpUpdTo.Value.Year && 
					dtpUpdFrom.Value.Month == dtpUpdTo.Value.Month &&
					dtpUpdFrom.Value.Day == dtpUpdTo.Value.Day)
				{
					try
					{
						otAllOrders.Initialize(Service.GetOrderTreeDataByCode(new Couple[] {cplCustomer}));
					}
					catch
					{
						MessageBox.Show("Unable to get data from server", "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				else 
					sbStatus.Text = "Searching start date must be less then end date";
			}
			this.Cursor = Cursors.Default;
			sbStatus.Text = "Ready";	
		}


		//Tab3 DateTimePickers handlers
		private void dtpUpdFrom_ValueChanged(object sender, System.EventArgs e)
		{
			dtpUpdFrom.Value = new DateTime(dtpUpdFrom.Value.Year, dtpUpdFrom.Value.Month, dtpUpdFrom.Value.Day, 0, 0, 0);
			dtpUpdTo.Value = new DateTime(dtpUpdTo.Value.Year, dtpUpdTo.Value.Month, dtpUpdTo.Value.Day, 23, 59, 59);
		}

		private void dtpUpdTo_ValueChanged(object sender, System.EventArgs e)
		{
			dtpUpdFrom.Value = new DateTime(dtpUpdFrom.Value.Year, dtpUpdFrom.Value.Month, dtpUpdFrom.Value.Day, 0, 0, 0);
			dtpUpdTo.Value = new DateTime(dtpUpdTo.Value.Year, dtpUpdTo.Value.Month, dtpUpdTo.Value.Day, 23, 59, 59);
		}


		//Tab3/Clear Details Panel
		private void bDetailsClear_Click(object sender, System.EventArgs e)
		{
			pnlDetails.Controls.Clear();
			dtDocDetails.Rows.Clear();
		}


		//Tab3/Update Items Details
		private void bDetailsUpdate_Click(object sender, System.EventArgs e)
		{
			StringBuilder sbExec = new StringBuilder();
			this.Cursor = Cursors.WaitCursor;
			sbStatus.Text = "Updating orders details";
			int i = 0;
			bool Exists;
			lvDocs.Items.Clear();
			DataTable dtItems = otAllOrders.GetChecked().Tables["tblItem"].Clone();
			DataTable dtBatch = otOpenOrders.Get().Tables["tblBatch"].Copy();

			foreach(Control cntrl in pnlDetails.Controls)
			{
				Exists = false;
				try
				{					
					DataSet dsItemOperationTypeOf = Service.GetItemOperationTypeOf(); //Procedure dbo.spGetItemOperationTypeOf
					dsItemOperationTypeOf.Tables["ItemOperationTypeOf"].TableName = "ItemOperation";
					
					string DataOperationChar = dsAvailableOps.Tables[0].Select("OperationTypeOfficeID_OperationTypeID='" + ((OrderDetails)cntrl).cbServiceType.SelectedValue.ToString() + "'")[0]["OperationChar"].ToString();
					string DataItemCode = dsAvailableOps.Tables[0].Select("OperationTypeOfficeID_OperationTypeID='" + ((OrderDetails)cntrl).cbServiceType.SelectedValue.ToString() + "'")[0]["OperationChar"].ToString() + ((OrderDetails)cntrl).tbItemCode.Text;					
			
					//gemoDream.Service.debug_DiaspalyDataSet(otAllOrders.dsOrderTree);
					

					if(otAllOrders.dsOrderTree.Tables["tblDocument"].Select("OperationChar='" + DataOperationChar + "' and Name='" + DataItemCode + "'").Length > 0)
						Exists = true;

					if(!Exists && ((OrderDetails)cntrl).chbEnabled.Checked == true)						
					{
						if(((OrderDetails)cntrl).tbLabel.Enabled && ((OrderDetails)cntrl).tbLabel.Text == "")
							continue;
						ListViewItem lviNext = new ListViewItem(new string[] {((OrderDetails)pnlDetails.Controls[i]).tbItemCode.Text, 
																				 dsAvailableOps.Tables[0].Select("OperationTypeOfficeID_OperationTypeID='" + ((OrderDetails)pnlDetails.Controls[i]).cbServiceType.SelectedValue.ToString() + "'")[0]["OperationTypeName"].ToString(), 
																				 ((OrderDetails)pnlDetails.Controls[i]).tbLabel.Text});

						dsItemOperationTypeOf.Tables["ItemOperation"].Rows.Add(dsItemOperationTypeOf.Tables["ItemOperation"].NewRow());

						string Code = ((OrderDetails)cntrl).tbItemCode.Text;
						otAllOrders.RealSelectNode(Code);
						string BatchID_ItemCode = otAllOrders.Selected.drNode["BatchID"].ToString() + "_" + otAllOrders.Selected.drNode["Code"].ToString();

						string OperationTypeOfficeID_OperationTypeID = ((OrderDetails)cntrl).cbServiceType.SelectedValue.ToString();

						dsItemOperationTypeOf.Tables["ItemOperation"].Rows[dsItemOperationTypeOf.Tables["ItemOperation"].Rows.Count - 1]["OperationTypeOfficeID_OperationTypeID"] = 
							OperationTypeOfficeID_OperationTypeID;
						dsItemOperationTypeOf.Tables["ItemOperation"].Rows[dsItemOperationTypeOf.Tables["ItemOperation"].Rows.Count - 1]["BatchID_ItemCode"] = 
							BatchID_ItemCode;
#if DEBUG
						// For debugging only			
						string filename = "C:/DELL/myXmlDocForAddDocuments.xml";
						if (File.Exists(filename)) File.Delete(filename);
						// Create the FileStream to write with.
						System.IO.FileStream myFileStream = new System.IO.FileStream(filename, System.IO.FileMode.Create);
						// Create an XmlTextWriter with the fileStream.
						System.Xml.XmlTextWriter myXmlWriter = new System.Xml.XmlTextWriter(myFileStream, System.Text.Encoding.Unicode);
						// Write to the file with the WriteXml method.
						dsItemOperationTypeOf.WriteXml(myXmlWriter);
						myXmlWriter.Close();
						// End of debugging part
#endif

						lvDocs.Items.Add(lviNext);						
					}					
				
					if(dsItemOperationTypeOf.Tables[0].Rows.Count > 0)
						try
						{
							Service.AddItemOperation(dsItemOperationTypeOf);//Procedure dbo.spAddItemOperation
						}
						catch{}				
				}				
				catch(Exception exc)
				{
					sbStatus.Text = "Unable to update order details";
					Console.WriteLine(exc.Message);
					this.Cursor = Cursors.Default;
					return;
				}
				i++;
			}
			if(otAllOrders.GetChecked().Tables["tblItem"].Rows.Count > 0)
				try
				{
					foreach(DataRow drItem in otAllOrders.GetChecked().Tables["tblItem"].Rows)
					{
						if(Service.GetCheckClossedRecheckSessionForItem(drItem["NewBatchID"].ToString(), drItem["NewItemCode"].ToString()).Tables[0].Rows[0][0].ToString() == "0")//dbo.spGetCheckClossedRecheckSessionForItem
						{
							DataSet dsDoc = Service.SetEndSession1(drItem["NewBatchID"].ToString(), drItem["NewItemCode"].ToString());
						}
						dtItems.ImportRow(drItem);
					}
					
#region BatchTracking

					foreach(DataRow dr in dtBatch.Rows)
						{
							DataRow[] drSet = dtItems.Select("NewBatchID = '" + dr["BatchID"].ToString() + "'");
							if(drSet.Length > 0)
							{
								object BatchID = dr["BatchID"];
								object EventID = GraderLib.BatchEvents.AddReport;
								object ItemsAffected = drSet.Length;
								object ItemsInBatch = dr["ItemsQuantity"];
								object FormID = GraderLib.Codes.AccRep;
								Service.SetBatchEvent(EventID, BatchID, FormID, ItemsAffected, ItemsInBatch);
							}
						}
#endregion

				}
				catch (Exception ex)
				{
					MessageBox.Show("Unable to end recheck session. Reason: " + ex.ToString(),
						"Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			else
				MessageBox.Show("At least one item must be checked to end session", "No batches are checked");

			otAllOrders.Clear();
			//bDetailsSelect_Click(this, EventArgs.Empty);			
			MessageBox.Show("Order details were updated successfully", "Details update");
			this.Cursor = Cursors.Default;
		}
		/*
		private void bDetailsUpdate_Click(object sender, System.EventArgs e)
		{
			StringBuilder sbExec = new StringBuilder();
			this.Cursor = Cursors.WaitCursor;
			sbStatus.Text = "Updating orders details";
			int i = 0;
			bool Exists;
			lvDocs.Items.Clear();

			foreach(Control cntrl in pnlDetails.Controls)
			{
				Exists = false;
				try
				{					
					DataSet dsItemOperationTypeOf = Service.GetItemOperationTypeOf();
					dsItemOperationTypeOf.Tables["ItemOperationTypeOf"].TableName = "ItemOperation";
					
					string DataOperationChar = dsAvailableOps.Tables[0].Select("OperationTypeOfficeID_OperationTypeID='" + ((OrderDetails)cntrl).cbServiceType.SelectedValue.ToString() + "'")[0]["OperationChar"].ToString();
					string DataItemCode = dsAvailableOps.Tables[0].Select("OperationTypeOfficeID_OperationTypeID='" + ((OrderDetails)cntrl).cbServiceType.SelectedValue.ToString() + "'")[0]["OperationChar"].ToString() + ((OrderDetails)cntrl).tbItemCode.Text;					
			
					if(otAllOrders.dsOrderTree.Tables["tblDocument"].Select("OperationChar='" + DataOperationChar + "' and Name='" + DataItemCode + "'").Length > 0)
						Exists = true;

					if(!Exists && ((OrderDetails)cntrl).chbEnabled.Checked == true)						
					{
						if(((OrderDetails)cntrl).tbLabel.Enabled && ((OrderDetails)cntrl).tbLabel.Text == "")
							continue;
						ListViewItem lviNext = new ListViewItem(new string[] {((OrderDetails)pnlDetails.Controls[i]).tbItemCode.Text, 
																 dsAvailableOps.Tables[0].Select("OperationTypeOfficeID_OperationTypeID='" + ((OrderDetails)pnlDetails.Controls[i]).cbServiceType.SelectedValue.ToString() + "'")[0]["OperationTypeName"].ToString(), 
																 ((OrderDetails)pnlDetails.Controls[i]).tbLabel.Text});

						dsItemOperationTypeOf.Tables["ItemOperation"].Rows.Add(dsItemOperationTypeOf.Tables["ItemOperation"].NewRow());

						string Code = ((OrderDetails)cntrl).tbItemCode.Text;
						otAllOrders.RealSelectNode(Code);
						string BatchID_ItemCode = otAllOrders.Selected.drNode["BatchID"].ToString() + "_" + otAllOrders.Selected.drNode["Code"].ToString();

						string OperationTypeOfficeID_OperationTypeID = ((OrderDetails)cntrl).cbServiceType.SelectedValue.ToString();

						dsItemOperationTypeOf.Tables["ItemOperation"].Rows[dsItemOperationTypeOf.Tables["ItemOperation"].Rows.Count - 1]["OperationTypeOfficeID_OperationTypeID"] = 
							OperationTypeOfficeID_OperationTypeID;
						dsItemOperationTypeOf.Tables["ItemOperation"].Rows[dsItemOperationTypeOf.Tables["ItemOperation"].Rows.Count - 1]["BatchID_ItemCode"] = 
							BatchID_ItemCode;					

						lvDocs.Items.Add(lviNext);						
					}					
				
					if(dsItemOperationTypeOf.Tables[0].Rows.Count > 0)
					try
					{
						Service.AddItemOperation(dsItemOperationTypeOf);
					}
					catch{}				
				}				
				catch(Exception exc)
				{
					sbStatus.Text = "Unable to update order details";
					Console.WriteLine(exc.Message);
					this.Cursor = Cursors.Default;
					return;
				}
				i++;
			}
			bDetailsSelect_Click(this, EventArgs.Empty);			
			MessageBox.Show("Order details were updated successfully", "Details update");
			this.Cursor = Cursors.Default;
		}
		*/


		//Tab3/Clear AllOrders-tree
		private void bUpdOrdOrdersClear_Click(object sender, System.EventArgs e)
		{
			otAllOrders.Clear();
		}


		//Double-clicking an item
		private void otAllOrders_RealDoubleClick(object sender, System.EventArgs e)
		{
			if(otAllOrders.Selected.tblName == "tblItem")
				if(!otAllOrders.Selected.drNode["StateCode"].ToString().Equals("3"))
				{
					AddNewDetails(otAllOrders.Selected.drNode["Name"].ToString(), "0", "");
				}
				else
				{
					MessageBox.Show("Item " + otAllOrders.Selected.drNode["Name"].ToString() + " is blocked.","Measure Weight failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
		}

#region ReadingBarCode
		private void tbOrderName_TextChanged(object sender, System.EventArgs e)
		{
			if(tbOrderName.Text.Length == 5)
			{
				tbOrderName.Text += tbOrderName.Text;
				tbOrderName.Text = tbOrderName.Text.Insert(5, ".");
				tbOrderName.SelectionStart = 11;
				tbOrderName.SelectionLength = 0;
				tmr.Start();
				//tbOrderName.SelectAll();
			}
		}

		private void tbItemName_TextChanged(object sender, System.EventArgs e)
		{
			if(tbItemName.Text.Length == 5)
			{
				tbItemName.Text += "." + tbItemName.Text;
				tbItemName.SelectionStart = 11;
				tbItemName.SelectionLength = 0;
			}
			if(tbItemName.Text.Length == 16)
			{				
				tbItemName.Text = tbItemName.Text.Insert(11, ".");
				tbItemName.Text = tbItemName.Text.Insert(15, ".");
				try
				{
					int GroupCode = Convert.ToInt32(tbItemName.Text.Substring(0, 5));
					int BatchCode = Convert.ToInt32(tbItemName.Text.Substring(12, 3));
					int ItemCode = Convert.ToInt32(tbItemName.Text.Substring(16, 2));
					//otAllOrders.SelectNode(GroupCode.ToString() + "." + GroupCode.ToString() + "." +
					//	BatchCode.ToString() + "." + ItemCode.ToString());
					otAllOrders.SelectNode(tbItemName.Text);

					AddNewDetails(tbItemName.Text.Substring(0, 5) + "." + tbItemName.Text.Substring(0, 5) + "." +
						tbItemName.Text.Substring(12, 3) + "." + tbItemName.Text.Substring(16, 2), 
						"0", "");
				}
				catch
				{
					sbStatus.Text = "Couldn't find pointed item at the orders tree";
				}
			}
		}

		private void tbOrderName_Enter(object sender, System.EventArgs e)
		{
			sbStatus.Text = "Reading barcode...";
			tbOrderName.Clear();
		}

		private void tbItemName_Enter(object sender, System.EventArgs e)
		{
			sbStatus.Text = "Reading barcode...";
			tmr.Stop();
		}

		private void tbOrderName_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{			
			if(tbOrderName.Text.Length == 11)
			{				
				e.Handled = true;

				tbItemName.Text = tbOrderName.Text + e.KeyChar;
				//tbOrderName.Text = "";				
				tbItemName.SelectionStart = 12;
				tbItemName.SelectionLength = 0;				
				tbItemName.Focus();
			}
		}

		private void tmr_Tick(object sender, EventArgs e)
		{
			tmr.Stop();
			try
			{
				int GroupCode = Convert.ToInt32(tbOrderName.Text.Substring(0, 5));
				//otAllOrders.SelectNode(GroupCode.ToString() + "." + GroupCode.ToString());
				otAllOrders.SelectNode(tbOrderName.Text);

				bool IsDefDocFormNeeded = false;

				CommonDetails cdDialog = new CommonDetails(this.AccessLevel, dsAvailableOps, IsDefDocFormNeeded, null, null, null, null);
				if(cdDialog.ShowDialog() == DialogResult.OK)
					WorkItems(otAllOrders.Selected, cdDialog.cbService.SelectedValue.ToString(), cdDialog.tbLabel.Text);
			}
			catch
			{
				sbStatus.Text = "Couldn't find pointed item at the orders tree";
			}
		}

		private void WorkItems(OrderNode noTemp, string iNdex, string sLabel)
		{
			if(noTemp.tblName == "tblItem")
			{
				for(int j = 0; j < noTemp.Nodes.Count; j++)
				{					
					AddNewDetails(noTemp.Text, iNdex, sLabel);
				}			
			}
				
			else 
				for(int i = 0; i < noTemp.Nodes.Count; i++)
					WorkItems((OrderNode)noTemp.Nodes[i], iNdex, sLabel);
		}		
		

#endregion ReadingBarCode
#endregion Tab3		

#region StatusBar
		private void bFax_Click(object sender, System.EventArgs e)
		{

			button13_Click(sender,e);

#region Old
			StringBuilder sb = new StringBuilder();
			sbStatus.Text = "Sending fax";
			this.Cursor = Cursors.WaitCursor;			

			if(cbcCustomer.SelectedCode == "" || cbcCustomer.SelectedCode == "0")
			{
				MessageBox.Show("Customer must be selected for the operation.", "Customer is not selected", 
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				this.Cursor = Cursors.Default;
				sbStatus.Text = "Fax was not sent";
				return;
			}

			DataSet dsData=otOpenOrders.Get();
			
			
			if(dsData.Tables.Count == 0 || dsData.Tables[0].Rows.Count == 0)
				sbStatus.Text = "At least one item must be chosen for this operation";
			else
				if(comboBox2.SelectedItem == null)
				sbStatus.Text = "File extension must be chosen for this operation";			
			else
				if(cbPersons.SelectedItem == null)
				sbStatus.Text = "Person with existing e-mail must be chosen";
			else
			{
				DataTable dtItems = dsData.Tables["tblItem"].Copy();
				dtItems.Columns.Add("Dimensions");
				dtItems.Columns.Add("CustomerName");
				int count = 0;
				string sDimensions = "";
				string customerName = "";
				string sDMax = "";
				string sDMin = "";
				string sH_x = "";
				string sLength="";
				string sMax="";
				string sMin="";
				string sDepth="";
				string sFullName="";
				string sFileName=""; 
				string sSendPath = Service.GetServiceCfgParameter("sendDir");

				string email = dtPerson.Select("PersonCode='" + cbPersons.SelectedValue.ToString() + "'")[0]["Email"].ToString();
				string sStatusText="";

				//////////////////
				bool isTextFile=false;
				if(comboBox2.SelectedIndex==2)
					isTextFile=true;


				DataSet dsItem=new DataSet();

				
				dtItems.Columns.Add("Depth",System.Type.GetType("System.String"));

				DataTable dtFile = new DataTable();
				dtFile.Columns.Add("Order No",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Batch No",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Report No",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Lot No",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Memo No",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Shape",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Length",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Max",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Width",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Min",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Depth/Hx",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Hx",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Weight",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Depth",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Table",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Pavilion",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Crown",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Girdle",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Girdle Condition",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Culet Size",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Polish",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Symmetry",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Clarity",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Potential Clarity",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Color",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Fluorescence",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Fluorescence Color",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Color Description",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Comments",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Description",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Key To Symbols",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Special Instructions",System.Type.GetType("System.String"));
				dtFile.Columns.Add("PartTypeId",System.Type.GetType("System.String"));

				DataTable dtFinal = new DataTable();
				dtFinal.Columns.Add("Order No",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Batch No",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Report No",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Lot No",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Memo No",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Shape",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Length",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Width",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Depth/Hx",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Weight",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Depth",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Table",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Pavilion",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Crown",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Girdle",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Girdle Condition",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Culet Size",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Polish",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Symmetry",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Clarity",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Potential Clarity",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Color",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Fluorescence",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Fluorescence Color",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Color Description",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Comments",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Description",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Key To Symbols",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Special Instructions",System.Type.GetType("System.String"));
				////////////////

				try
				{
					

					foreach(DataRow dr in dsData.Tables["tblItem"].Rows)
					{
						sb.Append(dr["Name"].ToString()).Append("; ");					

						DataSet dsPartValueTypeEx = Service.GetPartValueTypeEx();
						DataSet dsPartValueType = dsPartValueTypeEx.Copy();
						dsPartValueType.Tables["PartValueTypeEx"].TableName = "PartValue";
						dsPartValueType.Tables["PartValue"].Rows.Add(dsPartValueType.Tables["PartValue"].NewRow());
						//dsPartValueType.Tables["PartValue"].Rows[0]["PartID"] = iContainerID;
						dsPartValueType.Tables["PartValue"].Rows[0]["RecheckNumber"] = -1;
						/* sd 25.12.2006
						dsPartValueType.Tables["PartValue"].Rows[0]["BatchID"] = dr["BatchID"];
						dsPartValueType.Tables["PartValue"].Rows[0]["ItemCode"] = dr["Code"];
						*/
						dsPartValueType.Tables["PartValue"].Rows[0]["BatchID"] = dr["NewBatchID"];
						dsPartValueType.Tables["PartValue"].Rows[0]["ItemCode"] = dr["NewItemCode"];


						dsPartValueType.Tables["PartValue"].Rows[0]["ViewAccessCode"] = DBNull.Value;
						dsPartValueType = Service.GetPartValueType(dsPartValueType);

						DataTable dtPartValues = dsPartValueType.Tables[0].Copy();
						
						DataSet dsItem1=Service.ProxyGenericGetById(dr["BatchID"].ToString()+"_"+dr["Code"].ToString(),"Item");
						
						dtItems.Rows[count]["LotNumber"]=dsItem1.Tables[0].Rows[0]["LotNumber"].ToString();		
						dtItems.Rows[count]["Weight"] = dsItem1.Tables[0].Rows[0]["Weight"] == DBNull.Value ? 0 : dsItem1.Tables[0].Rows[0]["Weight"];

						foreach(DataRow drRow in dtPartValues.Rows)
						{
							try
							{
								sDMax = Convert.ToDouble(Service.GetMeasureValue("DimensionMax", dtPartValues, drRow["PartID"].ToString())).ToString(".##");
								sDMin = Convert.ToDouble(Service.GetMeasureValue("DimensionMin", dtPartValues, drRow["PartID"].ToString())).ToString(".##");
								sH_x = Convert.ToDouble(Service.GetMeasureValue("H_x", dtPartValues, drRow["PartID"].ToString())).ToString(".##");
								if(sDMax != "" && sDMin != "" && sH_x != "")
								{
									sDimensions=sDMax+"-"+sDMin+" x "+sH_x + " mm";
									break;
								}
							}
							catch
							{
								sDimensions = "";
							}
							if(sDimensions.Length==0)
							{
								try
								{
									sDimensions=Convert.ToDouble(Service.GetMeasureValue("Depth", dtPartValues, drRow["PartID"].ToString())).ToString(".##");
								}
								catch
								{}
							}

						}

						

						dtItems.Rows[count]["Dimensions"] = sDimensions;
						customerName = cbcCustomer.ComboField.drvSelectedItem[cbcCustomer.DisplayMember].ToString();
						customerName = customerName.Substring(0, customerName.Length - 7);
						dtItems.Rows[count]["CustomerName"] = customerName;
						count++;

						////////////////////////////////
						//Text File
						

						//if(isTextFile)
						//{
						DataTable tblParts=Service.GetParts(dr["ItemTypeID"].ToString()); 
						
						DataSet dsBatch=gemoDream.Service.ProxyGenericGetById(dr["BatchID"].ToString(),"Batch");
						DataSet	dsGroup=gemoDream.Service.ProxyGenericGetById(dsBatch.Tables[0].Rows[0]["GroupOfficeID_GroupID"].ToString(),"Group");
						

						foreach(DataRow rPart in tblParts.Rows)
						{
							
							DataRow rFile = dtFile.NewRow();
							rFile["Order No"]=Service.FillToFiveChars(dr["OrderCode"].ToString());
							rFile["Batch No"]=Service.FillToThreeChars(dr["BatchCode"].ToString());
								
							rFile["Report No"]=dr["Name"].ToString().Replace(".","").Substring(5);

							rFile["Lot No"]=dr["LotNumber"].ToString();
							rFile["Memo No"]=dsData.Tables["tblBatch"].Select("BatchID='"+dr["BatchID"].ToString()+"'")[0]["MemoNumber"].ToString();  // такого поля пока нет в базе

							DataSet dsShape = new DataSet();
							try
							{
								int iShapeCode=Convert.ToInt32(dr["Shape"].ToString());
								dsShape = Service.GetShapeByCode(iShapeCode);
								rFile["Shape"]=dsShape.Tables[0].Rows[0]["LongReportName"].ToString();
							}
							catch
							{
								rFile["Shape"]="";
							}
							
								
												
							sMax = Service.GetMeasureValue("Max", dtPartValues, rPart["ID"].ToString());
							sMin = Service.GetMeasureValue("Min", dtPartValues, rPart["ID"].ToString());
							sDepth = Service.GetMeasureValue("Depth", dtPartValues, rPart["ID"].ToString());
							sDepth = Service.GetMeasureValueByMeasureCode("14", dtPartValues, rPart["ID"].ToString());
							sH_x = Service.GetMeasureValue("H_x", dtPartValues, rPart["ID"].ToString());
							sH_x = Service.GetMeasureValueByMeasureCode("13", dtPartValues, rPart["ID"].ToString());

							try
							{
								rFile["Length"]=Convert.ToDouble(Service.GetMeasureValue("Max", dtPartValues, rPart["ID"].ToString())).ToString(".##");
									
							}
							catch
							{
								rFile["Length"]=Service.GetMeasureValue("Max", dtPartValues, rPart["ID"].ToString());//"";
							}

							try
							{
									
								rFile["Max"]=Convert.ToDouble(sMax).ToString(".##");
							}
							catch
							{
								rFile["Max"]="";
							}

							try
							{
								rFile["Width"]=Convert.ToDouble(Service.GetMeasureValue("Min", dtPartValues, rPart["ID"].ToString())).ToString(".##");
									
							}
							catch
							{
								rFile["Width"]="";
							}
							try
							{
								rFile["Min"]=Convert.ToDouble(sMin).ToString(".##");

							}
							catch
							{
								rFile["Min"]="";
							}

							try
							{
								rFile["Depth/Hx"]=Convert.ToDouble(sH_x).ToString(".##");
							}
							catch
							{
								rFile["Depth/Hx"]="";
							}

							try
							{
								rFile["Hx"]=Convert.ToDouble(sH_x).ToString(".##");
							}
							catch
							{
								rFile["Hx"]="";
							}

							rFile["Weight"]=dr["Weight"].ToString()+" "+dr["WeightUnitName"].ToString();
							try
							{
								rFile["Depth"]=Convert.ToDouble(sDepth).ToString(".##")+"%";
							}
							catch
							{
								rFile["Depth"]="";
							}

							rFile["Table"]=Service.GetMeasureValue("Tab_D", dtPartValues, rPart["ID"].ToString());
							rFile["Pavilion"]=Service.GetMeasureValue("Pav_D", dtPartValues, rPart["ID"].ToString());
							rFile["Crown"]=Service.GetMeasureValue("Crown_H", dtPartValues, rPart["ID"].ToString());
							rFile["Girdle"]=Service.GetMeasureValue("GirdleType", dtPartValues, rPart["ID"].ToString());
							rFile["Girdle Condition"]=Service.GetMeasureValue("GirdleType", dtPartValues, rPart["ID"].ToString());
							rFile["Culet Size"]=Service.GetMeasureValue("Culet Size", dtPartValues, rPart["ID"].ToString());
							rFile["Polish"]=Service.GetMeasureValue("Polish", dtPartValues, rPart["ID"].ToString());
							rFile["Symmetry"]=Service.GetMeasureValue("Symmetry", dtPartValues, rPart["ID"].ToString());

							rFile["Clarity"]=dr["Clarity"].ToString();//Service.GetMeasureValue("Clarity Grade", dtPartValues, rPart["ID"].ToString());
							rFile["Potential Clarity"]=Service.GetMeasureValue("Clarity Potential", dtPartValues, rPart["ID"].ToString());
							rFile["Color"]=dr["Color"].ToString();//Service.GetMeasureValue("Color Grade", dtPartValues, rPart["ID"].ToString());

							DataRow [] rFluor=dtPartValues.Select("PartId="+rPart["ID"].ToString()+" and MeasureCode=28");
							if(rFluor.Length>0)
								rFile["Fluorescence"]= rFluor[0]["ValueTitle"].ToString(); //Service.GetMeasureValue("LW Flourescence", dtPartValues, rPart["ID"].ToString());

							DataRow [] rFluorCol=dtPartValues.Select("PartId="+rPart["ID"].ToString()+" and MeasureCode=90");
							if(rFluorCol.Length>0)
								rFile["Fluorescence Color"]=rFluorCol[0]["ValueTitle"].ToString(); //Service.GetMeasureValue("Fluorescence Color", dtPartValues, rPart["ID"].ToString());

							rFile["Color Description"]=Service.GetMeasureValue("Color stone color", dtPartValues, rPart["ID"].ToString());
							rFile["Comments"]=dr["ItemComment"].ToString();
							rFile["Description"]=Service.GetMeasureValue("Description", dtPartValues, rPart["ID"].ToString());
							rFile["Key To Symbols"]="";
							rFile["Special Instructions"]=dsGroup.Tables[0].Rows[0]["SpecialInstruction"].ToString();
							rFile["PartTypeId"]=rPart["PartTypeId"].ToString();

							dtFile.Rows.Add(rFile);
					

						}	
						//sLength = Service.GetMeasureValue("Length",drPartValue,dRow["PartID"].ToString());
						
						dtFinal.Rows.Add(EditDataTable(dtFile).ItemArray);
						dtFile.Rows.Clear();
						sFileName="sp"+Service.FillToFiveChars(dtFinal.Rows[0]["Order No"].ToString())+Service.FillToThreeChars(dtFinal.Rows[0]["Batch No"].ToString());
							
								
						sFullName=sSendPath+sFileName+"."+"txt";
					
						//		SaveDataTabletToTabDelimFile(dtFinal,sFullName);
						if(email.Length>0)
						{
							Service.SendBatchByFax(sFileName+".txt",email,sFileName);//,sb.ToString());
							sStatusText = "E-mail was sent succesfully";
						}
							

						//dtFinal.Rows.Clear();
						//	}


						
					}
					
					SaveDataTabletToTabDelimFile(dtFinal,sSendPath,email);
					///////////////////////////////

					
					if(!isTextFile)
					{
						if(email.Length>0 )
						{
							Service.SendBatchByFax(dtItems, comboBox2.SelectedItem.ToString().ToLower(), email, sb.ToString(),sFileName);
							
							sStatusText = "E-mail was sent succesfully";
						
						}
						else 
						{
							sStatusText = "Messenger does not have an e-mail address";
							if(isTextFile)
							{
								try
								{
									//	System.IO.File.Delete(sFullName);
								}
								catch{}
							}
						}
					}
					sbStatus.Text = sStatusText;
				}
				catch(Exception ex)
				{
					MessageBox.Show("Unable to send e-mail. Make sure that SMTP is on.", "E-mail was not sent", MessageBoxButtons.OK, MessageBoxIcon.Error);
					sbStatus.Text = "E-mail was not sent. Make sure that e-mail address is correct and SMTP server is up";					
				}
			}
			this.Cursor = Cursors.Default;
#endregion

		}

		private void button13_Click(object sender, System.EventArgs e)
		{
			StringBuilder sb = new StringBuilder();
			sbStatus.Text = "Sending E-mail";
			this.Cursor = Cursors.WaitCursor;

			if(cbcCustomer.SelectedCode == "" || cbcCustomer.SelectedCode == "0")
			{
				MessageBox.Show("Customer must be selected for the operation.", "Customer is not selected", 
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				this.Cursor = Cursors.Default;
				sbStatus.Text = "E-mail was not sent";
				return;
			}

			DataSet dsData=otOpenOrders.Get();
						
			if(dsData.Tables.Count == 0 || dsData.Tables[0].Rows.Count == 0)
				sbStatus.Text = "At least one item must be chosen for this operation";
			else
				if(comboBox2.SelectedItem == null)
				sbStatus.Text = "File extension must be chosen for this operation";			
			else
				if(cbPersons.SelectedItem == null)
				sbStatus.Text = "Person with existing e-mail must be chosen";
			else if (comboBox2.Text == "Excel, *.xls")
			{
				if(otOpenOrders.GetChecked().Tables["tblItem"].Rows.Count == 0)
				{
					sbStatus.Text = "At least one item must be chosen for this operation";
				}
				else
				{		
					StringBuilder badMail = new StringBuilder();
					//by vetal_242
					//08.09.2006
					Hashtable hBatchCount = new Hashtable();
					Hashtable hDocsCount = new Hashtable();
					foreach(DataRow dr in otOpenOrders.GetChecked().Tables["tblItem"].Rows)
					{
						hBatchCount[dr["BatchID"].ToString()] = null;
					}
					string [,] BatchDock = new string[2, hBatchCount.Count];
					int batchIndex = 0;
					foreach(string batchID in hBatchCount.Keys)
					{
						DataSet dsDocs =  gemoDream.Service.GetDocumentIDByBatchID(batchID);//dbo.spGetDocumentTypeCodeByBatchID
						DataRow []drDocs = dsDocs.Tables[0].Select("DocumentTypeCode=10");
						if(drDocs.Length != 0)
						{
							hDocsCount[drDocs[0]["DocumentID"].ToString()] = batchID;
							BatchDock[0, batchIndex] = batchID;
							BatchDock[1, batchIndex] = drDocs[0]["DocumentID"].ToString();
						}
						else
						{
							BatchDock[0, batchIndex] = batchID;
							BatchDock[1, batchIndex] = "-1";
							DataRow []dr = otOpenOrders.GetChecked().Tables["tblItem"].Select("BatchID = " + batchID);
							MessageBox.Show(this, "The batch {" + Service.FillToFiveChars(dr[0]["OrderCode"].ToString()) +
								Service.FillToThreeChars(dr[0]["BatchCode"].ToString()) +
								"} doesn't contain items with attached documents of Excel format", "Create Excel-document error", MessageBoxButtons.OK, MessageBoxIcon.Error);				
							if(badMail.Length != 0)
								badMail.Append(", ");
							badMail.Append(Service.FillToFiveChars(dr[0]["OrderCode"].ToString()) + 
								Service.FillToThreeChars(dr[0]["BatchCode"].ToString()));
							badMail.Append(".xsl");
						}
						batchIndex++;
					}

					foreach(string sDockID in hDocsCount.Keys)
					{
						ArrayList alBatchID = new ArrayList();
						for(int i = 0; i < hBatchCount.Count; i++)
						{
							if(BatchDock[1, i].ToString() == sDockID)
							{
								alBatchID.Add(BatchDock[0, i].ToString());
							}
						}
						alBatchID.Sort();
						string subject;
						string email = dtPerson.Select("PersonCode='" + cbPersons.SelectedValue.ToString() + "'")[0]["Email"].ToString();
						CrystalReport.CrystalReport crReport;
						string sRepPath = Client.GetOfficeDirPath("repDir");
						//string sRepPath = Service.GetCRTemplatePath();
						//string sSendPath = Service.GetServiceCfgParameter("sendDir");
						string sSendPath = Client.GetOfficeDirPath("sendDir");

						string sLocatPath =  sSendPath; //  Service.GetServiceCfgParameter("locSendDir");
						crReport = new CrystalReport.CrystalReport(sRepPath);
						try
						{
							subject =  crReport.CreateMyXL(sDockID, alBatchID,
								otOpenOrders.GetChecked().Tables["tblItem"], sSendPath);
							sLocatPath = sLocatPath + subject;
														
							try
							{
								Service.ProxySendXLEmail(email, sLocatPath, subject.Split('.')[0]);
							}
							catch(Exception eEx)
							{
								if(eEx.Message.IndexOf("Session doesn't exist or expired. Retry to log on") == -1)
									throw eEx;
								else
								{
									StringBuilder wsName = new StringBuilder();
									for(int i = 0; i< alBatchID.Count; i++)
									{
										DataRow []drTemp = otOpenOrders.GetChecked().Tables["tblItem"].Select("BatchID = " + alBatchID[i].ToString());
										if(wsName.Length != 0)
										{
											wsName.Append(" ");
										}
										wsName.Append(Service.FillToFiveChars(drTemp[0]["OrderCode"].ToString()) + Service.FillToThreeChars(drTemp[0]["BatchCode"].ToString()));
									}
									if(badMail.Length != 0)
										badMail.Append(", ");
									badMail.Append(wsName);
									badMail.Append(".xsl");
								}
							}							
						}
						catch(Exception exce)
						{
							MessageBox.Show(this, exce.Message, "Create Excel-document error", MessageBoxButtons.OK, MessageBoxIcon.Error);							
							StringBuilder wsName = new StringBuilder();
							for(int i = 0; i< alBatchID.Count; i++)
							{
								DataRow []drTemp = otOpenOrders.GetChecked().Tables["tblItem"].Select("BatchID = " + alBatchID[i].ToString());
								if(wsName.Length != 0)
								{
									wsName.Append(" ");
								}
								wsName.Append(Service.FillToFiveChars(drTemp[0]["OrderCode"].ToString()) + Service.FillToThreeChars(drTemp[0]["BatchCode"].ToString()));
							}
							if(badMail.Length != 0)
								badMail.Append(", ");
							badMail.Append(wsName);
							badMail.Append(".xsl");						}
					}
					
					if(badMail.Length == 0)
						MessageBox.Show(this, "Emails sent", "Emails sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
					else
					{
						MessageBox.Show(this, badMail.ToString() + " not send", "Emails sent error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					this.Cursor = Cursors.Default;
					this.sbStatus.Text = "Ready";
				}
			}
			else
			{
				DataTable dtItems = dsData.Tables["tblItem"].Copy();
				dtItems.Columns.Add("Dimensions");
				dtItems.Columns.Add("CustomerName");
				int count = 0;
				string sDimensions = "";
				string customerName = "";
				string sDMax = "";
				string sDMin = "";
				string sH_x = "";
				string sLength="";
				string sMax="";
				string sMin="";
				string sDepth="";
				string sFullName="";
				string sFileName=""; 
				string sItemContanierWeight="";
				string sDiamondWeight="";
				bool isTotalWeight=true;
				string sSendPath = Service.GetServiceCfgParameter("sendDir");
				string sTempWeight="";

				string email = dtPerson.Select("PersonCode='" + cbPersons.SelectedValue.ToString() + "'")[0]["Email"].ToString();
				string sStatusText="";
				bool isWeightException=false;

				//////////////////
				bool isTextFile=false;
				if(comboBox2.SelectedIndex==2)
					isTextFile=true;


				DataSet dsItem=new DataSet();

				
				dtItems.Columns.Add("Depth",System.Type.GetType("System.String"));

				DataTable dtFile = new DataTable();
				dtFile.Columns.Add("Order No",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Batch No",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Report No",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Lot No",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Memo No",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Shape",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Length",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Max",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Width",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Min",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Depth/Hx",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Hx",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Weight",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Depth",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Table",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Pavilion",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Crown",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Girdle",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Girdle Condition",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Culet Size",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Polish",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Symmetry",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Clarity",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Potential Clarity",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Color",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Fluorescence",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Fluorescence Color",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Color Description",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Comments",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Description",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Key To Symbols",System.Type.GetType("System.String"));
				dtFile.Columns.Add("Special Instructions",System.Type.GetType("System.String"));
				dtFile.Columns.Add("PartTypeId",System.Type.GetType("System.String"));

				DataTable dtFinal = new DataTable();
				dtFinal.Columns.Add("Order No",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Batch No",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Report No",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Lot No",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Memo No",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Shape",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Length",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Width",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Depth/Hx",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Weight",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Depth",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Table",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Pavilion",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Crown",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Girdle",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Girdle Condition",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Culet Size",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Polish",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Symmetry",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Clarity",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Potential Clarity",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Color",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Fluorescence",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Fluorescence Color",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Color Description",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Comments",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Description",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Key To Symbols",System.Type.GetType("System.String"));
				dtFinal.Columns.Add("Special Instructions",System.Type.GetType("System.String"));
				////////////////

				if(isTextFile)
				{
					PrintingOptions frmPrintingOptions = new PrintingOptions();
					frmPrintingOptions.Text="Short Report Options";
					frmPrintingOptions.ShowDialog();
					isTotalWeight=frmPrintingOptions.IsTotalWeight;					
				}

				try
				{

					foreach(DataRow dr in dsData.Tables["tblItem"].Rows)
					{
						sb.Append(dr["Name"].ToString()).Append("; ");					

						DataSet dsPartValueTypeEx = Service.GetPartValueTypeEx();
						DataSet dsPartValueType = dsPartValueTypeEx.Copy();
						dsPartValueType.Tables["PartValueTypeEx"].TableName = "PartValue";
						dsPartValueType.Tables["PartValue"].Rows.Add(dsPartValueType.Tables["PartValue"].NewRow());
						//dsPartValueType.Tables["PartValue"].Rows[0]["PartID"] = iContainerID;
						dsPartValueType.Tables["PartValue"].Rows[0]["RecheckNumber"] = -1;
						/* sd 25.12.2006
						dsPartValueType.Tables["PartValue"].Rows[0]["BatchID"] = dr["BatchID"];
						dsPartValueType.Tables["PartValue"].Rows[0]["ItemCode"] = dr["Code"];
						*/
						dsPartValueType.Tables["PartValue"].Rows[0]["BatchID"] = dr["NewBatchID"];
						dsPartValueType.Tables["PartValue"].Rows[0]["ItemCode"] = dr["NewItemCode"];
						
						dsPartValueType.Tables["PartValue"].Rows[0]["ViewAccessCode"] = DBNull.Value;
						dsPartValueType = Service.GetPartValueType(dsPartValueType);

						DataTable dtPartValues = dsPartValueType.Tables[0].Copy();
						
						DataSet dsItem1=Service.ProxyGenericGetById(dr["BatchID"].ToString()+"_"+dr["Code"].ToString(),"Item");
						
						dtItems.Rows[count]["LotNumber"]=dsItem1.Tables[0].Rows[0]["LotNumber"].ToString();		
						dtItems.Rows[count]["Weight"] = dsItem1.Tables[0].Rows[0]["Weight"] == DBNull.Value ? 0 : dsItem1.Tables[0].Rows[0]["Weight"];

#region Get ItemContanier&DiamondWeigth
						DataTable dtParts = gemoDream.Service.GetParts(dtItems.Rows[count]["ItemTypeId"].ToString());
			
						DataSet dsIn1 = new DataSet();
						dsIn1.Tables.Add("PartTypes");
						DataSet dsPartTypes = gemoDream.Service.ProxyGenericGet(dsIn1);
						try
						{
							DataRow [] drPartTypeDiamondId = dsPartTypes.Tables[0].Select("PartTypeCode=1"); //Get 'Diamond' PartTypeId
							DataRow [] drPartTypeItemContainerId = dsPartTypes.Tables[0].Select("PartTypeCode=15"); //Get 'ItemContainer' PartTypeId
			
							DataRow [] drItemContainersPartsIds = dtParts.Select("PartTypeID="+drPartTypeItemContainerId[0]["PartTypeID"].ToString());
							DataRow [] drDiamondsPartsIds = dtParts.Select("PartTypeID="+drPartTypeDiamondId[0]["PartTypeID"].ToString());

#region GetPartValue
							DataSet dsIn=new DataSet();
							dsIn.Tables.Add("PartValueTypeEx");
							DataSet dsOut=gemoDream.Service.GenericGetCrystalSet(dsIn);
							dsOut.Tables[0].Rows.Add(dsOut.Tables[0].NewRow());
							/* sd 25.12.2006
							dsOut.Tables[0].Rows[0]["BatchID"]=dr["BatchID"].ToString();
							dsOut.Tables[0].Rows[0]["ItemCode"]=dr["Code"].ToString();
							*/
							dsOut.Tables[0].Rows[0]["BatchID"]=dr["NewBatchID"].ToString();
							dsOut.Tables[0].Rows[0]["ItemCode"]=dr["NewItemCode"].ToString();
							
							dsOut.Tables[0].Rows[0]["RecheckNumber"]=-1;
							dsOut.Tables[0].Rows[0]["ViewAccessCode"]=DBNull.Value;
							
							dsOut.Tables[0].TableName="PartValue";
							DataSet dsPartValue=gemoDream.Service.GenericGetCrystalSet(dsOut);
							gemoDream.Service.Debug_DiaspalyDataSet(dsPartValue);
#endregion

							for(int i=0;i<drItemContainersPartsIds.Length;i++)
							{
								DataRow [] drPartValues = dsPartValue.Tables[0].Select("PartID="+drItemContainersPartsIds[i]["ID"].ToString()+" and MeasureCode=2");
								if(drPartValues.Length>0)
								{
									switch(drPartValues[0]["MeasureClass"].ToString())
									{
										case "1": sItemContanierWeight=drPartValues[0]["MeasureValueName"].ToString(); break;
										case "2": sItemContanierWeight=drPartValues[0]["StringValue"].ToString(); break;
										case "3": sItemContanierWeight=drPartValues[0]["MeasureValue"].ToString(); break;
										case "4": sItemContanierWeight=drPartValues[0]["StringValue"].ToString(); break;
									}
									break;
								}
							}
				

						
						{
							for(int i = 0; i<drDiamondsPartsIds.Length;i++)
							{
								DataRow [] drPartValues = dsPartValue.Tables[0].Select("PartID="+drDiamondsPartsIds[i]["ID"].ToString()+" and (MeasureCode=2 or MeasureCode=4)");
								if(drPartValues.Length>0)
								{
									switch(drPartValues[0]["MeasureClass"].ToString())
									{
										case "1": sDiamondWeight=drPartValues[0]["MeasureValueName"].ToString(); break;
										case "2": sDiamondWeight=drPartValues[0]["StringValue"].ToString(); break;
										case "3": sDiamondWeight=drPartValues[0]["MeasureValue"].ToString(); break;
										case "4": sDiamondWeight=drPartValues[0]["StringValue"].ToString(); break;
									}
									break;
								}
							}
						}
				
	
						}
						catch(Exception exc)
						{
							System.Diagnostics.Trace.WriteLine(exc.Message.ToString());
						}
			
						//	if(!isWeight)
						//	{
						//		throw new Exception("NoWeight");
						//	}

#endregion


						string sCommentsByMeasureTitle = null;

						foreach(DataRow drRow in dtPartValues.Rows)
						{
							string strMeasureCode = drRow["MeasureCode"].ToString();
							if (strMeasureCode.Equals("48") || strMeasureCode.Equals("49") ||
								strMeasureCode.Equals("51"))
							{
								string sValueTitle = drRow["ValueTitle"].ToString();
								if (sValueTitle != null && sValueTitle.Length != 0)
								{
									if (sCommentsByMeasureTitle != null &&
										sCommentsByMeasureTitle.Length != 0)
										sCommentsByMeasureTitle += ",";
									sCommentsByMeasureTitle += sValueTitle;
								}
							}

							try
							{
								sDMax = Convert.ToDouble(Service.GetMeasureValue("DimensionMax", dtPartValues, drRow["PartID"].ToString())).ToString(".##");
								sDMin = Convert.ToDouble(Service.GetMeasureValue("DimensionMin", dtPartValues, drRow["PartID"].ToString())).ToString(".##");
								sH_x = Convert.ToDouble(Service.GetMeasureValue("H_x", dtPartValues, drRow["PartID"].ToString())).ToString(".##");
								if(sDMax != "" && sDMin != "" && sH_x != "")
								{
									sDimensions=sDMax+"-"+sDMin+" x "+sH_x + " mm";
									break;
								}
							}
							catch
							{
								sDimensions = "";
							}
							if(sDimensions.Length==0)
							{
								try
								{
									sDimensions=Convert.ToDouble(Service.GetMeasureValue("Depth", dtPartValues, drRow["PartID"].ToString())).ToString(".##");
								}
								catch
								{}
							}

						}

						

						dtItems.Rows[count]["Dimensions"] = sDimensions;
						customerName = cbcCustomer.ComboField.drvSelectedItem[cbcCustomer.DisplayMember].ToString();
						customerName = customerName.Substring(0, customerName.Length - 7);
						dtItems.Rows[count]["CustomerName"] = customerName;
						count++;

						////////////////////////////////
						//Text File
						
						

						//if(isTextFile)
						//{

					

						DataTable tblParts=Service.GetParts(dr["ItemTypeID"].ToString());
						//DataSet ds = new DataSet();
						//ds.Tables.Add(tblParts.Copy());
						//gemoDream.Service.debug_DiaspalyDataSet(ds);
						
						DataSet dsBatch=gemoDream.Service.ProxyGenericGetById(dr["BatchID"].ToString(),"Batch");
						DataSet	dsGroup=gemoDream.Service.ProxyGenericGetById(dsBatch.Tables[0].Rows[0]["GroupOfficeID_GroupID"].ToString(),"Group");
						

						foreach(DataRow rPart in tblParts.Rows)
						{
							
							DataRow rFile = dtFile.NewRow();
							rFile["Order No"]=Service.FillToFiveChars(dr["OrderCode"].ToString());
							rFile["Batch No"]=Service.FillToThreeChars(dr["BatchCode"].ToString());
								
							rFile["Report No"]=dr["Name"].ToString().Replace(".","").Substring(5);

							rFile["Lot No"]=dr["LotNumber"].ToString();
							rFile["Memo No"]=dsData.Tables["tblBatch"].Select("BatchID='"+dr["BatchID"].ToString()+"'")[0]["MemoNumber"].ToString();  // такого поля пока нет в базе

							DataSet dsShape = new DataSet();
							try
							{
								int iShapeCode=Convert.ToInt32(dr["Shape"].ToString());
								dsShape = Service.GetShapeByCode(iShapeCode);
								rFile["Shape"]=dsShape.Tables[0].Rows[0]["LongReportName"].ToString();
							}
							catch
							{
								rFile["Shape"]="";
							}
							
#region dimensions
											
							sMax = Service.GetMeasureValue("Max", dtPartValues, rPart["ID"].ToString());
							sMin = Service.GetMeasureValue("Min", dtPartValues, rPart["ID"].ToString());
							sDepth = Service.GetMeasureValue("Depth", dtPartValues, rPart["ID"].ToString());
							sDepth = Service.GetMeasureValueByMeasureCode("14", dtPartValues, rPart["ID"].ToString());
							sH_x = Service.GetMeasureValue("H_x", dtPartValues, rPart["ID"].ToString());
							sH_x = Service.GetMeasureValueByMeasureCode("13", dtPartValues, rPart["ID"].ToString());
								

							try
							{
								string sTempStr=Service.GetMeasureValue("Max", dtPartValues, rPart["ID"].ToString());
								/*
									string sTempStr=Service.GetMeasureValue("Max", dtPartValues, rPart["ID"].ToString());
									sTempStr=sTempStr.Substring(0,sTempStr.Length-2);
									if(sTempStr.Length==3) sTempStr="0"+sTempStr;
									rFile["Length"]=sTempStr;
									*/
								rFile["Length"]=Convert.ToDouble(sTempStr).ToString("0.00");
							}
							catch{}
								

							try
							{
								string sTempStr=sMax;
								//sTempStr=sTempStr.Substring(0,sTempStr.Length-2);

								//if(sTempStr.Length==3) sTempStr="0"+sTempStr;
								rFile["Max"]=Convert.ToDouble(sTempStr).ToString("0.00");
							}
							catch
							{
								rFile["Max"]="";
							}

							try
							{
								string sTempStr=Service.GetMeasureValue("Min", dtPartValues, rPart["ID"].ToString());
								//sTempStr=sTempStr.Substring(0,sTempStr.Length-2);
								//if(sTempStr.Length==3) sTempStr="0"+sTempStr;
								rFile["Width"]=Convert.ToDouble(sTempStr).ToString("0.00");
									
							}
							catch
							{
								rFile["Width"]="";
							}
							try
							{
								string sTempStr=sMin;
								//if(sTempStr.Length==3) sTempStr="0"+sTempStr;
								rFile["Min"]=Convert.ToDouble(sTempStr).ToString("0.00");

							}
							catch
							{
								rFile["Min"]="";
							}

							try
							{
								string sTempStr=sH_x;
								//if(sTempStr.Length==3) sTempStr="0"+sTempStr;
								rFile["Depth/Hx"]=Convert.ToDouble(sTempStr).ToString("0.00");
							}
							catch
							{
								rFile["Depth/Hx"]="";
							}

							try
							{
								string sTempStr=sH_x;
								//if(sTempStr.Length==3) sTempStr="0"+sTempStr;
								rFile["Hx"]=Convert.ToDouble(sTempStr).ToString("0.00");
							}
							catch
							{
								rFile["Hx"]="";
							}
#endregion
							try
							{
								if(isTotalWeight) //use ItemContanier Weight
								{
									sTempWeight=Convert.ToDouble(sItemContanierWeight).ToString("0.00");
									if(sTempWeight[0]=='.')
										sTempWeight="0"+sTempWeight;
									sTempWeight=sTempWeight+" ct. (twt)";
								}
							}
							catch
							{
								sStatusText="Item Contanier does not have weight";
								isWeightException=true;
								throw new Exception("Item Contanier does not have weight");
							}
							try
							{
								if(!isTotalWeight) //use Diamond Weight
								{
									sTempWeight=Convert.ToDouble(sDiamondWeight).ToString("0.00");
									if(sTempWeight[0]=='.')
										sTempWeight="0"+sTempWeight;
									sTempWeight=sTempWeight+" ct.";
								}
							}
							catch
							{
								sStatusText="Central stone does not have weight";
								isWeightException=true;
								throw new Exception("Central Stone does not have weight");
							}
							rFile["Weight"]=sTempWeight;

							try
							{
								//string sTempStr=sDepth.Substring(0,sH_x.Length-3);
								//if(sTempStr.Length==2) sTempStr="0"+sTempStr;
								rFile["Depth"]=Convert.ToDouble(sDepth).ToString("0.0")+"%";
							}
							catch
							{
								rFile["Depth"]="";
							}

							try 
							{
								string sTempStr=Service.GetMeasureValue("Tab_D", dtPartValues, rPart["ID"].ToString());
								//sTempStr=sTempStr.Substring(0,sTempStr.Length-5);
								rFile["Table"]=Convert.ToDouble(sTempStr).ToString("0")+"%";
							}
							catch
							{
								rFile["Table"]="";
							}
							try
							{
								string sTempStr=Service.GetMeasureValue("Pav_H", dtPartValues, rPart["ID"].ToString());
								//sTempStr=sTempStr.Substring(0,sb.Length-3);
								rFile["Pavilion"]=Convert.ToDouble(sTempStr).ToString("0.0")+"%";
							}
							catch
							{
								rFile["Pavilion"]="";
							}
	
							try
							{
								rFile["Crown"]=
									Convert.ToDouble(Service.GetMeasureValue("Crown_H",dtPartValues, rPart["ID"].ToString())).ToString("0.0")+"%";
							}
							catch{rFile["Crown"]="";}
							try
							{
								//string sGirdleFrom=Service.GetMeasureValueByMeasureCode("93",dtPartValues,rPart["ID"].ToString());
								//string sGirdleTo=Service.GetMeasureValueByMeasureCode("94",dtPartValues,rPart["ID"].ToString());
								string sGirdleFrom="";
								string sGirdleTo="";

								DataRow[] rParts=null;
								string sRet="";

								if(dtPartValues.Rows.Count > 0)					
								{
									rParts=dtPartValues.Select("MeasureCode=93 and PartID="+rPart["ID"].ToString());
									sGirdleFrom=rParts[0]["ValueTitle"].ToString(); 
									rParts=dtPartValues.Select("MeasureCode=94 and PartID="+rPart["ID"].ToString());
									sGirdleTo=rParts[0]["ValueTitle"].ToString();
								}				


								if(sGirdleFrom.Length>0 && sGirdleTo.Length>0)
									rFile["Girdle"]=sGirdleFrom+" - "+sGirdleTo;
								else rFile["Girdle"]="";

							}
							catch{}
							try
							{

								//rFile["Girdle Condition"]=Service.GetMeasureValue("GirdleType", dtPartValues, rPart["ID"].ToString());
								DataRow[] rParts=null;
								string sRet="";
								if(dtPartValues.Rows.Count > 0)					
								{
									rParts=dtPartValues.Select("MeasureName="+"'GirdleType'"+" and PartID="+rPart["ID"].ToString());					
									sRet=rParts[0]["ValueTitle"].ToString();
									rFile["Girdle Condition"]=sRet;
								}
													
							}
							catch{}

							try
							{
								rFile["Culet Size"]=Convert.ToDouble(Service.GetMeasureValue("Culet", dtPartValues, rPart["ID"].ToString())).ToString("0.00");
							}
							catch{}
								
							try
							{
								//rFile["Polish"]=Service.GetMeasureValue("Polish", dtPartValues, rPart["ID"].ToString());
								DataRow[] rParts=null;
								string sRet="";
								if(dtPartValues.Rows.Count > 0)					
								{
									rParts=dtPartValues.Select("MeasureName="+"'Polish'"+" and PartID="+rPart["ID"].ToString());					
									sRet=rParts[0]["ValueTitle"].ToString();
									rFile["Polish"]=sRet;
								}
							}
							catch{}

							try
							{
								//rFile["Symmetry"]=Service.GetMeasureValue("Symmetry", dtPartValues, rPart["ID"].ToString());
								DataRow[] rParts=null;
								string sRet="";
								if(dtPartValues.Rows.Count > 0)					
								{
									rParts=dtPartValues.Select("MeasureName="+"'Symmetry'"+" and PartID="+rPart["ID"].ToString());					
									sRet=rParts[0]["ValueTitle"].ToString();
									rFile["Symmetry"]=sRet;
								}
							}
							catch
							{}
							rFile["Clarity"]=dr["Clarity"].ToString();//Service.GetMeasureValue("Clarity Grade", dtPartValues, rPart["ID"].ToString());
							rFile["Potential Clarity"]=Service.GetMeasureValue("Clarity Potential", dtPartValues, rPart["ID"].ToString());
							rFile["Color"]=dr["Color"].ToString();//Service.GetMeasureValue("Color Grade", dtPartValues, rPart["ID"].ToString());

							DataRow [] rFluor=dtPartValues.Select("PartId="+rPart["ID"].ToString()+" and MeasureCode=28");
							if(rFluor.Length>0)
								rFile["Fluorescence"]= rFluor[0]["ValueTitle"].ToString(); //Service.GetMeasureValue("LW Flourescence", dtPartValues, rPart["ID"].ToString());

							DataRow [] rFluorCol=dtPartValues.Select("PartId="+rPart["ID"].ToString()+" and MeasureCode=90");
							if(rFluorCol.Length>0)
								rFile["Fluorescence Color"]=rFluorCol[0]["ValueTitle"].ToString(); //Service.GetMeasureValue("Fluorescence Color", dtPartValues, rPart["ID"].ToString());

							rFile["Color Description"]=Service.GetMeasureValue("Color stone color", dtPartValues, rPart["ID"].ToString());
							//Convert.ToDouble(Service.GetMeasureValue("Culet", dtPartValues, rPart["ID"].ToString())).ToString("0.00");
							rFile["Comments"]=dr["ItemComment"].ToString() +
								sCommentsByMeasureTitle;
							rFile["Description"]=Service.GetMeasureValue("Description", dtPartValues, rPart["ID"].ToString());
							rFile["Key To Symbols"]="";
							rFile["Special Instructions"]=dsGroup.Tables[0].Rows[0]["SpecialInstruction"].ToString();
							rFile["PartTypeId"]=rPart["PartTypeId"].ToString();

							dtFile.Rows.Add(rFile);
					

						}	
						//sLength = Service.GetMeasureValue("Length",drPartValue,dRow["PartID"].ToString());
						
						dtFinal.Rows.Add(EditDataTable(dtFile).ItemArray);
						dtFile.Rows.Clear();
						sFileName="sp"+Service.FillToFiveChars(dtFinal.Rows[0]["Order No"].ToString())+Service.FillToThreeChars(dtFinal.Rows[0]["Batch No"].ToString());
							
								
						sFullName=sSendPath+sFileName+"."+"txt";
					
						//		SaveDataTabletToTabDelimFile(dtFinal,sFullName);
						//	if(email.Length>0)
						//	{
						//			Service.SendBatchByFax(sFileName+".txt",email,sFileName);//,sb.ToString());
						//			sStatusText = "E-mail was sent succesfully";
						//		}
							

						//dtFinal.Rows.Clear();
						//	}


						
					}
					
					if(email.Length>0)
					{
						SaveDataTabletToTabDelimFile(dtFinal,sSendPath,email);
						sStatusText = "E-mail was sent succesfully";
					}
					else 
						sStatusText = "Messenger does not have an e-mail address";
					
					
					///////////////////////////////

					
					if(!isTextFile)
					{
						if(email.Length>0 )
						{
							Service.SendBatchByFax(dtItems, comboBox2.SelectedItem.ToString().ToLower(), email, sb.ToString(),sFileName);
							
							sStatusText = "E-mail was sent succesfully";
						
						}
						else 
						{
							sStatusText = "Messenger does not have an e-mail address";
							if(isTextFile)
							{
								try
								{
									//	System.IO.File.Delete(sFullName);
								}
								catch{}
							}
						}
					}
					sbStatus.Text = sStatusText;
				}
				catch(Exception ex)
				{
					if(isWeightException)
						MessageBox.Show("Unable to send e-mail. Weigth is not specified.", "E-mail was not sent", MessageBoxButtons.OK, MessageBoxIcon.Error);
					else
					{
						MessageBox.Show("Unable to send e-mail. Make sure that SMTP is on.", "E-mail was not sent", MessageBoxButtons.OK, MessageBoxIcon.Error);
						sbStatus.Text = "E-mail was not sent. Make sure that e-mail address is correct and SMTP server is up";					
					}
					sbStatus.Text = sStatusText;
				}
			}
			
			this.Cursor = Cursors.Default;
		}

		private DataRow EditDataTable (DataTable dtData)
		{
			DataTable dtFile=new DataTable();
			dtFile.Columns.Add("Order No",System.Type.GetType("System.String"));
			dtFile.Columns.Add("Batch No",System.Type.GetType("System.String"));
			dtFile.Columns.Add("Report No",System.Type.GetType("System.String"));
			dtFile.Columns.Add("Lot No",System.Type.GetType("System.String"));
			dtFile.Columns.Add("Memo No",System.Type.GetType("System.String"));
			dtFile.Columns.Add("Shape",System.Type.GetType("System.String"));
			dtFile.Columns.Add("Length",System.Type.GetType("System.String"));
			dtFile.Columns.Add("Width",System.Type.GetType("System.String"));
			dtFile.Columns.Add("Depth/Hx",System.Type.GetType("System.String"));
			dtFile.Columns.Add("Weight",System.Type.GetType("System.String"));
			dtFile.Columns.Add("Depth",System.Type.GetType("System.String"));
			dtFile.Columns.Add("Table",System.Type.GetType("System.String"));
			dtFile.Columns.Add("Pavilion",System.Type.GetType("System.String"));
			dtFile.Columns.Add("Crown",System.Type.GetType("System.String"));
			dtFile.Columns.Add("Girdle",System.Type.GetType("System.String"));
			dtFile.Columns.Add("Girdle Condition",System.Type.GetType("System.String"));
			dtFile.Columns.Add("Culet Size",System.Type.GetType("System.String"));
			dtFile.Columns.Add("Polish",System.Type.GetType("System.String"));
			dtFile.Columns.Add("Symmetry",System.Type.GetType("System.String"));
			dtFile.Columns.Add("Clarity",System.Type.GetType("System.String"));
			dtFile.Columns.Add("Potential Clarity",System.Type.GetType("System.String"));
			dtFile.Columns.Add("Color",System.Type.GetType("System.String"));
			dtFile.Columns.Add("Fluorescence",System.Type.GetType("System.String"));
			dtFile.Columns.Add("Fluorescence Color",System.Type.GetType("System.String"));
			dtFile.Columns.Add("Color Description",System.Type.GetType("System.String"));
			dtFile.Columns.Add("Comments",System.Type.GetType("System.String"));
			dtFile.Columns.Add("Description",System.Type.GetType("System.String"));
			dtFile.Columns.Add("Key To Symbols",System.Type.GetType("System.String"));
			dtFile.Columns.Add("Special Instructions",System.Type.GetType("System.String"));

			dtFile.Rows.Add(dtFile.NewRow());

			for(int i=0;i<dtFile.Columns.Count;i++)
			{
				string sTemp="";
				foreach(DataRow drData in dtData.Rows)
				{
					if(drData[dtFile.Columns[i].ColumnName].ToString().Length>0)
					{
						sTemp=drData[dtFile.Columns[i].ColumnName].ToString();
						break;
					}
				}

				dtFile.Rows[0][i]=sTemp;
			}
			/*
						foreach(DataRow dr in dtData.Rows)
						{
							for(int i=0;i<dtFile.Columns.Count;i++)
							{
								if(dr[i].ToString().Length!=0 && dtFile.Rows[0][i].ToString().Length==0)
									dtFile.Rows[0][i]=dr[i];
							}
						}
			*/			
			string sLenght="";
			string sMax="";
			string sWidth="";
			string sMin="";
			string sDepth="";
			string sHx="";
			string sColor="";
			string sClarity="";

			for(int i=0; i<dtData.Rows.Count;i++)
			{
				if(dtData.Rows[i]["Length"].ToString().Length>0) sLenght=dtData.Rows[i]["Length"].ToString();
				if(dtData.Rows[i]["Max"].ToString().Length>0) sMax=dtData.Rows[i]["Max"].ToString();
				if(dtData.Rows[i]["Depth"].ToString().Length>0) sDepth=dtData.Rows[i]["Depth"].ToString();
				if(dtData.Rows[i]["Min"].ToString().Length>0) sMin=dtData.Rows[i]["Min"].ToString();
				if(dtData.Rows[i]["Width"].ToString().Length>0) sWidth=dtData.Rows[i]["Width"].ToString();
				//if(dtData.Rows[i]["Hx"].ToString().Length>0) sHx=dtData.Rows[i]["Hx"].ToString();
				/*
								if(dtData.Rows[i]["Color"].ToString().Length>0 && dtData.Rows[i]["PartTypeId"].ToString()=="1") 
									sColor+=dtData.Rows[i]["Color"].ToString()+";";

								if(dtData.Rows[i]["Clarity"].ToString().Length>0 && dtData.Rows[i]["PartTypeId"].ToString()=="1") 
									sClarity+=dtData.Rows[i]["Clarity"].ToString()+";";
				*/
			}
			/*
						for(int i=0; i<dtData.Rows.Count;i++)
						{
							if(dtData.Rows[i]["Color"].ToString().Length>0 && dtData.Rows[i]["PartTypeId"].ToString()=="10") 
								sColor+="SS-"+dtData.Rows[i]["Color"].ToString()+";";

							if(dtData.Rows[i]["Clarity"].ToString().Length>0 && dtData.Rows[i]["PartTypeId"].ToString()=="10") 
								sClarity+="SS-"+dtData.Rows[i]["Clarity"].ToString()+";";

						}


						if(sColor.Length>0)
							sColor=sColor.Substring(0,sColor.Length-1);
						if(sClarity.Length>0)
							sClarity=sClarity.Substring(0,sClarity.Length-1);

						dtFile.Rows[0]["Color"]=sColor;
						dtFile.Rows[0]["Clarity"]=sClarity;
			*/
			if(sLenght.Length>0)
			{
				dtFile.Rows[0]["Length"]=sLenght;
			}
			else
			{	
				dtFile.Columns["Length"].ColumnName="Max";
				dtFile.Rows[0]["Max"]=sMax;
			}

			if(sWidth.Length>0)
			{
				dtFile.Rows[0]["Width"]=sWidth;
			}
			else
			{	
				dtFile.Columns["Width"].ColumnName="Min";
				dtFile.Rows[0]["Min"]=sMin;
			}


			//	dtFile.Rows[0]["Depth/Hx"]=sHx;
			
			/*
			if(sDepth.Length>0)
			{
				dtFile.Rows[0]["Depth/Hx"]=sDepth;
				dtFile.Columns["Depth/Hx"].ColumnName="Depth ";
			}
			else
			{	
				dtFile.Columns["Depth/Hx"].ColumnName="Hx";
				dtFile.Rows[0]["Hx"]=sHx;
			}
*/
			return  dtFile.Rows[0];
		}

		private void SaveDataTabletToTabDelimFile(DataTable dtData, string sSendPath,string email)
		{
			/*
			System.IO.StreamWriter sw = new System.IO.StreamWriter(sFileName);
			for(int i=0;i<dtData.Columns.Count;i++)
			{
				sw.Write(dtData.Columns[i].ColumnName.ToString()+"\t");
			}
			sw.WriteLine("");

			foreach(DataRow dr in dtData.Rows)
			{
				for(int i=0;i<dtData.Columns.Count;i++)
					sw.Write(dr[i].ToString()+"\t");
				sw.WriteLine("");
			}


			sw.Close();
			*/
			string sPrevOrder = "";
			string sPrevBatch = "";
			string sFileName = "";
			bool bFirst=true;

			System.IO.StreamWriter sw=null;
			try
			{
				for(int i=0;i<dtData.Rows.Count;i++)
				{
					if(sPrevBatch!=dtData.Rows[i]["Batch No"].ToString() || 
						sPrevOrder!=dtData.Rows[i]["Order No"].ToString())
					{
						if(!bFirst)
						{
							sw.Close();
							Service.SendBatchByFax(sFileName+".txt",email,sFileName);//,sb.ToString());
						}
						if(bFirst) bFirst=!bFirst;
						sFileName = "sp"+ dtData.Rows[i]["Order No"].ToString()+dtData.Rows[i]["Batch No"].ToString();
						sw = new System.IO.StreamWriter(sSendPath+"sp"+
							dtData.Rows[i]["Order No"].ToString()+dtData.Rows[i]["Batch No"].ToString()+".txt");
						sPrevBatch = dtData.Rows[i]["Batch No"].ToString();
						sPrevOrder = dtData.Rows[i]["Order No"].ToString();
						for(int q=0;q<dtData.Columns.Count;q++)
						{
							sw.Write(dtData.Columns[q].ColumnName.ToString()+"\t");
						}
						sw.WriteLine("");
					}
				
					for(int j=0;j<dtData.Columns.Count;j++)
						sw.Write(dtData.Rows[i][j].ToString()+"\t");
					sw.WriteLine("");
				
				

				}
				sw.Close();
				Service.SendBatchByFax(sFileName+".txt",email,sFileName);//,sb.ToString());
			}
			catch(Exception ex)
			{
				System.Diagnostics.Trace.WriteLine("43");
			}
		}


		private void bHelp_Click(object sender, System.EventArgs e)
		{
			groupBox7.Text = "Item Details";
			ListViewItem lvi;
			lvProps.Items.Clear();
			try
			{				
				DataSet dsParts = new DataSet();
				dsParts.Tables.Add(Service.GetItemPartsByItemTypeID(otOpenOrders.Selected.drNode["ItemTypeID"].ToString())); //Procedures dbo.spGetItemTypeTypeEx, dbo.spGetPartsByItemType

				DataRow[] adrContainers = dsParts.Tables["PartsByItemType"].Select("not PartTypeID=" + "15");
				if(adrContainers.Length != 0)
				{
					try
					{
						this.pbShape.Image = null;
						DataSet dsShape = Service.GetShapeByCode(Convert.ToInt32(otOpenOrders.Selected.drNode["Shape"]));//Procedures dbo.spGetShapeByCodeTypeEx, dbo.spGetShapeByCode
						//New part 04/07/08
						string pathToShape = Client.GetOfficeDirPath("iconDir") + dsShape.Tables[0].Rows[0]["Path2Drawing"].ToString();
						if (System.IO.File.Exists(pathToShape))
						{
							Image im =  System.Drawing.Image.FromFile(pathToShape);
							if(im != null)
							{
								this.pbShape.Image = im;
								Service.DrawAdjustShapeImage(this.pbShape, im);
							}
						}
//						Old part

//						Image imShape = (System.Drawing.Image)Service.ExtractImageFromString(dsShape.Tables[0].Rows[0]["Image_Path2Drawing"].ToString(),
//							dsShape.Tables[0].Rows[0]["Path2Drawing"].ToString());
//						Service.DrawAdjustShapeImage(pbShape, imShape);	
//						int itop = 0;
//						int ileft = 0;
//						try
//						{
//							itop = (pbShape.Parent.Height - pbShape.Height)/2;
//							ileft = (pbShape.Parent.Width - pbShape.Width)/2;
//						}
//						catch(Exception ex)
//						{
//							string msg = ex.Message;
//						}
//						pbShape.Top = itop;
//						pbShape.Left = ileft;
					}
					catch(Exception exc)
					{
						Console.WriteLine(exc.Message);
						pbShape.Image = null;
					}
				}
				else
					pbShape.Image = null;
				
				DataSet dsPartValueTypeEx = Service.GetPartValueTypeEx();//Procedure dbo.spGetPartValueTypeEx
				DataSet dsPartValueType = dsPartValueTypeEx.Copy();
				dsPartValueType.Tables["PartValueTypeEx"].TableName = "PartValue";
				dsPartValueType.Tables["PartValue"].Rows.Add(dsPartValueType.Tables["PartValue"].NewRow());
				//dsPartValueType.Tables["PartValue"].Rows[0]["PartID"] = iContainerID;
				dsPartValueType.Tables["PartValue"].Rows[0]["RecheckNumber"] = -1;
				/* sd 25.12.2006
				dsPartValueType.Tables["PartValue"].Rows[0]["BatchID"] = otOpenOrders.Selected.drNode["BatchID"];
				dsPartValueType.Tables["PartValue"].Rows[0]["ItemCode"] = otOpenOrders.Selected.drNode["Code"];
				*/
				dsPartValueType.Tables["PartValue"].Rows[0]["BatchID"] = otOpenOrders.Selected.drNode["NewBatchID"];
				dsPartValueType.Tables["PartValue"].Rows[0]["ItemCode"] = otOpenOrders.Selected.drNode["NewItemCode"];

				dsPartValueType.Tables["PartValue"].Rows[0]["ViewAccessCode"] = DBNull.Value;
				dsPartValueType = Service.GetPartValueType(dsPartValueType);//Procedure dbo.spGetPartValue

				DataTable dtPartValue = dsPartValueType.Tables[0].Copy();
				DataSet dsRules  = Service.GetCustomerProgramRuleByBatchID(otOpenOrders.Selected.drNode["BatchID"].ToString());//Procedure dbo.spGetCustomerProgramRuleByBatchID
				sbStatus.Text = "Getting more information";

				if(otOpenOrders.Selected.tblName == "tblItem")
				{
					DataTable dtInfo = Service.GetItemInfo(otOpenOrders.Selected.drNode["BatchID"].ToString() + "_" + otOpenOrders.Selected.drNode["Code"].ToString()).Tables[0];//Procedure dbo.spGetItemDetails
					string sItemCode = GraderLib.GetCorrectOrderBatchItemString(Convert.ToInt32(dtInfo.Rows[0]["OrderCode"]), 
																				Convert.ToInt32(dtInfo.Rows[0]["BatchCode"]), 
																			    Convert.ToInt32(dtInfo.Rows[0]["ItemCode"]));
					
					string sOldItemCode = GraderLib.GetCorrectOrderBatchItemString( Convert.ToInt32(dtInfo.Rows[0]["PrevOrderCode"]), 
																			        Convert.ToInt32(dtInfo.Rows[0]["PrevBatchCode"]), 
																			        Convert.ToInt32(dtInfo.Rows[0]["PrevItemCode"]));

					groupBox7.Text = "Item # " + (sItemCode.Trim() == sOldItemCode.Trim() ? sItemCode.Trim() : (sItemCode.Trim() + "/" + sOldItemCode.Trim())) + " Details";
					lbOtherDetails.Text = "Lot# " + dtInfo.Rows[0]["LotNumber"].ToString() + "\nItem# " + (sItemCode.Trim() == sOldItemCode.Trim() ? sItemCode.Trim() : (sItemCode.Trim() + "/" + sOldItemCode.Trim()));
					lbMemo.Text = dtInfo.Rows[0]["ItemComment"].ToString();
					DataRow[] drPartValue = dtPartValue.Select("", "PartID");
					DataTable dtParts = Service.GetParts(dtInfo.Rows[0]["ItemTypeID"].ToString());
					
					//by Vetal_242 20.10.2006
					//If this item old, then we must get old PartValue for compare
					
					DataTable dtOldPartValue = new DataTable();
					if(dtInfo.Rows[0]["PrevItemCode"].ToString()  != "" &&
						dtInfo.Rows[0]["PrevBatchCode"].ToString() != "" &&
						dtInfo.Rows[0]["PrevGroupCode"].ToString() != "" &&
						(dtInfo.Rows[0]["PrevGroupCode"].ToString()+
						 dtInfo.Rows[0]["PrevBatchCode"].ToString()+
						 dtInfo.Rows[0]["PrevItemCode"].ToString() != 
						 dtInfo.Rows[0]["GroupCode"].ToString() + 
						 dtInfo.Rows[0]["BatchCode"].ToString() +
						 dtInfo.Rows[0]["ItemCode"].ToString() ))
					{
						dtOldPartValue = Service.GetPartValueByCodePrev(dtInfo.Rows[0]["PrevGroupCode"].ToString(),
							                                            dtInfo.Rows[0]["PrevBatchCode"].ToString(),
							                                            dtInfo.Rows[0]["PrevItemCode"].ToString(),"1");			
					}


					foreach(DataRow dr in drPartValue)
					{
						if ((dr["MeasureClass"].ToString() == "1" ||
							dr["MeasureClass"].ToString() == "2" || 
							dr["MeasureClass"].ToString() == "3" ||
							dr["MeasureClass"].ToString() == "4")
							&&
							(dr["MeasureValueName"]!= DBNull.Value ||
							dr["MeasureValue"]	!= DBNull.Value ||
							dr["StringValue"]		!= DBNull.Value)
							)
						{
							DataRow []temp = dsRules.Tables[0].Select("PartID = '" + dr["PartID"] + "' and MeasureID = '" + dr["MeasureID"] + "'");	
							DataRow[] drOldPartValue = dtOldPartValue.Select("1=2");
							if(dtOldPartValue.Rows.Count > 0)
							{
								drOldPartValue = dtOldPartValue.Select("PartID = '" + dr["PartID"] + "' and MeasureID = '" + dr["MeasureID"] + "'");
							}

							if(temp.Length == 0)
							{
								lvi = new ListViewItem(dtParts.Select("ID="+dr["PartID"].ToString())[0]["Name"].ToString());
								lvi.SubItems.Add(dr["MeasureName"].ToString());
								
								switch (dr["MeasureClass"].ToString())
								{
									case "1":
									{
										lvi.SubItems.Add(dr["MeasureValueName"].ToString());
										if(drOldPartValue.Length > 0) lvi.SubItems.Add(drOldPartValue[0]["MeasureValueName"].ToString());
										break;
									}
									case "2":
									{
										lvi.SubItems.Add(dr["StringValue"].ToString());
										if(drOldPartValue.Length > 0) lvi.SubItems.Add(drOldPartValue[0]["StringValue"].ToString());
										break;
									}
									case "3":
									{
										try
										{
											lvi.SubItems.Add(Convert.ToDouble(dr["MeasureValue"]).ToString(".##"));
											if(drOldPartValue.Length > 0) lvi.SubItems.Add(Convert.ToDouble(drOldPartValue[0]["MeasureValue"]).ToString(".##"));
										}
										catch{}
										break;
									}
									case "4":
									{
										lvi.SubItems.Add(dr["StringValue"].ToString());
										if(drOldPartValue.Length > 0) lvi.SubItems.Add(drOldPartValue[0]["StringValue"].ToString());
										break;
									}								
								}
								lvProps.Items.Add(lvi);
							}
						}
					}					
				}
			}
			catch(Exception exc)
			{
				Console.WriteLine(exc.Message);
				sbStatus.Text = "Couldn't get details from server";
			}

			

			DataSet dsPic = Service.GetItemCPPictureByCode(otOpenOrders.Selected.drNode["OrderCode"].ToString(),
				otOpenOrders.Selected.drNode["BatchCode"].ToString());
			
			System.Diagnostics.Trace.WriteLine("dsf");
			this.pictureBox2.Image = null;
			//string pathTopicture = "";
			if(!Convert.IsDBNull(dsPic.Tables[0].Rows[0]["Path2Picture"]))
			{
				string pathToPicture = Client.GetOfficeDirPath("iconDir") + dsPic.Tables[0].Rows[0]["Path2Picture"].ToString();
				if (System.IO.File.Exists(pathToPicture))
				{
					Image im =  System.Drawing.Image.FromFile(pathToPicture);
					if(im != null)
					{
						this.pictureBox2.Image = im;
						Service.DrawAdjustShapeImage(this.pictureBox2, im);
					}
				}

//				imPic = (Image)Service.ExtractImageFromString(dsPic.Tables[0].Rows[0]["Image_Path2Picture"].ToString(),
//					dsPic.Tables[0].Rows[0]["Path2Picture"].ToString());
//				Service.DrawAdjustShapeImage(pictureBox2, imPic,-1,-1,0,0);	
				//pictureBox2.Image = imPic;

				sbStatus.Text = "Ready";
			}
		}

		private void cbcCustomer_Enter(object sender, System.EventArgs e)
		{
			sbStatus.Text = "Select a customer to process";
		}

		private void cbPeriod_Enter(object sender, System.EventArgs e)
		{
			sbStatus.Text = "Select a period to show orders history for";
		}

		private void liPersons_Enter(object sender, System.EventArgs e)
		{
			sbStatus.Text = "Customer's persons";
		}

		private void otClosed_Enter(object sender, System.EventArgs e)
		{
			sbStatus.Text = "Customer's orders history";
		}

		private void otOpenOrders_Enter(object sender, System.EventArgs e)
		{
			sbStatus.Text = "Customer's open orders. Check orders to display at <Update Order> tab and press <Order Update> button";
		}

		private void lbxItems_Enter(object sender, System.EventArgs e)
		{
			sbStatus.Text = "Order's items list. Click an items container to view all the items it contains";
		}

		private void cbPersons_Enter(object sender, System.EventArgs e)
		{
			sbStatus.Text = "Select a person to contact";
		}

		private void comboBox2_Enter(object sender, System.EventArgs e)
		{
			sbStatus.Text = "Select file extension";
		}

		private void cbCustPersons_Enter(object sender, System.EventArgs e)
		{
			sbStatus.Text = "Select a person for details";
		}

		private void dtpFrom_Enter(object sender, System.EventArgs e)
		{
			sbStatus.Text = "History start date";
		}

		private void dtpTo_Enter(object sender, System.EventArgs e)
		{
			sbStatus.Text = "History end date";
		}

		private void dateTimePicker1_Enter(object sender, System.EventArgs e)
		{
			sbStatus.Text = "Date filter start point";
		}

		private void dateTimePicker2_Enter(object sender, System.EventArgs e)
		{
			sbStatus.Text = "Date filter end point";
		}

		private void otAllOrders_Enter(object sender, System.EventArgs e)
		{
			sbStatus.Text = "Selected orders";
		}
		private void button1_Enter(object sender, System.EventArgs e)
		{
			sbStatus.Text = "Filtering orders by date";
		}

		private void ControlFocusLeave(object sender, System.EventArgs e)
		{
			sbStatus.Text = "Ready";
		}

		private void lbxIndustry_Enter(object sender, System.EventArgs e)
		{
			sbStatus.Text = "Customer's industry memberships";
		}

		private void lvDocs_Enter(object sender, System.EventArgs e)
		{
			sbStatus.Text = "Orders summary";
		}

		private void pnlDetails_Enter(object sender, System.EventArgs e)
		{
			sbStatus.Text = "Orders details";
		}

		private void tpOrders_Enter(object sender, System.EventArgs e)
		{
			sbStatus.Text = "Orders, Stones...";
		}

		private void tpCustomer_Enter(object sender, System.EventArgs e)
		{
			sbStatus.Text = "Customer";
		}

		private void tpUpdate_Enter(object sender, System.EventArgs e)
		{
			sbStatus.Text = "Order update";
		}		
		private void ptrOps_Enter(object sender, System.EventArgs e)
		{
			sbStatus.Text = "Operations list. Select an item to view all available operations";
		}

#endregion StatusBar

		private void tbSearchUnit_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
//            // Initialize the flag to false.
//            nonNumberEntered = false;
//            // Determine whether the keystroke is a number or backspace or dot.
//            if ((e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9) && 
//                (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9) && 
//                (e.KeyCode != Keys.Back) && 
//                (e.KeyCode != Keys.OemPeriod) && 
//                (e.KeyCode != Keys.Decimal))
//            {	
//                nonNumberEntered = true;
//            }

            if(e.KeyCode == Keys.Enter && tbSearchUnit.Text.Length >= 4)
			{
				bSearch_Click(sender, System.EventArgs.Empty);
			}
		}

		
		//Invoicing GO
		private void InvoicingGo()
		{
			string [] sDescriptionStatus = null;
			string sOperationMsg = "";
			string sMsgText = "";
			bool bFailed = false;
			sbStatus.Text = "Running invoicing...";
			this.Cursor = Cursors.WaitCursor;			
			DataTable dtInvoice = new DataTable("Invoice");
			dtInvoice.Columns.Add("BatchCode");
			dtInvoice.Columns.Add("InvoiceCode");
			dtInvoice.Columns.Add("ItemCount"); 
			
			String sFullBatchCode;
			String sFullItemCode;
			string orderToBill;
			try
			{
				DataSet dsChecked = otOpenOrders.Get();
				
				if (dsChecked.Tables["tblBatch"].Rows.Count == 0)
					throw new Exception  ("Error: No batches were selected for invoicing");
					

				if (dsChecked.Tables["tblOrder"].Rows.Count != 0)
				{
					orderToBill = dsChecked.Tables["tblOrder"].Rows[0]["OrderCode"].ToString();
					DataSet dsTemp = new DataSet();
					DataTable dtGetAccountType = dsTemp.Tables.Add("AccountType");
					dtGetAccountType.Columns.Add("GroupCode");
					dtGetAccountType.Columns.Add("CustomerID");
					dtGetAccountType.Columns.Add("CustomerOfficeID");
					DataRow row = dtGetAccountType.NewRow();
					dtGetAccountType.Rows.Add(row);
					row["CustomerID"] = cbcCustomer.SelectedID.Split('_')[1];
					row["CustomerOfficeID"] = cbcCustomer.SelectedID.Split('_')[0];
					row["GroupCode"] = Convert.ToInt32(orderToBill);
					dsTemp = Service.ProxyGenericGet(dsTemp);

					if (dsTemp.Tables[0].Rows.Count == 1)
					{
						var AccountType = dsTemp.Tables[0].Rows[0][0].ToString();
						closeExit = false;
						addressToBill = "";
						BillingOptions billToAccount; //= new BillingOptions();

						billToAccount = new BillingOptions(Convert.ToInt16(AccountType));
						billToAccount.ShowDialog();
						billToAccount.Close();
						billToAccount.Dispose();

						this.Show();
						this.Refresh();
						this.Cursor = Cursors.Default;
						if (closeExit) return;
					}
				}

				DataTable dtItems4Invoice = new DataTable();
				dtItems4Invoice = dsChecked.Tables["tblItem"].Copy();
				dtItems4Invoice.Columns.Add("Passed");
				dtItems4Invoice.Columns.Add("Description");
				dtItems4Invoice.Columns.Add(new DataColumn("Result", typeof(string)));
				dtItems4Invoice.Columns.Add(new DataColumn("FullBatch", typeof(string)));

				Hashtable hBatchWMemo = new Hashtable();

					object obInvoiceID = null;

					foreach (DataRow drBatch in dsChecked.Tables["tblBatch"].Rows)
					{
						//					object obInvoiceID = null;
						string sInvoiceID = "";
						int iItemCount = 0;

						sFullBatchCode = Service.FillToFiveChars(drBatch["GroupCode"].ToString()) + "." + Service.FillToThreeChars(drBatch["Code"].ToString());

						if (drBatch["MemoNumber"].ToString() == "")
							obInvoiceID = InvoiceBatch(drBatch["BatchID"], obInvoiceID, dtItems4Invoice);
						//							obInvoiceID = InvoiceBatch(drBatch["BatchID"], null, dtItems4Invoice);
						else
						{
							if (hBatchWMemo.ContainsKey(drBatch["MemoNumber"]))
								obInvoiceID = InvoiceBatch(drBatch["BatchID"], obInvoiceID, dtItems4Invoice);
							//								obInvoiceID = InvoiceBatch(drBatch["BatchID"], hBatchWMemo[drBatch["MemoNumber"]], dtItems4Invoice);
							else
							{
								obInvoiceID = InvoiceBatch(drBatch["BatchID"], obInvoiceID, dtItems4Invoice);
								//								obInvoiceID = InvoiceBatch(drBatch["BatchID"], null, dtItems4Invoice);
								hBatchWMemo.Add(drBatch["MemoNumber"], obInvoiceID);
							}
						}

						foreach (DataRow drItem in dtItems4Invoice.Select("BatchID = '" + drBatch["BatchID"] + "'"))
						{
							sFullItemCode = Service.FillToFiveChars(drItem["GroupCode"].ToString()) + "." + Service.FillToThreeChars(drItem["BatchCode"].ToString()) + "." + Service.FillToTwoChars(drItem["Code"].ToString());
							sDescriptionStatus = drItem["Description"].ToString().Split('_');
							//New part from 08/21/09						
							if (sDescriptionStatus[0] == "0")
								sMsgText = "Item " + sFullItemCode + ": Invoicing Failed: " + sDescriptionStatus[1];
							//							sMsgText = sMsgText + "Item " + sFullItemCode + ": Invoicing Failed: " + sDescriptionStatus[1]+ "\n";

							if (sDescriptionStatus[0] == "1")
								sMsgText = "Item " + sFullItemCode + ": " + sDescriptionStatus[1];
							//							sMsgText = sMsgText + "Item " + sFullItemCode + ": " + sDescriptionStatus[1]+ "\n";
							drItem["Result"] = sMsgText;
							drItem["FullBatch"] = "Batch " + sFullBatchCode;
							//End of New Part

							//This Old part commented 08/21/09, changed by new part above					
							//////////						if(drItem["Passed"].ToString() == "1")// && drItem["Description"].ToString()!="Item is already billed")
							//////////						{
							//////////							if (drItem["Description"].ToString() ==  "Item is already billed")
							//////////							{
							//////////								sMsgText = sMsgText + "Item " + sFullItemCode + ": Item is already billed" + "\n";
							//////////							}
							//////////							else
							//////////							{
							//////////								sMsgText = sMsgText + "Item " + sFullItemCode + ": "  + drItem["Description"].ToString() + "\n"; //Customer Program failed. Prices will be calculated by 'Failed' tab" + "\n";
							//////////								iItemCount++;
							//////////							}
							//////////						}
							//////////						else
							//////////							sMsgText = sMsgText + "Item " + sFullItemCode + ": " + drItem["Description"].ToString() + "\n";
							//End of Old Part


							//						if(drItem["Description"] != System.DBNull.Value)// && drItem["Description"].ToString()!=" Already invoiced;")
							//						{
							//							//if(drItem["Description"].ToString()!=" Already invoiced;")
							//							sMsgText = sMsgText + "Item " + sFullItemCode + ": invoicing failed. Reason: " + drItem["Description"].ToString() + "\n";						
							//							//iItemCount++;
							//						}
							//						else 
							//						{
							//							if(drItem["Passed"].ToString() == "1")
							//								sMsgText = sMsgText + "Item " + sFullItemCode + ": Customer Program failed. Prices will be calculated according to the 'Failed' tab" + "\n";
							//							//else
							//							
							//						}
						}

						//sMsgText = sMsgText == ""?"Invoicing finished without warnings" : sMsgText;
						//					MessageBox.Show(sMsgText, "Batch " + sFullBatchCode, MessageBoxButtons.OK, MessageBoxIcon.Information);
						sMsgText = "";
						sDescriptionStatus = null;
						if (obInvoiceID != null)
						{
							int InvoiceCode = 0;
							try
							{
								InvoiceCode = Convert.ToInt32(obInvoiceID);
								InvoiceCode += 500;
								sInvoiceID = InvoiceCode.ToString();
							}
							catch { }
							if (sInvoiceID != "")
							{
								dtInvoice.Rows.Add(new object[] { });
								dtInvoice.Rows[dtInvoice.Rows.Count - 1]["BatchCode"] = sFullBatchCode;
								dtInvoice.Rows[dtInvoice.Rows.Count - 1]["InvoiceCode"] = dtCustomer.Rows[0]["ShortName"].ToString() + sInvoiceID;
								dtInvoice.Rows[dtInvoice.Rows.Count - 1]["ItemCount"] = iItemCount;
							}
						}

#region BatchTracking
						int iItemsAffected = 0;
						iItemsAffected = dtItems4Invoice.Select("BatchID = '" + drBatch["BatchID"] + "' AND NOT Description LIKE '*Item is already billed*'").Length;
						if (sInvoiceID != "" && iItemsAffected > 0)
						{
							object BatchID = drBatch["BatchID"];
							object EventID = GraderLib.BatchEvents.Billed;
							object ItemsAffected = iItemsAffected;
							object ItemsInBatch = drBatch["ItemsQuantity"];
							object FormID = GraderLib.Codes.AccRep;
							Service.SetBatchEvent(EventID, BatchID, FormID, ItemsAffected, ItemsInBatch);
						}
#endregion
					}
					//				string msg = "";
					//
					//				foreach(DataRow dr in dtInvoice.Rows)
					//				{
					//					msg += "Batch " + dr["BatchCode"].ToString()+ " has Invoice N " +
					//						dr["InvoiceCode"].ToString() + 
					//						" (Invoiced Items " + dr["ItemCount"].ToString() + ").          \n";
					//				}


					//				if(msg!="")
					//				{
					//					msg += "Print invoices?";
					//					DialogResult res =
					//						MessageBox.Show(this,msg,"Billing",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
					//					if(res == DialogResult.Yes)
					//					{
					//						//print invoice
					//
					//					}
					//				}
					foreach (DataRow dr in dtItems4Invoice.Rows)
					{
						sMsgText = sMsgText + dr["FullBatch"].ToString() + ": " + dr["Result"].ToString() + "\n";
					}
					MessageBox.Show(sMsgText, "Order: " + dsChecked.Tables["tblOrder"].Rows[0]["OrderCode"].ToString() + ", billed to " + addressToBill, MessageBoxButtons.OK, MessageBoxIcon.Information);

					sOperationMsg = "Operation succeed";
					sbStatus.Text = sOperationMsg;
				
			}
			catch (Exception exc)
			{
				bFailed = true;
				sOperationMsg = "Operation failed.\n" + exc.Message;
				sbStatus.Text = "Operation failed";
				if (exc.Message.ToUpper().Contains("ERROR"))  MessageBox.Show(exc.Message);
			}
			
			finally
			{
				//MessageBox.Show(sOperationMsg, "Billing", MessageBoxButtons.OK, (bFailed)?MessageBoxIcon.Error:MessageBoxIcon.Information);
				this.Cursor = Cursors.Default;
				sbStatus.Text = "Ready";
			}
		}
		
		private void bBill_Click(object sender, System.EventArgs e)
		{
			//			bRegularBill = cbRegularBilling.Checked;
			//          bBillWithSKU = cbBillingWithSKU.Checked;
			//          bBillWithLot = cbBillingWithLot.Checked;
			SaveAddServices();
			InvoicingGo();
            cbRegularBilling.Checked = true;
			//			string sOperationMsg = "";
			//			string sMsgText = "";
			//			bool bFailed = false;
			//			sbStatus.Text = "Running invoicing...";
			//			this.Cursor = Cursors.WaitCursor;			
			//			DataTable dtInvoice = new DataTable("Invoice");
			//			dtInvoice.Columns.Add("BatchCode");
			//			dtInvoice.Columns.Add("InvoiceCode");
			//			dtInvoice.Columns.Add("ItemCount"); 
			//			
			//			
			//			String sFullBatchCode;
			//			String sFullItemCode;			
			//
			//			DataSet dsChecked = otOpenOrders.Get();
			//			
			//			DataTable dtItems4Invoice = new DataTable();			
			//			dtItems4Invoice = dsChecked.Tables["tblItem"].Copy();
			//			dtItems4Invoice.Columns.Add("Passed");
			//			dtItems4Invoice.Columns.Add("Description");
			//
			//			try
			//			{
			//				if (dsChecked.Tables["tblBatch"].Rows.Count == 0)
			//					throw new Exception("No batches selected");
			//
			//				//Key MemoNumber, value InvoiceID
			//				Hashtable hBatchWMemo = new Hashtable();
			//					
			//				foreach(DataRow drBatch in dsChecked.Tables["tblBatch"].Rows)
			//				{
			//					object obInvoiceID = null;
			//					string sInvoiceID = "";
			//					int iItemCount = 0;
			//					sFullBatchCode = Service.FillToFiveChars(drBatch["GroupCode"].ToString()) + "." + Service.FillToThreeChars(drBatch["Code"].ToString());
			//
			//					if(drBatch["MemoNumber"].ToString() == "")
			//						obInvoiceID = InvoiceBatch(drBatch["BatchID"], null, dtItems4Invoice);
			//					else
			//					{
			//						if(hBatchWMemo.ContainsKey(drBatch["MemoNumber"]))
			//							obInvoiceID = InvoiceBatch(drBatch["BatchID"], hBatchWMemo[drBatch["MemoNumber"]], dtItems4Invoice);
			//						else
			//						{
			//							obInvoiceID = InvoiceBatch(drBatch["BatchID"], null, dtItems4Invoice);
			//							hBatchWMemo.Add(drBatch["MemoNumber"], obInvoiceID);
			//						}
			//					}
			//
			//					foreach(DataRow drItem in dtItems4Invoice.Select("BatchID = '" + drBatch["BatchID"] + "'"))
			//					{
			//						sFullItemCode = Service.FillToFiveChars(drItem["GroupCode"].ToString()) + "." + Service.FillToThreeChars(drItem["BatchCode"].ToString()) + "." + Service.FillToTwoChars(drItem["Code"].ToString());
			//						if(drItem["Description"] != System.DBNull.Value)// && drItem["Description"].ToString()!=" Already invoiced;")
			//						{
			//							//if(drItem["Description"].ToString()!=" Already invoiced;")
			//								sMsgText = sMsgText + "Item " + sFullItemCode + ": invoicing failed. Reason: " + drItem["Description"].ToString() + "\n";						
			//							//iItemCount++;
			//						}
			//						else 
			//						{
			//							if(drItem["Passed"].ToString() == "1")
			//								sMsgText = sMsgText + "Item " + sFullItemCode + ": Customer Program failed. Prices will be calculated according to the 'Failed' tab" + "\n";
			//							//else
			//							iItemCount++;
			//						}
			//					}
			//
			//					sMsgText = sMsgText == ""?"Invoicing finished without warnings" : sMsgText;
			//					MessageBox.Show(sMsgText, "Batch " + sFullBatchCode, MessageBoxButtons.OK, MessageBoxIcon.Information);
			//					sMsgText = "";
			//					if(obInvoiceID != null)
			//					{
			//						int InvoiceCode = 0;
			//						try
			//						{
			//							InvoiceCode = Convert.ToInt32(obInvoiceID);
			//							InvoiceCode += 500;
			//							sInvoiceID = InvoiceCode.ToString();
			//						}
			//						catch{}
			//						if(sInvoiceID!="")
			//						{
			//							dtInvoice.Rows.Add(new object[]{});
			//							dtInvoice.Rows[dtInvoice.Rows.Count-1]["BatchCode"] = sFullBatchCode;
			//							dtInvoice.Rows[dtInvoice.Rows.Count-1]["InvoiceCode"] = dtCustomer.Rows[0]["ShortName"].ToString() + sInvoiceID;
			//							dtInvoice.Rows[dtInvoice.Rows.Count-1]["ItemCount"] = iItemCount;
			//						}
			//					}
			//
			//				}
			//				string msg = "";
			//				foreach(DataRow dr in dtInvoice.Rows)
			//				{
			//					msg += "Batch " + dr["BatchCode"].ToString()+ " has Invoice N " +
			//						dr["InvoiceCode"].ToString() + 
			//						" (Invoiced Items " + dr["ItemCount"].ToString() + ").          \n";
			//				}
			//				
			//				if(msg!="")
			//				{
			//					msg += "Print invoices?";
			//					DialogResult res =
			//						MessageBox.Show(this,msg,"Billing",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
			//					if(res == DialogResult.Yes)
			//					{
			//						//print invoice
			//
			//					}
			//				}
			//
			//				sOperationMsg = "Operation succeed";
			//				sbStatus.Text = sOperationMsg;
			//			}
			//			catch(Exception exc)
			//			{				
			//				bFailed = true;
			//				sOperationMsg = "Operation failed.\n" + exc.Message;
			//				sbStatus.Text = "Operation failed";
			//			}
			//			finally
			//			{
			//				MessageBox.Show(sOperationMsg, "Billing", MessageBoxButtons.OK, (bFailed)?MessageBoxIcon.Error:MessageBoxIcon.Information);
			//				this.Cursor = Cursors.Default;
			//				sbStatus.Text = "Ready";
			//			}
			//rbDefault.Checked = true;
		}
		
		//Invoicing Batch w/o memo
		private Object InvoiceBatch(Object oBatchID, Object oInInvoiceID, DataTable dtItems)
		{
			DataView dvItems4Invoice = dtItems.DefaultView;
			dvItems4Invoice.RowFilter = "BatchID = '" + oBatchID.ToString() + "'";

			Object oInvoiceID = oInInvoiceID; //for batches w/o memo oInInvoiceID == null
			
			DataTable dtInvoice = new DataTable("Invoice2");
			dtInvoice.Columns.Add("CustomerID");
			dtInvoice.Columns.Add("CustomerOfficeID");					

			Int32 iIsPassed = 1;
			String sDescription = "";

			DataSet dsBatchInvoice = Service.GetBatchInvoice(oBatchID.ToString());//Procedure dbo.spGetBatchInvoice

			for (int i = 0; i < dvItems4Invoice.Count; i++)
			{
				//if item is not invoiced
				if (dsBatchInvoice.Tables[0].Select("ItemCode = '" + dvItems4Invoice[i].Row["Code"].ToString() + "'").Length == 0)
				{
					//if invoice is not created yet creating it	
					if (oInvoiceID == null)
					{											
						dtInvoice.Rows.Add(dtInvoice.NewRow());
						dtInvoice.Rows[0]["CustomerID"] = cbcCustomer.SelectedID.Split('_')[1];
						dtInvoice.Rows[0]["CustomerOfficeID"] = cbcCustomer.SelectedID.Split('_')[0];
						DataSet dsInvoiceItem = Service.AddInvoice2(dtInvoice, "Add");//Procedure dbo.spAddInvoice2

						oInvoiceID = dsInvoiceItem.Tables[0].Rows[0][0];						
					}
					else
					{
						if (Convert.ToInt64(oInvoiceID) == 0)
						{
							dtInvoice.Rows.Add(dtInvoice.NewRow());
							dtInvoice.Rows[0]["CustomerID"] = cbcCustomer.SelectedID.Split('_')[1];
							dtInvoice.Rows[0]["CustomerOfficeID"] = cbcCustomer.SelectedID.Split('_')[0];
							DataSet dsInvoiceItem = Service.AddInvoice2(dtInvoice, "Add");//Procedure dbo.spAddInvoice2

							oInvoiceID = dsInvoiceItem.Tables[0].Rows[0][0];							
						}
					}

					//sDescription = InvoiceItem(dtItems.Rows[i]["Code"], oBatchID, oInvoiceID, ref iIsPassed);
					//sd 22.12.2006
					DataRow[] drNewCode = dtItems.Select("BatchID = '" + oBatchID.ToString() + "' and Code = '" + dvItems4Invoice[i].Row["Code"].ToString() + "'");
					string sBatchID = oBatchID.ToString();
					string sItemCode = dvItems4Invoice[i].Row["Code"].ToString();
					
						sDescription = InvoiceItem(sItemCode, sBatchID, oInvoiceID, ref iIsPassed);
						dvItems4Invoice[i].Row["Passed"] = iIsPassed;
						dvItems4Invoice[i].Row["Description"] = sDescription;
				}
				else
				{
					dvItems4Invoice[i].Row["Passed"] = 1;
					dvItems4Invoice[i].Row["Description"] = "0_Item is already billed";
				}
			}
			if (oInvoiceID != null && Convert.ToInt64(oInvoiceID) != 0)
			{
				try
				{
					DataTable dtUpdateInvoice = new DataTable("Invoice2");
					dtUpdateInvoice.Columns.Add("ExistsInvoiceID");
					dtUpdateInvoice.Columns.Add("CustomerID");
					dtUpdateInvoice.Columns.Add("CustomerOfficeID");
					dtUpdateInvoice.Columns.Add("BillTo");
					dtUpdateInvoice.Rows.Add(dtUpdateInvoice.NewRow());
					dtUpdateInvoice.Rows[0]["CustomerID"] = cbcCustomer.SelectedID.Split('_')[1];
					dtUpdateInvoice.Rows[0]["CustomerOfficeID"] = cbcCustomer.SelectedID.Split('_')[0];
					dtUpdateInvoice.Rows[0]["ExistsInvoiceID"] = oInvoiceID;
					if (billingTo != 0) dtUpdateInvoice.Rows[0]["BillTo"] = billingTo;
					else dtUpdateInvoice.Rows[0]["BillTo"] = 0;
			
					DataSet dsInvoiceItem = Service.AddInvoice2(dtUpdateInvoice, "Update");
				}
				catch(Exception ex)
				{
					var a = ex.Message;
				}
			}
			return Convert.ToInt64(oInvoiceID);
		}

		//Invoicing Item
		private String InvoiceItem(Object oItemCode, Object oBatchID, Object oInvoiceID, ref Int32 iPassed)
		{
		    DataSet dsInvoiceItem = new DataSet();
			dsInvoiceItem.Tables.Add("InvoicingGo");
			dsInvoiceItem.Tables[0].Columns.Add("InvoiceID");
			dsInvoiceItem.Tables[0].Columns.Add("BatchID");
			dsInvoiceItem.Tables[0].Columns.Add("ItemCode");
			dsInvoiceItem.Tables[0].Columns.Add("Pass");
			dsInvoiceItem.Tables[0].Columns.Add("AddSKU");
			dsInvoiceItem.Tables[0].Columns.Add("AddLotNumber");
			dsInvoiceItem.Tables[0].Rows.Add(dsInvoiceItem.Tables[0].NewRow());

			DataSet dsItemCpAndPrice = Service.GetCheckItemCpAndPrice(oBatchID.ToString(), oItemCode.ToString());//Procedure dbo.spGetCheckItemCpAndPrice
			DataSet dsInvoicingResult = new DataSet();
			if(dsItemCpAndPrice.Tables[0].Rows[0]["Description"].ToString() == "")
			{
				dsInvoiceItem.Tables[0].Rows[0]["InvoiceID"] = oInvoiceID;
				dsInvoiceItem.Tables[0].Rows[0]["BatchID"] = oBatchID;
				dsInvoiceItem.Tables[0].Rows[0]["ItemCode"] = oItemCode;
				dsInvoiceItem.Tables[0].Rows[0]["Pass"] = dsItemCpAndPrice.Tables[0].Rows[0]["Pass"];
                dsInvoiceItem.Tables[0].Rows[0]["AddSKU"] = (cbBillingWithSKU.Checked ? 1 : 0);
                dsInvoiceItem.Tables[0].Rows[0]["AddLotNumber"] = (cbBillingWithLot.Checked ? 1 : 0);
//				if(bRegularBill)
//					dsInvoiceItem.Tables[0].Rows[0]["AddSKU"] = 0;
//				else
//					dsInvoiceItem.Tables[0].Rows[0]["AddSKU"] = 1;

				dsInvoicingResult = Service.InvoicingGo(dsInvoiceItem);//Procedure dbo.spSetInvoicingGo

				iPassed = Convert.ToInt32(dsItemCpAndPrice.Tables[0].Rows[0]["Pass"]);
				return dsInvoicingResult.Tables[0].Rows[0][0].ToString();		
			}
			else
			{
				iPassed = 1;
				return "0_" + dsItemCpAndPrice.Tables[0].Rows[0]["Description"].ToString();
			}
		}

		private void btnFoceEndSession_Click(object sender, System.EventArgs e)
		{
			endSession(true);
		}

		private void tbMemoNumber_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				bSearch_Click(sender, System.EventArgs.Empty);
			}
		}

		private void lvMigratedItemData_DoubleClick(object sender, System.EventArgs e)
		{
			int iLength = 0;
            int i = ((ListView)sender).SelectedIndices[0];
            string sOrder = ((ListView)sender).Items[i].SubItems[2].Text;
            if (sOrder.Length == 12) iLength = 5;
            if (sOrder.Length == 13) iLength = 6;			
            sOrder = ((ListView)sender).Items[i].SubItems[2].Text.Substring(0, iLength) + "." + ((ListView)sender).Items[i].SubItems[2].Text.Trim();
			tbSearchUnit.Text = sOrder;
			bSearch_Click(sender, System.EventArgs.Empty);
		}

		private void otOpenOrders_RealDoubleClick(object sender, System.EventArgs e)
		{
			if(otOpenOrders.Selected.tblName == "tblOrder")
			{
				tbSearchUnit.Text = otOpenOrders.Selected.NodeCode;
				bSearch_Click(sender, System.EventArgs.Empty);
			}
		}

		private void bOrderReports_Click(object sender, System.EventArgs e)
		{
			otOrderReports.Initialize(otOpenOrders.GetTotalOrder());
			otOrderReports.Update();
			otOrderReports.Select();
			imageReportsList.Images.Clear();
			lvReportList.Items.Clear();
			lvReportPictures.Items.Clear();
			
			if (pbReportView.Image != null) 
			{
				pbReportView.Image.Dispose();
				pbReportView.Image = null;
			}

			label13.Text = "";
			tcMain.SelectedTab = tcMain.TabPages[3];
			string OrderCode = Service.FillToFiveChars(otOrderReports.dsOrderTree.Tables["tblOrder"].Rows[0]["OrderCode"].ToString());
			
			if (dtReportList != null)
			{
				dtReportList.Dispose();
				dtReportList = null;
			}
			
			if (otOrderReports.dsOrderTree != null)
			{
				dtReportList = LoadItemReportsList(otOrderReports.dsOrderTree);
				if (dtReportList != null)
				{
					if (!LoadReportFilesList(dtReportList)) 
					{
						MessageBox.Show("Order # " + OrderCode + " has no printed reports", "No Printed Reports", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
					else
					{
						bmissedReports_Click(sender, System.EventArgs.Empty);
						if (lvReportList.Items.Count == 0)
						{
							bprintedReport_Click(sender, System.EventArgs.Empty);
						}
						else
						{
							MessageBox.Show("Order # " + OrderCode + " has missed reports", "Missed Reports", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						}
					}
				}
			}
		}
		
		private bool LoadReportFilesList(DataTable dtReports)
		{
			bool bResult = false;
			string sPath = Client.GetOfficeDirPath("jpgDir");
			string sReportName = "";
			string sFileName;
			string sItemVVNNumber = "";

			foreach (DataRow r in dtReports.Rows)
			{
				sReportName = r["ReportNameVVN"].ToString();
				sItemVVNNumber = sPath + r["OldNumber"].ToString() + "." + r["VVN"] + ".jpg";
				sFileName = sPath + sReportName + ".jpg";
				if (sReportName.Trim() != "")
				{
					if (File.Exists(sFileName))
					{
						r["ReportFileName"] = sFileName;
						bResult = true;
					}
					else
					{
						if (File.Exists(sItemVVNNumber))
						{
							r["ReportFileName"] = sItemVVNNumber;
							bResult = true;
						}
						else
							r["ReportFileName"] = DBNull.Value;
					}
				}
			}
			return  bResult;
		}
		
		private void LoadThumbNails(string sOrderTreeReportName)
		{
			lvReportPictures.Items.Clear();
			imageReportsList.Images.Clear();
			string sNode = "";
			
			if (pbReportView.Image != null) 
			{
				pbReportView.Image.Dispose();
				pbReportView.Image = null;
			}
			if (sOrderTreeReportName.Trim() == "")
			{
				sNode = otOrderReports.Selected.NodeCode.Trim();
			}
			else
			{
				sNode = sOrderTreeReportName;
			}

			DataView dvReportsFiles = new DataView(dtReportList);

			if (sNode.Length < 19)
			{
				dvReportsFiles.RowFilter = "OrderTreeReportName Like '*" + sNode + "*'";
			
				if (dvReportsFiles.Count > 0)
				{
					foreach (DataRowView dvr in dvReportsFiles)
					{
						string sFullFileName = dvr["ReportFileName"].ToString().Trim();
						if (sFullFileName != "")
						{
							Image imgReport = System.Drawing.Image.FromFile(sFullFileName);
							Image icoReport = imgReport.GetThumbnailImage(imageReportsList.ImageSize.Width,imageReportsList.ImageSize.Height,null,IntPtr.Zero);
							imageReportsList.Images.Add(icoReport);
							string sFileName = dvr["RealReportName"].ToString();
							lvReportPictures.Items.Add(sFileName,imageReportsList.Images.Count-1);
							lvReportPictures.Items[lvReportPictures.Items.Count-1].Tag = sFileName;	
							if (dvReportsFiles.Count == 1)
							{
								lvReportPictures.Items[0].Selected = true;
							}
						}
					}
			
				}
				else
				MessageBox.Show("Order/Batch/Item # " + sNode + " has no printed reports", "No Printed Reports", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}		
		}

		private void otOrderReports_RealDoubleClick(object sender, System.EventArgs e)
		{
			LoadThumbNails("");
		}

		private DataTable LoadItemReportsList(DataSet dsOrder)
		{
			string sName;
			string sNewNum;
			string sPrevNum;
			string sVVN;
			string sOrder = Service.FillToFiveChars(dsOrder.Tables["tblOrder"].Rows[0]["OrderCode"].ToString());
			
			DataRow myDataRow;
			DataRow [] iRowDocs;
			DataRow [] iRowVVN;
			DataTable dtReportItemFile = new DataTable();
			dtReportItemFile.Columns.Add("NewNumber");
			dtReportItemFile.Columns.Add("OldNumber");
			dtReportItemFile.Columns.Add("OperationChar");
			dtReportItemFile.Columns.Add("ReportFileName");
			dtReportItemFile.Columns.Add("DocumentTypeCode");
			dtReportItemFile.Columns.Add("OrderTreeReportName");
			dtReportItemFile.Columns.Add("RealReportName");
			dtReportItemFile.Columns.Add("ReportNameVVN");
			dtReportItemFile.Columns.Add("NewbatchID");
			dtReportItemFile.Columns.Add("Name");
			dtReportItemFile.Columns.Add("VVN");

			//DataTable dtBatch = dsOrder.Tables["tblBatch"];
			DataTable dtItems = dsOrder.Tables["tblItem"];
			DataTable dtItemsDocs = dsOrder.Tables["tblDocument"];

            DataTable dtOrderVVN = Service.GetItemDataByOrderBatchItemMeasure(sOrder, "0", "0", "92", "0");
			
			DataView dvDocs = new DataView(dtItemsDocs);
			dvDocs.RowFilter = "DocumentTypeCode Not In (5,6,8,17,10,12,13,14,19,20,16)";
			DataTable dtDocs = new DataTable();
			
			dtDocs = dvDocs.Table.Clone();

			foreach (DataRowView dvr in dvDocs)
			{
				dtDocs.ImportRow(dvr.Row);
			}
			dtDocs.AcceptChanges();
			
			if (dvDocs.Count > 0)
			{
				try
				{
					foreach (DataRow dr in dtItems.Rows)
					{
						sVVN = "";
						sName = dr["Name"].ToString();	
						iRowDocs = dtDocs.Select("Name like '*" + sName + "'");
							
						sPrevNum = GraderLib.GetCorrectOrderBatchItemCodeStringNoDots(
													Convert.ToInt32(dr["PrevGroupCode"]),
													Convert.ToInt32(dr["PrevBatchCode"]), 
													Convert.ToInt32(dr["PrevItemCode"]));
						
						sNewNum = GraderLib.GetCorrectOrderBatchItemCodeStringNoDots(
													Convert.ToInt32(dr["NewOrderCode"]),
													Convert.ToInt32(dr["NewBatchCode"]), 
													Convert.ToInt32(dr["NewItemCode"]));
						
						iRowVVN = dtOrderVVN.Select("NewItemNumber = '" + sNewNum + "'");
						if (iRowVVN.Length > 0) 
						{
							sVVN = iRowVVN[0]["ResultValue"].ToString();
						}
			
						if (iRowDocs.Length > 0)
						{
							foreach (DataRow r in iRowDocs)
							{
								myDataRow = dtReportItemFile.NewRow();
								myDataRow["NewNumber"] = sNewNum;
								myDataRow["OldNumber"] = sPrevNum;
								myDataRow["OperationChar"] = r["OperationChar"].ToString();
								myDataRow["DocumentTypeCode"] = Convert.ToInt32(r["DocumentTypeCode"]);
								myDataRow["OrderTreeReportName"] = r["Name"].ToString();
								myDataRow["RealReportName"] = r["OperationChar"].ToString() + sPrevNum;
								myDataRow["NewBatchID"] = Convert.ToInt32(dr["NewBatchID"]);
								myDataRow["Name"] = dr["Name"].ToString();
								myDataRow["VVN"] = sVVN;

								if (sVVN.Length > 9)
								{
									myDataRow["ReportNameVVN"] = r["OperationChar"].ToString() + sPrevNum + "." + sVVN;
								}
								dtReportItemFile.Rows.Add(myDataRow);
							}
						}
						else
						{
							myDataRow = dtReportItemFile.NewRow();
							myDataRow["NewNumber"] = sNewNum;
							myDataRow["OldNumber"] = sPrevNum;
							myDataRow["NewBatchID"] = Convert.ToInt32(dr["NewBatchID"]);
							myDataRow["Name"] = dr["Name"].ToString();
							dtReportItemFile.Rows.Add(myDataRow);
						}
					}
				}
				catch(Exception exc)
				{
					this.Cursor = Cursors.Default;
					MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				MessageBox.Show("Order # " + sOrder + " has no attached reports", "No Reports", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return null;
			}
			return dtReportItemFile;
		}

		private void bClose_otReports_Click(object sender, System.EventArgs e)
		{
			otOrderReports.Clear();
			lvReportList.Items.Clear();
			lvReportPictures.Items.Clear();
			dtReportList = null;
			label13.Text = "";
			if(pbReportView.Image != null)
			{
				pbReportView.Image.Dispose();
				pbReportView.Image = null;
			}
			imageReportsList.Images.Clear();
			tcMain.SelectedTab = tcMain.TabPages[1];
		}

	
		private void lvReportPictures_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (pbReportView.Image != null) 
			{
				pbReportView.Image.Dispose();
				pbReportView.Image = null;
				pbReportView.SizeMode = PictureBoxSizeMode.StretchImage;
				pbReportView.ClientSize = new Size(pnlReportContainer.Width - 5, pnlReportContainer.Height - 5);
			}
			try
			{
				if(lvReportPictures.Items.Count > 0 && lvReportPictures.SelectedItems.Count>0)
				{
					string sReportName = lvReportPictures.SelectedItems[0].Tag.ToString();
					string myShapeFileName = "";

					DataRow[] drReports = dtReportList.Select("RealReportName = '" + sReportName + "'");
					if(drReports.Length > 0)
					{
						myShapeFileName = drReports[0]["ReportFileName"].ToString();;

						if (System.IO.File.Exists(myShapeFileName))
						{
							Image imgReport =  System.Drawing.Image.FromFile(myShapeFileName);

							if(imgReport != null)
							{
								Service.DrawAdjustShapeImage(this.pbReportView, imgReport);
								this.pbReportView.Tag = myShapeFileName;
							}
							
						}
					}
				}
			}
			catch(Exception ex)
			{
				string msg = ex.Message;
				MessageBox.Show(msg, "Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void bZoomPlus_Click(object sender, System.EventArgs e)
		{
			ZoomPicture(1.1);
		}

		private void otOrderReports_SelectedItemChanged(object sender, System.EventArgs e)
		{
			if(otOrderReports.Selected.tblName != "tblOrder")
			LoadThumbNails("");
		}

		private void bZoomMinus_Click(object sender, System.EventArgs e)
		{
			ZoomPicture(0.9);
		}
		
		private void ZoomPicture(double zoomScale)
		{
			string rptFilename;
			pbReportView.SizeMode = PictureBoxSizeMode.AutoSize;

			if (pbReportView.Image != null)
			{
				rptFilename = pbReportView.Tag.ToString();
				double imHeight = (double)pbReportView.Image.Height * zoomScale;
				double imWidth = (double)pbReportView.Image.Width * zoomScale;
	
				Image imgShape = System.Drawing.Image.FromFile(rptFilename);

				int h1 = Convert.ToInt32(imHeight);
				int w1 = Convert.ToInt32(imWidth);
				
				pbReportView.Image.Dispose();
				Image icoShape = imgShape.GetThumbnailImage(w1,h1,null,IntPtr.Zero);
				pbReportView.Image = icoShape;
			}		
		
		}

		private void bRestorePicture_Click(object sender, System.EventArgs e)
		{
			if (pbReportView.Image != null) 
			{
				pbReportView.Image.Dispose();
				pbReportView.Image = null;
				pbReportView.SizeMode = PictureBoxSizeMode.StretchImage;
				pbReportView.ClientSize = new Size(pnlReportContainer.Width - 5, pnlReportContainer.Height - 5);
			}
			string 	rptFilename = pbReportView.Tag.ToString();
			
			Image imgReport = System.Drawing.Image.FromFile(rptFilename);
			if(imgReport != null)
			{
				Service.DrawAdjustShapeImage(this.pbReportView, imgReport);
				this.pbReportView.Tag = rptFilename;
			}
		}

		private void bprintedReport_Click(object sender, System.EventArgs e)
		{
			if(dtReportList == null) return;
			string sReportStatus = "Printed";
			DataView dvPrinted = new DataView(dtReportList);
			dvPrinted.RowFilter = "ISNULL(ReportFileName,'') <> '' and ISNULL(RealReportName,'') <> ''";
			FillListView(dvPrinted, sReportStatus);
		}

		private void bmissedReports_Click(object sender, System.EventArgs e)
		{
			if(dtReportList == null) return;
			string sReportStatus = "Missed";
			DataView dvPrinted = new DataView(dtReportList);
			dvPrinted.RowFilter = "ISNULL(ReportFileName,'') = '' and ISNULL(RealReportName,'') <> ''";
			FillListView(dvPrinted, sReportStatus);
		}

		private void FillListView(DataView dvDataToFill, string sReportStatus)
		{
			ListViewItem lv;
			lvReportList.Items.Clear();
			foreach(DataRowView dr in dvDataToFill)
			{
				lv = new ListViewItem(dr["NewNumber"].ToString());
				lv.SubItems.Add(dr["RealReportName"].ToString());
				lv.SubItems.Add(dr["OperationChar"].ToString());
				lv.SubItems.Add(sReportStatus);
				lv.SubItems.Add(dr["Name"].ToString());
				lvReportList.Items.Add(lv);
			}
			string OrderCode = Service.FillToFiveChars(otOrderReports.dsOrderTree.Tables["tblOrder"].Rows[0]["OrderCode"].ToString());
			label13.Text = "Order " + OrderCode + ": " + lvReportList.Items.Count.ToString() + " " + sReportStatus + " reports";

		}

		private void lvReportList_DoubleClick(object sender, System.EventArgs e)
		{

		}

		private void lvReportList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string sOrderTreeReportName;
			foreach(ListViewItem item1 in lvReportList.Items)
			{
				if (item1.Selected)
				{
					sOrderTreeReportName = item1.SubItems[4].Text.Trim();
					LoadThumbNails(sOrderTreeReportName);
					break;					
				}
			}
		}

		private void bBillWithSKU_Click(object sender, System.EventArgs e)
		{
//			bRegularBill = false;
//			InvoicingGo();
//			bRegularBill = true;
		}

		private DataGridTableStyle OrderForDataGrid(string mappingName)
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

		private void tbOrderToDelivery_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				nonNumberEntered = false;
				if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
				{
					if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
					{
						if(e.KeyCode != Keys.Back)
						{
							if(e.KeyCode != Keys.Return)
								nonNumberEntered = true;
						
						}
					}
				}  //'" + dr["OperationTypeGroupName"].ToString() + "'"
				if (e.KeyCode == Keys.Return)
				{
					if(tbOrderToDelivery.Text.Trim().Length == 5)
					{
						if(dsOrdersToDelivery.Tables[0].Rows.Count > 0)
						{
							DataRow[] dr = dsOrdersToDelivery.Tables[0].Select("OrderCode = '" + tbOrderToDelivery.Text.Trim() + "'");
							if (dr.Length > 0)
							{
								MessageBox.Show("Duplicate Order # " + tbOrderToDelivery.Text, "Wrong Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
								tbOrderToDelivery.Text = "";
								tbOrderToDelivery.Focus();
								return;							
							}
						}
						DataTable dt = Service.GetOrderByOrderCode2(tbOrderToDelivery.Text.Trim());
						if (dt.Rows.Count == 0)
						{
							MessageBox.Show("Wrong Order # " + tbOrderToDelivery.Text, "Wrong Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
							tbOrderToDelivery.Text = "";
							tbOrderToDelivery.Focus();
							return;
						}
						string sOrder = Service.FillToFiveChars(dt.Rows[0]["OrderCode"].ToString());
						if(System.Convert.ToInt32(dt.Rows[0]["StateCode"]) == 1)
						{
							if(MessageBox.Show("Order # " + sOrder + " is closed. Would you like to add it to list for delivery?" ,
								"Order status", 
								MessageBoxButtons.YesNo,
								MessageBoxIcon.Question,
								MessageBoxDefaultButton.Button2) == DialogResult.No)
							{
								tbOrderToDelivery.Text = "";
								tbOrderToDelivery.Focus();								
								return;
							}
						}
						string [] sCustomer = dt.Rows[0]["CustomerName"].ToString().Split(',');
						dsOrdersToDelivery.Tables[0].Rows.Add(new object[] {	sOrder,
																				"",//dt.Rows[0]["ItemsQuantity"],
																				sCustomer[0],//dt.Rows[0]["CustomerName"],
																				dt.Rows[0]["CustomerCode"],
																				dt.Rows[0]["Memo"]
																			});
						tbOrderToDelivery.Text = "";
						tbOrderToDelivery.Focus();
					}
				}
			}
			catch{}
		}

		private void tbOrderToDelivery_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = nonNumberEntered;
		}

		private void tbOrderToDelivery_Enter(object sender, System.EventArgs e)
		{
			tbOrderToDelivery.Clear();
		}

		private void tcMain_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (bLoading && tcMain.SelectedIndex == 4)
			{
				tbSearchUnit.Text = "";
				tbOrderToDelivery.Text = "";
				tbOrderToDelivery.Focus();
			}
			if (bLoading && tcMain.SelectedIndex == 5)
			{
				tcMain.SelectedTab = tcMain.TabPages[5];
				if (myActiveOrder.Trim() != "")
				{
					FillBlockedDataObjects(myActiveOrder, "");
					//cbCustomerProgram.SelectedIndexChanged += new System.EventHandler(this.cbCustomerProgram_SelectedIndexChanged);
				}
			}
		}

		private void OrderTable_Deleted(object sender, System.Data.DataRowChangeEventArgs e)
		{
			dsOrdersToDelivery.Tables[0].AcceptChanges();
			if(otDelivery.dsOrderTree != null)
			{
				otDelivery.Clear();
				ViewDetailsForOrders();
			}
		}
		
		private void InitOrderDataGrid(string mappingName)
		{
			dgOrdersToDelivery.SetDataBinding(null, ""); 
			string[] columnNames = new string[] 
					{
						"OrderCode", "ItemsQuantity", "CustomerName", "CustomerCode", "Memo"
					};
		
			string[] headerText = new string[] 
					{
						"Order", "Qty", "Customer", "C.Code", "Memo"
					};
			
			int[] columnWidth = new int[]
					{
						60, 30, 180, 50, 110
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

			dgOrdersToDelivery.TableStyles.Clear();
			dgOrdersToDelivery.TableStyles.Add(tableStyle);
		}

		private void tbOrderToDelivery_TextChanged(object sender, System.EventArgs e)
		{

		}

		private void ViewDetailsForOrders()
		{
			bool bOrdersExist = false;
			try
			{
				DataSet dsOrders = new DataSet();
				dsOrders.DataSetName = "OrderSet";
				DataTable dtOrders = new DataTable("Orders");
				//				dsOrders.Tables.Add(dtOrders);
				dtOrders.Columns.Add(new DataColumn ("OrderCode", typeof(string)));
				
				if(dsOrdersToDelivery.Tables[0].Rows.Count > 0)
				{
					bOrdersExist = true;
					foreach(DataRow dr in dsOrdersToDelivery.Tables[0].Rows)
					{
						object oOrder = dr["OrderCode"].ToString();
						dtOrders.Rows.Add(new object[]{oOrder});	
					}
				}
				dsOrders.Tables.Add(dtOrders);
				object aOrders = dsOrders.GetXml();
				FillOrderTreeFromList(aOrders);

				if(bOrdersExist) UpdateOrdersList(dsOrdersToDelivery);
			}
			catch
			{}
		
		}

		private void bAddOrderToList_Click(object sender, System.EventArgs e)
		{
			ViewDetailsForOrders();
		}
		
		private void UpdateOrdersList(DataSet dsOrders)
		{
			foreach(DataRow dr in  dsOrdersToDelivery.Tables[0].Rows)
			{
				DataRow[] drs = otDelivery.dsOrderTree.Tables["tblItem"].Select("OrderCode = '" + dr["OrderCode"].ToString() + "'");
				dr["ItemsQuantity"] = drs.Length;
			}
		}

		private void cbMessenger_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			bPrintDeliveryReport.Enabled = true;
		}

		private void bOrdersForDelivery_Click(object sender, System.EventArgs e)
		{
		
		}

        private void cbRegularBilling_CheckedChanged(object sender, System.EventArgs e)
        {
            if(cbRegularBilling.Checked)
            {
                cbBillingWithSKU.Checked = false;
                cbBillingWithLot.Checked = false;
                bBill.Text = "Regular Billing";
            }
        }

        private void cbBillingWithSKU_CheckedChanged(object sender, System.EventArgs e)
        {
            cbRegularBilling.Checked = false;
            switch (cbBillingWithSKU.Checked)
            {
                case true:
                    if (cbBillingWithLot.Checked) bBill.Text = "Billing with SKU and Lot#";
                    else bBill.Text = "Billing with SKU";
                    break;
            
                case false:
                    if (cbBillingWithLot.Checked) bBill.Text = "Billing with Lot#";
                    else cbRegularBilling.Checked = true;
                    break;
            }
       
        }

        private void cbBillingWithLot_CheckedChanged(object sender, System.EventArgs e)
        {
           cbRegularBilling.Checked = false;  
            switch (cbBillingWithLot.Checked)
            {
                case true:
                    if (cbBillingWithSKU.Checked) bBill.Text = "Billing with SKU and Lot#";
                    else bBill.Text = "Billing with Lot#";        
                    break;

                case false:
                    if (cbBillingWithSKU.Checked) bBill.Text = "Billing with SKU";
                    else cbRegularBilling.Checked = true;
                    break;
            }
          
        }

		private void cbcCustomer_Load(object sender, EventArgs e)
		{

		}

        private string FillToFiveChars(string sNumber)
        {
            while (sNumber.Length < 5)
                sNumber = "0" + sNumber;
            return sNumber;
        }

		private void cmd_ClearAddServiceList_Click(object sender, EventArgs e)
		{
			lvAddServices.Items.Clear();
		}

		private void cmd_ReloadList_Click(object sender, EventArgs e)
		{
			string sOrder = tbSearchUnit.Text.Split(new char[] { '.' })[0].TrimStart(new char[] { '0' });
			FillAddServicesList(sOrder, "0");
		}

		private void SaveAddServices()
		{
			DataSet dsTemp = new DataSet("AllServices");
			DataTable dt = new DataTable();
			string sOrder = tbSearchUnit.Text.Split(new char[] { '.' })[0].TrimStart(new char[] { '0' });

			dt.TableName = "Services";
		
			try
			{
				if (lvAddServices.Items.Count > 0)
				{
					for (int i = 0; i < lvAddServices.Items[0].SubItems.Count - 1; i++)
					{
						//if (lvAddServices.Items[0].SubItems[i].GetType() == typeof(string))
						{
							dt.Columns.Add("col" + i.ToString());
						}
					}

					foreach (ListViewItem item in lvAddServices.Items)
					{
						if (item.Checked)
						{
							DataRow dr = dt.NewRow();
							for (int i = 0; i < dt.Columns.Count; i++)
							{
								dr[i] = item.SubItems[i+1].Text;
							}
							dt.Rows.Add(dr);
						}
					}
					dsTemp.Tables.Add(dt);
#if DEBUG
					// For debugging only			
					string filename = "C:/DELL/myXmlAddServicesList.xml";
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
					DataTable dtIn = dsIn.Tables.Add("SaveTotblTmpAdditionalServiceByBatch");
					dtIn.Columns.Add("XmlServices", System.Type.GetType("System.String"));
					dtIn.Columns.Add("OrderCode", System.Type.GetType("System.String"));
					DataRow row = dtIn.NewRow();
					dtIn.Rows.Add(row);
					row["XmlServices"] = dsTemp.GetXml();
					row["OrderCode"] = sOrder;
					DataSet dsOut = Service.ProxyGenericSet(dsIn, "Set");
				}
			}
			catch(Exception ex)
			{
				var a = ex.Message;
			}
		}


		private void otOpenOrders_AfterCheck(object sender, TreeViewEventArgs e)
		{
			var a = e.Node.Level;
			var b = e.Node.Checked;
			var nodeCode = ((OrderNode)e.Node).NodeCode.Split('.');
			if (e.Node.Level == 3) return;
			try
			{
				switch (e.Node.Level)
				{
					case 0:
						//if (nodeCode.Length > 1)
						//{
						//	if (e.Node.Checked && !((OrderNode)e.Node).IsChecked)
						//	{
						//		lvAddServices.Items.Clear();
						//		FillAddServicesList(nodeCode[0], "0");
						//	}
						//	if (!e.Node.Checked && ((OrderNode)e.Node).IsChecked)
						//		lvAddServices.Items.Clear();
						//}
						//	//else
						//	//	lvAddServices.Items.Clear();
						break;
					case 1:
						//goto exit;
						//if (!e.Node.Parent.Checked)
						//{
						//	if (nodeCode.Length > 2)
						//	{
						//		if (e.Node.Checked && !((OrderNode)e.Node).IsChecked) // && ((Cntrls.OrderNode)e.Node).IsChecked)
						//		{
						//			foreach (ListViewItem lv in lvAddServices.Items)
						//			{
						//				if (Int32.Parse(lv.SubItems[4].Text) == Int32.Parse(nodeCode[2]))
						//					return; // break; // goto exit;
						//			}
						//			FillAddServicesList(nodeCode[0], nodeCode[2]);
						//		}
						//		if (!e.Node.Checked && ((OrderNode)e.Node).IsChecked)
						//			lvAddServices.Items.Clear();
						//	}
						//}
						break;

						//		case 2:
						//		{
						//			if (e.Node.Nodes.Count > 0)
						//			{
						//				foreach (TreeNode nNode in e.Node.Nodes)
						//				{
						//					if (nNode.Checked) return;
						//					//i++;
						//				}
						//			}
						//			else
						//			{
						//				lvAddServices.BeginUpdate();

						//				foreach (ListViewItem lv in lvAddServices.Items)
						//				{
						//					if (Int32.Parse(lv.SubItems[4].Text) == Int32.Parse(nodeCode[2]))
						//						lv.Remove();
						//				}
						//				lvAddServices.EndUpdate();
						//				lvAddServices.Refresh();
						//			}
						//		}
						//	}
						//}
						//break;

					case 2:
						//case 3:
						//break;
						//goto exit;
						//if (!e.Node.Parent.Checked)
						{
							if (nodeCode.Length > 2)
							{
								var i = 0;
								if (e.Node.Checked && !((OrderNode)e.Node).IsChecked) // && ((Cntrls.OrderNode)e.Node).IsChecked)
								{
									foreach (ListViewItem lv in lvAddServices.Items)
									{
										if (Int32.Parse(lv.SubItems[4].Text) == Int32.Parse(nodeCode[2]))
											return; // break; // goto exit;
									}
									FillAddServicesList(nodeCode[0], nodeCode[2]);
								}

								if (!e.Node.Checked && ((OrderNode)e.Node).IsChecked)

								{
									foreach (TreeNode nNode in e.Node.Parent.Nodes)
									{
										if (nNode.Checked) return;
										//i++;
									}

									lvAddServices.BeginUpdate();
									foreach (ListViewItem lv in lvAddServices.Items)
									{
										if (Int32.Parse(lv.SubItems[4].Text) == Int32.Parse(nodeCode[2]))
											lv.Remove();
									}
									lvAddServices.EndUpdate();
									lvAddServices.Refresh();
									return;

								}
							}
						}
						break;
//exit:
					default:
						break;
				}
			}
			catch { }
		}

		//private void otOpenOrders_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		//{
		//	var a = e.Node.Level;
		//	var b = e.Node.Checked;
		//	if (e.Node.Level == 3) return;
		//	var nodeCode = ((OrderNode)e.Node).NodeCode.Split('.');
		//	return;
		//	try
		//	{
		//		switch (e.Node.Level)
		//		{
		//			case 0:
		//				if (nodeCode.Length > 1)
		//					if (e.Node.Checked) // && ((Cntrls.OrderNode)e.Node).IsChecked)
		//					{
		//						lvAddServices.Items.Clear();
		//						FillAddServicesList(nodeCode[0], "0");
		//					}
		//				else
		//						lvAddServices.Items.Clear();
		//				break;
		//			case 1:
		//				//if (!e.Node.Parent.Checked)
		//				{
		//					if (nodeCode.Length > 2)
		//					{
		//						if (e.Node.Checked) // && ((Cntrls.OrderNode)e.Node).IsChecked)
		//						{
		//							foreach (ListViewItem lv in lvAddServices.Items)
		//							{
		//								if (Int32.Parse(lv.SubItems[4].Text) == Int32.Parse(nodeCode[2]))
		//									break; // goto exit;
		//							}
		//							FillAddServicesList(nodeCode[0], nodeCode[2]);
		//						}
		//						else
		//						{
		//							lvAddServices.BeginUpdate();

		//							foreach (ListViewItem lv in lvAddServices.Items)
		//							{
		//								if (Int32.Parse(lv.SubItems[4].Text) == Int32.Parse(nodeCode[2]))
		//									lv.Remove();
		//							}
		//							lvAddServices.EndUpdate();
		//							lvAddServices.Refresh();
		//						}
		//					}
		//				}
		//				break;

		//			case 2:
		//			//case 3:
		//				//if (!e.Node.Parent.Checked)
		//				{
		//					if (nodeCode.Length > 2)
		//					{
		//						var i = 0;
		//						if (e.Node.Checked)
		//						{
		//							foreach (ListViewItem lv in lvAddServices.Items)
		//							{
		//								if (Int32.Parse(lv.SubItems[4].Text) == Int32.Parse(nodeCode[2]))
		//									break; // goto exit;
		//							}
		//							FillAddServicesList(nodeCode[0], nodeCode[2]);
		//						}
		//						else
		//						{
		//							foreach (TreeNode nNode in e.Node.Parent.Nodes)
		//							{
		//								if (nNode.Checked)
		//									i++;
		//							}

		//							if (i == 0)
		//							{
		//								lvAddServices.BeginUpdate();
		//								foreach (ListViewItem lv in lvAddServices.Items)
		//								{
		//									if (Int32.Parse(lv.SubItems[4].Text) == Int32.Parse(nodeCode[2]))
		//										lv.Remove();
		//								}
		//								lvAddServices.EndUpdate();
		//								lvAddServices.Refresh();
		//							}
		//						}
		//					}
		//				}

		//				break;

		//			default:
		//				break;
		//		}
		//	}
		//	catch { }

		//}
		//private void otOpenOrders_AfterExpand(object sender, TreeViewEventArgs e)
		//{
		//	var nodeCode = ((OrderNode)e.Node).NodeCode.Split('.');
		//	if (e.Node.Level == 0)
		//		{
		//		var a = 0;
		//		}
		//	//try
		//	//{
		//	//	switch (e.Node.Level)
		//	//	{
		//	//		case 0:
		//	//			break;
		//	//		case 1:
		//	//			{
		//	//				if (nodeCode.Length > 2)
		//	//					if (e.Node.Checked) // && ((Cntrls.OrderNode)e.Node).IsChecked)
		//	//					{
		//	//						foreach (ListViewItem lv in lvAddServices.Items)
		//	//						{
		//	//							if (Int32.Parse(lv.SubItems[4].Text) == Int32.Parse(nodeCode[2]))
		//	//								goto exit;
		//	//						}
		//	//						FillAddServicesList(nodeCode[0], nodeCode[2]);
		//	//					}
		//	//					else
		//	//					{
		//	//						lvAddServices.BeginUpdate();

		//	//						foreach (ListViewItem lv in lvAddServices.Items)
		//	//						{
		//	//							if (Int32.Parse(lv.SubItems[4].Text) == Int32.Parse(nodeCode[2]))
		//	//								lv.Remove();
		//	//						}
		//	//						lvAddServices.EndUpdate();
		//	//						lvAddServices.Refresh();
		//	//					}
		//	//			}
		//	//			break;
		//	//		case 2:
		//	//		case 3:
		//	//		exit:
		//	//			break;

		//	//		default:
		//	//			break;
		//	//	}
		//	//}

		//	//catch { }
		//}
		#region Blocking_Parts
		private DataSet GetBlockedPartsSKUBatches(string sOrder)
		{
			DataSet dsTemp = new DataSet();
			dsTemp.Tables.Add("BatchBlockedParts1");
			dsTemp.Tables[0].Columns.Add("GroupCode", Type.GetType("System.String"));
			dsTemp.Tables[0].Columns.Add("BatchCode", Type.GetType("System.String"));
			dsTemp.Tables[0].Rows.Add(dsTemp.Tables[0].NewRow());
			dsTemp.Tables[0].Rows[0][0] = sOrder;
			dsTemp.Tables[0].Rows[0][1] = "0";
			DataSet dsOut = Service.ProxyGenericGet(dsTemp); //Procedure [dbo].[spGetBatchBlockedParts]
			return dsOut;
		}

		private void FillBlockedDataObjects(string sOrder, string sSelectBy)
		{
			try
			{
				label22.Text = "";
				lblStructure.Text = "";
				button5.Enabled = false;
				DataSet dsBatches = GetBlockedPartsSKUBatches(sOrder);
#if DEBUG
				// For debugging only			
				string filename = "C:/DELL/myXmlBlockedBatches.xml";
				if (File.Exists(filename)) File.Delete(filename);
				// Create the FileStream to write with.
				System.IO.FileStream myFileStream = new System.IO.FileStream(filename, System.IO.FileMode.Create);
				// Create an XmlTextWriter with the fileStream.
				System.Xml.XmlTextWriter myXmlWriter = new System.Xml.XmlTextWriter(myFileStream, System.Text.Encoding.Unicode);
				// Write to the file with the WriteXml method.
				dsBatches.WriteXml(myXmlWriter);
				myXmlWriter.Close();
				// End of debugging part
#endif
				if (dsBatches != null)
				{
					ListViewItem lv;
					DataRow[] dRows;
					isLoaded = true;
					lvBatchesToBlock.Items.Clear();
					if (sSelectBy == "") dRows = dsBatches.Tables[0].Select();
					else dRows = dsBatches.Tables[0].Select("CustomerProgramName = '" + sSelectBy + "'");

					if (dRows.Length > 0)
					{
						foreach (DataRow dRow in dRows)
						{
							lv = new ListViewItem("");
							//if (dRow[6].ToString() != "") lv.Checked = true;
							//else
							lv.Checked = false;
							lv.SubItems.Add(dRow[0].ToString());
							lv.SubItems.Add(dRow[1].ToString());
							lv.SubItems.Add(dRow[2].ToString());
							lv.SubItems.Add(dRow[3].ToString());
							lv.SubItems.Add(dRow[4].ToString());
							lv.SubItems.Add(dRow[5].ToString());
							dRow[6] = dRow[6] == DBNull.Value ? "" : dRow[6].ToString();
							dRow[6] = dRow[6].ToString().TrimStart(';');
							dRow[7] = dRow[7] == DBNull.Value ? "" : dRow[7].ToString();
							dRow[7] = dRow[7].ToString().TrimStart(';');
							dRow[8] = dRow[8] == DBNull.Value ? "" : dRow[8].ToString();
							dRow[8] = dRow[8].ToString().TrimStart(';');
							var temp = dRow[8].ToString();
							lv.SubItems.Add(dRow[6].ToString()); // == DBNull.Value ? "" : dRow[6].ToString());
							lv.SubItems.Add(dRow[7].ToString()); // == DBNull.Value ? "" : dRow[7].ToString());
							lv.SubItems.Add(dRow[8].ToString());
							//lv.SubItems.Add(dRow[6].ToString());
							//lv.SubItems.Add(dRow[7].ToString());
							lvBatchesToBlock.Items.Add(lv);
						}
						lvBatchesToBlock.ListViewItemSorter = new ListViewItemComparer(1);
						lvBatchesToBlock.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvBatchesToBlock_ItemSelectionChanged);
						//lvBatchesToBlock.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lvBatchesToBlock_ItemCheck);
						//lvBatchesToBlock.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvBatchesToBlock_ItemChecked);
					}
					if (sSelectBy.Trim() == "")
					{
						dRows = dsBatches.Tables[1].Select();
						if (dRows.Length > 0)
						{
							cbCustomerProgram.DataSource = dsBatches.Tables[1];
							cbCustomerProgram.DisplayMember = "CustomerProgramName";
							cbCustomerProgram.ValueMember = "ItemTypeID";
							cbCustomerProgram.SelectedIndex = -1;
							cbCustomerProgram.Text = "Customer program lookup";
							//cbCustomerProgram.SelectedIndexChanged += new System.EventHandler(this.cbCustomerProgram_SelectedIndexChanged);
						}
					}
					//cbCustomerProgram.SelectedIndexChanged += new System.EventHandler(this.cbCustomerProgram_SelectedIndexChanged);
					isLoaded = false;
					cmd_Reset.Enabled = true;
					cbCustomerProgram.SelectedIndexChanged += new System.EventHandler(this.cbCustomerProgram_SelectedIndexChanged);

				}

			}
			catch (Exception ex)
			{
				var a = ex.Message;
			}
		}
		private void InitPartTree(string sItemTypeID)
		{
			try
			{
				partView.Clear();
				dsStructure = new DataSet();
				dsStructure.Tables.Add(Service.GetParts(sItemTypeID));  //tblName : Parts	/Procedure dbo.spGetPartsByItemType
				//dsStructure.Tables.Add(Service.GetPartsStruct());   //tblName : SetParts

				this.partView.Initialize(dsStructure.Tables["Parts"]);
				this.partView.ExpandTree();
				//partView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.partView_AfterCheck);
#if DEBUG
				// For debugging only			
				string filename = "C:/DELL/myXmlPartsList.xml";
				if (File.Exists(filename)) File.Delete(filename);
				// Create the FileStream to write with.
				System.IO.FileStream myFileStream = new System.IO.FileStream(filename, System.IO.FileMode.Create);
				// Create an XmlTextWriter with the fileStream.
				System.Xml.XmlTextWriter myXmlWriter = new System.Xml.XmlTextWriter(myFileStream, System.Text.Encoding.Unicode);
				// Write to the file with the WriteXml method.
				dsStructure.WriteXml(myXmlWriter);
				myXmlWriter.Close();
				// End of debugging part
#endif
			}
			catch (Exception ex)
			{
				var a = ex.Message;
			}
		}

		private void cbCustomerProgram_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (isLoaded) return;
			if (reset) return;
			if (bulkMode)
			{
				
				var selectedSKU = cbCustomerProgram.Text.ToString();
				resetBlockedParts();
				FillBlockedDataObjects(myActiveOrder, selectedSKU);
				var sItemTypeID = cbCustomerProgram.SelectedValue;
				//InitPartTree(sItemTypeID.ToString());
				button5.Enabled = true;
				if (lvBatchesToBlock.Items.Count > 0)
				{
					lvBatchesToBlock.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvBatchesToBlock_ItemSelectionChanged);
					lvBatchesToBlock.Items[0].Selected = true;
					lvBatchesToBlock.Items[0].Checked = true;
					lvBatchesToBlock.Items[0].BackColor = Color.SkyBlue;
					bulkMode = false;
				}
				//lvBatchesToBlock.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvBatchesToBlock_ItemChecked);
			}
		}

		//private void UpdatePartTree(TreeNodeCollection nodes, List<string> partID, bool toCheck)
		//{
		//   try
		//	{
		//		if (partID.Count > 0)
		//		{
		//			foreach (var node in partID)
		//			{
		//				foreach (TreeNode tn in nodes)
		//				{
		//					if (node.Trim().ToUpper() == "ITEM CONTAINER" && tn.Text.Trim().ToUpper() == node.Trim().ToUpper())
		//					{
		//						tn.Checked = toCheck;
		//						continue;
		//					}
		//					FindRecursive(tn, node.Trim(), toCheck);
		//				}
		//			}
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		var a = ex.Message;
		//	}

		//}

		private void lvBatchesToBlock_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			try
			{
				if (reset) return;
				//var a = 123;
				var BatchID = "";
				var SKU = "";
				var indexNew = e.Item.Index;
				if (indexNew == indexOld) return;
				foreach (ListViewItem item in lvBatchesToBlock.Items)
				{
					item.BackColor = Color.White;
				}
				e.Item.BackColor = Color.SkyBlue;
				List<string> partID = new List<string>();
				isLoaded = true;
				var itemTypeID = e.Item.SubItems[5].Text;
				lblStructure.Text = "";
				label22.Text = "";
				InitPartTree(itemTypeID.ToString());
				lblStructure.Text = e.Item.SubItems[6].Text;
				BatchID = e.Item.SubItems[1].Text;
				SKU = e.Item.SubItems[4].Text;
				//label22.Text = "Batch " + e.Item.SubItems[1].Text;
				//if (e.Item.Checked)
				{
	
					lblStructure.Text = e.Item.SubItems[6].Text;
					label22.Text = "Batch " + e.Item.SubItems[1].Text;
					var myParts1 = e.Item.SubItems[9].Text.Split(';');
					foreach (var item in myParts1)
					{
						partID.Add(item.ToString());
					}
					Service.UpdatePartTree(partView.tvPartTree.Nodes, partID, true);
					partView.AfterCheck += new TreeViewEventHandler(this.partView_AfterCheck);
					//myParts = new ArrayList();
					//GetCheckedPartFromPartTree(partView.tvPartTree.Nodes, ref myParts);

					//comboBox1.FindString(textBox1.Text); 
					bulkMode = false;
					var index = cbCustomerProgram.FindStringExact(SKU);
					cbCustomerProgram.SelectedIndex = index;
					isLoaded = false;
					bulkMode = true;
					indexOld = indexNew;
				}
				//else
				//{
				//	partView.Clear();
				//	cbCustomerProgram.SelectedIndex = -1;
				//	cbCustomerProgram.Text = "Customer program lookup";
				//}
			}
			catch (Exception ex)
			{
				var a = ex.Message;
			}
		}

		//private void FindRecursive(TreeNode treeNode, string findNode, bool toCheck)
		//{
		//	foreach (TreeNode tn in treeNode.Nodes)
		//	{
		//		if (tn.Text == findNode.Trim())
		//			tn.Checked = toCheck;
		//		FindRecursive(tn, findNode.Trim(), toCheck);
		//	}
		//}

		private void RefreshListView()
		{
			try
			{
				isLoaded = true;
				DataTable table = new DataTable();
				var columns = lvBatchesToBlock.Columns.Count;
				foreach (ColumnHeader column in lvBatchesToBlock.Columns)
					table.Columns.Add(column.Text);
				foreach (ListViewItem item in lvBatchesToBlock.Items)
				{
					var cells = new object[columns];
					for (var i = 0; i < columns; i++)
					{
						if (i == 0)
						{
							if (item.Checked) cells[i] = "1";
							else cells[i] = "0";
						}
						else cells[i] = item.SubItems[i].Text;
					}
					table.Rows.Add(cells);
				}
				lvBatchesToBlock.Items.Clear();
				DataTable results = table.AsEnumerable().Distinct().CopyToDataTable();
				ListViewItem lv;
				DataRow[] dRows;
				lvBatchesToBlock.Items.Clear();            //"DocumentTypeCode = '8'"
				dRows = results.Select();
				if (dRows.Length > 0)
				{
					foreach (DataRow dRow in dRows)
					{
						lv = new ListViewItem("");
						if (dRow[0].ToString() != "0") lv.Checked = true;
						else lv.Checked = false;
						lv.SubItems.Add(dRow[1].ToString());
						lv.SubItems.Add(dRow[2].ToString());
						lv.SubItems.Add(dRow[3].ToString());
						lv.SubItems.Add(dRow[4].ToString());
						lv.SubItems.Add(dRow[5].ToString());
						lv.SubItems.Add(dRow[6].ToString());
						lv.SubItems.Add(dRow[7].ToString());
						lv.SubItems.Add(dRow[8].ToString());
						lvBatchesToBlock.Items.Add(lv);
					}
					lvBatchesToBlock.ListViewItemSorter = new ListViewItemComparer(1);
					isLoaded = false;
				}
			}
			catch (Exception ex)
			{
				var a = ex.Message;
			}
		}

		private void lvBatchesToBlock_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			try
			{
				return;
				if (isLoaded) return;
				if (!bulkMode) return;
				var BatchID = "";
				var SKU = "";
				List<string> partID = new List<string>();
				isLoaded = true;
				var itemTypeID = e.Item.SubItems[5].Text;
				//InitPartTree(itemTypeID.ToString());
				lblStructure.Text = "";
				label22.Text = "";
				BatchID = e.Item.SubItems[1].Text;
				SKU = e.Item.SubItems[4].Text;
				
				if (e.Item.Checked)
				{
					InitPartTree(itemTypeID.ToString());
					lblStructure.Text = e.Item.SubItems[6].Text;
					label22.Text = "Batch " + e.Item.SubItems[1].Text;
					//var BatchID = e.Item.SubItems[1].Text;
					//label22.Text = "Batch " + BatchID;
					//List<string> partID = new List<string>();
					//var partName = e.Item.SubItems[8].Text
					//	.Replace("White Diamond Stone Set", "WDS")
					//	.Replace("Color Diamond Stone Set", "CDS")
					//	.Replace("Color Stone Set", "CSS")
					//	.Replace("Colored diamond", "CD");
					//partID.Add(partName);
					var myParts = e.Item.SubItems[8].Text.Split(';');
					foreach (var item in myParts)
					{
						partID.Add(item.ToString());
					}
					Service.UpdatePartTree(partView.tvPartTree.Nodes, partID, e.Item.Checked);
					partView.AfterCheck += new TreeViewEventHandler(this.partView_AfterCheck);
					bulkMode = false;
					var index = cbCustomerProgram.FindStringExact(SKU);
					cbCustomerProgram.SelectedIndex = index;
					bulkMode = true;
					//e.Item.SubItems[7].Text = "";
					//e.Item.SubItems[8].Text = "";
				}
				else
				{
					partView.Clear();
					cbCustomerProgram.SelectedIndex = -1;
					cbCustomerProgram.Text = "Customer program lookup";

				}
				isLoaded = false;
			}
			catch (Exception ex)
			{
				var aa = ex.Message;
			}
			//var a = 123;
		}

		private void lvBatchesToBlock_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			//var a = 123;
		}

		private void partView_AfterCheck(object sender, TreeViewEventArgs e)
		{
			try
			{
				if (reset) return;
				if (isLoaded) return;
				var a = e.Node.Text;
				var b = e.Node.ImageKey;
				//var BatchCode = lvBatchesToBlock.SelectedItems[0].SubItems[1].Text;
				var c = ""; // = lvBatchesToBlock.SelectedItems[0].SubItems[9].Text;
				var ee = ""; // lvBatchesToBlock.SelectedItems[0].SubItems[7].Text;
				var index = lvBatchesToBlock.SelectedIndices[0];
				//var c0 = c.Split(';');
				ArrayList myParts = new ArrayList();
				ArrayList myPartsNames = new ArrayList();
				
				Service.GetCheckedPartFromPartTree(partView.tvPartTree.Nodes, ref myParts, ref myPartsNames);
				//////if (e.Node.Checked)
				//////{
				//////	foreach(var item in c0)
				//////	{
				//////		if (item.ToUpper() == a.ToUpper()) return;
				//////		c = c = c + ";" + a;
				//////		ee = ee + ";" + b;
				//////	}
				//////	//if (c.Contains(a)) return;
				//////	//c = c + ";" + a;
				//////	//lvBatchesToBlock.SelectedItems[0].SubItems[8].Text = c.Replace(";;", ";").TrimStart(';').TrimEnd(';');
				//////	ee = ee + ";" + b;
				//////	//lvBatchesToBlock.SelectedItems[0].SubItems[7].Text = ee.Replace(";;", ";").TrimStart(';').TrimEnd(';');
				//////}
				//////else
				//////{
				//////	ee = ee.Replace(b, "");
				//////	for (int i = 0; i < c0.Length; i++)
				//////	{
				//////		if (c0[i].ToUpper() == a.ToUpper())
				//////		{
				//////			c0[i] = "";
				//////		}

				//////	}
				//////	c = "";
				//////	foreach (var item in c0)
				//////	{
				//////		c = c + ";" + item;
				//////	}

				//////	//lvBatchesToBlock.SelectedItems[0].SubItems[8].Text = c.Replace(";;", ";").TrimStart(';').TrimEnd(';');
				//////	//lvBatchesToBlock.SelectedItems[0].SubItems[7].Text = ee.Replace(";;", ";").TrimStart(';').TrimEnd(';');
				//////}
			
				if (myPartsNames.Count > 0)
				{
					c = "";
					foreach (var item in myPartsNames)
					{
						c = c + "; " + item;
					}
				}
				else c = "";
				if (myParts.Count > 0)
				{
					ee = "";
					foreach (var item in myParts)
					{
						ee = ee + ";" + item;
					}

				}
				lvBatchesToBlock.SelectedItems[0].SubItems[8].Text = ""; //cc.Replace(";;", ";").TrimStart(';').TrimEnd(';');
				lvBatchesToBlock.SelectedItems[0].SubItems[7].Text = ee.Replace(";;", ";").TrimStart(';').TrimEnd(';').Trim();
				lvBatchesToBlock.SelectedItems[0].SubItems[9].Text = c.Replace(";;", ";").TrimStart(';').TrimEnd(';').Trim();
				//if (lvBatchesToBlock.SelectedItems[0].SubItems[8].Text != lvBatchesToBlock.SelectedItems[0].SubItems[10].Text)
				{
					//try
					//{
					//	htBlockedPart.Add(index, "Changed");
					//}
					//catch { }
					lvBatchesToBlock.SelectedItems[0].Checked = true;
				}
				//else lvBatchesToBlock.SelectedItems[0].Checked = false;
			}
			catch (Exception ex)
			{
				var a = ex.Message;
			}
		} //partView_AfterCheck

		private void cmd_ClearBlockPart_Click(object sender, EventArgs e)
		{
			try
			{
				lvBatchesToBlock.Items.Clear();
				partView.Clear();
				cbCustomerProgram.DataSource = null;
				cbCustomerProgram.Items.Clear();
				lblStructure.Text = "";
			}
			catch (Exception ex)
			{
				var a = ex.Message;
			}
		}

 		private void cmd_Reset_Click(object sender, EventArgs e)
		{
			resetBlockedParts();
		}

		private void resetBlockedParts()
		{
			try
			{
				reset = true;
				cbCustomerProgram.DataSource = null;
				cbCustomerProgram.Items.Clear();
				//myActiveOrder = sItemNum[0];
				lvBatchesToBlock.Items.Clear();
				partView.Clear();
				FillBlockedDataObjects(myActiveOrder, "");
				cbCustomerProgram.Text = "Customer program lookup";
				cbCustomerProgram.SelectedIndex = -1;
				bulkMode = true;
				indexOld = -1;
				this.Cursor = Cursors.Default;
				isSelectItem = false;
				htBlockedPart = null;
				reset = false;
				lvBatchesToBlock.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvBatchesToBlock_ItemSelectionChanged);
				return;
			}
			catch (Exception ex)
			{
				var a = ex.Message;
			}
		}

		private void button6_Click(object sender, EventArgs e)
		{
			SaveBlockedParts();
		}

		private void SaveBlockedParts()
		{
			DataSet dsTemp = new DataSet("Batches");
			DataTable dt = new DataTable("PartsPerBatch");
 			int[] ColumnIndex = { 2, 3, 7 };

			try
			{
				var list = lvBatchesToBlock.CheckedIndices.Cast<int>().ToList();
				if (list.Count > 0)
				{
					foreach (var i in ColumnIndex)
					{
						dt.Columns.Add("Col" + i.ToString());
					}
					foreach (var item in list)
					{
						if (lvBatchesToBlock.Items[item].SubItems[7].Text.Trim() == "")
						{
							DataRow dr = dt.NewRow();
							foreach (int i in ColumnIndex)
							{
								if (i != 7)
									dr["Col" + i.ToString()] = lvBatchesToBlock.Items[item].SubItems[i].Text;
								else dr["Col" + i.ToString()] = "";
							}
							dt.Rows.Add(dr);
						}
						else
						{
							var parts0 = lvBatchesToBlock.Items[item].SubItems[7].Text.Split(';');
							foreach (var aa in parts0)
							{
								DataRow dr = dt.NewRow();
								foreach (int i in ColumnIndex)
								{
									if (i != 7)
										dr["Col" + i.ToString()] = lvBatchesToBlock.Items[item].SubItems[i].Text;
									else dr["Col" + i.ToString()] = aa;
								}
								dt.Rows.Add(dr);
							}
						}
					}
					dsTemp.Tables.Add(dt);
#if DEBUG
					// For debugging only			
					string filename = "C:/DELL/myXmlBlockedPartsList.xml";
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
					sbStatus.Text = "Batches Updated";
					resetBlockedParts();
				}
			}
			catch(Exception ex)
			{
				var a = ex.Message;
			}

		}

		private void button5_Click(object sender, EventArgs e)
		{
			try
			{
				if (lvBatchesToBlock.Items.Count > 0)
				{
					if (lvBatchesToBlock.Items[0].Checked)
					{
						var aa = lvBatchesToBlock.Items[0].SubItems[7].Text;
						var bb = lvBatchesToBlock.Items[0].SubItems[8].Text;
						var cc = lvBatchesToBlock.Items[0].SubItems[9].Text;
						for (var item = 0; item < lvBatchesToBlock.Items.Count; item++)
						{
							lvBatchesToBlock.Items[item].SubItems[7].Text = aa;
							lvBatchesToBlock.Items[item].SubItems[8].Text = bb;
							lvBatchesToBlock.Items[item].SubItems[9].Text = cc;
							lvBatchesToBlock.Items[item].Checked = true;
						}
					}
				}
				DialogResult result = MessageBox.Show("Is it OK to save bulk?", "Bulk blocked parts", MessageBoxButtons.YesNo);
				if (result == DialogResult.Yes)
					SaveBlockedParts();
				else
				{
					//bulkMode = true;
					//cbCustomerProgram_SelectedIndexChanged(sender, System.EventArgs.Empty);
					resetBlockedParts();
				}
			}
			catch(Exception ex)
			{
				var a = ex.Message;
			}
		}

		private void cbCustomerProgram_Click(object sender, EventArgs e)
		{
			bulkMode = true;
		}
		#endregion Blocking_Parts

		class ListViewItemComparer : IComparer
		{
			private int col;
			public ListViewItemComparer()
			{
				col = 0;
			}
			public ListViewItemComparer(int column)
			{
				col = column;
			}
			public int Compare(object x, object y)
			{
				return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
			}
		}

		//private void cbCustomerProgram_Click(object sender, EventArgs e)
		//{

		//}
	}
}
