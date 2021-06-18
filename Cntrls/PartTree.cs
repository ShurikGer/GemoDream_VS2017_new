using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Globalization;

namespace Cntrls
{
	/// <summary>
	/// Summary description for PartTree.
	/// </summary>
	public class PartTree : System.Windows.Forms.UserControl
	{
		DataTable dtParts;
		#region	 Generated
		public System.Windows.Forms.TreeView tvPartTree;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PartTree()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tvPartTree = new System.Windows.Forms.TreeView();
			this.SuspendLayout();
			// 
			// tvPartTree
			// 
			this.tvPartTree.CheckBoxes = true;
			this.tvPartTree.Location = new System.Drawing.Point(0, 0);
			this.tvPartTree.Name = "tvPartTree";
			this.tvPartTree.ShowNodeToolTips = true;
			this.tvPartTree.Size = new System.Drawing.Size(290, 225);
			this.tvPartTree.TabIndex = 0;
			this.tvPartTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvPartTree_AfterSelect);
			this.tvPartTree.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tvPartTree_KeyDown);
			// 
			// PartTree
			// 
			this.Controls.Add(this.tvPartTree);
			this.Name = "PartTree";
			this.Size = new System.Drawing.Size(290, 225);
			this.Resize += new System.EventHandler(this.PartTree_Resize);
			this.ResumeLayout(false);

		}
		#endregion

		#endregion	 Generated

		private void PartTree_Resize(object sender, System.EventArgs e)
		{
			tvPartTree.Size = new Size(Size.Width, Size.Height);
		}

		public void Initialize(DataTable dtIni)
		{
			Clear();
			dtParts = dtIni;

			if (dtParts.ChildRelations["PartChild"] == null)
			{
				DataColumn parentCol = dtParts.Columns["ID"];
				DataColumn childCol = dtParts.Columns["ParentID"];			
				dtParts.ChildRelations.Add("PartChild", parentCol, childCol);
			}
			
			tvPartTree.Nodes.AddRange(recursTreeFill(dtParts.Select("ParentID is NULL")));
		}

		public void Clear()
		{
			tvPartTree.Nodes.Clear();
		}
		private TreeNode[] recursTreeFill(DataRow[] drSet)
		{
			int i = 0;
			TreeNode[] tnSet = new TreeNode[drSet.Length];

			foreach(DataRow row in drSet)
			{
				var partName = row["Name"].ToString().ToLower();
				TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
				partName = myTI.ToTitleCase(partName);
				//partName = partName.Replace("White Diamond Stone Set", "WDS");
				//partName = partName.Replace("Color Diamond Stone Set", "CDS");
				//partName = partName.Replace("Color Stone Set", "CSS");
				//partName = partName.Replace("Colored diamond", "CD");
				tnSet[i] = new TreeNode(partName, recursTreeFill(row.GetChildRows("PartChild")));

				//tnSet[i] = new TreeNode(row["Name"].ToString(), recursTreeFill(row.GetChildRows("PartChild")));
				tnSet[i].ImageKey = row["ID"].ToString();
				tnSet[i].Tag = row["ID"];
				i++;
			}
			return tnSet;
		}

		public event System.EventHandler Changed;
		private void tvPartTree_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if (Changed != null )
			{
				foreach(TreeNode tn in tvPartTree.Nodes)
				{
					ColorChangedRecursive(tn);
				}
				SelectedNode.BackColor = System.Drawing.Color.SlateGray;
				SelectedNode.ForeColor = System.Drawing.Color.White;
				
				Changed(sender,e);
			}
		}

		[Browsable(false)]
		public TreeNode SelectedNode
		{
			get
			{
				return tvPartTree.SelectedNode;

			}
		}

		[Browsable(false)]
		public DataRow SelectedRow
		{
			get
			{
				DataRow[] drSet = dtParts.Select("ID = '" + SelectedNode.Tag.ToString() + "'");
				return drSet[0];				
			}
		}		

		public DataTable Data
		{
			get
			{
				return dtParts;
			}
		}
		public int NodesCount
		{
			get
			{
				return tvPartTree.Nodes.Count;
			}
		}
		public void ExpandTree()
		{
			tvPartTree.ExpandAll();
		}

		new public event KeyEventHandler KeyDown;

		protected override void OnKeyDown(KeyEventArgs kea)
		{
			if(KeyDown != null)
				KeyDown(this, kea);
		}
		
		private void ColorChangedRecursive(TreeNode treeNode)
		{
			treeNode.BackColor = System.Drawing.Color.Transparent;
			treeNode.ForeColor = ForeColor = System.Drawing.Color.Black;
			foreach (TreeNode tn in treeNode.Nodes)
			{
				ColorChangedRecursive(tn);
			}
		}

		private void tvPartTree_KeyDown(object sender, System.Windows.Forms.KeyEventArgs kea)
		{
			OnKeyDown(kea);
		}
	}
}
