using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.Models
{
    public class AttendanceDetailDB
    {
        public int UserId { get; set; }
        public string AttendanceType { get; set; } = "";
        public string Date { get; set; } = "";
        public string Time { get; set; } = "";
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Save_AttendanceDetail()
        {
            string query = "INSERT INTO AttendanceDetail VALUES (@UserId,GetDate(),@AttendanceType,1)";
            SqlCommand sc = new SqlCommand(query, Connection.Get_Connection());
            sc.CommandType = System.Data.CommandType.Text;
            sc.Parameters.AddWithValue("UserId", this.UserId);
            sc.Parameters.AddWithValue("AttendanceType", this.AttendanceType);
            int result = sc.ExecuteNonQuery();
            if (result == 1)
            {
                return "OK";
            }
            return "Data Not Saved";
        }
        public DataTable Get_AttendanceDetailByUserId()
        {
            string query = "Select FORMAT(AttendanceTime,'dd/MM/yyyy') As Date,FORMAT(AttendanceTime,'hh:mm tt') As Time,AttendanceType from AttendanceDetail Where Status = 1 AND UserId = @userid AND FORMAT(AttendanceTime,'dd/MM/yyyy') BETWEEN FORMAT(@fromdate,'dd/MM/yyyy') AND FORMAT(@todate,'dd/MM/yyyy')";
            SqlCommand sc = new SqlCommand(query, Connection.Get_Connection());
            sc.CommandType = CommandType.Text;
            sc.Parameters.AddWithValue("@userid", this.UserId);
            sc.Parameters.AddWithValue("@fromdate", this.FromDate);
            sc.Parameters.AddWithValue("@todate", this.ToDate);
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
    }
}
