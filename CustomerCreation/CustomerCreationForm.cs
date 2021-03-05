using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Cntrls;
using System.IO;
using System.Threading;
using System.Text;

namespace gemoDream
{
    /// <summary>
    /// Customers & persons creation & edition
    /// </summary>
    public class NewCustomer : System.Windows.Forms.Form
    {
        //private bool IsNewCustomer = false;
        #region DesignerDeclarations
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ColumnHeader itemN;
        private System.Windows.Forms.ColumnHeader firstName;
        private System.Windows.Forms.ColumnHeader lastName;
        private System.Windows.Forms.ColumnHeader position;
        private System.Windows.Forms.ColumnHeader phonePersonN;
        private System.Windows.Forms.ColumnHeader faxPersonN;
        private System.Windows.Forms.ColumnHeader cellPersonN;
        private System.Windows.Forms.ColumnHeader emailPerson;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox tbNewCustomer;
        internal System.Windows.Forms.Button bNewCustomer;
        private System.Windows.Forms.ListView liPersons;
        private System.Windows.Forms.Label lbPStartDate;
        internal System.Windows.Forms.PictureBox pbPicture;
        internal System.Windows.Forms.PictureBox pbSign;
        private System.Windows.Forms.TextBox tbPLastName;
        private System.Windows.Forms.TextBox tbPPhone4;
        private System.Windows.Forms.TextBox tbPPhone3;
        private System.Windows.Forms.TextBox tbPPhone2;
        private System.Windows.Forms.TextBox tbPPhone1;
        private System.Windows.Forms.CheckBox chbPLocationSame;
        private System.Windows.Forms.Button bPUpdate;
        private System.Windows.Forms.Button bPWebClear;
        private System.Windows.Forms.TextBox tbPRetypePwd;
        private System.Windows.Forms.TextBox tbPWebPwd;
        private System.Windows.Forms.TextBox tbPWebLogin;
        private System.Windows.Forms.TextBox tbPBirthDate;
        private System.Windows.Forms.ComboBox cbPPosition;
        private System.Windows.Forms.TextBox tbPID;
        private System.Windows.Forms.TextBox tbPCell4;
        private System.Windows.Forms.TextBox tbPCell3;
        private System.Windows.Forms.TextBox tbPCell2;
        private System.Windows.Forms.TextBox tbPCell1;
        private System.Windows.Forms.TextBox tbPFax4;
        private System.Windows.Forms.TextBox tbPFax3;
        private System.Windows.Forms.TextBox tbPFax2;
        private System.Windows.Forms.TextBox tbPFax1;
        private System.Windows.Forms.TextBox tbPEmail;
        private System.Windows.Forms.TextBox tbPFirstName;
        internal System.Windows.Forms.Button bNewPerson;
        private System.Windows.Forms.Button bDeletePerson;
        private System.Windows.Forms.GroupBox gbCustomer;
        private System.Windows.Forms.Button bUpdate;
        private System.Windows.Forms.TextBox tbAccountNumber;
        private System.Windows.Forms.ComboBox cbCarrier;
        private System.Windows.Forms.CheckBox chbUseTheirAccount;
        private System.Windows.Forms.ComboBox cbIndustry;
        private System.Windows.Forms.ComboBox cbBusiness;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.TextBox tbFax4;
        private System.Windows.Forms.TextBox tbFax3;
        private System.Windows.Forms.TextBox tbFax2;
        private System.Windows.Forms.TextBox tbFax1;
        private System.Windows.Forms.TextBox tbCompany;
        private System.Windows.Forms.GroupBox gbRBs;
        private System.Windows.Forms.RadioButton rbWeCarry;
        private System.Windows.Forms.RadioButton rbTheyCarry;
        private System.Windows.Forms.RadioButton rbWeShip;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Panel gbUnfixed;
        private System.Windows.Forms.Panel gbFixed;
        private System.Windows.Forms.RadioButton rbFixedP;
        private System.Windows.Forms.RadioButton rbFixedB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFixedP;
        private System.Windows.Forms.TextBox tbFixedB;
        private Cntrls.ComboTextComponent cbcCustomer;
        private gemoDream.Communication cCustomer;
        private gemoDream.Communication cPerson;
        private Cntrls.Location locPerson;
        private Cntrls.Location locCustomer;
        private System.Windows.Forms.GroupBox gbPerson;
        private System.Windows.Forms.StatusBar sbStatus;
        private Cntrls.Permissions prmCustomer;
        private Cntrls.Permissions prmPerson;
        private System.Windows.Forms.ListBox lbxIndustry;
        private System.Windows.Forms.Button bIndustrySelect;
        private System.Windows.Forms.Button bDeleteMembership;
        private Cntrls.OrdersTree ordersTree1;
        private System.Windows.Forms.Label lbPhoneExt;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.RadioButton rbClosed;
        private System.Windows.Forms.RadioButton rbOpen;
        private System.Windows.Forms.TextBox tbPhone3;
        private System.Windows.Forms.TextBox tbPhone1;
        private System.Windows.Forms.TextBox tbPhone4;
        private System.Windows.Forms.TextBox tbPhone2;
        private System.Windows.Forms.TextBox tbStartDate;
        private Cntrls.Price price1;
        private Cntrls.PartTree ptrTree;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label lbFixedCaratPrice;
        private System.Windows.Forms.Button btnUpdateRanges;
        private System.Windows.Forms.Button btnDelRange;
        private System.Windows.Forms.Button btnAddRange;
        private System.Windows.Forms.RadioButton rbUnfixed;
        private System.Windows.Forms.RadioButton rbFixed;
        private System.Windows.Forms.Button bLoadHistory;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox tbShortName;
        private System.Windows.Forms.TextBox tbPhoneExt;
        #endregion DesignerDeclarations

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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NewCustomer));
            this.sbStatus = new System.Windows.Forms.StatusBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.liPersons = new System.Windows.Forms.ListView();
            this.itemN = new System.Windows.Forms.ColumnHeader();
            this.firstName = new System.Windows.Forms.ColumnHeader();
            this.lastName = new System.Windows.Forms.ColumnHeader();
            this.position = new System.Windows.Forms.ColumnHeader();
            this.phonePersonN = new System.Windows.Forms.ColumnHeader();
            this.faxPersonN = new System.Windows.Forms.ColumnHeader();
            this.cellPersonN = new System.Windows.Forms.ColumnHeader();
            this.emailPerson = new System.Windows.Forms.ColumnHeader();
            this.gbPerson = new System.Windows.Forms.GroupBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lbPhoneExt = new System.Windows.Forms.Label();
            this.prmPerson = new Cntrls.Permissions();
            this.cPerson = new gemoDream.Communication();
            this.lbPStartDate = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.pbPicture = new System.Windows.Forms.PictureBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.pbSign = new System.Windows.Forms.PictureBox();
            this.tbPLastName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.locPerson = new Cntrls.Location();
            this.chbPLocationSame = new System.Windows.Forms.CheckBox();
            this.bPUpdate = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.bPWebClear = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tbPRetypePwd = new System.Windows.Forms.TextBox();
            this.tbPWebPwd = new System.Windows.Forms.TextBox();
            this.tbPWebLogin = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbPBirthDate = new System.Windows.Forms.TextBox();
            this.cbPPosition = new System.Windows.Forms.ComboBox();
            this.tbPID = new System.Windows.Forms.TextBox();
            this.tbPEmail = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbPFirstName = new System.Windows.Forms.TextBox();
            this.tbPhoneExt = new System.Windows.Forms.TextBox();
            this.tbPCell3 = new System.Windows.Forms.TextBox();
            this.tbPCell2 = new System.Windows.Forms.TextBox();
            this.tbPCell1 = new System.Windows.Forms.TextBox();
            this.tbPCell4 = new System.Windows.Forms.TextBox();
            this.tbPFax3 = new System.Windows.Forms.TextBox();
            this.tbPFax2 = new System.Windows.Forms.TextBox();
            this.tbPFax1 = new System.Windows.Forms.TextBox();
            this.tbPFax4 = new System.Windows.Forms.TextBox();
            this.tbPPhone3 = new System.Windows.Forms.TextBox();
            this.tbPPhone2 = new System.Windows.Forms.TextBox();
            this.tbPPhone1 = new System.Windows.Forms.TextBox();
            this.tbPPhone4 = new System.Windows.Forms.TextBox();
            this.bNewPerson = new System.Windows.Forms.Button();
            this.bDeletePerson = new System.Windows.Forms.Button();
            this.gbCustomer = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bDeleteMembership = new System.Windows.Forms.Button();
            this.bIndustrySelect = new System.Windows.Forms.Button();
            this.prmCustomer = new Cntrls.Permissions();
            this.lbxIndustry = new System.Windows.Forms.ListBox();
            this.locCustomer = new Cntrls.Location();
            this.cCustomer = new gemoDream.Communication();
            this.bUpdate = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.gbRBs = new System.Windows.Forms.GroupBox();
            this.rbWeShip = new System.Windows.Forms.RadioButton();
            this.rbTheyCarry = new System.Windows.Forms.RadioButton();
            this.rbWeCarry = new System.Windows.Forms.RadioButton();
            this.tbAccountNumber = new System.Windows.Forms.TextBox();
            this.cbCarrier = new System.Windows.Forms.ComboBox();
            this.chbUseTheirAccount = new System.Windows.Forms.CheckBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbStartDate = new System.Windows.Forms.TextBox();
            this.cbIndustry = new System.Windows.Forms.ComboBox();
            this.cbBusiness = new System.Windows.Forms.ComboBox();
            this.tbID = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCompany = new System.Windows.Forms.TextBox();
            this.tbFax3 = new System.Windows.Forms.TextBox();
            this.tbFax2 = new System.Windows.Forms.TextBox();
            this.tbFax1 = new System.Windows.Forms.TextBox();
            this.tbFax4 = new System.Windows.Forms.TextBox();
            this.tbPhone2 = new System.Windows.Forms.TextBox();
            this.tbPhone1 = new System.Windows.Forms.TextBox();
            this.tbPhone3 = new System.Windows.Forms.TextBox();
            this.tbPhone4 = new System.Windows.Forms.TextBox();
            this.bNewCustomer = new System.Windows.Forms.Button();
            this.tbNewCustomer = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bLoadHistory = new System.Windows.Forms.Button();
            this.ordersTree1 = new Cntrls.OrdersTree();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.rbClosed = new System.Windows.Forms.RadioButton();
            this.rbOpen = new System.Windows.Forms.RadioButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ptrTree = new Cntrls.PartTree();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnUpdateRanges = new System.Windows.Forms.Button();
            this.btnDelRange = new System.Windows.Forms.Button();
            this.btnAddRange = new System.Windows.Forms.Button();
            this.rbUnfixed = new System.Windows.Forms.RadioButton();
            this.rbFixed = new System.Windows.Forms.RadioButton();
            this.gbFixed = new System.Windows.Forms.Panel();
            this.lbFixedCaratPrice = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.tbFixedP = new System.Windows.Forms.TextBox();
            this.rbFixedP = new System.Windows.Forms.RadioButton();
            this.label17 = new System.Windows.Forms.Label();
            this.tbFixedB = new System.Windows.Forms.TextBox();
            this.rbFixedB = new System.Windows.Forms.RadioButton();
            this.gbUnfixed = new System.Windows.Forms.Panel();
            this.price1 = new Cntrls.Price();
            this.label13 = new System.Windows.Forms.Label();
            this.cbcCustomer = new Cntrls.ComboTextComponent();
            this.label27 = new System.Windows.Forms.Label();
            this.tbShortName = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gbPerson.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.panel5.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.gbCustomer.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.gbRBs.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbFixed.SuspendLayout();
            this.gbUnfixed.SuspendLayout();
            this.SuspendLayout();
            // 
            // sbStatus
            // 
            this.sbStatus.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
            this.sbStatus.Location = new System.Drawing.Point(0, 673);
            this.sbStatus.Name = "sbStatus";
            this.sbStatus.Size = new System.Drawing.Size(944, 15);
            this.sbStatus.TabIndex = 8;
            this.sbStatus.Text = "Ready";
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.tabControl1.ItemSize = new System.Drawing.Size(206, 15);
            this.tabControl1.Location = new System.Drawing.Point(5, 25);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(6, 2);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(935, 645);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.liPersons);
            this.tabPage1.Controls.Add(this.gbPerson);
            this.tabPage1.Controls.Add(this.bNewPerson);
            this.tabPage1.Controls.Add(this.bDeletePerson);
            this.tabPage1.Controls.Add(this.gbCustomer);
            this.tabPage1.Controls.Add(this.bNewCustomer);
            this.tabPage1.Controls.Add(this.tbNewCustomer);
            this.tabPage1.Location = new System.Drawing.Point(19, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(912, 637);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Customer";
            this.tabPage1.Enter += new System.EventHandler(this.tabPage1_Enter);
            // 
            // liPersons
            // 
            this.liPersons.AutoArrange = false;
            this.liPersons.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.itemN,
																						this.firstName,
																						this.lastName,
																						this.position,
																						this.phonePersonN,
																						this.faxPersonN,
																						this.cellPersonN,
																						this.emailPerson});
            this.liPersons.FullRowSelect = true;
            this.liPersons.GridLines = true;
            this.liPersons.HideSelection = false;
            this.liPersons.Location = new System.Drawing.Point(5, 280);
            this.liPersons.MultiSelect = false;
            this.liPersons.Name = "liPersons";
            this.liPersons.Size = new System.Drawing.Size(695, 80);
            this.liPersons.TabIndex = 3;
            this.liPersons.View = System.Windows.Forms.View.Details;
            this.liPersons.Leave += new System.EventHandler(this.ControlFocusLeave);
            this.liPersons.Enter += new System.EventHandler(this.liPersons_Enter);
            this.liPersons.SelectedIndexChanged += new System.EventHandler(this.liPersons_SelectedIndexChanged);
            // 
            // itemN
            // 
            this.itemN.Text = "#";
            this.itemN.Width = 27;
            // 
            // firstName
            // 
            this.firstName.Text = "First Name";
            this.firstName.Width = 100;
            // 
            // lastName
            // 
            this.lastName.Text = "Last Name";
            this.lastName.Width = 100;
            // 
            // position
            // 
            this.position.Text = "Position";
            this.position.Width = 64;
            // 
            // phonePersonN
            // 
            this.phonePersonN.Text = "Phone";
            this.phonePersonN.Width = 78;
            // 
            // faxPersonN
            // 
            this.faxPersonN.Text = "Fax";
            this.faxPersonN.Width = 80;
            // 
            // cellPersonN
            // 
            this.cellPersonN.Text = "Cell";
            this.cellPersonN.Width = 79;
            // 
            // emailPerson
            // 
            this.emailPerson.Text = "Email";
            this.emailPerson.Width = 161;
            // 
            // gbPerson
            // 
            this.gbPerson.Controls.Add(this.label26);
            this.gbPerson.Controls.Add(this.label25);
            this.gbPerson.Controls.Add(this.label24);
            this.gbPerson.Controls.Add(this.label23);
            this.gbPerson.Controls.Add(this.lbPhoneExt);
            this.gbPerson.Controls.Add(this.prmPerson);
            this.gbPerson.Controls.Add(this.cPerson);
            this.gbPerson.Controls.Add(this.lbPStartDate);
            this.gbPerson.Controls.Add(this.label35);
            this.gbPerson.Controls.Add(this.groupBox11);
            this.gbPerson.Controls.Add(this.groupBox10);
            this.gbPerson.Controls.Add(this.tbPLastName);
            this.gbPerson.Controls.Add(this.label12);
            this.gbPerson.Controls.Add(this.panel5);
            this.gbPerson.Controls.Add(this.bPUpdate);
            this.gbPerson.Controls.Add(this.groupBox8);
            this.gbPerson.Controls.Add(this.label7);
            this.gbPerson.Controls.Add(this.tbPBirthDate);
            this.gbPerson.Controls.Add(this.cbPPosition);
            this.gbPerson.Controls.Add(this.tbPID);
            this.gbPerson.Controls.Add(this.tbPEmail);
            this.gbPerson.Controls.Add(this.label8);
            this.gbPerson.Controls.Add(this.label9);
            this.gbPerson.Controls.Add(this.label10);
            this.gbPerson.Controls.Add(this.tbPFirstName);
            this.gbPerson.Controls.Add(this.tbPhoneExt);
            this.gbPerson.Controls.Add(this.tbPCell3);
            this.gbPerson.Controls.Add(this.tbPCell2);
            this.gbPerson.Controls.Add(this.tbPCell1);
            this.gbPerson.Controls.Add(this.tbPCell4);
            this.gbPerson.Controls.Add(this.tbPFax3);
            this.gbPerson.Controls.Add(this.tbPFax2);
            this.gbPerson.Controls.Add(this.tbPFax1);
            this.gbPerson.Controls.Add(this.tbPFax4);
            this.gbPerson.Controls.Add(this.tbPPhone3);
            this.gbPerson.Controls.Add(this.tbPPhone2);
            this.gbPerson.Controls.Add(this.tbPPhone1);
            this.gbPerson.Controls.Add(this.tbPPhone4);
            this.gbPerson.Enabled = false;
            this.gbPerson.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.gbPerson.ForeColor = System.Drawing.Color.DimGray;
            this.gbPerson.Location = new System.Drawing.Point(6, 365);
            this.gbPerson.Name = "gbPerson";
            this.gbPerson.Size = new System.Drawing.Size(899, 270);
            this.gbPerson.TabIndex = 6;
            this.gbPerson.TabStop = false;
            this.gbPerson.Text = "Person";
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.label26.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label26.Location = new System.Drawing.Point(10, 80);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(65, 15);
            this.label26.TabIndex = 92;
            this.label26.Text = "ID";
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.label25.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label25.Location = new System.Drawing.Point(10, 60);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(65, 15);
            this.label25.TabIndex = 91;
            this.label25.Text = "Position";
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.label24.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label24.Location = new System.Drawing.Point(10, 40);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(65, 15);
            this.label24.TabIndex = 90;
            this.label24.Text = "Last Name";
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.label23.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label23.Location = new System.Drawing.Point(10, 20);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(65, 15);
            this.label23.TabIndex = 89;
            this.label23.Text = "First Name";
            // 
            // lbPhoneExt
            // 
            this.lbPhoneExt.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.lbPhoneExt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbPhoneExt.Location = new System.Drawing.Point(10, 170);
            this.lbPhoneExt.Name = "lbPhoneExt";
            this.lbPhoneExt.Size = new System.Drawing.Size(40, 15);
            this.lbPhoneExt.TabIndex = 35;
            this.lbPhoneExt.Text = "Ext.";
            // 
            // prmPerson
            // 
            this.prmPerson.Location = new System.Drawing.Point(705, 15);
            this.prmPerson.Name = "prmPerson";
            this.prmPerson.Size = new System.Drawing.Size(190, 210);
            this.prmPerson.TabIndex = 22;
            this.prmPerson.Enter += new System.EventHandler(this.prmPerson_Enter);
            this.prmPerson.Leave += new System.EventHandler(this.ControlFocusLeave);
            // 
            // cPerson
            // 
            this.cPerson.Location = new System.Drawing.Point(220, 205);
            this.cPerson.Name = "cPerson";
            this.cPerson.Size = new System.Drawing.Size(230, 60);
            this.cPerson.TabIndex = 20;
            this.cPerson.Enter += new System.EventHandler(this.cPerson_Enter);
            this.cPerson.Leave += new System.EventHandler(this.ControlFocusLeave);
            // 
            // lbPStartDate
            // 
            this.lbPStartDate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbPStartDate.Location = new System.Drawing.Point(90, 100);
            this.lbPStartDate.Name = "lbPStartDate";
            this.lbPStartDate.Size = new System.Drawing.Size(125, 15);
            this.lbPStartDate.TabIndex = 32;
            // 
            // label35
            // 
            this.label35.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.label35.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label35.Location = new System.Drawing.Point(10, 100);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(75, 15);
            this.label35.TabIndex = 31;
            this.label35.Text = "Start Date";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.pbPicture);
            this.groupBox11.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.groupBox11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox11.Location = new System.Drawing.Point(455, 140);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(100, 125);
            this.groupBox11.TabIndex = 30;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Picture";
            // 
            // pbPicture
            // 
            this.pbPicture.BackColor = System.Drawing.SystemColors.Control;
            this.pbPicture.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbPicture.BackgroundImage")));
            this.pbPicture.Location = new System.Drawing.Point(10, 30);
            this.pbPicture.Name = "pbPicture";
            this.pbPicture.Size = new System.Drawing.Size(80, 80);
            this.pbPicture.TabIndex = 26;
            this.pbPicture.TabStop = false;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.pbSign);
            this.groupBox10.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.groupBox10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox10.Location = new System.Drawing.Point(560, 140);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(140, 125);
            this.groupBox10.TabIndex = 29;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Signature";
            // 
            // pbSign
            // 
            this.pbSign.BackColor = System.Drawing.SystemColors.Control;
            this.pbSign.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbSign.BackgroundImage")));
            this.pbSign.Location = new System.Drawing.Point(10, 30);
            this.pbSign.Name = "pbSign";
            this.pbSign.Size = new System.Drawing.Size(120, 80);
            this.pbSign.TabIndex = 26;
            this.pbSign.TabStop = false;
            // 
            // tbPLastName
            // 
            this.tbPLastName.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.tbPLastName.Location = new System.Drawing.Point(90, 35);
            this.tbPLastName.Name = "tbPLastName";
            this.tbPLastName.Size = new System.Drawing.Size(125, 20);
            this.tbPLastName.TabIndex = 1;
            this.tbPLastName.Text = "";
            this.tbPLastName.Leave += new System.EventHandler(this.ControlFocusLeave);
            this.tbPLastName.Enter += new System.EventHandler(this.tbPLastName_Enter);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(10, 145);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 15);
            this.label12.TabIndex = 24;
            this.label12.Text = "Phone";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.locPerson);
            this.panel5.Controls.Add(this.chbPLocationSame);
            this.panel5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel5.Location = new System.Drawing.Point(220, 10);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(230, 190);
            this.panel5.TabIndex = 19;
            // 
            // locPerson
            // 
            this.locPerson.Enabled = false;
            this.locPerson.Location = new System.Drawing.Point(5, 5);
            this.locPerson.Name = "locPerson";
            this.locPerson.Size = new System.Drawing.Size(215, 110);
            this.locPerson.TabIndex = 0;
            this.locPerson.Enter += new System.EventHandler(this.locPerson_Enter);
            this.locPerson.Leave += new System.EventHandler(this.ControlFocusLeave);
            // 
            // chbPLocationSame
            // 
            this.chbPLocationSame.Checked = true;
            this.chbPLocationSame.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbPLocationSame.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.chbPLocationSame.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chbPLocationSame.Location = new System.Drawing.Point(5, 165);
            this.chbPLocationSame.Name = "chbPLocationSame";
            this.chbPLocationSame.Size = new System.Drawing.Size(210, 15);
            this.chbPLocationSame.TabIndex = 1;
            this.chbPLocationSame.Text = "Same as Company Address";
            this.chbPLocationSame.CheckedChanged += new System.EventHandler(this.chbPLocationSame_CheckedChanged);
            // 
            // bPUpdate
            // 
            this.bPUpdate.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.bPUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bPUpdate.Location = new System.Drawing.Point(800, 235);
            this.bPUpdate.Name = "bPUpdate";
            this.bPUpdate.Size = new System.Drawing.Size(90, 23);
            this.bPUpdate.TabIndex = 23;
            this.bPUpdate.Text = "Upda&te";
            this.bPUpdate.Click += new System.EventHandler(this.bPUpdate_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.bPWebClear);
            this.groupBox8.Controls.Add(this.label16);
            this.groupBox8.Controls.Add(this.label15);
            this.groupBox8.Controls.Add(this.label14);
            this.groupBox8.Controls.Add(this.tbPRetypePwd);
            this.groupBox8.Controls.Add(this.tbPWebPwd);
            this.groupBox8.Controls.Add(this.tbPWebLogin);
            this.groupBox8.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.groupBox8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox8.Location = new System.Drawing.Point(455, 15);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(245, 125);
            this.groupBox8.TabIndex = 21;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Web";
            // 
            // bPWebClear
            // 
            this.bPWebClear.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.bPWebClear.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bPWebClear.Location = new System.Drawing.Point(145, 95);
            this.bPWebClear.Name = "bPWebClear";
            this.bPWebClear.Size = new System.Drawing.Size(90, 23);
            this.bPWebClear.TabIndex = 3;
            this.bPWebClear.Text = "Clear";
            this.bPWebClear.Click += new System.EventHandler(this.bPWebClear_Click);
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(5, 75);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 30);
            this.label16.TabIndex = 88;
            this.label16.Text = "Re-type Password";
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(5, 50);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 15);
            this.label15.TabIndex = 88;
            this.label15.Text = "Password";
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(5, 25);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 15);
            this.label14.TabIndex = 88;
            this.label14.Text = "Login";
            // 
            // tbPRetypePwd
            // 
            this.tbPRetypePwd.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.tbPRetypePwd.Location = new System.Drawing.Point(70, 70);
            this.tbPRetypePwd.Name = "tbPRetypePwd";
            this.tbPRetypePwd.PasswordChar = '*';
            this.tbPRetypePwd.Size = new System.Drawing.Size(165, 20);
            this.tbPRetypePwd.TabIndex = 2;
            this.tbPRetypePwd.Text = "";
            this.tbPRetypePwd.Leave += new System.EventHandler(this.ControlFocusLeave);
            this.tbPRetypePwd.Enter += new System.EventHandler(this.tbPRetypePwd_Enter);
            // 
            // tbPWebPwd
            // 
            this.tbPWebPwd.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.tbPWebPwd.Location = new System.Drawing.Point(70, 45);
            this.tbPWebPwd.Name = "tbPWebPwd";
            this.tbPWebPwd.PasswordChar = '*';
            this.tbPWebPwd.Size = new System.Drawing.Size(165, 20);
            this.tbPWebPwd.TabIndex = 1;
            this.tbPWebPwd.Text = "";
            this.tbPWebPwd.Leave += new System.EventHandler(this.ControlFocusLeave);
            this.tbPWebPwd.Enter += new System.EventHandler(this.tbPWebPwd_Enter);
            // 
            // tbPWebLogin
            // 
            this.tbPWebLogin.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.tbPWebLogin.Location = new System.Drawing.Point(70, 20);
            this.tbPWebLogin.Name = "tbPWebLogin";
            this.tbPWebLogin.Size = new System.Drawing.Size(165, 20);
            this.tbPWebLogin.TabIndex = 0;
            this.tbPWebLogin.Text = "";
            this.tbPWebLogin.Leave += new System.EventHandler(this.ControlFocusLeave);
            this.tbPWebLogin.Enter += new System.EventHandler(this.tbPWebLogin_Enter);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(10, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 15);
            this.label7.TabIndex = 88;
            this.label7.Text = "Birth Date";
            // 
            // tbPBirthDate
            // 
            this.tbPBirthDate.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.tbPBirthDate.Location = new System.Drawing.Point(90, 115);
            this.tbPBirthDate.MaxLength = 10;
            this.tbPBirthDate.Name = "tbPBirthDate";
            this.tbPBirthDate.Size = new System.Drawing.Size(125, 20);
            this.tbPBirthDate.TabIndex = 4;
            this.tbPBirthDate.Text = "";
            this.tbPBirthDate.TextChanged += new System.EventHandler(this.tbPBirthDate_TextChanged);
            this.tbPBirthDate.Leave += new System.EventHandler(this.ControlFocusLeave);
            this.tbPBirthDate.Enter += new System.EventHandler(this.tbPBirthDate_Enter);
            // 
            // cbPPosition
            // 
            this.cbPPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPPosition.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.cbPPosition.ItemHeight = 12;
            this.cbPPosition.Location = new System.Drawing.Point(90, 55);
            this.cbPPosition.Name = "cbPPosition";
            this.cbPPosition.Size = new System.Drawing.Size(125, 20);
            this.cbPPosition.TabIndex = 2;
            this.cbPPosition.Leave += new System.EventHandler(this.ControlFocusLeave);
            this.cbPPosition.Enter += new System.EventHandler(this.cbPPosition_Enter);
            // 
            // tbPID
            // 
            this.tbPID.Enabled = false;
            this.tbPID.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.tbPID.Location = new System.Drawing.Point(90, 75);
            this.tbPID.Name = "tbPID";
            this.tbPID.Size = new System.Drawing.Size(125, 20);
            this.tbPID.TabIndex = 3;
            this.tbPID.Text = "";
            this.tbPID.Leave += new System.EventHandler(this.ControlFocusLeave);
            this.tbPID.Enter += new System.EventHandler(this.tbPID_Enter);
            // 
            // tbPEmail
            // 
            this.tbPEmail.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.tbPEmail.Location = new System.Drawing.Point(65, 240);
            this.tbPEmail.Name = "tbPEmail";
            this.tbPEmail.Size = new System.Drawing.Size(150, 20);
            this.tbPEmail.TabIndex = 18;
            this.tbPEmail.Text = "";
            this.tbPEmail.Leave += new System.EventHandler(this.ControlFocusLeave);
            this.tbPEmail.Enter += new System.EventHandler(this.tbPEmail_Enter);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(10, 245);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 15);
            this.label8.TabIndex = 10;
            this.label8.Text = "Email";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(10, 220);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 15);
            this.label9.TabIndex = 9;
            this.label9.Text = "Cell";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(10, 195);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 15);
            this.label10.TabIndex = 88;
            this.label10.Text = "Fax";
            // 
            // tbPFirstName
            // 
            this.tbPFirstName.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.tbPFirstName.Location = new System.Drawing.Point(90, 15);
            this.tbPFirstName.Name = "tbPFirstName";
            this.tbPFirstName.Size = new System.Drawing.Size(125, 20);
            this.tbPFirstName.TabIndex = 0;
            this.tbPFirstName.Text = "";
            this.tbPFirstName.Leave += new System.EventHandler(this.ControlFocusLeave);
            this.tbPFirstName.Enter += new System.EventHandler(this.tbPFirstName_Enter);
            // 
            // tbPhoneExt
            // 
            this.tbPhoneExt.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.tbPhoneExt.Location = new System.Drawing.Point(65, 165);
            this.tbPhoneExt.MaxLength = 4;
            this.tbPhoneExt.Name = "tbPhoneExt";
            this.tbPhoneExt.Size = new System.Drawing.Size(35, 20);
            this.tbPhoneExt.TabIndex = 9;
            this.tbPhoneExt.Text = "";
            this.tbPhoneExt.Leave += new System.EventHandler(this.ControlFocusLeave);
            this.tbPhoneExt.Enter += new System.EventHandler(this.tbPhoneExt_Enter);
            // 
            // tbPCell3
            // 
            this.tbPCell3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.tbPCell3.Location = new System.Drawing.Point(140, 215);
            this.tbPCell3.MaxLength = 3;
            this.tbPCell3.Name = "tbPCell3";
            this.tbPCell3.Size = new System.Drawing.Size(30, 20);
            this.tbPCell3.TabIndex = 16;
            this.tbPCell3.Text = "";
            this.tbPCell3.TextChanged += new System.EventHandler(this.tbPCell3_TextChanged);
            this.tbPCell3.Leave += new System.EventHandler(this.ControlFocusLeave);
            this.tbPCell3.Enter += new System.EventHandler(this.tbPCell3_Enter);
            // 
            // tbPCell2
            // 
            this.tbPCell2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.tbPCell2.Location = new System.Drawing.Point(105, 215);
            this.tbPCell2.MaxLength = 3;
            this.tbPCell2.Name = "tbPCell2";
            this.tbPCell2.Size = new System.Drawing.Size(30, 20);
            this.tbPCell2.TabIndex = 15;
            this.tbPCell2.Text = "";
            this.tbPCell2.TextChanged += new System.EventHandler(this.tbPCell2_TextChanged);
            this.tbPCell2.Leave += new System.EventHandler(this.ControlFocusLeave);
            this.tbPCell2.Enter += new System.EventHandler(this.tbPCell2_Enter);
            // 
            // tbPCell1
            // 
            this.tbPCell1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.tbPCell1.Location = new System.Drawing.Point(65, 215);
            this.tbPCell1.MaxLength = 4;
            this.tbPCell1.Name = "tbPCell1";
            this.tbPCell1.Size = new System.Drawing.Size(35, 20);
            this.tbPCell1.TabIndex = 14;
            this.tbPCell1.Text = "+1";
            this.tbPCell1.TextChanged += new System.EventHandler(this.tbPCell1_TextChanged);
            this.tbPCell1.Leave += new System.EventHandler(this.ControlFocusLeave);
            this.tbPCell1.Enter += new System.EventHandler(this.tbPCell1_Enter);
            // 
            // tbPCell4
            // 
            this.tbPCell4.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.tbPCell4.Location = new System.Drawing.Point(175, 215);
            this.tbPCell4.MaxLength = 4;
            this.tbPCell4.Name = "tbPCell4";
            this.tbPCell4.Size = new System.Drawing.Size(40, 20);
            this.tbPCell4.TabIndex = 17;
            this.tbPCell4.Text = "";
            this.tbPCell4.Leave += new System.EventHandler(this.ControlFocusLeave);
            this.tbPCell4.Enter += new System.EventHandler(this.tbPCell4_Enter);
            // 
            // tbPFax3
            // 
            this.tbPFax3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.tbPFax3.Location = new System.Drawing.Point(140, 190);
            this.tbPFax3.MaxLength = 3;
            this.tbPFax3.Name = "tbPFax3";
            this.tbPFax3.Size = new System.Drawing.Size(30, 20);
            this.tbPFax3.TabIndex = 12;
            this.tbPFax3.Text = "";
            this.tbPFax3.TextChanged += new System.EventHandler(this.tbPFax3_TextChanged);
            this.tbPFax3.Leave += new System.EventHandler(this.ControlFocusLeave);
            this.tbPFax3.Enter += new System.EventHandler(this.tbPFax3_Enter);
            // 
            // tbPFax2
            // 
            this.tbPFax2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.tbPFax2.Location = new System.Drawing.Point(105, 190);
            this.tbPFax2.MaxLength = 3;
            this.tbPFax2.Name = "tbPFax2";
            this.tbPFax2.Size = new System.Drawing.Size(30, 20);
            this.tbPFax2.TabIndex = 11;
            this.tbPFax2.Text = "";
            this.tbPFax2.TextChanged += new System.EventHandler(this.tbPFax2_TextChanged);
            this.tbPFax2.Leave += new System.EventHandler(this.ControlFocusLeave);
            this.tbPFax2.Enter += new System.EventHandler(this.tbPFax2_Enter);
            // 
            // tbPFax1
            // 
            this.tbPFax1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.tbPFax1.Location = new System.Drawing.Point(65, 190);
            this.tbPFax1.MaxLength = 4;
            this.tbPFax1.Name = "tbPFax1";
            this.tbPFax1.Size = new System.Drawing.Size(35, 20);
            this.tbPFax1.TabIndex = 10;
            this.tbPFax1.Text = "+1";
            this.tbPFax1.TextChanged += new System.EventHandler(this.tbPFax1_TextChanged);
            this.tbPFax1.Leave += new System.EventHandler(this.ControlFocusLeave);
            this.tbPFax1.Enter += new System.EventHandler(this.tbPFax1_Enter);
            // 
            // tbPFax4
            // 
            this.tbPFax4.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.tbPFax4.Location = new System.Drawing.Point(175, 190);
            this.tbPFax4.MaxLength = 4;
            this.tbPFax4.Name = "tbPFax4";
            this.tbPFax4.Size = new System.Drawing.Size(40, 20);
            this.tbPFax4.TabIndex = 13;
            this.tbPFax4.Text = "";
            this.tbPFax4.Leave += new System.EventHandler(this.ControlFocusLeave);
            this.tbPFax4.Enter += new System.EventHandler(this.tbPFax4_Enter);
            // 
            // tbPPhone3
            // 
            this.tbPPhone3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.tbPPhone3.Location = new System.Drawing.Point(140, 140);
            this.tbPPhone3.MaxLength = 3;
            this.tbPPhone3.Name = "tbPPhone3";
            this.tbPPhone3.Size = new System.Drawing.Size(30, 20);
            this.tbPPhone3.TabIndex = 7;
            this.tbPPhone3.Text = "";
            this.tbPPhone3.TextChanged += new System.EventHandler(this.tbPPhone3_TextChanged);
            this.tbPPhone3.Leave += new System.EventHandler(this.ControlFocusLeave);
            this.tbPPhone3.Enter += new System.EventHandler(this.tbPPhone3_Enter);
            // 
            // tbPPhone2
            // 
            this.tbPPhone2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.tbPPhone2.Location = new System.Drawing.Point(105, 140);
            this.tbPPhone2.MaxLength = 3;
            this.tbPPhone2.Name = "tbPPhone2";
            this.tbPPhone2.Size = new System.Drawing.Size(30, 20);
            this.tbPPhone2.TabIndex = 6;
            this.tbPPhone2.Text = "";
            this.tbPPhone2.TextChanged += new System.EventHandler(this.tbPPhone2_TextChanged);
            this.tbPPhone2.Leave += new System.EventHandler(this.ControlFocusLeave);
            this.tbPPhone2.Enter += new System.EventHandler(this.tbPPhone2_Enter);
            // 
            // tbPPhone1
            // 
            this.tbPPhone1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.tbPPhone1.Location = new System.Drawing.Point(65, 140);
            this.tbPPhone1.MaxLength = 4;
            this.tbPPhone1.Name = "tbPPhone1";
            this.tbPPhone1.Size = new System.Drawing.Size(35, 20);
            this.tbPPhone1.TabIndex = 5;
            this.tbPPhone1.Text = "+1";
            this.tbPPhone1.TextChanged += new System.EventHandler(this.tbPPhone1_TextChanged);
            this.tbPPhone1.Leave += new System.EventHandler(this.ControlFocusLeave);
            this.tbPPhone1.Enter += new System.EventHandler(this.tbPPhone1_Enter);
            // 
            // tbPPhone4
            // 
            this.tbPPhone4.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.tbPPhone4.Location = new System.Drawing.Point(175, 140);
            this.tbPPhone4.MaxLength = 4;
            this.tbPPhone4.Name = "tbPPhone4";
            this.tbPPhone4.Size = new System.Drawing.Size(40, 20);
            this.tbPPhone4.TabIndex = 8;
            this.tbPPhone4.Text = "";
            this.tbPPhone4.Leave += new System.EventHandler(this.ControlFocusLeave);
            this.tbPPhone4.Enter += new System.EventHandler(this.tbPPhone4_Enter);
            // 
            // bNewPerson
            // 
            this.bNewPerson.BackColor = System.Drawing.Color.LightSteelBlue;
            this.bNewPerson.Enabled = false;
            this.bNewPerson.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.bNewPerson.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bNewPerson.Location = new System.Drawing.Point(715, 340);
            this.bNewPerson.Name = "bNewPerson";
            this.bNewPerson.Size = new System.Drawing.Size(190, 20);
            this.bNewPerson.TabIndex = 5;
            this.bNewPerson.Text = "New &Person  ";
            this.bNewPerson.Click += new System.EventHandler(this.bNewPerson_Click);
            // 
            // bDeletePerson
            // 
            this.bDeletePerson.BackColor = System.Drawing.Color.LightPink;
            this.bDeletePerson.Enabled = false;
            this.bDeletePerson.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.bDeletePerson.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bDeletePerson.Location = new System.Drawing.Point(715, 315);
            this.bDeletePerson.Name = "bDeletePerson";
            this.bDeletePerson.Size = new System.Drawing.Size(190, 20);
            this.bDeletePerson.TabIndex = 4;
            this.bDeletePerson.Text = "&Delete Person ";
            this.bDeletePerson.Click += new System.EventHandler(this.bDeletePerson_Click);
            // 
            // gbCustomer
            // 
            this.gbCustomer.Controls.Add(this.tbShortName);
            this.gbCustomer.Controls.Add(this.label27);
            this.gbCustomer.Controls.Add(this.label20);
            this.gbCustomer.Controls.Add(this.label19);
            this.gbCustomer.Controls.Add(this.label11);
            this.gbCustomer.Controls.Add(this.label2);
            this.gbCustomer.Controls.Add(this.bDeleteMembership);
            this.gbCustomer.Controls.Add(this.bIndustrySelect);
            this.gbCustomer.Controls.Add(this.prmCustomer);
            this.gbCustomer.Controls.Add(this.lbxIndustry);
            this.gbCustomer.Controls.Add(this.locCustomer);
            this.gbCustomer.Controls.Add(this.cCustomer);
            this.gbCustomer.Controls.Add(this.bUpdate);
            this.gbCustomer.Controls.Add(this.groupBox4);
            this.gbCustomer.Controls.Add(this.label6);
            this.gbCustomer.Controls.Add(this.tbStartDate);
            this.gbCustomer.Controls.Add(this.cbIndustry);
            this.gbCustomer.Controls.Add(this.cbBusiness);
            this.gbCustomer.Controls.Add(this.tbID);
            this.gbCustomer.Controls.Add(this.tbEmail);
            this.gbCustomer.Controls.Add(this.label5);
            this.gbCustomer.Controls.Add(this.label4);
            this.gbCustomer.Controls.Add(this.label3);
            this.gbCustomer.Controls.Add(this.tbCompany);
            this.gbCustomer.Controls.Add(this.tbFax3);
            this.gbCustomer.Controls.Add(this.tbFax2);
            this.gbCustomer.Controls.Add(this.tbFax1);
            this.gbCustomer.Controls.Add(this.tbFax4);
            this.gbCustomer.Controls.Add(this.tbPhone2);
            this.gbCustomer.Controls.Add(this.tbPhone1);
            this.gbCustomer.Controls.Add(this.tbPhone3);
            this.gbCustomer.Controls.Add(this.tbPhone4);
            this.gbCustomer.Enabled = false;
            this.gbCustomer.ForeColor = System.Drawing.Color.DimGray;
            this.gbCustomer.Location = new System.Drawing.Point(5, 25);
            this.gbCustomer.Name = "gbCustomer";
            this.gbCustomer.Size = new System.Drawing.Size(900, 250);
            this.gbCustomer.TabIndex = 2;
            this.gbCustomer.TabStop = false;
            this.gbCustomer.Text = "Customer";
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.label20.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label20.Location = new System.Drawing.Point(230, 20);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(120, 15);
            this.label20.TabIndex = 92;
            this.label20.Text = "ID";
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label19.Location = new System.Drawing.Point(230, 80);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(120, 15);
            this.label19.TabIndex = 91;
            this.label19.Text = "Industry Membership";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(230, 60);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(120, 15);
            this.label11.TabIndex = 90;
            this.label11.Text = "Business Type";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(9, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 15);
            this.label2.TabIndex = 89;
            this.label2.Text = "Company Name";
            // 
            // bDeleteMembership
            // 
            this.bDeleteMembership.BackColor = System.Drawing.Color.LightPink;
            this.bDeleteMembership.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.bDeleteMembership.ForeColor = System.Drawing.Color.DimGray;
            this.bDeleteMembership.Image = ((System.Drawing.Image)(resources.GetObject("bDeleteMembership.Image")));
            this.bDeleteMembership.Location = new System.Drawing.Point(490, 153);
            this.bDeleteMembership.Name = "bDeleteMembership";
            this.bDeleteMembership.Size = new System.Drawing.Size(20, 20);
            this.bDeleteMembership.TabIndex = 17;
            this.bDeleteMembership.Click += new System.EventHandler(this.bDeleteMembership_Click);
            // 
            // bIndustrySelect
            // 
            this.bIndustrySelect.BackColor = System.Drawing.Color.LightSteelBlue;
            this.bIndustrySelect.Image = ((System.Drawing.Image)(resources.GetObject("bIndustrySelect.Image")));
            this.bIndustrySelect.Location = new System.Drawing.Point(490, 75);
            this.bIndustrySelect.Name = "bIndustrySelect";
            this.bIndustrySelect.Size = new System.Drawing.Size(20, 20);
            this.bIndustrySelect.TabIndex = 15;
            this.bIndustrySelect.Click += new System.EventHandler(this.bIndustrySelect_Click);
            // 
            // prmCustomer
            // 
            this.prmCustomer.Location = new System.Drawing.Point(515, 15);
            this.prmCustomer.Name = "prmCustomer";
            this.prmCustomer.Size = new System.Drawing.Size(185, 230);
            this.prmCustomer.TabIndex = 19;
            this.prmCustomer.Enter += new System.EventHandler(this.prmCustomer_Enter);
            this.prmCustomer.Leave += new System.EventHandler(this.ControlFocusLeave);
            // 
            // lbxIndustry
            // 
            this.lbxIndustry.ItemHeight = 12;
            this.lbxIndustry.Location = new System.Drawing.Point(255, 96);
            this.lbxIndustry.Name = "lbxIndustry";
            this.lbxIndustry.ScrollAlwaysVisible = true;
            this.lbxIndustry.Size = new System.Drawing.Size(230, 76);
            this.lbxIndustry.TabIndex = 16;
            this.lbxIndustry.Leave += new System.EventHandler(this.ControlFocusLeave);
            this.lbxIndustry.Enter += new System.EventHandler(this.lbxIndustry_Enter);
            // 
            // locCustomer
            // 
            this.locCustomer.ForeColor = System.Drawing.Color.Black;
            this.locCustomer.Location = new System.Drawing.Point(10, 55);
            this.locCustomer.Name = "locCustomer";
            this.locCustomer.Size = new System.Drawing.Size(215, 108);
            this.locCustomer.TabIndex = 1;
            this.locCustomer.Enter += new System.EventHandler(this.locCustomer_Enter);
            this.locCustomer.Leave += new System.EventHandler(this.ControlFocusLeave);
            // 
            // cCustomer
            // 
            this.cCustomer.Location = new System.Drawing.Point(255, 180);
            this.cCustomer.Name = "cCustomer";
            this.cCustomer.Size = new System.Drawing.Size(230, 60);
            this.cCustomer.TabIndex = 18;
            this.cCustomer.Enter += new System.EventHandler(this.cCustomer_Enter);
            this.cCustomer.Leave += new System.EventHandler(this.ControlFocusLeave);
            // 
            // bUpdate
            // 
            this.bUpdate.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.bUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bUpdate.Location = new System.Drawing.Point(800, 215);
            this.bUpdate.Name = "bUpdate";
            this.bUpdate.Size = new System.Drawing.Size(90, 23);
            this.bUpdate.TabIndex = 25;
            this.bUpdate.Text = "&Update";
            this.bUpdate.Click += new System.EventHandler(this.bUpdate_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.gbRBs);
            this.groupBox4.Controls.Add(this.tbAccountNumber);
            this.groupBox4.Controls.Add(this.cbCarrier);
            this.groupBox4.Controls.Add(this.chbUseTheirAccount);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox4.Location = new System.Drawing.Point(705, 15);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(185, 170);
            this.groupBox4.TabIndex = 20;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Goods Movement";
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.label22.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label22.Location = new System.Drawing.Point(5, 150);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(60, 15);
            this.label22.TabIndex = 94;
            this.label22.Text = "Account #";
            // 
            // gbRBs
            // 
            this.gbRBs.Controls.Add(this.rbWeShip);
            this.gbRBs.Controls.Add(this.rbTheyCarry);
            this.gbRBs.Controls.Add(this.rbWeCarry);
            this.gbRBs.Location = new System.Drawing.Point(10, 15);
            this.gbRBs.Name = "gbRBs";
            this.gbRBs.Size = new System.Drawing.Size(165, 80);
            this.gbRBs.TabIndex = 0;
            this.gbRBs.TabStop = false;
            this.gbRBs.Enter += new System.EventHandler(this.gbRBs_Enter);
            this.gbRBs.Leave += new System.EventHandler(this.ControlFocusLeave);
            // 
            // rbWeShip
            // 
            this.rbWeShip.Location = new System.Drawing.Point(5, 50);
            this.rbWeShip.Name = "rbWeShip";
            this.rbWeShip.TabIndex = 3;
            this.rbWeShip.Text = "We Ship";
            this.rbWeShip.CheckedChanged += new System.EventHandler(this.rbWeShip_CheckedChanged);
            // 
            // rbTheyCarry
            // 
            this.rbTheyCarry.Location = new System.Drawing.Point(5, 30);
            this.rbTheyCarry.Name = "rbTheyCarry";
            this.rbTheyCarry.TabIndex = 2;
            this.rbTheyCarry.Text = "TheyCarry";
            // 
            // rbWeCarry
            // 
            this.rbWeCarry.Location = new System.Drawing.Point(5, 15);
            this.rbWeCarry.Name = "rbWeCarry";
            this.rbWeCarry.Size = new System.Drawing.Size(104, 15);
            this.rbWeCarry.TabIndex = 1;
            this.rbWeCarry.Text = "We Carry";
            // 
            // tbAccountNumber
            // 
            this.tbAccountNumber.Enabled = false;
            this.tbAccountNumber.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.tbAccountNumber.Location = new System.Drawing.Point(65, 145);
            this.tbAccountNumber.Name = "tbAccountNumber";
            this.tbAccountNumber.Size = new System.Drawing.Size(115, 20);
            this.tbAccountNumber.TabIndex = 3;
            this.tbAccountNumber.Text = "";
            this.tbAccountNumber.Leave += new System.EventHandler(this.ControlFocusLeave);
            this.tbAccountNumber.Enter += new System.EventHandler(this.tbAccountNumber_Enter);
            // 
            // cbCarrier
            // 
            this.cbCarrier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCarrier.Enabled = false;
            this.cbCarrier.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.cbCarrier.Location = new System.Drawing.Point(65, 120);
            this.cbCarrier.Name = "cbCarrier";
            this.cbCarrier.Size = new System.Drawing.Size(115, 20);
            this.cbCarrier.TabIndex = 2;
            this.cbCarrier.Leave += new System.EventHandler(this.ControlFocusLeave);
            this.cbCarrier.Enter += new System.EventHandler(this.cbCarrier_Enter);
            // 
            // chbUseTheirAccount
            // 
            this.chbUseTheirAccount.Enabled = false;
            this.chbUseTheirAccount.Location = new System.Drawing.Point(5, 105);
            this.chbUseTheirAccount.Name = "chbUseTheirAccount";
            this.chbUseTheirAccount.Size = new System.Drawing.Size(175, 15);
            this.chbUseTheirAccount.TabIndex = 1;
            this.chbUseTheirAccount.Text = "We use their account to ship";
            this.chbUseTheirAccount.Enter += new System.EventHandler(this.chbUseTheirAccount_Enter);
            this.chbUseTheirAccount.CheckedChanged += new System.EventHandler(this.chbUseTheirAccount_CheckedChanged);
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label21.Location = new System.Drawing.Point(5, 125);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(45, 15);
            this.label21.TabIndex = 93;
            this.label21.Text = "Carrier";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(230, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 15);
            this.label6.TabIndex = 88;
            this.label6.Text = "Start Date";
            // 
            // tbStartDate
            // 
            this.tbStartDate.Enabled = false;
            this.tbStartDate.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.tbStartDate.Location = new System.Drawing.Point(355, 35);
            this.tbStartDate.Name = "tbStartDate";
            this.tbStartDate.Size = new System.Drawing.Size(155, 20);
            this.tbStartDate.TabIndex = 12;
            this.tbStartDate.Text = "";
            this.tbStartDate.Leave += new System.EventHandler(this.ControlFocusLeave);
            this.tbStartDate.Enter += new System.EventHandler(this.tbStartDate_Enter);
            // 
            // cbIndustry
            // 
            this.cbIndustry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIndustry.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.cbIndustry.Items.AddRange(new object[] {
															"Rapoport",
															"JVC"});
            this.cbIndustry.Location = new System.Drawing.Point(355, 75);
            this.cbIndustry.Name = "cbIndustry";
            this.cbIndustry.Size = new System.Drawing.Size(130, 20);
            this.cbIndustry.TabIndex = 14;
            this.cbIndustry.Leave += new System.EventHandler(this.ControlFocusLeave);
            this.cbIndustry.Enter += new System.EventHandler(this.cbIndustry_Enter);
            // 
            // cbBusiness
            // 
            this.cbBusiness.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBusiness.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.cbBusiness.Location = new System.Drawing.Point(355, 55);
            this.cbBusiness.Name = "cbBusiness";
            this.cbBusiness.Size = new System.Drawing.Size(155, 20);
            this.cbBusiness.TabIndex = 13;
            this.cbBusiness.Leave += new System.EventHandler(this.ControlFocusLeave);
            this.cbBusiness.Enter += new System.EventHandler(this.cbBusiness_Enter);
            // 
            // tbID
            // 
            this.tbID.Enabled = false;
            this.tbID.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.tbID.Location = new System.Drawing.Point(355, 15);
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(155, 20);
            this.tbID.TabIndex = 11;
            this.tbID.Text = "";
            this.tbID.Leave += new System.EventHandler(this.ControlFocusLeave);
            this.tbID.Enter += new System.EventHandler(this.tbID_Enter);
            // 
            // tbEmail
            // 
            this.tbEmail.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.tbEmail.Location = new System.Drawing.Point(65, 220);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(155, 20);
            this.tbEmail.TabIndex = 10;
            this.tbEmail.Text = "";
            this.tbEmail.Leave += new System.EventHandler(this.ControlFocusLeave);
            this.tbEmail.Enter += new System.EventHandler(this.tbEmail_Enter);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(10, 225);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 15);
            this.label5.TabIndex = 88;
            this.label5.Text = "Email";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(10, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 15);
            this.label4.TabIndex = 88;
            this.label4.Text = "Fax";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(10, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 15);
            this.label3.TabIndex = 88;
            this.label3.Text = "Phone";
            // 
            // tbCompany
            // 
            this.tbCompany.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.tbCompany.Location = new System.Drawing.Point(106, 15);
            this.tbCompany.Name = "tbCompany";
            this.tbCompany.Size = new System.Drawing.Size(115, 20);
            this.tbCompany.TabIndex = 0;
            this.tbCompany.Text = "";
            this.tbCompany.Leave += new System.EventHandler(this.ControlFocusLeave);
            this.tbCompany.Enter += new System.EventHandler(this.tbCompany_Enter);
            // 
            // tbFax3
            // 
            this.tbFax3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.tbFax3.Location = new System.Drawing.Point(145, 195);
            this.tbFax3.MaxLength = 3;
            this.tbFax3.Name = "tbFax3";
            this.tbFax3.Size = new System.Drawing.Size(30, 20);
            this.tbFax3.TabIndex = 8;
            this.tbFax3.Text = "";
            this.tbFax3.TextChanged += new System.EventHandler(this.tbFax3_TextChanged);
            this.tbFax3.Leave += new System.EventHandler(this.ControlFocusLeave);
            this.tbFax3.Enter += new System.EventHandler(this.tbFax3_Enter);
            // 
            // tbFax2
            // 
            this.tbFax2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.tbFax2.Location = new System.Drawing.Point(110, 195);
            this.tbFax2.MaxLength = 3;
            this.tbFax2.Name = "tbFax2";
            this.tbFax2.Size = new System.Drawing.Size(30, 20);
            this.tbFax2.TabIndex = 7;
            this.tbFax2.Text = "";
            this.tbFax2.TextChanged += new System.EventHandler(this.tbFax2_TextChanged);
            this.tbFax2.Leave += new System.EventHandler(this.ControlFocusLeave);
            this.tbFax2.Enter += new System.EventHandler(this.tbFax2_Enter);
            // 
            // tbFax1
            // 
            this.tbFax1.Enabled = false;
            this.tbFax1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.tbFax1.Location = new System.Drawing.Point(65, 195);
            this.tbFax1.MaxLength = 4;
            this.tbFax1.Name = "tbFax1";
            this.tbFax1.Size = new System.Drawing.Size(35, 20);
            this.tbFax1.TabIndex = 6;
            this.tbFax1.Text = "+1";
            this.tbFax1.TextChanged += new System.EventHandler(this.tbFax1_TextChanged);
            this.tbFax1.Leave += new System.EventHandler(this.ControlFocusLeave);
            this.tbFax1.Enter += new System.EventHandler(this.tbFax1_Enter);
            // 
            // tbFax4
            // 
            this.tbFax4.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.tbFax4.Location = new System.Drawing.Point(180, 195);
            this.tbFax4.MaxLength = 4;
            this.tbFax4.Name = "tbFax4";
            this.tbFax4.Size = new System.Drawing.Size(40, 20);
            this.tbFax4.TabIndex = 9;
            this.tbFax4.Text = "";
            this.tbFax4.Leave += new System.EventHandler(this.ControlFocusLeave);
            this.tbFax4.Enter += new System.EventHandler(this.tbFax4_Enter);
            // 
            // tbPhone2
            // 
            this.tbPhone2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.tbPhone2.Location = new System.Drawing.Point(110, 170);
            this.tbPhone2.MaxLength = 3;
            this.tbPhone2.Name = "tbPhone2";
            this.tbPhone2.Size = new System.Drawing.Size(30, 20);
            this.tbPhone2.TabIndex = 3;
            this.tbPhone2.Text = "";
            this.tbPhone2.TextChanged += new System.EventHandler(this.tbPhone2_TextChanged);
            this.tbPhone2.Leave += new System.EventHandler(this.ControlFocusLeave);
            this.tbPhone2.Enter += new System.EventHandler(this.tbPhone2_Enter);
            // 
            // tbPhone1
            // 
            this.tbPhone1.Enabled = false;
            this.tbPhone1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.tbPhone1.Location = new System.Drawing.Point(65, 170);
            this.tbPhone1.MaxLength = 4;
            this.tbPhone1.Name = "tbPhone1";
            this.tbPhone1.Size = new System.Drawing.Size(35, 20);
            this.tbPhone1.TabIndex = 2;
            this.tbPhone1.Text = "+1";
            this.tbPhone1.TextChanged += new System.EventHandler(this.tbPhone1_TextChanged);
            this.tbPhone1.Leave += new System.EventHandler(this.ControlFocusLeave);
            this.tbPhone1.Enter += new System.EventHandler(this.tbPhone1_Enter);
            // 
            // tbPhone3
            // 
            this.tbPhone3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.tbPhone3.Location = new System.Drawing.Point(145, 170);
            this.tbPhone3.MaxLength = 3;
            this.tbPhone3.Name = "tbPhone3";
            this.tbPhone3.Size = new System.Drawing.Size(30, 20);
            this.tbPhone3.TabIndex = 4;
            this.tbPhone3.Text = "";
            this.tbPhone3.TextChanged += new System.EventHandler(this.tbPhone3_TextChanged);
            this.tbPhone3.Leave += new System.EventHandler(this.ControlFocusLeave);
            this.tbPhone3.Enter += new System.EventHandler(this.tbPhone3_Enter);
            // 
            // tbPhone4
            // 
            this.tbPhone4.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.tbPhone4.Location = new System.Drawing.Point(180, 170);
            this.tbPhone4.MaxLength = 4;
            this.tbPhone4.Name = "tbPhone4";
            this.tbPhone4.Size = new System.Drawing.Size(40, 20);
            this.tbPhone4.TabIndex = 5;
            this.tbPhone4.Text = "";
            this.tbPhone4.Leave += new System.EventHandler(this.ControlFocusLeave);
            this.tbPhone4.Enter += new System.EventHandler(this.tbPhone4_Enter);
            // 
            // bNewCustomer
            // 
            this.bNewCustomer.BackColor = System.Drawing.Color.LightSteelBlue;
            this.bNewCustomer.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.bNewCustomer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bNewCustomer.Location = new System.Drawing.Point(405, 5);
            this.bNewCustomer.Name = "bNewCustomer";
            this.bNewCustomer.Size = new System.Drawing.Size(200, 20);
            this.bNewCustomer.TabIndex = 0;
            this.bNewCustomer.Text = "&New Customer ";
            this.bNewCustomer.Click += new System.EventHandler(this.bNewCustomer_Click);
            // 
            // tbNewCustomer
            // 
            this.tbNewCustomer.Enabled = false;
            this.tbNewCustomer.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.tbNewCustomer.Location = new System.Drawing.Point(5, 5);
            this.tbNewCustomer.Name = "tbNewCustomer";
            this.tbNewCustomer.Size = new System.Drawing.Size(390, 20);
            this.tbNewCustomer.TabIndex = 1;
            this.tbNewCustomer.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.ForeColor = System.Drawing.Color.DimGray;
            this.tabPage2.Location = new System.Drawing.Point(19, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(912, 617);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Customer History";
            this.tabPage2.Enter += new System.EventHandler(this.tabPage2_Enter);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bLoadHistory);
            this.groupBox1.Controls.Add(this.ordersTree1);
            this.groupBox1.Controls.Add(this.rbAll);
            this.groupBox1.Controls.Add(this.rbClosed);
            this.groupBox1.Controls.Add(this.rbOpen);
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(890, 265);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Order History";
            // 
            // bLoadHistory
            // 
            this.bLoadHistory.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bLoadHistory.Location = new System.Drawing.Point(355, 20);
            this.bLoadHistory.Name = "bLoadHistory";
            this.bLoadHistory.TabIndex = 4;
            this.bLoadHistory.Text = "&Load";
            this.bLoadHistory.Click += new System.EventHandler(this.bLoadHistory_Click);
            // 
            // ordersTree1
            // 
            this.ordersTree1.CheckBoxes = true;
            this.ordersTree1.IsDocumentGhost = false;
            this.ordersTree1.IsExpand = false;
            this.ordersTree1.Location = new System.Drawing.Point(10, 45);
            this.ordersTree1.Name = "ordersTree1";
            this.ordersTree1.Selected = null;
            this.ordersTree1.ShowColorAndClarity = true;
            this.ordersTree1.Size = new System.Drawing.Size(875, 210);
            this.ordersTree1.TabIndex = 3;
            this.ordersTree1.Enter += new System.EventHandler(this.ordersTree1_Enter);
            this.ordersTree1.Leave += new System.EventHandler(this.ControlFocusLeave);
            // 
            // rbAll
            // 
            this.rbAll.Checked = true;
            this.rbAll.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.rbAll.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbAll.Location = new System.Drawing.Point(245, 20);
            this.rbAll.Name = "rbAll";
            this.rbAll.TabIndex = 2;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "all";
            // 
            // rbClosed
            // 
            this.rbClosed.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.rbClosed.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbClosed.Location = new System.Drawing.Point(130, 20);
            this.rbClosed.Name = "rbClosed";
            this.rbClosed.TabIndex = 1;
            this.rbClosed.Text = "closed";
            // 
            // rbOpen
            // 
            this.rbOpen.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.rbOpen.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbOpen.Location = new System.Drawing.Point(15, 20);
            this.rbOpen.Name = "rbOpen";
            this.rbOpen.TabIndex = 0;
            this.rbOpen.Text = "open";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ptrTree);
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Location = new System.Drawing.Point(19, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(912, 617);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Customer Prices";
            this.tabPage3.Enter += new System.EventHandler(this.tabPage3_Enter);
            // 
            // ptrTree
            // 
            this.ptrTree.Location = new System.Drawing.Point(5, 25);
            this.ptrTree.Name = "ptrTree";
            this.ptrTree.Size = new System.Drawing.Size(385, 325);
            this.ptrTree.TabIndex = 5;
            this.ptrTree.Changed += new System.EventHandler(this.ptrOps_SelectionChanged);
            this.ptrTree.Enter += new System.EventHandler(this.ptrTree_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnUpdateRanges);
            this.groupBox2.Controls.Add(this.btnDelRange);
            this.groupBox2.Controls.Add(this.btnAddRange);
            this.groupBox2.Controls.Add(this.rbUnfixed);
            this.groupBox2.Controls.Add(this.rbFixed);
            this.groupBox2.Controls.Add(this.gbFixed);
            this.groupBox2.Controls.Add(this.gbUnfixed);
            this.groupBox2.Location = new System.Drawing.Point(395, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(510, 345);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Type of price";
            // 
            // btnUpdateRanges
            // 
            this.btnUpdateRanges.Enabled = false;
            this.btnUpdateRanges.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnUpdateRanges.Location = new System.Drawing.Point(120, 100);
            this.btnUpdateRanges.Name = "btnUpdateRanges";
            this.btnUpdateRanges.Size = new System.Drawing.Size(95, 23);
            this.btnUpdateRanges.TabIndex = 8;
            this.btnUpdateRanges.Text = "Update";
            this.btnUpdateRanges.Visible = false;
            this.btnUpdateRanges.Click += new System.EventHandler(this.btnUpdateRanges_Click);
            // 
            // btnDelRange
            // 
            this.btnDelRange.Enabled = false;
            this.btnDelRange.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnDelRange.Location = new System.Drawing.Point(350, 100);
            this.btnDelRange.Name = "btnDelRange";
            this.btnDelRange.Size = new System.Drawing.Size(95, 23);
            this.btnDelRange.TabIndex = 7;
            this.btnDelRange.Text = "Delete Range";
            this.btnDelRange.Click += new System.EventHandler(this.btnDelRange_Click);
            // 
            // btnAddRange
            // 
            this.btnAddRange.Enabled = false;
            this.btnAddRange.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnAddRange.Location = new System.Drawing.Point(220, 100);
            this.btnAddRange.Name = "btnAddRange";
            this.btnAddRange.Size = new System.Drawing.Size(95, 23);
            this.btnAddRange.TabIndex = 6;
            this.btnAddRange.Text = "Add Range";
            this.btnAddRange.Click += new System.EventHandler(this.btnAddRange_Click);
            // 
            // rbUnfixed
            // 
            this.rbUnfixed.Enabled = false;
            this.rbUnfixed.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.rbUnfixed.Location = new System.Drawing.Point(10, 105);
            this.rbUnfixed.Name = "rbUnfixed";
            this.rbUnfixed.Size = new System.Drawing.Size(104, 20);
            this.rbUnfixed.TabIndex = 5;
            this.rbUnfixed.Text = "Unfixed";
            this.rbUnfixed.CheckedChanged += new System.EventHandler(this.rbUnfixed_CheckedChanged);
            // 
            // rbFixed
            // 
            this.rbFixed.Checked = true;
            this.rbFixed.Enabled = false;
            this.rbFixed.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.rbFixed.Location = new System.Drawing.Point(10, 20);
            this.rbFixed.Name = "rbFixed";
            this.rbFixed.Size = new System.Drawing.Size(110, 20);
            this.rbFixed.TabIndex = 4;
            this.rbFixed.TabStop = true;
            this.rbFixed.Text = "Fixed";
            this.rbFixed.CheckedChanged += new System.EventHandler(this.rbFixed_CheckedChanged);
            // 
            // gbFixed
            // 
            this.gbFixed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gbFixed.Controls.Add(this.lbFixedCaratPrice);
            this.gbFixed.Controls.Add(this.label1);
            this.gbFixed.Controls.Add(this.label18);
            this.gbFixed.Controls.Add(this.tbFixedP);
            this.gbFixed.Controls.Add(this.rbFixedP);
            this.gbFixed.Controls.Add(this.label17);
            this.gbFixed.Controls.Add(this.tbFixedB);
            this.gbFixed.Controls.Add(this.rbFixedB);
            this.gbFixed.ForeColor = System.Drawing.Color.DimGray;
            this.gbFixed.Location = new System.Drawing.Point(10, 40);
            this.gbFixed.Name = "gbFixed";
            this.gbFixed.Size = new System.Drawing.Size(495, 55);
            this.gbFixed.TabIndex = 2;
            this.gbFixed.Enter += new System.EventHandler(this.gbFixed_Enter);
            this.gbFixed.Leave += new System.EventHandler(this.gbFixed_Leave);
            // 
            // lbFixedCaratPrice
            // 
            this.lbFixedCaratPrice.Location = new System.Drawing.Point(118, 35);
            this.lbFixedCaratPrice.Name = "lbFixedCaratPrice";
            this.lbFixedCaratPrice.Size = new System.Drawing.Size(82, 15);
            this.lbFixedCaratPrice.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(20, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "fixed";
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label18.Location = new System.Drawing.Point(443, 35);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(15, 15);
            this.label18.TabIndex = 5;
            this.label18.Text = "%";
            // 
            // tbFixedP
            // 
            this.tbFixedP.Enabled = false;
            this.tbFixedP.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.tbFixedP.Location = new System.Drawing.Point(337, 30);
            this.tbFixedP.Name = "tbFixedP";
            this.tbFixedP.Size = new System.Drawing.Size(95, 20);
            this.tbFixedP.TabIndex = 4;
            this.tbFixedP.Text = "";
            // 
            // rbFixedP
            // 
            this.rbFixedP.Location = new System.Drawing.Point(337, 10);
            this.rbFixedP.Name = "rbFixedP";
            this.rbFixedP.Size = new System.Drawing.Size(15, 24);
            this.rbFixedP.TabIndex = 3;
            // 
            // label17
            // 
            this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label17.Location = new System.Drawing.Point(315, 35);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(15, 15);
            this.label17.TabIndex = 2;
            this.label17.Text = "$";
            // 
            // tbFixedB
            // 
            this.tbFixedB.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.tbFixedB.Location = new System.Drawing.Point(205, 30);
            this.tbFixedB.Name = "tbFixedB";
            this.tbFixedB.TabIndex = 1;
            this.tbFixedB.Text = "";
            // 
            // rbFixedB
            // 
            this.rbFixedB.Checked = true;
            this.rbFixedB.Location = new System.Drawing.Point(205, 10);
            this.rbFixedB.Name = "rbFixedB";
            this.rbFixedB.Size = new System.Drawing.Size(15, 24);
            this.rbFixedB.TabIndex = 0;
            this.rbFixedB.TabStop = true;
            this.rbFixedB.CheckedChanged += new System.EventHandler(this.rbFixedB_CheckedChanged);
            // 
            // gbUnfixed
            // 
            this.gbUnfixed.AutoScroll = true;
            this.gbUnfixed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gbUnfixed.Controls.Add(this.price1);
            this.gbUnfixed.Enabled = false;
            this.gbUnfixed.ForeColor = System.Drawing.Color.DimGray;
            this.gbUnfixed.Location = new System.Drawing.Point(10, 125);
            this.gbUnfixed.Name = "gbUnfixed";
            this.gbUnfixed.Size = new System.Drawing.Size(495, 215);
            this.gbUnfixed.TabIndex = 3;
            this.gbUnfixed.Enter += new System.EventHandler(this.gbUnfixed_Enter);
            this.gbUnfixed.Leave += new System.EventHandler(this.gbUnfixed_Leave);
            // 
            // price1
            // 
            this.price1.Location = new System.Drawing.Point(10, 5);
            this.price1.Name = "price1";
            this.price1.Size = new System.Drawing.Size(455, 45);
            this.price1.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.label13.Location = new System.Drawing.Point(15, 10);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(200, 15);
            this.label13.TabIndex = 1;
            this.label13.Text = "Avaliable Operations with prices";
            // 
            // cbcCustomer
            // 
            this.cbcCustomer.DefaultText = "Customer Lookup";
            this.cbcCustomer.DisplayMember = "CustomerName";
            this.cbcCustomer.InsertDefaultRow = true;
            this.cbcCustomer.Location = new System.Drawing.Point(25, 2);
            this.cbcCustomer.Name = "cbcCustomer";
            this.cbcCustomer.SelectedCode = "";
            this.cbcCustomer.Size = new System.Drawing.Size(445, 23);
            this.cbcCustomer.TabIndex = 0;
            this.cbcCustomer.ValueMember = "CustomerOfficeID_CustomerID";
            this.cbcCustomer.Enter += new System.EventHandler(this.cbcCustomer_Enter);
            this.cbcCustomer.SelectionChanged += new System.EventHandler(this.cbcCustomer_SelectedIndexChanged);
            this.cbcCustomer.Leave += new System.EventHandler(this.ControlFocusLeave);
            this.cbcCustomer.SelectedIndexChanged += new System.EventHandler(this.cbcCustomer_SelectedIndexChanged);
            // 
            // label27
            // 
            this.label27.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.label27.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label27.Location = new System.Drawing.Point(9, 40);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(90, 15);
            this.label27.TabIndex = 93;
            this.label27.Text = "Short Name";
            // 
            // tbShortName
            // 
            this.tbShortName.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.tbShortName.Location = new System.Drawing.Point(106, 35);
            this.tbShortName.Name = "tbShortName";
            this.tbShortName.Size = new System.Drawing.Size(115, 20);
            this.tbShortName.TabIndex = 94;
            this.tbShortName.Text = "";
            // 
            // NewCustomer
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.ClientSize = new System.Drawing.Size(944, 688);
            this.Controls.Add(this.cbcCustomer);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.sbStatus);
            this.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "NewCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Creation";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.gbPerson.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.gbCustomer.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.gbRBs.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.gbFixed.ResumeLayout(false);
            this.gbUnfixed.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private DataSet dsCustomerTypeEx;
        private DataTable dtPerson;
        private DataTable dtCustomer;
        private DataTable dtCustBiz;
        private DataTable dtCustInd;
        private DataTable dtCarrier;
        private DataTable dtStates;
        private DataTable dtPositions;
        private DataSet dsOpsPrcs;
        private DataSet dsAllCaratRanges;
        private DataSet dsCustomerPrices;
        private bool IsFixedPrice = true;
        private DataSet dsOTGRP;
        private DataSet dsCOGP;
        private int PrevOTGID = 0;
        private int AccessLevel;
        private bool IsNewPerson = false;
        private bool IsNewCustomer = false;

        //Constructor
        public NewCustomer()
        {
            InitializeComponent();
            InitCustomers();
            InitGlobal();

            locCustomer.CountryChanged += new EventHandler(tbCountry_TextChanged);
            locPerson.CountryChanged += new EventHandler(locPerson_CountryChanged);

            cbcCustomer.Focus();
        }

        public NewCustomer(int AccessLevel, char action)
        {
            this.AccessLevel = AccessLevel;
            InitializeComponent();
            InitCustomers();
            InitGlobal();

            if (action == 'c')
                bNewCustomer_Click(this, EventArgs.Empty);

            cbcCustomer.Enabled = false;
        }

        public NewCustomer(int AccessLevel, string custID)
        {
            this.AccessLevel = AccessLevel;
            InitializeComponent();
            InitCustomers();
            InitGlobal();

            ClearCustomerPanelFields();
            ClearCustomerPanelFields();

            GetType(custID);

            chbPLocationSame.Checked = true;
            //FillCustomer();
            //FillPersons(custID);
            DataTable dtCustomers = Service.GetCustomers().Tables["Customers"];
            cbcCustomer.SelectedCode = dtCustomers.Select("CustomerOfficeID_CustomerID='" + custID + "'")[0]["CustomerCode"].ToString();
            bNewPerson_Click(this, EventArgs.Empty);
            tbPFirstName.Focus();
            cbPPosition.SelectedValue = "1";
            gbCustomer.Enabled = false;
            gbPerson.Enabled = true;
            liPersons.Enabled = false;
            bDeletePerson.Enabled = false;
            bNewCustomer.Enabled = false;
            cbcCustomer.Enabled = false;

            //InitOpsTree();
        }

        public NewCustomer(int AccessLevel)
        {
            this.AccessLevel = AccessLevel;

            InitializeComponent();
            InitCustomers();
            InitGlobal();

            locCustomer.CountryChanged += new EventHandler(tbCountry_TextChanged);
            locPerson.CountryChanged += new EventHandler(locPerson_CountryChanged);

            cbcCustomer.Focus();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //		[STAThread]
        //		public static void Main() 
        //		{
        //			Application.Run(new NewCustomer());			
        //		}


        #region CustomerTab
        private void cbcCustomer_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            IsNewCustomer = false;

            sbStatus.Text = "Loading customer info";
            this.Cursor = Cursors.WaitCursor;

            ClearCustomerPanelFields();
            ClearCustomerPanelFields();
            ClearPersonPanelFields();
            ClearOrdersTree();
            ClearPrices();
            ptrTree.Clear();
            liPersons.Items.Clear();

            if (cbcCustomer.SelectedCode.ToString() == "0")
            {
                bUpdate.Enabled = false;
                bNewPerson.Enabled = false;
                bPUpdate.Enabled = false;
                return;
            }

            string sCustomerOfficeID = cbcCustomer.SelectedID.Split('_')[0];
            Service.SetDepartmentOfficeId(sCustomerOfficeID);

            bDeletePerson.Enabled = false;
            bNewPerson.Enabled = true;
            bUpdate.Enabled = true;

            GetType(cbcCustomer.ComboField.drvSelectedItem[cbcCustomer.ValueMember].ToString());
            ClearCustomerPanelFields();

            bUpdate.Enabled = true;
            gbCustomer.Enabled = true;
            gbPerson.Enabled = false;
            FillCustomer();
            FillPersons(cbcCustomer.SelectedID);
            tbCompany.Focus();

            dsOpsPrcs = Service.GetOperationsTree(cbcCustomer.ComboField.drvSelectedItem[cbcCustomer.ValueMember].ToString());

            dsCOGP = dsOpsPrcs.Copy();
            dsCOGP.Tables[0].TableName = "COGP";

            dsOpsPrcs.Tables["COGPByCustomer"].Columns["OperationTypeGroupParentID"].ColumnName = "ParentID";
            dsOpsPrcs.Tables["COGPByCustomer"].Columns["OperationTypeGroupID"].ColumnName = "ID";
            dsOpsPrcs.Tables["COGPByCustomer"].Columns["OperationTypeGroupName"].ColumnName = "Name";

            try
            {
                ptrTree.Initialize(dsOpsPrcs.Tables["COGPByCustomer"]);
            }
            catch (Exception exc)
            {
            }

            string s = cbcCustomer.ComboField.drvSelectedItem[cbcCustomer.ValueMember].ToString();
            dsCustomerPrices = Service.GetCOGRPByCustomer(s);

            //System.Diagnostics.Trace.WriteLine("CustomerPrices");
            //gemoDream.Service.debug_DiaspalyDataSet(dsCustomerPrices);

            InitPrices();

            if (lbxIndustry.Items.Count == 1)
                bDeleteMembership.Enabled = true;

            this.Cursor = Cursors.Default;
            sbStatus.Text = "Ready";
        }

        private void GetType(string id)
        {
            DataSet dsTemp = new DataSet();
            DataTable dtTemp = dsCustomerTypeEx.Tables[0].Copy();

            dsTemp.Tables.Add(dtTemp);
            dsTemp.Tables[0].TableName = "CustomerType";
            dsTemp.Tables[0].Rows.Add(new object[] { id, null, null });

            DataSet dsCustomerInfo = new DataSet();
            dsCustomerInfo.Tables.Add(dsTemp.Tables["CustomerType"].Copy());
            dsCustomerInfo.Tables[0].TableName = "Customer";

            try
            {
                dtCustomer = Service.GetCustomerType(dsCustomerInfo).Tables[0];
            }
            catch (Exception exc)
            {
                MessageBox.Show("Unable to get data from server. Reason: " + exc.Message,
                    "Data transfer error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            try
            {
                DataSet dsPersons = Service.GetPersonsByCustomer(dsCustomerInfo);
                dtPerson = dsPersons.Tables[0];
            }
            catch
            {
                MessageBox.Show("Unable to receive persons records", "Data transfer error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        //Customers list & selected customer info
        #region CustomerInfo

        #region InitCustomer
        public void InitCustomers()
        {
            DataTable dtCustomers = Service.GetCustomers().Tables[0];
            cbcCustomer.Initialize(dtCustomers);
        }

        private void InitGlobal()
        {
            this.Text = Service.sProgramTitle + "Customer Creation and Maintenance";
            dsCustomerTypeEx = Service.GetCustomerTypeEx();

            dtCarrier = dsCustomerTypeEx.Tables["Carriers"].Copy();
            dtCustBiz = dsCustomerTypeEx.Tables["BusinessTypes"].Copy();
            dtCustInd = dsCustomerTypeEx.Tables["IndustryMemberships"].Copy();
            dtStates = dsCustomerTypeEx.Tables["USStates"].Copy();
            dtPositions = dsCustomerTypeEx.Tables["Positions"].Copy();

            cbBusiness.DataSource = dtCustBiz.Copy();
            cbBusiness.ValueMember = "BusinessTypeID";
            cbBusiness.DisplayMember = "BusinessTypeName";

            cbPPosition.DataSource = dtPositions.Copy();
            cbPPosition.ValueMember = "PositionID";
            cbPPosition.DisplayMember = "PositionName";

            cbIndustry.DataSource = dtCustInd;
            cbIndustry.ValueMember = "IndustryMembershipID";
            cbIndustry.DisplayMember = "IndustryMembershipName";

            cbCarrier.DataSource = dtCarrier.Copy();
            cbCarrier.ValueMember = "CarrierID";
            cbCarrier.DisplayMember = "CarrierName";

            locCustomer.cbState.DataSource = dtStates.Copy();
            locCustomer.cbState.ValueMember = "USStateID";
            locCustomer.cbState.DisplayMember = "USStateName";

            locPerson.cbState.DataSource = dtStates.Copy();
            locPerson.cbState.ValueMember = "USStateID";
            locPerson.cbState.DisplayMember = "USStateName";

            for (int i = 1; i < dsCustomerTypeEx.Tables.Count; i++)
                dsCustomerTypeEx.Tables.RemoveAt(i);
        }

        private void InitPrices()
        {
            //if (!bNewCustomer)
            //{
            string s = cbcCustomer.SelectedID;

            char cSeparator = '_';
            string[] sIDs = s.Split(cSeparator);

            string sCID = sIDs[1];
            string sCOID = sIDs[0];

            dsAllCaratRanges = Service.GetCaratRanges(sCID, sCOID);
            dsAllCaratRanges.Tables[0].Columns.Add("State");

            //Operations-Prices

            InitOpsTree();

            dsOpsPrcs = Service.GetOperationsTree(cbcCustomer.ComboField.drvSelectedItem[cbcCustomer.ValueMember].ToString());

            dsOpsPrcs.Tables["COGPByCustomer"].Columns["OperationTypeGroupParentID"].ColumnName = "ParentID";
            dsOpsPrcs.Tables["COGPByCustomer"].Columns["OperationTypeGroupID"].ColumnName = "ID";
            dsOpsPrcs.Tables["COGPByCustomer"].Columns["OperationTypeGroupName"].ColumnName = "Name";

            try
            {
                ptrTree.Initialize(dsOpsPrcs.Tables["COGPByCustomer"]);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Unable to connect to server. Reason: " + exc.Message, "Internal Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                if (dsOpsPrcs.Tables["COGPByCustomer"].Rows[0]["IsFixedPrice"].ToString() == "1")
                    rbFixed.Checked = true;
            }
            catch { }

            dsOTGRP = Service.GetOperationTypeGroupRangePrices();
        }
        private void InitCustomerData(int sCustomerID)
        {
            /*
                        dtCustomer = new DataTable();
                        dtCustomer.Columns.Add("ID");
                        dtCustomer.Columns.Add("CompanyName");
                        dtCustomer.Columns.Add("Address1");
                        dtCustomer.Columns.Add("Address2");
                        dtCustomer.Columns.Add("Country");
                        dtCustomer.Columns.Add("City");
                        dtCustomer.Columns.Add("State");			
                        dtCustomer.Columns.Add("Zip1");
                        dtCustomer.Columns.Add("Zip2");
                        dtCustomer.Columns.Add("Phone");
                        dtCustomer.Columns.Add("Fax");
                        dtCustomer.Columns.Add("Email");
                        dtCustomer.Columns.Add("StartDate");
                        dtCustomer.Columns.Add("Business");
                        dtCustomer.Columns.Add("Industry");
                        dtCustomer.Columns.Add("Communication");			
                        dtCustomer.Columns.Add("Permissions");			
                        dtCustomer.Columns.Add("WeCarry");
                        dtCustomer.Columns.Add("TheyCarry");
                        dtCustomer.Columns.Add("WeShipCarry");
                        dtCustomer.Columns.Add("UseTheirAccount");
                        dtCustomer.Columns.Add("Carrier");
                        dtCustomer.Columns.Add("Account");

                        dtCustomer.Rows.Add(new object[] {"id1",
                                                             "cmn1",
                                                             "addr1",
                                                             "floor1",
                                                             "USA",
                                                             "city1",
                                                             "stt1",												 
                                                             "zip1",
                                                             "zip2",
                                                             "phn1",
                                                             "phnext",
                                                             "fx1",
                                                             "eml1",
                                                             "strt1",
                                                             "bsns1",
                                                             "JVC",
                                                             "f1p1m0e0",
                                                             "0,3,4,5,7",
                                                             false,
                                                             true,
                                                             true,
                                                             "crr1",
                                                             "accnt1"});
            */
        }

        private void FillCustomer()
        {
            tbCompany.Text = dtCustomer.Rows[0]["CompanyName"].ToString();
            tbShortName.Text = dtCustomer.Rows[0]["ShortName"].ToString();
            tbID.Text = dtCustomer.Rows[0]["CustomerCode"].ToString();
            locCustomer.tbAddress.Text = dtCustomer.Rows[0]["Address1"].ToString();
            locCustomer.tbAdditional.Text = dtCustomer.Rows[0]["Address2"].ToString();
            locCustomer.tbCity.Text = dtCustomer.Rows[0]["City"].ToString();
            try
            {
                locCustomer.cbState.SelectedValue = Convert.ToInt32(dtCustomer.Rows[0]["USStateID"]);
            }
            catch
            {
                locCustomer.cbState.Enabled = false;
            }
            locCustomer.tbZip1.Text = dtCustomer.Rows[0]["Zip1"].ToString();
            locCustomer.tbZip2.Text = dtCustomer.Rows[0]["Zip2"].ToString();
            locCustomer.tbCountry.Text = dtCustomer.Rows[0]["Country"].ToString();

            tbPhone1.Text = dtCustomer.Rows[0]["CountryPhoneCode"].ToString();
            tbPhone2.Text = dtCustomer.Rows[0]["Phone"].ToString().Substring(0, 3);
            tbPhone3.Text = dtCustomer.Rows[0]["Phone"].ToString().Substring(3, 3);
            tbPhone4.Text = dtCustomer.Rows[0]["Phone"].ToString().Substring(6, dtCustomer.Rows[0]["Phone"].ToString().Length - 6);

            if (dtCustomer.Rows[0]["Fax"].ToString().Length > 0)
            {
                tbFax1.Text = dtCustomer.Rows[0]["CountryPhoneCode"].ToString();
                tbFax2.Text = dtCustomer.Rows[0]["Fax"].ToString().Substring(0, 3);
                tbFax3.Text = dtCustomer.Rows[0]["Fax"].ToString().Substring(3, 3);
                tbFax4.Text = dtCustomer.Rows[0]["Fax"].ToString().Substring(6, dtCustomer.Rows[0]["Fax"].ToString().Length - 6);
            }

            tbEmail.Text = dtCustomer.Rows[0]["Email"].ToString();
            tbStartDate.Text = dtCustomer.Rows[0]["CreateDate"].ToString();

            cbBusiness.SelectedValue = Convert.ToInt32(dtCustomer.Rows[0]["BusinessTypeID"]);
            DataRow dr;
            lbxIndustry.Items.Clear();
            for (int i = 0; i < dtCustomer.Rows[0]["IndustryMembership"].ToString().Length; i++)
            {
                char ch = Convert.ToChar(dtCustomer.Rows[0]["IndustryMembership"].ToString().Substring(i, 1));
                try
                {
                    Convert.ToInt32(ch);
                    dr = dtCustInd.Select("IndustryMembershipID=" + ch)[0];
                    string Name = dr["IndustryMembershipName"].ToString();
                    lbxIndustry.Items.Add(Name);
                }
                catch
                {
                    continue;
                }
            }

            //cbIndustry.SelectedIndex = Convert.ToInt32(dtCustomer.Rows[0]["IndustryMembershipID"]);

            try
            {
                cbCarrier.SelectedValue = Convert.ToInt32(dtCustomer.Rows[0]["CarrierID"]);
            }
            catch { }

            try
            {
                locCustomer.cbState.SelectedValue = Convert.ToInt32(dtCustomer.Rows[0]["USStateID"]);
            }
            catch { }


            //IndustryMembership
            //IndMem(dtCustomer.Rows[0]["IndustryMembership"].ToString());

            //Communication
            CommunicationInit(dtCustomer.Rows[0]["Communication"].ToString(), cCustomer);

            //Permissions
            PermInit(dtCustomer.Rows[0]["Permission"].ToString(), prmCustomer);

            rbWeCarry.Checked = Convert.ToBoolean(dtCustomer.Rows[0]["WeCarry"]);
            rbTheyCarry.Checked = Convert.ToBoolean(dtCustomer.Rows[0]["TheyCarry"]);
            rbWeShip.Checked = Convert.ToBoolean(dtCustomer.Rows[0]["WeShipCarry"]);

            try
            {
                chbUseTheirAccount.Checked = Convert.ToBoolean(dtCustomer.Rows[0]["UseTheirAccount"]);
                cbCarrier.SelectedValue = Convert.ToInt32(dtCustomer.Rows[0]["CarrierID"]);
                tbAccountNumber.Text = dtCustomer.Rows[0]["Account"].ToString();
            }
            catch { }
        }

        private void ClearCustomerPanelFields()
        {
            prmCustomer.ClearChecks();
            tbCompany.Text = "";
            tbShortName.Text = "";
            locCustomer.ClearFields();
            tbPhone2.Text = "";
            tbPhone3.Text = "";
            tbPhone4.Text = "";
            tbFax2.Text = "";
            tbFax3.Text = "";
            tbFax4.Text = "";
            tbEmail.Text = "";
            tbID.Text = "";
            tbStartDate.Text = "";
            cbBusiness.Text = "";
            lbxIndustry.Items.Clear();
            cCustomer.ClearChecks();
            prmCustomer.ClearChecks();
            rbTheyCarry.Checked = false;
            tbAccountNumber.Text = "";
            cbBusiness.SelectedIndex = -1;
            cbIndustry.SelectedIndex = -1;
            locCustomer.cbState.SelectedIndex = -1;
            cbCarrier.SelectedIndex = -1;
        }

        private void ClearOrdersTree()
        {
            ordersTree1.Clear();
        }

        private void ClearPrices()
        {
            foreach (Control cntrl in gbUnfixed.Controls)
            {
                ((Price)cntrl).tbBuck.Text = "";
                ((Price)cntrl).tbPercent.Text = "";
                ((Price)cntrl).rbUnfixed01B.Checked = true;
                tbFixedB.Text = "";
                tbFixedP.Text = "";
                rbFixed.Checked = true;
            }
        }

        private void bNewCustomer_Click(object sender, System.EventArgs e)
        {
            IsNewCustomer = true;

            ClearCustomerPanelFields();
            ClearCustomerPanelFields();
            ClearPersonPanelFields();
            liPersons.Items.Clear();

            DataSet dsNewCust = new DataSet();
            dsNewCust.Tables.Add("CustomerTypeOf");
            dsNewCust = Service.GetCustomerType(dsNewCust);
            dtCustomer = dsNewCust.Tables[0].Copy();
            dtCustomer.Rows.Add(dtCustomer.NewRow());
            //InitGlobal();

            gbCustomer.Enabled = true;

            //locCustomer.cbState.DataSource = dtStates;
            //locCustomer.cbState.ValueMember = "USStateID";
            //locCustomer.cbState.DisplayMember = "USStateName";			

            dsCustomerPrices = Service.GetCOGRPTypeOf();
            dsCOGP = Service.GetCOGPTypeOf();
            dsCOGP.Tables[0].TableName = "COGP";
            Service.SetDepartmentOfficeId("0");
        }

        #endregion InitCustomer

        #region CustomerHandlers
        private void chbUseTheirAccount_CheckedChanged(object sender, System.EventArgs e)
        {
            cbCarrier.Enabled = chbUseTheirAccount.Checked;
            tbAccountNumber.Enabled = chbUseTheirAccount.Checked;
        }

        private void rbWeShip_CheckedChanged(object sender, System.EventArgs e)
        {
            chbUseTheirAccount.Enabled = rbWeShip.Checked;
            chbUseTheirAccount.Checked = rbWeShip.Checked;
            if (rbWeShip.Checked)
            {
                chbUseTheirAccount.Checked = false;
                chbUseTheirAccount_CheckedChanged(this, EventArgs.Empty);
            }
        }

        #region IndustryMembership
        private void bIndustrySelect_Click(object sender, System.EventArgs e)
        {
            bool bExists = false;
            for (int i = 0; i < lbxIndustry.Items.Count; i++)
                if (cbIndustry.Text == lbxIndustry.Items[i].ToString() && lbxIndustry.Items[i].ToString() != "")
                    bExists = true;
            if (cbIndustry.Text == "")
            {
                MessageBox.Show("One of the memberships must be chosen to add. You should select one membership type and click blue button to add selected membership to the list", "No items selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbIndustry.Focus();
                return;
            }

            if (!bExists)
                lbxIndustry.Items.Add(cbIndustry.Text);
            else
                MessageBox.Show("Selected item already exists in the list.", "Already exists",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            bDeleteMembership.Enabled = true;
        }

        private void bDeleteMembership_Click(object sender, System.EventArgs e)
        {
            if (lbxIndustry.SelectedIndex != -1)
                if (MessageBox.Show("Are you sure you want to delete this membership?",
                    "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    lbxIndustry.Items.RemoveAt(lbxIndustry.SelectedIndex);

            if (lbxIndustry.Items.Count == 0)
                bDeleteMembership.Enabled = false;
        }
        #endregion IndustryMembership

        #endregion CustomerHandlers

        #region UpdateCustomer
        private void bUpdate_Click(object sender, System.EventArgs e)
        {
            tbID.Enabled = false;
            sbStatus.Text = "Updating customer's information";
            this.Cursor = Cursors.WaitCursor;

            string wrongField = "One of the fields was filled wrong";

            if (FieldsOK(ref wrongField))
            {
                Service.SetDepartmentOfficeId("0");
                DataSet dsID = UpdateCustom();
                if (dsID == null)
                {
                    this.Cursor = Cursors.Default;
                    sbStatus.Text = "Update failed";
                    return;
                }

                UpdateCustomerPrices();
                InitCustomers();
                if (MessageBox.Show("Customer is saved, Do you want to continue to work with this customer?",
                    "Customer was saved successfully", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                    DialogResult.Yes)
                {
                    for (int i = 0; i < cbcCustomer.ComboField.cbField.Items.Count; i++)
                    {
                        if (((DataRowView)cbcCustomer.ComboField.cbField.Items[i])[1].ToString() == dsID.Tables[0].Rows[0]["Id"].ToString())
                        {
                            cbcCustomer.ComboField.cbField.SelectedIndex = i;
                            break;
                        }
                    }
                    //cbcCustomer.ComboField.cbField.SelectedValue = dsID.Tables[0].Rows[0]["Id"].ToString();
                }
                else
                {
                    cbcCustomer.Clear();
                    cbcCustomer.TextField.Text = "";
                    ClearCustomerPanelFields();
                    ClearOrdersTree();
                    ClearPersonPanelFields();
                    liPersons.Items.Clear();
                    bNewPerson.Enabled = false;
                    ClearPrices();
                    gbCustomer.Enabled = false;
                }
            }
            else
                MessageBox.Show(wrongField,
                    "Prohibited field value", MessageBoxButtons.OK, MessageBoxIcon.Error);

            this.Cursor = Cursors.Default;
            sbStatus.Text = "Ready";
        }

        private DataSet UpdateCustom()
        {
            dtCustomer.Rows[0]["CompanyName"] =
                Convert.ChangeType(tbCompany.Text, dtCustomer.Columns["CompanyName"].DataType);
            /**/
            dtCustomer.Rows[0]["ShortName"] =
                    Convert.ChangeType(tbShortName.Text, dtCustomer.Columns["ShortName"].DataType);
            dtCustomer.Rows[0]["CustomerCode"] = DBNull.Value;

            dtCustomer.Rows[0]["Address1"] =
                Convert.ChangeType(locCustomer.tbAddress.Text, dtCustomer.Columns["Address1"].DataType);
            dtCustomer.Rows[0]["Address2"] =
                Convert.ChangeType(locCustomer.tbAdditional.Text, dtCustomer.Columns["Address2"].DataType);
            dtCustomer.Rows[0]["City"] =
                Convert.ChangeType(locCustomer.tbCity.Text, dtCustomer.Columns["City"].DataType);
            if (locCustomer.cbState.SelectedValue != null)
            {
                dtCustomer.Rows[0]["USStateID"] =
                    Convert.ChangeType(locCustomer.cbState.SelectedValue, dtCustomer.Columns["USStateID"].DataType);
            }
            else
                dtCustomer.Rows[0]["USStateID"] = DBNull.Value;
            dtCustomer.Rows[0]["Zip1"] =
                Convert.ChangeType(locCustomer.tbZip1.Text, dtCustomer.Columns["Zip1"].DataType);
            try
            {
                dtCustomer.Rows[0]["Zip2"] =
                    Convert.ChangeType(locCustomer.tbZip2.Text, dtCustomer.Columns["Zip2"].DataType);
            }
            catch { }
            dtCustomer.Rows[0]["Country"] =
                Convert.ChangeType(locCustomer.tbCountry.Text, dtCustomer.Columns["Country"].DataType);

            dtCustomer.Rows[0]["CountryPhoneCode"] =
                Convert.ChangeType(tbPhone1.Text, dtCustomer.Columns["CountryPhoneCode"].DataType);
            dtCustomer.Rows[0]["Phone"] =
                Convert.ChangeType(tbPhone2.Text + tbPhone3.Text + tbPhone4.Text, dtCustomer.Columns["Phone"].DataType);

            dtCustomer.Rows[0]["CountryFaxCode"] =
                Convert.ChangeType(tbFax1.Text, dtCustomer.Columns["CountryPhoneCode"].DataType);
            dtCustomer.Rows[0]["Fax"] =
                Convert.ChangeType(tbFax2.Text + tbFax3.Text + tbFax4.Text, dtCustomer.Columns["Fax"].DataType);

            dtCustomer.Rows[0]["Email"] =
                Convert.ChangeType(tbEmail.Text, dtCustomer.Columns["Email"].DataType);
            dtCustomer.Rows[0]["CreateDate"] = DBNull.Value;

            if (cbBusiness.SelectedValue != null)
                dtCustomer.Rows[0]["BusinessTypeID"] =
                    Convert.ChangeType(cbBusiness.SelectedValue, dtCustomer.Columns["BusinessTypeID"].DataType);
            else dtCustomer.Rows[0]["BusinessTypeID"] = DBNull.Value;

            if (cbCarrier.SelectedValue != null)
                dtCustomer.Rows[0]["CarrierID"] =
                    Convert.ChangeType(cbCarrier.SelectedValue, dtCustomer.Columns["CarrierID"].DataType);
            else
                dtCustomer.Rows[0]["CarrierID"] = DBNull.Value;

            //IndustryMemberships listbox
            StringBuilder sbIndustryString = new StringBuilder();
            for (int i = 0; i < lbxIndustry.Items.Count; i++)
                sbIndustryString.Append(dtCustInd.Select("IndustryMembershipName='" + lbxIndustry.Items[i].ToString() + "'")[0]["IndustryMembershipID"].ToString()).Append(',');
            dtCustomer.Rows[0]["IndustryMembership"] = sbIndustryString.ToString();


            //Communication
            StringBuilder sbCommString = new StringBuilder();

            for (int i = 0; i < 4; i++)
            {
                sbCommString.Append(cCustomer.achbComm[i].Text.ToLower()[0]);
                sbCommString.Append(cCustomer.achbComm[i].Checked ? '1' : '0');
            }
            dtCustomer.Rows[0]["Communication"] =
                Convert.ChangeType(sbCommString.ToString(), dtCustomer.Columns["Communication"].DataType);

            //Permissions

            StringBuilder sbPermString = new StringBuilder();

            for (int i = 0; i < 8; i++)
                if (prmCustomer.achbPermissions[i].Checked)
                    sbPermString.Append((i + 1).ToString()).Append(',');
            dtCustomer.Rows[0]["Permission"] = sbPermString.ToString();


            dtCustomer.Rows[0]["WeCarry"] =
                Convert.ChangeType(rbWeCarry.Checked, dtCustomer.Columns["WeCarry"].DataType);
            dtCustomer.Rows[0]["TheyCarry"] =
                Convert.ChangeType(rbTheyCarry.Checked, dtCustomer.Columns["TheyCarry"].DataType);
            dtCustomer.Rows[0]["WeShipCarry"] =
                Convert.ChangeType(rbWeShip.Checked, dtCustomer.Columns["WeShipCarry"].DataType);
            dtCustomer.Rows[0]["UseTheirAccount"] =
                Convert.ChangeType(chbUseTheirAccount.Checked, dtCustomer.Columns["UseTheirAccount"].DataType);
            if (cbCarrier.SelectedValue != null)
                dtCustomer.Rows[0]["CarrierID"] =
                    Convert.ChangeType(cbCarrier.SelectedValue, dtCustomer.Columns["CarrierID"].DataType);
            else dtCustomer.Rows[0]["CarrierID"] = DBNull.Value;
            dtCustomer.Rows[0]["Account"] =
                Convert.ChangeType(tbAccountNumber.Text, dtCustomer.Columns["Account"].DataType);
            dtCustomer.TableName = "Customer";

            DataSet dsCustomer = new DataSet();
            dsCustomer.Tables.Add(dtCustomer.Copy());
            string St = String.Empty;
            try
            {
                St = dtStates.Select("USStateID=" + dsCustomer.Tables[0].Rows[0]["USStateID"])[0]["USStateName"].ToString();
                dsCustomer.Tables[0].Columns.Add("USStateName");
                dsCustomer.Tables[0].Rows[0]["USStateName"] = St;
            }
            catch
            {
                dsCustomer.Tables[0].Columns.Add("USStateName");
                dsCustomer.Tables[0].Rows[0]["USStateName"] = DBNull.Value;
            }
            //if(Service.iInvoiceDebugLevel >= 4)
            try
            {
                //	if(IsNewCustomer)
                //		dsCustomer = Service.QBAddCustomer(dsCustomer);
                //	else
                //		dsCustomer = Service.QBModCustomer(dsCustomer);

                //	dtCustomer.Rows[0]["QuickBookListID"] = dsCustomer.Tables[0].Rows[0]["QuickBookListID"];
                //	dtCustomer.Rows[0]["QuickBookEditSequence"] = dsCustomer.Tables[0].Rows[0]["QuickBookEditSequence"];

                //IsNewCustomer = false;
                return Service.UpdCustomerInfo(dtCustomer);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Unable to update Customer information \n" + exc.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                IsNewCustomer = true;
                return null;
            }

            //@QuickBookEditSequence varchar(150),
            //@QuickBookListID varchar(150)			
        }

        private void UpdateCustomerPrices()
        {
            //gemoDream.Service.debug_DiaspalyDataSet(dsCOGP);

            //System.Diagnostics.Trace.WriteLine("===========================================================");

            //gemoDream.Service.debug_DiaspalyDataSet(dsCustomerPrices);

            try
            {
                /*
                if (!IsNewCustomer)
                {
                    string s = cbcCustomer.SelectedID;

                    char cSeparator = '_';
                    string[] sIDs = s.Split(cSeparator);

                    string sCID = sIDs[1];
                    string sCOID = sIDs[0];
					
                    foreach(DataRow drRange in dsAllCaratRanges.Tables[0].Rows)
                    {
                        if (!Convert.IsDBNull(drRange["State"]) &&
                            drRange["State"].ToString().Equals("Deleted"))
                        {
                            try
                            {
                                DataSet dsIn = new DataSet();
                                DataTable dtIn = dsIn.Tables.Add("CaratRange");
                                //dtIn.Columns.Add("AuthorID",  System.Type.GetType("System.String"));
                                //dtIn.Columns.Add("AuthorOfficeID",  System.Type.GetType("System.String"));
                                dtIn.Columns.Add("CaratRangeClass", System.Type.GetType("System.String"));
                                dtIn.Columns.Add("CaratRangeTitle", System.Type.GetType("System.String"));
                                dtIn.Columns.Add("CaratRangeMin", System.Type.GetType("System.String"));
                                dtIn.Columns.Add("CaratRangeMax", System.Type.GetType("System.String"));
                                dtIn.Columns.Add("CID", System.Type.GetType("System.String"));
                                dtIn.Columns.Add("COID", System.Type.GetType("System.String"));
                                dtIn.Columns.Add("CPID", System.Type.GetType("System.String"));
                                dtIn.Columns.Add("CPOfficeID", System.Type.GetType("System.String"));
                                dtIn.Columns.Add("CRID", System.Type.GetType("System.String"));
                                dtIn.Columns.Add("ExpireDate", System.Type.GetType("System.String"));
                                //dtIn.Columns.Add("CRID", System.Type.GetType("System.String"));

                                DataRow row = dtIn.NewRow();
                                //row["AuthorID"] = str;
                                //row["AuthorOfficeID"] = str;
                                row["CaratRangeClass"] = drRange["CaratRangeClass"];
                                row["CaratRangeTitle"] = drRange["CaratRangeTitle"];
                                row["CaratRangeMin"] = drRange["CaratRangeMin"];
                                row["CaratRangeMax"] = drRange["CaratRangeMax"];
                                row["CID"] = sCID;
                                row["COID"] = sCOID;
                                row["CPID"] = DBNull.Value;
                                row["CPOfficeID"] = DBNull.Value;
                                row["CRID"] = drRange["CRID"];
                                row["ExpireDate"] = DateTime.Today;
					
                                dtIn.Rows.Add(row);

                                DataSet dsOut = Service.ProxyGenericSet(dsIn, "Set");

                                continue;
							
                                //string sCRID = dsOut.Tables[0].Rows[0][0].ToString();
                                //drRange["CRID"] = sCRID;
                                //drRange["State"] = "Unchanged";
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(this, "Can't get carat range ID. Reason: " + ex.ToString(),
                                    "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        if (!Convert.IsDBNull(drRange["State"]) &&
                            drRange["State"].ToString().Equals("Added"))
                        {
                            try
                            {
                                DataSet dsIn = new DataSet();
                                DataTable dtIn = dsIn.Tables.Add("CaratRange");
                                //dtIn.Columns.Add("AuthorID",  System.Type.GetType("System.String"));
                                //dtIn.Columns.Add("AuthorOfficeID",  System.Type.GetType("System.String"));
                                dtIn.Columns.Add("CaratRangeClass", System.Type.GetType("System.String"));
                                dtIn.Columns.Add("CaratRangeTitle", System.Type.GetType("System.String"));
                                dtIn.Columns.Add("CaratRangeMin", System.Type.GetType("System.String"));
                                dtIn.Columns.Add("CaratRangeMax", System.Type.GetType("System.String"));
                                dtIn.Columns.Add("CID", System.Type.GetType("System.String"));
                                dtIn.Columns.Add("COID", System.Type.GetType("System.String"));
                                dtIn.Columns.Add("CPID", System.Type.GetType("System.String"));
                                dtIn.Columns.Add("CPOfficeID", System.Type.GetType("System.String"));
                                dtIn.Columns.Add("CRID", System.Type.GetType("System.String"));
                                dtIn.Columns.Add("ExpireDate", System.Type.GetType("System.String"));
                                //dtIn.Columns.Add("CRID", System.Type.GetType("System.String"));

                                DataRow row = dtIn.NewRow();
                                //row["AuthorID"] = str;
                                //row["AuthorOfficeID"] = str;
                                row["CaratRangeClass"] = drRange["CaratRangeClass"];
                                row["CaratRangeTitle"] = drRange["CaratRangeTitle"];
                                row["CaratRangeMin"] = drRange["CaratRangeMin"];
                                row["CaratRangeMax"] = drRange["CaratRangeMax"];
                                row["CID"] = sCID;
                                row["COID"] = sCOID;
                                row["CPID"] = DBNull.Value;
                                row["CPOfficeID"] = DBNull.Value;
                                //row["CRID"] = DBNull.Value;
					
                                dtIn.Rows.Add(row);

                                DataSet dsOut = Service.ProxyGenericSet(dsIn, "Set");
							
                                string sCRID = dsOut.Tables[0].Rows[0][0].ToString();
                                drRange["CRID"] = sCRID;
                                drRange["State"] = "Unchanged";

                                //DataRow[] dr = dsCustomerPrices.Tables[0].Select("CustomerOfficeID_CustomerID=" + sCOID + "_" + sCID);
                                //string sCOID_CID_OTGID_CRID = 
                                //	dr[0]["COID"].ToString() + "_" + dr[0]["CID"].ToString() +
                                //	"_" + dr[0]["OTGID"].ToString() + "_" + sCRID;
                                //dr[0]["COID_CID_OTGID_CRID"] = sCOID_CID_OTGID_CRID;
                                //dr[0]["CRID"] = sCRID;
                                //dr[0]["IsFixedPrice"] = "0";

                                //gemoDream.Service.debug_DiaspalyDataSet(dsCustomerPrices);
                                //gemoDream.Service.debug_DiaspalyDataSet(dsCOGP);

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(this, "Can't get carat range ID. Reason: " + ex.ToString(),
                                    "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }

                    DataRow[] rowsToDelete = dsAllCaratRanges.Tables[0].Select("State='Deleted'");
				
                    foreach(DataRow row in rowsToDelete)
                    {
                        dsAllCaratRanges.Tables[0].Rows.Remove(row);
                    }

                }
                */

                SaveOperationGroupRangePrice();

                //gemoDream.Service.debug_DiaspalyDataSet(dsCustomerPrices);

                Service.SetCustomerOperationGroupRangePrice(dsCustomerPrices);
                Service.SetCOGP(dsCOGP);

                IsNewCustomer = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Can't do the update carat ranges. Reason: " + ex.ToString());

            }
        }

        #endregion UpdateCustomer

        #endregion CustomerInfo

        //Persons list & selected person info
        #region PersonInfo
        private void ClearPersonPanelFields()
        {
            tbPFirstName.Text = "";
            tbPLastName.Text = "";
            cbPPosition.SelectedIndex = 0;
            lbPStartDate.Text = "will be set on server";
            tbPID.Text = "";
            tbPBirthDate.Text = "";
            tbPPhone2.Text = "";
            tbPPhone3.Text = "";
            tbPPhone4.Text = "";
            tbPhoneExt.Text = "";
            tbPFax2.Text = "";
            tbPFax3.Text = "";
            tbPFax4.Text = "";
            tbPCell2.Text = "";
            tbPCell3.Text = "";
            tbPCell4.Text = "";
            tbPEmail.Text = "";
            locPerson.ClearFields();
            cPerson.ClearChecks();
            tbPWebLogin.Text = "";
            tbPWebPwd.Text = "";
            tbPRetypePwd.Text = "";
            prmPerson.ClearChecks();
            chbPLocationSame.Checked = false;
            tbPBirthDate.Enabled = true;
        }
        private void FillPersons(string custID)
        {
            //DataSet dsCust = new DataSet();
            //dsCust.Tables.Add(dsCustomerTypeEx.Tables[0]);
            //dtPerson = Service.GetPersonsByCustomer(dsCust).Tables[0].Copy();
            GetType(custID);

            liPersons.Items.Clear();
            for (int i = 0; i < dtPerson.Rows.Count; i++)
            {
                ListViewItem lviItem = new ListViewItem(i.ToString());
                lviItem.SubItems.Add(dtPerson.Rows[i]["FirstName"].ToString());
                lviItem.SubItems.Add(dtPerson.Rows[i]["LastName"].ToString());
                try
                {
                    lviItem.SubItems.Add(dtPerson.Rows[i]["PositionName"].ToString());
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }

                lviItem.SubItems.Add(dtPerson.Rows[i]["CountryPhoneCode"].ToString() + dtPerson.Rows[i]["Phone"].ToString());

                try
                {
                    lviItem.SubItems.Add(dtPerson.Rows[i]["CountryFaxCode"].ToString() + dtPerson.Rows[i]["Fax"].ToString());
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }

                try
                {
                    lviItem.SubItems.Add(dtPerson.Rows[i]["CountryCellCode"].ToString() +
                        dtPerson.Rows[i]["Cell"].ToString());
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }

                lviItem.SubItems.Add(dtPerson.Rows[i]["Email"].ToString());
                liPersons.Items.Add(lviItem);
            }
        }

        private void liPersons_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (liPersons.SelectedIndices.Count > 0 && liPersons.SelectedIndices[0] != -1)
                bDeletePerson.Enabled = true;
            else
                bDeletePerson.Enabled = false;

            IsNewPerson = false;
            ClearPersonPanelFields();
            gbPerson.Enabled = true;
            try
            {
                int iSelected = liPersons.SelectedIndices[0];
                FillPersonAdditional(iSelected);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            tbPFirstName.Focus();
        }

        private void FillPersonAdditional(int iRowNumber)
        {
            tbPID.Text = dtPerson.Rows[iRowNumber]["PersonCode"].ToString();
            tbPFirstName.Text = dtPerson.Rows[iRowNumber]["FirstName"].ToString();
            tbPLastName.Text = dtPerson.Rows[iRowNumber]["LastName"].ToString();

            try
            {
                tbPBirthDate.Text = Convert.ToDateTime(dtPerson.Rows[iRowNumber]["BirthDate"]).Month.ToString() + '/' +
                    Convert.ToDateTime(dtPerson.Rows[iRowNumber]["BirthDate"]).Day.ToString() + '/' +
                    Convert.ToDateTime(dtPerson.Rows[iRowNumber]["BirthDate"]).Year.ToString();
            }
            catch
            {
                tbPBirthDate.Text = "";
            }

            lbPStartDate.Text = dtPerson.Rows[iRowNumber]["CreateDate"].ToString();
            cbPPosition.SelectedValue = dtPerson.Rows[iRowNumber]["PositionID"].ToString();
            tbPEmail.Text = dtPerson.Rows[iRowNumber]["Email"].ToString();

            tbPPhone1.Text = dtPerson.Rows[iRowNumber]["CountryPhoneCode"].ToString();
            if (dtPerson.Rows[iRowNumber]["Phone"].ToString().Length > 2)
                tbPPhone2.Text = dtPerson.Rows[iRowNumber]["Phone"].ToString().Substring(0, 3);
            if (dtPerson.Rows[iRowNumber]["Phone"].ToString().Length > 5)
                tbPPhone3.Text = dtPerson.Rows[iRowNumber]["Phone"].ToString().Substring(3, 3);
            if (dtPerson.Rows[iRowNumber]["Phone"].ToString().Length > 9)
                tbPPhone4.Text = dtPerson.Rows[iRowNumber]["Phone"].ToString().Substring(6, dtPerson.Rows[0]["Phone"].ToString().Length - 6);

            tbPhoneExt.Text = dtPerson.Rows[iRowNumber]["ExtPhone"].ToString();

            try
            {
                tbPFax1.Text = dtPerson.Rows[iRowNumber]["CountryFaxCode"].ToString();
                if (dtPerson.Rows[iRowNumber]["Fax"].ToString().Length > 2)
                    tbPFax2.Text = dtPerson.Rows[iRowNumber]["Fax"].ToString().Substring(0, 3);
                if (dtPerson.Rows[iRowNumber]["Fax"].ToString().Length > 5)
                    tbPFax3.Text = dtPerson.Rows[iRowNumber]["Fax"].ToString().Substring(3, 3);
                if (dtPerson.Rows[iRowNumber]["Fax"].ToString().Length > 9)
                    tbPFax4.Text = dtPerson.Rows[iRowNumber]["Fax"].ToString().Substring(6, dtPerson.Rows[0]["Fax"].ToString().Length - 6);
            }
            catch { }

            try
            {
                tbPCell1.Text = dtPerson.Rows[iRowNumber]["CountryCellCode"].ToString();
                if (dtPerson.Rows[iRowNumber]["Cell"].ToString().Length > 2)
                    tbPCell2.Text = dtPerson.Rows[iRowNumber]["Cell"].ToString().Substring(0, 3);
                if (dtPerson.Rows[iRowNumber]["Cell"].ToString().Length > 5)
                    tbPCell3.Text = dtPerson.Rows[iRowNumber]["Cell"].ToString().Substring(3, 3);
                if (dtPerson.Rows[iRowNumber]["Cell"].ToString().Length > 9)
                    tbPCell4.Text = dtPerson.Rows[iRowNumber]["Cell"].ToString().Substring(6, dtPerson.Rows[0]["Cell"].ToString().Length - 6);
            }
            catch { }

            locPerson.tbCountry.Text = dtPerson.Rows[iRowNumber]["Country"].ToString();
            locPerson.tbCity.Text = dtPerson.Rows[iRowNumber]["City"].ToString();
            locPerson.tbAddress.Text = dtPerson.Rows[iRowNumber]["Address1"].ToString();
            locPerson.cbState.SelectedValue = dtPerson.Rows[iRowNumber]["USStateID"];

            try
            {
                locPerson.tbAdditional.Text = dtPerson.Rows[iRowNumber]["Address2"].ToString();
            }
            catch { }

            locPerson.tbZip1.Text = dtPerson.Rows[iRowNumber]["Zip1"].ToString();
            try
            {
                locPerson.tbZip2.Text = dtPerson.Rows[iRowNumber]["Zip2"].ToString();
            }
            catch { }
            tbPWebLogin.Text = dtPerson.Rows[iRowNumber]["WebLogin"].ToString();
            tbPWebPwd.Text = dtPerson.Rows[iRowNumber]["WebPwd"].ToString();

            CommunicationInit(dtPerson.Rows[iRowNumber]["Communication"].ToString(), cPerson);
            PermInit(dtPerson.Rows[iRowNumber]["Permission"].ToString(), prmPerson);
        }


        #region PersonHandlers
        //Person's address is the same as Customer's
        private void chbPLocationSame_CheckedChanged(object sender, System.EventArgs e)
        {
            locPerson.Enabled = !chbPLocationSame.Checked;

            if (chbPLocationSame.Checked)
            {
                locPerson.tbAdditional.Text = locCustomer.tbAdditional.Text;
                locPerson.tbAddress.Text = locCustomer.tbAddress.Text;
                locPerson.tbCity.Text = locCustomer.tbCity.Text;
                locPerson.tbCountry.Text = locCustomer.tbCountry.Text;
                locPerson.tbZip1.Text = locCustomer.tbZip1.Text;
                locPerson.tbZip2.Text = locCustomer.tbZip2.Text;
                locPerson.cbState.SelectedIndex = locCustomer.cbState.SelectedIndex;
            }
        }

        private void bDeletePerson_Click(object sender, System.EventArgs e)
        {
            if (liPersons.SelectedIndices.Count > 0 && liPersons.SelectedIndices[0] != -1)
                if (MessageBox.Show("Are you sure you want to delete this person's information?",
                    "Delete a person", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) ==
                    DialogResult.Yes)
                {
                    DataSet dsPersonTypeEx = Service.GetPersonTypeEx();
                    dsPersonTypeEx.Tables[0].TableName = "PersonType";
                    foreach (DataRow drExp in dtPerson.Rows)
                    {
                        if (drExp["PersonCode"].ToString() == tbPID.Text)
                        {
                            dsPersonTypeEx.Tables[0].Rows.Add(new object[] { drExp["PersonCustomerOfficeID_PersonCustomerID_PersonID"], null, null, null });
                            break;
                        }
                    }
                    liPersons.Items.RemoveAt(liPersons.SelectedIndices[0]);
                    Service.PersonExpire(dsPersonTypeEx.Tables[0]);
                }
            ClearPersonPanelFields();
        }


        //On New Person button click
        private void bNewPerson_Click(object sender, System.EventArgs e)
        {
            bNewCustomer.Enabled = false;
            bUpdate.Enabled = false;
            liPersons.Enabled = false;
            IsNewPerson = true;
            gbPerson.Enabled = true;
            ClearPersonPanelFields();

            tbPID.Text = "will be set on server";

            DataSet dsNewPers = new DataSet();
            dsNewPers.Tables.Add("PersonTypeOf");
            dsNewPers = Service.GetPersonType();
            dtPerson = dsNewPers.Tables[0].Copy();
            dtPerson.Rows.Add(dtPerson.NewRow());
        }


        //Clears Web login & pwd on button click
        private void bPWebClear_Click(object sender, System.EventArgs e)
        {
            tbPWebLogin.Text = "";
            tbPWebPwd.Text = "";
            tbPRetypePwd.Text = "";
        }


        private void tbPBirthDate_TextChanged(object sender, System.EventArgs e)
        {
            int iCount = 0;
            for (int i = 0; i < tbPBirthDate.Text.Length; i++)
                if (tbPBirthDate.Text[i] == '/')
                    iCount++;

            if (iCount < 2) tbPBirthDate.Text += '/';

            if (tbPBirthDate.Text.Length == 4)
            {
                tbPBirthDate.SelectionStart = 3;
                tbPBirthDate.SelectionLength = 0;
            }
            if (tbPBirthDate.Text.Length == 6)
            {
                tbPBirthDate.SelectionStart = 6;
                tbPBirthDate.SelectionLength = 0;
            }
        }


        #region PersonsPhoneFaxCellChanged
        //On changing Customer's country
        private void tbCountry_TextChanged(object sender, EventArgs ea)
        {
            if (locCustomer.tbCountry.Text.ToUpper() != "USA" && locCustomer.tbCountry.Text.ToUpper() != "US" &&
                locCustomer.tbCountry.Text.ToUpper() != "U.S." && locCustomer.tbCountry.Text.ToUpper() != "U.S.A.")
            {
                tbPhone1.Enabled = true;
                tbFax1.Enabled = true;
                tbPhone4.MaxLength = 32768;
                tbFax4.MaxLength = 32768;
            }
            else
            {
                tbPhone1.Enabled = false;
                tbPhone1.Text = "+1";
                tbPhone4.MaxLength = 4;
                tbFax1.Enabled = false;
                tbFax1.Text = "+1";
                tbFax4.MaxLength = 4;
            }
        }


        //On changing Person's country
        private void locPerson_CountryChanged(object sender, EventArgs ea)
        {
            if (locPerson.tbCountry.Text.ToUpper() != "USA" && locPerson.tbCountry.Text.ToUpper() != "US" &&
                locPerson.tbCountry.Text.ToUpper() != "U.S." && locPerson.tbCountry.Text.ToUpper() != "U.S.A.")
            {
                tbPPhone1.Enabled = true;
                tbPFax1.Enabled = true;
                tbPCell1.Enabled = true;
                tbPPhone4.MaxLength = 32768;
                tbPFax4.MaxLength = 32768;
                tbPCell4.MaxLength = 32768;
            }
            else
            {
                tbPPhone1.Enabled = false;
                tbPFax1.Enabled = false;
                tbPCell1.Enabled = false;
                tbPPhone1.Text = "+1";
                tbPFax1.Text = "+1";
                tbPFax1.Text = "+1";
                tbPPhone4.MaxLength = 4;
                tbPFax4.MaxLength = 4;
                tbPCell4.MaxLength = 4;
            }
        }


        private void tbPhone1_TextChanged(object sender, System.EventArgs e)
        {
            if (tbPhone1.Text == "")
                tbPhone1.Text = "+";
        }


        private void tbFax1_TextChanged(object sender, System.EventArgs e)
        {
            if (tbFax1.Text == "")
                tbFax1.Text = "+";
        }


        private void tbPPhone1_TextChanged(object sender, System.EventArgs e)
        {
            if (tbPPhone1.Text == "")
                tbPPhone1.Text = "+";
        }


        private void tbPFax1_TextChanged(object sender, System.EventArgs e)
        {
            if (tbPFax1.Text == "")
                tbPFax1.Text = "+";
        }


        private void tbPCell1_TextChanged(object sender, System.EventArgs e)
        {
            if (tbPCell1.Text == "")
                tbPCell1.Text = "+";
        }

        #endregion PersonsPhoneFaxCellChanged

        #endregion PersonHandlers
        #region UpdatePerson

        private void bPUpdate_Click(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Updating person info";
            this.Cursor = Cursors.WaitCursor;

            if (tbPWebPwd.Text != tbPRetypePwd.Text)
            {
                MessageBox.Show("Password doesn't match retyped password. Please, type and retype again.",
                    "Wrong password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbPWebPwd.Text = "";
                tbPRetypePwd.Text = "";
                tbPWebPwd.Focus();
            }
            else
            {
                if (PersonFieldsOK())
                {
                    if (!IsWebLoginExists())
                        UpdatePerson();
                    else
                    {
                        MessageBox.Show("Person with this login and password already exists.", "Wrong person web login",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbPWebPwd.Focus();
                        this.tbPRetypePwd.Text = "";
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Not all fields are filled correctly",
                        "Prohibited field value", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            this.Cursor = Cursors.Default;
            sbStatus.Text = "Ready";
            bNewCustomer.Enabled = true;
            bUpdate.Enabled = true;
            liPersons.Enabled = true;
        }

        private void UpdatePerson()
        {
            DataRow dr = dtPerson.NewRow();

            if (tbPID.Text == "will be set on server")
                dr = dtPerson.Rows[dtPerson.Rows.Count - 1];
            else
                dr = dtPerson.Select("PersonCode=" + tbPID.Text)[0];

            dr["CustomerOfficeID_CustomerID"] =
                Convert.ChangeType(dtCustomer.Rows[0]["CustomerOfficeID_CustomerID"], dtPerson.Columns["CustomerOfficeID_CustomerID"].DataType);
            dr["FirstName"] =
                Convert.ChangeType(tbPFirstName.Text, dtPerson.Columns["FirstName"].DataType);
            dr["LastName"] =
                Convert.ChangeType(tbPLastName.Text, dtPerson.Columns["LastName"].DataType);
            dr["PositionID"] =
                Convert.ChangeType(cbPPosition.SelectedValue, dtPerson.Columns["PositionID"].DataType);

            if (tbPBirthDate.Text != "//")
                try
                {
                    dr["BirthDate"] =
                        Convert.ChangeType(tbPBirthDate.Text, dtPerson.Columns["BirthDate"].DataType);
                }
                catch
                {
                }

            dr["Email"] = Convert.ChangeType(tbPEmail.Text, dtPerson.Columns["Email"].DataType);

            dr["CountryPhoneCode"] = Convert.ChangeType(tbPPhone1.Text, dtPerson.Columns["CountryPhoneCode"].DataType);
            dr["Phone"] = Convert.ChangeType(tbPPhone2.Text + tbPPhone3.Text + tbPPhone4.Text, dtPerson.Columns["Phone"].DataType);
            dr["ExtPhone"] = Convert.ChangeType(tbPhoneExt.Text, dtPerson.Columns["ExtPhone"].DataType);

            dr["CountryFaxCode"] = Convert.ChangeType(tbPFax1.Text, dtPerson.Columns["CountryFaxCode"].DataType);
            dr["Fax"] = Convert.ChangeType(tbPFax2.Text + tbPFax3.Text + tbPFax4.Text, dtPerson.Columns["Fax"].DataType);

            dr["CountryCellCode"] = Convert.ChangeType(tbPCell1.Text, dtPerson.Columns["CountryCellCode"].DataType);
            dr["Cell"] = Convert.ChangeType(tbPCell2.Text + tbPCell3.Text + tbPCell4.Text, dtPerson.Columns["Cell"].DataType);

            //location
            dr["Country"] = Convert.ChangeType(locPerson.tbCountry.Text, dtPerson.Columns["Country"].DataType);
            dr["City"] = Convert.ChangeType(locPerson.tbCity.Text, dtPerson.Columns["City"].DataType);
            dr["Address1"] = Convert.ChangeType(locPerson.tbAddress.Text, dtPerson.Columns["Address1"].DataType);
            dr["Address2"] = Convert.ChangeType(locPerson.tbAdditional.Text, dtPerson.Columns["Address2"].DataType);
            try
            {
                dr["USStateID"] = Convert.ChangeType(locPerson.cbState.SelectedValue, dtPerson.Columns["USStateID"].DataType);
            }
            catch
            {
                dr["USStateID"] = Convert.DBNull;
            }

            try
            {
                dr["Zip1"] = Convert.ChangeType(locPerson.tbZip1.Text, dtPerson.Columns["Zip1"].DataType);
            }
            catch { }
            try
            {
                dr["Zip2"] = Convert.ChangeType(locPerson.tbZip2.Text, dtPerson.Columns["Zip2"].DataType);
            }
            catch { }


            //web
            dr["WebLogin"] = Convert.ChangeType(tbPWebLogin.Text, dtPerson.Columns["WebLogin"].DataType);
            dr["WebPwd"] = Convert.ChangeType(tbPWebPwd.Text, dtPerson.Columns["WebPwd"].DataType);

            //Communication
            StringBuilder sbCommString = new StringBuilder();

            for (int j = 0; j < 4; j++)
            {
                sbCommString.Append(cPerson.achbComm[j].Text.ToLower()[0]);
                sbCommString.Append(cPerson.achbComm[j].Checked ? '1' : '0');
            }
            dtPerson.Rows[0]["Communication"] =
                Convert.ChangeType(sbCommString.ToString(), dtPerson.Columns["Communication"].DataType);

            //Permissions

            StringBuilder sbPermString = new StringBuilder();
            for (int j = 0; j < 8; j++)
                if (prmPerson.achbPermissions[j].Checked)
                    sbPermString.Append((j + 1).ToString()).Append(',');
            dtPerson.Rows[0]["Permission"] = sbPermString.ToString();

            /*
            try
            {
                DataSet dsIn = new DataSet();
                DataTable dtIn = dsIn.Tables.Add("PersonWebLogin");
                dtIn.Columns.Add("WebLogin", dtPerson.Columns["WebLogin"].DataType);
                dtIn.Columns.Add("WebPwd", dtPerson.Columns["WebLogin"].DataType);
                dtIn.Columns.Add("P", System.Type.GetType("System.String"));

                string str;
                str = "";
                if (!IsNewPerson)
                {
                    int iRowNumber = liPersons.SelectedIndices[0];
                    str = dtPerson.Rows[iRowNumber]["PersonCustomerOfficeID_PersonCustomerID_PersonID"].ToString();
                }
                				
                DataRow row = dtIn.NewRow();
                row["WebLogin"] = tbPWebLogin.Text;
                row["WebPwd"] = tbPWebPwd.Text;
                row["P"] = str;
				
                dtIn.Rows.Add(row);
                DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);

                if (dsOut.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Person with this login and password already exists.", "Wrong person web login",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbPWebPwd.Focus();
                    this.tbPRetypePwd.Text = "";
                    return ;
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show("Unable to check web login existance" + exc.Message, "Internal Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */

            try
            {
                Service.UpdPersonInfo(dtPerson);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Unable to update person information" + exc.Message, "Internal Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            gbPerson.Enabled = false;
            FillPersons(cbcCustomer.SelectedID);
        }

        private bool PersonFieldsOK()
        {
            if (tbPFirstName.Text == "" || tbPLastName.Text == "" || cbPPosition.SelectedValue == null)
                return false;

            if (tbPPhone2.Text.Length > 0 || tbPPhone3.Text.Length > 0 || tbPPhone2.Text.Length > 0)
            {
                if (tbPPhone4.Text.Length < 4 || tbPPhone3.Text.Length < 3 || tbPPhone2.Text.Length < 3)
                    return false;
            }

            if (tbPFax2.Text.Length > 0 || tbPFax3.Text.Length > 0 || tbPFax2.Text.Length > 0)
            {
                if (tbPFax4.Text.Length < 4 || tbPFax3.Text.Length < 3 || tbPFax2.Text.Length < 3)
                    return false;
            }

            if (tbPCell2.Text.Length > 0 || tbPCell3.Text.Length > 0 || tbPCell2.Text.Length > 0)
            {
                if (tbPCell4.Text.Length < 4 || tbPCell3.Text.Length < 3 || tbPCell2.Text.Length < 3)
                    return false;
            }


            if (tbPPhone2.Text.Length > 0 && tbPPhone3.Text.Length > 0 && tbPPhone4.Text.Length > 0)
                try
                {
                    Convert.ToInt32(tbPPhone2.Text);
                    Convert.ToInt32(tbPPhone3.Text);
                    Convert.ToInt32(tbPPhone4.Text);
                }
                catch
                {
                    return false;
                }

            if (tbPFax2.Text.Length > 0 && tbPFax3.Text.Length > 0 && tbPFax4.Text.Length > 0)
                try
                {
                    Convert.ToInt32(tbPFax2.Text);
                    Convert.ToInt32(tbPFax3.Text);
                    Convert.ToInt32(tbPFax4.Text);
                }
                catch
                {
                    return false;
                }

            if (tbPCell2.Text.Length > 0 && tbPCell3.Text.Length > 0 && tbPCell4.Text.Length > 0)

                try
                {
                    Convert.ToInt32(tbPCell2.Text);
                    Convert.ToInt32(tbPCell3.Text);
                    Convert.ToInt32(tbPCell4.Text);
                }
                catch
                {
                    return false;
                }

            string domen = tbPEmail.Text.Substring(tbPEmail.Text.LastIndexOf('.') + 1);
            if (tbPEmail.Text != "" && (tbPEmail.Text.Split(new char[] { '@' }).Length != 2 ||
                (domen.Length < 2 || domen.Length > 3)))
                return false;
            return true;
        }


        #endregion UpdatePerson

        #endregion PersonInfo

        #region Permissions_Communications_IndustryMemberships_Translating
        private void IndMem(string sIni)
        {
            int iPos = 0;

            lbxIndustry.Items.Clear();

            while (iPos < sIni.Length)
            {
                lbxIndustry.Items.Add(sIni.Substring(iPos, sIni.IndexOf(',', iPos) - iPos));
                iPos += sIni.IndexOf(',', iPos) - iPos + 1;
            }
        }
        private void PermInit(string sIni, Permissions prmPerm)
        {
            int iPos = 0;
            int iNum = 0;

            for (int i = 0; i < prmPerm.achbPermissions.Length; i++)
                prmPerm.achbPermissions[i].Checked = false;

            while (iPos < sIni.Length)
            {
                iNum = Convert.ToInt32(sIni.Substring(iPos, 1));

                iPos += 2;
                prmPerm.achbPermissions[iNum - 1].Checked = true;
            }
        }

        private void CommunicationInit(string sIni, Communication cComm)
        {
            CheckBox chbTemp = null;
            int iPos = 0;

            cComm.ClearChecks();

            for (int i = 0; i < cComm.achbComm.Length; i++)
                cComm.achbComm[i].Checked = false;

            while (iPos < sIni.Length)
            {
                switch (sIni[iPos])
                {
                    case 'p':
                        chbTemp = cComm.chbPhone;
                        break;
                    case 'f':
                        chbTemp = cComm.chbFax;
                        break;
                    case 'e':
                        chbTemp = cComm.chbEmail;
                        break;
                    case 'm':
                        chbTemp = cComm.chbMail;
                        break;
                }
                chbTemp.Location = new Point(5 + iPos / 2 * 55, chbTemp.Location.Y);
                chbTemp.Checked = sIni[iPos + 1] == '1' ? true : false;
                iPos += 2;
            }
        }
        #endregion Permissions_Communications_Translating

        #endregion CustomerTab


        #region PricesTab

        #region Handlers
        private void rbFixed_CheckedChanged(object sender, System.EventArgs e)
        {
            /*vms
            gbFixed.Enabled = rbFixed.Checked;
            try
            {
                System.Diagnostics.Trace.WriteLine("fixed_CheckedChanged");
                gemoDream.Service.debug_DiaspalyDataSet(dsCustomerPrices);
                gemoDream.Service.debug_DiaspalyDataSet(dsCOGP);

                DataRow[] adrRow1 = dsCustomerPrices.Tables[0].Select("CRID=" + label1.Tag.ToString() + " and OTGID=" + ptrTree.SelectedRow["OTGID"].ToString());
                DataRow[] adrRow = dsCOGP.Tables[0].Select("OTGID=" + adrRow1[0]["OTGID"].ToString() + " and COID=" + adrRow1[0]["COID"].ToString());
                if(adrRow.Length != 0)
                {
                    ptrTree.SelectedRow["IsFixedPrice"] = rbFixed.Checked == true ? "1" : "0";
                    adrRow[0]["IsFixedPrice"] = rbFixed.Checked == true ? "1" : "0";
                    adrRow1[0]["IsFixedPrice"] = rbFixed.Checked == true ? "1" : "0";
                    Console.WriteLine(adrRow[0]["IsFixedPrice"].ToString());
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(this, "Can't change fixed. Reason: " + exc.ToString(),
                    "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(exc.Message);
            }
            */
            gbFixed.Enabled = rbFixed.Checked;
            try
            {
                //System.Diagnostics.Trace.WriteLine("fixed_CheckedChanged");
                //gemoDream.Service.debug_DiaspalyDataSet(dsCustomerPrices);
                gemoDream.Service.Debug_DiaspalyDataSet(dsCOGP);

                //DataRow[] adrRow1 = dsCustomerPrices.Tables[0].Select("CRID=" + label1.Tag.ToString() + " and OTGID=" + ptrTree.SelectedRow["OTGID"].ToString());
                //DataRow[] adrRow = dsCOGP.Tables[0].Select("OTGID=" + adrRow1[0]["OTGID"].ToString() + " and COID=" + adrRow1[0]["COID"].ToString());
                string s = "OTGID=" + ptrTree.SelectedRow["OTGID"].ToString();
                DataRow[] adrRow = dsCOGP.Tables[0].Select(s);
                if (adrRow.Length != 0)
                {
                    ptrTree.SelectedRow["IsFixedPrice"] = rbFixed.Checked == true ? "1" : "0";
                    adrRow[0]["IsFixedPrice"] = rbFixed.Checked == true ? "1" : "0";
                    //adrRow1[0]["IsFixedPrice"] = rbFixed.Checked == true ? "1" : "0";
                    Console.WriteLine(adrRow[0]["IsFixedPrice"].ToString());
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(this, "Can't change fixed. Reason: " + exc.ToString(),
                    "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(exc.Message);
            }
        }

        private void rbUnfixed_CheckedChanged(object sender, System.EventArgs e)
        {
            gbUnfixed.Enabled = rbUnfixed.Checked;

            //mvs
            if (rbUnfixed.Checked)
            {
                btnAddRange.Enabled = true;
                btnDelRange.Enabled = true;
                btnUpdateRanges.Enabled = true;
            }
            else
            {
                btnAddRange.Enabled = false;
                btnDelRange.Enabled = false;
                btnUpdateRanges.Enabled = false;
            }
            //mvs
            try
            {
                //System.Diagnostics.Trace.WriteLine("Unfixed_CheckedChanged");
                //gemoDream.Service.debug_DiaspalyDataSet(dsCustomerPrices);
                //gemoDream.Service.debug_DiaspalyDataSet(dsCOGP);

                //DataRow[] adrRow1 = dsCustomerPrices.Tables[0].Select("CRID=" + Convert.ToInt32(label1.Tag));
                //DataRow[] adrRow = dsCOGP.Tables[0].Select("OTGID=" + adrRow1[0]["OTGID"].ToString());
                //if(adrRow.Length != 0)
                //{
                //	ptrTree.SelectedRow["IsFixedPrice"] = rbFixed.Checked == true ? "1" : "0";
                //	adrRow[0]["IsFixedPrice"] = rbFixed.Checked == true ? "1" : "0";
                //	adrRow1[0]["IsFixedPrice"] = rbFixed.Checked == true ? "1" : "0";
                //}
                string s = "OTGID=" + ptrTree.SelectedRow["OTGID"].ToString();
                DataRow[] adrRow = dsCOGP.Tables[0].Select(s);
                if (adrRow.Length != 0)
                {
                    ptrTree.SelectedRow["IsFixedPrice"] = rbFixed.Checked == true ? "1" : "0";
                    adrRow[0]["IsFixedPrice"] = rbFixed.Checked == true ? "1" : "0";
                    //adrRow1[0]["IsFixedPrice"] = rbFixed.Checked == true ? "1" : "0";
                    Console.WriteLine(adrRow[0]["IsFixedPrice"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Can't change fixed. Reason: " + ex.ToString(),
                    "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbFixedB_CheckedChanged(object sender, System.EventArgs e)
        {
            tbFixedB.Enabled = rbFixedB.Checked;
            tbFixedP.Enabled = !rbFixedB.Checked;
        }

        #endregion Handlers


        private void InitOpsTree()
        {
            gbUnfixed.Controls.Clear();

            //drawing all Price-controls
            DataRow[] sortedRows = dsAllCaratRanges.Tables[0].Select("1=1", "CaratRangeMax");

            //debug_DisplayDataRowCollection(sortedRows);

            foreach (DataRow drRange in sortedRows/*dsAllCaratRanges.Tables[0].Rows*/)
            {
                if (Convert.IsDBNull(drRange["State"]) ||
                    !(drRange["State"].ToString().Equals("Deleted")))
                {
                    if (drRange["CaratRangeClass"].ToString() == "0")
                    {
                        label1.Text = drRange["CaratRangeTitle"].ToString();
                        label1.Tag = drRange["CRID"].ToString();
                    }
                    else
                    {
                        Price pNew = new Price();
                        pNew.lbInterval.Text = drRange["CaratRangeTitle"].ToString();
                        pNew.lbName.Text = "";
                        pNew.Tag = drRange["CRID"].ToString();
                        pNew.sCaratRangeMin = drRange["CaratRangeMin"].ToString();
                        pNew.sCaratRangeMax = drRange["CaratRangeMax"].ToString();

                        if (gbUnfixed.Controls.Count > 0)
                            pNew.Location = new Point(10, gbUnfixed.Controls[gbUnfixed.Controls.Count - 1].Location.Y + 50);
                        else
                            pNew.Location = new Point(10, 5);

                        gbUnfixed.Controls.Add(pNew);
                    }
                }

                rbFixed.Checked = IsFixedPrice;
                rbUnfixed.Checked = !IsFixedPrice;
            }
        }

        private void SaveOperationGroupRangePrice()
        {
            DataRow drNew;

            //remembering prices for previous operation type and current customer

            if (label1.Tag == null)
                return;

            string s = "CRID=" + label1.Tag.ToString() + " and " + "OTGID=" + PrevOTGID.ToString();
            DataRow[] adrSel1 = dsCustomerPrices.Tables[0].Select("CRID=" + label1.Tag.ToString() + " and " + "OTGID=" + PrevOTGID.ToString());

            if (adrSel1.Length == 0)
            {
                try
                {
                    Convert.ToDouble(tbFixedB.Text);
                }
                catch
                {
                    if (tbFixedP.Text != "")
                        tbFixedB.Text = "0";
                }

                try
                {
                    Convert.ToDouble(tbFixedP.Text);
                }
                catch
                {
                    if (tbFixedB.Text != "")
                        tbFixedP.Text = "0";
                }

                if (tbFixedB.Text != "" || tbFixedP.Text != "")
                {
                    drNew = dsCustomerPrices.Tables[0].NewRow();
                    dsCustomerPrices.Tables[0].Rows.Add(drNew);
                    if (tbFixedB.Text != "")
                        drNew["RangeFixPrice"] = Convert.ToDouble(tbFixedB.Text);
                    if (tbFixedP.Text != "")
                        drNew["RangeRelPrice"] = Convert.ToDouble(tbFixedP.Text);
                    drNew["IsFixPrice"] = rbFixedB.Checked == true ? "1" : "0";
                    drNew["CRID"] = Convert.ToInt32(label1.Tag);
                    drNew["OTGID"] = PrevOTGID;
                    drNew["COID_CID_OTGID_CRID"] = cbcCustomer.ComboField.drvSelectedItem[cbcCustomer.ValueMember].ToString() +
                        "_" + drNew["OTGID"].ToString() + "_" + drNew["CRID"].ToString();
                    drNew["CustomerOfficeID_CustomerID"] = cbcCustomer.ComboField.drvSelectedItem[cbcCustomer.ValueMember].ToString();
                }
            }
            else
            {
                drNew = adrSel1[0];
                if (tbFixedB.Text != "" || tbFixedP.Text != "")
                {
                    if (tbFixedB.Text != "")
                        drNew["RangeFixPrice"] = Convert.ToDouble(tbFixedB.Text);
                    if (tbFixedP.Text != "")
                        drNew["RangeRelPrice"] = Convert.ToDouble(tbFixedP.Text);
                    drNew["IsFixPrice"] = rbFixedB.Checked == true ? "1" : "0";
                    drNew["CRID"] = Convert.ToInt32(label1.Tag);
                    drNew["OTGID"] = PrevOTGID;
                    drNew["COID_CID_OTGID_CRID"] = cbcCustomer.ComboField.drvSelectedItem[cbcCustomer.ValueMember].ToString() +
                        "_" + drNew["OTGID"].ToString() + "_" + drNew["CRID"].ToString();
                    drNew["CustomerOfficeID_CustomerID"] = cbcCustomer.ComboField.drvSelectedItem[cbcCustomer.ValueMember].ToString();
                }
            }

            foreach (Control cntrl in gbUnfixed.Controls)
            {
                string sFilter = "CRID=" + ((Price)cntrl).Tag.ToString() + " and " + "OTGID=" + PrevOTGID.ToString();
                DataRow[] adrSel = dsCustomerPrices.Tables[0].Select(sFilter);

                if (adrSel.Length == 0)
                {
                    try
                    {
                        Convert.ToDouble(((Price)cntrl).tbBuck.Text);
                    }
                    catch
                    {
                        if (((Price)cntrl).tbPercent.Text != "")
                            ((Price)cntrl).tbBuck.Text = "0";
                    }

                    try
                    {
                        Convert.ToDouble(((Price)cntrl).tbPercent.Text);
                    }
                    catch
                    {
                        if (((Price)cntrl).tbBuck.Text != "")
                            ((Price)cntrl).tbPercent.Text = "0";
                    }

                    if (((Price)cntrl).tbBuck.Text != "" || ((Price)cntrl).tbPercent.Text != "")
                    {
                        drNew = dsCustomerPrices.Tables[0].NewRow();
                        dsCustomerPrices.Tables[0].Rows.Add(drNew);
                        drNew["RangeFixPrice"] = Convert.ToDouble(((Price)cntrl).tbBuck.Text);
                        drNew["RangeRelPrice"] = Convert.ToDouble(((Price)cntrl).tbPercent.Text);
                        drNew["IsFixPrice"] = ((Price)cntrl).rbUnfixed01B.Checked == true ? "1" : "0";
                        drNew["CRID"] = Convert.ToInt32(((Price)cntrl).Tag);
                        drNew["OTGID"] = PrevOTGID;
                        drNew["COID_CID_OTGID_CRID"] = cbcCustomer.ComboField.drvSelectedItem[cbcCustomer.ValueMember].ToString() +
                            "_" + drNew["OTGID"].ToString() + "_" + drNew["CRID"].ToString();
                        drNew["CustomerOfficeID_CustomerID"] = cbcCustomer.ComboField.drvSelectedItem[cbcCustomer.ValueMember].ToString();
                    }
                }
                else
                {
                    drNew = adrSel[0];
                    if (((Price)cntrl).tbBuck.Text != "" || ((Price)cntrl).tbPercent.Text != "")
                    {
                        if (((Price)cntrl).tbBuck.Text != "")
                            drNew["RangeFixPrice"] = Convert.ToDouble(((Price)cntrl).tbBuck.Text);
                        if (((Price)cntrl).tbPercent.Text != "")
                            drNew["RangeRelPrice"] = Convert.ToDouble(((Price)cntrl).tbPercent.Text);
                        drNew["IsFixPrice"] = ((Price)cntrl).rbUnfixed01B.Checked == true ? "1" : "0";
                        drNew["CRID"] = Convert.ToInt32(((Price)cntrl).Tag);
                        drNew["OTGID"] = PrevOTGID;
                        drNew["COID_CID_OTGID_CRID"] = cbcCustomer.ComboField.drvSelectedItem[cbcCustomer.ValueMember].ToString() +
                            "_" + drNew["OTGID"].ToString() + "_" + drNew["CRID"].ToString();
                        drNew["CustomerOfficeID_CustomerID"] = cbcCustomer.ComboField.drvSelectedItem[cbcCustomer.ValueMember].ToString();
                    }
                }
            }
        }

        private void ReInitOpsTree()
        {
            //gbUnfixed.Visible = false;
            gbUnfixed.Controls.Clear();

            //drawing all Price-controls
            DataRow[] sortedRows = dsAllCaratRanges.Tables[0].Select("1=1", "CaratRangeMax");

            //debug_DisplayDataRowCollection(sortedRows);

            foreach (DataRow drRange in sortedRows/*dsAllCaratRanges.Tables[0].Rows*/)
            {
                /*
                if (Convert.IsDBNull(drRange["State"]) ||
                    !(drRange["State"].ToString().Equals("Deleted")))
                {
                */
                if (drRange["CaratRangeClass"].ToString() == "0")
                {
                    label1.Text = drRange["CaratRangeTitle"].ToString();
                    label1.Tag = drRange["CRID"].ToString();
                }
                else
                {
                    Price pNew = new Price();
                    pNew.lbInterval.Text = drRange["CaratRangeTitle"].ToString();
                    pNew.lbName.Text = "";
                    pNew.Tag = drRange["CRID"].ToString();
                    pNew.sCaratRangeMin = drRange["CaratRangeMin"].ToString();
                    pNew.sCaratRangeMax = drRange["CaratRangeMax"].ToString();

                    if (gbUnfixed.Controls.Count > 0)
                        pNew.Location = new Point(10, gbUnfixed.Controls[gbUnfixed.Controls.Count - 1].Location.Y + 50);
                    else
                        pNew.Location = new Point(10, 5);

                    gbUnfixed.Controls.Add(pNew);
                }
                //}
            }
            //gbUnfixed.Visible = true;
        }


        private void ptrOps_SelectionChanged(object sender, System.EventArgs e)
        {
            if (!rbFixed.Enabled)
                rbFixed.Enabled = true;

            if (!rbUnfixed.Enabled)
                rbUnfixed.Enabled = true;

            rbFixed.Checked = Convert.ToBoolean(ptrTree.SelectedRow["IsFixedPrice"]);
            rbUnfixed.Checked = !Convert.ToBoolean(ptrTree.SelectedRow["IsFixedPrice"]);
            DataRow drNew;

            //remembering prices for previous operation type and current customer

            string s = "CRID=" + label1.Tag.ToString() + " and " + "OTGID=" + PrevOTGID.ToString();
            DataRow[] adrSel1 = dsCustomerPrices.Tables[0].Select("CRID=" + label1.Tag.ToString() + " and " + "OTGID=" + PrevOTGID.ToString());

            if (adrSel1.Length == 0)
            {
                try
                {
                    Convert.ToDouble(tbFixedB.Text);
                }
                catch
                {
                    if (tbFixedP.Text != "")
                        tbFixedB.Text = "0";
                }

                try
                {
                    Convert.ToDouble(tbFixedP.Text);
                }
                catch
                {
                    if (tbFixedB.Text != "")
                        tbFixedP.Text = "0";
                }

                if (tbFixedB.Text != "" || tbFixedP.Text != "")
                {
                    drNew = dsCustomerPrices.Tables[0].NewRow();
                    dsCustomerPrices.Tables[0].Rows.Add(drNew);
                    if (tbFixedB.Text != "")
                        drNew["RangeFixPrice"] = Convert.ToDouble(tbFixedB.Text);
                    if (tbFixedP.Text != "")
                        drNew["RangeRelPrice"] = Convert.ToDouble(tbFixedP.Text);
                    drNew["IsFixPrice"] = rbFixedB.Checked == true ? "1" : "0";
                    drNew["CRID"] = Convert.ToInt32(label1.Tag);
                    drNew["OTGID"] = PrevOTGID;
                    drNew["COID_CID_OTGID_CRID"] = cbcCustomer.ComboField.drvSelectedItem[cbcCustomer.ValueMember].ToString() +
                        "_" + drNew["OTGID"].ToString() + "_" + drNew["CRID"].ToString();
                    drNew["CustomerOfficeID_CustomerID"] = cbcCustomer.ComboField.drvSelectedItem[cbcCustomer.ValueMember].ToString();
                }
            }
            else
            {
                drNew = adrSel1[0];
                if (tbFixedB.Text != "" || tbFixedP.Text != "")
                {
                    if (tbFixedB.Text != "")
                        drNew["RangeFixPrice"] = Convert.ToDouble(tbFixedB.Text);
                    if (tbFixedP.Text != "")
                        drNew["RangeRelPrice"] = Convert.ToDouble(tbFixedP.Text);
                    drNew["IsFixPrice"] = rbFixedB.Checked == true ? "1" : "0";
                    drNew["CRID"] = Convert.ToInt32(label1.Tag);
                    drNew["OTGID"] = PrevOTGID;
                    drNew["COID_CID_OTGID_CRID"] = cbcCustomer.ComboField.drvSelectedItem[cbcCustomer.ValueMember].ToString() +
                        "_" + drNew["OTGID"].ToString() + "_" + drNew["CRID"].ToString();
                    drNew["CustomerOfficeID_CustomerID"] = cbcCustomer.ComboField.drvSelectedItem[cbcCustomer.ValueMember].ToString();
                }
            }

            foreach (Control cntrl in gbUnfixed.Controls)
            {

                string sFilter = "CRID=" + ((Price)cntrl).Tag.ToString() + " and " + "OTGID=" + PrevOTGID.ToString();
                DataRow[] adrSel = dsCustomerPrices.Tables[0].Select(sFilter);

                if (adrSel.Length == 0)
                {
                    try
                    {
                        Convert.ToDouble(((Price)cntrl).tbBuck.Text);
                    }
                    catch
                    {
                        if (((Price)cntrl).tbPercent.Text != "")
                            ((Price)cntrl).tbBuck.Text = "0";
                    }

                    try
                    {
                        Convert.ToDouble(((Price)cntrl).tbPercent.Text);
                    }
                    catch
                    {
                        if (((Price)cntrl).tbBuck.Text != "")
                            ((Price)cntrl).tbPercent.Text = "0";
                    }

                    if (((Price)cntrl).tbBuck.Text != "" || ((Price)cntrl).tbPercent.Text != "")
                    {
                        drNew = dsCustomerPrices.Tables[0].NewRow();
                        dsCustomerPrices.Tables[0].Rows.Add(drNew);
                        drNew["RangeFixPrice"] = Convert.ToDouble(((Price)cntrl).tbBuck.Text);
                        drNew["RangeRelPrice"] = Convert.ToDouble(((Price)cntrl).tbPercent.Text);
                        drNew["IsFixPrice"] = ((Price)cntrl).rbUnfixed01B.Checked == true ? "1" : "0";
                        drNew["CRID"] = Convert.ToInt32(((Price)cntrl).Tag);
                        drNew["OTGID"] = PrevOTGID;
                        drNew["COID_CID_OTGID_CRID"] = cbcCustomer.ComboField.drvSelectedItem[cbcCustomer.ValueMember].ToString() +
                            "_" + drNew["OTGID"].ToString() + "_" + drNew["CRID"].ToString();
                        drNew["CustomerOfficeID_CustomerID"] = cbcCustomer.ComboField.drvSelectedItem[cbcCustomer.ValueMember].ToString();
                    }
                }
                else
                {
                    drNew = adrSel[0];
                    if (((Price)cntrl).tbBuck.Text != "" || ((Price)cntrl).tbPercent.Text != "")
                    {
                        if (((Price)cntrl).tbBuck.Text != "")
                            drNew["RangeFixPrice"] = Convert.ToDouble(((Price)cntrl).tbBuck.Text);
                        if (((Price)cntrl).tbPercent.Text != "")
                            drNew["RangeRelPrice"] = Convert.ToDouble(((Price)cntrl).tbPercent.Text);
                        drNew["IsFixPrice"] = ((Price)cntrl).rbUnfixed01B.Checked == true ? "1" : "0";
                        drNew["CRID"] = Convert.ToInt32(((Price)cntrl).Tag);
                        drNew["OTGID"] = PrevOTGID;
                        drNew["COID_CID_OTGID_CRID"] = cbcCustomer.ComboField.drvSelectedItem[cbcCustomer.ValueMember].ToString() +
                            "_" + drNew["OTGID"].ToString() + "_" + drNew["CRID"].ToString();
                        drNew["CustomerOfficeID_CustomerID"] = cbcCustomer.ComboField.drvSelectedItem[cbcCustomer.ValueMember].ToString();
                    }
                }
            }

            //clear range-prices for current operation type
            foreach (Control cntrl in gbUnfixed.Controls)
            {
                ((Price)cntrl).rbUnfixed01B.Checked = true;
                ((Price)cntrl).lbName.Text = "";
                ((Price)cntrl).tbPercent.Text = "";
                ((Price)cntrl).tbBuck.Text = "";

                tbFixedB.Text = "";
                tbFixedP.Text = "";
                rbFixedB.Checked = true;
            }

            //filling range-prices for current operation type
            foreach (DataRow drRange in dsOTGRP.Tables[0].Rows)
            {
                if (drRange["CaratRangeClass"].ToString() == "0")
                {
                    label1.Text = drRange["CaratRangeTitle"].ToString();
                    label1.Tag = drRange["CRID"].ToString();
                    if (drRange["OTGID"].ToString() == ptrTree.SelectedRow["ID"].ToString())
                    {
                        lbFixedCaratPrice.Text = Convert.ToDouble(drRange["RangePrice"]).ToString(".##");
                    }
                }
                else
                {
                    if (drRange["OTGID"].ToString() == ptrTree.SelectedRow["ID"].ToString())
                    {
                        foreach (Control cntrl in gbUnfixed.Controls)
                        {
                            ((Price)cntrl).lbName.Text = "";
                            if (((Price)cntrl).Tag.ToString() == drRange["CRID"].ToString())
                                ((Price)cntrl).lbName.Text = Convert.ToDouble(drRange["RangePrice"]).ToString(".##");
                        }
                    }
                }
            }

            //filling prices for current customer and current operation type
            foreach (DataRow drPrices in dsCustomerPrices.Tables[0].Rows)
            {
                if (drPrices["OTGID"].ToString() == ptrTree.SelectedRow["ID"].ToString())
                {
                    foreach (Control cntrl in gbUnfixed.Controls)
                    {
                        if (label1.Tag.ToString() == drPrices["CRID"].ToString())
                        {
                            rbFixedB.Checked = Convert.ToBoolean(drPrices["IsFixPrice"]);
                            rbFixedP.Checked = !Convert.ToBoolean(drPrices["IsFixPrice"]);
                            tbFixedB.Text = Convert.ToDouble(drPrices["RangeFixPrice"]).ToString(".##");
                            tbFixedP.Text = Convert.ToDouble(drPrices["RangeRelPrice"]).ToString(".##");
                        }

                        if (((Price)cntrl).Tag.ToString() == drPrices["CRID"].ToString())
                        {
                            ((Price)cntrl).rbUnfixed01B.Checked = Convert.ToBoolean(drPrices["IsFixPrice"]);
                            ((Price)cntrl).rbUnfixed01P.Checked = !Convert.ToBoolean(drPrices["IsFixPrice"]);
                            ((Price)cntrl).tbBuck.Text = Convert.ToDouble(drPrices["RangeFixPrice"]).ToString(".##");
                            ((Price)cntrl).tbPercent.Text = Convert.ToDouble(drPrices["RangeRelPrice"]).ToString(".##");
                        }
                    }
                }
            }
            PrevOTGID = Convert.ToInt32(ptrTree.SelectedRow["OTGID"]);

            rbFixed.Checked = Convert.ToBoolean(ptrTree.SelectedRow["IsFixedPrice"]);
        }

        private void ShowPrices(DataRow[] drSet)
        {
            int Y = 10;

            gbUnfixed.Controls.Clear();

            foreach (DataRow drPrice in drSet)
            {
                Price prNew = new Price();
                prNew.Location = new Point(10, Y);
                prNew.Size = new Size(455, 40);
                prNew.lbInterval.Text = drPrice["Interval"].ToString();
                prNew.lbName.Text = drPrice["Name"].ToString();
                prNew.rbUnfixed01B.Checked = Convert.ToBoolean(drPrice["Buck"]);
                prNew.rbUnfixed01P.Checked = Convert.ToBoolean(drPrice["Percent"]);
                prNew.tbBuck.Text = drPrice["BuckValue"].ToString();
                prNew.tbBuck.Leave += new EventHandler(tbBuck_Leave);
                prNew.tbPercent.Text = drPrice["PercentValue"].ToString();
                prNew.tbPercent.Leave += new EventHandler(tbPercent_Leave);

                gbUnfixed.Controls.Add(prNew);

                Y += 50;

            }
        }

        private void tbBuck_Leave(object sender, EventArgs e)
        {
            TextBox tbValue = (TextBox)sender;
            DataRow row = dsOpsPrcs.Tables["Prices"].Select("ID = '" + tbValue.Tag.ToString() + "'")[0];
            row["Buck"] = tbValue.Text;
        }

        private void tbPercent_Leave(object sender, EventArgs e)
        {
            TextBox tbValue = (TextBox)sender;
            DataRow row = dsOpsPrcs.Tables["Prices"].Select("ID = '" + tbValue.Tag.ToString() + "'")[0];
            row["Percent"] = tbValue.Text;
        }

        private void gbUnfixed_Leave(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Ready";
            DataRow drNew;

            //remembering prices for previous operation type and current customer

            DataRow[] adrSel1 = dsCustomerPrices.Tables[0].Select("CRID=" + label1.Tag.ToString() + " and " + "OTGID=" + PrevOTGID.ToString());

            if (adrSel1.Length == 0)
            {
                try
                {
                    Convert.ToDouble(tbFixedB.Text);
                }
                catch
                {
                    if (tbFixedP.Text != "")
                        tbFixedB.Text = "0";
                }

                try
                {
                    Convert.ToDouble(tbFixedP.Text);
                }
                catch
                {
                    if (tbFixedB.Text != "")
                        tbFixedP.Text = "0";
                }

                if (tbFixedB.Text != "" || tbFixedP.Text != "")
                {
                    drNew = dsCustomerPrices.Tables[0].NewRow();
                    dsCustomerPrices.Tables[0].Rows.Add(drNew);
                    if (tbFixedB.Text != "")
                        drNew["RangeFixPrice"] = Convert.ToDouble(tbFixedB.Text);
                    if (tbFixedP.Text != "")
                        drNew["RangeRelPrice"] = Convert.ToDouble(tbFixedP.Text);
                    drNew["IsFixPrice"] = rbFixedB.Checked == true ? "1" : "0";
                    drNew["CRID"] = Convert.ToInt32(label1.Tag);
                    drNew["OTGID"] = PrevOTGID;
                    drNew["COID_CID_OTGID_CRID"] = cbcCustomer.ComboField.drvSelectedItem[cbcCustomer.ValueMember].ToString() +
                        "_" + drNew["OTGID"].ToString() + "_" + drNew["CRID"].ToString();
                    drNew["CustomerOfficeID_CustomerID"] = cbcCustomer.ComboField.drvSelectedItem[cbcCustomer.ValueMember].ToString();
                }
            }
            else
            {
                drNew = adrSel1[0];
                if (tbFixedB.Text != "" || tbFixedP.Text != "")
                {
                    if (tbFixedB.Text != "")
                        drNew["RangeFixPrice"] = Convert.ToDouble(tbFixedB.Text);
                    if (tbFixedP.Text != "")
                        drNew["RangeRelPrice"] = Convert.ToDouble(tbFixedP.Text);
                    drNew["IsFixPrice"] = rbFixedB.Checked == true ? "1" : "0";
                    drNew["CRID"] = Convert.ToInt32(label1.Tag);
                    drNew["OTGID"] = PrevOTGID;
                    drNew["COID_CID_OTGID_CRID"] = cbcCustomer.ComboField.drvSelectedItem[cbcCustomer.ValueMember].ToString() +
                        "_" + drNew["OTGID"].ToString() + "_" + drNew["CRID"].ToString();
                    drNew["CustomerOfficeID_CustomerID"] = cbcCustomer.ComboField.drvSelectedItem[cbcCustomer.ValueMember].ToString();
                }
            }

            foreach (Control cntrl in gbUnfixed.Controls)
            {
                DataRow[] adrSel = dsCustomerPrices.Tables[0].Select("CRID=" + ((Price)cntrl).Tag.ToString() + " and " + "OTGID=" + PrevOTGID.ToString());

                if (adrSel.Length == 0)
                {
                    try
                    {
                        Convert.ToDouble(((Price)cntrl).tbBuck.Text);
                    }
                    catch
                    {
                        if (((Price)cntrl).tbPercent.Text != "")
                            ((Price)cntrl).tbBuck.Text = "0";
                    }

                    try
                    {
                        Convert.ToDouble(((Price)cntrl).tbPercent.Text);
                    }
                    catch
                    {
                        if (((Price)cntrl).tbBuck.Text != "")
                            ((Price)cntrl).tbPercent.Text = "0";
                    }

                    if (((Price)cntrl).tbBuck.Text != "" || ((Price)cntrl).tbPercent.Text != "")
                    {
                        drNew = dsCustomerPrices.Tables[0].NewRow();
                        dsCustomerPrices.Tables[0].Rows.Add(drNew);
                        drNew["RangeFixPrice"] = Convert.ToDouble(((Price)cntrl).tbBuck.Text);
                        drNew["RangeRelPrice"] = Convert.ToDouble(((Price)cntrl).tbPercent.Text);
                        drNew["IsFixPrice"] = ((Price)cntrl).rbUnfixed01B.Checked == true ? "1" : "0";
                        drNew["CRID"] = Convert.ToInt32(((Price)cntrl).Tag);
                        drNew["OTGID"] = PrevOTGID;
                        drNew["COID_CID_OTGID_CRID"] = cbcCustomer.ComboField.drvSelectedItem[cbcCustomer.ValueMember].ToString() +
                            "_" + drNew["OTGID"].ToString() + "_" + drNew["CRID"].ToString();
                        drNew["CustomerOfficeID_CustomerID"] = cbcCustomer.ComboField.drvSelectedItem[cbcCustomer.ValueMember].ToString();
                    }
                }
                else
                {
                    drNew = adrSel[0];
                    if (((Price)cntrl).tbBuck.Text != "" || ((Price)cntrl).tbPercent.Text != "")
                    {
                        if (((Price)cntrl).tbBuck.Text != "")
                            drNew["RangeFixPrice"] = Convert.ToDouble(((Price)cntrl).tbBuck.Text);
                        if (((Price)cntrl).tbPercent.Text != "")
                            drNew["RangeRelPrice"] = Convert.ToDouble(((Price)cntrl).tbPercent.Text);
                        drNew["IsFixPrice"] = ((Price)cntrl).rbUnfixed01B.Checked == true ? "1" : "0";
                        drNew["CRID"] = Convert.ToInt32(((Price)cntrl).Tag);
                        drNew["OTGID"] = PrevOTGID;
                        drNew["COID_CID_OTGID_CRID"] = cbcCustomer.ComboField.drvSelectedItem[cbcCustomer.ValueMember].ToString() +
                            "_" + drNew["OTGID"].ToString() + "_" + drNew["CRID"].ToString();
                        drNew["CustomerOfficeID_CustomerID"] = cbcCustomer.ComboField.drvSelectedItem[cbcCustomer.ValueMember].ToString();
                    }
                }
            }
        }

        private void gbFixed_Leave(object sender, System.EventArgs e)
        {
            gbUnfixed_Leave(this, EventArgs.Empty);
            sbStatus.Text = "Ready";
        }


        #endregion PricesTab


        #region HistoryTab
        private void DrawHistory(int filter)
        {
            Couple cplCustomer = new Couple();
            cplCustomer.FieldName = "CustomerCode";
            cplCustomer.FieldValue = cbcCustomer.ComboField.drvSelectedItem[cbcCustomer.CodeMember].ToString();
            ordersTree1.Initialize(Service.GetOrderTreeDataByCode(new Couple[] { cplCustomer }));
            //ordersTree1.Update();
        }
        #endregion HistoryTab


        #region StatusBar
        private void tbCompany_Enter(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Customer's company name";
            tbCompany.SelectionStart = 0;
            tbCompany.SelectionLength = tbCompany.Text.Length;
        }

        private void locCustomer_Enter(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Customer's company address";
        }

        private void tbPhone1_Enter(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Customer's company phone number";
            tbPhone1.SelectAll();
        }

        private void tbFax1_Enter(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Customer's company fax number";
            tbFax1.SelectAll();
        }

        private void tbEmail_Enter(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Customer's company e-mail";
            tbEmail.SelectAll();
        }

        private void tbID_Enter(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Customer's ID";
        }

        private void tbStartDate_Enter(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Start date";
        }

        private void cbBusiness_Enter(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Business type";
        }

        private void cbIndustry_Enter(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Industry membership";
        }

        private void cCustomer_Enter(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Customer's prefered method of communication";
        }

        private void groupBox5_Enter(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Customer's permissions";
        }

        private void gbRBs_Enter(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Goods movement";
        }

        private void chbUseTheirAccount_Enter(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Using customer's account";
        }

        private void tbAccountNumber_Enter(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Customer's account number";
            tbAccountNumber.SelectAll();
        }

        private void cbCarrier_Enter(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Goods carrier";
        }

        private void lbxIndustry_Enter(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Industry membership";
        }

        private void liPersons_Enter(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Company persons";
        }

        private void tbPFirstName_Enter(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Person's first name";
            tbPFirstName.SelectAll();
        }

        private void tbPLastName_Enter(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Person's last name";
            tbPLastName.SelectAll();
        }

        private void cbPPosition_Enter(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Person's position in company";
        }

        private void tbPID_Enter(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Person's ID";
        }

        private void tbPBirthDate_Enter(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Person's birthdate";
        }

        private void tbPPhone1_Enter(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Person's phone number";
            tbPPhone1.SelectAll();
        }

        private void tbPFax1_Enter(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Person's fax number";
            tbFax1.SelectAll();
        }

        private void tbPCell1_Enter(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Person's cellphone number";
            tbPCell1.SelectAll();
        }

        private void tbPEmail_Enter(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Person's e-mail";
            tbPEmail.SelectAll();
        }

        private void locPerson_Enter(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Person's location";
        }

        private void cPerson_Enter(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Person's preffered methods of communication";
        }

        private void tbPWebLogin_Enter(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Person's web-login";
            tbPWebLogin.SelectAll();
        }

        private void tbPWebPwd_Enter(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Person's password for web";
            tbPWebPwd.SelectAll();
        }

        private void tbPRetypePwd_Enter(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Retype password to be sure";
            tbPRetypePwd.SelectAll();
        }

        private void prmPerson_Enter(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Person's permissions";
        }

        private void tbPhone2_Enter(object sender, System.EventArgs e)
        {
            tbPhone2.SelectAll();
        }

        private void tbPPhone3_Enter(object sender, System.EventArgs e)
        {
            tbPPhone3.SelectAll();
        }

        private void tbPPhone4_Enter(object sender, System.EventArgs e)
        {
            tbPPhone4.SelectAll();
        }

        private void tbPhoneExt_Enter(object sender, System.EventArgs e)
        {
            tbPhoneExt.SelectAll();
        }

        private void tbPFax2_Enter(object sender, System.EventArgs e)
        {
            tbPFax2.SelectAll();
        }

        private void tbPFax3_Enter(object sender, System.EventArgs e)
        {
            tbPFax3.SelectAll();
        }

        private void tbPFax4_Enter(object sender, System.EventArgs e)
        {
            tbPFax4.SelectAll();
        }

        private void tbPhone3_Enter(object sender, System.EventArgs e)
        {
            tbPhone3.SelectAll();
        }

        private void tbPhone4_Enter(object sender, System.EventArgs e)
        {
            tbPhone4.SelectAll();
        }

        private void tbFax2_Enter(object sender, System.EventArgs e)
        {
            tbFax2.SelectAll();
        }

        private void tbFax3_Enter(object sender, System.EventArgs e)
        {
            tbFax3.SelectAll();
        }

        private void tbFax4_Enter(object sender, System.EventArgs e)
        {
            tbFax4.SelectAll();
        }

        private void tbPPhone2_Enter(object sender, System.EventArgs e)
        {
            tbPPhone2.SelectAll();
        }

        private void tbPCell2_Enter(object sender, System.EventArgs e)
        {
            tbPCell2.SelectAll();
        }

        private void tbPCell3_Enter(object sender, System.EventArgs e)
        {
            tbPCell3.SelectAll();
        }

        private void tbPCell4_Enter(object sender, System.EventArgs e)
        {
            tbPCell4.SelectAll();
        }

        private void tbPhone2_TextChanged(object sender, System.EventArgs e)
        {
            if (tbPhone2.Text.Length == 3) tbPhone3.Focus();
        }

        private void tbPhone3_TextChanged(object sender, System.EventArgs e)
        {
            if (tbPhone3.Text.Length == 3) tbPhone4.Focus();
        }

        private void tbFax2_TextChanged(object sender, System.EventArgs e)
        {
            if (tbFax2.Text.Length == 3) tbFax3.Focus();
        }

        private void tbFax3_TextChanged(object sender, System.EventArgs e)
        {
            if (tbFax3.Text.Length == 3) tbFax4.Focus();
        }

        private void tbPPhone2_TextChanged(object sender, System.EventArgs e)
        {
            if (tbPPhone2.Text.Length == 3) tbPPhone3.Focus();
        }

        private void tbPPhone3_TextChanged(object sender, System.EventArgs e)
        {
            if (tbPPhone3.Text.Length == 3) tbPPhone4.Focus();
        }

        private void tbPFax2_TextChanged(object sender, System.EventArgs e)
        {
            if (tbPFax2.Text.Length == 3) tbPFax3.Focus();
        }

        private void tbPFax3_TextChanged(object sender, System.EventArgs e)
        {
            if (tbPFax3.Text.Length == 3) tbPFax4.Focus();
        }

        private void tbPCell2_TextChanged(object sender, System.EventArgs e)
        {
            if (tbPCell2.Text.Length == 3) tbPCell3.Focus();
        }

        private void tbPCell3_TextChanged(object sender, System.EventArgs e)
        {
            if (tbPCell3.Text.Length == 3) tbPCell4.Focus();
        }
        private void ControlFocusLeave(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Ready";
        }
        private void cbcCustomer_Enter(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Customer lookup";
        }

        private void prmCustomer_Enter(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Customer permissions";
        }

        private void ordersTree1_Enter(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Orders history";
        }

        private void ptrTree_Enter(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Available operations";
        }

        private void gbFixed_Enter(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Fixed price";
        }

        private void gbUnfixed_Enter(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Unfixed prices";
        }

        private void tabPage3_Enter(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Customer prices";
        }

        private void tabPage2_Enter(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Customer history";
        }

        private void tabPage1_Enter(object sender, System.EventArgs e)
        {
            sbStatus.Text = "Customer";
        }
        #endregion StatusBar


        private bool FieldsOK(ref string wrongField)
        {
            try
            {
                Convert.ToInt32(locCustomer.tbZip1.Text);
            }
            catch
            {
                if (MessageBox.Show("Zip code has letters. Is it OK?", "Zip Code has letters",
                                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    return true;
                }
                wrongField = "Zip code must be numeric";
                return false;
            }

            try
            {
                Convert.ToInt32(tbPhone2.Text);
                Convert.ToInt32(tbPhone3.Text);
                Convert.ToInt32(tbPhone4.Text);
            }
            catch
            {
                wrongField = "Phone number must be numeric";
                return false;
            }

            try
            {
                Convert.ToInt32(tbFax2.Text);
                Convert.ToInt32(tbFax3.Text);
                Convert.ToInt32(tbFax4.Text);
            }
            catch
            {
                wrongField = "Fax number must be numeric";
                return false;
            }

            if (tbCompany.Text == "")
            {
                wrongField = "Company Name must be filled";
                return false;
            }
            if (tbShortName.Text == "")
            {
                wrongField = "Short Name must be filled";
                return false;
            }

            if (locCustomer.cbState.Enabled && locCustomer.cbState.SelectedValue == null)
            {
                wrongField = "State must be selected for US";
                return false;
            }

            if (locCustomer.tbCountry.Text == "")
            {
                wrongField = "Country must be filled";
                return false;
            }

            if (locCustomer.tbAddress.Text == "")
            {
                wrongField = "Address must be filled";
                return false;
            }

            if (locCustomer.tbZip1.Text.Length < 5)
            {
                wrongField = "Zip code must be filled with 5 numbers";
                return false;
            }

            if (locCustomer.tbCity.Text == "")
            {
                wrongField = "City must be filled";
                return false;
            }

            if (tbPhone1.Text == "+" || tbPhone2.Text.Length < 3 || tbPhone3.Text.Length < 3 || tbPhone4.Text == "")
            {
                wrongField = "Phone number must be in '+n nnn nnn nnnn'-format";
                return false;
            }
            if (cbBusiness.SelectedValue == null)
            {
                wrongField = "Business type must be selected";
                return false;
            }
            if (!(!rbWeCarry.Checked || !rbTheyCarry.Checked || !rbWeShip.Checked))
            {
                wrongField = "One of the Goods movement methods must be selected";
                return false;
            }

            if (chbUseTheirAccount.Checked && (tbAccountNumber.Text == "" || cbCarrier.SelectedValue == null))
            {
                wrongField = "Account number must be filled and Carrier selected";
                return false;
            }

            if (tbEmail.Text != "")
            {
                if (tbEmail.Text.Split(new char[] { '.' }).Length >= 2)
                {
                    string domen = tbEmail.Text.Substring(tbEmail.Text.LastIndexOf('.') + 1);

                    if (tbEmail.Text != "" && (tbEmail.Text.Split(new char[] { '@' }).Length != 2 ||
                        domen.Length > 3 || domen.Length < 2))
                    {
                        wrongField = "Email address has wrong format";
                        return false;
                    }
                }
                else
                {
                    wrongField = "Email address has wrong format";
                    return false;
                }
            }
            return true;
        }

        private bool IsWebLoginExists()
        {
            if (tbPWebLogin.Text.ToString().Length == 0)
            {
                tbPWebPwd.Text = "";
                this.tbPRetypePwd.Text = "";
                return false;
            }

            try
            {
                DataSet dsIn = new DataSet();
                DataTable dtIn = dsIn.Tables.Add("PersonWebLogin");
                dtIn.Columns.Add("WebLogin", dtPerson.Columns["WebLogin"].DataType);
                dtIn.Columns.Add("WebPwd", dtPerson.Columns["WebLogin"].DataType);
                dtIn.Columns.Add("P", System.Type.GetType("System.String"));

                string str;
                str = "";
                if (!IsNewPerson)
                {
                    int iRowNumber = liPersons.SelectedIndices[0];
                    str = dtPerson.Rows[iRowNumber]["PersonCustomerOfficeID_PersonCustomerID_PersonID"].ToString();
                }

                DataRow row = dtIn.NewRow();
                row["WebLogin"] = tbPWebLogin.Text;
                row["WebPwd"] = tbPWebPwd.Text;
                row["P"] = str;

                dtIn.Rows.Add(row);
                DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);

                if (dsOut.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Unable to check web login existance" + exc.Message, "Internal Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }

        private void btnAddRange_Click(object sender, System.EventArgs e)
        {
            try
            {
                //MessageBox.Show(dsAllCaratRanges.Tables[0].Rows.Count.ToString());

                NewCaratRange frm = new NewCaratRange();
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    string sRange = frm.GetCaratRange();
                    Decimal min, max;
                    try
                    {
                        char sSeparator = '-';
                        string[] sRangeArray = sRange.Split(sSeparator);
                        min = System.Convert.ToDecimal(sRangeArray[0]);
                        max = System.Convert.ToDecimal(sRangeArray[1]);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, "Can't convert range. Reason: " + ex.ToString(),
                            "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (!CheckRange(min, max))
                    {
                        MessageBox.Show(this, "Carat range cannot be added",
                            "Wrong range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    String sCaratRangeClass = "1";
                    String sCaratRangeMin = min.ToString();
                    String sCaratRangeMax = max.ToString();
                    String sCRID = AddCaratRange(sCaratRangeClass, sRange,
                        sCaratRangeMin, sCaratRangeMax);

                    DataRow newRow = dsAllCaratRanges.Tables[0].NewRow();
                    newRow[0] = sCRID;
                    newRow[1] = sCaratRangeClass;
                    newRow[2] = sRange;
                    newRow[3] = min;
                    newRow[4] = max;
                    //newRow["State"] = "Added";
                    dsAllCaratRanges.Tables[0].Rows.Add(newRow);

                    /*
                    string sFilter = "CaratRangeMax=" + max.ToString() + " AND CaratRangeMin=" +
                        min.ToString();
                    DataRow[] dataRow = dsAllCaratRanges.Tables[0].Select(sFilter);
                    if (dataRow.Length != 0)
                    {
                        if (dataRow[0]["State"].ToString().Equals("Deleted"))
                        {
                            dataRow[0]["State"] = "Unchanged";
                        }
                    }
                    else
                    {

                        DataRow newRow = dsAllCaratRanges.Tables[0].NewRow();
                        //DataRow[] foundRows = dsAllCaratRanges.Tables[0].Select("MAX(CRID)");
                        //foundRows.Length == 1;
                        newRow[0] = "123";
                        //dsAllCaratRanges.Tables[0].Rows.Count * 2 + 1;
                        //(Decimal)foundRows[0]["CRID"] + 1;
                        newRow[1] = "1";
                        newRow[2] = sRange;
                        newRow[3] = min;
                        newRow[4] = max;
                        newRow["State"] = "Added";
                        dsAllCaratRanges.Tables[0].Rows.Add(newRow);
                    }
                    */

                    ReInitOpsTree();
                    FillCustomerPrices();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Internal error: " + ex.ToString(),
                    "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillCustomerPrices()
        {
            //gemoDream.Service.debug_DiaspalyDataSet(dsCustomerPrices);

            foreach (DataRow drPrices in dsCustomerPrices.Tables[0].Rows)
            {
                if (drPrices["OTGID"].ToString() == ptrTree.SelectedRow["ID"].ToString())
                {
                    foreach (Control cntrl in gbUnfixed.Controls)
                    {
                        if (label1.Tag.ToString() == drPrices["CRID"].ToString())
                        {
                            rbFixedB.Checked = Convert.ToBoolean(drPrices["IsFixPrice"]);
                            rbFixedP.Checked = !Convert.ToBoolean(drPrices["IsFixPrice"]);
                            tbFixedB.Text = Convert.ToDouble(drPrices["RangeFixPrice"]).ToString(".##");
                            tbFixedP.Text = Convert.ToDouble(drPrices["RangeRelPrice"]).ToString(".##");
                        }

                        if (((Price)cntrl).Tag.ToString() == drPrices["CRID"].ToString())
                        {
                            ((Price)cntrl).rbUnfixed01B.Checked = Convert.ToBoolean(drPrices["IsFixPrice"]);
                            ((Price)cntrl).rbUnfixed01P.Checked = !Convert.ToBoolean(drPrices["IsFixPrice"]);
                            ((Price)cntrl).tbBuck.Text = Convert.ToDouble(drPrices["RangeFixPrice"]).ToString(".##");
                            ((Price)cntrl).tbPercent.Text = Convert.ToDouble(drPrices["RangeRelPrice"]).ToString(".##");
                        }
                    }
                }
            }
        }

        private void btnDelRange_Click(object sender, System.EventArgs e)
        {
            try
            {
                Cntrls.Price price = null;
                foreach (Control ctrl in gbUnfixed.Controls)
                {
                    price = (Cntrls.Price)ctrl;
                    if (price.cbInterval.Checked)
                    {
                        string s = cbcCustomer.SelectedID;

                        char cSeparator = '_';
                        string[] sIDs = s.Split(cSeparator);

                        string sCID = sIDs[1];
                        string sCOID = sIDs[0];

                        string sCRID = price.Tag.ToString();

                        string sFilter = "CRID=" + sCRID;
                        DataRow[] dr = this.dsAllCaratRanges.Tables[0].Select(sFilter);

                        try
                        {
                            DataSet dsIn = new DataSet();
                            DataTable dtIn = dsIn.Tables.Add("CaratRange");
                            dtIn.Columns.Add("CaratRangeClass", System.Type.GetType("System.String"));
                            dtIn.Columns.Add("CaratRangeTitle", System.Type.GetType("System.String"));
                            dtIn.Columns.Add("CaratRangeMin", System.Type.GetType("System.String"));
                            dtIn.Columns.Add("CaratRangeMax", System.Type.GetType("System.String"));
                            dtIn.Columns.Add("CID", System.Type.GetType("System.String"));
                            dtIn.Columns.Add("COID", System.Type.GetType("System.String"));
                            dtIn.Columns.Add("CPID", System.Type.GetType("System.String"));
                            dtIn.Columns.Add("CPOfficeID", System.Type.GetType("System.String"));
                            dtIn.Columns.Add("CRID", System.Type.GetType("System.String"));
                            dtIn.Columns.Add("ExpireDate", System.Type.GetType("System.String"));

                            DataRow row = dtIn.NewRow();
                            row["CaratRangeClass"] = dr[0]["CaratRangeClass"];
                            row["CaratRangeTitle"] = dr[0]["CaratRangeTitle"];
                            row["CaratRangeMin"] = dr[0]["CaratRangeMin"];
                            row["CaratRangeMax"] = dr[0]["CaratRangeMax"];
                            row["CID"] = sCID;
                            row["COID"] = sCOID;
                            row["CPID"] = DBNull.Value;
                            row["CPOfficeID"] = DBNull.Value;
                            row["CRID"] = sCRID;
                            row["ExpireDate"] = DateTime.Today;

                            dtIn.Rows.Add(row);

                            DataSet dsOut = Service.ProxyGenericSet(dsIn, "Set");

                            string sDeleteFilter = "CRID=" + sCRID;
                            DataRow[] deletePrice = dsCustomerPrices.Tables[0].Select(sDeleteFilter);
                            if (deletePrice.Length > 0)
                            {
                                dsCustomerPrices.Tables[0].Rows.Remove(deletePrice[0]);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(this, "Can't get carat range ID. Reason: " + ex.ToString(),
                                "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        //string sCRID = price.Tag.ToString();
                        //String sFilter = "CRID=" + sCRID;
                        dr = dsAllCaratRanges.Tables[0].Select(sFilter);

                        dsAllCaratRanges.Tables[0].Rows.Remove(dr[0]);

                        /*
                        string sCRID = price.Tag.ToString();
                        string sCaratRangeMin = price.sCaratRangeMin;
                        string sCaratRangeMax = price.sCaratRangeMax;
                        String sFilter = null;
                        if (sCRID.Equals("123"))
                        {
                            sFilter = "CaratRangeMin=" + sCaratRangeMin +
                                "and CaratRangeMax=" + sCaratRangeMax;

                        }
                        else
                            sFilter = "CRID=" + sCRID;
                        //String sFilter = "CaratRangeMin=" + 
                        DataRow[] dr = dsAllCaratRanges.Tables[0].Select(sFilter);
                        dr[0]["State"] = "Deleted";
                        */
                        //dsAllCaratRanges.Tables[0].Rows.Remove(dr[0]);
                        //dsAllCaratRanges.Tables[0].N
                    }
                }
                ReInitOpsTree();
                FillCustomerPrices();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Can't delete range. Reason: " + ex.ToString(),
                    "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private String AddCaratRange(String sCaratRangeClass,
            String sCaratRangeTitle, String sCaratRangeMin,
            String sCaratRangeMax)
        {
            if (!IsNewCustomer)
            {
                string s = cbcCustomer.SelectedID;

                char cSeparator = '_';
                string[] sIDs = s.Split(cSeparator);

                string sCID = sIDs[1];
                string sCOID = sIDs[0];

                try
                {
                    DataSet dsIn = new DataSet();
                    DataTable dtIn = dsIn.Tables.Add("CaratRange");
                    //dtIn.Columns.Add("AuthorID",  System.Type.GetType("System.String"));
                    //dtIn.Columns.Add("AuthorOfficeID",  System.Type.GetType("System.String"));
                    dtIn.Columns.Add("CaratRangeClass", System.Type.GetType("System.String"));
                    dtIn.Columns.Add("CaratRangeTitle", System.Type.GetType("System.String"));
                    dtIn.Columns.Add("CaratRangeMin", System.Type.GetType("System.String"));
                    dtIn.Columns.Add("CaratRangeMax", System.Type.GetType("System.String"));
                    dtIn.Columns.Add("CID", System.Type.GetType("System.String"));
                    dtIn.Columns.Add("COID", System.Type.GetType("System.String"));
                    dtIn.Columns.Add("CPID", System.Type.GetType("System.String"));
                    dtIn.Columns.Add("CPOfficeID", System.Type.GetType("System.String"));
                    dtIn.Columns.Add("CRID", System.Type.GetType("System.String"));
                    dtIn.Columns.Add("ExpireDate", System.Type.GetType("System.String"));
                    //dtIn.Columns.Add("CRID", System.Type.GetType("System.String"));
                    DataRow row = dtIn.NewRow();
                    //row["AuthorID"] = str;
                    //row["AuthorOfficeID"] = str;
                    row["CaratRangeClass"] = sCaratRangeClass;//drRange["CaratRangeClass"];
                    row["CaratRangeTitle"] = sCaratRangeTitle;//drRange["CaratRangeTitle"];
                    row["CaratRangeMin"] = sCaratRangeMin;//drRange["CaratRangeMin"];
                    row["CaratRangeMax"] = sCaratRangeMax;//drRange["CaratRangeMax"];
                    row["CID"] = sCID;
                    row["COID"] = sCOID;
                    row["CPID"] = DBNull.Value;
                    row["CPOfficeID"] = DBNull.Value;
                    //row["CRID"] = DBNull.Value;

                    dtIn.Rows.Add(row);
                    DataSet dsOut = Service.ProxyGenericSet(dsIn, "Set");

                    string sCRID = dsOut.Tables[0].Rows[0][0].ToString();
                    return sCRID;
                    //drRange["CRID"] = sCRID;
                    //drRange["State"] = "Unchanged";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Can't get carat range ID. Reason: " + ex.ToString(),
                        "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            return null;

        }

        private void DeleteRangePrices()
        {
            if (!IsNewCustomer)
            {
                string s = cbcCustomer.SelectedID;

                char cSeparator = '_';
                string[] sIDs = s.Split(cSeparator);

                string sCID = sIDs[1];
                string sCOID = sIDs[0];

                DataRow[] rowsToDelete = dsAllCaratRanges.Tables[0].Select("State='Deleted'");

                foreach (DataRow drRange in rowsToDelete/*dsAllCaratRanges.Tables[0].Rows*/)
                {
                    if (!Convert.IsDBNull(drRange["State"]) &&
                        drRange["State"].ToString().Equals("Deleted"))
                    {
                        try
                        {
                            DataSet dsIn = new DataSet();
                            DataTable dtIn = dsIn.Tables.Add("CaratRange");
                            //dtIn.Columns.Add("AuthorID",  System.Type.GetType("System.String"));
                            //dtIn.Columns.Add("AuthorOfficeID",  System.Type.GetType("System.String"));
                            dtIn.Columns.Add("CaratRangeClass", System.Type.GetType("System.String"));
                            dtIn.Columns.Add("CaratRangeTitle", System.Type.GetType("System.String"));
                            dtIn.Columns.Add("CaratRangeMin", System.Type.GetType("System.String"));
                            dtIn.Columns.Add("CaratRangeMax", System.Type.GetType("System.String"));
                            dtIn.Columns.Add("CID", System.Type.GetType("System.String"));
                            dtIn.Columns.Add("COID", System.Type.GetType("System.String"));
                            dtIn.Columns.Add("CPID", System.Type.GetType("System.String"));
                            dtIn.Columns.Add("CPOfficeID", System.Type.GetType("System.String"));
                            dtIn.Columns.Add("CRID", System.Type.GetType("System.String"));
                            dtIn.Columns.Add("ExpireDate", System.Type.GetType("System.String"));
                            //dtIn.Columns.Add("CRID", System.Type.GetType("System.String"));

                            DataRow row = dtIn.NewRow();
                            //row["AuthorID"] = str;
                            //row["AuthorOfficeID"] = str;
                            row["CaratRangeClass"] = drRange["CaratRangeClass"];
                            row["CaratRangeTitle"] = drRange["CaratRangeTitle"];
                            row["CaratRangeMin"] = drRange["CaratRangeMin"];
                            row["CaratRangeMax"] = drRange["CaratRangeMax"];
                            row["CID"] = sCID;
                            row["COID"] = sCOID;
                            row["CPID"] = DBNull.Value;
                            row["CPOfficeID"] = DBNull.Value;
                            row["CRID"] = drRange["CRID"];
                            row["ExpireDate"] = DateTime.Today;

                            dtIn.Rows.Add(row);

                            DataSet dsOut = Service.ProxyGenericSet(dsIn, "Set");

                            continue;

                            //string sCRID = dsOut.Tables[0].Rows[0][0].ToString();
                            //drRange["CRID"] = sCRID;
                            //drRange["State"] = "Unchanged";
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(this, "Can't get carat range ID. Reason: " + ex.ToString(),
                                "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                //DataRow[] 
                rowsToDelete = dsAllCaratRanges.Tables[0].Select("State='Deleted'");

                foreach (DataRow row in rowsToDelete)
                {
                    dsAllCaratRanges.Tables[0].Rows.Remove(row);
                }

            }

        }

        private void btnUpdateRanges_Click(object sender, System.EventArgs e)
        {

            DataRow drNew;

            // fixed price stuffing...
            string s = "CRID=" + label1.Tag.ToString() + " and " + "OTGID=" + PrevOTGID.ToString();
            DataRow[] adrSel1 = dsCustomerPrices.Tables[0].Select("CRID=" + label1.Tag.ToString() + " and " + "OTGID=" + PrevOTGID.ToString());

            if (adrSel1.Length == 0)
            {
                try
                {
                    Convert.ToDouble(tbFixedB.Text);
                }
                catch
                {
                    if (tbFixedP.Text != "")
                        tbFixedB.Text = "0";
                }

                try
                {
                    Convert.ToDouble(tbFixedP.Text);
                }
                catch
                {
                    if (tbFixedB.Text != "")
                        tbFixedP.Text = "0";
                }

                if (tbFixedB.Text != "" || tbFixedP.Text != "")
                {
                    drNew = dsCustomerPrices.Tables[0].NewRow();
                    dsCustomerPrices.Tables[0].Rows.Add(drNew);
                    if (tbFixedB.Text != "")
                        drNew["RangeFixPrice"] = Convert.ToDouble(tbFixedB.Text);
                    if (tbFixedP.Text != "")
                        drNew["RangeRelPrice"] = Convert.ToDouble(tbFixedP.Text);
                    drNew["IsFixPrice"] = rbFixedB.Checked == true ? "1" : "0";

                    //String sCaratRangeClass;
                    //String sCRID = AddCaratRange();

                    drNew["CRID"] = //Convert.ToInt32(label1.Tag);
                    drNew["OTGID"] = PrevOTGID;
                    drNew["COID_CID_OTGID_CRID"] = cbcCustomer.ComboField.drvSelectedItem[cbcCustomer.ValueMember].ToString() +
                        "_" + drNew["OTGID"].ToString() + "_" + drNew["CRID"].ToString();
                    drNew["CustomerOfficeID_CustomerID"] = cbcCustomer.ComboField.drvSelectedItem[cbcCustomer.ValueMember].ToString();
                }
            }
            else
            {
                drNew = adrSel1[0];
                if (tbFixedB.Text != "" || tbFixedP.Text != "")
                {
                    if (tbFixedB.Text != "")
                        drNew["RangeFixPrice"] = Convert.ToDouble(tbFixedB.Text);
                    if (tbFixedP.Text != "")
                        drNew["RangeRelPrice"] = Convert.ToDouble(tbFixedP.Text);
                    drNew["IsFixPrice"] = rbFixedB.Checked == true ? "1" : "0";
                    drNew["CRID"] = Convert.ToInt32(label1.Tag);
                    drNew["OTGID"] = PrevOTGID;
                    drNew["COID_CID_OTGID_CRID"] = cbcCustomer.ComboField.drvSelectedItem[cbcCustomer.ValueMember].ToString() +
                        "_" + drNew["OTGID"].ToString() + "_" + drNew["CRID"].ToString();
                    drNew["CustomerOfficeID_CustomerID"] = cbcCustomer.ComboField.drvSelectedItem[cbcCustomer.ValueMember].ToString();
                }
            }

            foreach (Control cntrl in gbUnfixed.Controls)
            {

                string sFilter = "CRID=" + ((Price)cntrl).Tag.ToString() + " and " + "OTGID=" + PrevOTGID.ToString();
                DataRow[] adrSel = dsCustomerPrices.Tables[0].Select(sFilter);

                if (adrSel.Length == 0)
                {
                    try
                    {
                        Convert.ToDouble(((Price)cntrl).tbBuck.Text);
                    }
                    catch
                    {
                        if (((Price)cntrl).tbPercent.Text != "")
                            ((Price)cntrl).tbBuck.Text = "0";
                    }

                    try
                    {
                        Convert.ToDouble(((Price)cntrl).tbPercent.Text);
                    }
                    catch
                    {
                        if (((Price)cntrl).tbBuck.Text != "")
                            ((Price)cntrl).tbPercent.Text = "0";
                    }

                    if (((Price)cntrl).tbBuck.Text != "" || ((Price)cntrl).tbPercent.Text != "")
                    {
                        drNew = dsCustomerPrices.Tables[0].NewRow();
                        dsCustomerPrices.Tables[0].Rows.Add(drNew);
                        drNew["RangeFixPrice"] = Convert.ToDouble(((Price)cntrl).tbBuck.Text);
                        drNew["RangeRelPrice"] = Convert.ToDouble(((Price)cntrl).tbPercent.Text);
                        drNew["IsFixPrice"] = ((Price)cntrl).rbUnfixed01B.Checked == true ? "1" : "0";

                        String sCaratRangeMin = ((Price)cntrl).sCaratRangeMin;
                        String sCaratRangeMax = ((Price)cntrl).sCaratRangeMax;
                        sFilter = "CaratRangeMin=" + sCaratRangeMin +
                            " and CaratRangeMax=" + sCaratRangeMax + " and State='Added'";
                        DataRow[] drAdded = dsAllCaratRanges.Tables[0].Select(sFilter);

                        String sCaratRangeClass = drAdded[0]["CaratRangeClass"].ToString();
                        String sCaratRangeTitle = drAdded[0]["CaratRangeTitle"].ToString();
                        //String sCaratRange
                        String sCRID = AddCaratRange(sCaratRangeClass, sCaratRangeTitle,
                            sCaratRangeMin, sCaratRangeMax);
                        drNew["CRID"] = sCRID;
                        //Convert.ToInt32(((Price)cntrl).Tag);
                        drNew["OTGID"] = PrevOTGID;
                        drNew["COID_CID_OTGID_CRID"] = cbcCustomer.ComboField.drvSelectedItem[cbcCustomer.ValueMember].ToString() +
                            "_" + drNew["OTGID"].ToString() + "_" + drNew["CRID"].ToString();
                        drNew["CustomerOfficeID_CustomerID"] = cbcCustomer.ComboField.drvSelectedItem[cbcCustomer.ValueMember].ToString();
                    }
                }
                else
                {
                    drNew = adrSel[0];
                    if (((Price)cntrl).tbBuck.Text != "" || ((Price)cntrl).tbPercent.Text != "")
                    {
                        if (((Price)cntrl).tbBuck.Text != "")
                            drNew["RangeFixPrice"] = Convert.ToDouble(((Price)cntrl).tbBuck.Text);
                        if (((Price)cntrl).tbPercent.Text != "")
                            drNew["RangeRelPrice"] = Convert.ToDouble(((Price)cntrl).tbPercent.Text);
                        drNew["IsFixPrice"] = ((Price)cntrl).rbUnfixed01B.Checked == true ? "1" : "0";

                        String sCaratRangeMin = ((Price)cntrl).sCaratRangeMin;
                        String sCaratRangeMax = ((Price)cntrl).sCaratRangeMax;
                        sFilter = "CaratRangeMin=" + sCaratRangeMin +
                            " and CaratRangeMax=" + sCaratRangeMax + " and State='Added'";
                        DataRow[] drAdded = dsAllCaratRanges.Tables[0].Select(sFilter);

                        String sCaratRangeClass = drAdded[0]["CaratRangeClass"].ToString();
                        String sCaratRangeTitle = drAdded[0]["CaratRangeTitle"].ToString();
                        //String sCaratRange
                        String sCRID = AddCaratRange(sCaratRangeClass, sCaratRangeTitle,
                            sCaratRangeMin, sCaratRangeMax);
                        drNew["CRID"] = sCRID;

                        //drNew["CRID"] = Convert.ToInt32(((Price)cntrl).Tag);
                        drNew["OTGID"] = PrevOTGID;
                        drNew["COID_CID_OTGID_CRID"] = cbcCustomer.ComboField.drvSelectedItem[cbcCustomer.ValueMember].ToString() +
                            "_" + drNew["OTGID"].ToString() + "_" + drNew["CRID"].ToString();
                        drNew["CustomerOfficeID_CustomerID"] = cbcCustomer.ComboField.drvSelectedItem[cbcCustomer.ValueMember].ToString();
                    }
                }
            }

            DeleteRangePrices();

            ReInitOpsTree();

            /*
            MessageBox.Show(dsAllCaratRanges.Tables[0].Rows.Count.ToString());
            foreach(DataRow drRange in dsAllCaratRanges.Tables[0].Rows)
            {
                switch (drRange.RowState)
                {
                    case DataRowState.Added:
                    {
                        MessageBox.Show("Added");
                        break;
                    }
                    case DataRowState.Deleted:
                    {
                        MessageBox.Show("Deleted");
                        break;
                    }
                    case DataRowState.Detached:
                    {
                        MessageBox.Show("Detached");
                        break;
                    }
                    case DataRowState.Modified:
                    {
                        MessageBox.Show("Modified");
                        break;
                    }
                    case DataRowState.Unchanged:
                    {
                        MessageBox.Show("Unchanged");
                        break;
                    }
                }
            }
            */
        }

        private bool CheckRange(Decimal min, Decimal max)
        {
            try
            {
                Decimal dmin = 0;
                Decimal dmax = 0;

                foreach (DataRow drRange in dsAllCaratRanges.Tables[0].Rows)
                {
                    if ((Convert.IsDBNull(drRange["State"]) ||
                        !drRange["State"].ToString().Equals("Deleted")) &&
                        drRange["CaratRangeClass"].ToString() != "0")
                    {
                        dmin = (System.Decimal)drRange["CaratRangeMin"];
                        dmax = (System.Decimal)drRange["CaratRangeMax"];

                        if ((min >= dmin && min <= dmax) ||
                            (max >= dmin && max <= dmax))
                        {
                            return false;
                        }

                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Can't check range. Reason: " + ex.ToString(),
                    "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        //private String UpdateCaratRange

        private void debug_DisplayDataRowCollection(DataRow[] rows)
        {
            string msg = "";
            if (rows.Length > 0)
                msg = "\r\n=======================================================\r\nTable Name: " + rows[0].Table.TableName + "\r\n";
            int i = 0;
            foreach (DataRow row in rows)
            {
                //foreach (DataRow row in table.Rows)
                //{
                i++;
                msg += "row N: " + i.ToString() + "\r\n";
                foreach (DataColumn column in row.Table.Columns)
                {
                    msg += "\t" + column.ColumnName + ": " + row[column].ToString() + "\r\n";
                }
                //}
                //MessageBox.Show(msg);
                System.Diagnostics.Trace.Write(msg);
            }
        }

        //History loads on button-click. Before it loaded on radio button-checkchanged. And on customer load
        //By 3ter on 2006.04.04 on Zeltser request
        private void bLoadHistory_Click(object sender, System.EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.sbStatus.Text = "Loading orders history. Please, wait.";
            try
            {
                ordersTree1.Clear();
                if (rbAll.Checked)
                    DrawHistory(0);
                else
                {
                    Couple cplCustomer = new Couple();
                    cplCustomer.FieldName = "CustomerCode";
                    cplCustomer.FieldValue = cbcCustomer.ComboField.drvSelectedItem[cbcCustomer.CodeMember].ToString();


                    if (rbClosed.Checked)
                    {
                        Couple cplStateE = new Couple();
                        cplStateE.FieldName = "EGroupState";
                        cplStateE.FieldValue = "1";
                        ordersTree1.Initialize(Service.GetOrderTreeDataByCode(new Couple[] { cplCustomer, cplStateE }));
                    }
                    if (rbOpen.Checked)
                    {
                        Couple cplStateB = new Couple();
                        cplStateB.FieldName = "BGroupState";
                        cplStateB.FieldValue = "2";
                        ordersTree1.Initialize(Service.GetOrderTreeDataByCode(new Couple[] { cplCustomer, cplStateB }));
                    }
                }
            }
            catch
            {
                sbStatus.Text = "Orders history for this customer is not available";
            }
            finally
            {
                this.Cursor = Cursors.Default;
                this.sbStatus.Text = "Ready";
            }
        }
    }
}
