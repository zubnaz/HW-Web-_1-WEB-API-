using DataProject.Data;
using DataProject.Data.Entitys;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HW_Web__1_WEB_API_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutosController : ControllerBase
    {
        public AutosController(AutoDbContext adc)
        {
            Adc = adc;
        }

        private readonly AutoDbContext Adc;

        [HttpGet("all")]

        public IActionResult Get()
        {
            return Ok(Adc.Autos.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var auto = Adc.Autos.Find(id);
            if (auto == null) return NotFound();
            return Ok(auto);
        }
        [HttpPost]
        public IActionResult Add(Auto auto)
        {
            if(!ModelState.IsValid) return BadRequest();
            Adc.Autos.Add(auto);
            Adc.SaveChanges();
            return Ok(auto);
        }
        [HttpPut]
        public IActionResult Update(Auto auto)
        {
            if (!ModelState.IsValid) return BadRequest();
            Adc.Autos.Update(auto);
            Adc.SaveChanges();
            return Ok(auto);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var auto = Adc.Autos.Find(id);
            if (auto == null) return BadRequest();
            Adc.Autos.Remove(auto);
            Adc.SaveChanges();
            return Ok(Adc.Autos.ToList());
        }
    }
}
