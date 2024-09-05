namespace IndustrialPlant.Infrastructure.GameServices.CalculatorService
{
    public interface IAddable
    {
        T Add<T>(T a, T b);
    }
}