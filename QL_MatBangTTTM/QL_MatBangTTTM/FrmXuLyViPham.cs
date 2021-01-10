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

namespace QL_MatBangTTTM
{
    public partial class FrmXuLyViPham : DevExpress.XtraEditors.XtraForm
    {
        BLL_XuLyViPham vp = new BLL_XuLyViPham();
        BLL_ThueMatBang thueMB = new BLL_ThueMatBang();
        string maNV;
        bool check = false;
        public FrmXuLyViPham(string maNV)
        {
            InitializeComponent();
            txtNhanVien.Text = maNV;
            this.maNV = maNV;
        }
        
        #region LoadDuLieu
        private void LoadDSHoSoViPham()
        {
            gcDSViPham.DataSource = vp.LayDSHoSoViPham();
        }
        private void LoadDSViPham()
        {
            txtViPham.Properties.DataSource = vp.LayDSViPham();
        }
        public void LoadCboMaThue()
        {
            txtMaThue.Properties.DataSource = vp.LayDSThueMatBang();
        }
        public void LoadAllMaThue()
        {
            txtMaThue.Properties.DataSource = thueMB.LayDSThueMatBang();
        }
        #endregion

        #region Clean DL
        public void choNhapTextBox(bool tinhTrang)
        {
            txtMaThue.ReadOnly = tinhTrang;
            txtViPham.ReadOnly = tinhTrang;
            txtGhiChu.ReadOnly = tinhTrang;
            txtTienPhat.ReadOnly = tinhTrang;
        }

        public void XoaDuLieuTextBox()
        {
            txtMaThue.EditValue = null;
            txtViPham.EditValue = null;
            txtTienPhat.EditValue = null;
            txtGhiChu.EditValue = null;
            txtNgayLap.EditValue = null;
            txtNgayDong.EditValue = null;
            txtMatBang.EditValue = null;
            txtViTri.EditValue = null;
            txtKhachHang.EditValue = null;
            txtNhanVien.EditValue = null;
            cboTinhTrang.EditValue = null;
        }
        #endregion



        #region Click_BTN
        private void Click_BtnThem()
        {
            XoaDuLieuTextBox();
            btnThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnHuy.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnLuuVP.Visible = true;
            btnNhapLai.Visible = true;
            btnHuyVP.Visible = true;
            check = true;
            choNhapTextBox(false);
            cboTinhTrang.SelectedIndex = 1;
            txtMaHS.Text = vp.LayMaXuLyTuSinh();
            txtNhanVien.Text = maNV;
            txtNgayLap.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtMaThue.Focus();
        }
        private void Click_BtnSua()
        {
            btnThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnHuy.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnLuuVP.Visible = true;
            btnNhapLai.Visible = true;
            btnHuyVP.Visible = true;
            check = true;
        }
        private void Click_BtnLuu()
        {
            btnThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnHuy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnLuuVP.Visible = false;
            btnNhapLai.Visible = false;
            btnHuyVP.Visible = false;
            check = false;
           
            choNhapTextBox(true);
            //choNhapTextBox(true);
        }
        private void Click_BtnHuy()
        {
            btnThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnHuy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnLuuVP.Visible = false;
            btnNhapLai.Visible = false;
            btnHuyVP.Visible = false;
            choNhapTextBox(true);
            //choNhapTextBox(true);   
            check = false;
        }
        #endregion
        private void btnThem_ItemClick(object sender, ItemClickEventArgs e)
        {
            Click_BtnThem();
            LoadCboMaThue();
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
            errorProvider1.Clear();
            if (txtMaThue.EditValue== null)
            {
                MessageBox.Show("Mã thuê không hợp lệ","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                errorProvider1.SetError(txtMaThue,"Hãy chọn lại mã thuê");
                txtMaThue.Focus();
                return;
            }
            if (txtViPham.EditValue == null)
            {
                MessageBox.Show("Vi phạm không hợp lê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(txtViPham, "Hãy chọn lại vi phạm");
                txtViPham.Focus();
                return;
            }
        }

        private void btnHuy_ItemClick(object sender, ItemClickEventArgs e)
        {
            Click_BtnHuy();
            dgvDSViPham_FocusedRowChanged(null, null);
        }

        private void FrmXuLyViPham_Load(object sender, EventArgs e)
        {
            LoadDSViPham();
            LoadAllMaThue();
            LoadDSHoSoViPham();          
        }

        private void txtMaThue_EditValueChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            var tt = vp.LayThongTinThueMB(txtMaThue.Text);
            if(tt!=null)
            {
                txtMatBang.Text = tt.DangKyThue.MatBang;
                txtViTri.Text = tt.DangKyThue.MatBang1.ViTri.ToString();
                txtKhachHang.Text = tt.DangKyThue.MaKhachHang;
            }   
            else
            {
                LoadAllMaThue();
                txtMatBang.Text = "";
                txtViTri.Text = "";
                txtKhachHang.Text = "";
            }    
          
        }

        private void dgvDSViPham_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (check)
                return;
            var tt = vp.LayThongTinHoSoVP((string)dgvDSViPham.GetFocusedRowCellValue(colMaHSViPham));
            if(tt!=null)
            {
                txtMaHS.Text = tt.MaHSViPham;
                txtMaThue.Text = tt.MaThueMB;
                txtNgayDong.Text = string.Format("{0:dd/MM/yyyy}", tt.NgayDongTien);
                txtNgayLap.Text = string.Format("{0:dd/MM/yyyy}", tt.NgayLap);
                txtTienPhat.Text = string.Format("{0:0,0 vnđ}", tt.TongTienPhat);
                txtViPham.EditValue = tt.MaViPham;
                cboTinhTrang.Text= dgvDSViPham.GetFocusedRowCellValue(colTinhTrang).ToString();
                txtGhiChu.Text = tt.GhiChu;
            }    
           
        }

