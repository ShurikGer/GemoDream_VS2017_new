#region using
using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
#endregion
namespace gemoDream
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class SaveCPas : System.Windows.Forms.Form
    {


        private string sCustomerProgName;
        private string sCustomerOfficeID_CustomerID;
        private string sVendorOfficeID_VendorID;
        private string sCPOfficeID_CPID_Old;


        private CustomerProgramForm Parent;
        private System.Windows.Forms.Button btSave;
        private Cntrls.ComboTextComponent ctcCustomer;
        private System.Windows.Forms.TextBox tbCPname;
        private System.Windows.Forms.Label label3;
        private Cntrls.ComboTextComponent ctcVendor;
        private System.Windows.Forms.CheckBox chbSameVendor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public SaveCPas(DataTable dtCus, string sCPName, CustomerProgramForm ParentForm, string sCPOID_CPID)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();


            ctcCustomer.Initialize(dtCus);
            ctcVendor.Initialize(dtCus);
            ctcVendor.Enabled = false;
            tbCPname.Text = sCPName.Trim();
            sCustomerProgName = sCPName.Trim();
            this.Parent = ParentForm;
            this.sCPOfficeID_CPID_Old = sCPOID_CPID;
            ctcCustomer.SelectionChanged += new EventHandler(ctcCustomer_SelectedIndexChanged);
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(SaveCPas));
            this.tbCPname = new System.Windows.Forms.TextBox();
            this.btSave = new System.Windows.Forms.Button();
            this.ctcCustomer = new Cntrls.ComboTextComponent();
            this.label3 = new System.Windows.Forms.Label();
            this.ctcVendor = new Cntrls.ComboTextComponent();
            this.chbSameVendor = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbCPname
            // 
            this.tbCPname.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
            this.tbCPname.Location = new System.Drawing.Point(75, 5);
            this.tbCPname.Name = "tbCPname";
            this.tbCPname.Size = new System.Drawing.Size(390, 20);
            this.tbCPname.TabIndex = 0;
            this.tbCPname.Text = "";
            // 
            // btSave
            // 
            this.btSave.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
            this.btSave.Location = new System.Drawing.Point(430, 110);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(85, 20);
            this.btSave.TabIndex = 4;
            this.btSave.Text = "Save";
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // ctcCustomer
            // 
            this.ctcCustomer.DefaultText = "Customer lookup";
            this.ctcCustomer.DisplayMember = "CustomerName";
            this.ctcCustomer.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
            this.ctcCustomer.InsertDefaultRow = true;
            this.ctcCustomer.Location = new System.Drawing.Point(75, 45);
            this.ctcCustomer.Name = "ctcCustomer";
            this.ctcCustomer.SelectedCode = "";
            this.ctcCustomer.Size = new System.Drawing.Size(445, 20);
            this.ctcCustomer.TabIndex = 5;
            this.ctcCustomer.ValueMember = "CustomerOfficeID_CustomerID";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
            this.label3.Location = new System.Drawing.Point(5, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Save as";
            // 
            // ctcVendor
            // 
            this.ctcVendor.DefaultText = "Vendor lookup";
            this.ctcVendor.DisplayMember = "CustomerName";
            this.ctcVendor.Enabled = false;
            this.ctcVendor.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
            this.ctcVendor.InsertDefaultRow = true;
            this.ctcVendor.Location = new System.Drawing.Point(75, 70);
            this.ctcVendor.Name = "ctcVendor";
            this.ctcVendor.SelectedCode = "";
            this.ctcVendor.Size = new System.Drawing.Size(445, 20);
            this.ctcVendor.TabIndex = 1;
            this.ctcVendor.ValueMember = "CustomerOfficeID_CustomerID";
            // 
            // chbSameVendor
            // 
            this.chbSameVendor.Checked = true;
            this.chbSameVendor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbSameVendor.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
            this.chbSameVendor.Location = new System.Drawing.Point(75, 95);
            this.chbSameVendor.Name = "chbSameVendor";
            this.chbSameVendor.Size = new System.Drawing.Size(390, 15);
            this.chbSameVendor.TabIndex = 10;
            this.chbSameVendor.Text = "Vendor is the same as Customer";
            this.chbSameVendor.CheckedChanged += new System.EventHandler(this.chbSameVendor_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
            this.label2.Location = new System.Drawing.Point(5, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "For";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
            this.label4.Location = new System.Drawing.Point(10, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "Customer";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
            this.label5.Location = new System.Drawing.Point(10, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "Vendor";
            // 
            // SaveCPas
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(524, 135);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chbSameVendor);
            this.Controls.Add(this.ctcVendor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ctcCustomer);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.tbCPname);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SaveCPas";
            this.ShowInTaskbar = false;
            this.Text = "Save customer program as";
            this.ResumeLayout(false);

        }
        #endregion


        private void btSave_Click(object sender, System.EventArgs e)
        {
            if (ctcCustomer.SelectedCode == "0" || ctcVendor.SelectedCode == "0" ||
                ctcCustomer.SelectedCode == "" || ctcVendor.SelectedCode == "")
            {
                MessageBox.Show("Customer and Vendor must be selected", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctcCustomer.Focus();
                return;
            }
            sCustomerProgName = this.tbCPname.Text;
            sCustomerOfficeID_CustomerID = ctcCustomer.ComboField.cbField.SelectedValue.ToString();
            sVendorOfficeID_VendorID = ctcVendor.ComboField.cbField.SelectedValue.ToString();
            bool bIsOK = Parent.SaveCP(this.sCustomerProgName, this.sCustomerOfficeID_CustomerID, this.sVendorOfficeID_VendorID,
            CustomerProgramForm.SaveCPmode.SaveAs);
            if (!bIsOK)
            {
                this.Dispose();
                return;
            }

            string sss = Parent.GetCPOfficeID_CPID();

            char[] sep = { '_' };
            string[] sTemp = this.sCPOfficeID_CPID_Old.Split(sep);
            Parent.CopyDefDocs(sTemp[0], sTemp[1]);
            //Parent.CopyAllOperations();

            if (bIsOK)
            {
                MessageBox.Show(this, "Customer program saved successfully.", "Successful save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
                Parent.LoadCustomerAndCustomerProgram(sss, this.sCustomerOfficeID_CustomerID, sCustomerProgName);
            }
        }

        private void chbSameVendor_CheckedChanged(object sender, System.EventArgs e)
        {
            ctcVendor.Enabled = !chbSameVendor.Checked;
            if (chbSameVendor.Checked)
            {
                if (ctcCustomer.SelectedCode != "0" && ctcCustomer.SelectedCode != "")
                {

                    ctcVendor.ComboField.cbField.SelectedIndex = ctcCustomer.ComboField.cbField.SelectedIndex;
                }
                else
                {
                    ctcVendor.SelectedCode = "";
                }
            }
        }

        private void ctcCustomer_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (chbSameVendor.Checked)
                if (ctcCustomer.ComboField.cbField.SelectedValue.ToString() == "0" ||
                    ctcCustomer.ComboField.cbField.SelectedValue.ToString() == "")
                    ctcVendor.SelectedCode = "0";
                else
                    ctcVendor.ComboField.cbField.SelectedIndex = ctcCustomer.ComboField.cbField.SelectedIndex;

            this.Cursor = Cursors.Default;
        }
    }
}
