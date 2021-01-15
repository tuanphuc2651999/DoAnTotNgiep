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

namespace QL_MatBangTTTM
{
    public partial class FrmThongKeDanhThu : DevExpress.XtraEditors.XtraForm
    {
        BLL_ThongKe tk = new BLL_ThongKe();
        public FrmThongKeDanhThu()
        {
            InitializeComponent();
            PushThongBao res = new PushThongBao();
            APIInput input = new APIInput();
            input.to= "dbv6GQTeiFM:APA91bGGRpUruFoBgrilCCFvW_j7G_RTcExUii30CJ0hTKAndaa0o4c_nXrkNddf5yghTphUM7dD2hoZdsMHcVJKLUNA6ZTPdJUsfeFLtqYQt8rgq5G9RhwbakedtEquIMrO5EvN54pv";
            Notification notification = new Notification();

            notification.title="Đây là tile";
            notification.body = "Đây là body";
            notification.mutable_content = true;
            notification.sound = "Tri-tone";
            input.notification = notification;
            
            GuiThongBao guiThongBao = new GuiThongBao();
            //guiThongBao.Load(input);
                      var result = guiThongBao.ThongBaoAsync(input);

            var db = tk.DoanhThu();
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