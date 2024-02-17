using SQLite;
using System;

namespace Angajati.Models
{
    public class Angajat
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Prenume { get; set; }
        public string Nume { get; set; }

        [MaxLength(30), Unique]
        public string Email { get; set; }
        public DateTime Data_nasterii { get; set; }
    }
}
