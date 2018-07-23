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
    public partial class admin_query : Form
    {
        public admin_query()
        {
            InitializeComponent();
        }

        private void admin_query_Load(object sender, EventArgs e)
        {
            string open = "Server =.; integrated security = SSPI; Initial Catalog = StudentManagement";
            SqlConnection mysqlConn = new SqlConnection(open);
            mysqlConn.Open();

            string sql1 = "select * from student as s, course as c,course_choosing where s.sid = course_choosing.sid and c.cid = course_choosing.cid";
            SqlCommand myCom1 = new SqlCommand(sql1, mysqlConn);
            SqlDataAdapter myAdapter1 = new SqlDataAdapter();
            myAdapter1.SelectCommand = myCom1;
            DataTable table1 = new DataTable();
            myAdapter1.Fill(table1);
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = table1;

            string sql2 = "select cs.sid,s.name,cs.cid,c.name,cs.score from student as s, course as c, course_choosing as cs where s.sid = cs.sid and c.cid = cs.cid";
            SqlCommand myCom2 = new SqlCommand(sql2, mysqlConn);
            SqlDataAdapter myAdapter2 = new SqlDataAdapter();
            myAdapter2.SelectCommand = myCom2;
            DataTable table2 = new DataTable();
            myAdapter2.Fill(table2);
            dataGridView2.AutoGenerateColumns = true;
            dataGridView2.DataSource = table2;

            string sql3 = "select * from course as c, course_choosing as cs where c.cid = cs.cid";
            SqlCommand myCom3 = new SqlCommand(sql3, mysqlConn);
            SqlDataAdapter myAdapter3 = new SqlDataAdapter();
            myAdapter3.SelectCommand = myCom3;
            DataTable table3 = new DataTable();
            myAdapter3.Fill(table3);
            dataGridView3.AutoGenerateColumns = true;
            dataGridView3.DataSource = table3;

            string sql4 = "select * from teacher as t, course as c where t.tid = c.tid";
            SqlCommand myCom4 = new SqlCommand(sql4, mysqlConn);
            SqlDataAdapter myAdapter4 = new SqlDataAdapter();
            myAdapter4.SelectCommand = myCom4;
            DataTable table4 = new DataTable();
            myAdapter4.Fill(table4);
            dataGridView4.AutoGenerateColumns = true;
            dataGridView4.DataSource = table4;

            mysqlConn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string open = "Server =.; integrated security = SSPI; Initial Catalog = StudentManagement";
            SqlConnection mysqlConn = new SqlConnection(open);
            mysqlConn.Open();

            string sid = sid_in1.Text;
            string sname = sname_in1.Text;

            if (sid.Equals(string.Empty) && sname.Equals(string.Empty))
            {
                string sql1 = "select * from student as s, course as c,course_choosing where s.sid = course_choosing.sid and c.cid = course_choosing.cid";
                SqlCommand myCom1 = new SqlCommand(sql1, mysqlConn);
                SqlDataAdapter myAdapter1 = new SqlDataAdapter();
                myAdapter1.SelectCommand = myCom1;
                DataTable table1 = new DataTable();
                myAdapter1.Fill(table1);
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = table1;
            }
            else if(sid.Equals(string.Empty))
            {
                string sql = "select * from student as s, course as c,course_choosing where s.sid = course_choosing.sid and c.cid = course_choosing.cid and s.name = '"+sname+"'";
                SqlCommand myCom = new SqlCommand(sql, mysqlConn);
                SqlDataAdapter myAdapter = new SqlDataAdapter();
                myAdapter.SelectCommand = myCom;
                DataTable table = new DataTable();
                myAdapter.Fill(table);
                dataGridView1.DataSource = table;
                dataGridView1.AutoGenerateColumns = true;
            }
            else
            {
                if (!sid.Equals(string.Empty) && !sname.Equals(string.Empty))
                {
                    string sql0 = "select * from student where sid = '" + sid + "' and name = '" + sname + "'";
                    SqlCommand Com = new SqlCommand(sql0, mysqlConn);
                    SqlDataReader Reader = Com.ExecuteReader();
                    if (!Reader.HasRows)
                        MessageBox.Show("ID and name do not match!", "warning");
                    else
                    {
                        Reader.Close();
                        string sql = "select * from student as s, course as c,course_choosing where s.sid = course_choosing.sid and c.cid = course_choosing.cid and s.sid = '" + sid + "'";
                        SqlCommand myCom = new SqlCommand(sql, mysqlConn);
                        SqlDataAdapter myAdapter = new SqlDataAdapter();
                        myAdapter.SelectCommand = myCom;
                        DataTable table = new DataTable();
                        myAdapter.Fill(table);
                        dataGridView1.DataSource = table;
                        dataGridView1.AutoGenerateColumns = true;
                    }

                }
                else
                {
                    string sql = "select * from student as s, course as c,course_choosing where s.sid = course_choosing.sid and c.cid = course_choosing.cid and s.sid = '" + sid + "'";
                    SqlCommand myCom = new SqlCommand(sql, mysqlConn);
                    SqlDataAdapter myAdapter = new SqlDataAdapter();
                    myAdapter.SelectCommand = myCom;
                    DataTable table = new DataTable();
                    myAdapter.Fill(table);
                    dataGridView1.DataSource = table;
                    dataGridView1.AutoGenerateColumns = true;
                }
            }

            mysqlConn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string open = "Server =.; integrated security = SSPI; Initial Catalog = StudentManagement";
            SqlConnection mysqlConn = new SqlConnection(open);
            mysqlConn.Open();

            string sid = sid_in2.Text;
            string sname = sname_in2.Text;
            string cid = cid_in1.Text;
            string cname = cname_in1.Text;

            if(!sid.Equals(string.Empty) && !sname.Equals(string.Empty))
            {
                string sql = "select * from student where sid = '" + sid + "' and name = '" + sname + "'";
                SqlCommand myCom = new SqlCommand(sql, mysqlConn);
                SqlDataReader reader = myCom.ExecuteReader();
                if (!reader.HasRows)
                    MessageBox.Show("student ID and name do not match", "warning");
                reader.Close();
            }
            else if(!cid.Equals(string.Empty) && !cname.Equals(string.Empty))
            {
                string sql = "select * from course where cid = '" + cid + "' and name = '" + cname + "'";
                SqlCommand myCom = new SqlCommand(sql, mysqlConn);
                SqlDataReader reader = myCom.ExecuteReader();
                if (!reader.HasRows)
                    MessageBox.Show("course ID and name do not match", "warning");
                reader.Close();
            }
            if ((sid.Equals(string.Empty) && sname.Equals(string.Empty)) 
                || (cid.Equals(string.Empty) && cname.Equals(string.Empty)))
            {
                string sql2 = "select cs.sid,s.name,cs.cid,c.name,cs.score from student as s, course as c, course_choosing as cs where s.sid = cs.sid and c.cid = cs.cid";
                SqlCommand myCom2 = new SqlCommand(sql2, mysqlConn);
                SqlDataAdapter myAdapter2 = new SqlDataAdapter();
                myAdapter2.SelectCommand = myCom2;
                DataTable table2 = new DataTable();
                myAdapter2.Fill(table2);
                dataGridView2.AutoGenerateColumns = true;
                dataGridView2.DataSource = table2;
            }
            else if(sid.Equals(string.Empty) && !sname.Equals(string.Empty))
            {
                string sql2 = "select cs.sid,s.name,cs.cid,c.name,cs.score from student as s, course as c, course_choosing as cs where s.sid = cs.sid and c.cid = cs.cid and s.name = '"+sname+"' and c.name = '"+cname+"'";
                SqlCommand myCom2 = new SqlCommand(sql2, mysqlConn);
                SqlDataAdapter myAdapter2 = new SqlDataAdapter();
                myAdapter2.SelectCommand = myCom2;
                DataTable table2 = new DataTable();
                myAdapter2.Fill(table2);
                dataGridView2.AutoGenerateColumns = true;
                dataGridView2.DataSource = table2;
            }
            else if(sid.Equals(string.Empty) && cname.Equals(string.Empty))
            {
                string sql2 = "select cs.sid,s.name,cs.cid,c.name,cs.score from student as s, course as c, course_choosing as cs where s.sid = cs.sid and c.cid = cs.cid and s.name = '" + sname + "' and c.cid = '" + cid + "'";
                SqlCommand myCom2 = new SqlCommand(sql2, mysqlConn);
                SqlDataAdapter myAdapter2 = new SqlDataAdapter();
                myAdapter2.SelectCommand = myCom2;
                DataTable table2 = new DataTable();
                myAdapter2.Fill(table2);
                dataGridView2.AutoGenerateColumns = true;
                dataGridView2.DataSource = table2;
            }
            else if(cid.Equals(string.Empty) && sname.Equals(string.Empty))
            {
                string sql2 = "select cs.sid,s.name,cs.cid,c.name,cs.score from student as s, course as c, course_choosing as cs where s.sid = cs.sid and c.cid = cs.cid and c.name = '" + cname + "' and s.sid = '" + sid + "'";
                SqlCommand myCom2 = new SqlCommand(sql2, mysqlConn);
                SqlDataAdapter myAdapter2 = new SqlDataAdapter();
                myAdapter2.SelectCommand = myCom2;
                DataTable table2 = new DataTable();
                myAdapter2.Fill(table2);
                dataGridView2.AutoGenerateColumns = true;
                dataGridView2.DataSource = table2;
            }
            else
            { 
                string sql2 = "select cs.sid,s.name,cs.cid,c.name,cs.score from student as s, course as c, course_choosing as cs where s.sid = cs.sid and c.cid = cs.cid and s.sid = '" + sid + "' and c.cid = '" + cid + "'";
                SqlCommand myCom2 = new SqlCommand(sql2, mysqlConn);
                SqlDataAdapter myAdapter2 = new SqlDataAdapter();
                myAdapter2.SelectCommand = myCom2;
                DataTable table2 = new DataTable();
                myAdapter2.Fill(table2);
                dataGridView2.AutoGenerateColumns = true;
                dataGridView2.DataSource = table2;

            }


            mysqlConn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string open = "Server =.; integrated security = SSPI; Initial Catalog = StudentManagement";
            SqlConnection mysqlConn = new SqlConnection(open);
            mysqlConn.Open();

            string cid = cid_in2.Text;
            string cname = cname_in2.Text;


            if(cid.Equals(string.Empty) && cname.Equals(string.Empty))
            {
                string sql3 = "select * from course as c, course_choosing as cs where c.cid = cs.cid";
                SqlCommand myCom3 = new SqlCommand(sql3, mysqlConn);
                SqlDataAdapter myAdapter3 = new SqlDataAdapter();
                myAdapter3.SelectCommand = myCom3;
                DataTable table3 = new DataTable();
                myAdapter3.Fill(table3);
                dataGridView3.AutoGenerateColumns = true;
                dataGridView3.DataSource = table3;
            }
            else if(cid.Equals(string.Empty))
            {
                string sql3 = "select * from course as c, course_choosing as cs where c.cid = cs.cid and c.name = '"+cname+"'";
                SqlCommand myCom3 = new SqlCommand(sql3, mysqlConn);
                SqlDataAdapter myAdapter3 = new SqlDataAdapter();
                myAdapter3.SelectCommand = myCom3;
                DataTable table3 = new DataTable();
                myAdapter3.Fill(table3);
                dataGridView3.AutoGenerateColumns = true;
                dataGridView3.DataSource = table3;
            }
            else
            {
                if (!cid.Equals(string.Empty) && !cname.Equals(string.Empty))
                {
                    string sql0 = "select * from course where cid = '" + cid + "' and name = '" + cname + "'";
                    SqlCommand Com = new SqlCommand(sql0, mysqlConn);
                    SqlDataReader Reader = Com.ExecuteReader();
                    if (!Reader.HasRows)
                        MessageBox.Show("ID and name do not match!", "warning");
                    else
                    {
                        Reader.Close();
                        string sql3 = "select * from course as c, course_choosing as cs where c.cid = cs.cid and c.cid = '" + cid + "'";
                        SqlCommand myCom3 = new SqlCommand(sql3, mysqlConn);
                        SqlDataAdapter myAdapter3 = new SqlDataAdapter();
                        myAdapter3.SelectCommand = myCom3;
                        DataTable table3 = new DataTable();
                        myAdapter3.Fill(table3);
                        dataGridView3.AutoGenerateColumns = true;
                        dataGridView3.DataSource = table3;
                    }
                }
                else
                {
                    string sql3 = "select * from course as c, course_choosing as cs where c.cid = cs.cid and c.cid = '" + cid + "'";
                    SqlCommand myCom3 = new SqlCommand(sql3, mysqlConn);
                    SqlDataAdapter myAdapter3 = new SqlDataAdapter();
                    myAdapter3.SelectCommand = myCom3;
                    DataTable table3 = new DataTable();
                    myAdapter3.Fill(table3);
                    dataGridView3.AutoGenerateColumns = true;
                    dataGridView3.DataSource = table3;
                }
            }

            mysqlConn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string open = "Server =.; integrated security = SSPI; Initial Catalog = StudentManagement";
            SqlConnection mysqlConn = new SqlConnection(open);
            mysqlConn.Open();

            string tid = tid_in.Text;
            string tname = tname_in.Text;

            if(tid.Equals(string.Empty) && tname.Equals(string.Empty))
            {
                string sql4 = "select * from teacher as t, course as c where t.tid = c.tid";
                SqlCommand myCom4 = new SqlCommand(sql4, mysqlConn);
                SqlDataAdapter myAdapter4 = new SqlDataAdapter();
                myAdapter4.SelectCommand = myCom4;
                DataTable table4 = new DataTable();
                myAdapter4.Fill(table4);
                dataGridView4.AutoGenerateColumns = true;
                dataGridView4.DataSource = table4;
            }
            else if (tid.Equals(string.Empty))
            {
                string sql4 = "select * from teacher as t, course as c where t.tid = c.tid and t.name = '"+tname+"'";
                SqlCommand myCom4 = new SqlCommand(sql4, mysqlConn);
                SqlDataAdapter myAdapter4 = new SqlDataAdapter();
                myAdapter4.SelectCommand = myCom4;
                DataTable table4 = new DataTable();
                myAdapter4.Fill(table4);
                dataGridView4.AutoGenerateColumns = true;
                dataGridView4.DataSource = table4;
            }
            else 
            {
                if (!tid.Equals(string.Empty) && !tname.Equals(string.Empty))
                {
                    string sql0 = "select * from teacher where tid = '" + tid + "' and name = '" + tname + "'";
                    SqlCommand Com = new SqlCommand(sql0, mysqlConn);
                    SqlDataReader Reader = Com.ExecuteReader();
                    if (!Reader.HasRows)
                        MessageBox.Show("ID and name do not match!", "warning");
                    else
                    {
                        Reader.Close();
                        string sql4 = "select * from teacher as t, course as c where t.tid = c.tid and t.tid = '" + tid + "'";
                        SqlCommand myCom4 = new SqlCommand(sql4, mysqlConn);
                        SqlDataAdapter myAdapter4 = new SqlDataAdapter();
                        myAdapter4.SelectCommand = myCom4;
                        DataTable table4 = new DataTable();
                        myAdapter4.Fill(table4);
                        dataGridView4.AutoGenerateColumns = true;
                        dataGridView4.DataSource = table4;
                    }
                }
                else
                {
                    string sql4 = "select * from teacher as t, course as c where t.tid = c.tid and t.tid = '" + tid + "'";
                    SqlCommand myCom4 = new SqlCommand(sql4, mysqlConn);
                    SqlDataAdapter myAdapter4 = new SqlDataAdapter();
                    myAdapter4.SelectCommand = myCom4;
                    DataTable table4 = new DataTable();
                    myAdapter4.Fill(table4);
                    dataGridView4.AutoGenerateColumns = true;
                    dataGridView4.DataSource = table4;
                }
            }

            mysqlConn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new admin().Show();
            this.Close();
        }


    }
}
