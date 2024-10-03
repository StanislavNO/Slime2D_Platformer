using UnityEngine;

namespace Assets.Source.Code
{
    public class AirborneState : MovementState
    {
        private readonly AirborneStateConfig _config;
        private readonly Rigidbody2D _player;

        public AirborneState(IStateSwitcher stateSwitcher, StateMachineData data, Player character) : base(stateSwitcher, data, character)
        {
            _player = character.Rigidbody2D;
            _config = character.Config.AirborneStateConfig;
        }

        public override void Enter()
        {
            base.Enter();

            Data.Speed = _config.Speed;

            View.StartAirborne();
        }

        public override void Exit()
        {
            base.Exit();

            View.StopAirborne();
        }

        public override void Update()
        {
            base.Update();

            //Data.YVelocity -= _config.BaseGravity * Time.deltaTime;
            Data.YVelocity = _player.velocity.y;
        }
    }
}