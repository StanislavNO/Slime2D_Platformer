using UnityEngine;

namespace Assets.Source.Code
{
    public abstract class MovementState : IState
    {
        protected readonly IStateSwitcher StateSwitcher;
        protected readonly StateMachineData Data;
        private readonly Player _player;
        private readonly SpriteRenderer _spriteRenderer;

        protected IInputService Input => _player.Input;
        protected CharacterController2D PlayerController => _player.PlayerController;
        protected PlayerView View => _player.View;

        public MovementState(IStateSwitcher stateSwitcher, StateMachineData data, Player character)
        {
            StateSwitcher = stateSwitcher;
            _player = character;
            _spriteRenderer = character.GetComponent<SpriteRenderer>();
            Data = data;
        }

        public virtual void Enter()
        {
            AddInputActionsCallbacks();
        }

        public virtual void Exit()
        {
            RemoveInputActionsCallbacks();
        }

        public void HandleInput()
        {
            Data.XInput = ReadHorizontalInput();
            Data.XVelocity = Data.XInput * Data.Speed;
        }

        public virtual void Update()
        {
            PlayerController.Move(Data.XVelocity);
            GetRotationFrom(Data.XVelocity);
        }

        protected virtual void AddInputActionsCallbacks() { }
        protected virtual void RemoveInputActionsCallbacks() { }

        protected bool IsHorizontalInputZero() => Data.XInput == 0;

        private void GetRotationFrom(float xVelocity)
        {
            if (xVelocity > 0)
                _spriteRenderer.flipX = false;

            if (xVelocity < 0)
                _spriteRenderer.flipX = true;
        }

        private float ReadHorizontalInput() => Input.HorizontalAxis;
    }
}