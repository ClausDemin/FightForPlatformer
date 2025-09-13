using System.Collections.Generic;

namespace Assets.Codebase.GameLogic.Common.AI
{
    public class Sequence : Node
    {
        private Node[] _nodes;

        private int _current = 0;

        public Sequence(params Node[] nodes)
        {
            _nodes = nodes;
        }

        public override Status Evaluate()
        {
            while(_current < _nodes.Length) 
            { 
                Status status = _nodes[_current].Evaluate();

                if (status == Status.Success)
                {
                    _current++;

                    return Status.Running;
                }
                else if (status == Status.Running)
                {
                    return Status.Running;
                }
                else 
                {
                    _current = 0;

                    return Status.Failure;
                }
            }

            _current = 0;

            return Status.Success;
        }
    }
}
