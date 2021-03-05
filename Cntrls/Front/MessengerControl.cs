using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Cntrls
{
	/// <summary>
	/// Summary description for MessengerControl.
	/// </summary>
	public class MessengerControl : System.Windows.Forms.UserControl
	{
		private DataTable dtMessengers;
		#region Generated

		internal System.Windows.Forms.PictureBox PictureBox3;
		internal System.Windows.Forms.PictureBox PictureBox2;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.PictureBox PictureBox1;
		private Cntrls.BindingComboBox bcbMessenger;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MessengerControl()
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MessengerControl));
            this.PictureBox3 = new System.Windows.Forms.PictureBox();
            this.PictureBox2 = new System.Windows.Forms.PictureBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.bcbMessenger = new Cntrls.BindingComboBox();
            this.SuspendLayout();
            // 
            // PictureBox3
            // 
            this.PictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PictureBox3.BackgroundImage")));
            this.PictureBox3.Location = new System.Drawing.Point(64, 32);
            this.PictureBox3.Name = "PictureBox3";
            this.PictureBox3.Size = new System.Drawing.Size(264, 24);
            this.PictureBox3.TabIndex = 19;
            this.PictureBox3.TabStop = false;
            // 
            // PictureBox2
            // 
            this.PictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PictureBox2.BackgroundImage")));
            this.PictureBox2.Location = new System.Drawing.Point(64, 64);
            this.PictureBox2.Name = "PictureBox2";
            this.PictureBox2.Size = new System.Drawing.Size(264, 24);
            this.PictureBox2.TabIndex = 18;
            this.PictureBox2.TabStop = false;
            // 
            // Label4
            // 
            this.Label4.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.Label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label4.Location = new System.Drawing.Point(0, 64);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(56, 24);
            this.Label4.TabIndex = 17;
            this.Label4.Text = "Stored Signature";
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.Label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label3.Location = new System.Drawing.Point(0, 32);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(72, 32);
            this.Label3.TabIndex = 16;
            this.Label3.Text = "Captured Signature";
            // 
            // PictureBox1
            // 
            this.PictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.PictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PictureBox1.BackgroundImage")));
            this.PictureBox1.Location = new System.Drawing.Point(336, 8);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(120, 88);
            this.PictureBox1.TabIndex = 15;
            this.PictureBox1.TabStop = false;
            // 
            // bcbMessenger
            // 
            this.bcbMessenger.CodeMember = "";
            this.bcbMessenger.DefaultText = "Messenger Lookup";
            this.bcbMessenger.DisplayMember = "MessengerName";
            this.bcbMessenger.drvSelectedItem = null;
            this.bcbMessenger.Filter = "";
            this.bcbMessenger.InsertDefaultRow = true;
            this.bcbMessenger.Location = new System.Drawing.Point(0, 0);
            this.bcbMessenger.Name = "bcbMessenger";
            this.bcbMessenger.Size = new System.Drawing.Size(328, 20);
            this.bcbMessenger.TabIndex = 21;
            this.bcbMessenger.ValueMember = "MessengerID";
            // 
            // MessengerControl
            // 
            this.Controls.Add(this.bcbMessenger);
            this.Controls.Add(this.PictureBox3);
            this.Controls.Add(this.PictureBox2);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.PictureBox1);
            this.Name = "MessengerControl";
            this.Size = new System.Drawing.Size(472, 104);
            this.ResumeLayout(false);

        }
		#endregion
		#endregion Generated
		public void Initialize(DataTable dtData)
		{
			dtMessengers = dtData.Copy();
			bcbMessenger.Initialize(dtMessengers);
		}

		public string MessengerID
		{
			get
			{
				return bcbMessenger.cbField.SelectedValue.ToString();
			}
		}

		[Browsable(false)]
		public string Filter
		{
			set
			{
				bcbMessenger.Filter = value;				
			}
			get 
			{
				return bcbMessenger.Filter;
			}			
		}
		public void Clear()
		{
			bcbMessenger.Clear();			
		}
	}
}
