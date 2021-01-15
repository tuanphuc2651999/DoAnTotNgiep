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
using Model;
using BLL;
using DAL;

namespace QL_MatBangTTTM
{
    public partial class FrmMatBang : DevExpress.XtraEditors.XtraForm
    {
        BLL_MatBang matBang = new BLL_MatBang();

        public FrmMatBang(string maNV)
        {
            InitializeComponent();
            GridLocalizer.Active = new MyGridLocalizer();
        }

        private void FrmMatBang_Load(object sender, EventArgs e)
        {
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnHuy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnCapNhatGia.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            txtMaMB.ReadOnly = true;
            txtViTri.ReadOnly = true;
            txtDienTich.ReadOnly = true;
            gLUEGia.ReadOnly = false;
            cboTinhTrang.ReadOnly = true;
            gLUETang.ReadOnly = true;
            gLUELoaiMB.ReadOnly = true;
            gLUEKhuVuc.ReadOnly = true;

            BindingList<TTMatBangModel> bindingList = new BindingList<TTMatBangModel>(matBang.LayDSTTMatBang());
            this.gCDSMatBang.DataSource = bindingList;
            GridLocalizer.Active = new MyGridLocalizer();
            LayThongTinLenTextBox();
            LayTatCaBangLienQuan();

        }
        #region Lấy dữ liệu
        private void LayTatCaBangLienQuan()
        {
            gLUEKhuVuc.Properties.DataSource = matBang.LayDSKhuVuc();
            gLUELoaiMB.Properties.DataSource = matBang.LayDSLoaiMB();
            gLUETang.Properties.DataSource = matBang.LayDSTang();
            gLUEGia.Properties.DataSource = matBang.LayDSGiaThue();
        }

        private void LayThongTinLenTextBox()
        {
            gLUEGia.EditValue = dgvMatBang.GetFocusedRowCellDisplayText(colMaGia);
            txtDienTich.EditValue = dgvMatBang.GetFocusedRowCellDisplayText(colDienTich);
            txtMaMB.EditValue = dgvMatBang.GetFocusedRowCellDisplayText(colMaMB);
            txtViTri.EditValue = dgvMatBang.GetFocusedRowCellDisplayText(colViTri);

            gLUETang.EditValue = dgvMatBang.GetFocusedRowCellDisplayText(colMaTang);
            gLUELoaiMB.EditValue = dgvMatBang.GetFocusedRowCellDisplayText(colMaLoaiMB);
            gLUEKhuVuc.EditValue = dgvMatBang.GetFocusedRowCellDisplayText(colMaKhuVuc);
            cboTinhTrang.EditValue = dgvMatBang.GetFocusedRowCellDisplayText(colTinhTrang);
        }
        #endregion

