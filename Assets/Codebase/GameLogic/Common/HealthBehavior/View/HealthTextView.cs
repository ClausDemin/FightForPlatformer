using Assets.HealthBarPractice.Codebase.Common.HealthBehavior.View.Interface;
using TMPro;
using UnityEngine;

namespace Assets.HealthBarPractice.Codebase.Common.HealthBehavior.View
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class HealthTextView : MonoBehaviour, IHealthView
    {
        private TextMeshProUGUI _text;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        public void Init(int current, int max)
        {
            UpdateView(current, max);
        }

        public void UpdateView(int current, int max)
        {
            _text.text = ConvertToString(current, max);
        }

        private string ConvertToString(int current, int max) 
        {
            return ($"{current} / {max}");
        }
    }
}
