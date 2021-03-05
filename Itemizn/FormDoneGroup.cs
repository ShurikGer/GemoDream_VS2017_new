using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace gemoDream
{
	/// <summary>
	/// Summary description for DoneGroupDialogForm.
	/// </summary>
	public class DoneGroupDialogForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnDoneGroup;
		private System.Windows.Forms.Button btnWrong;
		private System.Windows.Forms.Button btnEdit;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DoneGroupDialogForm()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DoneGroupDialogForm));
			this.btnWrong = new System.Windows.Forms.Button();
			this.btnDoneGroup = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.btnEdit = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnWrong
			// 
			this.btnWrong.BackColor = System.Drawing.Color.LightPink;
			this.btnWrong.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnWrong.Enabled = false;
			this.btnWrong.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
			this.btnWrong.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnWrong.Location = new System.Drawing.Point(360, 30);
			this.btnWrong.Name = "btnWrong";
			this.btnWrong.Size = new System.Drawing.Size(168, 24);
			this.btnWrong.TabIndex = 13;
			this.btnWrong.Text = "Something Wrong";
			// 
			// btnDoneGroup
			// 
			this.btnDoneGroup.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnDoneGroup.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
			this.btnDoneGroup.Location = new System.Drawing.Point(10, 30);
			this.btnDoneGroup.Name = "btnDoneGroup";
			this.btnDoneGroup.Size = new System.Drawing.Size(168, 24);
			this.btnDoneGroup.TabIndex = 14;
			this.btnDoneGroup.Text = "Done with the Division";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(10, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(520, 15);
			this.label1.TabIndex = 15;
			this.label1.Text = "Expected number of Items added.";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// btnEdit
			// 
			this.btnEdit.DialogResult = System.Windows.Forms.DialogResult.Retry;
			this.btnEdit.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.btnEdit.Location = new System.Drawing.Point(185, 30);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(168, 24);
			this.btnEdit.TabIndex = 16;
			this.btnEdit.Text = "Edit Items";
			// 
			// DoneGroupDialogForm
			// 
			this.AcceptButton = this.btnDoneGroup;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
			this.CancelButton = this.btnWrong;
			this.ClientSize = new System.Drawing.Size(539, 63);
			this.ControlBox = false;
			this.Controls.Add(this.btnEdit);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnDoneGroup);
			this.Controls.Add(this.btnWrong);
			this.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "DoneGroupDialogForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Itemizn part 2: Done with the Division";
			this.ResumeLayout(false);

		}
		#endregion
	
	}
}
