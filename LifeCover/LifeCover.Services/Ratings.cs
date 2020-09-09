using System.Collections.Generic;

namespace LifeCover.Services
{
    public static class Ratings //These would be stored in DB 
    {
        public static Dictionary<Rating, decimal> RatingFactors = new Dictionary<Rating, decimal>
        {
            {Rating.Professional, 1.0m },
            {Rating.WhiteCollar, 1.25m },
            {Rating.LightManual, 1.5m },
            {Rating.HeavyManual, 1.75m }
        };

        public static Dictionary<Occupation, Rating> OccupationRatings = new Dictionary<Occupation, Rating>
        {
            {Occupation.Cleaner, Rating.LightManual},
            {Occupation.Doctor, Rating.Professional},
            {Occupation.Author, Rating.WhiteCollar},
            {Occupation.Farmer, Rating.HeavyManual},
            {Occupation.Mechanic, Rating.HeavyManual},
            {Occupation.Florist, Rating.LightManual}
        };
    }
}
