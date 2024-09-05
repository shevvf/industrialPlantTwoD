using System;
using System.Numerics;

namespace IndustrialPlant.Infrastructure.GameServices.CalculatorService
{
    public class CalculatorService : ICalculator
    {
        public T Add<T>(T a, T b) => PerformOperation(a, b, (x, y) => x + y);
        public T Subtract<T>(T a, T b) => PerformOperation(a, b, (x, y) => x - y);
        public T Multiply<T>(T a, T b) => PerformOperation(a, b, (x, y) => x * y);
        public T Divide<T>(T a, T b) => PerformOperation(a, b, (x, y) => x / y);

        private T PerformOperation<T>(T a, T b, Func<double, double, double> operation)
        {
            double result = operation(
                a is BigInteger bigIntA ? (double)bigIntA : Convert.ToDouble(a),
                b is BigInteger bigIntB ? (double)bigIntB : Convert.ToDouble(b)
            );

            return (T)(typeof(T) == typeof(BigInteger)
                ? new BigInteger(result)
                : Convert.ChangeType(result, typeof(T)));
        }
    }
}
