using Assets.HealthBarPractice.Codebase.Common.HealthBehavior.Presenter;
using Assets.HealthBarPractice.Codebase.Common.HealthBehavior.Presenter.Interface;
using Assets.HealthBarPractice.Codebase.Common.HealthBehavior.View;
using UnityEngine;

namespace Assets.Codebase.GameLogic.Common.HealthBehavior.View
{
    [RequireComponent(typeof(HealthComponent))]
    public class HealthBarBootstrapper: MonoBehaviour
    {
        [SerializeField] private SmoothHealthBar _view;
        
        private IHealthPresenter _presenter;
        private HealthComponent _model;

        private void Start()
        {
            _model = GetComponent<HealthComponent>();
            _presenter = new HealthPresenter(_view, _model);

            _model.Death += OnDeath;
        }

        private void OnDeath() 
        {
            _view.gameObject.SetActive(false);
        }
    }
}
