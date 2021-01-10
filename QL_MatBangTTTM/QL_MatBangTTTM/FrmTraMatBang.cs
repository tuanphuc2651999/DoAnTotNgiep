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
using DevExpress.XtraEditors.Controls;

namespace QL_MatBangTTTM
{
    public partial class FrmTraMatBang : DevExpress.XtraEditors.XtraForm
    {
        BLL_TraMatBang traMB = new BLL_TraMatBang();
        BLL_XuLyViPham vp = new BLL_XuLyViPham();
        BLL_ThueMatBang thueMB = new BLL_ThueMatBang();
        bool check = false;
        string maNV;
        string maVP;
        public FrmTraMatBang(string maNV)
        {
            InitializeComponent();
            this.maNV = maNV;
        }
        private void AnHienButtonAddHoaDon(bool trangThai)
        {
            DevExpress.XtraEditors.Controls.EditorButtonCollection buttons = txtViPham.Properties.Buttons;
            foreach (EditorButton item in buttons)
            {
                item.Visible = trangThai;
            }
        }
        #region Lấy thông tin
        public void LoadDSThueMatBang()
        {
            txtMaThueMB.Properties.DataSource = traMB.LayDSDangThueMatBang();
        }
        public void LoadDSTraMB()
        {
            gcDSTraMB.DataSource = traMB.LayDSTraMatBang();
        }
        public void LoadAllDSThueMatBang()
        {
            txtMaThueMB.Properties.DataSource = traMB.LayAllDSDangThueMatBang();
        }
        public void choNhapTextBox(bool trangThai)
        {
            txtMaThueMB.ReadOnly = trangThai;          
        }
        public void LayThongTin(string ma)
        {
            var tt = thueMB.LayThongTinThueMatBang(ma);
            if (tt == null)
                return;
            else
            {
                txtMaMatBang.Text = tt.DangKyThue.MatBang;
                txtViTri.Text = tt.DangKyThue.MatBang1.ViTri.ToString();
                txtNgayHetHan.Text = string.Format("{0:dd/MM/yyyy}", tt.NgayHetHanHopDong);
                txtKhachHang.Text = tt.DangKyThue.MaKhachHang;
                txtTienHoanLai.Text= string.Format("{0:0,0 vnđ}", traMB.TinhTienHoanLai(tt.MaThueMB));
                TimeSpan kt = Commons.ConvertStringToDate(txtNgayHetHan.Text) - Commons.ConvertStringToDate(txtNgayTra.Text);
                int ngay = kt.Days;
                if (ngay == 0)
                {
                    cboTinhTrang.SelectedIndex = 0;
                }
                else if (ngay < 0)
                {
                    cboTinhTrang.SelectedIndex = 1;
                }
                else
                {
                    cboTinhTrang.SelectedIndex = 2;
                }
            }    
        }
        #endregion
        private void TaoMoi()
        {
            LoadDSThueMatBang();
            txtNhanVien.Text = maNV;          
            txtMaPhieuTra.Text = traMB.LayMaTraMatBangTuSinh();
            txtNgayLap.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtNgayTra.EditValue = Commons.ConvertStringToDate(DateTime.Now.ToString("dd/MM/yyyy"));
            txtMaThueMB.EditValue = null;
            txtMaMatBang.EditValue = null;
            txtViTri.EditValue = null;
            txtNgayHetHan.EditValue = null;
            txtNgayTra.EditValue = null;
            txtTienHoanLai.EditValue = null;
            txtViPham.EditValue = null;
            txtKhachHang.EditValue = null;
            cboTinhTrang.SelectedIndex = -1;
        }
        
        #region BTN
        private void Click_BtnThem()
        {
            TaoMoi();
            btnThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
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
           // btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
           // btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnHuy.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnLuuNV.Visible = true;
            btnNhapLai.Visible = false;
            btnHuyThem.Visible = true;
            choNhapTextBox(false);
            check = false;
        }
        private void Click_BtnLuu()
        {
            btnThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
           // btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
           // btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
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
           // btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
           // btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnHuy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnLuuNV.Visible = false;
            btnNhapLai.Visible = false;
            btnHuyThem.Visible = false;
            choNhapTextBox(true);
            check = false;

        }
        #endregion

        private void btnThem_ItemClick(object sender, ItemClickEventArgs e)
        {
            Click_BtnThem();             
            AnHienButtonAddHoaDon(false);
        }

        private void btnXoa_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnSua_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Click_BtnSua();
        }

