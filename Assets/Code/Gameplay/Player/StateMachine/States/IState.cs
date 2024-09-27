namespace Assets.Source.Code
{
    public interface IState
    {
        void Enter();
        void Exit();
        void HandleInput();
        void Update();
    }
}