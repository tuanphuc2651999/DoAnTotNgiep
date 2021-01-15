using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
    public class BLL_MatBang
    {
        DAL_MatBang mb = new DAL_MatBang();

        public List<TTMatBangModel> LayDSTTMatBang()
        {
            return mb.LayDSTTMatBang();
        }
        public List<GiaThue> LayDSGiaThue()
        {
            return mb.LayDSGiaThue();
        }
        public List<KhuVuc> LayDSKhuVuc()
        {
            return mb.LayDSKhuVuc();
        }
        public List<LoaiMB> LayDSLoaiMB()
        {
            return mb.LayDSLoaiMB();
        }
        public List<Tang> LayDSTang()
        {
            return mb.LayDSTang();
        }
        public string LayMaMBTuSinh()
        {
            return mb.LayMaMBTuSinh();
        }
        public bool KiemTraViTri(int viTriSo)
        {
            return mb.KiemTraViTri(viTriSo);
        }
        public bool LuuMatBang(MatBang tt)
        {
            return mb.LuuMatBang(tt);
        }
        public bool XoaMatBang(MatBang tt)
        {
            return mb.XoaMatBang(tt);
        }
        public bool CapNhatGia()
        {
            return mb.CapNhatGia();
        }
        public bool SuaMatBang(MatBang m)
        {
            return SuaMatBang(m);
        }
    }
}
