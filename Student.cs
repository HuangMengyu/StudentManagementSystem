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
    public partial class Student : Form
    {
        public string temp;
        public Student()
        {
            InitializeComponent();
        }
        public Student(string id)
        {
            InitializeComponent();
            temp = id;
        }

        private void Student_Load(object sender, EventArgs e)
        {
            string open = "Server =.; integrated security = SSPI; Initial Catalog = StudentManagement";
            SqlConnection mysqlConn = new SqlConnection(open);
            mysqlConn.Open();

            #region set data
            string sql = "select * from student";
            SqlCommand mysqlCom = new SqlCommand(sql, mysqlConn);
            SqlDataReader myReader = mysqlCom.ExecuteReader();
            while (myReader.Read())
            {
                if (myReader[0].ToString().Equals(temp))
                {
                    id_display.Text = myReader[0].ToString();
                    name_display.Text = myReader[1].ToString();
                    sex_display.Text = myReader[2].ToString();
                    enage_display.Text = myReader[3].ToString();
                    enyear_display.Text = myReader[4].ToString();
                    class_display.Text = myReader[5].ToString();
                    break;
                }
            }
            myReader.Close();
            string sql2 = "select course.cid,course.name,cs.score from course,course_choosing as cs where course.cid = cs.cid and cs.sid = '"+temp+"'";
            SqlCommand mysqlCom2 = new SqlCommand(sql2, mysqlConn);
            SqlDataAdapter myAdapter = new SqlDataAdapter();
            myAdapter.SelectCommand = mysqlCom2;
            DataTable table = new DataTable();
            myAdapter.Fill(table);
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = table;

            string sql3 = "select AVG(cs.score) from course_choosing as cs where cs.sid = '" + temp + "'";
            SqlCommand mysqlCom3 = new SqlCommand(sql3, mysqlConn);
            string temp1 = mysqlCom3.ExecuteScalar().ToString();
            avgscore_display.Text = mysqlCom3.ExecuteScalar().ToString();
            #endregion

            mysqlConn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string open = "Server =.; integrated security = SSPI; Initial Catalog = StudentManagement";
            SqlConnection mysqlConn = new SqlConnection(open);
            mysqlConn.Open();

            string cid_in = cid_input.Text.ToString();
            string cname_in = cname_input.Text.ToString();
            if(cid_in.Equals(String.Empty) && cname_in.Equals(String.Empty))
            {
                string sql1 = "select * from course";
                SqlCommand mysqlCom1 = new SqlCommand(sql1, mysqlConn);
                SqlDataAdapter myAdapter = new SqlDataAdapter();
                myAdapter.SelectCommand = mysqlCom1;
                DataTable table = new DataTable();
                myAdapter.Fill(table);
                dataGridView2.AutoGenerateColumns = true;
                dataGridView2.DataSource = table;
            }
            else if (cid_in.Equals(String.Empty) && cname_in != "")
            {
                string sql1 = "select * from course where name = '" + cname_in + "'";
                SqlCommand mysqlCom1 = new SqlCommand(sql1, mysqlConn);
                SqlDataAdapter myAdapter = new SqlDataAdapter();
                myAdapter.SelectCommand = mysqlCom1;
                DataTable table = new DataTable();
                myAdapter.Fill(table);
                dataGridView2.AutoGenerateColumns = true;
                dataGridView2.DataSource = table;
            }
            else
            {
                string sql1 = "select * from course where cid = '" + cid_in + "'";
                SqlCommand mysqlCom1 = new SqlCommand(sql1, mysqlConn);
                SqlDataAdapter myAdapter = new SqlDataAdapter();
                myAdapter.SelectCommand = mysqlCom1;
                DataTable table = new DataTable();
                myAdapter.Fill(table);
                dataGridView2.AutoGenerateColumns = true;
                dataGridView2.DataSource = table;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string open = "Server =.; integrated security = SSPI; Initial Catalog = StudentManagement";
            SqlConnection mysqlConn = new SqlConnection(open);
            mysqlConn.Open();

            string name = textBox1.Text;
            if(name.Equals(string.Empty))
            {
                string sql = "select course.cid,course.name,cs.score from course,course_choosing as cs where course.cid = cs.cid and cs.sid = '"+temp+"'";
                SqlCommand myCom = new SqlCommand(sql, mysqlConn);
                SqlDataAdapter myAdapter = new SqlDataAdapter();
                myAdapter.SelectCommand = myCom;
                DataTable table = new DataTable();
                myAdapter.Fill(table);
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = table;

            }
            else
            {
                string sql1 = "select * from course_choosing as cs,student,course where student.sid = cs.sid and course.cid = cs.cid and student.sid = '" + temp + "' and course.name = '" + name + "'";
                SqlCommand myCom1 = new SqlCommand(sql1, mysqlConn);
                SqlDataReader myReader = myCom1.ExecuteReader();
                if (!myReader.HasRows)
                    MessageBox.Show("You have not chosen this course!", "warning");
                else
                {
                    myReader.Close();
                    string sql = "select course.cid,course.name,cs.score from course,course_choosing as cs where course.cid = cs.cid and cs.sid = '" + temp + "'and course.name = '"+name+"'";
                    SqlCommand myCom = new SqlCommand(sql, mysqlConn);
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myAdapter.SelectCommand = myCom;
                    DataTable table = new DataTable();
                    myAdapter.Fill(table);
                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = table;
                }

            }

            mysqlConn.Close();
        }
    }
}
