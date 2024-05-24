using BusinessLogics.Services;
using DatabaseAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AttendanceSystem
{
    
    public partial class AdminLogin : Form
    {
        IUsers _users;
        IAttendanceDetail _attendanceDetail;
        public AdminLogin(IUsers users,IAttendanceDetail detail)
        {
            InitializeComponent();
            this._users = users;
            this._attendanceDetail = detail;
        }

        public void LoginFunction()
        {
            try
            {
                
                UsersDB users = this._users.Admin_Login(new UsersDB()
                {
                    EmailAddress = txt_name.Text ?? "",
                    Password = txt_pass.Text ?? ""
                });
                if (users.UserId > 0)
                {
                    txt_name.Clear();
                    txt_pass.Clear();
                    Repo.userdb = users;
                    this.Hide();
                    MainMenu mm = new MainMenu(this._attendanceDetail,this._users);
                    mm.ShowDialog();
                    this.Show();
                    txt_name.Focus();
                }
                else
                {
                    txt_name.Clear();
                    txt_pass.Clear();
                    txt_name.Focus();
                    MessageBox.Show("Incorrect Email Address or Passowrd", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginFunction();
        }

        

        
        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{TAB}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button1_Enter(object sender, EventArgs e)
        {
            LoginFunction();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Environment.Exit(0);
            Cursor.Current = Cursors.Default;
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
