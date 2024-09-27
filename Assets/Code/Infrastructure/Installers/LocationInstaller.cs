using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.TextCore.Text;
using Zenject;

namespace Assets.Source.Code
{
    public class LocationInstaller : MonoInstaller
    {
        [SerializeField] private Transform _playerSpawnPoint;
        [SerializeField] private Player _prefab;

        public override void InstallBindings()
        {
            InstallPlayer();
        }

        private void InstallPlayer()
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
