using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Cntrls
{
	/// <summary>
	/// Summary description for IntField.
	/// </summary>
	public class IntField : System.Windows.Forms.UserControl
	{
		
		private bool nonNumberEntered;
		#region Generated
		internal System.Windows.Forms.TextBox tbNumOfItem;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public IntField()
		{
			// This call is required by the Windows.Forms Form Designer.
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
			this.tbNumOfItem = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// tbNumOfItem
			// 
			this.tbNumOfItem.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
			this.tbNumOfItem.Location = new System.Drawing.Point(0, 0);
			this.tbNumOfItem.Name = "tbNumOfItem";
			this.tbNumOfItem.Size = new System.Drawing.Size(160, 20);
			this.tbNumOfItem.TabIndex = 2;
			this.tbNumOfItem.Text = "";
			this.tbNumOfItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbNumOfItem_KeyDown);
			this.tbNumOfItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNumOfItem_KeyPress);
			// 
			// IntField
			// 
			this.Controls.Add(this.tbNumOfItem);
			this.Name = "IntField";
			this.Size = new System.Drawing.Size(160, 20);
			this.Resize += new System.EventHandler(this.IntField_Resize);
			this.ResumeLayout(false);

		}
		#endregion

		#endregion Generated
		private bool bIsRequered = true;
		public bool IsRequered
		{
			get 
			{
				return bIsRequered;
			}
			set
			{
				bIsRequered = value;
			}
		}


		private void tbNumOfItem_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			// Initialize the flag to false.
			nonNumberEntered = false;
			// Determine whether the keystroke is a number or backspace or dot.
			if ((e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9) && 
				(e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9) && 
				(e.KeyCode != Keys.Back))
			{	
				nonNumberEntered = true;
			}		
		}

		private void tbNumOfItem_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = nonNumberEntered;
		}

		private void IntField_Resize(object sender, System.EventArgs e)
		{
			tbNumOfItem.Size = new Size(this.Size.Width, this.Size.Height);
		}
		public string Get()
		{
			if ((IsRequered) && (tbNumOfItem.Text.Length < 1))
			{
				tbNumOfItem.Focus();
				throw new Exception("Field can't be empty");
			}
			return tbNumOfItem.Text;
		}
		public void Select()
		{
			tbNumOfItem.Select();
		}
		public void Clear()
		{
			tbNumOfItem.Text = "";
		}
	}
}
