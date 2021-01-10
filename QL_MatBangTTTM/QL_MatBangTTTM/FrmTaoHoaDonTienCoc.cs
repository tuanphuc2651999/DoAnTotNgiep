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
using Liz.DoAn;
using DAL;

namespace QL_MatBangTTTM
{
    public partial class FrmTaoHoaDonTienCoc : DevExpress.XtraEditors.XtraForm
    {
        BLL_ThueMatBang thueMB = new BLL_ThueMatBang();
        string maDK = "";
        string maMB = "";
        string maHD;
        public FrmTaoHoaDonTienCoc(string maDK,string maMB)
        {
            InitializeComponent();
            this.maDK = maDK;
            this.maMB = maMB;
        }

        private void FrmTaoHoaDonTienCoc_Load(object sender, EventArgs e)
        {
            txtMaHoaDon.Text = thueMB.LayMaHoaDonTuSinh();
            txtNgayLap.EditValue = DateTime.Now;
            txtNgayDong.EditValue = DateTime.Now;
            txtMatBang.EditValue = maMB;
            txtTienCoc.Text = String.Format("{0:0,0 vnđ}", thueMB.TinhTienCoc(txtMatBang.Text));
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            HoaDonTienCoc hd = new HoaDonTienCoc();
            hd.MaHD = txtMaHoaDon.Text;
            hd.NgayDong = (DateTime)txtNgayDong.EditValue;
            hd.NgayLap = (DateTime)txtNgayLap.EditValue;
            hd.SoTien = (int)thueMB.TinhTienCoc(txtMatBang.Text);
            hd.TrangThai = 1;
            hd.MaDK = maDK;
            if (thueMB.ThemHoaDon(hd))
            {
                MessageBox.Show("Thêm hóa đơn thành công");
                maHD = txtMaHoaDon.Text;
                this.Close();
            }                
        }

        private void txtNgayDong_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNgayDong.Text.ToString()))
            {              
                return;
            }
            string ngayHienTai = (DateTime.Now).ToString("dd/MM/yyyy");
            string ngaydong = ((DateTime)txtNgayDong.EditValue).ToString("dd/MM/yyyy");
            TimeSpan ngay = Commons.ConvertStringToDate(ngayHienTai).Subtract(Commons.ConvertStringToDate(ngaydong));

            if (ngay.Days < 0)
            {
                MessageBox.Show("Ngày đóng không thể lớn hơn ngày hiện tại");
                txtNgayDong.EditValue = Commons.ConvertStringToDate(ngayHienTai);
                txtNgayDong.Focus();
                return;
            }
        }
        public string MaHoaDon()
        {
            return maHD;
        }
    }
}