using Assets.Code.Gameplay.Logic.Controllers;
using Assets.Code.UI;
using Assets.Source.Code;
using UnityEngine;
using Zenject;

namespace Assets.Code.Infrastructure.Installers
{
    public class MediatorInstaller : MonoInstaller
    {
        [SerializeField] private QuestDisplay _questDisplay;
        [SerializeField] private HealthBar _healthBar;

        public override void InstallBindings()
        {
            BindUI();
            BindMediators();
        }

        private void BindUI()
        {
            Container.Bind<QuestDisplay>().FromInstance(_questDisplay).AsSingle();
            Container.Bind<HealthBar>().FromInstance(_healthBar).AsSingle();
        }

        private void BindMediators()
        {
            Container.BindInterfacesAndSelfTo<QuestMediator>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<HealthMediator>().AsSingle().NonLazy();
        }
    }
}