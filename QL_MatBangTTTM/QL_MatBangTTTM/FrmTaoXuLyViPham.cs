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
using Liz.DoAn;

namespace QL_MatBangTTTM
{
    public partial class FrmTaoXuLyViPham : DevExpress.XtraEditors.XtraForm
    {
        BLL_XuLyViPham vp = new BLL_XuLyViPham();
        string maNV;
        string maTMB;
        string maVP;
        public FrmTaoXuLyViPham(string maNV,string maTMB)
        {
            InitializeComponent();
            this.maNV = maNV;
            this.maTMB = maTMB;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtViPham.EditValue == null)
            {
                MessageBox.Show("Vi phạm không hợp lê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(txtViPham, "Hãy chọn lại vi phạm");
                txtViPham.Focus();
                return;
            }            
            HoSoViPham hs = new HoSoViPham();
            hs.MaHSViPham = txtMaHS.Text;
            hs.NgayLap = Commons.ConvertStringToDate(txtNgayLap.Text);
            hs.TinhTrang = 0;
            if (txtTongTien.Text.Length > 0)
            {
                hs.TongTienPhat = int.Parse(txtTongTien.Text);
            }
            else
                hs.TongTienPhat = 0;
            hs.GhiChu = txtGhichu.Text;
            hs.MaViPham = txtViPham.EditValue.ToString();
            hs.MaThueMB = maTMB;
            hs.MaNhanVien = maNV;
            if (vp.ThemHSViPham(hs))
            {
                MessageBox.Show("Thêm vi phạm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                maVP = txtMaHS.EditValue.ToString();
                this.Close();
            }    
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txtMaHS.Text = vp.LayMaXuLyTuSinh();
            txtViPham.EditValue = null;
            txtGhichu.Text = "";
            txtTongTien.Text = "";
            txtMaNV.Text = maNV;
            txtNgayLap.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtTinhTrang.Text = "Chưa đóng";
        }

        private void FrmTaoXuLyViPham_Load(object sender, EventArgs e)
        {
            txtMaHS.Text = vp.LayMaXuLyTuSinh();
            txtViPham.Properties.DataSource = vp.LayDSViPhamChamDutHD();
            txtMaNV.Text = maNV;
            txtNgayLap.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtTinhTrang.Text = "Chưa đóng";

        }

        private void txtTongTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.Clear();
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(txtTongTien, "Tiền phạt chỉ cho nhập số");
            }
        }

        private void txtTongTien_EditValueChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }
        public string MaViPham()
        {
            return maVP;
        }
    }
}