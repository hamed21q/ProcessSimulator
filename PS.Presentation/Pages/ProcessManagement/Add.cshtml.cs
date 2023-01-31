using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PS.Domain;
using PS.Domain.Application;
using PS.Infrustructure;

namespace PS.Presentation.Pages.ProcessManagement
{
    public class AddModel : PageModel
    {
        private readonly ProcessService service;
        public AddModel(ProcessService service)
        {
            this.service = service;
        }

        public void OnGet()
        {

        }
        public IActionResult OnPost(ProcessViewModel model)
        {
            var pr = new Process(model.BurstTime, model.ArrivalTime);
            service.Add(pr);
            return RedirectToPage("/ProcessManagement/List");
        }

    }
}
