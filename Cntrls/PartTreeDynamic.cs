using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Cntrls
{
	/// <summary>
	/// Summary description for PartTreeDynamic.
	/// </summary>
	public class PartTreeDynamic : System.Windows.Forms.UserControl
	{
		DataTable dtParts;
		#region	 Generated
		public System.Windows.Forms.TreeView tvPartTree;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PartTreeDynamic()
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
			this.tvPartTree.HideSelection = false;
			this.tvPartTree.ImageIndex = -1;
			this.tvPartTree.Location = new System.Drawing.Point(0, 0);
			this.tvPartTree.Name = "tvPartTree";
			this.tvPartTree.SelectedImageIndex = -1;
			this.tvPartTree.Size = new System.Drawing.Size(290, 225);
			this.tvPartTree.TabIndex = 0;
			this.tvPartTree.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tvPartTree_KeyDown);
			this.tvPartTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvPartTree_AfterSelect);
			// 
			// PartTreeDynamic
			// 
			this.Controls.Add(this.tvPartTree);
			this.Name = "PartTreeDynamic";
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
		int[] countPartTypes;
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
			countPartTypes = new int[1000];
			tvPartTree.Nodes.AddRange(recursTreeFill(dtParts.Select("ParentID is NULL")));
		}

		public void Clear()
		{
			tvPartTree.Nodes.Clear();
			countPartTypes = new int[1000];
		}

		/// <summary>
		/// Extracts PartTypeID, PartID and ItemContainerName from the tag.
		/// </summary>
		/// <param name="sTag"></param>
		/// <param name="sPartTypeID"></param>
		/// <param name="sPartID"></param>
		/// <param name="sItemContainerName"></param>
		private void ParseTag(string sTag, 
			out string sPartTypeID, out string sPartID, out string sItemContainerName)
		{
			string[] sItem = sTag.Split('!');

			if (sItem.Length == 3)
			{
				sPartTypeID = sItem[0];
				sPartID = sItem[1];
				sItemContainerName = sItem[2];
			}
			else
			{
				sPartTypeID = "";
				sPartID = "";
				sItemContainerName = "";
			}
		}
		
		public void RefreshNames(DataTable dtPartTypes)
		{
			countPartTypes = new int[1000];
			recursTreeRefreshNames(dtPartTypes, tvPartTree.Nodes);
		}

		private void recursTreeRefreshNames(DataTable dtPartTypes, TreeNodeCollection nodes)
		{
			foreach(TreeNode node in nodes)
			{
				string sPartTypeID = "";
				string sPartID = "";
				string sItemContainerName = "";
				ParseTag(node.Tag.ToString(), out sPartTypeID, out sPartID, out sItemContainerName);
				DataRow partTypeRow = dtPartTypes.Select("PartTypeID = "+sPartTypeID)[0];
				int iPartTypeID = Convert.ToInt32(partTypeRow["PartTypeID"]);
				countPartTypes[iPartTypeID] ++;
				if (iPartTypeID != 15)
					node.Text = partTypeRow["PartTypeName"] + " " + countPartTypes[iPartTypeID];
				
				recursTreeRefreshNames(dtPartTypes, node.Nodes);
			}
		}

		private TreeNode[] recursTreeFill(DataRow[] drSet)
		{
			int i = 0;
			TreeNode[] tnSet = new TreeNode[drSet.Length];

			foreach(DataRow row in drSet)
			{
				int iPartTypeID = Convert.ToInt32(row["PartTypeID"]);
				
                countPartTypes[iPartTypeID] ++;
				string sItemContainerName = "";
				string s = "";

				if (iPartTypeID == 15)
				{
					ItemContainerNameForm nameForm = new ItemContainerNameForm(true);
					nameForm.ShowDialog();
					sItemContainerName = nameForm.GetItemContainerName();
					s = sItemContainerName;
				}
				else
				{
					s = row["PartTypeName"].ToString() + " " + countPartTypes[iPartTypeID];
				}

				tnSet[i] = new TreeNode(s, recursTreeFill(row.GetChildRows("PartChild")));
				//DataSet ds = new DataSet();
				//ds.Tables.Add("MyParts");
				//ds.Tables[0].Rows.Add(row.Cop);
				//gemoDream.Service.debug_DiaspalyDataSet(ds);
				s = row["PartTypeID"].ToString();
				string sPartTypeID = s;
				string sPartID = "";
				//sItemContainerName = "";

				//if (row["ItemContainerName"] != null)
				//	sItemContainerName = row["ItemContainerName"].ToString();
				//, s2 = "", s3 = "";
				string sTag = BuildTag(sPartTypeID, sPartID, sItemContainerName);
				tnSet[i].Tag = sTag;

				//tnSet[i].Tag = row["ID"];
				i++;
			}
			return tnSet;
		}

		/// <summary>
		/// Builds the tag containing PartTypeID, PartID, ItemContainerName
		/// </summary>
		/// <param name="sPartTypeID"></param>
		/// <param name="sPartID"></param>
		/// <param name="sItemContainerName"></param>
		/// <returns>tag containing nessesary info</returns>
		private string BuildTag(string sPartTypeID, string sPartID, string sItemContainerName)
		{
			//string sTag = String.Format("PartTypeID={0} PartID={1} ItemContainerName={2}",
			string sTag = String.Format("{0}!{1}!{2}",
				sPartTypeID, sPartID, sItemContainerName);
			return sTag;
		}

		public event System.EventHandler Changed;
		private void tvPartTree_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if (Changed != null )
			{
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

		private void tvPartTree_KeyDown(object sender, System.Windows.Forms.KeyEventArgs kea)
		{
			OnKeyDown(kea);
		}
	}
}
