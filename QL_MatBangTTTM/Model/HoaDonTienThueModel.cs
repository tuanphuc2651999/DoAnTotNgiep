using Liz.DoAn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class HoaDonTienThueModel
    {
        public string MaHDTienThue { get; set; }
        public string NgayLap { get; set; }
        public string NgayThanhToan { get; set; }
        public int? TienThue { get; set; }
        public int? TienDichVu { get; set; }
        public int? TongTien { get; set; }
        public int? TinhTrang { get; set; }
        public int Ky { get; set; }
        public string MaThueMB { get; set; }
        public string MaNV { get; set; }
        public string TinhTrangAsString
        {
            get
            {
                return this.TinhTrang == (int)Status.Active ? "Đã đóng" : "Chưa đóng";
            }
        }
        public string MaKH { get; set; }

    }
}
