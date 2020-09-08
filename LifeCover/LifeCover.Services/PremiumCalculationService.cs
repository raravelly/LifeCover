namespace LifeCover.Services
{
    public class PremiumCalculationService : IPremiumCalculationService
    {
        public decimal CalculatePremium(long sumInsured, Occupation occupation, int age)
        {
            var rating = Ratings.OccupationRatings[occupation];

            var ratingFactor = Ratings.RatingFactors[rating];

            return (sumInsured * ratingFactor * age) / 1000 * 12;
        }
    }
}
