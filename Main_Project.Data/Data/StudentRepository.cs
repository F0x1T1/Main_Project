using Main_Project.Models;
using Main_Project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Main_Project.Data
{
    public class StudentRepository : Basic<Student>, IStudentrep
    {
        private readonly AplContext _context;
        public StudentRepository(AplContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> AllS()
        {
            var studts = await _context.Student.ToListAsync();
            return studts;
        }

        public async Task<Student> GetByEmail(string email)
        {
            var users = await _context.Student.ToListAsync();
            return users.Where(u => u.Email == email).FirstOrDefault();
        }

        public async Task<Student> Login(string email, string password)
        {
            var users = await _context.Student.ToListAsync();
            var user = users.Where(u => u.Email == email).FirstOrDefault();
            return null;

        }
    }
}
