using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyHome.Models;

namespace MyHome.Pages.Temperatures
{
    public class DetailsModel : PageModel
    {
        private readonly MyHome.Models.HomeContext _context;

        public DetailsModel(MyHome.Models.HomeContext context)
        {
            _context = context;
        }

        public Temperature Temperature { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Temperature = await _context.Temperature.FirstOrDefaultAsync(m => m.ID == id);

            if (Temperature == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
