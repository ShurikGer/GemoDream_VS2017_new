using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;
using Excel = Microsoft.Office.Interop.Excel;


namespace gemoDream
{
	/// <summary>
	/// Summary description for OldNumbersForm.
	/// </summary>
	public class OldNumbersForm : System.Windows.Forms.Form
    {
		#region variables
		private Excel.Application objExcel;
		private Excel._Workbook BookTemp;

		private System.Windows.Forms.ListBox lbxOldNumbers;
        private System.Windows.Forms.Label lblNumberOfItems;
        private string sOrderCode = "";
        public string EntryBatch = "";
        public string sInspectedItems = "";
        public DataSet dsCPChanges;

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.Button btnSeparateBatch;
        private System.Windows.Forms.Button btnDone;

        private DataSet dsData;
        private DataSet dsOldNumbers;
        private TreeNode nodeSelectedBatch;
        private ArrayList alFiles;
        private TreeNode nodeFrom;
        private TreeNode nodeTo;
        private DataSet dsMemoNumbers;
        private bool bStart;
        private int AllNumberItems;
        private int CurrentNumberItems;
        private int SavedItems;
        private string sCustomerProgramID;
        private string sCustomerProgramName;
        private string sPath2Picture;
        //private string sXMLFileName;
        private Thread PrintingThread;
        private System.Windows.Forms.ComboBox cbMemoNumber;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblItemTypeName;
        private System.Windows.Forms.PictureBox picbox;
        private System.Windows.Forms.Button btnDeleteBatch;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.TreeView tvNewBatches;
        private System.Windows.Forms.TextBox txtOldNumbers;
        private System.Windows.Forms.ListBox lbNotFoundPrevNumbers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Panel pnlNumbers;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        #endregion
        private System.Windows.Forms.ContextMenu contextMnu;
        private System.Windows.Forms.MenuItem menuItemDeleteNumber;
        private System.Windows.Forms.Button btnDeleteNumber;
        private System.Windows.Forms.StatusBarPanel stsBarPnlMessages;
        private System.Windows.Forms.StatusBarPanel stsBarPnlsEIN;
        private System.Windows.Forms.StatusBarPanel stsBarPnlEIN;
        private System.Windows.Forms.StatusBarPanel stsBarPnlsSIN;
        private System.Windows.Forms.StatusBarPanel stsBarPnlSIN;
        /// <summary>
        /// Required designer variable.
        /// </summary>

        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.DataGrid dgOldNumbersFromList;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.Button btnStartFromList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbXMLFileList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnLoadAllFiles;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnClearDataGrid;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbSelectRealItem;
        private System.Windows.Forms.RadioButton rbSelectReportItem;
        private Label label7;
        private Label lbl_CID;

        //		private enum listType
        //		{
        //			eSelectedFile,
        //			eAllFiles,
        //			eRegularInput
        //		}
        const int EM_SCROLLCARET = 0x00B7;

        [DllImport("User32.dll")]
        extern static int SendMessage(IntPtr hWnd, UInt32 msg, Int32 wParam, Int32 lParam);

        public string CPID
        {
            get { return sCustomerProgramID; }
            set { sCustomerProgramID = value; }
        }


