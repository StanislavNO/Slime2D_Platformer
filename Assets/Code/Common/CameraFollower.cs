using UnityEngine;
using Zenject;

namespace Assets.Source.Code
{
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] private Vector3 _cameraOffset = new Vector3(0, 2, -10);
        [SerializeField][Range(0, 4)] private float _speed;

        private Transform _target;
        private Transform _transform;
        private Vector3 _newPosition;

        [Inject]
        private void Construct(Player player)
        {
            _target = player.transform;
        }

        private void Awake()
        {
            _transform = transform;
            _newPosition = _target.position += _cameraOffset;
        }

        private void LateUpdate()
        {
            if (_transform.position != _newPosition)
                MoveToTarget();
        }

        private void MoveToTarget()
        {
            Vector3 newPosition = _target.position;
            newPosition += _cameraOffset;

            _transform.position = Vector3.MoveTowards(
                _transform.position,
                newPosition,
                _speed * Time.deltaTime);
        }
    }
}