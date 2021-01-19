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
using DevExpress.XtraGrid.Localization;
using BLL;
using Model;
using DAL;

namespace QL_MatBangTTTM
{
    public partial class FrmDichVu : DevExpress.XtraEditors.XtraForm
    {
        BLL_GiaVaDichVu dichVu = new BLL_GiaVaDichVu();

        public FrmDichVu(string maNV)
        {
            InitializeComponent();
            GridLocalizer.Active = new MyGridLocalizer();
        }

        private void FrmDichVu_Load(object sender, EventArgs e)
        {
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnHuy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            txtMaDichVu.ReadOnly = true;
            txtTenDichVu.ReadOnly = false;
            txtDonViTinh.ReadOnly = false;
            gLUEGia.ReadOnly = true;

            BindingList<DichVuModel> bindingList = new BindingList<DichVuModel>(dichVu.LayDSDichVu());
            this.gCDSDichVu.DataSource = bindingList;
            GridLocalizer.Active = new MyGridLocalizer();
            LayThongTinLenTextBox();
            LayLenCbo();
        }

        private void LayLenCbo()
        {
            gLUEGia.Properties.DataSource = dichVu.LayDSGiaDichVu();
        }

        private void LayThongTinLenTextBox()
        {
            txtMaDichVu.EditValue = dgvDSDichVu.GetFocusedRowCellDisplayText(colMaDichVu);
            txtTenDichVu.EditValue = dgvDSDichVu.GetFocusedRowCellDisplayText(colTenDichVu);
            txtDonViTinh.EditValue = dgvDSDichVu.GetFocusedRowCellDisplayText(colDonViTinh);
            gLUEGia.EditValue = dgvDSDichVu.GetFocusedRowCellDisplayText(colMaGiaDV);
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnHuy.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            txtMaDichVu.ReadOnly = true;
            txtTenDichVu.ReadOnly = false;
            gLUEGia.ReadOnly = false;
            txtDonViTinh.ReadOnly = false;

            txtMaDichVu.ResetText();
            txtTenDichVu.ResetText();
            txtDonViTinh.ResetText();
            gLUEGia.ResetText();

            gLUEGia.EditValue = gLUEGia.Properties.GetKeyValue(0);
            txtMaDichVu.EditValue = dichVu.LayMaDVTuSinh();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string maDV = dgvDSDichVu.GetFocusedRowCellDisplayText(colMaDichVu).ToString().Trim();
            try
            {
                DialogResult r = MessageBox.Show("Bạn có chắc muốn xóa dịch vụ " + maDV + " không?", "Thông báo"
                   , MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (r == DialogResult.Yes)
                {
                    if (dichVu.KiemTraTonTaiMaDichVuTrongChiTietDV(maDV))
                    {
                        if (dichVu.XoaDichVu(maDV))
                        {
                            MessageBox.Show("Xóa thành công dịch vụ với mã: " + maDV, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FrmDichVu_Load(null, null);
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa dịch vụ với mã: " + maDV, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FrmDichVu_Load(null, null);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa dịch vụ với mã: " + maDV + ", vì dịch vụ này đang tồn tại trong chi tiết dịch vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FrmDichVu_Load(null, null);
                    }
                }
                else
                {
                    FrmDichVu_Load(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa giá thuê với mã: " + maDV, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var error = ex;
                FrmDichVu_Load(null, null);
            }
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string maDV = dgvDSDichVu.GetFocusedRowCellDisplayText(colMaDichVu).ToString().Trim();
            try
            {
                string tenDV = txtTenDichVu.EditValue.ToString().Trim();
                string dvt = txtDonViTinh.EditValue.ToString().Trim();

                DichVu dv = new DichVu()
                {
                    MaDichVu = maDV,
                    TenDichVu = tenDV,
                    DonViTinh = dvt,
                };

                if (dichVu.SuaDichVu(dv))
                {
                    MessageBox.Show("Sửa thành công: " + maDV, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmDichVu_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Sửa không thành công: " + maDV, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmDichVu_Load(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa không thành công: " + maDV, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var error = ex;
                FrmDichVu_Load(null, null);
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string maDV = txtMaDichVu.EditValue.ToString().Trim();
            if (string.IsNullOrEmpty(txtTenDichVu.EditValue.ToString().Trim()))
            {
                MessageBox.Show("Không được để trống tên dịch vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenDichVu.Focus();
            }
            else if (string.IsNullOrEmpty(txtDonViTinh.EditValue.ToString().Trim()))
            {
                MessageBox.Show("Không được để trống đơn vị tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDonViTinh.Focus();
            }
            else
            {
                string tenDV = txtTenDichVu.EditValue.ToString().Trim();
                string DVT = txtDonViTinh.EditValue.ToString().Trim();
                string MaGiaDV = gLUEGia.EditValue.ToString().Trim();
                try
                {
                    DichVu dv = new DichVu
                    {
                        MaDichVu = maDV,
                        TenDichVu = tenDV,
                        Gia = MaGiaDV,
                        DonViTinh = DVT,
                    };

                    if (dichVu.ThemDV(dv))
                    {
                        MessageBox.Show("Thêm dịch vụ: " + maDV + " thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FrmDichVu_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Thêm dịch vụ: " + maDV + " không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FrmDichVu_Load(null, null);
                    }

                }
                catch (Exception ex)
                {
                    var er = ex;
                    MessageBox.Show("Thêm dịch vụ: " + maDV + " không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmDichVu_Load(null, null);
                }
            }
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmDichVu_Load(null, null);
        }

        private void dgvDSDichVu_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (dgvDSDichVu.FocusedRowHandle >= 0 && btnThem.Visibility == DevExpress.XtraBars.BarItemVisibility.Always)
            {
                LayThongTinLenTextBox();
            }
        }
    }
}