using Microsoft.AspNetCore.Mvc;

namespace GunsOfTheOldWest.Models
{
    public class GunsFromTheOldWestModel
    {
        public GunsFromTheOldWestModel(int bullets)
        {
            this.bullets = bullets;
        }
        public int bullets { get; set; }
    }
}
