namespace QL_MatBangTTTM
{
    partial class FrmGiaThue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGiaThue));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnThem = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.btnSua = new DevExpress.XtraBars.BarButtonItem();
            this.btnLuu = new DevExpress.XtraBars.BarButtonItem();
            this.btnHuy = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaGiaThue = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenGiaThue = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGia = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNgayCapNhat = new DevExpress.XtraEditors.TextEdit();
            this.txtMaGiaThue = new DevExpress.XtraEditors.TextEdit();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gCDSGiaThue = new DevExpress.XtraGrid.GridControl();
            this.dgvDSGiaThue = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaGiaThue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenGiaThue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayCapNhat = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenGiaThue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayCapNhat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaGiaThue.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCDSGiaThue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSGiaThue)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnThem,
            this.btnXoa,
            this.btnSua,
            this.btnLuu,
            this.btnHuy});
            this.barManager1.MainMenu = this.bar1;
            this.barManager1.MaxItemId = 5;
            // 
            // bar1
            // 
            this.bar1.BarName = "MainMenu";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnThem),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnXoa),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSua),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnLuu),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnHuy)});
            this.bar1.OptionsBar.MultiLine = true;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "MainMenu";
            // 
            // btnThem
            // 
            this.btnThem.Caption = "Thêm giá thuê";
            this.btnThem.Id = 0;
            this.btnThem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.ImageOptions.Image")));
            this.btnThem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnThem.ImageOptions.LargeImage")));
            this.btnThem.Name = "btnThem";
            this.btnThem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnThem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThem_ItemClick);
            // 
            // btnXoa
            // 
            this.btnXoa.Caption = "Xóa giá thuê";
            this.btnXoa.Id = 1;
            this.btnXoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.ImageOptions.Image")));
            this.btnXoa.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnXoa.ImageOptions.LargeImage")));
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXoa_ItemClick);
            // 
            // btnSua
            // 
            this.btnSua.Caption = "Sửa giá thuê";
            this.btnSua.Id = 2;
            this.btnSua.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.ImageOptions.Image")));
            this.btnSua.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnSua.ImageOptions.LargeImage")));
            this.btnSua.Name = "btnSua";
            this.btnSua.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnSua.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSua_ItemClick);
            // 
            // btnLuu
            // 
            this.btnLuu.Caption = "Lưu";
            this.btnLuu.Id = 3;
            this.btnLuu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.ImageOptions.Image")));
            this.btnLuu.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnLuu.ImageOptions.LargeImage")));
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnLuu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLuu_ItemClick);
            // 
            // btnHuy
            // 
            this.btnHuy.Caption = "Hủy";
            this.btnHuy.Id = 4;
            this.btnHuy.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnHuy.ImageOptions.Image")));
            this.btnHuy.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnHuy.ImageOptions.LargeImage")));
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnHuy.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnHuy_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(897, 30);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 657);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(897, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 30);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 627);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(897, 30);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 627);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 30);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.56537F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 69.43463F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(897, 627);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.8743F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.2413F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.77217F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 4);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(891, 183);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(287, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(308, 175);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin giá thuê";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel3.Controls.Add(this.lblMaGiaThue, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtTenGiaThue, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtGia, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.txtNgayCapNhat, 2, 3);
            this.tableLayoutPanel3.Controls.Add(this.txtMaGiaThue, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 20);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(302, 151);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // lblMaGiaThue
            // 
            this.lblMaGiaThue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMaGiaThue.AutoSize = true;
            this.lblMaGiaThue.Location = new System.Drawing.Point(3, 10);
            this.lblMaGiaThue.Name = "lblMaGiaThue";
            this.lblMaGiaThue.Size = new System.Drawing.Size(84, 17);
            this.lblMaGiaThue.TabIndex = 1;
            this.lblMaGiaThue.Text = "Mã giá thuê";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên giá thuê";
            // 
            // txtTenGiaThue
            // 
            this.txtTenGiaThue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenGiaThue.Location = new System.Drawing.Point(108, 44);
            this.txtTenGiaThue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTenGiaThue.MenuManager = this.barManager1;
            this.txtTenGiaThue.Name = "txtTenGiaThue";
            this.txtTenGiaThue.Size = new System.Drawing.Size(191, 22);
            this.txtTenGiaThue.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Giá";
            // 
            // txtGia
            // 
            this.txtGia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGia.Location = new System.Drawing.Point(108, 81);
            this.txtGia.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtGia.MenuManager = this.barManager1;
            this.txtGia.Name = "txtGia";
            this.txtGia.Size = new System.Drawing.Size(191, 22);
            this.txtGia.TabIndex = 10;
            this.txtGia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGia_KeyPress);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 34);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ngày cập nhật";
            // 
            // txtNgayCapNhat
            // 
            this.txtNgayCapNhat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNgayCapNhat.Location = new System.Drawing.Point(108, 120);
            this.txtNgayCapNhat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNgayCapNhat.MenuManager = this.barManager1;
            this.txtNgayCapNhat.Name = "txtNgayCapNhat";
            this.txtNgayCapNhat.Size = new System.Drawing.Size(191, 22);
            this.txtNgayCapNhat.TabIndex = 14;
            // 
            // txtMaGiaThue
            // 
            this.txtMaGiaThue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaGiaThue.Location = new System.Drawing.Point(108, 7);
            this.txtMaGiaThue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaGiaThue.MenuManager = this.barManager1;
            this.txtMaGiaThue.Name = "txtMaGiaThue";
            this.txtMaGiaThue.Size = new System.Drawing.Size(191, 22);
            this.txtMaGiaThue.TabIndex = 15;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gCDSGiaThue);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 195);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(891, 428);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách giá thuê";
            // 
            // gCDSGiaThue
            // 
            this.gCDSGiaThue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gCDSGiaThue.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gCDSGiaThue.Location = new System.Drawing.Point(3, 20);
            this.gCDSGiaThue.MainView = this.dgvDSGiaThue;
            this.gCDSGiaThue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gCDSGiaThue.MenuManager = this.barManager1;
            this.gCDSGiaThue.Name = "gCDSGiaThue";
            this.gCDSGiaThue.Size = new System.Drawing.Size(885, 404);
            this.gCDSGiaThue.TabIndex = 0;
            this.gCDSGiaThue.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvDSGiaThue});
            // 
            // dgvDSGiaThue
            // 
            this.dgvDSGiaThue.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaGiaThue,
            this.colTenGiaThue,
            this.colGia,
            this.colNgayCapNhat});
            this.dgvDSGiaThue.DetailHeight = 431;
            this.dgvDSGiaThue.GridControl = this.gCDSGiaThue;
            this.dgvDSGiaThue.Name = "dgvDSGiaThue";
            this.dgvDSGiaThue.OptionsBehavior.Editable = false;
            this.dgvDSGiaThue.OptionsFind.AlwaysVisible = true;
            this.dgvDSGiaThue.OptionsFind.FindNullPrompt = "Nhập dữ liệu cần tìm";
            this.dgvDSGiaThue.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.dgvDSGiaThue.OptionsView.ShowGroupPanel = false;
            this.dgvDSGiaThue.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.dgvDSGiaThue_FocusedRowChanged);
            // 
            // colMaGiaThue
            // 
            this.colMaGiaThue.Caption = "Mã giá thuê";
            this.colMaGiaThue.FieldName = "MaGiaThue";
            this.colMaGiaThue.MinWidth = 23;
            this.colMaGiaThue.Name = "colMaGiaThue";
            this.colMaGiaThue.Visible = true;
            this.colMaGiaThue.VisibleIndex = 0;
            this.colMaGiaThue.Width = 87;
            // 
            // colTenGiaThue
            // 
            this.colTenGiaThue.Caption = "Tên giá thuê";
            this.colTenGiaThue.FieldName = "TenGiaThue";
            this.colTenGiaThue.MinWidth = 23;
            this.colTenGiaThue.Name = "colTenGiaThue";
            this.colTenGiaThue.Visible = true;
            this.colTenGiaThue.VisibleIndex = 1;
            this.colTenGiaThue.Width = 87;
            // 
            // colGia
            // 
            this.colGia.Caption = "Giá";
            this.colGia.FieldName = "Gia";
            this.colGia.MinWidth = 23;
            this.colGia.Name = "colGia";
            this.colGia.Visible = true;
            this.colGia.VisibleIndex = 2;
            this.colGia.Width = 87;
            // 
            // colNgayCapNhat
            // 
            this.colNgayCapNhat.Caption = "Ngày Cập Nhật";
            this.colNgayCapNhat.FieldName = "NgayCapNhat";
            this.colNgayCapNhat.MinWidth = 23;
            this.colNgayCapNhat.Name = "colNgayCapNhat";
            this.colNgayCapNhat.Visible = true;
            this.colNgayCapNhat.VisibleIndex = 3;
            this.colNgayCapNhat.Width = 87;
            // 
            // FrmGiaThue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 657);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmGiaThue";
            this.Text = "FrmGiaThue";
            this.Load += new System.EventHandler(this.FrmGiaThue_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenGiaThue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayCapNhat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaGiaThue.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gCDSGiaThue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSGiaThue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnThem;
        private DevExpress.XtraBars.BarButtonItem btnXoa;
        private DevExpress.XtraBars.BarButtonItem btnSua;
        private DevExpress.XtraBars.BarButtonItem btnLuu;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lblMaGiaThue;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txtTenGiaThue;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit txtGia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraGrid.GridControl gCDSGiaThue;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvDSGiaThue;
        private DevExpress.XtraGrid.Columns.GridColumn colMaGiaThue;
        private DevExpress.XtraGrid.Columns.GridColumn colTenGiaThue;
        private DevExpress.XtraGrid.Columns.GridColumn colGia;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayCapNhat;
        private DevExpress.XtraEditors.TextEdit txtNgayCapNhat;
        private DevExpress.XtraEditors.TextEdit txtMaGiaThue;
        private DevExpress.XtraBars.BarButtonItem btnHuy;
    }
}