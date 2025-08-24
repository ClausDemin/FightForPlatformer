using Assets.Codebase.GameLogic.Infrastructure.GameStateMachine;
using Assets.Codebase.GameLogic.Infrastructure.GameStateMachine.Factory;
using Assets.Codebase.GameLogic.Infrastructure.GameStateMachine.Factory.Interface;
using Assets.Codebase.GameLogic.Infrastructure.GameStateMachine.Interface;
using Assets.Codebase.GameLogic.Infrastructure.GameStateMachine.SceneLoading;
using Assets.Codebase.GameLogic.Infrastructure.GameStateMachine.States;
using Assets.Codebase.GameLogic.Services;
using Assets.Codebase.GameLogic.Services.InputService;
using Assets.Codebase.GameLogic.Services.InputService.Core;
using Assets.Codebase.GameLogic.Services.ResourcesLoading;
using Zenject;

namespace Assets.Codebase.GameLogic.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller, ICoroutineRunner, IInitializable
    {
        public override void InstallBindings()
        {
            BindInstallerInterfaces();
            BindStateMachine();
            BindStateFactory();
            BindStates();
            BindSceneLoader();
            BindStaticDataProvider();
            BindInputService();
        }

        public void Initialize()
        {
            Container.Resolve<IGameStateMachine>().Enter<BootstrapState>();
        }

        private void BindInstallerInterfaces()
        {
            Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle();
        }

        private void BindStateMachine()
        {
            Container.BindInterfacesAndSelfTo<StateMachine>().AsSingle();
        }

        private void BindStateFactory()
        {
            Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();
        }

        private void BindStates()
        {
            Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadLevelState>().AsSingle();
        }

        private void BindSceneLoader()
        {
            Container.Bind<SceneLoader>().To<SceneLoader>().AsSingle();
        }

        private void BindStaticDataProvider()
        {
            Container.Bind<StaticDataProvider>().To<StaticDataProvider>().AsSingle();
        }

        private void BindInputService()
        {
            Container.Bind<IInputService>().To<UnityStandaloneInputService>().AsSingle();
        }
    }
}
