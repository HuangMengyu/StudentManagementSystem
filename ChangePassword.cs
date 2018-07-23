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
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = id_in.Text;
            string pass = password_in.Text;
            string pass1 = password_in1.Text;

            if (id.Equals(string.Empty) || pass.Equals(string.Empty) || pass1.Equals(string.Empty))
                MessageBox.Show("Please finish all info!", "warning");
            else if (!pass.Equals(pass1))
                MessageBox.Show("The two password inputs are different!", "warning");
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
                    string open = "Server =.; integrated security = SSPI; Initial Catalog = StudentManagement";
                    SqlConnection mysqlConn = new SqlConnection(open);
                    mysqlConn.Open();
                    if (s_check.Checked)
                    {
                        string sql1 = "select * from s_account where sid = '"+id+"'";
                        SqlCommand myCom1 = new SqlCommand(sql1, mysqlConn);
                        SqlDataReader myReader1 = myCom1.ExecuteReader();
                        
                        if (!myReader1.HasRows)
                            MessageBox.Show("ID not exist!", "warning");
                        else
                        {
                            myReader1.Close();
                            string sql = "update s_account set password = '" + pass + "' where sid = '" + id + "'";
                            SqlCommand myCom = new SqlCommand(sql, mysqlConn);
                            myCom.ExecuteNonQuery();

                            new Form1().Show();
                            this.Close();
                        }

                    }
                    if (t_check.Checked)
                    {
                        string sql1 = "select * from t_account where tid = '" + id + "'";
                        SqlCommand myCom1 = new SqlCommand(sql1, mysqlConn);
                        SqlDataReader myReader1 = myCom1.ExecuteReader();
                        if (!myReader1.HasRows)
                            MessageBox.Show("ID not exist!", "warning");
                        else
                        {
                            myReader1.Close();
                            string sql = "update t_account set password = '" + pass + "' where tid = '" + id + "'";
                            SqlCommand myCom = new SqlCommand(sql, mysqlConn);
                            myCom.ExecuteNonQuery();

                            new Form1().Show();
                            this.Close();
                        }
                    }
                    if(a_check.Checked)
                    {
                        string sql1 = "select aid from a_account where aid = '" + id + "'";
                        SqlCommand myCom1 = new SqlCommand(sql1, mysqlConn);
                        SqlDataReader myReader1 = myCom1.ExecuteReader();
                        if (!myReader1.HasRows)
                            MessageBox.Show("ID not exist!", "warning");
                        else
                        {
                            myReader1.Close();
                            string sql = "update a_account set password = '" + pass + "' where aid = '" + id + "'";
                            SqlCommand myCom = new SqlCommand(sql, mysqlConn);
                            myCom.ExecuteNonQuery();

                            new Form1().Show();
                            this.Close();
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            new Form1().Show();
        }
    }
}
