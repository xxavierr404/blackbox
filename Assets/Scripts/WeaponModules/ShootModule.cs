using UnityEngine;

namespace WeaponModules
{
    public abstract class ShootModule: MonoBehaviour
    {
        [SerializeField] private string moduleName;
        [SerializeField] private GameObject particle;

        [SerializeField] protected float shootDelay;
        public float TimeUntilNextShoot { get; protected set; }
        
        public bool CanShoot { get; private set; }
        public string ModuleName => moduleName;

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