using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pizzazzia.Data;
using Pizzazzia.Models;

namespace Pizzazzia.Pages.Ingredients
{
    public class IndexModel : PageModel
    {
        private readonly Pizzazzia.Data.PizzazziaContext _context;

        public IndexModel(Pizzazzia.Data.PizzazziaContext context)
        {
            _context = context;
        }

        public IList<Ingredient> Ingredient { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Ingredient = await _context.Ingredient.ToListAsync();
        }
    }
}
