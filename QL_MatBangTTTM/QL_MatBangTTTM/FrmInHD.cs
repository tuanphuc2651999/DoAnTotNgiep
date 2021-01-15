using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DAL;
using Model;

namespace QL_MatBangTTTM
{
    public partial class FrmInHD : DevExpress.XtraEditors.XtraForm
    {
        public FrmInHD()
        {
            InitializeComponent();
        }
        public void print(PhieuDichVu dv, List<CT_DichVu> data)
        {
            XtraReport1 report = new XtraReport1();
            foreach (var item in report.Parameters)
            {
                item.Visible = false;
            }
            report.report((DateTime)dv.NgayLap,dv.MaThueMB,dv.ThueMatBang.DangKyThue.MaKhachHang,
                dv.ThueMatBang.DangKyThue.KhachHang.SDT, dv.ThueMatBang.DangKyThue.KhachHang.Email,
                dv.MaPhieuDV,data);
            {
                documentViewer1.DocumentSource = report;
                report.CreateDocument();
            }
        }
    }
}