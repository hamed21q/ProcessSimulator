using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PS.Domain;
using PS.Domain.Application;

namespace PS.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessSimulationController : ControllerBase
    {
        private readonly CPU cpu;

        public ProcessSimulationController(CPU cpu)
        {
            this.cpu = cpu;
        }

        [HttpPost("Simulate")]
        public ProcessSimulationViewModel Simulate([FromBody] CreateProcessSimulationCommand command)
        {
            return cpu.Process(command);
        }

        [HttpPost("Compare")]
        public AlgorithmComparisonViewModel Compare([FromBody] CreateAlgorithmComparisonCommand command)
        {
            return cpu.Compare(command);
        }
    }
}
