﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace RegistrationSystem
{
    class Course
    {
        public int ID { get; set; }
        public string CourseNumber { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public byte Hours { get; set; }
        public string Department { get; set; }
        public string Prerequisite { get; set; }
        public void PushChanges(User authority)
        {

        }
    }
}
