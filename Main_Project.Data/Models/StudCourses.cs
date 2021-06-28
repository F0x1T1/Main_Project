using System;

namespace Main_Project.Models
{
    public class StudCourses
    {
        public string Id { get; set; }
        public int CoursesID { get; set; }
        public int Grades { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public Courses Courses { get; set; }
        public Student Student { get; set; }
    }
}
