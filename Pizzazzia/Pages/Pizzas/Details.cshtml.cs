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
    public class DetailsModel : PageModel
    {
        private readonly PizzazziaContext _context;

        public DetailsModel(PizzazziaContext context)
        {
            _context = context;
        }

        public Pizza Pizza { get; set; } = default!;
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pizza = await _context.Pizza
                .Include(p => p.PizzaIngredients)
                .ThenInclude(pi => pi.Ingredient)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Pizza == null)
            {
                return NotFound();
            }

            Ingredients = Pizza.PizzaIngredients.Select(pi => pi.Ingredient).ToList();

            return Page();
        }
    }
}
