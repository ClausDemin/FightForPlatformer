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
                switch (node.Evaluate())
                {
                    case Status.Failure:
                        return Status.Failure;

                    case Status.Running:
                        return Status.Running;

                    case Status.Success:
                        continue;
                }
            }

            return Status.Success;
        }
    }
}
