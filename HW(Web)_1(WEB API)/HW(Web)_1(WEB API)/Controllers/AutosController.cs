using DataProject.Data;
using DataProject.Data.Entitys;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.ApiModels.Autos;
using BusinessLogic.Services;
using BusinessLogic.Interfaces;
using BusinessLogic.Helpers;
using BusinessLogic.Dtos;

namespace HW_Web__1_WEB_API_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutosController : ControllerBase
    {
        public AutosController(IAutosServices ias)
        {
            Ias = ias;         
        }

        private readonly IAutosServices Ias;
        

        
        [HttpGet("all")]
        
        public IActionResult Get()
        {
            return Ok( Ias.Get());
        }
        [HttpGet("all-async")]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await Ias.GetAsync());
        }
        [HttpGet("{id}")]
        public IActionResult GetByIdFromRoute([FromRoute] int id)
        {
            return Ok(Ias.Get(id));
        }
        [HttpGet("{id}-async")]
        public async Task<IActionResult> GetByIdFromRouteAsync([FromRoute] int id)
        {
            
            return Ok(await Ias.GetAsync(id));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Add(CreateAutoModel auto)
        {
            await Ias.Create(auto);
            return Ok();
        }
        [HttpPut("Edit")]
        public async Task<IActionResult> Update(EditAutoModel auto)
        {
            await Ias.Edit(auto);
            return Ok();
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await Ias.Delete(id);           
            return Ok();
        }
    }
}
