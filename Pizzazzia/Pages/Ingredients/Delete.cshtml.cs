using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pizzazzia.Data;
using Pizzazzia.Models;

namespace Pizzazzia.Pages.Ingredients
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly Pizzazzia.Data.PizzazziaContext _context;

        public DeleteModel(Pizzazzia.Data.PizzazziaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Ingredient Ingredient { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredient = await _context.Ingredient.FirstOrDefaultAsync(m => m.Id == id);

            if (ingredient == null)
            {
                return NotFound();
            }
            else
            {
                Ingredient = ingredient;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredient = await _context.Ingredient.FindAsync(id);
            if (ingredient != null)
            {
                Ingredient = ingredient;
                _context.Ingredient.Remove(Ingredient);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
