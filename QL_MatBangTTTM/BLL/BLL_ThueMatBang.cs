using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class BLL_ThueMatBang
    {
        DAL_DKThueMatBang dkThue = new DAL_DKThueMatBang();
        public List<DangKyThueModel> LayDSDKThueMatBang()
        {
            return dkThue.LayDSDKThueMatBang();
        }
        public List<MatBangModel> LayDSMatBang()
        {
            return dkThue.DSMatBang();
        }
        public bool ThemDangKyMatBang(DangKyThue input)
        {
            return dkThue.ThemDangKyMatBang(input);
        }
        public string LayMaDKTuSinh(int dem)
        {
            return dkThue.LayMaDKTuSinh(dem);
        }
        public HoaDonTienCoc HoaDon(string ma)
        {
            return dkThue.HoaDon(ma);
        }
        public LichHen LayThongTinLichHen(string ma)
        {
            return dkThue.LayThongTinLichHen(ma);
        }
        public bool UpdateTrangThaiMatBang(string maMB, int TrangThai)
        {
            return dkThue.UpdateTrangThaiMatBang(maMB, TrangThai);

        }

        public bool ThemHoaDon(HoaDonTienCoc hd)
        {
            return dkThue.ThemHoaDon(hd);
        }
        public string LayMaHoaDonTuSinh()
        {
            return dkThue.LayMaHoaDonTuSinh();
        }
        public double TinhTienCoc(string maMB)
        {
            return dkThue.TinhTienCoc(maMB);
        }
        public bool XoaHoaDon(string maHD)
        {
            return dkThue.XoaHoaDon(maHD);
        }
        public string LayMaLichHenTuSinh()
        {
            return dkThue.LayMaLichHenTuSinh();
        }
        public bool ThemLichHen(LichHen lh)
        {
            return dkThue.ThemLichHen(lh);
        }
        public bool XoaLichHen(string lh)
        {
            return dkThue.XoaLichHen(lh);
        }
        public bool KiemTraLichHen(LichHen lh)
        {
            return dkThue.KiemTraLichHen(lh);
        }
        public bool SuaDKThueMatBang(DangKyThue input)
        {
            return dkThue.SuaDKThueMatBang(input);
        }
        public MatBang LayThongTinMB(string mb)
        {
            return dkThue.LayThongTinMB(mb);
        }
        public List<ThueMatBang> LayDSThueMatBang()
        {
            return dkThue.LayDSThueMatBang();
        }
        public bool ThemThueMatBang(ThueMatBang thue)
        {
            return dkThue.ThemThueMatBang(thue);
        }
        public bool SuaThueMatBang(ThueMatBang thue)
        {
            return dkThue.SuaThueMatBang(thue);
        }
        public string LayMaThueTuSinh()
        {
            return dkThue.LayMaThueTuSinh();
        }
        public List<DangKyThueModel> LayDSMatBangChuaThue()
        {
            return dkThue.LayDSMatBangChuaThue();
        }
        public DangKyThue LayThongTinDKThue(string ma)
        {
            return dkThue.LayThongTinDKThue(ma);
        }
        public List<GiaThue> DSGia()
        {
            return dkThue.DSGia();
        }
        public double PhiDichVu(int dienTich)
        {
            return dkThue.PhiDichVu(dienTich);
        }
        public List<LichHenModel> LayDSLichHen()
        {
            return dkThue.LayDSLichHen();
        }
        public List<DangKyThue> LayDSDangKy()
        {
            return dkThue.LayDSDangKy();
        }
        public List<DangKyThueModel> LayDSDangKyChuaCoLichHen()
        {
            return dkThue.LayDSDangKyChuaCoLichHen();
        }
        public bool SuaLichHen(LichHen lh)
        {
            return dkThue.SuaLichHen(lh);
        }
        public HoaDonGiuCho HoaDonGiuCho(string ma)
        {
            return dkThue.HoaDonGiuCho(ma);
        }
        public bool ThemHoaDonGiuCho(HoaDonGiuCho hd)
        {
            return dkThue.ThemHoaDonGiuCho(hd);
        }
        public string LayMaHDGiuCho()
        {
            return dkThue.LayMaHDGiuCho();
        }
        public bool XoaHoaDonGiuCho(string maHD)
        {
            return dkThue.XoaHoaDonGiuCho(maHD);
        }
        public List<HoaDonTienCoc> LayDSHoaDonTienCoc()
        {           
            return dkThue.LayDSHoaDonTienCoc();
        }
        public List<HoaDonGiuCho> LayDSHoaDonGiuCho()
        {
            return dkThue.LayDSHoaDonGiuCho();
        }
        public List<ThueMatBang> LayDSThueMBChuaCoHoaDon()
        {
            return dkThue.LayDSThueMBChuaCoHoaDon();
        }
        public PhieuDichVu LayThongTinPhieuDV(string maPDV)
        {
            return dkThue.LayThongTinPhieuDV(maPDV);
        }
        public string LayMaHoaDVTuSinh()
        {
            return dkThue.LayMaHoaDVTuSinh();
        }
        public List<PhieuDichVuModel> LayDSPhieuDV()
        {
            return dkThue.LayDSPhieuDV();
        }
        public CT_DichVu LayThongTinCT_DichVu(string maPDV, string maDV)
        {
            return dkThue.LayThongTinCT_DichVu(maPDV, maDV);
        }
        public string LayMaHoaDonMoiNhat(string maThue)
        {
            return dkThue.LayMaHoaDonMoiNhat(maThue);
        }
        public int LayGiaDien()
        {
            return dkThue.LayGiaDien();
        }
        public int LayGiaNuoc()
        {
            return dkThue.LayGiaNuoc();
        }
        public bool ThemHoaDonDichVu(PhieuDichVu dv)
        {
            return dkThue.ThemHoaDonDichVu(dv);
        }
        public bool ThemCTHoaDonDichVu(CT_DichVu dv)
        {
            return dkThue.ThemCTHoaDonDichVu(dv);
        }
       public bool XoaHoaDonDichVu(string maHD)
        {
            return dkThue.XoaHoaDonDichVu(maHD);
        }
        public bool XoaCTHoaDonDichVu(string maHD)
        {
            return dkThue.XoaCTHoaDonDichVu(maHD);
        }
        public bool ThemThongBaoDichVu(ThongBao tt)
        {
            return dkThue.ThemThongBaoDichVu(tt);
        }
        
    }
}
