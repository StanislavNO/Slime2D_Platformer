using UnityEngine;

namespace Assets.Source.Code
{
    public class CharacterController2D : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private PlayerConfig _playerConfig;

        private float _height;

        private void Awake()
        {
            _height = _playerConfig.AirborneStateConfig.JumpingStateConfig.MaxHeight;
        }

        public void Move(float xVelocity)
        {
            Vector2 movement = new Vector2(xVelocity, _rigidbody.velocity.y);

            _rigidbody.velocity = movement;
        }

        public void Jump()
        {
            _rigidbody.AddForce(transform.up * _height, ForceMode2D.Impulse);
        }
    }
}