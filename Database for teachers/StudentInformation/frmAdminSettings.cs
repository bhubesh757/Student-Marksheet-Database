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
    public partial class frmAdminSettings : Form
    {
        private OleDbConnection Con = new OleDbConnection();
        private int[] Index = new int[0];
        private string UserName;
        public frmAdminSettings()
        {
           Con.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Students.accdb;
            Persist Security Info=False;";
            //I looked up how to do this table on https://www.youtube.com/watch?v=XeuNYFY5HSU
            //Credit goes for this youtuber for this technique.
            InitializeComponent();
            getInformation();
            
        }
        private void getInformation()
        {
            //https://www.youtube.com/watch?v=Sm5mxkytfWk&t=675s
           //I learned how to set up the table from this youtuber. Credit goes to him.
            DataTable Data = new DataTable();
            OleDbDataAdapter Adapter = new OleDbDataAdapter();
            OleDbCommand Command = new OleDbCommand();
            Command.Connection = Con;
            //Notice that in access, when merging 3 tables using left join, you must inclose the first merged table in ()
            //I have another version of this program in MySql, but unforunate I had to go with access since the MySql program only worked on my computer.
            Command.CommandText = "select tblStudents.StudentID,UserName,FirstName,LastName,Passwords,Gender,DOB,Address,Telephone,Image,MarkID,Mark1,Mark2,Mark3,Mark4,Mark5 from (tblStudents left join tblOtherInformation on tblOtherInformation.StudentID= tblStudents.StudentID) left join tblMarks on tblStudents.StudentID= tblMarks.StudentID order by tblStudents.StudentID";
            Adapter.SelectCommand = Command;
            Adapter.Fill(Data);
            dataGridStudents.DataSource = Data;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            frmAdmin Admin = new frmAdmin(true,"");
            Admin.ShowDialog();
            getInformation();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("You are about to delete user accounts, are you sure you want to delete?", "Deleting", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                Con.Open();
                bool Stop = false;
                Index = new int[dataGridStudents.SelectedRows.Count];
                int[] Information;
                //Saving the indexes of the highlighted rows.
                for (int i = 0; i < dataGridStudents.SelectedRows.Count; i++)
                {
                    Index[i] = dataGridStudents.SelectedRows[i].Index;
                }
                Information = new int[Index.Length];
                for (int i = 0; i < Index.Length; i++)
                {
                    Information[i] = Convert.ToInt32(dataGridStudents.Rows[Index[i]].Cells[0].Value);
                    //Just in case you tried to delete the admin account and ruin the program.
                    //You might try to highlight and delete 2 accounts, and one of the accounts being the admin account.
                    //Please do not bother, the program still detects the admin account, and stops you.
                    if (Information[i] == 1)
                    {
                        Stop = true;
                        MessageBox.Show("You cannot delete the admin account.");
                        break;
                    }
                }
                if (Stop == false)
                {
                    //The delete commands are put in a for loop so that the admin is allowed to delete multiple accounts in one highlight.
                    for (int i = 0; i < Index.Length; i++)
                    {
                        OleDbCommand Command = new OleDbCommand();
                        Command.Connection = Con;
                        Command.CommandText = "Delete from tblStudents where StudentID=" + Information[i] + "";
                        Command.ExecuteNonQuery();
                        Command.CommandText = "Delete from tblMarks where StudentID=" + Information[i] + "";
                        Command.ExecuteNonQuery();
                        Command.CommandText = "Delete from tblOtherInformation where StudentID=" + Information[i] + "";
                        Command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Data Deleted.");
                }
                Con.Close();
                getInformation(); 
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            bool Stop = false;
            Index = new int[dataGridStudents.SelectedRows.Count];
            string[] Information;
            for (int i = 0; i < dataGridStudents.SelectedRows.Count; i++)
            {
                Index[i] = dataGridStudents.SelectedRows[i].Index;
            }
            Information = new string[Index.Length];
            for (int i = 0; i < Index.Length; i++)
            {
                Information[i] = dataGridStudents.Rows[Index[i]].Cells[1].Value.ToString();
                if (Information[i].ToLower() == "admin")
                {
                    MessageBox.Show("You cannot edit the admin account.");
                    Stop = true;
                }
               UserName = Information[i];
            }
            //It would be very messy if the admin can edit multiple accounts are the same time, so I restricted it.
            //If the admin highlighted all the users and pressed edit, so many dialoges would open and they would be very annoying to close.
            if (Index.Length > 1)
            {
                MessageBox.Show("You can only edit one account at a time.");
                Stop = true;
            }
            if (Stop == false)
            {
                frmAdmin Admin = new frmAdmin(false, UserName);
                Admin.ShowDialog();
            }
            getInformation();
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            //Goes back to the log in page.
            frmLoggingIn LogIn = new frmLoggingIn();
            this.Hide();
            LogIn.ShowDialog();
        }
    }
}
