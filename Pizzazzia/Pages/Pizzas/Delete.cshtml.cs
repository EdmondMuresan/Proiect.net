﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pizzazzia.Data;
using Pizzazzia.Models;

namespace Pizzazzia.Pages.Pizzas
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
        public Pizza Pizza { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pizza = await _context.Pizza.FirstOrDefaultAsync(m => m.Id == id);

            if (pizza == null)
            {
                return NotFound();
            }
            else
            {
                Pizza = pizza;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pizza = await _context.Pizza.FindAsync(id);
            if (pizza != null)
            {
                Pizza = pizza;
                _context.Pizza.Remove(Pizza);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
