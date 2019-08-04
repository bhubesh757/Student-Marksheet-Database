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
    public  partial class frmAdmin : Form
    {
        //Allaith Ghadban
        //January 12,2017
        //StudentInformation
        //This program is similar to markbook, the admin can create users, and edit their accounts, by changing their names, uploading marks and etc..
        //The students can also log in to the program to see their marks. Also if they like they could see a chart of their marks.
        //Enchancements: 
        //The new admin setting form
        //The new table
        //Detecting the errors.
        private OleDbConnection Con = new OleDbConnection();
        private string LastName;
        private string FirstName;
        private string UserName;
        private bool Buttons;
        private string[] Mark = new string[5];
        public frmAdmin(bool Button,string User)
        {
            InitializeComponent();
            //Connecting to the database.
            Con.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Students.accdb;
            Persist Security Info=False;";
            comboGender.Items.Add("Male");
            comboGender.Items.Add("Female");
            comboGender.Items.Add("Other");
            Buttons = Button;
            byte[] ImageBytes;
            UserName = User;
            if (Button == false)
            {
                //False means that the admin picked that he wanted to edit a user account.
                int NumberOfMarks = Mark.Length;
                btnSave.Text = "Save changes";
                Con.Open();
                OleDbCommand Command = new OleDbCommand();
                Command.Connection = Con;
                Command.CommandText = "select  FirstName,LastName,Passwords,tblStudents.StudentID,DOB,Mark1,Mark2,Mark3,Mark4,Mark5,Image,Address,Telephone,Gender from (tblStudents left join tblOtherInformation on tblStudents.StudentID=tblOtherInformation.StudentID) left join tblMarks on tblMarks.StudentID= tblStudents.StudentID where UserName='" + User + "'";
               
                OleDbDataReader Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    txtFirstName.Text = Reader["FirstName"].ToString();
                    txtLastName.Text = Reader["LastName"].ToString();
                    txtStudentID.Text = Reader["StudentID"].ToString();
                    txtDate.Text = Convert.ToDateTime(Reader["DOB"].ToString()).ToString("yyyy-MM-dd");
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
                    comboGender.Text = Reader["Gender"].ToString();
                    // http://stackoverflow.com/questions/9173904/byte-array-to-image-conversion and http://stackoverflow.com/questions/18998763/how-to-retrieve-binary-image-from-database-using-c-sharp-in-asp-net
                    // Changing the image into binary code is obtained from stackoverflow.
                    try
                    {
                        //Changing the stored binary into an image.
                        ImageBytes = (byte[])Reader["Image"];
                        MemoryStream MS = new MemoryStream(ImageBytes, 0, ImageBytes.Length);
                        imgStudent.Image = Image.FromStream(MS, true);
                    }
                    catch { }
                }
                //Detecting how many marks are available.
                for (int i = 0; i < Mark.Length; i++)
                {
                    Mark[i] = Mark[i].Replace(" ", "");
                    if (Mark[i] == "")
                    {
                        Array.Resize(ref Mark, i);
                        break;
                    }
                }
                Reader.Close();
                Marking Grading = new Marking();
                try
                {
                    //Calculating the average and level.
                    Grading.Calculation(Mark);
                    txtAverage.Text = Grading._Average.ToString();
                    txtLevel.Text = Grading._Level.ToString();
                }
                catch { }
                Con.Close();
                Reader.Close();
            }
            if (Button == true)
            {
                //If the user decided to create a user, then it will a true.
                btnSave.Text = "Create account";
                txtStudentID.Visible = false;
                lblStudentID.Visible = false;
                txtAverage.Visible = false;
                txtLevel.Visible = false;
                lblLevel.Visible = false;
                lblAverage.Visible = false;
            }
        }
        private void ClearLabels()
        {
            lblFirstNameError.Visible = false;
            lblLastNameError.Visible = false;
            lblDOBError.Visible = false;
            lblGenderError.Visible = false;
            lblTelephoneError.Visible = false;
            lblAddressError.Visible = false;
            lblPasswordError.Visible = false;
            lblImageError.Visible = false;
            lblMarksError.Visible = false;
        }
        private string CapitalizeFirstLetter(string Word)
        {
            string Temp = "";
            for (int i = 0; i < Word.Length; i++)
            {
                if (i == 0)
                {
                    Temp = Temp + Word[i].ToString().ToUpper();
                }
                else
                {
                    Temp = Temp + Word[i].ToString().ToLower();
                }
            }
            return Temp;
        }
        private bool NumberAndLetterOnly(string Word)
        {
            for (int i = 0; i < Word.Length; i++)
            {
                if (Word[i].ToString().Any(char.IsLetter) == false&& Word[i].ToString().Any(char.IsDigit)==false)
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckM(string Word)
        {
            for (int i = 0; i < Word.Length; i++)
            {
                if (Word[i].ToString().Any(char.IsLetter) == false)
                {
                    return false;
                }
            }
            return true;
        }
        private string UpperCase(string Word)
        {
            string Return = "";
            for (int i = 0; i < Word.Length; i++)
            {
                if (char.IsLetter(Word[i]) == true)
                {
                    Return = Return + Word[i].ToString().ToUpper();
                }
                else
                {
                    Return = Return + Word[i];
                }
            }
            return Return;
        }
        //The reason why I declared this method is because the ToLower method crashes when there is a number or a random symbol in it, so I created my own method that works better than the built in.
        private string LowerCase(string Word)
        {
            string Return = "";
            for (int i = 0; i < Word.Length; i++)
            {
                if (char.IsLetter(Word[i]) == true)
                {
                    Return = Return + Word[i].ToString().ToLower();
                }
                else
                {
                    Return = Return + Word[i];
                }
            }
            return Return;
        }
      
        private byte[] ConvertImagetoBinary()
        {
            using (MemoryStream MS = new MemoryStream())
            {
                //Credit goes to stackoverflow for the method ConvertImageToBinary and this parameter code.  
                //http://stackoverflow.com/questions/17352061/fastest-way-to-convert-image-to-byte-array
                imgStudent.Image.Save(MS, System.Drawing.Imaging.ImageFormat.Jpeg);
                return MS.ToArray();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are you sure you to do this action?", "Confirming", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                if (Buttons == true)
                {
                    ClearLabels();
                    bool Checker = false;
                    Mark = new string[5];
                    DateTime DOB;
                    long Telephone;
                    int NumberOfMarks = 0;
                    Con.Open();
                    txtFirstName.Text = txtFirstName.Text.Replace(" ", "");
                    txtLastName.Text = txtLastName.Text.Replace(" ", "");
                    txtPassword.Text = txtPassword.Text.Replace(" ", "");
                    txtTelephone.Text = txtTelephone.Text.Replace(" ", "");
                    //Removing all spaces, just incase the user puts a space in one of the boxes.
                    //All these if statements detected the kind of errors in each textbox, whether it is because the textbox is empty, or if inappropriate data is entered into the textbox.
                    //Such as a number in a name, or a wrong date.
                    if (comboGender.Text == "")
                    {
                        lblGenderError.Visible = true;
                        lblGenderError.Text = "Fill out this box.";
                        Checker = true;
                    }
                    if (txtAddress.Text.Replace(" ", "") == "")
                    {
                        lblAddressError.Visible = true;
                        lblAddressError.Text = "Fill out this box.";
                        Checker = true;
                    }
                    if (txtPassword.Text == "")
                    {
                        lblPasswordError.Visible = true;
                        lblPasswordError.Text = "Fill out this box.";
                        Checker = true;
                    }
                    if (imgStudent.Image == null)
                    {
                        lblImageError.Visible = true;
                        lblImageError.Text = "Put an image here.";
                        Checker = true;
                    }
                    if (!long.TryParse(txtTelephone.Text, out Telephone) || Telephone.ToString().Length != 10)
                    {
                        Checker = true;
                        lblTelephoneError.Visible = true;
                        lblTelephoneError.Text = "Telephone number\nshould consist of only\nintegers and it should be 10 digits in length.";
                        if (txtTelephone.Text == "")
                        {
                            lblTelephoneError.Visible = true;
                            lblTelephoneError.Text = "Fill out this box.";
                        }
                    }
                    if (txtFirstName.Text == "")
                    {
                        lblFirstNameError.Visible = true;
                        lblFirstNameError.Text = "Fill out this box.";
                        Checker = true;
                    }
                    if (CheckM(txtFirstName.Text) == false)
                    {
                        lblFirstNameError.Visible = true;
                        //If the user entered a string with numbers and letters only, then the program will output that there cannot be numbers in the first name.
                        if (NumberAndLetterOnly(txtFirstName.Text) == true && txtFirstName.Text.Any(char.IsDigit) == true)
                        {
                            lblFirstNameError.Text = "The first name cannot have numbers in it.";
                        }
                        //If there are no numbers detected and the string does not consist of numbers and letters only, then clearly the user put a random symbol like ? ! . @
                        if (txtFirstName.Text.Any(char.IsDigit) == false && NumberAndLetterOnly(txtFirstName.Text) == false)
                        {
                            lblFirstNameError.Text = "The first name cannot have random symbols in it.";
                        }
                        //If numbers are detected, but there are not only letters and numbers then clearly there are numbers and random symbols.
                        if (txtFirstName.Text.Any(char.IsDigit) == true && NumberAndLetterOnly(txtFirstName.Text) == false)
                        {
                            lblFirstNameError.Text = "The first name cannot have numbers or random symbols in it.";
                        }
                        Checker = true;
                    }
                    FirstName = txtFirstName.Text;
                    if (txtLastName.Text == "")
                    {
                        lblLastNameError.Visible = true;
                        lblLastNameError.Text = "Fill out this box.";
                        Checker = true;
                    }
                    if (CheckM(txtLastName.Text) == false)
                    {
                        lblLastNameError.Visible = true;

                        if (NumberAndLetterOnly(txtLastName.Text) == true && txtLastName.Text.Any(char.IsDigit) == true)
                        {
                            lblLastNameError.Text = "The last name cannot have numbers in it.";
                        }
                        if (txtLastName.Text.Any(char.IsDigit) == false && NumberAndLetterOnly(txtLastName.Text) == false)
                        {
                            lblLastNameError.Text = "The last name cannot have random symbols in it.";
                        }
                        if (txtLastName.Text.Any(char.IsDigit) == true && NumberAndLetterOnly(txtLastName.Text) == false)
                        {
                            lblLastNameError.Text = "The last name cannot have numbers or random symbols in it.";
                        }
                        Checker = true;
                    }
                    LastName = txtLastName.Text;
                    if (!DateTime.TryParse(txtDate.Text, out DOB))
                    {
                        Checker = true;
                        lblDOBError.Visible = true;
                        lblDOBError.Text = "Error with the date.";
                        if (txtDate.Text.Replace(" ", "") == "")
                        {
                            lblDOBError.Visible = true;
                            lblDOBError.Text = "Fill out this box.";
                        }
                    }

                    int Reptitions = richtxtMarks.Lines.Length;
                    for (int i = 0; i < richtxtMarks.Lines.Length; i++)
                    {
                        //The reason why I declared this for loop is because, let us say the user only put 3 marks in, if there is an empty space on mark4 and mark5, the program will eliminate the space, by reducing the number of repetitions
                        //thus the array will not reach these areas.
                       
                        if (richtxtMarks.Lines[i].Replace(" ","") == "")
                        {
                            Reptitions--;
                        }
                    }
                  
                    for (int i = 0; i < Reptitions; i++)
                    {
                        try
                        {
                                double Check;
                                if (!double.TryParse(richtxtMarks.Lines[i], out Check))
                                {
                                    Checker = true;
                                    lblMarksError.Visible = true;
                                    lblMarksError.Text = "Error with the marks.";
                                    break;
                                }
                                //Detecting if the marks are within the range of 0 to 100.
                                if (Check > 100 || Check < 0)
                                {
                                    lblMarksError.Visible = true;
                                    lblMarksError.Text = "Marks can only be from 0 to 100";
                                    Checker = true;
                                    break;
                                }
                                Check = Math.Round(Check, 1);
                                Mark[i] = Check.ToString();
                        }
                        catch
                        {
                            NumberOfMarks = i + 1;
                        }
                    }
                    //Checking if the textbox is empty.
                    //I removed all spaces and enters, since you might try to crash my program by simply just putting a space or enter and then saving it.
                    if (richtxtMarks.Text.Replace(" ", "").Replace("\n", "") == "")
                    {
                        lblMarksError.Visible = true;
                        lblMarksError.Text = "Fill out this box.";
                        Checker = true;
                    }
                    if (NumberOfMarks > 5)
                    {
                        lblMarksError.Visible = true;
                        lblMarksError.Text = "You cannot have more than 5 marks.";
                        Checker = true;
                    }
                   //The program accesses the computer's cloak and checks if the date of birth occured past the current time, if it does, the program outputs an error.
                    if (DOB > DateTime.Now)
                    {
                        lblDOBError.Visible = true;
                        lblDOBError.Text = "You cannot be born in the future.";
                        Checker = true;

                    }
                    OleDbCommand Command = new OleDbCommand();
                    Command.Connection = Con;
                    if (Checker == false)
                    {
                        //For the StudentID variable, I am using it as a counter and also as the StudentID itself.
                        //I did this to spare myself 4 bytes.
                        int StudentID = 0;
                        Command.CommandText = "select StudentID from tblStudents order by StudentID";
                        OleDbDataReader Reader = Command.ExecuteReader();
                        while (Reader.Read())
                        {
                            StudentID++;
                        }
                        int[] StudentIDArray = new int[StudentID];
                        StudentID = 0;
                        Reader.Close();
                        Command.CommandText = "select StudentID from tblStudents order by StudentID";
                        Reader = Command.ExecuteReader();
                        while (Reader.Read())
                        {
                            StudentIDArray[StudentID] = Convert.ToInt32(Reader["StudentID"]);
                            StudentID++;
                        }
                        StudentID = 1;
                        for (int i = 0; i < StudentIDArray.Length; i++)
                        {
                            //This for loop checks if the StudentID exists.
                            //If it does, then the program will add one to the StudentID, and the for loop will start all over again by declaring i to -1.
                            if (StudentID == StudentIDArray[i])
                            {
                                StudentID++;
                                i = -1;
                            }
                        }
                        Reader.Close();
                        Command.CommandText = "select UserName from tblStudents";
                        Reader = Command.ExecuteReader();
                        int Counter = 0;
                        while (Reader.Read())
                        {
                            //Counting how many users there are.
                            Counter++;
                        }
                        Reader.Close();
                        Command.CommandText = "select UserName from tblStudents";
                        Reader = Command.ExecuteReader();
                        string[] Users = new string[Counter];
                        Counter = 0;
                        while (Reader.Read())
                        {
                            Users[Counter] = Reader["UserName"].ToString();
                            Users[Counter] = LowerCase(Users[Counter]);
                            Counter++;
                        }
                        Counter = 1;
                        UserName = FirstName[0] + "" + LastName[0];
                        for (int i = 0; i < Users.Length; i++)
                        {
                            //I change the username and other usernames to lowercase so they could be compared correctly. 
                            //For example, without changing them all to lowercase the program will see that Spanky is not the same as spanky.
                            if (LowerCase(UserName) == LowerCase(Users[i]))
                            {
                                //The username consists of the initial of the person, the first letter of the their first name and the first letter of their last name.
                                UserName = FirstName[0] + "" + LastName[0] + Counter.ToString();
                                //You might be confused of why I declared i to -1
                                //What I intend to do is to reset the for loop
                                //If I declared it to 0, the for loop ends will start at 1
                                //And that is not what I want
                                //In order for the program to work, the array must search all values, so it must start at 0.
                                i = -1;
                                Counter++;
                            }
                        }
                       
                        UserName = UserName.ToUpper();
                        Reader.Close();
                        FirstName = CapitalizeFirstLetter(FirstName);
                        LastName = CapitalizeFirstLetter(LastName);
                        //Uploading all the values
                        Command.CommandText = "INSERT INTO tblStudents (FirstName, LastName,DOB,Passwords,StudentID,UserName) values ('" + FirstName + "','" + LastName + "','" + DOB.ToString("yyyy-MM-dd") + "','" + txtPassword.Text + "','" + StudentID + "','" + UserName + "')";
                        Command.ExecuteNonQuery();
                        Command.CommandText = "INSERT into tblMarks (Mark1,Mark2, Mark3, Mark4, Mark5,StudentID,MarkID) values ('" + Mark[0] + "','" + Mark[1] + "','" + Mark[2] + "','" + Mark[3] + "','" + Mark[4] + "','" + StudentID + "','" + StudentID + "')";
                        Command.ExecuteNonQuery();
                        //The image field takes square brackets [], because in order to reference a field such an Ole object, the field must be inclosed by the square brackets. This exception only occurs in access.
                        Command.CommandText = "Insert into tblOtherInformation(Address,Telephone,Gender,StudentID,[Image]) values ('" + txtAddress.Text + "','" + Telephone + "','" + comboGender.Text + "','" + StudentID + "', @Image)";
                       //Changing the image into binary in order to upload it.
                        Command.Parameters.AddWithValue("@Image", ConvertImagetoBinary());
                        Command.ExecuteNonQuery();
                        Con.Close();
                        this.Hide();
                        MessageBox.Show("Data saved successfully!");
                    }
                    if (Checker == true)
                    {
                        MessageBox.Show("Error with the inputed information.");
                    }
                    Con.Close();
                }
                if (Buttons == false)
                {
                    //Uploading any changes to the program.
                    Mark = new string[5];
                    bool Checker = false;
                    long Telephone;
                    int NumberOfMarks = 0;
                    DateTime DOB;
                    txtFirstName.Text = txtFirstName.Text.Replace(" ", "");
                    txtLastName.Text = txtLastName.Text.Replace(" ", "");
                    txtPassword.Text = txtPassword.Text.Replace(" ", "");
                    txtTelephone.Text = txtTelephone.Text.Replace(" ", "");
                    ClearLabels();
                    if (comboGender.Text == "")
                    {
                        lblGenderError.Visible = true;
                        lblGenderError.Text = "Fill out this box.";
                        Checker = true;
                    }
                    if (txtPassword.Text == "")
                    {
                        lblPasswordError.Visible = true;
                        lblPasswordError.Text = "Fill out this box.";
                        Checker = true;
                    }
                    if (txtAddress.Text.Replace(" ", "") == "")
                    {
                        lblAddressError.Visible = true;
                        lblAddressError.Text = "Fill out this box.";
                        Checker = true;
                    }
                    if (imgStudent.Image == null)
                    {
                        lblImageError.Visible = true;
                        lblImageError.Text = "Put an image here.";
                        Checker = true;
                    }
                    if (!long.TryParse(txtTelephone.Text, out Telephone) || Telephone.ToString().Length != 10)
                    {
                        lblTelephoneError.Visible = true;
                        lblTelephoneError.Text = "Telephone number\nshould consist of only\nintegers and it should be 10 digits in length.";
                        if (txtTelephone.Text == "")
                        {
                            lblTelephoneError.Visible = true;
                            lblTelephoneError.Text = "Fill out this box.";
                        }
                        Checker = true;
                    }
                    if (txtFirstName.Text == "")
                    {
                        lblFirstNameError.Visible = true;
                        lblFirstNameError.Text = "Fill out this box.";
                        Checker = true;
                    }
                    if (CheckM(txtFirstName.Text) == false)
                    {
                        lblFirstNameError.Visible = true;

                        if (NumberAndLetterOnly(txtFirstName.Text) == true && txtFirstName.Text.Any(char.IsDigit) == true)
                        {
                            lblFirstNameError.Text = "The first name cannot have numbers in it.";
                        }
                        if (txtFirstName.Text.Any(char.IsDigit) == false && NumberAndLetterOnly(txtFirstName.Text) == false)
                        {
                            lblFirstNameError.Text = "The first name cannot have random symbols in it.";
                        }
                        if (txtFirstName.Text.Any(char.IsDigit) == true && NumberAndLetterOnly(txtFirstName.Text) == false)
                        {
                            lblFirstNameError.Text = "The first name cannot have numbers or random symbols in it.";
                        }
                        Checker = true;
                    }
                    
                    if (txtLastName.Text == "")
                    {
                        Checker = true;
                        lblLastNameError.Visible = true;
                        lblLastNameError.Text = "Fill out this box.";
                    }
                    if (CheckM(txtLastName.Text) == false)
                    {
                        lblLastNameError.Visible = true;

                        if (NumberAndLetterOnly(txtLastName.Text) == true && txtLastName.Text.Any(char.IsDigit) == true)
                        {
                            lblLastNameError.Text = "The last name cannot have numbers in it.";
                        }
                        if (txtLastName.Text.Any(char.IsDigit) == false && NumberAndLetterOnly(txtLastName.Text) == false)
                        {
                            lblLastNameError.Text = "The last name cannot have random symbols in it.";
                        }
                        if (txtLastName.Text.Any(char.IsDigit) == true && NumberAndLetterOnly(txtLastName.Text) == false)
                        {
                            lblLastNameError.Text = "The last name cannot have numbers or random symbols in it.";
                        }
                        Checker = true;
                    }
                    if (!DateTime.TryParse(txtDate.Text, out DOB))
                    {
                        lblDOBError.Visible = true;
                        lblDOBError.Text = "Error with the date.";
                        if (txtDate.Text.Replace(" ", "") == "")
                        {
                            lblDOBError.Visible = true;
                            lblDOBError.Text = "Fill out this box.";
                        }
                        Checker = true;
                    }
                  
                    int Repetitions = richtxtMarks.Lines.Length;
                    for (int i = 0; i < richtxtMarks.Lines.Length; i++)
                    {
                        //The reason why I declared this for loop is because, let us say the user only put 3 marks in, if there is an empty space on mark4 and mark5, the program will eliminate the space, by reducing the number of repetitions
                        //thus the array will not reach these areas.
                        if (richtxtMarks.Lines[i].Replace(" ","") == "")
                        {
                            Repetitions--;
                        }
                    }
                    for (int i = 0; i < Repetitions; i++)
                    {
                        try
                        {
                            double Check;
                            if (!double.TryParse(richtxtMarks.Lines[i], out Check))
                            {
                                lblMarksError.Visible = true;
                                lblMarksError.Text = "Error with the marks.";
                                Checker = true;
                                break;
                            }
                            if (Check > 100 || Check < 0)
                            {
                                lblMarksError.Visible = true;
                                lblMarksError.Text = "Marks can only be from 0 to 100";
                                Checker = true;
                            }
                            Check = Math.Round(Check, 1);
                            Mark[i] = Check.ToString();

                        }
                        catch
                        {
                            NumberOfMarks = i + 1;
                        }
                    }
                    if (richtxtMarks.Text.Replace(" ", "").Replace("\n", "") == "")
                    {
                        lblMarksError.Visible = true;
                        lblMarksError.Text = "Fill out this box.";
                        Checker = true;
                    }
                    if (NumberOfMarks > 5)
                    {
                        lblMarksError.Visible = true;
                        lblMarksError.Text = "You cannot have more than 5 marks.";
                        Checker = true;
                    }
                    if (DOB > DateTime.Now)
                    {
                        lblDOBError.Visible = true;
                        lblDOBError.Text = "You cannot be born in the future.";
                        Checker = true;
                    }
                    if (Checker == false)
                    {
                        Con.Open();
                        FirstName = CapitalizeFirstLetter(txtFirstName.Text);
                        LastName = CapitalizeFirstLetter(txtLastName.Text);
                        OleDbCommand Command = new OleDbCommand();
                        Command.Connection = Con;
                        //Same as the insert code except it is update.
                        Command.CommandText = "update tblStudents set FirstName='" + FirstName + "', LastName='" + LastName + "', Passwords='" + txtPassword.Text + "', DOB='" + DOB.ToString("yyyy-MM-dd") + "' where StudentID = " + txtStudentID.Text ;
                        Command.ExecuteNonQuery();
                        Command.CommandText = "Update tblMarks set Mark1='" + Mark[0] + "', Mark2 ='" + Mark[1] + "', Mark3='" + Mark[2] + "', Mark4='" + Mark[3] + "', Mark5='" + Mark[4] + "' where StudentID=" + txtStudentID.Text;
                        Command.ExecuteNonQuery();
                        Command.CommandText = "Update tblOtherInformation set Address='" + txtAddress.Text + "',Gender='" + comboGender.Text + "', Telephone ='" + Telephone + "', [Image] = @Image where StudentID=" + txtStudentID.Text;
                        Command.Parameters.AddWithValue("@Image", ConvertImagetoBinary());
                        Command.ExecuteNonQuery();
                        MessageBox.Show("The changes have been saved.");
                        Con.Close();
                        this.Hide();
                    }
                    if (Checker == true)
                    {
                        MessageBox.Show("Error in the inputed information.");
                    }
                }
                Con.Close();
            }
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            //Inserting an image.
            OpenFileDialog FD = new OpenFileDialog();
            if (FD.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    imgStudent.Image = new Bitmap(FD.FileName);
                }
                catch
                {
                    MessageBox.Show("Please enter a proper image.");
                }
            }
        }
    }
}
