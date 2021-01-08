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
using BLL;
using DAL;
using Liz.DoAn;

namespace QL_MatBangTTTM
{
    public partial class FrmTraMatBang : DevExpress.XtraEditors.XtraForm
    {
        BLL_TraMatBang traMB = new BLL_TraMatBang();
        bool check = false;
        string maNV;
        public FrmTraMatBang(string maNV)
        {
            InitializeComponent();
            this.maNV = maNV;
        }
        public void LoadDSThueMatBang()
        {
            txtMaThueMB.Properties.DataSource = traMB.LayDSDangThueMatBang();
        }
        public void LoadDSTraMB()
        {
            gcDSTraMB.DataSource = traMB.LayDSTraMatBang();
        }
        public void LoadAllDSThueMatBang()
        {
            txtMaThueMB.Properties.DataSource = traMB.LayAllDSDangThueMatBang();
        }
        public void choNhapTextBox(bool trangThai)
        {
            txtMaThueMB.ReadOnly = trangThai;          
        }
        private void TaoMoi()
        {
            LoadDSThueMatBang();
            txtNhanVien.Text = maNV;          
            txtMaPhieuTra.Text = traMB.LayMaTraMatBangTuSinh();
            txtNgayLap.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtNgayTra.EditValue = Commons.ConvertStringToDate(DateTime.Now.ToString("dd/MM/yyyy"));
        }
        #region BTN
        private void Click_BtnThem()
        {
            btnThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnHuy.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnLuuNV.Visible = true;
            btnNhapLai.Visible = true;
            btnHuyThem.Visible = true;
            check = true;
            choNhapTextBox(false);
            TaoMoi();
        }
        private void Click_BtnSua()
        {
            btnThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnHuy.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnLuuNV.Visible = true;
            btnNhapLai.Visible = false;
            btnHuyThem.Visible = true;
            choNhapTextBox(false);
            check = false;
        }
        private void Click_BtnLuu()
        {
            btnThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnHuy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnLuuNV.Visible = false;
            btnNhapLai.Visible = false;
            btnHuyThem.Visible = false;
            choNhapTextBox(true);
            check = false;
        }
        private void Click_BtnHuy()
        {
            btnThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnHuy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnLuuNV.Visible = false;
            btnNhapLai.Visible = false;
            btnHuyThem.Visible = false;
            choNhapTextBox(true);
           
        }
        #endregion

        private void btnThem_ItemClick(object sender, ItemClickEventArgs e)
        {
            Click_BtnThem();
        }

        private void btnXoa_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnSua_ItemClick(object sender, ItemClickEventArgs e)
        {
            Click_BtnSua();
        }

        private void btnLuu_ItemClick(object sender, ItemClickEventArgs e)
        {
            Click_BtnLuu();
        }

        private void btnHuy_ItemClick(object sender, ItemClickEventArgs e)
        {
            Click_BtnHuy();
        }

        private void FrmTraMatBang_Load(object sender, EventArgs e)
        {
            LoadAllDSThueMatBang();
            LoadDSTraMB();
        }
        private void buttonEdit1_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            MessageBox.Show("OK");
        }
    }
}