using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class DAL_TraMatBang
    {
        DBQL_MatBangTTTMDataContext db = new DBQL_MatBangTTTMDataContext();
        public List<ThueMatBang> LayDSDangThueMatBang()
        {
            var ds = db.ThueMatBangs.Where(t => t.TinhTrang == 1).OrderBy(t=>t.DangKyThue.MatBang);
            return ds.ToList();
        }
        public List<TraMatBangModel> LayDSTraMatBang()
        {
            var ds = from t in db.TraMatBangs
                     select new TraMatBangModel
                     {
                         MaNhanVien = t.MaNhanVien,
                         MaTraMatBang = t.MaTraMatBang,
                         NgayLap = string.Format("{0:dd/MM/yyyy}", t.NgayLap) ,
                         TienHoanLai = string.Format("{0:0,0 vnđ}", t.TienHoanLai),
                         NgayTra = string.Format("{0:dd/MM/yyyy}", t.NgayTra),
                         TinhTrang = t.TinhTrang,
                         ThueMB = t.ThueMB,
                         ViTri = t.ThueMatBang.DangKyThue.MatBang1.ViTri.ToString(),
                         MaKH = t.ThueMatBang.DangKyThue.MaKhachHang,
                         MaMB=t.ThueMatBang.DangKyThue.MatBang
                     };
            return ds.ToList();


        }
        public string LayMaTraMatBangTuSinh()
        {
            string result = "AEON_MTMB" + 1.ToString().PadLeft(4, '0');
            TraMatBang tmb = db.TraMatBangs.Where(x => x.MaTraMatBang.Contains($"AEON_MTMB"))
                .OrderByDescending(x => x.MaTraMatBang).FirstOrDefault();
            if (tmb != null && !string.IsNullOrWhiteSpace(tmb.MaTraMatBang))
            {
                int so = Convert.ToInt32(tmb.MaTraMatBang.Replace("AEON_MTMB", "")) + 1;
                result = "AEON_MTMB" + so.ToString().PadLeft(4, '0');
            }
            return result;
        }
        public bool ThemTraMatBang(TraMatBang tmb)
        {
            try
            {
                TraMatBang traMatBang = new TraMatBang();
                traMatBang.MaTraMatBang = tmb.MaTraMatBang;
                traMatBang.NgayLap = tmb.NgayLap;
                traMatBang.NgayTra = tmb.NgayTra;
                traMatBang.TienHoanLai = tmb.TienHoanLai;
                traMatBang.TinhTrang = tmb.TinhTrang;
                traMatBang.MaNhanVien = tmb.MaNhanVien;
                traMatBang.ThueMB = tmb.ThueMB;
                db.TraMatBangs.InsertOnSubmit(traMatBang);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }

        }
        public List<ThueMatBang> LayAllDSDangThueMatBang()
        {
            var ds = db.ThueMatBangs.Select(t=>t);
            return ds.ToList();
        }
        public decimal TinhTienHoanLai(string maThue)
        {
            var tienDV = db.PhieuDichVus.Where(t => t.MaThueMB == maThue && t.TinhTrang!=1)
                .Select(t => t.TongTien);
            var tienVP = db.HoSoViPhams.Where(t => t.MaThueMB == maThue && t.TinhTrang != 1&& t.TongTienPhat>0)
                .Select(t => t.TongTienPhat);
            decimal tiencoc = (int)db.ThueMatBangs.Where(t => t.MaThueMB == maThue).Select(t => t.HoaDonTienCoc1.SoTien).FirstOrDefault();
            int tongtien=0;
            foreach (var item in tienDV)
            {
                tongtien += (int)item;
            }
            foreach (var item in tienVP)
            {
                tongtien += (int)item;
            }
            return tiencoc - tongtien;
        }
    }
}
