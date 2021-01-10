using Liz.DoAn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class XuLyViPhamModel
    {
        public string MaHSViPham { get; set; }
        public string NgayLap { get; set; }
        public string NgayDongTien { get; set; }
        public int? TinhTrang { get; set; }
        public string TinhTrangAsString
        {
            get
            {
                if (this.TinhTrang == (int)Status.Active)
                    return "Đã đóng";                
                return "Chưa đóng";
            }
        }
        public string TongTienPhat { get; set; }
        public string GhiChu { get; set; }



        public string ViPham { get; set; }
        public string KhachHang { get; set; }
        public string MaNhanVien { get; set; }
        public string MaThueMB { get; set; }

    }
}
