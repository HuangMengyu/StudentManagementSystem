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
    public partial class AddCourse : Form
    {
        public AddCourse()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cid = cid_input.Text;
            string name = name_input.Text;
            string tid = tid_input.Text;
            string credit = credit_input.Text;
            string grade_in = grade_input.Text;
            string year = canyear_input.Text;

            if (cid.Equals(string.Empty) || name.Equals(string.Empty)
                || tid.Equals(string.Empty) || credit.Equals(string.Empty)
                || grade_in.Equals(string.Empty))
                MessageBox.Show("Need to finish all info!", "warning");
            else 
            {
                string open = "Server =.; integrated security = SSPI; Initial Catalog = StudentManagement";
                SqlConnection mysqlConn = new SqlConnection(open);
                mysqlConn.Open();

                string sql1 = "select * from course where cid = '" + cid + "'";
                SqlCommand myCom1 = new SqlCommand(sql1, mysqlConn);
                SqlDataReader myReader1 = myCom1.ExecuteReader();
                if (myReader1.HasRows)
                    MessageBox.Show("Duplicate course id!", "warning");
                else
                {
                    myReader1.Close();
                    string sql2 = "select * from teacher where tid = '" + tid + "'";
                    SqlCommand myCom2 = new SqlCommand(sql2, mysqlConn);
                    SqlDataReader myReader2 = myCom2.ExecuteReader();
                    if (!myReader2.HasRows)
                        MessageBox.Show("Teacher id not exist!", "warning");
                    else
                    {
                        if (!year.Equals(string.Empty))
                        {
                            myReader2.Close();
                            string sql = "insert into course values('" + cid + "','" + name + "','" + tid + "','" + credit + "','" + grade_in + "','" + year + "')";
                            SqlCommand myCom = new SqlCommand(sql, mysqlConn);
                            myCom.ExecuteNonQuery();
                            mysqlConn.Close();
                            new admin().Show();
                            this.Close();
                        }
                        else
                        {
                            myReader2.Close();
                            string sql = "insert into course values('" + cid + "','" + name + "','" + tid + "','" + credit + "','" + grade_in + "',NULL)";
                            SqlCommand myCom = new SqlCommand(sql, mysqlConn);
                            myCom.ExecuteNonQuery();
                            mysqlConn.Close();
                            new admin().Show();
                            this.Close();
                        }
                    }
                }
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new admin().Show();
            this.Close();
        }
    }
}