        private void btnXoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                DialogResult r = MessageBox.Show("Bạn có chắc muốn xóa mặt bằng " + txtMaMB.EditValue.ToString().Trim() + " không?", "Thông báo"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (r == DialogResult.Yes)
                {
                    //SplashScreenManager.ShowForm(this, typeof(WaitLoadFrm));
                    MatBang mb = new MatBang();
                    mb.MaMB = txtMaMB.EditValue.ToString().Trim();
                    if (matBang.XoaMatBang(mb))
                    {
                        MessageBox.Show("Xóa mặt bằng với mã mặt bằng " + txtMaMB.EditValue.ToString().Trim()+" thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FrmMatBang_Load(null, null);
                        //SplashScreenManager.CloseDefaultSplashScreen();
                    }
                    else
                    {
                        MessageBox.Show("Xóa mặt bằng với mã mặt bằng " + txtMaMB.EditValue.ToString().Trim()+" thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FrmMatBang_Load(null, null);
                        //SplashScreenManager.CloseDefaultSplashScreen();
                    }
                }

            }
            catch (Exception ex)
            {
                FrmMatBang_Load(null, null);
                throw;
            }
        }



        private void btnThem_ItemClick(object sender, ItemClickEventArgs e)
        {
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnCapNhatGia.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnHuy.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            txtMaMB.ReadOnly = true;
            txtViTri.ReadOnly = false;
            txtDienTich.ReadOnly = false;
            gLUEGia.ReadOnly = false;
            cboTinhTrang.ReadOnly = true;
            gLUETang.ReadOnly = false;
            gLUELoaiMB.ReadOnly = false;
            gLUEKhuVuc.ReadOnly = false;

            dgvMatBang.ClearSelection();

            txtMaMB.ResetText();
            txtViTri.ResetText();
            txtDienTich.ResetText();
            gLUEGia.ResetText();
            gLUETang.ResetText();
            gLUELoaiMB.ResetText();
            gLUEKhuVuc.ResetText();
            cboTinhTrang.ResetText();

            LayTatCaBangLienQuan();

            gLUETang.EditValue = gLUETang.Properties.GetKeyValue(0);
            gLUELoaiMB.EditValue = gLUELoaiMB.Properties.GetKeyValue(0);
            gLUEKhuVuc.EditValue = gLUEKhuVuc.Properties.GetKeyValue(0);
            gLUEGia.EditValue = gLUEGia.Properties.GetKeyValue(0);
            cboTinhTrang.EditValue = 0;
            txtViTri.EditValue = "";
            txtMaMB.EditValue = matBang.LayMaMBTuSinh();
            //gLUEGia.EditValue = matBang;
            txtDienTich.EditValue = "";
        }

        private void dgvMatBang_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (dgvMatBang.FocusedRowHandle >= 0 && btnThem.Visibility == DevExpress.XtraBars.BarItemVisibility.Always)
            {
                LayTatCaBangLienQuan();
                LayThongTinLenTextBox();
            }
        }

        private void btnHuy_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmMatBang_Load(null, null);
        }

        private void btnSua_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                string maMB = txtMaMB.EditValue.ToString().Trim();
                string maGia = gLUEGia.EditValue.ToString().Trim();

                MatBang m = new MatBang();
                m.MaMB = maMB;
                m.Gia = maGia;
                
                if (matBang.SuaMatBang(m))
                {
                    MessageBox.Show("Cập nhật thành công mặt bằng " +maMB, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                    FrmMatBang_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Cập nhật không thành công mặt bằng " + maMB, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                    FrmMatBang_Load(null, null);
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                MessageBox.Show("Cập nhật không thành công mặt bằng " + txtMaMB.EditValue.ToString().Trim(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                FrmMatBang_Load(null, null);
                throw;
            }
        }

        private void btnLuu_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtViTri.Text.Trim()))
                {
                    MessageBox.Show("Không được để trống vị trí", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtViTri.Focus();
                }
                else if (string.IsNullOrEmpty(txtDienTich.Text.Trim()))
                {
                    MessageBox.Show("Không được để trống diện tích", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDienTich.Focus();
                }
                else if (matBang.KiemTraViTri(Convert.ToInt32(txtViTri.EditValue.ToString().Trim())))
                {
                    MatBang mb = new MatBang();
                    mb.MaMB = txtMaMB.EditValue.ToString().Trim();
                    mb.ViTri = Convert.ToInt32(txtViTri.EditValue.ToString().Trim());
                    mb.TinhTrang = 0;
                    mb.DienTich = Convert.ToInt32(txtDienTich.EditValue.ToString().Trim());
                    mb.Gia = gLUEGia.EditValue.ToString().Trim();
                    mb.MaTang = gLUETang.EditValue.ToString().Trim();
                    mb.LoaiMB = gLUELoaiMB.EditValue.ToString().Trim();
                    mb.MaKhuVuc = gLUEKhuVuc.EditValue.ToString().Trim();
                    if (matBang.LuuMatBang(mb))
                    {
                        MessageBox.Show("Thêm mặt bằng "+mb.MaMB+" thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        FrmMatBang_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("TLưu mặt bằng " + mb.MaMB + " không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        FrmMatBang_Load(null, null);
                    }
                }
                else
                {
                    MessageBox.Show("Vị trí mặt bằng này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lưu không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FrmMatBang_Load(null, null);
                //throw;
            }

        }

        private void txtViTri_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtDienTich_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnCapNhatGia_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                matBang.CapNhatGia();
                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                FrmMatBang_Load(null, null);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                MessageBox.Show("Cập nhật không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FrmMatBang_Load(null, null);
                throw;
            }
        }
    }
}