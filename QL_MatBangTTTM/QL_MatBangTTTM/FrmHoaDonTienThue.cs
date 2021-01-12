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
using DAL;
using Liz.DoAn;

namespace QL_MatBangTTTM
{
    public partial class FrmHoaDonTienThue : DevExpress.XtraEditors.XtraForm
    {
        BLL_HoaDonTienThue hd = new BLL_HoaDonTienThue();
        string maNV;
        int tienThue;
        int tienDV;
        int tongTien;
        int namToiDa;
        int ky;
        bool check = false;
        bool checkSua = false;
        public FrmHoaDonTienThue(string maNV)
        {
            InitializeComponent();
            this.maNV = maNV;
        }
        public void LoadDSThue()
        {
            txtMaThue.Properties.DataSource = hd.LayMaThueMB();
        }
        public void LoadAllDSThue()
        {
            txtMaThue.Properties.DataSource = hd.LayAllMaThueMB();
        }
        public void LoadDSHoaDon()
        {
            gcHoaDon.DataSource = hd.LayDSHoaDon();
        }
        public void XoaTextBox()
        {

            txtNamDaDong.EditValue = null;
            txtTienDichVu.EditValue = null;
            txtMaMatBang.EditValue = null;
            txtViTri.EditValue = null;
            txtDienTich.EditValue = null;
            txtKhachHang.EditValue = null;
            txtTienThue.EditValue = null;
            txtTongTien.EditValue = null;
            cboTrangThai.SelectedIndex = -1;
            tienThue = 0;
            tienDV = 0;
            tongTien = 0;
            ky = 0;
            namToiDa = 0;
        }
        public void LayTT(string ma)
        {
            var tt = hd.LayTTThueMB(ma);
            if (tt != null)
            {

                tienThue = hd.TinhTienThue((int)tt.DangKyThue.MatBang1.DienTich);
                tienDV= (int)tt.PhiDichVuMotNam;
                ky = int.Parse( txtKy.EditValue.ToString());
                namToiDa = (int)tt.ThoiHanThue;
                txtNamDaDong.EditValue = tt.SoNamDaThanhToan + "/" + tt.ThoiHanThue;
                txtTienDichVu.EditValue = string.Format("{0:0,0 vnđ}", tienDV);
                txtMaMatBang.EditValue = tt.DangKyThue.MatBang;
                txtViTri.EditValue = tt.DangKyThue.MatBang1.ViTri;
                txtDienTich.EditValue = tt.DangKyThue.MatBang1.DienTich;
                txtKhachHang.EditValue = tt.DangKyThue.MaKhachHang;
                txtTienThue.EditValue = string.Format("{0:0,0 vnđ}", tienThue);
                txtTongTien.EditValue = string.Format("{0:0,0 vnđ}",ky*tienThue+tienDV);
                tongTien = ky * tienThue + ky*tienDV;
            }    
        }
        public void choNhapTextBox(bool tinhTrang)
        {
            txtMaThue.ReadOnly = tinhTrang;
            //txtKy.ReadOnly = tinhTrang;
            cboTrangThai.ReadOnly = tinhTrang;
        }
        private void Click_BtnThem()
        {
            btnThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnHuy.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnLuuHD.Visible = true;
            btnNhapLai.Visible = true;
            btnHuyThem.Visible = true;
            choNhapTextBox(false);
            check = true;
            checkSua = false;
        }
        private void Click_BtnSua()
        {
            btnThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnHuy.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnLuuHD.Visible = true;
            btnNhapLai.Visible = true;
            btnHuyThem.Visible = true;
            choNhapTextBox(false);
            checkSua = true;
            check = false;
        }
        private void Click_BtnLuu()
        {
            btnThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnHuy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnLuuHD.Visible = false;
            btnNhapLai.Visible = false;
            btnHuyThem.Visible = false;
            choNhapTextBox(true);
            check = false;           
        }
        private void Click_BtnHuy()
        {
            btnThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnHuy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnLuuHD.Visible = false;
            btnNhapLai.Visible = false;
            btnHuyThem.Visible = false;
            choNhapTextBox(true);
            check = false;
            checkSua = false;
        }

        private void btnThem_ItemClick(object sender, ItemClickEventArgs e)
        {
            XoaTextBox();
            LoadDSThue();
            Click_BtnThem();
            txtNhanVien.Text = maNV;
            txtMaHD.Text = hd.LayMaThueTuSinh();
            txtMaThue.EditValue = null;
            txtNgayLap.Text=  (DateTime.Now).ToString("dd/MM/yyyy");
            txtMaThue.Focus();
        }

