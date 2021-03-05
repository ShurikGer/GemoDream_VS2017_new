using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace Cntrls
{
	/// <summary>
	/// Summary description for OrdersTree.
	/// </summary>
		
	public class OrderTreeByMemoBatch : System.Windows.Forms.UserControl
	{	
		public struct TableList 
		{
			public static string[] Customer = {"4","tblCustomer"};			
			public static string[] Order = {"3","tblOrder"};
			public static string[] Batch = {"2","tblBatch"};
			public static string[] Item = {"1","tblItem"};
			public static string[] Document = {"5","tblDocument"};
		} ;
		public static string[] TableNames = {"tblItem","tblBatch","tblOrder","tblCustomer","tblDocument"};
		// I hate static and const field
		public static int GetTableCode(string tblName)
		{
			
			for(int i=0 ; i < TableNames.Length ; i++)
			{
				if (TableNames[i] == tblName)
				{
					return ++i;
				}
			}
			return 0;
		}

		public DataSet dsOrderTree;
		private ArrayList onDeletedNodes = new ArrayList();
		private string FirstTBLName = "tblOrder";
		private DataSet dsOutput;
		private DataSet dsOutputSelected;
		protected bool IsSearchingMode = false;
		public DataTable dtSatets;

		#region Generated

		private System.Windows.Forms.TreeView tvOrders;
		private System.Windows.Forms.ImageList ilTreeNodes;
		private System.ComponentModel.IContainer components;

		public OrderTreeByMemoBatch()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OrderTreeByMemoBatch));
			this.tvOrders = new System.Windows.Forms.TreeView();
			this.ilTreeNodes = new System.Windows.Forms.ImageList(this.components);
			this.SuspendLayout();
			// 
			// tvOrders
			// 
			this.tvOrders.CheckBoxes = true;
			this.tvOrders.HideSelection = false;
			this.tvOrders.ImageList = this.ilTreeNodes;
			this.tvOrders.Location = new System.Drawing.Point(0, 0);
			this.tvOrders.Name = "tvOrders";
			this.tvOrders.SelectedImageIndex = 7;
			this.tvOrders.Size = new System.Drawing.Size(655, 185);
			this.tvOrders.TabIndex = 3;
			this.tvOrders.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tvOrders_AfterExpand);
			this.tvOrders.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvOrders_AfterCheck);
			this.tvOrders.DoubleClick += new System.EventHandler(this.tvOrders_DoubleClick);
			this.tvOrders.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvOrders_AfterSelect);
			this.tvOrders.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvOrders_BeforeSelect);
			// 
			// ilTreeNodes
			// 
			this.ilTreeNodes.ImageSize = new System.Drawing.Size(16, 16);
			this.ilTreeNodes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeNodes.ImageStream")));
			this.ilTreeNodes.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// OrderTreeByMemoBatch
			// 
			this.Controls.Add(this.tvOrders);
			this.Name = "OrderTreeByMemoBatch";
			this.Size = new System.Drawing.Size(655, 185);
			this.Resize += new System.EventHandler(this.OrderTreeByMemoBatch_Resize);
			this.ResumeLayout(false);

		}
		#endregion
		#endregion Generated

		#region Design-time
		private bool bIsDocumentGhost = false;
		public bool IsDocumentGhost
		{
			set
			{
				bIsDocumentGhost = value;
				tvOrders.Tag = value;
			}
			get
			{
				return bIsDocumentGhost;
			}
		}

		public bool CheckBoxes
		{
			get 
			{
				return tvOrders.CheckBoxes;
			}
			set
			{
				tvOrders.CheckBoxes = value;
			}
		}
		private bool bIsExpand = false;
		public bool IsExpand
		{
			get
			{
				return bIsExpand;
			}
			set
			{
				bIsExpand = value;
			}
		}
		private bool bShowColorAndClarity = true;
		public bool ShowColorAndClarity
		{
			get
			{
				return bShowColorAndClarity;
			}
			set
			{
				bShowColorAndClarity = value;
			}
		}
		private void OrdersTree_Resize(object sender, System.EventArgs e)
		{
			tvOrders.Size = new Size(this.Size.Width, this.Size.Height);		
		}

		public event EventHandler SelectedItemChanged;
		private void tvOrders_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{		
			if(SelectedItemChanged != null)
			{				
				SelectedItemChanged(this, e);				
			}
		}

		public event EventHandler RealDoubleClick;
		protected virtual void OnRealDoubleClick(EventArgs ea)
		{
			if(RealDoubleClick != null)
				RealDoubleClick(this, EventArgs.Empty);
		}


		public event TreeViewCancelEventHandler BeforeSelect;
		private void tvOrders_BeforeSelect(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{
			if(BeforeSelect != null)
				BeforeSelect(sender, e);
		}

		private void tvOrders_DoubleClick(object sender, System.EventArgs e)
		{
			OnRealDoubleClick(EventArgs.Empty);
		}
		#endregion Design-time

		#region Run-Time

		#region Initialize
		public void Initialize()
		{					
			Initialize(dsOrderTree);
		}
		public void Initialize(DataSet dsData)
		{
			Initialize(dsData, FirstTBLName);
		}
		public void Initialize(DataSet dsData, string sTableName)
		{
			tvOrders.BeginUpdate();
			Clear();
			if (dsData.Tables["States"] !=null)
			{
				dtSatets = dsData.Tables["States"];
				dsData.Tables.Remove(dtSatets);
			}
			FirstTBLName = sTableName;
			dsOrderTree = dsData;
			
			First(sTableName);

			if (IsExpand) 
				tvOrders.ExpandAll();
			tvOrders.EndUpdate();

		}
		public bool IsInitialize
		{
			get 
			{
				return (tvOrders.Nodes.Count>0);
			}
		}
		
		private DataSet GetTestDS()
		{
			DataSet dsData = new DataSet();

			DataRow drData;
			DataTable dtOrder = dsData.Tables.Add("tblOrder");
			dtOrder.Columns.Add("ID");
			dtOrder.Columns.Add("Name");
			dtOrder.Columns.Add("Code");
			dtOrder.Columns.Add("SateCode");
			dtOrder.Columns.Add("IconIndex");			
			
			drData = dtOrder.NewRow();
			drData["ID"] = "1";
			drData["Name"] = "02000.02000";
			drData["SateCode"] = "closed";
			drData["IconIndex"] = "0";
			drData["Code"] = "02000";
			dtOrder.Rows.Add(drData);

			drData = dtOrder.NewRow();
			drData["ID"] = "2";
			drData["Name"] = "02001.02001";
			drData["SateCode"] = "closed";
			drData["IconIndex"] = "1";
			drData["Code"] = "02001";
			dtOrder.Rows.Add(drData);

			/*
						DataTable dtEntryBatch = dsData.Tables.Add("tblEntryBatch");
						dtEntryBatch.Columns.Add("ID");
						dtEntryBatch.Columns.Add("ParentID");
						dtEntryBatch.Columns.Add("Name");
						dtEntryBatch.Columns.Add("SateCode");
						dtEntryBatch.Columns.Add("IconIndex");

						drData = dtEntryBatch.NewRow();
						drData["ID"] = "1";
						drData["ParentID"] = "1";
						drData["Name"] = "02000.03000";
						drData["SateCode"] = "open";
						drData["IconIndex"] = "3";
						dtEntryBatch.Rows.Add(drData);

			*/

			DataTable dtBatch = dsData.Tables.Add("tblBatch");
			dtBatch.Columns.Add("ID");
			dtBatch.Columns.Add("ParentID");
			dtBatch.Columns.Add("Name");
			dtBatch.Columns.Add("Code");
			dtBatch.Columns.Add("SateCode");
			dtBatch.Columns.Add("IconIndex");

			drData = dtBatch.NewRow();
			drData["ID"] = "1";
			drData["ParentID"] = "1";
			drData["Name"] = "02000.02000.002";
			drData["Code"] = "002";
			drData["SateCode"] = "open";
			drData["IconIndex"] = "6";
			dtBatch.Rows.Add(drData);

			DataTable dtItem = dsData.Tables.Add("tblItem");
			dtItem.Columns.Add("ID");
			dtItem.Columns.Add("ParentID");
			dtItem.Columns.Add("Name");
			dtItem.Columns.Add("Code");
			dtItem.Columns.Add("SateCode");
			dtItem.Columns.Add("IconIndex");

			drData = dtItem.NewRow();
			drData["ID"] = "1";
			drData["ParentID"] = "1";
			drData["Name"] = "02000.02000.002.01";
			drData["Code"] = "01";
			drData["SateCode"] = "1";
			drData["IconIndex"] = "10";
			dtItem.Rows.Add(drData);
			
			drData = dtItem.NewRow();
			drData["ID"] = "2";
			drData["ParentID"] = "1";
			drData["Name"] = "02000.02000.002.02";
			drData["Code"] = "02";
			drData["SateCode"] = "1";
			drData["IconIndex"] = "9";
			dtItem.Rows.Add(drData);

			DataTable dtDocument = dsData.Tables.Add("tblDocument");
			dtDocument.Columns.Add("ID");
			dtDocument.Columns.Add("ItemID");
			dtDocument.Columns.Add("OrderID");
			dtDocument.Columns.Add("EntryBatchID");
			dtDocument.Columns.Add("BatchID");
			dtDocument.Columns.Add("Name");
			dtDocument.Columns.Add("Code");
			dtDocument.Columns.Add("SateCode");
			dtDocument.Columns.Add("IconIndex");
			
			drData = dtDocument.NewRow();
			drData["ID"] = "1";			
			drData["OrderID"] = "1";
			drData["Name"] = "A02000.02000";
			drData["SateCode"] = "inProccess";
			drData["IconIndex"] = "12";
			dtDocument.Rows.Add(drData);

			drData = dtDocument.NewRow();
			drData["ID"] = "2";			
			drData["BatchID"] = "1";
			drData["Name"] = "A02000.02000.002";
			drData["SateCode"] = "inProccess";
			drData["IconIndex"] = "12";
			dtDocument.Rows.Add(drData);

			drData = dtDocument.NewRow();
			drData["ID"] = "3";			
			drData["ItemID"] = "1";
			drData["Name"] = "A02000.02000.002.01";
			drData["SateCode"] = "inProccess";
			drData["IconIndex"] = "12";
			dtDocument.Rows.Add(drData);

			//Relation
			DataRelation drel;
			DataColumn parentCol;
			DataColumn childCol;
			/*			
						parentCol = dsData.Tables["tblOrder"].Columns["ID"];
						childCol = dsData.Tables["tblEntryBatch"].Columns["ParentID"];			
						drel = new DataRelation("Order_EntryBacth", parentCol, childCol);
						dsData.Relations.Add(drel);

						parentCol = dsData.Tables["tblEntryBatch"].Columns["ID"];
						childCol = dsData.Tables["tblBatch"].Columns["ParentID"];			
						drel = new DataRelation("EntryBatch_Batch", parentCol, childCol);
						dsData.Relations.Add(drel);
			*/

			parentCol = dsData.Tables["tblOrder"].Columns["ID"];
			childCol = dsData.Tables["tblBatch"].Columns["ParentID"];			
			drel = new DataRelation("Order_EntryBacth", parentCol, childCol);
			dsData.Relations.Add(drel);

			parentCol = dsData.Tables["tblBatch"].Columns["ID"];
			childCol = dsData.Tables["tblItem"].Columns["ParentID"];			
			drel = new DataRelation("Batch_Item", parentCol, childCol);
			dsData.Relations.Add(drel);

			parentCol = dsData.Tables["tblItem"].Columns["ID"];
			childCol = dsData.Tables["tblDocument"].Columns["ItemID"];			
			drel = new DataRelation("Item_Document", parentCol, childCol);
			dsData.Relations.Add(drel);

			parentCol = dsData.Tables["tblOrder"].Columns["ID"];
			childCol = dsData.Tables["tblDocument"].Columns["OrderID"];			
			drel = new DataRelation("Order_Document", parentCol, childCol);
			dsData.Relations.Add(drel);

			//auto generate new field. 
			foreach(DataTable table in dsData.Tables)
			{
				table.Columns.Add("SysCode");
				table.Columns.Add("Hide");
				
				int i = 0;
				foreach(DataRow row in table.Rows)
				{
					row["SysCode"] = i.ToString();
					i++;
					row["Hide"] = "0";
				}
				/*
								DataColumn[] keys = new DataColumn[1];
								keys[0] = table.Columns["SysCode"];
								table.PrimaryKey = keys;
				*/
			}
			return dsData;
		}
		
		#endregion Initialize

		#region FillControlWithData
		private void First(string sTableName)
		{
			foreach(DataRow row in dsOrderTree.Tables[sTableName].Rows)
			{
				if (row["Hide"].ToString() == "0")
				{
					OrderNode onOrder = Third(row);
					tvOrders.Nodes.Insert(tvOrders.Nodes.Count, onOrder);
				}
			}
		}

		private OrderNode[] Second(DataRow[] drNodes)
		{
			int i = 0;
			#region
			/*
			if(drNodes != null && drNodes.Length>0 && drNodes[0].Table.TableName == "tblItem")
			{
				try
				{
					if(drNodes.Length < 50)
					{
						DataTable dt = drNodes[0].Table.Copy();
						dt.Rows.Clear();
						//DataRow dra = 
						//dt.Rows.Add(drNodes[0].Table.NewRow());
						foreach(DataRow dr in drNodes)
						{
							DataRow d = dr.Table.NewRow();
							dt.Rows.Add(d);
							dt.AcceptChanges();
						}
						DataRow[] drs = dt.Select("","Code");
						drNodes = drs;
					}
				}
				catch(Exception ex)
				{
					string msg = ex.Message;
				}
			}
			*/
			#endregion
			OrderNode[] onArray = new OrderNode[drNodes.Length];
			
			foreach(DataRow row in drNodes)
			{
				if (row["Hide"].ToString() == "0")
				{
					onArray[i] = Third(row);
					i++;					
				}
			}
			return onArray;
		}

		private OrderNode Third(DataRow row)
		{	
			OrderNode node = new OrderNode(row, ShowColorAndClarity);
			if ((IsDocumentGhost) && (row.Table.TableName == "tblDocument"))
			{
				node.IsGhost=true;
			}
			foreach(DataRelation rel in row.Table.ChildRelations)
			{	
				try
				{
					node.Nodes.AddRange(Second(row.GetChildRows(rel)));
				}
				catch (Exception exc)
				{
					//	Catch when onArray.Length to Large
				}
			}
							
			return node;
		}

		#endregion FillControlWithData

		#region DisplayCheckedBehaviour
		protected virtual void tvOrders_AfterCheck(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			// The code only executes if the user caused the checked state to change.
			if((e.Action != TreeViewAction.Unknown) || IsSearchingMode)
			{				
				IsSearchingMode = false;
				if(e.Node.Nodes.Count > 0)
				{
					/* Calls the CheckAllChildNodes method, passing in the current 
					Checked value of the TreeNode whose checked state changed. */
					this.CheckAllChildNodes(e.Node, e.Node.Checked);
				}
				((OrderNode)e.Node).IsChecked = e.Node.Checked;
				e.Node.ExpandAll();
			}		
		}
		 

		// Updates all child tree nodes recursively.
		protected virtual void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
		{
			foreach(TreeNode node in treeNode.Nodes)
			{
				node.Checked = nodeChecked;
				((OrderNode)node).SetChecked(nodeChecked); 
				if(node.Nodes.Count > 0)
				{
					// If the current node has child nodes, call the CheckAllChildsNodes method recursively.
					this.CheckAllChildNodes(node, nodeChecked);
				}
			}
		}


		#endregion DisplayCheckedBehaviour

		#region GetData
		public DataSet Get()
		{
			dsOutput = dsOrderTree.Clone();
			foreach(OrderNode onObject in tvOrders.Nodes)
			{
				this.InsertRow(onObject);
			}
			return dsOutput;
		}

		public DataSet GetTotalOrder()
		{
			dsOutput = dsOrderTree.Clone();
			foreach(OrderNode onObject in tvOrders.Nodes)
			{
				if (!onObject.IsChecked)
					onObject.Checked = true;
				this.InsertRow(onObject);
			}
			return dsOutput;		
		}

		private void InsertRow (OrderNode onObject)
		{
			if (onObject.IsChecked)
			{
				DataTable dtCurTable = dsOutput.Tables[onObject.drNode.Table.TableName];
				dtCurTable.Rows.Add(onObject.drNode.ItemArray);
			}
			foreach(OrderNode onChild in onObject.Nodes)
			{
				this.InsertRow(onChild);
			}
		}
		#endregion GetData

		#region GetCheckedData
		public DataSet GetChecked()
		{
			dsOutput = dsOrderTree.Clone();			
			dsOutput.Relations.Clear();
			foreach(DataTable table in dsOutput.Tables)
			{
				table.Constraints.Clear();
			}

			foreach(OrderNode onObject in tvOrders.Nodes)
			{
				this.InsertCheckedRow(onObject);
			}
			return dsOutput;
		}

		private void InsertCheckedRow (OrderNode onObject)
		{
			if (onObject.Checked)
			{
				DataTable dtCurTable = dsOutput.Tables[onObject.drNode.Table.TableName];
				dtCurTable.Rows.Add(onObject.drNode.ItemArray);
			}
			foreach(OrderNode onChild in onObject.Nodes)
			{
				this.InsertCheckedRow(onChild);
			}
		}
		#endregion GetCheckedData


		#region SelectNode
		public void SelectNode(string sNodeCode)
		{
			SelectNode(sNodeCode, false);
		}
		public void SelectNode(string sNodeCode, bool IsSub )
		{
			OrderNode onSelectedNode = GetNode(tvOrders.Nodes, sNodeCode,IsSub);
			IsSearchingMode = true;
			try
			{
				onSelectedNode.Checked = true;			
			}
			catch(Exception exc)
			{
				MessageBox.Show(exc.Message, "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			tvOrders.SelectedNode = onSelectedNode;
		}

		public void RealSelectNode(string sNodeCode)
		{
			OrderNode onSelectedNode = GetNode(tvOrders.Nodes, sNodeCode, false);
			IsSearchingMode = true;
			tvOrders.SelectedNode = onSelectedNode;
		}

		public void Expand()
		{
			tvOrders.SelectedNode.Expand();
			foreach(TreeNode tvn in tvOrders.SelectedNode.Nodes)
				tvn.Expand();
		}

		public void ExpandOneLevel()
		{
			tvOrders.SelectedNode.Expand();
		}

		public void ExpandAll()
		{
			tvOrders.ExpandAll();
		}

		public void CollapseAll()
		{
			tvOrders.CollapseAll();
		}

		private OrderNode GetNode(TreeNodeCollection onArray, string sNodeCode, bool IsSub)
		{
			foreach(OrderNode oNode in onArray)
			{
				int strLen = oNode.NodeCode.Length;
				if (IsSub)
				{
					string dot = ".";
					if(Char.IsLetter(sNodeCode,0)) {dot = "";}
					string OriginalCode = dot+oNode.NodeCode+dot;
					string LocalCode = dot+sNodeCode+dot;
					
					if (OriginalCode.IndexOf(LocalCode)>(-1))
					{
						return oNode;
					}
				}
				else
				{
					/**
					 * For accelerate this function replace recursion with cycle with known
					 * tree structure (Order-Batch-Item)
					 * acceleration reaches 500% depending on order position in tree (last order - max acceleration)
					 * by vetal_242
					 * 16.02.2006
					 * */
					if (oNode.NodeCode.Equals(sNodeCode.Substring(0, strLen)))
					{
						if(strLen == sNodeCode.Length)
						{
							return oNode;				
						}
						else
						{
							foreach(OrderNode oNode1 in oNode.Nodes)
							{
								int strLen1 = oNode1.NodeCode.Length;
								if(oNode1.NodeCode.Equals(sNodeCode.Substring(0, strLen1)))
								{
									if(strLen1== sNodeCode.Length)
									{
										return oNode1;
									}
									else
									{
										foreach(OrderNode oNode2 in oNode1.Nodes)
										{
											int strLen2 = oNode2.NodeCode.Length;
											if(oNode2.NodeCode.Equals(sNodeCode.Substring(0, strLen2)))
											{
												if(strLen2 == sNodeCode.Length)
												{
													return oNode2;
												}
											}
										}
									}
								}
							}
						}
					}
				}
				try
				{
					if(IsSub)
					{
						return GetNode(oNode.Nodes, sNodeCode, IsSub);
					}
				}
				catch{}
			}
			throw new Exception("Selected node doesn't exist");
		}

		#endregion SelectNode

		#region GetSelectedNode
		public DataSet GetSelected()
		{
			dsOutputSelected = dsOrderTree.Clone();
			OrderNode onCurrentSelected = Selected;

			BuildParent(onCurrentSelected);			

			foreach(OrderNode onChild in onCurrentSelected.Nodes)
			{				
				BuildChildren(onChild);
			}
			return dsOutputSelected;
		}
		
		private void BuildParent(OrderNode onObject)
		{
			if(onObject.Parent!= null && 
				onObject.Parent.GetType() == typeof(OrderNode))
			{
				BuildParent((OrderNode)onObject.Parent);
			}

			DataTable dtCurTable = dsOutputSelected.Tables[onObject.drNode.Table.TableName];
			dtCurTable.Rows.Add(onObject.drNode.ItemArray);				

		}

		private void BuildChildren(OrderNode onObject)
		{
			DataTable dtCurTable = dsOutputSelected.Tables[onObject.drNode.Table.TableName];
			dtCurTable.Rows.Add(onObject.drNode.ItemArray);			
			foreach(OrderNode onChild in onObject.Nodes)
			{
				this.BuildChildren(onChild);
			}
		}
		
		[Browsable(false)]
		public OrderNode Selected
		{
			get
			{
				return ((OrderNode)tvOrders.SelectedNode);				
			}
			set
			{
				tvOrders.SelectedNode = value;
			}
		}
		
		#endregion GetSelectedNode

		public void Clear()
		{
			if (IsInitialize)
			{
				tvOrders.Nodes.Clear();
			}
		}
		
		
		#region AddNodes
		private void InsertNode(DataTable table, string ParentID)
		{			
			foreach(DataRow drItem in table.Rows)
			{
				int MaxID;
				try	{MaxID = Convert.ToInt32(dsOrderTree.Tables[table.TableName].Compute("Max(ID)",""));}
				catch{MaxID = 0;}
				drItem["ID"] = Convert.ToString(MaxID+1);

				DataRow drItemNew = dsOrderTree.Tables[table.TableName].NewRow();
				drItemNew.ItemArray = drItem.ItemArray;
				if (ParentID != null){drItemNew["ParentID"] = ParentID;}
							
				DataRow[] drIsPresence = drItemNew.Table.Select("Code = " + drItemNew["Code"]);
				if (drIsPresence.Length == 0 )
				{
					dsOrderTree.Tables[table.TableName].Rows.Add(drItemNew);
				}
				else
				{					
					dsOrderTree.Tables[table.TableName].Rows.Add(drItemNew);

					DataRelation relParent = drItemNew.Table.ParentRelations[0];
					string sParentName = drItemNew.GetParentRow(relParent)["Name"].ToString();
					int iNewCode = Convert.ToInt32(drItemNew.Table.Compute("Max(Code)","ParentID = '" + drItemNew["ParentID"] + "'"))+1;
					
					string sNewCode = iNewCode.ToString();
					
					for (int i = sNewCode.Length; i < drItemNew["Code"].ToString().Length; i++)
					{
						sNewCode = "0"+sNewCode;
					}

					drItemNew["Code"] = sNewCode;
					drItemNew["Name"] = sParentName + "." + sNewCode;
				}				
			}
		}

		public void InsertBatch(DataSet dsBatch)
		{
			InsertNode(dsBatch.Tables[TableList.Batch[1]],null);
			InsertNode(dsBatch.Tables[TableList.Item[1]],null);

			Initialize(dsOrderTree);
		}

		public void InsertItem(DataSet dsItem, DataRow dtBatch)
		{
			InsertNode(dsItem.Tables[TableList.Item[1]],dtBatch["ID"].ToString());
			Initialize(dsOrderTree);			
		}

		public void ReformItemName()
		{
			foreach(DataRow drNewBatch in dsOrderTree.Tables[TableList.Batch[1]].Rows)
			{
				DataRow[] drNewItems = drNewBatch.GetChildRows("Batch_Item");
				int i = 0;
				foreach(DataRow drNewItem in drNewItems)
				{
					i++;
					drNewItem["Code"] = i;
					drNewItem["Name"] = gemoDream.GraderLib.GetCorrectFullCodeString(
						Convert.ToInt32(drNewItem["OrderCode"]), 
						Convert.ToInt32(drNewItem["OrderCode"]), 
						Convert.ToInt32(drNewItem["BatchCode"]), 
						Convert.ToInt32(drNewItem["Code"]));
				}
			}
			Initialize();
		}


		private OrderNode GetSelectedNode(OrderNode onObject, string NodeType)
		{
			if (onObject.tblName == NodeType)
			{
				return onObject;
			}
			return GetSelectedNode((OrderNode)onObject.Parent,NodeType);
		}		
		public OrderNode SelectedOrder
		{
			get
			{
				return GetSelectedNode(Selected, TableList.Order[1]);
			}
		}
		public OrderNode SelectedBatch
		{
			get
			{
				return GetSelectedNode(Selected, TableList.Batch[1]);
			}
		}


		#endregion AddNodes

		#region DeleteChecked
		public void DeleteChecked()
		{		
			foreach(OrderNode onObject in tvOrders.Nodes)
			{
				this.DeleteCheckedRow(onObject);
			}
			Initialize(dsOrderTree);
		}

		private void DeleteCheckedRow(OrderNode onObject)
		{
			if (onObject.Checked)
			{
				onObject.drNode.Delete();
			}
			else
			{
				foreach(OrderNode onChild in onObject.Nodes)
				{
					this.DeleteCheckedRow(onChild);
				}
			}
		}
	
		#endregion DeleteChecked

		#region Delete Checked from Nodes
		public void DeleteCheckedFromNodes()
		{		
			foreach(OrderNode onObject in tvOrders.Nodes)
			{
				this.DeleteCheckedNode(onObject);
			}
			//	Initialize(dsOrderTree);
		}

		private void DeleteCheckedNode(OrderNode onObject)
		{
			if (onObject.Checked)
			{
				onObject.onRemove();
				onDeletedNodes.Add(onObject);
			}
			else
			{
				foreach(OrderNode onChild in onObject.Nodes)
				{
					this.DeleteCheckedNode(onChild);
				}
			}
		}

		#endregion 

		#region Hide Checked Row

		public void HideCheckedRow()
		{
			foreach(OrderNode onObject in tvOrders.Nodes)
			{
				this.HideCheckedRow_Second(onObject);
			}
			Initialize(dsOrderTree);
		}

		private void HideCheckedRow_Second(OrderNode onObject)
		{
			if (onObject.Checked)
			{
				onObject.drNode["Hide"] = "1";
			}
			
			foreach(OrderNode onChild in onObject.Nodes)
			{
				this.HideCheckedRow_Second(onChild);
			}
			
		}

		#endregion 

		#region UnHideRow
		public void UnHideRow(DataSet dsVisibleRow)
		{
			foreach(DataTable table in dsOrderTree.Tables)
			{
				foreach(DataRow row in table.Rows)
				{
					string criteria = "SysCode = '" + row["SysCode"].ToString()+"'";
					DataRow[] drPresence = dsVisibleRow.Tables[table.TableName].Select(criteria);
					
					if (drPresence.Length > 0)
					{	
						row["Hide"]= "0";
						DataRow NodeRow = row;
						while (NodeRow.Table.ParentRelations.Count > 0)
						{							
							DataRow ParentRow;
							foreach(DataRelation rel in NodeRow.Table.ParentRelations)
							{
								try
								{									
									ParentRow = NodeRow.GetParentRow(rel);
									NodeRow["Hide"]= "0";
									//string sTmp = ParentRow["Hide"].ToString();	// try to execute exception
									// It's good idea to check if sTmp == 0 then all other parent shold be visible (hide=0) too.
									// but for confidence i check all parent.
									NodeRow = ParentRow;
									break;
								}
								catch{}								
							}
						}
					}
				}
			}
			Initialize(dsOrderTree);
		}

		#endregion 

		#region ChangeType

		private void ChangeType(OrderNode node, string type)
		{
			node.drNode["StateCode"] = type;
			DataRow row = dtSatets.Select("StateCode = " + type + " and StateTargetCode = " + node.tblCode)[0];
			node.drNode["IconIndex"] = row["IconIndex"];
			node.ImageIndex = Convert.ToInt32(row["IconIndex"]);
			node.SelectedImageIndex = node.ImageIndex;
		}

		public void ChangeTypeSelected (string type)
		{
			ChangeType(Selected, type);
		}

		public void ChangeTypeChecked (string type)
		{
			foreach(OrderNode node in  tvOrders.Nodes)
			{
				OrderNode ChildNode = (OrderNode)node;

				if (ChildNode.Checked)
				{
					ChangeType(ChildNode, type);					
				}
				ChangeTypeCheckedSecond(ChildNode, type);			
			}
		}

		public void ChangeTypeCheckedSecond (OrderNode node, string type)
		{
			foreach(OrderNode ChildNode in  node.Nodes)
			{				
				if (ChildNode.Checked)
				{
					ChangeType(ChildNode, type);	
				}
				ChangeTypeCheckedSecond(ChildNode, type);
			}
		}
		#endregion ChangeType

		public event EventHandler AfterExpand;
		private void tvOrders_AfterExpand(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if(AfterExpand != null)
			{				
				AfterExpand(this, e);				
			}			
		}

		#endregion
	}

	#region Class OrderNode
	public class OrderNode:System.Windows.Forms.TreeNode
	{			
		public OrderNode(DataRow drData, OrderNode[] onArray):base(drData["Name"].ToString(), onArray)
		{
			Initialize(drData);
		}

		/*
		public OrderNode(DataRow drData, bool bShowColorAndClarity):base(drData["Name"].ToString())
		{
			if(drData["Name"].ToString().Length==18 && bShowColorAndClarity)
			{
				if( drData["Weight"] != null && drData["Weight"] != DBNull.Value)
				{
					this.Text = this.Text + " " + drData["Weight"].ToString() + " " + drData["WeightUnitName"].ToString();
				}
				if( drData["Color"] != null && drData["Color"] != DBNull.Value || drData["Clarity"] != null && drData["Clarity"] != DBNull.Value )
				{
					this.Text = this.Text + " (";
					if( drData["Color"] != null && drData["Color"] != DBNull.Value )
						this.Text = this.Text + drData["Color"].ToString();
					this.Text = this.Text + "/";
					if( drData["Clarity"] != null && drData["Clarity"] != DBNull.Value )
						this.Text = this.Text + drData["Clarity"].ToString();
					this.Text = this.Text + ")";
				}
			}
			Initialize(drData);
		}
		*/

		public OrderNode(DataRow drData, bool bShowColorAndClarity):base(drData["Name"].ToString())
		{
			
			if(drData["Name"].ToString().Length==11)
			{
				try
				{
					if (drData["CreateDate"] != DBNull.Value)
						this.Text = this.Text + " (" + drData["CreateDate"].ToString() + ")";
					else
						this.Text = this.Text + " (" + "No Date" + ")";

					if (drData["Memo"] != DBNull.Value)
					{
						if (drData["Memo"].ToString().Trim() != "")
							this.Text = this.Text + " (Memo: " + drData["Memo"].ToString().Trim() + ")";
					}
				}
				catch {}
			
			}

			if(drData["Name"].ToString().Length==15)
				try
				{
					if (drData["MemoNumber"] != DBNull.Value)
					{
						if (drData["MemoNumber"].ToString().Trim() != "")
							this.Text = this.Text + " (Memo: " + drData["MemoNumber"].ToString().Trim() + ")";
					}
				}
				catch{}

			if(drData["Name"].ToString().Length==18 && bShowColorAndClarity)
			{
				string sItemNumber = drData["Name"].ToString();
				if( drData["Weight"] != null && drData["Weight"] != DBNull.Value)
				{
					this.Text = this.Text + " " + drData["Weight"].ToString() + " " + drData["WeightUnitName"].ToString();
				}
				if( drData["Color"] != null && drData["Color"] != DBNull.Value && drData["Color"].ToString() != "" ||
					drData["Clarity"] != null && drData["Clarity"] != DBNull.Value && drData["Clarity"].ToString() != "" ||
					drData["KM"] != null && drData["KM"] != DBNull.Value && drData["KM"].ToString() != "" ||
					drData["LD"] != null && drData["LD"] != DBNull.Value && drData["LD"].ToString() != "")
				{
					this.Text = this.Text + " (";
					if (drData["KM"] != null && drData["KM"] != DBNull.Value && drData["KM"].ToString() != "")
					{
						this.Text = this.Text + drData["KM"].ToString() + " ";
						this.BackColor = System.Drawing.Color.Yellow;
					}
					if (drData["LD"] != null && drData["LD"] != DBNull.Value && drData["LD"].ToString() != "")
					{
						this.Text = this.Text + drData["LD"].ToString() + " ";
						this.ForeColor = System.Drawing.Color.Red;
					}
					if( drData["Color"] != null && drData["Color"] != DBNull.Value && drData["Color"].ToString() != "")
						this.Text = this.Text + drData["Color"].ToString();
					this.Text = this.Text + "/";
					if( drData["Clarity"] != null && drData["Clarity"] != DBNull.Value && drData["Clarity"].ToString() != "")
						this.Text = this.Text + drData["Clarity"].ToString();
					this.Text = this.Text + ")";
				}
				string sNewItemNumber = "";
				string sPrevItemNumber = "";
				//string sItemNumber = "";
				if(drData["NewOrderCode"]!= DBNull.Value && drData["NewBatchCode"]!= DBNull.Value && drData["NewItemCode"]!= DBNull.Value)
				{
					sNewItemNumber = gemoDream.Service.FillToFiveChars(drData["NewOrderCode"].ToString()) + "." +
						gemoDream.Service.FillToFiveChars(drData["NewOrderCode"].ToString()) + "." +
						gemoDream.Service.FillToThreeChars(drData["NewBatchCode"].ToString()) + "." +
						gemoDream.Service.FillToTwoChars(drData["NewItemCode"].ToString());
					if(sItemNumber==sNewItemNumber)
						sNewItemNumber = "";
				}
				if(drData["PrevOrderCode"]!= DBNull.Value && drData["PrevGroupCode"]!= DBNull.Value && drData["PrevBatchCode"]!= DBNull.Value && drData["PrevItemCode"]!= DBNull.Value)
				{
					sPrevItemNumber = 
						gemoDream.Service.FillToFiveChars(drData["PrevOrderCode"].ToString()) + "." +
						gemoDream.Service.FillToFiveChars(drData["PrevGroupCode"].ToString()) + "." +
						gemoDream.Service.FillToThreeChars(drData["PrevBatchCode"].ToString()) + "." +
						gemoDream.Service.FillToTwoChars(drData["PrevItemCode"].ToString());
				}
				
				if(sNewItemNumber == "") sNewItemNumber = sItemNumber;
				if(sPrevItemNumber == "") sPrevItemNumber = sItemNumber;
				if(sItemNumber == sNewItemNumber & sItemNumber==sPrevItemNumber)
				{

				}
				else
				{
					if(sItemNumber!=sPrevItemNumber)// && sItemNumber == sNewItemNumber)
					{
						this.Text = this.Text + " (Old # " + sPrevItemNumber + ")";
					}
					//else
					if(sItemNumber != sNewItemNumber)// && sItemNumber==sPrevItemNumber)
					{
						this.Text = this.Text + " (Current # " + sNewItemNumber + ")";
					}
				}
				/* 
				// sd 06.12.06
				if(sNewItemNumber != "")
					this.Text = this.Text + " (Current N: " + sNewItemNumber + ")";
				else
				{
					if(sPrevItemNumber != "")
						this.Text = this.Text + " (Previous N: " + sPrevItemNumber + ")";
				}
				*/
			}
			Initialize(drData);
		}

		public OrderNode(DataRow drData):base(drData["Name"].ToString())
		{
			Initialize(drData);
		}
		private void Initialize(DataRow drData)
		{
			drNode = drData;
			NodeCode = drData["Name"].ToString();
			tblName = drData.Table.TableName;
			tblCode = OrdersTree.GetTableCode(tblName);
			//			iTargetCode = drData["StateTargetCode"].ToString();
			this.SelectedImageIndex = Convert.ToInt32(drData["IconIndex"]);
			this.ImageIndex = Convert.ToInt32(drData["IconIndex"]);
		}

		public bool IsGhost = false;
		public string iTargetCode;
		public string tblName;
		public int tblCode;
		public DataRow drNode;
		public string NodeCode;
		private OrderNode ParentMember;
		private bool bIsChecked = false;			
		public bool IsChecked
		{
			set
			{					
				bIsChecked = value;	
				this.Checked = value;

				foreach(OrderNode onChild in this.Nodes)
				{
					if (value)
					{
						if (!onChild.Checked)
						{
							this.Checked = false;
							break;
						}					
					}
					else
					{
						if (onChild.IsChecked)
						{						
							bIsChecked = true;
							break;
						}
					}			
				}

				try
				{
					if ((Convert.ToBoolean(this.TreeView.Tag) == true) && (((OrderNode)this.Parent).tblName == "tblItem") && (value == true))
					{
						((OrderNode)this.Parent).SetChecked(value);
						((OrderNode)this.Parent.Parent).IsChecked = value;
					}
					else
					{					
						((OrderNode)this.Parent).IsChecked = value;
					}
				}
				catch{}		
			}
			get
			{
				return bIsChecked;
			}
		}
		
		public void SetChecked(bool bCheck)
		{
			bIsChecked = bCheck;
		}

		public void onRemove()
		{
			ParentMember = (OrderNode)Parent;
			Remove();
		}
	}
	#endregion
}
