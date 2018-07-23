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
    public partial class AddCourseChoosing : Form
    {
        public AddCourseChoosing()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sid = sid_input.Text;
            string cid = cid_input.Text;
            string tid = tid_input.Text;
            string chosen_year = year_input.Text;
            string score = score_input.Text;

            if (sid.Equals(string.Empty) || cid.Equals(string.Empty) || tid.Equals(string.Empty)
                || chosen_year.Equals(string.Empty) || score.Equals(string.Empty))
                MessageBox.Show("Need to finish all info!", "warning");
            else
            {
                string open = "Server =.; integrated security = SSPI; Initial Catalog = StudentManagement";
                SqlConnection mysqlConn = new SqlConnection(open);
                mysqlConn.Open();

                string sql1 = "select * from course where cid = '" + cid + "' and grade > all (select grade from student where sid = '" + sid + "') and '" + chosen_year + "' < cancelled_year";
                SqlCommand myCom1 = new SqlCommand(sql1, mysqlConn);
                SqlDataReader myReader = myCom1.ExecuteReader();
                if (!myReader.HasRows)
                    MessageBox.Show("Cannot select this course since the grade is not high enough or the course has been cancelled before chosen.", "warning");
                else
                {
                    myReader.Close();
                    string sql = "insert into course_choosing values('" + sid + "','" + cid + "','" + tid + "','" + chosen_year + "','" + score + "')";
                    SqlCommand myCom = new SqlCommand(sql, mysqlConn);
                    myCom.ExecuteNonQuery();

                    mysqlConn.Close();
                    new admin().Show();
                    this.Close(); 

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
