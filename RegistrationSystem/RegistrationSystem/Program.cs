﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistrationSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// Was downgraded for lab computers
        /// test
        [STAThread]
        static void Main()
        {

            // DatabaseConnection db = new DatabaseConnection(1,"000"); 
            //  var collection = db.GetOccurrences(Tables.Person, new System.Data.SqlClient.SqlParameter[] { }, new string[] { "*" });
            // System.Diagnostics.Debug.WriteLine("IsStudent = " + db.IsStudent);
            // System.Diagnostics.Debug.WriteLine("IsProfessor = " + db.IsProfessor);
            // System.Diagnostics.Debug.WriteLine("IsRegistrar = " + db.IsRegistrar);


            // db.Insert(Tables.Person,new System.Data.SqlClient.SqlParameter[] 
            /*  {
                 new System.Data.SqlClient.SqlParameter("FirstName","John"),
                  new System.Data.SqlClient.SqlParameter("LastName","Smith"),
                  new System.Data.SqlClient.SqlParameter("IsProfessor",true),
                  new System.Data.SqlClient.SqlParameter("IsStudent",true),
                  new System.Data.SqlClient.SqlParameter("IsRegistrar",false),
                  new System.Data.SqlClient.SqlParameter("Social",1234),
                  new System.Data.SqlClient.SqlParameter("StreetAddress","Memory Ln."),
                  new System.Data.SqlClient.SqlParameter("City","Small Texas"),
                  new System.Data.SqlClient.SqlParameter("State","Saddness"),
                  new System.Data.SqlClient.SqlParameter("ZipCode",1234),
                  new System.Data.SqlClient.SqlParameter("PhoneNumber","8000060000"),
                  new System.Data.SqlClient.SqlParameter("CanRegistrar",true),
                 new System.Data.SqlClient.SqlParameter("Password",db.Hash("Test")),
                  new System.Data.SqlClient.SqlParameter("Email","josh@cs.actx.edu"),
              });*/
            /*  User testAdmin = new User();
              System.Diagnostics.Debug.WriteLine("Auth Success = " + testAdmin.Authenticate(4, "test123"));
              System.Diagnostics.Debug.WriteLine("IsRegistrar = " + testAdmin.IsRegistrar);
              System.Diagnostics.Debug.WriteLine("First Name = " + testAdmin.FirstName);
              testAdmin.RemovePerson(18);
              */
            DatabaseConnection connection = new DatabaseConnection();
            foreach(var course in connection.BuildClassArray<Course>(new System.Data.SqlClient.SqlParameter[0], Tables.Course))
            {
                foreach(var property in typeof(Course).GetProperties())
                {
                    System.Diagnostics.Debug.WriteLine(property.Name + ": " + property.GetValue(course));
                }
            }
            System.Diagnostics.Debug.WriteLine("=========================");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LogIn());
        }
    }
}
