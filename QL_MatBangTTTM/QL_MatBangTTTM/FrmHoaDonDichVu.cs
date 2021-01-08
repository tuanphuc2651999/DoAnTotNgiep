﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Liz.DoAn;
using BLL;
using DAL;
using QL_MatBangTTTM.Resource;

namespace QL_MatBangTTTM
{
    public partial class FrmHoaDonDichVu : DevExpress.XtraEditors.XtraForm
    {
        BLL_ThueMatBang thueMB = new BLL_ThueMatBang();
        bool check = false;
        bool checkhd = false;
        int tongTien;
        string maNV;
        public FrmHoaDonDichVu(string maNV)
        {
            InitializeComponent();
            this.maNV = maNV;
        }
        #region BTN
        private void Click_BtnThem()
        {
            btnThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;         
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnHuy.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnLuuNV.Visible = true;
            btnNhapLai.Visible = true;
            btnHuyThem.Visible = true;
            check = true;
            choNhapTextBox(false);
            checkhd = true;
        }
        private void Click_BtnSua()
        {
            btnThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
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
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnHuy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnLuuNV.Visible = false;
            btnNhapLai.Visible = false;
            btnHuyThem.Visible = false;
            choNhapTextBox(true);
            check = false;
        }
        private void Click_BtnHuy()
        {
            btnThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnHuy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnLuuNV.Visible = false;
            btnNhapLai.Visible = false;
            btnHuyThem.Visible = false;
            choNhapTextBox(true);
            check = false;
            dgvDSHoaDon_FocusedRowChanged(null,null);
        }
        #endregion
        public void TaoMoi()
        {
            txtHoaDon.Text = thueMB.LayMaHoaDVTuSinh();
            txtMaDK.EditValue = null;
            txtNgayLap.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtNgayThanhToan.EditValue = Commons.ConvertStringToDate(DateTime.Now.ToString("dd/MM/yyyy"));
            txtSoNuocCu.EditValue = "0";
            txtSoDienCu.EditValue = "0";
            txtSoDienMoi.EditValue ="0";
            txtSoNuocMoi.EditValue = "0";
           
        }

        public void choNhapTextBox(bool trangThai)
        {
            txtMaDK.ReadOnly = trangThai;
            txtSoDienMoi.ReadOnly = trangThai;
            txtSoNuocMoi.ReadOnly = trangThai;
        }
        public int TongTien(int CSNM, int CSNC, int CSDM, int CSDC)
        {
            return ((CSNM - CSNC) * thueMB.LayGiaNuoc()) + ((CSDM - CSDC) * thueMB.LayGiaDien());
        }
        public void LoadCboMaThue()
        {
            txtMaDK.Properties.DataSource = thueMB.LayDSThueMBChuaCoHoaDon();
        }
        private void LoadDSHoaDon()
        {
            gcHoaDon.DataSource = thueMB.LayDSPhieuDV();
        }
        public void LoadCboAllMaThue()
        {
            txtMaDK.Properties.DataSource = thueMB.LayDSThueMatBang();
        }
        public void LayThongTinPhieuDV(string ma)
        {
            var tt = thueMB.LayThongTinPhieuDV(ma);
            var ctdvd = thueMB.LayThongTinCT_DichVu(ma, "AEON_MDV0001");
            var ctdvm = thueMB.LayThongTinCT_DichVu(ma, "AEON_MDV0002");
            txtGiaDien.Text = string.Format("{0:0,0 vnđ}", ctdvd.Gia);
            txtGiaNuoc.Text = string.Format("{0:0,0 vnđ}", ctdvm.Gia);
            txtSoDienCu.Text = ctdvd.ChiSoCu.ToString();
            txtSoDienMoi.Text =  ctdvd.ChiSoMoi.ToString();
            txtSoNuocCu.Text = ctdvm.ChiSoCu.ToString();
            txtSoNuocMoi.Text =  ctdvm.ChiSoMoi.ToString();
            txtHoaDon.Text = ma;
        }
        public void LayHoaDonGanNhat(string ma)
        {
            txtGiaDien.Text = string.Format("{0:0,0 vnđ}", thueMB.LayGiaDien());
            txtGiaNuoc.Text = string.Format("{0:0,0 vnđ}", thueMB.LayGiaDien());

            string maPDV = thueMB.LayMaHoaDonMoiNhat(ma);
            if(!string.IsNullOrEmpty(maPDV))
            {
                var ctdvd = thueMB.LayThongTinCT_DichVu(maPDV, "AEON_MDV0001");
                var ctdvm = thueMB.LayThongTinCT_DichVu(maPDV, "AEON_MDV0002");
                txtSoDienCu.Text = ctdvd.ChiSoMoi.ToString();               
                txtSoNuocCu.Text = ctdvm.ChiSoMoi.ToString();
                txtSoDienMoi.Text= ctdvd.ChiSoMoi.ToString();             
                txtSoNuocMoi.Text = ctdvm.ChiSoMoi.ToString();
            }
            else
            {               
                txtSoDienCu.Text = "0";
                txtSoNuocCu.Text = "0";
                txtSoDienMoi.Text = "0";
                txtSoNuocMoi.Text = "0";
            }
           
        }
        private void FrmHoaDonDichVu_Load(object sender, EventArgs e)
        {
            LoadDSHoaDon();
            LoadCboAllMaThue();
            
        }
       
