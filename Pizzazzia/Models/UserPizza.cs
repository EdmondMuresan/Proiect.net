namespace Pizzazzia.Models
{
    public class UserPizza
    {
        public int Id { get; set; } 
        public int UserId { get; set; }
        public User User { get; set; }

        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }

        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
    }
}
