using Assets.Codebase.GameLogic.Common.AttackBehavior.Interface;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Codebase.GameLogic.Common.AttackBehavior
{
    public class AttackComponent : MonoBehaviour, IAttacker
    {
        private const float Offset = 1.0f;

        [SerializeField] private Transform _view;

        private IDamageService _damageService;
        private AttackData _data;

        public void Init(IDamageService damageService, AttackData data)
        {
            _damageService = damageService;
            _data = data;
            IsInCooldown = false;
        }

        public event Action Happened;

        public GameObject GameObject => gameObject;
        public float Radius => _data.Radius;
        public bool IsInCooldown { get; private set; }

        public bool TryStart()
        {
            if (IsInCooldown == false) 
            { 
                Happened?.Invoke();
                return true;
            }

            return false;
        }

        public void ApplyDamage()
        {
            Vector3 attackOrigin = transform.position + _view.right * Offset;

            _damageService.PerformAttack(this, _data.Damage, attackOrigin, _data.Radius);
        }

        public void RaiseCooldown() 
        {
            IsInCooldown = true;

            StartCoroutine(FreeCooldown(_data.Cooldown));
        }

        private IEnumerator FreeCooldown(float forSeconds) 
        {
            yield return  new WaitForSeconds(forSeconds);

            IsInCooldown = false;
        }
    }
}
