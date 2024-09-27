using UnityEngine;
using Zenject;

namespace Assets.Source.Code
{
    public class EntryPoint : MonoBehaviour, ICoroutineRunner
    {
        private SceneLoader _sceneLoader;

        [Inject]
        private void Construct(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        private void Start()
        {
            _sceneLoader.LoadNextSceneAsync();
        }
    }
}