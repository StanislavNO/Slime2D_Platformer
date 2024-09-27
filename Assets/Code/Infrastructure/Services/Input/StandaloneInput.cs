using System;
using UnityEngine;

namespace Assets.Source.Code
{
    public class StandaloneInput : IInputService
    {
        private const string HORIZONTAL = "Horizontal";

        public event Action Jumping;
        public event Action<float> Moving;

        public float HorizontalAxis {get; private set;} = 0f;

        public void Tick()
        {
            HandleJumpInput();
            HandleMoveInput();
        }

        private void HandleJumpInput()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                Jumping?.Invoke();
        }

        private void HandleMoveInput()
        {
            HorizontalAxis = Input.GetAxis(HORIZONTAL);

            Moving?.Invoke(HorizontalAxis);
        }
    }
}