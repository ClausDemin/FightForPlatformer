namespace Assets.Codebase.GameLogic.Infrastructure.GameStateMachine.Interface
{
    public interface IGameStateMachine
    {
        public void Enter<TState>() where TState : class, IHollowState;
        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>;
    }
}
