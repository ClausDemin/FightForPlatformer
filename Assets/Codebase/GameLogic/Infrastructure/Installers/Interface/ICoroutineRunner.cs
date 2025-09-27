using System.Collections;
using UnityEngine;
using UnityEngine.Internal;

namespace Assets.Codebase.GameLogic.Infrastructure.Installers.Interface
{
    public interface ICoroutineRunner
    {
        public Coroutine StartCoroutine(string methodName);

        public Coroutine StartCoroutine(IEnumerator coroutine);

        public Coroutine StartCoroutine(string methodName, [DefaultValue("null")] object value);

        public void StopCoroutine(string methodName);

        public void StopCoroutine(IEnumerator routine);

        public void StopCoroutine(Coroutine routine);
    }
}
