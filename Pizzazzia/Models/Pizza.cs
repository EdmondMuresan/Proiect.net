using System.Collections.Generic;

namespace Pizzazzia.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public ICollection<PizzaIngredient> PizzaIngredients { get; set; } = new List<PizzaIngredient>();

        public ICollection<UserPizza> UserPizzas { get; set; } = new List<UserPizza>();
    }
}