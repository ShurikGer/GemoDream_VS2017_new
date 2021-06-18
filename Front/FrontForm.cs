using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.IO;
//using frmFront;
using Cntrls;
using Spire.License;
using Spire.Xls;
//using 
//using gdrClientLibrary;
//using CMStrategy;


namespace gemoDream
{	/// <summary>
    /// Summary description for FrontForm.
    /// </summary>
    public class FrontForm : System.Windows.Forms.Form
    {

        private bool bIsVendorSelected;
        private const int CustomerIndex = 0;
        private const int VendorIndex = 1;
        private const int MessengerIndex = 1;
        private const int NumberOfItemsIndex = 2;
        private const int TotalWeightIndex = 3;
        private const int ServiceTypeIndex = 4;
        private const int MemoIndex = 5;
        private const string strVendorInit = "";
        //private Front.gemoDreamService.CGemoDreamSrv gdSrv;
        private string sVendor;
        private string sVendorShR;
        private string sVendorGO;
        private string sVendorShO;
        private int iSecurityCode;
        private CMStrategy.CMStrategy cmstrategy;
        private DataSet dsFrontGet;
        private DataSet dsManifestData;
        internal System.Windows.Forms.TabPage TabPage1;
        internal System.Windows.Forms.GroupBox GroupBox6;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.GroupBox GroupBox7;
        internal System.Windows.Forms.PictureBox PictureBox8;
        internal System.Windows.Forms.PictureBox PictureBox7;
        internal System.Windows.Forms.PictureBox PictureBox6;
        internal System.Windows.Forms.PictureBox PictureBox5;
        internal System.Windows.Forms.PictureBox PictureBox4;
        internal System.Windows.Forms.RadioButton RadioButton17;
        internal System.Windows.Forms.RadioButton RadioButton16;
        internal System.Windows.Forms.RadioButton RadioButton15;
        internal System.Windows.Forms.RadioButton RadioButton14;
        internal System.Windows.Forms.RadioButton RadioButton13;
        internal System.Windows.Forms.Label Label17;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.PictureBox PictureBox3;
        internal System.Windows.Forms.PictureBox PictureBox2;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TabPage TabPage4;
        internal System.Windows.Forms.TabPage TabPage2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        internal System.Windows.Forms.ComboBox cbCustomers;
        internal System.Windows.Forms.ComboBox cbMessenger;
        internal System.Windows.Forms.ComboBox cbCustomer;
        internal System.Windows.Forms.TabPage tpTakeIn;
        internal System.Windows.Forms.TextBox tbCustomerID;
        internal System.Windows.Forms.StatusBar StatusBar;
        internal System.Windows.Forms.Button btnNewMessenger;
        internal System.Windows.Forms.Button btnClear;
        internal System.Windows.Forms.Button btnSubmit;
        internal System.Windows.Forms.TabControl tcFront;
        internal System.Windows.Forms.Button btnClearShReceiv;
        internal System.Windows.Forms.Button btnSubmitShReceiv;
        internal System.Windows.Forms.TextBox tbCustomerIDShip;
        internal System.Windows.Forms.TextBox tbBarCode;
        internal System.Windows.Forms.Panel pCarrer;
        internal System.Windows.Forms.Button btnDepSetDhip;
        internal System.Windows.Forms.Button btnNewCustomerShip;
        internal System.Windows.Forms.Button btnDepSet;
        internal System.Windows.Forms.Button btnNewCustomer;
        private System.Windows.Forms.TextBox tbOrderSummaryShip;
        private System.Windows.Forms.TextBox tbOrderSummary;
        internal System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TreeView treeView1;
        internal System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private Cntrls.CustomerOrder gbOrder;
        private Cntrls.CustomerOrder gbOrderShip;
        internal System.Windows.Forms.TextBox tbCustomerGO;
        internal System.Windows.Forms.TextBox tbCustomerShO;
        private Cntrls.OrdersTree otShipOut;
        internal System.Windows.Forms.Button btnSubmitShO;
        internal System.Windows.Forms.Button btnClearShO;
        private Cntrls.CarrierControl ccShipOut;
        internal System.Windows.Forms.TextBox tbCarrierBarCodeShO;
        internal System.Windows.Forms.Button btnDepSetShO;
        internal System.Windows.Forms.Button btnDepSetGO;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbShipingCharch;
        internal System.Windows.Forms.Button btnNewMessengerGO;
        private Cntrls.BarCode tbBarCodeShO;
        internal System.Windows.Forms.ComboBox cmbCarrier;
        internal System.Windows.Forms.RadioButton rbIZIK;
        internal System.Windows.Forms.RadioButton rbMore;
        private System.Windows.Forms.CheckBox cbPickedByOurMessenger;
        private System.Windows.Forms.CheckBox cbTakenOutByOurMessenger;
        private System.Windows.Forms.CheckBox cbPickedByOurMessengerT;
        internal System.Windows.Forms.Label lbVendor;
        internal System.Windows.Forms.Label lbVendorGO;
        internal System.Windows.Forms.Label lbVendorShO;
        private System.Windows.Forms.Label lblOrderNumber;
        private System.Windows.Forms.Label lblLastOrder;
        private System.Windows.Forms.Button btnViewReceipt;
        private System.Windows.Forms.Button btnRepeatCustomer;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.RadioButton rbPrintLabel;
        private System.Windows.Forms.RadioButton rbSkipLabel;
        private System.Windows.Forms.Button btnRepeatCustomerShRcv;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.RadioButton rbPrintLabelShRcv;
        private System.Windows.Forms.RadioButton rbSkipLabelShRcv;
        private System.Windows.Forms.Label lblOrderNumberShRc;
        private System.Windows.Forms.Label lblLastOrderShRc;
        private System.Windows.Forms.Button btnViewReceiptShRc;
        private Cntrls.BarCode tbBarCodeGO;
        private Cntrls.OrdersTree otGiveOut;
        private System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Button btnClearGO;
        internal System.Windows.Forms.Button btnSubmitGo;
        internal System.Windows.Forms.GroupBox groupBox10;
        private Cntrls.ShippingManifest ShipManifestGO;
        private Cntrls.ShippingManifest ShipManifestShO;
        private Cntrls.MessengerControl mcGiveOut;
        private System.Windows.Forms.GroupBox gbLoadByMemoBatch;
        private System.Windows.Forms.RadioButton rbLoadByBatch;
        private System.Windows.Forms.RadioButton rbLoadByMemo;
        private CheckBox chk_AutoCheckOut;
		private Button cmd_OrderFromXLS;
		private ComboBox cmb_BulkData;
		private Label label6;
		private Timer tmr;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        public FrontForm(int iSecurityCode)
        {
            InitializeComponent();
            this.iSecurityCode = iSecurityCode;
            cmstrategy = CMStrategy.CMStrategyFactory.CreateCMStrategy(iSecurityCode);
            dsFrontGet = new System.Data.DataSet();
            Initialize();
			tmr = new Timer();
			tmr.Interval = 1000;
			tmr.Tick += new EventHandler(tmr_Tick);
			//tmr.Start();
		}

