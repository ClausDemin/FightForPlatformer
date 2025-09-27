using Assets.Codebase.GameLogic.Common.HealthBehavior;
using Assets.Codebase.GameLogic.UI.SliderBars;
using Assets.HealthBarPractice.Codebase.Common.HealthBehavior.Presenter.Interface;

namespace Assets.HealthBarPractice.Codebase.Common.HealthBehavior.Presenter
{
    public class HealthPresenter : IHealthPresenter
    {
        private SmoothedResourceBar _view;
        private HealthComponent _health;

        public HealthPresenter(SmoothedResourceBar view, HealthComponent health)
        {
            _view = view;
            _health = health;

            _health.Changed += OnHealthChanged;
        }

        private void OnHealthChanged()
        {
            _view.UpdateView(_health.Current, _health.Max);
        }
    }
}
