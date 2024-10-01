namespace Assets.Source.Code
{
    public interface IStateSwitcher
    {
        void SwitchState<T>() where T : IState;
    }
}