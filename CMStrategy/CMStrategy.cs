using System;
using System.Data;

namespace CMStrategy
{
	/// <summary>
	/// Summary description for CMStrategy.
	/// </summary>
	public abstract class CMStrategy
	{
		private int iAccessLevel;
		public abstract void CallManager();
		public abstract void NewCustomer();
		public abstract void NewMessenger(string sCustomerID);
		public abstract DataRowView DepartureSettings(string sCustomerName);
		public abstract DataRowView DepartureSettings(string sCustomerName, string sCode);

		public CMStrategy()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}
}
