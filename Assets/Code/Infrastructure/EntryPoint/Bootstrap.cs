using UnityEngine;
using Zenject;

namespace Assets.Source.Code
{
    public class Bootstrap : MonoBehaviour
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