using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.IO;
using gemoDream;
using System.Collections.Generic;
using System.Linq;

namespace Cntrls
{
	/// <summary>
	/// Summary description for UserControl1.
	/// </summary>

	//public delegate void ChangedEventHandler(object sender, EventArgs ea);

	public class ItemPanel : System.Windows.Forms.UserControl
	{
		string sItemTypeForSelection;
		string sItemTypeGroupForSelection;
		DataSet dsData = new DataSet();
		private ListView listItems;
		private System.Windows.Forms.TreeView treeItemLibrary;
		private System.Windows.Forms.PictureBox pbItemPicture;
		private System.Windows.Forms.Label lbFullItemName;
		internal System.Windows.Forms.GroupBox GroupBox;
		private System.Windows.Forms.ImageList ilLibIcons;
		private System.Windows.Forms.ImageList ilItemIcons;
		private System.Windows.Forms.ImageList ilDefItemIcons;
		private System.Windows.Forms.ImageList ilDefLibIcons;
		private System.ComponentModel.IContainer components;
		private ColumnHeader columnHeader1;
		private ColumnHeader columnHeader2;
		private PartTreeEx ptItemStructure;
		private Label label1;
		private string MRUItemTypeID;

		[Browsable(true)]
		public List<string> ItemTypesInUse { get; set; }

		[Browsable(true)]
		public string StructName
		{
			get { return label1.Text; }
			set { label1.Text = value; }
		}

		[Browsable(true)]
		public Boolean initialized { get; set; }

		[Browsable(true)]
		public string FullItemName
		{
			get { return lbFullItemName.Text; }
			set { lbFullItemName.Text = value; }
		}

		[Browsable(true)]
		public Image ItemPicture
		{
			get { return pbItemPicture.Image; }
			set { pbItemPicture.Image = value; }
		}

		[Browsable(true)]
		public TreeView TreeItemLibrary
		{
			get { return treeItemLibrary; }
		}

		[Browsable(true)]
		public ListView ListItems
		{
			get { return listItems; }
		}

		[Browsable(true)]
		public PartTreeEx _ptItemStructure
		{
			get { return ptItemStructure; }
		}

	
		[Browsable(true)]
		public string CustomerProgram
		{
			get
			{
				if (itemId != null)
				{
					DataRow[] items = dsData.Tables["Items"].Select("Id = '" + itemId.ToString() + "'");
					if (items.Length > 0)
					{
						return (string)items[0]["CustomerProgram"];
					}
				}
				return "";
			}
		}

		[Browsable(true)]
		public string CustomerProgramId
		{
			get
			{
				if (itemId != null)
				{
					var id = (itemId.ToString().Contains("_")) ? "" : itemId.ToString();
					DataRow[] items = dsData.Tables["Items"].Select("Id = '" + id + "'"); // itemId.ToString() + "'");
					if (items.Length > 0)
					{
						return (string)items[0]["CustomerProgramId"];
					}
				}
				return "";
			}
		}
		[Browsable(true)]
		public int CustomerID { get; set; }

		[Browsable(true)]
		public bool instanceLoaded { get; set; }

		public ItemPanel()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			initialized = false;
			ptItemStructure.Enabled = true;
			ptItemStructure.Clear();
			label1.Text = "";
			//listItems.Items.Clear();

