using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReservesEstimation.Web.Models;

namespace ReservesEstimation.Web.Pages
{
    public class calculatorModel : PageModel
    {
        [BindProperty]
        public VolumetricReserveModel VolModel { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            return this.Page();
        }
    }
}