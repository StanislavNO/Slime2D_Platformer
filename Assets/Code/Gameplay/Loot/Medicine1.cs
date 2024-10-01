using UnityEngine;

namespace Assets.Source.Code
{
    public class Medicine1 : Loot
    {
        [SerializeField] private int _value;

        private void OnValidate()
        {
            if(_value < 0)
                _value = 0;
        }
    }
}