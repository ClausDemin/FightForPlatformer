using Assets.Codebase.GameLogic.Infrastructure.Installers.Interface;
using Assets.Codebase.GameLogic.UI.SliderBars.Interface;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Codebase.GameLogic.UI.SliderBars.Core
{
    public class SmoothSliderBar : SliderBar
    {
        private Coroutine _animation;
        private ICoroutineRunner _coroutineRunner;

        public SmoothSliderBar(Slider bar, float current, float max, ICoroutineRunner coroutineRunner, float changeDuration) : base(bar, current, max)
        {
            ChangeDuration = changeDuration;
            _coroutineRunner = coroutineRunner;
        }

        public float ChangeDuration { get; private set; }
        
        public void SetAnimationDuration(float duration)
        {
            if (duration < 0) throw new ArgumentOutOfRangeException();

            ChangeDuration = duration;
        }

        protected override void HandleViewUpdate(float current, float max)
        {
            PlayChangeAnimation(current);
        }

        private void PlayChangeAnimation(float current)
        {
            if (Bar.isActiveAndEnabled)
            {
                if (_animation != null)
                {
                    _coroutineRunner.StopCoroutine(_animation);
                }

                _animation = _coroutineRunner.StartCoroutine(ChangeValue(current));
            }
        }

        private IEnumerator ChangeValue(float target)
        {
            float timer = ChangeDuration;

            while (Bar.value != target)
            {
                float changeStep = Mathf.Abs((Bar.value - target)/ timer) * Time.deltaTime;

                Bar.SetValueWithoutNotify(Mathf.MoveTowards(Bar.value, target, changeStep));

                timer -= Time.deltaTime;

                yield return null;
            }

            _animation = null;

            yield break;
        }
    }
}
