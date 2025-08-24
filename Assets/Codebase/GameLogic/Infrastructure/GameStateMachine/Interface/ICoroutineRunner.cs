using System.Collections;
using UnityEngine;
using UnityEngine.Internal;

namespace Assets.Codebase.GameLogic.Infrastructure.GameStateMachine.Interface
{
    public interface ICoroutineRunner
    {
        public Coroutine StartCoroutine(string methodName);

        public Coroutine StartCoroutine(IEnumerator coroutine);

        public Coroutine StartCoroutine(string methodName, [DefaultValue("null")] object value);
    }
}
