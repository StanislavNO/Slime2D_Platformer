using System;

namespace Assets.Code.Gameplay.Logic
{
    public interface IQuest
    {
        event Action Complied;
    }
}