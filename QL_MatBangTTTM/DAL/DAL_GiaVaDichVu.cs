using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public class DAL_GiaVaDichVu
    {
        DBQL_MatBangTTTMDataContext db = new DBQL_MatBangTTTMDataContext();


        #region Giá Thuê
        // Lấy danh sách giá thuê
        public List<GiaThueModel> LayDSGiaThue()
        {
            var giaThue = from gt in db.GiaThues
                          select new GiaThueModel
                          {
                              MaGiaThue = gt.MaGiaThue,
                              TenGiaThue = gt.TenGiaThue,
                              Gia = (int)gt.Gia,
                              NgayCapNhat = gt.NgayCapNhat,
                          };
            return giaThue.ToList();
        }

        // Tự sinh mã giá thuê không trùng
        public string LayMaGiaThueTuSinh()
        {
            int soGiaThueHienCo = db.GiaThues.Select(t => t).Count();

            string maGiaThueTuSinh = LayMaGiaThueTuSinhSauKhiDem(soGiaThueHienCo);

            return maGiaThueTuSinh;
        }
        private string LayMaGiaThueTuSinhSauKhiDem(int soGiaThueHienCo)
        {
            if (soGiaThueHienCo < 10)
            {
                string ma = "AEON_MGT000" + soGiaThueHienCo;
                if (db.GiaThues.Where(m => m.MaGiaThue == ma).Count() == 0)
                {
                    return ma;
                }
                else
                {
                    return LayMaGiaThueTuSinhSauKhiDem(soGiaThueHienCo + 1);
                }
            }
            else if (soGiaThueHienCo >= 10 && soGiaThueHienCo < 100)
            {
                string ma = "AEON_MGT00" + soGiaThueHienCo;
                if (db.GiaThues.Where(m => m.MaGiaThue == ma).Count() == 0)
                {
                    return ma;
                }
                else
                {
                    return LayMaGiaThueTuSinhSauKhiDem(soGiaThueHienCo + 1);
                }
            }
            else if (soGiaThueHienCo >= 100 && soGiaThueHienCo < 1000)
            {
                string ma = "AEON_MGT0" + soGiaThueHienCo;
                if (db.GiaThues.Where(m => m.MaGiaThue == ma).Count() == 0)
                {
                    return ma;
                }
                else
                {
                    return LayMaGiaThueTuSinhSauKhiDem(soGiaThueHienCo + 1);
                }
            }
            else
            {
                string ma = "AEON_MGT" + soGiaThueHienCo;
                if (db.GiaThues.Where(m => m.MaGiaThue == ma).Count() == 0)
                {
                    return ma;
                }
                else
                {
                    return LayMaGiaThueTuSinhSauKhiDem(soGiaThueHienCo + 1);
                }
            }
        }

        // Thêm sửa giá thuê
        public bool ThemGiaThue(GiaThue gt)
        {
            try
            {
                GiaThue giaThue = new GiaThue
                {
                    MaGiaThue = gt.MaGiaThue,
                    TenGiaThue = gt.TenGiaThue,
                    Gia = gt.Gia,
                    NgayCapNhat = gt.NgayCapNhat,
                };
                db.GiaThues.InsertOnSubmit(giaThue);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                var error = ex;
                return false;
            }
        }

        public bool KiemTraTonTaiMaGiaThueTrongMatBang(string maGiaThue)
        {
            if (db.MatBangs.Where(t => t.Gia == maGiaThue).Count() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool XoaGiaThue(string maGiaThue)
        {
            try
            {
                // Kiểm tra mã giá thuê có tồn tại trong bảng mặt bằng chưa ?
                if (db.MatBangs.Where(t => t.Gia == maGiaThue).Count() == 0)
                {
                    GiaThue gt = db.GiaThues.Where(t => t.MaGiaThue == maGiaThue).FirstOrDefault();
                    db.GiaThues.DeleteOnSubmit(gt);
                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                var error = ex;
                return false;
            }
        }

        public bool SuaGiaThue(GiaThue gt)
        {
            try
            {
                GiaThue giaThue = db.GiaThues.Where(t => t.MaGiaThue == gt.MaGiaThue).FirstOrDefault();
                giaThue.Gia = gt.Gia;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                var error = ex;
                return false;
            }
        }
        #endregion

        #region Giá Dịch Vụ

        //Lấy danh sách giá dịch vụ
        public List<GiaDichVuModel> LayDSGiaDichVu()
        {
            var giaDV = from gt in db.GiaDVs
                        select new GiaDichVuModel
                        {
                            MaGiaDichVu = gt.GiaDV1,
                            TenDichVu = gt.TenDichVu,
                            Gia = (int)gt.Gia,
                            NgayTao = gt.NgayTao,
                        };
            return giaDV.ToList();
        }

        // Tự sinh mã giá dịch vụ không trùng
        public string LayMaGiaDVTuSinh()
        {
            int soGiaDVHienCo = db.GiaDVs.Select(t => t).Count();

            string maGiaDVTuSinh = LayMaGiaDVTuSinhSauKhiDem(soGiaDVHienCo);

            return maGiaDVTuSinh;
        }
        private string LayMaGiaDVTuSinhSauKhiDem(int soGiaDVHienCo)
        {
            if (soGiaDVHienCo < 10)
            {
                string ma = "AEON_MGDV000" + soGiaDVHienCo;
                if (db.GiaDVs.Where(m => m.GiaDV1 == ma).Count() == 0)
                {
                    return ma;
                }
                else
                {
                    return LayMaGiaDVTuSinhSauKhiDem(soGiaDVHienCo + 1);
                }
            }
            else if (soGiaDVHienCo >= 10 && soGiaDVHienCo < 100)
            {
                string ma = "AEON_MGDV00" + soGiaDVHienCo;
                if (db.GiaDVs.Where(m => m.GiaDV1 == ma).Count() == 0)
                {
                    return ma;
                }
                else
                {
                    return LayMaGiaDVTuSinhSauKhiDem(soGiaDVHienCo + 1);
                }
            }
            else if (soGiaDVHienCo >= 100 && soGiaDVHienCo < 1000)
            {
                string ma = "AEON_MGDV0" + soGiaDVHienCo;
                if (db.GiaDVs.Where(m => m.GiaDV1 == ma).Count() == 0)
                {
                    return ma;
                }
                else
                {
                    return LayMaGiaDVTuSinhSauKhiDem(soGiaDVHienCo + 1);
                }
            }
            else
            {
                string ma = "AEON_MGDV" + soGiaDVHienCo;
                if (db.GiaDVs.Where(m => m.GiaDV1 == ma).Count() == 0)
                {
                    return ma;
                }
                else
                {
                    return LayMaGiaDVTuSinhSauKhiDem(soGiaDVHienCo + 1);
                }
            }
        }

        // Thêm sửa giá dịch vụ
        public bool ThemGiaDV(GiaDV dv)
        {
            try
            {
                GiaDV giaDV = new GiaDV();
                giaDV.GiaDV1 = dv.GiaDV1;
                giaDV.TenDichVu = dv.TenDichVu;
                giaDV.Gia = dv.Gia;
                giaDV.NgayTao = dv.NgayTao;

                db.GiaDVs.InsertOnSubmit(giaDV);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                var error = ex;
                return false;
            }
        }

        public bool XoaGiaDV(string maGiaDV)
        {
            try
            {
                // Kiểm tra mã giá dịch vụ có tồn tại trong bảng mặt bằng chưa ?
                if (db.DichVus.Where(t => t.Gia == maGiaDV).Count() == 0)
                {
                    GiaDV dv = db.GiaDVs.Where(t => t.GiaDV1 == maGiaDV).FirstOrDefault();
                    db.GiaDVs.DeleteOnSubmit(dv);
                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                var error = ex;
                return false;
            }
        }

        public bool SuaGiaDV(GiaDV dv)
        {
            try
            {
                GiaDV giaDV = db.GiaDVs.Where(t => t.GiaDV1 == dv.GiaDV1).FirstOrDefault();
                giaDV.Gia = dv.Gia;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                var error = ex;
                return false;
            }
        }
        #endregion

        #region Dịch Vụ
        //Lấy danh sách dịch vụ
        public List<DichVuModel> LayDSDichVu()
        {
            var dichvu = from dv in db.DichVus
                         from gdv in db.GiaDVs
                         where dv.Gia == gdv.GiaDV1
                         select new DichVuModel
                         {
                             MaDichVu = dv.MaDichVu,
                             TenDichVu = dv.TenDichVu,
                             Gia = (int)gdv.Gia,
                             MaGiaDV = dv.Gia,
                             DonViTinh = dv.DonViTinh,
                         };
            return dichvu.ToList();
        }

        // Tự sinh mã dịch vụ không trùng
        public string LayMaDVTuSinh()
        {
            int soDVHienCo = db.DichVus.Select(t => t).Count();

            string maDVTuSinh = LayMaDVTuSinhSauKhiDem(soDVHienCo);

            return maDVTuSinh;
        }
        private string LayMaDVTuSinhSauKhiDem(int soDVHienCo)
        {
            if (soDVHienCo < 10)
            {
                string ma = "AEON_MDV000" + soDVHienCo;
                if (db.DichVus.Where(m => m.MaDichVu == ma).Count() == 0)
                {
                    return ma;
                }
                else
                {
                    return LayMaDVTuSinhSauKhiDem(soDVHienCo + 1);
                }
            }
            else if (soDVHienCo >= 10 && soDVHienCo < 100)
            {
                string ma = "AEON_MDV00" + soDVHienCo;
                if (db.DichVus.Where(m => m.MaDichVu == ma).Count() == 0)
                {
                    return ma;
                }
                else
                {
                    return LayMaDVTuSinhSauKhiDem(soDVHienCo + 1);
                }
            }
            else if (soDVHienCo >= 100 && soDVHienCo < 1000)
            {
                string ma = "AEON_MDV0" + soDVHienCo;
                if (db.DichVus.Where(m => m.MaDichVu == ma).Count() == 0)
                {
                    return ma;
                }
                else
                {
                    return LayMaDVTuSinhSauKhiDem(soDVHienCo + 1);
                }
            }
            else
            {
                string ma = "AEON_MDV" + soDVHienCo;
                if (db.DichVus.Where(m => m.MaDichVu == ma).Count() == 0)
                {
                    return ma;
                }
                else
                {
                    return LayMaDVTuSinhSauKhiDem(soDVHienCo + 1);
                }
            }
        }

        // Thêm sửa dịch vụ
        public bool ThemDV(DichVu dv)
        {
            try
            {
                DichVu dichVu = new DichVu();
                dichVu.MaDichVu = dv.MaDichVu;
                dichVu.TenDichVu = dv.TenDichVu;
                dichVu.Gia = dv.Gia;
                dichVu.DonViTinh = dv.DonViTinh;

                db.DichVus.InsertOnSubmit(dichVu);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                var error = ex;
                return false;
            }
        }
        public bool KiemTraTonTaiMaDichVuTrongChiTietDV(string maDichVu)
        {
            if (db.CT_DichVus.Where(t => t.MaDichVu == maDichVu).Count() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool XoaDichVu(string maDV)
        {
            try
            {
                // Kiểm tra dịch vụ thuê có tồn tại trong bảng mặt bằng chưa ?
                if (db.CT_DichVus.Where(t => t.MaDichVu == maDV).Count() == 0)
                {
                    DichVu dv = db.DichVus.Where(t => t.MaDichVu == maDV).FirstOrDefault();
                    db.DichVus.DeleteOnSubmit(dv);
                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                var error = ex;
                return false;
            }
        }

        public bool SuaDichVu(DichVu dv)
        {
            try
            {
                DichVu dichVu = db.DichVus.Where(t => t.MaDichVu == dv.MaDichVu).FirstOrDefault();
                dichVu.TenDichVu = dv.TenDichVu;
                dichVu.DonViTinh = dv.DonViTinh;

                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                var error = ex;
                return false;
            }
        }


        #endregion
    }
}
