using Assets.Code.Gameplay.Logic;
using Assets.Code.UI;
using System;
using Zenject;

namespace Assets.Source.Code
{
    public class QuestMediator : IDisposable, IInitializable
    {
        private readonly KeyQuest _keyQuest;
        private readonly QuestDisplay _questDisplay;

        public QuestMediator(KeyQuest keyQuest, QuestDisplay questDisplay)
        {
            _keyQuest = keyQuest;
            _questDisplay = questDisplay;

            _keyQuest.Changed += OnKeyCollectionChanged;
        }

        public void Dispose() =>
            _keyQuest.Changed -= OnKeyCollectionChanged;

        public void Initialize()
        {
            _questDisplay.SetMaxScore(_keyQuest.Target);
            _questDisplay.WriteScore(_keyQuest.CollectedKeys);
        }

        private void OnKeyCollectionChanged() =>
            _questDisplay.WriteScore(_keyQuest.CollectedKeys);
    }
}