        private void btnThem_ItemClick(object sender, ItemClickEventArgs e)
        {
            Click_BtnThem();
            LoadCboMaThue();
            TaoMoi();
            txtMaDK.Focus();        
        }

        private void btnLuu_ItemClick(object sender, ItemClickEventArgs e)
        {
            string s = txtMaDK.EditValue.ToString();
            if (string.IsNullOrEmpty(s))
            {
                MessageBox.Show("Hãy chọn mã thuê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaDK.Focus();
                return;
            }    
            if(check)
            {
                try
                {
                    PhieuDichVu pdv = new PhieuDichVu();
                    pdv.MaPhieuDV = txtHoaDon.EditValue.ToString();
                    pdv.NgayLap = Commons.ConvertStringToDate(txtNgayLap.Text);
                    pdv.NgayThanhToan = Commons.ConvertStringToDate(txtNgayLap.Text);
                    pdv.TongTien = tongTien;
                    pdv.TinhTrang = 1;
                    pdv.MaThueMB = txtMaDK.EditValue.ToString();
                    pdv.MaNhanVien = maNV;
                    CT_DichVu ctdvDien = new CT_DichVu();
                    ctdvDien.MaPhieuDV = txtHoaDon.EditValue.ToString();
                    ctdvDien.MaDichVu = "AEON_MDV0001";
                    ctdvDien.ChiSoMoi = int.Parse(txtSoDienMoi.EditValue.ToString());
                    ctdvDien.ChiSoCu = int.Parse(txtSoDienCu.EditValue.ToString());

                    CT_DichVu ctdvNuoc = new CT_DichVu();
                    ctdvNuoc.MaPhieuDV = txtHoaDon.EditValue.ToString();
                    ctdvNuoc.MaDichVu = "AEON_MDV0002";
                    ctdvNuoc.ChiSoMoi = int.Parse(txtSoNuocMoi.EditValue.ToString());
                    ctdvNuoc.ChiSoCu = int.Parse(txtSoNuocCu.EditValue.ToString());
                    bool keys = true;
                    if (!thueMB.ThemHoaDonDichVu(pdv))
                    {
                        keys = false;
                        thueMB.XoaHoaDonDichVu(pdv.MaPhieuDV);
                    }
                    if (!thueMB.ThemCTHoaDonDichVu(ctdvDien) || !thueMB.ThemCTHoaDonDichVu(ctdvNuoc))
                    {
                        keys = false;
                        thueMB.XoaCTHoaDonDichVu(pdv.MaPhieuDV);
                    }
                    if(keys)
                    {
                        MessageBox.Show("Thêm hóa đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ThongBao tt = new ThongBao();
                        tt.NgayTao = Commons.ConvertStringToDate(txtNgayLap.Text);
                        tt.TaiKhoan = pdv.ThueMatBang.DangKyThue.KhachHang.SDT;
                        tt.MaLoaiTT = 1;
                        tt.TrangThai = 1;
                        tt.NoiDung = string.Format(QL_MatBang.NOIDUNGTHONGBAO, (DateTime.Now).Month + "/" + (DateTime.Now).Year);
                        tt.TieuDe = QL_MatBang.TIEUDETHONGBAO;
                        thueMB.ThemThongBaoDichVu(tt);
                    }
                    Click_BtnLuu();
                    LoadDSHoaDon();
                    LoadCboMaThue();
                    LoadCboAllMaThue();
                    dgvDSHoaDon_FocusedRowChanged(null,null);
                }
                catch (Exception)
                {
                    MessageBox.Show("Đã có lỗi xẩy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    throw;
                }                               
            }    

        }

        private void dgvDSHoaDon_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (check)
            {
                txtMaDK.EditValue = "";
                return;
            }    
                
            LoadCboAllMaThue();
            string ma = dgvDSHoaDon.GetFocusedRowCellDisplayText(colMaHoaDon);
            if (!string.IsNullOrEmpty(ma))
            {
                LayThongTinPhieuDV(ma);
                txtNgayLap.Text = dgvDSHoaDon.GetFocusedRowCellDisplayText(colNgayLap);
                txtNgayThanhToan.Text = dgvDSHoaDon.GetFocusedRowCellDisplayText(colNgayThanhToan);
                txtTongTien.Text = dgvDSHoaDon.GetFocusedRowCellDisplayText(colTongTien);
                txtMaDK.EditValue = dgvDSHoaDon.GetFocusedRowCellDisplayText(colMaThue);
                cboTrangThai.EditValue = dgvDSHoaDon.GetFocusedRowCellDisplayText(colTinhTrang);
            }
        }

        private void btnHuy_ItemClick(object sender, ItemClickEventArgs e)
        {
            Click_BtnHuy();
            dgvDSHoaDon.Focus();
        }

        private void txtMaDK_EditValueChanged(object sender, EventArgs e)
        {
            if (!checkhd)
                return;
            if(!string.IsNullOrEmpty(txtMaDK.Text.ToString())&& !txtMaDK.Text.Equals("Hãy chọn mã đăng ký"))
            {
                LayHoaDonGanNhat(txtMaDK.EditValue.ToString());
            }    
        }

        private void txtSoDienMoi_EditValueChanged(object sender, EventArgs e)
        {
            if (!check)
                return;
            if (int.Parse(txtSoDienMoi.EditValue.ToString()) < int.Parse(txtSoDienCu.EditValue.ToString()))
            {
                MessageBox.Show("Chỉ số mới không được bé hơn chỉ số cũ","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtSoDienMoi.EditValue = txtSoDienCu.EditValue;
                return;
            }
            tongTien = TongTien(int.Parse(txtSoNuocMoi.Text.ToString()),
               int.Parse(txtSoNuocCu.Text.ToString()), 
               int.Parse(txtSoDienMoi.Text.ToString()), 
               int.Parse(txtSoDienCu.Text.ToString()));
            txtTongTien.EditValue = string.Format("{0:0,0 vnđ}", tongTien);
        }

        private void txtSoNuocMoi_EditValueChanged(object sender, EventArgs e)
        {
            if (!check)
                return;
            if (int.Parse(txtSoNuocMoi.EditValue.ToString()) < int.Parse(txtSoNuocCu.EditValue.ToString()))
            {
                MessageBox.Show("Chỉ số mới không được bé hơn chỉ số cũ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoNuocMoi.EditValue = txtSoNuocCu.EditValue;
                return;
            }
            tongTien = TongTien(int.Parse(txtSoNuocMoi.Text.ToString()),
              int.Parse(txtSoNuocCu.Text.ToString()),
              int.Parse(txtSoDienMoi.Text.ToString()),
              int.Parse(txtSoDienCu.Text.ToString()));
            txtTongTien.EditValue = string.Format("{0:0,0 vnđ}", tongTien);
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            btnThem_ItemClick(null,null);
        }

        private void btnHuyThem_Click(object sender, EventArgs e)
        {
            btnHuy_ItemClick(null,null);
        }

        private void btnLuuNV_Click(object sender, EventArgs e)
        {
            btnLuu_ItemClick(null,null);
        }
    }
}