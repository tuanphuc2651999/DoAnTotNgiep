using Liz.DoAn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class NhanVienModel
    {
        public string MaNV { get; set; }
        public string HoTenNV { get; set; }
        public DateTime NgayVL { get; set; }
        public string DiaChi { get; set; }
        public string GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string SDT { get; set; }
        public string CMND { get; set; }
        public string DuongDanHinh { get; set; }
        public int TinhTrang { get; set; }
        public string TinhTrangAsString {
            get {
                return this.TinhTrang == (int)Status.Active ? "Đang làm" : "Đã nghỉ"; }
        }
        public string ChucVu { get; set; }
        public string MaChucVu { get; set; }
        public string Email { get; set; }
    }
    public class TaiKhoanNVModel
    {
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string Email { get; set; }
        public int? TinhTrang { get; set; }
        public string TenNhanVien { get; set; }
    }
}
