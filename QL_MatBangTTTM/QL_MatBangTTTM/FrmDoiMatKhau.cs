using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BLL;
using DAL;

namespace QL_MatBangTTTM
{
    public partial class FrmDoiMatKhau : DevExpress.XtraEditors.XtraForm
    {
        BLL_PhanQuyen phanQuyen = new BLL_PhanQuyen();
        public FrmDoiMatKhau(string maTK)
        {
            InitializeComponent();
            txtTaiKhoan.Text = maTK;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            var tk = phanQuyen.KiemTraDangNhap(txtTaiKhoan.Text);
            if (string.IsNullOrEmpty(txtMatKhauCu.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu cũ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtMatKhauCu.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtMatKhauMoi.Text))
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtMatKhauMoi.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtXacNhanMK.Text))
            {
                MessageBox.Show("Bạn chưa nhập xác nhận mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtXacNhanMK.Focus();
                return;
            }
            if(txtMatKhauMoi.Text.Length<6||txtXacNhanMK.Text.Length<6)
            {
                MessageBox.Show("Mật khẩu phải có 6 kí tự trở lên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LamMoi();
                this.txtMatKhauMoi.Focus();
                return;
            } 
            if(!txtMatKhauMoi.Text.Equals(txtXacNhanMK.Text))
            {
                MessageBox.Show("Xác nhận mật khẩu không khớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LamMoi();
                this.txtMatKhauMoi.Focus();
                return;
            }
           if(!tk.MatKhau.Equals(txtMatKhauCu.Text))
            {
                MessageBox.Show("Mật khẩu cũ sai", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LamMoi();
                this.txtMatKhauCu.Focus();
                return;
            }
            TaiKhoanNV taiKhoanNV = new TaiKhoanNV();
            taiKhoanNV.TaiKhoan = txtTaiKhoan.Text;
            taiKhoanNV.MatKhau = txtMatKhauMoi.Text;
            taiKhoanNV.TinhTrang = 1;
           if(phanQuyen.SuaTaiKhoan(taiKhoanNV))
            {
                MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }    
           
        }
        public void LamMoi()
        {
            txtMatKhauCu.Text = "";
            txtMatKhauMoi.Text = "";
            txtXacNhanMK.Text = "";
        }

        private void txtMatKhauCu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar)&& !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(txtMatKhauCu, "Chỉ được nhập số và chữ");
            }
            else
            {
                errorProvider1.Clear();
            }    
                
        }

        private void txtMatKhauMoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtMatKhauCu.Text.Length == 0)
            {
                MessageBox.Show("Hãy nhập mật khẩu cũ trước", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LamMoi();
                this.txtMatKhauCu.Focus();
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(txtMatKhauMoi, "Chỉ được nhập số và chữ");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtXacNhanMK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(txtMatKhauMoi.Text.Length==0)
            {
                MessageBox.Show("Hãy nhập mật khẩu mới trước", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LamMoi();
                this.txtMatKhauMoi.Focus();
                e.Handled = true;
                return;
            }    
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(txtXacNhanMK, "Chỉ được nhập số và chữ");
            }
            else
            {
                errorProvider1.Clear();
            }
        }
    }
}