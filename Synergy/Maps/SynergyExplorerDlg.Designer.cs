namespace Maps
{
    partial class SynergyExplorerDlg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SynergyExplorerDlg));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPropertis = new System.Windows.Forms.TabPage();
            this.tabVersions = new System.Windows.Forms.TabPage();
            this.tabMembers = new System.Windows.Forms.TabPage();
            this.btnRenameFolder = new System.Windows.Forms.Button();
            this.btnDeleteFolder = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnNewFolder = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.btnUnlock = new System.Windows.Forms.PictureBox();
            this.btnLock = new System.Windows.Forms.PictureBox();
            this.btnCopyFolder = new System.Windows.Forms.Button();
            this.btnCopyFile = new System.Windows.Forms.Button();
            this.btnNewVersion = new System.Windows.Forms.Button();
            this.btnAddFiles = new System.Windows.Forms.Button();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.btnShareMap = new System.Windows.Forms.Button();
            this.btnTake = new System.Windows.Forms.Button();
            this.btnShareFolder = new System.Windows.Forms.Button();
            this.btnNewPlace = new System.Windows.Forms.Button();
            this.pictSearch = new System.Windows.Forms.PictureBox();
            this.panelPublish = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPublish = new System.Windows.Forms.Button();
            this.lblPublish = new System.Windows.Forms.Label();
            this.listMembers = new System.Windows.Forms.ListBox();
            this.Column1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnUnlock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictSearch)).BeginInit();
            this.panelPublish.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(12, 113);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 1;
            this.treeView1.ShowLines = false;
            this.treeView1.Size = new System.Drawing.Size(261, 320);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder_closed.png");
            this.imageList1.Images.SetKeyName(1, "folder_opened.png");
            this.imageList1.Images.SetKeyName(2, "Copy.png");
            this.imageList1.Images.SetKeyName(3, "version.png");
            this.imageList1.Images.SetKeyName(4, "openfile.png");
            this.imageList1.Images.SetKeyName(5, "share_s.png");
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dataGridView1.Location = new System.Drawing.Point(284, 113);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(538, 320);
            this.dataGridView1.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPropertis);
            this.tabControl1.Controls.Add(this.tabVersions);
            this.tabControl1.Controls.Add(this.tabMembers);
            this.tabControl1.Location = new System.Drawing.Point(284, 439);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(543, 127);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPropertis
            // 
            this.tabPropertis.Location = new System.Drawing.Point(4, 22);
            this.tabPropertis.Name = "tabPropertis";
            this.tabPropertis.Padding = new System.Windows.Forms.Padding(3);
            this.tabPropertis.Size = new System.Drawing.Size(535, 101);
            this.tabPropertis.TabIndex = 0;
            this.tabPropertis.Text = "Properties";
            this.tabPropertis.UseVisualStyleBackColor = true;
            // 
            // tabVersions
            // 
            this.tabVersions.Location = new System.Drawing.Point(4, 22);
            this.tabVersions.Name = "tabVersions";
            this.tabVersions.Padding = new System.Windows.Forms.Padding(3);
            this.tabVersions.Size = new System.Drawing.Size(535, 101);
            this.tabVersions.TabIndex = 1;
            this.tabVersions.Text = "Versions";
            this.tabVersions.UseVisualStyleBackColor = true;
            // 
            // tabMembers
            // 
            this.tabMembers.Location = new System.Drawing.Point(4, 22);
            this.tabMembers.Name = "tabMembers";
            this.tabMembers.Padding = new System.Windows.Forms.Padding(3);
            this.tabMembers.Size = new System.Drawing.Size(535, 101);
            this.tabMembers.TabIndex = 2;
            this.tabMembers.Text = "Members";
            this.tabMembers.UseVisualStyleBackColor = true;
            // 
            // btnRenameFolder
            // 
            this.btnRenameFolder.AutoSize = true;
            this.btnRenameFolder.BackColor = System.Drawing.SystemColors.Control;
            this.btnRenameFolder.FlatAppearance.BorderSize = 0;
            this.btnRenameFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRenameFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRenameFolder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRenameFolder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRenameFolder.ImageIndex = 0;
            this.btnRenameFolder.Location = new System.Drawing.Point(104, 84);
            this.btnRenameFolder.Name = "btnRenameFolder";
            this.btnRenameFolder.Size = new System.Drawing.Size(98, 23);
            this.btnRenameFolder.TabIndex = 4;
            this.btnRenameFolder.Text = "Переименовать";
            this.btnRenameFolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRenameFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRenameFolder.UseVisualStyleBackColor = false;
            // 
            // btnDeleteFolder
            // 
            this.btnDeleteFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteFolder.AutoSize = true;
            this.btnDeleteFolder.BackColor = System.Drawing.SystemColors.Control;
            this.btnDeleteFolder.FlatAppearance.BorderSize = 0;
            this.btnDeleteFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDeleteFolder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDeleteFolder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteFolder.Location = new System.Drawing.Point(215, 84);
            this.btnDeleteFolder.Name = "btnDeleteFolder";
            this.btnDeleteFolder.Size = new System.Drawing.Size(60, 23);
            this.btnDeleteFolder.TabIndex = 16;
            this.btnDeleteFolder.Text = "Удалить";
            this.btnDeleteFolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteFolder.UseVisualStyleBackColor = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // txtSearch
            // 
            this.txtSearch.ForeColor = System.Drawing.Color.Gray;
            this.txtSearch.Location = new System.Drawing.Point(564, 30);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(226, 20);
            this.txtSearch.TabIndex = 19;
            this.txtSearch.Text = "Имя файла содержит...";
            this.txtSearch.Visible = false;
            // 
            // btnNewFolder
            // 
            this.btnNewFolder.AutoSize = true;
            this.btnNewFolder.BackColor = System.Drawing.SystemColors.Control;
            this.btnNewFolder.FlatAppearance.BorderSize = 0;
            this.btnNewFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnNewFolder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnNewFolder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewFolder.ImageIndex = 0;
            this.btnNewFolder.Location = new System.Drawing.Point(10, 84);
            this.btnNewFolder.Name = "btnNewFolder";
            this.btnNewFolder.Size = new System.Drawing.Size(82, 23);
            this.btnNewFolder.TabIndex = 17;
            this.btnNewFolder.Text = "Новая папка";
            this.btnNewFolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNewFolder.UseVisualStyleBackColor = false;
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "take.png");
            this.imageList2.Images.SetKeyName(1, "share.png");
            this.imageList2.Images.SetKeyName(2, "addfiles.png");
            this.imageList2.Images.SetKeyName(3, "newplace.png");
            this.imageList2.Images.SetKeyName(4, "download.png");
            this.imageList2.Images.SetKeyName(5, "publish.png");
            // 
            // btnUnlock
            // 
            this.btnUnlock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUnlock.Image = ((System.Drawing.Image)(resources.GetObject("btnUnlock.Image")));
            this.btnUnlock.Location = new System.Drawing.Point(802, 88);
            this.btnUnlock.Name = "btnUnlock";
            this.btnUnlock.Size = new System.Drawing.Size(16, 16);
            this.btnUnlock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnUnlock.TabIndex = 68;
            this.btnUnlock.TabStop = false;
            // 
            // btnLock
            // 
            this.btnLock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLock.Image = ((System.Drawing.Image)(resources.GetObject("btnLock.Image")));
            this.btnLock.Location = new System.Drawing.Point(771, 88);
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(16, 16);
            this.btnLock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnLock.TabIndex = 67;
            this.btnLock.TabStop = false;
            // 
            // btnCopyFolder
            // 
            this.btnCopyFolder.FlatAppearance.BorderSize = 0;
            this.btnCopyFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyFolder.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCopyFolder.ImageIndex = 4;
            this.btnCopyFolder.ImageList = this.imageList2;
            this.btnCopyFolder.Location = new System.Drawing.Point(214, 14);
            this.btnCopyFolder.Name = "btnCopyFolder";
            this.btnCopyFolder.Size = new System.Drawing.Size(86, 51);
            this.btnCopyFolder.TabIndex = 66;
            this.btnCopyFolder.Text = "Копировать";
            this.btnCopyFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCopyFolder.UseVisualStyleBackColor = true;
            // 
            // btnCopyFile
            // 
            this.btnCopyFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyFile.FlatAppearance.BorderSize = 0;
            this.btnCopyFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCopyFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCopyFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopyFile.ImageIndex = 2;
            this.btnCopyFile.ImageList = this.imageList1;
            this.btnCopyFile.Location = new System.Drawing.Point(521, 84);
            this.btnCopyFile.Name = "btnCopyFile";
            this.btnCopyFile.Size = new System.Drawing.Size(108, 23);
            this.btnCopyFile.TabIndex = 10;
            this.btnCopyFile.Text = " Copy...";
            this.btnCopyFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopyFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCopyFile.UseVisualStyleBackColor = true;
            // 
            // btnNewVersion
            // 
            this.btnNewVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewVersion.FlatAppearance.BorderSize = 0;
            this.btnNewVersion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnNewVersion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnNewVersion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewVersion.ImageIndex = 3;
            this.btnNewVersion.ImageList = this.imageList1;
            this.btnNewVersion.Location = new System.Drawing.Point(638, 84);
            this.btnNewVersion.Name = "btnNewVersion";
            this.btnNewVersion.Size = new System.Drawing.Size(108, 23);
            this.btnNewVersion.TabIndex = 9;
            this.btnNewVersion.Text = " Новая версия";
            this.btnNewVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewVersion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNewVersion.UseVisualStyleBackColor = true;
            // 
            // btnAddFiles
            // 
            this.btnAddFiles.FlatAppearance.BorderSize = 0;
            this.btnAddFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFiles.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddFiles.ImageIndex = 2;
            this.btnAddFiles.ImageList = this.imageList2;
            this.btnAddFiles.Location = new System.Drawing.Point(96, 14);
            this.btnAddFiles.Name = "btnAddFiles";
            this.btnAddFiles.Size = new System.Drawing.Size(122, 51);
            this.btnAddFiles.TabIndex = 65;
            this.btnAddFiles.Text = "Добавить файл(ы)";
            this.btnAddFiles.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAddFiles.UseVisualStyleBackColor = true;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.BackColor = System.Drawing.SystemColors.Control;
            this.btnOpenFile.FlatAppearance.BorderSize = 0;
            this.btnOpenFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOpenFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOpenFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenFile.ImageIndex = 4;
            this.btnOpenFile.ImageList = this.imageList1;
            this.btnOpenFile.Location = new System.Drawing.Point(288, 84);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(108, 23);
            this.btnOpenFile.TabIndex = 5;
            this.btnOpenFile.Text = " Open";
            this.btnOpenFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOpenFile.UseVisualStyleBackColor = false;
            // 
            // btnShareMap
            // 
            this.btnShareMap.FlatAppearance.BorderSize = 0;
            this.btnShareMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShareMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnShareMap.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnShareMap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShareMap.ImageIndex = 5;
            this.btnShareMap.ImageList = this.imageList1;
            this.btnShareMap.Location = new System.Drawing.Point(402, 84);
            this.btnShareMap.Name = "btnShareMap";
            this.btnShareMap.Size = new System.Drawing.Size(108, 23);
            this.btnShareMap.TabIndex = 6;
            this.btnShareMap.Text = " Share";
            this.btnShareMap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShareMap.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnShareMap.UseVisualStyleBackColor = true;
            // 
            // btnTake
            // 
            this.btnTake.FlatAppearance.BorderSize = 0;
            this.btnTake.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTake.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTake.ImageIndex = 0;
            this.btnTake.ImageList = this.imageList2;
            this.btnTake.Location = new System.Drawing.Point(388, 14);
            this.btnTake.Name = "btnTake";
            this.btnTake.Size = new System.Drawing.Size(89, 51);
            this.btnTake.TabIndex = 64;
            this.btnTake.Text = "Принять";
            this.btnTake.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnTake.UseVisualStyleBackColor = true;
            // 
            // btnShareFolder
            // 
            this.btnShareFolder.FlatAppearance.BorderSize = 0;
            this.btnShareFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShareFolder.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnShareFolder.ImageIndex = 1;
            this.btnShareFolder.ImageList = this.imageList2;
            this.btnShareFolder.Location = new System.Drawing.Point(304, 14);
            this.btnShareFolder.Name = "btnShareFolder";
            this.btnShareFolder.Size = new System.Drawing.Size(85, 51);
            this.btnShareFolder.TabIndex = 63;
            this.btnShareFolder.Text = "Поделиться";
            this.btnShareFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnShareFolder.UseVisualStyleBackColor = true;
            // 
            // btnNewPlace
            // 
            this.btnNewPlace.FlatAppearance.BorderSize = 0;
            this.btnNewPlace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewPlace.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNewPlace.ImageIndex = 3;
            this.btnNewPlace.ImageList = this.imageList2;
            this.btnNewPlace.Location = new System.Drawing.Point(10, 14);
            this.btnNewPlace.Name = "btnNewPlace";
            this.btnNewPlace.Size = new System.Drawing.Size(88, 51);
            this.btnNewPlace.TabIndex = 62;
            this.btnNewPlace.Text = "Новое место";
            this.btnNewPlace.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNewPlace.UseVisualStyleBackColor = true;
            this.btnNewPlace.Click += new System.EventHandler(this.btnNewPlace_Click);
            // 
            // pictSearch
            // 
            this.pictSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictSearch.Image = ((System.Drawing.Image)(resources.GetObject("pictSearch.Image")));
            this.pictSearch.Location = new System.Drawing.Point(798, 26);
            this.pictSearch.Name = "pictSearch";
            this.pictSearch.Size = new System.Drawing.Size(24, 24);
            this.pictSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictSearch.TabIndex = 56;
            this.pictSearch.TabStop = false;
            this.pictSearch.Click += new System.EventHandler(this.pictSearch_Click);
            // 
            // panelPublish
            // 
            this.panelPublish.Controls.Add(this.btnCancel);
            this.panelPublish.Controls.Add(this.btnPublish);
            this.panelPublish.Controls.Add(this.lblPublish);
            this.panelPublish.Location = new System.Drawing.Point(328, 155);
            this.panelPublish.Name = "panelPublish";
            this.panelPublish.Size = new System.Drawing.Size(456, 237);
            this.panelPublish.TabIndex = 69;
            this.panelPublish.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.Location = new System.Drawing.Point(248, 165);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(107, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "ОТМЕНА";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPublish
            // 
            this.btnPublish.AutoSize = true;
            this.btnPublish.Location = new System.Drawing.Point(98, 165);
            this.btnPublish.Name = "btnPublish";
            this.btnPublish.Size = new System.Drawing.Size(107, 23);
            this.btnPublish.TabIndex = 1;
            this.btnPublish.Text = "ОПУБЛИКОВАТЬ";
            this.btnPublish.UseVisualStyleBackColor = true;
            this.btnPublish.Click += new System.EventHandler(this.btnPublish_Click);
            // 
            // lblPublish
            // 
            this.lblPublish.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPublish.Location = new System.Drawing.Point(81, 55);
            this.lblPublish.Name = "lblPublish";
            this.lblPublish.Size = new System.Drawing.Size(294, 46);
            this.lblPublish.TabIndex = 0;
            this.lblPublish.Text = "Выберите папку, в которой опубликовать карту, и нажмите кнопку \"Опубликовать\".";
            this.lblPublish.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listMembers
            // 
            this.listMembers.FormattingEnabled = true;
            this.listMembers.Location = new System.Drawing.Point(12, 443);
            this.listMembers.Name = "listMembers";
            this.listMembers.Size = new System.Drawing.Size(261, 121);
            this.listMembers.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column1.Width = 30;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "File Name";
            this.Column2.Name = "Column2";
            this.Column2.Width = 280;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 30;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Locked by";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Modified";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 70;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Column6";
            this.Column6.Name = "Column6";
            this.Column6.Visible = false;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Column7";
            this.Column7.Name = "Column7";
            this.Column7.Visible = false;
            // 
            // SynergyExplorerDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 578);
            this.Controls.Add(this.listMembers);
            this.Controls.Add(this.panelPublish);
            this.Controls.Add(this.btnUnlock);
            this.Controls.Add(this.btnLock);
            this.Controls.Add(this.btnCopyFolder);
            this.Controls.Add(this.btnNewFolder);
            this.Controls.Add(this.btnRenameFolder);
            this.Controls.Add(this.btnCopyFile);
            this.Controls.Add(this.btnNewVersion);
            this.Controls.Add(this.btnAddFiles);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.btnDeleteFolder);
            this.Controls.Add(this.btnShareMap);
            this.Controls.Add(this.btnTake);
            this.Controls.Add(this.btnShareFolder);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.btnNewPlace);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pictSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.tabControl1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SynergyExplorerDlg";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Synergy Explorer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dlg_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnUnlock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictSearch)).EndInit();
            this.panelPublish.ResumeLayout(false);
            this.panelPublish.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPropertis;
        private System.Windows.Forms.TabPage tabVersions;
        private System.Windows.Forms.Button btnRenameFolder;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button btnShareMap;
        private System.Windows.Forms.Button btnNewVersion;
        private System.Windows.Forms.Button btnCopyFile;
        private System.Windows.Forms.Button btnDeleteFolder;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.PictureBox pictSearch;
        private System.Windows.Forms.Button btnNewPlace;
        private System.Windows.Forms.Button btnNewFolder;
        private System.Windows.Forms.Button btnShareFolder;
        private System.Windows.Forms.Button btnTake;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Button btnAddFiles;
        private System.Windows.Forms.Button btnCopyFolder;
        private System.Windows.Forms.PictureBox btnLock;
        private System.Windows.Forms.PictureBox btnUnlock;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblPublish;
        public System.Windows.Forms.Panel panelPublish;
        private System.Windows.Forms.TabPage tabMembers;
        private System.Windows.Forms.ListBox listMembers;
        public System.Windows.Forms.TreeView treeView1;
        public System.Windows.Forms.Button btnPublish;
        private System.Windows.Forms.DataGridViewImageColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewImageColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}