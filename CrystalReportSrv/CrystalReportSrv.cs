using System;
using System.Data;
using System.Diagnostics;
using System.IO;

namespace CrystalReportSrv
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class CrystalReportSrv
	{
		
		private System.Data.DataSet dsCrystalSet;
		private string sReportsDir;
//		private CrystalDecisions.CrystalReports.Engine.ReportDocument crDocument;
		private string sExportDocPath="";
		private string sExportDocExt="";
		private string sPrinterName="";
		public string sAppDir="";

		public void Batch(DataSet dsData)
		{
			
			
			//string sReportPath=@"c:\work\sergei\work\crystal\reports\batch.rpt";
			string sReportPath=sReportsDir+@"batch.rpt";
//			crDocument.Load(sReportPath);
			//sPrinterName = GetPrinterName("Batch");

			DataSet dsTempSet=new DataSet();
			DataTable table1=new DataTable("batch");
			table1.Columns.Add("id",System.Type.GetType("System.String"));
			table1.Columns.Add("batchid",System.Type.GetType("System.String"));
			table1.Columns.Add("itemnumber",System.Type.GetType("System.String"));
			table1.Columns.Add("Color",System.Type.GetType("System.String"));
			table1.Columns.Add("Clarity",System.Type.GetType("System.String"));
			table1.Columns.Add("Measurments",System.Type.GetType("System.String"));

			table1.Columns.Add("Lotnum",System.Type.GetType("System.String"));
			table1.Columns.Add("weight",System.Type.GetType("System.String"));

			//dsItemSet=gemoDream.Service.GetCrystalSet(sBatchID+"_"+sItemCode,"Item");


			//tblItem

			//GroupCode
			//Name - item
			//Clarity
			//Color
			//BatchCode
			//CustomerCode
			//OrderCode
			//Dimensions
/*
			string sBatchName="";

			for(int i=0;i<dsData.Tables["tblItem"].Rows.Count;i++)
			{	
				DataRow tRow1=table1.NewRow();
				tRow1["id"]=i.ToString();

				for(int j=0;j<dsData.Tables["tblBatch"].Rows.Count;j++)
				{
					if(dsData.Tables["tblBatch"].Rows[j]["ID"].ToString()==
						dsData.Tables["tblItem"].Rows[i]["ParentID"].ToString())
						sBatchName=dsData.Tables["tblBatch"].Rows[j]["Name"].ToString();
				}
				
				tRow1["batchid"]=sBatchName;
				tRow1["text"]=dsData.Tables["tblItem"].Rows[i]["Name"];

				table1.Rows.Add(tRow1);	
			}
*/
			for(int i=0;i<dsData.Tables["tblItem"].Rows.Count;i++)
			{
				DataRow tRow1=table1.NewRow();
				tRow1["id"]=i.ToString();
				tRow1["batchid"]=FillToFiveChars(dsData.Tables["tblItem"].Rows[i]["OrderCode"].ToString())+FillToThreeChars(dsData.Tables["tblItem"].Rows[i]["BatchCode"].ToString());
				tRow1["itemnumber"]=dsData.Tables["tblItem"].Rows[i]["Name"].ToString().Replace(".","");
				tRow1["Color"]=dsData.Tables["tblItem"].Rows[i]["Color"].ToString();
				tRow1["Clarity"]=dsData.Tables["tblItem"].Rows[i]["Clarity"].ToString();
				tRow1["Measurments"]=dsData.Tables["tblItem"].Rows[i]["Dimensions"].ToString();
				tRow1["lotnum"]=dsData.Tables["tblItem"].Rows[i]["LotNumber"].ToString();
				tRow1["weight"]=dsData.Tables["tblItem"].Rows[i]["Weight"].ToString();

				table1.Rows.Add(tRow1);
			}
			

			dsTempSet.Tables.Add(table1);

			dsCrystalSet=new DataSet();
			dsCrystalSet=dsTempSet;
//			crDocument.SetDataSource(dsCrystalSet);
//
//			CrystalDecisions.CrystalReports.Engine.TextObject text;
//			text=crDocument.ReportDefinition.ReportObjects["text3"] as CrystalDecisions.CrystalReports.Engine.TextObject;
//			text.Text=dsData.Tables["tblItem"].Rows[0]["CustomerName"].ToString();
//			text=crDocument.ReportDefinition.ReportObjects["text5"] as CrystalDecisions.CrystalReports.Engine.TextObject;
//			text.Text=dsData.Tables["tblItem"].Rows[0]["CustomerCode"].ToString();
//			text=crDocument.ReportDefinition.ReportObjects["text7"] as CrystalDecisions.CrystalReports.Engine.TextObject;
//			text.Text=FillToFiveChars(dsData.Tables["tblItem"].Rows[0]["OrderCode"].ToString());



		}

		public void PDF_ReportSrv(string sTemplatePath, DataSet dsBatch, DataSet dsItem, DataSet dsItemType, DataSet dsShape, DataSet dsPartValueType, DataSet dsBatchWCustomer)
		{
			//string sReportName=System.IO.Path.GetFileName(sTemplatePath);

		}
		
		public CrystalReportSrv(string sReportsDirectory)
		{
//			crDocument=new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			sReportsDir=sReportsDirectory;
			//sAppDir=sApplicationDir;
		}


		#region ServiceTemplates


		#endregion

		private string GetReportNumber()
		{
			string sNumber="";
			System.Xml.XmlDocument doc=new System.Xml.XmlDocument();
			try
			{	
				doc.Load(sReportsDir+@"ReportNumber.xml");
				System.Xml.XmlNodeList nodes=doc.GetElementsByTagName("Number");
				sNumber=nodes[0].InnerText.ToString().Trim();
				int iNum=Convert.ToInt32(sNumber);
				iNum++;
				sNumber=iNum.ToString();
				nodes[0].InnerText=sNumber;
				doc.Save(sReportsDir+@"ReportNumber.xml");
			}
			catch(Exception exc)
			{
				
			}
			return sNumber;
		}
		
		private string FillToFiveChars(string sNumber)
		{
			while(sNumber.Length<5)
				sNumber="0"+sNumber;
			return sNumber;
		}
		private string FillToThreeChars(string sNumber)
		{
			while(sNumber.Length<3)
				sNumber="0"+sNumber;
			return sNumber;
		}
		
		private string FillToTwoChars(string sNumber)
		{
			while(sNumber.Length<2)
				sNumber="0"+sNumber;
			return sNumber;
		}
		
		private string GetMeasureValue(string sMeasureName, DataTable tTable, string sPartID)
		{
			DataRow[] rParts=null;
			string sRet="";
			try
			{

				if(tTable.Rows.Count > 0)					
				{
					rParts=tTable.Select("MeasureTitle="+"'"+sMeasureName+"'"+" and PartID="+sPartID);
					
					switch(rParts[0]["MeasureClass"].ToString())
					{
						case "1": sRet=rParts[0]["MeasureValueName"].ToString(); break;
						case "2": sRet=rParts[0]["StringValue"].ToString(); break;
						case "3": sRet=rParts[0]["MeasureValue"].ToString(); break;
						case "4": sRet=rParts[0]["StringValue"].ToString(); break;
					}
					
					Trace.WriteLine(sMeasureName+"="+rParts[0]["MeasureValueName"].ToString());
					Trace.WriteLine(sMeasureName+"="+rParts[0]["StringValue"].ToString());
					Trace.WriteLine(sMeasureName+"="+rParts[0]["MeasureValue"].ToString());

					//sRet=rParts[0]["MeasureValueName"].ToString();
				}
				

			}
			catch(Exception exc)
			{
				Trace.WriteLine(exc.Source.ToString()+" "+exc.Message.ToString());
			}

			return sRet;
			
		}

		public void PrintToDefaultPrinter()
		{			
			System.Drawing.Printing.PrinterSettings ps=new System.Drawing.Printing.PrinterSettings();
//			crDocument.PrintOptions.PrinterName=ps.PrinterName;
//			crDocument.PrintToPrinter(1, false,0,0);						
		}
		
		public void Print()
		{
//			crDocument.PrintOptions.PrinterName=sPrinterName;
//			crDocument.PrintToPrinter(1,false,0,0);
		}

		public void ViewDocument()
		{
			if(!File.Exists(sExportDocPath))
				throw new Exception("Not found file for preview");

			if(sExportDocExt.ToLower() == "pdf")
			{
				//	RegistryKey pdfRk = Registry.ClassesRoot.OpenSubKey("Applications\\AcroRd32.exe\\shell\\Read\\command");
				//	if(pdfRk == null)
				//		throw new Exception("Adobe Acrobat Reader 7.0 is not installed on your computer");

				Process.Start(sExportDocPath);
			}
			if(sExportDocExt.ToLower() == "rtf")
			{
				Process.Start(sExportDocPath);
			}
		}

		public void Export(string sPath,string sFileName, string sExt)
		{
			if(!System.IO.Directory.Exists(sPath))
				System.IO.Directory.CreateDirectory(sPath);

			sExt=sExt.ToLower();
			sExportDocPath=sPath+sFileName+"."+sExt;
			sExportDocExt=sExt;

	
		}

		public void Export(string sExt)
		{
			string sFileNamePrefix=@"gemoDreamTmp";
			string sFileName="";
			string sFullName="";

			int iIndex=0;
			while(true)
			{
				iIndex++;
				if(iIndex>100) {System.Windows.Forms.MessageBox.Show("Too many temporary files"); break;}
				sFileName=sFileNamePrefix+FillToThreeChars(iIndex.ToString());
				sFullName=sFileName+"."+sExt;
				if(File.Exists(sFullName))
				{
					try
					{
						System.IO.File.Delete(sFullName);
					}
					catch(Exception ex)
					{
						continue;
					}
					break;
				}
				break;

			}

			sExt=sExt.ToLower();
			sExportDocPath=sFullName;
			sExportDocExt=sExt;


		}


	}
}
