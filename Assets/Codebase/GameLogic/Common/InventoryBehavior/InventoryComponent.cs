using Assets.Codebase.GameLogic.Common.Goods;
using Assets.Codebase.GameLogic.Common.Goods.Coins;
using Assets.Codebase.GameLogic.Common.Goods.Visitor;
using Assets.Codebase.GameLogic.Common.HealthBehavior;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Codebase.GameLogic.Common.InventoryBehavior
{
    public class InventoryComponent : MonoBehaviour, IPickableVisitor
    {
        private readonly Dictionary<Type, int> _inventory = new();

        public void Add<TGood>() where TGood : class, IPickable
        {
            if (_inventory.ContainsKey(typeof(TGood)))
            {
                _inventory[typeof(TGood)]++;
            }
            else
            {
                _inventory.Add(typeof(TGood), 1);
            }
        }

        public void HandleCollision(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out IPickable pickable))
            {
                pickable.Accept(this);

                Destroy(collision.gameObject);
            }
        }

        public void Visit(Coin coin)
        {
            Add<Coin>();
        }

        public void Visit(HealingPotion healingPotion)
        {
            if (TryGetComponent(out HealthComponent health)) 
            {
                health.Increase(healingPotion.HealingAmount);
            }
        }
    }
}