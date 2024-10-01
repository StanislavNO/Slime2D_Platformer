using Assets.Code.UI;
using Assets.Source.Code;
using System;
using Zenject;

namespace Assets.Code.Gameplay.Logic.Controllers
{
    public class HealthMediator : IDisposable, IInitializable
    {
        private readonly IReadOnlyHealth _health;
        private readonly HealthBar _bar;

        public HealthMediator(IReadOnlyHealth health, HealthBar healthBar)
        {
            _health = health;
            _bar = healthBar;

            _health.Changed += OnHealthChanged;
        }

        public void Dispose()=>
            _health.Changed -= OnHealthChanged;

        public void Initialize() =>
            _bar.Write(_health.LifePoint, _health.MaxPoint);

        private void OnHealthChanged() =>
            _bar.Write(_health.LifePoint, _health.MaxPoint);
    }
}