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
using DevExpress.XtraGrid.Localization;
using BLL;
using Model;
using DAL;
using Liz.DoAn;
using DevExpress.XtraSplashScreen;

namespace QL_MatBangTTTM
{
    public partial class FrmTaiKhoanNV : DevExpress.XtraEditors.XtraForm
    {
        BLL_NhanVien nhanVien = new BLL_NhanVien();
        public FrmTaiKhoanNV(string maNV)
        {
            InitializeComponent();
            GridLocalizer.Active = new MyGridLocalizer();
        }
        private void Databingding(BindingList<TaiKhoanNVModel> kh)
        {
           /* txtMaKH.DataBindings.Add("text", kh, "MaKH");
            txtTenKH.DataBindings.Add("text", kh, "HoTenKH");
            txtCMND.DataBindings.Add("text", kh, "CMND");
            txtDiaChi.DataBindings.Add("text", kh, "DiaChi");
            txtSDT.DataBindings.Add("text", kh, "SDT");
            cboGioiTinh.DataBindings.Add("text", kh, "GioiTinh");
            cboTrangThai.DataBindings.Add("text", kh, "TinhTrangAsString");
            dENgaySinh.DataBindings.Add("datetime", kh, "ngaysinh");
            txtEmail.DataBindings.Add("text", kh, "Email");*/
        }
        private void FrmTaiKhoanNV_Load(object sender, EventArgs e)
        {
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnHuy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            cboTaiKhoan.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtMatKhau.ReadOnly = false;
            cboTinhTrang.ReadOnly = true;

            BindingList<TaiKhoanNVModel> bindingList = new BindingList<TaiKhoanNVModel>(nhanVien.layDSTKNV());
            this.gCDSTaiKhoanNV.DataSource = bindingList;
            LayThongTinLenTextBox();
            LayTatCaNhanVienLenCbo();
            GridLocalizer.Active = new MyGridLocalizer();
        }
        #region Lấy thông tin
        private void LayThongTinLenTextBox()
        {
            cboTaiKhoan.EditValue = dgvDSTaiKhoanNV.GetFocusedRowCellDisplayText(colTaiKhoan);
            txtMatKhau.EditValue = dgvDSTaiKhoanNV.GetFocusedRowCellDisplayText(colMatKhau);
            txtEmail.EditValue = dgvDSTaiKhoanNV.GetFocusedRowCellDisplayText(colEmail);
            cboTinhTrang.EditValue = dgvDSTaiKhoanNV.GetFocusedRowCellDisplayText(colTinhTrang);
        }

        // load combobox tất cả nhân viên
        private void LayTatCaNhanVienLenCbo()
        {
            cboTaiKhoan.Properties.DataSource = nhanVien.layDSTatCaNhanVien();
        }

        // load combobox nhân viên không có tài khoản
        private void LayNhanVienKhongCoTaiKhoan()
        {
            cboTaiKhoan.Properties.DataSource = nhanVien.layDSNhanVienKhongCoTaiKhoan();
        }
        #endregion

