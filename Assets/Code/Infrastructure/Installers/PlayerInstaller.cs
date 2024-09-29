using UnityEngine;
using Zenject;

namespace Assets.Source.Code
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private Transform _playerSpawnPoint;
        [SerializeField] private Player _prefab;

        public override void InstallBindings()
        {
            BindHealth();
            BindCharacterController();
            BindInstantiatePrefab();
        }

        private void BindCharacterController()
        {
            Container.BindInterfacesAndSelfTo<CharacterController2D>().AsSingle();
        }

        private void BindHealth()
        {
            Container.BindInterfacesTo<Health>().AsSingle();
        }

        private void BindInstantiatePrefab()
        {
            Player player = Container.InstantiatePrefabForComponent<Player>
                            (_prefab, _playerSpawnPoint.position, Quaternion.identity, null);

            Container.BindInterfacesAndSelfTo<Player>()
                .FromInstance(player)
                .AsSingle()
                .NonLazy();
        }
    }
}
