using Liz.DoAn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class KhachHangModel
    {
        public string MaKH { get; set; }
        public string HoTenKH { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string CMND { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public int TinhTrang { get; set; }
        public string DuongDanHinh { get; set; }
        public string TinhTrangAsString
        {
            get
            {
                return this.TinhTrang == (int)Status.Active ? "Đang hoạt động" : "Ngưng hoạt động";
            }
        }
    }
    public class TaiKhoanKHModel
    {
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string Email { get; set; }
        public string MKTamThoi { get; set; }
        public string ThoiGianDoiMKTamThoi { get; set; }
        public int? TinhTrang { get; set; }
        public string TenKhachHang { get; set; }
        public string MaKhachHang { get; set; }
        public string TinhTrangAsString
        {
            get
            {
                // return this.TinhTrang == (int)StatusTaiKhoan.Active ? "Đang hoạt động" : "Ngưng hoạt động";
                if (this.TinhTrang == (int)StatusTaiKhoan.Active)
                    return "Đang hoạt động";
                else if (this.TinhTrang == (int)StatusTaiKhoan.NewAccount)
                    return "Tài khoản mới";
                else
                    return "Bị Khóa";
            }
        }
    }

}

