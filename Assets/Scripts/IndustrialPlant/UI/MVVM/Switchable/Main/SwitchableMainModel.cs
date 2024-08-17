using System.Numerics;

using R3;

namespace IndustrialPlant.UI.MVVM.Switchable.Main
{
    public class SwitchableMainModel
    {
        private ReactiveProperty<BigInteger> currentCoins;
        private ReactiveProperty<BigInteger> currentCubes;
        private ReactiveProperty<BigInteger> cubesPerSecond;
        private ReactiveProperty<BigInteger> currentDiamonds;
        private ReactiveProperty<BigInteger> currentSpecialCoins;

        public ReactiveProperty<BigInteger> CurrentCoins
        {
            get
            {
                currentCoins ??= new(10);
                return currentCoins;
            }
        }

        public ReactiveProperty<BigInteger> CurrentCubes
        {
            get
            {
                currentCubes ??= new(10);
                return currentCubes;
            }
        }

        public ReactiveProperty<BigInteger> CubesPerSecond
        {
            get
            {
                cubesPerSecond ??= new(10);
                return cubesPerSecond;
            }
        }

        public ReactiveProperty<BigInteger> CurrentDiamonds
        {
            get
            {
                currentDiamonds ??= new(10);
                return currentDiamonds;
            }
        }

        public ReactiveProperty<BigInteger> CurrentSpecialCoins
        {
            get
            {
                currentSpecialCoins ??= new(10);
                return currentSpecialCoins;
            }
        }

        public SwitchableMainModel()
        {

        }
    }
}