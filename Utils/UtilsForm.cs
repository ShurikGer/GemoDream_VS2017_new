using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Cntrls;
using System.Text.RegularExpressions;

namespace gemoDream
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class UtilsForm : System.Windows.Forms.Form
    {
        enum Reports
        {
            FRONT_LABEL = 0,
            FRONT_EXT_RECEIPT = 1,
            FRONT_ITEMS_SELECTED = 2,
            ITEMIZING_BATCH_LABEL = 3,
            ITEMIZING_ITEM_LABEL = 4,
            ITEMIZING_INTERNAL_RECEIPT = 5,
            CP_CP = 6,
            ITEMIZING_SARIN_LABELS = 7
        }
        public enum FilterState
        {
            NotValid = 1,
            Valid = 2,
            NotEntered = 3
        }

        /*
        private class PictureAndPath
        {
            public Image imPicture;
            public string sPath2Picture;
            public Image imIcon;
            public string sPath2Icon;
        }
        */

        private DataSet dsItemProperties = new DataSet();
        //private DataSet ds = new DataSet();

        //private bool 

        private bool IsReinit = false;
        private bool IsFirst = false;

        private string sItemName = null;
        private bool IsSaveCopy = true;

        private bool IsInit = false;

        private DataView dvPartTypes = null;
        private DataView dvItemContainer = null;
        private DataSet dsPartTypes = null;

        #region Controls

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox textBox23;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox textBox17;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.ColumnHeader colorG;
        private System.Windows.Forms.ColumnHeader enbld;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.ColumnHeader polyID;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.RadioButton rbUnfixed;
        private System.Windows.Forms.RadioButton rbFixed;
        private System.Windows.Forms.Panel gbFixed;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox tbFixedP;
        private System.Windows.Forms.RadioButton rbFixedP;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox tbFixedB;
        private System.Windows.Forms.RadioButton rbFixedB;
        private System.Windows.Forms.Panel gbUnfixed;
        private System.Windows.Forms.Label label34;
        private Cntrls.PartTree ptShapes;
        private Cntrls.Price price1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.Label label81;
        private System.Windows.Forms.Label label82;
        private System.Windows.Forms.Label label83;
        private System.Windows.Forms.Label label84;
        private System.Windows.Forms.Label label85;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.Label label87;
        private System.Windows.Forms.Label label88;
        private System.Windows.Forms.Label label89;
        private System.Windows.Forms.Label label90;
        private System.Windows.Forms.Label label91;
        private System.Windows.Forms.Label label92;
        private System.Windows.Forms.Label label93;
        private System.Windows.Forms.Label label94;
        private System.Windows.Forms.Label label95;
        private System.Windows.Forms.Label label96;
        private System.Windows.Forms.Label label97;
        private System.Windows.Forms.Label label98;
        private System.Windows.Forms.Label label99;
        private System.Windows.Forms.Label label100;
        private System.Windows.Forms.Label label101;
        private System.Windows.Forms.Label label102;
        private System.Windows.Forms.Label label103;
        private System.Windows.Forms.Label label104;
        private System.Windows.Forms.Label label105;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.Label label106;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        //private Cntrls.PartTree ptShapes;
        private System.Windows.Forms.Button bShapesPicturePath;
        private System.Windows.Forms.Button bShapesPrintAll;
        private System.Windows.Forms.Button bShapesPrintSelected;
        private System.Windows.Forms.TextBox tbShapesPicturePath;
        private System.Windows.Forms.ComboBox cbShapesPriceGroup;
        public System.Windows.Forms.PictureBox pbShapesItemPicture;
        private System.Windows.Forms.TextBox tbShapesFullName;
        private System.Windows.Forms.TextBox tbShapesLongReportName;
        private System.Windows.Forms.TextBox tbShapesShortReportName;
        private System.Windows.Forms.TextBox tbShapesSarinGroup;
        private System.Windows.Forms.Button bShapesNew;
        private System.Windows.Forms.Button bShapesUpdate;
        #endregion Controls
        private System.ComponentModel.IContainer components;

        private System.Windows.Forms.StatusBar sbStatus;
        private System.Windows.Forms.Button bUsersSavePwd;
        private System.Windows.Forms.Button bUsersClearPwd;
        private System.Windows.Forms.TextBox tbUsersRetypePwd;
        private System.Windows.Forms.TextBox tbUsersPwd;
        private System.Windows.Forms.TextBox tbUsersLogin;
        private System.Windows.Forms.TextBox tbUsersLastName;
        private System.Windows.Forms.ComboBox cbUsersDepartment;
        private System.Windows.Forms.Button bUsersDelete;
        private System.Windows.Forms.Button bUsersSave;
        private System.Windows.Forms.Button bUsersClearChanges;
        private System.Windows.Forms.TextBox tbUsersComments;
        private System.Windows.Forms.TextBox tbUsersLastOperation;
        private System.Windows.Forms.TextBox tbUsersLastLogin;
        private System.Windows.Forms.TextBox tbUsersFirstLogin;
        private System.Windows.Forms.TextBox tbUsersCreated;
        private System.Windows.Forms.TextBox tbUsersFirstName;
        private System.Windows.Forms.Button bUsersSearchUser;
        private System.Windows.Forms.Button bUsersNewUser;
        private System.Windows.Forms.ListView lvUsers;
        private System.Windows.Forms.ColumnHeader cFirstName;
        private System.Windows.Forms.ColumnHeader cLastName;
        private System.Windows.Forms.ColumnHeader cLogin;
        private System.Windows.Forms.ColumnHeader cDepartment;
        private System.Windows.Forms.ColumnHeader cCreated;
        private System.Windows.Forms.ColumnHeader cFirstLogin;
        private System.Windows.Forms.ColumnHeader cLastLogin;
        private System.Windows.Forms.ColumnHeader cLastOperation;
        private System.Windows.Forms.GroupBox gbDetails;
        private System.Windows.Forms.ComboBox cbUsersRole;
        private System.Windows.Forms.ColumnHeader cRole;
        private System.Windows.Forms.Button bColorsUpdate;
        private System.Windows.Forms.TextBox tbColorsPolygonID;
        private System.Windows.Forms.TextBox tbColorsColorGrade;
        private System.Windows.Forms.Button bColorsNew;
        private System.Windows.Forms.Button bColorsDisable;
        private System.Windows.Forms.ListView lvColorsGrades;
        private System.Windows.Forms.ListBox lbxColorsMeasures;
        private DataRow drInfo;


        private DataTable dtUsers;
        private DataRow drSelected;
        private DataTable dtShapesTree;
        private DataTable dtShapesInfo;
        private Cntrls.PartTree partTree1;
        private DataTable dtMeasures;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpReports;
        private System.Windows.Forms.ListView lvReports;
        private System.Windows.Forms.ColumnHeader hdrForm;
        private System.Windows.Forms.ColumnHeader hdrReport;
        private System.Windows.Forms.TextBox tbReportsGroupOfficeID;
        private System.Windows.Forms.Label lbReportsGroupOfficeID;
        private System.Windows.Forms.Button btnReportsPrint;
        private System.Windows.Forms.TextBox tbReportsItemCode;
        private System.Windows.Forms.Label lbReportsItemCode;
        private System.Windows.Forms.TextBox tbReportsBatchCode;
        private System.Windows.Forms.Label lbReportsBatchCode;
        private System.Windows.Forms.TextBox tbReportsGroupCode;
        private System.Windows.Forms.Label lbReportsGroupCode;
        private System.Windows.Forms.TabPage tbNewStructure;
        private System.Windows.Forms.Label lbStructureNewItemName;
        private System.Windows.Forms.TextBox tbStructureNewItemName;
        private System.Windows.Forms.Button btnStructureNewGroup;
        private System.Windows.Forms.Button btnStructuresDeleteGroup;
        private System.Windows.Forms.Label lbStructureItemPartList;
        private System.Windows.Forms.Button btnStructureMoveItemPart;
        private System.Windows.Forms.ListBox lbStructurePartTypes;
        private System.Windows.Forms.ListBox lbStructureMeasures;
        private System.Windows.Forms.Label lbStructurePicPath;
        private System.Windows.Forms.Label lbStructureItemGroupIconPath;
        private System.Windows.Forms.Label lbStructureItemTypeIconPath;
        private System.Windows.Forms.TextBox tbStructureItemTypeIconPath;
        private System.Windows.Forms.PictureBox pbStructureItemType;
        private System.Windows.Forms.PictureBox pbStructureItemTypeGroup;
        private Cntrls.ItemPanelDynamic ipStructureStructures;
        private Cntrls.PartTreeDynamic ptStructureNewItem;
        private System.Windows.Forms.Button btnStructureDeleteItem;
        private System.Windows.Forms.Button btnStructureSave;
        private System.Windows.Forms.Button btnStructureClear;
        private System.Windows.Forms.Button btnStructureMoveItemPartBack;
        private System.Windows.Forms.TextBox tbStructureItemTypeGroupIconPath;
        private System.Windows.Forms.TextBox tbStructureItemTypePicPath;
        private System.Windows.Forms.ImageList ilStructureItemType;
        private System.Windows.Forms.Label label107;
        private System.Windows.Forms.Label label108;
        private System.Windows.Forms.TextBox tbStructureGroupName;
        private System.Windows.Forms.CheckBox cbStructureIsItemTypeGroupChild;
        private System.Windows.Forms.PictureBox pbStructureItemPicture;
		private TabPage tabPage8;
		private PartTree ptPartTree;
		private ComboTextComponent cbcCustomer;
		private ComboBox comboBox1;
		private TextBox textBox1;
        private int AccessLevel;

        /*
        public UtilsForm()
        {
            InitializeComponent();
            InitPrimaryData();
            Init();
        }
        */

        public UtilsForm(int AccessLevel)
        {
            this.AccessLevel = AccessLevel;
            InitializeComponent();
            InitPrimaryData();

            InitStructure();

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
			components = new System.ComponentModel.Container();
			System.Windows.Forms.ListViewItem listViewItem33 = new System.Windows.Forms.ListViewItem(new string[] {
            "Front",
            "Label"}, -1);
			System.Windows.Forms.ListViewItem listViewItem34 = new System.Windows.Forms.ListViewItem(new string[] {
            "Front",
            "External Receipt"}, -1);
			System.Windows.Forms.ListViewItem listViewItem35 = new System.Windows.Forms.ListViewItem(new string[] {
            "Front",
            "Items selected"}, -1);
			System.Windows.Forms.ListViewItem listViewItem36 = new System.Windows.Forms.ListViewItem(new string[] {
            "Itemizing",
            "Batch Label"}, -1);
			System.Windows.Forms.ListViewItem listViewItem37 = new System.Windows.Forms.ListViewItem(new string[] {
            "Itemizing",
            "Item Label"}, -1);
			System.Windows.Forms.ListViewItem listViewItem38 = new System.Windows.Forms.ListViewItem(new string[] {
            "Itemizing",
            "Internal Receipt"}, -1);
			System.Windows.Forms.ListViewItem listViewItem39 = new System.Windows.Forms.ListViewItem(new string[] {
            "Customer Program",
            "Customer Program"}, -1);
			System.Windows.Forms.ListViewItem listViewItem40 = new System.Windows.Forms.ListViewItem(new string[] {
            "Itemizing",
            "Sarin Label"}, -1);
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UtilsForm));
			tabControl1 = new System.Windows.Forms.TabControl();
			tpReports = new System.Windows.Forms.TabPage();
			tbReportsItemCode = new System.Windows.Forms.TextBox();
			lbReportsItemCode = new System.Windows.Forms.Label();
			tbReportsBatchCode = new System.Windows.Forms.TextBox();
			lbReportsBatchCode = new System.Windows.Forms.Label();
			tbReportsGroupCode = new System.Windows.Forms.TextBox();
			lbReportsGroupCode = new System.Windows.Forms.Label();
			btnReportsPrint = new System.Windows.Forms.Button();
			lvReports = new System.Windows.Forms.ListView();
			hdrForm = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			hdrReport = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			lbReportsGroupOfficeID = new System.Windows.Forms.Label();
			tbReportsGroupOfficeID = new System.Windows.Forms.TextBox();
			tabPage1 = new System.Windows.Forms.TabPage();
			partTree1 = new Cntrls.PartTree();
			tbShapesSarinGroup = new System.Windows.Forms.TextBox();
			tbShapesShortReportName = new System.Windows.Forms.TextBox();
			tbShapesLongReportName = new System.Windows.Forms.TextBox();
			tbShapesFullName = new System.Windows.Forms.TextBox();
			bShapesPicturePath = new System.Windows.Forms.Button();
			bShapesNew = new System.Windows.Forms.Button();
			bShapesUpdate = new System.Windows.Forms.Button();
			bShapesPrintAll = new System.Windows.Forms.Button();
			bShapesPrintSelected = new System.Windows.Forms.Button();
			tbShapesPicturePath = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			cbShapesPriceGroup = new System.Windows.Forms.ComboBox();
			label3 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			pbShapesItemPicture = new System.Windows.Forms.PictureBox();
			tabPage6 = new System.Windows.Forms.TabPage();
			listView1 = new System.Windows.Forms.ListView();
			columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			button22 = new System.Windows.Forms.Button();
			button21 = new System.Windows.Forms.Button();
			label106 = new System.Windows.Forms.Label();
			comboBox6 = new System.Windows.Forms.ComboBox();
			panel1 = new System.Windows.Forms.Panel();
			label105 = new System.Windows.Forms.Label();
			label104 = new System.Windows.Forms.Label();
			label101 = new System.Windows.Forms.Label();
			label100 = new System.Windows.Forms.Label();
			label99 = new System.Windows.Forms.Label();
			label98 = new System.Windows.Forms.Label();
			label96 = new System.Windows.Forms.Label();
			label94 = new System.Windows.Forms.Label();
			label93 = new System.Windows.Forms.Label();
			label92 = new System.Windows.Forms.Label();
			label91 = new System.Windows.Forms.Label();
			label90 = new System.Windows.Forms.Label();
			label89 = new System.Windows.Forms.Label();
			label88 = new System.Windows.Forms.Label();
			label87 = new System.Windows.Forms.Label();
			label86 = new System.Windows.Forms.Label();
			label85 = new System.Windows.Forms.Label();
			label84 = new System.Windows.Forms.Label();
			label83 = new System.Windows.Forms.Label();
			label82 = new System.Windows.Forms.Label();
			label81 = new System.Windows.Forms.Label();
			label80 = new System.Windows.Forms.Label();
			label79 = new System.Windows.Forms.Label();
			label78 = new System.Windows.Forms.Label();
			label77 = new System.Windows.Forms.Label();
			label76 = new System.Windows.Forms.Label();
			label75 = new System.Windows.Forms.Label();
			label74 = new System.Windows.Forms.Label();
			label73 = new System.Windows.Forms.Label();
			label71 = new System.Windows.Forms.Label();
			label70 = new System.Windows.Forms.Label();
			label69 = new System.Windows.Forms.Label();
			label68 = new System.Windows.Forms.Label();
			label67 = new System.Windows.Forms.Label();
			label66 = new System.Windows.Forms.Label();
			label65 = new System.Windows.Forms.Label();
			label64 = new System.Windows.Forms.Label();
			label63 = new System.Windows.Forms.Label();
			label62 = new System.Windows.Forms.Label();
			label61 = new System.Windows.Forms.Label();
			label60 = new System.Windows.Forms.Label();
			label59 = new System.Windows.Forms.Label();
			label58 = new System.Windows.Forms.Label();
			label57 = new System.Windows.Forms.Label();
			label56 = new System.Windows.Forms.Label();
			label55 = new System.Windows.Forms.Label();
			label54 = new System.Windows.Forms.Label();
			label53 = new System.Windows.Forms.Label();
			label52 = new System.Windows.Forms.Label();
			label51 = new System.Windows.Forms.Label();
			label50 = new System.Windows.Forms.Label();
			label49 = new System.Windows.Forms.Label();
			label48 = new System.Windows.Forms.Label();
			label47 = new System.Windows.Forms.Label();
			label46 = new System.Windows.Forms.Label();
			label45 = new System.Windows.Forms.Label();
			label44 = new System.Windows.Forms.Label();
			label43 = new System.Windows.Forms.Label();
			label42 = new System.Windows.Forms.Label();
			label41 = new System.Windows.Forms.Label();
			label40 = new System.Windows.Forms.Label();
			label39 = new System.Windows.Forms.Label();
			label38 = new System.Windows.Forms.Label();
			label37 = new System.Windows.Forms.Label();
			label36 = new System.Windows.Forms.Label();
			label35 = new System.Windows.Forms.Label();
			label72 = new System.Windows.Forms.Label();
			label95 = new System.Windows.Forms.Label();
			label97 = new System.Windows.Forms.Label();
			label102 = new System.Windows.Forms.Label();
			label103 = new System.Windows.Forms.Label();
			tabPage7 = new System.Windows.Forms.TabPage();
			groupBox9 = new System.Windows.Forms.GroupBox();
			rbUnfixed = new System.Windows.Forms.RadioButton();
			rbFixed = new System.Windows.Forms.RadioButton();
			gbFixed = new System.Windows.Forms.Panel();
			label31 = new System.Windows.Forms.Label();
			label32 = new System.Windows.Forms.Label();
			tbFixedP = new System.Windows.Forms.TextBox();
			rbFixedP = new System.Windows.Forms.RadioButton();
			label33 = new System.Windows.Forms.Label();
			tbFixedB = new System.Windows.Forms.TextBox();
			rbFixedB = new System.Windows.Forms.RadioButton();
			gbUnfixed = new System.Windows.Forms.Panel();
			label34 = new System.Windows.Forms.Label();
			tabPage5 = new System.Windows.Forms.TabPage();
			groupBox8 = new System.Windows.Forms.GroupBox();
			bColorsUpdate = new System.Windows.Forms.Button();
			tbColorsPolygonID = new System.Windows.Forms.TextBox();
			tbColorsColorGrade = new System.Windows.Forms.TextBox();
			label29 = new System.Windows.Forms.Label();
			label28 = new System.Windows.Forms.Label();
			bColorsNew = new System.Windows.Forms.Button();
			bColorsDisable = new System.Windows.Forms.Button();
			lvColorsGrades = new System.Windows.Forms.ListView();
			colorG = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			polyID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			enbld = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			groupBox7 = new System.Windows.Forms.GroupBox();
			lbxColorsMeasures = new System.Windows.Forms.ListBox();
			tabPage3 = new System.Windows.Forms.TabPage();
			lvUsers = new System.Windows.Forms.ListView();
			cFirstName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			cLastName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			cLogin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			cDepartment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			cRole = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			cCreated = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			cFirstLogin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			cLastLogin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			cLastOperation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			gbDetails = new System.Windows.Forms.GroupBox();
			cbUsersRole = new System.Windows.Forms.ComboBox();
			groupBox5 = new System.Windows.Forms.GroupBox();
			bUsersSavePwd = new System.Windows.Forms.Button();
			bUsersClearPwd = new System.Windows.Forms.Button();
			tbUsersRetypePwd = new System.Windows.Forms.TextBox();
			label24 = new System.Windows.Forms.Label();
			tbUsersPwd = new System.Windows.Forms.TextBox();
			label25 = new System.Windows.Forms.Label();
			tbUsersLogin = new System.Windows.Forms.TextBox();
			label21 = new System.Windows.Forms.Label();
			tbUsersLastName = new System.Windows.Forms.TextBox();
			label20 = new System.Windows.Forms.Label();
			cbUsersDepartment = new System.Windows.Forms.ComboBox();
			label13 = new System.Windows.Forms.Label();
			bUsersDelete = new System.Windows.Forms.Button();
			bUsersSave = new System.Windows.Forms.Button();
			bUsersClearChanges = new System.Windows.Forms.Button();
			tbUsersComments = new System.Windows.Forms.TextBox();
			groupBox4 = new System.Windows.Forms.GroupBox();
			tbUsersLastOperation = new System.Windows.Forms.TextBox();
			label14 = new System.Windows.Forms.Label();
			tbUsersLastLogin = new System.Windows.Forms.TextBox();
			label15 = new System.Windows.Forms.Label();
			tbUsersFirstLogin = new System.Windows.Forms.TextBox();
			label16 = new System.Windows.Forms.Label();
			tbUsersCreated = new System.Windows.Forms.TextBox();
			label17 = new System.Windows.Forms.Label();
			label18 = new System.Windows.Forms.Label();
			tbUsersFirstName = new System.Windows.Forms.TextBox();
			label19 = new System.Windows.Forms.Label();
			bUsersSearchUser = new System.Windows.Forms.Button();
			bUsersNewUser = new System.Windows.Forms.Button();
			tabPage2 = new System.Windows.Forms.TabPage();
			groupBox1 = new System.Windows.Forms.GroupBox();
			comboBox2 = new System.Windows.Forms.ComboBox();
			label12 = new System.Windows.Forms.Label();
			button8 = new System.Windows.Forms.Button();
			button7 = new System.Windows.Forms.Button();
			button6 = new System.Windows.Forms.Button();
			textBox7 = new System.Windows.Forms.TextBox();
			groupBox2 = new System.Windows.Forms.GroupBox();
			textBox6 = new System.Windows.Forms.TextBox();
			label11 = new System.Windows.Forms.Label();
			textBox5 = new System.Windows.Forms.TextBox();
			label10 = new System.Windows.Forms.Label();
			textBox4 = new System.Windows.Forms.TextBox();
			label9 = new System.Windows.Forms.Label();
			textBox3 = new System.Windows.Forms.TextBox();
			label8 = new System.Windows.Forms.Label();
			checkedListBox1 = new System.Windows.Forms.CheckedListBox();
			label7 = new System.Windows.Forms.Label();
			textBox2 = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			button5 = new System.Windows.Forms.Button();
			button4 = new System.Windows.Forms.Button();
			listBox1 = new System.Windows.Forms.ListBox();
			tabPage4 = new System.Windows.Forms.TabPage();
			groupBox6 = new System.Windows.Forms.GroupBox();
			checkBox1 = new System.Windows.Forms.CheckBox();
			textBox17 = new System.Windows.Forms.TextBox();
			label27 = new System.Windows.Forms.Label();
			textBox16 = new System.Windows.Forms.TextBox();
			label26 = new System.Windows.Forms.Label();
			comboBox5 = new System.Windows.Forms.ComboBox();
			label23 = new System.Windows.Forms.Label();
			comboBox4 = new System.Windows.Forms.ComboBox();
			label22 = new System.Windows.Forms.Label();
			textBox23 = new System.Windows.Forms.TextBox();
			label30 = new System.Windows.Forms.Label();
			button16 = new System.Windows.Forms.Button();
			button17 = new System.Windows.Forms.Button();
			listBox3 = new System.Windows.Forms.ListBox();
			tbNewStructure = new System.Windows.Forms.TabPage();
			cbStructureIsItemTypeGroupChild = new System.Windows.Forms.CheckBox();
			tbStructureGroupName = new System.Windows.Forms.TextBox();
			label108 = new System.Windows.Forms.Label();
			pbStructureItemPicture = new System.Windows.Forms.PictureBox();
			label107 = new System.Windows.Forms.Label();
			btnStructureMoveItemPartBack = new System.Windows.Forms.Button();
			btnStructureClear = new System.Windows.Forms.Button();
			btnStructureSave = new System.Windows.Forms.Button();
			btnStructureDeleteItem = new System.Windows.Forms.Button();
			ptStructureNewItem = new Cntrls.PartTreeDynamic();
			ipStructureStructures = new Cntrls.ItemPanelDynamic();
			pbStructureItemTypeGroup = new System.Windows.Forms.PictureBox();
			pbStructureItemType = new System.Windows.Forms.PictureBox();
			tbStructureItemTypeIconPath = new System.Windows.Forms.TextBox();
			tbStructureItemTypeGroupIconPath = new System.Windows.Forms.TextBox();
			lbStructureItemTypeIconPath = new System.Windows.Forms.Label();
			lbStructureItemGroupIconPath = new System.Windows.Forms.Label();
			lbStructurePicPath = new System.Windows.Forms.Label();
			tbStructureItemTypePicPath = new System.Windows.Forms.TextBox();
			lbStructureMeasures = new System.Windows.Forms.ListBox();
			lbStructurePartTypes = new System.Windows.Forms.ListBox();
			btnStructureMoveItemPart = new System.Windows.Forms.Button();
			lbStructureItemPartList = new System.Windows.Forms.Label();
			btnStructuresDeleteGroup = new System.Windows.Forms.Button();
			btnStructureNewGroup = new System.Windows.Forms.Button();
			tbStructureNewItemName = new System.Windows.Forms.TextBox();
			lbStructureNewItemName = new System.Windows.Forms.Label();
			sbStatus = new System.Windows.Forms.StatusBar();
			ilStructureItemType = new System.Windows.Forms.ImageList(components);
			tabPage8 = new System.Windows.Forms.TabPage();
			ptPartTree = new Cntrls.PartTree();
			cbcCustomer = new Cntrls.ComboTextComponent();
			comboBox1 = new System.Windows.Forms.ComboBox();
			textBox1 = new System.Windows.Forms.TextBox();
			tabControl1.SuspendLayout();
			tpReports.SuspendLayout();
			tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(pbShapesItemPicture)).BeginInit();
			tabPage6.SuspendLayout();
			panel1.SuspendLayout();
			tabPage7.SuspendLayout();
			groupBox9.SuspendLayout();
			gbFixed.SuspendLayout();
			tabPage5.SuspendLayout();
			groupBox8.SuspendLayout();
			groupBox7.SuspendLayout();
			tabPage3.SuspendLayout();
			gbDetails.SuspendLayout();
			groupBox5.SuspendLayout();
			groupBox4.SuspendLayout();
			tabPage2.SuspendLayout();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			tabPage4.SuspendLayout();
			groupBox6.SuspendLayout();
			tbNewStructure.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(pbStructureItemPicture)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(pbStructureItemTypeGroup)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(pbStructureItemType)).BeginInit();
			tabPage8.SuspendLayout();
			SuspendLayout();
			// 
			// tabControl1
			// 
			tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
			tabControl1.Controls.Add(tpReports);
			tabControl1.Controls.Add(tabPage1);
			tabControl1.Controls.Add(tabPage6);
			tabControl1.Controls.Add(tabPage7);
			tabControl1.Controls.Add(tabPage5);
			tabControl1.Controls.Add(tabPage3);
			tabControl1.Controls.Add(tabPage2);
			tabControl1.Controls.Add(tabPage4);
			tabControl1.Controls.Add(tbNewStructure);
			tabControl1.Controls.Add(tabPage8);
			tabControl1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			tabControl1.ItemSize = new System.Drawing.Size(70, 18);
			tabControl1.Location = new System.Drawing.Point(0, 0);
			tabControl1.Multiline = true;
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new System.Drawing.Size(944, 650);
			tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			tabControl1.TabIndex = 0;
			tabControl1.SelectedIndexChanged += new System.EventHandler(tabControl1_SelectedIndexChanged);
			// 
			// tpReports
			// 
			tpReports.Controls.Add(tbReportsItemCode);
			tpReports.Controls.Add(lbReportsItemCode);
			tpReports.Controls.Add(tbReportsBatchCode);
			tpReports.Controls.Add(lbReportsBatchCode);
			tpReports.Controls.Add(tbReportsGroupCode);
			tpReports.Controls.Add(lbReportsGroupCode);
			tpReports.Controls.Add(btnReportsPrint);
			tpReports.Controls.Add(lvReports);
			tpReports.Controls.Add(lbReportsGroupOfficeID);
			tpReports.Controls.Add(tbReportsGroupOfficeID);
			tpReports.Location = new System.Drawing.Point(40, 4);
			tpReports.Name = "tpReports";
			tpReports.Size = new System.Drawing.Size(900, 642);
			tpReports.TabIndex = 7;
			tpReports.Text = "Reports";
			tpReports.Enter += new System.EventHandler(tpReports_Enter);
			// 
			// tbReportsItemCode
			// 
			tbReportsItemCode.Enabled = false;
			tbReportsItemCode.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			tbReportsItemCode.Location = new System.Drawing.Point(430, 140);
			tbReportsItemCode.Name = "tbReportsItemCode";
			tbReportsItemCode.Size = new System.Drawing.Size(70, 20);
			tbReportsItemCode.TabIndex = 11;
			tbReportsItemCode.Text = "##";
			tbReportsItemCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(tbReportsItemCode_KeyPress);
			// 
			// lbReportsItemCode
			// 
			lbReportsItemCode.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			lbReportsItemCode.Location = new System.Drawing.Point(330, 140);
			lbReportsItemCode.Name = "lbReportsItemCode";
			lbReportsItemCode.Size = new System.Drawing.Size(70, 20);
			lbReportsItemCode.TabIndex = 10;
			lbReportsItemCode.Text = "Item Code";
			lbReportsItemCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbReportsBatchCode
			// 
			tbReportsBatchCode.Enabled = false;
			tbReportsBatchCode.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			tbReportsBatchCode.Location = new System.Drawing.Point(430, 105);
			tbReportsBatchCode.Name = "tbReportsBatchCode";
			tbReportsBatchCode.Size = new System.Drawing.Size(70, 20);
			tbReportsBatchCode.TabIndex = 9;
			tbReportsBatchCode.Text = "###";
			tbReportsBatchCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(tbReportsBatchCode_KeyPress);
			// 
			// lbReportsBatchCode
			// 
			lbReportsBatchCode.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			lbReportsBatchCode.Location = new System.Drawing.Point(330, 105);
			lbReportsBatchCode.Name = "lbReportsBatchCode";
			lbReportsBatchCode.Size = new System.Drawing.Size(70, 20);
			lbReportsBatchCode.TabIndex = 8;
			lbReportsBatchCode.Text = "Batch Code";
			lbReportsBatchCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbReportsGroupCode
			// 
			tbReportsGroupCode.Enabled = false;
			tbReportsGroupCode.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			tbReportsGroupCode.Location = new System.Drawing.Point(430, 70);
			tbReportsGroupCode.Name = "tbReportsGroupCode";
			tbReportsGroupCode.Size = new System.Drawing.Size(70, 20);
			tbReportsGroupCode.TabIndex = 7;
			tbReportsGroupCode.Text = "#####";
			tbReportsGroupCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(tbReportsGroupCode_KeyPress);
			// 
			// lbReportsGroupCode
			// 
			lbReportsGroupCode.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			lbReportsGroupCode.Location = new System.Drawing.Point(330, 70);
			lbReportsGroupCode.Name = "lbReportsGroupCode";
			lbReportsGroupCode.Size = new System.Drawing.Size(85, 20);
			lbReportsGroupCode.TabIndex = 6;
			lbReportsGroupCode.Text = "Group Code";
			lbReportsGroupCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnReportsPrint
			// 
			btnReportsPrint.Enabled = false;
			btnReportsPrint.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			btnReportsPrint.Location = new System.Drawing.Point(410, 175);
			btnReportsPrint.Name = "btnReportsPrint";
			btnReportsPrint.Size = new System.Drawing.Size(90, 25);
			btnReportsPrint.TabIndex = 1;
			btnReportsPrint.Text = "Print";
			btnReportsPrint.Click += new System.EventHandler(button1_Click);
			// 
			// lvReports
			// 
			lvReports.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            hdrForm,
            hdrReport});
			lvReports.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			lvReports.FullRowSelect = true;
			lvReports.GridLines = true;
			lvReports.HideSelection = false;
			lvReports.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem33,
            listViewItem34,
            listViewItem35,
            listViewItem36,
            listViewItem37,
            listViewItem38,
            listViewItem39,
            listViewItem40});
			lvReports.Location = new System.Drawing.Point(10, 10);
			lvReports.Name = "lvReports";
			lvReports.Size = new System.Drawing.Size(305, 425);
			lvReports.TabIndex = 0;
			lvReports.UseCompatibleStateImageBehavior = false;
			lvReports.View = System.Windows.Forms.View.Details;
			lvReports.SelectedIndexChanged += new System.EventHandler(lvReports_SelectedIndexChanged);
			// 
			// hdrForm
			// 
			hdrForm.Text = "Form";
			hdrForm.Width = 120;
			// 
			// hdrReport
			// 
			hdrReport.Text = "Report";
			hdrReport.Width = 180;
			// 
			// lbReportsGroupOfficeID
			// 
			lbReportsGroupOfficeID.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			lbReportsGroupOfficeID.Location = new System.Drawing.Point(330, 35);
			lbReportsGroupOfficeID.Name = "lbReportsGroupOfficeID";
			lbReportsGroupOfficeID.Size = new System.Drawing.Size(100, 20);
			lbReportsGroupOfficeID.TabIndex = 2;
			lbReportsGroupOfficeID.Text = "Group Office ID";
			// 
			// tbReportsGroupOfficeID
			// 
			tbReportsGroupOfficeID.Enabled = false;
			tbReportsGroupOfficeID.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			tbReportsGroupOfficeID.Location = new System.Drawing.Point(430, 35);
			tbReportsGroupOfficeID.Name = "tbReportsGroupOfficeID";
			tbReportsGroupOfficeID.Size = new System.Drawing.Size(70, 20);
			tbReportsGroupOfficeID.TabIndex = 3;
			tbReportsGroupOfficeID.Text = "###";
			tbReportsGroupOfficeID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(tbReportsGroupOfficeID_KeyPress);
			// 
			// tabPage1
			// 
			tabPage1.Controls.Add(partTree1);
			tabPage1.Controls.Add(tbShapesSarinGroup);
			tabPage1.Controls.Add(tbShapesShortReportName);
			tabPage1.Controls.Add(tbShapesLongReportName);
			tabPage1.Controls.Add(tbShapesFullName);
			tabPage1.Controls.Add(bShapesPicturePath);
			tabPage1.Controls.Add(bShapesNew);
			tabPage1.Controls.Add(bShapesUpdate);
			tabPage1.Controls.Add(bShapesPrintAll);
			tabPage1.Controls.Add(bShapesPrintSelected);
			tabPage1.Controls.Add(tbShapesPicturePath);
			tabPage1.Controls.Add(label5);
			tabPage1.Controls.Add(label4);
			tabPage1.Controls.Add(cbShapesPriceGroup);
			tabPage1.Controls.Add(label3);
			tabPage1.Controls.Add(label2);
			tabPage1.Controls.Add(label1);
			tabPage1.Controls.Add(pbShapesItemPicture);
			tabPage1.Location = new System.Drawing.Point(40, 4);
			tabPage1.Name = "tabPage1";
			tabPage1.Size = new System.Drawing.Size(900, 642);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "Shapes";
			// 
			// partTree1
			// 
			partTree1.Location = new System.Drawing.Point(5, 5);
			partTree1.Name = "partTree1";
			partTree1.Size = new System.Drawing.Size(570, 445);
			partTree1.TabIndex = 25;
			// 
			// tbShapesSarinGroup
			// 
			tbShapesSarinGroup.Location = new System.Drawing.Point(690, 150);
			tbShapesSarinGroup.Name = "tbShapesSarinGroup";
			tbShapesSarinGroup.Size = new System.Drawing.Size(225, 20);
			tbShapesSarinGroup.TabIndex = 5;
			tbShapesSarinGroup.Enter += new System.EventHandler(tbShapesSarinGroup_Enter);
			// 
			// tbShapesShortReportName
			// 
			tbShapesShortReportName.Location = new System.Drawing.Point(690, 80);
			tbShapesShortReportName.Name = "tbShapesShortReportName";
			tbShapesShortReportName.Size = new System.Drawing.Size(225, 20);
			tbShapesShortReportName.TabIndex = 3;
			tbShapesShortReportName.Enter += new System.EventHandler(tbShapesShortReportName_Enter);
			// 
			// tbShapesLongReportName
			// 
			tbShapesLongReportName.Location = new System.Drawing.Point(690, 45);
			tbShapesLongReportName.Name = "tbShapesLongReportName";
			tbShapesLongReportName.Size = new System.Drawing.Size(225, 20);
			tbShapesLongReportName.TabIndex = 2;
			tbShapesLongReportName.Enter += new System.EventHandler(tbShapesLongReportName_Enter);
			// 
			// tbShapesFullName
			// 
			tbShapesFullName.Location = new System.Drawing.Point(690, 10);
			tbShapesFullName.Name = "tbShapesFullName";
			tbShapesFullName.Size = new System.Drawing.Size(225, 20);
			tbShapesFullName.TabIndex = 1;
			tbShapesFullName.Enter += new System.EventHandler(tbShapesFullName_Enter);
			// 
			// bShapesPicturePath
			// 
			bShapesPicturePath.Location = new System.Drawing.Point(890, 180);
			bShapesPicturePath.Name = "bShapesPicturePath";
			bShapesPicturePath.Size = new System.Drawing.Size(25, 20);
			bShapesPicturePath.TabIndex = 7;
			bShapesPicturePath.Text = "...";
			bShapesPicturePath.Click += new System.EventHandler(bShapesPicturePath_Click);
			// 
			// bShapesNew
			// 
			bShapesNew.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			bShapesNew.ForeColor = System.Drawing.SystemColors.ControlText;
			bShapesNew.Location = new System.Drawing.Point(825, 610);
			bShapesNew.Name = "bShapesNew";
			bShapesNew.Size = new System.Drawing.Size(90, 23);
			bShapesNew.TabIndex = 24;
			bShapesNew.Text = "New";
			bShapesNew.Click += new System.EventHandler(bShapes_Click);
			// 
			// bShapesUpdate
			// 
			bShapesUpdate.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			bShapesUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
			bShapesUpdate.Location = new System.Drawing.Point(725, 610);
			bShapesUpdate.Name = "bShapesUpdate";
			bShapesUpdate.Size = new System.Drawing.Size(90, 23);
			bShapesUpdate.TabIndex = 23;
			bShapesUpdate.Text = "Update";
			bShapesUpdate.Click += new System.EventHandler(bShapesUpdate_Click);
			// 
			// bShapesPrintAll
			// 
			bShapesPrintAll.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			bShapesPrintAll.Location = new System.Drawing.Point(755, 460);
			bShapesPrintAll.Name = "bShapesPrintAll";
			bShapesPrintAll.Size = new System.Drawing.Size(165, 20);
			bShapesPrintAll.TabIndex = 9;
			bShapesPrintAll.Text = "Print All Shapes ";
			bShapesPrintAll.Click += new System.EventHandler(bShapesPrintSelected_Click);
			// 
			// bShapesPrintSelected
			// 
			bShapesPrintSelected.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			bShapesPrintSelected.Location = new System.Drawing.Point(580, 460);
			bShapesPrintSelected.Name = "bShapesPrintSelected";
			bShapesPrintSelected.Size = new System.Drawing.Size(165, 20);
			bShapesPrintSelected.TabIndex = 8;
			bShapesPrintSelected.Text = "Print Selected Shape ";
			bShapesPrintSelected.Click += new System.EventHandler(bShapesPrintSelected_Click);
			// 
			// tbShapesPicturePath
			// 
			tbShapesPicturePath.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			tbShapesPicturePath.Location = new System.Drawing.Point(690, 180);
			tbShapesPicturePath.Name = "tbShapesPicturePath";
			tbShapesPicturePath.Size = new System.Drawing.Size(200, 20);
			tbShapesPicturePath.TabIndex = 6;
			tbShapesPicturePath.Enter += new System.EventHandler(tbShapesPicturePath_Enter);
			// 
			// label5
			// 
			label5.BackColor = System.Drawing.SystemColors.Control;
			label5.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label5.Location = new System.Drawing.Point(580, 185);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(100, 15);
			label5.TabIndex = 19;
			label5.Text = "Picture File Name";
			// 
			// label4
			// 
			label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			label4.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label4.Location = new System.Drawing.Point(580, 145);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(340, 30);
			label4.TabIndex = 18;
			label4.Text = "Sarin Group";
			// 
			// cbShapesPriceGroup
			// 
			cbShapesPriceGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbShapesPriceGroup.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			cbShapesPriceGroup.Location = new System.Drawing.Point(580, 115);
			cbShapesPriceGroup.Name = "cbShapesPriceGroup";
			cbShapesPriceGroup.Size = new System.Drawing.Size(340, 20);
			cbShapesPriceGroup.TabIndex = 4;
			cbShapesPriceGroup.Enter += new System.EventHandler(cbShapesPriceGroup_Enter);
			// 
			// label3
			// 
			label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			label3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label3.Location = new System.Drawing.Point(580, 75);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(340, 30);
			label3.TabIndex = 16;
			label3.Text = "Short Report Name";
			// 
			// label2
			// 
			label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			label2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label2.Location = new System.Drawing.Point(580, 40);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(340, 30);
			label2.TabIndex = 15;
			label2.Text = "Long Report Name";
			// 
			// label1
			// 
			label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			label1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label1.Location = new System.Drawing.Point(580, 5);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(340, 30);
			label1.TabIndex = 0;
			label1.Text = "Full Name";
			// 
			// pbShapesItemPicture
			// 
			pbShapesItemPicture.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbShapesItemPicture.BackgroundImage")));
			pbShapesItemPicture.Location = new System.Drawing.Point(580, 210);
			pbShapesItemPicture.Name = "pbShapesItemPicture";
			pbShapesItemPicture.Size = new System.Drawing.Size(336, 240);
			pbShapesItemPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			pbShapesItemPicture.TabIndex = 12;
			pbShapesItemPicture.TabStop = false;
			// 
			// tabPage6
			// 
			tabPage6.Controls.Add(listView1);
			tabPage6.Controls.Add(button22);
			tabPage6.Controls.Add(button21);
			tabPage6.Controls.Add(label106);
			tabPage6.Controls.Add(comboBox6);
			tabPage6.Controls.Add(panel1);
			tabPage6.Location = new System.Drawing.Point(22, 4);
			tabPage6.Name = "tabPage6";
			tabPage6.Size = new System.Drawing.Size(412, 642);
			tabPage6.TabIndex = 5;
			tabPage6.Text = "Keyboard";
			// 
			// listView1
			// 
			listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeader1,
            columnHeader2});
			listView1.FullRowSelect = true;
			listView1.GridLines = true;
			listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			listView1.HoverSelection = true;
			listView1.Location = new System.Drawing.Point(5, 405);
			listView1.Name = "listView1";
			listView1.Size = new System.Drawing.Size(910, 205);
			listView1.TabIndex = 6;
			listView1.UseCompatibleStateImageBehavior = false;
			listView1.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			columnHeader1.Text = "Operation";
			columnHeader1.Width = 736;
			// 
			// columnHeader2
			// 
			columnHeader2.Text = "Keys";
			columnHeader2.Width = 167;
			// 
			// button22
			// 
			button22.BackColor = System.Drawing.Color.LightPink;
			button22.Location = new System.Drawing.Point(740, 615);
			button22.Name = "button22";
			button22.Size = new System.Drawing.Size(175, 20);
			button22.TabIndex = 5;
			button22.Text = "Delete";
			button22.UseVisualStyleBackColor = false;
			// 
			// button21
			// 
			button21.BackColor = System.Drawing.Color.LightSteelBlue;
			button21.Location = new System.Drawing.Point(740, 380);
			button21.Name = "button21";
			button21.Size = new System.Drawing.Size(175, 20);
			button21.TabIndex = 3;
			button21.Text = "Add";
			button21.UseVisualStyleBackColor = false;
			// 
			// label106
			// 
			label106.BackColor = System.Drawing.SystemColors.ControlLightLight;
			label106.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label106.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label106.ForeColor = System.Drawing.Color.Maroon;
			label106.Location = new System.Drawing.Point(575, 380);
			label106.Name = "label106";
			label106.Size = new System.Drawing.Size(150, 20);
			label106.TabIndex = 2;
			label106.Text = "arrUp";
			label106.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// comboBox6
			// 
			comboBox6.Location = new System.Drawing.Point(5, 380);
			comboBox6.Name = "comboBox6";
			comboBox6.Size = new System.Drawing.Size(555, 20);
			comboBox6.TabIndex = 1;
			comboBox6.Text = "Operation";
			// 
			// panel1
			// 
			panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
			panel1.Controls.Add(label105);
			panel1.Controls.Add(label104);
			panel1.Controls.Add(label101);
			panel1.Controls.Add(label100);
			panel1.Controls.Add(label99);
			panel1.Controls.Add(label98);
			panel1.Controls.Add(label96);
			panel1.Controls.Add(label94);
			panel1.Controls.Add(label93);
			panel1.Controls.Add(label92);
			panel1.Controls.Add(label91);
			panel1.Controls.Add(label90);
			panel1.Controls.Add(label89);
			panel1.Controls.Add(label88);
			panel1.Controls.Add(label87);
			panel1.Controls.Add(label86);
			panel1.Controls.Add(label85);
			panel1.Controls.Add(label84);
			panel1.Controls.Add(label83);
			panel1.Controls.Add(label82);
			panel1.Controls.Add(label81);
			panel1.Controls.Add(label80);
			panel1.Controls.Add(label79);
			panel1.Controls.Add(label78);
			panel1.Controls.Add(label77);
			panel1.Controls.Add(label76);
			panel1.Controls.Add(label75);
			panel1.Controls.Add(label74);
			panel1.Controls.Add(label73);
			panel1.Controls.Add(label71);
			panel1.Controls.Add(label70);
			panel1.Controls.Add(label69);
			panel1.Controls.Add(label68);
			panel1.Controls.Add(label67);
			panel1.Controls.Add(label66);
			panel1.Controls.Add(label65);
			panel1.Controls.Add(label64);
			panel1.Controls.Add(label63);
			panel1.Controls.Add(label62);
			panel1.Controls.Add(label61);
			panel1.Controls.Add(label60);
			panel1.Controls.Add(label59);
			panel1.Controls.Add(label58);
			panel1.Controls.Add(label57);
			panel1.Controls.Add(label56);
			panel1.Controls.Add(label55);
			panel1.Controls.Add(label54);
			panel1.Controls.Add(label53);
			panel1.Controls.Add(label52);
			panel1.Controls.Add(label51);
			panel1.Controls.Add(label50);
			panel1.Controls.Add(label49);
			panel1.Controls.Add(label48);
			panel1.Controls.Add(label47);
			panel1.Controls.Add(label46);
			panel1.Controls.Add(label45);
			panel1.Controls.Add(label44);
			panel1.Controls.Add(label43);
			panel1.Controls.Add(label42);
			panel1.Controls.Add(label41);
			panel1.Controls.Add(label40);
			panel1.Controls.Add(label39);
			panel1.Controls.Add(label38);
			panel1.Controls.Add(label37);
			panel1.Controls.Add(label36);
			panel1.Controls.Add(label35);
			panel1.Controls.Add(label72);
			panel1.Controls.Add(label95);
			panel1.Controls.Add(label97);
			panel1.Controls.Add(label102);
			panel1.Controls.Add(label103);
			panel1.Location = new System.Drawing.Point(2, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(915, 370);
			panel1.TabIndex = 0;
			// 
			// label105
			// 
			label105.BackColor = System.Drawing.Color.Transparent;
			label105.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label105.Location = new System.Drawing.Point(861, 129);
			label105.Name = "label105";
			label105.Size = new System.Drawing.Size(36, 57);
			label105.TabIndex = 65;
			// 
			// label104
			// 
			label104.BackColor = System.Drawing.Color.Transparent;
			label104.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label104.Location = new System.Drawing.Point(801, 186);
			label104.Name = "label104";
			label104.Size = new System.Drawing.Size(96, 42);
			label104.TabIndex = 64;
			label104.Text = "Enter";
			label104.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label101
			// 
			label101.BackColor = System.Drawing.Color.Transparent;
			label101.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label101.Location = new System.Drawing.Point(570, 306);
			label101.Name = "label101";
			label101.Size = new System.Drawing.Size(39, 45);
			label101.TabIndex = 63;
			label101.Text = "{   [";
			// 
			// label100
			// 
			label100.BackColor = System.Drawing.Color.Transparent;
			label100.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label100.Location = new System.Drawing.Point(858, 306);
			label100.Name = "label100";
			label100.Size = new System.Drawing.Size(36, 45);
			label100.TabIndex = 62;
			// 
			// label99
			// 
			label99.BackColor = System.Drawing.Color.Transparent;
			label99.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label99.Location = new System.Drawing.Point(801, 306);
			label99.Name = "label99";
			label99.Size = new System.Drawing.Size(36, 45);
			label99.TabIndex = 61;
			// 
			// label98
			// 
			label98.BackColor = System.Drawing.Color.Transparent;
			label98.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label98.Location = new System.Drawing.Point(744, 306);
			label98.Name = "label98";
			label98.Size = new System.Drawing.Size(36, 45);
			label98.TabIndex = 60;
			// 
			// label96
			// 
			label96.BackColor = System.Drawing.Color.Transparent;
			label96.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label96.Location = new System.Drawing.Point(135, 306);
			label96.Name = "label96";
			label96.Size = new System.Drawing.Size(36, 45);
			label96.TabIndex = 59;
			label96.Text = "Alt";
			label96.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label94
			// 
			label94.BackColor = System.Drawing.Color.Transparent;
			label94.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label94.Location = new System.Drawing.Point(861, 246);
			label94.Name = "label94";
			label94.Size = new System.Drawing.Size(36, 45);
			label94.TabIndex = 58;
			label94.Text = "+   =";
			// 
			// label93
			// 
			label93.BackColor = System.Drawing.Color.Transparent;
			label93.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label93.Location = new System.Drawing.Point(798, 246);
			label93.Name = "label93";
			label93.Size = new System.Drawing.Size(36, 45);
			label93.TabIndex = 57;
			// 
			// label92
			// 
			label92.BackColor = System.Drawing.Color.Transparent;
			label92.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label92.Location = new System.Drawing.Point(738, 246);
			label92.Name = "label92";
			label92.Size = new System.Drawing.Size(36, 45);
			label92.TabIndex = 56;
			label92.Text = "?   /";
			// 
			// label91
			// 
			label91.BackColor = System.Drawing.Color.Transparent;
			label91.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label91.Location = new System.Drawing.Point(675, 246);
			label91.Name = "label91";
			label91.Size = new System.Drawing.Size(39, 45);
			label91.TabIndex = 55;
			label91.Text = ">   .";
			// 
			// label90
			// 
			label90.BackColor = System.Drawing.Color.Transparent;
			label90.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label90.Location = new System.Drawing.Point(615, 246);
			label90.Name = "label90";
			label90.Size = new System.Drawing.Size(39, 45);
			label90.TabIndex = 54;
			label90.Text = "<   ,";
			// 
			// label89
			// 
			label89.BackColor = System.Drawing.Color.Transparent;
			label89.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label89.Location = new System.Drawing.Point(546, 249);
			label89.Name = "label89";
			label89.Size = new System.Drawing.Size(45, 42);
			label89.TabIndex = 53;
			label89.Text = "M";
			// 
			// label88
			// 
			label88.BackColor = System.Drawing.Color.Transparent;
			label88.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label88.Location = new System.Drawing.Point(477, 249);
			label88.Name = "label88";
			label88.Size = new System.Drawing.Size(45, 42);
			label88.TabIndex = 52;
			label88.Text = "N";
			// 
			// label87
			// 
			label87.BackColor = System.Drawing.Color.Transparent;
			label87.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label87.Location = new System.Drawing.Point(405, 249);
			label87.Name = "label87";
			label87.Size = new System.Drawing.Size(45, 42);
			label87.TabIndex = 51;
			label87.Text = "B";
			// 
			// label86
			// 
			label86.BackColor = System.Drawing.Color.Transparent;
			label86.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label86.Location = new System.Drawing.Point(336, 249);
			label86.Name = "label86";
			label86.Size = new System.Drawing.Size(45, 42);
			label86.TabIndex = 50;
			label86.Text = "V";
			// 
			// label85
			// 
			label85.BackColor = System.Drawing.Color.Transparent;
			label85.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label85.Location = new System.Drawing.Point(267, 249);
			label85.Name = "label85";
			label85.Size = new System.Drawing.Size(45, 42);
			label85.TabIndex = 49;
			label85.Text = "C";
			// 
			// label84
			// 
			label84.BackColor = System.Drawing.Color.Transparent;
			label84.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label84.Location = new System.Drawing.Point(192, 249);
			label84.Name = "label84";
			label84.Size = new System.Drawing.Size(45, 42);
			label84.TabIndex = 48;
			label84.Text = "X";
			// 
			// label83
			// 
			label83.BackColor = System.Drawing.Color.Transparent;
			label83.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label83.Location = new System.Drawing.Point(123, 249);
			label83.Name = "label83";
			label83.Size = new System.Drawing.Size(45, 42);
			label83.TabIndex = 47;
			label83.Text = "Z";
			// 
			// label82
			// 
			label82.BackColor = System.Drawing.Color.Transparent;
			label82.Font = new System.Drawing.Font("Verdana", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label82.Image = ((System.Drawing.Image)(resources.GetObject("label82.Image")));
			label82.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label82.Location = new System.Drawing.Point(15, 249);
			label82.Name = "label82";
			label82.Size = new System.Drawing.Size(84, 42);
			label82.TabIndex = 46;
			label82.Text = "Shift      ";
			label82.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label81
			// 
			label81.BackColor = System.Drawing.Color.Transparent;
			label81.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label81.Location = new System.Drawing.Point(729, 186);
			label81.Name = "label81";
			label81.Size = new System.Drawing.Size(45, 42);
			label81.TabIndex = 45;
			label81.Text = ":     ;";
			// 
			// label80
			// 
			label80.BackColor = System.Drawing.Color.Transparent;
			label80.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label80.Location = new System.Drawing.Point(657, 186);
			label80.Name = "label80";
			label80.Size = new System.Drawing.Size(45, 42);
			label80.TabIndex = 44;
			label80.Text = "L";
			// 
			// label79
			// 
			label79.BackColor = System.Drawing.Color.Transparent;
			label79.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label79.Location = new System.Drawing.Point(585, 186);
			label79.Name = "label79";
			label79.Size = new System.Drawing.Size(45, 42);
			label79.TabIndex = 43;
			label79.Text = "K";
			// 
			// label78
			// 
			label78.BackColor = System.Drawing.Color.Transparent;
			label78.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label78.Location = new System.Drawing.Point(513, 186);
			label78.Name = "label78";
			label78.Size = new System.Drawing.Size(45, 42);
			label78.TabIndex = 42;
			label78.Text = "J";
			// 
			// label77
			// 
			label77.BackColor = System.Drawing.Color.Transparent;
			label77.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label77.Location = new System.Drawing.Point(438, 186);
			label77.Name = "label77";
			label77.Size = new System.Drawing.Size(45, 42);
			label77.TabIndex = 41;
			label77.Text = "H";
			// 
			// label76
			// 
			label76.BackColor = System.Drawing.Color.Transparent;
			label76.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label76.Location = new System.Drawing.Point(363, 186);
			label76.Name = "label76";
			label76.Size = new System.Drawing.Size(45, 42);
			label76.TabIndex = 40;
			label76.Text = "G";
			// 
			// label75
			// 
			label75.BackColor = System.Drawing.Color.Transparent;
			label75.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label75.Location = new System.Drawing.Point(294, 186);
			label75.Name = "label75";
			label75.Size = new System.Drawing.Size(45, 42);
			label75.TabIndex = 39;
			label75.Text = "F";
			// 
			// label74
			// 
			label74.BackColor = System.Drawing.Color.Transparent;
			label74.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label74.Location = new System.Drawing.Point(219, 186);
			label74.Name = "label74";
			label74.Size = new System.Drawing.Size(45, 42);
			label74.TabIndex = 38;
			label74.Text = "D";
			// 
			// label73
			// 
			label73.BackColor = System.Drawing.Color.Transparent;
			label73.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label73.Location = new System.Drawing.Point(147, 186);
			label73.Name = "label73";
			label73.Size = new System.Drawing.Size(45, 42);
			label73.TabIndex = 37;
			label73.Text = "S";
			// 
			// label71
			// 
			label71.BackColor = System.Drawing.Color.Transparent;
			label71.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label71.Location = new System.Drawing.Point(792, 126);
			label71.Name = "label71";
			label71.Size = new System.Drawing.Size(45, 42);
			label71.TabIndex = 36;
			label71.Text = "|     \\";
			// 
			// label70
			// 
			label70.BackColor = System.Drawing.Color.Transparent;
			label70.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label70.Location = new System.Drawing.Point(720, 126);
			label70.Name = "label70";
			label70.Size = new System.Drawing.Size(45, 42);
			label70.TabIndex = 35;
			label70.Text = "P";
			// 
			// label69
			// 
			label69.BackColor = System.Drawing.Color.Transparent;
			label69.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label69.Location = new System.Drawing.Point(645, 126);
			label69.Name = "label69";
			label69.Size = new System.Drawing.Size(45, 42);
			label69.TabIndex = 34;
			label69.Text = "O";
			// 
			// label68
			// 
			label68.BackColor = System.Drawing.Color.Transparent;
			label68.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label68.Location = new System.Drawing.Point(573, 126);
			label68.Name = "label68";
			label68.Size = new System.Drawing.Size(45, 42);
			label68.TabIndex = 33;
			label68.Text = "I";
			// 
			// label67
			// 
			label67.BackColor = System.Drawing.Color.Transparent;
			label67.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label67.Location = new System.Drawing.Point(501, 126);
			label67.Name = "label67";
			label67.Size = new System.Drawing.Size(45, 42);
			label67.TabIndex = 32;
			label67.Text = "U";
			// 
			// label66
			// 
			label66.BackColor = System.Drawing.Color.Transparent;
			label66.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label66.Location = new System.Drawing.Point(429, 126);
			label66.Name = "label66";
			label66.Size = new System.Drawing.Size(45, 42);
			label66.TabIndex = 31;
			label66.Text = "Y";
			// 
			// label65
			// 
			label65.BackColor = System.Drawing.Color.Transparent;
			label65.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label65.Location = new System.Drawing.Point(354, 126);
			label65.Name = "label65";
			label65.Size = new System.Drawing.Size(45, 42);
			label65.TabIndex = 30;
			label65.Text = "T";
			// 
			// label64
			// 
			label64.BackColor = System.Drawing.Color.Transparent;
			label64.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label64.Location = new System.Drawing.Point(282, 126);
			label64.Name = "label64";
			label64.Size = new System.Drawing.Size(45, 42);
			label64.TabIndex = 29;
			label64.Text = "R";
			// 
			// label63
			// 
			label63.BackColor = System.Drawing.Color.Transparent;
			label63.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label63.Location = new System.Drawing.Point(210, 126);
			label63.Name = "label63";
			label63.Size = new System.Drawing.Size(45, 42);
			label63.TabIndex = 28;
			label63.Text = "E";
			// 
			// label62
			// 
			label62.BackColor = System.Drawing.Color.Transparent;
			label62.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label62.Location = new System.Drawing.Point(138, 126);
			label62.Name = "label62";
			label62.Size = new System.Drawing.Size(45, 42);
			label62.TabIndex = 27;
			label62.Text = "W";
			// 
			// label61
			// 
			label61.BackColor = System.Drawing.Color.Transparent;
			label61.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label61.Location = new System.Drawing.Point(63, 126);
			label61.Name = "label61";
			label61.Size = new System.Drawing.Size(45, 42);
			label61.TabIndex = 26;
			label61.Text = "Q";
			// 
			// label60
			// 
			label60.BackColor = System.Drawing.Color.Transparent;
			label60.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label60.Image = ((System.Drawing.Image)(resources.GetObject("label60.Image")));
			label60.Location = new System.Drawing.Point(15, 126);
			label60.Name = "label60";
			label60.Size = new System.Drawing.Size(27, 42);
			label60.TabIndex = 25;
			// 
			// label59
			// 
			label59.BackColor = System.Drawing.Color.Transparent;
			label59.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label59.ForeColor = System.Drawing.SystemColors.Control;
			label59.Location = new System.Drawing.Point(822, 66);
			label59.Name = "label59";
			label59.Size = new System.Drawing.Size(70, 42);
			label59.TabIndex = 24;
			// 
			// label58
			// 
			label58.BackColor = System.Drawing.Color.Transparent;
			label58.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label58.Location = new System.Drawing.Point(747, 63);
			label58.Name = "label58";
			label58.Size = new System.Drawing.Size(45, 42);
			label58.TabIndex = 23;
			label58.Text = "_      -";
			// 
			// label57
			// 
			label57.BackColor = System.Drawing.Color.Transparent;
			label57.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label57.Location = new System.Drawing.Point(675, 63);
			label57.Name = "label57";
			label57.Size = new System.Drawing.Size(45, 42);
			label57.TabIndex = 22;
			label57.Text = ")    0";
			// 
			// label56
			// 
			label56.BackColor = System.Drawing.Color.Transparent;
			label56.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label56.Location = new System.Drawing.Point(603, 63);
			label56.Name = "label56";
			label56.Size = new System.Drawing.Size(45, 42);
			label56.TabIndex = 21;
			label56.Text = "(     9";
			// 
			// label55
			// 
			label55.BackColor = System.Drawing.Color.Transparent;
			label55.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label55.Location = new System.Drawing.Point(531, 63);
			label55.Name = "label55";
			label55.Size = new System.Drawing.Size(45, 42);
			label55.TabIndex = 20;
			label55.Text = "*     8";
			// 
			// label54
			// 
			label54.BackColor = System.Drawing.Color.Transparent;
			label54.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label54.Location = new System.Drawing.Point(456, 63);
			label54.Name = "label54";
			label54.Size = new System.Drawing.Size(45, 42);
			label54.TabIndex = 19;
			label54.Text = "&&     7";
			// 
			// label53
			// 
			label53.BackColor = System.Drawing.Color.Transparent;
			label53.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label53.Location = new System.Drawing.Point(384, 63);
			label53.Name = "label53";
			label53.Size = new System.Drawing.Size(45, 42);
			label53.TabIndex = 18;
			label53.Text = "^     6";
			// 
			// label52
			// 
			label52.BackColor = System.Drawing.Color.Transparent;
			label52.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label52.Location = new System.Drawing.Point(309, 63);
			label52.Name = "label52";
			label52.Size = new System.Drawing.Size(45, 42);
			label52.TabIndex = 17;
			label52.Text = "%     5";
			// 
			// label51
			// 
			label51.BackColor = System.Drawing.Color.Transparent;
			label51.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label51.Location = new System.Drawing.Point(237, 63);
			label51.Name = "label51";
			label51.Size = new System.Drawing.Size(45, 42);
			label51.TabIndex = 16;
			label51.Text = "$     4";
			// 
			// label50
			// 
			label50.BackColor = System.Drawing.Color.Transparent;
			label50.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label50.Location = new System.Drawing.Point(165, 63);
			label50.Name = "label50";
			label50.Size = new System.Drawing.Size(45, 42);
			label50.TabIndex = 15;
			label50.Text = "#     3";
			// 
			// label49
			// 
			label49.BackColor = System.Drawing.Color.Transparent;
			label49.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label49.Location = new System.Drawing.Point(93, 63);
			label49.Name = "label49";
			label49.Size = new System.Drawing.Size(45, 42);
			label49.TabIndex = 14;
			label49.Text = "@     2";
			// 
			// label48
			// 
			label48.BackColor = System.Drawing.Color.Transparent;
			label48.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label48.Location = new System.Drawing.Point(21, 63);
			label48.Name = "label48";
			label48.Size = new System.Drawing.Size(45, 42);
			label48.TabIndex = 13;
			label48.Text = "!     1";
			// 
			// label47
			// 
			label47.BackColor = System.Drawing.Color.Transparent;
			label47.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label47.Location = new System.Drawing.Point(861, 21);
			label47.Name = "label47";
			label47.Size = new System.Drawing.Size(33, 25);
			label47.TabIndex = 12;
			label47.Text = "Del";
			// 
			// label46
			// 
			label46.BackColor = System.Drawing.Color.Transparent;
			label46.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label46.Location = new System.Drawing.Point(810, 21);
			label46.Name = "label46";
			label46.Size = new System.Drawing.Size(33, 25);
			label46.TabIndex = 11;
			label46.Text = "Ins";
			// 
			// label45
			// 
			label45.BackColor = System.Drawing.Color.Transparent;
			label45.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label45.Location = new System.Drawing.Point(582, 21);
			label45.Name = "label45";
			label45.Size = new System.Drawing.Size(33, 25);
			label45.TabIndex = 10;
			label45.Text = "F10";
			// 
			// label44
			// 
			label44.BackColor = System.Drawing.Color.Transparent;
			label44.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label44.Location = new System.Drawing.Point(528, 21);
			label44.Name = "label44";
			label44.Size = new System.Drawing.Size(33, 25);
			label44.TabIndex = 9;
			label44.Text = "F9";
			// 
			// label43
			// 
			label43.BackColor = System.Drawing.Color.Transparent;
			label43.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label43.Location = new System.Drawing.Point(468, 21);
			label43.Name = "label43";
			label43.Size = new System.Drawing.Size(33, 25);
			label43.TabIndex = 8;
			label43.Text = "F8";
			// 
			// label42
			// 
			label42.BackColor = System.Drawing.Color.Transparent;
			label42.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label42.Location = new System.Drawing.Point(414, 21);
			label42.Name = "label42";
			label42.Size = new System.Drawing.Size(33, 25);
			label42.TabIndex = 7;
			label42.Text = "F7";
			// 
			// label41
			// 
			label41.BackColor = System.Drawing.Color.Transparent;
			label41.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label41.Location = new System.Drawing.Point(357, 21);
			label41.Name = "label41";
			label41.Size = new System.Drawing.Size(33, 25);
			label41.TabIndex = 6;
			label41.Text = "F6";
			// 
			// label40
			// 
			label40.BackColor = System.Drawing.Color.Transparent;
			label40.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label40.Location = new System.Drawing.Point(300, 21);
			label40.Name = "label40";
			label40.Size = new System.Drawing.Size(33, 25);
			label40.TabIndex = 5;
			label40.Text = "F5";
			// 
			// label39
			// 
			label39.BackColor = System.Drawing.Color.Transparent;
			label39.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label39.Location = new System.Drawing.Point(243, 21);
			label39.Name = "label39";
			label39.Size = new System.Drawing.Size(33, 25);
			label39.TabIndex = 4;
			label39.Text = "F4";
			// 
			// label38
			// 
			label38.BackColor = System.Drawing.Color.Transparent;
			label38.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label38.Location = new System.Drawing.Point(186, 21);
			label38.Name = "label38";
			label38.Size = new System.Drawing.Size(33, 25);
			label38.TabIndex = 3;
			label38.Text = "F3";
			// 
			// label37
			// 
			label37.BackColor = System.Drawing.Color.Transparent;
			label37.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label37.Location = new System.Drawing.Point(129, 21);
			label37.Name = "label37";
			label37.Size = new System.Drawing.Size(33, 25);
			label37.TabIndex = 2;
			label37.Text = "F2";
			// 
			// label36
			// 
			label36.BackColor = System.Drawing.Color.Transparent;
			label36.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label36.Location = new System.Drawing.Point(75, 21);
			label36.Name = "label36";
			label36.Size = new System.Drawing.Size(33, 25);
			label36.TabIndex = 1;
			label36.Text = "F1";
			// 
			// label35
			// 
			label35.BackColor = System.Drawing.Color.Transparent;
			label35.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label35.Location = new System.Drawing.Point(18, 20);
			label35.Name = "label35";
			label35.Size = new System.Drawing.Size(33, 28);
			label35.TabIndex = 0;
			label35.Text = "Esc";
			// 
			// label72
			// 
			label72.BackColor = System.Drawing.Color.Transparent;
			label72.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label72.Location = new System.Drawing.Point(75, 186);
			label72.Name = "label72";
			label72.Size = new System.Drawing.Size(45, 42);
			label72.TabIndex = 27;
			label72.Text = "A";
			// 
			// label95
			// 
			label95.BackColor = System.Drawing.Color.Transparent;
			label95.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label95.Location = new System.Drawing.Point(78, 306);
			label95.Name = "label95";
			label95.Size = new System.Drawing.Size(36, 45);
			label95.TabIndex = 55;
			label95.Text = "Ctrl";
			label95.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label97
			// 
			label97.BackColor = System.Drawing.Color.Transparent;
			label97.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label97.Location = new System.Drawing.Point(252, 306);
			label97.Name = "label97";
			label97.Size = new System.Drawing.Size(36, 45);
			label97.TabIndex = 55;
			label97.Text = "~   `";
			// 
			// label102
			// 
			label102.BackColor = System.Drawing.Color.Transparent;
			label102.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label102.Location = new System.Drawing.Point(627, 306);
			label102.Name = "label102";
			label102.Size = new System.Drawing.Size(39, 45);
			label102.TabIndex = 55;
			label102.Text = "}   ]";
			// 
			// label103
			// 
			label103.BackColor = System.Drawing.Color.Transparent;
			label103.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label103.Location = new System.Drawing.Point(684, 306);
			label103.Name = "label103";
			label103.Size = new System.Drawing.Size(39, 45);
			label103.TabIndex = 55;
			label103.Text = "\"   \'";
			// 
			// tabPage7
			// 
			tabPage7.Controls.Add(groupBox9);
			tabPage7.Controls.Add(label34);
			tabPage7.Location = new System.Drawing.Point(22, 4);
			tabPage7.Name = "tabPage7";
			tabPage7.Size = new System.Drawing.Size(412, 642);
			tabPage7.TabIndex = 6;
			tabPage7.Text = "Misc";
			// 
			// groupBox9
			// 
			groupBox9.Controls.Add(rbUnfixed);
			groupBox9.Controls.Add(rbFixed);
			groupBox9.Controls.Add(gbFixed);
			groupBox9.Controls.Add(gbUnfixed);
			groupBox9.Location = new System.Drawing.Point(405, 5);
			groupBox9.Name = "groupBox9";
			groupBox9.Size = new System.Drawing.Size(510, 345);
			groupBox9.TabIndex = 6;
			groupBox9.TabStop = false;
			groupBox9.Text = "Type of price";
			// 
			// rbUnfixed
			// 
			rbUnfixed.Location = new System.Drawing.Point(10, 105);
			rbUnfixed.Name = "rbUnfixed";
			rbUnfixed.Size = new System.Drawing.Size(104, 20);
			rbUnfixed.TabIndex = 5;
			rbUnfixed.Text = "Unfixed";
			// 
			// rbFixed
			// 
			rbFixed.Checked = true;
			rbFixed.Location = new System.Drawing.Point(10, 20);
			rbFixed.Name = "rbFixed";
			rbFixed.Size = new System.Drawing.Size(110, 20);
			rbFixed.TabIndex = 4;
			rbFixed.TabStop = true;
			rbFixed.Text = "Fixed";
			// 
			// gbFixed
			// 
			gbFixed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			gbFixed.Controls.Add(label31);
			gbFixed.Controls.Add(label32);
			gbFixed.Controls.Add(tbFixedP);
			gbFixed.Controls.Add(rbFixedP);
			gbFixed.Controls.Add(label33);
			gbFixed.Controls.Add(tbFixedB);
			gbFixed.Controls.Add(rbFixedB);
			gbFixed.ForeColor = System.Drawing.Color.DimGray;
			gbFixed.Location = new System.Drawing.Point(10, 40);
			gbFixed.Name = "gbFixed";
			gbFixed.Size = new System.Drawing.Size(495, 55);
			gbFixed.TabIndex = 2;
			// 
			// label31
			// 
			label31.Location = new System.Drawing.Point(75, 35);
			label31.Name = "label31";
			label31.Size = new System.Drawing.Size(100, 15);
			label31.TabIndex = 6;
			label31.Text = "Current Price";
			// 
			// label32
			// 
			label32.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			label32.ForeColor = System.Drawing.SystemColors.ControlText;
			label32.Location = new System.Drawing.Point(445, 35);
			label32.Name = "label32";
			label32.Size = new System.Drawing.Size(15, 15);
			label32.TabIndex = 5;
			label32.Text = "%";
			// 
			// tbFixedP
			// 
			tbFixedP.Enabled = false;
			tbFixedP.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			tbFixedP.Location = new System.Drawing.Point(320, 30);
			tbFixedP.Name = "tbFixedP";
			tbFixedP.Size = new System.Drawing.Size(115, 20);
			tbFixedP.TabIndex = 4;
			// 
			// rbFixedP
			// 
			rbFixedP.Location = new System.Drawing.Point(320, 10);
			rbFixedP.Name = "rbFixedP";
			rbFixedP.Size = new System.Drawing.Size(15, 24);
			rbFixedP.TabIndex = 3;
			// 
			// label33
			// 
			label33.ForeColor = System.Drawing.SystemColors.ControlText;
			label33.Location = new System.Drawing.Point(300, 35);
			label33.Name = "label33";
			label33.Size = new System.Drawing.Size(15, 15);
			label33.TabIndex = 2;
			label33.Text = "$";
			// 
			// tbFixedB
			// 
			tbFixedB.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			tbFixedB.Location = new System.Drawing.Point(180, 30);
			tbFixedB.Name = "tbFixedB";
			tbFixedB.Size = new System.Drawing.Size(115, 20);
			tbFixedB.TabIndex = 1;
			// 
			// rbFixedB
			// 
			rbFixedB.Checked = true;
			rbFixedB.Location = new System.Drawing.Point(180, 10);
			rbFixedB.Name = "rbFixedB";
			rbFixedB.Size = new System.Drawing.Size(15, 24);
			rbFixedB.TabIndex = 0;
			rbFixedB.TabStop = true;
			// 
			// gbUnfixed
			// 
			gbUnfixed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			gbUnfixed.Enabled = false;
			gbUnfixed.ForeColor = System.Drawing.Color.DimGray;
			gbUnfixed.Location = new System.Drawing.Point(10, 125);
			gbUnfixed.Name = "gbUnfixed";
			gbUnfixed.Size = new System.Drawing.Size(495, 215);
			gbUnfixed.TabIndex = 3;
			// 
			// label34
			// 
			label34.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			label34.Location = new System.Drawing.Point(10, 5);
			label34.Name = "label34";
			label34.Size = new System.Drawing.Size(200, 15);
			label34.TabIndex = 5;
			label34.Text = "Avaliable Operations with prices";
			// 
			// tabPage5
			// 
			tabPage5.Controls.Add(groupBox8);
			tabPage5.Controls.Add(groupBox7);
			tabPage5.Location = new System.Drawing.Point(22, 4);
			tabPage5.Name = "tabPage5";
			tabPage5.Size = new System.Drawing.Size(412, 642);
			tabPage5.TabIndex = 4;
			tabPage5.Text = "Colors";
			tabPage5.Click += new System.EventHandler(tabPage5_Click);
			// 
			// groupBox8
			// 
			groupBox8.Controls.Add(bColorsUpdate);
			groupBox8.Controls.Add(tbColorsPolygonID);
			groupBox8.Controls.Add(tbColorsColorGrade);
			groupBox8.Controls.Add(label29);
			groupBox8.Controls.Add(label28);
			groupBox8.Controls.Add(bColorsNew);
			groupBox8.Controls.Add(bColorsDisable);
			groupBox8.Controls.Add(lvColorsGrades);
			groupBox8.ForeColor = System.Drawing.Color.DimGray;
			groupBox8.Location = new System.Drawing.Point(195, 15);
			groupBox8.Name = "groupBox8";
			groupBox8.Size = new System.Drawing.Size(345, 270);
			groupBox8.TabIndex = 2;
			groupBox8.TabStop = false;
			groupBox8.Text = "Grade";
			// 
			// bColorsUpdate
			// 
			bColorsUpdate.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			bColorsUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
			bColorsUpdate.Location = new System.Drawing.Point(225, 235);
			bColorsUpdate.Name = "bColorsUpdate";
			bColorsUpdate.Size = new System.Drawing.Size(110, 25);
			bColorsUpdate.TabIndex = 23;
			bColorsUpdate.Text = "Update";
			// 
			// tbColorsPolygonID
			// 
			tbColorsPolygonID.Location = new System.Drawing.Point(85, 205);
			tbColorsPolygonID.Name = "tbColorsPolygonID";
			tbColorsPolygonID.Size = new System.Drawing.Size(250, 20);
			tbColorsPolygonID.TabIndex = 22;
			// 
			// tbColorsColorGrade
			// 
			tbColorsColorGrade.Location = new System.Drawing.Point(85, 180);
			tbColorsColorGrade.Name = "tbColorsColorGrade";
			tbColorsColorGrade.Size = new System.Drawing.Size(250, 20);
			tbColorsColorGrade.TabIndex = 21;
			// 
			// label29
			// 
			label29.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label29.ForeColor = System.Drawing.SystemColors.ControlText;
			label29.Location = new System.Drawing.Point(5, 210);
			label29.Name = "label29";
			label29.Size = new System.Drawing.Size(75, 15);
			label29.TabIndex = 20;
			label29.Text = "Polygon ID";
			// 
			// label28
			// 
			label28.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label28.ForeColor = System.Drawing.SystemColors.ControlText;
			label28.Location = new System.Drawing.Point(5, 185);
			label28.Name = "label28";
			label28.Size = new System.Drawing.Size(75, 15);
			label28.TabIndex = 19;
			label28.Text = "Color Grade";
			// 
			// bColorsNew
			// 
			bColorsNew.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			bColorsNew.ForeColor = System.Drawing.SystemColors.ControlText;
			bColorsNew.Location = new System.Drawing.Point(175, 145);
			bColorsNew.Name = "bColorsNew";
			bColorsNew.Size = new System.Drawing.Size(160, 20);
			bColorsNew.TabIndex = 18;
			bColorsNew.Text = "New";
			// 
			// bColorsDisable
			// 
			bColorsDisable.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			bColorsDisable.ForeColor = System.Drawing.SystemColors.ControlText;
			bColorsDisable.Location = new System.Drawing.Point(5, 145);
			bColorsDisable.Name = "bColorsDisable";
			bColorsDisable.Size = new System.Drawing.Size(160, 20);
			bColorsDisable.TabIndex = 17;
			bColorsDisable.Text = "Disable ";
			// 
			// lvColorsGrades
			// 
			lvColorsGrades.AutoArrange = false;
			lvColorsGrades.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            colorG,
            polyID,
            enbld});
			lvColorsGrades.FullRowSelect = true;
			lvColorsGrades.GridLines = true;
			lvColorsGrades.HideSelection = false;
			lvColorsGrades.Location = new System.Drawing.Point(5, 20);
			lvColorsGrades.MultiSelect = false;
			lvColorsGrades.Name = "lvColorsGrades";
			lvColorsGrades.Size = new System.Drawing.Size(330, 120);
			lvColorsGrades.TabIndex = 16;
			lvColorsGrades.UseCompatibleStateImageBehavior = false;
			lvColorsGrades.View = System.Windows.Forms.View.Details;
			// 
			// colorG
			// 
			colorG.Text = "Name";
			colorG.Width = 180;
			// 
			// polyID
			// 
			polyID.Text = "Polygon ID";
			polyID.Width = 87;
			// 
			// enbld
			// 
			enbld.Text = "Enabled";
			enbld.Width = 59;
			// 
			// groupBox7
			// 
			groupBox7.Controls.Add(lbxColorsMeasures);
			groupBox7.ForeColor = System.Drawing.Color.DimGray;
			groupBox7.Location = new System.Drawing.Point(10, 15);
			groupBox7.Name = "groupBox7";
			groupBox7.Size = new System.Drawing.Size(170, 270);
			groupBox7.TabIndex = 1;
			groupBox7.TabStop = false;
			groupBox7.Text = "Measure";
			// 
			// lbxColorsMeasures
			// 
			lbxColorsMeasures.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			lbxColorsMeasures.ItemHeight = 12;
			lbxColorsMeasures.Items.AddRange(new object[] {
            "Color Grade",
            "Clarity",
            "Color",
            "Fluorescence",
            "...",
            "..."});
			lbxColorsMeasures.Location = new System.Drawing.Point(5, 20);
			lbxColorsMeasures.Name = "lbxColorsMeasures";
			lbxColorsMeasures.Size = new System.Drawing.Size(160, 244);
			lbxColorsMeasures.TabIndex = 0;
			lbxColorsMeasures.SelectedIndexChanged += new System.EventHandler(lbxColorsMeasures_SelectedIndexChanged);
			// 
			// tabPage3
			// 
			tabPage3.Controls.Add(lvUsers);
			tabPage3.Controls.Add(gbDetails);
			tabPage3.Controls.Add(bUsersSearchUser);
			tabPage3.Controls.Add(bUsersNewUser);
			tabPage3.Location = new System.Drawing.Point(22, 4);
			tabPage3.Name = "tabPage3";
			tabPage3.Size = new System.Drawing.Size(412, 642);
			tabPage3.TabIndex = 2;
			tabPage3.Text = "Users";
			// 
			// lvUsers
			// 
			lvUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            cFirstName,
            cLastName,
            cLogin,
            cDepartment,
            cRole,
            cCreated,
            cFirstLogin,
            cLastLogin,
            cLastOperation});
			lvUsers.FullRowSelect = true;
			lvUsers.GridLines = true;
			lvUsers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			lvUsers.Location = new System.Drawing.Point(10, 10);
			lvUsers.Name = "lvUsers";
			lvUsers.Size = new System.Drawing.Size(560, 440);
			lvUsers.TabIndex = 0;
			lvUsers.UseCompatibleStateImageBehavior = false;
			lvUsers.View = System.Windows.Forms.View.Details;
			lvUsers.SelectedIndexChanged += new System.EventHandler(lvUsers_SelectedIndexChanged);
			// 
			// cFirstName
			// 
			cFirstName.Text = "First Name";
			cFirstName.Width = 79;
			// 
			// cLastName
			// 
			cLastName.Text = "Last Name";
			cLastName.Width = 72;
			// 
			// cLogin
			// 
			cLogin.Text = "Login";
			cLogin.Width = 43;
			// 
			// cDepartment
			// 
			cDepartment.Text = "Department";
			cDepartment.Width = 89;
			// 
			// cRole
			// 
			cRole.Text = "Role";
			cRole.Width = 37;
			// 
			// cCreated
			// 
			cCreated.Text = "Created";
			// 
			// cFirstLogin
			// 
			cFirstLogin.Text = "First Login";
			cFirstLogin.Width = 78;
			// 
			// cLastLogin
			// 
			cLastLogin.Text = "Last Login";
			cLastLogin.Width = 70;
			// 
			// cLastOperation
			// 
			cLastOperation.Text = "Last Operation";
			cLastOperation.Width = 90;
			// 
			// gbDetails
			// 
			gbDetails.Controls.Add(cbUsersRole);
			gbDetails.Controls.Add(groupBox5);
			gbDetails.Controls.Add(tbUsersLogin);
			gbDetails.Controls.Add(label21);
			gbDetails.Controls.Add(tbUsersLastName);
			gbDetails.Controls.Add(label20);
			gbDetails.Controls.Add(cbUsersDepartment);
			gbDetails.Controls.Add(label13);
			gbDetails.Controls.Add(bUsersDelete);
			gbDetails.Controls.Add(bUsersSave);
			gbDetails.Controls.Add(bUsersClearChanges);
			gbDetails.Controls.Add(tbUsersComments);
			gbDetails.Controls.Add(groupBox4);
			gbDetails.Controls.Add(label18);
			gbDetails.Controls.Add(tbUsersFirstName);
			gbDetails.Controls.Add(label19);
			gbDetails.ForeColor = System.Drawing.Color.DimGray;
			gbDetails.Location = new System.Drawing.Point(580, 5);
			gbDetails.Name = "gbDetails";
			gbDetails.Size = new System.Drawing.Size(335, 485);
			gbDetails.TabIndex = 3;
			gbDetails.TabStop = false;
			gbDetails.Text = "First Name/Last Name/ Login";
			// 
			// cbUsersRole
			// 
			cbUsersRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbUsersRole.Location = new System.Drawing.Point(130, 207);
			cbUsersRole.Name = "cbUsersRole";
			cbUsersRole.Size = new System.Drawing.Size(200, 20);
			cbUsersRole.TabIndex = 14;
			// 
			// groupBox5
			// 
			groupBox5.Controls.Add(bUsersSavePwd);
			groupBox5.Controls.Add(bUsersClearPwd);
			groupBox5.Controls.Add(tbUsersRetypePwd);
			groupBox5.Controls.Add(label24);
			groupBox5.Controls.Add(tbUsersPwd);
			groupBox5.Controls.Add(label25);
			groupBox5.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			groupBox5.ForeColor = System.Drawing.SystemColors.ControlText;
			groupBox5.Location = new System.Drawing.Point(10, 120);
			groupBox5.Name = "groupBox5";
			groupBox5.Size = new System.Drawing.Size(320, 80);
			groupBox5.TabIndex = 5;
			groupBox5.TabStop = false;
			// 
			// bUsersSavePwd
			// 
			bUsersSavePwd.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			bUsersSavePwd.ForeColor = System.Drawing.SystemColors.ControlText;
			bUsersSavePwd.Location = new System.Drawing.Point(220, 55);
			bUsersSavePwd.Name = "bUsersSavePwd";
			bUsersSavePwd.Size = new System.Drawing.Size(95, 20);
			bUsersSavePwd.TabIndex = 3;
			bUsersSavePwd.Text = "Save";
			bUsersSavePwd.Click += new System.EventHandler(bUsersSavePwd_Click);
			// 
			// bUsersClearPwd
			// 
			bUsersClearPwd.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			bUsersClearPwd.ForeColor = System.Drawing.SystemColors.ControlText;
			bUsersClearPwd.Location = new System.Drawing.Point(120, 55);
			bUsersClearPwd.Name = "bUsersClearPwd";
			bUsersClearPwd.Size = new System.Drawing.Size(95, 20);
			bUsersClearPwd.TabIndex = 2;
			bUsersClearPwd.Text = "Clear";
			bUsersClearPwd.Click += new System.EventHandler(bUsersClearPwd_Click);
			// 
			// tbUsersRetypePwd
			// 
			tbUsersRetypePwd.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			tbUsersRetypePwd.Location = new System.Drawing.Point(120, 30);
			tbUsersRetypePwd.Name = "tbUsersRetypePwd";
			tbUsersRetypePwd.PasswordChar = '*';
			tbUsersRetypePwd.Size = new System.Drawing.Size(195, 20);
			tbUsersRetypePwd.TabIndex = 1;
			// 
			// label24
			// 
			label24.Location = new System.Drawing.Point(5, 35);
			label24.Name = "label24";
			label24.Size = new System.Drawing.Size(110, 15);
			label24.TabIndex = 3;
			label24.Text = "Retype Password";
			// 
			// tbUsersPwd
			// 
			tbUsersPwd.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			tbUsersPwd.Location = new System.Drawing.Point(120, 10);
			tbUsersPwd.Name = "tbUsersPwd";
			tbUsersPwd.PasswordChar = '*';
			tbUsersPwd.Size = new System.Drawing.Size(195, 20);
			tbUsersPwd.TabIndex = 0;
			// 
			// label25
			// 
			label25.Location = new System.Drawing.Point(5, 15);
			label25.Name = "label25";
			label25.Size = new System.Drawing.Size(110, 15);
			label25.TabIndex = 0;
			label25.Text = "Password";
			// 
			// tbUsersLogin
			// 
			tbUsersLogin.Location = new System.Drawing.Point(130, 70);
			tbUsersLogin.Name = "tbUsersLogin";
			tbUsersLogin.Size = new System.Drawing.Size(195, 20);
			tbUsersLogin.TabIndex = 3;
			// 
			// label21
			// 
			label21.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label21.ForeColor = System.Drawing.SystemColors.ControlText;
			label21.Location = new System.Drawing.Point(10, 70);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(115, 15);
			label21.TabIndex = 13;
			label21.Text = "Login";
			// 
			// tbUsersLastName
			// 
			tbUsersLastName.Location = new System.Drawing.Point(130, 45);
			tbUsersLastName.Name = "tbUsersLastName";
			tbUsersLastName.Size = new System.Drawing.Size(195, 20);
			tbUsersLastName.TabIndex = 2;
			// 
			// label20
			// 
			label20.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label20.ForeColor = System.Drawing.SystemColors.ControlText;
			label20.Location = new System.Drawing.Point(10, 45);
			label20.Name = "label20";
			label20.Size = new System.Drawing.Size(115, 15);
			label20.TabIndex = 11;
			label20.Text = "Last Name";
			// 
			// cbUsersDepartment
			// 
			cbUsersDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbUsersDepartment.Location = new System.Drawing.Point(130, 95);
			cbUsersDepartment.Name = "cbUsersDepartment";
			cbUsersDepartment.Size = new System.Drawing.Size(195, 20);
			cbUsersDepartment.TabIndex = 4;
			// 
			// label13
			// 
			label13.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label13.ForeColor = System.Drawing.SystemColors.ControlText;
			label13.Location = new System.Drawing.Point(10, 95);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(115, 15);
			label13.TabIndex = 9;
			label13.Text = "Department";
			// 
			// bUsersDelete
			// 
			bUsersDelete.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			bUsersDelete.ForeColor = System.Drawing.SystemColors.ControlText;
			bUsersDelete.Location = new System.Drawing.Point(220, 455);
			bUsersDelete.Name = "bUsersDelete";
			bUsersDelete.Size = new System.Drawing.Size(105, 20);
			bUsersDelete.TabIndex = 11;
			bUsersDelete.Text = "Delete User";
			bUsersDelete.Click += new System.EventHandler(bUsersDelete_Click);
			// 
			// bUsersSave
			// 
			bUsersSave.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			bUsersSave.ForeColor = System.Drawing.SystemColors.ControlText;
			bUsersSave.Location = new System.Drawing.Point(125, 455);
			bUsersSave.Name = "bUsersSave";
			bUsersSave.Size = new System.Drawing.Size(90, 20);
			bUsersSave.TabIndex = 10;
			bUsersSave.Text = "Save";
			bUsersSave.Click += new System.EventHandler(bUsersSave_Click);
			// 
			// bUsersClearChanges
			// 
			bUsersClearChanges.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			bUsersClearChanges.ForeColor = System.Drawing.SystemColors.ControlText;
			bUsersClearChanges.Location = new System.Drawing.Point(10, 455);
			bUsersClearChanges.Name = "bUsersClearChanges";
			bUsersClearChanges.Size = new System.Drawing.Size(110, 20);
			bUsersClearChanges.TabIndex = 9;
			bUsersClearChanges.Text = "Clear Changes ";
			bUsersClearChanges.Click += new System.EventHandler(bUsersClearChanges_Click);
			// 
			// tbUsersComments
			// 
			tbUsersComments.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			tbUsersComments.Location = new System.Drawing.Point(10, 330);
			tbUsersComments.Multiline = true;
			tbUsersComments.Name = "tbUsersComments";
			tbUsersComments.Size = new System.Drawing.Size(315, 120);
			tbUsersComments.TabIndex = 8;
			// 
			// groupBox4
			// 
			groupBox4.Controls.Add(tbUsersLastOperation);
			groupBox4.Controls.Add(label14);
			groupBox4.Controls.Add(tbUsersLastLogin);
			groupBox4.Controls.Add(label15);
			groupBox4.Controls.Add(tbUsersFirstLogin);
			groupBox4.Controls.Add(label16);
			groupBox4.Controls.Add(tbUsersCreated);
			groupBox4.Controls.Add(label17);
			groupBox4.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			groupBox4.ForeColor = System.Drawing.SystemColors.ControlText;
			groupBox4.Location = new System.Drawing.Point(10, 230);
			groupBox4.Name = "groupBox4";
			groupBox4.Size = new System.Drawing.Size(320, 95);
			groupBox4.TabIndex = 7;
			groupBox4.TabStop = false;
			// 
			// tbUsersLastOperation
			// 
			tbUsersLastOperation.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			tbUsersLastOperation.Location = new System.Drawing.Point(120, 70);
			tbUsersLastOperation.Name = "tbUsersLastOperation";
			tbUsersLastOperation.Size = new System.Drawing.Size(195, 20);
			tbUsersLastOperation.TabIndex = 3;
			tbUsersLastOperation.Text = "00/00/0000  12:00AM";
			// 
			// label14
			// 
			label14.Location = new System.Drawing.Point(5, 75);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(110, 15);
			label14.TabIndex = 7;
			label14.Text = "Last Operation";
			// 
			// tbUsersLastLogin
			// 
			tbUsersLastLogin.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			tbUsersLastLogin.Location = new System.Drawing.Point(120, 50);
			tbUsersLastLogin.Name = "tbUsersLastLogin";
			tbUsersLastLogin.Size = new System.Drawing.Size(195, 20);
			tbUsersLastLogin.TabIndex = 2;
			tbUsersLastLogin.Text = "00/00/0000  12:00AM";
			// 
			// label15
			// 
			label15.Location = new System.Drawing.Point(5, 55);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(110, 15);
			label15.TabIndex = 5;
			label15.Text = "Last Login";
			// 
			// tbUsersFirstLogin
			// 
			tbUsersFirstLogin.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			tbUsersFirstLogin.Location = new System.Drawing.Point(120, 30);
			tbUsersFirstLogin.Name = "tbUsersFirstLogin";
			tbUsersFirstLogin.Size = new System.Drawing.Size(195, 20);
			tbUsersFirstLogin.TabIndex = 1;
			tbUsersFirstLogin.Text = "00/00/0000  12:00AM";
			// 
			// label16
			// 
			label16.Location = new System.Drawing.Point(5, 35);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(110, 15);
			label16.TabIndex = 3;
			label16.Text = "First Login";
			// 
			// tbUsersCreated
			// 
			tbUsersCreated.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			tbUsersCreated.Location = new System.Drawing.Point(120, 10);
			tbUsersCreated.Name = "tbUsersCreated";
			tbUsersCreated.Size = new System.Drawing.Size(195, 20);
			tbUsersCreated.TabIndex = 0;
			tbUsersCreated.Text = "00/00/0000  12:00AM";
			// 
			// label17
			// 
			label17.Location = new System.Drawing.Point(5, 15);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(110, 15);
			label17.TabIndex = 0;
			label17.Text = "Created";
			// 
			// label18
			// 
			label18.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label18.ForeColor = System.Drawing.SystemColors.ControlText;
			label18.Location = new System.Drawing.Point(10, 210);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(115, 15);
			label18.TabIndex = 2;
			label18.Text = "User\'s Role";
			// 
			// tbUsersFirstName
			// 
			tbUsersFirstName.Location = new System.Drawing.Point(130, 20);
			tbUsersFirstName.Name = "tbUsersFirstName";
			tbUsersFirstName.Size = new System.Drawing.Size(195, 20);
			tbUsersFirstName.TabIndex = 1;
			// 
			// label19
			// 
			label19.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label19.ForeColor = System.Drawing.SystemColors.ControlText;
			label19.Location = new System.Drawing.Point(10, 20);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(115, 15);
			label19.TabIndex = 0;
			label19.Text = "First Name";
			// 
			// bUsersSearchUser
			// 
			bUsersSearchUser.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			bUsersSearchUser.Location = new System.Drawing.Point(495, 460);
			bUsersSearchUser.Name = "bUsersSearchUser";
			bUsersSearchUser.Size = new System.Drawing.Size(75, 23);
			bUsersSearchUser.TabIndex = 2;
			bUsersSearchUser.Text = "Search";
			bUsersSearchUser.Click += new System.EventHandler(bUsersSearchUser_Click);
			// 
			// bUsersNewUser
			// 
			bUsersNewUser.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			bUsersNewUser.Location = new System.Drawing.Point(410, 460);
			bUsersNewUser.Name = "bUsersNewUser";
			bUsersNewUser.Size = new System.Drawing.Size(75, 23);
			bUsersNewUser.TabIndex = 1;
			bUsersNewUser.Text = "New";
			bUsersNewUser.Click += new System.EventHandler(bUsersNewUser_Click);
			// 
			// tabPage2
			// 
			tabPage2.Controls.Add(groupBox1);
			tabPage2.Controls.Add(button5);
			tabPage2.Controls.Add(button4);
			tabPage2.Controls.Add(listBox1);
			tabPage2.Location = new System.Drawing.Point(22, 4);
			tabPage2.Name = "tabPage2";
			tabPage2.Size = new System.Drawing.Size(412, 642);
			tabPage2.TabIndex = 1;
			tabPage2.Text = "Departments";
			tabPage2.Click += new System.EventHandler(tabPage2_Click);
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(comboBox2);
			groupBox1.Controls.Add(label12);
			groupBox1.Controls.Add(button8);
			groupBox1.Controls.Add(button7);
			groupBox1.Controls.Add(button6);
			groupBox1.Controls.Add(textBox7);
			groupBox1.Controls.Add(groupBox2);
			groupBox1.Controls.Add(checkedListBox1);
			groupBox1.Controls.Add(label7);
			groupBox1.Controls.Add(textBox2);
			groupBox1.Controls.Add(label6);
			groupBox1.ForeColor = System.Drawing.Color.DimGray;
			groupBox1.Location = new System.Drawing.Point(580, 5);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(335, 355);
			groupBox1.TabIndex = 3;
			groupBox1.TabStop = false;
			groupBox1.Text = "Department Name";
			// 
			// comboBox2
			// 
			comboBox2.Location = new System.Drawing.Point(130, 45);
			comboBox2.Name = "comboBox2";
			comboBox2.Size = new System.Drawing.Size(195, 20);
			comboBox2.TabIndex = 10;
			comboBox2.Text = "comboBox2";
			// 
			// label12
			// 
			label12.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label12.ForeColor = System.Drawing.SystemColors.ControlText;
			label12.Location = new System.Drawing.Point(10, 45);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(115, 15);
			label12.TabIndex = 9;
			label12.Text = "Office";
			// 
			// button8
			// 
			button8.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			button8.ForeColor = System.Drawing.SystemColors.ControlText;
			button8.Location = new System.Drawing.Point(210, 325);
			button8.Name = "button8";
			button8.Size = new System.Drawing.Size(115, 20);
			button8.TabIndex = 8;
			button8.Text = "Delete Department  ";
			// 
			// button7
			// 
			button7.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			button7.ForeColor = System.Drawing.SystemColors.ControlText;
			button7.Location = new System.Drawing.Point(115, 325);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(90, 20);
			button7.TabIndex = 7;
			button7.Text = "Save";
			// 
			// button6
			// 
			button6.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			button6.ForeColor = System.Drawing.SystemColors.ControlText;
			button6.Location = new System.Drawing.Point(10, 325);
			button6.Name = "button6";
			button6.Size = new System.Drawing.Size(100, 20);
			button6.TabIndex = 6;
			button6.Text = "Clear Changes ";
			// 
			// textBox7
			// 
			textBox7.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			textBox7.Location = new System.Drawing.Point(10, 225);
			textBox7.Multiline = true;
			textBox7.Name = "textBox7";
			textBox7.Size = new System.Drawing.Size(315, 95);
			textBox7.TabIndex = 5;
			textBox7.Text = "Department Description";
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(textBox6);
			groupBox2.Controls.Add(label11);
			groupBox2.Controls.Add(textBox5);
			groupBox2.Controls.Add(label10);
			groupBox2.Controls.Add(textBox4);
			groupBox2.Controls.Add(label9);
			groupBox2.Controls.Add(textBox3);
			groupBox2.Controls.Add(label8);
			groupBox2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
			groupBox2.Location = new System.Drawing.Point(10, 125);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(320, 95);
			groupBox2.TabIndex = 4;
			groupBox2.TabStop = false;
			// 
			// textBox6
			// 
			textBox6.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			textBox6.Location = new System.Drawing.Point(120, 70);
			textBox6.Name = "textBox6";
			textBox6.Size = new System.Drawing.Size(195, 20);
			textBox6.TabIndex = 8;
			textBox6.Text = "00/00/0000  12:00AM";
			// 
			// label11
			// 
			label11.Location = new System.Drawing.Point(5, 75);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(110, 15);
			label11.TabIndex = 7;
			label11.Text = "Last Operation";
			// 
			// textBox5
			// 
			textBox5.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			textBox5.Location = new System.Drawing.Point(120, 50);
			textBox5.Name = "textBox5";
			textBox5.Size = new System.Drawing.Size(195, 20);
			textBox5.TabIndex = 6;
			textBox5.Text = "00/00/0000  12:00AM";
			// 
			// label10
			// 
			label10.Location = new System.Drawing.Point(5, 55);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(110, 15);
			label10.TabIndex = 5;
			label10.Text = "Last Login";
			// 
			// textBox4
			// 
			textBox4.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			textBox4.Location = new System.Drawing.Point(120, 30);
			textBox4.Name = "textBox4";
			textBox4.Size = new System.Drawing.Size(195, 20);
			textBox4.TabIndex = 4;
			textBox4.Text = "00/00/0000  12:00AM";
			// 
			// label9
			// 
			label9.Location = new System.Drawing.Point(5, 35);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(110, 15);
			label9.TabIndex = 3;
			label9.Text = "First Login";
			// 
			// textBox3
			// 
			textBox3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			textBox3.Location = new System.Drawing.Point(120, 10);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(195, 20);
			textBox3.TabIndex = 2;
			textBox3.Text = "00/00/0000  12:00AM";
			// 
			// label8
			// 
			label8.Location = new System.Drawing.Point(5, 15);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(110, 15);
			label8.TabIndex = 0;
			label8.Text = "Created";
			// 
			// checkedListBox1
			// 
			checkedListBox1.Items.AddRange(new object[] {
            "Manager",
            "Top Manager",
            "System Administrator"});
			checkedListBox1.Location = new System.Drawing.Point(130, 70);
			checkedListBox1.Name = "checkedListBox1";
			checkedListBox1.Size = new System.Drawing.Size(195, 49);
			checkedListBox1.TabIndex = 3;
			// 
			// label7
			// 
			label7.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label7.ForeColor = System.Drawing.SystemColors.ControlText;
			label7.Location = new System.Drawing.Point(10, 70);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(115, 15);
			label7.TabIndex = 2;
			label7.Text = "General Permissions";
			// 
			// textBox2
			// 
			textBox2.Location = new System.Drawing.Point(130, 20);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(195, 20);
			textBox2.TabIndex = 1;
			textBox2.Text = "textBox2";
			// 
			// label6
			// 
			label6.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label6.ForeColor = System.Drawing.SystemColors.ControlText;
			label6.Location = new System.Drawing.Point(10, 20);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(115, 15);
			label6.TabIndex = 0;
			label6.Text = "Department Name";
			// 
			// button5
			// 
			button5.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			button5.Location = new System.Drawing.Point(495, 335);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(75, 23);
			button5.TabIndex = 2;
			button5.Text = "Search";
			// 
			// button4
			// 
			button4.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			button4.Location = new System.Drawing.Point(410, 335);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(75, 23);
			button4.TabIndex = 1;
			button4.Text = "New";
			// 
			// listBox1
			// 
			listBox1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			listBox1.ItemHeight = 12;
			listBox1.Items.AddRange(new object[] {
            "Department Name ... ... ...",
            "Department Name ... ... ...",
            "Department Name ... ... ...",
            "Department Name ... ... ..."});
			listBox1.Location = new System.Drawing.Point(10, 10);
			listBox1.Name = "listBox1";
			listBox1.Size = new System.Drawing.Size(560, 316);
			listBox1.TabIndex = 0;
			// 
			// tabPage4
			// 
			tabPage4.Controls.Add(groupBox6);
			tabPage4.Controls.Add(button16);
			tabPage4.Controls.Add(button17);
			tabPage4.Controls.Add(listBox3);
			tabPage4.Location = new System.Drawing.Point(22, 4);
			tabPage4.Name = "tabPage4";
			tabPage4.Size = new System.Drawing.Size(412, 642);
			tabPage4.TabIndex = 3;
			tabPage4.Text = "Readers";
			tabPage4.Click += new System.EventHandler(tabPage4_Click);
			// 
			// groupBox6
			// 
			groupBox6.Controls.Add(checkBox1);
			groupBox6.Controls.Add(textBox17);
			groupBox6.Controls.Add(label27);
			groupBox6.Controls.Add(textBox16);
			groupBox6.Controls.Add(label26);
			groupBox6.Controls.Add(comboBox5);
			groupBox6.Controls.Add(label23);
			groupBox6.Controls.Add(comboBox4);
			groupBox6.Controls.Add(label22);
			groupBox6.Controls.Add(textBox23);
			groupBox6.Controls.Add(label30);
			groupBox6.ForeColor = System.Drawing.Color.DimGray;
			groupBox6.Location = new System.Drawing.Point(580, 5);
			groupBox6.Name = "groupBox6";
			groupBox6.Size = new System.Drawing.Size(335, 170);
			groupBox6.TabIndex = 5;
			groupBox6.TabStop = false;
			groupBox6.Text = "Scanner Details";
			// 
			// checkBox1
			// 
			checkBox1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			checkBox1.ForeColor = System.Drawing.SystemColors.ControlText;
			checkBox1.Location = new System.Drawing.Point(255, 15);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new System.Drawing.Size(70, 15);
			checkBox1.TabIndex = 17;
			checkBox1.Text = "Enabled";
			// 
			// textBox17
			// 
			textBox17.Location = new System.Drawing.Point(130, 135);
			textBox17.Name = "textBox17";
			textBox17.Size = new System.Drawing.Size(195, 20);
			textBox17.TabIndex = 16;
			// 
			// label27
			// 
			label27.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label27.ForeColor = System.Drawing.SystemColors.ControlText;
			label27.Location = new System.Drawing.Point(10, 135);
			label27.Name = "label27";
			label27.Size = new System.Drawing.Size(115, 15);
			label27.TabIndex = 15;
			label27.Text = "Office";
			// 
			// textBox16
			// 
			textBox16.Location = new System.Drawing.Point(130, 110);
			textBox16.Name = "textBox16";
			textBox16.Size = new System.Drawing.Size(195, 20);
			textBox16.TabIndex = 14;
			// 
			// label26
			// 
			label26.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label26.ForeColor = System.Drawing.SystemColors.ControlText;
			label26.Location = new System.Drawing.Point(10, 110);
			label26.Name = "label26";
			label26.Size = new System.Drawing.Size(115, 15);
			label26.TabIndex = 13;
			label26.Text = "Location Name";
			// 
			// comboBox5
			// 
			comboBox5.Location = new System.Drawing.Point(130, 85);
			comboBox5.Name = "comboBox5";
			comboBox5.Size = new System.Drawing.Size(195, 20);
			comboBox5.TabIndex = 12;
			// 
			// label23
			// 
			label23.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label23.ForeColor = System.Drawing.SystemColors.ControlText;
			label23.Location = new System.Drawing.Point(10, 85);
			label23.Name = "label23";
			label23.Size = new System.Drawing.Size(115, 15);
			label23.TabIndex = 11;
			label23.Text = "Department";
			// 
			// comboBox4
			// 
			comboBox4.Location = new System.Drawing.Point(130, 60);
			comboBox4.Name = "comboBox4";
			comboBox4.Size = new System.Drawing.Size(195, 20);
			comboBox4.TabIndex = 10;
			// 
			// label22
			// 
			label22.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label22.ForeColor = System.Drawing.SystemColors.ControlText;
			label22.Location = new System.Drawing.Point(10, 60);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(115, 15);
			label22.TabIndex = 9;
			label22.Text = "Office";
			// 
			// textBox23
			// 
			textBox23.Location = new System.Drawing.Point(130, 35);
			textBox23.Name = "textBox23";
			textBox23.Size = new System.Drawing.Size(195, 20);
			textBox23.TabIndex = 1;
			// 
			// label30
			// 
			label30.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label30.ForeColor = System.Drawing.SystemColors.ControlText;
			label30.Location = new System.Drawing.Point(10, 35);
			label30.Name = "label30";
			label30.Size = new System.Drawing.Size(115, 15);
			label30.TabIndex = 0;
			label30.Text = "Scanner ID";
			// 
			// button16
			// 
			button16.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			button16.Location = new System.Drawing.Point(495, 155);
			button16.Name = "button16";
			button16.Size = new System.Drawing.Size(75, 23);
			button16.TabIndex = 4;
			button16.Text = "Search";
			// 
			// button17
			// 
			button17.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			button17.Location = new System.Drawing.Point(410, 155);
			button17.Name = "button17";
			button17.Size = new System.Drawing.Size(75, 23);
			button17.TabIndex = 3;
			button17.Text = "New";
			// 
			// listBox3
			// 
			listBox3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			listBox3.ItemHeight = 12;
			listBox3.Items.AddRange(new object[] {
            "Scanner_ID\tDepartment\tLocation Name\tOffice\tEnabled",
            "Scanner_ID\tDepartment\tLocation Name\tOffice\tEnabled",
            "Scanner_ID\tDepartment\tLocation Name\tOffice\tEnabled",
            "Scanner_ID\tDepartment\tLocation Name\tOffice\tEnabled",
            "Scanner_ID\tDepartment\tLocation Name\tOffice\tEnabled"});
			listBox3.Location = new System.Drawing.Point(10, 10);
			listBox3.Name = "listBox3";
			listBox3.Size = new System.Drawing.Size(560, 136);
			listBox3.TabIndex = 1;
			// 
			// tbNewStructure
			// 
			tbNewStructure.Controls.Add(cbStructureIsItemTypeGroupChild);
			tbNewStructure.Controls.Add(tbStructureGroupName);
			tbNewStructure.Controls.Add(label108);
			tbNewStructure.Controls.Add(pbStructureItemPicture);
			tbNewStructure.Controls.Add(label107);
			tbNewStructure.Controls.Add(btnStructureMoveItemPartBack);
			tbNewStructure.Controls.Add(btnStructureClear);
			tbNewStructure.Controls.Add(btnStructureSave);
			tbNewStructure.Controls.Add(btnStructureDeleteItem);
			tbNewStructure.Controls.Add(ptStructureNewItem);
			tbNewStructure.Controls.Add(ipStructureStructures);
			tbNewStructure.Controls.Add(pbStructureItemTypeGroup);
			tbNewStructure.Controls.Add(pbStructureItemType);
			tbNewStructure.Controls.Add(tbStructureItemTypeIconPath);
			tbNewStructure.Controls.Add(tbStructureItemTypeGroupIconPath);
			tbNewStructure.Controls.Add(lbStructureItemTypeIconPath);
			tbNewStructure.Controls.Add(lbStructureItemGroupIconPath);
			tbNewStructure.Controls.Add(lbStructurePicPath);
			tbNewStructure.Controls.Add(tbStructureItemTypePicPath);
			tbNewStructure.Controls.Add(lbStructureMeasures);
			tbNewStructure.Controls.Add(lbStructurePartTypes);
			tbNewStructure.Controls.Add(btnStructureMoveItemPart);
			tbNewStructure.Controls.Add(lbStructureItemPartList);
			tbNewStructure.Controls.Add(btnStructuresDeleteGroup);
			tbNewStructure.Controls.Add(btnStructureNewGroup);
			tbNewStructure.Controls.Add(tbStructureNewItemName);
			tbNewStructure.Controls.Add(lbStructureNewItemName);
			tbNewStructure.Location = new System.Drawing.Point(22, 4);
			tbNewStructure.Name = "tbNewStructure";
			tbNewStructure.Size = new System.Drawing.Size(412, 642);
			tbNewStructure.TabIndex = 8;
			tbNewStructure.Text = "Structure";
			tbNewStructure.Click += new System.EventHandler(tbNewStructure_Click);
			tbNewStructure.Enter += new System.EventHandler(tbNewStructure_Enter);
			// 
			// cbStructureIsItemTypeGroupChild
			// 
			cbStructureIsItemTypeGroupChild.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			cbStructureIsItemTypeGroupChild.Location = new System.Drawing.Point(770, 150);
			cbStructureIsItemTypeGroupChild.Name = "cbStructureIsItemTypeGroupChild";
			cbStructureIsItemTypeGroupChild.Size = new System.Drawing.Size(104, 15);
			cbStructureIsItemTypeGroupChild.TabIndex = 33;
			cbStructureIsItemTypeGroupChild.Text = "add as a child";
			// 
			// tbStructureGroupName
			// 
			tbStructureGroupName.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			tbStructureGroupName.Location = new System.Drawing.Point(760, 35);
			tbStructureGroupName.Name = "tbStructureGroupName";
			tbStructureGroupName.Size = new System.Drawing.Size(155, 20);
			tbStructureGroupName.TabIndex = 32;
			tbStructureGroupName.TextChanged += new System.EventHandler(tbStructureGroupName_TextChanged);
			// 
			// label108
			// 
			label108.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			label108.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label108.Location = new System.Drawing.Point(760, 20);
			label108.Name = "label108";
			label108.Size = new System.Drawing.Size(136, 15);
			label108.TabIndex = 31;
			label108.Text = "Enter group name:";
			// 
			// pbStructureItemPicture
			// 
			pbStructureItemPicture.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbStructureItemPicture.BackgroundImage")));
			pbStructureItemPicture.Location = new System.Drawing.Point(770, 375);
			pbStructureItemPicture.Name = "pbStructureItemPicture";
			pbStructureItemPicture.Size = new System.Drawing.Size(125, 130);
			pbStructureItemPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			pbStructureItemPicture.TabIndex = 30;
			pbStructureItemPicture.TabStop = false;
			pbStructureItemPicture.Paint += new System.Windows.Forms.PaintEventHandler(pbItemPicture_Paint);
			// 
			// label107
			// 
			label107.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			label107.Location = new System.Drawing.Point(15, 285);
			label107.Name = "label107";
			label107.Size = new System.Drawing.Size(130, 15);
			label107.TabIndex = 29;
			label107.Text = "Measures";
			// 
			// btnStructureMoveItemPartBack
			// 
			btnStructureMoveItemPartBack.Location = new System.Drawing.Point(390, 335);
			btnStructureMoveItemPartBack.Name = "btnStructureMoveItemPartBack";
			btnStructureMoveItemPartBack.Size = new System.Drawing.Size(45, 23);
			btnStructureMoveItemPartBack.TabIndex = 28;
			btnStructureMoveItemPartBack.Text = "<-";
			btnStructureMoveItemPartBack.Click += new System.EventHandler(btnStructureMoveItemPartBack_Click);
			// 
			// btnStructureClear
			// 
			btnStructureClear.Location = new System.Drawing.Point(820, 610);
			btnStructureClear.Name = "btnStructureClear";
			btnStructureClear.Size = new System.Drawing.Size(95, 23);
			btnStructureClear.TabIndex = 27;
			btnStructureClear.Text = "Clear";
			btnStructureClear.Click += new System.EventHandler(btnStructureClear_Click);
			// 
			// btnStructureSave
			// 
			btnStructureSave.BackColor = System.Drawing.Color.LightSteelBlue;
			btnStructureSave.Location = new System.Drawing.Point(700, 610);
			btnStructureSave.Name = "btnStructureSave";
			btnStructureSave.Size = new System.Drawing.Size(95, 23);
			btnStructureSave.TabIndex = 26;
			btnStructureSave.Text = "Save";
			btnStructureSave.UseVisualStyleBackColor = false;
			btnStructureSave.Click += new System.EventHandler(btnStructureSave_Click);
			// 
			// btnStructureDeleteItem
			// 
			btnStructureDeleteItem.BackColor = System.Drawing.Color.LightPink;
			btnStructureDeleteItem.Location = new System.Drawing.Point(380, 215);
			btnStructureDeleteItem.Name = "btnStructureDeleteItem";
			btnStructureDeleteItem.Size = new System.Drawing.Size(95, 20);
			btnStructureDeleteItem.TabIndex = 25;
			btnStructureDeleteItem.Text = "Delete Item";
			btnStructureDeleteItem.UseVisualStyleBackColor = false;
			btnStructureDeleteItem.Click += new System.EventHandler(btnStructureDeleteItem_Click);
			// 
			// ptStructureNewItem
			// 
			ptStructureNewItem.Location = new System.Drawing.Point(445, 300);
			ptStructureNewItem.Name = "ptStructureNewItem";
			ptStructureNewItem.Size = new System.Drawing.Size(295, 305);
			ptStructureNewItem.TabIndex = 24;
			ptStructureNewItem.Load += new System.EventHandler(ptStructureNewItem_Load);
			// 
			// ipStructureStructures
			// 
			ipStructureStructures.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			ipStructureStructures.FullItemName = "Full Item Name";
			ipStructureStructures.ItemPicture = null;
			ipStructureStructures.Location = new System.Drawing.Point(10, 5);
			ipStructureStructures.Name = "ipStructureStructures";
			ipStructureStructures.Size = new System.Drawing.Size(745, 205);
			ipStructureStructures.TabIndex = 23;
			ipStructureStructures.ItemTypeSelected += new System.EventHandler(ipStructureStructures_ItemTypeSelected);
			ipStructureStructures.NewItemTypeSelected += new System.EventHandler(ipStructureStructures_NewItemTypeSelected_2);
			ipStructureStructures.SelectedItemTypeChanged += new System.EventHandler(ipStructureStructures_SelectedItemTypeChanged);
			ipStructureStructures.ItemTypeClicked += new System.EventHandler(ipStructureStructures_ItemTypeClicked);
			// 
			// pbStructureItemTypeGroup
			// 
			pbStructureItemTypeGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pbStructureItemTypeGroup.Location = new System.Drawing.Point(770, 105);
			pbStructureItemTypeGroup.Name = "pbStructureItemTypeGroup";
			pbStructureItemTypeGroup.Size = new System.Drawing.Size(17, 18);
			pbStructureItemTypeGroup.TabIndex = 22;
			pbStructureItemTypeGroup.TabStop = false;
			// 
			// pbStructureItemType
			// 
			pbStructureItemType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pbStructureItemType.Location = new System.Drawing.Point(750, 305);
			pbStructureItemType.Name = "pbStructureItemType";
			pbStructureItemType.Size = new System.Drawing.Size(33, 34);
			pbStructureItemType.TabIndex = 21;
			pbStructureItemType.TabStop = false;
			// 
			// tbStructureItemTypeIconPath
			// 
			tbStructureItemTypeIconPath.Location = new System.Drawing.Point(790, 320);
			tbStructureItemTypeIconPath.Name = "tbStructureItemTypeIconPath";
			tbStructureItemTypeIconPath.Size = new System.Drawing.Size(120, 20);
			tbStructureItemTypeIconPath.TabIndex = 20;
			tbStructureItemTypeIconPath.KeyDown += new System.Windows.Forms.KeyEventHandler(tbStructureItemTypeIconPath_KeyDown);
			// 
			// tbStructureItemTypeGroupIconPath
			// 
			tbStructureItemTypeGroupIconPath.Location = new System.Drawing.Point(800, 105);
			tbStructureItemTypeGroupIconPath.Name = "tbStructureItemTypeGroupIconPath";
			tbStructureItemTypeGroupIconPath.Size = new System.Drawing.Size(115, 20);
			tbStructureItemTypeGroupIconPath.TabIndex = 19;
			tbStructureItemTypeGroupIconPath.KeyDown += new System.Windows.Forms.KeyEventHandler(tbStructureItemTypeGroupIconPath_KeyDown);
			// 
			// lbStructureItemTypeIconPath
			// 
			lbStructureItemTypeIconPath.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			lbStructureItemTypeIconPath.Location = new System.Drawing.Point(790, 300);
			lbStructureItemTypeIconPath.Name = "lbStructureItemTypeIconPath";
			lbStructureItemTypeIconPath.Size = new System.Drawing.Size(115, 20);
			lbStructureItemTypeIconPath.TabIndex = 18;
			lbStructureItemTypeIconPath.Text = "Item Type Icon Path";
			// 
			// lbStructureItemGroupIconPath
			// 
			lbStructureItemGroupIconPath.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			lbStructureItemGroupIconPath.Location = new System.Drawing.Point(760, 85);
			lbStructureItemGroupIconPath.Name = "lbStructureItemGroupIconPath";
			lbStructureItemGroupIconPath.Size = new System.Drawing.Size(155, 15);
			lbStructureItemGroupIconPath.TabIndex = 17;
			lbStructureItemGroupIconPath.Text = "Item Type Group Icon Path";
			// 
			// lbStructurePicPath
			// 
			lbStructurePicPath.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			lbStructurePicPath.Location = new System.Drawing.Point(750, 525);
			lbStructurePicPath.Name = "lbStructurePicPath";
			lbStructurePicPath.Size = new System.Drawing.Size(160, 15);
			lbStructurePicPath.TabIndex = 16;
			lbStructurePicPath.Text = "Item Type Picture Path";
			// 
			// tbStructureItemTypePicPath
			// 
			tbStructureItemTypePicPath.Location = new System.Drawing.Point(750, 545);
			tbStructureItemTypePicPath.Name = "tbStructureItemTypePicPath";
			tbStructureItemTypePicPath.Size = new System.Drawing.Size(165, 20);
			tbStructureItemTypePicPath.TabIndex = 15;
			tbStructureItemTypePicPath.KeyDown += new System.Windows.Forms.KeyEventHandler(tbStructurePicPath_KeyDown);
			// 
			// lbStructureMeasures
			// 
			lbStructureMeasures.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			lbStructureMeasures.ItemHeight = 12;
			lbStructureMeasures.Location = new System.Drawing.Point(10, 300);
			lbStructureMeasures.Name = "lbStructureMeasures";
			lbStructureMeasures.Size = new System.Drawing.Size(170, 304);
			lbStructureMeasures.Sorted = true;
			lbStructureMeasures.TabIndex = 14;
			// 
			// lbStructurePartTypes
			// 
			lbStructurePartTypes.ItemHeight = 12;
			lbStructurePartTypes.Location = new System.Drawing.Point(195, 300);
			lbStructurePartTypes.Name = "lbStructurePartTypes";
			lbStructurePartTypes.Size = new System.Drawing.Size(185, 304);
			lbStructurePartTypes.TabIndex = 13;
			lbStructurePartTypes.SelectedIndexChanged += new System.EventHandler(lbStructurePartTypes_SelectedIndexChanged);
			// 
			// btnStructureMoveItemPart
			// 
			btnStructureMoveItemPart.Location = new System.Drawing.Point(390, 305);
			btnStructureMoveItemPart.Name = "btnStructureMoveItemPart";
			btnStructureMoveItemPart.Size = new System.Drawing.Size(45, 23);
			btnStructureMoveItemPart.TabIndex = 10;
			btnStructureMoveItemPart.Text = "->";
			btnStructureMoveItemPart.Click += new System.EventHandler(btnStructureMoveItemPart_Click);
			// 
			// lbStructureItemPartList
			// 
			lbStructureItemPartList.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			lbStructureItemPartList.Location = new System.Drawing.Point(200, 285);
			lbStructureItemPartList.Name = "lbStructureItemPartList";
			lbStructureItemPartList.Size = new System.Drawing.Size(130, 15);
			lbStructureItemPartList.TabIndex = 9;
			lbStructureItemPartList.Text = "Item part list";
			// 
			// btnStructuresDeleteGroup
			// 
			btnStructuresDeleteGroup.BackColor = System.Drawing.Color.LightPink;
			btnStructuresDeleteGroup.Location = new System.Drawing.Point(655, 215);
			btnStructuresDeleteGroup.Name = "btnStructuresDeleteGroup";
			btnStructuresDeleteGroup.Size = new System.Drawing.Size(95, 20);
			btnStructuresDeleteGroup.TabIndex = 7;
			btnStructuresDeleteGroup.Text = "Delete Group";
			btnStructuresDeleteGroup.UseVisualStyleBackColor = false;
			btnStructuresDeleteGroup.Click += new System.EventHandler(btnStructuresDeleteGroup_Click);
			// 
			// btnStructureNewGroup
			// 
			btnStructureNewGroup.BackColor = System.Drawing.Color.LightSteelBlue;
			btnStructureNewGroup.Location = new System.Drawing.Point(765, 185);
			btnStructureNewGroup.Name = "btnStructureNewGroup";
			btnStructureNewGroup.Size = new System.Drawing.Size(150, 20);
			btnStructureNewGroup.TabIndex = 6;
			btnStructureNewGroup.Text = "New Group";
			btnStructureNewGroup.UseVisualStyleBackColor = false;
			btnStructureNewGroup.Click += new System.EventHandler(btnStructureNewGroup_Click);
			// 
			// tbStructureNewItemName
			// 
			tbStructureNewItemName.Enabled = false;
			tbStructureNewItemName.Location = new System.Drawing.Point(110, 250);
			tbStructureNewItemName.Name = "tbStructureNewItemName";
			tbStructureNewItemName.Size = new System.Drawing.Size(800, 20);
			tbStructureNewItemName.TabIndex = 3;
			// 
			// lbStructureNewItemName
			// 
			lbStructureNewItemName.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			lbStructureNewItemName.Location = new System.Drawing.Point(15, 255);
			lbStructureNewItemName.Name = "lbStructureNewItemName";
			lbStructureNewItemName.Size = new System.Drawing.Size(95, 15);
			lbStructureNewItemName.TabIndex = 2;
			lbStructureNewItemName.Text = "New Item Name";
			lbStructureNewItemName.Click += new System.EventHandler(lbStructureNewItemName_Click);
			// 
			// sbStatus
			// 
			sbStatus.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			sbStatus.Location = new System.Drawing.Point(0, 653);
			sbStatus.Name = "sbStatus";
			sbStatus.Size = new System.Drawing.Size(944, 15);
			sbStatus.TabIndex = 1;
			sbStatus.Text = "Ready";
			// 
			// ilStructureItemType
			// 
			ilStructureItemType.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			ilStructureItemType.ImageSize = new System.Drawing.Size(32, 32);
			ilStructureItemType.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// tabPage8
			// 
			tabPage8.BackColor = System.Drawing.SystemColors.Control;
			tabPage8.Controls.Add(textBox1);
			tabPage8.Controls.Add(comboBox1);
			tabPage8.Controls.Add(cbcCustomer);
			tabPage8.Controls.Add(ptPartTree);
			tabPage8.Location = new System.Drawing.Point(40, 4);
			tabPage8.Name = "tabPage8";
			tabPage8.Size = new System.Drawing.Size(900, 642);
			tabPage8.TabIndex = 9;
			tabPage8.Text = "Excel Data";
			// 
			// ptPartTree
			// 
			ptPartTree.Location = new System.Drawing.Point(15, 8);
			ptPartTree.Name = "ptPartTree";
			ptPartTree.Size = new System.Drawing.Size(315, 266);
			ptPartTree.TabIndex = 42;
			// 
			// cbcCustomer
			// 
			cbcCustomer.DefaultText = "Customer Lookup";
			cbcCustomer.DisplayMember = "CustomerName";
			cbcCustomer.InsertDefaultRow = true;
			cbcCustomer.Location = new System.Drawing.Point(352, 8);
			cbcCustomer.Name = "cbcCustomer";
			cbcCustomer.SelectedCode = "";
			cbcCustomer.Size = new System.Drawing.Size(400, 20);
			cbcCustomer.TabIndex = 43;
			cbcCustomer.ValueMember = "CustomerOfficeID_CustomerID";
			// 
			// comboBox1
			// 
			comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBox1.FormattingEnabled = true;
			comboBox1.Location = new System.Drawing.Point(657, 116);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new System.Drawing.Size(220, 20);
			comboBox1.TabIndex = 44;
			// 
			// textBox1
			// 
			textBox1.Location = new System.Drawing.Point(428, 114);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(205, 20);
			textBox1.TabIndex = 45;
			// 
			// UtilsForm
			// 
			AutoScaleBaseSize = new System.Drawing.Size(6, 13);
			ClientSize = new System.Drawing.Size(944, 668);
			Controls.Add(sbStatus);
			Controls.Add(tabControl1);
			Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			MaximizeBox = false;
			Name = "UtilsForm";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Utils";
			tabControl1.ResumeLayout(false);
			tpReports.ResumeLayout(false);
			tpReports.PerformLayout();
			tabPage1.ResumeLayout(false);
			tabPage1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(pbShapesItemPicture)).EndInit();
			tabPage6.ResumeLayout(false);
			panel1.ResumeLayout(false);
			tabPage7.ResumeLayout(false);
			groupBox9.ResumeLayout(false);
			gbFixed.ResumeLayout(false);
			gbFixed.PerformLayout();
			tabPage5.ResumeLayout(false);
			groupBox8.ResumeLayout(false);
			groupBox8.PerformLayout();
			groupBox7.ResumeLayout(false);
			tabPage3.ResumeLayout(false);
			gbDetails.ResumeLayout(false);
			gbDetails.PerformLayout();
			groupBox5.ResumeLayout(false);
			groupBox5.PerformLayout();
			groupBox4.ResumeLayout(false);
			groupBox4.PerformLayout();
			tabPage2.ResumeLayout(false);
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			tabPage4.ResumeLayout(false);
			groupBox6.ResumeLayout(false);
			groupBox6.PerformLayout();
			tbNewStructure.ResumeLayout(false);
			tbNewStructure.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(pbStructureItemPicture)).EndInit();
			((System.ComponentModel.ISupportInitialize)(pbStructureItemTypeGroup)).EndInit();
			((System.ComponentModel.ISupportInitialize)(pbStructureItemType)).EndInit();
			tabPage8.ResumeLayout(false);
			tabPage8.PerformLayout();
			ResumeLayout(false);

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

        private void InitPrimaryData()
        {
            Cursor = Cursors.WaitCursor;
            //InitShapes();
            //InitUsers();
            //InitColors();
            Cursor = Cursors.Default;
        }

        #region Shapes

        private void InitShapes()
        {
            DisEnableRight(false);
            dtShapesTree = Service.GetShapesTree().Tables["Shapes"];
            dtShapesInfo = Service.GetShapesInfo().Tables["ShapesInfo"];
            ptShapes.Initialize(dtShapesTree);
            DataSet dsPrices = Service.GetPriceGroups();
            cbShapesPriceGroup.DataSource = dsPrices.Tables[0];
            cbShapesPriceGroup.DisplayMember = "PriceGroupName";
            cbShapesPriceGroup.ValueMember = "PriceGroupID";
        }

        private void bShapesPicturePath_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog ofdShapesPicturePath = new OpenFileDialog();
            ofdShapesPicturePath.Multiselect = false;
            ofdShapesPicturePath.Filter = "Image files (*.bmp;*.gif;*.jpg;*.png)|*.bmp;*.gif;*.jpg;*.png|All files (*.*)|*.*";

            ofdShapesPicturePath.AddExtension = true;
            if (ofdShapesPicturePath.ShowDialog() == DialogResult.OK)
            {
                tbShapesPicturePath.Text = ofdShapesPicturePath.FileName;
                tbShapesPicturePath.SelectionStart = tbShapesPicturePath.Text.Length - 1;
                tbShapesPicturePath.SelectionLength = 0;
                pbShapesItemPicture.Image = Image.FromFile(tbShapesPicturePath.Text, true);
            }
        }

        private void bShapes_Click(object sender, System.EventArgs e)
        {
            ClearRight();
            tbShapesFullName.Focus();
            DisEnableRight(true);
            drInfo = null;
        }

        private void DisEnableRight(bool enable)
        {
            tbShapesFullName.Enabled = enable;
            tbShapesLongReportName.Enabled = enable;
            tbShapesPicturePath.Enabled = enable;
            tbShapesSarinGroup.Enabled = enable;
            tbShapesShortReportName.Enabled = enable;
            cbShapesPriceGroup.Enabled = enable;
        }

        private void ClearRight()
        {
            tbShapesFullName.Clear();
            tbShapesLongReportName.Clear();
            tbShapesPicturePath.Clear();
            tbShapesSarinGroup.Clear();
            tbShapesShortReportName.Clear();
            pbShapesItemPicture.Image = null;
        }

        private void bShapesUpdate_Click(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Updating...";
            Cursor = Cursors.WaitCursor;
            if (tbShapesFullName.Text != "" && tbShapesLongReportName.Text != "" && tbShapesPicturePath.Text != "" &&
                tbShapesSarinGroup.Text != "" && tbShapesShortReportName.Text != "" &&
                cbShapesPriceGroup.SelectedIndex != -1)
            {
                drInfo["FullName"] = tbShapesFullName.Text;
                drInfo["LongReportName"] = tbShapesLongReportName.Text;
                drInfo["PicturePath"] = tbShapesPicturePath.Text;
                drInfo["SarinGroup"] = tbShapesSarinGroup.Text;
                drInfo["ShortReportName"] = tbShapesShortReportName.Text;
                drInfo["PriceGroup"] = Convert.ToInt32(cbShapesPriceGroup.SelectedValue);
            }
            else
                MessageBox.Show("Fields are not filled correctly", "All the fields must be filled", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            sbStatus.Text = "Ready";
            Cursor = Cursors.Default;
        }

        private void ptShapes_Changed(object sender, System.EventArgs e)
        {
            drInfo = dtShapesInfo.Select("ShapeID='" + ptShapes.SelectedRow["ID"].ToString() + "'")[0];
            tbShapesFullName.Text = drInfo["FullName"].ToString();
            tbShapesLongReportName.Text = drInfo["LongReportName"].ToString();
            tbShapesPicturePath.Text = drInfo["PicturePath"].ToString();
            tbShapesSarinGroup.Text = drInfo["SarinGroup"].ToString();
            tbShapesShortReportName.Text = drInfo["ShortReportName"].ToString();
            cbShapesPriceGroup.SelectedValue = Convert.ToInt32(drInfo["PriceGroup"]);
            if (System.IO.File.Exists(drInfo["PicturePath"].ToString()))
                pbShapesItemPicture.Image = Image.FromFile(drInfo["PicturePath"].ToString(), true);

        }

        #region StatusBar

        private void ptShapes_Enter(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Choose shape to view details";
        }

        private void tbShapesFullName_Enter(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Full Name";
        }

        private void tbShapesLongReportName_Enter(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Long Report Name";
        }

        private void tbShapesShortReportName_Enter(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Short Report Name";
        }

        private void cbShapesPriceGroup_Enter(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Price Group Name";
        }

        private void tbShapesSarinGroup_Enter(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Sarin Group";
        }

        private void tbShapesPicturePath_Enter(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Picture File Path";
        }
        #endregion StatusBar

        private void bShapesPrintSelected_Click(object sender, System.EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            sbStatus.Text = "Printing...";
            Cursor = Cursors.Default;
        }

        #endregion Shapes


        #region Users
        private void InitUsers()
        {
            dtUsers = Service.GetUsers().Tables["Users"];
            foreach (DataRow drUser in dtUsers.Rows)
            {
                ListViewItem lviUser = new ListViewItem(drUser["FirstName"].ToString());
                lviUser.SubItems.Add(drUser["LastName"].ToString());
                lviUser.SubItems.Add(drUser["Login"].ToString());
                lviUser.SubItems.Add(drUser["Department"].ToString());
                lviUser.SubItems.Add(drUser["RoleName"].ToString());
                lviUser.SubItems.Add(drUser["Created"].ToString());
                lviUser.SubItems.Add(drUser["FirstLogin"].ToString());
                lviUser.SubItems.Add(drUser["LastLogin"].ToString());
                lviUser.SubItems.Add(drUser["LastOperation"].ToString());
                lvUsers.Items.Add(lviUser);
            }

            DataTable dtRoles = Service.GetRoles().Tables["Roles"];
            cbUsersRole.DataSource = dtRoles;
            cbUsersRole.DisplayMember = "RoleName";
            cbUsersRole.ValueMember = "RoleID";
        }

        private void UsersClearRight()
        {
            tbUsersComments.Clear();
            tbUsersCreated.Clear();
            tbUsersFirstLogin.Clear();
            tbUsersFirstName.Clear();
            tbUsersLastLogin.Clear();
            tbUsersLastName.Clear();
            tbUsersLastOperation.Clear();
            tbUsersLogin.Clear();
            tbUsersPwd.Clear();
            tbUsersRetypePwd.Clear();
            cbUsersDepartment.SelectedIndex = -1;
            cbUsersRole.SelectedIndex = -1;
        }

        private void lvUsers_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            drSelected = dtUsers.Select("FirstName='" + lvUsers.SelectedItems[0].Text +
                "'&LastName='" + lvUsers.SelectedItems[0].SubItems[0].Text + "'")[0];

            tbUsersComments.Text = drSelected["Comments"].ToString();
            tbUsersCreated.Text = drSelected["Created"].ToString();
            tbUsersFirstLogin.Text = drSelected["FirstLogin"].ToString();
            tbUsersFirstName.Text = drSelected["FirstName"].ToString();
            tbUsersLastLogin.Text = drSelected["LastLogin"].ToString();
            tbUsersLastName.Text = drSelected["LastName"].ToString();
            tbUsersLastOperation.Text = drSelected["LastOperation"].ToString();
            tbUsersLogin.Text = drSelected["Login"].ToString();
            tbUsersPwd.Text = drSelected["Pwd"].ToString();
            tbUsersRetypePwd.Text = drSelected["Pwd"].ToString();
            cbUsersDepartment.SelectedValue = Convert.ToInt32(drSelected["Department"]);
            cbUsersRole.SelectedValue = Convert.ToInt32(drSelected["RoleID"]);
        }

        private void bUsersClearChanges_Click(object sender, System.EventArgs e)
        {
            UsersClearRight();
        }

        private void bUsersNewUser_Click(object sender, System.EventArgs e)
        {
            UsersClearRight();
            tbUsersFirstName.Focus();
        }

        private void bUsersClearPwd_Click(object sender, System.EventArgs e)
        {
            tbUsersPwd.Clear();
            tbUsersRetypePwd.Clear();
        }
        private void bUsersSearchUser_Click(object sender, System.EventArgs e)
        {
            DataRow[] drFound;

            System.Text.StringBuilder sbFilter = new System.Text.StringBuilder();
            if (tbUsersFirstName.Text != "")
                sbFilter.Append("FirstName='" + tbUsersFirstName.Text + "'");
            if (tbUsersLastName.Text != "")
                sbFilter.Append("&LastName='" + tbUsersLastName.Text + "'");
            if (tbUsersLogin.Text != "")
                sbFilter.Append("&Login='" + tbUsersLogin.Text + "'");
            if (cbUsersDepartment.SelectedText != "")
                sbFilter.Append("&Department='" + cbUsersDepartment.SelectedText + "'");
            if (cbUsersRole.SelectedText != "")
                sbFilter.Append("&Login='" + cbUsersRole.SelectedText + "'");
            if (tbUsersPwd.SelectedText != "")
                sbFilter.Append("&Pwd='" + tbUsersPwd.Text + "'");

            if (sbFilter.Length == 0)
                sbStatus.Text = "At least one search field must be filled";
            else
            {
                drFound = dtUsers.Select(sbFilter.ToString());

                tbUsersComments.Text = drFound[0]["Comments"].ToString();
                tbUsersCreated.Text = drFound[0]["Created"].ToString();
                tbUsersFirstLogin.Text = drFound[0]["FirstLogin"].ToString();
                tbUsersFirstName.Text = drFound[0]["FirstName"].ToString();
                tbUsersLastLogin.Text = drFound[0]["LastLogin"].ToString();
                tbUsersLastName.Text = drFound[0]["LastName"].ToString();
                tbUsersLastOperation.Text = drFound[0]["LastOperation"].ToString();
                tbUsersLogin.Text = drFound[0]["Login"].ToString();
                tbUsersPwd.Text = drFound[0]["Pwd"].ToString();
                tbUsersRetypePwd.Text = drFound[0]["Pwd"].ToString();
                cbUsersDepartment.SelectedValue = Convert.ToInt32(drFound[0]["Department"]);
                cbUsersRole.SelectedValue = Convert.ToInt32(drFound[0]["RoleID"]);
            }
        }

        private void bUsersDelete_Click(object sender, System.EventArgs e)
        {
            /*
            if(lvUsers.SelectedIndices[0] != -1)
                if(MessageBox.Show("Are you sure you want to delete this user's information?",
                    "Delete user", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) ==
                    DialogResult.Yes)
                {
                    lvUsers.Items.RemoveAt(lvUsers.SelectedIndices[0]);

                    DataSet dsUserTypeEx = Service.GetUserTypeEx();
                    dsUserTypeEx.Tables[0].TableName = "UserType";

                    DataRow drTypeEx = dsUserTypeEx.Tables[0].NewRow();
                    drTypeEx["ID"] = drSelected["ID"];
                    dsUserTypeEx.Tables[0].Rows.Add(drTypeEx);
							
                    Service.UserExpire(dsUserTypeEx.Tables[0]);
                }
            UsersClearRight();
            */
        }
        #endregion Users


        #region Colors
        private void InitColors()
        {
            dtMeasures = Service.GetMeasures().Tables["Measures"];
            lbxColorsMeasures.DataSource = dtMeasures;
            lbxColorsMeasures.DisplayMember = "Name";
            lbxColorsMeasures.ValueMember = "ID";
        }
        #endregion Colors

        private void lbxColorsMeasures_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            DataRow drMeasure = dtMeasures.Select("ID='" + lbxColorsMeasures.SelectedValue.ToString() + "'")[0];

        }

        private void bUsersSave_Click(object sender, System.EventArgs e)
        {

        }

        private void bUsersSavePwd_Click(object sender, System.EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, System.EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, System.EventArgs e)
        {

        }

        private void tabPage5_Click(object sender, System.EventArgs e)
        {

        }

        /*
        private string GetBatchByCode(string sGroupCode, string sBatchCode)
        {
            DataSet dsIn = new DataSet();
            dsIn.Tables.Add("BatchByCodeTypeEx");
            dsIn = gemoDream.Service.ProxyGenericGet(dsIn);
            dsIn.Tables[0].TableName = "BatchByCode";
            dsIn.Tables[0].Rows.Add(dsIn.Tables[0].NewRow());
            dsIn.Tables[0].Rows[0]["GroupCode"] = sGroupCode;
            dsIn.Tables[0].Rows[0]["BatchCode"] = sBatchCode;
            DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);
            string sBatchID = null;
            if (dsOut.Tables.Count > 0 && dsOut.Tables[0].Rows.Count > 0)
                sBatchID = dsOut.Tables[0].Rows[0]["BatchID"].ToString();
            return sBatchID;
        }

        private string GetGroupIDByCode(string sGroupCode)
        {
            DataSet dsIn = new DataSet();
            dsIn.Tables.Add("GroupByCodeTypeEx");
            dsIn = gemoDream.Service.ProxyGenericGet(dsIn);
            dsIn.Tables[0].TableName = "GroupByCode";
            dsIn.Tables[0].Rows.Add(dsIn.Tables[0].NewRow());
            dsIn.Tables[0].Rows[0]["GroupCode"] = sGroupCode;
            DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);
            string sGroupID = null;
            if (dsOut.Tables.Count > 0 && dsOut.Tables[0].Rows.Count > 0)
                sGroupID = dsOut.Tables[0].Rows[0]["GroupID"].ToString();
            return sGroupID;
        }

        private string GetItemsNum(string sGroupCode)
        {
            DataSet dsIn = new DataSet();
            dsIn.Tables.Add("GroupByCodeTypeEx");
            dsIn = gemoDream.Service.ProxyGenericGet(dsIn);
            dsIn.Tables[0].TableName = "GroupByCode";
            dsIn.Tables[0].Rows.Add(dsIn.Tables[0].NewRow());
            dsIn.Tables[0].Rows[0]["GroupCode"] = sGroupCode;
            DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);
            string sItemsQuantity = null;
            if (dsOut.Tables.Count > 0 && dsOut.Tables[0].Rows.Count > 0)
                sItemsQuantity = dsOut.Tables[0].Rows[0]["ItemsQuantity"].ToString();
            return sItemsQuantity;
        }

        private string GetShapeCodeByItemCode(string sGroupCode, string sBatchCode,
            string sItemCode)
        {
            DataSet dsIn = new DataSet();
            dsIn.Tables.Add("ShapeCodeByItemCode");
            dsIn.Tables[0].Columns.Add("GroupCode", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("BatchCode", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("ItemCode", System.Type.GetType("System.String"));
            dsIn.Tables[0].Rows.Add(dsIn.Tables[0].NewRow());
            dsIn.Tables[0].Rows[0]["GroupCode"] = sGroupCode;
            dsIn.Tables[0].Rows[0]["BatchCode"] = sBatchCode;
            dsIn.Tables[0].Rows[0]["ItemCode"] = sItemCode;
            DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);
            string sShapeCode = null;
            if (dsOut.Tables.Count != 0)
                sShapeCode = dsOut.Tables[0].Rows[0]["ValueCode"].ToString();
            return sShapeCode;
        }
        */

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
                        return FilterState.NotValid; ;
                    }
                    return FilterState.Valid; ;
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

        private void button1_Click(object sender, System.EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                sbStatus.Text = "Printing...";

                string sCRTemplatePath = Client.GetOfficeDirPath("repDir");
                string sReportKind = Service.GetReportKind();
                CrystalReport.CrystalReport crReport = null;
                if (sReportKind == "crystal")
                {
                    crReport = new CrystalReport.CrystalReport(sCRTemplatePath);
                }
                else
                {
                    crReport = new CrystalReport.CrystalReport(sCRTemplatePath, true);
                }
                switch ((Reports)lvReports.SelectedItems[0].Index)
                {
                    case Reports.FRONT_LABEL:
                        {
                            if (CheckFrontLabel())
                            {
                                string[] sGroupID = Service.GetGroupIDByCode1(tbReportsGroupCode.Text.ToString()).Split('_');
                                if (sGroupID[1] == null)
                                {
                                    MessageBox.Show(this, "Can't find group id. Please check your input.",
                                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                else
                                {
                                    //tbReportsGroupCode.Text = sGroupID[1];
                                    tbReportsGroupOfficeID.Text = sGroupID[0];

                                }
                                string sGroupOfficeID_GroupID = sGroupID[0] + "_" + sGroupID[1];
                                //sGroupID;
                                if (sReportKind == "crystal")
                                {
                                    crReport.Front_TakeIn_Label(sGroupOfficeID_GroupID);
                                    crReport.Print();
                                }
                                else
                                {
                                    try
                                    {
                                        crReport.Excel_Front_TakeIn_Label(sGroupOfficeID_GroupID);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(this, ex.Message, "Print error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }

                                    /*
                                    crReport = null;
                                    GC.Collect();
                                    GC.WaitForPendingFinalizers(); 
                                    GC.Collect();*/
                                }


                            }
                            break;
                        }
                    case Reports.FRONT_EXT_RECEIPT:
                        {
                            if (CheckFrontExtReceipt())
                            {
                                string[] sGroupID = Service.GetGroupIDByCode1(tbReportsGroupCode.Text.ToString()).Split('_');
                                if (sGroupID[1] == null)
                                {
                                    MessageBox.Show(this, "Can't find group id. Please check your input.",
                                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                else
                                {
                                    //tbReportsGroupCode.Text = sGroupID[1];
                                    tbReportsGroupOfficeID.Text = sGroupID[0];

                                }
                                string sGroupOfficeID_GroupID = sGroupID[0] + "_" + sGroupID[1];

                                CrystalReport.TakeInType type;
                                type = CrystalReport.TakeInType.TakeIn;
                                if (sReportKind == "crystal")
                                {
                                    crReport.Front_TakeIn(sGroupOfficeID_GroupID, type);
                                    crReport.Print();
                                }
                                else
                                {
                                    try
                                    {
                                        crReport.Excel_Front_TakeIn(sGroupOfficeID_GroupID, type, 1);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(this, ex.Message, "Print error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    /*
                                    crReport = null;
                                    GC.Collect();
                                    GC.WaitForPendingFinalizers(); 
                                    GC.Collect();*/
                                }


                            }
                            break;
                        }
                    case Reports.FRONT_ITEMS_SELECTED:
                        {
                            if (CheckFrontItemsSelected())
                            {
                                string sItemsNum = Service.GetItemsNum(tbReportsGroupCode.Text.ToString());
                                if (sItemsNum == null)
                                {
                                    MessageBox.Show(this, "Can't find items number. Please check your input.",
                                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                if (sReportKind == "crystal")
                                {
                                    crReport.Items_Selected(sItemsNum);
                                    crReport.Print();
                                }
                                else
                                {
                                    try
                                    {
                                        crReport.Excel_Items_Selected(sItemsNum);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(this, ex.Message, "Print error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    /*
                                    crReport = null;
                                    GC.Collect();
                                    GC.WaitForPendingFinalizers(); 
                                    GC.Collect();*/
                                }


                            }
                            break;
                        }
                    case Reports.ITEMIZING_BATCH_LABEL:
                        {
                            if (CheckItemizingBatchLabel())
                            {
                                string sBatchID = Service.GetBatchByCode(tbReportsGroupCode.Text,
                                    tbReportsBatchCode.Text);
                                if (sBatchID == null)
                                {
                                    MessageBox.Show(this, "Can't find batch id. Please check your input.",
                                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                if (sReportKind == "crystal")
                                {
                                    crReport.Label_Batch(sBatchID);
                                    crReport.Print();
                                }
                                else
                                {

                                    try
                                    {
                                        crReport.Excel_Label_Batch(sBatchID);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(this, ex.Message, "Print error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    /*
                                    crReport = null;
                                    GC.Collect();
                                    GC.WaitForPendingFinalizers(); 
                                    GC.Collect();*/
                                }


                            }
                            break;
                        }
                    case Reports.ITEMIZING_ITEM_LABEL:
                        {
                            if (CheckItemizingItemLabel())
                            {
                                string sItemCode = null;
                                if (tbReportsItemCode.Text.Trim() == "##")
                                {
                                    tbReportsItemCode.Text = "0";
                                    sItemCode = "01";
                                }
                                //                            string sItemCode = (tbReportsItemCode.Text.Trim() == "##" ? "01" : tbReportsItemCode.Text.Trim());

                                DataTable dataTable = Service.GetItemByCode(tbReportsGroupCode.Text.Trim(),
                                                                            tbReportsBatchCode.Text.Trim(),
                                                                            sItemCode);
                                if (dataTable.Rows.Count == 0)
                                {
                                    MessageBox.Show(this, "Can't find batch id and item code. Please check data.",
                                                            "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                //string sBatchID_ItemCode = dataTable.Rows[0]["BatchID_ItemCode"].ToString();
                                string sBatchID = dataTable.Rows[0]["BatchID"].ToString();
                                string sBatchID_ItemCode = sBatchID + "_" + tbReportsItemCode.Text.Trim(); //(tbReportsItemCode.Text == "##" ? "00" : tbReportsItemCode.Text);
                                if (sReportKind == "crystal")
                                {
                                    crReport.Label_Item(sBatchID_ItemCode);
                                    crReport.Print();
                                }
                                else
                                {
                                    try
                                    {
                                        crReport.Excel_Label_Item(sBatchID_ItemCode);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(this, ex.Message, "Print error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    /*
                                    crReport = null;
                                    GC.Collect();
                                    GC.WaitForPendingFinalizers(); 
                                    GC.Collect();*/
                                }


                            }
                            break;
                        }
                    case Reports.ITEMIZING_INTERNAL_RECEIPT:
                        {
                            if (CheckItemizingInternalReceipt())
                            {
                                string sBatchID = Service.GetBatchByCode(tbReportsGroupCode.Text,
                                    tbReportsBatchCode.Text);
                                if (sBatchID == null)
                                {
                                    MessageBox.Show(this, "Can't find batch id. Please check your input.",
                                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                crReport.Internal_Receipt(sBatchID);
                                crReport.Print();
                            }
                            break;
                        }
                    case Reports.CP_CP:
                        {
                            if (CheckCP_CP())
                            {
                                string sGroupCode = tbReportsGroupCode.Text.ToString();
                                string sBatchCode = tbReportsBatchCode.Text.ToString();
                                string sItemCode = (tbReportsItemCode.Text.ToString().Trim() == "##" ? "01" : tbReportsItemCode.Text.Trim());
                                string sShapeCode = Service.GetShapeCodeByItemCode(sGroupCode, sBatchCode, sItemCode);
                                if (sShapeCode.Length == 0)
                                {
                                    MessageBox.Show(this, "Can't find shape code. Please, check group, batch and item codes.",
                                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                CrystalReport.CrystalReport crReport1 = new CrystalReport.CrystalReport(sCRTemplatePath);
                                crReport1.Customer_Program(sBatchCode, sItemCode, sShapeCode, sGroupCode);
                                crReport1.Print();
                            }
                            break;
                        }
                    case Reports.ITEMIZING_SARIN_LABELS:
                        {
                            if (CheckItemizingItemLabel())
                            {
                                DataTable dataTable = Service.GetItemByCode(tbReportsGroupCode.Text,
                                    tbReportsBatchCode.Text, (tbReportsItemCode.Text.Trim() == "##" ? "01" : tbReportsItemCode.Text.Trim()));
                                if (dataTable.Rows.Count == 0)
                                {
                                    MessageBox.Show(this, "Can't find batch id and item code. Please check your input.",
                                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                //string sBatchID_ItemCode = dataTable.Rows[0]["BatchID_ItemCode"].ToString();
                                string sBatchID = dataTable.Rows[0]["BatchID"].ToString();
                                string sBatchID_ItemCode = sBatchID + "_" + (tbReportsItemCode.Text == "##" ? "00" : tbReportsItemCode.Text);
                                try
                                {
                                    crReport.Excel_Sarin_Label_Item(sBatchID_ItemCode);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(this, ex.Message, "Print error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            break;
                        }
                }

                //				if(crReport != null)				
                //				crReport.CloseExcel();
                //				crReport = null;
                //				GC.Collect();
                //				GC.WaitForPendingFinalizers(); 
                //				GC.Collect();

                Cursor = Cursors.Default;
                sbStatus.Text = "Printing complete";
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Can't print report. Reason: " + ex.ToString(),
                    "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor = Cursors.Default;
                sbStatus.Text = "Printing failed";
            }
        }


        private void SelectFrontLabel()
        {
            tbReportsGroupOfficeID.Enabled = true;
            tbReportsGroupCode.Enabled = true;
            tbReportsBatchCode.Enabled = false;
            tbReportsItemCode.Enabled = false;
        }

        private bool CheckFrontLabel()
        {
            //			if (this.tbReportsGroupOfficeID.Text.ToString().Length == 0 ||
            //				this.tbReportsGroupOfficeID.Text.ToString().Equals("###"))
            //			{
            //				MessageBox.Show(this, "Please enter a group office id.",
            //					"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //				return false;
            //			}

            FilterState fs = CheckGroupCode(tbReportsGroupCode);
            if (fs != FilterState.Valid)
            {
                if (fs == FilterState.NotEntered)
                    MessageBox.Show(this, "Please enter a group code", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void SelectFrontExtReceipt()
        {
            tbReportsGroupOfficeID.Enabled = true;
            tbReportsGroupCode.Enabled = true;
            tbReportsBatchCode.Enabled = false;
            tbReportsItemCode.Enabled = false;
        }

        private bool CheckFrontExtReceipt()
        {
            return CheckFrontLabel();
        }

        private void SelectFrontItemsSelected()
        {
            tbReportsGroupOfficeID.Enabled = false;
            tbReportsGroupCode.Enabled = true;
            tbReportsBatchCode.Enabled = false;
            tbReportsItemCode.Enabled = false;
        }

        private bool CheckFrontItemsSelected()
        {
            FilterState fs = CheckGroupCode(tbReportsGroupCode);
            if (fs != FilterState.Valid)
            {
                if (fs == FilterState.NotEntered)
                    MessageBox.Show(this, "Please enter a group code", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void SelectItemizingBatchLabel()
        {
            tbReportsGroupOfficeID.Enabled = false;
            tbReportsGroupCode.Enabled = true;
            tbReportsBatchCode.Enabled = true;
            tbReportsItemCode.Enabled = false;
        }

        private bool CheckItemizingBatchLabel()
        {
            FilterState fs = CheckGroupCode(tbReportsGroupCode);
            if (fs != FilterState.Valid)
            {
                if (fs == FilterState.NotEntered)
                    MessageBox.Show(this, "Please enter a group code", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            fs = CheckBatchCode(tbReportsBatchCode);
            if (fs != FilterState.Valid)
            {
                if (fs == FilterState.NotEntered)
                    MessageBox.Show(this, "Please enter a batch code", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void SelectItemizingItemLabel()
        {
            tbReportsGroupOfficeID.Enabled = false;
            tbReportsGroupCode.Enabled = true;
            tbReportsBatchCode.Enabled = true;
            tbReportsItemCode.Enabled = true;

        }

        private bool CheckItemizingItemLabel()
        {
            FilterState fs = CheckGroupCode(tbReportsGroupCode);
            if (fs != FilterState.Valid)
            {
                if (fs == FilterState.NotEntered)
                    MessageBox.Show(this, "Please enter a GROUP CODE", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            fs = CheckBatchCode(tbReportsBatchCode);
            if (fs != FilterState.Valid)
            {
                if (fs == FilterState.NotEntered)
                    MessageBox.Show(this, "Please enter a BATCH CODE", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            fs = CheckItemCode(tbReportsItemCode);
            if (fs != FilterState.Valid)
            {
                if (fs == FilterState.NotEntered)
                {
                    string message = "You did not enter an Item Code. Print for whole batch?";
                    string caption = "No Item Code Specified";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show(this, message, caption, buttons,
                                            MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                                            MessageBoxOptions.RightAlign);

                    if (result == DialogResult.Yes)
                    {
                        return true;
                    }

                    if (result == DialogResult.No)
                        //					MessageBox.Show(this, "Please enter an Item code", "Warning",
                        //						MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        return false;
                }

            }

            return true;
        }

        private void SelectItemizingInternalReceipt()
        {
            tbReportsGroupOfficeID.Enabled = false;
            tbReportsGroupCode.Enabled = true;
            tbReportsBatchCode.Enabled = true;
            tbReportsItemCode.Enabled = false;

        }

        private bool CheckItemizingInternalReceipt()
        {
            return CheckItemizingBatchLabel();
        }

        private void SelectCP_CP()
        {
            tbReportsGroupOfficeID.Enabled = false;
            tbReportsGroupCode.Enabled = true;
            tbReportsBatchCode.Enabled = true;
            tbReportsItemCode.Enabled = true;
        }

        private bool CheckCP_CP()
        {
            return CheckItemizingItemLabel();
        }

        private void lvReports_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (lvReports.SelectedItems.Count > 0)
            {
                btnReportsPrint.Enabled = true;
                switch ((Reports)lvReports.SelectedItems[0].Index)
                {
                    case Reports.FRONT_LABEL:
                        {
                            SelectFrontLabel();
                            break;
                        }
                    case Reports.FRONT_EXT_RECEIPT:
                        {
                            SelectFrontExtReceipt();
                            break;
                        }
                    case Reports.FRONT_ITEMS_SELECTED:
                        {
                            SelectFrontItemsSelected();
                            break;
                        }
                    case Reports.ITEMIZING_BATCH_LABEL:
                        {
                            SelectItemizingBatchLabel();
                            break;
                        }
                    case Reports.ITEMIZING_ITEM_LABEL:
                        {
                            SelectItemizingItemLabel();
                            break;
                        }
                    case Reports.ITEMIZING_INTERNAL_RECEIPT:
                        {
                            SelectItemizingInternalReceipt();
                            break;
                        }
                    case Reports.CP_CP:
                        {
                            SelectCP_CP();
                            break;
                        }
                    case Reports.ITEMIZING_SARIN_LABELS:
                        {
                            SelectItemizingItemLabel();
                            break;
                        }
                }
            }
        }

        private void tbReportsGroupCode_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar != 8)
            {
                string str = tbReportsGroupCode.Text.ToString();
                if (str.Equals("#####"))
                {
                    str = "";
                    tbReportsGroupCode.Text = str;
                }

                str += e.KeyChar.ToString();

                string pattern = "[0-9]{1,6}";
                Regex rex = new Regex(pattern);

                Match m = rex.Match(str);
                if (m.Length != str.Length)
                    e.Handled = true;
            }
        }

        private void tbReportsBatchCode_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar != 8)
            {
                string str = tbReportsBatchCode.Text.ToString();
                if (str.Equals("###"))
                {
                    str = "";
                    tbReportsBatchCode.Text = str;
                }

                str += e.KeyChar.ToString();

                string pattern = "[0-9]{1,3}";
                Regex rex = new Regex(pattern);

                Match m = rex.Match(str);
                if (m.Length != str.Length)
                    e.Handled = true;
            }
        }

        private void tbReportsItemCode_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar != 8)
            {
                string str = tbReportsItemCode.Text.ToString();
                if (str.Equals("##"))
                {
                    str = "";
                    tbReportsItemCode.Text = str;
                }

                str += e.KeyChar.ToString();

                string pattern = "[0-9]{1,2}";
                Regex rex = new Regex(pattern);

                Match m = rex.Match(str);
                if (m.Length != str.Length)
                    e.Handled = true;
            }
        }

        private void tbReportsGroupOfficeID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar != 8)
            {
                string str = tbReportsGroupOfficeID.Text.ToString();
                if (str.Equals("###"))
                {
                    str = "";
                    tbReportsGroupOfficeID.Text = str;
                }

                str += e.KeyChar.ToString();

                string pattern = "[0-9]{1,3}";
                Regex rex = new Regex(pattern);

                Match m = rex.Match(str);
                if (m.Length != str.Length)
                    e.Handled = true;
            }
        }

        private void tpReports_Enter(object sender, System.EventArgs e)
        {
            if (lvReports.SelectedItems.Count > 0)
            {
                /*
                this.tbReportsGroupOfficeID.Enabled = true;
                this.tbReportsGroupCode.Enabled = true;
                this.tbReportsBatchCode.Enabled = true;
                this.tbReportsItemCode.Enabled = true;
                */
                btnReportsPrint.Enabled = true;
            }
        }

        private void InitStructure()
        {
            ipStructureStructures.Initialize();
            DataTable dt = Service.GetItemizn1_ItemsLibrary();
            ipStructureStructures.InitializeLibrary(dt);

            //			ipStructureStructures.InitializePicture(null);

            //			string sTypeID;
            //for= dt.Rows[0]["Id"].ToString();
            /*
            foreach (DataRow row in dt.Rows)
            {
                sTypeID = row["Id"].ToString();
                DataTable dtItems = Service.GetItemizn1_ItemsSubtypesList(sTypeID);

                //DataSet ds = new DataSet();
                //ds.Tables.Add(dtItems);
                //gemoDream.Service.debug_DiaspalyDataSet(ds);

                ipStructureStructures.InitializeItems(dtItems);
            }
            */

            //DataTable dtItems = Service.GetItemizn1_ItemsSubtypesList(ipStructureStructures.TypeId);
            //ipStructureStructures.InitializeItems(dtItems);

            LoadPartTypesList();

            LoadMeasure();

            lbStructurePartTypes_SelectedValueChanged(this, null);

            ipStructureStructures_ItemTypeClicked(this, null);

            //this.itemPanel1.Initialize();

        }



        private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //if (
        }

        private void ipStructureStructures_NewItemTypeSelected(object sender, System.EventArgs e)
        {
            //DataTable table = Service.GetItemizn1_ItemsSubtypesList(ipStructureStructures.TypeId);
            //ipStructureStructures.InitializeItems(table);
        }

        /*
        private DataSet GetPartTypes()
        {
            try
            {
                DataSet dsIn = new DataSet();
                DataTable dtIn = dsIn.Tables.Add("PartTypes");
                //DataRow row = dtIn.NewRow();
                //dtIn.Rows.Add(row);
                DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);
                return dsOut;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Can't load part types. Reason: " + ex.ToString(),
                    "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        */

        private void LoadPartTypesList()
        {
            DataSet dsPartTypes = Service.GetPartTypes();
            /*DataView*/
            dvPartTypes = new DataView(dsPartTypes.Tables[0]);
            dvPartTypes.Sort = "PartTypeName";

            string sFilter = "PartTypeID = 15";
            string sSort = "";
            dvItemContainer = new DataView(dsPartTypes.Tables[0], sFilter, sSort, DataViewRowState.CurrentRows);

            lbStructurePartTypes.DataSource = dvItemContainer;
            lbStructurePartTypes.DisplayMember = "PartTypeName";
            lbStructurePartTypes.ValueMember = "PartTypeID";

            lbStructurePartTypes.SelectedValueChanged += new System.EventHandler(lbStructurePartTypes_SelectedValueChanged);
        }

        private void ipStructureStructures_Changed(object sender, System.EventArgs e)
        {
            //MessageBox.Show(this, this.ipStructureStructures.ItemId.ToString(),
            //	"!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //			dsParts = new DataSet();	
            //			dsParts.Tables.Add(Service.GetMeasuresByItemType(sItemTypeID));	//tblName : Measures
            //			dsParts.Tables.Add(Service.GetParts(sItemTypeID));	//tblName : Parts
            //			dsParts.Tables.Add(Service.GetPartsStruct());	//tblName : SetParts				
            //		}
            //		catch(Exception exc)
            //		{
            //			sbStatus.Text = "Unable to get parts info from server";
            //		}
        }

        private void btnStructureNewItem_Click(object sender, System.EventArgs e)
        {
            NewItemForm newItemForm = new NewItemForm();
            DialogResult dr = newItemForm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                //ipStructureStructures.NewGroup(string sTypeName, );
                IsSaveCopy = false;
            }
        }

        private void btnStructureNewGroup_Click(object sender, System.EventArgs e)
        {
            string sGroupName = tbStructureGroupName.Text;
            string sPath2Icon = tbStructureItemTypeGroupIconPath.Text;

            if (sGroupName == null || sGroupName.Length == 0)
            {
                MessageBox.Show(this, "New group name is empty. Please, enter the group name.",
                    "Empty group name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (sPath2Icon == null || sPath2Icon.Length == 0)
            {
                MessageBox.Show(this, "New group icon is empty. Please, enter the group icon.",
                    "Empty group icon", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Service.IsItemTypeGroupNameExists(sGroupName))
            {
                MessageBox.Show(this, "Item type group with this name already exists. Please, type another name.",
                    "Group exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbStructureIsItemTypeGroupChild.Checked)
                Service.AddItemTypeGroup(sGroupName, sPath2Icon, ipStructureStructures.TypeId);
            else
                Service.AddItemTypeGroup(sGroupName, sPath2Icon, null);

            ipStructureStructures.NewGroup(sGroupName, sPath2Icon);
            IsReinit = true;
            ipStructureStructures.Initialize();
            DataTable dt = Service.GetItemizn1_ItemsLibrary();
            ipStructureStructures.InitializeLibrary(dt);
            IsReinit = false;
        }

        private void btnStructuresDeleteGroup_Click(object sender, System.EventArgs e)
        {
            string sMessage = "Do you want to delete selected item type group?";
            DialogResult dialogResult = MessageBox.Show(this, sMessage, "Confirm deleting",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.Yes)
            {
                sMessage = "All child Groups and Item Types will be deleted too.\n Do you want to delete selected item type group?";
                dialogResult = MessageBox.Show(this, sMessage, "Confirm deleting",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (dialogResult == DialogResult.Yes)
                {

                    string sTypeId = ipStructureStructures.TypeId;
                    //ipStructureStructures.Enabled = false;

                    ipStructureStructures.DeleteSelectedGroup();

                    //ipStructureStructures.Enabled = true;
                    IsReinit = true;
                    ipStructureStructures.Initialize();
                    DataTable dt = Service.GetItemizn1_ItemsLibrary();
                    ipStructureStructures.InitializeLibrary(dt);
                    IsReinit = false;
                }
            }

        }

        private void lbStructurePartTypes_SelectedValueChanged(object sender, System.EventArgs e)
        {
            string sPartTypeID = lbStructurePartTypes.SelectedValue.ToString();

            DataRow[] drEmptySet = dsItemProperties.Tables["Measures"].Select("PartTypeID = '" + sPartTypeID + "'", "MeasureTitle");

            FillMeasures(drEmptySet);
        }

        private void LoadMeasure()
        {
            dsItemProperties = Service.GetMeasures();
            //string sItemTypeID = lbStructurePartTypes.SelectedValue.ToString();
            //DataTable dtMeasureType = 
            //Service.GetMeasures();
            //	Service.GetMeasuresByItemType(sItemTypeID);//tblName : MeasuresByItemType / 1 - empty
            //dtMeasureType.TableName = "Measures";	
            //dsItemProperties.Tables.Clear();
            //dsItemProperties.Tables.Add(dtMeasureType);		//tblName : Measures
        }

        private void FillMeasures(DataRow[] drSet)
        {
            lbStructureMeasures.Items.Clear();
            foreach (DataRow row in drSet)
            {
                lbStructureMeasures.Items.Add(row["MeasureTitle"].ToString());
            }
        }

        private void tbStructurePicPath_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Image im = Service.GetImageFromSrv(tbStructureItemTypePicPath.Text);
                if (im != null)
                    pbStructureItemPicture.Image = im;
                //ipStructureStructures.InitializePicture(im);
                else
                {
                    //ipStructureStructures.InitializePicture(null);
                    pbStructureItemPicture.Image = null;
                    MessageBox.Show("There is no picture in specified location",
                        "Picture not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void BuildItemName()
        {
            sItemName = "";
            TreeNode tn = ptStructureNewItem.tvPartTree.TopNode;
            RecurseBuildItemName(tn);
            string sItemName2 = sItemName.Remove(sItemName.Length - 1, 1);
            tbStructureNewItemName.Text = sItemName2;
        }

        /*
        private string SavePartType(string sItemParentID, string sItemPartName, string sPath2Icon, 
            string sPath2Picture, string sPartTypeID, string sItemContainerName,
            string sItemTypeID)
        {
			
            //	spSetPartType
            //	@ParentPartID dnSmallID, @PartName dsName, @Path2Drawing dsPath, @Path2Picture dsPath, 
            //	@PartLegend dsName,	@ShapeID dnSmallID, @PartTypeID int, @PartID int, 
            //	@AuthorID dnSmallID, @AuthorOfficeID dnTinyID, 
            //	@ExpireDate ddDate, @ItemTypeID dnSmallID)

            DataSet dsIn = new DataSet();
            dsIn.Tables.Add("PartType");
            dsIn.Tables[0].Columns.Add("ParentPartID", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("PartName", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("Path2Drawing", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("Path2Picture", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("PartLegend", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("ItemContainerName", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("ShapeID", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("PartTypeID", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("PartID", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("ExpireDate", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("ItemTypeID", System.Type.GetType("System.String"));
            //dsIn.Tables[0].Columns.Add("CurrentOfficeID", System.Type.GetType("System.String"));

            dsIn.Tables[0].Rows.Add(dsIn.Tables[0].NewRow());
            //dsIn.Tables[0].Rows[0]["ParentPartID"] = sItemParentID.Length == 0 ? DBNull.Value : sItemParentID;
            if (sItemParentID.Length == 0)
                dsIn.Tables[0].Rows[0]["ParentPartID"] = DBNull.Value;
            else
                dsIn.Tables[0].Rows[0]["ParentPartID"] = sItemParentID;
            dsIn.Tables[0].Rows[0]["PartName"] = sItemPartName;
            dsIn.Tables[0].Rows[0]["Path2Drawing"] = sPath2Icon;
            dsIn.Tables[0].Rows[0]["Path2Picture"] = sPath2Picture;
            dsIn.Tables[0].Rows[0]["PartLegend"] = DBNull.Value;
            dsIn.Tables[0].Rows[0]["ShapeID"] = DBNull.Value;
            dsIn.Tables[0].Rows[0]["PartTypeID"] = sPartTypeID;
            dsIn.Tables[0].Rows[0]["ItemContainerName"] = sItemContainerName;
            //DBNull.Value;
            dsIn.Tables[0].Rows[0]["PartID"] = DBNull.Value;
            dsIn.Tables[0].Rows[0]["ExpireDate"] = DBNull.Value;
            dsIn.Tables[0].Rows[0]["ItemTypeID"] = sItemTypeID;
            //dsIn.Tables[0].Rows[0]["CurrentOfficeID"] = sBatchCode;
            DataSet dsOut = gemoDream.Service.ProxyGenericSet(dsIn, "Set");
            string sItemID = dsOut.Tables[0].Rows[0]["ID"].ToString();
            return sItemID;
        }
        */

        private void ParseTag(string sTag,
            out string sPartTypeID, out string sPartID, out string sItemContainerName)
        {
            string[] sItem = sTag.Split('!');

            if (sItem.Length == 3)
            {
                sPartTypeID = sItem[0];
                sPartID = sItem[1];
                sItemContainerName = sItem[2];
            }
            else
            {
                sPartTypeID = "";
                sPartID = "";
                sItemContainerName = "";
            }
        }

        private string BuildTag(string sPartTypeID, string sPartID, string sItemContainerName)
        {
            //string sTag = String.Format("PartTypeID={0} PartID={1} ItemContainerName={2}",
            string sTag = String.Format("{0}!{1}!{2}",
                sPartTypeID, sPartID, sItemContainerName);
            return sTag;
        }

        /*
        private string SaveItemType(string sItemTypeGroupID,
            string sItemTypeName, string sPath2Icon,
            string sPath2Picture, string sDefaultCPID,
            string sDefaultCPOfficeID)
        {
			
            //	spSetItemType
            //	@ItemTypeGroupID dnSmallID, @ItemTypeName dsName, @Path2Icon dsPath, @Path2Picture dsPath, 
            //	@AuthorID dnSmallID, @AuthorOfficeID dnTinyID,
            //	@DefaultCPID dnID, @DefaultCPOfficeID dnTinyID, @ExpireDate ddDate, @CurrentOfficeID dnTinyID
            //	@ItemTypeID dsSmallID
			
            DataSet dsIn = new DataSet();
            dsIn.Tables.Add("ItemType");
            dsIn.Tables[0].Columns.Add("ItemTypeGroupID", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("ItemTypeName", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("Path2Icon", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("Path2Picture", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("DefaultCPID", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("DefaultCPOfficeID", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("ExpireDate", System.Type.GetType("System.String"));
            //dsIn.Tables[0].Columns.Add("CurrentOfficeID", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("ItemTypeID", System.Type.GetType("System.String"));

            dsIn.Tables[0].Rows.Add(dsIn.Tables[0].NewRow());
            //dsIn.Tables[0].Rows[0]["ParentPartID"] = sItemParentID.Length == 0 ? DBNull.Value : sItemParentID;
            dsIn.Tables[0].Rows[0]["ItemTypeGroupID"] = sItemTypeGroupID;
            dsIn.Tables[0].Rows[0]["ItemTypeName"] = sItemTypeName;
            dsIn.Tables[0].Rows[0]["Path2Icon"] = sPath2Icon;
            dsIn.Tables[0].Rows[0]["Path2Picture"] = sPath2Picture;
            dsIn.Tables[0].Rows[0]["DefaultCPID"] = sDefaultCPID;
            dsIn.Tables[0].Rows[0]["DefaultCPOfficeID"] = sDefaultCPOfficeID;
            dsIn.Tables[0].Rows[0]["ExpireDate"] = DBNull.Value;
            dsIn.Tables[0].Rows[0]["ItemTypeID"] = DBNull.Value;
            //dsIn.Tables[0].Rows[0]["CurrentOfficeID"] = sItemContainerName;
            DataSet dsOut = gemoDream.Service.ProxyGenericSet(dsIn, "Set");
            string sItemTypeID = dsOut.Tables[0].Rows[0][0].ToString();
            return sItemTypeID;
        }
        */

        private void SaveStructure()
        {
            string sItemTypeGroupID = ipStructureStructures.TypeId;
            string sItemTypeName = tbStructureNewItemName.Text;
            string sPath2Icon = "d02.ico"; //this.tbStructureItemTypeIconPath.Text;
            //"d02.ico";
            //this.tbStructureItemTypeIconPath.Text.ToString();
            //"";
            string sPath2Picture = "d02.ico"; // this.tbStructureItemTypePicPath.Text;
            //"d02.ico";
            //"";
            string sDefaultCPID = "2";
            string sDefaultCPOfficeID = "1";
            //this.tbSt
            string sItemTypeID = Service.SaveItemType(sItemTypeGroupID, sItemTypeName, sPath2Icon, sPath2Picture,
                sDefaultCPID, sDefaultCPOfficeID);
            foreach (TreeNode tn in ptStructureNewItem.tvPartTree.Nodes)
            {
                //TreeNode tn = this.ptStructureNewItem.tvPartTree.Nodes;
                RecurseSaveItemType(tn, sItemTypeID);
            }

            Image imIcon = Service.GetImageFromSrv(sPath2Icon);
            Image imPic = Service.GetImageFromSrv(sPath2Picture);
            string sCP = "";

            //this.IsReinit = true;
            //this.IsFirst  = true;
            ipStructureStructures.Enabled = false;
            ipStructureStructures.AddItemType(sItemTypeID, sItemTypeGroupID, sItemTypeName, sItemTypeName,
                                                    imIcon,
                                                    imIcon, //imPic, 
                                                    sCP, sDefaultCPID, sPath2Picture);
            ipStructureStructures.Enabled = true;
            //this.IsReinit = false;
        }

        private void RecurseSaveItemType(TreeNode tn, string sItemTypeID)
        {

            if (tn == null)
                return;
            string sItemParentID = "";

            if (tn.Parent != null)
            {
                string sPartTypeIDTemp;
                string sItemContainerNameTemp;
                string sItemParentIDTemp;
                ParseTag(tn.Parent.Tag.ToString(), out sPartTypeIDTemp,
                    out sItemParentIDTemp, out sItemContainerNameTemp);
                sItemParentID = sItemParentIDTemp;
            }
            string sPartTypeID;
            string sPartID;
            string sItemContainerName;
            ParseTag(tn.Tag.ToString(), out sPartTypeID, out sPartID, out sItemContainerName);

            string sItemPartName = tn.Text.ToString();
            string sPath2Icon = "12";
            //this.tbStructureItemTypeIconPath.Text.ToString();
            string sPath2Picture = "23";
            //this.tbStructureItemTypePicPath.Text.ToString();

            //string sItemTypeID = ipStructureStructures.TypeId.ToString();

            string sID = Service.SavePartType(sItemParentID, sItemPartName, sPath2Icon, sPath2Picture,
                sPartTypeID, sItemContainerName, sItemTypeID);
            tn.Tag = BuildTag(sPartTypeID, sID, sItemContainerName);
            foreach (TreeNode treeNode in tn.Nodes)
            {
                RecurseSaveItemType(treeNode, sItemTypeID);
            }

        }

        /*
        private void RecurseSaveItemType(TreeNode tn)
        {
            if (tn == null)
            {
                return ;
            }
            TreeNode tn2;
            if (tn.Nodes.Count > 0)
            {
                tn2 = tn.Nodes[0];
                if (tn2 != null)
                {
                    string sItemParentID = "";
                    string sPartTypeID;
                    string sPartID;
                    string sItemContainerName;
                    ParseTag(tn2.Tag.ToString(), out sPartTypeID, out sPartID, out sItemContainerName);

                    //string sPartTypeID = this.ipStructureStructures.ItemId;
                    string sItemPartName = tn2.Text.ToString();
                    string sPath2Icon = this.tbStructureItemTypeIconPath.Text.ToString();
                    string sPath2Picture = this.tbStructureItemTypePicPath.Text.ToString();
                    //string sItemContainerName = "item container name";

                    string sItemTypeID = ipStructureStructures.TypeId.ToString();

                    sPartID = this.SavePartType(sItemParentID, sItemPartName, sPath2Icon, sPath2Picture, sPartTypeID, 
                        sItemContainerName, sItemTypeID);
                    tn2.Tag = BuildTag(sPartTypeID, sPartID, sItemContainerName);
                    //sID;
                    //this.SaveItemType(sItemTypeGroupID, sItemTypeName, sPath2Icon, 
                    //	sPath2Picture, sDefaultCPID, sDefaultCPOfficeID);
                }
                RecurseSaveItemType(tn2);
            }
            tn2 = tn.NextNode;
            if (tn2 != null)
            {
                string sItemParentID = "";
                string sPartTypeID;
                string sPartID;
                string sItemContainerName;
                ParseTag(tn2.Tag.ToString(), out sPartTypeID, out sPartID, out sItemContainerName);

                //string sPartTypeID = this.ipStructureStructures.ItemId;
                string sItemPartName = tn2.Text.ToString();
                string sPath2Icon = this.tbStructureItemTypeIconPath.Text.ToString();
                string sPath2Picture = this.tbStructureItemTypePicPath.Text.ToString();
                //string sItemContainerName = "item container name";
                string sItemTypeID = "";

                sPartID = this.SavePartType(sItemParentID, sItemPartName, sPath2Icon, sPath2Picture, sPartTypeID, 
                    sItemContainerName, sItemTypeID);
                tn2.Tag = BuildTag(sPartTypeID, sPartID, sItemContainerName);
            }
            RecurseSaveItemType(tn2);
        }
        */

        private void RecurseBuildItemName(TreeNode tn)
        {
            if (tn == null)
            {
                sItemName += "}";
                return;
            }

            string sPartTypeID;
            string sPartID;
            string sItemContainerName;
            string sTag = tn.Tag.ToString();
            ParseTag(sTag, out sPartTypeID, out sPartID, out sItemContainerName);

            if (sPartTypeID == "15")
            {
                sItemName += tn.Text;
            }
            else
            {
                sItemName += GetItemTypeName(sPartTypeID);
            }
            TreeNode tn2;
            if (tn.Nodes.Count > 0)
            {
                tn2 = tn.Nodes[0];
                if (tn2 != null)
                {
                    sItemName += "{";
                }
                RecurseBuildItemName(tn2);
            }
            tn2 = tn.NextNode;
            if (tn2 != null)
            {
                sItemName += ",";
            }
            RecurseBuildItemName(tn2);
            //tn2 = tn.
        }

        private void btnStructureMoveItemPartBack_Click(object sender, System.EventArgs e)
        {
            TreeNode selectedNode = ptStructureNewItem.tvPartTree.SelectedNode;
            if (selectedNode == null)
            {
                //MessageBox.Show(this, "Node isn't selected. Nothing to remove.", "Warning",
                //	MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            selectedNode.Remove();
            if (ptStructureNewItem.tvPartTree.Nodes.Count == 0)
                lbStructurePartTypes.DataSource = dvItemContainer;
            ptStructureNewItem.RefreshNames(dvPartTypes.Table);
            BuildItemName();
        }

        private void btnStructureMoveItemPart_Click(object sender, System.EventArgs e)
        {
            string sItemTypeId = lbStructurePartTypes.SelectedValue.ToString();
            //string sItemTypeName = this.lbStructurePartTypes.SelectedItem;
            DataRowView rowView = (DataRowView)lbStructurePartTypes.SelectedItem;//.GetType().ToString();
            DataRow row = rowView.Row;
            string sItemTypeName = row["PartTypeName"].ToString();
            string sItemContainerName = "";

            /*			if (sItemTypeName.Equals("Item Container") == true)
                        {
                            ItemContainerNameForm itemContainerNameForm = new ItemContainerNameForm();
                            DialogResult dr = itemContainerNameForm.ShowDialog(this);
                            if (dr != DialogResult.OK)
                            {
                                return ;
                            }
                            sItemContainerName = itemContainerNameForm.GetItemContainerName();
                        }
                        */
            //row["ItemTypeName"].ToString();
            //string sItemTypeName = this.lbStructurePartTypes.SelectedItem.GetType().ToString();

            string sPartTypeID = row["PartTypeID"].ToString();
            string sPartID = "";

            TreeNode selectedNode = ptStructureNewItem.tvPartTree.SelectedNode;

            if (sPartTypeID == "15")
            {
                ItemContainerNameForm nameForm = new ItemContainerNameForm(true);
                DialogResult dr = nameForm.ShowDialog();
                if (dr != DialogResult.OK)
                {
                    return;
                }
                sItemContainerName = nameForm.GetItemContainerName();
                sItemTypeName = sItemContainerName;
            }

            TreeNode newNode = new TreeNode(sItemTypeName);
            newNode.Tag = BuildTag(sPartTypeID, sPartID, sItemContainerName);

            if (sPartTypeID == "15" || selectedNode == null)
            {
                ptStructureNewItem.tvPartTree.Nodes.Add(newNode);
                ptStructureNewItem.tvPartTree.SelectedNode = newNode;
            }
            else
            {
                selectedNode.Nodes.Add(newNode);
                selectedNode.Expand();
            }

            lbStructurePartTypes.DataSource = dvPartTypes;

            ptStructureNewItem.RefreshNames(dvPartTypes.Table);

            BuildItemName();
            //RecurseBuildItemName(

            //this

            //BuildName();
            /*
			
            string sItemTypeID = this.lbStructurePartTypes.SelectedValue.ToString();

            DataSet dsParts = new DataSet();
            DataTable dtMeasureType = Service.GetMeasuresByItemType(sItemTypeID);//tblName : MeasuresByItemType / 1 - empty
            dtMeasureType.TableName = "Measures";	
            dsParts.Tables.Add(dtMeasureType);		//tblName : Measures
            */

            /*
            //copy structeure
            foreach(DataColumn column in dsParts.Tables["PartValue"].Columns)
            {
                if (dsParts.Tables["Measures"].Columns[column.ColumnName] == null)
                {
                    dsParts.Tables["Measures"].Columns.Add(column.ColumnName,column.DataType, column.Expression);
                }
            }
            */

            //dsParts.Tables.Add(Service.GetParts(sItemTypeID));	//tblName : Parts
            //dsParts.Tables.Add(Service.GetPartsStruct());	//tblName : SetParts


            //ptPartTree.Initialize(dsParts.Tables["Parts"]);
            //this.ptStructureNewItem.Initialize(dsParts.Tables["Parts"]);
        }

        //private void InitLVRepo

        private string GetItemTypeName(string sPartTypeID)
        {
            try
            {
                if (dsPartTypes == null)
                    dsPartTypes = Service.GetPartTypes();
                string sFilter = String.Format("PartTypeID = {0}", sPartTypeID);
                DataRow[] rows = dsPartTypes.Tables[0].Select(sFilter);
                if (rows.Length > 0)
                {
                    string s = rows[0]["ShortPartTypeName"].ToString();
                    return s;
                }
                else
                {
                    return sPartTypeID;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Can't filter item type name. Reason: " + ex.ToString(),
                    "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return sPartTypeID;
        }

        /*
        private string GetItemTypeName(string ItemTypeName)
        {
            switch (ItemTypeName.ToLower())
            {
                case "back":
                    return "B";
                case "clasp/lock":
                    return "C";
                case "color diamond stone set":
                    return "CDSS";
                case "color stone set":
                    return "CSS";
                case "colored diamond":
                    return "CD";
                case "diamond":
                    return "D";
                case "item":
                    return "I";
                case "item container":
                    return "IC";
                case "metal":
                    return "M";
                case "metal body":
                    return "MB";
                case "mount":
                    return "Mt";
                case "pearl":
                    return "P";
                case "pearl set":
                    return "PS";
                case "post":
                    return "Pt";
                case "stone":
                    return "S";
                case "white diamond stone set":
                    return "WDSS";
                default:
                    break;
            }
            return ItemTypeName;
        }
        */

        private void ipStructureStructures_NewItemTypeSelected_1(object sender, System.EventArgs e)
        {
            //this.ipStructureStructures.

            /*
			
            string sItemTypeID = this.lbStructurePartTypes.SelectedValue.ToString();

            DataSet dsParts = new DataSet();
            DataTable dtMeasureType = Service.GetMeasuresByItemType(sItemTypeID);//tblName : MeasuresByItemType / 1 - empty
            dtMeasureType.TableName = "Measures";	
            dsParts.Tables.Add(dtMeasureType);		//tblName : Measures
            */
        }

        private void ipStructureStructures_ItemTypeSelected(object sender, System.EventArgs e)
        {
            if (!IsReinit || IsFirst)
            {
                IsFirst = false;

                string sItemTypeGroupID = ipStructureStructures.TypeId;
                if (sItemTypeGroupID != null)
                {
                    PictureAndPath pap2 = Service.GetItemTypeGroupPicAndPath(sItemTypeGroupID);

                    tbStructureItemTypeGroupIconPath.Text = pap2.sPath2Icon;
                    pbStructureItemTypeGroup.Image = pap2.imIcon;
                }
            }
        }

        private void ipStructureStructures_NewItemTypeSelected_2(object sender, System.EventArgs e)
        {
            DataTable table = Service.GetItemizn1_ItemsSubtypesList(ipStructureStructures.TypeId);
            ipStructureStructures.InitializeItems(table);
        }

        /*
        private PictureAndPath GetItemTypePictureAndPath(string sItemTypeID)
        {
            PictureAndPath pap = new PictureAndPath();

            //	spGetItemType
            //	@ItemTypeID dnSmallID
            //	@AuthorID dnSmallID, @AuthorOfficeID dnTinyID,
			

            DataSet dsIn = new DataSet();
            dsIn.Tables.Add("ItemType");
            dsIn.Tables[0].Columns.Add("ItemTypeID", System.Type.GetType("System.String"));

            dsIn.Tables[0].Rows.Add(dsIn.Tables[0].NewRow());
            dsIn.Tables[0].Rows[0]["ItemTypeID"] = sItemTypeID;
            DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);
            pap.sPath2Picture = dsOut.Tables[0].Rows[0]["Path2Picture"].ToString();
            pap.imPicture = Service.GetImageFromSrv(pap.sPath2Picture);
            pap.sPath2Icon = dsOut.Tables[0].Rows[0]["Path2Icon"].ToString();
            pap.imIcon = Service.GetImageFromSrv(pap.sPath2Icon);

            return pap;
        }
        */

        /*
        private PictureAndPath GetItemTypeGroupPicAndPath(string sItemTypeGroupID)
        {
            PictureAndPath pap = new PictureAndPath();
			
            //	spGetItemType
            //	@ItemTypeID dnSmallID
            //	@AuthorID dnSmallID, @AuthorOfficeID dnTinyID,
			

            DataSet dsIn = new DataSet();
            dsIn.Tables.Add("ItemTypeGroup");
            dsIn.Tables[0].Columns.Add("ItemTypeGroupID", System.Type.GetType("System.String"));

            dsIn.Tables[0].Rows.Add(dsIn.Tables[0].NewRow());
            dsIn.Tables[0].Rows[0]["ItemTypeGroupID"] = sItemTypeGroupID;
            DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);
            pap.sPath2Icon = dsOut.Tables[0].Rows[0]["Path2Icon"].ToString();
            pap.imIcon = Service.GetImageFromSrv(pap.sPath2Icon);

            return pap;
        }
        */

        private void ipStructureStructures_SelectedItemTypeChanged(object sender, System.EventArgs e)
        {
            //MessageBox.Show("3");
            //MessageBox.Show("SelectedItemTypeChanged");
        }

        /*
        private void DeleteItemType(string sItemTypeID)
        {
			
            //	spSetItemType
            //	@ItemTypeGroupID dnSmallID, @ItemTypeName dsName, @Path2Icon dsPath, @Path2Picture dsPath, 
            //	@AuthorID dnSmallID, @AuthorOfficeID dnTinyID,
            //	@DefaultCPID dnID, @DefaultCPOfficeID dnTinyID, @ExpireDate ddDate, @CurrentOfficeID dnTinyID
            //	@ItemTypeID dnSmallID,
			

            DataSet dsIn = new DataSet();
            dsIn.Tables.Add("ItemType");
            dsIn.Tables[0].Columns.Add("ItemTypeGroupID", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("ItemTypeName", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("Path2Icon", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("Path2Picture", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("DefaultCPID", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("DefaultCPOfficeID", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("ExpireDate", System.Type.GetType("System.String"));
            //dsIn.Tables[0].Columns.Add("CurrentOfficeID", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("ItemTypeID", System.Type.GetType("System.String"));

            dsIn.Tables[0].Rows.Add(dsIn.Tables[0].NewRow());
            //dsIn.Tables[0].Rows[0]["ParentPartID"] = sItemParentID.Length == 0 ? DBNull.Value : sItemParentID;
            dsIn.Tables[0].Rows[0]["ItemTypeGroupID"] = DBNull.Value;
            dsIn.Tables[0].Rows[0]["ItemTypeName"] = DBNull.Value;
            dsIn.Tables[0].Rows[0]["Path2Icon"] = DBNull.Value;
            dsIn.Tables[0].Rows[0]["Path2Picture"] = DBNull.Value;
            dsIn.Tables[0].Rows[0]["DefaultCPID"] = "2";
            dsIn.Tables[0].Rows[0]["DefaultCPOfficeID"] = "1";
            dsIn.Tables[0].Rows[0]["ExpireDate"] = DateTime.Now;
            //dsIn.Tables[0].Rows[0]["CurrentOfficeID"] = sItemContainerName;
            dsIn.Tables[0].Rows[0]["ItemTypeID"] = sItemTypeID;
            DataSet dsOut = gemoDream.Service.ProxyGenericSet(dsIn, "Set");
            dsOut.Tables[0].Rows[0][0].ToString();
			
        }
        */

        private void btnStructureDeleteItem_Click(object sender, System.EventArgs e)
        {
            string sMsg = "Are you sure you want to delete selected item?";
            string sTitle = "Confirm deleting";
            DialogResult dr = MessageBox.Show(this, sMsg, sTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                string sMsg2 = "Are you really sure you want to delete selected item?";
                dr = MessageBox.Show(this, sMsg2, sTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    string sItemTypeID;
                    sItemTypeID = ipStructureStructures.ItemId.ToString();
                    //DeleteItemType(sItemTypeID);

                    IsReinit = true;
                    IsFirst = true;
                    ipStructureStructures.DeleteItem(sItemTypeID);
                    IsReinit = false;

                    //this.ipStructureStructures.ReInit();

                    //InitStructure();
                    //this.ReinitializeStructure();
                }
            }
        }

        private bool IsStructureExists()
        {
            string sItemTypeName = tbStructureNewItemName.Text.ToString();
            bool bExists = Service.IsItemTypeNameExists(sItemTypeName);
            return bExists;
        }

        private void btnStructureSave_Click(object sender, System.EventArgs e)
        {
            if (IsStructureExists())
            {
                MessageBox.Show(this, "Structure already exists. Please, change it. ",
                    "Structure exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string sPath2Icon = tbStructureItemTypeIconPath.Text;

            //			Image imIcon = Service.GetImageFromSrv(sPath2Icon);
            //			if (sPath2Icon == null || sPath2Icon.Length == 0 || imIcon == null)
            //			{
            //				MessageBox.Show(this, "New item icon is empty. Please, enter the item icon.",
            //					"Empty item icon", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //				return ;
            //			}
            SaveStructure();
        }

        private void tbNewStructure_Click(object sender, System.EventArgs e)
        {

        }

        private void btnStructureClear_Click(object sender, System.EventArgs e)
        {
            IsSaveCopy = true;
            ptStructureNewItem.Clear();
            tbStructureNewItemName.Clear();
            lbStructurePartTypes.DataSource = dvItemContainer;
            btnStructureSave.Enabled = true;
            //this.ptStructureNewItem.tvPartTree.Nodes.Clear();
        }

        private void lbStructureNewItemName_Click(object sender, System.EventArgs e)
        {

        }

        private void tbNewStructure_Enter(object sender, System.EventArgs e)
        {

        }

        private void UpdateItemTypeGroupIcon(string sItemTypeGroupID, string sPath2Icon)
        {

        }

        private void tbStructureItemTypeGroupIconPath_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string sPath2Icon = tbStructureItemTypeGroupIconPath.Text;
                Image im = Service.GetImageFromSrv(sPath2Icon);
                if (im != null)
                {
                    pbStructureItemTypeGroup.Image = im;
                    string sItemTypeGroupID = ipStructureStructures.TypeId;
                    //UpdateItemTypeGroupIcon(sItemTypeGroupID, sPath2Icon);
                }
                else
                {
                    MessageBox.Show("There is no picture in specified location",
                        "Picture not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        //priv

        private void tbStructureItemTypeIconPath_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Image im = Service.GetImageFromSrv(tbStructureItemTypeIconPath.Text);
                if (im != null)
                {
                    //this.pbStructureItemType.Image = im;
                    ilStructureItemType.Images.Clear();
                    ilStructureItemType.Images.Add(im);
                    pbStructureItemType.Image = ilStructureItemType.Images[0];

                }
                else
                {
                    MessageBox.Show("There is no picture in specified location",
                        "Picture not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void ReinitializeStructure()
        {
            IsReinit = true;
            InitStructure();
            IsReinit = false;
        }

        private void ptStructureNewItem_Load(object sender, System.EventArgs e)
        {

        }

        private void lbStructurePartTypes_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void ipStructureStructures_ItemTypeClicked(object sender, System.EventArgs e)
        {
            if (!IsReinit || IsFirst)
            {
                IsFirst = false;
                string sItemTypeID = ipStructureStructures.ItemId;
                if (sItemTypeID != null)
                {
                    PictureAndPath pap = Service.GetItemTypePictureAndPath(sItemTypeID);
                    tbStructureItemTypePicPath.Text = pap.sPath2Picture;
                    if (pap.imPicture != null)
                        pbStructureItemPicture.Image = pap.imPicture;
                    else
                        pbShapesItemPicture.Image = null;

                    tbStructureItemTypeIconPath.Text = pap.sPath2Icon;

                    //this.pbStructureItemType.Image = pap.imIcon;

                    ilStructureItemType.Images.Clear();
                    if (pap.imIcon != null)
                        ilStructureItemType.Images.Add(pap.imIcon);
                    //else
                    //	ilStructureItemType.Images.Add(DBNull.Value);
                    if (ilStructureItemType.Images.Count > 0)
                        pbStructureItemType.Image = ilStructureItemType.Images[0];


                    /*
                    string sItemTypeGroupID = ipStructureStructures.TypeId;
                    PictureAndPath pap2 = GetItemTypeGroupPicAndPath(sItemTypeGroupID);

                    this.tbStructureItemTypeGroupIconPath.Text = pap2.sPath2Icon;
                    this.pbStructureItemTypeGroup.Image = pap2.imIcon;
                    */

                    DataSet dsParts = new DataSet();
                    /*
                    DataTable dtMeasureType = Service.GetMeasuresByItemType(sItemTypeID);//tblName : MeasuresByItemType / 1 - empty
                    dtMeasureType.TableName = "Measures";	

                    dsParts.Tables.Add(dtMeasureType);		//tblName : Measures
                    */

                    dsParts.Tables.Add(Service.GetParts(sItemTypeID));	//tblName : Parts
                    if (dsParts.Tables[0].Rows.Count > 0)
                        lbStructurePartTypes.DataSource = dvPartTypes;
                    //dsParts.Tables.Add(Service.GetPartsStruct());	//tblName : SetParts

                    //gemoDream.Service.debug_DiaspalyDataSet(dsParts);

                    //ptPartTree.Initialize(dsParts.Tables["Parts"]);
                    ptStructureNewItem.Initialize(dsParts.Tables["Parts"]);
                    ptStructureNewItem.ExpandTree();

                    //DataSet ds = Service.GetItemType(sItemTypeID);
                    //string sName = ds.Tables[0].Rows[0]["ItemTypeName"].ToString();

                    //this.tbStructureNewItemName.Text = sName;
                    BuildItemName();
                }
                else
                {
                    tbStructureItemTypeIconPath.Text = "";
                    pbStructureItemType.Image = null;

                    tbStructureItemTypePicPath.Text = "";
                }
            }
        }

        private void pbItemPicture_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (pbStructureItemPicture.Image == null) return;
            if (pbStructureItemPicture.Image.Size.Height > pbStructureItemPicture.Size.Height || pbStructureItemPicture.Image.Size.Width > pbStructureItemPicture.Size.Width)
            {
                pbStructureItemPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                pbStructureItemPicture.SizeMode = PictureBoxSizeMode.CenterImage;
            }
        }

        private void tbStructureGroupName_TextChanged(object sender, System.EventArgs e)
        {

        }

        //private void LoadPicture()
        //{

        //}

        #region Colors
        #endregion Colors
    }
}
