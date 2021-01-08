using Liz.DoAn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DangKyThueModel
    {
        public string MaDK { get; set; }
        public DateTime? NgayLap { get; set; }
        public int? TienCoc { get; set; }
        public DateTime? NgayKyHopDong { get; set; }
        public DateTime? NgayHetHanCoc { get; set; }
        public DateTime? NgayDongCoc { get; set; }
        public int? TinhTrang { get; set; }
        public string LichHen { get; set; }
        public string MaMB { get; set; }
        public string MaKhachHang { get; set; }
        public DateTime? NgayMoCua { get; set; }
        public int? ThoiHanThue { get; set; }
        public string TinhTrangAsString
        {
            get
            {
                if (this.TinhTrang == 0)
                {
                    return "Chờ đóng cọc";
                }
                if (this.TinhTrang == 1)
                {
                    return "Đã đóng cọc";
                }
                if (this.TinhTrang == -2)
                {
                    return "Hết hạn xử lý";
                }
                if (this.TinhTrang == 2)
                {
                    return "Đã xử lý";
                }
                return "Chưa xử lý";
            }
        }
        public DateTime? NgayHen { get; set; }
        public TimeSpan? GioBatDau { get; set; }
        public TimeSpan? GioKetThuc { get; set; }
        public int? SoTien
        {
            get; set;
        }

        public DateTime? NgayHetHan { get; set; }
        public string MaHD { get; set; }
    }
    public class MatBangModel
    {
        public string MaMB { get; set; }
        public double? DienTich { get; set; }
        public int? ViTri { get; set; }
        public int? TinhTrang { get; set; }
        public string TinhTrangAsString
        {
            get
            {
                if (this.TinhTrang == (int)Status.Active)
                    return "Chưa thuê";
                if (this.TinhTrang == (int)Status.Pending)
                    return "Đã đặt cọc";
                return "Đang thuê";
            }
        }
    }    

    public class LichHenModel
    {
        public string MaLichHen { get; set; }
        public string NgayHen { get; set; }
        public string GioBatDau { get; set; }
        public string GioKetThuc { get; set; }
        public string DiaChi { get; set; }
        public string NoiDung { get; set; }

        public string TinhTrang { get; set; }
        public string MaNhanVien { get; set; }
        public string MaDK { get; set; }
        public string MaKH { get; set; }
    }
}
