using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Main_Project.Models
{
    public class Courses
    {
        public int CoursesID { get; set; }
        public string NameCourses { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Vikladach> Teachers { get; set; } = new List<Vikladach>();
        public List<StudCourses> StudCourses { get; set; } = new List<StudCourses>();
    }
}