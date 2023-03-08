using Objects.Characters;
using UnityEngine;

namespace Objects.Projectiles
{
    public class LavaBullet : MonoBehaviour
    {
        [SerializeField] private int damage;

        private void OnCollisionEnter(Collision collision)
        {
            var collisionGameObject = collision.gameObject;

            AffectFreezable(collisionGameObject);
            AffectWater(collisionGameObject);
            AffectKillable(collisionGameObject);

            Destroy(gameObject);
        }

        private void AffectFreezable(GameObject obj)
        {
            var freezable = obj.GetComponent<Freezable>();
            if (freezable) freezable.ResetFreezeRate();
        }

        private void AffectWater(GameObject obj)
        {
            var water = obj.GetComponent<WaterDrop>();
            if (water) Destroy(obj);
        }

        private void AffectKillable(GameObject obj)
        {
            var killable = obj.GetComponent<Killable>();
            if (killable) killable.DealDamage(damage);
        }
    }
}