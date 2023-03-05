using UnityEngine;

namespace WeaponModules
{
    public abstract class ShootModule: MonoBehaviour
    {
        [SerializeField] private GameObject particle;
        public virtual void Shoot(Transform shooter)
        {
            particle.SetActive(true);
        }

        public virtual void StopShooting()
        {
            particle.SetActive(false);
        }
    }
}