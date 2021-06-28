using Main_Project.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Main_Project.Interfaces
{
     public interface IStudentrep : IGenrep<Student>
    {
        public Task<IEnumerable<Student>> AllS();
        public Task<Student> Login(string email, string password);

        public Task<Student> GetByEmail(string email);
    }
}
