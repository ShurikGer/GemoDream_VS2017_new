using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.Diagnostics;
using System.Net;
using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;

//using QBFC4Lib;
//using QBXMLRP2Lib;
//using Interop.QBFC4;
//using Interop.QBXMLRP2;
//using System.Text.RegularExpressions;
//using Excel = Microsoft.Office.Interop.Excel;
//using CrystalReport;

//Working version
namespace gemoDream
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Client
    {
        public const int Manager = 1;
        public const int Grader = 2;
        public static string MyActivePrinter;
        public static string MyActiveReportName;
        public static bool ViewReport;
		

        /// <summary>
        /// Gets Xml node from the configuration file by it's name
        /// </summary>
        /// <param name="sTagName">node's name</param>
        /// <returns>xml node</returns>
        public static XmlNode GetXmlElement(string sTagName)
        {
			string sPath = "ClientCfg.xml";
			XmlNodeList xnlList = null;
			XmlDocument xdDoc = new XmlDocument();
			//sExMsg = "";

			//if (!File.Exists(sPath))
			//    throw new Exception("File not found");

			try
			{
				xdDoc.Load(sPath);
				xnlList = xdDoc.GetElementsByTagName(sTagName);
			}
			catch (Exception eEx)
			{
				string sErrMsg = "Couldn't get parameter " + sTagName + " from client configuration file.\n";
				throw new Exception(sErrMsg + eEx.Message);
			}

			return xnlList[0];
        }

        public static XmlNode GetXmlElement(string sTagName, XmlDocument xdDoc)
        {
            XmlNodeList xnlList = null;
            try
            {
                xnlList = xdDoc.GetElementsByTagName(sTagName);   
            
            }
            catch(Exception eEx)
            {
                string sErrMsg = "Couldn't get parameter " + sTagName;
                throw new Exception(sErrMsg+eEx.Message);
            }
            return xnlList[0];
        }
        
        public static string GetOfficeDirPath(string sTagName)
        {
            XmlNodeList xnlList = null;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc = Service.xmlOfficeCfg;
            //sExMsg = "";
			
            //if(!File.Exists(sPath))
            //throw new Exception("File not found");
			
            try
            {
                //xmlDoc.Load(Service.sDirConfigFile);
                xnlList = xmlDoc.GetElementsByTagName(sTagName);
            }
            catch(Exception eEx)
            {
                string sErrMsg = "Couldn't get parameter " + sTagName + " from file " + Service.sDirConfigFile + ".\n";
                throw new Exception(sErrMsg+eEx.Message);
            }
	
            return xnlList[0].InnerText.ToString();
        }

        public static string GetServerConfigByTagName(string sTagName)
        {
            XmlNodeList xnlList = null;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc = Service.xmlServiceConfig;
            //sExMsg = "";
			
            //if(!File.Exists(sPath))
            //throw new Exception("File not found");
			
            try
            {
                //xmlDoc.Load(Service.sDirConfigFile);
                xnlList = xmlDoc.GetElementsByTagName(sTagName);
            }
            catch(Exception eEx)
            {
                string sErrMsg = "Couldn't get parameter " + sTagName + " from file " + Service.sDirConfigFile + ".\n";
                throw new Exception(sErrMsg+eEx.Message);
            }
	
            return xnlList[0].InnerText.ToString();
        }

        //        public static string GetMeasureFormat(string sMeasureName)
        //        {
        ////            XmlNodeList xnlList = null;
        ////            XmlDocument xmlDoc = new XmlDocument();
        ////            xmlDoc = Service.xmlDocFormats;
        ////            string sTagName = "Format";
        ////
        ////            try
        ////            {
        ////                xnlList = xmlDoc.GetElementsByTagName(sTagName);
        ////
        ////   
        ////            }
        ////            catch{}
        //
        //
        //        }

        /// <summary>
        /// Sets xml node innertext to specified value
        /// </summary>
        /// <param name="sTagName">node's name</param>
        /// <param name="sValue">value</param>
        /// <returns>true if successfull, false otherwise</returns>
        public static bool SetXmlElementVal(string sTagName, string sValue, out string sErrorMsg)
        {
            string sPath = "ClientCfg.xml";
            XmlNodeList xnlList = null;
            XmlDocument xdDoc = new XmlDocument();
            sErrorMsg = "";
			
            //if(!File.Exists(sPath))
            //	throw new Exception("File not found");
			
            try
            {
                xdDoc.Load(sPath);
                xnlList = xdDoc.GetElementsByTagName(sTagName);
                xnlList[0].InnerText = sValue;
                xdDoc.Save(sPath);
            }
            catch(Exception eEx)
            {
                sErrorMsg = eEx.Message;
                return false;
            }
	
            return true;
        }	

        /// <summary>
        /// Gets xml nodes from xml keymap document by xPath
        /// </summary>
        /// 		/// <param name="sXPath">xPth string</param>
        /// <param name="sFileName">file name</param>
        /// <returns>list of xml nodes</returns>
        public static XmlNodeList GetXmlNodesByXPath(string sXPath, string sFileName)
        {
            XmlDocument xmlDoc = new XmlDocument();
            if (sFileName.IndexOf("MeasureKeymap.xml") == 0) 
                xmlDoc = Service.xmlDocMeasureKeyMap;
            if (sFileName.IndexOf("ColorKeymap.xml") == 0) 
                xmlDoc = Service.xmlDocColorKeyMap;
            if (sFileName.IndexOf("ClarityKeymap.xml") == 0) 
                xmlDoc = Service.xmlDocClarityKeyMap;
            if (sFileName.IndexOf("Formats.xml") == 0)
                xmlDoc = Service.xmlDocFormats;

            //xmlDoc.Load(sFileName);
            XmlNodeList xnlNodes;
            try
            {
                xnlNodes = xmlDoc.SelectNodes(sXPath);
            }
            catch(Exception ex)
            {
#if DEBUG
				string sMessage = ex.Message;
#endif
				throw new Exception("Pressed key is not available");
            }
				
            return xnlNodes;
        }
        //		public static XmlNodeList GetXmlNodesByXPath(string sXPath, XmlDocument xmlDoc)
        //		{
        //			//XmlDocument xmlDoc = new XmlDocument();
        //			//xmlDoc.Load(sFileName);
        //			XmlNodeList xnlNodes;
        //			try
        //			{
        //				xnlNodes = xmlDoc.SelectNodes(sXPath);
        //			}
        //			catch
        //			{
        //				throw new Exception("Pressed key is not available");
        //			}
        //				
        //			return xnlNodes;
        //		}
        public static void OperationsTreeRelationsAdd(DataSet dsData)
        {
            DataRelation drel;
            DataColumn parentCol;
            DataColumn childCol;

            for(int i = 0; i < dsData.Tables.Count; i++)
            {
                parentCol = dsData.Tables[i].Columns["ID"];

                foreach(DataTable dtTable in dsData.Tables)
                {		
                    if(Convert.ToInt32(dtTable.TableName.Substring(3, dtTable.TableName.Length - 3)) ==
                        Convert.ToInt32(dsData.Tables[i].TableName.Substring(3, dtTable.TableName.Length - 3)) - 1)
                    {
                        childCol = dtTable.Columns["ParentID"];			
                        drel = new DataRelation("Rel" + i.ToString(), parentCol, childCol);
                        dsData.Relations.Add(drel);
                    }					
                }
            }

            parentCol = dsData.Tables["tblOrder"].Columns["ID"];
            childCol = dsData.Tables["tblBatch"].Columns["ParentID"];			
            drel = new DataRelation("Order_EntryBacth", parentCol, childCol);
            dsData.Relations.Add(drel);

            parentCol = dsData.Tables["tblBatch"].Columns["ID"];
            childCol = dsData.Tables["tblItem"].Columns["ParentID"];			
            drel = new DataRelation("Batch_Item", parentCol, childCol);
            dsData.Relations.Add(drel);

            parentCol = dsData.Tables["tblItem"].Columns["ID"];
            childCol = dsData.Tables["tblDocument"].Columns["ItemID"];			
            drel = new DataRelation("Item_Document", parentCol, childCol);
            dsData.Relations.Add(drel);

            parentCol = dsData.Tables["tblOrder"].Columns["ID"];
            childCol = dsData.Tables["tblDocument"].Columns["OrderID"];			
            drel = new DataRelation("Order_Document", parentCol, childCol);
            dsData.Relations.Add(drel);
        }
        public static void KillOpenExcel()
        {
            Process[] myProcesses;
            myProcesses = Process.GetProcessesByName("EXCEL");
            //			if (myProcesses.Length > 0)
            //			{
            //				MessageBox.Show("Warning: You have open Excel/Excel file(s). Please, save it", "Open Excel file(s)",
            //					MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //			}

            //			foreach(Process myProcess in myProcesses)
            //			{
            //				myProcess.Kill();
            //				myProcess.WaitForExit();
            //			}
        }

        public static void OrdersTreeRelationsAdd(DataSet dsData)
        {
            DataRelation drel;
            DataColumn parentCol;
            DataColumn childCol;
            /*			
                        parentCol = dsData.Tables["tblOrder"].Columns["ID"];
                        childCol = dsData.Tables["tblEntryBatch"].Columns["ParentID"];			
                        drel = new DataRelation("Order_EntryBacth", parentCol, childCol);
                        dsData.Relations.Add(drel);

                        parentCol = dsData.Tables["tblEntryBatch"].Columns["ID"];
                        childCol = dsData.Tables["tblBatch"].Columns["ParentID"];			
                        drel = new DataRelation("EntryBatch_Batch", parentCol, childCol);
                        dsData.Relations.Add(drel);
            */

            parentCol = dsData.Tables["tblOrder"].Columns["ID"];
            childCol = dsData.Tables["tblBatch"].Columns["ParentID"];			
            drel = new DataRelation("Order_EntryBacth", parentCol, childCol);
            dsData.Relations.Add(drel);

            parentCol = dsData.Tables["tblBatch"].Columns["ID"];
            childCol = dsData.Tables["tblItem"].Columns["ParentID"];			
            drel = new DataRelation("Batch_Item", parentCol, childCol);
            dsData.Relations.Add(drel);

            parentCol = dsData.Tables["tblItem"].Columns["ID"];
            childCol = dsData.Tables["tblDocument"].Columns["ItemID"];			
            drel = new DataRelation("Item_Document", parentCol, childCol);
            dsData.Relations.Add(drel);

            parentCol = dsData.Tables["tblOrder"].Columns["ID"];
            childCol = dsData.Tables["tblDocument"].Columns["OrderID"];			
            drel = new DataRelation("Order_Document", parentCol, childCol);
            dsData.Relations.Add(drel);
        }

        public static void OrdersTreeServiceColumnsAdd(DataSet dsData)
        {
            foreach(DataTable table in dsData.Tables)
            {
                table.Columns.Add("SysCode");
                table.Columns.Add("Hide");
				
                foreach(DataRow row in table.Rows)
                {
                    row["SysCode"] = table.Compute("Count(ID)","").ToString();
                    row["Hide"] = "0";
                }

                DataColumn[] keys = new DataColumn[1];
                keys[0] = table.Columns["SysCode"];
                table.PrimaryKey = keys;
            }
        }
        public static void UpdateQBLog(string sRow)
        {
            string sLogPath = Service.sAppDir + "/qb.log";
			
            if(!File.Exists(sLogPath))
                using(FileStream fsCreate = new FileStream(sLogPath, FileMode.Create)){}
			
            using(FileStream fsWrite = new FileStream(sLogPath, FileMode.Open, FileAccess.Write))
            {
                try
                {
                    fsWrite.Position = fsWrite.Length;
                    Byte[] bInfo = new UTF8Encoding(true).GetBytes("\n"+sRow);
                    fsWrite.Write(bInfo, 0, bInfo.Length);
                }
                catch{}
                finally
                {
                    if(fsWrite != null)
                        fsWrite.Close();
                }
            }

        }
    }


    public class PictureAndPath
    {
        public Image imPicture;
        public string sPath2Picture;
        public Image imIcon;
        public string sPath2Icon;
    }

    public class Service
    {
        private static  gemoDreamService.GdrService srv = null;	// web service object
        public static int iUserId = -1;		// client user identifier
        public static int iOfficeId = -1;		// client office identifier
        private static readonly int iOfficeCode = -1;		// client office code
        private static string sDepartmentId = "";	// client department identifier
        private static string sDepartmentName = "";	// client department name
        private static string sUser = "";			// client user name
        //private static int iDepartmentOfficeId = -1;	// client department identifier
        private static string sSessionId = "";		// session identifier
        private const char Splitter = '_';			// splitter
        private static string sVersion;//"1.3.10";	// GemoDream version
        public static string sProgramTitle;		// GemoDream version
        public static string sTitle; 		//GemoDream version
        public static string sAppDir = "";
        public static string sTempDir = "";
        public static string sProgramFileFolder = "";
        public static string sOfficeGroup = ""; //Office group
        public static string sDirConfigFile = ""; //Office XML config file
        public static string sIP_AddressTest = "";
        public static Log log=null;
        public static XmlDocument xmlOfficeCfg; // - office config XmlDocument
        public static XmlDocument xmlDocMeasureKeyMap;// Measure Keys Map XmlDocument();
        public static XmlDocument xmlDocColorKeyMap; // Color Keys Map XmlDocument();
        public static XmlDocument xmlDocClarityKeyMap;// Clarity Keys Map XmlDocument();
        public static XmlDocument xmlDocFormats;
        public static XmlDocument xmlServiceConfig; //service config XmlDocument
        public static XmlDocument xmlPrinters;
        public static XmlDocument xmlOffices; //list of offices and IP group
		public static bool IsMemo = false;
        public static DataSet dsRestrictedNumbers;
		//public static string  sIP_Group = "";
        
        static Service()
        {
            XmlNode xnNode = Client.GetXmlElement("serverUrl");
            string sMyServiceName = xnNode.InnerText;
            //sMyServiceName = sMyServiceName.Substring(sMyServiceName.IndexOf("/"), sMyServiceName.LastIndexOf("/"));
            string[] sWebService = sMyServiceName.Split('/');

			Version verVersion = System.Reflection.Assembly.GetAssembly(typeof(Service)).GetName().Version;
            sVersion = verVersion.Major.ToString() + "."  + verVersion.Minor.ToString("#00");
#if DEBUG
			sTitle = " v. " + sVersion + "." + verVersion.Build.ToString("#00") + "." + verVersion.Revision.ToString("#00") + " " /*+ " (VS2017) "*/ + sWebService[3];
#else
             sTitle = " v. " + sVersion + "." + verVersion.Build.ToString("#00") + "." + verVersion.Revision.ToString("#00") + " "; // + " (VS2017) ";
#endif
			sProgramTitle = ""; //"GemoDream v" + sVersion + "."  + verVersion.Build + " ";
            //sProgramTitle = sLogin + sProgramTitle;
        }


        /// <summary>
        /// Function returns measures output formats from server
        /// </summary>
        /// <returns></returns>
        public static DataSet GetMeasuresFormats()
        {			
            return srv.GetMeasuresFormats();			 
        }

        public static int iInvoiceDebugLevel = 4; 
        // iInvoiceDebugLevel < 1 - don't generate data for invoice
        // iInvoiceDebugLevel < 2 - don't call DBAddInvoice
        // iInvoiceDebugLevel < 3 - don't show warnings
        // iInvoiceDebugLevel < 4 - don't use QuickBook

        /// Current Department identifier
        public static string Department
        {
            get
            {
                return sDepartmentId;
            }
            set
            {
                sDepartmentId = value;
            }
        }

        /// Current Department name
        public static string DepartmentName
        {
            get
            {
                return sDepartmentName;				
            }
            set
            {
                sDepartmentName = value;
            }
        }

        /// Current User
        public static string User
        {
            get
            {
                return sUser;
            }
        }


#region Login
        /// <summary>
        /// Creates service object
        /// </summary>
        public static void CreateService()
        {
            srv = new gemoDreamService.GdrService();
			
            try
            {
				XmlNode xnNode = Client.GetXmlElement("serverUrl");
                srv.Url = xnNode.InnerText;
				
				string stemp = srv.Url.Substring(srv.Url.IndexOf("//") + 2);
#if DEBUG
				//string stemp = srv.Url.Substring(srv.Url.IndexOf("//") + 2);
				sTitle = sTitle + "," + stemp.Substring(0, stemp.IndexOf('/')) + ", "; 
				//sTitle = sTitle + "," + stemp.Substring(0, stemp.IndexOf('/')) + " ";    //srv.Url.Substring(srv.Url.IndexOf("//") + 2, srv.Url..LastIndexOf('/') - srv.Url.IndexOf('/') - 1) + " ";
#endif
			}
            catch(Exception eEx)
            {
                string sErrMsg = "Couldn't get server name from local configuration file.\n";
                throw new Exception(sErrMsg+eEx.Message);
            }
        }

        /// <summary>
        /// Checks login and password
        /// </summary>
        /// <param name="login">login</param>
        /// <param name="password">password</param>
        /// <param name="department">department</param>
        /// <returns>true if login successfull and false otherwise</returns>
        public static Int32 Login(string login, string password, string department, out DataSet dsAccess)
        {
            //string[] sSplitedDepartment = department.Split(Splitter);
            //int iDepartmentOfficeId = Convert.ToInt16(sSplitedDepartment[0]);
            //int iDepartmentId = Convert.ToInt32(sSplitedDepartment[1]);
            int iDepartmentOfficeId = 0;
            int iDepartmentId = 0;

			ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

			sSessionId = srv.Login(login, password, iDepartmentId, iDepartmentOfficeId, out dsAccess);
            if(sSessionId == "")
                return 1;

            sUser = login;

            //string sErrorMsg;
            //if(department != sDepartmentId)
            //	if(!Client.SetXmlElementVal("department", department, out sErrorMsg))
            //		MessageBox.Show("Couldn't save configuration changes\n"+sErrorMsg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

			
            DataSet dsUser = new DataSet();
            dsUser.Tables.Add("Authors");
            dsUser.Tables[0].Columns.Add("Login",System.Type.GetType("System.String"));
            dsUser.Tables[0].Columns.Add("DepartmentID",System.Type.GetType("System.String"));
            dsUser.Tables[0].Columns.Add("DepartmentOfficeID",System.Type.GetType("System.String"));
            dsUser.Tables[0].Columns.Add("Password",System.Type.GetType("System.String"));
            dsUser.Tables[0].Columns.Add("UserID",System.Type.GetType("System.String"));
            dsUser.Tables[0].Columns.Add("UserOfficeID",System.Type.GetType("System.String"));
            dsUser.Tables[0].Rows.Add(dsUser.Tables[0].NewRow());
            dsUser.Tables[0].Rows[0]["Login"] = login;
            dsUser.Tables[0].Rows[0]["Password"] = password;
            //dsUser.Tables[0].Rows[0]["DepartmentID"] = iDepartmentId;
            //dsUser.Tables[0].Rows[0]["DepartmentOfficeID"] = iDepartmentOfficeId;
            dsUser = ProxyGenericGet(dsUser);
            try
            {
                iUserId = Convert.ToInt32(dsUser.Tables[0].Rows[0]["UserID"].ToString());
                iOfficeId = Convert.ToInt32(dsUser.Tables[0].Rows[0]["OfficeID"].ToString());
            }
            catch{}

            //if (IsVersionCorrect())
                return 0;
            //else return 2;
        }

        /// <summary>
        /// Method compares DB and client versions. If different login fails.
        /// </summary>
        /// <returns></returns>

        //Added by _3ter on Zeltser's request on 12.23.2005
        public static Boolean IsVersionCorrect()
        {
            //for test only:
            //return true;
            //end of test 

            DataSet dsVer = new DataSet();
            DataTable dtVer = new DataTable("DBVersion");
            dsVer.Tables.Add(dtVer);

            try
            {
                dsVer = ProxyGenericGet(dsVer);
                if (dsVer.Tables["DBVersion"].Rows[0]["version"].ToString().Split(new Char[] {' '})[0] == "v" + Service.sVersion)
                    return true;
                else return false;
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message, "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }			
        }

        public static bool ConsoleLogin(string login, string password, string department, out DataSet dsAccess)
        {
            string[] sSplitedDepartment = department.Split(Splitter);
            int iDepartmentOfficeId = Convert.ToInt16(sSplitedDepartment[0]);
            int iDepartmentId = Convert.ToInt32(sSplitedDepartment[1]);

            sSessionId = srv.ConsoleLogin(login, password, out dsAccess);
            if(sSessionId == "")
                return false;

            sUser = login;

            //string sErrorMsg;
            /*
            if(department != sDepartmentId)
                if(!Client.SetXmlElementVal("department", department, out sErrorMsg))
                    MessageBox.Show("Couldn't save configuration changes\n"+sErrorMsg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            */

			
            DataSet dsUser = new DataSet();
            dsUser.Tables.Add("Authors");
            dsUser.Tables[0].Columns.Add("Login",System.Type.GetType("System.String"));
            dsUser.Tables[0].Columns.Add("DepartmentID",System.Type.GetType("System.String"));
            dsUser.Tables[0].Columns.Add("DepartmentOfficeID",System.Type.GetType("System.String"));
            dsUser.Tables[0].Columns.Add("Password",System.Type.GetType("System.String"));
            dsUser.Tables[0].Columns.Add("UserID",System.Type.GetType("System.String"));
            dsUser.Tables[0].Columns.Add("UserOfficeID",System.Type.GetType("System.String"));
            dsUser.Tables[0].Rows.Add(dsUser.Tables[0].NewRow());
            dsUser.Tables[0].Rows[0]["Login"] = login;
            dsUser.Tables[0].Rows[0]["Password"] = password;
            dsUser.Tables[0].Rows[0]["DepartmentID"] = iDepartmentId;
            dsUser.Tables[0].Rows[0]["DepartmentOfficeID"] = iDepartmentOfficeId;
            dsUser = ProxyGenericGet(dsUser);
            try
            {
                iUserId = Convert.ToInt32(dsUser.Tables[0].Rows[0]["UserID"].ToString());
                iOfficeId = Convert.ToInt32(dsUser.Tables[0].Rows[0]["OfficeID"].ToString());
            }
            catch{}

            return true;

        }

        /// <summary>
        /// Loggs of from service
        /// </summary>
        public static void Logoff()
        {
            srv.Logoff(sSessionId);
        }

        /// <summary>
        /// Gets current office departments
        /// </summary>
        /// <returns>office deoartments</returns>
        public static DataSet GetOfficeDepartments()
        {
            try
            {
                return srv.GetOfficeDepartments(iOfficeCode);
            }
            catch(Exception eEx)
            {
                string sErrMsg = "Couldn't load departments from the DataBase.\n";
                throw new Exception(sErrMsg+eEx.Message);
            }
        }

        /// <summary>
        /// Gets office code from service configuration file
        /// </summary>
        public static void GetOfficeCode()
        {
            try
            {
                //iOfficeCode = srv.GetOfficeCode();
            }
            catch(Exception eEx)
            {
                string sErrMsg = "Couldn't get office code from service configuration file.\n";
                throw new Exception(sErrMsg+eEx.Message);
            }
        }
#endregion

        public static void SetDepartmentOfficeId(string DepartmentOfficeId)
        {
            int iDepartmentOfficeId = 0;
            string SessionId = sSessionId;
            try
            {
                iDepartmentOfficeId = int.Parse(DepartmentOfficeId);
                Department = DepartmentOfficeId;
				
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
            }
            try
            {
                srv.SetDepartmentOfficeId(iDepartmentOfficeId,SessionId);
            }
            catch(Exception eEx)
            {
                if(eEx.Message.IndexOf("Session doesn't exist or expired. Retry to log on") == -1)
                    throw eEx;
				
                ReLoginForm rlLogin = new ReLoginForm();
                rlLogin.ShowDialog();
                srv.SetDepartmentOfficeId(iDepartmentOfficeId,SessionId);
            }
			
        }

#region Proxy service
        /// <summary>
        /// Proxy call of service function 'GenericGetProcedure'
        /// </summary>
        /// <param name="dsParameters">parameters of procedure</param>
        /// <returns>dataset with information from the db</returns>
        public static DataSet ProxyGenericGet(DataSet dsParameters)
        {
            DataSet dsReturnData = null;
            try
            {
                dsReturnData = srv.GenericGetProcedure(sSessionId, dsParameters);
            }
            catch(Exception eEx)
            {
                if(eEx.Message.IndexOf("Session doesn't exist or expired. Retry to log on") == -1)
                    throw eEx;
				
                ReLoginForm rlLogin = new ReLoginForm();
                rlLogin.ShowDialog();
                dsReturnData = srv.GenericGetProcedure(sSessionId, dsParameters);
                //dsReturnData = ProxyGenericGet(dsParameters);
            }
			
            return dsReturnData;
        }

        /// <summary>
        /// Proxy call of service function 'GenericSetProcedure'
        /// </summary>
        /// <param name="dsParameters">dataset with parameters</param>
        /// <param name="sHeader">header</param>
        /// <returns>dataset with information from the db</returns>
        /// 

        /**
         * Make XML file for define documents
         * vetal_242
         * 27.02.2006
         * */
        void MakeXML3(string sOrderCode, string sBatchCode, string sDocumentID, string sBatchID)
        {
            string sSendPath = GetServiceCfgParameter("sendDir");//gemoDreamService.ServiceLibrary.getXmlElement("sendDir");
            string sTableName= FillToFiveChars(sOrderCode) + FillToThreeChars(sBatchCode);
            string sReportNameTemplate=sSendPath+"{0}."+sTableName+".xml";
			
            DataSet dsDoc = GetDocument(sDocumentID);
            //Service.GetDocument(sDocumentID);
            DataRow row = dsDoc.Tables[0].Rows[0];

            //spGetBatch
            string sItemTypeID = GetItemTypeIDByBatchID(sBatchID);
            //Service.GetItemTypeIDByBatchID(sBatchID);

            //spGetItemType
            string sPath2Picture = GetPath2Picture(sItemTypeID);
            //Service.GetPath2Picture(sItemTypeID);

            string sItemContainerName = GetItemContainerName(sItemTypeID);
            //Service.GetItemContainerName(sItemTypeID);

            string sReportGroup = row["DocumentTypeName"].ToString();
            string sReportName = String.Format(sReportNameTemplate, sReportGroup);
			

            bool bUseDate = row["UseDate"].ToString().Equals("1");
			
            bool bUseVVN = row["UseVirtualVaultNumber"].ToString().Equals("1");

            string sBarCode = row["BarCodeFixedText"].ToString();

            //DataSet dsMeasures = new DataSet();
            //dsMeasures.Tables.Add(Service.GetMeasuresByItemType2(sItemTypeID));
            DataSet dsShapes = GetShapesByBatchID(sBatchID);
            //Service.GetShapesByBatchID(sBatchID);
            //gemoDream.Service.debug_DiaspalyDataSet(dsShapes);
            DataSet dsValues = GetDocumentValues(sDocumentID);
			//Service.GetDocumentValues(sDocumentID);
			XMLData xmlData = new XMLData
			{
				sReportGroup = row["DocumentTypeName"].ToString(),
				sItemPrefix = row["DocumentOperationChar"].ToString(),
				sFileName = row["CorelFile"].ToString(),
				sPicture = sPath2Picture,
				UseVVN = bUseVVN,
				sBarCode = sBarCode,
				UseDate = bUseDate
			};
			SaveXML(sReportName, sItemContainerName, xmlData, dsShapes, dsValues);
        }

        public static DataSet ProxyGenericSet(DataSet dsParameters, string sHeader)
        {
            DataSet dsReturnData = null;
            try
            {
#if DEBUG
				try
				{
					// For debugging only
					if (dsParameters.Tables[0].TableName.ToUpper().Contains("CPDOCRULE"))
					{
						string filename = "C:/DELL/myXml_CPRules_before_setCDDocRule.xml";
						if (File.Exists(filename)) File.Delete(filename);
						// Create the FileStream to write with.
						FileStream myFileStream = new FileStream(filename, System.IO.FileMode.Create);
						// Create an XmlTextWriter with the fileStream.
						System.Xml.XmlTextWriter myXmlWriter = new System.Xml.XmlTextWriter(myFileStream, System.Text.Encoding.Unicode);
						// Write to the file with the WriteXml method.
						dsParameters.WriteXml(myXmlWriter);
						myXmlWriter.Close();
						// End of debugging part
					}
				}
				catch
				{ }
#endif
				dsReturnData = srv.GenericSetProcedure(sSessionId, dsParameters, sHeader);
#if DEBUG
				try
				{
					// For debugging only
					if (dsParameters.Tables[0].TableName.ToUpper().Contains("CPDOCRULE"))
					{
						string filename = "C:/DELL/myXml_CPRulesDetails.xml";
						if (File.Exists(filename)) File.Delete(filename);
						// Create the FileStream to write with.
						FileStream myFileStream = new FileStream(filename, System.IO.FileMode.Create);
						// Create an XmlTextWriter with the fileStream.
						System.Xml.XmlTextWriter myXmlWriter = new System.Xml.XmlTextWriter(myFileStream, System.Text.Encoding.Unicode);
						// Write to the file with the WriteXml method.
						dsReturnData.WriteXml(myXmlWriter);
						myXmlWriter.Close();
						// End of debugging part
					}
				}
				catch
				{ }
#endif
			}
			catch (Exception eEx)
            {
                if(eEx.Message.IndexOf("Session doesn't exist or expired. Retry to log on") == -1)
                    throw eEx;
				
                ReLoginForm rlLogin = new ReLoginForm();
                rlLogin.ShowDialog();
                dsReturnData = srv.GenericSetProcedure(sSessionId, dsParameters, sHeader);
                //dsReturnData = ProxyGenericSet(dsParameters, sHeader);
            }

            return dsReturnData;
        }

        /// <summary>
        /// Proxy call of service function 'GenericGetByIdProcedure'
        /// </summary>
        /// <param name="sId">identifier</param>
        /// <param name="sName">table name</param>
        /// <returns>dataset with information from the db</returns>
        public static DataSet ProxyGenericGetById(string sId, string sName)
        {
            DataSet dsReturnData = null;
            try
            {
                dsReturnData = srv.GenericGetById(sSessionId, sId, sName);
            }
            catch(Exception eEx)
            {
                if(eEx.Message.IndexOf("Session doesn't exist or expired. Retry to log on") == -1)
                    throw eEx;
				
                ReLoginForm rlLogin = new ReLoginForm();
                rlLogin.ShowDialog();
                dsReturnData = srv.GenericGetById(sSessionId, sId, sName);
                //dsReturnData = ProxyGenericGetById(sId, sName);
            }

            return dsReturnData;
        }

        /// <summary>
        /// Proxy call of service function 'QBAddCustomer'
        /// </summary>
        /// <param name="dsCustomer">customer information</param>
        /// <returns>QB information</returns>
        /*
        public static DataSet ProxyQBAddCustomer(DataSet dsCustomer)
        {
            DataSet dsReturnData = null;
            try
            {
                //dsReturnData = srv.QBAddCustomer(sSessionId, dsCustomer);
                dsReturnData = QBAddCustomerLib(dsCustomer);
            }
            catch(Exception eEx)
            {
                if(eEx.Message.IndexOf("Session doesn't exist or expired. Retry to log on") == -1)
                    throw eEx;
				
                ReLoginForm rlLogin = new ReLoginForm();
                rlLogin.ShowDialog();
                dsReturnData = srv.QBAddCustomer(sSessionId, dsCustomer);
                //dsReturnData = ProxyQBAddCustomer(dsCustomer);
            }

            return dsReturnData;
        }

        */
        /// <summary>
        /// Proxy call of service function 'QBModifyCustomer'
        /// </summary>
        /// <param name="dsCustomer">customer information</param>
        /// <returns>QB information</returns>
        /*
        public static DataSet ProxyQBModifyCustomer(DataSet dsCustomer)
        {
            DataSet dsReturnData = null;
            try
            {
                //dsReturnData = srv.QBModifyCustomer(sSessionId, dsCustomer);
                dsReturnData = QBModifyCustomerLib(dsCustomer);
            }
            catch(Exception eEx)
            {
                if(eEx.Message.IndexOf("Session doesn't exist or expired. Retry to log on") == -1)
                    throw eEx;
				
                ReLoginForm rlLogin = new ReLoginForm();
                rlLogin.ShowDialog();
                dsReturnData = srv.QBModifyCustomer(sSessionId, dsCustomer);
                //dsReturnData = ProxyQBModifyCustomer(dsCustomer);
            }

            return dsReturnData;
        }

        */
        /// <summary>
        /// Proxy call of service function 'QBAddInvoice'
        /// </summary>
        /// <param name="sBatchId_ItemCode">concatenated batch identifier and item code</param>
        /*
        public static void ProxyQBAddInvoice(string sBatchId_ItemCode)
        {
            try
            {
                //srv.QBAddInvoice(sSessionId, sBatchId_ItemCode);
                QBAddItemInvoiceLib(sBatchId_ItemCode);
            }
            catch(Exception eEx)
            {
                if(eEx.Message.IndexOf("Session doesn't exist or expired. Retry to log on") == -1)
                    throw eEx;
				
                ReLoginForm rlLogin = new ReLoginForm();
                rlLogin.ShowDialog();
                srv.QBAddInvoice(sSessionId, sBatchId_ItemCode);
                //ProxyQBAddInvoice(sBatchId_ItemCode);
            }
        }

        */
        /// <summary>
        /// Proxy call of service function 'QBAddGroupInvoice'
        /// </summary>
        /// <param name="sGroupId_GroupOfficeId">concatenated group identifier and groupoffice identifier</param>
        /*
        public static void ProxyQBAddGroupInvoice(string sGroupOfficeID_GroupID)
        {
            try
            {
                //srv.QBAddInvoice(sSessionId, sBatchId_ItemCode);
                QBAddGroupInvoiceLib(sGroupOfficeID_GroupID);
            }
            catch(Exception eEx)
            {
                if(eEx.Message.IndexOf("Session doesn't exist or expired. Retry to log on") == -1)
                    throw eEx;
				
                ReLoginForm rlLogin = new ReLoginForm();
                rlLogin.ShowDialog();
                //srv.QBAddInvoice(sSessionId, sGroupId_GroupOfficeId);
                //ProxyQBAddInvoice(sBatchId_ItemCode);
            }
        }

        */
        /// <summary>
        /// Proxy call of service function 'SendMail'
        /// 		/// </summary>
        /// <param name="sTo">reciever's e-mail</param>
        /// <param name="sAttach">attach file</param>
        /// <param name="sSubject">e-mail subect</param>
        /// <returns>true if success and false otherwise</returns>
        public static bool ProxySendMail(string sTo, string sAttach, string sSubject)
        {
            try
            {
                srv.SendMail(sSessionId, sTo, sAttach, sSubject);
            }
            catch(Exception eEx)
            {
                if(eEx.Message.IndexOf("Session doesn't exist or expired. Retry to log on") == -1)
                    throw eEx;
				
                ReLoginForm rlLogin = new ReLoginForm();
                rlLogin.ShowDialog();
                srv.SendMail(sSessionId, sTo, sAttach, sSubject);
                //ProxySendMail(sTo, sAttach, sSubject);
            }

            return true;
        }

        /// <summary>
        /// Proxy call of service function 'SendBatchByFax'
        /// </summary>
        /// <param name="dsOrder">order information</param>
        /// <param name="sExt">attached file extention</param>
        /// <param name="sTo">reciever's e-mail</param>
        /// <param name="sSubject">e-mail subject</param>
        public static void ProxySendBatchByFax(DataTable dtOrder, string sExt, string sTo, string sSubject,string sFileName)
        {
            DataSet dsOrder = new DataSet();
            dsOrder.Tables.Add(dtOrder);
            try
            {
                srv.SendBatchByFax(sSessionId, dsOrder, sExt, sTo, sSubject,sFileName);
            }
            catch(Exception eEx)
            {
                if(eEx.Message.IndexOf("Session doesn't exist or expired. Retry to log on") == -1)
                    throw eEx;
				
                ReLoginForm rlLogin = new ReLoginForm();
                rlLogin.ShowDialog();
				
                srv.SendBatchByFax(sSessionId, dsOrder, sExt, sTo, sSubject,sFileName);
                //ProxySendBatchByFax(dsOrder, sExt, sTo, sSubject);
            }
        }

        public static void ProxySendXLEmail(string sTo, string sFileName, string sSubject)
        {			
            try
            {
                srv.SendMail(sSessionId, sTo, sFileName, sSubject);
            }
            catch(Exception eEx)
            {
                if(eEx.Message.IndexOf("Session doesn't exist or expired. Retry to log on") == -1)
                    throw eEx;
				
                ReLoginForm rlLogin = new ReLoginForm();
                rlLogin.ShowDialog();
				
                srv.SendMail(sSessionId, sTo, sFileName, sFileName);
                //ProxySendBatchByFax(dsOrder, sExt, sTo, sSubject);
            }
        }

        public static void ProxySendCancelledDocs(string sDocsName)
        {			
            //			try
            //			{
            //				string sBody = "NOTE: The previously ordered document [" + sDocsName + "] has been cancelled.";
            //				srv.SendMailCancelledDocs(sSessionId, sBody);
            //			}
            //			catch(Exception eEx)
            //			{
            //				if(eEx.Message.IndexOf("Session doesn't exist or expired. Retry to log on") == -1)
            //					throw eEx;
            //				
            //				ReLoginForm rlLogin = new ReLoginForm();
            //				rlLogin.ShowDialog();
            //				
            //				string sBody = "The previously ordered document [" + sDocsName + "] has been cancelled.";
            //				srv.SendMailCancelledDocs(sSessionId, sBody);
            //			}
        }
		
        public static void ProxySendBatchByFax1(string sFileName, string sTo, string sSubject)
        {
			
            try
            {
                srv.SendBatchByFax1(sSessionId, sFileName, sTo, sSubject);
            }
            catch(Exception eEx)
            {
                if(eEx.Message.IndexOf("Session doesn't exist or expired. Retry to log on") == -1)
                    throw eEx;
				
                ReLoginForm rlLogin = new ReLoginForm();
                rlLogin.ShowDialog();
                srv.SendBatchByFax1(sSessionId, sFileName, sTo, sSubject);
                //ProxySendBatchByFax(dsOrder, sExt, sTo, sSubject);
            }
        }

        /// <summary>
        /// Proxy call of service function 'SendDocument'
        /// </summary>
        /// <param name="sTemplatePath">path to report template</param>
        /// <param name="sSendPath">send path</param>
        /// <param name="sFileExt">sent file path</param>
        /// <param name="iOrderCode">order code</param>
        /// <param name="iBatchCode">batch code</param>
        /// <param name="iItemCode">item code</param>
        /// <param name="dsBatch">batch information</param>
        /// <param name="dsItem">item information</param>
        /// <param name="dsItemType">item type information</param>
        /// <param name="sDocChar">document char</param>
        /// <param name="dsShape">shape information</param>
        public static void ProxySendDocument(string sTemplatePath, string sSendPath, string sFileExt, int iOrderCode, int iBatchCode, int iItemCode, DataSet dsBatch, DataSet dsItem, DataSet dsItemType, string sDocChar, DataSet dsShape)
        {
            try
            {
                srv.SendDocument(sSessionId, sTemplatePath, sSendPath, sFileExt, iOrderCode, iBatchCode, iItemCode, dsBatch, dsItem, dsItemType, sDocChar, dsShape);
            }
            catch(Exception eEx)
            {
                if(eEx.Message.IndexOf("Session doesn't exist or expired. Retry to log on") == -1)
                    throw eEx;
				
                ReLoginForm rlLogin = new ReLoginForm();
                rlLogin.ShowDialog();
                srv.SendDocument(sSessionId, sTemplatePath, sSendPath, sFileExt, iOrderCode, iBatchCode, iItemCode, dsBatch, dsItem, dsItemType, sDocChar, dsShape);
                //ProxySendDocument(sTemplatePath, sSendPath, sFileExt, iOrderCode, iBatchCode, iItemCode, dsBatch, dsItem, dsItemType, sDocChar, dsShape);
            }
        }

        /// <summary>
        /// Proxy call of service function 'AddGraderData'
        /// </summary>
        /// <param name="sPath">path</param>
        /// <param name="rid">identifier</param>
        /// <returns>time when information was added</returns>
        public static DateTime ProxyAddGraderData(string sPath,string sPartID, out string rid)
        {
            DateTime dtTime = DateTime.Now;
            rid = "";
            try	
            {
				string fileData = File.ReadAllText(sPath);
				
				dtTime = srv.AddGraderData(sSessionId, sPath,sPartID, out rid);
            }
            catch(Exception eEx)
            {
                if(eEx.Message.IndexOf("Session doesn't exist or expired. Retry to log on") == -1)
                    throw eEx;
				
                ReLoginForm rlLogin = new ReLoginForm();
                rlLogin.ShowDialog();
                dtTime = srv.AddGraderData(sSessionId, sPath,sPartID, out rid);
                //dtTime = ProxyAddGraderData(sPath, out rid);
            }

            return dtTime;
        }

        /// <summary>
        /// Proxy call of service function 'AddPrices'
        /// </summary>
        /// <param name="sPath">path</param>
        /// <param name="dsCodes">codes</param>
        /// <param name="dsData">data</param>
        /// <param name="rid">identifier</param>
        /// <returns>time when information was added</returns>
        public static DateTime ProxyAddPrices(string sPath, DataSet dsCodes, DataSet dsData, out string rid)
        {
            DateTime dtTime = DateTime.Now;
            rid = "";
            try
            {
                dtTime = srv.AddPrices(sSessionId, sPath, dsCodes, dsData, out rid);
            }
            catch(Exception eEx)
            {
                if(eEx.Message.IndexOf("Session doesn't exist or expired. Retry to log on") == -1)
                    throw eEx;
				
                ReLoginForm rlLogin = new ReLoginForm();
                rlLogin.ShowDialog();
                dtTime = srv.AddPrices(sSessionId, sPath, dsCodes, dsData, out rid);
                //dtTime = ProxyAddPrices(sPath, dsCodes, dsData, out rid);
            }

            return dtTime;
        }

        /// <summary>
        /// Proxy call of service function 'GetGraderDir'
        /// </summary>
        /// <returns>grader directory</returns>
        public static string ProxyGetGraderDir()
        {
            string sGraderDir = "";
            try
            {
                sGraderDir = srv.GetGraderDir(sSessionId);
            }
            catch(Exception eEx)
            {
                if(eEx.Message.IndexOf("Session doesn't exist or expired. Retry to log on") == -1)
                    throw eEx;
				
                ReLoginForm rlLogin = new ReLoginForm();
                rlLogin.ShowDialog();
                sGraderDir = srv.GetGraderDir(sSessionId);
                //sGraderDir = ProxyGetGraderDir();
            }

            return sGraderDir;
        }

        /// <summary>
        /// Proxy call of service function 'GetGraderKeymap'
        /// </summary>
        /// <param name="sFileName">keymap string</param>
        /// <returns></returns>///
        //		public static string GetGraderKeymap(string sFileName)
        //		{
        //			string sPath = gemoDreamService.GdrService.sServicePath + "/"+sFileName;
        //			XmlNode xnKeymap = null;
        //			XmlDocument xdDoc = new XmlDocument();
        //			
        //			xdDoc.Load(sPath);
        //			xnKeymap = xdDoc.SelectSingleNode("/");
        //			
        //			return xnKeymap.InnerXml;
        //		}
        public static string ProxyGetGraderKeymap(string sFileName)
        {
            string sGraderKeymap = "";
            //            MessageBox.Show("ProxyGetGraderKeymap: " + sFileName);
            try
            {
                sGraderKeymap = srv.GetGraderKeymap(sSessionId, sFileName);
            }
            catch(Exception eEx)
            {
                if(eEx.Message.IndexOf("Session doesn't exist or expired. Retry to log on") == -1)
                    throw eEx;
				
                ReLoginForm rlLogin = new ReLoginForm();
                rlLogin.ShowDialog();
                sGraderKeymap = srv.GetGraderKeymap(sSessionId, sFileName);
                //sGraderKeymap = ProxyGetGraderKeymap(sFileName);
            }

            return sGraderKeymap;
        }

        /// <summary>
        /// Proxy call of service function 'GetServiceCfgParameter'
        /// </summary>
        /// <param name="sParameter">service configuration parameter name</param>
        /// <returns>service configuration parameter</returns>
        public static string ProxyGetServiceCfgParameter(string sParameter)
        {
            string sParameterValue = "";
            try
            {
                sParameterValue = srv.GetServiceCfgParameter(sSessionId, sParameter);
            }
            catch(Exception eEx)
            {
                if(eEx.Message.IndexOf("Session doesn't exist or expired. Retry to log on") == -1)
                    throw eEx;
				
                ReLoginForm rlLogin = new ReLoginForm();
                rlLogin.ShowDialog();
                sParameterValue = srv.GetServiceCfgParameter(sSessionId, sParameter);
                //sParameterValue = ProxyGetServiceCfgParameter(sParameter);
            }

            return sParameterValue;
        }

        /// <summary>
        /// Proxy call of service function 'GetImage'
        /// </summary>
        /// <param name="sFileName">file name</param>
        /// <returns>image</returns>
        public static string ProxyGetImage(string sFileName)
        {
            string sParameterValue = "";
            try
            {
                sParameterValue = srv.GetImage(sFileName);
            }
            catch(Exception eEx)
            {
                if(eEx.Message.IndexOf("Session doesn't exist or expired. Retry to log on") == -1)
                    throw eEx;
				
                ReLoginForm rlLogin = new ReLoginForm();
                rlLogin.ShowDialog();
                sParameterValue = srv.GetImage(sFileName);
            }

            return sParameterValue;
        }
#endregion

#region Front
        public static DataTable GetItemByCode(string GroupCode, string BatchCode, string ItemCode)
        {
            DataSet dsOrder = new DataSet();
            dsOrder.Tables.Add("ItemByCodeTypeEx");
            dsOrder = ProxyGenericGet(dsOrder);
            DataTable table = dsOrder.Tables[0];
            table.TableName = "ItemByCode";

            table.Rows.Add(table.NewRow());
            table.Rows[0]["GroupCode"]=Convert.ChangeType(GroupCode, table.Columns["GroupCode"].DataType);
            if(BatchCode != null)
            {
                table.Rows[0]["BatchCode"]=Convert.ChangeType(BatchCode, table.Columns["BatchCode"].DataType);
            }
            if(ItemCode != null)
            {
                table.Rows[0]["ItemCode"]=Convert.ChangeType(ItemCode, table.Columns["ItemCode"].DataType);
            }

            dsOrder = ProxyGenericGet(dsOrder);
            table = dsOrder.Tables[0];
            dsOrder.Tables.Remove(table);

            return table;
        }
        public static DataTable GetOldItemByCodeTypeEx()
        {
            DataSet dsOrder = new DataSet();
            dsOrder.Tables.Add("OldItemByCodeTypeEx");
            dsOrder = ProxyGenericGet(dsOrder);
            DataTable table = dsOrder.Tables[0];
            table.TableName = "ItemByCode";
            return table;
        }

        public static DataTable GetNewItemCustomerCodeByCode(string OrderCode, string GroupCode, string BatchCode, string ItemCode)
        {
            DataSet dsData = new DataSet();		
            DataTable dt = new DataTable("NewItemCustomerCodeByCode");
            dt.Columns.Add("OrderCode");
            dt.Columns.Add("GroupCode");
            dt.Columns.Add("BatchCode");
            dt.Columns.Add("ItemCode");
            dt.Rows.Add(new object[]{OrderCode, GroupCode, BatchCode, ItemCode});
            dsData.Tables.Add(dt);
            dsData = ProxyGenericGet(dsData);
            dt = dsData.Tables[0];
            dsData.Tables.Remove(dt);

            return dt;
        }

        public static DataTable GetMigratedItemCode(string GroupCode, string BatchCode, string ItemCode)
        {
            DataSet dsData = new DataSet();		
            DataTable dt = new DataTable("MigratedItemByCode");
            dt.Columns.Add("GroupCode");
            dt.Columns.Add("BatchCode");
            dt.Columns.Add("ItemCode");
            dt.Rows.Add(new object[]{GroupCode,BatchCode,ItemCode});
            dsData.Tables.Add(dt);
            dsData = ProxyGenericGet(dsData);
            dt = dsData.Tables[0];
            dsData.Tables.Remove(dt);

            return dt;
        }
        public static DataSet GetRestrictedNumbers()
        {
            DataSet dsTemp = new DataSet();
            DataTable dt = new DataTable("RestrictedNumbers");
            dsTemp.Tables.Add(dt);
            dsTemp = ProxyGenericGet(dsTemp);
            return dsTemp;
        }

        public static DataTable GetItemDataByOrderBatchItemMeasure( string GroupCode, string BatchCode, 
            string ItemCode, string MeasureCode, string PartID)
        {
            DataSet dsData = new DataSet();		
            DataTable dt = new DataTable("ItemDataFromOrderBatchItem");
            dt.Columns.Add("GroupCode");
            dt.Columns.Add("BatchCode");
            dt.Columns.Add("ItemCode");
            dt.Columns.Add("MeasureCode");
            dt.Columns.Add("PartID");
            dt.Rows.Add(new object[]{GroupCode, BatchCode, ItemCode, MeasureCode, PartID});
            dsData.Tables.Add(dt);
            dsData = ProxyGenericGet(dsData);
            dt = dsData.Tables[0];
            dsData.Tables.Remove(dt);

            return dt;		
        }

        public static DataTable GetItemListByCode(string GroupCode, string BatchCode)
        {
            DataSet dsOrder = new DataSet();
            dsOrder.Tables.Add("ItemByCodeTypeEx");
            dsOrder = ProxyGenericGet(dsOrder);
            DataTable table = dsOrder.Tables[0];
            table.TableName = "ItemByCode";

            table.Rows.Add(table.NewRow());
            table.Rows[0]["GroupCode"]=Convert.ChangeType(GroupCode, table.Columns["GroupCode"].DataType);
            table.Rows[0]["BatchCode"]=Convert.ChangeType(BatchCode, table.Columns["BatchCode"].DataType);
			
            dsOrder = ProxyGenericGet(dsOrder);
            table = dsOrder.Tables[0];
            dsOrder.Tables.Remove(table);

            return table;
        }

        public static DataTable GetOrderByOrderCode(string OrderCode)
        {
            DataSet dsOrder = new DataSet();
            dsOrder.Tables.Add("GroupByCodeTypeEx");
            dsOrder = ProxyGenericGet(dsOrder);
            DataTable table = dsOrder.Tables[0];
            table.TableName = "GroupByCode";

            table.Rows.Add(table.NewRow());
            table.Rows[0]["GroupCode"]=Convert.ChangeType(OrderCode, table.Columns["GroupCode"].DataType);

            dsOrder = ProxyGenericGet(dsOrder);
            table = dsOrder.Tables[0];
            dsOrder.Tables.Remove(table);

            return table;
        }

        public static DataTable GetOrderByOrderCode2(string OrderCode)
        {
            DataSet dsOrder = new DataSet();
            dsOrder.Tables.Add("GroupByCode2TypeEx");
            dsOrder = ProxyGenericGet(dsOrder);
            DataTable table = dsOrder.Tables[0];
            table.TableName = "GroupByCode2";

            table.Rows.Add(table.NewRow());
            table.Rows[0]["GroupCode"]=Convert.ChangeType(OrderCode, table.Columns["GroupCode"].DataType);

            dsOrder = ProxyGenericGet(dsOrder);
            table = dsOrder.Tables[0];
            dsOrder.Tables.Remove(table);

            return table;
        }

        public static string GetOrderCodeByOrderID(string OrderID)
        {
            DataSet dsData = ProxyGenericGetById(OrderID,"Group");			
            return dsData.Tables[0].Rows[0]["GroupCode"].ToString();
        }

        public static DataSet GetTakeIn()
        {

            DataSet dsFrontGet = new DataSet();			
            DataTable tmpMessenger = dsFrontGet.Tables.Add("Messengers");
			
			
            DataTable dtEntryBatch = dsFrontGet.Tables.Add("EntryBatchTypeOf");
            DataTable dtCarrier = dsFrontGet.Tables.Add("Carriers");

            DataSet dsData = ProxyGenericGet(dsFrontGet);			
            dsData.Tables.Add(GetAllCustomer());
            dsData.Tables.Add(GetMeasureUnits());
            dsData.Tables.Add(GetServiceTypes());
			
            DataTable table;
					
            Prepare_GetMesenger(dsData.Tables["Messengers"]);
						
            table = dsData.Tables["EntryBatchTypeOf"];
            table.TableName = "tblEntryBatch";
			
            table.Columns["CustomerID"].ColumnName = "CustomerID_OLD";
            table.Columns["CustomerOfficeID_CustomerID"].ColumnName = "CustomerID";
            table.Columns["PersonCustomerOfficeID_PersonCustomerID_PersonID"].ColumnName = "MessengerID";
			
            return dsData;
        }

        public static string GetCRTemplatePath()
        {
			//New Part
			string sReportPath = Client.GetOfficeDirPath("repDir");
			return sReportPath;
			
			//Old Part
		
			//if (iOfficeId == 1)
			//{
			//    return ProxyGetServiceCfgParameter("repDir");
			//}
			//else
			//{
			//    return System.Environment.GetEnvironmentVariable("TEMP")+@"\";
			//}
        }

        public static string GetServiceCfgParameter(string sParameter)
        {
            return ProxyGetServiceCfgParameter(sParameter);
        }

		
        public static DataTable GetAllCustomer()
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add("Customers");
            dsData = ProxyGenericGet(dsData);
            DataTable table = dsData.Tables["Customers"];
            Prepare_GetCustomer(table);
            dsData.Tables.Remove(table);
            return table;
        }

        private static void Prepare_GetCustomer(DataTable table)
        {
            table.TableName = "tblCustomer";
            table.Columns["CustomerName"].ColumnName = "CustomerName";
            if (table.Columns["CustomerID"] != null) table.Columns["CustomerID"].ColumnName = "CustomerID_OLD";
            table.Columns["CustomerOfficeID_CustomerID"].ColumnName = "CustomerID";
            table.Columns["CustomerCode"].ColumnName = "CustomerCode";
			
            //primarry key
            DataColumn[] keys = new DataColumn[1];
            keys[0] = table.Columns["CustomerCode"];
            table.PrimaryKey = keys;
        }

        public static DataTable GetCustomerByID(string CustomerID)
        {			
            DataSet dsData = ProxyGenericGetById(CustomerID, "Customer");
            DataTable table = dsData.Tables["Customer"];
            Prepare_GetCustomer(table);
            dsData.Tables.Remove(table);
            return table;
        }
		
        public static DataTable GetMeasureUnits()
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add("MeasureUnits");
            dsData = ProxyGenericGet(dsData); //Procedure dbo.spGetMeasureUnits
            DataTable table= dsData.Tables[0];
            table.TableName = "tblMeasureUnit";
            dsData.Tables.Remove(table);
            return table;
        }

        public static DataTable GetServiceTypes()
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add("ServiceTypes");
            dsData = ProxyGenericGet(dsData);
            DataTable table= dsData.Tables[0];
            table.TableName = "tblServiceType";
            dsData.Tables.Remove(table);
            return table;
        }

		
        private static void Prepare_GetMesenger(DataTable table)
        {			
            table.TableName = "tblMessenger";
            table.Columns["PersonCustomerOfficeID_PersonCustomerID_PersonID"].ColumnName = "MessengerID";			
            table.Columns["CustomerID"].ColumnName = "CustomerID_OLD";
            table.Columns["CustomerOfficeID_CustomerID"].ColumnName = "CustomerID";

            if (table.Columns["PositionCode"] != null)
            {
                DataRow[] RowArray = table.Select("PositionCode <> 1");
                foreach(DataRow row in RowArray)
                {
                    table.Rows.Remove(row);
                }
                table.Columns.Add("MessengerName");
                foreach(DataRow row in table.Rows)
                {
                    row["MessengerName"] = row["FirstName"].ToString() + row["LastName"].ToString();
                }				
            }
        }


        public static DataSet InsertTakeIn(DataSet dsSet)
        {
            DataTable table = dsSet.Tables["tblEntryBatch"];
            table.TableName = "EntryBatch";
            table.Columns["CustomerID"].ColumnName = "CustomerOfficeID_CustomerID";
            table.Columns["CustomerID_OLD"].ColumnName = "CustomerID";
            table.Columns["MessengerID"].ColumnName = "PersonCustomerOfficeID_PersonCustomerID_PersonID";
            DataSet dsOut = ProxyGenericSet(dsSet,"set");
            return dsOut;
        }
		
        public static string SetLightReturnData(string sOrderCode, string sBatchCode, string sItemCode, string sPrefix, string sPartID)
        {
            DataSet dsData=new DataSet();
            DataTable table=new DataTable("LightReturn");
            table.Columns.Add("GroupCode");
            table.Columns.Add("BatchCode");
            table.Columns.Add("ItemCode");
            table.Columns.Add("Prefix");
            table.Columns.Add("PartID");
            table.Rows.Add(table.NewRow());
            table.Rows[0]["GroupCode"] = sOrderCode;
            table.Rows[0]["BatchCode"] = sBatchCode;
            table.Rows[0]["ItemCode"]=sItemCode;
            table.Rows[0]["Prefix"]=sPrefix;
            table.Rows[0]["PartID"]=sPartID;
            dsData.Tables.Add(table);
            DataSet dsOut = ProxyGenericSet(dsData,"Set");
            string rId = dsOut.Tables[0].Rows[0][0].ToString();
            return rId;
        }
		
        public static DataTable GetGiveOut(string sCustomerID)
        {			
            DataSet dsData  =  new DataSet();
            dsData.Tables.Add("CustomerTypeEx");
            dsData = ProxyGenericGet(dsData);

            DataRow row = dsData.Tables[0].NewRow();
            row["CustomerOfficeID_CustomerID"] = sCustomerID;
            dsData.Tables[0].Rows.Add(row);
            dsData.Tables[0].TableName = "PersonsByCustomer";

            dsData = ProxyGenericGet(dsData);
			
            Prepare_GetMesenger(dsData.Tables[0]);

            return dsData.Tables[0];
        }

        public static void SetVendor(DataTable dtVendor)
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add(dtVendor);
            dtVendor.TableName = "GroupVendor";
            ProxyGenericSet(dsData, "Set");
        }
        public static DataTable GetVendorStruct()
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add("GroupVendorTypeOf");
            dsData = ProxyGenericGet(dsData);
            DataTable table = dsData.Tables[0];
            table.TableName = "Vendor";
            dsData.Tables.Remove(table);
            return table;
        }

        public static void SetItemOut(DataTable dtItemOut)
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add(dtItemOut);			
            ProxyGenericSet(dsData, "Set");

            //			try
            //			{
            //				foreach (DataRow dr in dtItemOut.Rows)
            //					//ProxyQBAddInvoice(dr["BatchID_ItemCode"].ToString());
            //					;
            //			}
            //			catch(Exception exc)
            //			{
            //				if (iInvoiceDebugLevel >= 4)
            //					MessageBox.Show("Can't add QB invoice:\r\n"+exc.Message);
            //			}
        }
        public static DataTable GetItemOutStruct()
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add("ItemOutTypeOf");
            dsData = ProxyGenericGet(dsData);
            DataTable table = dsData.Tables[0];
            table.TableName = "ItemOut";
            dsData.Tables.Remove(table);
            return table;
        }
		

        public static DataTable GetStates()
        {
            DataSet dataset = new DataSet();
            dataset.Tables.Add("States");
            DataSet dsData = ProxyGenericGet(dataset); //Procedure dbo.spGetStates
            DataTable table = dsData.Tables["States"];
            dsData.Tables.Remove(table);
            return table;
        }
        private static DataSet GetOrderTreeStructure(bool IsDoc)
        {			
            DataSet dsOrderTreeStructure = new DataSet();
            dsOrderTreeStructure.Tables.Add("GroupByCodeTypeEx");
            dsOrderTreeStructure.Tables.Add("BatchByCodeTypeEx");
            dsOrderTreeStructure.Tables.Add("ItemByCodeTypeEx");
            if (IsDoc) dsOrderTreeStructure.Tables.Add("ItemDocByCodeTypeEx");
            if (IsMemo) dsOrderTreeStructure.Tables.Add("MemoByCodeTypeEx");
            dsOrderTreeStructure = ProxyGenericGet(dsOrderTreeStructure);//Procedures dbo.spGetGroupByCodeTypeEx, dbo.spGetBatchByCodeTypeEx, dbo.spGetItemByCodeTypeEx, dbo.spGetItemDocByCodeTypeEx
            return dsOrderTreeStructure;
        }

        private static DataSet GetOrderTreeStructureWithOrderByMemo(bool IsDoc)
        {			
            DataSet dsOrderTreeStructure = new DataSet();
            dsOrderTreeStructure.Tables.Add("GroupByCodeTypeEx");
            dsOrderTreeStructure.Tables.Add("BatchByCodeByMemoTypeEx");
            dsOrderTreeStructure.Tables.Add("ItemByCodeTypeEx");
            if (IsDoc) dsOrderTreeStructure.Tables.Add("ItemDocByCodeTypeEx");
            dsOrderTreeStructure = ProxyGenericGet(dsOrderTreeStructure);//Procedures dbo.spGetGroupByCodeTypeEx, dbo.spGetBatchByCodeTypeEx, dbo.spGetItemByCodeTypeEx, dbo.spGetItemDocByCodeTypeEx
            return dsOrderTreeStructure;
        }

        private static DataSet GetOrderTreeStructureFromOrderList(bool IsDoc)
        {			
            DataSet dsOrderTreeStructure = new DataSet();
            dsOrderTreeStructure.Tables.Add("GroupByOrderCodeFromListTypeEx");
            dsOrderTreeStructure.Tables.Add("BatchByOrderCodeFromListTypeEx");
            dsOrderTreeStructure.Tables.Add("ItemByOrderCodeFromListTypeEx");
            if (IsDoc) dsOrderTreeStructure.Tables.Add("ItemDocByOrderCodeFromListTypeEx");
            dsOrderTreeStructure = ProxyGenericGet(dsOrderTreeStructure);
            return dsOrderTreeStructure;
        }

        public static DataSet GetOrderTreeDataByCustomerCodeAndFilterDate(string CustomerCode,string BeginDate, string EndDate)
        {
			Couple cplCustomer = new Couple
			{
				FieldName = "CustomerCode",
				FieldValue = CustomerCode
			};

			Couple cplDatesB = new Couple
			{
				FieldName = "BDate",
				FieldValue = BeginDate
			};

			Couple cplDatesE = new Couple
			{
				FieldName = "EDate",
				FieldValue = EndDate
			};

			return GetOrderTreeDataByCode(new Couple[] {cplCustomer, cplDatesB, cplDatesE});
        }
        public static DataSet GetOrderTreeDataByCustomerCode(string CustomerCode)
        {
            Couple[] cplBatch = new Couple[1];
			cplBatch[0] = new Couple
			{
				FieldName = "CustomerCode",
				FieldValue = CustomerCode
			};
			DataSet dsOrders =  Service.GetOrderTreeDataByCode(cplBatch);
            return dsOrders;
        }

        public static DataSet GetOrderTreeDataByGroupCodeAndFilterBState(string GroupCode,string BState)
        {
            return GetOrderTreeDataByGroupCodeAndFilterBState(GroupCode,BState, true);
        }
        public static DataSet GetOrderTreeDataByGroupCodeAndFilterBState(string GroupCode,string BState, bool IsDoc)
        {
            Couple[] cplBatch = new Couple[2];
			cplBatch[0] = new Couple
			{
				FieldName = "GroupCode",
				FieldValue = GroupCode
			};
			cplBatch[1].FieldName = "BState";
            cplBatch[1].FieldValue = BState;
            DataSet dsOrders =  Service.GetOrderTreeDataByCode(cplBatch,IsDoc);
            return dsOrders;
        }

        public static DataSet GetOrderTreeDataByGroupCode(string GroupCode)
        {
            //			if(GroupCode.Trim().ToUpper().IndexOf("MEMO") > 0)
            //			{
            //				GroupCode = GroupCode.Substring(0, GroupCode.Length - 5);
            //				IsMemo = true;
            //			}
            return GetOrderTreeDataByGroupCode(GroupCode, true);
        }

        public static DataSet GetOrderTreeDataByGroupCode(string GroupCode, bool IsDoc)
        {
            Couple[] cplBatch = new Couple[1];
			cplBatch[0] = new Couple
			{
				FieldName = "GroupCode",
				FieldValue = GroupCode
			};
			DataSet dsOrders = Service.GetOrderTreeDataByCode(cplBatch, IsDoc); //Call to procedures dbo.spGetGroupByCode,dbo.spGetBatchByCode,dbo.spGetItemByCode,dbo.spGetItemDocByCode
            return dsOrders;
        }

        public static DataSet GetOrderTreeData()
        {
            return GetOrderTreeData(new Couple[] {});
        }

        public static DataSet GetOrderTreeData(Couple[] aFieldCouple)
        {
            return GetOrderTreeData(aFieldCouple, true);
        }

        public static DataSet GetOrderTreeData(Couple[] aFieldCouple, bool IsDoc)
        {
            DataSet dsIn = GetOrderTreeStructure(IsDoc);//Procedure dbo.spGetGroupByCodeTypeEx, dbo.spGetBatchByCodeTypeEx, dbo.spGetItemByCodeTypeEx, dbo.spGetItemDocByCodeTypeEx

            foreach(DataTable table in dsIn.Tables)
            {
                table.TableName = table.TableName.Substring(0,(table.TableName.Length - 6));
                DataRow row = table.NewRow();
                foreach(Couple couple in aFieldCouple)
                {
                    row[couple.FieldName] = Convert.ChangeType(couple.FieldValue, table.Columns[couple.FieldName].DataType);
                }
                table.Rows.Add(row);
            }
            dsIn = ProxyGenericGet(dsIn);//Procedures dbo.spGetGroupByCode,dbo.spGetBatchByCode,dbo.spGetItemByCode,dbo.spGetItemDocByCode
            return dsIn;
        }

        public static DataSet GetOrderTreeDataForGiveOut(string GroupCode)
        {
            DataSet dsIn = GetOrderTreeStructure(true);

            foreach(DataTable table in dsIn.Tables)
            {
                table.TableName = table.TableName.Substring(0,(table.TableName.Length - 6));
                DataRow row = table.NewRow();
                row["GroupCode"] = Convert.ChangeType(GroupCode, table.Columns["GroupCode"].DataType);
                row["BState"] = Convert.ChangeType("2", table.Columns["BState"].DataType);
                if (table.TableName == "ItemDocByCode")
                {
                    row["EState"] = Convert.ChangeType("2", table.Columns["EState"].DataType);
                }
                table.Rows.Add(row);
            }

            dsIn = ProxyGenericGet(dsIn);

            Prepare_GetOrderTree(dsIn);
            dsIn.Tables.Add(GetStates());

            return dsIn;
        }

        public static DataSet GetOrderTreeDataByCode(Couple[] aFieldCouple)
        {
            return GetOrderTreeDataByCode(aFieldCouple, true);
        }
	
        public static DataSet GetOrderTreeDataByCodeFromList(object aOrders)
        {
            DataSet dsIn = GetOrderTreeStructureFromOrderList(true);

            foreach(DataTable table in dsIn.Tables)
            {
                table.TableName = table.TableName.Substring(0,(table.TableName.Length - 6));
                table.Columns.Add("GroupCodeList", typeof(string));
                DataRow row = table.NewRow();
                row["GroupCodeList"] = aOrders;
                table.Rows.Add(row);
            }
            dsIn = ProxyGenericGet(dsIn);
            foreach(DataTable dt in dsIn.Tables)
            {
                dt.TableName = dt.TableName.Substring(0,(dt.TableName.Length - 17)) + "Code";
            }
            Prepare_GetOrderTree(dsIn);
            dsIn.Tables.Add(GetStates());
            return dsIn;
        }
		
        public static DataSet GetOrderTreeDataByCode(Couple[] aFieldCouple, bool IsDoc)
        {
            DataSet dsIn = GetOrderTreeData(aFieldCouple, IsDoc);//Calling procedures dbo.spGetGroupByCode,dbo.spGetBatchByCode,dbo.spGetItemByCode,dbo.spGetItemDocByCode

            Prepare_GetOrderTree(dsIn);
            dsIn.Tables.Add(GetStates()); //Procedure dbo.spGetStates

            return dsIn;
        }

        private static void Prepare_GetOrderTree(DataSet dsIn)
        {
            bool IsDoc = dsIn.Tables["ItemDocByCode"] != null;
            IsMemo = dsIn.Tables["MemoByCode"] != null;

            foreach(DataTable table in dsIn.Tables)
            {
                table.Columns.Add("SysCode");
                table.Columns.Add("Hide");
				
                int i = 0;
                foreach(DataRow row in table.Rows)
                {
                    row["SysCode"] = i.ToString();
                    i++;
                    row["Hide"] = "0";
                }
            }
			
            foreach(DataTable table in dsIn.Tables)
            {
                string sPrefix = table.TableName.Substring(0, table.TableName.Length - 6);
                table.TableName = "tbl" + sPrefix;
                int iBatchCode=0, iItemCode=0, iOrderCode=0, iEBCode=0;
                string sName="";
				
                if (table.TableName != "tblMemo")
                {
                    if (table.Columns["GroupCode"] != null)
                    {
                        DataColumn dcName = table.Columns.Add("Name");
                        foreach(DataRow row in table.Rows)
                        {						
                            iOrderCode = Convert.ToInt32(row["GroupCode"].ToString());
                            iEBCode = Convert.ToInt32(row["GroupCode"].ToString());
						
                            if(table.Columns["BatchCode"]==null)
                                iBatchCode = 0;
                            else
                            {
                                if(Convert.IsDBNull(row["BatchCode"]))		
                                    iBatchCode = 0;
                                else		
                                    iBatchCode = Convert.ToInt32(row["BatchCode"]);
                            }
						
                            if(table.Columns["ItemCode"]==null)
                                iItemCode = 0;
                            else
                            {
                                if(Convert.IsDBNull(row["ItemCode"]))		
                                    iItemCode = 0;
                                else		
                                    iItemCode = Convert.ToInt32(row["ItemCode"]);
                            }

                            if(table.Columns["OperationChar"]==null)
                                sName = "";
                            else
                            {
                                if(Convert.IsDBNull(row["OperationChar"]))
                                    sName = "";
                                else		
                                    sName = Convert.ToString(row["OperationChar"]);
                            }


                            /*int iBatchCode = (table.Columns["BatchCode"]==null)?0:Convert.ToInt32(row["BatchCode"].ToString());
                            int iItemCode = (table.Columns["ItemCode"]==null)?0:Convert.ToInt32(row["ItemCode"].ToString());
                            string sName = (table.Columns["OperationChar"]==null)?"":row["OperationChar"].ToString();*/
                            
                            //sName += GraderLib.GetCorrectFullCodeString(iOrderCode,iEBCode,iBatchCode,iItemCode);

                            sName += GraderLib.GetCorrectFullCodeString(iOrderCode, iEBCode, iBatchCode,iItemCode);
                            row["Name"] = sName;
                        }
                    }
                }
                else
                {
                    if (table.Columns["GroupCode"] != null)
                    {
                        DataColumn dcName = table.Columns.Add("Name");
                        foreach(DataRow row in table.Rows)
                        {
                            row["Name"] = row["MemoNumber"].ToString();
                        }			
				
                    }
                }
                if (table.Columns[sPrefix + "Code"]!= null)
                {
                    table.Columns[sPrefix + "Code"].ColumnName = "Code";
                }
            }

            DataTable tbl;
            tbl = dsIn.Tables["tblGroup"];
            tbl.TableName = "tblOrder";
            tbl.Columns["GroupOfficeID_GroupID"].ColumnName = "ID";
            tbl.Columns["CustomerOfficeID_CustomerID"].ColumnName = "ParentID";			

            tbl = dsIn.Tables["tblBatch"];
            if (IsMemo)
            {
                tbl.Columns["MemoNumber_MemoNumberID"].ColumnName = "ParentID";
            }
            else
                tbl.Columns["GroupOfficeID_GroupID"].ColumnName = "ParentID";

            tbl.Columns.Add("ID");
            foreach(DataRow row in tbl.Rows)
            {
                row["ID"] = row["BatchID"].ToString();
            }
			
            tbl = dsIn.Tables["tblItem"];
            tbl.Columns["BatchID_ItemCode"].ColumnName = "ID";
            tbl.Columns.Add("ParentID");
            foreach(DataRow row in tbl.Rows)
            {
                row["ParentID"] = row["BatchID"].ToString();
            }
            //Prepare Memo
            if (IsMemo)
            {
                DataTable dtMemo = dsIn.Tables["tblMemo"];
                dtMemo.Columns["GroupOfficeID_GroupID"].ColumnName = "ParentID";
                dtMemo.Columns.Add("ID");
                foreach(DataRow row in dtMemo.Rows)
                {
                    row["ID"] = row["MemoNumber_MemoNumberID"];//.ToString();
                }
            }	

            // Prepare Document
            if (IsDoc)
            {
                DataTable dtDocument = dsIn.Tables["tblItemDoc"];
                dtDocument.TableName = "tblDocument";
                dtDocument.Columns["ItemOperationOfficeID_ItemOperationID"].ColumnName = "ID";
                dtDocument.Columns["BatchID"].ColumnName = "BatchID_OLD";
                dtDocument.Columns.Add("OrderID");
                dtDocument.Columns.Add("BatchID");
                dtDocument.Columns.Add("ItemID");
			
                foreach(DataRow row in dtDocument.Rows)
                {
                    string sCode = Regex.Replace(row["Name"].ToString(),@"^[^0-9\.]+","");
                    string[] sCodesArray = sCode.Split('.');					
                    string tblName = "";
                    switch (sCodesArray.Length)
                    {
                        case 2:
                            tblName = "Order";
                            break;
                        case 3:
                            tblName = "Batch";
                            break;
                        case 4:
                            tblName = "Item";
                            break;
                    }
                    try
                    {
                        DataRow drParrentRow = dsIn.Tables["tbl"+tblName].Select("Name = '"+sCode+"'")[0];
                        row[tblName+"ID"] = drParrentRow["ID"];
                    }
                    catch
                    {
                        row.Delete();
                    }
                }
                dtDocument.AcceptChanges();
				
            }
			
            // sd 06.12.2006 Sort Items in order tree
            DataRow[] drItems = dsIn.Tables["tblItem"].Select("","OrderCode, BatchCode,Code");
            DataTable dtItems = dsIn.Tables["tblItem"].Clone();
            try
            {
                if(drItems.Length>0)
                {
                    foreach(DataRow drItem in drItems)
                    {
                        dtItems.Rows.Add(drItem.ItemArray);
                    }
                }
            }
            catch
            {}
            if(dtItems!=null)
            {
                dtItems.TableName = "tblItem";
                dsIn.Tables.Remove("tblItem");
                dsIn.Tables.Add(dtItems);
            }

            //Relation
            DataRelation drel;
            DataColumn parentCol;
            DataColumn childCol;
#if DEBUG
            // For debugging only			
            string filename = Service.sTempDir + "/myXmlDocOrderBatchItem.xml";
            if (File.Exists(filename)) File.Delete(filename);
            // Create the FileStream to write with.
            System.IO.FileStream myFileStream = new System.IO.FileStream (filename, System.IO.FileMode.Create);
            // Create an XmlTextWriter with the fileStream.
            System.Xml.XmlTextWriter myXmlWriter = new System.Xml.XmlTextWriter(myFileStream, System.Text.Encoding.Unicode);
            // Write to the file with the WriteXml method.
            dsIn.WriteXml(myXmlWriter);   
            myXmlWriter.Close();
            // End of debugging part
#endif

            if (!IsMemo)
            {
                try
                {
                    parentCol = dsIn.Tables["tblOrder"].Columns["ID"];
                    childCol = dsIn.Tables["tblBatch"].Columns["ParentID"];			
                    drel = new DataRelation("Order_EntryBacth", parentCol, childCol);
                    dsIn.Relations.Add(drel);

                    //debug_DiaspalyDataSet(dsIn);

                    parentCol = dsIn.Tables["tblBatch"].Columns["ID"];
                    childCol = dsIn.Tables["tblItem"].Columns["ParentID"];			
                    drel = new DataRelation("Batch_Item", parentCol, childCol);
                    dsIn.Relations.Add(drel);
                }
			
                catch(Exception exc)
                {
                    MessageBox.Show("Can't show open orders. Reason: " + exc.Message, "Internal error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);				
                }
            }	
            else
            {
                try
                {
                    parentCol = dsIn.Tables["tblOrder"].Columns["ID"];
                    childCol = dsIn.Tables["tblMemo"].Columns["ParentID"];			
                    drel = new DataRelation("Order_Memo", parentCol, childCol);
                    dsIn.Relations.Add(drel);

                    parentCol = dsIn.Tables["tblMemo"].Columns["ID"];
                    childCol = dsIn.Tables["tblbatch"].Columns["ParentID"];			
                    drel = new DataRelation("Memo_Batch", parentCol, childCol);
                    dsIn.Relations.Add(drel);

                    parentCol = dsIn.Tables["tblBatch"].Columns["ID"];
                    childCol = dsIn.Tables["tblItem"].Columns["ParentID"];			
                    drel = new DataRelation("Batch_Item", parentCol, childCol);
                    dsIn.Relations.Add(drel);
                }
                catch(Exception exc)
                {
                    MessageBox.Show("Can't show open orders. Reason: " + exc.Message, "Internal error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);				
                }			
            }
            if (IsDoc)
            {
                //				parentCol = dsIn.Tables["tblOrder"].Columns["ID"];
                //				childCol = dsIn.Tables["tblDocument"].Columns["OrderID"];			
                //				drel = new DataRelation("Order_Document", parentCol, childCol);
                //				dsIn.Relations.Add(drel);
                //
                //				parentCol = dsIn.Tables["tblBatch"].Columns["ID"];
                //				childCol = dsIn.Tables["tblDocument"].Columns["BatchID"];			
                //				drel = new DataRelation("Batch_Document", parentCol, childCol);
                //				dsIn.Relations.Add(drel);

                parentCol = dsIn.Tables["tblItem"].Columns["ID"];
                childCol = dsIn.Tables["tblDocument"].Columns["ItemID"];			
                drel = new DataRelation("Item_Document", parentCol, childCol);
                dsIn.Relations.Add(drel);
            }
        }
		

        public static void CreateGroupVersion(string sGroupOldID)
        {
            CreateGroupVersion(sGroupOldID,"","");
        }

        public static void MoveFileToSendDir(string sFileName)
        {
            srv.MoveFileToSendDir(sSessionId,sFileName);
        }

        public static void CreateGroupVersion(string sGroupOldID,string InspectedTotalWeight,string InspectedWeightUnitID)
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add("GroupVersionTypeOf");
            dsData = ProxyGenericGet(dsData);
            dsData.Tables[0].TableName = "GroupVersion";
            DataRow row = dsData.Tables[0].NewRow();
            row["GroupOfficeID_GroupID"] = sGroupOldID;
            if (InspectedTotalWeight != "")
            {
                row["InspectedTotalWeight"] = Convert.ToDecimal(InspectedTotalWeight);
                row["InspectedWeightUnitID"] = InspectedWeightUnitID;
            }
            dsData.Tables[0].Rows.Add(row);

            dsData = ProxyGenericSet(dsData,"Add");
        }

        public static DataSet SetReitemizedOrderTreeData(DataSet dsIn)
        {
            Prepapre_SetOrderTree(dsIn);
            foreach(DataTable table in dsIn.Tables)
            {	
                table.TableName = "Reitemized" + table.TableName;
            }

            DataSet dsStruct = CreateStructure(dsIn,"TypeOf");
            LeftStructColumns(dsIn, dsStruct, "TypeOf");
            AddStructColumns(dsIn, dsStruct);

            DataSet dsOut = ProxyGenericSet(dsIn, "Set");

            return dsOut;
        }
        private static void Prepapre_SetOrderTree(DataSet dsIn)
        {
            //Relation			
            dsIn.Relations.Clear();

            // Prepare Document

            if (dsIn.Tables["tblDocument"] != null)
            {
                DataTable dtDocument = dsIn.Tables["tblDocument"];
                dtDocument.TableName = "tblOperation";			
                dtDocument.Columns["ID"].ColumnName = "ItemOperationOfficeID_ItemOperationID";
                dtDocument.Columns["BatchID"].ColumnName = "BatchID_NEW";
                dtDocument.Columns["BatchID_OLD"].ColumnName = "BatchID";
            }

            DataTable tbl;
            if (dsIn.Tables["tblOrder"] != null)
            {
                tbl = dsIn.Tables["tblOrder"];
                tbl.TableName = "tblGroup";
                tbl.Columns["ID"].ColumnName = "GroupOfficeID_GroupID";
            }

            tbl = dsIn.Tables["tblBatch"];
            tbl.Columns["ParentID"].ColumnName = "GroupOfficeID_GroupID";

            tbl = dsIn.Tables["tblItem"];
            tbl.Columns["ID"].ColumnName = "BatchID_ItemCode";


            // Rename tables			
            foreach(DataTable table in dsIn.Tables)
            {				
                string sPrefix = table.TableName.Substring(3, table.TableName.Length - 3);
                table.TableName = sPrefix;
                if (table.Columns["Code"] != null)
                {
                    table.Columns["Code"].ColumnName = sPrefix + "Code";
                }
            }
        }

        private static DataSet CreateStructure(DataSet dsIn)
        {
            return CreateStructure(dsIn,"TypeEx");
        }
        private static DataSet CreateStructure(DataSet dsIn, string Postfix)
        {
            DataSet dsOut = new DataSet();
            foreach(DataTable table in dsIn.Tables)
            {
                dsOut.Tables.Add(table.TableName + Postfix);
            }
            dsOut = ProxyGenericGet(dsOut);
            return dsOut;
        }

        private static void LeftStructColumns(DataSet dsIn)
        {
            DataSet dsStruct = CreateStructure(dsIn);
            LeftStructColumns(dsIn, dsStruct);
        }
        private static void LeftStructColumns(DataSet dsIn, DataSet dsStruct)
        {
            LeftStructColumns(dsIn, dsStruct, "TypeEx");
        }
        private static void LeftStructColumns(DataSet dsIn, DataSet dsStruct, string sPostfix)
        {
            foreach(DataTable table in dsIn.Tables)
            {
                table.Constraints.Clear();
                string tblStruct = table.TableName + sPostfix;
                bool IsEnd = true;
                while (IsEnd)
                {
                    IsEnd = false;
                    foreach(DataColumn column in table.Columns)
                    {
                        if (dsStruct.Tables[tblStruct].Columns[column.ColumnName] == null)
                        {
                            table.Columns.Remove(column);
                            IsEnd = true;
                            break;
                        }	
                    }	
                }	
            }	
        }	// :)

        private static void AddStructColumns(DataSet dsIn, DataSet dsStruct)
        {
            foreach(DataTable table in dsStruct.Tables)
            {
                string tblIn = table.TableName.Substring(0, table.TableName.Length - 6);
                bool IsEnd = true;
                while (IsEnd)
                {
                    IsEnd = false;
                    foreach(DataColumn column in table.Columns)
                    {
                        if (dsIn.Tables[tblIn] != null)
                        {
                            if (dsIn.Tables[tblIn].Columns[column.ColumnName] == null)
                            {
                                table.Columns.Add(column.ColumnName,column.DataType, column.Expression);
                                IsEnd = true;
                                break;
                            }	
                        }	
                    }	
                }	
            }	
        }	// :))

        public static void SetOrderTreeCloseState(DataSet dsIn)
        {
            Prepapre_SetOrderTree(dsIn);
            //			try
            //			{
            //				foreach(DataRow row in dsIn.Tables["Group"].Rows)
            //				//	ProxyQBAddGroupInvoice(row["GroupOfficeID"].ToString() + "_" + row["GroupID"].ToString());
            //				;
            //			}
            //			catch
            //			{
            //			}
            foreach(DataTable table in dsIn.Tables)
            {	
                table.TableName = "Close" + table.TableName + "StateByCode";
            }
            LeftStructColumns(dsIn);
            ProxyGenericSet(dsIn, "Set");
        }

        public static void UpdateOrderTreeState(DataSet dsIn)
        {
            Prepapre_SetOrderTree(dsIn);
            foreach(DataTable table in dsIn.Tables)
            {	
                table.TableName = table.TableName + "StateByCode";
            }
            LeftStructColumns(dsIn);
            ProxyGenericSet(dsIn, "Set");
        }


        public static void SetMemoNumber(DataSet dsMemoNumbers)
        {
            try
            {
                ProxyGenericSet(dsMemoNumbers, "Set");
            }
            catch(Exception exc)
            {
                MessageBox.Show("Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);				
            }
        }
#endregion Front

        public static void Debug_DiaspalyDataSetStruct(DataSet dsIn)
        {
            // Display what we get (only for debuging-time)
            string msg = "";
            foreach(DataTable table in dsIn.Tables)
            {
                msg = "\r\nTable Name: "+ table.TableName + "\r\n";
                //int i =0;
                foreach(DataColumn column in table.Columns)
                {
                    msg += "\t"+ column.ColumnName + ": " + "\r\n";
                }					
				
                MessageBox.Show(msg);
            }
        }
        public static void Debug_DiaspalyDataSet(DataSet dsIn)
        {
            // Display what we get (only for debuging-time)
            string msg = "";
            foreach(DataTable table in dsIn.Tables)
            {
                msg = "\r\nTable Name: "+ table.TableName + "\r\n";
                int i =0;
                foreach (DataRow row in table.Rows)
                {
                    i++;
                    msg += "row N: "+ i.ToString() + "\r\n";
                    foreach(DataColumn column in table.Columns)
                    {
                        msg += "\t"+ column.ColumnName + ": " + row[column].ToString() + "\r\n";
                    }					
                }
                //MessageBox.Show(msg);
                System.Diagnostics.Trace.Write(msg);
            }			
        }

        public static Image GetImageFromSrv(string sFileName)
        {
            string s = ProxyGetImage(sFileName);
            if(s!=null)
                return ExtractImageFromString(s, sFileName);
            else
                return null;
        }

        public static void UpdateEstimatedPartValues(int iBatchID, int iItemCode)
        {
            //DataTable table;
            DataSet dsNewCode = GetNewBatchIDItemCode(iBatchID.ToString(), iItemCode.ToString());
            if(dsNewCode!=null&&dsNewCode.Tables.Count>0&&dsNewCode.Tables[0].Rows.Count>0&&
                dsNewCode.Tables[0].Rows[0]["NewBatchID"].ToString()!=""&&
                dsNewCode.Tables[0].Rows[0]["NewItemCode"].ToString()!="")
            {
                try
                {
                    iBatchID = int.Parse(dsNewCode.Tables[0].Rows[0]["NewBatchID"].ToString());
                    iItemCode = int.Parse(dsNewCode.Tables[0].Rows[0]["NewItemCode"].ToString());
                }
                catch(Exception ex)
                {
                    string msg = ex.Message;
                }
            }
            DataSet dsIn;
            DataSet dsOut;

            dsIn = new DataSet();
            dsIn.Tables.Add("EstimatedValuesTypeOf");
            dsOut = ProxyGenericGet(dsIn);//Procedure dbo.spGetEstimatedValuesTypeOf
            dsOut.Tables["EstimatedValuesTypeOf"].Rows.Add(new object[]{});
            dsOut.Tables["EstimatedValuesTypeOf"].Rows[0]["BatchID"] = iBatchID;
            dsOut.Tables["EstimatedValuesTypeOf"].Rows[0]["ItemCode"] = iItemCode;
            dsOut.Tables["EstimatedValuesTypeOf"].TableName = "EstimatedValues";

            ProxyGenericSet(dsOut, "Set");//Procedure SetEstimatedValues
        }

        public static string GetMeasureValue(string sMeasureName, DataTable tTable, string sPartID)
        {
            DataRow[] rParts=null;
            string sRet="";
            try
            {

                if(tTable.Rows.Count > 0)					
                {
                    rParts=tTable.Select("MeasureName=" + "'" + sMeasureName + "'" + " and PartID = '"+sPartID + "'");
					
                    if (rParts.Length > 0)
                    {
                        switch(rParts[0]["MeasureClass"].ToString())
                        {
                            case "1": sRet=rParts[0]["MeasureValueName"].ToString(); break;
                            case "2": sRet=rParts[0]["StringValue"].ToString(); break;
                            case "3": sRet=rParts[0]["MeasureValue"].ToString(); break;
                            case "4": sRet=rParts[0]["StringValue"].ToString(); break;
                        }
                    }					
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return sRet;
			
        }

        public static string GetMeasureValueByMeasureCode(string sMeasureCode, DataTable tTable, string sPartID)
        {
            DataRow[] rParts=null;
            string sRet="";
            try
            {
                if(tTable.Rows.Count > 0)					
                {
                    rParts=tTable.Select("MeasureCode="+"'"+sMeasureCode+"'"+" and PartID="+sPartID);
					
                    switch(rParts[0]["MeasureClass"].ToString())
                    {
                        case "1": sRet=rParts[0]["MeasureValueName"].ToString(); break;
                        case "2": sRet=rParts[0]["StringValue"].ToString(); break;
                        case "3": sRet=rParts[0]["MeasureValue"].ToString(); break;
                        case "4": sRet=rParts[0]["StringValue"].ToString(); break;
                    }
                }
            }
            catch{}
            return sRet;
        }
#region Remeasure

        public static DataTable GetItemUpdateStruct()
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add("ItemTypeOf2");
            dsData = ProxyGenericGet(dsData);

            DataTable table = dsData.Tables[0];
            table.TableName = "UpdateItem";
            dsData.Tables.Remove(table);
            return table;			
        }

        public static void UpdateItem(DataTable table)
        {
            table.TableName = "Item";
            DataSet dsData = new DataSet();
            dsData.Tables.Add(table);
            dsData = ProxyGenericSet(dsData,"Update");
        }

        public static DataTable GetMeasureValues()
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add("MeasureValues");			
            dsData = ProxyGenericGet(dsData);

            DataTable table = dsData.Tables[0];
            dsData.Tables.Remove(table);
            return table;
        }
		
        public static DataTable GetPartsMeasures(string sItemTypeID, string sBatchID, string sItemCode,string sNewBatchID, string sNewItemCode)
        {			
            DataTable dtFilled = Service.GetPartValue(sNewBatchID, sNewItemCode);		//tblName : PartValue / 0 - filled table
            DataTable dtEmpty = Service.GetMeasuresByItemType(sItemTypeID);		//tblName : MeasuresByItemType / 1 - empty

            //copy structeure
            foreach(DataColumn column in dtFilled.Columns)
            {
                if (dtEmpty.Columns[column.ColumnName] == null)
                {
                    dtEmpty.Columns.Add(column.ColumnName,column.DataType, column.Expression);
                }
            }

            //copy data
            foreach(DataRow	row in dtEmpty.Rows)
            {
                DataRow[] drMeasures = dtFilled.Select("MeasureID = " + row["MeasureID"] + " and PartID = " + row["PartTypeID"]);
                if (drMeasures.Length >0)
                {
                    DataRow drMeasure = drMeasures[0];
                    foreach(DataColumn column in dtFilled.Columns)
                    {
                        row[column.ColumnName] = drMeasure[column.ColumnName];
                    }
                }
            }
            dtEmpty.TableName = "Measures";
            return dtEmpty;
        }

        public static DataTable GetPartValue(string BatchID, string ItemCode)
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add("PartValue");
            dsData = CreateStructure(dsData);
            DataTable table = dsData.Tables[0];
            table.TableName = "PartValue";
            DataRow row = table.NewRow();
            row["BatchID"] = Convert.ToInt32(BatchID);
            row["ItemCode"] = Convert.ToInt32(ItemCode);
            row["RecheckNumber"] = -1;
            table.Rows.Add(row);
            dsData = ProxyGenericGet(dsData);

            table = dsData.Tables[0];
            dsData.Tables.Remove(table);
            return table;		
        }

        public static DataTable GetPartValueCCM(string BatchID, string ItemCode)
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add("PartValue");
            dsData = CreateStructure(dsData);
            DataTable table = dsData.Tables[0];
            table.TableName = "PartValue";
            DataRow row = table.NewRow();
            row["BatchID"] = Convert.ToInt32(BatchID);
            row["ItemCode"] = Convert.ToInt32(ItemCode);
            row["RecheckNumber"] = -1;
            table.Rows.Add(row);
            dsData = ProxyGenericGet(dsData);

            table = dsData.Tables[0];
            dsData.Tables.Remove(table);
            return table;		
        }

        public static DataTable GetParts(string ItemTypeID)
        {
            DataTable table = GetItemPartsByItemTypeID(ItemTypeID);//Procedure dbo.spGetPartsByItemType
            Prepare_GetPartTree(table);
            table.TableName = "Parts";			
            return table;
        }

        public static DataTable GetItemPartsByItemTypeID(string ItemTypeID)
        {
            DataSet dsData = new DataSet();			
            dsData.Tables.Add("ItemTypeTypeEx");
            dsData = ProxyGenericGet(dsData);
            DataTable table = dsData.Tables["ItemTypeTypeEx"];			
            table.TableName = "PartsByItemType";

            DataRow row = table.NewRow();
            row["ItemTypeID"] = Convert.ToDecimal(ItemTypeID);
            table.Rows.Add(row);

            dsData = ProxyGenericGet(dsData);
            //			debug_DiaspalyDataSet(dsData);

            table = dsData.Tables[0];
            dsData.Tables.Remove(table);
            return table;
        }
		
        public static DataTable GetMeasuresByItemType(string ItemTypeID)
        {
            DataSet dsData = new DataSet();			
            dsData.Tables.Add("ItemTypeTypeEx");
            dsData = ProxyGenericGet(dsData);

            DataTable table = dsData.Tables["ItemTypeTypeEx"];			
            table.TableName = "MeasuresByItemType";

            DataRow row = table.NewRow();
            row["ItemTypeID"] = Convert.ToDecimal(ItemTypeID);
            table.Rows.Add(row);

            dsData = ProxyGenericGet(dsData);			

            table = dsData.Tables[0];			
            dsData.Tables.Remove(table);
            return table;
        }
		
        public static DataTable GetMeasuresByItemTypePartID(string ItemTypeID)
        {
            DataSet dsData = new DataSet();			
            dsData.Tables.Add("MeasuresByItemTypePartID");
            dsData.Tables[0].Columns.Add("ItemTypeID");
            dsData.Tables[0].Rows.Add(dsData.Tables[0].NewRow());
            dsData.Tables[0].Rows[0]["ItemTypeID"] = ItemTypeID;
			
            dsData = ProxyGenericGet(dsData);			

            DataTable table = dsData.Tables[0];			
            dsData.Tables.Remove(table);
            return table;
        }

        public static DataTable GetMeasuresByCP(string ItemTypeID, string BatchID)
        {
            DataSet dsData = new DataSet();			
            dsData.Tables.Add("ItemMeasuresByCP");
            dsData.Tables[0].Columns.Add("BatchID");
            dsData.Tables[0].Columns.Add("ItemTypeID");
            dsData.Tables[0].Rows.Add(dsData.Tables[0].NewRow());
            dsData.Tables[0].Rows[0]["BatchID"] = BatchID;
            dsData.Tables[0].Rows[0]["ItemTypeID"] = ItemTypeID;
			
            dsData = ProxyGenericGet(dsData);			

            DataTable table = dsData.Tables[0];			
            dsData.Tables.Remove(table);
            return table;
        }

        public static DataTable GetMeasuresByItemTypeAndBillable(string ItemTypeID)
        {
            DataSet dsData = new DataSet();			
            dsData.Tables.Add("ItemTypeTypeEx");
            dsData = ProxyGenericGet(dsData);

            DataTable table = dsData.Tables["ItemTypeTypeEx"];			
            table.TableName = "MeasuresByItemTypeAndBillable";

            DataRow row = table.NewRow();
            row["ItemTypeID"] = Convert.ToDecimal(ItemTypeID);
            table.Rows.Add(row);

            dsData = ProxyGenericGet(dsData);			

            table = dsData.Tables[0];			
            dsData.Tables.Remove(table);
            return table;
        }

        public static void Prepare_GetPartTree(DataTable dtParts)
        {
            dtParts.Columns["PartID"].ColumnName = "ID";
            dtParts.Columns["PartName"].ColumnName = "Name";
            dtParts.Columns["ParentPartID"].ColumnName = "ParentID";
        }

        public static DataTable GetItemPartsMeasure(string ItemTypeID)
        {
            DataSet dsData = new DataSet();			
            dsData.Tables.Add("PartValueTypeEx");
            dsData = ProxyGenericGet(dsData);
            DataTable table = dsData.Tables["PartValueTypeEx"];			
            table.TableName = "PartValue";

            DataRow row = table.NewRow();
            row["ItemTypeID"] = Convert.ToDecimal(ItemTypeID);
            table.Rows.Add(row);

            dsData = ProxyGenericGet(dsData);
            table = dsData.Tables[0];
            dsData.Tables.Remove(table);
            return table;
        }

        public static DataTable GetPartsStruct()
        {
            DataSet dsData = new DataSet();			
            dsData.Tables.Add("PartValueTypeOf");
            dsData = ProxyGenericGet(dsData);
            DataTable table = dsData.Tables["PartValueTypeOf"];			
            table.TableName = "SetParts";
            dsData.Tables.Remove(table);
            return table;
        }
        public static void SetPartValue(DataTable dtPartMeasures)
        {
            DataSet dsData = new DataSet();
            dtPartMeasures.TableName = "PartValue";								 
            dsData.Tables.Add(dtPartMeasures);
#if DEBUG
			// For debugging only
			var date1 = System.DateTime.Now.Millisecond;
			string filename = @"C:\DELL\" + date1.ToString() + "_myXmlSetPartValue.xml";
			if (File.Exists(filename)) File.Delete(filename);
			// Create the FileStream to write with.
			System.IO.FileStream myFileStream = new System.IO.FileStream(filename, System.IO.FileMode.Create);
			// Create an XmlTextWriter with the fileStream.
			System.Xml.XmlTextWriter myXmlWriter = new System.Xml.XmlTextWriter(myFileStream, System.Text.Encoding.Unicode);
			// Write to the file with the WriteXml method.
			dsData.WriteXml(myXmlWriter);
			myXmlWriter.Close();
			// End of debugging part
#endif

			ProxyGenericSet(dsData,"Set");//Procedure spSetPartValue

            int BatchId = Convert.ToInt32(dtPartMeasures.Rows[0]["BatchId"]);
            int ItemCode = Convert.ToInt32(dtPartMeasures.Rows[0]["ItemCode"]);
            UpdateEstimatedPartValues(BatchId, ItemCode);
        }

        public static string GetNewItemCodeByCode(string OrderCode,string GroupCode,string BatchCode,string ItemCode)
        {
            string result = "";
            DataSet dsData = new DataSet();		
            DataTable dt = new DataTable("NewItemCodeByCode");
            dt.Columns.Add("OrderCode");
            dt.Columns.Add("GroupCode");
            dt.Columns.Add("BatchCode");
            dt.Columns.Add("ItemCode");
            dt.Rows.Add(new object[]{OrderCode,GroupCode,BatchCode,ItemCode});
            dsData.Tables.Add(dt);
            dsData = ProxyGenericGet(dsData);
			
            try
            {result = dsData.Tables[0].Rows[0][0].ToString();}
            catch(Exception ex)
            {string msg = ex.Message;}
            return result;
        }

        public static DataSet GetNewBatchIDItemCode(string BatchID,string ItemCode)
        {
            DataSet result = null;
            DataSet dsData = new DataSet();		
            DataTable dt = new DataTable("NewBatchIDItemCode");
            dt.Columns.Add("BatchID");
            dt.Columns.Add("ItemCode");
            dt.Rows.Add(new object[]{BatchID,ItemCode});
            dsData.Tables.Add(dt);
            result = ProxyGenericGet(dsData);//Procedure dbo.spGetNewBatchIDItemCode
            return result;
        }

        public static string GetNewItemCodeByBathcID(string BatchID,string ItemCode)
        {
            string result = "";
            DataSet dsData = new DataSet();		
            DataTable dt = new DataTable("NewItemCodeByBathcID");
            dt.Columns.Add("BatchID");
            dt.Columns.Add("ItemCode");
            dt.Rows.Add(new object[]{BatchID,ItemCode});
            dsData.Tables.Add(dt);
            dsData = ProxyGenericGet(dsData);
            try
            {result = dsData.Tables[0].Rows[0][0].ToString();}
            catch(Exception ex)
            {string msg = ex.Message;}
            return result;
        }

#endregion Remeasure

#region DepSettings
        public static DataTable GetDepartureSet()
        {
            DataSet dsData = new DataSet();
            DataTable tmpCustomer = dsData.Tables.Add("Customers");
			
            dsData = ProxyGenericGet(dsData);			
			
            DataTable table = dsData.Tables["Customers"];
            Prepare_GetCustomer(table);

            return table;
        }
	
#endregion DepSettings

#region Grader
        /*public static string GetGraderDir()
        {
            try
            {
                CreateService();
                return srv.GetGraderDir();
            }
            catch(Exception eEx)
            {
                throw new Exception("Couldn't get grader directory from service configuration file\n"+eEx.Message);
            }
        }*/


        /// <summary>
        /// Calls web method that add grader data from specified file to the db
        /// </summary>
        /// <param name="sFilePath">path to file</param>
        /// <returns>date of adding data</returns>		
        public static DateTime AddGraderData(string sFilePath, string sPartID,out string rId)
        {
            try
            {
                return ProxyAddGraderData(sFilePath,sPartID, out rId);
            }
            catch(Exception e)
            {
				
                //MessageBox.Show(e.Message);
                //Service.log.Write(@"'Service.AddGraderData: Exception'"+e.Message);
                //throw new Exception("Couldn't add data from file "+sFilePath+" into db\n"+eEx.Message);
                rId = "1";
                return DateTime.Now;
            }
        }
				
        public static DateTime AddGraderData2(string sFilePath, out string rId)
        {
            string sPartID="";
            return ProxyAddGraderData(sFilePath,sPartID, out rId);
        }



        public static DataSet GetPartPossibleEnumValues(int partID, int ViewAccessCode)
        {
            try
            {
                DataSet dsIn = new DataSet();
                dsIn.Tables.Add("PartPossibleEnumValues");
                dsIn.Tables[0].Columns.Add("PartID");
                dsIn.Tables[0].Columns.Add("ViewAccessCode");
                dsIn.Tables[0].Rows.Add(new object[] {partID, ViewAccessCode});

                return ProxyGenericGet(dsIn);				
            }
            catch(Exception eEx)
            {
                throw new Exception("Couldn't get possible enum values for part\n"+eEx.Message);				
            }
        }

        /// <summary>
        /// Gets keymap file from server
        /// </summary>
        /// <param name="sFileName">keymap file name</param>
        /// <returns>true if successful and false otherwise</returns>
        public static bool GetKeymap(string sFileName)
        {
            try
            {
				//MessageBox.Show("Step 1. GetKeymap load file: " + sFileName);
				string sKeymap = ProxyGetGraderKeymap(sFileName);
				//MessageBox.Show("Step 2. GetKeymap got stream of file: " + sFileName);
                sFileName = Service.sTempDir + System.IO.Path.DirectorySeparatorChar + sFileName;

				if (File.Exists(sFileName)) File.Delete(sFileName);

					using (File.Create(sFileName)){}
				//MessageBox.Show("Step 3. Create file: " + sFileName);
                using(FileStream fsWrite = File.OpenWrite(sFileName))
                {
                    fsWrite.SetLength(0);
                    Byte[] bInfo = new UTF8Encoding(true).GetBytes(sKeymap);
                    fsWrite.Write(bInfo, 0, bInfo.Length);
                    fsWrite.Close();
                }

                return true;
            }
            catch(Exception eEx)
            {
                throw new Exception("Couldn't load file " + sFileName + "\n" + eEx.Message);
            }
        }

        public static string GetOfficeConfig(string sOfficeIPGroup, string sTagName)
        {
            //            XmlNode myOfficeNode; 
            //            string sMyOfficeConfigXml;
            //            try
            //            {
            //                XmlDocument xmlDoc = new XmlDocument();
            //                xmlDoc = Service.xmlOffices;
            //                XmlNode root = xmlDoc.DocumentElement;
            //                string sXPath = "OfficeNumbers[OfficeIPGroup = '" + sOfficeIPGroup + "']";
            //                myOfficeNode = root.SelectSingleNode(sXPath); 
            //                if(myOfficeNode != null)
            //                {
            //                    sMyOfficeConfigXml = myOfficeNode.LastChild.InnerText.ToString();
            //                    return sMyOfficeConfigXml.Trim();
            //                }
            //                else return "";
            //            }
            //            catch{ return "";} 
            XmlNode myOfficeNode; 
             string sMyOfficeConfigXml = "";
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc = Service.xmlOffices;
                XmlNode root = xmlDoc.DocumentElement;
                string sXPath = "OfficeNumbers[OfficeIPGroup = '" + sOfficeIPGroup + "']";
                myOfficeNode = root.SelectSingleNode(sXPath); 
                if(myOfficeNode != null && myOfficeNode.HasChildNodes)
                {
                    foreach(XmlNode temp in myOfficeNode.ChildNodes)
                    {
                        if(temp.Name == sTagName)
                        {
                            sMyOfficeConfigXml = temp.InnerText.ToString();
                            break;
                        }
                    }

                    return sMyOfficeConfigXml.Trim();
                }
                else 
                {
                    return "";
                }
            }
            catch(Exception eEx)
            {
                MessageBox.Show(eEx.Message);
                return "";
            }
     
        }

        /// <summary>
        /// Sets item state in the db
        /// </summary>
        /// <param name="iGroupCode">group code</param>
        /// <param name="iBatchCode">batch code</param>
        /// <param name="iItemCode">item code</param>
        /// <param name="iStateCode">state code</param>
		
        public static void SetItemStateByCode(int iGroupCode, int iBatchCode, int iItemCode, int iStateCode)
        {
            try
            {
                DataSet dsPrms = new DataSet();
                DataTable dtPrms = dsPrms.Tables.Add("ItemStateByCode");
                dtPrms.Columns.Add("StateCode");
                dtPrms.Columns.Add("GroupCode");
                dtPrms.Columns.Add("BatchCode");
                dtPrms.Columns.Add("ItemCode");
                DataRow drPrms = dtPrms.Rows.Add(new object[] {});
                drPrms["StateCode"] = iStateCode;
                drPrms["GroupCode"] = iGroupCode;
                drPrms["BatchCode"] = iBatchCode;
                drPrms["ItemCode"]  = iItemCode;

                ProxyGenericSet(dsPrms, "Set");
            }
            catch(Exception eEx)
            {
                throw new Exception("Coludn't set item state\n" + eEx.Message);
            }
        }

		public static string CheckIsItem(string ItemNumber)
		{
			return "";
		}

		public static string GetItemNumberBy7digit(string ItemNumber)
		{
			string rexBracket = (@"^\d{7}");
			Regex mm = new Regex(rexBracket);
			if (!Regex.IsMatch(ItemNumber, @"^\d{10,12}$"))
			{
				foreach (Match myMatch in mm.Matches(ItemNumber))
				{
					if (myMatch.ToString().Length == 7)
					{
						ItemNumber = myMatch.ToString();
						var measureId = 112;
						var maxRows = 1;
						DataSet dsData = new DataSet();
						dsData.Tables.Add("FindItemByValue");
						dsData.Tables[0].Columns.Add("StringValue");
						dsData.Tables[0].Columns.Add("rows");
						dsData.Tables[0].Columns.Add("MeasureID");
						dsData.Tables[0].Rows.Add(dsData.Tables[0].NewRow());
						//dsData.Tables[0].Rows[0]["StringValue"] = ItemNumber.Trim() + "%";
                        dsData.Tables[0].Rows[0]["StringValue"] = ItemNumber.Trim(); // +"%";
						dsData.Tables[0].Rows[0]["rows"] = maxRows;
						dsData.Tables[0].Rows[0]["MeasureID"] = measureId;
						dsData = ProxyGenericGet(dsData);
						if (dsData.Tables[0].Rows.Count == 1)
							ItemNumber = Convert.ToString(dsData.Tables[0].Rows[0]["NewItemNumber"]);
						break;
					}
				}
			}
			return ItemNumber;
		}


        /// <summary>
        /// Gets batch info for Clarity form
        /// </summary>
        /// <param name="iOrderCode">order code</param>
        /// <param name="iEntryBatchCode">entrybatch code</param>
        /// <param name="iBatchCode">batch code</param>
        /// <returns>clarity batch info</returns>
        public static DataSet GetClarityBatchInfo(int iOrderCode, int iEntryBatchCode, int iBatchCode, int iItemCode, bool FullAccess)
        {
            DataSet dsSet = GetBatchInfo(iOrderCode, iEntryBatchCode, iBatchCode, iItemCode, GraderLib.Codes.Clarity, FullAccess);
            return dsSet;
        }

        /// <summary>
        /// Updates batch info for Color form
        /// </summary>
        /// <param name="dsClarityBatch">full clarity batch information</param>
        /// <returns>true if successful and false otherwise</returns>
        public static void UpdateClarityBatchInfo(DataSet dsClarityBatch)
        {
            UpdateBatchInfo(dsClarityBatch, GraderLib.Codes.Clarity);
            //Old part
            //int BatchId = Convert.ToInt32(dsClarityBatch.Tables["tblValues"].Rows[0]["BatchId"]);
            //int ItemCode = Convert.ToInt32(dsClarityBatch.Tables["tblValues"].Rows[0]["ItemCode"]);
            //End of old part
            //New part 02.19.08
            int BatchId = 0;
            int ItemCode = 0;
            if (dsClarityBatch.Tables["tblValues"].Rows.Count > 0)
            {
                BatchId = Convert.ToInt32(dsClarityBatch.Tables["tblValues"].Rows[0]["BatchId"]);
                ItemCode = Convert.ToInt32(dsClarityBatch.Tables["tblValues"].Rows[0]["ItemCode"]);
                UpdateEstimatedPartValues(BatchId, ItemCode);
            }
            //int BatchId = Convert.ToInt32(dsClarityBatch.Tables["tblItems"].Rows[0]["NewBatchId"]);
            //int ItemCode = Convert.ToInt32(dsClarityBatch.Tables["tblItems"].Rows[0]["NewItemCode"]);
            //End of new part 
			
            //Commented 02.20.08
            //			try
            //			{
            //				if (iInvoiceDebugLevel >= 1)
            //				{
            //					int iViewAccessCode = 4; // ViewAccess = "Clarity"
            //					DBAddInvoice(iViewAccessCode, BatchId, ItemCode);
            //				}
            //				
            //			}
            //			catch(Exception exc)
            //			{
            //				if (iInvoiceDebugLevel >= 3) MessageBox.Show("Warning: Can't add invoice for Clarity:\r\n"+exc.Message);
            //			}

        }


        /// <summary>
        /// Gets batch info for Color form
        /// </summary>
        /// <param name="iOrderCode">order code</param>
        /// <param name="iEntryBatchCode">entrybatch code</param>
        /// <param name="iBatchCode">batch code</param>
        /// <returns>color batch info</returns>
        public static DataSet GetColorBatchInfo(int iOrderCode, int iEntryBatchCode, int iBatchCode, int iItemCode, bool FullAccess)
        {
            DataSet dsSet = GetBatchInfo(iOrderCode, iEntryBatchCode, iBatchCode, iItemCode, GraderLib.Codes.Color, FullAccess);
            return dsSet;
        }

        /// <summary>
        /// Updates batch info for Color form
        /// </summary>
        /// <param name="dsColorBatch">full color batch information</param>
        /// <returns>true if successful and false otherwise</returns>
        public static void UpdateColorBatchInfo(DataSet dsColorBatch)
        {
            UpdateBatchInfo(dsColorBatch, GraderLib.Codes.Color);
            //Old part
            //int BatchId = Convert.ToInt32(dsColorBatch.Tables["tblValues"].Rows[0]["BatchId"]);
            //int ItemCode = Convert.ToInt32(dsColorBatch.Tables["tblValues"].Rows[0]["ItemCode"]);
            //End of old part
            //New part 02.19.08
            int BatchId = 0;
            int ItemCode = 0;

            if (dsColorBatch.Tables["tblValues"].Rows.Count > 0)
            {
                BatchId = Convert.ToInt32(dsColorBatch.Tables["tblValues"].Rows[0]["BatchId"]);
                ItemCode = Convert.ToInt32(dsColorBatch.Tables["tblValues"].Rows[0]["ItemCode"]);
                UpdateEstimatedPartValues(BatchId, ItemCode);
            }
            //End of new part
            //Commented 02.20.08
            //			try
            //			{
            //				if (iInvoiceDebugLevel >= 1)
            //				{
            //					int iViewAccessCode = 5; // ViewAccess = "Color"
            //					DBAddInvoice(iViewAccessCode, BatchId, ItemCode);
            //				}
            //				
            //			}
            //			catch(Exception exc)
            //			{
            //				if (iInvoiceDebugLevel >= 3) MessageBox.Show("Warning: Can't add invoice for Color:\r\n"+exc.Message);
            //			}
        }


        /// <summary>
        /// Gets full batch information for Measure form
        /// </summary>
        /// <param name="iOrderCode">order code</param>
        /// <param name="iEntryBatchCode">entrybatch code</param>
        /// <param name="iBatchCode">batch code</param>
        /// <returns>measure batch information</returns>
        public static DataSet GetMeasureBatchInfo(int iOrderCode, int iEntryBatchCode, int iBatchCode, int iItemCode, bool bFullAccess)
        {
            DataSet dsSet = GetBatchInfo(iOrderCode, iEntryBatchCode, iBatchCode, iItemCode, GraderLib.Codes.Measure, bFullAccess);
            return dsSet;
        }

        /// <summary>
        /// Updates batch info for Color form
        /// </summary>
        /// <param name="dsMeasureBatch">full measure batch information</param>
        /// <returns>true if successful and false otherwise</returns>
        public static void UpdateMeasureBatchInfo(DataSet dsMeasureBatch)
        {
            UpdateBatchInfo(dsMeasureBatch, GraderLib.Codes.Measure);
        }
		

        /// <summary>
        /// Gets full batch information for Measure form
        /// </summary>
        /// <param name="iOrderCode">order code</param>
        /// <param name="iEntryBatchCode">entrybatch code</param>
        /// <param name="iBatchCode">batch code</param>
        /// <param name="AccessCode">viewaccess code</param>
        /// <returns>batch information</returns>
        private static DataSet GetBatchInfo(int iOrderCode, int iEntryBatchCode, int iBatchCode, int iItemCode, int AccessCode, bool FullAccess)
        {
            DataSet dsSet = new DataSet();
            DataSet dsRet, dsPrms;
            DataTable dtPrms;

            try
            {
#region items table
                dsPrms = new DataSet();
                dtPrms = dsPrms.Tables.Add(GraderLib.Sp.ItemsStruct);
                dsPrms = ProxyGenericGet(dsPrms); // Procedure  spGetItemByCodeTypeEx
                dtPrms = dsPrms.Tables[0];
                dtPrms.TableName = GraderLib.Sp.Items + "1";
                dsPrms.Tables[0].Rows.Add(dsPrms.Tables[0].NewRow());
                //dtPrms.Rows.Add(new object[] {});
                dtPrms.Rows[0]["GroupCode"] = iOrderCode.ToString();
                dtPrms.Rows[0]["BatchCode"] = iBatchCode.ToString();
                dtPrms.Rows[0]["ItemCode"] =  iItemCode.ToString();
                //dsRet = ProxyGenericGet(dsPrms);
                dsRet = new DataSet(); //Added by Sasha 12/08/08
                dsRet = ProxyGenericGet(dsPrms); // Procedure spGetItemCPPictureByCode1
                DataTable dtItem = dsSet.Tables.Add("tblItems");
                dtItem.Columns.Add("ItemTypeId");
                dtItem.Columns.Add("BatchId");
                dtItem.Columns.Add("OrderCode");
                dtItem.Columns.Add("EntryBatchCode");
                dtItem.Columns.Add("BatchCode");
                dtItem.Columns.Add("ItemCode");
                dtItem.Columns.Add("ItemComment");
                dtItem.Columns.Add("IsBlock");
                dtItem.Columns.Add("IsDone");
                dtItem.Columns.Add("CPPicturePath");
                dtItem.Columns.Add("CPPicturePicture");
                dtItem.Columns.Add("NewBatchID");
                dtItem.Columns.Add("NewItemCode");
                dtItem.Columns.Add("PrevGroupCode");
                dtItem.Columns.Add("PrevBatchCode");
                dtItem.Columns.Add("PrevItemCode");
	
                foreach(DataTable dtRet in dsRet.Tables)
                {
                    if(dtRet.Rows.Count == 0)
                        throw new Exception("There is no batches with entered code in the db");

                    foreach(DataRow drRet in dtRet.Rows)
                    {
                        object oItemTypeId = drRet["ItemTypeID"];
                        object oBatchId = drRet["BatchID"];
                        object oOrderCode = drRet["OrderCode"];
                        object oEntryBatchCode = drRet["GroupCode"];
                        object oBatchCode = drRet["BatchCode"];
                        object oItemCode = drRet["ItemCode"];
                        object oIsBlock = drRet["StateCode"];
                        object oItemComment = drRet["ItemComment"];
                        object oCPPicturePath = drRet["Path2Picture"];
                        object oCPPicturePicture = drRet["Image_Path2Picture"];
                        object oNewBatchID = drRet["NewBatchID"];
                        object oNewItemCode = drRet["NewItemCode"];
                        object oPrevGroupCode = drRet["PrevGroupCode"];
                        object oPrevBatchCode = drRet["PrevBatchCode"];
                        object oPrevItemcode = drRet["PrevItemCode"];
                        dtItem.Rows.Add(new object[] {	oItemTypeId, 
                                                         oBatchId, 
                                                         oOrderCode,
                                                         oEntryBatchCode, 
                                                         oBatchCode, 
                                                         oItemCode, 
                                                         oItemComment, 
                                                         oIsBlock, 
                                                         0, 
                                                         oCPPicturePath, 
                                                         oCPPicturePicture,
                                                         oNewBatchID,
                                                         oNewItemCode,
                                                         oPrevGroupCode, 
                                                         oPrevBatchCode, 
                                                         oPrevItemcode});
                        //dsSet.Tables.Add(dtRet.Copy());
                    }
                }
#endregion

#region parts table
                dsPrms = new DataSet();
                dtPrms = dsPrms.Tables.Add(GraderLib.Sp.PartsStruct);
                dsPrms = ProxyGenericGet(dsPrms);// Procedure spGetItemTypeTypeEx
                dtPrms = dsPrms.Tables[0]; 
                dtPrms.TableName = GraderLib.Sp.Parts;
                dtPrms.Rows.Add(new object[] {});
                dtPrms.Rows[0]["ItemTypeID"] = dtItem.Rows[0]["ItemTypeId"];//oItemTypeId;
                //dtPrms.Rows[0]["BatchID"] = dtItem.Rows[0]["BatchId"];
                dsRet = ProxyGenericGet(dsPrms);// procedure spGetPartsByItemType
                DataTable dtParts = dsSet.Tables.Add("tblParts");
                dtParts.Columns.Add("PartId");
                dtParts.Columns.Add("PartTypeId");
                dtParts.Columns.Add("OrderCode");
                dtParts.Columns.Add("EntryBatchCode");
                dtParts.Columns.Add("BatchCode");
                dtParts.Columns.Add("ItemCode");
                dtParts.Columns.Add("PartName");
                dtParts.Columns.Add("LaserInscription");
                dtParts.Columns.Add("ShapePath");
                dtParts.Columns.Add("PicturePath");
                dtParts.Columns.Add("ShapePicture");
                dtParts.Columns.Add("PicturePicture");
		
                //dtParts.Columns.Add("Comment");
                foreach(DataTable dtRet in dsRet.Tables)
                    foreach(DataRow drRet in dtRet.Rows)
                    {
                        object oPartId = drRet["PartID"];
                        object oPartTypeId = drRet["PartTypeID"];
                        object oPartName = drRet["PartName"];
                        object oLaserInscription = DBNull.Value;//drRet["LaserInscription"];
                        //object oPicturePath = drRet["Path2Picture"];
                        object oShapePath = drRet["Path2Drawing"];
                        //object oPicturePicture = drRet["Image_Path2Picture"];
                        object oShapePicture = drRet["Image_Path2Drawing"];

                        foreach(DataRow drItem in dtItem.Rows)
                        {
                            object oOrderCode = drItem["OrderCode"];
                            object oEntryBatchCode = drItem["EntryBatchCode"];
                            object oBatchCode = drItem["BatchCode"];
                            object oItemCode = drItem["ItemCode"];
                            //object oComment = DBNull.Value;//drItem["ItemComment"];
                            object oPicturePath =  drItem["CPPicturePath"];
                            object oPicturePicture = drItem["CPPicturePicture"];

                            dtParts.Rows.Add(new object[] {	oPartId, 
                                                              oPartTypeId, 
                                                              oOrderCode, 
                                                              oEntryBatchCode, 
                                                              oBatchCode, 
                                                              oItemCode, 
                                                              oPartName, 
                                                              oLaserInscription, 
                                                              oShapePath, 
                                                              oPicturePath, 
                                                              oShapePicture, 
                                                              oPicturePicture});
                        }

                        //dtParts.Rows.Add(new object[] {oPartId, oPartTypeId, oOrderCode, oEntryBatchCode, oBatchCode, oItemCode, oPartName, oLaserInscription, oComment});
                        //dsSet.Tables.Add(dtRet.Copy());
                    }
#endregion

#region item parts measures table
				
                dsPrms = new DataSet();
                if(!FullAccess)
                {
                    dtPrms = dsPrms.Tables.Add(GraderLib.Sp.MeasuresStruct);
                    dsPrms = ProxyGenericGet(dsPrms);//Procedure spGetItemMeasuresByViewAccessAndCPTypeEx
                    dtPrms = dsPrms.Tables[0];
                    dtPrms.TableName = GraderLib.Sp.Measures;
                    dtPrms.Rows.Add(new object[] {});
                    dtPrms.Rows[0]["ItemTypeID"] = dtItem.Rows[0]["ItemTypeId"];//oItemTypeId;
                    dtPrms.Rows[0]["ViewAccessCode"] = AccessCode;
                    dtPrms.Rows[0]["BatchID"] = dtItem.Rows[0]["NewBatchId"];
                }
                else
                {
                    dtPrms = dsPrms.Tables.Add(GraderLib.Sp.FullMeasuresStruct);
                    dsPrms = ProxyGenericGet(dsPrms);//Procedure spGetItemMeasuresByViewAccessTypeEx
                    dtPrms = dsPrms.Tables[0];
                    dtPrms.TableName = GraderLib.Sp.FullMeasures;
                    dtPrms.Rows.Add(new object[] {});
                    dtPrms.Rows[0]["ItemTypeID"] = dtItem.Rows[0]["ItemTypeId"];//oItemTypeId;
                    dtPrms.Rows[0]["ViewAccessCode"] = AccessCode;
                }
                //dtPrms.Rows[0]["BatchCode"] = iBatchCode;
                dsRet = ProxyGenericGet(dsPrms);//Procedure spGetItemMeasuresByViewAccessAndCP- or spGetItemMeasuresByViewAccessNoCP
                DataTable dtChars = dsSet.Tables.Add("tblChars");
                dtChars.Columns.Add("CharId");
                dtChars.Columns.Add("PartId");
                dtChars.Columns.Add("PartName");
                dtChars.Columns.Add("ItemCode");
                dtChars.Columns.Add("CharName");
                dtChars.Columns.Add("CharCode");
                dtChars.Columns.Add("IsEdit");

                /*string sPath = @"E:\work\~gemoDream\measures.txt";
                if(!File.Exists(sPath))
                    File.Create(sPath);
                FileStream fsWrite = new FileStream(sPath, FileMode.Append);
                //fsWrite.Position = fsWrite.Length;
                byte[] bInfo = new UTF8Encoding(true).GetBytes("\n");
                fsWrite.Write(bInfo, 0, bInfo.Length);*/

                foreach(DataTable dtRet in dsRet.Tables)
                {
                    if(dtRet.Rows.Count == 0)
                        throw new Exception("There is no measures for entered batch in the db");

                    foreach(DataRow drRet in dtRet.Rows)
                    {
                        object oCharId = drRet["MeasureID"];//MeasureID
                        object oCharName = drRet["MeasureName"];
                        object oCharCode = drRet["MeasureCode"];
                        object oIsEdit = drRet["IsEdit"];
                        object oMeasureClass = drRet["MeasureClass"];

                        object oPartTypeId = drRet["PartTypeID"];
                        object oPartId = DBNull.Value;
                        object oPartName = DBNull.Value;
                        object oItemCode = DBNull.Value;
						
                        //sd 11.02.06 after changed spGetItemMeasuresByViewAccessAndCP
                        oPartId = drRet["PartId"];
                        oPartName = drRet["PartName"];

						DataView dvPartTypeParts = new DataView(dtParts)
						{
							RowFilter = "PartTypeId = '" + oPartTypeId + "' and PartID = '" + oPartId + "'"
						};


						foreach (DataRowView drvPart in dvPartTypeParts)
                        {
                            //oPartId = drvPart["PartId"];
                            //oPartName = drvPart["PartName"];
                            //oItemCode = drvPart["ItemCode"];
							
                            oItemCode = drvPart["ItemCode"];

                            dtChars.Rows.Add(new object[] {oCharId, oPartId, oPartName, oItemCode, oCharName, oCharCode, oIsEdit});

                            //bInfo = new UTF8Encoding(true).GetBytes("Item: "+oItemCode+"; Part: "+oPartName+"("+oPartId+"); Measure: "+oCharName+"("+oCharId+"-"+oMeasureClass+")\n");
                            //fsWrite.Write(bInfo, 0, bInfo.Length);
                        }

                        //dtChars.Rows.Add(new object[] {oCharId, oPartId, oPartName, oCharName, oCharCode, oIsEdit});
                        //dsSet.Tables.Add(dtRet.Copy());
                    }
                }
                //fsWrite.Close();
#endregion

#region valuecodes table
                dsPrms = new DataSet();
                dtPrms = dsPrms.Tables.Add(GraderLib.Sp.MeasureValues);
                dsRet = ProxyGenericGet(dsPrms);//Procedure spGetMeasureValues
                DataTable dtValueCodes = dsSet.Tables.Add("tblValueCodes");
                dtValueCodes.Columns.Add("ValueId");
                dtValueCodes.Columns.Add("ValueCode");
                dtValueCodes.Columns.Add("ValueName");
                dtValueCodes.Columns.Add("CharId");
                foreach(DataTable dtRet in dsRet.Tables)
                    foreach(DataRow drRet in dtRet.Rows)
                    {
                        object oValueId = drRet["MeasureValueID"];
                        object oValueCode = drRet["ValueCode"];
                        object oValueName = drRet["MeasureValueName"];
                        //Changed MeasureCode to MeasureValueMeasureID because GraderLib.GetPartCharIds() compares ID and code otherwise.
                        //By 3ter on 2006.03.17. Bug
                        //						object oCharId = drRet["MeasureCode"];
                        object oCharId = drRet["MeasureValueMeasureID"];
						
                        dtValueCodes.Rows.Add(new object[] {oValueId, oValueCode, oValueName, oCharId});
                    }
#endregion

#region value, value history tables
                DataTable dtValues = dsSet.Tables.Add("tblValues");
                dtValues.Columns.Add("ValueId");
                dtValues.Columns.Add("Value");
                dtValues.Columns.Add("MeasureId");
                dtValues.Columns.Add("MeasureCode");
                dtValues.Columns.Add("PartId");
                dtValues.Columns.Add("PartName");
                dtValues.Columns.Add("ItemCode");
                dtValues.Columns.Add("BatchId");
                dtValues.Columns.Add("StringValue");

                dtValues.Columns.Add("IsDone"); //New Part, added 02.05.08

                DataTable dtValues0 = dsSet.Tables.Add("tblValues0");
                dtValues0.Columns.Add("ValueId");
                dtValues0.Columns.Add("Value");
                dtValues0.Columns.Add("MeasureId");
                dtValues0.Columns.Add("MeasureCode");
                dtValues0.Columns.Add("PartId");
                dtValues0.Columns.Add("PartName");
                dtValues0.Columns.Add("ItemCode");
                dtValues0.Columns.Add("BatchId");
                dtValues0.Columns.Add("StringValue");

                dtValues0.Columns.Add("IsDone"); //New Part, added 02.05.08

                for(int j=1; j<4; j++)
                {
                    DataTable dtHistory = dsSet.Tables.Add("tblHistory"+j);
                    dtHistory.Columns.Add("ValueId");
                    dtHistory.Columns.Add("Value");
                    dtHistory.Columns.Add("MeasureId");
                    dtHistory.Columns.Add("MeasureCode");
                    dtHistory.Columns.Add("PartId");
                    dtHistory.Columns.Add("PartName");
                    dtHistory.Columns.Add("ItemCode");
                    dtHistory.Columns.Add("BatchId");
                    dtHistory.Columns.Add("StringValue");
                }
                //-----------------------by Vetal----------------------------
                DataRow drItemPV = dtItem.Rows[0];

                dsPrms = new DataSet();
                dtPrms = dsPrms.Tables.Add(GraderLib.Sp.PartValuesStruct);
                dsPrms = ProxyGenericGet(dsPrms);//Procedure spGetPartValueCCMTypeEx
                dtPrms = dsPrms.Tables[0];
                if(!FullAccess) dtPrms.TableName = GraderLib.Sp.PartValues;
                else dtPrms.TableName = GraderLib.Sp.PartValuesFull;
                dtPrms.Rows.Add(new object[] {});
				
                dtPrms.Rows[0]["ViewAccessCode"] = AccessCode;
                dtPrms.Rows[0]["BatchID"] = drItemPV["BatchId"];// dtItem.Rows[0]["BatchId"];//DBNull.Value;
                dtPrms.Rows[0]["ItemTypeID"] = drItemPV["ItemTypeID"];//drItemPV["ItemCode"];//DBNull.Value;//DBNull.Value;
                dsRet = ProxyGenericGet(dsPrms);//Procedure spGetPartValueCCM

                //				DataColumn[] PrimaryKeyColumns = new DataColumn[3];
                //				PrimaryKeyColumns[0] = dsRet.Tables[0].Columns["MeasureId"];
                //				PrimaryKeyColumns[1] = dsRet.Tables[0].Columns["PartId"];
                //				PrimaryKeyColumns[2] = dsRet.Tables[0].Columns["ItemCode"];
                //				dsRet.Tables[0].PrimaryKey = PrimaryKeyColumns;
                //
                //				DataColumn[] PrimaryKeyColumnsPartss = new DataColumn[2];
                //				PrimaryKeyColumnsPartss[0] = dsSet.Tables["tblParts"].Columns["PartId"];
                //				PrimaryKeyColumnsPartss[1] = dsSet.Tables["tblParts"].Columns["ItemCode"];
                //				dsSet.Tables["tblParts"].PrimaryKey = PrimaryKeyColumnsPartss;

                dtValues.BeginLoadData();
                dtValues0.BeginLoadData();
                dsSet.Tables["tblHistory1"].BeginLoadData();
                dsSet.Tables["tblHistory2"].BeginLoadData();
                dsSet.Tables["tblHistory3"].BeginLoadData();
                foreach(DataRow drRet in dsRet.Tables[0].Rows)
                {
                    if(Convert.ToInt32(drRet["RecheckNumber"]) == 1)
                        dsSet.Tables["tblHistory1"].LoadDataRow(new object[] {drRet["MeasureValueID"], drRet["MeasureValue"], drRet["MeasureID"], drRet["MeasureCode"], drRet["PartID"], drRet["PartName"], drRet["ItemCode"], drItemPV["BatchId"], drRet["StringValue"]}, true);
						
                    if(Convert.ToInt32(drRet["RecheckNumber"]) == 2)
                        dsSet.Tables["tblHistory2"].LoadDataRow(new object[] {drRet["MeasureValueID"], drRet["MeasureValue"], drRet["MeasureID"], drRet["MeasureCode"], drRet["PartID"], drRet["PartName"], drRet["ItemCode"], drItemPV["BatchId"], drRet["StringValue"]}, true);
					
                    if(Convert.ToInt32(drRet["RecheckNumber"]) == 3)
                        dsSet.Tables["tblHistory3"].LoadDataRow(new object[] {drRet["MeasureValueID"], drRet["MeasureValue"], drRet["MeasureID"], drRet["MeasureCode"], drRet["PartID"], drRet["PartName"], drRet["ItemCode"], drItemPV["BatchId"], drRet["StringValue"]}, true);
					
                    if(Convert.ToInt32(drRet["isLastRecheck"]) == 1)
                    {
                        dtValues.LoadDataRow(new object[] {drRet["MeasureValueID"], drRet["MeasureValue"], drRet["MeasureID"], drRet["MeasureCode"], drRet["PartID"], drRet["PartName"], drRet["ItemCode"], drItemPV["BatchId"], drRet["StringValue"]}, true);
                        dtValues0.LoadDataRow(new object[] {drRet["MeasureValueID"], drRet["MeasureValue"], drRet["MeasureID"], drRet["MeasureCode"], drRet["PartID"], drRet["PartName"], drRet["ItemCode"], drItemPV["BatchId"], drRet["StringValue"]}, true);

                        if(!Convert.IsDBNull(drRet["MeasureID"]) && Convert.ToInt32(drRet["MeasureCode"])==GraderLib.Codes.Shape && !Convert.IsDBNull(drRet["MeasureValueID"])) //&& Convert.ToInt32(drRet["isLastRecheck"]) == 1)
                        {
                            int iItemCode1 = Convert.ToInt32(drRet["ItemCode"]);
                            int iPartId = Convert.ToInt32(drRet["PartID"]);
							//int iMeasureValueId = Convert.ToInt32(drRet["MeasureValueID"]);
							//GraderLib.UpdateShapePicture(iMeasureValueId, iOrderCode, iBatchCode, iItemCode, iPartId, ref dsSet, -1/*no form*/);

							DataView dvPartss = new DataView(dsSet.Tables["tblParts"])
							{
								RowFilter = "ItemCode=" + iItemCode1 + " and PartId=" + iPartId
							};

							if (dvPartss.Count > 0)
                            {
                                dvPartss[0]["ShapePath"] = drRet["Path2Drawing"];//ShapePath
                                dvPartss[0]["ShapePicture"] = drRet["Image_Path2Drawing"];//ShapePicture
                            }
		
                        }
                    }
                }
                dtValues.EndLoadData();
                dtValues0.EndLoadData();
                dsSet.Tables["tblHistory1"].EndLoadData();
                dsSet.Tables["tblHistory2"].EndLoadData();
                dsSet.Tables["tblHistory3"].EndLoadData();
#endregion

#region SetDepartmentOfficeId

                //DataSet ds = Service.GetGroupByCode(iOrderCode.ToString());//Procedures: spGetGroupByCodeTypeEx, spGetGroupByCode
                DataSet ds = Service.GetGroupByCode(dtItem.Rows[0]["OrderCode"].ToString());
                if(ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    string sCustomerOfficeID = ds.Tables[0].Rows[0]["CustomerOfficeID"].ToString();
                    Service.SetDepartmentOfficeId(sCustomerOfficeID);
                }
#endregion

#region BatchTracking
				
                object BatchID = dsSet.Tables["tblItems"].Rows[0]["NewBatchId"];
                object EventID = GraderLib.BatchEvents.Opened;
                object ItemsAffected = System.DBNull.Value;
                object ItemsInBatch = dsSet.Tables["tblItems"].Rows.Count;
                object FormID = AccessCode;
#if DEBUG
				string sTest = "";
#else
                SetBatchEvent(EventID, BatchID, FormID, ItemsAffected, ItemsInBatch);
#endif
#endregion
            }
            catch(Exception eEx)
            {
                throw new Exception("Couldn't get batch information from the db\n"+eEx.Message);
            }
#if DEBUG
			// For debugging only			
			string filename = @"C:\DELL\" + "myXmlOrderBatchItemData.xml";
			if (File.Exists(filename)) File.Delete(filename);
			// Create the FileStream to write with.
			System.IO.FileStream myFileStream = new System.IO.FileStream(filename, System.IO.FileMode.Create);
			// Create an XmlTextWriter with the fileStream.
			System.Xml.XmlTextWriter myXmlWriter = new System.Xml.XmlTextWriter(myFileStream, System.Text.Encoding.Unicode);
			// Write to the file with the WriteXml method.
			dsSet.WriteXml(myXmlWriter);
			myXmlWriter.Close();
			// End of debugging part
#endif
            return dsSet;
        }

        /// <summary>
        /// Updates batch info
        /// </summary>
        /// <param name="dsBatch">full  batch information</param>
        private static void UpdateBatchInfo(DataSet dsBatch, int iAccessCode)
        {
            DataSet dsPrms;
            DataTable dtPrms;
			
            try
            {
                DataTable dtValues = dsBatch.Tables["tblValues"];
                dtValues.Columns["ItemCode"].ColumnName = "ItemCode";
                dtValues.Columns["BatchId"].ColumnName = "BatchID";
                dtValues.Columns["PartId"].ColumnName = "PartID";
                dtValues.Columns["MeasureID"].ColumnName = "MeasureID";
                dtValues.Columns["MeasureCode"].ColumnName = "MeasureCode";
                dtValues.Columns["Value"].ColumnName = "MeasureValue";
                dtValues.Columns["ValueId"].ColumnName = "MeasureValueID";
                dtValues.Columns["StringValue"].ColumnName = "StringValue";
                dtValues.Columns.Add("UseClosedRecheckSession");

                dsPrms = new DataSet();
                dtPrms = dsPrms.Tables.Add(GraderLib.Sp.UpdatePartValuesStruct);
                dsPrms = ProxyGenericGet(dsPrms);//Procedure dbo.spGetPartValueTypeOf
                dtPrms = dsPrms.Tables[0];
                dtPrms.TableName = GraderLib.Sp.PartValues;

                DataRow drPrm;
                //DataRowCollection rc = dtValues.Rows.;
                if (dtValues.Rows.Count > 0)
                {
                    for (int i = 0; i < dtValues.Rows.Count; i++)
                    {
                        if (Convert.IsDBNull(dtValues.Rows[i]["IsDone"]))
                        {
                            //if (iAccessCode == 6)
                            dtValues.Rows[i].Delete();
                        }
                    }					
                }
                dtValues.AcceptChanges();

                if (dtValues.Rows.Count > 0)
                {
                    //iEvent = GraderLib.BatchEvents.ClosedUpdated;

                    foreach(DataRow drValue in dtValues.Rows)
                    {
                        drPrm = dtPrms.Rows.Add(new object[] {});
                        foreach(DataColumn dcPrm in dtPrms.Columns)
                        {
                            if(Convert.IsDBNull(drValue[dcPrm.ColumnName]))
                                continue;

                            drPrm[dcPrm] = Convert.ChangeType(drValue[dcPrm.ColumnName], dcPrm.DataType);
                        }
                        DataRow[] dr = dsBatch.Tables[0].Select("BatchID = '"+drValue["BatchID"].ToString() + "' and ItemCode = '"+ drValue["ItemCode"].ToString()+"'");
                        if(dr.Length>0)
                        {
                            drPrm["BatchID"] = dr[0]["NewBatchID"].ToString();
                            drPrm["ItemCode"] = dr[0]["NewItemCode"].ToString();
                        }
                    }
                    ProxyGenericSet(dsPrms, "Set");
                }

                //				if(iAccessCode == GraderLib.Codes.Measure)
                //				{
                //					DataTable dtItems = dsBatch.Tables["tblItems"];
                //					foreach(DataRow drItems in dtItems.Rows)
                //					{
                //						Service.SetItemStateByCode(System.Convert.ToInt32(drItems["OrderCode"]), System.Convert.ToInt32(drItems["BatchCode"]), System.Convert.ToInt32(drItems["ItemCode"]), System.Convert.ToInt32(drItems["IsBlock"]));
                //					}
                //				}

                if(iAccessCode == GraderLib.Codes.Clarity)
                {
                    dsPrms = new DataSet();
                    dtPrms = dsPrms.Tables.Add("PartValueTypeOf");
                    dsPrms = ProxyGenericGet(dsPrms);
                    dtPrms = dsPrms.Tables[0];
                    dtPrms.TableName = "PartValue";
                    DataTable dtItems = dsBatch.Tables["tblItems"];
                    foreach(DataRow drItem in dtItems.Rows)
                    {
                        if (drItem["ItemComment"].ToString() != "" || drItem["ItemComment"] != System.DBNull.Value)
                        {
                            DataRow drPrms = dtPrms.Rows.Add(new object[] {});
                            DataRow[] adrICID = dsBatch.Tables["tblParts"].Select("ItemCode = '" + drItem["ItemCode"] + "' and BatchCode = '" + drItem["BatchCode"] + "' and PartTypeId = '15'");
                            DataRow[] adrItemContainer = dsBatch.Tables["tblValues"].Select("ItemCode = '" + drItem["ItemCode"] + "' and BatchID = '" + drItem["BatchID"] + "' and PartID = '" + adrICID[0]["PartID"] + "' and MeasureCode = '26'");
                            /*
                             drPrms["BatchID"] = drItem["BatchID"];
                            drPrms["ItemCode"] = drItem["ItemCode"];
                            */

                            drPrms["BatchID"] = drItem["NewBatchID"];
                            drPrms["ItemCode"] = drItem["NewItemCode"];
                            drPrms["PartID"] = adrICID[0]["PartID"];
                            drPrms["MeasureCode"] = 26;
                            drPrms["StringValue"] = drItem["ItemComment"].ToString();
                        }
                    }
                    ProxyGenericSet(dsPrms, "Set");
                }
                /*dtValues.Columns["BatchID"].ColumnName = "BatchId";
                dtValues.Columns["PartID"].ColumnName = "PartId";
                dtValues.Columns["MeasureCode"].ColumnName = "CharId";
                dtValues.Columns["MeasureValue"].ColumnName = "Value";
                dtValues.Columns["MeasureValueID"].ColumnName = "ValueId";
                dtValues.Columns.Remove("UseClosedRecheckSession");*/
            }
            catch(Exception eEx)
            {
                throw new Exception("UpdateBatchInfo: Couldn't update batch information in the db\n"+eEx.Message);
            }
#region BatchEvents
            try
            {
                object EventID = System.DBNull.Value;
                object oNumberOfItems = dsBatch.Tables["tblItems"].Rows.Count;
                object oItemsAffected = System.DBNull.Value;
                object BatchID = dsBatch.Tables["tblItems"].Rows[0]["NewBatchID"];
                object FormID = iAccessCode;
                Hashtable ht = new Hashtable();
                DataRow[] dr = dsBatch.Tables["tblItems"].Select("IsDone = '1' ");
                if(dr.Length > 0)
                {
                    oItemsAffected = dr.Length;
                    EventID = GraderLib.BatchEvents.Touched;
                    SetBatchEvent(EventID, BatchID, FormID, oItemsAffected, oNumberOfItems);
                    if (dsBatch.Tables["tblValues"].Rows.Count > 0)
                    {
                        foreach(DataRow dr1 in dsBatch.Tables["tblValues"].Rows)
                        {
                            try
                            {
                                ht.Add(dr1["BatchID"].ToString() + "_" + dr1["ItemCode"].ToString(), null);
                            }
                            catch{}
                        }
                        if(ht.Count > 0)
                        {
                            oItemsAffected = ht.Count;
                            EventID = GraderLib.BatchEvents.Updated;
                            SetBatchEvent(EventID, BatchID, FormID, oItemsAffected, oNumberOfItems);
                        }
                    }
                }
            }
            catch(Exception eEx)
            {
                throw new Exception("UpdateBatchInfo: Couldn't update batch events information:\n" + eEx.Message);
            }

#endregion

        }
#endregion

#region Printing
        /// <summary>
        /// Gets available e-mail adresses and attach file types from server
        /// </summary>
        /// <returns>e-mail adresses and attach file types</returns>
        public static DataSet GetPrintingInfo()
        {
            DataSet dsPrinting = new DataSet();

            DataTable dtMail = dsPrinting.Tables.Add("Email");
            dtMail.Columns.Add("Folder");
            dtMail.Columns.Add("Path");
            dtMail.Rows.Add(new object[] {"Folder1", @"c:\"});
            dtMail.Rows.Add(new object[] {"Folder2", @"c:\"});

            DataTable dtFileType = dsPrinting.Tables.Add("FileType");
            dtFileType.Columns.Add("FileType");
            dtFileType.Columns.Add("FileExtension");
            dtFileType.Rows.Add(new object[] {"Pdf", ".pdf"});
            dtFileType.Rows.Add(new object[] {"Rtf", ".rtf"});

            return dsPrinting;
        }

        /// <summary>
        /// Gets all documents af all orders, batches and items
        /// </summary>
        /// <returns>documents</returns>
        public static DataSet GetDocuments()
        {
            DataSet dsData = GetOrderTreeData();
            DataTable dtCustomer = GetAllCustomer();
            dtCustomer.Columns["CustomerName"].ColumnName = "Name";
            dtCustomer.TableName = "CustomerByCode";
            dsData.Tables.Add(dtCustomer);
            Prepare_GetOrderTree(dsData);

            DataTable dtDocuments = dsData.Tables["tblDocument"].Copy();
            dtDocuments.TableName = "tblDocuments";
            DataSet dsDocuments = new DataSet();
            dsDocuments.Tables.Add(dtDocuments);
            //PrepareDisplayOrderTree(dsData);

            //debug_DiaspalyDataSet(dsData);

            /*DataRelation drel;
            DataColumn parentCol;
            DataColumn childCol;

            dsData.Tables["tblCustomer"].Columns["CustomerID"].ColumnName = "ID";
            parentCol = dsData.Tables["tblCustomer"].Columns["ID"];
            childCol = dsData.Tables["tblOrder"].Columns["ParentID"];
            drel = new DataRelation("Customer_Order", parentCol, childCol);
            dsData.Relations.Add(drel);*/

#region old code
            /*DataSet dsData = new DataSet();

            DataRow drData;
            DataTable dtOrder = dsData.Tables.Add("tblOrder");
            dtOrder.Columns.Add("ID");
            dtOrder.Columns.Add("Name");
            dtOrder.Columns.Add("Code");
            dtOrder.Columns.Add("SateCode");
            dtOrder.Columns.Add("IconIndex");
			
            drData = dtOrder.NewRow();
            drData["ID"] = "1";
            drData["Name"] = "02000.02000";
            drData["SateCode"] = "closed";
            drData["IconIndex"] = "0";
            drData["Code"] = "02000";
            dtOrder.Rows.Add(drData);

            drData = dtOrder.NewRow();
            drData["ID"] = "2";
            drData["Name"] = "02001.02001";
            drData["SateCode"] = "closed";
            drData["IconIndex"] = "1";
            drData["Code"] = "02001";
            dtOrder.Rows.Add(drData);


            DataTable dtBatch = dsData.Tables.Add("tblBatch");
            dtBatch.Columns.Add("ID");
            dtBatch.Columns.Add("ParentID");
            dtBatch.Columns.Add("Name");
            dtBatch.Columns.Add("Code");
            dtBatch.Columns.Add("SateCode");
            dtBatch.Columns.Add("IconIndex");

            drData = dtBatch.NewRow();
            drData["ID"] = "1";
            drData["ParentID"] = "1";
            drData["Name"] = "02000.02000.002";
            drData["Code"] = "002";
            drData["SateCode"] = "open";
            drData["IconIndex"] = "6";
            dtBatch.Rows.Add(drData);


            DataTable dtItem = dsData.Tables.Add("tblItem");
            dtItem.Columns.Add("ID");
            dtItem.Columns.Add("ParentID");
            dtItem.Columns.Add("Name");
            dtItem.Columns.Add("Code");
            dtItem.Columns.Add("SateCode");
            dtItem.Columns.Add("IconIndex");

            drData = dtItem.NewRow();
            drData["ID"] = "1";
            drData["ParentID"] = "1";
            drData["Name"] = "02000.02000.002.01";
            drData["Code"] = "01";
            drData["SateCode"] = "1";
            drData["IconIndex"] = "10";
            dtItem.Rows.Add(drData);
			
            drData = dtItem.NewRow();
            drData["ID"] = "2";
            drData["ParentID"] = "1";
            drData["Name"] = "02000.02000.002.02";
            drData["Code"] = "02";
            drData["SateCode"] = "1";
            drData["IconIndex"] = "9";
            dtItem.Rows.Add(drData);


            DataTable dtDocument = dsData.Tables.Add("tblDocument");
            dtDocument.Columns.Add("ID");
            dtDocument.Columns.Add("ItemID");
            dtDocument.Columns.Add("OrderID");
            dtDocument.Columns.Add("EntryBatchID");
            dtDocument.Columns.Add("BatchID");
            dtDocument.Columns.Add("Name");
            dtDocument.Columns.Add("Code");
            dtDocument.Columns.Add("SateCode");
            dtDocument.Columns.Add("IconIndex");
			
            drData = dtDocument.NewRow();
            drData["ID"] = "1";			
            drData["OrderID"] = "1";
            drData["Name"] = "A02000.02000";
            drData["SateCode"] = 1;
            drData["IconIndex"] = "12";
            dtDocument.Rows.Add(drData);

            drData = dtDocument.NewRow();
            drData["ID"] = "2";			
            drData["BatchID"] = "1";
            drData["Name"] = "A02000.02000.002";
            drData["SateCode"] = 2;
            drData["IconIndex"] = "12";
            dtDocument.Rows.Add(drData);

            drData = dtDocument.NewRow();
            drData["ID"] = "3";			
            drData["ItemID"] = "1";
            drData["Name"] = "A02000.02000.002.01";
            drData["SateCode"] = 3;
            drData["IconIndex"] = "12";
            dtDocument.Rows.Add(drData);


            //Relation
            DataRelation drel;
            DataColumn parentCol;
            DataColumn childCol;

            parentCol = dsData.Tables["tblOrder"].Columns["ID"];
            childCol = dsData.Tables["tblBatch"].Columns["ParentID"];			
            drel = new DataRelation("Order_EntryBacth", parentCol, childCol);
            dsData.Relations.Add(drel);

            parentCol = dsData.Tables["tblBatch"].Columns["ID"];
            childCol = dsData.Tables["tblItem"].Columns["ParentID"];			
            drel = new DataRelation("Batch_Item", parentCol, childCol);
            dsData.Relations.Add(drel);

            parentCol = dsData.Tables["tblItem"].Columns["ID"];
            childCol = dsData.Tables["tblDocument"].Columns["ItemID"];			
            drel = new DataRelation("Item_Document", parentCol, childCol);
            dsData.Relations.Add(drel);

            parentCol = dsData.Tables["tblOrder"].Columns["ID"];
            childCol = dsData.Tables["tblDocument"].Columns["OrderID"];			
            drel = new DataRelation("Order_Document", parentCol, childCol);
            dsData.Relations.Add(drel);

            parentCol = dsData.Tables["tblBatch"].Columns["ID"];
            childCol = dsData.Tables["tblDocument"].Columns["BatchID"];			
            drel = new DataRelation("Batch_Document", parentCol, childCol);
            dsData.Relations.Add(drel);

            //auto generate new field. 
            foreach(DataTable table in dsData.Tables)
            {
                table.Columns.Add("SysCode");
                table.Columns.Add("Hide");
				
                int i = 0;
                foreach(DataRow row in table.Rows)
                {
                    row["SysCode"] = i.ToString();
                    i++;
                    row["Hide"] = "0";
                }
            }
			
            DataTable tblItem = dsData.Tables["tblItem"];

            tblItem.Columns.Add("Number");
            tblItem.Columns.Add("PrevNumber");
            tblItem.Columns.Add("CustWeight");
            tblItem.Columns.Add("CustMeasureUnitID");
            tblItem.Columns.Add("MeasureUnitID");
            tblItem.Columns.Add("Weight");
            tblItem.Columns.Add("LotNumber");
            tblItem.Columns.Add("Comment");

            foreach(DataRow row in dsData.Tables["tblItem"].Rows)
            {				
                row["Number"] = row["Name"];
				
                row["CustWeight"] = "1";
                row["CustMeasureUnitID"] = "1";
                row["MeasureUnitID"] = "2";
                row["Weight"]= "12";
				
                row["Comment"] = "Test Item";
            }*/
#endregion

            return dsDocuments;//dsData;
        }


        /// <summary>
        /// Gets operation template path
        /// </summary>
        /// <param name="OperationTypeOfficeID">Operation Type Office identifier</param>
        /// <param name="OperationTypeID">Operation Type identifier</param>
        /// <returns>template path</returns>
        public static string GetOperationTemplatePath(int OperationTypeOfficeID, int OperationTypeID)
        {
            DataSet dsPrms = new DataSet();
            dsPrms.Tables.Add("OperationTypeTypeEx");
            dsPrms = ProxyGenericGet(dsPrms);
            DataTable dtPrms = dsPrms.Tables[0];
            dtPrms.TableName = "OperationType";
            DataRow drPrms = dtPrms.Rows.Add(new object[] {});
            drPrms["OperationTypeOfficeID_OperationTypeID"] = OperationTypeOfficeID+"_"+OperationTypeID;
            dsPrms = ProxyGenericGet(dsPrms);
            if(dsPrms.Tables[0].Rows.Count == 0)
                throw new Exception("GetOperationTemplatePath: There is no such document in the db");
            string sPath = Convert.ToString(dsPrms.Tables[0].Rows[0]["Path2Templete"]);

            return sPath;
        }

        /// <summary>
        /// Prepares dataset information to be displayed in the order tree
        /// </summary>
        /// <param name="dsData">information to be displayed</param>
        private static void PrepareDisplayOrderTree(DataSet dsData)
        {
            foreach(DataTable dtData in dsData.Tables)
                if(dtData.Columns["OrderCode"]!=null && dtData.Columns["GroupCode"]==null)
                    dtData.Columns["OrderCode"].ColumnName = "GroupCode";

            //debug_DiaspalyDataSet(dsData);

            string sOperationChar = "";
            int iGroupCode = 0;
            //int iOrderCode = 0;
            int iBatchCode = 0;
            int iItemCode = 0;

            object oOperationChar = null;
            object oGroupCode = null;
            //object oOrderCode = null;
            object oBatchCode = null;
            object oItemCode = null;

            foreach(DataTable dtData in dsData.Tables)
            {
                if(dtData.TableName == "tblCustomer")
                    continue;

                foreach(DataRow drData in dtData.Rows)
                {
                    sOperationChar = "";
                    iGroupCode = 0;
                    //iOrderCode = 0;
                    iBatchCode = 0;
                    iItemCode = 0;

                    oOperationChar = null;
                    oGroupCode = null;
                    //oOrderCode = null;
                    oBatchCode = null;
                    oItemCode = null;

                    if(dtData.Columns["OperationChar"] != null)		oOperationChar = drData["OperationChar"];
                    if(dtData.Columns["GroupCode"] != null)			oGroupCode = drData["GroupCode"];
                    //if(dtData.Columns["OrderCode"] != null)			oOrderCode = drData["OrderCode"];
                    if(dtData.Columns["BatchCode"] != null)			oBatchCode = drData["BatchCode"];
                    if(dtData.Columns["ItemCode"] != null)			oItemCode = drData["ItemCode"];

                    if(!Convert.IsDBNull(oOperationChar))	sOperationChar = Convert.ToString(oOperationChar);
                    if(!Convert.IsDBNull(oGroupCode))		iGroupCode = Convert.ToInt32(oGroupCode);
                    //if(!Convert.IsDBNull(oOrderCode))		iOrderCode = Convert.ToInt32(oOrderCode);
                    if(!Convert.IsDBNull(oBatchCode))		iBatchCode = Convert.ToInt32(oBatchCode);
                    if(!Convert.IsDBNull(oItemCode))		iItemCode = Convert.ToInt32(oItemCode);

                    drData["Name"] = sOperationChar;
                    drData["Name"] += GraderLib.GetCorrectFullCodeString(iGroupCode, iGroupCode, iBatchCode, iItemCode);
                }
            }
        }

        /// <summary>
        /// Sets document as done (printed well)
        /// </summary>
        /// <param name="sOperationChar">operation char</param>
        /// <param name="iGroupCode">group code</param>
        /// <param name="iBatchCode">batch code</param>
        /// <param name="iItemCode">item code</param>
        /// <param name="iState">document state</param>
        public static bool SetDocumentState(string sOperationChar, int iGroupCode, int iBatchCode, int iItemCode, int iState)
        {
            object oBatchCode = DBNull.Value;
            object oItemCode = DBNull.Value;
            object oGroupCode = DBNull.Value;
            object oOperationChar = DBNull.Value;
            if(sOperationChar != "")	oOperationChar = sOperationChar;
            if(iGroupCode != 0)			oGroupCode = iGroupCode;
            if(iBatchCode != 0)			oBatchCode = iBatchCode;
            if(iItemCode != 0)			oItemCode = iItemCode;

            DataSet dsDoc = new DataSet();
            DataTable dtDoc = dsDoc.Tables.Add("OperationStateByCode");
            dtDoc.Columns.Add("OperationChar");
            dtDoc.Columns.Add("GroupCode");
            dtDoc.Columns.Add("BatchCode");
            dtDoc.Columns.Add("ItemCode");
            dtDoc.Columns.Add("StateCode");
            dtDoc.Rows.Add(new object[] {oOperationChar, oGroupCode, oBatchCode, oItemCode, iState});

            /*dsDoc = */ProxyGenericSet(dsDoc, "Set");
            //int iSuccess = Convert.ToInt32(dsDoc.Tables[0].Rows[0][0]);
            //if(iSuccess == 0)
            //	return false;

            return true;
        }

        /// <summary>
        /// Sets document as deleted
        /// </summary>
        /// <param name="iDocId">document identifier</param>
        public static bool DeleteDocument(object oDocId)
        {
            DataSet dsPrms = new DataSet();
            DataTable dtPrms = dsPrms.Tables.Add("ItemOperationTypeEx");
            dsPrms = ProxyGenericGet(dsPrms);
            dtPrms = dsPrms.Tables[0];
            dtPrms.TableName = "ItemOperation";
            DataRow drPrms = dtPrms.Rows.Add(new object[] {});
            drPrms["ItemOperationOfficeID_ItemOperationID"] = oDocId;
            dsPrms = ProxyGenericSet(dsPrms, "Expire");

            int iSuccess = Convert.ToInt32(dsPrms.Tables[0].Rows[0][0]);
            if(iSuccess == 0)
                return false;
			
            return true;
        }
		
        /// <summary>
        /// Sends mail to the specified e-mail adress
        /// </summary>
        /// <param name="sTo">e-mail adress</param>
        /// <param name="sFileType">attach file extension</param>
        /// <param name="sAttachPath">path to the attach file</param>
        /// <returns>true if send is sucessfull</returns>
        public static bool SendDocumentByEmail(string sTo, string sAttachPath, DataSet dsFile)
        {
            ProxySendMail(sTo, sAttachPath, "Document");
            return true;
        }

        /// <summary>
        /// Sends document to the specified path
        /// </summary>
        /// <param name="sPath">path</param>
        public static void SendDocument(string sTemplatePath, string sSendPath, string sFileExt, int iOrderCode, int iBatchCode, int iItemCode, string sDocChar)
        {
            DataSet dsBatch = GetCrystalSet(iOrderCode+"_"+iBatchCode,"BatchByCode2");
            DataSet dsItemSet = GetCrystalSet(dsBatch.Tables[0].Rows[0]["BatchID"].ToString()+"_"+iItemCode.ToString(),"Item");
            DataSet dsItemTypeSet = gemoDream.Service.GetCrystalSet(dsItemSet.Tables[0].Rows[0]["ItemTypeID"].ToString(),"ItemType");
            DataSet dsShape=new DataSet();

            if(dsItemSet.Tables[0].Rows[0]["Shape"]!=DBNull.Value)
                dsShape=gemoDream.Service.GetShapeByCode(Convert.ToInt32(dsItemSet.Tables[0].Rows[0]["Shape"]));
			
			
            ProxySendDocument(sTemplatePath, sSendPath, sFileExt, iOrderCode, iBatchCode, iItemCode, dsBatch, dsItemSet, dsItemTypeSet, sDocChar, dsShape);
        }

#endregion

        public static void SetBatchEvent(object oEventID, object oBatchID, object oAccessCode, object oAffectedItems, object oItemsInBatch)
        {
            try
            {
                DataSet dsTemp = new DataSet();
                DataTable dtTemp = dsTemp.Tables.Add(GraderLib.Sp.BatchEventsStruct);
                dsTemp = ProxyGenericGet(dsTemp);// Procedure dbo.spGetBatchEventsTypeEx
                dtTemp = dsTemp.Tables[0];
                dtTemp.Columns["FormID"].ColumnName = "FormCode";
                dtTemp.TableName = GraderLib.Sp.BatchEventUpdate;
                dtTemp.Rows.Add(new object[] {oAccessCode, oEventID, oBatchID, oAffectedItems, oItemsInBatch});
                DataSet dsOut = ProxyGenericSet(dsTemp,"Set");// Procedure spSetBatchEvents
            }
            catch(Exception eEx)
            {
                throw new Exception("SetBatchEvent: Couldn't get/update batch events information from the db:\n" + eEx.Message);
            }
        }

        public static void DBAddInvoiceByCode(int iViewAccessCode, int iGroupCode, int iBatchCode, int iItemCode)
        {
            if (iInvoiceDebugLevel < 2)
                return;
            DataSet dsPrms = new DataSet();
            DataTable dtPrms = dsPrms.Tables.Add("InvoiceTypeOf");
            dsPrms = ProxyGenericGet(dsPrms);
            dtPrms = dsPrms.Tables[0];
            dtPrms.TableName = "Invoice";
            dtPrms.Rows.Add(new object[] {});
            dtPrms.Rows[0]["ViewAccessCode"] = iViewAccessCode;
            dtPrms.Rows[0]["Price"] = -2; // same effect as NULL
            dtPrms.Rows[0]["GroupOfficeID"] = -1; // treat ID as codes

            if(iGroupCode==0)
                dtPrms.Rows[0]["GroupID"] = DBNull.Value;
            else
                dtPrms.Rows[0]["GroupID"] = iGroupCode;

            if(iBatchCode==0)
                dtPrms.Rows[0]["BatchID"] = DBNull.Value;
            else
                dtPrms.Rows[0]["BatchID"] = iBatchCode;

            if(iItemCode==0)
                dtPrms.Rows[0]["ItemCode"] = DBNull.Value;
            else
                dtPrms.Rows[0]["ItemCode"] = iItemCode;

            dsPrms = ProxyGenericSet(dsPrms, "Add");
        }

        public static void DBAddInvoice(int iViewAccessCode, int iBatchId, int iItemCode)
        {
            if (iInvoiceDebugLevel < 2)
                return;
            DataSet dsPrms = new DataSet();
            DataTable dtPrms = dsPrms.Tables.Add("InvoiceTypeOf");
            dsPrms = ProxyGenericGet(dsPrms);
            dtPrms = dsPrms.Tables[0];
            dtPrms.TableName = "Invoice";
            dtPrms.Rows.Add(new object[] {});
            dtPrms.Rows[0]["ViewAccessCode"] = iViewAccessCode;
            dtPrms.Rows[0]["Price"] = -2; // same effect as NULL
            dtPrms.Rows[0]["BatchID"] = iBatchId;
            dtPrms.Rows[0]["ItemCode"] = iItemCode;
            dsPrms = ProxyGenericSet(dsPrms, "Add");
        }

        public static void DBAddBatchInvoice(int iViewAccessCode, int iBatchId)
        {
            if (iInvoiceDebugLevel < 2)
                return;
            DataSet dsPrms = new DataSet();
            DataTable dtPrms = dsPrms.Tables.Add("InvoiceTypeOf");
            dsPrms = ProxyGenericGet(dsPrms);
            dtPrms = dsPrms.Tables[0];
            dtPrms.TableName = "Invoice";
            dtPrms.Rows.Add(new object[] {});
            dtPrms.Rows[0]["ViewAccessCode"] = iViewAccessCode;
            dtPrms.Rows[0]["Price"] = -2; // same effect as NULL
            dtPrms.Rows[0]["BatchID"] = iBatchId;
            dsPrms = ProxyGenericSet(dsPrms, "Add");
        }

        public static void DBAddGroupInvoice(int iViewAccessCode, int iGroupOfficeId, int iGroupId)
        {
            if (iInvoiceDebugLevel < 2)
                return;
            DataSet dsPrms = new DataSet();
            DataTable dtPrms = dsPrms.Tables.Add("InvoiceTypeOf");
            dsPrms = ProxyGenericGet(dsPrms);
            dtPrms = dsPrms.Tables[0];
            dtPrms.TableName = "Invoice";
            dtPrms.Rows.Add(new object[] {});
            dtPrms.Rows[0]["ViewAccessCode"] = iViewAccessCode;
            dtPrms.Rows[0]["Price"] = -2; // same effect as NULL
            dtPrms.Rows[0]["GroupOfficeID"] = iGroupOfficeId;
            dtPrms.Rows[0]["GroupID"] = iGroupId;
            dsPrms = ProxyGenericSet(dsPrms, "Add");
        }

        public static void DBAddGroupInvoice(int iViewAccessCode, decimal dPrice, int iGroupOfficeId, int iGroupId)
        {
            if (iInvoiceDebugLevel < 2)
                return;
            DataSet dsPrms = new DataSet();
            DataTable dtPrms = dsPrms.Tables.Add("InvoiceTypeOf");
            dsPrms = ProxyGenericGet(dsPrms);
            dtPrms = dsPrms.Tables[0];
            dtPrms.TableName = "Invoice";
            dtPrms.Rows.Add(new object[] {});
            dtPrms.Rows[0]["ViewAccessCode"] = iViewAccessCode;
            dtPrms.Rows[0]["Price"] = dPrice; // same effect as NULL
            dtPrms.Rows[0]["GroupOfficeID"] = iGroupOfficeId;
            dtPrms.Rows[0]["GroupID"] = iGroupId;
            dsPrms = ProxyGenericSet(dsPrms, "Add");
        }

#region Itemizn

        public static DataSet GetItemizn1_EntryBatch(string sBarCode)
        {
            DataSet dsData = new DataSet();
            GetItemizn1_EntryBatch(sBarCode, dsData);
            return dsData;			
        }

        public static Image ExtractImageFromString(string sImage, string sImageFileName)
        {
            byte[] buf = Convert.FromBase64String(sImage);
            int wmfI = sImageFileName.LastIndexOf(".wmf");
            int emfI = sImageFileName.LastIndexOf(".emf");
            if (wmfI > 0 && wmfI == sImageFileName.Length-4 || emfI > 0 && emfI == sImageFileName.Length-4)
            {
                return new Metafile(new MemoryStream(buf, 0, buf.Length));
            }
            else
            {
                return new Bitmap(new MemoryStream(buf, 0, buf.Length));
            }
        }

        private static void AddImageColumn(DataTable table, string sPath2ImageColumn, string sNewColumnName)
        {
            table.Columns.Add(sNewColumnName, typeof(byte[]));
            foreach(DataRow row in table.Rows)
            {
                if(row["Image_"+sPath2ImageColumn] != DBNull.Value)
                {
                    row[sNewColumnName] = ExtractImageFromString(row["Image_"+sPath2ImageColumn].ToString(), row[sPath2ImageColumn].ToString());
                }
                else
                {
                    row[sNewColumnName] = DBNull.Value;
                }
            }
        }

        public static DataTable GetItemizn1_ItemsLibrary()
        {
            DataSet dsIn = new DataSet();
            dsIn.Tables.Add("ItemTypeGroups");
            DataSet dsOut = ProxyGenericGet(dsIn);//Procedure spGetItemTypeGroups
            //dsOut Columns:
            ////////////////
            //"ItemTypeGroupID", "ItemTypeGroupParentID", "ItemTypeGroupHistoryID",
            //"ItemTypeGroupName", "Path2Icon", "Image_Path2Icon"
            DataTable table = dsOut.Tables["ItemTypeGroups"];
            table.Columns["ItemTypeGroupID"].ColumnName			= "Id";
            table.Columns["ItemTypeGroupParentID"].ColumnName	= "ParentId";
            table.Columns["ItemTypeGroupName"].ColumnName		= "Name";
            AddImageColumn(table, "Path2Icon", "Icon");

            return dsOut.Tables["ItemTypeGroups"];
        }
		
        public static DataTable GetItemizn1_ItemsSubtypesList(string ItemTypeId)
        {
            DataTable table;
            DataSet dsOut;
            string sStoredProcName = "ItemTypesByGroup";

			if (Regex.IsMatch(ItemTypeId, @"^\d+_\d+_\d*_\d*$"))
			{
				string[] param = ItemTypeId.Split(new char[] { '_' });
				sStoredProcName = "MRUItems";
				DataSet dsIn = new DataSet();
				dsIn.Tables.Add("MRUItemsTypeOf");
				DataSet dsType = ProxyGenericGet(dsIn);
				dsType.Tables["MRUItemsTypeOf"].TableName = "MRUItems";
				dsType.Tables["MRUItems"].Rows.Add(new object[] { });
				dsType.Tables["MRUItems"].Rows[0]["CustomerOfficeID"] = param[0];
				dsType.Tables["MRUItems"].Rows[0]["CustomerID"] = param[1];
				dsType.Tables["MRUItems"].Rows[0]["VendorOfficeID"] = param[2];
				dsType.Tables["MRUItems"].Rows[0]["VendorID"] = param[3];

				dsOut = ProxyGenericGet(dsType);
				table = dsOut.Tables[sStoredProcName];//Procedure dbo.spGetMRUItems
			}
			else

			{
                dsOut = ProxyGenericGetById(ItemTypeId, sStoredProcName);
                table = dsOut.Tables[sStoredProcName];
            }
            //dsOut Columns:
            ////////////////
            //ItemTypeID, ItemTypeGroupID, ItemTypeHistoryID,
            //(cast(h.DefaultCPOfficeID as varchar(5))+'_'+cast(h.DefaultCPID as varchar(20))) as DefaultCPOfficeID_DefaultCPID,
            //DefaultCPID, DefaultCPOfficeID, ItemTypeName, Path2Icon, Path2Picture, LastAccessDate4MRU, 
            //CustomerProgramName

            table.Columns["ItemTypeID"].ColumnName						= "Id";
            table.Columns["ItemTypeName"].ColumnName					= "Name";
            table.Columns["DefaultCPName"].ColumnName					= "CustomerProgram";
            table.Columns["DefaultCPOfficeID_DefaultCPID"].ColumnName	= "CustomerProgramId";
            //table.Columns["ItemTypeGroupID"].ColumnName					= "TypeId";
            table.Columns.Add("TypeId", typeof(string));
            foreach(DataRow row in table.Rows)
            {
                if(row["CustomerProgram"] == DBNull.Value) row["CustomerProgram"] = "";
                row["TypeId"] = ItemTypeId;
            }

            AddImageColumn(table, "Path2Icon", "Icon");
            AddImageColumn(table, "Path2Picture", "Picture");

            return table;
        }
		
        public static void GetItemizn1_EntryBatch(string sBarCode, DataSet dsData)
        {
            int GroupId = Convert.ToInt32(sBarCode);
            DataTable table;
            DataSet dsIn;
            DataSet dsOut;

            dsIn = new DataSet();
            dsIn.Tables.Add("GroupByCode3TypeEx");
            dsOut = ProxyGenericGet(dsIn);//Procedure dbo.spGetGroupByCode3TypeEx
            dsOut.Tables["GroupByCode3TypeEx"].Rows.Add(new object[]{});
            dsOut.Tables["GroupByCode3TypeEx"].Rows[0]["GroupCode"] = GroupId;
            dsOut.Tables["GroupByCode3TypeEx"].TableName = "GroupByCode3";

            dsOut = ProxyGenericGet(dsOut);//Procedure dbo.spGetGroupByCode3
            table = dsOut.Tables["GroupByCode3"];
            //dsOut Columns:
            ////////////////
            //GroupOfficeID_GroupID, CustomerOfficeID_CustomerID, VendorOfficeID_VendorID,
            //PersonCustomerOfficeID_PersonCustomerID_PersonID, GroupOfficeID, GroupID, CustomerOfficeID, 
            //CustomerID, VendorOfficeID, VendorID, GroupCode, OrderCode, GroupHistoryID, StartDate, 
            //ServiceTypeID, CarrierID, InspectedQuantity, NotInspectedQuantity, InspectedTotalWeight, 
            //InspectedWeightUnitID, MeasureUnitName, MeasureUnitCode, NotInspectedTotalWeight, 
            //NotInspectedWeightUnitID, MeasureUnitName, MeasureUnitCode, NotInspectedTotalWeightTitle, 
            //Memo, SpecialInstruction, CarrierTrackingNumber, StateID, StateTargetID, ShipmentCharge, PersonID, 
            //PersonCustomerOfficeID, PersonCustomerID, StateCode, StateName, IconIndex,
            //ItemsQuantity, ItemsWeight (ct.), CustomerCode, GroupName, CustomerName, VendorName
			
            if (dsData.Tables["EntryBatch"] != null) dsData.Tables.Remove("EntryBatch");
            table.TableName = "EntryBatch";
            DataTable dtEntryBatch = table.Copy();
            dsData.Tables.Add(dtEntryBatch);
            dtEntryBatch.Columns["GroupOfficeID_GroupID"].ColumnName	= "EntryBatchId";
            dtEntryBatch.Columns["CustomerName"].ColumnName				= "CustomerName";
            dtEntryBatch.Columns["VendorName"].ColumnName				= "VendorName";
            dtEntryBatch.Columns["InspectedQuantity"].ColumnName		= "IQInspected";
            dtEntryBatch.Columns["NotInspectedQuantity"].ColumnName		= "IQNotInspected";
            dtEntryBatch.Columns["InspectedTotalWeight"].ColumnName		= "TWInspected";
            dtEntryBatch.Columns["InspectedWeightUnitID"].ColumnName	= "TWInspectedMeasureUnitId";
            dtEntryBatch.Columns["NotInspectedTotalWeight"].ColumnName	= "TWNotInspected";
            dtEntryBatch.Columns["NotInspectedWeightUnitID"].ColumnName = "TWNotInspectedMeasureUnitId";
			
            if(dtEntryBatch.Columns["ItemsQuantity"]!=null)
                dtEntryBatch.Columns["ItemsQuantity"].ColumnName = "EnteredIQ";
            else
                dtEntryBatch.Columns["ItemQuantity"].ColumnName = "EnteredIQ";
            dtEntryBatch.Columns["ItemsWeight"].ColumnName		= "EnteredIW";
            if(dtEntryBatch.Rows.Count > 0)
                dtEntryBatch.Rows.Add(dtEntryBatch.Rows[0].ItemArray);
        }

	
        public static void GetItemizn_MeasureUnits(DataSet dsData)
        {
            // Measure Unit
            if(dsData.Tables["MeasureUnits"]==null)
            {
                DataSet dsIn = new DataSet();
                dsIn.Tables.Add("MeasureUnits");
                DataSet dsOut = ProxyGenericGet(dsIn);
                //MeasureUnitID, MeasureUnitName, MeasureUnitCode
                dsData.Tables.Add(dsOut.Tables["MeasureUnits"].Copy());
                //dsData.Tables["MeasureUnits"].DefaultView.RowFilter = "MeasureUnitCode = 1 OR MeasureUnitCode = 2";
            }
        }

        public static ArrayList Itemizn2_BatchAdd(DataView dvItems, string sEntryBatchId, string sItemTypeId, string sCustomerProgramId, string sMemoNumber, string sMemoID)
        {
            DataSet dsIn = new DataSet();
            dsIn.Tables.Add("BatchTypeOf");

            DataSet dsBatchType = ProxyGenericGet(dsIn);//Procedure dbo.spGetBatchTypeOf
            DataTable table = dsBatchType.Tables["BatchTypeOf"];

            table.TableName = "Batch";
            table.Columns.Add("MemoNumberID");
            //parameters: GroupOfficeID_GroupID, CPOfficeID_CPID_CustomerProgramHistoryID, ItemTypeID, StoredItemsQuantity
            table.Rows.Add(new object[] { });
            table.Rows[0]["GroupOfficeID_GroupID"] = sEntryBatchId;
            table.Rows[0]["CPOfficeID_CPID"] = sCustomerProgramId;
            table.Rows[0]["ItemTypeID"] = sItemTypeId;
            table.Rows[0]["StoredItemsQuantity"] = dvItems.Count.ToString();
            table.Rows[0]["MemoNumber"] = (sMemoNumber.Trim() == "" ? null : sMemoNumber);
            table.Rows[0]["MemoNumberID"] = (sMemoID.Trim() == "" ? null : sMemoID);

            DataSet dsBatch = ProxyGenericSet(dsBatchType, "Add");//Procedure dbo.spAddBatch lera

            string sBatchId = dsBatch.Tables[0].Rows[0][0].ToString();
			ArrayList outList = new ArrayList();
            outList.Add(sBatchId);

            DataSet dsIn2 = new DataSet();
            dsIn2.Tables.Add("ItemTypeOf");

            DataSet dsItemType = ProxyGenericGet(dsIn2); //Procedure dbo.spGetItemTypeOf

            table = dsItemType.Tables["ItemTypeOf"];
            table.TableName = "Item";
            table.Columns.Add("ParNo");

            foreach (DataRowView rowFrom in dvItems)
            {
                DataRow rowTo = table.Rows.Add(new object[] { });
                //rowTo["ItemCode"]					= rowFrom["runningN"];
                rowTo["BatchID"] = sBatchId;

                if (rowFrom["lotN"].ToString() != "") rowTo["LotNumber"] = rowFrom["lotN"];
                if (rowFrom["ParNo"].ToString() != "") rowTo["ParNo"] = rowFrom["ParNo"];

                if (rowFrom["weight"].ToString() != "") rowTo["Weight"] = rowFrom["weight"];
                rowTo["WeightUnitID"] = rowFrom["weightUnitId"];

                if (rowFrom["customerWeight"].ToString() != "") rowTo["CustomerItemWeight"] = rowFrom["customerWeight"];
                rowTo["CustomerItemWeightUnitID"] = rowFrom["customerWeightUnitId"];

                string prev = rowFrom["prevN"].ToString();
                int point1 = prev.IndexOf(".");
                int point2 = prev.IndexOf(".", point1 + 1);
                int point3 = prev.IndexOf(".", point2 + 1);
                string str = "";
                if (point3 > -1)
                {
                    str = prev.Substring(0, point1);
                    rowTo["PrevOrderCode"] = str;
                    str = prev.Substring(point1 + 1, point2 - point1 - 1);
                    rowTo["PrevGroupCode"] = str;
                    str = prev.Substring(point2 + 1, point3 - point2 - 1);
                    rowTo["PrevBatchCode"] = str;
                    str = prev.Substring(point3 + 1);
                    rowTo["PrevItemCode"] = str;
                }

                //parameters: 
                //vwItem.ItemCode, vwItem.BatchID,  vwItem.LotNumber, vwItem.Weight, 
                //vwItem.WeightUnitID, vwItem.CustomerItemWeight, vwItem.CustomerItemWeightUnitID, 
                //vwItem.PrevItemCode, vwItem.PrevBatchCode, vwItem.PrevGroupCode, vwItem.PrevOrderCode
            }
            //For Test
            //table.TableName = "Item_CID";
            // End of test
            DataSet itemsds = ProxyGenericSet(dsItemType, "Add");//Procedure dbo.spAddItem  // 

            foreach (DataRow row in itemsds.Tables[0].Rows)
                outList.Add(row[0]);

            //Prefilling measures with default values from CP
            //By _3ter on 2006.05.18
            DataSet dsPrefill = new DataSet();
            DataTable dtPrefill = new DataTable("PrefilledMeasuresFromCP");
            dtPrefill.Columns.Add("BatchID");
            dtPrefill.Rows.Add(new Object[] { outList[0] });
            dsPrefill.Tables.Add(dtPrefill);

			ProxyGenericSet(dsPrefill, "Set");//Procedure dbo.spSetPrefilledMeasuresFromCP// ler

            /*
             * Commented by _3ter on 12.21.05 on Zeltser's request. Now CPGO runs only after End Session
             * 
            try
            {
                // Call GoCP
                DataSet dsGoCP = new DataSet();
                dsGoCP.Tables.Add("GoCP");
                dsGoCP.Tables[0].Columns.Add("BatchID", typeof(int));
                //parameters: BatchID
                dsGoCP.Tables[0].Rows.Add(new object[] {});
                dsGoCP.Tables[0].Rows[0][0]	= Convert.ToInt32(sBatchId);
                ProxyGenericSet(dsGoCP, "");
            }
            catch(Exception exc)
            {
                MessageBox.Show("Warning: Can't call GoCP stored procedure:\r\n\r\n"+exc.Message);
            }
            */
            try
            {
                if (iInvoiceDebugLevel >= 1)
                {
                    int tmpCode = 0;
                    int iViewAccessCode = 2; // ViewAccess = "Itemizing"
                    int GroupOfficeId = Convert.ToInt32(sEntryBatchId.Split(new char[] { '_' })[0]);
                    int GroupId = Convert.ToInt32(sEntryBatchId.Split(new char[] { '_' })[1]);
                    int BatchId = Convert.ToInt32(outList[0]);
                    //int ItemCode;
                    //Commented below by Sasha 04/16/09
                    //					for(int i=1; i<outList.Count; i++)
                    //					{
                    //						ItemCode = Convert.ToInt32( outList[i].ToString().Split(new char[] {'_'})[1] );
                    //
                    //						DBAddInvoice(iViewAccessCode, BatchId, ItemCode);
                    //					}
                }

            }
            catch (Exception exc)
            {
                if (iInvoiceDebugLevel >= 3) MessageBox.Show("Warning: Can't add invoice for Itemizn:\r\n" + exc.Message);
            }
            return outList;
        }
        //Method below adds new batch and new items printing labels between
        public static ArrayList Itemizn2_BatchAddNew(DataView dvItems, string sEntryBatchId, string sItemTypeId, string sCustomerProgramId,string sMemoNumber, string sMemoID)
        {
            DataSet dsIn = new DataSet();
            dsIn.Tables.Add("BatchTypeOf");
						
            DataSet dsBatchType = ProxyGenericGet(dsIn);//Procedure dbo.spGetBatchTypeOf
            DataTable table = dsBatchType.Tables["BatchTypeOf"];

            table.TableName = "Batch";
            table.Columns.Add("MemoNumberID");
            //parameters: GroupOfficeID_GroupID, CPOfficeID_CPID_CustomerProgramHistoryID, ItemTypeID, StoredItemsQuantity
            table.Rows.Add(new object[] {});
            table.Rows[0]["GroupOfficeID_GroupID"]	= sEntryBatchId;
            table.Rows[0]["CPOfficeID_CPID"]		= sCustomerProgramId;
            table.Rows[0]["ItemTypeID"]				= sItemTypeId;
            table.Rows[0]["StoredItemsQuantity"]	= dvItems.Count.ToString();
            table.Rows[0]["MemoNumber"]             = (sMemoNumber.Trim() == "" ? null : sMemoNumber);
            table.Rows[0]["MemoNumberID"]           = (sMemoID.Trim() == "" ? null : sMemoID);

            DataSet dsBatch = ProxyGenericSet(dsBatchType, "Add");//Procedure dbo.spAddBatch lera

            string sBatchId = dsBatch.Tables[0].Rows[0][0].ToString();
			ArrayList outList = new ArrayList();
            outList.Add(sBatchId);
            int itemNumber = 1;
            foreach (var row in dvItems)
            {
                outList.Add(sBatchId + @"_" + itemNumber.ToString());
                itemNumber++;
            }
            return outList;
            /*
            DataSet dsIn2 = new DataSet();
            dsIn2.Tables.Add("ItemTypeOf");

            DataSet dsItemType = ProxyGenericGet(dsIn2); //Procedure dbo.spGetItemTypeOf

            table = dsItemType.Tables["ItemTypeOf"];
            table.TableName = "Item";
            table.Columns.Add("ParNo");

            foreach(DataRowView rowFrom in dvItems)
            {
                DataRow rowTo = table.Rows.Add(new object[] {});
                //rowTo["ItemCode"]					= rowFrom["runningN"];
                rowTo["BatchID"]					= sBatchId;
				
                if(rowFrom["lotN"].ToString()!="") rowTo["LotNumber"]	= rowFrom["lotN"];
                if(rowFrom["ParNo"].ToString() !="") rowTo["ParNo"]		= rowFrom["ParNo"];
				
                if(rowFrom["weight"].ToString()!="") rowTo["Weight"] = rowFrom["weight"];
                rowTo["WeightUnitID"] = rowFrom["weightUnitId"];
				
                if(rowFrom["customerWeight"].ToString()!="") rowTo["CustomerItemWeight"] = rowFrom["customerWeight"];
                rowTo["CustomerItemWeightUnitID"]	= rowFrom["customerWeightUnitId"];

                string prev = rowFrom["prevN"].ToString();
                int point1 = prev.IndexOf(".");
                int point2 = prev.IndexOf(".", point1+1);
                int point3 = prev.IndexOf(".", point2+1);
                string str = "";
                if(point3 > -1) 
                {
                    str = prev.Substring(0, point1);
                    rowTo["PrevOrderCode"] = str;
                    str = prev.Substring(point1+1, point2-point1-1);
                    rowTo["PrevGroupCode"] = str;
                    str = prev.Substring(point2+1, point3-point2-1);
                    rowTo["PrevBatchCode"] = str;
                    str = prev.Substring(point3+1);
                    rowTo["PrevItemCode"] = str;
                }
			
                //parameters: 
                //vwItem.ItemCode, vwItem.BatchID,  vwItem.LotNumber, vwItem.Weight, 
                //vwItem.WeightUnitID, vwItem.CustomerItemWeight, vwItem.CustomerItemWeightUnitID, 
                //vwItem.PrevItemCode, vwItem.PrevBatchCode, vwItem.PrevGroupCode, vwItem.PrevOrderCode
            }
            //For Test
            //table.TableName = "Item_CID";
            // End of test
            DataSet itemsds = ProxyGenericSet(dsItemType, "Add");//Procedure dbo.spAddItem  // lera  call  sp to update dsItem
            
            foreach(DataRow row in itemsds.Tables[0].Rows)
                outList.Add(row[0]);

            //Prefilling measures with default values from CP
            //By _3ter on 2006.05.18
            DataSet dsPrefill = new DataSet();
            DataTable dtPrefill = new DataTable("PrefilledMeasuresFromCP");
            dtPrefill.Columns.Add("BatchID");
            dtPrefill.Rows.Add(new Object[] {outList[0]});
            dsPrefill.Tables.Add(dtPrefill);

            ProxyGenericSet(dsPrefill, "Set");//Procedure dbo.spSetPrefilledMeasuresFromCP// ler
            */
            /*
             * Commented by _3ter on 12.21.05 on Zeltser's request. Now CPGO runs only after End Session
             * 
            try
            {
                // Call GoCP
                DataSet dsGoCP = new DataSet();
                dsGoCP.Tables.Add("GoCP");
                dsGoCP.Tables[0].Columns.Add("BatchID", typeof(int));
                //parameters: BatchID
                dsGoCP.Tables[0].Rows.Add(new object[] {});
                dsGoCP.Tables[0].Rows[0][0]	= Convert.ToInt32(sBatchId);
                ProxyGenericSet(dsGoCP, "");
            }
            catch(Exception exc)
            {
                MessageBox.Show("Warning: Can't call GoCP stored procedure:\r\n\r\n"+exc.Message);
            }
            */
            /*
            try
            {
                if (iInvoiceDebugLevel >= 1)
                {
                    int iViewAccessCode = 2; // ViewAccess = "Itemizing"
                    int GroupOfficeId = Convert.ToInt32(sEntryBatchId.Split(new char[] {'_'})[0]);
                    int GroupId = Convert.ToInt32(sEntryBatchId.Split(new char[] {'_'})[1]);
                    int BatchId = Convert.ToInt32(outList[0]);
                    //int ItemCode;
                    //Commented below by Sasha 04/16/09
                    //					for(int i=1; i<outList.Count; i++)
                    //					{
                    //						ItemCode = Convert.ToInt32( outList[i].ToString().Split(new char[] {'_'})[1] );
                    //
                    //						DBAddInvoice(iViewAccessCode, BatchId, ItemCode);
                    //					}
                }
				
            }				
            catch(Exception exc)
            {
                if (iInvoiceDebugLevel >= 3) MessageBox.Show("Warning: Can't add invoice for Itemizn:\r\n"+exc.Message);
            }
            return outList;
            */
        }

        public static ArrayList Itemizn2_ItemsAdd(ArrayList outList, DataView dvItems, string sEntryBatchId, string sItemTypeId, string sCustomerProgramId, string sMemoNumber, string sMemoID)
        {
            
            DataSet dsIn = new DataSet();
            dsIn.Tables.Add("BatchTypeOf");

            DataSet dsBatchType = ProxyGenericGet(dsIn);//Procedure dbo.spGetBatchTypeOf
            DataTable table = dsBatchType.Tables["BatchTypeOf"];

            table.TableName = "Batch";
            table.Columns.Add("MemoNumberID");
            //parameters: GroupOfficeID_GroupID, CPOfficeID_CPID_CustomerProgramHistoryID, ItemTypeID, StoredItemsQuantity
            table.Rows.Add(new object[] { });
            table.Rows[0]["GroupOfficeID_GroupID"] = sEntryBatchId;
            table.Rows[0]["CPOfficeID_CPID"] = sCustomerProgramId;
            table.Rows[0]["ItemTypeID"] = sItemTypeId;
            table.Rows[0]["StoredItemsQuantity"] = dvItems.Count.ToString();
            table.Rows[0]["MemoNumber"] = (sMemoNumber.Trim() == "" ? null : sMemoNumber);
            table.Rows[0]["MemoNumberID"] = (sMemoID.Trim() == "" ? null : sMemoID);

            //DataSet dsBatch = ProxyGenericSet(dsBatchType, "Add");//Procedure dbo.spAddBatch lera
            
            string sBatchId = outList[0].ToString(); //dsBatch.Tables[0].Rows[0][0].ToString();
            //System.Collections.ArrayList outList = new System.Collections.ArrayList();
            //outList.Add(sBatchId);
            //int itemNumber = 1;
            //foreach (var row in dvItems)
            //{
            //    outList.Add(sBatchId + @"_" + itemNumber.ToString());
            //}
            //return outList;
            DataSet dsIn2 = new DataSet();
            dsIn2.Tables.Add("ItemTypeOf");

            DataSet dsItemType = ProxyGenericGet(dsIn2); //Procedure dbo.spGetItemTypeOf

            table = dsItemType.Tables["ItemTypeOf"];
            table.TableName = "Item";
            table.Columns.Add("ParNo");

            foreach(DataRowView rowFrom in dvItems)
            {
                DataRow rowTo = table.Rows.Add(new object[] {});
                //rowTo["ItemCode"]					= rowFrom["runningN"];
                rowTo["BatchID"]					= sBatchId;
				
                if(rowFrom["lotN"].ToString()!="") rowTo["LotNumber"]	= rowFrom["lotN"];
                if(rowFrom["ParNo"].ToString() !="") rowTo["ParNo"]		= rowFrom["ParNo"];
				
                if(rowFrom["weight"].ToString()!="") rowTo["Weight"] = rowFrom["weight"];
                rowTo["WeightUnitID"] = rowFrom["weightUnitId"];
				
                if(rowFrom["customerWeight"].ToString()!="") rowTo["CustomerItemWeight"] = rowFrom["customerWeight"];
                rowTo["CustomerItemWeightUnitID"]	= rowFrom["customerWeightUnitId"];

                string prev = rowFrom["prevN"].ToString();
                int point1 = prev.IndexOf(".");
                int point2 = prev.IndexOf(".", point1+1);
                int point3 = prev.IndexOf(".", point2+1);
                string str = "";
                if(point3 > -1) 
                {
                    str = prev.Substring(0, point1);
                    rowTo["PrevOrderCode"] = str;
                    str = prev.Substring(point1+1, point2-point1-1);
                    rowTo["PrevGroupCode"] = str;
                    str = prev.Substring(point2+1, point3-point2-1);
                    rowTo["PrevBatchCode"] = str;
                    str = prev.Substring(point3+1);
                    rowTo["PrevItemCode"] = str;
                }
			
                //parameters: 
                //vwItem.ItemCode, vwItem.BatchID,  vwItem.LotNumber, vwItem.Weight, 
                //vwItem.WeightUnitID, vwItem.CustomerItemWeight, vwItem.CustomerItemWeightUnitID, 
                //vwItem.PrevItemCode, vwItem.PrevBatchCode, vwItem.PrevGroupCode, vwItem.PrevOrderCode
            }
            //For Test
            //table.TableName = "Item_CID";
            // End of test
            DataSet itemsds = ProxyGenericSet(dsItemType, "Add");//Procedure dbo.spAddItem  // lera  call  sp to update dsItem
            
            foreach(DataRow row in itemsds.Tables[0].Rows)
                outList.Add(row[0]);

            //Prefilling measures with default values from CP
            //By _3ter on 2006.05.18
            DataSet dsPrefill = new DataSet();
            DataTable dtPrefill = new DataTable("PrefilledMeasuresFromCP");
            dtPrefill.Columns.Add("BatchID");
            dtPrefill.Rows.Add(new Object[] {outList[0]});
            dsPrefill.Tables.Add(dtPrefill);
			ProxyGenericSet(dsPrefill, "Set");//Procedure dbo.spSetPrefilledMeasuresFromCP// ler
            return outList;
            /*
             * Commented by _3ter on 12.21.05 on Zeltser's request. Now CPGO runs only after End Session
             * 
            try
            {
                // Call GoCP
                DataSet dsGoCP = new DataSet();
                dsGoCP.Tables.Add("GoCP");
                dsGoCP.Tables[0].Columns.Add("BatchID", typeof(int));
                //parameters: BatchID
                dsGoCP.Tables[0].Rows.Add(new object[] {});
                dsGoCP.Tables[0].Rows[0][0]	= Convert.ToInt32(sBatchId);
                ProxyGenericSet(dsGoCP, "");
            }
            catch(Exception exc)
            {
                MessageBox.Show("Warning: Can't call GoCP stored procedure:\r\n\r\n"+exc.Message);
            }
            */
            /*
            try
            {
                if (iInvoiceDebugLevel >= 1)
                {
                    int iViewAccessCode = 2; // ViewAccess = "Itemizing"
                    int GroupOfficeId = Convert.ToInt32(sEntryBatchId.Split(new char[] {'_'})[0]);
                    int GroupId = Convert.ToInt32(sEntryBatchId.Split(new char[] {'_'})[1]);
                    int BatchId = Convert.ToInt32(outList[0]);
                    //int ItemCode;
                    //Commented below by Sasha 04/16/09
                    //					for(int i=1; i<outList.Count; i++)
                    //					{
                    //						ItemCode = Convert.ToInt32( outList[i].ToString().Split(new char[] {'_'})[1] );
                    //
                    //						DBAddInvoice(iViewAccessCode, BatchId, ItemCode);
                    //					}
                }
				
            }				
            catch(Exception exc)
            {
                if (iInvoiceDebugLevel >= 3) MessageBox.Show("Warning: Can't add invoice for Itemizn:\r\n"+exc.Message);
            }
            return outList;
            */
        }
        public static bool GetItemizn_CustomerProgramExists(string sCustomerProgramName)
        {
            DataSet dsOut = ProxyGenericGetById(sCustomerProgramName, "CustomerProgramByName");
            return dsOut.Tables[0].Rows.Count>0;
        }

        public static DataTable GetItemizn_ItemTypeIdByCustomerProgram(string sCustomerProgramName)
        {
            DataSet dsOut = ProxyGenericGetById(sCustomerProgramName, "CustomerProgramByName2");
            return dsOut.Tables[0];
        }

        private static object GetItemizn_MakeDBNull(string val)
        {
            if(val == null || val.Length == 0)
                return DBNull.Value;
            return val;
        }

        //public static DataTable GetItemizn_ItemTypeIdByCustomerProgramAndCustomer(string sCustomerProgramName, string sVendorOfficeID, string sVendorID, string sCustomerOfficeID, string sCustomerID)
        //{
        //    DataSet dsIn = new DataSet();
        //    dsIn.Tables.Add("CustomerProgramByNameAndCustomerTypeOf");
        //    DataSet dsCPType = ProxyGenericGet(dsIn);

        //    DataTable table = dsCPType.Tables["CustomerProgramByNameAndCustomerTypeOf"];
        //    table.TableName = "CustomerProgramByNameAndCustomer";
        //    //parameters: 	VendorOfficeID, VendorID, CustomerOfficeID, CustomerID, CustomerProgramName
        //    table.Rows.Add(new object[] {});
        //    table.Rows[0]["CustomerOfficeID"]	= GetItemizn_MakeDBNull(sCustomerOfficeID.Trim());
        //    table.Rows[0]["CustomerID"]			= GetItemizn_MakeDBNull(sCustomerID.Trim());
        //    table.Rows[0]["VendorOfficeID"]		= GetItemizn_MakeDBNull(sVendorOfficeID.Trim());
        //    table.Rows[0]["VendorID"]			= GetItemizn_MakeDBNull(sVendorID.Trim());
        //    table.Rows[0]["CustomerProgramName"] = sCustomerProgramName;
        //    DataSet dsCP = ProxyGenericGet(dsCPType);
        //    AddImageColumn(dsCP.Tables[0], "Path2Picture", "Picture");
        //    return dsCP.Tables[0];
        //}

        public static string GetItemizn_MRUCustomerProgram(DataTable dtEntryBatch, string sItemType)
        {
            DataSet dsIn = new DataSet();
            dsIn.Tables.Add("MRUCustomerProgramTypeOf");
            DataSet dsCPType = ProxyGenericGet(dsIn);

            DataTable table = dsCPType.Tables["MRUCustomerProgramTypeOf"];
            table.TableName = "MRUCustomerProgram";
            //parameters: 	VendorOfficeID, VendorID, CustomerOfficeID, CustomerID, ItemTypeID
            table.Rows.Add(new object[] {});
            table.Rows[0]["CustomerOfficeID"]	= dtEntryBatch.Rows[0]["CustomerOfficeID"];
            table.Rows[0]["CustomerID"]			= dtEntryBatch.Rows[0]["CustomerID"];
            table.Rows[0]["VendorOfficeID"]		= dtEntryBatch.Rows[0]["VendorOfficeID"];
            table.Rows[0]["VendorID"]			= dtEntryBatch.Rows[0]["VendorID"];
            table.Rows[0]["ItemTypeID"]			= sItemType;
            DataSet dsCP = ProxyGenericGet(dsCPType);
            if(dsCP.Tables[0].Rows.Count > 0)
                return dsCP.Tables[0].Rows[0]["CustomerProgramName"].ToString();
            else
                return null;
        }

        public static void Itemizn1_EntryBatchUpdate(DataTable dtEntryBatch)
        {
            DataSet dsIn = new DataSet();
            dsIn.Tables.Add("ItemizingUpdateGroupTypeOf");
            DataSet dsBatchType = ProxyGenericGet(dsIn); //Procedure spGetItemizingUpdateGroupTypeOf

            DataTable table = dsBatchType.Tables[0];

            table.TableName = "ItemizingUpdateGroup";
            //parameters:
            //GroupOfficeID, GroupID,
            //VendorOfficeID, VendorID,
            //InspectedQuantity, InspectedTotalWeight, InspectedWeightUnitID
            table.Rows.Add(new object[] {});
            table.Rows[0]["GroupOfficeID"]			= dtEntryBatch.Rows[0]["GroupOfficeID"];
            table.Rows[0]["GroupID"]				= dtEntryBatch.Rows[0]["GroupID"];
            table.Rows[0]["VendorOfficeID"]			= dtEntryBatch.Rows[0]["VendorOfficeID"];
            table.Rows[0]["VendorID"]				= dtEntryBatch.Rows[0]["VendorID"];
            table.Rows[0]["InspectedQuantity"]		= dtEntryBatch.Rows[0]["IQInspected"];
            table.Rows[0]["InspectedTotalWeight"]	= dtEntryBatch.Rows[0]["TWInspected"];
            table.Rows[0]["InspectedWeightUnitID"]	= dtEntryBatch.Rows[0]["TWInspectedMeasureUnitId"];
            DataSet dsBatch = ProxyGenericSet(dsBatchType, ""); //Procedure spItemizingUpdateGroup
        }

        public static void Itemizn2_EntryBatchComplete(string sBarCode)
        {
        }

        public static DataSet GetGroupMemoNumbers(string sGroupID)
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add("GroupMemoNumber");
            dsData.Tables[0].Columns.Add("GroupID");
            dsData.Tables[0].Rows.Add(dsData.Tables[0].NewRow());
            dsData.Tables[0].Rows[0]["GroupID"] = sGroupID;
            dsData = ProxyGenericGet(dsData);
            return dsData;			
        }
		
        public static DataSet CopyAllPartValuesFromItemToItem(string ItemCodeFrom, string BatchCodeFrom,
            string OrderCodeFrom,string ItemCodeTo, string BatchCodeTo, string OrderCodeTo)

        {
            DataSet dsCopyItem=new DataSet();
            dsCopyItem.Tables.Add("CopyAllPartValuesFromItemToItem");
            DataTable dtCopyItem=dsCopyItem.Tables["CopyAllPartValuesFromItemToItem"];
            dtCopyItem.Columns.Add("ItemCodeFrom");
            dtCopyItem.Columns.Add("BatchCodeFrom");
            dtCopyItem.Columns.Add("OrderCodeFrom");
            dtCopyItem.Columns.Add("ItemCodeTo");
            dtCopyItem.Columns.Add("BatchCodeTo");
            dtCopyItem.Columns.Add("OrderCodeTo");
            dtCopyItem.Rows.Add(new object[]{});
            dtCopyItem.Rows[0]["ItemCodeFrom"]=ItemCodeFrom;
            dtCopyItem.Rows[0]["BatchCodeFrom"]=BatchCodeFrom;
            dtCopyItem.Rows[0]["OrderCodeFrom"]=OrderCodeFrom;
            dtCopyItem.Rows[0]["ItemCodeTo"]=ItemCodeTo;
            dtCopyItem.Rows[0]["BatchCodeTo"]=BatchCodeTo;
            dtCopyItem.Rows[0]["OrderCodeTo"]=OrderCodeTo;
						
            DataSet dsItemCopyTo = ProxyGenericSet(dsCopyItem, "");
            return dsItemCopyTo;			
        }
		
        public static string CreateNewBatch(string GroupOfficeID_GroupID, 
                                            string CPOfficeID_CPID, 
                                            string ItemTypeID, 
                                            string StoredItemsQuantity, 
                                            string MemoNumber, 
                                            string MemoNumberID)
        {
            string GroupOfficeID = GroupOfficeID_GroupID.Split(new char[] {'_'})[0];
            string CPID = CPOfficeID_CPID.Split(new char[] {'_'})[1];
            CPOfficeID_CPID = GroupOfficeID + "_" + CPID;
            DataSet dsIn = new DataSet();
            dsIn.Tables.Add("BatchTypeOf");
						
            DataSet dsBatchType = Service.ProxyGenericGet(dsIn); //Procedure dbo.spGetBatchTypeOf
            DataTable table = dsBatchType.Tables["BatchTypeOf"];

            table.TableName = "Batch";
            table.Columns.Add("MemoNumberID");
            //parameters: GroupOfficeID_GroupID, CPOfficeID_CPID_CustomerProgramHistoryID, ItemTypeID, StoredItemsQuantity
            table.Rows.Add(new object[] {});
            table.Rows[0]["GroupOfficeID_GroupID"]	= GroupOfficeID_GroupID;
            table.Rows[0]["CPOfficeID_CPID"]		= CPOfficeID_CPID;
            table.Rows[0]["ItemTypeID"]				= ItemTypeID;
            table.Rows[0]["StoredItemsQuantity"]	= StoredItemsQuantity;
            table.Rows[0]["MemoNumber"]             = MemoNumber;
            table.Rows[0]["MemoNumberID"]           = MemoNumberID;
						
            DataSet dsBatch = Service.ProxyGenericSet(dsBatchType, "Add");
            string sBatchId = dsBatch.Tables[0].Rows[0][0].ToString();//new batch
            return sBatchId;
        }
		
        public static DataSet AddItemToBatch(string BatchID, string PrevNumber)
        {
            DataSet dsIn2 = new DataSet();
            dsIn2.Tables.Add("ItemTypeOf");
            DataSet dsItemType = Service.ProxyGenericGet(dsIn2);//Procedure dbo.spGetItemTypeOf
            DataTable table = new DataTable();
            table = dsItemType.Tables["ItemTypeOf"];
            table.TableName = "Item";

            DataRow rowTo=null;
            rowTo = table.Rows.Add(new object[] {});
            rowTo["BatchID"] = BatchID;
            string prev=PrevNumber;
            int point1 = prev.IndexOf(".");
            int point2 = prev.IndexOf(".", point1+1);
            int point3 = prev.IndexOf(".", point2+1);
            string str = "";
            if(point3 > -1) 
            {
                str = prev.Substring(0, point1);
                rowTo["PrevOrderCode"] = str;
                str = prev.Substring(point1+1, point2-point1-1);
                rowTo["PrevGroupCode"] = str;
                str = prev.Substring(point2+1, point3-point2-1);
                rowTo["PrevBatchCode"] = str;
                str = prev.Substring(point3+1);
                rowTo["PrevItemCode"] = str;
            }
			//For Test
			//table.TableName = "Item_CID";
			// End of test
            DataSet itemsds = Service.ProxyGenericSet(dsItemType, "Add");//Procedure "dbo.spAddItem"
			return itemsds;
        }
        public static DataRow NewCustomerProgramInstanceByBatchCode(string sGroupCode, string sBatchCode,string sItemCode)
        {
            // Get from db Data for Batch
            DataSet dsIn = new DataSet();
            dsIn.Tables.Add("CustomerProgramInstanceByBatchCodeTypeOf");
            dsIn = gemoDream.Service.ProxyGenericGet(dsIn); //Procedure dbo.spGetCustomerProgramInstanceByBatchCodeTypeOf
            dsIn.Tables[0].TableName = "NewCustomerProgramInstanceByBatchCode";
            dsIn.Tables[0].Columns.Add("ItemCode");
            dsIn.Tables[0].Rows.Add(dsIn.Tables[0].NewRow());
            dsIn.Tables[0].Rows[0]["GroupCode"] = sGroupCode;
            dsIn.Tables[0].Rows[0]["BatchCode"] = sBatchCode;
            dsIn.Tables[0].Rows[0]["ItemCode"] = sItemCode;
            DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn); //Procedure dbo.spGetNewCustomerProgramInstanceByBatchCode
            if (dsOut.Tables.Count > 0 && dsOut.Tables[0].Rows.Count > 0)
                return dsOut.Tables[0].Rows[0];
            return null;
        }
        public static DataRow CustomerProgramInstanceByBatchCode(string sGroupCode, string sBatchCode)
        {
            // Get from db Data for Batch
            DataSet dsIn = new DataSet();
            dsIn.Tables.Add("CustomerProgramInstanceByBatchCodeTypeOf");
            //dsIn.Tables.Add("BatchByCodeTypeEx");
            dsIn = gemoDream.Service.ProxyGenericGet(dsIn);
            dsIn.Tables[0].TableName = "CustomerProgramInstanceByBatchCode";
            //dsIn.Tables[0].TableName = "BatchByCode";
            dsIn.Tables[0].Rows.Add(dsIn.Tables[0].NewRow());
            dsIn.Tables[0].Rows[0]["GroupCode"] = sGroupCode;
            dsIn.Tables[0].Rows[0]["BatchCode"] = sBatchCode;
            DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);
            if (dsOut.Tables.Count > 0 && dsOut.Tables[0].Rows.Count > 0)
                return dsOut.Tables[0].Rows[0];
            return null;
        }
		


        private static  DataTable GetCheckedOperations(String BatchID)
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add("NameCheckedOperationByBatchID");
            dsData.Tables[0].Columns.Add("BatchID");
            dsData.Tables[0].Rows.Add(dsData.Tables[0].NewRow());
            dsData.Tables[0].Rows[0][0] = BatchID;
            dsData = gemoDream.Service.GetNameCheckedOperationByBatchID(dsData);
            return dsData.Tables[0];
        }

        public static DataTable GetCurrentItemByCode(string GroupCode, string BatchCode, string ItemCode,string IsNew)
        {
            string sIsNew = "0";
            if(IsNew == "1")
                sIsNew = "1";
            DataSet dsOrder = new DataSet();
            dsOrder.Tables.Add("ItemByCodeTypeEx");
            dsOrder = ProxyGenericGet(dsOrder);
            DataTable table = dsOrder.Tables[0];
            table.TableName = "ItemByCode";
            table.Columns.Add("IsNew");

            table.Rows.Add(table.NewRow());
            table.Rows[0]["GroupCode"]=Convert.ChangeType(GroupCode, table.Columns["GroupCode"].DataType);
            table.Rows[0]["BatchCode"]=Convert.ChangeType(BatchCode, table.Columns["BatchCode"].DataType);
            table.Rows[0]["IsNew"]=sIsNew;
            if(ItemCode != null)
            {
                table.Rows[0]["ItemCode"]=Convert.ChangeType(ItemCode, table.Columns["ItemCode"].DataType);
            }

            dsOrder = ProxyGenericGet(dsOrder);
            table = dsOrder.Tables[0];
            dsOrder.Tables.Remove(table);

            return table;
        }
		

#endregion Itemizn

#region CrystalReport
        public static DataSet GetMeasureValueByPart(DataSet dsPart)
        {
            try
            {
                return ProxyGenericGet(dsPart);
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetMeasureValueByPart: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static DataSet GetCrystalSet(string ID,string Name)
        {
            return ProxyGenericGetById(ID, Name);//Procedure dbo.spGetItem
        }

        public static DataSet GenericGetCrystalSet(DataSet dsIn)
        {
            return ProxyGenericGet(dsIn);
        }

        public static DataSet GetIIBGBIC(string GC, string BC, string IC)
        {
            DataSet dsIIBGBIC = new DataSet();
            DataTable dtIIBGBIC = new DataTable("IIBGBICTypeEx");
            dsIIBGBIC.Tables.Add(dtIIBGBIC);

            dsIIBGBIC = ProxyGenericGet(dsIIBGBIC);
            dsIIBGBIC.Tables["IIBGBICTypeEx"].TableName = "IIBGBIC";
            dsIIBGBIC.Tables["IIBGBIC"].Rows.Add(dsIIBGBIC.Tables["IIBGBIC"].NewRow());
            dsIIBGBIC.Tables["IIBGBIC"].Rows[0]["GroupCode"] = GC;
            dsIIBGBIC.Tables["IIBGBIC"].Rows[0]["BatchCode"] = BC;
            dsIIBGBIC.Tables["IIBGBIC"].Rows[0]["ItemCode"] = IC;

            return ProxyGenericGet(dsIIBGBIC);
        }

        public static bool IsTableInDataSet(DataSet dsData,string sTableName)
        {
            for(int i=0;i<dsData.Tables.Count;i++)
            {
                if(dsData.Tables[i].TableName==sTableName) return true;
            }
            return false;
        }

        public static DataSet GetTblMeasure()
        {
            DataSet dsParameters=new DataSet();
            DataTable tblParams=new DataTable("TblMeasure");
            dsParameters.Tables.Add(tblParams);
            return Service.ProxyGenericGet(dsParameters);
        }

#endregion CrystalReport

        public static DataSet GetItem(string sItemCode, string sBatchID)
        {
            DataSet dsItem = new DataSet();
            DataTable dtItem = new DataTable("ItemTypeEx");
            dsItem.Tables.Add(dtItem);

            dsItem = srv.GenericGetProcedure(sSessionId, dsItem);
            dsItem.Tables[0].Rows.Add(dsItem.Tables[0].NewRow());
            dsItem.Tables[0].Rows[0]["BatchID_ItemCode"] = sBatchID + "_" + sItemCode;
            dsItem.Tables[0].TableName = "Item";
            return srv.GenericGetProcedure(sSessionId, dsItem);
        }
		
        public static string FillToFiveChars(string sNumber)
        {
            while(sNumber.Length<5)
                sNumber="0"+sNumber;
            return sNumber;
        }
        public static string FillToThreeChars(string sNumber)
        {
            while(sNumber.Length<3)
                sNumber="0"+sNumber;
            return sNumber;
        }
		
        public static string FillToTwoChars(string sNumber)
        {
            while(sNumber.Length<2)
                sNumber="0"+sNumber;
            return sNumber;
        }

        public static string GetItemCommentByGroup_Batch(string GC, string BC)
        {
            DataSet ds1 = ProxyGenericGetById(GC + "_" + BC, "BatchByCode2");
            return "";
        }

#region Utils


#region Shapes
        public static DataSet GetShapesTree()
        {
            try
            {
                DataSet dsShapeType = new DataSet();
                dsShapeType.Tables.Add("Shapes");
                return ProxyGenericGet(dsShapeType);
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetShapesTree: Unable to get data from server. Reason: " + exc.Message, 
                    "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static DataSet GetPriceGroups()
        {
            try
            {
                DataSet dsPriceGroups = new DataSet();
                dsPriceGroups.Tables.Add("PriceGroups");
                return ProxyGenericGet(dsPriceGroups);
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetPriceGroups: Unable to get data from server. Reason: " + exc.Message, 
                    "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static DataSet GetShapesInfo()
        {
            DataSet dsShapesInfo = new DataSet();
            dsShapesInfo.Tables.Add("ShapesInfo");
            try
            {
                return ProxyGenericGet(dsShapesInfo);
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetShapesInfo: Unable to get data from server. Reason: " + exc.Message, 
                    "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static void SetShapeInfo(DataTable dtShapeInfo)
        {
            DataSet dsInfo = new DataSet();
            dsInfo.Tables.Add(dtShapeInfo);

            try
            {
                ProxyGenericSet(dsInfo, "Set");
            }
            catch(Exception exc)
            {
                MessageBox.Show("SetShapeInfo: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);				
            }
        }
#endregion Shapes

#region Users
        public static DataSet GetUsers()
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add("Users");

            try
            {
                return ProxyGenericGet(dsData);
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetUsers: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static DataSet GetRoles()
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add("Roles");

            try
            {
                return ProxyGenericGet(dsData);
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetRoles: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }		
        }

        public static DataSet GetUserTypeEx()
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add("UserTypeEx");

            try
            {
                return ProxyGenericGet(dsData);
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetUserTypeEx: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }	
        }

        public static void UserExpire(DataTable dtUserExpire)
        {
            DataSet dsExpUser = new DataSet();
            dsExpUser.Tables.Add(dtUserExpire.Copy());
            dsExpUser.Tables[0].TableName = "User";

            try
            {
                ProxyGenericSet(dsExpUser, "Expire");
            }
            catch(Exception exc)
            {
                MessageBox.Show("Unable to connect to server. Reason: " + exc.Message, 
                    "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
#endregion Users

#region Colors
        public static DataSet GetMeasures()
        {
            DataSet dsMeasures = new DataSet();
            dsMeasures.Tables.Add("Measures");

            try
            {
                return ProxyGenericGet(dsMeasures);
            }
            catch(Exception exc)
            {
                MessageBox.Show("Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
#endregion Colors


#endregion Utils

#region AccountRep
#region Tab2
        public static void DrawAdjustShapeImage(PictureBox pbImageContainer, Image imShape)
        {
            try
            {
                if(pbImageContainer != null && imShape != null)
                {
                    double scaleX = (double)imShape.Width / (double)pbImageContainer.Width;	
                    double scaleY = (double)imShape.Height / (double)pbImageContainer.Height;
                    double scale = Math.Max(scaleX,scaleY);
                    if(scaleX == 0)
                    {
                        if(imShape.Width !=0)
                        {
                            Image icoShape = imShape.GetThumbnailImage(pbImageContainer.ClientSize.Width - 1,
                                pbImageContainer.ClientSize.Height - 1,
                                null,IntPtr.Zero);
                            pbImageContainer.Image = icoShape;
                            pbImageContainer.Top = (pbImageContainer.Parent.Height - pbImageContainer.Height) / 2;
                        }
                        return;
                    }
                    //pbImageContainer.BackColor = Color.White;
                    int NewWidth = Convert.ToInt32((double)imShape.Width / scale);
                    int NewHeight = Convert.ToInt32((double)imShape.Height / scale);
                    if(imShape.RawFormat == ImageFormat.Wmf || imShape.RawFormat == ImageFormat.Emf)
                    {
                        pbImageContainer.ClientSize = new Size(NewWidth, NewHeight);						
                        //pbImageContainer.ClientSize = new Size(imShape.Width / scaleX, imShape.Height / scaleX);						
                        pbImageContainer.Image = imShape;
                        pbImageContainer.Top = (pbImageContainer.Parent.Height - Convert.ToInt32(imShape.Height / scale)) / 2;
                    }
                    else
                    {
                        Image icoShape = imShape.GetThumbnailImage(NewWidth,NewHeight,null,IntPtr.Zero);
                        pbImageContainer.SizeMode = PictureBoxSizeMode.CenterImage;
                        pbImageContainer.Image = icoShape;
                        //pbImageContainer.BackColor = Color.White;
                    }
                    return;
                }
                pbImageContainer.Image = imShape;

            }
            catch(Exception ex)
            {
                string msg = ex.Message;
            }
        }
        public static void DrawAdjustShapeImage(PictureBox pbImageContainer, Image imShape, int pbTop, int pbLeft, int pbWidth, int pbHeight)
        {
            try
            {
                if(pbImageContainer!=null && imShape!=null)
                {

                    if(pbWidth>0)
                        pbImageContainer.Width = pbWidth;
                    if(pbHeight>0)
                        pbImageContainer.Height = pbHeight;

                    double scaleX = (double)imShape.Width / (double)pbImageContainer.Width;	
                    double scaleY = (double)imShape.Height / (double)pbImageContainer.Height;
                    double scale = Math.Max(scaleX,scaleY);
                    Image icoShape=null;
                    if(scale == 0)
                    {
                        if(imShape.Width !=0)
                        {
                            //pbImageContainer.Size = pbImageContainer.Parent.Size;
                            icoShape = imShape.GetThumbnailImage(pbImageContainer.ClientSize.Width - 1,
                                pbImageContainer.ClientSize.Height - 1,
                                null,IntPtr.Zero);
                            pbImageContainer.Image = icoShape;
                            pbImageContainer.Top = (pbImageContainer.Parent.Height - pbImageContainer.Height) / 2;
                            pbImageContainer.BackColor = Color.White;
                            //pbImageContainer.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                        return;
                    }
				
                    //pbImageContainer.SizeMode = PictureBoxSizeMode.StretchImage;
				
                    int NewWidth = Convert.ToInt32((double)imShape.Width / scale)-1;
                    int NewHeight = Convert.ToInt32((double)imShape.Height / scale)-1;
                    icoShape = imShape.GetThumbnailImage(NewWidth,NewHeight,null,IntPtr.Zero);
                    pbImageContainer.SizeMode = PictureBoxSizeMode.CenterImage;
                    pbImageContainer.Image = icoShape;
                    if(pbTop!=-1)
                        pbImageContainer.Top =pbTop;
                    if(pbLeft !=-1)
                        pbImageContainer.Left = pbLeft;
                    return;
                }
                else
                    pbImageContainer.Image = imShape; ;
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
            }
        }

		
        public static DataSet GetItemInfo(string BatchID_ItemCode)
        {			
            try
            {
                DataSet ds = ProxyGenericGetById(BatchID_ItemCode, "ItemDetails");
                AddImageColumn(ds.Tables[0], "Path2Icon", "Icon");
                return ds;
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetItemInfo: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static DataSet GetOpsByItem(string itemID)
        {
            try
            {
                return ProxyGenericGetById(itemID, "GetOpsByItem");
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetOpsByItem: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        //change by vetal_242 15.09.2006
        //end session work for item
        public static DataSet SetEndSession(string sBatchID, string sItemCode)
        {
            DataSet dsNew = new DataSet();
			
            dsNew.Tables.Add(new DataTable("EndRecheckSession"));
            dsNew.Tables["EndRecheckSession"].Columns.Add("BatchID");
            dsNew.Tables["EndRecheckSession"].Columns.Add("ItemCode");
            dsNew.Tables["EndRecheckSession"].Rows.Add(dsNew.Tables["EndRecheckSession"].NewRow());

            try
            {
                dsNew.Tables["EndRecheckSession"].Rows[0]["BatchID"] = sBatchID;
                dsNew.Tables["EndRecheckSession"].Rows[0]["ItemCode"] = sItemCode;
                DataSet ds = ProxyGenericSet(dsNew, "");
                return ds;
            }
            catch(Exception exc)
            {
                MessageBox.Show("SetEndSession: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);				
            }
            return null;
        }

        public static DataSet SetEndSession1(string sBatchID, string sItemCode)
        {
            DataSet dsNew = new DataSet();
			
            dsNew.Tables.Add(new DataTable("EndRecheckSession1"));
            dsNew.Tables["EndRecheckSession1"].Columns.Add("BatchID");
            dsNew.Tables["EndRecheckSession1"].Columns.Add("ItemCode");
            dsNew.Tables["EndRecheckSession1"].Rows.Add(dsNew.Tables["EndRecheckSession1"].NewRow());

            try
            {
                dsNew.Tables["EndRecheckSession1"].Rows[0]["BatchID"] = sBatchID;
                dsNew.Tables["EndRecheckSession1"].Rows[0]["ItemCode"] = sItemCode;
                DataSet ds = ProxyGenericSet(dsNew, "");
                return ds;
            }
            catch(Exception exc)
            {
                MessageBox.Show("SetEndSession: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);				
            }
            return null;
        }
        public static DataSet GetCheckClossedRecheckSessionForItem(string sBatchId, string sItemCode)
        {
            DataSet dsParam = new DataSet();
            dsParam.Tables.Add("CheckClossedRecheckSessionForItem");
            dsParam.Tables[0].Columns.Add("BatchID");
            dsParam.Tables[0].Columns.Add("ItemCode");
            dsParam.Tables[0].Rows.Add(dsParam.Tables[0].NewRow());
            dsParam.Tables[0].Rows[0]["BatchID"] = sBatchId;
            dsParam.Tables[0].Rows[0]["ItemCode"] = sItemCode;
            try
            {
                return ProxyGenericGet(dsParam);//Procedure dbo.spGetCheckClossedRecheckSessionForItem
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetPartValueType: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static DataSet GetPartValueTypeEx()
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add(new DataTable("PartValueTypeEx"));

            try
            {
                return ProxyGenericGet(dsData);
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetPartValueTypeEx: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static DataSet GetPartValueType(DataSet dsData)
        {
            try
            {
                return ProxyGenericGet(dsData);
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetPartValueType: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static void SendBatchByFax(DataTable dtData, string ext, string path, string sSubject,string sFileName)
        {
            ProxySendBatchByFax(dtData, ext, path, sSubject, sFileName);
        }
        public static void SendBatchByFax(string sFileName, string sTo, string sSubject)
        {
            ProxySendBatchByFax1(sFileName, sTo, sSubject);
        }
		

        public static DataSet GetShapeByCode(int code)
        {
            try
            {
                return ProxyGenericGetById(code.ToString(), "ShapeByCode");
            }
            catch(Exception exc)
            {
                MessageBox.Show("Unable to connect to server. Reason: " + exc.Message, "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static DataSet GetItemCPPictureByCode(string sOrderCode, string sBatchCode)
        {
            DataSet dsItemByCodeTypeEx = new DataSet();
            dsItemByCodeTypeEx.Tables.Add(new DataTable("ItemByCodeTypeEx"));
            dsItemByCodeTypeEx = ProxyGenericGet(dsItemByCodeTypeEx);

            dsItemByCodeTypeEx.Tables[0].Rows.Add(dsItemByCodeTypeEx.Tables[0].NewRow());
            dsItemByCodeTypeEx.Tables[0].Rows[0]["GroupCode"] = sOrderCode;
            dsItemByCodeTypeEx.Tables[0].Rows[0]["BatchCode"] = sBatchCode;
            //dsItemByCodeTypeEx.Tables[0].Rows[0]["ItemCode"] = sItemCode;
            dsItemByCodeTypeEx.Tables[0].TableName = "ItemCPPictureByCode";

            return ProxyGenericGet(dsItemByCodeTypeEx);
        }

        // Check  item CP and price
        public static DataSet GetCheckItemCpAndPrice(string sBatchID, string sItemCode)
        {
            try
            {
                DataSet dsData = new DataSet();
                dsData.Tables.Add("CheckItemCpAndPrice");
                dsData.Tables[0].Columns.Add("BatchID");
                dsData.Tables[0].Columns.Add("ItemCode");
                dsData.Tables[0].Rows.Add(dsData.Tables[0].NewRow());
                dsData.Tables[0].Rows[0]["BatchID"] = sBatchID;
                dsData.Tables[0].Rows[0]["ItemCode"] = sItemCode;

                return ProxyGenericGet(dsData);
            }
            catch(Exception exc)
            {
                MessageBox.Show("Unable to connect to server. Reason: " + exc.Message, "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        //get batch invoice
        public static DataSet GetBatchInvoice(string sBatchID)
        {
            try
            {
                DataSet dsData = new DataSet();
                dsData.Tables.Add("BatchInvoice");
                dsData.Tables[0].Columns.Add("BatchID");
                dsData.Tables[0].Rows.Add(dsData.Tables[0].NewRow());
                dsData.Tables[0].Rows[0]["BatchID"] = sBatchID;

                return ProxyGenericGet(dsData);//Procedure dbo.spGetBatchInvoice
            }
            catch(Exception exc)
            {
                MessageBox.Show("Unable to connect to server. Reason: " + exc.Message, "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        //Add invoicing for all batches in dtData
        public static DataSet AddInvoice2(DataTable dtData, string Header)
        {			

            DataSet dsSet = new DataSet();
            dsSet.Tables.Add(dtData);

            try
            {
                return ProxyGenericSet(dsSet, Header);
            }
            catch (Exception exc)
            {
                throw new Exception("Internal error occured at Service.AddInvoice2: " + exc.Message);				
            }
        }

        //Runs invoicing for all batches in dtData
        public static DataSet InvoicingGo(DataSet dsData)
        {			
            //if(bRegularInvoice) 
            dsData.Tables[0].TableName = "InvoicingGo";	
            //else
            //dsData.Tables[0].TableName = "InvoicingGoSKU";	
            try
            {
                return ProxyGenericSet(dsData, "Set");
            }
            catch (Exception exc)
            {
                throw new Exception("Internal error occured at Service.InvoicingGo: " + exc.Message);				
            }
        }
#endregion Tab2

#region Tab3
		
        public static DataSet GetItemOperationTypeOf()
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add("ItemOperationTypeOf");
            try
            {
                return ProxyGenericGet(dsData);
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetItemOperationTypeOf: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static void AddItemOperation(DataSet dsData)
        {
            try
            {
                ProxyGenericSet(dsData, "Add");
            }
            catch(Exception exc)
            {
                MessageBox.Show("AddItemOperation: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static DataSet GetItemDocByCodeTypeEx()
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add("ItemDocByCodeTypeEx");
            try
            {
                return ProxyGenericGet(dsData);
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetItemDocByCodeTypeEx: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static DataSet GetItemDocByCode(string OrderCode, string BatchCode, string ItemCode)
        {
            DataSet dsData = GetItemDocByCodeTypeEx();
            dsData.Tables[0].TableName = ("ItemDocByCode");
            try
            {
                dsData.Tables[0].Rows.Add(dsData.Tables[0].NewRow());
                dsData.Tables[0].Rows[0]["GroupCode"] = OrderCode;  
                dsData.Tables[0].Rows[0]["BatchCode"] = BatchCode;
                dsData.Tables[0].Rows[0]["ItemCode"] = ItemCode;
                return ProxyGenericGet(dsData);
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetItemDocByCodeTypeEx: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static DataSet AddDocumentToQueue(string sItemOperationOfficeID_ItemOperationID, string sFullCode)
        {
            DataSet dsIn = new DataSet();
            DataTable dtIn = dsIn.Tables.Add("AddDocumentToQueue");

            dtIn.Columns.Add("ItemOperationOfficeID", System.Type.GetType("System.String"));
            dtIn.Columns.Add("ItemOperationID", System.Type.GetType("System.String"));
            dtIn.Columns.Add("FullCode", System.Type.GetType("System.String"));

            DataRow row = dtIn.NewRow();

            string[] s = sItemOperationOfficeID_ItemOperationID.Split('_');
            row["FullCode"]		    = sFullCode;
            row["ItemOperationOfficeID"] = s[0];
            row["ItemOperationID"]  = s[1];
								
            dtIn.Rows.Add(row);

            string sID;
            DataSet ds = srv.GenericSetProcedure(sSessionId, dsIn, "");
            return ds;
        }

        public static DataSet GetOpsByItemCode(DataSet dsData)
        {
            try
            {
                return ProxyGenericGet(dsData);
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetOpsByItemCode: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
#endregion Tab3
		
        public static DataSet GetDocTypeNameByItemCode(string GroupCode, string BatchCode, string ItemCode)
        {
            DataSet dsIn = new DataSet();
            DataTable dt = new DataTable("DocTypeNameByItemCode");
            dt.Columns.Add("GroupCode");
            dt.Columns.Add("BatchCode");
            dt.Columns.Add("ItemCode");
            dt.Rows.Add(new object[] {GroupCode, BatchCode, ItemCode});
            dsIn.Tables.Add(dt);
            DataSet result = Service.ProxyGenericGet(dsIn);
            return result;
        }
#endregion AccountRep

#region CustomerCreation

#region Customers
        public static DataSet GetCustomers()
        {
            DataSet dsCustomersGet = new DataSet();

            DataTable dtCustomers = new DataTable("Customers");
            dsCustomersGet.Tables.Add(dtCustomers);

            try
            {
                return ProxyGenericGet(dsCustomersGet);//Procedure spGetCustomers
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetCustomers: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static DataSet GetCustomerType(DataSet dsType)
        {
            try
            {
                return ProxyGenericGet(dsType);
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetCustomerType: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static DataSet GetCustomerTypeEx()
        {
            DataSet dsCustomerGet = new DataSet();

            DataTable dtCustomer = new DataTable("CustomerTypeEx");
            DataTable dtCarriers = new DataTable("Carriers");
            DataTable dtBizs = new DataTable("BusinessTypes");
            DataTable dtIndustry = new DataTable("IndustryMemberships");
            DataTable dtStates = new DataTable("USStates");
            DataTable dtPositions = new DataTable("Positions");

            dsCustomerGet.Tables.Add(dtCustomer);
            dsCustomerGet.Tables.Add(dtCarriers);
            dsCustomerGet.Tables.Add(dtBizs);
            dsCustomerGet.Tables.Add(dtIndustry);
            dsCustomerGet.Tables.Add(dtStates);
            dsCustomerGet.Tables.Add(dtPositions);

            try
            {
                return ProxyGenericGet(dsCustomerGet);
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetCustomerTypeEx: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static DataSet UpdCustomerInfo(DataTable dtUpd)
        {
            DataSet dsNew = new DataSet();
            dsNew.Tables.Add(dtUpd.Copy());
            dsNew.Tables[0].TableName = "Customer";
            try
            {
                return ProxyGenericSet(dsNew, "Set");
            }
            catch(Exception exc)
            {				
                MessageBox.Show("UpdCustomerInfo: Unable to Connect to server. Reason: " + exc.Message, 
                    "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        /*
                public static DataSet QBAddCustomer(DataSet dsCust)
                {
                    return ProxyQBAddCustomer(dsCust);
                }
        *//*
		public static DataSet QBModCustomer(DataSet dsCust)
		{
			return ProxyQBModifyCustomer(dsCust);
		}
		*/
#endregion Customers

#region Persons
        public static DataSet GetPersonsByCustomer(DataSet dsCustID)
        {
            DataSet dsCopy = dsCustID.Copy();
            dsCopy.Tables[0].TableName = "PersonsByCustomer";

            try
            {
                return ProxyGenericGet(dsCopy);
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetPersonsByCustomer: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static DataSet GetPerson(string sPersonID, string sPersonCustomerID,
            string sPersonCustomerOfficeID)
        {
            DataSet dsIn = new DataSet();
            dsIn.Tables.Add("Person");
            dsIn.Tables[0].Columns.Add("PersonID", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("PersonCustomerID", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("PersonCustomerOfficeID", System.Type.GetType("System.String"));
            dsIn.Tables[0].Rows.Add(dsIn.Tables[0].NewRow());
            dsIn.Tables[0].Rows[0]["PersonID"] = sPersonID;
            dsIn.Tables[0].Rows[0]["PersonCustomerID"] = sPersonCustomerID;
            dsIn.Tables[0].Rows[0]["PersonCustomerOfficeID"] = sPersonCustomerOfficeID;
            DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);			
            return dsOut;
        }
        public static DataSet GetCarrier(string sGroupOfficeID, string sGroupID)
        {
            DataSet dsIn = new DataSet();
            dsIn.Tables.Add("CarrierByGroup");
            dsIn.Tables[0].Columns.Add("GroupOfficeID", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("GroupID", System.Type.GetType("System.String"));
            dsIn.Tables[0].Rows.Add(dsIn.Tables[0].NewRow());
            dsIn.Tables[0].Rows[0]["GroupOfficeID"] = sGroupOfficeID;
            dsIn.Tables[0].Rows[0]["GroupID"] = sGroupID;
            DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);			
            return dsOut;
        }

        public static DataSet GetPersonType()
        {
            DataSet dsPersonType = new DataSet();
            dsPersonType.Tables.Add("PersonTypeOf");
	
            try
            {
                return ProxyGenericGet(dsPersonType);
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetPersonType: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static DataSet GetPersonTypeEx()
        {
            DataSet dsPersonTypeEx = new DataSet();
            dsPersonTypeEx.Tables.Add("PersonTypeEx");
            try
            {
                return ProxyGenericGet(dsPersonTypeEx);
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetPersonTypeEx: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
		
        public static void UpdPersonInfo(DataTable dtUpd)
        {
            dtUpd.TableName = "Person";
            DataSet dsNew = new DataSet();
            dsNew.Tables.Add(dtUpd.Copy());
            try
            {
                ProxyGenericSet(dsNew, "Set");
            }
            catch(Exception exc)
            {
                MessageBox.Show("UpdPersonInfo: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void PersonExpire(DataTable dtPersonExpire)
        {
            DataSet dsExpPerson = new DataSet();
            dsExpPerson.Tables.Add(dtPersonExpire.Copy());
            dsExpPerson.Tables[0].TableName = "Person";

            try
            {
                ProxyGenericSet(dsExpPerson, "Expire");
            }
            catch(Exception exc)
            {
                MessageBox.Show("PersonExpire: Unable to connect to server. Reason: " + exc.Message, 
                    "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
#endregion Persons

#region Orders

        public static DataSet GetOrderTree(int CustomerID, int filter)
        {
            DataTable dtFilterTable = new DataTable("Orders");
            dtFilterTable.Columns.Add("CustomerID");
            dtFilterTable.Columns.Add("Status");			

            switch (filter)
            {
                case 0: 
                {
                    dtFilterTable.Rows.Add(new object[] {CustomerID, "All"});
                    break;
                }

                case 1: 
                {
                    dtFilterTable.Rows.Add(new object[] {CustomerID, "Open"});
                    break;
                }
                case 2:
                {
                    dtFilterTable.Rows.Add(new object[] {CustomerID, "Closed"});
                    break;
                }
                default:
                {
                    dtFilterTable.Rows.Add(new object[] {CustomerID, "All"});
                    break;
                }
            }

            DataSet dsOrders = new DataSet();
            dsOrders.Tables.Add(dtFilterTable);

            try
            {
                dsOrders = ProxyGenericGet(dsOrders);
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetOrderTree: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            Client.OrdersTreeRelationsAdd(dsOrders);

            return dsOrders;
        }


#endregion Orders

#region Operations
        public static DataSet GetOperationsTree(string CustomerID)
        {
            DataSet dsOps = new DataSet();
            dsOps.Tables.Add("CustomerTypeEx");
            dsOps = ProxyGenericGet(dsOps);
            dsOps.Tables["CustomerTypeEx"].TableName = "COGPByCustomer";
            dsOps.Tables["COGPByCustomer"].Rows.Add(dsOps.Tables["COGPByCustomer"].NewRow());

            dsOps.Tables["COGPByCustomer"].Rows[0]["CustomerOfficeID_CustomerID"] = CustomerID;

            try
            {
                return ProxyGenericGet(dsOps);
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetOperationsTree: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static DataSet GetOperationTypeGroupRangePrices()
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add("OperationTypeGroupRangePrices");
            try
            {
                return ProxyGenericGet(dsData);
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetOperationsTree: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static DataSet GetCaratRanges(string sCID, string sCOID)
        {
            DataSet dsData = new DataSet();
            //dsData.Tables.Add("CaratRanges");
            //dsData.Tables.Add("CaratRangesByCustomer");
            DataTable dtIn = dsData.Tables.Add("CaratRangesByCustomer");
            dtIn.Columns.Add("CustomerID", System.Type.GetType("System.String"));
            dtIn.Columns.Add("CustomerOfficeID", System.Type.GetType("System.String"));
            //dtIn.Columns.Add("CRID", System.Type.GetType("System.String"));

            DataRow row = dtIn.NewRow();
            //row["AuthorID"] = str;
            //row["AuthorOfficeID"] = str;
            row["CustomerID"] = sCID;
            row["CustomerOfficeID"] = sCOID;
            dtIn.Rows.Add(row);

            try
            {
                return ProxyGenericGet(dsData);
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetCaratRanges: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static DataSet GetCustomerTypeOf()
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add("CustomerTypeOf");
            try
            {
                return ProxyGenericGet(dsData);
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetCustomerTypeOf: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static DataSet GetCustomerOperationGroupRangePrices()
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add("CustomerOperationGroupRangePrices");
            try
            {
                return ProxyGenericGet(dsData);
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetCustomerOperationGroupRangePrices: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static DataSet GetCOGRPByCustomer(string CustID)
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add("CustomerTypeEx");
            dsData = ProxyGenericGet(dsData);
            dsData.Tables[0].TableName = "COGRPByCustomer";
            dsData.Tables[0].Rows.Add(dsData.Tables[0].NewRow());
            dsData.Tables[0].Rows[0][0] = CustID;
            try
            {
                return ProxyGenericGet(dsData);
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetCOGRPByCustomer: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /**
         * by Vetal_242
         * 04.06.2006
         * */
        public static DataSet GetCustomerProgramRuleByBatchID(string BatchID)
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add("CustomerProgramRuleByBatchID");
            dsData.Tables[0].Columns.Add("BatchID");
            dsData.Tables[0].Rows.Add(dsData.Tables[0].NewRow());
            dsData.Tables[0].Rows[0][0] = BatchID;
            try
            {
                return ProxyGenericGet(dsData);
            }
            catch(Exception exc)
            {
                MessageBox.Show("spGetCustomerProgramRuleByBatchID: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static void SetCustomerOperationGroupRangePrice(DataSet dsData)
        {
            dsData.Tables[0].TableName = "CustomerOperationGroupRangePrice";
            try
            {
                ProxyGenericSet(dsData, "Set");
            }
            catch(Exception exc)
            {				
            }
        }
        public static DataSet GetCOGRPTypeOf()
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add("CustomerOperationGroupRangePriceTypeOf");
            try
            {
                return ProxyGenericGet(dsData);
            }
            catch(Exception exc)
            {
                MessageBox.Show("SetCustomerOperationGroupRangePrice: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static DataSet GetCOGPTypeOf()
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add("CustomerOperationGroupPriceTypeOf");
            try
            {
                return ProxyGenericGet(dsData);
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetCOGPTypeOf: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static void SetCOGP(DataSet dsData)
        {
            dsData.Tables[0].TableName = "CustomerOperationGroupPrice";
            try
            {
                ProxyGenericSet(dsData, "Set");
            }
            catch(Exception exc)
            {				
            }
        }
#endregion Operations

#endregion CustomerCreation

#region CustomerProgram
        public static DataSet GetAllOperationsTree()
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add("OperationTree");

            try
            {
                return ProxyGenericGet(dsData);
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetAllOperationsTree: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static DataTable GetAdditionalService()
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add("AdditionalService");

            try
            {
                return ProxyGenericGet(dsData).Tables[0];
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetAdditionalService: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static DataSet GetProgramMainProps(string CustProgName)
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add("CustomerProgramByNameTypeEx");
            try
            {
                dsData = ProxyGenericGet(dsData);

                dsData.Tables["CustomerProgramByNameTypeEx"].TableName = "CustomerProgramByName";				
                dsData.Tables["CustomerProgramByName"].Rows.Add(dsData.Tables["CustomerProgramByName"].NewRow());
                dsData.Tables["CustomerProgramByName"].Rows[0]["CustomerProgramName"] = CustProgName;
                return ProxyGenericGet(dsData);
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetProgramMainProps: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static DataSet GetDocs()
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add("Docs");

            try
            {
                return ProxyGenericGet(dsData);
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetDocs: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static DataSet GetCustomerProgramTypeOf()
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add("CustomerProgramTypeOf2");

            try
            {
                return ProxyGenericGet(dsData);
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetCustomerProgramTypeOf: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static DataSet AddCustomerProgram(DataSet dsData)
        {
            try
            {
                return ProxyGenericSet(dsData, "Add");
            }
            catch(Exception exc)
            {
                MessageBox.Show("AddCustomerProgram: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static DataSet GetCustomerProgramTypeEx()
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add("CustomerProgramTypeEx");

            try
            {
                return ProxyGenericGet(dsData);
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetCustomerProgramTypeEx: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static DataSet AddCPHistory(DataSet dsData)
        {
            try
            {
                return ProxyGenericSet(dsData, "Add");
            }
            catch(Exception exc)
            {
                MessageBox.Show("AddCPHistory: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }	
	
        public static DataSet GetCPOperationTypeOf()
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add("CPOperationTypeOf");
            try
            {
                return ProxyGenericGet(dsData);
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetCPOperationTypeOf: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static DataSet GetNameCheckedOperationByBatchID(DataSet dsData)
        {
            try
            {
                return ProxyGenericGet(dsData);
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetNameCheckedOperationByBatchID: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static DataTable GetPricePartsMeasures(string sCPID)
        {
            try
            {
                DataSet dsData = new DataSet();
                dsData.Tables.Add("PricePartsMeasuresByCPID");
                dsData.Tables[0].Columns.Add("CPID");
                dsData.Tables[0].Rows.Add(dsData.Tables[0].NewRow());
                dsData.Tables[0].Rows[0]["CPID"] = sCPID;
                return ProxyGenericGet(dsData).Tables[0];//Procedure dbo.spGetPricePartsMeasuresByCPID
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetPricePartsMeasures: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static DataTable GetPriceRange(string sCPID)
        {
            try
            {
                DataSet dsData = new DataSet();
                dsData.Tables.Add("PriceRangeByCPID");
                dsData.Tables[0].Columns.Add("CPID");
                dsData.Tables[0].Rows.Add(dsData.Tables[0].NewRow());
                dsData.Tables[0].Rows[0]["CPID"] = sCPID;
                return ProxyGenericGet(dsData).Tables[0];
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetPriceRange: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static DataTable GetCustomerProgramPriceByCPID(string sCPID)
        {
            try
            {
                if(sCPID == "")
                    sCPID = "0";
                DataSet dsData = new DataSet();
                dsData.Tables.Add("CustomerProgramPriceByCPID");
                dsData.Tables[0].Columns.Add("CPID");
                dsData.Tables[0].Rows.Add(dsData.Tables[0].NewRow());
                dsData.Tables[0].Rows[0]["CPID"] = sCPID;
                return ProxyGenericGet(dsData).Tables[0];
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetCustomerProgramPriceByCPID: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static DataTable GetAdditionalServicePrice(string sCPID)
        {
            try
            {
                DataSet dsData = new DataSet();
                dsData.Tables.Add("AdditionalServicePriceByCPID");
                dsData.Tables[0].Columns.Add("CPID");
                dsData.Tables[0].Rows.Add(dsData.Tables[0].NewRow());
                dsData.Tables[0].Rows[0]["CPID"] = sCPID;
                dsData = ProxyGenericGet(dsData);
                dsData.Tables[0].Columns["ASID"].ColumnName = "AdditionalServiceID";
                return dsData.Tables[0];
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetAdditionalServicePrice: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static void SetCPOperation(DataSet dsData)
        {
            try
            {
                ProxyGenericSet(dsData, "Set");
            }
            catch(Exception exc)
            {
                MessageBox.Show("SetCPOperation: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
		
        public static string SetPrices()
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add("Prices");
            dsData.Tables[0].Rows.Add(dsData.Tables[0].NewRow());
            try
            {
                return ProxyGenericSet(dsData, "Set").Tables[0].Rows[0][0].ToString();
            }
            catch(Exception exc)
            {
                MessageBox.Show("SetPrices: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static void SetPricePartsMeasures(DataTable dtData, string sPriceID)
        {
            try
            {
                DataSet dsData = new DataSet();
                dtData.Columns.Add("PriceID");
                for(int i = 0; i < dtData.Rows.Count; i++)
                {
                    dtData.Rows[i]["PriceID"] = sPriceID;
                }
                dsData.Tables.Add(dtData);
                ProxyGenericSet(dsData, "Set");
            }
            catch(Exception exc)
            {
                MessageBox.Show("SetPricePartsMeasures: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void SetPriceRange(DataTable dtData, string sPriceID)
        {
            try
            {
                DataSet dsData = new DataSet();
                dtData.Columns.Add("PriceID");
                for(int i = 0; i < dtData.Rows.Count; i++)
                {
                    dtData.Rows[i]["PriceID"] = sPriceID;
                }
                dsData.Tables.Add(dtData);
                ProxyGenericSet(dsData, "Set");
            }
            catch(Exception exc)
            {
                MessageBox.Show("SetPriceRange: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
		
        public static void SetAdditionalServicePrice(DataTable dtData, string sPriceID)
        {
            try
            {
                DataSet dsData = new DataSet();
                dtData.Columns.Add("PriceID");
                for(int i = 0; i < dtData.Rows.Count; i++)
                {
                    dtData.Rows[i]["PriceID"] = sPriceID;
                }
                dsData.Tables.Add(dtData);
                ProxyGenericSet(dsData, "Set");
            }
            catch(Exception exc)
            {
                MessageBox.Show("SetAdditionalServicePrice: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void SetCPOperationWithCheck(DataSet dsData)
        {
            try
            {
                ProxyGenericSet(dsData, "Set");
            }
            catch(Exception exc)
            {
                MessageBox.Show("SetCPOperationWithCheck: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static DataSet GetCPDocs(DataSet dsData)
        {
            try
            {
                return ProxyGenericGet(dsData);
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetCPDocs: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static DataSet GetCPDocsTypeOf()
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add("CPDocTypeOf");
            try
            {
                return ProxyGenericGet(dsData);
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetDocsTypeOf: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
		
        public static DataTable GetSomeAdditionalMeasureByBatchID(string sBatchID)
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add("SomeAdditionalMeasureByBatchID");
            dsData.Tables[0].Columns.Add("BatchID");
            dsData.Tables[0].Rows.Add(dsData.Tables[0].NewRow());
            dsData.Tables[0].Rows[0]["BatchID"] = sBatchID;
            try
            {
                return ProxyGenericGet(dsData).Tables[0];
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetSomeAdditionalMeasureByBatchID: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static DataTable GetGirdleByBatchID(string sBatchID)
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add("GirdleByBatchID");
            dsData.Tables[0].Columns.Add("BatchID");
            dsData.Tables[0].Rows.Add(dsData.Tables[0].NewRow());
            dsData.Tables[0].Rows[0]["BatchID"] = sBatchID;
            try
            {
                return ProxyGenericGet(dsData).Tables[0];
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetGirdleByBatchID: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static DataTable GetPartValueByBatchID(string sBatchID)
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add("PartValueByBatchID");
            dsData.Tables[0].Columns.Add("BatchID");
            dsData.Tables[0].Rows.Add(dsData.Tables[0].NewRow());
            dsData.Tables[0].Rows[0]["BatchID"] = sBatchID;
            try
            {
                return ProxyGenericGet(dsData).Tables[0];
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetPartValueByBatchID: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
		
        public static DataTable GetPartValueByBatchIDItemCode(string sBatchID, string sItemCode)
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add("PartValueByBatchIDItemCode");
            dsData.Tables[0].Columns.Add("BatchID");
            dsData.Tables[0].Columns.Add("ItemCode");
            dsData.Tables[0].Rows.Add(dsData.Tables[0].NewRow());
            dsData.Tables[0].Rows[0]["BatchID"] = sBatchID;
            dsData.Tables[0].Rows[0]["ItemCode"] = sItemCode;
            try
            {
                return ProxyGenericGet(dsData).Tables[0];
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetPartValueByBatchIDItemCode: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static DataTable GetPartValueByCode(string sGroupCode, string sBatchCode, string sItemCode)
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add("PartValueByCode");
            dsData.Tables[0].Columns.Add("BatchCode");
            dsData.Tables[0].Columns.Add("GroupCode");
            dsData.Tables[0].Columns.Add("ItemCode");
            dsData.Tables[0].Rows.Add(dsData.Tables[0].NewRow());
            dsData.Tables[0].Rows[0]["BatchCode"] = sBatchCode;
            dsData.Tables[0].Rows[0]["GroupCode"] = sGroupCode;
            dsData.Tables[0].Rows[0]["ItemCode"] = sItemCode;
            try
            {
                return ProxyGenericGet(dsData).Tables[0];
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetPartValueByCode: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static DataTable GetPartValueByCodePrev(string sGroupCode, string sBatchCode, string sItemCode,string sIsPrev)
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add("PartValueByCode");
            dsData.Tables[0].Columns.Add("BatchCode");
            dsData.Tables[0].Columns.Add("GroupCode");
            dsData.Tables[0].Columns.Add("ItemCode");
            dsData.Tables[0].Columns.Add("IsPrev");
            dsData.Tables[0].Rows.Add(dsData.Tables[0].NewRow());
            dsData.Tables[0].Rows[0]["BatchCode"] = sBatchCode;
            dsData.Tables[0].Rows[0]["GroupCode"] = sGroupCode;
            dsData.Tables[0].Rows[0]["ItemCode"] = sItemCode;
            dsData.Tables[0].Rows[0]["IsPrev"] = sIsPrev;

            try
            {
                return ProxyGenericGet(dsData).Tables[0];
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetPartValueByCode: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static DataTable GetAllCutGradeRule()
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add("AllCutGradeRule");
            try
            {
                return ProxyGenericGet(dsData).Tables[0];
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetAllCutGradeRule: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static DataTable GetMeasureReplacements()
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add("MeasureReplacements");
            try
            {
                return ProxyGenericGet(dsData).Tables[0];
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetMeasureReplacements: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static DataSet GetCPDocRuleTypeOf()
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add("CPDocRuleTypeOf");
            try
            {
                return ProxyGenericGet(dsData);
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetCPDocRuleTypeOf: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static DataSet GetCPDocRuleByCpTypeOf(string sItemTypeID)
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add("CPDocRuleByCpTypeOf");
            dsData.Tables[0].Columns.Add("ItemTypeID");
            dsData.Tables[0].Rows.Add(dsData.Tables[0].NewRow());
            dsData.Tables[0].Rows[0]["ItemTypeID"] = sItemTypeID;
            try
            {
                return ProxyGenericGet(dsData);
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetCPDocRuleTypeOf: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static void SetCPDocRuleTypeOf(DataSet dsData)
        {
            try
            {
                ProxyGenericSet(dsData, "Set");
            }
            catch(Exception exc)
            {
                MessageBox.Show("SetCPDocRuleTypeOf: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static DataSet GetCPDoc_MeasureGroupTypeOf()
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add("CPDoc_MeasureGroupTypeOf");
            try
            {
                return ProxyGenericGet(dsData);
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetCPDoc_MeasureGroupTypeOf: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static void SetCPDoc_MeasureGroup(DataSet dsData)
        {
            try
            {
                ProxyGenericSet(dsData, "Set");
            }
            catch(Exception exc)
            {
                MessageBox.Show("SetCPDoc_MeasureGroup: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static DataSet SetCPDocs(DataSet dsData)
        {
            try
            {
                return ProxyGenericSet(dsData, "Set");
            }
            catch(Exception exc)
            {
                MessageBox.Show("SetCPDocs: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static DataSet GetMeasureGroups()
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add("MeasureGroups");
            try
            {
                return ProxyGenericGet(dsData);
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetMeasureGroups: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static DataSet GetCPDocRules(DataSet dsData)
        {
            dsData.Tables[0].TableName = "CPDocRule";
            try
            {
                return ProxyGenericGet(dsData);
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetCPDocRules: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static DataSet GetCPByName(string sName)
        {
            try
            {
                DataSet dsData = new DataSet();
                dsData.Tables.Add("CustomerProgramByName2TypeEx");
                dsData = ProxyGenericGet(dsData);
                dsData.Tables[0].TableName = "CustomerProgramByName2";
                dsData.Tables[0].Rows.Add(dsData.Tables[0].NewRow());
                dsData.Tables[0].Rows[0]["CustomerProgramName"] = sName;
                return ProxyGenericGet(dsData);	
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetCPByName: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static DataSet GetCPByNameAndCustomer(string sName, string sCust, string sVend)
        {
            try
            {
                DataSet dsData = new DataSet();
                dsData.Tables.Add("CustomerProgramByNameAndCustomerTypeOf");
                dsData = ProxyGenericGet(dsData);
                dsData.Tables[0].TableName = "CustomerProgramByNameAndCustomer";
                dsData.Tables[0].Rows.Add(dsData.Tables[0].NewRow());
                dsData.Tables[0].Rows[0]["CustomerProgramName"] = sName.Trim();
                dsData.Tables[0].Rows[0]["CustomerOfficeID"] = sCust.Split(new char[] {'_'})[0];
                dsData.Tables[0].Rows[0]["CustomerID"] = sCust.Split(new char[] {'_'})[1];
                dsData.Tables[0].Rows[0]["VendorOfficeID"] = sVend.Split(new char[] {'_'})[0];
                dsData.Tables[0].Rows[0]["VendorID"] = sVend.Split(new char[] {'_'})[1];
                return ProxyGenericGet(dsData);		
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetCPByNameAndCustomer: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static DataSet GetCheckedOperationByCP(string sName, string sCust)
        {
            try
            {
                DataSet dsData = new DataSet();
                dsData.Tables.Add();
                dsData.Tables[0].TableName = "CheckedOperationByCP";
                dsData.Tables[0].Columns.Add("CustomerProgramName");
                dsData.Tables[0].Columns.Add("CustomerOfficeID");
                dsData.Tables[0].Columns.Add("CustomerID");
                dsData.Tables[0].Rows.Add(dsData.Tables[0].NewRow());
                dsData.Tables[0].Rows[0]["CustomerProgramName"] = sName;
                dsData.Tables[0].Rows[0]["CustomerOfficeID"] = sCust.Split(new char[] {'_'})[0];
                dsData.Tables[0].Rows[0]["CustomerID"] = sCust.Split(new char[] {'_'})[1];
                return ProxyGenericGet(dsData);		
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetCPByNameAndCustomer: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static DataSet GetCPDocTypeEx()
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add("CPDocTypeEx");
            try
            {
                return ProxyGenericGet(dsData);
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetCPDocTypeEx: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static DataSet GetCPOperationsTypeEx()
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add("CPOperationsTypeEx");
            try
            {
                return ProxyGenericGet(dsData);
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetCPOperationsTypeEx: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static DataSet GetCPOperations(DataSet dsData)
        {
            try
            {
                return ProxyGenericGet(dsData);
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetCPOperations: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static DataSet GetCPMeasures(DataSet dsData)
        {
            dsData.Tables[0].TableName = "CPDoc_MeasureGroup";

            try
            {
                return ProxyGenericGet(dsData);
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetCPMeasures: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static DataSet GetCPDocOperationTypeOf()
        {
            DataSet dsData = new DataSet();
            dsData.Tables.Add("CPDoc_OperationTypeOf");
            try
            {
                return ProxyGenericGet(dsData);
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetCPDocOperationTypeOf: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static DataSet GetCPDocOperation(DataSet dsData)
        {
            dsData.Tables[0].TableName = "CPDoc_Operation";
            try
            {
                return ProxyGenericGet(dsData);
            }
            catch(Exception exc)
            {
                MessageBox.Show("GetCPDocOperation: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static DataSet SetCPDoc_Operation(DataSet dsData)
        {
            dsData.Tables[0].TableName = "CPDoc_Operation";
            try
            {
                return ProxyGenericSet(dsData, "Set");
            }
            catch(Exception exc)
            {
                MessageBox.Show("SetCPDoc_Operation: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static void SetCPDocRules(DataSet dsData)
        {
            try
            {
                ProxyGenericSet(dsData, "Set");
            }
            catch(Exception exc)
            {
                MessageBox.Show("SetCPDocRules: Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);				
            }
        }

		//Service.SetBulkCPDocRules(dsCPDocRules, PartID);
		public static void SetBulkCPDocRules(string iPartID, string CPDocID, string Rules, string Bulk)
		{
			DataSet dsIn = new DataSet();
			DataTable dtIn = dsIn.Tables.Add("CPDocRule_Bulk");
			dtIn.Columns.Add("CPDocID", System.Type.GetType("System.String"));
			dtIn.Columns.Add("PartID", System.Type.GetType("System.String"));
			dtIn.Columns.Add("CpDocRules", System.Type.GetType("System.String"));
			dtIn.Columns.Add("Bulk", System.Type.GetType("System.String"));
			DataRow row = dtIn.NewRow();
			dtIn.Rows.Add(row);
			row["CPDocID"] = CPDocID;
			row["PartID"] = iPartID;
			row["CpDocRules"] = Rules;
			row["Bulk"] = Bulk;
			DataSet dsOut = gemoDream.Service.ProxyGenericSet(dsIn, "Set");
		}


		#endregion CustomerProgram

		#region QB
		/// <summary>
		/// Adds customer to the qb
		/// </summary>
		/// <param name="dsCustomer">customer information</param>
		/// <returns>qb customer information</returns>
		/*
        public static DataSet QBAddCustomerLib(DataSet dsCustomer)
        {
            RequestProcessor2 rpRqProc = null;
            QBSessionManager smSessMgr = null;
            string sTicket = null;
            DataSet dsQBCustomerInfo = null;

            try
            {
                //int iUserId, iUserOfficeId, iDepartmentOfficeId;
                //if(!IsSessionActive(sSessionId, out iUserId, out iUserOfficeId, out iDepartmentOfficeId))
                //	throw new Exception(sSessionExpiredMsg);
				
                //Client.UpdateQBLog("smSessMgr = new QBSessionManager();");
                smSessMgr = new QBSessionManagerClass();
                rpRqProc = new RequestProcessor2Class();

                //smSessMgr.QBAuthPreferences.PutPersonalDataPref(ENPersonalDataPrefType.pdptNotNeeded);// .ApplicationLogin.SetEmpty();
                //smSessMgr.ConnectionTicket.SetEmpty();
                //smSessMgr.Language.SetEmpty();
                //smSessMgr.AppID.SetEmpty();
                //smSessMgr.AppVer.SetEmpty();

                //smSessMgr.ApplicationLogin.SetValue("Customer Add");
                //smSessMgr.ConnectionTicket.SetValue("0122701227");
                //smSessMgr.Language.SetValue("US");
                //smSessMgr.AppID.SetValue("GemoDream");
                //smSessMgr.AppVer.SetValue("1.0");

                //Client.UpdateQBLog("IMsgSetRequest iMsgRq = CreateCustomerAddRq(smSessMgr, dsCustomer);");
                IMsgSetRequest iMsgRq = CreateCustomerAddRq(smSessMgr, dsCustomer);
                //iMsgRq.ToXMLString();

                rpRqProc.OpenConnection2("",  "Customer Add", QBXMLRPConnectionType.remoteQBD);
                sTicket = rpRqProc.BeginSession("", QBFileMode.qbFileOpenDoNotCare);

                //Client.UpdateQBLog("smSessMgr.CommunicateOutOfProcess(false);");
                //smSessMgr.CommunicateOutOfProcess(false);

                //Client.UpdateQBLog("smSessMgr.OpenConnection2('', 'Customer Add', ENConnectionType.ctUnknown);");
                //smSessMgr.OpenConnection2("", "Customer Add", ENConnectionType.ctRemoteQBD);

                //Client.UpdateQBLog("smSessMgr.BeginSession('', ENOpenMode.omDontCare);");
                //smSessMgr.BeginSession("", ENOpenMode.omDontCare);

                //if(smSessMgr.ApplicationLogin.IsSet())
                //	ServiceLibrary.UpdateQBLog("ApplicationLogin="+smSessMgr.ApplicationLogin.GetValue().ToString());
                //if(smSessMgr.ConnectionTicket.IsSet())
                //	ServiceLibrary.UpdateQBLog("ConnectionTicket="+smSessMgr.ConnectionTicket.GetValue().ToString());
                //if(smSessMgr.Language.IsSet())
                //	ServiceLibrary.UpdateQBLog("Language="+smSessMgr.Language.GetValue().ToString());
                //if(smSessMgr.AppID.IsSet())
                //	ServiceLibrary.UpdateQBLog("AppID="+smSessMgr.AppID.GetValue().ToString());
                //if(smSessMgr.AppVer.IsSet())
                //	ServiceLibrary.UpdateQBLog("AppVer="+smSessMgr.AppVer.GetValue().ToString());
                //if(dsCustomer.Tables[0].Rows[0]["CustomerName"] != null)
                //	ServiceLibrary.UpdateQBLog("Name="+dsCustomer.Tables[0].Rows[0]["CompanyName"]+"("+dsCustomer.Tables[0].Rows.Count+")");

                //Client.UpdateQBLog("IMsgSetResponse iMsgRs = smSessMgr.DoRequests(iMsgRq);");
                //IMsgSetResponse iMsgRs;// = smSessMgr.DoRequests(iMsgRq);
                string sRs = rpRqProc.ProcessRequest(sTicket, iMsgRq.ToXMLString());
                //IMsgSetResponse iMsgRss = Convert.ChangeType(sRs, Convert.GetTypeCode(iMsgRs));

                //if (iMsgRs.ResponseList.GetAt(0).StatusCode != 0)
                //{
                //Client.UpdateQBLog("statuscode="+iMsgRs.ResponseList.GetAt(0).StatusCode);
                //throw new Exception(iMsgRs.ResponseList.GetAt(0).StatusMessage);
                //}
                
                //Client.UpdateQBLog("dsQBCustomerInfo = GetQBCustomerInfo(iMsgRs, dsCustomer, true);");
                dsQBCustomerInfo = GetQBCustomerInfo(sRs, dsCustomer, true);
            }
            catch(Exception eEx)
            {
                throw new Exception("Couldn't add customer into QB\n" + eEx.Message);
            }
            finally
            {
                /*if(smSessMgr != null)
                {
                    smSessMgr.EndSession();
                    smSessMgr.CloseConnection();
                    smSessMgr = null;
                }*//*
				if(rpRqProc!=null && sTicket!=null)
				{
					rpRqProc.EndSession(sTicket);
					rpRqProc.CloseConnection();
					rpRqProc = null;
				}			
			}

			return dsQBCustomerInfo;
		}

		*/
				   /// <summary>
				   /// Modifies customer in the qb
				   /// </summary>
				   /// <param name="dsCustomer">customer information</param>
		/*
        public static DataSet QBModifyCustomerLib(DataSet dsCustomer)
        {
            QBSessionManager smSessMgr = null;
            DataSet dsQBCustomerInfo = null;
            RequestProcessor2 rpRqProc = null;
            string sTicket = null;

            try
            {
                smSessMgr = new QBSessionManager();
                rpRqProc = new RequestProcessor2Class();

                IMsgSetRequest iMsgRq = CreateCustomerModRq(smSessMgr, dsCustomer);

                rpRqProc.OpenConnection2("",  "Customer Modify", QBXMLRPConnectionType.remoteQBD);
                sTicket = rpRqProc.BeginSession("", QBFileMode.qbFileOpenDoNotCare);
                string sRs = rpRqProc.ProcessRequest(sTicket, iMsgRq.ToXMLString());
                //smSessMgr.OpenConnection2("", "Customer Modify", ENConnectionType.ctRemoteQBD);
                //smSessMgr.BeginSession("", ENOpenMode.omDontCare);
                //IMsgSetResponse iMsgRs = smSessMgr.DoRequests(iMsgRq);

                //if (iMsgRs.ResponseList.GetAt(0).StatusCode != 0)
                //	throw new Exception(iMsgRs.ResponseList.GetAt(0).StatusMessage);

                dsQBCustomerInfo = GetQBCustomerInfo(sRs, dsCustomer, false);
                //dsQBCustomerInfo = GetQBCustomerInfo(iMsgRs, dsCustomer, false);
            }
            catch(Exception eEx)
            {
                throw new Exception("Couldn't modify customer in QB\n" + eEx.Message);
            }
            finally
            {
                if(rpRqProc!=null && sTicket!=null)
                {
                    rpRqProc.EndSession(sTicket);
                    rpRqProc.CloseConnection();
                    rpRqProc = null;
                }
            }

            return dsQBCustomerInfo;
        }

        */
		/// <summary>
		/// Adds invoice in the qb
		/// </summary>
		/// <param name="sBatchId_ItemCode"></param>
		/*
        public static void QBAddItemInvoiceLib(string sBatchId_ItemCode)
        {
            QBSessionManager smSessMgr = null;
            RequestProcessor2 rpRqProc = null;
            string sTicket = null;

            try
            {
                //DataSet dsInvoices = GetGroupInvoice(sSessionId, sGroupId_sGroupOfficeId);
                DataSet dsInvoices = GetItemInvoice(sSessionId, sBatchId_ItemCode);//(sSessionId, sGroupId_sGroupOfficeId);

                smSessMgr = new QBSessionManager();
                rpRqProc = new RequestProcessor2Class();

                IMsgSetRequest iMsgRq = CreateInvoiceAddRq(smSessMgr, dsInvoices);
				
                //smSessMgr.OpenConnection2("", "Invoice Add", ENConnectionType.ctRemoteQBD);
                //smSessMgr.BeginSession("", ENOpenMode.omDontCare);
                //IMsgSetResponse iMsgRs = smSessMgr.DoRequests(iMsgRq);
                rpRqProc.OpenConnection2("",  "Invoice Add", QBXMLRPConnectionType.remoteQBD);
                sTicket = rpRqProc.BeginSession("", QBFileMode.qbFileOpenDoNotCare);
                string sRs = rpRqProc.ProcessRequest(sTicket, iMsgRq.ToXMLString());
				

                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(sRs);
                XmlNodeList xNodeList = xDoc.GetElementsByTagName("InvoiceAddRs");

                foreach(XmlNode xNode in  xNodeList)
                {
                    string sStatusCode = xNode.Attributes.GetNamedItem("statusCode").Value;
                    if(sStatusCode != "0")
                    {
                        string sStatusMessage = xNode.Attributes.GetNamedItem("statusMessage").Value;
                        throw new Exception("QuickBooks responsed with code "+sStatusCode+"\n"+sStatusCode);
                        //continue;
                    }
                }
                //if (iMsgRs.ResponseList.GetAt(0).StatusCode != 0)
                //	throw new Exception(iMsgRs.ResponseList.GetAt(0).StatusMessage);
            }
            catch(Exception eEx)
            {
                throw new Exception("Couldn't add invoice into QB\n" + eEx.Message);
            }
            finally
            {
                if(rpRqProc!=null && sTicket!=null)
                {
                    rpRqProc.EndSession(sTicket);
                    rpRqProc.CloseConnection();
                    rpRqProc = null;
                }
            }
        }

        */
		/// <summary>
		/// Adds group invoice in the qb
		/// </summary>
		/// <param name="sBatchId_ItemCode"></param>
		/*
        public static void QBAddGroupInvoiceLib(string sGroupOfficeID_GroupID)
        {
            QBSessionManager smSessMgr = null;
            RequestProcessor2 rpRqProc = null;
            string sTicket = null;

            try
            {
                DataSet dsInvoices = GetGroupInvoice(sSessionId, sGroupOfficeID_GroupID);
                //DataSet dsInvoices = GetItemInvoice(sSessionId, sBatchId_ItemCode);//(sSessionId, sGroupId_sGroupOfficeId);

                smSessMgr = new QBSessionManager();
                rpRqProc = new RequestProcessor2Class();

                IMsgSetRequest iMsgRq = CreateInvoiceAddRq(smSessMgr, dsInvoices);
				
                //smSessMgr.OpenConnection2("", "Invoice Add", ENConnectionType.ctRemoteQBD);
                //smSessMgr.BeginSession("", ENOpenMode.omDontCare);
                //IMsgSetResponse iMsgRs = smSessMgr.DoRequests(iMsgRq);
                rpRqProc.OpenConnection2("",  "Invoice Add", QBXMLRPConnectionType.remoteQBD);
                sTicket = rpRqProc.BeginSession("", QBFileMode.qbFileOpenDoNotCare);
                string sRs = rpRqProc.ProcessRequest(sTicket, iMsgRq.ToXMLString());
				

                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(sRs);
                XmlNodeList xNodeList = xDoc.GetElementsByTagName("InvoiceAddRs");

                foreach(XmlNode xNode in  xNodeList)
                {
                    string sStatusCode = xNode.Attributes.GetNamedItem("statusCode").Value;
                    if(sStatusCode != "0")
                    {
                        string sStatusMessage = xNode.Attributes.GetNamedItem("statusMessage").Value;
                        throw new Exception("QuickBooks responsed with code "+sStatusCode+"\n"+sStatusCode);
                        //continue;
                    }
                }
                //if (iMsgRs.ResponseList.GetAt(0).StatusCode != 0)
                //	throw new Exception(iMsgRs.ResponseList.GetAt(0).StatusMessage);
            }
            catch(Exception eEx)
            {
                throw new Exception("Couldn't add invoice into QB\n" + eEx.Message);
            }
            finally
            {
                if(rpRqProc!=null && sTicket!=null)
                {
                    rpRqProc.EndSession(sTicket);
                    rpRqProc.CloseConnection();
                    rpRqProc = null;
                }
            }
        }

        */
		/// <summary>
		/// Creates customer add request for qb
		/// </summary>
		/// <param name="smSessMgr">session manager</param>
		/// <param name="dsCustomer">customer information</param>
		/// <returns>customer add request</returns>
		/*
        private static IMsgSetRequest CreateCustomerAddRq(QBSessionManager smSessMgr, DataSet dsCustomer)
        {
            string sFax, sPhone;
            ICustomerAdd iCustAdd;

            DataTable dtCustomer = dsCustomer.Tables["Customer"];
            IMsgSetRequest iMsgRq = smSessMgr.CreateMsgSetRequest("US", 3, 0);

            foreach(DataRow drCustomer in dtCustomer.Rows)
            {
                iCustAdd = iMsgRq.AppendCustomerAddRq();

                if(!Convert.IsDBNull(drCustomer["CompanyName"]))
                {
                    iCustAdd.Name.SetValue(drCustomer["CompanyName"].ToString());
                    iCustAdd.CompanyName.SetValue(drCustomer["CompanyName"].ToString());
                }
                if(!Convert.IsDBNull(drCustomer["Address1"]))
                    iCustAdd.BillAddress.Addr1.SetValue(drCustomer["Address1"].ToString());
                if(!Convert.IsDBNull(drCustomer["Address2"]))
                    iCustAdd.BillAddress.Addr2.SetValue(drCustomer["Address2"].ToString());
                if(!Convert.IsDBNull(drCustomer["City"]))
                    iCustAdd.BillAddress.City.SetValue(drCustomer["City"].ToString());
                if(!Convert.IsDBNull(drCustomer["Country"]))
                    iCustAdd.BillAddress.Country.SetValue(drCustomer["Country"].ToString());
                if(!Convert.IsDBNull(drCustomer["Zip1"]))
                    iCustAdd.BillAddress.PostalCode.SetValue(drCustomer["Zip1"].ToString());
                if(!Convert.IsDBNull(drCustomer["USStateName"]))
                    iCustAdd.BillAddress.State.SetValue(drCustomer["USStateName"].ToString());
                if(!Convert.IsDBNull(drCustomer["Email"]))
                    iCustAdd.Email.SetValue(drCustomer["Email"].ToString());
                if(!Convert.IsDBNull(drCustomer["CountryFaxCode"]) && !Convert.IsDBNull(drCustomer["Fax"]))
                {
                    sFax = "("+drCustomer["CountryFaxCode"].ToString()+")";
                    sFax += drCustomer["Fax"].ToString();
                    iCustAdd.Fax.SetValue(sFax);
                }
                if(!Convert.IsDBNull(drCustomer["CountryPhoneCode"]) && !Convert.IsDBNull(drCustomer["Phone"]))
                {
                    sPhone = "("+drCustomer["CountryPhoneCode"].ToString()+")";
                    sPhone += drCustomer["Phone"].ToString();
                    iCustAdd.Phone.SetValue(sPhone);
                }
                if(!Convert.IsDBNull(drCustomer["Account"]))
                    iCustAdd.AccountNumber.SetValue(drCustomer["Account"].ToString());
                iCustAdd.JobStartDate.SetValue(DateTime.Now);
            }

            return iMsgRq;
        }

        */
		/// <summary>
		/// Creates customer modify request for qb
		/// </summary>
		/// <param name="smSessMgr">session manager</param>
		/// <param name="dsCustomer">customer information</param>
		/// <returns>customer add request</returns>
		/*
        private static IMsgSetRequest CreateCustomerModRq(QBSessionManager smSessMgr, DataSet dsCustomer)
        {
            string sFax, sPhone;
            ICustomerMod iCustMod;

            DataTable dtCustomer = dsCustomer.Tables["Customer"];
            IMsgSetRequest iMsgRq = smSessMgr.CreateMsgSetRequest("US", 3, 0);

            foreach(DataRow drCustomer in dtCustomer.Rows)
            {
                iCustMod = iMsgRq.AppendCustomerModRq();

                if(!Convert.IsDBNull(drCustomer["QuickBookEditSequence"]))
                    iCustMod.EditSequence.SetValue(drCustomer["QuickBookEditSequence"].ToString());
                //Client.UpdateQBLog(drCustomer["QuickBookListID"].ToString());
                if(!Convert.IsDBNull(drCustomer["QuickBookListID"].ToString()))
                    iCustMod.ListID.SetValue(drCustomer["QuickBookListID"].ToString());
                if(!Convert.IsDBNull(drCustomer["CompanyName"]))
                {
                    iCustMod.Name.SetValue(drCustomer["CompanyName"].ToString());
                    iCustMod.CompanyName.SetValue(drCustomer["CompanyName"].ToString());
                }
                if(!Convert.IsDBNull(drCustomer["Account"]))
                    iCustMod.AccountNumber.SetValue(drCustomer["Account"].ToString());
                if(!Convert.IsDBNull(drCustomer["Email"]))
                    iCustMod.Email.SetValue(drCustomer["Email"].ToString());
                if(!Convert.IsDBNull(drCustomer["Address1"]))
                    iCustMod.BillAddress.Addr1.SetValue(drCustomer["Address1"].ToString());
                if(!Convert.IsDBNull(drCustomer["Address2"]))
                    iCustMod.BillAddress.Addr2.SetValue(drCustomer["Address2"].ToString());
                if(!Convert.IsDBNull(drCustomer["City"]))
                    iCustMod.BillAddress.City.SetValue(drCustomer["City"].ToString());
                if(!Convert.IsDBNull(drCustomer["Country"]))
                    iCustMod.BillAddress.Country.SetValue(drCustomer["Country"].ToString());
                if(!Convert.IsDBNull(drCustomer["Zip1"]))
                    iCustMod.BillAddress.PostalCode.SetValue(drCustomer["Zip1"].ToString());
                if(!Convert.IsDBNull(drCustomer["USStateName"]))
                    iCustMod.BillAddress.State.SetValue(drCustomer["USStateName"].ToString());
                if(!Convert.IsDBNull(drCustomer["CountryFaxCode"]) && !Convert.IsDBNull(drCustomer["Fax"]))
                {
                    sFax = "("+drCustomer["CountryFaxCode"].ToString()+")";
                    sFax += drCustomer["Fax"].ToString();
                    iCustMod.Fax.SetValue(sFax);
                }
                if(!Convert.IsDBNull(drCustomer["CountryPhoneCode"]) && !Convert.IsDBNull(drCustomer["Phone"]))
                {
                    sPhone = "("+drCustomer["CountryPhoneCode"].ToString()+")";
                    sPhone += drCustomer["Phone"].ToString();
                    iCustMod.Phone.SetValue(sPhone);
                }
                if(!Convert.IsDBNull(drCustomer["CreateDate"]))
                    iCustMod.JobStartDate.SetValue(Convert.ToDateTime(drCustomer["CreateDate"]));
            }

            return iMsgRq;
        }

        */
		/// <summary>
		/// Creates invoice add request for qb
		/// </summary>
		/// <param name="smSessMgr">session manager</param>
		/// <param name="dsInvoice">invoice information</param>
		/// <returns>invoice add reques</returns>
		/*		
                private static IMsgSetRequest CreateInvoiceAddRq(QBSessionManager smSessMgr, DataSet dsInvoices)
                {
                    IMsgSetRequest mrMsgRq = smSessMgr.CreateMsgSetRequest("US", 3, 0);
                    string sQBItem = ProxyGetServiceCfgParameter("qbItem");
                    string sDescription;
                    string sFullCode;

                    foreach(DataTable dtInvoice in dsInvoices.Tables)
                    {
                        if(dtInvoice.Rows.Count == 0)
                            continue;

                        DataRow drInvoice = dtInvoice.Rows[0];
                        IInvoiceAdd iInvAdd = mrMsgRq.AppendInvoiceAddRq();

                        if(!Convert.IsDBNull(drInvoice["CustomerListID"]))
                            iInvAdd.CustomerRef.ListID.SetValue(drInvoice["CustomerListID"].ToString());
                        //iInvAdd.CustomerRef.FullName.SetValue(textBox3.Text);
                        if(!Convert.IsDBNull(drInvoice["GroupCode"]))
                        {
                            sFullCode = GraderLib.GetCorrectCodeString(drInvoice["GroupCode"].ToString(), 5);
                            iInvAdd.PONumber.SetValue(sFullCode);
                        }
                        iInvAdd.DueDate.SetValue(DateTime.Now);
                        iInvAdd.IsToBePrinted.SetValue(true);
                        //iInvAdd.BillAddress.Addr1.SetValue(textBox5.Text);
                        //iInvAdd.BillAddress.Addr2.SetValue(textBox5.Text);
                        //iInvAdd.BillAddress.Addr3.SetValue(textBox5.Text);
                        //iInvAdd.BillAddress.Addr4.SetValue(textBox5.Text);
                        //iInvAdd.BillAddress.City.SetValue(textBox6.Text);
                        //iInvAdd.BillAddress.State.SetValue(textBox7.Text);
                        //iInvAdd.BillAddress.PostalCode.SetValue(textBox8.Text);
                        //iInvAdd.BillAddress.Country.SetValue(textBox9.Text);

                        foreach(DataRow drInvoiceLine in dtInvoice.Rows)
                        {
                            IORInvoiceLineAdd iInvLineAdd = iInvAdd.ORInvoiceLineAddList.Append();
                            iInvLineAdd.InvoiceLineAdd.ItemRef.FullName.SetValue(sQBItem); //item name
                            if(!Convert.IsDBNull(drInvoiceLine["Price"]))
                                iInvLineAdd.InvoiceLineAdd.Amount.SetValue(Convert.ToDouble(drInvoiceLine["Price"]));
                            iInvLineAdd.InvoiceLineAdd.ServiceDate.SetValue(DateTime.Now);
                            if(!Convert.IsDBNull(drInvoiceLine["OperationTypeGroupName"]))
                            {
                                sDescription = drInvoiceLine["OperationTypeGroupName"].ToString() + " for ";
                                if(!Convert.IsDBNull(drInvoiceLine["GroupCode"]))
                                {
                                    sFullCode = GraderLib.GetCorrectCodeString(drInvoiceLine["GroupCode"].ToString(), 5);
                                    sDescription += sFullCode + "." + sFullCode;
                                }
                                if(!Convert.IsDBNull(drInvoiceLine["BatchCode"]))
                                {
                                    sFullCode = GraderLib.GetCorrectCodeString(drInvoiceLine["BatchCode"].ToString(), 3);
                                    sDescription += "." + sFullCode;
                                }
                                if(!Convert.IsDBNull(drInvoiceLine["ItemCode"]))
                                {
                                    sFullCode = GraderLib.GetCorrectCodeString(drInvoiceLine["ItemCode"].ToString(), 2);
                                    sDescription += "." + sFullCode;
                                }
                                iInvLineAdd.InvoiceLineAdd.Desc.SetValue(sDescription);
                            }
                        }
                    }

                    return mrMsgRq;
                }

        */
		/// <summary>
		/// Gets group invoice from the db
		/// </summary>
		/// <returns>group invoice</returns>
		private static DataSet GetGroupInvoice(string sSessionId, string sGroupOfficeID_GroupID)
        {
            DataSet dsPrms = new DataSet();
            DataTable dtPrms = dsPrms.Tables.Add("GroupInvoiceTypeEx");
            dsPrms = ProxyGenericGet(dsPrms);
            dtPrms = dsPrms.Tables[0];
            dtPrms.TableName = "GroupInvoice";
            dtPrms.Rows.Add(new object[] {});

            dtPrms.Rows[0]["GroupOfficeID_GroupID"] = sGroupOfficeID_GroupID;
            dsPrms = ProxyGenericGet(dsPrms);

            return dsPrms;
        }
        /// <summary>
        /// Gets item invoice from the db
        /// </summary>
        /// <returns>item invoice</returns>
        private static DataSet GetItemInvoice(string sSessionId, string sBatchId_ItemCode)
        {
            DataSet dsPrms = new DataSet();
            DataTable dtPrms = dsPrms.Tables.Add("ItemInvoiceTypeEx");
            dsPrms = ProxyGenericGet(dsPrms);
            dtPrms = dsPrms.Tables[0];
            dtPrms.TableName = "ItemInvoice";
            dtPrms.Rows.Add(new object[] {});

            dtPrms.Rows[0]["BatchID_ItemCode"] = sBatchId_ItemCode;
            dsPrms = ProxyGenericGet(dsPrms);

            return dsPrms;
        }
		
        /// <summary>
        /// Gets Qb customer info
        /// </summary>
        /// <param name="iMsgRs">response message</param>
        /// <returns>QB customer information (ListID, EditSequence)</returns>
        /*
        private static DataSet GetQBCustomerInfo(IMsgSetResponse iMsgRs, DataSet dsQBCustomer, bool bIsAdd)
        {
            //Client.UpdateQBLog("responce="+iMsgRs);
            //Client.UpdateQBLog("IResponseList iRsList = iMsgRs.ResponseList;");
            IResponseList iRsList = iMsgRs.ResponseList;

            //Client.UpdateQBLog("rslistcount="+iRsList.Count);
            //Client.UpdateQBLog("statuscode="+iRsList.GetAt(0).StatusCode);
            //Client.UpdateQBLog("statusmsg="+iRsList.GetAt(0).StatusMessage);
            //iRsList.GetAt(i).StatusCode;

            //Client.UpdateQBLog("DataTable dtQBCustomer = dsQBCustomer.Tables['Customer']");
            DataTable dtQBCustomer = dsQBCustomer.Tables["Customer"];
            DataRow drQBCustomer;

            ICustomerRet iCust;
            IResponse iRs;
            IResponseType iRsType;
            //Client.UpdateQBLog("iRsList.Count="+iRsList.Count);
            for(int i=0; i<iRsList.Count; i++)
            {
                iRs = iRsList.GetAt(i);
                if(iRs.StatusCode != 0)
                    continue;

                iCust = (ICustomerRet)iRs.Detail;
                iRsType = iRs.Type;
				
                //Client.UpdateQBLog("iRsType.GetValue() != Convert.ToInt32(ENResponseType.rtCustomerAddRs");
                if((iRsType.GetValue()!=Convert.ToInt32(ENResponseType.rtCustomerAddRs) && bIsAdd) ||
                    (iRsType.GetValue()!=Convert.ToInt32(ENResponseType.rtCustomerModRs) && !bIsAdd))
                    continue;
                //throw new Exception("Customer response type is incorrect");

                drQBCustomer = dtQBCustomer.Rows[i];
                if(iCust.ListID != null)
                    drQBCustomer["QuickBookListID"] = iCust.ListID.GetValue();
                if(iCust.EditSequence != null)	
                    drQBCustomer["QuickBookEditSequence"] = iCust.EditSequence.GetValue();
            }

            return dsQBCustomer;
        }

        */
        /// <summary>
        /// Gets Qb customer info
        /// </summary>
        /// <param name="iMsgRs">response message</param>
        /// <returns>QB customer information (ListID, EditSequence)</returns>
        private static DataSet GetQBCustomerInfo(string sMsgRs, DataSet dsQBCustomer, bool bIsAdd)
        {
            DataTable dtQBCustomer = dsQBCustomer.Tables["Customer"];
            DataRow drQBCustomer;

            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(sMsgRs);
            XmlNodeList xNodeList = xDoc.GetElementsByTagName("CustomerAddRs");

            string sRsStatus = "";
            string sRsStatusMsg = "";
            foreach(XmlNode xNode in xNodeList)
            {
                XmlNamedNodeMap xNodeMap = xNode.Attributes;
                sRsStatus = xNodeMap.GetNamedItem("statusCode").Value;

                if(sRsStatus != "0")
                {
                    sRsStatusMsg = xNodeMap.GetNamedItem("statusMessage").Value;
                    throw new Exception("QuickBooks responsed with code "+sRsStatus+"\n"+sRsStatusMsg);
                    //continue;
                }
                for(int i=0; i<xNode.ChildNodes.Count; i++)
                {
                    XmlNode xChild = xNode.ChildNodes[i];
                    drQBCustomer = dtQBCustomer.Rows[i];

                    if(xChild.Name == "CustomerRet")
                    {
                        foreach(XmlNode xChild2 in xChild.ChildNodes)
                        {
                            if(xChild2.Name == "ListID")
                                drQBCustomer["QuickBookListID"] = xChild2.InnerText;
                            if(xChild2.Name == "EditSequence")
                                drQBCustomer["QuickBookEditSequence"] = xChild2.InnerText;
                        }
                    }
                }
            }

            return dsQBCustomer;
        }
#endregion

#region mvs

        public static DataSet GetDocs(string sCPOfficeID, string sCPID)
        {
            try
            {
                DataSet dsIn = new DataSet();
                DataTable dtIn = dsIn.Tables.Add("DocsByCP");
                dtIn.Columns.Add("CPID", System.Type.GetType("System.String"));
                dtIn.Columns.Add("CPOfficeID", System.Type.GetType("System.String"));

                DataRow row = dtIn.NewRow();
                row["CPID"] = sCPID;
                row["CPOfficeID"] = sCPOfficeID;
				
                dtIn.Rows.Add(row);
                DataSet dsOut = Service.ProxyGenericGet(dsIn);//Procedure dbo.spGetDocsByCP
                return dsOut;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't load documents. Reason: " + ex.ToString(),
                    "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return null;
        }

        public static DataSet GetCurrentDocs(string sCPOfficeID, string sCPID)
        {
            try
            {
                DataSet dsIn = new DataSet();
                DataTable dtIn = dsIn.Tables.Add("CurrentDocsByCP");
                dtIn.Columns.Add("CPID", System.Type.GetType("System.String"));
                dtIn.Columns.Add("CPOfficeID", System.Type.GetType("System.String"));

                DataRow row = dtIn.NewRow();
                row["CPID"] = sCPID;
                row["CPOfficeID"] = sCPOfficeID;
				
                dtIn.Rows.Add(row);
                DataSet dsOut = Service.ProxyGenericGet(dsIn);
                return dsOut;
            }
            catch (Exception ex)
            {
                MessageBox.Show("GetCurrentDocs. Can't load documents. Reason: " + ex.ToString(),
                    "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return null;
        }
        public static DataSet GetImpExpInfo(string sOfficeID)
        {
            try
            {
                DataSet dsImpEx  = new DataSet();
                DataTable table= dsImpEx.Tables.Add("ImpExInfo");
                table.Columns.Add("OfficeID",System.Type.GetType("System.Int16"));
                DataRow row = table.NewRow();

                if (sOfficeID == null) 
                    row["OfficeID"] = DBNull.Value;
                else
                    row["OfficeID"] = sOfficeID;

                table.Rows.Add(row);
                DataSet dsOut = Service.ProxyGenericGet(dsImpEx);
                return dsOut;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't load import/export info: " + ex.ToString(),
                    "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return null;
        }
        public static DataSet GetDocumentsPredefined(string sItemTypeID, string sDocumentTypeCode)
        {
            try
            {
                DataSet dsIn = new DataSet();
                DataTable dtIn = dsIn.Tables.Add("DocumentsPredefined");
                dtIn.Columns.Add("ItemTypeID", System.Type.GetType("System.String"));
                dtIn.Columns.Add("DocumentTypeCode", System.Type.GetType("System.Int16"));

                DataRow row = dtIn.NewRow();
                row["ItemTypeID"] = sItemTypeID;
                row["DocumentTypeCode"] = sDocumentTypeCode;
                //sItemTypeID;
				
                dtIn.Rows.Add(row);
                DataSet dsOut = Service.ProxyGenericGet(dsIn);
                return dsOut;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't load predefined documents. Reason: " + ex.ToString(),
                    "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return null;
        }

        public static string GetPath2Picture(string sItemTypeID)
        {
            try
            {
                DataSet dsIn = new DataSet();
                DataTable dtIn = dsIn.Tables.Add("ItemType");
                dtIn.Columns.Add("ItemTypeID", System.Type.GetType("System.String"));

                DataRow row = dtIn.NewRow();
                row["ItemTypeID"] = sItemTypeID;
				
                dtIn.Rows.Add(row);
                DataSet dsOut = Service.ProxyGenericGet(dsIn);

                string sPath2Picture = dsOut.Tables[0].Rows[0]["Path2Picture"].ToString();

                //gemoDream.Service.debug_DiaspalyDataSet(dsOut);
                //return dsOut;
                return sPath2Picture;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't load path to picture. Reason: " + ex.ToString(),
                    "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return null;
        }

        public static int GetDocumentsCount(string sCPOfficeID, string sCPID)
        {
            try
            {
                DataSet dsIn = new DataSet();
                DataTable dtIn = dsIn.Tables.Add("CustomerProgramDocumentsCount");

                dtIn.Columns.Add("CPOfficeID", System.Type.GetType("System.String"));
                dtIn.Columns.Add("CPID", System.Type.GetType("System.String"));

                DataRow row = dtIn.NewRow();

                row["CPOfficeID"] = sCPOfficeID;
                row["CPID"] = sCPID;
								
                dtIn.Rows.Add(row);
                DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);
                string sDocumentsCount = dsOut.Tables[0].Rows[0]["DocumentsCount"].ToString();

                int iDocumentsCount = System.Convert.ToInt32(sDocumentsCount, 10);
                return iDocumentsCount;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't get documents count. Reason: " + ex.ToString(),
                    "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return 1;
        }

        public static DataSet GetDocument(string sDocumentID)
        {
            try
            {
                DataSet dsIn = new DataSet();
                DataTable dtIn = dsIn.Tables.Add("Document");

                dtIn.Columns.Add("DocumentID", System.Type.GetType("System.String"));

                DataRow row = dtIn.NewRow();

                row["DocumentID"] = sDocumentID;
								
                dtIn.Rows.Add(row);
                DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);
                return dsOut;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't get document. Reason: " + ex.ToString(),
                    "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return null;
        }

        public static DataSet GetDocumentValues(string sDocumentID)
        {
            try
            {
                DataSet dsIn = new DataSet();
                DataTable dtIn = dsIn.Tables.Add("DocumentValue");

                dtIn.Columns.Add("DocumentID", System.Type.GetType("System.String"));

                DataRow row = dtIn.NewRow();

                row["DocumentID"] = sDocumentID;
								
                dtIn.Rows.Add(row);
                DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);//Procedure dbo.spGetDocumentValue
                return dsOut;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't get document values. Reason: " + ex.ToString(),
                    "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return null;
        }

        public void PrintCallback()
        {

        }

        public static void MakeTextFile3(DataSet ds, string sDocId)
        {
            try
            {
                //srv.MakeTextFile3(sSessionId, ds, sDocId, null, null);
                srv.AsincPrint(sSessionId, ds, sDocId);
            }
            catch(Exception eEx)
            {
                if(eEx.Message.IndexOf("Session doesn't exist or expired. Retry to log on") == -1)
                    throw eEx;
				
                ReLoginForm rlLogin = new ReLoginForm();
                rlLogin.ShowDialog();
                srv.AsincPrint(sSessionId, ds, sDocId);
                //srv.MakeTextFile3(sSessionId, ds, sDocId);
				
                //dsReturnData = ProxyGenericGet(dsParameters);
            }

            //int ijk = 0;
            //ijk += 1;
        }

        public static string GetItemTypeIDByBatchID(string sBatchID)
        {
            try
            {
                DataSet dsIn = new DataSet();
                DataTable dtIn = dsIn.Tables.Add("Batch");

                dtIn.Columns.Add("BatchID", System.Type.GetType("System.String"));

                DataRow row = dtIn.NewRow();

                row["BatchID"] = sBatchID;
								
                dtIn.Rows.Add(row);
                DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);
                string sItemTypeID = dsOut.Tables[0].Rows[0]["ItemTypeID"].ToString();
                return sItemTypeID;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't get item type ID. Reason: " + ex.ToString(),
                    "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return null;
        }
		
        public static DataSet GetDocumentIDByBatchID(string sBatchID)
        {
            try
            {
                DataSet dsIn = new DataSet();
                DataTable dtIn = dsIn.Tables.Add("DocumentTypeCodeByBatchID");

                dtIn.Columns.Add("BatchID", System.Type.GetType("System.String"));

                DataRow row = dtIn.NewRow();

                row["BatchID"] = sBatchID;
								
                dtIn.Rows.Add(row);
                DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);
                return dsOut;
                //string sDocumentID = dsOut.Tables[0].Rows[0]["DocumentID"].ToString();
                //return sDocumentID;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Can't get document ID. Reason: " + ex.ToString(),
                //	"Internal error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return null;
        }
        public static DataSet GetDocumentIDByOperationTypeID(string OperationTypeOfficeID)
        {
            try
            {
                DataSet dsIn = new DataSet();
                DataTable dtIn = dsIn.Tables.Add("DocumentIDByOperationTypeID");

                dtIn.Columns.Add("OperationTypeOfficeID", System.Type.GetType("System.String"));

                DataRow row = dtIn.NewRow();

                row["OperationTypeOfficeID"] = OperationTypeOfficeID;
								
                dtIn.Rows.Add(row);
                DataSet dsOut = ProxyGenericGet(dsIn);
                return dsOut;
                //string sDocumentID = dsOut.Tables[0].Rows[0]["DocumentID"].ToString();
                //return sDocumentID;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Can't get document ID. Reason: " + ex.ToString(),
                //	"Internal error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return null;
        }

        public static DataSet GetPartTypes()
        {
            try 
            {
                DataSet dsIn = new DataSet();
                DataTable dtIn = dsIn.Tables.Add("PartTypes");
                DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);
                return dsOut;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't get part types. Reason: " + ex.ToString(),
                    "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return null;
        }

        private static bool IsFreeInformation(string s)
        {
            if (s.StartsWith("{"))
                return true;
            return false;
        }

        private static string DelimeterFilter(string s)
        {
            if (s.Equals("/"))
                return "^ / ";
            if (s.Equals("x"))
                return "^ x ";
            if (s.Equals("*"))
                return "^ * ";
            if (s.Equals(" "))
                return  "^ ";
            if (s.Equals("  "))
                return  "^  ";
            if (s.Equals("   "))
                return  "^   ";
            if (s.Equals("    "))
                return  "^    ";
            if (s == null || s.Length == 0)
                return s;
            //string s2 = s;
            /*
            if (IsFreeInformation(s))
                s2 = FreeInformationFilter(s);
            else
                s2 = String.Format("[{0}]", s);
            */
            /*
            if (!s.StartsWith("["))
            {
                s2 = String.Format("{{{0}}}", s);
            }
            */
            return s;
        }

        public class XMLData
        {
            public string sReportGroup;
            public string sItemPrefix;
            //public string sReportName;
            public string sFileName;
            public string sPicture;
            public bool UseVVN;
            public string sBarCode;
            public bool UseDate;
        }

        /*
        public static bool FreeInformation(string s)
        {
            if (s == null)
                return true;
            if (s.StartsWith("{"))
                return true;
            return false;
        }
        */

        public static string FreeInformationFilter(string s)
        {
            if (s.StartsWith("{"))
            {
                string t = s.Substring(1, s.Length - 2);
                return t;
            }
            return s;
        }

        public static string GetItemContainerName(string sItemTypeID)
        {
            DataSet dsParts = new DataSet();
            dsParts.Tables.Add(Service.GetParts(sItemTypeID));
            DataRow[] rows = dsParts.Tables[0].Select("PartTypeID=15");
            if (rows.Length == 0)
                return "Item Container name not found";
            string sItemContainerName=rows[0]["Name"].ToString();
            return sItemContainerName;
        }

        public static void SaveXML(string sReportName, string sItemContainerName, XMLData data, DataSet dsMeasures, DataSet dsDocumentValues)
        {
			XmlTextWriter xwriter = new XmlTextWriter(sReportName, System.Text.Encoding.Unicode)
			{
				Formatting = System.Xml.Formatting.Indented,
				Indentation = 0
			};

			xwriter.WriteStartDocument(false);
			
            xwriter.WriteStartElement("Report");

            //string s = "[ID_Card]";
            string s;
            xwriter.WriteStartElement("Report_group");
            xwriter.WriteString(data.sReportGroup);
            xwriter.WriteEndElement();

            //s = "H";
            xwriter.WriteStartElement("ItemPrefix");
            xwriter.WriteString(data.sItemPrefix);
            xwriter.WriteEndElement();

            xwriter.WriteStartElement("File_Name");
            //string sFileName = 
            //"[C:\\Reports\\CorelFiles\\IDXtemplate_8_19.cdr]";
            xwriter.WriteString(data.sFileName);
            xwriter.WriteEndElement();

            xwriter.WriteStartElement("Pictures");

            xwriter.WriteStartElement("Picture");
            //sPicture = "путь";
            //xwriter.WriteString(data.sPicture);

            //string sItemContainerPartName = null;
            //dsMeasures.Tables[0].Select("MeasureCode="

            s = String.Format("[{0}.{1}]", sItemContainerName, "Path2Picture");
            //xwriter.WriteString("[Item Container.Path2Picture]");
            xwriter.WriteString(s);
            xwriter.WriteEndElement();

            xwriter.WriteEndElement();

            xwriter.WriteStartElement("Shapes");

            if (dsMeasures != null && dsMeasures.Tables.Count != 0)
            {
                foreach (DataRow row in dsMeasures.Tables[0].Rows)
                {
                    if (row["MeasureID"].ToString().Equals("8")) // Shape (cut)
                    {
                        xwriter.WriteStartElement("Shape");
                        //string sShape = "[diamond.ShapePath2Drawing]";
                        //string sShape = String.Format("[{0}.{1}]", row["PartName"], row["MeasureName"]);
                        // ShapePath2Drawing
                        string sShape = String.Format("[{0}.{1}]", row["PartName"], "ShapePath2Drawing");
                        xwriter.WriteString(sShape);
                        xwriter.WriteEndElement();
                    }
                }
            }


            xwriter.WriteEndElement();

            xwriter.WriteStartElement("Logos");
            xwriter.WriteStartElement("Logo");
            string sLogo = "[diamond.logo_file]";
            xwriter.WriteString(sLogo);
            xwriter.WriteEndElement();
            xwriter.WriteEndElement();


            if (data.UseVVN)
            {
                xwriter.WriteStartElement("Virtual_Vault_Number");

                //string sVVN = "[Item Container.Virtual Vault Number]";
                string sVVN = String.Format("[{0}.{1}]", sItemContainerName, "Virtual Vault Number");
                xwriter.WriteString(sVVN);
                xwriter.WriteEndElement();
            }

            xwriter.WriteStartElement("BarCode");
			
            if (data.sBarCode == null || data.sBarCode.Length == 0)
                //data.sBarCode = "[Item Container.Report Number]";
                data.sBarCode = String.Format("[{0}.{1}]", sItemContainerName, "Report Number");
            xwriter.WriteString(data.sBarCode);
            xwriter.WriteEndElement();

            xwriter.WriteStartElement("ReportNumber");
			
            string sReportNumber = String.Format("[{0}.{1}]", sItemContainerName, "Item Number");
            xwriter.WriteString(sReportNumber);
            xwriter.WriteEndElement();

            if (data.UseDate)
            {
                xwriter.WriteStartElement("Date");
                s = "Date";
                //s = "[Date]";
                xwriter.WriteString(s);
                xwriter.WriteEndElement();
            }

            xwriter.WriteStartElement("Titles");
            foreach (DataRow row in dsDocumentValues.Tables[0].Rows)
            {
                xwriter.WriteStartElement("Title");
                s = row["Title"].ToString();
                if(s.Length != 0)
                {
                    xwriter.WriteString(s);
                    xwriter.WriteEndElement();
                    xwriter.WriteStartElement("Title");
                }
                s = "^LF";
                xwriter.WriteString(s);
                xwriter.WriteEndElement();
            }
            xwriter.WriteEndElement();

            xwriter.WriteStartElement("Attributes");
            string s1;
            //char[] chDel = {']', '['};
            foreach (DataRow row in dsDocumentValues.Tables[0].Rows)
            {
                s1 = row["Value"].ToString();

                Regex reg = new Regex("(\\[[^]]*\\])|([^\\[\\]]*)");
                //string[] ss = reg.Split(s1);
                MatchCollection mc = reg.Matches(s1);
                //string[] ss = s1.Split(chDel);
                string   s2;
                foreach (Match m in mc)
                    //for (int i = 0; i < ss.Length; i++)
                {
                    s2 = DelimeterFilter(m.Value);
                    //DelimeterFilter(ss[i].ToString());
                    if (s2.Length != 0)
                    {
                        string s3 = s2;
                        xwriter.WriteStartElement("Attribute");
                        xwriter.WriteString(s3);
                        xwriter.WriteEndElement();
                    }
                }

                s = row["Unit"].ToString();
                if (s.Length != 0)
                {
                    xwriter.WriteStartElement("Attribute");
                    //xwriter.WriteAttributeString("xml", "space", null, "preserve");
                    //string temp = String.Format("{{{0}}}", s);
                    if (s.StartsWith(" "))
                        xwriter.WriteString(s);
                    else
                        xwriter.WriteString(" " + s);
                    xwriter.WriteEndElement();
                }

                xwriter.WriteStartElement("Attribute");
                s = "^LF";
                xwriter.WriteString(s);
                xwriter.WriteEndElement();
            }
            xwriter.WriteEndElement();

            xwriter.WriteStartElement("Comments");
            //s = "[Item container.CPComment]";
            s = String.Format("[{0}.{1}]", sItemContainerName, "CPComment");
            xwriter.WriteString(s);
            xwriter.WriteEndElement();

            xwriter.WriteStartElement("Descriptions");
            //s = "[Item container.CPDescription]";
            s = String.Format("[{0}.{1}]", sItemContainerName, "CPDescription");
            xwriter.WriteString(s);
            xwriter.WriteEndElement();

            xwriter.WriteEndElement();

            xwriter.Close();
        }


        public static string GetBatchByCode(string sGroupCode, string sBatchCode)
        {
            DataSet dsIn = new DataSet();
            dsIn.Tables.Add("BatchByCodeTypeEx");
            dsIn = gemoDream.Service.ProxyGenericGet(dsIn);
            dsIn.Tables[0].TableName = "BatchByCode";
            dsIn.Tables[0].Rows.Add(dsIn.Tables[0].NewRow());
            dsIn.Tables[0].Rows[0]["GroupCode"] = sGroupCode;
            dsIn.Tables[0].Rows[0]["BatchCode"] = sBatchCode;
            DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);
            string sBatchID = null;
            if (dsOut.Tables.Count > 0 && dsOut.Tables[0].Rows.Count > 0 && sBatchCode.Trim() != "")
                sBatchID = dsOut.Tables[0].Rows[0]["BatchID"].ToString();
            return sBatchID;
        }
 
        public static string GetGroupIDByCode(string sGroupCode)
        {
            DataSet dsIn = new DataSet();
            dsIn.Tables.Add("GroupByCodeTypeEx");
            dsIn = gemoDream.Service.ProxyGenericGet(dsIn);
            dsIn.Tables[0].TableName = "GroupByCode";
            dsIn.Tables[0].Rows.Add(dsIn.Tables[0].NewRow());
            dsIn.Tables[0].Rows[0]["GroupCode"] = sGroupCode;
            DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);
            string sGroupID = null;
            if (dsOut.Tables.Count > 0 && dsOut.Tables[0].Rows.Count > 0)
                sGroupID = dsOut.Tables[0].Rows[0]["GroupID"].ToString();
            return sGroupID;
        }

        public static string GetGroupIDByCode1(string sGroupCode)
        {
            DataSet dsIn = new DataSet();
            dsIn.Tables.Add("GroupByCodeTypeEx");
            dsIn = gemoDream.Service.ProxyGenericGet(dsIn);
            dsIn.Tables[0].TableName = "GroupByCode";
            dsIn.Tables[0].Rows.Add(dsIn.Tables[0].NewRow());
            dsIn.Tables[0].Rows[0]["GroupCode"] = sGroupCode;
            DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);
            string sGroupID = null;
            if (dsOut.Tables.Count > 0 && dsOut.Tables[0].Rows.Count > 0)
                sGroupID = dsOut.Tables[0].Rows[0]["GroupOfficeID_GroupID"].ToString();
            return sGroupID;
        }

        public static DataSet GetGroupByCode(string sGroupCode)
        {
            DataSet dsIn = new DataSet();
            dsIn.Tables.Add("GroupByCodeTypeEx");
            dsIn = gemoDream.Service.ProxyGenericGet(dsIn);
            dsIn.Tables[0].TableName = "GroupByCode";
            dsIn.Tables[0].Rows.Add(dsIn.Tables[0].NewRow());
            dsIn.Tables[0].Rows[0]["GroupCode"] = sGroupCode;
            DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);
            //			string sGroupID = null;
            //			if (dsOut.Tables.Count > 0 && dsOut.Tables[0].Rows.Count > 0)
            //				sGroupID = dsOut.Tables[0].Rows[0]["GroupID"].ToString();
            return dsOut;
        }

        public static string GetItemsNum(string sGroupCode)
        {
            DataSet dsIn = new DataSet();
            dsIn.Tables.Add("GroupByCodeTypeEx");
            dsIn = gemoDream.Service.ProxyGenericGet(dsIn);
            dsIn.Tables[0].TableName = "GroupByCode";
            dsIn.Tables[0].Rows.Add(dsIn.Tables[0].NewRow());
            dsIn.Tables[0].Rows[0]["GroupCode"] = sGroupCode;
            DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);
            string sItemsQuantity = null;
            if (dsOut.Tables.Count > 0 && dsOut.Tables[0].Rows.Count > 0)
                sItemsQuantity = dsOut.Tables[0].Rows[0]["ItemsQuantity"].ToString();
            return sItemsQuantity;
        }

        public static string GetShapeCodeByItemCode(string sGroupCode, string sBatchCode,
            string sItemCode)
        {
            DataSet dsIn = new DataSet();
            dsIn.Tables.Add("ShapeCodeByItemCode");
            dsIn.Tables[0].Columns.Add("GroupCode", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("BatchCode", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("ItemCode", System.Type.GetType("System.String"));
            dsIn.Tables[0].Rows.Add(dsIn.Tables[0].NewRow());
            dsIn.Tables[0].Rows[0]["GroupCode"] = sGroupCode;
            dsIn.Tables[0].Rows[0]["BatchCode"] = sBatchCode;
            dsIn.Tables[0].Rows[0]["ItemCode"] = sItemCode;
            DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);
            string sShapeCode = null;
            if (dsOut.Tables.Count != 0 && dsOut.Tables[0].Rows.Count != 0)
                sShapeCode = dsOut.Tables[0].Rows[0]["ValueCode"].ToString();
            return sShapeCode;
        }
        /*
            public static DataSet GetPartTypes()
            {
                try
                {
                    DataSet dsIn = new DataSet();
                    DataTable dtIn = dsIn.Tables.Add("PartTypes");
                    //DataRow row = dtIn.NewRow();
                    //dtIn.Rows.Add(row);
                    DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);
                    return dsOut;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Can't load part types. Reason: " + ex.ToString(),
                        "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            */

        public static string SavePartType(string sItemParentID, string sItemPartName, string sPath2Icon, 
            string sPath2Picture, string sPartTypeID, string sItemContainerName,
            string sItemTypeID)
        {
			
            //	spSetPartType
            //	@ParentPartID dnSmallID, @PartName dsName, @Path2Drawing dsPath, @Path2Picture dsPath, 
            //	@PartLegend dsName,	@ShapeID dnSmallID, @PartTypeID int, @PartID int, 
            //	@AuthorID dnSmallID, @AuthorOfficeID dnTinyID, 
            //	@ExpireDate ddDate, @ItemTypeID dnSmallID)

            DataSet dsIn = new DataSet();
            dsIn.Tables.Add("PartType");
            dsIn.Tables[0].Columns.Add("ParentPartID", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("PartName", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("Path2Drawing", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("Path2Picture", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("PartLegend", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("ItemContainerName", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("ShapeID", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("PartTypeID", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("PartID", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("ExpireDate", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("ItemTypeID", System.Type.GetType("System.String"));
            //dsIn.Tables[0].Columns.Add("CurrentOfficeID", System.Type.GetType("System.String"));

            dsIn.Tables[0].Rows.Add(dsIn.Tables[0].NewRow());
            //dsIn.Tables[0].Rows[0]["ParentPartID"] = sItemParentID.Length == 0 ? DBNull.Value : sItemParentID;
            if (sItemParentID.Length == 0)
                dsIn.Tables[0].Rows[0]["ParentPartID"] = DBNull.Value;
            else
                dsIn.Tables[0].Rows[0]["ParentPartID"] = sItemParentID;
            dsIn.Tables[0].Rows[0]["PartName"] = sItemPartName;
            dsIn.Tables[0].Rows[0]["Path2Drawing"] = sPath2Icon;
            dsIn.Tables[0].Rows[0]["Path2Picture"] = sPath2Picture;
            dsIn.Tables[0].Rows[0]["PartLegend"] = DBNull.Value;
            dsIn.Tables[0].Rows[0]["ShapeID"] = DBNull.Value;
            dsIn.Tables[0].Rows[0]["PartTypeID"] = sPartTypeID;
            dsIn.Tables[0].Rows[0]["ItemContainerName"] = sItemContainerName;
            //DBNull.Value;
            dsIn.Tables[0].Rows[0]["PartID"] = DBNull.Value;
            dsIn.Tables[0].Rows[0]["ExpireDate"] = DBNull.Value;
            dsIn.Tables[0].Rows[0]["ItemTypeID"] = sItemTypeID;
            //dsIn.Tables[0].Rows[0]["CurrentOfficeID"] = sBatchCode;
            DataSet dsOut = gemoDream.Service.ProxyGenericSet(dsIn, "Set");
            string sItemID = dsOut.Tables[0].Rows[0]["ID"].ToString();
            return sItemID;
        }

        public static string SaveItemType(string sItemTypeGroupID,
            string sItemTypeName, string sPath2Icon,
            string sPath2Picture, string sDefaultCPID,
            string sDefaultCPOfficeID)
        {
			
            //	spSetItemType
            //	@ItemTypeGroupID dnSmallID, @ItemTypeName dsName, @Path2Icon dsPath, @Path2Picture dsPath, 
            //	@AuthorID dnSmallID, @AuthorOfficeID dnTinyID,
            //	@DefaultCPID dnID, @DefaultCPOfficeID dnTinyID, @ExpireDate ddDate, @CurrentOfficeID dnTinyID
            //	@ItemTypeID dsSmallID
			
            DataSet dsIn = new DataSet();
            dsIn.Tables.Add("ItemType");
            dsIn.Tables[0].Columns.Add("ItemTypeGroupID", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("ItemTypeName", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("Path2Icon", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("Path2Picture", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("DefaultCPID", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("DefaultCPOfficeID", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("ExpireDate", System.Type.GetType("System.String"));
            //dsIn.Tables[0].Columns.Add("CurrentOfficeID", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("ItemTypeID", System.Type.GetType("System.String"));

            dsIn.Tables[0].Rows.Add(dsIn.Tables[0].NewRow());
            //dsIn.Tables[0].Rows[0]["ParentPartID"] = sItemParentID.Length == 0 ? DBNull.Value : sItemParentID;
            dsIn.Tables[0].Rows[0]["ItemTypeGroupID"] = sItemTypeGroupID;
            dsIn.Tables[0].Rows[0]["ItemTypeName"] = sItemTypeName;
            dsIn.Tables[0].Rows[0]["Path2Icon"] = sPath2Icon;
            dsIn.Tables[0].Rows[0]["Path2Picture"] = sPath2Picture;
            dsIn.Tables[0].Rows[0]["DefaultCPID"] = sDefaultCPID;
            dsIn.Tables[0].Rows[0]["DefaultCPOfficeID"] = sDefaultCPOfficeID;
            dsIn.Tables[0].Rows[0]["ExpireDate"] = DBNull.Value;
            dsIn.Tables[0].Rows[0]["ItemTypeID"] = DBNull.Value;
            //dsIn.Tables[0].Rows[0]["CurrentOfficeID"] = sItemContainerName;
            DataSet dsOut = gemoDream.Service.ProxyGenericSet(dsIn, "Set");
            string sItemTypeID = dsOut.Tables[0].Rows[0][0].ToString();
            return sItemTypeID;
        }

        public static PictureAndPath GetItemTypePictureAndPath(string sItemTypeID)
        {
            PictureAndPath pap = new PictureAndPath();

            //	spGetItemType
            //	@ItemTypeID dnSmallID
            //	@AuthorID dnSmallID, @AuthorOfficeID dnTinyID,
			

            DataSet dsIn = new DataSet();
            dsIn.Tables.Add("ItemType");
            dsIn.Tables[0].Columns.Add("ItemTypeID", System.Type.GetType("System.String"));

            dsIn.Tables[0].Rows.Add(dsIn.Tables[0].NewRow());
            dsIn.Tables[0].Rows[0]["ItemTypeID"] = sItemTypeID;
            DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);
            pap.sPath2Picture = dsOut.Tables[0].Rows[0]["Path2Picture"].ToString();
            pap.imPicture = Service.GetImageFromSrv(pap.sPath2Picture);
            pap.sPath2Icon = dsOut.Tables[0].Rows[0]["Path2Icon"].ToString();
            pap.imIcon = Service.GetImageFromSrv(pap.sPath2Icon);

            return pap;
        }

        public static PictureAndPath GetItemTypeGroupPicAndPath(string sItemTypeGroupID)
        {
            PictureAndPath pap = new PictureAndPath();
			
            //	spGetItemType
            //	@ItemTypeID dnSmallID
            //	@AuthorID dnSmallID, @AuthorOfficeID dnTinyID,
			

            DataSet dsIn = new DataSet();
            dsIn.Tables.Add("ItemTypeGroup");
            dsIn.Tables[0].Columns.Add("ItemTypeGroupID", System.Type.GetType("System.String"));

            dsIn.Tables[0].Rows.Add(dsIn.Tables[0].NewRow());
            dsIn.Tables[0].Rows[0]["ItemTypeGroupID"] = sItemTypeGroupID;
            DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);
            pap.sPath2Icon = dsOut.Tables[0].Rows[0]["Path2Icon"].ToString();
            pap.imIcon = Service.GetImageFromSrv(pap.sPath2Icon);

            return pap;
        }

        public static void DeleteItemType(string sItemTypeID)
        {
            //	spSetItemType
            //	@ItemTypeGroupID dnSmallID, @ItemTypeName dsName, @Path2Icon dsPath, @Path2Picture dsPath, 
            //	@AuthorID dnSmallID, @AuthorOfficeID dnTinyID,
            //	@DefaultCPID dnID, @DefaultCPOfficeID dnTinyID, @ExpireDate ddDate, @CurrentOfficeID dnTinyID
            //	@ItemTypeID dnSmallID,
			
            DataSet dsIn = new DataSet();
            dsIn.Tables.Add("ItemType");
            dsIn.Tables[0].Columns.Add("ItemTypeGroupID", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("ItemTypeName", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("Path2Icon", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("Path2Picture", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("DefaultCPID", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("DefaultCPOfficeID", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("ExpireDate", System.Type.GetType("System.String"));
            //dsIn.Tables[0].Columns.Add("CurrentOfficeID", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("ItemTypeID", System.Type.GetType("System.String"));

            dsIn.Tables[0].Rows.Add(dsIn.Tables[0].NewRow());
            //dsIn.Tables[0].Rows[0]["ParentPartID"] = sItemParentID.Length == 0 ? DBNull.Value : sItemParentID;
            dsIn.Tables[0].Rows[0]["ItemTypeGroupID"] = DBNull.Value;
            dsIn.Tables[0].Rows[0]["ItemTypeName"] = DBNull.Value;
            dsIn.Tables[0].Rows[0]["Path2Icon"] = DBNull.Value;
            dsIn.Tables[0].Rows[0]["Path2Picture"] = DBNull.Value;
            dsIn.Tables[0].Rows[0]["DefaultCPID"] = "2";
            dsIn.Tables[0].Rows[0]["DefaultCPOfficeID"] = "1";
            dsIn.Tables[0].Rows[0]["ExpireDate"] = DateTime.Now;
            //dsIn.Tables[0].Rows[0]["CurrentOfficeID"] = sItemContainerName;
            dsIn.Tables[0].Rows[0]["ItemTypeID"] = sItemTypeID;
            DataSet dsOut = gemoDream.Service.ProxyGenericSet(dsIn, "Set");
            dsOut.Tables[0].Rows[0][0].ToString();
        }

        public static void DeleteItemTypeGroup(string sItemTypeId)
        {
            // CREATE PROCEDURE [dbo].[spSetItemTypeGroup] 
            // @ItemTypeGroupName dsName, @Path2Icon dsPath, @AuthorID dnSmallID, @AuthorOfficeID dnTinyID, @ItemTypeGroupClass int, 
            // @ExpireDate ddDate, @ItemTypeGroupID int, @CurrentOfficeID dnTinyID)

            DataSet dsIn = new DataSet();
            DataTable dtIn = dsIn.Tables.Add("ItemTypeGroup");
				
            dtIn.Columns.Add("ItemTypeGroupName", System.Type.GetType("System.String"));
            dtIn.Columns.Add("Path2Icon", System.Type.GetType("System.String"));
            dtIn.Columns.Add("ItemTypeGroupClass", System.Type.GetType("System.String"));
            dtIn.Columns.Add("ExpireDate", System.Type.GetType("System.String"));
            dtIn.Columns.Add("ItemTypeGroupID", System.Type.GetType("System.String"));
            dtIn.Columns.Add("ItemTypeGroupParentID", System.Type.GetType("System.String"));

            DataRow row = dtIn.NewRow();

            //row["ItemTypeGroupName"] = DBNull.Value;
            //row["Path2Icon"] = DBNull.Value;
            //row["ItemTypeGroupClass"] = DBNull.Value;
            row["ExpireDate"] = DateTime.Now;
            row["ItemTypeGroupID"] = sItemTypeId;

            dtIn.Rows.Add(row);
            DataSet dsOut = gemoDream.Service.ProxyGenericSet(dsIn, "Set");
        }

        public static DataRow GetItemTypeGroup(string sItemTypeGroupID)
        {
            // CREATE Procedure [dbo].[spGetItemTypeGroup] 
            // (@ItemTypeGroupID dnTinyID,@AuthorID dnSmallID,@AuthorOfficeID dnTinyID) as			

            DataSet dsIn = new DataSet();
            DataTable dtIn = dsIn.Tables.Add("ItemTypeGroup");
				
            dtIn.Columns.Add("ItemTypeGroupID", System.Type.GetType("System.String"));
            DataRow row = dtIn.NewRow();

            row["ItemTypeGroupID"] = sItemTypeGroupID;

            dtIn.Rows.Add(row);
            DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);
            DataRow groupRow = dsOut.Tables[0].Rows[0];
            return groupRow;
        }

        public static string AddItemTypeGroup(string sGroupName, string sPath2Icon, string sParentID)
        {
            // CREATE PROCEDURE [dbo].[spSetItemTypeGroup] 
            // @ItemTypeGroupName dsName, @Path2Icon dsPath, @AuthorID dnSmallID, @AuthorOfficeID dnTinyID, @ItemTypeGroupClass int, 
            //	@ExpireDate ddDate, @ItemTypeGroupID int, @CurrentOfficeID dnTinyID)

            DataSet dsIn = new DataSet();
            DataTable dtIn = dsIn.Tables.Add("ItemTypeGroup");
				
            dtIn.Columns.Add("ItemTypeGroupName", System.Type.GetType("System.String"));
            dtIn.Columns.Add("Path2Icon", System.Type.GetType("System.String"));
            dtIn.Columns.Add("ItemTypeGroupClass", System.Type.GetType("System.String"));
            dtIn.Columns.Add("ExpireDate", System.Type.GetType("System.String"));
            dtIn.Columns.Add("ItemTypeGroupID", System.Type.GetType("System.String"));
            dtIn.Columns.Add("ItemTypeGroupParentID", System.Type.GetType("System.String"));

            DataRow row = dtIn.NewRow();

            row["ItemTypeGroupName"] = sGroupName;
            row["Path2Icon"] = sPath2Icon;
            row["ItemTypeGroupClass"] = "1";
            row["ExpireDate"] = DBNull.Value;
            row["ItemTypeGroupID"] = DBNull.Value;
            if (sParentID == null || sParentID == "")
                row["ItemTypeGroupParentID"] = DBNull.Value;
            else
                row["ItemTypeGroupParentID"] = sParentID;

            dtIn.Rows.Add(row);
            DataSet dsOut = gemoDream.Service.ProxyGenericSet(dsIn, "Set");
            string sItemTypeGroupID = dsOut.Tables[0].Rows[0][0].ToString();
            return sItemTypeGroupID;
        }

        public static bool IsItemTypeNameExists(string sItemTypeName)
        {
            //[spGetItemTypeByName] (@ItemTypeName varchar(1000), @AuthorID dnSmallID,@AuthorOfficeID dnTinyID)

            DataSet dsIn = new DataSet();
            DataTable dtIn = dsIn.Tables.Add("ItemTypeByName");
				
            dtIn.Columns.Add("ItemTypeName", System.Type.GetType("System.String"));

            DataRow row = dtIn.NewRow();

            row["ItemTypeName"] = sItemTypeName;

            dtIn.Rows.Add(row);
            DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);
            bool bExists = dsOut.Tables[0].Rows.Count == 0 ? false : true;
            return bExists;
        }

        public static DataSet GetItemType(string sItemTypeID)
        {
            //[spGetItemTypeByName] (@ItemTypeName varchar(1000), @AuthorID dnSmallID,@AuthorOfficeID dnTinyID)

            DataSet dsIn = new DataSet();
            DataTable dtIn = dsIn.Tables.Add("ItemType");

            dtIn.Columns.Add("ItemTypeID", System.Type.GetType("System.String"));

            DataRow row = dtIn.NewRow();

            row["ItemTypeID"] = sItemTypeID;

            dtIn.Rows.Add(row);
            DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);
            return dsOut;
        }

        public static bool IsItemTypeGroupNameExists(string sItemTypeGroupName)
        {
            //[spGetItemTypeGroupByName] (@ItemTypeGroupName varchar(1000), @AuthorID dnSmallID,@AuthorOfficeID dnTinyID) as

            DataSet dsIn = new DataSet();
            DataTable dtIn = dsIn.Tables.Add("ItemTypeGroupByName");
				
            dtIn.Columns.Add("ItemTypeGroupName", System.Type.GetType("System.String"));

            DataRow row = dtIn.NewRow();

            row["ItemTypeGroupName"] = sItemTypeGroupName;

            dtIn.Rows.Add(row);
            DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);
            bool bExists = dsOut.Tables[0].Rows.Count == 0 ? false : true;
            return bExists;
        }

        public static DataSet GetCustomerProgramByBatchID(string sBatchID)
        {
            DataSet dsIn = new DataSet();
            DataTable dtIn = dsIn.Tables.Add("CustomerProgramByBatchID");
				
            dtIn.Columns.Add("BatchID", System.Type.GetType("System.String"));

            DataRow row = dtIn.NewRow();

            row["BatchID"] = sBatchID;

            dtIn.Rows.Add(row);
            DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);
            return dsOut;
        }

        //		public static string SaveDocument(string sDocumentName, string sBarCodeFixedText, bool bUseDate, bool bUseVVN,
        //			string sItemOperationOfficeID, string sItemOperationID,
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
        //			// @OperationTypeOfficeID_OperationTypeID 
        //			DataSet dsIn = new DataSet();
        //			dsIn.Tables.Add("DocumentTypeOf");
        //			DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);
        //
        //			DataTable table = dsOut.Tables[0];
        //			table.TableName = "Document";
        //			table.Rows.Add(new object[] {});
        //			table.Rows[0]["DocumentName"]			= sDocumentName;
        //			table.Rows[0]["BarCodeFixedText"]		= sBarCodeFixedText;
        //			table.Rows[0]["UseDate"]				= bUseDate;
        //			table.Rows[0]["UseVirtualVaultNumber"]	= bUseVVN;
        //			table.Rows[0]["ItemTypeID"]				= sItemTypeID;
        //			table.Rows[0]["OperationTypeName"]		= sOperationTypeName;
        //			table.Rows[0]["OperationChar"]			= "H";
        //			
        //			dsOut = gemoDream.Service.ProxyGenericSet(dsOut, "Set");
        //			//gemoDream.Service.debug_DiaspalyDataSet(dsOut);
        //			string sID = dsOut.Tables[0].Rows[0][0].ToString();
        //			string[] sIDs = sID.Split('_');
        //			string sDocumentID = sIDs[0];
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
        //			}
        //				
        //			return sDocumentID;
        //		}

        public static void SaveDocumentValue(string sDocumentID, string sTitle, string sValue, string sUnit)
        {
            // spSetDocumentValue
            // @rId varchar(150) output,
            // @DocumentID dnID,
            // @Title nvarchar(2000),
            // @Value nvarchar(2000),
            // @Unit nvarchar(200)

            DataSet dsIn = new DataSet();
            DataTable dtIn = dsIn.Tables.Add("DocumentValue");
            dtIn.Columns.Add("DocumentID", System.Type.GetType("System.String"));
            dtIn.Columns.Add("Title", System.Type.GetType("System.String"));
            dtIn.Columns.Add("Value", System.Type.GetType("System.String"));
            dtIn.Columns.Add("Unit", System.Type.GetType("System.String"));
            DataRow row = dtIn.NewRow();

            row["DocumentID"] = sDocumentID;
            row["Title"] = sTitle;
            row["Value"] = sValue;
            row["Unit"] = sUnit;

            dtIn.Rows.Add(row);
            DataSet dsOut = gemoDream.Service.ProxyGenericSet(dsIn, "Set");
        }

        public static DataSet GetDocumentLanguage()
        {
            try
            {
                // spGetDocumentLanguage
                // @AuthorID dnSmallID,@AuthorOfficeID dnTinyID
			
                DataSet dsIn = new DataSet();
                dsIn.Tables.Add("DocumentLanguage");
				
                //dsIn.Tables[0].Rows.Add(dsIn.Tables[0].NewRow());
                DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);
                return dsOut;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't get document language. Reason: " + ex.ToString(),
                    "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        public static DataSet GetDefDocTitles(string sDocumentLanguageID)
        {
            try
            {
                // spGetDefaultDocumentTitles 
                // @AuthorID dnSmallID,@AuthorOfficeID dnTinyID
			
                DataSet dsIn = new DataSet();
                dsIn.Tables.Add("DefaultDocumentTitle");
                dsIn.Tables[0].Columns.Add("DocumentLanguageID", System.Type.GetType("System.String"));
				
                DataRow row = dsIn.Tables[0].NewRow();
                row["DocumentLanguageID"] = sDocumentLanguageID;
                dsIn.Tables[0].Rows.Add(row);
                DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);
                return dsOut;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't get default documents titles. Reason: " + ex.ToString(),
                    "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        /*
        public string SaveDocument(string sDocumentID, string sDocumentName, string sBarCodeFixedText, bool bUseDate, bool bUseVVN)
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
            DataSet dsIn = new DataSet();
            dsIn.Tables.Add("DocumentTypeOf");
            DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);

            DataTable table = dsOut.Tables[0];

            table.TableName = "Document";
            table.Rows.Add(new object[] {});
            table.Rows[0]["DocumentName"]			= sDocumentName;
            table.Rows[0]["BarCodeFixedText"]		= sBarCodeFixedText;
            table.Rows[0]["UseDate"]				= bUseDate;
            table.Rows[0]["UseVirtualVaultNumber"]	= bUseVVN;
            table.Rows[0]["CPOfficeID"]				= sCPOfficeID;
            table.Rows[0]["CPID"]					= sCPID;
            table.Rows[0]["ItemTypeID"]				= sItemTypeID;
            table.Rows[0]["OperationTypeName"]		= sOperationTypeName;
            table.Rows[0]["OperationChar"]			= "H";
			
            DataSet dsOutA = gemoDream.Service.ProxyGenericSet(dsOut, "Set");
            string sID = dsOutA.Tables[0].Rows[0][0].ToString();
            string[] sIDs = sID.Split('_');
            //gemoDream.Service.debug_DiaspalyDataSet(ds
            string sDocumentID = sIDs[0];
            if ((sDocumentName != null && sDocumentName.Length != 0) 
                //				|| dsOut.Tables[0].Columns.Count == 1
                )
            {
                this.sOperationTypeOfficeID_OperationTypeID = null;
            }
            else
            {
                string sOperationTypeOfficeID = sIDs[1];
                string sOperationTypeID = sIDs[2];
                this.sOperationTypeOfficeID_OperationTypeID = String.Format("{0}_{1}", sOperationTypeOfficeID, sOperationTypeID);
            }

            return sDocumentID;
        }
        */

        public static void UpdateDocument(string sDocumentID, string sDocumentName, string sBarCodeFixedText,
            bool bUseDate, bool bUseVVN, string sCorelFile, string sExportTypeID, string sImportTypeID, string sFormatTypeID)
        {
            //			spUpdateDocument
            //			@DocumentID dnID,
            //			@DocumentName  varchar(250),
            //			@BarCodeFixedText  varchar(2000),
            //			@UseDate  dnBool,
            //			@UseVirtualVaultNumber  dnBool,
            DataSet dsIn = new DataSet();
            DataTable dtIn = dsIn.Tables.Add("UpdateDocument");
            dtIn.Columns.Add("DocumentID", System.Type.GetType("System.String"));
            dtIn.Columns.Add("DocumentName", System.Type.GetType("System.String"));
            dtIn.Columns.Add("BarCodeFixedText", System.Type.GetType("System.String"));
            dtIn.Columns.Add("UseDate", System.Type.GetType("System.Int16"));
            dtIn.Columns.Add("UseVirtualVaultNumber", System.Type.GetType("System.Int16"));
            dtIn.Columns.Add("CorelFile", System.Type.GetType("System.String"));
            dtIn.Columns.Add("ExportTypeID", System.Type.GetType("System.Int16"));
            dtIn.Columns.Add("ImportTypeID", System.Type.GetType("System.Int16"));
            dtIn.Columns.Add("FormatTypeID", System.Type.GetType("System.Int16"));
			
            DataRow row = dtIn.NewRow();

            row["DocumentID"] = sDocumentID;
            row["DocumentName"] = sDocumentName;
            row["BarCodeFixedText"] = sBarCodeFixedText;
            row["UseDate"] = bUseDate;
            row["UseVirtualVaultNumber"] = bUseVVN;
            row["CorelFile"] = sCorelFile;
            row["ExportTypeID"] = sExportTypeID;
            row["ImportTypeID"] = sImportTypeID;
            row["FormatTypeID"] = sFormatTypeID;

            dtIn.Rows.Add(row);
            DataSet dsOut = gemoDream.Service.ProxyGenericSet(dsIn, "");
        }

        public static void DeleteDocumentValue(string sDocumentID)
        {
            //			spDeleteDocumentValue
            //			@DocumentID dnID,
            DataSet dsIn = new DataSet();
            DataTable dtIn = dsIn.Tables.Add("DeleteDocumentValue");
            dtIn.Columns.Add("DocumentID", System.Type.GetType("System.String"));
            DataRow row = dtIn.NewRow();

            row["DocumentID"] = sDocumentID;

            dtIn.Rows.Add(row);
            DataSet dsOut = gemoDream.Service.ProxyGenericSet(dsIn, "");
        }

        public static void SetDocument_CP(string sDocumentID, string sCPOfficeID, string sCPID)
        {
            //			spSetDocument_CP
            //			@DocumentID dnID,
            //			@CPOfficeID dnTinyID,
            //			@CPID dnID
            DataSet dsIn = new DataSet();
            DataTable dtIn = dsIn.Tables.Add("Document_CP");
            dtIn.Columns.Add("DocumentID", System.Type.GetType("System.String"));
            dtIn.Columns.Add("CPOfficeID", System.Type.GetType("System.String"));
            dtIn.Columns.Add("CPID", System.Type.GetType("System.String"));
            DataRow row = dtIn.NewRow();

            row["DocumentID"] = sDocumentID;
            row["CPOfficeID"] = sCPOfficeID;
            row["CPID"] = sCPID;

            dtIn.Rows.Add(row);
            DataSet dsOut = gemoDream.Service.ProxyGenericSet(dsIn, "Set");
        }

        /*
        public static void AddMagicOperations(DataSet ds)
        {
            DataRow row = ds.Tables["DocsByCP"].NewRow();
            row["OperationTypeOfficeID_OperationTypeID"] = "-3_3";
            row["OperationTypeName"] = "MDX Document";
            ds.Tables["DocsByCP"].Rows.Add(row);

            row = ds.Tables["DocsByCP"].NewRow();
            row["OperationTypeOfficeID_OperationTypeID"] = "-2_2";
            row["OperationTypeName"] = "FDX Document";
            ds.Tables["DocsByCP"].Rows.Add(row);

            row = ds.Tables["DocsByCP"].NewRow();
            row["OperationTypeOfficeID_OperationTypeID"] = "-1_1";
            row["OperationTypeName"] = "IDX Document";
            ds.Tables["DocsByCP"].Rows.Add(row);

            return ;
            //return ds;
        }
        */

        /*
        public static DataSet GetDocumentTypeClassDataView()
        {
            DataSet ds = new DataSet();
            ds.Tables.Add("DocsByCP");
            ds.Tables[0].Columns.Add("OperationTypeOfficeID_OperationTypeID", System.Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("OperationTypeName", System.Type.GetType("System.String"));

            DataRow row = ds.Tables[0].NewRow();
            row["OperationTypeOfficeID_OperationTypeID"] = "-3_3";
            row["OperationName"] = "MDX Document";




            //DataView dv = new DataView(ds.Tables[0]);
            //return dv;
            return ds;
        }
        */

        public static DataSet GetShapesByBatchID(string sBatchID)
        {
            // spGetMeasuresByItemType2 
            // @ItemTypeID ,@AuthorID dnSmallID,@AuthorOfficeID dnTinyID
			
            DataSet dsIn = new DataSet();
            dsIn.Tables.Add("ShapesByBatchID");
            dsIn.Tables[0].Columns.Add("BatchID", System.Type.GetType("System.String"));
				
            DataRow row = dsIn.Tables[0].NewRow();
            row["BatchID"] = sBatchID;
            dsIn.Tables[0].Rows.Add(row);
            DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);
            return dsOut;
        }

        public static string GetBatchIDByCP(string sCPID, string sCPOfficeID)
        {
            DataSet dsIn = new DataSet();
            dsIn.Tables.Add("GetBatchIDByCP");
            dsIn.Tables[0].Columns.Add("CPID", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("CPOfficeID", System.Type.GetType("System.String"));
				
            DataRow row = dsIn.Tables[0].NewRow();
            row["CPID"] = sCPID;
            row["CPOfficeID"] = sCPOfficeID;
            dsIn.Tables[0].Rows.Add(row);
            DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);
            string sBatchID = dsOut.Tables[0].Rows[0]["BatchID"].ToString();
            return sBatchID;
        }

        //		public static DataSet GetFileList(string sPath)
        //		{
        //			DataSet dsIn = new DataSet();
        //			dsIn.Tables.Add("FileList");
        //			dsIn.Tables[0].Columns.Add("Path", System.Type.GetType("System.String"));
        //				
        //			DataRow row = dsIn.Tables[0].NewRow();
        //			row["Path"] = sPath;
        //			dsIn.Tables[0].Rows.Add(row);
        //			DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);
        //			return dsOut;
        //		}

        public static ArrayList GetFileList(string sPath)
        {
            DirectoryInfo di = new DirectoryInfo(sPath);
            FileInfo[] fi = di.GetFiles();
            ArrayList fileNames = new ArrayList();
			foreach (FileInfo fiTemp in fi)
			{
				if (fiTemp.Extension.ToUpper() != ".JPG" && fiTemp.Extension.ToUpper() != ".DB")
				{
					if (fiTemp.Extension.ToUpper() != ".TMP")
					{
						if (!fiTemp.Name.ToUpper().Contains("BACKUP"))
						fileNames.Add(new FileName(fiTemp.Name.ToUpper()));
					}
				}
					//                if(fiTemp.Extension.ToUpper() == ".CDR" || fiTemp.Extension.ToUpper() == ".TXT" || fiTemp.Name.ToUpper().IndexOf("DOESN") > 0)
			}
			return fileNames;
		}

		public static ArrayList GetFileList(string sPath, bool forJPG)
		{
			if (forJPG)
			{
				DirectoryInfo di = new DirectoryInfo(sPath);
				FileInfo[] fi = di.GetFiles();
				ArrayList fileNames = new ArrayList();
				foreach (FileInfo fiTemp in fi)
					if (fiTemp.Extension.ToUpper().Contains(".CDR") || fiTemp.Extension.ToUpper().Contains(".XLS"))
					fileNames.Add(new FileName(fiTemp.Name));
				return fileNames;
			}
			else return null;
		}

		public static DataSet GetMeasuresWithAdditional()
        {
            DataSet dsMeasures = new DataSet();
            dsMeasures.Tables.Add("MeasuresWithAdditional");

            try
            {
                return ProxyGenericGet(dsMeasures);
            }
            catch(Exception exc)
            {
                MessageBox.Show("Unable to connect to server. Reason: " + exc.Message, "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static DataSet GetDocumentTypes()
        {
            DataSet ds = new DataSet();
            ds.Tables.Add("DocumentTypes");

            try
            {
                return ProxyGenericGet(ds);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't get document types. Reason: " + ex.ToString(), "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static string GetDocumentTypeReportFileName(string sDocumentTypeCode)
        {
            string sReportFileName = null;

            try
            {
                DataSet dsIn = new DataSet();
                dsIn.Tables.Add("DocumentTypeReportFileName");
                dsIn.Tables[0].Columns.Add("DocumentTypeCode", System.Type.GetType("System.String"));
				
                DataRow row = dsIn.Tables[0].NewRow();
                row["DocumentTypeCode"] = sDocumentTypeCode;
                dsIn.Tables[0].Rows.Add(row);
				
                DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);
                sReportFileName = dsOut.Tables[0].Rows[0]["DocumentTypeReportFileName"].ToString();
                return sReportFileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't get document types. Reason: " + ex.ToString(), "Internal error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                sReportFileName = "";
                return sReportFileName;
            }
        }

        public static bool IsMagicOperation(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].Equals('_'))
                    return false;
            }
            return true;
        }
        public static DataSet GetDocument_CP(string sDocumentID, string sCPOfficeID, string sCPID)
            //was		public static DataSet GetDocument_CP(string sDocumentID, string sCPID, string sCPOfficeID)
        {
            // spGetDocument_CP
            // @DocumentID dnID,
            // @CPOfficeID dnTinyID,
            // @CPID dnID
            DataSet dsIn = new DataSet();
            DataTable dtIn = dsIn.Tables.Add("Document_CP");
            dtIn.Columns.Add("DocumentID", System.Type.GetType("System.String"));
            dtIn.Columns.Add("CPOfficeID", System.Type.GetType("System.String"));
            dtIn.Columns.Add("CPID", System.Type.GetType("System.String"));
            DataRow row = dtIn.NewRow();

            row["DocumentID"] = sDocumentID;
            row["CPOfficeID"] = sCPOfficeID;
            row["CPID"] = sCPID;

            dtIn.Rows.Add(row);
            DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);
            return dsOut;
        }
		
        public static DataSet GetDocument_CP1(string sDocumentID, string sCPOfficeID, string sCPID)
            //was		public static DataSet GetDocument_CP(string sDocumentID, string sCPID, string sCPOfficeID)
        {
            // spGetDocument_CP
            // @DocumentID dnID,
            // @CPOfficeID dnTinyID,
            // @CPID dnID
            DataSet dsIn = new DataSet();
            DataTable dtIn = dsIn.Tables.Add("Document_CP1");
            dtIn.Columns.Add("DocumentID", System.Type.GetType("System.String"));
            dtIn.Columns.Add("CPOfficeID", System.Type.GetType("System.String"));
            dtIn.Columns.Add("CPID", System.Type.GetType("System.String"));
            DataRow row = dtIn.NewRow();

            row["DocumentID"] = sDocumentID;
            row["CPOfficeID"] = sCPOfficeID;
            row["CPID"] = sCPID;

            dtIn.Rows.Add(row);
            DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);
            return dsOut;
        }

        public static bool IsDocumentAttached(string sDocumentID, string sCPID, string sCPOfficeID)
            //		public static bool IsDocumentAttached(string sDocumentID, string sCPOfficeID, string sCPID)
        {
            try
            {
                DataSet ds = GetDocument_CP(sDocumentID, sCPOfficeID, sCPID);
                if (ds.Tables[0].Rows.Count == 0)
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't check document attachment. Reason: " + ex.ToString(),
                    "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
        }
        public static bool IsDocumentAttached1(string sDocumentID, string sCPID, string sCPOfficeID)
            //		public static bool IsDocumentAttached(string sDocumentID, string sCPOfficeID, string sCPID)
        {
            try
            {
                DataSet ds = GetDocument_CP1(sDocumentID, sCPOfficeID, sCPID);
                if (ds.Tables[0].Rows.Count == 0)
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't check document attachment. Reason: " + ex.ToString(),
                    "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
        }
#endregion mvs

#region ServerCfg
        public static string GetCorelReportsPath()
        {
            //			string sCorelParameter = "repDir";
            string sReportPath = Client.GetOfficeDirPath("repDir");
            //			string sPath = Service.ProxyGetServiceCfgParameter(sCorelParameter);
            //			sPath += @"CorelFiles\";
            //			return sPath;
            sReportPath += @"CorelFiles\";
            return sReportPath;

        }
#endregion

        public static string PrintExcelReport()
        {
            //srv.PrintExcelReport("","","");
            return "";
        }

        public static string GetReportKind()
        {
            string report = "";
            XmlNode xn = null;
            try
            {
                xn = Client.GetXmlElement("report");
            }
            catch{}
            if(xn!=null)
                report = xn.InnerText;
            if(report == "crystal")
                return "crystal";

            return "";
        }
        public static string GetShapeEditFileName()
        {
            string fn = "";
            XmlNode xn = null;
            try
            {
                xn = Client.GetXmlElement("plotting");
            }
            catch{}
            if(xn!=null)
                fn = xn.InnerText;
            return fn;
        }

        public static string GetShapeEditFileName(string sTagName)
        {
            string fn = "";
            XmlNode xn = null;
            try
            {
                xn = Client.GetXmlElement(sTagName);
            }
            catch{}
            if(xn!=null)
                fn = xn.InnerText;
            return fn;
        }

		public static void GetCheckedPartFromPartTree(TreeNodeCollection nodes, ref ArrayList myParts, ref ArrayList myPartsNames)
		{
			try
			{
				foreach (TreeNode tn in nodes)
				{
					if (tn.Checked)
					{
						myParts.Add(tn.ImageKey);
						myPartsNames.Add(tn.Text);
					}
					GetRecursive(tn, ref myParts, ref myPartsNames);
				}

			}
			catch (Exception ex)
			{
				var a = ex.Message;
			}
		}

		public static void GetRecursive(TreeNode treeNode, ref ArrayList myParts, ref ArrayList myPartsNames)
		{
			foreach (TreeNode tn in treeNode.Nodes)
			{
				if (tn.Checked)
				{
					myParts.Add(tn.ImageKey);
					myPartsNames.Add(tn.Text);
				}
				GetRecursive(tn, ref myParts, ref myPartsNames);
			}
		}

		public static void UpdatePartTree(TreeNodeCollection nodes, List<string> partID, bool toCheck)
		{
			try
			{
				if (partID.Count > 0)
				{
					foreach (string node in partID)
					{
						foreach (TreeNode tn in nodes)
						{
							if (node.Trim().ToUpper() == "ITEM CONTAINER" && tn.Text.Trim().ToUpper() == node.Trim().ToUpper())
							{
								tn.Checked = toCheck;
								continue;
							}
							FindRecursive(tn, node.Trim(), toCheck);
						}
					}
				}
			}
			catch (Exception ex)
			{
				var a = ex.Message;
			}

		}

		public static void FindRecursive(TreeNode treeNode, string findNode, bool toCheck)
		{
			foreach (TreeNode tn in treeNode.Nodes)
			{
				if (tn.Text == findNode)
					tn.Checked = toCheck;
				FindRecursive(tn, findNode, toCheck);
			}
		}


		public static string GetMyIP_Group()
        {
            string[] myIP1 = null;
            string sIPaddress = "";
            string[] sIP = null;
            string sIP_Group = "";
            
            //Process p;
            try
            {
                goto MyIP; 
                Process p = new Process();
                p.StartInfo.FileName = "IPCONFIG";
                p.StartInfo.UseShellExecute = false;
                //p.StartInfo.Arguments = "/renew";
                //                //p.StartInfo.RedirectStandardOutput = true;
                //                p.Start();
                //                p.WaitForExit();
                //                p.Kill();
                //
                //                p = new Process();
                //                p.StartInfo.FileName = "IPCONFIG";
                p.StartInfo.UseShellExecute = false;
                //p.StartInfo.Arguments = "/all";
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.StartInfo.RedirectStandardOutput = true;
                p.Start();
                p.WaitForExit();
                
                myIP1 = Regex.Split(p.StandardOutput.ReadToEnd().ToString().Trim(), "\r\n");
				int a = 0; // = myIP1.Length;
              
				for (int i = 0; i < myIP1.Length; i++)
				{
					if (myIP1[i].ToString().ToUpper().Contains("LOCAL AREA CONNECTION:"))
					{	
						a = i;
						break;
					}
				
				}

				for (int i = a + 1; i < myIP1.Length; i++)
				{ 
					if (myIP1[i].ToString().ToUpper().Contains("IP ADDRESS") || myIP1[i].ToString().ToUpper().Contains("IPV4 ADDRESS"))
					{
						sIPaddress = myIP1[i].ToString().Substring(myIP1[i].ToString().IndexOf(":") + 1).Trim();
						if (sIPaddress.IndexOf("192.168") >= 0)
						{
							sIP = sIPaddress.Split('.');
							sIP_Group = sIP[2].Trim();
							if (sIP_Group == "1" || sIP_Group == "0") sIP_Group = "255";
							break;
						}
						else
						{
							sIP_Group = "255";
							break;
						}
				
					}
				}
				//sIP_Group = "255";

                MyIP:
                sIP_Group = "255";
                IPHostEntry _IPHostEntry = Dns.GetHostEntry(Dns.GetHostName());
                foreach (IPAddress _IPAddress in _IPHostEntry.AddressList)
                {
                     if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                     {
                        sIPaddress = _IPAddress.ToString();
                         if (sIPaddress.Contains("192.168"))
						{
							sIP = sIPaddress.Split('.');
							sIP_Group = sIP[2].Trim();
							if (sIP_Group == "1" || sIP_Group == "0") sIP_Group = "255";
							break;
		        		}
                       
                     }
                }

				return sIP_Group;
				//foreach (string line in myIP1)
				//{
				//    //if (line.ToUpper().IndexOf("ETHERNET ADAPTER LOCAL") >= 0) bGetIP = true;
				//    if (line.ToUpper().IndexOf("IP ADDRESS") >= 0 || line.ToUpper().IndexOf("IPV4 ADDRESS") >= 0) // && bGetIP)
				//    {
				//        sIPaddress = line.Substring(line.IndexOf(":") + 1).Trim();
				//        if (sIPaddress.IndexOf("192.168")>= 0) 
				//            break;
				//    }
				//}
				//if (sIPaddress.IndexOf("192.168") < 0) sIP_Group = "255";
				
				//else
				//{

				//    if (sIPaddress.Trim() != "")
				//    {
				//        sIP = sIPaddress.Split('.');
				//        sIP_Group = sIP[2].Trim();
				//        return sIP_Group;
				//    }
				//}
				//    return sIP_Group;
            }
            catch
            {
                throw new Exception("Can't find IP address. Restart program");
            }
        }
		

        public static void SetIP_Connection()
        {
            Process p;
            try
            {
                p = new Process();
                p.StartInfo.FileName = "IPCONFIG";
                p.StartInfo.CreateNoWindow = true; //.UseShellExecute = false;
                p.StartInfo.Arguments = "/renew";
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.StartInfo.UseShellExecute = false;
                p.Start();
                p.WaitForExit();
            }
            catch{}
        }
 
    }

	public class Log
	{
		StreamWriter writer =null;
		string sPath="";
			
		public Log(string sLogPath)
		{
			sPath=sLogPath;
		}
				
		public void Write(string sText)
		{
			writer=new StreamWriter(sPath, true);
			writer.Write(System.DateTime.Now.Date.ToShortDateString()+" "+System.DateTime.Now.ToLongTimeString()+": ");
			writer.WriteLine(sText);
			writer.Flush();
			writer.Close();
		}

		~Log()
		{
				
		}
				
	}

	public class FileName
	{
		private string myFileName ;
    
		public  FileName(string sFileName)
		{
			this.myFileName = sFileName;
		}

		public string Text
		{
			get
			{
				return myFileName;
			}
		}

		public override string ToString()
		{
			return this.myFileName;
		}
	}

	public struct Couple
	{
		public string FieldName;
		public string FieldValue;			
	}
}