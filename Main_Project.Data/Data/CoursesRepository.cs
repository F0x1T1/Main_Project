using Main_Project.Models;
using Main_Project.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Main_Project.Data
{
    public class CoursesRepository : Basic<Courses>, ICoursesrep
    {
        private readonly AplContext _context;
        public CoursesRepository(AplContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Courses> GetCoursesWithStudent(int CoursID)
        {
            var cours = await this.FindAll().Include(c => c.Students).SingleOrDefaultAsync(c => c.CoursesID == CoursID);
            return cours;
        }

        public async Task<IEnumerable<Courses>> AllC()
        {
            var courses = await _context.Courses.ToListAsync();
            return courses;
        }

        public async Task<IEnumerable<Courses>> GetAllCourseByUserId(string userId)
        {
            var studentCourses = _context.StudCourses.Where(stc => stc.Id == userId).ToList();
            var courses = await _context.Courses.ToListAsync();
            List<Courses> result = new List<Courses>();

            foreach (var course in courses)
            {
                foreach (var studCourse in studentCourses)
                {
                    if(course.CoursesID == studCourse.CoursesID)
                    {
                        result.Add(course);
                    }    
                }
            }
            return result;
        }

        public async Task AddCourseToUser(StudCourses studCourses)
        {
            await _context.StudCourses.AddAsync(studCourses);
            await _context.SaveChangesAsync();
        }
    }
}
