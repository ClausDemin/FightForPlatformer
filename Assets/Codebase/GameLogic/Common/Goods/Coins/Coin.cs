using Assets.Codebase.GameLogic.Common.Goods.Visitor;
using UnityEngine;

namespace Assets.Codebase.GameLogic.Common.Goods.Coins
{
    public class Coin : MonoBehaviour, IPickable
    {
        public void Accept(IPickableVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
