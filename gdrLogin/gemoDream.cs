using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Xml;
using System.IO;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

// Developed namespaces
//using gdrClientLibrary;

//Working version
namespace gemoDream
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class LoginForm : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Label LoginLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.TextBox Login;
        private System.Windows.Forms.Label DepartmentLabel;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.ComboBox DptCombo;
        private System.Windows.Forms.Button btnExit;
		private Label label1;
        // Required designer variable.
        private System.ComponentModel.Container components = null;
        //private DataSet dsDepartments = null;

        /// <summary>
        /// LoginForm class constructor
        /// </summary>
        public LoginForm()
        {
            // Required for Windows Form Designer support
            InitializeComponent();
            Login.Focus();
			PrepareSystemToWork();
            this.Text = Service.sTitle;
			label1.Text = "VS2017-" + Service.sOfficeGroup;
            try
            {
                // getting office departments from db
                //dsDepartments = Service.GetOfficeDepartments();
                //DptCombo.DataSource = dsDepartments.Tables[0];
                //DptCombo.DisplayMember = "DepartmentName";
                //DptCombo.ValueMember = "OfficeID_DepartmentID";

                // getting last used department
                //XmlNode xnNode = Client.GetXmlElement("department");
                //Service.Department = xnNode.InnerText.ToString();
                //DptCombo.SelectedValue = Service.Department;

                Service.sProgramFileFolder = @"C:\PROGRAM FILES";
                string[] dirs = Directory.GetDirectories(@"c:\", "program files*");
                foreach (string dir in dirs)
                {
                    if (dir.Trim().ToUpper() != Service.sProgramFileFolder)
                    {
                        Service.sProgramFileFolder = dir;
                        break;
                    }
                }

				//Service.sAppDir = System.IO.Directory.GetCurrentDirectory();
				//Service.sTempDir = System.Environment.GetEnvironmentVariable("TEMP");
                Service.log = new Log(Service.sAppDir + @"\measure.log");
            }
            catch (Exception eEx)
            {
                MessageBox.Show(eEx.Message);
            }
	     }


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }


        #region Windows Form
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.LoginLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.LoginButton = new System.Windows.Forms.Button();
            this.Login = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.DptCombo = new System.Windows.Forms.ComboBox();
            this.DepartmentLabel = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LoginLabel
            // 
            this.LoginLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LoginLabel.Location = new System.Drawing.Point(60, 75);
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.Size = new System.Drawing.Size(40, 20);
            this.LoginLabel.TabIndex = 0;
            this.LoginLabel.Text = "Login";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PasswordLabel.Location = new System.Drawing.Point(40, 115);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(56, 16);
            this.PasswordLabel.TabIndex = 1;
            this.PasswordLabel.Text = "Password";
            // 
            // LoginButton
            // 
            this.LoginButton.BackColor = System.Drawing.Color.AliceBlue;
            this.LoginButton.Location = new System.Drawing.Point(118, 164);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(75, 23);
            this.LoginButton.TabIndex = 3;
            this.LoginButton.Text = "Log On";
            this.LoginButton.UseVisualStyleBackColor = false;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // Login
            // 
            this.Login.BackColor = System.Drawing.Color.White;
            this.Login.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Login.Location = new System.Drawing.Point(105, 75);
            this.Login.MaxLength = 30;
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(155, 20);
            this.Login.TabIndex = 0;
            // 
            // Password
            // 
            this.Password.AccessibleDescription = "";
            this.Password.AccessibleName = "";
            this.Password.BackColor = System.Drawing.Color.White;
            this.Password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Password.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Password.Location = new System.Drawing.Point(105, 110);
            this.Password.MaxLength = 32;
            this.Password.Name = "Password";
            this.Password.PasswordChar = '*';
            this.Password.Size = new System.Drawing.Size(156, 20);
            this.Password.TabIndex = 1;
            // 
            // DptCombo
            // 
            this.DptCombo.BackColor = System.Drawing.Color.White;
            this.DptCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DptCombo.Location = new System.Drawing.Point(105, 130);
            this.DptCombo.Name = "DptCombo";
            this.DptCombo.Size = new System.Drawing.Size(160, 20);
            this.DptCombo.TabIndex = 2;
            this.DptCombo.Visible = false;
            // 
            // DepartmentLabel
            // 
            this.DepartmentLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DepartmentLabel.Location = new System.Drawing.Point(25, 135);
            this.DepartmentLabel.Name = "DepartmentLabel";
            this.DepartmentLabel.Size = new System.Drawing.Size(75, 16);
            this.DepartmentLabel.TabIndex = 0;
            this.DepartmentLabel.Text = "Department";
            this.DepartmentLabel.Visible = false;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.AliceBlue;
            this.btnExit.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnExit.Location = new System.Drawing.Point(213, 164);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Tan;
            this.label1.Location = new System.Drawing.Point(37, 196);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "VS 2017";
            // 
            // LoginForm
            // 
            this.AcceptButton = this.LoginButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(334, 208);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.DepartmentLabel);
            this.Controls.Add(this.DptCombo);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.LoginLabel);
            this.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login GemoDream";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
				//Service.sOfficeGroup = Service.GetMyIP_Group();
				//Service.sAppDir = System.IO.Directory.GetCurrentDirectory();
				//Service.sTempDir = System.Environment.GetEnvironmentVariable("TEMP");
				
				//Service.CreateService();
                //Service.GetOfficeCode();

                Application.Run(new LoginForm());
            }
            catch (Exception eEx)
            {
                MessageBox.Show(eEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
			
	     }


        /// <summary>
        /// LoginButton button click event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event argument</param>
		
        private void LoginButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (Login.Text.Length == 0)
                    throw new Exception("You can't log on with zero length login.");
                //if(DptCombo.SelectedIndex == -1)
                //	throw new Exception("You can't log on without selected department.");

                string sSelectedDept = "";//DptCombo.SelectedValue.ToString();
                //DataView dvDepartments = new DataView(dsDepartments.Tables[0]);
                //dvDepartments.RowFilter = "OfficeID_DepartmentID='"+sSelectedDept+"'";
                //if(dvDepartments.Count > 0)
                //	Service.DepartmentName = dvDepartments[0]["DepartmentName"].ToString();

                DataSet dsAccess;
                switch (Service.Login(Login.Text, Password.Text, sSelectedDept, out dsAccess))
                {
                    case 1:
                        this.Login.SelectAll();
                        throw new Exception("You are not authorized.\nCheck your password, please");
                    case 2:
                        throw new Exception("Client version doesn't correspond to database version.");
                    case 0:
                        break;
                }

                Service.sProgramTitle = Login.Text.ToUpper() + ". " + Service.sTitle;
                Password.Text = "";

                this.Text = Service.sProgramTitle;
                //				MenuForm frm = new MenuForm(dsAccess);
                //				this.Hide();

                //				Process[] myProcesses;
                //				myProcesses = Process.GetProcessesByName("EXCEL");
                //				if (myProcesses.Length > 0)
                //				{
                //					MessageBox.Show("Warning: You have running Excel/Excel file(s). Please, save files", "Open Excel file(s)",
                //							MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //				}
                //				Client.KillOpenExcel();

                string sFileName = "";
                string sFileNameKeyMap = "";
                try
                {
                    //                    Process p = new Process();
                    //                    p.StartInfo.FileName = "IPCONFIG";
                    //                    p.StartInfo.UseShellExecute = false;
                    //                    //p.StartInfo.Arguments = "/all";
                    //                    p.StartInfo.RedirectStandardOutput = true;
                    //                    p.Start();
                    //
                    //                    string[] myIP1 = Regex.Split(p.StandardOutput.ReadToEnd().ToString().Trim(), "\r\n");
                    //                    string sIPaddress = "";
                    //                    string[] sIP = null;
                    //
                    //                    foreach (string line in myIP1)
                    //                    {
                    //                        if (line.ToUpper().IndexOf("IP ADDRESS") >= 0 || line.ToUpper().IndexOf("IPV4 ADDRESS") >= 0)
                    //                        {
                    //                            sIPaddress = line.Substring(line.IndexOf(":") + 1).Trim();
                    //                            break;
                    //                        }
                    //                    }
                    //                    if (sIPaddress.Trim() != "")
                    //                    {
                    //                        //                        string sIPaddress = System.Net.Dns.GetHostByName(Environment.MachineName).AddressList[0].ToString();
                    //                        sIP = sIPaddress.Split('.');
                    //                        Service.sOfficeGroup = sIP[2].Trim();
                    //                    }
                    //                    MessageBox.Show("Ipconfig text: " + Service.sIP_AddressTest);
                    //                    MessageBox.Show("Office group: " + Service.sOfficeGroup);
                    sFileNameKeyMap = "Offices.xml";
                    //sFileName = "Offices.xml";
				    Service.GetKeymap(sFileNameKeyMap);
				    sFileName = Service.sTempDir + System.IO.Path.DirectorySeparatorChar + sFileNameKeyMap;
                    //sFileName = Service.sAppDir + System.IO.Path.DirectorySeparatorChar + sFileName;
                    Service.xmlOffices = new XmlDocument();
                    Service.xmlOffices.Load(sFileName);
                    //MessageBox.Show("File " + sFileNameKeyMap + " was loaded");
                    Service.sDirConfigFile = Service.GetOfficeConfig(Service.sOfficeGroup, "OfficeConfigFile");
					//MessageBox.Show("File to load " + Service.sDirConfigFile);
                    //sFileName = Service.sAppDir + System.IO.Path.DirectorySeparatorChar + Service.sDirConfigFile;
                    //                    switch(sIP[2])
                    //                    {
                    //                        case "1": 
                    //                        {
                    //                            Service.sDirConfigFile = "OfficeCfg_2.xml"; break;
                    //                        }
                    //                        case "2": 
                    //                        {
                    //                            Service.sDirConfigFile = "OfficeCfg_1.xml"; break;
                    //                        }
                    //                        case "20": 
                    //                        {
                    //                            Service.sDirConfigFile = "OfficeCfg_3.xml"; break;
                    //                        }
                    //                        case "30":
                    //                        {
                    //                            Service.sDirConfigFile = "OfficeCfg_4.xml"; break;                        
                    //                        }
                    //                    
                    //                        default:
                    //                        {
                    //                            throw new Exception("Can't find Office Group Code");
                    //                        }
                    //                    }

                    if (Service.GetKeymap(Service.sDirConfigFile) == true)
                    {
                        sFileName = Service.sTempDir + System.IO.Path.DirectorySeparatorChar + Service.sDirConfigFile;
                        //sFileName = Service.sAppDir + System.IO.Path.DirectorySeparatorChar + Service.sDirConfigFile;
                        Service.xmlOfficeCfg = new XmlDocument();
                        Service.xmlOfficeCfg.Load(sFileName);
                    }

                }
                catch (Exception eEx)
                {
                    MessageBox.Show(eEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Password.Text = "";
                    this.Show();
                    //Password.Select();
                    //Password.SelectAll();
                    return;
                }

				try
				{
					//string sFileName = "";
					sFileNameKeyMap = "MeasureKeymap.xml";
					//sFileName = "MeasureKeymap.xml";
					Service.GetKeymap(sFileNameKeyMap);
					sFileName = Service.sTempDir + System.IO.Path.DirectorySeparatorChar + sFileNameKeyMap;
					//sFileName = Service.sAppDir + System.IO.Path.DirectorySeparatorChar + sFileName;
					Service.xmlDocMeasureKeyMap = new XmlDocument();
					Service.xmlDocMeasureKeyMap.Load(sFileName);

					sFileNameKeyMap = "ColorKeymap.xml";
					//sFileName = "ColorKeymap.xml";
					Service.GetKeymap(sFileNameKeyMap);
					sFileName = Service.sTempDir + System.IO.Path.DirectorySeparatorChar + sFileNameKeyMap;
					//sFileName = Service.sAppDir + System.IO.Path.DirectorySeparatorChar + sFileName;
					Service.xmlDocColorKeyMap = new XmlDocument();
					Service.xmlDocColorKeyMap.Load(sFileName);

					sFileNameKeyMap = "ClarityKeymap.xml";
					//sFileName = "ClarityKeymap.xml";
					Service.GetKeymap(sFileNameKeyMap);
					sFileName = Service.sTempDir + System.IO.Path.DirectorySeparatorChar + sFileNameKeyMap;
					//sFileName = Service.sAppDir + System.IO.Path.DirectorySeparatorChar + sFileName;				
					Service.xmlDocClarityKeyMap = new XmlDocument();
					Service.xmlDocClarityKeyMap.Load(sFileName);

					sFileNameKeyMap = "Formats.xml";
					//sFileName = "Formats.xml";
					Service.GetKeymap(sFileNameKeyMap);
					sFileName = Service.sTempDir + System.IO.Path.DirectorySeparatorChar + sFileNameKeyMap;
					//sFileName = Service.sAppDir + System.IO.Path.DirectorySeparatorChar + sFileName;		            
					Service.xmlDocFormats = new XmlDocument();
					Service.xmlDocFormats.Load(sFileName);

					sFileName = "Printers.xml";
					sFileName = Service.sAppDir + System.IO.Path.DirectorySeparatorChar + sFileName;
					Service.xmlPrinters = new XmlDocument();
					Service.xmlPrinters.Load(sFileName);

				}
				catch { }

				//try
				//{
				//    Service.dsRestrictedNumbers = new DataSet();

				//    Service.dsRestrictedNumbers = Service.GetRestrictedNumbers();
				//}
				//catch { }

                MenuForm frm = new MenuForm(dsAccess);

                this.Hide();
                frm.ShowMenu();
                this.Show();
            }

            catch (Exception eEx)
            {
                MessageBox.Show(eEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Password.Text = "";
                this.Show();
                //Password.Select();
                //Password.SelectAll();
                return;
            }
        }

		private void PrepareSystemToWork()
		{
			Service.sOfficeGroup = Service.GetMyIP_Group();
			Service.sAppDir = System.IO.Directory.GetCurrentDirectory();
			Service.sTempDir = System.Environment.GetEnvironmentVariable("TEMP");

			Service.CreateService();
		}

        private void LoginForm_Load(object sender, System.EventArgs e)
        {
            Login.Text = "admin";
            Password.Text = "admin";
            LoginButton_Click(this, EventArgs.Empty);
        }

        private void btnExit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
