using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace gemoDream
{
    /// <summary>
    /// Summary description for Prices.
    /// </summary>
    public class Prices : System.Windows.Forms.Form
    {
        #region Data
        private DataSet dsInitPrice;
        private DataTable dtAdditionalService;
        private DataView dvMeasures = null;
        private DataSet dsParts;
        private string sItemTypeID;
        private string sCPID;
        private DataSet dsPrice;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Pass;
        private System.Windows.Forms.TabPage Fail;
        private System.Windows.Forms.GroupBox gbpDinamic;
        private System.Windows.Forms.Label lItemProps;
        private System.Windows.Forms.Label lItemStructure;
        private System.Windows.Forms.CheckBox cbpDiscount;
        private System.Windows.Forms.TextBox tbpDeltaFix;
        private System.Windows.Forms.CheckBox cbpDeltaFix;
        private System.Windows.Forms.TextBox tbpFixed;
        private System.Windows.Forms.TextBox tbpDiscount;
        private System.Windows.Forms.GroupBox gbpAdditionalServicies;
        private System.Windows.Forms.CheckBox cbpAdditionalServicies;
        private System.Windows.Forms.Label lpService;
        private System.Windows.Forms.Label lpServicePrice;
        private System.Windows.Forms.Button bpServiceAdd;
        private System.Windows.Forms.Button bpServiceDelete;
        private System.Windows.Forms.ListBox lbMeasures;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbfFixed;
        private System.Windows.Forms.TextBox tbfFixed;
        private System.Windows.Forms.CheckBox cbfDiscount;
        private System.Windows.Forms.TextBox tbfDiscount;
        private Cntrls.PartTree ptParts;
        private System.Windows.Forms.Button bAttach;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.StatusBar sbStatus;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.RadioButton rbFixed;
        private System.Windows.Forms.RadioButton rbDynamic;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errProv1;
		private Boolean isCloseNormal = false;
		private static Boolean isLoaded = false;
        #endregion
		private IContainer components;


        private void Init(string sInitItemTypeID)
        {
            this.sItemTypeID = sInitItemTypeID;

            InitMeasures();
            InitPartTree(sItemTypeID);
            CommonInit();
        }

        public Prices(string sInitItemTypeID, string initCPID)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
			isLoaded = false;
			this.sCPID = initCPID;
            Init(sInitItemTypeID);

            if (initCPID != "")
            {
                InitPrices(GetPricesByCPID(initCPID));
            }
        }

        public Prices(string sInitItemTypeID, ref DataSet dsInitPrices)
        {
			InitializeComponent();
			isLoaded = false;
			Init(sInitItemTypeID);
            InitPrices(dsInitPrices);
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Prices));
			this.lbMeasures = new System.Windows.Forms.ListBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.Pass = new System.Windows.Forms.TabPage();
			this.label2 = new System.Windows.Forms.Label();
			this.rbFixed = new System.Windows.Forms.RadioButton();
			this.gbpAdditionalServicies = new System.Windows.Forms.GroupBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.bpServiceDelete = new System.Windows.Forms.Button();
			this.bpServiceAdd = new System.Windows.Forms.Button();
			this.lpService = new System.Windows.Forms.Label();
			this.lpServicePrice = new System.Windows.Forms.Label();
			this.gbpDinamic = new System.Windows.Forms.GroupBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.cbpDeltaFix = new System.Windows.Forms.CheckBox();
			this.tbpDeltaFix = new System.Windows.Forms.TextBox();
			this.cbpDiscount = new System.Windows.Forms.CheckBox();
			this.cbpAdditionalServicies = new System.Windows.Forms.CheckBox();
			this.rbDynamic = new System.Windows.Forms.RadioButton();
			this.tbpDiscount = new System.Windows.Forms.TextBox();
			this.tbpFixed = new System.Windows.Forms.TextBox();
			this.Fail = new System.Windows.Forms.TabPage();
			this.cbfFixed = new System.Windows.Forms.CheckBox();
			this.cbfDiscount = new System.Windows.Forms.CheckBox();
			this.tbfFixed = new System.Windows.Forms.TextBox();
			this.tbfDiscount = new System.Windows.Forms.TextBox();
			this.bAttach = new System.Windows.Forms.Button();
			this.lItemProps = new System.Windows.Forms.Label();
			this.lItemStructure = new System.Windows.Forms.Label();
			this.sbStatus = new System.Windows.Forms.StatusBar();
			this.bCancel = new System.Windows.Forms.Button();
			this.errProv1 = new System.Windows.Forms.ErrorProvider(this.components);
			this.ptParts = new Cntrls.PartTree();
			this.tabControl1.SuspendLayout();
			this.Pass.SuspendLayout();
			this.gbpAdditionalServicies.SuspendLayout();
			this.gbpDinamic.SuspendLayout();
			this.Fail.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.errProv1)).BeginInit();
			this.SuspendLayout();
			// 
			// lbMeasures
			// 
			this.lbMeasures.ItemHeight = 12;
			this.lbMeasures.Location = new System.Drawing.Point(160, 32);
			this.lbMeasures.Name = "lbMeasures";
			this.lbMeasures.Size = new System.Drawing.Size(152, 616);
			this.lbMeasures.TabIndex = 1;
			this.lbMeasures.DoubleClick += new System.EventHandler(this.lbMeasures_DoubleClick);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.Pass);
			this.tabControl1.Controls.Add(this.Fail);
			this.tabControl1.Location = new System.Drawing.Point(320, 8);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(608, 640);
			this.tabControl1.TabIndex = 2;
			// 
			// Pass
			// 
			this.Pass.Controls.Add(this.label2);
			this.Pass.Controls.Add(this.rbFixed);
			this.Pass.Controls.Add(this.gbpAdditionalServicies);
			this.Pass.Controls.Add(this.gbpDinamic);
			this.Pass.Controls.Add(this.cbpDiscount);
			this.Pass.Controls.Add(this.cbpAdditionalServicies);
			this.Pass.Controls.Add(this.rbDynamic);
			this.Pass.Controls.Add(this.tbpDiscount);
			this.Pass.Controls.Add(this.tbpFixed);
			this.Pass.Location = new System.Drawing.Point(4, 21);
			this.Pass.Name = "Pass";
			this.Pass.Size = new System.Drawing.Size(600, 615);
			this.Pass.TabIndex = 0;
			this.Pass.Text = "Pass";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(560, 12);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(16, 16);
			this.label2.TabIndex = 8;
			this.label2.Text = "%";
			// 
			// rbFixed
			// 
			this.rbFixed.Location = new System.Drawing.Point(8, 10);
			this.rbFixed.Name = "rbFixed";
			this.rbFixed.Size = new System.Drawing.Size(56, 16);
			this.rbFixed.TabIndex = 6;
			this.rbFixed.Text = "Fixed";
			this.rbFixed.CheckedChanged += new System.EventHandler(this.rbFixed_CheckedChanged);
			// 
			// gbpAdditionalServicies
			// 
			this.gbpAdditionalServicies.Controls.Add(this.panel2);
			this.gbpAdditionalServicies.Controls.Add(this.bpServiceDelete);
			this.gbpAdditionalServicies.Controls.Add(this.bpServiceAdd);
			this.gbpAdditionalServicies.Controls.Add(this.lpService);
			this.gbpAdditionalServicies.Controls.Add(this.lpServicePrice);
			this.gbpAdditionalServicies.Location = new System.Drawing.Point(8, 465);
			this.gbpAdditionalServicies.Name = "gbpAdditionalServicies";
			this.gbpAdditionalServicies.Size = new System.Drawing.Size(568, 147);
			this.gbpAdditionalServicies.TabIndex = 4;
			this.gbpAdditionalServicies.TabStop = false;
			// 
			// panel2
			// 
			this.panel2.AutoScroll = true;
			this.panel2.Location = new System.Drawing.Point(8, 32);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(472, 109);
			this.panel2.TabIndex = 6;
			// 
			// bpServiceDelete
			// 
			this.bpServiceDelete.BackColor = System.Drawing.Color.LightPink;
			this.bpServiceDelete.Location = new System.Drawing.Point(488, 52);
			this.bpServiceDelete.Name = "bpServiceDelete";
			this.bpServiceDelete.Size = new System.Drawing.Size(72, 20);
			this.bpServiceDelete.TabIndex = 5;
			this.bpServiceDelete.Text = "Delete";
			this.bpServiceDelete.UseVisualStyleBackColor = false;
			this.bpServiceDelete.Click += new System.EventHandler(this.bpServiceDelete_Click);
			// 
			// bpServiceAdd
			// 
			this.bpServiceAdd.BackColor = System.Drawing.Color.LightSteelBlue;
			this.bpServiceAdd.Location = new System.Drawing.Point(488, 30);
			this.bpServiceAdd.Name = "bpServiceAdd";
			this.bpServiceAdd.Size = new System.Drawing.Size(72, 20);
			this.bpServiceAdd.TabIndex = 4;
			this.bpServiceAdd.Text = "Add";
			this.bpServiceAdd.UseVisualStyleBackColor = false;
			this.bpServiceAdd.Click += new System.EventHandler(this.bpServiceAdd_Click);
			// 
			// lpService
			// 
			this.lpService.Location = new System.Drawing.Point(104, 16);
			this.lpService.Name = "lpService";
			this.lpService.Size = new System.Drawing.Size(80, 8);
			this.lpService.TabIndex = 0;
			this.lpService.Text = "Service Name";
			this.lpService.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lpServicePrice
			// 
			this.lpServicePrice.Location = new System.Drawing.Point(320, 16);
			this.lpServicePrice.Name = "lpServicePrice";
			this.lpServicePrice.Size = new System.Drawing.Size(96, 8);
			this.lpServicePrice.TabIndex = 1;
			this.lpServicePrice.Text = "Price";
			this.lpServicePrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// gbpDinamic
			// 
			this.gbpDinamic.Controls.Add(this.panel1);
			this.gbpDinamic.Controls.Add(this.cbpDeltaFix);
			this.gbpDinamic.Controls.Add(this.tbpDeltaFix);
			this.gbpDinamic.Location = new System.Drawing.Point(8, 48);
			this.gbpDinamic.Name = "gbpDinamic";
			this.gbpDinamic.Size = new System.Drawing.Size(587, 397);
			this.gbpDinamic.TabIndex = 3;
			this.gbpDinamic.TabStop = false;
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.Location = new System.Drawing.Point(8, 44);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(572, 345);
			this.panel1.TabIndex = 5;
			// 
			// cbpDeltaFix
			// 
			this.cbpDeltaFix.Location = new System.Drawing.Point(10, 20);
			this.cbpDeltaFix.Name = "cbpDeltaFix";
			this.cbpDeltaFix.Size = new System.Drawing.Size(72, 16);
			this.cbpDeltaFix.TabIndex = 0;
			this.cbpDeltaFix.Text = "Delta Fix";
			this.cbpDeltaFix.CheckedChanged += new System.EventHandler(this.cbpDeltaFix_CheckedChanged);
			// 
			// tbpDeltaFix
			// 
			this.tbpDeltaFix.Location = new System.Drawing.Point(85, 18);
			this.tbpDeltaFix.Name = "tbpDeltaFix";
			this.tbpDeltaFix.Size = new System.Drawing.Size(136, 20);
			this.tbpDeltaFix.TabIndex = 1;
			this.tbpDeltaFix.Validating += new System.ComponentModel.CancelEventHandler(this.tbpFixed_Validating);
			// 
			// cbpDiscount
			// 
			this.cbpDiscount.Location = new System.Drawing.Point(437, 14);
			this.cbpDiscount.Name = "cbpDiscount";
			this.cbpDiscount.Size = new System.Drawing.Size(82, 16);
			this.cbpDiscount.TabIndex = 0;
			this.cbpDiscount.Text = "Discount";
			this.cbpDiscount.CheckedChanged += new System.EventHandler(this.cbpDiscount_CheckedChanged);
			// 
			// cbpAdditionalServicies
			// 
			this.cbpAdditionalServicies.Location = new System.Drawing.Point(10, 450);
			this.cbpAdditionalServicies.Name = "cbpAdditionalServicies";
			this.cbpAdditionalServicies.Size = new System.Drawing.Size(125, 16);
			this.cbpAdditionalServicies.TabIndex = 5;
			this.cbpAdditionalServicies.Text = "Additional Services";
			this.cbpAdditionalServicies.CheckedChanged += new System.EventHandler(this.cbpAdditionalServicies_CheckedChanged);
			// 
			// rbDynamic
			// 
			this.rbDynamic.Location = new System.Drawing.Point(8, 32);
			this.rbDynamic.Name = "rbDynamic";
			this.rbDynamic.Size = new System.Drawing.Size(104, 16);
			this.rbDynamic.TabIndex = 7;
			this.rbDynamic.Text = "Dynamic";
			this.rbDynamic.CheckedChanged += new System.EventHandler(this.cbpDinamic_CheckedChanged);
			// 
			// tbpDiscount
			// 
			this.tbpDiscount.Location = new System.Drawing.Point(525, 10);
			this.tbpDiscount.MaxLength = 3;
			this.tbpDiscount.Name = "tbpDiscount";
			this.tbpDiscount.Size = new System.Drawing.Size(30, 20);
			this.tbpDiscount.TabIndex = 1;
			this.tbpDiscount.Validating += new System.ComponentModel.CancelEventHandler(this.tbpFixed_Validating);
			// 
			// tbpFixed
			// 
			this.tbpFixed.Location = new System.Drawing.Point(64, 10);
			this.tbpFixed.Name = "tbpFixed";
			this.tbpFixed.Size = new System.Drawing.Size(166, 20);
			this.tbpFixed.TabIndex = 1;
			this.tbpFixed.Validating += new System.ComponentModel.CancelEventHandler(this.tbpFixed_Validating);
			// 
			// Fail
			// 
			this.Fail.Controls.Add(this.cbfFixed);
			this.Fail.Controls.Add(this.cbfDiscount);
			this.Fail.Controls.Add(this.tbfFixed);
			this.Fail.Controls.Add(this.tbfDiscount);
			this.Fail.Location = new System.Drawing.Point(4, 22);
			this.Fail.Name = "Fail";
			this.Fail.Size = new System.Drawing.Size(600, 590);
			this.Fail.TabIndex = 1;
			this.Fail.Text = "Fail";
			// 
			// cbfFixed
			// 
			this.cbfFixed.Location = new System.Drawing.Point(8, 8);
			this.cbfFixed.Name = "cbfFixed";
			this.cbfFixed.Size = new System.Drawing.Size(54, 16);
			this.cbfFixed.TabIndex = 5;
			this.cbfFixed.Text = "Fixed";
			this.cbfFixed.CheckedChanged += new System.EventHandler(this.cbfFixed_CheckedChanged);
			// 
			// cbfDiscount
			// 
			this.cbfDiscount.Location = new System.Drawing.Point(160, 8);
			this.cbfDiscount.Name = "cbfDiscount";
			this.cbfDiscount.Size = new System.Drawing.Size(72, 16);
			this.cbfDiscount.TabIndex = 3;
			this.cbfDiscount.Text = "Discount";
			this.cbfDiscount.CheckedChanged += new System.EventHandler(this.cbfDiscount_CheckedChanged);
			// 
			// tbfFixed
			// 
			this.tbfFixed.Location = new System.Drawing.Point(8, 24);
			this.tbfFixed.Name = "tbfFixed";
			this.tbfFixed.Size = new System.Drawing.Size(136, 20);
			this.tbfFixed.TabIndex = 1;
			this.tbfFixed.Validating += new System.ComponentModel.CancelEventHandler(this.tbpFixed_Validating);
			// 
			// tbfDiscount
			// 
			this.tbfDiscount.Location = new System.Drawing.Point(160, 24);
			this.tbfDiscount.Name = "tbfDiscount";
			this.tbfDiscount.Size = new System.Drawing.Size(120, 20);
			this.tbfDiscount.TabIndex = 1;
			this.tbfDiscount.Validating += new System.ComponentModel.CancelEventHandler(this.tbpFixed_Validating);
			// 
			// bAttach
			// 
			this.bAttach.BackColor = System.Drawing.Color.LightSteelBlue;
			this.bAttach.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.bAttach.Location = new System.Drawing.Point(588, 657);
			this.bAttach.Name = "bAttach";
			this.bAttach.Size = new System.Drawing.Size(160, 20);
			this.bAttach.TabIndex = 6;
			this.bAttach.Text = "&Attach Price";
			this.bAttach.UseVisualStyleBackColor = false;
			this.bAttach.Click += new System.EventHandler(this.bAttach_Click);
			// 
			// lItemProps
			// 
			this.lItemProps.Location = new System.Drawing.Point(160, 8);
			this.lItemProps.Name = "lItemProps";
			this.lItemProps.Size = new System.Drawing.Size(152, 20);
			this.lItemProps.TabIndex = 3;
			this.lItemProps.Text = "Item Part Props";
			// 
			// lItemStructure
			// 
			this.lItemStructure.Location = new System.Drawing.Point(0, 8);
			this.lItemStructure.Name = "lItemStructure";
			this.lItemStructure.Size = new System.Drawing.Size(160, 20);
			this.lItemStructure.TabIndex = 4;
			this.lItemStructure.Text = "Item Structure Tree";
			// 
			// sbStatus
			// 
			this.sbStatus.Location = new System.Drawing.Point(0, 673);
			this.sbStatus.Name = "sbStatus";
			this.sbStatus.Size = new System.Drawing.Size(944, 16);
			this.sbStatus.TabIndex = 7;
			this.sbStatus.Text = "Ready";
			// 
			// bCancel
			// 
			this.bCancel.BackColor = System.Drawing.Color.LightPink;
			this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.bCancel.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.bCancel.Location = new System.Drawing.Point(754, 657);
			this.bCancel.Name = "bCancel";
			this.bCancel.Size = new System.Drawing.Size(160, 20);
			this.bCancel.TabIndex = 8;
			this.bCancel.Text = "&Cancel";
			this.bCancel.UseVisualStyleBackColor = false;
			this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
			// 
			// errProv1
			// 
			this.errProv1.ContainerControl = this;
			// 
			// ptParts
			// 
			this.ptParts.Location = new System.Drawing.Point(0, 32);
			this.ptParts.Name = "ptParts";
			this.ptParts.Size = new System.Drawing.Size(160, 616);
			this.ptParts.TabIndex = 5;
			this.ptParts.Changed += new System.EventHandler(this.ptParts_Changed);
			// 
			// Prices
			// 
			this.AcceptButton = this.bAttach;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
			this.CancelButton = this.bCancel;
			this.ClientSize = new System.Drawing.Size(944, 689);
			this.Controls.Add(this.bCancel);
			this.Controls.Add(this.bAttach);
			this.Controls.Add(this.sbStatus);
			this.Controls.Add(this.ptParts);
			this.Controls.Add(this.lbMeasures);
			this.Controls.Add(this.lItemStructure);
			this.Controls.Add(this.lItemProps);
			this.Controls.Add(this.tabControl1);
			this.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Prices";
			this.Text = "Prices";
			this.tabControl1.ResumeLayout(false);
			this.Pass.ResumeLayout(false);
			this.Pass.PerformLayout();
			this.gbpAdditionalServicies.ResumeLayout(false);
			this.gbpDinamic.ResumeLayout(false);
			this.gbpDinamic.PerformLayout();
			this.Fail.ResumeLayout(false);
			this.Fail.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.errProv1)).EndInit();
			this.ResumeLayout(false);

        }
        #endregion

        private void CommonInit()
        {
            this.panel1.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.controlRemoved);
            ptParts.Enabled = false;
            lbMeasures.Enabled = false;

            tbfDiscount.Enabled = false;
            tbfFixed.Enabled = false;
            gbpAdditionalServicies.Enabled = false;
            tbpDeltaFix.Enabled = false;
            gbpDinamic.Enabled = false;
            tbpDiscount.Enabled = false;
            tbpFixed.Enabled = false;

            cbfDiscount.Checked = false;
            cbfFixed.Checked = false;
            //	cbpAdditionalServicies.Checked = false;
            cbpDeltaFix.Checked = false;
            rbDynamic.Checked = true;
			rbFixed.Checked = false;
            cbpDiscount.Checked = false;
            //	rbFixed.Checked = true;


            dtAdditionalService = Service.GetAdditionalService(); // procedure spGetAdditionalService
			#region initDataSet
			dsPrice = new DataSet();
            dsPrice.Tables.Add("PriceRange");
            dsPrice.Tables["PriceRange"].Columns.Add("HomogeneousClassID");
            dsPrice.Tables["PriceRange"].Columns.Add("From", Type.GetType("System.Double"));
            dsPrice.Tables["PriceRange"].Columns.Add("To", Type.GetType("System.Double"));
            dsPrice.Tables["PriceRange"].Columns.Add("Price", Type.GetType("System.Double"));

            dsPrice.Tables.Add("PricePartsMeasures");
            dsPrice.Tables["PricePartsMeasures"].Columns.Add("PartID");
            dsPrice.Tables["PricePartsMeasures"].Columns.Add("MeasureCode");
            dsPrice.Tables["PricePartsMeasures"].Columns.Add("HomogeneousClassID");
            dsPrice.Tables["PricePartsMeasures"].Columns.Add("PartNameMeasureName");

            dsPrice.Tables.Add("AdditionalServicePrice");
            dsPrice.Tables["AdditionalServicePrice"].Columns.Add("AdditionalServiceID");
            dsPrice.Tables["AdditionalServicePrice"].Columns.Add("Price", Type.GetType("System.Double"));

            dsPrice.Tables.Add("CPHistory");
            dsPrice.Tables["CPHistory"].Columns.Add("isFixed");
            dsPrice.Tables["CPHistory"].Columns.Add("FixedPrice", Type.GetType("System.Double"));
            dsPrice.Tables["CPHistory"].Columns.Add("DeltaFix", Type.GetType("System.Double"));
            dsPrice.Tables["CPHistory"].Columns.Add("Discount", Type.GetType("System.Double"));
            dsPrice.Tables["CPHistory"].Columns.Add("FailFixed", Type.GetType("System.Double"));
            dsPrice.Tables["CPHistory"].Columns.Add("FailDiscount", Type.GetType("System.Double"));
            #endregion
        }

        private void InitPartTree(string sItemTypeID)
        {
            dsParts = new DataSet();

			dsParts.Tables.Add(Service.GetParts(sItemTypeID));	//procedure spGetPartsByItemType
            dsParts.Tables.Add(Service.GetPartsStruct());	//tblName : SetParts

            //gemoDream.Service.debug_DiaspalyDataSet(dsParts);

            this.ptParts.Initialize(dsParts.Tables["Parts"]);
            this.ptParts.ExpandTree();
            //this.ptParts.SelectedNode = this.ptParts.tvPartTree.TopNode;
        }

        private void InitMeasures()
        {
            DataSet dsMeasures = new DataSet();
            dsMeasures.Tables.Add(Service.GetMeasuresByItemTypeAndBillable(sItemTypeID)); //Procedure spGetMeasuresByItemTypeAndBillable

            dvMeasures = new DataView(dsMeasures.Tables[0]);
            dvMeasures.RowFilter = "1=0";
            dvMeasures.Sort = "MeasureTitle";

            this.lbMeasures.DataSource = dvMeasures;
            this.lbMeasures.ValueMember = "MeasureCode";
            this.lbMeasures.DisplayMember = "MeasureTitle";
        }

        private void cbpDinamic_CheckedChanged(object sender, System.EventArgs e)
        {
            gbpDinamic.Enabled = rbDynamic.Checked;
            tbpFixed.Enabled = !rbDynamic.Checked;
            ptParts.Enabled = rbDynamic.Checked;
            lbMeasures.Enabled = rbDynamic.Checked;
			panel1.Visible = rbDynamic.Checked;
			tbpFixed.Text = "";
			tbpFixed.Visible = !rbDynamic.Checked;
			if (isLoaded) ClearAddServiceControls();
			//panel1.Visible = false;
			//lbMeasures.Visible = false;

			if (!gbpDinamic.Enabled)
            {
                tbfFixed.Focus();
                tbfFixed.SelectAll();
            }
        }

        private void cbpDeltaFix_CheckedChanged(object sender, System.EventArgs e)
        {
            tbpDeltaFix.Enabled = cbpDeltaFix.Checked;
        }

        private void cbpDiscount_CheckedChanged(object sender, System.EventArgs e)
        {
            tbpDiscount.Enabled = cbpDiscount.Checked;
        }

        private void cbpAdditionalServicies_CheckedChanged(object sender, System.EventArgs e)
        {
            gbpAdditionalServicies.Enabled = cbpAdditionalServicies.Checked;
        }

        private void bpAdd_1_Click(object sender, System.EventArgs e)
        {
            Cntrls.PriceRange pr = new Cntrls.PriceRange((panel1.Controls.Count + 1));
            pr.Location = new System.Drawing.Point(0, (160 + ((panel1.Controls.Count - 1) * 160)));
            panel1.Controls.Add(pr);
        }

        private void cbfFixed_CheckedChanged(object sender, System.EventArgs e)
        {
            tbfFixed.Enabled = cbfFixed.Checked;
        }

        private void cbfDiscount_CheckedChanged(object sender, System.EventArgs e)
        {
            tbfDiscount.Enabled = cbfDiscount.Checked;
        }

        private void ptParts_Changed(object sender, System.EventArgs e)
        {
            try
            {
                string sPartID = this.ptParts.SelectedNode.Tag.ToString();

                DataRow[] rows = this.dsParts.Tables["Parts"].Select("ID = '" + sPartID + "'");
                string sPartTypeID = rows[0]["PartTypeID"].ToString();

                string sFilter = "PartTypeID IN (" + sPartTypeID + ", -1)";
                dvMeasures.RowFilter = sFilter;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Can't load measures. Reason: " + ex.ToString(),
                    "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lbMeasures_DoubleClick(object sender, System.EventArgs e)
        {
            DataRowView row = (DataRowView)this.lbMeasures.SelectedItem;
            string sMeasure = (string)row["MeasureTitle"];
            string sMeasureCode = row["MeasureCode"].ToString();
            string sPart = ptParts.SelectedNode.Text;
            string sHomogeneousClassID = ptParts.SelectedRow["HomogeneousClassID"].ToString();
            string sPartID = ptParts.SelectedRow["ID"].ToString();
            string sPartMeasure = String.Format("[{0}.{1}]", sPart, sMeasure);
            AddPartMeasure(sPartMeasure, sMeasureCode, sHomogeneousClassID, sPartID);
        }

        private void bAttach_Click(object sender, System.EventArgs e)
        {
            dsPrice.Clear();
            try
            {
                if (cbfFixed.Checked == false && rbDynamic.Checked == false && rbFixed.Checked == false)
                {
                    throw new Exception("No prices were entered");
                }

                #region saveDinamicPrice
                if (rbDynamic.Checked == true)
                {
                    
					for (int i = 0; i < panel1.Controls.Count; i++)
                    {
                        Cntrls.PriceRange curPriceRange = (Cntrls.PriceRange)panel1.Controls[i];
                        DataRowCollection drcPartsMeasures = curPriceRange.getPartsMeasures();
                        if (drcPartsMeasures.Count == 0)
                        {
                            int index = i + 1;
                            throw new Exception("Select Part_measure in Dynamic Prices " + index.ToString());
                        }
                        foreach (DataRow drPartMeasure in drcPartsMeasures)
                        {
                            DataRow drNewPricePartsMeasures = dsPrice.Tables["PricePartsMeasures"].NewRow();
                            drNewPricePartsMeasures["PartID"] = drPartMeasure["PartID"];
                            drNewPricePartsMeasures["MeasureCode"] = drPartMeasure["MeasureCode"];
                            drNewPricePartsMeasures["HomogeneousClassID"] = curPriceRange.Homogeneity;
                            drNewPricePartsMeasures["PartNameMeasureName"] = drPartMeasure["PartNameMeasureName"];
                            dsPrice.Tables["PricePartsMeasures"].Rows.Add(drNewPricePartsMeasures);
                        }
                        DataRowCollection drcPriceRange = curPriceRange.GetPriceRange();
                        if (drcPriceRange.Count == 0)
                        {
                            int index = i + 1;
                            throw new Exception("Price ranges are empty in Dynamic Prices " + index.ToString());
                        }
                        foreach (DataRow drPriceRange in drcPriceRange)
                        {
                            if (drPriceRange["From"].ToString() == "" || drPriceRange["To"].ToString() == "" || drPriceRange["Price"].ToString() == "")
                            {
                                int index = i + 1;
                                throw new Exception("Not all fields are filled at row " + index.ToString() + " of Dynamic Prices");
                            }

                            DataRow drNewPriceRange = dsPrice.Tables["PriceRange"].NewRow();
                            drNewPriceRange["From"] = drPriceRange["From"];
                            drNewPriceRange["To"] = drPriceRange["To"];
                            drNewPriceRange["Price"] = Convert.ToDouble(drPriceRange["Price"]);
                            drNewPriceRange["HomogeneousClassID"] = curPriceRange.Homogeneity;
                            dsPrice.Tables["PriceRange"].Rows.Add(drNewPriceRange);
                        }
                    }
                }
                #endregion

                #region forCPHistory

				dsPrice.Tables["CPHistory"].Rows.Add(dsPrice.Tables["CPHistory"].NewRow());	

				if (rbFixed.Checked == true && tbpFixed.Text.Trim() != "")
				{
				
					try
					{
						dsPrice.Tables["CPHistory"].Rows[0]["isFixed"] = "1";
						dsPrice.Tables["CPHistory"].Rows[0]["FixedPrice"] = System.Double.Parse(tbpFixed.Text);
					}
					catch (Exception ex)
					{
						throw new Exception("Invalid pass fixed price: " + ex.Message);
					}
				}
				else
				{
					rbFixed.Checked = false;
					tbpFixed.Text = "";
					dsPrice.Tables["CPHistory"].Rows[0]["isFixed"] = DBNull.Value;
					dsPrice.Tables["CPHistory"].Rows[0]["FixedPrice"] = DBNull.Value;
				}

                if (cbpDeltaFix.Checked == true && cbpDeltaFix.Enabled == true)
                {
                    try
                    {
                        dsPrice.Tables["CPHistory"].Rows[0]["DeltaFix"] = System.Double.Parse(tbpDeltaFix.Text);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Invalid delta fix: " + ex.Message);
                    }
                }

                if (cbpDiscount.Checked == true)
                {
                    try
                    {
                        if (System.Convert.ToDouble(tbpDiscount.Text) < 0 || System.Convert.ToDouble(tbpDiscount.Text) > 100)
                        {
                            throw new Exception("Invalid pass discount");
                        }
                        dsPrice.Tables["CPHistory"].Rows[0]["Discount"] = tbpDiscount.Text;
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message == "Invalid pass discount")
                            throw new Exception(ex.Message);
                        else
                            throw new Exception("Invalid pass discount: " + ex.Message);
                    }
                }

                if (cbfFixed.Checked == true)
                {
                    try
                    {
                        dsPrice.Tables["CPHistory"].Rows[0]["FailFixed"] = Convert.ToDouble(tbfFixed.Text);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Invalid fail fixed price: " + ex.Message);
                    }
                }

                if (cbfDiscount.Checked == true)
                {
                    try
                    {
                        if (System.Convert.ToDouble(tbfDiscount.Text) < 0 || System.Convert.ToDouble(tbfDiscount.Text) > 100)
                        {
                            throw new Exception("Invalid fail discount");
                        }
                        dsPrice.Tables["CPHistory"].Rows[0]["FailDiscount"] = Convert.ToDouble(tbfDiscount.Text);//tbfDiscount.Text;
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message == "Invalid fail discount")
                            throw new Exception(ex.Message);
                        else
                            throw new Exception("Invalid fail discount: " + ex.Message);
                    }
                }
                #endregion

                #region Save Additional Price
                if (cbpAdditionalServicies.Checked == true)
                {
                    for (int i = 0; i < panel2.Controls.Count; i++)
                    {
                        Cntrls.AdditionalPrice curAdditionalPrice = (Cntrls.AdditionalPrice)panel2.Controls[i];
                        DataRow drNewAdditionalServicePrice = dsPrice.Tables["AdditionalServicePrice"].NewRow();
                        drNewAdditionalServicePrice["AdditionalServiceID"] = curAdditionalPrice.GetASID();
                        if (curAdditionalPrice.GetPrice() == "")
                        {
                            throw new Exception("Invalid additional price");
                        }
                        drNewAdditionalServicePrice["Price"] = curAdditionalPrice.GetPrice();
                        dsPrice.Tables["AdditionalServicePrice"].Rows.Add(drNewAdditionalServicePrice);
                    }
                    Hashtable temp = new Hashtable();
                    foreach (DataRow dr in dsPrice.Tables["AdditionalServicePrice"].Rows)
                    {
                        temp[dr["AdditionalServiceID"].ToString()] = null;
                    }
                    if (temp.Count != dsPrice.Tables["AdditionalServicePrice"].Rows.Count)
                    {
                        throw new Exception("Two or more identical additional services selected");
                    }
                }
                #endregion
#if DEBUG
				// For debugging only			
				string filename = @"C:\DELL\myXmlPrices.xml";
				if (File.Exists(filename)) File.Delete(filename);
				// Create the FileStream to write with.
				System.IO.FileStream myFileStream = new System.IO.FileStream(filename, System.IO.FileMode.Create);
				// Create an XmlTextWriter with the fileStream.
				System.Xml.XmlTextWriter myXmlWriter = new System.Xml.XmlTextWriter(myFileStream, System.Text.Encoding.Unicode);
				// Write to the file with the WriteXml method.
				dsPrice.WriteXml(myXmlWriter);
				myXmlWriter.Close();
				// End of debugging part
#endif
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            isCloseNormal = true;
        }

        private void bpServiceAdd_Click(object sender, System.EventArgs e)
        {
            Cntrls.AdditionalPrice ap = new Cntrls.AdditionalPrice(dtAdditionalService, panel2.Controls.Count + 1);
            ap.Location = new System.Drawing.Point(8, (((panel2.Controls.Count) * 24)));
            panel2.Controls.Add(ap);
        }

        public static DataSet Pricing(IWin32Window parent, string initCPID, string sInitItemTypeID, ref Boolean isCloseCorrect)
        {
            Prices pr = new Prices(sInitItemTypeID, initCPID);
			isLoaded = true;
			pr.ShowDialog(parent);
            isCloseCorrect = pr.isCloseNormal;
            return pr.getDsPrices();
        }

        public static DataSet Pricing(IWin32Window parent, ref DataSet dsInPrices, string sInitItemTypeID, ref Boolean isCloseCorrect)
        {
            Prices pr = new Prices(sInitItemTypeID, ref dsInPrices);
			isLoaded = true;
			pr.ShowDialog(parent);
            isCloseCorrect = pr.isCloseNormal;
            return pr.getDsPrices();
        }

        private DataSet getDsPrices()
        {
            return this.dsPrice;
        }

        private DataSet GetPricesByCPID(String sCPID)
        {
            dsInitPrice = new DataSet();

            DataTable dtPPM = Service.GetPricePartsMeasures(sCPID);//Procedure dbo.spGetPricePartsMeasuresByCPID
            dtPPM.TableName = "PricePartsMeasures";
            dsInitPrice.Tables.Add(dtPPM.Copy());

            DataTable dtPR = Service.GetPriceRange(sCPID);//Procedure dbo.spGetPriceRangeByCPID
            dtPR.TableName = "PriceRange";
            dtPR.Columns["ValueFrom"].ColumnName = "From";
            dtPR.Columns["ValueTo"].ColumnName = "To";
            dsInitPrice.Tables.Add(dtPR.Copy());

            DataTable dtASP = Service.GetAdditionalServicePrice(sCPID);
            dtASP.TableName = "AdditionalServicePrice";
            dsInitPrice.Tables.Add(dtASP.Copy());

            DataTable dtCPH = Service.GetCustomerProgramPriceByCPID(sCPID);//Procedure dbo.spGetCustomerProgramPriceByCPID
            dtCPH.TableName = "CPHistory";
            dsInitPrice.Tables.Add(dtCPH.Copy());


            return dsInitPrice;
        }

        private void InitPrices(DataSet dsInitPrice)
        {
            int errorNumber = 0;
            string errorMessage = "";
            try
            {
                this.dsInitPrice = dsInitPrice;
                foreach (DataRow drPricePartsMeasures in dsInitPrice.Tables["PricePartsMeasures"].Rows)
                {
                    AddPartMeasure(drPricePartsMeasures["PartNameMeasureName"].ToString(),
                        drPricePartsMeasures["MeasureCode"].ToString(),
                        drPricePartsMeasures["HomogeneousClassID"].ToString(),
                        drPricePartsMeasures["PartID"].ToString());
                }
                foreach (DataRow drAS in dsInitPrice.Tables["AdditionalServicePrice"].Rows)
                {
                    Cntrls.AdditionalPrice ap = new Cntrls.AdditionalPrice(dtAdditionalService, panel2.Controls.Count + 1);
                    ap.Location = new System.Drawing.Point(8, (((panel2.Controls.Count) * 24)));
                    ap.SelectAdditionalService(drAS["AdditionalServiceID"].ToString(), System.Convert.ToDouble(drAS["Price"]).ToString("0.##"));
                    panel2.Controls.Add(ap);
                }

                if (dsInitPrice.Tables["CPHistory"].Rows.Count > 0)
                {
                    if (dsInitPrice.Tables["CPHistory"].Rows[0]["isFixed"].ToString() == "1")
                    {
                        errorNumber = 1;
                        rbFixed.Checked = true;
                        tbpFixed.Text = System.Convert.ToDouble(dsInitPrice.Tables["CPHistory"].Rows[0]["FixedPrice"].ToString()).ToString("0.##");
                    }

                    if (dsInitPrice.Tables["CPHistory"].Rows[0]["Discount"].ToString() != "")
                    {
                        errorNumber = 2;
                        cbpDiscount.Checked = true;
                        tbpDiscount.Text = System.Convert.ToDouble(dsInitPrice.Tables["CPHistory"].Rows[0]["Discount"].ToString()).ToString("0.##");
                    }
                    if (dsInitPrice.Tables["CPHistory"].Rows[0]["DeltaFix"].ToString() != "")
                    {
                        errorNumber = 3;
                        cbpDeltaFix.Checked = true;
                        tbpDeltaFix.Text = System.Convert.ToDouble(dsInitPrice.Tables["CPHistory"].Rows[0]["DeltaFix"].ToString()).ToString("0.##");
                    }
                    if (dsInitPrice.Tables["CPHistory"].Rows[0]["FailFixed"].ToString() != "")
                    {
                        errorNumber = 4;
                        cbfFixed.Checked = true;
                        tbfFixed.Text = System.Convert.ToDouble(dsInitPrice.Tables["CPHistory"].Rows[0]["FailFixed"].ToString()).ToString("0.##");
                    }
                    if (dsInitPrice.Tables["CPHistory"].Rows[0]["FailDiscount"].ToString() != "")
                    {
                        errorNumber = 5;
                        cbfDiscount.Checked = true;
                        tbfDiscount.Text = System.Convert.ToDouble(dsInitPrice.Tables["CPHistory"].Rows[0]["FailDiscount"].ToString()).ToString("0.##");
                    }
                }

                if (dsInitPrice.Tables["PricePartsMeasures"].Rows.Count > 0)
                {
                    rbDynamic.Checked = true;
					rbFixed.Checked = false;
                }

                if (dsInitPrice.Tables["AdditionalServicePrice"].Rows.Count > 0)
                {
                    cbpAdditionalServicies.Checked = true;
                }
            }
            catch (Exception exc)
            {
                this.Cursor = Cursors.Default;
                switch (errorNumber)
                {
                    case 1:
                        errorMessage = "Missing Fixed prices";
                        break;
                    case 2:
                        errorMessage = "Missing Discount";
                        break;
                    default:
                        break;
                }

                MessageBox.Show(exc.Message + ". " + errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddPartMeasure(string sPartMeasure, string sMeasureCode,
            string sHomogeneousClassID, string sPartID)
        {
            if (sHomogeneousClassID == "")
            {
                MessageBox.Show(this, "no homogeneous class for this part", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bool isAdded = false;
            for (int i = 0; i < panel1.Controls.Count; i++)
            {
                Cntrls.PriceRange curPricerange = (Cntrls.PriceRange)panel1.Controls[i];
                if (sHomogeneousClassID.Equals(curPricerange.Homogeneity))
                {
                    curPricerange.AddMeasures(sPartMeasure, sMeasureCode, sPartID);
                    curPricerange.Homogeneity = sHomogeneousClassID;
                    isAdded = true;
                    break;
                }
            }
            if (isAdded == false)
            {
                Cntrls.PriceRange pr = new Cntrls.PriceRange((panel1.Controls.Count + 1));
                pr.Location = new System.Drawing.Point(0, (((panel1.Controls.Count) * 160)));
                panel1.Controls.Add(pr);
                pr.AddMeasures(sPartMeasure, sMeasureCode, sPartID);
                pr.Homogeneity = sHomogeneousClassID;

                if (dsInitPrice != null)
                {
                    DataRow[] drPR = dsInitPrice.Tables["PriceRange"].Select("HomogeneousClassID = " + sHomogeneousClassID);
                    DataSet dsRange = new DataSet();
                    dsRange.Tables.Add("PriceRange");
                    dsRange.Tables[0].Columns.Add("From", Type.GetType("System.Double"));
                    dsRange.Tables[0].Columns.Add("To", Type.GetType("System.Double"));
                    dsRange.Tables[0].Columns.Add("Price", Type.GetType("System.Double"));
                    for (int i = 0; i < drPR.Length; i++)
                    {
                        dsRange.Tables[0].Rows.Add(new object[]{System.Convert.ToDouble(drPR[i]["From"]).ToString("0.##"), 
																   System.Convert.ToDouble(drPR[i]["To"]).ToString("0.##"), 
																   System.Convert.ToDouble(drPR[i]["Price"]).ToString("0.##")});
                    }
                    pr.ReInitRange(dsRange);
                }
            }
        }

        private void bpServiceDelete_Click(object sender, System.EventArgs e)
        {
            if (panel2.Controls.Count > 0)
            {
                panel2.Controls.RemoveAt(panel2.Controls.Count - 1);
            }
        }
        private void controlRemoved(object sender, System.Windows.Forms.ControlEventArgs e)
        {
            int tempY = 0;
            for (int i = 0; i < panel1.Controls.Count; i++)
            {
                if ((panel1.Controls[i].Location.Y - tempY) > 160)
                {
                    Point newLocation = new Point(0, tempY + 160);
                    panel1.Controls[i].Location = newLocation;
                    ((Cntrls.PriceRange)panel1.Controls[i]).newTitel(i + 1);
                }
                tempY = panel1.Controls[i].Location.Y;
            }
        }

        private void tbpFixed_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (((TextBox)sender).Enabled && ((TextBox)sender).Text != "")
                try
                {
                    ((TextBox)sender).Text = System.Convert.ToDouble(((TextBox)sender).Text).ToString("0.##");
                    errProv1.SetError((TextBox)sender, "");
                }
                catch
                {
                    errProv1.SetError((TextBox)sender, "Wrong number format.");
                }
            else errProv1.SetError((TextBox)sender, "");
        }

		private void bCancel_Click(object sender, EventArgs e)
		{
			this.Close();
			isCloseNormal = false;
		}

		private void rbFixed_CheckedChanged(object sender, EventArgs e)
		{
			gbpDinamic.Enabled = !rbFixed.Checked;
			tbpFixed.Enabled = rbFixed.Checked;
			ptParts.Enabled = !rbFixed.Checked;
			lbMeasures.Enabled = !rbFixed.Checked;
			lbMeasures.Visible = !rbFixed.Checked;
			panel1.Visible = !rbFixed.Checked;
			tbpFixed.Visible = rbFixed.Checked;
			if (isLoaded)   ClearAddServiceControls();
		}

		private void ClearAddServiceControls()
		{
			if (panel2.Controls.Count > 0)
			{
				var p = panel2.Controls.Count;
				for (var i = 0; i < p; i++)
					panel2.Controls.RemoveAt(0);
			}
			cbpAdditionalServicies.Checked = false;
		}
	}
}
