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
using BLL;
using Liz.DoAn;
using Model;

namespace QL_MatBangTTTM
{
    public partial class FrmThongKeDanhThu : DevExpress.XtraEditors.XtraForm
    {
        BLL_ThongKe tk = new BLL_ThongKe();
        public FrmThongKeDanhThu()
        {
            InitializeComponent();
            dynamic result = tk.HDTienCoc();
            decimal tong=0;
            foreach (var item in result)
            {
                tong = (decimal)(tong + item.Tong);
            }
            txtTienCoc.Text = String.Format("{0:0,0 vnđ}", tong);


            dynamic dv = tk.HDDichVu();
            decimal tongdv = 0;
            foreach (var item in dv)
            {
                tongdv = (decimal)(tongdv + item.Tong);
            }
            txtTienDV.Text = String.Format("{0:0,0 vnđ}", tongdv);

            dynamic tt = tk.HDTienThue();
            decimal tongtt = 0;
            foreach (var item in tt)
            {
                tongtt = (decimal)(tongtt + item.Tong);
            }
            txtTienThue.Text = String.Format("{0:0,0 vnđ}", tongtt);

            dynamic tgc = tk.HDTienGiuCho();
            decimal tongtgc = 0;
            foreach (var item in tgc)
            {
                tongtgc = (decimal)(tongtgc + item.Tong);
            }

            txtTongTien.Text= String.Format("{0:0,0 vnđ}", tongtt+ tongdv+ tong+ tongtgc);


            /*input.to= "dbv6GQTeiFM:APA91bGGRpUruFoBgrilCCFvW_j7G_RTcExUii30CJ0hTKAndaa0o4c_nXrkNddf5yghTphUM7dD2hoZdsMHcVJKLUNA6ZTPdJUsfeFLtqYQt8rgq5G9RhwbakedtEquIMrO5EvN54pv";
            Notification notification = new Notification();

            notification.title="Đây là tile";
            notification.body = "Đây là body";
            notification.mutable_content = true;
            notification.sound = "Tri-tone";
            input.notification = notification;
            
            GuiThongBao guiThongBao = new GuiThongBao();
            //guiThongBao.Load(input);
                      var result = guiThongBao.ThongBaoAsync(input);*/

            LoadChar();
        }

        public void LoadChar()
        {
            charDoanhThu.DataSource = tk.HDTienThue();
            charDoanhThu.Series["DoanhThu"].XValueMember = "Thang";
            charDoanhThu.Series["DoanhThu"].YValueMembers = "Tong";
        }
    }
}