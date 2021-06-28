using System;
using System.Collections.Generic;

namespace Main_Project.Models
{
    public class Vikladach
    {
        public string VikladachID { get; set; }
        public string Fullname { get; set; }
        public string City { get; set; }
        public string NapryamID { get; set; }
        public string Nomer { get; set; }
        public Napryam Napryam { get; set; }
        public FormaNavch FormaNavch { get; set; } 
        public List<Courses> Courses { get; set; } = new List<Courses>();
    }
}
