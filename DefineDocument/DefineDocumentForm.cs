using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Diagnostics;
using gemoDream.gemoDreamService;

namespace gemoDream
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class DefineDocumentForm : System.Windows.Forms.Form
	{
		public class NewOperationData
		{
			public string sDocumentID;
			public string sOperationTypeID;
			public string sOperationTypeOfficeID;
			public string sCPOfficeID;
			public string sCPID;
		}

		public enum DocTypeCode
		{
			MDX = 1,
			FDX = 2,
			IDX = 3
		}

		private enum DocumentExistance
		{
			DocumentNotExists = 1,
			DocumentExistsWithSameType = 2,
			DocumentExistsWithOtherType = 3
		}

		//private DefDocType DocumentType = 0;
		private string sDocTypeCode = null;
		private string sOperationTypeID = null;
		private string sDocumentName = null;
		private ArrayList newOperationsListMember = null;
		private DataSet dsParts = null;
		private DataSet dsNotVCCM = null;
		private bool IsLoadDocuments = false;
		private bool IsLoadImPExpInfo = false;
		private bool IsUpdateImPExpInfo = false;
		private string sOperationTypeOfficeID_OperationTypeID;
		private string sCPID = null;
		private string sCPOfficeID = null;
		private string sOperationTypeName;
		private string sDocumentID;
		//private string sOperationName;
		private DocTypeCode docTypeCode;
		private bool bInitLanguage = false;
		private string sItemTypeID = "";
		private string sPath2Picture = "";
		//private DataView dvDefDocTitles = null;
		private DataView dvMeasures = null;
		private DataSet ds = null;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ComboBox cbDocuments;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox lbMeasures;
		private System.Windows.Forms.DataGrid dataGrid;
		private System.Windows.Forms.Button btnMoveDown;
		private System.Windows.Forms.Button btnMoveUp;
		private System.Windows.Forms.Button btnDeleteLine;
		private System.Windows.Forms.Button btnAddLine;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.RadioButton rbSlash;
		private System.Windows.Forms.RadioButton rbX;
		private System.Windows.Forms.RadioButton rbMult;
		private System.Windows.Forms.RadioButton rbSpace;
		private System.Windows.Forms.RadioButton rbSpace2;
		private System.Windows.Forms.RadioButton rbSpace3;
		private System.Windows.Forms.RadioButton rbSpace4;
		private System.Windows.Forms.ListBox lbDefDocTitles;
		private System.Windows.Forms.Button btnView;
		private System.Windows.Forms.Button btnSaveWithName;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.TextBox tbFixedText;
		private System.Windows.Forms.RadioButton rbFixedText;
		private System.Windows.Forms.RadioButton rbReportNumber;
		private Cntrls.PartTreeEx1 ptItemStructure;
		private System.Windows.Forms.ComboBox cbLanguage;
		private System.Windows.Forms.CheckBox cbUseVVN;
		private System.Windows.Forms.CheckBox cbUseDate;
		private System.Windows.Forms.PictureBox pbItemPicture;
		private System.Windows.Forms.Button btnAttach;
		private System.Windows.Forms.Button btnUpdate;
		private System.Windows.Forms.Button btnInsertLine;
		private System.Windows.Forms.ListBox lbCorelFiles;
		private System.Windows.Forms.ComboBox cbFTPimport;
		private System.Windows.Forms.ComboBox cbFTPExport;
		private System.Windows.Forms.ComboBox cbExportFormat;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private PictureBox pictureBox1;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		/*
													iAccessLevel, 
													dsNotVCCM,
													sItemTypeID, 
													sPath2Picture, 
													sOperationTypeName, 
													sCPOfficeID, 
													sCPID, 
													newOperationsList, 
													sDocTypeCode, 
													sOperationTypeID, 
													sCPName);
		*/



		public DefineDocumentForm(int iAccessLevel,
									DataSet dsNotVCCM,
									string sItemTypeID,
									string sPath2Picture,
									string sOperationTypeName,
									string sCPOfficeID,
									string sCPID,
									ArrayList newOperationsList,
									string sDocTypeCode,
									string sCPName)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			this.sDocTypeCode = sDocTypeCode;
			this.Text += GetCaption(sOperationTypeName, sCPName);
			this.sItemTypeID = sItemTypeID;
			this.sPath2Picture = sPath2Picture;
			this.sOperationTypeName = sOperationTypeName;
			this.dsNotVCCM = dsNotVCCM;
			this.newOperationsListMember = newOperationsList;
			CommonInit();
			SetAccessLevel(iAccessLevel);
		}
		//This part is called from CP documents part (not default document)
		public DefineDocumentForm(int iAccessLevel,
									DataSet dsNotVCCM,
									string sItemTypeID,
									string sPath2Picture,
									string sOperationTypeName,
									string sCPOfficeID,
									string sCPID,
									ArrayList newOperationsList,
									string sDocTypeCode,
									string sOperationTypeID,
									string sCPName)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			//this.docTypeCode = docTypeCode;
			this.sDocTypeCode = sDocTypeCode;
			this.sOperationTypeID = sOperationTypeID;
			string[] sDocs;

			if (sOperationTypeName.IndexOf(',') < 0)
				this.Text += GetCaption("Document Type: " + sOperationTypeName, " SKU: " + sCPName);
			else
			{
				sDocs = sOperationTypeName.Split(',');
				sOperationTypeName = sDocs[1].Trim();
				this.Text += GetCaption("Document Type: " + sDocs[1].Trim(), " SKU: " + sCPName);
			}
			this.sItemTypeID = sItemTypeID;
			this.sPath2Picture = sPath2Picture;
			this.sOperationTypeName = sOperationTypeName;
			this.sCPOfficeID = sCPOfficeID;
			this.sCPID = sCPID;
			this.dsNotVCCM = dsNotVCCM;
			this.newOperationsListMember = newOperationsList;
			CommonInit();
			SetAccessLevel(iAccessLevel);
		}

		private void SetAccessLevel(int iAccessLevel)
		{
			//iAccessLevel = 2;
			switch (iAccessLevel)
			{
				case 1:
					{
						this.cbDocuments.Enabled = false;
						this.lbCorelFiles.Enabled = false;
						this.ptItemStructure.Enabled = false;
						this.rbSlash.Enabled = false;
						this.rbX.Enabled = false;
						this.rbMult.Enabled = false;
						this.rbSpace.Enabled = false;
						this.rbSpace2.Enabled = false;
						this.rbSpace3.Enabled = false;
						this.rbSpace4.Enabled = false;
						this.cbLanguage.Enabled = false;
						this.cbUseDate.Enabled = false;
						this.cbUseVVN.Enabled = false;
						this.rbReportNumber.Enabled = false;
						this.rbFixedText.Enabled = false;
						this.tbFixedText.Enabled = false;
						this.lbDefDocTitles.Enabled = false;
						this.lbMeasures.Enabled = false;
						this.dataGrid.Enabled = false;
						this.btnAddLine.Enabled = false;
						this.btnInsertLine.Enabled = false;
						this.btnDeleteLine.Enabled = false;
						this.btnMoveUp.Enabled = false;
						this.btnMoveDown.Enabled = false;
						this.btnView.Enabled = false;
						this.btnClear.Enabled = false;
						this.btnSaveWithName.Enabled = false;
						this.btnUpdate.Enabled = false;
						this.btnAttach.Enabled = false;
						break;
					}
				case 2:
					{
						//this.cbDocuments.Enabled = false;
						this.lbCorelFiles.Enabled = false;
						//this.ptItemStructure.Enabled = false;
						this.rbSlash.Enabled = false;
						this.rbX.Enabled = false;
						this.rbMult.Enabled = false;
						this.rbSpace.Enabled = false;
						this.rbSpace2.Enabled = false;
						this.rbSpace3.Enabled = false;
						this.rbSpace4.Enabled = false;
						this.cbLanguage.Enabled = false;
						this.cbUseDate.Enabled = false;
						this.cbUseVVN.Enabled = false;
						this.rbReportNumber.Enabled = false;
						this.rbFixedText.Enabled = false;
						this.tbFixedText.Enabled = false;
						this.lbDefDocTitles.Enabled = false;
						this.lbMeasures.Enabled = false;
						this.dataGrid.Enabled = false;
						this.btnAddLine.Enabled = false;
						this.btnInsertLine.Enabled = false;
						this.btnDeleteLine.Enabled = false;
						this.btnMoveUp.Enabled = false;
						this.btnMoveDown.Enabled = false;
						this.btnView.Enabled = false;
						this.btnClear.Enabled = false;
						this.btnSaveWithName.Enabled = false;
						this.btnUpdate.Enabled = false;
						this.btnAttach.Enabled = false;
						break;
					}
			}
		}

		private string GetCaption(string sDocTypeCode, string sCPName)
		{
			//			string sCaption = "";
			//			if (docTypeCode == DocTypeCode.MDX)
			//				sCaption = " - MDX Document, ";
			//			if (docTypeCode == DocTypeCode.FDX)
			//				sCaption = " - FDX Document, ";
			//			if (docTypeCode == DocTypeCode.IDX)
			//				sCaption = " - IDX Document, ";
			//			sCaption += sCPName;
			string sCaption = String.Format(" - {0}, {1}", sDocTypeCode, sCPName);
			return sCaption;
		}

		private void CommonInit()
		{
			InitLanguage();
			InitImpExInfo();
			InitDocuments();
			string sReportName = GetReportName();//Procedure dbo.spGetDocumentTypeReportFileName
			InitCorelFiles(sReportName);
			InitMeasures();//Procedure dbo.spGetMeasuresWithAdditional
			InitPartTree(this.sItemTypeID);//Procedures dbo.spGetMeasuresByItemType, dbo.spGetPartsByItemType

			InitItemPicture(sPath2Picture);
			string sDocumentLanguageID = "0";
			if (this.cbLanguage.SelectedValue != null)
				sDocumentLanguageID = this.cbLanguage.SelectedValue.ToString();
			InitDefDocTitles(sDocumentLanguageID);//Procedure dbo.spGetDefaultDocumentTitle
			InitTitlesValues();
			if (!IsLoadDocuments)
			{
				string s = this.cbDocuments.SelectedValue.ToString();
				string[] sIDs = s.Split('_');
				sDocumentID = sIDs[0];

				if (sDocumentID.Length != 0)
				{
					ReInitDocument(sDocumentID);
				}
			}
		}

		private void InitImpExInfo()
		{
			DataSet dsImpEx = Service.GetImpExpInfo(sCPOfficeID);
			if (dsImpEx != null)
			{
				this.cbFTPimport.DataSource = dsImpEx.Tables[0];
				this.cbFTPimport.DisplayMember = "Name";
				this.cbFTPimport.ValueMember = "ImportID_nOrder";
				this.cbFTPExport.DataSource = dsImpEx.Tables[1];
				this.cbFTPExport.DisplayMember = "Name";
				this.cbFTPExport.ValueMember = "ExportID_nOrder";
				this.cbExportFormat.DataSource = dsImpEx.Tables[2];
				this.cbExportFormat.DisplayMember = "Format";
				this.cbExportFormat.ValueMember = "FormatID";
			}
		}
		private DataSet InitDocuments()
		{
			//string sDocumentTypeCode = GetDocTypeCodeString(this.docTypeCode);
			DataSet dsDocOperations = Service.GetDocumentsPredefined(this.sItemTypeID, sDocTypeCode);//Procedure dbo.spGetDocumentsPredefined

			if (dsDocOperations != null)
			{
				DataView dvDocOperations = new DataView(dsDocOperations.Tables[0]);

				DataRow newRow = dvDocOperations.Table.NewRow();
				newRow["DocumentName"] = "none";
				newRow["DocumentID_OperationTypeOfficeID_OperationTypeID"] = DBNull.Value;
				//newRow["DocumentID"] = DBNull.Value;
				dvDocOperations.Table.Rows.Add(newRow);

				this.IsLoadDocuments = true;
				this.cbDocuments.DataSource = dvDocOperations;
				this.cbDocuments.ValueMember = "DocumentID_OperationTypeOfficeID_OperationTypeID";
				this.cbDocuments.DisplayMember = "DocumentName";

				if (this.sOperationTypeID.IndexOf('_') > 0)
				{
					sOperationTypeID = sOperationTypeID.Substring(sOperationTypeID.IndexOf('_') + 1).Trim();
					DataView dvOperationTypeID = new DataView(dsDocOperations.Tables[0]);
					dvOperationTypeID.RowFilter = "OperationTypeID = '" + sOperationTypeID + "'";
					if (dvOperationTypeID.Count > 0) this.cbDocuments.SelectedValue = dvOperationTypeID[0]["DocumentID_OperationTypeOfficeID_OperationTypeID"];
				}
				//this.cbExportFormat.SelectedValue = 

				//this.cbDocuments.SelectedValue = DBNull.Value;
				this.IsLoadDocuments = false;
				this.IsLoadImPExpInfo = false;
				this.IsUpdateImPExpInfo = false;
			}
			return dsDocOperations;
		}

		/*
		private void InitCorelFiles()
		{
			try
			{
				string sCorelReportsPath = gemoDream.Service.GetCorelReportsPath();
				DataSet dsCorelReports = gemoDream.Service.GetFileList(sCorelReportsPath);
				this.lbCorelFiles.DataSource = dsCorelReports;
				this.lbCorelFiles.ValueMember = "output";
				this.lbCorelFiles.DisplayMember = "output";
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Can't load corel files. Reason: " + ex.ToString(),
					"Internal error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
		*/

		//		private string GetReportName(DataSet dsDocumentType, string sDocTypeCode)
		//		{
		//			string sFilter = String.Format("DocumentTypeCode={0}", sDocTypeCode);
		//			DataRow[] rows = dsDocumentType.Tables[0].Select(sFilter);
		//			string sReport = rows[0]["DocumentTypeReport"].ToString();
		//			return sReport;
		//		}

		private string GetReportName()
		{
			return Service.GetDocumentTypeReportFileName(sDocTypeCode);
		}

		private string GetOriginalReportName(ArrayList lstFileNames, string sReportName)
		{
			string sReportNameOriginal = null;
			for (int i = 0; i < lstFileNames.Count; i++)
			{
				FileName fileName = (FileName)lstFileNames[i];
				if (fileName.Text.ToUpper().Equals(sReportName.ToUpper()))
				{
					sReportNameOriginal = fileName.Text;
					//break;
				}
			}

			//If file doesn't exist showing the filename with (Doesn't exist!) mark
			//By _3ter on 2006.06.07
			if (sReportNameOriginal == null && lbCorelFiles.FindString(sReportName + " (Doesn't exist!)", -1) < 0)
			{
				lstFileNames.Add(new FileName(sReportName + " (Doesn't exist!)"));
				sReportNameOriginal = sReportName + " (Doesn't exist!)";
				lbCorelFiles.DataSource = null;
				lbCorelFiles.DataSource = lstFileNames;
			}

			return sReportNameOriginal;
		}

		private void InitCorelFiles(string sReportName)
		{
			try
			{
				string sCorelFilesPath = Service.GetCorelReportsPath();
				string sReportFilePath = Service.GetCRTemplatePath();
				if (!Directory.Exists(sCorelFilesPath))
				{
					string sMsg = String.Format("Can't load corel files. Directory {0} is not exists or access denied. Please, check the directory.",
						sCorelFilesPath);

					MessageBox.Show(this, sMsg, "Directory isn't exists",
						MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
				if (!Directory.Exists(sReportFilePath))
				{
					string sMsg = String.Format("Can't load corel files. Directory {0} is not exists or access denied. Please, check the directory.",
						sReportFilePath);

					MessageBox.Show(this, sMsg, "Directory isn't exists",
						MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				ArrayList lstFileNames = Service.GetFileList(sCorelFilesPath);
				//ArrayList lstFileNamesCDR = GetFileListRPT(sReportFilePath);
				//lstFileNames.AddRange(lstFileNamesCDR);
				string sReportNameOriginal = GetOriginalReportName(lstFileNames, sReportName);

				this.lbCorelFiles.DataSource = lstFileNames;
				this.lbCorelFiles.ValueMember = "Text";
				this.lbCorelFiles.DisplayMember = "Text";

				if (sReportNameOriginal != null)
					this.lbCorelFiles.SelectedValue = sReportNameOriginal;
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Can't load corel files. Reason: " + ex.ToString(),
					"Internal error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private ArrayList GetFileListRPT(string sPath)
		{
			DirectoryInfo di = new DirectoryInfo(sPath);
			FileInfo[] fi = di.GetFiles();
			ArrayList fileNames = new ArrayList();
			foreach (FileInfo fiTemp in fi)
			{
				if (fiTemp.Extension.Equals(".rpt"))
				{
					fileNames.Add(new FileName(fiTemp.Name));
				}
			}

			return fileNames;
		}

		private void InitPartTree(string sItemTypeID)
		{
			dsParts = new DataSet();
			DataTable dtMeasureType = Service.GetMeasuresByItemType(sItemTypeID);//tblName : MeasuresByItemType / 1 - empty	/procedure spGetMeasuresByItemType
			dtMeasureType.TableName = "Measures";

			dsParts.Tables.Add(dtMeasureType);      //tblName : Measures

			dsParts.Tables.Add(Service.GetParts(sItemTypeID));  //tblName : Parts	/Procedure dbo.spGetPartsByItemType
			dsParts.Tables.Add(Service.GetPartsStruct());   //tblName : SetParts

			//gemoDream.Service.debug_DiaspalyDataSet(dsParts);

			this.ptItemStructure.Initialize(dsParts.Tables["Parts"]);
			this.ptItemStructure.ExpandTree();

			//this.ptItemStructure.SelectedNode = this.ptItemStructure.tvPartTree.TopNode;
		}

		private void InitLanguage()
		{
			try
			{
				this.bInitLanguage = true;
				DataSet ds = Service.GetDocumentLanguage();
				DataView dvLanguage = new DataView(ds.Tables[0]);
				dvLanguage.Sort = "Name";

				this.cbLanguage.DataSource = dvLanguage;
				this.cbLanguage.ValueMember = "DocumentLanguageID";
				this.cbLanguage.DisplayMember = "Name";

				this.cbLanguage.SelectedItem = "English";
				this.bInitLanguage = false;
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Can't init document language. Reason: " + ex.ToString(),
					"Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			//this.cbLanguage.SelectedIndex = 0;
		}

		private void InitMeasures()
		{
			DataSet dsMeasures = Service.GetMeasuresWithAdditional();

#if DEBUG
			// For debugging only			
			string filename = Service.sTempDir + "/myXmlDocMeasureFromDataSet.xml";
			if (File.Exists(filename)) File.Delete(filename);
			// Create the FileStream to write with.
			System.IO.FileStream myFileStream = new System.IO.FileStream(filename, System.IO.FileMode.Create);
			// Create an XmlTextWriter with the fileStream.
			System.Xml.XmlTextWriter myXmlWriter = new System.Xml.XmlTextWriter(myFileStream, System.Text.Encoding.Unicode);
			// Write to the file with the WriteXml method.
			dsMeasures.WriteXml(myXmlWriter);
			myXmlWriter.Close();
			// End of debugging part
#endif


			//gemoDream.Service.debug_DiaspalyDataSet(dsMeasures);
			//			DataRow row = dsMeasures.Tables[0].NewRow();
			//			row["PartTypeID"] = "-1";
			//			row["MeasureID"] = "-1";
			//			row["MeasureTitle"] = "ReportNumber";
			//			dsMeasures.Tables[0].Rows.Add(row);
			//
			//			row = dsMeasures.Tables[0].NewRow();
			//			row["PartTypeID"] = "-1";
			//			row["MeasureID"] = "-2";
			//			row["MeasureTitle"] = "FullShapeName";
			//			dsMeasures.Tables[0].Rows.Add(row);


			dvMeasures = new DataView(dsMeasures.Tables[0]);
			dvMeasures.RowFilter = "1=0";
			dvMeasures.Sort = "MeasureTitle";
#if DEBUG
			// For debugging only			
			filename = Service.sTempDir + "/myXmlDocMeasurefromView.xml";
			if (File.Exists(filename)) File.Delete(filename);
			// Create the FileStream to write with.
			myFileStream = new System.IO.FileStream(filename, System.IO.FileMode.Create);
			// Create an XmlTextWriter with the fileStream.
			myXmlWriter = new System.Xml.XmlTextWriter(myFileStream, System.Text.Encoding.Unicode);
			// Write to the file with the WriteXml method.
			dvMeasures.Table.DataSet.WriteXml(myXmlWriter);
			myXmlWriter.Close();
			// End of debugging part
#endif

			//			DataRowView row1 = dvMeasures.AddNew();
			//			row1["MeasureID"] = "-1";
			//			row1["MeasureTitle"] = "ReportNumber";

			//			DataRowView row2 = dvMeasures.AddNew();
			//			row2["MeasureID"] = "-2";
			//			row2["MeasureTitle"] = "FullShapeName";

			this.lbMeasures.DataSource = dvMeasures;
			this.lbMeasures.ValueMember = "MeasureID";
			this.lbMeasures.DisplayMember = "MeasureTitle";
		}

		private void InitItemPicture(string sPath2Picture)
		{
			string pathToShape = Client.GetOfficeDirPath("iconDir") + sPath2Picture;
			if (File.Exists(pathToShape))
			{
				Image im = System.Drawing.Image.FromFile(pathToShape);
				if (im != null)
					this.pbItemPicture.Image = im;
				Service.DrawAdjustShapeImage(this.pbItemPicture, im);
			}


			//MessageBox.Show("There is no picture in specified location",
			//	"Picture not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);

		}

		private void InitDefDocTitles(string sDocumentLanguageID)
		{
			DataSet dsDefDocTitles = Service.GetDefDocTitles(sDocumentLanguageID);
			DataView dvDefDocTitles = new DataView(dsDefDocTitles.Tables[0]);
			//this.dvDefDocTitles.RowFilter = "DocumentLanguageID = " + sDocumentLanguageID;

			this.lbDefDocTitles.DataSource = dvDefDocTitles;
			this.lbDefDocTitles.ValueMember = "TitleCode";
			this.lbDefDocTitles.DisplayMember = "TitleName";
		}

		private void InitTitlesValuesDataGrid(DataSet dsValues)
		{
			string[] columnNames = new string[]
				{
					"Title", "Value", "Unit"
				};
			string[] headerText = new string[]
				{
					"Title", "Value", "Unit"
				};
			int[] columnWidth = new int[]
				{
					100, 815, 40
				};

			DataGridTableStyle tableStyle = new DataGridTableStyle();
			tableStyle.MappingName = dsValues.Tables[0].TableName;
			//this.ds.Tables[0].TableName;

			for (int i = 0; i < columnNames.Length; i++)
			{
				DataGridTextBoxColumn tbColumn = new DataGridTextBoxColumn();

				tbColumn.MappingName = columnNames[i];
				tbColumn.HeaderText = headerText[i];
				tbColumn.Width = columnWidth[i];

				tableStyle.GridColumnStyles.Add(tbColumn);
				tableStyle.AllowSorting = false;
			}

			this.dataGrid.TableStyles.Clear();
			this.dataGrid.TableStyles.Add(tableStyle);
		}

		private void InitTitlesValues()
		{
			this.ds = new DataSet();
			ds.Tables.Add("DocumentValue");
			ds.Tables[0].Columns.Add("Title", System.Type.GetType("System.String"));
			ds.Tables[0].Columns.Add("Value", System.Type.GetType("System.String"));
			ds.Tables[0].Columns.Add("Unit", System.Type.GetType("System.String"));

			this.dataGrid.DataSource = ds;
			ds.Tables[0].DefaultView.AllowNew = false;
			this.InitTitlesValuesDataGrid(ds);
			this.dataGrid.SetDataBinding(ds.Tables[0].DefaultView, "");
			//this.dataGrid.SetDataBinding(ds, ds.Tables[0].TableName);
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DefineDocumentForm));
			this.lbDefDocTitles = new System.Windows.Forms.ListBox();
			this.btnView = new System.Windows.Forms.Button();
			this.btnSaveWithName = new System.Windows.Forms.Button();
			this.btnClear = new System.Windows.Forms.Button();
			this.btnAttach = new System.Windows.Forms.Button();
			this.btnMoveDown = new System.Windows.Forms.Button();
			this.btnMoveUp = new System.Windows.Forms.Button();
			this.btnDeleteLine = new System.Windows.Forms.Button();
			this.btnAddLine = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.tbFixedText = new System.Windows.Forms.TextBox();
			this.rbFixedText = new System.Windows.Forms.RadioButton();
			this.rbReportNumber = new System.Windows.Forms.RadioButton();
			this.cbUseVVN = new System.Windows.Forms.CheckBox();
			this.cbUseDate = new System.Windows.Forms.CheckBox();
			this.cbDocuments = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lbMeasures = new System.Windows.Forms.ListBox();
			this.dataGrid = new System.Windows.Forms.DataGrid();
			this.cbLanguage = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.rbSlash = new System.Windows.Forms.RadioButton();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.rbSpace4 = new System.Windows.Forms.RadioButton();
			this.rbSpace3 = new System.Windows.Forms.RadioButton();
			this.rbSpace2 = new System.Windows.Forms.RadioButton();
			this.rbSpace = new System.Windows.Forms.RadioButton();
			this.rbMult = new System.Windows.Forms.RadioButton();
			this.rbX = new System.Windows.Forms.RadioButton();
			this.pbItemPicture = new System.Windows.Forms.PictureBox();
			this.btnUpdate = new System.Windows.Forms.Button();
			this.btnInsertLine = new System.Windows.Forms.Button();
			this.lbCorelFiles = new System.Windows.Forms.ListBox();
			this.cbFTPimport = new System.Windows.Forms.ComboBox();
			this.cbFTPExport = new System.Windows.Forms.ComboBox();
			this.cbExportFormat = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.ptItemStructure = new Cntrls.PartTreeEx1();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbItemPicture)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// lbDefDocTitles
			// 
			this.lbDefDocTitles.Location = new System.Drawing.Point(855, 10);
			this.lbDefDocTitles.Name = "lbDefDocTitles";
			this.lbDefDocTitles.Size = new System.Drawing.Size(160, 225);
			this.lbDefDocTitles.TabIndex = 4;
			this.lbDefDocTitles.DoubleClick += new System.EventHandler(this.lbDefDocTitles_DoubleClick);
			// 
			// btnView
			// 
			this.btnView.Location = new System.Drawing.Point(94, 46);
			this.btnView.Name = "btnView";
			this.btnView.Size = new System.Drawing.Size(75, 23);
			this.btnView.TabIndex = 15;
			this.btnView.Text = "View";
			this.btnView.Click += new System.EventHandler(this.btnView_Click);
			// 
			// btnSaveWithName
			// 
			this.btnSaveWithName.Location = new System.Drawing.Point(773, 687);
			this.btnSaveWithName.Name = "btnSaveWithName";
			this.btnSaveWithName.Size = new System.Drawing.Size(100, 23);
			this.btnSaveWithName.TabIndex = 17;
			this.btnSaveWithName.Text = "Save With Name...";
			this.btnSaveWithName.Click += new System.EventHandler(this.btnSaveWithName_Click);
			// 
			// btnClear
			// 
			this.btnClear.Location = new System.Drawing.Point(885, 719);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(55, 23);
			this.btnClear.TabIndex = 16;
			this.btnClear.Text = "Clear";
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// btnAttach
			// 
			this.btnAttach.Location = new System.Drawing.Point(945, 687);
			this.btnAttach.Name = "btnAttach";
			this.btnAttach.Size = new System.Drawing.Size(60, 23);
			this.btnAttach.TabIndex = 18;
			this.btnAttach.Text = "Attach";
			this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);
			// 
			// btnMoveDown
			// 
			this.btnMoveDown.Location = new System.Drawing.Point(290, 719);
			this.btnMoveDown.Name = "btnMoveDown";
			this.btnMoveDown.Size = new System.Drawing.Size(75, 23);
			this.btnMoveDown.TabIndex = 14;
			this.btnMoveDown.Text = "Move Down";
			this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
			// 
			// btnMoveUp
			// 
			this.btnMoveUp.Location = new System.Drawing.Point(290, 687);
			this.btnMoveUp.Name = "btnMoveUp";
			this.btnMoveUp.Size = new System.Drawing.Size(75, 23);
			this.btnMoveUp.TabIndex = 13;
			this.btnMoveUp.Text = "Move Up";
			this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
			// 
			// btnDeleteLine
			// 
			this.btnDeleteLine.Location = new System.Drawing.Point(375, 687);
			this.btnDeleteLine.Name = "btnDeleteLine";
			this.btnDeleteLine.Size = new System.Drawing.Size(70, 23);
			this.btnDeleteLine.TabIndex = 12;
			this.btnDeleteLine.Text = "Delete Line";
			this.btnDeleteLine.Click += new System.EventHandler(this.btnDeleteLine_Click);
			// 
			// btnAddLine
			// 
			this.btnAddLine.Location = new System.Drawing.Point(455, 687);
			this.btnAddLine.Name = "btnAddLine";
			this.btnAddLine.Size = new System.Drawing.Size(65, 23);
			this.btnAddLine.TabIndex = 11;
			this.btnAddLine.Text = "Add Line";
			this.btnAddLine.Click += new System.EventHandler(this.btnAddLine_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.groupBox2);
			this.groupBox1.Controls.Add(this.cbUseVVN);
			this.groupBox1.Controls.Add(this.cbUseDate);
			this.groupBox1.Location = new System.Drawing.Point(150, 590);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(210, 105);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Misc";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.tbFixedText);
			this.groupBox2.Controls.Add(this.rbFixedText);
			this.groupBox2.Controls.Add(this.rbReportNumber);
			this.groupBox2.Controls.Add(this.btnView);
			this.groupBox2.Location = new System.Drawing.Point(10, 40);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(192, 65);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Bar-Code";
			// 
			// tbFixedText
			// 
			this.tbFixedText.Enabled = false;
			this.tbFixedText.Location = new System.Drawing.Point(88, 40);
			this.tbFixedText.Name = "tbFixedText";
			this.tbFixedText.Size = new System.Drawing.Size(96, 20);
			this.tbFixedText.TabIndex = 2;
			// 
			// rbFixedText
			// 
			this.rbFixedText.Location = new System.Drawing.Point(8, 40);
			this.rbFixedText.Name = "rbFixedText";
			this.rbFixedText.Size = new System.Drawing.Size(96, 24);
			this.rbFixedText.TabIndex = 1;
			this.rbFixedText.Text = "Fixed Text:";
			this.rbFixedText.CheckedChanged += new System.EventHandler(this.rbFixedText_CheckedChanged);
			// 
			// rbReportNumber
			// 
			this.rbReportNumber.Checked = true;
			this.rbReportNumber.Location = new System.Drawing.Point(8, 16);
			this.rbReportNumber.Name = "rbReportNumber";
			this.rbReportNumber.Size = new System.Drawing.Size(104, 24);
			this.rbReportNumber.TabIndex = 0;
			this.rbReportNumber.TabStop = true;
			this.rbReportNumber.Text = "ReportNumber";
			this.rbReportNumber.CheckedChanged += new System.EventHandler(this.rbReportNumber_CheckedChanged);
			// 
			// cbUseVVN
			// 
			this.cbUseVVN.Checked = true;
			this.cbUseVVN.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbUseVVN.Location = new System.Drawing.Point(95, 16);
			this.cbUseVVN.Name = "cbUseVVN";
			this.cbUseVVN.Size = new System.Drawing.Size(84, 24);
			this.cbUseVVN.TabIndex = 1;
			this.cbUseVVN.Text = "VV Number";
			// 
			// cbUseDate
			// 
			this.cbUseDate.Checked = true;
			this.cbUseDate.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbUseDate.Location = new System.Drawing.Point(16, 16);
			this.cbUseDate.Name = "cbUseDate";
			this.cbUseDate.Size = new System.Drawing.Size(48, 24);
			this.cbUseDate.TabIndex = 0;
			this.cbUseDate.Text = "Date";
			// 
			// cbDocuments
			// 
			this.cbDocuments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbDocuments.Location = new System.Drawing.Point(75, 4);
			this.cbDocuments.Name = "cbDocuments";
			this.cbDocuments.Size = new System.Drawing.Size(269, 21);
			this.cbDocuments.TabIndex = 1;
			this.cbDocuments.SelectedValueChanged += new System.EventHandler(this.cbDocuments_SelectedValueChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(10, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(126, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Documents";
			// 
			// lbMeasures
			// 
			this.lbMeasures.Location = new System.Drawing.Point(685, 10);
			this.lbMeasures.Name = "lbMeasures";
			this.lbMeasures.Size = new System.Drawing.Size(168, 225);
			this.lbMeasures.TabIndex = 9;
			this.lbMeasures.DoubleClick += new System.EventHandler(this.lbMeasures_DoubleClick);
			// 
			// dataGrid
			// 
			this.dataGrid.AllowSorting = false;
			this.dataGrid.CaptionVisible = false;
			this.dataGrid.DataMember = "";
			this.dataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid.Location = new System.Drawing.Point(5, 240);
			this.dataGrid.Name = "dataGrid";
			this.dataGrid.Size = new System.Drawing.Size(1010, 445);
			this.dataGrid.TabIndex = 10;
			// 
			// cbLanguage
			// 
			this.cbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbLanguage.Location = new System.Drawing.Point(85, 695);
			this.cbLanguage.Name = "cbLanguage";
			this.cbLanguage.Size = new System.Drawing.Size(125, 21);
			this.cbLanguage.TabIndex = 6;
			this.cbLanguage.SelectedValueChanged += new System.EventHandler(this.cbLanguage_SelectedValueChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(25, 700);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 16);
			this.label2.TabIndex = 5;
			this.label2.Text = "Language";
			// 
			// rbSlash
			// 
			this.rbSlash.Checked = true;
			this.rbSlash.Location = new System.Drawing.Point(8, 16);
			this.rbSlash.Name = "rbSlash";
			this.rbSlash.Size = new System.Drawing.Size(72, 20);
			this.rbSlash.TabIndex = 0;
			this.rbSlash.TabStop = true;
			this.rbSlash.Text = "/";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.rbSpace4);
			this.groupBox3.Controls.Add(this.rbSpace3);
			this.groupBox3.Controls.Add(this.rbSpace2);
			this.groupBox3.Controls.Add(this.rbSpace);
			this.groupBox3.Controls.Add(this.rbMult);
			this.groupBox3.Controls.Add(this.rbX);
			this.groupBox3.Controls.Add(this.rbSlash);
			this.groupBox3.Location = new System.Drawing.Point(10, 585);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(135, 100);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Separator";
			// 
			// rbSpace4
			// 
			this.rbSpace4.Location = new System.Drawing.Point(65, 50);
			this.rbSpace4.Name = "rbSpace4";
			this.rbSpace4.Size = new System.Drawing.Size(72, 20);
			this.rbSpace4.TabIndex = 6;
			this.rbSpace4.Text = "Space x 4";
			// 
			// rbSpace3
			// 
			this.rbSpace3.Location = new System.Drawing.Point(65, 30);
			this.rbSpace3.Name = "rbSpace3";
			this.rbSpace3.Size = new System.Drawing.Size(72, 20);
			this.rbSpace3.TabIndex = 5;
			this.rbSpace3.Text = "Space x 3";
			// 
			// rbSpace2
			// 
			this.rbSpace2.Location = new System.Drawing.Point(65, 10);
			this.rbSpace2.Name = "rbSpace2";
			this.rbSpace2.Size = new System.Drawing.Size(72, 20);
			this.rbSpace2.TabIndex = 4;
			this.rbSpace2.Text = "Space x 2";
			// 
			// rbSpace
			// 
			this.rbSpace.Location = new System.Drawing.Point(8, 76);
			this.rbSpace.Name = "rbSpace";
			this.rbSpace.Size = new System.Drawing.Size(72, 20);
			this.rbSpace.TabIndex = 3;
			this.rbSpace.Text = "Space";
			// 
			// rbMult
			// 
			this.rbMult.Location = new System.Drawing.Point(8, 56);
			this.rbMult.Name = "rbMult";
			this.rbMult.Size = new System.Drawing.Size(72, 20);
			this.rbMult.TabIndex = 2;
			this.rbMult.Text = "*";
			// 
			// rbX
			// 
			this.rbX.Location = new System.Drawing.Point(8, 36);
			this.rbX.Name = "rbX";
			this.rbX.Size = new System.Drawing.Size(72, 20);
			this.rbX.TabIndex = 1;
			this.rbX.Text = "x";
			// 
			// pbItemPicture
			// 
			this.pbItemPicture.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbItemPicture.BackgroundImage")));
			this.pbItemPicture.Location = new System.Drawing.Point(254, 58);
			this.pbItemPicture.Name = "pbItemPicture";
			this.pbItemPicture.Size = new System.Drawing.Size(111, 107);
			this.pbItemPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pbItemPicture.TabIndex = 45;
			this.pbItemPicture.TabStop = false;
			this.pbItemPicture.Paint += new System.Windows.Forms.PaintEventHandler(this.pbItemPicture_Paint);
			// 
			// btnUpdate
			// 
			this.btnUpdate.Location = new System.Drawing.Point(879, 687);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(60, 23);
			this.btnUpdate.TabIndex = 46;
			this.btnUpdate.Text = "Update";
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// btnInsertLine
			// 
			this.btnInsertLine.Location = new System.Drawing.Point(375, 719);
			this.btnInsertLine.Name = "btnInsertLine";
			this.btnInsertLine.Size = new System.Drawing.Size(70, 23);
			this.btnInsertLine.TabIndex = 47;
			this.btnInsertLine.Text = "Insert Line";
			this.btnInsertLine.Click += new System.EventHandler(this.btnInsertLine_Click);
			// 
			// lbCorelFiles
			// 
			this.lbCorelFiles.Location = new System.Drawing.Point(394, 10);
			this.lbCorelFiles.Name = "lbCorelFiles";
			this.lbCorelFiles.Size = new System.Drawing.Size(269, 225);
			this.lbCorelFiles.TabIndex = 48;
			this.lbCorelFiles.DoubleClick += new System.EventHandler(this.lbCorelFiles_DoubleClick);
			// 
			// cbFTPimport
			// 
			this.cbFTPimport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbFTPimport.Location = new System.Drawing.Point(375, 625);
			this.cbFTPimport.Name = "cbFTPimport";
			this.cbFTPimport.Size = new System.Drawing.Size(100, 21);
			this.cbFTPimport.TabIndex = 49;
			this.cbFTPimport.SelectedValueChanged += new System.EventHandler(this.cbFTPimport_SelectedValueChanged);
			// 
			// cbFTPExport
			// 
			this.cbFTPExport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbFTPExport.Location = new System.Drawing.Point(500, 625);
			this.cbFTPExport.Name = "cbFTPExport";
			this.cbFTPExport.Size = new System.Drawing.Size(100, 21);
			this.cbFTPExport.TabIndex = 50;
			this.cbFTPExport.SelectedValueChanged += new System.EventHandler(this.cbFTPExport_SelectedValueChanged);
			// 
			// cbExportFormat
			// 
			this.cbExportFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbExportFormat.Location = new System.Drawing.Point(625, 625);
			this.cbExportFormat.Name = "cbExportFormat";
			this.cbExportFormat.Size = new System.Drawing.Size(100, 21);
			this.cbExportFormat.TabIndex = 51;
			this.cbExportFormat.SelectedValueChanged += new System.EventHandler(this.cbExportFormat_SelectedValueChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(375, 600);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(115, 20);
			this.label3.TabIndex = 52;
			this.label3.Text = "Import";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(500, 600);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 20);
			this.label4.TabIndex = 53;
			this.label4.Text = "Export";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(625, 600);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 20);
			this.label5.TabIndex = 54;
			this.label5.Text = "File Format";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(6, 635);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(389, 91);
			this.pictureBox1.TabIndex = 55;
			this.pictureBox1.TabStop = false;
			// 
			// ptItemStructure
			// 
			this.ptItemStructure.Location = new System.Drawing.Point(5, 31);
			this.ptItemStructure.Name = "ptItemStructure";
			this.ptItemStructure.Size = new System.Drawing.Size(243, 203);
			this.ptItemStructure.TabIndex = 7;
			this.ptItemStructure.Changed += new System.EventHandler(this.ptItemStructure_Changed);
			// 
			// DefineDocumentForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1018, 743);
			this.Controls.Add(this.btnInsertLine);
			this.Controls.Add(this.btnMoveDown);
			this.Controls.Add(this.btnMoveUp);
			this.Controls.Add(this.btnDeleteLine);
			this.Controls.Add(this.btnAddLine);
			this.Controls.Add(this.dataGrid);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cbExportFormat);
			this.Controls.Add(this.cbFTPExport);
			this.Controls.Add(this.cbFTPimport);
			this.Controls.Add(this.lbCorelFiles);
			this.Controls.Add(this.btnUpdate);
			this.Controls.Add(this.pbItemPicture);
			this.Controls.Add(this.ptItemStructure);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cbLanguage);
			this.Controls.Add(this.lbMeasures);
			this.Controls.Add(this.lbDefDocTitles);
			this.Controls.Add(this.btnSaveWithName);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.btnAttach);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.cbDocuments);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DefineDocumentForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Define Document";
			this.Load += new System.EventHandler(this.DefineDocumentForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
			this.groupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbItemPicture)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			//string sItemTypeID = "12";
			//string sPath2Picture = "d01.ico";
			//Application.Run(new DefineDocumentForm(sItemTypeID, sPath2Picture));
		}

		/*
		private void ptItemStructure_Changed(object sender, System.EventArgs e)
		{
			string sPartTypeID = this.ptItemStructure.SelectedNode.Tag.ToString();
			string sFilter = "PartTypeID = " + sPartTypeID;
			dvMeasures.RowFilter = sFilter;
			//this.lbMeasures.
		}
		*/

		private void btnAddLine_Click(object sender, System.EventArgs e)
		{
			DataRow newRow = this.ds.Tables[0].NewRow();
			newRow["Title"] = "";
			newRow["Value"] = "";
			newRow["Unit"] = "";
			this.ds.Tables[0].Rows.Add(newRow);
			int iCurrentRow = this.ds.Tables[0].Rows.Count - 1;
			this.dataGrid.CurrentRowIndex = iCurrentRow;
		}

		private void btnInsertLine_Click(object sender, System.EventArgs e)
		{
			int iCurrentRow = this.dataGrid.CurrentRowIndex;

			DataRow newRow = this.ds.Tables[0].NewRow();
			newRow["Title"] = "";
			newRow["Value"] = "";
			newRow["Unit"] = "";
			this.ds.Tables[0].Rows.InsertAt(newRow, iCurrentRow + 1);
			this.dataGrid.CurrentRowIndex = iCurrentRow + 1;
		}

		private void btnDeleteLine_Click(object sender, System.EventArgs e)
		{
			int iCurrent = this.dataGrid.CurrentRowIndex;
			if (iCurrent != -1)
			{
				DataRow row = this.ds.Tables[0].Rows[iCurrent];
				this.ds.Tables[0].Rows.Remove(row);
			}
		}

		private void btnMoveUp_Click(object sender, System.EventArgs e)
		{
			int iCurrent = this.dataGrid.CurrentRowIndex;
			if (iCurrent > 0)
			{
				DataRow drTemp = this.ds.Tables[0].NewRow();
				drTemp["Title"] = this.ds.Tables[0].Rows[iCurrent - 1]["Title"];
				drTemp["Value"] = this.ds.Tables[0].Rows[iCurrent - 1]["Value"];
				drTemp["Unit"] = this.ds.Tables[0].Rows[iCurrent - 1]["Unit"];
				this.ds.Tables[0].Rows[iCurrent - 1]["Title"] = this.ds.Tables[0].Rows[iCurrent]["Title"];
				this.ds.Tables[0].Rows[iCurrent - 1]["Value"] = this.ds.Tables[0].Rows[iCurrent]["Value"];
				this.ds.Tables[0].Rows[iCurrent - 1]["Unit"] = this.ds.Tables[0].Rows[iCurrent]["Unit"];
				this.ds.Tables[0].Rows[iCurrent]["Title"] = drTemp["Title"];
				this.ds.Tables[0].Rows[iCurrent]["Value"] = drTemp["Value"];
				this.ds.Tables[0].Rows[iCurrent]["Unit"] = drTemp["Unit"];
				this.dataGrid.CurrentRowIndex = iCurrent - 1;
				//this.dataGrid.Refresh();
			}
		}

		private void btnMoveDown_Click(object sender, System.EventArgs e)
		{
			int iCurrent = this.dataGrid.CurrentRowIndex;
			if (iCurrent < this.ds.Tables[0].Rows.Count - 1)
			{
				DataRow drTemp = this.ds.Tables[0].NewRow();
				drTemp["Title"] = this.ds.Tables[0].Rows[iCurrent]["Title"];
				drTemp["Value"] = this.ds.Tables[0].Rows[iCurrent]["Value"];
				drTemp["Unit"] = this.ds.Tables[0].Rows[iCurrent]["Unit"];
				this.ds.Tables[0].Rows[iCurrent]["Title"] = this.ds.Tables[0].Rows[iCurrent + 1]["Title"];
				this.ds.Tables[0].Rows[iCurrent]["Value"] = this.ds.Tables[0].Rows[iCurrent + 1]["Value"];
				this.ds.Tables[0].Rows[iCurrent]["Unit"] = this.ds.Tables[0].Rows[iCurrent + 1]["Unit"];
				this.ds.Tables[0].Rows[iCurrent + 1]["Title"] = drTemp["Title"];
				this.ds.Tables[0].Rows[iCurrent + 1]["Value"] = drTemp["Value"];
				this.ds.Tables[0].Rows[iCurrent + 1]["Unit"] = drTemp["Unit"];
				this.dataGrid.CurrentRowIndex = iCurrent + 1;
				//this.dataGrid.Refresh();
			}
		}

		private string GetSeparator()
		{
			string sSeparator = "";
			if (this.rbSlash.Checked == true)
				sSeparator = "/";
			if (this.rbX.Checked == true)
				sSeparator = "x";
			if (this.rbMult.Checked == true)
				sSeparator = "*";
			if (this.rbSpace.Checked == true)
				sSeparator = " ";
			if (this.rbSpace2.Checked == true)
				sSeparator = "  ";
			if (this.rbSpace3.Checked == true)
				sSeparator = "   ";
			if (this.rbSpace4.Checked == true)
				sSeparator = "    ";
			return sSeparator;
		}

		private void lbMeasures_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			;
		}


		private int GetCurrentRowIndex()
		{
			int i = 0;
			foreach (Control ctrl in this.dataGrid.Controls)
			{
				MessageBox.Show(ctrl.GetType().ToString());
				//if (ctrl.Focused)
				//return i;
				i++;
			}
			return i;
		}

		private void lbMeasures_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
				/*
				DataGridCell cell = this.dataGrid.CurrentCell;
				object obj = this.dataGrid[cell];
				string s = obj.ToString();
				MessageBox.Show(s);
				*/

				int iCurrent = this.dataGrid.CurrentRowIndex;

				//int iCurrent = GetCurrentRowIndex();

				if (iCurrent == -1)
				{
					this.btnAddLine_Click(null, null);

					iCurrent = 0;
				}

				string sOld = this.ds.Tables[0].Rows[iCurrent]["Value"].ToString();
				DataRowView row = (DataRowView)this.lbMeasures.SelectedItem;
				string sMeasure = (string)row["MeasureTitle"];

				string sPartType = this.ptItemStructure.tvPartTree.SelectedNode.Text;
				string sNewPart = null;
				if (sOld.Length == 0)
				{
					sNewPart = String.Format("[{0}.{1}]", sPartType, sMeasure);
				}
				else
				{
					string sSeparator = GetSeparator();
					if (!sSeparator.StartsWith(" "))
						sNewPart = String.Format(" {0} [{1}.{2}]", sSeparator, sPartType, sMeasure);
					else
						sNewPart = String.Format("{0}[{1}.{2}]", sSeparator, sPartType, sMeasure);
				}
				sOld += sNewPart;
				this.ds.Tables[0].Rows[iCurrent]["Value"] = sOld;
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Can't add. Reason: " + ex.ToString(),
					"Internal error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void lbDefDocTitles_DoubleClick(object sender, System.EventArgs e)
		{
			if (this.lbDefDocTitles.SelectedItem != null)
			{
				int iCurrent = this.dataGrid.CurrentRowIndex;
				if (iCurrent == -1)
				{
					this.btnAddLine_Click(null, null);
					iCurrent = 0;
				}
				string sOld = this.ds.Tables[0].Rows[iCurrent]["Title"].ToString();
				DataRowView row = (DataRowView)this.lbDefDocTitles.SelectedItem;
				string sTitle = (string)row["TitleName"];
				string sNewTitle = null;
				if (sOld.Length == 0)
				{
					sNewTitle = String.Format(" {0} ", sTitle);
				}
				else
				{
					string sSeparator = GetSeparator();
					sNewTitle = String.Format("{0} {1} ", sSeparator, sTitle);
				}
				sOld += sNewTitle;
				this.ds.Tables[0].Rows[iCurrent]["Title"] = sOld;
			}
		}

		private void btnView_Click(object sender, System.EventArgs e)
		{
			try
			{
				string sPath = System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

				string sTempFileName = "temp.xml";
				string[] sPart = sPath.Split('\\');
				string sLink = "";
				for (int i = 0; i < sPart.Length - 1; i++)
				{
					sLink += sPart[i];
					sLink += "\\";
				}
				sLink += "Temp\\";
				sLink += sTempFileName;

				if (File.Exists(sLink))
					File.Delete(sLink);

				string sItemContainerName = Service.GetItemContainerName(this.sItemTypeID);

				string sPicture = this.sPath2Picture;
				bool UseVVN = this.cbUseVVN.Checked;
				string sBarCode = this.tbFixedText.Text.ToString();
				bool UseDate = this.cbUseDate.Checked;

				//DataSet dsBatches = Service.GetBatchsByCP(sCPID, sCPOfficeID);
				//this.sBat
				//GetShapesByCustomerProgram();
				//DataSet dsShapes = Service.GetShapesByBatchID(sBatchID);
				DataSet dsShapes = new DataSet();

				Service.XMLData xmlData = new Service.XMLData();
				//xmlData.s
				xmlData.sPicture = sPicture;
				xmlData.UseVVN = UseVVN;
				xmlData.sBarCode = sBarCode;
				xmlData.UseDate = UseDate;
				xmlData.sFileName = this.lbCorelFiles.SelectedValue.ToString();
				Service.SaveXML(sLink, sItemContainerName, xmlData, dsShapes, this.ds);

				string sCommand = "iexplore.exe";
				Process pr = Process.Start(sCommand, sLink);
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Can't view XML. Reason: " + ex.ToString(),
					"Internal error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			//pr.WaitForExit();
			//File.Delete(sLink);

		}

		private void Clear()
		{
			this.ptItemStructure.tvPartTree.SelectedNode = this.ptItemStructure.tvPartTree.TopNode;
			this.lbMeasures.SelectedIndex = 0;
			this.cbDocuments.SelectedValue = DBNull.Value;
			this.rbSlash.Checked = true;
			this.cbUseDate.Checked = true;
			this.cbUseVVN.Checked = true;
			this.rbReportNumber.Checked = true;
			this.cbLanguage.SelectedIndex = 0;
			this.lbDefDocTitles.SelectedIndex = 0;
			this.cbFTPExport.SelectedValue = DBNull.Value;
			this.cbFTPimport.SelectedValue = DBNull.Value;
			this.cbExportFormat.SelectedValue = DBNull.Value;
			this.tbFixedText.Text = "";
			this.ds.Clear();
		}

		private void btnClear_Click(object sender, System.EventArgs e)
		{
			Clear();
		}

		private DocumentExistance IsDocumentExist(string sDocumentName, out string sID,
			string sDocTypeCode)
		{
			DataView dvDocuments = (DataView)this.cbDocuments.DataSource;
			string sDocName;
			string sUpperDocumentName = sDocumentName.ToUpper();
			//string sUpperDocumentName = sDocumentName;
			foreach (DataRowView row in dvDocuments)
			{
				sDocName = row["DocumentName"].ToString().ToUpper();
				//sDocName = row["DocumentName"].ToString();
				if (sDocName.Equals(sUpperDocumentName))
				{
					sID = row["DocumentID_OperationTypeOfficeID_OperationTypeID"].ToString();
					//if (this.docTypeCode == docTypeCode)
					if (this.sDocTypeCode.Equals(sDocTypeCode))
						return DocumentExistance.DocumentExistsWithSameType;
					return DocumentExistance.DocumentExistsWithOtherType;
				}
			}
			sID = null;
			return DocumentExistance.DocumentNotExists;
		}

		private int UpdateDoc(string sDocumentID, string sDocumentName)
		{
			try
			{
				string sBarCodeFixedText = this.rbFixedText.Checked == true ? this.tbFixedText.Text.ToString() : "";
				bool bUseDate = this.cbUseDate.Checked;
				bool bUseVVN = this.cbUseVVN.Checked;
				string sCorelFile = lbCorelFiles.SelectedValue.ToString();
				string sFTPExport = this.cbFTPExport.SelectedValue.ToString();
				string sFTPimport = this.cbFTPimport.SelectedValue.ToString();
				string[] sExport = sFTPExport.Split('_');
				string[] sImport = sFTPimport.Split('_');
				Service.UpdateDocument(sDocumentID,
										sDocumentName,
										sBarCodeFixedText,
										bUseDate,
										bUseVVN,
										sCorelFile,
										sExport[0],
										sImport[0],
										this.cbExportFormat.SelectedValue.ToString());

				//check filds Title and Value
				//				foreach(DataRow row in ds.Tables[0].Rows)
				//				{
				//					if(row["Title"].ToString().Equals(""))
				//					{
				//						MessageBox.Show(this, "Select Title", "title error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				//						return -1;
				//					}
				//					/*if(row["Value"].ToString().Equals(""))
				//					{
				//						MessageBox.Show(this, "Select Value", "value error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				//						return -1;
				//					}*/
				//				}

				Service.DeleteDocumentValue(sDocumentID);

				string sTitle;
				string sValue;
				string sUnit;
				foreach (DataRow row in ds.Tables[0].Rows)
				{
					sTitle = row["Title"].ToString();
					sValue = row["Value"].ToString();
					sUnit = row["Unit"].ToString();
					Service.SaveDocumentValue(sDocumentID, sTitle, sValue, sUnit);
				}
				return 0;
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Can't save document. Reason: " + ex.ToString(),
					"Internal error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			return 0;
		}

		private void btnSaveWithName_Click(object sender, System.EventArgs e)
		{
			if (IsFixedTextEntered())
			{
				//string sOperationID = GetOperationID(this.docTypeCode);
				string sDocumentTypeCode = this.sDocTypeCode;
				NewDocumentNameForm newDocNameForm = new NewDocumentNameForm(sDocumentTypeCode);
				DialogResult result = newDocNameForm.ShowDialog(this);
				if (result == DialogResult.OK)
				{
					string sDocumentName = newDocNameForm.GetDocumentName();
					//string sDocTypeName = newDocNameForm.GetDocumentTypeName();
					string sNewDocTypeCode = newDocNameForm.GetDocumentTypeCode();
					//DocTypeCode newDocTypeCode = GetDocTypeCodeEnum(sDocTypeName);
					string sID;
					DocumentExistance dex = IsDocumentExist(sDocumentName, out sID, sNewDocTypeCode);
					if (dex == DocumentExistance.DocumentExistsWithSameType)
					{
						string[] sIDs = sID.Split('_');
						string sDocumentID = sIDs[0];
						DialogResult dr = MessageBox.Show(this,
							"Document with this name already exists. Are you sure you want to override it?",
							"Confirm update", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
						if (dr == DialogResult.Yes)
						{
							//if title or value fields was empty 
							if (UpdateDoc(sDocumentID, sDocumentName) == -1)
							{
								MessageBox.Show(this, "Document wasn't updated.",
									"abort update", MessageBoxButtons.OK, MessageBoxIcon.Error);
								return;
							}

							this.sDocumentID = null;
							this.sDocumentName = null;
							this.sOperationTypeOfficeID_OperationTypeID = null;
							//this.sDocumentID = sDocumentID;
							//this.sDocumentName = sDocumentName;
							//this.sOperationTypeOfficeID_OperationTypeID = sIDs[1] + "_" + sIDs[2];
							this.InitDocuments();
							this.cbDocuments.SelectedValue = sID;
						}
					}
					else
					{
						if (dex == DocumentExistance.DocumentExistsWithOtherType)
						{
							DialogResult dr = MessageBox.Show(this, "Document with this name but another document type already exists. Are you sure you want to create new document?",
								"Confirm creation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
							if (dr == DialogResult.No)
							{
								return;
							}
						}
						string s = SaveDoc(sDocumentName, sNewDocTypeCode);
						if (s.Equals("-1"))
						{
							return;
						}
						if (this.sDocTypeCode.Equals(sNewDocTypeCode))
						//if (this.docTypeCode == newDocTypeCode)
						{
							string[] sIDs = s.Split('_');
							this.sDocumentID = null;
							this.sDocumentName = null;
							this.sOperationTypeOfficeID_OperationTypeID = null;
							//this.sDocumentID = sIDs[0];
							//this.sDocumentName = sDocumentName;
							//this.sOperationTypeOfficeID_OperationTypeID = sIDs[1] + "_" + sIDs[2];
							this.InitDocuments();
							this.cbDocuments.SelectedValue = s;
						}
						else
						{
							this.sDocumentID = null;
							this.sDocumentName = null;
							this.sOperationTypeOfficeID_OperationTypeID = null;
							this.InitDocuments();
							this.cbDocuments.SelectedValue = DBNull.Value;
						}
					}
				}
			}
		}

		public static string GetDocTypeCodeString(DocTypeCode docTypeCode)
		{
			if (docTypeCode == DocTypeCode.MDX)
				return "1";
			if (docTypeCode == DocTypeCode.FDX)
				return "2";
			if (docTypeCode == DocTypeCode.IDX)
				return "3";//IDX
			System.Diagnostics.Trace.Assert(true);
			return "3";
		}

		public static DocTypeCode GetDocTypeCodeEnum(string sDocName)
		{
			if (sDocName.Equals("MDX Document"))
				return DocTypeCode.MDX;
			if (sDocName.Equals("FDX Document"))
				return DocTypeCode.FDX;
			if (sDocName.Equals("IDX Document"))
				return DocTypeCode.IDX;
			System.Diagnostics.Trace.Assert(true);
			return DocTypeCode.IDX;
		}

		public static DocTypeCode GetDocTypeCodeEnumByID(string sID)
		{
			if (sID.Equals("-3_3"))
				return DocTypeCode.MDX;
			if (sID.Equals("-2_2"))
				return DocTypeCode.FDX;
			if (sID.Equals("-2_2"))
				return DocTypeCode.IDX;
			System.Diagnostics.Trace.Assert(true);
			return DocTypeCode.IDX;
		}

		public static string GetOperationID(DocTypeCode docTypeCode)
		{
			if (docTypeCode == DocTypeCode.MDX)
				return "-3_3";
			if (docTypeCode == DocTypeCode.FDX)
				return "-2_2";
			if (docTypeCode == DocTypeCode.IDX)
				return "-1_1";
			System.Diagnostics.Trace.Assert(true);
			return "-1_1";
		}

		private string SaveDocument(string sDocumentName, string sBarCodeFixedText, bool bUseDate, bool bUseVVN,
			string sItemOperationOfficeID, string sItemOperationID,
			string sItemTypeID, string sOperationTypeName, string sDocTypeCode,
			string sCorelFile)
		{
			// spSetDocument
			// @rId varchar(150) output,
			// @DocumentName  varchar(250),
			// @BarCodeFixedText  varchar(2000),
			// @UseDate  dnBool,
			// @UseVirtualVaultNumber  dnBool,
			// @ItemOperationOfficeID  dnTinyID,
			// @ItemOperationID  dnID,
			// @CPOfficeID  dnTinyID,
			// @CPID  dnID,
			// @ItemTypeID  dnSmallID
			// @OperationTypeOfficeID_OperationTypeID 
			//			DataSet dsIn = new DataSet();
			//DataSet dsOut = new DataSet();
			//ds
			//			dsIn.Tables.Add("DocumentTypeOf");
			//			DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);

			//			foreach (DataColumn column in dsOut.Tables[0].Columns)
			//			{
			//				MessageBox.Show(column.ColumnName + " : " + column.DataType.ToString());
			//			}

			DataSet dsOut = new DataSet();
			dsOut.Tables.Add("Document");
			dsOut.Tables[0].Columns.Add("DocumentName", System.Type.GetType("System.String"));
			dsOut.Tables[0].Columns.Add("BarCodeFixedText", System.Type.GetType("System.String"));
			dsOut.Tables[0].Columns.Add("UseDate", System.Type.GetType("System.Int16"));
			dsOut.Tables[0].Columns.Add("UseVirtualVaultNumber", System.Type.GetType("System.Int16"));
			dsOut.Tables[0].Columns.Add("ItemTypeID", System.Type.GetType("System.Decimal"));
			dsOut.Tables[0].Columns.Add("OperationTypeName", System.Type.GetType("System.String"));
			dsOut.Tables[0].Columns.Add("OperationChar", System.Type.GetType("System.String"));
			dsOut.Tables[0].Columns.Add("DocumentTypeCode", System.Type.GetType("System.Decimal"));
			dsOut.Tables[0].Columns.Add("CorelFile", System.Type.GetType("System.String"));
			dsOut.Tables[0].Columns.Add("ExportTypeID", System.Type.GetType("System.Int16"));
			dsOut.Tables[0].Columns.Add("ImportTypeID", System.Type.GetType("System.Int16"));
			dsOut.Tables[0].Columns.Add("FormatTypeID", System.Type.GetType("System.Int16"));

			DataTable table = dsOut.Tables[0];
			table.TableName = "Document";
			table.Rows.Add(new object[] { });
			table.Rows[0]["DocumentName"] = sDocumentName;
			//table.Rows[0]["OperationTypeName"]		= sDocumentName;
			table.Rows[0]["BarCodeFixedText"] = sBarCodeFixedText;
			table.Rows[0]["UseDate"] = bUseDate;
			table.Rows[0]["UseVirtualVaultNumber"] = bUseVVN;
			table.Rows[0]["ItemTypeID"] = sItemTypeID;
			table.Rows[0]["OperationTypeName"] = sOperationTypeName;
			table.Rows[0]["OperationChar"] = "H";
			//string sDocTypeCode = GetDocTypeCodeString(docTypeCode);
			table.Rows[0]["DocumentTypeCode"] = sDocTypeCode;
			table.Rows[0]["CorelFile"] = sCorelFile;
			string sFTPExport = this.cbFTPExport.SelectedValue.ToString();
			string sFTPimport = this.cbFTPimport.SelectedValue.ToString();
			string[] sExport = sFTPExport.Split('_');
			string[] sImport = sFTPimport.Split('_');
			table.Rows[0]["ExportTypeID"] = sExport[0];
			table.Rows[0]["ImportTypeID"] = sImport[0];
			table.Rows[0]["FormatTypeID"] = this.cbExportFormat.SelectedValue;

			dsOut = gemoDream.Service.ProxyGenericSet(dsOut, "Set");
			//gemoDream.Service.debug_DiaspalyDataSet(dsOut);
			string s = dsOut.Tables[0].Rows[0][0].ToString();
			return s;
			////			string sID = dsOut.Tables[0].Rows[0][0].ToString();
			////			string[] sIDs = sID.Split('_');
			////			string sDocumentID = sIDs[0];
			//			if ((sDocumentName != null && sDocumentName.Length != 0) 
			//				)
			//			{
			//				this.sOperationTypeOfficeID_OperationTypeID = null;
			//			}
			//			else
			//			{
			//				string sOperationTypeOfficeID = sIDs[1];
			//				string sOperationTypeID = sIDs[2];
			//				this.sOperationTypeOfficeID_OperationTypeID = String.Format("{0}_{1}", sOperationTypeOfficeID, sOperationTypeID);
			////			}
			//				
			//			return sDocumentID;
		}

		//		private string SaveDocument(string sDocumentName, string sBarCodeFixedText, bool bUseDate, bool bUseVVN,
		//			string sItemOperationOfficeID, string sItemOperationID, string sCPOfficeID, string sCPID,
		//			string sItemTypeID, string sOperationTypeName)
		//		{
		//			// spSetDocument
		//			// @rId varchar(150) output,
		//			// @DocumentName  varchar(250),
		//			// @BarCodeFixedText  varchar(2000),
		//			// @UseDate  dnBool,
		//			// @UseVirtualVaultNumber  dnBool,
		//			// @ItemOperationOfficeID  dnTinyID,
		//			// @ItemOperationID  dnID,
		//			// @CPOfficeID  dnTinyID,
		//			// @CPID  dnID,
		//			// @ItemTypeID  dnSmallID
		//			DataSet dsIn = new DataSet();
		//			dsIn.Tables.Add("DocumentTypeOf");
		//			DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);
		//
		//			foreach (DataColumn column in dsOut.Tables[0].Columns)
		//			{
		//				MessageBox.Show(column.ColumnName + " : " + column.DataType.ToString());
		//			}
		//
		//			DataTable table = dsOut.Tables[0];
		//
		//			table.TableName = "Document";
		//			table.Rows.Add(new object[] {});
		//			table.Rows[0]["OperationTypeName"]			= sDocumentName;
		//			table.Rows[0]["BarCodeFixedText"]		= sBarCodeFixedText;
		//			table.Rows[0]["UseDate"]				= bUseDate;
		//			table.Rows[0]["UseVirtualVaultNumber"]	= bUseVVN;
		//			table.Rows[0]["CPOfficeID"]				= sCPOfficeID;
		//			table.Rows[0]["CPID"]					= sCPID;
		//			table.Rows[0]["ItemTypeID"]				= sItemTypeID;
		//			table.Rows[0]["OperationTypeName"]		= sOperationTypeName;
		//			table.Rows[0]["OperationChar"]			= "H";
		//			
		//			DataSet dsOutA = gemoDream.Service.ProxyGenericSet(dsOut, "Set");
		//			string sID = dsOutA.Tables[0].Rows[0][0].ToString();
		//			string[] sIDs = sID.Split('_');
		//			//gemoDream.Service.debug_DiaspalyDataSet(ds
		//			string sDocumentID = sIDs[0];
		//			if ((sDocumentName != null && sDocumentName.Length != 0) 
		////				|| dsOut.Tables[0].Columns.Count == 1
		//				)
		//			{
		//				this.sOperationTypeOfficeID_OperationTypeID = null;
		//			}
		//			else
		//			{
		//				string sOperationTypeOfficeID = sIDs[1];
		//				string sOperationTypeID = sIDs[2];
		//				this.sOperationTypeOfficeID_OperationTypeID = String.Format("{0}_{1}", sOperationTypeOfficeID, sOperationTypeID);
		//			}
		//
		//			return sDocumentID;
		//		}

		//private string SaveDoc(string sDocumentName, DocTypeCode docTypeCode)
		private string SaveDoc(string sDocumentName, string sDocTypeCode)
		{
			try
			{
				string sBarCodeFixedText = this.rbFixedText.Checked == true ? this.tbFixedText.Text.ToString() : "";
				bool bUseDate = this.cbUseDate.Checked;
				bool bUseVVN = this.cbUseVVN.Checked;
				string sItemOperationOfficeID = "";
				string sItemOperationID = "";
				//string sCPOfficeID = "";
				//string sCPID = "";
				string sItemTypeID = this.sItemTypeID;
				string sCorelFile = this.lbCorelFiles.SelectedValue.ToString();
				//string sDocumentID = "";
				//				if (sCPID == null)
				//				{

				//check filds Titles and Values
				/*foreach(DataRow row in ds.Tables[0].Rows)
				{
					if(row["Title"].ToString().Equals(""))
					{
						MessageBox.Show(this, "Select Title", "title error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return "-1";
					}
					if(row["Value"].ToString().Equals(""))
					{
						MessageBox.Show(this, "Select Value", "value error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return "-1";
					}
				}*/

				string s =
					/*sDocumentID = */ SaveDocument(sDocumentName, sBarCodeFixedText, bUseDate, bUseVVN, sItemOperationOfficeID,
					sItemOperationID, sItemTypeID, this.sOperationTypeName, sDocTypeCode, sCorelFile);
				//				}
				//				else
				//				{
				//					sDocumentID = SaveDocument(sDocumentName, sBarCodeFixedText, bUseDate, bUseVVN, sItemOperationOfficeID,
				//						sItemOperationID, sCPOfficeID, sCPID, sItemTypeID, this.sOperationTypeName);
				//					Service.SetDocument_CP(sDocumentID, sCPOfficeID, sCPID);
				//				}

				string[] sIDs = s.Split('_');
				string sDocumentID = sIDs[0];

				string sTitle;
				string sValue;
				string sUnit;
				foreach (DataRow row in ds.Tables[0].Rows)
				{
					sTitle = row["Title"].ToString();
					sValue = row["Value"].ToString();
					sUnit = row["Unit"].ToString();
					Service.SaveDocumentValue(sDocumentID, sTitle, sValue, sUnit);
				}
				//return sDocumentID;
				return s;
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Can't save document. Reason: " + ex.ToString(),
					"Internal error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			return null;
		}

		private void DisableForm()
		{
			this.btnAttach.Enabled = false;
			this.btnSaveWithName.Enabled = false;
			this.btnUpdate.Enabled = false;
			this.btnClear.Enabled = false;
			this.btnAddLine.Enabled = false;
			this.btnDeleteLine.Enabled = false;
			this.btnMoveDown.Enabled = false;
			this.btnMoveUp.Enabled = false;
			this.btnInsertLine.Enabled = false;
			this.dataGrid.Enabled = false;
		}

		private bool IsFixedTextEntered()
		{
			if (this.rbFixedText.Checked == true &&
				this.tbFixedText.Text.ToString().Length == 0)
			{
				MessageBox.Show(this, "Please, enter a fixed text.", "Empty fixed text",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			return true;
		}

		//		private void btnSave_Click(object sender, System.EventArgs e)
		//		{
		//			if (IsFixedTextEntered())
		//			{
		//				string sDocumentName = null;
		//				this.sDocumentID = SaveDoc(sDocumentName);
		//				MessageBox.Show(this, "Document was successfully saved.", "Information", MessageBoxButtons.OK,
		//					MessageBoxIcon.Information);
		//				DisableForm();
		//			}
		//		}

		private string GetNotVisibleMeasures(string sPartID)
		{
			return null;  // sasha
						  //if (dsNotVCCM != null)
						  //         {
						  //	string sFilter = "NotVisibleInCCM = 1 AND PartID = " + sPartID;
						  //	//gemoDream.Service.debug_DiaspalyDataSet(this.dsNotVCCM);
						  //	DataRow[] rows = this.dsNotVCCM.Tables[0].Select(sFilter);
						  //	string sNotVisibleMeasures = null;
						  //	foreach (DataRow row in rows)
						  //	{
						  //		if (sNotVisibleMeasures != null)
						  //			sNotVisibleMeasures += ",";
						  //		sNotVisibleMeasures += row["MeasureID"].ToString();
						  //	}
						  //	if (sNotVisibleMeasures != null)
						  //		sNotVisibleMeasures += ",";
						  //	sNotVisibleMeasures += "8";
						  //	return sNotVisibleMeasures;
						  //}
						  //else
						  //{
						  //	return null;
						  //}
		}

		private void ptItemStructure_Changed(object sender, System.EventArgs e)
		{
			try
			{
				string sPartTypeID = this.ptItemStructure.SelectedNode.Tag.ToString();

				DataRow[] rows = this.dsParts.Tables["Parts"].Select("PartTypeID = " + sPartTypeID);
				string sPartID = rows[0]["ID"].ToString();

				string sFilter = "PartTypeID IN (" + sPartTypeID + ", -1)";
				string sNotVisibleMeasures = this.GetNotVisibleMeasures(sPartID);
				if (sNotVisibleMeasures != null)
					sFilter += " AND MeasureID NOT IN (" + sNotVisibleMeasures + ")";

				//DataSet ds = new DataSet();
				//ds.Tables.Add(dvMeasures.Table.Copy());
				//gemoDream.Service.debug_DiaspalyDataSet(ds);
				//gemoDream.Service.debug_DiaspalyDataSet(this.dsNotVCCM);

				dvMeasures.RowFilter = sFilter;
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Can't load measures. Reason: " + ex.ToString(),
					"Internal error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}

		}

		private void cbLanguage_SelectedValueChanged(object sender, System.EventArgs e)
		{
			//if (this.cbLanguage.SelectedValue != null)
			if (!this.bInitLanguage)
			{
				//DataRowView row = (DataRowView)this.cbLanguage.SelectedValue;
				//string sDocumentLanguageID = (string)row["DocumentLanguageID"];
				string sDocumentLanguageID = this.cbLanguage.SelectedValue.ToString();
				InitDefDocTitles(sDocumentLanguageID);
			}
		}

		public string GetDocumentID()
		{
			return this.sDocumentID;
		}

		public string GetOperationTypeOfficeID_OperationTypeID()
		{
			return this.sOperationTypeOfficeID_OperationTypeID;
		}

		public string GetDocumentTypeCode()
		{
			return this.sDocTypeCode;
		}

		public static string AddOperation(int iAccessLevel,
											DataSet dsNotVCCM,
											ArrayList newOperationsList,
											string CPOfficeID_CPID,
											IWin32Window parent,
											ComboBox comboBox,
											string sItemTypeID,
											string sPath2Picture,
											string sOperationTypeName,
											string sDocTypeCode,
											string sOperationTypeID,
											string sCPName)
		{
			char separator = '_';
			string sCPOfficeID = null;
			string sCPID = null;
			DefineDocumentForm defDocForm;
			if (CPOfficeID_CPID != null && CPOfficeID_CPID.Length != 0)
			{
				string[] sCPOfficeID_CPID = CPOfficeID_CPID.Split(separator);
				sCPOfficeID = sCPOfficeID_CPID[0];
				sCPID = sCPOfficeID_CPID[1];
				defDocForm = new DefineDocumentForm(iAccessLevel,
													dsNotVCCM,
													sItemTypeID,
													sPath2Picture,
													sOperationTypeName,
													sCPOfficeID,
													sCPID,
													newOperationsList,
													sDocTypeCode,
													sOperationTypeID,
													sCPName);
			}
			else
			{
				defDocForm = new DefineDocumentForm(iAccessLevel,
													dsNotVCCM,
													sItemTypeID,
													sPath2Picture,
													sOperationTypeName,
													sCPOfficeID,
													sCPID,
													newOperationsList,
													sDocTypeCode,
													sOperationTypeID,
													sCPName);
			}

			defDocForm.ShowDialog(parent);
			string sDocumentID = defDocForm.GetDocumentID();
			if (sDocumentID == null)
				return null;

			//iDocumentsCount++;

			string sOperationTypeOfficeID_OperationTypeID = defDocForm.GetOperationTypeOfficeID_OperationTypeID();
			string sDocumentName = defDocForm.GetDocumentName();
			object oDocTypeCode = defDocForm.GetDocumentTypeCode();
			if (sOperationTypeOfficeID_OperationTypeID != null)
			{
				DataView dv = (DataView)comboBox.DataSource;

				/*
				DataSet ds = new DataSet();
				ds.Tables.Add(dv.Table.Copy());

				string sFilter = "OperationTypeOfficeID_OperationTypeID = " + sOperationTypeOfficeID_OperationTypeID;
				DataRow[] rows = ds.Tables[0].Select(sFilter);
				if (rows.Length > 0)
				{
					rows[0]["OperationTypeName"] = sDocumentName;
				}
				else
				{
				*/
				DataRow newRow = dv.Table.NewRow();

				newRow["OperationTypeOfficeID_OperationTypeID"] = sOperationTypeOfficeID_OperationTypeID;
				//newRow["OperationTypeName"] = sOperationTypeName;
				newRow["OperationTypeName"] = sDocumentName;
				newRow["DocumentTypeCode"] = oDocTypeCode;
				//newRow["nOrder"] = ;
				dv.Table.Rows.Add(newRow);
				//}

				//				string[] sOperationTypeOfficeID_OperationTypeIDs = sOperationTypeOfficeID_OperationTypeID.Split(separator);
				//				string sOperationTypeOfficeID = sOperationTypeOfficeID_OperationTypeIDs[1];
				//				string sOperationTypeID = sOperationTypeOfficeID_OperationTypeIDs[0];

				//              DefineDocumentForm.NewOperationData nod = new DefineDocumentForm.NewOperationData();
				//				nod.sDocumentID = sDocumentID;
				//				nod.sCPID = sCPID;
				//				nod.sCPOfficeID = sCPOfficeID;
				//				nod.sOperationTypeID = sOperationTypeID;
				//				nod.sOperationTypeOfficeID = sOperationTypeOfficeID;
				//				newOperationsList.Add(nod);
			}

			return sOperationTypeOfficeID_OperationTypeID;
		}

		private bool CheckOperationExistance(ArrayList newOperationsList, string sDocumentID)
		{
			for (int i = 0; i < newOperationsList.Count; i++)
			{
				DefineDocumentForm.NewOperationData nod = (DefineDocumentForm.NewOperationData)newOperationsList[i];
				if (nod.sDocumentID.Equals(sDocumentID))
				{
					return true;
				}
			}
			return false;
		}

		private void ReInitDocumentsValues(DataSet dsValues)
		{
			dsValues.Tables[0].DefaultView.AllowNew = false;
			this.dataGrid.DataSource = dsValues;
			this.InitTitlesValuesDataGrid(dsValues);
			this.dataGrid.SetDataBinding(dsValues.Tables[0].DefaultView, "");
			//this.dataGrid.SetDataBinding(dsValues, dsValues.Tables[0].TableName);
			this.ds = dsValues;
		}

		private void ReInitDocument(string sDocumentID)
		{
			DataSet dsDoc = Service.GetDocument(sDocumentID);//Procedure dbo.spGetDocument
			DataRow row = dsDoc.Tables[0].Rows[0];

			object obj = row["CorelFile"];
			if (obj == DBNull.Value)
			{
				MessageBox.Show(this, "You've loaded document saved in old format. Corel file field is empty.",
					"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				this.lbCorelFiles.SelectedIndex = 0;
			}
			else
			{
				string sReportName = row["CorelFile"].ToString();
				ArrayList lstFileNames = (ArrayList)this.lbCorelFiles.DataSource;
				//gemoDream.Service.GetFileList(sCorelFilesPath);
				string sReportNameOriginal = GetOriginalReportName(lstFileNames, sReportName);

				if (sReportNameOriginal != null)
				{
					this.lbCorelFiles.SelectedValue = sReportNameOriginal;
					this.cbExportFormat.SelectedValue = row["FormatTypeID"];
					this.cbFTPimport.SelectedValue = row["ImportID_nOrder"];
					this.cbFTPExport.SelectedValue = row["ExportID_nOrder"];
					IsLoadImPExpInfo = true;
				}
				//this.lbCorelFiles.SelectedValue = row["CorelFile"].ToString();
			}

			string sUseDate = row["UseDate"].ToString();
			if (sUseDate.Equals("1"))
				this.cbUseDate.Checked = true;
			else
				this.cbUseDate.Checked = false;

			string sUseVVN = row["UseVirtualVaultNumber"].ToString();
			if (sUseVVN.Equals("1"))
				this.cbUseVVN.Checked = true;
			else
				this.cbUseVVN.Checked = false;

			string sBarCodeFixedText = row["BarCodeFixedText"].ToString();
			if (sBarCodeFixedText.Length != 0)
			{
				this.rbFixedText.Checked = true;
				this.tbFixedText.Text = sBarCodeFixedText;
			}
			else
			{
				this.rbReportNumber.Checked = true;
				this.tbFixedText.Text = "";
			}

			DataSet dsValues = Service.GetDocumentValues(sDocumentID);
			ReInitDocumentsValues(dsValues);
		}

		private void cbDocuments_SelectedValueChanged(object sender, System.EventArgs e)
		{
			//string sDocumentID = this.cbDocuments.SelectedValue.ToString();
			if (!IsLoadDocuments)
			{
				string s = this.cbDocuments.SelectedValue.ToString();
				string[] sIDs = s.Split('_');
				string sDocumentID = sIDs[0];

				if (sDocumentID.Length != 0)
				{
					ReInitDocument(sDocumentID);
				}
			}
		}

		private void pbItemPicture_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			if (pbItemPicture.Image == null) return;
			if (pbItemPicture.Image.Size.Height > pbItemPicture.Size.Height || pbItemPicture.Image.Size.Width > pbItemPicture.Size.Width)
			{
				pbItemPicture.SizeMode = PictureBoxSizeMode.StretchImage;
			}
			else
			{
				pbItemPicture.SizeMode = PictureBoxSizeMode.CenterImage;
			}
		}

		private void rbReportNumber_CheckedChanged(object sender, System.EventArgs e)
		{
			this.tbFixedText.Enabled = false;
		}

		private void rbFixedText_CheckedChanged(object sender, System.EventArgs e)
		{
			this.tbFixedText.Enabled = true;
		}

		private string AttachDoc(string sDocumentID, string sCPID, string sCPOfficeID)
		{
			try
			{
				Service.SetDocument_CP(sDocumentID, sCPOfficeID, sCPID);//Procedure dbo.spSetDocument_CP
			}
			catch (Exception ex)
			{
				if (!ex.Message.Equals("Server was unable to process request. --> Violation of PRIMARY KEY constraint 'PK_tblDocument_CP'. Cannot insert duplicate key in object 'tblDocument_CP'.\nThe statement has been terminated."))
				{
					MessageBox.Show(this, "Can't attach document. Reason: " + ex.ToString(),
						"Internal error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return null;
				}
				else
				{
					//					MessageBox.Show(this, "Document already attached. Please, close the form and select document from the combo box.",
					//						"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return null;
				}
			}
			return sDocumentID;
		}

		private void btnAttach_Click(object sender, System.EventArgs e)
		{
			if (IsFixedTextEntered())
			{
				string s = this.cbDocuments.SelectedValue.ToString();
				string sDocumentName = this.cbDocuments.Text;
				if (s == null || s.Length == 0)
				{
					MessageBox.Show(this, "Document to attach isn't selected. Please, select any document first.",
						"Document isn't selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				string[] sIDs = s.Split('_');
				this.sDocumentID = sIDs[0];
				this.sDocumentName = sDocumentName;
				this.sOperationTypeOfficeID_OperationTypeID = sIDs[1] + "_" + sIDs[2];
				if (this.sCPID != null && this.sCPID.Length != 0)
				{
					if (Service.IsDocumentAttached1(sDocumentID, sCPID, sCPOfficeID))//Procedure dbo.spGetDocument_CP1

					//					if (Service.IsDocumentAttached(sDocumentID, sCPID, sCPOfficeID))
					{
						MessageBox.Show(this, "This document is already attached. Please, choose another document.",
							"Document already attached", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						this.sDocumentID = null;
						this.sDocumentName = sDocumentName;
						this.sOperationTypeOfficeID_OperationTypeID = null;
						return;
					}
					if (IsUpdateImPExpInfo)
					{
						UpdateDoc(sIDs[0], sDocumentName);
					}
					this.sDocumentID = AttachDoc(sDocumentID, sCPID, sCPOfficeID);//Procedure dbo.spSetDocument_CP
				}
				else
				{
					if (this.CheckOperationExistance(this.newOperationsListMember,
						sDocumentID))
					{
						MessageBox.Show(this, "This document is already attached. Please, choose another document.",
							"Document already attached", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						this.sDocumentID = null;
						this.sDocumentName = sDocumentName;
						this.sOperationTypeOfficeID_OperationTypeID = null;
						return;
					}
					else
					{

						DefineDocumentForm.NewOperationData nod = new DefineDocumentForm.NewOperationData();
						nod.sDocumentID = sDocumentID;
						nod.sCPID = null;
						nod.sCPOfficeID = null;
						nod.sOperationTypeID = null;
						nod.sOperationTypeOfficeID = null;
						newOperationsListMember.Add(nod);
						this.sDocumentID = sDocumentID;
					}
				}
				//this.sDocumentID = SaveDoc(sDocumentName);
				if (this.sDocumentID != null)
				{
					MessageBox.Show(this, "Document was successfully attached.", "Information", MessageBoxButtons.OK,
						MessageBoxIcon.Information);
					DisableForm();
				}
				//				else
				//				{
				//					MessageBox.Show(this, "This document is already attached. Please, choose another document.",
				//						"Document already attached", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				//				}
			}
		}


		private void DefineDocumentForm_Load(object sender, System.EventArgs e)
		{

		}

		public string GetDocumentName()
		{
			string s = String.Format("{0}, {1}", this.sDocumentName, this.sOperationTypeName);
			return s;
			//return this.sDocumentName;
		}

		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			//if (IsFixedTextEntered())
			{
				//DocumentID_OperationTypeOfficeID_OperationTypeID
				string sID = this.cbDocuments.SelectedValue.ToString();
				if (sID == null || sID.Length == 0)
				{
					MessageBox.Show(this, "Can't update document. Please, select any document first.",
						"Document isn't selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
				string[] sIDs = sID.Split('_');
				string sDocumentID = sIDs[0];
				string sDocumentName = cbDocuments.Text;

				//if title or value fields was empty 
				if (UpdateDoc(sDocumentID, sDocumentName) == -1)
				{
					MessageBox.Show(this, "Document wasn't updated.",
						"abort update", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				this.sDocumentID = null;
				this.sDocumentName = null;
				this.sOperationTypeOfficeID_OperationTypeID = null;
				//				this.sDocumentID = sDocumentID;
				//				this.sDocumentName = sDocumentName;
				//				this.sOperationTypeOfficeID_OperationTypeID = sIDs[1] + "_" + sIDs[2];
				MessageBox.Show(this, "Document was successfully updated.",
					"Successful update", MessageBoxButtons.OK, MessageBoxIcon.Warning);

				//this.InitDocuments();
				//this.cbDocuments.SelectedValue = sID;

				/*
				string sID;
				IsDocumentExist(sDocumentName, out sID, newDocTypeCode);
				if (dex == DocumentExistance.DocumentExistsWithSameType)
				{
					string[] sIDs = sID.Split('_');


				UpdateDoc(sDocumentID, sDocumentName);
				this.sDocumentID = sDocumentID;
				this.sDocumentName = sDocumentName;
				this.sOperationTypeOfficeID_OperationTypeID = sIDs[1] + "_" + sIDs[2];
				this.InitDocuments();
				this.cbDocuments.SelectedValue = sID;
				*/
			}
		}

		//private void label2_Click(object sender, System.EventArgs e)
		//{

		//}

		private void cbFTPimport_SelectedValueChanged(object sender, System.EventArgs e)
		{
			if (IsLoadImPExpInfo)
			{
				IsUpdateImPExpInfo = true;
			}
		}

		private void cbFTPExport_SelectedValueChanged(object sender, System.EventArgs e)
		{
			if (IsLoadImPExpInfo)
			{
				IsUpdateImPExpInfo = true;
			}
		}

		private void cbExportFormat_SelectedValueChanged(object sender, System.EventArgs e)
		{
			if (IsLoadImPExpInfo)
			{
				IsUpdateImPExpInfo = true;
			}
		}

		private void lbCorelFiles_DoubleClick(object sender, EventArgs e)
		{
			var pathToJPG = Service.GetServiceCfgParameter("sendDir") + "cdr_to_jpg";
			var corelFilePreview = lbCorelFiles.SelectedValue.ToString().ToUpper().Replace(".XLSX", ".JPG").Replace(".CDR", ".JPG").Replace(".XLS", ".JPG");

			ImageListViewDemo.DemoForm JPG_Show = new ImageListViewDemo.DemoForm(corelFilePreview, pathToJPG);
			JPG_Show.ShowDialog();
			var NewCorelFile = JPG_Show.ReturnSelectedGPG();
			lbCorelFiles.SelectedValue = NewCorelFile;
		}
	}
}