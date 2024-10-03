using System;

namespace Assets.Source.Code
{
    public class MobileInput : IInputService
    {
        public event Action Jumping;
        public event Action<float> Moving;

        public float HorizontalAxis { get; private set; } = 0;

        public void Tick()
        {
            HandleJumpInput();
            HandleMoveInput();
        }

        private void HandleMoveInput()
        {
            throw new NotImplementedException();
        }

        private void HandleJumpInput()
        {
            throw new NotImplementedException();
        }
    }
}
