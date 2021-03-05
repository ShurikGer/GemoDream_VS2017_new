using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using gemoDream;

namespace Cntrls
{
    /// <summary>
    /// Summary description for UserControl1.
    /// </summary>

    //public delegate void ChangedEventHandler(object sender, EventArgs ea);

    public class ItemPanelDynamic : System.Windows.Forms.UserControl
    {
        string sItemTypeForSelection;
        string sItemTypeGroupForSelection;
        DataSet dsData = new DataSet();
        bool isLibRefresh = false;
        private System.Windows.Forms.ListView listItems;
        private System.Windows.Forms.TreeView treeItemLibrary;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pbItemPicture;
        private System.Windows.Forms.Label lbFullItemName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        internal System.Windows.Forms.GroupBox GroupBox;
        private System.Windows.Forms.ImageList ilLibIcons;
        private System.Windows.Forms.ImageList ilItemIcons;
        private System.Windows.Forms.ImageList ilDefItemIcons;
        private System.Windows.Forms.ImageList ilDefLibIcons;
        private System.ComponentModel.IContainer components;
        private string MRUItemTypeID;


        [Browsable(false)]
        public string FullItemName
        {
            get { return lbFullItemName.Text; }
            set { lbFullItemName.Text = value; }
        }

        [Browsable(false)]
        public Image ItemPicture
        {
            get { return pbItemPicture.Image; }
            set { pbItemPicture.Image = value; }
        }

        [Browsable(false)]
        public TreeView TreeItemLibrary
        {
            get { return treeItemLibrary; }
        }

        [Browsable(false)]
        public ListView ListItems
        {
            get { return listItems; }
        }

        [Browsable(false)]
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

        [Browsable(false)]
        public string CustomerProgramId
        {
            get
            {
                if (itemId != null)
                {
                    DataRow[] items = dsData.Tables["Items"].Select("Id = '" + itemId.ToString() + "'");
                    if (items.Length > 0)
                    {
                        return (string)items[0]["CustomerProgramId"];
                    }
                }
                return "";
            }
        }