        private void btnThem_ItemClick(object sender, ItemClickEventArgs e)
        {
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnHuy.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            Random random = new Random();
            //
            // làm mới text box và combobox thông tin
            txtEmail.EditValue = "";

            //Tạo mới mật khẩu với số bất kì
            
            txtMatKhau.ReadOnly = true;

            cboTinhTrang.Text = "0";
            cboTinhTrang.ReadOnly = true;

            cboTaiKhoan.ReadOnly = false;
            cboTaiKhoan.Reset();
     
            cboTaiKhoan.EditValue =  cboTaiKhoan.Properties.GetKeyValue(0);
            LayNhanVienKhongCoTaiKhoan();
            if (cboTaiKhoan.Properties.GetKeyValue(0) == null)
            {
                MessageBox.Show("Tất cả khách hàng đều có tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FrmTaiKhoanNV_Load(null, null);
            }

            txtMatKhau.EditValue = random.Next(999999).ToString();
        }

        private void btnXoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                DialogResult r = MessageBox.Show("Bạn có chắc muốn khóa tài khoản " + "MÃ NHÂN VIÊN" + " không?", "Thông báo"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (r == DialogResult.Yes)
                {
                    SplashScreenManager.ShowForm(this, typeof(WaitLoadFrm));
                    TaiKhoanNV nv = new TaiKhoanNV();
                    nv.TaiKhoan = cboTaiKhoan.EditValue.ToString().Trim();
                    if (nhanVien.XoaTaiKhoanNhanVien(nv.TaiKhoan))
                    {
                        MessageBox.Show("Khóa tài khoản khách hàng thành công" + cboTaiKhoan.EditValue.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FrmTaiKhoanNV_Load(null, null);
                        SplashScreenManager.CloseDefaultSplashScreen();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi tạo tài khoản cho khách hàng " + cboTaiKhoan.EditValue.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FrmTaiKhoanNV_Load(null, null);
                        SplashScreenManager.CloseDefaultSplashScreen();
                    }
                }

            }
            catch (Exception)
            {
                FrmTaiKhoanNV_Load(null, null);
                throw;
            }
        }

        private void btnSua_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                TaiKhoanNV nv = new TaiKhoanNV();
                nv.TaiKhoan = cboTaiKhoan.EditValue.ToString().Trim();
                nv.MatKhau = txtMatKhau.EditValue.ToString().Trim();
                nv.Email = txtEmail.EditValue.ToString().Trim();
                nv.TinhTrang = nhanVien.LayTinhTrangTaiKhoanNV(nv.TaiKhoan);
                if (nhanVien.SuaTKNhanVien(nv))
                {
                    MessageBox.Show("Sửa tài khoản thành công với mã nhân viên: " + cboTaiKhoan.EditValue.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmTaiKhoanNV_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Sửa tài khoản không thành công với mã nhân viên: " + cboTaiKhoan.EditValue.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmTaiKhoanNV_Load(null, null);
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                MessageBox.Show("Sửa tài khoản ádfasdfasdfa không thành công với mã nhân viên: " + cboTaiKhoan.EditValue.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmTaiKhoanNV_Load(null, null);
            }
        }

        private void btnLuu_ItemClick(object sender, ItemClickEventArgs e)
        {

            // Kiểm tra thông tin nhập vào
            if (string.IsNullOrEmpty(txtEmail.Text.ToString().Trim()))
            {
                MessageBox.Show("Email nhân viên không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(txtMatKhau.Text.ToString().Trim()))
            {
                MessageBox.Show("Mật khẩu khách hàng không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhau.Focus();
                return;
            }
            else if (Commons.KiemTraEmailHopLe(txtEmail.Text.ToString().Trim()) != true)
            {
                MessageBox.Show("Email không được định dạng đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return;
            }
            else
            {
                SplashScreenManager.ShowForm(this, typeof(WaitLoadFrm));
                string taikhoan = cboTaiKhoan.EditValue.ToString().Trim();
                string matkhau = txtMatKhau.EditValue.ToString().Trim();
                string email = txtEmail.EditValue.ToString().Trim();

                TaiKhoanNV nv = new TaiKhoanNV();
                nv.TaiKhoan = taikhoan;
                nv.MatKhau = matkhau;
                nv.Email = email;
                nv.TinhTrang = 0;
                if (nhanVien.ThemTKNhanVien(nv))
                {
                    try
                    {
                        NhanVien nvv = new NhanVien();
                        nvv = nhanVien.LayTTNhanVien(taikhoan);
                        GMail gMail = new GMail();
                        gMail.GuiEmailTaiKhoan(email, nvv.HoTenNV, taikhoan, matkhau);
                        SplashScreenManager.CloseDefaultSplashScreen();
                        MessageBox.Show("Tạo tài khoản cho mã khách hàng " + cboTaiKhoan.EditValue.ToString() + " thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FrmTaiKhoanNV_Load(null, null);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Tạo tài khoản cho mã khách hàng " + cboTaiKhoan.EditValue.ToString() + " thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show("Không gửi được gmail cho khách hàng " + cboTaiKhoan.EditValue.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FrmTaiKhoanNV_Load(null, null);
                        throw;
                    }
                }
                else
                {
                    MessageBox.Show("Lỗi tạo tài khoản cho khách hàng " + cboTaiKhoan.EditValue.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SplashScreenManager.CloseDefaultSplashScreen();
                    FrmTaiKhoanNV_Load(null, null);
                }
            }
        }

        private void dgvDSTaiKhoanNV_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (dgvDSTaiKhoanNV.FocusedRowHandle >= 0 && btnThem.Visibility == DevExpress.XtraBars.BarItemVisibility.Always)
            {
                LayTatCaNhanVienLenCbo();
                LayThongTinLenTextBox();
            }
        }

        private void cboTaiKhoan_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                NhanVien nv = new NhanVien();
                nv = nhanVien.LayTTNhanVien(cboTaiKhoan.EditValue.ToString());
                //txtTK.EditValue = kh.SDT.ToString().Trim();
                txtEmail.EditValue = nv.Email.ToString().Trim();
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
        }

        private void btnHuy_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmTaiKhoanNV_Load(null, null);
        }
    }
}