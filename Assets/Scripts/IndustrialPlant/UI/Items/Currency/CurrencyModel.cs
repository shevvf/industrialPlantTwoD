using IndustrialPlant.Data.UserData;
using R3;
using System;
using System.Numerics;

namespace IndustrialPlant.UI.Items.Currency
{
    public class CurrencyModel
    {
        private readonly UserData userData;

        private ReactiveProperty<BigInteger> coins;
        private ReactiveProperty<BigInteger> cubes;
        private ReactiveProperty<BigInteger> cubesPerSecond;
        private ReactiveProperty<BigInteger> specialCoins;

        public ReactiveProperty<BigInteger> Coins
        {
            get => coins ??= new(userData.GameUserData.currencyStats.coins);
        }

        public ReactiveProperty<BigInteger> Cubes
        {
            get => cubes ??= new(userData.GameUserData.currencyStats.cubes);
        }

        public ReactiveProperty<BigInteger> CubesPerSecond
        {
            get => cubesPerSecond ??= new(userData.GameUserData.currencyStats.cubesPerSecond);
        }

        public ReactiveProperty<BigInteger> SpecialCoins
        {
            get => specialCoins ??= new(userData.GameUserData.currencyStats.specialCoins);
        }

        public CurrencyModel(UserData userData)
        {
            this.userData = userData;
        }

        [Serializable]
        public struct SaveData
        {
            public BigInteger coins;
            public BigInteger cubes;
            public BigInteger cubesPerSecond;
            public BigInteger specialCoins;
        }

        public SaveData Data => new()
        {
            coins = Coins.Value,
            cubes = Cubes.Value,
            cubesPerSecond = CubesPerSecond.Value,
            specialCoins = SpecialCoins.Value
        };
    }
}