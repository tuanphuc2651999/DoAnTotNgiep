using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class DAL_PhanQuyen
    {
        DBQL_MatBangTTTMDataContext db = new DBQL_MatBangTTTMDataContext();
        public IQueryable<NhomNguoiDung> layDSNhomNguoiDung()
        {
            return db.NhomNguoiDungs.Select(t => t);
        }
        public List<PhanQuyenModel> layDSQuyen(string maNhom)
        {
            var phanquyen = from pq in db.PhanQuyens join mh in db.ManHinhs on pq.MaMH equals mh.MaManHinh where pq.MaNhom == maNhom select new { pq.MaMH, mh.TenMH, pq.CoQuyen };
            List<PhanQuyenModel> ds = new List<PhanQuyenModel>();
            foreach (var item in phanquyen)
            {
                PhanQuyenModel model = new PhanQuyenModel();
                model.MaMH = item.MaMH;
                model.TenMH = item.TenMH;
                model.Quyen = item.CoQuyen;
                ds.Add(model);
            }
            return ds;
        }
        public bool capNhatQuyen(UpdateQuyenModel updates)
        {
            try
            {
                PhanQuyen phanQuyen = db.PhanQuyens.FirstOrDefault(t => t.MaNhom.Equals(updates.MaNhom) && t.ManHinh.MaManHinh.Equals(updates.MaMH));
                phanQuyen.CoQuyen = updates.Quyen;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public TaiKhoanNV KiemTraDangNhap(string tk)
        {
            try
            {
                var taiKhoan = db.TaiKhoanNVs.Where(t=>t.TaiKhoan.Equals(tk)).FirstOrDefault();
                return taiKhoan;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public bool SuaTaiKhoan(TaiKhoanNV taiKhoan)
        {
            try
            {
                TaiKhoanNV tk = db.TaiKhoanNVs.FirstOrDefault(t => t.TaiKhoan.Equals(taiKhoan.TaiKhoan));
                tk.MatKhau = taiKhoan.MatKhau;
                tk.TinhTrang = taiKhoan.TinhTrang;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public string laymaNhomNhanVien(string taikhoan)
        {
            NguoiDungNhomNguoiDung nd = db.NguoiDungNhomNguoiDungs.Where(t => t.TaiKhoan == taikhoan).FirstOrDefault();
            return nd.MaNhom;
        }
        public string LayChucVu(string manv)
        {
            var chucvu = from nv in db.NhanViens join cv in db.ChucVus on nv.ChucVu equals cv.MaChucVu
                         where nv.MaNhanVien.Equals(manv) select
                         new {cv.TenChucVu };

            return chucvu.ToString();
        }
       
    }
}
