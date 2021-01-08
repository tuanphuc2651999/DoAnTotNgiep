using Liz.DoAn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class PhieuDichVuModel
    {
        public string MaPhieuDV { get; set; }
        public string NgayLap { get; set; }
        public string NgayThanhToan { get; set; }
        public string TongTien { get; set; }
        public string MaThueMB { get; set; }
        public string MaNhanVien { get; set; }
        public int? TinhTrang { get; set; }
        public string TinhTrangAsString
        {
            get
            {
                return this.TinhTrang == (int)Status.Active ? "Đã thanh toán" : "chưa thanh toán";
            }
        }
        public string KhachHang { get; set; }
    }
}
