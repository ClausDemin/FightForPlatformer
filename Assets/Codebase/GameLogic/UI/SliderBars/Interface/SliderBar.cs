using UnityEngine;
using UnityEngine.UI;

namespace Assets.Codebase.GameLogic.UI.SliderBars.Interface
{
    [RequireComponent(typeof(Slider))]
    public abstract class SliderBar
    {
        protected Slider Bar;

        public SliderBar(Slider bar, float current, float max) 
        { 
            Bar = bar;
            Bar.maxValue = max;
            Bar.value = current;
        }

        public void UpdateView(float current, float max)
        {
            if (Bar.maxValue != max) 
            { 
                Bar.maxValue = max;
            }

            HandleViewUpdate(current, max);
        }

        protected abstract void HandleViewUpdate(float current, float max);
    }
}
