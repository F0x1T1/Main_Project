using System.Collections.Generic;
using System.Threading.Tasks;
using Main_Project.BL.DTO;
using Main_Project.Models;

namespace Main_Project.Interfaces
{
    public interface IStudentServices
    {
        Task<Student> AddStudent(StudentDTO obj);
        Task<StudentDTO> UpdateStudent(StudentDTO obj);
        Task<Student> DeleteStudent(int id);
        Task<StudentDTO> GetStudentById(int? id);
        Task<IEnumerable<StudentDTO>> GetAll();
        //public Task<string> Login(UserLoginDTO user);

        //public Task<StudentDTO> GetStudentByAccessToken(string token);

        /*public Task<bool> Register(RegisterDTO register);
        */
    }
}
