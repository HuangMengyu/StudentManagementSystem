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
    public partial class teacher : Form
    {
        public string temp;

        public teacher()
        {
            InitializeComponent();
        }
        public teacher(string id)
        {
            InitializeComponent();
            temp = id;
        }

        private void teacher_Load(object sender, EventArgs e)
        {
            string open = "Server =.; integrated security = SSPI; Initial Catalog = StudentManagement";
            SqlConnection mysqlConn = new SqlConnection(open);
            mysqlConn.Open();

            #region set datagridview
            string sql1 = "select * from teacher";
            SqlCommand myCom1 = new SqlCommand(sql1, mysqlConn);
            SqlDataReader myReader1 = myCom1.ExecuteReader();
            while(myReader1.Read())
            {
                if(myReader1[0].ToString().Equals(temp))
                {
                    tid_display.Text = myReader1[0].ToString();
                    tname_display.Text = myReader1[1].ToString();
                }
            }
            myReader1.Close();

            string sql2 = "select DISTINCT course.cid,course.name,student.sid,student.name,cs.chosen_year,cs.score from teacher,course,course_choosing as cs,student where teacher.tid = '" + temp + "' and cs.sid = student.sid and cs.tid = teacher.tid and cs.cid = course.cid";
            SqlCommand myCom2 = new SqlCommand(sql2, mysqlConn);
            SqlDataAdapter myAdapter = new SqlDataAdapter();
            myAdapter.SelectCommand = myCom2;
            DataTable table = new DataTable();
            myAdapter.Fill(table);
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = table;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[4].ReadOnly = true;

            comboBox1.Items.Add(" ");
            comboBox2.Items.Add(" ");
            comboBox3.Items.Add(" ");
            comboBox4.Items.Add(" ");
            comboBox4.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            string sql3 = "select DISTINCT c.name,cs.chosen_year from course as c,course_choosing as cs where c.cid = cs.cid and cs.tid = '"+temp+"'";
            SqlCommand myCom3 = new SqlCommand(sql3, mysqlConn);
            SqlDataReader myReader2 = myCom3.ExecuteReader();
            while(myReader2.Read())
            {
                comboBox1.Items.Add(myReader2[0].ToString() + ' ' + myReader2[1].ToString());
                comboBox2.Items.Add(myReader2[0].ToString() + ' ' + myReader2[1].ToString());
                comboBox3.Items.Add(myReader2[0].ToString() + ' ' + myReader2[1].ToString());
            }
            myReader2.Close();

            string sql4 = "select DISTINCT student.class from student,course_choosing as cs where cs.tid = '"+temp+"' and cs.sid = student.sid";
            SqlCommand myCom4 = new SqlCommand(sql4, mysqlConn);
            SqlDataReader myReader3 = myCom4.ExecuteReader();
            while (myReader3.Read())
                comboBox4.Items.Add(myReader3[0].ToString());

            #endregion
            mysqlConn.Close();
        }

        private void c_query_Click(object sender, EventArgs e)
        {
            string open = "Server =.; integrated security = SSPI; Initial Catalog = StudentManagement";
            SqlConnection mysqlConn = new SqlConnection(open);
            mysqlConn.Open();

            if (comboBox1.SelectedIndex == 0)
            {
                string sql2 = "select DISTINCT course.cid,course.name,student.sid,student.name,cs.chosen_year,cs.score from teacher,course,course_choosing as cs,student where teacher.tid = '" + temp + "' and cs.sid = student.sid and cs.tid = teacher.tid and cs.cid = course.cid";
                SqlCommand myCom2 = new SqlCommand(sql2, mysqlConn);
                SqlDataAdapter myAdapter = new SqlDataAdapter();
                myAdapter.SelectCommand = myCom2;
                DataTable table = new DataTable();
                myAdapter.Fill(table);
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = table;
            }
            else
            {
                string cbox1_string = comboBox1.SelectedItem.ToString();
                string[] array = cbox1_string.Split(' ');
                string cname = array[0];
                string cyear = array[1];
                string sql1 = "select DISTINCT course.cid,course.name,student.sid,student.name,cs.chosen_year,cs.score from teacher,course,course_choosing as cs,student where teacher.tid = '" + temp + "' and course.name = '" + cname + "' and cs.chosen_year = '" + cyear + "' and cs.sid = student.sid and cs.tid = teacher.tid and cs.cid = course.cid";
                SqlCommand myCom1 = new SqlCommand(sql1, mysqlConn);
                SqlDataAdapter myAdapter = new SqlDataAdapter();
                myAdapter.SelectCommand = myCom1;
                DataTable table = new DataTable();
                myAdapter.Fill(table);
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = table;
            }
            mysqlConn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string temp = comboBox2.Items[comboBox2.SelectedIndex].ToString();
            string[] array = temp.Split(' ');
            string cname = array[0];
            string cyear = array[1];
            if (comboBox2.SelectedIndex == 0)
                MessageBox.Show("Must select a course!", "warning");
            else
            {
                string open = "Server =.; integrated security = SSPI; Initial Catalog = StudentManagement";
                SqlConnection mysqlConn = new SqlConnection(open);
                mysqlConn.Open();

                string sql1 = "select AVG(cs.score) from course as c, course_choosing as cs where c.cid = cs.cid and c.name = '" + cname + "' and cs.chosen_year = '" + cyear + "'";
                SqlCommand myCom1 = new SqlCommand(sql1, mysqlConn);
                avgscore.Text = myCom1.ExecuteScalar().ToString();
                mysqlConn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string temp = comboBox3.Items[comboBox3.SelectedIndex].ToString();
            string[] array = temp.Split(' ');
            string cname = array[0];
            string cyear = array[1];
            string Class = comboBox4.SelectedItem.ToString();
            if (comboBox3.SelectedIndex == 0)
                MessageBox.Show("Must select a course!", "warning");
            else if (comboBox4.SelectedIndex == 0)
                MessageBox.Show("Must select a class!", "warning");
            else
            {
                string open = "Server =.; integrated security = SSPI; Initial Catalog = StudentManagement";
                SqlConnection mysqlConn = new SqlConnection(open);
                mysqlConn.Open();

                string sql1 = "select AVG(cs.score) from course as c, course_choosing as cs,student where c.cid = cs.cid and student.sid = cs.sid and c.name = '" + cname + "' and cs.chosen_year = '" + cyear + "' and student.class = '" + Class + "'";
                SqlCommand myCom1 = new SqlCommand(sql1, mysqlConn);
                avgscore_1.Text = myCom1.ExecuteScalar().ToString();

                mysqlConn.Close();
            }

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string open = "Server =.; integrated security = SSPI; Initial Catalog = StudentManagement";
            SqlConnection mysqlConn = new SqlConnection(open);
            mysqlConn.Open();

            string New = dataGridView1.CurrentCell.Value.ToString();
            string sid = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            string cid = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            string sql = "update course_choosing set score = '" + New + "' where sid = '" + sid + "' and cid = '" + cid + "'";
            SqlCommand myCom = new SqlCommand(sql, mysqlConn);
            myCom.ExecuteNonQuery();
            mysqlConn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }
    }
}
