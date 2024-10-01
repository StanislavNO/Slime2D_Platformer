using Assets.Code.UI;
using Assets.Source.Code;
using UnityEngine;
using Zenject;

namespace Assets.Code.Infrastructure.Installers
{
    public class MediatorInstaller : MonoInstaller
    {
        [SerializeField] private QuestDisplay _questDisplay;

        public override void InstallBindings()
        {
            Container.Bind<QuestDisplay>().FromInstance(_questDisplay).AsSingle();
            Container.BindInterfacesAndSelfTo<QuestMediator>().AsSingle().NonLazy();
        }
    }
}
