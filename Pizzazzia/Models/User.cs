using System.ComponentModel.DataAnnotations;

namespace Pizzazzia.Models
{
    public class User
    {
        public int Id { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage ="Prenumele trebuie sa inceapa cu majuscula (ex. Alex sau Alex Vlad sau Alex-Vlad")]
        [StringLength(30, MinimumLength = 3)]
        public string? Name { get; set; }
        [StringLength(70)]
        public string? Adress { get; set; }
        public string Email { get; set; }
        [RegularExpression(@"^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Telefonul trebuie sa fie de forma '0722-123-123' sau '0722.123.123' sau '0722 123 123'")]
        public string? Phone { get; set; }

        public ICollection<UserPizza> UserPizzas { get; set; } = new List<UserPizza>();
    }
}
