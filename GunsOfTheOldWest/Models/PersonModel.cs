using Microsoft.AspNetCore.Mvc;

namespace GunsOfTheOldWest.Models
{
    public class PersonModel
    {
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string EmailAdres { get; set; }
        public int TelefoonNummer { get; set; }
        public DateTime date { get; set; }
    }
}
