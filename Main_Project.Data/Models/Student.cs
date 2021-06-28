using System;
using System.Collections.Generic;

namespace Main_Project.Models
{
   public class Student
    {
        public string Fullname { get; set; }
        public string City { get; set; }
        public DateTime Birthdate { get; set; }
        public string Teachingtype { get; set; }
        public string Email { get; set; }
        public string StudID { get; set; }
        public string FormaNavchID { get; set; }
        public FormaNavch FormaNavch { get; set; }
        public List<Courses> Courses { get; set; } = new List<Courses>();
        public List<StudCourses> StudCourses { get; set; } = new List<StudCourses>();
    }
}