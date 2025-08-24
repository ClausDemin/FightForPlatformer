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
                switch (node.Evaluate())
                {
                    case Status.Failure:
                        continue;

                    case Status.Running:
                        return Status.Running;

                    case Status.Success:
                        return Status.Success;
                }
            }

            return Status.Failure;
        }
    }
}
