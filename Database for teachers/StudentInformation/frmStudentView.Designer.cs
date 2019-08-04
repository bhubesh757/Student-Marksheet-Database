namespace StudentInformation
{
    partial class frmStudentView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.btnLog_Out = new System.Windows.Forms.Button();
            this.btnChart = new System.Windows.Forms.Button();
            this.txtLevel = new System.Windows.Forms.TextBox();
            this.lblLevel = new System.Windows.Forms.Label();
            this.lblMark5 = new System.Windows.Forms.Label();
            this.lblMark4 = new System.Windows.Forms.Label();
            this.lblMark3 = new System.Windows.Forms.Label();
            this.lblMark2 = new System.Windows.Forms.Label();
            this.lblMark1 = new System.Windows.Forms.Label();
            this.txtAverage = new System.Windows.Forms.TextBox();
            this.lblAverage = new System.Windows.Forms.Label();
            this.richtxtMarks = new System.Windows.Forms.RichTextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblStudentID = new System.Windows.Forms.Label();
            this.chartMarks = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.lblTelephone = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ImageGroupBox = new System.Windows.Forms.GroupBox();
            this.imgStudent = new System.Windows.Forms.PictureBox();
            this.txtGender = new System.Windows.Forms.TextBox();
            this.groupBoxInformation = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartMarks)).BeginInit();
            this.ImageGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgStudent)).BeginInit();
            this.groupBoxInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(299, 60);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.ReadOnly = true;
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 82;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(224, 67);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 81;
            this.lblPassword.Text = "Password:";
            // 
            // btnLog_Out
            // 
            this.btnLog_Out.Location = new System.Drawing.Point(597, 357);
            this.btnLog_Out.Name = "btnLog_Out";
            this.btnLog_Out.Size = new System.Drawing.Size(75, 23);
            this.btnLog_Out.TabIndex = 80;
            this.btnLog_Out.Text = "Log out";
            this.btnLog_Out.UseVisualStyleBackColor = true;
            this.btnLog_Out.Click += new System.EventHandler(this.btnLog_Out_Click);
            // 
            // btnChart
            // 
            this.btnChart.Location = new System.Drawing.Point(214, 442);
            this.btnChart.Name = "btnChart";
            this.btnChart.Size = new System.Drawing.Size(75, 23);
            this.btnChart.TabIndex = 79;
            this.btnChart.Text = "Chart";
            this.btnChart.UseVisualStyleBackColor = true;
            this.btnChart.Click += new System.EventHandler(this.btnChart_Click);
            // 
            // txtLevel
            // 
            this.txtLevel.Location = new System.Drawing.Point(299, 178);
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.ReadOnly = true;
            this.txtLevel.Size = new System.Drawing.Size(100, 20);
            this.txtLevel.TabIndex = 78;
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Location = new System.Drawing.Point(224, 181);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(36, 13);
            this.lblLevel.TabIndex = 77;
            this.lblLevel.Text = "Level:";
            // 
            // lblMark5
            // 
            this.lblMark5.AutoSize = true;
            this.lblMark5.Location = new System.Drawing.Point(116, 274);
            this.lblMark5.Name = "lblMark5";
            this.lblMark5.Size = new System.Drawing.Size(40, 13);
            this.lblMark5.TabIndex = 76;
            this.lblMark5.Text = "Mark5:";
            // 
            // lblMark4
            // 
            this.lblMark4.AutoSize = true;
            this.lblMark4.Location = new System.Drawing.Point(116, 261);
            this.lblMark4.Name = "lblMark4";
            this.lblMark4.Size = new System.Drawing.Size(40, 13);
            this.lblMark4.TabIndex = 75;
            this.lblMark4.Text = "Mark4:";
            // 
            // lblMark3
            // 
            this.lblMark3.AutoSize = true;
            this.lblMark3.Location = new System.Drawing.Point(116, 248);
            this.lblMark3.Name = "lblMark3";
            this.lblMark3.Size = new System.Drawing.Size(40, 13);
            this.lblMark3.TabIndex = 74;
            this.lblMark3.Text = "Mark3:";
            // 
            // lblMark2
            // 
            this.lblMark2.AutoSize = true;
            this.lblMark2.Location = new System.Drawing.Point(116, 235);
            this.lblMark2.Name = "lblMark2";
            this.lblMark2.Size = new System.Drawing.Size(40, 13);
            this.lblMark2.TabIndex = 73;
            this.lblMark2.Text = "Mark2:";
            // 
            // lblMark1
            // 
            this.lblMark1.AutoSize = true;
            this.lblMark1.Location = new System.Drawing.Point(116, 222);
            this.lblMark1.Name = "lblMark1";
            this.lblMark1.Size = new System.Drawing.Size(40, 13);
            this.lblMark1.TabIndex = 72;
            this.lblMark1.Text = "Mark1:";
            // 
            // txtAverage
            // 
            this.txtAverage.Location = new System.Drawing.Point(299, 139);
            this.txtAverage.Name = "txtAverage";
            this.txtAverage.ReadOnly = true;
            this.txtAverage.Size = new System.Drawing.Size(100, 20);
            this.txtAverage.TabIndex = 71;
            // 
            // lblAverage
            // 
            this.lblAverage.AutoSize = true;
            this.lblAverage.Location = new System.Drawing.Point(224, 146);
            this.lblAverage.Name = "lblAverage";
            this.lblAverage.Size = new System.Drawing.Size(50, 13);
            this.lblAverage.TabIndex = 70;
            this.lblAverage.Text = "Average:";
            // 
            // richtxtMarks
            // 
            this.richtxtMarks.Location = new System.Drawing.Point(162, 222);
            this.richtxtMarks.Name = "richtxtMarks";
            this.richtxtMarks.ReadOnly = true;
            this.richtxtMarks.Size = new System.Drawing.Size(182, 75);
            this.richtxtMarks.TabIndex = 69;
            this.richtxtMarks.Text = "";
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(106, 99);
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(100, 20);
            this.txtDate.TabIndex = 68;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(106, 60);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.ReadOnly = true;
            this.txtLastName.Size = new System.Drawing.Size(100, 20);
            this.txtLastName.TabIndex = 67;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(106, 25);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.ReadOnly = true;
            this.txtFirstName.Size = new System.Drawing.Size(100, 20);
            this.txtFirstName.TabIndex = 66;
            // 
            // txtStudentID
            // 
            this.txtStudentID.Location = new System.Drawing.Point(299, 25);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.ReadOnly = true;
            this.txtStudentID.Size = new System.Drawing.Size(100, 20);
            this.txtStudentID.TabIndex = 65;
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Location = new System.Drawing.Point(24, 102);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(39, 13);
            this.lblDateOfBirth.TabIndex = 64;
            this.lblDateOfBirth.Text = "D.O.B:";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(24, 60);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(61, 13);
            this.lblLastName.TabIndex = 63;
            this.lblLastName.Text = "Last Name:";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(25, 25);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(60, 13);
            this.lblFirstName.TabIndex = 62;
            this.lblFirstName.Text = "First Name:";
            // 
            // lblStudentID
            // 
            this.lblStudentID.AutoSize = true;
            this.lblStudentID.Location = new System.Drawing.Point(224, 28);
            this.lblStudentID.Name = "lblStudentID";
            this.lblStudentID.Size = new System.Drawing.Size(61, 13);
            this.lblStudentID.TabIndex = 61;
            this.lblStudentID.Text = "Student ID:";
            // 
            // chartMarks
            // 
            chartArea1.Name = "chartMarks";
            this.chartMarks.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartMarks.Legends.Add(legend1);
            this.chartMarks.Location = new System.Drawing.Point(21, 238);
            this.chartMarks.Name = "chartMarks";
            series1.ChartArea = "chartMarks";
            series1.Legend = "Legend1";
            series1.Name = "Marks";
            this.chartMarks.Series.Add(series1);
            this.chartMarks.Size = new System.Drawing.Size(301, 198);
            this.chartMarks.TabIndex = 84;
            this.chartMarks.Text = "Marks";
            // 
            // txtTelephone
            // 
            this.txtTelephone.Location = new System.Drawing.Point(106, 178);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.ReadOnly = true;
            this.txtTelephone.Size = new System.Drawing.Size(100, 20);
            this.txtTelephone.TabIndex = 88;
            // 
            // lblTelephone
            // 
            this.lblTelephone.AutoSize = true;
            this.lblTelephone.Location = new System.Drawing.Point(25, 185);
            this.lblTelephone.Name = "lblTelephone";
            this.lblTelephone.Size = new System.Drawing.Size(61, 13);
            this.lblTelephone.TabIndex = 87;
            this.lblTelephone.Text = "Telephone:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(106, 136);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(100, 20);
            this.txtAddress.TabIndex = 86;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(25, 143);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(48, 13);
            this.lblAddress.TabIndex = 85;
            this.lblAddress.Text = "Address:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(224, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 89;
            this.label1.Text = "Gender:";
            // 
            // ImageGroupBox
            // 
            this.ImageGroupBox.Controls.Add(this.imgStudent);
            this.ImageGroupBox.Location = new System.Drawing.Point(31, 12);
            this.ImageGroupBox.Name = "ImageGroupBox";
            this.ImageGroupBox.Size = new System.Drawing.Size(271, 220);
            this.ImageGroupBox.TabIndex = 91;
            this.ImageGroupBox.TabStop = false;
            this.ImageGroupBox.Text = "Inserted Image";
            // 
            // imgStudent
            // 
            this.imgStudent.Location = new System.Drawing.Point(17, 19);
            this.imgStudent.Name = "imgStudent";
            this.imgStudent.Size = new System.Drawing.Size(241, 185);
            this.imgStudent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgStudent.TabIndex = 1;
            this.imgStudent.TabStop = false;
            // 
            // txtGender
            // 
            this.txtGender.Location = new System.Drawing.Point(299, 102);
            this.txtGender.Name = "txtGender";
            this.txtGender.ReadOnly = true;
            this.txtGender.Size = new System.Drawing.Size(100, 20);
            this.txtGender.TabIndex = 92;
            // 
            // groupBoxInformation
            // 
            this.groupBoxInformation.Controls.Add(this.txtAddress);
            this.groupBoxInformation.Controls.Add(this.txtGender);
            this.groupBoxInformation.Controls.Add(this.lblStudentID);
            this.groupBoxInformation.Controls.Add(this.lblFirstName);
            this.groupBoxInformation.Controls.Add(this.label1);
            this.groupBoxInformation.Controls.Add(this.txtLevel);
            this.groupBoxInformation.Controls.Add(this.lblLastName);
            this.groupBoxInformation.Controls.Add(this.lblLevel);
            this.groupBoxInformation.Controls.Add(this.txtTelephone);
            this.groupBoxInformation.Controls.Add(this.lblMark5);
            this.groupBoxInformation.Controls.Add(this.lblDateOfBirth);
            this.groupBoxInformation.Controls.Add(this.lblMark4);
            this.groupBoxInformation.Controls.Add(this.lblTelephone);
            this.groupBoxInformation.Controls.Add(this.lblMark3);
            this.groupBoxInformation.Controls.Add(this.txtStudentID);
            this.groupBoxInformation.Controls.Add(this.lblMark2);
            this.groupBoxInformation.Controls.Add(this.txtFirstName);
            this.groupBoxInformation.Controls.Add(this.lblMark1);
            this.groupBoxInformation.Controls.Add(this.lblAddress);
            this.groupBoxInformation.Controls.Add(this.txtAverage);
            this.groupBoxInformation.Controls.Add(this.txtLastName);
            this.groupBoxInformation.Controls.Add(this.lblAverage);
            this.groupBoxInformation.Controls.Add(this.txtDate);
            this.groupBoxInformation.Controls.Add(this.richtxtMarks);
            this.groupBoxInformation.Controls.Add(this.txtPassword);
            this.groupBoxInformation.Controls.Add(this.lblPassword);
            this.groupBoxInformation.Location = new System.Drawing.Point(328, 12);
            this.groupBoxInformation.Name = "groupBoxInformation";
            this.groupBoxInformation.Size = new System.Drawing.Size(438, 309);
            this.groupBoxInformation.TabIndex = 93;
            this.groupBoxInformation.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(451, 357);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 94;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(48, 442);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 95;
            this.btnClear.Text = "Clear Chart";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frmStudentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 469);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBoxInformation);
            this.Controls.Add(this.ImageGroupBox);
            this.Controls.Add(this.chartMarks);
            this.Controls.Add(this.btnLog_Out);
            this.Controls.Add(this.btnChart);
            this.Name = "frmStudentView";
            this.Text = "Student View";
            ((System.ComponentModel.ISupportInitialize)(this.chartMarks)).EndInit();
            this.ImageGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgStudent)).EndInit();
            this.groupBoxInformation.ResumeLayout(false);
            this.groupBoxInformation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button btnLog_Out;
        private System.Windows.Forms.Button btnChart;
        private System.Windows.Forms.TextBox txtLevel;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label lblMark5;
        private System.Windows.Forms.Label lblMark4;
        private System.Windows.Forms.Label lblMark3;
        private System.Windows.Forms.Label lblMark2;
        private System.Windows.Forms.Label lblMark1;
        private System.Windows.Forms.TextBox txtAverage;
        private System.Windows.Forms.Label lblAverage;
        private System.Windows.Forms.RichTextBox richtxtMarks;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblStudentID;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMarks;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.Label lblTelephone;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox ImageGroupBox;
        private System.Windows.Forms.PictureBox imgStudent;
        private System.Windows.Forms.TextBox txtGender;
        private System.Windows.Forms.GroupBox groupBoxInformation;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnClear;


    }
}