using BusinessLogics.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AttendanceSystem
{
    public partial class MainMenu : Form
    {
        IAttendanceDetail _attendanceDetail;
        IUsers _users;
        public MainMenu(IAttendanceDetail detail, IUsers users)
        {
            InitializeComponent();
            this._attendanceDetail = detail;
            this._users = users;
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            if (Repo.userdb.UserType == "A")
            {
                employeeToolStripMenuItem.Text = "Employee";
            }
            else
            {
                employeeToolStripMenuItem.Text = "Attendance";
            }
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Repo.userdb.UserType == "A")
            {
                new Employee(this._users).ShowDialog();
            }
            else
            {
                new AttendanceActivity(this._attendanceDetail).ShowDialog();
            }
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Report(this._users, this._attendanceDetail).ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
