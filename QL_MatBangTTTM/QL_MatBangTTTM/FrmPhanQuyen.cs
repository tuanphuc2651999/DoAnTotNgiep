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
using Model;

namespace QL_MatBangTTTM
{
    public partial class FrmPhanQuyen : DevExpress.XtraEditors.XtraForm
    {
        BLL_PhanQuyen pq = new BLL_PhanQuyen();
        public FrmPhanQuyen()
        {
            InitializeComponent();
           
        }

        private void FrmPhanQuyen_Load(object sender, EventArgs e)
        {
            gdcNhomND.DataSource = pq.layDSNhomNguoiDung();
        }

        private void btnCapNhatQuyen_ItemClick(object sender, ItemClickEventArgs e)
        {
            string maNhom = dgvDSNhomND.GetFocusedRowCellValue(colMaNhom).ToString();
            for (int i = 0; i < dgvDSChucNang.RowCount; i++)
            {
                string maMH = dgvDSChucNang.GetRowCellValue(i, colMaMH).ToString();
                bool coQuyen = bool.Parse(dgvDSChucNang.GetRowCellValue(i, colCoQuyen).ToString());
                UpdateQuyenModel quyen = new UpdateQuyenModel();
                quyen.MaNhom = maNhom;

                quyen.MaMH = maMH;
                quyen.Quyen = coQuyen;
                if (!pq.capNhatQuyen(quyen))
                {
                    MessageBox.Show("Lỗi");
                    return;
                }
            }

            MessageBox.Show("Cập nhật thành công");
        }

        private void dgvDSNhomND_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //Sự kiện click vào đổi dữ liệu

            if (e.FocusedRowHandle >= 0)
            {
                string value = dgvDSNhomND.GetFocusedRowCellValue(colMaNhom).ToString();
                gdcChucNang.DataSource = pq.layDSQuyen(value);
            }
        }
    }
}