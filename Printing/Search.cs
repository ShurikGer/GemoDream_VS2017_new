using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace gemoDream
{
	/// <summary>
	/// Summary description for Search.
	/// </summary>
	public class SearchForm : System.Windows.Forms.Form
	{
		private string sEnteredCode = "";
		private System.Windows.Forms.TextBox tbCode;
		private System.Windows.Forms.Button btnSearch;

		private const int DOC_ITEM_DISPLAY_CODE = 19;
		private static int[] DOC_ITEM_DISPLAY_CODE_FORMAT = {1,5,5,3,2};
		private static int DISPLAY_ITEM_DOT1 = DOC_ITEM_DISPLAY_CODE_FORMAT[0];
		private static int DISPLAY_ITEM_DOT2 = DOC_ITEM_DISPLAY_CODE_FORMAT[0]+DOC_ITEM_DISPLAY_CODE_FORMAT[1]+1;
		private static int DISPLAY_ITEM_DOT3 = DOC_ITEM_DISPLAY_CODE_FORMAT[0]+DOC_ITEM_DISPLAY_CODE_FORMAT[1]+DOC_ITEM_DISPLAY_CODE_FORMAT[2]+2;
		private static int DISPLAY_ITEM_DOT4 = DOC_ITEM_DISPLAY_CODE_FORMAT[0]+DOC_ITEM_DISPLAY_CODE_FORMAT[1]+DOC_ITEM_DISPLAY_CODE_FORMAT[2]+DOC_ITEM_DISPLAY_CODE_FORMAT[3]+3;
		private const int DOC_BATCH_DISPLAY_CODE = 16;
		private static int[] DOC_BATCH_DISPLAY_CODE_FORMAT = {1,5,5,3};
		private static int DISPLAY_BATCH_DOT1 = DOC_BATCH_DISPLAY_CODE_FORMAT[0];
		private static int DISPLAY_BATCH_DOT2 = DOC_BATCH_DISPLAY_CODE_FORMAT[0]+DOC_BATCH_DISPLAY_CODE_FORMAT[1]+1;
		private static int DISPLAY_BATCH_DOT3 = DOC_BATCH_DISPLAY_CODE_FORMAT[0]+DOC_BATCH_DISPLAY_CODE_FORMAT[1]+DOC_BATCH_DISPLAY_CODE_FORMAT[2]+2;
		private const int DOC_ORDER_DISPLAY_CODE = 12;
		private static int[] DOC_ORDER_DISPLAY_CODE_FORMAT = {1,5,5};
		private static int DISPLAY_ORDER_DOT1 = DOC_ORDER_DISPLAY_CODE_FORMAT[0];
		private static int DISPLAY_ORDER_DOT12 = DOC_ORDER_DISPLAY_CODE_FORMAT[0]+DOC_ORDER_DISPLAY_CODE_FORMAT[1]+1;

		private const int DOC_ITEM_CODE = 11;
		private static int[] DOC_ITEM_CODE_FORMAT = {1,5,3,2};
		private static int ITEM_DOT1 = DOC_ITEM_CODE_FORMAT[0];
		private static int ITEM_DOT2 = DOC_ITEM_CODE_FORMAT[0]+DOC_ITEM_CODE_FORMAT[1];
		private static int ITEM_DOT3 = DOC_ITEM_CODE_FORMAT[0]+DOC_ITEM_CODE_FORMAT[1]+DOC_ITEM_CODE_FORMAT[2];
		private const int DOC_BATCH_CODE = 9;
		private static int[] DOC_BATCH_CODE_FORMAT = {1,5,3};
		private static int BATCH_DOT1 = DOC_BATCH_CODE_FORMAT[0];
		private static int BATCH_DOT2 = DOC_BATCH_CODE_FORMAT[0]+DOC_BATCH_CODE_FORMAT[1];
		private const int DOC_ORDER_CODE = 6;
		private static int[] DOC_ORDER_CODE_FORMAT = {1,5};
		private static int ORDER_DOT1 = DOC_ORDER_CODE_FORMAT[0];

		private string cDocChar;
		private int iOrderCode = 0;
		private int iEntryBatchCode = 0;
		private int iBatchCode = 0;
		private int iItemCode = 0;

		private struct EnteredBarCode
		{
			public const int JustOperation = 1;
			public const int JustBatch = 3;
			public const int JustItem = 2;
			public const int FullGroupDocument = 6;
			public const int FullBatchDocument = 9;
			public const int FullItemDocument = 11;
			public const int FullGroup = 5;
			public const int FullBatch = 8;
			public const int FullItem = 10;
		}

		public string EnteredCode
		{
			get
			{
				return sEnteredCode;
			}
		}

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SearchForm()
		{
			InitializeComponent();
			tbCode.Focus();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(SearchForm));
			this.tbCode = new System.Windows.Forms.TextBox();
			this.btnSearch = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// tbCode
			// 
			this.tbCode.Location = new System.Drawing.Point(16, 16);
			this.tbCode.Name = "tbCode";
			this.tbCode.Size = new System.Drawing.Size(216, 20);
			this.tbCode.TabIndex = 0;
			this.tbCode.Text = "";
			this.tbCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCode_KeyDown);
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(88, 48);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.TabIndex = 1;
			this.btnSearch.Text = "Search";
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// SearchForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(250, 80);
			this.Controls.Add(this.btnSearch);
			this.Controls.Add(this.tbCode);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "SearchForm";
			this.Text = "Enter document code to search";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			SaveAndExit();
		}

		private void tbCode_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
				SaveAndExit();
		}

		private void SaveAndExit()
		{
			cDocChar = "";
			iOrderCode = 0;
			iEntryBatchCode = 0;
			iBatchCode = 0;
			iItemCode = 0;
			try
			{
				ParseBarCode();
				//sEnteredCode = tbCode.Text;
				string sFullCode = "";

				if(cDocChar != "")
					sFullCode += cDocChar;
				if(iOrderCode > 0)
					sFullCode += GetCorrectCodeString(iOrderCode, 5);
					//sOrderCode = GetCorrectCodeString(iOrderCode, 5);
				if(iEntryBatchCode > 0)
					sFullCode += "."+GetCorrectCodeString(iEntryBatchCode, 5);
					//sEntryBatchCode = GetCorrectCodeString(iOrderCode, 5);
				if(iBatchCode > 0)
					sFullCode += "."+GetCorrectCodeString(iBatchCode, 3);
					//sBatchCode = GetCorrectCodeString(iOrderCode, 3);
				if(iItemCode > 0)
					sFullCode += "."+GetCorrectCodeString(iItemCode, 2);
					//sItemCode = GetCorrectCodeString(iOrderCode, 2);

				if(sFullCode[0] == '.')
					sFullCode = sFullCode.Substring(1, sFullCode.Length-1);

				//string sFullCode = sOrderCode+"."+sEntryBatchCode+"."+sBatchCode+"."+sItemCode;
				sEnteredCode = sFullCode;
				tbCode.Text = "";
				this.Close();
			}
			catch(Exception eEx)
			{
				tbCode.Text = eEx.Message;
				tbCode.Focus();
				tbCode.SelectAll();
			}
		}

		private void ParseBarCode()
		{
			switch(tbCode.Text.Length)
			{
				case EnteredBarCode.JustOperation:
					cDocChar = Convert.ToString(tbCode.Text);
					break;

				/*case EnteredBarCode.JustGroup:
					iOrderCode = Convert.ToInt32(tbCode.Text);
					break;*/
				
				case EnteredBarCode.JustBatch:
					iBatchCode = Convert.ToInt32(tbCode.Text);
					break;
				
				case EnteredBarCode.JustItem:
					iItemCode = Convert.ToInt32(tbCode.Text);
					break;

				case EnteredBarCode.FullGroupDocument:
					cDocChar = Convert.ToString(tbCode.Text.Substring(0, DOC_ORDER_CODE_FORMAT[0]));
					iOrderCode = Convert.ToInt32(tbCode.Text.Substring(ORDER_DOT1, DOC_ORDER_CODE_FORMAT[1]));
					iEntryBatchCode = Convert.ToInt32(tbCode.Text.Substring(ORDER_DOT1, DOC_ORDER_CODE_FORMAT[1]));
					break;

				case EnteredBarCode.FullBatchDocument:
					cDocChar = Convert.ToString(tbCode.Text.Substring(0, DOC_BATCH_CODE_FORMAT[0]));
					iOrderCode = Convert.ToInt32(tbCode.Text.Substring(BATCH_DOT1, DOC_BATCH_CODE_FORMAT[1]));
					iEntryBatchCode = Convert.ToInt32(tbCode.Text.Substring(BATCH_DOT1, DOC_BATCH_CODE_FORMAT[1]));
					iBatchCode = Convert.ToInt32(tbCode.Text.Substring(BATCH_DOT2, DOC_BATCH_CODE_FORMAT[2]));
					break;

				case EnteredBarCode.FullItemDocument:
					cDocChar = Convert.ToString(tbCode.Text.Substring(0, DOC_ITEM_CODE_FORMAT[0]));
					iOrderCode = Convert.ToInt32(tbCode.Text.Substring(ITEM_DOT1, DOC_ITEM_CODE_FORMAT[1]));
					iEntryBatchCode = Convert.ToInt32(tbCode.Text.Substring(ITEM_DOT1, DOC_ITEM_CODE_FORMAT[1]));
					iBatchCode = Convert.ToInt32(tbCode.Text.Substring(ITEM_DOT2, DOC_ITEM_CODE_FORMAT[2]));
					iItemCode = Convert.ToInt32(tbCode.Text.Substring(ITEM_DOT3, DOC_ITEM_CODE_FORMAT[3]));
					break;

				case EnteredBarCode.FullGroup:
					iOrderCode = Convert.ToInt32(tbCode.Text.Substring(ORDER_DOT1-1, DOC_ORDER_CODE_FORMAT[1]));
					//iEntryBatchCode = Convert.ToInt32(tbCode.Text.Substring(ORDER_DOT1-1, DOC_ORDER_CODE_FORMAT[1]));
					break;

				case EnteredBarCode.FullBatch:
					iOrderCode = Convert.ToInt32(tbCode.Text.Substring(BATCH_DOT1-1, DOC_BATCH_CODE_FORMAT[1]));
					//iEntryBatchCode = Convert.ToInt32(tbCode.Text.Substring(BATCH_DOT1-1, DOC_BATCH_CODE_FORMAT[1]));
					iBatchCode = Convert.ToInt32(tbCode.Text.Substring(BATCH_DOT2-1, DOC_BATCH_CODE_FORMAT[2]));
					break;

				case EnteredBarCode.FullItem:
					iOrderCode = Convert.ToInt32(tbCode.Text.Substring(ITEM_DOT1-1, DOC_ITEM_CODE_FORMAT[1]));
					//iEntryBatchCode = Convert.ToInt32(tbCode.Text.Substring(ITEM_DOT1-1, DOC_ITEM_CODE_FORMAT[1]));
					iBatchCode = Convert.ToInt32(tbCode.Text.Substring(ITEM_DOT2-1, DOC_ITEM_CODE_FORMAT[2]));
					iItemCode = Convert.ToInt32(tbCode.Text.Substring(ITEM_DOT3-1, DOC_ITEM_CODE_FORMAT[3]));
					break;

				default:
					throw new Exception("Entered code has incorrect length");
			}
		}

		private string GetCorrectFullCodeString()
		{
			string sDocCode = "";
			if(cDocChar != "")
				sDocCode = cDocChar.ToString();

			if(iOrderCode > 0)
				sDocCode += GetCorrectCodeString(iOrderCode, DOC_ITEM_CODE_FORMAT[1]);
			if(iEntryBatchCode > 0)
				sDocCode += "."+GetCorrectCodeString(iEntryBatchCode, DOC_ITEM_CODE_FORMAT[1]);
			if(iBatchCode > 0)
				sDocCode += "."+GetCorrectCodeString(iBatchCode, DOC_ITEM_CODE_FORMAT[2]);
			if(iItemCode > 0)
				sDocCode += "."+GetCorrectCodeString(iItemCode, DOC_ITEM_CODE_FORMAT[3]);

			return sDocCode;
		}

		private string GetCorrectCodeString(int iCode, int iCodeLength)
		{
			string sCode = iCode.ToString();
			while(sCode.Length < iCodeLength)
				sCode = "0"+sCode;

			return sCode;
		}

	}
}