        private void btnSua_ItemClick(object sender, ItemClickEventArgs e)
        {
            if(dgvDSHoaDon.GetFocusedRowCellDisplayText(colTinhTrang).Equals("Đã đóng"))
            {
                MessageBox.Show("Hóa đơn này đã đóng không thể sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            cboTrangThai.ReadOnly = false;
            Click_BtnSua();
        }

        private void btnLuu_ItemClick(object sender, ItemClickEventArgs e)
        {
            errorProvider1.Clear();
            if (txtMaThue.EditValue==null||txtMaThue.Text=="")
            {
                MessageBox.Show("Bạn chưa chọn mã thuê hay chọn mã thuê","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                errorProvider1.SetError(txtMaThue, "Hãy chọn mã thuê");
                txtMaThue.Focus();
                return;
            }
            HoaDonTienThue hoadon = new HoaDonTienThue();
            hoadon.MaHDTienThue = txtMaHD.EditValue.ToString() ;
            hoadon.NgayLap =Commons.ConvertStringToDate(txtNgayLap.Text);
            hoadon.NgayThanhToan = null;
            hoadon.TienThue =tienThue;
            hoadon.TienDichVu = tienDV;
            hoadon.TongTien = tongTien;
            if(cboTrangThai.SelectedIndex==1)
                hoadon.TinhTrang = 1;
            else
                hoadon.TinhTrang = 0;
            hoadon.Ky = ky;
            hoadon.MaThueMB = txtMaThue.EditValue.ToString();
            hoadon.MaNV = maNV;
            if(check)
            {
                if (!hd.ThemHoaDonTienThue(hoadon))
                {
                    MessageBox.Show("Thêm hóa đơn không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("Thêm hóa đơn " + txtMaHD.Text + " thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Click_BtnLuu();
                    LoadDSHoaDon();
                    dgvDSHoaDon_FocusedRowChanged(null, null);
                    return;
                }
            }    
           if(checkSua)
            {
                if (!hd.SuaHoaDonTienThue(hoadon))
                {
                    MessageBox.Show("Sửa hóa đơn lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("Sửa hóa đơn " + txtMaHD.Text + " thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Click_BtnLuu();
                    LoadAllDSThue();
                    LoadDSHoaDon();
                    dgvDSHoaDon_FocusedRowChanged(null, null);
                    cboTrangThai.ReadOnly = true;
                    return;
                }
            }    
           
        }

        private void btnHuy_ItemClick(object sender, ItemClickEventArgs e)
        {
            Click_BtnHuy();
            LoadAllDSThue();            
            dgvDSHoaDon_FocusedRowChanged(null,null);
            txtKy.ReadOnly = true;
            dgvDSHoaDon.Focus();
        }

        private void FrmHoaDonTienThue_Load(object sender, EventArgs e)
        {
            LoadAllDSThue();
            LoadDSHoaDon();
        }

        private void txtMaThue_EditValueChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtMaThue.EditValue!=null&& txtMaThue.EditValue != "")
            {
                LayTT(txtMaThue.EditValue.ToString());
                if (check)
                {
                    txtKy.ReadOnly = false;
                }
            }                                    
        }

        private void txtKy_EditValueChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            ky = int.Parse(txtKy.EditValue.ToString());
            if (namToiDa<ky)
            {
                MessageBox.Show("Bạn thuê "+namToiDa+" năm bạn không thể đóng tiền quá "+namToiDa, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(txtKy,"Hãy chọn lại sô kỳ");
                txtKy.EditValue = 1;
                return;
            }
            tongTien = ky * tienThue + ky* tienDV;
            tienThue = ky * tienThue;
            txtTienThue.EditValue = string.Format("{0:0,0 vnđ}", tienThue);
            txtTongTien.EditValue = string.Format("{0:0,0 vnđ}", tongTien);
        }

        private void dgvDSHoaDon_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if(check)
            {
                return;
            }    
            txtMaHD.Text = dgvDSHoaDon.GetFocusedRowCellDisplayText(colMaHD);
            txtMaThue.EditValue = dgvDSHoaDon.GetFocusedRowCellDisplayText(colMaThueMB);
            txtNhanVien.EditValue = dgvDSHoaDon.GetFocusedRowCellDisplayText(colNhanVien);
            cboTrangThai.Text= dgvDSHoaDon.GetFocusedRowCellDisplayText(colTinhTrang);
            txtNgayLap.Text= dgvDSHoaDon.GetFocusedRowCellDisplayText(colNgayLap);
            txtKy.EditValue= dgvDSHoaDon.GetFocusedRowCellDisplayText(colKyThanhToan);
        }

        private void btnLuuHD_Click(object sender, EventArgs e)
        {
            btnLuu_ItemClick(null, null) ;
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            XoaTextBox();
            txtMaThue.Focus();
        }

        private void btnHuyThem_Click(object sender, EventArgs e)
        {
            btnHuy_ItemClick(null,null);
            dgvDSHoaDon_FocusedRowChanged(null, null);
        }
    }
}