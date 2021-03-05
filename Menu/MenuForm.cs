using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Threading;

//using gemoDream;

namespace gemoDream
{
	/// <summary>
	/// Summary description for MenuForm.
	/// </summary>
	public class MenuForm : System.Windows.Forms.Form
	{
		public static bool isWait;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Button btnFront;
		private System.Windows.Forms.Button btnColor;
		private System.Windows.Forms.Button btnClarity;
		private System.Windows.Forms.Button btnItemizn;
		private System.Windows.Forms.Button bCustProg;
		private System.Windows.Forms.Button btnMeasure;
		private System.Windows.Forms.Button btnNewCustomer;
		private System.Windows.Forms.Button btnAccountRep;
		private System.Windows.Forms.Button btnUtils;
		private System.Windows.Forms.Button btnPrint;
		private System.Windows.Forms.Button btnRemeasure;
		private System.Windows.Forms.Button btnReitemizn;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Button btnHistory;
    
        private Thread clockThread = null;
  
		private DataSet dsSecurity;

		public MenuForm(DataSet dsAccess)
		{
			InitializeComponent();
			this.Text = Service.sProgramTitle + this.Text;
			dsSecurity = dsAccess;

//#if DEBUG
//            // For debugging only			
//            string filename = Service.sTempDir + "/myXmlUserData.xml";
//            if (File.Exists(filename)) File.Delete(filename);
//            // Create the FileStream to write with.
//            System.IO.FileStream myFileStream = new System.IO.FileStream(filename, System.IO.FileMode.Create);
//            // Create an XmlTextWriter with the fileStream.
//            System.Xml.XmlTextWriter myXmlWriter = new System.Xml.XmlTextWriter(myFileStream, System.Text.Encoding.Unicode);
//            // Write to the file with the WriteXml method.
//            dsAccess.WriteXml(myXmlWriter);
//            myXmlWriter.Close();
//            // End of debugging part
//#endif
//			String repDir = ProxyGetServiceCfgParameter("repDir");
//			Directory reportsDir = new Directory(repDir);

			//ApplyMenuSecurity(dsAccess);

            //clockThread = new Thread(new ThreadStart(startClock));
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
			this.btnFront = new System.Windows.Forms.Button();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.btnColor = new System.Windows.Forms.Button();
			this.btnClarity = new System.Windows.Forms.Button();
			this.btnItemizn = new System.Windows.Forms.Button();
			this.bCustProg = new System.Windows.Forms.Button();
			this.btnAccountRep = new System.Windows.Forms.Button();
			this.btnMeasure = new System.Windows.Forms.Button();
			this.btnUtils = new System.Windows.Forms.Button();
			this.btnReitemizn = new System.Windows.Forms.Button();
			this.btnNewCustomer = new System.Windows.Forms.Button();
			this.btnRemeasure = new System.Windows.Forms.Button();
			this.btnPrint = new System.Windows.Forms.Button();
			this.btnHistory = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnFront
			// 
			this.btnFront.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.btnFront.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnFront.Enabled = false;
			this.btnFront.Font = new System.Drawing.Font("Verdana", 100F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.btnFront.ForeColor = System.Drawing.Color.Transparent;
			this.btnFront.Image = ((System.Drawing.Image)(resources.GetObject("btnFront.Image")));
			this.btnFront.Location = new System.Drawing.Point(30, 110);
			this.btnFront.Name = "btnFront";
			this.btnFront.Size = new System.Drawing.Size(105, 105);
			this.btnFront.TabIndex = 1;
			this.btnFront.Text = " &f";
			this.btnFront.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btnFront.UseVisualStyleBackColor = false;
			this.btnFront.Click += new System.EventHandler(this.FormButonClicked);
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "");
			// 
			// btnColor
			// 
			this.btnColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.btnColor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnColor.Enabled = false;
			this.btnColor.Font = new System.Drawing.Font("Verdana", 100F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.btnColor.ForeColor = System.Drawing.Color.Transparent;
			this.btnColor.Image = ((System.Drawing.Image)(resources.GetObject("btnColor.Image")));
			this.btnColor.Location = new System.Drawing.Point(160, 240);
			this.btnColor.Name = "btnColor";
			this.btnColor.Size = new System.Drawing.Size(105, 105);
			this.btnColor.TabIndex = 5;
			this.btnColor.Text = " &c";
			this.btnColor.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnColor.UseVisualStyleBackColor = false;
			this.btnColor.Click += new System.EventHandler(this.FormButonClicked);
			// 
			// btnClarity
			// 
			this.btnClarity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.btnClarity.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnClarity.Enabled = false;
			this.btnClarity.Font = new System.Drawing.Font("Verdana", 100F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.btnClarity.ForeColor = System.Drawing.Color.Transparent;
			this.btnClarity.Image = ((System.Drawing.Image)(resources.GetObject("btnClarity.Image")));
			this.btnClarity.Location = new System.Drawing.Point(30, 240);
			this.btnClarity.Name = "btnClarity";
			this.btnClarity.Size = new System.Drawing.Size(105, 105);
			this.btnClarity.TabIndex = 4;
			this.btnClarity.Text = " &l";
			this.btnClarity.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnClarity.UseVisualStyleBackColor = false;
			this.btnClarity.Click += new System.EventHandler(this.FormButonClicked);
			// 
			// btnItemizn
			// 
			this.btnItemizn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.btnItemizn.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnItemizn.Enabled = false;
			this.btnItemizn.Font = new System.Drawing.Font("Verdana", 100F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.btnItemizn.ForeColor = System.Drawing.Color.Transparent;
			this.btnItemizn.Image = ((System.Drawing.Image)(resources.GetObject("btnItemizn.Image")));
			this.btnItemizn.Location = new System.Drawing.Point(160, 110);
			this.btnItemizn.Name = "btnItemizn";
			this.btnItemizn.Size = new System.Drawing.Size(105, 105);
			this.btnItemizn.TabIndex = 2;
			this.btnItemizn.Text = " &i";
			this.btnItemizn.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btnItemizn.UseVisualStyleBackColor = false;
			this.btnItemizn.Click += new System.EventHandler(this.FormButonClicked);
			// 
			// bCustProg
			// 
			this.bCustProg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.bCustProg.Cursor = System.Windows.Forms.Cursors.Hand;
			this.bCustProg.Enabled = false;
			this.bCustProg.Font = new System.Drawing.Font("Verdana", 100F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.bCustProg.ForeColor = System.Drawing.Color.Transparent;
			this.bCustProg.Image = ((System.Drawing.Image)(resources.GetObject("bCustProg.Image")));
			this.bCustProg.Location = new System.Drawing.Point(160, 370);
			this.bCustProg.Name = "bCustProg";
			this.bCustProg.Size = new System.Drawing.Size(105, 105);
			this.bCustProg.TabIndex = 9;
			this.bCustProg.Text = " &s";
			this.bCustProg.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.bCustProg.UseVisualStyleBackColor = false;
			this.bCustProg.Click += new System.EventHandler(this.FormButonClicked);
			// 
			// btnAccountRep
			// 
			this.btnAccountRep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.btnAccountRep.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnAccountRep.Enabled = false;
			this.btnAccountRep.Font = new System.Drawing.Font("Verdana", 100F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.btnAccountRep.ForeColor = System.Drawing.Color.Transparent;
			this.btnAccountRep.Image = ((System.Drawing.Image)(resources.GetObject("btnAccountRep.Image")));
			this.btnAccountRep.Location = new System.Drawing.Point(30, 370);
			this.btnAccountRep.Name = "btnAccountRep";
			this.btnAccountRep.Size = new System.Drawing.Size(105, 105);
			this.btnAccountRep.TabIndex = 8;
			this.btnAccountRep.Text = " &a";
			this.btnAccountRep.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btnAccountRep.UseVisualStyleBackColor = false;
			this.btnAccountRep.Click += new System.EventHandler(this.FormButonClicked);
			// 
			// btnMeasure
			// 
			this.btnMeasure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.btnMeasure.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnMeasure.Enabled = false;
			this.btnMeasure.Font = new System.Drawing.Font("Verdana", 100F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.btnMeasure.ForeColor = System.Drawing.Color.Transparent;
			this.btnMeasure.Image = ((System.Drawing.Image)(resources.GetObject("btnMeasure.Image")));
			this.btnMeasure.Location = new System.Drawing.Point(290, 240);
			this.btnMeasure.Name = "btnMeasure";
			this.btnMeasure.Size = new System.Drawing.Size(105, 105);
			this.btnMeasure.TabIndex = 6;
			this.btnMeasure.Text = " &m";
			this.btnMeasure.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnMeasure.UseVisualStyleBackColor = false;
			this.btnMeasure.Click += new System.EventHandler(this.FormButonClicked);
			// 
			// btnUtils
			// 
			this.btnUtils.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.btnUtils.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnUtils.Enabled = false;
			this.btnUtils.Font = new System.Drawing.Font("Verdana", 100F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.btnUtils.ForeColor = System.Drawing.Color.Transparent;
			this.btnUtils.Image = ((System.Drawing.Image)(resources.GetObject("btnUtils.Image")));
			this.btnUtils.Location = new System.Drawing.Point(590, 370);
			this.btnUtils.Name = "btnUtils";
			this.btnUtils.Size = new System.Drawing.Size(105, 105);
			this.btnUtils.TabIndex = 12;
			this.btnUtils.Text = " &u";
			this.btnUtils.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btnUtils.UseVisualStyleBackColor = false;
			this.btnUtils.Click += new System.EventHandler(this.FormButonClicked);
			// 
			// btnReitemizn
			// 
			this.btnReitemizn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.btnReitemizn.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnReitemizn.Enabled = false;
			this.btnReitemizn.Font = new System.Drawing.Font("Verdana", 100F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.btnReitemizn.ForeColor = System.Drawing.Color.Black;
			this.btnReitemizn.Image = ((System.Drawing.Image)(resources.GetObject("btnReitemizn.Image")));
			this.btnReitemizn.Location = new System.Drawing.Point(290, 110);
			this.btnReitemizn.Name = "btnReitemizn";
			this.btnReitemizn.Size = new System.Drawing.Size(105, 105);
			this.btnReitemizn.TabIndex = 3;
			this.btnReitemizn.Text = " &t";
			this.btnReitemizn.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btnReitemizn.UseVisualStyleBackColor = false;
			this.btnReitemizn.Click += new System.EventHandler(this.FormButonClicked);
			// 
			// btnNewCustomer
			// 
			this.btnNewCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.btnNewCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnNewCustomer.Enabled = false;
			this.btnNewCustomer.Font = new System.Drawing.Font("Verdana", 100F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.btnNewCustomer.ForeColor = System.Drawing.Color.Transparent;
			this.btnNewCustomer.Image = ((System.Drawing.Image)(resources.GetObject("btnNewCustomer.Image")));
			this.btnNewCustomer.Location = new System.Drawing.Point(290, 370);
			this.btnNewCustomer.Name = "btnNewCustomer";
			this.btnNewCustomer.Size = new System.Drawing.Size(105, 105);
			this.btnNewCustomer.TabIndex = 10;
			this.btnNewCustomer.Text = " &n";
			this.btnNewCustomer.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btnNewCustomer.UseVisualStyleBackColor = false;
			this.btnNewCustomer.Click += new System.EventHandler(this.FormButonClicked);
			// 
			// btnRemeasure
			// 
			this.btnRemeasure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.btnRemeasure.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnRemeasure.Enabled = false;
			this.btnRemeasure.Font = new System.Drawing.Font("Verdana", 100F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.btnRemeasure.ForeColor = System.Drawing.Color.Transparent;
			this.btnRemeasure.Image = ((System.Drawing.Image)(resources.GetObject("btnRemeasure.Image")));
			this.btnRemeasure.Location = new System.Drawing.Point(410, 240);
			this.btnRemeasure.Name = "btnRemeasure";
			this.btnRemeasure.Size = new System.Drawing.Size(105, 105);
			this.btnRemeasure.TabIndex = 7;
			this.btnRemeasure.Text = " &e";
			this.btnRemeasure.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnRemeasure.UseVisualStyleBackColor = false;
			this.btnRemeasure.Click += new System.EventHandler(this.FormButonClicked);
			// 
			// btnPrint
			// 
			this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnPrint.Enabled = false;
			this.btnPrint.Font = new System.Drawing.Font("Verdana", 100F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.btnPrint.ForeColor = System.Drawing.Color.Transparent;
			this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
			this.btnPrint.Location = new System.Drawing.Point(410, 370);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new System.Drawing.Size(105, 105);
			this.btnPrint.TabIndex = 11;
			this.btnPrint.Text = " &p";
			this.btnPrint.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btnPrint.UseVisualStyleBackColor = false;
			this.btnPrint.Visible = false;
			this.btnPrint.Click += new System.EventHandler(this.FormButonClicked);
			// 
			// btnHistory
			// 
			this.btnHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.btnHistory.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnHistory.Enabled = false;
			this.btnHistory.Font = new System.Drawing.Font("Verdana", 100F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.btnHistory.ForeColor = System.Drawing.Color.Black;
			this.btnHistory.Image = ((System.Drawing.Image)(resources.GetObject("btnHistory.Image")));
			this.btnHistory.Location = new System.Drawing.Point(590, 240);
			this.btnHistory.Name = "btnHistory";
			this.btnHistory.Size = new System.Drawing.Size(105, 105);
			this.btnHistory.TabIndex = 13;
			this.btnHistory.Text = " &h";
			this.btnHistory.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btnHistory.UseVisualStyleBackColor = false;
			this.btnHistory.Click += new System.EventHandler(this.FormButonClicked);
			// 
			// MenuForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = new System.Drawing.Size(712, 516);
			this.Controls.Add(this.btnHistory);
			this.Controls.Add(this.btnPrint);
			this.Controls.Add(this.btnRemeasure);
			this.Controls.Add(this.btnNewCustomer);
			this.Controls.Add(this.btnReitemizn);
			this.Controls.Add(this.btnUtils);
			this.Controls.Add(this.btnMeasure);
			this.Controls.Add(this.btnAccountRep);
			this.Controls.Add(this.bCustProg);
			this.Controls.Add(this.btnItemizn);
			this.Controls.Add(this.btnClarity);
			this.Controls.Add(this.btnColor);
			this.Controls.Add(this.btnFront);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "MenuForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Menu";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.MenuForm_Closing);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MenuForm(new DataSet()));
			//MenuForm frm = new MenuForm(new DataSet());
			//frm.ShowMenu();
		}


		/// <summary>
		/// Applies menu security according to the current user permissions
		/// </summary>
		/// <param name="dsAccess">current user permissions</param>
		/// <returns>available buttons amount</returns>
		private int ApplyMenuSecurity()
		{
			btnFront.Enabled = false;
			btnItemizn.Enabled = false;
			btnReitemizn.Enabled = false;
			btnClarity.Enabled = false;
			btnColor.Enabled = false;
			btnMeasure.Enabled = false;
			btnRemeasure.Enabled = false;
			btnAccountRep.Enabled = false;
			bCustProg.Enabled = false;
			btnNewCustomer.Enabled = false;
			btnPrint.Enabled = false;
			btnUtils.Enabled = false;

			DataTable dtAccess = dsSecurity.Tables[0];
			string sMenuSecurity = "SecurityLevel";
			string sMenuAccess = "ViewAccessCode";

			DataView dvAccess = new DataView(dtAccess);
			dvAccess.RowFilter = sMenuSecurity+">"+0;

			foreach(DataRowView drvAccess in dvAccess)
			{
				switch (Convert.ToInt32(drvAccess[sMenuAccess]))
				{
					case 1: btnFront.Enabled = true;
						break;
					case 2: btnItemizn.Enabled = true;
						break;
					case 3: btnReitemizn.Enabled = true;
						break;
					case 4: btnClarity.Enabled = true;
						break;
					case 5: btnColor.Enabled = true;
						break;
					case 6: btnMeasure.Enabled = true;
						break;
					case 7: btnRemeasure.Enabled = true;
						break;
					case 8: btnAccountRep.Enabled = true;
						break;
					case 9: bCustProg.Enabled = true;
						break;
					case 10: btnNewCustomer.Enabled = true;
						break;
					case 11: btnPrint.Enabled = true;
						break;
					case 12: btnUtils.Enabled = true;							
						break;
					case 13: btnHistory.Enabled = true;
						break;
					case 16: //permission for delivery person - faux button
						break;
					default: throw new Exception("Security is not set for button with tabindex " + drvAccess[sMenuAccess].ToString());
				}						
			}

			return dvAccess.Count;
		}

		/// <summary>
		/// Shows Menu form
		/// </summary>
		public void ShowMenu()
		{
			if(ApplyMenuSecurity() > 1)
				ShowDialog();
		}

		private void FormButonClicked(object sender, System.EventArgs e)
		{
			try
			{
				int iMenuSecurity = GetFormSecurityLevel(((Button)sender).TabIndex);
				this.Hide();
				isWait = true;
                this.clockThread = new Thread(new ThreadStart(startClock));
                //System.Threading.Thread clockThread;
                //clockThread = new System.Threading.Thread(new System.Threading.ThreadStart(startClock));
                clockThread.Start();
				Form frmNew = new Form();
				this.Cursor = Cursors.WaitCursor;
				switch (((Button)sender).Name)
				{
					case "btnFront": frmNew = new FrontForm(iMenuSecurity);
						break;
					case "btnItemizn": frmNew = new Itemizn1Form(iMenuSecurity);
						break;
					case "btnClarity": frmNew = new ClarityForm(iMenuSecurity);
						break;
					case "btnColor": frmNew = new ColorForm(iMenuSecurity);
						break;
					case "btnMeasure": frmNew = new MeasureForm(iMenuSecurity);
						break;
					case "bCustProg": frmNew = new CustomerProgramForm(iMenuSecurity);
						break;
					case "btnNewCustomer": frmNew = new NewCustomer(iMenuSecurity);
						break;
					case "btnAccountRep": frmNew = new AccountRep(iMenuSecurity);
						break;
					case "btnPrint": frmNew = new PrintingForm(iMenuSecurity);
						break;
					case "btnUtils": frmNew = new UtilsForm(iMenuSecurity);
						break;
					case "btnRemeasure": frmNew = new RemeasureForm(iMenuSecurity);
						break;
					case "btnReitemizn": frmNew = new ReItemiznForm(iMenuSecurity);
						break;
					case "btnHistory": frmNew = new History(iMenuSecurity);
						break;
					default: throw new Exception("Handler is not set for this button. Modify Menu.FormButonClicked(object sender, System.EventArgs e)");
				}
				frmNew.Closing += new CancelEventHandler(frm_Closing);
                isWait = false;
  
                clockThread.Join();
   
				frmNew.ShowDialog(this);
				frmNew.Close();
				frmNew.Dispose();
				this.Cursor = Cursors.Default;
			}
			catch(Exception exc)
			{
				this.Cursor = Cursors.Default;
				MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void startClock()
		{
            waitClock frm = new waitClock();
            frm.ShowDialog();
 		}
		

		private void button1_Click(object sender, System.EventArgs e)
		{
			Form1 frm = new Form1();
			frm.ShowDialog(this);
			this.Cursor = Cursors.Default;
		}

		private int GetFormSecurityLevel(int iMenuAccess)
		{
			string sMenuSecurity = "SecurityLevel";
			string sMenuAccess = "ViewAccessCode";
			int iMenuSecurity=0;
			DataView dvAccess = new DataView(dsSecurity.Tables[0]);

			dvAccess.RowFilter = sMenuAccess+"="+iMenuAccess;
			if(dvAccess.Count>0)
				iMenuSecurity = Convert.ToInt32(dvAccess[0][sMenuSecurity]);

			return iMenuSecurity;
		}

		private void MenuForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			Service.Logoff();
		}		

		private void frm_Closing(object sender, CancelEventArgs e)
		{
			this.Show();
		}
	}
}
