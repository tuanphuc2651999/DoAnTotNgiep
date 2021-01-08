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
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraGrid.Views.Grid;
using Model;
using Liz.DoAn;
using System.IO;
using DevExpress.XtraSplashScreen;

namespace QL_MatBangTTTM
{
    public partial class FrmKhachHang : DevExpress.XtraEditors.XtraForm
    {
        BLL_KhachHang khachHang = new BLL_KhachHang();

        List<int> listViTriSua;
        List<int> listViTriThem;
        bool check = true;
        bool checkimg = true;
        int dem = 0;
        string pathHinh;
        int rowselect = 0;
        public FrmKhachHang(string maNV)
        {
            InitializeComponent();
            listViTriSua = new List<int>();
            listViTriThem = new List<int>();
        }
        public void choNhapTextBox(bool trangThai)
        {
            txtTenKH.ReadOnly = trangThai;
            dENgaySinh.ReadOnly = trangThai;
            txtSDT.ReadOnly = trangThai;
            txtCMND.ReadOnly = trangThai;
            txtEmail.ReadOnly = trangThai;
            txtDiaChi.ReadOnly = trangThai;            
            cboGioiTinh.ReadOnly = trangThai;
        }
        #region BTN
        private void Click_BtnThem()
        {
            btnThemKH.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnXoaKH.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSuaKH.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnLuuKH.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnHuy.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnLuuNV.Visible = true;
            btnNhapLai.Visible = true;
            btnTaiLen.Visible = true;
            btnHuyThem.Visible = true;
            check = true;
            label2.Visible = true;
            checkTaoTK.Visible = true;
        }
        private void Click_BtnSua()
        {
            btnThemKH.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnXoaKH.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSuaKH.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnLuuKH.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnHuy.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnLuuNV.Visible = true;
            btnNhapLai.Visible = true;
            btnTaiLen.Visible = true;
            btnHuyThem.Visible = true;
            check = false;
            choNhapTextBox(false);
            label2.Visible = false;
            checkTaoTK.Visible = false;
        }
        private void Click_BtnLuu()
        {
            btnThemKH.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnXoaKH.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnSuaKH.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnLuuKH.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnHuy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnLuuNV.Visible = false;
            btnNhapLai.Visible = false;
            btnTaiLen.Visible = false;
            btnHuyThem.Visible = false;
            choNhapTextBox(true);
        }
        private void Click_BtnHuy()
        {
            btnThemKH.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnXoaKH.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnSuaKH.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnLuuKH.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnHuy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnLuuNV.Visible = false;
            btnNhapLai.Visible = false;
            btnTaiLen.Visible = false;
            btnHuyThem.Visible = false;
            choNhapTextBox(true);
            label2.Visible = false;
            checkTaoTK.Visible = false;
        }
        #endregion
        #region LayThongTin
        public void LayThongTinLenTextBox()
        {
            txtMaKH.EditValue = dgvDSKhachHang.GetFocusedRowCellDisplayText(colMaKH);
            dENgaySinh.EditValue = dgvDSKhachHang.GetFocusedRowCellDisplayText(colNgaySinh);
            txtDiaChi.EditValue = dgvDSKhachHang.GetFocusedRowCellDisplayText(colDiaChi);
            cboGioiTinh.EditValue = dgvDSKhachHang.GetFocusedRowCellDisplayText(colGioiTinh);
            dENgaySinh.EditValue = dgvDSKhachHang.GetFocusedRowCellDisplayText(colNgaySinh);
            txtSDT.EditValue = dgvDSKhachHang.GetFocusedRowCellDisplayText(colSDT);
            txtCMND.EditValue = dgvDSKhachHang.GetFocusedRowCellDisplayText(colCMND);
            txtEmail.EditValue = dgvDSKhachHang.GetFocusedRowCellDisplayText(colEmail);
            txtTenKH.EditValue = dgvDSKhachHang.GetFocusedRowCellDisplayText(colTenKH);
        }
        public void LayDSKhachHang() {
            BindingList<KhachHangModel> bindingList = new BindingList<KhachHangModel>(khachHang.layDSKhachHang());
            this.gcDSKhachHang.DataSource = bindingList;
            LayThongTinLenTextBox();
        }

        #endregion
        private void TaoMoi()
        {
            txtMaKH.EditValue = "";
            txtTenKH.EditValue = "";
            dENgaySinh.EditValue=Commons.ConvertStringToDate("01/01/1990");
            txtSDT.EditValue = "";
            txtCMND.EditValue = "";
            txtEmail.EditValue = "";
            txtDiaChi.EditValue = "";
            pEHinh.Image = null;
            choNhapTextBox(false);           
        }

       
        private void FrmKhachHang_Load(object sender, EventArgs e)
        {
            LayDSKhachHang();           
            GridLocalizer.Active = new MyGridLocalizer();
        }       
        //Sự kiện 
        private void btnThemKH_ItemClick(object sender, ItemClickEventArgs e)
        {
            //dgvDSKhachHang.AddNewRow();
            TaoMoi();
            txtTenKH.Focus();
            txtMaKH.EditValue = khachHang.layMaKHTuSinh();
            Click_BtnThem();
        }

