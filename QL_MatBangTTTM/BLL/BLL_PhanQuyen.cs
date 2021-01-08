using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_PhanQuyen
    {
        DAL_PhanQuyen pq = new DAL_PhanQuyen();
        public IQueryable<NhomNguoiDung> layDSNhomNguoiDung()
        {
            return pq.layDSNhomNguoiDung();
        }
        public List<PhanQuyenModel> layDSQuyen(string maNhom)
        {
            return pq.layDSQuyen(maNhom);
        }
        public bool capNhatQuyen(UpdateQuyenModel updates)
        {
            return pq.capNhatQuyen(updates);
        }
        public TaiKhoanNV KiemTraDangNhap(string tK)
        {
            return pq.KiemTraDangNhap(tK);
        }
        public bool SuaTaiKhoan(TaiKhoanNV taiKhoan)
        {
            return pq.SuaTaiKhoan(taiKhoan);
        }
        public string laymaNhomNhanVien(string taikhoan)
        {
            return pq.laymaNhomNhanVien(taikhoan);
        }
        public string LayChucVu(string manv)
        {
            return pq.LayChucVu(manv);
        }
    }
}
