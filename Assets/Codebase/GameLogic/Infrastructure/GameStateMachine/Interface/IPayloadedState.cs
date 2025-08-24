namespace Assets.Codebase.GameLogic.Infrastructure.GameStateMachine.Interface
{
    public interface IPayloadedState<TPayload> : IState 
    {
        public void Enter(TPayload payload);
    }
}