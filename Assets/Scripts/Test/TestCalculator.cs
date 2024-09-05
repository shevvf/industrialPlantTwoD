using System.Numerics;

using IndustrialPlant.Infrastructure.GameServices.CalculatorService;

using UnityEngine;

namespace Test
{
    public class TestCalculator : MonoBehaviour
    {
        CalculatorService calculatorService = new();

        private void Start()
        {
            TestOperations();
        }

        private void TestOperations()
        {
            // ������� � int
            TestOperation(5, 3);

            // ������� � double
            TestOperation(5.5, 3.3);

            // ������� � decimal
            TestOperation(5.5m, 3.3m);

            // ������� � float
            TestOperation(5.5f, 3.3f);

            // ������� � short
            TestOperation((short)5, (short)3);

            // ������� � long
            TestOperation(500000000L, 3000000000L);

            // ������� � uint
            TestOperation(5000000000U, 3000000000U);

            // ������� � BigInteger
            TestOperation(new BigInteger(1234567890123456789), new BigInteger(9876543210987654321));
        }

        private void TestOperation<T>(T a, T b)
        {
            var addResult = calculatorService.Add(a, b);
            var subtractResult = calculatorService.Subtract(a, b);
            var multiplyResult = calculatorService.Multiply(a, b);
            var divideResult = calculatorService.Divide(a, b);

            Debug.Log($"Addition: {addResult} (Type: {addResult.GetType().Name})");
            Debug.Log($"Subtraction: {subtractResult} (Type: {subtractResult.GetType().Name})");
            Debug.Log($"Multiplication: {multiplyResult} (Type: {multiplyResult.GetType().Name})");
            Debug.Log($"Division: {divideResult} (Type: {divideResult.GetType().Name})");
        }
    }
}