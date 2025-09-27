using System.Collections;
using UnityEngine;

namespace Assets.Codebase.GameLogic.Common.Abilities
{
    public class VampirismView: MonoBehaviour
    {
        [SerializeField] private float _growthTime;


        private void Awake()
        {
            gameObject.SetActive(false);
        }

        public void OnActivate(float size) 
        {
            gameObject.SetActive(true);

            StartCoroutine(PlayGrowthAnimation(size));
        }

        public void OnDeactivate() 
        {
            transform.localScale = Vector3.one;
            gameObject.SetActive(false);
        }

        private IEnumerator PlayGrowthAnimation(float size) 
        {
            Vector3 initialScale = transform.localScale;
            Vector3 targetScale = transform.localScale * size;

            while (transform.localScale != targetScale) 
            { 
                float growthStep = ((targetScale - initialScale).magnitude / _growthTime) * Time.deltaTime;
                transform.localScale = Vector3.MoveTowards(transform.localScale, targetScale, growthStep);

                yield return null;
            }
        }
    }
}
