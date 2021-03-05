namespace gemoDream
{
	public partial class BillingOptions
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.cmd_Bill_Default = new System.Windows.Forms.Button();
			this.cmd_BillToQB_primary = new System.Windows.Forms.Button();
			this.cmd_BillToQB_corpt = new System.Windows.Forms.Button();
			this.cmd_BillToTally = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// cmd_Bill_Default
			// 
			this.cmd_Bill_Default.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmd_Bill_Default.Location = new System.Drawing.Point(61, 14);
			this.cmd_Bill_Default.Name = "cmd_Bill_Default";
			this.cmd_Bill_Default.Size = new System.Drawing.Size(351, 32);
			this.cmd_Bill_Default.TabIndex = 0;
			this.cmd_Bill_Default.Text = "Send Invoice to ";
			this.cmd_Bill_Default.UseVisualStyleBackColor = true;
			this.cmd_Bill_Default.Click += new System.EventHandler(this.cmd_Bill_Default_Click);
			// 
			// cmd_BillToQB_primary
			// 
			this.cmd_BillToQB_primary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmd_BillToQB_primary.Location = new System.Drawing.Point(62, 69);
			this.cmd_BillToQB_primary.Name = "cmd_BillToQB_primary";
			this.cmd_BillToQB_primary.Size = new System.Drawing.Size(90, 25);
			this.cmd_BillToQB_primary.TabIndex = 1;
			this.cmd_BillToQB_primary.Text = "QB primary";
			this.cmd_BillToQB_primary.UseVisualStyleBackColor = true;
			this.cmd_BillToQB_primary.Click += new System.EventHandler(this.cmd_BillToQB_primary_Click);
			// 
			// cmd_BillToQB_corpt
			// 
			this.cmd_BillToQB_corpt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmd_BillToQB_corpt.Location = new System.Drawing.Point(192, 69);
			this.cmd_BillToQB_corpt.Name = "cmd_BillToQB_corpt";
			this.cmd_BillToQB_corpt.Size = new System.Drawing.Size(90, 25);
			this.cmd_BillToQB_corpt.TabIndex = 2;
			this.cmd_BillToQB_corpt.Text = "QB corpt";
			this.cmd_BillToQB_corpt.UseVisualStyleBackColor = true;
			this.cmd_BillToQB_corpt.Click += new System.EventHandler(this.cmd_BillToQB_corpt_Click);
			// 
			// cmd_BillToTally
			// 
			this.cmd_BillToTally.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmd_BillToTally.Location = new System.Drawing.Point(322, 69);
			this.cmd_BillToTally.Name = "cmd_BillToTally";
			this.cmd_BillToTally.Size = new System.Drawing.Size(90, 25);
			this.cmd_BillToTally.TabIndex = 3;
			this.cmd_BillToTally.Text = "Tally";
			this.cmd_BillToTally.UseVisualStyleBackColor = true;
			this.cmd_BillToTally.Click += new System.EventHandler(this.cmd_BillToTally_Click);
			// 
			// BillingOptions
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(466, 106);
			this.Controls.Add(this.cmd_BillToTally);
			this.Controls.Add(this.cmd_BillToQB_corpt);
			this.Controls.Add(this.cmd_BillToQB_primary);
			this.Controls.Add(this.cmd_Bill_Default);
			this.Name = "BillingOptions";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Select Billing Options";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BillingOptions_FormClosed);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button cmd_Bill_Default;
		private System.Windows.Forms.Button cmd_BillToQB_primary;
		private System.Windows.Forms.Button cmd_BillToQB_corpt;
		private System.Windows.Forms.Button cmd_BillToTally;
	}
}