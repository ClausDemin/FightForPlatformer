using Assets.Codebase.GameLogic.Common.HealthBehavior.Interface;
using System;
using UnityEngine;

namespace Assets.Codebase.GameLogic.Common.HealthBehavior
{
    public class HealthComponent : MonoBehaviour, IDamageable, IHealable
    {
        private HealthData _health;

        public void Init(HealthData healthData)
        {
            _health = healthData;
        }

        public event Action<int> HealthChanged;
        public event Action DamageTaken;
        public event Action Death;

        public int Current => _health.Current;
        public float HealthPercentage => (float)_health.Current / _health.Max;
        public bool IsAlive => _health.Current > 0;

        public void TakeDamage(int damage)
        {
            if (IsAlive) 
            {
                _health.Reduce(damage);

                if (_health.Current == 0)
                {
                    Death?.Invoke();
                }
                else
                {
                    DamageTaken?.Invoke();
                }

                HealthChanged?.Invoke(Current);
            }
        }

        public void Increase(int amount)
        {
            _health.Increase(amount);

            HealthChanged?.Invoke(Current);
        }
    }
}
