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
using DAL;
using Model;
using DevExpress.XtraEditors;
using BLL;
using DevExpress.XtraEditors.Controls;
using Liz.DoAn;
using DevExpress.Utils;

namespace QL_MatBangTTTM
{

    public partial class FrmDangKy : DevExpress.XtraEditors.XtraForm
    {
        BLL_ThueMatBang thueMB = new BLL_ThueMatBang();
        List<int> listViTriSua;
        List<int> listViTriThem;
        int dem = 0;
        List<string> listHD;
        List<string> listLH;
        int trangThai = -1;
        string maNVDN;
        public FrmDangKy(string maNV)
        {
            InitializeComponent();
            GridLocalizer.Active = new MyGridLocalizer();
            txtNgayLap.Text = DateTime.Now.ToString("dd/MM/yyyy");
            listViTriSua = new List<int>();
            listViTriThem = new List<int>();
            listHD = new List<string>();
            listLH = new List<string>();
            maNVDN = maNV;
        }
        public void loadDSMBChuaThue()
        {
            repositoryItemMatBang.DataSource = thueMB.LayDSMatBang();
        }
        public void loadDSKhachHang()
        {
            BLL_KhachHang kh = new BLL_KhachHang();
            repositoryItemKhachHang.DataSource = kh.layDSKhachHang();
        }

        private void FrmDangKy_Load(object sender, EventArgs e)
        {
            LoadDSThue();
        }
        private void LoadDSThue()
        {
            BindingList<DangKyThueModel> bindingList = new BindingList<DangKyThueModel>(thueMB.LayDSDKThueMatBang());
            this.gcDSDKThue.DataSource = bindingList;
            GridLocalizer.Active = new MyGridLocalizer();
            dem = dgvDSDKThue.RowCount;
            loadDSMBChuaThue();
            loadDSKhachHang();
        }

        private void btnThem_ItemClick(object sender, ItemClickEventArgs e)
        {
            dgvDSDKThue.AddNewRow();
        }

        private void dgvDSDKThue_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            int dem = dgvDSDKThue.RowCount;
            string madk = thueMB.LayMaDKTuSinh(dem);
            DateTime ngayMoCuaToiThieu = DateTime.Today.AddDays(31);
            dgvDSDKThue.SetRowCellValue(e.RowHandle, colMaDK, madk);
            dgvDSDKThue.SetRowCellValue(e.RowHandle, colNgayLap, DateTime.Now);
            dgvDSDKThue.SetRowCellValue(e.RowHandle, colThoiHanThue, 1);
            dgvDSDKThue.SetRowCellValue(e.RowHandle, colNgayMoCua, ngayMoCuaToiThieu);
            //dgvDSDKThue.SetRowCellValue(e.RowHandle, colTinhTrang, 321123);
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if(dgvDSDKThue.GetFocusedRowCellDisplayText(colTinhTrang).ToString().Equals("Đã xử lý"))
            {
                MessageBox.Show("Phiếu đăng ký thuê này đã xử lý không thể tạo lịch hẹn");
                return;
            }    
            string maLH = dgvDSDKThue.GetFocusedRowCellDisplayText(colLichHen).ToString();
            string maHD = dgvDSDKThue.GetFocusedRowCellDisplayText(colHoaDon).ToString();
            int trangthai = -1;
            var hoaDon = thueMB.HoaDonGiuCho(maHD);
            if(hoaDon==null)
            {
                MessageBox.Show("Khách hàng chưa có hoá đơn giữ chỗ");
                return;
            }    
            else
            {
                trangthai = (int)hoaDon.TrangThai;
            }    
     
            if (!string.IsNullOrEmpty(maLH))
            {
                MessageBox.Show("Bạn đã có lịch hẹn không thể thêm lịch hẹn nữa");
                return;
            }
            else if (trangthai == 0)
            {
                MessageBox.Show("Bạn phải thanh toán hóa đơn rồi mới có thể tạo lịch hẹn");
                return;
            }
            else
            {
                FrmTaoLichHen taoLichHen = new FrmTaoLichHen(maNVDN, maHD, txtMaDK.Text);
                taoLichHen.ShowDialog();
                dgvDSDKThue.SetRowCellValue(dgvDSDKThue.FocusedRowHandle, colLichHen, taoLichHen.MaLichHen());
                if(!string.IsNullOrEmpty(taoLichHen.MaLichHen()))
                    listLH.Add(taoLichHen.MaLichHen());
            }

        }

