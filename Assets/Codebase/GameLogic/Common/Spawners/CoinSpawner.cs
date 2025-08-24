using Assets.Codebase.GameLogic.Common.Goods.Coins;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _prefab;

    private void Awake()
    {
        Instantiate(_prefab, transform.position, Quaternion.identity, null);
    }
}
