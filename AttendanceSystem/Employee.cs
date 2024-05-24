using BusinessLogics.Services;
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
    public partial class Employee : Form
    {
        IUsers _users;
        public Employee(IUsers users)
        {
            InitializeComponent();
            this._users = users;
        }
        int edit = 0;
        private void ChartofAccount_Load(object sender, EventArgs e)
        {
            try
            {
                CreateTableHeader();
                GetAllData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CreateTableHeader()
        {
            dataGridView1.Columns.Add("UserId", "User ID");
            dataGridView1.Columns.Add("FirstName", "First Name");
            dataGridView1.Columns.Add("LastName", "Last Name");
            dataGridView1.Columns.Add("EmailAddress", "Email Address");

            dataGridView1.Columns[0].DataPropertyName = "UserId";
            dataGridView1.Columns[0].Visible = false;

            dataGridView1.Columns[1].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].DataPropertyName = "FirstName";

            dataGridView1.Columns[2].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].DataPropertyName = "LastName";

            dataGridView1.Columns[3].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].DataPropertyName = "EmailAddress";


            DataGridViewButtonColumn editbutton = new DataGridViewButtonColumn();
            dataGridView1.Columns.Add(editbutton);
            editbutton.HeaderText = "Edit";
            editbutton.Text = "Edit";
            editbutton.Name = "Edit";
            editbutton.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn deletebtn = new DataGridViewButtonColumn();
            dataGridView1.Columns.Add(deletebtn);
            deletebtn.HeaderText = "Delete";
            deletebtn.Text = "Delete";
            deletebtn.Name = "Delete";
            deletebtn.UseColumnTextForButtonValue = true;

            dataGridView1.Columns[4].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[5].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;

        }
        private void GetAllData()
        {
            try
            {
                DataTable dt = this._users.Employee_GetAll();
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_clear_Click(object sender, EventArgs e)
        {
            try
            {
                edit = 0;
                txt_email.Clear();
                txt_first.Clear();
                txt_last.Clear();
                txt_password.Clear();
                txt_confirm.Clear();
                btn_save.Text = "Save";
                txt_first.Focus();
                GetAllData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (edit == 0)
                {
                    if (string.IsNullOrWhiteSpace(txt_password.Text))
                    {
                        MessageBox.Show("Password & Confirm Password Field Required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (string.IsNullOrWhiteSpace(txt_email.Text))
                {
                    MessageBox.Show("Email Address Field Required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txt_confirm.Text != txt_password.Text)
                {
                    MessageBox.Show("Password & Confirm Password Not Matched", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string message = this._users.Employee_Save(new DatabaseAccessLayer.Models.UsersDB()
                {
                    EmailAddress = txt_email.Text,
                    FirstName = txt_first.Text,
                    LastName = txt_last.Text,
                    Password = txt_password.Text,
                    UserId = edit
                });
                if (message.Equals("OK"))
                {
                    MessageBox.Show(edit > 0 ? "Employee Updated Successfully" : "Employee Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btn_clear.PerformClick();
                }
                else
                {
                    MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_first.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int row = e.RowIndex;
                if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
                {
                    edit = Convert.ToInt32(dataGridView1.Rows[row].Cells[4].Value.ToString());
                    txt_first.Text = dataGridView1.Rows[row].Cells[2].Value.ToString();
                    txt_last.Text = dataGridView1.Rows[row].Cells[3].Value.ToString();
                    txt_email.Text = dataGridView1.Rows[row].Cells[5].Value.ToString();
                    btn_save.Text = "Update";
                    txt_first.Focus();
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
                {
                    int delete = 0;

                    delete = Convert.ToInt32(dataGridView1.Rows[row].Cells[4].Value.ToString());
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this Employee", "Permission", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.OK)
                    {
                        string message = this._users.Employee_Delete(delete);
                        if (message == "OK")
                        {
                            MessageBox.Show("Employee Delete Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            GetAllData();
                            btn_clear.PerformClick();
                        }
                        else
                        {
                            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
