using Assets.Codebase.GameLogic.Common.Goods;
using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryComponent : MonoBehaviour
{
    private readonly Dictionary<Type, int> _inventory = new ();

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
            Type type = pickable.GetType();

            if (_inventory.ContainsKey(type))
            {
                _inventory[type]++;
            }
            else 
            { 
                _inventory.Add (type, 1);
            }

            Destroy(collision.gameObject);
        }
    }
}
