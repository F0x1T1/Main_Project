using Main_Project.BL.DTO;
using Main_Project.Interfaces;
using Main_Project.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
//using Main_Project.BL.JWT;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Main_Project.BL.SQLServises
{
   public class StudentServices : IStudentServices
    {
        private readonly IUnitOfWork Uof;
        protected IMapper Mapper;


        public StudentServices(IUnitOfWork uof, IMapper mapper)
        {
            Uof = uof;
            Mapper = mapper;
        }

        public async Task<Student> AddStudent(StudentDTO obj)
        {
            Student loc = Mapper.Map<StudentDTO, Student>(obj);
            var res = await Uof.Students.Add(loc);
            await Uof.SaveChangesAsync();
            return res;
        }

        public async Task<StudentDTO> GetStudentById(int? StudentID)
        {
            var res = Mapper.Map<Student, StudentDTO>
            (await Uof.Students.GetById(StudentID.Value));
            return res;
        }

        public async Task<IEnumerable<StudentDTO>> GetAll()
        {

            var students = await Uof.Students.AllS();
            var res = Mapper.Map<IEnumerable<Student>, IEnumerable<StudentDTO>>(students);
            return res;
        }

        public async Task<StudentDTO> UpdateStudent(StudentDTO obj)
        {
            Student location = Mapper.Map<Student>(obj);
            var res = Mapper.Map<Student, StudentDTO>
            (await Uof.Students.Update(location));
            await Uof.SaveChangesAsync();
            return res;
        }

        public async Task<Student> DeleteStudent(int StudentID)
        {
            var res = await Uof.Students.Delete(StudentID);
            await Uof.SaveChangesAsync();
            return res;
        }

        //public async Task<string> Login(UserLoginDTO userLogin)
        //{
        //    var user = await Uof.Students.Login(userLogin.Email, userLogin.Password);
        //    if (user != null)
        //    {
        //        var mappedUser = Mapper.Map<Student, StudentDTO>(user);
        //        return TokenManager.CteateTokens(mappedUser);
        //    }
        //    return null;
        //}

        //public async Task<StudentDTO> GetStudentByAccessToken(string token)
        //{
        //    try
        //    {
        //        var tokenHandler = new JwtSecurityTokenHandler();
        //        var key = Encoding.ASCII.GetBytes(JWTconfig.KEY);

        //        var tokenVakidationParameters = new TokenValidationParameters
        //        {
        //            ValidateIssuerSigningKey = true,
        //            IssuerSigningKey = new SymmetricSecurityKey(key),
        //            ValidateIssuer = false,
        //            ValidateAudience = false
        //        };

        //        var principle = tokenHandler.ValidateToken(token, tokenVakidationParameters, out SecurityToken securityToken);

        //        if (securityToken is JwtSecurityToken jwtSecurityToken && jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
        //        {
        //            var email = principle.FindFirst(ClaimTypes.Email)?.Value;
        //            var user = await Uof.Students.GetByEmail(email);
        //            var mappedStudent = Mapper.Map<Student, StudentDTO>(user);
        //            return mappedStudent;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return new StudentDTO();
        //    }

        //    return new StudentDTO();
        //}

        /*public async Task<bool> Register(RegisterDTO register)
        {

            Student student = new Student()
            { 
                Fullname = register.FullName,
                City = register.City,
                Nomer = register.PhoneNumber,
                Email = register.Gmail,
                PasswordHash = register.Password,
                PhoneNumberConfirmed = false,
                EmailConfirmed = true,
                TwoFactorEnabled = true,
                LockoutEnabled = true,
                LockoutEnd = DateTime.Now,
                AccessFailedCount = 0,
                UserName = register.FullName,
                FormaNavchID = "1"
        }; 

            var result = await Uof.Students.Add(student);
            var checkIfExists= await Uof.Students.GetByEmail(register.Gmail);
            return checkIfExists != null ? true : false;
        }*/
    }
}
