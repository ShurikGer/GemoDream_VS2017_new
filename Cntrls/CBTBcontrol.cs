#region Usings
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
#endregion Usings

namespace Cntrls
{
    /// <summary>
    /// Component contains ComboBox & TextBox
    /// 	/// </summary>
    public class ComboTextComponent : System.Windows.Forms.UserControl
    {
        private DataTable dtData;
        #region Generated

        private System.Windows.Forms.TextBox tbField;
        private BindingComboBox bcbField;
        internal System.Windows.Forms.Label lbStatus;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public ComboTextComponent()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                    components.Dispose();
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
            this.tbField = new System.Windows.Forms.TextBox();
            this.lbStatus = new System.Windows.Forms.Label();
            this.bcbField = new Cntrls.BindingComboBox();
            this.SuspendLayout();
            // 
            // tbField
            // 
            this.tbField.Location = new System.Drawing.Point(344, 0);
            this.tbField.MaxLength = 4;
            this.tbField.Name = "tbField";
            this.tbField.Size = new System.Drawing.Size(40, 20);
            this.tbField.TabIndex = 0;
            this.tbField.Text = "";
            this.tbField.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbField_KeyDown);
            this.tbField.TextChanged += new System.EventHandler(this.tbField_TextChanged);
            // 
            // lbStatus
            // 
            this.lbStatus.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(240)), ((System.Byte)(240)), ((System.Byte)(240)));
            this.lbStatus.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.lbStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbStatus.Location = new System.Drawing.Point(0, 24);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(655, 15);
            this.lbStatus.TabIndex = 6;
            // 
            // bcbField
            // 
            this.bcbField.CodeMember = "CustomerCode";
            this.bcbField.DefaultText = "";
            this.bcbField.DisplayMember = "CustomerName";
            this.bcbField.drvSelectedItem = null;
            this.bcbField.Filter = "";
            this.bcbField.Location = new System.Drawing.Point(0, 0);
            this.bcbField.Name = "bcbField";
            this.bcbField.Size = new System.Drawing.Size(344, 21);
            this.bcbField.TabIndex = 1;
            this.bcbField.ValueMember = "CustomerID";
            this.bcbField.SelectedIndexChanged += new System.EventHandler(this.bcbField_SelectedIndexChanged);
            // 
            // ComboTextComponent
            // 
            this.Controls.Add(this.bcbField);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.tbField);
            this.Name = "ComboTextComponent";
            this.Size = new System.Drawing.Size(656, 40);
            this.Resize += new System.EventHandler(this.ComboTextComponent_Resize);
            this.ResumeLayout(false);

        }
        #endregion
        #endregion Generated

        #region Design-Time
        public string DefaultText
        {
            get
            {
                return bcbField.DefaultText;
            }
            set
            {
                bcbField.DefaultText = value;
            }
        }

        public string SelectedCode
        {
            get
            {
                return tbField.Text;
            }
            set
            {
                if (value == "")
                {
                    try { bcbField.cbField.SelectedIndex = 0; }
                    catch { }
                    return;
                }
                bool IsExist = false;
                string Temp = "";
                DataView dvData = (DataView)bcbField.cbField.DataSource;
                foreach (DataRowView drvDataIterator in dvData)
                {
                    Temp = drvDataIterator[CodeMember].ToString();
                    if (drvDataIterator[CodeMember].ToString() == value)
                    {
                        bcbField.drvSelectedItem = drvDataIterator;
                        bcbField.Refresh();
                        IsExist = true;
                        break;
                    }
                }
                if (!IsExist)
                {
                    WrongCodeTyped(this, EventArgs.Empty);
                    throw new Exception("Customer not found.");
                }
            }
        }

        [
        Browsable(true),
        Category("ControlProperty"),
        DefaultValue(false)
        ]
        public bool InsertDefaultRow
        {
            get
            {
                return ComboField.InsertDefaultRow;
            }
            set
            {
                ComboField.InsertDefaultRow = value;
            }
        }


        //ComboField property
        [
        Browsable(true),
        DefaultValue("CustomerCode"),
        Category("ControlProperty"),
        Description("Specifies the text.")
        ]
        public Cntrls.BindingComboBox ComboField
        {
            get
            {
                return bcbField;
            }
        }


        //TextField property
        [
        Browsable(true),
        DefaultValue("CustomerCode"),
        Category("ControlProperty"),
        Description("Specifies the text.")
        ]
        public TextBox TextField
        {
            get
            {
                return tbField;
            }
        }

        [Browsable(true)]
        public string SelectedID
        {
            get
            {
                return ((DataRowView)bcbField.cbField.SelectedItem)[ValueMember].ToString();
            }
            set
            {
                ((DataRowView)bcbField.cbField.SelectedItem)[ValueMember] = value;
                bcbField.cbField.SelectedValue = value;
            }
        }
        private string sCodeMember = "CustomerCode";
        [
        DefaultValue("CustomerCode"),
        Category("ControlProperty"),
        Description("Specifies the text.")
        ]
        public string CodeMember
        {
            get
            {
                if (sCodeMember == null) return "CustomerCode";
                else return sCodeMember;
            }
            set
            {
                sCodeMember = value;
            }
        }

        [Category("ControlProperty")]
        public string ValueMember
        {
            get
            {
                return bcbField.ValueMember;
            }
            set
            {
                bcbField.ValueMember = value;
            }
        }

        [Category("ControlProperty")]
        public string DisplayMember
        {
            get
            {
                return bcbField.DisplayMember;
            }
            set
            {
                bcbField.DisplayMember = value;
            }
        }

        [Category("ControlProperty")]
        public override string Text
        {
            get
            {
                return bcbField.Text;
            }
            set
            {
                base.Text = value;
                bcbField.Text = value;
            }
        }

        [
        Browsable(true),
        Category("ControlProperty"),
        Description("Occurs whenewer 'SelectedIndex' property for cbFieldt has changed")
        ]
        public event System.EventHandler SelectedIndexChanged;
        public event System.EventHandler CodeEntered;

        [
        Browsable(true),
        Category("ControlProperty"),
        Description("Occurs when Wrong Code Typed")
        ]
        public event System.EventHandler WrongCodeTyped;
        public event EventHandler SelectionChanged;

        private void ComboTextComponent_Resize(object sender, System.EventArgs e)
        {
            if (Size.Width > 656)
            {
                int iWidth = bcbField.Size.Width - (lbStatus.Size.Width - Size.Width);
                bcbField.Size = new Size(iWidth, bcbField.Size.Height);
                tbField.Location = new Point(bcbField.Size.Width + 5, tbField.Location.Y);
                lbStatus.Size = new Size(Size.Width, lbStatus.Size.Height);
            }
            else if (Size.Width < 440)
            {
                bcbField.Size = new Size(Size.Width - tbField.Size.Width - 5, bcbField.Size.Height);
                tbField.Location = new Point(bcbField.Size.Width + 5, tbField.Location.Y);
            }
        }
        #endregion Design-Time

        #region Run-Time

        //Data Load for the Component
        public void Initialize(DataTable dtIni)
        {
            dtData = dtIni.Copy();
            bcbField.Initialize(dtData);

        }

        public event EventHandler SelectedItemChanged;

        private void bcbField_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            DataRowView drvData = (DataRowView)bcbField.cbField.SelectedItem;
            tbField.Text = drvData[CodeMember].ToString();
            //try
            //{
            //	SelectedIndexChanged(sender, e);
            //}
            //catch {}

            //Changed(EventArgs.Empty);
            RaiseSelectionChanged(EventArgs.Empty);
        }

        protected virtual void Changed(EventArgs ea)
        {
            if (SelectedItemChanged != null)
                SelectedItemChanged(this, ea);
        }

        protected virtual void RaiseSelectionChanged(EventArgs ea)
        {
            if (SelectionChanged != null)
                SelectionChanged(this, ea);
        }

        protected virtual void RaiseCodeEntered(EventArgs ea)
        {
            if (CodeEntered != null)
                CodeEntered(this, ea);
        }

        private void tbField_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                bcbField.Clear();
                DataRowView drvData = (DataRowView)bcbField.cbField.SelectedItem;
                tbField.Text = drvData[CodeMember].ToString();
            }
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    SelectedCode = tbField.Text.ToString();
                    RaiseCodeEntered(EventArgs.Empty);
                }
                catch
                {
                    tbField.SelectAll();
                }
            }
        }


        public void Clear()
        {
            bcbField.Clear();
        }

        #endregion Run-Time

        private void tbField_TextChanged(object sender, System.EventArgs e)
        {

        }
    }
}
