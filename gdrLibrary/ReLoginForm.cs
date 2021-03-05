using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace gemoDream
{
	/// <summary>
	/// Summary description for ReLoginForm.
	/// </summary>
	public class ReLoginForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label DepartmentLabel;
		private System.Windows.Forms.ComboBox DptCombo;
		private System.Windows.Forms.TextBox Password;
		private System.Windows.Forms.TextBox Login;
		private System.Windows.Forms.Button LoginButton;
		private System.Windows.Forms.Label PasswordLabel;
		private System.Windows.Forms.Label LoginLabel;
		private System.Windows.Forms.Button btnExit;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private bool bIsBtnPressed = false;
		private string UsName = "";	
		private string sDepartment = "";
		public ReLoginForm()
		{
			// Required for Windows Form Designer support
			InitializeComponent();
			
			bIsBtnPressed = false;
			Login.Text = Service.User;
			UsName = Service.User;
			Login.Enabled = false;
			DptCombo.Items.Add(Service.DepartmentName);
			sDepartment = Service.Department;
			DptCombo.SelectedIndex = 0;
			DptCombo.Enabled = false;

			Password.Focus();
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ReLoginForm));
			this.DepartmentLabel = new System.Windows.Forms.Label();
			this.DptCombo = new System.Windows.Forms.ComboBox();
			this.Password = new System.Windows.Forms.TextBox();
			this.Login = new System.Windows.Forms.TextBox();
			this.LoginButton = new System.Windows.Forms.Button();
			this.PasswordLabel = new System.Windows.Forms.Label();
			this.LoginLabel = new System.Windows.Forms.Label();
			this.btnExit = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// DepartmentLabel
			// 
			this.DepartmentLabel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.DepartmentLabel.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.DepartmentLabel.Location = new System.Drawing.Point(25, 135);
			this.DepartmentLabel.Name = "DepartmentLabel";
			this.DepartmentLabel.Size = new System.Drawing.Size(75, 16);
			this.DepartmentLabel.TabIndex = 6;
			this.DepartmentLabel.Text = "Department";
			this.DepartmentLabel.Visible = false;
			// 
			// DptCombo
			// 
			this.DptCombo.BackColor = System.Drawing.Color.White;
			this.DptCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.DptCombo.Location = new System.Drawing.Point(105, 130);
			this.DptCombo.Name = "DptCombo";
			this.DptCombo.Size = new System.Drawing.Size(160, 20);
			this.DptCombo.TabIndex = 9;
			this.DptCombo.Visible = false;
			// 
			// Password
			// 
			this.Password.AccessibleDescription = "";
			this.Password.AccessibleName = "";
			this.Password.BackColor = System.Drawing.Color.White;
			this.Password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Password.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.Password.Location = new System.Drawing.Point(105, 100);
			this.Password.MaxLength = 32;
			this.Password.Name = "Password";
			this.Password.PasswordChar = '*';
			this.Password.Size = new System.Drawing.Size(156, 20);
			this.Password.TabIndex = 8;
			this.Password.Text = "";
			// 
			// Login
			// 
			this.Login.BackColor = System.Drawing.Color.White;
			this.Login.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Login.Location = new System.Drawing.Point(105, 75);
			this.Login.MaxLength = 30;
			this.Login.Name = "Login";
			this.Login.Size = new System.Drawing.Size(155, 20);
			this.Login.TabIndex = 4;
			this.Login.Text = "";
			// 
			// LoginButton
			// 
			this.LoginButton.BackColor = System.Drawing.Color.AliceBlue;
			this.LoginButton.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LoginButton.Location = new System.Drawing.Point(105, 170);
			this.LoginButton.Name = "LoginButton";
			this.LoginButton.TabIndex = 10;
			this.LoginButton.Text = "Log On";
			this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
			// 
			// PasswordLabel
			// 
			this.PasswordLabel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.PasswordLabel.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.PasswordLabel.Location = new System.Drawing.Point(40, 105);
			this.PasswordLabel.Name = "PasswordLabel";
			this.PasswordLabel.Size = new System.Drawing.Size(56, 16);
			this.PasswordLabel.TabIndex = 7;
			this.PasswordLabel.Text = "Password";
			// 
			// LoginLabel
			// 
			this.LoginLabel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.LoginLabel.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LoginLabel.Location = new System.Drawing.Point(60, 75);
			this.LoginLabel.Name = "LoginLabel";
			this.LoginLabel.Size = new System.Drawing.Size(32, 16);
			this.LoginLabel.TabIndex = 5;
			this.LoginLabel.Text = "Login";
			// 
			// btnExit
			// 
			this.btnExit.BackColor = System.Drawing.Color.AliceBlue;
			this.btnExit.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.btnExit.Location = new System.Drawing.Point(190, 170);
			this.btnExit.Name = "btnExit";
			this.btnExit.TabIndex = 11;
			this.btnExit.Text = "Exit";
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// ReLoginForm
			// 
			this.AcceptButton = this.LoginButton;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = new System.Drawing.Size(334, 208);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.DepartmentLabel);
			this.Controls.Add(this.DptCombo);
			this.Controls.Add(this.Password);
			this.Controls.Add(this.Login);
			this.Controls.Add(this.LoginButton);
			this.Controls.Add(this.PasswordLabel);
			this.Controls.Add(this.LoginLabel);
			this.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.Name = "ReLoginForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Session expired";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.ReLoginForm_Closing);
			this.ResumeLayout(false);

		}
		#endregion

		private void LoginButton_Click(object sender, System.EventArgs e)
		{
			try
			{
				
				DataSet dsAccess;
				switch(Service.Login(Service.User, Password.Text, Service.Department, out dsAccess))
				{
					case 1:
						this.Login.SelectAll();
						throw new Exception("You are not authorized.\nCheck your password, please");						
					case 2: 
						throw new Exception("Client version doesn't correspond to database version.");						
					case 0:						
						break;
				}

				bIsBtnPressed = true;
				if(Service.User == UsName && sDepartment !="0" && sDepartment != "")
					Service.SetDepartmentOfficeId(sDepartment);
				
				this.Close();
			}
			catch(Exception eEx)
			{
				MessageBox.Show(eEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}		
		}

		private void btnExit_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
			bIsBtnPressed = true;
		}

		private void ReLoginForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(!bIsBtnPressed)
				e.Cancel = true;
		}
	}
}
