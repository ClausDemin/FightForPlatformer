using Assets.Codebase.GameLogic.Infrastructure.Inputs;
using Assets.Codebase.GameLogic.Infrastructure.Inputs.Interface;
using Assets.Codebase.GameLogic.Services.ResourcesLoading;
using Zenject;

namespace Assets.Codebase.GameLogic.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
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
    }
}
