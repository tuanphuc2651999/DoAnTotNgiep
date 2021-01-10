using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class BLL_XuLyViPham
    {
        DAL_XuLyViPham vp = new DAL_XuLyViPham();
        public List<XuLyViPhamModel> LayDSHoSoViPham()
        {
            return vp.LayDSHoSoViPham();
        }
        public List<ViPham> LayDSViPham()
        {
            return vp.LayDSViPham();
        }
        public dynamic LayDSThueMatBang()
        {
            return vp.LayDSThueMatBang();
        }
        public string LayMaXuLyTuSinh()
        {
            return vp.LayMaXuLyTuSinh();
        }
        public ThueMatBang LayThongTinThueMB(string ma)
        {
            return vp.LayThongTinThueMB(ma);
        }
        public HoSoViPham LayThongTinHoSoVP(string ma)
        {
            return vp.LayThongTinHoSoVP(ma);
        }
        public bool KiemTraViPhamPhiDichVu()
        {
            return vp.KiemTraViPhamPhiDichVu();
        }
        public bool KiemTraViPham(string ma)
        {
            return vp.KiemTraViPham(ma);
        }
        public bool ThemHSViPham(HoSoViPham hs)
        {
            return vp.ThemHSViPham(hs);
        }
        public bool SuaHSViPham(HoSoViPham hs)
        {
            return vp.SuaHSViPham(hs);
        }
        public bool KiemTraCoViPhamPhiDichVu(string ma)
        {
            return vp.KiemTraCoViPhamPhiDichVu(ma);
        }
        public List<ViPham> LayDSViPhamChamDutHD()
        {
            return vp.LayDSViPhamChamDutHD();
        }
        public string LayTTViPhamChamDutHD(string maThue)
        {
            return vp.LayTTViPhamChamDutHD(maThue);
        }
        public bool XoaViPhamn(string maViPham)
        {
            return vp.XoaViPhamn(maViPham);
        }
    }
}
