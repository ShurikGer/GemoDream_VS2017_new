using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace  gemoDream
{
	/// <summary>
	/// Summary description for FormCallOldNumbers.
	/// </summary>
	public class FormCallOldNumbers : System.Windows.Forms.Form
	{
		public System.Windows.Forms.Button bCallOldNumberForm;
		public System.Windows.Forms.Button bCancel;
		public System.Windows.Forms.TextBox tbOldNumbers;
		public System.Windows.Forms.Label label1;
		public System.Windows.Forms.Button bAddMoreOldNumbers;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormCallOldNumbers()
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
			this.bCallOldNumberForm = new System.Windows.Forms.Button();
			this.bCancel = new System.Windows.Forms.Button();
			this.tbOldNumbers = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.bAddMoreOldNumbers = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// bCallOldNumberForm
			// 
			this.bCallOldNumberForm.DialogResult = System.Windows.Forms.DialogResult.Yes;
			this.bCallOldNumberForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.bCallOldNumberForm.Location = new System.Drawing.Point(16, 72);
			this.bCallOldNumberForm.Name = "bCallOldNumberForm";
			this.bCallOldNumberForm.Size = new System.Drawing.Size(104, 24);
			this.bCallOldNumberForm.TabIndex = 0;
			this.bCallOldNumberForm.Text = "Yes";
			this.bCallOldNumberForm.Click += new System.EventHandler(this.bCallOldNumberForm_Click);
			// 
			// bCancel
			// 
			this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.bCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.bCancel.Location = new System.Drawing.Point(256, 72);
			this.bCancel.Name = "bCancel";
			this.bCancel.Size = new System.Drawing.Size(104, 24);
			this.bCancel.TabIndex = 1;
			this.bCancel.Text = "Cancel";
			// 
			// tbOldNumbers
			// 
			this.tbOldNumbers.AcceptsReturn = true;
			this.tbOldNumbers.Location = new System.Drawing.Point(136, 16);
			this.tbOldNumbers.Name = "tbOldNumbers";
			this.tbOldNumbers.Size = new System.Drawing.Size(104, 20);
			this.tbOldNumbers.TabIndex = 2;
			this.tbOldNumbers.Text = "";
			this.tbOldNumbers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbOldNumbers_KeyDown);
			this.tbOldNumbers.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbOldNumbers_KeyPress);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(296, 24);
			this.label1.TabIndex = 3;
			this.label1.Text = "Do you want to add                                           items?";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// bAddMoreOldNumbers
			// 
			this.bAddMoreOldNumbers.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.bAddMoreOldNumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.bAddMoreOldNumbers.Location = new System.Drawing.Point(128, 72);
			this.bAddMoreOldNumbers.Name = "bAddMoreOldNumbers";
			this.bAddMoreOldNumbers.Size = new System.Drawing.Size(120, 24);
			this.bAddMoreOldNumbers.TabIndex = 4;
			this.bAddMoreOldNumbers.Text = "Add More ##";
			// 
			// FormCallOldNumbers
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(376, 102);
			this.Controls.Add(this.bAddMoreOldNumbers);
			this.Controls.Add(this.tbOldNumbers);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.bCancel);
			this.Controls.Add(this.bCallOldNumberForm);
			this.Name = "FormCallOldNumbers";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Call Old Number ";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.FormCallOldNumbers_Closing);
			this.Closed += new System.EventHandler(this.FormCallOldNumbers_Closed);
			this.ResumeLayout(false);

		}
		#endregion

		private void bCallOldNumberForm_Click(object sender, System.EventArgs e)
		{
	
			this.DialogResult = System.Windows.Forms.DialogResult.Yes;
			this.Close(); //_Closing(this, System.ComponentModel.CancelEventArgs.Empty);
		}

		private void tbOldNumbers_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			bCallOldNumberForm_Click(this, System.EventArgs.Empty);
		}

		public void tbOldNumbers_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			char c = e.KeyChar;
//			if((c >='0'&& c<='9')||c==13)
//			{
//				e.Handled=false;
//			}
//			else
//			{
//				e.Handled=true;
//			}
		}

		private void FormCallOldNumbers_Closed(object sender, System.EventArgs e)
		{
	
		}

		private void FormCallOldNumbers_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
		
		}

	}
}
