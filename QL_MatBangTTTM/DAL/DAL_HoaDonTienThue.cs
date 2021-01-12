using Liz.DoAn;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_HoaDonTienThue
    {
        DBQL_MatBangTTTMDataContext db = new DBQL_MatBangTTTMDataContext();
        public string LayMaThueTuSinh()
        {
            string result = "AEON_HDTT0001";
            HoaDonTienThue lh = db.HoaDonTienThues.Where(x => x.MaHDTienThue.Contains($"AEON_HDTT"))
                .OrderByDescending(x => x.MaHDTienThue).FirstOrDefault();
            if (lh != null && !string.IsNullOrWhiteSpace(lh.MaHDTienThue))
            {
                int so = Convert.ToInt32(lh.MaHDTienThue.Replace("AEON_HDTT", "")) + 1;
                result = "AEON_HDTT" + so.ToString().PadLeft(4, '0');
            }
            return result;
        }
        public bool ThemHoaDonTienThue(HoaDonTienThue thue)
        {
            try
            {
                HoaDonTienThue hd = new HoaDonTienThue();
                hd.MaHDTienThue = thue.MaHDTienThue;
                hd.NgayLap = thue.NgayLap;
                hd.NgayThanhToan = thue.NgayThanhToan;
                hd.TienThue = thue.TienThue;
                hd.TienDichVu = thue.TienDichVu;
                hd.TongTien = thue.TongTien;
                hd.TinhTrang = thue.TinhTrang;
                hd.Ky = thue.Ky;
                hd.MaThueMB = thue.MaThueMB;
                hd.MaNV = thue.MaNV;
                db.HoaDonTienThues.InsertOnSubmit(hd);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }
        public List<ThueMatBang> LayMaThueMB()
        {
            try
            {
                var tm = from tmb in db.ThueMatBangs.
                         Where(t => t.TinhTrang != -1 && t.ThoiHanThue != t.SoNamDaThanhToan)
                         orderby tmb.DangKyThue.MatBang1.ViTri
                         select tmb;
                return tm.ToList();

            }
            catch (Exception)
            {
                List<ThueMatBang> mb = null;
                throw;
            }
        }
        public List<ThueMatBang> LayALLMaThueMB()
        {
            try
            {
                var tm = from tmb in db.ThueMatBangs.
                         Select(t => t)
                         orderby tmb.DangKyThue.MatBang1.ViTri
                         select tmb;
                return tm.ToList();

            }
            catch (Exception)
            {
                List<ThueMatBang> mb = null;
                throw;
            }
        }
        public ThueMatBang LayTTThueMB(string ma)
        {
            try
            {
                ThueMatBang tm = db.ThueMatBangs.Where(t => t.MaThueMB == ma).Select(t => t).FirstOrDefault();

                return tm;

            }
            catch (Exception)
            {
                ThueMatBang mb = null;
                throw;
            }
        }
        public int TinhTienThue(int dientich)
        {
            GiaThue gia = db.GiaThues.Select(t => t).OrderByDescending(t => t.MaGiaThue).FirstOrDefault();
            return (int)(gia.Gia * dientich * 12);
        }
        public List<HoaDonTienThueModel> LayDSHoaDon()
        {
            var ds = from hd in db.HoaDonTienThues
                     select new HoaDonTienThueModel
                     {
                         MaHDTienThue = hd.MaHDTienThue,
                         NgayLap = string.Format("{0:dd/MM/yyyy}", hd.NgayLap),
                         NgayThanhToan = string.Format("{0:dd/MM/yyyy}", hd.NgayThanhToan),
                         TienThue = hd.TienThue,
                         TienDichVu = hd.TienDichVu,
                         TongTien = hd.TongTien,
                         TinhTrang = hd.TinhTrang,
                         Ky = (int)hd.Ky,
                         MaThueMB = hd.MaThueMB,
                         MaNV = hd.MaNV,
                         MaKH = hd.ThueMatBang.DangKyThue.MaKhachHang
                     };

            return ds.ToList();
        }
        public bool SuaHoaDonTienThue(HoaDonTienThue ma)
        {
            try
            {
                HoaDonTienThue hd = db.HoaDonTienThues.Where(t => t.MaHDTienThue == ma.MaHDTienThue).Select(t => t).FirstOrDefault();
                hd.TinhTrang = ma.TinhTrang;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }
    }
}
