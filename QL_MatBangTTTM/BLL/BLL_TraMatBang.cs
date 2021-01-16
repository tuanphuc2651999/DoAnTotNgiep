using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class BLL_TraMatBang
    {
        DAL_TraMatBang tmb = new DAL_TraMatBang();
        public List<ThueMatBang> LayDSDangThueMatBang()
        {
            return tmb.LayDSDangThueMatBang();
        }
        public List<TraMatBangModel> LayDSTraMatBang()
        {
            return tmb.LayDSTraMatBang();
        }
        public string LayMaTraMatBangTuSinh()
        {
            return tmb.LayMaTraMatBangTuSinh();
        }
        public bool ThemTraMatBang(TraMatBang mb)
        {
            return tmb.ThemTraMatBang(mb);
        }
        public List<ThueMatBang> LayAllDSDangThueMatBang()
        {
            return tmb.LayAllDSDangThueMatBang();
        }
        public decimal TinhTienHoanLai(string ma)
        {
            return tmb.TinhTienHoanLai(ma);
        }
    }
}
