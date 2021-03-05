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
	/// Summary description for UserControl1.
	/// </summary>
	public class WeightControl : System.Windows.Forms.UserControl
	{
		private bool nonNumberEntered;
		private DataView dvMeasureUnit;
		#region Generated
		internal System.Windows.Forms.ComboBox cbMeasureUnit;
		internal System.Windows.Forms.TextBox tbTotalWeight;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		
		public WeightControl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
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
			this.cbMeasureUnit = new System.Windows.Forms.ComboBox();
			this.tbTotalWeight = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// cbMeasureUnit
			// 
			this.cbMeasureUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbMeasureUnit.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
			this.cbMeasureUnit.Location = new System.Drawing.Point(104, 0);
			this.cbMeasureUnit.Name = "cbMeasureUnit";
			this.cbMeasureUnit.Size = new System.Drawing.Size(60, 20);
			this.cbMeasureUnit.TabIndex = 7;
			// 
			// tbTotalWeight
			// 
			this.tbTotalWeight.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
			this.tbTotalWeight.Location = new System.Drawing.Point(0, 0);
			this.tbTotalWeight.Name = "tbTotalWeight";
			this.tbTotalWeight.TabIndex = 6;
			this.tbTotalWeight.Text = "";
			this.tbTotalWeight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbTotalWeight_KeyDown);
			this.tbTotalWeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbTotalWeight_KeyPress);
			// 
			// WeightControl
			// 
			this.Controls.Add(this.cbMeasureUnit);
			this.Controls.Add(this.tbTotalWeight);
			this.Name = "WeightControl";
			this.Size = new System.Drawing.Size(164, 20);
			this.Resize += new System.EventHandler(this.WeightControl_Resize);
			this.ResumeLayout(false);

		}
		#endregion

		#endregion Generated

		#region Design-time
		private bool bIsMeasureUnit = true;
		private string sDecimalSymbol;
		public bool IsMeasureUnit
		{
			get
			{
				return bIsMeasureUnit;
			}
			set
			{
				bIsMeasureUnit = value;
				if (bIsMeasureUnit)
				{
					cbMeasureUnit.Enabled = true;
					cbMeasureUnit.Visible = true;
				}
				else
				{
					cbMeasureUnit.Enabled = false;
					cbMeasureUnit.Visible = false;
				}
				WeightControl_Resize(null, null);				
			}
		}
		private bool bIsRequired = true;
		public bool IsRequired
		{
			set 
			{
				bIsRequired = value;
			}
			get
			{
				return bIsRequired;
			}
		}

		[ Browsable(false)]
		public string Weight
		{
			set
			{
				tbTotalWeight.Text = value;
			}
			get 
			{
				if (!bIsRequired && tbTotalWeight.Text=="")
				{
					return "";
				}

				tbTotalWeight.Text =  Convert.ToDouble(tbTotalWeight.Text.ToString()).ToString("####0.00;");
				int iPointPos = tbTotalWeight.Text.IndexOf(sDecimalSymbol);
				
				int i = tbTotalWeight.Text.Length - iPointPos - 1;
				bool hasOnePeriod = (iPointPos != -1) && (tbTotalWeight.Text.LastIndexOf(sDecimalSymbol) == iPointPos);
				if (hasOnePeriod)
				{
					if (Convert.ToInt32(dvMeasureUnit[cbMeasureUnit.SelectedIndex]["MeasureUnitCode"])== 1)
					{
						if (i==2 && hasOnePeriod)
						{
							return tbTotalWeight.Text;
						}
						else 
						{
							tbTotalWeight.Focus();
							tbTotalWeight.SelectAll();
							throw new Exception("Weight value must be within 0.01");
						}
					}
					else
					{
						if (i==2 && hasOnePeriod)
						{
							return tbTotalWeight.Text;
						}
						else 
						{
							tbTotalWeight.Focus();
							tbTotalWeight.SelectAll();
							throw new Exception("Weight value must be within 0.01");
						}
					}
				}
				else return "";
			}
		}
		[ Browsable(false)]
		public string MeasureUnitID
		{
			get
			{
				return dvMeasureUnit[cbMeasureUnit.SelectedIndex]["MeasureUnitID"].ToString();
			}
			set
			{
				try 
				{
					cbMeasureUnit.SelectedValue = value;
					iMeasureUnitIndex = cbMeasureUnit.SelectedIndex;
				}
				catch{};				
			}
		}
		private int iMeasureUnitIndex = 0;
		[ Browsable(false)]
		public string MeasureUnitCode
		{
			get
			{
				return dvMeasureUnit[cbMeasureUnit.SelectedIndex]["MeasureUnitCode"].ToString();
			}
			set
			{
				if (value != "")
				{
					foreach(DataRowView drvDataIterator in dvMeasureUnit)
					{
						if (drvDataIterator["MeasureUnitCode"].ToString() == value)
						{
							cbMeasureUnit.SelectedItem = drvDataIterator;
							iMeasureUnitIndex = cbMeasureUnit.SelectedIndex;
							break;
						}
					}
				}
			}
		}
		[ Browsable(false)]
		public string MeasureUnitName
		{
			get
			{
				return dvMeasureUnit[cbMeasureUnit.SelectedIndex]["MeasureUnitName"].ToString();
			}
		}

		private void WeightControl_Resize(object sender, System.EventArgs e)
		{
			if (IsMeasureUnit)
			{
				tbTotalWeight.Size = new Size(this.Size.Width - 64,tbTotalWeight.Size.Height);
				cbMeasureUnit.Location = new Point(tbTotalWeight.Size.Width + 4, cbMeasureUnit.Location.Y);
			}
			else
			{
				tbTotalWeight.Size = new Size(this.Size.Width,tbTotalWeight.Size.Height);
			}
		}
		
		#endregion Design-time

		public void Initialize(DataView dvMeasureUnit)
		{
			this.dvMeasureUnit = dvMeasureUnit;
			this.dvMeasureUnit.RowFilter = "MeasureUnitCode = 2";
				  //"MeasureUnitCode = 1 OR MeasureUnitCode = 2";
				  //Disabling "g." MeasureUnit in WeightControl
				  //Reason: Main item properties was moved to ItemContainer.
				  //ItemContainer can't have customer weight in "g." while in Main item properties
				  //weight can be specified in "g". In conversation Oleg told, to remove 
				  //possibility to choose weight in "g."

			cbMeasureUnit.DataSource = this.dvMeasureUnit;
			cbMeasureUnit.DisplayMember = "MeasureUnitName";
			cbMeasureUnit.ValueMember = "MeasureUnitID";
			
			// Default Measure Unit = ct.
			MeasureUnitCode = "2";
			sDecimalSymbol=System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
		}
		public void Clear()
		{
			cbMeasureUnit.SelectedIndex = iMeasureUnitIndex;
			tbTotalWeight.Text = "";
		}

		public void Get(DataRow drWeight)
		{
			drWeight["MeasureUnitID"]= MeasureUnitID;
			drWeight["TotalWeight"] = Weight;
		}

		private void tbTotalWeight_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			// Initialize the flag to false.
			nonNumberEntered = false;
			// Determine whether the keystroke is a number or backspace or dot.
			string dotOrComma="";			
			string test = e.KeyCode.ToString();
			if(e.KeyCode.ToString() == "OemPeriod" || e.KeyCode.ToString() == "Decimal")
				dotOrComma=".";
			if(e.KeyCode.ToString() == "Oemcomma")
				dotOrComma=",";
			
			
				
			if ((e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9) && 
				(e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9) && 
				(e.KeyCode != Keys.Back) && 
				(dotOrComma != sDecimalSymbol))
			{	
				nonNumberEntered = true;
			}
		}

		private void tbTotalWeight_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = nonNumberEntered;
		}

	}
}
