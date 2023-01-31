using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PS.Domain;
using PS.Infrustructure;

namespace PS.Presentation.Pages.ProcessManagement
{
    public class ListModel : PageModel
    {
        public List<Process> processes { get; set; }
        private readonly ProcessService service;
        public List<SelectListItem> alogrithems { get; set; }


        public ListModel(ProcessService service)
        {
            this.service = service;
        }

        public void OnGet()
        {
            processes = service.GetAll();
        }
        public IActionResult OnPostRemove(long id) 
        {
            var p = service.getBy(id);
            service.Remove(p);
            return RedirectToPage("/ProcessManagement/List");
        }
        public IActionResult OnPostSimulate(string algo)
        {
            return RedirectToPage($"/ProcessManageMent/Simulate?algo={algo}");
        }
    }
}
