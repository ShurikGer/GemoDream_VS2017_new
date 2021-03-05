using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;


namespace gemoDream
{
    /// <summary>
    /// Summary description for ColorForm.
    /// </summary>
    public class ColorForm : System.Windows.Forms.Form
    {
        public int accessLevel;
        internal System.Windows.Forms.GroupBox gbItemsNotDone;
        internal System.Windows.Forms.GroupBox gbItemsDone;
        private System.Windows.Forms.Label lItemCode;
        private System.Windows.Forms.Label lBatchCode;
        private System.Windows.Forms.Label lItemCaption;
        private System.Windows.Forms.Label lBatchCaption;
        private System.Windows.Forms.Label lItemPictureCaption;
        private System.Windows.Forms.Label lShapeCaption;
        private System.Windows.Forms.PictureBox pbShape;
        private System.Windows.Forms.Label lCurrent;
        private System.Windows.Forms.PictureBox pbItemPicture;
        internal System.Windows.Forms.GroupBox gbKeyboardMode;
        private System.Windows.Forms.RadioButton rbNextItem;
        private System.Windows.Forms.RadioButton rbGrade;
        private System.Windows.Forms.StatusBar sbStatus;
        internal System.Windows.Forms.GroupBox gbWarnings;
        private System.Windows.Forms.Label lWarnings;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Panel pColorPanel;
        private System.Windows.Forms.Label lPart;
        private System.Windows.Forms.Label lPartCaption;
        private System.Windows.Forms.TextBox tbItemsNotDone;
        private System.Windows.Forms.TextBox tbItemsDone;
        private System.Windows.Forms.Timer timer;
        internal System.Windows.Forms.GroupBox gbHistory1;
        private System.Windows.Forms.Label lHistory1;
        internal System.Windows.Forms.GroupBox gbHistory3;
        private System.Windows.Forms.Label lHistory3;
        internal System.Windows.Forms.GroupBox gbHistory2;
        private System.Windows.Forms.Label lHistory2;

        private int accessCode = -1;
        DataSet dsBatchSet = null;
        DataSet dsCopyBatchSet = null;
        private int curOrderCode = 0;
        private int curEntryBatchCode = 0;
        private int curBatchCode = 0;
        private int curItemCode = 0;
        private int curPartId = 0;
        private string curPartName = "";
        private string sFileName = "ColorKeymap.xml";

        private GraderLib.TypeInfo tiChar;
        private bool bJustEntered = false;
        private GraderLib.WorkMode wmMode;
        private string sGrade = "";
        private string sNext = "";
        private System.Windows.Forms.Panel pnlShape;
        private System.Windows.Forms.Label lMeasures;
        private System.Windows.Forms.Label lMeasuresText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvPartData;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label lNewBatchCode;
        private System.Windows.Forms.Label lOldBatchCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lNewItemCode;
        private System.Windows.Forms.Label lOldItemCode;
        private System.Windows.Forms.Button btnMeasureByCP;
        private string sMode = "";
        private System.Windows.Forms.Button btnMeasureByFullSet;
        private System.Windows.Forms.Label lblFullSet;
        private bool bFullAccess;
        private System.Windows.Forms.Button bSaveBatchData;
        private string sFullBatchNumber;

