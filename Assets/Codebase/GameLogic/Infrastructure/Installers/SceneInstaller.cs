using Assets.Codebase.GameLogic.Common.Ground;
using Assets.Codebase.GameLogic.Common.JumpBehavior;
using Assets.Codebase.GameLogic.Common.JumpBehavior.Interface;
using Assets.Codebase.GameLogic.Common.MovementBehavior;
using Assets.Codebase.GameLogic.Common.MovementBehavior.Interface;
using Assets.Codebase.GameLogic.Infrastructure.Factories;
using Zenject;

namespace Assets.Codebase.GameLogic.Infrastructure.Installers
{
    public class SceneInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            BindMovementCalculator();
            BindRotationService();
            BindMovementService();
            BindJumpService();
            BindGroundChecker();
            BindFactories();
        }

        private void BindMovementCalculator() 
        {
            Container.Bind<MovementCalculator>().To<MovementCalculator>().AsSingle();
        }

        private void BindRotationService()
        {
            Container.Bind<RotationService>().To<RotationService>().AsSingle();
        }

        private void BindMovementService()
        {
            Container.Bind<IMovementService>().To<MovementService>().AsSingle();
        }

        private void BindJumpService()
        {
            Container.Bind<IJumpService>().To<JumpService>().AsSingle();
        }

        private void BindGroundChecker()
        {
            Container.Bind<GroundChecker>().To<GroundChecker>().AsSingle();
        }

        private void BindFactories()
        {
            Container.Bind<EnemyFactory>().To<EnemyFactory>().AsSingle();
            Container.Bind<PlayerFactory>().To<PlayerFactory>().AsSingle();
        }
    }
}
