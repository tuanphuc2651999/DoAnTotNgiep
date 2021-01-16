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
using Liz.DoAn;
using BLL;
using DAL;
using QL_MatBangTTTM.Resource;
using static Liz.DoAn.NotificationForCustomer;

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
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
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
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnHuy.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnLuuNV.Visible = true;
            btnNhapLai.Visible = true;
            btnHuyThem.Visible = true;
            choNhapTextBox(false);
            txtMaDK.ReadOnly = true;
            check = true;
            checkhd = false;
        }
        private void Click_BtnLuu()
        {
            btnThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnHuy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnLuuNV.Visible = false;
            btnNhapLai.Visible = false;
            btnHuyThem.Visible = false;
            choNhapTextBox(true);
            check = false;
            checkhd = false;
        }
        private void Click_BtnHuy()
        {
            btnThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnHuy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnLuuNV.Visible = false;
            btnNhapLai.Visible = false;
            btnHuyThem.Visible = false;
            choNhapTextBox(true);
            check = false;
            checkhd = false;
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
            cboTrangThai.SelectedIndex = -1;
        }

        public void choNhapTextBox(bool trangThai)
        {
            txtMaDK.ReadOnly = trangThai;
            txtSoDienMoi.ReadOnly = trangThai;
            txtSoNuocMoi.ReadOnly = trangThai;
            cboTrangThai.ReadOnly = trangThai;
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
            if (txtMaDK.EditValue==null)
            {
                MessageBox.Show("Hãy chọn mã thuê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaDK.Focus();
                return;
            } 
            if(string.IsNullOrEmpty(cboTrangThai.Text))
            {
                MessageBox.Show("Hãy chọn trạng thái", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboTrangThai.Focus();
                return;
            }    
            if(txtSoDienCu.Text==txtSoDienMoi.Text&& txtSoNuocMoi.Text == txtSoNuocCu.Text)
            {
                
                    MessageBox.Show("Hãy chọn số điện nước", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSoDienMoi.Focus();
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
                    if(cboTrangThai.SelectedIndex==1)
                    {
                        pdv.TinhTrang = 1;
                    }    
                    else
                    {
                        pdv.TinhTrang = 0;
                    }    
                    pdv.MaThueMB = txtMaDK.EditValue.ToString();
                    pdv.MaNhanVien = maNV;
                    CT_DichVu ctdvDien = new CT_DichVu();
                    ctdvDien.MaPhieuDV = txtHoaDon.EditValue.ToString();
                    ctdvDien.MaDichVu = "AEON_MDV0001";
                    ctdvDien.ChiSoMoi = int.Parse(txtSoDienMoi.EditValue.ToString());
                    ctdvDien.ChiSoCu = int.Parse(txtSoDienCu.EditValue.ToString());
                    ctdvDien.Gia = thueMB.LayGiaDien();
                    CT_DichVu ctdvNuoc = new CT_DichVu();
                    ctdvNuoc.MaPhieuDV = txtHoaDon.EditValue.ToString();
                    ctdvNuoc.MaDichVu = "AEON_MDV0002";
                    ctdvNuoc.ChiSoMoi = int.Parse(txtSoNuocMoi.EditValue.ToString());
                    ctdvNuoc.ChiSoCu = int.Parse(txtSoNuocCu.EditValue.ToString());
                    ctdvNuoc.Gia = thueMB.LayGiaNuoc();
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
                       DialogResult r=  MessageBox.Show("Thêm hóa đơn thành công, bạn có muốn in hóa đơn không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        DAL.ThongBao tt = new DAL.ThongBao();
                        tt.NgayTao = Commons.ConvertStringToDate(txtNgayLap.Text);
                        tt.TaiKhoan = pdv.ThueMatBang.DangKyThue.KhachHang.SDT;
                        tt.MaLoaiTT = 1;
                        tt.TrangThai =1 ;
                        tt.NoiDung = string.Format(QL_MatBang.NOIDUNGTHONGBAO, (DateTime.Now).Month + "/" + (DateTime.Now).Year);
                        tt.TieuDe = QL_MatBang.TIEUDETHONGBAO;
                        thueMB.ThemThongBaoDichVu(tt);
                        if(thueMB.KiemTraToken(dgvDSHoaDon.GetFocusedRowCellDisplayText(colKhachHang)))
                        {
                            Root root = new Root();
                            Notification notification = new Notification();
                            NotificationForCustomer thongbao = new NotificationForCustomer();
                            root.to =thueMB.LayToken(dgvDSHoaDon.GetFocusedRowCellDisplayText(colKhachHang));
                            notification.title = tt.TieuDe;
                            notification.body = tt.NoiDung;
                            notification.mutable_content = "True";
                            notification.sound = "Tri-tone";
                            root.notification = notification;
                            thongbao.ThongBaoChoKhachHang(root);
                        }    

                       
                        if(r==DialogResult.Yes)
                        {
                            PhieuDichVu p = new PhieuDichVu();
                            p = thueMB.LayThongTinPhieuDV(txtHoaDon.EditValue.ToString());
                            List<CT_DichVu> c = new List<CT_DichVu>();
                            c = thueMB.LayThongTinCT_DichVu2(txtHoaDon.EditValue.ToString());
                            InHoaDon(p, c);
                        }                  
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
            else
            {
                PhieuDichVu pdv = new PhieuDichVu();
                pdv.TongTien = tongTien;
                if (cboTrangThai.SelectedIndex == 1)
                {
                    pdv.TinhTrang = 1;
                }
                else
                {
                    pdv.TinhTrang = 0;
                }
                var ctdvd = thueMB.LayThongTinCT_DichVu(txtMaDK.EditValue.ToString(), "AEON_MDV0001");
                var ctdvm = thueMB.LayThongTinCT_DichVu(txtMaDK.EditValue.ToString(), "AEON_MDV0002");
                

              
                if (!thueMB.SuaHoaDonDichVu(pdv))
                {
                    MessageBox.Show("Đã có lỗi xẩy ra không thể sửa hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!ctdvd.ChiSoMoi.ToString().Equals(txtSoDienMoi.EditValue))
                {
                    CT_DichVu ctdvDien = new CT_DichVu();
                    ctdvd.MaPhieuDV = txtHoaDon.EditValue.ToString();
                    ctdvDien.MaDichVu = "AEON_MDV0001";
                    ctdvDien.ChiSoMoi = int.Parse(txtSoDienMoi.EditValue.ToString());
                    if (!thueMB.SuaCTHoaDonDichVu(ctdvDien))
                    {
                        MessageBox.Show("Đã có lỗi xẩy ra không thể sửa hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                if (!ctdvm.ChiSoMoi.ToString().Equals(txtSoNuocMoi.EditValue))
                {

                    CT_DichVu ctdvNuoc = new CT_DichVu();
                    ctdvd.MaPhieuDV = txtHoaDon.EditValue.ToString();
                    ctdvNuoc.MaDichVu = "AEON_MDV0002";
                    ctdvNuoc.ChiSoMoi = int.Parse(txtSoDienMoi.EditValue.ToString());
                    if (!thueMB.SuaCTHoaDonDichVu(ctdvNuoc))
                    {
                        MessageBox.Show("Đã có lỗi xẩy ra không thể sửa hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                MessageBox.Show("Sửa thành công hóa đơn dịch vụ :"+txtHoaDon.EditValue, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Click_BtnLuu();
                LoadDSHoaDon();
                LoadCboMaThue();
                LoadCboAllMaThue();
                dgvDSHoaDon_FocusedRowChanged(null, null);

            }    

        }

        private void dgvDSHoaDon_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (check)
            {
                txtMaDK.EditValue ="";
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
            return;
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
            if(!string.IsNullOrEmpty(txtMaDK.Text.ToString()))
            {
                LayHoaDonGanNhat(txtMaDK.EditValue.ToString());
            }    
            else
            {
                txtSoDienCu.Text = "0";
                txtSoNuocCu.Text = "0";
                txtSoDienMoi.Text = "0";
                txtSoNuocMoi.Text = "0";
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
            if (checkhd == false)
            {
                var cttd = thueMB.LayThongTinCT_DichVu(txtHoaDon.EditValue.ToString(), "AEON_MDV0001");
                var cttn = thueMB.LayThongTinCT_DichVu(txtHoaDon.EditValue.ToString(), "AEON_MDV0002");
                int SNM = int.Parse(txtSoNuocMoi.Text.ToString());
                int SNC = int.Parse(txtSoNuocCu.Text.ToString());
                int SDM = int.Parse(txtSoDienMoi.Text.ToString());
                int SDC = int.Parse(txtSoDienCu.Text.ToString());
                int giaDien = (int)cttd.Gia;
                int giaNuoc = (int)cttn.Gia;
                tongTien = ((SNM - SNC) * giaDien) + ((SDM - SDC) * giaNuoc);
                txtTongTien.EditValue = string.Format("{0:0,0 vnđ}", tongTien);
            }
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

        private void btnSua_ItemClick(object sender, ItemClickEventArgs e)
        {
            if(dgvDSHoaDon.GetFocusedRowCellDisplayText(colTinhTrang).Equals("Đã thanh toán"))
            {
                MessageBox.Show("Hóa đơn "+txtHoaDon.EditValue+" đã thanh toán bạn không thể chỉnh xửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }    
            Click_BtnSua();
        }

        private void InHoaDon(PhieuDichVu dv, List<CT_DichVu> ct)
        {
            FrmInHD inHD = new FrmInHD();
            inHD.print(dv, ct);
            inHD.ShowDialog();
        }
        
    }
}