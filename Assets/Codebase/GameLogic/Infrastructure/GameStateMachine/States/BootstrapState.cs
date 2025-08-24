using Assets.Codebase.GameLogic.Infrastructure.GameStateMachine.Interface;
using Assets.Codebase.GameLogic.Infrastructure.GameStateMachine.SceneLoading;
using Assets.Codebase.GameLogic.Infrastructure.GameStateMachine.States;

namespace Assets.Codebase.GameLogic.Infrastructure.GameStateMachine
{
    public class BootstrapState : IHollowState
    {
        private const string InitialSceneName = "InitialScene";
        private const string MainSceneName = "MainScene";

        private readonly StateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public BootstrapState(StateMachine stateMachine, SceneLoader sceneLoader) 
        { 
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;

            RegisterServices();
        }

        public void Enter()
        {
            _sceneLoader.Load(InitialSceneName, EnterLoadLevel);
        }

        public void Exit()
        {
            
        }

        private void RegisterServices()
        {

        }

        private void EnterLoadLevel()
        {
            _stateMachine.Enter<LoadLevelState, string>(MainSceneName);
        }
    }
}
