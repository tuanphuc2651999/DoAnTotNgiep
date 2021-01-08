using DevExpress.XtraGrid.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_MatBangTTTM
{
    public class MyGridLocalizer : GridLocalizer
    {
        public override string GetLocalizedString(GridStringId id)
        {
            switch (id)
            {
                case GridStringId.FindControlFindButton:
                    return "Tìm";
                case GridStringId.FindControlClearButton:
                    return "Xóa";
                default:
                    return base.GetLocalizedString(id);
            }
        }
    }
}
