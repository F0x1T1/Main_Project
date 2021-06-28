using Main_Project.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Main_Project.Interfaces
{
    public interface ICoursesrep : IGenrep<Courses>
    {
        Task<Courses> GetCoursesWithStudent(int CoursID);
        public Task<IEnumerable<Courses>> AllC();

        public Task<IEnumerable<Courses>> GetAllCourseByUserId(string userId);


        public Task AddCourseToUser(StudCourses studCourses);
    }
}
