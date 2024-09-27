namespace Assets.Source.Code
{
    public class JumpingState : AirborneState
    {
        private readonly JumpingStateConfig _config;

        public JumpingState(IStateSwitcher stateSwitcher, StateMachineData data, Player character) : base(stateSwitcher, data, character)
            => _config = character.Config.AirborneStateConfig.JumpingStateConfig;

        public override void Enter()
        {
            base.Enter();

            PlayerController.Jump();

            View.StartJumping();
        }

        public override void Exit()
        {
            base.Exit();

            View.StopJumping();
        }

        public override void Update()
        {
            base.Update();

            if (Data.YVelocity < 0)
                StateSwitcher.SwitchState<FallingState>();
        }
    }
}