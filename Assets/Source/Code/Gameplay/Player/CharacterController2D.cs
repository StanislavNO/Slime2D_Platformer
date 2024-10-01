using UnityEngine;
using Zenject;

namespace Assets.Source.Code
{
    public class CharacterController2D 
    {
        private readonly float _height;

        private Rigidbody2D _rigidbody;
        private Transform _transform;

        [Inject]
        public CharacterController2D(PlayerConfig playerConfig)
        {
            _height = playerConfig.AirborneStateConfig.JumpingStateConfig.MaxHeight;
        }

        public void Initialize(Rigidbody2D rigidbody)
        {
            _rigidbody = rigidbody;
            _transform = rigidbody.transform;
        }

        public void Move(float xVelocity)
        {
            Vector2 movement = new Vector2(xVelocity, _rigidbody.velocity.y);

            _rigidbody.velocity = movement;
        }

        public void Jump()
        {
            _rigidbody.AddForce(_transform.up * _height, ForceMode2D.Impulse);
        }
    }
}