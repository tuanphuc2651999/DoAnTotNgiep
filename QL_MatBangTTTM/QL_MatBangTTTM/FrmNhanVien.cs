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
using Model;
using DevExpress.XtraGrid.Localization;
using System.IO;
using Liz.DoAn;
using System.Drawing.Imaging;
using DevExpress.XtraEditors;
using DAL;

namespace QL_MatBangTTTM
{
    public partial class FrmNhanVien : DevExpress.XtraEditors.XtraForm
    {
        BLL_NhanVien nhanVien = new BLL_NhanVien();
        string tenHinh;
        string pathHinh;
        bool check = true;
        bool checkimg = true;
        Image img;
        int rowselect=0;
        public FrmNhanVien(string maNV)
        {
            InitializeComponent();
        }
        private void TaoMoi()
        {
            txtMaNhanVien.EditValue = "";
            txtTenNV.EditValue = "";
            dENgayVL.EditValue=DateTime.Now;
            txtSDT.EditValue = "";
            txtCMND.EditValue = "";
            txtEmail.EditValue = "";
            txtDiaChi.EditValue = "";
            cboChucVu.EditValue = "";
            pENhanVien.Image = null;
            choNhapTextBox(false);
        }

        public void choNhapTextBox(bool trangThai)
        {          
            txtTenNV.ReadOnly = trangThai;
            dENgayVL.ReadOnly = trangThai;
            txtSDT.ReadOnly = trangThai;
            txtCMND.ReadOnly = trangThai;
            txtEmail.ReadOnly = trangThai;
            txtDiaChi.ReadOnly = trangThai;
            cboChucVu.ReadOnly = trangThai;
            cboGioiTinh.ReadOnly = trangThai;
        }
        public void LoadNV()
        {
            BindingList<NhanVienModel> bindingList = new BindingList<NhanVienModel>(nhanVien.layDSNhanVien());
            this.gcDSNhanVien.DataSource = bindingList;
        }
        public void LoadChucVu()
        {
            cboChucVu.Properties.DataSource= nhanVien.LoadChuVu();
            cboChucVu.Properties.DisplayMember = "TenChucVu";
            cboChucVu.Properties.ValueMember = "MaChucVu";
        }      
        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            LoadChucVu();
            LoadNV();
            GridLocalizer.Active = new MyGridLocalizer();
        }

