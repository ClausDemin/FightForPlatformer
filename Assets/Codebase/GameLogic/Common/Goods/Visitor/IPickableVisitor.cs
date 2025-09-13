using Assets.Codebase.GameLogic.Common.Goods.Coins;

namespace Assets.Codebase.GameLogic.Common.Goods.Visitor
{
    public interface IPickableVisitor
    {
        public void Visit(Coin coin);
        public void Visit(HealingPotion healingPotion);
    }
}
