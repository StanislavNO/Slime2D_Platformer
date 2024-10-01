using Assets.Source.Code;
using System;
using System.Collections.Generic;

namespace Assets.Code.Gameplay.Logic
{
    public class KeyQuest : IQuest, IDisposable
    {
        public event Action Complied;

        private readonly int _maxKeys;

        private List<Key> _keys;
        private int _collectedKeys;

        public KeyQuest(List<Key> keys)
        {
            if (keys == null)
                throw new ArgumentNullException(nameof(keys));

            _keys = keys;
            _collectedKeys = 0;
            _maxKeys = keys.Count;

            Subscribe();
        }

        public void Dispose()
        {
            Unsubscribe();
        }

        private void Subscribe()
        {
            foreach (var key in _keys)
                key.Collecting += CheckExecution;
        }

        private void Unsubscribe()
        {
            foreach (var key in _keys)
                key.Collecting -= CheckExecution;
        }

        private void CheckExecution(Loot key)
        {
            key.gameObject.SetActive(false);
            _collectedKeys++;

            if (_collectedKeys == _maxKeys)
                Complied?.Invoke();
        }
    }
}