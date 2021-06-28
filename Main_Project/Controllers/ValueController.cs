using Main_Project.Data;
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
    public class ValueController : ControllerBase
    {
        private readonly Value_Repository rep;

        public ValueController(Value_Repository repository)
        {
            this.rep = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("Teachers")]
        public async Task<ActionResult<IEnumerable<Vikladach>>> GetT()
        {
            return await rep.GetAll();
        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await rep.DeleteById(id);
        }
    }
}
