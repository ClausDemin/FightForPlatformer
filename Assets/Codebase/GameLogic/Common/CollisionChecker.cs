using System;
using UnityEngine;

namespace Assets.Codebase.GameLogic.Common
{
    public class CollisionChecker: MonoBehaviour
    {
        public event Action<Collision2D> CollisionEntered;
        public event Action<Collision2D> CollisionStay;

        public event Action<Collider2D> TriggerEntered;
        public event Action<Collider2D> TriggerExited;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            CollisionEntered?.Invoke(collision);
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            CollisionStay?.Invoke(collision);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            TriggerEntered?.Invoke(collision);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            TriggerExited?.Invoke(collision);
        }
    }
}
