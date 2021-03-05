using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace gemoDream
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class waitClock : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Timer timer1;
		private System.ComponentModel.IContainer components;

		public waitClock()
		{
			InitializeComponent();
			
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			/*
			string strMyDateTime =	System.DateTime.Now.Hour.ToString() + ":" +
									System.DateTime.Now.Minute.ToString() + ":" + 
									System.DateTime.Now.Second.ToString();
			*/
			this.label2.Text = System.DateTime.Now.ToString("hh:mm:ss tt");
			//this.label2.Text =  strMyDateTime;  
			
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label1.Location = new System.Drawing.Point(0, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(142, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Please wait";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
			this.label2.Location = new System.Drawing.Point(6, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(130, 12);
			this.label2.TabIndex = 1;
			this.label2.Text = "label2";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// waitClock
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 14);
			this.ClientSize = new System.Drawing.Size(142, 61);
			this.ControlBox = false;
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "waitClock";
			this.Opacity = 0.7;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Loading...";
			this.TopMost = true;
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new waitClock());
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
            if(MenuForm.isWait)  
  			{
				label2.Text = System.DateTime.Now.ToString("hh:mm:ss tt");
				/*
				label2.Text =	System.DateTime.Now.Hour.ToString() + ":" +
								System.DateTime.Now.Minute.ToString() + ":" +
								System.DateTime.Now.Second.ToString();
				*/
			}
			else
			{
				this.Dispose(true);
			}
		}
	}
}
