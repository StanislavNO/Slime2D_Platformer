using System;
using UnityEngine;

namespace Assets.Source.Code
{
    [Serializable]
    public class AirborneStateConfig
    {
        [SerializeField] private JumpingStateConfig _jumpingStateConfig;
        [SerializeField, Range(0, 10)] private float _speed;

        public JumpingStateConfig JumpingStateConfig => _jumpingStateConfig;

        public float Speed => _speed;

        public float BaseGravity
            => 2f * _jumpingStateConfig.MaxHeight / (_jumpingStateConfig.TimeToReachMaxHeight * _jumpingStateConfig.TimeToReachMaxHeight);
    }
}