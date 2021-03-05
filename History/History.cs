using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text.RegularExpressions;

namespace gemoDream
{
	/// <summary>
	/// Summary description for History.
	/// </summary>
	public class History : System.Windows.Forms.Form
	{
		//private CMStrategy.CMStrategy cmstrategy;
		public enum FilterState
		{
			NotValid    = 1,
			Valid       = 2,
			NotEntered  = 3
		}
		public class Filters
		{
			public FilterState IsCustomerSelected = FilterState.NotEntered;
			public FilterState IsGroupCodeEntered = FilterState.NotEntered;
			public FilterState IsBatchCodeEntered = FilterState.NotEntered;
			public FilterState IsItemCodeEntered = FilterState.NotEntered;
			public FilterState IsAuthorSelected = FilterState.NotEntered;
		}
		private DataSet dsAuthors = new DataSet();
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tbCustomer;
		private System.Windows.Forms.TabPage tbOrder;
		private System.Windows.Forms.TabPage tbBatch;
		private System.Windows.Forms.TabPage tbItem;
		private System.Windows.Forms.Label lbItemGroupCode;
		private System.Windows.Forms.TextBox tbItemGroupCode;
		private System.Windows.Forms.Label lbItemBatchCode;
		private System.Windows.Forms.TextBox tbItemBatchCode;
		private System.Windows.Forms.Label lbItemItemCode;
		private System.Windows.Forms.TextBox tbItemItemCode;
		private System.Windows.Forms.Label lbItemFrom;
		private System.Windows.Forms.DateTimePicker dtpItemFrom;
		private System.Windows.Forms.Label lbItemTo;
		private System.Windows.Forms.DateTimePicker dtpItemTo;
		private System.Windows.Forms.Label lbItemAuthor;
		private System.Windows.Forms.ComboBox cbItemAuthor;
		private System.Windows.Forms.Label lbCustomerCustomer;
		private System.Windows.Forms.Label lbCustomerFrom;
		private System.Windows.Forms.DateTimePicker dtpCustomerFrom;
		private System.Windows.Forms.Label lbCustomerTo;
		private System.Windows.Forms.DateTimePicker dtpCustomerTo;
		private System.Windows.Forms.Label lbCustomerAuthor;
		private System.Windows.Forms.ComboBox cbCustomerAuthor;
		private System.Windows.Forms.Button btnCustomerApply;
		private System.Windows.Forms.Label lbOrderOrder;
		private System.Windows.Forms.Label lbOrderFrom;
		private System.Windows.Forms.DateTimePicker dtpOrderFrom;
		private System.Windows.Forms.Label lbOrderTo;
		private System.Windows.Forms.DateTimePicker dtpOrderTo;
		private System.Windows.Forms.Label lbOrderAuthor;
		private System.Windows.Forms.ComboBox cbOrderAuthor;
		private System.Windows.Forms.Button btnOrderApply;
		private System.Windows.Forms.Label lbBatchGroupCode;
		private System.Windows.Forms.Label lbBatchBatchCode;
		private System.Windows.Forms.TextBox tbBatchBatchCode;
		private System.Windows.Forms.Label lbBatchFrom;
		private System.Windows.Forms.DateTimePicker dtpBatchFrom;
		private System.Windows.Forms.Label lbBatchTo;
		private System.Windows.Forms.DateTimePicker dtpBatchTo;
		private System.Windows.Forms.Label lbBatchAuthor;
		private System.Windows.Forms.ComboBox cbBatchAuthor;
		private System.Windows.Forms.Button btnBatchApply;
		private System.Windows.Forms.Button btnItemApply;
		private System.Windows.Forms.TextBox tbBatchGroupCode;
		private System.Windows.Forms.TextBox tbOrderOrderCode;
		private System.Windows.Forms.StatusBar sbStatus;
		private System.Windows.Forms.DataGrid dgCustomer;
		private System.Windows.Forms.DataGrid dgOrder;
		private System.Windows.Forms.DataGrid dgBatch;
		private System.Windows.Forms.DataGrid dgItem;
		private System.Windows.Forms.TextBox tbItemNumber;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGrid dgItemCreationHistory;
		private Cntrls.ItemNumberControl incNumber;
		private System.Windows.Forms.Button btnClearHistory;
		private Cntrls.ComboTextComponent cbcCustomerCustomer;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cbParts;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public History(int iSecurityLevel)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			InitCustomer(iSecurityLevel);
			InitOrder(iSecurityLevel);
			InitBatch(iSecurityLevel);
			InitItem(iSecurityLevel);
			tabControl.SelectedIndex = 0;
			tbItemNumber.Focus();
			
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(History));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tbItem = new System.Windows.Forms.TabPage();
            this.btnClearHistory = new System.Windows.Forms.Button();
            this.dgItemCreationHistory = new System.Windows.Forms.DataGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.dgItem = new System.Windows.Forms.DataGrid();
            this.btnItemApply = new System.Windows.Forms.Button();
            this.cbItemAuthor = new System.Windows.Forms.ComboBox();
            this.lbItemAuthor = new System.Windows.Forms.Label();
            this.dtpItemTo = new System.Windows.Forms.DateTimePicker();
            this.lbItemTo = new System.Windows.Forms.Label();
            this.dtpItemFrom = new System.Windows.Forms.DateTimePicker();
            this.lbItemFrom = new System.Windows.Forms.Label();
            this.tbItemItemCode = new System.Windows.Forms.TextBox();
            this.lbItemItemCode = new System.Windows.Forms.Label();
            this.tbItemBatchCode = new System.Windows.Forms.TextBox();
            this.lbItemBatchCode = new System.Windows.Forms.Label();
            this.tbItemGroupCode = new System.Windows.Forms.TextBox();
            this.lbItemGroupCode = new System.Windows.Forms.Label();
            this.tbItemNumber = new System.Windows.Forms.TextBox();
            this.cbParts = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbOrder = new System.Windows.Forms.TabPage();
            this.dgOrder = new System.Windows.Forms.DataGrid();
            this.btnOrderApply = new System.Windows.Forms.Button();
            this.cbOrderAuthor = new System.Windows.Forms.ComboBox();
            this.lbOrderAuthor = new System.Windows.Forms.Label();
            this.dtpOrderTo = new System.Windows.Forms.DateTimePicker();
            this.lbOrderTo = new System.Windows.Forms.Label();
            this.dtpOrderFrom = new System.Windows.Forms.DateTimePicker();
            this.lbOrderFrom = new System.Windows.Forms.Label();
            this.tbOrderOrderCode = new System.Windows.Forms.TextBox();
            this.lbOrderOrder = new System.Windows.Forms.Label();
            this.tbCustomer = new System.Windows.Forms.TabPage();
            this.cbcCustomerCustomer = new Cntrls.ComboTextComponent();
            this.dgCustomer = new System.Windows.Forms.DataGrid();
            this.btnCustomerApply = new System.Windows.Forms.Button();
            this.cbCustomerAuthor = new System.Windows.Forms.ComboBox();
            this.lbCustomerAuthor = new System.Windows.Forms.Label();
            this.dtpCustomerTo = new System.Windows.Forms.DateTimePicker();
            this.lbCustomerTo = new System.Windows.Forms.Label();
            this.dtpCustomerFrom = new System.Windows.Forms.DateTimePicker();
            this.lbCustomerFrom = new System.Windows.Forms.Label();
            this.lbCustomerCustomer = new System.Windows.Forms.Label();
            this.tbBatch = new System.Windows.Forms.TabPage();
            this.dgBatch = new System.Windows.Forms.DataGrid();
            this.btnBatchApply = new System.Windows.Forms.Button();
            this.cbBatchAuthor = new System.Windows.Forms.ComboBox();
            this.lbBatchAuthor = new System.Windows.Forms.Label();
            this.dtpBatchTo = new System.Windows.Forms.DateTimePicker();
            this.lbBatchTo = new System.Windows.Forms.Label();
            this.dtpBatchFrom = new System.Windows.Forms.DateTimePicker();
            this.lbBatchFrom = new System.Windows.Forms.Label();
            this.tbBatchBatchCode = new System.Windows.Forms.TextBox();
            this.lbBatchBatchCode = new System.Windows.Forms.Label();
            this.tbBatchGroupCode = new System.Windows.Forms.TextBox();
            this.lbBatchGroupCode = new System.Windows.Forms.Label();
            this.sbStatus = new System.Windows.Forms.StatusBar();
            this.tabControl.SuspendLayout();
            this.tbItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItemCreationHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgItem)).BeginInit();
            this.tbOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgOrder)).BeginInit();
            this.tbCustomer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCustomer)).BeginInit();
            this.tbBatch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBatch)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tbItem);
            this.tabControl.Controls.Add(this.tbOrder);
            this.tabControl.Controls.Add(this.tbCustomer);
            this.tabControl.Controls.Add(this.tbBatch);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 1;
            this.tabControl.Size = new System.Drawing.Size(990, 685);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tbItem
            // 
            this.tbItem.Controls.Add(this.btnClearHistory);
            this.tbItem.Controls.Add(this.dgItemCreationHistory);
            this.tbItem.Controls.Add(this.label1);
            this.tbItem.Controls.Add(this.dgItem);
            this.tbItem.Controls.Add(this.btnItemApply);
            this.tbItem.Controls.Add(this.cbItemAuthor);
            this.tbItem.Controls.Add(this.lbItemAuthor);
            this.tbItem.Controls.Add(this.dtpItemTo);
            this.tbItem.Controls.Add(this.lbItemTo);
            this.tbItem.Controls.Add(this.dtpItemFrom);
            this.tbItem.Controls.Add(this.lbItemFrom);
            this.tbItem.Controls.Add(this.tbItemItemCode);
            this.tbItem.Controls.Add(this.lbItemItemCode);
            this.tbItem.Controls.Add(this.tbItemBatchCode);
            this.tbItem.Controls.Add(this.lbItemBatchCode);
            this.tbItem.Controls.Add(this.tbItemGroupCode);
            this.tbItem.Controls.Add(this.lbItemGroupCode);
            this.tbItem.Controls.Add(this.tbItemNumber);
            this.tbItem.Controls.Add(this.cbParts);
            this.tbItem.Controls.Add(this.label2);
            this.tbItem.Location = new System.Drawing.Point(4, 21);
            this.tbItem.Name = "tbItem";
            this.tbItem.Size = new System.Drawing.Size(982, 660);
            this.tbItem.TabIndex = 3;
            this.tbItem.Text = "Item";
            // 
            // btnClearHistory
            // 
            this.btnClearHistory.Location = new System.Drawing.Point(400, 8);
            this.btnClearHistory.Name = "btnClearHistory";
            this.btnClearHistory.Size = new System.Drawing.Size(80, 20);
            this.btnClearHistory.TabIndex = 17;
            this.btnClearHistory.Text = "Clear History";
            this.btnClearHistory.Click += new System.EventHandler(this.btnClearHistory_Click);
            // 
            // dgItemCreationHistory
            // 
            this.dgItemCreationHistory.AllowNavigation = false;
            this.dgItemCreationHistory.CaptionVisible = false;
            this.dgItemCreationHistory.CausesValidation = false;
            this.dgItemCreationHistory.DataMember = "";
            this.dgItemCreationHistory.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgItemCreationHistory.Location = new System.Drawing.Point(528, 8);
            this.dgItemCreationHistory.Name = "dgItemCreationHistory";
            this.dgItemCreationHistory.ParentRowsVisible = false;
            this.dgItemCreationHistory.ReadOnly = true;
            this.dgItemCreationHistory.RowHeadersVisible = false;
            this.dgItemCreationHistory.Size = new System.Drawing.Size(456, 88);
            this.dgItemCreationHistory.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Full item #";
            // 
            // dgItem
            // 
            this.dgItem.AllowNavigation = false;
            this.dgItem.CaptionVisible = false;
            this.dgItem.CausesValidation = false;
            this.dgItem.DataMember = "";
            this.dgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgItem.Location = new System.Drawing.Point(0, 96);
            this.dgItem.Name = "dgItem";
            this.dgItem.ParentRowsVisible = false;
            this.dgItem.ReadOnly = true;
            this.dgItem.RowHeadersVisible = false;
            this.dgItem.Size = new System.Drawing.Size(984, 560);
            this.dgItem.TabIndex = 13;
            // 
            // btnItemApply
            // 
            this.btnItemApply.Location = new System.Drawing.Point(304, 8);
            this.btnItemApply.Name = "btnItemApply";
            this.btnItemApply.Size = new System.Drawing.Size(80, 20);
            this.btnItemApply.TabIndex = 12;
            this.btnItemApply.Text = "Get History";
            this.btnItemApply.Click += new System.EventHandler(this.btnItemApply_Click);
            // 
            // cbItemAuthor
            // 
            this.cbItemAuthor.Location = new System.Drawing.Point(360, 72);
            this.cbItemAuthor.Name = "cbItemAuthor";
            this.cbItemAuthor.Size = new System.Drawing.Size(120, 20);
            this.cbItemAuthor.TabIndex = 11;
            // 
            // lbItemAuthor
            // 
            this.lbItemAuthor.Location = new System.Drawing.Point(312, 72);
            this.lbItemAuthor.Name = "lbItemAuthor";
            this.lbItemAuthor.Size = new System.Drawing.Size(40, 20);
            this.lbItemAuthor.TabIndex = 10;
            this.lbItemAuthor.Text = "Author";
            this.lbItemAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpItemTo
            // 
            this.dtpItemTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpItemTo.Location = new System.Drawing.Point(200, 72);
            this.dtpItemTo.Name = "dtpItemTo";
            this.dtpItemTo.Size = new System.Drawing.Size(100, 20);
            this.dtpItemTo.TabIndex = 9;
            // 
            // lbItemTo
            // 
            this.lbItemTo.Location = new System.Drawing.Point(168, 72);
            this.lbItemTo.Name = "lbItemTo";
            this.lbItemTo.Size = new System.Drawing.Size(24, 20);
            this.lbItemTo.TabIndex = 8;
            this.lbItemTo.Text = "To";
            this.lbItemTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpItemFrom
            // 
            this.dtpItemFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpItemFrom.Location = new System.Drawing.Point(64, 72);
            this.dtpItemFrom.Name = "dtpItemFrom";
            this.dtpItemFrom.Size = new System.Drawing.Size(100, 20);
            this.dtpItemFrom.TabIndex = 7;
            // 
            // lbItemFrom
            // 
            this.lbItemFrom.Location = new System.Drawing.Point(16, 72);
            this.lbItemFrom.Name = "lbItemFrom";
            this.lbItemFrom.Size = new System.Drawing.Size(35, 20);
            this.lbItemFrom.TabIndex = 6;
            this.lbItemFrom.Text = "From";
            this.lbItemFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbItemItemCode
            // 
            this.tbItemItemCode.Location = new System.Drawing.Point(360, 40);
            this.tbItemItemCode.MaxLength = 2;
            this.tbItemItemCode.Name = "tbItemItemCode";
            this.tbItemItemCode.Size = new System.Drawing.Size(32, 20);
            this.tbItemItemCode.TabIndex = 5;
            this.tbItemItemCode.Text = "##";
            this.tbItemItemCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbItemItemCode_KeyPress);
            // 
            // lbItemItemCode
            // 
            this.lbItemItemCode.Location = new System.Drawing.Point(280, 40);
            this.lbItemItemCode.Name = "lbItemItemCode";
            this.lbItemItemCode.Size = new System.Drawing.Size(70, 20);
            this.lbItemItemCode.TabIndex = 4;
            this.lbItemItemCode.Text = "Item Code";
            this.lbItemItemCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbItemBatchCode
            // 
            this.tbItemBatchCode.Location = new System.Drawing.Point(224, 40);
            this.tbItemBatchCode.MaxLength = 3;
            this.tbItemBatchCode.Name = "tbItemBatchCode";
            this.tbItemBatchCode.Size = new System.Drawing.Size(48, 20);
            this.tbItemBatchCode.TabIndex = 3;
            this.tbItemBatchCode.Text = "###";
            this.tbItemBatchCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbItemBatchCode_KeyPress);
            // 
            // lbItemBatchCode
            // 
            this.lbItemBatchCode.Location = new System.Drawing.Point(160, 40);
            this.lbItemBatchCode.Name = "lbItemBatchCode";
            this.lbItemBatchCode.Size = new System.Drawing.Size(70, 20);
            this.lbItemBatchCode.TabIndex = 2;
            this.lbItemBatchCode.Text = "Batch Code";
            this.lbItemBatchCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbItemGroupCode
            // 
            this.tbItemGroupCode.Location = new System.Drawing.Point(80, 40);
            this.tbItemGroupCode.MaxLength = 6;
            this.tbItemGroupCode.Name = "tbItemGroupCode";
            this.tbItemGroupCode.Size = new System.Drawing.Size(56, 20);
            this.tbItemGroupCode.TabIndex = 1;
            this.tbItemGroupCode.Text = "#####";
            this.tbItemGroupCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbItemGroupCode_KeyPress);
            // 
            // lbItemGroupCode
            // 
            this.lbItemGroupCode.Location = new System.Drawing.Point(8, 40);
            this.lbItemGroupCode.Name = "lbItemGroupCode";
            this.lbItemGroupCode.Size = new System.Drawing.Size(64, 16);
            this.lbItemGroupCode.TabIndex = 0;
            this.lbItemGroupCode.Text = "Order Code";
            this.lbItemGroupCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbItemNumber
            // 
            this.tbItemNumber.Location = new System.Drawing.Point(80, 8);
            this.tbItemNumber.Name = "tbItemNumber";
            this.tbItemNumber.Size = new System.Drawing.Size(184, 20);
            this.tbItemNumber.TabIndex = 1;
            this.tbItemNumber.Text = "";
            this.tbItemNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbItemNumber_KeyDown);
            // 
            // cbParts
            // 
            this.cbParts.Location = new System.Drawing.Point(64, 100);
            this.cbParts.Name = "cbParts";
            this.cbParts.Size = new System.Drawing.Size(240, 20);
            this.cbParts.TabIndex = 19;
            this.cbParts.Visible = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "Part";
            this.label2.Visible = false;
            // 
            // tbOrder
            // 
            this.tbOrder.Controls.Add(this.dgOrder);
            this.tbOrder.Controls.Add(this.btnOrderApply);
            this.tbOrder.Controls.Add(this.cbOrderAuthor);
            this.tbOrder.Controls.Add(this.lbOrderAuthor);
            this.tbOrder.Controls.Add(this.dtpOrderTo);
            this.tbOrder.Controls.Add(this.lbOrderTo);
            this.tbOrder.Controls.Add(this.dtpOrderFrom);
            this.tbOrder.Controls.Add(this.lbOrderFrom);
            this.tbOrder.Controls.Add(this.tbOrderOrderCode);
            this.tbOrder.Controls.Add(this.lbOrderOrder);
            this.tbOrder.Location = new System.Drawing.Point(4, 22);
            this.tbOrder.Name = "tbOrder";
            this.tbOrder.Size = new System.Drawing.Size(982, 659);
            this.tbOrder.TabIndex = 1;
            this.tbOrder.Text = "Order";
            // 
            // dgOrder
            // 
            this.dgOrder.CaptionVisible = false;
            this.dgOrder.DataMember = "";
            this.dgOrder.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgOrder.Location = new System.Drawing.Point(0, 72);
            this.dgOrder.Name = "dgOrder";
            this.dgOrder.ReadOnly = true;
            this.dgOrder.Size = new System.Drawing.Size(932, 552);
            this.dgOrder.TabIndex = 9;
            // 
            // btnOrderApply
            // 
            this.btnOrderApply.Location = new System.Drawing.Point(456, 40);
            this.btnOrderApply.Name = "btnOrderApply";
            this.btnOrderApply.Size = new System.Drawing.Size(56, 20);
            this.btnOrderApply.TabIndex = 8;
            this.btnOrderApply.Text = "&Apply";
            this.btnOrderApply.Click += new System.EventHandler(this.btnOrderApply_Click);
            // 
            // cbOrderAuthor
            // 
            this.cbOrderAuthor.Location = new System.Drawing.Point(328, 40);
            this.cbOrderAuthor.Name = "cbOrderAuthor";
            this.cbOrderAuthor.Size = new System.Drawing.Size(120, 20);
            this.cbOrderAuthor.TabIndex = 7;
            // 
            // lbOrderAuthor
            // 
            this.lbOrderAuthor.Location = new System.Drawing.Point(288, 40);
            this.lbOrderAuthor.Name = "lbOrderAuthor";
            this.lbOrderAuthor.Size = new System.Drawing.Size(40, 20);
            this.lbOrderAuthor.TabIndex = 6;
            this.lbOrderAuthor.Text = "Author";
            this.lbOrderAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpOrderTo
            // 
            this.dtpOrderTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpOrderTo.Location = new System.Drawing.Point(176, 40);
            this.dtpOrderTo.Name = "dtpOrderTo";
            this.dtpOrderTo.Size = new System.Drawing.Size(100, 20);
            this.dtpOrderTo.TabIndex = 5;
            // 
            // lbOrderTo
            // 
            this.lbOrderTo.Location = new System.Drawing.Point(152, 40);
            this.lbOrderTo.Name = "lbOrderTo";
            this.lbOrderTo.Size = new System.Drawing.Size(24, 20);
            this.lbOrderTo.TabIndex = 4;
            this.lbOrderTo.Text = "To";
            this.lbOrderTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpOrderFrom
            // 
            this.dtpOrderFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpOrderFrom.Location = new System.Drawing.Point(40, 40);
            this.dtpOrderFrom.Name = "dtpOrderFrom";
            this.dtpOrderFrom.Size = new System.Drawing.Size(100, 20);
            this.dtpOrderFrom.TabIndex = 3;
            // 
            // lbOrderFrom
            // 
            this.lbOrderFrom.Location = new System.Drawing.Point(5, 40);
            this.lbOrderFrom.Name = "lbOrderFrom";
            this.lbOrderFrom.Size = new System.Drawing.Size(35, 20);
            this.lbOrderFrom.TabIndex = 2;
            this.lbOrderFrom.Text = "From";
            this.lbOrderFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbOrderOrderCode
            // 
            this.tbOrderOrderCode.Location = new System.Drawing.Point(80, 5);
            this.tbOrderOrderCode.MaxLength = 5;
            this.tbOrderOrderCode.Name = "tbOrderOrderCode";
            this.tbOrderOrderCode.Size = new System.Drawing.Size(56, 20);
            this.tbOrderOrderCode.TabIndex = 1;
            this.tbOrderOrderCode.Text = "#####";
            this.tbOrderOrderCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbOrderOrderCode_KeyPress);
            // 
            // lbOrderOrder
            // 
            this.lbOrderOrder.Location = new System.Drawing.Point(5, 5);
            this.lbOrderOrder.Name = "lbOrderOrder";
            this.lbOrderOrder.Size = new System.Drawing.Size(67, 20);
            this.lbOrderOrder.TabIndex = 0;
            this.lbOrderOrder.Text = "Order Code";
            this.lbOrderOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbCustomer
            // 
            this.tbCustomer.Controls.Add(this.cbcCustomerCustomer);
            this.tbCustomer.Controls.Add(this.dgCustomer);
            this.tbCustomer.Controls.Add(this.btnCustomerApply);
            this.tbCustomer.Controls.Add(this.cbCustomerAuthor);
            this.tbCustomer.Controls.Add(this.lbCustomerAuthor);
            this.tbCustomer.Controls.Add(this.dtpCustomerTo);
            this.tbCustomer.Controls.Add(this.lbCustomerTo);
            this.tbCustomer.Controls.Add(this.dtpCustomerFrom);
            this.tbCustomer.Controls.Add(this.lbCustomerFrom);
            this.tbCustomer.Controls.Add(this.lbCustomerCustomer);
            this.tbCustomer.Location = new System.Drawing.Point(4, 22);
            this.tbCustomer.Name = "tbCustomer";
            this.tbCustomer.Size = new System.Drawing.Size(982, 659);
            this.tbCustomer.TabIndex = 0;
            this.tbCustomer.Text = "Customer";
            // 
            // cbcCustomerCustomer
            // 
            this.cbcCustomerCustomer.DefaultText = "";
            this.cbcCustomerCustomer.DisplayMember = "CustomerName";
            this.cbcCustomerCustomer.Location = new System.Drawing.Point(80, 8);
            this.cbcCustomerCustomer.Name = "cbcCustomerCustomer";
            this.cbcCustomerCustomer.SelectedCode = "";
            this.cbcCustomerCustomer.Size = new System.Drawing.Size(448, 24);
            this.cbcCustomerCustomer.TabIndex = 10;
            this.cbcCustomerCustomer.ValueMember = "CustomerOfficeID_CustomerID";
            // 
            // dgCustomer
            // 
            this.dgCustomer.CaptionVisible = false;
            this.dgCustomer.DataMember = "";
            this.dgCustomer.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgCustomer.Location = new System.Drawing.Point(0, 72);
            this.dgCustomer.Name = "dgCustomer";
            this.dgCustomer.ReadOnly = true;
            this.dgCustomer.Size = new System.Drawing.Size(932, 552);
            this.dgCustomer.TabIndex = 9;
            // 
            // btnCustomerApply
            // 
            this.btnCustomerApply.Location = new System.Drawing.Point(456, 40);
            this.btnCustomerApply.Name = "btnCustomerApply";
            this.btnCustomerApply.Size = new System.Drawing.Size(56, 20);
            this.btnCustomerApply.TabIndex = 8;
            this.btnCustomerApply.Text = "&Apply";
            this.btnCustomerApply.Click += new System.EventHandler(this.btnCustomerApply_Click);
            // 
            // cbCustomerAuthor
            // 
            this.cbCustomerAuthor.Location = new System.Drawing.Point(328, 40);
            this.cbCustomerAuthor.Name = "cbCustomerAuthor";
            this.cbCustomerAuthor.Size = new System.Drawing.Size(120, 20);
            this.cbCustomerAuthor.TabIndex = 7;
            // 
            // lbCustomerAuthor
            // 
            this.lbCustomerAuthor.Location = new System.Drawing.Point(288, 40);
            this.lbCustomerAuthor.Name = "lbCustomerAuthor";
            this.lbCustomerAuthor.Size = new System.Drawing.Size(40, 20);
            this.lbCustomerAuthor.TabIndex = 6;
            this.lbCustomerAuthor.Text = "Author";
            this.lbCustomerAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpCustomerTo
            // 
            this.dtpCustomerTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCustomerTo.Location = new System.Drawing.Point(176, 40);
            this.dtpCustomerTo.Name = "dtpCustomerTo";
            this.dtpCustomerTo.Size = new System.Drawing.Size(100, 20);
            this.dtpCustomerTo.TabIndex = 5;
            // 
            // lbCustomerTo
            // 
            this.lbCustomerTo.Location = new System.Drawing.Point(152, 40);
            this.lbCustomerTo.Name = "lbCustomerTo";
            this.lbCustomerTo.Size = new System.Drawing.Size(24, 20);
            this.lbCustomerTo.TabIndex = 4;
            this.lbCustomerTo.Text = "To";
            this.lbCustomerTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpCustomerFrom
            // 
            this.dtpCustomerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCustomerFrom.Location = new System.Drawing.Point(40, 40);
            this.dtpCustomerFrom.Name = "dtpCustomerFrom";
            this.dtpCustomerFrom.Size = new System.Drawing.Size(100, 20);
            this.dtpCustomerFrom.TabIndex = 3;
            // 
            // lbCustomerFrom
            // 
            this.lbCustomerFrom.Location = new System.Drawing.Point(5, 40);
            this.lbCustomerFrom.Name = "lbCustomerFrom";
            this.lbCustomerFrom.Size = new System.Drawing.Size(35, 20);
            this.lbCustomerFrom.TabIndex = 2;
            this.lbCustomerFrom.Text = "From";
            this.lbCustomerFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbCustomerCustomer
            // 
            this.lbCustomerCustomer.Location = new System.Drawing.Point(5, 5);
            this.lbCustomerCustomer.Name = "lbCustomerCustomer";
            this.lbCustomerCustomer.Size = new System.Drawing.Size(70, 20);
            this.lbCustomerCustomer.TabIndex = 1;
            this.lbCustomerCustomer.Text = "Customer";
            this.lbCustomerCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbBatch
            // 
            this.tbBatch.Controls.Add(this.dgBatch);
            this.tbBatch.Controls.Add(this.btnBatchApply);
            this.tbBatch.Controls.Add(this.cbBatchAuthor);
            this.tbBatch.Controls.Add(this.lbBatchAuthor);
            this.tbBatch.Controls.Add(this.dtpBatchTo);
            this.tbBatch.Controls.Add(this.lbBatchTo);
            this.tbBatch.Controls.Add(this.dtpBatchFrom);
            this.tbBatch.Controls.Add(this.lbBatchFrom);
            this.tbBatch.Controls.Add(this.tbBatchBatchCode);
            this.tbBatch.Controls.Add(this.lbBatchBatchCode);
            this.tbBatch.Controls.Add(this.tbBatchGroupCode);
            this.tbBatch.Controls.Add(this.lbBatchGroupCode);
            this.tbBatch.Location = new System.Drawing.Point(4, 22);
            this.tbBatch.Name = "tbBatch";
            this.tbBatch.Size = new System.Drawing.Size(982, 659);
            this.tbBatch.TabIndex = 2;
            this.tbBatch.Text = "Batch";
            // 
            // dgBatch
            // 
            this.dgBatch.CaptionVisible = false;
            this.dgBatch.DataMember = "";
            this.dgBatch.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgBatch.Location = new System.Drawing.Point(0, 72);
            this.dgBatch.Name = "dgBatch";
            this.dgBatch.ReadOnly = true;
            this.dgBatch.Size = new System.Drawing.Size(976, 584);
            this.dgBatch.TabIndex = 11;
            // 
            // btnBatchApply
            // 
            this.btnBatchApply.Location = new System.Drawing.Point(456, 40);
            this.btnBatchApply.Name = "btnBatchApply";
            this.btnBatchApply.Size = new System.Drawing.Size(56, 20);
            this.btnBatchApply.TabIndex = 10;
            this.btnBatchApply.Text = "&Apply";
            this.btnBatchApply.Click += new System.EventHandler(this.btnBatchApply_Click);
            // 
            // cbBatchAuthor
            // 
            this.cbBatchAuthor.Location = new System.Drawing.Point(328, 40);
            this.cbBatchAuthor.Name = "cbBatchAuthor";
            this.cbBatchAuthor.Size = new System.Drawing.Size(120, 20);
            this.cbBatchAuthor.TabIndex = 9;
            // 
            // lbBatchAuthor
            // 
            this.lbBatchAuthor.Location = new System.Drawing.Point(288, 40);
            this.lbBatchAuthor.Name = "lbBatchAuthor";
            this.lbBatchAuthor.Size = new System.Drawing.Size(40, 20);
            this.lbBatchAuthor.TabIndex = 8;
            this.lbBatchAuthor.Text = "Author";
            this.lbBatchAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpBatchTo
            // 
            this.dtpBatchTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBatchTo.Location = new System.Drawing.Point(176, 40);
            this.dtpBatchTo.Name = "dtpBatchTo";
            this.dtpBatchTo.Size = new System.Drawing.Size(100, 20);
            this.dtpBatchTo.TabIndex = 7;
            // 
            // lbBatchTo
            // 
            this.lbBatchTo.Location = new System.Drawing.Point(152, 40);
            this.lbBatchTo.Name = "lbBatchTo";
            this.lbBatchTo.Size = new System.Drawing.Size(24, 20);
            this.lbBatchTo.TabIndex = 6;
            this.lbBatchTo.Text = "To";
            this.lbBatchTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpBatchFrom
            // 
            this.dtpBatchFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBatchFrom.Location = new System.Drawing.Point(40, 40);
            this.dtpBatchFrom.Name = "dtpBatchFrom";
            this.dtpBatchFrom.Size = new System.Drawing.Size(100, 20);
            this.dtpBatchFrom.TabIndex = 5;
            // 
            // lbBatchFrom
            // 
            this.lbBatchFrom.Location = new System.Drawing.Point(5, 40);
            this.lbBatchFrom.Name = "lbBatchFrom";
            this.lbBatchFrom.Size = new System.Drawing.Size(35, 20);
            this.lbBatchFrom.TabIndex = 4;
            this.lbBatchFrom.Text = "From";
            this.lbBatchFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbBatchBatchCode
            // 
            this.tbBatchBatchCode.Location = new System.Drawing.Point(224, 5);
            this.tbBatchBatchCode.MaxLength = 3;
            this.tbBatchBatchCode.Name = "tbBatchBatchCode";
            this.tbBatchBatchCode.Size = new System.Drawing.Size(48, 20);
            this.tbBatchBatchCode.TabIndex = 3;
            this.tbBatchBatchCode.Text = "###";
            this.tbBatchBatchCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbBatchBatchCode_KeyPress);
            // 
            // lbBatchBatchCode
            // 
            this.lbBatchBatchCode.Location = new System.Drawing.Point(152, 5);
            this.lbBatchBatchCode.Name = "lbBatchBatchCode";
            this.lbBatchBatchCode.Size = new System.Drawing.Size(70, 20);
            this.lbBatchBatchCode.TabIndex = 2;
            this.lbBatchBatchCode.Text = "Batch Code";
            this.lbBatchBatchCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbBatchGroupCode
            // 
            this.tbBatchGroupCode.Location = new System.Drawing.Point(80, 5);
            this.tbBatchGroupCode.MaxLength = 5;
            this.tbBatchGroupCode.Name = "tbBatchGroupCode";
            this.tbBatchGroupCode.Size = new System.Drawing.Size(56, 20);
            this.tbBatchGroupCode.TabIndex = 1;
            this.tbBatchGroupCode.Text = "#####";
            this.tbBatchGroupCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbBatchGroupCode_KeyPress);
            // 
            // lbBatchGroupCode
            // 
            this.lbBatchGroupCode.Location = new System.Drawing.Point(5, 5);
            this.lbBatchGroupCode.Name = "lbBatchGroupCode";
            this.lbBatchGroupCode.Size = new System.Drawing.Size(70, 20);
            this.lbBatchGroupCode.TabIndex = 0;
            this.lbBatchGroupCode.Text = "Order Code";
            this.lbBatchGroupCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sbStatus
            // 
            this.sbStatus.Location = new System.Drawing.Point(0, 690);
            this.sbStatus.Name = "sbStatus";
            this.sbStatus.Size = new System.Drawing.Size(994, 15);
            this.sbStatus.TabIndex = 2;
            this.sbStatus.Text = "Ready";
            // 
            // History
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.ClientSize = new System.Drawing.Size(994, 705);
            this.Controls.Add(this.sbStatus);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "History";
            this.Text = "History";
            this.tabControl.ResumeLayout(false);
            this.tbItem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgItemCreationHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgItem)).EndInit();
            this.tbOrder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgOrder)).EndInit();
            this.tbCustomer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgCustomer)).EndInit();
            this.tbBatch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgBatch)).EndInit();
            this.ResumeLayout(false);

        }
		#endregion

		private void tabControl_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			switch (tabControl.SelectedIndex)
			{
				case 0:
				{
					FocusItem();
					break;
				}
				case 1:
				{
					FocusBatch();
					break;
				}
				case 2:
				{
					FocusOrder();
					break;
				}
				case 3:
				{
					FocusCustomer();
					break;
				}
			}
		}

		private void InitCustomer(int iAccessLevel)
		{
			try
			{
				if (iAccessLevel > 1)
				{
					DataTable dtCustomers = Service.GetCustomers().Tables[0];
					cbcCustomerCustomer.Initialize(dtCustomers);

					InitDateTimePickerFrom(dtpCustomerFrom);
					InitDateTimePicker(dtpCustomerTo);
					LoadAuthors(cbCustomerAuthor);
				}
				else
				{
					cbcCustomerCustomer.Enabled = false;
					cbCustomerAuthor.Items.Add("All");
					cbCustomerAuthor.SelectedItem = "All";
					cbCustomerAuthor.Enabled = false;
					dtpCustomerFrom.Enabled = false;
					dtpCustomerTo.Enabled = false;
					btnCustomerApply.Enabled = false;
				}
				
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Can't load customers. Reason: " + ex.ToString(),
					"Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void InitOrder(int iAccessLevel)
		{
			if (iAccessLevel > 1)
			{
				InitDateTimePickerFrom(dtpOrderFrom);
				InitDateTimePicker(dtpOrderTo);
				LoadAuthors(cbOrderAuthor);
			}
			else
			{
				this.tbOrderOrderCode.Enabled = false;
				this.dtpOrderFrom.Enabled = false;
				this.dtpOrderTo.Enabled = false;
				this.cbOrderAuthor.Items.Add("All");
				this.cbOrderAuthor.SelectedItem = "All";
				this.cbOrderAuthor.Enabled = false;
				this.btnOrderApply.Enabled = false;
				this.dgOrder.Enabled = false;
			}
		}

		private void InitBatch(int iAccessLevel)
		{
			if (iAccessLevel > 1)
			{
				InitDateTimePickerFrom(dtpBatchFrom);
				InitDateTimePicker(dtpBatchTo);
				LoadAuthors(cbBatchAuthor);
			}
			else
			{
				this.tbBatchBatchCode.Enabled = false;
				this.tbBatchGroupCode.Enabled = false;
				this.dtpBatchFrom.Enabled = false;
				this.dtpBatchTo.Enabled = false;
				this.cbBatchAuthor.Items.Add("All");
				this.cbBatchAuthor.SelectedItem = "All";
				this.cbBatchAuthor.Enabled = false;
				this.btnBatchApply.Enabled = false;
				this.dgBatch.Enabled = false;
			}
		}

		private void InitItem(int iAccessLevel)
		{
			if (iAccessLevel > 1)
			{
				InitDateTimePickerFrom(dtpItemFrom);
				InitDateTimePicker(dtpItemTo);
				LoadAuthors(cbItemAuthor);
				tbItemNumber.Focus();
				tbItemNumber.SelectAll();
			}
			else
			{
				this.tbItemItemCode.Enabled = false;
				this.tbItemGroupCode.Enabled = false;
				this.tbItemBatchCode.Enabled = false;
				this.dtpItemFrom.Enabled = false;
				this.dtpItemTo.Enabled = false;
				this.cbItemAuthor.Items.Add("All");
				this.cbItemAuthor.SelectedItem = "All";
				this.cbItemAuthor.Enabled = false;
				this.btnItemApply.Enabled = false;
				this.dgItem.Enabled = false;

			}
		}

		private void InitDateTimePicker(DateTimePicker dtp)
		{
			dtp.MaxDate = DateTime.Today;
			dtp.Value = DateTime.Today;
		}

		private void InitDateTimePickerFrom(DateTimePicker dtp)
		{
			dtp.MaxDate = DateTime.Today.AddYears(-5);
			dtp.Value = DateTime.Today.AddYears(-5);
		}

		private void FocusCustomer()
		{
			//cbCustomerAuthor.SelectedItem = "All";
			//cbCustomerAuthor.SelectedValue = DBNull.Value;
			sbStatus.Text = "Ready";
			btnCustomerApply.Focus();
		}

		private void FocusOrder()
		{
			//cbOrderAuthor.SelectedItem = "All";
			//cbOrderAuthor.SelectedValue = DBNull.Value;

			sbStatus.Text = "Ready";
			btnOrderApply.Focus();
		}

		private void FocusBatch()
		{
			//cbBatchAuthor.SelectedItem = "All";
			//cbBatchAuthor.SelectedValue = DBNull.Value;
			sbStatus.Text = "Ready";
			btnBatchApply.Focus();
		}

		private void FocusItem()
		{
			//cbItemAuthor.SelectedItem = "All";
			//cbItemAuthor.SelectedValue = DBNull.Value;
			sbStatus.Text = "Ready";
			tbItemNumber.Focus();
            //btnItemApply.Focus();

		}

		private int GetAllIndex(ComboBox authorCombo)
		{
			for (int i = 0; i < authorCombo.Items.Count; i++) 
			{
				if (authorCombo.Items[i].ToString().Equals("All"))
					return i;
			}
			return authorCombo.Items.Count;
		}

		private void btnCustomerApply_Click(object sender, System.EventArgs e)
		{
			Filters fltr = new Filters();
			if (CheckCustomerFilters(fltr))
			{
				this.Cursor = Cursors.WaitCursor;
				sbStatus.Text = "Loading customer history...";

				try
				{

					DataSet dsIn = new DataSet();
					DataTable dtIn = dsIn.Tables.Add("CustomerHistory");
			
					dtIn.Columns.Add("filtrDateFrom", System.Type.GetType("System.DateTime"));
					dtIn.Columns.Add("filtrDateTo",System.Type.GetType("System.DateTime"));
					dtIn.Columns.Add("filtrCustomerID");
					dtIn.Columns.Add("filtrCustomerOfficeID");
					dtIn.Columns.Add("filtrAuthorID");
					dtIn.Columns.Add("filtrAuthorOfficeID");

					DataRow row = dtIn.NewRow();

					if (fltr.IsCustomerSelected == FilterState.Valid)
					{
						string s = cbcCustomerCustomer.SelectedID;

						char cSeparator = '_';
						string[] sIDs = s.Split(cSeparator);

						row["filtrCustomerID"] = sIDs[1];
						row["filtrCustomerOfficeID"] = sIDs[0];
					}
					else
					{
						row["filtrCustomerID"] = DBNull.Value;
						row["filtrCustomerOfficeID"] = DBNull.Value;
					}

					row["filtrDateFrom"] = dtpCustomerFrom.Value.Date.ToShortDateString();
					row["filtrDateTo"] = dtpCustomerTo.Value.Date.ToShortDateString();

					if (fltr.IsAuthorSelected == FilterState.Valid)
					{
						/*
						int iSelectedAuthor = this.cbCustomerAuthor.SelectedIndex;
						int iAllIndex = GetAllIndex(cbCustomerAuthor);
						if (iSelectedAuthor > iAllIndex)
							iSelectedAuthor = iSelectedAuthor - 1;
						DataRow[] sortedRows = dsAuthors.Tables[0].Select("1=1", "Login");
						string s = sortedRows[iSelectedAuthor]["AuthorOfficeID_AuthorID"].ToString();
						*/
							//dsAuthors.Tables[0].Rows[iSelectedAuthor]["AuthorOfficeID_AuthorID"].ToString();
						string s = cbCustomerAuthor.SelectedValue.ToString();

						char cSeparator = '_';
						string[] sIDs = s.Split(cSeparator);

						row["filtrAuthorID"] = sIDs[0];
						row["filtrAuthorOfficeID"] = sIDs[1];
					}
					else
					{
						row["filtrAuthorID"] = DBNull.Value;
						row["filtrAuthorOfficeID"] = DBNull.Value;
					}
			
					dtIn.Rows.Add(row);
					DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);

					InitCustomerDataGrid(dsOut.Tables[0].TableName);
					dgCustomer.SetDataBinding(dsOut, dsOut.Tables[0].TableName);

					Cursor = Cursors.Default;
					sbStatus.Text = "Customer history load successfuly";		
				}
				catch (Exception ex)
				{
					MessageBox.Show(this, "Can't load customer history. Reason: " + ex.ToString(),
						"Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					Cursor = Cursors.Default;
					sbStatus.Text = "Ready";
				}
			}
		}

		private void tbOrderOrderCode_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			OnGroupCodeKeyPress(tbOrderOrderCode, e);
		}

		private void btnOrderApply_Click(object sender, System.EventArgs e)
		{
			Filters fltr = new Filters();
			if (CheckOrderFilters(fltr))
			{
				this.Cursor = Cursors.WaitCursor;
				sbStatus.Text = "Loading order history...";

				try
				{

					DataSet dsIn = new DataSet();
					DataTable dtIn = dsIn.Tables.Add("GroupHistory");
				
					dtIn.Columns.Add("filtrGroupCode", System.Type.GetType("System.String"));
					dtIn.Columns.Add("filtrDateFrom", System.Type.GetType("System.DateTime"));
					dtIn.Columns.Add("filtrDateTo", System.Type.GetType("System.DateTime"));
					dtIn.Columns.Add("filtrAuthorID", System.Type.GetType("System.String"));
					dtIn.Columns.Add("filtrAuthorOfficeID", System.Type.GetType("System.String"));

					DataRow row = dtIn.NewRow();

					if (fltr.IsGroupCodeEntered == FilterState.Valid)
						row["filtrGroupCode"] = tbOrderOrderCode.Text.ToString();
					else
						row["filtrGroupCode"] = DBNull.Value;

					row["filtrDateFrom"] = dtpOrderFrom.Value.Date.ToShortDateString();
					row["filtrDateTo"] = dtpOrderTo.Value.Date.ToShortDateString();

					if (fltr.IsAuthorSelected == FilterState.Valid)
					{
						/*
						int iSelectedAuthor = cbOrderAuthor.SelectedIndex;
						int iAllIndex = GetAllIndex(cbOrderAuthor);
						if (iSelectedAuthor > iAllIndex)
							iSelectedAuthor = iSelectedAuthor - 1;

						DataRow[] sortedRows = dsAuthors.Tables[0].Select("1=1", "Login");
						string s = sortedRows[iSelectedAuthor]["AuthorOfficeID_AuthorID"].ToString();
						*/

						string s = cbOrderAuthor.SelectedValue.ToString();

						char cSeparator = '_';
						string[] sIDs = s.Split(cSeparator);

						row["filtrAuthorID"] = sIDs[0];
						row["filtrAuthorOfficeID"] = sIDs[1];
					}
					else
					{
						row["filtrAuthorID"] = DBNull.Value;
						row["filtrAuthorOfficeID"] = DBNull.Value;
					}
				
					dtIn.Rows.Add(row);
					DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);

					InitOrderDataGrid(dsOut.Tables[0].TableName);
					dgOrder.SetDataBinding(dsOut, dsOut.Tables[0].TableName);

					Cursor = Cursors.Default;
					sbStatus.Text = "Order history load successfuly";		
				}
				catch (Exception ex)
				{
					MessageBox.Show(this, "Can't load order history. Reason: " + ex.ToString(),
						"Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					Cursor = Cursors.Default;
					sbStatus.Text = "Ready";
				}
			}
		}

		private void tbBatchGroupCode_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			OnGroupCodeKeyPress(tbBatchGroupCode, e);
		}

		private void tbBatchBatchCode_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			OnBatchCodeKeyPress(tbBatchBatchCode, e);
		}

		private void btnBatchApply_Click(object sender, System.EventArgs e)
		{
			Random r = new Random();
			int rCode = r.Next(1000, 100000);

			Filters fltr = new Filters();
			if (CheckBatchFilters(fltr))
			{
				Cursor = Cursors.WaitCursor;
				sbStatus.Text = "Loading batch history...";

				try
				{
					DataSet dsIn = new DataSet();
					DataTable dtIn = dsIn.Tables.Add("BatchHistory");
				
					dtIn.Columns.Add("filtrGroupCode", System.Type.GetType("System.String"));
					dtIn.Columns.Add("filtrBatchCode", System.Type.GetType("System.String"));
					dtIn.Columns.Add("filtrDateFrom", System.Type.GetType("System.DateTime"));
					dtIn.Columns.Add("filtrDateTo", System.Type.GetType("System.DateTime"));
					dtIn.Columns.Add("filtrAuthorID", System.Type.GetType("System.String"));
					dtIn.Columns.Add("filtrAuthorOfficeID", System.Type.GetType("System.String"));

					DataRow row = dtIn.NewRow();

					if (fltr.IsGroupCodeEntered == FilterState.Valid)
						row["filtrGroupCode"] = tbBatchGroupCode.Text.ToString();
					else
						row["filtrGroupCode"] = DBNull.Value;

					if (fltr.IsBatchCodeEntered == FilterState.Valid)
						row["filtrBatchCode"] = tbBatchBatchCode.Text.ToString();
					else
						row["filtrBatchCode"] = DBNull.Value;

					row["filtrDateFrom"] = dtpBatchFrom.Value.Date.ToShortDateString();
					row["filtrDateTo"] = dtpBatchTo.Value.Date.ToShortDateString();

					if (fltr.IsAuthorSelected == FilterState.Valid)
					{
						/*
						int iSelectedAuthor = this.cbBatchAuthor.SelectedIndex;
						int iAllIndex = GetAllIndex(cbBatchAuthor);
						if (iSelectedAuthor > iAllIndex)
							iSelectedAuthor = iSelectedAuthor - 1;
						
						DataRow[] sortedRows = dsAuthors.Tables[0].Select("1=1", "Login");
						string s = sortedRows[iSelectedAuthor]["AuthorOfficeID_AuthorID"].ToString();
						*/
						
						//string s = dsAuthors.Tables[0].Rows[iSelectedAuthor]["AuthorOfficeID_AuthorID"].ToString();

						string s = cbBatchAuthor.SelectedValue.ToString();

						char cSeparator = '_';
						string[] sIDs = s.Split(cSeparator);

						row["filtrAuthorID"] = sIDs[0];
						row["filtrAuthorOfficeID"] = sIDs[1];
					}
					else
					{
						row["filtrAuthorID"] = DBNull.Value;
						row["filtrAuthorOfficeID"] = DBNull.Value;
					}
				
					dtIn.Rows.Add(row);
					DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);

					InitBatchDataGrid(dsOut.Tables[0].TableName);
					dgBatch.SetDataBinding(dsOut, dsOut.Tables[0].TableName);

					Cursor = Cursors.Default;
					sbStatus.Text = "Batch history load successfully";

				}
				catch (Exception ex)
				{
					MessageBox.Show(this, "Can't load batch history. Reason: " + ex.ToString(),
						"Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					Cursor = Cursors.Default;
					sbStatus.Text = "Ready";
				}
			}
		}

		private void tbItemGroupCode_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			OnGroupCodeKeyPress(tbItemGroupCode, e);
		}

		private void tbItemBatchCode_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			OnBatchCodeKeyPress(tbItemBatchCode, e);
		}

		private void tbItemItemCode_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			OnItemCodeKeyPress(tbItemItemCode, e);
		}

		private void btnItemApply_Click(object sender, System.EventArgs e)
		{
			tbItemNumber.Text = Service.GetItemNumberBy7digit(tbItemNumber.Text.Trim());
			if (Regex.IsMatch(tbItemNumber.Text, @"^\d{10,12}$"))
				//if (tbItemNumber.Text.Length == 10 || tbItemNumber.Text.Length == 11)
			{
			string[] sItemNum = GetFullNumber(tbItemNumber.Text).Split('.');
			tbItemGroupCode.Text = sItemNum[0];
			tbItemBatchCode.Text = sItemNum[1];
			tbItemItemCode.Text = sItemNum[2];
			
			dgItem.SetDataBinding(null,"");
			dgItemCreationHistory.SetDataBinding(null,"");

			Random r = new Random();
			int rCode = r.Next(1000, 100000);
			
			Filters fltr = new Filters();
			if (CheckItemFilters(fltr))
			{
				Cursor = Cursors.WaitCursor;
				sbStatus.Text = "Loading item history...";

				try
				{
					DataSet dsIn = new DataSet();
					DataTable dtIn = dsIn.Tables.Add("ItemHistory");
				
					dtIn.Columns.Add("filtrGroupCode", System.Type.GetType("System.String"));
					dtIn.Columns.Add("filtrBatchCode", System.Type.GetType("System.String"));
					dtIn.Columns.Add("filtrItemCode", System.Type.GetType("System.String"));
					dtIn.Columns.Add("filtrDateFrom", System.Type.GetType("System.DateTime"));
					dtIn.Columns.Add("filtrDateTo", System.Type.GetType("System.DateTime"));
					dtIn.Columns.Add("filtrAuthorID", System.Type.GetType("System.String"));
					dtIn.Columns.Add("filtrAuthorOfficeID", System.Type.GetType("System.String"));
					dtIn.Columns.Add("rand", System.Type.GetType("System.String"));

					DataRow row = dtIn.NewRow();

					if (fltr.IsGroupCodeEntered == FilterState.Valid)
						row["filtrGroupCode"] = tbItemGroupCode.Text.ToString();
					else
						row["filtrGroupCode"] = DBNull.Value;

					if (fltr.IsBatchCodeEntered == FilterState.Valid)
						row["filtrBatchCode"] = tbItemBatchCode.Text.ToString();
					else
						row["filtrBatchCode"] = DBNull.Value;

					if (fltr.IsItemCodeEntered == FilterState.Valid)
						row["filtrItemCode"] = tbItemItemCode.Text.ToString();
					else
						row["filtrItemCode"] = DBNull.Value;

					row["filtrDateFrom"] = dtpItemFrom.Value.Date.ToShortDateString();
					row["filtrDateTo"] = dtpItemTo.Value.Date.ToShortDateString();
					row["rand"] = rCode.ToString();

					if (fltr.IsAuthorSelected == FilterState.Valid)
					{
						/*
						int iSelectedAuthor = this.cbItemAuthor.SelectedIndex;
						int iAllIndex = GetAllIndex(cbItemAuthor);
						if (iSelectedAuthor > iAllIndex)
							iSelectedAuthor = iSelectedAuthor - 1;

						DataRow[] sortedRows = dsAuthors.Tables[0].Select("1=1", "Login");
						string s = sortedRows[iSelectedAuthor]["AuthorOfficeID_AuthorID"].ToString();
						*/

						//string s = dsAuthors.Tables[0].Rows[iSelectedAuthor]["AuthorOfficeID_AuthorID"].ToString();

						string s = cbItemAuthor.SelectedValue.ToString();

						char cSeparator = '_';
						string[] sIDs = s.Split(cSeparator);

						row["filtrAuthorID"] = sIDs[0];
						row["filtrAuthorOfficeID"] = sIDs[1];
					}
					else
					{
						row["filtrAuthorID"] = DBNull.Value;
						row["filtrAuthorOfficeID"] = DBNull.Value;
					}
				
					dtIn.Rows.Add(row);
					DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);

					InitItemDataGrid(dsOut.Tables[1].TableName);
					dgItem.SetDataBinding(dsOut, dsOut.Tables[1].TableName);

					Cursor = Cursors.Default;
					sbStatus.Text = "Item history load successfully";

					for (int i = 0; i < dsOut.Tables[1].Rows.Count; i++)
					{
						if(dsOut.Tables[1].Rows[i]["NewNumber"].ToString() != dsOut.Tables[1].Rows[i]["OldNumber"].ToString() && i != 0)
						{
							if(dsOut.Tables[1].Rows[i - 1]["NewNumber"].ToString() != dsOut.Tables[1].Rows[i]["NewNumber"].ToString())
							{
								dgItem.Select(i);
							}
						}
					}
					InitItemHistoryDataGrid(dsOut.Tables[0].TableName);
					dgItemCreationHistory.SetDataBinding(dsOut, dsOut.Tables[0].TableName);

				}
				catch (Exception ex)
				{
					DataSet dsClIn = new DataSet();
					DataTable dtClIn = dsClIn.Tables.Add("ClearItemHistory");
					dtClIn.Columns.Add("rand", System.Type.GetType("System.String"));
					DataRow row = dtClIn.NewRow();
					row["rand"] = rCode.ToString();
					dtClIn.Rows.Add(row);
					DataSet dsClOut = gemoDream.Service.ProxyGenericGet(dsClIn);					
					
					MessageBox.Show(this, "Can't load item history. Reason: " + ex.ToString(),
						"Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					Cursor = Cursors.Default;
					sbStatus.Text = "Ready";
				}
			}
		}
		}

		private void LoadAuthors(ComboBox cbAuthor)
		{
			try
			{
				cbAuthor.Items.Clear();
				//cbAuthor.Items.Add("All");

				if (dsAuthors.Tables.Count == 0)
				{
					DataSet dsIn = new DataSet();
					DataTable dtIn = dsIn.Tables.Add("Authors");
					dtIn.Columns.Add("Login", System.Type.GetType("System.String"));
					dtIn.Columns.Add("DepartmentID", System.Type.GetType("System.String"));
					dtIn.Columns.Add("DepartmentOfficeID", System.Type.GetType("System.String"));
					dtIn.Columns.Add("Password", System.Type.GetType("System.String"));
					dtIn.Columns.Add("UserID", System.Type.GetType("System.String"));
					dtIn.Columns.Add("UserOfficeID", System.Type.GetType("System.String"));
					DataRow row = dtIn.NewRow();
					dtIn.Rows.Add(row);
					dsAuthors = gemoDream.Service.ProxyGenericGet(dsIn);
					// OfficeID UserID CreateDate Login Password LastModifiedDate
					object[] obj = new object[] {null, null, null, "All", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null};
					dsAuthors.Tables[0].Rows.Add(obj);
				}

				if (dsAuthors.Tables.Count > 0)
				{
					DataView dvAuthors = new DataView(dsAuthors.Tables[0]);
					dvAuthors.Sort = "Login";
					
					cbAuthor.DataSource = dvAuthors;
					cbAuthor.DisplayMember = "Login";
					cbAuthor.ValueMember = "AuthorOfficeID_AuthorID";

					/*
					foreach (DataRow dr in dsAuthors.Tables[0].Rows)
					{
						cbAuthor.Items.Add(dr["Login"].ToString());
					}
					*/
				}
				//cbAuthor.Sorted = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Can't load authors. Reason: " + ex.ToString(),
					"Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			cbAuthor.SelectedValue = DBNull.Value;
			//cbAuthor.SelectedItem = "All";
			//cbAuthor.SelectedText = "All";
		}

		private void OnGroupCodeKeyPress(TextBox tbGroupCode, KeyPressEventArgs e)
		{
			if (e.KeyChar != 8)
			{
				string str = tbGroupCode.Text.ToString();
				if (str.Equals("#####"))
				{
					str = "";
					tbGroupCode.Text = str;
				}

				str += e.KeyChar.ToString();

				string pattern = "[0-9]{1,6}";
				Regex rex = new Regex(pattern);
					
				Match m = rex.Match(str);
				if (m.Length != str.Length)
					e.Handled = true;
			}
		}

		private void OnBatchCodeKeyPress(TextBox tbBatchCode, KeyPressEventArgs e)
		{
			if (e.KeyChar != 8)
			{
				string str = tbBatchCode.Text.ToString();
				if (str.Equals("###"))
				{
					str = "";
					tbBatchCode.Text = str;
				}

				str += e.KeyChar.ToString();

				string pattern = "[0-9]{1,3}";
				Regex rex = new Regex(pattern);
					
				Match m = rex.Match(str);
				if (m.Length != str.Length)
					e.Handled = true;
			}
		}

		private void OnItemCodeKeyPress(TextBox tbItemCode, KeyPressEventArgs e)
		{
			if (e.KeyChar != 8)
			{
				string str = tbItemCode.Text.ToString();
				if (str.Equals("##"))
				{
					str = "";
					tbItemCode.Text = str;
				}

				str += e.KeyChar.ToString();

				string pattern = "[0-9]{1,2}";
				Regex rex = new Regex(pattern);
					
				Match m = rex.Match(str);
				if (m.Length != str.Length)
					e.Handled = true;
			}
		}

		private FilterState CheckGroupCode(TextBox tbGroupCode)
		{
			if (tbGroupCode.Text.ToString().Length != 0)
			{
				if (!tbGroupCode.Text.ToString().Equals("#####"))
				{
					string pattern = "[0-9]{4,6}";
					Regex rex = new Regex(pattern);
					Match m = rex.Match(tbGroupCode.Text);
					if (m.Length != tbGroupCode.Text.Length)
					{
						MessageBox.Show(this, "Please input valid group code.",
							"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return FilterState.NotValid;;
					}
					return FilterState.Valid;;
				}
			}
			return FilterState.NotEntered;
		}

		private FilterState CheckBatchCode(TextBox tbBatchCode)
		{
			if (tbBatchCode.Text.ToString().Length != 0)
			{
				if (!tbBatchCode.Text.ToString().Equals("###"))

				{
					string pattern = "[0-9]{1,3}";
					Regex rex = new Regex(pattern);
					Match m = rex.Match(tbBatchCode.Text);
					if (m.Length != tbBatchCode.Text.Length)
					{
						MessageBox.Show(this, "Please input valid batch code.",
							"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return FilterState.NotValid;
					}
					return FilterState.Valid;
				}
			}
			return FilterState.NotEntered;
		}

		private FilterState CheckItemCode(TextBox tbItemCode)
		{
			if (tbItemCode.Text.ToString().Length != 0)
			{
				if (!tbItemCode.Text.ToString().Equals("##"))
				{
					string pattern = "[0-9]{1,2}";
					Regex rex = new Regex(pattern);
					Match m = rex.Match(tbItemCode.Text);
					if (m.Length != tbItemCode.Text.Length)
					{
						MessageBox.Show(this, "Please input valid item code.",
							"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return FilterState.NotValid;
					}
					return FilterState.Valid;
				}
			}
			return FilterState.NotEntered;
		}

		private bool CheckCustomerFilters(Filters fltr)
		{
			if (!cbcCustomerCustomer.SelectedID.Equals("0"))
			{
				fltr.IsCustomerSelected = FilterState.Valid;
			}

			/*
			if (!cbCustomerAuthor.SelectedItem.ToString().Equals("All"))
			{
				fltr.IsAuthorSelected = FilterState.Valid;
			}
			*/
			if (cbCustomerAuthor.SelectedValue.ToString().Length != 0)
			{
				fltr.IsAuthorSelected = FilterState.Valid;
			}

			if (!CheckDates(dtpCustomerFrom, dtpCustomerTo))
				return false;

			return true;
		}

		private bool CheckOrderFilters(Filters fltr)
		{
			fltr.IsGroupCodeEntered = CheckGroupCode(tbOrderOrderCode);
			if (fltr.IsGroupCodeEntered == FilterState.NotValid)
				return false;

			if (cbOrderAuthor.SelectedValue.ToString().Length != 0)
			{
				fltr.IsAuthorSelected = FilterState.Valid;
			}

			if (!CheckDates(dtpOrderFrom, dtpOrderTo))
				return false;

			return true;
		}
		
		private bool CheckBatchFilters(Filters fltr)
		{
			fltr.IsGroupCodeEntered = CheckGroupCode(tbBatchGroupCode);
			if (fltr.IsGroupCodeEntered == FilterState.NotValid)
				return false;

			fltr.IsBatchCodeEntered = CheckBatchCode(tbBatchBatchCode);
			if (fltr.IsBatchCodeEntered == FilterState.NotValid)
				return false;

			if (fltr.IsGroupCodeEntered != FilterState.Valid && 
				fltr.IsBatchCodeEntered == FilterState.Valid)
			{
				MessageBox.Show(this, "Please enter a group code.",
					"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}

			if (cbBatchAuthor.SelectedValue.ToString().Length != 0)
			{
				fltr.IsAuthorSelected = FilterState.Valid;
			}

			if (!CheckDates(dtpBatchFrom, dtpBatchTo))
				return false;

			return true;
		}

		private bool CheckItemFilters(Filters fltr)
		{
			fltr.IsGroupCodeEntered = CheckGroupCode(tbItemGroupCode);
			if (fltr.IsGroupCodeEntered == FilterState.NotValid)
				return false;

			fltr.IsBatchCodeEntered = CheckBatchCode(tbItemBatchCode);
			if (fltr.IsBatchCodeEntered == FilterState.NotValid)
				return false;

			fltr.IsItemCodeEntered  = CheckItemCode(tbItemItemCode);
			if (fltr.IsItemCodeEntered == FilterState.NotValid)
				return false;

			if (fltr.IsGroupCodeEntered != FilterState.Valid && 
				fltr.IsBatchCodeEntered == FilterState.Valid)
			{
				MessageBox.Show(this, "Please enter a group code.",
					"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}

			if (fltr.IsGroupCodeEntered != FilterState.Valid &&
				fltr.IsBatchCodeEntered != FilterState.Valid &&
				fltr.IsItemCodeEntered  == FilterState.Valid)
			{
				MessageBox.Show(this, "Please enter a group and batch code.",
					"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}

			if (cbItemAuthor.SelectedValue.ToString().Length != 0)
			{
				fltr.IsAuthorSelected = FilterState.Valid;
			}

			if (!CheckDates(dtpItemFrom, dtpItemTo))
				return false;

			return true;
		}

		private bool CheckDates(DateTimePicker dtpFrom, DateTimePicker dtpTo)
		{
			if (dtpFrom.Value > dtpTo.Value) 
			{
				MessageBox.Show(this, "Please enter correct period.", 
					"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			return true;
		}

		private void InitCustomerDataGrid(string mappingName)
		{
			string[] columnNames = new string[] 
				{
					"StartDate", "CustomerCode", "CompanyName", "Change", 
					"OldValue",	"NewValue", "FirstName", "LastName"
				};
			string[] headerText = new string[]
				{
					"Start Date", "Customer Code", "Company Name", "Change",
					"Old Value", "New Value", "First Name", "Last Name"
				};
			int[] columnWidth = new int[]
				{
					120, 70, 70, 140,
					130, 130, 110, 110
				};

			DataGridTableStyle tableStyle = new DataGridTableStyle();
			tableStyle.MappingName = mappingName;
			tableStyle.RowHeadersVisible = false;
	
			for (int i = 0; i < columnNames.Length; i++)
			{
				DataGridTextBoxColumn tbColumn = new DataGridTextBoxColumn();

				tbColumn.MappingName = columnNames[i];
				tbColumn.HeaderText = headerText[i];
				tbColumn.Width = columnWidth[i];
				tbColumn.NullText = "";
				tableStyle.GridColumnStyles.Add(tbColumn);						
			}

			dgCustomer.TableStyles.Clear();
			dgCustomer.TableStyles.Add(tableStyle);
		}

		private void InitBatchDataGrid(string mappingName)
		{
			string[] columnNames = new string[] 
					{
						"StartDate", "OrderCode", "BatchCode", 
						"Change", "OldValue", "NewValue",
						"FirstName", "LastName"
					};
			string[] headerText = new string[] 
					{
						"Start Date", "Order Code", "Batch Code",
						"Change", "Old Value", "New Value",
						"First Name", "Last Name"
					};
			int[] columnWidth = new int[]
					{
						120, 70, 70, 
						70,	130, 130,
						90, 90, 
					};

			DataGridTableStyle tableStyle = new DataGridTableStyle();
			tableStyle.MappingName = mappingName;
			tableStyle.RowHeadersVisible = false;

			for (int i = 0; i < columnNames.Length; i++)
			{
				DataGridTextBoxColumn tbColumn = new DataGridTextBoxColumn();

				tbColumn.MappingName = columnNames[i];
				tbColumn.HeaderText = headerText[i];
				tbColumn.Width = columnWidth[i];
				tbColumn.NullText = "";
				tableStyle.GridColumnStyles.Add(tbColumn);						
			}

			dgBatch.TableStyles.Clear();
			dgBatch.TableStyles.Add(tableStyle);

		}

		private void InitOrderDataGrid(string mappingName)
		{
			string[] columnNames = new string[] 
					{
						"StartDate", "GroupCode", "Change", "OldValue",
						"NewValue", "FirstName", "LastName"
					};
			string[] headerText = new string[]
				{
					"Start Date", "Order Code", "Change", "Old Value",
					"New Value", "First Name", "Last Name"
				};
			int[] columnWidth = new int[]
					{
						120, 70, 140, 140,
						140, 130, 130,
					};

			DataGridTableStyle tableStyle = new DataGridTableStyle();
			tableStyle.MappingName = mappingName;
			tableStyle.RowHeadersVisible = false;

			for (int i = 0; i < columnNames.Length; i++)
			{
				DataGridTextBoxColumn tbColumn = new DataGridTextBoxColumn();
				tbColumn.MappingName = columnNames[i];
				tbColumn.HeaderText = headerText[i];
				tbColumn.Width = columnWidth[i];
				tbColumn.NullText = "";
				tableStyle.GridColumnStyles.Add(tbColumn);						
			}

			dgOrder.TableStyles.Clear();
			dgOrder.TableStyles.Add(tableStyle);

		}
		private void InitItemHistoryDataGrid(string mappingName)
		{
			string[] columnNames = new string[] 
					{
						"NewNumber", "OldNumber", "CreateDate", "Person"
					};
			string[] headerText = new string[] 
					{
						"New #", "Old #", "Start Date", "User"
					};
			int[] columnWidth = new int[]
					{
						90, 90, 115, 130
					};

			DataGridTableStyle tableStyle = new DataGridTableStyle();
			tableStyle.MappingName = mappingName;
			tableStyle.RowHeadersVisible = false;

			for (int i = 0; i < columnNames.Length; i++)
			{
				DataGridTextBoxColumn tbColumn = new DataGridTextBoxColumn();

				tbColumn.MappingName = columnNames[i];
				tbColumn.HeaderText = headerText[i];
				tbColumn.Width = columnWidth[i];
				tbColumn.NullText = "";
				//tbColumn.ReadOnly = true;
				tableStyle.GridColumnStyles.Add(tbColumn);						
			}

			dgItemCreationHistory.TableStyles.Clear();
			dgItemCreationHistory.TableStyles.Add(tableStyle);
		}
		
		private void InitItemDataGrid(string mappingName)
		{
			string[] columnNames = new string[] 
					{
						"NewNumber", "OldNumber", "StartDate",// "GroupCode", "BatchCode", "ItemCode",
						"PartName", "MeasureName", "RecheckNumber", "OldValue",
						"NewValue", "Person"
					};
			string[] headerText = new string[] 
					{
						"New #", "Old #", "Start Date", //"Group Code", "Batch Code", "Item Code",
						"Part Name", "Measure Name", "R/c", "Old Value",
						"New Value", "User"
					};
			int[] columnWidth = new int[]
					{
						90,  90,  125,
                        150, 140, 25, 110, 
                        110, 125
					};

			DataGridTableStyle tableStyle = new DataGridTableStyle();
			tableStyle.MappingName = mappingName;
			tableStyle.RowHeadersVisible = false;

			for (int i = 0; i < columnNames.Length; i++)
			{
				DataGridTextBoxColumn tbColumn = new DataGridTextBoxColumn();

				tbColumn.MappingName = columnNames[i];
				tbColumn.HeaderText = headerText[i];
				tbColumn.Width = columnWidth[i];
				tbColumn.NullText = "";

				tableStyle.GridColumnStyles.Add(tbColumn);						
			}

			dgItem.TableStyles.Clear();
			dgItem.TableStyles.Add(tableStyle);

		}
		private string GetFullNumber(string myNumber)
		{
			//Regex re = new Regex(@"^\d{5}\.\d{3}\.\d{2}$");
            Regex re10 = new Regex(@"^\d{5}\.\d{3}\.\d{2}$");
            Regex re11 = new Regex(@"^\d{6}\.\d{3}\.\d{2}$");
			Regex re12 = new Regex(@"^\d{7}\.\d{3}\.\d{2}$");
			myNumber = myNumber.Trim().Replace(".","");
			string sText = myNumber;

			if (sText.Length == 10) 
			{
				sText = myNumber.Substring(0,5);
				sText += ".";
				sText += myNumber.Substring(5,3);
				sText += ".";
				sText += myNumber.Substring(8,2);
			
                if (!re10.IsMatch(sText))
                {
                   throw new Exception("Please type again. Acceptable format: 1234567890");
                }
				return sText;
            }
            if (sText.Length == 11) 
            {
                sText = myNumber.Substring(0,6);
                sText += ".";
                sText += myNumber.Substring(6,3);
                sText += ".";
                sText += myNumber.Substring(9,2);
			
                if (!re11.IsMatch(sText))
                {
                    throw new Exception("Please type again. Acceptable format: 12345678910");
                }
				return sText;
            }
			if (sText.Length == 12)
			{
				sText = myNumber.Substring(0, 7);
				sText += ".";
				sText += myNumber.Substring(7, 3);
				sText += ".";
				sText += myNumber.Substring(10, 2);

				if (!re12.IsMatch(sText))
				{
					throw new Exception("Please type again. Acceptable format: 12345678910");
				}
				return sText;
			}

			return sText;
		}

		private void tbItemNumber_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				if(tbItemNumber.Text.Length == 10 || tbItemNumber.Text.Length == 11)
				{
					btnItemApply_Click(this, System.EventArgs.Empty);
//					string[] sItemNum = GetFullNumber(tbItemNumber.Text).Split('.');
//					tbItemGroupCode.Text = sItemNum[0];
//					tbItemBatchCode.Text = sItemNum[1];
//					tbItemItemCode.Text = sItemNum[2];

				}
			}

		}
		private void incNumber_KeyDown(object sender, System.EventArgs e)
		{
		}			

		private void incNumber_Load(object sender, System.EventArgs e)
		{
		
		}

		private void btnClearHistory_Click(object sender, System.EventArgs e)
		{
			dgItem.SetDataBinding(null,"");
			dgItemCreationHistory.SetDataBinding(null,"");
			InitDateTimePickerFrom(dtpItemFrom);
			InitDateTimePicker(dtpItemTo);
			tbItemNumber.Text = "";
			tbItemGroupCode.Text = "";
			tbItemBatchCode.Text = "";
			tbItemItemCode.Text = "";
			tbItemNumber.Focus();
		}
	}
}
