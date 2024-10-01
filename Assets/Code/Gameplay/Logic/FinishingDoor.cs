using Assets.Source.Code;
using System;
using UnityEngine;

namespace Assets.Code.Gameplay.Logic
{
    public class FinishingDoor : MonoBehaviour
    {
        public event Action FinishComplied;

        [SerializeField] private Sprite _startSprite;
        [SerializeField] private Sprite _endSprite;
        [SerializeField] private SpriteRenderer _renderer;
        [SerializeField] private Collider2D _collider;

        private void Awake()
        {
            Close();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Player _))
                FinishComplied?.Invoke();
        }

        public void Open()
        {
            _renderer.sprite = _endSprite;
            _collider.enabled = true;
        }

        private void Close()
        {
            _collider.isTrigger = true;
            _collider.enabled = false;
            _renderer.sprite = _startSprite;
        }
    }
}