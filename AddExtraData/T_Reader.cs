using System;
using System.Data;
using System.IO;
using System.Xml;
using System.Globalization;



namespace gemoDream
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class T_Reader
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			/*Console.Write("Enter login please: ");
			string sLogin = Console.ReadLine();
			Console.Write("Enter password please: ");
			string sPassword = Console.ReadLine();*/

			Console.WriteLine("Started working utility...");
			string sLog = GetXmlParameter("logfile");
			StreamWriter sw = new StreamWriter(sLog, true);
			CultureInfo culture = new CultureInfo("en-US");
			try
			{
				string sLogin = GetXmlParameter("login");
				string sPassword = GetXmlParameter("password");

				string sDepartment = GetXmlParameter("department");
				string sDepartmentOffice = GetXmlParameter("departmentOffice");
				string serverUrl = GetXmlParameter("serverUrl");
				int iDepartmentId = Convert.ToInt32(sDepartment);
				int iDepartmentOfficeId = Convert.ToInt32(sDepartmentOffice);

				DataSet dsAccess;
				//gemoDreamService.GdrService.Url=serverUrl;
				gemoDreamService.GdrService srv = new gemoDreamService.GdrService();
				try
				{
					srv.Url = GetXmlParameter("serverUrl");
				}
				catch(Exception eEx)
				{
					string sErrMsg = "Couldn't get server name from local configuration file.\n";
					throw new Exception(sErrMsg+eEx.Message);
				}
				
				string sSessionId = srv.Login(sLogin, sPassword, iDepartmentId, iDepartmentOfficeId, out dsAccess);
				if(sSessionId == "")
					throw new Exception("You are not authorised. Check your login and password.");

				srv.Timeout = 60*60*1000; // time out for data file processing
				DataSet dsFiles = new DataSet();
				DataTable dtFiles = dsFiles.Tables.Add();
				dtFiles.Columns.Add("FileName");
				dtFiles.Columns.Add("FileTime");

				DateTime dtFileTime;
				string sDate = GetXmlParameter("time");
				DateTime time = Convert.ToDateTime(sDate,culture);

				string sDir = srv.GetGraderDir(sSessionId);
				string sFileTypess = GetXmlParameter("storedFileTypes");
				string[] sFileTypes = sFileTypess.Split(',');
				int countGood = 0;
				int countBad = 0;
				foreach(string sFileType in sFileTypes)
				{
					GetGraderFiles(sDir, sFileType.Trim().ToLower(), ref dsFiles);

					DataView dvFiles = new DataView(dtFiles);
					dvFiles.Sort = "FileTime";

					string path;
					foreach(DataRowView drvFile in dvFiles)
					{
						path = drvFile["FileName"].ToString();
						dtFileTime = File.GetLastWriteTime(path);
						if(DateTime.Compare(dtFileTime, time)<=0)//For files created later then time date
							continue;

						string rid;

						dtFileTime = srv.AddGraderData(sSessionId, path,"", out rid );

						if(true||rid=="") // success
						{
							sw.WriteLine(DateTime.Now);
							sw.WriteLine("Entry from {0} was impoprted in to the DB successfully", Path.GetFileName(path));
							countGood++;
						}
						else
						{
							sw.WriteLine(DateTime.Now);
							sw.WriteLine("{0} was NOT impoprted into the DB", Path.GetFileName(path));
							sw.WriteLine("ERROR: "+rid);
							countBad++;
						}

						SetXmlParameter("time",Convert.ToString(dtFileTime));

					}
				}
				
				Console.WriteLine("Utility executed successfully.");
				sw.WriteLine(DateTime.Now);
				sw.WriteLine("Utility execution complited: "+countGood+" files imported successfully; "+countBad+" files have errors");
			}
			catch (Exception e) 
			{
				sw.WriteLine(DateTime.Now);
				sw.WriteLine("Utility work is finished with error: {0}", e.ToString());
			}
			sw.Close();
	}


		/// <summary>
		/// Gets all files from specified directory and all subdirectories
		/// </summary>
		/// <param name="sDir">directory root</param>
		/// <param name="sFileType">file type to get</param>
		/// <param name="dsFiles">dataset with found files</param>
		private static void GetGraderFiles(string sDir, string sFileType, ref DataSet dsFiles)
		{
			string[] sFiles = Directory.GetFiles(sDir, sFileType);
			foreach(string sFile in sFiles)
				dsFiles.Tables[0].Rows.Add(new object[] {sFile, Directory.GetCreationTime(sFile)});
			
			string[] sDirs = Directory.GetDirectories(sDir);
			foreach(string sDr in sDirs)
				GetGraderFiles(sDr, sFileType, ref dsFiles);
		}

		/// <summary>
		/// Gets Xml node from the configuration file by it's name
		/// </summary>
		/// <param name="sTagName">node's name</param>
		/// <returns>xml node</returns>
		private static string GetXmlParameter(string sTagName)
		{
			string sPath = "ConsoleCfg.xml";
			XmlNodeList xnlList = null;
			XmlDocument xdDoc = new XmlDocument();
			
			try
			{
				xdDoc.Load(sPath);
				xnlList = xdDoc.GetElementsByTagName(sTagName);
			}
			catch(Exception eEx)
			{
				string sErrMsg = "Couldn't get parameter "+sTagName+" from console configuration file.\n";
				throw new Exception(sErrMsg+eEx.Message);
			}
	
			return xnlList[0].InnerText;
		}

		/// <summary>
		/// Sets xml node innertext to specified value
		/// </summary>
		/// <param name="sTagName">node's name</param>
		/// <param name="sValue">value</param>
		/// <returns>true if successfull, false otherwise</returns>
		private static bool SetXmlParameter(string sTagName, string sValue)
		{
			string sPath = "ConsoleCfg.xml";
			XmlNodeList xnlList = null;
			XmlDocument xdDoc = new XmlDocument();
			
			try
			{
				xdDoc.Load(sPath);
				xnlList = xdDoc.GetElementsByTagName(sTagName);
				xnlList[0].InnerText = sValue;
				xdDoc.Save(sPath);
			}
			catch(Exception eEx)
			{
				throw new Exception("Couldn't set parameter "+sTagName+" into console configuration file\n"+eEx.Message);
			}
	
			return true;
		}
	}
}
