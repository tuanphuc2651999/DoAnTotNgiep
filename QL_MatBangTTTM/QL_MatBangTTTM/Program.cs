using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_MatBangTTTM
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {          
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new FrmTraMatBang("AEON_NV0001"));
            // Application.Run(new FrmDangNhap());
            // Application.Run(new FrmTaoHoaDonTienCoc());
             Application.Run(new FrmTaiKhoanKhachHang());
            // Application.Run(new FrmNhanVien(""));
            // Application.Run(new FrmMain(""));

        }
    }
}
