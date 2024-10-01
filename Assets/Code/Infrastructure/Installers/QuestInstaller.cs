using Assets.Code.Gameplay.Logic;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Source.Code
{
    public class QuestInstaller : MonoInstaller
    {
        [SerializeField] private FinishingDoor _door;
        [SerializeField] private List<Key> _questItems;

        public override void InstallBindings()
        {
            BindQuest();
            BindFinishingDoor();
            BindQuestHandler();
        }

        private void BindQuest()
        {
            Container.BindInterfacesAndSelfTo<KeyQuest>()
                .AsSingle()
                .WithArguments(_questItems);
        }

        private void BindQuestHandler()
        {
            Container.BindInterfacesTo<QuestHandler>()
                .AsSingle()
                .NonLazy();
        }

        private void BindFinishingDoor()
        {
            Container.Bind<FinishingDoor>()
                .FromInstance(_door)
                .AsSingle();
        }
    }
}