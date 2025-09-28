using Assets.Codebase.GameLogic.Common.HealthBehavior;
using UnityEngine;

namespace Assets.Codebase.GameLogic.UI.SliderBars
{
    public class UIDisabler: MonoBehaviour
    {
        [SerializeField] private SmoothedResourceBar[] _bars;
        [SerializeField] private HealthComponent _health;

        private void Start()
        {
            _health.Death += OnDeath;
        }

        private void OnDeath() 
        {
            if (_bars != null && _bars.Length > 0) 
            {
                foreach (var bar in _bars) 
                { 
                    bar.gameObject.SetActive(false);
                }
            }
        }
    }
}
