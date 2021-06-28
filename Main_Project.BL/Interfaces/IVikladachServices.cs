using System.Collections.Generic;
using System.Threading.Tasks;
using Main_Project.BL.DTO;
using Main_Project.Models;

namespace Main_Project.Interfaces
{
    public interface IVikladachServices
    { 
        Task<Vikladach> AddVikladach(VikladachDTO obj);
        Task<VikladachDTO> UpdateVikladach(VikladachDTO obj);
        Task<Vikladach> DeleteVikladach(int id);
        Task<VikladachDTO> GetVikladachById(int? id);
        Task<IEnumerable<VikladachDTO>> GetAll();
    }
}
