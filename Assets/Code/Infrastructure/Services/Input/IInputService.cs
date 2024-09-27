using System;
using Zenject;

namespace Assets.Source.Code
{
    public interface IInputService : ITickable
    {
        event Action Jumping;
        event Action<float> Moving;

        float HorizontalAxis { get; }
    }
}