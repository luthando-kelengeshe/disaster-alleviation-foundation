using DAF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DAF.Pages
{
    public class causesModel : PageModel
    {
        public List<Allocations> allocationsMade = new();
        
        public void OnGet()
        {
            Allocations allocations = new();
            allocationsMade = allocations.GetAllocations();
        }
    }
}
