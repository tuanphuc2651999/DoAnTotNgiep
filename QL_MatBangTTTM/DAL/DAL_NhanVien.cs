using Liz.DoAn;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAL
{
   public class DAL_NhanVien
    {
        DBQL_MatBangTTTMDataContext db = new DBQL_MatBangTTTMDataContext();
        public List<NhanVienModel> layDSNhanVien()
        {
            try
            {
                var nhanViens = (from nv in db.NhanViens
                                 join cv in db.ChucVus on nv.ChucVu equals cv.MaChucVu
                                 where nv.TinhTrang==1
                                 select new NhanVienModel
                                 {
                                     MaNV = nv.MaNhanVien,
                                     HoTenNV = nv.HoTenNV,
                                     NgayVL = (DateTime)nv.NgayVL,
                                     DiaChi = nv.DiaChi,
                                     GioiTinh = nv.GioiTinh,
                                     NgaySinh = (DateTime)nv.NgaySinh,
                                     SDT = nv.SDT,
                                     DuongDanHinh =nv.DuongDanHinh,
                                     TinhTrang = (int)nv.TinhTrang,
                                     ChucVu = cv.TenChucVu,
                                     MaChucVu=cv.MaChucVu,
                                     CMND = nv.CMND,
                                     Email= nv.Email
                                 }) ;

                return nhanViens.ToList();
            }
            catch (Exception exe)
            {
                throw;
            }

        }

        public List<TaiKhoanNVModel> layDSTKNhanVien()
        {
            var taiKhoans = from tk in db.TaiKhoanNVs
                            join nv in db.NhanViens on tk.TaiKhoan equals nv.MaNhanVien
                            select new TaiKhoanNVModel {
                TaiKhoan = tk.TaiKhoan,
                MatKhau = tk.MatKhau,
                Email = tk.Email,
                TinhTrang= tk.TinhTrang,
                TenNhanVien=nv.HoTenNV
                            };
            return taiKhoans.ToList();
        }
        public bool ThemNhanVien(NhanVienModel nv)
        {
            try
            {
                NhanVien nhanVien = new NhanVien();
                nhanVien.MaNhanVien = nv.MaNV;
                nhanVien.HoTenNV = nv.HoTenNV;
                nhanVien.NgayVL = nv.NgayVL;
                nhanVien.DiaChi = nv.DiaChi;
                nhanVien.GioiTinh = nv.GioiTinh;
                nhanVien.NgaySinh = nv.NgaySinh;
                nhanVien.SDT = nv.SDT;
                nhanVien.Email = nv.Email;
                nhanVien.DuongDanHinh = nv.DuongDanHinh;
                nhanVien.TinhTrang = nv.TinhTrang;
                nhanVien.ChucVu = nv.ChucVu;
                db.NhanViens.InsertOnSubmit(nhanVien);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }

        }
        public bool SuaNhanVien(NhanVienModel nv)
        {
            try
            {
                NhanVien nhanVien = db.NhanViens.FirstOrDefault(t => t.MaNhanVien.Equals(nv.MaNV));
                nhanVien.MaNhanVien = nv.MaNV;
                nhanVien.HoTenNV = nv.HoTenNV;
                nhanVien.NgayVL = nv.NgayVL;
                nhanVien.DiaChi = nv.DiaChi;
                nhanVien.GioiTinh = nv.GioiTinh;
                nhanVien.NgaySinh = nv.NgaySinh;
                nhanVien.SDT = nv.SDT;
                nhanVien.CMND = nv.CMND;
                nhanVien.Email = nv.Email;
                nhanVien.DuongDanHinh = nv.DuongDanHinh;
                if (nv.TinhTrangAsString.Equals("Đang làm"))
                    nhanVien.TinhTrang = 1;
                else
                    nhanVien.TinhTrang = 0;
                nhanVien.ChucVu = nv.ChucVu;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public bool XoaNhanVien(string maNV)
        {
            try
            {
                NhanVien nv = db.NhanViens.Where(x => x.MaNhanVien.Equals(maNV)).FirstOrDefault();
                nv.TinhTrang = 0;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
          
        }
        public string LayMaNVTuSinh()
        {
            string result = "AEON_NV" + 1.ToString().PadLeft(4, '0');
            NhanVien nv = db.NhanViens.Where(x => x.MaNhanVien.Contains($"AEON_NV"))
                .OrderByDescending(x => x.MaNhanVien).FirstOrDefault();
            if (nv != null && !string.IsNullOrWhiteSpace(nv.MaNhanVien))
            {
                int so = Convert.ToInt32(nv.MaNhanVien.Replace("AEON_NV", "")) + 1;
                    result = "AEON_NV" + so.ToString().PadLeft(4, '0');
            }
            return result;
        }
        public List<ChucVu> LoadChuVu()
        {
            return db.ChucVus.Select(t => t).ToList();
        }
        public bool KiemTraNgayVaoLam(DateTime ngayVL)
        {
            string ngayHTString = DateTime.Now.ToString("dd/MM/yyyy");
            string ngayVLString = ngayVL.ToString("dd/MM/yyyy");
            TimeSpan ngay = Commons.ConvertStringToDate(ngayHTString).Subtract(Commons.ConvertStringToDate(ngayVLString));
            if(ngay.Days<0)
            {
                return true;
            }
            return false;
        }
        public bool KiemTraNgaySinh(DateTime ngaySinh,DateTime ngayVL)
        {
            string ngayVLtring = ngayVL.ToString("dd/MM/yyyy");
            string ngaySinhString = ngaySinh.ToString("dd/MM/yyyy");
            TimeSpan ngay = Commons.ConvertStringToDate(ngayVLtring).Subtract(Commons.ConvertStringToDate(ngaySinhString));
            if (ngay.Days>=6570)
                return true;
            return false;
        }
        public bool KiemTraEmail(string email,string manv)
        {
            int dem = db.NhanViens.Where(t => t.Email.Equals(email) && !t.MaNhanVien.Equals(manv)).Count();
            if(dem>0)
            {
                return true;
            }
            return false;
        }
        public bool KiemTraSDT(string sdt,string manv)
        {
            int dem = db.NhanViens.Where(t => t.SDT.Equals(sdt) && !t.MaNhanVien.Equals(manv)).Count();
            if (dem > 0)
            {
                return true;
            }
            return false;
        }
        public bool KiemTraCMND(string cnmd, string manv)
        {
            int dem = db.NhanViens.Where(t => t.CMND.Equals(cnmd) && !t.MaNhanVien.Equals(manv)).Count();
            if (dem > 0)
            {
                return true;
            }
            return false;
        }
        public bool KiemTraEmailHopLe(string emailaddress)
        {
            return Regex.IsMatch(emailaddress, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
        public bool ThemTKNhanVien(TaiKhoanNV nv)
        {
            try
            {
                TaiKhoanNV taiKhoanNV = new TaiKhoanNV();
                taiKhoanNV.TaiKhoan = nv.TaiKhoan;
                taiKhoanNV.Email = nv.Email;
                taiKhoanNV.MatKhau = nv.MatKhau;
                taiKhoanNV.TinhTrang = 1;
                db.TaiKhoanNVs.InsertOnSubmit(taiKhoanNV);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }           
        }

        
    }
}
