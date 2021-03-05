using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace gemoDream
{
	/// <summary>
	/// Summary description for NewGroupForm.
	/// </summary>
	public class NewGroupForm : System.Windows.Forms.Form
	{
		private Image imGroupImage;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.TextBox tbGroupName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbGroupIconPath;
		private System.Windows.Forms.Label lbGroupIconPath;
		private System.Windows.Forms.PictureBox pbGroupIcon;
		private System.Windows.Forms.ImageList ilGroupIcon;
		private System.ComponentModel.IContainer components;

		public NewGroupForm()
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NewGroupForm));
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.tbGroupName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tbGroupIconPath = new System.Windows.Forms.TextBox();
			this.lbGroupIconPath = new System.Windows.Forms.Label();
			this.pbGroupIcon = new System.Windows.Forms.PictureBox();
			this.ilGroupIcon = new System.Windows.Forms.ImageList(this.components);
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.btnCancel.Location = new System.Drawing.Point(232, 120);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(72, 24);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOK
			// 
			this.btnOK.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.btnOK.Location = new System.Drawing.Point(152, 120);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(72, 24);
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// tbGroupName
			// 
			this.tbGroupName.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.tbGroupName.Location = new System.Drawing.Point(152, 88);
			this.tbGroupName.Name = "tbGroupName";
			this.tbGroupName.Size = new System.Drawing.Size(152, 20);
			this.tbGroupName.TabIndex = 3;
			this.tbGroupName.Text = "";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label1.Location = new System.Drawing.Point(8, 88);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(136, 20);
			this.label1.TabIndex = 2;
			this.label1.Text = "Enter group name:";
			// 
			// tbGroupIconPath
			// 
			this.tbGroupIconPath.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.tbGroupIconPath.Location = new System.Drawing.Point(152, 48);
			this.tbGroupIconPath.Name = "tbGroupIconPath";
			this.tbGroupIconPath.Size = new System.Drawing.Size(152, 20);
			this.tbGroupIconPath.TabIndex = 1;
			this.tbGroupIconPath.Text = "";
			this.tbGroupIconPath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbGroupIconPath_KeyDown);
			// 
			// lbGroupIconPath
			// 
			this.lbGroupIconPath.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.lbGroupIconPath.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lbGroupIconPath.Location = new System.Drawing.Point(8, 48);
			this.lbGroupIconPath.Name = "lbGroupIconPath";
			this.lbGroupIconPath.Size = new System.Drawing.Size(136, 20);
			this.lbGroupIconPath.TabIndex = 0;
			this.lbGroupIconPath.Text = "Enter Group Icon Path";
			// 
			// pbGroupIcon
			// 
			this.pbGroupIcon.Location = new System.Drawing.Point(152, 8);
			this.pbGroupIcon.Name = "pbGroupIcon";
			this.pbGroupIcon.Size = new System.Drawing.Size(32, 32);
			this.pbGroupIcon.TabIndex = 10;
			this.pbGroupIcon.TabStop = false;
			// 
			// ilGroupIcon
			// 
			this.ilGroupIcon.ImageSize = new System.Drawing.Size(32, 32);
			this.ilGroupIcon.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// NewGroupForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(312, 150);
			this.Controls.Add(this.pbGroupIcon);
			this.Controls.Add(this.tbGroupIconPath);
			this.Controls.Add(this.tbGroupName);
			this.Controls.Add(this.lbGroupIconPath);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.label1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "NewGroupForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "New Group Form";
			this.ResumeLayout(false);

		}
		#endregion

		private void tbGroupIconPath_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				Image im = Service.GetImageFromSrv(tbGroupIconPath.Text);
				this.imGroupImage = im;
				if(im != null)
				{
					//pbGroupIcon.Image = im;
					ilGroupIcon.Images.Clear();
					ilGroupIcon.Images.Add(im);
					this.pbGroupIcon.Image = ilGroupIcon.Images[0];
				}
				else
				{
					pbGroupIcon.Image = null;
					MessageBox.Show("There is no picture in specified location",
						"Picture not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}			
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			string sName = this.tbGroupName.Text.ToString();
			if (Service.IsItemTypeGroupNameExists(sName))
			{
				MessageBox.Show(this, "Item type group with this name already exists. Please, type another name.",
					"Group exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				this.tbGroupName.Text = "";
				this.tbGroupName.Focus();
			}
			else
			{
				this.DialogResult = DialogResult.OK;
			}
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}

		public string GetGroupName()
		{
			return this.tbGroupName.Text.ToString();
		}

		public Image GetGroupImage()
		{
			return this.imGroupImage;
		}

		public string GetPath2Icon()
		{
			return this.tbGroupIconPath.Text.ToString();
		}
	}
}
