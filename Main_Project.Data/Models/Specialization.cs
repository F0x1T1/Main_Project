using System;
using System.Collections.Generic;

namespace Main_Project.Models
{
    public class Napryam
    {
        public string NapryamID { get; set; }
        public string Predmetna_obl { get; set; }
        public List<Vikladach> Vikladach { get; set; } //navigations
    }
}
