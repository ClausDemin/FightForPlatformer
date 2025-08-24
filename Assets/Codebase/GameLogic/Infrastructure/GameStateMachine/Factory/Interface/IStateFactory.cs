using Assets.Codebase.GameLogic.Infrastructure.GameStateMachine.Interface;

namespace Assets.Codebase.GameLogic.Infrastructure.GameStateMachine.Factory.Interface
{
    public interface IStateFactory
    {
        T GetState<T>() where T : class, IState;
    }
}
