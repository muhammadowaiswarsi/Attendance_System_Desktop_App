using BusinessLogics.Services;
using DatabaseAccessLayer.Models;
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
    public partial class Report : Form
    {
        IUsers _users;
        IAttendanceDetail _attendancedetail;
        public Report(IUsers users,IAttendanceDetail detail)
        {
            InitializeComponent();
            this._users = users;
            this._attendancedetail = detail;
        }

        private void Report_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = this._users.Employee_GetAllForDropDown();
                cb_employee.DataSource = dt;
                cb_employee.ValueMember = dt.Columns[1].ToString();
                cb_employee.DisplayMember = dt.Columns[0].ToString();
                DataRow dr = dt.NewRow();
                dr[1] = 0;
                dr[0] = "--Select Employee--";
                dt.Rows.InsertAt(dr, 0);
                if (Repo.userdb.UserType == "E")
                {
                    cb_employee.SelectedValue = Repo.userdb.UserId;
                    cb_employee.Enabled = false;
                }
                else
                {
                    cb_employee.SelectedIndex = 0;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_search_Click(object sender, EventArgs e)
        {
            try
            {
                if (cb_employee.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Select Employee", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cb_employee.Focus();
                    return;
                }
                DataTable dt = this._attendancedetail.Get_AttendanceDetail(new AttendanceDetailDB() { UserId = Convert.ToInt32(cb_employee.SelectedValue), FromDate = Convert.ToDateTime(fromdate.Value.Date), ToDate = Convert.ToDateTime(todate.Value.Date) });
                dataGridView1.DataSource = dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
