using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace Cntrls
{
	public class OrdersTree2 : Cntrls.OrdersTree
	{
		private System.ComponentModel.IContainer components = null;

		public OrdersTree2()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		
		public event EventHandler WrongCheck;
		public event EventHandler CorrectCheck;

		protected virtual void Changed(EventArgs ea)
		{
			if(WrongCheck != null)
				WrongCheck(this, ea);
		}

		protected virtual void ChangeOk(EventArgs ea)
		{
			if(CorrectCheck != null)
				CorrectCheck(this, ea);
		}

		protected override void tvOrders_AfterCheck(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if(((OrderNode)e.Node).tblName != "tblItem" && ((OrderNode)e.Node).tblName != "tblOrder")
			{
				if(e.Node.Checked)
				{
					e.Node.Checked = false;
					Changed(EventArgs.Empty);
				}
			}	
			else
			{
				if(((OrderNode)e.Node).tblName == "tblOrder")
					CheckItems(this, (OrderNode)e.Node, ((OrderNode)e.Node).Checked);
				ChangeOk(EventArgs.Empty);
			}
		}

		private void CheckItems(OrdersTree otCurrent, OrderNode noTemp, bool isChecked)
		{
			if(noTemp.tblName == "tblItem")
				noTemp.Checked = isChecked;
			else 
				for(int i = 0; i < noTemp.Nodes.Count; i++)
					CheckItems(otCurrent, (OrderNode)noTemp.Nodes[i], isChecked);
		}
		
		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion
	}
}
