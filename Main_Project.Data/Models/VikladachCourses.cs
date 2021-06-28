using System;

namespace Main_Project.Models
{
    public class VikladachCourses
    {
        public string VikladachID { get; set; }
        public int CoursesID { get; set; }
        public Courses Courses { get; set; }
        public Vikladach Vikladach { get; set; }
    }
}
