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
using QL_MatBangTTTM.Resource;
using Liz.DoAn;
using Model;
using DAL;

namespace QL_MatBangTTTM
{
    public partial class FrmLichHen : DevExpress.XtraEditors.XtraForm
    {
        BLL_ThueMatBang thueMB = new BLL_ThueMatBang();
        string maHD;
        bool check = false;
        public FrmLichHen(string maNV)
        {
            InitializeComponent();
        }
        public void LoadLichHen()
        {
           LoadDSDKThue();
           gcDSLichHen.DataSource= thueMB.LayDSLichHen();
        }
        public void LoadDSDKThueChuaCoLichHen()
        {
            txtMaDK.Properties.DataSource = thueMB.LayDSDangKyChuaCoLichHen();
        }
        public void LoadDSDKThue()
        {
            txtMaDK.Properties.DataSource = thueMB.LayDSDangKy();
        }
        private void FrmLichHen_Load(object sender, EventArgs e)
        {
            LoadLichHen();           
        }
        #region BTN
        private void Click_BtnThem()
        {
            btnThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnHuy.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnLuuNV.Visible = true;
            btnNhapLai.Visible = true;
            btnHuyThem.Visible = true;
            check = true;
            choNhapTextBox(false);
        }
        private void Click_BtnSua()
        {
            btnThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnHuy.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnLuuNV.Visible = true;
            btnNhapLai.Visible = true;           
            btnHuyThem.Visible = true;
            choNhapTextBox(false);
            check = false;
        }
        private void Click_BtnLuu()
        {
            btnThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnHuy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnLuuNV.Visible = false;
            btnNhapLai.Visible = false;
            btnHuyThem.Visible = false;
            choNhapTextBox(true);
            LoadDSDKThue();
            check = false;
        }
        private void Click_BtnHuy()
        {
            btnThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnHuy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnLuuNV.Visible = false;
            btnNhapLai.Visible = false;
            btnHuyThem.Visible = false;
            choNhapTextBox(true);
            LoadDSDKThue();
            check = false;
            dgvDSLichHen_FocusedRowChanged(null, null);
            dgvDSLichHen.Focus();
        }
        #endregion
        public void TaoMoi()
        {
            LoadDSDKThueChuaCoLichHen();
            DateTime NgayHen;
            DateTime ngayHienTai = DateTime.Now;
            NgayHen = ngayHienTai.AddDays(1);
            txtNgayHen.EditValue = NgayHen;
            txtMaLichHen.Text = thueMB.LayMaLichHenTuSinh();
            txtNoiDung.Text = QL_MatBang.NOIDUNG;
            txtDiaChi.Text= QL_MatBang.DIACHI;
            txtKhachHang.Text = "";
            txtMaDK.Text = "";
            txtTenKhachHang.Text = "";
            txtSDT.Text = "";
            txtMaDK.Focus();
            txtGioBatDau.EditValue = new TimeSpan(0, 7, 0, 0);
            txtGioKetThuc.EditValue = new TimeSpan(0, 8, 0, 0);
        }

        public void choNhapTextBox(bool trangThai)
        {
            txtMaDK.ReadOnly = trangThai;
            txtNgayHen.ReadOnly = trangThai;
            txtGioBatDau.ReadOnly = trangThai;
        }
        private void LayThongTinDKThue(string ma)
        {
            BLL_KhachHang khachHang = new BLL_KhachHang();
            var tt = thueMB.LayThongTinDKThue(ma);
            if (tt != null)
            {
                maHD = tt.MaHD;
            }
            if (tt != null)
            {
                var mb = thueMB.LayThongTinMB(tt.MatBang);
                var kh = khachHang.LayTTKhachHang(tt.MaKhachHang);
                var hoaDon = thueMB.HoaDon(tt.MaHD);
                DateTime ngayHetHan;
                DateTime ngayThue = (DateTime)tt.NgayMoCua;
                ngayHetHan = ngayThue.AddYears(1);
                txtKhachHang.EditValue = kh.MaKH;
                txtSDT.EditValue = kh.SDT;
                txtTenKhachHang.EditValue = kh.HoTenKH;
            }
        }
        private void btnThem_ItemClick(object sender, ItemClickEventArgs e)
        {
            TaoMoi();
            Click_BtnThem();
        }

