using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
namespace StudentInformation
{
    public partial class frmStudentView : Form
    {
      
        private OleDbConnection Con = new OleDbConnection();
        private string UserName;
        private string[] Mark = new string[5];
      
        public frmStudentView(string User)
        {
            InitializeComponent();

            //Filling the textboxes in order for the student to view his/her marks.
            Con.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Students.accdb;
            Persist Security Info=False;";
            Con.Open();
            UserName = User;
            byte[] ImageBytes;
            OleDbCommand Command = new OleDbCommand();
            Command.Connection = Con;
            Command.CommandText = "select  FirstName,LastName,Passwords,tblStudents.StudentID,DOB,Mark1,Mark2,Mark3,Mark4,Mark5,Image,Address,Telephone,Gender from (tblStudents left join tblOtherInformation on tblStudents.StudentID=tblOtherInformation.StudentID) left join tblMarks on tblMarks.StudentID= tblStudents.StudentID where UserName='" + User + "'";
            OleDbDataReader Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                txtFirstName.Text = Reader["FirstName"].ToString();
                txtLastName.Text = Reader["LastName"].ToString();
                txtStudentID.Text = Reader["StudentID"].ToString();
                txtDate.Text = Convert.ToDateTime(Reader["DOB"].ToString()).ToString("yyyy/MM/dd");
                Mark[0] = Reader["Mark1"].ToString();
                richtxtMarks.Text += Reader["Mark1"].ToString() + "\n";
                Mark[1] = Reader["Mark2"].ToString();
                richtxtMarks.Text += Reader["Mark2"].ToString() + "\n";
                Mark[2] = Reader["Mark3"].ToString();
                richtxtMarks.Text += Reader["Mark3"].ToString() + "\n";
                Mark[3] = Reader["Mark4"].ToString();
                richtxtMarks.Text += Reader["Mark4"].ToString() + "\n";
                Mark[4] = Reader["Mark5"].ToString();
                richtxtMarks.Text += Reader["Mark5"].ToString();
                txtPassword.Text = Reader["Passwords"].ToString();
                txtAddress.Text = Reader["Address"].ToString();
                txtTelephone.Text = Reader["Telephone"].ToString();
                txtGender.Text = Reader["Gender"].ToString();
                try
                {
                    ImageBytes = (byte[])Reader["Image"];
                    MemoryStream MS = new MemoryStream(ImageBytes, 0, ImageBytes.Length);
                    imgStudent.Image = Image.FromStream(MS, true);
                }
                catch { }
            }
            
            for (int i = 0; i < Mark.Length; i++)
            {
                Mark[i] = Mark[i].Replace(" ", "");
                if (Mark[i] == "")
                {
                    Array.Resize(ref Mark, i);
                    break;
                }
            }
            Marking Grading = new Marking();
            Grading.Calculation(Mark);
            txtAverage.Text = Grading._Average.ToString();
            txtLevel.Text = Grading._Level.ToString();
            Con.Close();
        }
        private void btnLog_Out_Click(object sender, EventArgs e)
        {
            frmLoggingIn FL = new frmLoggingIn();
            this.Hide();
            FL.ShowDialog();
        }

        private void btnChart_Click(object sender, EventArgs e)
        {
            Con.Open();
            OleDbCommand Command = new OleDbCommand();
            Command.Connection = Con;
            Command.CommandText = "select Mark1,Mark2,Mark3,Mark4,Mark5 from tblMarks where tblMarks.StudentID= " + txtStudentID.Text;
            OleDbDataReader Reader = Command.ExecuteReader();
            chartMarks.Series["Marks"].YValuesPerPoint = Mark.Length;
            while (Reader.Read())
            {
                foreach (var Series in chartMarks.Series)
                {
                    Series.Points.Clear();
                }
                for (int i = 0; i < Mark.Length; i++)
                {
                    this.chartMarks.Series["Marks"].Points.AddXY("Mark" + Convert.ToString(i + 1), Reader[i].ToString());
                }

            }
            Con.Close();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (var Series in chartMarks.Series)
            {
                Series.Points.Clear();
            }
        }

     



    }
}
