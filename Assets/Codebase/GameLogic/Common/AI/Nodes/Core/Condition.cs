namespace Assets.Codebase.GameLogic.Common.AI.Nodes.Core
{
    public abstract class Condition : Node
    {
        private readonly Node _child;

        public Condition(Node child)
        {
            _child = child;
        }

        public override Status Evaluate()
        {
            if (CanEvaluate()) 
            { 
                return _child.Evaluate();
            }

            return Status.Failure;
        }

        protected abstract bool CanEvaluate();
    }
}
