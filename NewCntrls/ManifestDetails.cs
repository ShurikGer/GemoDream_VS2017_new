using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Xml;
using gemoDream;

namespace NewCntrls
{
	/// <summary>
	/// Summary description for ManifestDetails.
	/// </summary>
	public class ManifestDetails : System.Windows.Forms.UserControl
	{
		public System.Windows.Forms.TextBox tbOrder;
		public System.Windows.Forms.TextBox tbMainMemo;
		public System.Windows.Forms.TextBox tbBatchSetMemo;
		public System.Windows.Forms.TextBox tbParcel;
		public System.Windows.Forms.TextBox tbEnvelope;
		public System.Windows.Forms.ComboBox cbComments;
		public System.Windows.Forms.Button bDelLine;
		public System.Windows.Forms.TextBox tbQuantity;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ManifestDetails()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitComponent call

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
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
			this.tbOrder = new System.Windows.Forms.TextBox();
			this.tbMainMemo = new System.Windows.Forms.TextBox();
			this.tbBatchSetMemo = new System.Windows.Forms.TextBox();
			this.tbParcel = new System.Windows.Forms.TextBox();
			this.tbEnvelope = new System.Windows.Forms.TextBox();
			this.cbComments = new System.Windows.Forms.ComboBox();
			this.bDelLine = new System.Windows.Forms.Button();
			this.tbQuantity = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// tbOrder
			// 
			this.tbOrder.Location = new System.Drawing.Point(0, 0);
			this.tbOrder.Name = "tbOrder";
			this.tbOrder.Size = new System.Drawing.Size(50, 20);
			this.tbOrder.TabIndex = 0;
			this.tbOrder.Text = "";
			// 
			// tbMainMemo
			// 
			this.tbMainMemo.Location = new System.Drawing.Point(50, 0);
			this.tbMainMemo.Name = "tbMainMemo";
			this.tbMainMemo.TabIndex = 1;
			this.tbMainMemo.Text = "";
			// 
			// tbBatchSetMemo
			// 
			this.tbBatchSetMemo.Location = new System.Drawing.Point(150, 0);
			this.tbBatchSetMemo.Name = "tbBatchSetMemo";
			this.tbBatchSetMemo.TabIndex = 2;
			this.tbBatchSetMemo.Text = "";
			// 
			// tbParcel
			// 
			this.tbParcel.Location = new System.Drawing.Point(250, 0);
			this.tbParcel.Name = "tbParcel";
			this.tbParcel.TabIndex = 3;
			this.tbParcel.Text = "";
			// 
			// tbEnvelope
			// 
			this.tbEnvelope.Location = new System.Drawing.Point(350, 0);
			this.tbEnvelope.Name = "tbEnvelope";
			this.tbEnvelope.TabIndex = 4;
			this.tbEnvelope.Text = "";
			// 
			// cbComments
			// 
			this.cbComments.Location = new System.Drawing.Point(490, 0);
			this.cbComments.Name = "cbComments";
			this.cbComments.Size = new System.Drawing.Size(300, 21);
			this.cbComments.TabIndex = 5;
			// 
			// bDelLine
			// 
			this.bDelLine.Location = new System.Drawing.Point(790, 0);
			this.bDelLine.Name = "bDelLine";
			this.bDelLine.Size = new System.Drawing.Size(45, 20);
			this.bDelLine.TabIndex = 6;
			this.bDelLine.Text = "Delete";
			// 
			// tbQuantity
			// 
			this.tbQuantity.Location = new System.Drawing.Point(450, 0);
			this.tbQuantity.Name = "tbQuantity";
			this.tbQuantity.Size = new System.Drawing.Size(40, 20);
			this.tbQuantity.TabIndex = 8;
			this.tbQuantity.Text = "";
			// 
			// ManifestDetails
			// 
			this.Controls.Add(this.tbQuantity);
			this.Controls.Add(this.bDelLine);
			this.Controls.Add(this.cbComments);
			this.Controls.Add(this.tbEnvelope);
			this.Controls.Add(this.tbParcel);
			this.Controls.Add(this.tbBatchSetMemo);
			this.Controls.Add(this.tbMainMemo);
			this.Controls.Add(this.tbOrder);
			this.Name = "ManifestDetails";
			this.Size = new System.Drawing.Size(840, 21);
			this.ResumeLayout(false);

		}
		#endregion
		}
		
	}

