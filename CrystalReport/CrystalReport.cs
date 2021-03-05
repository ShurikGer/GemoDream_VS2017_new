using System;
using System.Diagnostics;
using System.Data;
using Microsoft.Win32;
using System.IO;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Collections;
using System.Xml;
//using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System.Drawing;
using System.Drawing.Printing;
using gemoDream;
using System.Data.OleDb;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Fields;
using Spire.Pdf.Widget;
using Spire.Pdf.Barcode;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using System.Drawing.Imaging;

namespace CrystalReport
{
    public enum TakeInType
    {
        ShipReceivingPickedUpByOurMessenger,
        ShipReceiving,
        TakeIn,
        TakeInPickedUpByOurMessenger
    };


    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class CrystalReport
    {
        private System.Data.DataSet dsCrystalSet;
        private readonly string sReportsDir;
        //		private CrystalDecisions.CrystalReports.Engine.ReportDocument crDocument;
        private string sExportDocPath = "";
        private string sExportDocExt = "";
        private string sPrinterName = "";
		private readonly Log log;
        public bool isView = false;
        private System.Data.DataTable dtXL = new System.Data.DataTable();
        public bool isEdit = false;
        public int ipdfEditID = 0;
        private DataSet dsFormats;
        //		private Excel.Application objExcel;
        //		private Excel.Workbook BookTemp;
        private Excel.Application objExcel;
        private Excel._Workbook BookTemp;
		private bool skipErrors = false;
		public static XmlDocument xmlLabels;
		public CrystalReport(string sReportsDirectory)
        {
            //			crDocument=new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            sReportsDir = sReportsDirectory;
            //			log=new Log(sReportsDirectory + "print.log"); commented 03/07/08

            //Global variable containing formats for measures output
            //By 3ter on 2006.04.20
            dsFormats = gemoDream.Service.GetMeasuresFormats();
        }
        public CrystalReport(string sReportsDirectory, bool excel)
        {
            //			crDocument=new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            sReportsDir = sReportsDirectory;
            //			log=new Log(sReportsDirectory+"print.log"); commented 03/07/08

            //Global variable containing formats for measures output
            //By 3ter on 2006.04.20
            //dsFormats = gemoDream.Service.GetMeasuresFormats();
            if (excel)
            {
                //if (objExcel == null)
                //				Client.KillOpenExcel();

                //				objExcel = new Excel.Application();
                objExcel = new Excel.Application();
                Client.MyActiveReportName = "";
            }
        }


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

        public void Front_TakeIn_Label(string sID)
        {
            string sReportPath = sReportsDir + @"front_takeIn_label.rpt";

            //			string sReportPath= Client.GetOfficeDirPath("repDir") + @"front_takeIn_label.rpt";
            sPrinterName = GetPrinterName("Front_TakeIn_Label");
            //			crDocument.Load(sReportPath);

            //by vetal_242 07.10.2006
            DataSet dsMemoNumber = gemoDream.Service.GetGroupMemoNumbers(sID.Split('_')[1]);

            DataSet dsGroup = gemoDream.Service.GetCrystalSet(sID, "GroupWithCustomer");
            DataRow rGroup = dsGroup.Tables[0].Rows[0];
            DataSet dsServiceType = gemoDream.Service.GetCrystalSet(rGroup["ServiceTypeID"].ToString(), "ServiceType");

            string sDelim = "_";
            char[] cDelim = sDelim.ToCharArray();
            string[] split = sID.Split(cDelim);
            string sBatchCode = FillToThreeChars(split[0]);
            string sGroupCode = rGroup["GroupCode"].ToString();

            sGroupCode = FillToFiveChars(sGroupCode);


            DataTable tblMeasure = gemoDream.Service.GetMeasureUnits();

            string sDate = dsGroup.Tables[0].Rows[0]["CreateDate"].ToString();
            System.DateTime ddDate = System.DateTime.Parse(sDate);

            //			CrystalDecisions.CrystalReports.Engine.TextObject crText;
            //			crText=crDocument.ReportDefinition.ReportObjects["text1"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			crText.Text="*"+sGroupCode+"*"; //barcode
            //			crText=crDocument.ReportDefinition.ReportObjects["text2"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			crText.Text=sGroupCode; //barcode
            //			crText=crDocument.ReportDefinition.ReportObjects["text4"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			crText.Text=ddDate.Date.ToShortDateString();
            //			//System.DateTime.Now.Date.ToShortDateString(); //date
            //			crText=crDocument.ReportDefinition.ReportObjects["text5"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			crText.Text=ddDate.TimeOfDay.ToString();
            //			//System.DateTime.Now.ToShortTimeString();// time
            //
            //			crText=crDocument.ReportDefinition.ReportObjects["text7"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			crText.Text=rGroup["ExtPhone"].ToString(); //ext. phone
            //			crText=crDocument.ReportDefinition.ReportObjects["text8"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			crText.Text=rGroup["CustomerName"].ToString();  //"Customer";
            //			crText=crDocument.ReportDefinition.ReportObjects["text20"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			crText.Text="00.00.0000"; // due date
            //			crText=crDocument.ReportDefinition.ReportObjects["text19"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			crText.Text="00:00"; // due time


            string sWeight = "";
            string sInspWeightWord = "";
            bool isWeight = false;

            if (rGroup["InspectedTotalWeight"] != DBNull.Value)
            {
                isWeight = true;
                sInspWeightWord = "inspected";
                sWeight = rGroup["InspectedTotalWeight"].ToString() + " ";
                DataRow[] rMeasureName = tblMeasure.Select("MeasureUnitID=" + rGroup["InspectedWeightUnitID"].ToString());
                sWeight += rMeasureName[0]["MeasureUnitName"].ToString();
            }
            if (rGroup["NotInspectedTotalWeight"] != DBNull.Value)
            {
                isWeight = true;
                sInspWeightWord = "not inspected";
                sWeight = rGroup["NotInspectedTotalWeight"].ToString() + " ";
                DataRow[] rMeasureName = tblMeasure.Select("MeasureUnitID=" + rGroup["NotInspectedWeightUnitID"].ToString());
                sWeight += rMeasureName[0]["MeasureUnitName"].ToString();
            }


            string sQuantity = "";
            string sInspQuantWord = "";
            bool isQuantity = false;

            if (rGroup["InspectedQuantity"] != DBNull.Value)
            {
                isQuantity = true;
                sInspQuantWord = "inspected";
                sQuantity = rGroup["InspectedQuantity"].ToString();

            }
            if (rGroup["NotInspectedQuantity"] != DBNull.Value)
            {
                isQuantity = true;
                sInspQuantWord = "not inspected";
                sQuantity = rGroup["NotInspectedQuantity"].ToString();
            }


            //			if(isQuantity)
            //			{
            //				crText=crDocument.ReportDefinition.ReportObjects["text10"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //				crText.Text=sQuantity; // quantity number
            //				crText=crDocument.ReportDefinition.ReportObjects["text21"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //				crText.Text=sInspQuantWord; // quantity "insp" word
            //			}
            //			else 
            //			{
            //				crText=crDocument.ReportDefinition.ReportObjects["text10"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //				crText.Text=""; // quantity number
            //				crText=crDocument.ReportDefinition.ReportObjects["text21"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //				crText.Text=""; // quantity "insp" word
            //				crText=crDocument.ReportDefinition.ReportObjects["text9"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //				crText.Text=""; // "number of items" word
            //			}
            //
            //			if(isWeight)
            //			{
            //				crText=crDocument.ReportDefinition.ReportObjects["text12"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //				crText.Text=sWeight; // weight number
            //				crText=crDocument.ReportDefinition.ReportObjects["text22"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //				crText.Text=sInspWeightWord; // weight "insp" word
            //			}
            //			else
            //			{
            //				crText=crDocument.ReportDefinition.ReportObjects["text12"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //				crText.Text=""; // weight number
            //				crText=crDocument.ReportDefinition.ReportObjects["text22"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //				crText.Text=""; // weight "insp" word
            //				crText=crDocument.ReportDefinition.ReportObjects["text11"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //				crText.Text=""; // "total weight" word
            //			}

            //by vetal_242 07.10.2006
            //print group memoNumbers
            if (dsMemoNumber.Tables[0].Rows.Count != 0)
            {
                for (int i = 0; i < System.Math.Min(8, dsMemoNumber.Tables[0].Rows.Count); i++)
                {
                    int index = 30 + i;
                    //					crText=crDocument.ReportDefinition.ReportObjects["text" + index.ToString()] as CrystalDecisions.CrystalReports.Engine.TextObject;
                    //					crText.Text=dsMemoNumber.Tables[0].Rows[i]["Name"].ToString();
                }
            }

        }

        public void Front_TakeIn(string sGroupID, TakeInType type)
        {
            string sReportPath = sReportsDir + @"Front_TakeIn_External_Receipt.rpt";

            sPrinterName = GetPrinterName("Front_TakeIn_External_Receipt");
            //			crDocument.Load(sReportPath);
			DataSet dsMemoNumbers = gemoDream.Service.GetGroupMemoNumbers(sGroupID.Split('_')[1]);

            DataSet dsGroup = gemoDream.Service.GetCrystalSet(sGroupID, "GroupWithCustomer");
            DataRow rGroup = dsGroup.Tables[0].Rows[0];

            //debug_DataSet(dsGroup);
            gemoDream.Service.Debug_DiaspalyDataSet(dsGroup);

            string sDelim = "_";
            char[] cDelim = sDelim.ToCharArray();
            string[] split = sGroupID.Split(cDelim);
            string sBatchCode = FillToThreeChars(split[0]);
            string sGroupCode = rGroup["GroupCode"].ToString();

            sGroupCode = FillToFiveChars(sGroupCode);
            DataTable tblMeasure = gemoDream.Service.GetMeasureUnits();

            string sDate = dsGroup.Tables[0].Rows[0]["CreateDate"].ToString();
            System.DateTime ddDate = System.DateTime.Parse(sDate);
            //
            //			CrystalDecisions.CrystalReports.Engine.TextObject crText;
            //			crText=crDocument.ReportDefinition.ReportObjects["text12"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			crText.Text="*"+sGroupCode+"*"; //barcode
            //			crText=crDocument.ReportDefinition.ReportObjects["text13"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			crText.Text=sGroupCode; //barcode
            //			crText=crDocument.ReportDefinition.ReportObjects["text3"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			crText.Text=ddDate.Date.ToShortDateString();//System.DateTime.Now.Date.ToShortDateString(); //date
            //			crText=crDocument.ReportDefinition.ReportObjects["text4"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			crText.Text=ddDate.TimeOfDay.ToString();//System.DateTime.Now.ToShortTimeString();// time
            //			crText=crDocument.ReportDefinition.ReportObjects["text14"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			crText.Text=rGroup["CustomerName"].ToString();  //"Customer";
            //

            //external_receipt pic
            /*
            DataSet dataSet=new DataSet();
            DataTable table=new DataTable("external_receipt");
            table.Columns.Add("pic",System.Type.GetType("System.Byte[]"));
            DataRow row=table.NewRow();

            try
            {
                DataSet dsPic = gemoDream.Service.GetItemCPPictureByCode(dsItemsSet.Tables[0].Rows[0]["GroupCode"].ToString(),
                    dsItemsSet.Tables[0].Rows[0]["BatchCode"].ToString(),dsItemsSet.Tables[0].Rows[0]["ItemCode"].ToString());
					
                row[0]=Convert.FromBase64String(dsPic.Tables[0].Rows[0]["Image_Path2Picture"].ToString());
					
			
            }
            catch(Exception exc)
            {
                Trace.WriteLine("Shape==null");
            }
*/

            string sWeight = "";
            string sInspWeightWord = "";
            bool isWeight = false;

            if (rGroup["InspectedTotalWeight"] != DBNull.Value)
            {
                isWeight = true;
                sInspWeightWord = "inspected";
                sWeight = rGroup["InspectedTotalWeight"].ToString() + " ";
                DataRow[] rMeasureName = tblMeasure.Select("MeasureUnitID=" + rGroup["InspectedWeightUnitID"].ToString());
                sWeight += rMeasureName[0]["MeasureUnitName"].ToString();
            }
            if (rGroup["NotInspectedTotalWeight"] != DBNull.Value)
            {
                isWeight = true;
                sInspWeightWord = "not inspected";
                sWeight = rGroup["NotInspectedTotalWeight"].ToString() + " ";
                DataRow[] rMeasureName = tblMeasure.Select("MeasureUnitID=" + rGroup["NotInspectedWeightUnitID"].ToString());
                sWeight += rMeasureName[0]["MeasureUnitName"].ToString();
            }

            string sQuantity = "";
            string sInspQuantWord = "";
            bool isQuantity = false;

            if (rGroup["InspectedQuantity"] != DBNull.Value)
            {
                isQuantity = true;
                sInspQuantWord = "inspected";
                sQuantity = rGroup["InspectedQuantity"].ToString();

            }
            if (rGroup["NotInspectedQuantity"] != DBNull.Value)
            {
                isQuantity = true;
                sInspQuantWord = "not inspected";
                sQuantity = rGroup["NotInspectedQuantity"].ToString();
            }



            if (isQuantity)
            {
                //				crText=crDocument.ReportDefinition.ReportObjects["text6"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                //				crText.Text=sQuantity; // quantity number
                //				crText=crDocument.ReportDefinition.ReportObjects["text5"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                //				crText.Text="Number of items ("+sInspQuantWord+")"; // quantity "insp" word
            }
            else
            {
                //				crText=crDocument.ReportDefinition.ReportObjects["text5"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                //				crText.Text=""; // quantity number
                //				crText=crDocument.ReportDefinition.ReportObjects["text6"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                //				crText.Text=""; // quantity "insp" word
            }

            if (isWeight)
            {
                //				crText=crDocument.ReportDefinition.ReportObjects["text8"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                //				crText.Text=sWeight; // weight number
                //				crText=crDocument.ReportDefinition.ReportObjects["text7"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                //				crText.Text="Total weight ("+sInspWeightWord+")"; // weight "insp" word
            }
            else
            {
                //				crText=crDocument.ReportDefinition.ReportObjects["text8"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                //				crText.Text=""; // weight number
                //				crText=crDocument.ReportDefinition.ReportObjects["text7"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                //				crText.Text=""; // weight "insp" word
            }
            /*
            bool IsPickedUp = true;
            if (IsPickedUp)
            {
                crText=crDocument.ReportDefinition.ReportObjects["text39"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                crText.Text="cool!";
            }
            else
            {
                crText=crDocument.ReportDefinition.ReportObjects["text39"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                crText.Text="cool!";
            }
            */


            /*
            table.Rows.Add(row);

            dsCrystalSet=new DataSet();
            dsCrystalSet=dataSet;
            crDocument.SetDataSource(dsCrystalSet);
            */

            //		debug_Row(rGroup);

            //			crText=crDocument.ReportDefinition.ReportObjects["text15"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			crText.Text=rGroup["Address1"].ToString()+" "+rGroup["Address2"].ToString();  //"StreetName";
            //
            //			crText=crDocument.ReportDefinition.ReportObjects["text16"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			crText.Text=rGroup["City"].ToString()+","+rGroup["USStateName"].ToString() + "," + rGroup["Country"];  //"City, State";
            //
            //			crText=crDocument.ReportDefinition.ReportObjects["text17"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			crText.Text=rGroup["Zip1"].ToString()+"-"+rGroup["Zip2"].ToString();  //"City, State";
            //
            //			crText=crDocument.ReportDefinition.ReportObjects["text18"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			crText.Text=rGroup["CountryPhoneCode"].ToString()+" "+rGroup["Phone"].ToString();
            //
            //			crText=crDocument.ReportDefinition.ReportObjects["text19"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			crText.Text=rGroup["CountryFaxCode"].ToString()+" "+rGroup["Fax"].ToString();

            DataSet dsAuthor = gemoDream.Service.GetCrystalSet(sGroupID, "GroupAuthor");
            Debug_DataSet(dsAuthor);

            switch (type)
            {
                case TakeInType.TakeIn:
                    {
                        //					crText=crDocument.ReportDefinition.ReportObjects["text20"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                        //					crText.Text="";
                        //					crText=crDocument.ReportDefinition.ReportObjects["text21"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                        //					crText.Text="";

                        string sPersonID = dsGroup.Tables[0].Rows[0]["PersonID"].ToString();
                        string sPersonCustomerID = dsGroup.Tables[0].Rows[0]["PersonCustomerID"].ToString();
                        string sPersonCustomerOfficeID = dsGroup.Tables[0].Rows[0]["PersonCustomerOfficeID"].ToString();
                        //vetal_242 27.06.2006
                        //error conver string to int in database, when string = ""
                        if (sPersonID == "")
                            sPersonID = null;
                        if (sPersonCustomerID == "")
                            sPersonCustomerID = null;
                        if (sPersonCustomerOfficeID == "")
                            sPersonCustomerOfficeID = null;
                        DataSet dsMess = gemoDream.Service.GetPerson(sPersonID, sPersonCustomerID,
                            sPersonCustomerOfficeID);

                        string s1 = "";
                        string s2 = "";

                        if (dsMess.Tables[0].Rows.Count > 0)
                        {
                            s1 = dsMess.Tables[0].Rows[0]["FirstName"].ToString();
                            s2 = dsMess.Tables[0].Rows[0]["LastName"].ToString();
                        }

                        //					crText=crDocument.ReportDefinition.ReportObjects["text39"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                        //					crText.Text=s1 + " " + s2;
                        //
                        //					crText=crDocument.ReportDefinition.ReportObjects["text41"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                        //					crText.Text="";
                        //
                        //					crText=crDocument.ReportDefinition.ReportObjects["text43"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                        //					crText.Text="";
                        //					crText=crDocument.ReportDefinition.ReportObjects["text44"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                        //					crText.Text="";
                        break;
                    }
                case TakeInType.TakeInPickedUpByOurMessenger:
                    {
                        //					crText=crDocument.ReportDefinition.ReportObjects["text20"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                        //					crText.Text="";
                        //					crText=crDocument.ReportDefinition.ReportObjects["text21"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                        //					crText.Text="";
                        //
                        //					crText=crDocument.ReportDefinition.ReportObjects["text38"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                        //					crText.Text = "";
                        //					crText=crDocument.ReportDefinition.ReportObjects["text39"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                        //					crText.Text = "";
                        //					//crText.Text=s1 + " " + s2;
                        //
                        //					//crText=crDocument.ReportDefinition.ReportObjects["text41"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                        //					//crText.Text="";
                        //
                        //					crText=crDocument.ReportDefinition.ReportObjects["text43"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                        //					crText.Text="";
                        //					crText=crDocument.ReportDefinition.ReportObjects["text44"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                        //					crText.Text="";
                        break;
                        /*
                        //crText=crDocument.ReportDefinition.ReportObjects["text20"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                        //crText.Text="";
                        crText=crDocument.ReportDefinition.ReportObjects["text21"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                        crText.Text=dsAuthor.Tables[0].Rows[0]["FirstName"].ToString()+" "+dsAuthor.Tables[0].Rows[0]["LastName"];

                        crText=crDocument.ReportDefinition.ReportObjects["text43"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                        crText.Text="Received via [carrier name]";

                        crText=crDocument.ReportDefinition.ReportObjects["text44"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                        crText.Text="with [carrier name] tracking number [tracking number]";

                        //crText=crDocument.ReportDefinition.ReportObjects["text41"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                        //crText.Text="";
                        */
                        break;
                    }
                case TakeInType.ShipReceiving:
                    {
                        //					crText=crDocument.ReportDefinition.ReportObjects["text20"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                        //					crText.Text="";
                        //					crText=crDocument.ReportDefinition.ReportObjects["text21"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                        //					crText.Text="";
                        //
                        //					crText=crDocument.ReportDefinition.ReportObjects["text38"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                        //					crText.Text = "";
                        //					crText=crDocument.ReportDefinition.ReportObjects["text39"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                        //					crText.Text = "";
                        //
                        //					crText=crDocument.ReportDefinition.ReportObjects["text41"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                        //					crText.Text = "";
                        //
                        sGroupID = dsGroup.Tables[0].Rows[0]["GroupID"].ToString();
                        string sGroupOfficeID = dsGroup.Tables[0].Rows[0]["GroupOfficeID"].ToString();
                        DataSet dsCarrier = gemoDream.Service.GetCarrier(sGroupOfficeID, sGroupID);
                        string sCarrierName = dsCarrier.Tables[0].Rows[0]["CarrierName"].ToString();
                        string sCarrierTrackingNumber = dsCarrier.Tables[0].Rows[0]["CarrierTrackingNumber"].ToString();
                        //					crText=crDocument.ReportDefinition.ReportObjects["text43"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                        //					crText.Text="Received via " + sCarrierName;
                        //					crText=crDocument.ReportDefinition.ReportObjects["text44"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                        //					crText.Text="with " + sCarrierName + " tracking number " + sCarrierTrackingNumber;
                        break;
                    }
                case TakeInType.ShipReceivingPickedUpByOurMessenger:
                    {
                        //					crText=crDocument.ReportDefinition.ReportObjects["text20"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                        //					crText.Text="";
                        //					crText=crDocument.ReportDefinition.ReportObjects["text21"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                        //					crText.Text="";
                        //
                        //					crText=crDocument.ReportDefinition.ReportObjects["text38"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                        //					crText.Text = "";
                        //					crText=crDocument.ReportDefinition.ReportObjects["text39"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                        //					crText.Text = "";

                        //crText=crDocument.ReportDefinition.ReportObjects["text41"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                        //crText.Text = "";

                        //					crText=crDocument.ReportDefinition.ReportObjects["text38"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                        //					crText.Text="";
                        //					crText=crDocument.ReportDefinition.ReportObjects["text39"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                        //					crText.Text="";

                        sGroupID = dsGroup.Tables[0].Rows[0]["GroupID"].ToString();
                        string sGroupOfficeID = dsGroup.Tables[0].Rows[0]["GroupOfficeID"].ToString();
                        DataSet dsCarrier = gemoDream.Service.GetCarrier(sGroupOfficeID, sGroupID);
                        string sCarrierName = dsCarrier.Tables[0].Rows[0]["CarrierName"].ToString();
                        string sCarrierTrackingNumber = dsCarrier.Tables[0].Rows[0]["CarrierTrackingNumber"].ToString();
                        //					crText=crDocument.ReportDefinition.ReportObjects["text43"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                        //					crText.Text="Received via " + sCarrierName;
                        //					crText=crDocument.ReportDefinition.ReportObjects["text44"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                        //					crText.Text="with " + sCarrierName + " tracking number " + sCarrierTrackingNumber;
                        break;
                    }
            }

            /*
            crText=crDocument.ReportDefinition.ReportObjects["text20"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                crText.Text="";
            //else

            crText=crDocument.ReportDefinition.ReportObjects["text21"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            if (bPickedUpByOurMessenger)
                crText.Text=dsAuthor.Tables[0].Rows[0]["FirstName"].ToString()+" "+dsAuthor.Tables[0].Rows[0]["LastName"];
            else
                crText.Text="";
                

            crText=crDocument.ReportDefinition.ReportObjects["text39"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            crText.Text="???";
                //dsAuthor.Tables[0].Rows[0]["FirstName"].ToString()+" "+dsAuthor.Tables[0].Rows[0]["LastName"];
            */

            //			crText=crDocument.ReportDefinition.ReportObjects["text23"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			crText.Text=dsAuthor.Tables[0].Rows[0]["FirstName"].ToString()+" "+dsAuthor.Tables[0].Rows[0]["LastName"];

            if (rGroup["SpecialInstruction"].ToString() != "")
            {
                //				crText=crDocument.ReportDefinition.ReportObjects["text10"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                //				crText.Text=rGroup["SpecialInstruction"].ToString();
            }
            else
            {
                //				crText=crDocument.ReportDefinition.ReportObjects["text10"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                //				crText.Text="";
                //				crText=crDocument.ReportDefinition.ReportObjects["text9"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                //				crText.Text="";
            }

            //			crText=crDocument.ReportDefinition.ReportObjects["text24"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			crText.Text="";
            //			crText=crDocument.ReportDefinition.ReportObjects["text25"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			crText.Text="";
            //			crText=crDocument.ReportDefinition.ReportObjects["text26"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			crText.Text="";
            //			crText=crDocument.ReportDefinition.ReportObjects["text27"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			crText.Text="";

            //if(rGroup["Memo"].ToString()!="")
            //by vetal_242 10.07.2006
            if (dsMemoNumbers.Tables[0].Rows.Count != 0)
            {
                for (int i = 0; i < System.Math.Min(9, dsMemoNumbers.Tables[0].Rows.Count); i++)
                {
                    int index = 52 + i;
                    //					crText=crDocument.ReportDefinition.ReportObjects["text" + index.ToString()] as CrystalDecisions.CrystalReports.Engine.TextObject;
                    //					crText.Text = dsMemoNumbers.Tables[0].Rows[i]["Name"].ToString();
                }
            }

            //			crText=crDocument.ReportDefinition.ReportObjects["text32"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			crText.Text="";
            //			crText=crDocument.ReportDefinition.ReportObjects["text33"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			crText.Text="";
            //			crText=crDocument.ReportDefinition.ReportObjects["text34"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			crText.Text="";
            //			crText=crDocument.ReportDefinition.ReportObjects["text35"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			crText.Text="";
            //			crText=crDocument.ReportDefinition.ReportObjects["text36"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			crText.Text="";
            //			crText=crDocument.ReportDefinition.ReportObjects["text37"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			crText.Text="";
        }



        public void Label_Batch(string sBatchID)
        {
            string sReportPath;

            DataSet dsBatch = gemoDream.Service.GetCrystalSet(sBatchID, "BatchWithCustomer");

            DataTable dtItems = gemoDream.Service.GetItemByCode(dsBatch.Tables[0].Rows[0]["GroupCode"].ToString(),
                dsBatch.Tables[0].Rows[0]["BatchCode"].ToString(),
                null);

            StringBuilder sbOldNumbers = new StringBuilder("");

            if (dtItems.Rows[0]["PrevGroupCode"].ToString() != "")
            {
                sReportPath = sReportsDir + @"label_batch_on.rpt";
                foreach (DataRow drItem in dtItems.Rows)
                {
                    if (sbOldNumbers.Length != 0) sbOldNumbers.Append(" ");
                    sbOldNumbers.Append(FillToFiveChars(drItem["PrevGroupCode"].ToString()) + "." + FillToThreeChars(drItem["PrevBatchCode"].ToString()) + "." +
                        FillToTwoChars(drItem["PrevItemCode"].ToString()));
                }
            }
            else
            {
                sReportPath = sReportsDir + @"label_batch.rpt";
            }
            //string sReportPath="";

            sPrinterName = GetPrinterName("Label_Batch");

            //			crDocument.Load(sReportPath);

            DataSet dsGroup = gemoDream.Service.GetCrystalSet(dsBatch.Tables[0].Rows[0]["GroupOfficeID_GroupID"].ToString(), "GroupWithCustomer");
            DataRow rGroup = dsGroup.Tables[0].Rows[0];
            DataSet dsServiceType = gemoDream.Service.GetCrystalSet(rGroup["ServiceTypeID"].ToString(), "ServiceType");

            DataRow rBatch = dsBatch.Tables[0].Rows[0];

            string sDeliveryMethod = "";
            string sAccount = "";
            string sCarrier = "";

            if (rBatch["WeCarry"].ToString() == "1")
            {
                sDeliveryMethod = "We Carry";
            }

            if (rBatch["TheyCarry"].ToString() == "1")
            {
                sDeliveryMethod = "They Carry";
            }

            if (rBatch["WeShipCarry"].ToString() == "1")
            {
                sDeliveryMethod = "We Ship Carry";
                try
                {
                    sAccount = rBatch["Account"].ToString();
                    DataSet dsCustomerTypeEx = gemoDream.Service.GetCustomerTypeEx();
                    DataTable tblCarriers = dsCustomerTypeEx.Tables["Carriers"].Copy();
                    DataRow[] rCarrier = tblCarriers.Select("CarrierID=" + rBatch["CarrierID"]);
                    sCarrier = rCarrier[0]["CarrierName"].ToString();
                    sDeliveryMethod = "We Use Their Account To Ship";
                }
                catch
                {
                    sAccount = "";
                    sCarrier = "";
                }
                /*
                    sDeliveryMethod="We Use Their Account To Ship";
                    sAccount=rBatch["Account"].ToString();
                    DataSet dsCustomerTypeEx=gemoDream.Service.GetCustomerTypeEx();
                    DataTable tblCarriers=dsCustomerTypeEx.Tables["Carriers"].Copy();
                    DataRow []rCarrier= tblCarriers.Select("CarrierID="+rBatch["CarrierID"]);
                    sCarrier=rCarrier[0]["CarrierName"].ToString();
                    */
            }

            string sBatchCode = FillToThreeChars(rBatch["BatchCode"].ToString());
            string sGroupCode = FillToFiveChars(rBatch["GroupCode"].ToString());

            //			CrystalDecisions.CrystalReports.Engine.TextObject crText;
            //			crText=crDocument.ReportDefinition.ReportObjects["text1"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			crText.Text="*"+sGroupCode+sBatchCode+"*"; //barcode
            //			crText=crDocument.ReportDefinition.ReportObjects["text2"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			crText.Text=sGroupCode;
            //			crText=crDocument.ReportDefinition.ReportObjects["text3"] as CrystalDecisions.CrystalReports.Engine.TextObject;			
            //			crText.Text=sGroupCode+"."+sBatchCode; //barcode

            Trace.WriteLine(sGroupCode + "." + sBatchCode);

            //			crText=crDocument.ReportDefinition.ReportObjects["text8"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			crText.Text=rBatch["CustomerName"].ToString();  //"Customer";
            //
            //			crText=crDocument.ReportDefinition.ReportObjects["text10"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			crText.Text=rBatch["ItemsQuantity"].ToString(); //"# of items";

            if (sbOldNumbers.Length > 0)
            {
                //				crText=crDocument.ReportDefinition.ReportObjects["items"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                //				crText.Text = sbOldNumbers.ToString();//OldNumbers
            }

            //			crText=crDocument.ReportDefinition.ReportObjects["text17"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			crText.Text=sDeliveryMethod;//delivery method
            //			crText=crDocument.ReportDefinition.ReportObjects["text16"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			crText.Text=sCarrier;//Carrier
            //			crText=crDocument.ReportDefinition.ReportObjects["text21"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			crText.Text=sAccount;//Account #
            //
            //			crText=crDocument.ReportDefinition.ReportObjects["text23"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			crText.Text=rBatch["MemoNumber"].ToString();  //"MemoNumber";
            //
            //			
            //			crText=crDocument.ReportDefinition.ReportObjects["text12"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			if(rBatch["ItemsWeight"].ToString()!="")
            //				crText.Text=rBatch["ItemsWeight"].ToString()+" ct."; //weight
            //			else 
            //				crText.Text="";


            string sDate = dsBatch.Tables[0].Rows[0]["CreateDate"].ToString();
            System.DateTime ddDate = System.DateTime.Parse(sDate);

            //			crText=crDocument.ReportDefinition.ReportObjects["text4"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			crText.Text=ddDate.Date.ToShortDateString();
            //			//System.DateTime.Now.Date.ToShortDateString(); //date
            //			crText=crDocument.ReportDefinition.ReportObjects["text5"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			crText.Text=ddDate.TimeOfDay.ToString();
            //			//System.DateTime.Now.ToShortTimeString();// time
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
            //            
            //			crText=crDocument.ReportDefinition.ReportObjects["text20"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			crText.Text="00.00.0000"; //date

            //Vetal_242 21.06.2006
            //crText=crDocument.ReportDefinition.ReportObjects["text6"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //crText.Text = GetCheckedOperations(sBatchID);
            //crDocument.SetDataSource(GetCheckedOperations(sBatchID).Tables[0]);
            if (!(sbOldNumbers.Length > 0))
            {
                DataTable dtCheckedOperations = GetCheckedOperations(sBatchID);
                if (dtCheckedOperations.Rows.Count > 0)
                {
                    for (int i = 0; i < System.Math.Min(dtCheckedOperations.Rows.Count, 10); i++)
                    {
                        if (i == 0)
                        {
                            //							crText=crDocument.ReportDefinition.ReportObjects["text29"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                            //							crText.Text = dtCheckedOperations.Rows[i][0].ToString();
                        }
                        else //if(i>0 && i<10)
                        {
                            int index = (31 + i * 2);
                            string textObjectIndex = "text" + index.ToString();
                            //							crText=crDocument.ReportDefinition.ReportObjects[textObjectIndex] as CrystalDecisions.CrystalReports.Engine.TextObject;
                            //							crText.Text = dtCheckedOperations.Rows[i][0].ToString();
                        }
                        //					else
                        //					{
                        //						crText=crDocument.ReportDefinition.ReportObjects["text61"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                        //						crText.Text = dtCheckedOperations.Rows[i][0].ToString();
                        //					}
                    }
                }
            }
            try
            {
                //				crText = crDocument.ReportDefinition.ReportObjects["text25"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                //				crText.Text = dsServiceType.Tables[0].Rows[0]["ServiceTypeName"].ToString();
            }
            catch { }

        }


        public void Label_Item(string sItemID)
        {

            //string sReportPath=@"c:\work\sergei\work\crystal\reports\label_Item.rpt";
            string sReportPath = sReportsDir + @"label_item.rpt";

            //			crDocument.Load(sReportPath);
            sPrinterName = GetPrinterName("Label_Item");

            DataSet dsTempSet = new DataSet();
            dsCrystalSet = new DataSet();

            DataSet dsRecvSet = new DataSet();
            dsRecvSet = gemoDream.Service.GetCrystalSet(sItemID, "Item");
            DataRow row = dsRecvSet.Tables[0].Rows[0];

            DataTable table = new DataTable("table");
            table.Columns.Add("barcode", System.Type.GetType("System.String"));
            table.Columns.Add("barcodeNum", System.Type.GetType("System.String"));
            table.Columns.Add("loadnum", System.Type.GetType("System.String"));
            table.Columns.Add("weight", System.Type.GetType("System.String"));
            table.Columns.Add("sku", System.Type.GetType("System.String"));
            DataRow tRow = table.NewRow();

            string sGroupCode = FillToFiveChars(row["GroupCode"].ToString());
            string sBatchID = FillToThreeChars(row["BatchCode"].ToString());
            string sItemCode = FillToTwoChars(row["ItemCode"].ToString());

            string sOldGroupCode = FillToFiveChars(row["PrevGroupCode"].ToString());
            string sOldBatchCode = FillToThreeChars(row["PrevBatchCode"].ToString());
            string sOldItemCode = FillToTwoChars(row["PrevItemCode"].ToString());

            string sWeight = row["Weight"].ToString();

            DataSet dsMeasure;
            string sMeasureUnitName = "";
            /*
                            if(sWeight.Length>0)
                            {
                                dsMeasure=gemoDream.Service.GetCrystalSet(row["WeightUnitID"].ToString(),"MeasureUnit");
                                sMeasureUnitName=dsMeasure.Tables[0].Rows[0]["MeasureUnitName"].ToString();
                            }
                */
            tRow[0] = "*" + sGroupCode + sBatchID + sItemCode + "*";

            string sOldNumber = "";
            if (sOldGroupCode != "00000" && sOldBatchCode != "000" && sOldItemCode != "00")
                sOldNumber = "(" + sOldGroupCode + "." + sOldBatchCode + "." + sOldItemCode + ")";

            tRow[1] = sGroupCode + "." + sBatchID + "." + sItemCode + sOldNumber;

            Trace.WriteLine(sGroupCode + "." + sGroupCode + sBatchID + sItemCode + "." + sItemCode);

            tRow[2] = "";
            tRow[3] = sWeight;
            tRow["sku"] = "SKU: " + row["CustomerProgramName"].ToString();

            table.Rows.Add(tRow);
            dsTempSet.Tables.Add(table);

            //			dsTempSet.Tables[0].TableName=crDocument.Database.Tables[0].Name;
            dsCrystalSet = dsTempSet;
            //			crDocument.SetDataSource(dsCrystalSet);



        }

        /// <summary>
        /// get checked operations for printing Label_Batch.rpt vetal_242 20.06.2006
        /// </summary>
        /// <param name="BatchID"></param>
        /// <returns></returns>
        private DataTable GetCheckedOperations(String BatchID)
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add("NameCheckedOperationByBatchID");
            dsData.Tables[0].Columns.Add("BatchID");
            dsData.Tables[0].Rows.Add(dsData.Tables[0].NewRow());
            dsData.Tables[0].Rows[0][0] = BatchID;
            dsData = gemoDream.Service.GetNameCheckedOperationByBatchID(dsData);

            //			DataTable table1=new DataTable("Internal_Reciept");
            //			table1.Columns.Add("operation",System.Type.GetType("System.String"));
            //			table1.Columns.Add("signature",System.Type.GetType("System.String"));

            //			DataRow tRow1=table1.NewRow();
            //			tRow1[0]="Operation";
            //			tRow1[1]="Signature";   //empty
            //			table1.Rows.Add(tRow1);

            //			DataSet dsOperationSet=new DataSet();
            //
            //			for(int i=0;i<dsData.Tables[0].Rows.Count;i++)
            //			{
            //				if(i<25)
            //				{
            //					table1.Rows.Add(table1.NewRow());
            //					table1.Rows[i+1]["operation"]=dsData.Tables[0].Rows[i][0].ToString();
            //					table1.Rows[i+1]["signature"]="1";
            //				}
            //			}
            //
            //			DataSet dsTempSet=new DataSet();	
            //			dsTempSet.Tables.Add(table1);
            return dsData.Tables[0];
        }

        public void Internal_Receipt(string sBatchID)
        {

            //string sReportPath=@"c:\work\sergei\work\crystal\reports\internal_receipt.rpt";
            string sReportPath = sReportsDir + @"internal_receipt.rpt";

            //			crDocument.Load(sReportPath);
            sPrinterName = GetPrinterName("Internal_Receipt");
            DataSet dsTempSet = new DataSet();

            DataSet dsBatchSet = new DataSet();
            dsBatchSet = gemoDream.Service.GetCrystalSet(sBatchID, "BatchWithCustomer");
            DataSet dsCustomerSet = new DataSet();


            string sCustomerID = dsBatchSet.Tables[0].Rows[0]["CustomerOfficeID"].ToString() + "_" +
                dsBatchSet.Tables[0].Rows[0]["CustomerID"].ToString();


            dsCustomerSet = gemoDream.Service.GetCrystalSet(sCustomerID, "customer");

            string sBatchCode = FillToThreeChars(dsBatchSet.Tables[0].Rows[0]["BatchCode"].ToString());
            string sGroupCode = FillToFiveChars(dsBatchSet.Tables[0].Rows[0]["GroupCode"].ToString());

            DataSet dsAuthorSet = gemoDream.Service.GetCrystalSet(sBatchID, "BatchAuthor");
            DataSet dsItemTypeSet = gemoDream.Service.GetCrystalSet(dsBatchSet.Tables[0].Rows[0]["ItemTypeID"].ToString(), "ItemType");
            DataSet dsItemsSet = new DataSet();
            dsItemsSet.Tables.Add("ItemByCodeTypeEx");

            dsItemsSet = gemoDream.Service.GenericGetCrystalSet(dsItemsSet);


            DataSet dsOperationsSet = gemoDream.Service.GetCrystalSet(dsBatchSet.Tables[0].Rows[0]["CPOfficeID_CPID"].ToString(), "CPOperations");
            //	DataSet dsOperationsSet=gemoDream.Service.GetCrystalSet("1_47","CPOperations");

            dsItemsSet.Tables[0].Rows.Add(dsItemsSet.Tables[0].NewRow());
            dsItemsSet.Tables["ItemByCodeTypeEx"].Rows[0]["BatchCode"] = dsBatchSet.Tables[0].Rows[0]["BatchCode"];
            dsItemsSet.Tables["ItemByCodeTypeEx"].Rows[0]["GroupCode"] = dsBatchSet.Tables[0].Rows[0]["GroupCode"];

            //	dsItemsSet.Tables["ItemByCodeTypeEx"].Rows[0]["BatchCode"]="005";
            //	dsItemsSet.Tables["ItemByCodeTypeEx"].Rows[0]["GroupCode"]="1120";

            dsItemsSet.Tables[0].TableName = "ItemByCode";
            dsItemsSet = gemoDream.Service.GenericGetCrystalSet(dsItemsSet);

            DataSet dsGroup = gemoDream.Service.GetCrystalSet(dsBatchSet.Tables[0].Rows[0]["GroupOfficeID_GroupID"].ToString(), "Group");


            DataTable table = new DataTable("internal_receipt_header");


            table.Columns.Add("barcode", System.Type.GetType("System.String"));
            table.Columns.Add("barcode_num", System.Type.GetType("System.String"));
            table.Columns.Add("items", System.Type.GetType("System.String"));
            table.Columns.Add("date", System.Type.GetType("System.String"));
            table.Columns.Add("customer", System.Type.GetType("System.String"));
            table.Columns.Add("fio", System.Type.GetType("System.String"));
            table.Columns.Add("ext_num", System.Type.GetType("System.String"));
            table.Columns.Add("pic", System.Type.GetType("System.Byte[]"));

            Trace.WriteLine(sGroupCode + "." + sBatchCode);

            DataRow tRow = table.NewRow();
            tRow[0] = "*" + sGroupCode + sBatchCode + "*";
            tRow[1] = sGroupCode + "." + sBatchCode; //"barcode_num";
            tRow[2] = dsBatchSet.Tables[0].Rows[0]["ItemsQuantity"];  //"items";
            tRow[3] = dsBatchSet.Tables[0].Rows[0]["CreateDate"];  //"date";
            tRow[4] = dsCustomerSet.Tables[0].Rows[0]["CompanyName"].ToString() + "," + dsCustomerSet.Tables[0].Rows[0]["CustomerCode"].ToString();  //"customer";
            tRow[5] = dsAuthorSet.Tables[0].Rows[0]["FirstName"].ToString() + " " + dsAuthorSet.Tables[0].Rows[0]["LastName"].ToString(); //"fio"
            tRow[6] = "";//"ext. num";

            DataRow row1 = dsItemTypeSet.Tables[0].Rows[0];

            Trace.WriteLine(row1["Image_Path2Picture"].ToString());
            Trace.WriteLine(row1["Path2Picture"].ToString());

            tRow[7] = DBNull.Value;


            try
            {
                //DataSet dsShape=gemoDream.Service.GetShapeByCode(Convert.ToInt32(dsItemsSet.Tables[0].Rows[0]["Shape"]));
                //tRow[7]=Convert.FromBase64String(dsShape.Tables[0].Rows[0]["Image_Path2Drawing"].ToString());


                DataSet dsPic = gemoDream.Service.GetItemCPPictureByCode(dsItemsSet.Tables[0].Rows[0]["GroupCode"].ToString(),
                                                                            dsItemsSet.Tables[0].Rows[0]["BatchCode"].ToString());
                System.Drawing.Image imPic = (System.Drawing.Image)gemoDream.Service.ExtractImageFromString(dsPic.Tables[0].Rows[0]["Image_Path2Picture"].ToString(),
                    dsPic.Tables[0].Rows[0]["Path2Picture"].ToString());

                System.IO.MemoryStream mem = new MemoryStream();

                string sExt = System.IO.Path.GetExtension(dsPic.Tables[0].Rows[0]["Path2Picture"].ToString());
                if (sExt == "ico")
                    imPic.Save(mem, System.Drawing.Imaging.ImageFormat.Icon);//  System.Drawing.Imaging.ImageFormat.Jpeg);
                else
                    imPic.Save(mem, System.Drawing.Imaging.ImageFormat.Jpeg);

                tRow[7] = mem.GetBuffer();

                /*		
                    System.Drawing.Image imPic = (System.Drawing.Image)gemoDream.Service.ExtractImageFromString(dsPic.Tables[0].Rows[0]["Image_Path2Picture"].ToString(),
                        dsPic.Tables[0].Rows[0]["Path2Picture"].ToString());
                    imPic.Save(@"c:\1.ico",System.Drawing.Imaging.ImageFormat.Icon);
                    System.IO.FileStream fs=new FileStream(@"c:\1.ico",System.IO.FileMode.Open);
                    byte [] byteArr=new byte[fs.Length];
                    fs.Read(byteArr,0,(int)fs.Length);
                    fs.Close();
                    */


            }
            catch (Exception exc)
            {
                Trace.WriteLine("Shape==null");
            }

            table.Rows.Add(tRow);

            DataTable table1 = new DataTable("Internal_Reciept");
            table1.Columns.Add("number", System.Type.GetType("System.String"));
            table1.Columns.Add("lot_number", System.Type.GetType("System.String"));
            table1.Columns.Add("weight", System.Type.GetType("System.String"));
            table1.Columns.Add("operation", System.Type.GetType("System.String"));
            table1.Columns.Add("signature", System.Type.GetType("System.String"));
            table1.Columns.Add("fio", System.Type.GetType("System.String"));
            table1.Columns.Add("quantity", System.Type.GetType("System.String"));
            table1.Columns.Add("date", System.Type.GetType("System.String"));
            table1.Columns.Add("signature_2", System.Type.GetType("System.String"));


            DataRow tRow1 = table1.NewRow();
            tRow1[0] = "#";
            tRow1[1] = "Lot #";
            tRow1[2] = "Weight";
            tRow1[3] = "Operation";
            tRow1[4] = "Signature";   //empty
            tRow1[5] = "Name";   //empty
            tRow1[6] = "Quantity";  //empty    // в пустых пол€х должны быть "1"
            tRow1[7] = "Date"; //empty
            tRow1[8] = "Signature";  //empty
            table1.Rows.Add(tRow1);


            string sWeight = "";

            //			CrystalDecisions.CrystalReports.Engine.TextObject crText;

            if (dsGroup.Tables[0].Rows[0]["SpecialInstruction"].ToString() != "")
            {
                //				crText=crDocument.ReportDefinition.ReportObjects["text6"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                //				crText.Text=dsGroup.Tables[0].Rows[0]["SpecialInstruction"].ToString();
            }
            else
            {
                //				crText=crDocument.ReportDefinition.ReportObjects["text5"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                //				crText.Text="";
                //				crText=crDocument.ReportDefinition.ReportObjects["text6"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                //				crText.Text="";

            }

            if (dsGroup.Tables[0].Rows[0]["Memo"].ToString() != "")
            {
                //				crText=crDocument.ReportDefinition.ReportObjects["text8"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                //				crText.Text=dsGroup.Tables[0].Rows[0]["Memo"].ToString(); //memotext
            }
            else
            {
                //				crText=crDocument.ReportDefinition.ReportObjects["text7"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                //				crText.Text=""; //memotext
                //				crText=crDocument.ReportDefinition.ReportObjects["text8"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                //				crText.Text=""; //memo
            }

            //			crText=crDocument.ReportDefinition.ReportObjects["text4"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			crText.Text=dsBatchSet.Tables[0].Rows[0]["CustomerProgramName"].ToString(); //customer program


            DataSet dsOperationSet = new DataSet();

            for (int i = 0; i < 25; i++)
            {


                DataRow row = table1.NewRow();
                if (i < dsItemsSet.Tables[0].Rows.Count)
                {
                    row["number"] = (i + 1).ToString();
                    row["lot_number"] = dsItemsSet.Tables[0].Rows[i]["LotNumber"].ToString();

                    if (dsItemsSet.Tables[0].Rows[i]["Weight"].ToString().Length > 0)
                        sWeight = dsItemsSet.Tables[0].Rows[i]["Weight"].ToString();
                    else sWeight = " ";

                    row["weight"] = sWeight;
                }
                else
                {
                    row["number"] = "1";
                    row["lot_number"] = "1";
                    row["weight"] = "1";
                }


                row["operation"] = "1";
                row["signature"] = "1";
                row["fio"] = "1";
                row["quantity"] = "1";
                row["date"] = "1";
                row["signature_2"] = "1";
                table1.Rows.Add(row);
            }

            for (int i = 0; i < dsOperationsSet.Tables[0].Rows.Count; i++)
            {
                if (i < 25)
                {
                    dsOperationSet = gemoDream.Service.GetCrystalSet(dsOperationsSet.Tables[0].Rows[i]["OperationTypeOfficeID_OperationTypeID"].ToString(), "OperationType");

                    table1.Rows[i + 1]["operation"] = dsOperationSet.Tables[0].Rows[0]["OperationTypeName"].ToString();
                    table1.Rows[i + 1]["signature"] = "1";
                }
            }


            dsTempSet.Tables.Add(table);
            dsTempSet.Tables.Add(table1);


            dsCrystalSet = new DataSet();
            dsCrystalSet = dsTempSet;
            //			crDocument.SetDataSource(dsCrystalSet);

        }



        public void Customer_Program(string sBatchCode, string sItemCode, string sShapeCode, string sGroupCode)
        {
            Trace.WriteLine("ShapeCode" + sShapeCode);
            //string sReportPath=@"c:\work\sergei\work\crystal\reports\customer_program.rpt";
            string sReportPath = sReportsDir + @"customer_program.rpt";

            //			crDocument.Load(sReportPath);
            sPrinterName = GetPrinterName("Customer_Program");

            //DataSet dsBatchSet=gemoDream.Service.GetCrystalSet(sBatchID,"Batch");

            //DataSet dsItemsSet=new DataSet();
            //dsItemsSet.Tables.Add("ItemByCodeTypeEx");
            //dsItemsSet=gemoDream.Service.GenericGetCrystalSet(dsItemsSet);

            //dsItemsSet.Tables[0].Rows.Add(dsItemsSet.Tables[0].NewRow());
            //dsItemsSet.Tables["ItemByCodeTypeEx"].Rows[0]["BatchCode"]=dsBatchSet.Tables[0].Rows[0]["BatchCode"];
            //dsItemsSet.Tables["ItemByCodeTypeEx"].Rows[0]["GroupCode"]=dsBatchSet.Tables[0].Rows[0]["GroupCode"];
            //dsItemsSet.Tables[0].TableName="ItemByCode";
            //dsItemsSet=gemoDream.Service.GenericGetCrystalSet(dsItemsSet);

            /*	
                DataSet dsBatch=new DataSet();
                dsBatch=gemoDream.Service.GetCrystalSet(sGroupCode+"_"+sBatchCode,"BatchByCode2");
                dsItem=gemoDream.Service.GetCrystalSet(dsBatch.Tables[0].Rows[0]["BatchID"].ToString()+"_"+iItemCode.ToString(),"Item");
    */

            DataSet dsTempSet = new DataSet();
            DataTable table = new DataTable("picreport");
            table.Columns.Add("text11", System.Type.GetType("System.String"));
            table.Columns.Add("text12", System.Type.GetType("System.String"));
            table.Columns.Add("pic1", System.Type.GetType("System.Byte[]"));

            table.Columns.Add("text21", System.Type.GetType("System.String"));
            table.Columns.Add("text22", System.Type.GetType("System.String"));
            table.Columns.Add("pic2", System.Type.GetType("System.Byte[]"));


            //DataSet dsItemTypeSet=gemoDream.Service.GetCrystalSet(dsBatchSet.Tables[0].Rows[0]["ItemTypeID"].ToString(),"ItemType");

            //DataRow row1=dsItemTypeSet.Tables[0].Rows[0];
            /*
            System.Drawing.Bitmap bitmap=new System.Drawing.Bitmap(gemoDream.Service.ExtractImageFromString(row1["Image_Path2Picture"].ToString(),row1["Path2Picture"].ToString()));
            System.IO.MemoryStream mem=new MemoryStream();
            bitmap.Save(mem,System.Drawing.Imaging.ImageFormat.Bmp);
            */


            bool isPicture = false;
            byte[] picture = null;

            string sShape = "";
            try
            {
                DataSet dsShape = gemoDream.Service.GetShapeByCode(Convert.ToInt32(sShapeCode));
                sShape = dsShape.Tables[0].Rows[0]["LongReportName"].ToString();
                picture = Convert.FromBase64String(dsShape.Tables[0].Rows[0]["Image_Path2Drawing"].ToString());
                isPicture = true;
            }
            catch
            {
                Trace.WriteLine("Shape==null");
                isPicture = false;
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

            DataRow tRow = table.NewRow();
            //	sItemCode=FillToTwoChars(dsItemsSet.Tables[0].Rows[0]["ItemCode"].ToString());

            tRow["text11"] = "*" + sGroupCode + sBatchCode + sItemCode + "*";
            tRow["text12"] = sGroupCode + "." + sBatchCode + "." + sItemCode;
            //tRow["pic1"]=Convert.FromBase64String(row1["Image_Path2Picture"].ToString());
            if (isPicture)
                tRow["pic1"] = picture;
            else
                tRow["pic1"] = DBNull.Value;
            table.Rows.Add(tRow);

            dsTempSet.Tables.Add(table);
            dsCrystalSet = new DataSet();
            dsCrystalSet = dsTempSet;
            //			crDocument.SetDataSource(dsCrystalSet);


            //			CrystalDecisions.CrystalReports.Engine.TextObject text;
            //			text=crDocument.ReportDefinition.ReportObjects["text1"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			text.Text=sShape;
            //			text=crDocument.ReportDefinition.ReportObjects["text2"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			text.Text="";


        }

        public void Batch(DataSet dsData)
        {

            //string sReportPath=@"c:\work\sergei\work\crystal\reports\batch.rpt";
            string sReportPath = sReportsDir + @"batch.rpt";
            //			crDocument.Load(sReportPath);
            //sPrinterName = GetPrinterName("Batch");

            DataSet dsTempSet = new DataSet();
            DataTable table1 = new DataTable("batch");
            table1.Columns.Add("id", System.Type.GetType("System.String"));
            table1.Columns.Add("batchid", System.Type.GetType("System.String"));
            table1.Columns.Add("itemnumber", System.Type.GetType("System.String"));
            table1.Columns.Add("Color", System.Type.GetType("System.String"));
            table1.Columns.Add("Clarity", System.Type.GetType("System.String"));
            table1.Columns.Add("Measurments", System.Type.GetType("System.String"));


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
            for (int i = 0; i < dsData.Tables["tblItem"].Rows.Count; i++)
            {
                DataRow tRow1 = table1.NewRow();
                tRow1["id"] = i.ToString();
                tRow1["batchid"] = FillToFiveChars(dsData.Tables["tblItem"].Rows[i]["OrderCode"].ToString()) + FillToThreeChars(dsData.Tables["tblItem"].Rows[i]["BatchCode"].ToString());
                tRow1["itemnumber"] = dsData.Tables["tblItem"].Rows[i]["Name"].ToString().Replace(".", "");
                tRow1["Color"] = dsData.Tables["tblItem"].Rows[i]["Color"].ToString();
                tRow1["Clarity"] = dsData.Tables["tblItem"].Rows[i]["Clarity"].ToString();
                tRow1["Measurments"] = dsData.Tables["tblItem"].Rows[i]["Dimensions"].ToString();
                table1.Rows.Add(tRow1);
            }


            dsTempSet.Tables.Add(table1);

            dsCrystalSet = new DataSet();
            dsCrystalSet = dsTempSet;
            //			crDocument.SetDataSource(dsCrystalSet);

            //			CrystalDecisions.CrystalReports.Engine.TextObject text;
            //			text=crDocument.ReportDefinition.ReportObjects["text3"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			text.Text=dsData.Tables["tblItem"].Rows[0]["CustomerName"].ToString();
            //			text=crDocument.ReportDefinition.ReportObjects["text5"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			text.Text=dsData.Tables["tblItem"].Rows[0]["CustomerCode"].ToString();
            //			text=crDocument.ReportDefinition.ReportObjects["text7"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			text.Text=FillToFiveChars(dsData.Tables["tblItem"].Rows[0]["OrderCode"].ToString());



        }




        /**
         * this function make dataset for printing from defineDocument
         * vetal_242 
         * 01.03.2006
         * */
        public void Account_Representative_Label(DataRow drDoc, string sBatchID, string sNewBatchID, string sItemCode, string sNewItemCode, string sGroupCode, string sBatchCode)
        {
            string sReportPath;
            //Load templete

            sReportPath = sReportsDir + drDoc["CorelFile"];
            try
            {
                //				crDocument.Load(sReportPath);
            }
            catch (Exception ex)
            {
                throw new Exception("Template was not found at " + sReportPath + "\nPlease make sure the file exists at specified location.");
            }
            sPrinterName = GetPrinterName("Account_Rep_Label");

            DataTable table = new DataTable("parsel_label");

            //DataSet for print
            table.Columns.Add("barcode", System.Type.GetType("System.String"));
            table.Columns.Add("barcodenum", System.Type.GetType("System.String"));
            table.Columns.Add("carat weight", System.Type.GetType("System.String"));
            table.Columns.Add("color", System.Type.GetType("System.String"));
            table.Columns.Add("clarity", System.Type.GetType("System.String"));
            table.Columns.Add("isPrinted", System.Type.GetType("System.String"));
            table.Rows.Add(table.NewRow());

            sGroupCode = FillToFiveChars(sGroupCode);
            sBatchCode = FillToThreeChars(sBatchCode);
            sItemCode = FillToTwoChars(sItemCode);

            DataSet dsItemSet = new DataSet();
            dsItemSet = gemoDream.Service.GetCrystalSet(sNewBatchID + "_" + sNewItemCode, "Item");

            string sOldGroupCode = FillToFiveChars(dsItemSet.Tables[0].Rows[0]["PrevGroupCode"].ToString());
            string sOldBatchCode = FillToThreeChars(dsItemSet.Tables[0].Rows[0]["PrevBatchCode"].ToString());
            string sOldItemCode = FillToTwoChars(dsItemSet.Tables[0].Rows[0]["PrevItemCode"].ToString());

            if (sOldGroupCode != "00000" && sOldBatchCode != "000" && sOldItemCode != "00")
            {
                table.Rows[0]["barcode"] = "*" + sOldGroupCode + sOldBatchCode + sOldItemCode + "*";
                table.Rows[0]["barcodenum"] = sOldGroupCode + "." + sOldBatchCode + "." + sOldItemCode + "(" + sGroupCode + "." + sBatchCode + "." + sItemCode + ")";
            }
            else
            {
                table.Rows[0]["barcode"] = "*" + sGroupCode + sBatchCode + sItemCode + "*";
                table.Rows[0]["barcodenum"] = sGroupCode + "." + sBatchCode + "." + sItemCode;
            }

            DataSet dsMeasureValue = new DataSet();
            DataSet dsResults = new DataSet();
            dsMeasureValue.Tables.Add("MeasureValueByPart");
            dsMeasureValue.Tables[0].Columns.Add("BatchID");
            dsMeasureValue.Tables[0].Columns.Add("ItemCode");
            dsMeasureValue.Tables[0].Columns.Add("PartName");
            dsMeasureValue.Tables[0].Columns.Add("MeasureName");
            dsMeasureValue.Tables[0].Columns.Add("CutGrade");
            dsMeasureValue.Tables[0].Rows.Add(dsMeasureValue.Tables[0].NewRow());

            dsMeasureValue.Tables[0].Rows[0]["BatchID"] = sNewBatchID;
            dsMeasureValue.Tables[0].Rows[0]["ItemCode"] = sNewItemCode;
            dsMeasureValue.Tables[0].Rows[0]["CutGrade"] = 0;

            //get Measures for print from tblDocumentValues
            DataSet dsDocsValue = gemoDream.Service.GetDocumentValues(drDoc["DocumentID"].ToString());
            for (int it = 0; it < Math.Min(dsDocsValue.Tables[0].Rows.Count, 4); it++)
            {
                //decomposition string [Part_Name.Measure_Name] / [Part_Name.Measure_Name] / [Part_Name.Measure_Name]...
                //to array [Part_Name.Measure_Name]
                DataRow row = dsDocsValue.Tables[0].Rows[it];
                String temp = ReplaceBracketsWithValues(row["Value"].ToString(), sNewBatchID, sNewItemCode, sGroupCode, sBatchCode);
                if (temp.Length > 0)
                {
                    table.Rows[0][it + 2] = temp + " " + row["Unit"];
                }
            }

            dsCrystalSet = new DataSet();
            dsCrystalSet.Tables.Add(table);

            DataSet dsIn = new DataSet();
            dsIn.Tables.Add("ItemDocByCodeTypeEx");
            DataSet dsOut = gemoDream.Service.GenericGetCrystalSet(dsIn);

            dsOut.Tables[0].Rows.Add(dsOut.Tables[0].NewRow());
            dsOut.Tables[0].Rows[0]["GroupCode"] = sGroupCode;
            dsOut.Tables[0].Rows[0]["BatchCode"] = sBatchCode;
            dsOut.Tables[0].Rows[0]["ItemCode"] = sItemCode;
            dsOut.Tables[0].TableName = "ItemDocByCode";
            DataSet dsOut2 = gemoDream.Service.GenericGetCrystalSet(dsOut);


            //			CrystalDecisions.CrystalReports.Engine.TextObject crText;
            //			crText = crDocument.ReportDefinition.ReportObjects["text1"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			crText.Text = dsCrystalSet.Tables[0].Rows[0][5].ToString();

            if (dsOut2.Tables[0].Rows.Count > 0)
                dsCrystalSet.Tables[0].Rows[0][5] = "";
            else
                dsCrystalSet.Tables[0].Rows[0][5] = "Z";

            //			crDocument.SetDataSource(dsCrystalSet);

        }

        //Function parses string and replaces brackets with values.
        //By 3ter on 2006.03.17
        private String ReplaceBracketsWithValues(String sBrackets, DataTable dtResult, String FullItemNumber)
        {

            //            DataView dvResult = new DataView(dtResult);
            //            dvResult.RowFilter = "PartName = '" + sPartName + "' and MeasureName = '" + sPartName + "'";

            //String rexBracket = @"(\[\w{0,}\W{0,}\w{0,}\.\w{0,}\W{0,}\w{0,}\({0,1}\w{0,}\){0,1}\])";
            //String rexBracket = @"\[(\w{0,}\s?(\(\w{0,}\))?){0,}\.(\w{0,}\s?(\(\w{0,}\))?){0,}\]";
            String rexBracket = @"\[[^]^[]{1,}\.[^]^[]{1,}\]";

            MatchCollection matches = Regex.Matches(sBrackets, rexBracket);

            Object[,] aoReplacements = new Object[2, matches.Count];

            int i = 0;
            //StringBuilder exceptionMessage = new StringBuilder();
            //bool first = true;
            foreach (Match match in matches)
            {
                String sMatch = match.ToString();
                sMatch = sMatch.Remove(0, 1);
                sMatch = sMatch.Remove(sMatch.Length - 1, 1);

                String[] asParts = sMatch.Split(new char[] { '.' });
				DataView dvResult = new DataView(dtResult)
				{
					RowFilter = "PartName = '" + asParts[0] + "' and MeasureName = '" + asParts[1] + "'"
				};

				if (dvResult.Count == 0)
                {
                    throw new Exception("[" + asParts[0].ToString() + "." + asParts[1].ToString() + "]" + " doesn't exist for item {" + FullItemNumber + "}. Certified label will not be printed.");
                }
                aoReplacements[0, i] = match;
                aoReplacements[1, i] = dvResult[0][6].ToString();

                if (dvResult.Count > 1)
                {
                    throw new Exception("[" + asParts[0].ToString() + "." + asParts[1].ToString() + "]" + " exists " + dvResult.Count.ToString() + " times for item {" + FullItemNumber + "}. Certified label will not be printed.");
                }
                i++;
                sBrackets = sBrackets.Replace(match.ToString(), dvResult[0][6].ToString());

            }
            return sBrackets;
        }

        private static string GetMySum(string myInput)
        {
            string rexBracket = @"[\d.]+";
            var dResult = 0.00;
            var dTemp = 0.00;
            Regex mm = new Regex(rexBracket, RegexOptions.IgnoreCase);
            MatchCollection matches = Regex.Matches(myInput, rexBracket);
            if (matches.Count > 0)
            {
                foreach (Match m in matches)
                {
                    if (double.TryParse(m.Value.ToString(), out dTemp)) dResult = dResult + dTemp;

                }

            }
			myInput = dResult.ToString();
			var sFormat = myInput.Split('.');
			if (sFormat.Length == 2)
			{
				if (sFormat[1].Length < 2) myInput = dResult.ToString("###0.00");
				else myInput = dResult.ToString();
			}
			else myInput = dResult.ToString();
			return myInput;
  		}

        private String GetMyValues(String sBrackets, DataTable dtResult, String FullItemNumber, ref ArrayList ErrorArray)
        {
            var sResult = ReplaceBracketsWithValues(sBrackets, dtResult, FullItemNumber, ref ErrorArray);
            string rexBracket = @"{[^{}]+}";
            Regex mm = new Regex(rexBracket, RegexOptions.IgnoreCase);
            MatchCollection matches = Regex.Matches(sResult, rexBracket);

            if (matches.Count > 0)
            {
                foreach (Match m in matches)
                {
                    sResult = sResult.Replace(m.ToString(), GetMySum(m.ToString()));
                }
            }
            return (sResult ?? "");
        }


        private String ReplaceBracketsWithValues(String sBrackets, DataTable dtResult, String FullItemNumber, ref ArrayList ErrorArray)
        {
			string[] sShortNumber = FullItemNumber.Split(new char[] { '/' });
			
			String rexBracket = @"\[[^]^[]{1,}\.[^]^[]{1,}\]";

            MatchCollection matches = Regex.Matches(sBrackets, rexBracket);
			
           
            //StringBuilder exceptionMessage = new StringBuilder();
            //bool first = true;
            foreach (Match match in matches)
            {
                String sMatch = match.ToString();
                //sMatch = sMatch.Remove(0, 1);
                //sMatch = sMatch.Remove(sMatch.Length - 1, 1);
                sMatch = sMatch.Replace("[", "").Replace("]", "");

                String[] asParts = sMatch.Split(new char[] { '.' });
				try
				{
					DataRow[] drResult = dtResult.Select("PartName = '" + asParts[0] + "' and MeasureName = '" + asParts[1] + "'");
					//                DataView dvResult = new DataView(dtResult);
					//                dvResult.RowFilter = "PartName = '" + asParts[0] + "' and MeasureName = '" + asParts[1] + "'";


					if (drResult.Length == 0) 
					{
						{
							if (skipErrors)
							{
								if (checkXmlTag(asParts[1].ToString().ToUpper()))
								{
									ErrorArray.Add("# " + sShortNumber[0] + ": " + asParts[0].ToString() + "." + asParts[1].ToString());
									sBrackets = sBrackets.Replace(match.ToString(), "");
								}
								else
								{
									sBrackets = sBrackets.Replace(match.ToString(), "");
								}
							}
							else
							{
								ErrorArray.Add("# " + sShortNumber[0] + ": " + asParts[0].ToString() + "." + asParts[1].ToString());
								sBrackets = sBrackets.Replace(match.ToString(), "");
							}
						}
					}
					else
					{
						sBrackets = sBrackets.Replace(match.ToString(), Formats(asParts[1].ToString(), drResult[0][6]));
                        if (asParts[1].ToString().ToUpper().Contains("PREFIX")) sBrackets = sBrackets.ToUpper();
					}
				}
				catch 
				{
					ErrorArray.Add("# " + sShortNumber[0] + ": " + asParts[0].ToString() + "." + asParts[1].ToString());
				}
             
            }

			while (sBrackets.IndexOf("[") >= 0)
			/*if (sBrackets.Contains("["))*/ sBrackets = ReplaceBracketsWithValues(sBrackets, dtResult, FullItemNumber, ref ErrorArray);
            return sBrackets;
        }

        private String ReplaceBracketsWithValues(String sBrackets, String sBatchID, String sItemCode, String sGroupCode, String sBatchCode)
        {
            DataSet dsResults;
            DataSet dsMeasureValue = new DataSet();

            dsMeasureValue.Tables.Add("MeasureValueByPart");
            dsMeasureValue.Tables[0].Columns.Add("BatchID");
            dsMeasureValue.Tables[0].Columns.Add("ItemCode");
            dsMeasureValue.Tables[0].Columns.Add("PartName");
            dsMeasureValue.Tables[0].Columns.Add("MeasureTitle");
            dsMeasureValue.Tables[0].Columns.Add("CutGrade");
            dsMeasureValue.Tables[0].Rows.Add(dsMeasureValue.Tables[0].NewRow());

            dsMeasureValue.Tables[0].Rows[0]["BatchID"] = sBatchID;
            dsMeasureValue.Tables[0].Rows[0]["ItemCode"] = sItemCode;
            dsMeasureValue.Tables[0].Rows[0]["CutGrade"] = 0;

            //String rexBracket = @"(\[\w{0,}\W{0,}\w{0,}\.\w{0,}\W{0,}\w{0,}\({0,1}\w{0,}\){0,1}\])";
            //String rexBracket = @"\[(\w{0,}\s?(\(\w{0,}\))?){0,}\.(\w{0,}\s?(\(\w{0,}\))?){0,}\]";
            String rexBracket = @"\[[^]^[]{1,}\.[^]^[]{1,}\]";

            MatchCollection matches = Regex.Matches(sBrackets, rexBracket);

            Object[,] aoReplacements = new Object[2, matches.Count];

            int i = 0;
            StringBuilder exceptionMessage = new StringBuilder();
            bool first = true;
            foreach (Match match in matches)
            {
                String sMatch = match.ToString();
                sMatch = sMatch.Remove(0, 1);
                sMatch = sMatch.Remove(sMatch.Length - 1, 1);

                String[] asParts = sMatch.Split(new char[] { '.' });
                dsMeasureValue.Tables[0].Rows[0]["PartName"] = asParts[0];
                dsMeasureValue.Tables[0].Rows[0]["MeasureTitle"] = asParts[1];

                dsResults = gemoDream.Service.GetMeasureValueByPart(dsMeasureValue);//Procedure dbo.spGetMeasureValueByPart
                if (dsResults.Tables[0].Rows.Count == 0)
                {
                    throw new Exception("[" + asParts[0].ToString() + "." + asParts[1].ToString() + "]" + " doesn't exist for item {" + sGroupCode + "." + sGroupCode + "." + sBatchCode + "." + sItemCode + "}. Label will not be printed.");
                }
                aoReplacements[0, i] = match;
                aoReplacements[1, i] = dsResults.Tables[0].Rows[0][0].ToString();

                if (dsResults.Tables[0].Rows[0][0].ToString().Equals("exception"))
                {
                    //throw new Exception( "[" + asParts[0].ToString() + "." + asParts[1].ToString() + "]" + " is empty for item {"+sGroupCode+"."+sGroupCode+"."+sBatchCode+"."+sItemCode+"}. Label will not be printed.");
                    if (!first)
                    {
                        exceptionMessage.Append(", ");
                    }
                    else
                    {
                        first = false;
                    }
                    exceptionMessage.Append("[" + asParts[0].ToString() + "." + asParts[1].ToString() + "]");
                }
                i++;
                sBrackets = sBrackets.Replace(match.ToString(), dsResults.Tables[0].Rows[0][0].ToString());

            }
            if (exceptionMessage.Length != 0)
            {
                throw new Exception(exceptionMessage.ToString() + " is empty for item {" + sGroupCode + "." + sGroupCode + "." + sBatchCode + "." + sItemCode + "}. Label will not be printed.");
            }
            return sBrackets;
        }


        public void Account_Representative_Label(string sGroupCode, string sBatchCode, string sBatchID, string sNewBatchID, string sItemCode, string sNewItemCode, bool isTotalWeight)
        {

            //string sReportPath=@"c:\work\sergei\work\crystal\reports\account_rep_label.rpt";
            string sReportPath = sReportsDir + @"account_rep_label.rpt";
            try
            {
                //				crDocument.Load(sReportPath);
            }
            catch (Exception ex)
            {
                throw new Exception("Template was not found at " + sReportPath + "\nPlease make sure the file exists at specified location.");
            }
            sPrinterName = GetPrinterName("Account_Rep_Label");
            DataSet dsItemSet = new DataSet();
            dsItemSet = gemoDream.Service.GetCrystalSet(sBatchID + "_" + sItemCode, "Item");


            DataSet dsIn = new DataSet();
            dsIn.Tables.Add("PartValueTypeEx");
            DataSet dsOut = gemoDream.Service.GenericGetCrystalSet(dsIn);
            dsOut.Tables[0].Rows.Add(dsOut.Tables[0].NewRow());
            dsOut.Tables[0].Rows[0]["BatchID"] = sNewBatchID;
            //dsOut.Tables[0].Rows[0]["BatchID"]=13;
            dsOut.Tables[0].Rows[0]["RecheckNumber"] = -1;
            dsOut.Tables[0].Rows[0]["ViewAccessCode"] = DBNull.Value;
            dsOut.Tables[0].Rows[0]["ItemCode"] = sNewItemCode;
            dsOut.Tables[0].TableName = "PartValue";


            DataSet dsPartValue = gemoDream.Service.GenericGetCrystalSet(dsOut);

            int iRowColor = 0;
            int iRowClarity = 0;
            int iRowColoredDiamond = 0;
            bool isRowColor = false;
            bool isRowClarity = false;
            bool isRowColoredDiamond = false;
            string sWeight = "";
            string sDiamondWeight = "";
            string sPrintWeight = "";
            bool isWeight = false;

            //batch=13 / 60;
            //item=1;


            DataTable dtParts = gemoDream.Service.GetParts(dsItemSet.Tables[0].Rows[0]["ItemTypeId"].ToString());

            DataSet dsIn1 = new DataSet();
            dsIn1.Tables.Add("PartTypes");
            DataSet dsPartTypes = gemoDream.Service.ProxyGenericGet(dsIn1);
            bool isColorDiamod = false;
            try
            {
                DataRow[] drPartTypeDiamondId = dsPartTypes.Tables[0].Select("PartTypeCode=1"); //Get 'Diamond' PartTypeId
                DataRow[] drPartTypeItemContainerId = dsPartTypes.Tables[0].Select("PartTypeCode=15"); //Get 'ItemContainer' PartTypeId
                DataRow[] drPartTypeColorDiamondId = dsPartTypes.Tables[0].Select("PartTypeCode=2"); //Get 'ColorDiamod' PartTypeId by Vetal_242 25.01.2006

                DataRow[] drItemContainersPartsIds = dtParts.Select("PartTypeID=" + drPartTypeItemContainerId[0]["PartTypeID"].ToString());
                DataRow[] drDiamondsPartsIds = dtParts.Select("PartTypeID=" + drPartTypeDiamondId[0]["PartTypeID"].ToString());

                //ColorDiamond?
                //by Vetal_242 25.01.2006
                DataRow[] drColorDiamondsPartsIds = dtParts.Select("PartTypeID=" + drPartTypeColorDiamondId[0]["PartTypeID"].ToString());
                if (drColorDiamondsPartsIds.Length > 0)
                    isColorDiamod = true;

                for (int i = 0; i < drItemContainersPartsIds.Length; i++)
                {
                    DataRow[] drPartValues = dsPartValue.Tables[0].Select("PartID=" + drItemContainersPartsIds[i]["ID"].ToString() + " and MeasureCode=2");
                    if (drPartValues.Length > 0)
                    {
                        isWeight = true;
                        switch (drPartValues[0]["MeasureClass"].ToString())
                        {
                            case "1": sWeight = drPartValues[0]["MeasureValueName"].ToString(); break;
                            case "2": sWeight = drPartValues[0]["StringValue"].ToString(); break;
                            case "3": sWeight = drPartValues[0]["MeasureValue"].ToString(); break;
                            case "4": sWeight = drPartValues[0]["StringValue"].ToString(); break;
                        }
                        break;
                    }
                }


                //			if(!isWeight)
                {
                    for (int i = 0; i < drDiamondsPartsIds.Length; i++)
                    {
                        DataRow[] drPartValues = dsPartValue.Tables[0].Select("PartID=" + drDiamondsPartsIds[i]["ID"].ToString() + " and (MeasureCode=2 or MeasureCode=4)");
                        if (drPartValues.Length > 0)
                        {
                            isWeight = true;
                            switch (drPartValues[0]["MeasureClass"].ToString())
                            {
                                case "1": sDiamondWeight = drPartValues[0]["MeasureValueName"].ToString(); break;
                                case "2": sDiamondWeight = drPartValues[0]["StringValue"].ToString(); break;
                                case "3": sDiamondWeight = drPartValues[0]["MeasureValue"].ToString(); break;
                                case "4": sDiamondWeight = drPartValues[0]["StringValue"].ToString(); break;
                            }
                            break;
                        }
                    }
                }


            }
            catch (Exception exc)
            {
                System.Diagnostics.Trace.WriteLine(exc.Message.ToString());
            }

            if (!isWeight)
            {
                throw new Exception("Weight is empty for item {" + sGroupCode + "." + sGroupCode + "." + sBatchCode + "." + sItemCode + "}. Label will not be printed.");
            }



            for (int i = 0; i < dsPartValue.Tables[0].Rows.Count; i++)
            {
                if (isRowColor & isRowClarity & isRowColoredDiamond) break;

                if (dsPartValue.Tables[0].Rows[i]["MeasureCode"].ToString() == "27")
                {
                    iRowColor = i;
                    isRowColor = true;
                }
                if (dsPartValue.Tables[0].Rows[i]["MeasureCode"].ToString() == "29")
                {
                    iRowClarity = i;
                    isRowClarity = true;
                }
                //Color Diamod Color
                //by Vetal_242 25.01.2006
                if (dsPartValue.Tables[0].Rows[i]["MeasureCode"].ToString() == "32")
                {
                    iRowColoredDiamond = i;
                    isRowColoredDiamond = true;
                }

            }

            string sColor = "";
            string sClarity = "";
            if (dsPartValue.Tables[0].Rows.Count > 0)
            {
                if (!isColorDiamod)//not ColorDiamond
                    sColor = dsPartValue.Tables[0].Rows[iRowColor]["MeasureValueName"].ToString();
                else
                    if (isRowColoredDiamond)//nonselected diamond color
                        sColor = dsPartValue.Tables[0].Rows[iRowColoredDiamond]["MeasureValueName"].ToString();
                sClarity = dsPartValue.Tables[0].Rows[iRowClarity]["MeasureValueName"].ToString();
            }

            DataSet dsTempSet = new DataSet();
            DataTable table = new DataTable("parsel_label");

            table.Columns.Add("barcode", System.Type.GetType("System.String"));
            table.Columns.Add("barcodenum", System.Type.GetType("System.String"));
            table.Columns.Add("carat weight", System.Type.GetType("System.String"));
            table.Columns.Add("color", System.Type.GetType("System.String"));
            table.Columns.Add("clarity", System.Type.GetType("System.String"));
            table.Columns.Add("isPrinted", System.Type.GetType("System.String"));

            DataRow tRow = table.NewRow();

            sGroupCode = FillToFiveChars(sGroupCode);
            sBatchCode = FillToThreeChars(sBatchCode);
            sItemCode = FillToTwoChars(sItemCode);

            string sOldGroupCode = FillToFiveChars(dsItemSet.Tables[0].Rows[0]["PrevGroupCode"].ToString());
            string sOldBatchCode = FillToThreeChars(dsItemSet.Tables[0].Rows[0]["PrevBatchCode"].ToString());
            string sOldItemCode = FillToTwoChars(dsItemSet.Tables[0].Rows[0]["PrevItemCode"].ToString());

            if (sOldGroupCode != "00000" && sOldBatchCode != "000" && sOldItemCode != "00")
            {
                tRow[0] = "*" + sOldGroupCode + sOldBatchCode + sOldItemCode + "*";
                tRow[1] = sOldGroupCode + "." + sOldBatchCode + "." + sOldItemCode + "(" + sGroupCode + "." + sBatchCode + "." + sItemCode + ")";
            }
            else
            {
                tRow[0] = "*" + sGroupCode + sBatchCode + sItemCode + "*";
                tRow[1] = sGroupCode + "." + sBatchCode + "." + sItemCode;
            }

            if (isTotalWeight) //TotalWeight
            {
                try
                {
                    sPrintWeight = Convert.ToDouble(dsItemSet.Tables[0].Rows[0]["Weight"].ToString()).ToString("0.00");
                    sPrintWeight = sPrintWeight + " ct. (twt)";
                }
                catch
                {
                    sPrintWeight = "";
                }
            }
            if (!isTotalWeight) //Center Stone Weight
            {
                try
                {
                    sPrintWeight = Convert.ToDouble(sDiamondWeight).ToString("0.00") + " ct.";
                }
                catch
                { sPrintWeight = ""; }
            }

            if (sPrintWeight.Length > 0)
                tRow[2] = sPrintWeight;
            else
                tRow[2] = "";


            tRow[3] = sColor;//"color";
            tRow[4] = sClarity;//"clarity";

            table.Rows.Add(tRow);
            dsTempSet.Tables.Add(table);
            dsCrystalSet = dsTempSet;
            //			dsCrystalSet.Tables[0].TableName=crDocument.Database.Tables[0].Name;

            string sShapeCode = dsItemSet.Tables[0].Rows[0]["Shape"].ToString();
            DataSet dsShape = new DataSet();

            try
            {
                dsShape = gemoDream.Service.GetShapeByCode(Convert.ToInt32(sShapeCode));
            }
            catch
            { }


            //			CrystalDecisions.CrystalReports.Engine.TextObject crText;
            //			crText=crDocument.ReportDefinition.ReportObjects["text1"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			if(dsShape.Tables.Count>0)
            //				crText.Text=dsShape.Tables[0].Rows[0]["ShortReportName"].ToString();
            //			else 
            //				crText.Text="";


            dsIn = new DataSet();
            dsIn.Tables.Add("ItemDocByCodeTypeEx");
            dsOut = gemoDream.Service.GenericGetCrystalSet(dsIn);

            dsOut.Tables[0].Rows.Add(dsOut.Tables[0].NewRow());
            dsOut.Tables[0].Rows[0]["GroupCode"] = sGroupCode;
            dsOut.Tables[0].Rows[0]["BatchCode"] = sBatchCode;
            dsOut.Tables[0].Rows[0]["ItemCode"] = sItemCode;
            dsOut.Tables[0].TableName = "ItemDocByCode";
            DataSet dsOut2 = gemoDream.Service.GenericGetCrystalSet(dsOut);

            if (dsOut2.Tables[0].Rows.Count > 0)
                dsCrystalSet.Tables[0].Rows[0][5] = "";
            else
                dsCrystalSet.Tables[0].Rows[0][5] = "Z";

            //			crDocument.SetDataSource(dsCrystalSet);

        }

        public void GoldEngraving(DataSet dsData) //otOpenOrders from Acc. Rep.
        {
            string sReportPath = sReportsDir + @"gold_engraving.rpt";
            //			crDocument.Load(sReportPath);
            sPrinterName = GetPrinterName("GoldEngraving");


            DataSet dsUser = new DataSet();
            dsUser.Tables.Add("Authors");
            dsUser.Tables[0].Columns.Add("Login", System.Type.GetType("System.String"));
            dsUser.Tables[0].Columns.Add("DepartmentID", System.Type.GetType("System.String"));
            dsUser.Tables[0].Columns.Add("DepartmentOfficeID", System.Type.GetType("System.String"));
            dsUser.Tables[0].Columns.Add("Password", System.Type.GetType("System.String"));
            dsUser.Tables[0].Columns.Add("UserID", System.Type.GetType("System.String"));
            dsUser.Tables[0].Columns.Add("UserOfficeID", System.Type.GetType("System.String"));
            dsUser.Tables[0].Rows.Add(dsUser.Tables[0].NewRow());
            dsUser.Tables[0].Rows[0]["Login"] = DBNull.Value;
            dsUser.Tables[0].Rows[0]["Password"] = DBNull.Value;
            dsUser.Tables[0].Rows[0]["DepartmentID"] = DBNull.Value;
            dsUser.Tables[0].Rows[0]["DepartmentOfficeID"] = DBNull.Value;
            dsUser.Tables[0].Rows[0]["UserID"] = gemoDream.Service.iUserId;
            dsUser.Tables[0].Rows[0]["UserOfficeID"] = gemoDream.Service.iOfficeId;
            dsUser = gemoDream.Service.ProxyGenericGet(dsUser);


            //			CrystalDecisions.CrystalReports.Engine.TextObject crText;
            //			crText=crDocument.ReportDefinition.ReportObjects["text3"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			crText.Text=System.DateTime.Now.Date.ToShortDateString(); //date
            //			crText=crDocument.ReportDefinition.ReportObjects["text4"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			crText.Text=System.DateTime.Now.ToShortTimeString();// time
            //			crText=crDocument.ReportDefinition.ReportObjects["text25"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			crText.Text = dsUser.Tables[0].Rows[0]["FirstName"].ToString() + " " + dsUser.Tables[0].Rows[0]["LastName"].ToString(); //"Author";// Author
            //			crDocument.SetDataSource(dsData);
        }

        public void LaserInscription(DataSet dsData) //otOpenOrders from Acc. Rep.
        {
            string sReportPath = sReportsDir + @"laser_inscription.rpt";
            //			crDocument.Load(sReportPath);
            sPrinterName = GetPrinterName("LaserInscription");


            DataSet dsUser = new DataSet();
            dsUser.Tables.Add("Authors");
            dsUser.Tables[0].Columns.Add("Login", System.Type.GetType("System.String"));
            dsUser.Tables[0].Columns.Add("DepartmentID", System.Type.GetType("System.String"));
            dsUser.Tables[0].Columns.Add("DepartmentOfficeID", System.Type.GetType("System.String"));
            dsUser.Tables[0].Columns.Add("Password", System.Type.GetType("System.String"));
            dsUser.Tables[0].Columns.Add("UserID", System.Type.GetType("System.String"));
            dsUser.Tables[0].Columns.Add("UserOfficeID", System.Type.GetType("System.String"));
            dsUser.Tables[0].Rows.Add(dsUser.Tables[0].NewRow());
            dsUser.Tables[0].Rows[0]["Login"] = DBNull.Value;
            dsUser.Tables[0].Rows[0]["Password"] = DBNull.Value;
            dsUser.Tables[0].Rows[0]["DepartmentID"] = DBNull.Value;
            dsUser.Tables[0].Rows[0]["DepartmentOfficeID"] = DBNull.Value;
            dsUser.Tables[0].Rows[0]["UserID"] = gemoDream.Service.iUserId;
            dsUser.Tables[0].Rows[0]["UserOfficeID"] = gemoDream.Service.iOfficeId;
            dsUser = gemoDream.Service.ProxyGenericGet(dsUser);


            //			CrystalDecisions.CrystalReports.Engine.TextObject crText;
            //			crText=crDocument.ReportDefinition.ReportObjects["text3"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			crText.Text=System.DateTime.Now.Date.ToShortDateString(); //date
            //			crText=crDocument.ReportDefinition.ReportObjects["text4"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			crText.Text=System.DateTime.Now.ToShortTimeString();// time
            //			crText=crDocument.ReportDefinition.ReportObjects["text25"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			crText.Text = dsUser.Tables[0].Rows[0]["FirstName"].ToString() + " " + dsUser.Tables[0].Rows[0]["LastName"].ToString(); //"Author";// Author
            //			crDocument.SetDataSource(dsData);
        }


        public void Items_Selected(string sItemsNum)
        {
            string sReportPath = sReportsDir + @"items_selected.rpt";
            //string sReportPath=@"c:\work\sergei\work\crystal\reports\items_selected.rpt";
            //			crDocument.Load(sReportPath);
            sPrinterName = GetPrinterName("Items_Selected");
            //			CrystalDecisions.CrystalReports.Engine.TextObject crText;
            //			crText=crDocument.ReportDefinition.ReportObjects["itemsNum"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            //			crText.Text=sItemsNum;

        }

        public void XL_Report(DataTable dtDocs, string sPath)
        {
            //Excel datatable
            dtXL.Columns.Add("GroupCode");
            dtXL.Columns.Add("BatchCode");
            dtXL.Columns.Add("Report");
            dtXL.Columns.Add("Shape/Cut");
            dtXL.Columns.Add("Weight");
            dtXL.Columns.Add("Color");
            dtXL.Columns.Add("Clarity");
            dtXL.Columns.Add("Measurements");
            dtXL.Columns.Add("Description");
            dtXL.Columns.Add("Comments");
            dtXL.Columns.Add("Date");
            dtXL.Columns.Add("Virtual Vault #");
            dtXL.Columns.Add("Image Name");

            foreach (DataRow drDoc in dtDocs.Rows)
            {
                DataSet dsPartValueTypeEx = gemoDream.Service.GetPartValueTypeEx();
                DataSet dsPartValueType = dsPartValueTypeEx.Copy();
                dsPartValueType.Tables["PartValueTypeEx"].TableName = "PartValue";
                dsPartValueType.Tables["PartValue"].Rows.Add(dsPartValueType.Tables["PartValue"].NewRow());
                //dsPartValueType.Tables["PartValue"].Rows[0]["PartID"] = iContainerID;
                dsPartValueType.Tables["PartValue"].Rows[0]["RecheckNumber"] = -1;
                /* sd 25.12.2006 
                dsPartValueType.Tables["PartValue"].Rows[0]["BatchID"] = drDoc["BatchID"].ToString();
                dsPartValueType.Tables["PartValue"].Rows[0]["ItemCode"] = drDoc["ItemCode"].ToString();
                */
                dsPartValueType.Tables["PartValue"].Rows[0]["BatchID"] = drDoc["NewBatchID"].ToString();
                dsPartValueType.Tables["PartValue"].Rows[0]["ItemCode"] = drDoc["NewItemCode"].ToString();

                dsPartValueType.Tables["PartValue"].Rows[0]["ViewAccessCode"] = DBNull.Value;
                dsPartValueType = gemoDream.Service.GetPartValueType(dsPartValueType);
                DataSet dsBatchWCustomer = gemoDream.Service.GetCrystalSet(drDoc["BatchID"].ToString(), "BatchWithCustomer");


                DataTable dtParts = dsPartValueType.Tables[0].Copy();
                //stringValue, gde measurecode = 92

                string sPartID = "";
                string sNumber = "";
                string sShape = "";
                string sCustomerProgram = "";
                string sClarityGrade = "";
                string sColorGrade = "";
                string sDMax = "";
                string sDMin = "";
                string sH_x = "";
                string sDimensions = "";
                string sExternalComment = "";
                string sWeightTotal = "";
                string sWeightClc = "";
                string sWeightMeas = "";
                string sWeightFin = "";
                string sDescription = "";
                string sVirtualVault = "";

                DataSet dsItemSet = new DataSet();
                dsItemSet = gemoDream.Service.GetCrystalSet(drDoc["BatchID"].ToString() + "_" + drDoc["ItemCode"].ToString(), "Item");

                DataSet dsShape = new DataSet();
                DataSet dsIm = gemoDream.Service.GetItemCPPictureByCode(drDoc["GroupCode"].ToString(), drDoc["BatchCode"].ToString());
                bool isPicture = false;
                try
                {
                    dsShape = gemoDream.Service.GetShapeByCode(Convert.ToInt32(dsItemSet.Tables[0].Rows[0]["Shape"]));
                    isPicture = true;
                }
                catch
                {
                    isPicture = false;
                }

                if (dtParts.Rows.Count != 0)
                {
                    DataRow[] virtualVualtRows = dtParts.Select("MeasureCode=92");
                    if (virtualVualtRows.Length > 0)
                        sVirtualVault = virtualVualtRows[0]["stringValue"].ToString();

                    sPartID = dtParts.Rows[0]["PartID"].ToString();
                    sNumber = GetReportNumber();
                    if (dsShape.Tables.Count > 0)
                        sShape = dsShape.Tables[0].Rows[0]["ShortReportName"].ToString();
                    if (dsBatchWCustomer.Tables.Count > 0)
                        sCustomerProgram = dsBatchWCustomer.Tables[0].Rows[0]["CustomerProgramName"].ToString();

                    DataSet dsItem = gemoDream.Service.GetItem(drDoc["ItemCode"].ToString(), drDoc["BatchID"].ToString());
                    if (dsItem.Tables[0].Rows.Count > 0)
                    {
                        sClarityGrade = dsItem.Tables[0].Rows[0]["Color"].ToString();
                        sColorGrade = dsItem.Tables[0].Rows[0]["Clarity"].ToString();
                    }

                    foreach (DataRow drRow in dtParts.Rows)
                    {
                        try
                        {
                            sDMax = Convert.ToDouble(GetMeasureValue("DimensionMax", dtParts, drRow["PartID"].ToString())).ToString(".##");
                            sDMin = Convert.ToDouble(GetMeasureValue("DimensionMin", dtParts, drRow["PartID"].ToString())).ToString(".##");
                            sH_x = Convert.ToDouble(GetMeasureValue("H_x", dtParts, drRow["PartID"].ToString())).ToString(".##");
                            sDimensions = sDMax + "-" + sDMin + " x " + sH_x + " mm";
                            break;
                        }
                        catch
                        {
                            sDimensions = "";
                        }
                    }

                    //sExternalComment=GetMeasureValue("External Comment",dtParts,sPartID);
                    sExternalComment = gemoDream.Service.GetIIBGBIC(drDoc["GroupCode"].ToString(),
                        drDoc["BatchCode"].ToString(), drDoc["ItemCode"].ToString()).Tables["IIBGBIC"].Rows[0]["ItemComment"].ToString();

                    sDescription = dsBatchWCustomer.Tables[0].Rows[0]["Comment"].ToString();

                    foreach (DataRow drRow in dtParts.Rows)
                    {
                        sWeightTotal = GetMeasureValue("Total weight(ct)", dtParts, drRow["PartID"].ToString());
                        sWeightClc = GetMeasureValue("Calculated Weight", dtParts, drRow["PartID"].ToString());
                        sWeightMeas = GetMeasureValue("Measured Weight(ct)", dtParts, drRow["PartID"].ToString());
                        sWeightFin = "";
                        if (sWeightMeas != "")
                            sWeightFin = sWeightMeas;
                        if (sWeightClc != "")
                            sWeightFin = sWeightClc;
                        if (sWeightTotal != "")
                            sWeightFin = sWeightTotal;

                        try
                        {
                            double dR = Math.Round(Convert.ToDouble(sWeightFin), 2);
                            sWeightFin = dR.ToString() + " ct";
                            break;
                        }
                        catch
                        { }
                    }
                }
                else
                { }

                sNumber = drDoc["OperationChar"].ToString() + FillToFiveChars(drDoc["GroupCode"].ToString()) + FillToThreeChars(drDoc["BatchCode"].ToString()) + FillToTwoChars(drDoc["ItemCode"].ToString());

                object[] aoValues = new object[] {drDoc["GroupCode"], drDoc["BatchCode"], sNumber, sShape, sWeightFin, sColorGrade, 
													 sClarityGrade, sDimensions, sDescription, sExternalComment,
													 System.DateTime.Now.Date.Day.ToString()+" "+System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(System.DateTime.Now.Date.Month)+", "+System.DateTime.Now.Year.ToString(),
													 sVirtualVault, dsIm.Tables[0].Rows[0]["Path2Picture"].ToString()};
                dtXL.Rows.Add(aoValues);
            }

            while (dtXL.Rows.Count > 0)
            {
                DataTable dtCurrentBatch = dtXL.Clone();
                DataRow[] adrSameBatch = dtXL.Select("BatchCode=" + dtXL.Rows[0]["BatchCode"].ToString() +
                    " and GroupCode=" + dtXL.Rows[0]["GroupCode"].ToString());
                foreach (DataRow drRec in adrSameBatch)
                {
                    dtCurrentBatch.Rows.Add(drRec.ItemArray);
                    dtXL.Rows.Remove(drRec);
                }

                DataSet dsIm = gemoDream.Service.GetItemCPPictureByCode(dtCurrentBatch.Rows[0]["GroupCode"].ToString(),
                    dtCurrentBatch.Rows[0]["BatchCode"].ToString());

                Image img = (Image)gemoDream.Service.ExtractImageFromString(dsIm.Tables[0].Rows[0]["Image_Path2Picture"].ToString(),
                    dsIm.Tables[0].Rows[0]["Path2Picture"].ToString());
                CreateXL(dtCurrentBatch, img, sPath);
                CreateTXT(dtCurrentBatch, img, sPath);
            }
        }

        public void PDF_Report(string sTemplatePath, int iGroupCode, int iBatchCode, int iItemCode, string cOperationChar)
        {
            //string sReportName=System.IO.Path.GetFileName(sTemplatePath);

            string sReportName = System.IO.Path.GetFileNameWithoutExtension(sTemplatePath);

        }

        //		public CrystalDecisions.CrystalReports.Engine.ReportDocument GetReportDocument()
        //		{
        //			return crDocument;
        //		}

        public void PrintToDefaultPrinter()
        {
            System.Drawing.Printing.PrinterSettings ps = new System.Drawing.Printing.PrinterSettings();
            //			crDocument.PrintOptions.PrinterName=ps.PrinterName;
            //			crDocument.PrintToPrinter(1, false,0,0);						
        }

        public void Print()
        {
            try
            {
                //				crDocument.PrintOptions.PrinterName=sPrinterName;
                //				crDocument.PrintToPrinter(1,false,0,0);
            }
            catch { }
        }

        public void ViewDocument()
        {
            if (!File.Exists(sExportDocPath))
                throw new Exception("Not found file for preview");

            if (sExportDocExt.ToLower() == "pdf")
            {
                //	RegistryKey pdfRk = Registry.ClassesRoot.OpenSubKey("Applications\\AcroRd32.exe\\shell\\Read\\command");
                //	if(pdfRk == null)
                //		throw new Exception("Adobe Acrobat Reader 7.0 is not installed on your computer");

                Process.Start(sExportDocPath);
            }
            if (sExportDocExt.ToLower() == "rtf")
            {
                Process.Start(sExportDocPath);
            }
        }

        public void Export(string sPath, string sFileName, string sExt)
        {
            if (!System.IO.Directory.Exists(sPath))
                System.IO.Directory.CreateDirectory(sPath);

            sExt = sExt.ToLower();
            sExportDocPath = sPath + sFileName + "." + sExt;
            sExportDocExt = sExt;

            switch (sExt)
            {
                case "pdf": ExportToPDF(sExportDocPath); break;
                case "rtf": ExportToRTF(sExportDocPath); break;
            }

        }

        public void Export(string sExt)
        {
            string sFileNamePrefix = @"gemoDreamTmp";
            string sFileName = "";
            string sFullName = "";

            int iIndex = 0;
            while (true)
            {
                iIndex++;
                if (iIndex > 100) { System.Windows.Forms.MessageBox.Show("Too many temporary files"); break; }
                sFileName = sFileNamePrefix + FillToThreeChars(iIndex.ToString());
                sFullName = sFileName + "." + sExt;
                if (File.Exists(sFullName))
                {
                    try
                    {
                        System.IO.File.Delete(sFullName);
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                    break;
                }
                break;

            }

            sExt = sExt.ToLower();
            sExportDocPath = sFullName;
            sExportDocExt = sExt;

            switch (sExt)
            {
                case "pdf": ExportToPDF(sExportDocPath); break;
                case "rtf": ExportToRTF(sExportDocPath); break;
            }
        }

        private void CreateTXT(DataTable dtData, Image img, string sPath)
        {
            string[,] aPoles = new string[dtData.Rows.Count + 1, dtData.Columns.Count - 2];
            int maxLength = 0;

            for (int i = 2; i < dtData.Columns.Count; i++)
            {
                aPoles[0, i - 2] = dtData.Columns[i].ColumnName.ToString();
                if (aPoles[0, i - 2].Length > maxLength)
                    maxLength = aPoles[0, i - 2].Length;
            }

            for (int i = 0; i < dtData.Rows.Count; i++)
            {
                for (int j = 2; j < dtData.Columns.Count; j++)
                {
                    aPoles[i + 1, j - 2] = dtData.Rows[i][j].ToString();
                    if (aPoles[i + 1, j - 2].Length > maxLength)
                        maxLength = aPoles[i + 1, j - 2].Length;
                }
            }

            StreamWriter sw = new StreamWriter(sPath + dtData.Rows[0]["GroupCode"].ToString() + "." + dtData.Rows[0]["BatchCode"].ToString() + ".txt", false);

            try
            {
                for (int i = 0; i < dtData.Columns.Count - 2; i++)
                {
                    string fill = new string(' ', maxLength + 4 - aPoles[0, i].Length);
                    aPoles[0, i] += fill;
                    sw.Write(aPoles[0, i]);
                }

                sw.Write("\n");

                for (int i = 1; i < dtData.Rows.Count + 1; i++)
                {
                    for (int j = 0; j < dtData.Columns.Count - 2; j++)
                    {
                        string fill = new string(' ', maxLength + 4 - aPoles[i, j].Length);
                        aPoles[i, j] += fill;
                        sw.Write(aPoles[i, j]);
                    }
                    sw.Write("\n");
                }
            }

            catch (Exception exc)
            {
                System.Windows.Forms.MessageBox.Show("Unable to write to file: " + exc.Message);
            }
            sw.Close();
        }

        public string CreateMyXL(string sDockID, ArrayList alBatchID, DataTable dtItems, string sPath)
        {
            Client.KillOpenExcel();
            Excel.Application excelApp;
            Excel.Workbooks workbooks;
            Excel._Workbook workbook;
            Excel.Sheets sheets;
            Excel._Worksheet worksheet;

            string itemCode;
            excelApp = new Excel.Application();
            if (excelApp == null)
            {
                System.Windows.Forms.MessageBox.Show("EXCEL could not be started. Check that your office installation and project references are correct.",
                    "EXCEL could not be started", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                Console.WriteLine();
            }
            excelApp.Visible = false;
            workbooks = excelApp.Workbooks;
            workbook = workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            sheets = workbook.Worksheets;
            worksheet = (Excel._Worksheet)sheets.get_Item(1);

            if (worksheet == null)
            {
                System.Windows.Forms.MessageBox.Show("Worksheet could not be created. Check that your office installation and project references are correct",
                    "Worksheet could not be created", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            worksheet.get_Range("a1", "az27").NumberFormat = "@";

            try
            {
                DataSet dsDocsValue = gemoDream.Service.GetDocumentValues(sDockID);
                DataTable dtCutGradeRule = gemoDream.Service.GetAllCutGradeRule();
                DataTable dtMeasureReplacement = gemoDream.Service.GetMeasureReplacements();

                DataRow[] checkCutGrade = dsDocsValue.Tables[0].Select("Value like '%CutGrade%'");

                int Girdle = 0;
                if (checkCutGrade.Length != 0)
                {
                    Girdle = 1;
                }

                StringBuilder exceptionText = new StringBuilder();
                int itemCount = 0;
                int start = 0;
                for (int BatchIndex = 0; BatchIndex < alBatchID.Count; BatchIndex++)
                {
                    string batchID = alBatchID[BatchIndex].ToString();

                    //by vetal_242 10.02.2006 init DataTable's for check values by PartName.MeasureName
                    DataTable dtAdditionalMeasures = gemoDream.Service.GetSomeAdditionalMeasureByBatchID(batchID);
                    DataTable dtGirdle = gemoDream.Service.GetGirdleByBatchID(batchID);
                    DataTable dtPartValue = gemoDream.Service.GetPartValueByBatchID(batchID);

                    DataRow[] drItems = dtItems.Select("BatchID = " + batchID);
                    start = itemCount;

                    worksheet.get_Range("a" + (27 + itemCount).ToString(), "az" + (27 + drItems.Length + itemCount).ToString()).NumberFormat = "@";

                    itemCount += drItems.Length;
                    for (int count = 1; count < drItems.Length + 1; count++)
                    {
                        bool first = true;
                        itemCode = drItems[count - 1]["Code"].ToString();
                        for (int it = 0; it < dsDocsValue.Tables[0].Rows.Count; it++)
                        {
                            DataRow row = dsDocsValue.Tables[0].Rows[it];
                            String sBrackets = row["Value"].ToString();

                            //decomposition string [Part_Name.Measure_Name] / [Part_Name.Measure_Name] / [Part_Name.Measure_Name]...
                            //to array [Part_Name.Measure_Name]

                            DataSet dsResults;


                            /*DataSet dsMeasureValue = new DataSet();		

                            dsMeasureValue.Tables.Add("MeasureValueByPart");
                            dsMeasureValue.Tables[0].Columns.Add("BatchID");
                            dsMeasureValue.Tables[0].Columns.Add("ItemCode");
                            dsMeasureValue.Tables[0].Columns.Add("PartName");
                            dsMeasureValue.Tables[0].Columns.Add("MeasureTitle");
                            dsMeasureValue.Tables[0].Columns.Add("CutGrade");
                            dsMeasureValue.Tables[0].Rows.Add(dsMeasureValue.Tables[0].NewRow());

                            dsMeasureValue.Tables[0].Rows[0]["BatchID"] = batchID;
                            dsMeasureValue.Tables[0].Rows[0]["ItemCode"] = itemCode;			
                            dsMeasureValue.Tables[0].Rows[0]["CutGrade"] = Girdle;*/


                            String rexBracket = @"\[[^]^[]{1,}\.[^]^[]{1,}\]";

                            MatchCollection matches = Regex.Matches(sBrackets, rexBracket);

                            Object[,] aoReplacements = new Object[2, matches.Count];
                            int[,] bedCP = new int[2, matches.Count];
                            bedCP.Initialize();

                            int i = 0;
                            foreach (Match match in matches)
                            {
                                String sMatch = match.ToString();
                                sMatch = sMatch.Remove(0, 1);
                                sMatch = sMatch.Remove(sMatch.Length - 1, 1);

                                String[] asParts = sMatch.Split(new char[] { '.' });
                                //dsMeasureValue.Tables[0].Rows[0]["PartName"] = asParts[0];
                                //dsMeasureValue.Tables[0].Rows[0]["MeasureTitle"] = asParts[1];

                                dsResults = GetMeasureValueByPart(itemCode, asParts[0], asParts[1], Girdle, dtPartValue, dtAdditionalMeasures, dtGirdle, dtCutGradeRule, dtMeasureReplacement);

                                if (dsResults.Tables[0].Rows[0]["MeasureCode"].ToString() == "" &&
                                    dsResults.Tables[0].Rows[0]["Value"].ToString() == "")
                                {
                                    throw new Exception("[" + asParts[0].ToString() + "." + asParts[1].ToString() + "]" + " doesn't exist for item {" + drItems[count - 1]["OrderCode"].ToString()
                                        + "." + drItems[count - 1]["OrderCode"].ToString() + "." + drItems[count - 1]["BatchCode"].ToString() + "." + itemCode + "}.");
                                }

                                aoReplacements[0, i] = match;


                                if (dsResults.Tables[0].Rows[0]["Value"] != System.DBNull.Value)
                                    aoReplacements[1, i] = FormatMeasure(dsResults.Tables[0].Rows[0]["MeasureCode"], dsResults.Tables[0].Rows[0]["Value"]);

                                else
                                    aoReplacements[1, i] = dsResults.Tables[0].Rows[0]["Value"].ToString();

                                if (dsResults.Tables[0].Rows[0]["Value"].ToString().Equals("exception"))
                                {
                                    if (first)
                                    {
                                        first = false;
                                        exceptionText.Append("\n" + FillToFiveChars(drItems[count - 1]["OrderCode"].ToString()) + FillToThreeChars(drItems[count - 1]["BatchCode"].ToString())
                                            + FillToTwoChars(itemCode) + ": ");
                                    }
                                    exceptionText.Append("[" + asParts[0].ToString() + "." + asParts[1].ToString() + "], ");
                                }
                                if (dsResults.Tables[0].Rows[0]["CP"].ToString() == "0")
                                {
                                    bedCP[0, i] = sBrackets.IndexOf(match.ToString());
                                    bedCP[1, i] = dsResults.Tables[0].Rows[0][0].ToString().Length;
                                }
                                sBrackets = sBrackets.Replace(match.ToString(), aoReplacements[1, i].ToString());
                                i++;
                            }
                            if (itemCode == "1")
                            {
                                worksheet.Cells[1, it + 2] = row["Title"].ToString();
                            }
                            worksheet.Cells[start + 1 + count, it + 2] = sBrackets;
                            ((Excel.Range)worksheet.Cells[start + 1 + count, it + 2]).EntireColumn.AutoFit();
                            for (int j = 0; j < bedCP.Length / 2; j++)
                            {
                                if (bedCP[1, j] > 0)
                                {
                                    ((Excel.Range)worksheet.Cells[start + 1 + count, it + 2]).get_Characters((bedCP[0, j] + 1), (bedCP[1, j])).Font.ColorIndex = 3;
                                    ((Excel.Range)worksheet.Cells[start + 1 + count, it + 2]).get_Characters((bedCP[0, j] + 1), (bedCP[1, j])).Font.Bold = true;
                                    ((Excel.Range)worksheet.Cells[start + 1 + count, it + 2]).get_Characters((bedCP[0, j] + 1), (bedCP[1, j])).Font.Underline = true;
                                    ((Excel.Range)worksheet.Cells[start + 1 + count, it + 2]).get_Characters((bedCP[0, j] + 1), (bedCP[1, j])).Font.Italic = true;
                                    worksheet.Cells[start + 1 + count, 1] = "Fail";
                                    ((Excel.Range)worksheet.Cells[start + 1 + count, 1]).Font.Underline = true;
                                    ((Excel.Range)worksheet.Cells[start + 1 + count, 1]).Font.Bold = true;
                                    ((Excel.Range)worksheet.Cells[start + 1 + count, 1]).Font.ColorIndex = 3;
                                    ((Excel.Range)worksheet.Cells[start + 1 + count, 1]).Font.Italic = 3;
                                }
                            }

                        }
                    }
                }
                if (exceptionText.Length == 0)
                {
                    worksheet.Cells[itemCount + 4, 1] = "Please note:";
                    string text = "The rejections and reasons for rejection are in underlined bold italics";
                    worksheet.Cells[itemCount + 5, 1] = text;

                    ((Excel.Range)worksheet.Cells[itemCount + 5, 1]).get_Characters(text.IndexOf("underlined"), 0).Font.Bold = true;
                    ((Excel.Range)worksheet.Cells[itemCount + 5, 1]).get_Characters(text.IndexOf("underlined"), 0).Font.Underline = true;
                    ((Excel.Range)worksheet.Cells[itemCount + 5, 1]).get_Characters(text.IndexOf("underlined"), 0).Font.Italic = true;

                    StringBuilder wsName = new StringBuilder();
                    for (int i = 0; i < alBatchID.Count; i++)
                    {
                        DataRow[] drTemp = dtItems.Select("BatchID = " + alBatchID[i].ToString());
                        if (wsName.Length != 0)
                        {
                            wsName.Append(" ");
                        }
                        wsName.Append(FillToFiveChars(drTemp[0]["OrderCode"].ToString()) + FillToThreeChars(drTemp[0]["BatchCode"].ToString()));
                    }

                    if (wsName.Length > 31) // if the file name is getting long Ц lets use order numbers in there only.
                    {
                        wsName = new StringBuilder();
                        for (int i = 0; i < alBatchID.Count; i++)
                        {
                            DataRow[] drTemp = dtItems.Select("BatchID = " + alBatchID[i].ToString());
                            if ((wsName.Length + 6) < 31 && wsName.ToString().IndexOf(FillToFiveChars(drTemp[0]["OrderCode"].ToString())) == -1)
                            {
                                if (wsName.Length != 0)
                                {
                                    wsName.Append(" ");
                                }
                                wsName.Append(FillToFiveChars(drTemp[0]["OrderCode"].ToString()));
                            }
                        }
                    }

                    worksheet.Name = wsName.ToString();
                    workbook.Saved = true;
                    string fileName = worksheet.Name + ".xls";
                    if (File.Exists(sPath + fileName))
                    {
                        File.Delete(sPath + fileName);
                    }

                    workbook.SaveAs(sPath + worksheet.Name + ".xls",
                        Excel.XlFileFormat.xlWorkbookNormal,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Excel.XlSaveAsAccessMode.xlShared, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    return fileName;
                }
                else
                {
                    exceptionText.Append(" are empty");
                    throw new Exception(exceptionText.ToString());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                //Releasing excel objects
                excelApp.UserControl = true;

                workbook.Close(false, sPath + worksheet.Name + ".xls", false);
                workbooks.Close();
                excelApp.Quit();
                NAR(excelApp);
                NAR(workbooks);
                NAR(workbook);
                NAR(sheets);
                NAR(worksheet);

                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                Client.KillOpenExcel();
            }

        }

        /// <summary>
        /// Function check PartName.MeasureName value for item 
        /// and passing CP for this value
        /// by vetal_242 10.03.2006
        /// </summary>
        /// <param name="sItemCode"></param>
        /// <param name="sPartName"></param>
        /// <param name="sMeasureName"></param>
        /// <param name="Girdle"></param>
        /// <param name="dtPartValue"></param>
        /// <param name="dtAdditionalMeasure"></param>
        /// <param name="dtGirdle"></param>
        /// <param name="dtCutGradeRule"></param>
        /// <param name="MeasureReplacement"></param>
        /// <returns>DataSet whith row, contains MeasureValue (Value), flag for passing CP (CP), MeasureCode</returns>
        private DataSet GetMeasureValueByPart(string sItemCode, string sPartName, string sMeasureName, int Girdle, DataTable dtPartValue, DataTable dtAdditionalMeasure, DataTable dtGirdle, DataTable dtCutGradeRule, DataTable dtMeasureReplacement)
        {
            DataSet dsResult = new DataSet();
            dsResult.Tables.Add();

            string sValue = "";
            string sCP = "1";
            string sMeasureCode = "1";

            dsResult.Tables[0].Columns.Add("Value");
            dsResult.Tables[0].Columns.Add("CP");
            dsResult.Tables[0].Columns.Add("MeasureCode");
            dsResult.Tables[0].Rows.Add(dsResult.Tables[0].NewRow());


            if (sMeasureName == "Report Number")
            {
                sValue = dtAdditionalMeasure.Select("ItemCode = '" + sItemCode + "'")[0]["Report Number"].ToString();
                sCP = "1";
                sMeasureCode = "-1";
            }
            else if (sMeasureName == "FullShapeName")
            {
                DataRow[] drPartValue = dtPartValue.Select("ItemCode = '" + sItemCode + "' and MeasureID = '8'" + " and PartName = '" + sPartName + "'");
                if (drPartValue.Length > 0)
                {
                    sValue = drPartValue[0]["LongReportName"].ToString();
                }
                sCP = "1";
                sMeasureCode = "-2";
            }
            else if (sMeasureName == "CPSKU")
            {
                sValue = dtAdditionalMeasure.Select("ItemCode = '" + sItemCode + "'")[0]["CustomerProgramName"].ToString();
                sCP = "1";
                sMeasureCode = "-3";
            }
            else if (sMeasureName == "CPCustomerID")
            {
                sValue = dtAdditionalMeasure.Select("ItemCode = '" + sItemCode + "'")[0]["CPPropertyCustomerID"].ToString();
                sCP = "1";
                sMeasureCode = "-4";
            }
            else if (sMeasureName == "Batch #")
            {
                sValue = dtAdditionalMeasure.Select("ItemCode = '" + sItemCode + "'")[0]["Batch #"].ToString();
                sCP = "1";
                sMeasureCode = "-5";
            }
            else if (sMeasureName == "Item #")
            {
                sValue = dtAdditionalMeasure.Select("ItemCode = '" + sItemCode + "'")[0]["OldItem #"].ToString();
                if (sValue == "")
                {
                    sValue = dtAdditionalMeasure.Select("ItemCode = '" + sItemCode + "'")[0]["Item #"].ToString();
                }
                sCP = "1";
                sMeasureCode = "-6";
            }
            else if (sMeasureName == "Girdle" || sMeasureName == "FullGirdle")
            {
                string sGirdleFrom = "";
                string sGirdleTo = "";
                string sGirdleType = "";
                string sGirdle = "";
                string sPartID = "";

                DataRow[] drPartValue = dtPartValue.Select("PartName = '" + sPartName + "' and ItemCode = '" + sItemCode + "'");
                if (drPartValue.Length > 0)
                {
                    sPartID = drPartValue[0]["PartID"].ToString();
                }
                drPartValue = dtGirdle.Select("PartID = '" + sPartID + "' and ItemCode = '" + sItemCode + "' and MeasureID = '92'");
                if (drPartValue.Length > 0)
                {
                    sGirdleFrom = drPartValue[0]["ValueTitle"].ToString();
                }
                drPartValue = dtGirdle.Select("PartID = '" + sPartID + "' and ItemCode = '" + sItemCode + "' and MeasureID = '93'");
                if (drPartValue.Length > 0)
                {
                    sGirdleTo = drPartValue[0]["ValueTitle"].ToString();
                }

                if (sGirdleFrom != "" && sGirdleTo != "")
                {
                    if (sGirdleFrom != sGirdleTo)
                    {
                        sGirdle = sGirdleFrom + " to " + sGirdleTo;
                    }
                    else
                    {
                        sGirdle = sGirdleFrom;
                    }
                }
                else
                {
                    sGirdle = null;
                }

                if (sMeasureName == "FullGirdle")
                {
                    drPartValue = dtGirdle.Select("PartID = '" + sPartID + "' and ItemCode = '" + sItemCode + "' and MeasureID = '21'");
                    if (drPartValue.Length > 0)
                    {
                        sGirdleType = drPartValue[0]["ValueTitle"].ToString();
                    }

                    if (sGirdle != null && sGirdle != "")
                    {
                        if (sGirdleType != null && sGirdleType != "")
                        {
                            sGirdle = sGirdle + ", " + sGirdleType;
                        }
                        else
                        {
                            sGirdle = sGirdle;
                        }
                    }
                    else
                    {
                        sGirdle = null;
                    }
                    sMeasureCode = "-8";
                }
                else
                {
                    sMeasureCode = "-7";
                }
                sValue = sGirdle;
                sCP = "1";
            }

            else
            {

                DataRow[] drPartValue = dtPartValue.Select("ItemCode = '" + sItemCode + "' and PartName = '" + sPartName + "' and MeasureTitle = '" + sMeasureName + "'");
                if (drPartValue.Length > 0)
                {
                    switch (drPartValue[0]["MeasureClass"].ToString())
                    {
                        case "1":
                            sValue = drPartValue[0]["ValueTitle"].ToString();
                            break;
                        case "2":
                            sValue = drPartValue[0]["StringValue"].ToString();
                            break;
                        case "3":
                            sValue = drPartValue[0]["MeasureValue"].ToString();
                            break;
                        case "4":
                            sValue = drPartValue[0]["StringValue"].ToString();
                            break;
                    }
                    sCP = drPartValue[0]["goCp"].ToString();
                    sMeasureCode = drPartValue[0]["MeasureCode"].ToString();
                }
                else
                {
                    drPartValue = dtMeasureReplacement.Select("MeasureTitle = '" + sMeasureName + "'");
                    if (drPartValue.Length > 0)
                    {
                        if (drPartValue[0]["ReplaceMeasureID"].ToString() == "")
                        {
                            sValue = "";
                        }
                        else
                        {
                            drPartValue = dtPartValue.Select("ItemCode = '" + sItemCode + "' and PartName = '" + sPartName + "' and MeasureID = '" + drPartValue[0]["ReplaceMeasureID"] + "'");
                            if (drPartValue.Length > 0)
                            {
                                switch (drPartValue[0]["MeasureClass"].ToString())
                                {
                                    case "1":
                                        sValue = drPartValue[0]["ValueTitle"].ToString();
                                        break;
                                    case "2":
                                        sValue = drPartValue[0]["StringValue"].ToString();
                                        break;
                                    case "3":
                                        sValue = drPartValue[0]["MeasureValue"].ToString();
                                        break;
                                    case "4":
                                        sValue = drPartValue[0]["StringValue"].ToString();
                                        break;
                                }
                                sCP = drPartValue[0]["goCp"].ToString();
                                sMeasureCode = drPartValue[0]["MeasureCode"].ToString();
                            }
                            else
                            {
                                sValue = "exception";
                            }
                        }
                    }
                    else
                    {
                        sValue = "exception";
                    }
                }
                if (Girdle == 1)
                {
                    if (sValue != "" && sValue != "exception")
                    {
                        drPartValue = dtPartValue.Select("MeasureID = '8' and PartName = '" + sPartName + "' and ItemCode = '" + sItemCode + "'");
                        if (drPartValue.Length > 0)
                        {
                            string sCutGradeGroupID = drPartValue[0]["ShapeCutGradeGroupID"].ToString();

                            if (sCutGradeGroupID != "")
                            {
                                drPartValue = dtPartValue.Select("ItemCode = '" + sItemCode + "' and PartName = '" + sPartName + "' and MeasureCode = '" + sMeasureCode + "'");

                                string sCheckedMeasureCode = drPartValue[0]["MeasureCode"].ToString();
                                if (sCheckedMeasureCode != "25")
                                {
                                    string sCheckedValue = "";

                                    if (drPartValue[0]["ValueCode"].ToString() == "")
                                    {
                                        sCheckedValue = drPartValue[0]["MeasureValue"].ToString();
                                    }
                                    else
                                    {
                                        sCheckedValue = drPartValue[0]["ValueCode"].ToString();
                                    }
                                    drPartValue = dtCutGradeRule.Select("CheckMeasureCode = '" + sCheckedMeasureCode + "' and CutGradeGroupID = '" + sCutGradeGroupID + "'");
                                    bool isCp = false;
                                    for (int i = 0; i < drPartValue.Length; i++)
                                    {
                                        if ((drPartValue[i]["minValue"].ToString() == "" || System.Convert.ToDouble(drPartValue[i]["minValue"]) <= System.Convert.ToDouble(sCheckedValue)) && (drPartValue[i]["maxValue"].ToString() == "" || System.Convert.ToDouble(drPartValue[i]["maxValue"]) >= System.Convert.ToDouble(sCheckedValue)))
                                            isCp = true;
                                    }
                                    if (!isCp && drPartValue.Length > 0)
                                    {
                                        sCP = "0";
                                    }
                                }
                            }
                        }
                    }
                }

            }


            dsResult.Tables[0].Rows[0]["Value"] = sValue;
            dsResult.Tables[0].Rows[0]["CP"] = sCP;
            dsResult.Tables[0].Rows[0]["MeasureCode"] = sMeasureCode;

            return dsResult;
        }

        private void NAR(Object oEx)
        {
            try { System.Runtime.InteropServices.Marshal.ReleaseComObject(oEx); }
            catch { }
            finally { oEx = null; }
        }

        /// <summary>
        /// Function formats measureValue according to MeasureFormats.xml. 
        /// Returns not formatted value if it's not System.Double or if there is no correspondent format in .xml
        /// By 3ter on 2006.04.20
        /// </summary>
        /// <param name="measureCode"></param>
        /// <param name="measureValue"></param>
        /// <returns></returns>
        String FormatMeasure(Object measureCode, Object measureValue)
        {
            CultureInfo myCIintl = new CultureInfo("en-US", false);
            NumberFormatInfo numberInfo = myCIintl.NumberFormat;

            String currentMeasureFormat = "";
            DataRow[] adrFormats = dsFormats.Tables["Format"].Select("MeasureCode = '" + measureCode + "'");
            if (adrFormats.Length == 1)
            {
                currentMeasureFormat = adrFormats[0]["FormatString"].ToString();
            }

            Double temp;
            try { temp = Convert.ToDouble(measureValue, numberInfo); }
            catch { return measureValue.ToString(); }
            return temp.ToString(currentMeasureFormat);
        }

        private String Formats(string sParameter, object oMeasureValue)
        {
            XmlNode myFormatNode;
            double temp;
            string sFormat;
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc = Service.xmlDocFormats;
                XmlNode root = xmlDoc.DocumentElement;
                string sXPath = "FormatTable[Parameter = '" + sParameter + "']";
                myFormatNode = root.SelectSingleNode(sXPath);
                if (myFormatNode != null && oMeasureValue != null)
                {
                    sFormat = myFormatNode.LastChild.InnerText.ToString();
                    temp = Convert.ToDouble(oMeasureValue);
                    return temp.ToString(sFormat);
                }
                else return oMeasureValue.ToString();
            }
            catch { return oMeasureValue.ToString(); }
        }

        private void CreateXL(DataTable dtData, Image img, string sPath)
        {
            Excel.Application excelApp = new Excel.Application();
            if (excelApp == null)
            {
                System.Windows.Forms.MessageBox.Show("EXCEL could not be started. Check that your office installation and project references are correct.",
                    "EXCEL could not be started", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                Console.WriteLine();
            }
            excelApp.Visible = false;
            Excel.Workbooks workbooks = excelApp.Workbooks;
            Excel._Workbook workbook = workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Sheets sheets = workbook.Worksheets;
            Excel._Worksheet worksheet = (Excel._Worksheet)sheets.get_Item(1);
            if (worksheet == null)
            {
                System.Windows.Forms.MessageBox.Show("Worksheet could not be created. Check that your office installation and project references are correct",
                    "Worksheet could not be created", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            worksheet.Name = dtData.Rows[0]["GroupCode"].ToString() + "." + dtData.Rows[0]["BatchCode"].ToString();
            workbook.Title = dtData.Rows[0]["GroupCode"].ToString() + "." + dtData.Rows[0]["BatchCode"].ToString();


            for (int i = 0; i < dtData.Rows.Count; i++)
            {
                int cntr = 1;
                for (int j = 2; j < dtData.Columns.Count; j++)
                {
                    worksheet.Cells.set_Item(1, cntr, dtData.Columns[j].ColumnName);
                    worksheet.Cells.set_Item(i + 2, cntr, dtData.Rows[i][j]);
                    cntr++;
                }
            }

            img.Save("c:\\temp.jpg");
            worksheet.Shapes.AddPicture("c:\\temp.jpg", Microsoft.Office.Core.MsoTriState.msoTrue, Microsoft.Office.Core.MsoTriState.msoTrue, 550, 10, 200, 200);
            File.Delete("c:\\temp.jpg");
            workbook.SaveAs(sPath + worksheet.Name + ".xls",
                Excel.XlFileFormat.xlWorkbookNormal,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Excel.XlSaveAsAccessMode.xlShared, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        }


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
            //			
            if (isEdit)
            {
                EditPdf ed = new EditPdf(pdfFileName);
                if (ipdfEditID == 0)
                    ed.Edit();
                if (ipdfEditID == 1)
                    ed.EditSitaraPdf();
            }


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
            while (sNumber.Length < 5)
                sNumber = "0" + sNumber;
            return sNumber;
        }
        private string FillToThreeChars(string sNumber)
        {
            while (sNumber.Length < 3)
                sNumber = "0" + sNumber;
            return sNumber;
        }

        private string FillToTwoChars(string sNumber)
        {
            while (sNumber.Length < 2)
                sNumber = "0" + sNumber;
            return sNumber;
        }

        private static System.Drawing.Image ExtractImageFromString(string sImage, string sImageFileName)
        {
            byte[] buf = Convert.FromBase64String(sImage);
            int wmfI = sImageFileName.LastIndexOf(".wmf");
            int emfI = sImageFileName.LastIndexOf(".emf");
            if (wmfI > 0 && wmfI == sImageFileName.Length - 4 || emfI > 0 && emfI == sImageFileName.Length - 4)
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
            string sPrinter = "";
            int k = 0;
            XmlNodeList xnlList = null;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc = Service.xmlPrinters;
            PrinterSettings ps = new PrinterSettings();

            try
            {
				xnlList = xmlDoc.GetElementsByTagName(sReportName);
                sPrinter = xnlList[0].InnerText.ToString().Trim().ToUpper();
                foreach (string printer in PrinterSettings.InstalledPrinters)
                {
					if (printer.Trim().ToUpper().Contains(sPrinter.ToUpper()))
					{
						sPrinter = printer;
						break;
					}
					//k = printer.Trim().ToUpper().IndexOf(sPrinter);
					//if (k >= 0)
					//{
					//    if (sPrinter == printer.Substring(k).Trim().ToUpper())
					//    {
					//        sPrinter = printer;
					//        break;
					//    }
					//}
				}

            }
            catch (Exception eEx)
            {
                sPrinter = ps.PrinterName;
            }
            return sPrinter;
        }

        private string GetReportNumber()
        {
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            string sNumber = "";
            if (!System.IO.File.Exists(sReportsDir + "ReportNumber.xml"))
            {

            }

            try
            {
                doc.Load(sReportsDir + @"ReportNumber.xml");
                System.Xml.XmlNodeList nodes = doc.GetElementsByTagName("Number");
                sNumber = nodes[0].InnerText.ToString().Trim();
                int iNum = Convert.ToInt32(sNumber);
                if (!isView)
                    iNum++;
                sNumber = iNum.ToString();
                nodes[0].InnerText = sNumber;
                doc.Save(sReportsDir + @"ReportNumber.xml");
            }
            catch (Exception exc)
            {

            }


            return sNumber;
        }


        private string GetGifPathFromXml()
        {
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            string sXmlPath = gemoDream.Service.sAppDir + @"\clientcfg.xml";
            string sGifPath = "";
            try
            {
                doc.Load(sXmlPath);
                System.Xml.XmlNodeList nodes = doc.GetElementsByTagName("marksFolder");
                sGifPath = nodes[0].InnerText.ToString().Trim();
            }
            catch (Exception exc)
            {
                Trace.WriteLine(exc.Source.ToString() + " " + exc.Message.ToString());
            }

            return sGifPath;
        }


        private string GetMeasureValue(string sMeasureName, DataTable tTable, string sPartID)
        {
            DataRow[] rParts = null;
            string sRet = "";
            try
            {

                if (tTable.Rows.Count > 0)
                {
                    rParts = tTable.Select("MeasureTitle=" + "'" + sMeasureName + "'" + " and PartID=" + sPartID);

                    switch (rParts[0]["MeasureClass"].ToString())
                    {
                        case "1": sRet = rParts[0]["MeasureValueTitle"].ToString(); break;
                        case "2": sRet = rParts[0]["StringValue"].ToString(); break;
                        case "3": sRet = rParts[0]["MeasureValue"].ToString(); break;
                        case "4": sRet = rParts[0]["StringValue"].ToString(); break;
                    }

                    Trace.WriteLine(sMeasureName + "=" + rParts[0]["MeasureValueTitle"].ToString());
                    Trace.WriteLine(sMeasureName + "=" + rParts[0]["StringValue"].ToString());
                    Trace.WriteLine(sMeasureName + "=" + rParts[0]["MeasureValue"].ToString());

                    //sRet=rParts[0]["MeasureValueName"].ToString();
                }


            }
            catch (Exception exc)
            {
                Trace.WriteLine(exc.Source.ToString() + " " + exc.Message.ToString());
            }

            return sRet;

        }

        private Stream StreamImageFile(string sFileName)
        {
            return new FileStream(sFileName, FileMode.Open, FileAccess.Read);

        }


        private void Debug_DataSet(DataSet dsData)
        {
            foreach (DataTable table in dsData.Tables)
            {
                Trace.WriteLine("--------" + "Table:" + table.TableName.ToString() + "------------");
                foreach (DataColumn col in table.Columns)
                    Trace.WriteLine(col.Caption.ToString());

            }
        }

        private void Debug_Row(DataRow row)
        {
            Trace.WriteLine("-----------------------------------------");
            for (int i = 0; i < row.Table.Columns.Count; i++)
            {
                Trace.Write(row.Table.Columns[i].ColumnName.ToString() + "=");
                Trace.WriteLine(row[i].ToString());
            }
        }

		public void GetDataFromExcel(string sExcelFile, ref DataSet dsDatafromXLS)
		{
			OleDbDataAdapter MyAdapter;
			OleDbConnection MyConnection;

			try
			{
				Open_Excel(sExcelFile);
				Excel.Worksheet SheetData = (Excel.Worksheet)BookTemp.Sheets[1];
				string conn01 = "";
				string sWS = SheetData.Name;
				if (sExcelFile.ToLower().Contains(".xlsx"))
					conn01 = "Provider=Microsoft.ACE.OLEDB.12.0; " + "Data Source= " + sExcelFile + "; Extended Properties='Excel 12.0;HDR=Yes'";
				else
					conn01 = "Provider=Microsoft.JET.OLEDB.4.0; " + "Data Source= " + sExcelFile + "; Extended Properties='Excel 8.0;HDR=Yes'";
				MyConnection = new OleDbConnection(conn01);
				MyAdapter = new OleDbDataAdapter("select * from [" + sWS + "$]", MyConnection);

				MyAdapter.Fill(dsDatafromXLS);
				MyConnection.Close();
			}
			catch (Exception ex)
			{
				string a = ex.Message;
			}
			finally
			{
				CloseExcel();
			}
		}

        #region Excel Reports
        public void CloseExcel()
        {
            try
            {
                objExcel.DisplayAlerts = false;
                foreach (Excel.Workbook Book in objExcel.Workbooks)
                {
                    Book.Saved = true;
                    Book.Close(Type.Missing, Type.Missing, Type.Missing);
                }
                objExcel.Workbooks.Close();
                objExcel.Quit();
                objExcel = null;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            finally
            {
                NAR(objExcel);
                //objExcel=null;
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        public string Excel_Label_BatchNew(ArrayList outlist, Boolean toPrint)
        {
			string sBatchID = outlist[0].ToString();
            string sReportPath;
            string sTemp = "";
            sTemp = Environment.GetEnvironmentVariable("TEMP");
            if (sTemp == "") sTemp = "c:";
            //string fnTemp = @"c:\Label_Batch" + sBatchID + ".xls";
            string fnTemp = sTemp + "\\Label_Batch" + sBatchID + ".xls";

            DataSet dsBatch = Service.GetCrystalSet(sBatchID, "BatchWithCustomer");//Procedure dbo.spGetBatchWithCustomer
            string sGroupCode = dsBatch.Tables[0].Rows[0]["GroupCode"].ToString();
            string sBatchCode = FillToThreeChars(dsBatch.Tables[0].Rows[0]["BatchCode"].ToString());
            
            //DataTable dtItems = Service.GetItemByCode(dsBatch.Tables[0].Rows[0]["GroupCode"].ToString(),
                //dsBatch.Tables[0].Rows[0]["BatchCode"].ToString(), null);//Procedure dbo.spGetItemByCode

            StringBuilder sbOldNumbers = new StringBuilder("");
            string sReportsDir = Client.GetOfficeDirPath("repDir");

			//string sCRTemplatePath = Service.GetCRTemplatePath();
			if (!toPrint) return FillToFiveChars(sGroupCode) + "." + FillToThreeChars(sBatchCode) + ".";
			else
			{
				if (outlist.Count > 1)
				{
					sReportPath = sReportsDir + @"label_batch_on.xls";
					//MessageBox.Show("Line 3445, CrystalReport, Path to excel file: " + sReportPath);
					/*
					foreach (DataRow drItem in dtItems.Rows)
					{
						if (sbOldNumbers.Length != 0) sbOldNumbers.Append(" ");
						sbOldNumbers.Append(FillToFiveChars(drItem["PrevGroupCode"].ToString()) + "." + FillToThreeChars(drItem["PrevBatchCode"].ToString()) + "." +
							FillToTwoChars(drItem["PrevItemCode"].ToString()));
					}
					*/

					foreach (var outItem in outlist)
					{
						string sItemCode = outItem.ToString();
						if (!sItemCode.Contains("_"))
							continue;
						else
							sbOldNumbers.Append(" ");
						sItemCode = sItemCode.Substring(sItemCode.IndexOf("_") + 1);
						sbOldNumbers.Append(FillToFiveChars(sGroupCode) + "." + FillToThreeChars(sBatchCode) + "." + FillToTwoChars(sItemCode));
					}
				}
				else
				{
					sReportPath = sReportsDir + @"Labal_Batch.xls";
				}

				sPrinterName = GetPrinterName("Label_Batch");
				//MessageBox.Show("Line 3472, CrystalReport, selected printer for batch label: " + sPrinterName);
				#region  Open Excel
				//	objExcel = null ;
				Excel.Workbook BookData = null;
				Excel.Workbook BookTemp = null;
				try
				{
					Client.KillOpenExcel();

					objExcel = new Excel.Application();
					try
					{
						BookData = objExcel.Workbooks.Open(sReportPath, Type.Missing, true, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
					}
					catch (Exception ex)
					{
						throw new Exception("file not found");
					}
					BookData.SaveCopyAs(fnTemp);
					BookData.Close(false, sReportPath, null);
					//make local copy

					BookTemp = objExcel.Workbooks.Open(fnTemp, Type.Missing, false, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
					Excel.Worksheet SheetData = (Excel.Worksheet)BookTemp.Sheets[2];

					DataSet dsGroup = gemoDream.Service.GetCrystalSet(dsBatch.Tables[0].Rows[0]["GroupOfficeID_GroupID"].ToString(), "GroupWithCustomer");//Procedure dbo.spGetGroupWithCustomer
					DataRow rGroup = dsGroup.Tables[0].Rows[0];

					string sOrderDate = rGroup["CreateDate"].ToString();
					System.DateTime dOrderDate = System.DateTime.Parse(sOrderDate);

					DataSet dsServiceType = gemoDream.Service.GetCrystalSet(rGroup["ServiceTypeID"].ToString(), "ServiceType");
					DataRow rBatch = dsBatch.Tables[0].Rows[0];

					string sDeliveryMethod = "";
					string sAccount = "";
					string sCarrier = "";

					if (rBatch["WeCarry"].ToString() == "1")
					{
						sDeliveryMethod = "We Carry";
					}

					if (rBatch["TheyCarry"].ToString() == "1")
					{
						sDeliveryMethod = "They Carry";
					}

					if (rBatch["WeShipCarry"].ToString() == "1")
					{
						sDeliveryMethod = "We Ship Carry";
						try
						{
							sAccount = rBatch["Account"].ToString();
							DataSet dsCustomerTypeEx = gemoDream.Service.GetCustomerTypeEx();
							DataTable tblCarriers = dsCustomerTypeEx.Tables["Carriers"].Copy();
							DataRow[] rCarrier = tblCarriers.Select("CarrierID=" + rBatch["CarrierID"]);
							sCarrier = rCarrier[0]["CarrierName"].ToString();
							sDeliveryMethod = "We Use Their Account To Ship";
						}
						catch
						{
							sAccount = "";
							sCarrier = "";
						}
					}

					//string sBatchCode = FillToThreeChars(rBatch["BatchCode"].ToString());
					//string sGroupCode = FillToFiveChars(rBatch["GroupCode"].ToString());

					Excel.Range crCell = null;

					crCell = SheetData.get_Range("b2", Type.Missing);
					crCell.Cells.Value2 = "*" + sGroupCode + sBatchCode + "*"; //barcode

					crCell = SheetData.get_Range("b3", Type.Missing);
					crCell.Cells.Value2 = sGroupCode;
					crCell = SheetData.get_Range("b4", Type.Missing);
					crCell.Cells.Value2 = sGroupCode + "." + sBatchCode;

					crCell = SheetData.get_Range("b9", Type.Missing);
					crCell.Cells.Value2 = rBatch["CustomerName"].ToString();  //"Customer";

					crCell = SheetData.get_Range("b11", Type.Missing);
					crCell.Cells.Value2 = (outlist.Count - 1).ToString(); //rBatch["ItemsQuantity"].ToString(); //"# of items";

					if (sbOldNumbers.Length > 0)
					{
						crCell = SheetData.get_Range("b27", Type.Missing);//items1
						crCell.Cells.Value2 = sbOldNumbers.ToString();//OldNumbers
					}

					crCell = SheetData.get_Range("b18", Type.Missing);
					crCell.Cells.Value2 = sDeliveryMethod;//delivery method
					crCell = SheetData.get_Range("b17", Type.Missing);
					crCell.Cells.Value2 = sCarrier;//Carrier
					crCell = SheetData.get_Range("b22", Type.Missing);
					crCell.Cells.Value2 = sAccount;//Account #
					crCell = SheetData.get_Range("b24", Type.Missing);
					crCell.Cells.Value2 = rBatch["MemoNumber"].ToString();  //"MemoNumber";

					crCell = SheetData.get_Range("b13", Type.Missing);
					if (rBatch["ItemsWeight"].ToString() != "")
						crCell.Cells.Value2 = rBatch["ItemsWeight"].ToString() + " ct."; //weight
					else
						crCell.Cells.Value2 = "";

					string sDate = dsBatch.Tables[0].Rows[0]["CreateDate"].ToString();
					System.DateTime ddDate = System.DateTime.Parse(sDate);

					crCell = SheetData.get_Range("b5", Type.Missing);
					//dOrderDate
					crCell.Cells.Value2 = dOrderDate.Date.ToShortDateString(); //Date from Order created date
																			   //crCell.Cells.Value2 = ddDate.Date.ToShortDateString(); //date

					crCell = SheetData.get_Range("b6", Type.Missing);
					crCell.Cells.Value2 = dOrderDate.TimeOfDay.ToString();//Time from Order created date
																		  //crCell.Cells.Value2 = ddDate.TimeOfDay.ToString();// time

					crCell = SheetData.get_Range("b21", Type.Missing);
					crCell.Cells.Value2 = "00.00.0000"; //date
					crCell = SheetData.get_Range("b20", Type.Missing);
					crCell.Cells.Value2 = "00:00"; // time

					crCell = SheetData.get_Range("b8", Type.Missing);
					crCell.Cells.Value2 = rBatch["ExtPhone"].ToString();

					crCell = SheetData.get_Range("b15", Type.Missing);
					crCell.Cells.Value2 = rBatch["CustomerProgramName"].ToString();
					crCell = SheetData.get_Range("b21", Type.Missing);
					crCell.Cells.Value2 = "00.00.0000"; //date

					if (!(sbOldNumbers.Length > 0))
					{
						DataTable dtCheckedOperations = GetCheckedOperations(sBatchID);
						if (dtCheckedOperations.Rows.Count > 0)
						{
							for (int i = 0; i < System.Math.Min(dtCheckedOperations.Rows.Count, 10); i++)
							{
								if (i == 0)
								{
									crCell = SheetData.get_Range("b30", Type.Missing);
									crCell.Cells.Value2 = dtCheckedOperations.Rows[i][0].ToString();
								}
								else //if(i>0 && i<10)
								{

									int index = (31 + i * 2);
									string textObjectIndex = "b" + (index + 1).ToString();
									crCell = SheetData.get_Range(textObjectIndex, Type.Missing);
									crCell.Cells.Value2 = dtCheckedOperations.Rows[i][0].ToString();
								}
							}
						}
					}
					try
					{
						crCell = SheetData.get_Range("b26", Type.Missing);
						crCell.Cells.Value2 = dsServiceType.Tables[0].Rows[0]["ServiceTypeName"].ToString();
					}
					catch { }
					//print
					Excel.Worksheet SheetLabel = (Excel.Worksheet)BookTemp.Sheets[1];
					SheetLabel.PrintOut(Type.Missing, Type.Missing, 1, false, sPrinterName, Type.Missing, true, Type.Missing);
#if DEBUG
				string sTempXLSLabel = @"\Reports_etc\New Folder\";
				if (!Directory.Exists(Service.sTempDir + sTempXLSLabel)) Directory.CreateDirectory(Service.sTempDir + sTempXLSLabel);
				string myFile = Service.sTempDir + sTempXLSLabel + sGroupCode + "." + sBatchCode + ".xls";
				if (File.Exists(myFile)) File.Delete(myFile);
				SheetData.SaveAs(myFile, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
#endif

					NAR(crCell);
					NAR(SheetData);
					NAR(SheetLabel);
					crCell = null;
					SheetLabel = null;
					SheetData = null;
				}
				catch (Exception ex)
				{
					string msg = ex.Message;
					if (msg == "file not found")
					{
						throw new Exception("The system cannot find the file: " + sReportPath);
					}
				}
				finally
				{
					try
					{
						//BookTemp.Save();//save for test
						BookTemp.Close(false, fnTemp, null);
					}
					catch (Exception ex)
					{ }
					try
					{ BookData.Close(false, sReportPath, null); }
					catch (Exception ex)
					{ }
					try
					{
						//objExcel.Quit();

						NAR(BookTemp);
						NAR(BookData);
						//NAR(objExcel);

						BookTemp = null;
						BookData = null;
						//objExcel=null;

						/*
						GC.Collect();
						GC.WaitForPendingFinalizers(); 
						GC.Collect();*/
					}
					catch (Exception ex)
					{ }
					try
					{
						if (File.Exists(fnTemp))
							File.Delete(fnTemp);
					}
					catch { }

				}
				return FillToFiveChars(sGroupCode) + "." + FillToThreeChars(sBatchCode) + ".";
			}
				#endregion
        }

        public void Excel_Label_Batch(string sBatchID)
        {

            string sReportPath;
            string sTemp = "";
            sTemp = Environment.GetEnvironmentVariable("TEMP");
            if (sTemp == "") sTemp = "c:";
            //string fnTemp = @"c:\Label_Batch" + sBatchID + ".xls";
            string fnTemp = sTemp + "\\Label_Batch" + sBatchID + ".xls";

            DataSet dsBatch = Service.GetCrystalSet(sBatchID, "BatchWithCustomer");//Procedure dbo.spGetBatchWithCustomer

            DataTable dtItems = Service.GetItemByCode(dsBatch.Tables[0].Rows[0]["GroupCode"].ToString(),
                dsBatch.Tables[0].Rows[0]["BatchCode"].ToString(), null);//Procedure dbo.spGetItemByCode

            StringBuilder sbOldNumbers = new StringBuilder("");
            string sReportsDir = Client.GetOfficeDirPath("repDir");
            //string sCRTemplatePath = Service.GetCRTemplatePath();
            if (dtItems.Rows[0]["PrevGroupCode"].ToString() != "")
            {
                sReportPath = sReportsDir + @"label_batch_on.xls";

                foreach (DataRow drItem in dtItems.Rows)
                {
                    if (sbOldNumbers.Length != 0) sbOldNumbers.Append(" ");
                    sbOldNumbers.Append(FillToFiveChars(drItem["PrevGroupCode"].ToString()) + "." + FillToThreeChars(drItem["PrevBatchCode"].ToString()) + "." +
                        FillToTwoChars(drItem["PrevItemCode"].ToString()));
                }
            }
            else
            {
                sReportPath = sReportsDir + @"Labal_Batch.xls";
            }

            sPrinterName = GetPrinterName("Label_Batch");
            #region  Open Excel
            //	objExcel = null ;
            Excel.Workbook BookData = null;
            Excel.Workbook BookTemp = null;
            try
            {
                Client.KillOpenExcel();

                objExcel = new Excel.Application();
                try
                {
                    BookData = objExcel.Workbooks.Open(sReportPath, Type.Missing, true, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                }
                catch (Exception ex)
                {
                    throw new Exception("file not found");
                }
                BookData.SaveCopyAs(fnTemp);
                BookData.Close(false, sReportPath, null);
                //make local copy

                BookTemp = objExcel.Workbooks.Open(fnTemp, Type.Missing, false, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                Excel.Worksheet SheetData = (Excel.Worksheet)BookTemp.Sheets[2];

                DataSet dsGroup = gemoDream.Service.GetCrystalSet(dsBatch.Tables[0].Rows[0]["GroupOfficeID_GroupID"].ToString(), "GroupWithCustomer");//Procedure dbo.spGetGroupWithCustomer
                DataRow rGroup = dsGroup.Tables[0].Rows[0];

                string sOrderDate = rGroup["CreateDate"].ToString();
                System.DateTime dOrderDate = System.DateTime.Parse(sOrderDate);

                DataSet dsServiceType = gemoDream.Service.GetCrystalSet(rGroup["ServiceTypeID"].ToString(), "ServiceType");


                DataRow rBatch = dsBatch.Tables[0].Rows[0];

                string sDeliveryMethod = "";
                string sAccount = "";
                string sCarrier = "";

                if (rBatch["WeCarry"].ToString() == "1")
                {
                    sDeliveryMethod = "We Carry";
                }

                if (rBatch["TheyCarry"].ToString() == "1")
                {
                    sDeliveryMethod = "They Carry";
                }

                if (rBatch["WeShipCarry"].ToString() == "1")
                {
                    sDeliveryMethod = "We Ship Carry";
                    try
                    {
                        sAccount = rBatch["Account"].ToString();
                        DataSet dsCustomerTypeEx = gemoDream.Service.GetCustomerTypeEx();
                        DataTable tblCarriers = dsCustomerTypeEx.Tables["Carriers"].Copy();
                        DataRow[] rCarrier = tblCarriers.Select("CarrierID=" + rBatch["CarrierID"]);
                        sCarrier = rCarrier[0]["CarrierName"].ToString();
                        sDeliveryMethod = "We Use Their Account To Ship";
                    }
                    catch
                    {
                        sAccount = "";
                        sCarrier = "";
                    }
                }

                string sBatchCode = FillToThreeChars(rBatch["BatchCode"].ToString());
                string sGroupCode = FillToFiveChars(rBatch["GroupCode"].ToString());

                Excel.Range crCell = null;

                crCell = SheetData.get_Range("b2", Type.Missing);
                crCell.Cells.Value2 = "*" + sGroupCode + sBatchCode + "*"; //barcode

                crCell = SheetData.get_Range("b3", Type.Missing);
                crCell.Cells.Value2 = sGroupCode;
                crCell = SheetData.get_Range("b4", Type.Missing);
                crCell.Cells.Value2 = sGroupCode + "." + sBatchCode;

                crCell = SheetData.get_Range("b9", Type.Missing);
                crCell.Cells.Value2 = rBatch["CustomerName"].ToString();  //"Customer";

                crCell = SheetData.get_Range("b11", Type.Missing);
                crCell.Cells.Value2 = rBatch["ItemsQuantity"].ToString(); //"# of items";

                if (sbOldNumbers.Length > 0)
                {
                    crCell = SheetData.get_Range("b27", Type.Missing);//items1
                    crCell.Cells.Value2 = sbOldNumbers.ToString();//OldNumbers
                }

                crCell = SheetData.get_Range("b18", Type.Missing);
                crCell.Cells.Value2 = sDeliveryMethod;//delivery method
                crCell = SheetData.get_Range("b17", Type.Missing);
                crCell.Cells.Value2 = sCarrier;//Carrier
                crCell = SheetData.get_Range("b22", Type.Missing);
                crCell.Cells.Value2 = sAccount;//Account #
                crCell = SheetData.get_Range("b24", Type.Missing);
                crCell.Cells.Value2 = rBatch["MemoNumber"].ToString();  //"MemoNumber";

                crCell = SheetData.get_Range("b13", Type.Missing);
                if (rBatch["ItemsWeight"].ToString() != "")
                    crCell.Cells.Value2 = rBatch["ItemsWeight"].ToString() + " ct."; //weight
                else
                    crCell.Cells.Value2 = "";

                string sDate = dsBatch.Tables[0].Rows[0]["CreateDate"].ToString();
                System.DateTime ddDate = System.DateTime.Parse(sDate);

                crCell = SheetData.get_Range("b5", Type.Missing);
                //dOrderDate
                crCell.Cells.Value2 = dOrderDate.Date.ToShortDateString(); //Date from Order created date
                //crCell.Cells.Value2 = ddDate.Date.ToShortDateString(); //date

                crCell = SheetData.get_Range("b6", Type.Missing);
                crCell.Cells.Value2 = dOrderDate.TimeOfDay.ToString();//Time from Order created date
                //crCell.Cells.Value2 = ddDate.TimeOfDay.ToString();// time

                crCell = SheetData.get_Range("b21", Type.Missing);
                crCell.Cells.Value2 = "00.00.0000"; //date
                crCell = SheetData.get_Range("b20", Type.Missing);
                crCell.Cells.Value2 = "00:00"; // time

                crCell = SheetData.get_Range("b8", Type.Missing);
                crCell.Cells.Value2 = rBatch["ExtPhone"].ToString();

                crCell = SheetData.get_Range("b15", Type.Missing);
                crCell.Cells.Value2 = rBatch["CustomerProgramName"].ToString();
                crCell = SheetData.get_Range("b21", Type.Missing);
                crCell.Cells.Value2 = "00.00.0000"; //date

                if (!(sbOldNumbers.Length > 0))
                {
                    DataTable dtCheckedOperations = GetCheckedOperations(sBatchID);
                    if (dtCheckedOperations.Rows.Count > 0)
                    {
                        for (int i = 0; i < System.Math.Min(dtCheckedOperations.Rows.Count, 10); i++)
                        {
                            if (i == 0)
                            {
                                crCell = SheetData.get_Range("b30", Type.Missing);
                                crCell.Cells.Value2 = dtCheckedOperations.Rows[i][0].ToString();
                            }
                            else //if(i>0 && i<10)
                            {

                                int index = (31 + i * 2);
                                string textObjectIndex = "b" + (index + 1).ToString();
                                crCell = SheetData.get_Range(textObjectIndex, Type.Missing);
                                crCell.Cells.Value2 = dtCheckedOperations.Rows[i][0].ToString();
                            }
                        }
                    }
                }
                try
                {
                    crCell = SheetData.get_Range("b26", Type.Missing);
                    crCell.Cells.Value2 = dsServiceType.Tables[0].Rows[0]["ServiceTypeName"].ToString();
                }
                catch { }
                //print
               Excel.Worksheet SheetLabel = (Excel.Worksheet)BookTemp.Sheets[1];
               SheetLabel.PrintOut(Type.Missing, Type.Missing, 1, false, sPrinterName, Type.Missing, true, Type.Missing);
#if DEBUG
				string sTempXLSLabel = @"\Reports_etc\New Folder\";
				if (!Directory.Exists(Service.sTempDir + sTempXLSLabel)) Directory.CreateDirectory(Service.sTempDir + sTempXLSLabel);
				string myFile = Service.sTempDir + sTempXLSLabel + sGroupCode + "." + sBatchCode + ".xls";
				if (File.Exists(myFile)) File.Delete(myFile);
				SheetData.SaveAs(myFile, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
#endif
 

                NAR(crCell);
                NAR(SheetData);
                NAR(SheetLabel);
                crCell = null;
                SheetLabel = null;
                SheetData = null;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                if (msg == "file not found")
                {
                    throw new Exception("The system cannot find the file: " + sReportPath);
                }
            }
            finally
            {
                try
                {
                    //BookTemp.Save();//save for test
                    BookTemp.Close(false, fnTemp, null);
                }
                catch (Exception ex)
                { }
                try
                { BookData.Close(false, sReportPath, null); }
                catch (Exception ex)
                { }
                try
                {
                    //objExcel.Quit();

                    NAR(BookTemp);
                    NAR(BookData);
                    //NAR(objExcel);

                    BookTemp = null;
                    BookData = null;
                    //objExcel=null;

                    /*
                    GC.Collect();
                    GC.WaitForPendingFinalizers(); 
                    GC.Collect();*/
                }
                catch (Exception ex)
                { }
                try
                {
                    if (File.Exists(fnTemp))
                        File.Delete(fnTemp);
                }
                catch { }
            }
            #endregion

        }
        public void Open_Excel(string MyReport)
        {
            try
            {
                if (MyReport.Trim() != "")
                {
					if (objExcel == null)
                    {
                        objExcel = new Excel.Application();
                        BookTemp = objExcel.Workbooks.Open(MyReport, Type.Missing, true, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    }
                    else
                    {
                        if (Client.MyActiveReportName != MyReport)
                        {
                            try
                            {
                                foreach (Excel.Workbook Book in objExcel.Workbooks)
                                {

                                    Book.Saved = true;
                                    Book.RejectAllChanges(Type.Missing, Type.Missing, Type.Missing);
                                    Book.Close(Type.Missing, Type.Missing, Type.Missing);
                                }
                                BookTemp = objExcel.Workbooks.Open(MyReport, Type.Missing, true, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                            }
                            catch
                            {
                                BookTemp = objExcel.Workbooks.Open(MyReport, Type.Missing, true, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                            }
                        }
                    }
					
                }
                Client.MyActiveReportName = MyReport;
            }
            catch (Exception ex)
            {
                throw new Exception("file not found");
            }
        }
        public void Excel_Sarin_Label_Item(string sItemID)
        {
            string sPrinterName = "";
            string sReportPath = "";
            sReportPath = Client.GetOfficeDirPath("repDir") + @"label_item.xls";
            sPrinterName = GetPrinterName("Label_Item");
            string[] split = sItemID.Split('_');
            DataSet dsRecvSet = Service.GetCrystalSet(sItemID, "Item");
            DataTable dtPartValue = gemoDream.Service.GetPartValueByBatchIDItemCode(split[0], split[1]);
            Open_Excel(sReportPath);
            DataView dvGNumber, dvPrefix, dvSuffix;
            dvGNumber = new DataView(dtPartValue);
            dvPrefix = new DataView(dtPartValue);
            dvSuffix = new DataView(dtPartValue);

            foreach (DataRow row in dsRecvSet.Tables[0].Rows)
            {
                string sBatchID_ItemCode = row["BatchID_ItemCode"].ToString();
                string sGroupCode = FillToFiveChars(row["GroupCode"].ToString());
                string sBatchCode = FillToThreeChars(row["BatchCode"].ToString());
                string sItemCode = FillToTwoChars(row["ItemCode"].ToString());

                string sOldGroupCode = FillToFiveChars(row["PrevGroupCode"].ToString());
                string sOldBatchCode = FillToThreeChars(row["PrevBatchCode"].ToString());
                string sOldItemCode = FillToTwoChars(row["PrevItemCode"].ToString());

                string sOldNumber = "";
                if (sOldGroupCode != "00000" && sOldBatchCode != "000" && sOldItemCode != "00" &&
                    (sOldGroupCode + sOldBatchCode + sOldItemCode) != (sGroupCode + sBatchCode + sItemCode))
                {
                    sOldNumber = " (" + sOldGroupCode + "." + sOldBatchCode + "." + sOldItemCode + ")";
                }
                string SKU = row["CustomerProgramName"].ToString();

                try
                {
                    dvGNumber.RowFilter = "BatchID_ItemCode = " + "'" + sBatchID_ItemCode + "'"
                                            + " and PartTypeID = 1" + " and MeasureCode = 110";
                    dvPrefix.RowFilter = "BatchID_ItemCode = " + "'" + sBatchID_ItemCode + "'"
                        + " and PartTypeID = 1" + " and MeasureCode = 112";
                    dvSuffix.RowFilter = "BatchID_ItemCode = " + "'" + sBatchID_ItemCode + "'"
                        + " and PartTypeID = 1" + " and MeasureCode = 122";
                    if (dvGNumber.Count > 0 && dvPrefix.Count > 0 && dvGNumber.Count == dvPrefix.Count)
                    {
                        foreach (DataRowView row1 in dvGNumber)
                        {
                            int PartID = 0;
                            string[] sGNumber;
                            string sPrefix = "";
                            string SarinNumber = "";
                            string sSuffix = "";

                            PartID = Convert.ToInt16(row1["PartID"].ToString());
                            sGNumber = row1["ResultValue"].ToString().Split('.');
                            DataRow[] rowPrefix = dvPrefix.Table.Select("PartID = " + PartID + " and MeasureCode = 112");
                            sPrefix = rowPrefix[0]["ResultValue"].ToString().Trim();
                            DataRow[] rowSuffix = dvSuffix.Table.Select("PartID = " + PartID + " and MeasureCode = 122");
                            sSuffix = rowSuffix[0]["ResultValue"].ToString().Trim();
                            if (sSuffix.Trim() != "") sSuffix = "-" + sSuffix;
                            if (sPrefix.Trim() != "") sPrefix = sPrefix + "-";

                            SarinNumber = sPrefix.Trim() + sGNumber[0] + sSuffix.Trim();

                            Excel.Worksheet SheetData = (Excel.Worksheet)BookTemp.Sheets[4];
                            SheetData.Shapes.Item("BarCode").TextFrame.Characters(Type.Missing, Type.Missing).Text = "*" + SarinNumber + "*"; //barcode
                            SheetData.Shapes.Item("ItemNumber").TextFrame.Characters(Type.Missing, Type.Missing).Text = "Sarin# " + SarinNumber; //Sarin Number
                            SheetData.Shapes.Item("Weight").TextFrame.Characters(Type.Missing, Type.Missing).Text = sGroupCode + "." + sBatchCode + "." + sItemCode + sOldNumber;//Item Number
                            SheetData.Shapes.Item("SKU").TextFrame.Characters(Type.Missing, Type.Missing).Text = "SKU: " + SKU; //sku
                            SheetData.PrintOut(1, 1, 1, false, sPrinterName, Type.Missing, true, Type.Missing);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Problem with select: " + ex.Message);
                }
            }
        }

        public void Excel_Label_Item(string sItemID)
        {
			var PrintRegular = true;
			string sPrinterName = "";
			string[] sNumber = sItemID.Split('_');
			string sReportName = "Label_Item.xls";
			string sReportFolder = Client.GetOfficeDirPath("repDir");
			string sReportPath = sReportFolder + sReportName;
			int k = sReportName.ToUpper().IndexOf(".XLS");
			sPrinterName = GetPrinterName(sReportName.Substring(0, k));

            DataSet dsRecvSet = Service.GetCrystalSet(sItemID, "Item_New_1");//Procedure dbo.spGetItem_new_1
			string sSKU = "";

			if (dsRecvSet.Tables[0].Rows.Count > 0) sSKU = dsRecvSet.Tables[0].Rows[0]["CustomerProgramName"].ToString().Trim();
			else return;

			sReportName = "Label_Item_Pr.xls"; // - barcode 39
			var sReportName128 = "Label_Item_128.xls"; // barcode 128
			Open_Excel(sReportFolder + sReportName);
            foreach (DataRow row in dsRecvSet.Tables[0].Rows)
            {
                //row = dsRecvSet.Tables[0].Rows;
				string sPrefix = "";
				string SarinLRID = "";
				string SarinID = "";

				SarinLRID = row["SarinLRID"].ToString().Trim();
				SarinID = row["SarinID"].ToString().Trim();
                //if (SarinLRID.Trim() == "2000")
                //{
                //    //sReportPath = sReportFolder + "Label_CID.xls";
                //    PrintCID_Labels(row, sPrinterName, sReportPath);
                //}
                //else
                //{
                string sGroupCode = FillToFiveChars(row["GroupCode"].ToString());
                string sBatchID = FillToThreeChars(row["BatchCode"].ToString());
                string sItemCode = FillToTwoChars(row["ItemCode"].ToString());

                string sOldGroupCode = FillToFiveChars(row["PrevGroupCode"].ToString());
                string sOldBatchCode = FillToThreeChars(row["PrevBatchCode"].ToString());
                string sOldItemCode = FillToTwoChars(row["PrevItemCode"].ToString());

                string sOldNumber = "";
                if (sOldGroupCode != "00000" && sOldBatchCode != "000" && sOldItemCode != "00" &&
                    (sOldGroupCode + sOldBatchCode + sOldItemCode) != (sGroupCode + sBatchID + sItemCode))
                {
                    sOldNumber = " (" + sOldGroupCode + "." + sOldBatchCode + "." + sOldItemCode + ")";
                }

                DataSet dsResults = new DataSet();

                if (SarinLRID.Trim() == "2000")
                {
 
                    dsResults.Tables.Add("CIDInfo");
                    dsResults.Tables[0].Columns.Add("GroupCode");
                    dsResults.Tables[0].Columns.Add("Batch");
                    dsResults.Tables[0].Columns.Add("Item");
                    dsResults.Tables[0].Rows.Add(dsResults.Tables[0].NewRow());

                    dsResults.Tables[0].Rows[0]["GroupCode"] = sGroupCode;
                    dsResults.Tables[0].Rows[0]["Batch"] = sBatchID;
                    dsResults.Tables[0].Rows[0]["Item"] = sItemCode;

                    dsResults = Service.ProxyGenericGet(dsResults); //procedure spGetCIDInfo: 

				}

              try
                {  

                if (SarinLRID.Trim() == "2000" && dsResults.Tables[0].Rows.Count > 0)
                { 
                    PrintCID_Labels(row, sPrinterName, sReportFolder + sReportName, ref dsResults, out PrintRegular);
                }
               if (PrintRegular) 
                {
                    //string sSKU = row["CustomerProgramName"].ToString().Trim();
                    #region Open Excel
          
                        //----------------New Part by Sasha from 04/11/07
                        Excel.Worksheet SheetData = (Excel.Worksheet)BookTemp.Sheets[3];
						//@ConvertTo128(sOldNumber)
						SheetData.Shapes.Item("BarCode").TextFrame.Characters(Type.Missing, Type.Missing).Text = "*" + sGroupCode + sBatchID + sItemCode + "*"; //barcode	  39
						//SheetData.Shapes.Item("BarCode128").TextFrame.Characters(Type.Missing, Type.Missing).Text = @ConvertTo128(sGroupCode + sBatchID + sItemCode);  //barcode	128
						SheetData.Shapes.Item("ItemNumber").TextFrame.Characters(Type.Missing, Type.Missing).Text = sGroupCode + "." + sBatchID + "." + sItemCode + sOldNumber; //Item Number
                        //string sWeight = "Wt. " + (row["Weight"].ToString().Trim() != "" ? row["Weight"].ToString().Trim() : "");
                        //SheetData.Shapes.Item("Weight").TextFrame.Characters(Type.Missing, Type.Missing).Text = (row["Weight"].ToString().Trim() != "" ? ("Wt. " + row["Weight"].ToString().Trim()) : ""); //weight
                        //string sSKU = "SKU: " + (row["CustomerProgramName"].ToString().Trim() != "" ? row["CustomerProgramName"].ToString().Trim() : "");
                        SheetData.Shapes.Item("SKU").TextFrame.Characters(Type.Missing, Type.Missing).Text = (sSKU != "" ? ("SKU: " + sSKU) : ""); //sku
                        //string sMemo = "M: " + (row["MemoNumber"].ToString().Trim() != "" ? row["MemoNumber"].ToString().Trim() : "");
                        SheetData.Shapes.Item("Memo").TextFrame.Characters(Type.Missing, Type.Missing).Text = (row["MemoNumber"].ToString().Trim() != "" ? ("M: " + row["MemoNumber"].ToString().Trim()) : ""
                            + row["Weight"].ToString().Trim() != "" ? (" Wt: " + row["Weight"].ToString().Trim()) : ""); //memo                  
                        SheetData.Shapes.Item("Prefix").TextFrame.Characters(Type.Missing, Type.Missing).Text = "";
                        SheetData.Shapes.Item("BarCodePr").TextFrame.Characters(Type.Missing, Type.Missing).Text = "";

                        if (sSKU.StartsWith("844"))
                        {
                            sPrefix = row["Prefix"].ToString().Trim();
                            SheetData.Shapes.Item("Prefix").TextFrame.Characters(Type.Missing, Type.Missing).Text = (sPrefix != "" ? ("Prx: " + sPrefix) : "");
                            SheetData.Shapes.Item("BarCodePr").TextFrame.Characters(Type.Missing, Type.Missing).Text = "*" + sPrefix + "*"; //barcode	for prefix					                 
                        }
                        //SarinLRID = row["SarinLRID"].ToString().Trim();
                        //SarinID = row["SarinID"].ToString().Trim();
                        //if (SarinLRID.Trim() != "0" && SarinID.Trim() != "")
                        //{
                        //    SheetData.Shapes.Item("Prefix").TextFrame.Characters(Type.Missing, Type.Missing).Text = ("Srn: " + SarinID);
                        //    SheetData.Shapes.Item("BarCodePr").TextFrame.Characters(Type.Missing, Type.Missing).Text = "*" + SarinID + "*"; //barcode	for prefix		
                        //}
                        //else
                        //{
                        //    SheetData.Shapes.Item("Prefix").TextFrame.Characters(Type.Missing, Type.Missing).Text = "";
                        //    SheetData.Shapes.Item("BarCodePr").TextFrame.Characters(Type.Missing, Type.Missing).Text = ""; //barcode	for prefix			
                        //}

                        //Excel.Worksheet SheetLabel = (Excel.Worksheet)BookTemp.Sheets[3];
                        //SheetLabel.PrintOut(1, 1, 1, false, sPrinterName, Type.Missing, true, Type.Missing);
                        //string myFile = "";
#if DEBUG
                        string sTempXLSLabel = @"\Reports_etc\New Folder\";
                        if (!Directory.Exists(Service.sTempDir + sTempXLSLabel)) Directory.CreateDirectory(Service.sTempDir + sTempXLSLabel);
                        string myFile = Service.sTempDir + sTempXLSLabel + sGroupCode + "." + sBatchID + "." + sItemCode + ".xls";
                        if (File.Exists(myFile)) File.Delete(myFile);
                        SheetData.SaveAs(myFile, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
#else  
					SheetData.PrintOut(1, 1, 1, false, sPrinterName, Type.Missing, true, Type.Missing);
#endif
                    } 
                    }
                    catch (Exception ex)
                    {
                        string msg = ex.Message;
                        if (msg == "file not found")
                        {
                            throw new Exception("The system cannot find the file: " + sReportFolder + sReportName);
                        }
                    }
                    finally
                    {

                    }
               
                #endregion
                }

            if (Convert.ToInt16(sNumber[1]) == 0)
            {
                Excel.Worksheet SheetData = (Excel.Worksheet)BookTemp.Sheets[5];
//#if DEBUG
//                return;
//#else
				SheetData.PrintOut(1, 1, 1, false, sPrinterName, Type.Missing, true, Type.Missing);
//#endif
            }
        }
        public void Excel_Label_ItemNew(int totalItems, string sItemID, string sCustomerProgram, string sMemoName)
        {
            var PrintRegular = true;
            string sPrinterName = "";
            string[] sNumber = sItemID.Split('_');
            string sReportName = "Label_Item.xls";
            string sReportFolder = Client.GetOfficeDirPath("repDir");
            string sReportPath = sReportFolder + sReportName;
            int k = sReportName.ToUpper().IndexOf(".XLS");
            sPrinterName = GetPrinterName(sReportName.Substring(0, k));
			//MessageBox.Show("Line 4256, CrystalReport, Item label printer: " + sPrinterName);
			//DataSet dsRecvSet = Service.GetCrystalSet(sItemID, "Item_New_1");//Procedure dbo.spGetItem_new_1
			string sSKU = sCustomerProgram;
            string sOldNumber = sItemID;
            string[] orderBatchNumber = sItemID.Split('.');
            string sGroupCode = orderBatchNumber[0];
            string sBatchCode = orderBatchNumber[1];
            string sItemCode = orderBatchNumber[2];
            int itemCode = Convert.ToInt16(sItemCode);
            //if (dsRecvSet.Tables[0].Rows.Count > 0) sSKU = dsRecvSet.Tables[0].Rows[0]["CustomerProgramName"].ToString().Trim();
            //else return;

            sReportName = "Label_Item_Pr.xls"; // - barcode 39
            var sReportName128 = "Label_Item_128.xls"; // barcode 128
			//MessageBox.Show("Line 4270, CrystalReport, Item label path: " + sReportFolder + sReportName);

			Open_Excel(sReportFolder + sReportName);
            /*
            foreach (DataRow row in dsRecvSet.Tables[0].Rows)
            {
                //row = dsRecvSet.Tables[0].Rows;
                string sPrefix = "";
                string SarinLRID = "";
                string SarinID = "";

                SarinLRID = row["SarinLRID"].ToString().Trim();
                SarinID = row["SarinID"].ToString().Trim();
                //if (SarinLRID.Trim() == "2000")
                //{
                //    //sReportPath = sReportFolder + "Label_CID.xls";
                //    PrintCID_Labels(row, sPrinterName, sReportPath);
                //}
                //else
                //{
                string sGroupCode = FillToFiveChars(row["GroupCode"].ToString());
                string sBatchID = FillToThreeChars(row["BatchCode"].ToString());
                string sItemCode = FillToTwoChars(row["ItemCode"].ToString());

                string sOldGroupCode = FillToFiveChars(row["PrevGroupCode"].ToString());
                string sOldBatchCode = FillToThreeChars(row["PrevBatchCode"].ToString());
                string sOldItemCode = FillToTwoChars(row["PrevItemCode"].ToString());

                string sOldNumber = "";
                if (sOldGroupCode != "00000" && sOldBatchCode != "000" && sOldItemCode != "00" &&
                    (sOldGroupCode + sOldBatchCode + sOldItemCode) != (sGroupCode + sBatchID + sItemCode))
                {
                    sOldNumber = " (" + sOldGroupCode + "." + sOldBatchCode + "." + sOldItemCode + ")";
                }
                */
                DataSet dsResults = new DataSet();
                /* alex
                if (SarinLRID.Trim() == "2000")
                {

                    dsResults.Tables.Add("CIDInfo");
                    dsResults.Tables[0].Columns.Add("GroupCode");
                    dsResults.Tables[0].Columns.Add("Batch");
                    dsResults.Tables[0].Columns.Add("Item");
                    dsResults.Tables[0].Rows.Add(dsResults.Tables[0].NewRow());

                    dsResults.Tables[0].Rows[0]["GroupCode"] = sGroupCode;
                    dsResults.Tables[0].Rows[0]["Batch"] = sBatchID;
                    dsResults.Tables[0].Rows[0]["Item"] = sItemCode;

                    dsResults = Service.ProxyGenericGet(dsResults); //procedure spGetCIDInfo: 

                }
                alex */
                try
                {
                    /* alex
                    if (SarinLRID.Trim() == "2000" && dsResults.Tables[0].Rows.Count > 0)
                    {
                        PrintCID_Labels(row, sPrinterName, sReportFolder + sReportName, ref dsResults, out PrintRegular);
                    }
                    alex */
                    if (PrintRegular)
                    {
                        //string sSKU = row["CustomerProgramName"].ToString().Trim();
                        #region Open Excel

                        //----------------New Part by Sasha from 04/11/07
                        Excel.Worksheet SheetData = (Excel.Worksheet)BookTemp.Sheets[3];
                        //@ConvertTo128(sOldNumber)
                        SheetData.Shapes.Item("BarCode").TextFrame.Characters(Type.Missing, Type.Missing).Text = "*" + sGroupCode + sBatchCode + sItemCode + "*"; //barcode	  39
                                                                                                                                                                  //SheetData.Shapes.Item("BarCode128").TextFrame.Characters(Type.Missing, Type.Missing).Text = @ConvertTo128(sGroupCode + sBatchID + sItemCode);  //barcode	128
                    SheetData.Shapes.Item("ItemNumber").TextFrame.Characters(Type.Missing, Type.Missing).Text = sGroupCode + "." + sBatchCode + "." + sItemCode;// + sOldNumber; //Item Number
                        //string sWeight = "Wt. " + (row["Weight"].ToString().Trim() != "" ? row["Weight"].ToString().Trim() : "");
                        //SheetData.Shapes.Item("Weight").TextFrame.Characters(Type.Missing, Type.Missing).Text = (row["Weight"].ToString().Trim() != "" ? ("Wt. " + row["Weight"].ToString().Trim()) : ""); //weight
                        //string sSKU = "SKU: " + (row["CustomerProgramName"].ToString().Trim() != "" ? row["CustomerProgramName"].ToString().Trim() : "");
                        SheetData.Shapes.Item("SKU").TextFrame.Characters(Type.Missing, Type.Missing).Text = (sSKU != "" ? ("SKU: " + sSKU) : ""); //sku
                        //string sMemo = "M: " + (row["MemoNumber"].ToString().Trim() != "" ? row["MemoNumber"].ToString().Trim() : "");
                        SheetData.Shapes.Item("Memo").TextFrame.Characters(Type.Missing, Type.Missing).Text = (sMemoName != "" ? ("M: " + sMemoName) : ""); //memo                  
                        SheetData.Shapes.Item("Prefix").TextFrame.Characters(Type.Missing, Type.Missing).Text = "";
                        SheetData.Shapes.Item("BarCodePr").TextFrame.Characters(Type.Missing, Type.Missing).Text = "";
                    /* alex
                    if (sSKU.StartsWith("844"))
                    {
                        sPrefix = row["Prefix"].ToString().Trim();
                        SheetData.Shapes.Item("Prefix").TextFrame.Characters(Type.Missing, Type.Missing).Text = (sPrefix != "" ? ("Prx: " + sPrefix) : "");
                        SheetData.Shapes.Item("BarCodePr").TextFrame.Characters(Type.Missing, Type.Missing).Text = "*" + sPrefix + "*"; //barcode	for prefix					                 
                    }
                    alex */
                    //SarinLRID = row["SarinLRID"].ToString().Trim();
                    //SarinID = row["SarinID"].ToString().Trim();
                    //if (SarinLRID.Trim() != "0" && SarinID.Trim() != "")
                    //{
                    //    SheetData.Shapes.Item("Prefix").TextFrame.Characters(Type.Missing, Type.Missing).Text = ("Srn: " + SarinID);
                    //    SheetData.Shapes.Item("BarCodePr").TextFrame.Characters(Type.Missing, Type.Missing).Text = "*" + SarinID + "*"; //barcode	for prefix		
                    //}
                    //else
                    //{
                    //    SheetData.Shapes.Item("Prefix").TextFrame.Characters(Type.Missing, Type.Missing).Text = "";
                    //    SheetData.Shapes.Item("BarCodePr").TextFrame.Characters(Type.Missing, Type.Missing).Text = ""; //barcode	for prefix			
                    //}

                    //Excel.Worksheet SheetLabel = (Excel.Worksheet)BookTemp.Sheets[3];
                    //SheetLabel.PrintOut(1, 1, 1, false, sPrinterName, Type.Missing, true, Type.Missing);
                    //string myFile = "";
                    /* alex
#if DEBUG
                    string sTempXLSLabel = @"\Reports_etc\New Folder\";
                    if (!Directory.Exists(Service.sTempDir + sTempXLSLabel)) Directory.CreateDirectory(Service.sTempDir + sTempXLSLabel);
                    string myFile = Service.sTempDir + sTempXLSLabel + sGroupCode + "." + sBatchCode + "." + sItemCode + ".xls";
                    if (File.Exists(myFile)) File.Delete(myFile);
                    SheetData.SaveAs(myFile, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
#else  
                SheetData.PrintOut(1, 1, 1, false, sPrinterName, Type.Missing, true, Type.Missing);
#endif
alex */
                    SheetData.PrintOut(1, 1, 1, false, sPrinterName, Type.Missing, true, Type.Missing);
                }
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                    if (msg == "file not found")
                    {
                        throw new Exception("The system cannot find the file: " + sReportFolder + sReportName);
                    }
                }
                finally
                {

                }

            #endregion
            // }
            
             if (itemCode == totalItems)
             {
                 Excel.Worksheet SheetData = (Excel.Worksheet)BookTemp.Sheets[5];
                 //#if DEBUG
                 //                return;
                 //#else
                 SheetData.PrintOut(1, 1, 1, false, sPrinterName, Type.Missing, true, Type.Missing);
                 //#endif

             }
              
        }
        private void PrintCID_Labels(DataRow row, string sPrinterName, string sReportPath, ref DataSet dsResults, out bool PrintRegularLabel)
		{
			PrintRegularLabel = false;
			var sPrefix = "";
			var sProject = "";
			string sGroupCode = FillToFiveChars(row["GroupCode"].ToString());
			string sBatchCode = FillToThreeChars(row["BatchCode"].ToString());
			string sItemCode = FillToTwoChars(row["ItemCode"].ToString());

			string sOldGroupCode = FillToFiveChars(row["PrevGroupCode"].ToString());
			string sOldBatchCode = FillToThreeChars(row["PrevBatchCode"].ToString());
			string sOldItemCode = FillToTwoChars(row["PrevItemCode"].ToString());

			string sOldNumber = "";
			if (sOldGroupCode != "00000" && sOldBatchCode != "000" && sOldItemCode != "00" &&
				(sOldGroupCode + sOldBatchCode + sOldItemCode) != (sGroupCode + sBatchCode + sItemCode))
			{
				sOldNumber = " (" + sOldGroupCode + "." + sOldBatchCode + "." + sOldItemCode + ")";
			}
			
            //DataSet dsResults = new DataSet();
            //dsResults.Tables.Add("CIDInfo");
            //dsResults.Tables[0].Columns.Add("GroupCode");
            //dsResults.Tables[0].Columns.Add("Batch");
            //dsResults.Tables[0].Columns.Add("Item");
            //dsResults.Tables[0].Rows.Add(dsResults.Tables[0].NewRow());

            //dsResults.Tables[0].Rows[0]["GroupCode"] = sGroupCode;
            //dsResults.Tables[0].Rows[0]["Batch"] = sBatchCode;
            //dsResults.Tables[0].Rows[0]["Item"] = sItemCode;

            //dsResults = Service.ProxyGenericGet(dsResults);
			try
			{
				foreach (DataRow dr in dsResults.Tables[0].Rows)
				{
					sPrefix = dr["Prefix"].ToString();
					sProject = dr["Project"].ToString().Trim();
					if (sProject == "") PrintRegularLabel = true;
					else PrintRegularLabel = false;
					Excel.Worksheet SheetData = (Excel.Worksheet)BookTemp.Sheets[3];
					SheetData.Shapes.Item("BarCode").TextFrame.Characters(Type.Missing, Type.Missing).Text = "*" + sPrefix + "*"; //barcode  39
					//SheetData.Shapes.Item("BarCode128").TextFrame.Characters(Type.Missing, Type.Missing).Text ="";
					SheetData.Shapes.Item("ItemNumber").TextFrame.Characters(Type.Missing, Type.Missing).Text = (sProject + " " + sPrefix).Trim();//Prefix - instead of item number
					SheetData.Shapes.Item("SKU").TextFrame.Characters(Type.Missing, Type.Missing).Text = ""; //sku
					SheetData.Shapes.Item("Memo").TextFrame.Characters(Type.Missing, Type.Missing).Text = "";
					//item number instead of prefix
					SheetData.Shapes.Item("Prefix").TextFrame.Characters(Type.Missing, Type.Missing).Text = sGroupCode + "." + sBatchCode + "." + sItemCode + sOldNumber;
					SheetData.Shapes.Item("BarCodePr").TextFrame.Characters(Type.Missing, Type.Missing).Text = "";
#if DEBUG
					string sTempXLSLabel = @"\Reports_etc\New Folder\";
					if (!Directory.Exists(Service.sTempDir + sTempXLSLabel)) Directory.CreateDirectory(Service.sTempDir + sTempXLSLabel);
					string myFile = Service.sTempDir + sTempXLSLabel + "CID_" + sPrefix + ".xls";
					if (File.Exists(myFile)) File.Delete(myFile);
					SheetData.SaveAs(myFile, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
#else
					SheetData.PrintOut(1, 1, 1, false, sPrinterName, Type.Missing, true, Type.Missing);
#endif
				}
//					if (PrintRegularLabel)
//					{
//						Excel.Worksheet SheetData = (Excel.Worksheet)BookTemp.Sheets[3];
//						SheetData.Shapes.Item("BarCode").TextFrame.Characters(Type.Missing, Type.Missing).Text = "*" + sGroupCode + sBatchCode + sItemCode + "*"; //barcode  39
//						 //SheetData.Shapes.Item("BarCode").TextFrame.Characters(Type.Missing, Type.Missing).Text = @ConvertTo128(sPrefix);
//						SheetData.Shapes.Item("ItemNumber").TextFrame.Characters(Type.Missing, Type.Missing).Text = (sGroupCode + "." + sBatchCode + "." + sItemCode).Trim();//Prefix - instead of item number
//						SheetData.Shapes.Item("SKU").TextFrame.Characters(Type.Missing, Type.Missing).Text = ""; //sku
//						SheetData.Shapes.Item("Memo").TextFrame.Characters(Type.Missing, Type.Missing).Text = "";
//						//item number instead of prefix
//						SheetData.Shapes.Item("Prefix").TextFrame.Characters(Type.Missing, Type.Missing).Text = sGroupCode + "." + sBatchCode + "." + sItemCode + sOldNumber;
//						SheetData.Shapes.Item("BarCodePr").TextFrame.Characters(Type.Missing, Type.Missing).Text = "";
//#if DEBUG
//					var sTempXLSLabel = @"\Reports_etc\New Folder\";
//					if (!Directory.Exists(Service.sTempDir + sTempXLSLabel)) Directory.CreateDirectory(Service.sTempDir + sTempXLSLabel);
//					var myFile = Service.sTempDir + sTempXLSLabel + sGroupCode + "." + sBatchCode + "." + sItemCode + ".xls";
//					if (File.Exists(myFile)) File.Delete(myFile);
//					SheetData.SaveAs(myFile, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
//#else
//						SheetData.PrintOut(1, 1, 1, false, sPrinterName, Type.Missing, true, Type.Missing);
//#endif
//						PrintRegularLabel = false; 
					//}
				

			}
			catch (Exception ex)
			{
				string msg = ex.Message;
				if (msg == "file not found")
				{
					throw new Exception("The system cannot find the file: " + sReportPath);
				}
			}
                finally
                {
  
                }
		}


		public void Excel_Tag_Item(string sItemID, string sCustomerProgram)
        {
            string sPrinterName = "";
            string[] sNumber = sItemID.Split('_');
            string sReportPath = Client.GetOfficeDirPath("repDir") + @"label_item.xls"; // New part 03/07/08
            sPrinterName = GetPrinterName("SpecialLabel_Item");

            DataSet dsRecvSet = Service.GetCrystalSet(sItemID, "Item");

            Open_Excel(sReportPath);
            foreach (DataRow row in dsRecvSet.Tables[0].Rows)
            {

                string sGroupCode = FillToFiveChars(row["GroupCode"].ToString());
                string sBatchID = FillToThreeChars(row["BatchCode"].ToString());
                string sItemCode = FillToTwoChars(row["ItemCode"].ToString());

                string sOldGroupCode = FillToFiveChars(row["PrevGroupCode"].ToString());
                string sOldBatchCode = FillToThreeChars(row["PrevBatchCode"].ToString());
                string sOldItemCode = FillToTwoChars(row["PrevItemCode"].ToString());

                string sOldNumber = "";
                if (sOldGroupCode != "00000" && sOldBatchCode != "000" && sOldItemCode != "00" &&
                    (sOldGroupCode + sOldBatchCode + sOldItemCode) != (sGroupCode + sBatchID + sItemCode))
                {
                    sOldNumber = " (" + sOldGroupCode + "." + sOldBatchCode + "." + sOldItemCode + ")";
                }

                #region Open Excel
                try
                {

                    Excel.Worksheet SheetData = (Excel.Worksheet)BookTemp.Sheets[6];
                    //SheetData.Shapes.Item("BarCode").TextFrame.Characters(Type.Missing, Type.Missing).Text = "*" + sGroupCode+sBatchID + sItemCode + "*"; //barcode
                    SheetData.Shapes.Item("ItemNumber1").TextFrame.Characters(Type.Missing, Type.Missing).Text = sGroupCode + "." + sBatchID + "." + sItemCode + sOldNumber; //Item Number
                    SheetData.Shapes.Item("ItemNumber2").TextFrame.Characters(Type.Missing, Type.Missing).Text = sGroupCode + "." + sBatchID + "." + sItemCode + sOldNumber; //Item Number

                    //SheetData.Shapes.Item("Weight").TextFrame.Characters(Type.Missing, Type.Missing).Text = "Wt. " + row["Weight"].ToString(); //weight
                    //SheetData.Shapes.Item("SKU").TextFrame.Characters(Type.Missing, Type.Missing).Text = "SKU: " + row["CustomerProgramName"].ToString(); //sku
                    //Excel.Worksheet SheetLabel = (Excel.Worksheet)BookTemp.Sheets[3];
                    //SheetLabel.PrintOut(1, 1, 1, false, sPrinterName, Type.Missing, true, Type.Missing);
                    SheetData.PrintOut(1, 1, 1, false, sPrinterName, Type.Missing, true, Type.Missing);

                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                    if (msg == "file not found")
                    {
                        throw new Exception("The system cannot find the file: " + sReportPath);
                    }
                }
                finally
                {

                }
                #endregion
            }
            if (Convert.ToInt16(sNumber[1]) == 0)
            {
                return;
                //Excel.Worksheet SheetData = (Excel.Worksheet)BookTemp.Sheets[5];
                //SheetData.PrintOut(1, 1, 1, false, sPrinterName, Type.Missing, true, Type.Missing);
            }
        }


        public void Excel_Account_Representative_Label(string sGroupCode,
                                                        string sBatchCode,
                                                        string sBatchID,
                                                        string sNewBatchID,
                                                        string sItemCode,
                                                        string sNewItemCode,
                                                        bool isTotalWeight)
        {

            //string sReportPath=@"c:\work\sergei\work\crystal\reports\account_rep_label.rpt";
            string sReportPath = Client.GetOfficeDirPath("repDir") + @"account_rep_label.xls"; // New part 03/07/08

            string sTemp = "";
            sTemp = Environment.GetEnvironmentVariable("TEMP");
            if (sTemp == "") sTemp = "c:";

            string fnTemp = sTemp + "\\account_rep_label" + sGroupCode + "_" + sBatchCode + "_" + sItemCode + ".xls";
            //string sReportsDir = Service.GetCRTemplatePath();
            //string sReportPath=sReportsDir+@"account_rep_label.xls";

            sPrinterName = GetPrinterName("Account_Rep_Label");
            #region
            DataSet dsItemSet = new DataSet();
            dsItemSet = Service.GetCrystalSet(sBatchID + "_" + sItemCode, "Item"); //Procedure dbo.spGetItem

            DataSet dsIn = new DataSet();
            dsIn.Tables.Add("PartValueTypeEx");
            DataSet dsOut = Service.GenericGetCrystalSet(dsIn);//Procedure dbo.spGetPartValueTypeEx
            dsOut.Tables[0].Rows.Add(dsOut.Tables[0].NewRow());
            dsOut.Tables[0].Rows[0]["BatchID"] = sNewBatchID;
            //dsOut.Tables[0].Rows[0]["BatchID"]=13;
            dsOut.Tables[0].Rows[0]["RecheckNumber"] = -1;
            dsOut.Tables[0].Rows[0]["ViewAccessCode"] = DBNull.Value;
            dsOut.Tables[0].Rows[0]["ItemCode"] = sNewItemCode;
            dsOut.Tables[0].TableName = "PartValue";


            DataSet dsPartValue = Service.GenericGetCrystalSet(dsOut);//Procedure dbo.spGetPartValue

            int iRowColor = 0;
            int iRowClarity = 0;
            int iRowColoredDiamond = 0;
            bool isRowColor = false;
            bool isRowClarity = false;
            bool isRowColoredDiamond = false;
            string sWeight = "";
            string sDiamondWeight = "";
            string sPrintWeight = "";
            bool isWeight = false;

            #region CheckForWeight
            DataTable dtParts = Service.GetParts(dsItemSet.Tables[0].Rows[0]["ItemTypeId"].ToString());//Procedure dbo.spGetPartsByItemType

            DataSet dsIn1 = new DataSet();
            dsIn1.Tables.Add("PartTypes");
            DataSet dsPartTypes = Service.ProxyGenericGet(dsIn1);//Procedure dbo.spGetPartTypes
            bool isColorDiamod = false;
            try
            {
                DataRow[] drPartTypeDiamondId = dsPartTypes.Tables[0].Select("PartTypeCode=1"); //Get 'Diamond' PartTypeId
                DataRow[] drPartTypeItemContainerId = dsPartTypes.Tables[0].Select("PartTypeCode=15"); //Get 'ItemContainer' PartTypeId
                DataRow[] drPartTypeColorDiamondId = dsPartTypes.Tables[0].Select("PartTypeCode=2"); //Get 'ColorDiamod' PartTypeId by Vetal_242 25.01.2006

                DataRow[] drItemContainersPartsIds = dtParts.Select("PartTypeID=" + drPartTypeItemContainerId[0]["PartTypeID"].ToString());
                DataRow[] drDiamondsPartsIds = dtParts.Select("PartTypeID=" + drPartTypeDiamondId[0]["PartTypeID"].ToString());

                //ColorDiamond?
                //by Vetal_242 25.01.2006
                DataRow[] drColorDiamondsPartsIds = dtParts.Select("PartTypeID=" + drPartTypeColorDiamondId[0]["PartTypeID"].ToString());
                if (drColorDiamondsPartsIds.Length > 0)
                    isColorDiamod = true;

                for (int i = 0; i < drItemContainersPartsIds.Length; i++)
                {
                    DataRow[] drPartValues = dsPartValue.Tables[0].Select("PartID=" + drItemContainersPartsIds[i]["ID"].ToString() + " and MeasureCode=2");
                    if (drPartValues.Length > 0)
                    {
                        isWeight = true;
                        switch (drPartValues[0]["MeasureClass"].ToString())
                        {
                            case "1": sWeight = drPartValues[0]["MeasureValueName"].ToString(); break;
                            case "2": sWeight = drPartValues[0]["StringValue"].ToString(); break;
                            case "3": sWeight = drPartValues[0]["MeasureValue"].ToString(); break;
                            case "4": sWeight = drPartValues[0]["StringValue"].ToString(); break;
                        }
                        break;
                    }
                }

                //			if(!isWeight)
                {
                    for (int i = 0; i < drDiamondsPartsIds.Length; i++)
                    {
                        DataRow[] drPartValues = dsPartValue.Tables[0].Select("PartID=" + drDiamondsPartsIds[i]["ID"].ToString() + " and (MeasureCode=2 or MeasureCode=4)");
                        if (drPartValues.Length > 0)
                        {
                            isWeight = true;
                            switch (drPartValues[0]["MeasureClass"].ToString())
                            {
                                case "1": sDiamondWeight = drPartValues[0]["MeasureValueName"].ToString(); break;
                                case "2": sDiamondWeight = drPartValues[0]["StringValue"].ToString(); break;
                                case "3": sDiamondWeight = drPartValues[0]["MeasureValue"].ToString(); break;
                                case "4": sDiamondWeight = drPartValues[0]["StringValue"].ToString(); break;
                            }
                            break;
                        }
                    }
                }


            }
            catch (Exception exc)
            {
                System.Diagnostics.Trace.WriteLine(exc.Message.ToString());
            }

            if (!isWeight)
            {
                throw new Exception("Weight is empty for item {" + sGroupCode + "." + sGroupCode + "." + sBatchCode + "." + sItemCode + "}. Label will not be printed.");
            }

            #endregion

            for (int i = 0; i < dsPartValue.Tables[0].Rows.Count; i++)
            {
                if (isRowColor & isRowClarity & isRowColoredDiamond) break;

                if (dsPartValue.Tables[0].Rows[i]["MeasureCode"].ToString() == "27")
                {
                    iRowColor = i;
                    isRowColor = true;
                }
                if (dsPartValue.Tables[0].Rows[i]["MeasureCode"].ToString() == "29")
                {
                    iRowClarity = i;
                    isRowClarity = true;
                }
                //Color Diamod Color
                //by Vetal_242 25.01.2006
                if (dsPartValue.Tables[0].Rows[i]["MeasureCode"].ToString() == "32")
                {
                    iRowColoredDiamond = i;
                    isRowColoredDiamond = true;
                }

            }

            string sColor = "";
            string sClarity = "";
            if (dsPartValue.Tables[0].Rows.Count > 0)
            {
                if (!isColorDiamod)//not ColorDiamond
                    sColor = dsPartValue.Tables[0].Rows[iRowColor]["MeasureValueName"].ToString();
                else
                    if (isRowColoredDiamond)//nonselected diamond color
                        sColor = dsPartValue.Tables[0].Rows[iRowColoredDiamond]["MeasureValueName"].ToString();
                sClarity = dsPartValue.Tables[0].Rows[iRowClarity]["MeasureValueName"].ToString();
            }

            DataSet dsTempSet = new DataSet();
            DataTable table = new DataTable("parsel_label");

            table.Columns.Add("barcode", System.Type.GetType("System.String"));
            table.Columns.Add("barcodenum", System.Type.GetType("System.String"));
            table.Columns.Add("carat weight", System.Type.GetType("System.String"));
            table.Columns.Add("color", System.Type.GetType("System.String"));
            table.Columns.Add("clarity", System.Type.GetType("System.String"));
            table.Columns.Add("isPrinted", System.Type.GetType("System.String"));

            DataRow tRow = table.NewRow();

            sGroupCode = FillToFiveChars(sGroupCode);
            sBatchCode = FillToThreeChars(sBatchCode);
            sItemCode = FillToTwoChars(sItemCode);

            string sOldGroupCode = FillToFiveChars(dsItemSet.Tables[0].Rows[0]["PrevGroupCode"].ToString());
            string sOldBatchCode = FillToThreeChars(dsItemSet.Tables[0].Rows[0]["PrevBatchCode"].ToString());
            string sOldItemCode = FillToTwoChars(dsItemSet.Tables[0].Rows[0]["PrevItemCode"].ToString());

            if (sOldGroupCode != "00000" && sOldBatchCode != "000" && sOldItemCode != "00" &&
                (sOldGroupCode + sOldBatchCode + sOldItemCode) != (sGroupCode + sBatchCode + sItemCode))
            {
                tRow[0] = "*" + sOldGroupCode + sOldBatchCode + sOldItemCode + "*";
                tRow[1] = sOldGroupCode + "." + sOldBatchCode + "." + sOldItemCode + "(" + sGroupCode + "." + sBatchCode + "." + sItemCode + ")";
            }
            else
            {
                tRow[0] = "*" + sGroupCode + sBatchCode + sItemCode + "*";
                tRow[1] = sGroupCode + "." + sBatchCode + "." + sItemCode;
            }

            if (isTotalWeight) //TotalWeight
            {
                try
                {
                    sPrintWeight = Convert.ToDouble(dsItemSet.Tables[0].Rows[0]["Weight"].ToString()).ToString("0.00");
                    sPrintWeight = sPrintWeight + " ct. (twt)";
                }
                catch
                {
                    throw new Exception(" " + sGroupCode + "." + sBatchCode + "." + sItemCode + " (Total Weight)");
                    //sPrintWeight="";
                }
            }
            if (!isTotalWeight) //Center Stone Weight
            {
                try
                {
                    sPrintWeight = Convert.ToDouble(sDiamondWeight).ToString("0.00") + " ct.";
                }
                catch
                {
                    throw new Exception(" " + sGroupCode + "." + sBatchCode + "." + sItemCode + " (Center/Loose Stone Weight)");

                }
                //{sPrintWeight="";}	
            }

            if (sPrintWeight.Length > 0)
                tRow[2] = sPrintWeight;
            else
                tRow[2] = " ";


            tRow[3] = sColor;//"color";
            tRow[4] = sClarity;//"clarity";

            table.Rows.Add(tRow);
            //dsTempSet.Tables.Add(table);
            /*
            dsCrystalSet=dsTempSet;
            dsCrystalSet.Tables[0].TableName=crDocument.Database.Tables[0].Name;
            */
            string sShapeCode = dsItemSet.Tables[0].Rows[0]["Shape"].ToString();
            DataSet dsShape = new DataSet();

            try
            {
                dsShape = Service.GetShapeByCode(Convert.ToInt32(sShapeCode));
            }
            catch
            { }

            /*
            CrystalDecisions.CrystalReports.Engine.TextObject crText;
            crText=crDocument.ReportDefinition.ReportObjects["text1"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            */
            string sText1 = " ";
            if (dsShape.Tables.Count > 0)
                sText1 = dsShape.Tables[0].Rows[0]["ShortReportName"].ToString();
            /*	crText.Text=dsShape.Tables[0].Rows[0]["ShortReportName"].ToString();
            else 
                crText.Text="";*/


            dsIn = new DataSet();
            dsIn.Tables.Add("ItemDocByCodeTypeEx");
            dsOut = Service.GenericGetCrystalSet(dsIn);

            dsOut.Tables[0].Rows.Add(dsOut.Tables[0].NewRow());
            dsOut.Tables[0].Rows[0]["GroupCode"] = sGroupCode;
            dsOut.Tables[0].Rows[0]["BatchCode"] = sBatchCode;
            dsOut.Tables[0].Rows[0]["ItemCode"] = sItemCode;
            dsOut.Tables[0].TableName = "ItemDocByCode";
            DataSet dsOut2 = Service.GenericGetCrystalSet(dsOut);

            string sIsPrinted = " ";
            if (dsOut2.Tables[0].Rows.Count == 0)
                sIsPrinted = "Z";

            table.Rows[0][5] = sIsPrinted;

            #endregion
            /*
				dsCrystalSet.Tables[0].Rows[0][5] = "";
			else
				dsCrystalSet.Tables[0].Rows[0][5] = "Z";*/

            //crDocument.SetDataSource(dsCrystalSet);

            #region Open Excel
            //Excel.Application objExcel = null ;
            Excel.Workbook BookData = null;
            Excel.Workbook BookTemp = null;
            try
            {
                if (objExcel == null)
                    objExcel = new Excel.Application();
                try
                {
                    BookData = objExcel.Workbooks.Open(sReportPath, Type.Missing, true, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                }
                catch (Exception ex)
                {
                    throw new Exception("file not found");
                }

                BookData.SaveCopyAs(fnTemp);
                BookData.Close(false, sReportPath, null);
                //make local copy

                BookTemp = objExcel.Workbooks.Open(fnTemp, Type.Missing, false, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                Excel.Worksheet SheetData = (Excel.Worksheet)BookTemp.Sheets[2];

                Excel.Range crCell = null;

                string newBatchNumber = "";
                string oldNumber = table.Rows[0]["barcodenum"].ToString();
                newBatchNumber = oldNumber.Substring(0, 9);
                if (table.Rows[0]["barcodenum"].ToString().IndexOf("(") > 0)
                {
                    oldNumber = table.Rows[0]["barcodenum"].ToString().Substring(0, table.Rows[0]["barcodenum"].ToString().IndexOf("("));
                    newBatchNumber = table.Rows[0]["barcodenum"].ToString().Substring(table.Rows[0]["barcodenum"].ToString().IndexOf("(") + 1, 9);
                }

                crCell = SheetData.get_Range("b2", Type.Missing);
                crCell.Cells.Value2 = table.Rows[0]["barcode"].ToString(); //barcode

                crCell = SheetData.get_Range("b3", Type.Missing);
                //crCell.Cells.Value2 = table.Rows[0]["barcodenum"].ToString(); //barcodenum -- old part
                crCell.Cells.Value2 = oldNumber; //new part 07/25/08

                crCell = SheetData.get_Range("b4", Type.Missing);
                crCell.Cells.Value2 = sText1; //Shape

                crCell = SheetData.get_Range("b5", Type.Missing);
                crCell.Cells.Value2 = table.Rows[0]["carat weight"].ToString(); //carat weight

                crCell = SheetData.get_Range("b6", Type.Missing);
                crCell.Cells.Value2 = table.Rows[0]["color"].ToString(); //color

                crCell = SheetData.get_Range("b7", Type.Missing);
                crCell.Cells.Value2 = table.Rows[0]["clarity"].ToString(); //clarity

                crCell = SheetData.get_Range("b8", Type.Missing);
                crCell.Cells.Value2 = table.Rows[0]["isPrinted"].ToString(); //isPrinted

                crCell = SheetData.get_Range("b9", Type.Missing);
                crCell.Cells.Value2 = newBatchNumber;//new batch #

                Excel.Worksheet SheetLabel = (Excel.Worksheet)BookTemp.Sheets[1];
                SheetLabel.PrintOut(Type.Missing, Type.Missing, 1, false, sPrinterName, Type.Missing, true, Type.Missing);

                NAR(crCell);
                NAR(SheetData);
                NAR(SheetLabel);
                crCell = null;
                SheetLabel = null;
                SheetData = null;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                if (msg == "file not found")
                {
                    throw new Exception("The system cannot find the file: " + sReportPath);
                }
            }
            finally
            {
                try
                {
                    BookTemp.Close(false, fnTemp, null);
                    //BookTemp.Close(true,fnTemp,null);//save for test
                }
                catch (Exception ex)
                { }
                try
                { BookData.Close(false, sReportPath, null); }
                catch (Exception ex)
                { }
                try
                {
                    //objExcel.Quit();

                    NAR(BookTemp);
                    NAR(BookData);
                    //NAR(objExcel);

                    BookTemp = null;
                    BookData = null;
                    //objExcel=null;

                    /*
                                        GC.Collect();
                                        GC.WaitForPendingFinalizers(); 
                                        GC.Collect();*/
                }
                catch (Exception ex)
                { }
                try
                {
                    if (File.Exists(fnTemp))
                        File.Delete(fnTemp);//delete temp file
                }
                catch { }
            }
            #endregion


        }

        //Print cert.label from AccRep form
        private string DecimalToBase(int iDec, int numbase)
        {
            int base10 = 10;
            char[] cHexa = new char[] { 'A', 'B', 'C', 'D', 'E', 'F' };
            int[] iHexaNumeric = new int[] { 10, 11, 12, 13, 14, 15 };
            int[] iHexaIndices = new int[] { 0, 1, 2, 3, 4, 5 };
            //const int asciiDiff = 48;
            string strBin = "";
            int[] result = new int[32];
            int MaxBit = 32;
            for (; iDec > 0; iDec /= numbase)
            {
                int rem = iDec % numbase;
                result[--MaxBit] = rem;
            }
            for (int i = 0; i < result.Length; i++)
                if ((int)result.GetValue(i) >= base10)
                    strBin += cHexa[(int)result.GetValue(i) % base10];
                else
                    strBin += result.GetValue(i);
            strBin = strBin.TrimStart(new char[] { '0' });
            return strBin;
        }

        public string ConvertTo128(string chaine)
        {
            int ind = 1;
            int checksum = 0;
            int mini;
            int dummy;
            bool tableB;
            string code128;
            int longueur;

            code128 = "";
            longueur = chaine.Length;

            if (longueur == 0)
            {
                code128 = "";
                return code128;
            }
            else
            {
                for (ind = 0; ind < longueur; ind++)
                {
                    if ((chaine[ind] < 32) || (chaine[ind] > 126))
                    {
                        code128 = "";
                        return code128;
                    }
                }
            }

            tableB = true;
            ind = 0;

            while (ind < longueur)
            {
                if (tableB == true)
                {
                    if ((ind == 0) || (ind + 3 == longueur - 1))
                        mini = 4;
                    else
                        mini = 6;

                    mini = mini - 1;

                    if ((ind + mini) <= longueur - 1)
                    {
                        while (mini >= 0)
                        {
							/* code is commented to allow mixed numbers to convert
							 * commented code blocks mixed numbers
							if ((chaine[ind + mini] < 48) || (chaine[ind + mini] > 57))
                            {
                                code128 = "";
                                break;
                            }
							*/
                            mini = mini - 1;
                        }
                    }

                    if (mini < 0)
                    {
                        if (ind == 0)
                            code128 = char.ToString((char)205);
                        else
                            code128 = code128 + char.ToString((char)199);

                        tableB = false;
                    }
                    else
                    {
                        if (ind == 0)
                            code128 = char.ToString((char)204);
                    }
                }

                if (tableB == false)
                {
                    mini = 2;
                    mini = mini - 1;
                    if (ind + mini < longueur)
                    {
                        while (mini >= 0)
                        {
                            if (((chaine[ind + mini]) < 48) || ((chaine[ind]) > 57))
                            {
                                break;
                            }
                            mini = mini - 1;
                        }
                    }

                    if (mini < 0)
                    {
                        dummy = int.Parse(chaine.Substring(ind, 2));

                        //Console.WriteLine("\n  dummy ici : "+dummy);
                        if (dummy < 95)
                            dummy = dummy + 32;
                        else
                            dummy = dummy + 100;

                        code128 = code128 + (char)(dummy);
                        ind = ind + 2;
                    }
                    else
                    {
                        code128 = code128 + char.ToString((char)200);
                        tableB = true;
                    }
                }
                if (tableB == true)
                {
                    code128 = code128 + chaine[ind];
                    ind = ind + 1;
                }
            }

            for (ind = 0; ind <= code128.Length - 1; ind++)
            {
                dummy = code128[ind];
             
                if (dummy < 127)
                    dummy = dummy - 32;
                else
                    dummy = dummy - 100;

                if (ind == 0)
                {
                    checksum = dummy;
                }
                checksum = (checksum + (ind) * dummy) % 103;
            }

            if (checksum < 95)
            {
                checksum = checksum + 32;
            }
            else
            {
                checksum = checksum + 100;
            }
            code128 = code128 + char.ToString((char)checksum) + char.ToString((char)206);
            return code128;
        }

		private bool checkXmlTag(string tag)
		{
			try
			{
				XmlNodeList xnlList = null;
				XmlNode root = xmlLabels.DocumentElement;
				xnlList = root.SelectNodes("/Style/Label_Style[@file  = 'LBL_EXTENDED.CDR']/Measure");
				foreach (XmlNode myNode in xnlList)
				{
					if (myNode.InnerXml.ToUpper().Contains(tag.Trim().ToUpper())) return true;
				}
					return false;
			}
			catch
			{
				return false;
			}
		}

        public void Excel_Account_Representative_Label(DataRow drDoc, string sBatchID, string sNewBatchID, string sItemCode,
                                                        string sNewItemCode, string sGroupCode, string sBatchCode, string sLabelFileName)
        {
            try
			{
				try
				{
					if (xmlLabels == null)
					{
						var sFileNameKeyMap = "Labels.xml";
						Service.GetKeymap(sFileNameKeyMap);
						var sFileName = Service.sTempDir + System.IO.Path.DirectorySeparatorChar + sFileNameKeyMap;
						xmlLabels = new XmlDocument();
						//sFileName = Service.sAppDir + System.IO.Path.DirectorySeparatorChar + sFileName;
						xmlLabels.Load(sFileName);
					}
				}
				catch { }
			
				skipErrors = false;
				string[] sLabel = sLabelFileName.Split('.');
				switch (sLabel[0].ToUpper().Trim())
				{
					case "ACC_REP_TLKW_LABEL":
					case "ACCOUNT_REP_TLKW_LABEL":
					case "ACCOUNT_REP_TLKW_CEL100":
					case "ACCOUNT_REP_TLKW_CEL102":
					case "ACCOUNT_REP_TLKW_CELGRAND":
					case "ACCOUNT_REP_TLKW_ARCBRIL":
					case "LBL_EXTENDED":
						{
							if (sLabel[0].ToUpper().Trim().Contains("LBL_EXTENDED")) skipErrors = true;
							Excel_Account_Representative_Label_TLKW(drDoc, sBatchID, sNewBatchID, sItemCode, sNewItemCode, sGroupCode, sBatchCode, sLabelFileName);
							break;
						}
					case "ACC_REP_LABEL":
					case "ACCOUNT_REP_LABEL":
					case "LBL1":
					case "ACCOUNT_REP_LABEL_CD":
						{
							Excel_Account_Representative_Label_Reg(drDoc, sBatchID, sNewBatchID, sItemCode, sNewItemCode, sGroupCode, sBatchCode);
							break;
						}
					case "ACCOUNT_REP_LABEL_QR":
					case "ACC_REP_LABEL_QR":
						{
							Excel_Account_Representative_Label_QR(drDoc, sBatchID, sNewBatchID, sItemCode, sNewItemCode, sGroupCode, sBatchCode);
							break;
						}
					case "ACCOUNT_REP_LABEL3":
						{
							Excel_Account_Representative_Label_New(drDoc, sBatchID, sNewBatchID, sItemCode, sNewItemCode, sGroupCode, sBatchCode);
							break;
						}

					default:
						{
							Excel_Account_Representative_Label_Reg(drDoc, sBatchID, sNewBatchID, sItemCode, sNewItemCode, sGroupCode, sBatchCode);
							break;
						}
				}
				skipErrors = false;
           }
           catch
            {
                Excel_Account_Representative_Label_Reg(drDoc, sBatchID, sNewBatchID, sItemCode, sNewItemCode, sGroupCode, sBatchCode);
            }
          
         }

        public Bitmap PrePareQRCode(string myQRcode)
        {
            Bitmap img;
            try
            {
				QRCodeEncoder encoder = new QRCodeEncoder
				{
					QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L,
					QRCodeScale = 10,
					QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE,
					QRCodeVersion = 4
				};
				//myQRcode = @"http://wg.gemscience.net/vr/veri.aspx?" + myQRcode;
				img = encoder.Encode(myQRcode);
            }
            catch
            { return null; }
            return img;
       
        }
        private void Excel_Account_Representative_Label_QR(DataRow drDoc, string sBatchID, string sNewBatchID, string sItemCode, string sNewItemCode,
                                                           string sGroupCode, string sBatchCode)
        {
            //string sReportName = "Account_Rep_Label.xls";

            //#if DEBUG 
            //            sReportName = "Account_Rep_Label_New.xls";
            //#endif

             // New part 03/07/08
            //int k = sReportName.ToUpper().IndexOf(".XLS");
            sPrinterName = GetPrinterName("Account_Rep_Label");
            string sReportName = "Account_Rep_Label_QR.xls";
            string sReportPath = Client.GetOfficeDirPath("repDir") + sReportName;
            
           
            #region get data
            DataTable table = new DataTable("parsel_label");

            //DataSet for print
            table.Columns.Add("barcode", System.Type.GetType("System.String"));
            table.Columns.Add("barcodenum", System.Type.GetType("System.String"));
            table.Columns.Add("carat weight", System.Type.GetType("System.String"));
            table.Columns.Add("color", System.Type.GetType("System.String"));
            table.Columns.Add("clarity", System.Type.GetType("System.String"));
            table.Columns.Add("isPrinted", System.Type.GetType("System.String"));
            table.Columns.Add("Gnumber", System.Type.GetType("System.String"));

            table.Rows.Add(table.NewRow());

            sGroupCode = FillToFiveChars(sGroupCode);
            sBatchCode = FillToThreeChars(sBatchCode);
            sItemCode = FillToTwoChars(sItemCode);

            DataSet dsItemSet = new DataSet();

            string sFullOldNumber = "";
            string sFullNewNumber = "";
            string sDotNewBatch = "";

            string sNewNumber = "";
            string sOldNumber = "";
            string sprefix = "";

            string sFinalLabelCode = "";

            DataSet dsResults = new DataSet();
            dsResults.Tables.Add("ItemDataFromOrderBatchItem");
            dsResults.Tables[0].Columns.Add("GroupCode");
            dsResults.Tables[0].Columns.Add("BatchCode");
            dsResults.Tables[0].Columns.Add("ItemCode");
            dsResults.Tables[0].Rows.Add(dsResults.Tables[0].NewRow());

            dsResults.Tables[0].Rows[0]["GroupCode"] = sGroupCode;
            dsResults.Tables[0].Rows[0]["BatchCode"] = sBatchCode;
            dsResults.Tables[0].Rows[0]["ItemCode"] = sItemCode;

            dsResults = Service.ProxyGenericGet(dsResults);
            if (dsResults.Tables[0].Rows.Count == 0)
            {
                throw new Exception("Missing Data for # " + sGroupCode + "." + sBatchCode + "." + sItemCode);
            }            //get Measures for print from tblDocumentValues

            DataRow[] drResults = dsResults.Tables[0].Select("PartName = 'Item Container'");

            foreach (DataRow dr in drResults)
            {
                switch (dr["MeasureName"].ToString().Trim())
                {
                    case "NewItemNumber":
                        {
                            sNewNumber = dr["ResultValue"].ToString().Trim();
                            break;
                        }
                    case "OldItemNumber":
                        {
                            sOldNumber = dr["ResultValue"].ToString().Trim();
                            table.Rows[0]["barcode"] = "*" + sOldNumber + "*";
                            break;
                        }
                    case "DotOldItemNumber":
                        {
                            sFullOldNumber = dr["ResultValue"].ToString().Trim();
                            table.Rows[0]["barcodenum"] = sFullOldNumber;
                            break;
                        }
                    case "DotNewItemNumber":
                        {
                            sFullNewNumber = dr["ResultValue"].ToString().Trim();
                            break;
                        }
                    case "DotNewBatchNumber":
                        {
                            sDotNewBatch = dr["ResultValue"].ToString().Trim();
                            break;
                        }
                    case "FinalLabel":
                        {
                            sFinalLabelCode = dr["ResultValue"].ToString().Trim();
                            if (int.Parse(dr["ResultValue"].ToString().Trim()) == 1000)
                            {
                                sReportName = "Account_Rep_TL_Label.xls";
                                sReportPath = Client.GetOfficeDirPath("repDir") + sReportName;
                            }

                            break;
                        }
                    case "Prefix":
                        {
                            sprefix = dr["ResultValue"].ToString().Trim();
                            break;
                        }
                }
            }

            DataSet dsDocsValue = gemoDream.Service.GetDocumentValues(drDoc["DocumentID"].ToString());//Procedure dbo.spGetDocumentValue

            ArrayList ErrorArray = new ArrayList();
            DataRow GnumberRow = dsDocsValue.Tables[0].Rows[0];
            string Gnumber1 = GnumberRow["Value"].ToString();
            string[] Gset;
            string Gnumber;
            if (Gnumber1.Trim().ToUpper().IndexOf("GNUMBER") > 0)
            {
                Gnumber = ReplaceBracketsWithValues(GnumberRow["Value"].ToString(), dsResults.Tables[0], sFullNewNumber + "/" + sFullOldNumber);
                Gset = Gnumber.Split('.');
                dsDocsValue.Tables[0].Rows[0].Delete();
                dsDocsValue.Tables[0].AcceptChanges();
                Gnumber = (Convert.ToInt32(Gset[0])).ToString("X");
                //Gnumber = DecimalToBase(Convert.ToInt32(Gset[0]), 16);
                table.Rows[0]["barcode"] = "*" + Gnumber.ToUpper() + "*";
                table.Rows[0]["Gnumber"] = Gnumber.ToUpper();
            }

            for (int it = 0; it < Math.Min(dsDocsValue.Tables[0].Rows.Count, 4); it++)
            {
                //decomposition string [Part_Name.Measure_Name] / [Part_Name.Measure_Name] / [Part_Name.Measure_Name]...
                //to array [Part_Name.Measure_Name]
                DataRow row = dsDocsValue.Tables[0].Rows[it];

                String temp = GetMyValues(row["Value"].ToString(), dsResults.Tables[0], sFullNewNumber + "/" + sFullOldNumber, ref ErrorArray).Trim();

                //                String temp = ReplaceBracketsWithValues(row["Value"].ToString(), dsResults.Tables[0], sFullNewNumber + "/" + sFullOldNumber);

                temp = temp.Replace("VERY GOOD", "VG").Replace("IDEAL", "ID").Replace("GOOD", "G").Replace("EXCELLENT", "EX").Replace("FAIR", "F").Replace("N/A", "NA");
                temp = temp.Replace("Very Good", "VG").Replace("Ideal", "ID").Replace("Good", "G").Replace("Excellent", "EX").Replace("Fair", "F");
                temp = temp + " " + row["Unit"].ToString();
                temp = temp.Replace(" %", "%").Replace(" " + Convert.ToChar(176).ToString(), Convert.ToChar(176).ToString());
                temp = temp.Replace("SQUARE", "SQ.").Replace("MODIFIED", "MOD.");
                temp = temp.Replace("Square", "Sq.").Replace("Modified", "Mod.");

                if (temp.Length > 0)
                {
                    table.Rows[0][it + 2] = temp + " " + row["Unit"];
                }
            }
            string sErrMessage = "";
            try
            {
                if (ErrorArray.Count > 0)
                {
                    foreach (string sLine in ErrorArray)
                    {
                        sErrMessage = sErrMessage + sLine + "\n";
                    }
                    throw new Exception("\n" + sErrMessage);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                MessageBox.Show("Item # " + sNewNumber + "\n" + "Missing data:" + "\n" + msg);
                return;
            }

            //dsCrystalSet = new DataSet();
            //dsCrystalSet.Tables.Add(table);
            Bitmap QR_Code = PrePareQRCode(sOldNumber);
            string sTempDir = System.Environment.GetEnvironmentVariable("TEMP") + System.IO.Path.DirectorySeparatorChar;
            string sQR_code_File = sTempDir + sOldNumber + ".bmp";
            if (File.Exists(sQR_code_File)) File.Delete(sQR_code_File);
            QR_Code.Save(sTempDir + sOldNumber + ".bmp", ImageFormat.Bmp);
            
            DataSet dsIn = new DataSet();
            dsIn.Tables.Add("ItemDocByCodeTypeEx");
            DataSet dsOut = Service.GenericGetCrystalSet(dsIn);

            dsOut.Tables[0].Rows.Add(dsOut.Tables[0].NewRow()); //Procedure dbo.spGetItemDocByCodeTypeEx
            dsOut.Tables[0].Rows[0]["GroupCode"] = sGroupCode;
            dsOut.Tables[0].Rows[0]["BatchCode"] = sBatchCode;
            dsOut.Tables[0].Rows[0]["ItemCode"] = sItemCode;
            dsOut.Tables[0].TableName = "ItemDocByCode";
            DataSet dsOut2 = Service.GenericGetCrystalSet(dsOut); //Procedure dbo.spGetItemDocByCode

            /*
            CrystalDecisions.CrystalReports.Engine.TextObject crText;
            crText = crDocument.ReportDefinition.ReportObjects["text1"] as CrystalDecisions.CrystalReports.Engine.TextObject;
            crText.Text = dsCrystalSet.Tables[0].Rows[0][5].ToString();
            */
            string sText1 = " ";
            sText1 = table.Rows[0][5].ToString();

            string sIsPrinted = " ";
            if (dsOut2.Tables[0].Rows.Count == 0)
                sIsPrinted = "Z";

            table.Rows[0][5] = sIsPrinted;
            /*
            if(dsOut2.Tables[0].Rows.Count>0)
                dsCrystalSet.Tables[0].Rows[0][5] = "";
            else
                dsCrystalSet.Tables[0].Rows[0][5] = "Z";
                */
            #endregion 
            #region Open Excel
            Client.MyActiveReportName = "";
            Open_Excel(sReportPath);
            //            //Excel.Application objExcel = null ;
            //            Excel.Workbook BookData = null;
            //            Excel.Workbook BookTemp = null;
            try
            {
                 Excel.Worksheet SheetData = (Excel.Worksheet)BookTemp.Sheets[1];
                //Excel.Worksheet SheetData1 = (Excel.Worksheet)BookTemp.Sheets[2];

                Excel.Range crCell = null;
                {
                    crCell = SheetData.get_Range("A1", Type.Missing);
                    crCell.Cells.Value2 = "GSI #" + sFullOldNumber; 

                    //crCell = SheetData.get_Range("b3", Type.Missing);
                    ////crCell.Cells.Value2 = table.Rows[0]["barcodenum"].ToString(); //barcodenum -- old part
                    //crCell.Cells.Value2 = sFullOldNumber; //oldNumber; //new part 07/25/08

                    crCell = SheetData.get_Range("A6", Type.Missing);
                    crCell.Cells.Value2 = sDotNewBatch; //newBatchNumber;//new batch #
                }
                crCell = SheetData.get_Range("A4", Type.Missing);
                crCell.Cells.Value2 = sText1; //Shape

                crCell = SheetData.get_Range("A2", Type.Missing);
                crCell.Cells.Value2 = table.Rows[0]["carat weight"].ToString(); //carat weight

                crCell = SheetData.get_Range("A3", Type.Missing);
                crCell.Cells.Value2 = table.Rows[0]["color"].ToString(); //color

                crCell = SheetData.get_Range("B3", Type.Missing);
                crCell.Cells.Value2 = table.Rows[0]["clarity"].ToString(); //clarity

                if (QR_Code != null  && File.Exists(sQR_code_File))
                {
                    crCell = SheetData.get_Range("D3", Type.Missing);
                    float Left = (float)((double)crCell.Left);
                    float Top = (float)((double)crCell.Top);
                    const float ImageSize = 60;
                    SheetData.Shapes.AddPicture(sQR_code_File, Microsoft.Office.Core.MsoTriState.msoFalse,
                                                Microsoft.Office.Core.MsoTriState.msoCTrue, Left, Top, ImageSize, ImageSize);
                }

                string myFile = "";
#if DEBUG
                myFile = @"C:\DELL\Temp\" + Service.FillToFiveChars(sGroupCode) + "." + Service.FillToThreeChars(sBatchCode) + "." + Service.FillToTwoChars(sItemCode) + ".xls";
                SheetData.PrintOutEx(1, 1, 1, false, sPrinterName, Type.Missing, true, Type.Missing, Type.Missing);
                SheetData.SaveAs(myFile, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
#else                
				//SheetData1.PrintOutEx(1, 1, 1, false, sPrinterName, Type.Missing, true, Type.Missing, Type.Missing);
				SheetData.PrintOut(1, 1, 1, false, sPrinterName, Type.Missing, true, Type.Missing);
#endif
                //                SheetData1.PrintOut(Type.Missing,Type.Missing,1,false,sPrinterName,Type.Missing,true,Type.Missing);

                //                NAR(crCell);
                //                NAR(SheetData);
                //                NAR(SheetLabel);
                //                crCell = null;
                //                SheetLabel = null;
                //                SheetData = null;
            }
            catch (Exception ex)
            {
                Client.MyActivePrinter = "";
                Client.MyActiveReportName = "";
                if (objExcel != null)
                    CloseExcel();
                objExcel = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                string msg = ex.Message;
                if (msg == "file not found")
                {
                    throw new Exception("The system cannot find the file: " + sReportPath);
                }
            }
            finally
            {
                ////                try
                ////                {
                ////                    BookTemp.Save();//save for test
                ////                    BookTemp.Close(false,fnTemp,null);
                ////					
                ////                }
                ////                catch(Exception ex)
                ////                {}
                //                try
                //                {BookData.Close(false,sReportPath,null);}
                //                catch(Exception ex)
                //                {}
                //                try
                //                {
                //                    //objExcel.Quit();
                //					
                //                    NAR(BookTemp);
                //                    NAR(BookData);
                //                    //NAR(objExcel);
                //
                //                    BookTemp=null;
                //                    BookData=null;
                //                    //objExcel=null;
                //
                //                    /*
                //                                        GC.Collect();
                //                                        GC.WaitForPendingFinalizers(); 
                //                                        GC.Collect();*/
                //                }
                //                catch(Exception ex)
                //                {}
                //                try
                //                {
                //                if(File.Exists(fnTemp))
                //                	File.Delete(fnTemp);//delete temp file
                //                }
                //                catch(Exception ex)
                //                {}
            }
            #endregion       
        }


        private void Excel_Account_Representative_Label_Reg(DataRow drDoc, string sBatchID, string sNewBatchID, string sItemCode, string sNewItemCode,
                                                            string sGroupCode, string sBatchCode)
        {
            string sReportName = "Account_Rep_Label.xls";
			string sQRcode = "https://wg.gemscience.net/vr/veri.aspx?";
			string sQR_code_File = "";
 			string sReportPath = Client.GetOfficeDirPath("repDir") + sReportName; // New part 03/07/08
            int k = sReportName.ToUpper().IndexOf(".XLS");
			//            //Load template
			//            string sTemp = "";
			//            sTemp = Environment.GetEnvironmentVariable("TEMP");
			//            if(sTemp == "") sTemp = "c:";
			//            string fnTemp = sTemp + "\\account_rep_label" + sGroupCode + "_" + sBatchCode + "_" + sItemCode + ".xls";

			//sReportPath = sReportsDir + @"account_rep_label.xls";//drDoc["CorelFile"];
			#region //
			/*
            try
            {
                crDocument.Load(sReportPath);
            }
            catch (Exception ex)
            {
                throw new Exception("Template was not found at " + sReportPath + "\nPlease make sure the file exists at specified location." );
            }*/
			#endregion
			sPrinterName = GetPrinterName(sReportName.Substring(0, k));
            //sPrinterName = GetRealPrinterName(sPrinterName);
            #region get data
            DataTable table = new DataTable("parsel_label");

            //DataSet for print
            table.Columns.Add("barcode", System.Type.GetType("System.String"));
            table.Columns.Add("barcodenum", System.Type.GetType("System.String"));
            table.Columns.Add("carat weight", System.Type.GetType("System.String"));
            table.Columns.Add("color", System.Type.GetType("System.String"));
            table.Columns.Add("clarity", System.Type.GetType("System.String"));
            table.Columns.Add("isPrinted", System.Type.GetType("System.String"));
            table.Columns.Add("Gnumber", System.Type.GetType("System.String"));
            table.Columns.Add("barcodenum2", System.Type.GetType("System.String"));
            table.Columns.Add("finish", System.Type.GetType("System.String"));
            table.Columns.Add("Reserved", System.Type.GetType("System.String"));
            table.Rows.Add(table.NewRow());

            sGroupCode = FillToFiveChars(sGroupCode);
            sBatchCode = FillToThreeChars(sBatchCode);
            sItemCode = FillToTwoChars(sItemCode);

            //            DataSet dsItemSet = new DataSet();
            //            dsItemSet=gemoDream.Service.GetCrystalSet(sNewBatchID+"_"+sNewItemCode,"Item");//Procedure dbo.spGetItem
            //
            //            string sOldGroupCode = FillToFiveChars(dsItemSet.Tables[0].Rows[0]["PrevGroupCode"].ToString());
            //            string sOldBatchCode = FillToThreeChars(dsItemSet.Tables[0].Rows[0]["PrevBatchCode"].ToString());
            //            string sOldItemCode = FillToTwoChars(dsItemSet.Tables[0].Rows[0]["PrevItemCode"].ToString());
            //            string sFullOldNumber = sOldGroupCode + "." + sOldBatchCode + "." + sOldItemCode;
            //            string sFullNewNumber = sGroupCode + "." + sBatchCode + "." + sItemCode;
            //
            //            if(sOldGroupCode != "00000" && sOldBatchCode != "000" && sOldItemCode != "00" &&
            //                (sOldGroupCode + sOldBatchCode +  sOldItemCode)!= (sGroupCode + sBatchCode + sItemCode))
            //            {
            //                table.Rows[0]["barcode"] = "*" + sOldGroupCode + sOldBatchCode + sOldItemCode + "*";
            //                table.Rows[0]["barcodenum"] = sOldGroupCode + "." + sOldBatchCode + "." + sOldItemCode + "(" + sGroupCode + "." + sBatchCode + "." + sItemCode + ")";
            //            }
            //            else
            //            {
            //                table.Rows[0]["barcode"] = "*" + sGroupCode + sBatchCode + sItemCode + "*";
            //                table.Rows[0]["barcodenum"] = sGroupCode + "." + sBatchCode + "." + sItemCode;
            //            }
            string sFullOldNumber = "";
            string sFullNewNumber = "";
            string sDotNewBatch = "";

            string sNewNumber = "";
            string sOldNumber = "";
			string sprefix = "";

			string sFinalLabelCode = "";
            string sCPCustomerID = "";

            DataSet dsResults = new DataSet();
            dsResults.Tables.Add("ItemDataFromOrderBatchItem");
            dsResults.Tables[0].Columns.Add("GroupCode");
            dsResults.Tables[0].Columns.Add("BatchCode");
            dsResults.Tables[0].Columns.Add("ItemCode");
            dsResults.Tables[0].Rows.Add(dsResults.Tables[0].NewRow());

            dsResults.Tables[0].Rows[0]["GroupCode"] = sGroupCode;
            dsResults.Tables[0].Rows[0]["BatchCode"] = sBatchCode;
            dsResults.Tables[0].Rows[0]["ItemCode"] = sItemCode;

            dsResults = Service.ProxyGenericGet(dsResults);
            if (dsResults.Tables[0].Rows.Count == 0)
            {
                throw new Exception("Missing Data for # " + sGroupCode + "." + sBatchCode + "." + sItemCode);
            }            //get Measures for print from tblDocumentValues

            DataRow[] drResults = dsResults.Tables[0].Select("PartName = 'Item Container'");

            foreach (DataRow dr in drResults)
            {
                switch (dr["MeasureName"].ToString().Trim())
                {
                    case "NewItemNumber":
                        {
                            sNewNumber = dr["ResultValue"].ToString().Trim();
                            break;
                        }
                    case "OldItemNumber":
                        {
                            sOldNumber = dr["ResultValue"].ToString().Trim();
                            table.Rows[0]["barcode"] = "*" + sOldNumber + "*";
                            break;
                        }
                    case "DotOldItemNumber":
                        {
                            sFullOldNumber = dr["ResultValue"].ToString().Trim();
                            table.Rows[0]["barcodenum"] = sFullOldNumber;
                            break;
                        }
                    case "DotNewItemNumber":
                        {
                            sFullNewNumber = dr["ResultValue"].ToString().Trim();
                            break;
                        }
                    case "DotNewBatchNumber":
                        {
                            sDotNewBatch = dr["ResultValue"].ToString().Trim();
                            break;
                        }
					case "FinalLabel":
						{
							sFinalLabelCode = dr["ResultValue"].ToString().Trim();
							if (int.Parse(dr["ResultValue"].ToString().Trim()) == 1000)
							{
								sReportName = "Account_Rep_TL_Label.xls";
								sReportPath = Client.GetOfficeDirPath("repDir") + sReportName;
							}

							break;
						}
                    case "CPCustomerID":
                        {
                            sCPCustomerID = dr["ResultValue"].ToString().Trim();
                            break;
                        }

					case "Prefix":
						{
							sprefix = dr["ResultValue"].ToString().Trim();
							break;
						}
                }
            }

            if (sprefix.Trim() == "" && sFinalLabelCode.Trim().ToUpper() == "4000")
            {
                // "PartName = '" + asParts[0] + "' and MeasureName = '" + asParts[1] + "'"
                drResults = dsResults.Tables[0].Select("PartName like 'Diamond%' and MeasureName = 'Prefix'");
                sprefix = drResults[0]["ResultValue"].ToString().Trim();
            }
			ArrayList ErrorArray = new ArrayList();

			DataSet dsDocsValue = gemoDream.Service.GetDocumentValues(drDoc["DocumentID"].ToString());//Procedure dbo.spGetDocumentValue

			try
			{
				var drAdd = dsDocsValue.Tables[0].Select("Title like '%$QRCODE%'");
				if (drAdd.Length > 0)
				{
					var tempQR = GetMyValues(drAdd[0]["Value"].ToString(), dsResults.Tables[0], sFullNewNumber + "/" + sFullOldNumber, ref ErrorArray).Trim();
					sQRcode = sQRcode + tempQR;
					if (sQRcode.Trim().Length > 10)
					{
						Bitmap QR_Code = PrePareQRCode(sQRcode);
						string sTempDir = System.Environment.GetEnvironmentVariable("TEMP") + System.IO.Path.DirectorySeparatorChar;
						sQR_code_File = sTempDir + sOldNumber + ".bmp";
						if (File.Exists(sQR_code_File)) File.Delete(sQR_code_File);
						QR_Code.Save(sQR_code_File, ImageFormat.Bmp);
						sReportName = "account_rep_label_QR1.xls";
						sReportPath = Client.GetOfficeDirPath("repDir") + sReportName;
					}
				}
			}
			catch (Exception ex)
			{
				var sMessage = ex.Message;
			}

			DataRow GnumberRow = dsDocsValue.Tables[0].Rows[0];
            string Gnumber1 = GnumberRow["Value"].ToString();
            string[] Gset;
            string Gnumber;
            if (Gnumber1.Trim().ToUpper().IndexOf("GNUMBER") > 0)
            {
                Gnumber = ReplaceBracketsWithValues(GnumberRow["Value"].ToString(), dsResults.Tables[0], sFullNewNumber + "/" + sFullOldNumber);
                Gset = Gnumber.Split('.');
                dsDocsValue.Tables[0].Rows[0].Delete();
                dsDocsValue.Tables[0].AcceptChanges();
                Gnumber = (Convert.ToInt32(Gset[0])).ToString("X");
                //Gnumber = DecimalToBase(Convert.ToInt32(Gset[0]), 16);
                table.Rows[0]["barcode"] = "*" + Gnumber.ToUpper() + "*";
                table.Rows[0]["Gnumber"] = Gnumber.ToUpper();
            }

            for (int it = 0; it < Math.Min(dsDocsValue.Tables[0].Rows.Count, 4); it++)
            {
                //decomposition string [Part_Name.Measure_Name] / [Part_Name.Measure_Name] / [Part_Name.Measure_Name]...
                //to array [Part_Name.Measure_Name]
                DataRow row = dsDocsValue.Tables[0].Rows[it];

				string temp = GetMyValues(row["Value"].ToString(), dsResults.Tables[0], sFullNewNumber + "/" + sFullOldNumber, ref ErrorArray).Trim();

                //                String temp = ReplaceBracketsWithValues(row["Value"].ToString(), dsResults.Tables[0], sFullNewNumber + "/" + sFullOldNumber);

                temp = temp.Replace("VERY GOOD", "VG").Replace("IDEAL", "ID").Replace("GOOD", "G").Replace("EXCELLENT", "EX").Replace("FAIR", "F").Replace("N/A", "NA");
                temp = temp.Replace("Very Good", "VG").Replace("Ideal", "ID").Replace("Good", "G").Replace("Excellent", "EX").Replace("Fair", "F");
                temp = temp.Replace("SQUARE", "SQ.").Replace("MODIFIED", "MOD.");
                temp = temp.Replace("Square", "Sq.").Replace("Modified", "Mod.");               
                
                //temp = temp + " " + row["Unit"].ToString();
                if (temp.Length > 0)
                {
                    table.Rows[0][it + 2] = temp.Trim() + " " + row["Unit"];
                }
                temp = temp.Replace(" %", "%").Replace(" " + Convert.ToChar(176).ToString(), Convert.ToChar(176).ToString());
            }
            string sErrMessage = "";
            try
            {
                if (ErrorArray.Count > 0)
                {
                    foreach (string sLine in ErrorArray)
                    {
                        sErrMessage = sErrMessage + sLine + "\n";
                    }
                    throw new Exception("\n" + sErrMessage);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                MessageBox.Show("Item # " + sNewNumber + "\n" + "Missing data:" + "\n" + msg);
                return;
            }

            DataSet dsIn = new DataSet();
            dsIn.Tables.Add("ItemDocByCodeTypeEx");
            DataSet dsOut = Service.GenericGetCrystalSet(dsIn);

            dsOut.Tables[0].Rows.Add(dsOut.Tables[0].NewRow()); //Procedure dbo.spGetItemDocByCodeTypeEx
            dsOut.Tables[0].Rows[0]["GroupCode"] = sGroupCode;
            dsOut.Tables[0].Rows[0]["BatchCode"] = sBatchCode;
            dsOut.Tables[0].Rows[0]["ItemCode"] = sItemCode;
            dsOut.Tables[0].TableName = "ItemDocByCode";
            DataSet dsOut2 = Service.GenericGetCrystalSet(dsOut); //Procedure dbo.spGetItemDocByCode

             string sText1 = " ";
            sText1 = table.Rows[0][5].ToString();

            string sIsPrinted = " ";
            if (dsOut2.Tables[0].Rows.Count == 0)
                sIsPrinted = "Z";

            table.Rows[0][5] = sIsPrinted;
            /*
            if(dsOut2.Tables[0].Rows.Count>0)
                dsCrystalSet.Tables[0].Rows[0][5] = "";
            else
                dsCrystalSet.Tables[0].Rows[0][5] = "Z";
                */
            #endregion

            #region Open Excel
            Client.MyActiveReportName = "";
            if (sFinalLabelCode.Trim().ToUpper() == "4000")
            {
                sReportName = "Account_Rep_Label_cd.xls";
                sReportPath = Client.GetOfficeDirPath("repDir") + sReportName;
            }

            Open_Excel(sReportPath);
            //            //Excel.Application objExcel = null ;
            //            Excel.Workbook BookData = null;
            //            Excel.Workbook BookTemp = null;
            try
            {
                //                if(objExcel == null)
                //                    objExcel = new Excel.Application();
                //                try
                //                {
                //                    BookData = objExcel.Workbooks.Open(sReportPath,Type.Missing,true,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing);
                //                }
                //                catch(Exception ex)
                //                {
                //                    throw new Exception("file not found");
                //                }
                //                try
                //                {
                //                    if(File.Exists(fnTemp))
                //                        File.Delete(fnTemp);//delete temp file
                //                }
                //                catch{}
                //
                //                BookData.SaveCopyAs(fnTemp);
                //                BookData.Close(false,sReportPath,null);
                //                //make local copy
                //
                //                BookTemp = objExcel.Workbooks.Open(fnTemp,Type.Missing,false,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing);
                Excel.Worksheet SheetData = (Excel.Worksheet)BookTemp.Sheets[2];
                Excel.Worksheet SheetData1 = (Excel.Worksheet)BookTemp.Sheets[1];

                Excel.Range crCell = null;

                //                string newBatchNumber = "";
                //                string oldNumber = table.Rows[0]["barcodenum"].ToString();
                //                newBatchNumber = oldNumber.Substring(0, 9);
                //                if (table.Rows[0]["barcodenum"].ToString().IndexOf("(") > 0)
                //                {
                //                    oldNumber = table.Rows[0]["barcodenum"].ToString().Substring(0, table.Rows[0]["barcodenum"].ToString().IndexOf("("));
                //                    newBatchNumber = table.Rows[0]["barcodenum"].ToString().Substring(table.Rows[0]["barcodenum"].ToString().IndexOf("(")+1,9);
                //                }
                //                if (table.Rows[0]["Gnumber"].ToString().Trim() != "") 
                //                {
                //                    newBatchNumber = sGroupCode + "." + sBatchCode + "." + sItemCode;
                //                    oldNumber = table.Rows[0]["Gnumber"].ToString();
                //                    //newBatchNumber = table.Rows[0]["Gnumber"].ToString();
                //                }

				if (sFinalLabelCode.Trim().ToUpper() == "2000")
				{
					crCell = SheetData.get_Range("b2", Type.Missing);
					crCell.Cells.Value2 = "*" + sprefix + "*"; //table.Rows[0]["barcode"].ToString(); //barcode

					crCell = SheetData.get_Range("b3", Type.Missing);
					//crCell.Cells.Value2 = table.Rows[0]["barcodenum"].ToString(); //barcodenum -- old part
					crCell.Cells.Value2 = sCPCustomerID + ": " + sprefix; //oldNumber; //new part 07/25/08

					crCell = SheetData.get_Range("b9", Type.Missing);
					crCell.Cells.Value2 = sFullOldNumber; //newBatchNumber;//new batch #
				}
                else if (sFinalLabelCode.Trim().ToUpper() == "4000")
                {
                    if (sprefix.Trim().Length > 0)
                    { 
                        Match m = Regex.Match(sprefix.Trim(), @"[\d.,]+");
                        if (m.Success) sprefix = m.Value;

                    }
                    crCell = SheetData.get_Range("b2", Type.Missing);
                    crCell.Cells.Value2 = "*" + sprefix + "*"; //table.Rows[0]["barcode"].ToString(); //barcode

                    crCell = SheetData.get_Range("b3", Type.Missing);
                    //crCell.Cells.Value2 = table.Rows[0]["barcodenum"].ToString(); //barcodenum -- old part
                    crCell.Cells.Value2 = sCPCustomerID + ": " + sprefix; //oldNumber; //new part 07/25/08

                    crCell = SheetData.get_Range("b9", Type.Missing);
                    crCell.Cells.Value2 = "*" + sOldNumber + "*"; //newBatchNumber;//new batch #

                    crCell = SheetData.get_Range("b10", Type.Missing);
                    crCell.Cells.Value2 = sFullOldNumber; //newBatchNumber;//new batch #
                }
				else
				{
					crCell = SheetData.get_Range("b2", Type.Missing);
					crCell.Cells.Value2 = "*" + sOldNumber + "*"; //table.Rows[0]["barcode"].ToString(); //barcode

					crCell = SheetData.get_Range("b3", Type.Missing);
					//crCell.Cells.Value2 = table.Rows[0]["barcodenum"].ToString(); //barcodenum -- old part
					crCell.Cells.Value2 = sFullOldNumber; //oldNumber; //new part 07/25/08

					crCell = SheetData.get_Range("b9", Type.Missing);
					crCell.Cells.Value2 = sDotNewBatch; //newBatchNumber;//new batch #
				}
                
                crCell = SheetData.get_Range("b4", Type.Missing);
                crCell.Cells.Value2 = sText1; //Shape

                crCell = SheetData.get_Range("b5", Type.Missing);
                crCell.Cells.Value2 = table.Rows[0]["carat weight"].ToString(); //carat weight

                crCell = SheetData.get_Range("b6", Type.Missing);
                crCell.Cells.Value2 = table.Rows[0]["color"].ToString(); //color

                crCell = SheetData.get_Range("b7", Type.Missing);
                crCell.Cells.Value2 = table.Rows[0]["clarity"].ToString(); //clarity

                crCell = SheetData.get_Range("b8", Type.Missing);
                crCell.Cells.Value2 = table.Rows[0]["isPrinted"].ToString(); //isPrinted
                if (sReportName.ToUpper() == "ACCOUNT_REP_LABEL3.XLS")
                {
                    crCell = SheetData.get_Range("b10", Type.Missing);
                    crCell.Cells.Value2 = table.Rows[0]["barcodenum2"].ToString(); //barcodenum2
                    crCell = SheetData.get_Range("b11", Type.Missing);
                    crCell.Cells.Value2 = table.Rows[0]["finish"].ToString(); //finish             
                }

				//crCell = SheetData.get_Range("b9", Type.Missing);
				//crCell.Cells.Value2 = sDotNewBatch; //newBatchNumber;//new batch #
				
				if (sReportName.ToUpper() == "ACCOUNT_REP_TL_LABEL.XLS")
				{
					crCell = SheetData.get_Range("b10", Type.Missing);
					crCell.Cells.Value2 = "*" + sprefix + "*";
					
					crCell = SheetData.get_Range("b11", Type.Missing);
					crCell.Cells.Value2 = sprefix.ToString();
				}

				try
				{
					if (sQRcode.Trim().Length > 5)
					{
						if (File.Exists(sQR_code_File))
						{
							crCell = SheetData1.get_Range("b4", Type.Missing);
							float Left = 130; // (float)((double)crCell.Left);
							float Top = 30; // (float)((double)crCell.Top);
							float ImageSize = 50;
							SheetData1.Shapes.AddPicture(sQR_code_File, Microsoft.Office.Core.MsoTriState.msoFalse,
														Microsoft.Office.Core.MsoTriState.msoCTrue, Left, Top, ImageSize, ImageSize);
						}
					}
				}
				catch (Exception ex)
				{
					var sMessage = ex.Message;
				}
				
                //Excel.Worksheet SheetLabel = (Excel.Worksheet)BookTemp.Sheets[1];
                string myFile = "";
#if DEBUG
				myFile = @"C:\DELL\" + Service.FillToFiveChars(sGroupCode) + "." + Service.FillToThreeChars(sBatchCode) + "." + Service.FillToTwoChars(sItemCode) + ".xls";
				SheetData1.PrintOutEx(1, 1, 1, false, sPrinterName, Type.Missing, true, Type.Missing, Type.Missing);
				SheetData1.SaveAs(myFile, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
#else                
				//SheetData1.PrintOutEx(1, 1, 1, false, sPrinterName, Type.Missing, true, Type.Missing, Type.Missing);
				SheetData1.PrintOut(1, 1, 1, false, sPrinterName, Type.Missing, true, Type.Missing);
#endif
				//                SheetData1.PrintOut(Type.Missing,Type.Missing,1,false,sPrinterName,Type.Missing,true,Type.Missing);

                //                NAR(crCell);
                //                NAR(SheetData);
                //                NAR(SheetLabel);
                //                crCell = null;
                //                SheetLabel = null;
                //                SheetData = null;
            }
            catch (Exception ex)
            {
                Client.MyActivePrinter = "";
                Client.MyActiveReportName = "";
                if (objExcel != null)
                    CloseExcel();
                objExcel = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                string msg = ex.Message;
                if (msg == "file not found")
                {
                    throw new Exception("The system cannot find the file: " + sReportPath);
                }
            }
            finally
            {
                ////                try
                ////                {
                ////                    BookTemp.Save();//save for test
                ////                    BookTemp.Close(false,fnTemp,null);
                ////					
                ////                }
                ////                catch(Exception ex)
                ////                {}
                //                try
                //                {BookData.Close(false,sReportPath,null);}
                //                catch(Exception ex)
                //                {}
                //                try
                //                {
                //                    //objExcel.Quit();
                //					
                //                    NAR(BookTemp);
                //                    NAR(BookData);
                //                    //NAR(objExcel);
                //
                //                    BookTemp=null;
                //                    BookData=null;
                //                    //objExcel=null;
                //
                //                    /*
                //                                        GC.Collect();
                //                                        GC.WaitForPendingFinalizers(); 
                //                                        GC.Collect();*/
                //                }
                //                catch(Exception ex)
                //                {}
                //                try
                //                {
                //                if(File.Exists(fnTemp))
                //                	File.Delete(fnTemp);//delete temp file
                //                }
                //                catch(Exception ex)
                //                {}
            }
            #endregion
            //crDocument.SetDataSource(dsCrystalSet);

        }
        private void Excel_Account_Representative_Label_New(DataRow drDoc, string sBatchID, string sNewBatchID, string sItemCode, string sNewItemCode, 
                                                            string sGroupCode, string sBatchCode)
        {
            string sReportName = "ACCOUNT_REP_LABEL3.XLS";
            string sReportPath = Client.GetOfficeDirPath("repDir") + sReportName; // New part 03/07/08
            string sTemp = "Account_Rep_Label.xls";
            int k = sTemp.ToUpper().IndexOf(".XLS");
            sPrinterName = GetPrinterName(sTemp.Substring(0, k));
            #region get data

            string sNewNumber = "";
            string sOldNumber = "";

            string sFullOldNumber = "";
            string sFullNewNumber = "";
            string sDotNewBatch = "";
            //ArrayList SheetToPrint = new ArrayList();
            DataSet dsResults = new DataSet();
            dsResults.Tables.Add("ItemDataFromOrderBatchItem");
            dsResults.Tables[0].Columns.Add("GroupCode");
            dsResults.Tables[0].Columns.Add("BatchCode");
            dsResults.Tables[0].Columns.Add("ItemCode");
            dsResults.Tables[0].Rows.Add(dsResults.Tables[0].NewRow());

            dsResults.Tables[0].Rows[0]["GroupCode"] = sGroupCode;
            dsResults.Tables[0].Rows[0]["BatchCode"] = sBatchCode;
            dsResults.Tables[0].Rows[0]["ItemCode"] = sItemCode;

            dsResults = Service.ProxyGenericGet(dsResults);
            if (dsResults.Tables[0].Rows.Count == 0)
            {
                throw new Exception("Missing Data for # " + sGroupCode + "." + sBatchCode + "." + sItemCode);
            }

            DataRow[] drResults = dsResults.Tables[0].Select("PartName = 'Item Container'");
            foreach (DataRow dr in drResults)
            {
                switch (dr["MeasureName"].ToString().Trim())
                {
                    case "NewItemNumber":
                        {
                            sNewNumber = dr["ResultValue"].ToString().Trim();
                            break;
                        }
                    case "OldItemNumber":
                        {
                            sOldNumber = dr["ResultValue"].ToString().Trim();
                            break;
                        }
                    case "DotOldItemNumber":
                        {
                            sFullOldNumber = dr["ResultValue"].ToString().Trim();
                            break;
                        }
                    case "DotNewItemNumber":
                        {
                            sFullNewNumber = dr["ResultValue"].ToString().Trim();
                            break;
                        }
                    case "DotNewBatchNumber":
                        {
                            sDotNewBatch = dr["ResultValue"].ToString().Trim();
                            break;
                        }
                }
            }
                try
                {
                    DataSet dsDocsValue = gemoDream.Service.GetDocumentValues(drDoc["DocumentID"].ToString());//Procedure dbo.spGetDocumentValue                

                    ArrayList ErrorArray = new ArrayList();
                    foreach (DataRow row in dsDocsValue.Tables[0].Rows)
                    {
                        foreach (DataColumn dc in dsDocsValue.Tables[0].Columns)
                        {
                            if (dc.ColumnName == "Value" | dc.ColumnName == "Title")
                            {
                                String temp = GetMyValues(row[dc.ColumnName].ToString(), dsResults.Tables[0], sFullNewNumber + "/" + sFullOldNumber, ref ErrorArray).Trim();

                                temp = temp.Replace("VERY GOOD", "VG").Replace("IDEAL", "ID").Replace("GOOD", "G").Replace("EXCELLENT", "EX").Replace("FAIR", "F").Replace("N/A", "NA");
                                temp = temp.Replace("Very Good", "VG").Replace("Ideal", "ID").Replace("Good", "G").Replace("Excellent", "EX").Replace("Fair", "F");
                                temp = temp + " " + row["Unit"].ToString();
                                temp = temp.Replace(" %", "%").Replace(" " + Convert.ToChar(176).ToString(), Convert.ToChar(176).ToString());
                                temp = temp.Replace("SQUARE", "SQ.").Replace("MODIFIED", "MOD.");
                                temp = temp.Replace("Square", "Sq.").Replace("Modified", "Mod.");
                                temp = temp.Replace("Extremely", "Extr.");
                                
                                row[dc.ColumnName] = temp;
                            }
                        }
                    }
                    //[Diamond.CutGrade]/[Diamond.Polish]/[Diamond.Symmetry]
                    string sErrMessage = "";
                    if (ErrorArray.Count > 0)
                    {
                        foreach (string sLine in ErrorArray)
                        {
                            sErrMessage = sErrMessage + sLine + "\n";
                        }
                        ErrorArray.Clear();
                        throw new Exception("\n" + sErrMessage);
                    }
#if DEBUG
                    // For debugging only			
                    string filename = "C:/DELL/myXmlDocForCrystalReport.xml";
                    if (File.Exists(filename)) File.Delete(filename);
                    // Create the FileStream to write with.
                    System.IO.FileStream myFileStream = new System.IO.FileStream(filename, System.IO.FileMode.Create);
                    // Create an XmlTextWriter with the fileStream.
                    System.Xml.XmlTextWriter myXmlWriter = new System.Xml.XmlTextWriter(myFileStream, System.Text.Encoding.Unicode);
                    // Write to the file with the WriteXml method.
                    dsDocsValue.WriteXml(myXmlWriter);
                    myXmlWriter.Close();
                    // End of debugging part
#endif

                    #endregion               
                   
                    Open_Excel(sReportPath);
                    try
                    {
                        Excel.Worksheet SheetData = (Excel.Worksheet)BookTemp.Sheets[1];

                        SheetData.Shapes.Item("Barcode").TextFrame.Characters(Type.Missing, Type.Missing).Text = "*" + sOldNumber + "*";
                        SheetData.Shapes.Item("NewBatchNumber").TextFrame.Characters(Type.Missing, Type.Missing).Text = sDotNewBatch;
                        int iTextboxNumber = 1;
					foreach (DataRow dr1 in dsDocsValue.Tables[0].Rows)
					{

						if (dr1["Title"].ToString().ToUpper().Contains("$BARCODE"))
						{
							SheetData.Shapes.Item("Barcode").TextFrame.Characters(Type.Missing, Type.Missing).Text = "*" + dr1["Value"].ToString().Trim() + "*";
						}
						else
						{ 
							SheetData.Shapes.Item("TextBox" + iTextboxNumber.ToString()).TextFrame.Characters(Type.Missing, Type.Missing).Text = dr1["Value"].ToString();
							iTextboxNumber++;
						}
                            //if (iTextboxNumber > dsDocsValue.Tables[0].Rows.Count)
                            //{
                            //    throw new Exception("Template does not fit layout: " + sReportPath);
                            //}
                        }

						string myFile = "";
#if DEBUG
                    myFile = @"C:\DELL\" + Service.FillToFiveChars(sGroupCode) + "." + Service.FillToThreeChars(sBatchCode) + "." + Service.FillToTwoChars(sItemCode) + ".xls";
                    SheetData.SaveAs(myFile, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
#else
						SheetData.PrintOut(1, 1, 1,false, sPrinterName,Type.Missing,true,Type.Missing);
#endif

                    }
                    catch (Exception ex)
                    {
                        string msg = ex.Message;
                        if (msg == "file not found")
                        {
                            throw new Exception("The system cannot find the file: " + sReportPath);
                        }
                    }
                
                }
                
                catch (Exception ex)
                {
                    string msg = ex.Message;
                    MessageBox.Show("Item # " + sNewNumber + ", Missing data:" + "\n" + msg);
                    return;
                }
                finally
                {

    
                    //SheetToPrint.Clear();
                }

            }																																						 
  
        private void Excel_Account_Representative_Label_TLKW(DataRow drDoc, string sBatchID, string sNewBatchID, string sItemCode, string sNewItemCode,
                                                             string sGroupCode, string sBatchCode, string sLabelFileName)
        {
            string sComments = "";
            string sReportName = "";
            string sStyle = "";
#if DEBUG
            sReportName = "Account_Rep_TLKW_Label.xls";
            //sReportName = "Account_Rep_TLKW_CEL100.xls";
#else
            sReportName = "Account_Rep_TLKW_Label.xls";
#endif
            string sReportPath = Client.GetOfficeDirPath("repDir") + sReportName;

            int k = sReportName.ToUpper().IndexOf(".XLS");

            sPrinterName = GetPrinterName(sReportName.Substring(0, k));

            #region get data

            string sNewNumber = "";
            string sOldNumber = "";

            string sFullOldNumber = "";
            string sFullNewNumber = "";
            string sDotNewBatch = "";

            ArrayList SheetToPrint = new ArrayList();

            //DataSet for print
            DataSet dsResults = new DataSet();
            dsResults.Tables.Add("ItemDataFromOrderBatchItem");
            dsResults.Tables[0].Columns.Add("GroupCode");
            dsResults.Tables[0].Columns.Add("BatchCode");
            dsResults.Tables[0].Columns.Add("ItemCode");
            dsResults.Tables[0].Rows.Add(dsResults.Tables[0].NewRow());

            dsResults.Tables[0].Rows[0]["GroupCode"] = sGroupCode;
            dsResults.Tables[0].Rows[0]["BatchCode"] = sBatchCode;
            dsResults.Tables[0].Rows[0]["ItemCode"] = sItemCode;

            dsResults = Service.ProxyGenericGet(dsResults);
            if (dsResults.Tables[0].Rows.Count == 0)
            {
                throw new Exception("Missing Data for # " + sGroupCode + "." + sBatchCode + "." + sItemCode);
            }

            //get Measures for print from tblDocumentValues
            DataRow[] drResults = dsResults.Tables[0].Select("PartName = 'Item Container'");
            //            DataView dvItemData = new DataView(dsResults.Tables[0]);
            //            dvItemData.RowFilter = "PartName = 'Item Container'";

            foreach (DataRow dr in drResults)
            {
                switch (dr["MeasureName"].ToString().Trim())
                {
                    case "NewItemNumber":
                        {
                            sNewNumber = dr["ResultValue"].ToString().Trim();
                            break;
                        }
                    case "OldItemNumber":
                        {
                            sOldNumber = dr["ResultValue"].ToString().Trim();
                            break;
                        }
                    case "DotOldItemNumber":
                        {
                            sFullOldNumber = dr["ResultValue"].ToString().Trim();
                            break;
                        }
                    case "DotNewItemNumber":
                        {
                            sFullNewNumber = dr["ResultValue"].ToString().Trim();
                            break;
                        }
                    case "DotNewBatchNumber":
                        {
                            sDotNewBatch = dr["ResultValue"].ToString().Trim();
                            break;
                        }
                }
            }

            try
            {
                DataSet dsDocsValue = gemoDream.Service.GetDocumentValues(drDoc["DocumentID"].ToString());//Procedure dbo.spGetDocumentValue

                ArrayList ErrorArray = new ArrayList();
                foreach (DataRow row in dsDocsValue.Tables[0].Rows)
                {
                    foreach (DataColumn dc in dsDocsValue.Tables[0].Columns)
                    {
                        if (dc.ColumnName == "Value" | dc.ColumnName == "Title")
                        {
                            String temp = GetMyValues(row[dc.ColumnName].ToString(), dsResults.Tables[0], sFullNewNumber + "/" + sFullOldNumber, ref ErrorArray).Trim();

                            temp = temp.Replace("VERY GOOD", "VG").Replace("IDEAL", "ID").Replace("GOOD", "G").Replace("EXCELLENT", "EX").Replace("FAIR", "F").Replace("N/A", "NA");
                            temp = temp.Replace("Very Good", "VG").Replace("Ideal", "ID").Replace("Good", "G").Replace("Excellent", "EX").Replace("Fair", "F");
                            temp = temp + " " + row["Unit"].ToString();
                            temp = temp.Replace(" %", "%").Replace(" " + Convert.ToChar(176).ToString(), Convert.ToChar(176).ToString());
                            temp = temp.Replace("SQUARE", "SQ.").Replace("MODIFIED", "MOD.");
                            temp = temp.Replace("Square", "Sq.").Replace("Modified", "Mod.");
                            temp = temp.Replace("Extremely", "Extr.");

                            if (row[dc.ColumnName].ToString().ToUpper().Contains("CUTGRADE]")	&& dc.ColumnName == "Value") sComments = sComments + @"Cut/";
                            if (row[dc.ColumnName].ToString().ToUpper().Contains("POLISH]")		&& dc.ColumnName == "Value") sComments = sComments + @"Polish/";
                            if (row[dc.ColumnName].ToString().ToUpper().Contains("SYMMETRY]")	&& dc.ColumnName == "Value") sComments = sComments + @"Symmetry/";
                            if (row[dc.ColumnName].ToString().ToUpper().Contains("STYLE")		&& dc.ColumnName == "Title")
                            {
                                sStyle = row["Value"].ToString().ToUpper().Trim();
                            }

                                row[dc.ColumnName] = (temp.Trim() != "" ? temp : "  ");
                        }
                    }
                }
                //[Diamond.CutGrade]/[Diamond.Polish]/[Diamond.Symmetry]
                string sErrMessage = "";
                if (ErrorArray.Count > 0)
                {
                    foreach (string sLine in ErrorArray)
                    {
                        sErrMessage = sErrMessage + sLine + "\n";
                    }
                    ErrorArray.Clear();
                    throw new Exception("\n" + sErrMessage);
                }
    
            ArrayList alCutGradeDetail = new ArrayList();
#if DEBUG
            // For debugging only			
            string filename = "C:/DELL/myXmlDocForCrystalReport.xml";
            if (File.Exists(filename)) File.Delete(filename);
            // Create the FileStream to write with.
            System.IO.FileStream myFileStream = new System.IO.FileStream(filename, System.IO.FileMode.Create);
            // Create an XmlTextWriter with the fileStream.
            System.Xml.XmlTextWriter myXmlWriter = new System.Xml.XmlTextWriter(myFileStream, System.Text.Encoding.Unicode);
            // Write to the file with the WriteXml method.
            dsDocsValue.WriteXml(myXmlWriter);
            myXmlWriter.Close();
            // End of debugging part
#endif

            #endregion

            #region Open Excel
            Open_Excel(sReportPath);
            //Excel.Application objExcel = null ;
            ////            Excel.Workbook BookData = null;
            ////            Excel.Workbook BookTemp = null;
            try
            {
                ////                if(objExcel == null)
                ////                    objExcel = new Excel.Application();
                ////                try
                ////                {
                ////                    BookData = objExcel.Workbooks.Open(sReportPath,Type.Missing,true,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing);
                ////                }
                ////                catch(Exception ex)
                ////                {
                ////                    throw new Exception("file not found");
                ////                }
                ////                try
                ////                {
                ////                    if(File.Exists(fnTemp))
                ////                        File.Delete(fnTemp);//delete temp file
                ////                }
                ////                catch{}
                ////
                ////                BookData.SaveCopyAs(fnTemp);
                ////                BookData.Close(false,sReportPath,null);
                ////                //make local copy
                ////
                ////                BookTemp = objExcel.Workbooks.Open(fnTemp,Type.Missing,false,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing);
                Excel.Worksheet SheetData = (Excel.Worksheet)BookTemp.Sheets[1];
                Excel.Worksheet SheetData1 = (Excel.Worksheet)BookTemp.Sheets[2];

                Excel.Range crCell = null;

					//SheetData.Shapes.Item("Comments2").TextFrame.Characters(Type.Missing, Type.Missing).Text = "";

					SheetData.Shapes.Item("BarCode39").TextFrame.Characters(Type.Missing, Type.Missing).Text = "";

				int i1 = 0;
                int iBaseCellRow = 2;
                int iMaxRows = 7;
				int iFilledRowInFirstColumn = 0;
                string sTitleColumn = "b";
                string sDataColumn = "c";
                int iRows = dsDocsValue.Tables[0].Rows.Count;

                sLabelFileName = sLabelFileName.ToUpper().Trim();
					/*
					if (iMaxRows * 2 > iRows)
					{
						iMaxRows = iRows / 2 + iRows % 2;
					} */
				crCell = SheetData.get_Range("A1:F10", Type.Missing);
                crCell.Cells.Value2 = null;
                crCell.Cells.NumberFormat = "@";

                crCell = SheetData.get_Range("d9", Type.Missing);
                crCell.Cells.Value2 = "";
					//crCell.Style = "General";
					if (sStyle.Trim() == "")
					{
						if (sLabelFileName.Contains("TLKW_CEL100"))
						{
							crCell.Cells.Value2 = "CELEBRATION 100";

						}
						else if (sLabelFileName.Contains("TLKW_CEL102"))
						{
							crCell.Cells.Value2 = "CELEBRATION 102";
						}
						if (sLabelFileName.Contains("TLKW_CELGRAND"))
							crCell.Cells.Value2 = "CELEBRATION";
						if (sLabelFileName.Contains("TLKW_ARCBRIL"))
							crCell.Cells.Value2 = "ARCTIC BRILLIANCE";
					}
					else
						crCell.Cells.Value2 = "";
				DateTime ddDate = System.DateTime.Now;
				

				foreach (DataRow dr in dsDocsValue.Tables[0].Rows)
                {
						if (dr["Title"].ToString().Trim().ToUpper() != "$CUTGRADEFAILCODE")
						{
							//if (dr["Title"].ToString().Trim().ToUpper().Contains("$BARCODE"))
							//{
							//	crCell = SheetData.get_Range("b1", Type.Missing);
							//	crCell.Cells.Value2 = @ConvertTo128(dr["Value"].ToString().Trim());
							//}

							//if (dr["Title"].ToString().Trim().ToUpper().Contains("$ITEMID"))
							//{
							//	SheetData.Shapes.Item("ItemNumber").TextFrame.Characters(Type.Missing, Type.Missing).Text = "GSI " + dr["Value"].ToString().Trim();
							//}
 
							//else
							{
								if (!dr["Title"].ToString().Contains("$"))
								{
									crCell = SheetData.get_Range(sTitleColumn + Convert.ToString(iBaseCellRow + i1), Type.Missing);
									crCell.Cells.Value2 = dr["Title"].ToString();

									crCell = SheetData.get_Range(sDataColumn + Convert.ToString(iBaseCellRow + i1), Type.Missing);
									crCell.Cells.Value2 = dr["Value"].ToString();

									if (sDataColumn == "c" && dr["Value"].ToString().Trim() != "") iFilledRowInFirstColumn++;

									i1++;
									if (i1 >= iMaxRows && sTitleColumn == "d") break;
									if (i1 >= iMaxRows)
									{
										i1 = 0;
										sTitleColumn = "d";
										sDataColumn = "e";
									}
								}
								else continue;
							}
							//try
							//{
							//	crCell = SheetData.get_Range("b1", Type.Missing);
							//	crCell.Cells.Value2 = @ConvertTo128(sOldNumber);
							//	SheetData.Shapes.Item("Style").TextFrame.Characters(Type.Missing, Type.Missing).Text = sStyle;
							//	SheetData.Shapes.Item("ItemNumber").TextFrame.Characters(Type.Missing, Type.Missing).Text = "GSI " + sFullOldNumber;
							//	SheetData.Shapes.Item("Date").TextFrame.Characters(Type.Missing, Type.Missing).Text = ddDate.Date.ToShortDateString();
							//}
							//catch (Exception ex)
							//{
							//	string msg = ex.Message.ToString();
							//}
						}
                    else
                    {
                        alCutGradeDetail = GetCutGradeFailGroupCodes(dr["Value"].ToString());
                    }
                }
					try
					{
						crCell = SheetData.get_Range("b1", Type.Missing);
						crCell.Cells.Value2 = @ConvertTo128(sOldNumber);
						SheetData.Shapes.Item("Style").TextFrame.Characters(Type.Missing, Type.Missing).Text = sStyle;
						SheetData.Shapes.Item("ItemNumber").TextFrame.Characters(Type.Missing, Type.Missing).Text = "GSI " + sFullOldNumber;
						SheetData.Shapes.Item("Date").TextFrame.Characters(Type.Missing, Type.Missing).Text = ddDate.Date.ToShortDateString();
					}
					catch (Exception ex)
					{
						string msg = ex.Message.ToString();
					}

					try
					{
						var drAdd = dsDocsValue.Tables[0].Select("Title like '%$BARCODE%'");
						if (drAdd.Length > 0)
						{
							try
							{
								var temp = drAdd[0]["Value"].ToString().Trim();
								Int64 code = Int64.Parse(temp);
							
								crCell = SheetData.get_Range("b1", Type.Missing);
								crCell.Cells.Value2 = @ConvertTo128(drAdd[0]["Value"].ToString().Trim());
							}
							catch
							{
								crCell = SheetData.get_Range("b1", Type.Missing);
								crCell.Cells.Value2 = "";
								SheetData.Shapes.Item("BarCode39").TextFrame.Characters(Type.Missing, Type.Missing).Text = "*" + drAdd[0]["Value"].ToString().Trim() + "*";
							}
							drAdd = null;
						}
						drAdd = dsDocsValue.Tables[0].Select("Title like '%$ITEMID%'");
						if (drAdd.Length > 0)
						{
							var temp = drAdd[0]["Value"].ToString().Trim();
							SheetData.Shapes.Item("ItemNumber").TextFrame.Characters(Type.Missing, Type.Missing).Text = drAdd[0]["Value"].ToString().Trim();
							drAdd = null;
						}
						drAdd = dsDocsValue.Tables[0].Select("Title like '%$COMMENTS%'");
						if (drAdd.Length > 0)
						{
							SheetData.Shapes.Item("Blemish").TextFrame.Characters(Type.Missing, Type.Missing).Text = drAdd[0]["Value"].ToString().Trim();
							drAdd = null;
						}

					}
					catch { }//dsDocsValue.Tables[0]

						//System.DateTime ddDate = System.DateTime.Now;
						//try
						//{
						//    crCell = SheetData.get_Range("b1", Type.Missing);
						//    crCell.Cells.Value2 = @ConvertTo128(sOldNumber);
						//    SheetData.Shapes.Item("Style").TextFrame.Characters(Type.Missing, Type.Missing).Text = sStyle;
						//    SheetData.Shapes.Item("ItemNumber").TextFrame.Characters(Type.Missing, Type.Missing).Text = "GSI " + sFullOldNumber;
						//    SheetData.Shapes.Item("Date").TextFrame.Characters(Type.Missing, Type.Missing).Text = ddDate.Date.ToShortDateString();
						//}
						//catch (Exception ex)
						//{
						//    string msg = ex.Message.ToString();
						//}

						int iLastIndex;


                if (sComments.Trim().Length > 0)
                {
                    sComments = sComments.Trim();
                    crCell = SheetData.get_Range("b9", Type.Missing);
                    crCell.Cells.Value2 = "";
                        
                    //SheetData.Shapes.Item("Comments").TextFrame.Characters(Type.Missing, Type.Missing).Text = "";
                    iLastIndex = sComments.LastIndexOf('/');
                    if (iLastIndex == (sComments.Length - 1)) sComments = sComments.Substring(0, iLastIndex);
                    try
                    {
                        crCell = SheetData.get_Range("b9", Type.Missing);
                        crCell.Cells.Value2 = "*" + sComments;
                        //SheetData.Shapes.Item("Comments").TextFrame.Characters(Type.Missing, Type.Missing).Text = "*" + sComments;
                    }
                    catch { }
                }
					//Excel.Range ccCell = SheetData.get_Range("C2:C8", Type.Missing);
					sDataColumn = "c";

					//int iii = 1;
					//int n = 0;
					try
					{
						//while (iii < iMaxRows)
						//{
						//	crCell = SheetData.get_Range(sDataColumn + Convert.ToString(iii + 1), Type.Missing);
						//	iii++;
						//	if (crCell.Cells.Value2.Trim() != "")
						//	{
						//		//var cc = crCell.Cells.Value2.Trim();
						//		//var a = crCell.Cells.Text.Trim();
						//		n++;
						//	}
						//	else break;
						//}
						if (iFilledRowInFirstColumn < 5)
						{
							SheetData.get_Range("A2", SheetData.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing)).Font.Size = 14;
							SheetData.Shapes.Item("Divider").Delete();
						}
					}
					catch { }
					bool bTwoPages = false;
                SheetToPrint.Add(SheetData);

                if (alCutGradeDetail.Count > 0)
                {
                    bTwoPages = true;
                    crCell = SheetData.get_Range("d9", Type.Missing);
                    crCell.Cells.Value2 = "See Comments on 2nd Label";

                    try
                    {
                        //                        if(sOldNumber.Length > 10)
                        //                        {
                        //                            SheetData1.Shapes.Item("BarCode39").TextFrame.Characters(Type.Missing, Type.Missing).Text = "*" + sOldNumber + "*";
                        //                        }
                        //                        else 
                        crCell = SheetData1.get_Range("b1", Type.Missing);
                        crCell.Cells.Value2 = @ConvertTo128(sOldNumber);
                        //SheetData1.Shapes.Item("BarCode").TextFrame.Characters(Type.Missing, Type.Missing).Text = @ConvertTo128(sOldNumber);
                        SheetData1.Shapes.Item("ItemNumber").TextFrame.Characters(Type.Missing, Type.Missing).Text = "GSI " + sFullOldNumber;
                        SheetData1.Shapes.Item("Date").TextFrame.Characters(Type.Missing, Type.Missing).Text = ddDate.Date.ToShortDateString();

                        //SheetData.Shapes.Item("Comments2").TextFrame.Characters(Type.Missing, Type.Missing).Text = "See Comments on 2nd Label";
                    }
                    catch { }

                    i1 = 0;
                    sDataColumn = "c";
                    iBaseCellRow = 3;
                    foreach (object oLine in alCutGradeDetail)
                    {
                        crCell = SheetData1.get_Range(sDataColumn + Convert.ToString(iBaseCellRow + i1), Type.Missing);
                        crCell.Cells.Value2 = oLine.ToString();
                        i1++;
                    }
                    SheetToPrint.Add(SheetData1);
                }
                int m = 1;
                string myFile = "";
 					foreach (Excel.Worksheet mySheet in SheetToPrint)
					{
						if (Client.ViewReport)
						{
							objExcel.Application.Visible = true;
							objExcel.WindowState = Excel.XlWindowState.xlMaximized;
							mySheet.PrintPreview(Type.Missing); //, Type.Missing, 1, true, Type.Missing,/*sPrinterName,*/ Type.Missing, true, Type.Missing);
							objExcel.Application.Visible = false;
							objExcel.WindowState = Excel.XlWindowState.xlMinimized;
							Client.ViewReport = false;
							break;
						}
						else
						{
#if DEBUG
							myFile = @"C:\DELL\" + Service.FillToFiveChars(sGroupCode) + "." + Service.FillToThreeChars(sBatchCode) + "." + Service.FillToTwoChars(sItemCode) + "_" + m.ToString() + ".xls";
							mySheet.SaveAs(myFile, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
							m++;
#else
                    mySheet.PrintOut(1, 1, 1,false, sPrinterName,Type.Missing,true,Type.Missing);
#endif
						}
					}
					
                //Excel.Worksheet SheetLabel = (Excel.Worksheet)BookTemp.Sheets[1];
                //                SheetData.PrintOut(1, 1, 1,false, sPrinterName,Type.Missing,true,Type.Missing);
                //                
                //                //Excel.Worksheet SheetLabel1 = (Excel.Worksheet)BookTemp.Sheets[2];
                //                
                //                if(bTwoPages)
                //                {
                //                    SheetData1.PrintOut(1, 1, 1,false,sPrinterName,Type.Missing,true,Type.Missing);
                //                }

                ////                NAR(crCell);
                ////                NAR(SheetData);
                ////                NAR(SheetData1);
                ////                NAR(SheetLabel);
                ////                NAR(SheetLabel1);

                ////                crCell = null;
                ////                SheetLabel = null;
                ////                SheetLabel1 = null;
                ////                SheetData = null;
                ////                SheetData1 = null;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                if (msg == "file not found")
                {
                    throw new Exception("The system cannot find the file: " + sReportPath);
                }
            }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                MessageBox.Show("Item # " + sNewNumber + ", Missing data:" + "\n" + msg);
                return;
            }
            finally
            {

                ////                try
                ////                {
                ////                    BookData.Close(false,sReportPath,null);
                                   ////BookTemp.Close(false,sReportPath,null);
                ////                }
                ////                catch(Exception ex)
                ////                {}
                ////                try
                ////                {
                ////                    //objExcel.Quit();
                ////					
                ////                    NAR(BookTemp);
                ////                    NAR(BookData);
                ////                    //NAR(objExcel);
                ////
                ////                    BookTemp=null;
                ////                    BookData=null;
                ////                    //objExcel=null;
                ////
                ////                    /*
                ////                                        GC.Collect();
                ////                                        GC.WaitForPendingFinalizers(); 
                ////                                        GC.Collect();*/
                ////                }
                ////                catch(Exception ex)
                ////                {}
                ////                try
                ////                {
                ////                    if(File.Exists(fnTemp))
                ////                        File.Delete(fnTemp);//delete temp file
                ////                }
                ////                catch(Exception ex)
                ////                {}
                SheetToPrint.Clear();
            }
            #endregion
            //crDocument.SetDataSource(dsCrystalSet);

        }

        private ArrayList GetCutGradeFailGroupCodes(string sCutGradeFailCode)
        {
            ArrayList alCodeDescription = new ArrayList();
            int y = 10;
            int i = 0;
            int iRemainder;
            int iMyCutGradeCode;// = Convert.ToInt16(sCutGradeFailCode);

            try
            {
                iMyCutGradeCode = Convert.ToInt16(sCutGradeFailCode);
                if (iMyCutGradeCode > 0)
                {
                    for (; iMyCutGradeCode > 0; )
                    {
                        i++;
                        iRemainder = iMyCutGradeCode % y;
                        iMyCutGradeCode = iMyCutGradeCode / y;
                        if (iRemainder != 0)
                            alCodeDescription.Add("NOT IDEAL " + Convert.ToString(i));
                    }
                }
            }
            catch { }

            return alCodeDescription;
        }

        public void Excel_Front_TakeIn_Label(string sID)
        {
            //string sReportPath=sReportsDir+@"front_takeIn_label.rpt";
            //string sReportPath=sReportsDir+@"front_takeIn_label.xls"; old part
            string sReportName = "Front_TakeIn_Label.xls";

            string sReportPath = Client.GetOfficeDirPath("repDir") + sReportName; // New part 03/07/08
            int k = sReportName.ToUpper().IndexOf(".XLS");
            sPrinterName = GetPrinterName(sReportName.Substring(0, k));

            string sTemp = "";
            sTemp = Environment.GetEnvironmentVariable("TEMP");
            if (sTemp == "") sTemp = "c:";
            string fnTemp = sTemp + "\\front_takeIn_label" + sID + ".xls";

            //crDocument.Load(sReportPath);

            //by vetal_242 07.10.2006
            DataSet dsMemoNumber = Service.GetGroupMemoNumbers(sID.Split('_')[1]); //dbo.spGetGroupMemoNumber

            DataSet dsGroup = Service.GetCrystalSet(sID, "GroupWithCustomer");
            DataRow rGroup = dsGroup.Tables[0].Rows[0];
            DataSet dsServiceType = Service.GetCrystalSet(rGroup["ServiceTypeID"].ToString(), "ServiceType"); //dbo.spGetServiceType

            string sDelim = "_";
            char[] cDelim = sDelim.ToCharArray();
            string[] split = sID.Split(cDelim);
            string sBatchCode = FillToThreeChars(split[0]);
            string sGroupCode = rGroup["GroupCode"].ToString();

            sGroupCode = FillToFiveChars(sGroupCode);

            DataTable tblMeasure = Service.GetMeasureUnits();

            string sDate = dsGroup.Tables[0].Rows[0]["CreateDate"].ToString();
            System.DateTime ddDate = System.DateTime.Parse(sDate);

            #region Open Excel
            //Excel.Application objExcel = null ;
            Excel.Workbook BookData = null;
            //Excel.Workbook BookTemp = null;
            try
            {
                if (objExcel == null)
                    objExcel = new Excel.Application();
                try
                {
                    BookData = objExcel.Workbooks.Open(sReportPath, Type.Missing, true, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                }
                catch (Exception ex)
                {
                    throw new Exception("file not found");
                }

                //BookData.SaveCopyAs(fnTemp);
                //BookData.Close(false, sReportPath, null);
                //make local copy

                //BookTemp = objExcel.Workbooks.Open(fnTemp, Type.Missing, false, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                Excel.Worksheet SheetData = (Excel.Worksheet)BookData.Sheets[2];
                Excel.Worksheet SheetData0 = (Excel.Worksheet)BookData.Sheets[1];

				Excel.Range crCell = null;

                /*		
                CrystalDecisions.CrystalReports.Engine.TextObject crText;
                crText=crDocument.ReportDefinition.ReportObjects["text1"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                crText.Text= */
                var ServiceType = rGroup["ServiceTypeID"];
                var ServiceName = dsServiceType.Tables[0].Rows[0]["ServiceTypeName"];
				int ServiceTypeID = Convert.ToInt16(ServiceType);

				if (ServiceTypeID == 7 || ServiceTypeID == 8 || ServiceTypeID == 9)
						SheetData0.Shapes.Item("Text Box 58").TextFrame.Characters(Type.Missing, Type.Missing).Text = "Service type " + ServiceName;
                else SheetData0.Shapes.Item("Text Box 58").TextFrame.Characters(Type.Missing, Type.Missing).Text = "Special Instructions";
                
                crCell = SheetData.get_Range("b2", Type.Missing);
                crCell.Cells.Value2 = "*" + sGroupCode + "*"; //barcode


                /*crText=crDocument.ReportDefinition.ReportObjects["text2"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                crText.Text=sGroupCode; //barcode*/
                crCell = SheetData.get_Range("b3", Type.Missing);
                crCell.Cells.Value2 = sGroupCode; //barcode

				crCell = SheetData.get_Range("b4", Type.Missing);
				crCell.Cells.Value2 = "";

				/*crText=crDocument.ReportDefinition.ReportObjects["text4"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                crText.Text=ddDate.Date.ToShortDateString();*/
				crCell = SheetData.get_Range("b5", Type.Missing);
                crCell.Cells.Value2 = ddDate.Date.ToShortDateString();//date

                //System.DateTime.Now.Date.ToShortDateString(); 
                /*crText=crDocument.ReportDefinition.ReportObjects["text5"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                crText.Text=ddDate.TimeOfDay.ToString();*/
                crCell = SheetData.get_Range("b6", Type.Missing);
                crCell.Cells.Value2 = ddDate.TimeOfDay.ToString();// time

				crCell = SheetData.get_Range("b7", Type.Missing);
				crCell.Cells.Value2 = "";

				//System.DateTime.Now.ToShortTimeString();

				/*crText=crDocument.ReportDefinition.ReportObjects["text7"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                crText.Text=rGroup["ExtPhone"].ToString(); //ext. phone*/
				crCell = SheetData.get_Range("b8", Type.Missing);
                crCell.Cells.Value2 = rGroup["ExtPhone"].ToString(); //ext. phone

                /*crText=crDocument.ReportDefinition.ReportObjects["text8"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                crText.Text=rGroup["CustomerName"].ToString();  //"Customer";*/
                crCell = SheetData.get_Range("b9", Type.Missing);
                crCell.Cells.Value2 = rGroup["CustomerName"].ToString();  //"Customer";

                crCell = SheetData.get_Range("b36", Type.Missing);
                crCell.Cells.Value2 = (rGroup["Memo"].ToString().Trim() != "" ? "Main Memo" : "");

                crCell = SheetData.get_Range("b37", Type.Missing);
				var mainMemo = (rGroup["Memo"].ToString().Trim() != "" ? rGroup["Memo"].ToString().Trim() : "");
				crCell.Cells.Value2 = mainMemo; // (rGroup["Memo"].ToString().Trim() != "" ? rGroup["Memo"].ToString().Trim() : "");


                /*crText=crDocument.ReportDefinition.ReportObjects["text20"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                crText.Text="00.00.0000"; // due date*/
                crCell = SheetData.get_Range("b16", Type.Missing);
                crCell.Cells.Value2 = ""; // due date

                /*crText=crDocument.ReportDefinition.ReportObjects["text19"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                crText.Text="00:00"; // due time*/
                crCell = SheetData.get_Range("b15", Type.Missing);
                crCell.Cells.Value2 = ""; // due time

                crCell = SheetData.get_Range("b38", Type.Missing);
                crCell.Cells.Value2 = rGroup["SpecialInstruction"].ToString();

                #region Weight
                string sWeight = "";
                string sInspWeightWord = "";
                bool isWeight = false;

                if (rGroup["InspectedTotalWeight"] != DBNull.Value)
                {
                    isWeight = true;
                    sInspWeightWord = "inspected";
                    sWeight = rGroup["InspectedTotalWeight"].ToString() + " ";
                    if (sWeight.Trim() != "0" && rGroup["InspectedWeightUnitID"] != DBNull.Value)
                    {
                        DataRow[] rMeasureName = tblMeasure.Select("MeasureUnitID=" + rGroup["InspectedWeightUnitID"].ToString());
                        sWeight += rMeasureName[0]["MeasureUnitName"].ToString();
                    }

                }
                if (rGroup["NotInspectedTotalWeight"] != DBNull.Value)
                {
                    isWeight = true;
                    sInspWeightWord = "not inspected";
                    sWeight = rGroup["NotInspectedTotalWeight"].ToString() + " ";
                    if (sWeight.Trim() != "0" && rGroup["InspectedWeightUnitID"] != DBNull.Value)
                    {
                        DataRow[] rMeasureName = tblMeasure.Select("MeasureUnitID=" + rGroup["NotInspectedWeightUnitID"].ToString());
                        sWeight += rMeasureName[0]["MeasureUnitName"].ToString();
                    }
                }
                #endregion

                #region Quantity
                string sQuantity = "";
                string sInspQuantWord = "";
                bool isQuantity = false;

                if (rGroup["InspectedQuantity"] != DBNull.Value)
                {
                    isQuantity = true;
                    sInspQuantWord = "inspected";
                    sQuantity = rGroup["InspectedQuantity"].ToString();

                }
                if (rGroup["NotInspectedQuantity"] != DBNull.Value)
                {
                    isQuantity = true;
                    sInspQuantWord = "not inspected";
                    sQuantity = rGroup["NotInspectedQuantity"].ToString();
                }
                #endregion

                if (isQuantity)
                {
                    /*crText=crDocument.ReportDefinition.ReportObjects["text10"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                    crText.Text=sQuantity; // quantity number*/
                    crCell = SheetData.get_Range("b11", Type.Missing);
                    crCell.Cells.Value2 = sQuantity; // quantity number

                    /*crText=crDocument.ReportDefinition.ReportObjects["text21"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                    crText.Text= sInspQuantWord; // quantity "insp" word*/
                    crCell = SheetData.get_Range("b17", Type.Missing);
                    crCell.Cells.Value2 = sInspQuantWord; // quantity "insp" word

                }
                else
                {
                    /*crText=crDocument.ReportDefinition.ReportObjects["text10"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                    crText.Text=""; // quantity number*/
                    crCell = SheetData.get_Range("b11", Type.Missing);
                    crCell.Cells.Value2 = ""; // quantity number

                    /*crText=crDocument.ReportDefinition.ReportObjects["text21"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                    crText.Text=""; // quantity "insp" word*/
                    crCell = SheetData.get_Range("b17", Type.Missing);
                    crCell.Cells.Value2 = ""; // quantity "insp" word

                    /*crText=crDocument.ReportDefinition.ReportObjects["text9"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                    crText.Text=""; // "number of items" word*/
                    crCell = SheetData.get_Range("b10", Type.Missing);
                    crCell.Cells.Value2 = ""; // "number of items" word

                }

                if (isWeight && sWeight.Trim() != "0")
                {
                    /*crText=crDocument.ReportDefinition.ReportObjects["text12"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                    crText.Text=sWeight; // weight number*/
                    crCell = SheetData.get_Range("b13", Type.Missing);
                    crCell.Cells.Value2 = sWeight; // weight number

                    /*crText=crDocument.ReportDefinition.ReportObjects["text22"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                    crText.Text=sInspWeightWord; // weight "insp" word*/
                    crCell = SheetData.get_Range("b18", Type.Missing);
                    crCell.Cells.Value2 = sInspWeightWord; // weight "insp" word

                }
                else
                {
                    /*crText=crDocument.ReportDefinition.ReportObjects["text12"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                    crText.Text=""; // weight number*/
                    crCell = SheetData.get_Range("b13", Type.Missing);
                    crCell.Cells.Value2 = ""; // weight number

                    /*crText=crDocument.ReportDefinition.ReportObjects["text22"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                    crText.Text=""; // weight "insp" word*/
                    crCell = SheetData.get_Range("b18", Type.Missing);
                    crCell.Cells.Value2 = "Not Inspected"; // weight "insp" word

                    /*crText=crDocument.ReportDefinition.ReportObjects["text11"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                    crText.Text=""; // "total weight" word*/
                    //					crCell = SheetData.get_Range("b12",Type.Missing);
                    //					crCell.Cells.Value2 = ""; // "total weight" word

                }

                //by vetal_242 07.10.2006
                //print group memoNumbers
                if (dsMemoNumber.Tables[0].Rows.Count > 1)
                {
                    for (int i = 0; i < System.Math.Min(15, dsMemoNumber.Tables[0].Rows.Count); i++)
                    {
                        //int index = 30 + i;
                        int index = 19 + i;
                        /*crText=crDocument.ReportDefinition.ReportObjects["text" + index.ToString()] as CrystalDecisions.CrystalReports.Engine.TextObject;
                        crText.Text=dsMemoNumber.Tables[0].Rows[i]["Name"].ToString();*/
                        string sIndex = "b" + index.ToString();
						if (mainMemo.Trim().ToUpper() != dsMemoNumber.Tables[0].Rows[i]["Name"].ToString().Trim().ToUpper())
						{
							crCell = SheetData.get_Range(sIndex, Type.Missing);
							crCell.Cells.Value2 = dsMemoNumber.Tables[0].Rows[i]["Name"].ToString();
						}
						else crCell.Cells.Value2 = "";
					}
                }
                Excel.Worksheet SheetLabel = (Excel.Worksheet)BookData.Sheets[1];
                SheetLabel.PrintOut(Type.Missing, Type.Missing, 1, false, sPrinterName, Type.Missing, true, Type.Missing);

                NAR(crCell);
                NAR(SheetData);
                NAR(SheetLabel);
                crCell = null;
                SheetLabel = null;
                SheetData = null;
            }
            #region Close Excel
            catch (Exception ex)
            {
                string msg = ex.Message;
                if (msg == "file not found")
                {
                    throw new Exception("The system cannot find the file: " + sReportPath);
                }
            }
            finally
            {
                try
                {
                    BookTemp.Close(false, fnTemp, null);
                    //BookTemp.Close(true,fnTemp,null);//save for test
                }
                catch (Exception ex)
                { }
                try
                { BookData.Close(false, sReportPath, null); }
                catch (Exception ex)
                { }
                try
                {
                    //objExcel.Quit();

                    NAR(BookTemp);
                    NAR(BookData);
                    //NAR(objExcel);

                    BookTemp = null;
                    BookData = null;
                    //objExcel=null;

                    /*
                                        GC.Collect();
                                        GC.WaitForPendingFinalizers(); 
                                        GC.Collect();*/
                }
                catch (Exception ex)
                { }
                try
                {
                    if (File.Exists(fnTemp))
                        File.Delete(fnTemp);//delete temp file
                }
                catch { }
            }
            #endregion
            #endregion

        }

        public void PDF_Front_TakeIn(string sGroupID, TakeInType type, int CopyOfReport)
        {
            string sReceiptFileName = Client.GetOfficeDirPath("frontReceiptFile").ToUpper(); //New part from 01/27/09
            string sReportPath = Client.GetOfficeDirPath("repDir") + sReceiptFileName;
            sReceiptFileName = sReceiptFileName.Replace("XLS", "PDF");
#if DEBUG
            sReceiptFileName = @"C:\DELL\Front_TakeIn_External_Receipt1.pdf";
#endif
            sPrinterName = GetPrinterName("Front_TakeIn");
            DataSet dsMemoNumbers = Service.GetGroupMemoNumbers(sGroupID.Split('_')[1]);

            DataSet dsGroup = Service.GetCrystalSet(sGroupID, "GroupWithCustomer");

            DataSet dsAuthor = gemoDream.Service.GetCrystalSet(sGroupID, "GroupAuthor");

            DataRow rGroup = dsGroup.Tables[0].Rows[0];

            string sDelim = "_";
            char[] cDelim = sDelim.ToCharArray();
            string[] split = sGroupID.Split(cDelim);
            string sBatchCode = FillToThreeChars(split[0]);
            string sGroupCode = rGroup["GroupCode"].ToString();

            sGroupCode = FillToFiveChars(sGroupCode);
            DataTable tblMeasure = Service.GetMeasureUnits();

            string sDate = dsGroup.Tables[0].Rows[0]["CreateDate"].ToString();
            System.DateTime ddDate = System.DateTime.Parse(sDate);

            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(sReceiptFileName);

            //DateTime myDate = DateTime.Now;
            var format = @"MM\/dd\/yyyy HH:mm tt";
            string sMyDate = ddDate.ToString(format);
                        
            PdfFormWidget formWidget = doc.Form as PdfFormWidget;
            var campoText = null as PdfTextBoxFieldWidget;
            PdfFormFieldWidgetCollection myCollection = formWidget.FieldsWidget;

            string sCustomerData = rGroup["CustomerName"].ToString() + "\n";
            sCustomerData = sCustomerData + rGroup["Address1"].ToString() + " " + rGroup["Address2"].ToString() + "\n";
            sCustomerData = sCustomerData + rGroup["City"].ToString() + "," + rGroup["USStateName"].ToString() + "," + rGroup["Country"] + ", ";
            sCustomerData = sCustomerData + FillToFiveChars(rGroup["Zip1"].ToString()) + (rGroup["Zip2"].ToString().Trim() != "" ? ("-" + rGroup["Zip2"].ToString()) : "") + "\n";
            sCustomerData = sCustomerData + rGroup["CountryPhoneCode"].ToString() + " " + rGroup["Phone"].ToString() + "\n";
            sCustomerData = sCustomerData + rGroup["CountryFaxCode"].ToString() + " " + rGroup["Fax"].ToString();
            
            #region Weight
            string sWeight = "";
            string sInspWeightWord = "";
            bool isWeight = false;

            if (rGroup["InspectedTotalWeight"] != DBNull.Value)
            {
                try
                {
                    isWeight = true;
                    sInspWeightWord = "inspected";
                    sWeight = rGroup["InspectedTotalWeight"].ToString() + " ";
                    DataRow[] rMeasureName = tblMeasure.Select("MeasureUnitID= " + rGroup["InspectedWeightUnitID"]);
                    sWeight += rMeasureName[0]["MeasureUnitName"].ToString();
                }
                catch (Exception ex) { }
            }
            if (rGroup["NotInspectedTotalWeight"] != DBNull.Value)
            {
                try
                {
                    isWeight = true;
                    sInspWeightWord = "not inspected";
                    sWeight = rGroup["NotInspectedTotalWeight"].ToString() + " ";
                    DataRow[] rMeasureName = tblMeasure.Select("MeasureUnitID= " + rGroup["NotInspectedWeightUnitID"]);
                    sWeight += rMeasureName[0]["MeasureUnitName"].ToString();
                }
                catch (Exception ex) { }
            }

            #endregion

            #region Quantity
            string sQuantity = "";
            string sInspQuantWord = "";
            bool isQuantity = false;

            if (rGroup["InspectedQuantity"] != DBNull.Value)
            {
                try
                {
                    isQuantity = true;
                    sInspQuantWord = "(inspected)";
                    sQuantity = rGroup["InspectedQuantity"].ToString();
                }
                catch (Exception ex) { }

            }
            if (rGroup["NotInspectedQuantity"] != DBNull.Value)
            {
                try
                {
                    isQuantity = true;
                    sInspQuantWord = "(not inspected)";
                    sQuantity = rGroup["NotInspectedQuantity"].ToString();
                }
                catch (Exception ex) { }
            }
           #endregion
            
            try
            {
                DrawBarCode39_Field(sGroupCode, ref doc);

                campoText = formWidget.FieldsWidget["Date"] as PdfTextBoxFieldWidget;
                campoText.Text = sMyDate;

                campoText = formWidget.FieldsWidget["Order"] as PdfTextBoxFieldWidget;
                campoText.Text = sGroupCode;

                campoText = formWidget.FieldsWidget["Memo"] as PdfTextBoxFieldWidget;
                if (rGroup["Memo"].ToString().Trim() != "") campoText.Text = "Main Memo" + " " + rGroup["Memo"].ToString().Trim();
                else campoText.Text = "";

                campoText = formWidget.FieldsWidget["SpecialInstructions"] as PdfTextBoxFieldWidget;
                var campoText1 = formWidget.FieldsWidget["SpInstrTitle"] as PdfTextBoxFieldWidget;
                if (rGroup["SpecialInstruction"].ToString() != "")
                {
                    campoText.Text = rGroup["SpecialInstruction"].ToString();
                    campoText1.Text = "Special Instructions:";
                }
                else
                {
                    campoText.Text = "";
                    campoText1.Text = "";
                }

                campoText = formWidget.FieldsWidget["Customer"] as PdfTextBoxFieldWidget;
                campoText.Text = sCustomerData;

                campoText = formWidget.FieldsWidget["AcceptedBy_In"] as PdfTextBoxFieldWidget;
                campoText.Text = dsAuthor.Tables[0].Rows[0]["FirstName"].ToString() + " " + dsAuthor.Tables[0].Rows[0]["LastName"];

                //campoText = formWidget.FieldsWidget["Customer"] as PdfTextBoxFieldWidget;
                //campoText.Text = sCustomerData;

                //campoText = formWidget.FieldsWidget["Customer"] as PdfTextBoxFieldWidget;
                //campoText.Text = sCustomerData;

                //campoText = formWidget.FieldsWidget["Customer"] as PdfTextBoxFieldWidget;
                //campoText.Text = sCustomerData;

                switch (type)
                {
                    case TakeInType.TakeIn:
                        {
                            string sPersonID = dsGroup.Tables[0].Rows[0]["PersonID"].ToString();
                            string sPersonCustomerID = dsGroup.Tables[0].Rows[0]["PersonCustomerID"].ToString();
                            string sPersonCustomerOfficeID = dsGroup.Tables[0].Rows[0]["PersonCustomerOfficeID"].ToString();
                           
                            if (sPersonID == "")
                                sPersonID = null;
                            if (sPersonCustomerID == "")
                                sPersonCustomerID = null;
                            if (sPersonCustomerOfficeID == "")
                                sPersonCustomerOfficeID = null;
                            DataSet dsMess = gemoDream.Service.GetPerson(sPersonID, sPersonCustomerID,
                                sPersonCustomerOfficeID);

                            campoText = formWidget.FieldsWidget["SubmittedBy_In"] as PdfTextBoxFieldWidget;
                            if (dsMess.Tables[0].Rows.Count > 0)
                            {
                                campoText.Text = dsMess.Tables[0].Rows[0]["FirstName"].ToString() + " " + dsMess.Tables[0].Rows[0]["LastName"].ToString();
                            }
                            else campoText.Text = "";
                            campoText = formWidget.FieldsWidget["Messenger"] as PdfTextBoxFieldWidget;
                            campoText.Text = "";

                            campoText = formWidget.FieldsWidget["Carrier"] as PdfTextBoxFieldWidget;
                            campoText.Text = "";

                            campoText = formWidget.FieldsWidget["Tracking"] as PdfTextBoxFieldWidget;
                            campoText.Text = "";

                            campoText = formWidget.FieldsWidget["SubmittedBy"] as PdfTextBoxFieldWidget;
                            campoText.Text = "Submitted By:";
                            break;
                        }

                    case TakeInType.TakeInPickedUpByOurMessenger:
                        {
                            campoText = formWidget.FieldsWidget["Messenger"] as PdfTextBoxFieldWidget;
                            campoText.Text = "Picked Up By Our Messenger.";


                            break;
                        }

                    case TakeInType.ShipReceiving:
                        {
                            sGroupID = dsGroup.Tables[0].Rows[0]["GroupID"].ToString();
                            string sGroupOfficeID = dsGroup.Tables[0].Rows[0]["GroupOfficeID"].ToString();
                            DataSet dsCarrier = gemoDream.Service.GetCarrier(sGroupOfficeID, sGroupID);
                            string sCarrierName = dsCarrier.Tables[0].Rows[0]["CarrierName"].ToString();
                            string sCarrierTrackingNumber = dsCarrier.Tables[0].Rows[0]["CarrierTrackingNumber"].ToString();

                            campoText = formWidget.FieldsWidget["Carrier"] as PdfTextBoxFieldWidget;
                            campoText.Text = "Received via " + sCarrierName;

                            campoText = formWidget.FieldsWidget["Tracking"] as PdfTextBoxFieldWidget;
                            campoText.Text = "with " + sCarrierName + " tracking number " + sCarrierTrackingNumber; 
                            break;
                        }
                    case TakeInType.ShipReceivingPickedUpByOurMessenger:
                        {
                            campoText = formWidget.FieldsWidget["Messenger"] as PdfTextBoxFieldWidget;
                            campoText.Text = "Picked Up By Our Messenger.";
                            sGroupID = dsGroup.Tables[0].Rows[0]["GroupID"].ToString();
                            string sGroupOfficeID = dsGroup.Tables[0].Rows[0]["GroupOfficeID"].ToString();

                            DataSet dsCarrier = gemoDream.Service.GetCarrier(sGroupOfficeID, sGroupID);
                            string sCarrierName = dsCarrier.Tables[0].Rows[0]["CarrierName"].ToString();
                            string sCarrierTrackingNumber = dsCarrier.Tables[0].Rows[0]["CarrierTrackingNumber"].ToString();

                            campoText = formWidget.FieldsWidget["Carrier"] as PdfTextBoxFieldWidget;
                            campoText.Text = "Received via " + sCarrierName;

                            campoText = formWidget.FieldsWidget["Tracking"] as PdfTextBoxFieldWidget;
                            campoText.Text = "with " + sCarrierName + " tracking number " + sCarrierTrackingNumber;
                            break;
                        }
                
                }

             }

            catch (Exception ex) { }
        }

        private void DrawBarCode39_Field(string myCode, ref PdfDocument myPDF)
        {
            float y = 180;
            float x = 20;
			PdfCode39ExtendedBarcode barcode39 = new PdfCode39ExtendedBarcode(myCode)
			{
				BarHeight = 30,
				NarrowBarWidth = 1
			};
			//float Height = barcode6.BarHeight;
			//float Width = barcode6.NarrowBarWidth;
			//barcode6.BarcodeToTextGapHeight = 1f;
			//barcode6.TextDisplayLocation = TextLocation.Bottom;
			barcode39.Draw(myPDF.Pages[0], new PointF(x, y));
            //x = barcode39.Bounds.X;
            //y = barcode39.Bounds.Y;
        }

        public void Excel_Front_TakeIn(string sGroupID, TakeInType type, int CopyOfReport)
        {
            //string sReportPath=sReportsDir+@"Front_TakeIn_External_Receipt.rpt";
            //string sReportPath=sReportsDir+@"front_takeIn_label.xls"; old part
            string sReceiptFileName = Client.GetOfficeDirPath("frontReceiptFile"); //New part from 01/27/09
            string sReportPath = Client.GetOfficeDirPath("repDir") + sReceiptFileName; //New part from 01/27/09
            //string sReportPath = Client.GetOfficeDirPath("repDir") + @"Front_TakeIn_External_Receipt.xls"; old part 03/07/08

            string sTemp = "";
            sTemp = Environment.GetEnvironmentVariable("TEMP");
            if (sTemp == "") sTemp = "c:";
            string fnTemp = @"" + sTemp + "\\Front_TakeIn_External_Receipt" + sGroupID + ".xls";

            sPrinterName = GetPrinterName("Front_TakeIn");
            //crDocument.Load(sReportPath);

            DataSet dsMemoNumbers = Service.GetGroupMemoNumbers(sGroupID.Split('_')[1]);

            DataSet dsGroup = Service.GetCrystalSet(sGroupID, "GroupWithCustomer");

            DataRow rGroup = dsGroup.Tables[0].Rows[0];

            //debug_DataSet(dsGroup);
            //gemoDream.Service.debug_DiaspalyDataSet(dsGroup);

            string sDelim = "_";
            char[] cDelim = sDelim.ToCharArray();
            string[] split = sGroupID.Split(cDelim);
            string sBatchCode = FillToThreeChars(split[0]);
            string sGroupCode = rGroup["GroupCode"].ToString();

            sGroupCode = FillToFiveChars(sGroupCode);
            DataTable tblMeasure = Service.GetMeasureUnits();

            string sDate = dsGroup.Tables[0].Rows[0]["CreateDate"].ToString();
            System.DateTime ddDate = System.DateTime.Parse(sDate);
            //**************************************
            #region Open Excel
            //Excel.Application objExcel = null ;
            Excel.Workbook BookData = null;
            Excel.Workbook BookTemp = null;
            try
            {
                if (objExcel == null)
                    objExcel = new Excel.Application();
                try
                {
                    BookData = objExcel.Workbooks.Open(sReportPath, Type.Missing, true, Type.Missing, 
																	Type.Missing, Type.Missing, Type.Missing, 
																	Type.Missing, Type.Missing, Type.Missing, 
																	Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                }
                catch (Exception ex)
                {
                    throw new Exception("file not found");
                }
				//try
				//{

				//	BookData.SaveCopyAs(fnTemp);
				//	BookData.Close(false, sReportPath, null);
				//}
				//catch (Exception ex)
				//{
				//	var a = ex.Message;
				//}
				//make local copy

				//BookTemp = objExcel.Workbooks.Open(fnTemp, Type.Missing, false, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
				//Excel.Worksheet SheetData = (Excel.Worksheet)BookTemp.Sheets[2];
				//Excel.Worksheet MainPage = (Excel.Worksheet)BookTemp.Sheets[1];
				Excel.Worksheet SheetData = (Excel.Worksheet)BookData.Sheets[2];
				Excel.Worksheet MainPage = (Excel.Worksheet)BookData.Sheets[1];

				Excel.Range crCell = null;
                //***********************************

                /*CrystalDecisions.CrystalReports.Engine.TextObject crText;
                crText=crDocument.ReportDefinition.ReportObjects["text12"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                crText.Text="*"+sGroupCode+"*"; //barcode*/
                crCell = SheetData.get_Range("b13", Type.Missing);
                crCell.Cells.Value2 = "*" + sGroupCode + "*"; //barcode

                /*crText=crDocument.ReportDefinition.ReportObjects["text13"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                crText.Text=sGroupCode; //barcode*/
                crCell = SheetData.get_Range("b14", Type.Missing);
                crCell.Cells.Value2 = sGroupCode + "_" + rGroup["OfficeCode"].ToString(); //barcode

                /*crText=crDocument.ReportDefinition.ReportObjects["text3"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                crText.Text=ddDate.Date.ToShortDateString();//System.DateTime.Now.Date.ToShortDateString(); //date*/
                crCell = SheetData.get_Range("b4", Type.Missing);
                crCell.Cells.Value2 = ddDate.Date.ToShortDateString();//date

                /*crText=crDocument.ReportDefinition.ReportObjects["text4"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                crText.Text=ddDate.TimeOfDay.ToString();//System.DateTime.Now.ToShortTimeString();// time*/
                crCell = SheetData.get_Range("b5", Type.Missing);
                crCell.Cells.Value2 = ddDate.TimeOfDay.ToString();// time

                /*crText=crDocument.ReportDefinition.ReportObjects["text14"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                crText.Text=rGroup["CustomerName"].ToString();  //"Customer";*/
                crCell = SheetData.get_Range("b15", Type.Missing);
                crCell.Cells.Value2 = rGroup["CustomerName"].ToString();  //"Customer";



                #region Weight
                string sWeight = "";
                string sInspWeightWord = "";
                bool isWeight = false;

                if (rGroup["InspectedTotalWeight"] != DBNull.Value)
                {
                    try
                    {
                        isWeight = true;
                        sInspWeightWord = "inspected";
                        sWeight = rGroup["InspectedTotalWeight"].ToString() + " ";
                        DataRow[] rMeasureName = tblMeasure.Select("MeasureUnitID= " + rGroup["InspectedWeightUnitID"]);
                        sWeight += rMeasureName[0]["MeasureUnitName"].ToString();
                    }
                    catch { }
                }
                if (rGroup["NotInspectedTotalWeight"] != DBNull.Value)
                {
                    try
                    {
                        isWeight = true;
                        sInspWeightWord = "not inspected";
                        sWeight = rGroup["NotInspectedTotalWeight"].ToString() + " ";
                        DataRow[] rMeasureName = tblMeasure.Select("MeasureUnitID= " + rGroup["NotInspectedWeightUnitID"]);
                        sWeight += rMeasureName[0]["MeasureUnitName"].ToString();
                    }
                    catch { }
                }
                #endregion

                #region Quantity
                string sQuantity = "";
                string sInspQuantWord = "";
                bool isQuantity = false;

                if (rGroup["InspectedQuantity"] != DBNull.Value)
                {
                    try
                    {
                        isQuantity = true;
                        sInspQuantWord = "inspected";
                        sQuantity = rGroup["InspectedQuantity"].ToString();
                    }
                    catch { }

                }
                if (rGroup["NotInspectedQuantity"] != DBNull.Value)
                {
                    try
                    {
                        isQuantity = true;
                        sInspQuantWord = "not inspected";
                        sQuantity = rGroup["NotInspectedQuantity"].ToString();
                    }
                    catch { }
                }
                #endregion

                #region Fill weight&quantity
                if (isQuantity)
                {
                    /*crText=crDocument.ReportDefinition.ReportObjects["text6"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                    crText.Text=sQuantity; // quantity number*/
                    crCell = SheetData.get_Range("b7", Type.Missing);
                    crCell.Cells.Value2 = sQuantity; // quantity number

                    /*crText=crDocument.ReportDefinition.ReportObjects["text5"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                    crText.Text="Number of items ("+sInspQuantWord+")"; // quantity "insp" word*/
                    crCell = SheetData.get_Range("b6", Type.Missing);
                    crCell.Cells.Value2 = "Number of items (" + sInspQuantWord + ")"; // quantity "insp" word
                }
                else
                {
                    /*crText=crDocument.ReportDefinition.ReportObjects["text5"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                    crText.Text=" "; // quantity number*/
                    crCell = SheetData.get_Range("b6", Type.Missing);
                    crCell.Cells.Value2 = " "; // quantity number

                    /*crText=crDocument.ReportDefinition.ReportObjects["text6"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                    crText.Text=" "; // quantity "insp" word*/
                    crCell = SheetData.get_Range("b7", Type.Missing);
                    crCell.Cells.Value2 = " "; // quantity "insp" word
                }

                if (isWeight)
                {
                    /*crText=crDocument.ReportDefinition.ReportObjects["text8"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                    crText.Text=sWeight; // weight number*/
                    crCell = SheetData.get_Range("b9", Type.Missing);
                    crCell.Cells.Value2 = sWeight; // weight number

                    /*crText=crDocument.ReportDefinition.ReportObjects["text7"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                    crText.Text="Total weight ("+sInspWeightWord+")"; // weight "insp" word*/
                    crCell = SheetData.get_Range("b8", Type.Missing);
                    crCell.Cells.Value2 = "Total weight (" + sInspWeightWord + ")"; // weight "insp" word
                }
                else
                {
                    /*crText=crDocument.ReportDefinition.ReportObjects["text8"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                    crText.Text=" "; // weight number*/
                    crCell = SheetData.get_Range("b9", Type.Missing);
                    crCell.Cells.Value2 = " "; // weight number

                    /*crText=crDocument.ReportDefinition.ReportObjects["text7"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                    crText.Text=" "; // weight "insp" word*/
                    crCell = SheetData.get_Range("b8", Type.Missing);
                    crCell.Cells.Value2 = " "; // weight "insp" word
                }
                #endregion

                #region Picked up by our messenger
                /*
				bool IsPickedUp = true;
				if (IsPickedUp)
				{
					crText=crDocument.ReportDefinition.ReportObjects["text39"] as CrystalDecisions.CrystalReports.Engine.TextObject;
					crText.Text="cool!";
				}
				else
				{
					crText=crDocument.ReportDefinition.ReportObjects["text39"] as CrystalDecisions.CrystalReports.Engine.TextObject;
					crText.Text="cool!";
				}
				*/
                #endregion


                /*crText=crDocument.ReportDefinition.ReportObjects["text15"] as CrystalDecisions.CrystalReports.Engine.TextObject;
				crText.Text=rGroup["Address1"].ToString()+" "+rGroup["Address2"].ToString();  //"StreetName";*/
                crCell = SheetData.get_Range("b16", Type.Missing);
                crCell.Cells.Value2 = rGroup["Address1"].ToString() + " " + rGroup["Address2"].ToString();  //"StreetName";

                /*crText=crDocument.ReportDefinition.ReportObjects["text16"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                crText.Text=rGroup["City"].ToString()+","+rGroup["USStateName"].ToString() + "," + rGroup["Country"];  //"City, State";*/
                crCell = SheetData.get_Range("b17", Type.Missing);
                crCell.Cells.Value2 = rGroup["City"].ToString() + "," + rGroup["USStateName"].ToString() + "," + rGroup["Country"];  //"City, State";

                /*crText=crDocument.ReportDefinition.ReportObjects["text17"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                crText.Text=rGroup["Zip1"].ToString()+"-"+rGroup["Zip2"].ToString();  //"City, State";*/
                crCell = SheetData.get_Range("b18", Type.Missing);
                crCell.Cells.Value2 = FillToFiveChars(rGroup["Zip1"].ToString()) + (rGroup["Zip2"].ToString().Trim() != "" ? ("-" + rGroup["Zip2"].ToString()) : "");  //"City, State";

                /*crText=crDocument.ReportDefinition.ReportObjects["text18"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                crText.Text=rGroup["CountryPhoneCode"].ToString()+" "+rGroup["Phone"].ToString();*/
                crCell = SheetData.get_Range("b19", Type.Missing);
                crCell.Cells.Value2 = rGroup["CountryPhoneCode"].ToString() + " " + rGroup["Phone"].ToString();

                /*crText=crDocument.ReportDefinition.ReportObjects["text19"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                crText.Text=rGroup["CountryFaxCode"].ToString()+" "+rGroup["Fax"].ToString();*/
                crCell = SheetData.get_Range("b20", Type.Missing);
                crCell.Cells.Value2 = rGroup["CountryFaxCode"].ToString() + " " + rGroup["Fax"].ToString();

                crCell = SheetData.get_Range("b77", Type.Missing);
                crCell.Cells.Value2 = (rGroup["Memo"].ToString().Trim() != "" ? "Main Memo" : "");

                crCell = SheetData.get_Range("b78", Type.Missing);
                crCell.Cells.Value2 = (rGroup["Memo"].ToString().Trim() != "" ? rGroup["Memo"].ToString().Trim() : "");

                DataSet dsAuthor = gemoDream.Service.GetCrystalSet(sGroupID, "GroupAuthor");
                //				debug_DataSet(dsAuthor);

                switch (type)
                {
                    case TakeInType.TakeIn:
                        {
                            /*crText=crDocument.ReportDefinition.ReportObjects["text20"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                            crText.Text="";*/
                            crCell = SheetData.get_Range("b21", Type.Missing);
                            crCell.Cells.Value2 = " ";

                            /*crText=crDocument.ReportDefinition.ReportObjects["text21"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                            crText.Text=" ";*/
                            crCell = SheetData.get_Range("b22", Type.Missing);
                            crCell.Cells.Value2 = " ";

                            string sPersonID = dsGroup.Tables[0].Rows[0]["PersonID"].ToString();
                            string sPersonCustomerID = dsGroup.Tables[0].Rows[0]["PersonCustomerID"].ToString();
                            string sPersonCustomerOfficeID = dsGroup.Tables[0].Rows[0]["PersonCustomerOfficeID"].ToString();
                            //vetal_242 27.06.2006
                            //error conver string to int in database, when string = ""
                            if (sPersonID == "")
                                sPersonID = null;
                            if (sPersonCustomerID == "")
                                sPersonCustomerID = null;
                            if (sPersonCustomerOfficeID == "")
                                sPersonCustomerOfficeID = null;
                            DataSet dsMess = gemoDream.Service.GetPerson(sPersonID, sPersonCustomerID,
                                sPersonCustomerOfficeID);

                            string s1 = "";
                            string s2 = "";

                            if (dsMess.Tables[0].Rows.Count > 0)
                            {
                                s1 = dsMess.Tables[0].Rows[0]["FirstName"].ToString();
                                s2 = dsMess.Tables[0].Rows[0]["LastName"].ToString();
                            }

                            /*crText=crDocument.ReportDefinition.ReportObjects["text39"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                            crText.Text=s1 + " " + s2;*/
                            crCell = SheetData.get_Range("b40", Type.Missing);
                            crCell.Cells.Value2 = s1 + " " + s2;

                            /*crText=crDocument.ReportDefinition.ReportObjects["text41"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                            crText.Text="";*/
                            crCell = SheetData.get_Range("b42", Type.Missing);
                            crCell.Cells.Value2 = " ";

                            /*crText=crDocument.ReportDefinition.ReportObjects["text43"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                            crText.Text="";*/
                            crCell = SheetData.get_Range("b44", Type.Missing);
                            crCell.Cells.Value2 = " ";

                            /*crText=crDocument.ReportDefinition.ReportObjects["text44"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                            crText.Text="";*/
                            crCell = SheetData.get_Range("b45", Type.Missing);
                            crCell.Cells.Value2 = " ";
                            break;
                        }
                    case TakeInType.TakeInPickedUpByOurMessenger:
                        {
                            /*crText=crDocument.ReportDefinition.ReportObjects["text20"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                            crText.Text="";*/
                            crCell = SheetData.get_Range("b21", Type.Missing);
                            crCell.Cells.Value2 = " ";

                            /*crText=crDocument.ReportDefinition.ReportObjects["text21"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                            crText.Text="";*/
                            crCell = SheetData.get_Range("b22", Type.Missing);
                            crCell.Cells.Value2 = " ";

                            /*crText=crDocument.ReportDefinition.ReportObjects["text38"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                            crText.Text = "";*/
                            crCell = SheetData.get_Range("b39", Type.Missing);
                            crCell.Cells.Value2 = " ";

                            /*crText=crDocument.ReportDefinition.ReportObjects["text39"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                            crText.Text = "";*/
                            crCell = SheetData.get_Range("b40", Type.Missing);
                            crCell.Cells.Value2 = " ";
                            //crText.Text=s1 + " " + s2;

                            //crText=crDocument.ReportDefinition.ReportObjects["text41"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                            //crText.Text="";

                            /*crText=crDocument.ReportDefinition.ReportObjects["text43"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                            crText.Text="";*/
                            crCell = SheetData.get_Range("b44", Type.Missing);
                            crCell.Cells.Value2 = " ";

                            /*crText=crDocument.ReportDefinition.ReportObjects["text44"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                            crText.Text="";*/
                            crCell = SheetData.get_Range("b45", Type.Missing);
                            crCell.Cells.Value2 = " ";
                            break;

                        }
                    case TakeInType.ShipReceiving:
                        {
                            /*crText=crDocument.ReportDefinition.ReportObjects["text20"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                            crText.Text="";*/
                            crCell = SheetData.get_Range("b21", Type.Missing);
                            crCell.Cells.Value2 = " ";

                            /*crText=crDocument.ReportDefinition.ReportObjects["text21"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                            crText.Text="";*/
                            crCell = SheetData.get_Range("b22", Type.Missing);
                            crCell.Cells.Value2 = " ";

                            /*crText=crDocument.ReportDefinition.ReportObjects["text38"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                            crText.Text = "";*/
                            crCell = SheetData.get_Range("b39", Type.Missing);
                            crCell.Cells.Value2 = " ";

                            /*crText=crDocument.ReportDefinition.ReportObjects["text39"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                            crText.Text = "";*/
                            crCell = SheetData.get_Range("b40", Type.Missing);
                            crCell.Cells.Value2 = " ";

                            /*crText=crDocument.ReportDefinition.ReportObjects["text41"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                            crText.Text = "";*/
                            crCell = SheetData.get_Range("b42", Type.Missing);
                            crCell.Cells.Value2 = " ";

                            sGroupID = dsGroup.Tables[0].Rows[0]["GroupID"].ToString();
                            string sGroupOfficeID = dsGroup.Tables[0].Rows[0]["GroupOfficeID"].ToString();
                            DataSet dsCarrier = gemoDream.Service.GetCarrier(sGroupOfficeID, sGroupID);
                            string sCarrierName = dsCarrier.Tables[0].Rows[0]["CarrierName"].ToString();
                            string sCarrierTrackingNumber = dsCarrier.Tables[0].Rows[0]["CarrierTrackingNumber"].ToString();
                            /*crText=crDocument.ReportDefinition.ReportObjects["text43"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                            crText.Text="Received via " + sCarrierName;*/
                            crCell = SheetData.get_Range("b44", Type.Missing);
                            crCell.Cells.Value2 = "Received via " + sCarrierName;

                            /*crText=crDocument.ReportDefinition.ReportObjects["text44"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                            crText.Text="with " + sCarrierName + " tracking number " + sCarrierTrackingNumber;*/
                            crCell = SheetData.get_Range("b45", Type.Missing);
                            crCell.Cells.Value2 = "with " + sCarrierName + " tracking number " + sCarrierTrackingNumber;
                            break;
                        }
                    case TakeInType.ShipReceivingPickedUpByOurMessenger:
                        {
                            /*crText=crDocument.ReportDefinition.ReportObjects["text20"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                            crText.Text="";*/
                            crCell = SheetData.get_Range("b21", Type.Missing);
                            crCell.Cells.Value2 = " ";

                            /*crText=crDocument.ReportDefinition.ReportObjects["text21"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                            crText.Text="";*/
                            crCell = SheetData.get_Range("b22", Type.Missing);
                            crCell.Cells.Value2 = " ";

                            /*crText=crDocument.ReportDefinition.ReportObjects["text38"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                            crText.Text = "";*/
                            crCell = SheetData.get_Range("b39", Type.Missing);
                            crCell.Cells.Value2 = " ";

                            /*crText=crDocument.ReportDefinition.ReportObjects["text39"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                            crText.Text = "";*/
                            crCell = SheetData.get_Range("b40", Type.Missing);
                            crCell.Cells.Value2 = " ";

                            //crText=crDocument.ReportDefinition.ReportObjects["text41"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                            //crText.Text = "";

                            /*crText=crDocument.ReportDefinition.ReportObjects["text38"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                            crText.Text="";*/
                            crCell = SheetData.get_Range("b39", Type.Missing);
                            crCell.Cells.Value2 = " ";

                            /*crText=crDocument.ReportDefinition.ReportObjects["text39"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                            crText.Text="";*/
                            crCell = SheetData.get_Range("b40", Type.Missing);
                            crCell.Cells.Value2 = " ";

                            sGroupID = dsGroup.Tables[0].Rows[0]["GroupID"].ToString();
                            string sGroupOfficeID = dsGroup.Tables[0].Rows[0]["GroupOfficeID"].ToString();
                            DataSet dsCarrier = gemoDream.Service.GetCarrier(sGroupOfficeID, sGroupID);
                            string sCarrierName = dsCarrier.Tables[0].Rows[0]["CarrierName"].ToString();
                            string sCarrierTrackingNumber = dsCarrier.Tables[0].Rows[0]["CarrierTrackingNumber"].ToString();
                            /*crText=crDocument.ReportDefinition.ReportObjects["text43"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                            crText.Text="Received via " + sCarrierName;*/
                            crCell = SheetData.get_Range("b44", Type.Missing);
                            crCell.Cells.Value2 = "Received via " + sCarrierName;

                            /*crText=crDocument.ReportDefinition.ReportObjects["text44"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                            crText.Text="with " + sCarrierName + " tracking number " + sCarrierTrackingNumber;*/
                            crCell = SheetData.get_Range("b45", Type.Missing);
                            crCell.Cells.Value2 = "with " + sCarrierName + " tracking number " + sCarrierTrackingNumber;
                            break;
                        }
                }

                /*crText=crDocument.ReportDefinition.ReportObjects["text23"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                crText.Text=dsAuthor.Tables[0].Rows[0]["FirstName"].ToString()+" "+dsAuthor.Tables[0].Rows[0]["LastName"];*/
                crCell = SheetData.get_Range("b24", Type.Missing);
                crCell.Cells.Value2 = dsAuthor.Tables[0].Rows[0]["FirstName"].ToString() + " " + dsAuthor.Tables[0].Rows[0]["LastName"];

                if (rGroup["SpecialInstruction"].ToString() != "")
                {
                    /*crText=crDocument.ReportDefinition.ReportObjects["text10"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                    crText.Text=rGroup["SpecialInstruction"].ToString();*/
                    crCell = SheetData.get_Range("b11", Type.Missing);
                    crCell.Cells.Value2 = rGroup["SpecialInstruction"].ToString();
                }
                else
                {
                    /*crText=crDocument.ReportDefinition.ReportObjects["text10"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                    crText.Text="";*/
                    crCell = SheetData.get_Range("b11", Type.Missing);
                    crCell.Cells.Value2 = " ";

                    /*crText=crDocument.ReportDefinition.ReportObjects["text9"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                    crText.Text="";*/
                    crCell = SheetData.get_Range("b10", Type.Missing);
                    crCell.Cells.Value2 = " ";
                }

                /*crText=crDocument.ReportDefinition.ReportObjects["text24"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                crText.Text="";*/
                crCell = SheetData.get_Range("b25", Type.Missing);
                crCell.Cells.Value2 = " ";

                /*crText=crDocument.ReportDefinition.ReportObjects["text25"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                crText.Text="";*/
                crCell = SheetData.get_Range("b26", Type.Missing);
                crCell.Cells.Value2 = " ";

                /*crText=crDocument.ReportDefinition.ReportObjects["text26"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                crText.Text="";*/
                crCell = SheetData.get_Range("b27", Type.Missing);
                crCell.Cells.Value2 = " ";

                /*crText=crDocument.ReportDefinition.ReportObjects["text27"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                crText.Text="";*/
                crCell = SheetData.get_Range("b28", Type.Missing);
                crCell.Cells.Value2 = " ";

                //if(rGroup["Memo"].ToString()!="")
                //by vetal_242 10.07.2006
                int iPagesToPrint = 1;
                if (dsMemoNumbers.Tables[0].Rows.Count != 0)
                {
                    if (dsMemoNumbers.Tables[0].Rows.Count <= 15)
                    {
                        for (int i = 0; i < dsMemoNumbers.Tables[0].Rows.Count; i++)
                        {
                            //int index = 52 + i;
                            int index = 53 + i;
                            string sIndex = "b" + index.ToString();
                            /*crText=crDocument.ReportDefinition.ReportObjects["text" + index.ToString()] as CrystalDecisions.CrystalReports.Engine.TextObject;
                            crText.Text = dsMemoNumbers.Tables[0].Rows[i]["Name"].ToString();*/

                            crCell = SheetData.get_Range(sIndex, Type.Missing);
                            crCell.Cells.Value2 = dsMemoNumbers.Tables[0].Rows[i]["Name"].ToString();
                        }
                    }
                    else
                    {
                        iPagesToPrint = 2;
                        MainPage.Shapes.Item("Memo_ToNextPageInfo").TextFrame.Characters(Type.Missing, Type.Missing).Text = "Memo List is moved to the next page. See it there, please";
                        //SheetLabel.PrintOut(Type.Missing,Type.Missing,1,false,sPrinterName,Type.Missing,true,Type.Missing);
                        Excel.Worksheet SheetMemo = (Excel.Worksheet)BookData.Sheets[3];
                        SheetMemo.Shapes.Item("OrderNumber").TextFrame.Characters(Type.Missing, Type.Missing).Text = "Order # " + sGroupCode;
                        SheetMemo.Shapes.Item("AcceptedBy").TextFrame.Characters(Type.Missing, Type.Missing).Text = dsAuthor.Tables[0].Rows[0]["FirstName"].ToString() + " " + dsAuthor.Tables[0].Rows[0]["LastName"];

                        for (int i = 0; i < dsMemoNumbers.Tables[0].Rows.Count; i++)
                        {
                            int index = 10 + i;
                            string sIndex = "E" + index.ToString();
                            crCell = SheetMemo.get_Range(sIndex, Type.Missing);
                            crCell.Cells.Value2 = dsMemoNumbers.Tables[0].Rows[i]["Name"].ToString();
                        }
                    }
                }

                /*crText=crDocument.ReportDefinition.ReportObjects["text32"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                crText.Text="";*/
                crCell = SheetData.get_Range("b33", Type.Missing);
                crCell.Cells.Value2 = " ";

                /*crText=crDocument.ReportDefinition.ReportObjects["text33"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                crText.Text="";*/
                crCell = SheetData.get_Range("b34", Type.Missing);
                crCell.Cells.Value2 = " ";

                /*crText=crDocument.ReportDefinition.ReportObjects["text34"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                crText.Text="";*/
                crCell = SheetData.get_Range("b35", Type.Missing);
                crCell.Cells.Value2 = " ";

                /*crText=crDocument.ReportDefinition.ReportObjects["text35"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                crText.Text="";*/
                crCell = SheetData.get_Range("b36", Type.Missing);
                crCell.Cells.Value2 = " ";

                /*crText=crDocument.ReportDefinition.ReportObjects["text36"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                crText.Text="";*/
                crCell = SheetData.get_Range("b37", Type.Missing);
                crCell.Cells.Value2 = " ";

                /*crText=crDocument.ReportDefinition.ReportObjects["text37"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                crText.Text="";*/
                crCell = SheetData.get_Range("b38", Type.Missing);
                crCell.Cells.Value2 = " ";

				//**************************************
				//try { BookTemp.Save(); }
				//catch { }
				//Excel.Worksheet SheetLabel = (Excel.Worksheet)BookTemp.Sheets[1];
				//Excel.Worksheet SheetMemoPrint = (Excel.Worksheet)BookTemp.Sheets[3];
				Excel.Worksheet SheetLabel = (Excel.Worksheet)BookData.Sheets[1];
				Excel.Worksheet SheetMemoPrint = (Excel.Worksheet)BookData.Sheets[3];

				if (Client.ViewReport == true)
                {
					objExcel.Application.Visible = true;
					objExcel.WindowState = Excel.XlWindowState.xlMaximized;
					SheetLabel.PrintPreview(Type.Missing); //, Type.Missing, 1, true, Type.Missing,/*sPrinterName,*/ Type.Missing, true, Type.Missing);
					objExcel.Application.Visible = false;
					objExcel.WindowState = Excel.XlWindowState.xlMinimized;
					Client.ViewReport = false;

					//SheetLabel.SaveAs(myFile, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
					//objExcel.Application.Visible = true;
     //               objExcel.WindowState = Excel.XlWindowState.xlMaximized;
     //               SheetLabel.(Type.Missing, Type.Missing, 1, true, Type.Missing,/*sPrinterName,*/ Type.Missing, true, Type.Missing);
     ////               if (iPagesToPrint == 2)
     ////                   SheetMemoPrint.PrintOut(Type.Missing, Type.Missing, 1, true, sPrinterName, Type.Missing, true, Type.Missing);
     ////               objExcel.Application.Visible = false;
     ////               objExcel.WindowState = Excel.XlWindowState.xlMinimized;
     //               Client.ViewReport = false;
                }
                else
                {
                    if (iPagesToPrint == 1)
                        SheetLabel.PrintOut(Type.Missing, Type.Missing, CopyOfReport, false, sPrinterName, Type.Missing, true, Type.Missing);

                    if (iPagesToPrint == 2)
                    {
                        SheetLabel.PrintOut(Type.Missing, Type.Missing, CopyOfReport, false, sPrinterName, Type.Missing, true, Type.Missing);
                        SheetMemoPrint.PrintOut(Type.Missing, Type.Missing, CopyOfReport, false, sPrinterName, Type.Missing, true, Type.Missing);
                    }
                }

                NAR(crCell);
                NAR(SheetData);
                NAR(SheetLabel);
                crCell = null;
                SheetLabel = null;
                SheetData = null;
            }
            #region Close Excel
            catch (Exception ex)
            {
                string msg = ex.Message;
                if (msg == "file not found")
                {
                    throw new Exception("The system cannot find the file: " + sReportPath);
                }
            }
            finally
            {
                try
                {
                    //BookTemp.Save();
                    BookTemp.Close(false, fnTemp, null);
                    //BookTemp.Close(true,fnTemp,null);//save for test
                }
                catch (Exception ex)
                { }
                try
                { BookData.Close(false, sReportPath, null); }
                catch (Exception ex)
                { }
                try
                {
                    //objExcel.Quit();

                    NAR(BookTemp);
                    NAR(BookData);
                    //NAR(objExcel);

                    BookTemp = null;
                    BookData = null;
                    //objExcel=null;


                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                }
                catch (Exception ex)
                { }
                try
                {
                    if (File.Exists(fnTemp))
                        File.Delete(fnTemp);//delete temp file
                }
                catch { }
            }
            #endregion
            #endregion

            //*******************************************

        }

        /*-------------------------*/
        public void Excel_Items_Selected(string sItemsNum)
        {
            //string sReportPath=sReportsDir+@"items_selected.rpt";
            // New part 03/07/08;
            string sReportPath = Client.GetOfficeDirPath("repDir") + @"items_selected.xls";
            //string sReportPath=sReportsDir+@"items_selected.xls"; old part 03/07/08
            string sTemp = "";
            sTemp = Environment.GetEnvironmentVariable("TEMP");
            if (sTemp == "") sTemp = "c:";
            string fnTemp = sTemp + "\\Items_Selected" + sItemsNum + ".xls";
            //string sReportPath=@"c:\work\sergei\work\crystal\reports\items_selected.rpt";
            //crDocument.Load(sReportPath);
            //sPrinterName=GetPrinterName("Items_Selected");
            //CrystalDecisions.CrystalReports.Engine.TextObject crText;

            #region  Open Excel
            //Excel.Application objExcel = null ;
            Excel.Workbook BookData = null;
            Excel.Workbook BookTemp = null;
            try
            {
                if (objExcel == null)
                    objExcel = new Excel.Application();
                try
                {
                    BookData = objExcel.Workbooks.Open(sReportPath, Type.Missing, true, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                }
                catch (Exception ex)
                {
                    throw new Exception("file not found");
                }

                BookData.SaveCopyAs(fnTemp);
                BookData.Close(false, sReportPath, null);
                //make local copy

                BookTemp = objExcel.Workbooks.Open(fnTemp, Type.Missing, false, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                Excel.Worksheet SheetData = (Excel.Worksheet)BookTemp.Sheets[2];

                Excel.Range crCell = null;
                /*crText=crDocument.ReportDefinition.ReportObjects["itemsNum"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                crText.Text=sItemsNum;*/

                crCell = SheetData.get_Range("b3", Type.Missing);
                crCell.Cells.Value2 = sItemsNum;


                //print
                Excel.Worksheet SheetLabel = (Excel.Worksheet)BookTemp.Sheets[1];
                SheetLabel.PrintOut(Type.Missing, Type.Missing, 1, false, sPrinterName, Type.Missing, true, Type.Missing);

                NAR(crCell);
                NAR(SheetData);
                NAR(SheetLabel);
                crCell = null;
                SheetLabel = null;
                SheetData = null;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                if (msg == "file not found")
                {
                    throw new Exception("The system cannot find the file: " + sReportPath);
                }
            }
            finally
            {
                try
                {
                    //BookTemp.Save();//save for test
                    BookTemp.Close(false, fnTemp, null);
                }
                catch (Exception ex)
                { }
                try
                { BookData.Close(false, sReportPath, null); }
                catch (Exception ex)
                { }
                try
                {
                    //objExcel.Quit();

                    NAR(BookTemp);
                    NAR(BookData);
                    //NAR(objExcel);

                    BookTemp = null;
                    BookData = null;
                    //objExcel=null;

                    /*
                                        GC.Collect();
                                        GC.WaitForPendingFinalizers(); 
                                        GC.Collect();*/
                }
                catch (Exception ex)
                { }
                try
                {
                    if (File.Exists(fnTemp))
                        File.Delete(fnTemp);
                }
                catch { }
            }
            #endregion


        }

        public void Excel_Batch(DataSet dsData)
        {
            //string sReportPath=sReportsDir+@"batch.rpt";
            //string sReportPath=sReportsDir+@"batch.xls"; old part 03/07/08
            string sReportPath = Client.GetOfficeDirPath("repDir") + @"batch.xls";

            string sTemp = "";
            sTemp = Environment.GetEnvironmentVariable("TEMP");
            if (sTemp == "") sTemp = "c:";
            string fnTemp = sTemp + "\\batch" + FillToFiveChars(dsData.Tables["tblItem"].Rows[0]["OrderCode"].ToString()) + FillToThreeChars(dsData.Tables["tblItem"].Rows[0]["BatchCode"].ToString()) + ".xls";
            //crDocument.Load(sReportPath);
            sPrinterName = GetPrinterName("Batch");

            //DataSet dsTempSet=new DataSet();
            DataTable table1 = new DataTable("batch");
            table1.Columns.Add("id", System.Type.GetType("System.String"));
            table1.Columns.Add("batchid", System.Type.GetType("System.String"));
            table1.Columns.Add("itemnumber", System.Type.GetType("System.String"));
            table1.Columns.Add("Color", System.Type.GetType("System.String"));
            table1.Columns.Add("Clarity", System.Type.GetType("System.String"));
            table1.Columns.Add("Measurments", System.Type.GetType("System.String"));

            for (int i = 0; i < dsData.Tables["tblItem"].Rows.Count; i++)
            {
                DataRow tRow1 = table1.NewRow();
                tRow1["id"] = i.ToString();
                tRow1["batchid"] = FillToFiveChars(dsData.Tables["tblItem"].Rows[i]["OrderCode"].ToString()) + FillToThreeChars(dsData.Tables["tblItem"].Rows[i]["BatchCode"].ToString());
                tRow1["itemnumber"] = dsData.Tables["tblItem"].Rows[i]["Name"].ToString().Replace(".", "");
                tRow1["Color"] = dsData.Tables["tblItem"].Rows[i]["Color"].ToString();
                tRow1["Clarity"] = dsData.Tables["tblItem"].Rows[i]["Clarity"].ToString();
                tRow1["Measurments"] = dsData.Tables["tblItem"].Rows[i]["Dimensions"].ToString();
                table1.Rows.Add(tRow1);
            }


            //dsTempSet.Tables.Add(table1);
            /*
                        dsCrystalSet=new DataSet();
                        dsCrystalSet=dsTempSet;
                        crDocument.SetDataSource(dsCrystalSet);
            */
            //table1

            #region  Open Excel
            //Excel.Application objExcel = null ;
            Excel.Workbook BookData = null;
            Excel.Workbook BookTemp = null;
            try
            {
                if (objExcel == null)
                    objExcel = new Excel.Application();
                try
                {
                    BookData = objExcel.Workbooks.Open(sReportPath, Type.Missing, true, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                }
                catch (Exception ex)
                {
                    throw new Exception("file not found");
                }

                BookData.SaveCopyAs(fnTemp);
                BookData.Close(false, sReportPath, null);
                //make local copy

                BookTemp = objExcel.Workbooks.Open(fnTemp, Type.Missing, false, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                Excel.Worksheet SheetData = (Excel.Worksheet)BookTemp.Sheets[2];

                Excel.Range crCell = null;

                /*text=crDocument.ReportDefinition.ReportObjects["text3"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                text.Text=dsData.Tables["tblItem"].Rows[0]["CustomerName"].ToString();*/
                crCell = SheetData.get_Range("b4", Type.Missing);
                crCell.Cells.Value2 = dsData.Tables["tblItem"].Rows[0]["CustomerName"].ToString();

                /*text=crDocument.ReportDefinition.ReportObjects["text5"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                text.Text=dsData.Tables["tblItem"].Rows[0]["CustomerCode"].ToString();*/
                crCell = SheetData.get_Range("b6", Type.Missing);
                crCell.Cells.Value2 = dsData.Tables["tblItem"].Rows[0]["CustomerCode"].ToString();

                /*text=crDocument.ReportDefinition.ReportObjects["text7"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                text.Text=FillToFiveChars(dsData.Tables["tblItem"].Rows[0]["OrderCode"].ToString());*/
                crCell = SheetData.get_Range("b8", Type.Missing);
                crCell.Cells.Value2 = FillToFiveChars(dsData.Tables["tblItem"].Rows[0]["OrderCode"].ToString());
                char cn = 'd';
                //int index = 0;
                string colname = "";
                foreach (DataRow dr in table1.Rows)
                {

                    colname = cn.ToString() + 2;
                    crCell = SheetData.get_Range(colname, Type.Missing);
                    crCell.Cells.Value2 = dr["batchid"].ToString();

                    colname = cn.ToString() + 3;
                    crCell = SheetData.get_Range(colname, Type.Missing);
                    crCell.Cells.Value2 = dr["itemnumber"].ToString();

                    colname = cn.ToString() + 5;
                    crCell = SheetData.get_Range(colname, Type.Missing);
                    crCell.Cells.Value2 = dr["Color"].ToString();

                    colname = cn.ToString() + 4;
                    crCell = SheetData.get_Range(colname, Type.Missing);
                    crCell.Cells.Value2 = dr["Clarity"].ToString();

                    colname = cn.ToString() + 7;
                    crCell = SheetData.get_Range(colname, Type.Missing);
                    crCell.Cells.Value2 = dr["Measurments"].ToString();

                    //tRow1["batchid"]=FillToFiveChars(dsData.Tables["tblItem"].Rows[i]["OrderCode"].ToString())+FillToThreeChars(dsData.Tables["tblItem"].Rows[i]["BatchCode"].ToString());
                    //tRow1["itemnumber"]=dsData.Tables["tblItem"].Rows[i]["Name"].ToString().Replace(".","");
                    //tRow1["Color"]=dsData.Tables["tblItem"].Rows[i]["Color"].ToString();
                    //tRow1["Clarity"]=dsData.Tables["tblItem"].Rows[i]["Clarity"].ToString();
                    //tRow1["Measurments"]=dsData.Tables["tblItem"].Rows[i]["Dimensions"].ToString();
                    //table1.Rows.Add(tRow1);
                    cn++;
                }

                //print
                Excel.Worksheet SheetLabel = (Excel.Worksheet)BookTemp.Sheets[1];

                SheetLabel.PrintOut(Type.Missing, Type.Missing, 1, false, sPrinterName, Type.Missing, true, Type.Missing);

                NAR(crCell);
                NAR(SheetData);
                NAR(SheetLabel);
                crCell = null;
                SheetLabel = null;
                SheetData = null;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                if (msg == "file not found")
                {
                    throw new Exception("The system cannot find the file: " + sReportPath);
                }
            }
            finally
            {
                try
                {
                    //					BookTemp.Save();//save for test
                    BookTemp.Close(false, fnTemp, null);
                }
                catch (Exception ex)
                { }
                try
                { BookData.Close(false, sReportPath, null); }
                catch (Exception ex)
                { }
                try
                {
                    //objExcel.Quit();

                    NAR(BookTemp);
                    NAR(BookData);
                    //NAR(objExcel);

                    BookTemp = null;
                    BookData = null;
                    //objExcel=null;

                    /*
                                        GC.Collect();
                                        GC.WaitForPendingFinalizers(); 
                                        GC.Collect();*/
                }
                catch (Exception ex)
                { }
                try
                {
                    if (File.Exists(fnTemp))
                        File.Delete(fnTemp);
                }
                catch { }
            }
            #endregion


        }

        #endregion

        ~CrystalReport()
        {
            CloseExcel();
        }
    }

    public class EditPdf
    {
        System.Data.DataSet dsXRefTable;
        long iXrefPos = 0;
        readonly string sFileName = "";
        System.IO.MemoryStream mem = null;
        float Bleed_x1 = 0;
        float Bleed_y1 = 0;
        float Bleed_x2 = 0;
        float Bleed_y2 = 0;

        float Media_x1 = 0;
        float Media_y1 = 0;
        float Media_x2 = 0;
        float Media_y2 = 0;

        float Crop_x1 = 0;
        float Crop_y1 = 0;
        float Crop_x2 = 0;
        float Crop_y2 = 0;

        readonly int iPage1Obj = 8;
        readonly int iPagr2Obj = 20;

        bool bChangeMedia = false;

        public EditPdf(string sPdfFileName)
        {
            dsXRefTable = new DataSet();
            dsXRefTable.Tables.Add();
            dsXRefTable.Tables[0].Columns.Add("Offset", System.Type.GetType("System.String"));
            //dsXRefTable.Tables[0].Columns.Add("Object_num",System.Type.GetType("System.String"));
            dsXRefTable.Tables[0].Columns.Add("Object_num", System.Type.GetType("System.Int32"));

            sFileName = sPdfFileName;
            //read pdf to memory stream
            System.IO.FileStream fs = new System.IO.FileStream(sFileName, System.IO.FileMode.Open);
            mem = new System.IO.MemoryStream();
            byte[] buf = new byte[fs.Length];
            fs.Read(buf, 0, (int)fs.Length);
            mem.Write(buf, 0, buf.Length);
            fs.Close();
        }

        public void Edit()
        {


            //ChangeVerNumber();
            //CropToBleed();
            //ChangeBleedBoxSize(10,10,50,50);

            Bleed_x1 = 5.975998f;
            Bleed_y1 = 0.503998f;
            Bleed_x2 = 266.952026f;
            Bleed_y2 = 171.496002f;

            Crop_x1 = 15.119995f;
            Crop_y1 = 10.007996f;
            Crop_x2 = 258.096008f;
            Crop_y2 = 164.800003f;

            bChangeMedia = false;
            Media_x1 = 0;
            Media_y1 = 0;
            Media_x2 = 266.33f;
            Media_y2 = 162f;


            CreateXRefTable();
            ChangeXRefTable();

            //	AddBleedBox(10, 10, 50, 50);

            MemToFile(sFileName);

        }
        public void EditSitaraPdf()
        {
            Bleed_x1 = 0f;
            Bleed_y1 = 499.68f;
            Bleed_x2 = 225f;
            Bleed_y2 = 792f;

            Crop_x1 = 0f;
            Crop_y1 = 499.68f;
            Crop_x2 = 225f;
            Crop_y2 = 792f;

            bChangeMedia = true;
            Media_x1 = 0f;
            Media_y1 = 499.68f;
            Media_x2 = 225f;
            Media_y2 = 792f;


            CreateXRefTableSitara();
            ChangeXRefTableSitara();

            //	AddBleedBox(10, 10, 50, 50);

            MemToFile(sFileName);
        }


        private void AddBleedBox(int x1, int y1, int x2, int y2)
        {
            mem.Seek(0, System.IO.SeekOrigin.Begin);
            System.IO.StreamReader reader = new System.IO.StreamReader(mem);

            string sPattern = @"Contents [ 5 0 R ]";

            System.Text.RegularExpressions.Regex regExp = new System.Text.RegularExpressions.Regex(sPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            System.Text.RegularExpressions.Match regMatch;

            byte[] buf = new byte[18];
            System.Text.ASCIIEncoding ASCIenc = new System.Text.ASCIIEncoding();

            int iOffs = 0;

            while (true)
            {
                mem.Read(buf, 0, 18);
                string sTemp = new string((ASCIenc.GetChars(buf)));

                regMatch = regExp.Match(sTemp);
                if (regMatch.Success)
                {
                    iOffs = (int)mem.Position + 1;
                    break;
                }

                //	regMatch=regExpEOF.Match(sTemp);
                //	if(regMatch.Success)
                //		break;

                mem.Position -= 17;
            }
            if (iOffs == 0) return;
            /*
                            System.IO.MemoryStream mem1=new System.IO.MemoryStream();
                            mem1.Write(mem.GetBuffer(),0,(int)mem.Length);
                            mem.Seek(iOffs,System.IO.SeekOrigin.Begin);

				
                            string sStr='\x0a'+"["+x1.ToString()+" "+y1.ToString()+" "+x2.ToString()+" "+y2.ToString()+"]";
                            mem.Write(ASCIenc.GetBytes(sStr),0,sStr.Length);
				
                            mem1.Seek(iOffs+17,System.IO.SeekOrigin.Begin);
                            byte [] buf1=new byte[mem1.Length-mem1.Position];
                            mem1.Read(buf1,0,buf1.Length);
                            mem.Write(buf1,0,buf1.Length);
                            mem1.Close();
                */
        }
        //doesn't work :)

        private void ChangeBleedBoxSize(int x1, int y1, int x2, int y2)
        {
            mem.Seek(0, System.IO.SeekOrigin.Begin);
            System.IO.StreamReader reader = new System.IO.StreamReader(mem);

            string sPattern = @"[^\d]4 0 obj";
            string sEOFPattern = @"%%EOF";
            System.Text.RegularExpressions.Regex regExp = new System.Text.RegularExpressions.Regex(sPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regExpEOF = new System.Text.RegularExpressions.Regex(sEOFPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Match regMatch;

            byte[] buf = new byte[8];
            System.Text.ASCIIEncoding ASCIenc = new System.Text.ASCIIEncoding();

            int iOffs = 0;

            while (true)
            {
                mem.Read(buf, 0, 8);
                string sTemp = new string((ASCIenc.GetChars(buf)));

                //if(mem.Position>1400)
                //	System.Diagnostics.Trace.WriteLine("asd");

                regMatch = regExp.Match(sTemp);
                if (regMatch.Success)
                {
                    iOffs = (int)mem.Position;
                    break;
                }

                //	regMatch=regExpEOF.Match(sTemp);
                //	if(regMatch.Success)
                //		break;

                mem.Position -= 7;
            }
            if (iOffs == 0) return;

            System.IO.MemoryStream mem1 = new System.IO.MemoryStream();
            mem1.Write(mem.GetBuffer(), 0, (int)mem.Length);
            mem.Seek(iOffs, System.IO.SeekOrigin.Begin);


            string sStr = '\x0a' + "[" + x1.ToString() + " " + y1.ToString() + " " + x2.ToString() + " " + y2.ToString() + "]";
            mem.Write(ASCIenc.GetBytes(sStr), 0, sStr.Length);

            mem1.Seek(iOffs + 17, System.IO.SeekOrigin.Begin);
            byte[] buf1 = new byte[mem1.Length - mem1.Position];
            mem1.Read(buf1, 0, buf1.Length);
            mem.Write(buf1, 0, buf1.Length);
            mem1.Close();
        }
        private void ChangeVerNumber()
        {
            string sTemp = "%PDF-1.3\n";
            System.Text.ASCIIEncoding ASCIenc = new System.Text.ASCIIEncoding();
            mem.Seek(0, System.IO.SeekOrigin.Begin);
            mem.Write(ASCIenc.GetBytes(sTemp), 0, sTemp.Length);
            mem.Flush();
        }

        private void CropToBleed()
        {
            mem.Seek(0, System.IO.SeekOrigin.Begin);
            System.IO.StreamReader reader = new System.IO.StreamReader(mem);

            string sPattern = @"CropBox";
            string sEOFPattern = @"%%EOF";
            System.Text.RegularExpressions.Regex regExp = new System.Text.RegularExpressions.Regex(sPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regExpEOF = new System.Text.RegularExpressions.Regex(sEOFPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Match regMatch;

            byte[] buf = new byte[7];
            System.Text.ASCIIEncoding ASCIenc = new System.Text.ASCIIEncoding();

            int iOffs = 0;

            while (true)
            {
                mem.Read(buf, 0, 7);
                string sTemp = new string((ASCIenc.GetChars(buf)));

                //if(mem.Position>1400)
                //	System.Diagnostics.Trace.WriteLine("asd");

                regMatch = regExp.Match(sTemp);
                if (regMatch.Success)
                {
                    iOffs = (int)mem.Position - 7;
                    break;
                }

                //	regMatch=regExpEOF.Match(sTemp);
                //	if(regMatch.Success)
                //		break;

                mem.Position -= 6;
            }
            if (iOffs == 0) return;

            System.IO.MemoryStream mem1 = new System.IO.MemoryStream();
            mem1.Write(mem.GetBuffer(), 0, (int)mem.Length);
            mem.Seek(iOffs, System.IO.SeekOrigin.Begin);
            string sStr = "BleedBox";
            mem.Write(ASCIenc.GetBytes(sStr), 0, sStr.Length);
            mem1.Seek(iOffs + 7, System.IO.SeekOrigin.Begin);
            byte[] buf1 = new byte[mem1.Length - mem1.Position];
            mem1.Read(buf1, 0, buf1.Length);
            mem.Write(buf1, 0, buf1.Length);
            mem1.Close();


        }
        private void CreateXRefTable()
        {
            mem.Seek(0, System.IO.SeekOrigin.Begin);
            System.IO.StreamReader reader = new System.IO.StreamReader(mem);

            string sPattern = @"([^\d][1-9]|[1-9][\d]) \d obj";
            string sEOFPattern = @"%%EOF";
            string sXREFPattern = @"xref";

            System.Text.RegularExpressions.Regex regExp = new System.Text.RegularExpressions.Regex(sPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regExpEOF = new System.Text.RegularExpressions.Regex(sEOFPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regXREF = new System.Text.RegularExpressions.Regex(sXREFPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            System.Text.RegularExpressions.Match regMatch;

            byte[] buf1 = new byte[8];
            mem.Seek(0, System.IO.SeekOrigin.Begin);
            System.Text.ASCIIEncoding ASCIenc = new System.Text.ASCIIEncoding();

            System.DateTime start = new DateTime();
            start = System.DateTime.Now;

            while (true)
            {
                mem.Read(buf1, 0, 8);
                string sTemp = new string((ASCIenc.GetChars(buf1)));

                regMatch = regExp.Match(sTemp);
                if (regMatch.Success)
                {
                    /*
                        if(regMatch.ToString()[0]!=0x0A) System.Diagnostics.Trace.WriteLine(regMatch.ToString()+" : "+(mem.Position-8).ToString());
                        else System.Diagnostics.Trace.WriteLine(regMatch.ToString()+" : "+(mem.Position-7).ToString());
                        mem.Position+=3;
                        */
                    System.Data.DataRow row = dsXRefTable.Tables[0].NewRow();
                    if (regMatch.ToString()[0] != 0x0A)
                    {
                        row["Offset"] = (mem.Position - 8).ToString();
                        row["Object_num"] = regMatch.ToString().Substring(0, 2);

                        #region page2 bleedbox & cropBox
                        if (Convert.ToInt32(row["Object_num"].ToString()) == 19)//page2 bleedbox
                        {
                            mem.Position -= 8;
                            mem.Position += 83;
                            int iInsOffs = (int)mem.Position;

                            sTemp = @"/BleedBox [" + Bleed_x1.ToString().Replace(",", ".") + " " + Bleed_y1.ToString().Replace(",", ".") + " "
                                + Bleed_x2.ToString().Replace(",", ".") + " " + Bleed_y2.ToString().Replace(",", ".") + "]" + '\x0a' +
                                @"/TrimBox [" + Crop_x1.ToString().Replace(",", ".") + " " + Crop_y1.ToString().Replace(",", ".") + " "
                                + Crop_x2.ToString().Replace(",", ".") + " " + Crop_y2.ToString().Replace(",", ".") + "]" + '\x0a';

                            System.IO.MemoryStream mem1 = new System.IO.MemoryStream();

                            mem1.Write(mem.GetBuffer(), 0, (int)mem.Length);
                            mem.Write(ASCIenc.GetBytes(sTemp), 0, sTemp.Length);
                            int iMemOffs = (int)mem.Position;
                            mem1.Seek(iInsOffs, System.IO.SeekOrigin.Begin);
                            byte[] buf2 = new byte[mem1.Length - mem1.Position];
                            mem1.Read(buf2, 0, buf2.Length);
                            mem.Write(buf2, 0, buf2.Length);
                            mem.Position = iMemOffs;


                        }
                        #endregion

                    }
                    else
                    {
                        row["Offset"] = (mem.Position - 7).ToString();
                        row["Object_num"] = Convert.ToInt32(regMatch.ToString().Trim().Substring(0, 1));

                        #region page1 bleedbox & cropBox
                        if (Convert.ToInt32(row["Object_num"].ToString()) == 8) //page1 bleedbox
                        {
                            mem.Position -= 7;
                            mem.Position += 80;
                            int iInsOffs = (int)mem.Position;

                            sTemp = @"/BleedBox [" + Bleed_x1.ToString().Replace(",", ".") + " " + Bleed_y1.ToString().Replace(",", ".") + " "
                                + Bleed_x2.ToString().Replace(",", ".") + " " + Bleed_y2.ToString().Replace(",", ".") + "]" + '\x0a' +
                                @"/TrimBox [" + Crop_x1.ToString().Replace(",", ".") + " " + Crop_y1.ToString().Replace(",", ".") + " "
                                + Crop_x2.ToString().Replace(",", ".") + " " + Crop_y2.ToString().Replace(",", ".") + "]" + '\x0a';

                            System.IO.MemoryStream mem1 = new System.IO.MemoryStream();

                            mem1.Write(mem.GetBuffer(), 0, (int)mem.Length);
                            mem.Write(ASCIenc.GetBytes(sTemp), 0, sTemp.Length);
                            int iMemOffs = (int)mem.Position;
                            mem1.Seek(iInsOffs, System.IO.SeekOrigin.Begin);
                            byte[] buf2 = new byte[mem1.Length - mem1.Position];
                            mem1.Read(buf2, 0, buf2.Length);
                            mem.Write(buf2, 0, buf2.Length);
                            mem.Position = iMemOffs;

                        }
                        #endregion

                        #region CropBox
                        if (Convert.ToInt32(row["Object_num"].ToString()) == 4)
                        {
                            mem.Position -= 7;
                            mem.Position += 9;
                            int iInsOffs = (int)mem.Position;

                            sTemp = @"[" + Crop_x1.ToString().Replace(",", ".") + " " + Crop_y1.ToString().Replace(",", ".") + " "
                                + Crop_x2.ToString().Replace(",", ".") + " " + Crop_y2.ToString().Replace(",", ".") + "]" + '\x0a';

                            System.IO.MemoryStream mem1 = new System.IO.MemoryStream();

                            mem1.Write(mem.GetBuffer(), 0, (int)mem.Length);
                            mem.Write(ASCIenc.GetBytes(sTemp), 0, sTemp.Length);
                            int iMemOffs = (int)mem.Position;
                            mem1.Seek(iInsOffs + 17, System.IO.SeekOrigin.Begin);
                            byte[] buf2 = new byte[mem1.Length - mem1.Position];
                            mem1.Read(buf2, 0, buf2.Length);
                            mem.Write(buf2, 0, buf2.Length);
                            mem.Position = iMemOffs;

                        }

                        #endregion
                    }

                    dsXRefTable.Tables[0].Rows.Add(row);
                    mem.Position += 3;
                }
                regMatch = regExpEOF.Match(sTemp);
                if (regMatch.Success)
                    break;

                regMatch = regXREF.Match(sTemp);
                if (regMatch.Success)
                {
                    iXrefPos = mem.Position - 8 + regMatch.Index;
                    break;
                }

                mem.Position -= 7;
            }
            System.DateTime end = new DateTime();
            end = System.DateTime.Now;
            System.TimeSpan diff = end.Subtract(start);

            System.Diagnostics.Trace.WriteLine(diff.TotalSeconds.ToString());
            System.Diagnostics.Trace.WriteLine("done");


        }

        private void ChangeXRefTable()
        {
            System.IO.StreamWriter stremWriter = new System.IO.StreamWriter(mem);
            mem.Seek(iXrefPos, System.IO.SeekOrigin.Begin);
            System.Text.ASCIIEncoding ASCIenc = new System.Text.ASCIIEncoding();
            string sStr = "0";


            mem.Write(ASCIenc.GetBytes("xref\n"), 0, 5);

            sStr = "0 " + (dsXRefTable.Tables[0].Rows.Count + 1).ToString() + " \n";
            mem.Write(ASCIenc.GetBytes(sStr), 0, sStr.Length);

            sStr = "0";
            sStr = FillTo10(sStr) + " " + "65535" + " f \n";
            mem.Write(ASCIenc.GetBytes(sStr), 0, sStr.Length);

            for (int i = 0; i < dsXRefTable.Tables[0].Rows.Count; i++)
            {
                System.Data.DataRow[] rows = dsXRefTable.Tables[0].Select("Object_num=" + (i + 1).ToString());
                try
                {
                    sStr = FillTo10(rows[0]["Offset"].ToString()) + " " + "00000" + " n \n";
                }
                catch
                { }
                mem.Write(ASCIenc.GetBytes(sStr), 0, sStr.Length);
            }

            //trailer
            //
            sStr = "trailer\n<<\n/Size " + (dsXRefTable.Tables[0].Rows.Count + 1).ToString() + "\n/Root 1 0 R\n" +
                "/Info 40 0 R\n>>\nstartxref\n" + iXrefPos.ToString() + "\n%%EOF";
            mem.Write(ASCIenc.GetBytes(sStr), 0, sStr.Length);
            mem.SetLength(mem.Position);


            /*

                System.IO.FileStream fs=new System.IO.FileStream(sFileName+".tmp",System.IO.FileMode.Create);
                fs.Write(mem.GetBuffer(),0,(int)mem.Position);
                fs.Close();
                */
        }


        private void CreateXRefTableSitara()
        {
            mem.Seek(0, System.IO.SeekOrigin.Begin);
            System.IO.StreamReader reader = new System.IO.StreamReader(mem);

            string sPattern = @"([^\d][1-9]|[1-9][\d]) \d obj";
            string sEOFPattern = @"%%EOF";
            string sXREFPattern = @"xref";

            System.Text.RegularExpressions.Regex regExp = new System.Text.RegularExpressions.Regex(sPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regExpEOF = new System.Text.RegularExpressions.Regex(sEOFPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regXREF = new System.Text.RegularExpressions.Regex(sXREFPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            System.Text.RegularExpressions.Match regMatch;

            byte[] buf1 = new byte[8];
            mem.Seek(0, System.IO.SeekOrigin.Begin);
            System.Text.ASCIIEncoding ASCIenc = new System.Text.ASCIIEncoding();

            System.DateTime start = new DateTime();
            start = System.DateTime.Now;

            while (true)
            {
                mem.Read(buf1, 0, 8);
                string sTemp = new string((ASCIenc.GetChars(buf1)));

                regMatch = regExp.Match(sTemp);
                if (regMatch.Success)
                {
                    /*
                        if(regMatch.ToString()[0]!=0x0A) System.Diagnostics.Trace.WriteLine(regMatch.ToString()+" : "+(mem.Position-8).ToString());
                        else System.Diagnostics.Trace.WriteLine(regMatch.ToString()+" : "+(mem.Position-7).ToString());
                        mem.Position+=3;
                        */
                    System.Data.DataRow row = dsXRefTable.Tables[0].NewRow();
                    if (regMatch.ToString()[0] != 0x0A)
                    {
                        row["Offset"] = (mem.Position - 8).ToString();
                        row["Object_num"] = regMatch.ToString().Substring(0, 2);



                        #region page2 bleedbox & cropBox
                        if (Convert.ToInt32(row["Object_num"].ToString()) == 20)//page2 bleedbox
                        {
                            mem.Position -= 8;
                            mem.Position += 83;
                            int iInsOffs = (int)mem.Position;

                            sTemp = @"/MediaBox [" + Media_x1.ToString().Replace(",", ".") + " " + Media_y1.ToString().Replace(",", ".") + " "
                                + Media_x2.ToString().Replace(",", ".") + " " + Media_y2.ToString().Replace(",", ".") + "]" + '\x0a' +
                                @"/BleedBox [" + Bleed_x1.ToString().Replace(",", ".") + " " + Bleed_y1.ToString().Replace(",", ".") + " "
                                + Bleed_x2.ToString().Replace(",", ".") + " " + Bleed_y2.ToString().Replace(",", ".") + "]" + '\x0a' +
                                @"/TrimBox [" + Crop_x1.ToString().Replace(",", ".") + " " + Crop_y1.ToString().Replace(",", ".") + " "
                                + Crop_x2.ToString().Replace(",", ".") + " " + Crop_y2.ToString().Replace(",", ".") + "]" + '\x0a';

                            System.IO.MemoryStream mem1 = new System.IO.MemoryStream();

                            mem1.Write(mem.GetBuffer(), 0, (int)mem.Length);
                            mem.Write(ASCIenc.GetBytes(sTemp), 0, sTemp.Length);
                            int iMemOffs = (int)mem.Position;
                            mem1.Seek(iInsOffs, System.IO.SeekOrigin.Begin);
                            byte[] buf2 = new byte[mem1.Length - mem1.Position];
                            mem1.Read(buf2, 0, buf2.Length);
                            mem.Write(buf2, 0, buf2.Length);
                            mem.Position = iMemOffs;


                        }
                        #endregion

                    }
                    else
                    {
                        row["Offset"] = (mem.Position - 7).ToString();
                        row["Object_num"] = Convert.ToInt32(regMatch.ToString().Trim().Substring(0, 1));

                        #region page1 bleedbox & cropBox
                        if (Convert.ToInt32(row["Object_num"].ToString()) == 8) //page1 bleedbox
                        {
                            mem.Position -= 7;
                            mem.Position += 80;
                            int iInsOffs = (int)mem.Position;

                            sTemp = @"/MediaBox [" + Media_x1.ToString().Replace(",", ".") + " " + Media_y1.ToString().Replace(",", ".") + " "
                                + Media_x2.ToString().Replace(",", ".") + " " + Media_y2.ToString().Replace(",", ".") + "]" + '\x0a' +
                                @"/BleedBox [" + Bleed_x1.ToString().Replace(",", ".") + " " + Bleed_y1.ToString().Replace(",", ".") + " "
                                + Bleed_x2.ToString().Replace(",", ".") + " " + Bleed_y2.ToString().Replace(",", ".") + "]" + '\x0a' +
                                @"/TrimBox [" + Crop_x1.ToString().Replace(",", ".") + " " + Crop_y1.ToString().Replace(",", ".") + " "
                                + Crop_x2.ToString().Replace(",", ".") + " " + Crop_y2.ToString().Replace(",", ".") + "]" + '\x0a';

                            System.IO.MemoryStream mem1 = new System.IO.MemoryStream();

                            mem1.Write(mem.GetBuffer(), 0, (int)mem.Length);
                            mem.Write(ASCIenc.GetBytes(sTemp), 0, sTemp.Length);
                            int iMemOffs = (int)mem.Position;
                            mem1.Seek(iInsOffs, System.IO.SeekOrigin.Begin);
                            byte[] buf2 = new byte[mem1.Length - mem1.Position];
                            mem1.Read(buf2, 0, buf2.Length);
                            mem.Write(buf2, 0, buf2.Length);
                            mem.Position = iMemOffs;

                        }
                        #endregion

                        //Pages objects - 2 0 obj
                        if (Convert.ToInt32(row["Object_num"].ToString()) == 2)
                        {
                            mem.Position -= 7;
                            mem.Position += 31;
                            byte[] buf2 = new byte[14];
                            mem.Read(buf2, 0, 14);
                            Trace.WriteLine(buf2.ToString());

                        }

                        #region CropBox
                        if (Convert.ToInt32(row["Object_num"].ToString()) == 4)
                        {
                            mem.Position -= 7;
                            mem.Position += 9;
                            int iInsOffs = (int)mem.Position;

                            sTemp = @"[" + Crop_x1.ToString().Replace(",", ".") + " " + Crop_y1.ToString().Replace(",", ".") + " "
                                + Crop_x2.ToString().Replace(",", ".") + " " + Crop_y2.ToString().Replace(",", ".") + "]" + '\x0a';

                            System.IO.MemoryStream mem1 = new System.IO.MemoryStream();

                            mem1.Write(mem.GetBuffer(), 0, (int)mem.Length);
                            mem.Write(ASCIenc.GetBytes(sTemp), 0, sTemp.Length);
                            int iMemOffs = (int)mem.Position;
                            mem1.Seek(iInsOffs + 17, System.IO.SeekOrigin.Begin);
                            byte[] buf2 = new byte[mem1.Length - mem1.Position];
                            mem1.Read(buf2, 0, buf2.Length);
                            mem.Write(buf2, 0, buf2.Length);
                            mem.Position = iMemOffs;

                        }

                        #endregion
                    }

                    dsXRefTable.Tables[0].Rows.Add(row);
                    mem.Position += 3;
                }
                regMatch = regExpEOF.Match(sTemp);
                if (regMatch.Success)
                    break;

                regMatch = regXREF.Match(sTemp);
                if (regMatch.Success)
                {
                    iXrefPos = mem.Position - 8 + regMatch.Index;
                    break;
                }

                mem.Position -= 7;
            }
            System.DateTime end = new DateTime();
            end = System.DateTime.Now;
            System.TimeSpan diff = end.Subtract(start);

            System.Diagnostics.Trace.WriteLine(diff.TotalSeconds.ToString());
            System.Diagnostics.Trace.WriteLine("done");


        }

        private void ChangeXRefTableSitara()
        {
            System.IO.StreamWriter stremWriter = new System.IO.StreamWriter(mem);
            mem.Seek(iXrefPos, System.IO.SeekOrigin.Begin);
            System.Text.ASCIIEncoding ASCIenc = new System.Text.ASCIIEncoding();
            string sStr = "0";


            mem.Write(ASCIenc.GetBytes("xref\n"), 0, 5);

            sStr = "0 " + (dsXRefTable.Tables[0].Rows.Count + 1).ToString() + " \n";
            mem.Write(ASCIenc.GetBytes(sStr), 0, sStr.Length);

            sStr = "0";
            sStr = FillTo10(sStr) + " " + "65535" + " f \n";
            mem.Write(ASCIenc.GetBytes(sStr), 0, sStr.Length);

            for (int i = 0; i < dsXRefTable.Tables[0].Rows.Count; i++)
            {
                System.Data.DataRow[] rows = dsXRefTable.Tables[0].Select("Object_num=" + (i + 1).ToString());
                try
                {
                    sStr = FillTo10(rows[0]["Offset"].ToString()) + " " + "00000" + " n \n";
                }
                catch
                { }
                mem.Write(ASCIenc.GetBytes(sStr), 0, sStr.Length);
            }

            //trailer
            //
            sStr = "trailer\n<<\n/Size " + (dsXRefTable.Tables[0].Rows.Count + 1).ToString() + "\n/Root 1 0 R\n" +
                "/Info 40 0 R\n>>\nstartxref\n" + iXrefPos.ToString() + "\n%%EOF";
            mem.Write(ASCIenc.GetBytes(sStr), 0, sStr.Length);
            mem.SetLength(mem.Position);


            /*

                System.IO.FileStream fs=new System.IO.FileStream(sFileName+".tmp",System.IO.FileMode.Create);
                fs.Write(mem.GetBuffer(),0,(int)mem.Position);
                fs.Close();
                */
        }


        private void XRefTableToFile(string sFileName)
        {
            System.IO.StreamWriter strFile = new System.IO.StreamWriter(sFileName, false);
            string sStr = "0";

            strFile.Write("xref\n");
            strFile.Write("0 " + (dsXRefTable.Tables[0].Rows.Count + 1).ToString() + " \n");

            sStr = FillTo10(sStr) + " " + "65535" + " f \n";
            strFile.Write(sStr);

            for (int i = 0; i < dsXRefTable.Tables[0].Rows.Count; i++)
            {
                System.Data.DataRow[] rows = dsXRefTable.Tables[0].Select("Object_num=" + (i + 1).ToString());
                sStr = FillTo10(rows[0]["Offset"].ToString()) + " " + "00000" + " n \n";
                strFile.Write(sStr);
            }

            strFile.Close();
        }
        private void MemToFile(string sFileName)
        {
            System.IO.FileStream fs = new System.IO.FileStream(sFileName, System.IO.FileMode.Create);
            fs.Write(mem.GetBuffer(), 0, (int)mem.Length);
            fs.Close();
        }
        private string FillTo10(string sString)
        {
            while (sString.Length < 10)
                sString = "0" + sString;
            return sString;
        }

    }

    public class Log
    {
        System.IO.StreamWriter writer = null;
        readonly string sPath = "";

        public Log(string sLogPath)
        {
            sPath = sLogPath;

        }

        public void Write(string sText)
        {
            writer = new StreamWriter(sPath, true);
            writer.Write(System.DateTime.Now.Date.ToShortDateString() + " " + System.DateTime.Now.Date.ToShortTimeString() + ": ");
            writer.WriteLine(sText);
            writer.Flush();
            writer.Close();
        }

       ~Log()
        {

        }

    }
}