namespace IndustrialPlant.Infrastructure.GameServices.CalculatorService
{
    public interface ISubtractable
    {
        T Subtract<T>(T a, T b);
    }
}