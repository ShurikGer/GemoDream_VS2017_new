using System;
using System.Windows.Forms;
using System.Data;

namespace CMStrategy
{
	/// <summary>
	/// Summary description for CMAccessStrategy.
	/// </summary>
	public class CMAccessStrategy:CMStrategy
	{
		private int iAccessLevel;
		public CMAccessStrategy(int i)
		{
			//
			// TODO: Add constructor logic here
			//
			iAccessLevel = i;
		}

		public override void CallManager()
		{
			MessageBox.Show("Call Manager!");
		}

		public override void NewCustomer()
		{
			gemoDream.NewCustomer frm = new gemoDream.NewCustomer(iAccessLevel, 'c');
			frm.ShowDialog();
			//this.Cursor = Cursors.Default;
		}

		public override void NewMessenger(string sCustomerID)
		{
			gemoDream.NewCustomer frm = new gemoDream.NewCustomer(iAccessLevel, sCustomerID);
			frm.ShowDialog();
			//this.Cursor = Cursors.Default;
		}

		public override DataRowView DepartureSettings(string sCustomerName, string sCode)
		{
			gemoDream.DeaprtureForm frm = new gemoDream.DeaprtureForm(sCustomerName, sCode);
			frm.ShowDialog();
			if (frm.SelectedValue["CustomerID"].ToString() == "0") frm.SelectedValue["CustomerID"] = System.DBNull.Value;
			return frm.SelectedValue;
		}

		public override DataRowView DepartureSettings(string sCustomerName)
		{
			gemoDream.DeaprtureForm frm = new gemoDream.DeaprtureForm(sCustomerName);
			frm.ShowDialog();
			if (frm.SelectedValue["CustomerID"].ToString() == "0") frm.SelectedValue["CustomerID"] = System.DBNull.Value;
			return frm.SelectedValue;
		}
	}
}
