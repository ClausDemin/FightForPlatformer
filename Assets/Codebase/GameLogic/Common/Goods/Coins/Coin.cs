using UnityEngine;

namespace Assets.Codebase.GameLogic.Common.Goods.Coins
{
    public class Coin: MonoBehaviour, IPickable
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.TryGetComponent<InventoryComponent>(out var inventory)) 
            {
                inventory.Add<Coin>();
                Destroy(gameObject);
            }
        }
    }
}
