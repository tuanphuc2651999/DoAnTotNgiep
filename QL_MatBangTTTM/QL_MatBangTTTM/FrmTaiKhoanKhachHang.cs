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
using Model;
using BLL;
using DAL;
using Liz.DoAn;
using DevExpress.XtraSplashScreen;
using System.Text.RegularExpressions;

namespace QL_MatBangTTTM
{
    public partial class FrmTaiKhoanKhachHang : DevExpress.XtraEditors.XtraForm
    {
        BLL_KhachHang khachHang = new BLL_KhachHang();
        public FrmTaiKhoanKhachHang()
        {
            InitializeComponent();
            GridLocalizer.Active = new MyGridLocalizer();
            cboMaKhachHang.BackColor = Color.White;
            cboTinhTrang.BackColor = Color.White;
            txtTK.BackColor = Color.White;
            txtMatKhau.BackColor = Color.White;
            cboMaKhachHang.BackColor = Color.White;
        }

        private void FrmTaiKhoanKhachHang_Load(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            cboMaKhachHang.Enabled = false;
            cboTinhTrang.Enabled = false;
            txtMatKhau.Enabled = true;
            txtEmail.Enabled = true;
            txtTK.Enabled = false;

            BindingList<TaiKhoanKHModel> bindingList = new BindingList<TaiKhoanKHModel>(khachHang.layDSTKKH());
            this.gCDSTaiKhoanKH.DataSource = bindingList;
            LayThongTinLenTextBox();
            GridLocalizer.Active = new MyGridLocalizer();
            cboMaKhachHang.Reset();
            LayTatCaKhachHangLenCbo();
        }

        #region Lấy thông tin

        // maping thông tin dưới dgv lên textbox
        private void LayThongTinLenTextBox()
        {
            txtTK.EditValue = dgvDSTaiKhoanKH.GetFocusedRowCellDisplayText(colTaiKhoan);
            txtMatKhau.EditValue = dgvDSTaiKhoanKH.GetFocusedRowCellDisplayText(colMatKhau);
            txtEmail.EditValue = dgvDSTaiKhoanKH.GetFocusedRowCellDisplayText(colEmail);
            cboTinhTrang.EditValue = dgvDSTaiKhoanKH.GetFocusedRowCellDisplayText(colTinhTrang);
            cboMaKhachHang.EditValue = dgvDSTaiKhoanKH.GetFocusedRowCellDisplayText(colMaKH);
        }

        // load combobox tất cả khách hàng
        private void LayTatCaKhachHangLenCbo()
        {
            cboMaKhachHang.Properties.DataSource = khachHang.layDSKhachHang();
        }

        // load combobox khách hàng không có tài khoản
        private void LayKhachHangKhongCoTaiKhoan()
        {
            cboMaKhachHang.Properties.DataSource = khachHang.layDSKHKhongCoTaiKhoan();
        }
        #endregion


        #region Kiểm tra thông tin 
        public static bool KiemTraDinhDangGmail(string inputEmail)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }
        #endregion

