using Assets.Codebase.GameLogic.Common.Goods;
using Assets.Codebase.GameLogic.Common.Goods.Visitor;
using UnityEngine;

public class HealingPotion : MonoBehaviour, IPickable
{

    public int HealingAmount { get; private set;}

    public void Construct(int healingAmount) 
    { 
        HealingAmount = healingAmount;
    }

    public void Accept(IPickableVisitor visitor)
    {
        visitor.Visit(this);
    }
}
