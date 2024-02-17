using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pizzazzia.Data;
using Pizzazzia.Models;

namespace Pizzazzia.Pages.Pizzas
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly PizzazziaContext _context;

        public CreateModel(PizzazziaContext context)
        {
            _context = context;
        }

        public List<Ingredient> AllIngredients { get; set; } = new List<Ingredient>();

        [BindProperty]
        public Pizza Pizza { get; set; } = new Pizza();

        [BindProperty]
        public List<int> SelectedIngredientIds { get; set; } = new List<int>();

        public async Task<IActionResult> OnGetAsync()
        {
            AllIngredients = await _context.Ingredient.ToListAsync();
            return Page();
        }

        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            
            Pizza.PizzaIngredients = SelectedIngredientIds
                .Select(id => new PizzaIngredient { IngredientId = id })
                .ToList();

            _context.Pizza.Add(Pizza);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
