using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PhanQuyenModel
    {
        public string MaMH { get; set; }

        public string TenMH { get; set; }

        public bool? Quyen { get; set; }
    }
    public class UpdateQuyenModel
    {
        public string MaNhom { get; set; }

        public string MaMH { get; set; }

        public bool? Quyen { get; set; }
    }
    public class TaiKhoanModel {
        public string TaiKhoan { get; set; }

        public string MatKhau { get; set; }

        public string Email { get; set; }
        public int? TrangThai { get; set; }
    }
}
