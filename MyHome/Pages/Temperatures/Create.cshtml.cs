using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyHome.Models;

namespace MyHome.Pages.Temperatures
{
    // Reference: https://docs.microsoft.com/zh-cn/aspnet/core/data/ef-rp/intro?view=aspnetcore-2.1&tabs=netcore-cli

    public class CreateModel : PageModel
    {
        private readonly MyHome.Models.HomeContext _context;

        public CreateModel(MyHome.Models.HomeContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Temperature Temperature { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            // Validate
            if (!Temperature.Memo.Contains("Keeper"))
            {
                return Page();
            }
            else
            {
                Temperature.Memo = Temperature.Memo.Replace("Keeper", "");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Temperature.Add(Temperature);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}