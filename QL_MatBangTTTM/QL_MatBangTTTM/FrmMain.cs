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
using DevExpress.XtraSplashScreen;
using BLL;

namespace QL_MatBangTTTM
{
    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        string maNVDN;
        bool check = true;
        BLL_PhanQuyen pq = new BLL_PhanQuyen();
        public FrmMain( string maNV)
        {
            InitializeComponent();
            maNVDN = maNV;
            Quyen(maNV);
        }

        public void Quyen(string tendn)
        {

            string manhom = pq.laymaNhomNhanVien(tendn);
            dataGridView1.DataSource= pq.layDSQuyen(manhom);
            foreach (DataGridViewRow dt in dataGridView1.Rows)
            {
                foreach (BarItem i in ribbon.Items)
                {
                    if (pq.LayChucVu(tendn)  != "Quản lý"|| pq.LayChucVu(tendn) != "Giám đốc")
                    {
                        if (i.Tag != null)
                        {
                            if (i.Tag.Equals(dt.Cells[0].Value.ToString()))
                                i.Visibility = BarItemVisibility.Always;
                        }
                    }
                    else
                        i.Visibility = BarItemVisibility.Always;
                }

            }
        }


        private bool CheckExitsForm(string name)
        {
            bool check = false;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == name)
                {
                    check = true;
                    break;
                }
            }
            return check;
        }
        private void ActiveChildForm(string name)
        {
            foreach (Form frm in MdiChildren)
            {
                if (frm.Name == name)
                {
                    frm.Activate();
                    break;
                }
            }
        }
        private void LoadFormDialog(Form form)
        {
            form.ShowDialog();
        }
        private void loadFrm(Form frm)
        {

            if (!CheckExitsForm(frm.Name))
            {
                SplashScreenManager.ShowForm(this,typeof(WaitLoadFrm));
                frm.MdiParent = this;
                frm.Show();
                SplashScreenManager.CloseDefaultSplashScreen();
            }
            else
            {
                ActiveChildForm(frm.Name);
            }
        }

        private void btnGiaThueMatBang_ItemClick(object sender, ItemClickEventArgs e)
        {
            //loadFrm(new FrmTrangChu());
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có chắc muốn đăng xuất không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (r == DialogResult.Yes)
            {
                this.Hide();
                FrmDangNhap frm = new FrmDangNhap();
                frm.Show();
            }       
            
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            loadFrm(new FrmTrangChu());
        }

        private void btnPhanQuyen_ItemClick(object sender, ItemClickEventArgs e)
        {         
            loadFrm(new FrmPhanQuyen());

        }

        private void btnNhanVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            loadFrm(new FrmNhanVien(maNVDN));
        }

        private void btnKhachHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            loadFrm(new FrmKhachHang(maNVDN));
        }

        private void btnLichHen_ItemClick(object sender, ItemClickEventArgs e)
        {
            loadFrm(new FrmLichHen(maNVDN));
        }

        private void btnDangKyThue_ItemClick(object sender, ItemClickEventArgs e)
        {
            loadFrm(new FrmDangKy(maNVDN));
        }

        private void btnThueMatBang_ItemClick(object sender, ItemClickEventArgs e)
        {
            loadFrm(new FrmThueMatBang(maNVDN));
        }

        private void btnTraMatBang_ItemClick(object sender, ItemClickEventArgs e)
        {
            loadFrm(new FrmTraMatBang(maNVDN));
        }

        private void btnXyLyViPham_ItemClick(object sender, ItemClickEventArgs e)
        {
            loadFrm(new FrmXuLyViPham(maNVDN));
        }

        private void btnHoaDonDV_ItemClick(object sender, ItemClickEventArgs e)
        {
            loadFrm(new FrmHoaDonDichVu(maNVDN));
        }

        private void btnHoaDonTienThue_ItemClick(object sender, ItemClickEventArgs e)
        {
            loadFrm(new FrmHoaDonTienThue(maNVDN));
        }

        private void btnTaiKhoanNhanVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            loadFrm(new FrmTaiKhoanNV(maNVDN));
        }

        private void btnTaiKhoanKhachHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            loadFrm(new FrmTaiKhoanKhachHang());
        }

        private void btnMatBang_ItemClick(object sender, ItemClickEventArgs e)
        {
            loadFrm(new FrmMatBang(maNVDN));
        }

        private void btnDoiMatKhau_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadFormDialog(new FrmDoiMatKhau(maNVDN));
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
          /*  DialogResult r;
            r = MessageBox.Show("Bạn có chắc muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (r == DialogResult.No)
                e.Cancel = true;*/

        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnThongTinSuDung_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}
        private void btnTCDoanhThu_ItemClick(object sender, ItemClickEventArgs e)
        {
            loadFrm(new FrmThongKeDanhThu());
        }
    }
}