using System;

namespace Assets.Source.Code
{
    public interface IReadOnlyHealth
    {
        event Action Died;
        event Action Changed;

        int LifePoint { get; }
        int MaxPoint { get; }
    }
}
