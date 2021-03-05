using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Cntrls
{
    /// <summary>
    /// Summary description for ItemNumberControl.
    /// </summary>
    public class ItemNumberControl : System.Windows.Forms.UserControl
    {
        private bool nonNumberEntered;

        #region Generated
        private System.Windows.Forms.TextBox tbNumItem;
        private System.Windows.Forms.Timer timer;
        private System.ComponentModel.IContainer components;

        public ItemNumberControl()
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
            this.tbNumItem = new System.Windows.Forms.TextBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tbNumItem
            // 
            this.tbNumItem.Location = new System.Drawing.Point(0, 0);
            this.tbNumItem.Name = "tbNumItem";
            this.tbNumItem.Size = new System.Drawing.Size(180, 20);
            this.tbNumItem.TabIndex = 20;
            this.tbNumItem.Text = "#####.#####.###.##";
            this.tbNumItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPrevItem_KeyDown);
            this.tbNumItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbNumItem_MouseDown);
            this.tbNumItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPrevItem_KeyPress);
            // 
            // ItemNumberControl
            // 
            this.Controls.Add(this.tbNumItem);
            this.Name = "ItemNumberControl";
            this.Size = new System.Drawing.Size(180, 20);
            this.Resize += new System.EventHandler(this.ItemNumberControl_Resize);
            this.ResumeLayout(false);

        }
        #endregion
        #endregion Generated

        #region Design-Time
        private void ItemNumberControl_Resize(object sender, System.EventArgs e)
        {
            tbNumItem.Size = new Size(Size.Width, Size.Height);
        }
        #endregion Design-Time

        #region Format //#####.#####.###.##
        #region Design-Time
        [Browsable(false)]
        public string ItemNumber
        {
            get
            {
                if ((tbNumItem.Text == "#####.#####.###.##") || (tbNumItem.Text == ""))
                {
                    return "";
                }
                return Get();
            }
            set
            {
                tbNumItem.Text = value;
            }
        }
        #endregion Design-Time

        public string Get()
        {
            Regex re10 = new Regex(@"^\d{5}\.\d{5}\.\d{3}\.\d{2}$");
            Regex re11 = new Regex(@"^\d{6}\.\d{6}\.\d{3}\.\d{2}$");
			Regex re12 = new Regex(@"^\d{7}\.\d{7}\.\d{3}\.\d{2}$");
			string sText0 = tbNumItem.Text.Trim().Replace(".", "");
			if (sText0.Trim().Length >= 7 &&   sText0.Trim().Length <= 10) sText0 = gemoDream.Service.GetItemNumberBy7digit(sText0);
		
            string sText = "";

            if (sText0.Length == 10)
            {
                sText = sText0.Substring(0, 5);
                sText += ".";
                sText += sText0.Substring(0, 5);
                sText += ".";
                sText += sText0.Substring(5, 3);
                sText += ".";
                sText += sText0.Substring(8, 2);

                if (!re10.IsMatch(sText))
                {
                    tbNumItem.Focus();
                    tbNumItem.SelectAll();
                    throw new Exception("Please type again. Acceptable formats: 12345.12345.123.12 or 1234567890");
                }
            }
            if (sText0.Length == 11)
            {
                sText = sText0.Substring(0, 6);
                sText += ".";
                sText += sText0.Substring(0, 6);
                sText += ".";
                sText += sText0.Substring(6, 3);
                sText += ".";
                sText += sText0.Substring(9, 2);

                if (!re11.IsMatch(sText))
                {
                    tbNumItem.Focus();
                    tbNumItem.SelectAll();
                    throw new Exception("Please type again. Acceptable formats: 123456.123456.123.12 or 12345678910");
                }
            }
			if (sText0.Length == 12)
			{
				sText = sText0.Substring(0, 7);
				sText += ".";
				sText += sText0.Substring(0, 7);
				sText += ".";
				sText += sText0.Substring(7, 3);
				sText += ".";
				sText += sText0.Substring(10, 2);

				if (!re12.IsMatch(sText))
				{
					tbNumItem.Focus();
					tbNumItem.SelectAll();
					throw new Exception("Please type again. Acceptable formats: 123456.123456.123.12 or 12345678910");
				}
			}

 			if (sText0.Length == 15)
            {
                sText = sText0.Substring(0, 5);
                sText += ".";
                sText += sText0.Substring(5, 5);
                sText += ".";
                sText += sText0.Substring(10, 3);
                sText += ".";
                sText += sText0.Substring(13, 2);

                if (!re10.IsMatch(sText))
                {
                    tbNumItem.Focus();
                    tbNumItem.SelectAll();
                    throw new Exception("Please type again. Acceptable formats: 123456.123456.123.12 or 12345678910");
                }
            }

			if (sText0.Length == 17)
			{
				sText = sText0.Substring(0, 6);
				sText += ".";
				sText += sText0.Substring(6, 6);
				sText += ".";
				sText += sText0.Substring(12, 3);
				sText += ".";
				sText += sText0.Substring(15, 2);

				if (!re11.IsMatch(sText))
				{
					tbNumItem.Focus();
					tbNumItem.SelectAll();
					throw new Exception("Please type again. Acceptable formats: 123456.123456.123.12 or 12345678910");
				}
			}
				if (sText0.Length == 19)
				{
					sText = sText0.Substring(0, 7);
					sText += ".";
					sText += sText0.Substring(7, 7);
					sText += ".";
					sText += sText0.Substring(14, 3);
					sText += ".";
					sText += sText0.Substring(17, 2);

					if (!re12.IsMatch(sText))
					{
						tbNumItem.Focus();
						tbNumItem.SelectAll();
						throw new Exception("Please type again. Acceptable formats: 123456.123456.123.12 or 12345678910");
					}
  				}
            return sText;
        }


        //            Regex re = new Regex(@"^\d{5}\.\d{5}\.\d{3}\.\d{2}$");
        //			string sText = tbNumItem.Text;
        //
        //			if (sText.Length == 10) 
        //			{
        //				sText = tbNumItem.Text.Substring(0,5);
        //				sText += ".";
        //				sText += tbNumItem.Text.Substring(0,5);
        //				sText += ".";
        //				sText += tbNumItem.Text.Substring(5,3);
        //				sText += ".";
        //				sText += tbNumItem.Text.Substring(8,2);
        //			}
        //
        //			if (re.IsMatch(sText))
        //			{
        //				return sText;
        //			}
        //			else
        //			{
        //				tbNumItem.Focus();
        //				tbNumItem.SelectAll();
        //				throw new Exception("Please type again. Acceptable formats: #####.#####.###.##  or ##########");
        //			}			


        #endregion Format #####.#####.###.##

        private void tbPrevItem_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            // Initialize the flag to false.
            nonNumberEntered = false;
            // Determine whether the keystroke is a number or backspace or dot.
            if ((e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9) &&
                (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9) &&
                (e.KeyCode != Keys.Back) &&
                (e.KeyCode != Keys.OemPeriod) &&
                (e.KeyCode != Keys.Decimal))
            {
                nonNumberEntered = true;
            }
            if ((e.KeyCode == Keys.Enter) && (CodeEntered != null))
            {
                CodeEntered(this, e);
            }
        }

        public event System.EventHandler CodeEntered;

        private void tbPrevItem_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = nonNumberEntered;
        }

        private void tbNumItem_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (tbNumItem.Text == "#####.#####.###.##")
                tbNumItem.Text = "";
            tbNumItem.SelectAll();
        }

        public void Get(string sNumItem)
        {
            sNumItem = Get();
        }

        public void Clear()
        {
            ItemNumber = "#####.#####.###.##";
        }

        public override String Text
        {
            get
            {
                return tbNumItem.Text;
            }
        }


    }
}
