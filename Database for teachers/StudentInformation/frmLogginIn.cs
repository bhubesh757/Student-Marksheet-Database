using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace StudentInformation
{
    public partial class frmLoggingIn : Form
    {
        private OleDbConnection Con = new OleDbConnection();
        public frmLoggingIn()
        {
            InitializeComponent();
            //https://www.connectionstrings.com/access/
            //Establishing connection.
            //https://www.microsoft.com/en-US/download/details.aspx?id=13255
            //Download the database adapter.
            Con.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Students.accdb;
            Persist Security Info=False;";
        }
        private string FirstName;
        private string LastName;
        public  string UserName;
        private void btnlogin_Click(object sender, EventArgs e)
        {
                bool Success = false;
                Con.Open();
                OleDbCommand Command = new OleDbCommand();
                Command.Connection = Con;
                Command.CommandText = "select FirstName, LastName from tblstudents where Username ='" + txtUsername.Text + "'And Passwords = '" + txtPassword.Text + "'";
                OleDbDataReader Read = Command.ExecuteReader();
                //This counter was declared to see if a match for the entered username and password was found.
                int Counter = 0;
                while (Read.Read())
                {
                    FirstName = Read["FirstName"].ToString();
                    LastName = Read["LastName"].ToString();
                    Counter++;
                }
                if (Counter == 1)
                {
                    MessageBox.Show("Welcome! " + FirstName + " " + LastName);
                    UserName = txtUsername.Text;
                    Success = true;
                }
                else
                {
                    MessageBox.Show("Invalid password or username.");
                }
                if (Success == true && txtUsername.Text.ToLower() == "admin")
                {
                    frmAdminSettings Ad = new frmAdminSettings();
                    Success = false;
                    this.Hide();
                    Ad.ShowDialog();
                }
                if (Success == true)
                {
                    frmStudentView SV = new frmStudentView(UserName);
                    this.Hide();
                    SV.ShowDialog();
                }
                Con.Close();
            
            }
        private void frmLoggingIn_Load(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                lblConnection.Text = "Connected";
                Con.Close();
            }
            catch { }
        }
    }
}
