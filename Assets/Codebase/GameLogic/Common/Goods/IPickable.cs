using Assets.Codebase.GameLogic.Common.Goods.Visitor;

namespace Assets.Codebase.GameLogic.Common.Goods
{
    public interface IPickable
    {
        public void Accept(IPickableVisitor visitor);
    }
}
