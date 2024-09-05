namespace IndustrialPlant.Infrastructure.GameServices.CalculatorService
{
    public interface IDividable
    {
        T Divide<T>(T a, T b);
    }
}