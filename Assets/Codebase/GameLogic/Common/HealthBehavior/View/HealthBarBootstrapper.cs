using Assets.Codebase.GameLogic.UI.SliderBars;
using Assets.HealthBarPractice.Codebase.Common.HealthBehavior.Presenter;
using Assets.HealthBarPractice.Codebase.Common.HealthBehavior.Presenter.Interface;
using UnityEngine;

namespace Assets.Codebase.GameLogic.Common.HealthBehavior.View
{
    [RequireComponent(typeof(HealthComponent))]
    public class HealthBarBootstrapper: MonoBehaviour
    {
        [SerializeField] private SmoothedResourceBar _view;
        
        private IHealthPresenter _presenter;
        private HealthComponent _model;

        private void Start()
        {
            _model = GetComponent<HealthComponent>();
            _view.UpdateView(_model.Current, _model.Max);

            _presenter = new HealthPresenter(_view, _model);
        }
    }
}
