using Liz.DoAn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TraMatBangModel
    {
        public string MaTraMatBang { get; set; }
        public string NgayLap { get; set; }
        public string TienHoanLai { get; set; }
        public int? TinhTrang { get; set; }
        public string TinhTrangAsString
        {
            get
            {
                if (this.TinhTrang == (int)Status.Active)
                    return "Trả đúng hạn";
                if (this.TinhTrang == (int)Status.Locked)
                    return "Trả trễ hạn";
                return "Trả trước hạn";
            }
        }
        public string NgayTra { get; set; }
        public string MaNhanVien { get; set; }
        public string ThueMB { get; set; }
        public string MaMB { get; set; }
        public string ViTri { get; set; }
        public string MaKH { get; set; }
    }
}
