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
using DAL;
using BLL;
using Model;

namespace QL_MatBangTTTM
{
    public partial class FrmGiaThue : DevExpress.XtraEditors.XtraForm
    {
        BLL_GiaVaDichVu giaThue = new BLL_GiaVaDichVu();
        public FrmGiaThue(string maNV)
        {
            InitializeComponent();
            GridLocalizer.Active = new MyGridLocalizer();
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnHuy.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            dgvDSGiaThue.ClearSelection();

            txtMaGiaThue.ReadOnly = true;
            txtTenGiaThue.ReadOnly = false;
            txtGia.ReadOnly = false;
            txtNgayCapNhat.ReadOnly = true;

            txtMaGiaThue.ResetText();
            txtTenGiaThue.ResetText();
            txtGia.ResetText();
            txtNgayCapNhat.ResetText();

            txtMaGiaThue.EditValue = giaThue.LayMaGiaThueTuSinh();
            txtNgayCapNhat.EditValue = DateTime.Now.ToShortDateString();

        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string maGT = dgvDSGiaThue.GetFocusedRowCellDisplayText(colMaGiaThue).ToString().Trim();
            try
            {
                DialogResult r = MessageBox.Show("Bạn có chắc muốn xóa giá thuê " + txtMaGiaThue.EditValue.ToString().Trim() + " không?", "Thông báo"
                   , MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (r == DialogResult.Yes)
                {
                    if (giaThue.KiemTraTonTaiMaGiaThueTrongMatBang(maGT))
                    {
                        if (giaThue.XoaGiaThue(maGT))
                        {
                            MessageBox.Show("Xóa thành công giá thuê với mã: " + maGT, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FrmGiaThue_Load(null, null);
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa giá thuê với mã: " + maGT, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FrmGiaThue_Load(null, null);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa giá thuê với mã: " + maGT + ", vì giá thuê này đang tồn tại trong bảng Mặt Bằng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FrmGiaThue_Load(null, null);
                    }
                }
                else
                {
                    FrmGiaThue_Load(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa giá thuê với mã: " + maGT, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var error = ex;
                FrmGiaThue_Load(null, null);
            }
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string maGT = txtMaGiaThue.EditValue.ToString().Trim();
            try
            {
                int gia = int.Parse(txtGia.EditValue.ToString().Trim());
                GiaThue gt = new GiaThue()
                {
                    MaGiaThue = maGT,
                    Gia = gia,
                };

                if (giaThue.SuaGiaThue(gt))
                {
                    MessageBox.Show("Sửa thành công: " + maGT, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmGiaThue_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Sửa không thành công: " + maGT, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmGiaThue_Load(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa không thành công: " + maGT, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var error = ex;
                FrmGiaThue_Load(null, null);
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string maGT = txtMaGiaThue.EditValue.ToString().Trim();
            if (string.IsNullOrEmpty(txtTenGiaThue.EditValue.ToString().Trim()))
            {
                MessageBox.Show("Không được để trống tên giá thuê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenGiaThue.Focus();
            }
            else if (string.IsNullOrEmpty(txtGia.EditValue.ToString().Trim()))
            {
                MessageBox.Show("Không được để trống giá thuê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGia.Focus();
            }
            else
            {

                string tenGT = txtTenGiaThue.EditValue.ToString().Trim();
                int gia = int.Parse(txtGia.EditValue.ToString().Trim());
                DateTime ngayCapNhat = DateTime.Now;
                try
                {
                    GiaThue gt = new GiaThue
                    {
                        MaGiaThue = maGT,
                        TenGiaThue = tenGT,
                        Gia = gia,
                        NgayCapNhat = ngayCapNhat,
                    };

                    if (giaThue.ThemGiaThue(gt))
                    {
                        MessageBox.Show("Thêm giá thuê: " + maGT + " thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FrmGiaThue_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Thêm giá thuê: " + maGT + " không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FrmGiaThue_Load(null, null);
                    }

                }
                catch (Exception ex)
                {
                    var er = ex;
                    MessageBox.Show("Thêm giá thuê: " + maGT + " không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmGiaThue_Load(null, null);
                }
            }
        }

        private void txtGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void FrmGiaThue_Load(object sender, EventArgs e)
        {
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnHuy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            txtMaGiaThue.ReadOnly = true;
            txtTenGiaThue.ReadOnly = true;
            txtGia.ReadOnly = false;
            txtNgayCapNhat.ReadOnly = true;

            BindingList<GiaThueModel> bindingList = new BindingList<GiaThueModel>(giaThue.LayDSGiaThue());
            this.gCDSGiaThue.DataSource = bindingList;
            GridLocalizer.Active = new MyGridLocalizer();
            LayThongTinLenTextBox();
        }

        private void LayThongTinLenTextBox()
        {
            txtGia.EditValue = dgvDSGiaThue.GetFocusedRowCellDisplayText(colGia);
            txtMaGiaThue.EditValue = dgvDSGiaThue.GetFocusedRowCellDisplayText(colMaGiaThue);
            txtNgayCapNhat.EditValue = dgvDSGiaThue.GetFocusedRowCellDisplayText(colNgayCapNhat);
            txtTenGiaThue.EditValue = dgvDSGiaThue.GetFocusedRowCellDisplayText(colTenGiaThue);
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmGiaThue_Load(null, null);
        }

        private void dgvDSGiaThue_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (dgvDSGiaThue.FocusedRowHandle >= 0 && btnThem.Visibility == DevExpress.XtraBars.BarItemVisibility.Always)
            {
                LayThongTinLenTextBox();
            }

        }
    }
}