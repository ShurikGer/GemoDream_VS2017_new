using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using gemoDream;

namespace Cntrls
{
    /// <summary>
    /// class BarCodeField provide visual form for entering Bar-code .
    /// </summary>
    public class BarCodeField : System.Windows.Forms.UserControl
    {
        #region Generated
        private System.Windows.Forms.TextBox tbBarCode;
        private System.Windows.Forms.Timer timer;
        private System.ComponentModel.IContainer components;

        public BarCodeField()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
            Initialize();
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
            this.tbBarCode = new System.Windows.Forms.TextBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tbBarCode
            // 
            this.tbBarCode.Location = new System.Drawing.Point(0, 0);
            this.tbBarCode.Name = "tbBarCode";
            this.tbBarCode.Size = new System.Drawing.Size(360, 20);
            this.tbBarCode.TabIndex = 0;
            this.tbBarCode.Text = "";
            this.tbBarCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbBarCode_KeyDown);
            this.tbBarCode.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbBarCode_MouseDown);
            this.tbBarCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbBarCode_KeyPress);
            this.tbBarCode.TextChanged += new System.EventHandler(this.tbBarCode_TextChanged);
            this.tbBarCode.Enter += new System.EventHandler(this.tbBarCode_Enter);
            // 
            // timer
            // 
            this.timer.Interval = 500;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // BarCodeField
            // 
            this.Controls.Add(this.tbBarCode);
            this.Name = "BarCodeField";
            this.Size = new System.Drawing.Size(360, 20);
            this.Resize += new System.EventHandler(this.BarCodeField_Resize);
            this.Enter += new System.EventHandler(this.BarCodeField_Enter);
            this.ResumeLayout(false);

        }
        #endregion

        #endregion Generated

        #region Design-Time
        #region Property

        /// <summary>
        /// Specify the text
        /// </summary>
        private int iDigitsQuantity = 50;
        public int DigitsQuantity
        {
            get
            {
                return iDigitsQuantity;
            }
            set
            {
                if (iDigitsQuantity > 0)
                {
                    iDigitsQuantity = value;
                }
                else
                {
                    throw new Exception("BarCode DigitsQuantity must be > 0");
                }
            }
        }
        private bool bIsRequired = true;
        public bool IsRequired
        {
            set
            {
                bIsRequired = value;
            }
            get
            {
                return bIsRequired;
            }
        }
        [
        Browsable(true),
        Category("ControlProperty"),
        Description("Specifies the text.")
        ]
        public override string Text
        {
            get
            {
                return tbBarCode.Text;
            }
            set
            {
                tbBarCode.Text = value;
            }
        }


        /// <summary>
        /// property specify if entered code is correct
        /// </summary>
        [
        Browsable(false)
        ]
        public string Value
        {
            get
            {
                if (tbBarCode.Text.Length > 4 || tbBarCode.Text.Length == 0)
                {
                    return Text;
                }
                else
                {
                    tbBarCode.Focus();
                    tbBarCode.SelectAll();
                    throw new Exception("Please scan again. 5 or 6 digits must be entered.");
                }
            }
        }

        private bool bIsVariable = false;
        public bool IsVariable
        {
            get
            {
                return bIsVariable;
            }
            set
            {
                bIsVariable = value;
            }
        }

        #endregion Property

        /// <summary>
        /// definition of event
        /// </summary>
        [
        Category("ControlProperty"),
        Description("Event fired when the length of text value become equals DigitsQuantity.")
        ]
        public event EventHandler CodeEntered;

        /// <summary>
        /// Event: onResize.
        /// Ovner: this.
        /// Description: Resizing contorl for desing-time
        /// </summary>
        private void BarCodeField_Resize(object sender, System.EventArgs e)
        {
            tbBarCode.Size = Size;
        }
        #endregion Design-Time

        #region EventHandler

        /// <summary>
        /// Event: onMouseDown.
        /// Ovner: tbBarCode.
        /// Description: Select tbBarCode.Text
        /// </summary>		
        private void tbBarCode_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            tbBarCode.SelectAll();
        }

        /// <summary>
        /// Event: onTextChanged.
        /// Ovner: tbBarCode.
        /// Description: When tbBarCode.Text.Length become equals the Length, component rize the event CodeEntered
        /// </summary>
        private void tbBarCode_TextChanged(object sender, System.EventArgs e)
        {
            //			if (tbBarCode.Text.Length == iDigitsQuantity)
            //			{
            //				if(CodeEntered != null)
            //					CodeEntered(this, System.EventArgs.Empty);
            //			}
        }

        private void BarCodeField_Enter(object sender, System.EventArgs e)
        {
            tbBarCode.Select();
            tbBarCode.SelectAll();
        }
        #endregion EventHandler

        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;


        private void Initialize()
        {
            if (IsVariable)
            {
                this.tbBarCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbBarCode_KeyDown);
                this.tbBarCode.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbBarCode_MouseDown);
                this.tbBarCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbBarCode_KeyPress);
                this.tbBarCode.TextChanged += new System.EventHandler(this.tbBarCode_TextChanged);
            }
        }

        // Handle the KeyDown event to determine the type of character entered into the control.
        private void tbBarCode_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            // Initialize the flag to false.
            nonNumberEntered = false;

            // Determine whether the keystroke is a number from the top of the keyboard.
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                // Determine whether the keystroke is a number from the keypad.
                if ((e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9))
                {
                    // Determine whether the keystroke is a backspace.
                    if (e.KeyCode != Keys.Back)
                    {
                        if (!IsVariable ||
                            ((e.KeyCode != Keys.OemPeriod) &&
                            (e.KeyCode != Keys.Decimal))
                            )
                        {
                            // A non-numerical keystroke was pressed.
                            // Set the flag to true and evaluate in KeyPress event.
                            nonNumberEntered = true;
                        }
                    }
                }
            }

            if (!IsVariable)
            {
                if (e.KeyCode == Keys.Enter && tbBarCode.Text.Length > 4 && e.KeyCode != Keys.Back)
                {
                    tbBarCode.SelectAll();
                    CodeEntered(this, System.EventArgs.Empty);
                }
                if (tbBarCode.Text.Length == iDigitsQuantity && e.KeyCode != Keys.Back) tbBarCode.SelectAll();
            }
        }

        // This event occurs after the KeyDown event and can be used to prevent
        // characters from entering the control.
        private void tbBarCode_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }
        public void Clear()
        {
            tbBarCode.Text = "";
        }

        private void timer_Tick(object sender, System.EventArgs e)
        {

        }

        private void tbBarCode_Enter(object sender, System.EventArgs e)
        {
            tbBarCode.Clear();

            //            if(CodeEntered != null)
            //                CodeEntered(this, System.EventArgs.Empty);
        }
    }
}
