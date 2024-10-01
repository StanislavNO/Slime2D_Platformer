using System;
using Zenject;

namespace Assets.Source.Code
{
    public class GameOverManager : IDisposable, IInitializable
    {
        private readonly SceneLoader _sceneLoader;
        private readonly IReadOnlyHealth _health;

        public GameOverManager(SceneLoader sceneLoader, IReadOnlyHealth health)
        {
            _sceneLoader = sceneLoader;
            _health = health;
        }

        public void Initialize() =>
            _health.Died += OnPlayerDied;

        public void Dispose() =>
            _health.Died -= OnPlayerDied;

        private void OnPlayerDied() =>
            _sceneLoader.ReloadCurrentScene();
    }
}