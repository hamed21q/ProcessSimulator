using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PS.Domain;
using PS.Domain.Application;

namespace PS.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddProcessController : ControllerBase
    {
        private readonly CPU cpu;

        public AddProcessController(CPU cpu)
        {
            this.cpu = cpu;
        }

        [HttpPost]
        public ProcessSimulationViewModel Simulate([FromBody] CreateProcessSimulationCommand command)
        {
            return cpu.Process(command);
        }
    }
}