        private void btnLuu_ItemClick(object sender, ItemClickEventArgs e)
        {
            errorProvider1.Clear();
            if (txtMaThueMB.EditValue==null)
            {
                MessageBox.Show("Bạn chưa chọn mã thuê mặt bằng");
                errorProvider1.SetError(txtMaThueMB, "Bạn chưa chọn mã thuê mặt bằng");
                txtMaThueMB.Focus();
                return;
            }
            TraMatBang traMatBang = new TraMatBang();
            traMatBang.MaNhanVien = maNV;
            traMatBang.MaTraMatBang = txtMaPhieuTra.Text;
            traMatBang.NgayLap = Commons.ConvertStringToDate(txtNgayLap.Text);
            traMatBang.NgayTra = Commons.ConvertStringToDate(txtNgayTra.Text);
            traMatBang.TienHoanLai = traMB.TinhTienHoanLai(txtMaThueMB.EditValue.ToString()) ;
            traMatBang.ThueMB = txtMaThueMB.EditValue.ToString();
            TimeSpan kt = Commons.ConvertStringToDate(txtNgayHetHan.Text)- Commons.ConvertStringToDate(txtNgayTra.Text);
            int ngay = kt.Days;
            if (ngay==0)
            {
                traMatBang.TinhTrang = 1;
            }
            else if(ngay<0)
            {
                traMatBang.TinhTrang = 0;
            }
            else
            {
                traMatBang.TinhTrang = -1;
            }
            if (string.IsNullOrEmpty(txtViPham.Text))
            {
                if(txtNgayTra.Text!=txtNgayHetHan.Text)
                {
                   DialogResult r= MessageBox.Show("Ngày trả không đúng ngày hết hạn hợp đồng bạn có chắc không muốn thêm vi phạm không?"
                        ,"Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
                   if(r==DialogResult.Yes)
                    {
                        if(traMB.ThemTraMatBang(traMatBang))
                        {
                            MessageBox.Show("Thêm trả mặt bằng thành công"
                        , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            maVP = null;
                            Click_BtnLuu();
                            LoadDSTraMB();
                            return;
                        }    
                    }    
                   else
                    {
                        return;      
                    }    
                }    
            }
            else
            {
                if (traMB.ThemTraMatBang(traMatBang))
                {
                    MessageBox.Show("Thêm trả mặt bằng thành công"
                , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    maVP = null;
                    Click_BtnLuu();
                    LoadDSTraMB();
                    return;
                }
            }    
        }

        private void btnHuy_ItemClick(object sender, ItemClickEventArgs e)
        {
            Click_BtnHuy();
            dgvDSTraMB.Focus();
            dgvDSTraMB_FocusedRowChanged(null,null);
        }

        private void FrmTraMatBang_Load(object sender, EventArgs e)
        {
            LoadAllDSThueMatBang();
            LoadDSTraMB();
        }
        private void buttonEdit1_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
           if(txtViPham.Text.Length>0)
            {
                MessageBox.Show("Đã có vi phạm yêu cầu chấm dứt hợp đồng không thể tạo thêm?"
                         , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }   
           else
            {
                if(txtMaThueMB.EditValue==null)
                {
                    MessageBox.Show("Bạn chưa chọn mã thuê không thể thêm vi phạm"
                         , "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    txtMaThueMB.Focus();
                    return;
                }    
                FrmTaoXuLyViPham viPham = new FrmTaoXuLyViPham(maNV, txtMaThueMB.EditValue.ToString()) ;
                viPham.ShowDialog();
                maVP = viPham.MaViPham();
                if(!string.IsNullOrEmpty(maVP))
                {
                    string tenVP = vp.LayTTViPhamChamDutHD(txtMaThueMB.EditValue.ToString());
                    if (!string.IsNullOrEmpty(tenVP))
                        txtViPham.Text = tenVP;
                }    
                
            }    
        }
        
        private void txtMaThueMB_EditValueChanged(object sender, EventArgs e)
        {   
            if(txtMaThueMB.EditValue!=null)
            {
                txtNgayTra.EditValue = Commons.ConvertStringToDate(DateTime.Now.ToString("dd/MM/yyyy"));
                LayThongTin(txtMaThueMB.EditValue.ToString());
                string tenVP = vp.LayTTViPhamChamDutHD(txtMaThueMB.EditValue.ToString());
                if (txtNgayHetHan.EditValue == txtNgayTra.EditValue)
                {
                    AnHienButtonAddHoaDon(true);
                    return;
                }

                if (!string.IsNullOrEmpty(tenVP))
                {
                    txtViPham.Text = tenVP;
                    AnHienButtonAddHoaDon(false);
                    return;
                }                   
                else
                {
                    AnHienButtonAddHoaDon(true);
                }                                       
            } 
            else
            {
                TaoMoi();
            }
            if (!check)
            {
                AnHienButtonAddHoaDon(false);
                return;
            }
        }

        private void FrmTraMatBang_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!string.IsNullOrEmpty(maVP))
            {
                vp.XoaViPhamn(maVP);
            }    
        }

        private void dgvDSTraMB_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (check)
                return;
            LoadAllDSThueMatBang();
           txtMaPhieuTra.Text = dgvDSTraMB.GetFocusedRowCellDisplayText(colMaPT).ToString();
            txtNgayTra.Text = dgvDSTraMB.GetFocusedRowCellDisplayText(colNgayTrar).ToString();
            txtNgayLap.Text = dgvDSTraMB.GetFocusedRowCellDisplayText(colNgayLap).ToString();
            txtNhanVien.Text = dgvDSTraMB.GetFocusedRowCellDisplayText(colNhanVien).ToString();
            txtMaThueMB.EditValue= dgvDSTraMB.GetFocusedRowCellDisplayText(colMaThue).ToString();
        }

        private void btnHuyThem_Click(object sender, EventArgs e)
        {
            btnHuy_ItemClick(null,null);
        }
    }
}