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
}
