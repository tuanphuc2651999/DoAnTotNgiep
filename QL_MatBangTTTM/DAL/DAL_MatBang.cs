using System;
using Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_MatBang
    {
        DBQL_MatBangTTTMDataContext db = new DBQL_MatBangTTTMDataContext();

        #region Mặt Bằng
        public List<TTMatBangModel> LayDSTTMatBang()
        {
            var matbang = from mb in db.MatBangs
                          from gt in db.GiaThues
                          from tang in db.Tangs
                          from lmb in db.LoaiMBs
                          from kv in db.KhuVucs
                          where mb.Gia == gt.MaGiaThue &&
                                mb.MaTang == tang.MaTang &&
                                mb.LoaiMB == lmb.MaLoaiMB &&
                                mb.MaKhuVuc == kv.MaKhuVuc
                          select new TTMatBangModel
                          {
                              MaMB = mb.MaMB,
                              ViTri = mb.ViTri,
                              TinhTrang = mb.TinhTrang,
                              DienTich = mb.DienTich,
                              MaGia = mb.Gia,
                              Gia = gt.Gia,
                              MaTang = mb.MaTang,
                              TenTang = tang.TenTang,
                              LoaiMB = mb.LoaiMB,
                              TenLoaiMB = lmb.TenLoaiMB,
                              MaKhuVuc = mb.MaKhuVuc,
                              TenKhuVuc = kv.TenKhuVuc,
                          };
            return matbang.ToList();
        }

        public bool LuuMatBang(MatBang tt)
        {
            try
            {
                MatBang mb = new MatBang();
                mb.MaMB = tt.MaMB;
                mb.ViTri = tt.ViTri;
                mb.TinhTrang = tt.TinhTrang;
                mb.DienTich = tt.DienTich;
                mb.Gia = tt.Gia;
                mb.MaTang = tt.MaTang;
                mb.LoaiMB = tt.LoaiMB;
                mb.MaKhuVuc = tt.MaKhuVuc;
                db.MatBangs.InsertOnSubmit(mb);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

        public bool XoaMatBang(MatBang tt)
        {
            try
            {
                MatBang mb = db.MatBangs.Where(t => t.MaMB == tt.MaMB).FirstOrDefault();
                mb.TinhTrang = -1;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

        public bool CapNhatGia()
        {
            try
            {
                if (!string.IsNullOrEmpty(LayMaGiaThueCuoiCung()))
                {
                    try
                    {
                        string maGiaMoi = LayMaGiaThueCuoiCung();
                        List<MatBang> dsMB = db.MatBangs.Where(t => t.TinhTrang == 0).ToList();
                        foreach (MatBang m in dsMB)
                        {
                            MatBang mbl = db.MatBangs.Where(t => t.MaMB == m.MaMB).FirstOrDefault();
                            mbl.Gia = maGiaMoi;
                            db.SubmitChanges();
                        }
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                        throw;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                var a = ex.ToString();
                return false;
                throw;
            }
        }

        private string LayMaGiaThueCuoiCung()
        {
            return db.GiaThues.OrderByDescending(gia => gia.MaGiaThue).Take(1).SingleOrDefault().MaGiaThue;
            //return db.GiaThues.Select(t => t.MaGiaThue).LastOrDefault();
        }

        public bool SuaMatBang(MatBang m)
        {
            try
            {
                MatBang luu = db.MatBangs.Where(t => t.MaMB == m.MaMB).FirstOrDefault();
                luu.Gia = m.Gia;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return false;
                throw;
            }
        }

        // Tạo mã mặt bằng không trùng
        public string LayMaMBTuSinh()
        {
            int soMBHienCo = db.MatBangs.Select(t => t).Count();

            string maMBTuSinh = LayMaMBTuSinhSauKhiDem(soMBHienCo);

            return maMBTuSinh;
        }

        private string LayMaMBTuSinhSauKhiDem(int soMBHienCo)
        {
            if (soMBHienCo < 10)
            {
                string ma = "AEON_MMB000" + soMBHienCo;
                if (db.MatBangs.Where(m => m.MaMB == ma).Count() == 0)
                {
                    return ma;
                }
                else
                {
                    return LayMaMBTuSinhSauKhiDem(soMBHienCo + 1);
                }
            }
            else if (soMBHienCo >= 10 && soMBHienCo < 100)
            {
                string ma = "AEON_MMB00" + soMBHienCo;
                if (db.MatBangs.Where(m => m.MaMB == ma).Count() == 0)
                {
                    return ma;
                }
                else
                {
                    return LayMaMBTuSinhSauKhiDem(soMBHienCo + 1);
                }
            }
            else if (soMBHienCo >= 100 && soMBHienCo < 1000)
            {
                string ma = "AEON_MMB0" + soMBHienCo;
                if (db.MatBangs.Where(m => m.MaMB == ma).Count() == 0)
                {
                    return ma;
                }
                else
                {
                    return LayMaMBTuSinhSauKhiDem(soMBHienCo + 1);
                }
            }
            else
            {
                string ma = "AEON_MMB" + soMBHienCo;
                if (db.MatBangs.Where(m => m.MaMB == ma).Count() == 0)
                {
                    return ma;
                }
                else
                {
                    return LayMaMBTuSinhSauKhiDem(soMBHienCo + 1);
                }
            }
        }

        #endregion

        #region Giá Thuê
        public List<GiaThue> LayDSGiaThue()
        {
            return db.GiaThues.Select(t => t).ToList();
        }

        //public GiaThue LayGiaMatBangGanNhat()
        //{
        //    return db.GiaThues.Select(t => t).LastOrDefault();
        //}

        #endregion

        #region Tầng
        public List<Tang> LayDSTang()
        {
            return db.Tangs.Select(t => t).ToList();
        }
        #endregion

        #region Loại Mặt Bằng
        public List<LoaiMB> LayDSLoaiMB()
        {
            return db.LoaiMBs.Select(t => t).ToList();
        }
        #endregion

        #region Khu Vực
        public List<KhuVuc> LayDSKhuVuc()
        {
            return db.KhuVucs.Select(t => t).ToList();
        }
        #endregion

        #region Vị trí
        public bool KiemTraViTri(int viTriSo)
        {
            // kiểm tra vị trí mặt bằng đó không phải ở tình trạng "Đang thuê" và "Trống"
            if (db.MatBangs.Where(t => t.ViTri == viTriSo && t.TinhTrang == 1).Count() == 0)
            {
                if (db.MatBangs.Where(t => t.ViTri == viTriSo && t.TinhTrang == 0).Count() == 0)
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }
        #endregion
    }
}
