using Assets.Codebase.GameLogic.Common.Abilities.Interface;
using Assets.Codebase.GameLogic.Common.Actor.Enemy;
using Assets.Codebase.GameLogic.Common.AttackBehavior.Interface;
using Assets.Codebase.GameLogic.Common.HealthBehavior;
using Assets.Codebase.GameLogic.Common.HealthBehavior.Interface;
using Assets.Codebase.GameLogic.Infrastructure.Repositories.Interface;
using Assets.Codebase.GameLogic.Service.Discrete;
using Assets.Codebase.GameLogic.Services.ResourcesLoading;
using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Assets.Codebase.GameLogic.Common.Abilities
{
    public class Vampirism : MonoBehaviour, IAbility
    {
        private IDamageService _damageService;
        private IDamageable _current;
        private IRepository<EnemyComponent> _enemies;
        private ValueAccumulator _damageAccumulator;
        private YieldInstruction _cooldownAwaiter;

        [SerializeField] HealthComponent _health;

        private int _damage;
        private bool _isRunning;

        public event Action Used;
        public event Action CooldownRaised;
        public event Action CooldownReleased;
        
        public float Radius { get; private set; }
        public float Duration { get; private set; }
        public float Cooldown { get; private set; }

        [Inject]
        public void Construct(IDamageService damageService, IRepository<EnemyComponent> enemies, StaticDataProvider staticDataProvider)
        {
            _damageAccumulator = new ValueAccumulator();
            _damageService = damageService;
            _enemies = enemies;

            _damageAccumulator.Ticked += OnAccumulated;

            InitFieldsFromStaticData(staticDataProvider);
        }

        private void OnDestroy()
        {
            _damageAccumulator.Ticked -= OnAccumulated;
        }

        public bool IsInCooldown { get; private set; }

        public void Use()
        {
            if (CanUse())
            {
                StartCoroutine(UseAbility());
            }
        }

        private bool TryFindTarget()
        {
            _current = _enemies
                .Entities
                .Select(enemy => enemy.GetComponent<HealthComponent>())
                .OrderBy(enemy => (enemy.transform.position - transform.position).sqrMagnitude < Radius * Radius)
                .Where(enemy => IsInRadius(enemy.transform))
                .FirstOrDefault();
                
            if (_current != null) 
            { 
                return true;
            }

            return false;
        }

        private IEnumerator UseAbility()
        {
            IsInCooldown = true;
            _isRunning = true;

            Used?.Invoke();

            float timer = 0;
            float damagePerSecond = _damage / Duration;

            while (timer < Duration)
            {
                TryFindTarget();

                if (_current != null)
                {
                    float damagePerFrame = damagePerSecond * Time.deltaTime;

                    _damageAccumulator.Accumulate(damagePerFrame);
                }

                timer += Time.deltaTime;

                yield return null;

            }

            StartCoroutine(FreeCooldown());

            _isRunning = false;

            yield break;
        }

        private IEnumerator FreeCooldown()
        {
            CooldownRaised?.Invoke();

            yield return _cooldownAwaiter;

            IsInCooldown = false;

            CooldownReleased?.Invoke();

            yield break;
        }

        private bool CanUse()
        {
            return _isRunning == false && IsInCooldown == false;
        }

        private bool IsInRadius(Transform target) 
        {
            return (target.position - transform.position).magnitude < Radius ;
        }

        private void OnAccumulated(int damage) 
        {
            _damageService.PerformAttack(_current, damage);
            _health.Increase(damage);
        }

        private void InitFieldsFromStaticData(StaticDataProvider staticDataProvider)
        {
            _damage = staticDataProvider.VampirismConfig.Damage;
            Radius = staticDataProvider.VampirismConfig.Radius;

            Duration = staticDataProvider.VampirismConfig.Duration;
            Cooldown = staticDataProvider.VampirismConfig.Cooldown;

            _cooldownAwaiter = new WaitForSeconds(Cooldown);
        }
    }
}
