using System;

namespace Assets.Codebase.GameLogic.Common.HealthBehavior
{
    public class HealthData
    {
        public HealthData(int max)
        {
            Max = max;
            Current = Max;
        }

        public int Max {  get; private set; }
        public int Current { get; private set; }

        public void Reduce(int damage)
        {
            if (damage < 0) 
            {
                throw new ArgumentOutOfRangeException($"Damage must be greater than zero, but value was {damage}");
            }

            if (Current > damage)
            {
                Current -= damage;
            }
            else
            {
                Current = 0;
            }
        }

        public void Increase(int healing) 
        {
            if (healing < 0)
            {
                throw new ArgumentOutOfRangeException($"healing must be greater than zero, but value was {healing}");
            }

            if (Current + healing < Max)
            {
                Current += healing;
            }
            else
            {
                Current = Max;
            }
        }
    }
}