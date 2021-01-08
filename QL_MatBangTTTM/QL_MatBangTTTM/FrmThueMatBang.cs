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
using DevExpress.XtraEditors.Controls;
using Liz.DoAn;

namespace QL_MatBangTTTM
{
    public partial class FrmThueMatBang : DevExpress.XtraEditors.XtraForm
    {
        BLL_ThueMatBang thueMB = new BLL_ThueMatBang();
        BLL_KhachHang khachHang = new BLL_KhachHang();       
        int tienCoc = 0;
        int thoiHanThue = 0;
        int phiDV = 0;
        string maHD;
        int soNamDaThanhToan = 0;
        bool check = true;
        string maNV;
        public FrmThueMatBang(string maNV)
        {
            InitializeComponent();
            this.maNV = maNV;
        }
        public void choNhapTextBox(bool tinhTrang)
        {
            txtMaDK.ReadOnly = tinhTrang;


        }
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
            //checkTaoTK.Visible = true;
        }
        private void Click_BtnSua()
        {
            btnThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;          
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnHuy.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnLuuNV.Visible = true;
            btnNhapLai.Visible = true;
            btnHuyThem.Visible = true;
            check = false;
            txtThoiHanThue.ReadOnly = false;
            txtThoiHanThue.Focus();               
        }
        private void Click_BtnLuu()
        {
            btnThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
           
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnHuy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnLuuNV.Visible = false;
            btnNhapLai.Visible = false;
            check = true;
            btnHuyThem.Visible = false;
            choNhapTextBox(true);
            //choNhapTextBox(true);
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
            //choNhapTextBox(true);        
        }
        private void btnThem_ItemClick(object sender, ItemClickEventArgs e)
        {
            TaoMoi();
            LoadDSDKThue();
            check = false;
            txtMaDK.Focus();
            Click_BtnThem();

        }
        public void LoadDSThue()
        {
            gcThueMatBang.DataSource = thueMB.LayDSThueMatBang();
        }
        public void LoadDSDKThue()
        {
            txtMaDK.Properties.DataSource = thueMB.LayDSMatBangChuaThue();
        }
        public void LoadCboDangKyAll()
        {
            txtMaDK.Properties.DataSource = thueMB.LayDSDangKy();
        }
        public void LoadTienThue()
        {
           // txtLoaiDichVu.Properties.DataSource = thueMB.DSGia();
        }

        private void AnHienButtonAddHoaDon(bool trangThai)
        {
            DevExpress.XtraEditors.Controls.EditorButtonCollection buttons = txtTienCoc.Properties.Buttons;
            foreach (EditorButton item in buttons)
            {
                item.Visible = trangThai;
            }
        }
        private void TaoMoi()
        {
            txtMaThue.EditValue = thueMB.LayMaThueTuSinh();
            txtNgayLap.EditValue = DateTime.Now;
            txtNhanVien.EditValue =maNV;
            txtNgayThue.EditValue = "";
            txtNgayHetHan.EditValue = "";
            txtThoiHanThue.EditValue = "";
            txtPhiDV.EditValue = "";
            txtMaKhachHang.EditValue = "";
            txtViTri.EditValue = "";
            txtDienTich.EditValue = "";
            txtNamDaThanhToan.EditValue = 0;
            txtTienCoc.EditValue = 0;
            txtMaMB.EditValue = "";
            txtMaDK.EditValue = "";
        }
        private void LayThongTinDKThue(string ma)
        {
            var tt = thueMB.LayThongTinDKThue(ma);    
            if(tt!=null)
            {
                var mb = thueMB.LayThongTinMB(tt.MatBang);
                var kh = khachHang.LayTTKhachHang(tt.MaKhachHang);
                var hoaDon = thueMB.HoaDon(ma);
                DateTime ngayHetHan;
                DateTime ngayThue = (DateTime)tt.NgayMoCua;
                ngayHetHan = ngayThue.AddYears(1);
                txtNgayThue.EditValue = tt.NgayMoCua;
                txtNgayHetHan.EditValue = ngayHetHan;
                txtThoiHanThue.EditValue =tt.ThoiHanThue;
                if(hoaDon!=null)
                {
                    txtTienCoc.EditValue = String.Format("{0:0,0 vnđ}", hoaDon.SoTien);
                    maHD = hoaDon.MaHD;
                }   
                else
                {
                    txtTienCoc.EditValue = "";
                    AnHienButtonAddHoaDon(true);
                }
                txtPhiDV.EditValue= string.Format("{0:0,0 vnđ/năm}", thueMB.PhiDichVu((int)mb.DienTich));
                txtMaMB.EditValue = tt.MatBang;
                txtMaKhachHang.EditValue = kh.MaKH;
                txtViTri.EditValue = mb.ViTri;
                txtDienTich.EditValue = string.Format("{0:0 (m2)}", mb.DienTich);
                //tienCoc = (int)hoaDon.SoTien;
                thoiHanThue = (int)tt.ThoiHanThue;
                phiDV = (int)thueMB.PhiDichVu((int)mb.DienTich);
                if (string.IsNullOrEmpty(dgvDSThueMatBang.GetFocusedRowCellDisplayText(colDaThanhToan).ToString()))
                    txtNamDaThanhToan.EditValue = 0;
                else
                txtNamDaThanhToan.EditValue = dgvDSThueMatBang.GetFocusedRowCellDisplayText(colDaThanhToan).ToString();
            }               
        }
        public void LoadLaiDS()
        {
            LoadDSThue();
            LoadDSDKThue();
            LoadTienThue();
            LoadCboDangKyAll();
        }
        private void FrmThueMatBang_Load(object sender, EventArgs e)
        {
            LoadLaiDS();
        }

