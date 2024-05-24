using DatabaseAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogics.Services
{
    public interface IUsers
    {
        UsersDB Admin_Login(UsersDB user);
        DataTable Employee_GetAllForDropDown();
        DataTable Employee_GetAll();
        string Employee_Delete(int UserId);
        string Employee_Save(UsersDB users);
    }
    public class Users : IUsers
    {
        public UsersDB Admin_Login(UsersDB user)
        {
            return user.User_Login();
        }
        public DataTable Employee_GetAllForDropDown()
        {
            return new UsersDB().Employee_GetAllForDropDown();
        }
        public DataTable Employee_GetAll()
        {
            return new UsersDB().Employee_GetAll();
        }
        public string Employee_Delete(int UserId)
        {
            return new UsersDB().Delete_Employee(UserId);
        }
        public string Employee_Save(UsersDB users)
        {
            return users.SaveUpdateEmployee();
        }
    }
}
