using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using gemoDream;

namespace Cntrls
{
	/// <summary>
	/// Summary description for DocumentProps.
	/// </summary>
	public class DocumentProps : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.TabPage tabPage5;
		private System.Windows.Forms.CheckBox chbDocReturnDoc;
		private System.Windows.Forms.Panel panel1;		
		private System.Windows.Forms.GroupBox groupBox3;		
		private System.Windows.Forms.GroupBox groupBox2;		
		private System.Windows.Forms.GroupBox gbToDo;
		public System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Panel panel2;
		public System.Windows.Forms.CheckBox chbDocEnabled;
		
		public System.Windows.Forms.CheckBox chbPrintDoc6;
		public System.Windows.Forms.ComboBox cbDoc6;
		public System.Windows.Forms.CheckBox chbPrintDoc5;
		public System.Windows.Forms.ComboBox cbDoc5;
		public System.Windows.Forms.ComboBox cbDoc4;
		public System.Windows.Forms.CheckBox chbPrintDoc4;
		public System.Windows.Forms.ComboBox cbDoc3;
		public System.Windows.Forms.CheckBox chbPrintDoc3;
		public System.Windows.Forms.ComboBox cbDoc2;
		public System.Windows.Forms.CheckBox chbPrintDoc2;
		public System.Windows.Forms.ComboBox cbDoc1;
		public System.Windows.Forms.CheckBox chbPrintDoc1;
		public System.Windows.Forms.TextBox tbDescription;
		public System.Windows.Forms.DataGrid dgRechecks;
		public System.Windows.Forms.Panel pnlPartProps;


		private int iAccessLevel;
		private string sCPName;
		private DataSet dsData;
		private DataSet dsParts;
		private DataSet dsBlockedParts;
		private DataTable dtPartsInfo;
		DataRow[] adrInfo;
		public Cntrls.PartTree ptPartTree;
		public DataSet dsRulez;
		private int currentPartTypeID;
		private string sCPOfficeID = null;
		private string sCPID = null;
		private string sItemTypeID;
		private string sPath2Picture;
		private ArrayList newOperationsList;
		private bool bInitDocz = false;
		public System.Windows.Forms.CheckBox chbShowDoc1;
		public System.Windows.Forms.CheckBox chbShowDoc2;
		public System.Windows.Forms.CheckBox chbShowDoc3;
		public System.Windows.Forms.CheckBox chbShowDoc4;
		public System.Windows.Forms.CheckBox chbShowDoc5;
		public System.Windows.Forms.CheckBox chbShowDoc6;
		private Button cmd_Select;
		private Button cmd_UnSelect;



		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DocumentProps()
		{
			InitializeComponent();
			//Init();			
		}

