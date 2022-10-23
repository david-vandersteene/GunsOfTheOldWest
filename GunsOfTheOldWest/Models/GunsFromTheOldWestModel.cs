using Microsoft.AspNetCore.Mvc;

namespace GunsOfTheOldWest.Models
{
    public class GunsFromTheOldWestModel
    {
        public GunsFromTheOldWestModel()
        {
            this.Bullets = 12;
        }
        public int Bullets { get; set;}

        public void removeBullet()
        {
            Bullets--;
        }
    }
}
