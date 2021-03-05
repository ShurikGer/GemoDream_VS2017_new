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
		public BillingOptions()
		{
			InitializeComponent();
		}

		public BillingOptions(int BillTo)
		{
			InitializeComponent();
			switch (BillTo)
			{
				case 1:
					cmd_Bill_Default.Text = "Send Invoice to QB primary";
					cmd_BillToQB_primary.Enabled = false;
					billToAccount = 1;
					break;

				case 2:
					cmd_Bill_Default.Text = "Send Invoice to QB corpt";
					cmd_BillToQB_corpt.Enabled = false;
					billToAccount = 2;
					break;

				case 3:
					cmd_Bill_Default.Text = "Send Invoice to Tally";
					cmd_BillToTally.Enabled = false;
					billToAccount = 3;
					break;
			}

		}

		private void cmd_Bill_Default_Click(object sender, EventArgs e)
		{
			AccountRep.billingTo = billToAccount;
			Close();
		}

		private void cmd_BillToQB_primary_Click(object sender, EventArgs e)
		{
			AccountRep.billingTo = 1;
			Close();
		}

		private void cmd_BillToQB_corpt_Click(object sender, EventArgs e)
		{
			AccountRep.billingTo = 2;
			Close();
		}

		private void cmd_BillToTally_Click(object sender, EventArgs e)
		{
			AccountRep.billingTo = 3;
			Close();
		}

		private void BillingOptions_FormClosed(object sender, FormClosedEventArgs e)
		{
			AccountRep.closeExit = true;
		}
	}
}
