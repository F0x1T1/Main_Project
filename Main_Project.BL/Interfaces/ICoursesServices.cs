using System.Collections.Generic;
using System.Threading.Tasks;
using Main_Project.BL.DTO;
using Main_Project.Models;

namespace Main_Project.Interfaces
{
   public interface ICoursesServices
   {
        Task<PostCoursesDTO> UpdateCourses(PostCoursesDTO obj);// update courses
        Task<PostCoursesDTO> GetCoursesById(int? id);// return courses by courses id
        Task<Courses> DeleteCourses(int id);// delete courses by courses id
        Task<Courses> AddCourses(PostCoursesDTO obj);// add new courses
        Task<IEnumerable<PostCoursesDTO>> GetAllC();// return all courses

        Task<IEnumerable<CoursesInUserDTO>> GetByUserId(string userId);

        Task AddCourseToUser(CoursesInUserDTO coursesInUserDTO);
    }
}
