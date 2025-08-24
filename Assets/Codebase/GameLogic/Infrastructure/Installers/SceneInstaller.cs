using Assets.Codebase.GameLogic.Common.Ground;
using Assets.Codebase.GameLogic.Common.MovementBehavior;
using Assets.Codebase.GameLogic.Common.MovementBehavior.Interface;
using Assets.Codebase.GameLogic.Services;
using Zenject;

namespace Assets.Codebase.GameLogic.Infrastructure.Installers
{
    public class SceneInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            BindMovementCalculator();
            BindMovementService();
            BindGroundChecker();
            BindActorsFactory();
        }

        private void BindGroundChecker()
        {
            Container.Bind<GroundChecker>().To<GroundChecker>().AsSingle();
        }

        private void BindMovementCalculator() 
        {
            Container.Bind<MovementCalculator>().To<MovementCalculator>().AsSingle();
        }

        private void BindMovementService()
        {
            Container.Bind<IMovementService>().To<MovementService>().AsSingle();
        }

        private void BindActorsFactory()
        {
            Container.Bind<ActorsFactory>().To<ActorsFactory>().AsSingle();
        }
    }
}
