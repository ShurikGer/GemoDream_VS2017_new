using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Cntrls
{
    /// <summary>
    /// Summary description for BarCode.
    /// </summary>
    public class BarCode : System.Windows.Forms.UserControl
    {
        private const int ITEM_CODE = 10;
        private const int BATCH_CODE = 8;
        private const int ORDER_CODE = 5;

        private const int DOC_ITEM_CODE = ITEM_CODE + 1;
        private const int DOC_BATCH_CODE = BATCH_CODE + 1;
        private const int DOC_ORDER_CODE = ORDER_CODE + 1;

        private const int EXT_ITEM_CODE = 11;
        private const int EXT_BATCH_CODE = 9;
        private const int EXT_ORDER_CODE = 6;

        private const int EXT_DOC_ITEM_CODE = EXT_ITEM_CODE + 1;
        private const int EXT_DOC_BATCH_CODE = EXT_BATCH_CODE + 1;
        private const int EXT_DOC_ORDER_CODE = EXT_ORDER_CODE + 1;

        public string sFullCode = "";
        public string cDocChar = "";
        public int iOrderCode = 0;

        public int iEntryBatchCode = 0;
        public int iBatchCode = 0;
        public int iItemCode = 0;
        public bool bEnteringCode = true;
        public bool bIsCorrect = true;

        #region Generated
        private System.Windows.Forms.TextBox tbDocId;
        private System.Windows.Forms.Timer timer;
        private System.ComponentModel.IContainer components;

        public BarCode()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call

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

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tbDocId = new System.Windows.Forms.TextBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tbDocId
            // 
            this.tbDocId.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
            this.tbDocId.Location = new System.Drawing.Point(0, 0);
            this.tbDocId.Name = "tbDocId";
            this.tbDocId.Size = new System.Drawing.Size(260, 20);
            this.tbDocId.TabIndex = 2;
            this.tbDocId.Text = "";
            this.tbDocId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDocId_KeyPress);
            this.tbDocId.Enter += new System.EventHandler(this.tbDocId_Enter);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // BarCode
            // 
            this.Controls.Add(this.tbDocId);
            this.Name = "BarCode";
            this.Size = new System.Drawing.Size(260, 20);
            this.Resize += new System.EventHandler(this.BarCode_Resize);
            this.ResumeLayout(false);

        }
        #endregion
        #endregion Generated

        public bool IsCorrectCode
        {
            get
            {
                return bIsCorrect;
            }
        }

        private void timer_Tick(object sender, System.EventArgs e)
        {
            timer.Stop();
            bEnteringCode = false;
            try
            {
                if (tbDocId.Text.Trim().Length > 4)
                {
                    ParseDocumentCode();
                    sFullCode = GetCorrectFullCodeString();
                    bIsCorrect = true;
                }
            }
            catch
            {
                sFullCode = "Input code has incorrect format";
                bIsCorrect = false;
                return;
            }

            if (bIsCorrect)
            {
                tbDocId.Text = sFullCode;

                if (CodeEntered != null)
                    CodeEntered(this, System.EventArgs.Empty);
            }
        }

        private void tbDocId_Enter(object sender, System.EventArgs e)
        {
            //tbDocId.Text = "";
        }

        private void tbDocId_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            timer.Stop();
            timer.Interval = 1000;
            timer.Start();

            char c = e.KeyChar;
            if (((c >= '0' && c <= '9') || c == '.' || c == 8 || c == 13) && (sender as TextBox).Text.Length < 18)
            {
                e.Handled = false;
            }
            else
            {
                if (((sender as TextBox).Text.Length == 18) && c != 13 &&
                    ((c >= '0' && c <= '9') || c == '.' || c == 8) && (sender as TextBox).Text == "#####.#####.###.##")
                {
                    (sender as TextBox).Text = "";
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }


            if (!bEnteringCode)
            {
                sFullCode = "";
                cDocChar = "";
                iOrderCode = 0;
                iEntryBatchCode = 0;
                iBatchCode = 0;
                iItemCode = 0;
                bEnteringCode = true;
            }
        }


        private const int DOC_ITEM_DISPLAY_CODE = 19;
        private static int[] DOC_ITEM_DISPLAY_CODE_FORMAT = { 1, 5, 5, 3, 2 };
        private static int DISPLAY_ITEM_DOT1 = DOC_ITEM_DISPLAY_CODE_FORMAT[0];
        private static int DISPLAY_ITEM_DOT2 = DOC_ITEM_DISPLAY_CODE_FORMAT[0] + DOC_ITEM_DISPLAY_CODE_FORMAT[1] + 1;
        private static int DISPLAY_ITEM_DOT3 = DOC_ITEM_DISPLAY_CODE_FORMAT[0] + DOC_ITEM_DISPLAY_CODE_FORMAT[1] + DOC_ITEM_DISPLAY_CODE_FORMAT[2] + 2;
        private static int DISPLAY_ITEM_DOT4 = DOC_ITEM_DISPLAY_CODE_FORMAT[0] + DOC_ITEM_DISPLAY_CODE_FORMAT[1] + DOC_ITEM_DISPLAY_CODE_FORMAT[2] + DOC_ITEM_DISPLAY_CODE_FORMAT[3] + 3;
        private const int DOC_BATCH_DISPLAY_CODE = 16;
        private static int[] DOC_BATCH_DISPLAY_CODE_FORMAT = { 1, 5, 5, 3 };
        private static int DISPLAY_BATCH_DOT1 = DOC_BATCH_DISPLAY_CODE_FORMAT[0];
        private static int DISPLAY_BATCH_DOT2 = DOC_BATCH_DISPLAY_CODE_FORMAT[0] + DOC_BATCH_DISPLAY_CODE_FORMAT[1] + 1;
        private static int DISPLAY_BATCH_DOT3 = DOC_BATCH_DISPLAY_CODE_FORMAT[0] + DOC_BATCH_DISPLAY_CODE_FORMAT[1] + DOC_BATCH_DISPLAY_CODE_FORMAT[2] + 2;
        private const int DOC_ORDER_DISPLAY_CODE = 12;
        private static int[] DOC_ORDER_DISPLAY_CODE_FORMAT = { 1, 5, 5 };
        private static int DISPLAY_ORDER_DOT1 = DOC_ORDER_DISPLAY_CODE_FORMAT[0];
        private static int DISPLAY_ORDER_DOT12 = DOC_ORDER_DISPLAY_CODE_FORMAT[0] + DOC_ORDER_DISPLAY_CODE_FORMAT[1] + 1;


        private static int[] DOC_ITEM_CODE_FORMAT = { 1, 5, 3, 2 };
        private static int ITEM_DOT1 = DOC_ITEM_CODE_FORMAT[0];
        private static int ITEM_DOT2 = DOC_ITEM_CODE_FORMAT[0] + DOC_ITEM_CODE_FORMAT[1];
        private static int ITEM_DOT3 = DOC_ITEM_CODE_FORMAT[0] + DOC_ITEM_CODE_FORMAT[1] + DOC_ITEM_CODE_FORMAT[2];

        private static int[] DOC_BATCH_CODE_FORMAT = { 1, 5, 3 };
        private static int BATCH_DOT1 = DOC_BATCH_CODE_FORMAT[0];
        private static int BATCH_DOT2 = DOC_BATCH_CODE_FORMAT[0] + DOC_BATCH_CODE_FORMAT[1];

        private static int[] DOC_ORDER_CODE_FORMAT = { 1, 5 };
        private static int ORDER_DOT1 = DOC_ORDER_CODE_FORMAT[0];
        private static int[] EXT_DOC_ITEM_CODE_FORMAT = { 1, 6, 3, 2 };


        private void ParseDocumentCode()
        {

            cDocChar = "";
            sFullCode = "";
            iOrderCode = 0;
            iEntryBatchCode = 0;
            iBatchCode = 0;
            iItemCode = 0;

            try
            {
                switch (tbDocId.Text.Length)
                {
                    case ITEM_CODE:
                        iOrderCode = Convert.ToInt32(tbDocId.Text.Substring(0, 5));
                        iEntryBatchCode = iOrderCode;
                        iBatchCode = Convert.ToInt32(tbDocId.Text.Substring(5, 3));
                        iItemCode = Convert.ToInt32(tbDocId.Text.Substring(8, 2));
                        break;
                    case BATCH_CODE:
                        iOrderCode = Convert.ToInt32(tbDocId.Text.Substring(0, 5));
                        iEntryBatchCode = iOrderCode;
                        iBatchCode = Convert.ToInt32(tbDocId.Text.Substring(5, 3));
                        break;
                    case ORDER_CODE:
                        iOrderCode = Convert.ToInt32(tbDocId.Text.Substring(0, 5));
                        iEntryBatchCode = iOrderCode;
                        break;

                    //				case DOC_ITEM_CODE:
                    //					cDocChar = Convert.ToString(tbDocId.Text.Substring(0, DOC_ITEM_CODE_FORMAT[0]));
                    //					iOrderCode = Convert.ToInt32(tbDocId.Text.Substring(ITEM_DOT1, DOC_ITEM_CODE_FORMAT[1]));
                    //					iEntryBatchCode = Convert.ToInt32(tbDocId.Text.Substring(ITEM_DOT1, DOC_ITEM_CODE_FORMAT[1]));
                    //					iBatchCode = Convert.ToInt32(tbDocId.Text.Substring(ITEM_DOT2, DOC_ITEM_CODE_FORMAT[2]));
                    //					iItemCode = Convert.ToInt32(tbDocId.Text.Substring(ITEM_DOT3, DOC_ITEM_CODE_FORMAT[3]));
                    //					break;
                    //				case DOC_BATCH_CODE:
                    //					cDocChar = Convert.ToString(tbDocId.Text.Substring(0, DOC_BATCH_CODE_FORMAT[0]));
                    //					iOrderCode = Convert.ToInt32(tbDocId.Text.Substring(BATCH_DOT1, DOC_BATCH_CODE_FORMAT[1]));
                    //					iEntryBatchCode = Convert.ToInt32(tbDocId.Text.Substring(BATCH_DOT1, DOC_BATCH_CODE_FORMAT[1]));
                    //					iBatchCode = Convert.ToInt32(tbDocId.Text.Substring(BATCH_DOT2, DOC_BATCH_CODE_FORMAT[2]));
                    //					break;
                    //				case DOC_ORDER_CODE:
                    //					cDocChar = Convert.ToString(tbDocId.Text.Substring(0, DOC_ORDER_CODE_FORMAT[0]));
                    //					iOrderCode = Convert.ToInt32(tbDocId.Text.Substring(ORDER_DOT1, DOC_ORDER_CODE_FORMAT[1]));
                    //					iEntryBatchCode = Convert.ToInt32(tbDocId.Text.Substring(ORDER_DOT1, DOC_ORDER_CODE_FORMAT[1]));
                    //					break;

                    case EXT_ITEM_CODE:
                        iOrderCode = Convert.ToInt32(tbDocId.Text.Substring(0, 6));
                        iEntryBatchCode = iOrderCode;
                        iBatchCode = Convert.ToInt32(tbDocId.Text.Substring(6, 3));
                        iItemCode = Convert.ToInt32(tbDocId.Text.Substring(9, 2));
                        break;

                    case EXT_BATCH_CODE:
                        iOrderCode = Convert.ToInt32(tbDocId.Text.Substring(0, 6));
                        iEntryBatchCode = iOrderCode;
                        iBatchCode = Convert.ToInt32(tbDocId.Text.Substring(6, 3));
                        break;

                    case EXT_ORDER_CODE:
                        iOrderCode = Convert.ToInt32(tbDocId.Text.Substring(0, 6));
                        iEntryBatchCode = iOrderCode;
                        break;
                    /*
                             private const int EXT_DOC_ITEM_CODE = EXT_ITEM_CODE + 1;
                            private const int DOC_BATCH_CODE = EXT_BATCH_CODE + 1;
                            private const int DOC_ORDER_CODE = EXT_ORDER_CODE + 1;
                     */
                    //                case EXT_DOC_ITEM_CODE:
                    //                    cDocChar = Convert.ToString(tbDocId.Text.Substring(0, DOC_ITEM_CODE_FORMAT[0]));
                    //                    iOrderCode = Convert.ToInt32(tbDocId.Text.Substring(ITEM_DOT1, DOC_ITEM_CODE_FORMAT[1]));
                    //                    iEntryBatchCode = Convert.ToInt32(tbDocId.Text.Substring(ITEM_DOT1, DOC_ITEM_CODE_FORMAT[1]));
                    //                    iBatchCode = Convert.ToInt32(tbDocId.Text.Substring(ITEM_DOT2, DOC_ITEM_CODE_FORMAT[2]));
                    //                    iItemCode = Convert.ToInt32(tbDocId.Text.Substring(ITEM_DOT3, DOC_ITEM_CODE_FORMAT[3]));
                    //                    break;

                    default:
                        throw new Exception("Input code has incorrect format");
                }
            }
            catch
            {
                throw new Exception("Input code has incorrect format");
            }

        }

        private string GetCorrectFullCodeString()
        {
            string sDocCode = cDocChar.ToString();
            if (iOrderCode > 0 && iOrderCode < 1000000)
            {
                if (iOrderCode > 0 && iOrderCode < 100000)
                {
                    sDocCode += GetCorrectCodeString(iOrderCode, DOC_ITEM_CODE_FORMAT[1]);
                    if (iEntryBatchCode > 0)
                        sDocCode += "." + GetCorrectCodeString(iEntryBatchCode, DOC_ITEM_CODE_FORMAT[1]);
                    if (iBatchCode > 0)
                        sDocCode += "." + GetCorrectCodeString(iBatchCode, DOC_ITEM_CODE_FORMAT[2]);
                    if (iItemCode > 0)
                        sDocCode += "." + GetCorrectCodeString(iItemCode, DOC_ITEM_CODE_FORMAT[3]);
                }
                if (iOrderCode >= 100000 && iOrderCode < 1000000)
                {
                    sDocCode += GetCorrectCodeString(iOrderCode, EXT_DOC_ITEM_CODE_FORMAT[1]);
                    if (iEntryBatchCode > 0)
                    {
                        sDocCode += "." + GetCorrectCodeString(iEntryBatchCode, EXT_DOC_ITEM_CODE_FORMAT[1]);
                    }
                    if (iBatchCode > 0)
                    {
                        sDocCode += "." + GetCorrectCodeString(iBatchCode, EXT_DOC_ITEM_CODE_FORMAT[2]);
                    }
                    if (iItemCode > 0)
                    {
                        sDocCode += "." + GetCorrectCodeString(iItemCode, EXT_DOC_ITEM_CODE_FORMAT[3]);
                    }
                }
                return sDocCode;
            }
            else throw new Exception("Input code has incorrect format");

        }

        private string GetCorrectCodeString(int iCode, int iCodeLength)
        {
            string sCode = iCode.ToString();
            while (sCode.Length < iCodeLength)
                sCode = "0" + sCode;

            return sCode;
        }

        private void BarCode_Resize(object sender, System.EventArgs e)
        {
            tbDocId.Size = new Size(this.Size.Width, this.Size.Height);
        }

        public void SelectAll()
        {
            tbDocId.SelectAll();
        }


        /// <summary>
        /// definition of event
        /// </summary>
        [
        Category("ControlProperty"),
        Description("Event fired when the length of text value become equals DigitsQuantity.")
        ]
        public event EventHandler CodeEntered;

        public override string Text
        {
            get
            {
                return sFullCode;
            }
            //            set
            //            {
            //                tbDocId.Text = value;
            //            }
        }

        public string sGroupCode
        {
            get
            {
                if (iOrderCode > 0)
                    tbDocId.Text = GetCorrectCodeString(iOrderCode, 5);
                else
                    tbDocId.Text = "";
                return tbDocId.Text; //iOrderCode.ToString();
            }
            //            set
            //            {
            //                sGroupCode = value;
            //                tbDocId.Text = sGroupCode;
            //            }
        }
    }
}
