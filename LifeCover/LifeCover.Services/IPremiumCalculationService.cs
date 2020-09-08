namespace LifeCover.Services
{
    public interface IPremiumCalculationService
    {
        decimal CalculatePremium(long sumInsured, Occupation occupation, int age);
    }
}