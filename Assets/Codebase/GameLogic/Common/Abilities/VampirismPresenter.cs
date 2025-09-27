using Assets.Codebase.GameLogic.UI.SliderBars;

namespace Assets.Codebase.GameLogic.Common.Abilities
{
    public class VampirismPresenter
    {
        private Vampirism _model;
        private VampirismView _view;
        private SmoothedResourceBar _bar;

        public VampirismPresenter(Vampirism model, SmoothedResourceBar bar, VampirismView view)
        {
            _model = model;
            _bar = bar;

            _bar.SetAnimationDuration(_model.Duration);

            SubscribeModelEvents();
            _view = view;
        }

        private void SubscribeModelEvents()
        {
            _model.Used += OnUsed;
            _model.CooldownRaised += OnCooldownRaised;
            _model.CooldownReleased += OnCooldownReleased;
        }

        private void OnUsed() 
        {
            _bar.UpdateView(0, 1);
            _view.OnActivate(_model.Radius * 2);
        }

        private void OnCooldownRaised() 
        {
            _bar.SetAnimationDuration(_model.Cooldown);
            _bar.UpdateView(1, 1);

            _view.OnDeactivate();
        }

        private void OnCooldownReleased() 
        {
            _bar.SetAnimationDuration(_model.Duration);
        }
    }
}
