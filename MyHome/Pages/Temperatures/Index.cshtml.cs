using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyHome.Models;
using Microsoft.AspNetCore.Authorization;

namespace MyHome.Pages.Temperatures
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly MyHome.Models.HomeContext _context;

        public IndexModel(MyHome.Models.HomeContext context)
        {
            _context = context;
        }

        public IList<Temperature> Temperature { get;set; }

        public async Task OnGetAsync()
        {
            Temperature = await _context.Temperature.ToListAsync();
        }
    }
}
