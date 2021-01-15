using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liz.DoAn
{
    public enum Status
    {
        Active = 1,
        Inactive = -1,
        Pending = -2,
        Locked = 0
    }
    public enum StatusTaiKhoan
    {
        NewAccount = 0,
        Locked = -1,
        Active = 1
    }
    public enum StatusMatBang
    {
        Locked = -1,
        Empty = 0,
        Rented = 1,
    }
}
