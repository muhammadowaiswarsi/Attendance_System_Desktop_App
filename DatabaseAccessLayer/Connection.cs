using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer
{
    internal class Connection
    {
        public static SqlConnection Get_Connection()
        {
            SqlConnection SqlConnection = new SqlConnection();
            SqlConnection.ConnectionString = @"Data Source=DESKTOP-UAMCB00\SQLEXPRESS;Initial Catalog=AttendanceSystem; User ID = sa; Password = Hello123!";
            SqlConnection.Open();
            return SqlConnection;
        }
    }
}
