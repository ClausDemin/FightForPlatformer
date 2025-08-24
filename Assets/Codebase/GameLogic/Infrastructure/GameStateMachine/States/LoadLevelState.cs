using Assets.Codebase.GameLogic.Infrastructure.GameStateMachine.Interface;
using Assets.Codebase.GameLogic.Infrastructure.GameStateMachine.SceneLoading;

namespace Assets.Codebase.GameLogic.Infrastructure.GameStateMachine.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly StateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public LoadLevelState(SceneLoader sceneLoader) 
        {
            _sceneLoader = sceneLoader;
        }

        public void Enter(string sceneName)
        {
            _sceneLoader.Load(sceneName, OnSceneLoaded);
        }

        public void Exit()
        {
            
        }

        private void OnSceneLoaded() 
        {

        }
    }
}
