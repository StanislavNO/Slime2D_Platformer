using System;
using UnityEngine;

namespace Assets.Source.Code
{
    public class Health : IReadOnlyHealth
    {
        private const int MIN_POINT = 0;

        public event Action Died;
        public event Action Changed;

        public int LifePoint { get; private set; }
        public int MaxPoint { get; private set; }

        public Health(PlayerConfig playerConfig)
        {
            LifePoint = playerConfig.HealthConfig.StartPoint;
            MaxPoint = LifePoint;
        }

        public void TakeDamage(int value)
        {
            if (value < MIN_POINT)
                throw new ArgumentOutOfRangeException("value");

            if (LifePoint > value)
                LifePoint -= value;
            else
                LifePoint = MIN_POINT;

            if (LifePoint <= MIN_POINT)
                Died.Invoke();

            Changed?.Invoke();
        }

        public void Heal(int value)
        {
            if (value < MIN_POINT)
                throw new ArgumentOutOfRangeException("value");

            if (LifePoint < MaxPoint)
                LifePoint += value;
            else
                LifePoint = MaxPoint;

            Changed?.Invoke();
        }
    }
}