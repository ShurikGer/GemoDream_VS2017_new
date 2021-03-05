using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Cntrls
{
	/// <summary>
	/// Summary description for PartPropControl.
	/// </summary>
	public class PartPropControl : System.Windows.Forms.UserControl
	{
		public System.Windows.Forms.TextBox tbMaxValue;
		public System.Windows.Forms.TextBox tbPropName;
		public System.Windows.Forms.TextBox tbMinValue;
		public System.Windows.Forms.CheckBox chbDo;
		public System.Windows.Forms.ComboBox cbMinValue;
		public System.Windows.Forms.ComboBox cbMaxValue;
		private System.Windows.Forms.ToolTip ttCheckBoxPopUp;
		public CheckBox chbDo2;
		public CheckBox chbDo3;
		public CheckBox chbDo4;
		private PictureBox pictureBox1;
		private System.ComponentModel.IContainer components;

		public PartPropControl()
		{
			InitializeComponent();

			ttCheckBoxPopUp.SetToolTip(this.chbDo, "Enable/Disable measure");
			ttCheckBoxPopUp.SetToolTip(this.chbDo2, "Visible/Invisible in CCM");
			ttCheckBoxPopUp.SetToolTip(this.chbDo3, "Is default value");
			ttCheckBoxPopUp.SetToolTip(this.chbDo4, "For Info Only");
			ttCheckBoxPopUp.SetToolTip(this.tbMinValue, "Min");
			ttCheckBoxPopUp.SetToolTip(this.tbMaxValue, "Max");
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
			this.components = new System.ComponentModel.Container();
			this.tbMaxValue = new System.Windows.Forms.TextBox();
			this.tbMinValue = new System.Windows.Forms.TextBox();
			this.tbPropName = new System.Windows.Forms.TextBox();
			this.chbDo = new System.Windows.Forms.CheckBox();
			this.cbMinValue = new System.Windows.Forms.ComboBox();
			this.cbMaxValue = new System.Windows.Forms.ComboBox();
			this.ttCheckBoxPopUp = new System.Windows.Forms.ToolTip(this.components);
			this.chbDo2 = new System.Windows.Forms.CheckBox();
			this.chbDo3 = new System.Windows.Forms.CheckBox();
			this.chbDo4 = new System.Windows.Forms.CheckBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// tbMaxValue
			// 
			this.tbMaxValue.Enabled = false;
			this.tbMaxValue.Location = new System.Drawing.Point(250, 0);
			this.tbMaxValue.Name = "tbMaxValue";
			this.tbMaxValue.Size = new System.Drawing.Size(105, 20);
			this.tbMaxValue.TabIndex = 5;
			this.tbMaxValue.Leave += new System.EventHandler(this.tbMaxValue_Leave);
			// 
			// tbMinValue
			// 
			this.tbMinValue.Enabled = false;
			this.tbMinValue.Location = new System.Drawing.Point(140, 0);
			this.tbMinValue.Name = "tbMinValue";
			this.tbMinValue.Size = new System.Drawing.Size(105, 20);
			this.tbMinValue.TabIndex = 4;
			this.tbMinValue.Leave += new System.EventHandler(this.tbMinValue_Leave);
			// 
			// tbPropName
			// 
			this.tbPropName.Enabled = false;
			this.tbPropName.Location = new System.Drawing.Point(0, 0);
			this.tbPropName.Name = "tbPropName";
			this.tbPropName.ReadOnly = true;
			this.tbPropName.Size = new System.Drawing.Size(135, 20);
			this.tbPropName.TabIndex = 3;
			// 
			// chbDo
			// 
			this.chbDo.Location = new System.Drawing.Point(357, 5);
			this.chbDo.Name = "chbDo";
			this.chbDo.Size = new System.Drawing.Size(15, 15);
			this.chbDo.TabIndex = 6;
			this.chbDo.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// cbMinValue
			// 
			this.cbMinValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbMinValue.DropDownWidth = 100;
			this.cbMinValue.Enabled = false;
			this.cbMinValue.Location = new System.Drawing.Point(140, 0);
			this.cbMinValue.Name = "cbMinValue";
			this.cbMinValue.Size = new System.Drawing.Size(105, 21);
			this.cbMinValue.TabIndex = 7;
			this.cbMinValue.Leave += new System.EventHandler(this.cbMinValue_Leave);
			// 
			// cbMaxValue
			// 
			this.cbMaxValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbMaxValue.DropDownWidth = 100;
			this.cbMaxValue.Enabled = false;
			this.cbMaxValue.Location = new System.Drawing.Point(250, 0);
			this.cbMaxValue.Name = "cbMaxValue";
			this.cbMaxValue.Size = new System.Drawing.Size(105, 21);
			this.cbMaxValue.TabIndex = 8;
			this.cbMaxValue.Leave += new System.EventHandler(this.cbMaxValue_Leave);
			// 
			// chbDo2
			// 
			this.chbDo2.Location = new System.Drawing.Point(377, 5);
			this.chbDo2.Name = "chbDo2";
			this.chbDo2.Size = new System.Drawing.Size(15, 15);
			this.chbDo2.TabIndex = 10;
			// 
			// chbDo3
			// 
			this.chbDo3.Location = new System.Drawing.Point(397, 5);
			this.chbDo3.Name = "chbDo3";
			this.chbDo3.Size = new System.Drawing.Size(15, 15);
			this.chbDo3.TabIndex = 11;
			this.chbDo3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
			// 
			// chbDo4
			// 
			this.chbDo4.BackColor = System.Drawing.SystemColors.Control;
			this.chbDo4.FlatAppearance.BorderColor = System.Drawing.Color.White;
			this.chbDo4.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
			this.chbDo4.ForeColor = System.Drawing.SystemColors.Control;
			this.chbDo4.Location = new System.Drawing.Point(417, 5);
			this.chbDo4.Name = "chbDo4";
			this.chbDo4.Size = new System.Drawing.Size(12, 12);
			this.chbDo4.TabIndex = 12;
			this.chbDo4.UseVisualStyleBackColor = false;
			this.chbDo4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.SystemColors.Highlight;
			this.pictureBox1.Location = new System.Drawing.Point(411, 3);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(25, 18);
			this.pictureBox1.TabIndex = 13;
			this.pictureBox1.TabStop = false;
			// 
			// PartPropControl
			// 
			this.Controls.Add(this.chbDo4);
			this.Controls.Add(this.chbDo3);
			this.Controls.Add(this.chbDo2);
			this.Controls.Add(this.cbMaxValue);
			this.Controls.Add(this.cbMinValue);
			this.Controls.Add(this.chbDo);
			this.Controls.Add(this.tbMaxValue);
			this.Controls.Add(this.tbMinValue);
			this.Controls.Add(this.tbPropName);
			this.Controls.Add(this.pictureBox1);
			this.Name = "PartPropControl";
			this.Size = new System.Drawing.Size(436, 20);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
		{
			chbDo3.Enabled = chbDo.Checked;
			chbDo4.Enabled = chbDo.Checked;
			//chbDo4.Checked = !chbDo3.Checked;
			//chbDo3.Checked = !chbDo4.Checked;
			tbMaxValue.Enabled = tbMinValue.Enabled = tbPropName.Enabled = 
				cbMaxValue.Enabled = cbMinValue.Enabled = chbDo.Checked;
			OnReadyToUpdate(EventArgs.Empty);
		}

		private void checkBox3_CheckedChanged(object sender, System.EventArgs e)
		{
			if (chbDo3.Checked) chbDo4.Checked = false;
			//chbDo3.Enabled = chbDo.Checked;
			//chbDo4.Enabled = chbDo.Checked;
			//chbDo4.Checked = !chbDo3.Checked;
			//chbDo3.Checked = !chbDo4.Checked;
		}

		private void checkBox4_CheckedChanged(object sender, System.EventArgs e)
		{
			if (chbDo4.Checked) chbDo3.Checked = false;
			//chbDo3.Enabled = chbDo.Checked;
			//chbDo4.Enabled = chbDo.Checked;
			//chbDo4.Checked = !chbDo3.Checked;
			//chbDo3.Checked = !chbDo4.Checked;
		}

		private void tbMinValue_Leave(object sender, System.EventArgs e)
		{
			string sDS = System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
			try
			{
				tbMinValue.Text = (Convert.ToDouble(tbMinValue.Text)).ToString(".####");
			}
			catch
			{
				tbMinValue.Text = "0" + sDS + "00";
			}
			OnReadyToUpdate(EventArgs.Empty);
		}

		private void tbMaxValue_Leave(object sender, System.EventArgs e)
		{
			string sDS = System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
			try
			{
				tbMaxValue.Text = (Convert.ToDouble(tbMaxValue.Text)).ToString(".####");
			}
			catch
			{
				tbMaxValue.Text = "0" + sDS + "00";
			}
			OnReadyToUpdate(EventArgs.Empty);
		}

		public event EventHandler ReadyToUpdate;

		protected virtual void OnReadyToUpdate(EventArgs ea)
		{
			if(ReadyToUpdate != null)
				ReadyToUpdate(this, ea);
		}

		private void cbMinValue_Leave(object sender, System.EventArgs e)
		{
			OnReadyToUpdate(EventArgs.Empty);
		}

		private void cbMaxValue_Leave(object sender, System.EventArgs e)
		{
			OnReadyToUpdate(EventArgs.Empty);
		}
	}
}
