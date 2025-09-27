using Assets.Codebase.GameLogic.Infrastructure.Installers.Interface;
using Assets.Codebase.GameLogic.UI.SliderBars.Core;
using Assets.Codebase.GameLogic.UI.SliderBars.Interface;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Codebase.GameLogic.UI.SliderBars
{
    [RequireComponent(typeof(Slider))]
    public class SmoothedResourceBar : MonoBehaviour, ICoroutineRunner, ISliderView
    {
        [SerializeField] private SmoothSliderBar _bar;
        [SerializeField] private float _changeDuration;

        public void Awake()
        {
            Slider bar = GetComponent<Slider>();

            _bar = new SmoothSliderBar(bar, bar.value, bar.maxValue, this, _changeDuration);
        }

        public void UpdateView(float current, float max)
        {
            _bar.UpdateView(current, max);
        }

        public void SetAnimationDuration(float duration) 
        {
            if (duration < 0) throw new ArgumentOutOfRangeException();

            _changeDuration = duration;
        }
    }
}