		public DocumentProps(int iAccessLevel, DataSet dsDocs, DataSet dsMsrs, DataSet dsPrts, DataSet dsRealRules,
			string sCPOfficeID, string sCPID, string sItemTypeID, string sPath2Picture, 
			ArrayList newOperationsList, string sCPName)
		{
			this.iAccessLevel = iAccessLevel;
			this.sCPOfficeID = sCPOfficeID;
			this.sCPID = sCPID;
			this.sItemTypeID = sItemTypeID;
			this.sPath2Picture = sPath2Picture;
			this.newOperationsList = newOperationsList;
			this.sCPName = sCPName;

			dsData = dsMsrs.Copy();
			dsParts = dsPrts.Copy();
			if (dsRealRules != null)
				dsRulez = dsRealRules.Copy();
			else
				dsRulez = new DataSet();

			InitializeComponent();
			Init();
			InitDocz(dsDocs);				
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.chbDocReturnDoc = new System.Windows.Forms.CheckBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.gbToDo = new System.Windows.Forms.GroupBox();
			this.dgRechecks = new System.Windows.Forms.DataGrid();
			this.panel2 = new System.Windows.Forms.Panel();
			this.chbShowDoc6 = new System.Windows.Forms.CheckBox();
			this.chbShowDoc5 = new System.Windows.Forms.CheckBox();
			this.chbShowDoc4 = new System.Windows.Forms.CheckBox();
			this.chbShowDoc3 = new System.Windows.Forms.CheckBox();
			this.chbShowDoc2 = new System.Windows.Forms.CheckBox();
			this.chbShowDoc1 = new System.Windows.Forms.CheckBox();
			this.cbDoc6 = new System.Windows.Forms.ComboBox();
			this.chbPrintDoc6 = new System.Windows.Forms.CheckBox();
			this.cbDoc5 = new System.Windows.Forms.ComboBox();
			this.chbPrintDoc5 = new System.Windows.Forms.CheckBox();
			this.cbDoc1 = new System.Windows.Forms.ComboBox();
			this.cbDoc4 = new System.Windows.Forms.ComboBox();
			this.chbPrintDoc4 = new System.Windows.Forms.CheckBox();
			this.cbDoc3 = new System.Windows.Forms.ComboBox();
			this.chbPrintDoc3 = new System.Windows.Forms.CheckBox();
			this.cbDoc2 = new System.Windows.Forms.ComboBox();
			this.chbPrintDoc2 = new System.Windows.Forms.CheckBox();
			this.chbPrintDoc1 = new System.Windows.Forms.CheckBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.chbDocEnabled = new System.Windows.Forms.CheckBox();
			this.tbDescription = new System.Windows.Forms.TextBox();
			this.pnlPartProps = new System.Windows.Forms.Panel();
			this.cmd_Select = new System.Windows.Forms.Button();
			this.cmd_UnSelect = new System.Windows.Forms.Button();
			this.ptPartTree = new Cntrls.PartTree();
			this.gbToDo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgRechecks)).BeginInit();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabPage5
			// 
			this.tabPage5.Location = new System.Drawing.Point(0, 0);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Size = new System.Drawing.Size(200, 100);
			this.tabPage5.TabIndex = 0;
			// 
			// chbDocReturnDoc
			// 
			this.chbDocReturnDoc.Location = new System.Drawing.Point(0, 0);
			this.chbDocReturnDoc.Name = "chbDocReturnDoc";
			this.chbDocReturnDoc.Size = new System.Drawing.Size(104, 24);
			this.chbDocReturnDoc.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(200, 100);
			this.panel1.TabIndex = 0;
			// 
			// groupBox3
			// 
			this.groupBox3.Location = new System.Drawing.Point(100, 15);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(90, 65);
			this.groupBox3.TabIndex = 1;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Clarity";
			// 
			// groupBox2
			// 
			this.groupBox2.Location = new System.Drawing.Point(5, 15);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(90, 65);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Color";
			// 
			// gbToDo
			// 
			this.gbToDo.Controls.Add(this.dgRechecks);
			this.gbToDo.Controls.Add(this.panel2);
			this.gbToDo.Enabled = false;
			this.gbToDo.Location = new System.Drawing.Point(673, 4);
			this.gbToDo.Name = "gbToDo";
			this.gbToDo.Size = new System.Drawing.Size(265, 326);
			this.gbToDo.TabIndex = 2;
			this.gbToDo.TabStop = false;
			this.gbToDo.Text = "What to do.";
			// 
			// dgRechecks
			// 
			this.dgRechecks.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dgRechecks.CaptionBackColor = System.Drawing.SystemColors.ControlLight;
			this.dgRechecks.CaptionVisible = false;
			this.dgRechecks.DataMember = "";
			this.dgRechecks.HeaderFont = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.dgRechecks.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgRechecks.Location = new System.Drawing.Point(5, 15);
			this.dgRechecks.Name = "dgRechecks";
			this.dgRechecks.PreferredRowHeight = 12;
			this.dgRechecks.Size = new System.Drawing.Size(255, 60);
			this.dgRechecks.TabIndex = 12;
			// 
			// panel2
			// 
			this.panel2.AutoScroll = true;
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel2.Controls.Add(this.chbShowDoc6);
			this.panel2.Controls.Add(this.chbShowDoc5);
			this.panel2.Controls.Add(this.chbShowDoc4);
			this.panel2.Controls.Add(this.chbShowDoc3);
			this.panel2.Controls.Add(this.chbShowDoc2);
			this.panel2.Controls.Add(this.chbShowDoc1);
			this.panel2.Controls.Add(this.cbDoc6);
			this.panel2.Controls.Add(this.chbPrintDoc6);
			this.panel2.Controls.Add(this.cbDoc5);
			this.panel2.Controls.Add(this.chbPrintDoc5);
			this.panel2.Controls.Add(this.cbDoc1);
			this.panel2.Controls.Add(this.cbDoc4);
			this.panel2.Controls.Add(this.chbPrintDoc4);
			this.panel2.Controls.Add(this.cbDoc3);
			this.panel2.Controls.Add(this.chbPrintDoc3);
			this.panel2.Controls.Add(this.cbDoc2);
			this.panel2.Controls.Add(this.chbPrintDoc2);
			this.panel2.Controls.Add(this.chbPrintDoc1);
			this.panel2.Location = new System.Drawing.Point(5, 81);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(255, 239);
			this.panel2.TabIndex = 2;
			// 
			// chbShowDoc6
			// 
			this.chbShowDoc6.Location = new System.Drawing.Point(218, 250);
			this.chbShowDoc6.Name = "chbShowDoc6";
			this.chbShowDoc6.Size = new System.Drawing.Size(15, 15);
			this.chbShowDoc6.TabIndex = 19;
			this.chbShowDoc6.CheckedChanged += new System.EventHandler(this.chbShowDoc6_CheckedChanged);
			// 
			// chbShowDoc5
			// 
			this.chbShowDoc5.Location = new System.Drawing.Point(218, 205);
			this.chbShowDoc5.Name = "chbShowDoc5";
			this.chbShowDoc5.Size = new System.Drawing.Size(15, 15);
			this.chbShowDoc5.TabIndex = 18;
			this.chbShowDoc5.CheckedChanged += new System.EventHandler(this.chbShowDoc5_CheckedChanged);
			// 
			// chbShowDoc4
			// 
			this.chbShowDoc4.Location = new System.Drawing.Point(218, 155);
			this.chbShowDoc4.Name = "chbShowDoc4";
			this.chbShowDoc4.Size = new System.Drawing.Size(15, 15);
			this.chbShowDoc4.TabIndex = 17;
			this.chbShowDoc4.CheckedChanged += new System.EventHandler(this.chbShowDoc4_CheckedChanged);
			// 
			// chbShowDoc3
			// 
			this.chbShowDoc3.Location = new System.Drawing.Point(218, 110);
			this.chbShowDoc3.Name = "chbShowDoc3";
			this.chbShowDoc3.Size = new System.Drawing.Size(15, 15);
			this.chbShowDoc3.TabIndex = 16;
			this.chbShowDoc3.CheckedChanged += new System.EventHandler(this.chbShowDoc3_CheckedChanged);
			// 
			// chbShowDoc2
			// 
			this.chbShowDoc2.Location = new System.Drawing.Point(218, 65);
			this.chbShowDoc2.Name = "chbShowDoc2";
			this.chbShowDoc2.Size = new System.Drawing.Size(15, 15);
			this.chbShowDoc2.TabIndex = 15;
			this.chbShowDoc2.CheckedChanged += new System.EventHandler(this.chbShowDoc2_CheckedChanged);
			// 
			// chbShowDoc1
			// 
			this.chbShowDoc1.Location = new System.Drawing.Point(218, 20);
			this.chbShowDoc1.Name = "chbShowDoc1";
			this.chbShowDoc1.Size = new System.Drawing.Size(15, 15);
			this.chbShowDoc1.TabIndex = 14;
			this.chbShowDoc1.CheckedChanged += new System.EventHandler(this.chbShowDoc1_CheckedChanged);
			// 
			// cbDoc6
			// 
			this.cbDoc6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbDoc6.Enabled = false;
			this.cbDoc6.Location = new System.Drawing.Point(2, 250);
			this.cbDoc6.Name = "cbDoc6";
			this.cbDoc6.Size = new System.Drawing.Size(210, 20);
			this.cbDoc6.TabIndex = 13;
			this.cbDoc6.SelectedIndexChanged += new System.EventHandler(this.comboBoxDocument6);
			// 
			// chbPrintDoc6
			// 
			this.chbPrintDoc6.Enabled = false;
			this.chbPrintDoc6.Location = new System.Drawing.Point(2, 235);
			this.chbPrintDoc6.Name = "chbPrintDoc6";
			this.chbPrintDoc6.Size = new System.Drawing.Size(180, 15);
			this.chbPrintDoc6.TabIndex = 12;
			this.chbPrintDoc6.Text = "Print Document";
			this.chbPrintDoc6.CheckedChanged += new System.EventHandler(this.chbPrintDoc6_CheckedChanged);
			// 
			// cbDoc5
			// 
			this.cbDoc5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbDoc5.DropDownWidth = 205;
			this.cbDoc5.Enabled = false;
			this.cbDoc5.Location = new System.Drawing.Point(2, 205);
			this.cbDoc5.Name = "cbDoc5";
			this.cbDoc5.Size = new System.Drawing.Size(210, 20);
			this.cbDoc5.TabIndex = 11;
			this.cbDoc5.SelectedIndexChanged += new System.EventHandler(this.comboBoxDocument5);
			// 
			// chbPrintDoc5
			// 
			this.chbPrintDoc5.Enabled = false;
			this.chbPrintDoc5.Location = new System.Drawing.Point(2, 190);
			this.chbPrintDoc5.Name = "chbPrintDoc5";
			this.chbPrintDoc5.Size = new System.Drawing.Size(180, 15);
			this.chbPrintDoc5.TabIndex = 10;
			this.chbPrintDoc5.Text = "Print Document";
			this.chbPrintDoc5.CheckedChanged += new System.EventHandler(this.chbPrintDoc5_CheckedChanged);
			// 
			// cbDoc1
			// 
			this.cbDoc1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbDoc1.Enabled = false;
			this.cbDoc1.Location = new System.Drawing.Point(2, 20);
			this.cbDoc1.Name = "cbDoc1";
			this.cbDoc1.Size = new System.Drawing.Size(210, 20);
			this.cbDoc1.TabIndex = 2;
			this.cbDoc1.SelectedIndexChanged += new System.EventHandler(this.comboBoxDocument1);
			// 
			// cbDoc4
			// 
			this.cbDoc4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbDoc4.Enabled = false;
			this.cbDoc4.Location = new System.Drawing.Point(2, 155);
			this.cbDoc4.Name = "cbDoc4";
			this.cbDoc4.Size = new System.Drawing.Size(210, 20);
			this.cbDoc4.TabIndex = 8;
			this.cbDoc4.SelectedIndexChanged += new System.EventHandler(this.comboBoxDocument4);
			// 
			// chbPrintDoc4
			// 
			this.chbPrintDoc4.Enabled = false;
			this.chbPrintDoc4.Location = new System.Drawing.Point(2, 140);
			this.chbPrintDoc4.Name = "chbPrintDoc4";
			this.chbPrintDoc4.Size = new System.Drawing.Size(180, 15);
			this.chbPrintDoc4.TabIndex = 7;
			this.chbPrintDoc4.Text = "Print Document";
			this.chbPrintDoc4.CheckedChanged += new System.EventHandler(this.chbPrintDoc4_CheckedChanged);
			// 
			// cbDoc3
			// 
			this.cbDoc3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbDoc3.Enabled = false;
			this.cbDoc3.Location = new System.Drawing.Point(2, 110);
			this.cbDoc3.Name = "cbDoc3";
			this.cbDoc3.Size = new System.Drawing.Size(210, 20);
			this.cbDoc3.TabIndex = 6;
			this.cbDoc3.SelectedIndexChanged += new System.EventHandler(this.comboBoxDocument3);
			// 
			// chbPrintDoc3
			// 
			this.chbPrintDoc3.Enabled = false;
			this.chbPrintDoc3.Location = new System.Drawing.Point(2, 95);
			this.chbPrintDoc3.Name = "chbPrintDoc3";
			this.chbPrintDoc3.Size = new System.Drawing.Size(180, 15);
			this.chbPrintDoc3.TabIndex = 5;
			this.chbPrintDoc3.Text = "Print Document";
			this.chbPrintDoc3.CheckedChanged += new System.EventHandler(this.chbPrintDoc3_CheckedChanged);
			// 
			// cbDoc2
			// 
			this.cbDoc2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbDoc2.Enabled = false;
			this.cbDoc2.Location = new System.Drawing.Point(2, 65);
			this.cbDoc2.Name = "cbDoc2";
			this.cbDoc2.Size = new System.Drawing.Size(210, 20);
			this.cbDoc2.TabIndex = 4;
			this.cbDoc2.SelectedIndexChanged += new System.EventHandler(this.comboBoxDocument2);
			this.cbDoc2.Click += new System.EventHandler(this.chbPrintDoc2_CheckedChanged);
			// 
			// chbPrintDoc2
			// 
			this.chbPrintDoc2.Enabled = false;
			this.chbPrintDoc2.Location = new System.Drawing.Point(2, 50);
			this.chbPrintDoc2.Name = "chbPrintDoc2";
			this.chbPrintDoc2.Size = new System.Drawing.Size(180, 15);
			this.chbPrintDoc2.TabIndex = 3;
			this.chbPrintDoc2.Text = "Print Document";
			this.chbPrintDoc2.CheckedChanged += new System.EventHandler(this.chbPrintDoc2_CheckedChanged);
			// 
			// chbPrintDoc1
			// 
			this.chbPrintDoc1.Location = new System.Drawing.Point(2, 5);
			this.chbPrintDoc1.Name = "chbPrintDoc1";
			this.chbPrintDoc1.Size = new System.Drawing.Size(180, 15);
			this.chbPrintDoc1.TabIndex = 1;
			this.chbPrintDoc1.Text = "Print Document";
			this.chbPrintDoc1.CheckedChanged += new System.EventHandler(this.chbPrintDoc1_CheckedChanged);
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(3, 315);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(183, 17);
			this.checkBox1.TabIndex = 3;
			this.checkBox1.Text = "Return Item to Customer";
			// 
			// chbDocEnabled
			// 
			this.chbDocEnabled.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.chbDocEnabled.Location = new System.Drawing.Point(5, 0);
			this.chbDocEnabled.Name = "chbDocEnabled";
			this.chbDocEnabled.Size = new System.Drawing.Size(84, 15);
			this.chbDocEnabled.TabIndex = 5;
			this.chbDocEnabled.Text = "Enabled";
			this.chbDocEnabled.CheckedChanged += new System.EventHandler(this.chbDocEnabled_CheckedChanged_1);
			// 
			// tbDescription
			// 
			this.tbDescription.Enabled = false;
			this.tbDescription.Location = new System.Drawing.Point(5, 242);
			this.tbDescription.Multiline = true;
			this.tbDescription.Name = "tbDescription";
			this.tbDescription.Size = new System.Drawing.Size(195, 67);
			this.tbDescription.TabIndex = 7;
			// 
			// pnlPartProps
			// 
			this.pnlPartProps.AutoScroll = true;
			this.pnlPartProps.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlPartProps.Location = new System.Drawing.Point(205, 45);
			this.pnlPartProps.Name = "pnlPartProps";
			this.pnlPartProps.Size = new System.Drawing.Size(467, 321);
			this.pnlPartProps.TabIndex = 9;
			this.pnlPartProps.Leave += new System.EventHandler(this.pnlPartProps_Leave);
			// 
			// cmd_Select
			// 
			this.cmd_Select.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.cmd_Select.Location = new System.Drawing.Point(559, 27);
			this.cmd_Select.Name = "cmd_Select";
			this.cmd_Select.Size = new System.Drawing.Size(69, 18);
			this.cmd_Select.TabIndex = 12;
			this.cmd_Select.Text = "Check in";
			this.cmd_Select.UseVisualStyleBackColor = false;
			this.cmd_Select.Click += new System.EventHandler(this.cmd_Select_Click);
			// 
			// cmd_UnSelect
			// 
			this.cmd_UnSelect.BackColor = System.Drawing.Color.Snow;
			this.cmd_UnSelect.Location = new System.Drawing.Point(559, 8);
			this.cmd_UnSelect.Name = "cmd_UnSelect";
			this.cmd_UnSelect.Size = new System.Drawing.Size(69, 18);
			this.cmd_UnSelect.TabIndex = 13;
			this.cmd_UnSelect.Text = "Check out";
			this.cmd_UnSelect.UseVisualStyleBackColor = false;
			this.cmd_UnSelect.Click += new System.EventHandler(this.cmd_UnSelect_Click);
			// 
			// ptPartTree
			// 
			this.ptPartTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ptPartTree.Location = new System.Drawing.Point(5, 15);
			this.ptPartTree.Name = "ptPartTree";
			this.ptPartTree.Size = new System.Drawing.Size(195, 222);
			this.ptPartTree.TabIndex = 10;
			this.ptPartTree.Changed += new System.EventHandler(this.ptPartTree_Changed_1);
			// 
			// DocumentProps
			// 
			this.Controls.Add(this.cmd_UnSelect);
			this.Controls.Add(this.cmd_Select);
			this.Controls.Add(this.tbDescription);
			this.Controls.Add(this.chbDocEnabled);
			this.Controls.Add(this.gbToDo);
			this.Controls.Add(this.ptPartTree);
			this.Controls.Add(this.pnlPartProps);
			this.Controls.Add(this.checkBox1);
			this.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.Name = "DocumentProps";
			this.Size = new System.Drawing.Size(941, 377);
			this.Load += new System.EventHandler(this.DocumentProps_Load);
			this.gbToDo.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgRechecks)).EndInit();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		public DataSet Rulez
		{
			get
			{
				if (dsRulez != null) return dsRulez.Copy();
				else return null;
			}
			set
			{
				if (value != null) dsRulez = value.Copy();
				else dsRulez = new DataSet();
			}
		}

		private void Init()
		{
			try
			{
				chbDocEnabled.Checked = false;

				ptPartTree.Enabled = false;
				gbToDo.Enabled = false;
				gbToDo.Enabled = false;
				ptPartTree.Initialize(dsParts.Tables["Parts"]);
				ptPartTree.ExpandTree();
				chbShowDoc1.Checked = false;
				chbShowDoc2.Checked = false;
				chbShowDoc3.Checked = false;
				chbShowDoc4.Checked = false;
				chbShowDoc5.Checked = false;
				chbShowDoc6.Checked = false;

				chbShowDoc1.Enabled = false;
				chbShowDoc2.Enabled = false;
				chbShowDoc3.Enabled = false;
				chbShowDoc4.Enabled = false;
				chbShowDoc5.Enabled = false;
				chbShowDoc6.Enabled = false;
	
			}
			catch(Exception ex)
			{
				var a = ex.Message;
			}
		}

		//private void UpdatePartTree(TreeNodeCollection nodes, List<string> partID, bool toCheck)
		//{
		//	try
		//	{
		//		if (partID.Count > 0)
		//		{
		//			foreach (string node in partID)
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

		//private void FindRecursive(TreeNode treeNode, string findNode, bool toCheck)
		//{
		//	foreach (TreeNode tn in treeNode.Nodes)
		//	{
		//		if (tn.Text == findNode)
		//			tn.Checked = toCheck;
		//		FindRecursive(tn, findNode, toCheck);
		//	}
		//}

		public void InitRechecks(DataView dvData)
		{
			dvData.AllowNew = false;
			dvData.AllowDelete = false;
			dgRechecks.TableStyles.Add(NewTableStyle());
			dgRechecks.RowHeadersVisible = false;
			dgRechecks.DataSource = dvData;
		}


		//new document
		public DataGridTableStyle NewTableStyle()
		{			
			DataGridTableStyle ts1 = new DataGridTableStyle();
			ts1.MappingName = "Rechecks";
			ts1.HeaderFont = new Font(ts1.HeaderFont.FontFamily, ts1.HeaderFont.Size, FontStyle.Bold);			
			ts1.PreferredRowHeight = 10;
			ts1.RowHeadersVisible = false;			

			DataGridColumnStyle tcProp = new DataGridTextBoxColumn();
			tcProp.MappingName = "Property_Name";
			tcProp.HeaderText = "Property Name";
			tcProp.Width = 110;
			tcProp.ReadOnly = true;
			tcProp.Alignment = HorizontalAlignment.Center;
			ts1.GridColumnStyles.Add(tcProp);

			DataGridColumnStyle tcRechecks = new DataGridTextBoxColumn();
			tcRechecks.MappingName = "Rechecks";
			tcRechecks.HeaderText = "Rechecks";
			tcRechecks.Width = 70;
			tcRechecks.Alignment = HorizontalAlignment.Center;
			tcRechecks.NullText = "0";
			ts1.GridColumnStyles.Add(tcRechecks);

			DataGridColumnStyle boolCol = new DataGridBoolColumn();
			boolCol.MappingName = "Do";
			boolCol.HeaderText = "Do";
			boolCol.Width = 25;
			
			ts1.GridColumnStyles.Add(boolCol);      

			return ts1;
		}

		//PartTreeInit
		public void InitTree(DataTable dtIni)
		{
			try
			{
				ptPartTree.Initialize(dtIni);
				ptPartTree.ExpandTree();

				DataSet dsTemp = new DataSet();
				dsTemp.Tables.Add("BlockedPartsBySKU");
				dsTemp.Tables[0].Columns.Add("CPID", Type.GetType("System.String"));
				dsTemp.Tables[0].Rows.Add(dsTemp.Tables[0].NewRow());
				dsTemp.Tables[0].Rows[0][0] = sCPID;
				dsBlockedParts = Service.ProxyGenericGet(dsTemp);
				if (dsBlockedParts.Tables.Count > 0)
				{
					if (dsBlockedParts.Tables[0].Rows.Count == 1)
					{
						string[] myParts = dsBlockedParts.Tables[0].Rows[0][8].ToString().TrimStart(';').Split(';');
						//ArrayList partID = new ArrayList();
						List<string> partID = new List<string>();
						foreach (var part in myParts)
						{
							partID.Add(part);
						}
						Service.UpdatePartTree(ptPartTree.tvPartTree.Nodes, partID, true);
					}
				}
			}
			catch(Exception ex)
			{
				var a = ex.Message;
			}
		}


		//PrintDocs CheckBoxes:
		private void chbPrintDoc1_CheckedChanged(object sender, System.EventArgs e)
		{

			if(!chbPrintDoc1.Checked)
			{
				chbPrintDoc2.Checked = false;
				chbPrintDoc3.Checked = false;
				chbPrintDoc4.Checked = false;
				chbPrintDoc5.Checked = false;
				chbPrintDoc6.Checked = false;

				chbPrintDoc3.Enabled = false;
				chbPrintDoc4.Enabled = false;
				chbPrintDoc5.Enabled = false;
				chbPrintDoc6.Enabled = false;
		
				chbShowDoc1.Checked = false;
				chbShowDoc2.Checked = false;
				chbShowDoc3.Checked = false;
				chbShowDoc4.Checked = false;
				chbShowDoc5.Checked = false;
				chbShowDoc6.Checked = false;

				chbShowDoc1.Enabled = false;
				chbShowDoc2.Enabled = false;
				chbShowDoc3.Enabled = false;
				chbShowDoc4.Enabled = false;
				chbShowDoc5.Enabled = false;
				chbShowDoc6.Enabled = false;

				cbDoc3.Enabled = false;
				cbDoc4.Enabled = false;
				cbDoc5.Enabled = false;
				cbDoc6.Enabled = false;
			}

			chbShowDoc1.Enabled = chbPrintDoc1.Checked;

			cbDoc1.Enabled = chbPrintDoc2.Enabled = chbPrintDoc1.Checked;
		}

		private void chbPrintDoc2_CheckedChanged(object sender, System.EventArgs e)
		{
			if(!chbPrintDoc2.Checked)
			{
				chbPrintDoc3.Checked = false;
				chbPrintDoc4.Checked = false;
				chbPrintDoc5.Checked = false;
				chbPrintDoc6.Checked = false;
				
				chbPrintDoc4.Enabled = false;
				chbPrintDoc5.Enabled = false;
				chbPrintDoc6.Enabled = false;
			
				chbShowDoc2.Checked = false;
				chbShowDoc3.Checked = false;
				chbShowDoc4.Checked = false;
				chbShowDoc5.Checked = false;
				chbShowDoc6.Checked = false;

				chbShowDoc2.Enabled = false;
				chbShowDoc3.Enabled = false;
				chbShowDoc4.Enabled = false;
				chbShowDoc5.Enabled = false;
				chbShowDoc6.Enabled = false;
			
				cbDoc4.Enabled = false;
				cbDoc5.Enabled = false;
				cbDoc6.Enabled = false;
			}

			chbShowDoc2.Enabled = chbPrintDoc2.Checked;
			cbDoc2.Enabled = chbPrintDoc3.Enabled = chbPrintDoc2.Checked;
			//			cbDoc2.SelectedIndex = -1;			
			//			cbDoc2.SelectedIndex = 0;			
		}

		private void chbPrintDoc3_CheckedChanged(object sender, System.EventArgs e)
		{
			if(!chbPrintDoc3.Checked)
			{
				chbPrintDoc4.Checked = false;
				chbPrintDoc5.Checked = false;
				chbPrintDoc6.Checked = false;
				
				chbPrintDoc5.Enabled = false;
				chbPrintDoc6.Enabled = false;
			
				chbShowDoc3.Checked = false;
				chbShowDoc4.Checked = false;
				chbShowDoc5.Checked = false;
				chbShowDoc6.Checked = false;

				chbShowDoc3.Enabled = false;
				chbShowDoc4.Enabled = false;
				chbShowDoc5.Enabled = false;
				chbShowDoc6.Enabled = false;
			
				cbDoc5.Enabled = false;
				cbDoc6.Enabled = false;
			}

			chbShowDoc3.Enabled = chbPrintDoc3.Checked;
			cbDoc3.Enabled = chbPrintDoc4.Enabled = chbPrintDoc3.Checked;
			//			cbDoc3.SelectedIndex = -1;			
			//			cbDoc3.SelectedIndex = 0;	
		}

		private void chbPrintDoc4_CheckedChanged(object sender, System.EventArgs e)
		{	
			if(!chbPrintDoc4.Checked)
			{
				chbPrintDoc5.Checked = false;
				chbPrintDoc6.Checked = false;
				
				chbPrintDoc6.Enabled = false;
			
				chbShowDoc4.Checked = false;
				chbShowDoc5.Checked = false;
				chbShowDoc6.Checked = false;

				chbShowDoc4.Enabled = false;
				chbShowDoc5.Enabled = false;
				chbShowDoc6.Enabled = false;
				
				cbDoc6.Enabled = false;
			}
		
			chbShowDoc4.Enabled = chbPrintDoc4.Checked;
			cbDoc4.Enabled = chbPrintDoc5.Enabled = chbPrintDoc4.Checked;
			//			cbDoc4.SelectedIndex = -1;			
			//			cbDoc4.SelectedIndex = 0;
		}

		private void chbPrintDoc5_CheckedChanged(object sender, System.EventArgs e)
		{
			if(!chbPrintDoc5.Checked)
			{
				chbPrintDoc6.Checked = false;
				cbDoc6.Enabled = false;
				
				chbShowDoc5.Checked = false;
				chbShowDoc6.Checked = false;

				chbShowDoc5.Enabled = false;
				chbShowDoc6.Enabled = false;
				
			}
	
			chbShowDoc5.Enabled = chbPrintDoc5.Checked;
			cbDoc5.Enabled = chbPrintDoc6.Enabled = chbPrintDoc5.Checked;
		}

		private void chbPrintDoc6_CheckedChanged(object sender, System.EventArgs e)
		{
			cbDoc6.Enabled = chbPrintDoc6.Checked;
			chbShowDoc6.Checked = false;
			chbShowDoc6.Enabled = chbPrintDoc6.Checked;
		}

		private void DocumentProps_Load(object sender, System.EventArgs e)
		{
		
		}
		
		public CheckBox DocEnabledCheck
		{
			get
			{
				return chbDocEnabled;
			}
			set
			{
				chbDocEnabled = value;
			}
		}

		
		private void chbDocEnabled_CheckedChanged_1(object sender, System.EventArgs e)
		{
			ptPartTree.Enabled = chbDocEnabled.Checked;
			gbToDo.Enabled = chbDocEnabled.Checked;
			pnlPartProps.Enabled = chbDocEnabled.Checked;
			ChckdCngd(EventArgs.Empty);
			tbDescription.Enabled = chbDocEnabled.Checked;
		}

		public event EventHandler DocEnabledCheckedChanged;

		protected virtual void ChckdCngd(EventArgs ea)
		{
			if(DocEnabledCheckedChanged != null)
				DocEnabledCheckedChanged(this, ea);
		}

		
		private void ptPartTree_Changed(object sender, System.EventArgs e)
		{
			int Pos = 5;
			if(pnlPartProps.Controls.Count != 0)
			{
				for(int i = 0; i < pnlPartProps.Controls.Count; i++)
				{
					adrInfo[i]["Name"] = ((PartPropControl)pnlPartProps.Controls[i]).tbPropName.Text;
					adrInfo[i]["Min"] = ((PartPropControl)pnlPartProps.Controls[i]).tbMinValue.Text;
					adrInfo[i]["Max"] = ((PartPropControl)pnlPartProps.Controls[i]).tbMaxValue.Text;
				}
				pnlPartProps.Controls.Clear();
			}
				
			adrInfo = dtPartsInfo.Select("ID='" + ptPartTree.SelectedRow["ID"].ToString() + "'");
			foreach(DataRow drNext in adrInfo)
			{
				PartPropControl ppcNew = new PartPropControl();
				ppcNew.Location = new Point(5, Pos);
				ppcNew.tbPropName.Text = drNext["Name"].ToString();
				ppcNew.tbPropName.Tag = drNext["ID"].ToString();
				ppcNew.tbMinValue.Text = drNext["Min"].ToString();
				ppcNew.tbMaxValue.Text = drNext["Max"].ToString();

				Pos += 35;
			}
		}		

		private void InitDocz(DataSet dsDocOperations)
		{
			//gemoDream.Service.debug_DiaspalyDataSet(dsDocOperations);

			this.bInitDocz = true;

			DataView dvDocOperationsA = new DataView(dsDocOperations.Tables["DocsByCP"]);
			//dvDocOperationsA.Sort = "nOrder";

			DataView dvDocOperationsB = new DataView(dsDocOperations.Tables["DocsByCP"]/*.Copy()*/);
			//dvDocOperationsB.Sort = "nOrder";

			DataView dvDocOperationsC = new DataView(dsDocOperations.Tables["DocsByCP"]/*.Copy()*/);
			//dvDocOperationsC.Sort = "nOrder";

			DataView dvDocOperationsD = new DataView(dsDocOperations.Tables["DocsByCP"]/*.Copy()*/);
			//dvDocOperationsD.Sort = "nOrder";
			
			DataView dvDocOperationsE = new DataView(dsDocOperations.Tables["DocsByCP"]/*.Copy()*/);
			
			DataView dvDocOperationsF = new DataView(dsDocOperations.Tables["DocsByCP"]/*.Copy()*/);			
			
			cbDoc1.DataSource = dvDocOperationsA;
			//dsDocs.Tables["DocsByCP"].Copy();
			cbDoc1.ValueMember = "OperationTypeOfficeID_OperationTypeID";
			//cbDoc1.DisplayMember = "DocumentName";
			cbDoc1.DisplayMember = "OperationTypeName";
			//cbDoc1.ValueMember = ""

			cbDoc2.DataSource = dvDocOperationsB;
			//dsDocs.Tables["DocsByCP"].Copy();
			cbDoc2.ValueMember = "OperationTypeOfficeID_OperationTypeID";
			//cbDoc2.DisplayMember = "DocumentName";
			cbDoc2.DisplayMember = "OperationTypeName";

			cbDoc3.DataSource = dvDocOperationsC;
			//dsDocs.Tables["DocsByCP"].Copy();
			cbDoc3.ValueMember = "OperationTypeOfficeID_OperationTypeID";
			//cbDoc3.DisplayMember = "DocumentName";
			cbDoc3.DisplayMember = "OperationTypeName";

			cbDoc4.DataSource = dvDocOperationsD;
			//dsDocs.Tables["DocsByCP"].Copy();
			cbDoc4.ValueMember = "OperationTypeOfficeID_OperationTypeID";
			//cbDoc4.DisplayMember = "DocumentName";
			cbDoc4.DisplayMember = "OperationTypeName";

			cbDoc5.DataSource = dvDocOperationsE;
			//dsDocs.Tables["DocsByCP"].Copy();
			cbDoc5.ValueMember = "OperationTypeOfficeID_OperationTypeID";
			//cbDoc4.DisplayMember = "DocumentName";
			cbDoc5.DisplayMember = "OperationTypeName";

			cbDoc6.DataSource = dvDocOperationsF;
			//dsDocs.Tables["DocsByCP"].Copy();
			cbDoc6.ValueMember = "OperationTypeOfficeID_OperationTypeID";
			//cbDoc4.DisplayMember = "DocumentName";
			cbDoc6.DisplayMember = "OperationTypeName";
			
			this.bInitDocz = false;

			//cbDoc1.SelectedIndex = -1;
			//cbDoc2.SelectedIndex = -1;
			//cbDoc3.SelectedIndex = -1;
			//cbDoc4.SelectedIndex = -1;
		}

		private void ptPartTree_Changed_1(object sender, System.EventArgs e)
		{
			pnlPartProps.Focus();
			DataRow[] drSet = dsParts.Tables["MeasuresByItemType"].Select("PartTypeID = '" + ptPartTree.SelectedRow["PartTypeID"] + "'", "MeasureTitle");

			currentPartTypeID = Convert.ToInt32(ptPartTree.SelectedRow["ID"]);
			CreateCharacteristic(drSet);
		}

		private void CreateCharacteristic(DataRow[] drSet)
		{
			DataRow[] dCurMin;
			DataRow[] dCurMax;
			DataRow[] dNotVisible;
			DataRow[] dIsDefaultMeasureValue;

			pnlPartProps.Controls.Clear();
#if DEBUG
			// For debugging only			
			string filename = "C:/DELL/mySkuRules.xml";
			if (System.IO.File.Exists(filename)) System.IO.File.Delete(filename);
			// Create the FileStream to write with.
			System.IO.FileStream myFileStream = new System.IO.FileStream(filename, System.IO.FileMode.Create);
			// Create an XmlTextWriter with the fileStream.
			System.Xml.XmlTextWriter myXmlWriter = new System.Xml.XmlTextWriter(myFileStream, System.Text.Encoding.Unicode);
			// Write to the file with the WriteXml method.
			dsRulez.WriteXml(myXmlWriter);
			myXmlWriter.Close();
			// End of debugging part
#endif

			foreach (DataRow row in drSet)
			{
				if(row["MeasureClass"].ToString() == "1" || row["MeasureClass"].ToString() == "3")
				{
					PartPropControl ppcNew = new PartPropControl();
					ppcNew.tbPropName.Text = row["MeasureTitle"].ToString();
					ppcNew.Leave += new EventHandler(pnlPartProps_Leave);
					ppcNew.Tag = row["MeasureID"];						
					dCurMin = dsRulez.Tables[0].Select("MeasureID=" + ppcNew.Tag.ToString() + " and PartID=" + currentPartTypeID.ToString());
					dCurMax = dsRulez.Tables[0].Select("MeasureID=" + ppcNew.Tag.ToString() + " and PartID=" + currentPartTypeID.ToString());
					dNotVisible = dsRulez.Tables[0].Select("MeasureID=" + ppcNew.Tag.ToString() + " and PartID=" + currentPartTypeID.ToString());
					dIsDefaultMeasureValue = dsRulez.Tables[0].Select("MeasureID=" + ppcNew.Tag.ToString() + " and PartID=" + currentPartTypeID.ToString());

					//mvs
					//string s1 = ppcNew.Tag.ToString();
					//string s2 = currentPartTypeID.ToString();
					//System.Diagnostics.Trace.WriteLine("MeasureID=" + ppcNew.Tag.ToString() + " and PartID=" + currentPartTypeID.ToString());
					//gemoDream.Service.debug_DiaspalyDataSet(dsRulez);

					if (dNotVisible.Length > 0 && !dNotVisible[0].IsNull("NotVisibleInCCM"))
					{
						if (dNotVisible[0]["NotVisibleInCCM"].ToString() == "1")
							ppcNew.chbDo2.Checked = true;
						else
							ppcNew.chbDo2.Checked = false;
					}
					// for visual debug
					/*
					else
					{
						gemoDream.Service.debug_DiaspalyDataSet(dsRulez);
					}
					*/

					if (dIsDefaultMeasureValue.Length > 0 && !dIsDefaultMeasureValue[0].IsNull("IsDefaultMeasureValue"))
					{
						if (dNotVisible[0]["IsDefaultMeasureValue"].ToString() == "1")
							ppcNew.chbDo3.Checked = true;
						else
							ppcNew.chbDo3.Checked = false;
						if (dNotVisible[0]["IsDefaultMeasureValue"].ToString() == "2")
						{
							//ppcNew.chbDo3.Checked = false;
							ppcNew.chbDo4.Checked = true;
						}
						//else
						//	ppcNew.chbDo3.Checked = false;
					}
					/*
					else
					{
						gemoDream.Service.debug_DiaspalyDataSet(dsRulez);
					}
					*/


					switch (row["MeasureClass"].ToString()) 
					{
						case "1":
							
							DataTable dtComboSource = dsData.Tables[0].Clone();
							DataRow[] aRows = dsData.Tables[0].Select("MeasureCode=" + row["MeasureCode"].ToString());
							for(int i = 0; i < aRows.Length; i++)
								dtComboSource.Rows.Add(aRows[i].ItemArray);						

							ppcNew.cbMinValue.Show();
							ppcNew.cbMaxValue.Show();
							ppcNew.tbMinValue.Hide();
							ppcNew.tbMaxValue.Hide();
						
							ppcNew.cbMinValue.DataSource = dtComboSource.Copy();
							ppcNew.cbMaxValue.DataSource = dtComboSource.Copy();
							ppcNew.cbMinValue.ValueMember = "MeasureValueID";
							ppcNew.cbMaxValue.ValueMember = "MeasureValueID";
//                            ppcNew.cbMinValue.Tag = "nOrder";
//                            ppcNew.cbMaxValue.Tag = "nOrder";
							ppcNew.cbMinValue.DisplayMember = "MeasureValueName";					
							ppcNew.cbMaxValue.DisplayMember = "MeasureValueName";					

							if (dCurMin.Length > 0 && !dCurMin[0].IsNull("MinMeasure"))
							{
								ppcNew.cbMinValue.SelectedValue = Convert.ToInt32(dCurMin[0]["MinMeasure"]);
								ppcNew.chbDo.Checked = true;
							}
							else
								ppcNew.cbMinValue.SelectedIndex = -1;

							if (dCurMax.Length > 0 && !dCurMax[0].IsNull("MaxMeasure"))
							{
								ppcNew.cbMaxValue.SelectedValue = Convert.ToInt32(dCurMax[0]["MaxMeasure"]);
								ppcNew.chbDo.Checked = true;
							}
							else
								ppcNew.cbMaxValue.SelectedIndex = -1;

							ppcNew.cbMinValue.SelectedIndexChanged += new System.EventHandler(this.onMinComboBox);
							break;

						case "3":
							ppcNew.cbMinValue.Hide();
							ppcNew.cbMaxValue.Hide();
							ppcNew.tbMinValue.Show();
							ppcNew.tbMaxValue.Show();
						
							if (dCurMin.Length > 0 && !dCurMin[0].IsNull("MinMeasure"))
							{
								string str = dCurMin[0]["MinMeasure"].ToString();
								if (str.Equals("0"))
									ppcNew.tbMinValue.Text = ".00";
								else
									ppcNew.tbMinValue.Text = Convert.ToDouble(dCurMin[0]["MinMeasure"]).ToString(".####");
								ppcNew.chbDo.Checked = true;
							}

							if (dCurMax.Length > 0 && !dCurMax[0].IsNull("MaxMeasure"))
							{
								string str = dCurMin[0]["MaxMeasure"].ToString();
								if (str.Equals("0"))
									ppcNew.tbMaxValue.Text = ".00";
								else
									ppcNew.tbMaxValue.Text = Convert.ToDouble(dCurMin[0]["MaxMeasure"]).ToString(".####");
								ppcNew.chbDo.Checked = true;
							}

							break;

						default: continue;
					}
					if(pnlPartProps.Controls.Count > 0)
						ppcNew.Location = new Point(5, pnlPartProps.Controls[pnlPartProps.Controls.Count - 1].Location.Y + 21);
					else
						ppcNew.Location = new Point(5, 1);
					if (ppcNew.chbDo.Checked)
					{
						ppcNew.chbDo3.Enabled = true;
						ppcNew.chbDo4.Enabled = true;
					}
					else
					{
						ppcNew.chbDo3.Enabled = false;
						ppcNew.chbDo4.Enabled = false;
					}
					pnlPartProps.Controls.Add(ppcNew);

					pnlPartProps.ScrollControlIntoView(ppcNew);
					//ppcNew.Dispose();
					//ppcNew = null;
				}
			}
			GC.Collect();
			GC.WaitForPendingFinalizers();
			GC.Collect();
		}

		private void DoMinMaxCorrect(PartPropControl ppc)
		{
			double mind;
			double maxd;
			int mini;
			int maxi;
            DataRow[] dRow;

			if(ppc.tbMinValue.Visible)
			{
				mind = Convert.ToDouble(ppc.tbMinValue.Text);
				maxd = Convert.ToDouble(ppc.tbMaxValue.Text);
				if(maxd < mind)
				{
					ppc.tbMaxValue.Text = (mind + 1).ToString();
				}
			}
			else
			{
                mini = Convert.ToInt32(ppc.cbMinValue.SelectedValue);
			    maxi = Convert.ToInt32(ppc.cbMaxValue.SelectedValue);
				dRow = ((DataTable)(ppc.cbMinValue.DataSource)).Select("MeasureValueID = " + mini);
                
                if(dRow.Length > 0) mini = Convert.ToInt32(dRow[0]["nOrder"].ToString());
                dRow = ((DataTable)(ppc.cbMaxValue.DataSource)).Select("MeasureValueID = " + maxi);
                if(dRow.Length > 0) maxi = Convert.ToInt32(dRow[0]["nOrder"].ToString());

				if(maxi < mini)
				{
					ppc.cbMaxValue.SelectedValue = 
						Convert.ToInt32(((DataTable)(ppc.cbMaxValue.DataSource)).Rows[((DataTable)(ppc.cbMaxValue.DataSource)).Rows.Count - 1]["MeasureValueID"]);
				}
			}	
		}

		private void pnlPartProps_Leave(object sender, System.EventArgs e)
		{
			PartPropControl ppCurrent = new PartPropControl();
			try
			{
				ppCurrent = (PartPropControl)sender;
			}
			catch (Exception ex)
			{
				var a = ex.Message;
				return;
			}
			double mind;
			double maxd;
			int mini;
			int maxi;
			//for(int i = 0; i < pnlPartProps.Controls.Count; i++)
		{
			mind = maxd = - 1;
			mini = maxi = -1;
			//ppCurrent = (PartPropControl)pnlPartProps.Controls[i];
			try
			{
				DoMinMaxCorrect(ppCurrent);
			}
			catch(Exception exc)
			{
					var a = exc.Message;
					//Console.WriteLine(exc.Message);
			}

			try
			{
				if(ppCurrent.tbMinValue.Visible)
				{
					if (ppCurrent.tbMinValue.Text.ToString().Equals(""))
						mind = 0.0;
					else
						mind = Convert.ToDouble(ppCurrent.tbMinValue.Text);
					if (ppCurrent.tbMaxValue.Text.ToString().Equals(""))
						maxd = 0.0;
					else
						maxd = Convert.ToDouble(ppCurrent.tbMaxValue.Text);
				}
				else
				{
					// ??
					//if (ppCurrent.cbMinValue.
					mini = Convert.ToInt32(ppCurrent.cbMinValue.SelectedValue);
					maxi = Convert.ToInt32(ppCurrent.cbMaxValue.SelectedValue);
				}
					
				DataRow[] aRow = dsRulez.Tables[0].Select("MeasureID=" + ppCurrent.Tag.ToString() + " and PartID=" + currentPartTypeID.ToString());

				//if(ppCurrent.chbDo.Checked && ((mini != -1 && maxi != -1) || (mind != -1 && maxd != -1)))
				if(ppCurrent.chbDo.Checked)
				{						
					if(aRow.Length == 0)
					{
						dsRulez.Tables[0].Rows.Add(dsRulez.Tables[0].NewRow());
						dsRulez.Tables[0].Rows[dsRulez.Tables[0].Rows.Count - 1]["MeasureID"] = Convert.ToInt32(ppCurrent.Tag);
						dsRulez.Tables[0].Rows[dsRulez.Tables[0].Rows.Count - 1]["PartID"] = Convert.ToInt32(currentPartTypeID);
						dsRulez.Tables[0].Rows[dsRulez.Tables[0].Rows.Count - 1]["MinMeasure"] =
							ppCurrent.cbMinValue.Visible ? Convert.ToDouble(mini) : Convert.ToDouble(mind);
						dsRulez.Tables[0].Rows[dsRulez.Tables[0].Rows.Count - 1]["MaxMeasure"] =
							ppCurrent.cbMaxValue.Visible ? Convert.ToDouble(maxi) : Convert.ToDouble(maxd);
						/*
							//E.B.M.
							if(ppCurrent.chbDo2.Checked)
								dsRulez.Tables[0].Rows[dsRulez.Tables[0].Rows.Count - 1]["NEWCOLLNAME1"] ="sdsd";
							else
								dsRulez.Tables[0].Rows[dsRulez.Tables[0].Rows.Count - 1]["NEWCOLLNAME1"] ="sdsd";
							if(ppCurrent.chbDo3.Checked)
								dsRulez.Tables[0].Rows[dsRulez.Tables[0].Rows.Count - 1]["NEWCOLLNAME2"] ="sdsd";
							else
								dsRulez.Tables[0].Rows[dsRulez.Tables[0].Rows.Count - 1]["NEWCOLLNAME2"] ="sdsd";
							//E.B.M.
							*/
					}
					else
					{
						aRow[0]["PartID"] = Convert.ToInt32(currentPartTypeID);
						aRow[0]["MinMeasure"] =
							ppCurrent.cbMinValue.Visible ? Convert.ToDouble(mini) : Convert.ToDouble(mind);
						//ppCurrent.cbMinValue.Visible ? Convert.ToDouble(ppCurrent.cbMinValue.SelectedValue) : Convert.ToDouble(mind);
						aRow[0]["MaxMeasure"] =
							ppCurrent.cbMaxValue.Visible ? Convert.ToDouble(maxi) : Convert.ToDouble(maxd);
						//ppCurrent.cbMaxValue.Visible ? Convert.ToDouble(ppCurrent.cbMaxValue.SelectedValue) : Convert.ToDouble(maxd);
					}
				}
				else
				{
					dsRulez.Tables[0].Rows.Remove(aRow[0]);
				}
			}
			catch(Exception exc)
			{
					var a = exc.Message;
					//Console.WriteLine(exc.Message);
			}

			try
			{
				DataRow[] aRow = dsRulez.Tables[0].Select("MeasureID=" + ppCurrent.Tag.ToString() + " and PartID=" + currentPartTypeID.ToString());
				if (ppCurrent.chbDo2.Checked)
				{
					if (aRow.Length == 0)
					{
						dsRulez.Tables[0].Rows.Add(dsRulez.Tables[0].NewRow());
						dsRulez.Tables[0].Rows[dsRulez.Tables[0].Rows.Count - 1]["MeasureID"] = Convert.ToInt32(ppCurrent.Tag);
						dsRulez.Tables[0].Rows[dsRulez.Tables[0].Rows.Count - 1]["PartID"] = Convert.ToInt32(currentPartTypeID);
						dsRulez.Tables[0].Rows[dsRulez.Tables[0].Rows.Count - 1]["NotVisibleInCCM"] = 1;//"1";
					}
					else
					{
						aRow[0]["NotVisibleInCCM"] = 1;
					}
				}
				else
				{
					if (aRow.Length == 0)
					{
						dsRulez.Tables[0].Rows.Add(dsRulez.Tables[0].NewRow());
						dsRulez.Tables[0].Rows[dsRulez.Tables[0].Rows.Count - 1]["MeasureID"] = Convert.ToInt32(ppCurrent.Tag);
						dsRulez.Tables[0].Rows[dsRulez.Tables[0].Rows.Count - 1]["PartID"] = Convert.ToInt32(currentPartTypeID);
						dsRulez.Tables[0].Rows[dsRulez.Tables[0].Rows.Count - 1]["NotVisibleInCCM"] = 0;//"1";
					}
					else
					{
						aRow[0]["NotVisibleInCCM"] = 0;
					}
				}
			}
			catch(Exception exc)
			{
					var a = exc.Message;
					//Console.WriteLine(exc.Message);
			}

			try
			{
				DataRow[] aRow = dsRulez.Tables[0].Select("MeasureID=" + ppCurrent.Tag.ToString() + " and PartID=" + currentPartTypeID.ToString());
				if (ppCurrent.chbDo.Checked && ppCurrent.chbDo3.Checked && ppCurrent.chbDo3.Enabled)
				{
					if (aRow.Length == 0)
					{
						dsRulez.Tables[0].Rows.Add(dsRulez.Tables[0].NewRow());
						dsRulez.Tables[0].Rows[dsRulez.Tables[0].Rows.Count - 1]["MeasureID"] = Convert.ToInt32(ppCurrent.Tag);
						dsRulez.Tables[0].Rows[dsRulez.Tables[0].Rows.Count - 1]["PartID"] = Convert.ToInt32(currentPartTypeID);
						dsRulez.Tables[0].Rows[dsRulez.Tables[0].Rows.Count - 1]["IsDefaultMeasureValue"] = 1;
					}
					else
					{
						aRow[0]["IsDefaultMeasureValue"] = 1;
					}
				}
				else
				{
					if (aRow.Length == 0)
					{
						dsRulez.Tables[0].Rows.Add(dsRulez.Tables[0].NewRow());
						dsRulez.Tables[0].Rows[dsRulez.Tables[0].Rows.Count - 1]["MeasureID"] = Convert.ToInt32(ppCurrent.Tag);
						dsRulez.Tables[0].Rows[dsRulez.Tables[0].Rows.Count - 1]["PartID"] = Convert.ToInt32(currentPartTypeID);
						dsRulez.Tables[0].Rows[dsRulez.Tables[0].Rows.Count - 1]["IsDefaultMeasureValue"] = 0;//"1";
					}
					else
					{
						aRow[0]["IsDefaultMeasureValue"] = 0;
					}
				}
					if (ppCurrent.chbDo.Checked && ppCurrent.chbDo4.Checked && ppCurrent.chbDo4.Enabled)
					{
						if (aRow.Length == 0)
						{
							dsRulez.Tables[0].Rows.Add(dsRulez.Tables[0].NewRow());
							dsRulez.Tables[0].Rows[dsRulez.Tables[0].Rows.Count - 1]["MeasureID"] = Convert.ToInt32(ppCurrent.Tag);
							dsRulez.Tables[0].Rows[dsRulez.Tables[0].Rows.Count - 1]["PartID"] = Convert.ToInt32(currentPartTypeID);
							dsRulez.Tables[0].Rows[dsRulez.Tables[0].Rows.Count - 1]["IsDefaultMeasureValue"] = 2;
						}
						else
						{
							aRow[0]["IsDefaultMeasureValue"] = 2;
						}
					//}
					//else
					//{
					//	if (aRow.Length == 0)
					//	{
					//		dsRulez.Tables[0].Rows.Add(dsRulez.Tables[0].NewRow());
					//		dsRulez.Tables[0].Rows[dsRulez.Tables[0].Rows.Count - 1]["MeasureID"] = Convert.ToInt32(ppCurrent.Tag);
					//		dsRulez.Tables[0].Rows[dsRulez.Tables[0].Rows.Count - 1]["PartID"] = Convert.ToInt32(currentPartTypeID);
					//		dsRulez.Tables[0].Rows[dsRulez.Tables[0].Rows.Count - 1]["IsDefaultMeasureValue"] = 0;//"1";
					//	}
					//	else
					//	{
					//		aRow[0]["IsDefaultMeasureValue"] = 0;
					//	}
					}

				}
			catch(Exception exc)
			{
					var a = exc.Message;
					//Console.WriteLine(exc.Message);
			}

			try
			{
				DataRow[] aRow = dsRulez.Tables[0].Select("MeasureID=" + ppCurrent.Tag.ToString() + " and PartID=" + currentPartTypeID.ToString());
				if (aRow.Length > 0 && !ppCurrent.chbDo.Checked && 
					!ppCurrent.chbDo2.Checked && !ppCurrent.chbDo3.Enabled)
				{
					dsRulez.Tables[0].Rows.Remove(aRow[0]);
				}
			}
			catch (Exception exc)
			{
					var a = exc.Message;
					//Console.WriteLine(exc.Message);			
			}
			}
			}

		private void comboBoxDocument(object sender, System.EventArgs e)
		{
			CheckSameDocs(sender);
		}		

		private void CheckSameDocs(object sender)
		{
			/*
			bool isSame = false;
			ComboBox[] acbDocs = new ComboBox[] {cbDoc1, cbDoc2, cbDoc3, cbDoc4};
			CheckBox[] chbDocs = new CheckBox[] {chbPrintDoc1, chbPrintDoc2, chbPrintDoc3, chbPrintDoc4};
			for(int i = 0; i < acbDocs.Length; i++)
			{
				if((ComboBox)sender != acbDocs[i])
				{
					if(((ComboBox)sender).SelectedValue == acbDocs[i].SelectedValue && chbDocs[i].Checked==true)
						isSame = true;
				}
			}
			if(isSame && ((ComboBox)sender).SelectedIndex > -1)
			{
				((ComboBox)sender).SelectedIndex--;
			}
			*/
		}

		public bool IsRulesEmpty()
		{
			if (dsRulez == null)
				return true;

			if (dsRulez.Tables[0].Rows.Count > 0)
				return false;
			else
				return true;
		}

		public DataSet GetRulez()
		{
			return this.dsRulez.Copy();
		}

		/*
		private string AddOperation(ComboBox comboBox, string sItemTypeID, string sPath2Picture, string sOperationTypeName)
		{
			DefineDocumentForm defDocForm;
			if (this.sCPOfficeID != null && this.sCPOfficeID.Length != 0)
			{
				defDocForm = new DefineDocumentForm(sItemTypeID, sPath2Picture, sOperationTypeName, sCPOfficeID,
					sCPID);
			}
			else
			{
				defDocForm = new DefineDocumentForm(sItemTypeID, sPath2Picture, sOperationTypeName);
			}
			defDocForm.ShowDialog(this);
			string sDocumentID = defDocForm.GetDocumentID();
			if (sDocumentID == null)
				return null;

			//this.iDocumentsCount++;
			
			string sOperationTypeOfficeID_OperationTypeID = defDocForm.GetOperationTypeOfficeID_OperationTypeID();
			if (sOperationTypeOfficeID_OperationTypeID != null)
			{
				DataView dv = (DataView)comboBox.DataSource;
				DataRow newRow = dv.Table.NewRow();

				newRow["OperationTypeOfficeID_OperationTypeID"] = sOperationTypeOfficeID_OperationTypeID;
				newRow["OperationTypeName"] = sOperationTypeName;
				//newRow["nOrder"] = ;
				dv.Table.Rows.Add(newRow);

				string[] sOperationTypeOfficeID_OperationTypeIDs = sOperationTypeOfficeID_OperationTypeID.Split(separator);
				string sOperationTypeOfficeID = sOperationTypeOfficeID_OperationTypeIDs[1];
				string sOperationTypeID = sOperationTypeOfficeID_OperationTypeIDs[0];
			
				DefineDocumentForm.NewOperationData nod = new DefineDocumentForm.NewOperationData();
				nod.sCPID = sCPID;
				nod.sCPOfficeID = sCPOfficeID;
				nod.sOperationTypeID = sOperationTypeID;
				nod.sOperationTypeOfficeID = sOperationTypeOfficeID;
				this.newOperationsList.Add(nod);
			}

			return sOperationTypeOfficeID_OperationTypeID;
		}
		*/

		private void comboBoxDocument1(object sender, System.EventArgs e)
		{
	
				if (!this.bInitDocz)
				{
					OnComboBoxDocument(cbDoc1, chbShowDoc1);

					//CheckSameDocs(sender);
				}
		}

		private void comboBoxDocument2(object sender, System.EventArgs e)
		{

				if (!this.bInitDocz)
				{
					OnComboBoxDocument(cbDoc2, chbShowDoc2);

				//CheckSameDocs(sender);
				}
		}

		private void comboBoxDocument3(object sender, System.EventArgs e)
		{
				if (!this.bInitDocz)
				{
					OnComboBoxDocument(cbDoc3, chbShowDoc3);

					//CheckSameDocs(sender);
				}
		}

		private void comboBoxDocument4(object sender, System.EventArgs e)
		{
				if (!this.bInitDocz)
				{
					OnComboBoxDocument(cbDoc4, chbShowDoc4);

					//CheckSameDocs(sender);
				}
		}
		
		private void comboBoxDocument5(object sender, System.EventArgs e)
		{
				if (!this.bInitDocz)
				{
					OnComboBoxDocument(cbDoc5, chbShowDoc5);

					//CheckSameDocs(sender);
				}
	
		}

		private void comboBoxDocument6(object sender, System.EventArgs e)
		{

				if (!this.bInitDocz)
				{
					OnComboBoxDocument(cbDoc6, chbShowDoc6);

					//CheckSameDocs(sender);
				}
	
		}

	
		//		DefineDocumentForm.DefDocType GetDocTypeCode(string sID)
		//		{
		//			if (sID.Equals("-3_3"))
		//				return DefineDocumentForm.DefDocType.MDX;
		//			if (sID.Equals("-2_2"))
		//				return DefineDocumentForm.DefDocType.FDX;
		//			return DefineDocumentForm.DefDocType.IDX;
		//		}

		private void onMinComboBox(object sender, System.EventArgs e)
		{
			Control cntrl = (Control)sender;

			foreach (Control c in pnlPartProps.Controls)
			{
				PartPropControl ppc = (PartPropControl)c;
				if (ppc.Contains(cntrl))
				{
					ppc.cbMaxValue.SelectedValue = ppc.cbMinValue.SelectedValue;
					break;
				}
			}
		}


		private void OnComboBoxDocument(ComboBox comboBox, CheckBox chbShowDoc)
		{
			//if (this.iAccessLevel > 2)
		
			if (comboBox.SelectedValue != null)
			{
				DataView dv = (DataView)comboBox.DataSource;
				DataTable dt = dv.Table.Copy();
				string sID = comboBox.SelectedValue.ToString();
				DataRow[] foundRows;
				foundRows = dt.Select("OperationTypeOfficeID_OperationTypeID = '" + sID + "'");
				string sItemTypeID = this.sItemTypeID;
				string sPath2Picture = this.sPath2Picture;
				string sDocumentID = "";
				string sDocTypeCode = null;
				string sOperationTypeName = null;
				string sOperationTypeID = null;
				if(foundRows.Length == 1)
				{
					sDocTypeCode = foundRows[0]["DocumentTypeCode"].ToString(); 
					sOperationTypeName = foundRows[0]["OperationTypeName"].ToString();
					sOperationTypeID = foundRows[0]["OperationTypeOfficeID_OperationTypeID"].ToString();
				}
				else
					return;

				if (Service.IsMagicOperation(sID) || chbShowDoc.Checked == true)
				{
//					chbShowDoc.Checked = false;
					int iDocumentsCountA;
					if (this.sCPID == null || this.sCPID.Length == 0)
						iDocumentsCountA = this.newOperationsList.Count + 1;
					else
					{
						iDocumentsCountA = Service.GetDocumentsCount(this.sCPOfficeID, sCPID);//Procedure dbo.spGetCustomerProgramDocumentsCount
						iDocumentsCountA++;
						//iDocumentsCountA = iDocumentsCount + 1;
					}
////					string sOperationTypeName = comboBox.Text;
////
////					string sOperationTypeID = sID;

					//DefineDocumentForm.DocTypeCode docTypeCode = DefineDocumentForm.GetDocTypeCodeEnumByID(sID);

					DataSet dsNotVCCM = this.GetRulez();

					string CPOfficeID_CPID = null;
					if (sCPOfficeID.Length != 0 && sCPID.Length != 0)
						CPOfficeID_CPID = String.Format("{0}_{1}", sCPOfficeID, sCPID);
					/*

					*/

					
					string sCPName = this.sCPName;
					if(this.iAccessLevel > 2)
					{
						sDocumentID = gemoDream.DefineDocumentForm.AddOperation(	
							this.iAccessLevel,
							dsNotVCCM,
							this.newOperationsList, 
							CPOfficeID_CPID, 
							this,
							comboBox, 
							sItemTypeID, 
							sPath2Picture, 
							sOperationTypeName, 
							sDocTypeCode,
							sOperationTypeID,
							sCPName);
						if (sDocumentID != null)
						{
							chbShowDoc.Checked = false;
							comboBox.SelectedValue = sDocumentID;
						}
					}

					//else
					//	comboBox.SelectedIndex = 0;
					chbShowDoc.Checked = false;
				}
			}
		}

		//private void button1_Click(object sender, System.EventArgs e)
		//{
		//	if (!this.bInitDocz)
		//	{
		//		if (Service.IsMagicOperation(cbDoc1.SelectedValue.ToString()))
		//		{
		//			OnComboBoxDocument(cbDoc1, chbShowDoc1);
		//		}
		//		else
		//		{
		//			String[] DocId = cbDoc1.SelectedValue.ToString().Split('_');
		//			DataSet ds = Service.GetDocument(null);
		//			DataRow[] dr = ds.Tables[0].Select("OperationTypeID='" + DocId[1] + "'");
		//			MessageBox.Show("wait implements");
		//		}
		//	}		
		//}

		private void chbShowDoc1_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chbShowDoc1.Checked)
			{
				//				chbShowDoc2.Checked = false;
				//				chbShowDoc3.Checked = false;
				//				chbShowDoc4.Checked = false;
				//				chbShowDoc5.Checked = false;
				//				chbShowDoc6.Checked = false;

				comboBoxDocument1(sender, e);
			}		
		}

		private void chbShowDoc2_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chbShowDoc2.Checked)
			{
				//				chbShowDoc2.Checked = false;
				//				chbShowDoc3.Checked = false;
				//				chbShowDoc4.Checked = false;
				//				chbShowDoc5.Checked = false;
				//				chbShowDoc6.Checked = false;

				comboBoxDocument2(sender, e);
			}		
		}

		private void chbShowDoc3_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chbShowDoc3.Checked)
			{
				//				chbShowDoc2.Checked = false;
				//				chbShowDoc3.Checked = false;
				//				chbShowDoc4.Checked = false;
				//				chbShowDoc5.Checked = false;
				//				chbShowDoc6.Checked = false;

				comboBoxDocument3(sender, e);
			}		
		}

		private void chbShowDoc4_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chbShowDoc4.Checked)
			{
				//				chbShowDoc2.Checked = false;
				//				chbShowDoc3.Checked = false;
				//				chbShowDoc4.Checked = false;
				//				chbShowDoc5.Checked = false;
				//				chbShowDoc6.Checked = false;

				comboBoxDocument4(sender, e);
			}		
		}

		private void chbShowDoc5_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chbShowDoc5.Checked)
			{
				//				chbShowDoc2.Checked = false;
				//				chbShowDoc3.Checked = false;
				//				chbShowDoc4.Checked = false;
				//				chbShowDoc5.Checked = false;
				//				chbShowDoc6.Checked = false;

				comboBoxDocument5(sender, e);
			}		
		}

		private void chbShowDoc6_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chbShowDoc6.Checked)
			{
				//				chbShowDoc2.Checked = false;
				//				chbShowDoc3.Checked = false;
				//				chbShowDoc4.Checked = false;
				//				chbShowDoc5.Checked = false;
				//				chbShowDoc6.Checked = false;

				comboBoxDocument6(sender, e);
			}		
		}
		private void UpdateNotVisibleInCCM(string PartID, bool check)
		{
			try
			{
				//DataRow[] drParameters = dsRulez.Tables[0].Select("PartID = '" + ptPartTree.SelectedNode.ImageKey + "'");
				foreach (PartPropControl temp in pnlPartProps.Controls)
				{
					temp.chbDo2.Checked = check;
					{
						DataRow[] aRow = dsRulez.Tables[0].Select("MeasureID=" + temp.Tag.ToString() + " and PartID=" + PartID.ToString());
						if (temp.chbDo2.Checked)
						{
							if (aRow.Length == 0)
							{
								dsRulez.Tables[0].Rows.Add(dsRulez.Tables[0].NewRow());
								dsRulez.Tables[0].Rows[dsRulez.Tables[0].Rows.Count - 1]["MeasureID"] = Convert.ToInt32(temp.Tag);
								dsRulez.Tables[0].Rows[dsRulez.Tables[0].Rows.Count - 1]["PartID"] = Convert.ToInt32(PartID);
								dsRulez.Tables[0].Rows[dsRulez.Tables[0].Rows.Count - 1]["NotVisibleInCCM"] = 1;//"1";
							}
							else
							{
								aRow[0]["NotVisibleInCCM"] = 1;
							}
						}
						else
						{
							if (aRow.Length == 0)
							{
								dsRulez.Tables[0].Rows.Add(dsRulez.Tables[0].NewRow());
								dsRulez.Tables[0].Rows[dsRulez.Tables[0].Rows.Count - 1]["MeasureID"] = Convert.ToInt32(temp.Tag);
								dsRulez.Tables[0].Rows[dsRulez.Tables[0].Rows.Count - 1]["PartID"] = Convert.ToInt32(PartID);
								dsRulez.Tables[0].Rows[dsRulez.Tables[0].Rows.Count - 1]["NotVisibleInCCM"] = 0;//"1";
							}
							else
							{
								aRow[0]["NotVisibleInCCM"] = 0;
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				var a = ex.Message;
			}
		}

		private void cmd_Select_Click(object sender, EventArgs e)
		{
			var PartID = ptPartTree.SelectedNode.ImageKey;
			UpdateNotVisibleInCCM(PartID, true);
		}

		private void cmd_UnSelect_Click(object sender, EventArgs e)
		{
			var PartID = ptPartTree.SelectedNode.ImageKey;
			UpdateNotVisibleInCCM(PartID, false);
		}
	}
}
