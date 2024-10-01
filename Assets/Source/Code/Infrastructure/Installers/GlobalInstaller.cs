using UnityEngine;
using Zenject;

namespace Assets.Source.Code
{
    public class GlobalInstaller : MonoInstaller
    {
        [SerializeField] private PlayerConfig _playerConfig;

        public override void InstallBindings()
        {
            BindInput();
            BindSceneLoader();
            BindPlayerConfig();
        }

        private void BindSceneLoader()
        {
            Container.Bind<SceneLoader>().AsSingle();
        }

        private void BindInput()
        {
            Container.BindInterfacesAndSelfTo<StandaloneInput>().AsSingle();
        }

        private void BindPlayerConfig()
        {
            Container.Bind<PlayerConfig>().FromInstance(_playerConfig).AsSingle();
        }
    }
}