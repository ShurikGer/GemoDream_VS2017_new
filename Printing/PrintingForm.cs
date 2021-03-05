using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;


namespace gemoDream
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class PrintingForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.StatusBar sbStatus;
		private System.ComponentModel.IContainer components;
		private Cntrls.OrdersTree otDocs;
		private System.Windows.Forms.TextBox tbDocId;
		private System.Windows.Forms.Button btnView;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnPrint;
		private System.Windows.Forms.GroupBox gbEmail;
		private System.Windows.Forms.ComboBox cbFileType;
		private System.Windows.Forms.Label lFileType;
		private System.Windows.Forms.ComboBox cbEmail;
		private System.Windows.Forms.Button btnSend;
		private System.Windows.Forms.Timer timer;
		/// <summary>
		/// Developer's class members
		/// </summary>
		// access code
 		private int accessCode = -1;

		private const int DOC_ITEM_DISPLAY_CODE = 19;
		private static int[] DOC_ITEM_DISPLAY_CODE_FORMAT = {1,5,5,3,2};
		private static int DISPLAY_ITEM_DOT1 = DOC_ITEM_DISPLAY_CODE_FORMAT[0];
		private static int DISPLAY_ITEM_DOT2 = DOC_ITEM_DISPLAY_CODE_FORMAT[0]+DOC_ITEM_DISPLAY_CODE_FORMAT[1]+1;
		private static int DISPLAY_ITEM_DOT3 = DOC_ITEM_DISPLAY_CODE_FORMAT[0]+DOC_ITEM_DISPLAY_CODE_FORMAT[1]+DOC_ITEM_DISPLAY_CODE_FORMAT[2]+2;
		private static int DISPLAY_ITEM_DOT4 = DOC_ITEM_DISPLAY_CODE_FORMAT[0]+DOC_ITEM_DISPLAY_CODE_FORMAT[1]+DOC_ITEM_DISPLAY_CODE_FORMAT[2]+DOC_ITEM_DISPLAY_CODE_FORMAT[3]+3;
		private const int DOC_BATCH_DISPLAY_CODE = 16;
		private static int[] DOC_BATCH_DISPLAY_CODE_FORMAT = {1,5,5,3};
		private static int DISPLAY_BATCH_DOT1 = DOC_BATCH_DISPLAY_CODE_FORMAT[0];
		private static int DISPLAY_BATCH_DOT2 = DOC_BATCH_DISPLAY_CODE_FORMAT[0]+DOC_BATCH_DISPLAY_CODE_FORMAT[1]+1;
		private static int DISPLAY_BATCH_DOT3 = DOC_BATCH_DISPLAY_CODE_FORMAT[0]+DOC_BATCH_DISPLAY_CODE_FORMAT[1]+DOC_BATCH_DISPLAY_CODE_FORMAT[2]+2;
		private const int DOC_ORDER_DISPLAY_CODE = 12;
		private static int[] DOC_ORDER_DISPLAY_CODE_FORMAT = {1,5,5};
		private static int DISPLAY_ORDER_DOT1 = DOC_ORDER_DISPLAY_CODE_FORMAT[0];
		private static int DISPLAY_ORDER_DOT12 = DOC_ORDER_DISPLAY_CODE_FORMAT[0]+DOC_ORDER_DISPLAY_CODE_FORMAT[1]+1;

		private const int DOC_ITEM_CODE = 11;
		private static int[] DOC_ITEM_CODE_FORMAT = {1,5,3,2};
		private static int ITEM_DOT1 = DOC_ITEM_CODE_FORMAT[0];
		private static int ITEM_DOT2 = DOC_ITEM_CODE_FORMAT[0]+DOC_ITEM_CODE_FORMAT[1];
		private static int ITEM_DOT3 = DOC_ITEM_CODE_FORMAT[0]+DOC_ITEM_CODE_FORMAT[1]+DOC_ITEM_CODE_FORMAT[2];
		private const int DOC_BATCH_CODE = 9;
		private static int[] DOC_BATCH_CODE_FORMAT = {1,5,3};
		private static int BATCH_DOT1 = DOC_BATCH_CODE_FORMAT[0];
		private static int BATCH_DOT2 = DOC_BATCH_CODE_FORMAT[0]+DOC_BATCH_CODE_FORMAT[1];
		private const int DOC_ORDER_CODE = 6;
		private static int[] DOC_ORDER_CODE_FORMAT = {1,5};
		private static int ORDER_DOT1 = DOC_ORDER_CODE_FORMAT[0];
		private bool bEnteringCode = false;

		private char cDocChar;
		private int iOrderCode = 0;
		private int iEntryBatchCode = 0;
		private int iBatchCode = 0;
		private int iItemCode = 0;

		private DataSet dsDocs = null;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.ImageList ilTreeNodes;
		private System.Windows.Forms.GroupBox gbFilterBy;
		private System.Windows.Forms.CheckBox chbFilter;
		private System.Windows.Forms.TextBox tbFilterCustomer;
		private System.Windows.Forms.TextBox tbFilterOrder;
		private System.Windows.Forms.TextBox tbFilterBatch;
		private System.Windows.Forms.CheckBox chbFilterCustomer;
		private System.Windows.Forms.CheckBox chbFilterOrder;
		private System.Windows.Forms.CheckBox chbFilterBatch;
		private System.Windows.Forms.Button bRunFilter;
		private DataSet dsAttributes = null;
		private System.Windows.Forms.TextBox tbFilterCustomerName;
		private System.Windows.Forms.RadioButton rbPrinted;
		private System.Windows.Forms.RadioButton rbUnprinted;
		private System.Windows.Forms.RadioButton rbAll;
		private DataSet dsDocsSorted;
		private DataSet dsDocuments = null;
		private System.Windows.Forms.Button btnSendBackground;
		private Cntrls.ComboTextComponent CustomerComboText;
		private System.Windows.Forms.GroupBox groupBox1;
		

		struct DocumentState
		{
            public const int UnReady = 4;	// delete
			public const int UnPrinted = 3;	// delete, print, view, send
			public const int Printed = 2;	// print, view, send
			public const int Closed = 1;	// print, view, send
		}
		private int iCurDocState = DocumentState.UnPrinted;


		/// <summary>
		/// PrintingForm class constructor
		/// </summary>
		/// <param name="iAccessCode">acess code</param>
		public PrintingForm(int iAccessCode)
		{
			return;
			InitializeComponent();
			this.Text = Service.sProgramTitle + " Printing";

			accessCode = iAccessCode;

			timer.Stop();
			timer.Interval = 1000;
			InitCustomers();
			
			//dsDocs = Service.GetDocuments();
			rbUnprinted.Checked = true;
			otDocs.CheckBoxes = true;
			chbFilter.Checked = true;

            /*DataTable dtDocsSorted = dsDocs.Tables["tblDocuments"].Clone();
			dsDocsSorted = new DataSet();
			dsDocsSorted.Tables.Add(dtDocsSorted);

			DataView dvDocs = new DataView(dsDocs.Tables["tblDocuments"].Copy());
			dvDocs.Sort = "GroupCode, BatchCode, ItemCode, Name, OperationChar";
			for(int i = 0; i < dvDocs.Count; i++)
			{
				dtDocsSorted.Rows.Add(dvDocs[i].Row.ItemArray);

			//	ListViewItem lviDoc = new ListViewItem(dvDocs[i]["Name"].ToString(), Convert.ToInt32(dvDocs[i]["IconIndex"]));
			//	lviDoc.Tag = dvDocs[i];
			//	lvDocs.Items.Add(lviDoc);
			}
			//otDocs.Initialize(dsDocs);
			//otDocs.Initialize(dsDocs, "tblCustomer");*/

			//DataSet dsDocsSorted = SortDocuments(dsDocs);
			//otDocs.Initialize(dsDocsSorted, "tblDocuments");

			dsAttributes = Service.GetPrintingInfo();
			cbEmail.DataSource = dsAttributes.Tables["Email"];
			cbEmail.ValueMember = "Path";
			cbEmail.DisplayMember = "Folder";
			cbEmail.Enabled = false;
			cbFileType.DataSource = dsAttributes.Tables["FileType"];
			cbFileType.DisplayMember = "FileType";
			cbFileType.ValueMember = "FileExtension";
		}

		public void InitCustomers()
		{
			try
			{
				DataTable dtCustomers = Service.GetCustomers().Tables[0];
				CustomerComboText.Initialize(dtCustomers);
			}
			catch
			{
				MessageBox.Show("Unable to connect to database", "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.Close();
			}
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PrintingForm));
			this.otDocs = new Cntrls.OrdersTree();
			this.tbDocId = new System.Windows.Forms.TextBox();
			this.sbStatus = new System.Windows.Forms.StatusBar();
			this.btnView = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnPrint = new System.Windows.Forms.Button();
			this.gbEmail = new System.Windows.Forms.GroupBox();
			this.cbFileType = new System.Windows.Forms.ComboBox();
			this.lFileType = new System.Windows.Forms.Label();
			this.cbEmail = new System.Windows.Forms.ComboBox();
			this.btnSendBackground = new System.Windows.Forms.Button();
			this.btnSend = new System.Windows.Forms.Button();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.btnSearch = new System.Windows.Forms.Button();
			this.ilTreeNodes = new System.Windows.Forms.ImageList(this.components);
			this.gbFilterBy = new System.Windows.Forms.GroupBox();
			this.CustomerComboText = new Cntrls.ComboTextComponent();
			this.tbFilterCustomerName = new System.Windows.Forms.TextBox();
			this.tbFilterBatch = new System.Windows.Forms.TextBox();
			this.tbFilterOrder = new System.Windows.Forms.TextBox();
			this.tbFilterCustomer = new System.Windows.Forms.TextBox();
			this.chbFilterBatch = new System.Windows.Forms.CheckBox();
			this.chbFilterOrder = new System.Windows.Forms.CheckBox();
			this.chbFilterCustomer = new System.Windows.Forms.CheckBox();
			this.bRunFilter = new System.Windows.Forms.Button();
			this.chbFilter = new System.Windows.Forms.CheckBox();
			this.rbPrinted = new System.Windows.Forms.RadioButton();
			this.rbUnprinted = new System.Windows.Forms.RadioButton();
			this.rbAll = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.gbEmail.SuspendLayout();
			this.gbFilterBy.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// otDocs
			// 
			this.otDocs.CheckBoxes = true;
			this.otDocs.IsDocumentGhost = false;
			this.otDocs.IsExpand = true;
			this.otDocs.Location = new System.Drawing.Point(5, 5);
			this.otDocs.Name = "otDocs";
			this.otDocs.Selected = null;
			this.otDocs.ShowColorAndClarity = true;
			this.otDocs.Size = new System.Drawing.Size(340, 340);
			this.otDocs.TabIndex = 0;
			this.otDocs.SelectedItemChanged += new System.EventHandler(this.otDocs_SelectedItemChanged);
			// 
			// tbDocId
			// 
			this.tbDocId.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
			this.tbDocId.Location = new System.Drawing.Point(350, 130);
			this.tbDocId.Name = "tbDocId";
			this.tbDocId.Size = new System.Drawing.Size(355, 20);
			this.tbDocId.TabIndex = 2;
			this.tbDocId.Text = "[a-z]#####.#####.###.##";
			this.tbDocId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDocId_KeyPress);
			this.tbDocId.Enter += new System.EventHandler(this.tbDocId_Enter);
			// 
			// sbStatus
			// 
			this.sbStatus.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
			this.sbStatus.Location = new System.Drawing.Point(0, 660);
			this.sbStatus.Name = "sbStatus";
			this.sbStatus.Size = new System.Drawing.Size(879, 15);
			this.sbStatus.TabIndex = 18;
			// 
			// btnView
			// 
			this.btnView.Location = new System.Drawing.Point(350, 180);
			this.btnView.Name = "btnView";
			this.btnView.Size = new System.Drawing.Size(355, 23);
			this.btnView.TabIndex = 4;
			this.btnView.Text = "&View";
			this.btnView.Click += new System.EventHandler(this.btnView_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.BackColor = System.Drawing.Color.LightPink;
			this.btnDelete.Location = new System.Drawing.Point(350, 205);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(355, 23);
			this.btnDelete.TabIndex = 5;
			this.btnDelete.Text = "&Delete";
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnPrint
			// 
			this.btnPrint.BackColor = System.Drawing.Color.LightSteelBlue;
			this.btnPrint.Location = new System.Drawing.Point(350, 230);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new System.Drawing.Size(355, 23);
			this.btnPrint.TabIndex = 6;
			this.btnPrint.Text = "&Print";
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			// 
			// gbEmail
			// 
			this.gbEmail.Controls.Add(this.cbFileType);
			this.gbEmail.Controls.Add(this.lFileType);
			this.gbEmail.Controls.Add(this.cbEmail);
			this.gbEmail.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
			this.gbEmail.ForeColor = System.Drawing.Color.DimGray;
			this.gbEmail.Location = new System.Drawing.Point(350, 255);
			this.gbEmail.Name = "gbEmail";
			this.gbEmail.Size = new System.Drawing.Size(360, 60);
			this.gbEmail.TabIndex = 7;
			this.gbEmail.TabStop = false;
			this.gbEmail.Text = "E-mail";
			// 
			// cbFileType
			// 
			this.cbFileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbFileType.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
			this.cbFileType.Location = new System.Drawing.Point(80, 35);
			this.cbFileType.Name = "cbFileType";
			this.cbFileType.Size = new System.Drawing.Size(275, 20);
			this.cbFileType.TabIndex = 1;
			// 
			// lFileType
			// 
			this.lFileType.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
			this.lFileType.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lFileType.Location = new System.Drawing.Point(5, 40);
			this.lFileType.Name = "lFileType";
			this.lFileType.Size = new System.Drawing.Size(70, 15);
			this.lFileType.TabIndex = 24;
			this.lFileType.Text = "File type";
			// 
			// cbEmail
			// 
			this.cbEmail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbEmail.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
			this.cbEmail.Location = new System.Drawing.Point(5, 15);
			this.cbEmail.Name = "cbEmail";
			this.cbEmail.Size = new System.Drawing.Size(350, 20);
			this.cbEmail.TabIndex = 0;
			// 
			// btnSendBackground
			// 
			this.btnSendBackground.Enabled = false;
			this.btnSendBackground.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.btnSendBackground.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnSendBackground.Location = new System.Drawing.Point(350, 320);
			this.btnSendBackground.Name = "btnSendBackground";
			this.btnSendBackground.Size = new System.Drawing.Size(170, 23);
			this.btnSendBackground.TabIndex = 8;
			this.btnSendBackground.Text = "Send &background";
			this.btnSendBackground.Click += new System.EventHandler(this.btnSendBackground_Click);
			// 
			// btnSend
			// 
			this.btnSend.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
			this.btnSend.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnSend.Location = new System.Drawing.Point(530, 320);
			this.btnSend.Name = "btnSend";
			this.btnSend.Size = new System.Drawing.Size(180, 23);
			this.btnSend.TabIndex = 9;
			this.btnSend.Text = "&Send";
			this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
			// 
			// timer
			// 
			this.timer.Enabled = true;
			this.timer.Interval = 1000;
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(350, 155);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(355, 23);
			this.btnSearch.TabIndex = 3;
			this.btnSearch.Text = "S&earch";
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// ilTreeNodes
			// 
			this.ilTreeNodes.ImageSize = new System.Drawing.Size(16, 16);
			this.ilTreeNodes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeNodes.ImageStream")));
			this.ilTreeNodes.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// gbFilterBy
			// 
			this.gbFilterBy.Controls.Add(this.CustomerComboText);
			this.gbFilterBy.Controls.Add(this.tbFilterCustomerName);
			this.gbFilterBy.Controls.Add(this.tbFilterBatch);
			this.gbFilterBy.Controls.Add(this.tbFilterOrder);
			this.gbFilterBy.Controls.Add(this.tbFilterCustomer);
			this.gbFilterBy.Controls.Add(this.chbFilterBatch);
			this.gbFilterBy.Controls.Add(this.chbFilterOrder);
			this.gbFilterBy.Controls.Add(this.chbFilterCustomer);
			this.gbFilterBy.Enabled = false;
			this.gbFilterBy.Location = new System.Drawing.Point(5, 50);
			this.gbFilterBy.Name = "gbFilterBy";
			this.gbFilterBy.Size = new System.Drawing.Size(350, 55);
			this.gbFilterBy.TabIndex = 4;
			this.gbFilterBy.TabStop = false;
			// 
			// CustomerComboText
			// 
			this.CustomerComboText.DefaultText = "Customer Lookup";
			this.CustomerComboText.DisplayMember = "CustomerName";
			this.CustomerComboText.Enabled = false;
			this.CustomerComboText.Location = new System.Drawing.Point(90, 10);
			this.CustomerComboText.Name = "CustomerComboText";
			this.CustomerComboText.SelectedCode = "";
			this.CustomerComboText.Size = new System.Drawing.Size(255, 20);
			this.CustomerComboText.TabIndex = 1;
			this.CustomerComboText.ValueMember = "CustomerCode";
			this.CustomerComboText.SelectionChanged += new System.EventHandler(this.CustomerComboText_SelectionChanged);
			this.CustomerComboText.CodeEntered += new System.EventHandler(this.CustomerComboText_CodeEntered);
			// 
			// tbFilterCustomerName
			// 
			this.tbFilterCustomerName.Enabled = false;
			this.tbFilterCustomerName.Location = new System.Drawing.Point(115, 10);
			this.tbFilterCustomerName.Name = "tbFilterCustomerName";
			this.tbFilterCustomerName.TabIndex = 1;
			this.tbFilterCustomerName.Text = "";
			this.tbFilterCustomerName.Enter += new System.EventHandler(this.tbFilterCustomerName_Enter);
			// 
			// tbFilterBatch
			// 
			this.tbFilterBatch.Enabled = false;
			this.tbFilterBatch.Location = new System.Drawing.Point(305, 30);
			this.tbFilterBatch.MaxLength = 3;
			this.tbFilterBatch.Name = "tbFilterBatch";
			this.tbFilterBatch.Size = new System.Drawing.Size(40, 20);
			this.tbFilterBatch.TabIndex = 5;
			this.tbFilterBatch.Text = "###";
			this.tbFilterBatch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tbFilterBatch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbFilterBatch_KeyDown);
			this.tbFilterBatch.Enter += new System.EventHandler(this.tbFilterBatch_Enter);
			// 
			// tbFilterOrder
			// 
			this.tbFilterOrder.Enabled = false;
			this.tbFilterOrder.Location = new System.Drawing.Point(90, 30);
			this.tbFilterOrder.MaxLength = 11;
			this.tbFilterOrder.Name = "tbFilterOrder";
			this.tbFilterOrder.Size = new System.Drawing.Size(110, 20);
			this.tbFilterOrder.TabIndex = 3;
			this.tbFilterOrder.Text = "#####.#####";
			this.tbFilterOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tbFilterOrder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbFilterBatch_KeyDown);
			this.tbFilterOrder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFilterOrder_KeyPress);
			this.tbFilterOrder.Enter += new System.EventHandler(this.tbFilterOrder_Enter);
			// 
			// tbFilterCustomer
			// 
			this.tbFilterCustomer.Enabled = false;
			this.tbFilterCustomer.Location = new System.Drawing.Point(215, 10);
			this.tbFilterCustomer.MaxLength = 4;
			this.tbFilterCustomer.Name = "tbFilterCustomer";
			this.tbFilterCustomer.Size = new System.Drawing.Size(40, 20);
			this.tbFilterCustomer.TabIndex = 2;
			this.tbFilterCustomer.Text = "####";
			this.tbFilterCustomer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tbFilterCustomer.Enter += new System.EventHandler(this.tbFilterCustomer_Enter);
			// 
			// chbFilterBatch
			// 
			this.chbFilterBatch.Location = new System.Drawing.Point(215, 35);
			this.chbFilterBatch.Name = "chbFilterBatch";
			this.chbFilterBatch.Size = new System.Drawing.Size(85, 15);
			this.chbFilterBatch.TabIndex = 4;
			this.chbFilterBatch.Text = "Batch Code";
			this.chbFilterBatch.CheckedChanged += new System.EventHandler(this.chbFilterBatch_CheckedChanged);
			// 
			// chbFilterOrder
			// 
			this.chbFilterOrder.Location = new System.Drawing.Point(5, 35);
			this.chbFilterOrder.Name = "chbFilterOrder";
			this.chbFilterOrder.Size = new System.Drawing.Size(85, 15);
			this.chbFilterOrder.TabIndex = 2;
			this.chbFilterOrder.Text = "Order Code";
			this.chbFilterOrder.CheckedChanged += new System.EventHandler(this.chbFilterOrder_CheckedChanged);
			// 
			// chbFilterCustomer
			// 
			this.chbFilterCustomer.Location = new System.Drawing.Point(5, 15);
			this.chbFilterCustomer.Name = "chbFilterCustomer";
			this.chbFilterCustomer.Size = new System.Drawing.Size(80, 15);
			this.chbFilterCustomer.TabIndex = 0;
			this.chbFilterCustomer.Text = "Customer";
			this.chbFilterCustomer.CheckedChanged += new System.EventHandler(this.chbFilterCustomer_CheckedChanged);
			// 
			// bRunFilter
			// 
			this.bRunFilter.Location = new System.Drawing.Point(5, 107);
			this.bRunFilter.Name = "bRunFilter";
			this.bRunFilter.Size = new System.Drawing.Size(350, 19);
			this.bRunFilter.TabIndex = 5;
			this.bRunFilter.Text = "&Filter";
			this.bRunFilter.Click += new System.EventHandler(this.bRunFilter_Click);
			// 
			// chbFilter
			// 
			this.chbFilter.Location = new System.Drawing.Point(10, 33);
			this.chbFilter.Name = "chbFilter";
			this.chbFilter.Size = new System.Drawing.Size(70, 15);
			this.chbFilter.TabIndex = 3;
			this.chbFilter.Text = "Filter by:";
			this.chbFilter.CheckedChanged += new System.EventHandler(this.chbFilter_CheckedChanged);
			// 
			// rbPrinted
			// 
			this.rbPrinted.Location = new System.Drawing.Point(10, 15);
			this.rbPrinted.Name = "rbPrinted";
			this.rbPrinted.Size = new System.Drawing.Size(90, 15);
			this.rbPrinted.TabIndex = 0;
			this.rbPrinted.Text = "show printed";
			this.rbPrinted.CheckedChanged += new System.EventHandler(this.rbPrinted_CheckedChanged);
			// 
			// rbUnprinted
			// 
			this.rbUnprinted.Location = new System.Drawing.Point(105, 15);
			this.rbUnprinted.Name = "rbUnprinted";
			this.rbUnprinted.Size = new System.Drawing.Size(105, 15);
			this.rbUnprinted.TabIndex = 1;
			this.rbUnprinted.Text = "show unprinted";
			this.rbUnprinted.CheckedChanged += new System.EventHandler(this.rbUnprinted_CheckedChanged);
			// 
			// rbAll
			// 
			this.rbAll.Location = new System.Drawing.Point(215, 15);
			this.rbAll.Name = "rbAll";
			this.rbAll.Size = new System.Drawing.Size(65, 15);
			this.rbAll.TabIndex = 2;
			this.rbAll.Text = "show all";
			this.rbAll.CheckedChanged += new System.EventHandler(this.rbAll_CheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.gbFilterBy);
			this.groupBox1.Controls.Add(this.chbFilter);
			this.groupBox1.Controls.Add(this.rbPrinted);
			this.groupBox1.Controls.Add(this.rbUnprinted);
			this.groupBox1.Controls.Add(this.rbAll);
			this.groupBox1.Controls.Add(this.bRunFilter);
			this.groupBox1.Location = new System.Drawing.Point(350, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(360, 130);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Filter";
			// 
			// PrintingForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
			this.ClientSize = new System.Drawing.Size(879, 675);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnSendBackground);
			this.Controls.Add(this.btnSend);
			this.Controls.Add(this.btnSearch);
			this.Controls.Add(this.gbEmail);
			this.Controls.Add(this.btnPrint);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnView);
			this.Controls.Add(this.sbStatus);
			this.Controls.Add(this.tbDocId);
			this.Controls.Add(this.otDocs);
			this.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "PrintingForm";
			this.Text = "Printing";
			this.gbEmail.ResumeLayout(false);
			this.gbFilterBy.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void timer_Tick(object sender, System.EventArgs e)
		{
			timer.Stop();
			bEnteringCode = false;

			try
			{
				ParseDocumentCode();
				DataView dvDocs = new DataView(dsDocuments.Tables["tblDocuments"]);
				string sFullCode = GetCorrectFullCodeString();
				dvDocs.RowFilter = "BatchCode="+iBatchCode+" and GroupCode="+iOrderCode+" and ItemCode="+iItemCode+" and OperationChar='"+cDocChar+"'";
				if(dvDocs.Count == 0)
					throw new Exception("There is no such document in the db");

				tbDocId.Text = sFullCode;

				Service.SetDocumentState(cDocChar.ToString(), iOrderCode, iBatchCode, iItemCode, DocumentState.Printed);
				//dsDocs = Service.GetDocuments();
				//otDocs.Initialize(dsDocs, "tblCustomer");
				//otDocs.Initialize(dsDocs, "tblDocuments");
				GetDocumentsByState(iCurDocState);

				try // Invoicing
				{
					if (Service.iInvoiceDebugLevel >= 1)
					{
						int iViewAccessCode = 11; // ViewAccess = "Printing"
						Service.DBAddInvoiceByCode(iViewAccessCode, iOrderCode, iBatchCode, iItemCode);
					}
				}
				catch(Exception exc)
				{
					MessageBox.Show("Warning: Can't add invoice for Printing:\r\n"+exc.Message);
				}
			
			}
			catch(Exception eEx)
			{
				tbDocId.Text = "[a-z]#####.#####.###.##";
				tbDocId.Focus();
				MessageBox.Show("Couldn't update document state\n"+eEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void tbDocId_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			timer.Stop();
			timer.Interval = 1000;
			timer.Start();

			if(!bEnteringCode)
			{
				iOrderCode = 0;
				iEntryBatchCode = 0;
				iBatchCode = 0;
				iItemCode = 0;
				bEnteringCode = true;
			}
		}

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			try
			{
				SearchForm sf = new SearchForm();
				sf.ShowDialog();
				if(sf.EnteredCode.Length != 0)
					otDocs.SelectNode(sf.EnteredCode, true);
			}
			catch(Exception eEx)
			{
				MessageBox.Show(eEx.Message);
			}
		}

		private void btnView_Click(object sender, System.EventArgs e)
		{			
			if(otDocs.GetChecked().Tables["tblDocuments"].Rows.Count == 0)		
				return;

			this.Cursor = Cursors.WaitCursor;
			sbStatus.Text = "Depending on type of chosen documents this operation can take up to 10 minutes";
			try
			{
				foreach(DataRow drDoc in otDocs.GetChecked().Tables[0].Rows)
				{
					string sFullCode = drDoc["Name"].ToString();
					ParseDisplayDocumentCode(sFullCode);

					string sRepPath = Service.GetCRTemplatePath();
					CrystalReport.CrystalReport crRpt = new CrystalReport.CrystalReport(sRepPath);

					int iOperationTypeOfficeId = Convert.ToInt32(drDoc["OperationTypeOfficeID"]);
					int iOperationTypeId = Convert.ToInt32(drDoc["OperationTypeID"]);
					string sTemplatePath = Service.GetOperationTemplatePath(iOperationTypeOfficeId, iOperationTypeId);

					crRpt.isView=true;
					crRpt.PDF_Report(sTemplatePath, Convert.ToInt32(drDoc["GroupCode"]), 
						Convert.ToInt32(drDoc["BatchCode"]), Convert.ToInt32(drDoc["ItemCode"]), drDoc["OperationChar"].ToString());
					//crRpt.FDXR1(iOrderCode, iBatchCode, iItemCode);

					string sFileType = cbFileType.SelectedValue.ToString();
					sFileType = sFileType.Substring(1, sFileType.Length-1).ToLower();
					crRpt.Export(sFileType);
					//crRpt = Export2CrystalReport();
					crRpt.ViewDocument();
				}
			}
			catch(Exception eEx)
			{
				if(MessageBox.Show("Couldn't load document\n" + eEx.Message + "\nLoad other documents?",
					"Load error", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No)
				{
					this.Cursor = Cursors.Default;
					sbStatus.Text = "Operation was interrupted";
					return;
				}
			}
			this.Cursor = Cursors.Default;
			sbStatus.Text = "Ready";
		}

		private void btnPrint_Click(object sender, System.EventArgs e)
		{			
			if(otDocs.GetChecked().Tables["tblDocuments"].Rows.Count == 0)		
				return;
		
			this.Cursor = Cursors.WaitCursor;
			sbStatus.Text = "Depending on type of chosen documents this operation can take up to 10 minutes";
			foreach(DataRow drDoc in otDocs.GetChecked().Tables[0].Rows)
			{
				try
				{
					string sFullCode = drDoc["Name"].ToString();
					ParseDisplayDocumentCode(sFullCode);

					string sRepPath = Service.GetCRTemplatePath();
					CrystalReport.CrystalReport crRpt = new CrystalReport.CrystalReport(sRepPath);

					int iOperationTypeOfficeId = Convert.ToInt32(drDoc["OperationTypeOfficeID"]);
					int iOperationTypeId = Convert.ToInt32(drDoc["OperationTypeID"]);
					string sTemplatePath = Service.GetOperationTemplatePath(iOperationTypeOfficeId, iOperationTypeId);

					crRpt.isView=true;
					crRpt.PDF_Report(sTemplatePath, Convert.ToInt32(drDoc["GroupCode"]),
						Convert.ToInt32(drDoc["BatchCode"]), Convert.ToInt32(drDoc["ItemCode"]), drDoc["OperationChar"].ToString());
					//crRpt.FDXR1(iOrderCode, iBatchCode, iItemCode);

					string sFileType = cbFileType.SelectedValue.ToString();
					sFileType = sFileType.Substring(1, sFileType.Length-1).ToLower();
					crRpt.Export(sFileType);
//					crRpt.SelectPrinter("Printing_Form_Printer");
					crRpt.Print();
					//crRpt.PrintToDefaultPrinter();
					
					//crRpt = Export2CrystalReport();
				
				}
				catch(Exception eEx)
				{
					if(MessageBox.Show("Couldn't print document\n"+eEx.Message + "\nContinue printing other documents?",
						"Print error", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No)
					{
						sbStatus.Text = "Operation was interrupted";
						this.Cursor = Cursors.Default;
						return;
					}
				}
			}
			sbStatus.Text = "Ready";
			this.Cursor = Cursors.Default;
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			if(!IsDocumentSelected())
				return;

			try
			{
				string sFullCode = otDocs.Selected.NodeCode;
				object oDocId = otDocs.Selected.drNode["ID"];
				Service.DeleteDocument(oDocId);

				GetDocumentsByState(iCurDocState);
				//dsDocs = Service.GetDocuments();
				//otDocs.Initialize(dsDocs, "tblDocuments");
				//otDocs.Initialize(dsDocs, "tblCustomer");

				tbDocId.Text = "[a-z]#####.#####.###.##";
			}
			catch(Exception eEx)
			{
				MessageBox.Show("Couldn't delete document from the db\n"+eEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private string FillToFiveChars(string sNumber)
		{
			while(sNumber.Length<5)
				sNumber="0"+sNumber;
			return sNumber;
		}
		private string FillToThreeChars(string sNumber)
		{
			while(sNumber.Length<3)
				sNumber="0"+sNumber;
			return sNumber;
		}
		
		private string FillToTwoChars(string sNumber)
		{
			while(sNumber.Length<2)
				sNumber="0"+sNumber;
			return sNumber;
		}

		private void MakeXML2(string sReportNameTemplate, string sDocumentID, string sBatchID)
		{
			DataSet dsDoc = Service.GetDocument(sDocumentID);
			DataRow row = dsDoc.Tables[0].Rows[0];

			//spGetBatch
			string sItemTypeID = Service.GetItemTypeIDByBatchID(sBatchID);

			//spGetItemType
			string sPath2Picture = Service.GetPath2Picture(sItemTypeID);

			string sItemContainerName = Service.GetItemContainerName(sItemTypeID);

			string sReportGroup = row["DocumentTypeName"].ToString();
			string sReportName = String.Format(sReportNameTemplate, sReportGroup);
			

			bool bUseDate = row["UseDate"].ToString().Equals("1");
			
			bool bUseVVN = row["UseVirtualVaultNumber"].ToString().Equals("1");

			string sBarCode = row["BarCodeFixedText"].ToString();

			//DataSet dsMeasures = new DataSet();
			//dsMeasures.Tables.Add(Service.GetMeasuresByItemType2(sItemTypeID));
			DataSet dsShapes = Service.GetShapesByBatchID(sBatchID);
			//gemoDream.Service.debug_DiaspalyDataSet(dsShapes);
			DataSet dsValues = Service.GetDocumentValues(sDocumentID);
			Service.XMLData xmlData = new Service.XMLData();
			xmlData.sReportGroup = row["DocumentTypeName"].ToString();
			xmlData.sItemPrefix  = row["DocumentOperationChar"].ToString();
			xmlData.sFileName = row["CorelFile"].ToString();
			xmlData.sPicture = sPath2Picture;
			xmlData.UseVVN = bUseVVN;
			xmlData.sBarCode = sBarCode;
			xmlData.UseDate = bUseDate;
			Service.SaveXML(sReportName, sItemContainerName, xmlData, dsShapes, dsValues);
		}


		private void MakeXML(string sReportName, string sPath2Picture, string sDocumentID, string sBatchID)
		{
			DataSet dsDoc = Service.GetDocument(sDocumentID);
			DataRow row = dsDoc.Tables[0].Rows[0];
			bool bUseDate = row["UseDate"].ToString().Equals("1");
			
			bool bUseVVN = row["UseVirtualVaultNumber"].ToString().Equals("1");

			string sBarCode = row["BarCodeFixedText"].ToString();

			//DataSet dsMeasures = new DataSet();
			//dsMeasures.Tables.Add(Service.GetMeasuresByItemType2(sItemTypeID));
			DataSet dsShapes = Service.GetShapesByBatchID(sBatchID);
			gemoDream.Service.Debug_DiaspalyDataSet(dsShapes);
			DataSet dsValues = Service.GetDocumentValues(sDocumentID);
			Service.XMLData xmlData = new Service.XMLData();
			xmlData.sReportGroup = row["DocumentTypeName"].ToString();
			xmlData.sItemPrefix  = row["DocumentOperationChar"].ToString();
			xmlData.sFileName = row["CorelFile"].ToString();
			xmlData.sPicture = sPath2Picture;
			xmlData.UseVVN = bUseVVN;
			xmlData.sBarCode = sBarCode;
			xmlData.UseDate = bUseDate;
			Service.SaveXML(sReportName, "Item container name not found", xmlData, dsShapes, dsValues);
		}

		private void MakeTextFile2()
		{
			ArrayList printedDocs = new ArrayList();
			string sOldBatchID = "";

			DataSet dsChecked = otDocs.GetChecked();
			//gemoDream.Service.debug_DiaspalyDataSet(dsChecked);

			this.Cursor = Cursors.WaitCursor;
			sbStatus.Text = "Depending on type of chosen documents this operation can take up to 10 minutes";
			
			DataSet dsIndex=new DataSet();
			string sSendPath = Service.GetServiceCfgParameter("sendDir");

			string sIconDir = Service.GetServiceCfgParameter("iconDir");

			//gemoDream.Service.debug_DiaspalyDataSet(dsChecked);
            			
			foreach(DataRow drChecked in dsChecked.Tables["tblDocuments"].Rows)
			{
				string sFullCode = drChecked["Name"].ToString();
				try
				{					
					ParseDisplayDocumentCode(sFullCode);
			
					string sBatchCode=FillToThreeChars(drChecked["BatchCode"].ToString());
					string sOrderCode=FillToFiveChars(drChecked["GroupCode"].ToString());
					string sTableName=sOrderCode+sBatchCode;

					
					string sBatchID = drChecked["BatchID"].ToString();

					DataSet dsCP = Service.GetCustomerProgramByBatchID(sBatchID);

					string sCPPropertyCustomerID = dsCP.Tables[0].Rows[0]["CPPropertyCustomerID"].ToString();
					string sSKU = dsCP.Tables[0].Rows[0]["CustomerProgramName"].ToString();
					string sCustomerStyle = dsCP.Tables[0].Rows[0]["CustomerStyle"].ToString();
					Char decSeparator = Convert.ToChar(System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator);					

					//We need SRP on foreground printing too! by _3ter on 12.21.05
					string sSRP = dsCP.Tables[0].Rows[0]["SRP"].ToString();
					if(sSRP.Split(new char[] {decSeparator}).Length < 2)
					{
						sSRP += ".0000";
					}
					else 
						while(sSRP.Split(new char[] {decSeparator})[1].Length < 4)
							sSRP += "0";


					DataSet dsDocuments = Service.GetDocumentIDByBatchID(sBatchID);

					//gemoDream.Service.debug_DiaspalyDataSet(dsDocuments);
					if (sBatchID != sOldBatchID)
					{
						printedDocs.Clear();		
						sOldBatchID = sBatchID;
					}
					foreach (DataRow row in dsDocuments.Tables[0].Rows)
					{

						string sDocumentID = row["DocumentID"].ToString();
						if (!printedDocs.Contains(sDocumentID))
						{
							//if (sDocumentID != null && sDocumentID.Length != 0)
							//{
							//spGetBatch
							//string sItemTypeID = Service.GetItemTypeIDByBatchID(sBatchID);
							//spGetItemType
							//string sPath2Picture = Service.GetPath2Picture(sItemTypeID);

							//DataSet dsDoc = Service.GetDocument(sDocumentID);
							//DataRow docRow = dsDoc.Tables[0].Rows[0];

							//string sReportGroup = docRow["DocumentTypeName"].ToString();

							//string sReportName = sSendPath+sReportGroup+"."+sTableName+".xml";
							string sReportNameTemplate=sSendPath+"{0}."+sTableName+".xml";
							//MakeXML(sReportName, sPath2Picture, sDocumentID, sBatchID);
							MakeXML2(sReportNameTemplate, sDocumentID, sBatchID); 

							printedDocs.Add(sDocumentID);
						}
						//}
					}

					int iOperationTypeOfficeId = Convert.ToInt32(drChecked["OperationTypeOfficeID"]);
					int iOperationTypeId = Convert.ToInt32(drChecked["OperationTypeID"]);
					string sTemplatePath = Service.GetOperationTemplatePath(iOperationTypeOfficeId, iOperationTypeId);
				
					string sFileName = drChecked["OperationChar"].ToString() + 
						FillToFiveChars(drChecked["GroupCode"].ToString()) +  
						FillToThreeChars(drChecked["BatchCode"].ToString()) +  
						FillToTwoChars(drChecked["ItemCode"].ToString());
					
					if(!Service.IsTableInDataSet(dsIndex,sTableName))
					{
						dsIndex.Tables.Add(sTableName);
						dsIndex.Tables[sTableName].Columns.Add("FileName",System.Type.GetType("System.String"));
					}

					DataRow rTemp=dsIndex.Tables[sTableName].NewRow();

					rTemp["FileName"]=sFileName;
					dsIndex.Tables[sTableName].Rows.Add(rTemp);

					System.IO.StreamWriter sw=new System.IO.StreamWriter(sSendPath+sFileName+".txt",false);
					sw.Write("Report Type\tReport Number\tItem Number\tItem Type Part Name\t");
				
					DataSet dsItem=Service.GetItem(drChecked["ItemCode"].ToString(),drChecked["BatchID"].ToString());
					
					string sShapeCode=dsItem.Tables[0].Rows[0]["Shape"].ToString();
					string sShortReportName="null";
					//Commented because not usable by _3ter on 12.21.05
					//					bool bUseLongReportName = false;
					string sFullShapeName="null";

					DataSet dsShape=new DataSet();
					try
					{

						dsShape=gemoDream.Service.GetShapeByCode(Convert.ToInt32(sShapeCode));
						//gemoDream.Service.debug_DiaspalyDataSet(dsShape);
						//sShortReportName=dsShape.Tables[0].Rows[0]["ShortReportName"].ToString();
						//sLongReportName=dsShape.Tables[0].Rows[0]["LongReportName"].ToString();
					}
					catch
					{}

					string sExternalComment = gemoDream.Service.GetIIBGBIC(sOrderCode,sBatchCode,drChecked["ItemCode"].ToString()).Tables["IIBGBIC"].Rows[0]["ItemComment"].ToString();
					if(sExternalComment.Length==0) sExternalComment="null";

					//gemoDream.Service.debug_DiaspalyDataSet(dsItem);
                    
					foreach(DataRow drItem in dsItem.Tables[0].Rows)
					{

						//	tblTextFile.Rows[i]["ReportType"]=drChecked["GroupCode"].ToString();
						//	tblTextFile.Rows[i]["ReportNumber"]=sFileName;
						
						DataTable tblParts=Service.GetParts(drItem["ItemTypeID"].ToString()); 

						DataSet ds1 = new DataSet();
						ds1.Tables.Add(tblParts.Copy());
						//gemoDream.Service.debug_DiaspalyDataSet(ds1);
					
						DataSet dsMeasures=Service.GetTblMeasure();
						//gemoDream.Service.debug_DiaspalyDataSet(dsMeasures);
						for(int i=0;i<dsMeasures.Tables[0].Rows.Count;i++)
						{
							sw.Write(dsMeasures.Tables[0].Rows[i]["MeasureName"].ToString()+"\t");
								
						}
						
						sw.WriteLine("Path2Picture\tComment\tCPComment\tCPDescription\tShapePath2Drawing\tFullShapeName\tCPCustomerID\tCPSKU");

						string sShapePath2Drawing = "";
						//	sw.WriteLine("Comment\t");
						//    sw.WriteLine("CPcomment\t");
					
						/*
						int iShapeCode = 0;
						DataSet dsShapeMy = null;
						string sPath2Drawing = "";
						//sShapeCode = drItem["Shape"].ToString();
						try
						{
							iShapeCode = Convert.ToInt32(sShapeCode);
							dsShapeMy = Service.GetShapeByCode(iShapeCode);
							//rFile["Shape"]=dsShape.Tables[0].Rows[0]["LongReportName"].ToString();
							//sPath2Drawing=dsShapeMy.Tables[0].Rows[0]["Path2Drawing"].ToString();
						}
						catch
						{
							sPath2Drawing = "";
						}
						*/
	
						/////////////// end of first line ////////////
						///
						//Data

						//DataSet dsZ = new DataSet();
						//dsZ.Tables.Add(tblParts.Copy());
						//gemoDream.Service.debug_DiaspalyDataSet(dsZ);
						
						/* sd 25.12.2006
						DataTable tblPartValue=Service.GetPartValue(drChecked["BatchID"].ToString(),drChecked["ItemCode"].ToString());
						*/
						DataTable tblPartValue=Service.GetPartValue(drChecked["NewBatchID"].ToString(),drChecked["NewItemCode"].ToString());

						DataSet dsBatch = Service.ProxyGenericGetById(drChecked["BatchID"].ToString(),"Batch");

						DataSet dsTemp = new DataSet("Temp");
						dsTemp.Tables.Add("CustomerProgramInstanceByCPID2");
						DataRow row=dsTemp.Tables[0].NewRow();
						dsTemp.Tables[0].Columns.Add(new DataColumn("CPID",Type.GetType("System.String")));
						row["CPID"] = dsBatch.Tables[0].Rows[0]["CPID"].ToString();
						dsTemp.Tables[0].Rows.Add(row);
						dsTemp.AcceptChanges();

						dsTemp = Service.ProxyGenericGet(dsTemp);

						DataSet dsPic =	Service.GetItemCPPictureByCode(	dsBatch.Tables[0].Rows[0]["OrderCode"].ToString(),
																		dsBatch.Tables[0].Rows[0]["BatchCode"].ToString());
				
						foreach(DataRow drPart in tblParts.Rows)
						{
							//DataSet ds = new DataSet();
							//ds.Tables.Add(tblParts.Copy());
							//gemoDream.Service.debug_DiaspalyDataSet(ds);

							sw.Write(drChecked["OperationChar"].ToString()+"\t");
							sw.Write(sFileName+"\t");
							string sItemNumber = sFileName.Substring(1);
							sw.Write(sItemNumber+"\t");
							sw.Write(drPart["Name"]+"\t");

							DataRow [] rPartValue=tblPartValue.Select("PartID="+drPart["ID"].ToString());
							
							// DataSet for Description
							DataSet dsCustomer = new DataSet();
							
							//	dsCustomer.Tables.Add(new DataTable("CustomerProgramByCPID2"));
							//  dsCustomer.Tables[0].Columns.Add(new DataColumn("CPID"));
							//DataRow r = dsCustomer.Tables[0].NewRow();
							//r[0]=dsBatch.Tables[0].Rows[0]["CPID"];
							//dsCustomer.Tables[0].Rows.Add(r);
							//dsCustomer=Service.ProxyGenericGet(dsCustomer);
                            
							//							DataSet dsPic =	Service.GetItemCPPictureByCode(dsBatch.Tables[0].Rows[0]["OrderCode"].ToString(),dsBatch.Tables[0].Rows[0]["BatchCode"].ToString());

							//dsPic.Tables[0].Rows[0]["Path2Picture"].ToString();

							//string sLongReportName = "";
							//string sShortReportName = "";
							//string sShapePath2Drawing = "";
							
							for(int i=0; i<dsMeasures.Tables[0].Rows.Count;i++)
							{
								//gemoDream.Service.debug_DiaspalyDataSet(dsMeasures);

								string sMeasureCode=dsMeasures.Tables[0].Rows[i]["MeasureCode"].ToString();
								string sMeasure="";
								
								string sFilter = "PartID="+drPart["ID"].ToString()+"and MeasureCode="+sMeasureCode;
								DataRow [] rParts=tblPartValue.Select("PartID="+drPart["ID"].ToString()+"and MeasureCode="+sMeasureCode);	

								DataSet dss = new DataSet();
								dss.Tables.Add(tblPartValue.Copy());
								//gemoDream.Service.debug_DiaspalyDataSet(dss);
								if (sMeasureCode.Equals("95"))
								{
									sw.Write(sCustomerStyle + "\t");
									continue;
								}

								//Printing SRP. by _3ter on 12.21.05
								if (sMeasureCode.Equals("96"))
								{
									sw.Write(sSRP + "\t");
									continue;
								}
								
								if(rParts.Length==0)
									sw.Write("null\t");
								else
								{
									switch(rParts[0]["MeasureClass"].ToString())
									{
										case "1": sMeasure=rParts[0]["ValueTitle"].ToString()+"\t"; break;
										case "2": sMeasure=rParts[0]["StringValue"].ToString()+"\t"; break;
										case "3": sMeasure=rParts[0]["MeasureValue"].ToString()+"\t"; break;
										case "4": sMeasure=rParts[0]["StringValue"].ToString()+"\t"; break;
									}

									if(rParts[0]["MeasureName"].ToString()=="Shape (cut)")
									{
										sFullShapeName = rParts[0]["LongReportName"].ToString();
										sShortReportName = rParts[0]["ShortReportName"].ToString();
										sShapePath2Drawing = rParts[0]["ShapePath2Drawing"].ToString();

										//bUseLongReportName = true;
										sMeasure=sShortReportName+"\t";
									}
									//if (rParts[0]["MeasureName"].ToString()=="Customer Style")
									//if (rParts[0]["MeasureCode"].ToString().Equals("95"))
									//if (sMeasureCode.Equals("95"))
									//{
									//	sMeasure=sCustomerStyle + "\t";
									//}
									
									sw.Write((sMeasure.Replace("\n", " ")).Replace("\r", " "));
								}
							}
							sw.Write(dsPic.Tables[0].Rows[0]["Path2Picture"].ToString()+"\t");
							sw.Write(sExternalComment+"\t");

							//							DataSet dsTemp = new DataSet("Temp");
							//							dsTemp.Tables.Add("CustomerProgramInstanceByCPID2");
							//							DataRow row=dsTemp.Tables[0].NewRow();
							//							dsTemp.Tables[0].Columns.Add(new DataColumn("CPID",Type.GetType("System.String")));
							//							row["CPID"] = dsBatch.Tables[0].Rows[0]["CPID"].ToString();
							//							dsTemp.Tables[0].Rows.Add(row);
							//							dsTemp.AcceptChanges();
							//
							//							dsTemp = Service.ProxyGenericGet(dsTemp);

							if(dsTemp.Tables[0].Rows[0]["Comment"].ToString() != "")
							{
								string s = ((dsTemp.Tables[0].Rows[0]["Comment"].ToString().Replace("\n", " ")).Replace("\t", " ")).Replace("\r", " ");
								sw.Write(s+"\t");
							}
							else
								sw.Write("null\t");

							if(dsTemp.Tables[0].Rows[0]["Description"].ToString() != "")
							{
								string s = ((dsTemp.Tables[0].Rows[0]["Description"].ToString().Replace("\n", " ")).Replace("\t", " ")).Replace("\r", " ");
								sw.Write(s+"\t");
							}
							else
								sw.Write("null\t");

							if (sShapePath2Drawing != "")
								sw.Write(sShapePath2Drawing+"\t");
							else
								sw.Write("null\t");

							if (sFullShapeName != "")
								sw.Write(sFullShapeName+"\t");
							else
								sw.Write("null\t");

							if (sCPPropertyCustomerID != "")
								sw.Write(sCPPropertyCustomerID + "\t");
							else
								sw.Write("null\t");

							if (sSKU != "")
								sw.WriteLine(sSKU);
							else
								sw.WriteLine("null");
							
						}						
							
					}

					
					
					//sw.Write();

					sw.Close();
				}
				catch(Exception eEx)
				{
					if(MessageBox.Show("Error sending document " + sFullCode + "\n" + eEx.Message + 
						"\nContinue sending other documents?", 
						"Send error", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No)
					{
						this.Cursor = Cursors.Default;
						sbStatus.Text = "Operation was interrupted";
						return;
					}
				}
				
			}

			for(int i=0;i<dsIndex.Tables.Count;i++)
			{
				System.IO.StreamWriter sw=new System.IO.StreamWriter(sSendPath+dsIndex.Tables[i].TableName+".txt",false);
				foreach(DataRow rT in dsIndex.Tables[i].Rows)
				{
					sw.WriteLine(rT[0].ToString()+".txt");
				}
				sw.Close();
			}

			System.IO.StreamWriter sw1=new System.IO.StreamWriter(sSendPath+"index.txt",false);
			foreach(DataTable tblT in dsIndex.Tables)
			{
				sw1.WriteLine(tblT.TableName+".txt");
			}

			sw1.Close();
			
			
			//	Service.SendDocument(sTemplatePath, sSendPath, sFileExt, iOrderCode, iBatchCode, iItemCode, cDocChar.ToString());			
			sbStatus.Text = "Ready";
			this.Cursor = Cursors.Default;			

		}

		private void MakeTextFile()
		{
			DataSet dsChecked = otDocs.GetChecked();
			gemoDream.Service.Debug_DiaspalyDataSet(dsChecked);

			this.Cursor = Cursors.WaitCursor;
			sbStatus.Text = "Depending on type of chosen documents this operation can take up to 10 minutes";
			
			DataSet dsIndex=new DataSet();
			string sSendPath = Service.GetServiceCfgParameter("sendDir");

			string sIconDir = Service.GetServiceCfgParameter("iconDir");
			
			foreach(DataRow drChecked in dsChecked.Tables["tblDocuments"].Rows)
			{
				string sFullCode = drChecked["Name"].ToString();
				try
				{					
					ParseDisplayDocumentCode(sFullCode);
			
					string sBatchCode=FillToThreeChars(drChecked["BatchCode"].ToString());
					string sOrderCode=FillToFiveChars(drChecked["GroupCode"].ToString());
					string sTableName=sOrderCode+sBatchCode;

					
					string sBatchID = drChecked["BatchID"].ToString();
					DataSet dsCP = Service.GetCustomerProgramByBatchID(sBatchID);
					string sCPPropertyCustomerID = dsCP.Tables[0].Rows[0]["CPPropertyCustomerID"].ToString();
					string sSKU = dsCP.Tables[0].Rows[0]["CustomerProgramName"].ToString();
					string sCustomerStyle = dsCP.Tables[0].Rows[0]["CustomerStyle"].ToString();
					//string sDocumentID = Service.GetDocumentIDByBatchID(sBatchID);
					DataSet dsDocuments = Service.GetDocumentIDByBatchID(sBatchID);
					foreach (DataRow row in dsDocuments.Tables[0].Rows)
					{
						string sDocumentID = row["DocumentID"].ToString();
						//if (sDocumentID != null && sDocumentID.Length != 0)
						//{
						string sItemTypeID = Service.GetItemTypeIDByBatchID(sBatchID);
						string sPath2Picture = Service.GetPath2Picture(sItemTypeID);

						DataSet dsDoc = Service.GetDocument(sDocumentID);
						DataRow docRow = dsDoc.Tables[0].Rows[0];

						string sReportGroup = docRow["DocumentTypeName"].ToString();

						string sReportName = sSendPath+sReportGroup+"."+sTableName+".xml";
						MakeXML(sReportName, sPath2Picture, sDocumentID, sBatchID);
						//}
					}

					int iOperationTypeOfficeId = Convert.ToInt32(drChecked["OperationTypeOfficeID"]);
					int iOperationTypeId = Convert.ToInt32(drChecked["OperationTypeID"]);
					string sTemplatePath = Service.GetOperationTemplatePath(iOperationTypeOfficeId, iOperationTypeId);
				
					string sFileName = drChecked["OperationChar"].ToString() + 
						FillToFiveChars(drChecked["GroupCode"].ToString()) +  
						FillToThreeChars(drChecked["BatchCode"].ToString()) +  
						FillToTwoChars(drChecked["ItemCode"].ToString());
					
					if(!Service.IsTableInDataSet(dsIndex,sTableName))
					{
						dsIndex.Tables.Add(sTableName);
						dsIndex.Tables[sTableName].Columns.Add("FileName",System.Type.GetType("System.String"));
					}

					DataRow rTemp=dsIndex.Tables[sTableName].NewRow();

					rTemp["FileName"]=sFileName;
					dsIndex.Tables[sTableName].Rows.Add(rTemp);

					System.IO.StreamWriter sw=new System.IO.StreamWriter(sSendPath+sFileName+".txt",false);
					sw.Write("Report Type\tReport Number\tItem Type Part Name\t");
				
					DataSet dsItem=Service.GetItem(drChecked["ItemCode"].ToString(),drChecked["BatchID"].ToString());
					
					string sShapeCode=dsItem.Tables[0].Rows[0]["Shape"].ToString();
					string sShortReportName="null";
					bool bUseLongReportName = false;

					string sFullShapeName="null";

					DataSet dsShape=new DataSet();
					try
					{

						dsShape=gemoDream.Service.GetShapeByCode(Convert.ToInt32(sShapeCode));
						//gemoDream.Service.debug_DiaspalyDataSet(dsShape);
						//sShortReportName=dsShape.Tables[0].Rows[0]["ShortReportName"].ToString();
						//sLongReportName=dsShape.Tables[0].Rows[0]["LongReportName"].ToString();
					}
					catch
					{}

					string sExternalComment = gemoDream.Service.GetIIBGBIC(sOrderCode,sBatchCode,drChecked["ItemCode"].ToString()).Tables["IIBGBIC"].Rows[0]["ItemComment"].ToString();
					if(sExternalComment.Length==0) sExternalComment="null";
                    
					foreach(DataRow drItem in dsItem.Tables[0].Rows)
					{

						//	tblTextFile.Rows[i]["ReportType"]=drChecked["GroupCode"].ToString();
						//	tblTextFile.Rows[i]["ReportNumber"]=sFileName;
						
						DataTable tblParts=Service.GetParts(drItem["ItemTypeID"].ToString()); 

						DataSet ds1 = new DataSet();
						ds1.Tables.Add(tblParts.Copy());
						//gemoDream.Service.debug_DiaspalyDataSet(ds1);
					
						DataSet dsMeasures=Service.GetTblMeasure();
						//gemoDream.Service.debug_DiaspalyDataSet(dsMeasures);
						for(int i=0;i<dsMeasures.Tables[0].Rows.Count;i++)
						{
							sw.Write(dsMeasures.Tables[0].Rows[i]["MeasureName"].ToString()+"\t");
								
						}
						
						sw.WriteLine("Path2Picture\tComment\tCPComment\tCPDescription\tShapePath2Drawing\tFullShapeName\tCPCustomerID\tCPSKU");

						string sShapePath2Drawing = "";
						//	sw.WriteLine("Comment\t");
						//    sw.WriteLine("CPcomment\t");
					
						/*
						int iShapeCode = 0;
						DataSet dsShapeMy = null;
						string sPath2Drawing = "";
						//sShapeCode = drItem["Shape"].ToString();
						try
						{
							iShapeCode = Convert.ToInt32(sShapeCode);
							dsShapeMy = Service.GetShapeByCode(iShapeCode);
							//rFile["Shape"]=dsShape.Tables[0].Rows[0]["LongReportName"].ToString();
							//sPath2Drawing=dsShapeMy.Tables[0].Rows[0]["Path2Drawing"].ToString();
						}
						catch
						{
							sPath2Drawing = "";
						}
						*/
	
						/////////////// end of first line ////////////
						///
						//Data
				
						foreach(DataRow drPart in tblParts.Rows)
						{
							//DataSet ds = new DataSet();
							//ds.Tables.Add(tblParts.Copy());
							//gemoDream.Service.debug_DiaspalyDataSet(ds);


							sw.Write(drChecked["OperationChar"].ToString()+"\t");
							sw.Write(sFileName+"\t");
							sw.Write(drPart["Name"]+"\t");
							/* sd 25.12.2006
							DataTable tblPartValue=Service.GetPartValue(drChecked["BatchID"].ToString(),drChecked["ItemCode"].ToString());
							*/
							DataTable tblPartValue=Service.GetPartValue(drChecked["NewBatchID"].ToString(),drChecked["NewItemCode"].ToString());
							DataRow [] rPartValue=tblPartValue.Select("PartID="+drPart["ID"].ToString());
							
							DataSet dsBatch = Service.ProxyGenericGetById(drChecked["BatchID"].ToString(),"Batch");
							
							// DataSet for Description
							DataSet dsCustomer = new DataSet();
							
							//	dsCustomer.Tables.Add(new DataTable("CustomerProgramByCPID2"));
							//  dsCustomer.Tables[0].Columns.Add(new DataColumn("CPID"));
							//DataRow r = dsCustomer.Tables[0].NewRow();
							//r[0]=dsBatch.Tables[0].Rows[0]["CPID"];
							//dsCustomer.Tables[0].Rows.Add(r);
							//dsCustomer=Service.ProxyGenericGet(dsCustomer);
                            
							DataSet dsPic =	Service.GetItemCPPictureByCode(	dsBatch.Tables[0].Rows[0]["OrderCode"].ToString(),
																			dsBatch.Tables[0].Rows[0]["BatchCode"].ToString());

							dsPic.Tables[0].Rows[0]["Path2Picture"].ToString();

							//string sLongReportName = "";
							//string sShortReportName = "";
							//string sShapePath2Drawing = "";
							
							for(int i=0; i<dsMeasures.Tables[0].Rows.Count;i++)
							{
								//gemoDream.Service.debug_DiaspalyDataSet(dsMeasures);

								string sMeasureCode=dsMeasures.Tables[0].Rows[i]["MeasureCode"].ToString();
								string sMeasure="";
								
								string sFilter = "PartID="+drPart["ID"].ToString()+"and MeasureCode="+sMeasureCode;
								DataRow [] rParts=tblPartValue.Select("PartID="+drPart["ID"].ToString()+"and MeasureCode="+sMeasureCode);	

								//DataSet dss = new DataSet();
								//dss.Tables.Add(tblPartValue.Copy());
								//gemoDream.Service.debug_DiaspalyDataSet(dss);
								if (sMeasureCode.Equals("95"))
								{
									sw.Write(sCustomerStyle + "\t");
									continue;
								}
								
								if(rParts.Length==0)
									sw.Write("null\t");
								else
								{
									switch(rParts[0]["MeasureClass"].ToString())
									{
										case "1": sMeasure=rParts[0]["ValueTitle"].ToString()+"\t"; break;
										case "2": sMeasure=rParts[0]["StringValue"].ToString()+"\t"; break;
										case "3": sMeasure=rParts[0]["MeasureValue"].ToString()+"\t"; break;
										case "4": sMeasure=rParts[0]["StringValue"].ToString()+"\t"; break;
									}

									if(rParts[0]["MeasureName"].ToString()=="Shape (cut)")
									{
										sFullShapeName = rParts[0]["LongReportName"].ToString();
										sShortReportName = rParts[0]["ShortReportName"].ToString();
										sShapePath2Drawing = rParts[0]["ShapePath2Drawing"].ToString();

										//bUseLongReportName = true;
										sMeasure=sShortReportName+"\t";
									}
									//if (rParts[0]["MeasureName"].ToString()=="Customer Style")
									//if (rParts[0]["MeasureCode"].ToString().Equals("95"))
									//if (sMeasureCode.Equals("95"))
									//{
									//	sMeasure=sCustomerStyle + "\t";
									//}
									
									sw.Write((sMeasure.Replace("\n", " ")).Replace("\r", " "));
								}
									
							}
							sw.Write(dsPic.Tables[0].Rows[0]["Path2Picture"].ToString()+"\t");
							sw.Write(sExternalComment+"\t");

							DataSet dsTemp = new DataSet("Temp");
							dsTemp.Tables.Add("CustomerProgramInstanceByCPID2");
							DataRow row=dsTemp.Tables[0].NewRow();
							dsTemp.Tables[0].Columns.Add(new DataColumn("CPID",Type.GetType("System.String")));
							row["CPID"] = dsBatch.Tables[0].Rows[0]["CPID"].ToString();
							dsTemp.Tables[0].Rows.Add(row);
							dsTemp.AcceptChanges();

							dsTemp = Service.ProxyGenericGet(dsTemp);
							if(dsTemp.Tables[0].Rows[0]["Comment"].ToString() != "")
							{
								string s = ((dsTemp.Tables[0].Rows[0]["Comment"].ToString().Replace("\n", " ")).Replace("\t", " ")).Replace("\r", " ");
								sw.Write(s+"\t");
							}
							else
								sw.Write("null\t");

							if(dsTemp.Tables[0].Rows[0]["Description"].ToString() != "")
							{
								string s = ((dsTemp.Tables[0].Rows[0]["Description"].ToString().Replace("\n", " ")).Replace("\t", " ")).Replace("\r", " ");
								sw.Write(s+"\t");
							}
							else
								sw.Write("null\t");

							if (sShapePath2Drawing != "")
								sw.Write(sShapePath2Drawing+"\t");
							else
								sw.Write("null\t");

							if (sFullShapeName != "")
								sw.Write(sFullShapeName+"\t");
							else
								sw.Write("null\t");

							if (sCPPropertyCustomerID != "")
								sw.Write(sCPPropertyCustomerID + "\t");
							else
								sw.Write("null\t");

							if (sSKU != "")
								sw.WriteLine(sSKU);
							else
								sw.WriteLine("null");
							
						}						
							
					}

					
					
					//sw.Write();

					sw.Close();
				}
				catch(Exception eEx)
				{
					if(MessageBox.Show("Error sending document " + sFullCode + "\n" + eEx.Message + 
						"\nContinue sending other documents?", 
						"Send error", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No)
					{
						this.Cursor = Cursors.Default;
						sbStatus.Text = "Operation was interrupted";
						return;
					}
				}
				
			}

			for(int i=0;i<dsIndex.Tables.Count;i++)
			{
				System.IO.StreamWriter sw=new System.IO.StreamWriter(sSendPath+dsIndex.Tables[i].TableName+".txt",false);
				foreach(DataRow rT in dsIndex.Tables[i].Rows)
				{
					sw.WriteLine(rT[0].ToString()+".txt");
				}
				sw.Close();
			}

			System.IO.StreamWriter sw1=new System.IO.StreamWriter(sSendPath+"index.txt",false);
			foreach(DataTable tblT in dsIndex.Tables)
			{
				sw1.WriteLine(tblT.TableName+".txt");
			}

			sw1.Close();
			
			
			//	Service.SendDocument(sTemplatePath, sSendPath, sFileExt, iOrderCode, iBatchCode, iItemCode, cDocChar.ToString());			
			sbStatus.Text = "Ready";
			this.Cursor = Cursors.Default;			

		}

		private void btnSend_Click(object sender, System.EventArgs e)
		{
			MakeTextFile2();
			return ;
			// WTF is that?????????????????????????????

			//			DataSet ds = this.otDocs.GetChecked();
			//			String s = this.tbDocId.Text;
			//			gemoDream.Service.MakeTextFile3(ds, s);

			//gemoDream.Service.
			//MakeTextFile2();

			return;

			this.Cursor = Cursors.WaitCursor;
			sbStatus.Text = "Depending on type of chosen documents this operation can take up to 10 minutes";
			
			/*try
			{
				string sEmail = cbEmail.SelectedValue.ToString();
				string sFileType = cbFileType.SelectedValue.ToString();
				string sFilePath = @"c:\instal\ServiceCfg";
				Service.SendDocumentByEmail(sEmail, sFileType, sFilePath);
				MessageBox.Show("Document "+otDocs.Selected.NodeCode+" was sent successfully to e-mail "+cbEmail.SelectedValue.ToString(), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch(Exception eEx)
			{
				MessageBox.Show("Couldn't send document "+otDocs.Selected.NodeCode+" to e-mail "+cbEmail.SelectedValue.ToString()+"\n"+eEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}*/
			
			
			string sFileExt = cbFileType.SelectedValue.ToString();
			sFileExt = sFileExt.Substring(1, sFileExt.Length-1).ToLower();
			DataSet dsChecked = otDocs.GetChecked();

			string sRepPath = Service.GetCRTemplatePath();
			CrystalReport.CrystalReport crRpt=new CrystalReport.CrystalReport(sRepPath);
			string sendToPath = Service.GetServiceCfgParameter("sendDir");
			crRpt.XL_Report(dsChecked.Tables["tblDocuments"].Copy(), sendToPath);

			foreach(DataRow drChecked in dsChecked.Tables["tblDocuments"].Rows)
			{
				string sFullCode = drChecked["Name"].ToString();
				try
				{					
					ParseDisplayDocumentCode(sFullCode);
					//string sSendPath = cbEmail.SelectedValue.ToString();
					string sSendPath = Service.GetServiceCfgParameter("locSendDir");
				
				
					int iOperationTypeOfficeId = Convert.ToInt32(drChecked["OperationTypeOfficeID"]);
					int iOperationTypeId = Convert.ToInt32(drChecked["OperationTypeID"]);
					string sTemplatePath = Service.GetOperationTemplatePath(iOperationTypeOfficeId, iOperationTypeId);
				
					crRpt.PDF_Report(sTemplatePath,Convert.ToInt32(drChecked["GroupCode"]),Convert.ToInt32(drChecked["BatchCode"]),Convert.ToInt32(drChecked["ItemCode"]), drChecked["OperationChar"].ToString());
				
					string sFileName = drChecked["OperationChar"].ToString() + 
						drChecked["GroupCode"].ToString() + "." + 
						drChecked["BatchCode"].ToString() + "." + 
						drChecked["ItemCode"].ToString();
					crRpt.Export(sRepPath, sFileName, sFileExt);

				
					gemoDream.Service.MoveFileToSendDir(sFileName+"."+sFileExt);
				}
				catch(Exception eEx)
				{
					if(MessageBox.Show("Error sending document " + sFullCode + "\n" + eEx.Message + 
						"\nContinue sending other documents?", 
						"Send error", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No)
					{
						this.Cursor = Cursors.Default;
						sbStatus.Text = "Operation was interrupted";
						return;
					}
				}
			}			
			//	Service.SendDocument(sTemplatePath, sSendPath, sFileExt, iOrderCode, iBatchCode, iItemCode, cDocChar.ToString());			
			sbStatus.Text = "Ready";
			this.Cursor = Cursors.Default;
		}

		private void tbDocId_Enter(object sender, System.EventArgs e)
		{
			tbDocId.Text = "";
		}

		private void otDocs_SelectedItemChanged(object sender, System.EventArgs e)
		{
			if(!IsDocumentSelected())
			{
				tbDocId.Text = "[a-z]#####.#####.###.##";
				btnDelete.Enabled = false;
				btnView.Enabled = false;
				btnPrint.Enabled = false;
				btnSend.Enabled = false;
				cbEmail.Enabled = false;
				cbFileType.Enabled = false;
				return;
			}
			tbDocId.Text = otDocs.Selected.NodeCode;

			DataRow drSelected = otDocs.Selected.drNode;
			int iDocState = Convert.ToInt32(drSelected["StateCode"]);
			//DataView dvDocType = new DataView(dsDocs.Tables["tblDocument"]);
			//dvDocType.RowFilter = "Name='"+otDocs.Selected.NodeCode+"'";
			//int iDocState = Convert.ToInt32(dvDocType[0]["StateCode"]);
			switch(iDocState)
			{
				case DocumentState.UnReady:
					btnDelete.Enabled = true;
					btnView.Enabled = false;
					btnPrint.Enabled = false;
					btnSend.Enabled = false;
					btnSendBackground.Enabled = false;
					cbEmail.Enabled = false;
					cbFileType.Enabled = false;
					break;

				case DocumentState.UnPrinted:
					btnDelete.Enabled = true;
					btnView.Enabled = true;
					btnPrint.Enabled = true;
					btnSend.Enabled = false;
					btnSendBackground.Enabled = true;
					//cbEmail.Enabled = true;
					cbEmail.Enabled = false;
					cbFileType.Enabled = true;
					break;

				case DocumentState.Printed:
					btnDelete.Enabled = false;
					btnView.Enabled = true;
					btnPrint.Enabled = true;
					btnSend.Enabled = false;
					btnSendBackground.Enabled = true;
					//cbEmail.Enabled = true;
					cbEmail.Enabled = false;
					cbFileType.Enabled = true;
					break;

				case DocumentState.Closed:
					btnDelete.Enabled = false;
					btnView.Enabled = true;
					btnPrint.Enabled = true;
					btnSend.Enabled = false;
					btnSendBackground.Enabled = true;
					//cbEmail.Enabled = true;
					cbEmail.Enabled = false;
					cbFileType.Enabled = true;
					break;

				default:
					break;
			}
			btnSend.Enabled = false;
		}


		private void ParseDocumentCode()
		{
			iOrderCode = 0;
			iEntryBatchCode = 0;
			iBatchCode = 0;
			iItemCode = 0;

			switch(tbDocId.Text.Length)
			{
				case DOC_ITEM_CODE:
					cDocChar = Convert.ToChar(tbDocId.Text.Substring(0, DOC_ITEM_CODE_FORMAT[0]));
					iOrderCode = Convert.ToInt32(tbDocId.Text.Substring(ITEM_DOT1, DOC_ITEM_CODE_FORMAT[1]));
					iEntryBatchCode = Convert.ToInt32(tbDocId.Text.Substring(ITEM_DOT1, DOC_ITEM_CODE_FORMAT[1]));
					iBatchCode = Convert.ToInt32(tbDocId.Text.Substring(ITEM_DOT2, DOC_ITEM_CODE_FORMAT[2]));
					iItemCode = Convert.ToInt32(tbDocId.Text.Substring(ITEM_DOT3, DOC_ITEM_CODE_FORMAT[3]));
					break;
				case DOC_BATCH_CODE:
					cDocChar = Convert.ToChar(tbDocId.Text.Substring(0, DOC_BATCH_CODE_FORMAT[0]));
					iOrderCode = Convert.ToInt32(tbDocId.Text.Substring(BATCH_DOT1, DOC_BATCH_CODE_FORMAT[1]));
					iEntryBatchCode = Convert.ToInt32(tbDocId.Text.Substring(BATCH_DOT1, DOC_BATCH_CODE_FORMAT[1]));
					iBatchCode = Convert.ToInt32(tbDocId.Text.Substring(BATCH_DOT2, DOC_BATCH_CODE_FORMAT[2]));
					break;
				case DOC_ORDER_CODE:
					cDocChar = Convert.ToChar(tbDocId.Text.Substring(0, DOC_ORDER_CODE_FORMAT[0]));
					iOrderCode = Convert.ToInt32(tbDocId.Text.Substring(ORDER_DOT1, DOC_ORDER_CODE_FORMAT[1]));
					iEntryBatchCode = Convert.ToInt32(tbDocId.Text.Substring(ORDER_DOT1, DOC_ORDER_CODE_FORMAT[1]));
					break;
				default:
					throw new Exception("Document code length is incorrect");
			}
		}

		private void ParseDisplayDocumentCode(string sCode)
		{
			iOrderCode = 0;
			iEntryBatchCode = 0;
			iBatchCode = 0;
			iItemCode = 0;

			switch(sCode.Length)
			{
				case DOC_ITEM_DISPLAY_CODE:
					cDocChar = Convert.ToChar(tbDocId.Text.Substring(0, DOC_ITEM_DISPLAY_CODE_FORMAT[0]));
					iOrderCode = Convert.ToInt32(tbDocId.Text.Substring(DISPLAY_ITEM_DOT1, DOC_ITEM_DISPLAY_CODE_FORMAT[1]));
					iEntryBatchCode = Convert.ToInt32(tbDocId.Text.Substring(DISPLAY_ITEM_DOT1, DOC_ITEM_DISPLAY_CODE_FORMAT[1]));
					iBatchCode = Convert.ToInt32(tbDocId.Text.Substring(DISPLAY_ITEM_DOT3, DOC_ITEM_DISPLAY_CODE_FORMAT[3]));
					iItemCode = Convert.ToInt32(tbDocId.Text.Substring(DISPLAY_ITEM_DOT4, DOC_ITEM_DISPLAY_CODE_FORMAT[4]));
					break;
				case DOC_BATCH_DISPLAY_CODE:
					cDocChar = Convert.ToChar(tbDocId.Text.Substring(0, DOC_ITEM_DISPLAY_CODE_FORMAT[0]));
					iOrderCode = Convert.ToInt32(tbDocId.Text.Substring(DISPLAY_ITEM_DOT1, DOC_ITEM_DISPLAY_CODE_FORMAT[1]));
					iEntryBatchCode = Convert.ToInt32(tbDocId.Text.Substring(DISPLAY_ITEM_DOT1, DOC_ITEM_DISPLAY_CODE_FORMAT[1]));
					iBatchCode = Convert.ToInt32(tbDocId.Text.Substring(DISPLAY_ITEM_DOT3, DOC_ITEM_DISPLAY_CODE_FORMAT[3]));
					break;
				case DOC_ORDER_DISPLAY_CODE:
					cDocChar = Convert.ToChar(tbDocId.Text.Substring(0, DOC_ITEM_DISPLAY_CODE_FORMAT[0]));
					iOrderCode = Convert.ToInt32(tbDocId.Text.Substring(DISPLAY_ITEM_DOT1, DOC_ITEM_DISPLAY_CODE_FORMAT[1]));
					iEntryBatchCode = Convert.ToInt32(tbDocId.Text.Substring(DISPLAY_ITEM_DOT1, DOC_ITEM_DISPLAY_CODE_FORMAT[1]));
					break;
				default:
					throw new Exception("Document code length is incorrect");
			}
		}

		private string GetCorrectFullCodeString()
		{
			string sDocCode = cDocChar.ToString();

			if(iOrderCode > 0)
				sDocCode += GetCorrectCodeString(iOrderCode, DOC_ITEM_CODE_FORMAT[1]);
			if(iEntryBatchCode > 0)
				sDocCode += "."+GetCorrectCodeString(iEntryBatchCode, DOC_ITEM_CODE_FORMAT[1]);
			if(iBatchCode > 0)
				sDocCode += "."+GetCorrectCodeString(iBatchCode, DOC_ITEM_CODE_FORMAT[2]);
			if(iItemCode > 0)
				sDocCode += "."+GetCorrectCodeString(iItemCode, DOC_ITEM_CODE_FORMAT[3]);

			return sDocCode;
		}

		private string GetCorrectCodeString(int iCode, int iCodeLength)
		{
			string sCode = iCode.ToString();
			while(sCode.Length < iCodeLength)
				sCode = "0"+sCode;

			return sCode;
		}

		/*private object GetDocumentIdentifier(string sFullCode)
		{
			DataView dvDocs = new DataView(dsDocs.Tables["tblDocument"]);
			dvDocs.RowFilter = "BatchCode="+iBatchCode+" and GroupCode="+iOrderCode+" and ItemCode="+iItemCode+" and OperationChar='"+cDocChar+"'";
			//dvDocs.RowFilter = "Code='"+sFullCode+"'";

			//object oId = dvDocs[0]["ID"];
			return dvDocs[0]["ID"];
		}*/

		private bool IsDocumentSelected()
		{
			string sDocCode = otDocs.Selected.NodeCode;
			if( sDocCode.Length == DOC_ORDER_CODE+6 || sDocCode.Length == DOC_BATCH_CODE+7 || sDocCode.Length == DOC_ITEM_CODE+8)
				return true;

			return false;
		}

		private CrystalReport.CrystalReport Export2CrystalReport(DataSet dsChecked)
		{			
			string sFullCode = otDocs.Selected.NodeCode;
			ParseDisplayDocumentCode(sFullCode);

			string sRepPath = Service.GetCRTemplatePath();
			CrystalReport.CrystalReport crRpt = new CrystalReport.CrystalReport(sRepPath);

			int iOperationTypeOfficeId = Convert.ToInt32(otDocs.Selected.drNode["OperationTypeOfficeID"]);
			int iOperationTypeId = Convert.ToInt32(otDocs.Selected.drNode["OperationTypeID"]);
			string sTemplatePath = Service.GetOperationTemplatePath(iOperationTypeOfficeId, iOperationTypeId);

			crRpt.isView=true;
			crRpt.PDF_Report(sTemplatePath, iOrderCode, iBatchCode, iItemCode, cDocChar.ToString());
			//crRpt.FDXR1(iOrderCode, iBatchCode, iItemCode);

			string sFileType = cbFileType.SelectedValue.ToString();
			sFileType = sFileType.Substring(1, sFileType.Length-1).ToLower();
			crRpt.Export(sFileType);

			return crRpt;
		}

		private void chbFilter_CheckedChanged(object sender, System.EventArgs e)
		{
			gbFilterBy.Enabled = chbFilter.Checked;
		}

		private void chbFilterCustomer_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chbFilterCustomer.Checked)
			{
				CustomerComboText.Enabled = true;
				CustomerComboText.Focus();
			}
			else
			{
				CustomerComboText.Enabled = false;
			}
		}

		private void chbFilterOrder_CheckedChanged(object sender, System.EventArgs e)
		{
			tbFilterOrder.Enabled = chbFilterOrder.Checked;
			if(chbFilterOrder.Checked)
				tbFilterOrder.Focus();
		}

		private void chbFilterBatch_CheckedChanged(object sender, System.EventArgs e)
		{
			tbFilterBatch.Enabled = chbFilterBatch.Checked;
			if(chbFilterBatch.Checked)
				tbFilterBatch.Focus();
		}

		private void tbFilterCustomer_Enter(object sender, System.EventArgs e)
		{
			tbFilterCustomer.SelectAll();
		}

		private void tbFilterOrder_Enter(object sender, System.EventArgs e)
		{
			tbFilterOrder.SelectAll();
		}

		private void tbFilterBatch_Enter(object sender, System.EventArgs e)
		{
			tbFilterBatch.SelectAll();
		}

		private void bRunFilter_Click(object sender, System.EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			this.sbStatus.Text = "Loading documents from database. Please, wait.";

			int state = 0;
			if(rbPrinted.Checked)
			{
				state = DocumentState.Printed;
			}
			else if(rbUnprinted.Checked)
			{
				state = DocumentState.UnPrinted;
			}
			else if(rbAll.Checked)
			{
				state = 0;
			}

			GetDocumentsByState(state);

			this.Cursor = Cursors.Default;
			this.sbStatus.Text = "Ready";
		}

		private void tbFilterOrder_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(tbFilterOrder.Text.Length == 4)
			{
				try
				{
					Convert.ToInt32(tbFilterOrder.Text);
					tbFilterOrder.Text += e.KeyChar.ToString() + "." + tbFilterOrder.Text + e.KeyChar.ToString();
				}
				catch
				{
					MessageBox.Show("Order name must be numeric", "Wrong order name", MessageBoxButtons.OK,
						MessageBoxIcon.Warning);
					tbFilterOrder.Clear();
				}
			}
		}

		private void tbFilterCustomerName_Enter(object sender, System.EventArgs e)
		{
			tbFilterCustomer.SelectAll();
		}

		private void rbPrinted_CheckedChanged(object sender, System.EventArgs e)
		{
			if(!rbPrinted.Checked)
				return;

			//GetDocumentsByState(DocumentState.Printed);
		}

		private void rbUnprinted_CheckedChanged(object sender, System.EventArgs e)
		{
			if(!rbUnprinted.Checked)
				return;

			//GetDocumentsByState(DocumentState.UnPrinted);
		}

		private void rbAll_CheckedChanged(object sender, System.EventArgs e)
		{
			if(!rbAll.Checked)
				return;

			//GetDocumentsByState(0);
		}

		private DataSet SortDocuments(DataSet dsUnsortedDocs)
		{
			DataTable dtDocsSorted = dsUnsortedDocs.Tables["tblDocuments"].Clone();
			dsDocsSorted = new DataSet();
			dsDocsSorted.Tables.Add(dtDocsSorted);

			DataView dvDocs = new DataView(dsUnsortedDocs.Tables["tblDocuments"].Copy());
			dvDocs.Sort = "GroupCode, BatchCode, ItemCode, Name, OperationChar";
			for(int i = 0; i < dvDocs.Count; i++)
				dtDocsSorted.Rows.Add(dvDocs[i].Row.ItemArray);

			return dsDocsSorted;
		}

		private void GetDocumentsByState(int iDocState)
		{
			if(!(dsDocuments == null))
			{
				dsDocuments.Clear();
			}

			DataSet dsPrms = new DataSet();
			DataTable dtPrms = dsPrms.Tables.Add("ItemDocByCodeTypeEx");
			dsPrms = Service.ProxyGenericGet(dsPrms);

			dtPrms = dsPrms.Tables[0];
			dtPrms.TableName = "ItemDocByCode4Printing";
			DataRow drPrms = dtPrms.Rows.Add(new object[] {});
			if(iDocState > 0)
			{				
				drPrms["BState"] = iDocState;
				drPrms["EState"] = iDocState;
			}
			else
			{
				drPrms["BState"] = System.Convert.DBNull;
				drPrms["EState"] = System.Convert.DBNull;
			}
			iCurDocState = iDocState;
			//by Vetal_242
			if(chbFilter.Checked)
			{
				if(!chbFilterBatch.Checked && !chbFilterCustomer.Checked && !chbFilterOrder.Checked)
				{
					MessageBox.Show("Please, select one or more conditions for filter.","No filters selected", MessageBoxButtons.OK ,MessageBoxIcon.Error);
					return;
				}
				if(chbFilterCustomer.Checked)
				{				
					drPrms["CustomerCode"] = CustomerComboText.SelectedID;
				}
				if(chbFilterOrder.Checked && tbFilterOrder.Text.Length == 11)
				{
					try
					{
						Convert.ToInt32(tbFilterOrder.Text.Split(new char[] {'.'})[0]);
						Convert.ToInt32(tbFilterOrder.Text.Split(new char[] {'.'})[1]);

						if(tbFilterOrder.Text.Split(new char[] {'.'})[0] !=
							tbFilterOrder.Text.Split(new char[] {'.'})[1])
						{
							throw new Exception();
						}
						drPrms["GroupCode"] = Convert.ToInt32(tbFilterOrder.Text.Split(new char[] {'.'})[0]);
					}
					catch
					{
						MessageBox.Show("Wrong order format", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}
				}

				if(chbFilterBatch.Checked && tbFilterBatch.Text.Length == 3)
				{
					try
					{
						drPrms["BatchCode"] = Convert.ToInt32(tbFilterBatch.Text);					
					}
					catch
					{
						MessageBox.Show("Wrong batch format", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}
				}
			}
			//end by Vetal_242
			dsDocuments = Service.ProxyGenericGet(dsPrms);
			DataTable dtDocuments = dsDocuments.Tables[0];
			dtDocuments.TableName = "tblDocuments";
			dtDocuments.Columns["ItemOperationOfficeID_ItemOperationID"].ColumnName = "ID";
			dtDocuments.Columns.Add("Hide");
			dtDocuments.Columns.Add("Name");
			foreach(DataRow drDocument in dtDocuments.Rows)
			{
				drDocument["Hide"] = "0";

				//GroupCode, BatchCode, ItemCode, Name, OperationChar
				string sName = drDocument["OperationChar"].ToString();
				if(!Convert.IsDBNull(drDocument["GroupCode"]))
				{
					string sGroup = GetCorrectCodeString(Convert.ToInt32(drDocument["GroupCode"]), 5);
					sName += sGroup+"."+sGroup;
				}
				if(!Convert.IsDBNull(drDocument["BatchCode"]))
					sName += "."+GetCorrectCodeString(Convert.ToInt32(drDocument["BatchCode"]), 3);
				if(!Convert.IsDBNull(drDocument["ItemCode"]))
					sName += "."+GetCorrectCodeString(Convert.ToInt32(drDocument["ItemCode"]), 2);

				drDocument["Name"] = sName;
			}

			DataSet dsDocsSorted = SortDocuments(dsDocuments);
			otDocs.Initialize(dsDocsSorted, "tblDocuments");
		}

		private void btnSendBackground_Click(object sender, System.EventArgs e)
		{
			DataSet ds = this.otDocs.GetChecked();
			String s = this.tbDocId.Text;
			gemoDream.Service.MakeTextFile3(ds, s);
		}

		private void CustomerComboText_SelectionChanged(object sender, System.EventArgs e)
		{	
		}

		private void tbFilterBatch_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				bRunFilter_Click(sender, e);
			}
		}

		private void CustomerComboText_CodeEntered(object sender, System.EventArgs e)
		{
			bRunFilter_Click(sender, e);
		}
	}
}
