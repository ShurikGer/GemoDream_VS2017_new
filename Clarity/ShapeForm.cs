using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data; 
using System.Drawing.Imaging;

namespace gemoDream
{
	/// <summary>
	/// Summary description for ShapeForm.
	/// </summary>
	public class ShapeForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ImageList imgListLarge;
		private System.Windows.Forms.ListView lvShapes;
		private System.Windows.Forms.TreeView tvShapeGroups;
		private System.Windows.Forms.PictureBox picBoxShape;
		private System.ComponentModel.IContainer components;
		private DataSet dsShapeGgroups;
		private System.Windows.Forms.StatusBar statusBar1;
		private DataSet dsShapes;
		public string sShapeCode;
		public string sResShapeCode;
		private bool f;

		public ShapeForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.Text = Service.sProgramTitle + " Shapes";
			f = false;
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
																													 "l1"}, 0, System.Drawing.Color.Empty, System.Drawing.Color.Empty, new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204))));
			System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("l2", 1);
			System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("l3", 2);
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ShapeForm));
			this.lvShapes = new System.Windows.Forms.ListView();
			this.imgListLarge = new System.Windows.Forms.ImageList(this.components);
			this.picBoxShape = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tvShapeGroups = new System.Windows.Forms.TreeView();
			this.label2 = new System.Windows.Forms.Label();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.SuspendLayout();
			// 
			// lvShapes
			// 
			this.lvShapes.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			listViewItem1.StateImageIndex = 0;
			this.lvShapes.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
																					 listViewItem1,
																					 listViewItem2,
																					 listViewItem3});
			this.lvShapes.LabelWrap = false;
			this.lvShapes.LargeImageList = this.imgListLarge;
			this.lvShapes.Location = new System.Drawing.Point(288, 24);
			this.lvShapes.MultiSelect = false;
			this.lvShapes.Name = "lvShapes";
			this.lvShapes.Size = new System.Drawing.Size(720, 664);
			this.lvShapes.TabIndex = 1;
			this.lvShapes.ItemActivate += new System.EventHandler(this.lvShapes_ItemActivate);
			this.lvShapes.Enter += new System.EventHandler(this.lvShapes_Enter);
			this.lvShapes.SelectedIndexChanged += new System.EventHandler(this.lvShapes_SelectedIndexChanged);
			// 
			// imgListLarge
			// 
			this.imgListLarge.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.imgListLarge.ImageSize = new System.Drawing.Size(107, 67);
			this.imgListLarge.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListLarge.ImageStream")));
			this.imgListLarge.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// picBoxShape
			// 
			this.picBoxShape.BackColor = System.Drawing.Color.White;
			this.picBoxShape.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picBoxShape.Image = ((System.Drawing.Image)(resources.GetObject("picBoxShape.Image")));
			this.picBoxShape.Location = new System.Drawing.Point(8, 504);
			this.picBoxShape.Name = "picBoxShape";
			this.picBoxShape.Size = new System.Drawing.Size(280, 184);
			this.picBoxShape.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.picBoxShape.TabIndex = 2;
			this.picBoxShape.TabStop = false;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(7, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(240, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "Shape Group";
			// 
			// tvShapeGroups
			// 
			this.tvShapeGroups.ImageIndex = -1;
			this.tvShapeGroups.Location = new System.Drawing.Point(7, 24);
			this.tvShapeGroups.Name = "tvShapeGroups";
			this.tvShapeGroups.SelectedImageIndex = -1;
			this.tvShapeGroups.Size = new System.Drawing.Size(278, 464);
			this.tvShapeGroups.TabIndex = 4;
			this.tvShapeGroups.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvShapeGroups_AfterSelect);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(288, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 16);
			this.label2.TabIndex = 5;
			this.label2.Text = "Shape";
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 683);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Size = new System.Drawing.Size(1016, 22);
			this.statusBar1.TabIndex = 6;
			// 
			// ShapeForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(1016, 705);
			this.Controls.Add(this.statusBar1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tvShapeGroups);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.picBoxShape);
			this.Controls.Add(this.lvShapes);
			this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ShapeForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ShapeForm";
			this.Load += new System.EventHandler(this.ShapeForm_Load);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ShapeForm_KeyUp);
			this.ResumeLayout(false);

		}
		#endregion
		private void LoadData()
		{
			tvShapeGroups.Nodes.Clear();
			LoadAllShapeGroups();
			LoadShapes();
		
			lvShapes.Items.Clear();
			picBoxShape.Image = null;
		}
		private void LoadAllShapeGroups()
		{
			try
			{
			
				DataSet dsShapeGroupsParams = new DataSet();
				DataTable dtShapeGroupsParams = new DataTable("ShapeGroups");
				dsShapeGroupsParams.Tables.Add(dtShapeGroupsParams);
				dsShapeGgroups  = Service.ProxyGenericGet(dsShapeGroupsParams);//Procedure dbo.spGetShapeGroups

				if(dsShapeGgroups!=null && dsShapeGgroups.Tables.Count>0)
				{
					DataRow[] drParentShapeGroups = dsShapeGgroups.Tables[0].Select("ParentShapeGroupID is null");
					foreach(DataRow drParentShapeGroup in drParentShapeGroups)
					{
						TreeNode ParentNodeShapeGroup = new TreeNode(drParentShapeGroup["ShapeGroupName"].ToString());
						ParentNodeShapeGroup.Tag=drParentShapeGroup["ShapeGroupID"].ToString();
						tvShapeGroups.Nodes.Add(ParentNodeShapeGroup);
					
						GetChild(drParentShapeGroup["ShapeGroupID"].ToString(), ParentNodeShapeGroup);
					}
				}
			}
			catch(Exception ex)
			{
				string msg = ex.Message;
			}
		}
		private void GetChild(string sParentShapeGroupID , TreeNode ParentNodeShapeGroup)
		{
			try
			{
				DataRow[] drChildShapeGroups = dsShapeGgroups.Tables[0].Select("ParentShapeGroupID = '" + sParentShapeGroupID + "'");
				if(drChildShapeGroups.Length == 0)
				{
					return;
				}
				else
				{
					foreach(DataRow drChildShapeGroup in drChildShapeGroups)
					{
						TreeNode ChildNodeShapeGroup = new TreeNode(drChildShapeGroup["ShapeGroupName"].ToString());
						ChildNodeShapeGroup.Tag=drChildShapeGroup["ShapeGroupID"].ToString();
						ParentNodeShapeGroup.Nodes.Add(ChildNodeShapeGroup);
						GetChild(drChildShapeGroup["ShapeGroupID"].ToString() , ChildNodeShapeGroup);					
					}
				}
			}
			catch(Exception ex)
			{
				string msg = ex.Message;
			}
		}
		
		
		private void tvShapeGroups_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			statusBar1.Text = "Loading";
			this.Cursor = Cursors.WaitCursor;

			string ShapeGroupID = e.Node.Tag.ToString();
			SelectShapeGroup(ShapeGroupID);

			this.Cursor = Cursors.Default;
			statusBar1.Text = " ";
		}

		private void LoadShapes()
		{
			DataSet dsShapeParaps = new DataSet();
			DataTable dtShapeParams = new DataTable("Shapes");
			dsShapeParaps.Tables.Add(dtShapeParams);
			dsShapes = Service.ProxyGenericGet(dsShapeParaps);//Procedure dbo.spGetShapes
			ChangePlace();
		}
		private void SelectShapeGroup(string ShapeGroupID)
		{
			
			lvShapes.Items.Clear();
			imgListLarge.Images.Clear();
			
			try
			{
				DataRow[] drShapes = dsShapes.Tables[0].Select("ShapeGroupID = '" + ShapeGroupID + "'");
				string pathToShape = Client.GetOfficeDirPath("iconDir");
				string myShapeFileName = "";
				foreach(DataRow drShape in drShapes)
				{
					myShapeFileName = pathToShape + drShape["Path2Drawing"].ToString();
					if (System.IO.File.Exists(myShapeFileName))
					{
					
					//old part
					//Image imgShape = (Image)Service.ExtractImageFromString(drShape["Image_Path2Drawing"].ToString(), 
					//														drShape["Path2Drawing"].ToString());
					//New part - 03/31/08
					Image imgShape = System.Drawing.Image.FromFile(myShapeFileName);//  
					Image icoShape = imgShape.GetThumbnailImage(imgListLarge.ImageSize.Width,imgListLarge.ImageSize.Height,null,IntPtr.Zero);
					imgListLarge.Images.Add(icoShape);
					string sPath = drShape["Path2Drawing"].ToString();
					string sPath1 = sPath.Replace("/","\\");
					
					string sFileName = sPath1.Substring(sPath1.LastIndexOf("\\")+1);
					
					lvShapes.Items.Add(sFileName,imgListLarge.Images.Count-1);
					lvShapes.Items[lvShapes.Items.Count-1].Tag = drShape["ShapeCode"].ToString();
					}
				}
				if(sShapeCode != null && sShapeCode != "" && lvShapes.Items.Count>0 && !f)
				{
					foreach(ListViewItem lvi in lvShapes.Items)
					{
						if(lvi.Tag.ToString()==sShapeCode)
						{
							lvShapes.Items[lvi.Index].Selected = true;
							lvShapes.Focus();
							lvShapes.Select();
							f = true;
							return;
						}
					}
				}
			}
			catch(Exception ex)
			{
				string msg = ex.Message;
			}

		}

		private void lvShapes_ItemActivate(object sender, System.EventArgs e)
		{
			if(lvShapes.SelectedItems.Count>0)
			{
				DialogResult result;
				result = MessageBox.Show(this,"Save selected Shape? ","Select Shape",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1);
				if(result == DialogResult.Yes)
				{
					sResShapeCode = lvShapes.SelectedItems[0].Tag.ToString();
					this.Close();
				}
			}
		}

		private void lvShapes_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				if(lvShapes.Items.Count > 0 && lvShapes.SelectedItems.Count>0)
				{
					string sShapeCode = lvShapes.SelectedItems[0].Tag.ToString();
					string pathToShape = Client.GetOfficeDirPath("iconDir");
					string myShapeFileName = "";

					DataRow[] drShapes = dsShapes.Tables[0].Select("ShapeCode = '" + sShapeCode + "'");
					if(drShapes.Length > 0)
					{
						myShapeFileName = pathToShape + drShapes[0]["Path2Drawing"].ToString();;

						if (System.IO.File.Exists(myShapeFileName))
						{
//							Old Part
//							Image imgShape = (Image)Service.ExtractImageFromString(drShapes[0]["Image_Path2Drawing"].ToString(), 
//								drShapes[0]["Path2Drawing"].ToString());
					
							Image imgShape = System.Drawing.Image.FromFile(myShapeFileName);
							double k1 = (double)picBoxShape.ClientSize.Height / imgShape.Height;
							double k2 = (double)picBoxShape.ClientSize.Width / imgShape.Width;
							double k = Math.Min(k1,k2);
							int w1 = Convert.ToInt32(imgShape.Width * k) - 1;
							int h1 = Convert.ToInt32(imgShape.Height * k) - 1;

							Image icoShape = imgShape.GetThumbnailImage(w1,h1,null,IntPtr.Zero);
							picBoxShape.Image = icoShape;
						}
					
					}
				}
			}
			catch(Exception ex)
			{
				string msg = ex.Message;
			}
			
		}

		
		private void lvShapes_Enter(object sender, System.EventArgs e)
		{
			if(lvShapes.SelectedItems.Count < 1 && lvShapes.Items.Count > 0)
				lvShapes.Items[0].Selected = true;
		}

		private void ShapeForm_Load(object sender, System.EventArgs e)
		{
			LoadData();
			SelectShape();
			lvShapes.Select();
		}
		private void SelectShape()
		{
			if(sShapeCode != "" && dsShapes != null && dsShapes.Tables.Count>0 && dsShapes.Tables[0].Rows.Count>0)
			{
				DataRow[] drShapes = dsShapes.Tables[0].Select("ShapeCode = '" + sShapeCode + "'");
				if(drShapes.Length>0)
				{
					string sShapeGroupID = drShapes[0]["ShapeGroupID"].ToString();
					DataRow[] drGgroups = dsShapeGgroups.Tables[0].Select("ShapeGroupID = '" + sShapeGroupID + "'");
					TreeNode SelectedNodeGroup = GetNode(tvShapeGroups.Nodes,sShapeGroupID);
					//tvShapeGroups.Focus();
					tvShapeGroups.Select();
					tvShapeGroups.SelectedNode = SelectedNodeGroup;
				}
			}
			tvShapeGroups.ExpandAll();
		}
		private TreeNode GetNode(TreeNodeCollection NodesShapeGroups,string ShapeGroupID)
		{
			TreeNode resultNode = null;
			foreach(TreeNode NodeShapeGroup in NodesShapeGroups)
			{
				if(NodeShapeGroup.Tag.ToString()== ShapeGroupID)
				{
					return NodeShapeGroup;
				}
				else
				{
					if(NodeShapeGroup.Nodes.Count>0)
					{
						resultNode = GetNode(NodeShapeGroup.Nodes,ShapeGroupID);
						if(resultNode != null && resultNode.Tag.ToString()== ShapeGroupID)
							return resultNode;
					}
				}
			}
			return resultNode;
		}

		private void ChangePlace()
		{	//Change selected shape and first shape
			if(sShapeCode != null && sShapeCode != "" && dsShapes != null && dsShapes.Tables.Count > 0)
			{
				DataRow[] drShapes = dsShapes.Tables[0].Select("ShapeCode = '" + sShapeCode + "'");
				if(drShapes.Length>0)
				{
					foreach(DataColumn dcShape in dsShapes.Tables[0].Columns)
					{
						object TempObj = dsShapes.Tables[0].Rows[0][dcShape];
						dsShapes.Tables[0].Rows[0][dcShape] = drShapes[0][dcShape];
						drShapes[0][dcShape] = TempObj;
					}
				}
			}
		
		}

		private void ShapeForm_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Escape)
			{
				DialogResult result;
				result = MessageBox.Show(this,"Close without saving? ","Select Shape",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1);
				if(result == DialogResult.Yes)
				{
					sResShapeCode = "";
					this.Close();
				}
			}
		}
	}
}
