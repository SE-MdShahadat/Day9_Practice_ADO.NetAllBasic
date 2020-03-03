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

namespace ADObasic
{
    public partial class ADOBasicUi : Form
    {
        public ADOBasicUi()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string code = codeTextBox.Text;
            string name = nameTextBox.Text;
            Insert(code,name);
        }
        private void Insert(string code, string name)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection();
                string connectionString = @"Server=MDSHAHADAT; Database=StudentDB; Integrated Security=True;";
                sqlConnection.ConnectionString = connectionString;

                SqlCommand sqlCommand = new SqlCommand();
                string commandString = @"Insert Into Departments (Code, Name) Values ('"+code+"', '"+name+"')";
                sqlCommand.CommandText = commandString;

                sqlCommand.Connection = sqlConnection;

                sqlConnection.Open();
                int isExecuted;
                isExecuted= sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    MessageBox.Show("Information Saved Successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to Save");
                }

                sqlConnection.Close();

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        //private void Insert()
        //{
        //    try
        //    {
        //        SqlConnection sqlConnection = new SqlConnection();
        //        string connectionString = @"Server=MDSHAHADAT; Database=StudentDB; Integrated Security=True;";
        //        sqlConnection.ConnectionString = connectionString;

        //        SqlCommand sqlCommand = new SqlCommand();
        //        string commandString = @"Insert Into Departments (Code, Name) Values ('CSE', 'Computer Science & Engineering')";
        //        sqlCommand.CommandText = commandString;

        //        sqlCommand.Connection = sqlConnection;

        //        sqlConnection.Open();
        //        sqlCommand.ExecuteNonQuery();
        //        sqlConnection.Close();

        //    }
        //    catch (Exception exception)
        //    {
        //        MessageBox.Show(exception.Message);
        //    }
        //}
    }
}
