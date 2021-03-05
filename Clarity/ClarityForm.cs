using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;
//using gemoDream;


namespace gemoDream
{
    //define:BATCH_CODE
    /// <summary>
    /// Summary description for ClarityForm.
    /// </summary>
    public class ClarityForm : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Label lWarnings;
        internal System.Windows.Forms.GroupBox gbItemsDone;
        internal System.Windows.Forms.GroupBox gbItemsNotDone;
        private System.Windows.Forms.StatusBar sbStatus;
        internal System.Windows.Forms.GroupBox gbWarnings;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TextBox tbItemsDone;
        private System.Windows.Forms.TextBox tbItemsNotDone;

        private int accessCode = -1;
        DataSet dsBatchSet = null;
        DataSet dsCopyBatchSet = null;
        private int curOrderCode = 0;
        private int curEntryBatchCode = 0;
        private int curBatchCode = 0;
        private int curItemCode = 0;
        private string curPartName = "";
        private int curPartId = 0;
        private string sFileName = "ClarityKeymap.xml";

        private GraderLib.TypeInfo tiChar;
        private bool bJustEntered = false;
        private int InscriptionCode = GraderLib.Codes.LaserInscription;//-1;
        private int CommentCode = -1;
        private GraderLib.WorkMode wmMode;
        private string sGrade = "";
        private string sNext = "";
        private string sMode = "";
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbShape;
        private System.Windows.Forms.Button btnEditShape;
        private System.Windows.Forms.Label lMeasures;
        private System.Windows.Forms.Label lMeasuresText;
        internal System.Windows.Forms.GroupBox gbHistory3;
        private System.Windows.Forms.Label lHistory3;
        private System.Windows.Forms.TextBox tbLaserInscription;
        private System.Windows.Forms.TextBox tbComment;
        private System.Windows.Forms.Label lCurrent;
        private System.Windows.Forms.Label lPart;
        private System.Windows.Forms.Label lItemCode;
        private System.Windows.Forms.Label lBatchCode;
        private System.Windows.Forms.Label lPartText;
        private System.Windows.Forms.Label lItemText;
        private System.Windows.Forms.Label lBatchText;
        private System.Windows.Forms.Label lItemPicture;
        private System.Windows.Forms.Label lShapePicture;
        private System.Windows.Forms.PictureBox pbItem;
        internal System.Windows.Forms.GroupBox gbHistory1;
        private System.Windows.Forms.Label lHistory1;
        internal System.Windows.Forms.GroupBox gbHistory2;
        private System.Windows.Forms.Label lHistory2;
        internal System.Windows.Forms.GroupBox gbKeyboardMode;
        private System.Windows.Forms.RadioButton rbNextItem;
        private System.Windows.Forms.RadioButton rbComment;
        private System.Windows.Forms.RadioButton rbLaserInscription;
        private System.Windows.Forms.RadioButton rbGrade;
        private System.Windows.Forms.Panel pItemPanel;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ListView listMeasureView;
        private System.Windows.Forms.CheckBox cbReplotting;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lNewItemCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lNewBatchCode;
        private System.Windows.Forms.Label lOldBatchCode;
        private System.Windows.Forms.Label lOldItemCode;
        private System.Windows.Forms.TextBox tbBlemishLocation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button b_ClearComments;
        private System.Windows.Forms.Button b_ClearLI;
        private System.Windows.Forms.Button b_ClearBlemish;
        private System.Windows.Forms.RadioButton rbBlemish;
        private System.Boolean isNewItem = false;
        private System.Windows.Forms.Button btnMeasureByCP;
        private System.Windows.Forms.Button btnMeasureByFullSet;
        private System.Windows.Forms.Label lblFullSet; // flag of new item to proceed
        private bool bFullAccess = false;
        private System.Windows.Forms.Button bSaveBatchData;
		private Label label9;
		private Label label8;
		private TextBox txt_Measurements;
		private TextBox txt_MaxMinRatio;
		private ColumnHeader columnHeader1;
        private string sFullBatchNumber;

