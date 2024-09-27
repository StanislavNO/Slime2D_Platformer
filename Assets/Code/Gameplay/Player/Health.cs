using System;

namespace Assets.Source.Code
{
    public class Health
    {
        public event Action Died;

        private int _lifePoint;
        private int _minPoint = 0;

        public void TakeDamage(int value)
        {
            if (value > _minPoint)
            {
                if (_lifePoint > value)
                    _lifePoint -= value;
                else
                    Died.Invoke();
            }

            if (_lifePoint <= _minPoint)
                Died.Invoke();
        }

        public void Heal(int value)
        {
            if (value > _minPoint)
                _lifePoint += value;
        }
    }
}