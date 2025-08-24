using Assets.Codebase.GameLogic.Common.Actor.Enemy;
using Assets.Codebase.GameLogic.Common.AI.Nodes.Core;

namespace Assets.Codebase.GameLogic.Common.AI.Nodes.Implementation
{
    public class HasEnemy : Condition
    {
        private EnemyComponent _character;

        public HasEnemy(Node child, EnemyComponent character) : base(child)
        {
            _character = character;
        }

        protected override bool CanEvaluate()
        {
            return _character.HasEnemy;
        }
    }
}
