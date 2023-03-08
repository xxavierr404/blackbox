using UnityEngine;

namespace WeaponModules
{
    public abstract class ShootModule: MonoBehaviour
    {
        [SerializeField] private GameObject particle;

        [SerializeField] protected float shootDelay;
        protected float TimeUntilNextShoot;
        
        public bool CanShoot { get; private set; }

        private void Start()
        {
            TimeUntilNextShoot = 0;
        }
        
        protected virtual void Update()
        {
            if (TimeUntilNextShoot > 0)
            {
                TimeUntilNextShoot -= Time.deltaTime;
            }
        }

        public virtual void Shoot(Transform shooter)
        {
            if (TimeUntilNextShoot > 0)
            {
                CanShoot = false;
                return;
            }
            
            if (particle)
            {
                particle.SetActive(true);
            }

            CanShoot = true;
            TimeUntilNextShoot = shootDelay;
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