namespace QL_MatBangTTTM
{
    partial class FrmDichVu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDichVu));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnThem = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.btnSua = new DevExpress.XtraBars.BarButtonItem();
            this.btnLuu = new DevExpress.XtraBars.BarButtonItem();
            this.btnHuy = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaDV = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenDichVu = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDonViTinh = new DevExpress.XtraEditors.TextEdit();
            this.txtMaDichVu = new DevExpress.XtraEditors.TextEdit();
            this.gLUEGia = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gCDSDichVu = new DevExpress.XtraGrid.GridControl();
            this.dgvDSDichVu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaDichVu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenDichVu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDonViTinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaGiaDV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.colGiaDV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenGia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaGiaDichVu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayTao = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDichVu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonViTinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaDichVu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gLUEGia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCDSDichVu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSDichVu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar3});
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
            this.barManager1.StatusBar = this.bar3;
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
            this.btnThem.Caption = "Thêm dịch vụ";
            this.btnThem.Id = 0;
            this.btnThem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.ImageOptions.Image")));
            this.btnThem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnThem.ImageOptions.LargeImage")));
            this.btnThem.Name = "btnThem";
            this.btnThem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnThem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThem_ItemClick);
            // 
            // btnXoa
            // 
            this.btnXoa.Caption = "Xóa dịch vụ";
            this.btnXoa.Id = 1;
            this.btnXoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.ImageOptions.Image")));
            this.btnXoa.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnXoa.ImageOptions.LargeImage")));
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXoa_ItemClick);
            // 
            // btnSua
            // 
            this.btnSua.Caption = "Sửa dịch vụ";
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
            // bar3
            // 
            this.bar3.BarName = "StatusBar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "StatusBar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1048, 30);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 591);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1048, 24);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 30);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 561);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1048, 30);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 561);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1048, 561);
            this.tableLayoutPanel1.TabIndex = 7;
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1042, 163);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(335, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(361, 155);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin dịch vụ";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel3.Controls.Add(this.lblMaDV, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtTenDichVu, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.txtDonViTinh, 2, 3);
            this.tableLayoutPanel3.Controls.Add(this.txtMaDichVu, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.gLUEGia, 2, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 20);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(355, 131);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // lblMaDV
            // 
            this.lblMaDV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMaDV.AutoSize = true;
            this.lblMaDV.Location = new System.Drawing.Point(3, 7);
            this.lblMaDV.Name = "lblMaDV";
            this.lblMaDV.Size = new System.Drawing.Size(100, 17);
            this.lblMaDV.TabIndex = 1;
            this.lblMaDV.Text = "Mã dịch vụ";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên dịch vụ";
            // 
            // txtTenDichVu
            // 
            this.txtTenDichVu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenDichVu.Location = new System.Drawing.Point(126, 37);
            this.txtTenDichVu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTenDichVu.MenuManager = this.barManager1;
            this.txtTenDichVu.Name = "txtTenDichVu";
            this.txtTenDichVu.Size = new System.Drawing.Size(226, 22);
            this.txtTenDichVu.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Giá";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Đơn vị tính";
            // 
            // txtDonViTinh
            // 
            this.txtDonViTinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDonViTinh.Location = new System.Drawing.Point(126, 102);
            this.txtDonViTinh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDonViTinh.MenuManager = this.barManager1;
            this.txtDonViTinh.Name = "txtDonViTinh";
            this.txtDonViTinh.Size = new System.Drawing.Size(226, 22);
            this.txtDonViTinh.TabIndex = 14;
            // 
            // txtMaDichVu
            // 
            this.txtMaDichVu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaDichVu.Location = new System.Drawing.Point(126, 5);
            this.txtMaDichVu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaDichVu.MenuManager = this.barManager1;
            this.txtMaDichVu.Name = "txtMaDichVu";
            this.txtMaDichVu.Size = new System.Drawing.Size(226, 22);
            this.txtMaDichVu.TabIndex = 15;
            // 
            // gLUEGia
            // 
            this.gLUEGia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.gLUEGia.Location = new System.Drawing.Point(126, 69);
            this.gLUEGia.MenuManager = this.barManager1;
            this.gLUEGia.Name = "gLUEGia";
            this.gLUEGia.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gLUEGia.Properties.DisplayMember = "Gia";
            this.gLUEGia.Properties.PopupView = this.gridLookUpEdit1View;
            this.gLUEGia.Properties.ValueMember = "MaGiaDichVu";
            this.gLUEGia.Size = new System.Drawing.Size(226, 22);
            this.gLUEGia.TabIndex = 16;
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaGiaDichVu,
            this.colTenGia,
            this.colGiaDV,
            this.colNgayTao});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gCDSDichVu);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 175);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(1042, 382);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách dịch vụ";
            // 
            // gCDSDichVu
            // 
            this.gCDSDichVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gCDSDichVu.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gCDSDichVu.Location = new System.Drawing.Point(3, 20);
            this.gCDSDichVu.MainView = this.dgvDSDichVu;
            this.gCDSDichVu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gCDSDichVu.MenuManager = this.barManager1;
            this.gCDSDichVu.Name = "gCDSDichVu";
            this.gCDSDichVu.Size = new System.Drawing.Size(1036, 358);
            this.gCDSDichVu.TabIndex = 0;
            this.gCDSDichVu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvDSDichVu});
            // 
            // dgvDSDichVu
            // 
            this.dgvDSDichVu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaDichVu,
            this.colTenDichVu,
            this.colGia,
            this.colDonViTinh,
            this.colMaGiaDV});
            this.dgvDSDichVu.DetailHeight = 431;
            this.dgvDSDichVu.GridControl = this.gCDSDichVu;
            this.dgvDSDichVu.Name = "dgvDSDichVu";
            this.dgvDSDichVu.OptionsBehavior.Editable = false;
            this.dgvDSDichVu.OptionsFind.AlwaysVisible = true;
            this.dgvDSDichVu.OptionsFind.FindNullPrompt = "Nhập dữ liệu cần tìm";
            this.dgvDSDichVu.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.dgvDSDichVu.OptionsView.ShowGroupPanel = false;
            this.dgvDSDichVu.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.dgvDSDichVu_FocusedRowChanged);
            // 
            // colMaDichVu
            // 
            this.colMaDichVu.Caption = "Mã dịch vụ";
            this.colMaDichVu.FieldName = "MaDichVu";
            this.colMaDichVu.MinWidth = 23;
            this.colMaDichVu.Name = "colMaDichVu";
            this.colMaDichVu.Visible = true;
            this.colMaDichVu.VisibleIndex = 0;
            this.colMaDichVu.Width = 87;
            // 
            // colTenDichVu
            // 
            this.colTenDichVu.Caption = "Tên dịch vụ";
            this.colTenDichVu.FieldName = "TenDichVu";
            this.colTenDichVu.MinWidth = 23;
            this.colTenDichVu.Name = "colTenDichVu";
            this.colTenDichVu.Visible = true;
            this.colTenDichVu.VisibleIndex = 1;
            this.colTenDichVu.Width = 87;
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
            // colDonViTinh
            // 
            this.colDonViTinh.Caption = "Đơn vị tính";
            this.colDonViTinh.FieldName = "DonViTinh";
            this.colDonViTinh.MinWidth = 23;
            this.colDonViTinh.Name = "colDonViTinh";
            this.colDonViTinh.Visible = true;
            this.colDonViTinh.VisibleIndex = 3;
            this.colDonViTinh.Width = 87;
            // 
            // colMaGiaDV
            // 
            this.colMaGiaDV.Caption = "Mã giá dịch vụ";
            this.colMaGiaDV.FieldName = "MaGiaDV";
            this.colMaGiaDV.MinWidth = 25;
            this.colMaGiaDV.Name = "colMaGiaDV";
            this.colMaGiaDV.Width = 94;
            // 
            // colGiaDV
            // 
            this.colGiaDV.Caption = "Giá dịch vụ";
            this.colGiaDV.FieldName = "Gia";
            this.colGiaDV.Name = "colGiaDV";
            this.colGiaDV.Visible = true;
            this.colGiaDV.VisibleIndex = 1;
            // 
            // colTenGia
            // 
            this.colTenGia.Caption = "Tên dịch vụ";
            this.colTenGia.FieldName = "TenDichVu";
            this.colTenGia.Name = "colTenGia";
            this.colTenGia.Visible = true;
            this.colTenGia.VisibleIndex = 2;
            // 
            // colMaGiaDichVu
            // 
            this.colMaGiaDichVu.Caption = "Mã giá";
            this.colMaGiaDichVu.FieldName = "MaGiaDichVu";
            this.colMaGiaDichVu.Name = "colMaGiaDichVu";
            this.colMaGiaDichVu.Visible = true;
            this.colMaGiaDichVu.VisibleIndex = 0;
            // 
            // colNgayTao
            // 
            this.colNgayTao.Caption = "Ngày tạo";
            this.colNgayTao.FieldName = "NgayTao";
            this.colNgayTao.Name = "colNgayTao";
            this.colNgayTao.Visible = true;
            this.colNgayTao.VisibleIndex = 3;
            // 
            // FrmDichVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 615);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmDichVu";
            this.Text = "FrmDichVu";
            this.Load += new System.EventHandler(this.FrmDichVu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDichVu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonViTinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaDichVu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gLUEGia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gCDSDichVu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSDichVu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem btnHuy;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lblMaDV;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txtTenDichVu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit txtDonViTinh;
        private DevExpress.XtraEditors.TextEdit txtMaDichVu;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraGrid.GridControl gCDSDichVu;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvDSDichVu;
        private DevExpress.XtraGrid.Columns.GridColumn colMaDichVu;
        private DevExpress.XtraGrid.Columns.GridColumn colTenDichVu;
        private DevExpress.XtraGrid.Columns.GridColumn colGia;
        private DevExpress.XtraGrid.Columns.GridColumn colDonViTinh;
        private DevExpress.XtraEditors.GridLookUpEdit gLUEGia;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colMaGiaDV;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraGrid.Columns.GridColumn colTenGia;
        private DevExpress.XtraGrid.Columns.GridColumn colGiaDV;
        private DevExpress.XtraGrid.Columns.GridColumn colMaGiaDichVu;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayTao;
    }
}