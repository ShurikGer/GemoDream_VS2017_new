using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace gemoDream
{
	/// <summary>
	/// Summary description for ExternalReceiptForm.
	/// </summary>
	public class ExternalReceiptForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lbQuestion;
		private System.Windows.Forms.Button btnTwo;
		private System.Windows.Forms.Button btnNone;
		private System.Windows.Forms.Button btnOne;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public enum Result {
			ONE = 1, TWO = 2, NONE = 3
		};

		public Result MyResult = Result.NONE;

		public ExternalReceiptForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			
			//this.pbIcon.Image = (Image)SystemIcons.Warning;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ExternalReceiptForm));
			this.lbQuestion = new System.Windows.Forms.Label();
			this.btnTwo = new System.Windows.Forms.Button();
			this.btnNone = new System.Windows.Forms.Button();
			this.btnOne = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lbQuestion
			// 
			this.lbQuestion.Location = new System.Drawing.Point(8, 8);
			this.lbQuestion.Name = "lbQuestion";
			this.lbQuestion.Size = new System.Drawing.Size(232, 24);
			this.lbQuestion.TabIndex = 0;
			this.lbQuestion.Text = "Do you want to print external receipt?";
			// 
			// btnTwo
			// 
			this.btnTwo.Location = new System.Drawing.Point(88, 48);
			this.btnTwo.Name = "btnTwo";
			this.btnTwo.TabIndex = 2;
			this.btnTwo.Text = "&Two";
			this.btnTwo.Click += new System.EventHandler(this.btnTwo_Click);
			// 
			// btnNone
			// 
			this.btnNone.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnNone.Location = new System.Drawing.Point(168, 48);
			this.btnNone.Name = "btnNone";
			this.btnNone.TabIndex = 3;
			this.btnNone.Text = "&None";
			this.btnNone.Click += new System.EventHandler(this.btnNone_Click);
			// 
			// btnOne
			// 
			this.btnOne.Location = new System.Drawing.Point(8, 48);
			this.btnOne.Name = "btnOne";
			this.btnOne.TabIndex = 1;
			this.btnOne.Text = "&One";
			this.btnOne.Click += new System.EventHandler(this.btnOne_Click);
			// 
			// ExternalReceiptForm
			// 
			this.AcceptButton = this.btnOne;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
			this.CancelButton = this.btnNone;
			this.ClientSize = new System.Drawing.Size(250, 80);
			this.Controls.Add(this.btnNone);
			this.Controls.Add(this.btnTwo);
			this.Controls.Add(this.lbQuestion);
			this.Controls.Add(this.btnOne);
			this.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "ExternalReceiptForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Print External Receipt";
			this.TopMost = true;
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOne_Click(object sender, System.EventArgs e)
		{
			this.MyResult = Result.ONE;
			this.DialogResult = DialogResult.OK;
		}

		private void btnTwo_Click(object sender, System.EventArgs e)
		{
			this.MyResult = Result.TWO;
			this.DialogResult = DialogResult.OK;
		}

		private void btnNone_Click(object sender, System.EventArgs e)
		{
			this.MyResult = Result.NONE;
			this.DialogResult = DialogResult.Cancel;
		}
	}
}
