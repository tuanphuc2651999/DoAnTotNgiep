using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class BLL_ThongKe
    {
        DAL_ThongKe tk = new DAL_ThongKe();
        public dynamic HDTienThue()
        {
            return tk.HDTienThue();
        }
        public dynamic DoanhThu()
        {
            return tk.DoanhThu();
        }

        public dynamic HDTienCoc()
        {
            return tk.HDTienCoc();
        }

        public dynamic HDTienGiuCho()
        {
            return tk.HDTienCoc();
        }
        public dynamic HDDichVu()
        {
            return tk.HDTienCoc();
        }
    }
}
