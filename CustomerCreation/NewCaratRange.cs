using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace gemoDream
{
	/// <summary>
	/// Summary description for NewCaratRange.
	/// </summary>
	public class NewCaratRange : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbCaratRange;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public NewCaratRange()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NewCaratRange));
			this.label1 = new System.Windows.Forms.Label();
			this.tbCaratRange = new System.Windows.Forms.TextBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label1.Location = new System.Drawing.Point(8, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Enter carat range:";
			// 
			// tbCaratRange
			// 
			this.tbCaratRange.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.tbCaratRange.Location = new System.Drawing.Point(112, 32);
			this.tbCaratRange.Name = "tbCaratRange";
			this.tbCaratRange.Size = new System.Drawing.Size(144, 20);
			this.tbCaratRange.TabIndex = 1;
			this.tbCaratRange.Text = "#####.##-#####.##";
			this.tbCaratRange.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCaratRange_KeyPress);
			// 
			// btnOK
			// 
			this.btnOK.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.btnOK.Location = new System.Drawing.Point(104, 64);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(72, 24);
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.btnCancel.Location = new System.Drawing.Point(184, 64);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(72, 24);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// NewCaratRange
			// 
			this.AcceptButton = this.btnCancel;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
			this.ClientSize = new System.Drawing.Size(266, 95);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.tbCaratRange);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "NewCaratRange";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "New Carat Range";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if (!CheckCaratRange())
			{
				MessageBox.Show(this, "Invalid carat range. Please input '#####.##-#####.##'",
					"Invalid range", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return ;
			}
			this.DialogResult = DialogResult.OK;
		}

		public string GetCaratRange()
		{
			return tbCaratRange.Text;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}

		private void tbCaratRange_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar != 8)
			{
				string str = tbCaratRange.Text.ToString();
				if (str.Equals("#####.##-#####.##"))
				{
					str = "";
					tbCaratRange.Text = str;
				}

				str += e.KeyChar.ToString();

				string pattern = "[0-9.-]{1,17}";
				Regex rex = new Regex(pattern);
					
				Match m = rex.Match(str);
				if (m.Length != str.Length)
					e.Handled = true;
			}
		}

		private bool CheckCaratRange()
		{
			string str = tbCaratRange.Text.ToString();

			string pattern = "[0-9]{1,5}.[0-9]{2}-[0-9]{1,5}.[0-9]{2}";
			Regex rex = new Regex(pattern);
					
			Match m = rex.Match(str);
			if (m.Length != str.Length)
				return false;
			return true;
		}
	}
}
