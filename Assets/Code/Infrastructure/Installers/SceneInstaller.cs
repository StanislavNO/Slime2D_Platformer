using UnityEngine;
using Zenject;

namespace Assets.Source.Code
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private PlayerConfig _playerConfig;

        public override void InstallBindings()
        {
            Container.Bind<PlayerConfig>().FromInstance(_playerConfig).AsSingle();
        }
    }
}
