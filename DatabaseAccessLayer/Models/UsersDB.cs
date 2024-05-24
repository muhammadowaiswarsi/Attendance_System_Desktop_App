using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.Models
{
    public class UsersDB
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string EmailAddress { get; set; } = "";
        public string Password { get; set; } = "";
        public string UserType { get; set; } = "";
        public UsersDB User_Login()
        {
            UsersDB userdb = new UsersDB();
            string query = "Select UserId,FirstName,LastName,UserType from Users Where EmailAddress = @EmailAddress AND Password = @Password AND Status = 1";
            SqlCommand sc = new SqlCommand(query,Connection.Get_Connection());
            sc.CommandType = System.Data.CommandType.Text;
            sc.Parameters.AddWithValue("@EmailAddress", this.EmailAddress);
            sc.Parameters.AddWithValue("@Password", this.Password);
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                userdb = new UsersDB()
                {
                    UserId = Convert.ToInt32(dt.Rows[0]["UserId"]),
                    FirstName = Convert.ToString(dt.Rows[0]["FirstName"]) ?? "",
                    LastName = Convert.ToString(dt.Rows[0]["LastName"]) ?? "",
                    UserType = Convert.ToString(dt.Rows[0]["UserType"]) ?? "",
                };
            }
            return userdb;
        }
        public DataTable Employee_GetAllForDropDown()
        {
            string query = "Select FirstName+' '+LastName As Username,UserID from Users Where UserType = 'E' AND Status = 1";
            SqlCommand sc = new SqlCommand(query, Connection.Get_Connection());
            sc.CommandType = System.Data.CommandType.Text;
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        public DataTable Employee_GetAll()
        {
            string query = "Select FirstName,LastName,UserID,EmailAddress from Users Where UserType = 'E' AND Status = 1";
            SqlCommand sc = new SqlCommand(query, Connection.Get_Connection());
            sc.CommandType = System.Data.CommandType.Text;
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        public string Delete_Employee(int UserId)
        {
            string query = "Update Users Set Status = 0 Where UserId = @UserId";
            SqlCommand sc = new SqlCommand(query, Connection.Get_Connection());
            sc.CommandType = CommandType.Text;
            sc.Parameters.AddWithValue("@UserId", UserId);
            int result = sc.ExecuteNonQuery();
            if (result == 1)
            {
                return "OK";
            }
            return "Employee Not Deleted";
        }
        public string SaveUpdateEmployee()
        {
            string query = "";
            if (this.UserId > 0)
            {
                query += "Update Users Set FirstName = @FirstName,LastName = @LastName,EmailAddress=@EmailAddress Where UserId = @UserId";
                query += Environment.NewLine;
                if (!string.IsNullOrWhiteSpace(this.Password))
                {
                    query += "Update Users Set Password = @Password Where UserId = @UserId";
                }
            }
            else
            {
                query = "Insert into Users Values (@FirstName,@LastName,@EmailAddress,@Password,'E',1)";
            }
            SqlCommand sc = new SqlCommand(query, Connection.Get_Connection());
            sc.CommandType = CommandType.Text;
            sc.Parameters.AddWithValue("@FirstName", this.FirstName ?? "");
            sc.Parameters.AddWithValue("@LastName", this.LastName ?? "");
            sc.Parameters.AddWithValue("@EmailAddress", this.EmailAddress ?? "");
            if (!string.IsNullOrWhiteSpace(this.Password))
            {
                sc.Parameters.AddWithValue("@Password", this.Password);
            }
            if (this.UserId > 0)
            {
                sc.Parameters.AddWithValue("@UserId", this.UserId);
            }
            int result = sc.ExecuteNonQuery();
            if (result > 0)
            {
                return "OK";
            }
            return this.UserId == 0 ? "Data Not Saved" : "Data Not Updated";
        }
    }
}
