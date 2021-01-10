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
using QL_MatBangTTTM.Resource;
using DAL;

namespace QL_MatBangTTTM
{
    public partial class FrmTaoLichHen : DevExpress.XtraEditors.XtraForm
    {
        BLL_ThueMatBang thueMB = new BLL_ThueMatBang();
        string maHD;
        string maNV;
        string maDK;
        string maLichHen;
        public FrmTaoLichHen(string maNV, string maHD, string maDK)
        {
            InitializeComponent();
            txtGioBatDau.EditValue = DateTime.Parse("7:00 AM");
            txtMaLichHen.Text = thueMB.LayMaLichHenTuSinh();
            txtNgayHen.Focus();
            txtDiaChi.EditValue = QL_MatBang.DIACHI;
            txtNoiDung.EditValue= QL_MatBang.NOIDUNG;
            txtMaNV.EditValue = maNV;
            this.maHD = maHD;
            this.maNV = maNV;
            this.maDK = maDK;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(txtNgayHen.EditValue==null)
            {
                MessageBox.Show("Chưa chọn ngày hẹn");
                txtNgayHen.Focus();
                return;
            }    
            string gioDB = ((DateTime)txtGioBatDau.EditValue).ToString("HH:mm:ss");
            string gioKT = ((DateTime)txtGioKetThuc.EditValue).ToString("HH:mm:ss");
            string ngayHen = ((DateTime)txtNgayHen.EditValue).ToString("dd/MM/yyyy");
            LichHen lh = new LichHen();
            lh.MaLichHen = txtMaLichHen.Text;
            lh.NgayHen =Commons.ConvertStringToDate(ngayHen);
            lh.GioBatDau = TimeSpan.Parse(gioDB);
            lh.GioKetThuc = TimeSpan.Parse(gioKT);
            lh.DiaChi = txtDiaChi.Text;
            lh.NoiDung = txtNoiDung.Text;
            lh.MaNhanVien = txtMaNV.Text;
            lh.MaDK = maDK;
            lh.TinhTrang = 1;

            if (!thueMB.KiemTraLichHen(lh))
            {
                MessageBox.Show("Giờ này đã có lịch hẹn");
                txtGioBatDau.Focus();
                return;
            }    
            else
            {
                if(thueMB.ThemLichHen(lh))
                {
                    MessageBox.Show("Thêm thành công");
                    maLichHen = lh.MaLichHen;
                    this.Close();
                    return;
                }    
            }    

        }
        public string MaLichHen()
        {
            return maLichHen;
        }
        private void txtNgayHen_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNgayHen.Text))
            {
                string ngayHTString = DateTime.Now.ToString("dd/MM/yyyy");
                string ngayHenString = ((DateTime)txtNgayHen.EditValue).ToString("dd/MM/yyyy");
                string ngayHetHanString= LayNgayToiThieu(maHD).ToString("dd/MM/yyyy");
                DateTime ngayHT = Commons.ConvertStringToDate(ngayHTString);
                DateTime ngayHen = Commons.ConvertStringToDate(ngayHenString);
                DateTime ngayHetHan = Commons.ConvertStringToDate(ngayHetHanString);
                TimeSpan ktNgay = ngayHen - ngayHT;
                TimeSpan ktNgayMax = ngayHetHan- ngayHen;

                if (ktNgay.Days<=0)
                {
                    MessageBox.Show("Ngày hẹn không thể nhỏ hơn hoặc bằng ngày hiện tại");
                    txtNgayHen.EditValue = (DateTime)DateTime.Now.AddDays(1);
                    txtNgayHen.Focus();
                    return;
                }
                if (ktNgayMax.Days < 0)
                {
                    MessageBox.Show("Ngày hẹn phải nhỏ hơn thời hạn hết hiệu lực tiền cọc ngày:"+ ngayHetHanString);
                    txtNgayHen.EditValue = (DateTime)DateTime.Now.AddDays(1);
                    txtNgayHen.Focus();
                    return;
                }

            }
        }
        private DateTime LayNgayToiThieu(string maHD)
        {
            var hd = thueMB.HoaDonGiuCho(maHD);
            return (DateTime)hd.NgayHetHan;
        }

        private void txtGioBatDau_EditValueChanged(object sender, EventArgs e)
        {
            DateTime gioBD = (DateTime)txtGioBatDau.EditValue;
            DateTime gioKT;
            gioKT = gioBD.AddHours(1);
            txtGioKetThuc.EditValue = gioKT;
            DateTime GioKetThuc = DateTime.Parse("4:00 PM");
            DateTime GioBatDau = DateTime.Parse("7:00 AM");
            if (((DateTime)txtGioBatDau.EditValue).Hour < GioBatDau.Hour)
            {
                MessageBox.Show("Lịch hẹn không thể đặt trước 7:00 AM");
                txtGioBatDau.EditValue = DateTime.Parse("7:00 AM");
                txtGioBatDau.Focus();
                return;
            }

            if (((DateTime)txtGioBatDau.EditValue).Hour> GioKetThuc.Hour)
            {
                MessageBox.Show("Lịch hẹn không thể đặt sau 4 giờ");
                txtGioBatDau.EditValue = DateTime.Parse("4:00 PM");
                txtGioBatDau.Focus();
                return;
            }    
            //DateTime gioKT = (DateTime)txtGioKetThuc.EditValue;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}