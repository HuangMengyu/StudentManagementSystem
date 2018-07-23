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
    public partial class admin : Form
    {
        public string temp;
        public admin()
        {
            InitializeComponent();
        }
        public admin(string id)
        {
            InitializeComponent();
            temp = id;
        }

        private void admin_Load(object sender, EventArgs e)
        {
            id_display.Text = temp;

            string open = "Server =.; integrated security = SSPI; Initial Catalog = StudentManagement";
            SqlConnection mysqlConn = new SqlConnection(open);
            mysqlConn.Open();

            string sql1 = "select * from student";
            SqlCommand myCom1 = new SqlCommand(sql1, mysqlConn);
            SqlDataAdapter myAdapter1 = new SqlDataAdapter();
            myAdapter1.SelectCommand = myCom1;
            DataTable table1 = new DataTable();
            myAdapter1.Fill(table1);
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = table1;
            dataGridView1.Columns[0].ReadOnly = true;

            string sql2 = "select * from teacher";
            SqlCommand myCom2 = new SqlCommand(sql2, mysqlConn);
            SqlDataAdapter myAdapter2 = new SqlDataAdapter();
            myAdapter2.SelectCommand = myCom2;
            DataTable table2 = new DataTable();
            myAdapter2.Fill(table2);
            dataGridView2.AutoGenerateColumns = true;
            dataGridView2.DataSource = table2;
            dataGridView2.Columns[0].ReadOnly = true; 

            string sql3 = "select * from course";
            SqlCommand myCom3 = new SqlCommand(sql3, mysqlConn);
            SqlDataAdapter myAdapter3 = new SqlDataAdapter();
            myAdapter3.SelectCommand = myCom3;
            DataTable table3 = new DataTable();
            myAdapter3.Fill(table3);
            dataGridView3.AutoGenerateColumns = true;
            dataGridView3.DataSource = table3;
            dataGridView3.Columns[0].ReadOnly = true;

            string sql4 = "select * from course_choosing";
            SqlCommand myCom4 = new SqlCommand(sql4, mysqlConn);
            SqlDataAdapter myAdapter4 = new SqlDataAdapter();
            myAdapter4.SelectCommand = myCom4;
            DataTable table4 = new DataTable();
            myAdapter4.Fill(table4);
            dataGridView4.AutoGenerateColumns = true;
            dataGridView4.DataSource = table4;
            dataGridView4.Columns[0].ReadOnly = true;
            dataGridView4.Columns[1].ReadOnly = true;
            dataGridView4.Columns[2].ReadOnly = true;

            mysqlConn.Close();

        }
        private int rowIndex;

        private void button2_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            new admin_query().Show();
            this.Hide();
        }

        #region student table
        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
                rowIndex = e.RowIndex;
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[1];
                contextMenuStrip1.Show(dataGridView1, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!dataGridView1.Rows[rowIndex].IsNewRow)
            {
                string sid = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
                dataGridView1.Rows.RemoveAt(rowIndex);

                string open = "Server =.; integrated security = SSPI; Initial Catalog = StudentManagement";
                SqlConnection mysqlConn = new SqlConnection(open);
                mysqlConn.Open();

                string sql1 = "delete from course_choosing where sid = '" + sid + "'";
                SqlCommand myCom1 = new SqlCommand(sql1, mysqlConn);
                myCom1.ExecuteNonQuery();

                string sql2 = "delete from s_account where sid = '" + sid + "'";
                SqlCommand myCom2 = new SqlCommand(sql2, mysqlConn);
                myCom2.ExecuteNonQuery();

                string sql = "delete from student where sid = '" + sid + "'";
                SqlCommand myCom = new SqlCommand(sql, mysqlConn);
                myCom.ExecuteNonQuery();

                string sql4 = "select * from course_choosing";
                SqlCommand myCom4 = new SqlCommand(sql4, mysqlConn);
                SqlDataAdapter myAdapter4 = new SqlDataAdapter();
                myAdapter4.SelectCommand = myCom4;
                DataTable table4 = new DataTable();
                myAdapter4.Fill(table4);
                dataGridView4.AutoGenerateColumns = true;
                dataGridView4.DataSource = table4;
                mysqlConn.Close();

            }
                
        }



        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AddStudent().Show();
            this.Close();
        }
        #endregion

        #region teacher table
        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!dataGridView2.Rows[rowIndex].IsNewRow)
            {
                string tid = dataGridView2.Rows[rowIndex].Cells[0].Value.ToString();
                dataGridView2.Rows.RemoveAt(rowIndex);

                string open = "Server =.; integrated security = SSPI; Initial Catalog = StudentManagement";
                SqlConnection mysqlConn = new SqlConnection(open);
                mysqlConn.Open();

                string sql1 = "delete from course_choosing where tid = '" + tid + "' ";
                SqlCommand myCom1 = new SqlCommand(sql1, mysqlConn);
                myCom1.ExecuteNonQuery();

                string sql3 = "delete from course where tid = '" + tid + "'";
                SqlCommand myCom3 = new SqlCommand(sql3, mysqlConn);
                myCom3.ExecuteNonQuery();

                string sql = "delete from teacher where tid = '" + tid + "'";
                SqlCommand myCom = new SqlCommand(sql, mysqlConn);
                myCom.ExecuteNonQuery();

                string sql4 = "select * from teacher where tid = '" + tid + "'";
                SqlCommand myCom4 = new SqlCommand(sql4, mysqlConn);
                SqlDataReader myReader4 = myCom4.ExecuteReader();
                if (!myReader4.HasRows)
                {
                    myReader4.Close();
                    string sql2 = "delete from t_account where tid = '" + tid + "'";
                    SqlCommand myCom2 = new SqlCommand(sql2, mysqlConn);
                    myCom2.ExecuteNonQuery();
                }

                string sql5 = "select * from course";
                SqlCommand myCom5 = new SqlCommand(sql5, mysqlConn);
                SqlDataAdapter myAdapter5 = new SqlDataAdapter();
                myAdapter5.SelectCommand = myCom5;
                DataTable table5 = new DataTable();
                myAdapter5.Fill(table5);
                dataGridView3.AutoGenerateColumns = true;
                dataGridView3.DataSource = table5;

                string sql6 = "select * from course_choosing";
                SqlCommand myCom6 = new SqlCommand(sql6, mysqlConn);
                SqlDataAdapter myAdapter6 = new SqlDataAdapter();
                myAdapter6.SelectCommand = myCom6;
                DataTable table6 = new DataTable();
                myAdapter6.Fill(table6);
                dataGridView4.AutoGenerateColumns = true;
                dataGridView4.DataSource = table6;

                mysqlConn.Close();

            }
        }

        private void dataGridView2_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dataGridView2.Rows[e.RowIndex].Selected = true;
                rowIndex = e.RowIndex;
                dataGridView2.CurrentCell = dataGridView2.Rows[e.RowIndex].Cells[1];
                contextMenuStrip2.Show(dataGridView2, e.Location);
                contextMenuStrip2.Show(Cursor.Position);
            }
        }

        private void insertToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new AddTeacher().Show();
            this.Close();
        }


        #endregion

        #region course table
        private void dataGridView3_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dataGridView3.Rows[e.RowIndex].Selected = true;
                rowIndex = e.RowIndex;
                dataGridView3.CurrentCell = dataGridView3.Rows[e.RowIndex].Cells[1];
                contextMenuStrip3.Show(dataGridView3, e.Location);
                contextMenuStrip3.Show(Cursor.Position);
            }
        }

        private void deleteToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (!dataGridView3.Rows[rowIndex].IsNewRow)
            {
                string cid = dataGridView3.Rows[rowIndex].Cells[0].Value.ToString();
                dataGridView3.Rows.RemoveAt(rowIndex);

                string open = "Server =.; integrated security = SSPI; Initial Catalog = StudentManagement";
                SqlConnection mysqlConn = new SqlConnection(open);
                mysqlConn.Open();

                string sql2 = "delete from course_choosing where cid = '" + cid + "'";
                SqlCommand myCom2 = new SqlCommand(sql2, mysqlConn);
                myCom2.ExecuteNonQuery();

                string sql1 = "delete from course where cid = '" + cid + "'";
                SqlCommand myCom1 = new SqlCommand(sql1, mysqlConn);
                myCom1.ExecuteNonQuery();

                string sql4 = "select * from course_choosing";
                SqlCommand myCom4 = new SqlCommand(sql4, mysqlConn);
                SqlDataAdapter myAdapter4 = new SqlDataAdapter();
                myAdapter4.SelectCommand = myCom4;
                DataTable table4 = new DataTable();
                myAdapter4.Fill(table4);
                dataGridView4.AutoGenerateColumns = true;
                dataGridView4.DataSource = table4;

            }
        }

        private void insertToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new AddCourse().Show();
            this.Close();
        }

        #endregion

        #region course_choosing table

        private void dataGridView4_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dataGridView4.Rows[e.RowIndex].Selected = true;
                rowIndex = e.RowIndex;
                dataGridView4.CurrentCell = dataGridView4.Rows[e.RowIndex].Cells[1];
                contextMenuStrip4.Show(dataGridView4, e.Location);
                contextMenuStrip4.Show(Cursor.Position);
            }
        }

        private void deleteToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (!dataGridView4.Rows[rowIndex].IsNewRow)
            {
                string sid = dataGridView4.Rows[rowIndex].Cells[0].Value.ToString();
                string cid = dataGridView4.Rows[rowIndex].Cells[1].Value.ToString();
                string tid = dataGridView4.Rows[rowIndex].Cells[2].Value.ToString();
                string chosen_year = dataGridView4.Rows[rowIndex].Cells[3].Value.ToString();
                dataGridView4.Rows.RemoveAt(rowIndex);

                string open = "Server =.; integrated security = SSPI; Initial Catalog = StudentManagement";
                SqlConnection mysqlConn = new SqlConnection(open);
                mysqlConn.Open();

                string sql = "delete from course_choosing where sid = '" + sid + "' and cid = '" + cid + "' and tid = '" + tid + "' and chosen_year = '" + chosen_year + "'";
                SqlCommand myCom = new SqlCommand(sql, mysqlConn);
                myCom.ExecuteNonQuery();
            }
        }

        private void insertToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            new AddCourseChoosing().Show();
            this.Close();
        }


        #endregion

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string open = "Server =.; integrated security = SSPI; Initial Catalog = StudentManagement";
            SqlConnection mysqlConn = new SqlConnection(open);
            mysqlConn.Open();

            string New = dataGridView1.CurrentCell.Value.ToString();
            int index = dataGridView1.CurrentCell.ColumnIndex;
            string sid = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();

            if(index == 1)
            {
                string sql = "update student set name = '"+New+"' where sid = '"+sid+"'";
                SqlCommand Com = new SqlCommand(sql, mysqlConn);
                Com.ExecuteNonQuery();
            }
            else if (index == 2)
            {
                string sql = "update student set sex = '"+New+"' where sid = '"+sid+"'";
                SqlCommand Com = new SqlCommand(sql, mysqlConn);
                Com.ExecuteNonQuery();
            }
            else if (index == 3)
            {
                string sql = "update student set entrance_age = '"+New+"' where sid = '"+sid+"'";
                SqlCommand Com = new SqlCommand(sql, mysqlConn);
                Com.ExecuteNonQuery();
            }
            else if (index == 4)
            {
                string sql = "update student set entrance_year = '" + New + "' where sid = '" + sid + "'";
                SqlCommand Com = new SqlCommand(sql, mysqlConn);
                Com.ExecuteNonQuery();
            }
            else if (index == 5)
            {
                string sql = "update student set class = '" + New + "' where sid = '" + sid + "'";
                SqlCommand Com = new SqlCommand(sql, mysqlConn);
                Com.ExecuteNonQuery();
            }
            mysqlConn.Close();
        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string open = "Server =.; integrated security = SSPI; Initial Catalog = StudentManagement";
            SqlConnection mysqlConn = new SqlConnection(open);
            mysqlConn.Open();

            string New = dataGridView2.CurrentCell.Value.ToString();
            int index = dataGridView2.CurrentCell.ColumnIndex;
            string tid = dataGridView2.Rows[rowIndex].Cells[0].Value.ToString();

            if (index == 1)
            {
                string sql = "update teacher set name = '" + New + "' where tid = '" + tid + "'";
                SqlCommand Com = new SqlCommand(sql, mysqlConn);
                Com.ExecuteNonQuery();
            }
            mysqlConn.Close();
        }

        private void dataGridView3_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string open = "Server =.; integrated security = SSPI; Initial Catalog = StudentManagement";
            SqlConnection mysqlConn = new SqlConnection(open);
            mysqlConn.Open();

            string New = dataGridView3.CurrentCell.Value.ToString();
            int index = dataGridView3.CurrentCell.ColumnIndex;
            string cid = dataGridView3.Rows[rowIndex].Cells[0].Value.ToString();

            if (index == 1)
            {
                string sql = "update course set name = '" + New + "' where cid = '" + cid + "'";
                SqlCommand Com = new SqlCommand(sql, mysqlConn);
                Com.ExecuteNonQuery();
            }
            else if (index == 3)
            {
                string sql = "update course set credit = '" + New + "' where cid = '" + cid + "'";
                SqlCommand Com = new SqlCommand(sql, mysqlConn);
                Com.ExecuteNonQuery();
            }
            else if (index == 4)
            {
                string sql = "update course set grade = '" + New + "' where cid = '" + cid + "'";
                SqlCommand Com = new SqlCommand(sql, mysqlConn);
                Com.ExecuteNonQuery();
            }
            else if (index == 5)
            {
                string sql = "update course set cancelled_year = '" + New + "' where cid = '" + cid + "'";
                SqlCommand Com = new SqlCommand(sql, mysqlConn);
                Com.ExecuteNonQuery();
            }
            mysqlConn.Close();
        }

        private void dataGridView4_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string open = "Server =.; integrated security = SSPI; Initial Catalog = StudentManagement";
            SqlConnection mysqlConn = new SqlConnection(open);
            mysqlConn.Open();

            string New = dataGridView4.CurrentCell.Value.ToString();
            int index = dataGridView4.CurrentCell.ColumnIndex;
            string sid = dataGridView4.Rows[rowIndex].Cells[0].Value.ToString();
            string cid = dataGridView4.Rows[rowIndex].Cells[1].Value.ToString();
            string tid = dataGridView4.Rows[rowIndex].Cells[2].Value.ToString();

            if (index == 3)
            {
                string sql = "update course_choosing set chosen_year = '" + New + "' where sid = '" + sid + "' and cid = '"+cid +"' and tid = '"+tid+"'";
                SqlCommand Com = new SqlCommand(sql, mysqlConn);
                Com.ExecuteNonQuery();
            }
            else if(index == 4)
            {
                string sql = "update course_choosing set score = '" + New + "' where sid = '" + sid + "' and cid = '" + cid + "' and tid = '" + tid + "'";
                SqlCommand Com = new SqlCommand(sql, mysqlConn);
                Com.ExecuteNonQuery();
            }
            mysqlConn.Close();
        }
    }
}
