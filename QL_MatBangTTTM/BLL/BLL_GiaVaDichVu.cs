using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class BLL_GiaVaDichVu
    {
        DAL_GiaVaDichVu db = new DAL_GiaVaDichVu();

        #region Giá Thuê
        public List<GiaThueModel> LayDSGiaThue()
        {
            return db.LayDSGiaThue();
        }

        public string LayMaGiaThueTuSinh()
        {
            return db.LayMaGiaThueTuSinh();
        }

        public bool ThemGiaThue(GiaThue gt)
        {
            return db.ThemGiaThue(gt);
        }

        public bool SuaGiaThue(GiaThue gt)
        {
            return db.SuaGiaThue(gt);
        }

        public bool KiemTraTonTaiMaGiaThueTrongMatBang(string maGiaThue)
        {
            return db.KiemTraTonTaiMaGiaThueTrongMatBang(maGiaThue);
        }

        public bool XoaGiaThue(string ma)
        {
            return db.XoaGiaThue(ma);
        }
        #endregion

        #region Giá dịch vụ
        public List<GiaDichVuModel> LayDSGiaDichVu()
        {
            return db.LayDSGiaDichVu();
        }

        public string LayMaGiaDVTuSinh()
        {
            return db.LayMaGiaDVTuSinh();
        }

        public bool ThemGiaDV(GiaDV gdv)
        {
            return db.ThemGiaDV(gdv);
        }

        public bool SuaGiaDV(GiaDV gdv)
        {
            return db.SuaGiaDV(gdv);
        }

        public bool XoaGiaDV(string ma)
        {
            return db.XoaGiaDV(ma);
        }
        #endregion

        #region Dịch vụ
        public List<DichVuModel> LayDSDichVu()
        {
            return db.LayDSDichVu();
        }

        public string LayMaDVTuSinh()
        {
            return db.LayMaDVTuSinh();
        }

        public bool ThemDV(DichVu dv)
        {
            return db.ThemDV(dv);
        }

        public bool SuaDichVu(DichVu dv)
        {
            return db.SuaDichVu(dv);
        }

        public bool KiemTraTonTaiMaDichVuTrongChiTietDV(string ma)
        {
            return db.KiemTraTonTaiMaDichVuTrongChiTietDV(ma);
        }

        public bool XoaDichVu(string ma)
        {
            return db.XoaDichVu(ma);
        }
        #endregion

    }
}
