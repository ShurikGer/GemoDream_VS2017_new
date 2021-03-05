using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Cntrls
{
	public class AdditionalPrice : System.Windows.Forms.UserControl
	{
		private DataTable dtAdditionalService;
		private System.Windows.Forms.TextBox tbpServicePrice;
		private System.Windows.Forms.ComboBox cbpService;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ErrorProvider errProv1;
		private System.ComponentModel.Container components = null;

		public AdditionalPrice(DataTable iDt, int n)
		{
			InitializeComponent();
			dtAdditionalService = iDt;
			cbpService.DataSource = dtAdditionalService;
			cbpService.DisplayMember = "Name";
			cbpService.ValueMember = "AdditionalServiceID";
			cbpService.SelectedIndex = -1;
			label1.Text = n.ToString();
		}
		
		public AdditionalPrice()
		{
			InitializeComponent();
		}

		public void InitAdditionalService(DataTable iDt, int n)
		{
			dtAdditionalService = iDt;
			cbpService.DataSource = dtAdditionalService;
			cbpService.DisplayMember = "Name";
			cbpService.ValueMember = "AdditionalServiceID";
			cbpService.SelectedIndex = -1;
			label1.Text = n.ToString();
		}

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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tbpServicePrice = new System.Windows.Forms.TextBox();
			this.cbpService = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.errProv1 = new System.Windows.Forms.ErrorProvider();
			this.SuspendLayout();
			// 
			// tbpServicePrice
			// 
			this.tbpServicePrice.Location = new System.Drawing.Point(264, 0);
			this.tbpServicePrice.Name = "tbpServicePrice";
			this.tbpServicePrice.Size = new System.Drawing.Size(128, 20);
			this.tbpServicePrice.TabIndex = 5;
			this.tbpServicePrice.Text = "";
			this.tbpServicePrice.Validating += new System.ComponentModel.CancelEventHandler(this.tbpServicePrice_Validating);
			// 
			// cbpService
			// 
			this.cbpService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbpService.Location = new System.Drawing.Point(16, 0);
			this.cbpService.Name = "cbpService";
			this.cbpService.Size = new System.Drawing.Size(240, 21);
			this.cbpService.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(8, 24);
			this.label1.TabIndex = 6;
			this.label1.Text = "1";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// errProv1
			// 
			this.errProv1.ContainerControl = this;
			// 
			// AdditionalPrice
			// 
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbpServicePrice);
			this.Controls.Add(this.cbpService);
			this.Name = "AdditionalPrice";
			this.Size = new System.Drawing.Size(416, 24);
			this.ResumeLayout(false);

		}
		#endregion

		public string GetASID()
		{
			return cbpService.SelectedValue.ToString();
		}
		public string GetPrice()
		{
			return tbpServicePrice.Text;
		}
		public void SelectAdditionalService(string sASID, string sPrice)
		{
			cbpService.SelectedValue = sASID;
			tbpServicePrice.Text = sPrice;
		}

		private void tbpServicePrice_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (((TextBox)sender).Enabled && ((TextBox)sender).Text != "")
				try
				{
					((TextBox)sender).Text = System.Convert.ToDouble(((TextBox)sender).Text).ToString("0.##");
					errProv1.SetError((TextBox)sender, "");
				}
				catch
				{
					errProv1.SetError((TextBox)sender, "Wrong number format.");
				}
			else errProv1.SetError((TextBox)sender, "");
		}		
	}
}
