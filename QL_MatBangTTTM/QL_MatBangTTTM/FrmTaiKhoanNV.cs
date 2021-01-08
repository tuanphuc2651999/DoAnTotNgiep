using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Localization;
using BLL;
using Model;

namespace QL_MatBangTTTM
{
    public partial class FrmTaiKhoanNV : DevExpress.XtraEditors.XtraForm
    {
        BLL_NhanVien nhanVien = new BLL_NhanVien();
        public FrmTaiKhoanNV(string maNV)
        {
            InitializeComponent();
            GridLocalizer.Active = new MyGridLocalizer();
        }
        private void Databingding(BindingList<TaiKhoanNVModel> kh)
        {
           /* txtMaKH.DataBindings.Add("text", kh, "MaKH");
            txtTenKH.DataBindings.Add("text", kh, "HoTenKH");
            txtCMND.DataBindings.Add("text", kh, "CMND");
            txtDiaChi.DataBindings.Add("text", kh, "DiaChi");
            txtSDT.DataBindings.Add("text", kh, "SDT");
            cboGioiTinh.DataBindings.Add("text", kh, "GioiTinh");
            cboTrangThai.DataBindings.Add("text", kh, "TinhTrangAsString");
            dENgaySinh.DataBindings.Add("datetime", kh, "ngaysinh");
            txtEmail.DataBindings.Add("text", kh, "Email");*/
        }
        private void FrmTaiKhoanNV_Load(object sender, EventArgs e)
        {
            BindingList<TaiKhoanNVModel> bindingList = new BindingList<TaiKhoanNVModel>(nhanVien.layDSTKNV());
            this.gCDSTaiKhoanNV.DataSource = bindingList;
            //dem = dgvDSKhachHang.RowCount;
            GridLocalizer.Active = new MyGridLocalizer();
            Databingding(bindingList);
        }
    }
}