        private void btnThem_ItemClick(object sender, ItemClickEventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;

            dgvDSTaiKhoanKH.ClearSelection();

            Random random = new Random();
            //
            // làm mới text box và combobox thông tin
            txtTK.EditValue = "";
            txtEmail.EditValue = "";

            //Tạo mới mật khẩu với số bất kì
            txtMatKhau.EditValue = random.Next(999999).ToString();
            txtMatKhau.Enabled = false;

            cboTinhTrang.Text = "0";
            cboTinhTrang.Enabled = false;

            cboMaKhachHang.Enabled = true;
            cboMaKhachHang.Reset();
            LayKhachHangKhongCoTaiKhoan();
            cboMaKhachHang.EditValue = cboMaKhachHang.Properties.GetKeyValue(0);
            if (cboMaKhachHang.Properties.GetKeyValue(0) == null)
            {
                MessageBox.Show("Tất cả khách hàng đều có tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FrmTaiKhoanKhachHang_Load(null, null);
            }
        }

        private void btnLuu_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Kiểm tra thông tin nhập vào
            if (string.IsNullOrEmpty(txtTK.Text.ToString().Trim()))
            {
                MessageBox.Show("Tài khoản khách hàng không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTK.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(txtEmail.Text.ToString().Trim()))
            {
                MessageBox.Show("Email khách hàng không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return;
            }
            else if (KiemTraDinhDangGmail(txtEmail.Text.ToString().Trim()) != true)
            {
                MessageBox.Show("Email không được định dạng đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return;
            }
            else
            {
                SplashScreenManager.ShowForm(this, typeof(WaitLoadFrm));
                string sdt = txtTK.EditValue.ToString().Trim();
                string mk = txtMatKhau.EditValue.ToString().Trim();
                string email = txtEmail.EditValue.ToString().Trim();
                string maKH = cboMaKhachHang.EditValue.ToString().Trim();

                TaiKhoanKH tk = new TaiKhoanKH();
                tk.TaiKhoan = sdt;
                tk.MatKhau = mk;
                tk.Email = email;
                tk.TinhTrang = 0;
                tk.MaKhachHang = maKH;
                if (khachHang.ThemTKKhachHang(tk))
                {
                    try
                    {
                        GMail gMail = new GMail();
                        gMail.GuiEmailTaiKhoanKH(email, "Tên NV", sdt, mk);
                        SplashScreenManager.CloseDefaultSplashScreen();
                        MessageBox.Show("Tạo tài khoản cho mã khách hàng " + cboMaKhachHang.EditValue.ToString() +" thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FrmTaiKhoanKhachHang_Load(null, null);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Tạo tài khoản cho mã khách hàng " + cboMaKhachHang.EditValue.ToString() + " thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show("Không gửi được gmail cho khách hàng " + cboMaKhachHang.EditValue.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FrmTaiKhoanKhachHang_Load(null, null);
                        throw;
                    }
                    
                }
                else
                {
                    MessageBox.Show("Lỗi tạo tài khoản cho khách hàng " + cboMaKhachHang.EditValue.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SplashScreenManager.CloseDefaultSplashScreen();
                    FrmTaiKhoanKhachHang_Load(null, null);
                }
            }

        }

        private void btnSua_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                TaiKhoanKH tk = new TaiKhoanKH();
                tk.TaiKhoan = txtTK.EditValue.ToString().Trim();
                tk.MatKhau = txtMatKhau.EditValue.ToString().Trim();
                tk.Email = txtEmail.EditValue.ToString().Trim();
                tk.MaKhachHang = cboMaKhachHang.EditValue.ToString().Trim();
                tk.TinhTrang = Convert.ToInt32(cboTinhTrang.EditValue.ToString().Trim());
                if (khachHang.SuaTaiKhoanKhachHang(tk))
                {
                    MessageBox.Show("Sửa tài khoản thành công với mã khách hàng: " + cboMaKhachHang.EditValue.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmTaiKhoanKhachHang_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Sửa tài khoản không thành công với mã khách hàng: " + cboMaKhachHang.EditValue.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmTaiKhoanKhachHang_Load(null, null);
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                FrmTaiKhoanKhachHang_Load(null, null);
            }
        }

        private void dgvDSTaiKhoanKH_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LayTatCaKhachHangLenCbo();
            LayThongTinLenTextBox();
        }

        private void cboMaKhachHang_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                KhachHang kh = new KhachHang();
                kh = khachHang.LayTTKhachHang(cboMaKhachHang.EditValue.ToString());
                txtTK.EditValue = kh.SDT.ToString().Trim();
                txtEmail.EditValue = kh.Email.ToString().Trim();
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
        }

        private void btnXoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                DialogResult r = MessageBox.Show("Bạn có chắc muốn xóa tài khoản " + cboMaKhachHang.EditValue.ToString() + " không?", "Thông báo"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (r == DialogResult.Yes)
                {
                    //SplashScreenManager.ShowForm(this, typeof(WaitLoadFrm));
                    TaiKhoanKH tk = new TaiKhoanKH();
                    tk.TaiKhoan = txtTK.EditValue.ToString().Trim();
                    if (khachHang.XoaTaiKhoanKhachHang(tk))
                    {
                        MessageBox.Show("Xóa tài khoản khách hàng thành công" + cboMaKhachHang.EditValue.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FrmTaiKhoanKhachHang_Load(null, null);
                        //SplashScreenManager.CloseDefaultSplashScreen();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi tạo tài khoản cho khách hàng " + cboMaKhachHang.EditValue.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FrmTaiKhoanKhachHang_Load(null, null);
                        //SplashScreenManager.CloseDefaultSplashScreen();
                    }
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
        }
    }
}