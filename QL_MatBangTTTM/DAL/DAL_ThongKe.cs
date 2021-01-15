using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class DAL_ThongKe
    {
        DBQL_MatBangTTTMDataContext db = new DBQL_MatBangTTTMDataContext();
        public dynamic HDTienThue()
        {
            var result = db.HoaDonTienThues
                        .GroupBy(l =>  l.NgayThanhToan.Value.Year)
                        .Select(cl => new ThongKeModel
                        {
                            Thang = cl.First().NgayThanhToan.Value.Year,
                            Tong = cl.Sum(c => c.TongTien)
                        }).ToList();
            return result;
        }
        public dynamic HDTienCoc()
        {
            var result = db.HoaDonTienCocs
                        .GroupBy(l => l.NgayDong.Value.Year)
                        .Select(cl => new ThongKeModel
                        {
                            Thang = cl.First().NgayDong.Value.Year,
                            Tong = cl.Sum(c => c.SoTien)
                        }).ToList();
            return result;
        }

        public dynamic HDTienGiuCho()
        {
            var result = db.HoaDonGiuChos
                        .GroupBy(l => l.NgayDong.Value.Year)
                        .Select(cl => new ThongKeModel
                        {
                            Thang = cl.First().NgayDong.Value.Year,
                            Tong = cl.Sum(c => c.SoTien)
                        }).ToList();
            return result;
        }
        public dynamic HDDichVu()
        {
            var result = db.PhieuDichVus
                        .GroupBy(l => l.NgayThanhToan.Value.Year)
                        .Select(cl => new ThongKeModel
                        {
                            Thang = cl.First().NgayThanhToan.Value.Year,
                            Tong = cl.Sum(c => c.TongTien)
                        }).ToList();
            return result;
        }

        public dynamic DoanhThu()
        {
            List<ThongKeModel> lst = new List<ThongKeModel>();
            dynamic dt1 = HDTienThue();
            dynamic dt2 = HDTienCoc();
            dynamic dt3 = HDTienGiuCho();
            dynamic dt4 = HDDichVu();
            foreach (ThongKeModel item in dt1)
            {
                lst.Add(item);
            }
            foreach (ThongKeModel item in dt2)
            {
                lst.Add(item);
            }
            foreach (ThongKeModel item in dt3)
            {
                lst.Add(item);
            }
            foreach (ThongKeModel item in dt4)
            {
                lst.Add(item);
            }
            //lst đây là dữ liệu các tháng

            var result = lst
                        .GroupBy(l => l.Thang)
                        .Select(cl => new ThongKeModel
                        {
                            Thang = cl.First().Thang,
                            Tong = cl.Sum(c => c.Tong)
                        }).ToList();


           /* List<ThongKeModel> result1 = new List<ThongKeModel>();
            var dl = lst.GroupBy(t => t.Thang).ToList();
            foreach (var item in dl)
            {
                var s1= lst.GroupBy(l => l.Thang==item.Thang)
                        .Select(cl => new ThongKeModel
                        {
                            Thang = cl.First().Thang,
                            Tong = cl.Sum(c => c.Tong)
                        }).ToList();
                decimal tong=0 ;
                int nam =0;       
                foreach (ThongKeModel item1 in s1)
                {
                    tong = (decimal)(tong + item1.Tong);
                    nam = item1.Thang;                   
                }
                ThongKeModel model = new ThongKeModel();
                model.Tong = tong;
                model.Thang = nam;
                result1.Add(model);
            }*/

            /*List<ThongKeModel> result = new List<ThongKeModel>();
            for (int i = 0; i < lst.Count; i++)
            {
                for (int j = i+1; j < lst.Count; j++)
                {
                    if(lst[i].Thang == lst[j].Thang)
                    {
                        ThongKeModel thong = new ThongKeModel();
                        thong.Thang = lst[i].Thang;
                        thong.Tong = (lst[i].Tong + lst[j].Tong);
                        result.Add(thong);
                    }                          
                }
            }*/
            return result;
        }
    }
}
