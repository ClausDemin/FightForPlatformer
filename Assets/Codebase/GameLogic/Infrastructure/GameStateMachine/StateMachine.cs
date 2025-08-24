using Assets.Codebase.GameLogic.Infrastructure.GameStateMachine.Factory.Interface;
using Assets.Codebase.GameLogic.Infrastructure.GameStateMachine.Interface;

namespace Assets.Codebase.GameLogic.Infrastructure.GameStateMachine
{
    public class StateMachine: IGameStateMachine
    {
        private IState _current;
        private readonly IStateFactory _stateFactory;

        public StateMachine(IStateFactory stateFactory)
        {
            _stateFactory = stateFactory;
        }

        public void Enter<TState>()
            where TState : class, IHollowState
        {
            IHollowState state = ChangeState<TState>();

            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload)
            where TState : class, IPayloadedState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IState
        {
            _current?.Exit();

            TState state = _stateFactory.GetState<TState>();
            _current = state;

            return state;
        }
    }
}
