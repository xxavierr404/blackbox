using Objects.Characters;
using UnityEngine;

namespace Objects.Projectiles
{
    public class LavaBullet: MonoBehaviour
    {
        [SerializeField] private int damage;
        
        private void OnCollisionEnter(Collision collision)
        {
            var freezable = collision.gameObject.GetComponent<Freezable>();
            if (freezable)
            {
                freezable.ResetFreezeRate();
            }

            var water = collision.gameObject.GetComponent<WaterDrop>();
            if (water)
            {
                Destroy(collision.gameObject);
            }

            var killable = collision.gameObject.GetComponent<Killable>();
            if (killable)
            {
                killable.DealDamage(damage);
            }
            
            Destroy(gameObject);
        }
    }
}