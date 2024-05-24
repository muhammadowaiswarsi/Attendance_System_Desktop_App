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
    public partial class AttendanceActivity : Form
    {
        IAttendanceDetail _attendanceDetail;
        public AttendanceActivity(IAttendanceDetail detail)
        {
            InitializeComponent();
            this._attendanceDetail = detail;
        }

        private void btn_checkin_Click(object sender, EventArgs e)
        {
            try
            {
                btn_checkin.Enabled = false;
                string message = this._attendanceDetail.Save_Attendace(new AttendanceDetailDB() { UserId = Repo.userdb.UserId, AttendanceType = "IN" });
                if (message.Equals("OK"))
                {
                    MessageBox.Show("Data Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btn_checkin.Enabled = true;
            }
        }

        private void btn_checkout_Click(object sender, EventArgs e)
        {
            try
            {
                btn_checkout.Enabled = false;
                string message = this._attendanceDetail.Save_Attendace(new AttendanceDetailDB() { UserId = Repo.userdb.UserId, AttendanceType = "OUT" });
                if (message.Equals("OK"))
                {
                    MessageBox.Show("Data Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btn_checkout.Enabled = true;
            }
        }
    }
}