			// TODO: Add any initialization after the InitComponent call

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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Ring Type1", 1, 1);
			System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Ring Type2--1");
			System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Ring Type2--2");
			System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Ring Type2", 4, 4, new System.Windows.Forms.TreeNode[] {
            treeNode20,
            treeNode21});
			System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Ring Type3", 2, 2);
			System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Rings", new System.Windows.Forms.TreeNode[] {
            treeNode19,
            treeNode22,
            treeNode23});
			System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Studs", 5, 5);
			System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("...", 1, 1);
			System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("...", 3, 3);
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemPanel));
			this.GroupBox = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.listItems = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.treeItemLibrary = new System.Windows.Forms.TreeView();
			this.pbItemPicture = new System.Windows.Forms.PictureBox();
			this.lbFullItemName = new System.Windows.Forms.Label();
			this.ilDefLibIcons = new System.Windows.Forms.ImageList(this.components);
			this.ilDefItemIcons = new System.Windows.Forms.ImageList(this.components);
			this.ilLibIcons = new System.Windows.Forms.ImageList(this.components);
			this.ilItemIcons = new System.Windows.Forms.ImageList(this.components);
			this.ptItemStructure = new Cntrls.PartTreeEx();
			this.GroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbItemPicture)).BeginInit();
			this.SuspendLayout();
			// 
			// GroupBox
			// 
			this.GroupBox.Controls.Add(this.label1);
			this.GroupBox.Controls.Add(this.ptItemStructure);
			this.GroupBox.Controls.Add(this.listItems);
			this.GroupBox.Controls.Add(this.treeItemLibrary);
			this.GroupBox.Controls.Add(this.pbItemPicture);
			this.GroupBox.Controls.Add(this.lbFullItemName);
			this.GroupBox.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.GroupBox.ForeColor = System.Drawing.Color.DimGray;
			this.GroupBox.Location = new System.Drawing.Point(0, 0);
			this.GroupBox.Name = "GroupBox";
			this.GroupBox.Size = new System.Drawing.Size(939, 202);
			this.GroupBox.TabIndex = 8;
			this.GroupBox.TabStop = false;
			this.GroupBox.Text = "Item";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Abadi MT Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(557, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(37, 16);
			this.label1.TabIndex = 8;
			this.label1.Text = "label1";
			// 
			// listItems
			// 
			this.listItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
			this.listItems.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listItems.FullRowSelect = true;
			this.listItems.GridLines = true;
			this.listItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.listItems.Location = new System.Drawing.Point(145, 3);
			this.listItems.MultiSelect = false;
			this.listItems.Name = "listItems";
			this.listItems.ShowItemToolTips = true;
			this.listItems.Size = new System.Drawing.Size(408, 199);
			this.listItems.TabIndex = 6;
			this.listItems.UseCompatibleStateImageBehavior = false;
			this.listItems.View = System.Windows.Forms.View.Details;
			this.listItems.SelectedIndexChanged += new System.EventHandler(this.listItems_SelectedIndexChanged);
			this.listItems.DoubleClick += new System.EventHandler(this.listItems_DoubleClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "";
			this.columnHeader1.Width = 0;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Item Types";
			this.columnHeader2.Width = 400;
			// 
			// treeItemLibrary
			// 
			this.treeItemLibrary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.treeItemLibrary.HideSelection = false;
			this.treeItemLibrary.Location = new System.Drawing.Point(791, 37);
			this.treeItemLibrary.Name = "treeItemLibrary";
			treeNode19.ImageIndex = 1;
			treeNode19.Name = "";
			treeNode19.SelectedImageIndex = 1;
			treeNode19.Text = "Ring Type1";
			treeNode20.Name = "";
			treeNode20.Text = "Ring Type2--1";
			treeNode21.Name = "";
			treeNode21.Text = "Ring Type2--2";
			treeNode22.ImageIndex = 4;
			treeNode22.Name = "";
			treeNode22.SelectedImageIndex = 4;
			treeNode22.Text = "Ring Type2";
			treeNode23.ImageIndex = 2;
			treeNode23.Name = "";
			treeNode23.SelectedImageIndex = 2;
			treeNode23.Text = "Ring Type3";
			treeNode24.Name = "";
			treeNode24.Text = "Rings";
			treeNode25.ImageIndex = 5;
			treeNode25.Name = "";
			treeNode25.SelectedImageIndex = 5;
			treeNode25.Text = "Studs";
			treeNode26.ImageIndex = 1;
			treeNode26.Name = "";
			treeNode26.SelectedImageIndex = 1;
			treeNode26.Text = "...";
			treeNode27.ImageIndex = 3;
			treeNode27.Name = "";
			treeNode27.SelectedImageIndex = 3;
			treeNode27.Text = "...";
			this.treeItemLibrary.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode24,
            treeNode25,
            treeNode26,
            treeNode27});
			this.treeItemLibrary.Size = new System.Drawing.Size(148, 159);
			this.treeItemLibrary.TabIndex = 5;
			this.treeItemLibrary.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeItemLibrary_AfterSelect);
			// 
			// pbItemPicture
			// 
			this.pbItemPicture.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbItemPicture.BackgroundImage")));
			this.pbItemPicture.Location = new System.Drawing.Point(10, 20);
			this.pbItemPicture.Name = "pbItemPicture";
			this.pbItemPicture.Size = new System.Drawing.Size(135, 130);
			this.pbItemPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pbItemPicture.TabIndex = 2;
			this.pbItemPicture.TabStop = false;
			this.pbItemPicture.Paint += new System.Windows.Forms.PaintEventHandler(this.pbItemPicture_Paint);
			// 
			// lbFullItemName
			// 
			this.lbFullItemName.AutoEllipsis = true;
			this.lbFullItemName.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbFullItemName.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lbFullItemName.Location = new System.Drawing.Point(10, 153);
			this.lbFullItemName.Name = "lbFullItemName";
			this.lbFullItemName.Size = new System.Drawing.Size(125, 49);
			this.lbFullItemName.TabIndex = 1;
			this.lbFullItemName.Text = "Full Item Name";
			// 
			// ilDefLibIcons
			// 
			this.ilDefLibIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilDefLibIcons.ImageStream")));
			this.ilDefLibIcons.TransparentColor = System.Drawing.Color.Transparent;
			this.ilDefLibIcons.Images.SetKeyName(0, "");
			this.ilDefLibIcons.Images.SetKeyName(1, "");
			this.ilDefLibIcons.Images.SetKeyName(2, "");
			this.ilDefLibIcons.Images.SetKeyName(3, "");
			this.ilDefLibIcons.Images.SetKeyName(4, "");
			this.ilDefLibIcons.Images.SetKeyName(5, "");
			this.ilDefLibIcons.Images.SetKeyName(6, "");
			this.ilDefLibIcons.Images.SetKeyName(7, "");
			this.ilDefLibIcons.Images.SetKeyName(8, "");
			this.ilDefLibIcons.Images.SetKeyName(9, "");
			this.ilDefLibIcons.Images.SetKeyName(10, "");
			this.ilDefLibIcons.Images.SetKeyName(11, "");
			this.ilDefLibIcons.Images.SetKeyName(12, "");
			this.ilDefLibIcons.Images.SetKeyName(13, "");
			this.ilDefLibIcons.Images.SetKeyName(14, "");
			this.ilDefLibIcons.Images.SetKeyName(15, "");
			// 
			// ilDefItemIcons
			// 
			this.ilDefItemIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilDefItemIcons.ImageStream")));
			this.ilDefItemIcons.TransparentColor = System.Drawing.Color.Transparent;
			this.ilDefItemIcons.Images.SetKeyName(0, "");
			this.ilDefItemIcons.Images.SetKeyName(1, "");
			this.ilDefItemIcons.Images.SetKeyName(2, "");
			this.ilDefItemIcons.Images.SetKeyName(3, "");
			this.ilDefItemIcons.Images.SetKeyName(4, "");
			this.ilDefItemIcons.Images.SetKeyName(5, "");
			this.ilDefItemIcons.Images.SetKeyName(6, "");
			this.ilDefItemIcons.Images.SetKeyName(7, "");
			this.ilDefItemIcons.Images.SetKeyName(8, "");
			this.ilDefItemIcons.Images.SetKeyName(9, "");
			this.ilDefItemIcons.Images.SetKeyName(10, "");
			this.ilDefItemIcons.Images.SetKeyName(11, "");
			this.ilDefItemIcons.Images.SetKeyName(12, "");
			this.ilDefItemIcons.Images.SetKeyName(13, "");
			this.ilDefItemIcons.Images.SetKeyName(14, "");
			this.ilDefItemIcons.Images.SetKeyName(15, "");
			// 
			// ilLibIcons
			// 
			this.ilLibIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.ilLibIcons.ImageSize = new System.Drawing.Size(16, 16);
			this.ilLibIcons.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// ilItemIcons
			// 
			this.ilItemIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.ilItemIcons.ImageSize = new System.Drawing.Size(16, 16);
			this.ilItemIcons.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// ptItemStructure
			// 
			this.ptItemStructure.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ptItemStructure.Location = new System.Drawing.Point(559, 37);
			this.ptItemStructure.Name = "ptItemStructure";
			this.ptItemStructure.Size = new System.Drawing.Size(226, 165);
			this.ptItemStructure.TabIndex = 7;
			// 
			// ItemPanel
			// 
			this.Controls.Add(this.GroupBox);
			this.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.Name = "ItemPanel";
			this.Size = new System.Drawing.Size(942, 205);
			this.Resize += new System.EventHandler(this.ItemPanel_Resize);
			this.GroupBox.ResumeLayout(false);
			this.GroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbItemPicture)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void listItems_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (listItems.SelectedItems.Count > 0 || instanceLoaded)
				{
					listItems.BackColor = Color.White;
					ListViewItem item = listItems.SelectedItems[0];
					item.BackColor = Color.White;
					System.Diagnostics.Debug.Assert(item.Tag != null, "Please call Initialize() before using of ItemPanel");
					if (item.Tag == null) return;
					itemId = item.Tag.ToString();
					DataRow[] items = dsData.Tables["Items"].Select("Id = '" + itemId.ToString() + "'");
					if (items.Length > 0)
					{
						InitPartTree(itemId);
						if (items[0]["Picture"] == System.DBNull.Value)
						{
							pbItemPicture.Image = new Bitmap(1, 1);
						}
						else
						{
							//pbItemPicture.Image = (System.Drawing.Image)items[0]["Picture"];
						}
						lbFullItemName.Text = (string)items[0]["FullName"];
						ItemName = (string)items[0]["Name"];
						if (CustomerID != 0) label1.Text = items[0]["Name"].ToString().ToUpper().Replace("ITEM CONTAINER", "IC");
						else label1.Text = "";
						listItems.EnsureVisible(item.Index);
						listItems.Focus();
					}
				}
				else
				{
					if (itemId != null)
					{
						bool isPreviousSelectionValid = false;
						foreach (ListViewItem item in listItems.Items)
						{
							if (itemId == item.Tag.ToString()) isPreviousSelectionValid = true;
						}
						if (!isPreviousSelectionValid)
						{
							pbItemPicture.Image = new Bitmap(1, 1);
							lbFullItemName.Text = "";
							ItemName = "";
							itemId = null;
						}
					}
				}
				OnChanged(EventArgs.Empty);
			}
			catch { }
		}

		private void InitPartTree(string sItemTypeID)
		{
			if (sItemTypeID.Trim() == "" || CustomerID == 0)
			{
				this.ptItemStructure.Clear();
				label1.Text = "";
				return;
			}
			DataSet dsParts = new DataSet();
			//DataTable dtMeasureType = Service.GetMeasuresByItemType(sItemTypeID);//tblName : MeasuresByItemType / 1 - empty	/procedure spGetMeasuresByItemType
			//dtMeasureType.TableName = "Measures";

			//dsParts.Tables.Add(dtMeasureType);      //tblName : Measures

			dsParts.Tables.Add(Service.GetParts(sItemTypeID));  //tblName : Parts	/Procedure dbo.spGetPartsByItemType	
																//dsParts.Tables.Add(Service.GetPartsStruct());   //tblName : SetParts

			//gemoDream.Service.debug_DiaspalyDataSet(dsParts);

			this.ptItemStructure.Initialize(dsParts.Tables["Parts"]);
			this.ptItemStructure.ExpandTree();
			//this.ptItemStructure.SelectedNode = this.ptItemStructure.tvPartTree.TopNode;
		}

		private void ItemPanel_Load(object sender, System.EventArgs e)
		{
			//ItemPanel_SizeChanged(null,null);
		}

		[Browsable(true)]
		public event EventHandler Changed;

		protected virtual void OnChanged(EventArgs ea)
		{
			if (Changed != null)
				Changed(this, ea);
		}

		private void ItemPanel_Resize(object sender, System.EventArgs e)
		{
			//GroupBox.Location = new Point(0,0);
			//         GroupBox.Size = new Size(this.Size.Width, this.Size.Height);
			//listItems.Size = new Size(listItems.Size.Width, this.Size.Height - listItems.Location.Y - 5);
			//treeItemLibrary.Location = new Point(listItems.Location.X + listItems.Size.Width + 5, listItems.Location.Y);
			//treeItemLibrary.Size = new Size(this.Size.Width - treeItemLibrary.Location.X - 5, this.Size.Height - treeItemLibrary.Location.Y - 5);
		}

		public void Initialize()
		{
			treeItemLibrary.Nodes.Clear();
			listItems.Items.Clear();
			ptItemStructure.Clear();
			label1.Text = "";
			lbFullItemName.Text = "";
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ItemPanel));
			pbItemPicture.Image = new Bitmap(1, 1);

			if (dsData != null)
			{
				dsData.Clear();
				dsData = null;
				//dsData.Dispose();
				dsData = new DataSet();
			}
			dsData.Tables.Add("Items");

			dsData.Tables["Items"].Columns.Add("Id");
			dsData.Tables["Items"].Columns.Add("TypeId");
			dsData.Tables["Items"].Columns.Add("Name");
			dsData.Tables["Items"].Columns.Add("FullName");
			dsData.Tables["Items"].Columns.Add("Icon");
			dsData.Tables["Items"].Columns.Add("Picture");
			dsData.Tables["Items"].Columns.Add("CustomerProgram");
			dsData.Tables["Items"].Columns.Add("CustomerProgramId");
			dsData.Tables["Items"].Columns.Add("Path2Picture");

			//dsData.Tables["Items"].PrimaryKey = new DataColumn[] {dsData.Tables["Items"].Columns["Id"], dsData.Tables["Items"].Columns["TypeId"]};
			dsData.Tables["Items"].Columns["Id"].DataType = System.Type.GetType("System.String");
			dsData.Tables["Items"].Columns["TypeId"].DataType = System.Type.GetType("System.String");
			dsData.Tables["Items"].Columns["Name"].DataType = System.Type.GetType("System.String");
			dsData.Tables["Items"].Columns["FullName"].DataType = System.Type.GetType("System.String");
			dsData.Tables["Items"].Columns["Icon"].DataType = System.Type.GetType("System.Byte[]");
			dsData.Tables["Items"].Columns["Picture"].DataType = System.Type.GetType("System.Byte[]");
			dsData.Tables["Items"].Columns["CustomerProgram"].DataType = System.Type.GetType("System.String");
			dsData.Tables["Items"].Columns["CustomerProgramId"].DataType = System.Type.GetType("System.String");
			dsData.Tables["Items"].Columns["Path2Picture"].DataType = System.Type.GetType("System.String");
		}

		private void recursTreeFill(DataTable table, string cur, TreeNodeCollection nodeTree)
		{
			foreach (DataRow row in table.Rows)
			{
				if (cur == null && row["ParentId"] == System.DBNull.Value || row["ParentId"] != System.DBNull.Value && row["ParentId"].ToString() == cur)
				{
					nodeTree.Add((string)row["Name"]);
					nodeTree[nodeTree.Count - 1].Tag = row["Id"].ToString();
					if (row["Icon"] == System.DBNull.Value)
					{
						ilLibIcons.Images.Add(ilDefLibIcons.Images[0]);
						nodeTree[nodeTree.Count - 1].ImageIndex = ilLibIcons.Images.Count - 1;
						nodeTree[nodeTree.Count - 1].SelectedImageIndex = ilLibIcons.Images.Count - 1;
					}
					else
					{
						ilLibIcons.Images.Add((System.Drawing.Bitmap)row["Icon"]);
						nodeTree[nodeTree.Count - 1].ImageIndex = ilLibIcons.Images.Count - 1;
						nodeTree[nodeTree.Count - 1].SelectedImageIndex = ilLibIcons.Images.Count - 1;
					}

					recursTreeFill(table, row["Id"].ToString(), nodeTree[nodeTree.Count - 1].Nodes);
				}
			}
		}

		public void InitializeLibrary(DataTable table)
		{
			treeItemLibrary.Nodes.Clear();
			ilLibIcons.Images.Clear();

			if (MRUItemTypeID != null)
			{
				treeItemLibrary.Nodes.Add("Most Recently Used");
				treeItemLibrary.Nodes[0].Tag = MRUItemTypeID;
				ilLibIcons.Images.Add(ilDefLibIcons.Images[13]);
				treeItemLibrary.Nodes[0].ImageIndex = ilLibIcons.Images.Count - 1;
				treeItemLibrary.Nodes[0].SelectedImageIndex = ilLibIcons.Images.Count - 1;
			}

			if (dsData.Tables[table.TableName] != null) dsData.Tables.Remove(table.TableName);
			DataTable newTable = table.Copy();
			dsData.Tables.Add(newTable);
			newTable.TableName = "Types";

			treeItemLibrary.ImageList = ilLibIcons;
			recursTreeFill(dsData.Tables["Types"], null, treeItemLibrary.Nodes);
			if (treeItemLibrary.Nodes.Count > 0) treeItemLibrary.SelectedNode = treeItemLibrary.Nodes[0];
		}

		public void InitializePicture(Image picture)
		{
			if (picture != null)
			{
				double scaleX = (double)picture.Width / (double)pbItemPicture.Width;
				double scaleY = (double)picture.Height / (double)pbItemPicture.Height;
				double scale = Math.Max(scaleX, scaleY);
				Image icoShape = null;
				if (scale == 0)
				{
					if (picture.Width != 0)
					{
						icoShape = picture.GetThumbnailImage(pbItemPicture.Width - 2,
							pbItemPicture.Height - 2,
							null, IntPtr.Zero);
						pbItemPicture.Image = icoShape;
						pbItemPicture.SizeMode = PictureBoxSizeMode.CenterImage;
					}
					return;
				}

				//pbImageContainer.SizeMode = PictureBoxSizeMode.StretchImage;

				int NewWidth = Convert.ToInt32((double)picture.Width / scale) - 2;
				int NewHeight = Convert.ToInt32((double)picture.Height / scale) - 2;
				icoShape = picture.GetThumbnailImage(NewWidth, NewHeight, null, IntPtr.Zero);
				pbItemPicture.SizeMode = PictureBoxSizeMode.CenterImage;
				pbItemPicture.Image = icoShape;
			}
			else
			{
				pbItemPicture.Image = picture;
			}
		}

		[Browsable(true)]
		public event EventHandler ItemTypeSelected; // fiers after type slection in the item library

		[Browsable(true)]
		public event EventHandler NewItemTypeSelected; // fiers after first selection of the given type

		[Browsable(true)]
		public event EventHandler ListViewDoubleClick;

		[Browsable(true)]
		public string DefaultPathToPicture
		{
			get
			{
				DataRow[] rows = dsData.Tables["Items"].Select("Id = '" + itemId.ToString() + "'");
				if (rows.Length > 0)
					return rows[0]["Path2Picture"].ToString();
				else
					return "";
			}
		}

		[Browsable(true)]
		public Image DefaultPicture
		{
			get
			{
				try
				{
					//gemoDream.Service.debug_DiaspalyDataSet(dsData);
					DataRow[] drs = dsData.Tables["Items"].Select("Id = '" + itemId.ToString() + "'");
					if (drs.Length > 0 && !drs[0]["Picture"].Equals(DBNull.Value))
						return (Image)drs[0]["Picture"];
					else
						return null;
				}
				catch
				{
					return null;
				}
			}
		}

		private string typeId;
		[Browsable(true)]
		public string TypeId
		{
			get { return typeId; }
		}

		//private string itemId;
		public string itemId;
		[Browsable(true)]
		public string ItemId
		{
			get { return itemId; }
		}

		[Browsable(true)]
		public string ItemName { get; private set; }
		private void treeItemLibrary_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if (ItemTypeSelected != null)
				ItemTypeSelected(this, e);

			System.Diagnostics.Debug.Assert(e.Node.Tag != null, "Please call Initialize() before using of ItemPanel");
			if (e.Node.Tag == null) return;

			//if (CustomerID != 0)
			{

				//typeId = "1"; // e.Node.Tag.ToString();
				typeId = e.Node.Tag.ToString();
				DataRow[] items = dsData.Tables["Items"].Select("typeId = '" + typeId.ToString() + "'");

				if (items.Length == 0)
				{
					if (NewItemTypeSelected != null)
						NewItemTypeSelected(this, e);
				}
#if DEBUG
				try
				{
					// For debugging only			
					string filename = "C:/DELL/myXml_ItemPanel.xml";
					if (File.Exists(filename)) File.Delete(filename);
					// Create the FileStream to write with.
					FileStream myFileStream = new FileStream(filename, System.IO.FileMode.Create);
					// Create an XmlTextWriter with the fileStream.
					System.Xml.XmlTextWriter myXmlWriter = new System.Xml.XmlTextWriter(myFileStream, System.Text.Encoding.Unicode);
					// Write to the file with the WriteXml method.
					dsData.WriteXml(myXmlWriter);
					myXmlWriter.Close();
					// End of debugging part
				}
				catch
				{ }
#endif
				//if(CustomerID == 0)
				//////LoadItemitemTypeView(true, typeId);
				goto aa1;
				items = dsData.Tables["Items"].Select("typeId = '" + typeId.ToString() + "'");
				ilItemIcons.Images.Clear();
				listItems.Items.Clear();
				listItems.View = View.Details;
				listItems.AllowColumnReorder = true;
				//listItems.CheckBoxes = true;
				listItems.FullRowSelect = true;
				listItems.BackColor = Color.White;
				//listItems.Columns.Add("Check", -2, HorizontalAlignment.Left);
				//listItems.Columns.Add("Item Types", -2, HorizontalAlignment.Left);
				//listItems.LabelEdit = true;
				//listItems.LargeImageList = listItems.SmallImageList = ilItemIcons;
				//ListViewItem lv1 = null;
				//var i = 1;
				foreach (DataRow row in items)
				{
					goto a1;
					listItems.Items.Add((string)row["Name"]);
					listItems.Items[listItems.Items.Count - 1].Tag = row["Id"].ToString();
				/*
				if (row["Icon"] == System.DBNull.Value)
				{
					ilItemIcons.Images.Add(ilDefItemIcons.Images[0]);
					listItems.Items[listItems.Items.Count-1].ImageIndex = ilItemIcons.Images.Count-1;
				}
				else
				{
					ilItemIcons.Images.Add((Bitmap)row["Icon"]);
					listItems.Items[listItems.Items.Count-1].ImageIndex = ilItemIcons.Images.Count-1;
				}
				*/
				a1:
					ListViewItem lvi = new ListViewItem(""); // (row["TypeID"].ToString());
					lvi.Tag = row["ID"].ToString();
					var Name = row["Name"].ToString();

					lvi.SubItems.Add(row["Name"].ToString().ToUpper().Replace("ITEM CONTAINER", "IC"));
					listItems.Items.Add(lvi);

					if (ItemTypesInUse != null)
					{
						if (!ItemTypesInUse.Contains(row["ID"].ToString()))
							lvi.BackColor = Color.LightGray;
					}
					//listItems.Items[listItems.Items.Count - 1].Tag = row["Id"].ToString();
					//i++;
				}
			aa1:
				if (sItemTypeForSelection != null && typeId != null && typeId == sItemTypeGroupForSelection)
				{
					SelectListItem(sItemTypeForSelection);
					sItemTypeForSelection = null;
					sItemTypeGroupForSelection = null;
				}
				else
					if (listItems.Items.Count > 0) listItems.Items[0].Selected = true;
				else listItems_SelectedIndexChanged(this, new System.EventArgs());
			}
		}

		public void LoadItemitemTypeView(bool Full, string typeID)
		{
			ilItemIcons.Images.Clear();
			//listItems.Items.Clear();
			bool newtypeID = false;
			bool selectedTypeID = false;
			if (CustomerID == 0)
			{
				Full = true;
				listItems.Items.Clear();
				return;
			}
			else Full = false;

			DataRow[] items;
			var expession = "typeID not like '*_*'";
			var sortOrder = "typeID ASC";
			switch (typeID)
			{
				case "0":
					//var expession = "typeID not like '*_*'";
					//var sortOrder = "typeID ASC";
					items = dsData.Tables["Items"].Select(expession, sortOrder);
					break;
				case "-1":
					items = dsData.Tables["Items"].Select();
					ItemTypesInUse = (from DataRow drow in dsData.Tables["Items"].Rows
									  where (!drow["typeID"].ToString().Contains("_") || drow["typeID"].ToString().Trim() == "")
									  select drow["id"].ToString()).Distinct().ToList();
					break;
				case "-2":
					items = dsData.Tables["Items"].Select(expession, sortOrder);
					//items = dsData.Tables["Items"].Select();
					Full = true;
					//ItemTypesInUse = (from DataRow drow in dsData.Tables["Items"].Rows
					//				  where (!drow["typeID"].ToString().Contains("_") || drow["typeID"].ToString().Trim() == "")
					//				  select drow["id"].ToString()).Distinct().ToList();
					break;
				default:
					items = dsData.Tables["Items"].Select("Id = '" + typeID.ToString() + "' and typeID not like '*_*'");
					if (items.Length == 1 && ItemTypesInUse.Count > 0 && !ItemTypesInUse.Contains(typeID.ToString())) 
						newtypeID = true;
					selectedTypeID = true;
					break;
			}
			//if (typeID == "0") // || typeID.Contains("_"))
			//{
			//	items = dsData.Tables["Items"].Select();

			//}
			//if (typeID == "-1") // || typeID.Contains("_"))
			//{
			//	items = dsData.Tables["Items"].Select();
			//	ItemTypesInUse = (from DataRow drow in dsData.Tables["Items"].Rows
			//					  where !drow["typeID"].ToString().Contains("_")
			//					  select drow["id"].ToString()).Distinct().ToList();
			//}

			//else
			//{
			//	items = dsData.Tables["Items"].Select("typeID = '" + typeID.ToString() + "'");
			//}
			try
			{
				if (items.Length > 0)
				{
					//items = dsData.Tables["Items"].Select("typeID = '" + typeID.ToString() + "'");
					ilItemIcons.Images.Clear();
					listItems.Items.Clear();
					ptItemStructure.Clear();
					listItems.View = View.Details;
					listItems.AllowColumnReorder = true;
					listItems.FullRowSelect = true;
					listItems.BackColor = Color.White;
					ListViewItem lvi;
					//var i = 0;
					if (selectedTypeID)
					{
						lvi = new ListViewItem("");
						lvi.Tag = typeID;
						//var Name = row["Name"].ToString();
						lvi.SubItems.Add("(" + items[0]["ID"].ToString() + ")" + items[0]["Name"].ToString().ToUpper().Replace("ITEM CONTAINER", "IC"));
						listItems.Items.Add(lvi);
						listItems.Items[0].Selected = true;
						listItems_SelectedIndexChanged(this, null);
						return;
 					}

					foreach (DataRow row in items)
					{
						if (row["typeID"].ToString().Trim() != "")
						{
							//ListViewItem lvi = new ListViewItem(""); // (row["typeID"].ToString());
							if (Full)
							{
								if (!row["typeID"].ToString().Contains("_"))
								{
									lvi = new ListViewItem("");
									lvi.Tag = row["ID"].ToString();
									//var Name = row["Name"].ToString();
									lvi.SubItems.Add("(" + row["ID"].ToString() + ")" + row["Name"].ToString().ToUpper().Replace("ITEM CONTAINER", "IC"));
									listItems.Items.Add(lvi);
								}
							}
							else
							{
								if (ItemTypesInUse.Contains(row["ID"].ToString()) && !row["typeID"].ToString().Contains("_"))
								{
									lvi = new ListViewItem("");
									lvi.Tag = row["ID"].ToString();
									//var Name = row["Name"].ToString();
									lvi.SubItems.Add("(" + row["ID"].ToString() + ") " + row["Name"].ToString().ToUpper().Replace("ITEM CONTAINER", "IC"));
									listItems.Items.Add(lvi);
									//i++;
								}
								//if (!ItemTypesInUse.Contains(typeID))
								//{
								//	int itypeID;
								//	if (int.TryParse(typeID, out itypeID))
								//	{
								//		if (row["ID"].ToString().Trim() == typeID)
								//		{
								//			lvi = new ListViewItem("");
								//			lvi.Tag = row["ID"].ToString();
								//			//var Name = row["Name"].ToString();
								//			lvi.SubItems.Add(row["Name"].ToString().ToUpper().Replace("ITEM CONTAINER", "IC"));
								//			listItems.Items.Add(lvi);
								//			break;
								//		}
								//	}
								//}
							}

						}
					}
					//MessageBox.Show("Number of lines = " + i.ToString());
				}
				//if (selectedTypeID) listItems_SelectedIndexChanged(this, null);
			}
			catch
			{ }

		}

		public void InitializeItems(DataTable table)
		{
			if (table != null)
			{
				if (initialized) return;
				dsData.Tables["Items"].BeginLoadData();
				foreach (DataRow row in table.Rows)
					dsData.Tables["Items"].LoadDataRow(new Object[] { row["Id"], row["TypeId"], row["Name"], row["Name"], row["Icon"], row["Picture"], row["CustomerProgram"], row["CustomerProgramId"], row["Path2Picture"] }, true);
				dsData.Tables["Items"].EndLoadData();
				initialized = true;
				//gemoDream.Service.debug_DiaspalyDataSet(dsData);
			}
		}

		/// <summary>
		/// Updates Most Recently Used Items list
		/// </summary>
		/// <param name="table"></param>
		public void InitializeMRU(string sCustomerOfficeID, string sCustomerID, string sVendorOfficeID, string sVendorID)
		{
			if (sVendorOfficeID == null || sVendorOfficeID == "") sVendorOfficeID = sCustomerOfficeID;
			if (sVendorID == null || sVendorID == "") sVendorID = sCustomerID;
			MRUItemTypeID = sCustomerOfficeID + "_" + sCustomerID + "_" + sVendorOfficeID + "_" + sVendorID;
			InitializeLibrary(dsData.Tables["Types"]);
		}

		private void pbItemPicture_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			if (pbItemPicture.Image == null) return;
			if (pbItemPicture.Image.Size.Height > pbItemPicture.Size.Height || pbItemPicture.Image.Size.Width > pbItemPicture.Size.Width)
			{
				pbItemPicture.SizeMode = PictureBoxSizeMode.StretchImage;
			}
			else
			{
				pbItemPicture.SizeMode = PictureBoxSizeMode.CenterImage;
			}
		}

		public void SelectListItem(string id)
		{
			listItems.BackColor = Color.White;
			if (ItemTypesInUse.Contains(id))
			{
				foreach (ListViewItem item in listItems.Items)
				{
					item.BackColor = Color.White;
					if (item.Tag.ToString() == id)
					//if (item.Selected = (item.Tag.ToString() == id))
					{
						listItems.Items[item.Index].Selected = true;
						listItems.EnsureVisible(item.Index);
						item.BackColor = Color.SkyBlue;
						listItems.Focus();
					}
				}
			}
			else
			{
				listItems.Items.Clear();
				LoadItemitemTypeView(false, id);

			}
		}

		public void ClearControls()
		{
			ListItems.Enabled = true;
			ListItems.Items.Clear();
			ptItemStructure.Enabled = true;
			ptItemStructure.Clear();
			label1.Text = "";
		}
		private void SelectLibraryItem(TreeNodeCollection nodes, string id)
		{
			foreach (TreeNode node in nodes)
			{
				if (node.Tag.ToString() == id)
				{
					treeItemLibrary.SelectedNode = node;
					return;
				}
				else
				{
					SelectLibraryItem(node.Nodes, id);
				}
			}
		}

		public void SelectLibraryItem(string id)
		{
			SelectLibraryItem(treeItemLibrary.Nodes, id);
		}
		public void SelectItemTypeById(string sItemTypeId, string sItemTypeGroupId)
		{
			SelectLibraryItem(sItemTypeGroupId);
			SelectListItem(sItemTypeId);
			sItemTypeForSelection = sItemTypeId;
			sItemTypeGroupForSelection = sItemTypeGroupId;
		}

		private void listItems_DoubleClick(object sender, EventArgs e)
		{
			if (ListViewDoubleClick != null)
				ListViewDoubleClick(this, e);
		}
	}
}
