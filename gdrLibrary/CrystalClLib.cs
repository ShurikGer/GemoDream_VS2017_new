using System;
using System.Diagnostics;
using System.Data;
using Microsoft.Win32;
using System.IO;
using System.Runtime.InteropServices;

namespace CrystalReportCl
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class CrystalReport
	{
		
		private System.Data.DataSet dsCrystalSet;
		private string sReportsDir;
//		private CrystalDecisions.CrystalReports.Engine.ReportDocument crDocument;
		private string sExportDocPath="";
		private string sExportDocExt="";
		private string sPrinterName="";

		public CrystalReport(string sReportsDirectory)
		{
//			crDocument=new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			sReportsDir=sReportsDirectory;
		}

		#region Front


		#region Old_front_TakeIn_Label
		/*
		public void Front_TakeIn_Label(string sID)
		{
		  //string sReportPath=@"c:\work\sergei\work\crystal\reports\front_takein_Label_.rpt";
			string sReportPath=sReportsDir+@"front_takeIn_label.rpt";
			
			sPrinterName=GetPrinterName("Front_TakeIn_Label");

			crDocument.Load(sReportPath);
	
			DataSet tempSet=new DataSet();
			DataSet recvSet=new DataSet();
			dsCrystalSet=new DataSet();
			DataSet dsServiceType=new DataSet();

			recvSet=gemoDream.Service.GetCrystalSet(sID,"Group");
			
			DataRow row=recvSet.Tables[0].Rows[0];

			debug_DataSet(recvSet);

			dsServiceType=gemoDream.Service.GetCrystalSet(row["ServiceTypeID"].ToString(),"ServiceType");
					
			string sDelim="_";
			char [] cDelim=sDelim.ToCharArray();
			string[] split=sID.Split(cDelim);
			string sBatchCode=FillToThreeChars(split[0]);

			System.Data.DataTable table=new DataTable("Meq2");

			table.Columns.Add("text1",System.Type.GetType("System.String"));
			table.Columns.Add("text2",System.Type.GetType("System.String"));
			table.Columns.Add("text3",System.Type.GetType("System.String"));
			table.Columns.Add("text4",System.Type.GetType("System.String"));
			table.Columns.Add("text5",System.Type.GetType("System.String"));
			table.Columns.Add("text6",System.Type.GetType("System.String"));
			table.Columns.Add("text7",System.Type.GetType("System.String"));
			table.Columns.Add("text8",System.Type.GetType("System.String"));
			table.Columns.Add("text9",System.Type.GetType("System.String"));
			
			System.Data.DataRow tRow=table.NewRow();

			string sGroupCode=row["GroupCode"].ToString();
	

			sGroupCode=FillToFiveChars(sGroupCode);
				

			tRow[0]="*"+sGroupCode+sGroupCode+sBatchCode+"*";
			tRow[1]=sGroupCode+"."+sGroupCode+"."+sBatchCode;
			tRow[2]=row["CreateDate"].ToString();
			tRow[3]=row["CustomerName"].ToString();
			tRow[6]=dsServiceType.Tables[0].Rows[0]["ServiceTypeName"].ToString();
	
			DataTable tblMeasure=gemoDream.Service.GetMeasureUnits();
			

			foreach(DataColumn col in tblMeasure.Columns)
				Trace.WriteLine(col.Caption);

			string sNotInspUnitName="";
			string sInspUnitName="";

			Trace.WriteLine("--------------");

			foreach(DataRow rowq in tblMeasure.Rows)
			{
				Trace.WriteLine(rowq["MeasureUnitID"].ToString());
				Trace.WriteLine(row["NotInspectedWeightUnitID"].ToString());
				if(rowq["MeasureUnitID"].ToString()==row["NotInspectedWeightUnitID"].ToString())
					sNotInspUnitName=rowq["MeasureUnitName"].ToString();
				if(rowq["MeasureUnitID"].ToString()==row["InspectedWeightUnitID"].ToString())
					sInspUnitName=rowq["MeasureUnitName"].ToString();
			
			}

		#region Quantity/Weight
			string sQuantity="";
			string sWeight="";
			string temp="";
			string sInspQ="";
			string sInspW="";
			bool bWeight=false;
			bool bQuantity=false;

			if(row["InspectedQuantity"].ToString().Length>0)
			{
				sQuantity=row["InspectedQuantity"].ToString();	
				sInspQ="(insp.)";
				bQuantity=true;
			}
			
			if(row["NotInspectedQuantity"].ToString().Length>0)
			{
				sQuantity=row["NotInspectedQuantity"].ToString();
				sInspQ="(not insp.)";
				bQuantity=true;
			}

			
			if(row["InspectedTotalWeight"].ToString().Length>0)
			{
				sWeight=row["InspectedTotalWeight"].ToString()+" "+sInspUnitName;
				sInspW="(insp.)";
				bWeight=true;
			}
			if(row["NotInspectedTotalWeight"].ToString().Length>0)
			{
				sWeight=row["NotInspectedTotalWeight"].ToString()+" "+sNotInspUnitName;
				sInspW="(not insp.)";
				bWeight=true;
			}
			
			if(bQuantity)
				temp="Quantity:"+sQuantity+sInspQ;
			if(bWeight&&bQuantity)
			{
				temp="Quantity:"+sQuantity+sInspQ+"/ Weight:"+sWeight+" "+sInspW;
			}
			if(bWeight)
				temp="Weight:"+sWeight+" "+sInspW;

			tRow[5]=temp;
		#endregion
	
			table.Rows.Add(tRow);
			
			tempSet.Tables.Add(table);
			
			dsCrystalSet=tempSet;	
			dsCrystalSet.Tables[0].TableName=crDocument.Database.Tables[0].Name;
			crDocument.SetDataSource(dsCrystalSet);
		}
		
		*/
		#endregion


		public void Front_TakeIn_Label(string sID)
		{
			string sReportPath=sReportsDir+@"front_takeIn_label.rpt";
			
			sPrinterName=GetPrinterName("Front_TakeIn_Label");
//			crDocument.Load(sReportPath);
	
			DataSet	dsGroup=gemoDream.Service.GetCrystalSet(sID,"GroupWithCustomer");
			DataRow rGroup=dsGroup.Tables[0].Rows[0];
			DataSet dsServiceType=gemoDream.Service.GetCrystalSet(rGroup["ServiceTypeID"].ToString(),"ServiceType");

			string sDelim="_";
			char [] cDelim=sDelim.ToCharArray();
			string[] split=sID.Split(cDelim);
			string sBatchCode=FillToThreeChars(split[0]);
			string sGroupCode=rGroup["GroupCode"].ToString();
	
			sGroupCode=FillToFiveChars(sGroupCode);
				
			
			DataTable tblMeasure=gemoDream.Service.GetMeasureUnits();
			
//			CrystalDecisions.CrystalReports.Engine.TextObject crText;
//			crText=crDocument.ReportDefinition.ReportObjects["text1"] as CrystalDecisions.CrystalReports.Engine.TextObject;
//			crText.Text="*"+sGroupCode+"*"; //barcode
//			crText=crDocument.ReportDefinition.ReportObjects["text2"] as CrystalDecisions.CrystalReports.Engine.TextObject;
//			crText.Text=sGroupCode; //barcode
//			crText=crDocument.ReportDefinition.ReportObjects["text4"] as CrystalDecisions.CrystalReports.Engine.TextObject;
//			crText.Text=System.DateTime.Now.Date.ToShortDateString(); //date
//			crText=crDocument.ReportDefinition.ReportObjects["text5"] as CrystalDecisions.CrystalReports.Engine.TextObject;
//			crText.Text=System.DateTime.Now.ToShortTimeString();// time
//
//			crText=crDocument.ReportDefinition.ReportObjects["text7"] as CrystalDecisions.CrystalReports.Engine.TextObject;
//			crText.Text=rGroup["ExtPhone"].ToString(); //ext. phone
//			crText=crDocument.ReportDefinition.ReportObjects["text8"] as CrystalDecisions.CrystalReports.Engine.TextObject;
//			crText.Text=rGroup["CustomerName"].ToString();  //"Customer";
//			crText=crDocument.ReportDefinition.ReportObjects["text20"] as CrystalDecisions.CrystalReports.Engine.TextObject;
//			crText.Text="00.00.0000"; // due date
//			crText=crDocument.ReportDefinition.ReportObjects["text19"] as CrystalDecisions.CrystalReports.Engine.TextObject;
//			crText.Text="00:00"; // due time

			#region Weight
			string sWeight="";
			string sInspWeightWord="";
			bool isWeight=false;

			if(rGroup["InspectedTotalWeight"]!=DBNull.Value)
			{
				isWeight=true;
				sInspWeightWord="inspected";
				sWeight=rGroup["InspectedTotalWeight"].ToString()+" ";
				DataRow [] rMeasureName=tblMeasure.Select("MeasureUnitID="+rGroup["InspectedWeightUnitID"].ToString());
				sWeight+=rMeasureName[0]["MeasureUnitName"].ToString();
			}
			if(rGroup["NotInspectedTotalWeight"]!=DBNull.Value)
			{
				isWeight=true;
				sInspWeightWord="not inspected";
				sWeight=rGroup["NotInspectedTotalWeight"].ToString()+" ";
				DataRow [] rMeasureName=tblMeasure.Select("MeasureUnitID="+rGroup["NotInspectedWeightUnitID"].ToString());
				sWeight+=rMeasureName[0]["MeasureUnitName"].ToString();
			}
			#endregion

			#region Quantity
			string sQuantity="";
			string sInspQuantWord="";
			bool isQuantity=false;
					
			if(rGroup["InspectedQuantity"]!=DBNull.Value)
			{
				isQuantity=true;
				sInspQuantWord="inspected";
				sQuantity=rGroup["InspectedQuantity"].ToString();

			}
			if(rGroup["NotInspectedQuantity"]!=DBNull.Value)
			{
				isQuantity=true;
				sInspQuantWord="not inspected";
				sQuantity=rGroup["NotInspectedQuantity"].ToString();
			}
			#endregion

			if(isQuantity)
			{
//				crText=crDocument.ReportDefinition.ReportObjects["text10"] as CrystalDecisions.CrystalReports.Engine.TextObject;
//				crText.Text=sQuantity; // quantity number
//				crText=crDocument.ReportDefinition.ReportObjects["text21"] as CrystalDecisions.CrystalReports.Engine.TextObject;
//				crText.Text=sInspQuantWord; // quantity "insp" word
			}
			else 
			{
//				crText=crDocument.ReportDefinition.ReportObjects["text10"] as CrystalDecisions.CrystalReports.Engine.TextObject;
//				crText.Text=""; // quantity number
//				crText=crDocument.ReportDefinition.ReportObjects["text21"] as CrystalDecisions.CrystalReports.Engine.TextObject;
//				crText.Text=""; // quantity "insp" word
//				crText=crDocument.ReportDefinition.ReportObjects["text9"] as CrystalDecisions.CrystalReports.Engine.TextObject;
//				crText.Text=""; // "number of items" word
			}

			if(isWeight)
			{
//				crText=crDocument.ReportDefinition.ReportObjects["text12"] as CrystalDecisions.CrystalReports.Engine.TextObject;
//				crText.Text=sWeight; // weight number
//				crText=crDocument.ReportDefinition.ReportObjects["text22"] as CrystalDecisions.CrystalReports.Engine.TextObject;
//				crText.Text=sInspWeightWord; // weight "insp" word
			}
			else
			{
//				crText=crDocument.ReportDefinition.ReportObjects["text12"] as CrystalDecisions.CrystalReports.Engine.TextObject;
//				crText.Text=""; // weight number
//				crText=crDocument.ReportDefinition.ReportObjects["text22"] as CrystalDecisions.CrystalReports.Engine.TextObject;
//				crText.Text=""; // weight "insp" word
//				crText=crDocument.ReportDefinition.ReportObjects["text11"] as CrystalDecisions.CrystalReports.Engine.TextObject;
//				crText.Text=""; // "total weight" word
			}

		}
		public void Front_TakeIn(string sID) //kvitanciya
		{
			//	string sReportPath=@"c:\work\sergei\work\crystal\reports\front_takein.rpt";
			
			string sReportPath=sReportsDir+@"front_takein.rpt";
			
			sPrinterName=GetPrinterName("Front_TakeIn");

//			crDocument.Load(sReportPath);
			DataSet dsTempSet=new DataSet();
			DataSet dsRecvSet=new DataSet();
			DataSet dsPerson=new DataSet();
			dsCrystalSet=new DataSet();
			string sOrderSummary="";
			string sSpecialInstructions="";			
			string sMessenger="";
						

			dsRecvSet=gemoDream.Service.GetCrystalSet(sID,"Group");
			DataRow row=dsRecvSet.Tables[0].Rows[0];

			DataSet dsServiceType=gemoDream.Service.GetCrystalSet(row["ServiceTypeID"].ToString(),"ServiceType");
			DataSet dsAuthor=gemoDream.Service.GetCrystalSet(sID,"GroupAuthor");
			
			if(row["PersonCustomerOfficeID_PersonCustomerID_PersonID"].ToString().Length>0)
			{
				dsPerson=gemoDream.Service.GetCrystalSet(row["PersonCustomerOfficeID_PersonCustomerID_PersonID"].ToString(),"Person");
				sMessenger="messenger";

				foreach (DataColumn col in dsPerson.Tables[0].Columns)
					Trace.WriteLine(col.Caption);

			}
			
			DataTable table=new DataTable("table");

			table.Columns.Add("text1",System.Type.GetType("System.String"));
			table.Columns.Add("text2",System.Type.GetType("System.String"));
			table.Columns.Add("text3",System.Type.GetType("System.String"));
			
			DataRow tRow=table.NewRow();
			
			DataTable tblMeasure=gemoDream.Service.GetMeasureUnits();
			

			string sNotInspUnitName="";
			string sInspUnitName="";

			Trace.WriteLine("--------------");

			foreach(DataRow rowq in tblMeasure.Rows)
			{
				Trace.WriteLine(rowq["MeasureUnitID"].ToString());
				Trace.WriteLine(row["NotInspectedWeightUnitID"].ToString());
				if(rowq["MeasureUnitID"].ToString()==row["NotInspectedWeightUnitID"].ToString())
					sNotInspUnitName=rowq["MeasureUnitName"].ToString();
				if(rowq["MeasureUnitID"].ToString()==row["InspectedWeightUnitID"].ToString())
					sInspUnitName=rowq["MeasureUnitName"].ToString();
			
			}
			
			#region Quantity/Weight
			string sQuantity="";
			string sWeight="";
			string temp="";
			string sInspQ="";
			string sInspW="";
			bool bWeight=false;
			bool bQuantity=false;

			if(row["InspectedQuantity"].ToString().Length>0)
			{
				sQuantity=row["InspectedQuantity"].ToString();	
				sInspQ="inspected";
				bQuantity=true;
			}
			
			if(row["NotInspectedQuantity"].ToString().Length>0)
			{
				sQuantity=row["NotInspectedQuantity"].ToString();
				sInspQ="not inspected";
				bQuantity=true;
			}

			
			if(row["InspectedTotalWeight"].ToString().Length>0)
			{
				sWeight=row["InspectedTotalWeight"].ToString()+" "+sInspUnitName;
				sInspW="inspected";
				bWeight=true;
			}
			if(row["NotInspectedTotalWeight"].ToString().Length>0)
			{
				sWeight=row["NotInspectedTotalWeight"].ToString()+" "+sNotInspUnitName;
				sInspW="not inspected";
				bWeight=true;
			}
			
			if(bQuantity)
				temp="Quantity:"+sQuantity+sInspQ;
			if(bWeight&&bQuantity)
			{
				temp="Quantity:"+sQuantity+sInspQ+"/ Weight:"+sWeight+" "+sInspW;
			}
			if(bWeight)
				temp="Weight:"+sWeight+" "+sInspW;

			
			#endregion
			
									    
			sOrderSummary="Customer: "+row["CustomerName"].ToString()+"\n"+
				"Messenger: "+sMessenger+"\n"+
				"Number of items: "+sQuantity+" "+sInspQ+"\n"+
				"Total weight: "+sWeight+" "+sInspW+"\n"+
				"Service Type: "+dsServiceType.Tables[0].Rows[0]["ServiceTypeName"].ToString()+"\n"+
				"Memo: "+row["Memo"].ToString();
			
			sSpecialInstructions=row["SpecialInstruction"].ToString();
	
			tRow[0]=sOrderSummary;
			tRow[1]=dsAuthor.Tables[0].Rows[0]["FirstName"].ToString()+" "+dsAuthor.Tables[0].Rows[0]["LastName"];

			/*
			 *dsAuthor
				FirstName
				MiddleName
				LastName
				GroupOfficeID
				GroupID
			*/

			
			tRow[2]=sSpecialInstructions;
			table.Rows.Add(tRow);
			dsTempSet.Tables.Add(table);
			dsCrystalSet=dsTempSet;
//			dsCrystalSet.Tables[0].TableName=crDocument.Database.Tables[0].Name;
//			crDocument.SetDataSource(dsCrystalSet);
			

		}


		#endregion

		#region Itemizing

		public void Label_Batch(string sBatchID)
		{
			string sReportPath=sReportsDir+@"label_batch.rpt";
			//string sReportPath="";

			sPrinterName=GetPrinterName("Label_Batch");

//			crDocument.Load(sReportPath);
			DataSet dsBatch=gemoDream.Service.GetCrystalSet(sBatchID,"BatchWithCustomer");
			DataRow rBatch=dsBatch.Tables[0].Rows[0];

			string sDeliveryMethod="";
			string sAccount="";
			string sCarrier="";

			if(rBatch["WeCarry"].ToString()=="1")
			{
				sDeliveryMethod="We Carry";
			}

			if(rBatch["TheyCarry"].ToString()=="1")
			{
				sDeliveryMethod="They Carry";
			}

			if(rBatch["WeShipCarry"].ToString()=="1")
			{
				sDeliveryMethod="We Use Their Account To Ship";
				sAccount=rBatch["Account"].ToString();
				DataSet dsCustomerTypeEx=gemoDream.Service.GetCustomerTypeEx();
				DataTable tblCarriers=dsCustomerTypeEx.Tables["Carriers"].Copy();
				DataRow []rCarrier= tblCarriers.Select("CarrierID="+rBatch["CarrierID"]);
				sCarrier=rCarrier[0]["CarrierName"].ToString();
			}
			/*
			WeCarry
			TheyCarry
			WeShipCarry
			UseTheirAccount
			Account
			CarrierID
			*/

		
			string sBatchCode=FillToThreeChars(rBatch["BatchCode"].ToString());
			string sGroupCode=FillToFiveChars(rBatch["GroupCode"].ToString());
			
//			CrystalDecisions.CrystalReports.Engine.TextObject crText;
//			crText=crDocument.ReportDefinition.ReportObjects["text1"] as CrystalDecisions.CrystalReports.Engine.TextObject;
//			crText.Text="*"+sGroupCode+sBatchCode+"*"; //barcode
//			crText=crDocument.ReportDefinition.ReportObjects["text2"] as CrystalDecisions.CrystalReports.Engine.TextObject;
//			crText.Text=sGroupCode;
//			crText=crDocument.ReportDefinition.ReportObjects["text3"] as CrystalDecisions.CrystalReports.Engine.TextObject;			
//			crText.Text=sGroupCode+"."+sBatchCode; //barcode
//			
//			Trace.WriteLine(sGroupCode+"."+sBatchCode);
//
//			crText=crDocument.ReportDefinition.ReportObjects["text8"] as CrystalDecisions.CrystalReports.Engine.TextObject;
//			crText.Text=rBatch["CustomerName"].ToString();  //"Customer";
//
//			crText=crDocument.ReportDefinition.ReportObjects["text10"] as CrystalDecisions.CrystalReports.Engine.TextObject;
//			crText.Text=rBatch["ItemsQuantity"].ToString(); //"# of items";
//			
//			crText=crDocument.ReportDefinition.ReportObjects["text17"] as CrystalDecisions.CrystalReports.Engine.TextObject;
//			crText.Text=sDeliveryMethod;//delivery method
//			crText=crDocument.ReportDefinition.ReportObjects["text16"] as CrystalDecisions.CrystalReports.Engine.TextObject;
//			crText.Text=sCarrier;//Carrier
//			crText=crDocument.ReportDefinition.ReportObjects["text21"] as CrystalDecisions.CrystalReports.Engine.TextObject;
//			crText.Text=sAccount;//Account #
//			
//
//			crText=crDocument.ReportDefinition.ReportObjects["text12"] as CrystalDecisions.CrystalReports.Engine.TextObject;
//			crText.Text=rBatch["ItemsWeight"].ToString()+" ct."; //weight
//			
//			crText=crDocument.ReportDefinition.ReportObjects["text4"] as CrystalDecisions.CrystalReports.Engine.TextObject;
//			crText.Text=System.DateTime.Now.Date.ToShortDateString(); //date
//			crText=crDocument.ReportDefinition.ReportObjects["text5"] as CrystalDecisions.CrystalReports.Engine.TextObject;
//			crText.Text=System.DateTime.Now.ToShortTimeString();// time
//
//			crText=crDocument.ReportDefinition.ReportObjects["text20"] as CrystalDecisions.CrystalReports.Engine.TextObject;
//			crText.Text="00.00.0000"; //date
//			crText=crDocument.ReportDefinition.ReportObjects["text19"] as CrystalDecisions.CrystalReports.Engine.TextObject;
//			crText.Text="00:00"; // time
//
//			crText=crDocument.ReportDefinition.ReportObjects["text7"] as CrystalDecisions.CrystalReports.Engine.TextObject;
//			crText.Text=rBatch["ExtPhone"].ToString();
//
//			crText=crDocument.ReportDefinition.ReportObjects["text14"] as CrystalDecisions.CrystalReports.Engine.TextObject;
//			crText.Text=rBatch["CustomerProgramName"].ToString();
		}
		/*
				public void Label_Batch_old(string sBatchID)
				{
					//	string sReportPath=@"c:\work\sergei\work\crystal\reports\label_Batch.rpt";
					string sReportPath=sReportsDir+@"label_batch.rpt";

					crDocument.Load(sReportPath);
					sPrinterName=GetPrinterName("Label_Batch");
					DataSet dsTempSet=new DataSet();
					dsCrystalSet=new DataSet();
					DataSet dsRecvSet=new DataSet();
					dsRecvSet=gemoDream.Service.GetCrystalSet(sBatchID,"BatchWithCustomer");
					DataRow row=dsRecvSet.Tables[0].Rows[0];
					DataSet dsAccountRepSet=gemoDream.Service.GetCrystalSet(dsRecvSet.Tables[0].Rows[0]["BatchID"].ToString(),"BatchAccountRep");
					DataTable table=new DataTable("lable");
					string sBatchCode=FillToThreeChars(row["BatchCode"].ToString());
					string sGroupCode=FillToFiveChars(row["GroupCode"].ToString());
					table.Columns.Add("text1",System.Type.GetType("System.String"));
					table.Columns.Add("text2",System.Type.GetType("System.String"));
					table.Columns.Add("text3",System.Type.GetType("System.String"));
					table.Columns.Add("text4",System.Type.GetType("System.String"));
					table.Columns.Add("text5",System.Type.GetType("System.String"));
					table.Columns.Add("text6",System.Type.GetType("System.String"));

					DataRow tRow=table.NewRow();
					tRow[0]="*"+sGroupCode+sBatchCode+"*";
					tRow[1]=sGroupCode+"."+sBatchCode;
					tRow[2]="";
					tRow[3]="";
					tRow[4]="";
					tRow[5]="";
			
					table.Rows.Add(tRow);
					dsTempSet.Tables.Add(table);
					dsTempSet.Tables[0].TableName=crDocument.Database.Tables[0].Name;
					dsCrystalSet=dsTempSet;
					crDocument.SetDataSource(dsCrystalSet);

					CrystalDecisions.CrystalReports.Engine.TextObject crText;
					crText=crDocument.ReportDefinition.ReportObjects["text1"] as CrystalDecisions.CrystalReports.Engine.TextObject;
					crText.Text=row["ItemsQuantity"].ToString(); //"# of items";
					crText=crDocument.ReportDefinition.ReportObjects["text2"] as CrystalDecisions.CrystalReports.Engine.TextObject;
					crText.Text="date_1";
					crText=crDocument.ReportDefinition.ReportObjects["text3"] as CrystalDecisions.CrystalReports.Engine.TextObject;
					crText.Text=row["CustomerName"].ToString();  //"Customer";
					crText=crDocument.ReportDefinition.ReportObjects["text4"] as CrystalDecisions.CrystalReports.Engine.TextObject;
					crText.Text=dsAccountRepSet.Tables[0].Rows[0]["FirstName"].ToString()+
					dsAccountRepSet.Tables[0].Rows[0]["LastName"].ToString();  //"FIO account repr";
					crText=crDocument.ReportDefinition.ReportObjects["text5"] as CrystalDecisions.CrystalReports.Engine.TextObject;
					crText.Text=row["ExtPhone"].ToString();  //"ext. num";
					crText=crDocument.ReportDefinition.ReportObjects["text6"] as CrystalDecisions.CrystalReports.Engine.TextObject;
					crText.Text="time_1";
					crText=crDocument.ReportDefinition.ReportObjects["text7"] as CrystalDecisions.CrystalReports.Engine.TextObject;
					crText.Text=row["CustomerProgramName"].ToString();  //"Customer Program";
			
					//	crText=crDocument.ReportDefinition.ReportObjects["text8"] as CrystalDecisions.CrystalReports.Engine.TextObject;
					//	crText.Text="date_2";
					//	crText=crDocument.ReportDefinition.ReportObjects["text9"] as CrystalDecisions.CrystalReports.Engine.TextObject;
					//	crText.Text="time_2";
				
					crText=crDocument.ReportDefinition.ReportObjects["text10"] as CrystalDecisions.CrystalReports.Engine.TextObject;
					crText.Text="Delivery Method";

				}
		*/

		public void Label_Item(string sItemID)
		{
			//string sReportPath=@"c:\work\sergei\work\crystal\reports\label_Item.rpt";
			string sReportPath=sReportsDir+@"label_item.rpt";

//			crDocument.Load(sReportPath);
			sPrinterName=GetPrinterName("Label_Item");

			DataSet dsTempSet=new DataSet();
			dsCrystalSet=new DataSet();

			DataSet dsRecvSet=new DataSet();
			dsRecvSet=gemoDream.Service.GetCrystalSet(sItemID,"Item");
			DataRow row=dsRecvSet.Tables[0].Rows[0];
			
			
			DataTable table=new DataTable("table");
			table.Columns.Add("barcode",System.Type.GetType("System.String"));
			table.Columns.Add("barcodeNum",System.Type.GetType("System.String"));
			table.Columns.Add("loadnum",System.Type.GetType("System.String"));
			table.Columns.Add("weight",System.Type.GetType("System.String"));
			DataRow tRow=table.NewRow();

			string sGroupCode=FillToFiveChars(row["GroupCode"].ToString());
			string sBatchID=FillToThreeChars(row["BatchCode"].ToString());
			string sItemCode=FillToTwoChars(row["ItemCode"].ToString());

			string sWeight=row["Weight"].ToString();

			DataSet dsMeasure;
			string sMeasureUnitName="";
			/*
						if(sWeight.Length>0)
						{
							dsMeasure=gemoDream.Service.GetCrystalSet(row["WeightUnitID"].ToString(),"MeasureUnit");
							sMeasureUnitName=dsMeasure.Tables[0].Rows[0]["MeasureUnitName"].ToString();
						}
			*/
			tRow[0]="*"+sGroupCode+sBatchID+sItemCode+"*";
			tRow[1]=sGroupCode+"."+sBatchID+"."+sItemCode;

			Trace.WriteLine(sGroupCode+"."+sGroupCode+sBatchID+sItemCode+"."+sItemCode);

			tRow[2]="";
			tRow[3]=sWeight;

			table.Rows.Add(tRow);
			dsTempSet.Tables.Add(table);

//			dsTempSet.Tables[0].TableName=crDocument.Database.Tables[0].Name;
			dsCrystalSet=dsTempSet;
//			crDocument.SetDataSource(dsCrystalSet);
		}

		public void Internal_Receipt(string sBatchID)
		{

			//string sReportPath=@"c:\work\sergei\work\crystal\reports\internal_receipt.rpt";
			string sReportPath=sReportsDir+@"internal_receipt.rpt";

//			crDocument.Load(sReportPath);
			sPrinterName=GetPrinterName("Internal_Receipt");
			DataSet dsTempSet=new DataSet();

			DataSet dsBatchSet=new DataSet();
			dsBatchSet=gemoDream.Service.GetCrystalSet(sBatchID,"Batch");
			DataSet dsCustomerSet=new DataSet();

			
			string sCustomerID=dsBatchSet.Tables[0].Rows[0]["CustomerOfficeID"].ToString()+"_"+
				dsBatchSet.Tables[0].Rows[0]["CustomerID"].ToString();
			

			dsCustomerSet=gemoDream.Service.GetCrystalSet(sCustomerID,"customer");
			
			string sBatchCode=FillToThreeChars(dsBatchSet.Tables[0].Rows[0]["BatchCode"].ToString());
			string sGroupCode=FillToFiveChars(dsBatchSet.Tables[0].Rows[0]["GroupCode"].ToString());
		
			DataSet dsAuthorSet=gemoDream.Service.GetCrystalSet(sBatchID,"BatchAuthor");
			DataSet dsItemTypeSet=gemoDream.Service.GetCrystalSet(dsBatchSet.Tables[0].Rows[0]["ItemTypeID"].ToString(),"ItemType");
			DataSet dsItemsSet=new DataSet();
			dsItemsSet.Tables.Add("ItemByCodeTypeEx");
			dsItemsSet=gemoDream.Service.GenericGetCrystalSet(dsItemsSet);

			DataSet dsOperationsSet=gemoDream.Service.GetCrystalSet(dsBatchSet.Tables[0].Rows[0]["CPOfficeID_CPID"].ToString(),"CPOperations");
			//	DataSet dsOperationsSet=gemoDream.Service.GetCrystalSet("1_47","CPOperations");
	
			dsItemsSet.Tables[0].Rows.Add(dsItemsSet.Tables[0].NewRow());
			dsItemsSet.Tables["ItemByCodeTypeEx"].Rows[0]["BatchCode"]=dsBatchSet.Tables[0].Rows[0]["BatchCode"];
			dsItemsSet.Tables["ItemByCodeTypeEx"].Rows[0]["GroupCode"]=dsBatchSet.Tables[0].Rows[0]["GroupCode"];

			//	dsItemsSet.Tables["ItemByCodeTypeEx"].Rows[0]["BatchCode"]="005";
			//	dsItemsSet.Tables["ItemByCodeTypeEx"].Rows[0]["GroupCode"]="1120";

			dsItemsSet.Tables[0].TableName="ItemByCode";
			dsItemsSet=gemoDream.Service.GenericGetCrystalSet(dsItemsSet);
		
			DataTable table=new DataTable("internal_receipt_header");

			table.Columns.Add("barcode",System.Type.GetType("System.String"));
			table.Columns.Add("barcode_num",System.Type.GetType("System.String"));
			table.Columns.Add("items",System.Type.GetType("System.String"));
			table.Columns.Add("date",System.Type.GetType("System.String"));
			table.Columns.Add("customer",System.Type.GetType("System.String"));
			table.Columns.Add("fio",System.Type.GetType("System.String"));
			table.Columns.Add("ext_num",System.Type.GetType("System.String"));
			table.Columns.Add("pic",System.Type.GetType("System.Byte[]"));
			
			Trace.WriteLine(sGroupCode+"."+sBatchCode);
    			
			DataRow tRow=table.NewRow();
			tRow[0]="*"+sGroupCode+sBatchCode+"*";
			tRow[1]=sGroupCode+"."+sBatchCode; //"barcode_num";
			tRow[2]=dsBatchSet.Tables[0].Rows[0]["ItemsQuantity"];  //"items";
			tRow[3]=dsBatchSet.Tables[0].Rows[0]["CreateDate"];  //"date";
			tRow[4]=dsCustomerSet.Tables[0].Rows[0]["CompanyName"];  //"customer";
			tRow[5]=dsAuthorSet.Tables[0].Rows[0]["FirstName"].ToString()+" "+dsAuthorSet.Tables[0].Rows[0]["LastName"].ToString(); //"fio"
			tRow[6]="ext. num";
			
			DataRow row1=dsItemTypeSet.Tables[0].Rows[0];
			
			Trace.WriteLine(row1["Image_Path2Picture"].ToString());
			Trace.WriteLine(row1["Path2Picture"].ToString());
			
			tRow[7]=DBNull.Value;
			try
			{
				DataSet dsShape=gemoDream.Service.GetShapeByCode(Convert.ToInt32(dsItemsSet.Tables[0].Rows[0]["Shape"]));
				tRow[7]=Convert.FromBase64String(dsShape.Tables[0].Rows[0]["Image_Path2Drawing"].ToString());
			}
			catch //(Exception exc)
			{
				Trace.WriteLine("Shape==null");
			}

			table.Rows.Add(tRow);

			DataTable table1=new DataTable("Internal_Reciept");
			table1.Columns.Add("number",System.Type.GetType("System.String"));
			table1.Columns.Add("lot_number",System.Type.GetType("System.String"));
			table1.Columns.Add("weight",System.Type.GetType("System.String"));
			table1.Columns.Add("operation",System.Type.GetType("System.String"));
			table1.Columns.Add("signature",System.Type.GetType("System.String"));
			table1.Columns.Add("fio",System.Type.GetType("System.String"));
			table1.Columns.Add("quantity",System.Type.GetType("System.String"));
			table1.Columns.Add("date",System.Type.GetType("System.String"));
			table1.Columns.Add("signature_2",System.Type.GetType("System.String"));
			

			DataRow tRow1=table1.NewRow();
			tRow1[0]="#";
			tRow1[1]="Lot #";
			tRow1[2]="Weight";
			tRow1[3]="Operation";
			tRow1[4]="Signature";   //empty
			tRow1[5]="Name";   //empty
			tRow1[6]="Quantity";  //empty    // в пустых полях должны быть "1"
			tRow1[7]="Date"; //empty
			tRow1[8]="Signature";  //empty
			table1.Rows.Add(tRow1);


			string sWeight="";

			for(int i=0;i<dsItemsSet.Tables[0].Rows.Count;i++)
			{
				DataRow row=table1.NewRow();
				row["number"]=(i+1).ToString();
				row["lot_number"]=dsItemsSet.Tables[0].Rows[i]["LotNumber"].ToString();
				
				if(dsItemsSet.Tables[0].Rows[i]["Weight"].ToString().Length>0)
					sWeight=dsItemsSet.Tables[0].Rows[i]["Weight"].ToString();
				else sWeight=" ";
				
				row["weight"]=sWeight;
				//	row["operation"]="operation";
				//	row["signature"]="1";
				row["fio"]="1";
				row["quantity"]="1";
				row["date"]="1";
				row["signature_2"]="1";
				table1.Rows.Add(row);
			}

			DataSet dsOperationSet=new DataSet();

			for(int i=0;i<dsOperationsSet.Tables[0].Rows.Count;i++)
			{
				dsOperationSet=gemoDream.Service.GetCrystalSet(dsOperationsSet.Tables[0].Rows[i]["OperationTypeOfficeID_OperationTypeID"].ToString(),"OperationType");

				table1.Rows[i+1]["operation"]=dsOperationSet.Tables[0].Rows[0]["OperationTypeName"].ToString();
				table1.Rows[i+1]["signature"]="1";
			}

			dsTempSet.Tables.Add(table);
			dsTempSet.Tables.Add(table1);

			
			dsCrystalSet=new DataSet();
			dsCrystalSet=dsTempSet;
//			crDocument.SetDataSource(dsCrystalSet);

		}

		public void Customer_Program(string sBatchCode, string sItemCode, string sShapeCode,string sGroupCode,string sPartName)
		{
			
			Trace.WriteLine("ShapeCode="+sShapeCode);

			//string sReportPath=@"c:\work\sergei\work\crystal\reports\customer_program.rpt";
			string sReportPath=sReportsDir+@"customer_program.rpt";
			
//			crDocument.Load(sReportPath);
			sPrinterName=GetPrinterName("Customer_Program");

			//DataSet dsBatchSet=gemoDream.Service.GetCrystalSet(sBatchID,"Batch");
			
			//DataSet dsItemsSet=new DataSet();
			//dsItemsSet.Tables.Add("ItemByCodeTypeEx");
			//dsItemsSet=gemoDream.Service.GenericGetCrystalSet(dsItemsSet);
						
			//dsItemsSet.Tables[0].Rows.Add(dsItemsSet.Tables[0].NewRow());
			//dsItemsSet.Tables["ItemByCodeTypeEx"].Rows[0]["BatchCode"]=dsBatchSet.Tables[0].Rows[0]["BatchCode"];
			//dsItemsSet.Tables["ItemByCodeTypeEx"].Rows[0]["GroupCode"]=dsBatchSet.Tables[0].Rows[0]["GroupCode"];
			//dsItemsSet.Tables[0].TableName="ItemByCode";
			//dsItemsSet=gemoDream.Service.GenericGetCrystalSet(dsItemsSet);
        
			DataSet dsTempSet=new DataSet();
			DataTable table=new DataTable("picreport");
			table.Columns.Add("text11",System.Type.GetType("System.String"));
			table.Columns.Add("text12",System.Type.GetType("System.String"));
			table.Columns.Add("pic1",System.Type.GetType("System.Byte[]"));
			
			table.Columns.Add("text21",System.Type.GetType("System.String"));
			table.Columns.Add("text22",System.Type.GetType("System.String"));
			table.Columns.Add("pic2",System.Type.GetType("System.Byte[]"));


			//DataSet dsItemTypeSet=gemoDream.Service.GetCrystalSet(dsBatchSet.Tables[0].Rows[0]["ItemTypeID"].ToString(),"ItemType");
		
			//DataRow row1=dsItemTypeSet.Tables[0].Rows[0];
			/*
			System.Drawing.Bitmap bitmap=new System.Drawing.Bitmap(gemoDream.Service.ExtractImageFromString(row1["Image_Path2Picture"].ToString(),row1["Path2Picture"].ToString()));
			System.IO.MemoryStream mem=new MemoryStream();
			bitmap.Save(mem,System.Drawing.Imaging.ImageFormat.Bmp);
			*/

			
			bool isPicture=false;
			byte [] picture=null;

			string sShape="";
			try
			{
				//DataSet dsShape=gemoDream.Service.GetShapeByCode(Convert.ToInt32(dsItemsSet.Tables[0].Rows[0]["Shape"]));
				DataSet dsShape=gemoDream.Service.GetShapeByCode(Convert.ToInt32(sShapeCode));
				picture=Convert.FromBase64String(dsShape.Tables[0].Rows[0]["Image_Path2Drawing"].ToString());
				sShape=dsShape.Tables[0].Rows[0]["LongReportName"].ToString();
				isPicture=true;
			}
			catch//(Exception exc)
			{
				Trace.WriteLine("Shape==null");
				isPicture=false;
			}
/*
			int iCount=0;
			for(;;)			
			{
				if(iCount==dsItemsSet.Tables[0].Rows.Count)
					break;

				DataRow tRow=table.NewRow();
				sItemCode=FillToTwoChars(dsItemsSet.Tables[0].Rows[iCount]["ItemCode"].ToString());
				tRow["text11"]="*"+sGroupCode+sBatchCode+sItemCode+"*";
				tRow["text12"]=sGroupCode+"."+sBatchCode+"."+sItemCode;
				//tRow["pic1"]=Convert.FromBase64String(row1["Image_Path2Picture"].ToString());
				if(isPicture)
					tRow["pic1"]=picture;
				else
					tRow["pic1"]=DBNull.Value;
				
		
				iCount++;
				
				if(iCount==dsItemsSet.Tables[0].Rows.Count)
				{
					tRow["text21"]=DBNull.Value;
					tRow["text22"]=DBNull.Value;
					if(isPicture)
                        tRow["pic2"]=picture;
					else 
						tRow["pic2"]=DBNull.Value;

					table.Rows.Add(tRow);
					break;
				}

				sItemCode=FillToTwoChars(dsItemsSet.Tables[0].Rows[iCount]["ItemCode"].ToString());
                tRow["text21"]="*"+sGroupCode+sGroupCode+sBatchCode+sItemCode+"*";
				tRow["text22"]=sGroupCode+"."+sGroupCode+"."+sBatchCode+"."+sItemCode;
				//tRow["pic2"]=Convert.FromBase64String(row1["Image_Path2Picture"].ToString());
				if(isPicture)
					tRow["pic2"]=picture;
				else 
					tRow["pic2"]=DBNull.Value;
				

				iCount++;
				table.Rows.Add(tRow);
			}
*/

			DataRow tRow=table.NewRow();
		//	sItemCode=FillToTwoChars(dsItemsSet.Tables[0].Rows[0]["ItemCode"].ToString());

			tRow["text11"]="*"+sGroupCode+sBatchCode+sItemCode+"*";
			tRow["text12"]=sGroupCode+"."+sBatchCode+"."+sItemCode;
			//tRow["pic1"]=Convert.FromBase64String(row1["Image_Path2Picture"].ToString());
			if(isPicture)
				tRow["pic1"]=picture;
			else
				tRow["pic1"]=DBNull.Value;
			table.Rows.Add(tRow);

			dsTempSet.Tables.Add(table);
			dsCrystalSet=new DataSet();
			dsCrystalSet=dsTempSet;

//			crDocument.SetDataSource(dsCrystalSet);
//
//			CrystalDecisions.CrystalReports.Engine.TextObject text;
//			text=crDocument.ReportDefinition.ReportObjects["text1"] as CrystalDecisions.CrystalReports.Engine.TextObject;
//			text.Text=sShape;
//			text=crDocument.ReportDefinition.ReportObjects["text2"] as CrystalDecisions.CrystalReports.Engine.TextObject;
//			text.Text=sPartName;

		}

		#endregion

		public void Batch(DataSet dsData)
		{
			
			//string sReportPath=@"c:\work\sergei\work\crystal\reports\batch.rpt";
			string sReportPath=sReportsDir+@"batch.rpt";
//			crDocument.Load(sReportPath);
			sPrinterName=GetPrinterName("Batch");

			DataSet dsTempSet=new DataSet();

			DataTable table=new DataTable("batchorder");
			table.Columns.Add("order",System.Type.GetType("System.String"));
			table.Columns.Add("ordernum",System.Type.GetType("System.String"));
			
			DataRow tRow=table.NewRow();
			tRow[0]=dsData.Tables["tblOrder"].Rows[0]["Name"];
			tRow[1]=dsData.Tables["tblOrder"].Rows[0]["Name"];
			
			table.Rows.Add(tRow);
			dsTempSet.Tables.Add(table);


			DataTable table1=new DataTable("batch");
			table1.Columns.Add("id",System.Type.GetType("System.String"));
			table1.Columns.Add("batchid",System.Type.GetType("System.String"));
			table1.Columns.Add("text",System.Type.GetType("System.String"));
			
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

			

			dsTempSet.Tables.Add(table1);

			dsCrystalSet=new DataSet();
			dsCrystalSet=dsTempSet;
//			crDocument.SetDataSource(dsCrystalSet);

		}

		public void Account_Representative_Label(string sGroupCode, string sBatchCode, string sBatchID, string sItemCode,string sNewBatchID,string sNewItemCode)
		{
			//string sReportPath=@"c:\work\sergei\work\crystal\reports\account_rep_label.rpt";
			string sReportPath=sReportsDir+@"account_rep_label.rpt";
//			crDocument.Load(sReportPath);
			sPrinterName=GetPrinterName("Account_Rep_Label");
			DataSet dsItemSet=new DataSet();
			dsItemSet=gemoDream.Service.GetCrystalSet(sBatchID+"_"+sItemCode,"Item");

			
			DataSet dsIn=new DataSet();
			dsIn.Tables.Add("PartValueTypeEx");
			DataSet dsOut=gemoDream.Service.GenericGetCrystalSet(dsIn);
			dsOut.Tables[0].Rows.Add(dsOut.Tables[0].NewRow());
			dsOut.Tables[0].Rows[0]["BatchID"]=sNewBatchID;
			//dsOut.Tables[0].Rows[0]["BatchID"]=13;
			dsOut.Tables[0].Rows[0]["RecheckNumber"]=-1;
			dsOut.Tables[0].Rows[0]["ViewAccessCode"]=DBNull.Value;
			dsOut.Tables[0].Rows[0]["ItemCode"]=sNewItemCode;
			dsOut.Tables[0].TableName="PartValue";

			
			DataSet dsPartValue=gemoDream.Service.GenericGetCrystalSet(dsOut);

			int iRowColor=0;
			int iRowClarity=0;
			bool isRowColor=false;
			bool isRowClarity=false;
			
			//batch=13 / 60;
			//item=1;

			for(int i=0;i<dsPartValue.Tables[0].Rows.Count;i++)
			{
				if(isRowColor&isRowClarity) break;

				if(System.Int32.Parse(dsPartValue.Tables[0].Rows[i]["MeasureCode"].ToString())==27)
				{
					iRowColor=i;
					isRowColor=true;
				}
				if(System.Int32.Parse(dsPartValue.Tables[0].Rows[i]["MeasureCode"].ToString())==29)
				{
					iRowClarity=i;
					isRowClarity=true;
				}

			}
	
			string sColor="";
			string sClarity="";
			if(dsPartValue.Tables[0].Rows.Count>0)
			{
				sColor=dsPartValue.Tables[0].Rows[iRowColor]["MeasureValueName"].ToString();
				sClarity=dsPartValue.Tables[0].Rows[iRowClarity]["MeasureValueName"].ToString();
			}

			DataSet dsTempSet=new DataSet();
			DataTable table=new DataTable("parsel_label");

			table.Columns.Add("barcode",System.Type.GetType("System.String"));
			table.Columns.Add("barcodenum",System.Type.GetType("System.String"));
			table.Columns.Add("carat weight",System.Type.GetType("System.String"));
			table.Columns.Add("color",System.Type.GetType("System.String"));
			table.Columns.Add("clarity",System.Type.GetType("System.String"));
			
			DataRow tRow=table.NewRow();
			
			sGroupCode=FillToFiveChars(sGroupCode);
			sBatchCode=FillToThreeChars(sBatchCode);
			sItemCode=FillToTwoChars(sItemCode);

			tRow[0]="*"+sGroupCode+sBatchCode+sItemCode+"*";
			tRow[1]=sGroupCode+"."+sBatchCode+"."+sItemCode;
			
			tRow[2]=dsItemSet.Tables[0].Rows[0]["Weight"].ToString()+"ct"+" (twt)";//"carat weight";
			tRow[3]=sColor;//"color";
			tRow[4]=sClarity;//"clarity";
	
			table.Rows.Add(tRow);
			dsTempSet.Tables.Add(table);
			dsCrystalSet=dsTempSet;
//			dsCrystalSet.Tables[0].TableName=crDocument.Database.Tables[0].Name;

			string sShapeCode=dsItemSet.Tables[0].Rows[0]["Shape"].ToString();
			DataSet dsShape=new DataSet();

			try
			{
				dsShape=gemoDream.Service.GetShapeByCode(Convert.ToInt32(sShapeCode));
			}
			catch
			{}

			
//			CrystalDecisions.CrystalReports.Engine.TextObject crText;
//			crText=crDocument.ReportDefinition.ReportObjects["text1"] as CrystalDecisions.CrystalReports.Engine.TextObject;
////			if(dsShape.Tables.Count>0)
//				crText.Text=dsShape.Tables[0].Rows[0]["Short_Report_Name"].ToString();
//			else 
//				crText.Text="";
//
//			crDocument.SetDataSource(dsCrystalSet);

		}
		
	
		public void Items_Selected(string sItemsNum)
		{
			string sReportPath=sReportsDir+@"items_selected.rpt";
			//string sReportPath=@"c:\work\sergei\work\crystal\reports\items_selected.rpt";
//			crDocument.Load(sReportPath);
			sPrinterName=GetPrinterName("Items_Selected");
//			CrystalDecisions.CrystalReports.Engine.TextObject crText;
//			crText=crDocument.ReportDefinition.ReportObjects["itemsNum"] as CrystalDecisions.CrystalReports.Engine.TextObject;
//			crText.Text=sItemsNum;

		}


		public void PDF_Report(string sTemplatePath,int iGroupCode, int iBatchCode, int iItemCode)
		{
			//string sReportName=System.IO.Path.GetFileName(sTemplatePath);

			
			
		}

		public void PDF_ReportSrv(string sTemplatePath, DataSet dsBatch, DataSet dsItem, DataSet dsItemType, DataSet dsShape)
		{
			//string sReportName=System.IO.Path.GetFileName(sTemplatePath);

			
			
		}
		
//		public CrystalDecisions.CrystalReports.Engine.ReportDocument GetReportDocument()
//		{
//			return crDocument;
//		}

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

			switch(sExt)
			{
				case "pdf":ExportToPDF(sExportDocPath); break;
				case "rtf":ExportToRTF(sExportDocPath); break;
			}
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
					catch //(Exception ex)
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

			switch(sExt)
			{
				case "pdf":ExportToPDF(sExportDocPath); break;
				case "rtf":ExportToRTF(sExportDocPath); break;
			}
		}

		
		#region PDF_Templates
		
	
		#region ClientTemplates

	
		public System.Drawing.Image mFile;

	
		#endregion 
		
		#region ServiceTemplates
	
		#endregion


		#endregion
		
		private void ExportToPDF(string pdfFileName)
		{
//			CrystalDecisions.Shared.ExportOptions exportOptions=new CrystalDecisions.Shared.ExportOptions();
//			CrystalDecisions.Shared.DiskFileDestinationOptions diskFileOptions=new CrystalDecisions.Shared.DiskFileDestinationOptions();
//			exportOptions=crDocument.ExportOptions;
//			exportOptions.ExportFormatType=CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;
//			exportOptions.ExportDestinationType=CrystalDecisions.Shared.ExportDestinationType.DiskFile;
//			diskFileOptions.DiskFileName=pdfFileName;
//			exportOptions.DestinationOptions=diskFileOptions;
//			crDocument.Export();		
		}

		private void ExportToRTF(string rtfFileName)
		{
			
//			CrystalDecisions.Shared.ExportOptions exportOptions=new CrystalDecisions.Shared.ExportOptions();
//			CrystalDecisions.Shared.DiskFileDestinationOptions diskFileOptions=new CrystalDecisions.Shared.DiskFileDestinationOptions();
//			exportOptions=crDocument.ExportOptions;
//			exportOptions.ExportFormatType=CrystalDecisions.Shared.ExportFormatType.RichText;
//			exportOptions.ExportDestinationType=CrystalDecisions.Shared.ExportDestinationType.DiskFile;
//			diskFileOptions.DiskFileName=rtfFileName;
//			exportOptions.DestinationOptions=diskFileOptions;
//			crDocument.Export();		
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
		
		private static System.Drawing.Image ExtractImageFromString(string sImage, string sImageFileName)
		{
			byte[] buf = Convert.FromBase64String(sImage);
			int wmfI = sImageFileName.LastIndexOf(".wmf");
			int emfI = sImageFileName.LastIndexOf(".emf");
			if (wmfI > 0 && wmfI == sImageFileName.Length-4 || emfI > 0 && emfI == sImageFileName.Length-4)
			{
				return new System.Drawing.Imaging.Metafile(new System.IO.MemoryStream(buf, 0, buf.Length));
			}
			else
			{
				return new System.Drawing.Bitmap(new System.IO.MemoryStream(buf, 0, buf.Length));
			}
		}

		private string GetPrinterName(string sReportName)
		{
			string sPrinter="";

			/*
				try
				{
					string sXmlPath=sReportsDir+@"Printers.xml";
					System.Xml.XmlDocument doc=new System.Xml.XmlDocument();
					doc.Load(sXmlPath);
					System.Xml.XmlNodeList nodes=doc.GetElementsByTagName(sReportName);
					sPrinter=nodes[0].InnerText.ToString().Trim();
				}
				catch(Exception exc)
				{
					System.Drawing.Printing.PrinterSettings ps=new System.Drawing.Printing.PrinterSettings();
					sPrinter=ps.PrinterName;
					System.Diagnostics.Trace.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!default!!!!!!!!!!!");
				}

				return sPrinter;
			*/
			Trace.WriteLine(System.IO.Directory.GetCurrentDirectory());
			Trace.WriteLine("report="+sReportName);

			string sXmlPath=gemoDream.Service.sAppDir+@"\printers.xml";
			System.Xml.XmlDocument doc=new System.Xml.XmlDocument();
			try
			{	
				Trace.WriteLine(sXmlPath);
				doc.Load(sXmlPath);
			}
			catch //(Exception exc)
			{
				Trace.WriteLine("Failed to load printers.xml");
			}

			try
			{
				System.Xml.XmlNodeList nodes=doc.GetElementsByTagName(sReportName);
				sPrinter=nodes[0].InnerText.ToString().Trim();
			}
			catch //(Exception exc)
			{
				System.Drawing.Printing.PrinterSettings ps=new System.Drawing.Printing.PrinterSettings();
				sPrinter=ps.PrinterName;
				System.Diagnostics.Trace.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!default!!!!!!!!!!!");
			}
			return sPrinter;

		}

		private Stream StreamImageFile(string sFileName)
		{
			return new FileStream(sFileName, FileMode.Open, FileAccess.Read);
			
		}


		private void debug_DataSet(DataSet dsData)
		{
			foreach(DataTable table in dsData.Tables)
			{
				Trace.WriteLine("--------"+"Table:"+table.TableName.ToString()+"------------");
				foreach(DataColumn col in table.Columns)
					Trace.WriteLine(col.Caption.ToString());
				
			}
		}

	}
}


