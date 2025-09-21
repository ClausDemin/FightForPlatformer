using Assets.Codebase.GameLogic.Common.HealthBehavior;
using Assets.HealthBarPractice.Codebase.Common.HealthBehavior.Presenter.Interface;
using Assets.HealthBarPractice.Codebase.Common.HealthBehavior.View.Interface;
using System;

namespace Assets.HealthBarPractice.Codebase.Common.HealthBehavior.Presenter
{
    public class HealthPresenter : IHealthPresenter
    {
        private IHealthView _view;
        private HealthComponent _health;

        public HealthPresenter(IHealthView view, HealthComponent health)
        {
            _view = view;
            _health = health;

            _view.Init(_health.Current, _health.Max);

            _health.Changed += OnHealthChanged;
        }

        private void OnHealthChanged()
        {
            _view.UpdateView(_health.Current, _health.Max);
        }
    }
}