        /// <summary>
        /// ColorForm class constructor
        /// </summary>
        /// <param name="iAccessCode">access code</param>
        public ColorForm(int iAccessCode)
        {
            InitializeComponent();
            this.Text = Service.sProgramTitle + " Color";

            tbItemsDone.Text = "";
            tbItemsNotDone.Text = "";
            lMeasures.Text = "";
            lCurrent.Text = "";

            rbNextItem.Checked = true;
            accessCode = iAccessCode;
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ColorForm));
            this.gbItemsNotDone = new System.Windows.Forms.GroupBox();
            this.tbItemsDone = new System.Windows.Forms.TextBox();
            this.gbItemsDone = new System.Windows.Forms.GroupBox();
            this.tbItemsNotDone = new System.Windows.Forms.TextBox();
            this.pColorPanel = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lOldItemCode = new System.Windows.Forms.Label();
            this.lNewItemCode = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lOldBatchCode = new System.Windows.Forms.Label();
            this.lNewBatchCode = new System.Windows.Forms.Label();
            this.lCurrent = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lMeasures = new System.Windows.Forms.Label();
            this.lMeasuresText = new System.Windows.Forms.Label();
            this.pnlShape = new System.Windows.Forms.Panel();
            this.gbHistory1 = new System.Windows.Forms.GroupBox();
            this.lHistory1 = new System.Windows.Forms.Label();
            this.gbHistory3 = new System.Windows.Forms.GroupBox();
            this.lHistory3 = new System.Windows.Forms.Label();
            this.lPart = new System.Windows.Forms.Label();
            this.lItemCode = new System.Windows.Forms.Label();
            this.lBatchCode = new System.Windows.Forms.Label();
            this.lPartCaption = new System.Windows.Forms.Label();
            this.lItemCaption = new System.Windows.Forms.Label();
            this.lBatchCaption = new System.Windows.Forms.Label();
            this.lItemPictureCaption = new System.Windows.Forms.Label();
            this.lShapeCaption = new System.Windows.Forms.Label();
            this.pbItemPicture = new System.Windows.Forms.PictureBox();
            this.gbHistory2 = new System.Windows.Forms.GroupBox();
            this.lHistory2 = new System.Windows.Forms.Label();
            this.pbShape = new System.Windows.Forms.PictureBox();
            this.lvPartData = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.gbKeyboardMode = new System.Windows.Forms.GroupBox();
            this.rbNextItem = new System.Windows.Forms.RadioButton();
            this.rbGrade = new System.Windows.Forms.RadioButton();
            this.sbStatus = new System.Windows.Forms.StatusBar();
            this.gbWarnings = new System.Windows.Forms.GroupBox();
            this.lWarnings = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.btnMeasureByCP = new System.Windows.Forms.Button();
            this.btnMeasureByFullSet = new System.Windows.Forms.Button();
            this.lblFullSet = new System.Windows.Forms.Label();
            this.bSaveBatchData = new System.Windows.Forms.Button();
            this.gbItemsNotDone.SuspendLayout();
            this.gbItemsDone.SuspendLayout();
            this.pColorPanel.SuspendLayout();
            this.gbHistory1.SuspendLayout();
            this.gbHistory3.SuspendLayout();
            this.gbHistory2.SuspendLayout();
            this.gbKeyboardMode.SuspendLayout();
            this.gbWarnings.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbItemsNotDone
            // 
            this.gbItemsNotDone.Controls.Add(this.tbItemsDone);
            this.gbItemsNotDone.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.gbItemsNotDone.ForeColor = System.Drawing.Color.DimGray;
            this.gbItemsNotDone.Location = new System.Drawing.Point(5, 5);
            this.gbItemsNotDone.Name = "gbItemsNotDone";
            this.gbItemsNotDone.Size = new System.Drawing.Size(545, 100);
            this.gbItemsNotDone.TabIndex = 9;
            this.gbItemsNotDone.TabStop = false;
            this.gbItemsNotDone.Text = "Items done in the batch with grades";
            // 
            // tbItemsDone
            // 
            this.tbItemsDone.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(240)), ((System.Byte)(240)), ((System.Byte)(240)));
            this.tbItemsDone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbItemsDone.Location = new System.Drawing.Point(8, 16);
            this.tbItemsDone.Multiline = true;
            this.tbItemsDone.Name = "tbItemsDone";
            this.tbItemsDone.ReadOnly = true;
            this.tbItemsDone.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbItemsDone.Size = new System.Drawing.Size(528, 72);
            this.tbItemsDone.TabIndex = 2;
            this.tbItemsDone.Text = @"item #########, measur, polish, symmetry, clarity, KM/FF.., metal, setting....
