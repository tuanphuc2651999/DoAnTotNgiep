using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Model;
using System.Collections.Generic;
using DAL;

namespace QL_MatBangTTTM
{
    public partial class XtraReport1 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport1()
        {
            InitializeComponent();
        }
        public void report(DateTime ngaylap, string mathue, string kh, string dt, string email, string mahd,string tenkh,List<CT_DichVu> data)
        {
            pNgayLap.Value = ngaylap;
            MaThue.Value = mathue;
            pKhachHang.Value = kh;
            pSDT.Value = dt;
            Email.Value = email;
            pMaHD.Value = mahd;
            pTenKH.Value = tenkh;
            objectDataSource4.DataSource = data;
        }
    }
}
