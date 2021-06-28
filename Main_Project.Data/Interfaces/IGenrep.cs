using System.Collections.Generic;
using System.Threading.Tasks;

namespace Main_Project.Interfaces
{
    public interface IGenrep<T> where T : class
    {
        Task<T> Add(T obj);
        Task<IEnumerable<T>> Get();
        Task<T> GetById(int id);
        Task<T> Update(T obj);
        Task<T> Delete(int id);
    }

}
