using Assets.Codebase.GameLogic.Infrastructure.GameStateMachine.Factory.Interface;
using Assets.Codebase.GameLogic.Infrastructure.GameStateMachine.Interface;
using Zenject;

namespace Assets.Codebase.GameLogic.Infrastructure.GameStateMachine.Factory
{
    public class StateFactory: IStateFactory
    {
        private readonly DiContainer _container;

        public StateFactory(DiContainer container)
        {
            _container = container;
        }

        public T GetState<T>() where T : class, IState
        {
            return _container.Resolve<T>();
        }
    }

}
