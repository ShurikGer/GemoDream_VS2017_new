using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace gemoDream
{
	
	public partial class BillingOptions : Form
	{
		int billToAccount = 0;
		Boolean addressSelected = false;
		
		public BillingOptions()
		{
			InitializeComponent();
		}

		public BillingOptions(int BillTo)
		{
			InitializeComponent();
			AccountRep.closeExit = false;
			switch (BillTo)
			{
				case 1:
					cmd_Bill_Default.Text = "Default: Send Invoice to QB primary";
					cmd_BillToQB_primary.Enabled = false;
					AccountRep.addressToBill = "QB primary";
					billToAccount = 1;
					break;

				case 2:
					cmd_Bill_Default.Text = "Default: Send Invoice to QB corpt";
					cmd_BillToQB_corpt.Enabled = false;
					AccountRep.addressToBill = "QB corpt";
					billToAccount = 2;
					break;

				case 3:
					cmd_Bill_Default.Text = "Deafault: Send Invoice to Tally";
					cmd_BillToTally.Enabled = false;
					AccountRep.addressToBill = "Tally";
					billToAccount = 3;
					break;
			}

		}

		private void cmd_Bill_Default_Click(object sender, EventArgs e)
		{
			AccountRep.billingTo = billToAccount;
			addressSelected = true;
			Close();
		}

		private void cmd_BillToQB_primary_Click(object sender, EventArgs e)
		{
			AccountRep.billingTo = 1;
			AccountRep.addressToBill = "QB primary";
			addressSelected = true;
			Close();
		}

		private void cmd_BillToQB_corpt_Click(object sender, EventArgs e)
		{
			AccountRep.billingTo = 2;
			AccountRep.addressToBill = "QB corpt";
			addressSelected = true;
			Close();
		}

		private void cmd_BillToTally_Click(object sender, EventArgs e)
		{
			AccountRep.billingTo = 3;
			AccountRep.addressToBill = "Tally";
			addressSelected = true;
			Close();
		}

		//private void cmd_Cancel_Click(object sender, EventArgs e)
		//{
		//	AccountRep.closeExit = true;
		//	Close();
		//}

		private void BillingOptions_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (!addressSelected)
			{
				AccountRep.closeExit = true;
				AccountRep.addressToBill = "";
			}
			Close();
		}
	}
}
