using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_NhanVien
    {
        DAL_NhanVien nhanVien = new DAL_NhanVien();
        public List<NhanVienModel> layDSNhanVien()
        {
            return nhanVien.layDSNhanVien();
        }
        public List<TaiKhoanNVModel> layDSTKNV()
        {
            return nhanVien.layDSTKNhanVien();
        }
        public bool ThemNhanVien(NhanVienModel nv)
        {
            return nhanVien.ThemNhanVien(nv);

        }
        public bool SuaNhanVien(NhanVienModel nv)
        {
            return nhanVien.SuaNhanVien(nv);
        }
        public string LayMaNVTuSinh() 
        {
            return nhanVien.LayMaNVTuSinh();
        }
        public List<ChucVu> LoadChuVu()
        {
            return nhanVien.LoadChuVu();
        }
        public bool KiemTraNgayVL(DateTime ngayVL)
        {
            return nhanVien.KiemTraNgayVaoLam(ngayVL);
        }
        public bool KiemTraNgaySinh(DateTime ngaySinh,DateTime ngayVL)
        {
            return nhanVien.KiemTraNgaySinh(ngaySinh, ngayVL);
        }
        public bool KiemTraSDT(string sdt,string manv)
        {
            return nhanVien.KiemTraSDT(sdt, manv);
        }
        public bool KiemTraCMND(string cmnd,string manv)
        {
            return nhanVien.KiemTraCMND(cmnd, manv);
        }
        public bool KiemTraEmail(string email,string manv)
        {
            return nhanVien.KiemTraEmail(email, manv);
        }       
        public bool KiemTraEmailHopLe(string email)
        {
            return nhanVien.KiemTraEmailHopLe(email);
        }
        public bool XoaNhanVien(string maNV)
        {
            return nhanVien.XoaNhanVien(maNV);
        }
        public bool ThemTKNhanVien(TaiKhoanNV nv)
        {
            return nhanVien.ThemTKNhanVien(nv);
        }
    }
}
