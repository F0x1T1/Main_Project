using Main_Project.BL.DTO;
using Main_Project.Data;
using Main_Project.Interfaces;
using Main_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Main_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {


        private IStudentServices StudentServices;
        public StudentController( IStudentServices studentServices)
        {
            this.StudentServices = studentServices;
        }

        [HttpGet]
        public async Task<IEnumerable<StudentDTO>> GetS()
        {
            return await StudentServices.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult> CreateS(StudentDTO student)
        {
            await StudentServices.AddStudent(student);
            return NoContent(); //NoContent - status 204 (We havn't any data)
        }

        [HttpGet("{StudentID}")]
        public async Task<ActionResult<Student>> GetS(int StudentID)
        {
            return Ok(await StudentServices.GetStudentById(StudentID));
        }

        [HttpDelete("{StudentID}")]
        public async Task<ActionResult> DelS(int StudentID)
        {
            await StudentServices.DeleteStudent(StudentID);
            return NoContent();
        }

        //[HttpPost("Login")]
        //public async Task<string> Login([FromBody]UserLoginDTO userLogin)
        //{
        //    return await studentServices.Login(userLogin);
        //}

        //[HttpPost("GetByToken")]
        //public async Task<StudentDTO> GetUserByAccessToken([FromBody] string token)
        //{
        //    return await studentServices.GetStudentByAccessToken(token);
        //}

       /* [HttpPost("Register")]
        public async Task<bool> RegisterUser([FromBody] RegisterDTO studRegister)
        {
            return await studentServices.Register(studRegister);
        }*/
    }
}
