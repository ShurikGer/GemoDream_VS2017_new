using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace gemoDream
{
	/// <summary>
	/// Summary description for DoneBatchDialogForm.
	/// </summary>
	public class DoneBatchDialogForm : System.Windows.Forms.Form
	{
		public System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnDone;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DoneBatchDialogForm()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DoneBatchDialogForm));
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnDone = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnEdit
			// 
			this.btnEdit.BackColor = System.Drawing.SystemColors.Control;
			this.btnEdit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnEdit.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
			this.btnEdit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnEdit.Location = new System.Drawing.Point(215, 30);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(168, 24);
			this.btnEdit.TabIndex = 1;
			this.btnEdit.Text = "Edit Items";
			// 
			// btnDone
			// 
			this.btnDone.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnDone.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
			this.btnDone.Location = new System.Drawing.Point(16, 30);
			this.btnDone.Name = "btnDone";
			this.btnDone.Size = new System.Drawing.Size(168, 24);
			this.btnDone.TabIndex = 0;
			this.btnDone.Text = "Done with the Batch";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(10, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(384, 15);
			this.label1.TabIndex = 2;
			this.label1.Text = "25 items added.";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// DoneBatchDialogForm
			// 
			this.AcceptButton = this.btnDone;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
			this.CancelButton = this.btnEdit;
			this.ClientSize = new System.Drawing.Size(400, 63);
			this.ControlBox = false;
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnDone);
			this.Controls.Add(this.btnEdit);
			this.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "DoneBatchDialogForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Itemizn part 2: Done with the Batch";
			this.ResumeLayout(false);

		}
		#endregion

	}
}
