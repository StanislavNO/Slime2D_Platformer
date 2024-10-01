using System;

namespace Assets.Source.Code
{
    public class Health : IHealthDamageHandler, IHealthRegenerator, IReadOnlyHealth
    {
        private const int MIN_POINT = 0;

        public event Action Died;
        public event Action<int> Changed;

        public int LifePoint { get; private set; }
        public int MaxPoint { get; private set; }

        public Health(PlayerConfig playerConfig)
        {
            LifePoint = playerConfig.HealthConfig.Point;
        }

        public void TakeDamage(int value)
        {
            if (value > MIN_POINT)
            {
                if (LifePoint > value)
                    LifePoint -= value;
                else
                    Died.Invoke();
            }

            if (LifePoint <= MIN_POINT)
                Died.Invoke();

            Changed?.Invoke(LifePoint);
        }

        public void Heal(int value)
        {
            if (value > MIN_POINT)
                LifePoint += value;

            Changed?.Invoke(LifePoint);
        }
    }
}