using System;
using UnityEngine;

namespace Assets.Source.Code
{
    [Serializable]
    public class HealthConfig
    {
        [SerializeField, Range(1, 100)] private int _point;

        public int StartPoint => _point;
    }
}
