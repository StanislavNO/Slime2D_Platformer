namespace Assets.Source.Code
{
    public class IdlingState : GroundedState
    {
        public IdlingState(IStateSwitcher stateSwitcher, StateMachineData data, Player character) : base(stateSwitcher, data, character)
        {
        }

        public override void Enter()
        {
            base.Enter();

            Data.Speed = 0;

            View.StartIdling();
        }

        public override void Exit()
        {
            base.Exit();

            View.StopIdling();
        }

        public override void Update()
        {
            base.Update();

            if (IsHorizontalInputZero())
                return;

            StateSwitcher.SwitchState<RunningState>();
        }
    }
}