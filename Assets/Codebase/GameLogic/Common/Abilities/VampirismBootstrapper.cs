using Assets.Codebase.GameLogic.UI.SliderBars;
using UnityEngine;

namespace Assets.Codebase.GameLogic.Common.Abilities
{
    public class VampirismBootstrapper: MonoBehaviour
    {
        [SerializeField] private SmoothedResourceBar _bar;
        [SerializeField] private Vampirism _model;
        [SerializeField] private VampirismView _view;
        
        private VampirismPresenter _presenter;

        private void Start() 
        {
            _presenter = new VampirismPresenter(_model, _bar, _view);
        }
    }
}