        private void txtMaDK_EditValueChanged(object sender, EventArgs e)
        {
            LayThongTinDKThue(txtMaDK.EditValue.ToString());
        }

        private void btnLuu_ItemClick(object sender, ItemClickEventArgs e)
        {
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtMaDK.EditValue.ToString()))
            {
                MessageBox.Show("Bạn chưa chọn mã thuê mặt bằng");
                errorProvider1.SetError(txtMaDK, "Bạn chưa chọn mã thuê mặt bằng");
                txtMaDK.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtTienCoc.EditValue.ToString()))
            {
                MessageBox.Show("Chưa có hóa đơn tiền cọc hãy tạo hóa đơn tiền cọc rồi mới có thể thuê mặt bằng");
                errorProvider1.SetError(txtTienCoc,"Hãy tạo hóa đơn");
                txtTienCoc.Focus();
                return;
            }    
            ThueMatBang themMB = new ThueMatBang();
            themMB.MaThueMB = txtMaThue.EditValue.ToString();
            themMB.NgayLap = (DateTime)txtNgayLap.EditValue;
            themMB.NgayThue = (DateTime)txtNgayThue.EditValue;
            themMB.NgayHetHanHopDong = (DateTime)txtNgayHetHan.EditValue;
            themMB.ThoiHanThue = int.Parse(txtThoiHanThue.EditValue.ToString());
            themMB.SoNamDaThanhToan = int.Parse(txtNamDaThanhToan.EditValue.ToString());
            themMB.HoaDonTienCoc = maHD;
            themMB.PhiDichVuMotNam = phiDV;
            themMB.TinhTrang = 1;
            themMB.MaNhanVien = maNV;
            themMB.MaDKThue = txtMaDK.EditValue.ToString();
            if(check)
            {
                if (!thueMB.ThemThueMatBang(themMB))
                {
                    MessageBox.Show("Không thể thêm thuê mặt bằng");
                    return;
                }
                MessageBox.Show("Thêm thành công");
                Click_BtnLuu();
                LoadLaiDS();
            }
            else
            {
                if (!thueMB.SuaThueMatBang(themMB))
                {
                    MessageBox.Show("Sửa mặt bằng lỗi");
                    return;
                }
                MessageBox.Show("Sửa thành công");
                Click_BtnLuu();
                txtThoiHanThue.ReadOnly = true;
                dgvDSThueMatBang.Focus();
                LoadLaiDS();
            }    
            
           
        }

        private void dgvDSThueMatBang_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (check == false)
                return;
            string maDK = dgvDSThueMatBang.GetFocusedRowCellValue(colMaDKThue).ToString();
            txtMaDK.EditValue = maDK;
            txtMaThue.EditValue= dgvDSThueMatBang.GetFocusedRowCellValue(colMaThue).ToString();
            txtThoiHanThue.EditValue= dgvDSThueMatBang.GetFocusedRowCellValue(colThoiHanThue).ToString();
            txtNhanVien.EditValue = dgvDSThueMatBang.GetFocusedRowCellValue(colNhanVien).ToString();          
            txtNgayLap.EditValue=Commons.ConvertStringToDate(dgvDSThueMatBang.GetFocusedRowCellDisplayText(colNgayLap));
            txtTrangThai.Text= dgvDSThueMatBang.GetFocusedRowCellValue(colTrangThai).ToString();           
        }

        private void btnHuy_ItemClick(object sender, ItemClickEventArgs e)
        {
            Click_BtnHuy();
            LoadCboDangKyAll();
            dgvDSThueMatBang_FocusedRowChanged(null, null);
            dgvDSThueMatBang.Focus();
        }

        private void buttonEdit1_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
           // MessageBox.Show("OK");
        }

        private void txtTienCoc_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmTaoHoaDonTienCoc hoaDonTT = new FrmTaoHoaDonTienCoc(txtMaDK.EditValue.ToString(), txtMaMB.EditValue.ToString()) ;
            hoaDonTT.ShowDialog();
            string maDK = txtMaDK.EditValue.ToString();
            LayThongTinDKThue(maDK);
        }

        private void txtTienCoc_EditValueChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void btnSua_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dgvDSThueMatBang.GetFocusedRowCellValue(colTrangThai).ToString().Equals("Đã trả"))
            {
                MessageBox.Show("Hợp đồng này đã trả bạn không thể chỉnh sửa","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;

            }
            Click_BtnSua();
        }

        private void txtThoiHanThue_EditValueChanged(object sender, EventArgs e)
        {
            if (check)
                return;
            errorProvider1.Clear();
            if (int.Parse(txtThoiHanThue.EditValue.ToString())< int.Parse(dgvDSThueMatBang.GetFocusedRowCellValue(colThoiHanThue).ToString()))
            {
                MessageBox.Show("Thời hạn thuê chỉnh sửa không thể bé hơn thời gian thuê lúc trước");
                txtThoiHanThue.EditValue = int.Parse(dgvDSThueMatBang.GetFocusedRowCellValue(colThoiHanThue).ToString());
                errorProvider1.SetError(txtThoiHanThue, "Hãy chọn lại thời hạn thuê");
                txtThoiHanThue.Focus();
                return;
            }    
        }

        private void btnLuuNV_Click(object sender, EventArgs e)
        {
            btnLuu_ItemClick(null,null);
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            TaoMoi();
        }

        private void btnHuyThem_Click(object sender, EventArgs e)
        {
            btnHuy_ItemClick(null,null);
        }
    }
}