        /// <summary>
        /// ClarityForm class constructor
        /// </summary>
        /// <param name="iAccessCode">access code</param>
        public ClarityForm(int iAccessCode)
        {
            InitializeComponent();
            this.Text = Service.sProgramTitle + " Clarity";

            tbItemsDone.Text = "";
            tbItemsNotDone.Text = "";
            lMeasures.Text = "";

            rbNextItem.Checked = true;
            accessCode = iAccessCode;
            cbReplotting.Checked = false;
            bFullAccess = false;
            lblFullSet.Text = "CP Set";

            btnMeasureByFullSet.Enabled = true;
            btnMeasureByCP.Enabled = false;
            btnMeasureByCP.Visible = false;
            sFullBatchNumber = "";
            bSaveBatchData.Enabled = false;

            //Service.GetKeymap(sFileName);
            //sFileName = Service.sAppDir + System.IO.Path.DirectorySeparatorChar + sFileName;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClarityForm));
			this.gbItemsDone = new System.Windows.Forms.GroupBox();
			this.tbItemsDone = new System.Windows.Forms.TextBox();
			this.gbItemsNotDone = new System.Windows.Forms.GroupBox();
			this.tbItemsNotDone = new System.Windows.Forms.TextBox();
			this.sbStatus = new System.Windows.Forms.StatusBar();
			this.gbWarnings = new System.Windows.Forms.GroupBox();
			this.lWarnings = new System.Windows.Forms.Label();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.panel1 = new System.Windows.Forms.Panel();
			this.lShapePicture = new System.Windows.Forms.Label();
			this.cbReplotting = new System.Windows.Forms.CheckBox();
			this.btnEditShape = new System.Windows.Forms.Button();
			this.pbShape = new System.Windows.Forms.PictureBox();
			this.lMeasures = new System.Windows.Forms.Label();
			this.lMeasuresText = new System.Windows.Forms.Label();
			this.gbHistory3 = new System.Windows.Forms.GroupBox();
			this.lHistory3 = new System.Windows.Forms.Label();
			this.tbLaserInscription = new System.Windows.Forms.TextBox();
			this.tbComment = new System.Windows.Forms.TextBox();
			this.lCurrent = new System.Windows.Forms.Label();
			this.lPart = new System.Windows.Forms.Label();
			this.lItemCode = new System.Windows.Forms.Label();
			this.lBatchCode = new System.Windows.Forms.Label();
			this.lPartText = new System.Windows.Forms.Label();
			this.lItemText = new System.Windows.Forms.Label();
			this.lBatchText = new System.Windows.Forms.Label();
			this.lItemPicture = new System.Windows.Forms.Label();
			this.pbItem = new System.Windows.Forms.PictureBox();
			this.gbHistory1 = new System.Windows.Forms.GroupBox();
			this.lHistory1 = new System.Windows.Forms.Label();
			this.gbHistory2 = new System.Windows.Forms.GroupBox();
			this.lHistory2 = new System.Windows.Forms.Label();
			this.gbKeyboardMode = new System.Windows.Forms.GroupBox();
			this.rbBlemish = new System.Windows.Forms.RadioButton();
			this.rbNextItem = new System.Windows.Forms.RadioButton();
			this.rbComment = new System.Windows.Forms.RadioButton();
			this.rbLaserInscription = new System.Windows.Forms.RadioButton();
			this.rbGrade = new System.Windows.Forms.RadioButton();
			this.pItemPanel = new System.Windows.Forms.Panel();
			this.bSaveBatchData = new System.Windows.Forms.Button();
			this.lblFullSet = new System.Windows.Forms.Label();
			this.btnMeasureByFullSet = new System.Windows.Forms.Button();
			this.btnMeasureByCP = new System.Windows.Forms.Button();
			this.listMeasureView = new System.Windows.Forms.ListView();
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.b_ClearBlemish = new System.Windows.Forms.Button();
			this.b_ClearLI = new System.Windows.Forms.Button();
			this.b_ClearComments = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.tbBlemishLocation = new System.Windows.Forms.TextBox();
			this.lOldBatchCode = new System.Windows.Forms.Label();
			this.lNewBatchCode = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.lOldItemCode = new System.Windows.Forms.Label();
			this.lNewItemCode = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txt_MaxMinRatio = new System.Windows.Forms.TextBox();
			this.txt_Measurements = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.gbItemsDone.SuspendLayout();
			this.gbItemsNotDone.SuspendLayout();
			this.gbWarnings.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbShape)).BeginInit();
			this.gbHistory3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbItem)).BeginInit();
			this.gbHistory1.SuspendLayout();
			this.gbHistory2.SuspendLayout();
			this.gbKeyboardMode.SuspendLayout();
			this.pItemPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbItemsDone
			// 
			this.gbItemsDone.Controls.Add(this.tbItemsDone);
			this.gbItemsDone.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.gbItemsDone.ForeColor = System.Drawing.Color.DimGray;
			this.gbItemsDone.Location = new System.Drawing.Point(5, 5);
			this.gbItemsDone.Name = "gbItemsDone";
			this.gbItemsDone.Size = new System.Drawing.Size(785, 90);
			this.gbItemsDone.TabIndex = 8;
			this.gbItemsDone.TabStop = false;
			this.gbItemsDone.Text = "Items done in the batch with grades";
			// 
			// tbItemsDone
			// 
			this.tbItemsDone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.tbItemsDone.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbItemsDone.Location = new System.Drawing.Point(5, 15);
			this.tbItemsDone.Multiline = true;
			this.tbItemsDone.Name = "tbItemsDone";
			this.tbItemsDone.ReadOnly = true;
			this.tbItemsDone.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbItemsDone.Size = new System.Drawing.Size(775, 65);
			this.tbItemsDone.TabIndex = 1;
			this.tbItemsDone.Text = resources.GetString("tbItemsDone.Text");
			// 
			// gbItemsNotDone
			// 
			this.gbItemsNotDone.Controls.Add(this.tbItemsNotDone);
			this.gbItemsNotDone.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.gbItemsNotDone.ForeColor = System.Drawing.Color.DimGray;
			this.gbItemsNotDone.Location = new System.Drawing.Point(795, 5);
			this.gbItemsNotDone.Name = "gbItemsNotDone";
			this.gbItemsNotDone.Size = new System.Drawing.Size(218, 90);
			this.gbItemsNotDone.TabIndex = 9;
			this.gbItemsNotDone.TabStop = false;
			this.gbItemsNotDone.Text = "Items in the batch not done yet";
			// 
			// tbItemsNotDone
			// 
			this.tbItemsNotDone.BackColor = System.Drawing.SystemColors.Control;
			this.tbItemsNotDone.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbItemsNotDone.Location = new System.Drawing.Point(10, 15);
			this.tbItemsNotDone.Multiline = true;
			this.tbItemsNotDone.Name = "tbItemsNotDone";
			this.tbItemsNotDone.ReadOnly = true;
			this.tbItemsNotDone.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbItemsNotDone.Size = new System.Drawing.Size(203, 65);
			this.tbItemsNotDone.TabIndex = 0;
			this.tbItemsNotDone.Text = "item #####.#####.###.##\r\nitem #####.#####.###.##\r\nitem #####.#####.###.##\r\nitem #" +
    "####.#####.###.##\r\nitem #####.#####.###.##";
			// 
			// sbStatus
			// 
			this.sbStatus.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.sbStatus.Location = new System.Drawing.Point(0, 686);
			this.sbStatus.Name = "sbStatus";
			this.sbStatus.Size = new System.Drawing.Size(1014, 15);
			this.sbStatus.TabIndex = 13;
			// 
			// gbWarnings
			// 
			this.gbWarnings.Controls.Add(this.lWarnings);
			this.gbWarnings.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.gbWarnings.ForeColor = System.Drawing.Color.Maroon;
			this.gbWarnings.Location = new System.Drawing.Point(0, 505);
			this.gbWarnings.Name = "gbWarnings";
			this.gbWarnings.Size = new System.Drawing.Size(445, 80);
			this.gbWarnings.TabIndex = 14;
			this.gbWarnings.TabStop = false;
			this.gbWarnings.Text = "Warnings";
			// 
			// lWarnings
			// 
			this.lWarnings.BackColor = System.Drawing.SystemColors.Control;
			this.lWarnings.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lWarnings.ForeColor = System.Drawing.Color.Maroon;
			this.lWarnings.Location = new System.Drawing.Point(5, 15);
			this.lWarnings.Name = "lWarnings";
			this.lWarnings.Size = new System.Drawing.Size(435, 60);
			this.lWarnings.TabIndex = 6;
			this.lWarnings.Text = "All kinds of warning or informational messages could be shown here. It could be g" +
    "eneral message, or it could say that calculated weight does not match real weigh" +
    "t.";
			// 
			// timer
			// 
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lShapePicture);
			this.panel1.Controls.Add(this.cbReplotting);
			this.panel1.Controls.Add(this.btnEditShape);
			this.panel1.Controls.Add(this.pbShape);
			this.panel1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.panel1.Location = new System.Drawing.Point(695, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(310, 250);
			this.panel1.TabIndex = 22;
			// 
			// lShapePicture
			// 
			this.lShapePicture.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lShapePicture.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lShapePicture.Location = new System.Drawing.Point(10, 220);
			this.lShapePicture.Name = "lShapePicture";
			this.lShapePicture.Size = new System.Drawing.Size(150, 25);
			this.lShapePicture.TabIndex = 5;
			this.lShapePicture.Text = "Shape";
			this.lShapePicture.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cbReplotting
			// 
			this.cbReplotting.Location = new System.Drawing.Point(160, 225);
			this.cbReplotting.Name = "cbReplotting";
			this.cbReplotting.Size = new System.Drawing.Size(60, 15);
			this.cbReplotting.TabIndex = 22;
			this.cbReplotting.Text = "Re-plot";
			this.cbReplotting.Click += new System.EventHandler(this.cbReplotting_Click);
			// 
			// btnEditShape
			// 
			this.btnEditShape.BackColor = System.Drawing.Color.LightSteelBlue;
			this.btnEditShape.CausesValidation = false;
			this.btnEditShape.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnEditShape.Location = new System.Drawing.Point(230, 220);
			this.btnEditShape.Name = "btnEditShape";
			this.btnEditShape.Size = new System.Drawing.Size(75, 20);
			this.btnEditShape.TabIndex = 21;
			this.btnEditShape.Text = "Plotting";
			this.btnEditShape.UseVisualStyleBackColor = false;
			this.btnEditShape.Click += new System.EventHandler(this.btnEditShape_Click);
			// 
			// pbShape
			// 
			this.pbShape.BackColor = System.Drawing.Color.White;
			this.pbShape.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.pbShape.Location = new System.Drawing.Point(5, 5);
			this.pbShape.Name = "pbShape";
			this.pbShape.Size = new System.Drawing.Size(300, 210);
			this.pbShape.TabIndex = 4;
			this.pbShape.TabStop = false;
			this.pbShape.Paint += new System.Windows.Forms.PaintEventHandler(this.pbShape_Paint);
			// 
			// lMeasures
			// 
			this.lMeasures.BackColor = System.Drawing.Color.White;
			this.lMeasures.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lMeasures.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lMeasures.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lMeasures.Location = new System.Drawing.Point(5, 95);
			this.lMeasures.Name = "lMeasures";
			this.lMeasures.Size = new System.Drawing.Size(215, 382);
			this.lMeasures.TabIndex = 20;
			this.lMeasures.Text = "measure, polish, symmetry, clarity";
			// 
			// lMeasuresText
			// 
			this.lMeasuresText.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.lMeasuresText.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lMeasuresText.Location = new System.Drawing.Point(5, 80);
			this.lMeasuresText.Name = "lMeasuresText";
			this.lMeasuresText.Size = new System.Drawing.Size(55, 15);
			this.lMeasuresText.TabIndex = 19;
			this.lMeasuresText.Text = "Measures";
			// 
			// gbHistory3
			// 
			this.gbHistory3.Controls.Add(this.lHistory3);
			this.gbHistory3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.gbHistory3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.gbHistory3.Location = new System.Drawing.Point(708, 400);
			this.gbHistory3.Name = "gbHistory3";
			this.gbHistory3.Size = new System.Drawing.Size(297, 75);
			this.gbHistory3.TabIndex = 16;
			this.gbHistory3.TabStop = false;
			this.gbHistory3.Text = "Previous summary III";
			// 
			// lHistory3
			// 
			this.lHistory3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.lHistory3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lHistory3.Location = new System.Drawing.Point(2, 10);
			this.lHistory3.Name = "lHistory3";
			this.lHistory3.Size = new System.Drawing.Size(298, 60);
			this.lHistory3.TabIndex = 6;
			this.lHistory3.Text = "measur, polish, symmetry, clarity, KM/FF.., metal, setting....";
			// 
			// tbLaserInscription
			// 
			this.tbLaserInscription.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.tbLaserInscription.Location = new System.Drawing.Point(455, 540);
			this.tbLaserInscription.Multiline = true;
			this.tbLaserInscription.Name = "tbLaserInscription";
			this.tbLaserInscription.ReadOnly = true;
			this.tbLaserInscription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbLaserInscription.Size = new System.Drawing.Size(270, 40);
			this.tbLaserInscription.TabIndex = 15;
			this.tbLaserInscription.Text = "Laser Inscription";
			// 
			// tbComment
			// 
			this.tbComment.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.tbComment.Location = new System.Drawing.Point(455, 480);
			this.tbComment.Multiline = true;
			this.tbComment.Name = "tbComment";
			this.tbComment.ReadOnly = true;
			this.tbComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbComment.Size = new System.Drawing.Size(270, 40);
			this.tbComment.TabIndex = 14;
			this.tbComment.Text = "Comment";
			// 
			// lCurrent
			// 
			this.lCurrent.AllowDrop = true;
			this.lCurrent.BackColor = System.Drawing.Color.White;
			this.lCurrent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lCurrent.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lCurrent.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lCurrent.Location = new System.Drawing.Point(220, 95);
			this.lCurrent.Name = "lCurrent";
			this.lCurrent.Size = new System.Drawing.Size(275, 382);
			this.lCurrent.TabIndex = 6;
			this.lCurrent.Text = "measure, polish, symmetry, clarity, KM/FF.., metal, setting....";
			// 
			// lPart
			// 
			this.lPart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.lPart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lPart.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.lPart.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lPart.Location = new System.Drawing.Point(40, 61);
			this.lPart.Name = "lPart";
			this.lPart.Size = new System.Drawing.Size(385, 15);
			this.lPart.TabIndex = 12;
			this.lPart.Text = "Center Stone/Side Stones....";
			this.lPart.TextChanged += new System.EventHandler(this.lPart_TextChanged);
			// 
			// lItemCode
			// 
			this.lItemCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.lItemCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lItemCode.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.lItemCode.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lItemCode.Location = new System.Drawing.Point(355, 3);
			this.lItemCode.Name = "lItemCode";
			this.lItemCode.Size = new System.Drawing.Size(160, 15);
			this.lItemCode.TabIndex = 11;
			this.lItemCode.Text = "#####.#####.###.##";
			// 
			// lBatchCode
			// 
			this.lBatchCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.lBatchCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lBatchCode.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.lBatchCode.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lBatchCode.Location = new System.Drawing.Point(90, 3);
			this.lBatchCode.Name = "lBatchCode";
			this.lBatchCode.Size = new System.Drawing.Size(160, 15);
			this.lBatchCode.TabIndex = 10;
			this.lBatchCode.Text = "#####.#####.###";
			// 
			// lPartText
			// 
			this.lPartText.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.lPartText.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lPartText.Location = new System.Drawing.Point(5, 62);
			this.lPartText.Name = "lPartText";
			this.lPartText.Size = new System.Drawing.Size(35, 15);
			this.lPartText.TabIndex = 9;
			this.lPartText.Text = "Part";
			// 
			// lItemText
			// 
			this.lItemText.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.lItemText.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lItemText.Location = new System.Drawing.Point(290, 3);
			this.lItemText.Name = "lItemText";
			this.lItemText.Size = new System.Drawing.Size(60, 15);
			this.lItemText.TabIndex = 8;
			this.lItemText.Text = "Current #";
			// 
			// lBatchText
			// 
			this.lBatchText.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.lBatchText.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lBatchText.Location = new System.Drawing.Point(5, 3);
			this.lBatchText.Name = "lBatchText";
			this.lBatchText.Size = new System.Drawing.Size(45, 15);
			this.lBatchText.TabIndex = 7;
			this.lBatchText.Text = "Batch #";
			// 
			// lItemPicture
			// 
			this.lItemPicture.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.lItemPicture.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lItemPicture.Location = new System.Drawing.Point(580, 115);
			this.lItemPicture.Name = "lItemPicture";
			this.lItemPicture.Size = new System.Drawing.Size(80, 15);
			this.lItemPicture.TabIndex = 6;
			this.lItemPicture.Text = "Item Picture";
			// 
			// pbItem
			// 
			this.pbItem.BackColor = System.Drawing.Color.White;
			this.pbItem.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.pbItem.Location = new System.Drawing.Point(545, 10);
			this.pbItem.Name = "pbItem";
			this.pbItem.Size = new System.Drawing.Size(140, 100);
			this.pbItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pbItem.TabIndex = 3;
			this.pbItem.TabStop = false;
			this.pbItem.Paint += new System.Windows.Forms.PaintEventHandler(this.pbItem_Paint);
			this.pbItem.Move += new System.EventHandler(this.pbItem_Move);
			// 
			// gbHistory1
			// 
			this.gbHistory1.Controls.Add(this.lHistory1);
			this.gbHistory1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.gbHistory1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.gbHistory1.Location = new System.Drawing.Point(708, 250);
			this.gbHistory1.Name = "gbHistory1";
			this.gbHistory1.Size = new System.Drawing.Size(297, 75);
			this.gbHistory1.TabIndex = 12;
			this.gbHistory1.TabStop = false;
			this.gbHistory1.Text = "Previous summary I";
			// 
			// lHistory1
			// 
			this.lHistory1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.lHistory1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lHistory1.Location = new System.Drawing.Point(0, 10);
			this.lHistory1.Name = "lHistory1";
			this.lHistory1.Size = new System.Drawing.Size(300, 60);
			this.lHistory1.TabIndex = 7;
			this.lHistory1.Text = "measur, polish, symmetry, clarity, KM/FF.., metal, setting....";
			// 
			// gbHistory2
			// 
			this.gbHistory2.Controls.Add(this.lHistory2);
			this.gbHistory2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.gbHistory2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.gbHistory2.Location = new System.Drawing.Point(708, 325);
			this.gbHistory2.Name = "gbHistory2";
			this.gbHistory2.Size = new System.Drawing.Size(297, 75);
			this.gbHistory2.TabIndex = 11;
			this.gbHistory2.TabStop = false;
			this.gbHistory2.Text = "Previous summary II";
			// 
			// lHistory2
			// 
			this.lHistory2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.lHistory2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lHistory2.Location = new System.Drawing.Point(0, 10);
			this.lHistory2.Name = "lHistory2";
			this.lHistory2.Size = new System.Drawing.Size(305, 60);
			this.lHistory2.TabIndex = 6;
			this.lHistory2.Text = "measur, polish, symmetry, clarity, KM/FF.., metal, setting....";
			// 
			// gbKeyboardMode
			// 
			this.gbKeyboardMode.Controls.Add(this.rbBlemish);
			this.gbKeyboardMode.Controls.Add(this.rbNextItem);
			this.gbKeyboardMode.Controls.Add(this.rbComment);
			this.gbKeyboardMode.Controls.Add(this.rbLaserInscription);
			this.gbKeyboardMode.Controls.Add(this.rbGrade);
			this.gbKeyboardMode.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.gbKeyboardMode.ForeColor = System.Drawing.Color.DimGray;
			this.gbKeyboardMode.Location = new System.Drawing.Point(865, 480);
			this.gbKeyboardMode.Name = "gbKeyboardMode";
			this.gbKeyboardMode.Size = new System.Drawing.Size(140, 95);
			this.gbKeyboardMode.TabIndex = 15;
			this.gbKeyboardMode.TabStop = false;
			this.gbKeyboardMode.Text = "Keyboard Mode ";
			// 
			// rbBlemish
			// 
			this.rbBlemish.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.rbBlemish.ForeColor = System.Drawing.SystemColors.ControlText;
			this.rbBlemish.Location = new System.Drawing.Point(10, 60);
			this.rbBlemish.Name = "rbBlemish";
			this.rbBlemish.Size = new System.Drawing.Size(104, 15);
			this.rbBlemish.TabIndex = 4;
			this.rbBlemish.Text = "Blemish";
			this.rbBlemish.CheckedChanged += new System.EventHandler(this.rbBlemish_CheckedChanged);
			// 
			// rbNextItem
			// 
			this.rbNextItem.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.rbNextItem.ForeColor = System.Drawing.SystemColors.ControlText;
			this.rbNextItem.Location = new System.Drawing.Point(10, 75);
			this.rbNextItem.Name = "rbNextItem";
			this.rbNextItem.Size = new System.Drawing.Size(125, 15);
			this.rbNextItem.TabIndex = 3;
			this.rbNextItem.Text = "Ready for next item";
			this.rbNextItem.CheckedChanged += new System.EventHandler(this.rbNextItem_CheckedChanged);
			// 
			// rbComment
			// 
			this.rbComment.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.rbComment.ForeColor = System.Drawing.SystemColors.ControlText;
			this.rbComment.Location = new System.Drawing.Point(10, 30);
			this.rbComment.Name = "rbComment";
			this.rbComment.Size = new System.Drawing.Size(104, 15);
			this.rbComment.TabIndex = 2;
			this.rbComment.Text = "Comment";
			this.rbComment.CheckedChanged += new System.EventHandler(this.rbComment_CheckedChanged);
			// 
			// rbLaserInscription
			// 
			this.rbLaserInscription.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.rbLaserInscription.ForeColor = System.Drawing.SystemColors.ControlText;
			this.rbLaserInscription.Location = new System.Drawing.Point(10, 45);
			this.rbLaserInscription.Name = "rbLaserInscription";
			this.rbLaserInscription.Size = new System.Drawing.Size(104, 15);
			this.rbLaserInscription.TabIndex = 1;
			this.rbLaserInscription.Text = "LI String";
			this.rbLaserInscription.CheckedChanged += new System.EventHandler(this.rbLaserInscription_CheckedChanged);
			// 
			// rbGrade
			// 
			this.rbGrade.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.rbGrade.ForeColor = System.Drawing.SystemColors.ControlText;
			this.rbGrade.Location = new System.Drawing.Point(10, 15);
			this.rbGrade.Name = "rbGrade";
			this.rbGrade.Size = new System.Drawing.Size(104, 15);
			this.rbGrade.TabIndex = 0;
			this.rbGrade.Text = "Grade";
			this.rbGrade.CheckedChanged += new System.EventHandler(this.rbGrade_CheckedChanged);
			// 
			// pItemPanel
			// 
			this.pItemPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pItemPanel.Controls.Add(this.label9);
			this.pItemPanel.Controls.Add(this.label8);
			this.pItemPanel.Controls.Add(this.txt_Measurements);
			this.pItemPanel.Controls.Add(this.txt_MaxMinRatio);
			this.pItemPanel.Controls.Add(this.gbHistory3);
			this.pItemPanel.Controls.Add(this.gbHistory2);
			this.pItemPanel.Controls.Add(this.gbHistory1);
			this.pItemPanel.Controls.Add(this.bSaveBatchData);
			this.pItemPanel.Controls.Add(this.lblFullSet);
			this.pItemPanel.Controls.Add(this.btnMeasureByFullSet);
			this.pItemPanel.Controls.Add(this.btnMeasureByCP);
			this.pItemPanel.Controls.Add(this.listMeasureView);
			this.pItemPanel.Controls.Add(this.b_ClearBlemish);
			this.pItemPanel.Controls.Add(this.b_ClearLI);
			this.pItemPanel.Controls.Add(this.b_ClearComments);
			this.pItemPanel.Controls.Add(this.label7);
			this.pItemPanel.Controls.Add(this.label4);
			this.pItemPanel.Controls.Add(this.tbBlemishLocation);
			this.pItemPanel.Controls.Add(this.lItemPicture);
			this.pItemPanel.Controls.Add(this.lOldBatchCode);
			this.pItemPanel.Controls.Add(this.lNewBatchCode);
			this.pItemPanel.Controls.Add(this.label6);
			this.pItemPanel.Controls.Add(this.label5);
			this.pItemPanel.Controls.Add(this.lOldItemCode);
			this.pItemPanel.Controls.Add(this.lNewItemCode);
			this.pItemPanel.Controls.Add(this.label3);
			this.pItemPanel.Controls.Add(this.label2);
			this.pItemPanel.Controls.Add(this.panel1);
			this.pItemPanel.Controls.Add(this.label1);
			this.pItemPanel.Controls.Add(this.lCurrent);
			this.pItemPanel.Controls.Add(this.lMeasuresText);
			this.pItemPanel.Controls.Add(this.tbLaserInscription);
			this.pItemPanel.Controls.Add(this.tbComment);
			this.pItemPanel.Controls.Add(this.lPart);
			this.pItemPanel.Controls.Add(this.lItemCode);
			this.pItemPanel.Controls.Add(this.lBatchCode);
			this.pItemPanel.Controls.Add(this.lPartText);
			this.pItemPanel.Controls.Add(this.lItemText);
			this.pItemPanel.Controls.Add(this.lBatchText);
			this.pItemPanel.Controls.Add(this.pbItem);
			this.pItemPanel.Controls.Add(this.lMeasures);
			this.pItemPanel.Controls.Add(this.gbWarnings);
			this.pItemPanel.Controls.Add(this.gbKeyboardMode);
			this.pItemPanel.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.pItemPanel.Location = new System.Drawing.Point(3, 100);
			this.pItemPanel.Name = "pItemPanel";
			this.pItemPanel.Size = new System.Drawing.Size(1010, 590);
			this.pItemPanel.TabIndex = 10;
			// 
			// bSaveBatchData
			// 
			this.bSaveBatchData.BackColor = System.Drawing.Color.PeachPuff;
			this.bSaveBatchData.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bSaveBatchData.Location = new System.Drawing.Point(515, 435);
			this.bSaveBatchData.Name = "bSaveBatchData";
			this.bSaveBatchData.Size = new System.Drawing.Size(135, 20);
			this.bSaveBatchData.TabIndex = 45;
			this.bSaveBatchData.Text = "Save Batch Manually";
			this.bSaveBatchData.UseVisualStyleBackColor = false;
			this.bSaveBatchData.Click += new System.EventHandler(this.bSaveBatchData_Click);
			// 
			// lblFullSet
			// 
			this.lblFullSet.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblFullSet.Location = new System.Drawing.Point(780, 490);
			this.lblFullSet.Name = "lblFullSet";
			this.lblFullSet.Size = new System.Drawing.Size(80, 20);
			this.lblFullSet.TabIndex = 44;
			this.lblFullSet.Text = "Data Set:";
			this.lblFullSet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnMeasureByFullSet
			// 
			this.btnMeasureByFullSet.BackColor = System.Drawing.Color.LightGray;
			this.btnMeasureByFullSet.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnMeasureByFullSet.Location = new System.Drawing.Point(780, 515);
			this.btnMeasureByFullSet.Name = "btnMeasureByFullSet";
			this.btnMeasureByFullSet.Size = new System.Drawing.Size(80, 20);
			this.btnMeasureByFullSet.TabIndex = 43;
			this.btnMeasureByFullSet.Text = "Get Full Set";
			this.btnMeasureByFullSet.UseVisualStyleBackColor = false;
			this.btnMeasureByFullSet.Click += new System.EventHandler(this.btnMeasureByFullSet_Click);
			// 
			// btnMeasureByCP
			// 
			this.btnMeasureByCP.BackColor = System.Drawing.Color.Tan;
			this.btnMeasureByCP.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnMeasureByCP.Location = new System.Drawing.Point(785, 515);
			this.btnMeasureByCP.Name = "btnMeasureByCP";
			this.btnMeasureByCP.Size = new System.Drawing.Size(75, 20);
			this.btnMeasureByCP.TabIndex = 42;
			this.btnMeasureByCP.Text = "Get CP Set";
			this.btnMeasureByCP.UseVisualStyleBackColor = false;
			this.btnMeasureByCP.Click += new System.EventHandler(this.btnMeasureByCP_Click);
			// 
			// listMeasureView
			// 
			this.listMeasureView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listMeasureView.CheckBoxes = true;
			this.listMeasureView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
			this.listMeasureView.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listMeasureView.FullRowSelect = true;
			this.listMeasureView.GridLines = true;
			this.listMeasureView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listMeasureView.Location = new System.Drawing.Point(3, 79);
			this.listMeasureView.MultiSelect = false;
			this.listMeasureView.Name = "listMeasureView";
			this.listMeasureView.Size = new System.Drawing.Size(499, 398);
			this.listMeasureView.TabIndex = 23;
			this.listMeasureView.TabStop = false;
			this.listMeasureView.UseCompatibleStateImageBehavior = false;
			this.listMeasureView.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Measure";
			this.columnHeader2.Width = 213;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Data";
			this.columnHeader3.Width = 261;
			// 
			// b_ClearBlemish
			// 
			this.b_ClearBlemish.Location = new System.Drawing.Point(401, 480);
			this.b_ClearBlemish.Name = "b_ClearBlemish";
			this.b_ClearBlemish.Size = new System.Drawing.Size(44, 20);
			this.b_ClearBlemish.TabIndex = 41;
			this.b_ClearBlemish.Text = "Clear";
			// 
			// b_ClearLI
			// 
			this.b_ClearLI.Location = new System.Drawing.Point(730, 550);
			this.b_ClearLI.Name = "b_ClearLI";
			this.b_ClearLI.Size = new System.Drawing.Size(40, 20);
			this.b_ClearLI.TabIndex = 40;
			this.b_ClearLI.Text = "Clear";
			// 
			// b_ClearComments
			// 
			this.b_ClearComments.Location = new System.Drawing.Point(730, 490);
			this.b_ClearComments.Name = "b_ClearComments";
			this.b_ClearComments.Size = new System.Drawing.Size(40, 20);
			this.b_ClearComments.TabIndex = 39;
			this.b_ClearComments.Text = "Clear";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(455, 525);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(95, 10);
			this.label7.TabIndex = 35;
			this.label7.Text = "Laser Inscription";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(513, 467);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(85, 10);
			this.label4.TabIndex = 34;
			this.label4.Text = "Comments";
			// 
			// tbBlemishLocation
			// 
			this.tbBlemishLocation.Location = new System.Drawing.Point(0, 480);
			this.tbBlemishLocation.Multiline = true;
			this.tbBlemishLocation.Name = "tbBlemishLocation";
			this.tbBlemishLocation.ReadOnly = true;
			this.tbBlemishLocation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbBlemishLocation.Size = new System.Drawing.Size(395, 20);
			this.tbBlemishLocation.TabIndex = 33;
			this.tbBlemishLocation.Text = "Blemish Locations";
			// 
			// lOldBatchCode
			// 
			this.lOldBatchCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.lOldBatchCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lOldBatchCode.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.lOldBatchCode.ForeColor = System.Drawing.Color.Blue;
			this.lOldBatchCode.Location = new System.Drawing.Point(90, 42);
			this.lOldBatchCode.Name = "lOldBatchCode";
			this.lOldBatchCode.Size = new System.Drawing.Size(160, 15);
			this.lOldBatchCode.TabIndex = 32;
			this.lOldBatchCode.Text = "#####.#####.###";
			// 
			// lNewBatchCode
			// 
			this.lNewBatchCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.lNewBatchCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lNewBatchCode.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.lNewBatchCode.ForeColor = System.Drawing.Color.Blue;
			this.lNewBatchCode.Location = new System.Drawing.Point(90, 22);
			this.lNewBatchCode.Name = "lNewBatchCode";
			this.lNewBatchCode.Size = new System.Drawing.Size(160, 15);
			this.lNewBatchCode.TabIndex = 31;
			this.lNewBatchCode.Text = "#####.#####.###";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(5, 42);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(75, 15);
			this.label6.TabIndex = 30;
			this.label6.Text = "Old Batch #";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(5, 22);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(75, 15);
			this.label5.TabIndex = 29;
			this.label5.Text = "New Batch #";
			// 
			// lOldItemCode
			// 
			this.lOldItemCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.lOldItemCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lOldItemCode.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.lOldItemCode.ForeColor = System.Drawing.Color.Blue;
			this.lOldItemCode.Location = new System.Drawing.Point(355, 42);
			this.lOldItemCode.Name = "lOldItemCode";
			this.lOldItemCode.Size = new System.Drawing.Size(160, 15);
			this.lOldItemCode.TabIndex = 28;
			this.lOldItemCode.Text = "#####.#####.###.##";
			// 
			// lNewItemCode
			// 
			this.lNewItemCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.lNewItemCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lNewItemCode.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.lNewItemCode.ForeColor = System.Drawing.Color.Blue;
			this.lNewItemCode.Location = new System.Drawing.Point(355, 22);
			this.lNewItemCode.Name = "lNewItemCode";
			this.lNewItemCode.Size = new System.Drawing.Size(160, 15);
			this.lNewItemCode.TabIndex = 27;
			this.lNewItemCode.Text = "#####.#####.###.##";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(290, 42);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(55, 15);
			this.label3.TabIndex = 26;
			this.label3.Text = "Old #";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(290, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(55, 15);
			this.label2.TabIndex = 25;
			this.label2.Text = "New #";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(230, 80);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(70, 15);
			this.label1.TabIndex = 24;
			this.label1.Text = "Data";
			// 
			// txt_MaxMinRatio
			// 
			this.txt_MaxMinRatio.Location = new System.Drawing.Point(536, 205);
			this.txt_MaxMinRatio.Name = "txt_MaxMinRatio";
			this.txt_MaxMinRatio.Size = new System.Drawing.Size(101, 20);
			this.txt_MaxMinRatio.TabIndex = 46;
			// 
			// txt_Measurements
			// 
			this.txt_Measurements.Location = new System.Drawing.Point(536, 260);
			this.txt_Measurements.Name = "txt_Measurements";
			this.txt_Measurements.Size = new System.Drawing.Size(137, 20);
			this.txt_Measurements.TabIndex = 47;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(534, 181);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(113, 16);
			this.label8.TabIndex = 48;
			this.label8.Text = "Max/Min Ratio";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(537, 237);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(129, 16);
			this.label9.TabIndex = 49;
			this.label9.Text = "Max/Min/Height";
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "M";
			this.columnHeader1.Width = 1;
			// 
			// ClarityForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
			this.ClientSize = new System.Drawing.Size(1014, 701);
			this.Controls.Add(this.pItemPanel);
			this.Controls.Add(this.sbStatus);
			this.Controls.Add(this.gbItemsNotDone);
			this.Controls.Add(this.gbItemsDone);
			this.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.Name = "ClarityForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "clarity / Clarity Name";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ClarityForm_KeyDown);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ClarityForm_KeyPress);
			this.gbItemsDone.ResumeLayout(false);
			this.gbItemsDone.PerformLayout();
			this.gbItemsNotDone.ResumeLayout(false);
			this.gbItemsNotDone.PerformLayout();
			this.gbWarnings.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbShape)).EndInit();
			this.gbHistory3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbItem)).EndInit();
			this.gbHistory1.ResumeLayout(false);
			this.gbHistory2.ResumeLayout(false);
			this.gbKeyboardMode.ResumeLayout(false);
			this.pItemPanel.ResumeLayout(false);
			this.pItemPanel.PerformLayout();
			this.ResumeLayout(false);

        }
        #endregion


        /// <summary>
        /// Timer tick event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event argument</param>
        private void timer_Tick(object sender, System.EventArgs e)
        {
            timer.Stop();

            if (sNext.Length == 10 && sFullBatchNumber != sNext.Substring(0, 8)) bFullAccess = false;
            if (sNext.Length == 11 && sFullBatchNumber != sNext.Substring(0, 9)) bFullAccess = false;

            //        {
            //				if(sFullBatchNumber != sNext.Substring(0, 8)) bFullAccess = false;

            if (bFullAccess)
            {
                btnMeasureByFullSet.Enabled = false;
                btnMeasureByFullSet.Visible = false;
                btnMeasureByCP.Enabled = true;
                btnMeasureByCP.Visible = true;
                lblFullSet.Text = "Full Set";
            }

            else
            {
                btnMeasureByFullSet.Enabled = true;
                btnMeasureByFullSet.Visible = true;
                btnMeasureByCP.Enabled = false;
                btnMeasureByCP.Visible = false;
                lblFullSet.Text = "CP Set";
            }

            //			}

            wmMode = GraderLib.WorkMode.NextNotEnteringCode;
            isNewItem = true;

            //pbShape.Parent = pnlShape;
            //pbItem.Parent = pnlItem;
            GraderWork.GetEnteredItem(ref sNext,
                ref dsBatchSet,
                ref curOrderCode,
                ref curEntryBatchCode,
                ref curBatchCode,
                ref curItemCode,
                ref curPartName,
                ref curPartId,
                ref accessCode,
                ref lPart,
                ref lCurrent,
                ref lHistory1,
                ref lHistory2,
                ref lHistory3,
                ref rbNextItem,
                ref lBatchCode,
                ref lNewBatchCode,
                ref lOldBatchCode,
                ref lItemCode,
                ref lNewItemCode,
                ref	lOldItemCode,
                ref lWarnings,
                ref rbGrade,
                ref tbItemsDone,
                ref tbItemsNotDone,
                GraderLib.Codes.Clarity,
                ref pbShape,
                ref pbItem,
                ref tbComment,
                ref tbLaserInscription,
                InscriptionCode,
                ref lMeasures,
                GraderLib.Codes.Clarity,
                isNewItem,
                ref bFullAccess);

            //if(dsBatchSet != null) bSaveBatchData.Enabled = true;
            cbReplotting.Checked = false;
            btnEditShape.Enabled = true;
            ToPlotOrNotToPlot();
            LoadListView (ref listMeasureView, ref lMeasures, ref lCurrent);
            //PrintShape(10001);
        }



        /// <summary>
        /// CheckedChanged event handler for the Comment radio button
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void rbComment_CheckedChanged(object sender, System.EventArgs e)
        {
            if (rbComment.Checked)
            {
                btnMeasureByFullSet.Enabled = false;
                btnMeasureByCP.Enabled = false;
            }
            else
            {
                btnMeasureByFullSet.Enabled = true;
                btnMeasureByCP.Enabled = true;
            }

            DataView dvValues, dvValues0;
            if (!rbComment.Checked && curOrderCode != 0 && curEntryBatchCode != 0 && curBatchCode != 0 && curItemCode != 0)
            {
                DataTable dtValues = dsBatchSet.Tables["tblValues"];
                DataTable dtValues0 = dsBatchSet.Tables["tblValues0"];

                dvValues = new DataView(dtValues);
                dvValues0 = new DataView(dtValues0);
                dvValues.RowFilter = "ItemCode=" + curItemCode + " and PartId=" + curPartId + " and MeasureID= 26"; //+InscriptionCode;
                dvValues0.RowFilter = "ItemCode=" + curItemCode + " and PartId=" + curPartId + " and MeasureID= 26";//+InscriptionCode;

                if (dvValues.Count > 0)
                {
                    dvValues[0]["StringValue"] = tbComment.Text;
                    dvValues0[0]["StringValue"] = tbComment.Text;
                    dvValues[0]["IsDone"] = 1;
                }

                tbItemsDone.Focus();
                return;
                //				int a = curPartId;
                //				DataTable dtItems = dsBatchSet.Tables["tblItems"];
                //				DataView dvItems = new DataView(dtItems);
                //				dvItems.RowFilter = "ItemCode="+curItemCode;
                //				//Now Comments goes to Internal comment of ItemContainer. In Library.cs - UpdateBatchInfo
                //				dvItems[0]["ItemComment"] = tbComment.Text;
                //
                //				tbItemsDone.Focus();
                //				return;
            }

            if (!rbComment.Checked && curOrderCode == 0 && curEntryBatchCode == 0 && curBatchCode == 0 && curItemCode == 0)
                return;

            if (curOrderCode == 0 && curEntryBatchCode == 0 && curBatchCode == 0 && curItemCode == 0)
            {
                lWarnings.Text = "Enter item code first, please";
                rbNextItem.Checked = true;
                return;
            }

            lWarnings.Text = "";
            wmMode = GraderLib.WorkMode.Comment;

            tbLaserInscription.ReadOnly = true;
            tbComment.ReadOnly = false;
            tbComment.Focus();
        }

        /// <summary>
        /// CheckedChanged event handler for the laser inscription radio button
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void rbLaserInscription_CheckedChanged(object sender, System.EventArgs e)
        {
            if (rbLaserInscription.Checked)
            {
                btnMeasureByFullSet.Enabled = false;
                btnMeasureByCP.Enabled = false;
            }
            else
            {
                btnMeasureByFullSet.Enabled = true;
                btnMeasureByCP.Enabled = true;
            }
            DataView dvValues, dvValues0;
            if (!rbLaserInscription.Checked && curOrderCode != 0 && curEntryBatchCode != 0 && curBatchCode != 0 && curItemCode != 0)
            {
                DataTable dtValues = dsBatchSet.Tables["tblValues"];
                DataTable dtValues0 = dsBatchSet.Tables["tblValues0"];

                dvValues = new DataView(dtValues);
                dvValues0 = new DataView(dtValues0);
                dvValues.RowFilter = "ItemCode=" + curItemCode + " and PartId=" + curPartId + " and MeasureID=" + InscriptionCode;
                dvValues0.RowFilter = "ItemCode=" + curItemCode + " and PartId=" + curPartId + " and MeasureID=" + InscriptionCode;

                if (dvValues.Count > 0)
                {
                    dvValues[0]["StringValue"] = tbLaserInscription.Text;
                    dvValues0[0]["StringValue"] = tbLaserInscription.Text;
                    dvValues[0]["IsDone"] = 1;
                }

                tbItemsDone.Focus();
                return;
            }

            if (!rbLaserInscription.Checked && curOrderCode == 0 && curEntryBatchCode == 0 && curBatchCode == 0 && curItemCode == 0)
                return;

            if (curOrderCode == 0 && curEntryBatchCode == 0 && curBatchCode == 0 && curItemCode == 0)
            {
                rbNextItem.Checked = true;
                lWarnings.Text = "Enter item code first, please";
                //MessageBox.Show("Enter item code first, please");
                return;
            }

            dvValues = new DataView(dsBatchSet.Tables["tblValues"]);
            dvValues.RowFilter = "ItemCode=" + curItemCode + " and PartId=" + curPartId + " and MeasureID=" + InscriptionCode;
            if (dvValues.Count == 0)
            {
                rbGrade.Checked = true;
                lWarnings.Text = "There is no measure Laser inscription for current part";
                return;
            }

            lWarnings.Text = "";
            wmMode = GraderLib.WorkMode.LaserInscription;

            tbComment.ReadOnly = true;
            tbLaserInscription.ReadOnly = false;
            tbLaserInscription.Focus();
        }

        /// <summary>
        /// CheckedChanged event handler for the Ready for nex item radio button
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void rbNextItem_CheckedChanged(object sender, System.EventArgs e)
        {
            if (!rbNextItem.Checked)
                return;

            //
            if (dsBatchSet != null)
                GraderLib.UpdateItemValue(ref dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, curItemCode, false);
            //
            wmMode = GraderLib.WorkMode.NextNotEnteringCode;

            lBatchCode.Text = "#####.#####.###";
            lItemCode.Text = "#####.#####.###.##";
            lNewBatchCode.Text = "";
            lNewItemCode.Text = "";
            lOldItemCode.Text = "";
            lOldBatchCode.Text = "";

            lPart.Text = "";
            lMeasures.Text = "";
            lHistory1.Text = "";
            lHistory2.Text = "";
            lHistory3.Text = "";
            lCurrent.Text = "";
            tbComment.Text = "";
            tbLaserInscription.Text = "";
            lWarnings.Text = "";
            curOrderCode = 0;
            curEntryBatchCode = 0;
            curBatchCode = 0;
            curItemCode = 0;
            curPartName = "";
            curPartId = 0;
            tbComment.ReadOnly = true;
            tbLaserInscription.ReadOnly = true;
            pbItem.Image = null;
            pbShape.Image = null;
            sNext = "";
            listMeasureView.Items.Clear();
			txt_Measurements.Text = "";
			txt_MaxMinRatio.Text = "";
        }

        /// <summary>
        /// CheckedChanged event handler for the Grade radio button
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void rbGrade_CheckedChanged(object sender, System.EventArgs e)
        {
            if (!rbGrade.Checked)
                return;

            if (curOrderCode == 0 && curEntryBatchCode == 0 && curBatchCode == 0 && curItemCode == 0)
            {
                lWarnings.Text = "Enter item code first, please";
                rbNextItem.Checked = true;
                return;
            }

            //wmMode = GraderLib.WorkMode.GradeEnteringStringValue;
            wmMode = GraderLib.WorkMode.GradeEnteringEnumValue;
            tbComment.ReadOnly = true;
            tbLaserInscription.ReadOnly = true;

            lWarnings.Text = "";
            sGrade = "";
        }
        private void ToPlotOrNotToPlot()
        {
            if (lMeasures.Text.ToUpper().IndexOf("PLOT") >= 0)
            {
                if (lCurrent.Text.ToUpper().IndexOf("PLOT") >= 0)
                {
                    lShapePicture.Text = "Need Plotting";
                    lShapePicture.ForeColor = System.Drawing.Color.Red;
                    lShapePicture.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));

                }
                else
                {
                    lShapePicture.Text = "Shape";
                    lShapePicture.ForeColor = System.Drawing.Color.Black;
                    lShapePicture.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
                }
            }
            else
            {
                lShapePicture.Text = "Shape";
                lShapePicture.ForeColor = System.Drawing.Color.Black;
                lShapePicture.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
            }
        }

        private void LoadListView(ref ListView listMeasureView, ref Label lMeasures, ref Label lCurrent)
        {

            listMeasureView.Items.Clear();
			string sMeasureList = lMeasures.Text.Replace("\n\r","|");
			char[] separator = { '|' };
			string[] Title = sMeasureList.Split(separator);
            //string[] Title = lMeasures.Text.Split(separator);
			string sValues = lCurrent.Text.Replace("\n\r", "|").Replace(",","");
			string[] Values = sValues.Split(separator);
            //string[] Values = lCurrent.Text.Split(separator);

            if (Title.Length > 0 && Values.Length > 0)
            {
                listMeasureView.Columns[0].Width = 1;
				listMeasureView.Columns[1].Width = 213;
				listMeasureView.Columns[2].Width = 261;
				for (int i = 0; i < Title.Length; ++i)
                {
                    ListViewItem LoadList = new ListViewItem((i+1).ToString());
					string sTitle = Title[i];
					string sValue = Values[i];
			        LoadList.SubItems.Add(Title[i]);
					switch (Title[i].Trim().ToUpper())
					{
						case "MEASUREMENTS":
							txt_Measurements.Text = sValue;
                            try
                            {
                                if (txt_Measurements.Text.Trim() != "" && txt_MaxMinRatio.Text.Trim() == "")
                                {
                                        string[] sRatio = null;
                                        double dMax = 0.00;
                                        double dMin = 0.00;
                                        sRatio = txt_Measurements.Text.Trim().ToUpper().Replace(" ", "").Replace("-", ";").Replace("X", ";").Split(';');
                                        //if (txt_Measurements.Text.Trim().Contains("-")) sRatio = txt_Measurements.Text.Trim().Split('-');
                                        //else if (txt_Measurements.Text.Trim().Contains("+")) sRatio = txt_Measurements.Text.Trim().Split('+');
                                        if (sRatio.Length > 1)
                                        {
                                            dMax = Math.Max(double.Parse(sRatio[0].Trim()), double.Parse(sRatio[1].Trim()));
                                            dMin = Math.Min(double.Parse(sRatio[0].Trim()), double.Parse(sRatio[1].Trim()));
                                            if (dMax > double.Epsilon && dMin > double.Epsilon)
                                                txt_MaxMinRatio.Text = (dMax / dMin).ToString("##0.##");
                                        }
                                  
                                }
                            }
                            catch { }

							break;
						case "MAX/MIN":
							txt_MaxMinRatio.Text = sValue;
							break;
						default:
							break;
					}
					//if (sTitle.Trim().ToUpper() == "MEASUREMENTS") txt_Measurements.Text = sValue;

                    LoadList.SubItems.Add(Values[i]);
                    listMeasureView.Items.Add(LoadList);
                }

            }
        }

        /// <summary>
        /// ClarityForm keyDown event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event argument</param>
        private void ClarityForm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
                #region Choosing NextPart
                if (e.KeyCode == Keys.Enter && wmMode == GraderLib.WorkMode.ChoosingMode && sMode == "" && curPartId != 0 && curItemCode != 0)
                {
                    isNewItem = false;
                    //rbGrade_CheckedChanged(this, EventArgs.Empty);
                    rbGrade.Checked = false;
                    rbGrade.Checked = true;
                    GraderWork.SelectNextPart(ref dsBatchSet,
                        ref curOrderCode,
                        ref curEntryBatchCode,
                        ref curBatchCode,
                        ref curItemCode,
                        ref curPartName,
                        ref curPartId,
                        ref lPart,
                        ref lCurrent,
                        ref lHistory1,
                        ref lHistory2,
                        ref lHistory3,
                        ref tbItemsDone,
                        ref tbItemsNotDone,
                        ref rbNextItem,
                        ref pbShape,
                        ref pbItem,
                        GraderLib.Codes.Clarity,
                        ref tbComment,
                        ref tbLaserInscription,
                        InscriptionCode,
                        true,
                        ref lMeasures);
                    btnEditShape.Enabled = true;
                    ToPlotOrNotToPlot();
                    LoadListView (ref listMeasureView, ref lMeasures, ref lCurrent);
                    //tbComment.Text="";
                }
                #endregion

                #region Closing Batch manually
                if (e.KeyCode == Keys.Enter && wmMode == GraderLib.WorkMode.ChoosingMode && curPartId == 0 && curItemCode == 0)
                {
                    isNewItem = false;
                    wmMode = GraderLib.WorkMode.NextNotEnteringCode;
                    dsCopyBatchSet = dsBatchSet.Copy();
                    dsCopyBatchSet.DataSetName = "CopyOfMainDataSet";
                    if (dsCopyBatchSet != null) bSaveBatchData.Enabled = true;
                    //GraderLib.UpdateItemValue(ref dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, curItemCode, false);
                    TextBox tbLaserInscription = new TextBox();
                    TextBox tbComment = new TextBox();
                    bFullAccess = false;

                    GraderWork.UpdateDbBatch(ref dsBatchSet,
                        ref lPart,
                        ref lCurrent,
                        ref lHistory1,
                        ref lHistory2,
                        ref lHistory3,
                        ref tbItemsDone,
                        ref tbItemsNotDone,
                        ref rbNextItem,
                        ref pbShape,
                        ref pbItem,
                        GraderLib.Codes.Clarity,
                        ref tbComment,
                        ref tbLaserInscription);
                    btnEditShape.Enabled = true;
					LoadListView(ref listMeasureView, ref lMeasures, ref lCurrent);
                }
                #endregion

                #region Changing Mode
                if (e.KeyCode == Keys.Escape)
                {

                    sMode = "";
                    tbItemsDone.Focus();
                    wmMode = GraderLib.WorkMode.ChoosingMode;
                    e.Handled = true;
                    return;
                }
                #endregion
                if (e.Alt == true && e.KeyCode == Keys.S && wmMode == GraderLib.WorkMode.GradeEnteringEnumValue)
                {
                    SelectShape();
                }
            }
            catch (Exception eEx)
            {
                lWarnings.Text = eEx.Message;
                sGrade = "";
                return;
            }
        }

        /// <summary>
        /// ClarityForm keypress event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event argument</param>
        private void ClarityForm_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (wmMode == GraderLib.WorkMode.NextEnteringCode || wmMode == GraderLib.WorkMode.NextNotEnteringCode)
            {
                //NextKeyPress(e);
                GraderWork.NextKeyPress(e,
                    ref timer,
                    ref bJustEntered,
                    ref wmMode,
                    ref sNext,
                    ref lPart,
                    ref lCurrent,
                    ref lBatchCode,
                    ref lItemCode,
                    ref lWarnings,
                    ref lHistory1,
                    ref lHistory2,
                    ref lHistory3);
				LoadListView(ref listMeasureView, ref lMeasures, ref lCurrent);
                return;
            }

            if (wmMode == GraderLib.WorkMode.GradeEnteringEnumValue)
            {
                //GradeKeyPress(e);
                GraderWork.GradeKeyPress(e,
                    ref wmMode,
                    sFileName,
                    ref dsBatchSet,
                    ref curOrderCode,
                    ref curEntryBatchCode,
                    ref curBatchCode,
                    ref curItemCode,
                    ref curPartId,
                    ref curPartName,
                    ref bJustEntered,
                    ref sGrade,
                    ref sbStatus,
                    ref lWarnings,
                    ref lCurrent,
                    ref lHistory1,
                    ref lHistory2,
                    ref lHistory3,
                    ref lPart,
                    ref tbItemsDone,
                    ref tbItemsNotDone,
                    ref rbNextItem,
                    ref tiChar,
                    ref pbShape,
                    ref pbItem,
                    GraderLib.Codes.Clarity,
                    ref tbComment,
                    ref tbLaserInscription,
                    InscriptionCode,
                    ref lMeasures);

                ToPlotOrNotToPlot();
				LoadListView(ref listMeasureView, ref lMeasures, ref lCurrent);
                return;
            }

            if (wmMode == GraderLib.WorkMode.ChoosingMode)
            {
                //ModeKeyPress(e);
                GraderWork.ModeKeyPress(e,
                    sFileName,
                    ref sMode,
                    ref rbNextItem,
                    ref rbGrade,
                    ref rbComment,
                    ref rbLaserInscription,
                    ref lWarnings,
                    ref CommentCode,
                    ref InscriptionCode,
                    ref dsBatchSet,
                    curOrderCode,
                    curEntryBatchCode,
                    curBatchCode,
                    curItemCode,
                    ref tbItemsNotDone,
                    ref tbItemsDone);
                return;
            }
        }

        /// <summary>
        /// Paint event handler for pbShape
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e"> event argument</param>
        private void pbShape_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            //GraderLib.ShowCorrectPicture(ref pbShape);
            //			if(pbShape!=null && pbShape.Image != null && (pbShape.Image.Width > pbItem.Parent.Width || pbShape.Image.Height > pbShape.Parent.Height))
            //			{
            //				double k1 = (double)pbShape.Parent.Height / pbShape.Image.Size.Height;
            //				double k2 = (double)pbShape.Parent.Width / pbShape.Image.Size.Width;
            //				double k = Math.Min(k1,k2);
            //			
            //				pbShape.SizeMode = PictureBoxSizeMode.CenterImage;
            //				int h = Convert.ToInt32(pbShape.Image.Size.Height * k)-2;
            //				int w = Convert.ToInt32(pbShape.Image.Size.Width * k)-2;
            //				Image ico = pbShape.Image.GetThumbnailImage(w,h,null,IntPtr.Zero);
            //				pbShape.Image = ico;
            //			}
            //			if(pbShape!=null && pbShape.Image != null && pbShape.BackColor != Color.White)
            //				pbShape.BackColor = Color.White;
        }

        /// <summary>
        /// Paint event handler for pbItem
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event argument</param>
        private void pbItem_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            //GraderLib.ShowCorrectPicture(ref pbItem);
            if (pbItem != null && pbItem.Image != null && (pbItem.Image.Width > pbItem.Width || pbItem.Image.Height > pbItem.Height))
            {
                double k1 = (double)pbItem.Size.Height / pbItem.Image.Size.Height;
                double k2 = (double)pbItem.Size.Width / pbItem.Image.Size.Width;
                double k = Math.Min(k1, k2);

                pbItem.SizeMode = PictureBoxSizeMode.CenterImage;
                int h = Convert.ToInt32(pbItem.Image.Size.Height * k) - 2;
                int w = Convert.ToInt32(pbItem.Image.Size.Width * k) - 2;
                Image ico = pbItem.Image.GetThumbnailImage(w, h, null, IntPtr.Zero);
                pbItem.Image = ico;
            }
            if (pbItem != null && pbItem.Image != null && pbItem.BackColor != Color.White)
                pbItem.BackColor = Color.White;
        }


        private void SelectShape()
        {
            string sNewShapeCode = "";
            string sShapeCode = "";
            //check for carrent part has Shape
            DataRow[] drChars = dsBatchSet.Tables["tblChars"].Select("CharCode='" + 8 + "' and PartId='" + curPartId + "' and ItemCode='" + curItemCode + "'");
            if (drChars.Length > 0)
            {	//Get ShapeId, then ShapeCode
                DataRow[] drVals = dsBatchSet.Tables["tblValues0"].Select("PartId='" + curPartId + "' and ItemCode='" + curItemCode + "' and  (MeasureCode = 8 or MeasureID = 8)");
                if (drVals.Length > 0)
                {
                    string sShapeID = drVals[0]["ValueID"].ToString();
                    DataRow[] drSapeCodes = dsBatchSet.Tables["tblValueCodes"].Select("ValueId = '" + sShapeID + "'");
                    if (drSapeCodes.Length > 0)
                    {
                        sShapeCode = drSapeCodes[0]["ValueCode"].ToString();
                    }
                }
            }
            else
                return;
            try
            {
                if (curOrderCode != 0 && curBatchCode != 0 && curItemCode != 0 && sShapeCode == "")
                {   //if current item has not Shape, Get Shape from db by Item Code
                    DataSet dsShapeParams = new DataSet();
                    DataTable dtShapeParams = new DataTable("ShapeCodeByItemCode");
                    dtShapeParams.Columns.Add("GroupCode");
                    dtShapeParams.Columns.Add("BatchCode");
                    dtShapeParams.Columns.Add("ItemCode");
                    dtShapeParams.Rows.Add(new object[] { curOrderCode, curBatchCode, curItemCode });
                    dsShapeParams.Tables.Add(dtShapeParams);
                    DataSet dsShape = Service.ProxyGenericGet(dsShapeParams);
                    if (dsShape != null && dsShape.Tables.Count > 0 && dsShape.Tables[0].Rows.Count > 0)
                    {
                        sShapeCode = dsShape.Tables[0].Rows[0]["ValueCode"].ToString();
                    }
                }
                ShapeForm frm = new ShapeForm();
                frm.sShapeCode = sShapeCode;
                frm.ShowDialog(this);
                if (frm.sResShapeCode != null && frm.sResShapeCode != "")
                {
                    sNewShapeCode = frm.sResShapeCode;

                    //Get new shape info from db
                    DataSet dsNewShapeParams = new DataSet();
                    DataTable dtNewShapeParams = new DataTable("ShapeByCode");
                    dtNewShapeParams.Columns.Add("ShapeCode");
                    dtNewShapeParams.Rows.Add(new object[] { sNewShapeCode });
                    dsNewShapeParams.Tables.Add(dtNewShapeParams);
                    DataSet dsNewShape = Service.ProxyGenericGet(dsNewShapeParams);

                    //set new ShapeCode, Picture and Path  to local tables
                    if (dsNewShape != null && dsNewShape.Tables.Count > 0 && dsNewShape.Tables[0].Rows.Count > 0)
                    {
                        DataRow[] drParts = dsBatchSet.Tables["tblParts"].Select("ItemCode='" + curItemCode + "' and PartId='" + curPartId + "'");
                        if (drParts.Length > 0)
                        {
                            drParts[0]["ShapePath"] = dsNewShape.Tables[0].Rows[0]["Path2Drawing"];
                            drParts[0]["ShapePicture"] = dsNewShape.Tables[0].Rows[0]["Image_Path2Drawing"];
                        }
                    }

                    string sMeasureValueID = "";
                    DataRow[] drMeasureValueID = dsBatchSet.Tables["tblValueCodes"].Select("ValueCode = '" + sNewShapeCode + "'");//["ValueID"]
                    if (drMeasureValueID.Length > 0)
                    {
                        sMeasureValueID = drMeasureValueID[0]["ValueID"].ToString();
                    }
                    DataRow[] drShapes = dsBatchSet.Tables["tblValues"].Select("ItemCode = '" + curItemCode + "' and PartID = '" + curPartId + "' and (MeasureCode=8 or MeasureID=8)");
                    if (drShapes.Length > 0)
                    {
                        drShapes[0]["ValueID"] = sMeasureValueID;
                        drShapes[0]["IsDone"] = 1;

                    }
                    drShapes = dsBatchSet.Tables["tblValues0"].Select("ItemCode = '" + curItemCode + "' and PartID = '" + curPartId + "' and (MeasureCode=8 or MeasureID=8)");
                    if (drShapes.Length > 0)
                    {
                        drShapes[0]["ValueID"] = sMeasureValueID;
                        drShapes[0]["IsDone"] = 1;
                    }

                    GraderLib.UpdateCurrentPartInfo(dsBatchSet,
                        curOrderCode,
                        curEntryBatchCode,
                        curBatchCode,
                        curItemCode,
                        curPartName,
                        curPartId,
                        "tblHistory1",
                        "tblHistory2",
                        "tblHistory3",
                        ref lPart,
                        ref lCurrent,
                        ref lHistory1,
                        ref lHistory2,
                        ref lHistory3,
                        ref pbShape,
                        ref pbItem,
                        ref lMeasures);
					LoadListView(ref listMeasureView, ref lMeasures, ref lCurrent);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }


        private void btnEditShape_Click(object sender, System.EventArgs e)
        {
            const int ERROR_FILE_NOT_FOUND = 2;
            const int ERROR_ACCESS_DENIED = 5;

            ProcessStartInfo pInfo = null;
            try
            {

                DataRow[] drChars = dsBatchSet.Tables["tblChars"].Select("CharCode='" + 8 + "' and PartId='" + curPartId + "' and ItemCode='" + curItemCode + "'");
                if (drChars.Length > 0)
                {
                    DataView dvParts = new DataView(dsBatchSet.Tables["tblParts"]);
                    dvParts.RowFilter = "ItemCode=" + curItemCode + " and PartId=" + curPartId;
                    if (dvParts.Count > 0 && dvParts[0]["ShapePath"].ToString() != "")
                    {
                        string sShapeDir = Client.GetOfficeDirPath("iconDir");// + dvParts[0]["ShapePath"].ToString();
                        string sShapePath = dvParts[0]["ShapePath"].ToString();
                        string ProgFileName = Service.GetShapeEditFileName("pathToPlotting");
						ProgFileName = Service.sProgramFileFolder + System.IO.Path.DirectorySeparatorChar + ProgFileName;
                        string sPathToPlotting = Client.GetOfficeDirPath("plotDir");
                        string sPlotFileName = "";
                        if (ProgFileName != "")
                        {
                            if (curOrderCode != 0 && curBatchCode != 0 && curItemCode != 0)
                            {
                                string filter = "OrderCode = '" + curOrderCode.ToString() + "' and " +
                                    "BatchCode = '" + curBatchCode.ToString() + "' and " +
                                    "ItemCode = '" + curItemCode.ToString() + "'";
                                DataRow[] drItems = dsBatchSet.Tables["tblItems"].Select(filter);
                                string sItemNumber = Service.FillToFiveChars(curOrderCode.ToString()) +
                                    Service.FillToThreeChars(curBatchCode.ToString()) +
                                    Service.FillToTwoChars(curItemCode.ToString());

                                if (drItems.Length > 0)
                                {
                                    sItemNumber = Service.FillToFiveChars(drItems[0]["PrevGroupCode"].ToString()) +
                                        Service.FillToThreeChars(drItems[0]["PrevBatchCode"].ToString()) +
                                        Service.FillToTwoChars(drItems[0]["PrevItemCode"].ToString());
                                }

                                pInfo = new ProcessStartInfo();
                                pInfo.FileName = ProgFileName;
                                sPlotFileName = sItemNumber + "." + curPartName;
                                //sPlotFileName = sPlotFileName;

                                //pInfo.Arguments = "\"" + sShapePath + "\" " +  sItemNumber + "." + curPartName ; //old part
                                //pInfo.Arguments = sShapePath + " " + sPathToPlotting + " " + sItemNumber + "." + curPartName;// previous new part
                                //pInfo.Arguments = "\"" + sShapePath + "\" " +  sItemNumber + "." + curPartName + " " + sPathToPlotting + " " + sShapeDir;// previous new part
                                pInfo.Arguments = "\"" + sShapePath + "\" " + "\"" + sPlotFileName + "\"" + " " + sPathToPlotting + " " + sShapeDir;// last new part, 4/23/08

                                pInfo.UseShellExecute = false;
                                Process p = Process.Start(pInfo);
                                btnEditShape.Enabled = false;
                                cbReplotting.Checked = false;
                            }
                        }
                    }
                }
            }
            catch (Win32Exception ex)
            {
                if (ex.NativeErrorCode == ERROR_FILE_NOT_FOUND)
                {
                    MessageBox.Show(this, "The system cannot find the file " + pInfo.FileName, "Edit Shape", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ex.NativeErrorCode == ERROR_ACCESS_DENIED)
                {
                    MessageBox.Show(this, "The file " + pInfo.FileName + " access denied", "Edit Shape", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Edit Shape", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pbItem_Move(object sender, System.EventArgs e)
        {
            string s = "";
        }

        private void cbReplotting_Click(object sender, System.EventArgs e)
        {
            if (cbReplotting.Checked)
            {
                btnEditShape.Enabled = true;
                cbReplotting.Checked = false;
            }
        }

        private void rbBlemish_CheckedChanged(object sender, System.EventArgs e)
        {

        }

        private void btnMeasureByCP_Click(object sender, System.EventArgs e)
        {
            bFullAccess = false;
            lblFullSet.Text = "CP Set";
            btnMeasureByFullSet.Enabled = true;
            btnMeasureByFullSet.Visible = true;
            btnMeasureByCP.Enabled = false;
            btnMeasureByCP.Visible = false;
            ReloadItemVithUpdatedMeasureSet();
        }

        private void btnMeasureByFullSet_Click(object sender, System.EventArgs e)
        {
            bFullAccess = true;
            lblFullSet.Text = "Full Set";
            btnMeasureByFullSet.Enabled = false;
            btnMeasureByFullSet.Visible = false;
            btnMeasureByCP.Enabled = true;
            btnMeasureByCP.Visible = true;
            ReloadItemVithUpdatedMeasureSet();
        }

        private void ReloadItemVithUpdatedMeasureSet()
        {
            string sCurrentItem = lItemCode.Text;
            if ((sCurrentItem.Length == 18 && sCurrentItem.IndexOf("#") == -1) || (sCurrentItem.Length == 20 && sCurrentItem.IndexOf("#") == -1))
            {
                string[] ssCurrentItem = lItemCode.Text.Split('.');
                int iOrderCode = Convert.ToInt32(ssCurrentItem[0]);
                int iEntryBatchCode = Convert.ToInt32(ssCurrentItem[1]);
                int iBatchCode = Convert.ToInt32(ssCurrentItem[2]);
                int iItemCode = Convert.ToInt32(ssCurrentItem[3]);

                try
                {
                    wmMode = GraderLib.WorkMode.NextNotEnteringCode;
                    TextBox tbLaserInscription = new TextBox();
                    TextBox tbComment = new TextBox();
                    DataView dvItems = new DataView(dsBatchSet.Tables["tblItems"]);
                    dvItems.RowFilter = "OrderCode=" + ssCurrentItem[0] + " and EntryBatchCode=" + ssCurrentItem[1] + " and BatchCode=" + ssCurrentItem[2] + " and ItemCode=" + ssCurrentItem[3];

                    if (dvItems.Count == 1)
                        dvItems[0]["IsDone"] = 1;

                    rbLaserInscription_CheckedChanged(this, System.EventArgs.Empty);
                    rbComment_CheckedChanged(this, System.EventArgs.Empty);

                    GraderLib.UpdateDoneNotDoneItemBoxes
                        (dsBatchSet,
                        iOrderCode,
                        iEntryBatchCode,
                        iBatchCode,
                        ref tbItemsNotDone,
                        ref tbItemsDone);

                    GraderWork.UpdateDbBatch
                        (ref dsBatchSet,
                        ref lPart,
                        ref lCurrent,
                        ref lHistory1,
                        ref lHistory2,
                        ref lHistory3,
                        ref tbItemsDone,
                        ref tbItemsNotDone,
                        ref rbNextItem,
                        ref pbShape,
                        ref pbItem,
                        GraderLib.Codes.Clarity,
                        ref tbComment,
                        ref tbLaserInscription);
					LoadListView(ref listMeasureView, ref lMeasures, ref lCurrent);
                }
                catch (Exception eEx)
                {
                    lWarnings.Text = eEx.Message;
                }
                if (dsBatchSet != null)
                {
                    dsBatchSet.Dispose();
                    dsBatchSet = null;
                }
                lItemCode.Text = sCurrentItem;
                sNext = ssCurrentItem[0] + ssCurrentItem[2] + ssCurrentItem[3];
                if (sNext.Length == 10)
                    sFullBatchNumber = sNext.Substring(0, 8);
                if (sNext.Length == 11)
                    sFullBatchNumber = sNext.Substring(0, 9);
                timer_Tick(this, EventArgs.Empty);
            }
        }

        private void bSaveBatchData_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (dsCopyBatchSet != null)
                {
                    lWarnings.Text = "";
                    GraderWork.UpdateDbBatch
                        (ref dsCopyBatchSet,
                        ref lPart,
                        ref lCurrent,
                        ref lHistory1,
                        ref lHistory2,
                        ref lHistory3,
                        ref tbItemsDone,
                        ref tbItemsNotDone,
                        ref rbNextItem,
                        ref pbShape,
                        ref pbItem,
                        GraderLib.Codes.Clarity,
                        ref tbComment,
                        ref tbLaserInscription);
					LoadListView(ref listMeasureView, ref lMeasures, ref lCurrent);

                    bSaveBatchData.Enabled = false;
                    dsCopyBatchSet = null;
                    //"Batch was worked up. Enter next batch item code, please"
                    lWarnings.Text = "Batch was saved. Enter next item code, please";
                }
            }
            catch (Exception eEx)
            {
                lWarnings.Text = eEx.Message;
                bSaveBatchData.Enabled = false;
            }
        }

        private void lPart_TextChanged(object sender, System.EventArgs e)
        {
            if (lPart.Text.ToUpper().IndexOf("DIAMOND") >= 0)
            {
                ToPlotOrNotToPlot();
            }
            else
            {
                lShapePicture.Text = "Shape";
                lShapePicture.ForeColor = System.Drawing.Color.Black;
                lShapePicture.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
            }

        }
    }
}