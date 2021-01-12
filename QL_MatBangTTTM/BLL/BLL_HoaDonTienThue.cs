using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
  public class BLL_HoaDonTienThue
    {
        DAL_HoaDonTienThue hd = new DAL_HoaDonTienThue();
        public string LayMaThueTuSinh()
        {
            return hd.LayMaThueTuSinh();
        }
        public bool ThemHoaDonTienThue(HoaDonTienThue t)
        {
            return hd.ThemHoaDonTienThue(t);
        }
        public List<ThueMatBang> LayMaThueMB()
        {
            return hd.LayMaThueMB();
        }
        public List<ThueMatBang> LayAllMaThueMB()
        {
            return hd.LayALLMaThueMB();
        }
        public ThueMatBang LayTTThueMB(string ma)
        {
            return hd.LayTTThueMB(ma);
        }
        public int TinhTienThue(int dientich)
        {
            return hd.TinhTienThue(dientich);
        }
        public List<HoaDonTienThueModel> LayDSHoaDon()
        {
            return hd.LayDSHoaDon();
        }
        public bool SuaHoaDonTienThue(HoaDonTienThue ma)
        {
            return hd.SuaHoaDonTienThue(ma);
        }
    }
}
