using Manina.Windows.Forms;

namespace ImageListViewDemo
{
    partial class DemoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DemoForm));
			this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.imageListView1 = new Manina.Windows.Forms.ImageListView();
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.thumbnailsToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.galleryToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.paneToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.detailsToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.clearCacheToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.rendererToolStripLabel = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.renderertoolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.thumbnailSizeToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
			this.x48ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x96ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x120ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x150ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x200ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.timerStatus = new System.Windows.Forms.Timer(this.components);
			this.rotateCWToolStripButton = new System.Windows.Forms.ToolStripSeparator();
			this.rotateCCWToolStripButton = new System.Windows.Forms.ToolStripSeparator();
			this.removeAllToolStripButton = new System.Windows.Forms.ToolStripSeparator();
			this.removeToolStripButton = new System.Windows.Forms.ToolStripSeparator();
			this.addToolStripButton = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
			this.toolStripContainer1.ContentPanel.SuspendLayout();
			this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
			this.toolStripContainer1.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.toolStrip.SuspendLayout();
			this.contextMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStripContainer1
			// 
			// 
			// toolStripContainer1.BottomToolStripPanel
			// 
			this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip);
			// 
			// toolStripContainer1.ContentPanel
			// 
			this.toolStripContainer1.ContentPanel.Controls.Add(this.imageListView1);
			this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1048, 663);
			this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStripContainer1.LeftToolStripPanelVisible = false;
			this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
			this.toolStripContainer1.Name = "toolStripContainer1";
			this.toolStripContainer1.RightToolStripPanelVisible = false;
			this.toolStripContainer1.Size = new System.Drawing.Size(1048, 723);
			this.toolStripContainer1.TabIndex = 0;
			this.toolStripContainer1.Text = "toolStripContainer1";
			// 
			// toolStripContainer1.TopToolStripPanel
			// 
			this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip);
			// 
			// statusStrip
			// 
			this.statusStrip.Dock = System.Windows.Forms.DockStyle.None;
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
			this.statusStrip.Location = new System.Drawing.Point(0, 0);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(1048, 22);
			this.statusStrip.TabIndex = 0;
			// 
			// toolStripStatusLabel
			// 
			this.toolStripStatusLabel.Name = "toolStripStatusLabel";
			this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
			this.toolStripStatusLabel.Text = "Ready";
			// 
			// imageListView1
			// 
			this.imageListView1.DefaultImage = null;
			this.imageListView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.imageListView1.ErrorImage = null;
			this.imageListView1.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.imageListView1.Location = new System.Drawing.Point(0, 0);
			this.imageListView1.Name = "imageListView1";
			this.imageListView1.Size = new System.Drawing.Size(1048, 663);
			this.imageListView1.TabIndex = 0;
			this.imageListView1.Text = "";
			this.imageListView1.ThumbnailSize = new System.Drawing.Size(120, 120);
			this.imageListView1.ItemClick += new Manina.Windows.Forms.ItemClickEventHandler(this.imageListView1_ItemClick);
			this.imageListView1.SelectionChanged += new System.EventHandler(this.imageListView1_SelectionChanged);
			this.imageListView1.ThumbnailCached += new Manina.Windows.Forms.ThumbnailCachedEventHandler(this.imageListView1_ThumbnailCached);
			// 
			// toolStrip
			// 
			this.toolStrip.BackColor = System.Drawing.SystemColors.ControlLight;
			this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thumbnailsToolStripButton,
            this.addToolStripButton,
            this.galleryToolStripButton,
            this.removeToolStripButton,
            this.paneToolStripButton,
            this.removeAllToolStripButton,
            this.toolStripSeparator1,
            this.detailsToolStripButton,
            this.rotateCCWToolStripButton,
            this.clearCacheToolStripButton,
            this.rotateCWToolStripButton,
            this.toolStripSeparator5,
            this.toolStripSeparator2,
            this.rendererToolStripLabel,
            this.toolStripSeparator4,
            this.renderertoolStripComboBox,
            this.toolStripSeparator3,
            this.thumbnailSizeToolStripDropDownButton});
			this.toolStrip.Location = new System.Drawing.Point(3, 0);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(638, 38);
			this.toolStrip.TabIndex = 0;
			// 
			// thumbnailsToolStripButton
			// 
			this.thumbnailsToolStripButton.BackColor = System.Drawing.Color.Snow;
			this.thumbnailsToolStripButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.thumbnailsToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("thumbnailsToolStripButton.Image")));
			this.thumbnailsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.thumbnailsToolStripButton.Name = "thumbnailsToolStripButton";
			this.thumbnailsToolStripButton.Size = new System.Drawing.Size(74, 35);
			this.thumbnailsToolStripButton.Text = "Thumbnails";
			this.thumbnailsToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.thumbnailsToolStripButton.Click += new System.EventHandler(this.thumbnailsToolStripButton_Click);
			// 
			// galleryToolStripButton
			// 
			this.galleryToolStripButton.BackColor = System.Drawing.Color.Snow;
			this.galleryToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("galleryToolStripButton.Image")));
			this.galleryToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.galleryToolStripButton.Name = "galleryToolStripButton";
			this.galleryToolStripButton.Size = new System.Drawing.Size(47, 35);
			this.galleryToolStripButton.Text = "Gallery";
			this.galleryToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.galleryToolStripButton.Click += new System.EventHandler(this.galleryToolStripButton_Click);
			// 
			// paneToolStripButton
			// 
			this.paneToolStripButton.BackColor = System.Drawing.Color.Snow;
			this.paneToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("paneToolStripButton.Image")));
			this.paneToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.paneToolStripButton.Name = "paneToolStripButton";
			this.paneToolStripButton.Size = new System.Drawing.Size(37, 35);
			this.paneToolStripButton.Text = "Pane";
			this.paneToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.paneToolStripButton.Click += new System.EventHandler(this.paneToolStripButton_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
			// 
			// detailsToolStripButton
			// 
			this.detailsToolStripButton.BackColor = System.Drawing.Color.Snow;
			this.detailsToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("detailsToolStripButton.Image")));
			this.detailsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.detailsToolStripButton.Name = "detailsToolStripButton";
			this.detailsToolStripButton.Size = new System.Drawing.Size(46, 35);
			this.detailsToolStripButton.Text = "Details";
			this.detailsToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.detailsToolStripButton.Click += new System.EventHandler(this.detailsToolStripButton_Click);
			// 
			// clearCacheToolStripButton
			// 
			this.clearCacheToolStripButton.BackColor = System.Drawing.Color.Snow;
			this.clearCacheToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.clearCacheToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.clearCacheToolStripButton.Name = "clearCacheToolStripButton";
			this.clearCacheToolStripButton.Size = new System.Drawing.Size(50, 35);
			this.clearCacheToolStripButton.Text = "Refresh";
			this.clearCacheToolStripButton.Click += new System.EventHandler(this.clearCacheToolStripButton_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 38);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
			// 
			// rendererToolStripLabel
			// 
			this.rendererToolStripLabel.BackColor = System.Drawing.Color.Snow;
			this.rendererToolStripLabel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.rendererToolStripLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.rendererToolStripLabel.Name = "rendererToolStripLabel";
			this.rendererToolStripLabel.Size = new System.Drawing.Size(57, 35);
			this.rendererToolStripLabel.Text = "Renderer:";
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 38);
			// 
			// renderertoolStripComboBox
			// 
			this.renderertoolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.renderertoolStripComboBox.Name = "renderertoolStripComboBox";
			this.renderertoolStripComboBox.Size = new System.Drawing.Size(121, 38);
			this.renderertoolStripComboBox.SelectedIndexChanged += new System.EventHandler(this.renderertoolStripComboBox_SelectedIndexChanged);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
			// 
			// thumbnailSizeToolStripDropDownButton
			// 
			this.thumbnailSizeToolStripDropDownButton.BackColor = System.Drawing.Color.Snow;
			this.thumbnailSizeToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.thumbnailSizeToolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.x48ToolStripMenuItem,
            this.x96ToolStripMenuItem,
            this.x120ToolStripMenuItem,
            this.x150ToolStripMenuItem,
            this.x200ToolStripMenuItem});
			this.thumbnailSizeToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.thumbnailSizeToolStripDropDownButton.Name = "thumbnailSizeToolStripDropDownButton";
			this.thumbnailSizeToolStripDropDownButton.Size = new System.Drawing.Size(101, 35);
			this.thumbnailSizeToolStripDropDownButton.Text = "Thumbnail Size";
			// 
			// x48ToolStripMenuItem
			// 
			this.x48ToolStripMenuItem.Name = "x48ToolStripMenuItem";
			this.x48ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.x48ToolStripMenuItem.Text = "48 x 48";
			this.x48ToolStripMenuItem.Click += new System.EventHandler(this.x48ToolStripMenuItem_Click);
			// 
			// x96ToolStripMenuItem
			// 
			this.x96ToolStripMenuItem.Name = "x96ToolStripMenuItem";
			this.x96ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.x96ToolStripMenuItem.Text = "96 x 96";
			this.x96ToolStripMenuItem.Click += new System.EventHandler(this.x96ToolStripMenuItem_Click);
			// 
			// x120ToolStripMenuItem
			// 
			this.x120ToolStripMenuItem.Name = "x120ToolStripMenuItem";
			this.x120ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.x120ToolStripMenuItem.Text = "120 x120";
			this.x120ToolStripMenuItem.Click += new System.EventHandler(this.x120ToolStripMenuItem_Click);
			// 
			// x150ToolStripMenuItem
			// 
			this.x150ToolStripMenuItem.Name = "x150ToolStripMenuItem";
			this.x150ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.x150ToolStripMenuItem.Text = "150 x150";
			this.x150ToolStripMenuItem.Click += new System.EventHandler(this.x150ToolStripMenuItem_Click);
			// 
			// x200ToolStripMenuItem
			// 
			this.x200ToolStripMenuItem.Name = "x200ToolStripMenuItem";
			this.x200ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.x200ToolStripMenuItem.Text = "200 x 200";
			this.x200ToolStripMenuItem.Click += new System.EventHandler(this.x200ToolStripMenuItem_Click);
			// 
			// contextMenuStrip
			// 
			this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
			this.contextMenuStrip.Name = "contextMenuStrip";
			this.contextMenuStrip.Size = new System.Drawing.Size(108, 26);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
			// 
			// openFileDialog
			// 
			this.openFileDialog.Filter = resources.GetString("openFileDialog.Filter");
			this.openFileDialog.Multiselect = true;
			this.openFileDialog.ShowReadOnly = true;
			// 
			// timerStatus
			// 
			this.timerStatus.Interval = 2000;
			this.timerStatus.Tick += new System.EventHandler(this.timerStatus_Tick);
			// 
			// rotateCWToolStripButton
			// 
			this.rotateCWToolStripButton.Name = "rotateCWToolStripButton";
			this.rotateCWToolStripButton.Size = new System.Drawing.Size(6, 38);
			this.rotateCWToolStripButton.Click += new System.EventHandler(this.rotateCWToolStripButton_Click);
			// 
			// rotateCCWToolStripButton
			// 
			this.rotateCCWToolStripButton.Name = "rotateCCWToolStripButton";
			this.rotateCCWToolStripButton.Size = new System.Drawing.Size(6, 38);
			this.rotateCCWToolStripButton.Click += new System.EventHandler(this.rotateCCWToolStripButton_Click);
			// 
			// removeAllToolStripButton
			// 
			this.removeAllToolStripButton.BackColor = System.Drawing.SystemColors.Control;
			this.removeAllToolStripButton.Name = "removeAllToolStripButton";
			this.removeAllToolStripButton.Size = new System.Drawing.Size(6, 38);
			this.removeAllToolStripButton.Click += new System.EventHandler(this.removeAllToolStripButton_Click);
			// 
			// removeToolStripButton
			// 
			this.removeToolStripButton.Name = "removeToolStripButton";
			this.removeToolStripButton.Size = new System.Drawing.Size(6, 38);
			this.removeToolStripButton.Click += new System.EventHandler(this.removeToolStripButton_Click);
			// 
			// addToolStripButton
			// 
			this.addToolStripButton.BackColor = System.Drawing.SystemColors.Control;
			this.addToolStripButton.Name = "addToolStripButton";
			this.addToolStripButton.Size = new System.Drawing.Size(6, 38);
			this.addToolStripButton.Click += new System.EventHandler(this.addToolStripButton_Click);
			// 
			// DemoForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(1048, 723);
			this.Controls.Add(this.toolStripContainer1);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "DemoForm";
			this.Text = "Image List View";
			this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
			this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
			this.toolStripContainer1.ContentPanel.ResumeLayout(false);
			this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
			this.toolStripContainer1.TopToolStripPanel.PerformLayout();
			this.toolStripContainer1.ResumeLayout(false);
			this.toolStripContainer1.PerformLayout();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.contextMenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel rendererToolStripLabel;
        private System.Windows.Forms.ToolStripComboBox renderertoolStripComboBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton detailsToolStripButton;
        private System.Windows.Forms.ToolStripButton thumbnailsToolStripButton;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Timer timerStatus;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        //private System.Windows.Forms.ToolStripButton columnsToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton galleryToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton clearCacheToolStripButton;
        private System.Windows.Forms.ToolStripDropDownButton thumbnailSizeToolStripDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem x48ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x96ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x120ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x150ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x200ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton paneToolStripButton;
        private ImageListView imageListView1;
		private System.Windows.Forms.ToolStripSeparator addToolStripButton;
		private System.Windows.Forms.ToolStripSeparator removeToolStripButton;
		private System.Windows.Forms.ToolStripSeparator removeAllToolStripButton;
		private System.Windows.Forms.ToolStripSeparator rotateCCWToolStripButton;
		private System.Windows.Forms.ToolStripSeparator rotateCWToolStripButton;
	}
}

