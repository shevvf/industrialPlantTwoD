using System;
using System.Numerics;

namespace IndustrialPlant.UI.Items.Currency
{
    [Serializable]
    public class CurrencyStats
    {
        public BigInteger coins;
        public BigInteger cubes;
        public BigInteger cubesPerSecond;
        public BigInteger specialCoins;
    }
}