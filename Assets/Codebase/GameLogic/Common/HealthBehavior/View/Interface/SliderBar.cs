using UnityEngine;
using UnityEngine.UI;

namespace Assets.HealthBarPractice.Codebase.Common.HealthBehavior.View.Interface
{
    [RequireComponent(typeof(Slider))]
    public abstract class SliderBar : MonoBehaviour, IHealthView
    {
        protected Slider Bar;

        protected virtual void Awake()
        {
            Bar = GetComponent<Slider>();
        }

        public void Init(int current, int max)
        {
            Bar.maxValue = max;
            Bar.value = current;
        }

        public void UpdateView(int current, int max)
        {
            HandleViewUpdate(current, max);
        }

        public abstract void HandleViewUpdate(int current, int max);
    }
}
