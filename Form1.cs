using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace StudentManagementSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (user_input.Text == String.Empty || password_input.Text == String.Empty)
                MessageBox.Show("Please enter user id and password!", "error");
            else
            {
                int check_count = 0;
                if (s_check.Checked)
                    ++check_count;
                if (t_check.Checked)
                    ++check_count;
                if (a_check.Checked)
                    ++check_count;
                if (check_count > 1)
                    MessageBox.Show("Cannot check more than one checkboxes!", "warning");
                else if (check_count == 0)
                    MessageBox.Show("Must check one of the boxes!", "Warning");
                else if (check_count == 1)
                {
                    string user_id = user_input.Text.ToString();
                    string password = password_input.Text.ToString();
                    if (s_check.Checked)
                    {
                        string open = "Server =.; integrated security = SSPI; Initial Catalog = StudentManagement";
                        SqlConnection mysqlConn = new SqlConnection(open);
                        mysqlConn.Open();
                        string sql = "select * from s_account";
                        SqlCommand mysqlCom = new SqlCommand(sql, mysqlConn);

                        SqlDataReader myReader = mysqlCom.ExecuteReader();
                        bool flag = false;
                        while (myReader.Read())
                        {
                            if (user_id.Equals(myReader[0].ToString()) && password.Equals(myReader[1].ToString()))
                            { flag = true; break; }
                        }
                        if (flag)
                        {
                            new Student(user_id).Show();
                            user_input.Clear();
                            password_input.Clear();
                            s_check.Checked = false;
                            mysqlConn.Close();
                            this.Hide();
                        }
                        else
                            MessageBox.Show("Wrong user id or password!", "warning");

                    }
                    else if (t_check.Checked)
                    {
                        string open = "Server =.; integrated security = SSPI; Initial Catalog = StudentManagement";
                        SqlConnection mysqlConn = new SqlConnection(open);
                        mysqlConn.Open();
                        string sql = "select * from t_account";
                        SqlCommand mysqlCom = new SqlCommand(sql, mysqlConn);

                        SqlDataReader myReader = mysqlCom.ExecuteReader();
                        bool flag = false;
                        while (myReader.Read())
                        {
                            if (user_id.Equals(myReader[0].ToString()) && password.Equals(myReader[1].ToString()))
                            { flag = true; break; }
                        }
                        if (flag)
                        {
                            teacher t = new teacher(user_id);
                            t.Show();
                            user_input.Clear();
                            password_input.Clear();
                            t_check.Checked = false;
                            mysqlConn.Close();
                            this.Hide();
                        }
                        else
                            MessageBox.Show("Wrong user id or password!", "warning");
                    }
                    else if (a_check.Checked)
                    {
                        string open = "Server =.; integrated security = SSPI; Initial Catalog = StudentManagement";
                        SqlConnection mysqlConn = new SqlConnection(open);
                        mysqlConn.Open();
                        string sql = "select * from a_account";
                        SqlCommand mysqlCom = new SqlCommand(sql, mysqlConn);

                        SqlDataReader myReader = mysqlCom.ExecuteReader();
                        bool flag = false;
                        while (myReader.Read())
                        {
                            if (user_id.Equals(myReader[0].ToString()) && password.Equals(myReader[1].ToString()))
                            { flag = true; break; }
                        }
                        if (flag)
                        {
                            admin a = new admin(user_id);
                            a.Show();
                            user_input.Clear();
                            password_input.Clear();
                            a_check.Checked = false;
                            mysqlConn.Close();
                            this.Hide();
                        }
                        else
                            MessageBox.Show("Wrong user id or password!", "warning");
                    }
                }

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new ChangePassword().Show();
            this.Hide();
        }
    }
}
