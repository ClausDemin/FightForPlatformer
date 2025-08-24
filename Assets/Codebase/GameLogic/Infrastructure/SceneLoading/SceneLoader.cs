using Assets.Codebase.GameLogic.Infrastructure.GameStateMachine.Interface;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Codebase.GameLogic.Infrastructure.GameStateMachine.SceneLoading
{
    public class SceneLoader
    {
        private ICoroutineRunner _coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void Load(string sceneName, Action callback = null) 
        {
            if (SceneManager.GetActiveScene().name != sceneName)
            {
                _coroutineRunner.StartCoroutine(LoadScene(sceneName, callback));
            }
            else 
            { 
                callback?.Invoke();
            }
        }

        private IEnumerator LoadScene(string sceneName, Action callback = null) 
        {
            AsyncOperation waitNextScene =  SceneManager.LoadSceneAsync(sceneName);

            while (waitNextScene.isDone == false) 
            { 
                yield return null;
            }

            callback?.Invoke();
        }
    }
}
