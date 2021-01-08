using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using BLL;

namespace QL_MatBangTTTM
{
    public partial class FrmXuLyViPham : DevExpress.XtraEditors.XtraForm
    {
        BLL_XuLyViPham vp = new BLL_XuLyViPham();
        BLL_ThueMatBang thueMB = new BLL_ThueMatBang();
        string maNV;
        bool check = false;
        public FrmXuLyViPham(string maNV)
        {
            InitializeComponent();
            txtNhanVien.Text = maNV;
            this.maNV = maNV;
        }
        
        #region LoadDuLieu
        private void LoadDSHoSoViPham()
        {
            gcDSViPham.DataSource = vp.LayDSHoSoViPham();
        }
        private void LoadDSViPham()
        {
            txtViPham.Properties.DataSource = vp.LayDSViPham();
        }
        public void LoadCboMaThue()
        {
            txtMaThue.Properties.DataSource = vp.LayDSThueMatBang();
        }
        #endregion

        #region Clean DL
        public void choNhapTextBox(bool tinhTrang)
        {
            txtMaThue.ReadOnly = tinhTrang;
            txtViPham.ReadOnly = tinhTrang;
            txtGhiChu.ReadOnly = tinhTrang;
            txtTienPhat.ReadOnly = tinhTrang;
        }

        public void XoaDuLieuTextBox()
        {
            txtMaThue.EditValue = null;
            txtViPham.EditValue = null;
            txtTienPhat.EditValue = null;
            txtGhiChu.EditValue = null;
            txtNgayLap.EditValue = null;
            txtNgayDong.EditValue = null;
            txtMatBang.EditValue = null;
            txtViTri.EditValue = null;
            txtKhachHang.EditValue = null;
            txtNhanVien.EditValue = null;
            cboTinhTrang.EditValue = null;
        }
        #endregion



        #region Click_BTN
        private void Click_BtnThem()
        {
            XoaDuLieuTextBox();
            btnThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnHuy.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnLuuVP.Visible = true;
            btnNhapLai.Visible = true;
            btnHuyVP.Visible = true;
            check = true;
            choNhapTextBox(false);         
            txtMaHS.Text = vp.LayMaXuLyTuSinh();
            txtNhanVien.Text = maNV;
            txtNgayLap.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtMaThue.Focus();
        }
        private void Click_BtnSua()
        {
            btnThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnHuy.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnLuuVP.Visible = true;
            btnNhapLai.Visible = true;
            btnHuyVP.Visible = true;
            check = true;
        }
        private void Click_BtnLuu()
        {
            btnThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnHuy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnLuuVP.Visible = false;
            btnNhapLai.Visible = false;
            btnHuyVP.Visible = false;
            check = false;
           
            choNhapTextBox(true);
            //choNhapTextBox(true);
        }
        private void Click_BtnHuy()
        {
            btnThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnHuy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnLuuVP.Visible = false;
            btnNhapLai.Visible = false;
            btnHuyVP.Visible = false;
            choNhapTextBox(true);
            //choNhapTextBox(true);   
            check = false;
        }
        #endregion
        private void btnThem_ItemClick(object sender, ItemClickEventArgs e)
        {
            Click_BtnThem();
        }

        private void btnXoa_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnSua_ItemClick(object sender, ItemClickEventArgs e)
        {
            Click_BtnSua();
        }

        private void btnLuu_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnHuy_ItemClick(object sender, ItemClickEventArgs e)
        {
            Click_BtnHuy();
        }

        private void FrmXuLyViPham_Load(object sender, EventArgs e)
        {
            LoadDSViPham();
            LoadCboMaThue();
            LoadDSHoSoViPham();
            
        }

        private void txtMaThue_EditValueChanged(object sender, EventArgs e)
        {
            var tt = vp.LayThongTinThueMB(txtMaThue.Text);
            if(tt!=null)
            {
                txtMatBang.Text = tt.DangKyThue.MatBang;
                txtViTri.Text = tt.DangKyThue.MatBang1.ViTri.ToString();
                txtKhachHang.Text = tt.DangKyThue.MaKhachHang;
            }   
            else
            {
                txtMatBang.Text = "";
                txtViTri.Text = "";
                txtKhachHang.Text = "";
            }    
          
        }

        private void dgvDSViPham_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (check)
                return;
            var tt = vp.LayThongTinHoSoVP((string)dgvDSViPham.GetFocusedRowCellValue(colMaHSViPham));
            if(tt!=null)
            {
                txtMaHS.Text = tt.MaHSViPham;
                txtMaThue.Text = tt.MaThueMB;
                txtNgayDong.Text = string.Format("{0:dd/MM/yyyy}", tt.NgayDongTien);
                txtNgayLap.Text = string.Format("{0:dd/MM/yyyy}", tt.NgayLap);
                txtTienPhat.Text = string.Format("{0:0,0 vnđ}", tt.TongTienPhat);
                txtViPham.EditValue = tt.MaViPham;
                cboTinhTrang.Text= dgvDSViPham.GetFocusedRowCellValue(colTinhTrang).ToString();
                txtGhiChu.Text = tt.GhiChu;
            }    
           
        }
    }
}