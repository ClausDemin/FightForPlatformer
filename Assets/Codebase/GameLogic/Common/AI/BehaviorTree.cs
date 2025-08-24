namespace Assets.Codebase.GameLogic.Common.AI
{
    public class BehaviorTree
    {
        private Node _root;

        public BehaviorTree(Node root)
        {
            _root = root;
        }

        public void Update() 
        {
            _root.Evaluate();
        }
    }
}
