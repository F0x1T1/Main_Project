using Main_Project.Models;
using Main_Project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Main_Project.Data
{
    public class StudCoursesReposytory : Basic<StudCourses>, IStudCourses
    {
        public StudCoursesReposytory(AplContext context) : base(context)
        {

        }
    }
}
