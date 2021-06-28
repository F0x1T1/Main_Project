using Main_Project.BL.DTO;
using Main_Project.Interfaces;
using Main_Project.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Main_Project.SQLServises
{
    public class CoursesServices : ICoursesServices
    {
        private readonly IUnitOfWork Uof;
        protected IMapper Mapper;


        public CoursesServices(IUnitOfWork uof, IMapper mapper)
        {
            Uof = uof;
            Mapper = mapper;
        }

        public async Task<Courses> AddCourses(PostCoursesDTO obj)
        {
            Courses loc = Mapper.Map<PostCoursesDTO, Courses>(obj);
            var res = await Uof.Courses.Add(loc);
            await Uof.SaveChangesAsync();
            return res;
        }

        public async Task<PostCoursesDTO> GetCoursesById(int? CoursesID)
        {
            var res = Mapper.Map<Courses, PostCoursesDTO>
            (await Uof.Courses.GetById(CoursesID.Value));
            return res;
        }

        public async Task<IEnumerable<PostCoursesDTO>> GetAllC()
        {

            var courses = await Uof.Courses.AllC();
            var res = Mapper.Map<IEnumerable<Courses>, IEnumerable<PostCoursesDTO>>(courses);
            return res;

        }

        public async Task<PostCoursesDTO> UpdateCourses(PostCoursesDTO obj)
        {
            Courses location = Mapper.Map<Courses>(obj);
            var res = Mapper.Map<Courses, PostCoursesDTO>
            (await Uof.Courses.Update(location));
            await Uof.SaveChangesAsync();
            return res;

        }

        public async Task<Courses> DeleteCourses(int CoursesID)
        {
            var res = await Uof.Courses.Delete(CoursesID);
            await Uof.SaveChangesAsync();
            return res;
        }

        public async Task<IEnumerable<CoursesInUserDTO>> GetByUserId(string userId)
        {
            var courses = await Uof.Courses.GetAllCourseByUserId(userId);
            //var res = Mapper.Map<IEnumerable<Courses>, IEnumerable<PostCoursesDTO>>(courses);
            List<CoursesInUserDTO> coursesInUserDTOs = new();
            foreach (var cinu in courses)
            {
                coursesInUserDTOs.Add(new CoursesInUserDTO() { CoursesID = cinu.CoursesID, studId = userId, Price = cinu.Price, Grades = 70, NameCourses = cinu.NameCourses, Description = cinu.Description });
            }
            return coursesInUserDTOs;
        }

        public async Task AddCourseToUser(CoursesInUserDTO coursesInUserDTO)
        {
            StudCourses studCourses = new() { CoursesID = coursesInUserDTO.CoursesID, Id = coursesInUserDTO.studId, Grades = 70 };
            await Uof.Courses.AddCourseToUser(studCourses);
        }
    }
}
