using System.Numerics;

using R3;

namespace IndustrialPlant.UI.MVVM.Switchable.Main
{
    public class SwitchableMainModel
    {
        private ReactiveProperty<BigInteger> currentMoney;
        private ReactiveProperty<BigInteger> incomePerTap;
        private ReactiveProperty<BigInteger> icomePerSecond;
        private ReactiveProperty<int> currentEnergy;
        private ReactiveProperty<int> maxEnergy;

        public ReactiveProperty<BigInteger> CurrentMoney
        {
            get
            {
                currentMoney ??= new(0);
                return currentMoney;
            }
        }

        public ReactiveProperty<BigInteger> IncomePerTap
        {
            get
            {
                incomePerTap ??= new(1);
                return incomePerTap;
            }
        }

        public ReactiveProperty<BigInteger> IncomePerSecond
        {
            get
            {
                icomePerSecond ??= new(1);
                return icomePerSecond;
            }
        }

        public ReactiveProperty<int> CurrentEnergy
        {
            get
            {
                currentEnergy ??= new(10);
                return currentEnergy;
            }
        }

        public ReactiveProperty<int> MaxEnergy
        {
            get
            {
                maxEnergy ??= new(10);
                return maxEnergy;
            }
        }

        public SwitchableMainModel()
        {

        }
    }
}