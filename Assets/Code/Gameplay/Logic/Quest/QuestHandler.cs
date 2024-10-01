using Assets.Source.Code;
using System;

namespace Assets.Code.Gameplay.Logic
{
    public class QuestHandler : IDisposable
    {
        private readonly IQuest _quest;
        private readonly FinishingDoor _door;
        private readonly SceneLoader _sceneLoader;

        public QuestHandler(IQuest quest, FinishingDoor door, SceneLoader sceneLoader)
        {
            _quest = quest;
            _door = door;
            _sceneLoader = sceneLoader;

            _quest.Complied += OnQuestComplied;
            _door.FinishComplied += OnPlayerFinishDetected;
        }

        public void Dispose()
        {
            _quest.Complied -= OnQuestComplied;
            _door.FinishComplied -= OnPlayerFinishDetected;
        }

        private void OnPlayerFinishDetected() =>
            _sceneLoader.ReloadCurrentScene();

        private void OnQuestComplied() =>
            _door.Open();
    }
}