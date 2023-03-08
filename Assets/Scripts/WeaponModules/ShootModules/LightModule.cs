using Objects.Characters;
using UnityEngine;

namespace WeaponModules.ShootModules
{
    public class LightModule : ShootModule
    {
        [SerializeField] private new Light light;
        [SerializeField] private float shootDistance;
        [SerializeField] private float enemyStunDuration;

        private void Start()
        {
            light.intensity = 0;
        }

        protected override void Update()
        {
            base.Update();
            if (light.intensity > 0) light.intensity = 5f * TimeUntilNextShoot / shootDelay;
        }

        public override void Shoot(Transform shooter)
        {
            base.Shoot(shooter);
            if (!CanShoot) return;

            if (Physics.Raycast(transform.position, shooter.forward, out var hit, shootDistance))
            {
                var enemy = hit.collider.GetComponent<Enemy>();
                if (enemy) enemy.DisableForSeconds(enemyStunDuration);
            }

            ;

            light.intensity = 5f;
        }
    }
}