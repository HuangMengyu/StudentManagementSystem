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
    public partial class AddTeacher : Form
    {
        public AddTeacher()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id_in = id_input.Text;
            string name_in = name_input.Text;
            
            if (id_in.Equals(String.Empty) || name_in.Equals(String.Empty))
                MessageBox.Show("Please finish all info!", "warning");
            else
            {
                string open = "Server =.; integrated security = SSPI; Initial Catalog = StudentManagement";
                SqlConnection mysqlConn = new SqlConnection(open);
                mysqlConn.Open();

                string sql1 = "select * from teacher where tid = '" + id_in + "' and name = '"+name_in+"'";
                SqlCommand myCom1 = new SqlCommand(sql1, mysqlConn);
                SqlDataReader myReader1 = myCom1.ExecuteReader();
                if (myReader1.HasRows)
                    MessageBox.Show("Wrong ID or name!", "warning");
                else
                {
                    myReader1.Close();
                    string sql2 = "insert into teacher values ('" + id_in + "','" + name_in + "')";
                    SqlCommand myCom2 = new SqlCommand(sql2, mysqlConn);
                    myCom2.ExecuteNonQuery();

                    string sql3 = "insert into t_account values ('" + id_in + "','123456')";
                    SqlCommand myCom3 = new SqlCommand(sql3, mysqlConn);
                    myCom3.ExecuteNonQuery();

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
