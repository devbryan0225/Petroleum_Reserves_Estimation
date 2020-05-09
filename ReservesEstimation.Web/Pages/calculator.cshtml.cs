using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReservesEstimation.FormulaLib;
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

        public void OnPost()
        {

            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            //return this.Page();
        }
    }
}