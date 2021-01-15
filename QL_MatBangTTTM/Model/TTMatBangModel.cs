using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Liz.DoAn;

namespace Model
{
    public class TTMatBangModel
    {
        public string MaMB { get; set; }
        public int? ViTri { get; set; }
        public int? TinhTrang { get; set; }
        public double? DienTich { get; set; }
        public string MaGia { get; set; }
        public int? Gia { get; set; }
        public string MaTang { get; set; }
        public string TenTang { get; set; }
        public string LoaiMB { get; set; }
        public string TenLoaiMB { get; set; }
        public string MaKhuVuc { get; set; }
        public string TenKhuVuc { get; set; }
        public string TinhTrangAsString
        {
            get
            {
                if (this.TinhTrang == (int)StatusMatBang.Empty)
                    return "Còn Trống";
                else if (this.TinhTrang == (int)StatusMatBang.Rented)
                    return "Đang thuê";
                else
                    return "Không tồn tại";
            }
        }
    }
}
