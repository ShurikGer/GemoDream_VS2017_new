using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Linq;

namespace Cntrls
{
	/// <summary>
	/// Summary description for UserControl1.
	/// </summary>
	public class CustomerOrder : System.Windows.Forms.UserControl
	{
		private DataSet dsOrder;
		private int index;
		private bool isChange;
		internal System.Windows.Forms.GroupBox GroupBox5;
		internal System.Windows.Forms.Label Label12;
		internal System.Windows.Forms.Label Label13;
		internal System.Windows.Forms.Label Label14;
		internal System.Windows.Forms.Label Label15;
		internal System.Windows.Forms.CheckBox cbMemo;
		internal System.Windows.Forms.TextBox tbMemo;
		internal System.Windows.Forms.TextBox tbSpecInstr;
		internal System.Windows.Forms.ComboBox cbServiceType;
		internal System.Windows.Forms.RadioButton rbTotalWeight3;
		internal System.Windows.Forms.RadioButton rbTotalWeight2;
		internal System.Windows.Forms.RadioButton rbTotalWeight1;
		internal System.Windows.Forms.RadioButton rbNumOfItem3;
		internal System.Windows.Forms.RadioButton rbNumOfItem2;
		internal System.Windows.Forms.RadioButton rbNumOfItem1;
		internal System.Windows.Forms.Panel Panel1;
		internal System.Windows.Forms.Panel Panel2;
		private Cntrls.WeightControl wcWeight;
		private Cntrls.IntField ifNumOfItem;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox tbMN;
		private System.Windows.Forms.ListBox lbMNs;
		private System.Windows.Forms.Label lblMainMemo;
		private System.Windows.Forms.TextBox tbOrderMemo;
	//	private Cntrls.IntField ifNumOfItem;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CustomerOrder()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			isChange = false;

