using Objects.Characters;
using UnityEngine;

namespace Objects
{
    public class Acid : MonoBehaviour
    {
        [SerializeField] private int damage;

        private void OnTriggerEnter(Collider collision)
        {
            var player = collision.gameObject.GetComponent<Player>();
            if (player)
            {
                player.DealDamage(damage);
            }
        }
    }
}