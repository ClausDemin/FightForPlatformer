using Assets.Codebase.GameLogic.Common.AttackBehavior.Interface;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Codebase.GameLogic.Common.AttackBehavior
{
    public class AttackComponent : MonoBehaviour
    {
        private const float Offset = 1.0f;

        private IDamageService _damageService;
        private AttackData _attackData;

        public void Init(IDamageService damageService, AttackData attackData)
        {
            _damageService = damageService;
            _attackData = attackData;
            IsInCooldown = false;
        }

        public event Action Attack;

        public float Radius => _attackData.Radius;
        public bool IsInCooldown { get; private set; }

        public bool TryStartAttack()
        {
            if (IsInCooldown == false) 
            { 
                Attack?.Invoke();
                return true;
            }

            return false;
        }

        public void ApplyDamage()
        {
            Vector3 attackOrigin = transform.position + transform.right * Offset;

            _damageService.Attack(gameObject, _attackData.Damage, attackOrigin, _attackData.Radius);
        }

        public void RaiseCooldown() 
        {
            IsInCooldown = true;

            StartCoroutine(FreeCooldown(_attackData.Cooldown));
        }

        private IEnumerator FreeCooldown(float forSeconds) 
        {
            yield return  new WaitForSeconds(forSeconds);

            IsInCooldown = false;
        }
    }
}
