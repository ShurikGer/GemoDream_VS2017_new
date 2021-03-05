using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Globalization;

namespace Cntrls
{
	/// <summary>
	/// Summary description for PriceRange.
	/// </summary>
	public class PriceRange : System.Windows.Forms.UserControl
	{
		private DataView dvPart_value;
		private DataTable dtPart_Measure = new DataTable("Part_Value");
				
        //private int index;
		private DataSet dsFormats;
		private string homogeneity = "";
		public string Homogeneity 
		{
			get{return homogeneity;}
			set{homogeneity = value;}
		}
		private DataSet ds;
		private System.Windows.Forms.GroupBox gbpPrice_1;
		private System.Windows.Forms.Button bdpDeleteLine_1;
		private System.Windows.Forms.Button bdpAddLine_1;
		private System.Windows.Forms.Button bdpDelete_1;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.DataGrid dataGrid;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PriceRange()
		{
			InitializeComponent();
			InitTitlesValues();

			dtPart_Measure.Columns.Add("PartNameMeasureName");
			dtPart_Measure.Columns.Add("MeasureCode");
			dtPart_Measure.Columns.Add("PartID");
			dsFormats = gemoDream.Service.GetMeasuresFormats();	
		}

		public PriceRange(int N)
		{
			InitializeComponent();
			this.gbpPrice_1.Text = "Price " + N.ToString();
			InitTitlesValues();

			dtPart_Measure.Columns.Add("PartNameMeasureName");
			dtPart_Measure.Columns.Add("MeasureCode");
			dtPart_Measure.Columns.Add("PartID");
			dsFormats = gemoDream.Service.GetMeasuresFormats();	
		}
		private void InitTitlesValues()
		{
			this.ds = new DataSet();
			ds.Tables.Add("PriceRange");
			ds.Tables[0].Columns.Add("From", System.Type.GetType("System.String"));
			ds.Tables[0].Columns.Add("To", System.Type.GetType("System.String"));
			ds.Tables[0].Columns.Add("Price", System.Type.GetType("System.String"));

			this.dataGrid.DataSource = ds;
			ds.Tables[0].DefaultView.AllowNew = false;
			this.InitTitlesValuesDataGrid(ds);
			this.dataGrid.SetDataBinding(ds.Tables[0].DefaultView, "");
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
			this.gbpPrice_1 = new System.Windows.Forms.GroupBox();
			this.dataGrid = new System.Windows.Forms.DataGrid();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.bdpDeleteLine_1 = new System.Windows.Forms.Button();
			this.bdpAddLine_1 = new System.Windows.Forms.Button();
			this.bdpDelete_1 = new System.Windows.Forms.Button();
			this.gbpPrice_1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// gbpPrice_1
			// 
			this.gbpPrice_1.Controls.Add(this.dataGrid);
			this.gbpPrice_1.Controls.Add(this.listBox1);
			this.gbpPrice_1.Controls.Add(this.bdpDeleteLine_1);
			this.gbpPrice_1.Controls.Add(this.bdpAddLine_1);
			this.gbpPrice_1.Controls.Add(this.bdpDelete_1);
			this.gbpPrice_1.Location = new System.Drawing.Point(0, 0);
			this.gbpPrice_1.Name = "gbpPrice_1";
			this.gbpPrice_1.Size = new System.Drawing.Size(560, 280);
			this.gbpPrice_1.TabIndex = 3;
			this.gbpPrice_1.TabStop = false;
			this.gbpPrice_1.Text = "Price 1";
			// 
			// dataGrid
			// 
			this.dataGrid.CaptionVisible = false;
			this.dataGrid.DataMember = "";
			this.dataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid.Location = new System.Drawing.Point(232, 32);
			this.dataGrid.Name = "dataGrid";
			this.dataGrid.Size = new System.Drawing.Size(240, 232);
			this.dataGrid.TabIndex = 8;
			// 
			// listBox1
			// 
			this.listBox1.ItemHeight = 12;
			this.listBox1.Location = new System.Drawing.Point(8, 32);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(216, 232);
			this.listBox1.TabIndex = 7;
			this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
			// 
			// bdpDeleteLine_1
			// 
			this.bdpDeleteLine_1.BackColor = System.Drawing.Color.LightPink;
			this.bdpDeleteLine_1.Location = new System.Drawing.Point(480, 56);
			this.bdpDeleteLine_1.Name = "bdpDeleteLine_1";
			this.bdpDeleteLine_1.Size = new System.Drawing.Size(72, 20);
			this.bdpDeleteLine_1.TabIndex = 6;
			this.bdpDeleteLine_1.Text = "Delete Line";
			this.bdpDeleteLine_1.Click += new System.EventHandler(this.bdpDeleteLine_1_Click);
			// 
			// bdpAddLine_1
			// 
			this.bdpAddLine_1.BackColor = System.Drawing.Color.LightSteelBlue;
			this.bdpAddLine_1.Location = new System.Drawing.Point(480, 32);
			this.bdpAddLine_1.Name = "bdpAddLine_1";
			this.bdpAddLine_1.Size = new System.Drawing.Size(72, 20);
			this.bdpAddLine_1.TabIndex = 5;
			this.bdpAddLine_1.Text = "Add Line";
			this.bdpAddLine_1.Click += new System.EventHandler(this.bdpAddLine_1_Click);
			// 
			// bdpDelete_1
			// 
			this.bdpDelete_1.BackColor = System.Drawing.Color.LightPink;
			this.bdpDelete_1.Location = new System.Drawing.Point(208, 8);
			this.bdpDelete_1.Name = "bdpDelete_1";
			this.bdpDelete_1.Size = new System.Drawing.Size(72, 20);
			this.bdpDelete_1.TabIndex = 0;
			this.bdpDelete_1.Text = "Delete";
			this.bdpDelete_1.Click += new System.EventHandler(this.bdpDelete_1_Click);
			// 
			// PriceRange
			// 
			this.Controls.Add(this.gbpPrice_1);
			this.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
			this.Name = "PriceRange";
			this.Size = new System.Drawing.Size(568, 288);
			this.gbpPrice_1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void bdpAddLine_1_Click(object sender, System.EventArgs e)
		{
			DataRow newRow = this.ds.Tables[0].NewRow();
			newRow["From"] = DBNull.Value;
			newRow["To"] = DBNull.Value;
			newRow["Price"] = DBNull.Value;
			this.ds.Tables[0].Rows.Add(newRow);
			int iCurrentRow = this.ds.Tables[0].Rows.Count - 1;

			if(ds.Tables[0].Rows.Count > 1 )
			{
				if(ds.Tables[0].Rows[(ds.Tables[0].Rows.Count) - 2]["From"] != DBNull.Value
					&& ds.Tables[0].Rows[(ds.Tables[0].Rows.Count) - 2]["To"] != DBNull.Value
					&& ds.Tables[0].Rows[(ds.Tables[0].Rows.Count) - 2]["Price"] != DBNull.Value)
				{
					double From = System.Convert.ToDouble(ds.Tables[0].Rows[(ds.Tables[0].Rows.Count) - 2]["To"]) + 0.01;
					ds.Tables[0].Rows[(ds.Tables[0].Rows.Count) - 1]["From"] = From;
					this.dataGrid.CurrentRowIndex = iCurrentRow;
				}
				else
				{
					ds.Tables[0].Rows.Remove(newRow);
					MessageBox.Show(this, "Please, fill previous range first", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
		}
		
		private void bdpDeleteLine_1_Click(object sender, System.EventArgs e)
		{
			int iCurrent = this.dataGrid.CurrentRowIndex;
			if (iCurrent != -1)
			{
				DataRow row = this.ds.Tables[0].Rows[iCurrent];
				this.ds.Tables[0].Rows.Remove(row);
			}
		}

		private void InitTitlesValuesDataGrid(DataSet dsValues)
		{
			string[] columnNames = new string[] 
				{
					"From", "To", "Price"
				};
			string[] headerText = new string[]
				{
					"From", "To", "Price"
				};
			int[] columnWidth = new int[]
				{
					50, 50, 84
				};

			DataGridTableStyle tableStyle = new DataGridTableStyle();
			tableStyle.MappingName = dsValues.Tables[0].TableName;
			
			for (int i = 0; i < columnNames.Length; i++)
			{
				DataGridTextBoxColumn tbColumn = new DataGridTextBoxColumn();				

				tbColumn.MappingName = columnNames[i];
				tbColumn.HeaderText = headerText[i];
				tbColumn.Width = columnWidth[i];

				tableStyle.GridColumnStyles.Add(tbColumn);						
			}

			this.dataGrid.TableStyles.Clear();
			this.dataGrid.TableStyles.Add(tableStyle);
		}
		public void AddMeasures(string sPart_Measure, string sMeasureCode, string sPartID)
		{
			if(listBox1.FindString(sPart_Measure) == -1)
			{
				DataRow drPart_Measure = dtPart_Measure.NewRow();

				drPart_Measure["PartNameMeasureName"] = sPart_Measure;
				drPart_Measure["MeasureCode"] = sMeasureCode;
				drPart_Measure["PartID"] = sPartID;
				
				dtPart_Measure.Rows.Add(drPart_Measure);

				dvPart_value = new DataView(dtPart_Measure);
				dvPart_value.RowFilter = "1=1";
				
				listBox1.DataSource = dvPart_value;
				listBox1.DisplayMember = "PartNameMeasureName";
			}
			else
			{
				MessageBox.Show(this, sPart_Measure + " already exist", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void bdpDelete_1_Click(object sender, System.EventArgs e)
		{
			Dispose(true);
		}
		public DataRowCollection GetPriceRange()
		{
			return ds.Tables[0].Rows;
		}
		public DataRowCollection getPartsMeasures()
		{
			return dtPart_Measure.Rows;
		}

		private void listBox1_DoubleClick(object sender, System.EventArgs e)
		{
			if(dtPart_Measure.Rows.Count > 0)
			{
				DataRowView row = (DataRowView)listBox1.SelectedItem;
			
				dtPart_Measure.Rows.Remove(row.Row);

				dvPart_value = new DataView(dtPart_Measure);
				dvPart_value.RowFilter = "1=1";
				
				listBox1.DataSource = dvPart_value;
				listBox1.DisplayMember = "PartNameMeasureName";
			}
		}
		public void ReInitRange(DataSet dsValues)
		{
			dsValues.Tables[0].DefaultView.AllowNew = false;
			this.dataGrid.DataSource = dsValues;
			this.InitTitlesValuesDataGrid(dsValues);
			this.dataGrid.SetDataBinding(dsValues.Tables[0].DefaultView, "");
			this.ds = dsValues;
		}
		private string FormatMeasure(string measureCode, string measureValue)
		{
			CultureInfo myCIintl = new CultureInfo( "en-US", false );
			NumberFormatInfo numberInfo = myCIintl.NumberFormat;

			String currentMeasureFormat = "";
			DataRow[] adrFormats = dsFormats.Tables["Format"].Select("MeasureCode = '" + measureCode + "'");
			if (adrFormats.Length == 1)
			{
				currentMeasureFormat = adrFormats[0]["FormatString"].ToString();
			}

			Double temp;
			try { temp = Convert.ToDouble(measureValue, numberInfo); }
			catch {return measureValue.ToString();}
			return temp.ToString(currentMeasureFormat);
		}
		public void newTitel(int N)
		{
			this.gbpPrice_1.Text = "Price " + N.ToString();
		}
	}
}
