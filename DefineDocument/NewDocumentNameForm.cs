using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using gemoDream;


namespace gemoDream
{
	/// <summary>
	/// Summary description for NewDocumentName.
	/// </summary>
	public class NewDocumentNameForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.TextBox tbDocName;
		private System.Windows.Forms.Label lbDocTypeClass;
		private System.Windows.Forms.Label lbDocName;
		private System.Windows.Forms.ComboBox cbDocType;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public NewDocumentNameForm(string sDocumentTypeCode)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			InitDocTypeClass(sDocumentTypeCode);
		}

		private void InitDocTypeClass(string sDocumentTypeCode)
		{
			/*
			DataSet ds = new DataSet();
			ds.Tables.Add("DocsByCP");
			ds.Tables[0].Columns.Add("OperationTypeOfficeID_OperationTypeID", System.Type.GetType("System.String"));
			ds.Tables[0].Columns.Add("OperationTypeName", System.Type.GetType("System.String"));

			Service.AddMagicOperations(ds);
			*/
			DataSet ds = Service.GetDocumentTypes();

			this.cbDocType.DataSource = ds.Tables[0];
			this.cbDocType.ValueMember = "DocumentTypeCode";
				//"OperationTypeOfficeID_OperationTypeID";
			this.cbDocType.DisplayMember = "DocumentTypeName";
				//"OperationTypeName";

			this.cbDocType.SelectedValue = sDocumentTypeCode;
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NewDocumentNameForm));
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.tbDocName = new System.Windows.Forms.TextBox();
			this.lbDocName = new System.Windows.Forms.Label();
			this.lbDocTypeClass = new System.Windows.Forms.Label();
			this.cbDocType = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.btnCancel.Location = new System.Drawing.Point(224, 112);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(72, 24);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOK
			// 
			this.btnOK.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.btnOK.Location = new System.Drawing.Point(144, 112);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(72, 24);
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// tbDocName
			// 
			this.tbDocName.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.tbDocName.Location = new System.Drawing.Point(144, 32);
			this.tbDocName.Name = "tbDocName";
			this.tbDocName.Size = new System.Drawing.Size(152, 20);
			this.tbDocName.TabIndex = 1;
			this.tbDocName.Text = "";
			this.tbDocName.TextChanged += new System.EventHandler(this.tbDocName_TextChanged);
			// 
			// lbDocName
			// 
			this.lbDocName.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.lbDocName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lbDocName.Location = new System.Drawing.Point(8, 32);
			this.lbDocName.Name = "lbDocName";
			this.lbDocName.Size = new System.Drawing.Size(152, 20);
			this.lbDocName.TabIndex = 0;
			this.lbDocName.Text = "Enter document name:";
			this.lbDocName.Click += new System.EventHandler(this.label1_Click);
			// 
			// lbDocTypeClass
			// 
			this.lbDocTypeClass.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.lbDocTypeClass.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lbDocTypeClass.Location = new System.Drawing.Point(8, 72);
			this.lbDocTypeClass.Name = "lbDocTypeClass";
			this.lbDocTypeClass.Size = new System.Drawing.Size(152, 20);
			this.lbDocTypeClass.TabIndex = 2;
			this.lbDocTypeClass.Text = "Document type:";
			// 
			// cbDocType
			// 
			this.cbDocType.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.cbDocType.Location = new System.Drawing.Point(144, 72);
			this.cbDocType.Name = "cbDocType";
			this.cbDocType.Size = new System.Drawing.Size(152, 20);
			this.cbDocType.TabIndex = 3;
			// 
			// NewDocumentNameForm
			// 
			this.AcceptButton = this.btnCancel;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(304, 142);
			this.Controls.Add(this.cbDocType);
			this.Controls.Add(this.lbDocTypeClass);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.tbDocName);
			this.Controls.Add(this.lbDocName);
			this.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "NewDocumentNameForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Document Name";
			this.Load += new System.EventHandler(this.NewDocumentNameForm_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if (this.tbDocName.Text.ToString().Length == 0)
			{
				MessageBox.Show(this, "Please, enter a document name.", "Warning", MessageBoxButtons.OK,
					MessageBoxIcon.Warning);
				return ;
			}
			this.DialogResult = DialogResult.OK;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}

		public string GetDocumentName()
		{
			return this.tbDocName.Text.ToString();
		}

//		public string GetDocumentTypeName()
//		{
//			string s = this.cbDocType.Text;
//			return s;
//		}

		public string GetDocumentTypeCode()
		{
			//return this.cbDocType.Text;
			return this.cbDocType.SelectedValue.ToString();
		}

		private void tbDocName_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void label1_Click(object sender, System.EventArgs e)
		{
		
		}

		private void NewDocumentNameForm_Load(object sender, System.EventArgs e)
		{
		
		}
	}
}
