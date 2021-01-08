namespace QL_MatBangTTTM
{
    partial class FrmPhanQuyen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPhanQuyen));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnThemNhomNguoiDung = new DevExpress.XtraBars.BarButtonItem();
            this.btnThemNguoiDungVaoNhom = new DevExpress.XtraBars.BarButtonItem();
            this.btnCapNhatQuyen = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gdcNhomND = new DevExpress.XtraGrid.GridControl();
            this.dgvDSNhomND = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaNhom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenNhom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcChucNang = new DevExpress.XtraGrid.GridControl();
            this.dgvDSChucNang = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaMH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCoQuyen = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdcNhomND)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSNhomND)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdcChucNang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSChucNang)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnThemNhomNguoiDung,
            this.btnThemNguoiDungVaoNhom,
            this.btnCapNhatQuyen});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 3;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnThemNhomNguoiDung),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnThemNguoiDungVaoNhom),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCapNhatQuyen)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnThemNhomNguoiDung
            // 
            this.btnThemNhomNguoiDung.Caption = "Thêm nhóm người dùng";
            this.btnThemNhomNguoiDung.Id = 0;
            this.btnThemNhomNguoiDung.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThemNhomNguoiDung.ImageOptions.SvgImage")));
            this.btnThemNhomNguoiDung.Name = "btnThemNhomNguoiDung";
            this.btnThemNhomNguoiDung.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnThemNguoiDungVaoNhom
            // 
            this.btnThemNguoiDungVaoNhom.Caption = "Thêm người dùng vào nhóm";
            this.btnThemNguoiDungVaoNhom.Id = 1;
            this.btnThemNguoiDungVaoNhom.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThemNguoiDungVaoNhom.ImageOptions.SvgImage")));
            this.btnThemNguoiDungVaoNhom.Name = "btnThemNguoiDungVaoNhom";
            this.btnThemNguoiDungVaoNhom.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnCapNhatQuyen
            // 
            this.btnCapNhatQuyen.Caption = "Cập nhật quyền";
            this.btnCapNhatQuyen.Id = 2;
            this.btnCapNhatQuyen.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCapNhatQuyen.ImageOptions.SvgImage")));
            this.btnCapNhatQuyen.Name = "btnCapNhatQuyen";
            this.btnCapNhatQuyen.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnCapNhatQuyen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCapNhatQuyen_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlTop.Size = new System.Drawing.Size(1027, 30);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 582);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlBottom.Size = new System.Drawing.Size(1027, 24);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 30);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 552);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1027, 30);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 552);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.gdcNhomND, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gdcChucNang, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 30);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1027, 552);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // gdcNhomND
            // 
            this.gdcNhomND.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdcNhomND.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gdcNhomND.Location = new System.Drawing.Point(3, 2);
            this.gdcNhomND.MainView = this.dgvDSNhomND;
            this.gdcNhomND.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gdcNhomND.MenuManager = this.barManager1;
            this.gdcNhomND.Name = "gdcNhomND";
            this.gdcNhomND.Size = new System.Drawing.Size(507, 548);
            this.gdcNhomND.TabIndex = 0;
            this.gdcNhomND.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvDSNhomND});
            // 
            // dgvDSNhomND
            // 
            this.dgvDSNhomND.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaNhom,
            this.colTenNhom});
            this.dgvDSNhomND.GridControl = this.gdcNhomND;
            this.dgvDSNhomND.Name = "dgvDSNhomND";
            this.dgvDSNhomND.OptionsView.ShowGroupPanel = false;
            this.dgvDSNhomND.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.dgvDSNhomND_FocusedRowChanged);
            // 
            // colMaNhom
            // 
            this.colMaNhom.Caption = "Mã Nhóm";
            this.colMaNhom.FieldName = "MaNhom";
            this.colMaNhom.MinWidth = 24;
            this.colMaNhom.Name = "colMaNhom";
            this.colMaNhom.Visible = true;
            this.colMaNhom.VisibleIndex = 0;
            this.colMaNhom.Width = 94;
            // 
            // colTenNhom
            // 
            this.colTenNhom.Caption = "Tên nhóm";
            this.colTenNhom.FieldName = "TenNhom";
            this.colTenNhom.MinWidth = 24;
            this.colTenNhom.Name = "colTenNhom";
            this.colTenNhom.Visible = true;
            this.colTenNhom.VisibleIndex = 1;
            this.colTenNhom.Width = 94;
            // 
            // gdcChucNang
            // 
            this.gdcChucNang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdcChucNang.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gdcChucNang.Location = new System.Drawing.Point(516, 2);
            this.gdcChucNang.MainView = this.dgvDSChucNang;
            this.gdcChucNang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gdcChucNang.MenuManager = this.barManager1;
            this.gdcChucNang.Name = "gdcChucNang";
            this.gdcChucNang.Size = new System.Drawing.Size(508, 548);
            this.gdcChucNang.TabIndex = 1;
            this.gdcChucNang.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvDSChucNang});
            // 
            // dgvDSChucNang
            // 
            this.dgvDSChucNang.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaMH,
            this.gridColumn2,
            this.colCoQuyen});
            this.dgvDSChucNang.GridControl = this.gdcChucNang;
            this.dgvDSChucNang.Name = "dgvDSChucNang";
            this.dgvDSChucNang.OptionsView.ShowGroupPanel = false;
            // 
            // colMaMH
            // 
            this.colMaMH.Caption = "Mã màn hình";
            this.colMaMH.FieldName = "MaMH";
            this.colMaMH.MinWidth = 24;
            this.colMaMH.Name = "colMaMH";
            this.colMaMH.Visible = true;
            this.colMaMH.VisibleIndex = 0;
            this.colMaMH.Width = 94;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tên màn hình";
            this.gridColumn2.FieldName = "TenMH";
            this.gridColumn2.MinWidth = 24;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 94;
            // 
            // colCoQuyen
            // 
            this.colCoQuyen.Caption = "Có quyền";
            this.colCoQuyen.FieldName = "Quyen";
            this.colCoQuyen.MinWidth = 24;
            this.colCoQuyen.Name = "colCoQuyen";
            this.colCoQuyen.Visible = true;
            this.colCoQuyen.VisibleIndex = 2;
            this.colCoQuyen.Width = 94;
            // 
            // FrmPhanQuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 606);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmPhanQuyen";
            this.Text = "Phân quyền";
            this.Load += new System.EventHandler(this.FrmPhanQuyen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdcNhomND)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSNhomND)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdcChucNang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSChucNang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnThemNhomNguoiDung;
        private DevExpress.XtraBars.BarButtonItem btnThemNguoiDungVaoNhom;
        private DevExpress.XtraBars.BarButtonItem btnCapNhatQuyen;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraGrid.GridControl gdcNhomND;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvDSNhomND;
        private DevExpress.XtraGrid.GridControl gdcChucNang;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvDSChucNang;
        private DevExpress.XtraGrid.Columns.GridColumn colMaNhom;
        private DevExpress.XtraGrid.Columns.GridColumn colTenNhom;
        private DevExpress.XtraGrid.Columns.GridColumn colMaMH;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn colCoQuyen;
    }
}