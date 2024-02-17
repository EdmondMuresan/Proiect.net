using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pizzazzia.Models;

namespace Pizzazzia.Data
{
    public class PizzazziaContext : IdentityDbContext<IdentityUser>
    {
        public PizzazziaContext(DbContextOptions<PizzazziaContext> options)
            : base(options)
        {
        }

        
        public DbSet<Pizza> Pizza { get; set; } = default!;
        public DbSet<Ingredient> Ingredient { get; set; } = default!;
        public DbSet<PizzaIngredient> PizzaIngredient { get; set; } = default!;
        public DbSet<UserPizza> UserPizzas { get; set; } = default!;
        public DbSet<User> User { get; set; } = default!;
    }
}
