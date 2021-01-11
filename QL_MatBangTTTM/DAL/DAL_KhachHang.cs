using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_KhachHang
    {
        DBQL_MatBangTTTMDataContext db = new DBQL_MatBangTTTMDataContext();
        public List<KhachHangModel> layDSKhachHang()
        {
            var khachHang = from kh in db.KhachHangs
                            where kh.TinhTrang==1
                    select new KhachHangModel
                    {
                        MaKH = kh.MaKH,
                        HoTenKH = kh.HoTenKH,
                        CMND= kh.CMND,
                        DiaChi = kh.DiaChi,
                        GioiTinh = kh.GioiTinh,
                        NgaySinh = (DateTime)kh.NgaySinh,
                        SDT = kh.SDT,
                        Email= kh.Email,
                        DuongDanHinh = kh.DuongDanHinh,
                        TinhTrang = (int)kh.TinhTrang,                        
                    };                            
            return khachHang.ToList();
        }
        public bool themKhachHang(KhachHangModel khachHang)
        {
            try
            {
                KhachHang kh = new KhachHang();
                kh.MaKH = khachHang.MaKH;
                kh.HoTenKH = khachHang.HoTenKH;
                kh.NgaySinh = khachHang.NgaySinh;
                kh.GioiTinh = khachHang.GioiTinh;
                kh.DiaChi = khachHang.DiaChi;
                kh.SDT = khachHang.SDT;
                kh.CMND = khachHang.CMND;
                kh.Email = khachHang.Email;
                kh.DuongDanHinh = khachHang.DuongDanHinh;
                kh.TinhTrang = 1;
                db.KhachHangs.InsertOnSubmit(kh);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public bool suaKhachHang(KhachHangModel khachHang)
        {
            try
            {
                KhachHang kh = db.KhachHangs.FirstOrDefault(t => t.MaKH.Equals(khachHang.MaKH));
                
                kh.MaKH = khachHang.MaKH;
                kh.HoTenKH = khachHang.HoTenKH;
                kh.NgaySinh = khachHang.NgaySinh;
                kh.GioiTinh = khachHang.GioiTinh;
                kh.DiaChi = khachHang.DiaChi;
                kh.SDT = khachHang.SDT;
                kh.Email = khachHang.Email;
                kh.CMND = khachHang.CMND;
                kh.DuongDanHinh = khachHang.DuongDanHinh;

                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public string layMaKHTuSinh()
        {
            string result = "";
            KhachHang khachHang = db.KhachHangs.Where(x => x.MaKH.Contains($"AEON_KH"))
                .OrderByDescending(x => x.MaKH).FirstOrDefault();
            if (khachHang != null && !string.IsNullOrWhiteSpace(khachHang.MaKH))
            {
                int so =Convert.ToInt32(khachHang.MaKH.Replace("AEON_KH", "")) + 1;
                 result = "AEON_KH"+ so.ToString().PadLeft(4,'0');
            }
            return result;
        }

        public List<TaiKhoanKHModel> layDSTKKH()
        {
            var taiKhoans = from tk in db.TaiKhoanKHs
                            join kh in db.KhachHangs on tk.TaiKhoan equals kh.SDT
                            select new TaiKhoanKHModel {
                TaiKhoan = tk.TaiKhoan,
                MatKhau = tk.MatKhau,
                Email = tk.Email,
                TinhTrang = tk.TinhTrang,
                TenKhachHang=kh.HoTenKH,
                MaKhachHang=kh.MaKH
                            };
            return taiKhoans.ToList();
        }

        public KhachHang LayTTKhachHang(string ma)
        {
            KhachHang khachHang =db.KhachHangs.Where(t=>t.MaKH==ma).Select(t => t).FirstOrDefault();
            return khachHang;
        }
        public bool XoaKhachHang(string maKH)
        {
            try
            {
                KhachHang nv = db.KhachHangs.Where(x => x.MaKH.Equals(maKH)).FirstOrDefault();
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
        public bool KiemTraEmail(string email, string manv)
        {
            int dem = db.KhachHangs.Where(t => t.Email.Equals(email) && !t.MaKH.Equals(manv)).Count();
            if (dem > 0)
            {
                return true;
            }
            return false;
        }
        public bool KiemTraSDT(string sdt, string manv)
        {
            int dem = db.KhachHangs.Where(t => t.SDT.Equals(sdt) && !t.MaKH.Equals(manv)).Count();
            if (dem > 0)
            {
                return true;
            }
            return false;
        }
        public bool KiemTraCMND(string cnmd, string manv)
        {
            int dem = db.KhachHangs.Where(t => t.CMND.Equals(cnmd) && !t.MaKH.Equals(manv)).Count();
            if (dem > 0)
            {
                return true;
            }
            return false;
        }
        public bool ThemTKKhachHang(TaiKhoanKH nv)
        {
            try
            {
                TaiKhoanKH taiKhoanKH = new TaiKhoanKH();
                taiKhoanKH.TaiKhoan = nv.TaiKhoan;
                taiKhoanKH.Email = nv.Email;
                taiKhoanKH.MatKhau = nv.MatKhau;
                taiKhoanKH.TinhTrang = nv.TinhTrang;
                taiKhoanKH.MaKhachHang = nv.MaKhachHang;
                db.TaiKhoanKHs.InsertOnSubmit(taiKhoanKH);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public List<KhachHangModel> layDSKhachHangKhongCoTaiKhoan()
        {
            var khachHang = from kh in db.KhachHangs
                            where kh.TinhTrang == 1 &&
                            !(from tkkh in db.TaiKhoanKHs select tkkh.MaKhachHang).Contains(kh.MaKH)
                            select new KhachHangModel
                            {
                                MaKH = kh.MaKH,
                                HoTenKH = kh.HoTenKH,
                                CMND = kh.CMND,
                                DiaChi = kh.DiaChi,
                                GioiTinh = kh.GioiTinh,
                                NgaySinh = (DateTime)kh.NgaySinh,
                                SDT = kh.SDT,
                                Email = kh.Email,
                                DuongDanHinh = kh.DuongDanHinh,
                                TinhTrang = (int)kh.TinhTrang,
                            };
            return khachHang.ToList();
        }
        public bool SuaTaiKhoanKhachHang(TaiKhoanKH taiKhoan)
        {
            try
            {
                TaiKhoanKH kh = db.TaiKhoanKHs.FirstOrDefault(t => t.TaiKhoan.Equals(taiKhoan.TaiKhoan));

                kh.TaiKhoan = taiKhoan.TaiKhoan;
                kh.MatKhau = taiKhoan.MatKhau;
                kh.Email = taiKhoan.Email;
                kh.TinhTrang = taiKhoan.TinhTrang;
                kh.MaKhachHang = taiKhoan.MaKhachHang;

                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool XoaTaiKhoanKhachHang(TaiKhoanKH tk)
        {
            try
            {
                TaiKhoanKH tkkh = db.TaiKhoanKHs.Where(x => x.TaiKhoan.Equals(tk.TaiKhoan)).FirstOrDefault();
                tkkh.TinhTrang = -1;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public int LayTinhTrangTaiKhoanKH(string ma)
        {
            int tinhTrang =(int)db.TaiKhoanKHs.Where(t => t.MaKhachHang == ma).Select(t => t.TinhTrang).FirstOrDefault();
            return tinhTrang;
        }
    }
}