			// TODO: Add any initialization after the InitializeComponent call

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
			this.GroupBox5 = new System.Windows.Forms.GroupBox();
			this.lblMainMemo = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tbMN = new System.Windows.Forms.TextBox();
			this.lbMNs = new System.Windows.Forms.ListBox();
			this.ifNumOfItem = new Cntrls.IntField();
			this.wcWeight = new Cntrls.WeightControl();
			this.cbMemo = new System.Windows.Forms.CheckBox();
			this.tbMemo = new System.Windows.Forms.TextBox();
			this.tbSpecInstr = new System.Windows.Forms.TextBox();
			this.Label12 = new System.Windows.Forms.Label();
			this.cbServiceType = new System.Windows.Forms.ComboBox();
			this.Label13 = new System.Windows.Forms.Label();
			this.Panel2 = new System.Windows.Forms.Panel();
			this.rbTotalWeight3 = new System.Windows.Forms.RadioButton();
			this.rbTotalWeight2 = new System.Windows.Forms.RadioButton();
			this.rbTotalWeight1 = new System.Windows.Forms.RadioButton();
			this.Label14 = new System.Windows.Forms.Label();
			this.Panel1 = new System.Windows.Forms.Panel();
			this.rbNumOfItem3 = new System.Windows.Forms.RadioButton();
			this.rbNumOfItem2 = new System.Windows.Forms.RadioButton();
			this.rbNumOfItem1 = new System.Windows.Forms.RadioButton();
			this.Label15 = new System.Windows.Forms.Label();
			this.tbOrderMemo = new System.Windows.Forms.TextBox();
			this.GroupBox5.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.Panel2.SuspendLayout();
			this.Panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// GroupBox5
			// 
			this.GroupBox5.Controls.Add(this.groupBox1);
			this.GroupBox5.Controls.Add(this.ifNumOfItem);
			this.GroupBox5.Controls.Add(this.wcWeight);
			this.GroupBox5.Controls.Add(this.cbMemo);
			this.GroupBox5.Controls.Add(this.tbSpecInstr);
			this.GroupBox5.Controls.Add(this.Label12);
			this.GroupBox5.Controls.Add(this.cbServiceType);
			this.GroupBox5.Controls.Add(this.Label13);
			this.GroupBox5.Controls.Add(this.Panel2);
			this.GroupBox5.Controls.Add(this.Label14);
			this.GroupBox5.Controls.Add(this.Panel1);
			this.GroupBox5.Controls.Add(this.Label15);
			this.GroupBox5.Controls.Add(this.tbMemo);
			this.GroupBox5.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
			this.GroupBox5.ForeColor = System.Drawing.Color.DimGray;
			this.GroupBox5.Location = new System.Drawing.Point(0, 0);
			this.GroupBox5.Name = "GroupBox5";
			this.GroupBox5.Size = new System.Drawing.Size(810, 160);
			this.GroupBox5.TabIndex = 0;
			this.GroupBox5.TabStop = false;
			this.GroupBox5.Text = "Order";
			// 
			// lblMainMemo
			// 
			this.lblMainMemo.ForeColor = System.Drawing.Color.Black;
			this.lblMainMemo.Location = new System.Drawing.Point(200, 8);
			this.lblMainMemo.Name = "lblMainMemo";
			this.lblMainMemo.Size = new System.Drawing.Size(136, 24);
			this.lblMainMemo.TabIndex = 12;
			this.lblMainMemo.Text = "Order Memo";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tbOrderMemo);
			this.groupBox1.Controls.Add(this.tbMN);
			this.groupBox1.Controls.Add(this.lbMNs);
			this.groupBox1.Controls.Add(this.lblMainMemo);
			this.groupBox1.Location = new System.Drawing.Point(448, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(352, 144);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Batches Memo Numbers";
			// 
			// tbMN
			// 
			this.tbMN.Location = new System.Drawing.Point(8, 16);
			this.tbMN.Name = "tbMN";
			this.tbMN.Size = new System.Drawing.Size(184, 20);
			this.tbMN.TabIndex = 11;
			this.tbMN.Text = "";
			this.tbMN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbMN_KeyDown);
			// 
			// lbMNs
			// 
			this.lbMNs.HorizontalScrollbar = true;
			this.lbMNs.ItemHeight = 12;
			this.lbMNs.Location = new System.Drawing.Point(8, 40);
			this.lbMNs.Name = "lbMNs";
			this.lbMNs.Size = new System.Drawing.Size(184, 100);
			this.lbMNs.TabIndex = 10;
			this.lbMNs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbMNs_KeyDown);
			this.lbMNs.DoubleClick += new System.EventHandler(this.lbMNs_DoubleClick);
			// 
			// ifNumOfItem
			// 
			this.ifNumOfItem.Enabled = false;
			this.ifNumOfItem.IsRequered = true;
			this.ifNumOfItem.Location = new System.Drawing.Point(88, 16);
			this.ifNumOfItem.Name = "ifNumOfItem";
			this.ifNumOfItem.Size = new System.Drawing.Size(109, 20);
			this.ifNumOfItem.TabIndex = 1;
			this.ifNumOfItem.Leave += new System.EventHandler(this.ifNumOfItem_Leave);
			// 
			// wcWeight
			// 
			this.wcWeight.Enabled = false;
			this.wcWeight.IsMeasureUnit = true;
			this.wcWeight.IsRequired = true;
			this.wcWeight.Location = new System.Drawing.Point(88, 43);
			this.wcWeight.Name = "wcWeight";
			this.wcWeight.Size = new System.Drawing.Size(109, 24);
			this.wcWeight.TabIndex = 3;
			this.wcWeight.Leave += new System.EventHandler(this.wcWeight_Leave);
			// 
			// cbMemo
			// 
			this.cbMemo.Checked = true;
			this.cbMemo.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbMemo.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
			this.cbMemo.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cbMemo.Location = new System.Drawing.Point(8, 136);
			this.cbMemo.Name = "cbMemo";
			this.cbMemo.Size = new System.Drawing.Size(45, 15);
			this.cbMemo.TabIndex = 8;
			this.cbMemo.Text = "N/A";
			this.cbMemo.Visible = false;
			this.cbMemo.CheckedChanged += new System.EventHandler(this.cbMemo_CheckedChanged);
			// 
			// tbMemo
			// 
			this.tbMemo.Enabled = false;
			this.tbMemo.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
			this.tbMemo.ForeColor = System.Drawing.SystemColors.WindowText;
			this.tbMemo.Location = new System.Drawing.Point(56, 128);
			this.tbMemo.Name = "tbMemo";
			this.tbMemo.Size = new System.Drawing.Size(8, 20);
			this.tbMemo.TabIndex = 7;
			this.tbMemo.Text = "";
			this.tbMemo.Visible = false;
			this.tbMemo.Leave += new System.EventHandler(this.tbMemo_Leave);
			// 
			// tbSpecInstr
			// 
			this.tbSpecInstr.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
			this.tbSpecInstr.Location = new System.Drawing.Point(88, 95);
			this.tbSpecInstr.Multiline = true;
			this.tbSpecInstr.Name = "tbSpecInstr";
			this.tbSpecInstr.Size = new System.Drawing.Size(357, 57);
			this.tbSpecInstr.TabIndex = 5;
			this.tbSpecInstr.Text = "";
			// 
			// Label12
			// 
			this.Label12.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
			this.Label12.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label12.Location = new System.Drawing.Point(10, 96);
			this.Label12.Name = "Label12";
			this.Label12.Size = new System.Drawing.Size(100, 30);
			this.Label12.TabIndex = 9;
			this.Label12.Text = "Special Instructions";
			// 
			// cbServiceType
			// 
			this.cbServiceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbServiceType.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
			this.cbServiceType.Location = new System.Drawing.Point(88, 70);
			this.cbServiceType.Name = "cbServiceType";
			this.cbServiceType.Size = new System.Drawing.Size(357, 20);
			this.cbServiceType.TabIndex = 4;
			this.cbServiceType.SelectedIndexChanged += new System.EventHandler(this.cbServiceType_SelectedIndexChanged);
			// 
			// Label13
			// 
			this.Label13.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
			this.Label13.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label13.Location = new System.Drawing.Point(10, 72);
			this.Label13.Name = "Label13";
			this.Label13.Size = new System.Drawing.Size(100, 15);
			this.Label13.TabIndex = 7;
			this.Label13.Text = "Service Type";
			// 
			// Panel2
			// 
			this.Panel2.Controls.Add(this.rbTotalWeight3);
			this.Panel2.Controls.Add(this.rbTotalWeight2);
			this.Panel2.Controls.Add(this.rbTotalWeight1);
			this.Panel2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
			this.Panel2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Panel2.Location = new System.Drawing.Point(200, 40);
			this.Panel2.Name = "Panel2";
			this.Panel2.Size = new System.Drawing.Size(245, 24);
			this.Panel2.TabIndex = 2;
			// 
			// rbTotalWeight3
			// 
			this.rbTotalWeight3.Checked = true;
			this.rbTotalWeight3.Location = new System.Drawing.Point(195, 5);
			this.rbTotalWeight3.Name = "rbTotalWeight3";
			this.rbTotalWeight3.Size = new System.Drawing.Size(45, 15);
			this.rbTotalWeight3.TabIndex = 2;
			this.rbTotalWeight3.TabStop = true;
			this.rbTotalWeight3.Text = "N/A";
			this.rbTotalWeight3.CheckedChanged += new System.EventHandler(this.rbTotalWeight3_CheckedChanged);
			// 
			// rbTotalWeight2
			// 
			this.rbTotalWeight2.Location = new System.Drawing.Point(90, 5);
			this.rbTotalWeight2.Name = "rbTotalWeight2";
			this.rbTotalWeight2.Size = new System.Drawing.Size(95, 15);
			this.rbTotalWeight2.TabIndex = 1;
			this.rbTotalWeight2.Text = "Not Inspected";
			this.rbTotalWeight2.CheckedChanged += new System.EventHandler(this.wcWeight_Leave);
			// 
			// rbTotalWeight1
			// 
			this.rbTotalWeight1.Location = new System.Drawing.Point(5, 5);
			this.rbTotalWeight1.Name = "rbTotalWeight1";
			this.rbTotalWeight1.Size = new System.Drawing.Size(75, 15);
			this.rbTotalWeight1.TabIndex = 0;
			this.rbTotalWeight1.Text = "Inspected";
			this.rbTotalWeight1.CheckedChanged += new System.EventHandler(this.wcWeight_Leave);
			// 
			// Label14
			// 
			this.Label14.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
			this.Label14.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label14.Location = new System.Drawing.Point(10, 48);
			this.Label14.Name = "Label14";
			this.Label14.Size = new System.Drawing.Size(100, 15);
			this.Label14.TabIndex = 3;
			this.Label14.Text = "Total Weight";
			// 
			// Panel1
			// 
			this.Panel1.Controls.Add(this.rbNumOfItem3);
			this.Panel1.Controls.Add(this.rbNumOfItem2);
			this.Panel1.Controls.Add(this.rbNumOfItem1);
			this.Panel1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
			this.Panel1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Panel1.Location = new System.Drawing.Point(200, 15);
			this.Panel1.Name = "Panel1";
			this.Panel1.Size = new System.Drawing.Size(245, 20);
			this.Panel1.TabIndex = 0;
			// 
			// rbNumOfItem3
			// 
			this.rbNumOfItem3.Checked = true;
			this.rbNumOfItem3.Location = new System.Drawing.Point(195, 5);
			this.rbNumOfItem3.Name = "rbNumOfItem3";
			this.rbNumOfItem3.Size = new System.Drawing.Size(45, 15);
			this.rbNumOfItem3.TabIndex = 2;
			this.rbNumOfItem3.TabStop = true;
			this.rbNumOfItem3.Text = "N/A";
			this.rbNumOfItem3.CheckedChanged += new System.EventHandler(this.rbNumOfItem3_CheckedChanged);
			// 
			// rbNumOfItem2
			// 
			this.rbNumOfItem2.Location = new System.Drawing.Point(90, 5);
			this.rbNumOfItem2.Name = "rbNumOfItem2";
			this.rbNumOfItem2.Size = new System.Drawing.Size(95, 15);
			this.rbNumOfItem2.TabIndex = 1;
			this.rbNumOfItem2.Text = "Not Inspected";
			this.rbNumOfItem2.CheckedChanged += new System.EventHandler(this.ifNumOfItem_Leave);
			// 
			// rbNumOfItem1
			// 
			this.rbNumOfItem1.Location = new System.Drawing.Point(5, 5);
			this.rbNumOfItem1.Name = "rbNumOfItem1";
			this.rbNumOfItem1.Size = new System.Drawing.Size(75, 15);
			this.rbNumOfItem1.TabIndex = 0;
			this.rbNumOfItem1.Text = "Inspected";
			this.rbNumOfItem1.CheckedChanged += new System.EventHandler(this.ifNumOfItem_Leave);
			// 
			// Label15
			// 
			this.Label15.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
			this.Label15.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label15.Location = new System.Drawing.Point(10, 20);
			this.Label15.Name = "Label15";
			this.Label15.Size = new System.Drawing.Size(70, 28);
			this.Label15.TabIndex = 0;
			this.Label15.Text = "Number Of Items";
			// 
			// tbOrderMemo
			// 
			this.tbOrderMemo.Location = new System.Drawing.Point(200, 32);
			this.tbOrderMemo.Name = "tbOrderMemo";
			this.tbOrderMemo.Size = new System.Drawing.Size(136, 20);
			this.tbOrderMemo.TabIndex = 13;
			this.tbOrderMemo.Text = "";
			// 
			// CustomerOrder
			// 
			this.Controls.Add(this.GroupBox5);
			this.Name = "CustomerOrder";
			this.Size = new System.Drawing.Size(815, 162);
			this.GroupBox5.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.Panel2.ResumeLayout(false);
			this.Panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public void InitializeOrder(DataSet dsOrder)
		{
			this.dsOrder = dsOrder;
			//DataTable dtMeasureUnit = this.dsOrder.Tables["tblMeasureUnit"];
			
			DataTable dtServiceType = this.dsOrder.Tables["tblServiceType"];

			DataView dvMeasureUnit = this.dsOrder.Tables["tblMeasureUnit"].DefaultView;
			dvMeasureUnit.Sort = "MeasureUnitID Asc";
			//dvMeasureUnit.RowFilter = "MeasureUnitCode = 1 OR MeasureUnitCode = 1";
			wcWeight.Initialize(dvMeasureUnit);

			DataView dvServiceType = dtServiceType.DefaultView;
			dvServiceType.Sort = "ServiceTypeID Asc";
			cbServiceType.DataSource = dtServiceType;
			cbServiceType.DisplayMember = "ServiceTypeName";
			cbServiceType.ValueMember = "ServiceTypeID";

			//tbMemo.Enabled = true;
			ifNumOfItem_Leave(null, null);
			wcWeight_Leave(null, null);
			tbMemo_Leave(null, null);
		}


		private void cbMemo_CheckedChanged(object sender, System.EventArgs e)
		{			
			tbMemo.Enabled = !cbMemo.Checked;
			tbMemo_Leave(sender,e);
		}
		private void rbTotalWeight3_CheckedChanged(object sender, System.EventArgs e)
		{
			wcWeight.Enabled = !rbTotalWeight3.Checked;
			wcWeight_Leave(sender, e);
		}
		private void rbNumOfItem3_CheckedChanged(object sender, System.EventArgs e)
		{
			ifNumOfItem.Enabled = !rbNumOfItem3.Checked;
			ifNumOfItem_Leave(sender, e);
		}

		public void ClearOrder()
		{	
			wcWeight.Clear();
			ifNumOfItem.Clear();
		
			cbServiceType.SelectedIndex = 0;			
			ifNumOfItem.Text="";			
			tbSpecInstr.Text="";
			tbOrderMemo.Text = "";
			tbMemo.Text="";
			lbMNs.Items.Clear();
			tbMN.Text = "";
			rbNumOfItem1.Checked = false;
			rbNumOfItem2.Checked = false;
			rbNumOfItem3.Checked = true;
			rbTotalWeight1.Checked = false;
			rbTotalWeight2.Checked = false;
			rbTotalWeight3.Checked = true;
			cbMemo.Checked = true;
					
			ifNumOfItem_Leave(null, null);
			wcWeight_Leave(null, null);
			cbServiceType_SelectedIndexChanged(null, null);
			tbMemo_Leave(null, null);

		}
		public void GetBatch(DataRow drBatch)
		{		
            //String sExpMsg = "Some fields are not filled or incorrect typed data";
            int iServiceType = Convert.ToInt16(cbServiceType.SelectedValue);

			if (this.rbNumOfItem1.Checked) drBatch["IsTWInspected"] = 1;
			else if (this.rbNumOfItem2.Checked) drBatch["IsTWInspected"] = 2;
			else if (this.rbNumOfItem3.Checked) drBatch["IsTWInspected"] = 0;
			


			if (this.rbTotalWeight1.Checked) drBatch["IsIQInspected"] = 1;
			else if (this.rbTotalWeight2.Checked) drBatch["IsIQInspected"] = 2;
			else if (this.rbTotalWeight3.Checked) drBatch["IsIQInspected"] = 0;

            try
            {
                //if (iServiceType == 7)
                //{
                //    var orderMemos = getListOfMemoNumbers();
                //    var itemQuantity = 0;
                //    if (orderMemos.Length > 0)
                //    {
                //        if (!rbNumOfItem3.Checked || ifNumOfItem.Text =="")
                //            foreach (var lines in orderMemos)
                //            {
                //                if (lines.Contains("/"))
                //                {
                //                    var strMemoline = lines.Substring(lines.IndexOf("/") + 1);
                //                    strMemoline = new string(strMemoline.Where(x => char.IsDigit(x)).ToArray());
                //                    int iOut = 0;
                //                    int.TryParse(strMemoline, out iOut);
                //                    itemQuantity = itemQuantity + iOut;
                //                }
                //            }
                //    }
                //    if (itemQuantity > 0) drBatch["ItemsQuantity"] = itemQuantity;
                //    //else drBatch["ItemsQuantity"] = 1000;
                //}

                //else
                {
                    if (!rbNumOfItem3.Checked)
                    {
                        drBatch["ItemsQuantity"] = ifNumOfItem.Get();
                    }
                }

            }
            catch (Exception ex)
            { }

			if (!rbTotalWeight3.Checked)
			{
				wcWeight.Get(drBatch);
			}

            drBatch["ServiceTypeID"] = iServiceType; // cbServiceType.SelectedValue;
			
			if (this.tbSpecInstr.ToString().Length>0)
			{
				drBatch["SpecialInstruction"]=tbSpecInstr.Text;   
			}
			

			if (this.cbMemo.Checked)
			{
				drBatch["IsMemo"]=1;
			}
			else drBatch["IsMemo"]= 0;
			
				
				if (this.tbOrderMemo.ToString().Trim().Length > 0)
				{
					drBatch["Memo"] = tbOrderMemo.Text.Trim();
				}
				//else throw new Exception(sExpMsg);
			
		}
		
		public event System.EventHandler Changed;		
		private void ifNumOfItem_Leave(object sender, System.EventArgs e)
		{
			string sEvnText;
			sEvnText = "Number Of Items";
			if (rbNumOfItem1.Checked) sEvnText += " (" + rbNumOfItem1.Text + "): ";
			else if (rbNumOfItem2.Checked) sEvnText += " (" + rbNumOfItem2.Text + "): ";
			else if (rbNumOfItem3.Checked) sEvnText += ": " + rbNumOfItem3.Text;
		
			try{sEvnText += ifNumOfItem.Get();}
			catch{}
		
			if (Changed != null) Changed(sender, new MyEventArgs(0,sEvnText));
		}

		private void wcWeight_Leave(object sender, System.EventArgs e)
		{
			string sEvnText;
			sEvnText = "Total Weight";
			if (rbTotalWeight1.Checked) sEvnText += " (" + rbTotalWeight1.Text + "): ";
			else if (rbTotalWeight2.Checked) sEvnText += " (" + rbTotalWeight2.Text + "): ";
			else if (rbTotalWeight3.Checked) sEvnText += ": " + rbTotalWeight3.Text;
		
			try
			{
				sEvnText += wcWeight.Weight;
				sEvnText += " " + wcWeight.MeasureUnitName;
			}
			catch{}			
		
			if (Changed != null) Changed(sender, new MyEventArgs(1,sEvnText));
			cbServiceType_SelectedIndexChanged(sender,e);		
		}

		private void cbServiceType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string sEvnText = "ServiceType: " + ((DataRowView)cbServiceType.SelectedItem)["ServiceTypeName"].ToString();
			if (Changed != null) Changed(sender, new MyEventArgs(2,sEvnText));
		}

		private void tbMemo_Leave(object sender, System.EventArgs e)
		{
			string sEvnText = "Memo: ";

			if (cbMemo.Checked) sEvnText += cbMemo.Text;
			else sEvnText += tbMemo.Text;			
			if (Changed != null) Changed(sender, new MyEventArgs(3,sEvnText));
		}

		private void tbMN_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				string sMemoNumber;
				string sMemoNumberShort;
	
				if(((System.Windows.Forms.TextBox)sender).Text != "")
				{
					sMemoNumber = ((System.Windows.Forms.TextBox)sender).Text.Trim();
					sMemoNumberShort = sMemoNumber.ToUpper();
					if (sMemoNumber.IndexOf("/") > 0)
					{
						sMemoNumberShort = sMemoNumber.Substring(0, sMemoNumber.IndexOf("/"));
					}
					if(isChange)
					{
						if(lbMNs.Items.IndexOf(sMemoNumberShort) != -1)
						{
							MessageBox.Show(this, "This MemoNumber already entered", "Wrong MemoNumber", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
						else
						{
							isChange = false;
							lbMNs.Items.Insert(index, tbMN.Text);
							tbMN.Text = "";
						}
					}
					else
					{
						if(lbMNs.Items.IndexOf(sMemoNumberShort) != -1)
						{
							MessageBox.Show(this, "This MemoNumber already entered", "Wrong MemoNumber", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
						else
						{
							lbMNs.Items.Add(tbMN.Text);
							tbMN.Text = "";
						}
					}
				}
			}
		}

		private void lbMNs_DoubleClick(object sender, System.EventArgs e)
		{
			if (lbMNs.SelectedIndex > -1)
			{
				tbMN.Text = lbMNs.SelectedItem.ToString();
				index = lbMNs.SelectedIndex;
				lbMNs.Items.RemoveAt(index);
				isChange = true;
				tbMN.Focus();
			}
		}

		private void lbMNs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Delete)
			{
				if(lbMNs.SelectedIndex != -1)
				{
					lbMNs.Items.RemoveAt(lbMNs.SelectedIndex);
				}
				tbMN.Focus();
			}
		}
		public string[] getListOfMemoNumbers()
		{
	
			if (lbMNs.Items.Count == 0)
				lbMNs.Items.Add(tbOrderMemo.Text.Trim());
			string []memoNumbers = new string[lbMNs.Items.Count];
			for(int i = 0; i < lbMNs.Items.Count; i++)
			{
				memoNumbers[i] = lbMNs.Items[i].ToString();
			}
			return memoNumbers;
		}
	}

	
	public class MyEventArgs:System.EventArgs
	{
		public MyEventArgs(int iIndex, string sText)
		{
			Text = sText;
			Index = iIndex;
		}
		public string Text;
		public int Index;
	
	}
}
