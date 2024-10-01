using Assets.Source.Code;
using System;
using System.Collections.Generic;

namespace Assets.Code.Gameplay.Logic
{
    public class KeyQuest : IQuest, IDisposable
    {
        public event Action Complied;
        public event Action Changed;

        private List<Key> _keys;

        public int Target { get; private set; }
        public int CollectedKeys { get; private set; }

        public KeyQuest(List<Key> keys)
        {
            if (keys == null)
                throw new ArgumentNullException(nameof(keys));

            _keys = keys;
            CollectedKeys = 0;
            Target = _keys.Count;

            Subscribe();
        }

        public void Dispose()
        {
            Unsubscribe();
        }

        private void Subscribe()
        {
            foreach (var key in _keys)
                key.Collecting += OnKeyCollecting;
        }

        private void Unsubscribe()
        {
            foreach (var key in _keys)
                key.Collecting -= OnKeyCollecting;
        }

        private void OnKeyCollecting(Loot key)
        {
            key.gameObject.SetActive(false);
            CollectedKeys++;
            Changed?.Invoke();

            if (CollectedKeys == Target)
                Complied?.Invoke();
        }
    }
}