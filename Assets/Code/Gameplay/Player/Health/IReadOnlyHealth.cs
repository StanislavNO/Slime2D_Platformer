using System;

namespace Assets.Source.Code
{
    public interface IReadOnlyHealth
    {
        event Action Died;
        event Action<int> Changed;

        int LifePoint { get; }
        int MaxPoint { get; }
    }
}
