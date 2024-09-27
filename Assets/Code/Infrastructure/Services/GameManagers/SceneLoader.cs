using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Source.Code
{
    public class SceneLoader
    {
        private int _nextSceneIndex;

        public SceneLoader()
        {
            _nextSceneIndex = (int)SceneNames.Game;
        }

        public void ReloadCurrentScene() =>
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        public async void LoadNextSceneAsync(Action loadComplete = null) =>
            await LoadSceneAsync(loadComplete);

        public void SetNextScene(SceneNames name) =>
            _nextSceneIndex = (int)name;

        private async UniTask LoadSceneAsync(Action loadComplete)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_nextSceneIndex);

            while (asyncLoad.isDone == false)
                await UniTask.Yield();

            loadComplete?.Invoke();
        }
    }
}
