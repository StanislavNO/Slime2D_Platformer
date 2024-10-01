namespace Assets.Source.Code
{
    public class GroundedState : MovementState
    {
        private readonly GroundChecker _groundChecker;

        public GroundedState(IStateSwitcher stateSwitcher, StateMachineData data, Player character) : base(stateSwitcher, data, character)
            => _groundChecker = character.GroundChecker;

        public override void Enter()
        {
            base.Enter();

            View.StartGrounded();
        }

        public override void Exit()
        {
            base.Exit();

            View.StopGrounded();
        }

        public override void Update()
        {
            base.Update();

            if (_groundChecker.IsTouches)
                return;

            StateSwitcher.SwitchState<FallingState>();
        }

        protected override void AddInputActionsCallbacks()
        {
            base.AddInputActionsCallbacks();

            Input.Jumping += OnJumpKeyPressed;
        }

        protected override void RemoveInputActionsCallbacks()
        {
            base.RemoveInputActionsCallbacks();

            Input.Jumping -= OnJumpKeyPressed;
        }

        private void OnJumpKeyPressed() => StateSwitcher.SwitchState<JumpingState>();
    }
}
