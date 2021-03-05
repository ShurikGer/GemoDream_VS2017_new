using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Cntrls
{
	/// <summary>
	/// Summary description for DataTree.
	/// </summary>
	public class DataTree : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.TreeView Tree;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ImageList imageList1;
		DataSet dsData;

		public DataTree()
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
			this.components = new System.ComponentModel.Container();
			this.Tree = new System.Windows.Forms.TreeView();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.SuspendLayout();
			// 
			// Tree
			// 
			this.Tree.ImageList = this.imageList1;
			this.Tree.Location = new System.Drawing.Point(0, 0);
			this.Tree.Name = "Tree";
			this.Tree.PathSeparator = ".";
			this.Tree.Size = new System.Drawing.Size(240, 192);
			this.Tree.TabIndex = 0;
			this.Tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.Tree_AfterSelect);
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(12, 11);
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// DataTree
			// 
			this.Controls.Add(this.Tree);
			this.Name = "DataTree";
			this.Size = new System.Drawing.Size(240, 192);
			this.Resize += new System.EventHandler(this.DataTree_Resize);
			this.ResumeLayout(false);

		}
		#endregion

		private void DataTree_Resize(object sender, System.EventArgs e)
		{
			Tree.Width = this.Width;
			Tree.Height = this.Height;
		}

		private DataSet GetTestDS()
		{
			DataSet dsData = new DataSet();

			//Level0
			DataRow drData;
			DataTable dtOrder = dsData.Tables.Add("0");
			dtOrder.Columns.Add("PrntID");
			dtOrder.Columns.Add("ID");
			dtOrder.Columns.Add("Name");
			//dtOrder.Columns.Add("Props");
			
			
			drData = dtOrder.NewRow();
			drData["PrntID"] = "0";
			drData["ID"] = "id0-1";
			drData["Name"] = "0-1";
			dtOrder.Rows.Add(drData);

			drData = dtOrder.NewRow();
			drData["PrntID"] = "0";
			drData["ID"] = "id0-2";
			drData["Name"] = "0-2";			
			dtOrder.Rows.Add(drData);


			//Level1
			DataTable dtLevel1 = dsData.Tables.Add("1");
			dtLevel1.Columns.Add("PrntID");
			dtLevel1.Columns.Add("ID");
			dtLevel1.Columns.Add("Name");
			//dtOrder.Columns.Add("Props");
			
			drData = dtLevel1.NewRow();
			drData["PrntID"] = "id0-1";
			drData["ID"] = "id0-1-1";
			drData["Name"] = "0-1-1";
			dtLevel1.Rows.Add(drData);

			drData = dtLevel1.NewRow();
			drData["PrntID"] = "id0-1";
			drData["ID"] = "id0-1-2";
			drData["Name"] = "0-1-2";
			dtLevel1.Rows.Add(drData);

			drData = dtLevel1.NewRow();
			drData["PrntID"] = "id0-2";
			drData["ID"] = "id0-2-1";
			drData["Name"] = "0-2-1";
			dtLevel1.Rows.Add(drData);


			//Level2
			DataTable dtLevel2 = dsData.Tables.Add("2");
			dtLevel2.Columns.Add("PrntID");
			dtLevel2.Columns.Add("ID");
			dtLevel2.Columns.Add("Name");
			//dtOrder.Columns.Add("Props");
			
			drData = dtLevel2.NewRow();
			drData["PrntID"] = "id0-1-1";
			drData["ID"] = "id0-1-1-1";
			drData["Name"] = "0-1-1-1";
			dtLevel2.Rows.Add(drData);

			drData = dtLevel2.NewRow();
			drData["PrntID"] = "id0-1-1";
			drData["ID"] = "id0-1-1-2";
			drData["Name"] = "0-1-1-2";
			dtLevel2.Rows.Add(drData);

			drData = dtLevel2.NewRow();
			drData["PrntID"] = "id0-2-1";
			drData["ID"] = "id0-2-1-1";
			drData["Name"] = "0-2-1-1";
			dtLevel2.Rows.Add(drData);
		
			return dsData;
		}

		public void SetData()
		{
			dsData = GetTestDS();
		}
		public void SetData(DataSet dsIni)
		{
			dsData = dsIni;
		}

		public void Init()
		{	
			foreach(DataTable dtLevel in dsData.Tables)
			{
				if(dtLevel.TableName == "0")
					foreach(DataRow drNode in dtLevel.Rows)
					{
						TreeNode tnParent = new TreeNode(drNode[2].ToString());
						tnParent.ImageIndex = 1;
						tnParent.Tag = drNode;
						Tree.Nodes.Add(tnParent);
						GetAllChildren(0, dsData, drNode, tnParent);
					}
			}
			Tree.ExpandAll();
			Initialized(EventArgs.Empty);
		}

		private void GetAllChildren(int iPrntTbl, DataSet dsData, DataRow drRow, TreeNode tnParent)
		{ 
			foreach(DataTable dtTable in dsData.Tables)
			{
				if(Convert.ToInt32(dtTable.TableName) == iPrntTbl + 1)
				{
					foreach(DataRow drNew in dtTable.Rows)
					{
						if(drNew[0].ToString() == drRow[1].ToString())
						{
							TreeNode tnCurrent = new TreeNode(drNew[2].ToString());
							tnCurrent.Tag = drNew;
							tnCurrent.ImageIndex = 1;
							tnParent.Nodes.Add(tnCurrent);
							GetAllChildren(Convert.ToInt32(dtTable.TableName), dsData, drNew, tnCurrent);
						}
					}
				}
			}				
		}

		public object[] GetNodeProps(TreeNode tnNode)
		{
			DataRow drData = (DataRow)tnNode.Tag;
			return drData.ItemArray;
		}

		public event EventHandler SelectionChanged;
		public event EventHandler DataInit;

		protected virtual void Initialized(EventArgs ea)
		{
			if(DataInit != null)
				DataInit(this, ea);
		}

		protected virtual void Changed(EventArgs ea)
		{
			if(SelectionChanged != null)
				SelectionChanged(this, ea);			
		}


		private void Tree_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if(e.Node.ImageIndex == 0)
				Changed(EventArgs.Empty);		
		}


		public TreeNode Selected
		{
			get
			{
				return Tree.SelectedNode;
			}
			set
			{
				Tree.SelectedNode = value;
			}
		}
								 
		public bool CheckBoxes
		{
			get
			{
				return Tree.CheckBoxes;
			}
			set
			{
				Tree.CheckBoxes = value;
			}

		}

		public TreeNode[] FindNodes(string[] Properties)
		{
			ArrayList alNodes = new ArrayList(1);
			foreach(TreeNode tnRoot in Tree.Nodes)
			{
				CheckProps(tnRoot, Properties, alNodes);
			}

			TreeNode[] nRet = new TreeNode[alNodes.Count];
			for(int i = 0; i < alNodes.Count; i++)
			{
				nRet[i] = (TreeNode)alNodes[i];
			}
			return nRet;
		}

		private void CheckProps(TreeNode tnRoot, string[] Props, ArrayList alNodes)
		{
			int iOkQ = 0;
			foreach(string Prop in Props)
				foreach(object oProp in ((DataRow)tnRoot.Tag).ItemArray)
				{
					try					
					{
						if(Prop == (string)oProp)
							iOkQ ++;						
					}
					catch
					{
					}
				}
			if(iOkQ > 0) alNodes.Add(tnRoot);
			if(tnRoot.Nodes.Count != 0)
				foreach(TreeNode tnChild in tnRoot.Nodes)
					CheckProps(tnChild, Props, alNodes);
		}

		public void ClearChecks()
		{
			Tree.Nodes.Clear();
			this.Init();
		}
		
		public DataSet Data
		{
			get
			{
				return dsData;
			}
		}
	}
}
