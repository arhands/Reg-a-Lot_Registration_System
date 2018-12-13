﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistrationSystem
{
    public partial class ProfessorView : Form
    {
        List<SectionStudent> updateGrade = new List<SectionStudent>();
        string[] semesterIndex = LogIn.user.GetSemesters();

        public ProfessorView()
        {

            InitializeComponent();
            SetLabels();
            UserViewComboBox_Load();
            SemesterComboBox_Load();
            AddDropSemesterComboBox_Load();
            AddDropCoursesComboBox_Load();

            StudentGridView.CellEndEdit += StudentGridView_CellEndEdit;
        }

        private void StudentGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var row = StudentGridView.Rows[e.RowIndex];
            var id = Convert.ToInt32(row.Cells[0].Value);
            var grade = row.Cells[3].Value as string;
            if (grade == null)
                grade = "";
            if (grade.Length > 10)
                grade = grade.Substring(0, 10).ToUpper();
            row.Cells[3].Value = grade;
            LogIn.user.SetGrade(id, grade,selectedSection.SectionNumber);
        }

        //=========================Set user specific labels:
        private void SetLabels()
        {
            ProfessorTitle.Text = LogIn.user.FirstName + " " + LogIn.user.LastName;
            UserFirstNameLbl.Text = LogIn.user.FirstName;
            UserLastNameLbl.Text = LogIn.user.LastName;
            UserIDNumberLbl.Text = LogIn.user.EnterpriseID.ToString();
            UserAddressLbl.Text = LogIn.user.StreetAddress;
            UserEmailLbl.Text = LogIn.user.Email;
            UserPhoneNumberLbl.Text = LogIn.user.PhoneNumber.ToString();
        }
        //======================================================User View:
        public void UserViewComboBox_Load()
        {
            if (LogIn.user.IsStudent)
            {
                UserViewComboBox.Items.Add("Student");
            }
            if (LogIn.user.IsProfessor)
            {
                UserViewComboBox.Items.Add("Professor");
            }
            if (LogIn.user.IsRegistrar)
            {
                UserViewComboBox.Items.Add("Registar");
            }

        }
        private void UserViewComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProfessorView Professor = new ProfessorView();
            StudentView Student = new StudentView();
            Registrar Registar = new Registrar();
            if (UserViewComboBox.SelectedItem.ToString() == "Student")
            {
                Student.Show();
                Close();
            }
            if (UserViewComboBox.SelectedItem.ToString() == "Professor")
            {
                Professor.Show();
                Close();
            }
            if (UserViewComboBox.SelectedItem.ToString() == "Registar")
            {
                Registar.Show();
                Close();
            }
        }
        //=====================================================Schedule tab:
        private void SemesterComboBox_Load()
        {
            ScheduleSemesterComboBox.Items.Clear();
            foreach (string semester in semesterIndex)
            {
                ScheduleSemesterComboBox.Items.Add(semester.ToString());
            }

        }
        List<Section> loadedSections = new List<Section>();
        Section selectedSection;
        private void ScheduleSemesterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            string[] selectedItem = ScheduleSemesterComboBox.SelectedItem.ToString().Split();
            loadedSections = LogIn.user.GetSections(selectedItem[0], selectedItem[1], true);
            ScheduleSectionsComboBox.Items.Clear();
            foreach (Section section in loadedSections)
            {
                ScheduleSectionsComboBox.Items.Add(section.GetCourseName(LogIn.user) + '-' + section.SectionNumber);
            }

        }

        private void ScheduleSectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] selectedItem = ScheduleSectionsComboBox.SelectedItem.ToString().Split('-');
            selectedSection = loadedSections.Find((Section s) => { return s.SectionNumber.ToString() == selectedItem[1] && s.GetCourseName(LogIn.user) == selectedItem[0]; });
            List<SectionStudent> students = LogIn.user.GetStudents(new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("SectionID", selectedSection.ID) });
            updateGrade = students;
           
    
            foreach (var student in students)
            {
                var row = new DataGridViewRow();
          

                row.CreateCells(StudentGridView,new string[] {
                    student.PersonID.ToString(),
                    student.GetFirstName(LogIn.user),
                    student.GetLastName(LogIn.user),
                    student.Grade,
                });
                StudentGridView.Rows.Add(row);
            }
        }
           
            
    
             
          

//====================================================Add Drop Tab:
        private void AddDropSemesterComboBox_Load()
        {
            AddDropSemesterComboBox.Items.Clear();
            foreach (string semester in semesterIndex)
            {
                AddDropSemesterComboBox.Items.Add(semester);
            }
        }
        private void AddDropCoursesComboBox_Load()
        {
            AddDropCoursesComboBox.Items.Clear();
          /*  foreach (Course course in courseIndex)
            {
                AddDropCoursesComboBox.Items.Add(course);
            }*/
        }

        private void AddDropListBox_Load()
        {
            AddDropListBox.Items.Clear();
            /*foreach (Section section in sectionIndex)
            {
                AddDropListBox.Items.Add(section);
            }*/
        }
        private void AddDropCoursesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddDropListBox_Load();
        }
//===========================================================Buttons:
        private void Logout_Click(object sender, EventArgs e)
        {

            Environment.Exit(1);
        }

        private void UpdateInfoBtn_Click_1(object sender, EventArgs e)
        {
            UserPersonalInformation update = new UserPersonalInformation("Update", LogIn.user.EnterpriseID);
            update.Show();
        }
    }
}
