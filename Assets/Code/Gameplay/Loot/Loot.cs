using System;
using UnityEngine;

namespace Assets.Source.Code
{
    [RequireComponent(typeof(Collider2D))]
    public class Loot : MonoBehaviour
    {
        public event Action<LootNames> Collecting;

        [SerializeField] private LootNames _name;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out ILootCollector _))
            {
                Collecting?.Invoke(_name);
            }
        }
    }
}