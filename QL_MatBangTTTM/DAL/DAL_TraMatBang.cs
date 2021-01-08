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
            var ds = db.ThueMatBangs.Where(t => t.TinhTrang == 1);
            return ds.ToList();
        }
        public List<TraMatBang> LayDSTraMatBang()
        {
            var ds = db.TraMatBangs.Select(t => t);
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
    }
}
