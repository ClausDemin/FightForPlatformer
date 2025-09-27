using System;

namespace Assets.Codebase.GameLogic.Service.Discrete
{
    public class ValueAccumulator
    {
        private float _current;

        private int _threshold;

        public event Action<int> Ticked;

        public ValueAccumulator(int threshold = 1)
        {
            _current = 0;
            _threshold = threshold;
        }

        public void Accumulate(float value)
        {
            if (value < 0) throw new ArgumentOutOfRangeException($"value must be greater than 0, but was {value}");

            _current += value;

            if (_current > _threshold)
            {
                Ticked?.Invoke(_threshold);

                _current -= _threshold;
            }
        }
    }
}
