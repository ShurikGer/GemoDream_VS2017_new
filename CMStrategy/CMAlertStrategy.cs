using System;
using System.Windows.Forms;
using System.Data;

namespace CMStrategy
{
	/// <summary>
	/// Summary description for CMAlertStrategy.
	/// </summary>
	internal class CMAlertStrategy : CMStrategy
	{
		private int iAccessLevel;
		public CMAlertStrategy(int i)
		{
			iAccessLevel = i;
		}
		public override void CallManager()
		{
			MessageBox.Show("Call Manager!");
		}

		public override void NewCustomer()
		{
			MessageBox.Show("Call Manager!");
		}
		public override void NewMessenger(string sCustomerID)
		{
			MessageBox.Show("Call Manager!");
		}

		public override DataRowView DepartureSettings(string sCustomerName)			
		{
			MessageBox.Show("Call Manager!");
			return ((DataRowView)new Object());
		}

		public override DataRowView DepartureSettings(string sCustomerName, string sCode)			
		{
			MessageBox.Show("Call Manager!");
			return ((DataRowView)new Object());
		}
	}
}
