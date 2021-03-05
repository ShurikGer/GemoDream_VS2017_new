using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Xml;
using SerialPortCustomWrapper;
using System.Threading;
using System.IO;

//Working version
namespace gemoDream
{
    /// <summary>
    /// MesureForm class
    /// </summary>
    public class MeasureForm : System.Windows.Forms.Form
    {
        internal System.Windows.Forms.GroupBox gbItemsDone;
        internal System.Windows.Forms.GroupBox gbItemsNotDone;
        private System.Windows.Forms.Label lItemCode;
        private System.Windows.Forms.Label lBatchCode;
        private System.Windows.Forms.Label lItemCaption;
        private System.Windows.Forms.Label lBatchCaption;
        private System.Windows.Forms.Label lItemPictureCaption;
        private System.Windows.Forms.Label lShapeCaption;
        private System.Windows.Forms.PictureBox pbShape;
        private System.Windows.Forms.PictureBox pbItemPicture;
        internal System.Windows.Forms.GroupBox gbKeyboardMode;
        private System.Windows.Forms.RadioButton rbNextItem;
        private System.Windows.Forms.RadioButton rbGrade;
        internal System.Windows.Forms.GroupBox gbWarnings;
        private System.Windows.Forms.Label lWarnings;
        private System.Windows.Forms.StatusBar sbStatus;
        private System.Windows.Forms.Label lPart;
        private System.Windows.Forms.Label lPartCaption;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TextBox tbItemsNotDone;
        private System.Windows.Forms.TextBox tbItemsDone;
        internal System.Windows.Forms.GroupBox gbHistory1;
        private System.Windows.Forms.Label lHistory1;
        internal System.Windows.Forms.GroupBox gbHistory3;
        private System.Windows.Forms.Label lHistory3;
        internal System.Windows.Forms.GroupBox gbHistory2;
        private System.Windows.Forms.Label lHistory2;
        private System.Windows.Forms.Panel pnlShape;
        private System.Windows.Forms.Label lMeasures;
        private System.Windows.Forms.Label lMeasuresText;
        private System.Windows.Forms.Label lCurrent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lNewBatchCode;
        private System.Windows.Forms.Label lOldBatchCode;
        private System.Windows.Forms.Label lNewItemCode;
        private System.Windows.Forms.Label lOldItemCode;
        private System.Windows.Forms.Panel pMeasurePanel;
        private System.Windows.Forms.Button btnMeasureByCP;
        private System.Windows.Forms.Button btnMeasureByFullSet;
        private bool bFullAccess;
        private System.Windows.Forms.Label lblFullSet;
        private string sFullBatchNumber;
        private System.Windows.Forms.Button btnGetWeight;
        private System.Windows.Forms.Label lCaratWeight;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnRefreshWeight;
        private System.Windows.Forms.TextBox tbComPort;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbRate;
        private System.Windows.Forms.ComboBox cmbParity;
        private System.Windows.Forms.GroupBox gbflowControl;
        private System.Windows.Forms.ComboBox cmbStopBits;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button cmd_Start;
        private System.Windows.Forms.Button cmd_Stop;
        private System.Windows.Forms.ComboBox cmbDataBits;
        private System.Windows.Forms.ComboBox cmbComPort;
        private System.Windows.Forms.Label Label11;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bSaveBatchData;
        private Label label13;
        private Label label12;
        private Label lCaratWeight_3digit;
        private SerialPortCustomWrapper.SerialPortCustomWrapper spcw;

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MeasureForm));
            this.gbItemsDone = new System.Windows.Forms.GroupBox();
            this.tbItemsNotDone = new System.Windows.Forms.TextBox();
            this.gbItemsNotDone = new System.Windows.Forms.GroupBox();
            this.tbItemsDone = new System.Windows.Forms.TextBox();
            this.pMeasurePanel = new System.Windows.Forms.Panel();
            this.bSaveBatchData = new System.Windows.Forms.Button();
            this.btnRefreshWeight = new System.Windows.Forms.Button();
            this.lCaratWeight = new System.Windows.Forms.Label();
            this.btnGetWeight = new System.Windows.Forms.Button();
            this.lOldItemCode = new System.Windows.Forms.Label();
            this.lNewItemCode = new System.Windows.Forms.Label();
            this.lOldBatchCode = new System.Windows.Forms.Label();
            this.lNewBatchCode = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lMeasures = new System.Windows.Forms.Label();
            this.lMeasuresText = new System.Windows.Forms.Label();
            this.pnlShape = new System.Windows.Forms.Panel();
            this.gbHistory1 = new System.Windows.Forms.GroupBox();
            this.lHistory1 = new System.Windows.Forms.Label();
            this.gbHistory3 = new System.Windows.Forms.GroupBox();
            this.lHistory3 = new System.Windows.Forms.Label();
            this.gbHistory2 = new System.Windows.Forms.GroupBox();
            this.lHistory2 = new System.Windows.Forms.Label();
            this.lPart = new System.Windows.Forms.Label();
            this.lItemCode = new System.Windows.Forms.Label();
            this.lBatchCode = new System.Windows.Forms.Label();
            this.lPartCaption = new System.Windows.Forms.Label();
            this.lItemCaption = new System.Windows.Forms.Label();
            this.lBatchCaption = new System.Windows.Forms.Label();
            this.lItemPictureCaption = new System.Windows.Forms.Label();
            this.lShapeCaption = new System.Windows.Forms.Label();
            this.pbItemPicture = new System.Windows.Forms.PictureBox();
            this.lCurrent = new System.Windows.Forms.Label();
            this.pbShape = new System.Windows.Forms.PictureBox();
            this.gbKeyboardMode = new System.Windows.Forms.GroupBox();
            this.rbNextItem = new System.Windows.Forms.RadioButton();
            this.rbGrade = new System.Windows.Forms.RadioButton();
            this.gbWarnings = new System.Windows.Forms.GroupBox();
            this.lWarnings = new System.Windows.Forms.Label();
            this.sbStatus = new System.Windows.Forms.StatusBar();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.btnMeasureByCP = new System.Windows.Forms.Button();
            this.btnMeasureByFullSet = new System.Windows.Forms.Button();
            this.lblFullSet = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tbComPort = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.gbflowControl = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbRate = new System.Windows.Forms.ComboBox();
            this.cmbDataBits = new System.Windows.Forms.ComboBox();
            this.cmbParity = new System.Windows.Forms.ComboBox();
            this.cmbStopBits = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmd_Start = new System.Windows.Forms.Button();
            this.cmd_Stop = new System.Windows.Forms.Button();
            this.cmbComPort = new System.Windows.Forms.ComboBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lCaratWeight_3digit = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.gbItemsDone.SuspendLayout();
            this.gbItemsNotDone.SuspendLayout();
            this.pMeasurePanel.SuspendLayout();
            this.gbHistory1.SuspendLayout();
            this.gbHistory3.SuspendLayout();
            this.gbHistory2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbItemPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShape)).BeginInit();
            this.gbKeyboardMode.SuspendLayout();
            this.gbWarnings.SuspendLayout();
            this.gbflowControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbItemsDone
            // 
            this.gbItemsDone.Controls.Add(this.tbItemsNotDone);
            this.gbItemsDone.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gbItemsDone.ForeColor = System.Drawing.Color.DimGray;
            this.gbItemsDone.Location = new System.Drawing.Point(565, 5);
            this.gbItemsDone.Name = "gbItemsDone";
            this.gbItemsDone.Size = new System.Drawing.Size(215, 100);
            this.gbItemsDone.TabIndex = 12;
            this.gbItemsDone.TabStop = false;
            this.gbItemsDone.Text = "Items in the batch not done yet";
            // 
            // tbItemsNotDone
            // 
            this.tbItemsNotDone.BackColor = System.Drawing.SystemColors.Control;
            this.tbItemsNotDone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbItemsNotDone.Location = new System.Drawing.Point(10, 25);
            this.tbItemsNotDone.Multiline = true;
            this.tbItemsNotDone.Name = "tbItemsNotDone";
            this.tbItemsNotDone.ReadOnly = true;
            this.tbItemsNotDone.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbItemsNotDone.Size = new System.Drawing.Size(200, 70);
            this.tbItemsNotDone.TabIndex = 0;
            this.tbItemsNotDone.Text = "item #####.#####.###.##\r\nitem #####.#####.###.##\r\nitem #####.#####.###.##\r\nitem #" +
    "####.#####.###.##\r\nitem #####.#####.###.##";
            // 
            // gbItemsNotDone
            // 
            this.gbItemsNotDone.Controls.Add(this.tbItemsDone);
            this.gbItemsNotDone.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gbItemsNotDone.ForeColor = System.Drawing.Color.DimGray;
            this.gbItemsNotDone.Location = new System.Drawing.Point(5, 5);
            this.gbItemsNotDone.Name = "gbItemsNotDone";
            this.gbItemsNotDone.Size = new System.Drawing.Size(555, 100);
            this.gbItemsNotDone.TabIndex = 11;
            this.gbItemsNotDone.TabStop = false;
            this.gbItemsNotDone.Text = "Items done in the batch with grades";
            // 
            // tbItemsDone
            // 
            this.tbItemsDone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tbItemsDone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbItemsDone.Location = new System.Drawing.Point(8, 16);
            this.tbItemsDone.Multiline = true;
            this.tbItemsDone.Name = "tbItemsDone";
            this.tbItemsDone.ReadOnly = true;
            this.tbItemsDone.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbItemsDone.Size = new System.Drawing.Size(528, 72);
            this.tbItemsDone.TabIndex = 2;
            this.tbItemsDone.Text = resources.GetString("tbItemsDone.Text");
            // 
            // pMeasurePanel
            // 
            this.pMeasurePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pMeasurePanel.Controls.Add(this.label13);
            this.pMeasurePanel.Controls.Add(this.label12);
            this.pMeasurePanel.Controls.Add(this.lCaratWeight_3digit);
            this.pMeasurePanel.Controls.Add(this.bSaveBatchData);
            this.pMeasurePanel.Controls.Add(this.btnRefreshWeight);
            this.pMeasurePanel.Controls.Add(this.lCaratWeight);
            this.pMeasurePanel.Controls.Add(this.btnGetWeight);
            this.pMeasurePanel.Controls.Add(this.lOldItemCode);
            this.pMeasurePanel.Controls.Add(this.lNewItemCode);
            this.pMeasurePanel.Controls.Add(this.lOldBatchCode);
            this.pMeasurePanel.Controls.Add(this.lNewBatchCode);
            this.pMeasurePanel.Controls.Add(this.label5);
            this.pMeasurePanel.Controls.Add(this.label4);
            this.pMeasurePanel.Controls.Add(this.label3);
            this.pMeasurePanel.Controls.Add(this.label2);
            this.pMeasurePanel.Controls.Add(this.label1);
            this.pMeasurePanel.Controls.Add(this.lMeasures);
            this.pMeasurePanel.Controls.Add(this.lMeasuresText);
            this.pMeasurePanel.Controls.Add(this.pnlShape);
            this.pMeasurePanel.Controls.Add(this.gbHistory1);
            this.pMeasurePanel.Controls.Add(this.gbHistory3);
            this.pMeasurePanel.Controls.Add(this.gbHistory2);
            this.pMeasurePanel.Controls.Add(this.lPart);
            this.pMeasurePanel.Controls.Add(this.lItemCode);
            this.pMeasurePanel.Controls.Add(this.lBatchCode);
            this.pMeasurePanel.Controls.Add(this.lPartCaption);
            this.pMeasurePanel.Controls.Add(this.lItemCaption);
            this.pMeasurePanel.Controls.Add(this.lBatchCaption);
            this.pMeasurePanel.Controls.Add(this.lItemPictureCaption);
            this.pMeasurePanel.Controls.Add(this.lShapeCaption);
            this.pMeasurePanel.Controls.Add(this.pbItemPicture);
            this.pMeasurePanel.Controls.Add(this.lCurrent);
            this.pMeasurePanel.Controls.Add(this.pbShape);
            this.pMeasurePanel.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.pMeasurePanel.Location = new System.Drawing.Point(3, 105);
            this.pMeasurePanel.Name = "pMeasurePanel";
            this.pMeasurePanel.Size = new System.Drawing.Size(772, 480);
            this.pMeasurePanel.TabIndex = 13;
            this.pMeasurePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.pMeasurePanel_Paint);
            // 
            // bSaveBatchData
            // 
            this.bSaveBatchData.BackColor = System.Drawing.Color.PeachPuff;
            this.bSaveBatchData.Location = new System.Drawing.Point(455, 450);
            this.bSaveBatchData.Name = "bSaveBatchData";
            this.bSaveBatchData.Size = new System.Drawing.Size(125, 20);
            this.bSaveBatchData.TabIndex = 39;
            this.bSaveBatchData.Text = "Save Batch Manually";
            this.bSaveBatchData.UseVisualStyleBackColor = false;
            this.bSaveBatchData.Click += new System.EventHandler(this.bSaveBatchData_Click);
            // 
            // btnRefreshWeight
            // 
            this.btnRefreshWeight.Location = new System.Drawing.Point(670, 450);
            this.btnRefreshWeight.Name = "btnRefreshWeight";
            this.btnRefreshWeight.Size = new System.Drawing.Size(95, 20);
            this.btnRefreshWeight.TabIndex = 38;
            this.btnRefreshWeight.Text = "Refresh Weight";
            this.btnRefreshWeight.Click += new System.EventHandler(this.btnRefreshWeight_Click);
            // 
            // lCaratWeight
            // 
            this.lCaratWeight.BackColor = System.Drawing.Color.White;
            this.lCaratWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lCaratWeight.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCaratWeight.ForeColor = System.Drawing.Color.Maroon;
            this.lCaratWeight.Location = new System.Drawing.Point(695, 425);
            this.lCaratWeight.Name = "lCaratWeight";
            this.lCaratWeight.Size = new System.Drawing.Size(70, 20);
            this.lCaratWeight.TabIndex = 37;
            this.lCaratWeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnGetWeight
            // 
            this.btnGetWeight.Location = new System.Drawing.Point(590, 450);
            this.btnGetWeight.Name = "btnGetWeight";
            this.btnGetWeight.Size = new System.Drawing.Size(75, 20);
            this.btnGetWeight.TabIndex = 35;
            this.btnGetWeight.Text = "Get Weight";
            this.btnGetWeight.Click += new System.EventHandler(this.btnGetWeight_Click);
            // 
            // lOldItemCode
            // 
            this.lOldItemCode.BackColor = System.Drawing.SystemColors.Window;
            this.lOldItemCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lOldItemCode.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lOldItemCode.ForeColor = System.Drawing.Color.Blue;
            this.lOldItemCode.Location = new System.Drawing.Point(300, 42);
            this.lOldItemCode.Name = "lOldItemCode";
            this.lOldItemCode.Size = new System.Drawing.Size(160, 15);
            this.lOldItemCode.TabIndex = 33;
            this.lOldItemCode.Text = "#####.#####.###.##";
            // 
            // lNewItemCode
            // 
            this.lNewItemCode.BackColor = System.Drawing.SystemColors.Window;
            this.lNewItemCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lNewItemCode.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lNewItemCode.ForeColor = System.Drawing.Color.Blue;
            this.lNewItemCode.Location = new System.Drawing.Point(300, 22);
            this.lNewItemCode.Name = "lNewItemCode";
            this.lNewItemCode.Size = new System.Drawing.Size(160, 15);
            this.lNewItemCode.TabIndex = 32;
            this.lNewItemCode.Text = "#####.#####.###.##";
            // 
            // lOldBatchCode
            // 
            this.lOldBatchCode.BackColor = System.Drawing.SystemColors.Window;
            this.lOldBatchCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lOldBatchCode.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lOldBatchCode.ForeColor = System.Drawing.Color.Blue;
            this.lOldBatchCode.Location = new System.Drawing.Point(65, 42);
            this.lOldBatchCode.Name = "lOldBatchCode";
            this.lOldBatchCode.Size = new System.Drawing.Size(160, 15);
            this.lOldBatchCode.TabIndex = 31;
            this.lOldBatchCode.Text = "#####.#####.###";
            // 
            // lNewBatchCode
            // 
            this.lNewBatchCode.BackColor = System.Drawing.SystemColors.Window;
            this.lNewBatchCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lNewBatchCode.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lNewBatchCode.ForeColor = System.Drawing.Color.Blue;
            this.lNewBatchCode.Location = new System.Drawing.Point(65, 22);
            this.lNewBatchCode.Name = "lNewBatchCode";
            this.lNewBatchCode.Size = new System.Drawing.Size(160, 15);
            this.lNewBatchCode.TabIndex = 30;
            this.lNewBatchCode.Text = "#####.#####.###";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(235, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 15);
            this.label5.TabIndex = 29;
            this.label5.Text = "Old #";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(235, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 28;
            this.label4.Text = "New #";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(5, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 27;
            this.label3.Text = "Old Batch";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(5, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 26;
            this.label2.Text = "New Batch";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(190, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 25;
            this.label1.Text = "Data";
            // 
            // lMeasures
            // 
            this.lMeasures.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lMeasures.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lMeasures.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.lMeasures.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lMeasures.Location = new System.Drawing.Point(5, 102);
            this.lMeasures.Name = "lMeasures";
            this.lMeasures.Size = new System.Drawing.Size(180, 370);
            this.lMeasures.TabIndex = 24;
            this.lMeasures.Text = "measur, polish, symmetry, clarity";
            // 
            // lMeasuresText
            // 
            this.lMeasuresText.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.lMeasuresText.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lMeasuresText.Location = new System.Drawing.Point(5, 85);
            this.lMeasuresText.Name = "lMeasuresText";
            this.lMeasuresText.Size = new System.Drawing.Size(55, 15);
            this.lMeasuresText.TabIndex = 23;
            this.lMeasuresText.Text = "Measures";
            // 
            // pnlShape
            // 
            this.pnlShape.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlShape.BackgroundImage")));
            this.pnlShape.Location = new System.Drawing.Point(485, 25);
            this.pnlShape.Name = "pnlShape";
            this.pnlShape.Size = new System.Drawing.Size(125, 125);
            this.pnlShape.TabIndex = 19;
            // 
            // gbHistory1
            // 
            this.gbHistory1.Controls.Add(this.lHistory1);
            this.gbHistory1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gbHistory1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gbHistory1.Location = new System.Drawing.Point(455, 160);
            this.gbHistory1.Name = "gbHistory1";
            this.gbHistory1.Size = new System.Drawing.Size(310, 95);
            this.gbHistory1.TabIndex = 18;
            this.gbHistory1.TabStop = false;
            this.gbHistory1.Text = "Previous summary I";
            // 
            // lHistory1
            // 
            this.lHistory1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.lHistory1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lHistory1.Location = new System.Drawing.Point(10, 15);
            this.lHistory1.Name = "lHistory1";
            this.lHistory1.Size = new System.Drawing.Size(295, 75);
            this.lHistory1.TabIndex = 7;
            this.lHistory1.Text = "shape, weight, [...]";
            // 
            // gbHistory3
            // 
            this.gbHistory3.Controls.Add(this.lHistory3);
            this.gbHistory3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gbHistory3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gbHistory3.Location = new System.Drawing.Point(460, 345);
            this.gbHistory3.Name = "gbHistory3";
            this.gbHistory3.Size = new System.Drawing.Size(305, 75);
            this.gbHistory3.TabIndex = 17;
            this.gbHistory3.TabStop = false;
            this.gbHistory3.Text = "Previous summary III";
            // 
            // lHistory3
            // 
            this.lHistory3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.lHistory3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lHistory3.Location = new System.Drawing.Point(5, 15);
            this.lHistory3.Name = "lHistory3";
            this.lHistory3.Size = new System.Drawing.Size(295, 50);
            this.lHistory3.TabIndex = 7;
            this.lHistory3.Text = "shape, weight, [...]";
            // 
            // gbHistory2
            // 
            this.gbHistory2.Controls.Add(this.lHistory2);
            this.gbHistory2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gbHistory2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gbHistory2.Location = new System.Drawing.Point(455, 260);
            this.gbHistory2.Name = "gbHistory2";
            this.gbHistory2.Size = new System.Drawing.Size(310, 75);
            this.gbHistory2.TabIndex = 16;
            this.gbHistory2.TabStop = false;
            this.gbHistory2.Text = "Previous summary II";
            // 
            // lHistory2
            // 
            this.lHistory2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.lHistory2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lHistory2.Location = new System.Drawing.Point(5, 15);
            this.lHistory2.Name = "lHistory2";
            this.lHistory2.Size = new System.Drawing.Size(300, 50);
            this.lHistory2.TabIndex = 7;
            this.lHistory2.Text = "shape, weight, [...]";
            // 
            // lPart
            // 
            this.lPart.BackColor = System.Drawing.SystemColors.Window;
            this.lPart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lPart.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.lPart.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lPart.Location = new System.Drawing.Point(40, 65);
            this.lPart.Name = "lPart";
            this.lPart.Size = new System.Drawing.Size(385, 15);
            this.lPart.TabIndex = 12;
            this.lPart.Text = "Cener Stone/Side Stones....";
            this.lPart.TextChanged += new System.EventHandler(this.lPart_TextChanged);
            // 
            // lItemCode
            // 
            this.lItemCode.BackColor = System.Drawing.SystemColors.Window;
            this.lItemCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lItemCode.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.lItemCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lItemCode.Location = new System.Drawing.Point(300, 2);
            this.lItemCode.Name = "lItemCode";
            this.lItemCode.Size = new System.Drawing.Size(160, 15);
            this.lItemCode.TabIndex = 11;
            this.lItemCode.Text = "#####.#####.###.##";
            // 
            // lBatchCode
            // 
            this.lBatchCode.BackColor = System.Drawing.SystemColors.Window;
            this.lBatchCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lBatchCode.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.lBatchCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lBatchCode.Location = new System.Drawing.Point(65, 2);
            this.lBatchCode.Name = "lBatchCode";
            this.lBatchCode.Size = new System.Drawing.Size(160, 15);
            this.lBatchCode.TabIndex = 10;
            this.lBatchCode.Text = "#####.#####.###";
            // 
            // lPartCaption
            // 
            this.lPartCaption.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.lPartCaption.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lPartCaption.Location = new System.Drawing.Point(5, 65);
            this.lPartCaption.Name = "lPartCaption";
            this.lPartCaption.Size = new System.Drawing.Size(30, 15);
            this.lPartCaption.TabIndex = 9;
            this.lPartCaption.Text = "Part";
            // 
            // lItemCaption
            // 
            this.lItemCaption.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.lItemCaption.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lItemCaption.Location = new System.Drawing.Point(235, 2);
            this.lItemCaption.Name = "lItemCaption";
            this.lItemCaption.Size = new System.Drawing.Size(55, 15);
            this.lItemCaption.TabIndex = 8;
            this.lItemCaption.Text = "Current #";
            // 
            // lBatchCaption
            // 
            this.lBatchCaption.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.lBatchCaption.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lBatchCaption.Location = new System.Drawing.Point(5, 2);
            this.lBatchCaption.Name = "lBatchCaption";
            this.lBatchCaption.Size = new System.Drawing.Size(35, 15);
            this.lBatchCaption.TabIndex = 7;
            this.lBatchCaption.Text = "Batch";
            // 
            // lItemPictureCaption
            // 
            this.lItemPictureCaption.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.lItemPictureCaption.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lItemPictureCaption.Location = new System.Drawing.Point(640, 5);
            this.lItemPictureCaption.Name = "lItemPictureCaption";
            this.lItemPictureCaption.Size = new System.Drawing.Size(86, 15);
            this.lItemPictureCaption.TabIndex = 6;
            this.lItemPictureCaption.Text = "Item Picture";
            // 
            // lShapeCaption
            // 
            this.lShapeCaption.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.lShapeCaption.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lShapeCaption.Location = new System.Drawing.Point(480, 5);
            this.lShapeCaption.Name = "lShapeCaption";
            this.lShapeCaption.Size = new System.Drawing.Size(86, 15);
            this.lShapeCaption.TabIndex = 5;
            this.lShapeCaption.Text = "Shape";
            // 
            // pbItemPicture
            // 
            this.pbItemPicture.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbItemPicture.BackgroundImage")));
            this.pbItemPicture.Location = new System.Drawing.Point(630, 25);
            this.pbItemPicture.Name = "pbItemPicture";
            this.pbItemPicture.Size = new System.Drawing.Size(125, 125);
            this.pbItemPicture.TabIndex = 3;
            this.pbItemPicture.TabStop = false;
            this.pbItemPicture.Paint += new System.Windows.Forms.PaintEventHandler(this.pbItemPicture_Paint);
            // 
            // lCurrent
            // 
            this.lCurrent.BackColor = System.Drawing.SystemColors.Control;
            this.lCurrent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lCurrent.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.lCurrent.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lCurrent.Location = new System.Drawing.Point(185, 102);
            this.lCurrent.Name = "lCurrent";
            this.lCurrent.Size = new System.Drawing.Size(255, 370);
            this.lCurrent.TabIndex = 6;
            this.lCurrent.Text = "current item grade";
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
            // gbKeyboardMode
            // 
            this.gbKeyboardMode.Controls.Add(this.rbNextItem);
            this.gbKeyboardMode.Controls.Add(this.rbGrade);
            this.gbKeyboardMode.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gbKeyboardMode.ForeColor = System.Drawing.Color.DimGray;
            this.gbKeyboardMode.Location = new System.Drawing.Point(635, 585);
            this.gbKeyboardMode.Name = "gbKeyboardMode";
            this.gbKeyboardMode.Size = new System.Drawing.Size(140, 70);
            this.gbKeyboardMode.TabIndex = 17;
            this.gbKeyboardMode.TabStop = false;
            this.gbKeyboardMode.Text = "Keyboard Mode ";
            // 
            // rbNextItem
            // 
            this.rbNextItem.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.rbNextItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbNextItem.Location = new System.Drawing.Point(10, 40);
            this.rbNextItem.Name = "rbNextItem";
            this.rbNextItem.Size = new System.Drawing.Size(125, 15);
            this.rbNextItem.TabIndex = 3;
            this.rbNextItem.Text = "Ready for next item";
            this.rbNextItem.CheckedChanged += new System.EventHandler(this.rbNextItem_CheckedChanged);
            // 
            // rbGrade
            // 
            this.rbGrade.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.rbGrade.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbGrade.Location = new System.Drawing.Point(10, 20);
            this.rbGrade.Name = "rbGrade";
            this.rbGrade.Size = new System.Drawing.Size(104, 15);
            this.rbGrade.TabIndex = 0;
            this.rbGrade.Text = "Grade";
            this.rbGrade.CheckedChanged += new System.EventHandler(this.rbGrade_CheckedChanged);
            // 
            // gbWarnings
            // 
            this.gbWarnings.Controls.Add(this.lWarnings);
            this.gbWarnings.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gbWarnings.ForeColor = System.Drawing.Color.Maroon;
            this.gbWarnings.Location = new System.Drawing.Point(5, 585);
            this.gbWarnings.Name = "gbWarnings";
            this.gbWarnings.Size = new System.Drawing.Size(525, 70);
            this.gbWarnings.TabIndex = 16;
            this.gbWarnings.TabStop = false;
            this.gbWarnings.Text = "Warnings";
            // 
            // lWarnings
            // 
            this.lWarnings.BackColor = System.Drawing.SystemColors.Control;
            this.lWarnings.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lWarnings.ForeColor = System.Drawing.Color.Maroon;
            this.lWarnings.Location = new System.Drawing.Point(10, 20);
            this.lWarnings.Name = "lWarnings";
            this.lWarnings.Size = new System.Drawing.Size(510, 45);
            this.lWarnings.TabIndex = 6;
            this.lWarnings.Text = "All kinds of warning or informational messages could be shown here. It could be g" +
    "eneral message, or it could say that calculated weight does not match real weigh" +
    "t.";
            // 
            // sbStatus
            // 
            this.sbStatus.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.sbStatus.Location = new System.Drawing.Point(0, 656);
            this.sbStatus.Name = "sbStatus";
            this.sbStatus.Size = new System.Drawing.Size(985, 15);
            this.sbStatus.TabIndex = 18;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // btnMeasureByCP
            // 
            this.btnMeasureByCP.BackColor = System.Drawing.Color.Tan;
            this.btnMeasureByCP.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnMeasureByCP.Location = new System.Drawing.Point(555, 610);
            this.btnMeasureByCP.Name = "btnMeasureByCP";
            this.btnMeasureByCP.Size = new System.Drawing.Size(75, 20);
            this.btnMeasureByCP.TabIndex = 19;
            this.btnMeasureByCP.Text = "CP Set";
            this.btnMeasureByCP.UseVisualStyleBackColor = false;
            this.btnMeasureByCP.Click += new System.EventHandler(this.btnMeasureByCP_Click);
            // 
            // btnMeasureByFullSet
            // 
            this.btnMeasureByFullSet.BackColor = System.Drawing.Color.LightGray;
            this.btnMeasureByFullSet.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnMeasureByFullSet.Location = new System.Drawing.Point(555, 610);
            this.btnMeasureByFullSet.Name = "btnMeasureByFullSet";
            this.btnMeasureByFullSet.Size = new System.Drawing.Size(75, 20);
            this.btnMeasureByFullSet.TabIndex = 20;
            this.btnMeasureByFullSet.Text = "Full Set";
            this.btnMeasureByFullSet.UseVisualStyleBackColor = false;
            this.btnMeasureByFullSet.Click += new System.EventHandler(this.btnMeasureByFullSet_Click);
            // 
            // lblFullSet
            // 
            this.lblFullSet.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFullSet.Location = new System.Drawing.Point(565, 585);
            this.lblFullSet.Name = "lblFullSet";
            this.lblFullSet.Size = new System.Drawing.Size(65, 20);
            this.lblFullSet.TabIndex = 21;
            this.lblFullSet.Text = "Data Set:";
            this.lblFullSet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tbComPort
            // 
            this.tbComPort.BackColor = System.Drawing.Color.White;
            this.tbComPort.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbComPort.Location = new System.Drawing.Point(790, 50);
            this.tbComPort.Multiline = true;
            this.tbComPort.Name = "tbComPort";
            this.tbComPort.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbComPort.Size = new System.Drawing.Size(190, 410);
            this.tbComPort.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(800, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(165, 20);
            this.label6.TabIndex = 23;
            this.label6.Text = "Com.Port Result";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbflowControl
            // 
            this.gbflowControl.Controls.Add(this.radioButton2);
            this.gbflowControl.Controls.Add(this.radioButton1);
            this.gbflowControl.Location = new System.Drawing.Point(815, 610);
            this.gbflowControl.Name = "gbflowControl";
            this.gbflowControl.Size = new System.Drawing.Size(140, 50);
            this.gbflowControl.TabIndex = 27;
            this.gbflowControl.TabStop = false;
            this.gbflowControl.Text = "Flow Control";
            this.gbflowControl.Enter += new System.EventHandler(this.gbflowControl_Enter);
            // 
            // radioButton2
            // 
            this.radioButton2.Location = new System.Drawing.Point(85, 25);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(50, 20);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "CTS";
            // 
            // radioButton1
            // 
            this.radioButton1.Location = new System.Drawing.Point(10, 25);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(70, 20);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "Xon/Xoff";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(800, 510);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 15);
            this.label7.TabIndex = 28;
            this.label7.Text = "Bit Rate";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(800, 535);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 15);
            this.label8.TabIndex = 29;
            this.label8.Text = "Data Bits";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(800, 555);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 15);
            this.label9.TabIndex = 30;
            this.label9.Text = "Parity";
            // 
            // cmbRate
            // 
            this.cmbRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRate.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600"});
            this.cmbRate.Location = new System.Drawing.Point(875, 505);
            this.cmbRate.Name = "cmbRate";
            this.cmbRate.Size = new System.Drawing.Size(95, 20);
            this.cmbRate.TabIndex = 31;
            // 
            // cmbDataBits
            // 
            this.cmbDataBits.Items.AddRange(new object[] {
            "7",
            "8"});
            this.cmbDataBits.Location = new System.Drawing.Point(875, 530);
            this.cmbDataBits.Name = "cmbDataBits";
            this.cmbDataBits.Size = new System.Drawing.Size(95, 20);
            this.cmbDataBits.TabIndex = 32;
            // 
            // cmbParity
            // 
            this.cmbParity.Items.AddRange(new object[] {
            "odd",
            "even",
            "none"});
            this.cmbParity.Location = new System.Drawing.Point(875, 555);
            this.cmbParity.Name = "cmbParity";
            this.cmbParity.Size = new System.Drawing.Size(95, 20);
            this.cmbParity.TabIndex = 33;
            // 
            // cmbStopBits
            // 
            this.cmbStopBits.Items.AddRange(new object[] {
            "2",
            "1"});
            this.cmbStopBits.Location = new System.Drawing.Point(875, 580);
            this.cmbStopBits.Name = "cmbStopBits";
            this.cmbStopBits.Size = new System.Drawing.Size(95, 20);
            this.cmbStopBits.TabIndex = 34;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(800, 580);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 20);
            this.label10.TabIndex = 35;
            this.label10.Text = "Stop Bits";
            // 
            // cmd_Start
            // 
            this.cmd_Start.Enabled = false;
            this.cmd_Start.Location = new System.Drawing.Point(795, 25);
            this.cmd_Start.Name = "cmd_Start";
            this.cmd_Start.Size = new System.Drawing.Size(65, 20);
            this.cmd_Start.TabIndex = 36;
            this.cmd_Start.Text = "Start";
            this.cmd_Start.Click += new System.EventHandler(this.cmd_Start_Click);
            // 
            // cmd_Stop
            // 
            this.cmd_Stop.Enabled = false;
            this.cmd_Stop.Location = new System.Drawing.Point(885, 25);
            this.cmd_Stop.Name = "cmd_Stop";
            this.cmd_Stop.Size = new System.Drawing.Size(55, 20);
            this.cmd_Stop.TabIndex = 37;
            this.cmd_Stop.Text = "Stop";
            this.cmd_Stop.Click += new System.EventHandler(this.cmd_Stop_Click);
            // 
            // cmbComPort
            // 
            this.cmbComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComPort.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cmbComPort.Location = new System.Drawing.Point(875, 480);
            this.cmbComPort.Name = "cmbComPort";
            this.cmbComPort.Size = new System.Drawing.Size(95, 20);
            this.cmbComPort.TabIndex = 38;
            // 
            // Label11
            // 
            this.Label11.Location = new System.Drawing.Point(800, 485);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(65, 15);
            this.Label11.TabIndex = 39;
            this.Label11.Text = "Com Port";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(785, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 660);
            this.panel1.TabIndex = 40;
            // 
            // lCaratWeight_3digit
            // 
            this.lCaratWeight_3digit.BackColor = System.Drawing.Color.White;
            this.lCaratWeight_3digit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lCaratWeight_3digit.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCaratWeight_3digit.ForeColor = System.Drawing.Color.Maroon;
            this.lCaratWeight_3digit.Location = new System.Drawing.Point(510, 425);
            this.lCaratWeight_3digit.Name = "lCaratWeight_3digit";
            this.lCaratWeight_3digit.Size = new System.Drawing.Size(70, 20);
            this.lCaratWeight_3digit.TabIndex = 40;
            this.lCaratWeight_3digit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(446, 428);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 13);
            this.label12.TabIndex = 41;
            this.label12.Text = "3-digit->";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(628, 428);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 13);
            this.label13.TabIndex = 42;
            this.label13.Text = "Regular->";
            // 
            // MeasureForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.ClientSize = new System.Drawing.Size(985, 671);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Label11);
            this.Controls.Add(this.cmbComPort);
            this.Controls.Add(this.cmd_Stop);
            this.Controls.Add(this.cmd_Start);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbStopBits);
            this.Controls.Add(this.cmbParity);
            this.Controls.Add(this.cmbDataBits);
            this.Controls.Add(this.cmbRate);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.gbflowControl);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbComPort);
            this.Controls.Add(this.lblFullSet);
            this.Controls.Add(this.btnMeasureByFullSet);
            this.Controls.Add(this.btnMeasureByCP);
            this.Controls.Add(this.sbStatus);
            this.Controls.Add(this.gbKeyboardMode);
            this.Controls.Add(this.gbWarnings);
            this.Controls.Add(this.pMeasurePanel);
            this.Controls.Add(this.gbItemsDone);
            this.Controls.Add(this.gbItemsNotDone);
            this.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MeasureForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Measure";
            this.Closed += new System.EventHandler(this.MeasureForm_Closed);
            this.Load += new System.EventHandler(this.MeasureForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MeasureForm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MeasureForm_KeyPress);
            this.gbItemsDone.ResumeLayout(false);
            this.gbItemsDone.PerformLayout();
            this.gbItemsNotDone.ResumeLayout(false);
            this.gbItemsNotDone.PerformLayout();
            this.pMeasurePanel.ResumeLayout(false);
            this.pMeasurePanel.PerformLayout();
            this.gbHistory1.ResumeLayout(false);
            this.gbHistory3.ResumeLayout(false);
            this.gbHistory2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbItemPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShape)).EndInit();
            this.gbKeyboardMode.ResumeLayout(false);
            this.gbWarnings.ResumeLayout(false);
            this.gbflowControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.ComponentModel.IContainer components;

        /// Access code for Measure form
        private int accessCode = -1;
        /// order code of the current item
        private int curOrderCode = 0;
        /// entrry batch code of the current item
        private int curEntryBatchCode = 0;
        /// batch code of the current item
        private int curBatchCode = 0;
        /// item code of the current item
        private int curItemCode = 0;
        /// part name of the current item
        private string curPartName = "";
        /// current part identifier
        private int curPartId = 0;
        /// dataset with full information about item
        private DataSet dsBatchSet = null;
        private DataSet dsCopyBatchSet = null;
        /// keymap file for Measure form
        private string sFileName = "MeasureKeymap.xml";

        private string sComPortSetFleName = "ComPort.xml";

        private static XmlDocument xmlComPort;

        //Service.sAppDir + System.IO.Path.DirectorySeparatorChar + 

        private GraderLib.TypeInfo tiChar;
        private bool bJustEntered = false;
        private GraderLib.WorkMode wmMode;
        private string sGrade = "";
        private string sNext = "";
        private string sMode = "";

        private int iTestMode = 0;

        //        private bool bUseComPort = true;
        //        ThreadStart job; //= new ThreadStart(Digi);
        //        Thread thread;// = new Thread(job);

        /// <summary>
        /// MeasureForm class constructor
        /// </summary>
        public MeasureForm(int iAccessCode)
        {
            InitializeComponent();
            this.Text = Service.sProgramTitle + " Measure";

            tbItemsDone.Text = "";
            tbItemsNotDone.Text = "";
            lMeasures.Text = "";

            rbNextItem.Checked = true;
            accessCode = iAccessCode;
            bFullAccess = false;
            lblFullSet.Text = "CP Set";

            btnMeasureByFullSet.Enabled = true;
            btnMeasureByCP.Enabled = false;
            btnMeasureByCP.Visible = false;
            sFullBatchNumber = "";
            lCaratWeight.Text = "";
            lCaratWeight_3digit.Text = "";

            cmbRate.SelectedIndex = 0;
            cmbComPort.SelectedIndex = 0;
            cmbDataBits.SelectedIndex = 0;
            cmbParity.SelectedIndex = 0;
            cmbStopBits.SelectedIndex = 0;
            radioButton2.Checked = true;

            sComPortSetFleName = Service.sAppDir + System.IO.Path.DirectorySeparatorChar + sComPortSetFleName;
            xmlComPort = new XmlDocument();

            try
            {
#if DEBUG
#else
				if (File.Exists(sComPortSetFleName))
                {
                    xmlComPort.Load(sComPortSetFleName);
                    spcw = new SerialPortCustomWrapper.SerialPortCustomWrapper(xmlComPort);
                }
                else spcw = new SerialPortCustomWrapper.SerialPortCustomWrapper(true);
                //spcw.PortOpen = true;
                spcw.dblResult = 0;
                spcw.PortOpen = false;
                spcw.iComPortSource = 0;
#endif

                //			try
                //			{
                //				XmlNode xnNode = Client.GetXmlElement("ScaleTimer");
                //				this.timer1.Interval = Convert.ToInt32(xnNode.InnerText.ToString());
                //			}
            }
            catch { }
            {
                lCaratWeight.Visible = false;
                lCaratWeight_3digit.Visible = false;
                label12.Visible = false;
                label13.Visible = false;
                btnGetWeight.Visible = false;
                btnRefreshWeight.Visible = false;
                cmd_Start.Enabled = false;
                cmd_Stop.Enabled = false;
                bSaveBatchData.Enabled = false;
            }
            //			catch(Exception ex)
            //            {
            //                cmd_Start.Enabled = false;
            //                cmd_Stop.Enabled = false;
            //                MessageBox.Show(ex.Message + "\r\n" + "Com Port is not available","Com Port Problem");
            //            }

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
                spcw.dblResult = 0;
                spcw.PortOpen = false;
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //        [STAThread]
        //        static void Main() 
        //        {
        //            try
        //            {
        //                Application.Run(new MeasureForm(Client.Grader));
        //            }
        //            catch(Exception ex)
        //            {
        //                MessageBox.Show("Exception: " + ex.Message +"\nwas thrown by "+ ex.TargetSite/* +"\n"+ex.InnerException+ex.Source/*+"\n"+ex.StackTrace+"\n"+ex.GetBaseException()*/, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }


        /// <summary>
        /// Timer Tick event handler
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

            wmMode = GraderLib.WorkMode.NextNotEnteringCode;

            pbShape.Parent = pnlShape;
            pbShape.Top = 0;
            pbShape.Left = 0;
            //pbItemPicture.Parent = pnlItem;
            //Service.log.Write(@"-------------------");
            //Service.log.Write(@"Entering 'GetEnteredItem'");
            try
            {
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
                    GraderLib.Codes.Measure,
                    ref pbShape,
                    ref pbItemPicture,
                    ref lMeasures,
                    GraderLib.Codes.Measure,
                    ref bFullAccess);

                //if(dsBatchSet != null) bSaveBatchData.Enabled = true;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.Write("Df");
            }
            //Service.log.Write(@"Done 'GetEnteredItem'");
        }

        /// <summary>
        /// rbGrade radiobutton CheckedChanged event handler
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
            wmMode = GraderLib.WorkMode.GradeEnteringCharacteristic;

            lWarnings.Text = "";
            sGrade = "";
            sbStatus.Text = "";
        }

        /// <summary>
        /// rbNextItem radiobutton CheckedChanged event handler
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

            lMeasures.Text = "";
            lHistory1.Text = "";
            lHistory2.Text = "";
            lHistory3.Text = "";
            lPart.Text = "";
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

            //tbHiddenNextItem.Focus();		
            sNext = "";
        }

        /// <summary>
        /// MeasureForm keyDown event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event argument</param>
        private void MeasureForm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
                #region Entering StringValue
                if (e.KeyCode == Keys.Space && btnGetWeight.Enabled)
                {
                    btnGetWeight_Click(this, System.EventArgs.Empty);
                    return;
                }

                if (e.KeyCode == Keys.Enter && wmMode == GraderLib.WorkMode.GradeEnteringStringValue)
                {
                    GraderWork.SubmitValue("StringValue", sGrade, curPartId, curItemCode, ref dsBatchSet, tiChar);

                    wmMode = GraderLib.WorkMode.GradeEnteringCharacteristic;
                    bJustEntered = true;

                    GraderWork.UpdateSubmit(ref dsBatchSet,
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
                        ref lMeasures);
                }
                #endregion

                #region Entering IntegerValue
                if (e.KeyCode == Keys.Enter && wmMode == GraderLib.WorkMode.GradeEnteringIntegerValue)
                {
                    GraderWork.CheckSubmitValue(sGrade, tiChar);
                    GraderWork.SubmitValue("Value", sGrade, curPartId, curItemCode, ref dsBatchSet, tiChar);

                    wmMode = GraderLib.WorkMode.GradeEnteringCharacteristic;
                    bJustEntered = true;

                    GraderWork.UpdateSubmit(ref dsBatchSet, ref curOrderCode, ref curEntryBatchCode, ref curBatchCode, ref curItemCode, ref curPartName, ref curPartId, ref lPart, ref lCurrent, ref lHistory1, ref lHistory2, ref lHistory3, ref tbItemsDone, ref tbItemsNotDone, ref rbNextItem, ref pbShape, ref pbItemPicture, ref lMeasures);
                }
                #endregion

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
                        GraderLib.Codes.Measure,
                        true,
                        ref lMeasures);

                    //					if(lPart.Text.ToUpper().IndexOf("DIAMOND") >= 0)
                    //					{
                    //						if(!spcw.PortOpen) spcw.PortOpen = true;
                    //						lCaratWeight.Visible = true;
                    //						btnGetWeight.Visible = true;
                    //						btnRefreshWeight.Visible = true;
                    //						btnGetWeight.Enabled = false;
                    //						btnRefreshWeight.Enabled = false;
                    //						timer1.Start();
                    //					}
                    //					else
                    //					{
                    //						spcw.PortOpen = false;
                    //						lCaratWeight.Visible = false;
                    //						btnGetWeight.Visible = false;
                    //						btnRefreshWeight.Visible = false;
                    //						timer1.Stop();
                    //					}
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
                    GraderWork.UpdateBatch(ref dsBatchSet, GraderLib.Codes.Measure, tbItemsDone.Text);
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
                        GraderLib.Codes.Measure,
                        ref tbComment,
                        ref tbLaserInscription);
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
            }
            catch (Exception eEx)
            {
                lWarnings.Text = eEx.Message;
                sGrade = "";
                sbStatus.Text = "";
                return;
            }

            lWarnings.Text = "";
        }

        /// <summary>
        /// KeyPress event handler for MeasureForm
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event argument</param>
        private void MeasureForm_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 32 && bJustEntered) return;

            if (wmMode == GraderLib.WorkMode.NextEnteringCode || wmMode == GraderLib.WorkMode.NextNotEnteringCode)
            {
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
                return;
            }

            if (wmMode == GraderLib.WorkMode.GradeEnteringEnumValue || wmMode == GraderLib.WorkMode.GradeEnteringStringValue ||
                wmMode == GraderLib.WorkMode.GradeEnteringIntegerValue || wmMode == GraderLib.WorkMode.GradeEnteringCharacteristic)
            {
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
                    GraderLib.Codes.Measure,
                    ref tbComment,
                    ref tbLaser,
                    -1,
                    ref lMeasures);
                return;
            }

            if (wmMode == GraderLib.WorkMode.ChoosingMode)
            {
                GraderWork.ModeKeyPress(e,
                    sFileName,
                    ref sMode,
                    ref rbNextItem,
                    ref rbGrade,
                    ref lWarnings,
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
        /// <param name="e">event argument</param>
        private void pbShape_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            /*if(pbShape.Image==null) return;
            if(pbShape.Image.Size.Height > pbShape.Size.Height || pbShape.Image.Size.Width > pbShape.Size.Width)
            {
                pbShape.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                pbShape.SizeMode = PictureBoxSizeMode.CenterImage;
            }*/
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
            if (pbShape.Top != itop)
                pbShape.Top = itop;
            if (pbShape.Left != ileft)
                pbShape.Left = ileft;
        }

        /// <summary>
        /// Paint event handler for pbItemPicture
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event argument</param>
        private void pbItemPicture_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            /*if(pbItemPicture.Image==null) return;
            if(pbItemPicture.Image.Size.Height > pbItemPicture.Size.Height || pbItemPicture.Image.Size.Width > pbItemPicture.Size.Width)
            {
                pbItemPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                pbItemPicture.SizeMode = PictureBoxSizeMode.CenterImage;
            }*/
            GraderLib.ShowCorrectPicture(ref pbItemPicture);
        }

        private void MeasureForm_Load(object sender, System.EventArgs e)
        {

        }

        private void pMeasurePanel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
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
            ReloadItemWithUpdatedMeasureSet();
        }

        private void btnMeasureByFullSet_Click(object sender, System.EventArgs e)
        {
            bFullAccess = true;
            lblFullSet.Text = "Full Set";
            btnMeasureByFullSet.Enabled = false;
            btnMeasureByFullSet.Visible = false;
            btnMeasureByCP.Enabled = true;
            btnMeasureByCP.Visible = true;
            ReloadItemWithUpdatedMeasureSet();
        }

        private void ReloadItemWithUpdatedMeasureSet()
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
                        GraderLib.Codes.Measure,
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
                sFullBatchNumber = sNext.Substring(0, sNext.Length - 2);
                //                if (sNext.Length == 10) sFullBatchNumber = sNext.Substring(0, 8);
                //                if (sNext.Length == 11) sFullBatchNumber = sNext.Substring(0, 8);

                timer_Tick(this, EventArgs.Empty);
            }
        }

        private void btnGetWeight_Click(object sender, System.EventArgs e)
        {
            try
            {
                string myPartName = "";
                myPartName = lPart.Text.ToUpper().Trim();
                if (myPartName.IndexOf("COLORED DIAMOND") == 0 && myPartName.IndexOf("DIAMOND STONE") < 0)
                {
                    sGrade = "mc";
                }
                if (myPartName.IndexOf("DIAMOND") == 0 && myPartName.IndexOf("DIAMOND STONE") < 0)
                {
                    sGrade = "mc";
                }
                if (myPartName.IndexOf("COLOR STONE") == 0 && myPartName.IndexOf("COLOR STONE SET") < 0)
                {
                    sGrade = "mc";
                }
                else
                {
                    if (myPartName.IndexOf("DIAMOND STONE") >= 0)
                        sGrade = "twc";
                }
                char[] cEnteredChars = sGrade.ToCharArray();
                int[] iPartCharCodes = GraderLib.GetPartCharCodes(dsBatchSet,
                    curOrderCode, curEntryBatchCode, curBatchCode, curItemCode, curPartId);

                tiChar = GraderLib.GetCharInfo(cEnteredChars, iPartCharCodes, sFileName);
                wmMode = GraderLib.WorkMode.GradeEnteringIntegerValue;
                sGrade = lCaratWeight_3digit.Text;

                //				if (Convert.ToDouble(sGrade.Trim) > 9.99)

                GraderWork.CheckSubmitValue(sGrade, tiChar);
                GraderWork.SubmitValue("Value", sGrade, curPartId, curItemCode, ref dsBatchSet, tiChar);

                wmMode = GraderLib.WorkMode.GradeEnteringCharacteristic;
                bJustEntered = true;

                GraderWork.UpdateSubmit(ref dsBatchSet,
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
                    ref lMeasures);

            }
            catch (Exception eEx)
            {
                lCaratWeight.Text = "";
                lCaratWeight_3digit.Text = "";
                btnGetWeight.Enabled = false;

                lWarnings.Text = eEx.Message;
                sGrade = "";
                sbStatus.Text = "";
                tbItemsDone.Focus();
            }
        }

        private void MeasureForm_Closed(object sender, System.EventArgs e)
        {
            try
            {
                if (spcw.PortOpen)
                {
                    spcw.dblResult = 0;
                    spcw.PortOpen = false;
                }
                timer.Stop();
                timer1.Stop();
            }
            catch { }
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            timer1.Stop();

            try
            {
                //if(spcw.PortOpen)
                {
                    btnGetWeight.Enabled = false;
                    btnRefreshWeight.Enabled = false;

                    if (spcw.dblResult > 0.002)
                    {
                        double result = spcw.dblResult;
                        string MyString = Service9_2Digit(result).ToString("##0.00;");
                        lCaratWeight.Text = MyString;
                        MyString = Service9_3Digit(result).ToString("##0.000;");
                        lCaratWeight_3digit.Text = MyString;
                        spcw.dblResult = 0;
                        spcw.PortOpen = false;

                        if ((sbStatus.Text.Trim().Length == 0 && lPart.Text.ToUpper().IndexOf("DIAMOND") >= 0)
                            || (sbStatus.Text.Trim().Length == 0 && lPart.Text.ToUpper().IndexOf("COLOR STONE") >= 0))
                        {
                            btnGetWeight.Enabled = true;
                            btnRefreshWeight.Enabled = true;
                        }

                        //if (sbStatus.Text.Trim().Length == 0 && lPart.Text.ToUpper().IndexOf("COLOR STONE") >= 0)
                        //{
                        //    btnGetWeight.Enabled = true;
                        //    btnRefreshWeight.Enabled = true;
                        //}
                        //						else
                        //						{
                        //						}
                    }
                    else
                    {
                        if (!spcw.PortOpen) spcw.PortOpen = true;
                        timer1.Start();
                    }
                }


                //else
                {

                    //					if(lCaratWeight.Text.Trim().Length > 0 && sbStatus.Text.Trim().Length == 0)
                    //						btnGetWeight.Enabled = true;
                }
                if (iTestMode == 1)
                {
                    tbComPort.Text = tbComPort.Text + "\r\n" + spcw.InputString;
                    timer1.Start();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private double Service9_2Digit(double d)
        {
            d = d + 0.001;
            int shifted = (int)(d * 1000) / 10;
            d = (double)(shifted * 10) / 1000;
            return d;
        }
        private double Service9_3Digit(double b)
        {
            b = b + 0.0001;
            int shifted = (int)(b * 10000) / 10;
            b = (double)(shifted * 10) / 10000;
            return b;
        }


        private void btnRefreshWeight_Click(object sender, System.EventArgs e)
        {
            if (sbStatus.Text.Trim().Length == 0 && lPart.Text.ToUpper().IndexOf("DIAMOND") >= 0)
            {
                timer1.Start();
            }

            if (sbStatus.Text.Trim().Length == 0 && lPart.Text.ToUpper().IndexOf("COLOR STONE") >= 0)
            {
                timer1.Start();
            }

        }

        private void lPart_TextChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (lPart.Text.ToUpper().IndexOf("DIAMOND") >= 0 || lPart.Text.ToUpper().IndexOf("COLOR STONE") >= 0)
                {
#if DEBUG                    
#else
					if (!spcw.PortOpen) spcw.PortOpen = true;
#endif
                    lCaratWeight.Visible = true;
                    lCaratWeight_3digit.Visible = true;
                    btnGetWeight.Visible = true;
                    btnRefreshWeight.Visible = true;
                    btnGetWeight.Enabled = false;
                    btnRefreshWeight.Enabled = false;
                    timer1.Start();
                }
                else
                {
#if DEBUG
#else
                    if (spcw.PortOpen)
                    {
                        spcw.dblResult = 0;
                        spcw.PortOpen = false;
                    }
#endif
                    lCaratWeight.Text = "";
                    lCaratWeight.Visible = false;
                    lCaratWeight_3digit.Text = "";
                    lCaratWeight_3digit.Visible = false;
                    btnGetWeight.Visible = false;
                    btnRefreshWeight.Visible = false;
                    //timer1.Stop();
                }
            }
            catch (Exception ex)
            {
                lCaratWeight.Text = "";
                lCaratWeight.Visible = false;
                lCaratWeight_3digit.Text = "";
                lCaratWeight_3digit.Visible = false;
                btnGetWeight.Visible = false;
                btnRefreshWeight.Visible = false;
                //timer1.Stop();			
            }
        }

        private void cmd_Start_Click(object sender, System.EventArgs e)
        {
            spcw.iComPortSource = 1;
            spcw.CommPort = Convert.ToInt16(cmbComPort.Text);
            spcw.BitRate = Convert.ToInt16(cmbRate.Text);
            spcw.DataBits = Convert.ToInt16(cmbDataBits.Text);
            spcw.Parity = cmbParity.Text.ToString();
            spcw.StopBits = Convert.ToInt16(cmbStopBits.Text);
            spcw.CTSHandshaking = radioButton2.Checked;
            spcw.XonXoffHandshaking = radioButton1.Checked;
            if (!spcw.PortOpen) spcw.PortOpen = true;

            iTestMode = 1;
            timer1.Start();

            //            thread = new Thread(new ThreadStart(Digi));
            //            thread.Start();
            //            thread.Join();
        }

        private void Digi()
        {
            tbComPort.Text = tbComPort.Text + "\r\n" + spcw.dblResult.ToString();

        }

        private void cmd_Stop_Click(object sender, System.EventArgs e)
        {
            //timer1.Stop();
            iTestMode = 0;
            spcw.iComPortSource = 0;
            if (spcw.PortOpen) spcw.PortOpen = false;
            tbComPort.Text = "";
            //thread.Abort();
        }

        private void gbflowControl_Enter(object sender, System.EventArgs e)
        {

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
                        ref pbItemPicture,
                        GraderLib.Codes.Measure,
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
