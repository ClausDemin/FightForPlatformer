using System;
using UnityEngine;

namespace Assets.Codebase.GameLogic.Common.Actor.Player.Animation
{
    public class AnimationEventsListener: MonoBehaviour
    {
        public event Action Attack;
        public event Action AttackEnded;

        private void OnAttack()
        {
            Attack?.Invoke();
        }

        private void OnAttackEnded() 
        {
            AttackEnded?.Invoke();
        }
    }
}

