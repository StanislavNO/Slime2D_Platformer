using Assets.Code.Gameplay.Logic;
using Assets.Source.Code;
using UnityEngine;
using Zenject;

namespace Assets.Code.Gameplay
{
    public class AudioController : MonoBehaviour
    {
        [SerializeField] private AudioSource _questSound;
        [SerializeField] private AudioSource _damageSound;
        [SerializeField] private AudioSource _medicineSound;

        private IReadOnlyHealth _health;
        private IQuest _quest;

        private int _currentHealth;

        [Inject]
        private void Construct(IReadOnlyHealth health, IQuest quest)
        {
            _health = health;
            _quest = quest;
        }

        private void Awake()
        {
            _currentHealth = _health.LifePoint;

            _health.Changed += OnHealthChanged;
            _quest.Changed += OnQuestChanged;
        }

        private void OnDestroy()
        {
            _health.Changed -= OnHealthChanged;
            _quest.Changed -= OnQuestChanged;
        }

        private void OnQuestChanged()
        {
            _questSound.Play();
        }

        private void OnHealthChanged()
        {
            if (_health.LifePoint >= _currentHealth)
                _medicineSound.Play();
            else
                _damageSound.Play();

            _currentHealth = _health.LifePoint;
        }
    }
}