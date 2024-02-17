using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pizzazzia.Data;
using Pizzazzia.Models;

namespace Pizzazzia.Pages.Pizzas
{
    public class IndexModel : PageModel
    {
        private readonly Pizzazzia.Data.PizzazziaContext _context;

        public IndexModel(Pizzazzia.Data.PizzazziaContext context)
        {
            _context = context;
        }

        public IList<Pizza> Pizza { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Pizza = await _context.Pizza.ToListAsync();
        }
    }
}
