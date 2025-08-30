namespace Assets.Codebase.GameLogic.Common.AI
{
    public class Sequence : Node
    {
        private Node[] _nodes;

        public Sequence(params Node[] nodes)
        {
            _nodes = nodes;
        }

        public override Status Evaluate()
        {
            foreach (Node node in _nodes) 
            {
                Status status = node.Evaluate();

                if (status != Status.Success)
                {
                    return status;
                }
            }

            return Status.Success;
        }
    }
}
