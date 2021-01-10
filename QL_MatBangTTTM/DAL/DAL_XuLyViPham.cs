using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
     public class DAL_XuLyViPham
    {
        DBQL_MatBangTTTMDataContext db = new DBQL_MatBangTTTMDataContext();
        public List<XuLyViPhamModel> LayDSHoSoViPham()
        {
            var ds = from hs in db.HoSoViPhams
                     select new XuLyViPhamModel
                     {
                         MaHSViPham = hs.MaHSViPham,
                         NgayLap = string.Format("{0:dd/MM/yyyy}", hs.NgayLap),
                         NgayDongTien = string.Format("{0:dd/MM/yyyy}", hs.NgayDongTien),
                         TinhTrang = hs.TinhTrang,
                         TongTienPhat = string.Format("{0:0,0 vnđ}", hs.TongTienPhat),
                         GhiChu = hs.GhiChu,
                         ViPham = hs.ViPham.TenViPham,
                         MaThueMB = hs.MaThueMB,
                         MaNhanVien=hs.MaNhanVien,
                         KhachHang= hs.ThueMatBang.DangKyThue.MaKhachHang
                     };
            return ds.ToList();
        }      

        public List<ViPham> LayDSViPham()
        {

            return db.ViPhams.Select(t => t).ToList();
        }

        public dynamic LayDSThueMatBang()
        {
            var mb = from tmb in db.ThueMatBangs.Where(t => t.TinhTrang == 1 || t.TinhTrang == -2)
                     select new  { tmb.MaThueMB, tmb.DangKyThue.MatBang1.MaMB, tmb.DangKyThue.MatBang1.ViTri};
            return mb.ToList();
        }
        public string LayMaXuLyTuSinh()
        {
            string result = "AEON_SLVP0001";
            HoSoViPham lh = db.HoSoViPhams.Where(x => x.MaHSViPham.Contains($"AEON_SLVP"))
                .OrderByDescending(x => x.MaHSViPham).FirstOrDefault();
            if (lh != null && !string.IsNullOrWhiteSpace(lh.MaHSViPham))
            {
                int so = Convert.ToInt32(lh.MaHSViPham.Replace("AEON_SLVP", "")) + 1;
                result = "AEON_SLVP" + so.ToString().PadLeft(4, '0');
            }
            return result;
        }
        public ThueMatBang LayThongTinThueMB(string ma)
        {
            ThueMatBang mb = db.ThueMatBangs.Where(t => t.MaThueMB.Equals(ma)).Select(t => t).FirstOrDefault();
            return mb;
        }

        public HoSoViPham LayThongTinHoSoVP(string ma)
        {
            HoSoViPham hs = db.HoSoViPhams.Where(t => t.MaHSViPham.Equals(ma)).Select(t => t).FirstOrDefault();
            return hs;
        }

        public bool KiemTraViPhamPhiDichVu()
        {
            DateTime dateTime = DateTime.Now;
            string nam = dateTime.ToString("yyyy");
            string thang = dateTime.ToString("MM");
            int kt = db.HoSoViPhams.Where(t => t.NgayLap.Value.Year.Equals(nam)
             && t.NgayLap.Value.Month.Equals(thang)
             && t.MaViPham.Equals("AEON_MVP0002")).Count();
            if (kt > 0)
                return true;
            return false;
        }
        public bool KiemTraViPham(string maVP)
        {     
            int kt = db.HoSoViPhams.Where(t =>t.MaViPham.Equals(maVP)
            &&t.MaViPham!= "AEON_MVP0005").Count();
            if (kt > 0)
                return true;
            return false;
        }

        public bool ThemHSViPham(HoSoViPham hs)
        {
            try
            {
                HoSoViPham hoSoViPham = new HoSoViPham();
                hoSoViPham = hs;
                db.HoSoViPhams.InsertOnSubmit(hoSoViPham);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            
        }
        public bool SuaHSViPham(HoSoViPham hs)
        {
            try
            {
                HoSoViPham hoSoViPham = db.HoSoViPhams.Where(t=>t.MaHSViPham==hs.MaHSViPham).FirstOrDefault();
                hoSoViPham = hs;               
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public bool KiemTraCoViPhamPhiDichVu(string ma)
        {
            DateTime dateTime = DateTime.Now;
            string nam = dateTime.ToString("yyyy");
            string thang = dateTime.ToString("MM");
            PhieuDichVu kt = db.PhieuDichVus.Where(
                 t=>t.MaThueMB.Equals(ma)).OrderByDescending(t=>t.NgayLap).FirstOrDefault();
            if(kt.TinhTrang!=1)
            {
                return true;
            }
            return false;
        }
        public List<ViPham> LayDSViPhamChamDutHD()
        {


            return db.ViPhams.Where(t=>t.MaViPham== "AEON_MVP0001"|| t.MaViPham == "AEON_MVP0002" ||
            t.MaViPham == "AEON_MVP0003").Select(t => t).ToList();
        }

        public string LayTTViPhamChamDutHD(string maThue)
        {
            var ds= db.HoSoViPhams.Where(t => (t.MaViPham == "AEON_MVP0001" || t.MaViPham == "AEON_MVP0002" ||
             t.MaViPham == "AEON_MVP0003")&&t.MaThueMB==maThue).Select(t => t).FirstOrDefault();
            if (ds == null)
                return null;
            else
            return ds.ViPham.TenViPham;
        }
        public bool XoaViPhamn(string maViPham)
        {
            try
            {
                HoSoViPham nv = db.HoSoViPhams.Where(x => x.MaHSViPham.Equals(maViPham)).FirstOrDefault();
                db.HoSoViPhams.DeleteOnSubmit(nv);
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
