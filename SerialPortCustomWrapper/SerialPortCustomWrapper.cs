using System;
using DesktopSerialIO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections;
using System.Xml;
using gemoDream;

//Working version
namespace SerialPortCustomWrapper
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class SerialPortCustomWrapper
    {
        private DesktopSerialIO.SerialIO.SerialPort sp;
        private StringBuilder sb;

        private double _dblResult;
        public int _iComPortSource = 0;

        public int iComPortSource
        {
            get
            {
                return _iComPortSource;
            }
            set
            {
                _iComPortSource = value;
            }
        }

        public double dblResult
        {
            get
            {
                return _dblResult;
            }
            set
            {
                _dblResult = value;
            }

        }

        public bool PortOpen
        {
            get
            {
                return sp.PortOpen;
            }
            set
            {
                sp.PortOpen = value;
                sp.EnableOnComm = value;
            }
        }

        public int BitRate
        {
            get
            {
                return sp.BitRate;
            }
            set
            {
                sp.BitRate = value;
            }
        }

        public int CommPort
        {
            get
            {
                return sp.CommPort;
            }
            set
            {
                sp.CommPort = value;
            }
        }

        public string Parity
        {
            get
            {
                return sp.Parity;
            }
            set
            {
                sp.Parity = value;
            }
        }

        public float StopBits
        {
            get
            {
                return sp.StopBits;
            }
            set
            {
                sp.StopBits = value;
            }
        }

        public int DataBits
        {
            get
            {
                return sp.DataBits;
            }
            set
            {
                sp.DataBits = value;
            }
        }

        public bool RTSEnable
        {
            get
            {
                return sp.RTSEnable;
            }
            set
            {
                sp.RTSEnable = value;
            }
        }

        public bool DTREnable
        {
            get
            {
                return sp.DTREnable;
            }
            set
            {
                sp.DTREnable = value;
            }
        }

        public bool CTSHandshaking
        {
            get
            {
                return sp.CTSHandshaking;
            }
            set
            {
                sp.CTSHandshaking = value;
            }
        }

        public bool XonXoffHandshaking
        {
            get
            {
                return sp.XonXoffHandshaking;
            }
            set
            {
                sp.XonXoffHandshaking = value;
            }
        }

        public byte[] InpuArray
        {
            get
            {
                return sp.InputArray();
            }
        }

        public string InputString
        {
            get
            {
                return sp.InputString();
            }
        }


        public SerialPortCustomWrapper(XmlDocument xmlSettings)
        {
            //
            // TODO: Add constructor logic here
            //

            if (_iComPortSource == 0)
            {
                sb = new StringBuilder(512);
                sp = new DesktopSerialIO.SerialIO.SerialPort();
                LoadPortSettings(xmlSettings);
                //                {
                //                    sp.CommPort = 1;
                //                    sp.BitRate= 1200;
                //                    sp.Parity = "odd";
                //                    sp.StopBits=1;
                //                    sp.DataBits=7;
                //                    sp.RTSEnable=true;
                //                    sp.DTREnable=true;
                //                    //sp.CTSHandshaking=true;
                //                    sp.XonXoffHandshaking = true;
                //                }
            }
            sp.OnComm += new DesktopSerialIO.SerialIO.SerialPort.OnCommEventHandler(SerialPort_OnComm);
        }

        public SerialPortCustomWrapper(bool byDefault)
        {
            //
            // TODO: Add constructor logic here
            //

            if (_iComPortSource == 0)
            {
                sb = new StringBuilder(512);
                sp = new DesktopSerialIO.SerialIO.SerialPort();
                {
                    sp.CommPort = 1;
                    sp.BitRate = 1200;
                    sp.Parity = "odd";
                    sp.StopBits = 1;
                    sp.DataBits = 7;
                    sp.RTSEnable = true;
                    sp.DTREnable = true;
                    //sp.CTSHandshaking=true;
                    sp.XonXoffHandshaking = true;
                }
            }
            sp.OnComm += new DesktopSerialIO.SerialIO.SerialPort.OnCommEventHandler(SerialPort_OnComm);
        }

        private void LoadPortSettings(XmlDocument xmlSettings)
        {
            //GetXmlElement(string sTagName, XmlDocument xdDoc)
            XmlNode xnNode = Client.GetXmlElement("CommPortNumber", xmlSettings);
            sp.CommPort = Convert.ToInt16(xnNode.InnerText.ToString());

            xnNode = Client.GetXmlElement("BitRate", xmlSettings);
            sp.BitRate = Convert.ToInt16(xnNode.InnerText.ToString());

            xnNode = Client.GetXmlElement("DataBits", xmlSettings);
            sp.DataBits = Convert.ToInt16(xnNode.InnerText.ToString());

            xnNode = Client.GetXmlElement("StopBits", xmlSettings);
            sp.StopBits = Convert.ToInt16(xnNode.InnerText.ToString());

            xnNode = Client.GetXmlElement("Parity", xmlSettings);
            sp.Parity = xnNode.InnerText.ToString();

            xnNode = Client.GetXmlElement("RTSEnable", xmlSettings);
            sp.RTSEnable = (xnNode.InnerText.ToString() == "true" ? true : false);

            xnNode = Client.GetXmlElement("DTREnable", xmlSettings);
            sp.DTREnable = (xnNode.InnerText.ToString() == "true" ? true : false);

            xnNode = Client.GetXmlElement("XonXoffHandshaking", xmlSettings);
            sp.XonXoffHandshaking = (xnNode.InnerText.ToString() == "true" ? true : false);

            xnNode = Client.GetXmlElement("CTSHandshaking", xmlSettings);
            sp.CTSHandshaking = (xnNode.InnerText.ToString() == "true" ? true : false);

            sp.CTSHandshaking = (!sp.XonXoffHandshaking);
        }

        private void SerialPort_OnComm()
        {
            string s = sp.InputString();
            sb.Append(s);
            //	statusBar1.Text=s;
            //			System.Console.Write(sb.ToString());
            //	this.BeginInvoke(new EventHandler(DisplayData));

            ThreadStart job = new ThreadStart(Digi);
            Thread thread = new Thread(job);
            thread.Start();
            thread.Join();
            //	this.BeginInvoke(new EventHandler(Digi));
        }

        private void Digi()
        {
            string strSnapshot = "";
            string sToTrim = "\r\n + ct";
            strSnapshot = sb.ToString();
            String rexBracket = (@"\d+\.\d*");
            Regex mm = new Regex(rexBracket);
            string output = "";
            double dVal = 0;
            double dValProced = 0;

            if (strSnapshot.Length > 60)
            {
                sp.PortOpen = false;
                //strSnapshot.Replace("\r"," ").Replace("  "," ");

                string[] strLines = strSnapshot.Split('\n');
                for (int i = 0; i < strLines.Length; i++)
                {
                    strLines[i] = strLines[i].Trim(sToTrim.ToCharArray());
                    if (strLines[i] == "") strLines[i] = "0";
                }

                if (strLines.Length > 3)
                {

                    // good get the next to last line
                    string strNextToLast = "";
                    strNextToLast = strLines[strLines.Length - 2];

                    goto New123;
                    //lblDigi.Text=strNextToLast;
                    //					double dVal = 0;
                    dVal = double.Parse(strNextToLast.Trim().ToUpper().Replace("CT", "").Replace("+", "").Replace("-", "").Replace("!", "").Replace("?", "").Replace(" ", "").Replace("N", ""));
                    //					double dValProced = 0;
                    dValProced = Service9(dVal);
                    _dblResult = dValProced;
                    sb = new StringBuilder(512);
                //sp.PortOpen = false;
                //txtDigi1.Text=strNextToLast.Replace("ct","").Trim();
                //					txtDigi1.Text=dVal.ToString();
                //					txtDigi2.Text=dValProced.ToString();

                  New123:
                    foreach (Match myMatch in mm.Matches(strNextToLast))
                    {
                        output += output + myMatch.ToString();
                    }
                    dVal = double.Parse(output);
                    //dValProced = Service9(dVal);
                    //_dblResult = dValProced;
                    _dblResult = dVal;
                    sb = new StringBuilder(512);
                }
            }
            if (sb.Length > (int)(0.8 * sb.Capacity))
            {
                sb.Remove(0, (int)(0.6 * sb.Capacity));
            }
        }


        private double Service9(double d)
        {
            string sDfind9 = d.ToString("##0.0000;");
            //			int iLength = sDfind9.Length - (sDfind9.IndexOf('.') + 1);
            //			if (iLength > 2 && sDfind9.EndsWith("9"))
            if (sDfind9.Substring(sDfind9.Length - 2, 1) == "9")
            {
                d = d + 0.001;
            }
            else
            {
                double shifted = 0;
                shifted = d * 1000;
                int intShifted = (int)shifted;
                int reminder = intShifted % 10;
                int clean = intShifted - reminder;
                d = ((double)clean) / 1000;
            }
            return d;
        }

        ~SerialPortCustomWrapper()
        {
            if (sp.PortOpen == true)
            {
                sp.PortOpen = false;
            }
        }
    }
}