        private void btnTaiLen_Click(object sender, EventArgs e)
        {
            try
            {
                openFile.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files (*.*)|*.*";

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    pathHinh = openFile.FileName;
                    img = Image.FromFile(pathHinh);
                    pENhanVien.Image = img;
                    dgvDSNhanVien.SetRowCellValue(dgvDSNhanVien.FocusedRowHandle, colHinhAnh, txtMaNhanVien.Text + ".PNG");
                    checkimg = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hãy chọn hình ảnh");
            }
        }
        private void dgvDSNhanVien_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if(dgvDSNhanVien.FocusedRowHandle>=0 && btnThem.Visibility == DevExpress.XtraBars.BarItemVisibility.Always)
            {
                LayThongTinLenTextBox();
                string DuongDanHinh = dgvDSNhanVien.GetFocusedRowCellDisplayText("DuongDanHinh");
                pathHinh = FileUtils.FolderUploads + "\\" + DuongDanHinh;
                if (!string.IsNullOrEmpty(pathHinh))
                {
                    if (File.Exists(pathHinh))
                    {                       
                        pENhanVien.Image = FileUtils.StringToImage(pathHinh);
                    }
                    else
                    {
                        pENhanVien.Image = null;
                    }
                   
                }
            }  
        }

        private void btnLuu_ItemClick(object sender, ItemClickEventArgs e)
        {
            rowselect = dgvDSNhanVien.FocusedRowHandle;
            DateTime ngayVL = Commons.ConvertStringToDate(dENgayVL.Text.ToString().Substring(0,10));
            DateTime ngaySinh = Commons.ConvertStringToDate(dENgaySinh.Text.ToString().Substring(0, 10));
            string maNV = txtMaNhanVien.EditValue.ToString();
            string tenNV = Commons.FormatHoTen(txtTenNV.EditValue.ToString());
            string diaChi = txtDiaChi.EditValue.ToString();
            string gioiTinh = cboGioiTinh.EditValue.ToString();
            string sdt = txtSDT.EditValue.ToString();
            string cmnd = txtCMND.EditValue.ToString();
            string email = txtEmail.EditValue.ToString();
            string duongDanHinh = dgvDSNhanVien.GetFocusedRowCellDisplayText(colHinhAnh) ;
            if (string.IsNullOrEmpty(txtTenNV.Text.ToString()))
            {
                MessageBox.Show("Tên nhân viên không thể để trống ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(txtTenNV, "Tên không được để trống");
                txtTenNV.Focus();
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
            if (string.IsNullOrEmpty(cboChucVu.Text))
            {
                MessageBox.Show("Bạn hãy chọn chức vụ cho nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(cboChucVu, "Chưa chọn chức vụ");
                cboChucVu.Focus();
                return;
            }
           
            if (nhanVien.KiemTraNgayVL(ngayVL))
            {
                MessageBox.Show("Ngày vào làm không thể lớn hơn ngày hiện tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(dENgayVL, "Ngày vào làm không thể lớn hơn ngày hiện tại");
                dENgayVL.Focus();
                return;
            }
            if (nhanVien.KiemTraSDT(sdt,maNV))
            {
                MessageBox.Show("Số điện thoại này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(txtSDT, "Số điện thoại đã có người sử dụng");
                txtSDT.Focus();
                return;
            }
            if (!nhanVien.KiemTraEmailHopLe(txtEmail.Text.ToString()))
            {
                MessageBox.Show("Email không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return;
            }
            if (nhanVien.KiemTraEmail(email, maNV))
            {
                MessageBox.Show("Email này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(txtEmail, "Email này đã tồn tại");
                txtEmail.Focus();
                return;
            }
            if (nhanVien.KiemTraCMND(cmnd, maNV))
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
            NhanVienModel nv = new NhanVienModel();
            nv.MaNV = maNV;
            nv.HoTenNV = tenNV;
            nv.DiaChi = diaChi;
            nv.GioiTinh = gioiTinh;
            nv.NgaySinh = ngaySinh;
            nv.NgayVL = ngayVL;
            nv.SDT = sdt;
            nv.CMND = cmnd;
            nv.Email = email;
            nv.TinhTrang = 1;
            nv.DuongDanHinh = duongDanHinh;
            nv.ChucVu = cboChucVu.EditValue.ToString();
            if (check)
            {           
                if (!nhanVien.ThemNhanVien(nv))
                {
                    MessageBox.Show("Thêm nhân viên lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if(checkTaoTK.Checked)
                     {
                        Random random = new Random();
                        string mk = random.Next(999999).ToString();
                        TaiKhoanNV tk = new TaiKhoanNV();
                        tk.TaiKhoan = maNV;
                        tk.MatKhau = mk;
                        tk.Email = email;
                        tk.TinhTrang = 0;
                        if (nhanVien.ThemTKNhanVien(tk))
                        {
                            GMail gMail = new GMail();
                            gMail.GuiEmailTaiKhoan(email, tenNV, maNV, mk);
                        }
                    }
                                         
                    MessageBox.Show("Thêm nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Click_BtnLuu();
                }    
               
               
            }    
            else
            {
                if(!nhanVien.SuaNhanVien(nv))
                {
                    MessageBox.Show("Sửa nhân viên lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }    
                else
                {
                    Click_BtnLuu();
                    MessageBox.Show("Sửa nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }    

            }
            if (!string.IsNullOrEmpty(duongDanHinh)&& !checkimg)
            {
                FileUtils.SaveFile(pathHinh, duongDanHinh, pENhanVien);
            }
            LoadNV();
            //dgvDSNhanVien_FocusedRowChanged(null, null);
            dgvDSNhanVien.FocusedRowHandle= rowselect;  
        }
        private void Click_BtnThem()
        {
            btnThem.Visibility= DevExpress.XtraBars.BarItemVisibility.Never;
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnHuy.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnLuuNV.Visible = true;
            btnNhapLai.Visible = true;
            btnTaiLen.Visible = true;
            btnHuyThem.Visible = true;
            check = true;
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
            btnTaiLen.Visible = true;
            btnHuyThem.Visible = true;
            check = false;
            choNhapTextBox(false);
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
            btnTaiLen.Visible = false;
            btnHuyThem.Visible = false;
            choNhapTextBox(true);
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
            btnTaiLen.Visible = false;
            btnHuyThem.Visible = false;
            choNhapTextBox(true);
            LayThongTinLenTextBox();
        }

        private void btnThem_ItemClick(object sender, ItemClickEventArgs e)
        {
           TaoMoi();
           txtMaNhanVien.EditValue= nhanVien.LayMaNVTuSinh();
            Click_BtnThem();
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
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(txtCMND, "Chứng minh nhân dân không được nhập chữ");
            }
        }

        private void btnXoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            int row = dgvDSNhanVien.FocusedRowHandle;
            if(row>=0)
            {
                DialogResult r = MessageBox.Show("Bạn có chắc muốn xóa nhân viên "+dgvDSNhanVien.GetFocusedRowCellValue(colMaNV)+" không?","Thông báo"
                    ,MessageBoxButtons.YesNo,MessageBoxIcon.Error);
                if(r==DialogResult.Yes)
                {
                    if(nhanVien.XoaNhanVien(dgvDSNhanVien.GetFocusedRowCellValue(colMaNV).ToString()))
                    {
                        MessageBox.Show("Xóa thành công nhân viên " + dgvDSNhanVien.GetFocusedRowCellValue(colMaNV), "Thông báo"
                                                , MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadNV();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa nhân viên " + dgvDSNhanVien.GetFocusedRowCellValue(colMaNV), "Thông báo"
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
     public void LayThongTinLenTextBox()
        {
            txtMaNhanVien.EditValue = dgvDSNhanVien.GetFocusedRowCellDisplayText(colMaNV);
            dENgayVL.EditValue = dgvDSNhanVien.GetFocusedRowCellDisplayText(colNgayVL);
            txtDiaChi.EditValue = dgvDSNhanVien.GetFocusedRowCellDisplayText(colDiaChi);
            cboGioiTinh.EditValue = dgvDSNhanVien.GetFocusedRowCellDisplayText(colGioiTinh);
            dENgaySinh.EditValue = dgvDSNhanVien.GetFocusedRowCellDisplayText(colNgaySinh);
            txtSDT.EditValue = dgvDSNhanVien.GetFocusedRowCellDisplayText(colSDT);
            txtCMND.EditValue = dgvDSNhanVien.GetFocusedRowCellDisplayText(colCMND);
            txtEmail.EditValue = dgvDSNhanVien.GetFocusedRowCellDisplayText(colEmail);
            cboChucVu.EditValue= dgvDSNhanVien.GetFocusedRowCellDisplayText(colMaChuVu);
            txtTenNV.EditValue= dgvDSNhanVien.GetFocusedRowCellDisplayText(colTenNV);
        }

       



        private void txtTenNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.Clear();
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar)&&!char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(txtTenNV, "Kí tự không hợp lệ");
            }
           
        }
        private void txtNhapLai_Click(object sender, EventArgs e)
        {
            TaoMoi();
            txtTenNV.Focus();
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.Clear();
        }

        private void cboChucVu_EditValueChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void txtDiaChi_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.Clear();
        }

        private void dENgayVL_EditValueChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        } 

        private void cboGioiTinh_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void dENgaySinh_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void btnLuuNV_Click(object sender, EventArgs e)
        {
            btnLuu_ItemClick(null,null);
        }

        private void dENgaySinh_EditValueChanged(object sender, EventArgs e)
        {
            DateTime ngayHienTai = Commons.ConvertStringToDate(DateTime.Now.ToString("dd/MM/yyyy"));
            DateTime ngaySinh = Commons.ConvertStringToDate(dENgaySinh.Text.ToString().Substring(0, 10));
            if (!nhanVien.KiemTraNgaySinh(ngaySinh, ngayHienTai))
            {
                MessageBox.Show("Ngày sinh không hợp lệ, nhân viên phải đủ 18 tuổi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dENgaySinh.EditValue = dgvDSNhanVien.GetFocusedRowCellValue(colNgaySinh);
                dENgaySinh.Focus();
                return;
            }
        }

        private void btnSua_ItemClick(object sender, ItemClickEventArgs e)
        {
            Click_BtnSua();
        }

        private void btnHuy_ItemClick(object sender, ItemClickEventArgs e)
        {
            Click_BtnHuy();          
        }

        private void btnHuyThem_Click(object sender, EventArgs e)
        {
            Click_BtnHuy();
        }
    }
}