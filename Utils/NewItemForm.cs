using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace gemoDream
{
	/// <summary>
	/// Summary description for NewItemForm.
	/// </summary>
	public class NewItemForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbNewItemName;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public NewItemForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NewItemForm));
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.tbNewItemName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.btnCancel.Location = new System.Drawing.Point(224, 64);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(72, 24);
			this.btnCancel.TabIndex = 7;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOK
			// 
			this.btnOK.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.btnOK.Location = new System.Drawing.Point(144, 64);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(72, 24);
			this.btnOK.TabIndex = 6;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// tbNewItemName
			// 
			this.tbNewItemName.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.tbNewItemName.Location = new System.Drawing.Point(152, 32);
			this.tbNewItemName.Name = "tbNewItemName";
			this.tbNewItemName.Size = new System.Drawing.Size(144, 20);
			this.tbNewItemName.TabIndex = 5;
			this.tbNewItemName.Text = "";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label1.Location = new System.Drawing.Point(8, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(128, 20);
			this.label1.TabIndex = 4;
			this.label1.Text = "Enter new item name:";
			// 
			// NewItemForm
			// 
			this.AcceptButton = this.btnCancel;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
			this.ClientSize = new System.Drawing.Size(306, 96);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.tbNewItemName);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "NewItemForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "New Item Form";
			this.ResumeLayout(false);

		}
		#endregion

		public string GetItemName() 
		{
			return tbNewItemName.Text.ToString();
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}
	}
}
