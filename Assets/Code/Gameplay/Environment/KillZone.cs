using Assets.Code.Gameplay.Environment;
using Assets.Code.Gameplay.Player;
using UnityEngine;

namespace Assets.Scripts.Utilities
{
    [RequireComponent(typeof(Collider2D))]
    public class KillZone : MonoBehaviour
    {
        [SerializeField] private Transform _playerSpawnPoint;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IPlayer player))
            {
                player.Warp(_playerSpawnPoint.position);
            }
            else if(other.TryGetComponent(out Barrier barrier))
            {
                other.gameObject.SetActive(false);
            }
        }
    }
}