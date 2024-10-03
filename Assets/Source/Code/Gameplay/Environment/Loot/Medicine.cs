using UnityEngine;

namespace Assets.Source.Code
{
    public class Medicine : Loot
    {
        [SerializeField] private int _value;

        private void Start()
        {
            gameObject.SetActive(true);
        }

        private void OnValidate()
        {
            if(_value < 0)
                _value = 0;
        }

        protected override void OnTriggerEnter2D(Collider2D collision)
        {
            base.OnTriggerEnter2D(collision);

            if (collision.TryGetComponent(out IHealthRegenerator player))
            { 
                player.Heal(_value);
                gameObject.SetActive(false);
            }
        }
    }
}