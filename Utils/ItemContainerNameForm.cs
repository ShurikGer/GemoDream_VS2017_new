using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace gemoDream
{
	/// <summary>
	/// Summary description for ItemContainerNameForm.
	/// </summary>
	public class ItemContainerNameForm : System.Windows.Forms.Form
	{
		//private bool bBlocked;
		private System.Windows.Forms.TextBox tbItemContainerName;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Label lbItemContainerName;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ItemContainerNameForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			//this.bBlocked = false;
		}

		public ItemContainerNameForm(bool bBlocked)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			//this.bBlocked = bBlocked;
			if (bBlocked)
			{
				this.AcceptButton = this.btnOK;
				this.btnCancel.Enabled = false;
			}
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ItemContainerNameForm));
			this.tbItemContainerName = new System.Windows.Forms.TextBox();
			this.lbItemContainerName = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// tbItemContainerName
			// 
			this.tbItemContainerName.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.tbItemContainerName.Location = new System.Drawing.Point(168, 16);
			this.tbItemContainerName.Name = "tbItemContainerName";
			this.tbItemContainerName.Size = new System.Drawing.Size(144, 20);
			this.tbItemContainerName.TabIndex = 11;
			this.tbItemContainerName.Text = "";
			// 
			// lbItemContainerName
			// 
			this.lbItemContainerName.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.lbItemContainerName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lbItemContainerName.Location = new System.Drawing.Point(8, 16);
			this.lbItemContainerName.Name = "lbItemContainerName";
			this.lbItemContainerName.Size = new System.Drawing.Size(152, 20);
			this.lbItemContainerName.TabIndex = 10;
			this.lbItemContainerName.Text = "Enter Item Container Name";
			// 
			// btnCancel
			// 
			this.btnCancel.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.btnCancel.Location = new System.Drawing.Point(240, 48);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(72, 24);
			this.btnCancel.TabIndex = 13;
			this.btnCancel.Text = "Cancel";
			// 
			// btnOK
			// 
			this.btnOK.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.btnOK.Location = new System.Drawing.Point(160, 48);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(72, 24);
			this.btnOK.TabIndex = 12;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// ItemContainerNameForm
			// 
			this.AcceptButton = this.btnCancel;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(320, 78);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.tbItemContainerName);
			this.Controls.Add(this.lbItemContainerName);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ItemContainerNameForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Item Container Name";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if (this.tbItemContainerName.Text.Length == 0)
			{
				MessageBox.Show(this, "Please, enter the item container name or press escape to cancel build operation.",
					"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return ;
			}
			this.DialogResult = DialogResult.OK;
		}

		public string GetItemContainerName()
		{
			return this.tbItemContainerName.Text.ToString();
		}
	}
}