        public string CPName
        {
            get { return sCustomerProgramName; }
            set { sCustomerProgramName = value; }
        }
        public string Path2Picture
        {
            get { return sPath2Picture; }
            set { sPath2Picture = value; }
        }
        public OldNumbersForm()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            this.dsData = new System.Data.DataSet();
            this.dsData.Tables.Add(new DataTable("Batches"));
            this.dsData.Tables.Add(new DataTable("Items"));
            this.nodeFrom = null;
            this.nodeTo = null;
            this.nodeSelectedBatch = null;
            rbSelectRealItem.Checked = true;
            //this.MouseWheel += new MouseEventHandler(this.sdsds);
            //	GetMemoNumbers();
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        void sdsds(object sender, MouseEventArgs arg)
        {
            base.OnMouseWheel(arg);
        }
        public OldNumbersForm(string EntryBatch, string sGroupCode, string sAllNumberItems, DataTable dtOrderInfo, DataSet dsMemo)
        {
            InitializeComponent();
            this.EntryBatch = EntryBatch;
            this.sOrderCode = sGroupCode;
            //this.MouseWheel += new MouseEventHandler(this.sdsds);
            this.dsData = new System.Data.DataSet();
            this.dsData.Tables.Add(new DataTable("Batches"));
            this.dsData.Tables.Add(new DataTable("Items"));
            this.dsData.Tables.Add(new DataTable("NewItems"));
            dsData.Tables["NewItems"].Columns.Add("BatchID");
            dsData.Tables["NewItems"].Columns.Add("ItemCode");
            this.dsData.Tables.Add(new DataTable("NewBatches"));
            this.dsData.Tables.Add(dtOrderInfo);
            dsData.Tables["NewBatches"].Columns.Add("BatchID");
            this.nodeFrom = null;
            this.nodeTo = null;
            this.nodeSelectedBatch = null;
            this.CurrentNumberItems = 0;
            this.AllNumberItems = 0;
            this.SavedItems = 0;
            this.dsOldNumbers = new DataSet("ItemSet");
            this.label1.Text = "";
            this.alFiles = new ArrayList();

            try
            {
                this.AllNumberItems = Convert.ToInt32(sAllNumberItems);
            }
            catch { }
            dsMemoNumbers = dsMemo.Copy();
            GetMemoNumbers();////Procedure dbo.spGetGroupMemoNumber
            SetFormDone();
            if (Convert.ToInt16(sAllNumberItems) > 0) txtOldNumbers.Select();
            btnLoadFile.Enabled = false;
            btnLoadAllFiles.Enabled = false;
            btnStartFromList.Enabled = false;

            GetFileList();
            this.Text = Service.sProgramTitle + "Old Item Numbers. Order # " + sGroupCode;
            stsBarPnlEIN.Text = AllNumberItems.ToString();
            btnStart_Click(this, System.EventArgs.Empty);
            btnSeparateBatch.Enabled = false;
            label7.Text = "";
            lbl_CID.Text = "";


            //			DataTable dtDataFromXML = new DataTable();
            //			DataTable dtItemDataType = new DataTable();
            //			dtItemDataType = Service.GetOldItemByCodeTypeEx();
            //
            //			dtDataFromXML.Columns.Add("ITEM");
            //			dtDataFromXML.Columns.Add("OrderCode", dtItemDataType.Columns["OrderCode"].DataType);
            //			dtDataFromXML.Columns.Add("BatchCode", dtItemDataType.Columns["BatchCode"].DataType);
            //			dtDataFromXML.Columns.Add("ItemCode", dtItemDataType.Columns["ItemCode"].DataType);
            //
            //			dsOldNumbers.Tables.Add(dtDataFromXML);
            //			dsOldNumbers.Tables[0].RowDeleted += new System.Data.DataRowChangeEventHandler(OldItemListTable_Deleted);
            dgOldNumbersFromList.SetDataBinding(null, "");
            rbSelectRealItem.Checked = true;
            //lblExpectedItems.Text = AllNumberItems.ToString();
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


        //		[STAThread]
        //		static void Main() 
        //		{
        //			Application.Run(new OldNumbersForm("","","0",null));
        //		}
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OldNumbersForm));
			this.lbxOldNumbers = new System.Windows.Forms.ListBox();
			this.contextMnu = new System.Windows.Forms.ContextMenu();
			this.menuItemDeleteNumber = new System.Windows.Forms.MenuItem();
			this.lblNumberOfItems = new System.Windows.Forms.Label();
			this.btnSort = new System.Windows.Forms.Button();
			this.btnSeparateBatch = new System.Windows.Forms.Button();
			this.btnDone = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lblItemTypeName = new System.Windows.Forms.Label();
			this.picbox = new System.Windows.Forms.PictureBox();
			this.tvNewBatches = new System.Windows.Forms.TreeView();
			this.cbMemoNumber = new System.Windows.Forms.ComboBox();
			this.btnStart = new System.Windows.Forms.Button();
			this.btnDeleteBatch = new System.Windows.Forms.Button();
			this.lblError = new System.Windows.Forms.Label();
			this.txtOldNumbers = new System.Windows.Forms.TextBox();
			this.lbNotFoundPrevNumbers = new System.Windows.Forms.ListBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.pnlNumbers = new System.Windows.Forms.Panel();
			this.pnlButtons = new System.Windows.Forms.Panel();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.stsBarPnlMessages = new System.Windows.Forms.StatusBarPanel();
			this.stsBarPnlsEIN = new System.Windows.Forms.StatusBarPanel();
			this.stsBarPnlEIN = new System.Windows.Forms.StatusBarPanel();
			this.stsBarPnlsSIN = new System.Windows.Forms.StatusBarPanel();
			this.stsBarPnlSIN = new System.Windows.Forms.StatusBarPanel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label6 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.btnDeleteNumber = new System.Windows.Forms.Button();
			this.btnLoadFile = new System.Windows.Forms.Button();
			this.dgOldNumbersFromList = new System.Windows.Forms.DataGrid();
			this.btnStartFromList = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.cbXMLFileList = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.btnLoadAllFiles = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.btnClearDataGrid = new System.Windows.Forms.Button();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.rbSelectRealItem = new System.Windows.Forms.RadioButton();
			this.rbSelectReportItem = new System.Windows.Forms.RadioButton();
			this.label7 = new System.Windows.Forms.Label();
			this.lbl_CID = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picbox)).BeginInit();
			this.pnlNumbers.SuspendLayout();
			this.pnlButtons.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.stsBarPnlMessages)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.stsBarPnlsEIN)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.stsBarPnlEIN)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.stsBarPnlsSIN)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.stsBarPnlSIN)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgOldNumbersFromList)).BeginInit();
			this.groupBox4.SuspendLayout();
			this.SuspendLayout();
			// 
			// lbxOldNumbers
			// 
			this.lbxOldNumbers.AllowDrop = true;
			this.lbxOldNumbers.ContextMenu = this.contextMnu;
			this.lbxOldNumbers.ItemHeight = 12;
			this.lbxOldNumbers.Location = new System.Drawing.Point(5, 9);
			this.lbxOldNumbers.Name = "lbxOldNumbers";
			this.lbxOldNumbers.Size = new System.Drawing.Size(166, 376);
			this.lbxOldNumbers.TabIndex = 2;
			// 
			// contextMnu
			// 
			this.contextMnu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemDeleteNumber});
			// 
			// menuItemDeleteNumber
			// 
			this.menuItemDeleteNumber.Index = 0;
			this.menuItemDeleteNumber.Text = "Delete Number";
			this.menuItemDeleteNumber.Click += new System.EventHandler(this.menuItemDeleteNumber_Click);
			// 
			// lblNumberOfItems
			// 
			this.lblNumberOfItems.Location = new System.Drawing.Point(-2, 394);
			this.lblNumberOfItems.Name = "lblNumberOfItems";
			this.lblNumberOfItems.Size = new System.Drawing.Size(142, 15);
			this.lblNumberOfItems.TabIndex = 3;
			this.lblNumberOfItems.Text = "Number of Items:";
			// 
			// btnSort
			// 
			this.btnSort.Enabled = false;
			this.btnSort.Location = new System.Drawing.Point(201, 248);
			this.btnSort.Name = "btnSort";
			this.btnSort.Size = new System.Drawing.Size(48, 20);
			this.btnSort.TabIndex = 36;
			this.btnSort.Text = "Sort->";
			this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
			// 
			// btnSeparateBatch
			// 
			this.btnSeparateBatch.BackColor = System.Drawing.Color.LightSteelBlue;
			this.btnSeparateBatch.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSeparateBatch.Location = new System.Drawing.Point(24, 7);
			this.btnSeparateBatch.Name = "btnSeparateBatch";
			this.btnSeparateBatch.Size = new System.Drawing.Size(100, 48);
			this.btnSeparateBatch.TabIndex = 41;
			this.btnSeparateBatch.Text = "Change CP. Sep. Batch";
			this.btnSeparateBatch.UseVisualStyleBackColor = false;
			this.btnSeparateBatch.Click += new System.EventHandler(this.btnSeparateBatch_Click);
			// 
			// btnDone
			// 
			this.btnDone.BackColor = System.Drawing.Color.LightSteelBlue;
			this.btnDone.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDone.Location = new System.Drawing.Point(24, 94);
			this.btnDone.Name = "btnDone";
			this.btnDone.Size = new System.Drawing.Size(100, 22);
			this.btnDone.TabIndex = 40;
			this.btnDone.Text = "Done";
			this.btnDone.UseVisualStyleBackColor = false;
			this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lblItemTypeName);
			this.panel1.Controls.Add(this.picbox);
			this.panel1.Location = new System.Drawing.Point(336, 8);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(136, 280);
			this.panel1.TabIndex = 39;
			// 
			// lblItemTypeName
			// 
			this.lblItemTypeName.Location = new System.Drawing.Point(7, 141);
			this.lblItemTypeName.Name = "lblItemTypeName";
			this.lblItemTypeName.Size = new System.Drawing.Size(121, 131);
			this.lblItemTypeName.TabIndex = 0;
			this.lblItemTypeName.Text = "\"Short-hand\" CP Details, including structure";
			// 
			// picbox
			// 
			this.picbox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picbox.BackgroundImage")));
			this.picbox.Location = new System.Drawing.Point(7, 16);
			this.picbox.Name = "picbox";
			this.picbox.Size = new System.Drawing.Size(121, 112);
			this.picbox.TabIndex = 37;
			this.picbox.TabStop = false;
			this.picbox.Paint += new System.Windows.Forms.PaintEventHandler(this.picbox_Paint);
			// 
			// tvNewBatches
			// 
			this.tvNewBatches.AllowDrop = true;
			this.tvNewBatches.CheckBoxes = true;
			this.tvNewBatches.FullRowSelect = true;
			this.tvNewBatches.Location = new System.Drawing.Point(3, 9);
			this.tvNewBatches.Name = "tvNewBatches";
			this.tvNewBatches.Size = new System.Drawing.Size(323, 534);
			this.tvNewBatches.TabIndex = 43;
			this.tvNewBatches.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvNewBatches_AfterSelect);
			this.tvNewBatches.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvNewBatches_ItemDrag);
			this.tvNewBatches.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvNewBatches_AfterSelect);
			this.tvNewBatches.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvNewBatches_DragDrop);
			this.tvNewBatches.DragOver += new System.Windows.Forms.DragEventHandler(this.tvNewBatches_DragOver);
			this.tvNewBatches.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvNewBatches_MouseDown);
			this.tvNewBatches.MouseLeave += new System.EventHandler(this.tvNewBatches_MouseLeave);
			this.tvNewBatches.MouseHover += new System.EventHandler(this.tvNewBatches_MouseHover);
			this.tvNewBatches.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tvNewBatches_MouseMove);
			this.tvNewBatches.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tvNewBatches_MouseUp);
			// 
			// cbMemoNumber
			// 
			this.cbMemoNumber.Location = new System.Drawing.Point(113, 8);
			this.cbMemoNumber.Name = "cbMemoNumber";
			this.cbMemoNumber.Size = new System.Drawing.Size(184, 20);
			this.cbMemoNumber.TabIndex = 45;
			this.cbMemoNumber.SelectedIndexChanged += new System.EventHandler(this.cbMemoNumber_SelectedIndexChanged);
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(320, 8);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(75, 20);
			this.btnStart.TabIndex = 46;
			this.btnStart.Text = "&Start";
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// btnDeleteBatch
			// 
			this.btnDeleteBatch.BackColor = System.Drawing.Color.LightPink;
			this.btnDeleteBatch.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDeleteBatch.Location = new System.Drawing.Point(24, 63);
			this.btnDeleteBatch.Name = "btnDeleteBatch";
			this.btnDeleteBatch.Size = new System.Drawing.Size(100, 22);
			this.btnDeleteBatch.TabIndex = 47;
			this.btnDeleteBatch.Text = "Delete Batch";
			this.btnDeleteBatch.UseVisualStyleBackColor = false;
			this.btnDeleteBatch.Click += new System.EventHandler(this.btnDeleteBatch_Click);
			// 
			// lblError
			// 
			this.lblError.Location = new System.Drawing.Point(3, 409);
			this.lblError.Name = "lblError";
			this.lblError.Size = new System.Drawing.Size(142, 24);
			this.lblError.TabIndex = 48;
			// 
			// txtOldNumbers
			// 
			this.txtOldNumbers.Location = new System.Drawing.Point(113, 32);
			this.txtOldNumbers.Name = "txtOldNumbers";
			this.txtOldNumbers.Size = new System.Drawing.Size(184, 20);
			this.txtOldNumbers.TabIndex = 49;
			this.txtOldNumbers.TextChanged += new System.EventHandler(this.txtOldNumbers_TextChanged);
			this.txtOldNumbers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOldNumbers_KeyDown);
			this.txtOldNumbers.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOldNumbers_KeyPress);
			this.txtOldNumbers.MouseEnter += new System.EventHandler(this.txtOldNumbers_MouseEnter);
			// 
			// lbNotFoundPrevNumbers
			// 
			this.lbNotFoundPrevNumbers.BackColor = System.Drawing.SystemColors.Control;
			this.lbNotFoundPrevNumbers.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lbNotFoundPrevNumbers.ItemHeight = 12;
			this.lbNotFoundPrevNumbers.Location = new System.Drawing.Point(5, 462);
			this.lbNotFoundPrevNumbers.Name = "lbNotFoundPrevNumbers";
			this.lbNotFoundPrevNumbers.SelectionMode = System.Windows.Forms.SelectionMode.None;
			this.lbNotFoundPrevNumbers.Size = new System.Drawing.Size(144, 108);
			this.lbNotFoundPrevNumbers.TabIndex = 50;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.label2.Location = new System.Drawing.Point(5, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(94, 15);
			this.label2.TabIndex = 51;
			this.label2.Text = "Memo number:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(5, 32);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 15);
			this.label3.TabIndex = 52;
			this.label3.Text = "Old Item Number:";
			// 
			// pnlNumbers
			// 
			this.pnlNumbers.Controls.Add(this.label2);
			this.pnlNumbers.Controls.Add(this.cbMemoNumber);
			this.pnlNumbers.Controls.Add(this.label3);
			this.pnlNumbers.Controls.Add(this.txtOldNumbers);
			this.pnlNumbers.Location = new System.Drawing.Point(2, 2);
			this.pnlNumbers.Name = "pnlNumbers";
			this.pnlNumbers.Size = new System.Drawing.Size(305, 57);
			this.pnlNumbers.TabIndex = 53;
			// 
			// pnlButtons
			// 
			this.pnlButtons.Controls.Add(this.btnDeleteBatch);
			this.pnlButtons.Controls.Add(this.btnSeparateBatch);
			this.pnlButtons.Controls.Add(this.btnDone);
			this.pnlButtons.Enabled = false;
			this.pnlButtons.Location = new System.Drawing.Point(336, 296);
			this.pnlButtons.Name = "pnlButtons";
			this.pnlButtons.Size = new System.Drawing.Size(136, 120);
			this.pnlButtons.TabIndex = 54;
			// 
			// statusBar1
			// 
			this.statusBar1.AccessibleRole = System.Windows.Forms.AccessibleRole.StatusBar;
			this.statusBar1.Location = new System.Drawing.Point(0, 688);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.stsBarPnlMessages,
            this.stsBarPnlsEIN,
            this.stsBarPnlEIN,
            this.stsBarPnlsSIN,
            this.stsBarPnlSIN});
			this.statusBar1.ShowPanels = true;
			this.statusBar1.Size = new System.Drawing.Size(979, 24);
			this.statusBar1.SizingGrip = false;
			this.statusBar1.TabIndex = 57;
			// 
			// stsBarPnlMessages
			// 
			this.stsBarPnlMessages.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.None;
			this.stsBarPnlMessages.Name = "stsBarPnlMessages";
			this.stsBarPnlMessages.Width = 300;
			// 
			// stsBarPnlsEIN
			// 
			this.stsBarPnlsEIN.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.None;
			this.stsBarPnlsEIN.Name = "stsBarPnlsEIN";
			this.stsBarPnlsEIN.Text = "Expected Item Numbers:";
			this.stsBarPnlsEIN.Width = 190;
			// 
			// stsBarPnlEIN
			// 
			this.stsBarPnlEIN.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.None;
			this.stsBarPnlEIN.Name = "stsBarPnlEIN";
			this.stsBarPnlEIN.Width = 50;
			// 
			// stsBarPnlsSIN
			// 
			this.stsBarPnlsSIN.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.None;
			this.stsBarPnlsSIN.Name = "stsBarPnlsSIN";
			this.stsBarPnlsSIN.Text = "Saved Item Numbers:";
			this.stsBarPnlsSIN.Width = 160;
			// 
			// stsBarPnlSIN
			// 
			this.stsBarPnlSIN.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.None;
			this.stsBarPnlSIN.Name = "stsBarPnlSIN";
			this.stsBarPnlSIN.Width = 50;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.lbxOldNumbers);
			this.groupBox1.Controls.Add(this.lblNumberOfItems);
			this.groupBox1.Controls.Add(this.lblError);
			this.groupBox1.Controls.Add(this.lbNotFoundPrevNumbers);
			this.groupBox1.Location = new System.Drawing.Point(18, 112);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(177, 570);
			this.groupBox1.TabIndex = 58;
			this.groupBox1.TabStop = false;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(0, 443);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(136, 16);
			this.label6.TabIndex = 51;
			this.label6.Text = "Wrong/Missing Numbers";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.pnlButtons);
			this.groupBox2.Controls.Add(this.panel1);
			this.groupBox2.Controls.Add(this.tvNewBatches);
			this.groupBox2.Controls.Add(this.groupBox3);
			this.groupBox2.Location = new System.Drawing.Point(266, 112);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(480, 570);
			this.groupBox2.TabIndex = 59;
			this.groupBox2.TabStop = false;
			// 
			// groupBox3
			// 
			this.groupBox3.Location = new System.Drawing.Point(133, 19);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(136, 80);
			this.groupBox3.TabIndex = 70;
			this.groupBox3.TabStop = false;
			// 
			// btnDeleteNumber
			// 
			this.btnDeleteNumber.BackColor = System.Drawing.Color.LightPink;
			this.btnDeleteNumber.Enabled = false;
			this.btnDeleteNumber.Location = new System.Drawing.Point(201, 216);
			this.btnDeleteNumber.Name = "btnDeleteNumber";
			this.btnDeleteNumber.Size = new System.Drawing.Size(48, 20);
			this.btnDeleteNumber.TabIndex = 60;
			this.btnDeleteNumber.Text = "&Delete";
			this.btnDeleteNumber.UseVisualStyleBackColor = false;
			this.btnDeleteNumber.Click += new System.EventHandler(this.btnDeleteNumber_Click);
			// 
			// btnLoadFile
			// 
			this.btnLoadFile.Location = new System.Drawing.Point(423, 22);
			this.btnLoadFile.Name = "btnLoadFile";
			this.btnLoadFile.Size = new System.Drawing.Size(115, 20);
			this.btnLoadFile.TabIndex = 61;
			this.btnLoadFile.Text = "Load Selected File";
			this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
			// 
			// dgOldNumbersFromList
			// 
			this.dgOldNumbersFromList.CausesValidation = false;
			this.dgOldNumbersFromList.DataMember = "";
			this.dgOldNumbersFromList.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgOldNumbersFromList.Location = new System.Drawing.Point(770, 105);
			this.dgOldNumbersFromList.Name = "dgOldNumbersFromList";
			this.dgOldNumbersFromList.ParentRowsVisible = false;
			this.dgOldNumbersFromList.PreferredColumnWidth = 120;
			this.dgOldNumbersFromList.RowHeadersVisible = false;
			this.dgOldNumbersFromList.Size = new System.Drawing.Size(197, 577);
			this.dgOldNumbersFromList.TabIndex = 62;
			// 
			// btnStartFromList
			// 
			this.btnStartFromList.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.btnStartFromList.Location = new System.Drawing.Point(804, 48);
			this.btnStartFromList.Name = "btnStartFromList";
			this.btnStartFromList.Size = new System.Drawing.Size(115, 20);
			this.btnStartFromList.TabIndex = 63;
			this.btnStartFromList.Text = "Convert to New ##";
			this.btnStartFromList.UseVisualStyleBackColor = false;
			this.btnStartFromList.Click += new System.EventHandler(this.btnStartFromList_Click);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Brown;
			this.label1.Location = new System.Drawing.Point(0, 546);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(480, 24);
			this.label1.TabIndex = 64;
			// 
			// cbXMLFileList
			// 
			this.cbXMLFileList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbXMLFileList.Enabled = false;
			this.cbXMLFileList.Location = new System.Drawing.Point(544, 22);
			this.cbXMLFileList.Name = "cbXMLFileList";
			this.cbXMLFileList.Size = new System.Drawing.Size(231, 20);
			this.cbXMLFileList.TabIndex = 65;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(562, 3);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(184, 16);
			this.label4.TabIndex = 66;
			this.label4.Text = "Old Numbers Files List";
			// 
			// btnLoadAllFiles
			// 
			this.btnLoadAllFiles.Location = new System.Drawing.Point(423, 48);
			this.btnLoadAllFiles.Name = "btnLoadAllFiles";
			this.btnLoadAllFiles.Size = new System.Drawing.Size(113, 20);
			this.btnLoadAllFiles.TabIndex = 67;
			this.btnLoadAllFiles.Text = "Load All Files";
			this.btnLoadAllFiles.Click += new System.EventHandler(this.btnLoadAllFiles_Click);
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(214, 79);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(181, 30);
			this.label5.TabIndex = 68;
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnClearDataGrid
			// 
			this.btnClearDataGrid.Location = new System.Drawing.Point(807, 21);
			this.btnClearDataGrid.Name = "btnClearDataGrid";
			this.btnClearDataGrid.Size = new System.Drawing.Size(112, 20);
			this.btnClearDataGrid.TabIndex = 69;
			this.btnClearDataGrid.Text = "Clear Table";
			this.btnClearDataGrid.Click += new System.EventHandler(this.btnClearDataGrid_Click);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.rbSelectRealItem);
			this.groupBox4.Controls.Add(this.rbSelectReportItem);
			this.groupBox4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.groupBox4.Location = new System.Drawing.Point(8, 64);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(145, 45);
			this.groupBox4.TabIndex = 71;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Item Type";
			// 
			// rbSelectRealItem
			// 
			this.rbSelectRealItem.Location = new System.Drawing.Point(10, 20);
			this.rbSelectRealItem.Name = "rbSelectRealItem";
			this.rbSelectRealItem.Size = new System.Drawing.Size(50, 15);
			this.rbSelectRealItem.TabIndex = 0;
			this.rbSelectRealItem.Text = "Real";
			// 
			// rbSelectReportItem
			// 
			this.rbSelectReportItem.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.rbSelectReportItem.Location = new System.Drawing.Point(80, 15);
			this.rbSelectReportItem.Name = "rbSelectReportItem";
			this.rbSelectReportItem.Size = new System.Drawing.Size(60, 25);
			this.rbSelectReportItem.TabIndex = 1;
			this.rbSelectReportItem.Text = "Report";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(318, 40);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(38, 12);
			this.label7.TabIndex = 72;
			this.label7.Text = "CID #";
			// 
			// lbl_CID
			// 
			this.lbl_CID.Location = new System.Drawing.Point(669, 52);
			this.lbl_CID.Name = "lbl_CID";
			this.lbl_CID.Size = new System.Drawing.Size(106, 30);
			this.lbl_CID.TabIndex = 73;
			// 
			// OldNumbersForm
			// 
			this.AllowDrop = true;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
			this.ClientSize = new System.Drawing.Size(979, 712);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.lbl_CID);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.btnClearDataGrid);
			this.Controls.Add(this.btnLoadAllFiles);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.cbXMLFileList);
			this.Controls.Add(this.btnStartFromList);
			this.Controls.Add(this.dgOldNumbersFromList);
			this.Controls.Add(this.btnLoadFile);
			this.Controls.Add(this.btnDeleteNumber);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.statusBar1);
			this.Controls.Add(this.pnlNumbers);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.btnSort);
			this.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Name = "OldNumbersForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "OldNumbersForm";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.OldNumbersForm_Closing);
			this.Closed += new System.EventHandler(this.OldNumbersForm_Closed);
			//this.Load += new System.EventHandler(this.OldNumbersForm_Load);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picbox)).EndInit();
			this.pnlNumbers.ResumeLayout(false);
			this.pnlNumbers.PerformLayout();
			this.pnlButtons.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.stsBarPnlMessages)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.stsBarPnlsEIN)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.stsBarPnlEIN)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.stsBarPnlsSIN)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.stsBarPnlSIN)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgOldNumbersFromList)).EndInit();
			this.groupBox4.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }
        #endregion

        #region DragDrop
        private void tvNewBatches_ItemDrag(object sender, ItemDragEventArgs e)
        {
            /*
            try
            {
                TreeView tv =((TreeView)sender);
                TreeNode tn=(TreeNode)e.Item;
                if(tn!=null&&tn.Parent!=null)
                {
                    nodeFrom=tn;
                    tv.DoDragDrop(tn,DragDropEffects.Move);
                }
                else
                {
                    nodeFrom=null;
                }
            }
            catch(Exception ex)
            {
                string msg=ex.Message;
            }
            */
        }

        private void tvNewBatches_DragDrop(object sender, DragEventArgs e)
        {
            /*
            TreeNode to = tvNewBatches.GetNodeAt(tvNewBatches.PointToClient(new Point(e.X,e.Y)));
            TreeNode from =(TreeNode)e.Data.GetData(typeof(TreeNode));
            if(CanDropNode(from,to))
            {
                CopyItemToOtherBatch(from,to);
            }
            */
        }
        private bool CanDropNode(TreeNode from, TreeNode to)
        {
            bool result = false;
            if (to != null && from != null && to != from && from.Parent != to && from.Parent != to.Parent && bStart)
            {
                //copy only to new batch
                string sbID = GetbIDForNode(to);
                string filter = "bID = '" + sbID + "'";
                DataRow[] drBatches = dsData.Tables["Batches"].Select(filter);
                if (drBatches.Length > 0)
                {
                    string IsNewBatch = drBatches[0]["IsNewBatch"].ToString();
                    if (IsNewBatch == "1")
                    {
                        DataRow[] drItems = dsData.Tables["Items"].Select(filter);
                        if (drItems.Length < 25)
                            result = true;
                    }
                }
            }
            return result;
        }

        private void tvNewBatches_DragOver(object sender, DragEventArgs e)
        {
            /*
            TreeNode to = tvNewBatches.GetNodeAt(tvNewBatches.PointToClient(new Point(e.X,e.Y)));
            TreeNode from =(TreeNode)e.Data.GetData(typeof(TreeNode));
			
            bool f = CanDropNode(from,to);
            if(f)
                e.Effect = DragDropEffects.Move;
            else
                e.Effect= DragDropEffects.None;
                */
        }
        #endregion

        private string AddBacth(DataRow oldBatch)
        {
            // Add Batch to DataSet
            string sID = "";
            try
            {
                if (dsData.Tables["Batches"].Columns.Count == 0)
                {
                    foreach (DataColumn col in oldBatch.Table.Columns)
                    {
                        dsData.Tables["Batches"].Columns.Add(col.ColumnName);
                    }
                    dsData.Tables["Batches"].Columns.Add("bID");
                    dsData.Tables["Batches"].Columns.Add("IsNewBatch");
                }
                dsData.Tables["Batches"].Rows.Add(new object[] { });
                foreach (DataColumn col in oldBatch.Table.Columns)
                {
                    dsData.Tables["Batches"].Rows[dsData.Tables["Batches"].Rows.Count - 1][col.ColumnName] =
                        oldBatch[col.ColumnName];
                }

                sID = Service.FillToThreeChars(dsData.Tables["Batches"].Rows.Count.ToString());
                if (dsData.Tables["Batches"].Rows.Count > 0)
                    dsData.Tables["Batches"].Rows[dsData.Tables["Batches"].Rows.Count - 1]["bID"] = sID;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return sID;
        }
        private void AddItems(DataRow[] Items, string bID)
        {
            //Add Item(prev number) to DataSet
            foreach (DataRow drItem in Items)
            {
                DataRow dr = drItem.Table.NewRow();
                if (dsData.Tables["Items"].Columns.Count == 0)
                {
                    foreach (DataColumn col in drItem.Table.Columns)
                    {
                        dsData.Tables["Items"].Columns.Add(col.ColumnName);
                    }
                    dsData.Tables["Items"].Columns.Add("iID");
                    dsData.Tables["Items"].Columns.Add("bID");
                    dsData.Tables["Items"].Columns.Add("FirstbID");
                    dsData.Tables["Items"].Columns.Add("NewNumber");
                }
                dsData.Tables["Items"].Rows.Add(new object[] { });
                foreach (DataColumn col in drItem.Table.Columns)
                {
                    dsData.Tables["Items"].Rows[dsData.Tables["Items"].Rows.Count - 1][col.ColumnName] =
                        drItem[col.ColumnName];
                }

                dsData.Tables["Items"].Rows[dsData.Tables["Items"].Rows.Count - 1]["bID"] = bID;
                string iID = Service.FillToTwoChars(dsData.Tables["Items"].Rows.Count.ToString());
                dsData.Tables["Items"].Rows[dsData.Tables["Items"].Rows.Count - 1]["iID"] = iID;
                dsData.Tables["Items"].Rows[dsData.Tables["Items"].Rows.Count - 1]["FirstbID"] = bID;
            }

        }
        private void AddNewBatch(string sbID)
        {
            // Add new Batch in DataSet. Copy data from selected Old Batch
            string filter = "bID = '" + sbID + "'";
            DataRow[] drBatches = dsData.Tables["Batches"].Select(filter);
            if (drBatches.Length > 0)
            {
                dsData.Tables["Batches"].Rows.Add(new object[] { });
                foreach (DataColumn col in dsData.Tables["Batches"].Columns)
                {
                    dsData.Tables["Batches"].Rows[dsData.Tables["Batches"].Rows.Count - 1][col.ColumnName] =
                        drBatches[0][col.ColumnName];
                }
                dsData.Tables["Batches"].Rows[dsData.Tables["Batches"].Rows.Count - 1]["bID"] =
                    Service.FillToThreeChars(dsData.Tables["Batches"].Rows.Count.ToString());
                dsData.Tables["Batches"].Rows[dsData.Tables["Batches"].Rows.Count - 1]["IsNewBatch"] = "1";

                if (CPID != "")
                {
                    dsData.Tables["Batches"].Rows[dsData.Tables["Batches"].Rows.Count - 1]["BasicCPID"] = CPID;
                    dsData.Tables["Batches"].Rows[dsData.Tables["Batches"].Rows.Count - 1]["CustomerProgramName"] = CPName;
                    dsData.Tables["Batches"].Rows[dsData.Tables["Batches"].Rows.Count - 1]["Path2Picture"] = Path2Picture;
                }

            }
        }

        private void GetFileList()
        {
            //return;
            this.label4.Text = "";
            cbXMLFileList.Items.Clear();
            cbXMLFileList.SelectedIndex = -1;
            cbXMLFileList.Enabled = false;
            string sXMLFilePath = Client.GetOfficeDirPath("oldNumberXMLDir");
			
#if DEBUG
			sXMLFilePath = @"C:\dell\SendDir\OldNumbersXML\";
#endif
			DirectoryInfo di = new DirectoryInfo(sXMLFilePath);
            FileInfo[] fi = di.GetFiles("*");
            if (fi.Length > 0)
            {
                btnLoadFile.Enabled = true;
                btnLoadAllFiles.Enabled = true;

                foreach (FileInfo fitemp in fi)
                {
                    if (fitemp.Name.ToLower().EndsWith(".xml")) // || fitemp.Name.ToLower().Contains(".xls"))

						cbXMLFileList.Items.Add(fitemp.Name);
                }
            }

            if (cbXMLFileList.Items.Count > 0)
            {
                cbXMLFileList.SelectedIndex = 0;
                this.label4.Text = "Old Numbers Files List";
                cbXMLFileList.Enabled = true;
            }
        }

        private ArrayList CreateNewBatch(DataRow[] items, DataRow oldBatch)//, out string BatchID)
        {
            //Create new Batch in DB.Add new Items for Batch and copy data from old Items
            ArrayList result = new ArrayList();

            DataRowView drvMemo = ((DataRowView)cbMemoNumber.SelectedItem);
            string sMemoName = null;
            string sMemoID = null;
            if (drvMemo != null && drvMemo["Name"].ToString() != "[none]")
            {
                sMemoName = drvMemo["Name"].ToString();
                if (rbSelectReportItem.Checked) sMemoName = sMemoName + " (P)";
                sMemoID = drvMemo["MemoNumberID"].ToString();
            }
            else
            {
                if (rbSelectReportItem.Checked) sMemoName = "(P)";
                //                {
                //                    sMemoName = "(P)";
                //                    sMemoID = drvMemo["MemoNumberID"].ToString();
                //                }
            }

            string sOldBatchID = oldBatch["BatchID"].ToString();

            string sOldBatchCode = "";//oldBatch["BatchCode"].ToString();
            string sOldOrderCode = "";//oldBatch["GroupCode"].ToString();
            string sOldItemCode = "";

            string sNewBatchCode = "";
            string sNewOrderCode = "";
            string sNewItemCode = "";
            string sBatchId = "";

            sBatchId = Service.CreateNewBatch(EntryBatch,
                                                oldBatch["CPOfficeID"] + "_" + oldBatch["BasicCPID"],
                                                oldBatch["ItemTypeID"].ToString(),
                                                items.Length.ToString(),
                                                sMemoName,
                                                sMemoID);  //Procedure "dbo.spAddBatch"

            //Service.get
            //get BatchCode
            DataSet dsBatchIn = new DataSet();
            DataTable dtBatch = new DataTable("Batch");
            dtBatch.Columns.Add("BatchID");
            dtBatch.Rows.Add(new object[] { sBatchId });
            dsBatchIn.Tables.Add(dtBatch);
            DataSet dsBatchOut = Service.ProxyGenericGet(dsBatchIn); //Procedure "dbo.spGetBatch"
            //--------
            string sFullBatchCode = "";
            if (dsBatchOut.Tables[0].Rows.Count > 0)
            {
                sFullBatchCode = sBatchId + ";" +
                    Service.FillToFiveChars(dsBatchOut.Tables[0].Rows[0]["OrderCode"].ToString()) + "." +
                    Service.FillToFiveChars(dsBatchOut.Tables[0].Rows[0]["GroupCode"].ToString()) + "." +
                    Service.FillToThreeChars(dsBatchOut.Tables[0].Rows[0]["BatchCode"].ToString());
            }
            sNewBatchCode = dsBatchOut.Tables[0].Rows[0]["BatchCode"].ToString();
            sNewOrderCode = dsBatchOut.Tables[0].Rows[0]["OrderCode"].ToString();

            foreach (DataRow rowFrom in items)
            {
                #region add item to batch -----------
                string prev = rowFrom["prevN"].ToString();

                sOldOrderCode = prev.Split('.')[0];
                sOldBatchCode = prev.Split('.')[2];
                sOldItemCode = prev.Split('.')[3];


                //NewBatchID, NewItemCode for current Item
                //string NewFullItemCode = Service.GetNewItemCodeByCode(sOldOrderCode,sOldOrderCode,sOldBatchCode,sOldItemCode);//Procedure "dbo.spGetNewItemCodeByCode"

                DataSet itemsds = Service.AddItemToBatch(sBatchId, prev);
                //--Set Number created item;


                //--
                if (itemsds != null && itemsds.Tables.Count > 0 && itemsds.Tables[0].Rows.Count > 0 && itemsds.Tables[0].Rows[0][0].ToString() != "")
                {
                    sNewItemCode = itemsds.Tables[0].Rows[0][0].ToString().Split('_')[1];
                    SavedItems++;

                    //					DataSet ds = Service.CopyAllPartValuesFromItemToItem(
                    //						NewFullItemCode.Split('.')[3], 
                    //						NewFullItemCode.Split('.')[2],
                    //						NewFullItemCode.Split('.')[1],
                    //						//sOldItemCode, sOldBatchCode,sOldOrderCode, 
                    //						sNewItemCode, sNewBatchCode, sNewOrderCode);

                    //add BatchCode.ItemCode to result 123.12
                    result.Add(prev + ";" + sFullBatchCode + "." +
                        Service.FillToTwoChars(sNewItemCode));
                }
                #endregion
            }

			DataSet dsPrefill = new DataSet();
			DataTable dtPrefill = new DataTable("PrefilledMeasuresFromCP");
			dtPrefill.Columns.Add("BatchID");
			dtPrefill.Rows.Add(new Object[] {sBatchId});
			dsPrefill.Tables.Add(dtPrefill);
			DataSet temp = Service.ProxyGenericSet(dsPrefill, "Set");//Procedure dbo.spSetPrefilledMeasuresFromCP//

			return result;
        }
        public ArrayList BatchAddOldItems(ArrayList alOldNumbers, bool bFromTable)
        {
            //Group items by Basic CPID 
            //Same Basic CPID in same Batch
            ArrayList outList = new ArrayList();
            ArrayList OldNumbers = new ArrayList(alOldNumbers);

            //CheckIsItem
            if (!bFromTable)
            {
                foreach (string OldNumber in alOldNumbers)
                {
                    if (!CheckIsItem(OldNumber, false))
                    {
                        if (lblError.Text == "")
                        {
                            lblError.Text = "Can`t find Item Number:";
                        }
                        lbNotFoundPrevNumbers.Items.Add(OldNumber);
                        OldNumbers.RemoveAt(OldNumbers.IndexOf(OldNumber));
                        outList.Clear();
                        return outList;
                    }
                }
            }
            DataTable dtOldNumbers = new DataTable();
            DataTable dtItems = new DataTable();
            //dtOldNumbers.Columns.Add("MemoNumber");
            //dtOldNumbers.Columns.Add("MemoNumberID");
            dtOldNumbers.Columns.Add("BasicCPID");
            dtOldNumbers.Columns.Add("prevN");

            DataTable dtBatch = new DataTable();
            dtBatch.Columns.Add("BasicCPID");
            dtBatch.Columns.Add("prevN");

            #region

            Hashtable htPrevCode = new Hashtable();
            foreach (string oldNumber in OldNumbers)
            {
                string prev = oldNumber;
                if (prev != "")
                {
                    dtOldNumbers.Rows.Add(new object[] { });
                    dtOldNumbers.Rows[dtOldNumbers.Rows.Count - 1]["prevN"] = oldNumber;
                    string[] prevs = prev.Split('.');
                    string sPrevCode = Service.FillToFiveChars(prevs[0]) + "." +
                        Service.FillToThreeChars(prevs[2]) + "." +
                        Service.FillToTwoChars(prevs[3]);
                    try
                    {
                        htPrevCode.Add(sPrevCode, null);
                    }
                    catch (Exception ex)
                    {
                        string msg = ex.Message;
                    }
                }
            }

            #endregion
            bool f = false;
            //create old batches`s table

            string sPrevBatchCode = "";
            DataRow Batch = null;
            foreach (string prevCode in htPrevCode.Keys)
            //foreach(string prevCode in OldNumbers)
            {
                string sPrevBatchCode1 = prevCode.Split('.')[0] + prevCode.Split('.')[1];
                if (sPrevBatchCode1 != sPrevBatchCode)
                {
                    Batch = Service.NewCustomerProgramInstanceByBatchCode(prevCode.Split('.')[0], prevCode.Split('.')[1], prevCode.Split('.')[2]); //Procedure dbo.spGetNewCustomerProgramInstanceByBatchCode
					sPrevBatchCode = sPrevBatchCode1;
                }
                if (Batch == null)
                {
                    //If number is not found, that deletes it from table and add message
                    if (lblError.Text == "")
                    {
                        lblError.Text = "Can`t find Item Number:";
                    }
                    string filter = "prevN like '" + prevCode.Split('.')[0] + "." +
                                                    prevCode.Split('.')[0] + "." +
                                                    prevCode.Split('.')[1] + "%'";

                    DataRow[] drs = dtOldNumbers.Select(filter);
                    foreach (DataRow dr in drs)
                    {
                        lbNotFoundPrevNumbers.Items.Add(dr["prevN"].ToString());
                        lbxOldNumbers.Items.Remove(dr["prevN"].ToString());
                        dr.Delete();
                    }
                    SetNumberOfItems();
                }
                else
                {
                    dtBatch.Rows.Add(new object[] { });
                    DataRow drBatch = null;
                    foreach (DataColumn col in Batch.Table.Columns)
                    {
                        if (!f) try { dtBatch.Columns.Add(col.ColumnName); }
                            catch { }
                        drBatch = dtBatch.Rows[dtBatch.Rows.Count - 1];
                        drBatch[col.ColumnName] = Batch[col.ColumnName];
                    }
                    f = true;
                    drBatch["BasicCPID"] = Batch["BasicCPID"];
                    drBatch["prevN"] = prevCode;
                }
            }

            Hashtable htBasicCPID = new Hashtable();
            foreach (DataRow dr in dtOldNumbers.Rows)
            {
                try
                {
                    string prev = dr["prevN"].ToString();
                    if (prev != "")
                    {
                        string sPrevCode = Service.FillToFiveChars(prev.Split('.')[1]) + "." +
                                            Service.FillToThreeChars(prev.Split('.')[2]) + "." +
                                            Service.FillToTwoChars(prev.Split('.')[3]);
                        DataRow[] drPrev = dtBatch.Select("prevN = '" + sPrevCode + "'");
                        if (drPrev.Length > 0)
                        {
                            dr["BasicCPID"] = drPrev[0]["BasicCPID"];
                        }
                    }
                    htBasicCPID.Add(dr["BasicCPID"].ToString(), null);
                }
                catch (Exception ex)
                { string msg = ex.ToString(); }
            }
            DataRow[] drCPs = null;
            try
            {
                foreach (string cp in htBasicCPID.Keys)
                {
                    string filter = "BasicCPID = " + ((cp == "") ? "''" : "'" + cp + "'");
                    drCPs = dtOldNumbers.Select(filter);
                    if (drCPs.Length < 26)
                    {
                        DataRow[] drBatch = dtBatch.Select("BasicCPID = '" + cp + "'");
                        string bID = AddBacth(drBatch[0]);
                        AddItems(drCPs, bID);
                    }
                    else
                    {
                        int count = 0;
                        ArrayList al = new ArrayList();
                        foreach (DataRow dr in drCPs)
                        {
                            if (count < 25)
                            {
                                al.Add(dr);
                            }
                            else
                            {
                                DataRow[] drBatch = dtBatch.Select("BasicCPID = '" + cp + "'");
                                string bID = AddBacth(drBatch[0]);
                                DataRow[] drItems = (DataRow[])al.ToArray(typeof(System.Data.DataRow));
                                AddItems(drItems, bID);
                                al.Clear();
                                al.Add(dr);
                                count = 0;
                            }
                            count++;
                        }
                        if (al.Count > 0)
                        {
                            DataRow[] drBatch = dtBatch.Select("BasicCPID = '" + cp + "'");
                            string bID = AddBacth(drBatch[0]);
                            DataRow[] drItems = (DataRow[])al.ToArray(typeof(System.Data.DataRow));
                            AddItems(drItems, bID);
                            al.Clear();
                        }

                    }
                }
                CurrentNumberItems = dsData.Tables["Items"].Rows.Count;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            tvNewBatches.BeginUpdate();
            tvNewBatches.Nodes.Clear();
            FillBatchTree();
            tvNewBatches.EndUpdate();
            return outList;
        }


        private void FillBatchTree()
        {
            //Fill TreeView Batches from DataSet
            tvNewBatches.Nodes.Clear();
            TreeNode tn = null;
            try
            {
                foreach (DataRow drBatch in dsData.Tables["Batches"].Rows)
                {
                    string cpname = drBatch["CustomerProgramName"].ToString();
                    string sIsNewBatch = drBatch["IsNewBatch"].ToString();
                    string nodeName = "Batch " + drBatch["bID"].ToString() + "(" + cpname + ")";
                    if (sIsNewBatch == "1")
                        nodeName += " +";
                    tn = new TreeNode(nodeName);
                    string filter = "bID = '" + drBatch["bID"].ToString() + "'";
                    DataRow[] drItems = dsData.Tables["Items"].Select(filter, "prevN");
                    foreach (DataRow drItem in drItems)
                    {
                        string ItemText = "";
                        if (drItem["NewNumber"].ToString() != "")
                            ItemText = drItem["prevN"].ToString() + " (" + drItem["NewNumber"].ToString() + ")";
                        else
                            ItemText = drItem["prevN"].ToString();
                        tn.Nodes.Add(new TreeNode(ItemText));
                    }
                    tvNewBatches.Nodes.Add(tn);
                }
                tvNewBatches.ExpandAll();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }

        private void SetNumberOfItems()
        {
            //Display number entered Old Item Numbers
            lblNumberOfItems.Text = "Number of Items: " + lbxOldNumbers.Items.Count.ToString();
            CurrentNumberItems = lbxOldNumbers.Items.Count;
        }
        private bool CheckEnteredCode()
        {
            //Check entered Item Code #####.#####.###.## or #####.###.## or ##########

            //			if(cbMemoNumber.Text == "[none]" || cbMemoNumber.Text.Trim() == "")
            //			{
            //				if(MessageBox.Show("Memo info is missing.\r\nIs it OK to itemize this batch?",
            //					"Missing Memo info", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) == DialogResult.No)	
            //				{
            //					return false;
            //				}
            ////                else
            ////                {
            ////                    if (rbSelectReportItem.Checked) cbMemoNumber.Text = "(P)";
            ////                }
            //             }
            label7.Text = "";
            lbl_CID.Text = "";
            txtOldNumbers.Text = txtOldNumbers.Text.Trim();
			//if (txtOldNumbers.Text.Length >= 7 && txtOldNumbers.Text.Length < 10)
			if (Regex.IsMatch(txtOldNumbers.Text, @"^\d{7,9}$"))
			{
   				if (txtOldNumbers.Text.Length == 7)
				{
					label7.Text = "CID #";
					lbl_CID.Text = txtOldNumbers.Text.Trim();
				}
				txtOldNumbers.Text = gemoDream.Service.GetItemNumberBy7digit(txtOldNumbers.Text);
            }

            string sText = txtOldNumbers.Text;
            Regex re = null;
            string sReg = "";

            switch (sText.Length)
            {
                case 10:
                    if (sText.IndexOf(".") < 0)
                    {
                        string s = sText.Substring(0, 5) + "."  /*+ sText.Substring(0,5) + "."*/ + sText.Substring(5, 3) + "." + sText.Substring(8, 2);
                        sText = s;
                        sReg = @"\d{5}.\d{3}\.\d{2}";
                        re = new Regex(sReg);
                        if (re.IsMatch(sText))
                        {
                            string[] sCodes = sText.Split('.');
                            sText = sCodes[0] + "." + sCodes[0] + "." + sCodes[1] + "." + sCodes[2];
                            sReg = @"\d{5}.\d{5}.\d{3}\.\d{2}";
                        }
                    }
                    break;
                case 11:
                    if (sText.IndexOf(".") < 0)
                    {
                        string s = sText.Substring(0, 6) + "." + sText.Substring(6, 3) + "." + sText.Substring(9, 2);
                        sText = s;
                        sReg = @"\d{6}.\d{3}\.\d{2}";
                        re = new Regex(sReg);
                        if (re.IsMatch(sText))
                        {
                            string[] sCodes = sText.Split('.');
                            sText = sCodes[0] + "." + sCodes[0] + "." + sCodes[1] + "." + sCodes[2];
                            sReg = @"\d{6}.\d{6}.\d{3}\.\d{2}";
                        }
                    }
                    break;
                case 12:
					if (sText.IndexOf(".") < 0)
					{
						string s = sText.Substring(0, 7) + "." + sText.Substring(7, 3) + "." + sText.Substring(10, 2);
						sText = s;
						sReg = @"\d{7}.\d{3}\.\d{2}";
						re = new Regex(sReg);
						if (re.IsMatch(sText))
						{
							string[] sCodes = sText.Split('.');
							sText = sCodes[0] + "." + sCodes[0] + "." + sCodes[1] + "." + sCodes[2];
							sReg = @"\d{7}.\d{7}.\d{3}\.\d{2}";
						}
	   				}
					else
					{
						sReg = @"\d{5}.\d{3}\.\d{2}";
						re = new Regex(sReg);
						if (re.IsMatch(sText))
						{
							string[] sCodes = sText.Split('.');
							sText = sCodes[0] + "." + sCodes[0] + "." + sCodes[1] + "." + sCodes[2];
							sReg = @"\d{5}.\d{5}.\d{3}\.\d{2}";
						}
					}
                    break;

                case 13:
					if (sText.Contains("."))
					{
						sReg = @"\d{6}.\d{3}\.\d{2}";
						re = new Regex(sReg);
						if (re.IsMatch(sText))
						{
							string[] sCodes = sText.Split('.');
							sText = sCodes[0] + "." + sCodes[0] + "." + sCodes[1] + "." + sCodes[2];
							sReg = @"\d{6}.\d{6}.\d{3}\.\d{2}";
						}
					}
                    break;

				case 14:
					if (sText.Contains("."))
					{
						sReg = @"\d{7}.\d{3}\.\d{2}";
						re = new Regex(sReg);
						if (re.IsMatch(sText))
						{
							string[] sCodes = sText.Split('.');
							sText = sCodes[0] + "." + sCodes[0] + "." + sCodes[1] + "." + sCodes[2];
							sReg = @"\d{7}.\d{7}.\d{3}\.\d{2}";
						}
					}
					break;

				default:
                    txtOldNumbers.Text = "Order#.Batch#.Item#";
                    stsBarPnlMessages.Text = sText + ": Number/Format is incorrect";
                    label1.Text = stsBarPnlMessages.Text;
                    txtOldNumbers.SelectAll();
                    return false;
            }

            //                    if(sText.Length != 10 && sText.Length != 12)
            //                    {
            //                        txtOldNumbers.Text="#####.###.##";
            //                        stsBarPnlMessages.Text =sText + ": Number/Format is incorrect";
            //                        label1.Text = stsBarPnlMessages.Text;
            //                        txtOldNumbers.SelectAll();
            //                        return false;
            //                    }
            //
            //                    if(sText.IndexOf(".")<0 && sText.Length==10)
            //                    {
            //                        string s = sText.Substring(0,5) + "." + 
            //                            sText.Substring(5,3) + "." + 
            //                            sText.Substring(8,2);
            //                        sText = s;
            //                    }
            //			
            //                    if (sText.Length == 12) 
            //                    {
            //                        sReg = @"\d{5}.\d{3}\.\d{2}";
            //                        re=new Regex(sReg);
            //                        if(re.IsMatch(sText))
            //                        {
            //                            string[] sCodes=sText.Split('.');
            //                            sText = sCodes[0]+"."+sCodes[0]+"."+sCodes[1]+"."+sCodes[2];
            //                        }
            //                    }

            //                    sReg = @"\d{5}.\d{5}.\d{3}\.\d{2}";
            re = new Regex(sReg);
            bool checksText = CheckIsItem(sText, true);//Call procedure dbo.spGetItemByCode
            sText = txtOldNumbers.Text;

            if (re.IsMatch(sText) && checksText && lbxOldNumbers.Items.IndexOf(sText) < 0)
            {
                if ((CurrentNumberItems + SavedItems) < AllNumberItems)
                {
                    lbxOldNumbers.Items.AddRange(new object[] { sText });
                    lbxOldNumbers.SelectedIndex = lbxOldNumbers.Items.Count - 1;

                    txtOldNumbers.Text = "";
                    SetNumberOfItems();
                    btnSort.Enabled = true;
                    btnDeleteNumber.Enabled = true;

                    if (CurrentNumberItems + SavedItems == AllNumberItems)
                        SortNumbers();//Call procedure dbo.spGetNewCustomerProgramInstanceByBatchCode
                }
                else
                {
                    stsBarPnlMessages.Text = "All number are entered";
                    //statusBar1.Text = "All number are Entered";
                    txtOldNumbers.Text = "";
                }

            }
            else
            {
                if (lbxOldNumbers.Items.IndexOf(sText) > -1)
                {
                    stsBarPnlMessages.Text = "Number is duplicated";
                    //statusBar1.Text="Number is duplicated";
                }
                txtOldNumbers.Text = "Order#.Batch#.Item#";
                txtOldNumbers.SelectAll();
            }
            return checksText;
        }

        private void btnSort_Click(object sender, System.EventArgs e)
        {
            SortNumbers();
            /*statusBar1.Text="Sorting";
            this.Cursor=Cursors.WaitCursor;
            ArrayList al=CheckForDoubleNumbers(new ArrayList(lbxOldNumbers.Items));	
            al.Sort();
            Clear();
            BatchAddOldItems(al);
            pnlButtons.Enabled=true;
            statusBar1.Text="";
            this.Cursor=Cursors.Default;*/
        }

        private void SortNumbers()
        {
            stsBarPnlMessages.Text = "Sorting";
            //statusBar1.Text="Sorting";
            this.Cursor = Cursors.WaitCursor;
            ArrayList al = CheckForDoubleNumbers(new ArrayList(lbxOldNumbers.Items));
            al.Sort();
            Clear();
            BatchAddOldItems(al, false);
            pnlButtons.Enabled = true;
            stsBarPnlMessages.Text = "";
            //statusBar1.Text="";
            this.Cursor = Cursors.Default;
        }

        private bool CheckIsItem(string OldNumber, bool bShowMsg)
        {
            string sGroupCode = "";
            string sBatchCode = "";
            string sItemCode = "";
            bool result = false;
            if (OldNumber != "")
            {
                sGroupCode = OldNumber.Split('.')[1];
                sBatchCode = OldNumber.Split('.')[2];
                sItemCode = OldNumber.Split('.')[3];
            }
            if (sGroupCode != "" && sBatchCode != "" && sItemCode != "")
            {
                DataTable dt = Service.GetCurrentItemByCode(sGroupCode, sBatchCode, sItemCode, "1");//Procedure dbo.spGetItemByCode
                if (dt.Rows.Count > 0)
                {
                    string sPrevCode = OldNumber;
                    if (dt.Rows[0]["PrevOrderCode"] != DBNull.Value &&
                        dt.Rows[0]["PrevGroupCode"] != DBNull.Value &&
                        dt.Rows[0]["PrevBatchCode"] != DBNull.Value &&
                        dt.Rows[0]["PrevItemCode"]  != DBNull.Value)

                        sPrevCode = Service.FillToFiveChars(dt.Rows[0]["PrevOrderCode"].ToString()) + "." +
                                    Service.FillToFiveChars(dt.Rows[0]["PrevGroupCode"].ToString()) + "." +
                                    Service.FillToThreeChars(dt.Rows[0]["PrevBatchCode"].ToString()) + "." +
                                    Service.FillToTwoChars(dt.Rows[0]["PrevItemCode"].ToString());
                    if ((OldNumber != sPrevCode) && bShowMsg)
                    {
                        string msg = "Item Number is not First Previous Number.\r\nFirst # is: " + sPrevCode;
                        label1.Text = msg;
                        //MessageBox.Show(this,msg,"Old Item Number = " + sPrevCode + "" ,MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        txtOldNumbers.Text = sPrevCode;
                    }
                    else
                    {
                        txtOldNumbers.Text = OldNumber;
                        label1.Text = "";
                    }
                    result = true;
                }
            }
            return result;
        }

        private string CheckIsItemInTable(string OldNumber)
        {
            string sGroupCode = "";
            string sBatchCode = "";
            string sItemCode = "";
            string result = "";

            if (OldNumber != "")
            {
                sGroupCode = OldNumber.Split('.')[0];
                sBatchCode = OldNumber.Split('.')[1];
                sItemCode = OldNumber.Split('.')[2];
            }

            if (sGroupCode != "" && sBatchCode != "" && sItemCode != "")
            {
                DataTable dt = Service.GetCurrentItemByCode(sGroupCode, sBatchCode, sItemCode, "1");//Procedure dbo.spGetItemByCode
                if (dt.Rows.Count > 0)
                {
                    string sPrevCode = OldNumber;
                    if (dt.Rows[0]["PrevOrderCode"] != DBNull.Value &&
                        dt.Rows[0]["PrevBatchCode"] != DBNull.Value &&
                        dt.Rows[0]["PrevItemCode"] != DBNull.Value)

                        sPrevCode = Service.FillToFiveChars(dt.Rows[0]["PrevOrderCode"].ToString()) + "." +
                                    Service.FillToThreeChars(dt.Rows[0]["PrevBatchCode"].ToString()) + "." +
                                    Service.FillToTwoChars(dt.Rows[0]["PrevItemCode"].ToString());
                    if (OldNumber != sPrevCode)
                    {
                        result = sPrevCode;
                    }
                    else
                    {
                        result = OldNumber;
                    }
                }
            }
            return result.Trim();
        }

        private ArrayList CheckForDoubleNumbers(ArrayList list)
        {
            // Delete duplicating Item Numbers 
            Hashtable ht = new Hashtable();
            foreach (string OldNumber in list)
            {
                try { ht.Add(OldNumber, null); }
                catch { }
            }
            ArrayList result = new ArrayList();
            foreach (string OldNumber in ht.Keys)
            {
                result.Add(OldNumber);
            }
            return result;
        }
        private void Clear()
        {
            dsData.Tables["Batches"].Clear();
            dsData.Tables["Items"].Clear();
            dsData.Tables["NewBatches"].Clear();
            dsData.Tables["NewItems"].Clear();

            tvNewBatches.Nodes.Clear();
            lblError.Text = "";
            lbNotFoundPrevNumbers.Items.Clear();
            lblItemTypeName.Text = "";
            label1.Text = "";
            AddTableToDataSet();
            dgOldNumbersFromList.SetDataBinding(null, "");
        }
        #region MouseDown_MouseUp
        private void tvNewBatches_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            try
            {
                nodeFrom = null;
                TreeView tv = ((TreeView)sender);
                TreeNode tn = tvNewBatches.GetNodeAt(e.X, e.Y);//tvNewBatches.PointToClient(new Point(e.X,e.Y)));
                if (tn != null && tn.Parent != null)
                {
                    nodeFrom = tn;
                    this.Cursor = Cursors.Hand;
                }
                else
                {
                    nodeFrom = null;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }

        private void tvNewBatches_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            TreeNode to = tvNewBatches.GetNodeAt(e.X, e.Y);//tvNewBatches.PointToClient(new Point(e.X,e.Y)));
            TreeNode from = nodeFrom;
            if (CanDropNode(from, to))
            {
                CopyItemToOtherBatch(from, to);
            }
            nodeFrom = null;
            this.Cursor = Cursors.Default;
        }

        #endregion

        private void CopyItemToOtherBatch(TreeNode from, TreeNode to)
        {
            //Copy Item to New Batch if they have same Item Type
            if (from != null && to != null)
            {
                string sbIDFrom = GetbIDForNode(from);
                string sbIDTo = GetbIDForNode(to);
                string sPrevNumber = from.Text;
                string filter = "";
                DataRow[] dr = null;
                string sItemTypeIDFrom = "";
                string sItemTypeIDTo = "";

                filter = "bID = '" + sbIDFrom + "'";
                dr = dsData.Tables["Batches"].Select(filter);
                if (dr.Length > 0)
                    sItemTypeIDFrom = dr[0]["ItemTypeID"].ToString();

                filter = "bID = '" + sbIDTo + "'";
                dr = dsData.Tables["Batches"].Select(filter);
                if (dr.Length > 0)
                    sItemTypeIDTo = dr[0]["ItemTypeID"].ToString();
                if (sItemTypeIDFrom == sItemTypeIDTo)
                {
                    string mess = "Move Item " + sPrevNumber + " From Batch " + sbIDFrom + "  To Batch " + sbIDTo + "?";
                    DialogResult result;

                    result = MessageBox.Show(this, mess, "Moving Item to other Batch", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        filter = "bID = '" + sbIDFrom + "' and prevN = '" + sPrevNumber + "'";
                        DataRow[] drItems = dsData.Tables["Items"].Select(filter);
                        foreach (DataRow drItem in drItems)
                        {
                            drItem["bID"] = sbIDTo;
                        }
                        ReindexItems(sbIDTo);
                        ReindexItems(sbIDFrom);
                        tvNewBatches.BeginUpdate();
                        tvNewBatches.Nodes.Clear();
                        FillBatchTree();
                        tvNewBatches.EndUpdate();
                    }
                }
                else
                {
                    string Message = "Batch " + sbIDFrom + " and " + sbIDTo + " have different Item Type. ";
                    MessageBox.Show(this, Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CopyItemToOtherBatch()
        {
            if (nodeFrom != null && nodeTo != null)
            {
                string sbIDFrom = GetbIDForNode(nodeFrom);
                string sbIDTo = GetbIDForNode(nodeTo);
                string sPrevNumber = nodeFrom.Text;
                string filter = "";
                DataRow[] dr = null;
                string sItemTypeIDFrom = "";
                string sItemTypeIDTo = "";

                filter = "bID = '" + sbIDFrom + "'";
                dr = dsData.Tables["Batches"].Select(filter);
                if (dr.Length > 0)
                    sItemTypeIDFrom = dr[0]["ItemTypeID"].ToString();

                filter = "bID = '" + sbIDTo + "'";
                dr = dsData.Tables["Batches"].Select(filter);
                if (dr.Length > 0)
                    sItemTypeIDTo = dr[0]["ItemTypeID"].ToString();
                if (sItemTypeIDFrom == sItemTypeIDTo)
                {
                    string mess = "Move Item " + sPrevNumber + " From Batch " + sbIDFrom + "  To Batch " + sbIDTo;
                    DialogResult result;

                    result = MessageBox.Show(this, mess, "", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        filter = "bID = '" + sbIDFrom + "' and prevN = '" + sPrevNumber + "'";
                        DataRow[] drItems = dsData.Tables["Items"].Select(filter);
                        foreach (DataRow drItem in drItems)
                        {
                            drItem["bID"] = sbIDTo;
                        }
                        ReindexItems(sbIDTo);
                        ReindexItems(sbIDFrom);
                        tvNewBatches.BeginUpdate();
                        tvNewBatches.Nodes.Clear();
                        FillBatchTree();
                        tvNewBatches.EndUpdate();
                    }
                }
                else
                    MessageBox.Show("Items have different Item Type");
            }
        }

        private void ReindexItems(string bID)
        {
            //reindex Item ID in DataSet after copy Item or delete new Batch
            int index = 1;
            string filter = "bID = '" + bID + "'";
            string sortOrder = "prevN";
            DataRow[] drItems = dsData.Tables["Items"].Select(filter, sortOrder);
            foreach (DataRow drItem in drItems)
            {
                string siID = Service.FillToTwoChars(index.ToString());
                drItem["iID"] = siID;
                index++;
            }
        }

        private void btnSeparateBatch_Click(object sender, System.EventArgs e)
        {
            // Check for selected Batch is Old Batch and call AddNewBatch
            btnSeparateBatch.Enabled = false;
            string sbID = "";
            if (nodeSelectedBatch != null)
            {
                sbID = GetbIDForNode(nodeSelectedBatch);
                nodeSelectedBatch = null;
            }
            if (sbID != "")
            {
                string filter = "bID = '" + sbID + "'";
                DataRow[] drBatches = dsData.Tables["Batches"].Select(filter);

                if (drBatches.Length > 0)
                {
                    string sCustomerID = dsData.Tables["EntryBatch"].Rows[0]["CustomerID"].ToString();
                    string sCustomerOfficeID = dsData.Tables["EntryBatch"].Rows[0]["CustomerOfficeID"].ToString();
                    string sVendorID = dsData.Tables["EntryBatch"].Rows[0]["VendorID"].ToString();
                    string sVendorOfficeID = dsData.Tables["EntryBatch"].Rows[0]["VendorOfficeID"].ToString();
                    ////////					string sCustomerID = drBatches[0]["CustomerID"].ToString();
                    ////////					string sCustomerOfficeID = 	drBatches[0]["CustomerOfficeID"].ToString();
                    ////////					string sVendorID = drBatches[0]["VendorID"].ToString();
                    ////////					string sVendorOfficeID = drBatches[0]["VendorOfficeID"].ToString();
                    string sItemTypeID = drBatches[0]["ItemTypeID"].ToString();
                    string sCPID = drBatches[0]["CPID"].ToString();
                    CPID = "";
                    if (SelectCP(sCustomerID, sCustomerOfficeID, sVendorID, sVendorOfficeID, sItemTypeID, sCPID) == DialogResult.Yes)
                    {
                        string IsNewBatch = drBatches[0]["IsNewBatch"].ToString();
                        if (IsNewBatch == "")
                        {
                            AddNewBatch(sbID);
                            tvNewBatches.BeginUpdate();
                            tvNewBatches.Nodes.Clear();
                            FillBatchTree();
                            tvNewBatches.EndUpdate();
                        }
                    }
                }
            }
            //btnSeparateBatch.Enabled = true;
        }

        private void tvNewBatches_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            //System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldNumbersForm));
            //Save selected Node in global variable. Show picture for selected Batch
            nodeSelectedBatch = e.Node;
            btnSeparateBatch.Enabled = true;
            string bID = GetbIDForNode(e.Node);
            string filter = "bID = '" + bID + "'";
            DataRow[] dr = dsData.Tables["Batches"].Select(filter);
            if (dr.Length > 0)
            {
                lblItemTypeName.Text = dr[0]["ItemTypeName"].ToString();
                try
                {
                    if (dr[0]["Image_path2picture"] is DBNull)
                    {
                        picbox.Image = null;
                        //((System.Drawing.Image)(resources.GetObject("picbox.Image")));
                    }
                    else
                    {
                        Image img = (Image)Service.ExtractImageFromString(dr[0]["Image_path2picture"].ToString(), dr[0]["Path2Picture"].ToString());
                        Service.DrawAdjustShapeImage(picbox, img, -1, -1, 0, 0);
                    }
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                }
            }
        }
        private string GetbIDForNode(TreeNode node)
        {
            //return Batch ID(ID in DataSet) for selected batch or item
            string result = "";
            string s = "";
            if (node.Parent != null)
                s = node.Parent.Text;
            else
                s = node.Text;
            result = s.Substring(6, 3);
            return result;

        }

        private void btnDeleteBatch_Click(object sender, System.EventArgs e)
        {
            //Delete only new batch. Items from this batch move to their old batches
            //			string Message = "Remove Batch " + GetbIDForNode(nodeSelectedBatch) + "?";
            //				DialogResult result =	MessageBox.Show(this,Message,"Removing Batch",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            TreeNode tn = nodeSelectedBatch;
            string sbID = GetbIDForNode(nodeSelectedBatch);
            string filter = "bID = '" + sbID + "'";
            DataRow[] drBatches = dsData.Tables["Batches"].Select(filter);
            if (drBatches.Length > 0)
            {
                string IsNewBatch = drBatches[0]["IsNewBatch"].ToString();
                if (IsNewBatch == "1")
                {
                    string Message = "Remove Batch " + GetbIDForNode(nodeSelectedBatch) + "?";
                    DialogResult result = MessageBox.Show(this, Message, "Removing Batch", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        DataRow[] drItems = dsData.Tables["Items"].Select(filter);
                        foreach (DataRow drItem in drItems)
                        {
                            drItem["bID"] = drItem["FirstbID"];
                        }
                        drBatches[0].Delete();
                        ReindexNewBatches();
                        ReindexItems(sbID);
                        tvNewBatches.BeginUpdate();
                        tvNewBatches.Nodes.Clear();
                        FillBatchTree();
                        tvNewBatches.EndUpdate();
                        return;
                    }
                }
            }
            string message = "You can`t remove Batch " + GetbIDForNode(nodeSelectedBatch) + ".";
            MessageBox.Show(this, message, "Removing Batch", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void ReindexNewBatches()
        {
            string filter = "IsNewBatch = '' or IsNewBatch Is Null";
            DataRow[] drOldBatches = dsData.Tables["Batches"].Select(filter);
            int OldBatchesCount = drOldBatches.Length + 1;
            filter = "IsNewBatch = '1'";
            DataRow[] drNewBatches = dsData.Tables["Batches"].Select(filter);
            foreach (DataRow drNewBatch in drNewBatches)
            {
                string sbId = drNewBatch["bID"].ToString();
                string sNewbId = Service.FillToThreeChars(OldBatchesCount.ToString());
                filter = "bId = '" + sbId + "'";
                DataRow[] drItems = dsData.Tables["Items"].Select(filter);
                foreach (DataRow drItem in drItems)
                {
                    drItem["bID"] = sNewbId;
                }
                drNewBatch["bID"] = sNewbId;
                OldBatchesCount++;
            }

        }
        private void GetMemoNumbers()
        {
            //Get MemoNumbers from DB for this Order
            //			dsMemoNumbers = Service.GetGroupMemoNumbers(EntryBatch.Split('_')[1]);//Procedure dbo.spGetGroupMemoNumber
            //																
            //			dsMemoNumbers.Tables[0].TableName = "MemoNumbers";
            if (dsMemoNumbers.Tables.Count == 1)
            {
                DataRow drNone = dsMemoNumbers.Tables[0].NewRow();
                drNone["MemoNumberID"] = System.DBNull.Value;

                cbMemoNumber.DataSource = dsMemoNumbers.Tables[0];
                cbMemoNumber.DisplayMember = "Name";
                cbMemoNumber.ValueMember = "MemoNumberID";
                SetSingleMemoIndex();
            }
            //			DataRow drNone = dsMemoNumbers.Tables[0].NewRow();
            //			drNone["MemoNumberID"] = System.DBNull.Value;
            //			drNone["Name"] = "[none]";
            //			dsMemoNumbers.Tables[0].Rows.InsertAt(drNone, 0);
            //				
            //			cbMemoNumber.DataSource = dsMemoNumbers;
            //			cbMemoNumber.DisplayMember = "MemoNumbers.Name";
            //			cbMemoNumber.ValueMember = "MemoNumbers.MemoNumberID";	
            //			SetSingleMemoIndex();
            //cbMemoNumber.SelectedIndex = 0;
        }

        private void btnDone_Click(object sender, System.EventArgs e)
        {
			RenameFiles();
			alFiles.Clear();
			//alItems.Clear();
			Hashtable htBatchID = new Hashtable();
            this.Cursor = Cursors.WaitCursor;
            stsBarPnlMessages.Text = "Saving Data";
            //statusBar1.Text="Saving Data";
            SetFormDone();
            ArrayList alAllNewNumbers = new ArrayList();
            //	DataTable new DataTable
            foreach (DataRow drBatch in dsData.Tables["Batches"].Rows)
            {
                //Save Data in DB
                //Check for less 25 Items in one Batch
                string sbID = drBatch["bID"].ToString();
                string filter = "bID = '" + sbID + "'";
                DataRow[] drItems = dsData.Tables["Items"].Select(filter);
                int iItemsInBatch = 25;
                DataTable dt = new DataTable();
                ArrayList al = new ArrayList();
                if (drItems.Length > 0)
                {
                    if (drItems.Length > iItemsInBatch)
                    {
                        int count = 0;
                        foreach (DataRow drItem in drItems)
                        {
                            if (count < iItemsInBatch)
                            {
                                al.Add(drItem);
                            }
                            else
                            {
                                DataRow[] dr = (DataRow[])al.ToArray(typeof(DataRow));
                                ArrayList alBatchNewNumbers = CreateNewBatch(dr, drBatch);
                                alAllNewNumbers.AddRange(alBatchNewNumbers);
                                count = 0;
                                al.Clear();
                                al.Add(drItem);
                            }
                            count++;
                        }
                        if (al.Count > 0)
                        {
                            DataRow[] dr = (DataRow[])al.ToArray(typeof(DataRow));
                            ArrayList alBatchNewNumbers = CreateNewBatch(dr, drBatch);
                            alAllNewNumbers.AddRange(alBatchNewNumbers);
                            al.Clear();
                        }
                    }
                    else
                    {
                        ArrayList alBatchNewNumbers = CreateNewBatch(drItems, drBatch);
                        alAllNewNumbers.AddRange(alBatchNewNumbers);
                    }
                }
            }
            if (alAllNewNumbers.Count == 0) return;
            foreach (string s in alAllNewNumbers)
            {
                string[] sNumbers = s.Split(';');
                string sOldNumber = sNumbers[0];
                string sBatchID = sNumbers[1];
                string sNewNumber = sNumbers[2];
                string sItemCode = sNewNumber.Split('.')[3];
                dsData.Tables["NewItems"].Rows.Add(new object[] { sBatchID, sItemCode });
                try
                { htBatchID.Add(sBatchID, null); }
                catch { }
                string filter = "prevN = '" + sOldNumber + "'";
                DataRow[] drItems = dsData.Tables["Items"].Select(filter);
                foreach (DataRow drItem in drItems)
                {
                    drItem["NewNumber"] = sNewNumber;
                }
            }
            foreach (string batchId in htBatchID.Keys)
            {
                dsData.Tables["NewBatches"].Rows.Add(new object[] { batchId });
            }
            tvNewBatches.BeginUpdate();
            tvNewBatches.Nodes.Clear();
            FillBatchTree();
            tvNewBatches.EndUpdate();
            this.Cursor = Cursors.Default;
            stsBarPnlMessages.Text = "";
            //statusBar1.Text="";
            stsBarPnlSIN.Text = SavedItems.ToString();
            //CurrentNumberItems = 0;
            //lblSavedItems.Text = SavedItems.ToString();
            //SavedItems=CurrentNumberItems;
            #region BatchTracking

            if (dsData.Tables["NewBatches"].Rows.Count > 0)
            {
                if (dsData.Tables["NewItems"].Rows.Count > 0)
                {
                    foreach (DataRow dr in dsData.Tables["NewBatches"].Rows)
                    {
                        DataRow[] drItems = dsData.Tables["NewItems"].Select("BatchID = '" + dr["BatchID"].ToString() + "'");
                        if (drItems.Length > 0)
                        {
                            object BatchID = dr["BatchID"];
                            object EventID = GraderLib.BatchEvents.CreatedFromOldNumbers;
                            object ItemsAffected = drItems.Length;
                            object ItemsInBatch = drItems.Length;
                            object FormID = GraderLib.Codes.Itemizing;
                            Service.SetBatchEvent(EventID, BatchID, FormID, ItemsAffected, ItemsInBatch);
                        }
                    }
                }
            }

            #endregion

            DialogResult res = MessageBox.Show(this, "Print Labels?", "Printing labels", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
                PrintBatches();
            if (SavedItems == AllNumberItems)
            {
                SetFormDone();
                btnStart.Enabled = false;
            }
            CheckInspectedItemsNumber();
            rbSelectRealItem.Checked = true;
        }

        private void CheckInspectedItemsNumber()
        {
            //			DataTable dtItemsList = new DataTable();
            //			dtItemsList = Service.GetItemByCode(sOrderCode, null, null);
            try
            {
                DataTable dtOrder = new DataTable();
                dtOrder = Service.GetOrderByOrderCode(sOrderCode);

                int iItemsInOrder = 0;
                int iInspectedItems = 0;
                int iItemsQuantity = 0;

                //			if(dtItemsList.Rows.Count > 0) 
                //			{
                //				iItemsInOrder = dtItemsList.Rows.Count;
                //				dtOrder.Rows[0]["ItemsQuantity"] = iItemsInOrder;
                //			}

                if (dtOrder.Rows.Count > 0)
                {
                    iInspectedItems = Convert.ToInt32(dtOrder.Rows[0]["InspectedQuantity"].ToString());
                    iItemsQuantity = Convert.ToInt32(dtOrder.Rows[0]["ItemsQuantity"].ToString());

                    if (iInspectedItems < iItemsQuantity)
                    {
                        dtOrder.Rows[0]["InspectedQuantity"] = Convert.ChangeType(iItemsQuantity, dtOrder.Columns["InspectedQuantity"].DataType);
                        dtOrder.Columns["InspectedQuantity"].ColumnName = "IQInspected";
                        dtOrder.Columns["InspectedTotalWeight"].ColumnName = "TWInspected";
                        dtOrder.Columns["InspectedWeightUnitID"].ColumnName = "TWInspectedMeasureUnitId";
                        Service.Itemizn1_EntryBatchUpdate(dtOrder);
                    }
                }
            }
            catch { }
        }

        private void txtOldNumbers_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            stsBarPnlMessages.Text = "";
            //statusBar1.Text = "";
            if (e.KeyCode == Keys.Enter)
            {
                label1.Text = "";
                //btnStart_Click(this, System.EventArgs.Empty);
                CheckEnteredCode();
            }

        }

        private void txtOldNumbers_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (((c >= '0' && c <= '9') || c == '.' || c == 8 || c == 13) && (sender as TextBox).Text.Length < 18)
            {
                e.Handled = false;
            }
            else
            {
                if (((sender as TextBox).Text.Length == 18) && c != 13 &&
                    ((c >= '0' && c <= '9') || c == '.' || c == 8) && (sender as TextBox).Text == "#####.#####.###.##")
                {
                    (sender as TextBox).Text = "";
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }
        private void SetFormDone()
        {
            bStart = false;
            pnlNumbers.Enabled = false;
            btnSort.Enabled = false;
            btnDeleteNumber.Enabled = false;
            pnlButtons.Enabled = false;
            //rbSelectRealItem.Checked = true;
        }

        private void btnStart_Click(object sender, System.EventArgs e)
        {
            //			if(cbMemoNumber.Text == "[none]")
            //			{
            //                if(MessageBox.Show("Memo info is missing.\r\nIs it OK to itemize this batch?",
            //                    "Missing Memo info", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) == DialogResult.No)	
            //                {
            //                    return;
            //                }
            //                else
            //                {
            //                    if (rbSelectReportItem.Checked) cbMemoNumber.Text = "(P)";                   
            //                }
            //			}

            if (CurrentNumberItems < AllNumberItems)
            {
                picbox.Image = null;
                bStart = true;
                pnlNumbers.Enabled = true;
                Clear();
                lbxOldNumbers.Items.Clear();
                SetNumberOfItems();
                stsBarPnlMessages.Text = "Select Memo Number and enter Old Item Number";
                //statusBar1.Text="Select Memo Number and enter Old Item Number";
            }
        }

        private void cbMemoNumber_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            stsBarPnlMessages.Text = "";
            //statusBar1.Text="";
        }

        private void picbox_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (picbox.Image == null) return;
            if (picbox.Image.Size.Height > picbox.Size.Height || picbox.Image.Size.Width > picbox.Size.Width)
            {
                picbox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                picbox.SizeMode = PictureBoxSizeMode.CenterImage;
            }
        }
        private void PrintBatchesThread()
        {
            for (; ; )
            {
                if (PrintingThread == null || !PrintingThread.IsAlive)
                {
                    PrintingThread = new Thread(new ThreadStart(PrintBatches));
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
                    break;
            }
        }
        private void PrintBatches()
        {
            ArrayList outList = new ArrayList();
            string sReportKind = Service.GetReportKind();
            string sCRTemplatePath = Service.GetCRTemplatePath();
            CrystalReport.CrystalReport crReport_Batch = null;
            if (sReportKind != "crystal")
            {
                crReport_Batch = new CrystalReport.CrystalReport(sCRTemplatePath, true);
            }
            foreach (DataRow drBatchID in dsData.Tables["NewBatches"].Rows)
            {
                string sBatchID = drBatchID["BatchID"].ToString();
                string filter = "BatchID = '" + sBatchID + "'";
                outList.Clear();
                outList.Add(sBatchID);
                DataRow[] drItemCodes = dsData.Tables["NewItems"].Select(filter);
                foreach (DataRow drItemCode in drItemCodes)
                {
                    outList.Add(sBatchID + "_" + drItemCode["ItemCode"].ToString());
                }
                if (outList.Count > 1)
                {
                    Print(outList, crReport_Batch);
                }
            }
            crReport_Batch.CloseExcel();
            crReport_Batch = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private void Print(ArrayList outList, CrystalReport.CrystalReport crReport)
        {
            string sCRTemplatePath = Service.GetCRTemplatePath();
            string sReportKind = Service.GetReportKind();
            CrystalReport.CrystalReport crReport_Batch = crReport;// = new CrystalReport.CrystalReport(sCRTemplatePath);
            CrystalReport.CrystalReport crReport_Label = null;
            if (sReportKind == "crystal")
            {
                crReport_Batch = new CrystalReport.CrystalReport(sCRTemplatePath);
                crReport_Batch.Label_Batch(outList[0].ToString());
                crReport_Batch.Print();
            }
            else
            {
                if (crReport_Batch == null)
                    crReport_Batch = new CrystalReport.CrystalReport(sCRTemplatePath, true);
                try
                {
                    crReport_Batch.Excel_Label_Batch(outList[0].ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Print error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                /*crReport_Batch.CloseExcel();
                crReport_Batch = null;*/

            }
            if (sReportKind != "crystal")
            {
                if (crReport_Batch != null)
                    crReport_Label = crReport_Batch;
                else
                    crReport_Label = new CrystalReport.CrystalReport(sCRTemplatePath, true);
            }
            for (int i = 1; i < outList.Count; i++)
            {
                //crReport_Label = new CrystalReport.CrystalReport(sCRTemplatePath);
                if (sReportKind == "crystal")
                {
                    crReport_Label = new CrystalReport.CrystalReport(sCRTemplatePath);
                    crReport_Label.Label_Item(outList[i].ToString());
                    crReport_Label.Print();
                }
                else
                {
                    try
                    {
                        crReport_Label.Excel_Label_Item(outList[0].ToString() + "_0");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, ex.Message, "Print error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                }
            }
            Client.MyActivePrinter = "";
            Client.MyActiveReportName = "";
            /* new part */
            if (crReport_Label != null)
                crReport_Label.CloseExcel();
            crReport_Label = null;

            if (crReport_Batch != null)
                crReport_Batch.CloseExcel();
            crReport_Batch = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            /*	crReport_Label.CloseExcel();
                crReport_Label = null;
                crReport_Batch.CloseExcel();
                crReport_Batch = null;
                GC.Collect();
                GC.WaitForPendingFinalizers(); 
                GC.Collect();*/
        }

        private void txtOldNumbers_MouseEnter(object sender, System.EventArgs e)
        {
            txtOldNumbers.Text = "";
        }

        private void OldNumbersForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (SavedItems < AllNumberItems)
            {
                e.Cancel = true;
                //				if(MessageBox.Show(this,"Not all number are entered. Would you like to close form?","Closing window",MessageBoxButtons.YesNo,MessageBoxIcon.Error) == DialogResult.Yes)
                //				{
                //					e.Cancel = false;
                //				}
                //				else e.Cancel = true;

                if (MessageBox.Show(this, "Not all number are entered. Would you like to close form?", "Closing window", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void OldNumbersForm_Closed(object sender, System.EventArgs e)
        {
            int iItemsItemized = Convert.ToInt32(((Itemizn1Form)Owner).lbItemsItemized.Text) + SavedItems;
            //((Itemizn1Form)Owner).tbItemsInGroup.Text = "0";
            //tbItemsInspected.Text
            //((Itemizn1Form)Owner).tbItemsInspected.Text = "";
            ((Itemizn1Form)Owner).lbItemsItemized.Text = iItemsItemized.ToString();
            ((Itemizn1Form)Owner).bcItem.Text = sOrderCode;
            //////////			((Itemizn1Form)Owner).Initialize();
            //////////			((Itemizn1Form)Owner).bcfItem.Text = sOrderCode;
            //////////			((Itemizn1Form)Owner).LoadOrderData();

            //((Itemizn1Form)Owner).SetCanClose = true;
            //Dispose();		
        }
        private DialogResult SelectCP(string CustomerID, string CustomerOfficeID, string VendorID, string VendorOfficeID, string ItemTypeID, string oldCPID)
        {
            FormSelectCustomerProgram frm = new FormSelectCustomerProgram(CustomerID, CustomerOfficeID, VendorID, VendorOfficeID, ItemTypeID, oldCPID);
            frm.ShowDialog(this);
            if (frm.DialogResult == DialogResult.Yes)
            {
                frm.Close();
                frm.Dispose();
                return DialogResult.Yes;
            }
            else
            {
                frm.Close();
                frm.Dispose();
                return DialogResult.No;
            }
        }
        private void DeleteNumber()
        {
            string Message = "Remove Number " + lbxOldNumbers.SelectedItem.ToString() + "?";
            DialogResult result = MessageBox.Show(this, Message, "Removing Number", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                lbxOldNumbers.Items.RemoveAt(lbxOldNumbers.SelectedIndex);
                SetNumberOfItems();
                Clear();
                btnDeleteNumber.Enabled = false;
                pnlButtons.Enabled = false;
            }

        }
        private void menuItemDeleteNumber_Click(object sender, System.EventArgs e)
        {
            if (lbxOldNumbers.SelectedIndex != -1)
                DeleteNumber();
            else
                MessageBox.Show(this, "You have to select Item Number.", "Removing Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnDeleteNumber_Click(object sender, System.EventArgs e)
        {
            if (lbxOldNumbers.SelectedIndex != -1)
                DeleteNumber();
            else
                MessageBox.Show(this, "You have to select Item Number.", "Removing Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void tvNewBatches_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                TreeNode to = tvNewBatches.GetNodeAt(e.X, e.Y);//tvNewBatches.PointToClient(new Point(e.X,e.Y)));
                TreeNode from = nodeFrom;

                bool f = CanDropNode(from, to);
                if (f)
                    this.Cursor = Cursors.Cross;
                else
                    this.Cursor = Cursors.No;
            }
        }

        private void tvNewBatches_MouseHover(object sender, System.EventArgs e)
        {

        }

        private void tvNewBatches_MouseLeave(object sender, System.EventArgs e)
        {
            nodeFrom = null;
            this.Cursor = Cursors.Default;
        }
		private void CopyXmlToDataTable(ArrayList sFileNames)
		{
			//CrystalReport.CrystalReport crReport = null;
			picbox.Image = null;
			bStart = true;
			pnlNumbers.Enabled = true;
			Clear();
			lbxOldNumbers.Items.Clear();
			label5.Text = "";
			string sXMLFilePath = Client.GetOfficeDirPath("oldNumberXMLDir");
#if DEBUG
			sXMLFilePath = @"C:\dell\SendDir\OldNumbersXML\";
#endif
			string sXMLFileName = "";
			string sMessage = stsBarPnlMessages.Text;
			Hashtable ht = new Hashtable();  //LoadListFromExcel(string sExcelFile)
			try
			{
				foreach (string sFiles in sFileNames)
				{
					DataSet dsTemp = new DataSet();
					sXMLFileName = sXMLFilePath + sFiles;

					//if (sXMLFileName.ToLower().Contains(".xml")) dsTemp.ReadXml(sXMLFileName);
					//else
					//{
					//	crReport.GetDataFromExcel(sXMLFileName, ref dsTemp);
					//	//dsTemp.Tables.Add(LoadListFromExcel(sXMLFileName));

					//}
					dsTemp.ReadXml(sXMLFileName);
					stsBarPnlMessages.Text = "Loading file " + sFiles;
					//label5.Text = "Loading file\r\n" + sFiles;

					string sItemNumber = "";
					try
					{ 
					foreach (DataRow dr in dsTemp.Tables[0].Rows)
					{
						sItemNumber = dr[0].ToString();
						if (sItemNumber.Trim() == "") continue;
							sItemNumber = sItemNumber.Replace(".", "").Trim();
							long number1;
							bool canConvert = long.TryParse(sItemNumber, out number1);
							if (!canConvert) sItemNumber = sItemNumber.Substring(1, sItemNumber.Length);
						
							while (sItemNumber.Length < 11)
							{
								sItemNumber = "0" + sItemNumber;
							}
						
							string s = sItemNumber.Substring(0, 6) + "." +
										sItemNumber.Substring(6, 3) + "." +
										sItemNumber.Substring(9, 2);

							string[] sCodes = s.Split('.');

							//if (sItemNumber.Length == 12)
							//{
							try
							{
								ht.Add(sItemNumber, null);

								Object oOldNumber = sItemNumber;
								Object oPrevOrderCode = sCodes[0];
								Object oPrevBatchCode = sCodes[1];
								Object oPrevItemCode = sCodes[2];
								Object[] oNewRow = new object[] { oOldNumber, oPrevOrderCode, oPrevBatchCode, oPrevItemCode };
								dsOldNumbers.Tables[0].Rows.Add(oNewRow);
							}
								catch { }
							//}
						//}
					}
				}
				catch(Exception ex)
				{
					var error = ex.Message;
				}
				dsTemp.Dispose();
				dsTemp = null;
				}
			}
			catch (Exception ex)
			{
				var error = ex.Message;
			}
		
            stsBarPnlMessages.Text = sMessage;

            if (dsOldNumbers.Tables[0].Rows.Count > 0)
            {
                //DataView myView = new DataView(dsOldNumbers.Tables[0]);
                //myView.AllowNew = true;
                //myView.AllowEdit = false;
                //myView.AllowDelete = true;

                InitBatchDataGrid(dsOldNumbers.Tables[0].TableName, 1);
				dgOldNumbersFromList.SetDataBinding(dsOldNumbers, dsOldNumbers.Tables[0].TableName);
				//dgOldNumbersFromList.SetDataBinding(myView, "");

				dgOldNumbersFromList.Refresh();

                AllNumberItems = dsOldNumbers.Tables[0].Rows.Count;
                label5.Text = "Total items to add:\r\n" + AllNumberItems.ToString();
            }
            stsBarPnlEIN.Text = AllNumberItems.ToString();
        }

        private void btnLoadFile_Click(object sender, System.EventArgs e)
        {
            btnLoadFile.Enabled = false;
            string sXMLFileName = cbXMLFileList.SelectedItem.ToString();
            alFiles.Clear();
            alFiles.Add(sXMLFileName);
            CopyXmlToDataTable(alFiles);
            btnLoadFile.Enabled = true;
            btnStartFromList.Enabled = true;

        }
        private void ClearDataSet(DataSet dsMydataSet)
        {
            while (dsMydataSet.Tables.Count > 0)
            {
                DataTable table = dsOldNumbers.Tables[0];
                if (dsMydataSet.Tables.CanRemove(table))
                {
                    dsMydataSet.Tables.Remove(table);
                }
            }

        }

        private void AddTableToDataSet()
        {
            ClearDataSet(dsOldNumbers);

            DataTable dtDataFromXML = new DataTable("Items");
            DataTable dtItemDataType = new DataTable();
            dtItemDataType = Service.GetOldItemByCodeTypeEx();

            dtDataFromXML.Columns.Add("ITEM");
            dtDataFromXML.Columns.Add("OrderCode", dtItemDataType.Columns["OrderCode"].DataType);
            dtDataFromXML.Columns.Add("BatchCode", dtItemDataType.Columns["BatchCode"].DataType);
            dtDataFromXML.Columns.Add("ItemCode", dtItemDataType.Columns["ItemCode"].DataType);

            dsOldNumbers.Tables.Add(dtDataFromXML);
            dsOldNumbers.Tables[0].RowDeleted += new System.Data.DataRowChangeEventHandler(OldItemListTable_Deleted);
        }

        private void InitBatchDataGrid(string mappingName, int iMode)
        {
            string[] columnNames; //= new string[];
            if (iMode == 1)
            {
                columnNames = new string[] 
					{
						"ITEM", "OrderCode", "BatchCode", "ItemCode" 
					};
            }
            else
            {
                columnNames = new string[] 
					{
						"ITEM", "PrevOrderCode", "PrevBatchCode", "PrevItemCode" 
					};
            }
            string[] headerText = new string[] 
					{
						"Old  Numbers", "", "", ""
					};

            int[] columnWidth = new int[]
					{
						100, 0, 0, 0
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
            dgOldNumbersFromList.TableStyles.Clear();
            dgOldNumbersFromList.TableStyles.Add(tableStyle);
        }

        private void OldItemListTable_Deleted(object sender, System.Data.DataRowChangeEventArgs e)
        {
            dsOldNumbers.Tables[0].AcceptChanges();
            AllNumberItems = dsOldNumbers.Tables[0].Rows.Count;
            label5.Text = "Total items to add:\r\n" + AllNumberItems.ToString();
            stsBarPnlEIN.Text = AllNumberItems.ToString();
        }

        private void btnStartFromList_Click(object sender, System.EventArgs e)
        {
            btnStartFromList.Enabled = false;
            ArrayList alItems = new ArrayList();
            try
            {
                DataSet dsGetOldNumbers = new DataSet();
                DataTable dtOldNumbers = new DataTable("ItemByCodeFromList");
                dtOldNumbers.Columns.Add("ItemsList", typeof(System.String));
                DataRow newRow;
                newRow = dtOldNumbers.NewRow();
                newRow[0] = dsOldNumbers.GetXml();
                dtOldNumbers.Rows.Add(newRow);
                dsGetOldNumbers.Tables.Add(dtOldNumbers);
                DataSet dsItemsOut = Service.ProxyGenericGet(dsGetOldNumbers); //Procedure "dbo.spGetItemByCodeFromList"
                lbNotFoundPrevNumbers.Items.Clear();
                if (dsItemsOut.Tables.Count > 0)
                {
                    if (dsItemsOut.Tables[1].Rows.Count > 0)
                    {
                        foreach (DataRow dr in dsItemsOut.Tables[1].Rows)
                            lbNotFoundPrevNumbers.Items.Add(dr[0].ToString());
                    }

                    if (dsItemsOut.Tables[0].Rows.Count > 0)
                    {
                        ClearDataSet(dsOldNumbers);
                        dgOldNumbersFromList.SetDataBinding(null, "");
                        dgOldNumbersFromList.Refresh();
                        dsOldNumbers.Tables.Add(dsItemsOut.Tables[0].Copy());
                        InitBatchDataGrid(dsOldNumbers.Tables[0].TableName, 2);
                        dgOldNumbersFromList.SetDataBinding(dsOldNumbers.Tables[0], "");

                        AllNumberItems = dsItemsOut.Tables[0].Rows.Count;

                        foreach (DataRow dr in dsOldNumbers.Tables[0].Rows)
                        {
                            alItems.Add(dr[0].ToString());
                        }
                        BatchAddOldItems(alItems, true);
                        //RenameFiles();
                        //alFiles.Clear();
                        alItems.Clear();
                    }
                }
            }
            catch { }
            dgOldNumbersFromList.SetDataBinding(null, "");
            dgOldNumbersFromList.Refresh();
            btnStartFromList.Enabled = true;
            pnlButtons.Enabled = true;
            stsBarPnlMessages.Text = "";
            //statusBar1.Text="";
            this.Cursor = Cursors.Default;
            stsBarPnlEIN.Text = AllNumberItems.ToString();
        }

        private void RenameFiles()
        {
            string sXMLFilePath = Client.GetOfficeDirPath("oldNumberXMLDir");
#if DEBUG
			sXMLFilePath = @"C:\dell\SendDir\OldNumbersXML\";
#endif
			string sNewFile = ".done";
            if (alFiles.Count > 0)
            {
                foreach (string sFiles in alFiles)
                {
                    if (File.Exists(sXMLFilePath + sFiles))
                    {
                        File.Copy(sXMLFilePath + sFiles, sXMLFilePath + sFiles + sNewFile, true);
                        File.Delete(sXMLFilePath + sFiles);
                    }
                }
                GetFileList();
            }
        }

        private void txtOldNumbers_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void btnLoadAllFiles_Click(object sender, System.EventArgs e)
        {
            btnLoadAllFiles.Enabled = false;
            alFiles.Clear();

            foreach (string sFileNames in cbXMLFileList.Items)
            {
                alFiles.Add(sFileNames);
            }

            CopyXmlToDataTable(alFiles);
            btnLoadAllFiles.Enabled = true;
            btnStartFromList.Enabled = true;

        }

        private void btnClearDataGrid_Click(object sender, System.EventArgs e)
        {
            dgOldNumbersFromList.SetDataBinding(null, "");
            label5.Text = "";
        }

        //private void OldNumbersForm_Load(object sender, System.EventArgs e)
        //{

        //}
        private void SetSingleMemoIndex()
        {
            try
            {
                if (dsMemoNumbers.Tables["MemoNumbers"].Rows.Count == 2)
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

		//private DataTable LoadListFromExcel(string sExcelFile)
		//{
		//	DataTable dtExcelData = new DataTable();
		//	dtExcelData.Columns.Add("ITEM");
		//	Excel.Workbook BookData = null;
		//	try
		//	{
		//		Client.KillOpenExcel();
		//		objExcel = new Excel.Application();
				
		//		BookData = objExcel.Workbooks.Open(sExcelFile, Type.Missing, true, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

		//		Excel.Worksheet SheetData = (Excel.Worksheet)BookData.Sheets[0];
		//		Excel.Range crCell = SheetData.get_Range("a1", "a10000");
				
		//		for (int i = 1; i < 10000; i++)
		//		{

		//			var item = Convert.ToString(SheetData.get_Range("a" + i.ToString(), Type.Missing).Value2);
		//			var nextItem = Convert.ToString(SheetData.get_Range("a" + (i + 1).ToString(), Type.Missing).Value2);
		//			if (item.Trim() == "")
		//			{
		//				if (nextItem.Trim() != "") continue;
		//				else break;
		//			}
		//			DataRow row = dtExcelData.NewRow();
		//			row[0] = item;
		//			dtExcelData.Rows.Add(row);
		//		}

		//	}
		//	catch { return null; }
		//	try
		//	{ BookData.Close(false, sExcelFile, null); }
		//	catch { }

		//	return dtExcelData;
		//}

	}
}
