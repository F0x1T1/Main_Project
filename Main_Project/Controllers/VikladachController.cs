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
    public class VikladachController : ControllerBase
    {

        private readonly IVikladachServices VikladachServices;
        public VikladachController(IVikladachServices Vikladach)
        {
            this.VikladachServices = Vikladach;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VikladachDTO>>> GetT()
        {
            return Ok(await VikladachServices.GetAll()); // Ok - status 200 (We have some data)
        }

        [HttpPost]
        public async Task<ActionResult> CreateT(VikladachDTO Vikladach)
        {
            await VikladachServices.AddVikladach(Vikladach);
            return NoContent(); //NoContent - status 204 (We havn't any data)
        }

        [HttpGet("{VikladachID}")]
        public async Task<ActionResult<VikladachDTO>> GetT(int VikladachID)
        {
            return Ok(await VikladachServices.GetVikladachById(VikladachID));
        }

        [HttpDelete("{VikladachID}")]
        public async Task<ActionResult> DelT(int VikladachID)
        {
            await VikladachServices.DeleteVikladach(VikladachID);
            return NoContent();
        }

    }
}
