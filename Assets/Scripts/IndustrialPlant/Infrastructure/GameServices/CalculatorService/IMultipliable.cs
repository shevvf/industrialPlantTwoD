namespace IndustrialPlant.Infrastructure.GameServices.CalculatorService
{
    public interface IMultipliable
    {
        T Multiply<T>(T a, T b);
    }
}