        private void txtMaDK_EditValueChanged(object sender, EventArgs e)
        {
            LayThongTinDKThue(txtMaDK.Text);
        }
        private DateTime LayNgayToiThieu(string maHD)
        {
            var hd = thueMB.HoaDonGiuCho(maHD);
            return (DateTime)hd.NgayHetHan;
        }
        private void txtNgayHen_EditValueChanged(object sender, EventArgs e)
        {           
                
         
        }

        private void txtGioBatDau_EditValueChanged(object sender, EventArgs e)
        {
            if (check==false)
                return;
            TimeSpan gioBD = (TimeSpan)txtGioBatDau.EditValue;
            TimeSpan gioKT;
            gioKT = gioBD.Add(new TimeSpan(0, 1, 0, 0));
            txtGioKetThuc.EditValue = gioKT;
            if (txtGioBatDau.TimeSpan < new TimeSpan(0, 7, 0, 0))
            {
                MessageBox.Show("Lịch hẹn không thể đặt trước 7:00");
                txtGioBatDau.EditValue = new TimeSpan(0, 7, 0, 0);
                txtGioBatDau.Focus();
                return;
            }

            if (txtGioBatDau.TimeSpan > new TimeSpan(0, 16, 0, 0))
            {
                MessageBox.Show("Lịch hẹn không thể đặt sau 16:00");
                txtGioBatDau.EditValue = new TimeSpan(0, 16, 0, 0);
                txtGioBatDau.Focus();
                return;
            }
        }

