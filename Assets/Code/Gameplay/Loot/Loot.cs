using System;
using UnityEngine;

namespace Assets.Source.Code
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class Loot : MonoBehaviour
    {
        public event Action<Loot> Collecting;

        protected virtual void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out ILootCollector _))
                Collecting?.Invoke(this);
        }
    }
}