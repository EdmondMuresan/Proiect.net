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
    public class EditModel : PageModel
    {
        private readonly PizzazziaContext _context;

        public EditModel(PizzazziaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pizza Pizza { get; set; } = default!;
        public List<Ingredient> AllIngredients { get; set; } = new List<Ingredient>();

        [BindProperty]
        public List<int> SelectedIngredientIds { get; set; } = new List<int>();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pizza = await _context.Pizza
                .Include(p => p.PizzaIngredients)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Pizza == null)
            {
                return NotFound();
            }

            AllIngredients = await _context.Ingredient.ToListAsync();

            
            SelectedIngredientIds = Pizza.PizzaIngredients.Select(pi => pi.IngredientId).ToList();

            return Page();
        }

       
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

           
            var existingPizza = await _context.Pizza
                .Include(p => p.PizzaIngredients)
                .FirstOrDefaultAsync(m => m.Id == Pizza.Id);

            if (existingPizza == null)
            {
                return NotFound();
            }

            
            existingPizza.Name = Pizza.Name;
            existingPizza.Price = Pizza.Price;

            existingPizza.PizzaIngredients = SelectedIngredientIds
                .Select(id => new PizzaIngredient { IngredientId = id })
                .ToList();

            _context.Attach(existingPizza).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PizzaExists(Pizza.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PizzaExists(int id)
        {
            return _context.Pizza.Any(e => e.Id == id);
        }
    }
}