        /// <summary>
        /// Get data for TakeIn tab. Fill dsFrontGet
        /// </summary>
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrontForm));
			this.StatusBar = new System.Windows.Forms.StatusBar();
			this.tcFront = new System.Windows.Forms.TabControl();
			this.tpTakeIn = new System.Windows.Forms.TabPage();
			this.groupBox9 = new System.Windows.Forms.GroupBox();
			this.rbSkipLabel = new System.Windows.Forms.RadioButton();
			this.rbPrintLabel = new System.Windows.Forms.RadioButton();
			this.btnRepeatCustomer = new System.Windows.Forms.Button();
			this.cbPickedByOurMessengerT = new System.Windows.Forms.CheckBox();
			this.gbOrder = new Cntrls.CustomerOrder();
			this.btnClear = new System.Windows.Forms.Button();
			this.btnSubmit = new System.Windows.Forms.Button();
			this.GroupBox4 = new System.Windows.Forms.GroupBox();
			this.btnViewReceipt = new System.Windows.Forms.Button();
			this.lblLastOrder = new System.Windows.Forms.Label();
			this.lblOrderNumber = new System.Windows.Forms.Label();
			this.tbOrderSummary = new System.Windows.Forms.TextBox();
			this.GroupBox2 = new System.Windows.Forms.GroupBox();
			this.panel7 = new System.Windows.Forms.Panel();
			this.lbVendor = new System.Windows.Forms.Label();
			this.btnDepSet = new System.Windows.Forms.Button();
			this.Label5 = new System.Windows.Forms.Label();
			this.PictureBox3 = new System.Windows.Forms.PictureBox();
			this.PictureBox2 = new System.Windows.Forms.PictureBox();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.btnNewMessenger = new System.Windows.Forms.Button();
			this.cbMessenger = new System.Windows.Forms.ComboBox();
			this.btnNewCustomer = new System.Windows.Forms.Button();
			this.tbCustomerID = new System.Windows.Forms.TextBox();
			this.cbCustomer = new System.Windows.Forms.ComboBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.TabPage4 = new System.Windows.Forms.TabPage();
			this.cbTakenOutByOurMessenger = new System.Windows.Forms.CheckBox();
			this.btnClearShO = new System.Windows.Forms.Button();
			this.btnSubmitShO = new System.Windows.Forms.Button();
			this.groupBox10 = new System.Windows.Forms.GroupBox();
			this.otShipOut = new Cntrls.OrdersTree();
			this.tbBarCodeShO = new Cntrls.BarCode();
			this.label11 = new System.Windows.Forms.Label();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.tbShipingCharch = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.ccShipOut = new Cntrls.CarrierControl();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lbVendorShO = new System.Windows.Forms.Label();
			this.btnDepSetShO = new System.Windows.Forms.Button();
			this.tbCarrierBarCodeShO = new System.Windows.Forms.TextBox();
			this.tbCustomerShO = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.ShipManifestShO = new Cntrls.ShippingManifest();
			this.TabPage1 = new System.Windows.Forms.TabPage();
			this.groupBox11 = new System.Windows.Forms.GroupBox();
			this.rbSkipLabelShRcv = new System.Windows.Forms.RadioButton();
			this.rbPrintLabelShRcv = new System.Windows.Forms.RadioButton();
			this.cbPickedByOurMessenger = new System.Windows.Forms.CheckBox();
			this.gbOrderShip = new Cntrls.CustomerOrder();
			this.btnSubmitShReceiv = new System.Windows.Forms.Button();
			this.btnClearShReceiv = new System.Windows.Forms.Button();
			this.GroupBox6 = new System.Windows.Forms.GroupBox();
			this.btnViewReceiptShRc = new System.Windows.Forms.Button();
			this.lblLastOrderShRc = new System.Windows.Forms.Label();
			this.lblOrderNumberShRc = new System.Windows.Forms.Label();
			this.tbOrderSummaryShip = new System.Windows.Forms.TextBox();
			this.GroupBox1 = new System.Windows.Forms.GroupBox();
			this.panel6 = new System.Windows.Forms.Panel();
			this.btnDepSetDhip = new System.Windows.Forms.Button();
			this.btnRepeatCustomerShRcv = new System.Windows.Forms.Button();
			this.tbBarCode = new System.Windows.Forms.TextBox();
			this.GroupBox7 = new System.Windows.Forms.GroupBox();
			this.pCarrer = new System.Windows.Forms.Panel();
			this.rbMore = new System.Windows.Forms.RadioButton();
			this.cmbCarrier = new System.Windows.Forms.ComboBox();
			this.PictureBox8 = new System.Windows.Forms.PictureBox();
			this.PictureBox7 = new System.Windows.Forms.PictureBox();
			this.PictureBox6 = new System.Windows.Forms.PictureBox();
			this.PictureBox5 = new System.Windows.Forms.PictureBox();
			this.PictureBox4 = new System.Windows.Forms.PictureBox();
			this.rbIZIK = new System.Windows.Forms.RadioButton();
			this.RadioButton17 = new System.Windows.Forms.RadioButton();
			this.RadioButton16 = new System.Windows.Forms.RadioButton();
			this.RadioButton15 = new System.Windows.Forms.RadioButton();
			this.RadioButton14 = new System.Windows.Forms.RadioButton();
			this.RadioButton13 = new System.Windows.Forms.RadioButton();
			this.btnNewCustomerShip = new System.Windows.Forms.Button();
			this.tbCustomerIDShip = new System.Windows.Forms.TextBox();
			this.cbCustomers = new System.Windows.Forms.ComboBox();
			this.Label17 = new System.Windows.Forms.Label();
			this.TabPage2 = new System.Windows.Forms.TabPage();
			this.chk_AutoCheckOut = new System.Windows.Forms.CheckBox();
			this.otGiveOut = new Cntrls.OrdersTree();
			this.gbLoadByMemoBatch = new System.Windows.Forms.GroupBox();
			this.rbLoadByMemo = new System.Windows.Forms.RadioButton();
			this.rbLoadByBatch = new System.Windows.Forms.RadioButton();
			this.ShipManifestGO = new Cntrls.ShippingManifest();
			this.tbBarCodeGO = new Cntrls.BarCode();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.btnNewMessengerGO = new System.Windows.Forms.Button();
			this.mcGiveOut = new Cntrls.MessengerControl();
			this.panel1 = new System.Windows.Forms.Panel();
			this.tbCustomerGO = new System.Windows.Forms.TextBox();
			this.btnDepSetGO = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.lbVendorGO = new System.Windows.Forms.Label();
			this.btnClearGO = new System.Windows.Forms.Button();
			this.btnSubmitGo = new System.Windows.Forms.Button();
			this.label9 = new System.Windows.Forms.Label();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.cmb_BulkData = new System.Windows.Forms.ComboBox();
			this.cmd_OrderFromXLS = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.tcFront.SuspendLayout();
			this.tpTakeIn.SuspendLayout();
			this.groupBox9.SuspendLayout();
			this.GroupBox4.SuspendLayout();
			this.GroupBox2.SuspendLayout();
			this.panel7.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.TabPage4.SuspendLayout();
			this.groupBox10.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.panel2.SuspendLayout();
			this.TabPage1.SuspendLayout();
			this.groupBox11.SuspendLayout();
			this.GroupBox6.SuspendLayout();
			this.GroupBox1.SuspendLayout();
			this.panel6.SuspendLayout();
			this.GroupBox7.SuspendLayout();
			this.pCarrer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox8)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox7)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox6)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox4)).BeginInit();
			this.TabPage2.SuspendLayout();
			this.gbLoadByMemoBatch.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// StatusBar
			// 
			this.StatusBar.Font = new System.Drawing.Font("Verdana", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.StatusBar.Location = new System.Drawing.Point(0, 655);
			this.StatusBar.Name = "StatusBar";
			this.StatusBar.Size = new System.Drawing.Size(994, 20);
			this.StatusBar.TabIndex = 1;
			this.StatusBar.Text = "StatusBar";
			// 
			// tcFront
			// 
			this.tcFront.Alignment = System.Windows.Forms.TabAlignment.Left;
			this.tcFront.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tcFront.Controls.Add(this.tpTakeIn);
			this.tcFront.Controls.Add(this.TabPage4);
			this.tcFront.Controls.Add(this.TabPage1);
			this.tcFront.Controls.Add(this.TabPage2);
			this.tcFront.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.tcFront.ItemSize = new System.Drawing.Size(125, 20);
			this.tcFront.Location = new System.Drawing.Point(0, 10);
			this.tcFront.Multiline = true;
			this.tcFront.Name = "tcFront";
			this.tcFront.Padding = new System.Drawing.Point(15, 3);
			this.tcFront.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.tcFront.SelectedIndex = 0;
			this.tcFront.Size = new System.Drawing.Size(990, 645);
			this.tcFront.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			this.tcFront.TabIndex = 0;
			this.tcFront.SelectedIndexChanged += new System.EventHandler(this.tcFront_SelectedIndexChanged);
			// 
			// tpTakeIn
			// 
			this.tpTakeIn.BackColor = System.Drawing.SystemColors.Control;
			this.tpTakeIn.Controls.Add(this.label6);
			this.tpTakeIn.Controls.Add(this.cmd_OrderFromXLS);
			this.tpTakeIn.Controls.Add(this.cmb_BulkData);
			this.tpTakeIn.Controls.Add(this.groupBox9);
			this.tpTakeIn.Controls.Add(this.btnRepeatCustomer);
			this.tpTakeIn.Controls.Add(this.cbPickedByOurMessengerT);
			this.tpTakeIn.Controls.Add(this.gbOrder);
			this.tpTakeIn.Controls.Add(this.btnClear);
			this.tpTakeIn.Controls.Add(this.btnSubmit);
			this.tpTakeIn.Controls.Add(this.GroupBox4);
			this.tpTakeIn.Controls.Add(this.GroupBox2);
			this.tpTakeIn.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tpTakeIn.ForeColor = System.Drawing.SystemColors.Control;
			this.tpTakeIn.Location = new System.Drawing.Point(24, 4);
			this.tpTakeIn.Name = "tpTakeIn";
			this.tpTakeIn.Size = new System.Drawing.Size(962, 637);
			this.tpTakeIn.TabIndex = 2;
			this.tpTakeIn.Text = "TakeIn";
			this.tpTakeIn.Visible = false;
			// 
			// groupBox9
			// 
			this.groupBox9.Controls.Add(this.rbSkipLabel);
			this.groupBox9.Controls.Add(this.rbPrintLabel);
			this.groupBox9.ForeColor = System.Drawing.SystemColors.ControlText;
			this.groupBox9.Location = new System.Drawing.Point(715, 565);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new System.Drawing.Size(90, 60);
			this.groupBox9.TabIndex = 7;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "Labels";
			// 
			// rbSkipLabel
			// 
			this.rbSkipLabel.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.rbSkipLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.rbSkipLabel.Location = new System.Drawing.Point(5, 40);
			this.rbSkipLabel.Name = "rbSkipLabel";
			this.rbSkipLabel.Size = new System.Drawing.Size(80, 15);
			this.rbSkipLabel.TabIndex = 1;
			this.rbSkipLabel.Text = "Skip Label";
			// 
			// rbPrintLabel
			// 
			this.rbPrintLabel.Checked = true;
			this.rbPrintLabel.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.rbPrintLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.rbPrintLabel.Location = new System.Drawing.Point(5, 20);
			this.rbPrintLabel.Name = "rbPrintLabel";
			this.rbPrintLabel.Size = new System.Drawing.Size(80, 15);
			this.rbPrintLabel.TabIndex = 0;
			this.rbPrintLabel.TabStop = true;
			this.rbPrintLabel.Text = "Print Label";
			// 
			// btnRepeatCustomer
			// 
			this.btnRepeatCustomer.Font = new System.Drawing.Font("Verdana", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnRepeatCustomer.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnRepeatCustomer.Location = new System.Drawing.Point(15, 225);
			this.btnRepeatCustomer.Name = "btnRepeatCustomer";
			this.btnRepeatCustomer.Size = new System.Drawing.Size(520, 25);
			this.btnRepeatCustomer.TabIndex = 5;
			this.btnRepeatCustomer.Tag = "\"0_0\"";
			this.btnRepeatCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnRepeatCustomer.Click += new System.EventHandler(this.btnRepeatCustomer_Click);
			// 
			// cbPickedByOurMessengerT
			// 
			this.cbPickedByOurMessengerT.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.cbPickedByOurMessengerT.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cbPickedByOurMessengerT.Location = new System.Drawing.Point(30, 610);
			this.cbPickedByOurMessengerT.Name = "cbPickedByOurMessengerT";
			this.cbPickedByOurMessengerT.Size = new System.Drawing.Size(195, 15);
			this.cbPickedByOurMessengerT.TabIndex = 2;
			this.cbPickedByOurMessengerT.Text = "Picked Up By Our Messenger";
			this.cbPickedByOurMessengerT.CheckedChanged += new System.EventHandler(this.cbPickedByOurMessengerT_CheckedChanged);
			// 
			// gbOrder
			// 
			this.gbOrder.Location = new System.Drawing.Point(5, 250);
			this.gbOrder.Name = "gbOrder";
			this.gbOrder.Size = new System.Drawing.Size(820, 170);
			this.gbOrder.TabIndex = 0;
			this.gbOrder.Changed += new System.EventHandler(this.gbOrder_Changed);
			this.gbOrder.Load += new System.EventHandler(this.gbOrder_Load);
			// 
			// btnClear
			// 
			this.btnClear.BackColor = System.Drawing.SystemColors.Control;
			this.btnClear.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.btnClear.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnClear.Location = new System.Drawing.Point(435, 610);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(80, 20);
			this.btnClear.TabIndex = 3;
			this.btnClear.Text = "Clear";
			this.btnClear.UseVisualStyleBackColor = false;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// btnSubmit
			// 
			this.btnSubmit.BackColor = System.Drawing.SystemColors.Control;
			this.btnSubmit.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.btnSubmit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnSubmit.Location = new System.Drawing.Point(550, 610);
			this.btnSubmit.Name = "btnSubmit";
			this.btnSubmit.Size = new System.Drawing.Size(80, 20);
			this.btnSubmit.TabIndex = 4;
			this.btnSubmit.Text = "Submit";
			this.btnSubmit.UseVisualStyleBackColor = false;
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			// 
			// GroupBox4
			// 
			this.GroupBox4.Controls.Add(this.btnViewReceipt);
			this.GroupBox4.Controls.Add(this.lblLastOrder);
			this.GroupBox4.Controls.Add(this.lblOrderNumber);
			this.GroupBox4.Controls.Add(this.tbOrderSummary);
			this.GroupBox4.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.GroupBox4.ForeColor = System.Drawing.Color.Black;
			this.GroupBox4.Location = new System.Drawing.Point(5, 420);
			this.GroupBox4.Name = "GroupBox4";
			this.GroupBox4.Size = new System.Drawing.Size(590, 185);
			this.GroupBox4.TabIndex = 1;
			this.GroupBox4.TabStop = false;
			this.GroupBox4.Text = "Order Summary";
			// 
			// btnViewReceipt
			// 
			this.btnViewReceipt.ForeColor = System.Drawing.Color.Black;
			this.btnViewReceipt.Location = new System.Drawing.Point(440, 150);
			this.btnViewReceipt.Name = "btnViewReceipt";
			this.btnViewReceipt.Size = new System.Drawing.Size(135, 25);
			this.btnViewReceipt.TabIndex = 3;
			this.btnViewReceipt.Text = "View Order Receipt";
			this.btnViewReceipt.Click += new System.EventHandler(this.btnViewReceipt_Click);
			// 
			// lblLastOrder
			// 
			this.lblLastOrder.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblLastOrder.ForeColor = System.Drawing.Color.Black;
			this.lblLastOrder.Location = new System.Drawing.Point(440, 115);
			this.lblLastOrder.Name = "lblLastOrder";
			this.lblLastOrder.Size = new System.Drawing.Size(130, 25);
			this.lblLastOrder.TabIndex = 2;
			this.lblLastOrder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblOrderNumber
			// 
			this.lblOrderNumber.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblOrderNumber.ForeColor = System.Drawing.Color.Black;
			this.lblOrderNumber.Location = new System.Drawing.Point(435, 60);
			this.lblOrderNumber.Name = "lblOrderNumber";
			this.lblOrderNumber.Size = new System.Drawing.Size(140, 45);
			this.lblOrderNumber.TabIndex = 1;
			this.lblOrderNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbOrderSummary
			// 
			this.tbOrderSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.tbOrderSummary.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbOrderSummary.Location = new System.Drawing.Point(5, 20);
			this.tbOrderSummary.Multiline = true;
			this.tbOrderSummary.Name = "tbOrderSummary";
			this.tbOrderSummary.ReadOnly = true;
			this.tbOrderSummary.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbOrderSummary.Size = new System.Drawing.Size(400, 155);
			this.tbOrderSummary.TabIndex = 0;
			this.tbOrderSummary.Text = "This field contains dynamically updated order summary.";
			// 
			// GroupBox2
			// 
			this.GroupBox2.Controls.Add(this.panel7);
			this.GroupBox2.Controls.Add(this.Label5);
			this.GroupBox2.Controls.Add(this.PictureBox3);
			this.GroupBox2.Controls.Add(this.PictureBox2);
			this.GroupBox2.Controls.Add(this.Label4);
			this.GroupBox2.Controls.Add(this.Label3);
			this.GroupBox2.Controls.Add(this.PictureBox1);
			this.GroupBox2.Controls.Add(this.btnNewMessenger);
			this.GroupBox2.Controls.Add(this.cbMessenger);
			this.GroupBox2.Controls.Add(this.btnNewCustomer);
			this.GroupBox2.Controls.Add(this.tbCustomerID);
			this.GroupBox2.Controls.Add(this.cbCustomer);
			this.GroupBox2.Controls.Add(this.Label1);
			this.GroupBox2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.GroupBox2.ForeColor = System.Drawing.Color.DimGray;
			this.GroupBox2.Location = new System.Drawing.Point(5, 0);
			this.GroupBox2.Name = "GroupBox2";
			this.GroupBox2.Size = new System.Drawing.Size(675, 220);
			this.GroupBox2.TabIndex = 0;
			this.GroupBox2.TabStop = false;
			this.GroupBox2.Text = "Customer Status";
			// 
			// panel7
			// 
			this.panel7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel7.BackgroundImage")));
			this.panel7.Controls.Add(this.lbVendor);
			this.panel7.Controls.Add(this.btnDepSet);
			this.panel7.Location = new System.Drawing.Point(10, 65);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(655, 20);
			this.panel7.TabIndex = 4;
			// 
			// lbVendor
			// 
			this.lbVendor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.lbVendor.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.lbVendor.ForeColor = System.Drawing.Color.Black;
			this.lbVendor.Location = new System.Drawing.Point(0, 0);
			this.lbVendor.Name = "lbVendor";
			this.lbVendor.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lbVendor.Size = new System.Drawing.Size(456, 24);
			this.lbVendor.TabIndex = 0;
			this.lbVendor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnDepSet
			// 
			this.btnDepSet.BackColor = System.Drawing.Color.LightSteelBlue;
			this.btnDepSet.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.btnDepSet.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnDepSet.Location = new System.Drawing.Point(456, 0);
			this.btnDepSet.Name = "btnDepSet";
			this.btnDepSet.Size = new System.Drawing.Size(200, 20);
			this.btnDepSet.TabIndex = 1;
			this.btnDepSet.Text = "Departure Settings ";
			this.btnDepSet.UseVisualStyleBackColor = false;
			this.btnDepSet.Click += new System.EventHandler(this.btnDepSet_Click);
			// 
			// Label5
			// 
			this.Label5.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.Label5.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label5.Location = new System.Drawing.Point(420, 125);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(35, 15);
			this.Label5.TabIndex = 7;
			this.Label5.Text = "Photo";
			// 
			// PictureBox3
			// 
			this.PictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PictureBox3.BackgroundImage")));
			this.PictureBox3.Location = new System.Drawing.Point(125, 125);
			this.PictureBox3.Name = "PictureBox3";
			this.PictureBox3.Size = new System.Drawing.Size(275, 30);
			this.PictureBox3.TabIndex = 11;
			this.PictureBox3.TabStop = false;
			// 
			// PictureBox2
			// 
			this.PictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PictureBox2.BackgroundImage")));
			this.PictureBox2.Location = new System.Drawing.Point(125, 175);
			this.PictureBox2.Name = "PictureBox2";
			this.PictureBox2.Size = new System.Drawing.Size(275, 30);
			this.PictureBox2.TabIndex = 10;
			this.PictureBox2.TabStop = false;
			// 
			// Label4
			// 
			this.Label4.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.Label4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label4.Location = new System.Drawing.Point(10, 175);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(110, 15);
			this.Label4.TabIndex = 8;
			this.Label4.Text = "Stored Signature";
			// 
			// Label3
			// 
			this.Label3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.Label3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label3.Location = new System.Drawing.Point(10, 125);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(110, 15);
			this.Label3.TabIndex = 6;
			this.Label3.Text = "Captured Signature";
			// 
			// PictureBox1
			// 
			this.PictureBox1.BackColor = System.Drawing.SystemColors.Control;
			this.PictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PictureBox1.BackgroundImage")));
			this.PictureBox1.Location = new System.Drawing.Point(465, 125);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(200, 90);
			this.PictureBox1.TabIndex = 7;
			this.PictureBox1.TabStop = false;
			// 
			// btnNewMessenger
			// 
			this.btnNewMessenger.BackColor = System.Drawing.Color.LightSteelBlue;
			this.btnNewMessenger.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.btnNewMessenger.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnNewMessenger.Location = new System.Drawing.Point(465, 95);
			this.btnNewMessenger.Name = "btnNewMessenger";
			this.btnNewMessenger.Size = new System.Drawing.Size(200, 20);
			this.btnNewMessenger.TabIndex = 5;
			this.btnNewMessenger.Text = "New Messenger ";
			this.btnNewMessenger.UseVisualStyleBackColor = false;
			this.btnNewMessenger.Click += new System.EventHandler(this.btnNewMessenger_Click);
			// 
			// cbMessenger
			// 
			this.cbMessenger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbMessenger.Enabled = false;
			this.cbMessenger.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.cbMessenger.Location = new System.Drawing.Point(10, 95);
			this.cbMessenger.Name = "cbMessenger";
			this.cbMessenger.Size = new System.Drawing.Size(395, 20);
			this.cbMessenger.TabIndex = 4;
			this.cbMessenger.SelectedIndexChanged += new System.EventHandler(this.cbMessenger_SelectedIndexChanged);
			// 
			// btnNewCustomer
			// 
			this.btnNewCustomer.BackColor = System.Drawing.Color.LightSteelBlue;
			this.btnNewCustomer.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.btnNewCustomer.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnNewCustomer.Location = new System.Drawing.Point(465, 20);
			this.btnNewCustomer.Name = "btnNewCustomer";
			this.btnNewCustomer.Size = new System.Drawing.Size(200, 20);
			this.btnNewCustomer.TabIndex = 2;
			this.btnNewCustomer.Text = "New Customer ";
			this.btnNewCustomer.UseVisualStyleBackColor = false;
			this.btnNewCustomer.Click += new System.EventHandler(this.btnNewCustomer_Click);
			// 
			// tbCustomerID
			// 
			this.tbCustomerID.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.tbCustomerID.Location = new System.Drawing.Point(415, 20);
			this.tbCustomerID.Name = "tbCustomerID";
			this.tbCustomerID.Size = new System.Drawing.Size(40, 20);
			this.tbCustomerID.TabIndex = 0;
			this.tbCustomerID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbCustomerID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCustomerID_KeyDown);
			// 
			// cbCustomer
			// 
			this.cbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCustomer.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.cbCustomer.Location = new System.Drawing.Point(10, 20);
			this.cbCustomer.Name = "cbCustomer";
			this.cbCustomer.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cbCustomer.Size = new System.Drawing.Size(395, 20);
			this.cbCustomer.TabIndex = 1;
			this.cbCustomer.SelectedIndexChanged += new System.EventHandler(this.cbCustomer_SelectedIndexChanged);
			// 
			// Label1
			// 
			this.Label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.Label1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label1.Location = new System.Drawing.Point(10, 45);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(655, 15);
			this.Label1.TabIndex = 3;
			// 
			// TabPage4
			// 
			this.TabPage4.BackColor = System.Drawing.SystemColors.Control;
			this.TabPage4.Controls.Add(this.cbTakenOutByOurMessenger);
			this.TabPage4.Controls.Add(this.btnClearShO);
			this.TabPage4.Controls.Add(this.btnSubmitShO);
			this.TabPage4.Controls.Add(this.groupBox10);
			this.TabPage4.Controls.Add(this.groupBox8);
			this.TabPage4.Controls.Add(this.ShipManifestShO);
			this.TabPage4.Location = new System.Drawing.Point(24, 4);
			this.TabPage4.Name = "TabPage4";
			this.TabPage4.Size = new System.Drawing.Size(962, 637);
			this.TabPage4.TabIndex = 3;
			this.TabPage4.Text = "Ship Out";
			this.TabPage4.Visible = false;
			// 
			// cbTakenOutByOurMessenger
			// 
			this.cbTakenOutByOurMessenger.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
			this.cbTakenOutByOurMessenger.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.cbTakenOutByOurMessenger.Location = new System.Drawing.Point(775, 615);
			this.cbTakenOutByOurMessenger.Name = "cbTakenOutByOurMessenger";
			this.cbTakenOutByOurMessenger.Size = new System.Drawing.Size(180, 15);
			this.cbTakenOutByOurMessenger.TabIndex = 2;
			this.cbTakenOutByOurMessenger.Text = "Taken Out By Our Messenger";
			this.cbTakenOutByOurMessenger.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			// 
			// btnClearShO
			// 
			this.btnClearShO.BackColor = System.Drawing.SystemColors.Control;
			this.btnClearShO.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.btnClearShO.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnClearShO.Location = new System.Drawing.Point(585, 615);
			this.btnClearShO.Name = "btnClearShO";
			this.btnClearShO.Size = new System.Drawing.Size(80, 20);
			this.btnClearShO.TabIndex = 3;
			this.btnClearShO.Text = "Clear";
			this.btnClearShO.UseVisualStyleBackColor = false;
			this.btnClearShO.Click += new System.EventHandler(this.btnClearShO_Click);
			// 
			// btnSubmitShO
			// 
			this.btnSubmitShO.BackColor = System.Drawing.SystemColors.Control;
			this.btnSubmitShO.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.btnSubmitShO.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnSubmitShO.Location = new System.Drawing.Point(690, 615);
			this.btnSubmitShO.Name = "btnSubmitShO";
			this.btnSubmitShO.Size = new System.Drawing.Size(80, 20);
			this.btnSubmitShO.TabIndex = 4;
			this.btnSubmitShO.Text = "Submit";
			this.btnSubmitShO.UseVisualStyleBackColor = false;
			this.btnSubmitShO.Click += new System.EventHandler(this.btnSubmitShO_Click);
			// 
			// groupBox10
			// 
			this.groupBox10.Controls.Add(this.otShipOut);
			this.groupBox10.Controls.Add(this.tbBarCodeShO);
			this.groupBox10.Controls.Add(this.label11);
			this.groupBox10.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.groupBox10.ForeColor = System.Drawing.Color.DimGray;
			this.groupBox10.Location = new System.Drawing.Point(5, 225);
			this.groupBox10.Name = "groupBox10";
			this.groupBox10.Size = new System.Drawing.Size(565, 405);
			this.groupBox10.TabIndex = 1;
			this.groupBox10.TabStop = false;
			this.groupBox10.Text = "Items/Bags/Documents";
			// 
			// otShipOut
			// 
			this.otShipOut.CheckBoxes = true;
			this.otShipOut.IsDocumentGhost = true;
			this.otShipOut.IsExpand = false;
			this.otShipOut.Location = new System.Drawing.Point(10, 50);
			this.otShipOut.Name = "otShipOut";
			this.otShipOut.Selected = null;
			this.otShipOut.ShowColorAndClarity = true;
			this.otShipOut.Size = new System.Drawing.Size(540, 350);
			this.otShipOut.TabIndex = 2;
			// 
			// tbBarCodeShO
			// 
			this.tbBarCodeShO.Location = new System.Drawing.Point(10, 20);
			this.tbBarCodeShO.Name = "tbBarCodeShO";
			this.tbBarCodeShO.Size = new System.Drawing.Size(255, 20);
			this.tbBarCodeShO.TabIndex = 0;
			this.tbBarCodeShO.CodeEntered += new System.EventHandler(this.tbBarCodeShO_CodeEntered);
			// 
			// label11
			// 
			this.label11.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label11.Location = new System.Drawing.Point(280, 25);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(130, 15);
			this.label11.TabIndex = 1;
			this.label11.Text = "Full Item Name";
			// 
			// groupBox8
			// 
			this.groupBox8.BackColor = System.Drawing.SystemColors.Control;
			this.groupBox8.Controls.Add(this.tbShipingCharch);
			this.groupBox8.Controls.Add(this.label2);
			this.groupBox8.Controls.Add(this.ccShipOut);
			this.groupBox8.Controls.Add(this.panel2);
			this.groupBox8.Controls.Add(this.tbCarrierBarCodeShO);
			this.groupBox8.Controls.Add(this.tbCustomerShO);
			this.groupBox8.Controls.Add(this.label10);
			this.groupBox8.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.groupBox8.ForeColor = System.Drawing.Color.DimGray;
			this.groupBox8.Location = new System.Drawing.Point(5, 0);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(675, 220);
			this.groupBox8.TabIndex = 0;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Identification";
			// 
			// tbShipingCharch
			// 
			this.tbShipingCharch.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.tbShipingCharch.Location = new System.Drawing.Point(445, 190);
			this.tbShipingCharch.Name = "tbShipingCharch";
			this.tbShipingCharch.Size = new System.Drawing.Size(220, 20);
			this.tbShipingCharch.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label2.Location = new System.Drawing.Point(340, 195);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 15);
			this.label2.TabIndex = 3;
			this.label2.Text = "Shipping Charge:";
			// 
			// ccShipOut
			// 
			this.ccShipOut.Location = new System.Drawing.Point(10, 85);
			this.ccShipOut.Name = "ccShipOut";
			this.ccShipOut.Size = new System.Drawing.Size(655, 95);
			this.ccShipOut.TabIndex = 1;
			// 
			// panel2
			// 
			this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
			this.panel2.Controls.Add(this.lbVendorShO);
			this.panel2.Controls.Add(this.btnDepSetShO);
			this.panel2.Location = new System.Drawing.Point(10, 65);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(655, 20);
			this.panel2.TabIndex = 9;
			// 
			// lbVendorShO
			// 
			this.lbVendorShO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.lbVendorShO.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.lbVendorShO.ForeColor = System.Drawing.Color.Black;
			this.lbVendorShO.Location = new System.Drawing.Point(0, 0);
			this.lbVendorShO.Name = "lbVendorShO";
			this.lbVendorShO.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lbVendorShO.Size = new System.Drawing.Size(455, 24);
			this.lbVendorShO.TabIndex = 0;
			this.lbVendorShO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnDepSetShO
			// 
			this.btnDepSetShO.BackColor = System.Drawing.Color.LightSteelBlue;
			this.btnDepSetShO.Enabled = false;
			this.btnDepSetShO.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.btnDepSetShO.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnDepSetShO.Location = new System.Drawing.Point(455, 0);
			this.btnDepSetShO.Name = "btnDepSetShO";
			this.btnDepSetShO.Size = new System.Drawing.Size(200, 20);
			this.btnDepSetShO.TabIndex = 1;
			this.btnDepSetShO.Text = "Departure Settings ";
			this.btnDepSetShO.UseVisualStyleBackColor = false;
			this.btnDepSetShO.Click += new System.EventHandler(this.btnDepSetShO_Click);
			// 
			// tbCarrierBarCodeShO
			// 
			this.tbCarrierBarCodeShO.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.tbCarrierBarCodeShO.ForeColor = System.Drawing.SystemColors.WindowText;
			this.tbCarrierBarCodeShO.Location = new System.Drawing.Point(10, 190);
			this.tbCarrierBarCodeShO.Name = "tbCarrierBarCodeShO";
			this.tbCarrierBarCodeShO.Size = new System.Drawing.Size(320, 20);
			this.tbCarrierBarCodeShO.TabIndex = 2;
			this.tbCarrierBarCodeShO.Tag = "tbCarrierBarCodeShO";
			this.tbCarrierBarCodeShO.Text = "Scan Package Bar-Code Here";
			this.tbCarrierBarCodeShO.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbBarCode_MouseUp);
			this.tbCarrierBarCodeShO.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tbBarCode_MouseUp);
			// 
			// tbCustomerShO
			// 
			this.tbCustomerShO.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.tbCustomerShO.Location = new System.Drawing.Point(10, 20);
			this.tbCustomerShO.Name = "tbCustomerShO";
			this.tbCustomerShO.ReadOnly = true;
			this.tbCustomerShO.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.tbCustomerShO.Size = new System.Drawing.Size(655, 20);
			this.tbCustomerShO.TabIndex = 0;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.label10.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label10.Location = new System.Drawing.Point(10, 45);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(0, 12);
			this.label10.TabIndex = 5;
			// 
			// ShipManifestShO
			// 
			this.ShipManifestShO.Location = new System.Drawing.Point(455, 230);
			this.ShipManifestShO.Name = "ShipManifestShO";
			this.ShipManifestShO.Size = new System.Drawing.Size(505, 360);
			this.ShipManifestShO.TabIndex = 5;
			this.ShipManifestShO.Visible = false;
			// 
			// TabPage1
			// 
			this.TabPage1.BackColor = System.Drawing.SystemColors.Control;
			this.TabPage1.Controls.Add(this.groupBox11);
			this.TabPage1.Controls.Add(this.cbPickedByOurMessenger);
			this.TabPage1.Controls.Add(this.gbOrderShip);
			this.TabPage1.Controls.Add(this.btnSubmitShReceiv);
			this.TabPage1.Controls.Add(this.btnClearShReceiv);
			this.TabPage1.Controls.Add(this.GroupBox6);
			this.TabPage1.Controls.Add(this.GroupBox1);
			this.TabPage1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.TabPage1.Location = new System.Drawing.Point(24, 4);
			this.TabPage1.Name = "TabPage1";
			this.TabPage1.Size = new System.Drawing.Size(962, 637);
			this.TabPage1.TabIndex = 0;
			this.TabPage1.Text = "Ship Receiving";
			// 
			// groupBox11
			// 
			this.groupBox11.Controls.Add(this.rbSkipLabelShRcv);
			this.groupBox11.Controls.Add(this.rbPrintLabelShRcv);
			this.groupBox11.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Underline);
			this.groupBox11.Location = new System.Drawing.Point(695, 530);
			this.groupBox11.Name = "groupBox11";
			this.groupBox11.Size = new System.Drawing.Size(90, 60);
			this.groupBox11.TabIndex = 6;
			this.groupBox11.TabStop = false;
			this.groupBox11.Text = "Labels";
			// 
			// rbSkipLabelShRcv
			// 
			this.rbSkipLabelShRcv.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.rbSkipLabelShRcv.Location = new System.Drawing.Point(5, 40);
			this.rbSkipLabelShRcv.Name = "rbSkipLabelShRcv";
			this.rbSkipLabelShRcv.Size = new System.Drawing.Size(80, 15);
			this.rbSkipLabelShRcv.TabIndex = 1;
			this.rbSkipLabelShRcv.Text = "Skip Label";
			// 
			// rbPrintLabelShRcv
			// 
			this.rbPrintLabelShRcv.Checked = true;
			this.rbPrintLabelShRcv.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.rbPrintLabelShRcv.Location = new System.Drawing.Point(5, 20);
			this.rbPrintLabelShRcv.Name = "rbPrintLabelShRcv";
			this.rbPrintLabelShRcv.Size = new System.Drawing.Size(80, 15);
			this.rbPrintLabelShRcv.TabIndex = 0;
			this.rbPrintLabelShRcv.TabStop = true;
			this.rbPrintLabelShRcv.Text = "Print Label";
			// 
			// cbPickedByOurMessenger
			// 
			this.cbPickedByOurMessenger.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.cbPickedByOurMessenger.Location = new System.Drawing.Point(25, 570);
			this.cbPickedByOurMessenger.Name = "cbPickedByOurMessenger";
			this.cbPickedByOurMessenger.Size = new System.Drawing.Size(210, 15);
			this.cbPickedByOurMessenger.TabIndex = 3;
			this.cbPickedByOurMessenger.Text = "Picked Up By Our Messenger";
			// 
			// gbOrderShip
			// 
			this.gbOrderShip.Location = new System.Drawing.Point(5, 225);
			this.gbOrderShip.Name = "gbOrderShip";
			this.gbOrderShip.Size = new System.Drawing.Size(810, 168);
			this.gbOrderShip.TabIndex = 1;
			this.gbOrderShip.Changed += new System.EventHandler(this.gbOrderShip_Changed);
			// 
			// btnSubmitShReceiv
			// 
			this.btnSubmitShReceiv.BackColor = System.Drawing.SystemColors.Control;
			this.btnSubmitShReceiv.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.btnSubmitShReceiv.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnSubmitShReceiv.Location = new System.Drawing.Point(600, 570);
			this.btnSubmitShReceiv.Name = "btnSubmitShReceiv";
			this.btnSubmitShReceiv.Size = new System.Drawing.Size(80, 20);
			this.btnSubmitShReceiv.TabIndex = 5;
			this.btnSubmitShReceiv.Text = "Submit";
			this.btnSubmitShReceiv.UseVisualStyleBackColor = false;
			this.btnSubmitShReceiv.Click += new System.EventHandler(this.btnSubmitShReceiv_Click);
			// 
			// btnClearShReceiv
			// 
			this.btnClearShReceiv.BackColor = System.Drawing.SystemColors.Control;
			this.btnClearShReceiv.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.btnClearShReceiv.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnClearShReceiv.Location = new System.Drawing.Point(510, 570);
			this.btnClearShReceiv.Name = "btnClearShReceiv";
			this.btnClearShReceiv.Size = new System.Drawing.Size(80, 20);
			this.btnClearShReceiv.TabIndex = 4;
			this.btnClearShReceiv.Text = "Clear";
			this.btnClearShReceiv.UseVisualStyleBackColor = false;
			this.btnClearShReceiv.Click += new System.EventHandler(this.btnClearShReceiv_Click);
			// 
			// GroupBox6
			// 
			this.GroupBox6.Controls.Add(this.btnViewReceiptShRc);
			this.GroupBox6.Controls.Add(this.lblLastOrderShRc);
			this.GroupBox6.Controls.Add(this.lblOrderNumberShRc);
			this.GroupBox6.Controls.Add(this.tbOrderSummaryShip);
			this.GroupBox6.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.GroupBox6.ForeColor = System.Drawing.Color.DimGray;
			this.GroupBox6.Location = new System.Drawing.Point(5, 390);
			this.GroupBox6.Name = "GroupBox6";
			this.GroupBox6.Size = new System.Drawing.Size(675, 170);
			this.GroupBox6.TabIndex = 2;
			this.GroupBox6.TabStop = false;
			this.GroupBox6.Text = "Order Summary";
			// 
			// btnViewReceiptShRc
			// 
			this.btnViewReceiptShRc.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnViewReceiptShRc.Location = new System.Drawing.Point(424, 136);
			this.btnViewReceiptShRc.Name = "btnViewReceiptShRc";
			this.btnViewReceiptShRc.Size = new System.Drawing.Size(152, 24);
			this.btnViewReceiptShRc.TabIndex = 3;
			this.btnViewReceiptShRc.Text = "View Order Receipt";
			this.btnViewReceiptShRc.Click += new System.EventHandler(this.btnViewReceiptShRc_Click);
			// 
			// lblLastOrderShRc
			// 
			this.lblLastOrderShRc.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
			this.lblLastOrderShRc.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblLastOrderShRc.Location = new System.Drawing.Point(432, 88);
			this.lblLastOrderShRc.Name = "lblLastOrderShRc";
			this.lblLastOrderShRc.Size = new System.Drawing.Size(144, 32);
			this.lblLastOrderShRc.TabIndex = 2;
			this.lblLastOrderShRc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblOrderNumberShRc
			// 
			this.lblOrderNumberShRc.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
			this.lblOrderNumberShRc.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblOrderNumberShRc.Location = new System.Drawing.Point(432, 32);
			this.lblOrderNumberShRc.Name = "lblOrderNumberShRc";
			this.lblOrderNumberShRc.Size = new System.Drawing.Size(140, 45);
			this.lblOrderNumberShRc.TabIndex = 1;
			this.lblOrderNumberShRc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbOrderSummaryShip
			// 
			this.tbOrderSummaryShip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.tbOrderSummaryShip.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbOrderSummaryShip.Location = new System.Drawing.Point(8, 16);
			this.tbOrderSummaryShip.Multiline = true;
			this.tbOrderSummaryShip.Name = "tbOrderSummaryShip";
			this.tbOrderSummaryShip.ReadOnly = true;
			this.tbOrderSummaryShip.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbOrderSummaryShip.Size = new System.Drawing.Size(328, 144);
			this.tbOrderSummaryShip.TabIndex = 0;
			this.tbOrderSummaryShip.Text = "This filed contains dynamically updated order summary.";
			// 
			// GroupBox1
			// 
			this.GroupBox1.BackColor = System.Drawing.SystemColors.Control;
			this.GroupBox1.Controls.Add(this.panel6);
			this.GroupBox1.Controls.Add(this.tbBarCode);
			this.GroupBox1.Controls.Add(this.GroupBox7);
			this.GroupBox1.Controls.Add(this.btnNewCustomerShip);
			this.GroupBox1.Controls.Add(this.tbCustomerIDShip);
			this.GroupBox1.Controls.Add(this.cbCustomers);
			this.GroupBox1.Controls.Add(this.Label17);
			this.GroupBox1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.GroupBox1.ForeColor = System.Drawing.Color.DimGray;
			this.GroupBox1.Location = new System.Drawing.Point(5, 0);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new System.Drawing.Size(735, 220);
			this.GroupBox1.TabIndex = 0;
			this.GroupBox1.TabStop = false;
			this.GroupBox1.Text = "Identification";
			// 
			// panel6
			// 
			this.panel6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel6.BackgroundImage")));
			this.panel6.Controls.Add(this.btnDepSetDhip);
			this.panel6.Controls.Add(this.btnRepeatCustomerShRcv);
			this.panel6.Location = new System.Drawing.Point(10, 65);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(700, 20);
			this.panel6.TabIndex = 9;
			// 
			// btnDepSetDhip
			// 
			this.btnDepSetDhip.BackColor = System.Drawing.Color.LightSteelBlue;
			this.btnDepSetDhip.Enabled = false;
			this.btnDepSetDhip.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.btnDepSetDhip.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnDepSetDhip.Location = new System.Drawing.Point(500, 0);
			this.btnDepSetDhip.Name = "btnDepSetDhip";
			this.btnDepSetDhip.Size = new System.Drawing.Size(200, 20);
			this.btnDepSetDhip.TabIndex = 0;
			this.btnDepSetDhip.Text = "Departure Settings ";
			this.btnDepSetDhip.UseVisualStyleBackColor = false;
			this.btnDepSetDhip.Click += new System.EventHandler(this.btnDepSetDhip_Click);
			// 
			// btnRepeatCustomerShRcv
			// 
			this.btnRepeatCustomerShRcv.Font = new System.Drawing.Font("Verdana", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnRepeatCustomerShRcv.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnRepeatCustomerShRcv.Location = new System.Drawing.Point(0, 0);
			this.btnRepeatCustomerShRcv.Name = "btnRepeatCustomerShRcv";
			this.btnRepeatCustomerShRcv.Size = new System.Drawing.Size(495, 20);
			this.btnRepeatCustomerShRcv.TabIndex = 1;
			this.btnRepeatCustomerShRcv.Tag = "\"0_0\"";
			this.btnRepeatCustomerShRcv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnRepeatCustomerShRcv.Click += new System.EventHandler(this.btnRepeatCustomerShRcv_Click);
			// 
			// tbBarCode
			// 
			this.tbBarCode.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.tbBarCode.ForeColor = System.Drawing.SystemColors.WindowText;
			this.tbBarCode.Location = new System.Drawing.Point(10, 190);
			this.tbBarCode.Name = "tbBarCode";
			this.tbBarCode.Size = new System.Drawing.Size(655, 20);
			this.tbBarCode.TabIndex = 11;
			this.tbBarCode.Tag = "Scan Package Bar-Code Here";
			this.tbBarCode.Text = "Scan Package Bar-Code Here";
			this.tbBarCode.TextChanged += new System.EventHandler(this.tbBarCode_TextChanged);
			this.tbBarCode.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbBarCode_MouseUp);
			this.tbBarCode.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tbBarCode_MouseUp);
			// 
			// GroupBox7
			// 
			this.GroupBox7.Controls.Add(this.pCarrer);
			this.GroupBox7.Location = new System.Drawing.Point(10, 85);
			this.GroupBox7.Name = "GroupBox7";
			this.GroupBox7.Size = new System.Drawing.Size(655, 95);
			this.GroupBox7.TabIndex = 3;
			this.GroupBox7.TabStop = false;
			this.GroupBox7.Text = "Carrier";
			// 
			// pCarrer
			// 
			this.pCarrer.AutoScroll = true;
			this.pCarrer.Controls.Add(this.rbMore);
			this.pCarrer.Controls.Add(this.cmbCarrier);
			this.pCarrer.Controls.Add(this.PictureBox8);
			this.pCarrer.Controls.Add(this.PictureBox7);
			this.pCarrer.Controls.Add(this.PictureBox6);
			this.pCarrer.Controls.Add(this.PictureBox5);
			this.pCarrer.Controls.Add(this.PictureBox4);
			this.pCarrer.Controls.Add(this.rbIZIK);
			this.pCarrer.Controls.Add(this.RadioButton17);
			this.pCarrer.Controls.Add(this.RadioButton16);
			this.pCarrer.Controls.Add(this.RadioButton15);
			this.pCarrer.Controls.Add(this.RadioButton14);
			this.pCarrer.Controls.Add(this.RadioButton13);
			this.pCarrer.Location = new System.Drawing.Point(5, 20);
			this.pCarrer.Name = "pCarrer";
			this.pCarrer.Size = new System.Drawing.Size(645, 70);
			this.pCarrer.TabIndex = 0;
			// 
			// rbMore
			// 
			this.rbMore.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.rbMore.ForeColor = System.Drawing.SystemColors.ControlText;
			this.rbMore.Location = new System.Drawing.Point(575, 5);
			this.rbMore.Name = "rbMore";
			this.rbMore.Size = new System.Drawing.Size(65, 15);
			this.rbMore.TabIndex = 5;
			this.rbMore.TabStop = true;
			this.rbMore.Tag = "7";
			this.rbMore.Text = "More...";
			this.rbMore.CheckedChanged += new System.EventHandler(this.CarrierRadioButton_CheckedChanged);
			// 
			// cmbCarrier
			// 
			this.cmbCarrier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCarrier.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.cmbCarrier.Location = new System.Drawing.Point(505, 30);
			this.cmbCarrier.Name = "cmbCarrier";
			this.cmbCarrier.Size = new System.Drawing.Size(121, 20);
			this.cmbCarrier.TabIndex = 6;
			this.cmbCarrier.SelectedIndexChanged += new System.EventHandler(this.cmbCarrier_SelectedIndexChanged);
			// 
			// PictureBox8
			// 
			this.PictureBox8.BackColor = System.Drawing.SystemColors.Control;
			this.PictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox8.Image")));
			this.PictureBox8.Location = new System.Drawing.Point(410, 25);
			this.PictureBox8.Name = "PictureBox8";
			this.PictureBox8.Size = new System.Drawing.Size(80, 40);
			this.PictureBox8.TabIndex = 12;
			this.PictureBox8.TabStop = false;
			// 
			// PictureBox7
			// 
			this.PictureBox7.BackColor = System.Drawing.SystemColors.Control;
			this.PictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox7.Image")));
			this.PictureBox7.Location = new System.Drawing.Point(310, 25);
			this.PictureBox7.Name = "PictureBox7";
			this.PictureBox7.Size = new System.Drawing.Size(80, 40);
			this.PictureBox7.TabIndex = 11;
			this.PictureBox7.TabStop = false;
			// 
			// PictureBox6
			// 
			this.PictureBox6.BackColor = System.Drawing.SystemColors.Control;
			this.PictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox6.Image")));
			this.PictureBox6.Location = new System.Drawing.Point(210, 25);
			this.PictureBox6.Name = "PictureBox6";
			this.PictureBox6.Size = new System.Drawing.Size(80, 40);
			this.PictureBox6.TabIndex = 10;
			this.PictureBox6.TabStop = false;
			// 
			// PictureBox5
			// 
			this.PictureBox5.BackColor = System.Drawing.SystemColors.Control;
			this.PictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox5.Image")));
			this.PictureBox5.Location = new System.Drawing.Point(110, 25);
			this.PictureBox5.Name = "PictureBox5";
			this.PictureBox5.Size = new System.Drawing.Size(80, 40);
			this.PictureBox5.TabIndex = 9;
			this.PictureBox5.TabStop = false;
			// 
			// PictureBox4
			// 
			this.PictureBox4.BackColor = System.Drawing.SystemColors.Control;
			this.PictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox4.Image")));
			this.PictureBox4.Location = new System.Drawing.Point(10, 25);
			this.PictureBox4.Name = "PictureBox4";
			this.PictureBox4.Size = new System.Drawing.Size(80, 40);
			this.PictureBox4.TabIndex = 8;
			this.PictureBox4.TabStop = false;
			// 
			// rbIZIK
			// 
			this.rbIZIK.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.rbIZIK.ForeColor = System.Drawing.SystemColors.ControlText;
			this.rbIZIK.Location = new System.Drawing.Point(510, 5);
			this.rbIZIK.Name = "rbIZIK";
			this.rbIZIK.Size = new System.Drawing.Size(60, 15);
			this.rbIZIK.TabIndex = 4;
			this.rbIZIK.Tag = "6";
			this.rbIZIK.Text = "IZIK";
			this.rbIZIK.CheckedChanged += new System.EventHandler(this.CarrierRadioButton_CheckedChanged);
			// 
			// RadioButton17
			// 
			this.RadioButton17.Checked = true;
			this.RadioButton17.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.RadioButton17.ForeColor = System.Drawing.SystemColors.ControlText;
			this.RadioButton17.Location = new System.Drawing.Point(410, 5);
			this.RadioButton17.Name = "RadioButton17";
			this.RadioButton17.Size = new System.Drawing.Size(83, 15);
			this.RadioButton17.TabIndex = 3;
			this.RadioButton17.TabStop = true;
			this.RadioButton17.Tag = "5";
			this.RadioButton17.Text = "MalcaAmit";
			this.RadioButton17.CheckedChanged += new System.EventHandler(this.CarrierRadioButton_CheckedChanged);
			// 
			// RadioButton16
			// 
			this.RadioButton16.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.RadioButton16.ForeColor = System.Drawing.SystemColors.ControlText;
			this.RadioButton16.Location = new System.Drawing.Point(310, 5);
			this.RadioButton16.Name = "RadioButton16";
			this.RadioButton16.Size = new System.Drawing.Size(60, 15);
			this.RadioButton16.TabIndex = 2;
			this.RadioButton16.Tag = "4";
			this.RadioButton16.Text = "Brinks";
			this.RadioButton16.CheckedChanged += new System.EventHandler(this.CarrierRadioButton_CheckedChanged);
			// 
			// RadioButton15
			// 
			this.RadioButton15.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.RadioButton15.ForeColor = System.Drawing.SystemColors.ControlText;
			this.RadioButton15.Location = new System.Drawing.Point(210, 5);
			this.RadioButton15.Name = "RadioButton15";
			this.RadioButton15.Size = new System.Drawing.Size(60, 15);
			this.RadioButton15.TabIndex = 1;
			this.RadioButton15.Tag = "3";
			this.RadioButton15.Text = "USPS";
			this.RadioButton15.CheckedChanged += new System.EventHandler(this.CarrierRadioButton_CheckedChanged);
			// 
			// RadioButton14
			// 
			this.RadioButton14.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.RadioButton14.ForeColor = System.Drawing.SystemColors.ControlText;
			this.RadioButton14.Location = new System.Drawing.Point(110, 5);
			this.RadioButton14.Name = "RadioButton14";
			this.RadioButton14.Size = new System.Drawing.Size(60, 15);
			this.RadioButton14.TabIndex = 0;
			this.RadioButton14.Tag = "2";
			this.RadioButton14.Text = "UPS";
			this.RadioButton14.CheckedChanged += new System.EventHandler(this.CarrierRadioButton_CheckedChanged);
			// 
			// RadioButton13
			// 
			this.RadioButton13.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.RadioButton13.ForeColor = System.Drawing.SystemColors.ControlText;
			this.RadioButton13.Location = new System.Drawing.Point(10, 5);
			this.RadioButton13.Name = "RadioButton13";
			this.RadioButton13.Size = new System.Drawing.Size(60, 15);
			this.RadioButton13.TabIndex = 0;
			this.RadioButton13.Tag = "1";
			this.RadioButton13.Text = "FedEx";
			this.RadioButton13.CheckedChanged += new System.EventHandler(this.CarrierRadioButton_CheckedChanged);
			// 
			// btnNewCustomerShip
			// 
			this.btnNewCustomerShip.BackColor = System.Drawing.Color.LightSteelBlue;
			this.btnNewCustomerShip.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.btnNewCustomerShip.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnNewCustomerShip.Location = new System.Drawing.Point(510, 20);
			this.btnNewCustomerShip.Name = "btnNewCustomerShip";
			this.btnNewCustomerShip.Size = new System.Drawing.Size(200, 20);
			this.btnNewCustomerShip.TabIndex = 2;
			this.btnNewCustomerShip.Text = "New Customer ";
			this.btnNewCustomerShip.UseVisualStyleBackColor = false;
			this.btnNewCustomerShip.Click += new System.EventHandler(this.btnNewCustomerShip_Click);
			// 
			// tbCustomerIDShip
			// 
			this.tbCustomerIDShip.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.tbCustomerIDShip.Location = new System.Drawing.Point(415, 20);
			this.tbCustomerIDShip.Name = "tbCustomerIDShip";
			this.tbCustomerIDShip.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.tbCustomerIDShip.Size = new System.Drawing.Size(40, 20);
			this.tbCustomerIDShip.TabIndex = 0;
			this.tbCustomerIDShip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbCustomerIDShip.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCustomerIDShip_KeyDown);
			// 
			// cbCustomers
			// 
			this.cbCustomers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCustomers.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.cbCustomers.Location = new System.Drawing.Point(10, 20);
			this.cbCustomers.Name = "cbCustomers";
			this.cbCustomers.Size = new System.Drawing.Size(395, 20);
			this.cbCustomers.TabIndex = 1;
			this.cbCustomers.SelectedIndexChanged += new System.EventHandler(this.cbCustomers_SelectedIndexChanged);
			// 
			// Label17
			// 
			this.Label17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.Label17.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.Label17.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label17.Location = new System.Drawing.Point(10, 45);
			this.Label17.Name = "Label17";
			this.Label17.Size = new System.Drawing.Size(655, 15);
			this.Label17.TabIndex = 5;
			// 
			// TabPage2
			// 
			this.TabPage2.BackColor = System.Drawing.SystemColors.Control;
			this.TabPage2.Controls.Add(this.chk_AutoCheckOut);
			this.TabPage2.Controls.Add(this.otGiveOut);
			this.TabPage2.Controls.Add(this.gbLoadByMemoBatch);
			this.TabPage2.Controls.Add(this.ShipManifestGO);
			this.TabPage2.Controls.Add(this.tbBarCodeGO);
			this.TabPage2.Controls.Add(this.groupBox3);
			this.TabPage2.Controls.Add(this.btnClearGO);
			this.TabPage2.Controls.Add(this.btnSubmitGo);
			this.TabPage2.Controls.Add(this.label9);
			this.TabPage2.Location = new System.Drawing.Point(24, 4);
			this.TabPage2.Name = "TabPage2";
			this.TabPage2.Size = new System.Drawing.Size(962, 637);
			this.TabPage2.TabIndex = 1;
			this.TabPage2.Text = "GiveOut";
			this.TabPage2.Visible = false;
			// 
			// chk_AutoCheckOut
			// 
			this.chk_AutoCheckOut.AutoSize = true;
			this.chk_AutoCheckOut.Location = new System.Drawing.Point(448, 207);
			this.chk_AutoCheckOut.Name = "chk_AutoCheckOut";
			this.chk_AutoCheckOut.Size = new System.Drawing.Size(124, 17);
			this.chk_AutoCheckOut.TabIndex = 7;
			this.chk_AutoCheckOut.Text = "Auto Check out";
			this.chk_AutoCheckOut.UseVisualStyleBackColor = true;
			// 
			// otGiveOut
			// 
			this.otGiveOut.CheckBoxes = true;
			this.otGiveOut.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.otGiveOut.ForeColor = System.Drawing.Color.DimGray;
			this.otGiveOut.IsDocumentGhost = true;
			this.otGiveOut.IsExpand = false;
			this.otGiveOut.Location = new System.Drawing.Point(10, 240);
			this.otGiveOut.Name = "otGiveOut";
			this.otGiveOut.Selected = null;
			this.otGiveOut.ShowColorAndClarity = true;
			this.otGiveOut.Size = new System.Drawing.Size(570, 390);
			this.otGiveOut.TabIndex = 2;
			// 
			// gbLoadByMemoBatch
			// 
			this.gbLoadByMemoBatch.Controls.Add(this.rbLoadByMemo);
			this.gbLoadByMemoBatch.Controls.Add(this.rbLoadByBatch);
			this.gbLoadByMemoBatch.Location = new System.Drawing.Point(530, 590);
			this.gbLoadByMemoBatch.Name = "gbLoadByMemoBatch";
			this.gbLoadByMemoBatch.Size = new System.Drawing.Size(130, 40);
			this.gbLoadByMemoBatch.TabIndex = 6;
			this.gbLoadByMemoBatch.TabStop = false;
			this.gbLoadByMemoBatch.Text = "Load By";
			this.gbLoadByMemoBatch.Visible = false;
			// 
			// rbLoadByMemo
			// 
			this.rbLoadByMemo.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.rbLoadByMemo.Location = new System.Drawing.Point(70, 20);
			this.rbLoadByMemo.Name = "rbLoadByMemo";
			this.rbLoadByMemo.Size = new System.Drawing.Size(55, 15);
			this.rbLoadByMemo.TabIndex = 1;
			this.rbLoadByMemo.Text = "Memo";
			this.rbLoadByMemo.CheckedChanged += new System.EventHandler(this.rbLoadByMemo_CheckedChanged);
			// 
			// rbLoadByBatch
			// 
			this.rbLoadByBatch.Checked = true;
			this.rbLoadByBatch.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.rbLoadByBatch.Location = new System.Drawing.Point(5, 20);
			this.rbLoadByBatch.Name = "rbLoadByBatch";
			this.rbLoadByBatch.Size = new System.Drawing.Size(55, 15);
			this.rbLoadByBatch.TabIndex = 0;
			this.rbLoadByBatch.TabStop = true;
			this.rbLoadByBatch.Text = "Batch";
			this.rbLoadByBatch.CheckedChanged += new System.EventHandler(this.rbLoadByBatch_CheckedChanged);
			// 
			// ShipManifestGO
			// 
			this.ShipManifestGO.Location = new System.Drawing.Point(520, 240);
			this.ShipManifestGO.Name = "ShipManifestGO";
			this.ShipManifestGO.Size = new System.Drawing.Size(435, 350);
			this.ShipManifestGO.TabIndex = 4;
			this.ShipManifestGO.Visible = false;
			// 
			// tbBarCodeGO
			// 
			this.tbBarCodeGO.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.tbBarCodeGO.ForeColor = System.Drawing.Color.DimGray;
			this.tbBarCodeGO.Location = new System.Drawing.Point(10, 210);
			this.tbBarCodeGO.Name = "tbBarCodeGO";
			this.tbBarCodeGO.Size = new System.Drawing.Size(255, 20);
			this.tbBarCodeGO.TabIndex = 0;
			this.tbBarCodeGO.CodeEntered += new System.EventHandler(this.tbBarCodeGO_CodeEntered);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.btnNewMessengerGO);
			this.groupBox3.Controls.Add(this.mcGiveOut);
			this.groupBox3.Controls.Add(this.panel1);
			this.groupBox3.Controls.Add(this.tbCustomerGO);
			this.groupBox3.Controls.Add(this.btnDepSetGO);
			this.groupBox3.Controls.Add(this.label8);
			this.groupBox3.Controls.Add(this.lbVendorGO);
			this.groupBox3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.groupBox3.ForeColor = System.Drawing.Color.DimGray;
			this.groupBox3.Location = new System.Drawing.Point(5, 0);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(495, 200);
			this.groupBox3.TabIndex = 0;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Identification";
			this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
			// 
			// btnNewMessengerGO
			// 
			this.btnNewMessengerGO.BackColor = System.Drawing.Color.LightSteelBlue;
			this.btnNewMessengerGO.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.btnNewMessengerGO.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnNewMessengerGO.Location = new System.Drawing.Point(350, 80);
			this.btnNewMessengerGO.Name = "btnNewMessengerGO";
			this.btnNewMessengerGO.Size = new System.Drawing.Size(120, 20);
			this.btnNewMessengerGO.TabIndex = 2;
			this.btnNewMessengerGO.Text = "New Messenger ";
			this.btnNewMessengerGO.UseVisualStyleBackColor = false;
			this.btnNewMessengerGO.Click += new System.EventHandler(this.btnNewMessengerGO_Click);
			// 
			// mcGiveOut
			// 
			this.mcGiveOut.Enabled = false;
			this.mcGiveOut.Filter = "";
			this.mcGiveOut.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.mcGiveOut.ForeColor = System.Drawing.Color.DimGray;
			this.mcGiveOut.Location = new System.Drawing.Point(10, 95);
			this.mcGiveOut.Name = "mcGiveOut";
			this.mcGiveOut.Size = new System.Drawing.Size(480, 95);
			this.mcGiveOut.TabIndex = 1;
			// 
			// panel1
			// 
			this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
			this.panel1.Location = new System.Drawing.Point(10, 50);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(330, 20);
			this.panel1.TabIndex = 4;
			this.panel1.Visible = false;
			// 
			// tbCustomerGO
			// 
			this.tbCustomerGO.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.tbCustomerGO.Location = new System.Drawing.Point(10, 20);
			this.tbCustomerGO.Name = "tbCustomerGO";
			this.tbCustomerGO.ReadOnly = true;
			this.tbCustomerGO.Size = new System.Drawing.Size(470, 20);
			this.tbCustomerGO.TabIndex = 0;
			// 
			// btnDepSetGO
			// 
			this.btnDepSetGO.BackColor = System.Drawing.Color.LightSteelBlue;
			this.btnDepSetGO.Enabled = false;
			this.btnDepSetGO.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.btnDepSetGO.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnDepSetGO.Location = new System.Drawing.Point(350, 50);
			this.btnDepSetGO.Name = "btnDepSetGO";
			this.btnDepSetGO.Size = new System.Drawing.Size(120, 20);
			this.btnDepSetGO.TabIndex = 1;
			this.btnDepSetGO.Text = "Departure Settings ";
			this.btnDepSetGO.UseVisualStyleBackColor = false;
			this.btnDepSetGO.Click += new System.EventHandler(this.btnDepSetGO_Click);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.label8.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label8.Location = new System.Drawing.Point(10, 45);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(0, 12);
			this.label8.TabIndex = 0;
			// 
			// lbVendorGO
			// 
			this.lbVendorGO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.lbVendorGO.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.lbVendorGO.ForeColor = System.Drawing.Color.Black;
			this.lbVendorGO.Location = new System.Drawing.Point(30, 80);
			this.lbVendorGO.Name = "lbVendorGO";
			this.lbVendorGO.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lbVendorGO.Size = new System.Drawing.Size(310, 24);
			this.lbVendorGO.TabIndex = 0;
			this.lbVendorGO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnClearGO
			// 
			this.btnClearGO.BackColor = System.Drawing.SystemColors.Control;
			this.btnClearGO.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.btnClearGO.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnClearGO.Location = new System.Drawing.Point(780, 610);
			this.btnClearGO.Name = "btnClearGO";
			this.btnClearGO.Size = new System.Drawing.Size(80, 20);
			this.btnClearGO.TabIndex = 2;
			this.btnClearGO.Text = "Clear Order";
			this.btnClearGO.UseVisualStyleBackColor = false;
			this.btnClearGO.Click += new System.EventHandler(this.btnClearGO_Click);
			// 
			// btnSubmitGo
			// 
			this.btnSubmitGo.BackColor = System.Drawing.SystemColors.Control;
			this.btnSubmitGo.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.btnSubmitGo.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnSubmitGo.Location = new System.Drawing.Point(870, 610);
			this.btnSubmitGo.Name = "btnSubmitGo";
			this.btnSubmitGo.Size = new System.Drawing.Size(80, 20);
			this.btnSubmitGo.TabIndex = 3;
			this.btnSubmitGo.Text = "Submit ";
			this.btnSubmitGo.UseVisualStyleBackColor = false;
			this.btnSubmitGo.Click += new System.EventHandler(this.btnSubmitGo_Click);
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label9.Location = new System.Drawing.Point(280, 210);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(270, 15);
			this.label9.TabIndex = 1;
			this.label9.Text = "Full Item Name";
			// 
			// treeView1
			// 
			this.treeView1.LineColor = System.Drawing.Color.Empty;
			this.treeView1.Location = new System.Drawing.Point(0, 0);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(121, 97);
			this.treeView1.TabIndex = 0;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(0, 0);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(100, 20);
			this.textBox2.TabIndex = 0;
			// 
			// cmb_BulkData
			// 
			this.cmb_BulkData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb_BulkData.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmb_BulkData.FormattingEnabled = true;
			this.cmb_BulkData.Location = new System.Drawing.Point(715, 33);
			this.cmb_BulkData.Name = "cmb_BulkData";
			this.cmb_BulkData.Size = new System.Drawing.Size(237, 21);
			this.cmb_BulkData.TabIndex = 8;
			// 
			// cmd_OrderFromXLS
			// 
			this.cmd_OrderFromXLS.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.cmd_OrderFromXLS.ForeColor = System.Drawing.Color.Black;
			this.cmd_OrderFromXLS.Location = new System.Drawing.Point(771, 220);
			this.cmd_OrderFromXLS.Name = "cmd_OrderFromXLS";
			this.cmd_OrderFromXLS.Size = new System.Drawing.Size(143, 25);
			this.cmd_OrderFromXLS.TabIndex = 9;
			this.cmd_OrderFromXLS.Text = "Make New Order";
			this.cmd_OrderFromXLS.UseVisualStyleBackColor = true;
			this.cmd_OrderFromXLS.Visible = false;
			this.cmd_OrderFromXLS.Click += new System.EventHandler(this.cmd_OrderFromXLS_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.ForeColor = System.Drawing.Color.Black;
			this.label6.Location = new System.Drawing.Point(712, 10);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(144, 13);
			this.label6.TabIndex = 10;
			this.label6.Text = "XLS files for new orders";
			// 
			// FrontForm
			// 
			this.ClientSize = new System.Drawing.Size(994, 675);
			this.Controls.Add(this.tcFront);
			this.Controls.Add(this.StatusBar);
			this.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.HelpButton = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "FrontForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Front";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.FrontForm_Closing);
			this.tcFront.ResumeLayout(false);
			this.tpTakeIn.ResumeLayout(false);
			this.tpTakeIn.PerformLayout();
			this.groupBox9.ResumeLayout(false);
			this.GroupBox4.ResumeLayout(false);
			this.GroupBox4.PerformLayout();
			this.GroupBox2.ResumeLayout(false);
			this.GroupBox2.PerformLayout();
			this.panel7.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.PictureBox3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.TabPage4.ResumeLayout(false);
			this.groupBox10.ResumeLayout(false);
			this.groupBox8.ResumeLayout(false);
			this.groupBox8.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.TabPage1.ResumeLayout(false);
			this.groupBox11.ResumeLayout(false);
			this.GroupBox6.ResumeLayout(false);
			this.GroupBox6.PerformLayout();
			this.GroupBox1.ResumeLayout(false);
			this.GroupBox1.PerformLayout();
			this.panel6.ResumeLayout(false);
			this.GroupBox7.ResumeLayout(false);
			this.pCarrer.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.PictureBox8)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox7)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox6)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox4)).EndInit();
			this.TabPage2.ResumeLayout(false);
			this.TabPage2.PerformLayout();
			this.gbLoadByMemoBatch.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new FrontForm(3));
        }

		private void tmr_Tick(object sender, EventArgs e)
		{
			tmr.Stop();
			try
			{
				string sXLSFilePath = Client.GetOfficeDirPath("repDir") + @"RubyFront\";
				DirectoryInfo di = new DirectoryInfo(sXLSFilePath);
				FileInfo[] fi = di.GetFiles("*");
				if (fi.Length > 0)
				{
					cmb_BulkData.Enabled = true;
					foreach (var fitemp in fi)
					{
						if (fitemp.Name.ToLower().Contains(".xls"))
							cmb_BulkData.Items.Add(fitemp.Name);
					}
					cmb_BulkData.Visible = true;
					cmd_OrderFromXLS.Enabled = true;
					cmd_OrderFromXLS.Visible = true;
				}
				else
				{
					label6.Text = "";
					cmb_BulkData.Items.Clear();
					cmb_BulkData.SelectedIndex = -1;
					cmb_BulkData.Visible = false;
					cmb_BulkData.Enabled = false;
					cmd_OrderFromXLS.Visible = false;

					tmr.Start();
				}
				if (cmb_BulkData.Items.Count > 0)
				{
					cmb_BulkData.Visible = true;
					cmb_BulkData.SelectedIndex = 0;
					cmb_BulkData.Enabled = true;
					label6.Text = "Bulk Data Files List";
				}
			}
			catch { }
		}

		private void Initialize()
        {

            this.Text = Service.sProgramTitle + this.Text;
            StatusBar.Text = "Loading...";

            pCarrer.Enabled = false;
            cbCustomers.Enabled = false;
            gbOrderShip.Enabled = false;
            btnClearShReceiv.Enabled = false;
            btnSubmitShReceiv.Enabled = false;
            tbBarCode.Enabled = false;
            //Client.KillOpenExcel();
            bIsVendorSelected = false;
            Client.ViewReport = false;
            lblOrderNumber.ResetText();
            lblLastOrder.ResetText();
            lblOrderNumberShRc.ResetText();
            lblLastOrderShRc.ResetText();
            btnViewReceipt.Enabled = false;
            btnViewReceiptShRc.Enabled = false;
            rbPrintLabel.Checked = true;
            rbPrintLabelShRcv.Checked = true;
            rbLoadByBatch.Checked = true;
            Service.IsMemo = false;

			label6.Text = "";
			cmb_BulkData.Items.Clear();
			cmb_BulkData.SelectedIndex = -1;
			cmb_BulkData.Visible = false;
			cmb_BulkData.Enabled = false;
			cmd_OrderFromXLS.Visible = false;

			//tbOrderMemo.Clear();			
			try
            {
                dsFrontGet = Service.GetTakeIn();//Procedures: spGetMessengers,spGetCarriers, spGetCustomers, spGetMeasureUnits, spGetServiceTypes

                PrepareDSGet();

                InitializeTakeIn();
                InitializeShipReceiving();

                StatusBar.Text = "StatusBar";
            }
            catch (Exception exc)
            {
                StatusBar.Text = exc.Message;
            }
        }


        private void GetTakeInData()
        {
            //dsFrontGet.Clear();
            if (dsFrontGet != null)
            {
                dsFrontGet.Dispose();
                dsFrontGet = null;
            }
            dsFrontGet = new DataSet();
            DataTable tmpCustomer = dsFrontGet.Tables.Add("tblCustomer");
            DataColumn dcCustomerID = tmpCustomer.Columns.Add("CustomerID");
            dcCustomerID.DataType = System.Type.GetType("System.Int32");
            tmpCustomer.Columns.Add("CustomerName");
            tmpCustomer.Columns.Add("CustomerCode");

            for (int i = 0; i < 10; i++)
            {
                DataRow myRow = tmpCustomer.NewRow();
                myRow["CustomerID"] = i;
                myRow["CustomerCode"] = i + 5000;
                myRow["CustomerName"] = "Customer " + i.ToString();
                tmpCustomer.Rows.Add(myRow);
            }

            DataColumn[] keys = new DataColumn[1];
            keys[0] = dsFrontGet.Tables["tblCustomer"].Columns["CustomerCode"];
            dsFrontGet.Tables["tblCustomer"].PrimaryKey = keys;

            tmpCustomer = dsFrontGet.Tables.Add("tblMessenger");
            dcCustomerID = tmpCustomer.Columns.Add("MessengerID");
            dcCustomerID.DataType = System.Type.GetType("System.Int32");
            tmpCustomer.Columns.Add("MessengerName");
            tmpCustomer.Columns.Add("CustomerID");
            for (int i = 0; i < 10; i++)
            {
                DataRow myRow = tmpCustomer.NewRow();
                myRow["MessengerID"] = i;
                myRow["CustomerID"] = i;
                myRow["MessengerName"] = "Messenger " + i.ToString();
                tmpCustomer.Rows.Add(myRow);
            }

            // Get the DataColumn objects from two DataTable objects in a DataSet.
            DataColumn parentCol;
            DataColumn childCol;
            // Code to get the DataSet not shown here.
            parentCol = dsFrontGet.Tables["tblCustomer"].Columns["CustomerID"];
            childCol = dsFrontGet.Tables["tblMessenger"].Columns["MessengerID"];
            // Create DataRelation.
            DataRelation relCustOrder;
            relCustOrder = new DataRelation("CustomerMessenger", parentCol, childCol);
            // Add the relation to the DataSet.
            dsFrontGet.Relations.Add(relCustOrder);

            DataTable tmpMeasureUnit = dsFrontGet.Tables.Add("tblMeasureUnit");
            DataColumn dcMeasureUnitID = tmpMeasureUnit.Columns.Add("MeasureUnitID");
            dcMeasureUnitID.DataType = System.Type.GetType("System.Int32");
            tmpMeasureUnit.Columns.Add("MeasureUnitName");
            tmpMeasureUnit.Columns.Add("MeasureUnitCode");

            DataRow myRow1 = tmpMeasureUnit.NewRow();
            myRow1["MeasureUnitID"] = 0;
            myRow1["MeasureUnitName"] = "g";
            myRow1["MeasureUnitCode"] = "1";
            tmpMeasureUnit.Rows.Add(myRow1);
            myRow1.AcceptChanges();

            DataRow myRow2 = tmpMeasureUnit.NewRow();
            myRow2["MeasureUnitID"] = 1;
            myRow2["MeasureUnitName"] = "ct.";
            myRow2["MeasureUnitCode"] = "2";
            tmpMeasureUnit.Rows.Add(myRow2);
            myRow2.AcceptChanges();

            DataTable tmpServiceType = dsFrontGet.Tables.Add("tblServiceType");
            DataColumn dcServiceTypeID = tmpServiceType.Columns.Add("ServiceTypeID");
            dcServiceTypeID.DataType = System.Type.GetType("System.Int32");
            tmpServiceType.Columns.Add("ServiceTypeName");

            DataRow myRow4 = tmpServiceType.NewRow();
            myRow4["ServiceTypeID"] = 0;
            myRow4["ServiceTypeName"] = "24 hours";
            tmpServiceType.Rows.Add(myRow4);
            myRow4.AcceptChanges();

            DataRow myRow3 = tmpServiceType.NewRow();
            myRow3["ServiceTypeID"] = 1;
            myRow3["ServiceTypeName"] = "48 hours";
            tmpServiceType.Rows.Add(myRow3);
            myRow3.AcceptChanges();

            DataRow myRow5 = tmpServiceType.NewRow();
            myRow5["ServiceTypeID"] = 1;
            myRow5["ServiceTypeName"] = "5 days";
            tmpServiceType.Rows.Add(myRow5);
            myRow5.AcceptChanges();

            myRow5 = tmpServiceType.NewRow();
            myRow5["ServiceTypeID"] = 1;
            myRow5["ServiceTypeName"] = "7 days";
            tmpServiceType.Rows.Add(myRow5);
            myRow5.AcceptChanges();

            myRow5 = tmpServiceType.NewRow();
            myRow5["ServiceTypeID"] = 1;
            myRow5["ServiceTypeName"] = "10 days";
            tmpServiceType.Rows.Add(myRow5);
            myRow5.AcceptChanges();

            // FORM SET ^)
            DataTable dtEntryBatch = dsFrontGet.Tables.Add("tblEntryBatch");
            dtEntryBatch.Columns.Add("CustomerID");
            dtEntryBatch.Columns.Add("MessengerID");
            dtEntryBatch.Columns.Add("IsIQInspected");
            dtEntryBatch.Columns.Add("TotalWeight");
            dtEntryBatch.Columns.Add("IsTWInspected");
            dtEntryBatch.Columns.Add("MeasureUnitID");
            dtEntryBatch.Columns.Add("ServiceTypeID");
            dtEntryBatch.Columns.Add("Memo");
            dtEntryBatch.Columns.Add("IsMemo");
            dtEntryBatch.Columns.Add("SpecialInstruction");
            dtEntryBatch.Columns.Add("CarrierTrackingNumber");
            dtEntryBatch.Columns.Add("OrderCode");
            dtEntryBatch.Columns.Add("CarrierID");
            dtEntryBatch.Columns.Add("ItemsQuantity");

        }


        private void PrepareDSGet()
        {

            dsFrontGet.Tables["tblMeasureUnit"].DefaultView.Sort = "MeasureUnitCode Asc";
            DataRow drCustomerLookup = dsFrontGet.Tables["tblCustomer"].NewRow();
            drCustomerLookup["CustomerName"] = "Customer Lookup";
            drCustomerLookup["CustomerID"] = "0";
            drCustomerLookup["CustomerCode"] = "0000";
            dsFrontGet.Tables["tblCustomer"].Rows.InsertAt(drCustomerLookup, 0);

            DataRow drMessengerLookup = dsFrontGet.Tables["tblMessenger"].NewRow();
            drMessengerLookup["MessengerName"] = "Messenger Lookup";
            drMessengerLookup["MessengerID"] = "0";
            drMessengerLookup["CustomerID"] = "0";
            dsFrontGet.Tables["tblMessenger"].Rows.InsertAt(drMessengerLookup, 0);
        }


        private void InitializeShipReceiving()
        {
            gbOrderShip.InitializeOrder(dsFrontGet);

            dsFrontGet.Tables["tblMeasureUnit"].DefaultView.Sort = "MeasureUnitCode Asc";
            gbOrderShip.InitializeOrder(dsFrontGet);

            DataView dvCustomers = new DataView(dsFrontGet.Tables["tblCustomer"]);
            //dvCustomers.Sort = "CustomerID ASC";

            cbCustomers.BeginUpdate();
            cbCustomers.DataSource = dvCustomers;
            cbCustomers.DisplayMember = "CustomerName";
            cbCustomers.ValueMember = "CustomerID";
            cbCustomers.EndUpdate();

            ClearShReceiv();
            cbCustomers.Enabled = true;

            DataSet dsIn = new DataSet();
            dsIn.Tables.Add("Carriers");
            DataSet dsCarriers = Service.ProxyGenericGet(dsIn);

            DataRow[] rCarriers = dsCarriers.Tables[0].Select("CarrierCode>6");

            DataTable dtMoreCarriers = new DataTable("MoreCarriers");
            dtMoreCarriers.Columns.Add("CarrierName", System.Type.GetType("System.String"));
            dtMoreCarriers.Columns.Add("CarrierCode", System.Type.GetType("System.String"));
            for (int i = 0; i < rCarriers.Length; i++)
            {
                DataRow rNew = dtMoreCarriers.NewRow();
                rNew["CarrierName"] = rCarriers[i]["CarrierName"].ToString();
                rNew["CarrierCode"] = rCarriers[i]["CarrierCode"].ToString();
                dtMoreCarriers.Rows.Add(rNew);
            }

            cmbCarrier.DataSource = dtMoreCarriers;
            cmbCarrier.DisplayMember = "CarrierName";
            cmbCarrier.ValueMember = "CarrierCode";

            cmbCarrier.Enabled = false;
            btnRepeatCustomerShRcv.Tag = "\"0\"";

        }
        private void InitializeTakeIn()
        {
            try
            {
                gbOrder.InitializeOrder(dsFrontGet);

                DataView dvMessengers = new DataView(dsFrontGet.Tables["tblMessenger"]);
                //dvMessengers.Sort = "MessengerID ASC";

                cbMessenger.BeginUpdate();
                cbMessenger.DataSource = dvMessengers;
                cbMessenger.DisplayMember = "MessengerName";
                cbMessenger.ValueMember = "MessengerID";
                cbMessenger.EndUpdate();


                DataView dvCustomers = new DataView(dsFrontGet.Tables["tblCustomer"]);
                //dvCustomers.Sort = "CustomerID ASC";

                cbCustomer.BeginUpdate();
                cbCustomer.DataSource = dvCustomers;
                cbCustomer.DisplayMember = "CustomerName";
                cbCustomer.ValueMember = "CustomerID";
                cbCustomer.EndUpdate();
                btnRepeatCustomer.Tag = "\"0\"";

                ClearTakeIn();
                cbCustomer.Enabled = true;
                bIsVendorSelected = false;
                //RemoveRoomForVendor();
                //InsertRowToOrderSummary(this.tbOrderSummary, VendorIndex, "Vendor: Vendor Lookup");
                StatusBar.Text = "StatusBar";
            }
            catch (Exception exc)
            {
                StatusBar.Text = exc.Message;
            }
        }


        private void tbCustomerID_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                cbCustomer.SelectedIndex = 0;
                DataRowView drvCurrentCustomer = (DataRowView)cbCustomer.SelectedItem;
                tbCustomerID.Text = drvCurrentCustomer["CustomerCode"].ToString();
            }
            if (e.KeyCode == Keys.Enter)
            {
                bool IsExist = false;
                try
                {
                    DataView dvCustomers = (DataView)cbCustomer.DataSource;
                    foreach (DataRowView drvCustomerIterator in dvCustomers)
                    {
                        if (drvCustomerIterator["CustomerCode"].ToString() == tbCustomerID.Text.ToString())
                        {
                            cbCustomer.SelectedItem = drvCustomerIterator;
                            IsExist = true;
                            break;
                        }
                    }
                    if (!IsExist)
                    {
                        tbCustomerID.SelectAll();
                        StatusBar.Text = "Customer with code " + tbCustomerID.Text.Trim() + " not exists";
                    }

                }
                catch { }
                finally { }
            }
        }

        private void cbCustomer_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                cbPickedByOurMessengerT.Checked = false;
                DataRowView drvCurrentCustomer = (DataRowView)cbCustomer.SelectedItem;
                tbCustomerID.Text = drvCurrentCustomer["CustomerCode"].ToString();
                StatusBar.Text = drvCurrentCustomer["CustomerName"].ToString();
                InsertRowToOrderSummary(tbOrderSummary, CustomerIndex, "\tCustomer: " + drvCurrentCustomer["CustomerName"].ToString());
                string CustomerID = drvCurrentCustomer["CustomerID"].ToString();
                if (CustomerID == "0")
                {
                    gbOrder.Enabled = false;
                    cbMessenger.Enabled = false;
                    btnNewMessenger.Enabled = false;
                    btnSubmit.Enabled = false;
                    btnClear.Enabled = true;
                    btnDepSet.Enabled = false;
                    //					if(btnRepeatCustomer.Tag.ToString() != "0")
                    //					{
                    //						btnRepeatCustomer.Enabled = true;
                    //					}
                    //					else
                    //						btnRepeatCustomer.Enabled = false;
                }
                else
                {
                    lblOrderNumber.ResetText();
                    lblLastOrder.ResetText();
                    btnViewReceipt.Enabled = false;
                    gbOrder.Enabled = true;
                    cbMessenger.Enabled = true;
                    btnNewMessenger.Enabled = true;
                    btnSubmit.Enabled = true;
                    btnClear.Enabled = true;
                    btnDepSet.Enabled = true;
                    string sCustomerOfficeId = CustomerID.Split('_')[0];
                    Service.SetDepartmentOfficeId(sCustomerOfficeId);
                    btnRepeatCustomer.Text = "";
                    btnRepeatCustomer.Tag = "0_0";
                    //					btnRepeatCustomer.Tag =  cbCustomer.SelectedIndex.ToString() + (cbPickedByOurMessengerT.Checked ? "_1" : "_0");
                    //					btnRepeatCustomer.Text = "Customer: " + drvCurrentCustomer["CustomerName"].ToString();
                }

                DataView dvCurrentMessengers = (DataView)cbMessenger.DataSource;
                dvCurrentMessengers.RowFilter = "CustomerID = '" + CustomerID + "' or CustomerID = '0'";

                string sText = "Messenger: " + ((DataRowView)cbMessenger.SelectedItem)["MessengerName"].ToString();

                int iMessengerIndex = MessengerIndex;
                if (bIsVendorSelected)
                    iMessengerIndex++;
                InsertRowToOrderSummary(tbOrderSummary, iMessengerIndex, sText);
            }
            finally { }
        }


        private void btnClear_Click(object sender, System.EventArgs e)
        {
            ClearTakeIn();
        }
        private void ClearTakeIn()
        {
            sVendor = "";
            lbVendor.Text = strVendorInit;

            if (bIsVendorSelected)
                RemoveRoomForVendor();
            bIsVendorSelected = false;
            //			InsertRowToOrderSummary(tbOrderSummary, VendorIndex, "Vendor: Vendor Lookup");
            cbCustomer.SelectedIndex = 0;
            cbMessenger.SelectedIndex = 0;
            gbOrder.ClearOrder();
            lblOrderNumber.Text = "";
            lblLastOrder.Text = "";
            btnRepeatCustomer.Tag = "0_0";
            btnRepeatCustomer.Text = "";
            //btnRepeatCustomer.Enabled = false;
            rbPrintLabel.Checked = true;
            //tbOrderMemo.Clear();
        }


        private void btnClearShReceiv_Click(object sender, System.EventArgs e)
        {
            ClearShReceiv();
        }
        private void ClearShReceiv()
        {
            cbCustomers.SelectedIndex = 0;
            tbBarCode.Text = "";
            tbBarCode.Text = tbBarCode.Tag.ToString();
            sVendorShR = "";
            rbIZIK.Checked = true;
            gbOrderShip.ClearOrder();
            lblOrderNumberShRc.Text = "";
            lblLastOrderShRc.Text = "";
            btnRepeatCustomerShRcv.Tag = "0_0";
            btnRepeatCustomerShRcv.Text = "";
            rbPrintLabelShRcv.Checked = true;
        }

        private void btnSubmitShReceiv_Click(object sender, System.EventArgs e)
        {
            string sOrderID = "";
            string sOrderCode = "";
            string sSelectedIndex = cbCustomers.SelectedIndex.ToString() + (cbPickedByOurMessenger.Checked ? "_GSI" : "_0");
            string sTitle = cbCustomers.Text;

            this.Cursor = Cursors.WaitCursor;
            StatusBar.Text = "Submitting changes. Please, wait";

            if (MessageBox.Show("Are you sure you want to save?", "", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                this.Cursor = Cursors.Default;
                StatusBar.Text = "Operation canceled";
                return;
            }
            //			else
            //			{
            //				btnRepeatCustomerShRcv.Tag = sSelectedIndex;
            //				btnRepeatCustomerShRcv.Text = "Customer: " + sTitle;
            //			}

            try
            {
                DataSet dsUpdate = new DataSet();
                dsUpdate.Tables.Add(dsFrontGet.Tables["tblEntryBatch"].Clone());
                DataRow drBatch = dsUpdate.Tables["tblEntryBatch"].NewRow();

                gbOrderShip.GetBatch(drBatch);
                drBatch["CustomerID"] = cbCustomers.SelectedValue;

                if (tbBarCode.Text != tbBarCode.Tag.ToString())
                {
                    drBatch["CarrierTrackingNumber"] = tbBarCode.Text;
                }


                foreach (Control rbCarrier in pCarrer.Controls)
                {
                    if ("System.Windows.Forms.RadioButton" == rbCarrier.GetType().ToString())
                    {
                        RadioButton rb = (RadioButton)rbCarrier;
                        if (rb.Checked)
                        {
                            if (rb.Name == "rbMore")
                            {
                                DataSet dsIn = new DataSet();
                                dsIn.Tables.Add("Carriers");
                                DataSet dsCarriers = Service.ProxyGenericGet(dsIn);

                                DataRow[] rCarriers = dsCarriers.Tables[0].Select("CarrierCode=" + cmbCarrier.SelectedValue);
                                drBatch["CarrierID"] = rCarriers[0]["CarrierID"].ToString();
                                break;
                            }
                            DataRow[] drArray = dsFrontGet.Tables["Carriers"].Select("CarrierCode = " + rb.Tag.ToString());
                            drBatch["CarrierID"] = drArray[0]["CarrierID"];
                            break;
                        }
                    }
                }

                btnRepeatCustomerShRcv.Tag = sSelectedIndex;
                btnRepeatCustomerShRcv.Text = "Customer: " + sTitle;

                if (sVendorShR != "") drBatch["VendorOfficeID_VendorID"] = sVendorShR;

                dsUpdate.Tables["tblEntryBatch"].Rows.Add(drBatch);

                DataSet dsID = Service.InsertTakeIn(dsUpdate);
                sOrderID = dsID.Tables[0].Rows[0][0].ToString();

                SaveMemoNumberShReceiv(sOrderID);

                DataSet dsPickedUp = new DataSet();
                dsPickedUp.Tables.Add("PickedUpByOurMessenger");
                dsPickedUp.Tables[0].Columns.Add("PickedUpByOurMessenger", System.Type.GetType("System.String"));
                dsPickedUp.Tables[0].Columns.Add("GroupID", System.Type.GetType("System.String"));


                dsPickedUp.Tables[0].Rows.Add(dsPickedUp.Tables[0].NewRow());
                if (cbPickedByOurMessenger.Checked)
                    dsPickedUp.Tables[0].Rows[0]["PickedUpByOurMessenger"] = 1;
                else
                    dsPickedUp.Tables[0].Rows[0]["PickedUpByOurMessenger"] = 0;

                dsPickedUp.Tables[0].Rows[0]["GroupID"] = sOrderID.Split(new char[] { '_' })[1].ToString();

                Service.ProxyGenericSet(dsPickedUp, "set");

                try
                {
                    if (Service.iInvoiceDebugLevel >= 1)
                    {
                        int iViewAccessCode = 1; // ViewAccess = "Front Desc"
                        int iGroupOfficeId = Convert.ToInt32(sOrderID.Split(new char[] { '_' })[0]);
                        int iGroupId = Convert.ToInt32(sOrderID.Split(new char[] { '_' })[1]);
                        Service.DBAddGroupInvoice(iViewAccessCode, iGroupOfficeId, iGroupId);
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Warning: Can't add invoice for Front:\r\n" + exc.Message);
                }

                //string sOrderCode = Service.GetOrderCodeByOrderID(sOrderID);
                sOrderCode = sOrderID.Split(new char[] { '_' })[2];
                //tbOrderSummary.Text += "\r\nThe data was successfully added";
                StatusBar.Text = "Data was successfully added. Created Order Code: " + sOrderCode;
                sOrderID = sOrderID.Split(new char[] { '_' })[0] + "_" + sOrderID.Split(new char[] { '_' })[1];

                lblOrderNumberShRc.Text = "Last Order # ";
                lblLastOrderShRc.Text = sOrderCode;

                btnViewReceiptShRc.Enabled = true;
                sOrderID = sOrderID.Split(new char[] { '_' })[0] + "_" + sOrderID.Split(new char[] { '_' })[1];

                try
                {
                    //Print Report
                    for (; ; )
                    {
                        bool bPickedUpByOurMessenger = this.cbPickedByOurMessenger.Checked;
                        Print2(sOrderID, bPickedUpByOurMessenger);

                        if (MessageBox.Show("Would you like to print again?",
                            "Printing completed", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
                            continue;
                        else
                            break;
                    }
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Printing Error: " + exp.Message);
                }
                ClearShReceiv();
            }
            catch (Exception exp)
            {
                this.StatusBar.Text = exp.Message;
            }
            btnRepeatCustomerShRcv.Tag = sSelectedIndex;
            btnRepeatCustomerShRcv.Text = "Customer: " + sTitle;
            btnRepeatCustomerShRcv.Enabled = true;
            lblOrderNumberShRc.Text = "Last Order # ";
            lblLastOrderShRc.Text = sOrderCode;
            this.Cursor = Cursors.Default;
            StatusBar.Text = "Ready";
        }

        private void Print2(string sOrderID, bool bPickedUpByOurMessenger)
        {	//Service.GetCRTemplatePath()
            string sCRTemplatePath = Client.GetOfficeDirPath("repDir");
            string sReportKind = Service.GetReportKind();
            CrystalReport.CrystalReport crReport;// = new CrystalReport.CrystalReport(sCRTemplatePath);
            if (rbPrintLabelShRcv.Checked)
            {
                if (sReportKind == "crystal")
                {
                    crReport = new CrystalReport.CrystalReport(sCRTemplatePath);
                    crReport.Front_TakeIn_Label(sOrderID);
                    crReport.Print();
                }
                else
                {
                    crReport = new CrystalReport.CrystalReport(sCRTemplatePath, true);
                    try
                    {
                        crReport.Excel_Front_TakeIn_Label(sOrderID);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, ex.Message, "Print error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (crReport != null)
                        crReport.CloseExcel();
                    crReport = null;
                    /*GC.Collect();
                    GC.WaitForPendingFinalizers(); 
                    GC.Collect();*/
                }
            }
            //if(MessageBox.Show("Would You like to print external receipt?","External Receipt",MessageBoxButtons.YesNo,MessageBoxIcon.Question)
            //	== DialogResult.Yes)
            ExternalReceiptForm f = new ExternalReceiptForm();
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                ExternalReceiptForm.Result r = f.MyResult;
                if (r == ExternalReceiptForm.Result.ONE)
                {
                    if (sReportKind == "crystal")
                    {
                        crReport = new CrystalReport.CrystalReport(sCRTemplatePath);
                    }
                    else
                    {
                        crReport = new CrystalReport.CrystalReport(sCRTemplatePath, true);
                    }
                    CrystalReport.TakeInType type;
                    if (bPickedUpByOurMessenger)
                        type = CrystalReport.TakeInType.ShipReceivingPickedUpByOurMessenger;
                    else
                        type = CrystalReport.TakeInType.ShipReceiving;
                    if (sReportKind == "crystal")
                    {
                        crReport.Front_TakeIn(sOrderID, type);
                        crReport.Print();
                    }
                    else
                    {
                        try
                        {
                            string sReceiptStyle = Client.GetOfficeDirPath("ReceiptStyle");
                            if (sReceiptStyle.Trim().ToUpper() == "XLS")    crReport.Excel_Front_TakeIn(sOrderID, type, 1);
                            if (sReceiptStyle.Trim().ToUpper() == "PDF")    crReport.PDF_Front_TakeIn(sOrderID, type, 1);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(this, ex.Message, "Print error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        if (crReport != null)
                            crReport.CloseExcel();
                        crReport = null;
                        /*GC.Collect();
                        GC.WaitForPendingFinalizers(); 
                        GC.Collect();*/
                    }

                }
                else if (r == ExternalReceiptForm.Result.TWO)
                {
                    if (sReportKind == "crystal")
                    {
                        crReport = new CrystalReport.CrystalReport(sCRTemplatePath);
                    }
                    else
                    {
                        crReport = new CrystalReport.CrystalReport(sCRTemplatePath, true);
                    }

                    CrystalReport.TakeInType type;
                    if (bPickedUpByOurMessenger)
                        type = CrystalReport.TakeInType.ShipReceivingPickedUpByOurMessenger;
                    else
                        type = CrystalReport.TakeInType.ShipReceiving;
                    if (sReportKind == "crystal")
                    {
                        crReport.Front_TakeIn(sOrderID, type);
                        crReport.Print();
                        crReport.Print();
                    }
                    else
                    {
                        try
                        {
                            crReport.Excel_Front_TakeIn(sOrderID, type, 2);
                            //							crReport.Excel_Front_TakeIn(sOrderID, type);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(this, ex.Message, "Print error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        if (crReport != null)
                            crReport.CloseExcel();
                        crReport = null;
                        /*GC.Collect();
                        GC.WaitForPendingFinalizers(); 
                        GC.Collect();*/
                    }
                }
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private void cbCustomers_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                cbPickedByOurMessenger.Checked = false;
                DataRowView drvCurrentCustomer = (DataRowView)cbCustomers.SelectedItem;
                tbCustomerIDShip.Text = drvCurrentCustomer["CustomerCode"].ToString();
                InsertRowToOrderSummary(tbOrderSummaryShip, 0, "\tCustomer: " + drvCurrentCustomer["CustomerName"].ToString());
                StatusBar.Text = drvCurrentCustomer["CustomerName"].ToString();
                if (drvCurrentCustomer["CustomerID"].ToString() == "0")
                {
                    pCarrer.Enabled = false;
                    tbBarCode.Enabled = false;
                    gbOrderShip.Enabled = false;
                    btnClearShReceiv.Enabled = true;
                    btnSubmitShReceiv.Enabled = false;
                    //					if(btnRepeatCustomerShRcv.Tag.ToString() != "0")
                    //					{
                    //						btnRepeatCustomerShRcv.Enabled = true;
                    //					}
                    //					else
                    //					{
                    //						btnRepeatCustomerShRcv.Enabled = false;
                    //					}
                }
                else
                {
                    lblOrderNumberShRc.ResetText();
                    lblLastOrderShRc.ResetText();
                    btnViewReceiptShRc.Enabled = false;
                    pCarrer.Enabled = true;
                    tbBarCode.Enabled = true;
                    gbOrderShip.Enabled = true;
                    btnClearShReceiv.Enabled = true;
                    btnSubmitShReceiv.Enabled = true;
                    btnRepeatCustomerShRcv.Tag = "0_0";
                    btnRepeatCustomerShRcv.Text = "";
                    //					btnRepeatCustomerShRcv.Tag = cbCustomers.SelectedIndex.ToString() + (cbPickedByOurMessenger.Checked ? "_1" : "_0");
                    //					btnRepeatCustomerShRcv.Text = "Customer: " + drvCurrentCustomer["CustomerName"].ToString();
                }
            }
            finally { }

        }

        private void tbCustomerIDShip_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                cbCustomers.SelectedIndex = 0;
                DataRowView drvCurrentCustomer = (DataRowView)cbCustomers.SelectedItem;
                tbCustomerIDShip.Text = drvCurrentCustomer["CustomerCode"].ToString();
            }
            if (e.KeyCode == Keys.Enter)
            {
                bool IsExist = false;
                try
                {
                    DataView dvCustomers = (DataView)cbCustomers.DataSource;
                    foreach (DataRowView drvCustomerIterator in dvCustomers)
                    {
                        if (drvCustomerIterator["CustomerCode"].ToString() == tbCustomerIDShip.Text.ToString())
                        {
                            cbCustomers.SelectedItem = drvCustomerIterator;
                            IsExist = true;
                            break;
                        }
                    }
                    if (!IsExist)
                    {
                        tbCustomerIDShip.SelectAll();
                        StatusBar.Text = "Customer with code " + tbCustomerIDShip.Text.Trim() + " not exists";
                    }
                }
                catch { }
                finally { }
            }

        }

        private void btnNewCustomer_Click(object sender, System.EventArgs e)
        {
            cmstrategy.NewCustomer();
        }

        private void tbBarCode_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            ((TextBox)sender).Focus();
            ((TextBox)sender).SelectAll();
        }

        private void btnNewCustomerShip_Click(object sender, System.EventArgs e)
        {
            cmstrategy.NewCustomer();
        }

        private void btnDepSetDhip_Click(object sender, System.EventArgs e)
        {
            DataRowView drvCustomer = (DataRowView)cbCustomers.SelectedItem;
            try
            {
                DataRowView drvVendor = cmstrategy.DepartureSettings(drvCustomer["CustomerName"].ToString());
                sVendorShR = drvVendor["CustomerID"].ToString();
            }
            catch
            {
                sVendorShR = "";
            }
        }

        private void btnDepSet_Click(object sender, System.EventArgs e)
        {
            DataRowView drvCustomer = (DataRowView)cbCustomer.SelectedItem;
            try
            {
                DataRowView drvVendor = cmstrategy.DepartureSettings(drvCustomer["CustomerName"].ToString());
                sVendor = drvVendor["CustomerID"].ToString();

                lbVendor.Text = "Vendor: " + drvVendor["CustomerName"].ToString();
                if (!bIsVendorSelected)
                    MakeRoomForVendor();
                bIsVendorSelected = true;

                InsertRowToOrderSummary(tbOrderSummary, VendorIndex, lbVendor.Text);
            }
            catch
            {
                sVendor = "";
            }
        }

        private void btnNewMessenger_Click(object sender, System.EventArgs e)
        {
            cmstrategy.NewMessenger(cbCustomer.SelectedValue.ToString());
        }

        private void btnSubmit_Click(object sender, System.EventArgs e)
        {
            string sSelectedIndex = cbCustomer.SelectedIndex.ToString() + (cbPickedByOurMessengerT.Checked ? "_GSI" : "_" + cbMessenger.SelectedIndex.ToString());
            string sTitle = cbCustomer.Text;
            bool bPickedUpByOurMessenger = cbPickedByOurMessengerT.Checked;
            this.Cursor = Cursors.WaitCursor;
            StatusBar.Text = "Submitting changes. Please, wait";

            if (MessageBox.Show("Are you sure you want to save?", "", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                this.Cursor = Cursors.Default;
                StatusBar.Text = "Operation canceled";
                return;
            }
            //			else
            //			{
            //				btnRepeatCustomer.Tag = sSelectedIndex;
            //				btnRepeatCustomer.Text = "Customer: " + sTitle;
            //			}
            try
            {
                string CustomerID = cbCustomer.SelectedValue.ToString();
                DataSet dsUpdate = new DataSet();
                dsUpdate.Tables.Add(dsFrontGet.Tables["tblEntryBatch"].Clone());
                DataRow drBatch = dsUpdate.Tables["tblEntryBatch"].NewRow();

                gbOrder.GetBatch(drBatch);
                drBatch["CustomerID"] = cbCustomer.SelectedValue;

                if (cbMessenger.Enabled == false)
                {
                    drBatch["MessengerID"] = Convert.DBNull;
                }
                else
                {
                    if (cbMessenger.SelectedValue.ToString() != "0")
                        drBatch["MessengerID"] = cbMessenger.SelectedValue;
                    else throw new Exception("Select The Messenger!");
                }
                btnRepeatCustomer.Tag = sSelectedIndex;
                btnRepeatCustomer.Text = "Customer: " + sTitle;

                if (sVendor != "") drBatch["VendorOfficeID_VendorID"] = sVendor;
                //if (tbOrderMemo.Text !="") drBatch["Memo"] = tbOrderMemo.Text;

                dsUpdate.Tables["tblEntryBatch"].Rows.Add(drBatch);

                DataSet dsID = Service.InsertTakeIn(dsUpdate);//Procedure dbo.spSetEntryBatch
                //	Service.debug_DiaspalyDataSet(dsUpdate);

                string sOrderID = dsID.Tables[0].Rows[0][0].ToString();

                SaveMemoNumber(sOrderID);

                DataSet dsPickedUp = new DataSet();
                dsPickedUp.Tables.Add("PickedUpByOurMessenger");
                dsPickedUp.Tables[0].Columns.Add("PickedUpByOurMessenger", System.Type.GetType("System.String"));
                dsPickedUp.Tables[0].Columns.Add("GroupID", System.Type.GetType("System.String"));


                dsPickedUp.Tables[0].Rows.Add(dsPickedUp.Tables[0].NewRow());
                if (cbPickedByOurMessengerT.Checked)
                    dsPickedUp.Tables[0].Rows[0]["PickedUpByOurMessenger"] = 1;
                else
                    dsPickedUp.Tables[0].Rows[0]["PickedUpByOurMessenger"] = 0;

                dsPickedUp.Tables[0].Rows[0]["GroupID"] = sOrderID.Split(new char[] { '_' })[1].ToString();

                Service.ProxyGenericSet(dsPickedUp, "set"); //Procedure dbo.spsetPickedUpByOurMessenger

                try
                {
                    if (Service.iInvoiceDebugLevel >= 1)
                    {
                        int iViewAccessCode = 1; // ViewAccess = "Front Desc"
                        int iGroupOfficeId = Convert.ToInt32(sOrderID.Split(new char[] { '_' })[0]);
                        int iGroupId = Convert.ToInt32(sOrderID.Split(new char[] { '_' })[1]);
                        Service.DBAddGroupInvoice(iViewAccessCode, iGroupOfficeId, iGroupId); //Procedure dbo.spAddInvoice
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Warning: Can't add invoice for Front:\r\n" + exc.Message);
                }

                //string sOrderCode = Service.GetOrderCodeByOrderID(sOrderID);

                string sOrderCode = sOrderID.Split(new char[] { '_' })[2];
                //tbOrderSummary.Text += "\r\nThe data was successfully added";

                StatusBar.Text = "Data was successfully added. Created Order Code: " + sOrderCode;

                //				btnRepeatCustomer.Tag = sSelectedIndex.ToString();
                //				btnRepeatCustomer.Text = "Customer: " + sTitle;				

                lblOrderNumber.Text = "Last Order # ";
                lblLastOrder.Text = sOrderCode;

                btnViewReceipt.Enabled = true;
                sOrderID = sOrderID.Split(new char[] { '_' })[0] + "_" + sOrderID.Split(new char[] { '_' })[1];

                try
                {
                    //Print Report
                    for (; ; )
                    {

                        Print1(sOrderID, bPickedUpByOurMessenger);

                        if (MessageBox.Show("Would you like to print again?",
                            "Printing completed", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
                            continue;
                        else
                            break;
                    }
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Printing Error: " + exp.Message);
                }
                StatusBar.Text = "Ready";

                ClearTakeIn();
                btnRepeatCustomer.Tag = sSelectedIndex;
                btnRepeatCustomer.Text = "Customer: " + sTitle;
                btnRepeatCustomer.Enabled = true;
                lblOrderNumber.Text = "Last Order # ";
                lblLastOrder.Text = sOrderCode;
            }
            catch (Exception exp)
            {
                this.StatusBar.Text = exp.Message;
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// function for save MemoNumber
        /// by vetal_242 07.05.2006
        /// </summary>
        /// <param name="sOrderID"></param>
        /// <returns></returns>
        private bool SaveMemoNumber(string sOrderID)
        {
            string[] memoNumbers = gbOrder.getListOfMemoNumbers();
            DataSet dsMemoNumbers = new DataSet();
            dsMemoNumbers.Tables.Add("GroupMemoNumber");
            dsMemoNumbers.Tables[0].Columns.Add("GroupID");
            dsMemoNumbers.Tables[0].Columns.Add("Name");

            for (int i = 0; i < memoNumbers.Length; i++)
            {
                dsMemoNumbers.Tables[0].Rows.Add(dsMemoNumbers.Tables[0].NewRow());
                dsMemoNumbers.Tables[0].Rows[i]["GroupID"] = sOrderID.Split('_')[1];
                dsMemoNumbers.Tables[0].Rows[i]["Name"] = memoNumbers[i];
            }

            if (dsMemoNumbers.Tables[0].Rows.Count > 0)
            {
                Service.SetMemoNumber(dsMemoNumbers);//Loop of procedures dbo.spSetGroupMemoNumber
            }
            return true;
        }

        /// <summary>
        /// function for save MemoNumber
        /// by vetal_242 07.05.2006
        /// </summary>
        /// <param name="sOrderID"></param>
        /// <returns></returns>
        private bool SaveMemoNumberShReceiv(string sOrderID)
        {
            string[] memoNumbers = gbOrderShip.getListOfMemoNumbers();
            DataSet dsMemoNumbers = new DataSet();
            dsMemoNumbers.Tables.Add("GroupMemoNumber");
            dsMemoNumbers.Tables[0].Columns.Add("GroupID");
            dsMemoNumbers.Tables[0].Columns.Add("Name");

            for (int i = 0; i < memoNumbers.Length; i++)
            {
                dsMemoNumbers.Tables[0].Rows.Add(dsMemoNumbers.Tables[0].NewRow());
                dsMemoNumbers.Tables[0].Rows[i]["GroupID"] = sOrderID.Split('_')[1];
                dsMemoNumbers.Tables[0].Rows[i]["Name"] = memoNumbers[i];
            }

            if (dsMemoNumbers.Tables[0].Rows.Count > 0)
            {
                Service.SetMemoNumber(dsMemoNumbers);
            }
            return true;
        }

        private void Print1(string sOrderID, bool bPickedUpByOurMessenger)
        {
            string sCRTemplatePath = Client.GetOfficeDirPath("repDir");
            string sReportKind = Service.GetReportKind();
            CrystalReport.CrystalReport crReport;// = new CrystalReport.CrystalReport(sCRTemplatePath);
            if (rbPrintLabel.Checked)
            {
                if (sReportKind == "crystal")
                {
                    crReport = new CrystalReport.CrystalReport(sCRTemplatePath);
                    crReport.Front_TakeIn_Label(sOrderID);
                    crReport.Print();
                }
                else
                {
                    crReport = new CrystalReport.CrystalReport(sCRTemplatePath, true);
                    try
                    {
                        crReport.Excel_Front_TakeIn_Label(sOrderID);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, ex.Message, "Print error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (crReport != null)
                        crReport.CloseExcel();
                    crReport = null;
                    /*	GC.Collect();
                    GC.WaitForPendingFinalizers(); 
                    GC.Collect();*/
                }
            }

            //if(MessageBox.Show("Would You like to print external receipt?","External Receipt",MessageBoxButtons.YesNo,MessageBoxIcon.Question)
            //	== DialogResult.Yes)
            //{
            //	crReport = new CrystalReport.CrystalReport(sCRTemplatePath);
            //	crReport.Front_TakeIn(sOrderID);
            //	crReport.Print();
            //}

            ExternalReceiptForm f = new ExternalReceiptForm();
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                ExternalReceiptForm.Result r = f.MyResult;
                if (r == ExternalReceiptForm.Result.ONE)
                {
                    if (sReportKind == "crystal")
                    {
                        crReport = new CrystalReport.CrystalReport(sCRTemplatePath);
                    }
                    else
                    {
                        crReport = new CrystalReport.CrystalReport(sCRTemplatePath, true);
                    }
                    CrystalReport.TakeInType type;
                    if (bPickedUpByOurMessenger)
                        type = CrystalReport.TakeInType.TakeInPickedUpByOurMessenger;
                    else
                        type = CrystalReport.TakeInType.TakeIn;
                    if (sReportKind == "crystal")
                    {
                        crReport.Front_TakeIn(sOrderID, type);
                        crReport.Print();
                    }
                    else
                    {
                        try
                        {
                            crReport.Excel_Front_TakeIn(sOrderID, type, 1);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(this, ex.Message, "Print error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        if (crReport != null)
                            crReport.CloseExcel();
                        crReport = null;
                        /*GC.Collect();
                        GC.WaitForPendingFinalizers(); 
                        GC.Collect();*/
                    }

                }
                else if (r == ExternalReceiptForm.Result.TWO)
                {
                    if (sReportKind == "crystal")
                    {
                        crReport = new CrystalReport.CrystalReport(sCRTemplatePath);
                    }
                    else
                    {
                        crReport = new CrystalReport.CrystalReport(sCRTemplatePath, true);
                    }
                    CrystalReport.TakeInType type;
                    if (bPickedUpByOurMessenger)
                        type = CrystalReport.TakeInType.TakeInPickedUpByOurMessenger;
                    else
                        type = CrystalReport.TakeInType.TakeIn;
                    if (sReportKind == "crystal")
                    {
                        crReport.Front_TakeIn(sOrderID, type);
                        crReport.Print();
                        crReport.Print();
                    }
                    else
                    {
                        try
                        {
                            crReport.Excel_Front_TakeIn(sOrderID, type, 2);
                            //							crReport.Excel_Front_TakeIn(sOrderID, type);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(this, ex.Message, "Print error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        if (crReport != null)
                            crReport.CloseExcel();
                        crReport = null;
                        /*GC.Collect();
                        GC.WaitForPendingFinalizers(); 
                        GC.Collect();*/
                    }


                }
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private void tcFront_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            switch (tcFront.SelectedIndex)
            {
                case 3:
                    InitializeGiveOut();
                    break;
                case 1:
                    InitializeShipOut();
                    break;
            }
        }

        private void InitializeGiveOut()
        {
            ShipManifestGO.Initialize();
            Button[] bAddToManifestListGO = new Button[] { ShipManifestGO.bAddToManifest };
            Button[] bCreateManifestGO = new Button[] { ShipManifestGO.bCreateManifest };
            Button[] bClearManifestGO = new Button[] { ShipManifestGO.bClearData };

            bAddToManifestListGO[0].Click += new System.EventHandler(bAddToManifestListGO_Click);
            bCreateManifestGO[0].Click += new System.EventHandler(bCreateManifestGO_Click);
            bClearManifestGO[0].Click += new System.EventHandler(bClearManifestGO_Click);


            if (!otGiveOut.IsInitialize)
            {
                ClearGO();
            }
            else
            {
                tbBarCodeGO.Select();
                tbBarCodeGO.SelectAll();
            }
            tbBarCodeGO.Focus();
            chk_AutoCheckOut.Checked = true;
        }

        private void bAddToManifestListGO_Click(object sender, System.EventArgs e)
        {
            DataSet dsTemp1 = otGiveOut.Get();

            if (dsTemp1.Tables["tblBatch"].Rows.Count > 0)
            {
                dsManifestData = ShipManifestGO.AddToManifest(dsTemp1);
                if (dsManifestData != null)
                {
                    ShipManifestGO.bCreateManifest.Enabled = true;
                    if (dsManifestData.Tables.Count > 0)
                        StatusBar.Text = "Selected batches are added to manifest";
                }
                else
                {
                    ShipManifestGO.bCreateManifest.Enabled = false;
                    StatusBar.Text = "Can't Add Selected Batches to Manifest";
                }
            }

            /*
                dsBatchCPItemSet.Tables[0].Rows.Add(new Object[] {	oNBatches, 
                                                                            oQuantity, 
                                                                            oOrderCode, 
                                                                            oMemoNumber, 
                                                                            oCustomerCode, 
                                                                            oGroupID, 
                                                                            oOfficeID_CPID,
                                                                            oSetID,
                                                                            oItemTypeName});
            */
        }

        private void bCreateManifestGO_Click(object sender, System.EventArgs e)
        {
            if (dsManifestData != null)
            {


            }
        }

        private void bClearManifestGO_Click(object sender, System.EventArgs e)
        {
            ShipManifestGO.Initialize(); //.dgOrdersToDelivery.SetDataBinding(null, ""); 

        }

        private void tbBarCodeGO_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            bool bOpenOrder = false;
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    otGiveOut.SelectNode(tbBarCodeGO.Text);

                }
                catch
                {
                    if (otGiveOut.IsInitialize)
                    {
                        MessageBox.Show("Item not in the current order.");
                    }
                    else
                    {
                        try
                        {
                            // Get Data

                            //Initialize Components
                            string[] sCodesArray = tbBarCodeGO.Text.Split('.');
                            DataSet dsOrders = Service.GetOrderTreeDataByGroupCode(sCodesArray[0]);
                            //DataSet dsOrders = Service.GetOrderTreeDataByGroupCodeAndFilterBState(sCodesArray[0], "2");

                            if (dsOrders.Tables["tblOrder"].Rows.Count == 0)
                                throw new Exception("Order # " + sCodesArray[0] + " doesn't exists");

                            if (System.Convert.ToInt32(dsOrders.Tables[0].Rows[0]["StateCode"]) == 1)
                            {
                                if (MessageBox.Show("Order # " + sCodesArray[0] + " is closed. Would you like to open it temporary?", "Order status", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    bOpenOrder = true;
                                }
                                else throw new Exception("Order# " + sCodesArray[0] + " is closed");
                            }

                            if (System.Convert.ToInt32(dsOrders.Tables[0].Rows[0]["StateCode"]) >= 2 || bOpenOrder == true)
                            {
                                string sCusID = dsOrders.Tables["tblOrder"].Rows[0]["ParentID"].ToString();

                                DataTable dtCustomer = Service.GetCustomerByID(sCusID);
                                string sCusName = dtCustomer.Rows[0]["CustomerName"].ToString();

                                tbCustomerGO.Text = sCusName;

                                otGiveOut.Initialize(dsOrders);
                                otGiveOut.RealSelectNode(tbBarCodeGO.Text);
                                otGiveOut.ExpandOneLevel();
                                mcGiveOut.Initialize(Service.GetGiveOut(sCusID));

                                btnSubmitGo.Enabled = true;
                                mcGiveOut.Enabled = true;
                                btnClearGO.Enabled = true;
                                btnDepSetGO.Enabled = true;
                                btnNewMessengerGO.Enabled = false;
                                //								try
                                //								{
                                //									otGiveOut.SelectNode(tbBarCodeGO.Text);
                                //								}
                                //								catch
                                //								{
                                //									MessageBox.Show("Item not in the current order.");							
                                //								}
                            }
                        }
                        catch (Exception exc)
                        {
                            StatusBar.Text = exc.Message;
                        }
                    }
                }
                tbBarCodeGO.SelectAll();
                //if (chk_AutoCheckOut.Checked)
                //{
                //    btnSubmitGo_Click(sender, e);
                //}
            }
        }

        private void InitializeShipOut()
        {
            ShipManifestShO.Initialize();
            Button[] bAddToManifestListShO = new Button[] { ShipManifestShO.bAddToManifest };
            Button[] bCreateManifestShO = new Button[] { ShipManifestShO.bCreateManifest };

            bAddToManifestListShO[0].Click += new System.EventHandler(bAddToManifestListShO_Click);
            bCreateManifestShO[0].Click += new System.EventHandler(bCreateManifestShO_Click);

            if (!otShipOut.IsInitialize)
            {
                ClearShO();
            }
            else
            {
                tbBarCodeShO.Select();
                tbBarCodeShO.SelectAll();
            }

            DataSet dsIn = new DataSet();
            dsIn.Tables.Add("Carriers");
            DataSet dsCarriers = Service.ProxyGenericGet(dsIn);

            DataRow[] rCarriers = dsCarriers.Tables[0].Select("CarrierCode>6");

            DataTable dtMoreCarriers = new DataTable("MoreCarriers");
            dtMoreCarriers.Columns.Add("CarrierName", System.Type.GetType("System.String"));
            dtMoreCarriers.Columns.Add("CarrierCode", System.Type.GetType("System.String"));
            for (int i = 0; i < rCarriers.Length; i++)
            {
                DataRow rNew = dtMoreCarriers.NewRow();
                rNew["CarrierName"] = rCarriers[i]["CarrierName"].ToString();
                rNew["CarrierCode"] = rCarriers[i]["CarrierCode"].ToString();
                dtMoreCarriers.Rows.Add(rNew);
            }

            ccShipOut.AddDataToCombo(dtMoreCarriers);
        }

        private void bAddToManifestListShO_Click(object sender, System.EventArgs e)
        {

        }

        private void bCreateManifestShO_Click(object sender, System.EventArgs e)
        {

        }

        private void tbBarCodeShO_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            bool bOpenOrder = false;
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    otShipOut.SelectNode(tbBarCodeShO.Text);
                }
                catch
                {
                    if (otShipOut.IsInitialize)
                    {
                        MessageBox.Show("Item not in the current order.");
                    }
                    else
                    {
                        try
                        {
                            string[] sCodesArray = tbBarCodeShO.Text.Split('.');
                            DataSet dsOrders = Service.GetOrderTreeDataByGroupCode(sCodesArray[0]);
                            //DataSet dsOrders = Service.GetOrderTreeDataByGroupCodeAndFilterBState(sCodesArray[0], "2");

                            if (dsOrders.Tables["tblOrder"].Rows.Count == 0)
                                throw new Exception("Order # " + sCodesArray[0] + " doesn't exists");

                            if (System.Convert.ToInt32(dsOrders.Tables[0].Rows[0]["StateCode"]) == 1)
                            {
                                if (MessageBox.Show("Order # " + sCodesArray[0] + " is closed. Would you like to open it temporary?", "Order status", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    bOpenOrder = true;
                                }
                                else throw new Exception("Order# " + sCodesArray[0] + " is closed");
                            }

                            if (System.Convert.ToInt32(dsOrders.Tables[0].Rows[0]["StateCode"]) >= 2 || bOpenOrder == true)
                            {
                                string sCusID = dsOrders.Tables["tblOrder"].Rows[0]["ParentID"].ToString();

                                DataTable dtCustomer = Service.GetCustomerByID(sCusID);
                                string sCusName = dtCustomer.Rows[0]["CustomerName"].ToString();


                                tbCustomerShO.Text = sCusName;

                                otShipOut.Initialize(dsOrders);

                                btnSubmitShO.Enabled = true;
                                ccShipOut.Enabled = true;
                                btnClearShO.Enabled = true;
                                tbCarrierBarCodeShO.Enabled = true;
                                tbShipingCharch.Enabled = true;
                                btnDepSetShO.Enabled = true;
                                try
                                {
                                    otShipOut.SelectNode(tbBarCodeShO.Text);
                                }
                                catch
                                {
                                    MessageBox.Show("Item not in the current order.");
                                }
                            }
                        }
                        catch (Exception exc)
                        {
                            StatusBar.Text = exc.Message;
                        }

                    }
                }
                tbBarCodeShO.SelectAll();
            }
        }

        private void tbBarCodeShO_CodeEntered(object sender, System.EventArgs e)
        {
            bool bOpenOrder = false;
            try
            {
                otShipOut.SelectNode(tbBarCodeShO.Text);
            }
            catch
            {
                if (otShipOut.IsInitialize)
                {
                    MessageBox.Show("Item not in the current order.");
                }
                else
                {
                    try
                    {
                        string[] sCodesArray = tbBarCodeShO.Text.Split('.');
                        DataSet dsOrders = Service.GetOrderTreeDataByGroupCode(sCodesArray[1]);

                        if (dsOrders.Tables["tblOrder"].Rows.Count == 0)
                            throw new Exception("Order # " + sCodesArray[1] + " doesn't exists");

                        if (System.Convert.ToInt32(dsOrders.Tables[0].Rows[0]["StateCode"]) == 1)
                        {
                            if (MessageBox.Show("Order # " + sCodesArray[1] + " is closed. Would you like to open it temporary?", "Order status", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                bOpenOrder = true;
                            }
                            else throw new Exception("Order# " + sCodesArray[1] + " is closed");
                        }

                        if (System.Convert.ToInt32(dsOrders.Tables[0].Rows[0]["StateCode"]) >= 2 || bOpenOrder == true)
                        {
                            string sCusID = dsOrders.Tables["tblOrder"].Rows[0]["ParentID"].ToString();

                            DataTable dtCustomer = Service.GetCustomerByID(sCusID);
                            string sCusName = dtCustomer.Rows[0]["CustomerName"].ToString();

                            tbCustomerShO.Text = sCusName;

                            otShipOut.Initialize(dsOrders);

                            btnSubmitShO.Enabled = true;
                            ccShipOut.Enabled = true;
                            btnClearShO.Enabled = true;
                            tbCarrierBarCodeShO.Enabled = true;
                            tbShipingCharch.Enabled = true;
                            btnDepSetShO.Enabled = true;
                            try
                            {
                                otShipOut.SelectNode(tbBarCodeShO.Text);
                            }
                            catch
                            {
                                MessageBox.Show("Item not in the current order.");
                            }
                        }
                    }
                    catch (Exception exc)
                    {
                        StatusBar.Text = exc.Message;
                    }
                }
            }
            tbBarCodeShO.SelectAll();
        }

        private void tbBarCodeGO_CodeEntered(object sender, System.EventArgs e)
        {
            bool bOpenOrder = false;
            if (tbBarCodeGO.Text.Trim().Length > 4)
            {
                try
                {
                    otGiveOut.SelectNode(tbBarCodeGO.Text);
                }
                catch
                {
                    if (otGiveOut.IsInitialize)
                    {
                        MessageBox.Show("Item not in the current order.");
                    }
                    else
                    {
                        try
                        {
                            if (Service.IsMemo)
                                StatusBar.Text = "Loading Order by Memo list. Please, wait";
                            else
                                StatusBar.Text = "Loading Order by batch list. Please, wait";

                            string[] sCodesArray = tbBarCodeGO.Text.Split('.');
                            DataSet dsOrders = new DataSet();

                            dsOrders = Service.GetOrderTreeDataByGroupCode(sCodesArray[1]);//Procedures spGetGroupByCode, spGetBatchByCode, spGetItemByCode, spGetItemDocByCode

                            if (dsOrders.Tables["tblOrder"].Rows.Count == 0)
                                throw new Exception("Order # " + sCodesArray[0] + " doesn't exists");

                            if (System.Convert.ToInt32(dsOrders.Tables[0].Rows[0]["StateCode"]) == 1)
                            {
                                if (MessageBox.Show("Order # " + sCodesArray[0] + " is closed. Would you like to open it temporary?", "Order status", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    bOpenOrder = true;
                                }
                                else throw new Exception("Order# " + sCodesArray[0] + " is closed");
                            }

                            if (System.Convert.ToInt32(dsOrders.Tables[0].Rows[0]["StateCode"]) >= 2 || bOpenOrder == true)
                            {

                                ShipManifestGO.bAddToManifest.Enabled = true;

                                string sCusID = dsOrders.Tables["tblOrder"].Rows[0]["ParentID"].ToString();

                                DataTable dtCustomer = Service.GetCustomerByID(sCusID); //Procedure spGetCustomer
                                string sCusName = dtCustomer.Rows[0]["CustomerName"].ToString();

                                tbCustomerGO.Text = sCusName;

                                otGiveOut.Initialize(dsOrders);
                                otGiveOut.RealSelectNode(tbBarCodeGO.Text);
                                otGiveOut.ExpandOneLevel();
                                mcGiveOut.Initialize(Service.GetGiveOut(sCusID));//Procedure spGetPersonsByCustomer

                                btnSubmitGo.Enabled = true;
                                mcGiveOut.Enabled = true;
                                btnClearGO.Enabled = true;
                                btnDepSetGO.Enabled = true;
                                btnNewMessengerGO.Enabled = false;
                                StatusBar.Text = tbBarCodeGO.Text + " Loaded";
                                //							try
                                //							{
                                //								otGiveOut.SelectNode(tbBarCodeGO.Text);
                                //							}
                                //							catch
                                //							{
                                //								MessageBox.Show("Item not in the current order.");							
                                //							}
                            }
                        }
                        catch (Exception exc)
                        {
                            StatusBar.Text = exc.Message;
                        }
                    }
                }
                tbBarCodeGO.SelectAll();
                if (chk_AutoCheckOut.Checked)
                {
                    otGiveOut.CheckBoxes = true;
                    btnSubmitGo_Click(sender, e);
                }
            }
        }

        private void btnClearGO_Click(object sender, System.EventArgs e)
        {
            ClearGO();
        }

        private void btnSubmitGo_Click(object sender, System.EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            StatusBar.Text = "Submitting changes. Please, wait";

            if (!chk_AutoCheckOut.Checked && MessageBox.Show("Are you sure you want to save?", "", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                this.Cursor = Cursors.Default;
                StatusBar.Text = "Operation canceled";
                return;
            }
            // send data to server.

            try
            {
                if (!chk_AutoCheckOut.Checked && mcGiveOut.MessengerID.ToString().Trim() == "0") throw new Exception("Select The Messenger!");
                //
                //				// begin printing
                //				DataSet dsData = otGiveOut.GetChecked();
                //				//DataSet dsReport=otGiveOut.Get();
                //				//Service.debug_DiaspalyDataSetStruct(dsReport);
                //
                //				DataTable dtItems = dsData.Tables["tblItem"].Copy();
                //			
                //				dtItems.Columns.Add("Dimensions");
                //				dtItems.Columns.Add("CustomerName");
                //				int count = 0;
                //				string sDimensions = "";
                //				string customerName = "";
                //				string sDMax = "";
                //				string sDMin = "";
                //				string sH_x = "";
                //
                //				try
                //				{
                //					foreach(DataRow dr in dsData.Tables["tblItem"].Rows)
                //					{
                //						DataSet dsPartValueTypeEx = Service.GetPartValueTypeEx();
                //						DataSet dsPartValueType = dsPartValueTypeEx.Copy();
                //						dsPartValueType.Tables["PartValueTypeEx"].TableName = "PartValue";
                //						dsPartValueType.Tables["PartValue"].Rows.Add(dsPartValueType.Tables["PartValue"].NewRow());
                //						//dsPartValueType.Tables["PartValue"].Rows[0]["PartID"] = iContainerID;
                //						dsPartValueType.Tables["PartValue"].Rows[0]["RecheckNumber"] = -1;
                //						
                //						/* 
                //						  dsPartValueType.Tables["PartValue"].Rows[0]["BatchID"] = dr["BatchID"];
                //						dsPartValueType.Tables["PartValue"].Rows[0]["ItemCode"] = dr["Code"];*/
                //
                //						dsPartValueType.Tables["PartValue"].Rows[0]["BatchID"] = dr["NewBatchID"];
                //						dsPartValueType.Tables["PartValue"].Rows[0]["ItemCode"] = dr["NewItemCode"];
                //						dsPartValueType.Tables["PartValue"].Rows[0]["ViewAccessCode"] = DBNull.Value;
                //						dsPartValueType = Service.GetPartValueType(dsPartValueType);
                //
                //						DataTable dtPartValues = dsPartValueType.Tables[0].Copy();
                //						
                //						foreach(DataRow drRow in dtPartValues.Rows)
                //						{
                //							
                //							try
                //							{
                //								sDMax = Convert.ToDouble(Service.GetMeasureValue("DimensionMax", dtPartValues, drRow["PartID"].ToString())).ToString(".##");
                //								sDMin = Convert.ToDouble(Service.GetMeasureValue("DimensionMin", dtPartValues, drRow["PartID"].ToString())).ToString(".##");
                //								sH_x = Convert.ToDouble(Service.GetMeasureValue("H_x", dtPartValues, drRow["PartID"].ToString())).ToString(".##");
                //								if(sDMax != "" && sDMin != "" && sH_x != "")
                //								{
                //									sDimensions=sDMax+"-"+sDMin+" x "+sH_x + " mm";
                //									break;
                //								}
                //							}
                //							catch
                //							{
                //								sDimensions = "";
                //							}
                //						}
                //						dtItems.Rows[count]["Dimensions"] = sDimensions;
                //
                //						customerName = tbCustomerGO.Text;
                //						customerName = customerName.Substring(0, customerName.Length - 7);
                //
                //						dtItems.Rows[count]["CustomerName"] = customerName;
                //						count++;
                //					}
                //				}
                //				catch
                //				{
                //					MessageBox.Show("Unable to print report", "Report was not printed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //					StatusBar.Text = "Print error";
                //					this.Cursor = Cursors.Default;
                //					return;
                //				}
                //
                //				DataSet dsReport = new DataSet();
                //				dsReport.Tables.Add(dtItems);
                //			
                //				for(;;)
                //				{
                //					Print3(dsReport);
                //
                //					if(MessageBox.Show("Would you like to print again?", 
                //						"Printing completed", MessageBoxButtons.YesNo, 
                //						MessageBoxIcon.Question) == DialogResult.Yes)						
                //						continue;
                //					else
                //						break;
                //				}
                //				// end printing

                // set vendor
                DataTable dtVendor = Service.GetVendorStruct();//Procedure dbo.spGetGroupVendorTypeOf
                DataRow drVendor = dtVendor.NewRow();

                drVendor["GroupOfficeID_GroupID"] = otGiveOut.dsOrderTree.Tables["tblOrder"].Rows[0]["ID"];
                if (sVendorGO != "")
                {
                    drVendor["VendorOfficeID_VendorID"] = sVendorGO;
                }

                drVendor["ShipmentCharge"] = 0;
                dtVendor.Rows.Add(drVendor);

                Service.SetVendor(dtVendor);

                // set ItemOut
                DataSet dsTemp = new DataSet();
                //DataSet dsTemp = otGiveOut.GetChecked();//Procedure dbo.spSetGroupVendor

                if (chk_AutoCheckOut.Checked)
                    dsTemp = otGiveOut.dsOrderTree; //Procedure dbo.spSetGroupVendor
                else
                    dsTemp = otGiveOut.GetChecked();

                DataTable dtItemOut = Service.GetItemOutStruct();

                foreach (DataRow row in dsTemp.Tables["tblItem"].Rows)
                {
                    DataRow drItem = dtItemOut.NewRow();
                    drItem["BatchID_ItemCode"] = row["ID"];
                    //					if (mcGiveOut.MessengerID.ToString() != "0") 
                    //						drItem["PersonCustomerOfficeID_PersonCustomerID_PersonID"] = mcGiveOut.MessengerID;
                    //					else throw new Exception("Select The Messenger!");

                    dtItemOut.Rows.Add(drItem);
                }


                // set order tree to db
                Service.SetItemOut(dtItemOut);//Loop with procedure dbo.spSetItemOut				
                Service.SetOrderTreeCloseState(otGiveOut.GetChecked());//Procedure dbo.spSetCloseGroupStateByCode and loop with procedure dbo.spSetCloseBatchStateByCode and dbo.spSetCloseItemStateByCode

                #region BatchTracking
                DataSet dsTemp1 = otGiveOut.Get();

                if (dsTemp1.Tables["tblBatch"].Rows.Count > 0)
                {
                    foreach (DataRow dr in dsTemp1.Tables["tblBatch"].Rows)
                    {
                        DataRow[] drSet = dsTemp1.Tables["tblItem"].Select("NewBatchID = '" + dr["BatchID"].ToString() + "'");
                        if (drSet.Length > 0)
                        {
                            object BatchID = dr["BatchID"];
                            object EventID = GraderLib.BatchEvents.TakeOut;
                            object ItemsAffected = drSet.Length;
                            object ItemsInBatch = dr["ItemsQuantity"];
                            object FormID = GraderLib.Codes.AccRep;
                            Service.SetBatchEvent(EventID, BatchID, FormID, ItemsAffected, ItemsInBatch);//Procedure dbo.spSetBatchEvents
                        }
                    }
                }
                #endregion

                ClearGO();
                StatusBar.Text = "Data was successfully added";


            }
            catch (Exception exc)
            {
                StatusBar.Text = "Data wasn't added. Error: " + exc.Message;
            }
            this.Cursor = Cursors.Default;
        }

        private void Print3(DataSet dsReport)
        {
            try
            {
                string sCRTemplatePath = Client.GetOfficeDirPath("repDir");
                string sReportKind = Service.GetReportKind();
                CrystalReport.CrystalReport crBatch;//=new CrystalReport.CrystalReport(sCRTemplatePath);
                if (dsReport.Tables["tblItem"].Rows.Count == 0)
                {
                    MessageBox.Show("There are no items in selected orders", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (sReportKind == "crystal")
                {
                    crBatch = new CrystalReport.CrystalReport(sCRTemplatePath);
                    crBatch.Batch(dsReport);
                    crBatch.Print();
                }
                else
                {
                    crBatch = new CrystalReport.CrystalReport(sCRTemplatePath, true);
                    try
                    {
                        crBatch.Excel_Batch(dsReport);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, ex.Message, "Print error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (crBatch != null)
                        crBatch.CloseExcel();
                    crBatch = null;
                    /*GC.Collect();
                    GC.WaitForPendingFinalizers(); 
                    GC.Collect();*/
                }


                int ItemCount = dsReport.Tables["tblItem"].Rows.Count;
                CrystalReport.CrystalReport crReport;//=new CrystalReport.CrystalReport(sCRTemplatePath);
                if (sReportKind == "crystal")
                {
                    crReport = new CrystalReport.CrystalReport(sCRTemplatePath);
                    crReport.Items_Selected(ItemCount.ToString());
                    crReport.Print();
                }
                else
                {
                    crReport = new CrystalReport.CrystalReport(sCRTemplatePath, true);
                    try
                    {
                        crReport.Excel_Items_Selected(ItemCount.ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, ex.Message, "Print error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (crReport != null)
                        crReport.CloseExcel();
                    crReport = null;
                    /*GC.Collect();
                    GC.WaitForPendingFinalizers(); 
                    GC.Collect();*/
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private void ClearGO()
        {
            sVendorGO = "";
            otGiveOut.Clear();
            tbCustomerGO.Text = "";
            btnSubmitGo.Enabled = false;
            mcGiveOut.Clear();
            mcGiveOut.Enabled = false;
            btnClearGO.Enabled = false;
            btnDepSetGO.Enabled = false;
            btnNewMessengerGO.Enabled = false;
            tbBarCodeGO.Text = "Scan Barcode";
            tbBarCodeGO.Select();
            tbBarCodeGO.SelectAll();
            lbVendorGO.Text = strVendorInit;
            ShipManifestGO.bAddToManifest.Enabled = false;
            ShipManifestGO.bCreateManifest.Enabled = false;
            rbLoadByBatch.Checked = true;
            Service.IsMemo = false;
        }

        //Ship out, pick-up and measurements blocks are merged into one loop
        //by _3ter on 2006.06.19. accellerating
        //measurements and lot# are still not working!!!

        private void btnSubmitShO_Click(object sender, System.EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            StatusBar.Text = "Submitting changes. Please, wait";

            if (MessageBox.Show("Are you sure you want to save?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                this.Cursor = Cursors.Default;
                StatusBar.Text = "Operation canceled";
                return;
            }
            // send data to server.
            try
            {

                // begin printing
                DataSet dsData = otShipOut.GetChecked();
                //				//DataSet dsReport=otShipOut.Get();
                //				DataTable dtItems = dsData.Tables["tblItem"].Copy();
                //			
                //				dtItems.Columns.Add("Dimensions");
                //				dtItems.Columns.Add("CustomerName");
                //				int count = 0;
                //				string sDimensions = "";
                //				string customerName = "";
                //				string sDMax = "";
                //				string sDMin = "";
                //				string sH_x = "";

                try
                {
                    DataSet dsPartValueTypeEx = Service.GetPartValueTypeEx();//Procedure dbo.spGetPartValueTypeEx					

                    DataSet dsTemp = otShipOut.GetChecked();
                    DataTable dtItemOut = Service.GetItemOutStruct();//Procedure dbo.spGetItemOutTypeOf

                    DataSet dsPickedUp = new DataSet();
                    dsPickedUp.Tables.Add("ItemOutByOurMessenger");
                    dsPickedUp.Tables[0].Columns.Add("TakenOutByOurMessenger", System.Type.GetType("System.String"));
                    dsPickedUp.Tables[0].Columns.Add("BatchID", System.Type.GetType("System.String"));
                    dsPickedUp.Tables[0].Columns.Add("ItemCode", System.Type.GetType("System.String"));

                    foreach (DataRow dr in dsData.Tables["tblItem"].Rows)
                    {
                        //MEASUREMENTS
                        //						DataSet dsPartValueType = dsPartValueTypeEx.Copy();
                        //						dsPartValueType.Tables["PartValueTypeEx"].TableName = "PartValue";
                        //						dsPartValueType.Tables["PartValue"].Rows.Clear();
                        //						dsPartValueType.Tables["PartValue"].Rows.Add(dsPartValueType.Tables["PartValue"].NewRow());												
                        //						dsPartValueType.Tables["PartValue"].Rows[0]["RecheckNumber"] = -1;
                        //						/* sd 25.12.2006
                        //				
                        //						dsPartValueType.Tables["PartValue"].Rows[0]["BatchID"] = dr["BatchID"];
                        // 						dsPartValueType.Tables["PartValue"].Rows[0]["ItemCode"] = dr["Code"]; 
                        //						*/
                        //						dsPartValueType.Tables["PartValue"].Rows[0]["BatchID"] = dr["NewBatchID"];
                        //						dsPartValueType.Tables["PartValue"].Rows[0]["ItemCode"] = dr["NewItemCode"];
                        //
                        //						dsPartValueType.Tables["PartValue"].Rows[0]["ViewAccessCode"] = DBNull.Value;
                        //						dsPartValueType = Service.GetPartValueType(dsPartValueType);
                        //
                        //						DataTable dtPartValues = dsPartValueType.Tables[0].Copy();

                        //						foreach(DataRow drRow in dtPartValues.Rows)
                        //						{							
                        //							try
                        //							{
                        //								sDMax = Convert.ToDouble(Service.GetMeasureValue("DimensionMax", dtPartValues, drRow["PartID"].ToString())).ToString(".##");
                        //								sDMin = Convert.ToDouble(Service.GetMeasureValue("DimensionMin", dtPartValues, drRow["PartID"].ToString())).ToString(".##");
                        //								sH_x = Convert.ToDouble(Service.GetMeasureValue("H_x", dtPartValues, drRow["PartID"].ToString())).ToString(".##");
                        //								if(sDMax != "" && sDMin != "" && sH_x != "")
                        //								{
                        //									sDimensions=sDMax+"-"+sDMin+" x "+sH_x + " mm";
                        //									break;
                        //								}
                        //							}
                        //							catch
                        //							{
                        //								sDimensions = "";
                        //							}
                        //						}
                        //						dtItems.Rows[count]["Dimensions"] = sDimensions;

                        //						customerName = tbCustomerShO.Text;
                        //						customerName = customerName.Substring(0, customerName.Length - 7);
                        //
                        //						dtItems.Rows[count]["CustomerName"] = customerName;
                        //						count++;


                        //SHIP-OUT
                        DataRow drItem = dtItemOut.NewRow();
                        drItem["BatchID_ItemCode"] = dr["ID"];

                        try
                        {
                            string sCarrierCode = ccShipOut.CarrierCode;
                            DataRow[] drArray = dsFrontGet.Tables["Carriers"].Select("CarrierCode = '" + sCarrierCode + "'");
                            drItem["CarrierID"] = drArray[0]["CarrierID"];
                        }
                        catch { }

                        if (tbCarrierBarCodeShO.Text != tbCarrierBarCodeShO.Tag.ToString())
                        {
                            drItem["CarrierTrackingNumber"] = tbCarrierBarCodeShO.Text;
                        }

                        dtItemOut.Rows.Add(drItem);

                        //PICK-UP
                        DataRow r = dsPickedUp.Tables[0].NewRow();

                        if (cbTakenOutByOurMessenger.Checked)
                            r["TakenOutByOurMessenger"] = 1;
                        else
                            r["TakenOutByOurMessenger"] = 0;

                        r["BatchID"] = dr["BatchID"];
                        r["ItemCode"] = dr["Code"];

                        dsPickedUp.Tables[0].Rows.Add(r);

                    }
                    Service.SetItemOut(dtItemOut);
                    Service.ProxyGenericSet(dsPickedUp, "set");
                    Service.SetOrderTreeCloseState(otShipOut.GetChecked());
                    cbTakenOutByOurMessenger.Checked = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    StatusBar.Text = "Internal error";
                    this.Cursor = Cursors.Default;
                    return;
                }

                //SET VENDOR INTO HISTORY
                DataTable dtVendor = Service.GetVendorStruct();
                DataRow drVendor = dtVendor.NewRow();

                drVendor["GroupOfficeID_GroupID"] = otShipOut.dsOrderTree.Tables["tblOrder"].Rows[0]["ID"];
                if (sVendorShO != "")
                {
                    drVendor["VendorOfficeID_VendorID"] = sVendorShO;
                }

                drVendor["ShipmentCharge"] = 0;
                if (tbShipingCharch.Text != "")
                    try
                    {
                        drVendor["ShipmentCharge"] = Convert.ToDecimal(tbShipingCharch.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Shipping charge is in wrong format", "Wrong decimal format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        StatusBar.Text = "Shipping charge is in wrong format";
                        this.Cursor = Cursors.Default;
                        return;
                    }

                try
                {
                    if (Service.iInvoiceDebugLevel >= 1)
                    {
                        int iViewAccessCode = 1; // ViewAccess = "Front"
                        int iGroupOfficeId = Convert.ToInt32(drVendor["GroupOfficeID_GroupID"].ToString().Split(new char[] { '_' })[0]);
                        int iGroupId = Convert.ToInt32(drVendor["GroupOfficeID_GroupID"].ToString().Split(new char[] { '_' })[1]);
                        if (Convert.ToDecimal(drVendor["ShipmentCharge"]) > 0)
                            Service.DBAddGroupInvoice(iViewAccessCode, Convert.ToDecimal(drVendor["ShipmentCharge"]), iGroupOfficeId, iGroupId);
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Warning: Can't add invoice for Front:\r\n" + exc.Message);
                }

                dtVendor.Rows.Add(drVendor);

                Service.SetVendor(dtVendor);


                //PRINTING
                //				DataSet dsReport = new DataSet();
                //				dsReport.Tables.Add(dtItems);

                //				try
                //				{
                //					for(;;)
                //					{
                //						Print4(dsReport);
                //
                //						if(MessageBox.Show("Would you like to print again?", 
                //							"Printing completed", MessageBoxButtons.YesNo, 
                //							MessageBoxIcon.Question) == DialogResult.Yes)						
                //							continue;
                //						else
                //							break;
                //					}
                //				}
                //				catch
                //				{
                //					MessageBox.Show("Printing error occured", "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //					StatusBar.Text ="Internal error";
                //					this.Cursor = Cursors.Default;
                //					return;
                //				}



                StatusBar.Text = "Data was successfully added";
                #region BatchTracking
                DataSet dsTemp1 = otShipOut.Get();
                if (dsTemp1.Tables["tblBatch"].Rows.Count > 0)
                {
                    foreach (DataRow dr in dsTemp1.Tables["tblBatch"].Rows)
                    {
                        DataRow[] drSet = dsTemp1.Tables["tblItem"].Select("NewBatchID = '" + dr["BatchID"].ToString() + "'");
                        if (drSet.Length > 0)
                        {
                            object BatchID = dr["BatchID"];
                            object EventID = GraderLib.BatchEvents.ShipOut;
                            object ItemsAffected = drSet.Length;
                            object ItemsInBatch = dr["ItemsQuantity"];
                            object FormID = GraderLib.Codes.AccRep;
                            Service.SetBatchEvent(EventID, BatchID, FormID, ItemsAffected, ItemsInBatch);
                        }
                    }
                }
                #endregion
            }
            catch (Exception exc)
            {
                StatusBar.Text = "Error: " + exc.Message;
            }
            this.Cursor = Cursors.Default;
        }

        private void Print4(DataSet dsReport)
        {
            string sCRTemplatePath = Client.GetOfficeDirPath("repDir");
            string sReportKind = Service.GetReportKind();
            CrystalReport.CrystalReport crBatch;//=new CrystalReport.CrystalReport(sCRTemplatePath);
            if (dsReport.Tables["tblItem"].Rows.Count == 0)
            {
                MessageBox.Show("There are no items in selected orders", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (sReportKind == "crystal")
            {
                crBatch = new CrystalReport.CrystalReport(sCRTemplatePath);
                crBatch.Batch(dsReport);
                crBatch.Print();
            }
            else
            {
                crBatch = new CrystalReport.CrystalReport(sCRTemplatePath, true);
                try
                {
                    crBatch.Excel_Batch(dsReport);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Print error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (crBatch != null)
                    crBatch.CloseExcel();
                crBatch = null;
                /*GC.Collect();
                GC.WaitForPendingFinalizers(); 
                GC.Collect();*/
            }

            int ItemCount = dsReport.Tables["tblItem"].Rows.Count;
            CrystalReport.CrystalReport crReport;//=new CrystalReport.CrystalReport(sCRTemplatePath);
            if (sReportKind == "crystal")
            {
                crReport = new CrystalReport.CrystalReport(sCRTemplatePath);
                crReport.Items_Selected(ItemCount.ToString());
                crReport.Print();
            }
            else
            {
                crReport = new CrystalReport.CrystalReport(sCRTemplatePath, true);
                try
                {
                    crReport.Excel_Items_Selected(ItemCount.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Print error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (crReport != null)
                    crReport.CloseExcel();
                crReport = null;
                /*GC.Collect();
                GC.WaitForPendingFinalizers(); 
                GC.Collect();*/
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private void ClearShO()
        {
            sVendorShO = "";
            otShipOut.Clear();
            tbCustomerShO.Text = "";
            btnSubmitShO.Enabled = false;
            ccShipOut.Enabled = false;
            btnClearShO.Enabled = false;
            tbCarrierBarCodeShO.Enabled = false;
            btnDepSetShO.Enabled = false;
            tbBarCodeShO.Text = "Scan Barcode";
            tbShipingCharch.Enabled = false;
            tbBarCodeShO.Select();
            tbBarCodeShO.SelectAll();
            lbVendorShO.Text = strVendorInit;
            ShipManifestShO.bAddToManifest.Enabled = true;
            ShipManifestShO.bCreateManifest.Enabled = true;

        }

        private void gbOrder_Changed(object sender, EventArgs E)
        {
            MyEventArgs e = (MyEventArgs)E;
            int ItemIndex = e.Index;
            if (bIsVendorSelected)
                ItemIndex += 3;
            else
                ItemIndex += 2;

            InsertRowToOrderSummary(tbOrderSummary, ItemIndex, e.Text);
        }

        private void InsertRowToOrderSummary(TextBox OrderSummary, int ItemIndex, string sText)
        {
            int arrLength = OrderSummary.Lines.Length;

            if ((ItemIndex + 1) != arrLength)
            {
                for (int i = arrLength; i < (ItemIndex + 1); i++)
                {
                    OrderSummary.AppendText("\r\n");
                }
            }

            string[] sList = OrderSummary.Lines;
            sList[ItemIndex] = sText;
            OrderSummary.Lines = sList;
        }

        private void cbMessenger_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            string sText = "Messenger: " + ((DataRowView)cbMessenger.SelectedItem)["MessengerName"].ToString();

            int iMessengerIndex = MessengerIndex;
            if (bIsVendorSelected)
                iMessengerIndex++;
            InsertRowToOrderSummary(tbOrderSummary, iMessengerIndex, sText);
        }

        private void btnClearShO_Click(object sender, System.EventArgs e)
        {
            ClearShO();
        }

        private void btnDepSetGO_Click(object sender, System.EventArgs e)
        {
            try
            {
                DataRowView drvVendor = cmstrategy.DepartureSettings(tbCustomerGO.Text);
                sVendorGO = drvVendor["CustomerID"].ToString();

                lbVendorGO.Text = "Vendor: " + drvVendor["CustomerName"].ToString();
            }
            catch
            {
                sVendorGO = "";
            }
        }

        private void btnDepSetShO_Click(object sender, System.EventArgs e)
        {
            try
            {
                DataRowView drvVendor = cmstrategy.DepartureSettings(tbCustomerShO.Text);
                sVendorShO = drvVendor["CustomerID"].ToString();

                lbVendorShO.Text = "Vendor: " + drvVendor["CustomerName"].ToString();
            }
            catch
            {
                sVendorShO = "";
            }
        }

        private void btnNewMessengerGO_Click(object sender, System.EventArgs e)
        {
            cmstrategy.NewMessenger(cbCustomer.SelectedValue.ToString());
        }

        private void gbOrderShip_Changed(object sender, System.EventArgs E)
        {
            MyEventArgs e = (MyEventArgs)E;
            int ItemIndex = e.Index + 3;

            InsertRowToOrderSummary(tbOrderSummaryShip, ItemIndex, e.Text);
        }

        private void CarrierRadioButton_CheckedChanged(object sender, System.EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                if (((RadioButton)sender).Name == "rbMore")
                {
                    cmbCarrier.Enabled = true;
                    InsertRowToOrderSummary(tbOrderSummaryShip, 1, "Carrier: " + cmbCarrier.GetItemText(cmbCarrier.SelectedItem));
                    return;
                }

                cmbCarrier.Enabled = false;

                InsertRowToOrderSummary(tbOrderSummaryShip, 1, "Carrier: " + ((RadioButton)sender).Text);
            }
        }

        private void tbBarCode_TextChanged(object sender, System.EventArgs e)
        {
            string sBarCode = (((TextBox)sender).Text == ((TextBox)sender).Tag.ToString()) ? "" : ((TextBox)sender).Text;
            InsertRowToOrderSummary(tbOrderSummaryShip, 2, "Bar-Code: " + sBarCode);
        }

        private void cmbCarrier_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            InsertRowToOrderSummary(tbOrderSummaryShip, 1, "Carrier: " + cmbCarrier.GetItemText(cmbCarrier.SelectedItem));
        }

        private void cbPickedByOurMessengerT_CheckedChanged(object sender, System.EventArgs e)
        {
            cbMessenger.Enabled = !cbPickedByOurMessengerT.Checked;
        }

        private void MakeRoomForVendor()
        {
            string[] sList = tbOrderSummary.Lines;

            string[] sList2 = new string[sList.Length + 1];
            sList2[0] = sList[0];
            for (int i = 1; i < sList.Length; i++)
            {
                sList2[i + 1] = sList[i];
            }
            tbOrderSummary.Lines = sList2;
        }

        private void RemoveRoomForVendor()
        {
            string[] sList = tbOrderSummary.Lines;

            string[] sList2 = new string[sList.Length - 1];
            sList2[0] = sList[0];
            for (int i = 2; i < sList.Length; i++)
            {
                sList2[i - 1] = sList[i];
            }
            tbOrderSummary.Lines = sList2;
        }

        private void btnViewReceipt_Click(object sender, System.EventArgs e)
        {

            ViewReceipt(lblLastOrder.Text);
            //			string sRepPath = Client.GetOfficeDirPath("repDir"); 			
            //			CrystalReport.CrystalReport crReport;
            //			crReport=new CrystalReport.CrystalReport(sRepPath,true);
            //			DataTable dtOrder = Service.GetOrderByOrderCode(lblLastOrder.Text);
            //			if (dtOrder.Rows.Count > 0)
            //			{
            //				Client.ViewReport = true;
            //				crReport.Excel_Front_TakeIn(dtOrder.Rows[0]["GroupOfficeID"].ToString() + "_" + dtOrder.Rows[0]["GroupID"].ToString(), CrystalReport.TakeInType.TakeIn, 1);
            //				Client.ViewReport = false;
            //			}
        }

        private void ViewReceipt(string sOrderCode)
        {
            string sRepPath = Client.GetOfficeDirPath("repDir");
            CrystalReport.CrystalReport crReport;
            crReport = new CrystalReport.CrystalReport(sRepPath, true);
            DataTable dtOrder = Service.GetOrderByOrderCode(sOrderCode);
            if (dtOrder.Rows.Count > 0)
            {
                Client.ViewReport = true;
                crReport.Excel_Front_TakeIn(dtOrder.Rows[0]["GroupOfficeID"].ToString() + "_" + dtOrder.Rows[0]["GroupID"].ToString(),
                                            CrystalReport.TakeInType.TakeIn, 1);
                Client.ViewReport = false;
            }
        }

        private void gbOrder_Load(object sender, System.EventArgs e)
        {

        }

        private void btnRepeatCustomer_Click(object sender, System.EventArgs e)
        {
            string[] sTags = btnRepeatCustomer.Tag.ToString().Split('_');
            try
            {
                if (sTags[0] == "0") return;
                cbCustomer.SelectedIndex = Convert.ToInt32(sTags[0]);
                cbPickedByOurMessengerT.Checked = false;
                if (sTags[1] == "GSI")
                {
                    cbMessenger.SelectedIndex = 0;
                    cbPickedByOurMessengerT.Checked = true;
                }
                else
                    cbMessenger.SelectedIndex = Convert.ToInt32(sTags[1]);

                btnRepeatCustomer.Tag = sTags[0] + "_" + sTags[1];
                btnRepeatCustomer.Text = "Customer: " + cbCustomer.Text;
            }
            catch (Exception exc)
            {
                StatusBar.Text = exc.Message;
            }
        }

        private void btnRepeatCustomerShRcv_Click(object sender, System.EventArgs e)
        {
            string[] sTags = btnRepeatCustomerShRcv.Tag.ToString().Split('_');
            try
            {
                if (sTags[0] == "0") return;
                cbCustomers.SelectedIndex = Convert.ToInt32(sTags[0]);
                cbPickedByOurMessenger.Checked = (sTags[1] == "GSI" ? true : false);
                btnRepeatCustomerShRcv.Tag = sTags[0] + "_" + sTags[1];
                btnRepeatCustomerShRcv.Text = "Customer: " + cbCustomers.Text;
            }
            catch (Exception exc)
            {
                StatusBar.Text = exc.Message;
            }
        }

        private void btnViewReceiptShRc_Click(object sender, System.EventArgs e)
        {
            ViewReceipt(lblLastOrderShRc.Text);
            //			string sRepPath = Client.GetOfficeDirPath("repDir"); 			
            //			CrystalReport.CrystalReport crReport;
            //			crReport=new CrystalReport.CrystalReport(sRepPath,true);
            //			DataTable dtOrder = Service.GetOrderByOrderCode(lblLastOrder.Text);
            //			if (dtOrder.Rows.Count > 0)
            //			{
            //				Client.ViewReport = true;
            //				crReport.Excel_Front_TakeIn(dtOrder.Rows[0]["GroupOfficeID"].ToString() + "_" + dtOrder.Rows[0]["GroupID"].ToString(), CrystalReport.TakeInType.TakeIn, 1);
            //				Client.ViewReport = false;
            //			}
        }

        private void groupBox3_Enter(object sender, System.EventArgs e)
        {

        }

        private void rbLoadByBatch_CheckedChanged(object sender, System.EventArgs e)
        {
            if (rbLoadByBatch.Checked)
            {
                Service.IsMemo = false;
                if (otGiveOut.dsOrderTree != null)
                {
                    try
                    {
                        otGiveOut.Clear();
                        tbBarCodeGO_CodeEntered(sender, System.EventArgs.Empty);
                    }
                    catch { }
                    finally
                    {
                        Service.IsMemo = false;
                    }
                }

            }
            Service.IsMemo = false;
        }

        private void rbLoadByMemo_CheckedChanged(object sender, System.EventArgs e)
        {
            if (rbLoadByMemo.Checked)
            {
                Service.IsMemo = true;
                if (otGiveOut.dsOrderTree != null)
                {
                    try
                    {
                        otGiveOut.Clear();
                        tbBarCodeGO_CodeEntered(sender, System.EventArgs.Empty);
                        Service.IsMemo = false;
                    }
                    catch { }
                    finally
                    {
                        Service.IsMemo = false;
                    }
                }

            }
            Service.IsMemo = false;
        }

        private void FrontForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Service.IsMemo = false;
        }

		private void cmd_OrderFromXLS_Click(object sender, EventArgs e)
		{
			try
			{
				cmd_OrderFromXLS.Enabled = false;
				string fileToLoad = cmb_BulkData.SelectedItem.ToString();
				var memo = fileToLoad.ToUpper().Replace(".XLSX", "").Replace(".XLS", "");
				Workbook workbook = new Workbook();
				workbook.LoadFromFile(Client.GetOfficeDirPath("repDir") + @"RubyFront\" + fileToLoad);
				Worksheet sheet = workbook.Worksheets[0];
				DataTable dataTable = sheet.ExportDataTable();
				var nItems = dataTable.Rows.Count;
				
			}
			catch { }

		}
	}
}