        public ItemPanelDynamic()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("123123df sadf assa fasd fasd f asdf ", 5);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("123df sadf assa fasd fasd f asdf ", 9);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("123df sadf assa fasd fasd f asdf ", 13);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("123df sadf assa fasd fasd f asdf ", 12);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("123df sadf assa fasd fasd f asdf ", 14);
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("fdgsd", 6);
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("sdfg", 7);
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("ssdfgsdfg", 11);
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ItemPanelDynamic));
            this.GroupBox = new System.Windows.Forms.GroupBox();
            this.listItems = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.ilDefItemIcons = new System.Windows.Forms.ImageList(this.components);
            this.ilDefLibIcons = new System.Windows.Forms.ImageList(this.components);
            this.treeItemLibrary = new System.Windows.Forms.TreeView();
            this.label12 = new System.Windows.Forms.Label();
            this.pbItemPicture = new System.Windows.Forms.PictureBox();
            this.lbFullItemName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ilLibIcons = new System.Windows.Forms.ImageList(this.components);
            this.ilItemIcons = new System.Windows.Forms.ImageList(this.components);
            this.GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox
            // 
            this.GroupBox.Controls.Add(this.listItems);
            this.GroupBox.Controls.Add(this.treeItemLibrary);
            this.GroupBox.Controls.Add(this.label12);
            this.GroupBox.Controls.Add(this.pbItemPicture);
            this.GroupBox.Controls.Add(this.lbFullItemName);
            this.GroupBox.Controls.Add(this.label1);
            this.GroupBox.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
            this.GroupBox.ForeColor = System.Drawing.Color.DimGray;
            this.GroupBox.Location = new System.Drawing.Point(0, 0);
            this.GroupBox.Name = "GroupBox";
            this.GroupBox.Size = new System.Drawing.Size(750, 190);
            this.GroupBox.TabIndex = 8;
            this.GroupBox.TabStop = false;
            this.GroupBox.Text = "Item";
            // 
            // listItems
            // 
            this.listItems.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader1});
            this.listItems.HideSelection = false;
            this.listItems.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
																					  listViewItem1,
																					  listViewItem2,
																					  listViewItem3,
																					  listViewItem4,
																					  listViewItem5,
																					  listViewItem6,
																					  listViewItem7,
																					  listViewItem8});
            this.listItems.LargeImageList = this.ilDefItemIcons;
            this.listItems.Location = new System.Drawing.Point(145, 25);
            this.listItems.MultiSelect = false;
            this.listItems.Name = "listItems";
            this.listItems.Size = new System.Drawing.Size(320, 145);
            this.listItems.SmallImageList = this.ilDefLibIcons;
            this.listItems.TabIndex = 6;
            this.listItems.SelectedIndexChanged += new System.EventHandler(this.listItems_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 316;
            // 
            // ilDefItemIcons
            // 
            this.ilDefItemIcons.ImageSize = new System.Drawing.Size(32, 32);
            this.ilDefItemIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilDefItemIcons.ImageStream")));
            this.ilDefItemIcons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ilDefLibIcons
            // 
            this.ilDefLibIcons.ImageSize = new System.Drawing.Size(16, 16);
            this.ilDefLibIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilDefLibIcons.ImageStream")));
            this.ilDefLibIcons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // treeItemLibrary
            // 
            this.treeItemLibrary.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(240)), ((System.Byte)(240)), ((System.Byte)(240)));
            this.treeItemLibrary.HideSelection = false;
            this.treeItemLibrary.ImageList = this.ilDefLibIcons;
            this.treeItemLibrary.Location = new System.Drawing.Point(470, 25);
            this.treeItemLibrary.Name = "treeItemLibrary";
            this.treeItemLibrary.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
																						new System.Windows.Forms.TreeNode("Rings", new System.Windows.Forms.TreeNode[] {
																																										   new System.Windows.Forms.TreeNode("Ring Type1", 1, 1),
																																										   new System.Windows.Forms.TreeNode("Ring Type2", 4, 4, new System.Windows.Forms.TreeNode[] {
																																																																		 new System.Windows.Forms.TreeNode("Ring Type2--1"),
																																																																		 new System.Windows.Forms.TreeNode("Ring Type2--2")}),
																																										   new System.Windows.Forms.TreeNode("Ring Type3", 2, 2)}),
																						new System.Windows.Forms.TreeNode("Studs", 5, 5),
																						new System.Windows.Forms.TreeNode("...", 1, 1),
																						new System.Windows.Forms.TreeNode("...", 3, 3)});
            this.treeItemLibrary.Size = new System.Drawing.Size(270, 145);
            this.treeItemLibrary.TabIndex = 5;
            this.treeItemLibrary.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeItemLibrary_AfterSelect);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(470, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 15);
            this.label12.TabIndex = 4;
            this.label12.Text = "Item Library";
            // 
            // pbItemPicture
            // 
            this.pbItemPicture.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbItemPicture.BackgroundImage")));
            this.pbItemPicture.Location = new System.Drawing.Point(10, 20);
            this.pbItemPicture.Name = "pbItemPicture";
            this.pbItemPicture.Size = new System.Drawing.Size(125, 130);
            this.pbItemPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbItemPicture.TabIndex = 2;
            this.pbItemPicture.TabStop = false;
            this.pbItemPicture.Paint += new System.Windows.Forms.PaintEventHandler(this.pbItemPicture_Paint);
            // 
            // lbFullItemName
            // 
            this.lbFullItemName.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
            this.lbFullItemName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbFullItemName.Location = new System.Drawing.Point(10, 155);
            this.lbFullItemName.Name = "lbFullItemName";
            this.lbFullItemName.Size = new System.Drawing.Size(125, 30);
            this.lbFullItemName.TabIndex = 1;
            this.lbFullItemName.Text = "Full Item Name";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(145, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Items";
            // 
            // ilLibIcons
            // 
            this.ilLibIcons.ImageSize = new System.Drawing.Size(16, 16);
            this.ilLibIcons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ilItemIcons
            // 
            this.ilItemIcons.ImageSize = new System.Drawing.Size(32, 32);
            this.ilItemIcons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ItemPanelDynamic
            // 
            this.Controls.Add(this.GroupBox);
            this.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(204)));
            this.Name = "ItemPanelDynamic";
            this.Size = new System.Drawing.Size(750, 196);
            this.Resize += new System.EventHandler(this.ItemPanel_Resize);
            this.GroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private void listItems_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (listItems.SelectedItems.Count > 0)
            {
                ListViewItem item = listItems.SelectedItems[0];
                System.Diagnostics.Debug.Assert(item.Tag != null, "Please call Initialize() before using of ItemPanel");
                if (item.Tag == null) return;
                itemId = item.Tag.ToString();
                DataRow[] items = dsData.Tables["Items"].Select("Id = '" + itemId.ToString() + "'");
                if (items.Length > 0)
                {
                    if (items[0]["Picture"] == System.DBNull.Value)
                    {
                        pbItemPicture.Image = new Bitmap(1, 1);
                    }
                    else
                    {
                        pbItemPicture.Image = (System.Drawing.Image)items[0]["Picture"];
                    }
                    lbFullItemName.Text = (string)items[0]["FullName"];
                    itemName = (string)items[0]["Name"];
                    if (!isLibRefresh && ItemTypeClicked != null && itemId != null) ItemTypeClicked(this, new System.EventArgs());
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
                        itemName = "";
                        itemId = null;
                    }
                }
            }
            if (SelectedItemTypeChanged != null)
                SelectedItemTypeChanged(this, e);

            OnChanged(EventArgs.Empty);

            isLibRefresh = false;
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
            GroupBox.Location = new Point(0, 0);
            GroupBox.Size = new Size(this.Size.Width, this.Size.Height);
            listItems.Size = new Size(listItems.Size.Width, this.Size.Height - listItems.Location.Y - 5);
            treeItemLibrary.Location = new Point(listItems.Location.X + listItems.Size.Width + 5, listItems.Location.Y);
            treeItemLibrary.Size = new Size(this.Size.Width - treeItemLibrary.Location.X - 5, this.Size.Height - treeItemLibrary.Location.Y - 5);
        }

        public void Initialize()
        {
            treeItemLibrary.Nodes.Clear();
            listItems.Clear();

            if (dsData != null)
            {
                dsData.Tables.Clear();
                dsData.Clear();
            }
            dsData.Tables.Add("Items");

            lbFullItemName.Text = "";
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ItemPanel));
            pbItemPicture.Image = new Bitmap(1, 1);

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
            pbItemPicture.Image = picture;
        }

        [Browsable(true)]
        public event EventHandler ItemTypeSelected; // fiers after Item Type Group selection in the library

        [Browsable(true)]
        public event EventHandler NewItemTypeSelected; // fiers after first selection of the given Item Type Group

        [Browsable(true)]
        public event EventHandler SelectedItemTypeChanged; // fiers after selection of the Item Type

        [Browsable(true)]
        public event EventHandler ItemTypeClicked; // fiers after Item Type Group selection in the library

        [Browsable(false)]
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

        [Browsable(false)]
        public Image DefaultPicture
        {
            get
            {
                DataRow[] drs = dsData.Tables["Items"].Select("Id = '" + itemId.ToString() + "'");
                if (drs.Length > 0)
                    return (Image)drs[0]["Picture"];
                else
                    return null;
            }
        }

        private string typeId;
        [Browsable(false)]
        public string TypeId
        {
            get { return typeId; }
        }

        //private string itemId;
        public string itemId;
        [Browsable(false)]
        public string ItemId
        {
            get { return itemId; }
        }

        private string itemName;
        [Browsable(false)]
        public string ItemName
        {
            get { return itemName; }
        }
        private void treeItemLibrary_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {

            System.Diagnostics.Debug.Assert(e.Node.Tag != null, "Please call Initialize() before using of ItemPanel");
            if (e.Node.Tag == null) return;

            typeId = e.Node.Tag.ToString();

            DataRow[] items = dsData.Tables["Items"].Select("typeId = '" + typeId.ToString() + "'");

            if (ItemTypeSelected != null)
                ItemTypeSelected(this, e);

            if (items.Length == 0)
                if (NewItemTypeSelected != null)
                    NewItemTypeSelected(this, e);

            items = dsData.Tables["Items"].Select("typeId = '" + typeId.ToString() + "'");
            ilItemIcons.Images.Clear();
            listItems.Items.Clear();
            listItems.LargeImageList = listItems.SmallImageList = ilItemIcons;
            foreach (DataRow row in items)
            {
                listItems.Items.Add((string)row["Name"]);
                listItems.Items[listItems.Items.Count - 1].Tag = row["Id"].ToString();
                if (row["Icon"] == System.DBNull.Value)
                {
                    ilItemIcons.Images.Add(ilDefItemIcons.Images[0]);
                    listItems.Items[listItems.Items.Count - 1].ImageIndex = ilItemIcons.Images.Count - 1;
                }
                else
                {
                    ilItemIcons.Images.Add((Bitmap)row["Icon"]);
                    listItems.Items[listItems.Items.Count - 1].ImageIndex = ilItemIcons.Images.Count - 1;
                }
            }
            isLibRefresh = true;
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

        public void InitializeItems(DataTable table)
        {
            if (table != null)
            {
                //dsData.Tables["Items"].Rows.Clear();
                //dsData.Tables["Items"].Clear();

                dsData.Tables["Items"].BeginLoadData();
                foreach (DataRow row in table.Rows)
                    dsData.Tables["Items"].LoadDataRow(new Object[] { row["Id"], row["TypeId"], row["Name"], row["Name"], row["Icon"], row["Picture"], row["CustomerProgram"], row["CustomerProgramId"], row["Path2Picture"] }, true);
                dsData.Tables["Items"].EndLoadData();

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
            foreach (ListViewItem item in listItems.Items)
                item.Selected = (item.Tag.ToString() == id);
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

        /*
        private string AddItemTypeGroup(string sGroupName, string sPath2Icon)
        {
            // CREATE PROCEDURE [dbo].[spSetItemTypeGroup] 
            // @ItemTypeGroupName dsName, @Path2Icon dsPath, @AuthorID dnSmallID, @AuthorOfficeID dnTinyID, @ItemTypeGroupClass int, 
            //	@ExpireDate ddDate, @ItemTypeGroupID int, @CurrentOfficeID dnTinyID)

            DataSet dsIn = new DataSet();
            DataTable dtIn = dsIn.Tables.Add("ItemTypeGroup");
				
            dtIn.Columns.Add("ItemTypeGroupName", System.Type.GetType("System.String"));
            dtIn.Columns.Add("Path2Icon", System.Type.GetType("System.String"));
            dtIn.Columns.Add("ItemTypeGroupClass", System.Type.GetType("System.String"));
            dtIn.Columns.Add("ExpireDate", System.Type.GetType("System.String"));
            dtIn.Columns.Add("ItemTypeGroupID", System.Type.GetType("System.String"));

            DataRow row = dtIn.NewRow();

            row["ItemTypeGroupName"] = sGroupName;
            row["Path2Icon"] = sPath2Icon;
            row["ItemTypeGroupClass"] = "1";
            row["ExpireDate"] = DBNull.Value;
            row["ItemTypeGroupID"] = DBNull.Value;

            dtIn.Rows.Add(row);
            DataSet dsOut = gemoDream.Service.ProxyGenericSet(dsIn, "Set");
            string sItemTypeGroupID = dsOut.Tables[0].Rows[0][0].ToString();
            return sItemTypeGroupID;
        }
        */

        /*
        private DataRow GetItemTypeGroup(string sItemTypeGroupID)
        {
            // CREATE Procedure [dbo].[spGetItemTypeGroup] 
            // (@ItemTypeGroupID dnTinyID,@AuthorID dnSmallID,@AuthorOfficeID dnTinyID) as			

            DataSet dsIn = new DataSet();
            DataTable dtIn = dsIn.Tables.Add("ItemTypeGroup");
				
            dtIn.Columns.Add("ItemTypeGroupID", System.Type.GetType("System.String"));
            DataRow row = dtIn.NewRow();

            row["ItemTypeGroupID"] = sItemTypeGroupID;

            dtIn.Rows.Add(row);
            DataSet dsOut = gemoDream.Service.ProxyGenericGet(dsIn);
            DataRow groupRow = dsOut.Tables[0].Rows[0];
            return groupRow;
        }
        */

        /// <summary>
        /// Determines if given group exists in the item panel
        /// </summary>
        /// <param name="sGroupName"></param>
        /// <returns>true if group with given name already exists, otherwise else</returns>
        private bool IsItemTypeGroupNameExist(string sGroupName)
        {

            gemoDream.Service.Debug_DiaspalyDataSet(dsData);

            bool IsNameExist = false;
            foreach (DataRow row in dsData.Tables["Types"].Rows)
            {
                if (row["Name"].ToString().Equals(sGroupName))
                {
                    IsNameExist = true;
                    return IsNameExist;
                }
            }
            return IsNameExist;
        }

        public void NewGroup(string sGroupName, string sPath2Icon/*Image imGroupImage*/)
        {
            /*			if (IsItemTypeGroupNameExist(sGroupName))
                        {
                            MessageBox.Show(this, "Item type group with this name already exists. Please, type another name.",
                                "Group exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return ;
                        }

                        string sItemTypeGroupID = Service.AddItemTypeGroup(sGroupName, sPath2Icon);
            */
            //
            //			DataRow groupRow = Service.GetItemTypeGroup(sItemTypeGroupID);
            //
            //			DataRow newGroupRow = dsData.Tables["Types"].NewRow();
            //			for (int i = 0; i < groupRow.Table.Columns.Count; i++)
            //			{
            //				newGroupRow[i] = groupRow[i];
            //			}
            //
            //			dsData.Tables["Types"].Rows.Add(newGroupRow);
            //
            //			this.InitializeLibrary(dsData.Tables["Types"]);

        }

        /*
        private void DeleteItemTypeGroup(string sItemTypeId)
        {
            // CREATE PROCEDURE [dbo].[spSetItemTypeGroup] 
            // @ItemTypeGroupName dsName, @Path2Icon dsPath, @AuthorID dnSmallID, @AuthorOfficeID dnTinyID, @ItemTypeGroupClass int, 
            // @ExpireDate ddDate, @ItemTypeGroupID int, @CurrentOfficeID dnTinyID)

            DataSet dsIn = new DataSet();
            DataTable dtIn = dsIn.Tables.Add("ItemTypeGroup");
				
            dtIn.Columns.Add("ItemTypeGroupName", System.Type.GetType("System.String"));
            dtIn.Columns.Add("Path2Icon", System.Type.GetType("System.String"));
            dtIn.Columns.Add("ItemTypeGroupClass", System.Type.GetType("System.String"));
            dtIn.Columns.Add("ExpireDate", System.Type.GetType("System.String"));
            dtIn.Columns.Add("ItemTypeGroupID", System.Type.GetType("System.String"));

            DataRow row = dtIn.NewRow();

            //row["ItemTypeGroupName"] = DBNull.Value;
            //row["Path2Icon"] = DBNull.Value;
            //row["ItemTypeGroupClass"] = DBNull.Value;
            row["ExpireDate"] = DateTime.Now;
            row["ItemTypeGroupID"] = sItemTypeId;

            dtIn.Rows.Add(row);
            DataSet dsOut = gemoDream.Service.ProxyGenericSet(dsIn, "Set");
        }
        */

        /// <summary>
        /// Deletes group by ItemTypeGroupID.
        /// </summary>
        /// <param name="sItemTypeGroupID"></param>
        public void DeleteGroup(string sItemTypeGroupID)
        {
            Service.DeleteItemTypeGroup(sItemTypeGroupID);

            //gemoDream.Service.debug_DiaspalyDataSet(dsData);

            /*
            string sFilter = "ID = " + sItemTypeGroupID;
            DataRow[] rows = dsData.Tables["Types"].Select(sFilter);
            DataRow rowToDelete = rows[0];
            dsData.Tables["Types"].Rows.Remove(rowToDelete);

            this.InitializeLibrary(dsData.Tables["Types"]);
            */
        }

        /// <summary>
        /// Deletes the selected group.
        /// </summary>
        public void DeleteSelectedGroup()
        {
            recursTreeDelete(treeItemLibrary.SelectedNode);

            //gemoDream.Service.debug_DiaspalyDataSet(dsData);

            /*
            string sFilter = "ID = " + sItemTypeGroupID;
            DataRow[] rows = dsData.Tables["Types"].Select(sFilter);
            DataRow rowToDelete = rows[0];
            dsData.Tables["Types"].Rows.Remove(rowToDelete);

            this.InitializeLibrary(dsData.Tables["Types"]);
            */
        }

        private void recursTreeDelete(TreeNode node)
        {
            foreach (TreeNode childNode in node.Nodes)
            {
                recursTreeDelete(childNode);
            }
            Service.DeleteItemTypeGroup(node.Tag.ToString());
        }

        /*
        private void DeleteItemType(string sItemTypeID)
        {
			
            //	spSetItemType
            //	@ItemTypeGroupID dnSmallID, @ItemTypeName dsName, @Path2Icon dsPath, @Path2Picture dsPath, 
            //	@AuthorID dnSmallID, @AuthorOfficeID dnTinyID,
            //	@DefaultCPID dnID, @DefaultCPOfficeID dnTinyID, @ExpireDate ddDate, @CurrentOfficeID dnTinyID
            //	@ItemTypeID dnSmallID,
			

            DataSet dsIn = new DataSet();
            dsIn.Tables.Add("ItemType");
            dsIn.Tables[0].Columns.Add("ItemTypeGroupID", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("ItemTypeName", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("Path2Icon", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("Path2Picture", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("DefaultCPID", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("DefaultCPOfficeID", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("ExpireDate", System.Type.GetType("System.String"));
            //dsIn.Tables[0].Columns.Add("CurrentOfficeID", System.Type.GetType("System.String"));
            dsIn.Tables[0].Columns.Add("ItemTypeID", System.Type.GetType("System.String"));

            dsIn.Tables[0].Rows.Add(dsIn.Tables[0].NewRow());
            //dsIn.Tables[0].Rows[0]["ParentPartID"] = sItemParentID.Length == 0 ? DBNull.Value : sItemParentID;
            dsIn.Tables[0].Rows[0]["ItemTypeGroupID"] = DBNull.Value;
            dsIn.Tables[0].Rows[0]["ItemTypeName"] = DBNull.Value;
            dsIn.Tables[0].Rows[0]["Path2Icon"] = DBNull.Value;
            dsIn.Tables[0].Rows[0]["Path2Picture"] = DBNull.Value;
            dsIn.Tables[0].Rows[0]["DefaultCPID"] = "2";
            dsIn.Tables[0].Rows[0]["DefaultCPOfficeID"] = "1";
            dsIn.Tables[0].Rows[0]["ExpireDate"] = DateTime.Now;
            //dsIn.Tables[0].Rows[0]["CurrentOfficeID"] = sItemContainerName;
            dsIn.Tables[0].Rows[0]["ItemTypeID"] = sItemTypeID;
            DataSet dsOut = gemoDream.Service.ProxyGenericSet(dsIn, "Set");
            dsOut.Tables[0].Rows[0][0].ToString();
        }
        */

        /// <summary>
        /// Deletes item by ItemTypeID.
        /// </summary>
        /// <param name="sItemTypeID"></param>
        public void DeleteItem(string sItemTypeID)
        {
            Service.DeleteItemType(sItemTypeID);

            string sFilter = "Id = '" + sItemTypeID + "'";

            DataRow[] rows = dsData.Tables["Items"].Select(sFilter);
            DataRow rowToDelete = rows[0];
            dsData.Tables["Items"].Rows.Remove(rowToDelete);

            this.InitializeLibrary(dsData.Tables["Types"]);
            //this.InitializeItems(dsData.Tables["Items"]);
        }



        /// <summary>
        /// Adds item type.
        /// </summary>
        /// <param name="sItemTypeID"></param>
        /// <param name="sTypeID"></param>
        /// <param name="sName"></param>
        /// <param name="sFullName"></param>
        /// <param name="imIcon"></param>
        /// <param name="imPicture"></param>
        /// <param name="sCP"></param>
        /// <param name="sCPId"></param>
        /// <param name="sPath2Pic"></param>
        public void AddItemType(string sItemTypeID, string sTypeID, string sName, string sFullName,
            Image imIcon, Image imPicture, string sCP, string sCPId, string sPath2Pic)
        {
            DataRow newRow = dsData.Tables["Items"].NewRow();
            newRow["Id"] = sItemTypeID;
            newRow["TypeId"] = sTypeID;
            newRow["Name"] = sName;
            newRow["FullName"] = sFullName;
            if (imIcon == null)
                newRow["Icon"] = DBNull.Value;
            else
                newRow["Icon"] = imIcon;
            if (imPicture == null)
                newRow["Picture"] = DBNull.Value;
            else
                newRow["Picture"] = imPicture;
            newRow["CustomerProgram"] = sCP;
            newRow["CustomerProgramId"] = sCPId;
            newRow["Path2Picture"] = sPath2Pic;

            dsData.Tables["Items"].Rows.Add(newRow);

            this.InitializeLibrary(dsData.Tables["Types"]);
        }


        /*
        public string GetItemTypePath2Picture(string sItemTypeID)
        {
            string sFilter = "Id = '" + sItemTypeID + "'";

            DataRow[] rows = dsData.Tables["Items"].Select(sFilter);
            string sPath2Pic = (string)rows[0]["Path2Picture"];
            return sPath2Pic;
        }

        public Image GetItemTypePicture(string sItemTypeID)
        {
            string sFilter = "Id = '" + sItemTypeID + "'";

            DataRow[] rows = dsData.Tables["Items"].Select(sFilter);
            Image im = (Image)rows[0]["Picture"];
            return im;
        }

        public Image GetItemTypeIcon(string sItemTypeID)
        {
            string sFilter = "Id = '" + sItemTypeID + "'";

            DataRow[] rows = dsData.Tables["Items"].Select(sFilter);
            Image im = (Image)rows[0]["Icon"];
            return im;
        }
        */

        /*
        public void ReInit()
        {
            this.InitializeLibrary(dsData.Tables["Types"]);
        }
        */
    }
}