item #########, measur, polish, symmetry, clarity, KM/FF.., metal, setting....
item #########, measur, polish, symmetry, clarity, KM/FF.., metal, setting....
item #########, measur, polish, symmetry, clarity, KM/FF.., metal, setting....
item #########, measur, polish, symmetry, clarity, KM/FF.., metal, setting....";
            this.tbItemsDone.TextChanged += new System.EventHandler(this.tbItemsDone_TextChanged);
            // 
            // gbItemsDone
            // 
            this.gbItemsDone.Controls.Add(this.tbItemsNotDone);
            this.gbItemsDone.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.gbItemsDone.ForeColor = System.Drawing.Color.DimGray;
            this.gbItemsDone.Location = new System.Drawing.Point(555, 5);
            this.gbItemsDone.Name = "gbItemsDone";
            this.gbItemsDone.Size = new System.Drawing.Size(215, 100);
            this.gbItemsDone.TabIndex = 10;
            this.gbItemsDone.TabStop = false;
            this.gbItemsDone.Text = "Items in the batch not done yet";
            // 
            // tbItemsNotDone
            // 
            this.tbItemsNotDone.BackColor = System.Drawing.SystemColors.Control;
            this.tbItemsNotDone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbItemsNotDone.Location = new System.Drawing.Point(10, 16);
            this.tbItemsNotDone.Multiline = true;
            this.tbItemsNotDone.Name = "tbItemsNotDone";
            this.tbItemsNotDone.ReadOnly = true;
            this.tbItemsNotDone.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbItemsNotDone.Size = new System.Drawing.Size(200, 72);
            this.tbItemsNotDone.TabIndex = 0;
            this.tbItemsNotDone.Text = "item #####.#####.###.##\r\nitem #####.#####.###.##\r\nitem #####.#####.###.##\r\nitem #" +
                "####.#####.###.##\r\nitem #####.#####.###.##";
            // 
            // pColorPanel
            // 
            this.pColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pColorPanel.Controls.Add(this.bSaveBatchData);
            this.pColorPanel.Controls.Add(this.label7);
            this.pColorPanel.Controls.Add(this.label6);
            this.pColorPanel.Controls.Add(this.lOldItemCode);
            this.pColorPanel.Controls.Add(this.lNewItemCode);
            this.pColorPanel.Controls.Add(this.label3);
            this.pColorPanel.Controls.Add(this.label2);
            this.pColorPanel.Controls.Add(this.lOldBatchCode);
            this.pColorPanel.Controls.Add(this.lNewBatchCode);
            this.pColorPanel.Controls.Add(this.lCurrent);
            this.pColorPanel.Controls.Add(this.label1);
            this.pColorPanel.Controls.Add(this.lMeasures);
            this.pColorPanel.Controls.Add(this.lMeasuresText);
            this.pColorPanel.Controls.Add(this.pnlShape);
            this.pColorPanel.Controls.Add(this.gbHistory1);
            this.pColorPanel.Controls.Add(this.gbHistory3);
            this.pColorPanel.Controls.Add(this.lPart);
            this.pColorPanel.Controls.Add(this.lItemCode);
            this.pColorPanel.Controls.Add(this.lBatchCode);
            this.pColorPanel.Controls.Add(this.lPartCaption);
            this.pColorPanel.Controls.Add(this.lItemCaption);
            this.pColorPanel.Controls.Add(this.lBatchCaption);
            this.pColorPanel.Controls.Add(this.lItemPictureCaption);
            this.pColorPanel.Controls.Add(this.lShapeCaption);
            this.pColorPanel.Controls.Add(this.pbItemPicture);
            this.pColorPanel.Controls.Add(this.gbHistory2);
            this.pColorPanel.Controls.Add(this.pbShape);
            this.pColorPanel.Controls.Add(this.lvPartData);
            this.pColorPanel.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.pColorPanel.Location = new System.Drawing.Point(3, 105);
            this.pColorPanel.Name = "pColorPanel";
            this.pColorPanel.Size = new System.Drawing.Size(772, 480);
            this.pColorPanel.TabIndex = 11;
            this.pColorPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.pColorPanel_Paint);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(235, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 15);
            this.label7.TabIndex = 32;
            this.label7.Text = "Old #";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(235, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 15);
            this.label6.TabIndex = 31;
            this.label6.Text = "New #";
            // 
            // lOldItemCode
            // 
            this.lOldItemCode.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(240)), ((System.Byte)(240)), ((System.Byte)(240)));
            this.lOldItemCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lOldItemCode.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lOldItemCode.ForeColor = System.Drawing.Color.Blue;
            this.lOldItemCode.Location = new System.Drawing.Point(300, 45);
            this.lOldItemCode.Name = "lOldItemCode";
            this.lOldItemCode.Size = new System.Drawing.Size(160, 15);
            this.lOldItemCode.TabIndex = 30;
            this.lOldItemCode.Text = "#####.#####.###.##";
            // 
            // lNewItemCode
            // 
            this.lNewItemCode.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(240)), ((System.Byte)(240)), ((System.Byte)(240)));
            this.lNewItemCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lNewItemCode.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lNewItemCode.ForeColor = System.Drawing.Color.Blue;
            this.lNewItemCode.Location = new System.Drawing.Point(300, 25);
            this.lNewItemCode.Name = "lNewItemCode";
            this.lNewItemCode.Size = new System.Drawing.Size(160, 15);
            this.lNewItemCode.TabIndex = 29;
            this.lNewItemCode.Text = "#####.#####.###.##";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 28;
            this.label3.Text = "Old Batch";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 27;
            this.label2.Text = "New Batch";
            // 
            // lOldBatchCode
            // 
            this.lOldBatchCode.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(240)), ((System.Byte)(240)), ((System.Byte)(240)));
            this.lOldBatchCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lOldBatchCode.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lOldBatchCode.ForeColor = System.Drawing.Color.Blue;
            this.lOldBatchCode.Location = new System.Drawing.Point(65, 45);
            this.lOldBatchCode.Name = "lOldBatchCode";
            this.lOldBatchCode.Size = new System.Drawing.Size(160, 15);
            this.lOldBatchCode.TabIndex = 26;
            this.lOldBatchCode.Text = "#####.#####.###";
            // 
            // lNewBatchCode
            // 
            this.lNewBatchCode.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(240)), ((System.Byte)(240)), ((System.Byte)(240)));
            this.lNewBatchCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lNewBatchCode.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lNewBatchCode.ForeColor = System.Drawing.Color.Blue;
            this.lNewBatchCode.Location = new System.Drawing.Point(65, 25);
            this.lNewBatchCode.Name = "lNewBatchCode";
            this.lNewBatchCode.Size = new System.Drawing.Size(160, 15);
            this.lNewBatchCode.TabIndex = 25;
            this.lNewBatchCode.Text = "#####.#####.###";
            // 
            // lCurrent
            // 
            this.lCurrent.BackColor = System.Drawing.SystemColors.Control;
            this.lCurrent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lCurrent.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
            this.lCurrent.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lCurrent.Location = new System.Drawing.Point(190, 110);
            this.lCurrent.Name = "lCurrent";
            this.lCurrent.Size = new System.Drawing.Size(285, 360);
            this.lCurrent.TabIndex = 6;
            this.lCurrent.Text = "current item grade";
            this.lCurrent.Click += new System.EventHandler(this.lCurrent_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(190, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 15);
            this.label1.TabIndex = 23;
            this.label1.Text = "Current";
            // 
            // lMeasures
            // 
            this.lMeasures.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(240)), ((System.Byte)(240)), ((System.Byte)(240)));
            this.lMeasures.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lMeasures.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
            this.lMeasures.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lMeasures.Location = new System.Drawing.Point(5, 110);
            this.lMeasures.Name = "lMeasures";
            this.lMeasures.Size = new System.Drawing.Size(185, 360);
            this.lMeasures.TabIndex = 22;
            this.lMeasures.Text = "measur, polish, symmetry, clarity";
            // 
            // lMeasuresText
            // 
            this.lMeasuresText.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
            this.lMeasuresText.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lMeasuresText.Location = new System.Drawing.Point(5, 90);
            this.lMeasuresText.Name = "lMeasuresText";
            this.lMeasuresText.Size = new System.Drawing.Size(55, 15);
            this.lMeasuresText.TabIndex = 21;
            this.lMeasuresText.Text = "Measures";
            // 
            // pnlShape
            // 
            this.pnlShape.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlShape.BackgroundImage")));
            this.pnlShape.Location = new System.Drawing.Point(480, 25);
            this.pnlShape.Name = "pnlShape";
            this.pnlShape.Size = new System.Drawing.Size(130, 125);
            this.pnlShape.TabIndex = 16;
            this.pnlShape.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlShape_Paint);
            // 
            // gbHistory1
            // 
            this.gbHistory1.Controls.Add(this.lHistory1);
            this.gbHistory1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.gbHistory1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gbHistory1.Location = new System.Drawing.Point(515, 170);
            this.gbHistory1.Name = "gbHistory1";
            this.gbHistory1.Size = new System.Drawing.Size(245, 105);
            this.gbHistory1.TabIndex = 15;
            this.gbHistory1.TabStop = false;
            this.gbHistory1.Text = "Previous summary I";
            this.gbHistory1.Enter += new System.EventHandler(this.gbHistory1_Enter);
            // 
            // lHistory1
            // 
            this.lHistory1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
            this.lHistory1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lHistory1.Location = new System.Drawing.Point(10, 15);
            this.lHistory1.Name = "lHistory1";
            this.lHistory1.Size = new System.Drawing.Size(225, 80);
            this.lHistory1.TabIndex = 7;
            this.lHistory1.Text = "color, [...]";
            // 
            // gbHistory3
            // 
            this.gbHistory3.Controls.Add(this.lHistory3);
            this.gbHistory3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.gbHistory3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gbHistory3.Location = new System.Drawing.Point(515, 370);
            this.gbHistory3.Name = "gbHistory3";
            this.gbHistory3.Size = new System.Drawing.Size(245, 75);
            this.gbHistory3.TabIndex = 14;
            this.gbHistory3.TabStop = false;
            this.gbHistory3.Text = "Previous summary III";
            // 
            // lHistory3
            // 
            this.lHistory3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
            this.lHistory3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lHistory3.Location = new System.Drawing.Point(5, 15);
            this.lHistory3.Name = "lHistory3";
            this.lHistory3.Size = new System.Drawing.Size(230, 50);
            this.lHistory3.TabIndex = 7;
            this.lHistory3.Text = "color, [...]";
            this.lHistory3.Click += new System.EventHandler(this.lHistory3_Click);
            // 
            // lPart
            // 
            this.lPart.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(240)), ((System.Byte)(240)), ((System.Byte)(240)));
            this.lPart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lPart.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
            this.lPart.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lPart.Location = new System.Drawing.Point(40, 70);
            this.lPart.Name = "lPart";
            this.lPart.Size = new System.Drawing.Size(385, 15);
            this.lPart.TabIndex = 12;
            this.lPart.Text = "Cener Stone/Side Stones....";
            // 
            // lItemCode
            // 
            this.lItemCode.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(240)), ((System.Byte)(240)), ((System.Byte)(240)));
            this.lItemCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lItemCode.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
            this.lItemCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lItemCode.Location = new System.Drawing.Point(300, 5);
            this.lItemCode.Name = "lItemCode";
            this.lItemCode.Size = new System.Drawing.Size(160, 15);
            this.lItemCode.TabIndex = 11;
            this.lItemCode.Text = "#####.#####.###.##";
            // 
            // lBatchCode
            // 
            this.lBatchCode.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(240)), ((System.Byte)(240)), ((System.Byte)(240)));
            this.lBatchCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lBatchCode.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
            this.lBatchCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lBatchCode.Location = new System.Drawing.Point(65, 5);
            this.lBatchCode.Name = "lBatchCode";
            this.lBatchCode.Size = new System.Drawing.Size(160, 15);
            this.lBatchCode.TabIndex = 10;
            this.lBatchCode.Text = "#####.#####.###";
            this.lBatchCode.Click += new System.EventHandler(this.lBatchCode_Click);
            // 
            // lPartCaption
            // 
            this.lPartCaption.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
            this.lPartCaption.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lPartCaption.Location = new System.Drawing.Point(5, 70);
            this.lPartCaption.Name = "lPartCaption";
            this.lPartCaption.Size = new System.Drawing.Size(35, 15);
            this.lPartCaption.TabIndex = 9;
            this.lPartCaption.Text = "Part";
            // 
            // lItemCaption
            // 
            this.lItemCaption.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
            this.lItemCaption.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lItemCaption.Location = new System.Drawing.Point(235, 5);
            this.lItemCaption.Name = "lItemCaption";
            this.lItemCaption.Size = new System.Drawing.Size(60, 15);
            this.lItemCaption.TabIndex = 8;
            this.lItemCaption.Text = "Current #";
            // 
            // lBatchCaption
            // 
            this.lBatchCaption.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
            this.lBatchCaption.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lBatchCaption.Location = new System.Drawing.Point(0, 5);
            this.lBatchCaption.Name = "lBatchCaption";
            this.lBatchCaption.Size = new System.Drawing.Size(35, 15);
            this.lBatchCaption.TabIndex = 7;
            this.lBatchCaption.Text = "Batch";
            // 
            // lItemPictureCaption
            // 
            this.lItemPictureCaption.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
            this.lItemPictureCaption.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lItemPictureCaption.Location = new System.Drawing.Point(640, 5);
            this.lItemPictureCaption.Name = "lItemPictureCaption";
            this.lItemPictureCaption.Size = new System.Drawing.Size(86, 15);
            this.lItemPictureCaption.TabIndex = 6;
            this.lItemPictureCaption.Text = "Item Picture";
            // 
            // lShapeCaption
            // 
            this.lShapeCaption.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
            this.lShapeCaption.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lShapeCaption.Location = new System.Drawing.Point(515, 5);
            this.lShapeCaption.Name = "lShapeCaption";
            this.lShapeCaption.Size = new System.Drawing.Size(86, 15);
            this.lShapeCaption.TabIndex = 5;
            this.lShapeCaption.Text = "Shape";
            // 
            // pbItemPicture
            // 
            this.pbItemPicture.BackColor = System.Drawing.Color.Transparent;
            this.pbItemPicture.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbItemPicture.BackgroundImage")));
            this.pbItemPicture.Location = new System.Drawing.Point(630, 25);
            this.pbItemPicture.Name = "pbItemPicture";
            this.pbItemPicture.Size = new System.Drawing.Size(125, 125);
            this.pbItemPicture.TabIndex = 3;
            this.pbItemPicture.TabStop = false;
            this.pbItemPicture.Click += new System.EventHandler(this.pbItemPicture_Click);
            this.pbItemPicture.Paint += new System.Windows.Forms.PaintEventHandler(this.pbItemPicture_Paint);
            // 
            // gbHistory2
            // 
            this.gbHistory2.Controls.Add(this.lHistory2);
            this.gbHistory2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.gbHistory2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gbHistory2.Location = new System.Drawing.Point(515, 285);
            this.gbHistory2.Name = "gbHistory2";
            this.gbHistory2.Size = new System.Drawing.Size(245, 75);
            this.gbHistory2.TabIndex = 12;
            this.gbHistory2.TabStop = false;
            this.gbHistory2.Text = "Previous summary II";
            // 
            // lHistory2
            // 
            this.lHistory2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
            this.lHistory2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lHistory2.Location = new System.Drawing.Point(10, 15);
            this.lHistory2.Name = "lHistory2";
            this.lHistory2.Size = new System.Drawing.Size(225, 50);
            this.lHistory2.TabIndex = 7;
            this.lHistory2.Text = "color, [...]";
            // 
            // pbShape
            // 
            this.pbShape.BackColor = System.Drawing.Color.Transparent;
            this.pbShape.Location = new System.Drawing.Point(485, 25);
            this.pbShape.Name = "pbShape";
            this.pbShape.Size = new System.Drawing.Size(125, 125);
            this.pbShape.TabIndex = 4;
            this.pbShape.TabStop = false;
            this.pbShape.Paint += new System.Windows.Forms.PaintEventHandler(this.pbShape_Paint);
            // 
            // lvPartData
            // 
            this.lvPartData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                                                                                         this.columnHeader3,
                                                                                         this.columnHeader1,
                                                                                         this.columnHeader2});
            this.lvPartData.GridLines = true;
            this.lvPartData.Location = new System.Drawing.Point(10, 200);
            this.lvPartData.Name = "lvPartData";
            this.lvPartData.Size = new System.Drawing.Size(330, 220);
            this.lvPartData.TabIndex = 24;
            this.lvPartData.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Item";
            this.columnHeader3.Width = 0;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Measure";
            this.columnHeader1.Width = 160;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Current Values";
            this.columnHeader2.Width = 160;
            // 
            // gbKeyboardMode
            // 
            this.gbKeyboardMode.Controls.Add(this.rbNextItem);
            this.gbKeyboardMode.Controls.Add(this.rbGrade);
            this.gbKeyboardMode.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.gbKeyboardMode.ForeColor = System.Drawing.Color.DimGray;
            this.gbKeyboardMode.Location = new System.Drawing.Point(625, 590);
            this.gbKeyboardMode.Name = "gbKeyboardMode";
            this.gbKeyboardMode.Size = new System.Drawing.Size(145, 70);
            this.gbKeyboardMode.TabIndex = 16;
            this.gbKeyboardMode.TabStop = false;
            this.gbKeyboardMode.Text = "Keyboard Mode ";
            // 
            // rbNextItem
            // 
            this.rbNextItem.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.rbNextItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbNextItem.Location = new System.Drawing.Point(10, 40);
            this.rbNextItem.Name = "rbNextItem";
            this.rbNextItem.Size = new System.Drawing.Size(130, 15);
            this.rbNextItem.TabIndex = 3;
            this.rbNextItem.Text = "Ready for next item";
            this.rbNextItem.CheckedChanged += new System.EventHandler(this.rbNextItem_CheckedChanged);
            // 
            // rbGrade
            // 
            this.rbGrade.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.rbGrade.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbGrade.Location = new System.Drawing.Point(10, 20);
            this.rbGrade.Name = "rbGrade";
            this.rbGrade.Size = new System.Drawing.Size(104, 15);
            this.rbGrade.TabIndex = 0;
            this.rbGrade.Text = "Grade";
            this.rbGrade.CheckedChanged += new System.EventHandler(this.rbGrade_CheckedChanged);
            // 
            // sbStatus
            // 
            this.sbStatus.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
            this.sbStatus.Location = new System.Drawing.Point(0, 656);
            this.sbStatus.Name = "sbStatus";
            this.sbStatus.Size = new System.Drawing.Size(780, 15);
            this.sbStatus.TabIndex = 17;
            // 
            // gbWarnings
            // 
            this.gbWarnings.Controls.Add(this.lWarnings);
            this.gbWarnings.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.gbWarnings.ForeColor = System.Drawing.Color.Maroon;
            this.gbWarnings.Location = new System.Drawing.Point(5, 590);
            this.gbWarnings.Name = "gbWarnings";
            this.gbWarnings.Size = new System.Drawing.Size(525, 70);
            this.gbWarnings.TabIndex = 18;
            this.gbWarnings.TabStop = false;
            this.gbWarnings.Text = "Warnings";
            // 
            // lWarnings
            // 
            this.lWarnings.BackColor = System.Drawing.SystemColors.Control;
            this.lWarnings.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
            this.lWarnings.ForeColor = System.Drawing.Color.Maroon;
            this.lWarnings.Location = new System.Drawing.Point(10, 20);
            this.lWarnings.Name = "lWarnings";
            this.lWarnings.Size = new System.Drawing.Size(510, 40);
            this.lWarnings.TabIndex = 6;
            this.lWarnings.Text = "All kinds of warning or informational messages could be shown here. It could be g" +
                "eneral message, or it could say that calculated weight does not match real weigh" +
                "t.";
            this.lWarnings.Click += new System.EventHandler(this.lWarnings_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // btnMeasureByCP
            // 
            this.btnMeasureByCP.BackColor = System.Drawing.Color.Tan;
            this.btnMeasureByCP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.btnMeasureByCP.Location = new System.Drawing.Point(540, 635);
            this.btnMeasureByCP.Name = "btnMeasureByCP";
            this.btnMeasureByCP.Size = new System.Drawing.Size(75, 20);
            this.btnMeasureByCP.TabIndex = 19;
            this.btnMeasureByCP.Text = "CP Set";
            this.btnMeasureByCP.Click += new System.EventHandler(this.btnMeasureByCP_Click);
            // 
            // btnMeasureByFullSet
            // 
            this.btnMeasureByFullSet.BackColor = System.Drawing.Color.LightGray;
            this.btnMeasureByFullSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.btnMeasureByFullSet.Location = new System.Drawing.Point(540, 635);
            this.btnMeasureByFullSet.Name = "btnMeasureByFullSet";
            this.btnMeasureByFullSet.Size = new System.Drawing.Size(75, 20);
            this.btnMeasureByFullSet.TabIndex = 20;
            this.btnMeasureByFullSet.Text = "Full Set";
            this.btnMeasureByFullSet.Click += new System.EventHandler(this.btnMeasureByFullSet_Click);
            // 
            // lblFullSet
            // 
            this.lblFullSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.lblFullSet.Location = new System.Drawing.Point(540, 610);
            this.lblFullSet.Name = "lblFullSet";
            this.lblFullSet.Size = new System.Drawing.Size(80, 15);
            this.lblFullSet.TabIndex = 21;
            this.lblFullSet.Text = "Data Set:";
            this.lblFullSet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bSaveBatchData
            // 
            this.bSaveBatchData.BackColor = System.Drawing.Color.PeachPuff;
            this.bSaveBatchData.Location = new System.Drawing.Point(485, 450);
            this.bSaveBatchData.Name = "bSaveBatchData";
            this.bSaveBatchData.Size = new System.Drawing.Size(150, 20);
            this.bSaveBatchData.TabIndex = 33;
            this.bSaveBatchData.Text = "Save Batch Manually";
            this.bSaveBatchData.Click += new System.EventHandler(this.bSaveBatchData_Click);
            // 
            // ColorForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(780, 671);
            this.Controls.Add(this.lblFullSet);
            this.Controls.Add(this.btnMeasureByFullSet);
            this.Controls.Add(this.btnMeasureByCP);
            this.Controls.Add(this.gbKeyboardMode);
            this.Controls.Add(this.gbWarnings);
            this.Controls.Add(this.sbStatus);
            this.Controls.Add(this.pColorPanel);
            this.Controls.Add(this.gbItemsDone);
            this.Controls.Add(this.gbItemsNotDone);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "ColorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Color  /Customer Name";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ColorForm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ColorForm_KeyPress);
            this.Load += new System.EventHandler(this.ColorForm_Load);
            this.gbItemsNotDone.ResumeLayout(false);
            this.gbItemsDone.ResumeLayout(false);
            this.pColorPanel.ResumeLayout(false);
            this.gbHistory1.ResumeLayout(false);
            this.gbHistory3.ResumeLayout(false);
            this.gbHistory2.ResumeLayout(false);
            this.gbKeyboardMode.ResumeLayout(false);
            this.gbWarnings.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion


        /// <summary>
        /// Grade radiobutton CheckedChanged event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event argument</param>
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

            lWarnings.Text = "";
            sGrade = "";
        }

        /// <summary>
        /// Ready for next item radiobutton CheckedChanged event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event argument</param>
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
            lWarnings.Text = "";
            curOrderCode = 0;
            curEntryBatchCode = 0;
            curBatchCode = 0;
            curItemCode = 0;
            curPartName = "";
            curPartId = 0;
            pbItemPicture.Image = null;
            pbShape.Image = null;
            lvPartData.Items.Clear();

            sNext = "";
        }

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

            //			{
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

            pbShape.Parent = pnlShape;
            pbShape.Top = 0;
            pbShape.Left = 0;
            //pbItemPicture.Parent = pnlItem;
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
                GraderLib.Codes.Color,
                ref pbShape,
                ref pbItemPicture,
                ref lMeasures,
                GraderLib.Codes.Color,
                ref bFullAccess);
            //if(dsBatchSet != null) bSaveBatchData.Enabled = true;

            //LoadListView(ref lMeasures, ref lCurrent);

            #region old code
            /*
            try
            {
                //GraderLib.ParseCode(dsBatchSet, tbHiddenNextItem, ref curOrderCode, ref curEntryBatchCode, ref curBatchCode, ref curItemCode);
                GraderLib.ParseCode(dsBatchSet, sNext, ref curOrderCode, ref curEntryBatchCode, ref curBatchCode, ref curItemCode);
                if(dsBatchSet != null)
                    GraderLib.IsCurrentBatch(dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, ref rbNextItem, accessCode);

                if(dsBatchSet==null || GraderLib.IsBatchWorkedUp(dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode))
                    dsBatchSet = Service.GetColorBatchInfo(curOrderCode, curEntryBatchCode, curBatchCode);

                GraderLib.UpdateItemValue(ref dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, curItemCode, false);

                GraderLib.UpdateDoneNotDoneItemBoxes(dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, ref tbItemsNotDone, ref tbItemsDone);

                GraderLib.IsBatchItem(dsBatchSet, curItemCode, ref rbNextItem, accessCode);
                GraderLib.IsItemBlocked(dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, curItemCode, ref rbNextItem);

                //GraderLib.UpdateItemHistory(ref dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, curItemCode);
                GraderLib.UpdateItemValue(ref dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, curItemCode, true);
				
                GraderLib.NextPartName(dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, curItemCode, ref curPartName, ref curPartId);
                GraderLib.UpdateCurrentPartInfo(dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, curItemCode, curPartName, curPartId, "tblHistory1", "tblHistory2", "tblHistory3", ref lPart, ref lCurrent, ref lHistory1, ref lHistory2, ref lHistory3, ref pbShape, ref pbItemPicture);
                rbGrade.Checked = true;

                string sItemCode = GraderLib.GetCorrectFullCodeString(curOrderCode, curEntryBatchCode, curBatchCode, curItemCode);
                lBatchCode.Text = sItemCode.Substring(0, sItemCode.Length-3);
                lItemCode.Text = sItemCode;
                //lBatchCode.Text = curOrderCode+"."+curEntryBatchCode+"."+curBatchCode;
                //lItemCode.Text = curOrderCode+"."+curEntryBatchCode+"."+curBatchCode+"."+GraderLib.CorrectItemCode(dsBatchSet, curItemCode);
            }
            catch(Exception eEx)
            {
                lBatchCode.Text = "#####.#####.###";
                lItemCode.Text  = "#####.#####.###.##";
                curOrderCode = 0;
                curEntryBatchCode = 0;
                curBatchCode = 0;
                curItemCode = 0;
                lWarnings.Text = eEx.Message;
            }
            finally
            {
                //tbHiddenNextItem.Text = "";
                sNext = "";
            }*/
            #endregion
        }

        /// <summary>
        /// ColorForm keypress event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event argument</param>
        private void ColorForm_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
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
                //LoadListView(ref lMeasures, ref lCurrent);
                return;
            }

            if (wmMode == GraderLib.WorkMode.GradeEnteringEnumValue)
            {
                //GradeKeyPress(e);
                TextBox tbComment = new TextBox();
                TextBox tbLaser = new TextBox();
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
                    ref pbItemPicture,
                    GraderLib.Codes.Color,
                    ref tbComment,
                    ref tbLaser,
                    -1,
                    ref lMeasures);
                //LoadListView(ref lMeasures, ref lCurrent);
                return;
            }

            if (wmMode == GraderLib.WorkMode.ChoosingMode)
            {
                //ModeKeyPress(e);
                GraderWork.ModeKeyPress(e, sFileName, ref sMode, ref rbNextItem, ref rbGrade, ref lWarnings, ref dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, curItemCode, ref tbItemsNotDone, ref tbItemsDone);
                return;
            }
        }

        /// <summary>
        /// ColorForm keyDown event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event argument</param>
        private void ColorForm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
                #region Choosing NextPart
                if (e.KeyCode == Keys.Enter && wmMode == GraderLib.WorkMode.ChoosingMode && sMode == "" && curPartId != 0 && curItemCode != 0)
                {
                    rbGrade_CheckedChanged(this, EventArgs.Empty);
                    //rbGrade.Checked = true;
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
                        ref pbItemPicture,
                        GraderLib.Codes.Color,
                        true,
                        ref lMeasures);
                }
                #endregion

                #region Closing Batch manually
                if (e.KeyCode == Keys.Enter && wmMode == GraderLib.WorkMode.ChoosingMode && curPartId == 0 && curItemCode == 0)
                {
                    wmMode = GraderLib.WorkMode.NextNotEnteringCode;
                    dsCopyBatchSet = dsBatchSet.Copy();
                    dsCopyBatchSet.DataSetName = "CopyOfMainDataSet";
                    if (dsCopyBatchSet != null) bSaveBatchData.Enabled = true;
                    //GraderLib.UpdateItemValue(ref dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, curItemCode, false);
                    TextBox tbLaserInscription = new TextBox();
                    TextBox tbComment = new TextBox();
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
                        ref pbItemPicture,
                        GraderLib.Codes.Color,
                        ref tbComment,
                        ref tbLaserInscription);
                    bFullAccess = false;
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

                /*#region GradeEnteringEnumValue
                if( wmMode == GraderLib.WorkMode.GradeEnteringEnumValue )
                {
                    //GradeKeyPress(e);
                    TextBox tbComment = new TextBox();
                    TextBox tbLaser = new TextBox();
                    //GraderWork.GradeKeyPress(e, ref wmMode, sFileName, ref dsBatchSet, ref curOrderCode, ref curEntryBatchCode, ref curBatchCode, ref curItemCode, ref curPartId, ref curPartName, ref bJustEntered, ref sGrade, ref sbStatus, ref lWarnings, ref lCurrent, ref lHistory1, ref lHistory2, ref lHistory3, ref lPart, ref tbItemsDone, ref tbItemsNotDone, ref rbNextItem, ref tiChar, ref pbShape, ref pbItemPicture, GraderLib.Codes.Color, ref tbComment, ref tbLaser, -1);

                    return;
                }
                            #endregion

                            #region ChoosingMode
                if( wmMode == GraderLib.WorkMode.ChoosingMode )
                {
                    //ModeKeyPress(e);
                    GraderWork.ModeKeyPress(e, sFileName, ref sMode, ref rbNextItem, ref rbGrade, ref lWarnings);
                    return;
                }
                            #endregion*/
            }
            catch (Exception eEx)
            {
                lWarnings.Text = eEx.Message;
                sGrade = "";
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
            /*if(pbShape.Image==null) 
                return;

            if(pbShape.Image.Size.Height > pbShape.Size.Height || pbShape.Image.Size.Width > pbShape.Size.Width)
                pbShape.SizeMode = PictureBoxSizeMode.StretchImage;
            else
                pbShape.SizeMode = PictureBoxSizeMode.CenterImage;*/
            GraderLib.ShowCorrectPicture(ref pbShape);
            int itop = 0;
            int ileft = 0;
            try
            {
                itop = (pbShape.Parent.Height - pbShape.Height) / 2;
                ileft = (pbShape.Parent.Width - pbShape.Width) / 2;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            pbShape.Top = itop;
            pbShape.Left = ileft;
        }

        /// <summary>
        /// Paint event handler for pbItemPicture
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event argument</param>
        private void pbItemPicture_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            /*if(pbItemPicture.Image == null) 
                return;

            if(pbItemPicture.Image.Size.Height > pbItemPicture.Size.Height || pbItemPicture.Image.Size.Width > pbItemPicture.Size.Width)
                pbItemPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            else
                pbItemPicture.SizeMode = PictureBoxSizeMode.CenterImage;
                */
            GraderLib.ShowCorrectPicture(ref pbItemPicture);
        }

        private void tbItemsDone_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void lBatchCode_Click(object sender, System.EventArgs e)
        {

        }

        private void lCurrent_Click(object sender, System.EventArgs e)
        {

        }

        private void lWarnings_Click(object sender, System.EventArgs e)
        {

        }

        private void pnlShape_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }

        private void pColorPanel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }

        private void pbItemPicture_Click(object sender, System.EventArgs e)
        {

        }

        private void gbHistory1_Enter(object sender, System.EventArgs e)
        {

        }

        private void ColorForm_Load(object sender, System.EventArgs e)
        {

        }

        private void lHistory3_Click(object sender, System.EventArgs e)
        {

        }

        private void LoadListView(ref Label lMeasures, ref Label lCurrent)
        {
            lvPartData.Items.Clear();
            char[] separator = { ',' };
            string[] Title = lMeasures.Text.Split(separator);
            string[] Values = lCurrent.Text.Split(separator);

            if (Title.Length > 0 && Values.Length > 0)
            {
                for (int i = 0; i < Title.Length; ++i)
                {
                    ListViewItem LoadList = new ListViewItem("Item", 0);
                    LoadList.SubItems.Add(Title[i].Trim());
                    LoadList.SubItems.Add(Values[i].Trim());
                    lvPartData.Items.Add(LoadList);
                }
            }
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
                        ref pbItemPicture,
                        GraderLib.Codes.Color,
                        ref tbComment,
                        ref tbLaserInscription);
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
                    TextBox tbLaserInscription = new TextBox();
                    TextBox tbComment = new TextBox();
                    lWarnings.Text = "";
                    GraderWork.UpdateDbBatch(
                        ref dsCopyBatchSet,
                        ref lPart,
                        ref lCurrent,
                        ref lHistory1,
                        ref lHistory2,
                        ref lHistory3,
                        ref tbItemsDone,
                        ref tbItemsNotDone,
                        ref rbNextItem,
                        ref pbShape,
                        ref pbItemPicture,
                        GraderLib.Codes.Color,
                        ref tbComment,
                        ref tbLaserInscription);

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
    }
}