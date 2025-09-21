using Assets.HealthBarPractice.Codebase.Common.HealthBehavior.View.Interface;

namespace Assets.HealthBarPractice.Codebase.Common.HealthBehavior
{
    public class HealthSliderView : SliderBar
    {
        public override void HandleViewUpdate(int current, int max)
        {
            if (Bar.maxValue != max)
            {
                Bar.maxValue = max;
            }

            Bar.value = current;
        }
    }
}
