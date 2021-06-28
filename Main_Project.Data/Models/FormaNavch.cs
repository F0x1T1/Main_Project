using System;
using System.Collections.Generic;

namespace Main_Project.Models
{
  public class FormaNavch
    {
        public string StudID { get; set; }
        public string Form { get; set; }
        public List<Vikladach> Vikladach { get; set; }
        public List<Student> student { get; set; }
    }
}
