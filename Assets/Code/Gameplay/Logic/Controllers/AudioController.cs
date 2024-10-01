using Assets.Code.Gameplay.Logic;
using Assets.Source.Code;
using UnityEngine;
using Zenject;

namespace Assets.Code.Gameplay
{
    public class AudioController : MonoBehaviour
    {
        [SerializeField] private AudioSource _key;
        [SerializeField] private AudioSource _medicine;

        private IReadOnlyHealth _health;
        private IQuest _quest;

        [Inject]
        private void Construct(IReadOnlyHealth health, IQuest quest)
        {
            _health = health;
            _quest = quest;
        }
    }
}