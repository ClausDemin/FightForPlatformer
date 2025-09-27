using Assets.Codebase.GameLogic.Infrastructure.Inputs;
using Assets.Codebase.GameLogic.Infrastructure.Inputs.Interface;
using Assets.Codebase.GameLogic.Infrastructure.Installers.Interface;
using Assets.Codebase.GameLogic.Services.ResourcesLoading;
using Zenject;

namespace Assets.Codebase.GameLogic.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller, ICoroutineRunner
    {
        public override void InstallBindings()
        {
            BindInterfaces();
            BindStaticDataProvider();
            BindInputService();
        }

        private void BindStaticDataProvider()
        {
            Container.Bind<StaticDataProvider>().To<StaticDataProvider>().AsSingle();
        }

        private void BindInputService()
        {
            Container.Bind<IInputService>().To<UnityStandaloneInputService>().AsSingle();
        }

        private void BindInterfaces()
        { 
            Container.BindInterfacesAndSelfTo<BootstrapInstaller>().FromInstance(this).AsSingle();
        }
    }
}
