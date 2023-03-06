using System;
using UnityEngine;

namespace WeaponModules.ShootModules
{
    public class LightModule : ShootModule
    {
        [SerializeField] private new Light light;

        private void Start()
        {
            light.intensity = 0;
        }

        protected override void Update()
        {
            base.Update();
            if (light.intensity > 0)
            {
                light.intensity = 5f * TimeUntilNextShoot / shootDelay;
            }
        }

        public override void Shoot(Transform shooter)
        {
            base.Shoot(shooter);
            if (!CanShoot) return;

            light.intensity = 5f;
        }
    }
}