        private void btnLuu_ItemClick(object sender, ItemClickEventArgs e)
        {
            int  rowselect = dgvDSLichHen.FocusedRowHandle;
            string ngayHen = ((DateTime)txtNgayHen.EditValue).ToString("dd/MM/yyyy");
            string ngayHienTai= DateTime.Now.ToString("dd/MM/yyyy");
            TimeSpan ngay = Commons.ConvertStringToDate(ngayHienTai).Subtract(Commons.ConvertStringToDate(ngayHen));


            if (string.IsNullOrEmpty(txtMaDK.EditValue.ToString()))
            {              
                    MessageBox.Show("Bạn chưa chọn mã đăng ký", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorProvider1.SetError(txtMaDK, "Bạn chưa chọn mã đăng ký");
                    txtMaDK.Focus();
                    return;
            }

            if (ngay.Days>=0)
            {
                MessageBox.Show("Ngày hẹn phải lớn hơn ngày hiện tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(txtNgayHen, "Ngày hẹn phải lớn hơn ngày hiện tại");
                txtNgayHen.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(txtNgayHen.Text) && check == false)
            {
                if (maHD != null)
                {
                    string ngayHetHanString = LayNgayToiThieu(maHD).ToString("dd/MM/yyyy");
                    DateTime ngayHenDate = Commons.ConvertStringToDate(ngayHen);
                    DateTime ngayHetHan = Commons.ConvertStringToDate(ngayHetHanString);
                    TimeSpan ktNgayMax = ngayHetHan - ngayHenDate;
                    if (ktNgayMax.Days < 0)
                    {
                        MessageBox.Show("Ngày hẹn phải nhỏ hơn ngày hết hạn cọc ngày: " + ngayHetHan.ToString("dd/MM/yyyy"));
                        txtNgayHen.EditValue = ngayHetHan;
                        txtNgayHen.Focus();
                        return;
                    }
                }
            }
            LichHen lh = new LichHen();
            lh.MaLichHen = txtMaLichHen.Text;
            lh.NgayHen = Commons.ConvertStringToDate(ngayHen);
            lh.GioBatDau = (TimeSpan)txtGioBatDau.EditValue;
            lh.GioKetThuc = (TimeSpan)txtGioKetThuc.EditValue;
            lh.DiaChi = txtDiaChi.Text;
            lh.NoiDung = txtNoiDung.Text;
            if(!string.IsNullOrEmpty(txtNhanVien.Text))
                lh.MaNhanVien = txtNhanVien.Text;
            lh.MaDK = txtMaDK.EditValue.ToString();
            lh.TinhTrang = 1;

            if (!thueMB.KiemTraLichHen(lh))
            {
                MessageBox.Show("Giờ này đã có lịch hẹn");
                txtGioBatDau.Focus();
                return;
            }
            if (check)
            {
                if (thueMB.ThemLichHen(lh))
                {
                    MessageBox.Show("Thêm lịch hẹn thành công");
                    LoadLichHen();
                    Click_BtnLuu();
                    dgvDSLichHen.FocusedRowHandle = dgvDSLichHen.RowCount;
                    return;
                }
            }
            else
            {
                if(thueMB.SuaLichHen(lh))
                {
                    MessageBox.Show("Sửa lịch hẹn thành công");
                    LoadLichHen();
                    Click_BtnLuu();
                    dgvDSLichHen.FocusedRowHandle = rowselect;
                    return;
                }    
            }    
        }

        private void dgvDSLichHen_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            if (check)
                return;
            string maDK = dgvDSLichHen.GetFocusedRowCellValue(colMaDKThue).ToString();
            LoadDSDKThue();
            txtNhanVien.EditValue= dgvDSLichHen.GetFocusedRowCellDisplayText(colNhanVien).ToString();
            txtMaDK.EditValue = dgvDSLichHen.GetFocusedRowCellValue(colMaDKThue).ToString();
            txtNoiDung.EditValue= dgvDSLichHen.GetFocusedRowCellValue(colNoiDung).ToString();
            txtDiaChi.EditValue = dgvDSLichHen.GetFocusedRowCellValue(colDiaChi).ToString();
            txtGioBatDau.EditValue =dgvDSLichHen.GetFocusedRowCellDisplayText(colTGBD).ToString().Substring(0,5);
            txtGioKetThuc.EditValue = dgvDSLichHen.GetFocusedRowCellDisplayText(colThoiGianKT).ToString().Substring(0, 5);
            txtNgayHen.EditValue = dgvDSLichHen.GetFocusedRowCellValue(colNgayHen).ToString().Substring(0,10);
            txtMaLichHen.EditValue = dgvDSLichHen.GetFocusedRowCellValue(colMaLH).ToString();
            LayThongTinDKThue(maDK);
        }

        private void btnXoa_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnSua_ItemClick(object sender, ItemClickEventArgs e)
        {
            string ngayHen = txtNgayHen.EditValue.ToString();
            string ngayHienTai = DateTime.Now.ToString("dd/MM/yyyy");
            TimeSpan ngay = Commons.ConvertStringToDate(ngayHienTai).Subtract(Commons.ConvertStringToDate(ngayHen));
            if(ngay.Days>=0)
            {
                MessageBox.Show("Lịch hẹn đã quá hẹn bạn không thể chỉnh sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;            
            }    
            Click_BtnSua();
            txtMaDK.ReadOnly = true;
            txtNgayHen.EditValue =Commons.ConvertStringToDate(ngayHen);
            txtNgayHen.Focus();
        }

        private void btnHuy_ItemClick(object sender, ItemClickEventArgs e)
        {
            Click_BtnHuy();            
        }

        private void btnLuuNV_Click(object sender, EventArgs e)
        {
            btnLuu_ItemClick(null, null);
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            btnThem_ItemClick(null,null);
        }

        private void btnHuyThem_Click(object sender, EventArgs e)
        {
            Click_BtnHuy();
        }
    }
}