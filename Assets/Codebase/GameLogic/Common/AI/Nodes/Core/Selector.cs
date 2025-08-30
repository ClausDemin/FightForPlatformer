namespace Assets.Codebase.GameLogic.Common.AI
{
    public class Selector : Node
    {
        private Node[] _nodes;

        public Selector(params Node[] nodes) 
        {
            _nodes = nodes;
        }

        public override Status Evaluate()
        {
            foreach (Node node in _nodes) 
            {
                Status status = node.Evaluate();

                if (status != Status.Failure) 
                {
                    return status;
                }
            }

            return Status.Failure;
        }
    }
}
