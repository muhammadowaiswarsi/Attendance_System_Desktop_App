using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccessLayer.Models;

namespace BusinessLogics.Services
{
    public interface IAttendanceDetail
    {
        string Save_Attendace(AttendanceDetailDB detail);
        DataTable Get_AttendanceDetail(AttendanceDetailDB detail);
    }
    public class AttendanceDetail : IAttendanceDetail
    {
        public string Save_Attendace(AttendanceDetailDB detail)
        {
            return detail.Save_AttendanceDetail();
        }
        public DataTable Get_AttendanceDetail(AttendanceDetailDB detail)
        {
            return detail.Get_AttendanceDetailByUserId();
        }
    }
}
