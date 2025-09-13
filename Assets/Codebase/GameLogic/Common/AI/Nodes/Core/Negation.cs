namespace Assets.Codebase.GameLogic.Common.AI.Nodes.Core
{
    public class Negation : Node
    {
        private Condition _condition;

        private Node _child;

        public Negation(Condition condition, Node child)
        {
            _condition = condition;
            _child = child;
        }

        public override Status Evaluate()
        {
            if (_condition.Evaluate() == Status.Failure)
            {
                return _child.Evaluate();
            }

            return Status.Failure;
        }
    }
}
