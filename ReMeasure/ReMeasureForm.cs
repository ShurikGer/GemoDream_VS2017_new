using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Xml;

namespace gemoDream
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class RemeasureForm : System.Windows.Forms.Form
    {
        private bool isFirst;
        private bool isItemEntered;
        private int iAccessLevel;
        private DataSet dsData;
        private DataSet dsParts;
        private bool bOnlyBatchUpdated;
        private string sActivePartID = "";
        private string sActivePartName = "";
        #region Generated
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPeriod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnClear;
        private Cntrls.ComboTextComponent ctcCustomer;
        private Cntrls.ItemNumberControl incNumber;
        private Cntrls.ItemNumberControl incNewNumber;
        private Cntrls.OrdersTree otOrders;
        private Cntrls.PartTree ptPartTree;
        private System.Windows.Forms.Panel pCharacteristics;
        private System.Windows.Forms.Panel pPart;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.StatusBar StatusBar;
        private System.Windows.Forms.Button btnSARIN;
        private System.Windows.Forms.ComboBox cbMemoNumber;
        private System.Windows.Forms.Panel pItem;
        private Cntrls.ItemNumberControl incPrevNumber;
        private Cntrls.WeightControl wcCustWeight;
        private Cntrls.WeightControl wcWeight;
        private System.Windows.Forms.TextBox tbComment;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbLotNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbMemoNumber;
        private System.Windows.Forms.TextBox tbMemoNumber;
        private System.Windows.Forms.Button btnUpdateBatch;
        private System.Windows.Forms.CheckBox chk_SkipAddDocs;
        private System.Windows.Forms.ListView lvItemData;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label9;
        internal System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListView lvMigratedItemData;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnMeasureByCP;
        private System.Windows.Forms.Button btnMeasureByFullSet;
        private bool bFullAccess;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public RemeasureForm(int AccessLevel)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            //this.pItem.Controls.Remove(cbMemoNumber);
            //this.Controls.Add(cbMemoNumber);
            Initialize(AccessLevel);
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
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemeasureForm));
			this.dtpTo = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.dtpFrom = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.cbPeriod = new System.Windows.Forms.ComboBox();
			this.btnSelect = new System.Windows.Forms.Button();
			this.btnClear = new System.Windows.Forms.Button();
			this.StatusBar = new System.Windows.Forms.StatusBar();
			this.btnUpdate = new System.Windows.Forms.Button();
			this.btnReset = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.pCharacteristics = new System.Windows.Forms.Panel();
			this.pPart = new System.Windows.Forms.Panel();
			this.btnUpdateBatch = new System.Windows.Forms.Button();
			this.label11 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.btnSARIN = new System.Windows.Forms.Button();
			this.cbMemoNumber = new System.Windows.Forms.ComboBox();
			this.pItem = new System.Windows.Forms.Panel();
			this.label12 = new System.Windows.Forms.Label();
			this.tbLotNumber = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tbComment = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.lbMemoNumber = new System.Windows.Forms.Label();
			this.tbMemoNumber = new System.Windows.Forms.TextBox();
			this.chk_SkipAddDocs = new System.Windows.Forms.CheckBox();
			this.lvItemData = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.label9 = new System.Windows.Forms.Label();
			this.lvMigratedItemData = new System.Windows.Forms.ListView();
			this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.label10 = new System.Windows.Forms.Label();
			this.btnMeasureByCP = new System.Windows.Forms.Button();
			this.btnMeasureByFullSet = new System.Windows.Forms.Button();
			this.label14 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.otOrders = new Cntrls.OrdersTree();
			this.incNumber = new Cntrls.ItemNumberControl();
			this.ctcCustomer = new Cntrls.ComboTextComponent();
			this.incPrevNumber = new Cntrls.ItemNumberControl();
			this.incNewNumber = new Cntrls.ItemNumberControl();
			this.ptPartTree = new Cntrls.PartTree();
			this.wcCustWeight = new Cntrls.WeightControl();
			this.wcWeight = new Cntrls.WeightControl();
			this.pPart.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.pItem.SuspendLayout();
			this.SuspendLayout();
			// 
			// dtpTo
			// 
			this.dtpTo.Enabled = false;
			this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpTo.Location = new System.Drawing.Point(395, 55);
			this.dtpTo.Name = "dtpTo";
			this.dtpTo.Size = new System.Drawing.Size(95, 20);
			this.dtpTo.TabIndex = 31;
			this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
			// 
			// label2
			// 
			this.label2.ForeColor = System.Drawing.Color.Black;
			this.label2.Location = new System.Drawing.Point(375, 60);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(20, 15);
			this.label2.TabIndex = 30;
			this.label2.Text = "to";
			// 
			// dtpFrom
			// 
			this.dtpFrom.Enabled = false;
			this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFrom.Location = new System.Drawing.Point(265, 55);
			this.dtpFrom.Name = "dtpFrom";
			this.dtpFrom.Size = new System.Drawing.Size(95, 20);
			this.dtpFrom.TabIndex = 29;
			this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
			// 
			// label1
			// 
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(225, 60);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 15);
			this.label1.TabIndex = 28;
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
			this.cbPeriod.Location = new System.Drawing.Point(5, 55);
			this.cbPeriod.Name = "cbPeriod";
			this.cbPeriod.Size = new System.Drawing.Size(205, 20);
			this.cbPeriod.TabIndex = 27;
			this.cbPeriod.SelectedIndexChanged += new System.EventHandler(this.cbPeriod_SelectedIndexChanged);
			// 
			// btnSelect
			// 
			this.btnSelect.Enabled = false;
			this.btnSelect.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.btnSelect.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnSelect.Location = new System.Drawing.Point(500, 55);
			this.btnSelect.Name = "btnSelect";
			this.btnSelect.Size = new System.Drawing.Size(65, 20);
			this.btnSelect.TabIndex = 33;
			this.btnSelect.Text = "Select";
			this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
			// 
			// btnClear
			// 
			this.btnClear.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.btnClear.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnClear.Location = new System.Drawing.Point(310, 25);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(65, 20);
			this.btnClear.TabIndex = 32;
			this.btnClear.Text = "Clear";
			this.btnClear.Visible = false;
			// 
			// StatusBar
			// 
			this.StatusBar.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.StatusBar.Location = new System.Drawing.Point(0, 685);
			this.StatusBar.Name = "StatusBar";
			this.StatusBar.Size = new System.Drawing.Size(1018, 20);
			this.StatusBar.TabIndex = 35;
			this.StatusBar.Text = "Ready";
			// 
			// btnUpdate
			// 
			this.btnUpdate.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.btnUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnUpdate.Location = new System.Drawing.Point(540, 375);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(90, 23);
			this.btnUpdate.TabIndex = 37;
			this.btnUpdate.Text = "Update Item";
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// btnReset
			// 
			this.btnReset.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.btnReset.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnReset.Location = new System.Drawing.Point(450, 375);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(70, 23);
			this.btnReset.TabIndex = 36;
			this.btnReset.Text = "Reset";
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(330, 86);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(120, 15);
			this.label3.TabIndex = 0;
			this.label3.Text = "Item #";
			// 
			// pCharacteristics
			// 
			this.pCharacteristics.AutoScroll = true;
			this.pCharacteristics.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pCharacteristics.Location = new System.Drawing.Point(320, -5);
			this.pCharacteristics.Name = "pCharacteristics";
			this.pCharacteristics.Size = new System.Drawing.Size(315, 375);
			this.pCharacteristics.TabIndex = 42;
			// 
			// pPart
			// 
			this.pPart.Controls.Add(this.btnUpdateBatch);
			this.pPart.Controls.Add(this.label11);
			this.pPart.Controls.Add(this.ptPartTree);
			this.pPart.Controls.Add(this.pCharacteristics);
			this.pPart.Controls.Add(this.label13);
			this.pPart.Controls.Add(this.btnReset);
			this.pPart.Controls.Add(this.btnUpdate);
			this.pPart.Location = new System.Drawing.Point(5, 280);
			this.pPart.Name = "pPart";
			this.pPart.Size = new System.Drawing.Size(645, 400);
			this.pPart.TabIndex = 43;
			// 
			// btnUpdateBatch
			// 
			this.btnUpdateBatch.Location = new System.Drawing.Point(320, 375);
			this.btnUpdateBatch.Name = "btnUpdateBatch";
			this.btnUpdateBatch.Size = new System.Drawing.Size(120, 23);
			this.btnUpdateBatch.TabIndex = 49;
			this.btnUpdateBatch.Text = "Update Batch Memo";
			this.btnUpdateBatch.Click += new System.EventHandler(this.btnUpdateBatch_Click);
			// 
			// label11
			// 
			this.label11.BackColor = System.Drawing.SystemColors.Control;
			this.label11.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label11.Location = new System.Drawing.Point(125, 300);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(180, 35);
			this.label11.TabIndex = 43;
			// 
			// label13
			// 
			this.label13.BackColor = System.Drawing.SystemColors.Window;
			this.label13.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label13.Location = new System.Drawing.Point(125, 340);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(185, 55);
			this.label13.TabIndex = 44;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pictureBox1.Location = new System.Drawing.Point(10, 590);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(100, 90);
			this.pictureBox1.TabIndex = 53;
			this.pictureBox1.TabStop = false;
			// 
			// btnSARIN
			// 
			this.btnSARIN.Enabled = false;
			this.btnSARIN.Location = new System.Drawing.Point(580, 55);
			this.btnSARIN.Name = "btnSARIN";
			this.btnSARIN.Size = new System.Drawing.Size(60, 20);
			this.btnSARIN.TabIndex = 46;
			this.btnSARIN.Text = "SARIN";
			this.btnSARIN.Click += new System.EventHandler(this.btnSARIN_Click);
			// 
			// cbMemoNumber
			// 
			this.cbMemoNumber.Location = new System.Drawing.Point(452, 167);
			this.cbMemoNumber.Name = "cbMemoNumber";
			this.cbMemoNumber.Size = new System.Drawing.Size(180, 20);
			this.cbMemoNumber.TabIndex = 47;
			this.cbMemoNumber.SelectedIndexChanged += new System.EventHandler(this.cbMemoNumber_SelectedIndexChanged);
			// 
			// pItem
			// 
			this.pItem.AutoScroll = true;
			this.pItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pItem.Controls.Add(this.label12);
			this.pItem.Controls.Add(this.tbLotNumber);
			this.pItem.Controls.Add(this.label4);
			this.pItem.Controls.Add(this.incPrevNumber);
			this.pItem.Controls.Add(this.tbComment);
			this.pItem.Controls.Add(this.label8);
			this.pItem.Controls.Add(this.label7);
			this.pItem.Controls.Add(this.label6);
			this.pItem.Controls.Add(this.label5);
			this.pItem.Controls.Add(this.lbMemoNumber);
			this.pItem.Controls.Add(this.tbMemoNumber);
			this.pItem.Controls.Add(this.incNewNumber);
			this.pItem.Enabled = false;
			this.pItem.Location = new System.Drawing.Point(325, 80);
			this.pItem.Name = "pItem";
			this.pItem.Size = new System.Drawing.Size(315, 195);
			this.pItem.TabIndex = 48;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(5, 24);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(104, 16);
			this.label12.TabIndex = 46;
			this.label12.Text = "New #";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbLotNumber
			// 
			this.tbLotNumber.Enabled = false;
			this.tbLotNumber.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.tbLotNumber.Location = new System.Drawing.Point(125, 66);
			this.tbLotNumber.Name = "tbLotNumber";
			this.tbLotNumber.Size = new System.Drawing.Size(180, 20);
			this.tbLotNumber.TabIndex = 3;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(5, 71);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(107, 15);
			this.label4.TabIndex = 2;
			this.label4.Text = "Lot Number";
			// 
			// tbComment
			// 
			this.tbComment.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.tbComment.Location = new System.Drawing.Point(5, 128);
			this.tbComment.Multiline = true;
			this.tbComment.Name = "tbComment";
			this.tbComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbComment.Size = new System.Drawing.Size(300, 56);
			this.tbComment.TabIndex = 11;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(8, 112);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(96, 15);
			this.label8.TabIndex = 10;
			this.label8.Text = "Comment";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(5, 48);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(107, 15);
			this.label7.TabIndex = 8;
			this.label7.Text = "Old Item #";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(5, 88);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(107, 15);
			this.label6.TabIndex = 6;
			this.label6.Text = "Customer Weight";
			this.label6.Visible = false;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(5, 72);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(120, 15);
			this.label5.TabIndex = 4;
			this.label5.Text = "Weight";
			this.label5.Visible = false;
			// 
			// lbMemoNumber
			// 
			this.lbMemoNumber.Location = new System.Drawing.Point(5, 89);
			this.lbMemoNumber.Name = "lbMemoNumber";
			this.lbMemoNumber.Size = new System.Drawing.Size(115, 15);
			this.lbMemoNumber.TabIndex = 44;
			this.lbMemoNumber.Text = "Memo Number";
			// 
			// tbMemoNumber
			// 
			this.tbMemoNumber.Enabled = false;
			this.tbMemoNumber.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.tbMemoNumber.Location = new System.Drawing.Point(125, 104);
			this.tbMemoNumber.Name = "tbMemoNumber";
			this.tbMemoNumber.Size = new System.Drawing.Size(180, 20);
			this.tbMemoNumber.TabIndex = 45;
			this.tbMemoNumber.Visible = false;
			// 
			// chk_SkipAddDocs
			// 
			this.chk_SkipAddDocs.Location = new System.Drawing.Point(910, 660);
			this.chk_SkipAddDocs.Name = "chk_SkipAddDocs";
			this.chk_SkipAddDocs.Size = new System.Drawing.Size(105, 20);
			this.chk_SkipAddDocs.TabIndex = 50;
			this.chk_SkipAddDocs.Text = "Add Documents";
			// 
			// lvItemData
			// 
			this.lvItemData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
			this.lvItemData.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lvItemData.FullRowSelect = true;
			this.lvItemData.GridLines = true;
			this.lvItemData.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvItemData.Location = new System.Drawing.Point(650, 30);
			this.lvItemData.MultiSelect = false;
			this.lvItemData.Name = "lvItemData";
			this.lvItemData.Size = new System.Drawing.Size(360, 415);
			this.lvItemData.TabIndex = 51;
			this.lvItemData.UseCompatibleStateImageBehavior = false;
			this.lvItemData.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Part Name";
			this.columnHeader1.Width = 105;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Grade";
			this.columnHeader2.Width = 122;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Value";
			this.columnHeader3.Width = 116;
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label9.Location = new System.Drawing.Point(680, 5);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(285, 20);
			this.label9.TabIndex = 52;
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lvMigratedItemData
			// 
			this.lvMigratedItemData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader4,
            this.columnHeader6});
			this.lvMigratedItemData.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lvMigratedItemData.FullRowSelect = true;
			this.lvMigratedItemData.GridLines = true;
			this.lvMigratedItemData.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvMigratedItemData.Location = new System.Drawing.Point(650, 480);
			this.lvMigratedItemData.MultiSelect = false;
			this.lvMigratedItemData.Name = "lvMigratedItemData";
			this.lvMigratedItemData.Size = new System.Drawing.Size(360, 155);
			this.lvMigratedItemData.TabIndex = 54;
			this.lvMigratedItemData.UseCompatibleStateImageBehavior = false;
			this.lvMigratedItemData.View = System.Windows.Forms.View.Details;
			this.lvMigratedItemData.DoubleClick += new System.EventHandler(this.lvMigratedItemData_DoubleClick);
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "From Old Number";
			this.columnHeader5.Width = 122;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Current Order";
			this.columnHeader4.Width = 110;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "To New Number";
			this.columnHeader6.Width = 109;
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label10.Location = new System.Drawing.Point(695, 450);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(290, 25);
			this.label10.TabIndex = 55;
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnMeasureByCP
			// 
			this.btnMeasureByCP.BackColor = System.Drawing.Color.Tan;
			this.btnMeasureByCP.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnMeasureByCP.Location = new System.Drawing.Point(455, 30);
			this.btnMeasureByCP.Name = "btnMeasureByCP";
			this.btnMeasureByCP.Size = new System.Drawing.Size(80, 20);
			this.btnMeasureByCP.TabIndex = 56;
			this.btnMeasureByCP.Text = "Get CP Set";
			this.btnMeasureByCP.UseVisualStyleBackColor = false;
			this.btnMeasureByCP.Click += new System.EventHandler(this.btnMeasureByCP_Click);
			// 
			// btnMeasureByFullSet
			// 
			this.btnMeasureByFullSet.BackColor = System.Drawing.Color.LightGray;
			this.btnMeasureByFullSet.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnMeasureByFullSet.Location = new System.Drawing.Point(455, 30);
			this.btnMeasureByFullSet.Name = "btnMeasureByFullSet";
			this.btnMeasureByFullSet.Size = new System.Drawing.Size(80, 20);
			this.btnMeasureByFullSet.TabIndex = 57;
			this.btnMeasureByFullSet.Text = "Get Full Set";
			this.btnMeasureByFullSet.UseVisualStyleBackColor = false;
			this.btnMeasureByFullSet.Click += new System.EventHandler(this.btnMeasureByFullSet_Click);
			// 
			// label14
			// 
			this.label14.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label14.Location = new System.Drawing.Point(425, 5);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(210, 20);
			this.label14.TabIndex = 58;
			this.label14.Text = "Measurements By CP";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label15
			// 
			this.label15.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.label15.Location = new System.Drawing.Point(660, 645);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(240, 35);
			this.label15.TabIndex = 59;
			// 
			// otOrders
			// 
			this.otOrders.CheckBoxes = true;
			this.otOrders.IsDocumentGhost = false;
			this.otOrders.IsExpand = false;
			this.otOrders.Location = new System.Drawing.Point(5, 80);
			this.otOrders.Name = "otOrders";
			this.otOrders.Selected = null;
			this.otOrders.ShowColorAndClarity = true;
			this.otOrders.Size = new System.Drawing.Size(315, 325);
			this.otOrders.TabIndex = 34;
			this.otOrders.SelectedItemChanged += new System.EventHandler(this.otOrders_SelectedItemChanged);
			this.otOrders.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.otOrders_BeforeSelect);
			// 
			// incNumber
			// 
			this.incNumber.ItemNumber = "";
			this.incNumber.Location = new System.Drawing.Point(452, 83);
			this.incNumber.Name = "incNumber";
			this.incNumber.Size = new System.Drawing.Size(180, 20);
			this.incNumber.TabIndex = 12;
			this.incNumber.CodeEntered += new System.EventHandler(this.incNumber_KeyDown);
			this.incNumber.Load += new System.EventHandler(this.incNumber_Load);
			// 
			// ctcCustomer
			// 
			this.ctcCustomer.DefaultText = "Customer lookup";
			this.ctcCustomer.DisplayMember = "CustomerName";
			this.ctcCustomer.InsertDefaultRow = true;
			this.ctcCustomer.Location = new System.Drawing.Point(5, 5);
			this.ctcCustomer.Name = "ctcCustomer";
			this.ctcCustomer.SelectedCode = "";
			this.ctcCustomer.Size = new System.Drawing.Size(390, 40);
			this.ctcCustomer.TabIndex = 40;
			this.ctcCustomer.ValueMember = "CustomerID";
			this.ctcCustomer.SelectionChanged += new System.EventHandler(this.ctcCustomer_SelectionChanged);
			this.ctcCustomer.Load += new System.EventHandler(this.ctcCustomer_Load);
			// 
			// incPrevNumber
			// 
			this.incPrevNumber.ItemNumber = "";
			this.incPrevNumber.Location = new System.Drawing.Point(125, 45);
			this.incPrevNumber.Name = "incPrevNumber";
			this.incPrevNumber.Size = new System.Drawing.Size(180, 20);
			this.incPrevNumber.TabIndex = 13;
			// 
			// incNewNumber
			// 
			this.incNewNumber.ItemNumber = "";
			this.incNewNumber.Location = new System.Drawing.Point(125, 23);
			this.incNewNumber.Name = "incNewNumber";
			this.incNewNumber.Size = new System.Drawing.Size(180, 20);
			this.incNewNumber.TabIndex = 12;
			// 
			// ptPartTree
			// 
			this.ptPartTree.Location = new System.Drawing.Point(0, 125);
			this.ptPartTree.Name = "ptPartTree";
			this.ptPartTree.Size = new System.Drawing.Size(315, 170);
			this.ptPartTree.TabIndex = 41;
			this.ptPartTree.Changed += new System.EventHandler(this.ptPartTree_Changed);
			this.ptPartTree.Load += new System.EventHandler(this.ptPartTree_Load);
			// 
			// wcCustWeight
			// 
			this.wcCustWeight.IsMeasureUnit = true;
			this.wcCustWeight.IsRequired = true;
			this.wcCustWeight.Location = new System.Drawing.Point(125, 60);
			this.wcCustWeight.Name = "wcCustWeight";
			this.wcCustWeight.Size = new System.Drawing.Size(215, 20);
			this.wcCustWeight.TabIndex = 14;
			this.wcCustWeight.Visible = false;
			// 
			// wcWeight
			// 
			this.wcWeight.IsMeasureUnit = true;
			this.wcWeight.IsRequired = true;
			this.wcWeight.Location = new System.Drawing.Point(125, 40);
			this.wcWeight.Name = "wcWeight";
			this.wcWeight.Size = new System.Drawing.Size(215, 20);
			this.wcWeight.TabIndex = 15;
			this.wcWeight.Visible = false;
			// 
			// RemeasureForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
			this.ClientSize = new System.Drawing.Size(1018, 705);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.btnMeasureByFullSet);
			this.Controls.Add(this.btnMeasureByCP);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.lvMigratedItemData);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.lvItemData);
			this.Controls.Add(this.chk_SkipAddDocs);
			this.Controls.Add(this.otOrders);
			this.Controls.Add(this.cbMemoNumber);
			this.Controls.Add(this.btnSARIN);
			this.Controls.Add(this.incNumber);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.ctcCustomer);
			this.Controls.Add(this.StatusBar);
			this.Controls.Add(this.btnSelect);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.dtpTo);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dtpFrom);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cbPeriod);
			this.Controls.Add(this.pItem);
			this.Controls.Add(this.pPart);
			this.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "RemeasureForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "ReMeasure";
			this.pPart.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.pItem.ResumeLayout(false);
			this.pItem.PerformLayout();
			this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /*		[STAThread]
                static void Main() 
                {
                    Application.Run(new Form1());
                }
        */
        #endregion Generated

        private void Initialize(int AccessLevel)
        {
            isItemEntered = false;
            isFirst = true;
            this.Text = Service.sProgramTitle + this.Text;
            this.iAccessLevel = AccessLevel;
            dsData = new DataSet();
            dsData.Tables.Add(Service.GetMeasureValues());//Procedure dbo.spGetMeasureValues
            ctcCustomer.Initialize(Service.GetAllCustomer());
            wcCustWeight.Initialize(Service.GetMeasureUnits().DefaultView);
            wcWeight.Initialize(Service.GetMeasureUnits().DefaultView);
            bOnlyBatchUpdated = false;
            cbMemoNumber.Enabled = false;
            btnUpdateBatch.Enabled = false;
            Clear();
            this.chk_SkipAddDocs.Checked = false;

        }

        private void EnableItem(bool b)
        {
            pCharacteristics.Enabled = b;
            pItem.Enabled = b;
            btnClear.Enabled = b;
            btnUpdate.Enabled = b;
            btnReset.Enabled = b;
            ptPartTree.Enabled = b;
            btnUpdateBatch.Enabled = !b;
        }

        private void ClearItem()
        {
            EnableItem(false);
            ptPartTree.Clear();
            pCharacteristics.Controls.Clear();
        }

        private void ClearOrder()
        {
            otOrders.Clear();
            ClearItem();
            btnUpdateBatch.Enabled = false;
            this.chk_SkipAddDocs.Checked = false;
            this.lvItemData.Items.Clear();
            this.label9.Text = "";
            this.label10.Text = "";
            this.label11.Text = "";
            this.label13.Text = "";
            this.label15.Text = "";
            this.lvMigratedItemData.Items.Clear();
            this.incPrevNumber.ItemNumber = "";
            this.incNewNumber.ItemNumber = "";
            tbComment.Text = "";
            tbComment.Enabled = false;
            bFullAccess = false;
        }

        private void Clear()
        {
            ctcCustomer.Clear();
            ClearOrder();
            pictureBox1.Image = null;
            btnMeasureByCP.Enabled = false;
            btnMeasureByCP.Visible = false;
            btnMeasureByFullSet.Enabled = true;
            btnMeasureByFullSet.Visible = true;
        }

        private void CreateCharacteristic(DataRow[] drSet)
        {
            pCharacteristics.Controls.Clear();
            int ySpacing = 5;
            int xSpacing = 5;
            foreach (DataRow row in drSet)
            {
                if ((Convert.ToDecimal(row["MeasureClass"]) > 4) ||
                    (Convert.ToDecimal(row["MeasureClass"]) < 1) ||
                    row["PartID"].ToString() != ptPartTree.SelectedRow["ID"].ToString())
                    continue;

                string sTag = "MeasureID = '" + row["MeasureID"].ToString() + "' and PartID='" + row["PartID"].ToString() + "'";
                int iLastControlIndex = pCharacteristics.Controls.Count - 1;
                int y;
                if (iLastControlIndex == -1) y = ySpacing;
                else
                {
                    Control cLastControl = pCharacteristics.Controls[iLastControlIndex];
                    y = cLastControl.Location.Y + cLastControl.Size.Height + ySpacing;
                }

                Label lCharName = new Label();
                lCharName.Text = row["MeasureTitle"].ToString();
                lCharName.Size = new Size(120, 20);
                lCharName.Location = new Point(1, y);
                pCharacteristics.Controls.Add(lCharName);

                TextBox tbValue;

                System.Windows.Forms.Control cntrlMy = null;


                switch (row["MeasureClass"].ToString())
                {
                    case "1":
                        DataView dvList = new DataView(dsData.Tables["MeasureValues"], "MeasureValueMeasureID = " + row["MeasureID"], "", DataViewRowState.CurrentRows);

                        ComboBox cbValue = new ComboBox();
                        cntrlMy = cbValue;

                        cbValue.DataSource = dvList;
                        cbValue.ValueMember = "MeasureValueID";
                        cbValue.DisplayMember = "MeasureValueName";


                        cbValue.DropDownStyle = ComboBoxStyle.DropDownList;
                        cbValue.Size = new Size(170, 30);
                        cbValue.Location = new Point(lCharName.Size.Width + xSpacing, y);

                        cbValue.Tag = sTag;
                        pCharacteristics.Controls.Add(cbValue);

                        string sMeasureValueID = row["MeasureValueID"].ToString();
                        if (sMeasureValueID.Length > 0)
                        {
                            DataRow[] drSelectedValue = dsData.Tables["MeasureValues"].Select("MeasureValueID = '" + row["MeasureValueID"] + "'");
                            string sCurrentVal = drSelectedValue[0]["MeasureValueName"].ToString();
                            int iCurIndex = cbValue.FindStringExact(sCurrentVal);
                            cbValue.SelectedIndex = iCurIndex;
                        }
                        else
                        {
                            cbValue.SelectedIndex = -1;
                        }

                        cbValue.SelectedIndexChanged += new System.EventHandler(cbChar_SelectedIndexChanged);

                        break;

                    case "2":
                        tbValue = new TextBox();
                        cntrlMy = tbValue;
                        tbValue.Text = row["StringValue"].ToString();
                        tbValue.Size = new Size(170, 30);
                        tbValue.Location = new Point(lCharName.Size.Width + xSpacing, y);
                        tbValue.Leave += new System.EventHandler(tbCharStr_Leave);
                        tbValue.Tag = sTag;
                        pCharacteristics.Controls.Add(tbValue);
                        break;

                    case "3":
                        tbValue = new TextBox();
                        cntrlMy = tbValue;
                        tbValue.Text = row["MeasureValue"].ToString();
                        tbValue.Size = new Size(170, 30);
                        tbValue.Location = new Point(lCharName.Size.Width + xSpacing, y);
                        tbValue.Leave += new System.EventHandler(tbChar_Leave);
                        tbValue.Tag = sTag;
                        pCharacteristics.Controls.Add(tbValue);
                        break;

                    case "4":
                        tbValue = new TextBox();
                        cntrlMy = tbValue;
                        tbValue.Text = row["StringValue"].ToString();
                        tbValue.Size = new Size(170, 30);
                        tbValue.Location = new Point(lCharName.Size.Width + xSpacing, y);
                        tbValue.Leave += new System.EventHandler(tbCharStr_Leave);
                        tbValue.Tag = sTag;
                        pCharacteristics.Controls.Add(tbValue);
                        break;
                }
                if (cntrlMy != null) // TODO: check isEdit
                {
                    // Calculated weight
                    //if ( row["MeasureCode"].ToString()=="5" )
                    //	cntrlMy.Enabled = false;
                    // Apprasal value
                    //if ( row["MeasureCode"].ToString()=="10" )
                    //	cntrlMy.Enabled = false;
                }
            }
        }

        private void ctcCustomer_SelectionChanged(object sender, System.EventArgs e)
        {
            DataSet ds = new DataSet();

            this.Cursor = Cursors.WaitCursor;
            this.StatusBar.Text = "Loading customer details";
            string sCustomerID = ctcCustomer.SelectedID;
            if (sCustomerID == "0")
            {
                Clear();
                btnSelect.Enabled = false;
            }
            else
            {
                string sCustomerOfficeId = ctcCustomer.SelectedID.Split('_')[0];
                Service.SetDepartmentOfficeId(sCustomerOfficeId);
                string sCustomerCode = ctcCustomer.SelectedCode;
                /** load one item when it's code entered in field Item Number
                * by Vetal_242
                * 04.06.2006
                * */

                //fixed by 3ter on 2006.05.15
                if (incNumber.Text.Length > 0)
                {
                    isItemEntered = false;
                    ds = Service.GetOrderTreeDataByGroupCode(incNumber.Get().Split('.')[0]);//Load Order-Batch_Item-Doc list
                    cbPeriod.SelectedIndex = -1;
                    if (ds.Tables["tblOrder"].Rows[0]["CustomerCode"].ToString() != sCustomerCode)
                    {
                        StatusBar.Text = "Specified item doesn't belong to the customer";
                        this.Cursor = Cursors.Default;
                        return;
                    }

                    otOrders.Initialize(ds);

                    try
                    {
                        otOrders.SelectNode(incNumber.Get());
                    }
                    catch (Exception exc)
                    {
                        if (exc.Message == "Please type again. Acceptable format is #####.#####.###.##")
                            StatusBar.Text = "Couldn't parse specified item code";
                        else
                            MessageBox.Show(exc.Message, "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    ds = Service.GetOrderTreeDataByCustomerCode(sCustomerCode);
                    cbPeriod.SelectedIndex = -1;
                    otOrders.Initialize(ds);
                }

                /*

                if(!isItemEntered)
                {
                    DataSet ds = Service.GetOrderTreeDataByCustomerCode(sCustomerCode);
                    //Service.debug_DiaspalyDataSet(ds);
                    otOrders.Initialize(ds);
                    btnSelect.Enabled = true;
                    try
                    {
                        otOrders.SelectNode(incNumber.Get());
                    }
                    catch(Exception exc)
                    {
                        MessageBox.Show(exc.Message, "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    isItemEntered = false;
                    DataSet ds = Service.GetOrderTreeDataByGroupCode(incNumber.Get().Split('.')[0]);
                    otOrders.Initialize(ds);
					
                    btnSelect.Enabled = false;//true
                    try
                    {
                        otOrders.SelectNode(incNumber.Get());
                    }
                    catch{}
                }
                */
            }
            this.Cursor = Cursors.Default;
            this.StatusBar.Text = "Ready";
        }

        private void cbPeriod_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (cbPeriod.SelectedItem.ToString() == "From - To")
            {
                dtpFrom.Enabled = true;
                dtpTo.Enabled = true;
            }
            else
            {
                dtpFrom.Enabled = false;
                dtpTo.Enabled = false;
            }

            if (cbPeriod.SelectedItem.ToString() == "This Month")
            {
                dtpFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
                dtpTo.Value = DateTime.Now;
            }

            if (cbPeriod.SelectedItem.ToString() == "This Year")
            {
                dtpFrom.Value = new DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0);
                dtpTo.Value = DateTime.Now;
            }

            if (cbPeriod.SelectedItem.ToString() == "Last Month")
            {
                if (DateTime.Now.Month != 1)
                {
                    dtpFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 1, 0, 0, 0);
                    dtpTo.Value = new DateTime(DateTime.Now.Year,
                        DateTime.Now.Month - 1,
                        DateTime.DaysInMonth(dtpFrom.Value.Year, dtpFrom.Value.Month), 23, 59, 59);
                }
                else
                {
                    dtpFrom.Value = new DateTime(DateTime.Now.Year, 12, 1, 0, 0, 0);
                    dtpTo.Value = new DateTime(DateTime.Now.Year, 12, DateTime.DaysInMonth(dtpFrom.Value.Year, dtpFrom.Value.Month), 23, 59, 59);
                }
            }

            if (cbPeriod.SelectedItem.ToString() == "Last Year")
            {
                dtpFrom.Value = new DateTime(DateTime.Now.Year - 1, 1, 1, 0, 0, 0);
                dtpTo.Value = new DateTime(DateTime.Now.Year - 1, 12, 31, 23, 59, 59);
            }
        }

        private void btnSelect_Click(object sender, System.EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.StatusBar.Text = "Filtering by date";
            DataSet ds = Service.GetOrderTreeDataByCustomerCodeAndFilterDate(ctcCustomer.SelectedCode, dtpFrom.Value.ToString(), dtpTo.Value.ToString());
            otOrders.Initialize(ds);
            this.Cursor = Cursors.Default;
            this.StatusBar.Text = "Ready";
        }

        private void otOrders_SelectedItemChanged(object sender, System.EventArgs e)
        {
            //E.B.M.
            // getting batch row

            this.Cursor = Cursors.WaitCursor;
            this.StatusBar.Text = "Loading order details";
            this.chk_SkipAddDocs.Checked = false;
            bool b = (otOrders.Selected.tblName == Cntrls.OrdersTree.TableList.Item[1]);
            EnableItem(b);
            pCharacteristics.Controls.Clear();
            btnSARIN.Enabled = false;
            //			ListViewItem lvi;
            //			lvItemData.Items.Clear();
            //			lvMigratedItemData.Items.Clear();
            label9.Text = "";
            label10.Text = "";
            label11.Text = "";
            pictureBox1.Image = null;
            incNumber.ItemNumber = "";
            if (otOrders.Selected.drNode != null &&
                otOrders.Selected.drNode.Table.TableName == "tblBatch")
            {
                DataRow drBatch = otOrders.SelectedBatch.drNode;

                //by vetal_242 07.07.2006 
                DataSet dsMemoNumbers = Service.GetGroupMemoNumbers(drBatch["GroupID"].ToString());//Procedure dbo.spGetGroupMemoNumber
                dsMemoNumbers.Tables[0].TableName = "MemoNumbers";

                //by vetal_242 25.09.2006
                DataRow drNone = dsMemoNumbers.Tables[0].NewRow();
                drNone["MemoNumberID"] = System.DBNull.Value;
                drNone["Name"] = "[none]";
                dsMemoNumbers.Tables[0].Rows.InsertAt(drNone, 0);

                cbMemoNumber.DataSource = dsMemoNumbers;
                //isFirst = false;
                cbMemoNumber.DisplayMember = "MemoNumbers.Name";
                //isFirst = false;
                cbMemoNumber.ValueMember = "MemoNumbers.MemoNumberID";
                cbMemoNumber.SelectedIndex = cbMemoNumber.FindString(drBatch["MemoNumber"].ToString());


                cbMemoNumber.Enabled = true;
                isFirst = false;
                //tbMemoNumber.Enabled = true;
                //tbMemoNumber.Text =  drBatch["MemoNumber"].ToString();
            }
            else
            {
                if (otOrders.Selected.drNode != null &&
                    otOrders.Selected.drNode.Table.TableName == "tblItem")
                {
                    DataRow drBatch = otOrders.SelectedBatch.drNode;
                    cbMemoNumber.SelectedIndex = cbMemoNumber.FindString(drBatch["MemoNumber"].ToString());
                    btnSARIN.Enabled = true;
                }
                tbMemoNumber.Enabled = false;
                cbMemoNumber.Enabled = false;
            }

            if (otOrders.Selected == null)
            {
                this.Cursor = Cursors.Default;
                this.StatusBar.Text = "Ready";
                return;
            }

            if (b)
            {
                DataRow drItem = otOrders.Selected.drNode;

                try
                {
                    incNumber.ItemNumber = drItem["Name"].ToString();

                    string sPrevNum = "";
                    string sNewNum = "";
                    try
                    {
                        sPrevNum = GraderLib.GetCorrectFullCodeString(
                            Convert.ToInt32(drItem["PrevGroupCode"]),
                            Convert.ToInt32(drItem["PrevGroupCode"]),
                            Convert.ToInt32(drItem["PrevBatchCode"]),
                            Convert.ToInt32(drItem["PrevItemCode"]));
                    }
                    catch
                    {
                        sPrevNum = "";
                    }

                    try
                    {
                        sNewNum = GraderLib.GetCorrectFullCodeString(
                            Convert.ToInt32(drItem["NewOrderCode"]),
                            Convert.ToInt32(drItem["NewOrderCode"]),
                            Convert.ToInt32(drItem["NewBatchCode"]),
                            Convert.ToInt32(drItem["NewItemCode"]));
                    }
                    catch
                    {
                        sNewNum = "";
                    }
                    //sd 2006.12.08
                    //if(incNumber.ItemNumber == sPrevNum)
                    //sPrevNum = "";

                    tbMemoNumber.Enabled = false;
                    cbMemoNumber.Enabled = false;
                    incPrevNumber.ItemNumber = sPrevNum;
                    incNewNumber.ItemNumber = sNewNum;
                    wcCustWeight.Weight = drItem["CustomerItemWeight"].ToString().Trim() == "" ? "0" : drItem["CustomerItemWeight"].ToString().Trim();
                    wcCustWeight.MeasureUnitID = drItem["CustomerItemWeightUnitID"].ToString();
					wcWeight.Weight = drItem["Weight"].ToString().Trim() == "" ? "0" : drItem["Weight"].ToString().Trim();
                    wcWeight.MeasureUnitID = drItem["WeightUnitID"].ToString();
                    tbLotNumber.Text = drItem["LotNumber"].ToString();
                    this.tbComment.Text = drItem["ItemComment"].ToString();

                    StatusBar.Text = "";
                }
                catch (Exception exc)
                {
                    StatusBar.Text = "Error: " + exc.Message;
                }


                //  --  Create DataSet for Parts and Measures

                //				string sItemTypeID = otOrders.SelectedBatch.drNode["ItemTypeID"].ToString();
                //				string sBatchID = otOrders.Selected.drNode["BatchID"].ToString();
                //				string sItemCode = otOrders.Selected.drNode["Code"].ToString();
                //
                //				string sNewBatchID = otOrders.Selected.drNode["NewBatchID"].ToString();
                //				string sNewItemCode = otOrders.Selected.drNode["NewItemCode"].ToString();
                //
                //				dsParts = new DataSet();
                //				//Procedure dbo.spGetPartValue
                //				dsParts.Tables.Add(Service.GetPartValue(sNewBatchID, sNewItemCode));		//tblName : PartValue / 0 - filled table
                //				
                ////				DataTable dtMeasureType = Service.GetMeasuresByItemType(sItemTypeID);//tblName : MeasuresByItemType / 1 - empty
                //				//by vetal_242 29.09.2006 display only CP Measures
                //				DataTable dtMeasureType = Service.GetMeasuresByCP(sItemTypeID, sBatchID);
                //				dtMeasureType.TableName = "Measures";	
                //				dsParts.Tables.Add(dtMeasureType);		//tblName : Measures
                //
                //				//copy structure
                //				foreach(DataColumn column in dsParts.Tables["PartValue"].Columns)
                //				{
                //					if (dsParts.Tables["Measures"].Columns[column.ColumnName] == null)
                //					{
                //						dsParts.Tables["Measures"].Columns.Add(column.ColumnName,column.DataType, column.Expression);
                //					}
                //				}
                //				
                //
                //				dsParts.Tables.Add(Service.GetParts(sItemTypeID));	//tblName : Parts
                //				dsParts.Tables.Add(Service.GetPartsStruct());	//tblName : SetParts
                //				
                //				ptPartTree.Initialize(dsParts.Tables["Parts"]);

                //New part added by sasha 11/16/08
                LoadAllForSelectedItem();

                ptPartTree.Initialize(dsParts.Tables["Parts"]);
                ptPartTree.tvPartTree.Select();
                btnMeasureByCP.Visible = false;
                btnMeasureByCP.Enabled = false;
                btnMeasureByFullSet.Visible = true;
                btnMeasureByFullSet.Enabled = true;

                //CreateDataSet_Parts_Measures();//  --  Create DataSet for Parts and Measures - for selected item

                //LoadItemData();// Load parts - data for selected item
                // Load parts - data for selected item
                //				DataTable	dtPartValue = dsParts.Tables["PartValue"];
                //				DataRow[]	drPartValue = dtPartValue.Select("", "PartID");
                //				DataTable	dtParts = dsParts.Tables["Parts"];
                //				if (incNumber.Text.Trim() != incPrevNumber.Text.Trim() && incPrevNumber.Text.Trim() != "")
                //				{
                //					label9.Text = "Data for # " + incNumber.Text.Substring(incNumber.Text.IndexOf(".") + 1) + " (" + incPrevNumber.Text.Substring(incNumber.Text.IndexOf(".") + 1) + ")";
                //				}
                //				else
                //				{
                //					label9.Text = "Data for # " + incNumber.Text.Substring(incNumber.Text.IndexOf(".") + 1);
                //				}
                //				
                //				foreach(DataRow dr in drPartValue)
                //				{
                //					if ((dr["MeasureClass"].ToString() == "1" ||
                //						dr["MeasureClass"].ToString() == "2" || 
                //						dr["MeasureClass"].ToString() == "3" ||
                //						dr["MeasureClass"].ToString() == "4")
                //						&&
                //						(dr["MeasureValueName"]!= DBNull.Value ||
                //						dr["MeasureValue"]	!= DBNull.Value ||
                //						dr["StringValue"]	!= DBNull.Value)
                //						)
                //
                //					{
                //						lvi = new ListViewItem(dtParts.Select("ID="+dr["PartID"].ToString())[0]["Name"].ToString());
                //						lvi.SubItems.Add(dr["MeasureName"].ToString());
                //								
                //						switch (dr["MeasureClass"].ToString())
                //						{
                //							case "1":
                //							{
                //								lvi.SubItems.Add(dr["MeasureValueName"].ToString());
                //								break;
                //							}
                //							case "2":
                //							{
                //								lvi.SubItems.Add(dr["StringValue"].ToString());
                //								break;
                //							}
                //							case "3":
                //							{
                //								try
                //								{
                //									lvi.SubItems.Add(Convert.ToDouble(dr["MeasureValue"]).ToString(".##"));
                //								}
                //								catch{}
                //								break;
                //							}
                //							case "4":
                //							{
                //								lvi.SubItems.Add(dr["StringValue"].ToString());
                //								break;
                //							}								
                //						}
                //						lvItemData.Items.Add(lvi);
                //					}	
                //				}

                //LoadPicture(); //Load picture for selected item

                //End of new part
            }
            this.Cursor = Cursors.Default;
            this.StatusBar.Text = "Ready";
        }

        private bool CreateDataSet_Parts_Measures()
        {
            string sItemTypeID = otOrders.SelectedBatch.drNode["ItemTypeID"].ToString();
            string sBatchID = otOrders.Selected.drNode["BatchID"].ToString();
            string sItemCode = otOrders.Selected.drNode["Code"].ToString();

            string sNewBatchID = otOrders.Selected.drNode["NewBatchID"].ToString();
            string sNewItemCode = otOrders.Selected.drNode["NewItemCode"].ToString();

            dsParts = new DataSet();
            //Procedure dbo.spGetPartValue
            dsParts.Tables.Add(Service.GetPartValue(sNewBatchID, sNewItemCode));//Procedure dbo.spGetPartValue		//tblName : PartValue / 0 - filled table
            DataTable dtPartsValue = dsParts.Tables[0];
            DataTable dtMeasureType;
            if (dtPartsValue.Rows.Count > 0)
            {
                //				DataTable dtMeasureType = Service.GetMeasuresByItemType(sItemTypeID);//tblName : MeasuresByItemType / 1 - empty
                //by vetal_242 29.09.2006 display only CP Measures
                //DataTable dtMeasureType =  Service.GetMeasuresByCP(sItemTypeID, sBatchID);  

                //By Sasha 06/23/09 - show all measure/ measure by CP 
                if (!bFullAccess)
                {
                    dtMeasureType = Service.GetMeasuresByCP(sItemTypeID, sBatchID);
                }
                else
                {
                    dtMeasureType = Service.GetMeasuresByItemTypePartID(sItemTypeID);
                }

                dtMeasureType.TableName = "Measures";
                dsParts.Tables.Add(dtMeasureType);		//tblName : Measures

                //copy structure
                foreach (DataColumn column in dsParts.Tables["PartValue"].Columns)
                {
                    if (dsParts.Tables["Measures"].Columns[column.ColumnName] == null)
                    {
                        dsParts.Tables["Measures"].Columns.Add(column.ColumnName, column.DataType, column.Expression);
                    }
                }

                dsParts.Tables.Add(Service.GetParts(sItemTypeID));	//tblName : Parts
                dsParts.Tables.Add(Service.GetPartsStruct());	//tblName : SetParts

                return true;
            }
            return false;
        }

        private void LoadAllForSelectedItem()
        {

            string[] sItemNumber = incPrevNumber.Get().Split('.');
            string sPrevItemNumber = sItemNumber[1] + sItemNumber[2] + sItemNumber[3];
            //DataRow[] drPrefixs =	dsParts.Tables[0].Select("MeasureCode='112'  and BatchID='" + batchID + "' and ItemCode='" + ItemCode + "'");

            sItemNumber = incNumber.Get().Split('.');
            string sItemNumber1 = sItemNumber[1] + sItemNumber[2] + sItemNumber[3];

            label13.Text = "#" + (sItemNumber1 == sPrevItemNumber ? sItemNumber1 : sItemNumber1 + "/" + sPrevItemNumber) + ":\n" + "No Plotting";

            DirectoryInfo di;
            try
            {
                di = new DirectoryInfo(Client.GetOfficeDirPath("plotDir"));

                FileInfo[] fi = di.GetFiles(sPrevItemNumber + "*.cdr");

                if (fi.Length > 0)
                    label13.Text = "#" + (sItemNumber1 == sPrevItemNumber ? sItemNumber1 : sItemNumber1 + "/" + sPrevItemNumber) + ":\n" + "Plotting OK";
            }
            catch (Exception exc)
            {
                label15.Text = "";
            }

            if (CreateDataSet_Parts_Measures())
            {
                LoadItemData();
                LoadPicture();

                label15.Text = "";

                DataRow[] drPrefixs = dsParts.Tables[0].Select("MeasureCode= '112'");
                if (drPrefixs.Length > 0)
                {
                    label15.Text = "#" + (sItemNumber1 == sPrevItemNumber ? sItemNumber1 : sItemNumber1 + "/" + sPrevItemNumber) + ":\n" + "No PSX files";

                    try
                    {
                        DirectoryInfo di1;
                        di1 = new DirectoryInfo(Client.GetOfficeDirPath("lightReturnDir"));
                        foreach (DataRow dr in drPrefixs)
                        {
                            FileInfo[] fi1 = di1.GetFiles(dr["StringValue"].ToString() + "*");
                            if (fi1.Length > 5)
                                label15.Text = "#" + (sItemNumber1 == sPrevItemNumber ? sItemNumber1 : sItemNumber1 + "/" + sPrevItemNumber) + ":\n" + "PSX files OK";
                            break;
                        }
                    }
                    catch (Exception exc)
                    {
                        label15.Text = "";
                    }
                }
            }
        }

        private void LoadItemData()
        {
            ListViewItem lvi;
            lvItemData.Items.Clear();
            DataTable dtPartValue = dsParts.Tables["PartValue"];
            DataRow[] drPartValue = dtPartValue.Select("", "PartID");
            DataTable dtParts = dsParts.Tables["Parts"];
            if (incNumber.Text.Trim() != incPrevNumber.Text.Trim() && incPrevNumber.Text.Trim() != "")
            {
                label9.Text = "Data for # " + incNumber.Text.Substring(incNumber.Text.IndexOf(".") + 1) + " (" + incPrevNumber.Text.Substring(incNumber.Text.IndexOf(".") + 1) + ")";
            }
            else
            {
                label9.Text = "Data for # " + incNumber.Text.Substring(incNumber.Text.IndexOf(".") + 1);
            }

            try
            {
                foreach (DataRow dr in drPartValue)
                {
                    if ((dr["MeasureClass"].ToString() == "1" ||
                        dr["MeasureClass"].ToString() == "2" ||
                        dr["MeasureClass"].ToString() == "3" ||
                        dr["MeasureClass"].ToString() == "4")
                        &&
                        (dr["MeasureValueName"] != DBNull.Value ||
                        dr["MeasureValue"] != DBNull.Value ||
                        dr["StringValue"] != DBNull.Value)
                        )
                    {
                        DataRow[] drParts = dsParts.Tables["Parts"].Select("ID=" + dr["PartID"].ToString());
                        if (drParts.Length > 0)
                        {
                            lvi = new ListViewItem(dtParts.Select("ID=" + dr["PartID"].ToString())[0]["Name"].ToString());
                            lvi.SubItems.Add(dr["MeasureName"].ToString());

                            switch (dr["MeasureClass"].ToString())
                            {
                                case "1":
                                    {
                                        lvi.SubItems.Add(dr["MeasureValueName"].ToString());
                                        break;
                                    }
                                case "2":
                                    {
                                        lvi.SubItems.Add(dr["StringValue"].ToString());
                                        break;
                                    }
                                case "3":
                                    {
                                        try
                                        {
                                            lvi.SubItems.Add(Convert.ToDouble(dr["MeasureValue"]).ToString(".##"));
                                        }
                                        catch { }
                                        break;
                                    }
                                case "4":
                                    {
                                        lvi.SubItems.Add(dr["StringValue"].ToString());
                                        break;
                                    }
                            }
                            lvItemData.Items.Add(lvi);
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void LoadPicture()
        {
            try
            {
                this.pictureBox1.Image = null;
                DataSet dsPic = Service.GetItemCPPictureByCode(otOrders.Selected.drNode["OrderCode"].ToString(),
                    otOrders.Selected.drNode["BatchCode"].ToString());

                //System.Diagnostics.Trace.WriteLine("dsf");

                //string pathTopicture = "";
                if (!Convert.IsDBNull(dsPic.Tables[0].Rows[0]["Path2Picture"]))
                {
                    string pathToPicture = Client.GetOfficeDirPath("iconDir") + dsPic.Tables[0].Rows[0]["Path2Picture"].ToString();
                    if (System.IO.File.Exists(pathToPicture))
                    {
                        Image im = System.Drawing.Image.FromFile(pathToPicture);
                        if (im != null)
                        {
                            this.pictureBox1.Image = im;
                            Service.DrawAdjustShapeImage(this.pictureBox1, im);
                        }
                    }
                }
            }
            catch
            {
                this.pictureBox1.Image = null;
            }
        }

        private void ptPartTree_Changed(object sender, System.EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.StatusBar.Text = "Measure values";
            this.tbComment.Enabled = true;
            string sPartID = ptPartTree.SelectedRow["ID"].ToString();
            sActivePartID = sPartID;
            sActivePartName = ptPartTree.SelectedNode.Text;
            label11.Text = "Part: " + "\n" + sActivePartName;
            string sPartTypeID = ptPartTree.SelectedRow["PartTypeID"].ToString();
            string sBatchID = otOrders.Selected.drNode["BatchID"].ToString();
            string sItemCode = otOrders.Selected.drNode["Code"].ToString();
            DataRow[] drEmptySet = dsParts.Tables["Measures"].Select("PartTypeID = '" + sPartTypeID + "' and PartID='" + sPartID + "'", "MeasureTitle");

            //copy data
            foreach (DataRow row in drEmptySet)
            {
                DataRow[] drMeasures = dsParts.Tables["PartValue"].Select("PartID='" + sPartID + "' and MeasureID = '" + row["MeasureID"].ToString() + "'");

                if (drMeasures.Length > 0)
                {
                    DataRow drMeasure = drMeasures[0];
                    foreach (DataColumn column in dsParts.Tables["PartValue"].Columns)
                    {
                        row[column.ColumnName] = drMeasure[column.ColumnName];
                    }
                }
                else
                {
                    //Setting MeasureValue, MeasureValueID, StringValue to DBNull
                    //Otherwise when passing DataRow[] to CreateCharacteristic() it copies all measures to all parts with same Parts structure
                    //By Vetal, 3ter on 10.02.2006
                    row["MeasureValue"] = System.DBNull.Value;
                    row["MeasureValueID"] = System.DBNull.Value;
                    row["StringValue"] = System.DBNull.Value;
                    row["BatchID"] = sBatchID;
                    row["ItemCode"] = sItemCode;
                    row["PartID"] = sPartID;
                }
            }

            CreateCharacteristic(drEmptySet);
            this.Cursor = Cursors.Default;
            this.StatusBar.Text = "Ready";
        }

        private void tbCharStr_Leave(object sender, System.EventArgs e)
        {
            TextBox tbValue = (TextBox)sender;
            DataRow row = dsParts.Tables["Measures"].Select(tbValue.Tag.ToString())[0];

            //if (tbValue.Text == "") return;

            row["StringValue"] = tbValue.Text;
            DataRow[] drExistSet = dsParts.Tables["SetParts"].Select("MeasureCode = '" + row["MeasureCode"] + "' and PartID = '" + row["PartID"] + "'");
            //Need to duplicate MeasureValues in DataSet we read from. Filtering by PartID too because can have many parts with similar Measures.
            //By Vetal, 3ter on 10.02.2006
            DataRow[] adrInPartValues = dsParts.Tables["PartValue"].Select(tbValue.Tag.ToString());
            if (adrInPartValues.Length > 0)
            {
                adrInPartValues[0]["StringValue"] = tbValue.Text;
            }
            else
            {
                DataRow drNew1 = dsParts.Tables["PartValue"].NewRow();
                drNew1["StringValue"] = tbValue.Text;
                drNew1["MeasureCode"] = row["MeasureCode"];
                drNew1["MeasureID"] = row["MeasureID"];
                drNew1["MeasureClass"] = row["MeasureClass"];
                drNew1["MeasureName"] = row["MeasureName"];
                drNew1["MeasureTitle"] = row["MeasureTitle"];

                drNew1["BatchID"] = row["BatchID"];
                drNew1["ItemCode"] = row["ItemCode"];
                drNew1["PartID"] = row["PartID"];
                dsParts.Tables["PartValue"].Rows.Add(drNew1);
            }

            if (drExistSet.Length > 0)
            {
                drExistSet[0]["StringValue"] = tbValue.Text;
            }
            else
            {
                DataRow drNew = dsParts.Tables["SetParts"].NewRow();
                drNew["StringValue"] = tbValue.Text;
                drNew["MeasureCode"] = row["MeasureCode"];

                drNew["BatchID"] = row["BatchID"];
                drNew["ItemCode"] = row["ItemCode"];
                drNew["PartID"] = row["PartID"];
                dsParts.Tables["SetParts"].Rows.Add(drNew);
            }
        }

        private void tbChar_Leave(object sender, System.EventArgs e)
        {
            String sDecSep = System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
            TextBox tbValue = (TextBox)sender;
            DataRow row = dsParts.Tables["Measures"].Select(tbValue.Tag.ToString())[0];

            try
            {
                if (tbValue.Text == "") return;
                Convert.ToDecimal(tbValue.Text);
            }
            catch
            {
                MessageBox.Show("Value must be numeric!");
                ((TextBox)sender).Focus();
                return;
            }

            String[] aPrts = tbValue.Text.Split(new char[] { Convert.ToChar(sDecSep) });
            if (aPrts.Length > 0)
            {
                if (aPrts[0].Length > 10)
                {
                    MessageBox.Show("Measure value can't have more than 10 digits before decimal separator.", "Incorrect number format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ((TextBox)sender).Focus();
                    return;
                }
            }

            //Rounding MeasureValue, precision = 2
            //By 3ter on 2006.02.13
            Decimal dVal = Math.Round(Convert.ToDecimal(tbValue.Text), 4);
            row["MeasureValue"] = dVal;
            tbValue.Text = dVal.ToString();

            DataRow[] drExistSet = dsParts.Tables["SetParts"].Select("MeasureCode = '" + row["MeasureCode"] + "' and PartID = '" + row["PartID"] + "'");
            //Need to duplicate MeasureValues in DataSet we read from. Filtering by PartID too because can have many parts with similar Measures.
            //By Vetal, 3ter on 10.02.2006
            DataRow[] adrInPartValues = dsParts.Tables["PartValue"].Select(tbValue.Tag.ToString());
            if (adrInPartValues.Length > 0)
            {
                adrInPartValues[0]["MeasureValue"] = tbValue.Text;
            }
            else
            {
                DataRow drNew1 = dsParts.Tables["PartValue"].NewRow();
                drNew1["MeasureValue"] = tbValue.Text;
                drNew1["MeasureCode"] = row["MeasureCode"];
                drNew1["MeasureID"] = row["MeasureID"];
                drNew1["MeasureClass"] = row["MeasureClass"];
                drNew1["MeasureName"] = row["MeasureName"];
                drNew1["MeasureTitle"] = row["MeasureTitle"];

                drNew1["BatchID"] = row["BatchID"];
                drNew1["ItemCode"] = row["ItemCode"];
                drNew1["PartID"] = row["PartID"];
                dsParts.Tables["PartValue"].Rows.Add(drNew1);
            }
            if (drExistSet.Length > 0)
            {
                drExistSet[0]["MeasureValue"] = Convert.ToDecimal(tbValue.Text);
            }
            else
            {
                DataRow drNew = dsParts.Tables["SetParts"].NewRow();
                drNew["MeasureValue"] = Convert.ToDecimal(tbValue.Text);
                drNew["MeasureCode"] = Convert.ToDecimal(row["MeasureCode"]);

                drNew["BatchID"] = row["BatchID"];
                drNew["ItemCode"] = row["ItemCode"];
                drNew["PartID"] = row["PartID"];
                dsParts.Tables["SetParts"].Rows.Add(drNew);
            }
        }

        private void cbChar_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ComboBox cbValue = (ComboBox)sender;
            string sValue = cbValue.SelectedValue.ToString();

            DataRow row = dsParts.Tables["Measures"].Select(cbValue.Tag.ToString())[0];
            row["MeasureValueID"] = sValue;

            DataRow[] drExistSet = dsParts.Tables["SetParts"].Select("MeasureCode = '" + row["MeasureCode"] + "' and PartID = '" + row["PartID"] + "'");
            //Need to duplicate MeasureValues in DataSet we read from. Filtering by PartID too because can have many parts with similar Measures.
            //By Vetal, 3ter on 10.02.2006
            DataRow[] adrInPartValues = dsParts.Tables["PartValue"].Select(cbValue.Tag.ToString());
            if (adrInPartValues.Length > 0)
            {
                adrInPartValues[0]["MeasureValueID"] = Convert.ToDecimal(sValue);
            }
            else
            {
                DataRow drNew1 = dsParts.Tables["PartValue"].NewRow();
                drNew1["MeasureValueID"] = Convert.ToDecimal(sValue);
                drNew1["MeasureCode"] = row["MeasureCode"];
                drNew1["MeasureID"] = row["MeasureID"];
                drNew1["MeasureClass"] = row["MeasureClass"];
                drNew1["MeasureName"] = row["MeasureName"];
                drNew1["MeasureTitle"] = row["MeasureTitle"];

                drNew1["BatchID"] = row["BatchID"];
                drNew1["ItemCode"] = row["ItemCode"];
                drNew1["PartID"] = row["PartID"];
                dsParts.Tables["PartValue"].Rows.Add(drNew1);
            }
            if (drExistSet.Length > 0)
            {
                drExistSet[0]["MeasureValueID"] = Convert.ToDecimal(sValue);
            }
            else
            {
                DataRow drNew = dsParts.Tables["SetParts"].NewRow();
                drNew["MeasureValueID"] = Convert.ToDecimal(sValue);
                drNew["MeasureCode"] = Convert.ToDecimal(row["MeasureCode"]);

                drNew["BatchID"] = row["BatchID"];
                drNew["ItemCode"] = row["ItemCode"];
                drNew["PartID"] = row["PartID"];
                dsParts.Tables["SetParts"].Rows.Add(drNew);
            }
        }

        private void btnReset_Click(object sender, System.EventArgs e)
        {
            Clear();
        }


        private void btnUpdate_Click(object sender, System.EventArgs e)
        {
            btnUpdate.Focus();
            //			if(bOnlyBatchUpdated)
            //			{
            //				if(UpdateBatchMemoNum())
            //				{
            //					MessageBox.Show(this, "MemmoNumber were updated successfully.", 
            //						"Update successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //				}
            //				bOnlyBatchUpdated = false;
            //			}
            //			else
            //			{
            //				if(wcWeight.Enabled == false && wcCustWeight.Enabled == false)
            //				{
            //					if(UpdateBatchMemoNum())
            //					{
            //						MessageBox.Show(this, "MemmoNumber were updated successfully.", 
            //							"Update successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //					}
            //				}
            //				else
            {
                //					if(!bOnlyBatchUpdated)
                //UpdateBatchMemoNum();
                {
                    if (UpdateItem() != 1)
                    {
                        LoadAllForSelectedItem();
                        MessageBox.Show(this, "Changes were updated successfully.",
                            "Update successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                //					else
                //					{
                //						if(UpdateBatchMemoNum())
                //						{
                //							MessageBox.Show(this, "MemmoNumber were updated successfully.", 
                //								"Update successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //						}
                //					}
            }
            //			}
            //  Don't clear form after update
            //  by vetal_242
            //  03.01.2006			
            //Clear();
            this.chk_SkipAddDocs.Checked = false;
        }

        private int UpdateItem()
        {
            this.Cursor = Cursors.WaitCursor;
            this.StatusBar.Text = "Updating changes...";
            DataRow drItem = otOrders.Selected.drNode;
            string partName = "";
            /**
             * by vetal_242 
             * 03.21.2006
             * */
            if (ptPartTree.SelectedNode != null) //06.01.2006
            {									//check selectedNode
                partName = ptPartTree.SelectedNode.Text;
            }
            #region CheckWeight
            if (partName.ToLower().IndexOf("diamond") != -1)
            {
                string batchID = otOrders.Selected.drNode["BatchID"].ToString();
                string batchCode = otOrders.Selected.drNode["BatchCode"].ToString();
                string orderCode = otOrders.Selected.drNode["OrderCode"].ToString();
                string itemCode = otOrders.Selected.drNode["Code"].ToString();
                string partID = ptPartTree.SelectedRow["ID"].ToString();
                string item = Service.FillToFiveChars(orderCode) + "." + Service.FillToFiveChars(orderCode) + "." + Service.FillToThreeChars(batchCode) + "." + Service.FillToTwoChars(itemCode);
                DataRow[] dRS = dsParts.Tables[0].Select("MeasureCode=6 and BatchID='" + batchID + "' and ItemCode='" + itemCode + "' and PartID='" + partID + "'");
                // if we have sarin weight but measured weight is null we don'need to compare anything
                // by 3ter on 2006.03.24. bug
                DataRow[] drMeasured = dsParts.Tables[0].Select("MeasureCode=4 and BatchID='" + batchID + "' and ItemCode='" + itemCode + "' and PartID='" + partID + "'");

                if (dRS.Length != 0 && drMeasured.Length != 0)
                {
                    string sarinWeight = dRS[0]["MeasureValue"].ToString();
                    string measureWeight = drMeasured[0]["MeasureValue"].ToString();
                    //if sarinWeight is empty - mountedDiamond
                    if (sarinWeight != "" && measureWeight != "")
                    {
                        string shape;
                        string shapeID;
                        DataRow[] drShapeID = dsParts.Tables[0].Select("MeasureCode=8 and BatchID='" + batchID + "' and ItemCode='" + itemCode + "' and PartID='" + partID + "'");
                        if (drShapeID.Length != 0)
                        {
                            shapeID = drShapeID[0]["MeasureValueID"].ToString();
                        }
                        else
                        {
                            shapeID = "";
                        }
                        DataRow[] drShape = dsParts.Tables[0].Select("MeasureCode=8 and BatchID='" + batchID + "' and ItemCode='" + itemCode + "' and PartID='" + partID + "'");
                        if (drShape.Length != 0)
                        {
                            shape = drShape[0]["MeasureValueName"].ToString();
                        }
                        else
                        {
                            shape = "";
                        }

                        if (shape.ToLower().IndexOf("round") != -1)
                        {
                            if (System.Math.Abs(System.Convert.ToDouble(sarinWeight) - System.Convert.ToDouble(measureWeight)) > 0.01)
                            {
                                if (MessageBox.Show("Measured Weight - Sarin Weight for Item " + item + " looks incorrect. You can re-enter Measured Weight or proceed with current values.\nDo you want to save current values?", "Weights campare failed", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No)
                                {
                                    MessageBox.Show("Please, enter correct values", "Re-enter values", MessageBoxButtons.OK);
                                    this.StatusBar.Text = "Ready";
                                    this.Cursor = Cursors.Default;
                                    return 1;
                                }
                                else
                                {
                                }
                            }
                            //							else
                            //							{
                            //								DataRow []drFF = dsParts.Tables[0].Select("MeasureCode=51 and BatchID='" + batchID + "' and ItemCode='" + itemCode + "' and PartID='" + partID + "'");
                            //								if(drFF.Length != 0)
                            //								{
                            //									string FF = drFF[0]["MeasureValueName"].ToString();
                            //									if(FF == "")
                            //									{
                            //										Service.SetItemStateByCode(System.Convert.ToInt32(orderCode), System.Convert.ToInt32(batchCode), System.Convert.ToInt32(itemCode), 2);
                            //									}
                            //								}
                            //							}
                        }
                        else
                        {
                            if (System.Math.Abs(System.Convert.ToDouble(sarinWeight) - System.Convert.ToDouble(measureWeight)) > 0.02)
                            {
                                if (MessageBox.Show("Measured Weight - Sarin Weight for Item " + item + " looks incorrect. You can re-enter Measured Weight or proceed with current values.\nDo you want to save current values?", "Weights campare failed", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No)
                                {
                                    MessageBox.Show("Please, enter correct weights", "Re-enter values", MessageBoxButtons.OK);
                                    this.StatusBar.Text = "Ready";
                                    this.Cursor = Cursors.Default;
                                    return 1;
                                }
                                else
                                {
                                }
                            }
                            //							else
                            //							{
                            //								DataRow []drFF = dsParts.Tables[0].Select("MeasureCode=51 and BatchID='" + batchID + "' and ItemCode='" + itemCode + "' and PartID='" + partID + "'");
                            //								if(drFF.Length != 0)
                            //								{
                            //									string FF = drFF[0]["MeasureValueName"].ToString();
                            //									if(FF == "")
                            //									{
                            //										Service.SetItemStateByCode(System.Convert.ToInt32(orderCode), System.Convert.ToInt32(batchCode), System.Convert.ToInt32(itemCode), 2);
                            //									}
                            //								}
                            //							}
                        }

                        DataRow[] cWR = dsParts.Tables[0].Select("MeasureCode=7 and BatchID='" + batchID + "' and ItemCode='" + itemCode + "' and PartID='" + partID + "'");
                        if (cWR.Length != 0)
                        {
                            string customerWeight = cWR[0]["MeasureValue"].ToString();
                            if (customerWeight != "")
                            {
                                if (System.Math.Abs(System.Convert.ToDouble(customerWeight) - System.Convert.ToDouble(measureWeight)) > 0.02)
                                {
                                    if (MessageBox.Show("Measured Weight - Customer Weight for Item " + item + " looks incorrect. You can re-enter Measured Weight or proceed with current values.\nDo you want to save current values?", "Weights campare failed", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No)
                                    {
                                        MessageBox.Show("Please, enter correct weights", "Re-enter values", MessageBoxButtons.OK);
                                        this.StatusBar.Text = "Ready";
                                        this.Cursor = Cursors.Default;
                                        return 1;
                                    }
                                    else
                                    {
                                    }
                                }
                                //								else
                                //								{
                                //									DataRow []drFF = dsParts.Tables[0].Select("MeasureCode=51 and BatchID='" + batchID + "' and ItemCode='" + itemCode + "' and PartID='" + partID + "'");
                                //									if(drFF.Length != 0)
                                //									{
                                //										string FF = drFF[0]["MeasureValueName"].ToString();
                                //										if(FF == "")
                                //										{
                                //											Service.SetItemStateByCode(System.Convert.ToInt32(orderCode), System.Convert.ToInt32(batchCode), System.Convert.ToInt32(itemCode), 2);
                                //										}
                                //									}
                                //								}
                            }
                        }
                    }
                }
                else
                {
                    DataRow[] drCustomerWeight = dsParts.Tables[0].Select("MeasureCode=7 and BatchID='" + batchID + "' and ItemCode='" + itemCode + "' and PartID='" + partID + "'");
                    DataRow[] drCalculatedWeight = dsParts.Tables[0].Select("MeasureCode=5 and BatchID='" + batchID + "' and ItemCode='" + itemCode + "' and PartID='" + partID + "'");
                    if (drCalculatedWeight.Length != 0 && drCustomerWeight.Length != 0)
                    {
                        string customerWeight = drCustomerWeight[0]["MeasureValue"].ToString();
                        string calculatedWeight = drCalculatedWeight[0]["MeasureValue"].ToString();
                        if (customerWeight != "" && calculatedWeight != "")
                        {
                            if (System.Math.Abs(System.Convert.ToDouble(customerWeight) - System.Convert.ToDouble(calculatedWeight)) > 0.02)
                            {
                                if (MessageBox.Show("Calculated Weight - Customer Weight for Item " + item + " looks incorrect. You can re-enter Measured Weight or proceed with current values.\nDo you want to save current values?", "Weights campare failed", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No)
                                {
                                    MessageBox.Show("Please, enter correct weights", "Re-enter values", MessageBoxButtons.OK);
                                    this.StatusBar.Text = "Ready";
                                    this.Cursor = Cursors.Default;
                                    return 1;
                                }
                                else
                                {
                                }
                            }
                            //							else
                            //							{
                            //								DataRow []drFF = dsParts.Tables[0].Select("MeasureCode=51 and BatchID='" + batchID + "' and ItemCode='" + itemCode + "' and PartID='" + partID + "'");
                            //								if(drFF.Length != 0)
                            //								{
                            //									string FF = drFF[0]["MeasureValueName"].ToString();
                            //									if(FF == "")
                            //									{
                            //										Service.SetItemStateByCode(System.Convert.ToInt32(orderCode), System.Convert.ToInt32(batchCode), System.Convert.ToInt32(itemCode), 2);
                            //									}
                            //								}
                            //							}
                        }
                    }
                }
            }
            //end by vetal_242
            #endregion
            try
            {
                string batchID = otOrders.Selected.drNode["BatchID"].ToString();
                string batchCode = otOrders.Selected.drNode["BatchCode"].ToString();
                string orderCode = otOrders.Selected.drNode["OrderCode"].ToString();
                string itemCode = otOrders.Selected.drNode["Code"].ToString();
                string partID = ptPartTree.SelectedRow["ID"].ToString();

                if (incPrevNumber.ItemNumber != "")
                {
                    string[] sPrevNum = incPrevNumber.ItemNumber.ToString().Split('.');
                    drItem["PrevGroupCode"] = Convert.ToDecimal(sPrevNum[1]);
                    drItem["PrevBatchCode"] = Convert.ToDecimal(sPrevNum[2]);
                    drItem["PrevItemCode"] = Convert.ToDecimal(sPrevNum[3]);

                    //					DataTable dtTest = Service.GetItemByCode(sPrevNum[1],sPrevNum[2],sPrevNum[3]);
                    //					if (dtTest.Rows.Count == 0) throw new Exception ("Entered PrevItemNumber doesn't exist in DataBase! Data wasn't added.");
                }
                else
                {
                    drItem["PrevGroupCode"] = System.DBNull.Value;
                    drItem["PrevBatchCode"] = System.DBNull.Value;
                    drItem["PrevItemCode"] = System.DBNull.Value;
                }

                DataTable dtTest = Service.GetItemByCode(orderCode, batchCode, itemCode);//Procedure dbo.spGetItemByCode
                if (dtTest.Rows.Count == 0) throw new Exception("Entered Old Number doesn't exist! Data wasn't added.");

                DataRow[] cWR = dsParts.Tables[0].Select("MeasureCode=7 and BatchID='" + batchID + "' and ItemCode='" + itemCode + "' and PartID='" + partID + "'");
                if (cWR.Length != 0)
                {
					if (wcCustWeight.Weight != "" || wcCustWeight.Weight != "0.00")
                    {
                        drItem["CustomerItemWeight"] = Convert.ToDecimal(wcCustWeight.Weight);
                    }
                    else
                    {
                        drItem["CustomerItemWeight"] = System.DBNull.Value;
                    }
                    drItem["CustomerItemWeightUnitID"] = wcCustWeight.MeasureUnitID;
                    if (wcWeight.Weight != "")
                    {
                        drItem["Weight"] = Convert.ToDecimal(wcWeight.Weight);
                    }
                    else
                    {
                        drItem["Weight"] = System.DBNull.Value;
                    }
                    drItem["WeightUnitID"] = wcWeight.MeasureUnitID;
                    drItem["LotNumber"] = tbLotNumber.Text;
                    drItem["ItemComment"] = tbComment.Text;
                }
            }

            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                drItem.RejectChanges();
            }

            DataTable dtUpdatedItem = Service.GetItemUpdateStruct(); //Procedure dbo.spGetItemTypeOf2
            DataRow drUpdate = dtUpdatedItem.NewRow();
            foreach (DataColumn column in dtUpdatedItem.Columns)
            {
                try
                {
                    drUpdate[column] = drItem[column.ColumnName];
                }
                catch
                {
                    //MessageBox.Show(column.ColumnName);
                }
            }
            //drUpdate["ItemCode"] = drItem["Code"];
            //sd 22.12.2006
            //drUpdate["ItemCode"] = drItem["NewItemCode"];
            //drUpdate["BatchID"] = drItem["NewBatchID"];
            drUpdate[0] = drItem["NewBatchID"].ToString() + "_" + drItem["NewItemCode"].ToString();//drItem[0];
            dtUpdatedItem.Rows.Add(drUpdate);

            Service.UpdateItem(dtUpdatedItem); //Proceedure dbo.spUpdateItem
            drItem.AcceptChanges();
            if (dsParts.Tables["SetParts"].Rows.Count > 0)
            {

                //  passing copy of existing DataTable. No need to remove from DataSet
                //  by vetal_242
                //  03.01.2006				
                DataTable table = dsParts.Tables["SetParts"].Copy();
                //Clearing SetParts-DataTable to not fire messagebox on otOrders_BeforeSelect
                //Below if block added/changed by Sasha 11/18/08
                if (this.chk_SkipAddDocs.Checked)
                {
                    string batchCode = otOrders.Selected.drNode["BatchCode"].ToString();
                    string orderCode = otOrders.Selected.drNode["OrderCode"].ToString();
                    string itemCode = otOrders.Selected.drNode["Code"].ToString();
                    DataSet dsDocs = Service.GetItemDocByCode(orderCode, batchCode, itemCode);//Procedure dbo.spGetItemDocByCode
                    foreach (DataRow drDoc in dsDocs.Tables[0].Rows)
                    {
                        string name = drDoc["OperationChar"].ToString() + orderCode + "." + batchCode + "." + itemCode;
                        Service.AddDocumentToQueue(drDoc["ItemOperationOfficeID_ItemOperationID"].ToString(), name);
                    }
                }

                dsParts.Tables["SetParts"].Rows.Clear();
                table.Rows[0]["BatchID"] = drItem["NewBatchID"];
                table.Rows[0]["ItemCode"] = drItem["NewItemCode"];

                Service.SetPartValue(table); //Procedure spSetPartValue
            }
            this.StatusBar.Text = "Ready";
            this.Cursor = Cursors.Default;
            return 0;
        }

        private void otOrders_BeforeSelect(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
        {
            //this.Focus();
            otOrders.Focus();
            if (otOrders.Selected == null) return;
            if (otOrders.Selected.tblName != "tblItem") return;

            bool ItemChanged = true;
            DataRow drItem = otOrders.Selected.drNode;
            string sPrevNum = "";
            try
            {
                sPrevNum = GraderLib.GetCorrectFullCodeString(
                    Convert.ToInt32(drItem["PrevGroupCode"]),
                    Convert.ToInt32(drItem["PrevGroupCode"]),
                    Convert.ToInt32(drItem["PrevBatchCode"]),
                    Convert.ToInt32(drItem["PrevItemCode"]));
                incPrevNumber.ItemNumber = sPrevNum;
            }
            catch
            {
                sPrevNum = "";
            }

            //sd 2006.12.08
            //if(incNumber.ItemNumber == sPrevNum)
            //	sPrevNum = "";

            //try-block by 3ter on 2006.03.30 to catch zero-weight exception
            try
            {
                if (
                    sPrevNum == incPrevNumber.ItemNumber.ToString()
                    //&& drItem["CustomerItemWeight"].ToString() == wcCustWeight.Weight.ToString()
                    //&& drItem["CustomerItemWeightUnitID"].ToString() == wcCustWeight.MeasureUnitID.ToString()
                    //&& drItem["Weight"].ToString() == wcWeight.Weight.ToString()
                    //&& drItem["WeightUnitID"].ToString() == wcWeight.MeasureUnitID.ToString()
                    && drItem["LotNumber"].ToString() == tbLotNumber.Text
                    && drItem["ItemComment"].ToString() == tbComment.Text

                    )
                { ItemChanged = false; }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }


            if ((ItemChanged) || (dsParts.Tables["SetParts"].Rows.Count > 0))
            {
                DialogResult dResult = MessageBox.Show("Do you want to save the Item changes ?", "Alert", MessageBoxButtons.YesNoCancel);
                if (dResult == DialogResult.Yes)
                {
                    if (UpdateItem() == 1)
                        e.Cancel = true;
                }
                if (dResult == DialogResult.Cancel)
                    e.Cancel = true;
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

        private void incNumber_KeyDown(object sender, System.EventArgs e)
        {
            lvMigratedItemData.Items.Clear();
            ListViewItem lv2;

            try
            {
                isItemEntered = true;
                string sEnteredItem = incNumber.ItemNumber;
                string[] sNewItemNum;
                string[] sItemNum = incNumber.Get().Split('.');
                //Line below added by Sasha 11/10/08
                DataTable dtNewItemCode = Service.GetNewItemCustomerCodeByCode(sItemNum[0], sItemNum[1], sItemNum[2], sItemNum[3]);//Procedure dbo.spGetNewItemCustomerCodeByCode
                //DataTable dtOrder = Service.GetOrderByOrderCode(sItemNum[0]    );//Procedure dbo.spGetGroupByCode

                //by 3ter on 2006.05.15. if item not found don't through exception (there is no row at position 0)
                if (dtNewItemCode.Rows.Count > 0)
                {
                    string temp1 = dtNewItemCode.Rows[0]["NewItemNumber"].ToString().Trim();
                    incNewNumber.ItemNumber = dtNewItemCode.Rows[0]["NewItemNumber"].ToString().Trim();
                    incNumber.ItemNumber = incNewNumber.ItemNumber;
                    //incNumber.ItemNumber = dtNewItemCode.Rows[0]["NewItemNumber"].ToString().Trim();
                    string Temp = dtNewItemCode.Rows[0]["CustomerCode"].ToString();
                    ctcCustomer.SelectedCode = dtNewItemCode.Rows[0]["CustomerCode"].ToString(); //Get Customer code
                    otOrders.SelectNode(incNewNumber.Get()); //Load all order-batch-item list
                    sNewItemNum = incNewNumber.Get().Split('.');
                    DataTable dtMigratedItemCode = Service.GetMigratedItemCode(sNewItemNum[0], "0", "0");
                    if (dtMigratedItemCode.Rows.Count > 0)
                    {
                        //                        string sPrevItemN = "";
                        //                        string sCurrentOrderItemN = "";
                        //                        string sNewItemN = "";						

                        foreach (DataRow dr in dtMigratedItemCode.Rows)
                        {
                            //                            string[] sPrevItemNumber = dr["PrevItemNumber"].ToString().Trim().Split('.');
                            //                            string[] sCurrentOrderItemNumber = dr["CurrentOrderItemNumber"].ToString().Trim().Split('.');
                            //                            string[] sNewItemNumber = dr["NewItemNumber"].ToString().Trim().Split('.');
                            //
                            //                            if (sPrevItemNumber.Length == 3)
                            //                                sPrevItemN = GraderLib.GetCorrectFullCodeString( Convert.ToInt32(sPrevItemNumber[0]), Convert.ToInt32(sPrevItemNumber[0]),
                            //                                    Convert.ToInt32(sPrevItemNumber[1]),
                            //                                    Convert.ToInt32(sPrevItemNumber[2]));
                            //                            if (sCurrentOrderItemNumber.Length == 3)
                            //                                sCurrentOrderItemN = GraderLib.GetCorrectFullCodeString(Convert.ToInt32(sCurrentOrderItemNumber[0]), Convert.ToInt32(sPrevItemNumber[0]),
                            //                                    Convert.ToInt32(sCurrentOrderItemNumber[1]),
                            //                                    Convert.ToInt32(sCurrentOrderItemNumber[2]));
                            //                            if (sNewItemNumber.Length == 3)
                            //                                sNewItemN = GraderLib.GetCorrectFullCodeString( Convert.ToInt32(sNewItemNumber[0]), Convert.ToInt32(sNewItemNumber[0]),
                            //                                    Convert.ToInt32(sNewItemNumber[1]),
                            //                                    Convert.ToInt32(sNewItemNumber[2]));

                            //                            lv2 = new ListViewItem(sPrevItemN);
                            //                            lv2.SubItems.Add(sCurrentOrderItemN);
                            //                            lv2.SubItems.Add(sNewItemN);
                            //                            lvMigratedItemData.Items.Add(lv2);

                            lv2 = new ListViewItem(dr["PrevItemNumber"].ToString());
                            lv2.SubItems.Add(dr["CurrentOrderItemNumber"].ToString());
                            lv2.SubItems.Add(dr["NewItemNumber"].ToString());
                            //lv2.SubItems.Add(dr["NewItemNumber"].ToString());
                            lvMigratedItemData.Items.Add(lv2);
                        }
                        this.label10.Text = "Order # " + sNewItemNum[0] + ": Migrated Items";
                    }

                    incNumber.ItemNumber = sEnteredItem;
                }
                // Below part commented by Sasha 11/18/08
                //				if (dtOrder.Rows.Count > 0)
                //				{
                //					ctcCustomer.SelectedCode = dtOrder.Rows[0]["CustomerCode"].ToString();
                //					otOrders.SelectNode(incNumber.Get());
                //				}
                else
                {
                    throw new Exception("Item" + incNumber.ItemNumber.ToString() + " cannot be found");
                    StatusBar.Text = "Item/order cannot be found";
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool UpdateBatchMemoNum()
        {
            DataRow drBatch = otOrders.SelectedBatch.drNode;
            string[] sCode = otOrders.SelectedBatch.NodeCode.Split('.');
            try
            {
                DataSet ds1 = new DataSet();
                ds1.Tables.Add("BatchByCodeTypeEx");//Procedure dbo.spGetBatchByCodeTypeEx
                DataSet ds2 = Service.ProxyGenericGet(ds1);
                DataRow row = ds2.Tables[0].NewRow();

                row["BatchCode"] = sCode[2];
                row["BGroupState"] = System.DBNull.Value;
                row["BDate"] = System.DBNull.Value;
                row["EDate"] = System.DBNull.Value;
                row["BState"] = System.DBNull.Value;
                row["CustomerCode"] = ctcCustomer.SelectedCode.ToString();
                row["EGroupState"] = System.DBNull.Value;
                row["EState"] = System.DBNull.Value;
                row["GroupCode"] = drBatch["GroupCode"].ToString();

                ds2.Tables[0].Rows.Add(row);
                ds2.Tables[0].TableName = "BatchByCode";
                DataSet ds3 = Service.ProxyGenericGet(ds2);//Procedure dbo.spGetBatchByCode

                string sBatchID = ds3.Tables[0].Rows[0]["BatchID"].ToString();
                DataSet dsMemoNumber = new DataSet();
                dsMemoNumber.Tables.Add("MemoNumber");
                DataColumn dcMemoNumber = new DataColumn("MemoNumber", Type.GetType("System.String"));
                DataColumn dcMemoNumberID = new DataColumn("MemoNumberID", Type.GetType("System.String"));
                DataColumn dcBatchID = new DataColumn("BatchID", Type.GetType("System.String"));
                dsMemoNumber.Tables[0].Columns.Add(dcBatchID);
                dsMemoNumber.Tables[0].Columns.Add(dcMemoNumber);
                dsMemoNumber.Tables[0].Columns.Add(dcMemoNumberID);
                DataRow drMemNum = dsMemoNumber.Tables[0].NewRow();
                drMemNum["BatchID"] = sBatchID;

                DataRowView drvMemo = ((DataRowView)cbMemoNumber.SelectedItem);
                string sMemoName = null;
                string sMemoID = null;
                if (drvMemo["Name"].ToString() != "[none]")
                {
                    sMemoName = drvMemo["Name"].ToString();
                    sMemoID = drvMemo["MemoNumberID"].ToString();
                }
                drMemNum["MemoNumber"] = sMemoName;
                drMemNum["MemoNumberID"] = sMemoID;
                dsMemoNumber.Tables[0].Rows.Add(drMemNum);
                dsMemoNumber.AcceptChanges();
                DataSet dsTest = Service.ProxyGenericSet(dsMemoNumber, "Set");
                return true;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                return false;
            }
        }

        private void tbMemoNumber_TextChanged(object sender, System.EventArgs e)
        {
            if (tbMemoNumber.Text.Length != 0)
            {
                this.btnUpdate.Enabled = true;
                bOnlyBatchUpdated = true;
            }
            else
            {
                this.btnUpdate.Enabled = false;
                bOnlyBatchUpdated = false;
            }
        }

        /**
         * Update item measure from .ou1
         * by vetal_242
         * 17.01.2006
        */
        private void btnSARIN_Click(object sender, System.EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.StatusBar.Text = "Importing sarin files";
                //sd 01.12.2006
                DataTable dtItems = new DataTable();
                dtItems.Columns.Add("OrderCode");
                dtItems.Columns.Add("BatchCode");
                dtItems.Columns.Add("ItemCode");
                dtItems.Columns.Add("PrevOrderCode");
                dtItems.Columns.Add("PrevBatchCode");
                dtItems.Columns.Add("PrevItemCode");
                dtItems.Columns.Add("Prefix");
                dtItems.Columns.Add("GNumber");
                dtItems.Columns.Add("PartID");
                dtItems.Columns.Add("Suffix");
				dtItems.Columns.Add("SarinID");
                bool res = false;
                DataRow drItem = otOrders.Selected.drNode;
				string sPartID_Selected = ptPartTree.SelectedRow["ID"].ToString();
				string sPartName = ptPartTree.SelectedNode.Text;
                if (drItem != null)
                {
					string sNewItemCode = Service.GetNewItemCodeByBathcID(drItem["BatchID"].ToString(), drItem["Code"].ToString()); //Procedure dbo.spGetNewItemCodeByBathcID
                    string[] sCodes = sNewItemCode.Split('.');

                    string batchID = "";
                    string OrderCode = "";
                    string BatchCode = "";
                    string ItemCode = "";
                    string PrevOrderCode = "";
                    string PrevBatchCode = "";
                    string PrevItemCode = "";
                    /*	if(sCodes.Length==4)
                    {
                        batchID = drItem["NewBatchID"].ToString(); 
                        OrderCode = sCodes[1];
                        BatchCode = sCodes[2];
                        ItemCode = sCodes[3];
                    }
                    else*/
                    {
                        batchID = drItem["BatchID"].ToString();
                        OrderCode = Service.FillToFiveChars(drItem["OrderCode"].ToString());
                        BatchCode = Service.FillToThreeChars(drItem["BatchCode"].ToString());
                        ItemCode = Service.FillToTwoChars(drItem["Code"].ToString());
                        PrevOrderCode = Service.FillToFiveChars(drItem["PrevOrderCode"].ToString());
                        PrevBatchCode = Service.FillToThreeChars(drItem["PrevBatchCode"].ToString());
                        PrevItemCode = Service.FillToTwoChars(drItem["PrevItemCode"].ToString());
                    }

                    /*DataRow[] dr = dsParts.Tables[0].Select("MeasureCode='12'  and BatchID='" + batchID + "' and ItemCode='" + ItemCode + "'");
                    bool f = true;
				 
                    //Check is exist value (Min - code = 12)
                    f = false;
                    if(dr.Length>0)
                    {
                        if(dr[0]["MeasureValue"] is DBNull)
                            f = true;
                    }
                    else
                    {
                        f = true;
                    }*/

                    //if(f)
                    {
						DataRow[] drPrefixs = dsParts.Tables[0].Select("MeasureCode='112'  and BatchID='" + batchID + "' and ItemCode='" + ItemCode + "' and PartID = '" + sPartID_Selected + "'");
						DataRow[] drSuffix = dsParts.Tables[0].Select("MeasureCode='122'  and BatchID='" + batchID + "' and ItemCode='" + ItemCode + "' and PartID = '" + sPartID_Selected + "'");
						DataRow[] drNGnumbers = dsParts.Tables[0].Select("MeasureCode='110'  and BatchID='" + batchID + "' and ItemCode='" + ItemCode + "' and PartID = '" + sPartID_Selected + "'");
						DataRow[] drSarinID = dsParts.Tables[0].Select("MeasureCode='169'  and BatchID='" + batchID + "' and ItemCode='" + ItemCode + "' and PartID = '" + sPartID_Selected + "'");
						if (drSarinID.Length > 0)
						{
							string sSarinID = "";
							sSarinID = drSarinID[0][dsParts.Tables[0].Columns.IndexOf("StringValue")].ToString().Trim();
							string sPartID = drSarinID[0][dsParts.Tables[0].Columns.IndexOf("PartID")].ToString().Trim();
							if (sSarinID.Trim().Length > 5)
							{
								//string sPartID = drPrefix["PartID"].ToString();
								string sFileName2 = Client.GetOfficeDirPath("graderDir") + sSarinID.Trim() + ".ou1";
								if (sFileName2.ToUpper() != ".OU1" && File.Exists(sFileName2))
								{
									dtItems.Rows.Add(new object[] {OrderCode, BatchCode, ItemCode, PrevOrderCode, PrevBatchCode, PrevItemCode, "", "", sPartID, "", sSarinID.Trim()});
								}
							
							}
						}
						else
						if (drPrefixs.Length > 0)
                        {
                            foreach (DataRow drPrefix in drPrefixs)
                            {
                                string Prefix = "";
                                string GNumber = "";
                                string myGNumber = "";
                                string Suffix = "";
                                Prefix = drPrefix[dsParts.Tables[0].Columns.IndexOf("StringValue")].ToString().Trim();
								
                                if (drSuffix.Length > 0)
                                {
                                    Suffix = drSuffix[dsParts.Tables[0].Columns.IndexOf("StringValue")].ToString().Trim();
                                }
                                string sPartID = drPrefix["PartID"].ToString();
                                DataRow[] drGNumber = dsParts.Tables[0].Select("MeasureCode='110' and BatchID='" + batchID + "' and ItemCode='" + ItemCode + "' and PartID = '" + sPartID + "'");
                                if (drGNumber.Length > 0)
                                {
                                    myGNumber = drGNumber[0]["MeasureValue"].ToString().Trim();
                                    if (myGNumber.IndexOf(".") > -1)
                                        GNumber = myGNumber.Substring(0, myGNumber.IndexOf("."));//   drGNumber[0]["MeasureValue"].ToString();
                                    if (Convert.ToInt64(GNumber, 10) == 0) GNumber = "";
                                }
                                //							string sFileName2 = Service.GetServiceCfgParameter("graderDir") + Prefix.Trim() + GNumber.Trim() + Suffix.Trim() + ".ou1";
                                //							if (File.Exists(sFileName2))

                                string sFileName2 = Client.GetOfficeDirPath("graderDir") + Prefix.Trim() + GNumber.Trim() + Suffix.Trim() + ".ou1";
                                //#if DEBUG
                                //                            sFileName2 = "C:/graderfiles/" + Prefix + GNumber + Suffix + ".ou1";
                                //#endif
								if (sFileName2.ToUpper() != ".OU1" && File.Exists(sFileName2))
                                {
                                    dtItems.Rows.Add(new object[] { OrderCode, BatchCode, ItemCode, PrevOrderCode, PrevBatchCode, PrevItemCode, Prefix.Trim(), GNumber, sPartID, Suffix.Trim(), "" });
                                }
								//else
								//{
								//    //MessageBox.Show("Sarin file for # " + sFileName2.Substring(0, sFileName2.Length - 4) + " is missing");
								//    break;
								//}
                            }
                        }
                        if (dtItems.Rows.Count == 0) // || drPrefixs.Length == 0)
                        //else
                        {
                            string Prefix = "";
                            string GNumber = "";
                            string sPartID = "";
                            if (sActivePartName.IndexOf("Diamond") > -1 || sActivePartName.IndexOf("Color stone") > -1)
                                sPartID = sActivePartID;
                            string Suffix = "";
                            //null;//drPrefix["PartID"].ToString();
                            //DataRow []drGNumber = dsParts.Tables[0].Select("MeasureCode='110' and BatchID='" + batchID + "' and ItemCode='" + ItemCode + "'");
                            //if(drGNumber.Length>0)
                            //sPartID = drGNumber[0]["PartID"].ToString();
                            dtItems.Rows.Add(new object[] { OrderCode, BatchCode, ItemCode, PrevOrderCode, PrevBatchCode, PrevItemCode, Prefix, GNumber, sPartID, Suffix, "" });
                        }
                        res = GraderWork.ChangeDataFromOU11(dtItems);
                    }
                }
                this.Cursor = Cursors.Default;
                this.StatusBar.Text = "Ready";
                //MessageBox.Show("SARIN update is done", "Update from ou1",MessageBoxButtons.OK,MessageBoxIcon.Information);
                if (res)
                {
                    MessageBox.Show("SARIN update is done", "Update from ou1", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAllForSelectedItem();
                }
                else
                    MessageBox.Show("SARIN update is not done", "Update from ou1", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                #region sd 01.11.2006
                /*this.Cursor = Cursors.WaitCursor;
				this.StatusBar.Text = "Importing sarin files";
				string[] sItemNum = incNumber.Get().Split('.');
				string OrderCode = sItemNum[0];
				string BatchCode = sItemNum[2];
				GraderWork.ChangeDataFromOU1(OrderCode, BatchCode);
			
				this.Cursor = Cursors.Default;
				this.StatusBar.Text = "Ready";
				MessageBox.Show("SARIN update is done", "Update from ou1",MessageBoxButtons.OK,MessageBoxIcon.Information);
				*/
                #endregion
            }
            catch (Exception exc)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbMemoNumber_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (cbMemoNumber.Enabled)
            {
                if (!isFirst)
                {
                    this.btnUpdateBatch.Enabled = true;
                    bOnlyBatchUpdated = true;
                }
                isFirst = false;
            }
        }

        private void incNumber_Load(object sender, System.EventArgs e)
        {

        }

        private void ctcCustomer_Load(object sender, System.EventArgs e)
        {

        }

        private void btnUpdateBatch_Click(object sender, System.EventArgs e)
        {
            btnUpdateBatch.Focus();
            if (bOnlyBatchUpdated)
            {
                if (UpdateBatchMemoNum())
                {
                    MessageBox.Show(this, "Batch Memo was updated successfully.",
                        "Update successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                bOnlyBatchUpdated = false;
                btnUpdateBatch.Enabled = false;
            }

        }

        private void lvMigratedItemData_DoubleClick(object sender, System.EventArgs e)
        {
            int iLength = 0;
            int i = ((ListView)sender).SelectedIndices[0];
            string sOrder = ((ListView)sender).Items[i].SubItems[2].Text; //.Substring(0, 5);
            if (sOrder.Length == 12) iLength = 5;
            if (sOrder.Length == 13) iLength = 6;
            sOrder = ((ListView)sender).Items[i].SubItems[2].Text.Substring(0, iLength);
            sOrder = sOrder + "." + ((ListView)sender).Items[i].SubItems[2].Text;
            incNumber.ItemNumber = sOrder;
            incNumber_KeyDown(sender, System.EventArgs.Empty);
        }

        private void btnMeasureByCP_Click(object sender, System.EventArgs e)
        {
            bFullAccess = false;
            btnMeasureByFullSet.Enabled = true;
            btnMeasureByFullSet.Visible = true;
            btnMeasureByCP.Enabled = false;
            btnMeasureByCP.Visible = false;
            label14.Refresh();
            label14.Text = "Measurements By CP";
            string sItemNumber = incNumber.Get();
            if (sItemNumber.Length > 9)
            {
                if (CreateDataSet_Parts_Measures())
                {
                    LoadItemData();
                    LoadPicture();
                    ptPartTree_Changed(this, System.EventArgs.Empty);
                }
            }
        }

        private void btnMeasureByFullSet_Click(object sender, System.EventArgs e)
        {
            bFullAccess = true;
            btnMeasureByFullSet.Enabled = false;
            btnMeasureByFullSet.Visible = false;
            btnMeasureByCP.Enabled = true;
            btnMeasureByCP.Visible = true;
            label14.Refresh();
            label14.Text = "Full Set of Measurements";
            string sItemNumber = incNumber.Get();
            if (sItemNumber.Length > 9)
            {
                if (CreateDataSet_Parts_Measures())
                {
                    LoadItemData();
                    LoadPicture();
                    ptPartTree_Changed(this, System.EventArgs.Empty);
                }
            }
        }

		private void ptPartTree_Load(object sender, EventArgs e)
		{

		}
        //		private void ColorChangedRecursive(TreeNode treeNode)
        //		{
        //			treeNode.BackColor = System.Drawing.Color.Transparent;
        //			
        //			foreach (TreeNode tn in treeNode.Nodes)
        //			{
        //				ColorChangedRecursive(tn);
        //			}
        //		}

    }
}
