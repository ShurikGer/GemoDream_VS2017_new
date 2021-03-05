using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Cntrls;
using System.Data;

namespace gemoDream
{
	/// <summary>
	/// Summary description for ReprintForm.
	/// </summary>
	public class ReprintForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button bOK;
		private Cntrls.OrdersTree otReprintOrders;
		private System.Windows.Forms.Button bCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ReprintForm(DataSet ds)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			try
			{				
				otReprintOrders.Initialize(ds);
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ""+ex.ToString(), "Internal Error", 
					MessageBoxButtons.OK, MessageBoxIcon.Error);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ReprintForm));
			this.bOK = new System.Windows.Forms.Button();
			this.otReprintOrders = new Cntrls.OrdersTree();
			this.bCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// bOK
			// 
			this.bOK.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.bOK.Location = new System.Drawing.Point(245, 195);
			this.bOK.Name = "bOK";
			this.bOK.TabIndex = 1;
			this.bOK.Text = "&OK";
			this.bOK.Click += new System.EventHandler(this.bOK_Click_1);
			// 
			// otReprintOrders
			// 
			this.otReprintOrders.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.otReprintOrders.CheckBoxes = true;
			this.otReprintOrders.IsDocumentGhost = false;
			this.otReprintOrders.IsExpand = false;
			this.otReprintOrders.Location = new System.Drawing.Point(5, 5);
			this.otReprintOrders.Name = "otReprintOrders";
			this.otReprintOrders.Selected = null;
			this.otReprintOrders.ShowColorAndClarity = true;
			this.otReprintOrders.Size = new System.Drawing.Size(655, 185);
			this.otReprintOrders.TabIndex = 0;
			// 
			// bCancel
			// 
			this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.bCancel.Location = new System.Drawing.Point(325, 195);
			this.bCancel.Name = "bCancel";
			this.bCancel.TabIndex = 2;
			this.bCancel.Text = "&Cancel";
			// 
			// ReprintForm
			// 
			this.AcceptButton = this.bOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
			this.CancelButton = this.bCancel;
			this.ClientSize = new System.Drawing.Size(668, 240);
			this.ControlBox = false;
			this.Controls.Add(this.bCancel);
			this.Controls.Add(this.bOK);
			this.Controls.Add(this.otReprintOrders);
			this.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(670, 242);
			this.Name = "ReprintForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Reprint Form";
			this.ResumeLayout(false);

		}
		#endregion

		private void bOK_Click_1(object sender, System.EventArgs e)
		{
			this.Close();
			
			try
			{
				AccountRep.AnalyzeAndPrint(otReprintOrders.GetChecked().Tables["tblItem"]);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message, "Print error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
