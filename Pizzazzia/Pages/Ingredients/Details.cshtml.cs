﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly Pizzazzia.Data.PizzazziaContext _context;

        public DetailsModel(Pizzazzia.Data.PizzazziaContext context)
        {
            _context = context;
        }

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
    }
}
