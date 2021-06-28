using Main_Project.BL.DTO;
using Main_Project.Data;
using Main_Project.Interfaces;
using Main_Project.Models;
using Main_Project.SQLServises;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Main_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private  ICoursesServices coursesServices;

        public CoursesController( ICoursesServices courses)
        {
            this.coursesServices = courses;
        }

        //[Authorize]
        [HttpGet]
        public async Task<IEnumerable<PostCoursesDTO>> GetC()
        {
            return await coursesServices.GetAllC(); // Ok - status 200 (We have some data)
        }

        [HttpGet("GetByUser/{userId}")]
        public async Task<IEnumerable<CoursesInUserDTO>> GetByUserId(string userId)
        {
            return await coursesServices.GetByUserId(userId);
        }

        [HttpPost]
        public async Task<ActionResult> CreateC(PostCoursesDTO courses)
        {
            await coursesServices.AddCourses(courses);
            return NoContent(); //NoContent - status 204 (We havn't any data)
        }

        [HttpGet("{CoursesID}")]
        public async Task<ActionResult<PostCoursesDTO>> GetC(int CoursesID)
        {
            return Ok(await coursesServices.GetCoursesById(CoursesID));
        }

        [HttpDelete("{CoursesID}")]
        public async Task<ActionResult> DelC(int CoursesID)
        {
            await coursesServices.DeleteCourses(CoursesID);
            return NoContent();
        }

        [HttpPost("AddCourseToUser")]
        public async Task AddCourseToUser(CoursesInUserDTO coursesInUserDTO)
        {
            await coursesServices.AddCourseToUser(coursesInUserDTO);
        }


    }
}
