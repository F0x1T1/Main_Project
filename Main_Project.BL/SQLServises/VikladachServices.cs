using Main_Project.BL.DTO;
using Main_Project.Interfaces;
using Main_Project.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Main_Project.BL.SQLServises
{
   public class VikladachServices : IVikladachServices
    {
        private readonly IUnitOfWork Uof;
        protected IMapper Mapper;


        public VikladachServices(IUnitOfWork uof, IMapper mapper)
        {
            Uof = uof;
            Mapper = mapper;
        }

        public async Task<Vikladach> AddVikladach(VikladachDTO obj)
        {
            Vikladach loc = Mapper.Map<VikladachDTO, Vikladach>(obj);
            var res = await Uof.Vikladach.Add(loc);
            await Uof.SaveChangesAsync();
            return res;
        }

        public async Task<VikladachDTO> GetVikladachById(int? VikladachID)
        {
            var res = Mapper.Map<Vikladach, VikladachDTO>
            (await Uof.Vikladach.GetById(VikladachID.Value));
            return res;
        }

        public async Task<IEnumerable<VikladachDTO>> GetAll()
        {
            var res = Mapper.Map<IEnumerable<Vikladach>, IEnumerable<VikladachDTO>>
            (await Uof.Vikladach.Get());
            return res;
        }

        public async Task<VikladachDTO> UpdateVikladach(VikladachDTO obj)
        {
            Vikladach location = Mapper.Map<Vikladach>(obj);
            var res = Mapper.Map<Vikladach, VikladachDTO>
            (await Uof.Vikladach.Update(location));
            await Uof.SaveChangesAsync();
            return res;
        }

        public async Task<Vikladach> DeleteVikladach(int VikladachID)
        {
            var res = await Uof.Vikladach.Delete(VikladachID);
            await Uof.SaveChangesAsync();
            return res;
        }

    }
}
