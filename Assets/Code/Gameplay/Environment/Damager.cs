using Assets.Code.Gameplay.Player;
using Assets.Source.Code;
using UnityEngine;
using Zenject;

namespace Assets.Code.Gameplay.Environment
{
    public class Damager : MonoBehaviour
    {
        [SerializeField] private Collider2D _collider;
        [SerializeField][Range(0, 100)] private int _damage;
        [SerializeField][Range(0, 10)] private float _cooldown;

        private float _timeCounter;
        private IHealthDamageHandler _player;

        [Inject]
        private void Construct(IHealthDamageHandler player)
        {
            _player = player;
        }

        private void Awake()
        {
            _collider.isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.TryGetComponent(out IPlayer _))
                _player.TakeDamage(_damage);
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            _timeCounter += Time.deltaTime;

            if (_timeCounter >= _cooldown)
            {
                Debug.Log("damage");
                _player.TakeDamage(_damage);
                _timeCounter = 0;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _timeCounter = 0;
        }
    }
}