        private void txtViPham_EditValueChanged(object sender, EventArgs e)
        {
            if (!check)
                return;
            errorProvider1.Clear();
            if (txtMaThue.EditValue==null)
            {
                MessageBox.Show("Bạn chưa chọn mã thuê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(txtMaThue, "Hãy chọn mã thuê");
            }    
            if(txtViPham.EditValue.Equals("AEON_MVP0002"))
            {
                if(vp.KiemTraCoViPhamPhiDichVu("AEON_MVP0002"))
                {
                    MessageBox.Show("Mã thuê "+ txtMaThue.EditValue+" đã thanh toán hóa đơn dịch vụ điện nước bạn không thể tạo vi phạm này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorProvider1.SetError(txtMaThue, "Hãy chọn mã thuê");
                    return;
                }    


                if(vp.KiemTraViPhamPhiDichVu())
                {
                    MessageBox.Show("Vi phạm :"+txtViPham.Text+" trong tháng "+DateTime.Now.Month+"/"+ DateTime.Now.Year+ 
                        " của mã thuê "+txtMaThue.EditValue+" đã tổn tại",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorProvider1.SetError(txtViPham, "Hãy chọn lại vi phạm");
                    return;
                }    
            }else
            {
                if(txtViPham.EditValue!=null)
                {
                    if (vp.KiemTraViPham(txtViPham.EditValue.ToString()))
                    {
                        MessageBox.Show("Vi phạm :" + txtViPham.Text +"của mã thuê "+ txtMaThue.EditValue + " đã tổn tại",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        errorProvider1.SetError(txtViPham, "Hãy chọn lại vi phạm");
                    }
                }    
                  
            }    
        }

        private void txtTienPhat_EditValueChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void txtTienPhat_KeyPress(object sender, KeyPressEventArgs e)
        {          
            if(txtTienPhat.Properties.ReadOnly)
            {
                return;
            }    
            errorProvider1.Clear();
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(txtTienPhat, "Tiền phạt chỉ cho nhập số");
            }
        }

        private void txtTienPhat_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (txtTienPhat.Properties.ReadOnly)
            {
                return;
            }
            if (check)
            {
                if (txtTienPhat.Text.Length > 0)
                {
                    try
                    {
                        int tien = int.Parse(txtTienPhat.EditValue.ToString());
                        txtTienPhat.Text = string.Format("{0:0,0 vnđ}", tien);
                    }
                    catch (Exception)
                    {
                        return;
                        throw;
                    }
                }
            }
        }
    }
}