using UnityEngine;

namespace WeaponModules
{
    public abstract class ShootModule: MonoBehaviour
    {
        [SerializeField] private GameObject particle;
        
        public virtual void Shoot(Transform shooter)
        {
            if (particle)
            {
                particle.SetActive(true);
            }
        }

        public virtual void StopShooting()
        {
            if (particle)
            {
                particle.SetActive(false);
            }
        }
    }
}