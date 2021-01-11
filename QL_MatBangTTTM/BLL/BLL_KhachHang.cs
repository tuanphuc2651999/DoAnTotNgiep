using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_KhachHang
    {
        DAL_KhachHang khachHang = new DAL_KhachHang();
        public List<KhachHangModel> layDSKhachHang()
        {
            return khachHang.layDSKhachHang();
        }
        public List<KhachHangModel> layDSKHKhongCoTaiKhoan()
        {
            return khachHang.layDSKhachHangKhongCoTaiKhoan();
        }
        public bool suaKhachHang(KhachHangModel kh)
        {
            return khachHang.suaKhachHang(kh);
        }
        public bool themKhachHang(KhachHangModel kh)
        {
            return khachHang.themKhachHang(kh);
        }
        public string layMaKHTuSinh()
        {
            return khachHang.layMaKHTuSinh();
        }
        public List<TaiKhoanKHModel> layDSTKKH()
        {
            return khachHang.layDSTKKH();
        }
        public KhachHang LayTTKhachHang(string ma)
        {
            return khachHang.LayTTKhachHang(ma);
        }
        public bool XoaKhachHang(string maKH)
        {
            return khachHang.XoaKhachHang(maKH);
        }
        public bool KiemTraEmail(string email, string manv)
        {
            return khachHang.KiemTraEmail(email,manv);
        }
        public bool KiemTraSDT(string sdt, string manv)
        {
            return khachHang.KiemTraSDT(sdt, manv);
        }
        public bool KiemTraCMND(string cnmd, string manv)
        {
            return khachHang.KiemTraCMND(cnmd, manv);
        }
        public bool ThemTKKhachHang(TaiKhoanKH nv)
        {
            return khachHang.ThemTKKhachHang(nv);
        }
        public bool SuaTaiKhoanKhachHang(TaiKhoanKH tk)
        {
            return khachHang.SuaTaiKhoanKhachHang(tk);
        }
        public bool XoaTaiKhoanKhachHang(TaiKhoanKH tk)
        {
            return khachHang.XoaTaiKhoanKhachHang(tk);
        }
        public int LayTinhTrangTaiKhoanKH(string maKH)
        {
            return khachHang.LayTinhTrangTaiKhoanKH(maKH);
        }

    }
}
