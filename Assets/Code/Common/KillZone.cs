using Assets.Source.Code;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using Zenject;

namespace Assets.Scripts.Utilities
{
    [RequireComponent(typeof(Collider2D))]
    public class KillZone : MonoBehaviour
    {
        [SerializeField] private Transform PlayerSpawnPoint;

        [Inject]
        private void Construct(Player player)
        {

        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            //if (other.TryGetComponent<Health>(out Health player))
            //{
            //    SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
            //}
            //else
            //{
            //    if(!other.TryGetComponent<TilemapCollider2D>(out TilemapCollider2D component))
            //        Destroy(other.gameObject);
            //}
        }
    }
}