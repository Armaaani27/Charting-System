using Microsoft.AspNetCore.Mvc;
using Library.ChartingSystem.Models;
using API.ChartingSystem.Enterprise;

namespace API.ChartingSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhysicianController : ControllerBase
    {
        private readonly ILogger<PhysicianController> _logger;

        public PhysicianController(ILogger<PhysicianController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Physician>Get()
        {
            return new PhysicianEC().GetPhysicians();
        }

        [HttpGet("{id}")]
        public Physician? GetById(int id)
        {
            return new PhysicianEC().GetById(id);
        }

        [HttpDelete("{id}")]
        public Physician? Delete(int id)
        {
            return new PhysicianEC().Delete(id);
        }

    }
}