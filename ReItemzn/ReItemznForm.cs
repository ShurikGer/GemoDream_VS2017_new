using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace gemoDream
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class ReItemiznForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Button btnStartGrouping;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.StatusBar sbStatus;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.TextBox tbItemsInspected;
		internal System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label9;
		private Cntrls.OrdersTree otParent;
		private Cntrls.OrdersTree otNewVersion;
		private System.Windows.Forms.Button btnSetBatch;
		private System.Windows.Forms.Button btnSetItem;
		private System.Windows.Forms.Panel pNewVersion;
		private System.Windows.Forms.Button btnUpdate;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.Button btnDelete;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button btnParentInValid;
		private System.Windows.Forms.Button btnParentValid;
		private System.Windows.Forms.Button btnNewVersionInValid;
		private System.Windows.Forms.Button btnNewVersionValid;
		private Cntrls.WeightControl weightControl;
		private Cntrls.BarCode tbBarCode;
		private int accessCode = 0;

		public ReItemiznForm(int iAccessCode)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.Text = Service.sProgramTitle + this.Text;

			accessCode = iAccessCode;
			
			weightControl.Initialize(Service.GetMeasureUnits().DefaultView);
			Service.GetMeasureUnits();
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ReItemiznForm));
			this.otParent = new Cntrls.OrdersTree();
			this.pNewVersion = new System.Windows.Forms.Panel();
			this.btnDelete = new System.Windows.Forms.Button();
			this.panel4 = new System.Windows.Forms.Panel();
			this.btnNewVersionInValid = new System.Windows.Forms.Button();
			this.btnNewVersionValid = new System.Windows.Forms.Button();
			this.otNewVersion = new Cntrls.OrdersTree();
			this.panel5 = new System.Windows.Forms.Panel();
			this.weightControl = new Cntrls.WeightControl();
			this.tbItemsInspected = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.btnStartGrouping = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnParentInValid = new System.Windows.Forms.Button();
			this.btnParentValid = new System.Windows.Forms.Button();
			this.btnSetBatch = new System.Windows.Forms.Button();
			this.btnSetItem = new System.Windows.Forms.Button();
			this.sbStatus = new System.Windows.Forms.StatusBar();
			this.btnUpdate = new System.Windows.Forms.Button();
			this.btnClear = new System.Windows.Forms.Button();
			this.tbBarCode = new Cntrls.BarCode();
			this.pNewVersion.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// otParent
			// 
			this.otParent.CheckBoxes = true;
			this.otParent.IsDocumentGhost = false;
			this.otParent.IsExpand = true;
			this.otParent.Location = new System.Drawing.Point(10, 25);
			this.otParent.Name = "otParent";
			this.otParent.Selected = null;
			this.otParent.ShowColorAndClarity = true;
			this.otParent.Size = new System.Drawing.Size(685, 170);
			this.otParent.TabIndex = 1;
			// 
			// pNewVersion
			// 
			this.pNewVersion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pNewVersion.Controls.Add(this.btnDelete);
			this.pNewVersion.Controls.Add(this.panel4);
			this.pNewVersion.Controls.Add(this.otNewVersion);
			this.pNewVersion.Controls.Add(this.panel5);
			this.pNewVersion.Enabled = false;
			this.pNewVersion.Location = new System.Drawing.Point(5, 250);
			this.pNewVersion.Name = "pNewVersion";
			this.pNewVersion.Size = new System.Drawing.Size(700, 230);
			this.pNewVersion.TabIndex = 2;
			// 
			// btnDelete
			// 
			this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
			this.btnDelete.Location = new System.Drawing.Point(5, 175);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(25, 25);
			this.btnDelete.TabIndex = 26;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.btnNewVersionInValid);
			this.panel4.Controls.Add(this.btnNewVersionValid);
			this.panel4.Location = new System.Drawing.Point(370, 178);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(320, 20);
			this.panel4.TabIndex = 10;
			// 
			// btnNewVersionInValid
			// 
			this.btnNewVersionInValid.BackColor = System.Drawing.Color.LightPink;
			this.btnNewVersionInValid.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
			this.btnNewVersionInValid.Location = new System.Drawing.Point(175, 0);
			this.btnNewVersionInValid.Name = "btnNewVersionInValid";
			this.btnNewVersionInValid.Size = new System.Drawing.Size(145, 20);
			this.btnNewVersionInValid.TabIndex = 8;
			this.btnNewVersionInValid.Text = "Invalid ";
			this.btnNewVersionInValid.Click += new System.EventHandler(this.btnNewVersionInValid_Click);
			// 
			// btnNewVersionValid
			// 
			this.btnNewVersionValid.BackColor = System.Drawing.Color.LightSteelBlue;
			this.btnNewVersionValid.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
			this.btnNewVersionValid.Location = new System.Drawing.Point(0, 0);
			this.btnNewVersionValid.Name = "btnNewVersionValid";
			this.btnNewVersionValid.Size = new System.Drawing.Size(145, 20);
			this.btnNewVersionValid.TabIndex = 7;
			this.btnNewVersionValid.Text = "Valid ";
			this.btnNewVersionValid.Click += new System.EventHandler(this.btnNewVersionValid_Click);
			// 
			// otNewVersion
			// 
			this.otNewVersion.CheckBoxes = true;
			this.otNewVersion.IsDocumentGhost = false;
			this.otNewVersion.IsExpand = true;
			this.otNewVersion.Location = new System.Drawing.Point(5, 5);
			this.otNewVersion.Name = "otNewVersion";
			this.otNewVersion.Selected = null;
			this.otNewVersion.ShowColorAndClarity = true;
			this.otNewVersion.Size = new System.Drawing.Size(685, 170);
			this.otNewVersion.TabIndex = 0;
			this.otNewVersion.SelectedItemChanged += new System.EventHandler(this.otNewVersion_SelectedItemChanged);
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.weightControl);
			this.panel5.Controls.Add(this.tbItemsInspected);
			this.panel5.Controls.Add(this.label7);
			this.panel5.Controls.Add(this.label9);
			this.panel5.Location = new System.Drawing.Point(5, 205);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(685, 20);
			this.panel5.TabIndex = 25;
			// 
			// weightControl
			// 
			this.weightControl.IsMeasureUnit = true;
			this.weightControl.IsRequired = false;
			this.weightControl.Location = new System.Drawing.Point(415, 0);
			this.weightControl.Name = "weightControl";
			this.weightControl.Size = new System.Drawing.Size(270, 20);
			this.weightControl.TabIndex = 7;
			this.weightControl.Weight = "";
			// 
			// tbItemsInspected
			// 
			this.tbItemsInspected.Enabled = false;
			this.tbItemsInspected.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
			this.tbItemsInspected.Location = new System.Drawing.Point(155, 0);
			this.tbItemsInspected.Name = "tbItemsInspected";
			this.tbItemsInspected.TabIndex = 6;
			this.tbItemsInspected.Text = "";
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
			this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label7.Location = new System.Drawing.Point(280, 5);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(130, 15);
			this.label7.TabIndex = 4;
			this.label7.Text = "Inspected Total Weight";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(0, 5);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(145, 15);
			this.label9.TabIndex = 0;
			this.label9.Text = "Inspected Items Quantity";
			// 
			// panel3
			// 
			this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
			this.panel3.Controls.Add(this.btnStartGrouping);
			this.panel3.Location = new System.Drawing.Point(10, 225);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(685, 20);
			this.panel3.TabIndex = 8;
			// 
			// btnStartGrouping
			// 
			this.btnStartGrouping.BackColor = System.Drawing.Color.LightSteelBlue;
			this.btnStartGrouping.Enabled = false;
			this.btnStartGrouping.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
			this.btnStartGrouping.Location = new System.Drawing.Point(365, 0);
			this.btnStartGrouping.Name = "btnStartGrouping";
			this.btnStartGrouping.Size = new System.Drawing.Size(320, 20);
			this.btnStartGrouping.TabIndex = 6;
			this.btnStartGrouping.Text = "New Group Version";
			this.btnStartGrouping.Click += new System.EventHandler(this.btnStartGrouping_Click);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.btnParentInValid);
			this.panel2.Controls.Add(this.btnParentValid);
			this.panel2.Location = new System.Drawing.Point(375, 200);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(320, 20);
			this.panel2.TabIndex = 9;
			// 
			// btnParentInValid
			// 
			this.btnParentInValid.BackColor = System.Drawing.Color.LightPink;
			this.btnParentInValid.Enabled = false;
			this.btnParentInValid.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
			this.btnParentInValid.Location = new System.Drawing.Point(175, 0);
			this.btnParentInValid.Name = "btnParentInValid";
			this.btnParentInValid.Size = new System.Drawing.Size(145, 20);
			this.btnParentInValid.TabIndex = 8;
			this.btnParentInValid.Text = "Invalid ";
			this.btnParentInValid.Click += new System.EventHandler(this.btnParentInValid_Click);
			// 
			// btnParentValid
			// 
			this.btnParentValid.BackColor = System.Drawing.Color.LightSteelBlue;
			this.btnParentValid.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
			this.btnParentValid.Location = new System.Drawing.Point(0, 0);
			this.btnParentValid.Name = "btnParentValid";
			this.btnParentValid.Size = new System.Drawing.Size(145, 20);
			this.btnParentValid.TabIndex = 7;
			this.btnParentValid.Text = "Valid ";
			this.btnParentValid.Click += new System.EventHandler(this.btnParentValid_Click);
			// 
			// btnSetBatch
			// 
			this.btnSetBatch.Enabled = false;
			this.btnSetBatch.Image = ((System.Drawing.Image)(resources.GetObject("btnSetBatch.Image")));
			this.btnSetBatch.Location = new System.Drawing.Point(10, 195);
			this.btnSetBatch.Name = "btnSetBatch";
			this.btnSetBatch.Size = new System.Drawing.Size(25, 25);
			this.btnSetBatch.TabIndex = 10;
			this.btnSetBatch.Click += new System.EventHandler(this.btnSetBatch_Click);
			// 
			// btnSetItem
			// 
			this.btnSetItem.Enabled = false;
			this.btnSetItem.Image = ((System.Drawing.Image)(resources.GetObject("btnSetItem.Image")));
			this.btnSetItem.Location = new System.Drawing.Point(40, 195);
			this.btnSetItem.Name = "btnSetItem";
			this.btnSetItem.Size = new System.Drawing.Size(25, 25);
			this.btnSetItem.TabIndex = 13;
			this.btnSetItem.Click += new System.EventHandler(this.btnSetItem_Click);
			// 
			// sbStatus
			// 
			this.sbStatus.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
			this.sbStatus.Location = new System.Drawing.Point(0, 501);
			this.sbStatus.Name = "sbStatus";
			this.sbStatus.Size = new System.Drawing.Size(712, 15);
			this.sbStatus.TabIndex = 19;
			// 
			// btnUpdate
			// 
			this.btnUpdate.Enabled = false;
			this.btnUpdate.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
			this.btnUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnUpdate.Location = new System.Drawing.Point(615, 480);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(90, 23);
			this.btnUpdate.TabIndex = 22;
			this.btnUpdate.Text = "Update";
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// btnClear
			// 
			this.btnClear.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
			this.btnClear.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnClear.Location = new System.Drawing.Point(520, 480);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(90, 23);
			this.btnClear.TabIndex = 23;
			this.btnClear.Text = "Clear";
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// tbBarCode
			// 
			this.tbBarCode.Location = new System.Drawing.Point(10, 0);
			this.tbBarCode.Name = "tbBarCode";
			this.tbBarCode.Size = new System.Drawing.Size(370, 20);
			this.tbBarCode.TabIndex = 0;
			this.tbBarCode.CodeEntered += new System.EventHandler(this.tbBarCode_CodeEntered);
			// 
			// ReItemiznForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
			this.ClientSize = new System.Drawing.Size(712, 516);
			this.Controls.Add(this.tbBarCode);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.btnUpdate);
			this.Controls.Add(this.sbStatus);
			this.Controls.Add(this.btnSetItem);
			this.Controls.Add(this.btnSetBatch);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.pNewVersion);
			this.Controls.Add(this.otParent);
			this.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "ReItemiznForm";
			this.Text = "ReItemzn";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.pNewVersion.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new ReItemiznForm(1));
		}

		private void tbBarCode_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			tbBarCode.SelectAll();
		}

		private void tbBarCode_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			tbBarCode.SelectAll();
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			tbBarCode.SelectAll();
		}

		private void tbBarCode_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				try
				{			
					//Initialize Components
					string[] sCodesArray = tbBarCode.Text.Split('.');
					DataSet dsOrders =  Service.GetOrderTreeDataByGroupCode(sCodesArray[0], false);
					
					
					otParent.Initialize(dsOrders);					
				}
				catch(Exception exc)
				{
					MessageBox.Show(exc.Message);
				}
				
				tbBarCode.SelectAll();
			}
		}

		private void btnStartGrouping_Click(object sender, System.EventArgs e)
		{
			DataSet dsNewVersion = otParent.dsOrderTree.Clone();
			//string Batch = Cntrls.OrdersTree.TableList.Batch;
			//dsNewVersion.Tables[Batch];

			Object[] osetOrder = otParent.dsOrderTree.Tables["tblOrder"].Rows[0].ItemArray;
			dsNewVersion.Tables["tblOrder"].Rows.Add(osetOrder);
			DataTable dtStates = otParent.dtSatets.Copy();

			dsNewVersion.Tables.Add(dtStates);

			otNewVersion.Initialize(dsNewVersion);
			ActivateNewVersion(true);

		}

		public void ActivateNewVersion(bool b)
		{
			pNewVersion.Enabled = b;
			btnSetBatch.Enabled = b;
			btnDelete.Enabled = b;
			btnUpdate.Enabled = b;
			
			btnParentInValid.Enabled = !b;
			btnParentValid.Enabled = !b;
		}

	
		private void otNewVersion_SelectedItemChanged(object sender, System.EventArgs e)
		{
			if (otNewVersion.Selected.tblName == Cntrls.OrdersTree.TableList.Order[1])
			{
				btnSetItem.Enabled = false;
			}
			else
			{
				btnSetItem.Enabled = true;
			}		
		}

		private void btnSetBatch_Click(object sender, System.EventArgs e)
		{
			try
			{
				otNewVersion.InsertBatch(otParent.Get().Copy());
				AfterBreak();
			}
			catch (Exception Exc){MessageBox.Show(Exc.Message);}
		}

		private void btnSetItem_Click(object sender, System.EventArgs e)
		{
			try
			{
				DataSet dsInserted = otParent.Get().Copy();
				DataRow drBatch = otNewVersion.SelectedBatch.drNode;

				DataRow[] drExistItem = drBatch.GetChildRows("Batch_Item");

				int iResultItemCount = drExistItem.Length + dsInserted.Tables["tblItem"].Rows.Count;
				if (iResultItemCount > 25)
				{
					throw new Exception("Result Number of Item in Batch greater then 25!");
				}
				foreach(DataRow drItem in dsInserted.Tables["tblItem"].Rows)
				{
					if (drBatch["ItemTypeID"].ToString() != drItem["ItemTypeID"].ToString())
					{
						throw new Exception("Item Type mismatch!");
					}
				}

				otNewVersion.InsertItem(dsInserted, drBatch);
				AfterBreak();
				otNewVersion.ReformItemName();
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message);
			}
			btnSetItem.Enabled = false;
		}

		private void AfterBreak()
		{
			otParent.HideCheckedRow();
			if (otNewVersion.IsInitialize)
			{
				tbItemsInspected.Text = otNewVersion.dsOrderTree.Tables["tblItem"].Rows.Count.ToString();
				otNewVersion.ReformItemName();
			}
			else
			{
				tbItemsInspected.Text = "";
			}
		}
		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			otParent.UnHideRow(otNewVersion.Get());
			otNewVersion.DeleteChecked();
			btnSetItem.Enabled = false;
			AfterBreak();
			if (!otNewVersion.IsInitialize)
			{					
				ActivateNewVersion(false);
			}
		}

		private void btnParentInValid_Click(object sender, System.EventArgs e)
		{
			otParent.ChangeTypeChecked("3");
			// set changes to db
			Service.UpdateOrderTreeState(otParent.GetChecked());
		}

		private void btnParentValid_Click(object sender, System.EventArgs e)
		{
			otParent.ChangeTypeChecked("2");
			// set changes to db
			Service.UpdateOrderTreeState(otParent.GetChecked());
		}

		private void btnNewVersionInValid_Click(object sender, System.EventArgs e)
		{
			otNewVersion.ChangeTypeChecked("3");
		}

		private void btnNewVersionValid_Click(object sender, System.EventArgs e)
		{
			otNewVersion.ChangeTypeChecked("2");		
		}

		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			//Check for Inspected total weight 

			try
			{
				Service.CreateGroupVersion(otParent.dsOrderTree.Tables["tblOrder"].Rows[0]["ID"].ToString(),
					weightControl.Weight,
					weightControl.MeasureUnitID);				
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message);
				return;
			}

			try
			{
				if (weightControl.Weight != "")
				{
					bool IsOk = true;
					decimal dRealTotalWeigth = 0;

					foreach(DataRow drItem in otNewVersion.dsOrderTree.Tables["tblItem"].Rows)
					{
						if ((weightControl.MeasureUnitID != drItem["WeightUnitID"].ToString())
							|| (Convert.ToDecimal(drItem["Weight"].ToString()) == 0 ))							
						{throw new Exception();}

						dRealTotalWeigth += Convert.ToDecimal(drItem["Weight"].ToString());
					}

					decimal dFluctuation = Math.Abs(dRealTotalWeigth - Convert.ToDecimal(weightControl.Weight));
					if ( dFluctuation > (decimal)0.02)
					{
						MessageBox.Show("Fluctuation between Real Total Weight (" + dRealTotalWeigth +") and Inspected Total Weight (" + weightControl.Weight + ") greater then 0.02");
					}
				}
			}
			catch (Exception exc)
			{	
				sbStatus.Text = exc.Message;
			}
			


			//Set new Batch / Compare new and old datasets -> set BatchID to DBNULL if batch is new.
			
			DataTable dtOldBatch = otParent.dsOrderTree.Tables["tblBatch"];
			DataTable dtOldItem = otParent.dsOrderTree.Tables["tblItem"];
						
			DataTable dtBatch = otNewVersion.dsOrderTree.Tables["tblBatch"];
			DataTable dtItem = otNewVersion.dsOrderTree.Tables["tblItem"];
			

			foreach(DataRow drNewBatch in dtBatch.Rows)
			{
				string SysCode = drNewBatch["SysCode"].ToString();
				DataRow[] drNewItems = drNewBatch.GetChildRows("Batch_Item");

				DataRow drOldBatch = dtOldBatch.Select("SysCode = " +SysCode)[0];
				DataRow[] drOldItems = drOldBatch.GetChildRows("Batch_Item");

				//Check Batch	
				bool IsNewBatch = false;
															
				int i = 0;
				int iBatchState = 0;
				foreach(DataRow drNewItem in drNewItems)
				{
					i++;
					iBatchState = 1;
					foreach(DataRow drOldItem in drOldItems)
					{
						if (drNewItem["SysCode"].ToString() == drOldItem["SysCode"].ToString())
						{
							iBatchState = 2;
							break;
						}
					}
					if (iBatchState == 1)
					{
						IsNewBatch = true;
					}

					drNewItem["Code"] = i;
					drNewItem["BatchCode"] = drNewBatch["Code"];
				}					
				
				if ((drNewBatch["Code"].ToString() != drOldBatch["Code"].ToString())
					|| (drNewItems.Length != drOldItems.Length))
				{
					IsNewBatch = true;
				}

				if (IsNewBatch)
				{
					drNewBatch["BatchID"] = System.DBNull.Value;
					foreach(DataRow drNewItem in drNewItems)
					{
						drNewItem["BatchID"] = System.DBNull.Value;
					}
				}
			}			

			DataSet dsNew = new DataSet();
			dsNew.Tables.Add(dtBatch.Copy());
			dsNew.Tables.Add(dtItem.Copy());
			//Service.debug_DiaspalyDataSet(dsNew);
			try
			{
				DataSet dsOutput = Service.SetReitemizedOrderTreeData(dsNew);

				//Print Report
				for(;;)
				{
					Print1(dsOutput);

					if(MessageBox.Show("Would you like to print again?", 
						"Printing completed", MessageBoxButtons.YesNo, 
						MessageBoxIcon.Question) == DialogResult.Yes)
					{
						continue;
					}
					else
						break;
				}

				sbStatus.Text = "Data successfully added";
			}
			catch (Exception exc)
			{				
				sbStatus.Text = "Error:" + exc.Message;
			}
			otParent.Clear();
			otNewVersion.Clear();
		}

		private void Print1(DataSet dsOutput)
		{
			string sCRTemplatePath = Client.GetOfficeDirPath("repDir");

			foreach(DataRow row in dsOutput.Tables[0].Rows)
			{
				string BATCHID = row[0].ToString();
				if (BATCHID == "") continue;
				
				CrystalReport.CrystalReport crReport_Batch = new CrystalReport.CrystalReport(sCRTemplatePath);
				crReport_Batch.Label_Batch(BATCHID);
				crReport_Batch.Print();

				CrystalReport.CrystalReport crInternal_Receipt_Report=new CrystalReport.CrystalReport(sCRTemplatePath);
				crInternal_Receipt_Report.Internal_Receipt(BATCHID);
				crInternal_Receipt_Report.Print();
				///////////
				//	CrystalReport.CrystalReport crCustomer_Program=new CrystalReport.CrystalReport(sCRTemplatePath);
				//	crCustomer_Program.Customer_Program(BATCHID);
				//	crCustomer_Program.Print();
			}


			foreach(DataRow row in dsOutput.Tables[1].Rows)
			{
				string ITEMID = row[0].ToString();
				if (ITEMID == "") continue;

				CrystalReport.CrystalReport crReport_Label= new CrystalReport.CrystalReport(sCRTemplatePath);
				crReport_Label.Label_Item(ITEMID);
				crReport_Label.Print();
			}
		}

		private void btnClear_Click(object sender, System.EventArgs e)
		{
			otNewVersion.Clear();
			otParent.Clear();

			ActivateNewVersion(false);
			btnStartGrouping.Enabled = false;
			btnParentInValid.Enabled = false;
			btnParentValid.Enabled = false;
		}

		private void tbBarCode_CodeEntered(object sender, System.EventArgs e)
		{
			
				try
				{			
					//Initialize Components
					string[] sCodesArray = tbBarCode.Text.Split('.');
					DataSet dsOrders =  Service.GetOrderTreeDataByGroupCode(sCodesArray[0],false);
					if(dsOrders.Tables["tblOrder"] != null && dsOrders.Tables["tblOrder"].Rows.Count > 0)
						Service.SetDepartmentOfficeId(dsOrders.Tables["tblOrder"].Rows[0]["CustomerOfficeID"].ToString());
					
					otParent.Initialize(dsOrders);					
					ActivateNewVersion(false);
					btnStartGrouping.Enabled = true;
				}
				catch(Exception exc)
				{
					MessageBox.Show(exc.Message);
				}
				tbBarCode.SelectAll();
			
		}
	}
}