        private void btnLuuKH_ItemClick(object sender, ItemClickEventArgs e)
        {
            rowselect = dgvDSKhachHang.FocusedRowHandle;
            DateTime ngayHienTai = Commons.ConvertStringToDate(DateTime.Now.ToString("dd/MM/yyyy"));            
            DateTime ngaySinh = Commons.ConvertStringToDate(dENgaySinh.Text.ToString().Substring(0, 10));
            TimeSpan ngay = ngayHienTai.Subtract(ngaySinh);
            string maKH = txtMaKH.EditValue.ToString();
            string tenNV = Commons.FormatHoTen(txtTenKH.EditValue.ToString());
            string diaChi = txtDiaChi.EditValue.ToString();
            string gioiTinh = cboGioiTinh.EditValue.ToString();
            string sdt = txtSDT.EditValue.ToString();
            string cmnd = txtCMND.EditValue.ToString();
            string email = txtEmail.EditValue.ToString();
            string duongDanHinh = "";
            if (string.IsNullOrEmpty(txtTenKH.Text.ToString()))
            {
                MessageBox.Show("Tên khách hàng không thể để trống ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(txtTenKH, "Tên khách hàng không được để trống");
                txtTenKH.Focus();
                return;
            }
            if (!(ngay.Days >= 6570))
            {
                MessageBox.Show("Ngày sinh không hợp lệ, khách hàng phải đủ 18 tuổi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dENgaySinh.EditValue = Commons.ConvertStringToDate("01/01/1990");
                dENgaySinh.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtSDT.Text.ToString()))
            {
                MessageBox.Show("Số điện thoại không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(txtSDT, "Số điện thoại không được để trống");
                txtSDT.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtEmail.Text.ToString()))
            {
                MessageBox.Show("Email không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(txtEmail, "Email không được để trống");
                txtEmail.Focus();
                return;
            }
            if (khachHang.KiemTraSDT(sdt, maKH))
            {
                MessageBox.Show("Số điện thoại này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(txtSDT, "Số điện thoại đã có người sử dụng");
                txtSDT.Focus();
                return;
            }
            if (!Commons.KiemTraEmailHopLe(txtEmail.Text.ToString()))
            {
                MessageBox.Show("Email không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return;
            }
            if (khachHang.KiemTraEmail(email, maKH))
            {
                MessageBox.Show("Email này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(txtEmail, "Email này đã tồn tại");
                txtEmail.Focus();
                return;
            }
            if (khachHang.KiemTraCMND(cmnd, maKH))
            {
                MessageBox.Show("Chứng minh nhân đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(txtCMND, "Chứng minh nhân đã tồn tại");
                txtCMND.Focus();
                return;
            }
            if (string.IsNullOrEmpty(diaChi))
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(txtDiaChi, "Bạn chưa nhập địa chỉ");
                txtDiaChi.Focus();
                return;
            }
            KhachHangModel nv = new KhachHangModel();
            nv.MaKH = maKH;
            nv.HoTenKH = tenNV;
            nv.DiaChi = diaChi;
            nv.GioiTinh = gioiTinh;
            nv.NgaySinh = ngaySinh;
            nv.SDT = sdt;
            nv.CMND = cmnd;
            nv.Email = email;
            nv.TinhTrang = 1;
            if(!string.IsNullOrEmpty(duongDanHinh))
            {
                nv.DuongDanHinh = duongDanHinh;
            }          
                     
            if (check)
            {              
                if (!khachHang.themKhachHang(nv))
                {
                    MessageBox.Show("Thêm khách hàng lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    SplashScreenManager.ShowForm(this, typeof(WaitLoadFrm));
                    if (checkTaoTK.Checked)
                    {     
                    Random random = new Random();
                    string mk = random.Next(999999).ToString();
                    TaiKhoanKH tk = new TaiKhoanKH();
                    tk.TaiKhoan = sdt;
                    tk.MatKhau = mk;
                    tk.Email = email;
                    tk.TinhTrang = 0;
                    tk.MaKhachHang = maKH;
                    if (khachHang.ThemTKKhachHang(tk))
                    {
                        GMail gMail = new GMail();
                        gMail.GuiEmailTaiKhoanKH(email, tenNV, sdt, mk);
                            SplashScreenManager.CloseDefaultSplashScreen();
                    }
                    else
                    {
                            MessageBox.Show("Lỗi tạo tài khoản cho khách hàng " + txtMaKH.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }    
                    }
                   
                    MessageBox.Show("Thêm khách hàng "+txtMaKH.Text +" thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Click_BtnLuu();
                }


            }
            else
            {
                if (!khachHang.suaKhachHang(nv))
                {
                    MessageBox.Show("Sửa khách hàng "+txtMaKH.Text+" lỗi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    Click_BtnLuu();
                    MessageBox.Show("Sửa khách hàng " + txtMaKH.Text + " thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            if (!string.IsNullOrEmpty(duongDanHinh) && !checkimg)
            {
                FileUtils.SaveFile(pathHinh, duongDanHinh, pEHinh);
            }
            LayDSKhachHang();           
            dgvDSKhachHang.FocusedRowHandle = rowselect;            
        }
        private void btnTaiLen_Click(object sender, EventArgs e)
        {
            try
            {
                openFile.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files (*.*)|*.*";

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    pathHinh = openFile.FileName;
                    Image img = Image.FromFile(pathHinh);
                    pEHinh.Image = img;
                    dgvDSKhachHang.SetRowCellValue(dgvDSKhachHang.FocusedRowHandle, colHinh, txtMaKH.Text + ".PNG");
                    checkimg = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hãy chọn hình ảnh");
            }
        }

        private void dgvDSKhachHang_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (dgvDSKhachHang.FocusedRowHandle >= 0 && btnThemKH.Visibility == DevExpress.XtraBars.BarItemVisibility.Always)
            {
                LayThongTinLenTextBox();
                string DuongDanHinh = dgvDSKhachHang.GetFocusedRowCellDisplayText("DuongDanHinh");
                pathHinh = FileUtils.FolderUploads + "\\" + DuongDanHinh;
                if (!string.IsNullOrEmpty(pathHinh))
                {
                    if (File.Exists(pathHinh))
                    {
                        pEHinh.Image = FileUtils.StringToImage(pathHinh);
                    }
                    else
                    {
                        pEHinh.Image = null;
                    }

                }
            }
        }

        private void btnSuaKH_ItemClick(object sender, ItemClickEventArgs e)
        {
            Click_BtnSua();
        }

        private void btnHuy_ItemClick(object sender, ItemClickEventArgs e)
        {
            Click_BtnHuy();
            dgvDSKhachHang_FocusedRowChanged(null,null);
            dgvDSKhachHang.Focus();
        }

        private void btnHuyThem_Click(object sender, EventArgs e)
        {
            Click_BtnHuy();
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            TaoMoi();
        }

        private void btnXoaKH_ItemClick(object sender, ItemClickEventArgs e)
        {
            int row = dgvDSKhachHang.FocusedRowHandle;
            if (row >= 0)
            {
                DialogResult r = MessageBox.Show("Bạn có chắc muốn xóa khách hàng " + dgvDSKhachHang.GetFocusedRowCellValue(colMaKH) + " không?", "Thông báo"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (r == DialogResult.Yes)
                {
                    if (khachHang.XoaKhachHang(dgvDSKhachHang.GetFocusedRowCellValue(colMaKH).ToString()))
                    {
                        MessageBox.Show("Xóa thành công nhân viên " + dgvDSKhachHang.GetFocusedRowCellValue(colMaKH), "Thông báo"
                                                , MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LayDSKhachHang();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa nhân viên " + dgvDSKhachHang.GetFocusedRowCellValue(colMaKH), "Thông báo"
                                                                       , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn nhân viên để xóa", "Thông báo"
                         , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvDSKhachHang_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;
            var row = dgvDSKhachHang.FocusedRowHandle;
            var focusRow = dgvDSKhachHang.GetFocusedRow();
            if (focusRow == null)
                return;
            if (row >= 0 && btnThemKH.Visibility == DevExpress.XtraBars.BarItemVisibility.Always)
            {
                popupMenu1.ShowPopup(barManager1, new Point(MousePosition.X, MousePosition.Y));

            }
            else
                popupMenu1.HidePopup();

        }
        #region KeyPress
        private void txtTenKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.Clear();
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(txtTenKH, "Kí tự không hợp lệ");
            }
        }
        #endregion

        private void dENgaySinh_EditValueChanged(object sender, EventArgs e)
        {
           /* DateTime ngayHienTai = Commons.ConvertStringToDate(DateTime.Now.ToString("dd/MM/yyyy"));
            DateTime ngaySinh = Commons.ConvertStringToDate(dENgaySinh.Text.ToString().Substring(0, 10));
            TimeSpan ngay = ngayHienTai.Subtract(ngaySinh);
            if (!(ngay.Days >= 6570))
            {
                MessageBox.Show("Ngày sinh không hợp lệ, khách hàng phải đủ 18 tuổi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dENgaySinh.EditValue = dgvDSKhachHang.GetFocusedRowCellValue(colNgaySinh);
                dENgaySinh.Focus();
                return;
            }*/
        }

        private void dENgaySinh_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.Clear();
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(txtSDT, "Số điện thoại không được nhập chữ");
            }
        }

        private void txtCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.Clear();
        }

        private void btnLuuNV_Click(object sender, EventArgs e)
        {
            btnLuuKH_ItemClick(null,null);
        }
    }
}