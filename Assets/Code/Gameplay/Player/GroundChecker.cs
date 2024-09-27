using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Source.Code
{
    public class GroundChecker : MonoBehaviour
    {
        public bool IsTouches { get; private set; }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.TryGetComponent(out TilemapCollider2D _))
                IsTouches = true;
        }

        private void OnTriggerExit2D(Collider2D collider)
        {
            if (collider.TryGetComponent(out TilemapCollider2D _))
                IsTouches = false;
        }
    }
}