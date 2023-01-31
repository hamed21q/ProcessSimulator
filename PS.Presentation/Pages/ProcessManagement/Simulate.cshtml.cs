using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PS.Domain;
using PS.Domain.Application;
using PS.Infrustructure;

namespace PS.Presentation.Pages.ProcessManagement
{
    public class SimulateModel : PageModel
    {
        public ProcessSimulationViewModel model;
        public ProcessService service;

        public SimulateModel(ProcessService service)
        {
            this.service = service;
        }

        public void OnGet(string algo)
        {
            model = service.Simulate(algo);
        }
    }
}
