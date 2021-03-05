using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Cntrls
{
    /// <summary>
    /// Summary description for OrderDetails.
    /// </summary>
    public class OrderDetails : System.Windows.Forms.UserControl
    {
        public System.Windows.Forms.TextBox tbLabel;
        public System.Windows.Forms.ComboBox cbServiceType;
        public System.Windows.Forms.TextBox tbItemCode;
        public System.Windows.Forms.CheckBox chbEnabled;

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public OrderDetails()
        {
            InitializeComponent();
        }

        public OrderDetails(DataSet dsOps)
        {
            InitializeComponent();
            cbServiceType.DataSource = dsOps.Tables["OperationTree"];
            cbServiceType.DisplayMember = "TreeItemName";
            cbServiceType.ValueMember = "OperationTypeOfficeID_OperationTypeID";
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

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbLabel = new System.Windows.Forms.TextBox();
            this.cbServiceType = new System.Windows.Forms.ComboBox();
            this.tbItemCode = new System.Windows.Forms.TextBox();
            this.chbEnabled = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tbLabel
            // 
            this.tbLabel.Enabled = false;
            this.tbLabel.Location = new System.Drawing.Point(312, 0);
            this.tbLabel.Name = "tbLabel";
            this.tbLabel.Size = new System.Drawing.Size(115, 20);
            this.tbLabel.TabIndex = 39;
            this.tbLabel.Text = "";
            // 
            // cbServiceType
            // 
            this.cbServiceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbServiceType.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.cbServiceType.Items.AddRange(new object[] {
															   "1",
															   "2",
															   "3"});
            this.cbServiceType.Location = new System.Drawing.Point(144, 0);
            this.cbServiceType.Name = "cbServiceType";
            this.cbServiceType.Size = new System.Drawing.Size(165, 20);
            this.cbServiceType.TabIndex = 38;
            // 
            // tbItemCode
            // 
            this.tbItemCode.Enabled = false;
            this.tbItemCode.Location = new System.Drawing.Point(0, 0);
            this.tbItemCode.Name = "tbItemCode";
            this.tbItemCode.ReadOnly = true;
            this.tbItemCode.Size = new System.Drawing.Size(140, 20);
            this.tbItemCode.TabIndex = 37;
            this.tbItemCode.Text = "#####.#####.###.##";
            // 
            // chbEnabled
            // 
            this.chbEnabled.Location = new System.Drawing.Point(432, 3);
            this.chbEnabled.Name = "chbEnabled";
            this.chbEnabled.Size = new System.Drawing.Size(16, 16);
            this.chbEnabled.TabIndex = 40;
            this.chbEnabled.CheckedChanged += new System.EventHandler(this.chbEnabled_CheckedChanged);
            // 
            // OrderDetails
            // 
            this.Controls.Add(this.chbEnabled);
            this.Controls.Add(this.tbLabel);
            this.Controls.Add(this.cbServiceType);
            this.Controls.Add(this.tbItemCode);
            this.Name = "OrderDetails";
            this.Size = new System.Drawing.Size(448, 20);
            this.ResumeLayout(false);

        }
        #endregion

        private void chbEnabled_CheckedChanged(object sender, System.EventArgs e)
        {
            tbItemCode.Enabled = tbLabel.Enabled = cbServiceType.Enabled = chbEnabled.Checked;
        }
    }
}
