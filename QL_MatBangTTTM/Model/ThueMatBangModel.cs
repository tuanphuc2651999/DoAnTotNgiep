using Liz.DoAn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class ThueMatBangModel
    {
        public string MaThueMB { get; set; }
        public string NgayLap { get; set; }
        public string NgayThue { get; set; }
        public string NgayHetHanHopDong { get; set; }
        public int? ThoiHanThue { get; set; }
        public int? SoNamDaThanhToan { get; set; }
        public int PhiDichVuMotNam { get; set; }
        public int? TinhTrang { get; set; }
        public string TinhTrangAsString
        {
            get
            {
                if (this.TinhTrang == (int)Status.Active)
                    return "Đang thuê";
                if (this.TinhTrang == (int)Status.Pending)
                    return "Chờ gia hạn";
                return "Đã trả";
            }
        }
        public string KhachHang { get; set; }
        public string MaNhanVien { get; set; }
        public string MaDKThue { get; set; }
        public int? TongTien { get; set; }
        public string HoaDonTienCoc { get; set; }
        public int? TienCoc { get; set; }
    }
}
