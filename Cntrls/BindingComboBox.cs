using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Cntrls
{
	/// <summary>
	/// We set all windowscontrols to public for full component control.
	/// </summary>
	public class BindingComboBox : System.Windows.Forms.UserControl
	{	
		private bool IsEventForbidden = false;
		public System.Windows.Forms.ComboBox cbField;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		#region Generated
		private System.ComponentModel.Container components = null;

		public BindingComboBox()
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
			this.cbField = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// cbField
			// 
			this.cbField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbField.Location = new System.Drawing.Point(0, 0);
			this.cbField.Name = "cbField";
			this.cbField.Size = new System.Drawing.Size(136, 21);
			this.cbField.TabIndex = 0;
			this.cbField.SelectedIndexChanged += new System.EventHandler(this.cbField_SelectedIndexChanged);
			// 
			// BindingComboBox
			// 
			this.Controls.Add(this.cbField);
			this.Name = "BindingComboBox";
			this.Size = new System.Drawing.Size(136, 21);
			this.Resize += new System.EventHandler(this.BindingComboBox_Resize);
			this.ResumeLayout(false);

		}
		#endregion
		#endregion Generated

		#region Design-time
		#region properties

		public bool IsInitialize
		{
			get 
			{
				return (cbField.DataSource != null);
			}
		}
		private string sFilteredID = "";
		[Browsable(false)]
		public string Filter
		{
			set
			{
				if (IsInitialize)
				{
					sFilteredID = value;
					if(InsertDefaultRow)
					{
						((DataView)cbField.DataSource).RowFilter = "CustomerID = " + value + " or CustomerID = 0";
					}
					else
					{
						((DataView)cbField.DataSource).RowFilter = "CustomerID = " + value;
					}
				}
			}
			get
			{
				return sFilteredID;
			}
		}		
		[
		Browsable(true),
		Category("ControlProperty"),
		Description("Specifies the text.")
		]
		public override string Text
		{
			get
			{
				return this.cbField.Text;
			}
			set
			{
				this.cbField.Text = value;
			}
		}


		private string sDisplayMember = "CustomerName";
		[		
		Category("ControlProperty"),
		Description("Specifies the text.")
		]
		public string DisplayMember
		{
			get
			{
				return sDisplayMember;
			}
			set
			{
				sDisplayMember = value;
			}
		}
	
		private string sValueMember = "CustomerID";
		[
		Category("ControlProperty"),
		Description("Specifies the text.")
		]
		public string ValueMember
		{
			get 
			{
				return sValueMember;
			}
			set 
			{
				sValueMember = value ;				
			}
		}

		private string sCodeMember = "CustomerCode";
		[
		Category("ControlProperty"),
		Description("Specifies the text.")
		]
		public string CodeMember
		{
			get 
			{
				return sCodeMember;
			}
			set
			{
				sCodeMember = value;
			}
		}

		private bool bInsertDefaultRow = false;
		[
		Category("ControlProperty"),
		Description("Specifies the text."),
		DefaultValue(false)
		]
		public bool InsertDefaultRow
		{
			get 
			{
				return bInsertDefaultRow;
			}
			set
			{
				bInsertDefaultRow = value;
				if ((value) && (DefaultText=="")) DefaultText = "Customer Lookup";
			}
		}

		private string sDefaultText = "Customer Lookup";
		[
		Category("ControlProperty"),
		Description("available only if InsertDefaultRow property is set to true."),		
		]
		public string DefaultText
		{
			get
			{
				return sDefaultText;
			}
			set
			{
				sDefaultText = value;
			}
		}
	
		public DataRowView drvSelectedItem
		{
			get 
			{
				return (DataRowView) this.cbField.SelectedItem;
			}
			set
			{
				this.cbField.SelectedItem = value;
			}

		}


		#endregion properties

		[
		Browsable(true),
		Category("ControlProperty"),
		Description("Occurs whenever 'SelectedIndex' property for cbFieldt has changed")
		]
		public event System.EventHandler SelectedIndexChanged;
		

		public void BindingComboBox_Resize(object sender, System.EventArgs e)
		{
			cbField.Size = new Size(this.Size.Width, cbField.Size.Height);		
		}
		#endregion Design-time

		#region Run-time
		public void Initialize(DataTable dtData)
		{			
			IsEventForbidden = true;
			if (InsertDefaultRow)
			{
				DataRow drData = dtData.NewRow();
				drData[DisplayMember]= DefaultText;
				drData[ValueMember] = 0;
				if (sCodeMember != "")
				{
					drData[sCodeMember] = "0000";
				}
				dtData.Rows.InsertAt(drData,0);
			}

			DataView dvData = new DataView(dtData);
			//dvData.Sort = ValueMember + " ASC";
		
			cbField.BeginUpdate();
			cbField.DataSource = dvData;
			cbField.DisplayMember = DisplayMember;
			cbField.ValueMember = ValueMember;
			cbField.EndUpdate();
			
			IsEventForbidden = false;
		}
		public void Clear()
		{
			if (IsInitialize)
			{
				cbField.SelectedIndex = 0;
			}
		}

		#endregion Run-time

		protected virtual void cbField_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (!IsEventForbidden)
			{
				if(SelectedIndexChanged != null)
					SelectedIndexChanged(this, e);
			}
		}
	}
}