        private void repositoryItemHoaDon_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (dgvDSDKThue.GetFocusedRowCellDisplayText(colTinhTrang).ToString().Equals("Đã xử lý"))
            {
                MessageBox.Show("Phiếu đăng ký thuê này đã xử lý không thể tạo hóa đơn");
                return;
            }
            string maHD = dgvDSDKThue.GetRowCellDisplayText(dgvDSDKThue.FocusedRowHandle, colHoaDon).ToString();
            string maMB = dgvDSDKThue.GetRowCellDisplayText(dgvDSDKThue.FocusedRowHandle, colMaMatBang).ToString();
            string maDK = dgvDSDKThue.GetRowCellDisplayText(dgvDSDKThue.FocusedRowHandle, colMaDK).ToString();
            var ttMB = thueMB.LayThongTinMB(maMB);
            if(ttMB!=null)
            {
                if(ttMB.TinhTrang!=1&& ttMB.TinhTrang != -1 )
                {
                    MessageBox.Show("Mặt bằng này đã có người thuê hiện tại bạn không thể đặt cọc");
                    return;
                }    
            }    
            if (string.IsNullOrEmpty(maHD))
            {
                if (string.IsNullOrEmpty(maMB))
                {
                    MessageBox.Show("Bạn chưa chọn mặt bằng");
                    return;
                }
                FrmTaoHoaDon taoHoaDon = new FrmTaoHoaDon(maMB, maDK);
                taoHoaDon.ShowDialog();
                dgvDSDKThue.SetRowCellValue(dgvDSDKThue.FocusedRowHandle, colHoaDon, taoHoaDon.MaHoaDon());
                listHD.Add(taoHoaDon.MaHoaDon());
                trangThai = taoHoaDon.TrangThai();
            }
            else
            {
                MessageBox.Show("Phiếu đăng ký " + maHD + " đã có hóa đơn tiền cọc rồi");
                return;
            }
        }

        private void btnLuu_ItemClick(object sender, ItemClickEventArgs e)
        {
            bool check = true;
            dgvDSDKThue.FocusedRowHandle = 1;
            DangKyThue dk = new DangKyThue();
            string maDK, lichHen, matBang, khachHang, hoaDon;
            DateTime ngaylap, ngayMoCua;
            int tinhTrang, thoiHanThue;
            if (listViTriSua.Count > 0)
            {
                foreach (var item in listViTriSua)
                {
                    maDK = dgvDSDKThue.GetRowCellDisplayText(item, colMaDK).ToString();
                    ngaylap = Commons.ConvertStringToDate(dgvDSDKThue.GetRowCellDisplayText(item, colNgayLap).ToString());
                    ngayMoCua = Commons.ConvertStringToDate(dgvDSDKThue.GetRowCellDisplayText(item, colNgayMoCua).ToString());
                    thoiHanThue = int.Parse(dgvDSDKThue.GetRowCellDisplayText(item, colThoiHanThue).ToString());
                    lichHen = dgvDSDKThue.GetRowCellDisplayText(item, colLichHen).ToString();
                    matBang = dgvDSDKThue.GetRowCellDisplayText(item, colMatBang).ToString();
                    khachHang = dgvDSDKThue.GetRowCellValue(item, colKhachHang).ToString();
                    hoaDon = dgvDSDKThue.GetRowCellDisplayText(item, colHoaDon).ToString();
                    //tinhTrang =int.Parse(dgvDSDKThue.GetRowCellDisplayText(item, colMaDK));
                    TimeSpan ktNgay = ngayMoCua - ngaylap;
                    if (ktNgay.Days <= 30)
                    {
                        MessageBox.Show("Ngày mở cửa phải lớn hơn ngày hiện tại 30 ngày");
                        return;
                    }
                    if (string.IsNullOrEmpty(khachHang))
                    {
                        MessageBox.Show("Ở dòng " + item + " bạn chưa chọn khách hàng");
                        dgvDSDKThue.FocusedRowHandle = item;
                        return;
                    }
                   
                    dk.MaDK = maDK;
                    dk.NgayLap = ngaylap;
                    dk.NgayMoCua = ngayMoCua;
                    dk.ThoiHanThue = thoiHanThue;
                    dk.LichHen = lichHen;
                    dk.MatBang = matBang;
                    dk.MaKhachHang = khachHang;
                    if (!string.IsNullOrEmpty(hoaDon))
                    dk.MaHD = hoaDon;
                    dk.TinhTrang = trangThai;
                    if (!thueMB.SuaDKThueMatBang(dk))
                    {
                        MessageBox.Show("Không thể lưu phiếu thuê " + maDK);
                        check = false;
                    }
                    else
                    {
                        listHD.Remove(hoaDon);
                        listLH.Remove(lichHen);
                        check = true;
                    }

                }
            }
            if (listViTriThem.Count > 0)
            {
                foreach (var item in listViTriThem)
                {
                    int viTriRow = item - 1;//Vì item là đếm phần từ nên vị trí sẽ là trừ 1
                    maDK = dgvDSDKThue.GetRowCellDisplayText(viTriRow, colMaDK).ToString();
                    ngaylap = Commons.ConvertStringToDate(dgvDSDKThue.GetRowCellDisplayText(viTriRow, colNgayLap).ToString());
                    ngayMoCua = Commons.ConvertStringToDate(dgvDSDKThue.GetRowCellDisplayText(viTriRow, colNgayMoCua).ToString());
                    thoiHanThue = int.Parse(dgvDSDKThue.GetRowCellDisplayText(viTriRow, colThoiHanThue).ToString());
                    lichHen = dgvDSDKThue.GetRowCellDisplayText(viTriRow, colLichHen).ToString();
                    matBang = dgvDSDKThue.GetRowCellDisplayText(viTriRow, colMatBang).ToString();
                    khachHang = dgvDSDKThue.GetRowCellDisplayText(viTriRow, colKhachHang).ToString();
                    hoaDon = dgvDSDKThue.GetRowCellDisplayText(viTriRow, colHoaDon).ToString();
                    //tinhTrang = int.Parse(dgvDSDKThue.GetRowCellDisplayText(viTriRow, colMaDK));
                    TimeSpan ktNgay = ngayMoCua - DateTime.Now;
                    if (ktNgay.Days < 30)
                    {
                        MessageBox.Show("Ngày mở cửa phải lớn hơn ngày hiện tại 30 ngày");
                        return;
                    }
                    if (string.IsNullOrEmpty(khachHang))
                    {
                        MessageBox.Show("Bạn chưa chọn khách hàng ở dòng:" + item);
                        dgvDSDKThue.FocusedRowHandle = item;
                        return;
                    }
                    else
                    {
                        khachHang = dgvDSDKThue.GetRowCellValue(viTriRow, colKhachHang).ToString();
                    }
                    if (string.IsNullOrEmpty(matBang))
                    {
                        MessageBox.Show("Bạn chưa chọn mặt bằng ở dòng: " + item);
                        dgvDSDKThue.FocusedRowHandle = viTriRow;
                        return;
                    }

                    if (thueMB.LayThongTinMB(matBang) != null)
                    {
                        if (thueMB.LayThongTinMB(matBang).TinhTrang == 0)
                        {
                            MessageBox.Show("Bạn đã chọn mặt bằng có người đặt cọc ở dòng: " + item);
                            dgvDSDKThue.FocusedRowHandle = viTriRow;
                            return;
                        }
                        if (thueMB.LayThongTinMB(matBang).TinhTrang == -1)
                        {
                            MessageBox.Show("Bạn đã chọn mặt bằng có người thuê ở dòng: " + item);
                            dgvDSDKThue.FocusedRowHandle = viTriRow;
                            return;
                        }
                        dk.MaDK = maDK;
                        dk.NgayLap = ngaylap;
                        dk.NgayMoCua = ngayMoCua;
                        dk.ThoiHanThue = thoiHanThue;
                        dk.LichHen = lichHen;
                        dk.MatBang = matBang;
                        dk.MaKhachHang = khachHang;
                        dk.TinhTrang = trangThai;
                        if (!string.IsNullOrEmpty(hoaDon))
                            dk.MaHD = hoaDon;
                        if (!thueMB.ThemDangKyMatBang(dk))
                        {
                            MessageBox.Show("Không thể lưu phiếu thuê " + maDK);
                            check = false;

                        }
                        else
                        {
                            listHD.Remove(hoaDon);
                            listLH.Remove(lichHen);
                            check = true;
                        }

                    }
                }
            }
                if (listHD.Count > 0)
                {
                    foreach (string item in listHD)
                    {
                        if (!thueMB.XoaHoaDonGiuCho(item))
                        {
                            MessageBox.Show("Lỗi khi xóa hóa đơn");
                        }
                    }
                }
                if (listLH.Count > 0)
                {
                    foreach (string item in listLH)
                    {
                        if (!thueMB.XoaLichHen(item))
                        {
                            MessageBox.Show("Lỗi khi xóa lịch hẹn");
                        }
                    }
                }
                listViTriSua.Clear();
                listViTriThem.Clear();
                listHD.Clear();
                listLH.Clear();
                LoadDSThue();
                if (check)
                {
                    MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }
        public void LayThongTinTienCoc(string mahd)
        {
            if (!string.IsNullOrEmpty(mahd))
            {
                var tienCoc = thueMB.HoaDonGiuCho(mahd);
                string tien = String.Format("{0:0,0 vnđ}", tienCoc.SoTien);
                txtTienCoc.Text = tien;
                txtNgayHetHan.EditValue = tienCoc.NgayHetHan;
            }
            else
            {
                txtTienCoc.Text = "";
                txtNgayHetHan.Text = "";
            }
        }
        public void LayThongTinLichHen(string maLH)
        {
            if (!string.IsNullOrEmpty(maLH))
            {
                var lichHen = thueMB.LayThongTinLichHen(maLH);
                txtLichHen.EditValue = lichHen.NgayHen;
                txtGioBatDau.Text = lichHen.GioBatDau.ToString();
                txtGioKetThuc.Text = lichHen.GioKetThuc.ToString();
            }
            else
            {
                txtLichHen.Text = "";
                txtGioBatDau.Text = "";
                txtGioKetThuc.Text = "";
            }
        }
        private void dgvDSDKThue_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            string maDK = dgvDSDKThue.GetFocusedRowCellDisplayText(colMaDK).ToString();
            if (dem == dgvDSDKThue.RowCount)
            {
                int index = dgvDSDKThue.FocusedRowHandle;
                int kt = listViTriSua.Where(t => t == index).Count();
                if (kt == 0)
                    listViTriSua.Add(index);
            }
            else
            {
                int demRow = dgvDSDKThue.RowCount;
                int kt = listViTriThem.Where(t => t == demRow).Count();
                if (kt == 0)
                    listViTriThem.Add(demRow);
            }
            DoiThongTinTextBox();
        }

        private void dgvDSDKThue_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DoiThongTinTextBox();
            int row = dgvDSDKThue.FocusedRowHandle + 1;
            string maHD = dgvDSDKThue.GetFocusedRowCellDisplayText(colHoaDon).ToString();
            string maLH = dgvDSDKThue.GetFocusedRowCellDisplayText(colLichHen).ToString();
            string maMB = dgvDSDKThue.GetFocusedRowCellDisplayText(colMatBang).ToString();
            LayThongTinTienCoc(maHD);
            LayThongTinLichHen(maLH);
            if (string.IsNullOrEmpty(maMB))
            {
                repositoryItemMatBang.ReadOnly = false;
            }
            else
            {
                repositoryItemMatBang.ReadOnly = true;
            }
            foreach (int item in listViTriThem)
            {
                if (item == row)
                {
                    repositoryItemMatBang.ReadOnly = false;
                }
            }

        }
        public void DoiThongTinTextBox()
        {
            txtMaDK.Text = dgvDSDKThue.GetFocusedRowCellDisplayText(colMaDK).ToString();
            txtNgayLap.Text = dgvDSDKThue.GetFocusedRowCellDisplayText(colNgayLap).ToString();
            txtNgayMoCua.Text = dgvDSDKThue.GetFocusedRowCellDisplayText(colNgayMoCua).ToString();
            txtThoiHanThue.Text = dgvDSDKThue.GetFocusedRowCellDisplayText(colThoiHanThue).ToString();
            txtKhachHang.Text = dgvDSDKThue.GetFocusedRowCellDisplayText(colKhachHang).ToString();
            txtTinhTrang.Text = dgvDSDKThue.GetFocusedRowCellDisplayText(colTinhTrang).ToString();
            txtMaMatBang.Text = dgvDSDKThue.GetFocusedRowCellDisplayText(colMatBang).ToString();
        }
        private void repositoryItemMatBang_ButtonClick(object sender, ButtonPressedEventArgs e)
        {

            /*string maMB= dgvDSDKThue.GetFocusedRowCellDisplayText(colMatBang).ToString();
             //int row = dgvDSDKThue.FocusedRowHandle;
             if (!string.IsNullOrEmpty(maMB))
             {
                 MessageBox.Show("Đã có mặt bằng rông thể chọn");
                // dgvDSDKThue.FocusedRowHandle = row;
                 return;
             }  */
        }

        private void repositoryItemMatBang_EditValueChanged(object sender, EventArgs e)
        {
            /*string maMB = dgvDSDKThue.GetFocusedRowCellDisplayText(colMaMatBang).ToString();
            string khachHang = dgvDSDKThue.GetFocusedRowCellValue(colMaMatBang).ToString();
            var matBang = thueMB.LayThongTinMB(maMB);
            if (matBang != null)
            {
                if (matBang.TinhTrang == 0)
                {
                    MessageBox.Show("Mặt bằng này đã có người đặt cọc");
                    return;
                }
                if (matBang.TinhTrang == -1)
                {
                    MessageBox.Show("Mặt bằng này đã có người thuê");
                    return;
                }
            }*/

        }

        private void FrmDangKy_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (listHD.Count > 0)
            {
                foreach (string item in listHD)
                {
                    if (!thueMB.XoaHoaDonGiuCho(item))
                    {
                        MessageBox.Show("Lỗi khi xóa hóa đơn");
                    }
                }
            }
            if (listLH.Count > 0)
            {
                foreach (string item in listLH)
                {
                    if (!thueMB.XoaLichHen(item))
                    {
                        MessageBox.Show("Lỗi khi xóa lịch hẹn");
                    }
                }
            }
        }
    }
}
    