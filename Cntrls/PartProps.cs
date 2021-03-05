using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Cntrls
{
	/// <summary>
	/// Summary description for PartProps.
	/// </summary>
	
	public class PartProps : System.Windows.Forms.UserControl
	{
		#region form

		private System.Windows.Forms.Panel panel1;
		#endregion form

		//private DataSet dsData;
		//private DataSet dsParts;
		//private DataSet dsOutput;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private Cntrls.PartTree ptPartTree;
		
		public PartProps()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
		}

		public void InitTree(DataTable dtIni)
		{
			ptPartTree.Initialize(dtIni);
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



		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panel1 = new System.Windows.Forms.Panel();
			this.ptPartTree = new Cntrls.PartTree();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
			this.panel1.Location = new System.Drawing.Point(355, 10);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(305, 130);
			this.panel1.TabIndex = 66;
			// 
			// ptPartTree
			// 
			this.ptPartTree.Location = new System.Drawing.Point(0, 10);
			this.ptPartTree.Name = "ptPartTree";
			this.ptPartTree.Size = new System.Drawing.Size(355, 130);
			this.ptPartTree.TabIndex = 67;
			// 
			// PartProps
			// 
			this.Controls.Add(this.ptPartTree);
			this.Controls.Add(this.panel1);
			this.Name = "PartProps";
			this.Size = new System.Drawing.Size(665, 145);
			this.ResumeLayout(false);

		}
		#endregion				
		
	}
}

		
